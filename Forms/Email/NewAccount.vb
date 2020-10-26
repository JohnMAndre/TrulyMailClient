Friend Class NewAccount

    Private m_strInBoxFolder As String = String.Empty
    Private m_popProfile As POPProfile
    Private m_smtpProfile As SMTPProfile

    Private Const SMTP_PORT_SSL As Integer = 465
    Private Const SMTP_PORT_SSL_GMAIL As Integer = 587
    Private Const SMTP_PORT_NORMAL As Integer = 25
    Private Const POP_PORT_SSL As Integer = 995
    Private Const POP_PORT_NORMAL As Integer = 110
    Private m_boolPOPAccountNameManuallyChanged As Boolean
    Private m_boolPOPUsernameChanging As Boolean
    Private m_boolSMTPAccountNameManuallyChanged As Boolean
    Private m_boolSMTPUsernameChanging As Boolean
    Private m_boolInitialLoad As Boolean = True

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        '-- create a new POP account (maybe smtp)
    End Sub
    Public Sub New(ByVal pop As POPProfile)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        '-- Edit existing POP account
        m_popProfile = pop
        Text = "Edit Receiving Account"
    End Sub
    Public Sub New(ByVal smtp As SMTPProfile)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        '-- Edit existing SMTP account (ignore POP)
        m_smtpProfile = smtp
        Text = "Edit Sending Account"
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

#Region " Public Properties "
    Public Property SMTPServerAddress As String
        Get
            Return txtSMTPServer.Text
        End Get
        Set(value As String)
            txtSMTPServer.Text = value
        End Set
    End Property
    Public Property SMTPServerPort As Integer
        Get
            Return ConvertToInt32(txtSMTPServerPort.Text, 80)
        End Get
        Set(value As Integer)
            txtSMTPServerPort.Text = value.ToString()
        End Set
    End Property
    Public Property SMTPUsername As String
        Get
            Return txtSMTPUsername.Text
        End Get
        Set(value As String)
            txtSMTPUsername.Text = value
        End Set
    End Property
    Public Property SMTPUserSecureConnection As Boolean
        Get
            Return chkSecureSMTPSecureAuthentication.Checked
        End Get
        Set(value As Boolean)
            chkSecureSMTPSecureAuthentication.Checked = value
        End Set
    End Property
    Public Property SMTPSecurity As SecureConnectionOption
        Get
            If rbtnSecureSMTPNone.Checked Then
                Return SecureConnectionOption.None
            ElseIf rbtnSecureSMTPTLS.Checked Then
                Return SecureConnectionOption.TLS
            ElseIf rbtnSecureSMTPSSL.Checked Then
                Return SecureConnectionOption.SSL
            End If
        End Get
        Set(value As SecureConnectionOption)
            Select Case value
                Case SecureConnectionOption.None
                    rbtnSecureSMTPNone.Checked = True
                Case SecureConnectionOption.TLS
                    rbtnSecureSMTPTLS.Checked = True
                Case SecureConnectionOption.SSL
                    rbtnSecureSMTPSSL.Checked = True
            End Select
        End Set
    End Property
#End Region
#Region " Validation Logic "
    Private Function WelcomeOK() As String
        If Not rdobtnSetupGmail.Checked AndAlso Not rdobtnSetupHotmail.Checked AndAlso Not rdobtnSetupOther.Checked Then
            Return "Please select which kind of email account you would like to setup."
        Else
            Return String.Empty
        End If
    End Function
    Private Function POP1OK() As String
        If txtPOPServer.Text.Trim.Length = 0 Then
            txtPOPServer.Focus()
            Return "Please enter your receiving server (for example, gmail.com)."
        ElseIf Not IsValidServerAddress(txtPOPServer.Text) Then
            txtPOPServer.Focus()
            Return "Please enter your receiving server in the proper format (for example, gmail.com)."
        ElseIf txtPOPUsername.Text.Trim.Length = 0 Then
            txtPOPUsername.Focus()
            Return "Please enter your receiving username (for example, suzi@gmail.com or just suzi)."
        ElseIf txtPOPAccountName.Text.Trim.Length = 0 Then
            txtPOPAccountName.Focus()
            Return "Please enter a name for this receiving account (can be anything you want)."
        Else
            Return String.Empty
        End If
    End Function
    Private Function POP2OK() As String
        If Not IsNumeric(txtDownloadFrequency.Text) Then
            txtDownloadFrequency.Focus()
            Return "Please enter a number for the number of minutes between downloads."
        Else
            Return String.Empty
        End If
    End Function
    Private Function SMTP1OK() As String
        If rbtnExistingSMTP.Checked AndAlso cboSMTPProfile.SelectedIndex < 0 Then
            cboSMTPProfile.Focus()
            Return "Please select the sending profile you want to use when replying on this account."
        Else
            Return String.Empty
        End If
    End Function
    Private Function SMTP2OK() As String
        If Not IsValidServerAddress(txtSMTPServer.Text) Then
            Return "Please enter a valid server name, like smtp.gmail.com)."
        ElseIf Not IsNumeric(txtSMTPServerPort.Text) Then
            Return "Please enter the port number. Use the default if you are unsure."
        Else
            Return String.Empty
        End If
    End Function
    Private Function SMTP3OK() As String
        If txtSMTPDisplayName.Text.Trim.Length = 0 Then
            Return "Please enter your name."
        ElseIf txtSMTPDisplayEmail.Text.Trim.Length = 0 Then
            Return "Please enter your email address."
        ElseIf Not IsValidEmailAddress(txtSMTPDisplayEmail.Text) Then
            Return "Please enter your email address in the format user@domain.com."
        ElseIf txtSMTPReplyTo.Text.Trim.Length > 0 AndAlso Not IsValidEmailAddress(txtSMTPReplyTo.Text) Then
            Return "Please enter your reply to address in the format user@domain.com or leave it blank."
        ElseIf txtSMTPAccountName.Text.Trim.Length = 0 Then
            Return "Please enter a name for this sending account (can be anything you want)."
        Else
            Return String.Empty
        End If
    End Function
#End Region

