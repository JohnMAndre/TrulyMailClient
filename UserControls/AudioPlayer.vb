Public Class AudioPlayer

    Private m_strFilename As String

    'Will hold the return value from the mciSendString function.
    Private m_intReturnValue As Integer
    '
    'Will contain the return data from the lpstrReturnString parameter. It
    'needs to have at least a 128 space buffer.
    Private m_strReturnData As String = Space(128)
    '
    'Will hold the return value form the mciGetErrorString function. This 
    'string also needs a 128 space buffer.
    Private m_strErrorString As String = Space(128)
    '
    'Will contain True or False if our mciGetErrorString was successful at 
    'determining our error returned from the mciSendString function.
    Private m_boolErrorSuccess As Boolean
    '
    'This is used to hold the length of the song in MS value. I didn't want
    'the timer to keep having to initiate the device for the length of the
    'song.
    Private m_intSongLengthMS As Integer


    Public ReadOnly Property Filename As String
        Get
            Return m_strFilename
        End Get
    End Property
    Public Property CurrentPosition As Long
    Public Property CurrentLength As Long
    Public Property Status As PlayerStatus

    Public Enum PlayerStatus
        NoMedia
        Stopped
        Playing
        Paused
    End Enum

#Region " API "
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal _
           lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer
    Private Declare Function mciGetErrorString Lib "winmm.dll" Alias "mciGetErrorStringA" (ByVal dwError As Integer, ByVal lpstrBuffer _
            As String, ByVal uLength As Integer) As Integer
