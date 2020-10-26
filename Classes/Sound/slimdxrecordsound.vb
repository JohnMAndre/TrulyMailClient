Imports System.Threading
Imports SlimDX
Imports SlimDX.DirectSound
Imports SlimDX.Multimedia

Public Class SlimDXRecordSound

    Public Event SetPath(ByRef filename As String)

    Private m_boolCapturing As Boolean = False
    Private m_guidCaptureDevice As Guid = Guid.Empty
    Private m_wv As WavFile
    Private WavFormats As ArrayList


    Private Structure WavFile
        Public SampleCount As Integer
        Public miNotifySize As Integer
        Public BufferSize As Integer
        Public buffer As CaptureBuffer
        Public waveFormatEx As WaveFormat
        Public mappDevice As DirectSoundCapture
        Public mbwWriter As IO.BinaryWriter
        Public mfsWaveFile As IO.FileStream
    End Structure

    Private Enum RecordProcess
        Start
        Save
        Finish
    End Enum

    Public Function Record(ByVal start As Boolean, ByVal deviceGuid As Guid) As Boolean
        Try
            m_boolCapturing = start
            If start Then
                LoadCaptureDevices(deviceGuid)
                '--after you select device get the formats for that device.
                ScanAvailableInputFormats()
                m_wv = New WavFile
                Return StartOrStopRecord(RecordProcess.Start)
            Else
                m_boolCapturing = False
                DoneWithRecording()
            End If

        Catch ex As Exception
            Log(ex)
            'cEventLog.WriteEvent("SLIMDXRecordSound.Record: " & ex.Message.ToString, True)
        End Try
    End Function
    Private Sub DoneWithRecording()
        StartOrStopRecord(RecordProcess.Finish)
    End Sub
    Public ReadOnly Property RecordingDevices As DeviceCollection
        Get
            Return DirectSoundCapture.GetDevices
        End Get
    End Property
    ''' <summary>
    ''' Sets the module level guid of the capture device (mic) to use for recording
    ''' </summary>
    ''' <param name="deviceGuid"></param>
    ''' <remarks></remarks>
    Private Sub LoadCaptureDevices(ByVal deviceGuid As Guid)
        Try
            Dim CaptureDevices As DeviceCollection = DirectSoundCapture.GetDevices
            For Each dsDeviceInfo As DeviceInformation In CaptureDevices
                If dsDeviceInfo.DriverGuid = deviceGuid Then
                    m_guidCaptureDevice = deviceGuid
                    Exit Sub
                End If
            Next

            '-- if we didn't find a matching capture device, and we have at least one, then just load the first one
            If CaptureDevices.Count > 0 Then
                m_guidCaptureDevice = CaptureDevices(0).DriverGuid
            End If
        Catch ex As Exception
            Log(ex)
            'cEventLog.WriteEvent("SLIMDXRecordSound.LoadCaptureDevices: " & ex.Message.ToString, True)
        End Try
    End Sub
    Private Sub ScanAvailableInputFormats()
        Try
            '-----------------------------------------------------------------------------
            ' Name: ScanAvailableInputFormats()
            ' Desc: Tests to see if 20 different standard wave maryDirectSoundFormats
            ' are supported by the capture device 
            '-----------------------------------------------------------------------------
            'Dim l As New List(Of String)
            'Dim mappDevice As DirectSoundCapture = Nothing
            Dim dsCaptureBufferDesc As New CaptureBufferDescription
            'Dim dsCaptureBuffer As CaptureBuffer = Nothing
            WavFormats = New ArrayList


            ' Try 20 different standard maryDirectSoundFormats to see if they are supported
            For intIndex As Integer = 0 To 19
                Dim mvfWaveFormat As New WaveFormat
                mvfWaveFormat.FormatTag = WaveFormatTag.Pcm
                GetWaveFormatFromIndex(intIndex, mvfWaveFormat)
                ' To test if a capture mvfWaveFormat is supported, try to create a 
                ' new capture buffer using a specific mvfWaveFormat. If it works
                ' then the mvfWaveFormat is supported, otherwise not.
                dsCaptureBufferDesc.BufferBytes = mvfWaveFormat.AverageBytesPerSecond
                dsCaptureBufferDesc.Format = mvfWaveFormat
                Try
                    Using mappDevice As New DirectSoundCapture(m_guidCaptureDevice)
                        Using dsCaptureBuffer As New CaptureBuffer(mappDevice, dsCaptureBufferDesc)
                            '-- do nothing, just test if we can create things, will throw exception if we cannot
                        End Using
                    End Using
                    WavFormats.Add(mvfWaveFormat)
                    'l.Add(ConvertWaveFormatToString(mvfWaveFormat))
                Catch ex As Exception
                    Application.DoEvents() '-- for breakpoint only
                    'Finally
                    '    If Not dsCaptureBuffer Is Nothing Then dsCaptureBuffer.Dispose()
                    '    If Not mappDevice Is Nothing Then mappDevice.Dispose()
                End Try
            Next
        Catch ex As Exception
            Log(ex)
            'cEventLog.WriteEvent("SLIMDXRecordSound.ScanAvailableInputFormats:" & ex.Message.ToString, True)
        End Try
    End Sub

    Private Function StartOrStopRecord(ByVal sr As RecordProcess) As Boolean
        Try
            StartOrStopRecord = True
            '-----------------------------------------------------------------------------
            ' Name: StartOrStopRecord()
            ' Desc: Starts or stops the capture buffer from mbRecording
            '-----------------------------------------------------------------------------
            If sr = RecordProcess.Start Then
                ' Create a capture buffer, and tell the capture 
                ' buffer to start mbRecording 
                If Not CreateCaptureBuffer() Then
                    Return False
                End If
                m_wv.buffer.Start(True)
            Else
                ' Stop the buffer, and read any data that was not 
                ' caught by a notification
                If sr = RecordProcess.Finish Then
                    m_wv.buffer.Stop()
                End If

                Dim bt() As Byte = RecordCapturedData()
                If bt IsNot Nothing Then
                    Dim filepath As String = ""
                    RaiseEvent SetPath(filepath)
                    CreateRIFF(filepath)
                    ' Write the data into the wav file
                    m_wv.mbwWriter.Write(bt, 0, bt.Length)
                    CloseRiff()
                    m_wv.SampleCount = 0
                End If

                If m_wv.mappDevice IsNot Nothing Then
                    m_wv.mappDevice.Dispose()
                    m_wv.mappDevice = Nothing
                End If
            End If
        Catch ex As Exception
            StartOrStopRecord = False
            Log(ex)
            'cEventLog.WriteEvent("SLIMDXRecordSound.StartOrStopRecord: " & ex.Message.ToString, True)
        End Try
    End Function
    Private Function CreateCaptureBuffer() As Boolean
        Try
            '-----------------------------------------------------------------------------
            ' Name: CreateCaptureBuffer()
            ' Desc: Creates a capture buffer and sets the format 
            '-----------------------------------------------------------------------------
            CreateCaptureBuffer = True
            If WavFormats.Count = 0 Then
                Return False
            End If
            m_wv.mappDevice = New DirectSoundCapture(m_guidCaptureDevice)
            m_wv.waveFormatEx = WavFormats(0)
            Dim dsCaputreBufferDesc As New CaptureBufferDescription
            If Not m_wv.buffer Is Nothing Then
                m_wv.buffer.Dispose()
                m_wv.buffer = Nothing
            End If
            If m_wv.waveFormatEx.Channels = 0 Then
                Exit Function
            End If
            ' Set the notification size
            If 1024 > m_wv.waveFormatEx.AverageBytesPerSecond / 8 Then
                m_wv.miNotifySize = 1024
            Else
                m_wv.miNotifySize = m_wv.waveFormatEx.AverageBytesPerSecond / 8
            End If
            m_wv.miNotifySize = m_wv.miNotifySize - (m_wv.miNotifySize Mod m_wv.waveFormatEx.BlockAlignment)
            ' Set the buffer sizes
            m_wv.BufferSize = m_wv.waveFormatEx.AverageBytesPerSecond * 1800 '30 minutes-ish' 65
            ' Create the capture buffer
            dsCaputreBufferDesc.BufferBytes = m_wv.BufferSize
            m_wv.waveFormatEx.FormatTag = WaveFormatTag.Pcm ' Microsoft.DirectX.DirectSound.WaveFormatTag.Pcm
            dsCaputreBufferDesc.Format = m_wv.waveFormatEx ' Set the format during creatation
            m_wv.buffer = New CaptureBuffer(m_wv.mappDevice, dsCaputreBufferDesc)
        Catch ex As Exception
            Log(ex)
            'cEventLog.WriteEvent("SLIMDXRecordSound.CreateCaptureBuffer: " & ex.Message.ToString, True)
            CreateCaptureBuffer = False
        End Try
    End Function
    Private Function RecordCapturedData() As Byte()
        RecordCapturedData = Nothing
        Try
            '-----------------------------------------------------------------------------
            ' Name: RecordCapturedData()
            ' Desc: Copies data from the capture buffer to the output buffer 
            '-----------------------------------------------------------------------------
            Dim iReadPos As Integer = iReadPos
            Dim iLockSize As Integer
            iReadPos = m_wv.buffer.CurrentReadPosition
            iLockSize = iReadPos
            If iLockSize < 0 Then
                iLockSize = iLockSize + m_wv.BufferSize
                ' Block align lock size so that we are always write on a boundary
                iLockSize = iLockSize - (iLockSize Mod m_wv.miNotifySize)
            End If
            If iLockSize = 0 Then
                Return Nothing
            End If
            ReDim RecordCapturedData(iLockSize - 1)
            m_wv.buffer.Read(RecordCapturedData, 0, False)
            ' Update the number of samples, in bytes, of the file so far.
            m_wv.SampleCount = m_wv.SampleCount + RecordCapturedData.Length
            ' Move the capture offset along
        Catch ex As Exception
            Log(ex)
            'cEventLog.WriteEvent("SLIMDXRecordSound.RecordCapturedData: " & ex.Message.ToString, True)
        End Try
    End Function
    Private Sub CreateRIFF(ByVal filepath As String)
        Try
            '**************************************************************************
            'Here is where the file will be created. A
            'wave file is a RIFF file, which has chunks
            'of data that describe what the file contains.
            'A wave RIFF file is put together like this:
            'The 12 byte RIFF chunk is constructed like this:
            'Bytes(0 - 3) 'R' 'I' 'F' 'F'
            'Bytes 4 - 7 : Length of file, minus the first 8 bytes of the RIFF description.
            '(4 bytes for "WAVE" + 24 bytes for format chunk length +
            '8 bytes for data chunk description + actual sample data size.)
            'Bytes(8 - 11) 'W' 'A' 'V' 'E'
            'The 24 byte FORMAT chunk is constructed like this:
            'Bytes(0 - 3) 'f' 'm' 't' ' '
            'Bytes 4 - 7 : The format chunk length. This is always 16.
            'Bytes 8 - 9 : File padding. Always 1.
            'Bytes 10- 11: Number of channels. Either 1 for mono, or 2 for stereo.
            'Bytes 12- 15: Sample rate.
            'Bytes 16- 19: Number of bytes per second.
            'Bytes 20- 21: Bytes per sample. 1 for 8 bit mono, 2 for 8 bit stereo or
            '16 bit mono, 4 for 16 bit stereo.
            'Bytes 22- 23: Number of bits per sample.
            'The DATA chunk is constructed like this:
            'Bytes(0 - 3) 'd' 'a' 't' 'a'
            'Bytes 4 - 7 : Length of data, in bytes.
            'Bytes 8 -...: Actual sample data.
            '***************************************************************************/
            ' Open up the wave file for writing.
            ' Set up file with RIFF chunk info.
            Dim chrChunkRiff() As Char = "RIFF"
            Dim chrChunkType() As Char = "WAVE"
            Dim chrChunkFmt() As Char = "fmt "
            Dim chrChunkData() As Char = "data"
            Dim shBytesPerSample As Short = 0 ' Bytes per sample.
            Dim shPad As Short = 1 ' File padding
            Dim iFormatChunkLength As Integer = 16 ' Format chunk length.
            Dim iLength As Integer = 0 ' File length, minus first 8 bytes of RIFF description. This will be filled in later.
            m_wv.mfsWaveFile = New IO.FileStream(filepath, IO.FileMode.Create)
            m_wv.mbwWriter = New IO.BinaryWriter(m_wv.mfsWaveFile)
            ' Figure out how many bytes there will be per sample.
            If m_wv.waveFormatEx.BitsPerSample = 8 And m_wv.waveFormatEx.Channels = 1 Then
                shBytesPerSample = 1
            ElseIf (m_wv.waveFormatEx.BitsPerSample = 8 And m_wv.waveFormatEx.Channels = 2) And (m_wv.waveFormatEx.BitsPerSample = 16 And m_wv.waveFormatEx.Channels = 1) Then
                shBytesPerSample = 2
            ElseIf (m_wv.waveFormatEx.BitsPerSample = 16 And m_wv.waveFormatEx.Channels = 2) Then
                shBytesPerSample = 4
            End If
            With m_wv.mbwWriter
                .Write(chrChunkRiff)
                .Write(iLength)
                .Write(chrChunkType)
                ' Fill in the format info for the wave file.
                .Write(chrChunkFmt)
                .Write(iFormatChunkLength)
                .Write(shPad)
                .Write(m_wv.waveFormatEx.Channels)
                .Write(m_wv.waveFormatEx.SamplesPerSecond)
                .Write(m_wv.waveFormatEx.AverageBytesPerSecond)
                .Write(shBytesPerSample)
                .Write(m_wv.waveFormatEx.BitsPerSample)
                ' Now fill in the data chunk.
                .Write(chrChunkData)
                .Write(CInt(0)) ' The sample length will be written in later.
            End With
        Catch ex As Exception
            Log(ex)
            'cEventLog.WriteEvent("SLIMDXRecordSound.CreateRIFF: " & ex.Message.ToString, True)
        End Try
    End Sub
    Private Sub CloseRiff()
        Try
            With m_wv
                .mbwWriter.Seek(4, IO.SeekOrigin.Begin) ' Seek to the length descriptor of the RIFF file.
                .mbwWriter.Write(Int(m_wv.SampleCount + 36)) ' Write the file length, minus first 8 bytes of RIFF description.
                .mbwWriter.Seek(40, IO.SeekOrigin.Begin) ' Seek to the data length descriptor of the RIFF file.
                .mbwWriter.Write(m_wv.SampleCount) ' Write the length of the sample data in bytes.
                .mbwWriter.Flush()
                .mbwWriter.Close() ' Close the file now.
                .mbwWriter = Nothing ' Set the mbwWriter to null.
                .mfsWaveFile.Dispose()
                .mfsWaveFile = Nothing ' Set the FileStream to null.
            End With
        Catch ex As Exception
            Log(ex)
            'cEventLog.WriteEvent("SLIMDXRecordSound.CloseRiff: " & ex.Message.ToString, True)
        End Try
    End Sub
    Private Sub GetWaveFormatFromIndex(ByVal iIndex As Integer, ByRef wvfWaveFormat As WaveFormat)
        Try
            '-----------------------------------------------------------------------------
            ' Name: GetWaveFormatFromIndex()
            ' Desc: Returns 20 different wave maryDirectSoundFormats based on iIndex
            '-----------------------------------------------------------------------------
            Dim iSampleRate As Integer
            Dim iType As Integer
            iSampleRate = iIndex / 4
            iType = iIndex Mod 4
            With wvfWaveFormat
                Select Case iSampleRate
                    Case 4
                        .SamplesPerSecond = 48000
                    Case 3
                        .SamplesPerSecond = 44100
                    Case 2
                        .SamplesPerSecond = 22050
                    Case 1
                        .SamplesPerSecond = 11025
                    Case 0
                        .SamplesPerSecond = 8000
                End Select
                Select Case iType
                    Case 0
                        .BitsPerSample = 8
                        .Channels = 1
                    Case 1
                        .BitsPerSample = 16
                        .Channels = 1
                    Case 2
                        .BitsPerSample = 8
                        .Channels = 2
                    Case 3
                        .BitsPerSample = 16
                        .Channels = 2
                End Select
                .BlockAlignment = CShort(.Channels * (.BitsPerSample / 8))
                .AverageBytesPerSecond = .BlockAlignment * .SamplesPerSecond
            End With
        Catch ex As Exception
            Log(ex)
            'cEventLog.WriteEvent("SLIMDXRecordSound.GetWaveFormatFromIndex: " & ex.Message.ToString, True)
        End Try
    End Sub
    Private Function ConvertWaveFormatToString(ByRef wvfWaveFormat As WaveFormat) As String
        ConvertWaveFormatToString = Nothing
        Try
            '-----------------------------------------------------------------------------
            ' Name: ConvertWaveFormatToString()
            ' Desc: Converts a wave Format to a text string
            '-----------------------------------------------------------------------------
            Dim sReturn As String
            With wvfWaveFormat
                sReturn = .SamplesPerSecond & " Hz, " & .BitsPerSample & "-bit "
                If wvfWaveFormat.Channels = 1 Then
                    sReturn = sReturn & "Mono"
                Else
                    sReturn = sReturn & "Stereo"
                End If
            End With
            ConvertWaveFormatToString = sReturn
        Catch ex As Exception
            Log(ex)
            'cEventLog.WriteEvent("SLIMDXRecordSound.ConvertWaveFormatToString: " & ex.Message.ToString, True)
        End Try
    End Function
End Class
