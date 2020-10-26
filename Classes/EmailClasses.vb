<Serializable()> Friend Class POPProfile
    Implements IUsernamePassword

    Public m_dtLastChecked As Date = Date.Now
    Private m_dtStartupTime As Date = m_dtLastChecked
    Public ID As String
    Public Name As String
    Public SMTPProfileID As String '-- points to the SMTP profile to use when replying

    Public ServerAddress As String
    Public ServerPort As Integer
    Public InBoxPath As String '-- relative to ProfilePath
    Private m_strUsername As String
    Private m_strPassword As String = String.Empty
    Public PasswordDuringSession As String = String.Empty '-- never saved to settings
    Public SecureConnection As SecureConnectionOption
    Public UseSecureAuthentication As Boolean '-- ignored if SecureConnection=None

    Public DownloadOnStartup As Boolean
    Public DownloadAtInterval As Boolean
    Public DownloadInterval As Integer
    Public LeaveOnServer As Boolean
    Public SendReturnReceiptSenderInAddressBook As POPReceiptOption
    Public SendReturnReceiptSenderNotInAddressBook As POPReceiptOption
    Public Property MessagesReceived As Integer '-- number of messages received since last reset (user can reset this number at any time)
    Public Property IncludeInReceiveAll As Boolean '-- false to skip this account when receive all is called

    Public Property LastTimeMessageReceived As Date '-- date the last msg was received on this account
    Public Property LastNumberOfMessagesReceived As Integer '-- number of msgs received last time any msgs were received on this account

    Public ReadOnly Property LastCheckedForDisplay() As String
        Get
            If m_dtLastChecked = m_dtStartupTime Then
                Return String.Empty
            Else
                Dim ts As TimeSpan = Date.Now - m_dtLastChecked
                If ts.TotalMilliseconds > 0 Then
                    Return FormatTimeSpan(ts) & " ago"
                End If
            End If
        End Get
    End Property
    Public ReadOnly Property LastTimeMessageReceivedForDisplay() As String
        Get
            If LastTimeMessageReceived = m_dtStartupTime Then
                Return String.Empty
            Else
                Dim ts As TimeSpan = Date.Now - LastTimeMessageReceived
                If ts.TotalMilliseconds > 0 Then
                    Return FormatTimeSpan(ts) & " ago"
                End If
            End If
        End Get
    End Property
    Public Property LastChecked() As Date
        Get
            Return m_dtLastChecked
        End Get
        Set(ByVal value As Date)
            m_dtLastChecked = value
        End Set
    End Property
    Public Property Username() As String Implements IUsernamePassword.Username
        Get
            Return m_strUsername
        End Get
        Set(ByVal value As String)
            m_strUsername = value
        End Set
    End Property
    '-- This delegate and function added to handle cross-threaded issues with the MainFormReference
    Private Delegate Function GetPasswordCallback() As String
    Private Function GetPassword() As String
        If MainFormReference.InvokeRequired Then
            Dim deleg As New GetPasswordCallback(AddressOf GetPassword)
            Return MainFormReference.Invoke(deleg)
        Else
            If m_strPassword.Length = 0 OrElse DecryptTextSymetric(EncryptionPassword, m_strPassword).Length = 0 Then
                If PasswordDuringSession.Length = 0 Then
                    If Not PreventAnyLogin Then
                        '-- prompt user
                        Dim frm As New LoginK(Me)
                        Beep() '-- add some sound to let user to know something is happening (just incase the login form is behind the main form)
                        frm.TopLevel = True
                        frm.BringToFront()
                        frm.Owner = MainFormReference
                        Application.DoEvents()
                        If frm.ShowDialog = DialogResult.OK Then
                            Return frm.Password
                        Else
                            '-- user pressed cancel
                            Return String.Empty
                        End If
                    Else
                        Return String.Empty
                    End If
                Else
                    '-- need password, did not store, but use the password entered earlier this session
                    Return PasswordDuringSession
                End If
            Else
                Return DecryptTextSymetric(EncryptionPassword, m_strPassword)
            End If
        End If
    End Function
    Public Property Password() As String Implements IUsernamePassword.Password
        Get
            Return GetPassword()
        End Get
        Set(ByVal value As String)
            'Log("Entering set password")
            'Dim bool As Boolean
            'bool = value Is Nothing
            'Log("value is nothing: " & bool.ToString())
            'bool = EncryptionPassword Is Nothing
            'Log("EncryptionPassword is nothing: " & bool.ToString())
            'Log("Continuing set password")

            If value Is Nothing Then
                Log("POP set password = nothing")
            ElseIf EncryptionPassword Is Nothing Then
                Log("POP set password: EncryptionPassword = nothing")
            Else
                Log("POP set password: value not null, encrypt not null")
                If value.Length > 0 Then
                    m_strPassword = EncryptTextSymetric(EncryptionPassword, value, EncryptionLevelEnum.Version5Fast)
                Else
                    m_strPassword = String.Empty
                End If
            End If
        End Set
    End Property
    Public Property EncryptedPassword() As String
        Get
            If m_strPassword.Length = 0 Then
                Return String.Empty
            Else
                Return m_strPassword
            End If
        End Get
        Set(ByVal value As String)
            m_strPassword = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Dim strReturn As String = Name & " (" & ServerAddress & ")"
        Return strReturn
    End Function
