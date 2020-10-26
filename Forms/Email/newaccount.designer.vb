<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewAccount
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewAccount))
        Me.lblStep = New System.Windows.Forms.Label()
        Me.grpPOPDetails1 = New System.Windows.Forms.GroupBox()
        Me.llblChangeInbox = New System.Windows.Forms.LinkLabel()
        Me.grpPOPSecurity = New System.Windows.Forms.GroupBox()
        Me.chkSecurePOPSecureAuthentication = New System.Windows.Forms.CheckBox()
        Me.rbtnSecurePOPSSL = New System.Windows.Forms.RadioButton()
        Me.rbtnSecurePOPTLS = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rbtnSecurePOPNone = New System.Windows.Forms.RadioButton()
        Me.llblShowPOPSecurity = New System.Windows.Forms.LinkLabel()
        Me.lblPOPDefaultPort = New System.Windows.Forms.Label()
        Me.txtPOPServerPort = New System.Windows.Forms.TextBox()
        Me.txtPOPAccountName = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPOPUsername = New System.Windows.Forms.TextBox()
        Me.txtPOPServer = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.grpSMTPDetails1 = New System.Windows.Forms.GroupBox()
        Me.cboSMTPProfile = New System.Windows.Forms.ComboBox()
        Me.rbtnNewSMTP = New System.Windows.Forms.RadioButton()
        Me.rbtnExistingSMTP = New System.Windows.Forms.RadioButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.llblShowSMTPSecuritySettings = New System.Windows.Forms.LinkLabel()
        Me.grpSMTPSecuritySettings = New System.Windows.Forms.GroupBox()
        Me.chkSecureSMTPSecureAuthentication = New System.Windows.Forms.CheckBox()
        Me.rbtnSecureSMTPSSL = New System.Windows.Forms.RadioButton()
        Me.rbtnSecureSMTPTLS = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rbtnSecureSMTPNone = New System.Windows.Forms.RadioButton()
        Me.btnTestSMTP = New System.Windows.Forms.Button()
        Me.lblSMTPDefaultPort = New System.Windows.Forms.Label()
        Me.txtSMTPServerPort = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtSMTPUsername = New System.Windows.Forms.TextBox()
        Me.txtSMTPServer = New System.Windows.Forms.TextBox()
        Me.grpConfirm = New System.Windows.Forms.GroupBox()
        Me.lblFoldersLabel = New System.Windows.Forms.Label()
        Me.lblInBox = New System.Windows.Forms.Label()
        Me.lblReplyTo = New System.Windows.Forms.Label()
        Me.lblReceiptNotInBook = New System.Windows.Forms.Label()
        Me.lblReceiptInBook = New System.Windows.Forms.Label()
        Me.lblDownloadAtInterval = New System.Windows.Forms.Label()
        Me.lblDownloadAtStartup = New System.Windows.Forms.Label()
        Me.lblSMTPSecureAuthentication = New System.Windows.Forms.Label()
        Me.lblPOPSecureAuthentication = New System.Windows.Forms.Label()
        Me.lblSMTPSecureConnection = New System.Windows.Forms.Label()
        Me.lblPOPSecureConnection = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lblPOPTitle = New System.Windows.Forms.Label()
        Me.lblSMTPAccountName = New System.Windows.Forms.Label()
        Me.lblPOPAccountName = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblSMTPUsername = New System.Windows.Forms.Label()
        Me.lblPOPUsername = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblSMTPServer = New System.Windows.Forms.Label()
        Me.lblPOPServer = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblDisplayName = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.grpPOPDetails2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboSendReceiptsSenderUnknown = New System.Windows.Forms.ComboBox()
        Me.cboSendReceiptsSenderKnown = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkDownloadAtStartup = New System.Windows.Forms.CheckBox()
        Me.chkLeaveOnServer = New System.Windows.Forms.CheckBox()
        Me.txtDownloadFrequency = New System.Windows.Forms.TextBox()
        Me.chkDownloadAtFrequency = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.grpSMTPDetails2 = New System.Windows.Forms.GroupBox()
        Me.llblSMTPUsernameFromPOPUsername = New System.Windows.Forms.LinkLabel()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.grpSMTPDetails3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtSMTPDisplayName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSMTPDisplayEmail = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSMTPReplyTo = New System.Windows.Forms.TextBox()
        Me.txtSMTPAccountName = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpWelcome = New System.Windows.Forms.GroupBox()
        Me.rtbSetupGmail = New System.Windows.Forms.RichTextBox()
        Me.rtbSetupOther = New System.Windows.Forms.RichTextBox()
        Me.rtbSetupHotmail = New System.Windows.Forms.RichTextBox()
        Me.rdobtnSetupHotmail = New System.Windows.Forms.RadioButton()
        Me.lblGmailInfo = New System.Windows.Forms.RichTextBox()
        Me.rdobtnSetupOther = New System.Windows.Forms.RadioButton()
        Me.rdobtnSetupGmail = New System.Windows.Forms.RadioButton()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnNext = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnBack = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.grpPOPDetails1.SuspendLayout()
        Me.grpPOPSecurity.SuspendLayout()
        Me.grpSMTPDetails1.SuspendLayout()
        Me.grpSMTPSecuritySettings.SuspendLayout()
        Me.grpConfirm.SuspendLayout()
        Me.grpPOPDetails2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpSMTPDetails2.SuspendLayout()
        Me.grpSMTPDetails3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grpWelcome.SuspendLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStep
        '
        Me.lblStep.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStep.BackColor = System.Drawing.Color.Transparent
        Me.lblStep.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep.Location = New System.Drawing.Point(21, 9)
        Me.lblStep.Name = "lblStep"
        Me.lblStep.Size = New System.Drawing.Size(847, 23)
        Me.lblStep.TabIndex = 0
        Me.lblStep.Text = "Connecting TrulyMail to an Existing Email Account"
        '
        'grpPOPDetails1
        '
        Me.grpPOPDetails1.AutoSize = True
        Me.grpPOPDetails1.BackColor = System.Drawing.Color.Transparent
        Me.grpPOPDetails1.Controls.Add(Me.llblChangeInbox)
        Me.grpPOPDetails1.Controls.Add(Me.grpPOPSecurity)
        Me.grpPOPDetails1.Controls.Add(Me.llblShowPOPSecurity)
        Me.grpPOPDetails1.Controls.Add(Me.lblPOPDefaultPort)
        Me.grpPOPDetails1.Controls.Add(Me.txtPOPServerPort)
        Me.grpPOPDetails1.Controls.Add(Me.txtPOPAccountName)
        Me.grpPOPDetails1.Controls.Add(Me.Label19)
        Me.grpPOPDetails1.Controls.Add(Me.Label1)
        Me.grpPOPDetails1.Controls.Add(Me.Label11)
        Me.grpPOPDetails1.Controls.Add(Me.txtPOPUsername)
        Me.grpPOPDetails1.Controls.Add(Me.txtPOPServer)
        Me.grpPOPDetails1.Controls.Add(Me.Label12)
        Me.grpPOPDetails1.Controls.Add(Me.Label28)
        Me.grpPOPDetails1.Controls.Add(Me.Label9)
        Me.grpPOPDetails1.Controls.Add(Me.Label14)
        Me.grpPOPDetails1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpPOPDetails1.Location = New System.Drawing.Point(0, 0)
        Me.grpPOPDetails1.Name = "grpPOPDetails1"
        Me.grpPOPDetails1.Size = New System.Drawing.Size(690, 485)
        Me.grpPOPDetails1.TabIndex = 10
        Me.grpPOPDetails1.TabStop = False
        Me.grpPOPDetails1.Tag = "Receiving (POP3) Server Details"
        Me.grpPOPDetails1.Visible = False
        '
        'llblChangeInbox
        '
        Me.llblChangeInbox.AutoSize = True
        Me.llblChangeInbox.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblChangeInbox.LinkArea = New System.Windows.Forms.LinkArea(6, 12)
        Me.llblChangeInbox.Location = New System.Drawing.Point(153, 78)
        Me.llblChangeInbox.Name = "llblChangeInbox"
        Me.llblChangeInbox.Size = New System.Drawing.Size(87, 20)
        Me.llblChangeInbox.TabIndex = 47
        Me.llblChangeInbox.TabStop = True
        Me.llblChangeInbox.Text = "InBox change"
        Me.llblChangeInbox.UseCompatibleTextRendering = True
        '
        'grpPOPSecurity
        '
        Me.grpPOPSecurity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPOPSecurity.Controls.Add(Me.chkSecurePOPSecureAuthentication)
        Me.grpPOPSecurity.Controls.Add(Me.rbtnSecurePOPSSL)
        Me.grpPOPSecurity.Controls.Add(Me.rbtnSecurePOPTLS)
        Me.grpPOPSecurity.Controls.Add(Me.Label8)
        Me.grpPOPSecurity.Controls.Add(Me.rbtnSecurePOPNone)
        Me.grpPOPSecurity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPOPSecurity.Location = New System.Drawing.Point(8, 219)
        Me.grpPOPSecurity.Name = "grpPOPSecurity"
        Me.grpPOPSecurity.Size = New System.Drawing.Size(676, 73)
        Me.grpPOPSecurity.TabIndex = 34
        Me.grpPOPSecurity.TabStop = False
        Me.grpPOPSecurity.Text = "Security Settings"
        Me.grpPOPSecurity.Visible = False
        '
        'chkSecurePOPSecureAuthentication
        '
        Me.chkSecurePOPSecureAuthentication.AutoSize = True
        Me.chkSecurePOPSecureAuthentication.Enabled = False
        Me.chkSecurePOPSecureAuthentication.Location = New System.Drawing.Point(16, 46)
        Me.chkSecurePOPSecureAuthentication.Name = "chkSecurePOPSecureAuthentication"
        Me.chkSecurePOPSecureAuthentication.Size = New System.Drawing.Size(178, 20)
        Me.chkSecurePOPSecureAuthentication.TabIndex = 9
        Me.chkSecurePOPSecureAuthentication.Text = "&Use secure authentication"
        Me.chkSecurePOPSecureAuthentication.UseVisualStyleBackColor = True
        '
        'rbtnSecurePOPSSL
        '
        Me.rbtnSecurePOPSSL.AutoSize = True
        Me.rbtnSecurePOPSSL.Location = New System.Drawing.Point(267, 21)
        Me.rbtnSecurePOPSSL.Name = "rbtnSecurePOPSSL"
        Me.rbtnSecurePOPSSL.Size = New System.Drawing.Size(51, 20)
        Me.rbtnSecurePOPSSL.TabIndex = 8
        Me.rbtnSecurePOPSSL.Text = "&SSL"
        Me.rbtnSecurePOPSSL.UseVisualStyleBackColor = True
        '
        'rbtnSecurePOPTLS
        '
        Me.rbtnSecurePOPTLS.AutoSize = True
        Me.rbtnSecurePOPTLS.Location = New System.Drawing.Point(346, 21)
        Me.rbtnSecurePOPTLS.Name = "rbtnSecurePOPTLS"
        Me.rbtnSecurePOPTLS.Size = New System.Drawing.Size(143, 20)
        Me.rbtnSecurePOPTLS.TabIndex = 7
        Me.rbtnSecurePOPTLS.Text = "&TLS (recommended)"
        Me.rbtnSecurePOPTLS.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(145, 16)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Use secure connection:"
        '
        'rbtnSecurePOPNone
        '
        Me.rbtnSecurePOPNone.AutoSize = True
        Me.rbtnSecurePOPNone.Checked = True
        Me.rbtnSecurePOPNone.Location = New System.Drawing.Point(176, 21)
        Me.rbtnSecurePOPNone.Name = "rbtnSecurePOPNone"
        Me.rbtnSecurePOPNone.Size = New System.Drawing.Size(56, 20)
        Me.rbtnSecurePOPNone.TabIndex = 6
        Me.rbtnSecurePOPNone.TabStop = True
        Me.rbtnSecurePOPNone.Text = "&None"
        Me.rbtnSecurePOPNone.UseVisualStyleBackColor = True
        '
        'llblShowPOPSecurity
        '
        Me.llblShowPOPSecurity.AutoSize = True
        Me.llblShowPOPSecurity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblShowPOPSecurity.Location = New System.Drawing.Point(152, 200)
        Me.llblShowPOPSecurity.Name = "llblShowPOPSecurity"
        Me.llblShowPOPSecurity.Size = New System.Drawing.Size(144, 16)
        Me.llblShowPOPSecurity.TabIndex = 5
        Me.llblShowPOPSecurity.TabStop = True
        Me.llblShowPOPSecurity.Text = "Show Security Settings"
        '
        'lblPOPDefaultPort
        '
        Me.lblPOPDefaultPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPOPDefaultPort.AutoSize = True
        Me.lblPOPDefaultPort.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPOPDefaultPort.Location = New System.Drawing.Point(596, 55)
        Me.lblPOPDefaultPort.Name = "lblPOPDefaultPort"
        Me.lblPOPDefaultPort.Size = New System.Drawing.Size(76, 16)
        Me.lblPOPDefaultPort.TabIndex = 32
        Me.lblPOPDefaultPort.Text = "Default: 110"
        '
        'txtPOPServerPort
        '
        Me.txtPOPServerPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPOPServerPort.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOPServerPort.Location = New System.Drawing.Point(550, 52)
        Me.txtPOPServerPort.Name = "txtPOPServerPort"
        Me.txtPOPServerPort.Size = New System.Drawing.Size(42, 22)
        Me.txtPOPServerPort.TabIndex = 1
        Me.txtPOPServerPort.Tag = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\" & _
    "f1\fnil\fcharset0 Arial;}{\f2\fnil\fcharset2 Symbol;}}"
        Me.txtPOPServerPort.Text = "110"
        Me.txtPOPServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPOPAccountName
        '
        Me.txtPOPAccountName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPOPAccountName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOPAccountName.Location = New System.Drawing.Point(153, 126)
        Me.txtPOPAccountName.Name = "txtPOPAccountName"
        Me.txtPOPAccountName.Size = New System.Drawing.Size(520, 22)
        Me.txtPOPAccountName.TabIndex = 4
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(14, 132)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(105, 16)
        Me.Label19.TabIndex = 27
        Me.Label19.Text = "Account name: *"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Account InBox:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 16)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Receiving server:"
        '
        'txtPOPUsername
        '
        Me.txtPOPUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPOPUsername.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOPUsername.Location = New System.Drawing.Point(153, 101)
        Me.txtPOPUsername.Name = "txtPOPUsername"
        Me.txtPOPUsername.Size = New System.Drawing.Size(520, 22)
        Me.txtPOPUsername.TabIndex = 3
        Me.txtPOPUsername.Tag = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\" & _
    "f1\fnil\fcharset0 Arial;}{\f2\fnil\fcharset2 Symbol;}}"
        '
        'txtPOPServer
        '
        Me.txtPOPServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPOPServer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOPServer.Location = New System.Drawing.Point(153, 52)
        Me.txtPOPServer.Name = "txtPOPServer"
        Me.txtPOPServer.Size = New System.Drawing.Size(355, 22)
        Me.txtPOPServer.TabIndex = 0
        Me.txtPOPServer.Tag = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\" & _
    "f1\fnil\fcharset0 Arial;}{\f2\fnil\fcharset2 Symbol;}}"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 104)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 16)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Username:"
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(514, 55)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(36, 16)
        Me.Label28.TabIndex = 31
        Me.Label28.Text = "Port:"
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(659, 25)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Please enter the details about your receiving (POP3) email server."
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(14, 160)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(662, 37)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "* Note: Your account name CAN be the same as your username or you can change it t" & _
    "o anything you want - the choice is yours."
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Stuffed_Folder.png")
        Me.ImageList1.Images.SetKeyName(1, "Folder_Closed.png")
        Me.ImageList1.Images.SetKeyName(2, "Folder_Open.png")
        Me.ImageList1.Images.SetKeyName(3, "foldergreen.png")
        Me.ImageList1.Images.SetKeyName(4, "Postage stamp.bmp")
        Me.ImageList1.Images.SetKeyName(5, "Empty trash can.bmp")
        Me.ImageList1.Images.SetKeyName(6, "Full trash can.bmp")
        Me.ImageList1.Images.SetKeyName(7, "Message.bmp")
        Me.ImageList1.Images.SetKeyName(8, "Redirect.bmp")
        Me.ImageList1.Images.SetKeyName(9, "Edit_message.bmp")
        Me.ImageList1.Images.SetKeyName(10, "infinity_24.png")
        '
        'grpSMTPDetails1
        '
        Me.grpSMTPDetails1.AutoSize = True
        Me.grpSMTPDetails1.BackColor = System.Drawing.Color.Transparent
        Me.grpSMTPDetails1.Controls.Add(Me.cboSMTPProfile)
        Me.grpSMTPDetails1.Controls.Add(Me.rbtnNewSMTP)
        Me.grpSMTPDetails1.Controls.Add(Me.rbtnExistingSMTP)
        Me.grpSMTPDetails1.Controls.Add(Me.Label18)
        Me.grpSMTPDetails1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpSMTPDetails1.Location = New System.Drawing.Point(0, 0)
        Me.grpSMTPDetails1.Name = "grpSMTPDetails1"
        Me.grpSMTPDetails1.Size = New System.Drawing.Size(690, 485)
        Me.grpSMTPDetails1.TabIndex = 13
        Me.grpSMTPDetails1.TabStop = False
        Me.grpSMTPDetails1.Tag = "Sending (SMTP) Profile Selection"
        Me.grpSMTPDetails1.Visible = False
        '
        'cboSMTPProfile
        '
        Me.cboSMTPProfile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSMTPProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSMTPProfile.FormattingEnabled = True
        Me.cboSMTPProfile.Location = New System.Drawing.Point(195, 68)
        Me.cboSMTPProfile.Name = "cboSMTPProfile"
        Me.cboSMTPProfile.Size = New System.Drawing.Size(479, 21)
        Me.cboSMTPProfile.TabIndex = 1
        '
        'rbtnNewSMTP
        '
        Me.rbtnNewSMTP.AutoSize = True
        Me.rbtnNewSMTP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnNewSMTP.Location = New System.Drawing.Point(17, 116)
        Me.rbtnNewSMTP.Name = "rbtnNewSMTP"
        Me.rbtnNewSMTP.Size = New System.Drawing.Size(150, 20)
        Me.rbtnNewSMTP.TabIndex = 2
        Me.rbtnNewSMTP.TabStop = True
        Me.rbtnNewSMTP.Text = "&New sending settings"
        Me.rbtnNewSMTP.UseVisualStyleBackColor = True
        '
        'rbtnExistingSMTP
        '
        Me.rbtnExistingSMTP.AutoSize = True
        Me.rbtnExistingSMTP.Checked = True
        Me.rbtnExistingSMTP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnExistingSMTP.Location = New System.Drawing.Point(17, 67)
        Me.rbtnExistingSMTP.Name = "rbtnExistingSMTP"
        Me.rbtnExistingSMTP.Size = New System.Drawing.Size(176, 20)
        Me.rbtnExistingSMTP.TabIndex = 0
        Me.rbtnExistingSMTP.TabStop = True
        Me.rbtnExistingSMTP.Text = "&Existing sending settings:"
        Me.rbtnExistingSMTP.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(14, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(659, 42)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Please choose or enter your SMTP settings to use with this POP3 account."
        '
        'llblShowSMTPSecuritySettings
        '
        Me.llblShowSMTPSecuritySettings.AutoSize = True
        Me.llblShowSMTPSecuritySettings.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblShowSMTPSecuritySettings.Location = New System.Drawing.Point(146, 121)
        Me.llblShowSMTPSecuritySettings.Name = "llblShowSMTPSecuritySettings"
        Me.llblShowSMTPSecuritySettings.Size = New System.Drawing.Size(144, 16)
        Me.llblShowSMTPSecuritySettings.TabIndex = 3
        Me.llblShowSMTPSecuritySettings.TabStop = True
        Me.llblShowSMTPSecuritySettings.Text = "Show Security Settings"
        '
        'grpSMTPSecuritySettings
        '
        Me.grpSMTPSecuritySettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSMTPSecuritySettings.Controls.Add(Me.chkSecureSMTPSecureAuthentication)
        Me.grpSMTPSecuritySettings.Controls.Add(Me.rbtnSecureSMTPSSL)
        Me.grpSMTPSecuritySettings.Controls.Add(Me.rbtnSecureSMTPTLS)
        Me.grpSMTPSecuritySettings.Controls.Add(Me.Label5)
        Me.grpSMTPSecuritySettings.Controls.Add(Me.rbtnSecureSMTPNone)
        Me.grpSMTPSecuritySettings.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSMTPSecuritySettings.Location = New System.Drawing.Point(14, 142)
        Me.grpSMTPSecuritySettings.Name = "grpSMTPSecuritySettings"
        Me.grpSMTPSecuritySettings.Size = New System.Drawing.Size(643, 75)
        Me.grpSMTPSecuritySettings.TabIndex = 37
        Me.grpSMTPSecuritySettings.TabStop = False
        Me.grpSMTPSecuritySettings.Text = "Security Settings"
        Me.grpSMTPSecuritySettings.Visible = False
        '
        'chkSecureSMTPSecureAuthentication
        '
        Me.chkSecureSMTPSecureAuthentication.AutoSize = True
        Me.chkSecureSMTPSecureAuthentication.Enabled = False
        Me.chkSecureSMTPSecureAuthentication.Location = New System.Drawing.Point(16, 52)
        Me.chkSecureSMTPSecureAuthentication.Name = "chkSecureSMTPSecureAuthentication"
        Me.chkSecureSMTPSecureAuthentication.Size = New System.Drawing.Size(178, 20)
        Me.chkSecureSMTPSecureAuthentication.TabIndex = 7
        Me.chkSecureSMTPSecureAuthentication.Text = "&Use secure authentication"
        Me.chkSecureSMTPSecureAuthentication.UseVisualStyleBackColor = True
        Me.chkSecureSMTPSecureAuthentication.Visible = False
        '
        'rbtnSecureSMTPSSL
        '
        Me.rbtnSecureSMTPSSL.AutoSize = True
        Me.rbtnSecureSMTPSSL.Location = New System.Drawing.Point(257, 24)
        Me.rbtnSecureSMTPSSL.Name = "rbtnSecureSMTPSSL"
        Me.rbtnSecureSMTPSSL.Size = New System.Drawing.Size(51, 20)
        Me.rbtnSecureSMTPSSL.TabIndex = 6
        Me.rbtnSecureSMTPSSL.Text = "&SSL"
        Me.rbtnSecureSMTPSSL.UseVisualStyleBackColor = True
        '
        'rbtnSecureSMTPTLS
        '
        Me.rbtnSecureSMTPTLS.AutoSize = True
        Me.rbtnSecureSMTPTLS.Location = New System.Drawing.Point(340, 24)
        Me.rbtnSecureSMTPTLS.Name = "rbtnSecureSMTPTLS"
        Me.rbtnSecureSMTPTLS.Size = New System.Drawing.Size(49, 20)
        Me.rbtnSecureSMTPTLS.TabIndex = 5
        Me.rbtnSecureSMTPTLS.Text = "&TLS"
        Me.rbtnSecureSMTPTLS.UseVisualStyleBackColor = True
        Me.rbtnSecureSMTPTLS.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 16)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Use secure connection:"
        '
        'rbtnSecureSMTPNone
        '
        Me.rbtnSecureSMTPNone.AutoSize = True
        Me.rbtnSecureSMTPNone.Checked = True
        Me.rbtnSecureSMTPNone.Location = New System.Drawing.Point(176, 24)
        Me.rbtnSecureSMTPNone.Name = "rbtnSecureSMTPNone"
        Me.rbtnSecureSMTPNone.Size = New System.Drawing.Size(56, 20)
        Me.rbtnSecureSMTPNone.TabIndex = 4
        Me.rbtnSecureSMTPNone.TabStop = True
        Me.rbtnSecureSMTPNone.Text = "&None"
        Me.rbtnSecureSMTPNone.UseVisualStyleBackColor = True
        '
        'btnTestSMTP
        '
        Me.btnTestSMTP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTestSMTP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTestSMTP.Location = New System.Drawing.Point(437, 226)
        Me.btnTestSMTP.Name = "btnTestSMTP"
        Me.btnTestSMTP.Size = New System.Drawing.Size(217, 26)
        Me.btnTestSMTP.TabIndex = 42
        Me.btnTestSMTP.Text = "&Test Settings"
        Me.btnTestSMTP.UseVisualStyleBackColor = True
        '
        'lblSMTPDefaultPort
        '
        Me.lblSMTPDefaultPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSMTPDefaultPort.AutoSize = True
        Me.lblSMTPDefaultPort.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSMTPDefaultPort.Location = New System.Drawing.Point(589, 72)
        Me.lblSMTPDefaultPort.Name = "lblSMTPDefaultPort"
        Me.lblSMTPDefaultPort.Size = New System.Drawing.Size(70, 16)
        Me.lblSMTPDefaultPort.TabIndex = 35
        Me.lblSMTPDefaultPort.Text = "Default: 25"
        '
        'txtSMTPServerPort
        '
        Me.txtSMTPServerPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSMTPServerPort.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSMTPServerPort.Location = New System.Drawing.Point(543, 69)
        Me.txtSMTPServerPort.Name = "txtSMTPServerPort"
        Me.txtSMTPServerPort.Size = New System.Drawing.Size(42, 22)
        Me.txtSMTPServerPort.TabIndex = 1
        Me.txtSMTPServerPort.Tag = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\" & _
    "f1\fnil\fcharset0 Arial;}{\f2\fnil\fcharset2 Symbol;}}"
        Me.txtSMTPServerPort.Text = "25"
        Me.txtSMTPServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(507, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 16)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Port:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(21, 72)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(97, 16)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Sending server:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(21, 98)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 16)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Sending username:"
        '
        'txtSMTPUsername
        '
        Me.txtSMTPUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSMTPUsername.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSMTPUsername.Location = New System.Drawing.Point(144, 95)
        Me.txtSMTPUsername.Name = "txtSMTPUsername"
        Me.txtSMTPUsername.Size = New System.Drawing.Size(393, 22)
        Me.txtSMTPUsername.TabIndex = 2
        '
        'txtSMTPServer
        '
        Me.txtSMTPServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSMTPServer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSMTPServer.Location = New System.Drawing.Point(144, 69)
        Me.txtSMTPServer.Name = "txtSMTPServer"
        Me.txtSMTPServer.Size = New System.Drawing.Size(355, 22)
        Me.txtSMTPServer.TabIndex = 0
        '
        'grpConfirm
        '
        Me.grpConfirm.AutoSize = True
        Me.grpConfirm.BackColor = System.Drawing.Color.Transparent
        Me.grpConfirm.Controls.Add(Me.lblFoldersLabel)
        Me.grpConfirm.Controls.Add(Me.lblInBox)
        Me.grpConfirm.Controls.Add(Me.lblReplyTo)
        Me.grpConfirm.Controls.Add(Me.lblReceiptNotInBook)
        Me.grpConfirm.Controls.Add(Me.lblReceiptInBook)
        Me.grpConfirm.Controls.Add(Me.lblDownloadAtInterval)
        Me.grpConfirm.Controls.Add(Me.lblDownloadAtStartup)
        Me.grpConfirm.Controls.Add(Me.lblSMTPSecureAuthentication)
        Me.grpConfirm.Controls.Add(Me.lblPOPSecureAuthentication)
        Me.grpConfirm.Controls.Add(Me.lblSMTPSecureConnection)
        Me.grpConfirm.Controls.Add(Me.lblPOPSecureConnection)
        Me.grpConfirm.Controls.Add(Me.Label40)
        Me.grpConfirm.Controls.Add(Me.Label33)
        Me.grpConfirm.Controls.Add(Me.lblPOPTitle)
        Me.grpConfirm.Controls.Add(Me.lblSMTPAccountName)
        Me.grpConfirm.Controls.Add(Me.lblPOPAccountName)
        Me.grpConfirm.Controls.Add(Me.Label27)
        Me.grpConfirm.Controls.Add(Me.Label26)
        Me.grpConfirm.Controls.Add(Me.Label25)
        Me.grpConfirm.Controls.Add(Me.lblSMTPUsername)
        Me.grpConfirm.Controls.Add(Me.lblPOPUsername)
        Me.grpConfirm.Controls.Add(Me.Label23)
        Me.grpConfirm.Controls.Add(Me.lblSMTPServer)
        Me.grpConfirm.Controls.Add(Me.lblPOPServer)
        Me.grpConfirm.Controls.Add(Me.Label22)
        Me.grpConfirm.Controls.Add(Me.lblEmail)
        Me.grpConfirm.Controls.Add(Me.lblDisplayName)
        Me.grpConfirm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpConfirm.Location = New System.Drawing.Point(0, 0)
        Me.grpConfirm.Name = "grpConfirm"
        Me.grpConfirm.Size = New System.Drawing.Size(690, 485)
        Me.grpConfirm.TabIndex = 35
        Me.grpConfirm.TabStop = False
        Me.grpConfirm.Tag = "Confirm Account Settings"
        Me.grpConfirm.Visible = False
        '
        'lblFoldersLabel
        '
        Me.lblFoldersLabel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFoldersLabel.Location = New System.Drawing.Point(17, 195)
        Me.lblFoldersLabel.Name = "lblFoldersLabel"
        Me.lblFoldersLabel.Size = New System.Drawing.Size(142, 20)
        Me.lblFoldersLabel.TabIndex = 26
        Me.lblFoldersLabel.Text = "Folders:"
        '
        'lblInBox
        '
        Me.lblInBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInBox.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInBox.Location = New System.Drawing.Point(162, 195)
        Me.lblInBox.Name = "lblInBox"
        Me.lblInBox.Size = New System.Drawing.Size(264, 20)
        Me.lblInBox.TabIndex = 25
        Me.lblInBox.Text = "Options:"
        '
        'lblReplyTo
        '
        Me.lblReplyTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReplyTo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReplyTo.Location = New System.Drawing.Point(436, 155)
        Me.lblReplyTo.Name = "lblReplyTo"
        Me.lblReplyTo.Size = New System.Drawing.Size(248, 20)
        Me.lblReplyTo.TabIndex = 22
        Me.lblReplyTo.Text = "Email:"
        '
        'lblReceiptNotInBook
        '
        Me.lblReceiptNotInBook.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReceiptNotInBook.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptNotInBook.Location = New System.Drawing.Point(162, 175)
        Me.lblReceiptNotInBook.Name = "lblReceiptNotInBook"
        Me.lblReceiptNotInBook.Size = New System.Drawing.Size(264, 20)
        Me.lblReceiptNotInBook.TabIndex = 21
        Me.lblReceiptNotInBook.Text = "Options:"
        '
        'lblReceiptInBook
        '
        Me.lblReceiptInBook.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReceiptInBook.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptInBook.Location = New System.Drawing.Point(162, 155)
        Me.lblReceiptInBook.Name = "lblReceiptInBook"
        Me.lblReceiptInBook.Size = New System.Drawing.Size(264, 20)
        Me.lblReceiptInBook.TabIndex = 20
        Me.lblReceiptInBook.Text = "Options:"
        '
        'lblDownloadAtInterval
        '
        Me.lblDownloadAtInterval.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDownloadAtInterval.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDownloadAtInterval.Location = New System.Drawing.Point(162, 135)
        Me.lblDownloadAtInterval.Name = "lblDownloadAtInterval"
        Me.lblDownloadAtInterval.Size = New System.Drawing.Size(264, 20)
        Me.lblDownloadAtInterval.TabIndex = 18
        Me.lblDownloadAtInterval.Text = "Options:"
        '
        'lblDownloadAtStartup
        '
        Me.lblDownloadAtStartup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDownloadAtStartup.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDownloadAtStartup.Location = New System.Drawing.Point(162, 115)
        Me.lblDownloadAtStartup.Name = "lblDownloadAtStartup"
        Me.lblDownloadAtStartup.Size = New System.Drawing.Size(264, 20)
        Me.lblDownloadAtStartup.TabIndex = 17
        Me.lblDownloadAtStartup.Text = "Options:"
        '
        'lblSMTPSecureAuthentication
        '
        Me.lblSMTPSecureAuthentication.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSMTPSecureAuthentication.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSMTPSecureAuthentication.Location = New System.Drawing.Point(436, 94)
        Me.lblSMTPSecureAuthentication.Name = "lblSMTPSecureAuthentication"
        Me.lblSMTPSecureAuthentication.Size = New System.Drawing.Size(248, 20)
        Me.lblSMTPSecureAuthentication.TabIndex = 16
        Me.lblSMTPSecureAuthentication.Text = "Secure Authentication:"
        Me.lblSMTPSecureAuthentication.Visible = False
        '
        'lblPOPSecureAuthentication
        '
        Me.lblPOPSecureAuthentication.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPOPSecureAuthentication.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPOPSecureAuthentication.Location = New System.Drawing.Point(162, 94)
        Me.lblPOPSecureAuthentication.Name = "lblPOPSecureAuthentication"
        Me.lblPOPSecureAuthentication.Size = New System.Drawing.Size(264, 20)
        Me.lblPOPSecureAuthentication.TabIndex = 15
        Me.lblPOPSecureAuthentication.Text = "Secure Authentication:"
        '
        'lblSMTPSecureConnection
        '
        Me.lblSMTPSecureConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSMTPSecureConnection.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSMTPSecureConnection.Location = New System.Drawing.Point(436, 76)
        Me.lblSMTPSecureConnection.Name = "lblSMTPSecureConnection"
        Me.lblSMTPSecureConnection.Size = New System.Drawing.Size(248, 20)
        Me.lblSMTPSecureConnection.TabIndex = 14
        Me.lblSMTPSecureConnection.Text = "Secure connection:"
        '
        'lblPOPSecureConnection
        '
        Me.lblPOPSecureConnection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPOPSecureConnection.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPOPSecureConnection.Location = New System.Drawing.Point(162, 76)
        Me.lblPOPSecureConnection.Name = "lblPOPSecureConnection"
        Me.lblPOPSecureConnection.Size = New System.Drawing.Size(264, 20)
        Me.lblPOPSecureConnection.TabIndex = 13
        Me.lblPOPSecureConnection.Text = "Secure connection:"
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(17, 76)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(142, 20)
        Me.Label40.TabIndex = 12
        Me.Label40.Text = "Secure connection:"
        '
        'Label33
        '
        Me.Label33.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(436, 17)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(248, 20)
        Me.Label33.TabIndex = 11
        Me.Label33.Text = "Sending (SMTP)"
        '
        'lblPOPTitle
        '
        Me.lblPOPTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPOPTitle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPOPTitle.Location = New System.Drawing.Point(162, 17)
        Me.lblPOPTitle.Name = "lblPOPTitle"
        Me.lblPOPTitle.Size = New System.Drawing.Size(264, 20)
        Me.lblPOPTitle.TabIndex = 10
        Me.lblPOPTitle.Text = "Receiving (POP3)"
        '
        'lblSMTPAccountName
        '
        Me.lblSMTPAccountName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSMTPAccountName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSMTPAccountName.Location = New System.Drawing.Point(436, 244)
        Me.lblSMTPAccountName.Name = "lblSMTPAccountName"
        Me.lblSMTPAccountName.Size = New System.Drawing.Size(248, 20)
        Me.lblSMTPAccountName.TabIndex = 9
        Me.lblSMTPAccountName.Text = "Account name:"
        '
        'lblPOPAccountName
        '
        Me.lblPOPAccountName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPOPAccountName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPOPAccountName.Location = New System.Drawing.Point(162, 245)
        Me.lblPOPAccountName.Name = "lblPOPAccountName"
        Me.lblPOPAccountName.Size = New System.Drawing.Size(264, 20)
        Me.lblPOPAccountName.TabIndex = 9
        Me.lblPOPAccountName.Text = "Account name:"
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(17, 245)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(142, 20)
        Me.Label27.TabIndex = 9
        Me.Label27.Text = "Account name:"
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(17, 115)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(142, 20)
        Me.Label26.TabIndex = 8
        Me.Label26.Text = "Options:"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(17, 94)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(142, 20)
        Me.Label25.TabIndex = 7
        Me.Label25.Text = "Secure Authentication:"
        '
        'lblSMTPUsername
        '
        Me.lblSMTPUsername.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSMTPUsername.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSMTPUsername.Location = New System.Drawing.Point(436, 58)
        Me.lblSMTPUsername.Name = "lblSMTPUsername"
        Me.lblSMTPUsername.Size = New System.Drawing.Size(248, 20)
        Me.lblSMTPUsername.TabIndex = 6
        Me.lblSMTPUsername.Text = "Username:"
        '
        'lblPOPUsername
        '
        Me.lblPOPUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPOPUsername.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPOPUsername.Location = New System.Drawing.Point(162, 58)
        Me.lblPOPUsername.Name = "lblPOPUsername"
        Me.lblPOPUsername.Size = New System.Drawing.Size(264, 20)
        Me.lblPOPUsername.TabIndex = 6
        Me.lblPOPUsername.Text = "Username:"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(17, 58)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(142, 20)
        Me.Label23.TabIndex = 6
        Me.Label23.Text = "Username:"
        '
        'lblSMTPServer
        '
        Me.lblSMTPServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSMTPServer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSMTPServer.Location = New System.Drawing.Point(436, 41)
        Me.lblSMTPServer.Name = "lblSMTPServer"
        Me.lblSMTPServer.Size = New System.Drawing.Size(248, 20)
        Me.lblSMTPServer.TabIndex = 5
        Me.lblSMTPServer.Text = "Server:"
        '
        'lblPOPServer
        '
        Me.lblPOPServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPOPServer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPOPServer.Location = New System.Drawing.Point(162, 38)
        Me.lblPOPServer.Name = "lblPOPServer"
        Me.lblPOPServer.Size = New System.Drawing.Size(264, 20)
        Me.lblPOPServer.TabIndex = 5
        Me.lblPOPServer.Text = "Server:"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(17, 41)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(142, 20)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "Server (port):"
        '
        'lblEmail
        '
        Me.lblEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEmail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.Location = New System.Drawing.Point(436, 135)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(248, 20)
        Me.lblEmail.TabIndex = 4
        Me.lblEmail.Text = "Email:"
        '
        'lblDisplayName
        '
        Me.lblDisplayName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDisplayName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayName.Location = New System.Drawing.Point(436, 115)
        Me.lblDisplayName.Name = "lblDisplayName"
        Me.lblDisplayName.Size = New System.Drawing.Size(248, 20)
        Me.lblDisplayName.TabIndex = 3
        Me.lblDisplayName.Text = "Name:"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.DetectUrls = False
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.ShortcutsEnabled = False
        Me.RichTextBox1.Size = New System.Drawing.Size(177, 485)
        Me.RichTextBox1.TabIndex = 36
        Me.RichTextBox1.TabStop = False
        Me.RichTextBox1.Text = ""
        '
        'grpPOPDetails2
        '
        Me.grpPOPDetails2.AutoSize = True
        Me.grpPOPDetails2.BackColor = System.Drawing.Color.Transparent
        Me.grpPOPDetails2.Controls.Add(Me.GroupBox2)
        Me.grpPOPDetails2.Controls.Add(Me.GroupBox1)
        Me.grpPOPDetails2.Controls.Add(Me.Label35)
        Me.grpPOPDetails2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpPOPDetails2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPOPDetails2.Location = New System.Drawing.Point(0, 0)
        Me.grpPOPDetails2.Name = "grpPOPDetails2"
        Me.grpPOPDetails2.Size = New System.Drawing.Size(690, 485)
        Me.grpPOPDetails2.TabIndex = 37
        Me.grpPOPDetails2.TabStop = False
        Me.grpPOPDetails2.Tag = "Receiving (POP3) Account Preferences"
        Me.grpPOPDetails2.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboSendReceiptsSenderUnknown)
        Me.GroupBox2.Controls.Add(Me.cboSendReceiptsSenderKnown)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 163)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(482, 105)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Return Receipts (can be overridden in the address book)"
        '
        'cboSendReceiptsSenderUnknown
        '
        Me.cboSendReceiptsSenderUnknown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSendReceiptsSenderUnknown.FormattingEnabled = True
        Me.cboSendReceiptsSenderUnknown.Items.AddRange(New Object() {"Ask me", "Always", "Never"})
        Me.cboSendReceiptsSenderUnknown.Location = New System.Drawing.Point(348, 60)
        Me.cboSendReceiptsSenderUnknown.Name = "cboSendReceiptsSenderUnknown"
        Me.cboSendReceiptsSenderUnknown.Size = New System.Drawing.Size(121, 24)
        Me.cboSendReceiptsSenderUnknown.TabIndex = 7
        '
        'cboSendReceiptsSenderKnown
        '
        Me.cboSendReceiptsSenderKnown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSendReceiptsSenderKnown.FormattingEnabled = True
        Me.cboSendReceiptsSenderKnown.Items.AddRange(New Object() {"Ask me", "Always", "Never"})
        Me.cboSendReceiptsSenderKnown.Location = New System.Drawing.Point(348, 29)
        Me.cboSendReceiptsSenderKnown.Name = "cboSendReceiptsSenderKnown"
        Me.cboSendReceiptsSenderKnown.Size = New System.Drawing.Size(121, 24)
        Me.cboSendReceiptsSenderKnown.TabIndex = 5
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(12, 63)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(334, 16)
        Me.Label30.TabIndex = 6
        Me.Label30.Text = "Send return receipts to senders not in my address book:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(312, 16)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Send return receipts to senders in my address book:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkDownloadAtStartup)
        Me.GroupBox1.Controls.Add(Me.chkLeaveOnServer)
        Me.GroupBox1.Controls.Add(Me.txtDownloadFrequency)
        Me.GroupBox1.Controls.Add(Me.chkDownloadAtFrequency)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(479, 105)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Downloading New Messages"
        '
        'chkDownloadAtStartup
        '
        Me.chkDownloadAtStartup.AutoSize = True
        Me.chkDownloadAtStartup.Checked = True
        Me.chkDownloadAtStartup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDownloadAtStartup.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDownloadAtStartup.Location = New System.Drawing.Point(23, 24)
        Me.chkDownloadAtStartup.Name = "chkDownloadAtStartup"
        Me.chkDownloadAtStartup.Size = New System.Drawing.Size(233, 20)
        Me.chkDownloadAtStartup.TabIndex = 0
        Me.chkDownloadAtStartup.Text = "Download new messages at &startup"
        Me.chkDownloadAtStartup.UseVisualStyleBackColor = True
        '
        'chkLeaveOnServer
        '
        Me.chkLeaveOnServer.AutoSize = True
        Me.chkLeaveOnServer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLeaveOnServer.Location = New System.Drawing.Point(23, 81)
        Me.chkLeaveOnServer.Name = "chkLeaveOnServer"
        Me.chkLeaveOnServer.Size = New System.Drawing.Size(180, 20)
        Me.chkLeaveOnServer.TabIndex = 3
        Me.chkLeaveOnServer.Text = "&Leave messages on server"
        Me.chkLeaveOnServer.UseVisualStyleBackColor = True
        '
        'txtDownloadFrequency
        '
        Me.txtDownloadFrequency.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDownloadFrequency.Location = New System.Drawing.Point(229, 52)
        Me.txtDownloadFrequency.Name = "txtDownloadFrequency"
        Me.txtDownloadFrequency.Size = New System.Drawing.Size(42, 22)
        Me.txtDownloadFrequency.TabIndex = 2
        Me.txtDownloadFrequency.Tag = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\" & _
    "f1\fnil\fcharset0 Arial;}{\f2\fnil\fcharset2 Symbol;}}"
        Me.txtDownloadFrequency.Text = "10"
        Me.txtDownloadFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkDownloadAtFrequency
        '
        Me.chkDownloadAtFrequency.AutoSize = True
        Me.chkDownloadAtFrequency.Checked = True
        Me.chkDownloadAtFrequency.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDownloadAtFrequency.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDownloadAtFrequency.Location = New System.Drawing.Point(23, 54)
        Me.chkDownloadAtFrequency.Name = "chkDownloadAtFrequency"
        Me.chkDownloadAtFrequency.Size = New System.Drawing.Size(208, 20)
        Me.chkDownloadAtFrequency.TabIndex = 1
        Me.chkDownloadAtFrequency.Text = "Download new messages every"
        Me.chkDownloadAtFrequency.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(278, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 16)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "minutes"
        '
        'Label35
        '
        Me.Label35.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label35.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(14, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(659, 25)
        Me.Label35.TabIndex = 2
        Me.Label35.Text = "Please choose your preferences for this POP3 account."
        '
        'grpSMTPDetails2
        '
        Me.grpSMTPDetails2.AutoSize = True
        Me.grpSMTPDetails2.BackColor = System.Drawing.Color.Transparent
        Me.grpSMTPDetails2.Controls.Add(Me.llblSMTPUsernameFromPOPUsername)
        Me.grpSMTPDetails2.Controls.Add(Me.btnTestSMTP)
        Me.grpSMTPDetails2.Controls.Add(Me.llblShowSMTPSecuritySettings)
        Me.grpSMTPDetails2.Controls.Add(Me.grpSMTPSecuritySettings)
        Me.grpSMTPDetails2.Controls.Add(Me.Label29)
        Me.grpSMTPDetails2.Controls.Add(Me.lblSMTPDefaultPort)
        Me.grpSMTPDetails2.Controls.Add(Me.Label16)
        Me.grpSMTPDetails2.Controls.Add(Me.txtSMTPServerPort)
        Me.grpSMTPDetails2.Controls.Add(Me.txtSMTPServer)
        Me.grpSMTPDetails2.Controls.Add(Me.Label4)
        Me.grpSMTPDetails2.Controls.Add(Me.txtSMTPUsername)
        Me.grpSMTPDetails2.Controls.Add(Me.Label17)
        Me.grpSMTPDetails2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpSMTPDetails2.Location = New System.Drawing.Point(0, 0)
        Me.grpSMTPDetails2.Name = "grpSMTPDetails2"
        Me.grpSMTPDetails2.Size = New System.Drawing.Size(690, 485)
        Me.grpSMTPDetails2.TabIndex = 14
        Me.grpSMTPDetails2.TabStop = False
        Me.grpSMTPDetails2.Tag = "Sending (SMTP) Server Settings"
        Me.grpSMTPDetails2.Visible = False
        '
        'llblSMTPUsernameFromPOPUsername
        '
        Me.llblSMTPUsernameFromPOPUsername.AutoSize = True
        Me.llblSMTPUsernameFromPOPUsername.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblSMTPUsernameFromPOPUsername.Location = New System.Drawing.Point(540, 98)
        Me.llblSMTPUsernameFromPOPUsername.Name = "llblSMTPUsernameFromPOPUsername"
        Me.llblSMTPUsernameFromPOPUsername.Size = New System.Drawing.Size(114, 16)
        Me.llblSMTPUsernameFromPOPUsername.TabIndex = 43
        Me.llblSMTPUsernameFromPOPUsername.TabStop = True
        Me.llblSMTPUsernameFromPOPUsername.Text = "Same as receiving"
        '
        'Label29
        '
        Me.Label29.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(14, 16)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(659, 42)
        Me.Label29.TabIndex = 2
        Me.Label29.Text = "Please enter your sending settings to use with this receiving account."
        '
        'grpSMTPDetails3
        '
        Me.grpSMTPDetails3.AutoSize = True
        Me.grpSMTPDetails3.BackColor = System.Drawing.Color.Transparent
        Me.grpSMTPDetails3.Controls.Add(Me.GroupBox3)
        Me.grpSMTPDetails3.Controls.Add(Me.txtSMTPAccountName)
        Me.grpSMTPDetails3.Controls.Add(Me.Label15)
        Me.grpSMTPDetails3.Controls.Add(Me.Label6)
        Me.grpSMTPDetails3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpSMTPDetails3.Location = New System.Drawing.Point(0, 0)
        Me.grpSMTPDetails3.Name = "grpSMTPDetails3"
        Me.grpSMTPDetails3.Size = New System.Drawing.Size(690, 485)
        Me.grpSMTPDetails3.TabIndex = 38
        Me.grpSMTPDetails3.TabStop = False
        Me.grpSMTPDetails3.Tag = "Sending (SMTP) Preferences"
        Me.grpSMTPDetails3.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.txtSMTPDisplayName)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtSMTPDisplayEmail)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtSMTPReplyTo)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(17, 51)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(532, 100)
        Me.GroupBox3.TabIndex = 34
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Recipient will see"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(16, 27)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(74, 16)
        Me.Label31.TabIndex = 5
        Me.Label31.Text = "Your name:"
        '
        'txtSMTPDisplayName
        '
        Me.txtSMTPDisplayName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSMTPDisplayName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSMTPDisplayName.Location = New System.Drawing.Point(116, 24)
        Me.txtSMTPDisplayName.Name = "txtSMTPDisplayName"
        Me.txtSMTPDisplayName.Size = New System.Drawing.Size(405, 22)
        Me.txtSMTPDisplayName.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Your email:"
        '
        'txtSMTPDisplayEmail
        '
        Me.txtSMTPDisplayEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSMTPDisplayEmail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSMTPDisplayEmail.Location = New System.Drawing.Point(116, 49)
        Me.txtSMTPDisplayEmail.Name = "txtSMTPDisplayEmail"
        Me.txtSMTPDisplayEmail.Size = New System.Drawing.Size(405, 22)
        Me.txtSMTPDisplayEmail.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 16)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Reply to:"
        '
        'txtSMTPReplyTo
        '
        Me.txtSMTPReplyTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSMTPReplyTo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSMTPReplyTo.Location = New System.Drawing.Point(116, 74)
        Me.txtSMTPReplyTo.Name = "txtSMTPReplyTo"
        Me.txtSMTPReplyTo.Size = New System.Drawing.Size(405, 22)
        Me.txtSMTPReplyTo.TabIndex = 2
        '
        'txtSMTPAccountName
        '
        Me.txtSMTPAccountName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSMTPAccountName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSMTPAccountName.Location = New System.Drawing.Point(207, 220)
        Me.txtSMTPAccountName.Name = "txtSMTPAccountName"
        Me.txtSMTPAccountName.Size = New System.Drawing.Size(467, 22)
        Me.txtSMTPAccountName.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(17, 223)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(184, 16)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "Name of this sending account:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(659, 42)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "When sending messages using this SMTP account..."
        '
        'grpWelcome
        '
        Me.grpWelcome.AutoSize = True
        Me.grpWelcome.BackColor = System.Drawing.Color.Transparent
        Me.grpWelcome.Controls.Add(Me.rtbSetupGmail)
        Me.grpWelcome.Controls.Add(Me.rtbSetupOther)
        Me.grpWelcome.Controls.Add(Me.rtbSetupHotmail)
        Me.grpWelcome.Controls.Add(Me.rdobtnSetupHotmail)
        Me.grpWelcome.Controls.Add(Me.lblGmailInfo)
        Me.grpWelcome.Controls.Add(Me.rdobtnSetupOther)
        Me.grpWelcome.Controls.Add(Me.rdobtnSetupGmail)
        Me.grpWelcome.Controls.Add(Me.Label37)
        Me.grpWelcome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpWelcome.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpWelcome.Location = New System.Drawing.Point(0, 0)
        Me.grpWelcome.Name = "grpWelcome"
        Me.grpWelcome.Size = New System.Drawing.Size(690, 485)
        Me.grpWelcome.TabIndex = 41
        Me.grpWelcome.TabStop = False
        Me.grpWelcome.Tag = "Setting up a New Email Account"
        Me.grpWelcome.Visible = False
        '
        'rtbSetupGmail
        '
        Me.rtbSetupGmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbSetupGmail.BackColor = System.Drawing.Color.White
        Me.rtbSetupGmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbSetupGmail.DetectUrls = False
        Me.rtbSetupGmail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbSetupGmail.Location = New System.Drawing.Point(56, 126)
        Me.rtbSetupGmail.Name = "rtbSetupGmail"
        Me.rtbSetupGmail.ReadOnly = True
        Me.rtbSetupGmail.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtbSetupGmail.ShortcutsEnabled = False
        Me.rtbSetupGmail.Size = New System.Drawing.Size(628, 17)
        Me.rtbSetupGmail.TabIndex = 42
        Me.rtbSetupGmail.TabStop = False
        Me.rtbSetupGmail.Text = "Gmail"
        '
        'rtbSetupOther
        '
        Me.rtbSetupOther.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbSetupOther.BackColor = System.Drawing.Color.White
        Me.rtbSetupOther.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbSetupOther.DetectUrls = False
        Me.rtbSetupOther.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbSetupOther.Location = New System.Drawing.Point(56, 182)
        Me.rtbSetupOther.Name = "rtbSetupOther"
        Me.rtbSetupOther.ReadOnly = True
        Me.rtbSetupOther.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtbSetupOther.ShortcutsEnabled = False
        Me.rtbSetupOther.Size = New System.Drawing.Size(628, 17)
        Me.rtbSetupOther.TabIndex = 42
        Me.rtbSetupOther.TabStop = False
        Me.rtbSetupOther.Text = "Other"
        '
        'rtbSetupHotmail
        '
        Me.rtbSetupHotmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbSetupHotmail.BackColor = System.Drawing.Color.White
        Me.rtbSetupHotmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbSetupHotmail.DetectUrls = False
        Me.rtbSetupHotmail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbSetupHotmail.Location = New System.Drawing.Point(56, 155)
        Me.rtbSetupHotmail.Name = "rtbSetupHotmail"
        Me.rtbSetupHotmail.ReadOnly = True
        Me.rtbSetupHotmail.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtbSetupHotmail.ShortcutsEnabled = False
        Me.rtbSetupHotmail.Size = New System.Drawing.Size(628, 17)
        Me.rtbSetupHotmail.TabIndex = 42
        Me.rtbSetupHotmail.TabStop = False
        Me.rtbSetupHotmail.Text = "Hotmail"
        '
        'rdobtnSetupHotmail
        '
        Me.rdobtnSetupHotmail.AutoSize = True
        Me.rdobtnSetupHotmail.Location = New System.Drawing.Point(36, 157)
        Me.rdobtnSetupHotmail.Name = "rdobtnSetupHotmail"
        Me.rdobtnSetupHotmail.Size = New System.Drawing.Size(14, 13)
        Me.rdobtnSetupHotmail.TabIndex = 38
        Me.rdobtnSetupHotmail.UseVisualStyleBackColor = True
        '
        'lblGmailInfo
        '
        Me.lblGmailInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGmailInfo.BackColor = System.Drawing.Color.White
        Me.lblGmailInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGmailInfo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGmailInfo.Location = New System.Drawing.Point(6, 291)
        Me.lblGmailInfo.Name = "lblGmailInfo"
        Me.lblGmailInfo.ReadOnly = True
        Me.lblGmailInfo.ShortcutsEnabled = False
        Me.lblGmailInfo.Size = New System.Drawing.Size(678, 188)
        Me.lblGmailInfo.TabIndex = 37
        Me.lblGmailInfo.TabStop = False
        Me.lblGmailInfo.Text = resources.GetString("lblGmailInfo.Text")
        Me.lblGmailInfo.Visible = False
        '
        'rdobtnSetupOther
        '
        Me.rdobtnSetupOther.AutoSize = True
        Me.rdobtnSetupOther.Location = New System.Drawing.Point(36, 184)
        Me.rdobtnSetupOther.Name = "rdobtnSetupOther"
        Me.rdobtnSetupOther.Size = New System.Drawing.Size(14, 13)
        Me.rdobtnSetupOther.TabIndex = 4
        Me.rdobtnSetupOther.UseVisualStyleBackColor = True
        '
        'rdobtnSetupGmail
        '
        Me.rdobtnSetupGmail.AutoSize = True
        Me.rdobtnSetupGmail.Location = New System.Drawing.Point(36, 128)
        Me.rdobtnSetupGmail.Name = "rdobtnSetupGmail"
        Me.rdobtnSetupGmail.Size = New System.Drawing.Size(14, 13)
        Me.rdobtnSetupGmail.TabIndex = 3
        Me.rdobtnSetupGmail.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(14, 16)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(659, 108)
        Me.Label37.TabIndex = 2
        Me.Label37.Text = resources.GetString("Label37.Text")
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.SplitContainer1)
        Me.KryptonPanel.Controls.Add(Me.Panel2)
        Me.KryptonPanel.Controls.Add(Me.Panel1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(871, 576)
        Me.KryptonPanel.TabIndex = 42
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 36)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpPOPDetails1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpPOPDetails2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpSMTPDetails1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpSMTPDetails2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpWelcome)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpSMTPDetails3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpConfirm)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.RichTextBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(871, 485)
        Me.SplitContainer1.SplitterDistance = 690
        Me.SplitContainer1.TabIndex = 42
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lblStep)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(871, 36)
        Me.Panel2.TabIndex = 44
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnNext)
        Me.Panel1.Controls.Add(Me.btnBack)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 521)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(871, 55)
        Me.Panel1.TabIndex = 43
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(760, 15)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Palette = Me.KryptonPalette1
        Me.btnCancel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnCancel.Size = New System.Drawing.Size(90, 25)
        Me.btnCancel.TabIndex = 45
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(610, 15)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Palette = Me.KryptonPalette1
        Me.btnNext.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnNext.Size = New System.Drawing.Size(90, 25)
        Me.btnNext.TabIndex = 44
        Me.btnNext.Values.Image = Global.TrulyMail.My.Resources.Resources.Arrow_right_16
        Me.btnNext.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnNext.Values.Text = "&Next"
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.Location = New System.Drawing.Point(502, 15)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Palette = Me.KryptonPalette1
        Me.btnBack.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnBack.Size = New System.Drawing.Size(90, 25)
        Me.btnBack.TabIndex = 43
        Me.btnBack.Values.Image = Global.TrulyMail.My.Resources.Resources.Arrow_left_16
        Me.btnBack.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnBack.Values.Text = "&Back"
        '
        'NewAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(871, 576)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NewAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Email Accounts"
        Me.grpPOPDetails1.ResumeLayout(False)
        Me.grpPOPDetails1.PerformLayout()
        Me.grpPOPSecurity.ResumeLayout(False)
        Me.grpPOPSecurity.PerformLayout()
        Me.grpSMTPDetails1.ResumeLayout(False)
        Me.grpSMTPDetails1.PerformLayout()
        Me.grpSMTPSecuritySettings.ResumeLayout(False)
        Me.grpSMTPSecuritySettings.PerformLayout()
        Me.grpConfirm.ResumeLayout(False)
        Me.grpPOPDetails2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpSMTPDetails2.ResumeLayout(False)
        Me.grpSMTPDetails2.PerformLayout()
        Me.grpSMTPDetails3.ResumeLayout(False)
        Me.grpSMTPDetails3.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grpWelcome.ResumeLayout(False)
        Me.grpWelcome.PerformLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblStep As System.Windows.Forms.Label
    Friend WithEvents grpPOPDetails1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPOPUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPOPServer As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpSMTPDetails1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtSMTPServer As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents rbtnNewSMTP As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnExistingSMTP As System.Windows.Forms.RadioButton
    Friend WithEvents cboSMTPProfile As System.Windows.Forms.ComboBox
    Friend WithEvents txtPOPAccountName As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents grpConfirm As System.Windows.Forms.GroupBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblDisplayName As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents txtPOPServerPort As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblPOPDefaultPort As System.Windows.Forms.Label
    Friend WithEvents llblShowPOPSecurity As System.Windows.Forms.LinkLabel
    Friend WithEvents grpPOPSecurity As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnSecurePOPSSL As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSecurePOPTLS As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rbtnSecurePOPNone As System.Windows.Forms.RadioButton
    Friend WithEvents chkSecurePOPSecureAuthentication As System.Windows.Forms.CheckBox
    Friend WithEvents grpPOPDetails2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDownloadFrequency As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents chkDownloadAtFrequency As System.Windows.Forms.CheckBox
    Friend WithEvents chkDownloadAtStartup As System.Windows.Forms.CheckBox
    Friend WithEvents chkLeaveOnServer As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboSendReceiptsSenderUnknown As System.Windows.Forms.ComboBox
    Friend WithEvents cboSendReceiptsSenderKnown As System.Windows.Forms.ComboBox
    Friend WithEvents lblSMTPDefaultPort As System.Windows.Forms.Label
    Friend WithEvents txtSMTPServerPort As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents llblShowSMTPSecuritySettings As System.Windows.Forms.LinkLabel
    Friend WithEvents grpSMTPSecuritySettings As System.Windows.Forms.GroupBox
    Friend WithEvents chkSecureSMTPSecureAuthentication As System.Windows.Forms.CheckBox
    Friend WithEvents rbtnSecureSMTPSSL As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSecureSMTPTLS As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbtnSecureSMTPNone As System.Windows.Forms.RadioButton
    Friend WithEvents grpSMTPDetails2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents grpSMTPDetails3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPReplyTo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPDisplayEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPAccountName As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents grpWelcome As System.Windows.Forms.GroupBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lblPOPTitle As System.Windows.Forms.Label
    Friend WithEvents lblSMTPUsername As System.Windows.Forms.Label
    Friend WithEvents lblPOPUsername As System.Windows.Forms.Label
    Friend WithEvents lblSMTPServer As System.Windows.Forms.Label
    Friend WithEvents lblPOPServer As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lblPOPAccountName As System.Windows.Forms.Label
    Friend WithEvents lblSMTPAccountName As System.Windows.Forms.Label
    Friend WithEvents lblSMTPSecureConnection As System.Windows.Forms.Label
    Friend WithEvents lblPOPSecureConnection As System.Windows.Forms.Label
    Friend WithEvents lblPOPSecureAuthentication As System.Windows.Forms.Label
    Friend WithEvents lblSMTPSecureAuthentication As System.Windows.Forms.Label
    Friend WithEvents lblDownloadAtInterval As System.Windows.Forms.Label
    Friend WithEvents lblDownloadAtStartup As System.Windows.Forms.Label
    Friend WithEvents lblReceiptNotInBook As System.Windows.Forms.Label
    Friend WithEvents lblReceiptInBook As System.Windows.Forms.Label
    Friend WithEvents lblReplyTo As System.Windows.Forms.Label
    Friend WithEvents lblInBox As System.Windows.Forms.Label
    Friend WithEvents lblFoldersLabel As System.Windows.Forms.Label
    Friend WithEvents btnTestSMTP As System.Windows.Forms.Button
    Friend WithEvents llblSMTPUsernameFromPOPUsername As System.Windows.Forms.LinkLabel
    Friend WithEvents rdobtnSetupOther As System.Windows.Forms.RadioButton
    Friend WithEvents rdobtnSetupGmail As System.Windows.Forms.RadioButton
    Friend WithEvents lblGmailInfo As System.Windows.Forms.RichTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents rtbSetupHotmail As System.Windows.Forms.RichTextBox
    Friend WithEvents rdobtnSetupHotmail As System.Windows.Forms.RadioButton
    Friend WithEvents rtbSetupGmail As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbSetupOther As System.Windows.Forms.RichTextBox
    Friend WithEvents llblChangeInbox As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnNext As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnBack As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
