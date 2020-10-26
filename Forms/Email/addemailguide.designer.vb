<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEmailGuide
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddEmailGuide))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.llblStartOver = New System.Windows.Forms.LinkLabel()
        Me.lblEmailFormat = New System.Windows.Forms.Label()
        Me.llblWhyAskForPassword = New System.Windows.Forms.LinkLabel()
        Me.chkRememberPassword = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.grpServerSettings = New System.Windows.Forms.GroupBox()
        Me.btnEditSettings = New System.Windows.Forms.Button()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.grpServerSecurity = New System.Windows.Forms.GroupBox()
        Me.lblReceivingConnectionEncryption = New System.Windows.Forms.Label()
        Me.pbReceivingLoginSecurity = New System.Windows.Forms.PictureBox()
        Me.lblSendingConnectionEncryption = New System.Windows.Forms.Label()
        Me.lblUsernameCaption = New System.Windows.Forms.Label()
        Me.lblSendingServerPort = New System.Windows.Forms.Label()
        Me.lblSendingServerAddress = New System.Windows.Forms.Label()
        Me.lblSendingCaption = New System.Windows.Forms.Label()
        Me.pbSendingStatus = New System.Windows.Forms.PictureBox()
        Me.lblReceivingServerPort = New System.Windows.Forms.Label()
        Me.lblReceivingServerAddress = New System.Windows.Forms.Label()
        Me.lblReceivingCaption = New System.Windows.Forms.Label()
        Me.pbReceivingStatus = New System.Windows.Forms.PictureBox()
        Me.lblSearchingTitle = New System.Windows.Forms.Label()
        Me.pbWorking = New System.Windows.Forms.PictureBox()
        Me.pnlSearchButtons = New System.Windows.Forms.Panel()
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.bgwGetDomainConfigs = New System.ComponentModel.BackgroundWorker()
        Me.pnlCreateAccountButtons = New System.Windows.Forms.Panel()
        Me.btnManualSetup = New System.Windows.Forms.Button()
        Me.btnCreateAccount = New System.Windows.Forms.Button()
        Me.btnCancel2 = New System.Windows.Forms.Button()
        Me.bgwTestConfigs = New System.ComponentModel.BackgroundWorker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtEditedSendingServerAddress = New System.Windows.Forms.TextBox()
        Me.txtEditedReceivingServerAddress = New System.Windows.Forms.TextBox()
        Me.txtEditedUsername = New System.Windows.Forms.TextBox()
        Me.txtEditedSendingPort = New System.Windows.Forms.TextBox()
        Me.txtEditedReceivingPort = New System.Windows.Forms.TextBox()
        Me.lblEditedPortCaption = New System.Windows.Forms.Label()
        Me.grpEditedSettings = New System.Windows.Forms.GroupBox()
        Me.btnReTestSettings = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboEditedSendingConnectionSecurity = New System.Windows.Forms.ComboBox()
        Me.cboEditedReceivingConnectionSecurity = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pbEditedSendingStatus = New System.Windows.Forms.PictureBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pbEditedReceivingStatus = New System.Windows.Forms.PictureBox()
        Me.lblEditedSearchingTitle = New System.Windows.Forms.Label()
        Me.pbEditedWorking = New System.Windows.Forms.PictureBox()
        Me.bgwTryAutoConfig = New System.ComponentModel.BackgroundWorker()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.GroupBox1.SuspendLayout()
        Me.grpServerSettings.SuspendLayout()
        Me.grpServerSecurity.SuspendLayout()
        CType(Me.pbReceivingLoginSecurity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSendingStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbReceivingStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbWorking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearchButtons.SuspendLayout()
        Me.pnlCreateAccountButtons.SuspendLayout()
        Me.grpEditedSettings.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pbEditedSendingStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEditedReceivingStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEditedWorking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.llblStartOver)
        Me.GroupBox1.Controls.Add(Me.lblEmailFormat)
        Me.GroupBox1.Controls.Add(Me.llblWhyAskForPassword)
        Me.GroupBox1.Controls.Add(Me.chkRememberPassword)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtEmailAddress)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtFullName)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(543, 150)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'llblStartOver
        '
        Me.llblStartOver.AutoSize = True
        Me.llblStartOver.Location = New System.Drawing.Point(468, 115)
        Me.llblStartOver.Name = "llblStartOver"
        Me.llblStartOver.Size = New System.Drawing.Size(66, 16)
        Me.llblStartOver.TabIndex = 10
        Me.llblStartOver.TabStop = True
        Me.llblStartOver.Text = "Start Over"
        Me.llblStartOver.Visible = False
        '
        'lblEmailFormat
        '
        Me.lblEmailFormat.AutoSize = True
        Me.lblEmailFormat.Location = New System.Drawing.Point(283, 49)
        Me.lblEmailFormat.Name = "lblEmailFormat"
        Me.lblEmailFormat.Size = New System.Drawing.Size(244, 16)
        Me.lblEmailFormat.TabIndex = 9
        Me.lblEmailFormat.Text = "Must be in the format user@domain.com"
        '
        'llblWhyAskForPassword
        '
        Me.llblWhyAskForPassword.AutoSize = True
        Me.llblWhyAskForPassword.Location = New System.Drawing.Point(283, 79)
        Me.llblWhyAskForPassword.Name = "llblWhyAskForPassword"
        Me.llblWhyAskForPassword.Size = New System.Drawing.Size(137, 16)
        Me.llblWhyAskForPassword.TabIndex = 8
        Me.llblWhyAskForPassword.TabStop = True
        Me.llblWhyAskForPassword.Text = "Why do we need this?"
        '
        'chkRememberPassword
        '
        Me.chkRememberPassword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRememberPassword.Checked = True
        Me.chkRememberPassword.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRememberPassword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRememberPassword.Location = New System.Drawing.Point(17, 105)
        Me.chkRememberPassword.Name = "chkRememberPassword"
        Me.chkRememberPassword.Size = New System.Drawing.Size(170, 20)
        Me.chkRememberPassword.TabIndex = 7
        Me.chkRememberPassword.Text = "Remember password:"
        Me.chkRememberPassword.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(119, 76)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(158, 22)
        Me.txtPassword.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Email address:"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Location = New System.Drawing.Point(119, 46)
        Me.txtEmailAddress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(158, 22)
        Me.txtEmailAddress.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(283, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "(shown to others)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Your name:"
        '
        'txtFullName
        '
        Me.txtFullName.Location = New System.Drawing.Point(119, 16)
        Me.txtFullName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(158, 22)
        Me.txtFullName.TabIndex = 0
        '
        'grpServerSettings
        '
        Me.grpServerSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpServerSettings.BackColor = System.Drawing.Color.Transparent
        Me.grpServerSettings.Controls.Add(Me.btnEditSettings)
        Me.grpServerSettings.Controls.Add(Me.lblUsername)
        Me.grpServerSettings.Controls.Add(Me.grpServerSecurity)
        Me.grpServerSettings.Controls.Add(Me.lblUsernameCaption)
        Me.grpServerSettings.Controls.Add(Me.lblSendingServerPort)
        Me.grpServerSettings.Controls.Add(Me.lblSendingServerAddress)
        Me.grpServerSettings.Controls.Add(Me.lblSendingCaption)
        Me.grpServerSettings.Controls.Add(Me.pbSendingStatus)
        Me.grpServerSettings.Controls.Add(Me.lblReceivingServerPort)
        Me.grpServerSettings.Controls.Add(Me.lblReceivingServerAddress)
        Me.grpServerSettings.Controls.Add(Me.lblReceivingCaption)
        Me.grpServerSettings.Controls.Add(Me.pbReceivingStatus)
        Me.grpServerSettings.Controls.Add(Me.lblSearchingTitle)
        Me.grpServerSettings.Controls.Add(Me.pbWorking)
        Me.grpServerSettings.Location = New System.Drawing.Point(14, 164)
        Me.grpServerSettings.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpServerSettings.Name = "grpServerSettings"
        Me.grpServerSettings.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpServerSettings.Size = New System.Drawing.Size(543, 158)
        Me.grpServerSettings.TabIndex = 1
        Me.grpServerSettings.TabStop = False
        Me.grpServerSettings.Visible = False
        '
        'btnEditSettings
        '
        Me.btnEditSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditSettings.Location = New System.Drawing.Point(474, 15)
        Me.btnEditSettings.Name = "btnEditSettings"
        Me.btnEditSettings.Size = New System.Drawing.Size(60, 28)
        Me.btnEditSettings.TabIndex = 2
        Me.btnEditSettings.Text = "&Edit"
        Me.btnEditSettings.UseVisualStyleBackColor = True
        Me.btnEditSettings.Visible = False
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(117, 55)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(0, 16)
        Me.lblUsername.TabIndex = 24
        '
        'grpServerSecurity
        '
        Me.grpServerSecurity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpServerSecurity.Controls.Add(Me.lblReceivingConnectionEncryption)
        Me.grpServerSecurity.Controls.Add(Me.pbReceivingLoginSecurity)
        Me.grpServerSecurity.Controls.Add(Me.lblSendingConnectionEncryption)
        Me.grpServerSecurity.Location = New System.Drawing.Point(411, 60)
        Me.grpServerSecurity.Name = "grpServerSecurity"
        Me.grpServerSecurity.Size = New System.Drawing.Size(121, 78)
        Me.grpServerSecurity.TabIndex = 23
        Me.grpServerSecurity.TabStop = False
        Me.grpServerSecurity.Text = "Server Security"
        '
        'lblReceivingConnectionEncryption
        '
        Me.lblReceivingConnectionEncryption.AutoSize = True
        Me.lblReceivingConnectionEncryption.Location = New System.Drawing.Point(11, 23)
        Me.lblReceivingConnectionEncryption.Name = "lblReceivingConnectionEncryption"
        Me.lblReceivingConnectionEncryption.Size = New System.Drawing.Size(0, 16)
        Me.lblReceivingConnectionEncryption.TabIndex = 14
        '
        'pbReceivingLoginSecurity
        '
        Me.pbReceivingLoginSecurity.Location = New System.Drawing.Point(76, 23)
        Me.pbReceivingLoginSecurity.Name = "pbReceivingLoginSecurity"
        Me.pbReceivingLoginSecurity.Size = New System.Drawing.Size(16, 16)
        Me.pbReceivingLoginSecurity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbReceivingLoginSecurity.TabIndex = 15
        Me.pbReceivingLoginSecurity.TabStop = False
        '
        'lblSendingConnectionEncryption
        '
        Me.lblSendingConnectionEncryption.AutoSize = True
        Me.lblSendingConnectionEncryption.Location = New System.Drawing.Point(11, 51)
        Me.lblSendingConnectionEncryption.Name = "lblSendingConnectionEncryption"
        Me.lblSendingConnectionEncryption.Size = New System.Drawing.Size(0, 16)
        Me.lblSendingConnectionEncryption.TabIndex = 20
        '
        'lblUsernameCaption
        '
        Me.lblUsernameCaption.AutoSize = True
        Me.lblUsernameCaption.Location = New System.Drawing.Point(47, 55)
        Me.lblUsernameCaption.Name = "lblUsernameCaption"
        Me.lblUsernameCaption.Size = New System.Drawing.Size(75, 16)
        Me.lblUsernameCaption.TabIndex = 22
        Me.lblUsernameCaption.Text = "Username: "
        '
        'lblSendingServerPort
        '
        Me.lblSendingServerPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSendingServerPort.AutoSize = True
        Me.lblSendingServerPort.Location = New System.Drawing.Point(376, 111)
        Me.lblSendingServerPort.Name = "lblSendingServerPort"
        Me.lblSendingServerPort.Size = New System.Drawing.Size(0, 16)
        Me.lblSendingServerPort.TabIndex = 19
        '
        'lblSendingServerAddress
        '
        Me.lblSendingServerAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSendingServerAddress.Location = New System.Drawing.Point(117, 111)
        Me.lblSendingServerAddress.Name = "lblSendingServerAddress"
        Me.lblSendingServerAddress.Size = New System.Drawing.Size(247, 16)
        Me.lblSendingServerAddress.TabIndex = 18
        '
        'lblSendingCaption
        '
        Me.lblSendingCaption.AutoSize = True
        Me.lblSendingCaption.Location = New System.Drawing.Point(47, 111)
        Me.lblSendingCaption.Name = "lblSendingCaption"
        Me.lblSendingCaption.Size = New System.Drawing.Size(59, 16)
        Me.lblSendingCaption.TabIndex = 17
        Me.lblSendingCaption.Text = "Sending:"
        '
        'pbSendingStatus
        '
        Me.pbSendingStatus.Location = New System.Drawing.Point(13, 111)
        Me.pbSendingStatus.Name = "pbSendingStatus"
        Me.pbSendingStatus.Size = New System.Drawing.Size(16, 16)
        Me.pbSendingStatus.TabIndex = 16
        Me.pbSendingStatus.TabStop = False
        '
        'lblReceivingServerPort
        '
        Me.lblReceivingServerPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReceivingServerPort.AutoSize = True
        Me.lblReceivingServerPort.Location = New System.Drawing.Point(376, 83)
        Me.lblReceivingServerPort.Name = "lblReceivingServerPort"
        Me.lblReceivingServerPort.Size = New System.Drawing.Size(0, 16)
        Me.lblReceivingServerPort.TabIndex = 13
        '
        'lblReceivingServerAddress
        '
        Me.lblReceivingServerAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReceivingServerAddress.BackColor = System.Drawing.Color.Transparent
        Me.lblReceivingServerAddress.Location = New System.Drawing.Point(117, 83)
        Me.lblReceivingServerAddress.Name = "lblReceivingServerAddress"
        Me.lblReceivingServerAddress.Size = New System.Drawing.Size(247, 16)
        Me.lblReceivingServerAddress.TabIndex = 12
        '
        'lblReceivingCaption
        '
        Me.lblReceivingCaption.AutoSize = True
        Me.lblReceivingCaption.Location = New System.Drawing.Point(47, 83)
        Me.lblReceivingCaption.Name = "lblReceivingCaption"
        Me.lblReceivingCaption.Size = New System.Drawing.Size(67, 16)
        Me.lblReceivingCaption.TabIndex = 11
        Me.lblReceivingCaption.Text = "Receiving:"
        '
        'pbReceivingStatus
        '
        Me.pbReceivingStatus.Location = New System.Drawing.Point(13, 83)
        Me.pbReceivingStatus.Name = "pbReceivingStatus"
        Me.pbReceivingStatus.Size = New System.Drawing.Size(16, 16)
        Me.pbReceivingStatus.TabIndex = 2
        Me.pbReceivingStatus.TabStop = False
        '
        'lblSearchingTitle
        '
        Me.lblSearchingTitle.AutoSize = True
        Me.lblSearchingTitle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchingTitle.Location = New System.Drawing.Point(47, 19)
        Me.lblSearchingTitle.Name = "lblSearchingTitle"
        Me.lblSearchingTitle.Size = New System.Drawing.Size(216, 18)
        Me.lblSearchingTitle.TabIndex = 1
        Me.lblSearchingTitle.Text = "Searching TrulyMail Database"
        '
        'pbWorking
        '
        Me.pbWorking.Image = CType(resources.GetObject("pbWorking.Image"), System.Drawing.Image)
        Me.pbWorking.Location = New System.Drawing.Point(6, 10)
        Me.pbWorking.Name = "pbWorking"
        Me.pbWorking.Size = New System.Drawing.Size(34, 34)
        Me.pbWorking.TabIndex = 0
        Me.pbWorking.TabStop = False
        '
        'pnlSearchButtons
        '
        Me.pnlSearchButtons.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSearchButtons.AutoSize = True
        Me.pnlSearchButtons.BackColor = System.Drawing.Color.Transparent
        Me.pnlSearchButtons.Controls.Add(Me.btnContinue)
        Me.pnlSearchButtons.Controls.Add(Me.btnCancel)
        Me.pnlSearchButtons.Location = New System.Drawing.Point(355, 166)
        Me.pnlSearchButtons.Name = "pnlSearchButtons"
        Me.pnlSearchButtons.Size = New System.Drawing.Size(200, 34)
        Me.pnlSearchButtons.TabIndex = 0
        '
        'btnContinue
        '
        Me.btnContinue.Location = New System.Drawing.Point(87, 3)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(110, 28)
        Me.btnContinue.TabIndex = 1
        Me.btnContinue.Text = "C&ontinue"
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(4, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 28)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'bgwGetDomainConfigs
        '
        Me.bgwGetDomainConfigs.WorkerSupportsCancellation = True
        '
        'pnlCreateAccountButtons
        '
        Me.pnlCreateAccountButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCreateAccountButtons.AutoSize = True
        Me.pnlCreateAccountButtons.BackColor = System.Drawing.Color.Transparent
        Me.pnlCreateAccountButtons.Controls.Add(Me.btnManualSetup)
        Me.pnlCreateAccountButtons.Controls.Add(Me.btnCreateAccount)
        Me.pnlCreateAccountButtons.Controls.Add(Me.btnCancel2)
        Me.pnlCreateAccountButtons.Location = New System.Drawing.Point(13, 322)
        Me.pnlCreateAccountButtons.Name = "pnlCreateAccountButtons"
        Me.pnlCreateAccountButtons.Size = New System.Drawing.Size(549, 33)
        Me.pnlCreateAccountButtons.TabIndex = 1
        Me.pnlCreateAccountButtons.Visible = False
        '
        'btnManualSetup
        '
        Me.btnManualSetup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnManualSetup.Location = New System.Drawing.Point(0, 2)
        Me.btnManualSetup.Name = "btnManualSetup"
        Me.btnManualSetup.Size = New System.Drawing.Size(116, 28)
        Me.btnManualSetup.TabIndex = 2
        Me.btnManualSetup.Text = "&Manual Setup"
        Me.btnManualSetup.UseVisualStyleBackColor = True
        '
        'btnCreateAccount
        '
        Me.btnCreateAccount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateAccount.Enabled = False
        Me.btnCreateAccount.Location = New System.Drawing.Point(434, 2)
        Me.btnCreateAccount.Name = "btnCreateAccount"
        Me.btnCreateAccount.Size = New System.Drawing.Size(110, 28)
        Me.btnCreateAccount.TabIndex = 1
        Me.btnCreateAccount.Text = "&Create &Account"
        Me.btnCreateAccount.UseVisualStyleBackColor = True
        '
        'btnCancel2
        '
        Me.btnCancel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel2.Location = New System.Drawing.Point(351, 2)
        Me.btnCancel2.Name = "btnCancel2"
        Me.btnCancel2.Size = New System.Drawing.Size(75, 28)
        Me.btnCancel2.TabIndex = 0
        Me.btnCancel2.Text = "&Cancel"
        Me.btnCancel2.UseVisualStyleBackColor = True
        '
        'bgwTestConfigs
        '
        Me.bgwTestConfigs.WorkerSupportsCancellation = True
        '
        'txtEditedSendingServerAddress
        '
        Me.txtEditedSendingServerAddress.Location = New System.Drawing.Point(129, 109)
        Me.txtEditedSendingServerAddress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEditedSendingServerAddress.Name = "txtEditedSendingServerAddress"
        Me.txtEditedSendingServerAddress.Size = New System.Drawing.Size(158, 22)
        Me.txtEditedSendingServerAddress.TabIndex = 27
        '
        'txtEditedReceivingServerAddress
        '
        Me.txtEditedReceivingServerAddress.Location = New System.Drawing.Point(129, 81)
        Me.txtEditedReceivingServerAddress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEditedReceivingServerAddress.Name = "txtEditedReceivingServerAddress"
        Me.txtEditedReceivingServerAddress.Size = New System.Drawing.Size(158, 22)
        Me.txtEditedReceivingServerAddress.TabIndex = 26
        '
        'txtEditedUsername
        '
        Me.txtEditedUsername.Location = New System.Drawing.Point(129, 53)
        Me.txtEditedUsername.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEditedUsername.Name = "txtEditedUsername"
        Me.txtEditedUsername.Size = New System.Drawing.Size(158, 22)
        Me.txtEditedUsername.TabIndex = 25
        '
        'txtEditedSendingPort
        '
        Me.txtEditedSendingPort.Location = New System.Drawing.Point(322, 109)
        Me.txtEditedSendingPort.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEditedSendingPort.Name = "txtEditedSendingPort"
        Me.txtEditedSendingPort.Size = New System.Drawing.Size(44, 22)
        Me.txtEditedSendingPort.TabIndex = 29
        '
        'txtEditedReceivingPort
        '
        Me.txtEditedReceivingPort.Location = New System.Drawing.Point(322, 81)
        Me.txtEditedReceivingPort.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEditedReceivingPort.Name = "txtEditedReceivingPort"
        Me.txtEditedReceivingPort.Size = New System.Drawing.Size(44, 22)
        Me.txtEditedReceivingPort.TabIndex = 28
        '
        'lblEditedPortCaption
        '
        Me.lblEditedPortCaption.AutoSize = True
        Me.lblEditedPortCaption.Location = New System.Drawing.Point(328, 59)
        Me.lblEditedPortCaption.Name = "lblEditedPortCaption"
        Me.lblEditedPortCaption.Size = New System.Drawing.Size(32, 16)
        Me.lblEditedPortCaption.TabIndex = 30
        Me.lblEditedPortCaption.Text = "Port"
        '
        'grpEditedSettings
        '
        Me.grpEditedSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEditedSettings.AutoSize = True
        Me.grpEditedSettings.BackColor = System.Drawing.Color.Transparent
        Me.grpEditedSettings.Controls.Add(Me.lblEditedPortCaption)
        Me.grpEditedSettings.Controls.Add(Me.btnReTestSettings)
        Me.grpEditedSettings.Controls.Add(Me.txtEditedSendingPort)
        Me.grpEditedSettings.Controls.Add(Me.Button2)
        Me.grpEditedSettings.Controls.Add(Me.txtEditedReceivingPort)
        Me.grpEditedSettings.Controls.Add(Me.GroupBox3)
        Me.grpEditedSettings.Controls.Add(Me.txtEditedSendingServerAddress)
        Me.grpEditedSettings.Controls.Add(Me.Label9)
        Me.grpEditedSettings.Controls.Add(Me.txtEditedReceivingServerAddress)
        Me.grpEditedSettings.Controls.Add(Me.Label10)
        Me.grpEditedSettings.Controls.Add(Me.txtEditedUsername)
        Me.grpEditedSettings.Controls.Add(Me.Label12)
        Me.grpEditedSettings.Controls.Add(Me.pbEditedSendingStatus)
        Me.grpEditedSettings.Controls.Add(Me.Label13)
        Me.grpEditedSettings.Controls.Add(Me.Label15)
        Me.grpEditedSettings.Controls.Add(Me.pbEditedReceivingStatus)
        Me.grpEditedSettings.Controls.Add(Me.lblEditedSearchingTitle)
        Me.grpEditedSettings.Controls.Add(Me.pbEditedWorking)
        Me.grpEditedSettings.Location = New System.Drawing.Point(13, 162)
        Me.grpEditedSettings.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpEditedSettings.Name = "grpEditedSettings"
        Me.grpEditedSettings.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpEditedSettings.Size = New System.Drawing.Size(543, 160)
        Me.grpEditedSettings.TabIndex = 32
        Me.grpEditedSettings.TabStop = False
        Me.grpEditedSettings.Visible = False
        '
        'btnReTestSettings
        '
        Me.btnReTestSettings.Location = New System.Drawing.Point(411, 15)
        Me.btnReTestSettings.Name = "btnReTestSettings"
        Me.btnReTestSettings.Size = New System.Drawing.Size(124, 28)
        Me.btnReTestSettings.TabIndex = 31
        Me.btnReTestSettings.Text = "&Re-Test Settings"
        Me.btnReTestSettings.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(474, 15)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(60, 28)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "&Edit"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cboEditedSendingConnectionSecurity)
        Me.GroupBox3.Controls.Add(Me.cboEditedReceivingConnectionSecurity)
        Me.GroupBox3.Location = New System.Drawing.Point(411, 60)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(121, 78)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Server Security"
        '
        'cboEditedSendingConnectionSecurity
        '
        Me.cboEditedSendingConnectionSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEditedSendingConnectionSecurity.FormattingEnabled = True
        Me.cboEditedSendingConnectionSecurity.Items.AddRange(New Object() {"None", "SSL"})
        Me.cboEditedSendingConnectionSecurity.Location = New System.Drawing.Point(15, 48)
        Me.cboEditedSendingConnectionSecurity.Name = "cboEditedSendingConnectionSecurity"
        Me.cboEditedSendingConnectionSecurity.Size = New System.Drawing.Size(89, 24)
        Me.cboEditedSendingConnectionSecurity.TabIndex = 17
        '
        'cboEditedReceivingConnectionSecurity
        '
        Me.cboEditedReceivingConnectionSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEditedReceivingConnectionSecurity.FormattingEnabled = True
        Me.cboEditedReceivingConnectionSecurity.Items.AddRange(New Object() {"None", "SSL"})
        Me.cboEditedReceivingConnectionSecurity.Location = New System.Drawing.Point(15, 20)
        Me.cboEditedReceivingConnectionSecurity.Name = "cboEditedReceivingConnectionSecurity"
        Me.cboEditedReceivingConnectionSecurity.Size = New System.Drawing.Size(89, 24)
        Me.cboEditedReceivingConnectionSecurity.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(47, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 16)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Username: "
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(376, 111)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 16)
        Me.Label10.TabIndex = 19
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(47, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 16)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Sending:"
        '
        'pbEditedSendingStatus
        '
        Me.pbEditedSendingStatus.Location = New System.Drawing.Point(13, 111)
        Me.pbEditedSendingStatus.Name = "pbEditedSendingStatus"
        Me.pbEditedSendingStatus.Size = New System.Drawing.Size(16, 16)
        Me.pbEditedSendingStatus.TabIndex = 16
        Me.pbEditedSendingStatus.TabStop = False
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(376, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(0, 16)
        Me.Label13.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(47, 83)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 16)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Receiving:"
        '
        'pbEditedReceivingStatus
        '
        Me.pbEditedReceivingStatus.Location = New System.Drawing.Point(13, 83)
        Me.pbEditedReceivingStatus.Name = "pbEditedReceivingStatus"
        Me.pbEditedReceivingStatus.Size = New System.Drawing.Size(16, 16)
        Me.pbEditedReceivingStatus.TabIndex = 2
        Me.pbEditedReceivingStatus.TabStop = False
        '
        'lblEditedSearchingTitle
        '
        Me.lblEditedSearchingTitle.AutoSize = True
        Me.lblEditedSearchingTitle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditedSearchingTitle.Location = New System.Drawing.Point(47, 19)
        Me.lblEditedSearchingTitle.Name = "lblEditedSearchingTitle"
        Me.lblEditedSearchingTitle.Size = New System.Drawing.Size(159, 18)
        Me.lblEditedSearchingTitle.TabIndex = 1
        Me.lblEditedSearchingTitle.Text = "Custom Configuration"
        '
        'pbEditedWorking
        '
        Me.pbEditedWorking.Image = CType(resources.GetObject("pbEditedWorking.Image"), System.Drawing.Image)
        Me.pbEditedWorking.Location = New System.Drawing.Point(7, 12)
        Me.pbEditedWorking.Name = "pbEditedWorking"
        Me.pbEditedWorking.Size = New System.Drawing.Size(34, 34)
        Me.pbEditedWorking.TabIndex = 0
        Me.pbEditedWorking.TabStop = False
        Me.pbEditedWorking.Visible = False
        '
        'bgwTryAutoConfig
        '
        Me.bgwTryAutoConfig.WorkerSupportsCancellation = True
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPalette = Me.KryptonPalette1
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.pnlSearchButtons)
        Me.KryptonPanel.Controls.Add(Me.pnlCreateAccountButtons)
        Me.KryptonPanel.Controls.Add(Me.GroupBox1)
        Me.KryptonPanel.Controls.Add(Me.grpServerSettings)
        Me.KryptonPanel.Controls.Add(Me.grpEditedSettings)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(573, 360)
        Me.KryptonPanel.TabIndex = 33
        '
        'AddEmailGuide
        '
        Me.AcceptButton = Me.btnContinue
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(573, 360)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "AddEmailGuide"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Email Account"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpServerSettings.ResumeLayout(False)
        Me.grpServerSettings.PerformLayout()
        Me.grpServerSecurity.ResumeLayout(False)
        Me.grpServerSecurity.PerformLayout()
        CType(Me.pbReceivingLoginSecurity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSendingStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbReceivingStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbWorking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearchButtons.ResumeLayout(False)
        Me.pnlCreateAccountButtons.ResumeLayout(False)
        Me.grpEditedSettings.ResumeLayout(False)
        Me.grpEditedSettings.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.pbEditedSendingStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEditedReceivingStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEditedWorking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grpServerSettings As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents chkRememberPassword As System.Windows.Forms.CheckBox
    Friend WithEvents llblWhyAskForPassword As System.Windows.Forms.LinkLabel
    Friend WithEvents lblEmailFormat As System.Windows.Forms.Label
    Friend WithEvents pnlSearchButtons As System.Windows.Forms.Panel
    Friend WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents bgwGetDomainConfigs As System.ComponentModel.BackgroundWorker
    Friend WithEvents llblStartOver As System.Windows.Forms.LinkLabel
    Friend WithEvents pnlCreateAccountButtons As System.Windows.Forms.Panel
    Friend WithEvents btnManualSetup As System.Windows.Forms.Button
    Friend WithEvents btnCreateAccount As System.Windows.Forms.Button
    Friend WithEvents btnCancel2 As System.Windows.Forms.Button
    Friend WithEvents pbWorking As System.Windows.Forms.PictureBox
    Friend WithEvents lblSearchingTitle As System.Windows.Forms.Label
    Friend WithEvents lblSendingConnectionEncryption As System.Windows.Forms.Label
    Friend WithEvents lblSendingServerPort As System.Windows.Forms.Label
    Friend WithEvents lblSendingServerAddress As System.Windows.Forms.Label
    Friend WithEvents lblSendingCaption As System.Windows.Forms.Label
    Friend WithEvents pbSendingStatus As System.Windows.Forms.PictureBox
    Friend WithEvents pbReceivingLoginSecurity As System.Windows.Forms.PictureBox
    Friend WithEvents lblReceivingConnectionEncryption As System.Windows.Forms.Label
    Friend WithEvents lblReceivingServerPort As System.Windows.Forms.Label
    Friend WithEvents lblReceivingServerAddress As System.Windows.Forms.Label
    Friend WithEvents lblReceivingCaption As System.Windows.Forms.Label
    Friend WithEvents pbReceivingStatus As System.Windows.Forms.PictureBox
    Friend WithEvents lblUsernameCaption As System.Windows.Forms.Label
    Friend WithEvents grpServerSecurity As System.Windows.Forms.GroupBox
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents bgwTestConfigs As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnEditSettings As System.Windows.Forms.Button
    Friend WithEvents txtEditedSendingServerAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtEditedReceivingServerAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtEditedUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblEditedPortCaption As System.Windows.Forms.Label
    Friend WithEvents txtEditedSendingPort As System.Windows.Forms.TextBox
    Friend WithEvents txtEditedReceivingPort As System.Windows.Forms.TextBox
    Friend WithEvents grpEditedSettings As System.Windows.Forms.GroupBox
    Friend WithEvents btnReTestSettings As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents pbEditedSendingStatus As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pbEditedReceivingStatus As System.Windows.Forms.PictureBox
    Friend WithEvents lblEditedSearchingTitle As System.Windows.Forms.Label
    Friend WithEvents pbEditedWorking As System.Windows.Forms.PictureBox
    Friend WithEvents cboEditedSendingConnectionSecurity As System.Windows.Forms.ComboBox
    Friend WithEvents cboEditedReceivingConnectionSecurity As System.Windows.Forms.ComboBox
    Friend WithEvents bgwTryAutoConfig As System.ComponentModel.BackgroundWorker
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
End Class