#Region " Show Group Steps "

    Private Sub ShowWelcome()
        grpPOPDetails1.Hide()
        grpWelcome.Show()
        lblStep.Text = grpWelcome.Tag.ToString()
        btnBack.Enabled = False
    End Sub
    Private Sub ShowPOP1(ByVal errorText As String)
        If errorText.Length = 0 Then
            grpPOPDetails2.Hide()
            grpPOPDetails1.Show()
            grpWelcome.Hide()
            txtPOPServer.Focus()
            lblStep.Text = grpPOPDetails1.Tag.ToString()
            btnBack.Enabled = True

            If m_popProfile IsNot Nothing Then
                '-- Populate with existing data
                Static boolAlreadyProcessed As Boolean
                '-- Only process once
                If Not boolAlreadyProcessed Then
                    boolAlreadyProcessed = True
                    txtPOPServer.Text = m_popProfile.ServerAddress
                    txtPOPServerPort.Text = m_popProfile.ServerPort
                    txtPOPUsername.Text = m_popProfile.Username
                    txtPOPAccountName.Text = m_popProfile.Name
                    m_strInBoxFolder = MessageStoreRootPath & m_popProfile.InBoxPath
                    Select Case m_popProfile.SecureConnection
                        Case SecureConnectionOption.None
                            rbtnSecurePOPNone.Checked = True
                            chkSecurePOPSecureAuthentication.Checked = False
                        Case SecureConnectionOption.TLS
                            rbtnSecurePOPTLS.Checked = True
                            chkSecurePOPSecureAuthentication.Checked = m_popProfile.UseSecureAuthentication
                        Case SecureConnectionOption.SSL
                            rbtnSecurePOPSSL.Checked = True
                            chkSecurePOPSecureAuthentication.Checked = m_popProfile.UseSecureAuthentication
                    End Select
                End If
            Else

                If m_boolInitialLoad Then
                    rbtnNewSMTP.Checked = True

                    If rdobtnSetupGmail.Checked Then
                        '-- gmail
                        txtPOPServer.Text = "pop.gmail.com"
                        txtPOPServerPort.Text = "995"
                        rbtnSecurePOPSSL.Checked = True
                        chkSecurePOPSecureAuthentication.Checked = True
                    ElseIf rdobtnSetupHotmail.Checked Then
                        '-- hotmail
                        txtPOPServer.Text = "pop3.live.com"
                        txtPOPServerPort.Text = "995"
                        rbtnSecurePOPSSL.Checked = True
                        chkSecurePOPSecureAuthentication.Checked = True
                    Else
                        '-- other
                        'txtPOPServer.Text = String.Empty
                        txtPOPServerPort.Text = "110"
                        rbtnSecurePOPSSL.Checked = False
                        chkSecurePOPSecureAuthentication.Checked = False
                    End If
                Else
                    '-- User already started changing stuff, don't start changing again
                End If
                

                txtPOPUsername.Focus()
            End If
        Else
            ShowMessageBoxError(errorText)
        End If
    End Sub
    Private Sub ShowPOP2(ByVal errorText As String)
        If errorText.Length = 0 Then
            grpPOPDetails1.Hide()
            grpSMTPDetails1.Hide()
            grpPOPDetails2.Show()
            chkDownloadAtStartup.Focus()
            lblStep.Text = grpPOPDetails2.Tag.ToString()

            If m_popProfile IsNot Nothing Then
                Static boolAlreadyProcessed As Boolean
                '-- Only process once
                If Not boolAlreadyProcessed Then
                    boolAlreadyProcessed = True
                    chkDownloadAtStartup.Checked = m_popProfile.DownloadOnStartup
                    chkDownloadAtFrequency.Checked = m_popProfile.DownloadAtInterval
                    txtDownloadFrequency.Text = m_popProfile.DownloadInterval
                    chkLeaveOnServer.Checked = m_popProfile.LeaveOnServer

                    cboSendReceiptsSenderKnown.SelectedIndex = Convert.ToInt32(m_popProfile.SendReturnReceiptSenderInAddressBook)
                    cboSendReceiptsSenderUnknown.SelectedIndex = Convert.ToInt32(m_popProfile.SendReturnReceiptSenderNotInAddressBook)
                End If
            End If
        Else
            ShowMessageBoxError(errorText)
        End If
    End Sub
    Private Sub ShowSMTP1(ByVal errorText As String)
        If errorText.Length = 0 Then
            grpSMTPDetails1.Show()
            grpPOPDetails2.Hide()
            grpSMTPDetails2.Hide()
            grpConfirm.Hide()
            txtPOPServer.Focus()
            lblStep.Text = grpSMTPDetails1.Tag.ToString()
            btnNext.Text = "&Next"

            If m_popProfile IsNot Nothing Then
                Static boolAlreadyProcessed As Boolean
                '-- Only process once
                If Not boolAlreadyProcessed Then
                    boolAlreadyProcessed = True
                    For Each smtp As SMTPProfile In cboSMTPProfile.Items
                        If smtp.ID = m_popProfile.SMTPProfileID Then
                            cboSMTPProfile.SelectedItem = smtp
                            Exit For
                        End If
                    Next
                End If
            End If
        Else
            ShowMessageBoxError(errorText)
        End If
    End Sub
    Private Sub ShowSMTP2(ByVal errorText As String)
        If errorText.Length = 0 Then
            grpSMTPDetails2.Show()
            grpSMTPDetails1.Hide()
            grpSMTPDetails3.Hide()
            txtSMTPServer.Focus()
            lblStep.Text = grpSMTPDetails2.Tag.ToString()

            If m_smtpProfile IsNot Nothing Then
                llblSMTPUsernameFromPOPUsername.Enabled = False
                btnBack.Enabled = False
            End If

            If m_smtpProfile IsNot Nothing Then
                Static boolAlreadyProcessed As Boolean
                '-- Only process once
                If Not boolAlreadyProcessed Then
                    boolAlreadyProcessed = True
                    txtSMTPServer.Text = m_smtpProfile.ServerName
                    txtSMTPServerPort.Text = m_smtpProfile.ServerPort
                    txtSMTPUsername.Text = m_smtpProfile.Username
                    Select Case m_smtpProfile.SecureConnection
                        Case SecureConnectionOption.None
                            rbtnSecureSMTPNone.Checked = True
                            chkSecureSMTPSecureAuthentication.Checked = False
                        Case SecureConnectionOption.TLS
                            rbtnSecureSMTPTLS.Checked = True
                            'chkSecureSMTPSecureAuthentication.Checked = m_smtpProfile.UseSecureAuthentication
                        Case SecureConnectionOption.SSL
                            rbtnSecureSMTPSSL.Checked = True
                            'chkSecureSMTPSecureAuthentication.Checked = m_smtpProfile.UseSecureAuthentication
                    End Select
                End If
            Else
                If rdobtnSetupGmail.Checked Then
                    '-- gmail
                    txtSMTPServer.Text = "smtp.gmail.com"
                    rbtnSecureSMTPSSL.Checked = True
                    txtSMTPServerPort.Text = "587"
                ElseIf rdobtnSetupHotmail.Checked Then
                    '-- hotmail
                    txtSMTPServer.Text = "smtp.live.com"
                    rbtnSecureSMTPSSL.Checked = True
                    txtSMTPServerPort.Text = "587"
                Else
                    '-- other
                    txtSMTPServer.Text = String.Empty
                    rbtnSecureSMTPSSL.Checked = False
                    txtSMTPServerPort.Text = "25"
                End If
                
                txtSMTPUsername.Text = txtPOPUsername.Text
                btnNext.Focus()
            End If
        Else
            ShowMessageBoxError(errorText)
        End If
    End Sub
    Private Sub ShowSMTP3(ByVal errorText As String)
        If errorText.Length = 0 Then
            grpSMTPDetails3.Show()
            grpSMTPDetails2.Hide()
            grpConfirm.Hide()
            txtSMTPDisplayName.Focus()
            lblStep.Text = grpSMTPDetails3.Tag.ToString()
            btnNext.Text = "&Next"

            btnBack.Enabled = True

            If m_smtpProfile IsNot Nothing Then
                Static boolAlreadyProcessed As Boolean
                '-- Only process once
                If Not boolAlreadyProcessed Then
                    boolAlreadyProcessed = True
                    txtSMTPDisplayName.Text = m_smtpProfile.DisplayName
                    txtSMTPDisplayEmail.Text = m_smtpProfile.DisplayEmail
                    txtSMTPReplyTo.Text = m_smtpProfile.ReplyTo

                    txtSMTPAccountName.Text = m_smtpProfile.Name
                End If
            Else
                If IsValidEmailAddress(txtPOPUsername.Text) Then
                    txtSMTPDisplayEmail.Text = txtPOPUsername.Text
                End If
            End If
        Else
            ShowMessageBoxError(errorText)
        End If
    End Sub
    Private Sub ShowConfirm(ByVal errorText As String)
        Try
            If errorText.Length = 0 Then
                grpSMTPDetails3.Hide()
                grpSMTPDetails1.Hide()
                grpConfirm.Show()
                lblStep.Text = grpConfirm.Tag.ToString()
                RichTextBox1.SendToBack()
                btnNext.Text = "&Finish"

                Dim smtp As SMTPProfile
                If rbtnExistingSMTP.Checked Then
                    smtp = cboSMTPProfile.SelectedItem
                End If

                '-- Populate all labels

                '-- SMTP settings
                If smtp IsNot Nothing AndAlso m_smtpProfile Is Nothing Then
                    '-- Existing SMTP Settings, but not editing existing smtp account
                    lblSMTPUsername.Text = smtp.Username

                    lblSMTPServer.Text = smtp.ServerName & " (" & smtp.ServerPort & ")"
                    lblSMTPSecureConnection.Text = smtp.SecureConnection.ToString

                    lblSMTPAccountName.Text = smtp.Name

                    lblDisplayName.Text = "Name: " & smtp.DisplayName
                    lblEmail.Text = "Email: " & smtp.DisplayEmail
                    If smtp.ReplyTo IsNot Nothing AndAlso smtp.ReplyTo.Length > 0 Then
                        lblReplyTo.Text = "Reply to: " & smtp.ReplyTo
                    Else
                        lblReplyTo.Text = "Reply to: " & smtp.DisplayEmail
                    End If
                Else
                    '-- Entered SMTP settigns
                    lblSMTPServer.Text = txtSMTPServer.Text.Trim & " (" & txtSMTPServerPort.Text.Trim & ")"

                    If txtSMTPUsername.Text.Trim.Length > 0 Then
                        lblSMTPUsername.Text = txtSMTPUsername.Text.Trim
                    Else
                        lblSMTPUsername.Text = "Not required"
                    End If

                    If rbtnSecureSMTPNone.Checked Then
                        lblSMTPSecureConnection.Text = "<none>"
                    ElseIf rbtnSecureSMTPTLS.Checked Then
                        lblSMTPSecureConnection.Text = "TLS"
                    Else
                        lblSMTPSecureConnection.Text = "SSL"
                    End If

                    If chkSecureSMTPSecureAuthentication.Checked Then
                        lblSMTPSecureAuthentication.Text = "Yes"
                    Else
                        lblSMTPSecureAuthentication.Text = "No"
                    End If

                    lblSMTPAccountName.Text = txtSMTPAccountName.Text

                    lblDisplayName.Text = "Name: " & txtSMTPDisplayName.Text
                    lblEmail.Text = "Email: " & txtSMTPDisplayEmail.Text
                    If txtSMTPReplyTo.Text.Length > 0 Then
                        lblReplyTo.Text = "Reply to: " & txtSMTPReplyTo.Text
                    Else
                        lblReplyTo.Text = "Reply to: " & txtSMTPDisplayEmail.Text
                    End If
                End If

                '-- POP settings
                If m_smtpProfile IsNot Nothing Then
                    lblPOPServer.Text = String.Empty
                    lblPOPUsername.Text = String.Empty
                    lblPOPSecureConnection.Text = String.Empty
                    lblPOPSecureAuthentication.Text = String.Empty
                    lblDownloadAtStartup.Text = String.Empty
                    lblDownloadAtInterval.Text = String.Empty
                    lblReceiptInBook.Text = String.Empty
                    lblReceiptNotInBook.Text = String.Empty
                    lblInBox.Text = String.Empty
                    lblPOPAccountName.Text = String.Empty
                    lblPOPTitle.Text = String.Empty
                Else
                    lblPOPServer.Text = txtPOPServer.Text & " (" & txtPOPServerPort.Text & ")"
                    lblPOPUsername.Text = txtPOPUsername.Text

                    If rbtnSecurePOPNone.Checked Then
                        lblPOPSecureConnection.Text = "<none>"
                    ElseIf rbtnSecurePOPTLS.Checked Then
                        lblPOPSecureConnection.Text = "TLS"
                    Else
                        lblPOPSecureConnection.Text = "SSL"
                    End If

                    If chkSecurePOPSecureAuthentication.Checked Then
                        lblPOPSecureAuthentication.Text = "Yes"
                    Else
                        lblPOPSecureAuthentication.Text = "No"
                    End If

                    If chkDownloadAtStartup.Checked Then
                        lblDownloadAtStartup.Text = "Download at startup"
                    Else
                        lblDownloadAtStartup.Text = "Do not download at startup"
                    End If
                    If chkDownloadAtFrequency.Checked Then
                        lblDownloadAtInterval.Text = "Download every " & txtDownloadFrequency.Text & " minutes."
                    Else
                        lblDownloadAtInterval.Text = "Do not download periodically"
                    End If
                    Select Case cboSendReceiptsSenderKnown.SelectedIndex
                        Case 0
                            lblReceiptInBook.Text = "Receipt if sender is known: Ask"
                        Case 1
                            lblReceiptInBook.Text = "Receipt if sender is known: Send"
                        Case 2
                            lblReceiptInBook.Text = "Receipt if sender is known: None"
                    End Select

                    Select Case cboSendReceiptsSenderUnknown.SelectedIndex
                        Case 0
                            lblReceiptNotInBook.Text = "Receipt if sender is unknown: Ask"
                        Case 1
                            lblReceiptNotInBook.Text = "Receipt if sender is unknown: Send"
                        Case 2
                            lblReceiptNotInBook.Text = "Receipt if sender is unknown: None"
                    End Select
                    Dim strInBox As String = ToolTip1.GetToolTip(llblChangeInbox)
                    lblInBox.Text = "InBox: '" & strInBox & "'"

                    lblPOPAccountName.Text = txtPOPAccountName.Text

                End If

                If m_smtpProfile IsNot Nothing Then
                    '-- hide folders label since we will not show POP info
                    lblFoldersLabel.Visible = False
                End If
            Else
                ShowMessageBoxError(errorText)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error. Please contact TrulyMail Support.")
            Close()
        End Try
    End Sub
