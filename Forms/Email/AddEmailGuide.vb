Public Class AddEmailGuide

#Region " Module Level Stuff "
    Private m_boolCancel As Boolean
    Friend Enum EmailDomainConfigConnectionSecurity
        None
        SSL
    End Enum
    Private Class EmailDomainConfig
        Public Property MXLookup As Boolean
        Public Property DomainName As String
        Public Property Priority As Integer
        Public Property POPServerAddress As String
        Public Property POPServerPort As Integer
        Public Property POPUsernameFull As Boolean
        Public Property POPConnectionSecurity As EmailDomainConfigConnectionSecurity
        Public Property POPLoginSecurity As Boolean
        Public Property SMTPServerAddress As String
        Public Property SMTPServerPort As Integer
        Public Property SMTPUsernameFull As Boolean
        Public Property SMTPConnectionSecurity As EmailDomainConfigConnectionSecurity
        Public Property SMTPLoginSecurity As Boolean
        Public Sub New(ByVal configLine As String)
            Dim cols() As String = configLine.Split(vbTab)
            MXLookup = ConvertToBool(cols(0), False)
            DomainName = cols(1)
            Priority = ConvertToInt32(cols(2), 0)
            POPServerAddress = cols(3)
            POPServerPort = ConvertToInt32(cols(4), 110)
            POPUsernameFull = ConvertToBool(cols(5), True)
            POPConnectionSecurity = CType(ConvertToInt32(cols(6), 1), EmailDomainConfigConnectionSecurity)
            POPLoginSecurity = ConvertToBool(cols(7), True)

            SMTPServerAddress = cols(8)
            SMTPServerPort = ConvertToInt32(cols(9), 587)
            SMTPUsernameFull = ConvertToBool(cols(10), True)
            SMTPConnectionSecurity = CType(ConvertToInt32(cols(11), 1), EmailDomainConfigConnectionSecurity)
            SMTPLoginSecurity = ConvertToBool(cols(12), False)
        End Sub
        Public Sub New()

        End Sub
    End Class

    Private m_lstConfigs As New List(Of EmailDomainConfig)
    Private m_boolPOPSuccess, m_boolSMTPSuccess As Boolean
    Private Enum ConfigDataSource
        Server
        User
    End Enum

    Private m_configSource As ConfigDataSource
    Private m_pop As POPProfile
    Private m_smtp As SMTPProfile
    Private m_lstServerAddressThatDontExist As New List(Of String)