#End Region

    Public Sub LoadMedia(ByVal filename As String)
        If filename = Nothing Then
            Exit Sub
        End If
        m_strFilename = """" & filename & """"

        'Go ahead and tell the device to close the alias even if one was
        'opened or not. No bad side effect or anything will happen if there
        'wasn't one already opened. It just a precaution I use.
        m_intReturnValue = mciSendString("close oursong", 0, 0, 0)

        'Open and create a new device with the specified filename using the
        'alias name: oursong.
        m_intReturnValue = mciSendString("open " & m_strFilename & " type mpegvideo alias oursong", 0, 0, 0)

        Status = PlayerStatus.Stopped
        picPlay.Image = ImageList1.Images("playbutton")
        ToolTip1.SetToolTip(picPlay, "Play")
    End Sub
    Public Sub Play()
        If m_strFilename = Nothing Then
            Exit Sub
        End If

        'Tell the device to play.
        m_intReturnValue = mciSendString("play oursong", 0, 0, 0)

        Dim errorSuccess As Boolean
        'Check to see what happened on the inside.
        errorSuccess = mciGetErrorString(m_intReturnValue, m_strErrorString, 128)
        '
        '
        'Get the length of the currently opened song in milli-seconds.
        m_intReturnValue = mciSendString("status oursong length", m_strReturnData, 128, 0)
        '
        m_intSongLengthMS = Val(m_strReturnData)
        '
        'Set the maximun property of the control to the length of the song 
        'so it will accurately set the current position of the device.
        Dim intDuration As Integer = Val(m_strReturnData)
        If intDuration > 0 Then
            progressSlider.Maximum = intDuration
        End If

        picPlay.Image = ImageList1.Images("pausebutton")
        Status = PlayerStatus.Playing

        ToolTip1.SetToolTip(picPlay, "Pause")
        tmrUpdateStatus.Start()
    End Sub
    Public Sub Pause()
        picPlay.Image = ImageList1.Images("playbutton")
        m_intReturnValue = mciSendString("pause oursong", 0, 0, 0)
        ToolTip1.SetToolTip(picPlay, "Resume")
        Status = PlayerStatus.Paused
    End Sub
    Public Sub StopPlaying()
        m_intReturnValue = mciSendString("stop oursong", 0, 0, 0)
        mciSendString("seek oursong to start", 0, 0, 0)
        picPlay.Image = ImageList1.Images("playbutton")
        Status = PlayerStatus.Stopped
        ToolTip1.SetToolTip(picPlay, "Play")
    End Sub
    Public Sub ResumePlaying()
        picPlay.Image = ImageList1.Images("pausebutton")
        m_intReturnValue = mciSendString("resume oursong", 0, 0, 0)
        ToolTip1.SetToolTip(picPlay, "Pause")
        Status = PlayerStatus.Playing
    End Sub
    Public Sub CloseMedia()
        Status = PlayerStatus.NoMedia

        m_intReturnValue = mciSendString("close oursong", 0, 0, 0)

        m_boolErrorSuccess = mciGetErrorString(m_intReturnValue, m_strErrorString, 128)
        ToolTip1.SetToolTip(picPlay, "Pause")
    End Sub
    Public Sub Seek(ByVal millisecondsFromStart As Long)
        Select Case Status
            Case PlayerStatus.NoMedia
                '-- ignore
            Case PlayerStatus.Paused, PlayerStatus.Stopped
                m_intReturnValue = mciSendString("seek song to " & millisecondsFromStart, 0, 0, 0)
            Case PlayerStatus.Playing
                m_intReturnValue = mciSendString("play oursong from " & millisecondsFromStart, 0, 0, 0)
        End Select
    End Sub

    Private Sub picStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picStop.Click
        StopPlaying()
    End Sub

    Private Sub picPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picPlay.Click
        Select Case Status
            Case PlayerStatus.Playing
                Pause()
            Case PlayerStatus.Paused
                ResumePlaying()
            Case PlayerStatus.Stopped
                Play()
            Case Else
                '-- do nothing
        End Select
    End Sub
    Private m_intVolume As Integer = 50
    Private m_boolMute As Boolean

    Public Property Mute As Boolean
        Get
            Return m_boolMute
        End Get
        Set(ByVal value As Boolean)
            m_boolMute = value
            If value Then
                picMute.Image = ImageList1.Images("speakerOff")
                SetVolume(0)
            Else
                picMute.Image = ImageList1.Images("speakerOn")
                SetVolume(m_intVolume)
            End If
        End Set
    End Property
    ''' <summary>
    ''' Sets volume between 1 and 1000
    ''' </summary>
    ''' <param name="volume"></param>
    ''' <remarks></remarks>
    Private Sub SetVolume(ByVal volume As Integer)
        m_intReturnValue = mciSendString("setaudio oursong volume to " & volume, 0, 0, 0)
    End Sub
    Public Property Volume As Integer
        Get
            Return m_intVolume / 10
        End Get
        Set(ByVal value As Integer)
            m_intVolume = value * 10
            SetVolume(m_intVolume)
        End Set
    End Property
    Private Sub picMute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMute.Click
        Mute = Not Mute

        If Mute Then
            picMute.Image = ImageList1.Images("SpeakerOff")
        Else
            picMute.Image = ImageList1.Images("SpeakerOn")
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrUpdateStatus.Tick
        m_intReturnValue = mciSendString("status oursong position", m_strReturnData, 128, 0)

        Dim intPosition As Integer = Val(m_strReturnData)
        Dim ts As TimeSpan = New TimeSpan(0, 0, 0, 0, intPosition)
        lblPosition.Text = FormatTimeSpan(ts)

        ts = New TimeSpan(0, 0, 0, 0, m_intSongLengthMS)
        lblDuration.Text = FormatTimeSpan(ts)

        progressSlider.Maximum = Math.Max(m_intSongLengthMS, progressSlider.Minimum + 1)
        If intPosition > progressSlider.Maximum Then
            intPosition = progressSlider.Maximum
        End If

        If Not m_boolProgressChanging Then
            progressSlider.Value = intPosition

            If intPosition = m_intSongLengthMS AndAlso m_intSongLengthMS > 1 Then
                StopPlaying()
            End If
        End If
    End Sub

    Private Sub AudioPlayer_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        CloseMedia()
    End Sub

    Private Sub volumeSlider_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles volumeSlider.Scroll
        Volume = volumeSlider.Value
        If Mute Then
            Mute = False
        End If
    End Sub
    Private m_boolProgressChanging As Boolean
    Private Sub progressSlider_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles progressSlider.MouseDown
        m_boolProgressChanging = True
    End Sub

    Private Sub progressSlider_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles progressSlider.MouseUp
        m_boolProgressChanging = False
    End Sub

    Private Sub progressSlider_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles progressSlider.Scroll
        If m_boolProgressChanging Then
            tmrSeek.Stop()
            tmrSeek.Start()
        End If
    End Sub
    Private Function FormatTimeSpan(ByVal time_span As TimeSpan, Optional ByVal whole_seconds As Boolean = True) As String
        Dim txt As String = ""

        If time_span.Hours > 0 Then
            txt &= time_span.Hours.ToString("0") & ":"
            time_span = time_span.Subtract(New TimeSpan(0, time_span.Hours, 0, 0))

            txt &= time_span.Minutes.ToString("00") & ":"
            time_span = time_span.Subtract(New TimeSpan(0, 0, time_span.Minutes, 0))
        Else
            txt &= time_span.Minutes.ToString("0") & ":"
            time_span = time_span.Subtract(New TimeSpan(0, 0, time_span.Minutes, 0))
        End If

        txt &= time_span.Seconds.ToString("00")


        ' Return the result.
        Return txt
    End Function

    Private Sub tmrSeek_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSeek.Tick
        tmrSeek.Stop()
        Seek(progressSlider.Value)
    End Sub
End Class