End Class






<Serializable()> Friend Class SMTPProfile
    Implements IUsernamePassword

    Public ID As String
    Public Name As String
    Public IsDefault As Boolean

    Public ServerName As String
    Public ServerPort As Integer
    'Public SentItems As String '-- relative to ProfilePath
    'Public DraftsFolder As String '-- relative to ProfilePath

    Private m_strUsername As String
    Private m_strPassword As String = String.Empty
    Public PasswordDuringSession As String = String.Empty '-- never saved to settings
    Public SecureConnection As SecureConnectionOption
    'Public UseSecureAuthentication As Boolean '-- ignored if SecureConnection=None

    Public DisplayName As String
    Public DisplayEmail As String
    Public ReplyTo As String
    Public SmtpAuthentication As Integer
    Public Property MessagesSent As Integer '-- number of messages sent on this account since last reset (user can reset at any time)
    Public Overrides Function ToString() As String
        Dim strReturn As String = Name & " (" & ServerName & ")"
        If IsDefault Then
            strReturn &= " (Default)"
        End If
        Return strReturn
    End Function
    Public Property Username() As String Implements IUsernamePassword.Username
        Get
            Return m_strUsername
        End Get
        Set(ByVal value As String)
            m_strUsername = value
        End Set
    End Property
    Public Property EncryptedPassword() As String
        Get
            If m_strPassword.Length = 0 Then
                Return String.Empty
            Else
                Return m_strPassword
            End If
        End Get
        Set(ByVal value As String)
            m_strPassword = value
        End Set
    End Property
    '-- This delegate and function added to handle cross-threaded issues with the MainFormReference
    Private Delegate Function GetPasswordCallback() As String
    Private Function GetPassword() As String
        If MainFormReference.InvokeRequired Then
            Dim deleg As New GetPasswordCallback(AddressOf GetPassword)
            Return MainFormReference.Invoke(deleg)
        Else
            If m_strPassword.Length = 0 OrElse DecryptTextSymetric(EncryptionPassword, m_strPassword).Length = 0 Then
                If PasswordDuringSession.Length = 0 Then
                    If Not PreventAnyLogin Then
                        '-- prompt user
                        Dim frm As New LoginK(Me)
                        Beep() '-- add some sound to let user to know something is happening (just incase the login form is behind the main form)
                        frm.TopLevel = True
                        frm.BringToFront()
                        frm.Owner = MainFormReference
                        Application.DoEvents()
                        If frm.ShowDialog() = DialogResult.OK Then
                            Return frm.Password
                        Else
                            '-- user pressed cancel
                            Return String.Empty
                        End If
                    Else
                        Return String.Empty
                    End If
                Else
                    Return PasswordDuringSession
                End If
            Else
                Return DecryptTextSymetric(EncryptionPassword, m_strPassword)
            End If
        End If
    End Function
    Public Property Password() As String Implements IUsernamePassword.Password
        Get
            Return GetPassword()
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                Log("SMTP set password = nothing")
            ElseIf EncryptionPassword Is Nothing Then
                Log("SMTP set password: EncryptionPassword = nothing")
            Else
                Log("SMTP set password: value not null, encrypt not null")
                If value.Length > 0 Then
                    m_strPassword = EncryptTextSymetric(EncryptionPassword, value, EncryptionLevelEnum.Version5Fast)
                Else
                    m_strPassword = String.Empty
                End If
            End If
        End Set
    End Property
    Public Shared Function GetByID(ByVal id As String) As SMTPProfile
        For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
            If smtp.ID = id Then
                Return smtp
            End If
        Next
        Return Nothing '-- should never get here
    End Function
End Class