#End Region
#Region " Rtf Messages "
    Private Function GetRtfMessage(ByVal sender As Control) As String
        Select Case sender.Name
            Case RichTextBox1.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Getting Help\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\pard You have selected the help area. To get help, select the item on which you would like help. Then, you will see that help here.\f1\fs17\par" & Environment.NewLine & _
                        "}"
            Case rdobtnSetupGmail.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Setup Gmail Account\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "If your email account is hosted by Google (Gmail), select this. It will automatically complete most of the information for you.\f1\par" & Environment.NewLine & _
                        "}"
            Case rdobtnSetupHotmail.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Setup Hotmail Account\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "If your email account is hosted by Hotmail (Live.com), select this. It will automatically complete most of the information for you.\f1\par" & Environment.NewLine & _
                        "}"
            Case rdobtnSetupOther.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Setup Different (non-Gmail) Account\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "You can use this option for any email account which provides POP3 access. When in doubt choose this option.\f1\par" & Environment.NewLine & _
                        "}"
            Case txtPOPUsername.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}{\f2\fnil\fcharset2 Symbol;}}" & Environment.NewLine & _
                        "{\*\generator Msftedit 5.41.15.1515;}\viewkind4\uc1\pard\b\f0\fs20 Receiving Username\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\b0 This is where you put your username on the receiving server you entered above.\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Examples include:\par" & Environment.NewLine & _
                        "\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li360 user@domain.com\par" & Environment.NewLine & _
                        "{\pntext\f2\'B7\tab}user\f1\par" & Environment.NewLine & _
                        "}"
            Case txtPOPServer.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}{\f2\fnil\fcharset2 Symbol;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Receiving Server\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "This is where you put the address of the server which holds your messages.\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Examples include:\par" & Environment.NewLine & _
                        "\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li360 pop.gmail.com\par" & Environment.NewLine & _
                        "{\pntext\f2\'B7\tab}pop.mail.lycos.com\par" & Environment.NewLine & _
                        "{\pntext\f2\'B7\tab}pop1.mail.com\par" & Environment.NewLine & _
                        "\pard\f1\fs20\par" & Environment.NewLine & _
                        "}"
            Case txtPOPServerPort.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}{\f2\fnil\fcharset0 Microsoft Sans Serif;}{\f3\fnil\fcharset2 Symbol;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Port\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\b0 Leave this as the default number unless you have received instructions to change it\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Examples include:\par" & Environment.NewLine & _
                        "\pard{\pntext\f3\'B7\tab}{\*\pn\pnlvlblt\pnf3\pnindent0{\pntxtb\'B7}}\fi-360\li360 110\par" & Environment.NewLine & _
                        "{\pntext\f3\'B7\tab}995\f1\par" & Environment.NewLine & _
                        "\pard\f2\fs17\par" & Environment.NewLine & _
                        "}"
            Case llblChangeInbox.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}{\f2\fnil\fcharset0 Microsoft Sans Serif;}{\f3\fnil\fcharset2 Symbol;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Account InBox\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\b0 Where would you like new messages for this account to be stored? Click the dropdown and select the folder.\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Examples include:\par" & Environment.NewLine & _
                        "\pard{\pntext\f3\'B7\tab}{\*\pn\pnlvlblt\pnf3\pnindent0{\pntxtb\'B7}}\fi-360\li360 InBox\f1\par" & Environment.NewLine & _
                        "\pard\f2\fs17\par" & Environment.NewLine & _
                        "}"
            Case txtPOPAccountName.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}{\f2\fnil\fcharset0 Microsoft Sans Serif;}{\f3\fnil\fcharset2 Symbol;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Account Name\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\b0 What would you like to call this receiving email account? It can be anything you want because it is for your reference only.\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Examples include:\par" & Environment.NewLine & _
                        "\pard{\pntext\f3\'B7\tab}{\*\pn\pnlvlblt\pnf3\pnindent0{\pntxtb\'B7}}\fi-360\li360 Work Email\f1\par" & Environment.NewLine & _
                        "\f0{\pntext\f3\'B7\tab}Personal Gmail\f1\par" & Environment.NewLine & _
                        "\pard\f2\fs17\par" & Environment.NewLine & _
                        "}"


            Case rbtnSecurePOPNone.Name, rbtnSecurePOPTLS.Name, rbtnSecurePOPSSL.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Use Secure Connection\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\b0 Some receiving servers support secure (encrypted) communication. This keeps others from spying on you while you are downloading your messages. If your server does not support encryption, select None. Otherwise, select the type of encryption your server supports.\par" & Environment.NewLine & _
                        "}"
            Case chkSecurePOPSecureAuthentication.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Use Secure Authentication\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\b0 Normally, secure (encrypted) connections only affect the connection after your username and password have been sent and accepted. Some servers allow you to encrypt your username and password as well. Check this box if your server does support encrypting your username and password.\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "}"


            Case chkDownloadAtStartup.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Download new messages as startup\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Check this box if you want any messages waiting on this server to be downloaded when you start TrulyMail.\f1\fs17\par" & Environment.NewLine & _
                        "}"
            Case chkDownloadAtFrequency.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Download new messages every __ minutes\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Check this box if you want any messages waiting on this server to be downloaded periodically (you must also choose the number of minutes in the text box to the right).\f1\fs17\par" & Environment.NewLine & _
                        "}"
            Case txtDownloadFrequency.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Download new messages every __ minutes\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Choose the number of minutes you want to wait before automatically downloading new messages for this account (you must also check the checkbox to the left).\f1\fs17\par" & Environment.NewLine & _
                        "}"
            Case chkLeaveOnServer.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Leave messages on the server\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Check this box if, after downloading new messages, you want those messages to remain on the server.\f1\fs17\par" & Environment.NewLine & _
                        "}"

            Case cboSendReceiptsSenderKnown.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Send return receipts to senders in my address book\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "When you receive a message from a sender who is in your address book, and they request a read receipt, do you want to send the receipt automatically?\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Yes = send without asking\par" & Environment.NewLine & _
                        "Ask = ask me each time\par" & Environment.NewLine & _
                        "No = do not send\f1\fs17\par" & Environment.NewLine & _
                        "}"

            Case cboSendReceiptsSenderUnknown.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Send return receipts to senders not in my address book\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "When you receive a message from a sender who is not in your address book, and they request a read receipt, do you want to send the receipt automatically?\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Yes = send without asking\par" & Environment.NewLine & _
                        "Ask = ask me each time\par" & Environment.NewLine & _
                        "No = do not send\f1\fs17\par" & Environment.NewLine & _
                        "}"


                '--------------------------
                '--------- S M T P --------
                '--------------------------
            Case rbtnExistingSMTP.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Existing Sending Settings\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\pard Choose this option if you have already setup a sending (SMTP) server and wish to use those same settings when replying to messages from this account.\f1\fs17\par" & Environment.NewLine & _
                        "}"
            Case rbtnNewSMTP.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 New Sending Settings\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\pard Choose this option if you wish to use different sending (SMTP) settings than any you have already created.\f1\fs17\par" & Environment.NewLine & _
                        "}"
            Case cboSMTPProfile.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Existing Sending Profile Selector\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\pard Choose, from the dropdown, which sending (SMTP) settings you would like to use with this account.\f1\fs17\par" & Environment.NewLine & _
                        "}"


            Case txtSMTPDisplayName.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}{\f2\fnil\fcharset2 Symbol;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Your Name\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\pard When sending from this sending account, what name would you like your recipients to see?\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\pard Example:\par" & Environment.NewLine & _
                        "\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li360 John Q. Public\par" & Environment.NewLine & _
                        "\pard\f1\fs17\par" & Environment.NewLine & _
                        "}"
            Case txtSMTPDisplayEmail.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}{\f2\fnil\fcharset2 Symbol;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Your Email\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\pard When sending from this sending account, from what email address would you like your recipients to see this email coming?\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\pard Example:\par" & Environment.NewLine & _
                        "\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li360 user@domain.com\par" & Environment.NewLine & _
                        "\pard\f1\fs17\par" & Environment.NewLine & _
                        "}"
            Case txtSMTPReplyTo.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}{\f2\fnil\fcharset2 Symbol;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Reply To\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\pard When sending from this sending account, to what email address would you like your recipients to reply?\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "If you leave this blank, your email address entered above will be used.\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\pard Example:\par" & Environment.NewLine & _
                        "\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li360 user@domain.com\par" & Environment.NewLine & _
                        "\pard\f1\fs17\par" & Environment.NewLine & _
                        "}"
            Case txtSMTPAccountName.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Name of This Sending Account\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "\pard This can be anything you want since it will be for your reference only. If you setup additional receiving email accounts, you will see this in the dropdown list of sending accounts.\f1\fs17\par" & Environment.NewLine & _
                        "}"
                'Case cboSMTPDraftsFolder.Name
                '    Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                '            "\viewkind4\uc1\pard\b\f0\fs20 Store Drafts In\b0\par" & Environment.NewLine & _
                '            "\par" & Environment.NewLine & _
                '            "\pard This is the folder where, when using this account to send a message, drafts of that message will be kept.\f1\fs17\par" & Environment.NewLine & _
                '            "}"
                'Case cboSMTPSentItemsFolder.Name, chkSMTPStoreSentMessage.Name
                '    Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                '            "\viewkind4\uc1\pard\b\f0\fs20 Store a Copy In\b0\par" & Environment.NewLine & _
                '            "\par" & Environment.NewLine & _
                '            "\pard This is the folder where, when using this account to send a message, a copy of that message will be kept. If you uncheck the box, no copy will be kept.\f1\fs17\par" & Environment.NewLine & _
                '            "}"

            Case txtSMTPServer.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}{\f2\fnil\fcharset2 Symbol;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Sending Server\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Enter the name of your sending server here.\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Examples include:\par" & Environment.NewLine & _
                        "\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li360 smtp.gmail.com\par" & Environment.NewLine & _
                        "{\pntext\f2\'B7\tab}smtp.mail.lycos.com\par" & Environment.NewLine & _
                        "{\pntext\f2\'B7\tab}smtp1.mail.com\par" & Environment.NewLine & _
                        "\pard\f1\fs17\par" & Environment.NewLine & _
                        "}"
            Case txtSMTPServerPort.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}{\f2\fnil\fcharset2 Symbol;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Port\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Leave this as the default number unless you have received instructions to change it.\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Examples include:\par" & Environment.NewLine & _
                        "\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li360 25\f1\fs17\par" & Environment.NewLine & _
                        "\f0\fs20{\pntext\f2\'B7\tab}465\f1\fs17\par" & Environment.NewLine & _
                        "}"
            Case txtSMTPUsername.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}{\f2\fnil\fcharset2 Symbol;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Sending Username\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "If your sending server does not require you to login before sending messages, then leave this blank. Otherwise, enter your sending username here.\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Examples include:\par" & Environment.NewLine & _
                        "\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li360 user@domain.com\f1\fs17\par" & Environment.NewLine & _
                        "\f0\fs20{\pntext\f2\'B7\tab}user\f1\fs17\par" & Environment.NewLine & _
                        "}"
            Case rbtnSecureSMTPNone.Name, rbtnSecureSMTPTLS.Name, rbtnSecureSMTPSSL.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Use Secure Connection\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Some sending servers support secure (encrypted) communication. This keeps others from spying on you while you are sending your messages. If your server does not support encryption, select None. Otherwise, select the type of encryption your server supports.\f1\fs17\par" & Environment.NewLine & _
                        "}"
            Case chkSecureSMTPSecureAuthentication.Name
                Return "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}}" & Environment.NewLine & _
                        "\viewkind4\uc1\pard\b\f0\fs20 Use Secure Authentication\b0\par" & Environment.NewLine & _
                        "\par" & Environment.NewLine & _
                        "Normally, secure (encrypted) connections only affect the connection after your username and password have been sent and accepted. Some servers allow you to encrypt your username and password as well. Check this box if your server does support encrypting your username and password.\f1\fs17\par" & Environment.NewLine & _
                        "}"
            Case Else
                Return String.Empty
        End Select
    End Function
#End Region
    Private Sub Finish()
        If m_smtpProfile IsNot Nothing Then
            '-- Just update the existing smtp profile
            m_smtpProfile.Name = txtSMTPAccountName.Text.Trim
            m_smtpProfile.DisplayEmail = txtSMTPDisplayEmail.Text.Trim
            m_smtpProfile.DisplayName = txtSMTPDisplayName.Text.Trim
            m_smtpProfile.ReplyTo = txtSMTPReplyTo.Text.Trim
            m_smtpProfile.ServerName = txtSMTPServer.Text.Trim
            m_smtpProfile.ServerPort = txtSMTPServerPort.Text.Trim
            m_smtpProfile.Username = txtSMTPUsername.Text.Trim

            If rbtnSecureSMTPNone.Checked Then
                m_smtpProfile.SecureConnection = SecureConnectionOption.None
            ElseIf rbtnSecureSMTPTLS.Checked Then
                m_smtpProfile.SecureConnection = SecureConnectionOption.TLS
            Else
                m_smtpProfile.SecureConnection = SecureConnectionOption.SSL
            End If
        Else
            '-- Create SMTP, if new
            Dim strSMTPID As String
            If rbtnNewSMTP.Checked Then
                Dim smtp As New SMTPProfile
                smtp.ID = Guid.NewGuid.ToString()
                strSMTPID = smtp.ID
                smtp.Name = txtSMTPAccountName.Text.Trim
                smtp.IsDefault = cboSMTPProfile.Items.Count = 0 '-- if this is first, it is default

                smtp.DisplayEmail = txtSMTPDisplayEmail.Text.Trim
                smtp.DisplayName = txtSMTPDisplayName.Text.Trim
                smtp.ReplyTo = txtSMTPReplyTo.Text

                smtp.ServerName = txtSMTPServer.Text.Trim
                smtp.ServerPort = txtSMTPServerPort.Text.Trim
                smtp.Username = txtSMTPUsername.Text.Trim
                smtp.Password = String.Empty
                If rbtnSecureSMTPNone.Checked Then
                    smtp.SecureConnection = SecureConnectionOption.None
                ElseIf rbtnSecureSMTPTLS.Checked Then
                    smtp.SecureConnection = SecureConnectionOption.TLS
                Else
                    smtp.SecureConnection = SecureConnectionOption.SSL
                End If

                AppSettings.SMTPProfiles.Add(smtp)
            Else
                '-- just use this smtp account with this pop account
                strSMTPID = CType(cboSMTPProfile.SelectedItem, SMTPProfile).ID
            End If

            If m_popProfile IsNot Nothing Then
                '-- Update POP
                m_popProfile.Name = txtPOPAccountName.Text.Trim
                m_popProfile.DownloadAtInterval = chkDownloadAtFrequency.Checked
                m_popProfile.DownloadInterval = Convert.ToInt32(txtDownloadFrequency.Text)
                m_popProfile.DownloadOnStartup = chkDownloadAtStartup.Checked
                m_popProfile.InBoxPath = UnQualifyPath(m_strInBoxFolder.Substring(MessageStoreRootPath.Length))
                m_popProfile.LeaveOnServer = chkLeaveOnServer.Checked
                m_popProfile.Username = txtPOPUsername.Text.Trim
                If rbtnSecurePOPNone.Checked Then
                    m_popProfile.SecureConnection = SecureConnectionOption.None
                ElseIf rbtnSecurePOPTLS.Checked Then
                    m_popProfile.SecureConnection = SecureConnectionOption.TLS
                Else
                    m_popProfile.SecureConnection = SecureConnectionOption.SSL
                End If
                m_popProfile.UseSecureAuthentication = chkSecurePOPSecureAuthentication.Checked
                m_popProfile.SendReturnReceiptSenderInAddressBook = CType(cboSendReceiptsSenderKnown.SelectedIndex, POPReceiptOption)
                m_popProfile.SendReturnReceiptSenderNotInAddressBook = CType(cboSendReceiptsSenderUnknown.SelectedIndex, POPReceiptOption)
                m_popProfile.ServerAddress = txtPOPServer.Text.Trim
                m_popProfile.ServerPort = Convert.ToInt32(txtPOPServerPort.Text)
                m_popProfile.SMTPProfileID = strSMTPID
            Else
                '-- Create POP
                Dim pop As New POPProfile
                pop.ID = Guid.NewGuid.ToString()
                pop.Name = txtPOPAccountName.Text.Trim
                pop.DownloadAtInterval = chkDownloadAtFrequency.Checked
                pop.DownloadInterval = Convert.ToInt32(txtDownloadFrequency.Text)
                pop.DownloadOnStartup = chkDownloadAtStartup.Checked
                pop.InBoxPath = UnQualifyPath(m_strInBoxFolder.Substring(MessageStoreRootPath.Length))
                pop.LeaveOnServer = chkLeaveOnServer.Checked
                pop.Username = txtPOPUsername.Text.Trim
                pop.Password = String.Empty
                If rbtnSecurePOPNone.Checked Then
                    pop.SecureConnection = SecureConnectionOption.None
                ElseIf rbtnSecurePOPTLS.Checked Then
                    pop.SecureConnection = SecureConnectionOption.TLS
                Else
                    pop.SecureConnection = SecureConnectionOption.SSL
                End If
                pop.UseSecureAuthentication = chkSecurePOPSecureAuthentication.Checked
                pop.SendReturnReceiptSenderInAddressBook = CType(cboSendReceiptsSenderKnown.SelectedIndex, POPReceiptOption)
                pop.SendReturnReceiptSenderNotInAddressBook = CType(cboSendReceiptsSenderUnknown.SelectedIndex, POPReceiptOption)
                pop.ServerAddress = txtPOPServer.Text.Trim
                pop.ServerPort = Convert.ToInt32(txtPOPServerPort.Text)
                pop.SMTPProfileID = strSMTPID

                AppSettings.POPProfiles.Add(pop)
            End If
        End If

        AppSettings.Save()

        Close()
    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If grpWelcome.Visible Then
            ShowPOP1(WelcomeOK)
        ElseIf grpPOPDetails1.Visible Then
            ShowPOP2(POP1OK)
        ElseIf grpPOPDetails2.Visible Then
            ShowSMTP1(POP2OK)
        ElseIf grpSMTPDetails1.Visible Then
            If rbtnExistingSMTP.Checked Then
                ShowConfirm(SMTP1OK)
            Else
                ShowSMTP2(SMTP1OK)
            End If
        ElseIf grpSMTPDetails2.Visible Then
            CheckForSpecialSMTPPort()
            ShowSMTP3(SMTP2OK)
        ElseIf grpSMTPDetails3.Visible Then
            ShowConfirm(SMTP3OK)
        ElseIf grpConfirm.Visible Then
            Finish()
        End If
    End Sub

    Private Sub NewAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If m_popProfile IsNot Nothing Then
            ShowPOP1(String.Empty)
        ElseIf m_smtpProfile IsNot Nothing Then
            ShowSMTP2(String.Empty)
        Else
            grpWelcome.BringToFront()
            ShowWelcome()
        End If

        '-- Defaults
        If m_popProfile IsNot Nothing Then
            m_strInBoxFolder = MessageStoreRootPath & m_popProfile.InBoxPath

            cboSendReceiptsSenderKnown.SelectedIndex = m_popProfile.SendReturnReceiptSenderInAddressBook
            cboSendReceiptsSenderUnknown.SelectedIndex = m_popProfile.SendReturnReceiptSenderNotInAddressBook
        Else
            m_strInBoxFolder = InBoxRootPath

            cboSendReceiptsSenderKnown.SelectedIndex = 0
            cboSendReceiptsSenderUnknown.SelectedIndex = 0
        End If

        SetInBoxPathLabel(m_strInBoxFolder)


        '-- Load SMTP Profiles
        Dim lst As List(Of SMTPProfile) = AppSettings.SMTPProfiles
        For Each profile As SMTPProfile In lst
            cboSMTPProfile.Items.Add(profile)
        Next
        If cboSMTPProfile.Items.Count = 0 Then
            rbtnExistingSMTP.Enabled = False
            rbtnNewSMTP.Checked = True
        End If

        '-- setup RTF labels
        rtbSetupHotmail.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Arial;}}" & Environment.NewLine & _
                            "{\colortbl ;\red255\green0\blue0;}" & Environment.NewLine & _
                            "\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\fs20 I want to use my existing \cf1\b Hotmail / Live.com / MSN / Outlook.com \cf0\b0 email account\lang1033\par" & Environment.NewLine & _
                            "}"

        rtbSetupGmail.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Arial;}}" & Environment.NewLine & _
                            "{\colortbl ;\red255\green0\blue0;}" & Environment.NewLine & _
                            "\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\fs20 I want to use my existing \cf1\b Google / Gmail \cf0\b0 email account\lang1033\par" & Environment.NewLine & _
                            "}"

        rtbSetupOther.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Arial;}}" & Environment.NewLine & _
                            "{\colortbl ;\red255\green0\blue0;}" & Environment.NewLine & _
                            "\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\fs20 I want to use my existing email account hosted \cf1\b somewhere else\cf0\lang1033\b0\par" & Environment.NewLine & _
                            "}"
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        If grpPOPDetails1.Visible Then
            ShowWelcome()
        ElseIf grpPOPDetails2.Visible Then
            ShowPOP1(String.Empty)
        ElseIf grpSMTPDetails1.Visible Then
            ShowPOP2(String.Empty)
        ElseIf grpSMTPDetails2.Visible Then
            ShowSMTP1(String.Empty)
        ElseIf grpSMTPDetails3.Visible Then
            ShowSMTP2(String.Empty)
        ElseIf grpConfirm.Visible Then
            If m_smtpProfile Is Nothing AndAlso rbtnExistingSMTP.Checked Then
                ShowSMTP1(String.Empty)
            Else
                ShowSMTP3(String.Empty)
            End If
        End If
    End Sub

    Private Sub rbtnExistingSMTP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnExistingSMTP.CheckedChanged
        cboSMTPProfile.Enabled = rbtnExistingSMTP.Checked
    End Sub

    Private Sub Control_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOPServer.Enter, txtPOPUsername.Enter, txtPOPServerPort.Enter, txtPOPAccountName.Enter, rbtnSecurePOPTLS.Enter, rbtnSecurePOPSSL.Enter, rbtnSecurePOPNone.Enter, chkSecurePOPSecureAuthentication.Enter, txtDownloadFrequency.Enter, chkLeaveOnServer.Enter, chkDownloadAtStartup.Enter, chkDownloadAtFrequency.Enter, cboSendReceiptsSenderUnknown.Enter, cboSendReceiptsSenderKnown.Enter, txtSMTPServer.Enter, txtSMTPUsername.Enter, rbtnNewSMTP.Enter, rbtnExistingSMTP.Enter, cboSMTPProfile.Enter, RichTextBox1.Enter, txtSMTPServerPort.Enter, rbtnSecureSMTPTLS.Enter, rbtnSecureSMTPSSL.Enter, rbtnSecureSMTPNone.Enter, chkSecureSMTPSecureAuthentication.Enter, txtSMTPReplyTo.Enter, txtSMTPDisplayName.Enter, txtSMTPDisplayEmail.Enter, txtSMTPAccountName.Enter, rdobtnSetupOther.Enter, rdobtnSetupGmail.Enter, rdobtnSetupHotmail.Enter
        Dim strRtf As String = GetRtfMessage(CType(sender, Control))
        If strRtf.Length > 0 Then
            RichTextBox1.Rtf = strRtf
        Else
            RichTextBox1.Text = String.Empty
        End If
    End Sub
    Private Sub Control_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOPUsername.Leave, txtPOPServer.Leave, txtPOPServerPort.Leave, txtPOPAccountName.Leave, rbtnSecurePOPTLS.Leave, rbtnSecurePOPSSL.Leave, rbtnSecurePOPNone.Leave, chkSecurePOPSecureAuthentication.Leave, txtDownloadFrequency.Leave, chkLeaveOnServer.Leave, chkDownloadAtStartup.Leave, chkDownloadAtFrequency.Leave, cboSendReceiptsSenderUnknown.Leave, cboSendReceiptsSenderKnown.Leave, txtSMTPServer.Leave, txtSMTPUsername.Leave, rbtnNewSMTP.Leave, rbtnExistingSMTP.Leave, cboSMTPProfile.Leave, RichTextBox1.Leave, txtSMTPServerPort.Leave, rbtnSecureSMTPTLS.Leave, rbtnSecureSMTPSSL.Leave, rbtnSecureSMTPNone.Leave, chkSecureSMTPSecureAuthentication.Leave, txtSMTPReplyTo.Leave, txtSMTPDisplayName.Leave, txtSMTPDisplayEmail.Leave, txtSMTPAccountName.Leave, rdobtnSetupOther.Leave, rdobtnSetupGmail.Leave, rdobtnSetupHotmail.Leave
        RichTextBox1.Text = String.Empty
    End Sub

    Private Sub llblShowPOPSecurity_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblShowPOPSecurity.LinkClicked
        grpPOPSecurity.Visible = Not grpPOPSecurity.Visible
        If grpPOPSecurity.Visible Then
            llblShowPOPSecurity.Text = "Hide Security Settings"
        Else
            llblShowPOPSecurity.Text = "Show Security Settings"
        End If
    End Sub

    Private Sub SetPOPDefaultPort()
        Dim intDefaultPort As Integer
        If rbtnSecurePOPSSL.Checked Then
            intDefaultPort = 995
        ElseIf rbtnSecurePOPTLS.Checked Then
            intDefaultPort = 995
        Else
            intDefaultPort = 110
        End If

        If lblPOPDefaultPort.Text.EndsWith(txtPOPServerPort.Text) Then
            '-- user chose the default, so we change the port as well as the default port
            txtPOPServerPort.Text = intDefaultPort
        Else
            '-- we just change the default port
        End If

        lblPOPDefaultPort.Text = "Default: " & intDefaultPort
    End Sub
    Private Sub rbtnSecurePOPNone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSecurePOPNone.CheckedChanged
        chkSecurePOPSecureAuthentication.Enabled = Not rbtnSecurePOPNone.Checked
    End Sub

    Private Sub chkDownloadAtFrequency_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDownloadAtFrequency.CheckedChanged
        txtDownloadFrequency.Enabled = chkDownloadAtFrequency.Checked
    End Sub
    Private Sub rbtnSecurePOPSSL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSecurePOPSSL.CheckedChanged
        SetPOPDefaultPort()
    End Sub

    Private Sub SetSMTPDefaultPort()
        Dim intDefaultPort As Integer
        If rbtnSecureSMTPSSL.Checked Then
            intDefaultPort = SMTP_PORT_SSL
        Else
            intDefaultPort = SMTP_PORT_NORMAL
        End If

        If lblSMTPDefaultPort.Text.EndsWith(txtSMTPServerPort.Text) Then
            '-- user chose the default, so we change the port as well as the default port
            txtSMTPServerPort.Text = intDefaultPort
        Else
            '-- we just change the default port
        End If

        lblSMTPDefaultPort.Text = "Default: " & intDefaultPort
    End Sub
    Private Sub rbtnSecureSMTPSSL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSecureSMTPSSL.CheckedChanged
        SetSMTPDefaultPort()
    End Sub

    Private Sub llblShowSMTPSecuritySettings_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblShowSMTPSecuritySettings.LinkClicked
        grpSMTPSecuritySettings.Visible = Not grpSMTPSecuritySettings.Visible

        If grpSMTPSecuritySettings.Visible Then
            llblShowSMTPSecuritySettings.Text = "Hide Security Settings"
        Else
            llblShowSMTPSecuritySettings.Text = "Show Security Settings"
        End If
    End Sub

    Private Sub rbtnSecureSMTPNone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSecureSMTPNone.CheckedChanged
        chkSecureSMTPSecureAuthentication.Enabled = Not rbtnSecureSMTPNone.Checked
    End Sub

    Private Sub CheckForSpecialSMTPPort()
        If txtSMTPServer.Text.ToLower.EndsWith("gmail.com") AndAlso txtSMTPServerPort.Text <> SMTP_PORT_SSL_GMAIL AndAlso rbtnSecureSMTPSSL.Checked Then
            If ShowMessageBox("When using SSL with Gmail, the port they recommend is " & SMTP_PORT_SSL_GMAIL & ". Would you like to use port " & SMTP_PORT_SSL_GMAIL & " instead of your selected port?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                txtSMTPServerPort.Text = SMTP_PORT_SSL_GMAIL
            End If
        End If
    End Sub
    Private Sub btnTestSMTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestSMTP.Click
        Dim strErrorText As String = SMTP2OK()
        If strErrorText.Length > 0 Then
            ShowMessageBoxError(strErrorText)
            Exit Sub
        End If
        CheckForSpecialSMTPPort()

        '-- try to send a test message
        '-- Send the message using the specified account
        Try
            Dim strFrom As String = String.Empty
            If IsValidEmailAddress(txtSMTPUsername.Text) Then
                strFrom = txtSMTPUsername.Text
            ElseIf IsValidEmailAddress(txtPOPUsername.Text) Then
                strFrom = txtPOPUsername.Text
            ElseIf m_smtpProfile IsNot Nothing AndAlso IsValidEmailAddress(m_smtpProfile.DisplayEmail) Then
                strFrom = m_smtpProfile.DisplayEmail
            Else
                Do Until IsValidEmailAddress(strFrom)
                    strFrom = GetInput("Please enter your email address for sending the test message.", False)
                    If strFrom = Chr(0) Then
                        '-- use canceled
                        Exit Sub
                    End If
                Loop
            End If
            Dim strTo As String = strFrom
            Dim strSubject As String = "TrulyMail Test"
            Dim strBody As String = "This is a test message from TrulyMail. You can safely delete this message."

            Dim msg As New System.Net.Mail.MailMessage(strFrom, strTo, strSubject, strBody)

            Dim msgsender As System.Net.Mail.SmtpClient
            msgsender = New System.Net.Mail.SmtpClient(txtSMTPServer.Text, Convert.ToInt32(txtSMTPServerPort.Text))
            Dim strSMTPPassword As String = GetInput("Please enter the password to use with this account.", True)
            If strSMTPPassword = Chr(0) Then
                '-- cancel was pressed
                Exit Sub
            End If

            Application.DoEvents()

            msgsender.Credentials = New System.Net.NetworkCredential(txtSMTPUsername.Text, strSMTPPassword)
            msgsender.EnableSsl = rbtnSecureSMTPSSL.Checked
            msgsender.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            msgsender.Timeout = 15000 '-- 15 seconds

            msgsender.Send(msg)
            ShowMessageBox("A test message was sent successfully (to: " & strFrom & "). You can ignore it when you download it in the future.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            ShowMessageBoxError("Failure: " & ex.Message)
        End Try
    End Sub

    Private Sub llblSMTPUsernameFromPOPUsername_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblSMTPUsernameFromPOPUsername.LinkClicked
        If txtPOPUsername.Text.Length > 0 Then
            txtSMTPUsername.Text = txtPOPUsername.Text
        End If
    End Sub

    Private Sub rdobtnSetupGmail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdobtnSetupGmail.CheckedChanged
        lblGmailInfo.Visible = rdobtnSetupGmail.Checked
    End Sub

    Private Sub lblGmailInfo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles lblGmailInfo.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub

    Private Sub txtSMTPUsername_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSMTPUsername.Validating
        If rdobtnSetupGmail.Checked Then
            If Not IsValidEmailAddress(txtSMTPUsername.Text) Then
                ShowMessageBox("The username you entered is not valid for Google accounts. You should use your full email address like JohnDoe@gmail.com.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtSMTPUsername.BackColor = Color.Pink
            Else
                txtSMTPUsername.BackColor = Color.White
            End If
        ElseIf rdobtnSetupHotmail.Checked Then
            If Not IsValidEmailAddress(txtSMTPUsername.Text) Then
                ShowMessageBox("The username you entered is not valid for Hotmail / Windows Live accounts. You should use your full email address like JohnDoe@hotmail.com.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtSMTPUsername.BackColor = Color.Pink
            Else
                txtSMTPUsername.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub txtPOPUsername_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPOPUsername.Validating
        If rdobtnSetupGmail.Checked Then
            If Not IsValidEmailAddress(txtPOPUsername.Text) Then
                ShowMessageBox("The username you entered is not valid for Google accounts. You should use your full email address like JohnDoe@gmail.com.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtPOPUsername.BackColor = Color.Pink
            Else
                txtPOPUsername.BackColor = Color.White
            End If
        ElseIf rdobtnSetupHotmail.Checked Then
            If Not IsValidEmailAddress(txtPOPUsername.Text) Then
                ShowMessageBox("The username you entered is not valid for Hotmail / Windows Live accounts. You should use your full email address like JohnDoe@hotmail.com.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtPOPUsername.BackColor = Color.Pink
            Else
                txtPOPUsername.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub txtPOPUsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOPUsername.TextChanged
        If Not m_boolPOPAccountNameManuallyChanged Then
            m_boolPOPUsernameChanging = True
            txtPOPAccountName.Text = txtPOPUsername.Text
            m_boolPOPUsernameChanging = False
        End If
    End Sub

    Private Sub txtPOPAccountName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOPAccountName.TextChanged
        If Not m_boolPOPUsernameChanging Then
            m_boolPOPAccountNameManuallyChanged = True
        End If
    End Sub

    Private Sub txtSMTPDisplayEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSMTPDisplayEmail.TextChanged

    End Sub

    Private Sub txtSMTPUsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSMTPUsername.TextChanged
        If Not m_boolSMTPAccountNameManuallyChanged Then
            m_boolSMTPUsernameChanging = True
            txtSMTPAccountName.Text = txtSMTPUsername.Text
            m_boolSMTPUsernameChanging = False
        End If
    End Sub

    Private Sub txtSMTPAccountName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSMTPAccountName.TextChanged
        If Not m_boolSMTPUsernameChanging Then
            m_boolSMTPAccountNameManuallyChanged = True
        End If
    End Sub

    Private Sub rtbSetupOther_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rtbSetupOther.MouseClick
        rdobtnSetupOther.Checked = True
        rdobtnSetupOther.Focus()
    End Sub

    Private Sub rtbSetupHotmail_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rtbSetupHotmail.MouseClick
        rdobtnSetupHotmail.Checked = True
        rdobtnSetupHotmail.Focus()
    End Sub

    Private Sub rtbSetupGmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbSetupGmail.Click
        rdobtnSetupGmail.Checked = True
        rdobtnSetupGmail.Focus()
    End Sub
    Private Sub SetInBoxPathLabel(ByVal fullPath As String)
        Const CHANGE As String = " change"
        Dim strNewPath As String = UnQualifyPath(fullPath.Substring(MessageStoreRootPath.Length)) & CHANGE
        llblChangeInbox.Text = strNewPath
        Dim intReduction As Integer
        Dim strBasePath As String = UnQualifyPath(fullPath.Substring(MessageStoreRootPath.Length))
        Do Until llblChangeInbox.Right <= txtPOPUsername.Width
            intReduction += 1
            strNewPath = strBasePath.Substring(0, strBasePath.Length - intReduction) & "..." & CHANGE
            llblChangeInbox.Text = strNewPath
        Loop
        llblChangeInbox.LinkArea = New LinkArea(strNewPath.Length - CHANGE.Length + 1, CHANGE.Length)
        ToolTip1.SetToolTip(llblChangeInbox, fullPath)
    End Sub

    Private Sub llblChangeInbox_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblChangeInbox.LinkClicked
        Try
            Dim fbd As New FolderBrowserDialogTM()
            fbd.ShowAllFolders = False
            fbd.SelectedPath = m_strInBoxFolder
            fbd.ShowNewFolderButton = True
            fbd.Description = "Select folder for new email messages"
            If fbd.ShowDialog(Me) = DialogResult.OK Then
                SetInBoxPathLabel(fbd.SelectedPath)
                m_strInBoxFolder = fbd.SelectedPath
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error changing the folder for this email account. " & CONTACT_TRULYMAIL_MESSAGE)
        End Try
    End Sub

    Private Sub rbtnSecurePOPTLS_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSecurePOPTLS.CheckedChanged
        SetPOPDefaultPort()
    End Sub
End Class