#End Region

    Private Sub LoadDomainConfigList(domainHint As String)
        Dim strFilename As String = GetMainAppFolder()
        strFilename = System.IO.Path.Combine(strFilename, "EmailDomainConfigs.bin")
        Dim strContents As String = GetZipContentFileText(strFilename)

        Dim strLines() As String
        strLines = strContents.Split(Environment.NewLine)
        For Each strLine In strLines
            If strLine.Contains(domainHint) Then '-- This speeds up the loading process 10x
                Dim config As New EmailDomainConfig(strLine)
                m_lstConfigs.Add(config)
                Application.DoEvents()
            End If
        Next
    End Sub
    Private Sub bgwGetDomainConfigs_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwGetDomainConfigs.DoWork
        LoadDomainConfigList(e.Argument.ToString())

        bgwTestConfigs.RunWorkerAsync()

    End Sub
    Private Sub bgwGetDomainConfigs_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwGetDomainConfigs.RunWorkerCompleted
        btnContinue.Enabled = True
        lblSearchingTitle.Text = "Verifying connections"
        btnCreateAccount.Enabled = False
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        m_boolCancel = True
        Close()
    End Sub
    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        m_boolCancel = False
        Dim boolValidToContinue As Boolean = True
        btnContinue.Enabled = False

        If Not IsValidEmailAddress(txtEmailAddress.Text) Then
            ShowMessageBoxError("Your email address is not in the correct format. It must be in the format: user@domain.com.")
            boolValidToContinue = False
        End If

        If Not txtFullName.Text.Trim.Length > 0 Then
            ShowMessageBoxError("Your name is missing.")
            boolValidToContinue = False
        End If

        If Not txtPassword.Text.Length > 0 Then
            ShowMessageBoxError("Your password is missing.")
            boolValidToContinue = False
        End If

        If EmailAddressExistsAlready(txtEmailAddress.Text) Then
            If ShowMessageBox("It appears this email address is already setup in TrulyMail. Would you like to continue anyway?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Log("Continuing to create duplicate email address.")
            Else
                boolValidToContinue = False
            End If
        End If

        Const ORIGINAL_RESOLUTION_DPI As Integer = 96
        Dim dblSizeAdjustFactor As Double = Me.AutoScaleDimensions.Height / ORIGINAL_RESOLUTION_DPI

        '-- validate
        If boolValidToContinue Then
            Dim addr As New System.Net.Mail.MailAddress(txtEmailAddress.Text)
            Dim strDomain As String = addr.Host
            pnlSearchButtons.Visible = False
            pnlCreateAccountButtons.Visible = True
            grpServerSettings.Visible = True
            Me.Height = ConvertToInt32(400 * dblSizeAdjustFactor, 500)
            llblStartOver.Visible = True

            txtFullName.Enabled = False
            txtEmailAddress.Enabled = False
            txtPassword.Enabled = False
            chkRememberPassword.Enabled = False

            bgwGetDomainConfigs.RunWorkerAsync(strDomain)
        Else
            btnContinue.Enabled = True
        End If

    End Sub
    Private Function EmailAddressExistsAlready(address As String) As Boolean
        Try
            '-- Look for existing email address in POP and SMTP profiles
            For Each pop As POPProfile In AppSettings.POPProfiles
                If IsValidEmailAddress(pop.Username) Then
                    If pop.Username.ToLower = address.ToLower Then
                        Return True
                    End If
                End If
            Next

            For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
                If smtp.DisplayEmail.ToLower = address.ToLower Then
                    Return True
                ElseIf IsValidEmailAddress(smtp.Username) Then
                    If smtp.Username.ToLower = address.ToLower Then
                        Return True
                    End If
                End If
            Next
            Return False
        Catch ex As Exception
            Log(ex) '-- just log and continue
        End Try
    End Function
    Private Sub llblWhyAskForPassword_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblWhyAskForPassword.LinkClicked
        ShowMessageBox("In order to ensure your email account is setup correctly we will try to connect using your username and password." & _
                       Environment.NewLine & Environment.NewLine & _
                       "This information is NEVER sent to TrulyMail.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub CancelAll()
        m_boolCancel = True
        If bgwGetDomainConfigs.IsBusy Then
            bgwGetDomainConfigs.CancelAsync()
        End If
        If bgwTestConfigs.IsBusy Then
            bgwTestConfigs.CancelAsync()
        End If

        If bgwTryAutoConfig.IsBusy Then
            bgwTryAutoConfig.CancelAsync()
        End If
    End Sub
    Private Sub btnCancel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel2.Click
        If bgwTestConfigs.IsBusy Then
            CancelAll()
        Else
            Close()
        End If
    End Sub
    Private Sub llblStartOver_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblStartOver.LinkClicked
        StartOver()
    End Sub
    Private Sub StartOver()
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf StartOver)
            Invoke(deleg)
        Else
            If bgwGetDomainConfigs.IsBusy Then
                bgwGetDomainConfigs.CancelAsync()
            End If
            grpServerSettings.Hide()
            grpEditedSettings.Hide()
            pnlSearchButtons.Show()
            Me.Height = 250
            pnlCreateAccountButtons.Hide()
            lblUsername.Text = String.Empty
            lblReceivingServerAddress.Text = String.Empty
            lblReceivingServerPort.Text = String.Empty
            lblReceivingConnectionEncryption.Text = String.Empty
            pbReceivingLoginSecurity.Image = Nothing
            pbReceivingStatus.Image = Nothing

            lblSendingConnectionEncryption.Text = String.Empty
            lblSendingServerAddress.Text = String.Empty
            lblSendingServerPort.Text = String.Empty
            pbSendingStatus.Image = Nothing

            pbWorking.Show()
            lblSearchingTitle.Text = "Searching TrulyMail Database"
            grpServerSecurity.Show()
            lblReceivingCaption.Show()
            lblSendingCaption.Show()
            lblUsernameCaption.Show()

            txtFullName.Enabled = True
            txtEmailAddress.Enabled = True
            txtPassword.Enabled = True
            chkRememberPassword.Enabled = True
        End If

    End Sub
    Private Sub ManualSetup()
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf ManualSetup)
            Invoke(deleg)
        Else
            If bgwGetDomainConfigs.IsBusy Then
                bgwGetDomainConfigs.CancelAsync()
            End If
            Hide()
            Dim frm As New NewAccount()
            'frm.SMTPServerAddress =
            frm.ShowDialog()
            Close()
        End If
    End Sub
    Private Delegate Sub UpdateConfigCallback(ByVal config As EmailDomainConfig)
    Private Sub UpdateConfig(ByVal config As EmailDomainConfig)
        If InvokeRequired Then
            Dim deleg As New UpdateConfigCallback(AddressOf UpdateConfig)
            Invoke(deleg, config)
        Else
            If config.POPUsernameFull Then
                lblUsername.Text = txtEmailAddress.Text
            Else
                lblUsername.Text = txtEmailAddress.Text.Substring(0, txtEmailAddress.Text.IndexOf("@") - 1)
            End If

            lblReceivingServerAddress.Text = config.POPServerAddress
            lblReceivingServerPort.Text = config.POPServerPort.ToString()

            lblReceivingConnectionEncryption.Text = config.POPConnectionSecurity.ToString
            If config.POPLoginSecurity Then
                pbReceivingLoginSecurity.Image = My.Resources.CheckMark_16
                SetToolTip(pbReceivingLoginSecurity, "Login secured by SSL")
            Else
                pbReceivingLoginSecurity.Image = My.Resources.Erase_16
            End If

            lblSendingServerAddress.Text = config.SMTPServerAddress
            lblSendingServerPort.Text = config.SMTPServerPort.ToString()
            lblSendingConnectionEncryption.Text = config.SMTPConnectionSecurity.ToString()
        End If
    End Sub
    Private Sub btnManualSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManualSetup.Click
        CancelAll()
        ManualSetup()
    End Sub
    Private Delegate Sub SetToolTipCallback(ByVal control As Control, ByVal text As String)
    Private Sub SetToolTip(ByVal control As Control, ByVal text As String)
        If InvokeRequired Then
            Dim deleg As New SetToolTipCallback(AddressOf SetToolTip)
            Invoke(deleg, control, text)
        Else
            ToolTip1.SetToolTip(control, text)
        End If
    End Sub
    Private Delegate Sub SetTextCallback(ByVal control As Control, ByVal text As String)
    Private Sub SetText(ByVal control As Control, ByVal text As String)
        If InvokeRequired Then
            Dim deleg As New SetTextCallback(AddressOf SetText)
            Invoke(deleg, control, text)
        Else
            control.Text = text
        End If
    End Sub

    Private Sub bgwTestConfigs_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwTestConfigs.DoWork
        SetText(lblSearchingTitle, "Verifying connections")
        SetImage(pbSendingStatus, Nothing)
        SetImage(pbReceivingStatus, Nothing)

        SetText(lblEditedSearchingTitle, "Verifying connections")
        SetImage(pbEditedSendingStatus, Nothing)
        SetImage(pbEditedReceivingStatus, Nothing)

        Dim boolPOPIsOK As Boolean
        Dim boolSMTPIsOK As Boolean

        Application.DoEvents()
        Dim strErrorMessage As String

        SetImage(pbReceivingStatus, Nothing)
        SetImage(pbSendingStatus, Nothing)

        Select Case m_configSource
            Case ConfigDataSource.Server
                If m_lstConfigs.Count > 0 Then
                    For intConfig = 0 To m_lstConfigs.Count - 1

                        Dim config As EmailDomainConfig = m_lstConfigs(intConfig)

                        If Not m_boolPOPSuccess Then
                            '-- If we were successful earlier, no need to keep checking POP, 
                            '   just move on to SMTP if that is where the problem lies
                            SetImage(pbSendingStatus, Nothing)
                            UpdateConfig(config)

                            m_pop = New POPProfile()
                            If config.POPUsernameFull Then
                                m_pop.Username = txtEmailAddress.Text
                            Else
                                m_pop.Username = GetUserNameFromEmailAddress(txtEmailAddress.Text)
                            End If

                            m_pop.ServerAddress = config.POPServerAddress
                            m_pop.ServerPort = config.POPServerPort
                            m_pop.Password = txtPassword.Text
                            If config.POPConnectionSecurity = EmailDomainConfigConnectionSecurity.SSL Then
                                m_pop.SecureConnection = SecureConnectionOption.SSL
                            Else
                                m_pop.SecureConnection = SecureConnectionOption.None
                            End If

                            '-- Now, test the config
                            '   Test POP first
                            If m_boolCancel Then
                                Exit Sub
                            End If
                            strErrorMessage = POPConnects(m_pop)
                            If strErrorMessage.Length = 0 Then
                                If m_pop.SecureConnection = SecureConnectionOption.SSL Then
                                    SetToolTip(pbReceivingStatus, "Encrypted receiving connection succeeded")
                                Else
                                    SetToolTip(pbReceivingStatus, "Unencrypted receiving connection succeeded")
                                End If
                                SetImage(pbReceivingStatus, My.Resources.BallGreen_16)
                                m_boolPOPSuccess = True
                            Else
                                SetImage(pbReceivingStatus, My.Resources.BallRed_16)
                                SetToolTip(pbReceivingStatus, "Receiving connection failed." & Environment.NewLine & Environment.NewLine & "Error: " & strErrorMessage.ToString())
                                m_boolPOPSuccess = False
                            End If
                        End If

                        '-- Now try SMTP
                        If Not m_boolSMTPSuccess Then
                            '-- If we were successful earlier, no need to keep checking SMTP, 
                            '   just focus on POP if that is where the problem lies
                            SetImage(pbReceivingStatus, Nothing)
                            Dim smtp As New SMTPProfile()
                            smtp.ServerName = config.SMTPServerAddress
                            smtp.ServerPort = config.SMTPServerPort
                            If config.SMTPConnectionSecurity = EmailDomainConfigConnectionSecurity.SSL Then
                                smtp.SecureConnection = SecureConnectionOption.SSL
                            Else
                                smtp.SecureConnection = SecureConnectionOption.None
                            End If
                            If config.SMTPUsernameFull Then
                                smtp.Username = txtEmailAddress.Text
                            Else
                                smtp.Username = GetUserNameFromEmailAddress(txtEmailAddress.Text)
                            End If
                            smtp.Password = txtPassword.Text

                            If m_boolCancel Then
                                Exit Sub
                            End If
                            strErrorMessage = SMTPConnects(smtp)
                            If strErrorMessage.Length = 0 Then
                                m_boolSMTPSuccess = True
                                SetImage(pbSendingStatus, My.Resources.BallGreen_16)
                                If config.SMTPConnectionSecurity = EmailDomainConfigConnectionSecurity.SSL Then
                                    SetToolTip(pbSendingStatus, "Encrypted sending connection succeeded")
                                Else
                                    SetToolTip(pbSendingStatus, "Unencrypted sending connection succeeded")
                                End If
                            Else
                                m_boolSMTPSuccess = False
                                SetImage(pbSendingStatus, My.Resources.BallRed_16)
                                SetToolTip(pbSendingStatus, "Sending connection failed." & Environment.NewLine & Environment.NewLine & "Error: " & strErrorMessage.ToString())
                            End If
                        End If

                        If m_boolPOPSuccess AndAlso m_boolSMTPSuccess Then
                            Exit For
                        End If
                    Next
                Else
                    '-- nothing in the database, prompt for manual config
                    'AutoConfigFailed()
                End If
            Case ConfigDataSource.User
                SetImage(pbEditedReceivingStatus, Nothing)
                SetImage(pbEditedSendingStatus, Nothing)

                m_boolPOPSuccess = False
                m_boolSMTPSuccess = False

                m_pop = New POPProfile()
                m_pop.Username = txtEditedUsername.Text

                m_pop.ServerAddress = txtEditedReceivingServerAddress.Text
                m_pop.ServerPort = txtEditedReceivingPort.Text
                m_pop.Password = txtPassword.Text
                If EditedReceivingSSL() Then
                    m_pop.SecureConnection = SecureConnectionOption.SSL
                Else
                    m_pop.SecureConnection = SecureConnectionOption.None
                End If

                '-- Now, test the config
                '   Test POP first
                strErrorMessage = POPConnects(m_pop)
                If strErrorMessage.Length = 0 Then
                    If m_pop.SecureConnection = SecureConnectionOption.SSL Then
                        SetToolTip(pbEditedReceivingStatus, "Encrypted receiving connection succeeded")
                    Else
                        SetToolTip(pbEditedReceivingStatus, "Unencrypted receiving connection succeeded")
                    End If
                    SetImage(pbEditedReceivingStatus, My.Resources.BallGreen_16)
                    m_boolPOPSuccess = True
                Else
                    SetImage(pbEditedReceivingStatus, My.Resources.BallRed_16)
                    SetToolTip(pbEditedReceivingStatus, "Receiving connection failed." & Environment.NewLine & Environment.NewLine & "Error: " & strErrorMessage.ToString())
                    m_boolPOPSuccess = False
                End If

                '-- Now try SMTP
                Dim smtp As New SMTPProfile()
                smtp.ServerName = txtEditedSendingServerAddress.Text
                smtp.ServerPort = txtEditedSendingPort.Text
                If EditedSendingSSL() Then
                    smtp.SecureConnection = SecureConnectionOption.SSL
                Else
                    smtp.SecureConnection = SecureConnectionOption.None
                End If
                smtp.Username = txtEditedUsername.Text
                smtp.Password = txtPassword.Text

                strErrorMessage = SMTPConnects(smtp)
                If strErrorMessage.Length = 0 Then
                    m_boolSMTPSuccess = True
                    SetImage(pbEditedSendingStatus, My.Resources.BallGreen_16)
                    If smtp.SecureConnection = SecureConnectionOption.SSL Then
                        SetToolTip(pbEditedSendingStatus, "Encrypted sending connection succeeded")
                    Else
                        SetToolTip(pbEditedSendingStatus, "Unencrypted sending connection succeeded")
                    End If
                Else
                    m_boolSMTPSuccess = False
                    SetImage(pbEditedSendingStatus, My.Resources.BallRed_16)
                    SetToolTip(pbEditedSendingStatus, "Sending connection failed." & Environment.NewLine & Environment.NewLine & "Error: " & strErrorMessage.ToString())
                End If
        End Select
    End Sub
    Private Delegate Sub SetImageCallback(ByVal pb As PictureBox, ByVal image As Bitmap)
    Private Sub SetImage(ByVal pb As PictureBox, ByVal image As Bitmap)
        If InvokeRequired Then
            Dim deleg As New SetImageCallback(AddressOf SetImage)
            Invoke(deleg, pb, image)
        Else
            pb.Image = image
        End If
    End Sub
    Private Delegate Function NoParamFunctionBooleanReturn() As Boolean
    Private Function EditedReceivingSSL() As Boolean
        If InvokeRequired Then
            Dim deleg As New NoParamFunctionBooleanReturn(AddressOf EditedReceivingSSL)
            Return Invoke(deleg)
        Else
            Return cboEditedReceivingConnectionSecurity.SelectedIndex = 1
        End If
    End Function
    Private Function EditedSendingSSL() As Boolean
        If InvokeRequired Then
            Dim deleg As New NoParamFunctionBooleanReturn(AddressOf EditedSendingSSL)
            Return Invoke(deleg)
        Else
            Return cboEditedSendingConnectionSecurity.SelectedIndex = 1
        End If
    End Function
    ''' <summary>
    ''' Returns error message or empty string if successful
    ''' </summary>
    ''' <param name="pop"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function POPConnects(ByVal pop As POPProfile) As String
        Dim strLicense As String = My.Resources.aspnetpop3_xml_lic
        aspNetPOP3.POP3.LoadLicenseString(strLicense)
        Dim popServer As aspNetPOP3.POP3
        popServer = New aspNetPOP3.POP3(pop.ServerAddress, pop.Username, pop.Password, pop.ServerPort)

        Dim ssl As New AdvancedIntellect.Ssl.SslSocket()
        If pop.SecureConnection = SecureConnectionOption.None Then
            popServer.LoadSslSocket(Nothing)
        Else
            popServer.LoadSslSocket(ssl)
        End If

        Try
            popServer.Connect()

            popServer.PopulateInboxStats() '-- Seems this is where we get an error if the username/password are wrong not .Connect()
            Dim i As Integer = popServer.InboxSize

            '-- It worked
            Return String.Empty
        Catch ex As Exception
            If ex.Message.Contains("Username and password not accepted") Then
                '-- Known bad username / password

            Else
                '-- Didn't connect
                Return ex.Message
            End If
        End Try
    End Function
    ''' <summary>
    ''' Returns error message or empty string if successful
    ''' </summary>
    ''' <param name="smtp"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SMTPConnects(ByVal smtp As SMTPProfile) As String
        Using msg As New System.Net.Mail.MailMessage()
            msg.To.Add("autodelete@trulymail.com")
            msg.Subject = "Please delete this"
            msg.Body = "This is a test message only. Please delete this."
            msg.From = New System.Net.Mail.MailAddress(txtEmailAddress.Text)

            Dim msgsender As System.Net.Mail.SmtpClient
            msgsender = New System.Net.Mail.SmtpClient(smtp.ServerName, smtp.ServerPort)

            msgsender.Credentials = New System.Net.NetworkCredential(smtp.Username, smtp.Password)
            msgsender.EnableSsl = smtp.SecureConnection = SecureConnectionOption.SSL
            msgsender.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            msgsender.Timeout = 30000 '30 seconds
            Try
                msgsender.Send(msg)

                '-- It worked
                Return String.Empty
            Catch ex As Exception
                '-- Didn't connect
                Return ex.Message
            End Try
        End Using
    End Function
    Private Sub AutoConfigFailed()
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf AutoConfigFailed)
            Invoke(deleg)
        Else
            lblSearchingTitle.Text = "Your domain was not found in the TrulyMail database."
            lblUsername.Text = "Please click the Edit button or use Manual Setup."
            grpServerSecurity.Hide()
            lblReceivingCaption.Hide()
            lblSendingCaption.Hide()
            lblUsernameCaption.Hide()
        End If
    End Sub
    Private Sub AddEmailGuide_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Height = 250
    End Sub
    Private Sub CleanUpAfterCancel()
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf CleanUpAfterCancel)
            Invoke(deleg)
        Else
            lblSearchingTitle.Text = "Process was cancelled"
            lblEditedSearchingTitle.Text = "Process was cancelled"
            btnCreateAccount.Enabled = False
            btnEditSettings.Show()
            pbWorking.Visible = False
            pbEditedWorking.Visible = False
        End If
    End Sub
    Private Sub FinishTestingAutoConfig()
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf FinishTestingAutoConfig)
            Invoke(deleg)
        Else
            If m_boolPOPSuccess AndAlso m_boolSMTPSuccess Then
                lblSearchingTitle.Text = "Connections verified"
                lblEditedSearchingTitle.Text = "Connections verified"
                btnCreateAccount.Enabled = True
            Else
                lblSearchingTitle.Text = "Connection problems. Please check."
                lblEditedSearchingTitle.Text = "Connection problems. Please check."
                btnCreateAccount.Enabled = False
            End If
            btnEditSettings.Show()
            pbWorking.Visible = False
            pbEditedWorking.Visible = False
        End If
    End Sub

    Private Sub bgwTestConfigs_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwTestConfigs.RunWorkerCompleted
        '-- I thought this was always on the UI thread but clearly it is not
        If m_boolCancel Then
            '-- User clicked cancel
            CleanUpAfterCancel()
        ElseIf m_configSource = ConfigDataSource.Server AndAlso (Not m_boolPOPSuccess) AndAlso (Not m_boolSMTPSuccess) Then
            bgwTryAutoConfig.RunWorkerAsync()
        Else
            FinishTestingAutoConfig()
        End If
    End Sub

    Private Sub btnCreateAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateAccount.Click
        Dim smtp As SMTPProfile
        Dim pop As POPProfile
        Dim boolOKToClose As Boolean
        Try
            smtp = New SMTPProfile()
            smtp.ID = Guid.NewGuid.ToString()
            smtp.DisplayEmail = txtEmailAddress.Text
            smtp.DisplayName = txtFullName.Text
            smtp.IsDefault = AppSettings.SMTPProfiles.Count = 0 '-- only default if this is the first we are adding
            smtp.Name = txtEmailAddress.Text
            If m_configSource = ConfigDataSource.Server Then
                smtp.SecureConnection = SecureConnectionOption.SSL
                smtp.ServerName = lblSendingServerAddress.Text
                smtp.ServerPort = lblSendingServerPort.Text
                smtp.Username = lblUsername.Text
                If chkRememberPassword.Checked Then
                    smtp.Password = txtPassword.Text
                End If
            Else
                smtp.SecureConnection = IIf(EditedSendingSSL(), SecureConnectionOption.SSL, SecureConnectionOption.None)
                smtp.ServerName = txtEditedSendingServerAddress.Text
                smtp.ServerPort = txtEditedSendingPort.Text
                smtp.Username = txtEditedUsername.Text
                If chkRememberPassword.Checked Then
                    smtp.Password = txtPassword.Text
                End If
            End If
            AppSettings.SMTPProfiles.Add(smtp)

            pop = New POPProfile()
            pop.ID = Guid.NewGuid.ToString()
            pop.SMTPProfileID = smtp.ID


            If m_configSource = ConfigDataSource.Server Then
                pop.ServerAddress = lblReceivingServerAddress.Text
                pop.ServerPort = lblReceivingServerPort.Text
                pop.Username = lblUsername.Text
                pop.SecureConnection = SecureConnectionOption.SSL
                pop.UseSecureAuthentication = True
                If chkRememberPassword.Checked Then
                    pop.Password = txtPassword.Text
                End If
            Else
                pop.ServerAddress = txtEditedReceivingServerAddress.Text
                pop.ServerPort = txtEditedReceivingPort.Text
                pop.Username = txtEditedUsername.Text
                pop.SecureConnection = IIf(EditedReceivingSSL(), SecureConnectionOption.SSL, SecureConnectionOption.None)
                pop.UseSecureAuthentication = EditedReceivingSSL() '-- if secure connection, use secure login
                If chkRememberPassword.Checked Then
                    pop.Password = txtPassword.Text
                End If
            End If

            pop.SendReturnReceiptSenderInAddressBook = POPReceiptOption.AskMe
            pop.SendReturnReceiptSenderNotInAddressBook = POPReceiptOption.AskMe

            pop.Name = txtEmailAddress.Text
            pop.DownloadAtInterval = True
            pop.DownloadInterval = 10 '-- 10 minutes
            pop.DownloadOnStartup = False
            pop.LeaveOnServer = False
            pop.InBoxPath = UnQualifyPath(InBoxRootPath.Substring(MessageStoreRootPath.Length))
            AppSettings.POPProfiles.Add(pop)

            AppSettings.Save()
            boolOKToClose = True
        Catch ex As Exception
            Log(ex)
            boolOKToClose = False
            ShowMessageBoxError("There was an error creating your email accounts. Please notify TrulyMail Support.")
        End Try

        If boolOKToClose Then
            Close()
        End If
    End Sub

    Private Sub btnEditSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditSettings.Click
        grpServerSettings.Hide()
        grpEditedSettings.Show()

        If lblUsername.Text.IndexOf(" ") > 0 Then
            txtEditedUsername.Text = txtEmailAddress.Text
        Else
            txtEditedUsername.Text = lblUsername.Text
        End If
        txtEditedReceivingServerAddress.Text = lblReceivingServerAddress.Text
        txtEditedReceivingPort.Text = lblReceivingServerPort.Text
        Select Case lblReceivingConnectionEncryption.Text.ToLower()
            Case "ssl"
                cboEditedReceivingConnectionSecurity.SelectedIndex = 1
            Case Else
                cboEditedReceivingConnectionSecurity.SelectedIndex = 0
        End Select

        txtEditedSendingServerAddress.Text = lblSendingServerAddress.Text
        txtEditedSendingPort.Text = lblSendingServerPort.Text
        Select Case lblSendingConnectionEncryption.Text.ToLower()
            Case "ssl"
                cboEditedSendingConnectionSecurity.SelectedIndex = 1
            Case Else
                cboEditedSendingConnectionSecurity.SelectedIndex = 0
        End Select


    End Sub

    Private Sub btnReTestSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReTestSettings.Click
        '-- Retest and if successful send to TrulyMail server for others to use (after approval by admin)
        m_boolCancel = False
        m_configSource = ConfigDataSource.User
        pbEditedWorking.Show()
        btnCreateAccount.Enabled = False
        bgwTestConfigs.RunWorkerAsync()
    End Sub

    Private Sub AddEmailGuide_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        grpServerSettings.BringToFront()
    End Sub

    Private Sub bgwTryAutoConfig_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwTryAutoConfig.DoWork
        '-- server configs failed, try to guess the server names (mail.domain.com, pop.domain.com, pop3.domain.com, etc.)
        Dim config As EmailDomainConfig
        Dim strDomain As String = GetDomainFromEmailAddress(txtEmailAddress.Text)

        '-- First, try to get POP
        Try
            For intCounterUsernameFull As Integer = 1 To 2 '-- true/false
                For intCounterServerPort As Integer = 1 To 2 '-- 995/110; includes connection security
                    For intCounterLoginSecurity As Integer = 1 To 2 '-- true/false
                        For intCounterServerAddress As Integer = 1 To 4 '-- pop/pop3/mail/imap
                            config = New EmailDomainConfig()
                            Select Case intCounterServerPort
                                Case 1
                                    config.POPServerPort = 995
                                    config.POPConnectionSecurity = EmailDomainConfigConnectionSecurity.SSL
                                Case 2
                                    config.POPServerPort = 110
                                    config.POPConnectionSecurity = EmailDomainConfigConnectionSecurity.None
                            End Select

                            Select Case intCounterServerAddress
                                Case 1
                                    config.POPServerAddress = "pop3." & strDomain
                                Case 2
                                    config.POPServerAddress = "pop." & strDomain
                                Case 3
                                    config.POPServerAddress = "mail." & strDomain
                                Case 4
                                    config.POPServerAddress = "imap." & strDomain
                            End Select

                            config.POPUsernameFull = (intCounterUsernameFull = 1)
                            config.POPLoginSecurity = (intCounterLoginSecurity = 1)

                            If (config.POPConnectionSecurity = EmailDomainConfigConnectionSecurity.None AndAlso config.POPLoginSecurity) OrElse m_lstServerAddressThatDontExist.Contains(config.POPServerAddress.ToLower()) Then
                                '-- ignore iterations which include LoginSecurely without SSL
                                '-- ignore any servers we've already found to not exist (we have 32 iterations here, no need to recheck an address if it is known not to exist)
                                '-- do nothing
                            Else
                                If TryToConnectToPOPServer(config) Then
                                    Exit Try
                                End If
                            End If

                            If m_boolCancel Then
                                Exit Sub
                            End If
                        Next
                    Next
                Next
            Next
        Catch ex As Exception
            Log(ex)
        End Try
        
        '-- Now, try to get SMTP
        Try
            For intCounterUsernameFull As Integer = 1 To 2 '-- true/false
                For intCounterServerPort As Integer = 1 To 3 '-- 587/465/110; includes connection security
                    For intCounterLoginSecurity As Integer = 1 To 2 '-- true/false
                        For intCounterServerAddress As Integer = 1 To 2 '-- smtp/mail
                            Select Case intCounterServerPort
                                Case 1
                                    config.SMTPServerPort = 587
                                    config.SMTPConnectionSecurity = EmailDomainConfigConnectionSecurity.SSL
                                Case 2
                                    config.SMTPServerPort = 465
                                    config.SMTPConnectionSecurity = EmailDomainConfigConnectionSecurity.SSL
                                Case 3
                                    config.SMTPServerPort = 25
                                    config.SMTPConnectionSecurity = EmailDomainConfigConnectionSecurity.None
                            End Select

                            Select Case intCounterServerAddress
                                Case 1
                                    config.SMTPServerAddress = "smtp." & strDomain
                                Case 2
                                    config.SMTPServerAddress = "mail." & strDomain
                                Case 3
                            End Select

                            config.SMTPUsernameFull = (intCounterUsernameFull = 1)
                            config.SMTPLoginSecurity = (intCounterLoginSecurity = 1)

                            '-- 11 Dec 2016 adding extra logging to new account setup because it is causing me great headaches in releasing TM 6.0
                            If (config.SMTPConnectionSecurity = EmailDomainConfigConnectionSecurity.None AndAlso config.SMTPLoginSecurity) Then
                                '-- ignore iterations which include LoginSecurely without SSL
                                Log("Ignoring SMTP check because SMTPConnectionSecurity was off but SMTPLoginSecurity was true - conflicting settings")
                            ElseIf m_lstServerAddressThatDontExist.Contains(config.SMTPServerAddress.ToLower()) Then
                                '-- ignore any servers we've already found to not exist (we have 24 iterations here, no need to recheck an address if it is known not to exist)
                                '-- do nothing
                                Log("Ignoring SMTP check because server address (" & config.SMTPServerAddress & ") is known to not exist.")
                            Else
                                Log("Trying to connect to SMTP server: " & config.SMTPServerAddress)
                                If TryToConnectToSMTPServer(config) Then
                                    Log("Connection successful")
                                    Exit Try
                                Else
                                    Log("Connection failed")
                                End If
                            End If
                            If m_boolCancel Then
                                Exit Sub
                            End If
                        Next
                    Next
                Next
            Next
        Catch ex As Exception
            Log(ex)
        End Try


        '-- if we still fail, let user configure
        If m_boolPOPSuccess = False OrElse m_boolSMTPSuccess = False Then
            AutoConfigFailed()
        End If
    End Sub
    Private Delegate Sub TryToConnectToPOPServerCallback(ByVal config As EmailDomainConfig)
    Private Function TryToConnectToPOPServer(ByVal config As EmailDomainConfig) As Boolean
        SetImage(pbReceivingStatus, Nothing)

        Dim strErrorMessage As String
        UpdateConfig(config)

        m_pop = New POPProfile()
        If config.POPUsernameFull Then
            m_pop.Username = txtEmailAddress.Text
        Else
            m_pop.Username = GetUserNameFromEmailAddress(txtEmailAddress.Text)
        End If

        m_pop.ServerAddress = config.POPServerAddress
        m_pop.ServerPort = config.POPServerPort
        Log("Password.Text = " & txtPassword.Text)
        m_pop.Password = txtPassword.Text
        If config.POPConnectionSecurity = EmailDomainConfigConnectionSecurity.SSL Then
            m_pop.SecureConnection = SecureConnectionOption.SSL
        Else
            m_pop.SecureConnection = SecureConnectionOption.None
        End If

        '-- Now, test the config
        strErrorMessage = POPConnects(m_pop)
        If strErrorMessage.Length = 0 Then
            If m_pop.SecureConnection = SecureConnectionOption.SSL Then
                SetToolTip(pbReceivingStatus, "Encrypted receiving connection succeeded")
            Else
                SetToolTip(pbReceivingStatus, "Unencrypted receiving connection succeeded")
            End If
            SetImage(pbReceivingStatus, My.Resources.BallGreen_16)
            m_boolPOPSuccess = True
            Return True
        Else
            If strErrorMessage.ToLower.Contains("failed dns resolution") Then
                m_lstServerAddressThatDontExist.Add(m_pop.ServerAddress.ToLower())
            End If
            SetImage(pbReceivingStatus, My.Resources.BallRed_16)
            SetToolTip(pbReceivingStatus, "Receiving connection failed." & Environment.NewLine & Environment.NewLine & "Error: " & strErrorMessage.ToString())
            m_boolPOPSuccess = False
            Return False
        End If
    End Function

    Private Delegate Sub TryToConnectToSMTPServerCallback(ByVal config As EmailDomainConfig)
    Private Function TryToConnectToSMTPServer(ByVal config As EmailDomainConfig) As Boolean
        SetImage(pbSendingStatus, Nothing)

        Dim strErrorMessage As String
        UpdateConfig(config)

        m_smtp = New SMTPProfile()
        If config.SMTPUsernameFull Then
            m_smtp.Username = txtEmailAddress.Text
        Else
            m_smtp.Username = GetUserNameFromEmailAddress(txtEmailAddress.Text)
        End If

        m_smtp.ServerName = config.POPServerAddress
        m_smtp.ServerPort = config.POPServerPort
        m_smtp.Password = txtPassword.Text
        If config.POPConnectionSecurity = EmailDomainConfigConnectionSecurity.SSL Then
            m_smtp.SecureConnection = SecureConnectionOption.SSL
        Else
            m_smtp.SecureConnection = SecureConnectionOption.None
        End If

        '-- Now, test the config
        strErrorMessage = SMTPConnects(m_smtp)
        If strErrorMessage.Length = 0 Then
            If m_smtp.SecureConnection = SecureConnectionOption.SSL Then
                SetToolTip(pbSendingStatus, "Encrypted sending connection succeeded")
            Else
                SetToolTip(pbSendingStatus, "Unencrypted sending connection succeeded")
            End If
            SetImage(pbSendingStatus, My.Resources.BallGreen_16)
            m_boolSMTPSuccess = True
            Return True
        Else
            SetImage(pbSendingStatus, My.Resources.BallRed_16)
            SetToolTip(pbSendingStatus, "Sending connection failed." & Environment.NewLine & Environment.NewLine & "Error: " & strErrorMessage.ToString())
            m_boolSMTPSuccess = False
            Return False
        End If
    End Function
    Private Sub bgwTryAutoConfig_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwTryAutoConfig.RunWorkerCompleted
        FinishTestingAutoConfig()
    End Sub
End Class
