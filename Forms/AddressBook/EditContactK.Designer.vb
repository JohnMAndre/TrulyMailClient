<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditContactK
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditContactK))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkbtnNotes = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.chkbtnOther = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.chkbtnSettings = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.chkbtnPicture = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.chkbtnReminders = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.chkbtnEmail = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.btnDelete = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSave = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.pbContctType = New System.Windows.Forms.PictureBox()
        Me.txtTags = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtEmailAddress = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtFullName = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.lblDateAdded = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblEmailAddress = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.pnlEmail = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtWebMessagePassword = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtWebMessageQuestion = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.cboSMTPAccount = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel22 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel21 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.chkAutoRequestReturnReceipt = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonLabel27 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblAutoSendReturnReceipts = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cboAutoSendReturnReceipts = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.pnlReminder = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonGroupBox2 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.btnEditLastSent = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnClearLastSent = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblLastSentDate = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblLastMessageSent = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.nudReminderSent = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.dtpLastMessageSent = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel17 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel18 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel19 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonGroupBox1 = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.btnEditLastReceived = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnClearLastReceived = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblLastReceivedDate = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblLastMessageReceived = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.nudReminderReceived = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.dtpLastMessageReceived = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonLabel16 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel15 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel20 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.pnlPicture = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnRefreshPictureFromWeb = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnChangePicture = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnLoadGravitar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtPictureURL = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.cboBuiltInPicture = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.rdoContactPictureGravitar = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.rdoContactPictureWeb = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.rdoContactPictureThisComputer = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.rdoContactPictureBuiltIn = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.rdoContactPictureNone = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.pbContactPicture = New System.Windows.Forms.PictureBox()
        Me.rdoContactPictureCurrent = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.pnlSettings = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.nudImportance = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.chkRemoteImages = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.chkReceiveOnly = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.chkBlocked = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.chkActive = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonLabel14 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.pnlNotes = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtNotes = New ComponentFactory.Krypton.Toolkit.KryptonRichTextBox()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.pnlOther = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtCustom4 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel13 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtCustom3 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtCustom2 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtCustom1 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtWorkPhone = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtMobilePhone = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtHomePhone = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txtWebPage = New ComponentFactory.Krypton.Toolkit.KryptonRichTextBox()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonCheckSet1 = New ComponentFactory.Krypton.Toolkit.KryptonCheckSet(Me.components)
        Me.KryptonTextBox3 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.rtbNotes = New ComponentFactory.Krypton.Toolkit.KryptonRichTextBox()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.pbContctType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEmail.SuspendLayout()
        CType(Me.cboSMTPAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAutoSendReturnReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlReminder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlReminder.SuspendLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox2.Panel.SuspendLayout()
        Me.KryptonGroupBox2.SuspendLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        CType(Me.pnlPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPicture.SuspendLayout()
        CType(Me.cboBuiltInPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbContactPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSettings.SuspendLayout()
        CType(Me.pnlNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNotes.SuspendLayout()
        CType(Me.pnlOther, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOther.SuspendLayout()
        CType(Me.KryptonCheckSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.chkbtnNotes)
        Me.KryptonPanel.Controls.Add(Me.chkbtnOther)
        Me.KryptonPanel.Controls.Add(Me.chkbtnSettings)
        Me.KryptonPanel.Controls.Add(Me.chkbtnPicture)
        Me.KryptonPanel.Controls.Add(Me.chkbtnReminders)
        Me.KryptonPanel.Controls.Add(Me.chkbtnEmail)
        Me.KryptonPanel.Controls.Add(Me.btnDelete)
        Me.KryptonPanel.Controls.Add(Me.btnSave)
        Me.KryptonPanel.Controls.Add(Me.pbContctType)
        Me.KryptonPanel.Controls.Add(Me.txtTags)
        Me.KryptonPanel.Controls.Add(Me.txtEmailAddress)
        Me.KryptonPanel.Controls.Add(Me.txtFullName)
        Me.KryptonPanel.Controls.Add(Me.lblDateAdded)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel.Controls.Add(Me.lblEmailAddress)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Controls.Add(Me.pnlEmail)
        Me.KryptonPanel.Controls.Add(Me.pnlReminder)
        Me.KryptonPanel.Controls.Add(Me.pnlPicture)
        Me.KryptonPanel.Controls.Add(Me.pnlSettings)
        Me.KryptonPanel.Controls.Add(Me.pnlNotes)
        Me.KryptonPanel.Controls.Add(Me.pnlOther)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(570, 411)
        Me.KryptonPanel.TabIndex = 0
        '
        'chkbtnNotes
        '
        Me.chkbtnNotes.Location = New System.Drawing.Point(414, 136)
        Me.chkbtnNotes.Name = "chkbtnNotes"
        Me.chkbtnNotes.Palette = Me.KryptonPalette1
        Me.chkbtnNotes.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkbtnNotes.Size = New System.Drawing.Size(77, 25)
        Me.chkbtnNotes.TabIndex = 16
        Me.chkbtnNotes.Values.Text = "Notes"
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'chkbtnOther
        '
        Me.chkbtnOther.Location = New System.Drawing.Point(337, 136)
        Me.chkbtnOther.Name = "chkbtnOther"
        Me.chkbtnOther.Palette = Me.KryptonPalette1
        Me.chkbtnOther.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkbtnOther.Size = New System.Drawing.Size(77, 25)
        Me.chkbtnOther.TabIndex = 14
        Me.chkbtnOther.Values.Text = "Other"
        '
        'chkbtnSettings
        '
        Me.chkbtnSettings.Location = New System.Drawing.Point(260, 136)
        Me.chkbtnSettings.Name = "chkbtnSettings"
        Me.chkbtnSettings.Palette = Me.KryptonPalette1
        Me.chkbtnSettings.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkbtnSettings.Size = New System.Drawing.Size(77, 25)
        Me.chkbtnSettings.TabIndex = 13
        Me.chkbtnSettings.Values.Text = "Settings"
        '
        'chkbtnPicture
        '
        Me.chkbtnPicture.Location = New System.Drawing.Point(183, 136)
        Me.chkbtnPicture.Name = "chkbtnPicture"
        Me.chkbtnPicture.Palette = Me.KryptonPalette1
        Me.chkbtnPicture.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkbtnPicture.Size = New System.Drawing.Size(77, 25)
        Me.chkbtnPicture.TabIndex = 12
        Me.chkbtnPicture.Values.Text = "Picture"
        '
        'chkbtnReminders
        '
        Me.chkbtnReminders.Location = New System.Drawing.Point(89, 136)
        Me.chkbtnReminders.Name = "chkbtnReminders"
        Me.chkbtnReminders.Palette = Me.KryptonPalette1
        Me.chkbtnReminders.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkbtnReminders.Size = New System.Drawing.Size(94, 25)
        Me.chkbtnReminders.TabIndex = 11
        Me.chkbtnReminders.Values.Text = "Reminders"
        '
        'chkbtnEmail
        '
        Me.chkbtnEmail.Checked = True
        Me.chkbtnEmail.Location = New System.Drawing.Point(12, 136)
        Me.chkbtnEmail.Name = "chkbtnEmail"
        Me.chkbtnEmail.Palette = Me.KryptonPalette1
        Me.chkbtnEmail.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkbtnEmail.Size = New System.Drawing.Size(77, 25)
        Me.chkbtnEmail.TabIndex = 10
        Me.chkbtnEmail.Values.Text = "Email"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDelete.Location = New System.Drawing.Point(140, 353)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Palette = Me.KryptonPalette1
        Me.btnDelete.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnDelete.Size = New System.Drawing.Size(114, 46)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Values.Image = Global.TrulyMail.My.Resources.Resources.Erase_32
        Me.btnDelete.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnDelete.Values.Text = "&Delete"
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSave.Location = New System.Drawing.Point(305, 353)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Palette = Me.KryptonPalette1
        Me.btnSave.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnSave.Size = New System.Drawing.Size(114, 46)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Values.Image = Global.TrulyMail.My.Resources.Resources.Savefile_32
        Me.btnSave.Values.Text = "&Save"
        '
        'pbContctType
        '
        Me.pbContctType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbContctType.Location = New System.Drawing.Point(504, 12)
        Me.pbContctType.Name = "pbContctType"
        Me.pbContctType.Size = New System.Drawing.Size(54, 46)
        Me.pbContctType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbContctType.TabIndex = 3
        Me.pbContctType.TabStop = False
        '
        'txtTags
        '
        Me.txtTags.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTags.Location = New System.Drawing.Point(155, 64)
        Me.txtTags.Name = "txtTags"
        Me.txtTags.Palette = Me.KryptonPalette1
        Me.txtTags.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtTags.Size = New System.Drawing.Size(403, 22)
        Me.txtTags.TabIndex = 7
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmailAddress.Location = New System.Drawing.Point(155, 38)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Palette = Me.KryptonPalette1
        Me.txtEmailAddress.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtEmailAddress.Size = New System.Drawing.Size(343, 22)
        Me.txtEmailAddress.TabIndex = 6
        '
        'txtFullName
        '
        Me.txtFullName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFullName.Location = New System.Drawing.Point(155, 12)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Palette = Me.KryptonPalette1
        Me.txtFullName.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtFullName.Size = New System.Drawing.Size(343, 22)
        Me.txtFullName.TabIndex = 5
        '
        'lblDateAdded
        '
        Me.lblDateAdded.Location = New System.Drawing.Point(155, 90)
        Me.lblDateAdded.Name = "lblDateAdded"
        Me.lblDateAdded.Palette = Me.KryptonPalette1
        Me.lblDateAdded.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.lblDateAdded.Size = New System.Drawing.Size(6, 2)
        Me.lblDateAdded.TabIndex = 4
        Me.lblDateAdded.Values.Text = ""
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(12, 90)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Palette = Me.KryptonPalette1
        Me.KryptonLabel4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel4.Size = New System.Drawing.Size(50, 19)
        Me.KryptonLabel4.TabIndex = 3
        Me.KryptonLabel4.Values.Text = "Added"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(12, 64)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Palette = Me.KryptonPalette1
        Me.KryptonLabel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel3.Size = New System.Drawing.Size(44, 19)
        Me.KryptonLabel3.TabIndex = 2
        Me.KryptonLabel3.Values.Text = "Tags:"
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(12, 38)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Palette = Me.KryptonPalette1
        Me.lblEmailAddress.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.lblEmailAddress.Size = New System.Drawing.Size(99, 19)
        Me.lblEmailAddress.TabIndex = 1
        Me.lblEmailAddress.Values.Text = "Email address:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(12, 12)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Palette = Me.KryptonPalette1
        Me.KryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel1.Size = New System.Drawing.Size(50, 19)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Name:"
        '
        'pnlEmail
        '
        Me.pnlEmail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEmail.Controls.Add(Me.txtWebMessagePassword)
        Me.pnlEmail.Controls.Add(Me.txtWebMessageQuestion)
        Me.pnlEmail.Controls.Add(Me.cboSMTPAccount)
        Me.pnlEmail.Controls.Add(Me.KryptonLabel22)
        Me.pnlEmail.Controls.Add(Me.KryptonLabel21)
        Me.pnlEmail.Controls.Add(Me.chkAutoRequestReturnReceipt)
        Me.pnlEmail.Controls.Add(Me.KryptonLabel27)
        Me.pnlEmail.Controls.Add(Me.lblAutoSendReturnReceipts)
        Me.pnlEmail.Controls.Add(Me.cboAutoSendReturnReceipts)
        Me.pnlEmail.Location = New System.Drawing.Point(4, 167)
        Me.pnlEmail.Name = "pnlEmail"
        Me.pnlEmail.Palette = Me.KryptonPalette1
        Me.pnlEmail.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.pnlEmail.Size = New System.Drawing.Size(563, 180)
        Me.pnlEmail.TabIndex = 21
        '
        'txtWebMessagePassword
        '
        Me.txtWebMessagePassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWebMessagePassword.Location = New System.Drawing.Point(191, 88)
        Me.txtWebMessagePassword.Name = "txtWebMessagePassword"
        Me.txtWebMessagePassword.Palette = Me.KryptonPalette1
        Me.txtWebMessagePassword.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtWebMessagePassword.Size = New System.Drawing.Size(364, 22)
        Me.txtWebMessagePassword.TabIndex = 50
        '
        'txtWebMessageQuestion
        '
        Me.txtWebMessageQuestion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWebMessageQuestion.Location = New System.Drawing.Point(191, 66)
        Me.txtWebMessageQuestion.Name = "txtWebMessageQuestion"
        Me.txtWebMessageQuestion.Palette = Me.KryptonPalette1
        Me.txtWebMessageQuestion.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtWebMessageQuestion.Size = New System.Drawing.Size(364, 22)
        Me.txtWebMessageQuestion.TabIndex = 49
        Me.txtWebMessageQuestion.Visible = False
        '
        'cboSMTPAccount
        '
        Me.cboSMTPAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSMTPAccount.DropDownWidth = 222
        Me.cboSMTPAccount.Items.AddRange(New Object() {"<Use default email account>"})
        Me.cboSMTPAccount.Location = New System.Drawing.Point(191, 110)
        Me.cboSMTPAccount.Name = "cboSMTPAccount"
        Me.cboSMTPAccount.Palette = Me.KryptonPalette1
        Me.cboSMTPAccount.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.cboSMTPAccount.Size = New System.Drawing.Size(363, 20)
        Me.cboSMTPAccount.TabIndex = 48
        '
        'KryptonLabel22
        '
        Me.KryptonLabel22.Location = New System.Drawing.Point(11, 111)
        Me.KryptonLabel22.Name = "KryptonLabel22"
        Me.KryptonLabel22.Palette = Me.KryptonPalette1
        Me.KryptonLabel22.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel22.Size = New System.Drawing.Size(158, 19)
        Me.KryptonLabel22.TabIndex = 47
        Me.KryptonLabel22.Values.Text = "Default sending account:"
        '
        'KryptonLabel21
        '
        Me.KryptonLabel21.Location = New System.Drawing.Point(11, 88)
        Me.KryptonLabel21.Name = "KryptonLabel21"
        Me.KryptonLabel21.Palette = Me.KryptonPalette1
        Me.KryptonLabel21.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel21.Size = New System.Drawing.Size(139, 19)
        Me.KryptonLabel21.TabIndex = 46
        Me.KryptonLabel21.Values.Text = "Encryption password:"
        '
        'chkAutoRequestReturnReceipt
        '
        Me.chkAutoRequestReturnReceipt.AutoSize = False
        Me.chkAutoRequestReturnReceipt.CheckPosition = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right
        Me.chkAutoRequestReturnReceipt.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkAutoRequestReturnReceipt.Location = New System.Drawing.Point(11, 38)
        Me.chkAutoRequestReturnReceipt.Name = "chkAutoRequestReturnReceipt"
        Me.chkAutoRequestReturnReceipt.Palette = Me.KryptonPalette1
        Me.chkAutoRequestReturnReceipt.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkAutoRequestReturnReceipt.Size = New System.Drawing.Size(192, 19)
        Me.chkAutoRequestReturnReceipt.TabIndex = 40
        Me.chkAutoRequestReturnReceipt.Text = "Auto-request return receipt:"
        Me.chkAutoRequestReturnReceipt.Values.Text = "Auto-request return receipt:"
        '
        'KryptonLabel27
        '
        Me.KryptonLabel27.Location = New System.Drawing.Point(11, 63)
        Me.KryptonLabel27.Name = "KryptonLabel27"
        Me.KryptonLabel27.Palette = Me.KryptonPalette1
        Me.KryptonLabel27.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel27.Size = New System.Drawing.Size(154, 19)
        Me.KryptonLabel27.TabIndex = 45
        Me.KryptonLabel27.Values.Text = "Web message question:"
        Me.KryptonLabel27.Visible = False
        '
        'lblAutoSendReturnReceipts
        '
        Me.lblAutoSendReturnReceipts.Location = New System.Drawing.Point(11, 12)
        Me.lblAutoSendReturnReceipts.Name = "lblAutoSendReturnReceipts"
        Me.lblAutoSendReturnReceipts.Palette = Me.KryptonPalette1
        Me.lblAutoSendReturnReceipts.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.lblAutoSendReturnReceipts.Size = New System.Drawing.Size(158, 19)
        Me.lblAutoSendReturnReceipts.TabIndex = 44
        Me.lblAutoSendReturnReceipts.Values.Text = "Auto-send return receipt:"
        '
        'cboAutoSendReturnReceipts
        '
        Me.cboAutoSendReturnReceipts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAutoSendReturnReceipts.DropDownWidth = 222
        Me.cboAutoSendReturnReceipts.Items.AddRange(New Object() {"Use Receiving Account Settings", "Always", "Never", "Forced"})
        Me.cboAutoSendReturnReceipts.Location = New System.Drawing.Point(191, 11)
        Me.cboAutoSendReturnReceipts.Name = "cboAutoSendReturnReceipts"
        Me.cboAutoSendReturnReceipts.Palette = Me.KryptonPalette1
        Me.cboAutoSendReturnReceipts.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.cboAutoSendReturnReceipts.Size = New System.Drawing.Size(222, 20)
        Me.cboAutoSendReturnReceipts.TabIndex = 39
        '
        'pnlReminder
        '
        Me.pnlReminder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlReminder.Controls.Add(Me.KryptonGroupBox2)
        Me.pnlReminder.Controls.Add(Me.KryptonGroupBox1)
        Me.pnlReminder.Controls.Add(Me.KryptonButton1)
        Me.pnlReminder.Location = New System.Drawing.Point(4, 167)
        Me.pnlReminder.Name = "pnlReminder"
        Me.pnlReminder.Palette = Me.KryptonPalette1
        Me.pnlReminder.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.pnlReminder.Size = New System.Drawing.Size(563, 180)
        Me.pnlReminder.TabIndex = 20
        '
        'KryptonGroupBox2
        '
        Me.KryptonGroupBox2.Location = New System.Drawing.Point(5, 91)
        Me.KryptonGroupBox2.Name = "KryptonGroupBox2"
        Me.KryptonGroupBox2.Palette = Me.KryptonPalette1
        Me.KryptonGroupBox2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        '
        'KryptonGroupBox2.Panel
        '
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.btnEditLastSent)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.btnClearLastSent)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.lblLastSentDate)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.lblLastMessageSent)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.nudReminderSent)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.dtpLastMessageSent)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.KryptonLabel17)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.KryptonLabel18)
        Me.KryptonGroupBox2.Panel.Controls.Add(Me.KryptonLabel19)
        Me.KryptonGroupBox2.Size = New System.Drawing.Size(555, 81)
        Me.KryptonGroupBox2.TabIndex = 43
        Me.KryptonGroupBox2.Text = "Sent"
        Me.KryptonGroupBox2.Values.Heading = "Sent"
        '
        'btnEditLastSent
        '
        Me.btnEditLastSent.Location = New System.Drawing.Point(493, 5)
        Me.btnEditLastSent.Name = "btnEditLastSent"
        Me.btnEditLastSent.Size = New System.Drawing.Size(23, 25)
        Me.btnEditLastSent.TabIndex = 17
        Me.btnEditLastSent.Values.Image = Global.TrulyMail.My.Resources.Resources.Editpencil_16
        Me.btnEditLastSent.Values.Text = ""
        '
        'btnClearLastSent
        '
        Me.btnClearLastSent.Location = New System.Drawing.Point(464, 5)
        Me.btnClearLastSent.Name = "btnClearLastSent"
        Me.btnClearLastSent.Size = New System.Drawing.Size(23, 25)
        Me.btnClearLastSent.TabIndex = 16
        Me.btnClearLastSent.Values.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.btnClearLastSent.Values.Text = ""
        '
        'lblLastSentDate
        '
        Me.lblLastSentDate.Location = New System.Drawing.Point(233, 6)
        Me.lblLastSentDate.Name = "lblLastSentDate"
        Me.lblLastSentDate.Palette = Me.KryptonPalette1
        Me.lblLastSentDate.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.lblLastSentDate.Size = New System.Drawing.Size(183, 19)
        Me.lblLastSentDate.TabIndex = 14
        Me.lblLastSentDate.Values.Text = "No messages sent to contact"
        '
        'lblLastMessageSent
        '
        Me.lblLastMessageSent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastMessageSent.Location = New System.Drawing.Point(385, 33)
        Me.lblLastMessageSent.Name = "lblLastMessageSent"
        Me.lblLastMessageSent.Palette = Me.KryptonPalette1
        Me.lblLastMessageSent.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.lblLastMessageSent.Size = New System.Drawing.Size(163, 19)
        Me.lblLastMessageSent.TabIndex = 11
        Me.lblLastMessageSent.Values.Text = "Message sent 0 days ago"
        '
        'nudReminderSent
        '
        Me.nudReminderSent.Location = New System.Drawing.Point(232, 30)
        Me.nudReminderSent.Name = "nudReminderSent"
        Me.nudReminderSent.Size = New System.Drawing.Size(54, 22)
        Me.nudReminderSent.TabIndex = 9
        Me.nudReminderSent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpLastMessageSent
        '
        Me.dtpLastMessageSent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpLastMessageSent.CalendarTodayDate = New Date(2012, 5, 5, 0, 0, 0, 0)
        Me.dtpLastMessageSent.Location = New System.Drawing.Point(232, 5)
        Me.dtpLastMessageSent.Name = "dtpLastMessageSent"
        Me.dtpLastMessageSent.Size = New System.Drawing.Size(315, 21)
        Me.dtpLastMessageSent.TabIndex = 8
        Me.dtpLastMessageSent.Visible = False
        '
        'KryptonLabel17
        '
        Me.KryptonLabel17.Location = New System.Drawing.Point(4, 32)
        Me.KryptonLabel17.Name = "KryptonLabel17"
        Me.KryptonLabel17.Palette = Me.KryptonPalette1
        Me.KryptonLabel17.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel17.Size = New System.Drawing.Size(205, 19)
        Me.KryptonLabel17.TabIndex = 7
        Me.KryptonLabel17.Values.Text = "Remind me if nothing sent in last "
        '
        'KryptonLabel18
        '
        Me.KryptonLabel18.Location = New System.Drawing.Point(4, 6)
        Me.KryptonLabel18.Name = "KryptonLabel18"
        Me.KryptonLabel18.Palette = Me.KryptonPalette1
        Me.KryptonLabel18.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel18.Size = New System.Drawing.Size(189, 19)
        Me.KryptonLabel18.TabIndex = 6
        Me.KryptonLabel18.Values.Text = "Last message sent to contact:"
        '
        'KryptonLabel19
        '
        Me.KryptonLabel19.Location = New System.Drawing.Point(283, 32)
        Me.KryptonLabel19.Name = "KryptonLabel19"
        Me.KryptonLabel19.Palette = Me.KryptonPalette1
        Me.KryptonLabel19.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel19.Size = New System.Drawing.Size(39, 19)
        Me.KryptonLabel19.TabIndex = 10
        Me.KryptonLabel19.Values.Text = "days"
        '
        'KryptonGroupBox1
        '
        Me.KryptonGroupBox1.Location = New System.Drawing.Point(5, 4)
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        Me.KryptonGroupBox1.Palette = Me.KryptonPalette1
        Me.KryptonGroupBox1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnEditLastReceived)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.btnClearLastReceived)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblLastReceivedDate)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.lblLastMessageReceived)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.nudReminderReceived)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.dtpLastMessageReceived)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel16)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel15)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonLabel20)
        Me.KryptonGroupBox1.Size = New System.Drawing.Size(555, 81)
        Me.KryptonGroupBox1.TabIndex = 42
        Me.KryptonGroupBox1.Text = "Received"
        Me.KryptonGroupBox1.Values.Heading = "Received"
        '
        'btnEditLastReceived
        '
        Me.btnEditLastReceived.Location = New System.Drawing.Point(493, 2)
        Me.btnEditLastReceived.Name = "btnEditLastReceived"
        Me.btnEditLastReceived.Size = New System.Drawing.Size(23, 25)
        Me.btnEditLastReceived.TabIndex = 15
        Me.btnEditLastReceived.Values.Image = Global.TrulyMail.My.Resources.Resources.Editpencil_16
        Me.btnEditLastReceived.Values.Text = ""
        '
        'btnClearLastReceived
        '
        Me.btnClearLastReceived.Location = New System.Drawing.Point(464, 2)
        Me.btnClearLastReceived.Name = "btnClearLastReceived"
        Me.btnClearLastReceived.Size = New System.Drawing.Size(23, 25)
        Me.btnClearLastReceived.TabIndex = 14
        Me.btnClearLastReceived.Values.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.btnClearLastReceived.Values.Text = ""
        '
        'lblLastReceivedDate
        '
        Me.lblLastReceivedDate.Location = New System.Drawing.Point(233, 4)
        Me.lblLastReceivedDate.Name = "lblLastReceivedDate"
        Me.lblLastReceivedDate.Palette = Me.KryptonPalette1
        Me.lblLastReceivedDate.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.lblLastReceivedDate.Size = New System.Drawing.Size(224, 19)
        Me.lblLastReceivedDate.TabIndex = 13
        Me.lblLastReceivedDate.Values.Text = "No messages received from contact"
        '
        'lblLastMessageReceived
        '
        Me.lblLastMessageReceived.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastMessageReceived.Location = New System.Drawing.Point(359, 29)
        Me.lblLastMessageReceived.Name = "lblLastMessageReceived"
        Me.lblLastMessageReceived.Palette = Me.KryptonPalette1
        Me.lblLastMessageReceived.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.lblLastMessageReceived.Size = New System.Drawing.Size(189, 19)
        Me.lblLastMessageReceived.TabIndex = 12
        Me.lblLastMessageReceived.Values.Text = "Message received 0 days ago"
        '
        'nudReminderReceived
        '
        Me.nudReminderReceived.Location = New System.Drawing.Point(232, 28)
        Me.nudReminderReceived.Name = "nudReminderReceived"
        Me.nudReminderReceived.Size = New System.Drawing.Size(54, 22)
        Me.nudReminderReceived.TabIndex = 7
        Me.nudReminderReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpLastMessageReceived
        '
        Me.dtpLastMessageReceived.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpLastMessageReceived.CalendarTodayDate = New Date(2012, 5, 5, 0, 0, 0, 0)
        Me.dtpLastMessageReceived.Location = New System.Drawing.Point(232, 3)
        Me.dtpLastMessageReceived.Name = "dtpLastMessageReceived"
        Me.dtpLastMessageReceived.Size = New System.Drawing.Size(315, 21)
        Me.dtpLastMessageReceived.TabIndex = 6
        Me.dtpLastMessageReceived.Visible = False
        '
        'KryptonLabel16
        '
        Me.KryptonLabel16.Location = New System.Drawing.Point(4, 29)
        Me.KryptonLabel16.Name = "KryptonLabel16"
        Me.KryptonLabel16.Palette = Me.KryptonPalette1
        Me.KryptonLabel16.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel16.Size = New System.Drawing.Size(230, 19)
        Me.KryptonLabel16.TabIndex = 5
        Me.KryptonLabel16.Values.Text = "Remind me if nothing received in last "
        '
        'KryptonLabel15
        '
        Me.KryptonLabel15.Location = New System.Drawing.Point(4, 4)
        Me.KryptonLabel15.Name = "KryptonLabel15"
        Me.KryptonLabel15.Palette = Me.KryptonPalette1
        Me.KryptonLabel15.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel15.Size = New System.Drawing.Size(230, 19)
        Me.KryptonLabel15.TabIndex = 4
        Me.KryptonLabel15.Values.Text = "Last message received from contact:"
        '
        'KryptonLabel20
        '
        Me.KryptonLabel20.Location = New System.Drawing.Point(283, 30)
        Me.KryptonLabel20.Name = "KryptonLabel20"
        Me.KryptonLabel20.Palette = Me.KryptonPalette1
        Me.KryptonLabel20.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel20.Size = New System.Drawing.Size(39, 19)
        Me.KryptonLabel20.TabIndex = 11
        Me.KryptonLabel20.Values.Text = "days"
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Location = New System.Drawing.Point(513, 111)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Palette = Me.KryptonPalette1
        Me.KryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonButton1.Size = New System.Drawing.Size(29, 23)
        Me.KryptonButton1.TabIndex = 41
        Me.KryptonButton1.Values.Image = Global.TrulyMail.My.Resources.Resources.Refresh_16
        Me.KryptonButton1.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.KryptonButton1.Values.Text = ""
        '
        'pnlPicture
        '
        Me.pnlPicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPicture.Controls.Add(Me.btnRefreshPictureFromWeb)
        Me.pnlPicture.Controls.Add(Me.btnChangePicture)
        Me.pnlPicture.Controls.Add(Me.btnLoadGravitar)
        Me.pnlPicture.Controls.Add(Me.txtPictureURL)
        Me.pnlPicture.Controls.Add(Me.cboBuiltInPicture)
        Me.pnlPicture.Controls.Add(Me.rdoContactPictureGravitar)
        Me.pnlPicture.Controls.Add(Me.rdoContactPictureWeb)
        Me.pnlPicture.Controls.Add(Me.rdoContactPictureThisComputer)
        Me.pnlPicture.Controls.Add(Me.rdoContactPictureBuiltIn)
        Me.pnlPicture.Controls.Add(Me.rdoContactPictureNone)
        Me.pnlPicture.Controls.Add(Me.pbContactPicture)
        Me.pnlPicture.Controls.Add(Me.rdoContactPictureCurrent)
        Me.pnlPicture.Location = New System.Drawing.Point(4, 167)
        Me.pnlPicture.Name = "pnlPicture"
        Me.pnlPicture.Palette = Me.KryptonPalette1
        Me.pnlPicture.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.pnlPicture.Size = New System.Drawing.Size(563, 180)
        Me.pnlPicture.TabIndex = 19
        '
        'btnRefreshPictureFromWeb
        '
        Me.btnRefreshPictureFromWeb.Location = New System.Drawing.Point(525, 111)
        Me.btnRefreshPictureFromWeb.Name = "btnRefreshPictureFromWeb"
        Me.btnRefreshPictureFromWeb.Palette = Me.KryptonPalette1
        Me.btnRefreshPictureFromWeb.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnRefreshPictureFromWeb.Size = New System.Drawing.Size(29, 23)
        Me.btnRefreshPictureFromWeb.TabIndex = 41
        Me.btnRefreshPictureFromWeb.Values.Image = Global.TrulyMail.My.Resources.Resources.Refresh_16
        Me.btnRefreshPictureFromWeb.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnRefreshPictureFromWeb.Values.Text = ""
        '
        'btnChangePicture
        '
        Me.btnChangePicture.Location = New System.Drawing.Point(372, 84)
        Me.btnChangePicture.Name = "btnChangePicture"
        Me.btnChangePicture.Palette = Me.KryptonPalette1
        Me.btnChangePicture.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnChangePicture.Size = New System.Drawing.Size(90, 25)
        Me.btnChangePicture.TabIndex = 40
        Me.btnChangePicture.Values.Text = "&Browse"
        '
        'btnLoadGravitar
        '
        Me.btnLoadGravitar.Location = New System.Drawing.Point(372, 137)
        Me.btnLoadGravitar.Name = "btnLoadGravitar"
        Me.btnLoadGravitar.Palette = Me.KryptonPalette1
        Me.btnLoadGravitar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnLoadGravitar.Size = New System.Drawing.Size(90, 25)
        Me.btnLoadGravitar.TabIndex = 39
        Me.btnLoadGravitar.Values.Text = "&Load"
        '
        'txtPictureURL
        '
        Me.txtPictureURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPictureURL.Location = New System.Drawing.Point(321, 113)
        Me.txtPictureURL.Name = "txtPictureURL"
        Me.txtPictureURL.Palette = Me.KryptonPalette1
        Me.txtPictureURL.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtPictureURL.Size = New System.Drawing.Size(202, 22)
        Me.txtPictureURL.TabIndex = 20
        '
        'cboBuiltInPicture
        '
        Me.cboBuiltInPicture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBuiltInPicture.DropDownWidth = 222
        Me.cboBuiltInPicture.Items.AddRange(New Object() {"Standard female", "Standard male"})
        Me.cboBuiltInPicture.Location = New System.Drawing.Point(321, 61)
        Me.cboBuiltInPicture.Name = "cboBuiltInPicture"
        Me.cboBuiltInPicture.Palette = Me.KryptonPalette1
        Me.cboBuiltInPicture.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.cboBuiltInPicture.Size = New System.Drawing.Size(222, 20)
        Me.cboBuiltInPicture.TabIndex = 38
        '
        'rdoContactPictureGravitar
        '
        Me.rdoContactPictureGravitar.Location = New System.Drawing.Point(168, 138)
        Me.rdoContactPictureGravitar.Name = "rdoContactPictureGravitar"
        Me.rdoContactPictureGravitar.Palette = Me.KryptonPalette1
        Me.rdoContactPictureGravitar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.rdoContactPictureGravitar.Size = New System.Drawing.Size(105, 19)
        Me.rdoContactPictureGravitar.TabIndex = 37
        Me.rdoContactPictureGravitar.Values.Text = "From Gravitar"
        '
        'rdoContactPictureWeb
        '
        Me.rdoContactPictureWeb.Location = New System.Drawing.Point(168, 113)
        Me.rdoContactPictureWeb.Name = "rdoContactPictureWeb"
        Me.rdoContactPictureWeb.Palette = Me.KryptonPalette1
        Me.rdoContactPictureWeb.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.rdoContactPictureWeb.Size = New System.Drawing.Size(105, 19)
        Me.rdoContactPictureWeb.TabIndex = 36
        Me.rdoContactPictureWeb.Values.Text = "From the web"
        '
        'rdoContactPictureThisComputer
        '
        Me.rdoContactPictureThisComputer.Location = New System.Drawing.Point(168, 88)
        Me.rdoContactPictureThisComputer.Name = "rdoContactPictureThisComputer"
        Me.rdoContactPictureThisComputer.Palette = Me.KryptonPalette1
        Me.rdoContactPictureThisComputer.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.rdoContactPictureThisComputer.Size = New System.Drawing.Size(138, 19)
        Me.rdoContactPictureThisComputer.TabIndex = 35
        Me.rdoContactPictureThisComputer.Values.Text = "From this computer"
        '
        'rdoContactPictureBuiltIn
        '
        Me.rdoContactPictureBuiltIn.Location = New System.Drawing.Point(168, 63)
        Me.rdoContactPictureBuiltIn.Name = "rdoContactPictureBuiltIn"
        Me.rdoContactPictureBuiltIn.Palette = Me.KryptonPalette1
        Me.rdoContactPictureBuiltIn.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.rdoContactPictureBuiltIn.Size = New System.Drawing.Size(108, 19)
        Me.rdoContactPictureBuiltIn.TabIndex = 34
        Me.rdoContactPictureBuiltIn.Values.Text = "Built-in picture"
        '
        'rdoContactPictureNone
        '
        Me.rdoContactPictureNone.Location = New System.Drawing.Point(168, 38)
        Me.rdoContactPictureNone.Name = "rdoContactPictureNone"
        Me.rdoContactPictureNone.Palette = Me.KryptonPalette1
        Me.rdoContactPictureNone.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.rdoContactPictureNone.Size = New System.Drawing.Size(84, 19)
        Me.rdoContactPictureNone.TabIndex = 33
        Me.rdoContactPictureNone.Values.Text = "No picture"
        '
        'pbContactPicture
        '
        Me.pbContactPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbContactPicture.Location = New System.Drawing.Point(9, 4)
        Me.pbContactPicture.Name = "pbContactPicture"
        Me.pbContactPicture.Size = New System.Drawing.Size(140, 140)
        Me.pbContactPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbContactPicture.TabIndex = 32
        Me.pbContactPicture.TabStop = False
        '
        'rdoContactPictureCurrent
        '
        Me.rdoContactPictureCurrent.Location = New System.Drawing.Point(168, 12)
        Me.rdoContactPictureCurrent.Name = "rdoContactPictureCurrent"
        Me.rdoContactPictureCurrent.Palette = Me.KryptonPalette1
        Me.rdoContactPictureCurrent.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.rdoContactPictureCurrent.Size = New System.Drawing.Size(111, 19)
        Me.rdoContactPictureCurrent.TabIndex = 2
        Me.rdoContactPictureCurrent.Values.Text = "Current picture"
        '
        'pnlSettings
        '
        Me.pnlSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSettings.Controls.Add(Me.nudImportance)
        Me.pnlSettings.Controls.Add(Me.chkRemoteImages)
        Me.pnlSettings.Controls.Add(Me.chkReceiveOnly)
        Me.pnlSettings.Controls.Add(Me.chkBlocked)
        Me.pnlSettings.Controls.Add(Me.chkActive)
        Me.pnlSettings.Controls.Add(Me.KryptonLabel14)
        Me.pnlSettings.Location = New System.Drawing.Point(4, 167)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Palette = Me.KryptonPalette1
        Me.pnlSettings.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.pnlSettings.Size = New System.Drawing.Size(563, 180)
        Me.pnlSettings.TabIndex = 18
        '
        'nudImportance
        '
        Me.nudImportance.Location = New System.Drawing.Point(293, 122)
        Me.nudImportance.Name = "nudImportance"
        Me.nudImportance.Palette = Me.KryptonPalette1
        Me.nudImportance.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.nudImportance.Size = New System.Drawing.Size(59, 21)
        Me.nudImportance.TabIndex = 6
        Me.nudImportance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkRemoteImages
        '
        Me.chkRemoteImages.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkRemoteImages.Location = New System.Drawing.Point(11, 88)
        Me.chkRemoteImages.Name = "chkRemoteImages"
        Me.chkRemoteImages.Palette = Me.KryptonPalette1
        Me.chkRemoteImages.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkRemoteImages.Size = New System.Drawing.Size(513, 19)
        Me.chkRemoteImages.TabIndex = 5
        Me.chkRemoteImages.Text = "Show Remote Images (do not block remote images in messages from this contact)"
        Me.chkRemoteImages.Values.Text = "Show Remote Images (do not block remote images in messages from this contact)"
        '
        'chkReceiveOnly
        '
        Me.chkReceiveOnly.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkReceiveOnly.Location = New System.Drawing.Point(11, 63)
        Me.chkReceiveOnly.Name = "chkReceiveOnly"
        Me.chkReceiveOnly.Palette = Me.KryptonPalette1
        Me.chkReceiveOnly.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkReceiveOnly.Size = New System.Drawing.Size(365, 19)
        Me.chkReceiveOnly.TabIndex = 4
        Me.chkReceiveOnly.Text = "Receive Only (you cannot send messages to this contact)"
        Me.chkReceiveOnly.Values.Text = "Receive Only (you cannot send messages to this contact)"
        '
        'chkBlocked
        '
        Me.chkBlocked.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkBlocked.Location = New System.Drawing.Point(11, 38)
        Me.chkBlocked.Name = "chkBlocked"
        Me.chkBlocked.Palette = Me.KryptonPalette1
        Me.chkBlocked.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkBlocked.Size = New System.Drawing.Size(319, 19)
        Me.chkBlocked.TabIndex = 3
        Me.chkBlocked.Text = "Blocked (this contact cannot send you messages)"
        Me.chkBlocked.Values.Text = "Blocked (this contact cannot send you messages)"
        '
        'chkActive
        '
        Me.chkActive.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkActive.Location = New System.Drawing.Point(11, 13)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Palette = Me.KryptonPalette1
        Me.chkActive.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkActive.Size = New System.Drawing.Size(316, 19)
        Me.chkActive.TabIndex = 2
        Me.chkActive.Text = "Active (uncheck to permanently hide this contact)"
        Me.chkActive.Values.Text = "Active (uncheck to permanently hide this contact)"
        '
        'KryptonLabel14
        '
        Me.KryptonLabel14.Location = New System.Drawing.Point(11, 122)
        Me.KryptonLabel14.Name = "KryptonLabel14"
        Me.KryptonLabel14.Palette = Me.KryptonPalette1
        Me.KryptonLabel14.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel14.Size = New System.Drawing.Size(281, 19)
        Me.KryptonLabel14.TabIndex = 1
        Me.KryptonLabel14.Values.Text = "Importance (used when receiving messages):"
        '
        'pnlNotes
        '
        Me.pnlNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlNotes.Controls.Add(Me.txtNotes)
        Me.pnlNotes.Controls.Add(Me.KryptonLabel5)
        Me.pnlNotes.Location = New System.Drawing.Point(4, 167)
        Me.pnlNotes.Name = "pnlNotes"
        Me.pnlNotes.Palette = Me.KryptonPalette1
        Me.pnlNotes.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.pnlNotes.Size = New System.Drawing.Size(563, 180)
        Me.pnlNotes.TabIndex = 15
        '
        'txtNotes
        '
        Me.txtNotes.AcceptsTab = True
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(59, 3)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(501, 174)
        Me.txtNotes.TabIndex = 2
        Me.txtNotes.Text = ""
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(3, 3)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Palette = Me.KryptonPalette1
        Me.KryptonLabel5.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel5.Size = New System.Drawing.Size(50, 19)
        Me.KryptonLabel5.TabIndex = 1
        Me.KryptonLabel5.Values.Text = "Notes:"
        '
        'pnlOther
        '
        Me.pnlOther.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlOther.Controls.Add(Me.txtCustom4)
        Me.pnlOther.Controls.Add(Me.KryptonLabel13)
        Me.pnlOther.Controls.Add(Me.txtCustom3)
        Me.pnlOther.Controls.Add(Me.KryptonLabel12)
        Me.pnlOther.Controls.Add(Me.txtCustom2)
        Me.pnlOther.Controls.Add(Me.KryptonLabel11)
        Me.pnlOther.Controls.Add(Me.txtCustom1)
        Me.pnlOther.Controls.Add(Me.KryptonLabel10)
        Me.pnlOther.Controls.Add(Me.KryptonLabel9)
        Me.pnlOther.Controls.Add(Me.txtWorkPhone)
        Me.pnlOther.Controls.Add(Me.KryptonLabel8)
        Me.pnlOther.Controls.Add(Me.txtMobilePhone)
        Me.pnlOther.Controls.Add(Me.KryptonLabel7)
        Me.pnlOther.Controls.Add(Me.txtHomePhone)
        Me.pnlOther.Controls.Add(Me.txtWebPage)
        Me.pnlOther.Controls.Add(Me.KryptonLabel6)
        Me.pnlOther.Location = New System.Drawing.Point(4, 167)
        Me.pnlOther.Name = "pnlOther"
        Me.pnlOther.Palette = Me.KryptonPalette1
        Me.pnlOther.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.pnlOther.Size = New System.Drawing.Size(563, 180)
        Me.pnlOther.TabIndex = 17
        '
        'txtCustom4
        '
        Me.txtCustom4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustom4.Location = New System.Drawing.Point(81, 133)
        Me.txtCustom4.Name = "txtCustom4"
        Me.txtCustom4.Palette = Me.KryptonPalette1
        Me.txtCustom4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtCustom4.Size = New System.Drawing.Size(479, 22)
        Me.txtCustom4.TabIndex = 31
        '
        'KryptonLabel13
        '
        Me.KryptonLabel13.Location = New System.Drawing.Point(3, 133)
        Me.KryptonLabel13.Name = "KryptonLabel13"
        Me.KryptonLabel13.Palette = Me.KryptonPalette1
        Me.KryptonLabel13.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel13.Size = New System.Drawing.Size(72, 19)
        Me.KryptonLabel13.TabIndex = 30
        Me.KryptonLabel13.Values.Text = "Custom 4:"
        '
        'txtCustom3
        '
        Me.txtCustom3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustom3.Location = New System.Drawing.Point(81, 107)
        Me.txtCustom3.Name = "txtCustom3"
        Me.txtCustom3.Palette = Me.KryptonPalette1
        Me.txtCustom3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtCustom3.Size = New System.Drawing.Size(479, 22)
        Me.txtCustom3.TabIndex = 29
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Location = New System.Drawing.Point(3, 107)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Palette = Me.KryptonPalette1
        Me.KryptonLabel12.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel12.Size = New System.Drawing.Size(72, 19)
        Me.KryptonLabel12.TabIndex = 28
        Me.KryptonLabel12.Values.Text = "Custom 3:"
        '
        'txtCustom2
        '
        Me.txtCustom2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustom2.Location = New System.Drawing.Point(81, 81)
        Me.txtCustom2.Name = "txtCustom2"
        Me.txtCustom2.Palette = Me.KryptonPalette1
        Me.txtCustom2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtCustom2.Size = New System.Drawing.Size(479, 22)
        Me.txtCustom2.TabIndex = 27
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.Location = New System.Drawing.Point(3, 81)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Palette = Me.KryptonPalette1
        Me.KryptonLabel11.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel11.Size = New System.Drawing.Size(72, 19)
        Me.KryptonLabel11.TabIndex = 26
        Me.KryptonLabel11.Values.Text = "Custom 2:"
        '
        'txtCustom1
        '
        Me.txtCustom1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustom1.Location = New System.Drawing.Point(81, 55)
        Me.txtCustom1.Name = "txtCustom1"
        Me.txtCustom1.Palette = Me.KryptonPalette1
        Me.txtCustom1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtCustom1.Size = New System.Drawing.Size(479, 22)
        Me.txtCustom1.TabIndex = 25
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.Location = New System.Drawing.Point(3, 55)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Palette = Me.KryptonPalette1
        Me.KryptonLabel10.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel10.Size = New System.Drawing.Size(72, 19)
        Me.KryptonLabel10.TabIndex = 24
        Me.KryptonLabel10.Values.Text = "Custom 1:"
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Location = New System.Drawing.Point(250, 29)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Palette = Me.KryptonPalette1
        Me.KryptonLabel9.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel9.Size = New System.Drawing.Size(42, 19)
        Me.KryptonLabel9.TabIndex = 23
        Me.KryptonLabel9.Values.Text = "Web:"
        '
        'txtWorkPhone
        '
        Me.txtWorkPhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWorkPhone.Location = New System.Drawing.Point(298, 4)
        Me.txtWorkPhone.Name = "txtWorkPhone"
        Me.txtWorkPhone.Palette = Me.KryptonPalette1
        Me.txtWorkPhone.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtWorkPhone.Size = New System.Drawing.Size(262, 22)
        Me.txtWorkPhone.TabIndex = 22
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Location = New System.Drawing.Point(250, 3)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Palette = Me.KryptonPalette1
        Me.KryptonLabel8.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel8.Size = New System.Drawing.Size(46, 19)
        Me.KryptonLabel8.TabIndex = 21
        Me.KryptonLabel8.Values.Text = "Work:"
        '
        'txtMobilePhone
        '
        Me.txtMobilePhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMobilePhone.Location = New System.Drawing.Point(81, 29)
        Me.txtMobilePhone.Name = "txtMobilePhone"
        Me.txtMobilePhone.Palette = Me.KryptonPalette1
        Me.txtMobilePhone.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtMobilePhone.Size = New System.Drawing.Size(169, 22)
        Me.txtMobilePhone.TabIndex = 20
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Location = New System.Drawing.Point(3, 29)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Palette = Me.KryptonPalette1
        Me.KryptonLabel7.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel7.Size = New System.Drawing.Size(54, 19)
        Me.KryptonLabel7.TabIndex = 19
        Me.KryptonLabel7.Values.Text = "Mobile:"
        '
        'txtHomePhone
        '
        Me.txtHomePhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHomePhone.Location = New System.Drawing.Point(81, 3)
        Me.txtHomePhone.Name = "txtHomePhone"
        Me.txtHomePhone.Palette = Me.KryptonPalette1
        Me.txtHomePhone.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtHomePhone.Size = New System.Drawing.Size(169, 22)
        Me.txtHomePhone.TabIndex = 18
        '
        'txtWebPage
        '
        Me.txtWebPage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWebPage.Location = New System.Drawing.Point(298, 29)
        Me.txtWebPage.Name = "txtWebPage"
        Me.txtWebPage.Size = New System.Drawing.Size(262, 20)
        Me.txtWebPage.TabIndex = 2
        Me.txtWebPage.Text = ""
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(3, 3)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Palette = Me.KryptonPalette1
        Me.KryptonLabel6.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel6.Size = New System.Drawing.Size(50, 19)
        Me.KryptonLabel6.TabIndex = 1
        Me.KryptonLabel6.Values.Text = "Home:"
        '
        'KryptonCheckSet1
        '
        Me.KryptonCheckSet1.CheckButtons.Add(Me.chkbtnEmail)
        Me.KryptonCheckSet1.CheckButtons.Add(Me.chkbtnReminders)
        Me.KryptonCheckSet1.CheckButtons.Add(Me.chkbtnPicture)
        Me.KryptonCheckSet1.CheckButtons.Add(Me.chkbtnSettings)
        Me.KryptonCheckSet1.CheckButtons.Add(Me.chkbtnOther)
        Me.KryptonCheckSet1.CheckButtons.Add(Me.chkbtnNotes)
        Me.KryptonCheckSet1.CheckedButton = Me.chkbtnEmail
        '
        'KryptonTextBox3
        '
        Me.KryptonTextBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonTextBox3.Location = New System.Drawing.Point(155, 64)
        Me.KryptonTextBox3.Name = "KryptonTextBox3"
        Me.KryptonTextBox3.Palette = Me.KryptonPalette1
        Me.KryptonTextBox3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonTextBox3.Size = New System.Drawing.Size(403, 22)
        Me.KryptonTextBox3.TabIndex = 7
        '
        'rtbNotes
        '
        Me.rtbNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbNotes.Location = New System.Drawing.Point(59, 3)
        Me.rtbNotes.Name = "rtbNotes"
        Me.rtbNotes.Size = New System.Drawing.Size(501, 174)
        Me.rtbNotes.TabIndex = 2
        Me.rtbNotes.Text = ""
        '
        'EditContactK
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(570, 411)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "EditContactK"
        Me.Palette = Me.KryptonPalette1
        Me.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Contact"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.pbContctType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEmail.ResumeLayout(False)
        Me.pnlEmail.PerformLayout()
        CType(Me.cboSMTPAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAutoSendReturnReceipts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlReminder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlReminder.ResumeLayout(False)
        CType(Me.KryptonGroupBox2.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.Panel.ResumeLayout(False)
        Me.KryptonGroupBox2.Panel.PerformLayout()
        CType(Me.KryptonGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox2.ResumeLayout(False)
        CType(Me.KryptonGroupBox1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        Me.KryptonGroupBox1.Panel.PerformLayout()
        CType(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        CType(Me.pnlPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPicture.ResumeLayout(False)
        Me.pnlPicture.PerformLayout()
        CType(Me.cboBuiltInPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbContactPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        CType(Me.pnlNotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNotes.ResumeLayout(False)
        Me.pnlNotes.PerformLayout()
        CType(Me.pnlOther, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOther.ResumeLayout(False)
        Me.pnlOther.PerformLayout()
        CType(Me.KryptonCheckSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents txtTags As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtEmailAddress As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtFullName As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents lblDateAdded As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblEmailAddress As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents pbContctType As System.Windows.Forms.PictureBox
    Friend WithEvents btnDelete As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents chkbtnPicture As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents chkbtnReminders As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents chkbtnEmail As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonCheckSet1 As ComponentFactory.Krypton.Toolkit.KryptonCheckSet
    Friend WithEvents chkbtnOther As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents chkbtnSettings As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents pnlNotes As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents chkbtnNotes As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents pnlOther As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtWebPage As ComponentFactory.Krypton.Toolkit.KryptonRichTextBox
    Friend WithEvents txtHomePhone As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtMobilePhone As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtWorkPhone As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtCustom1 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtCustom4 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel13 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtCustom3 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtCustom2 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents pnlSettings As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonLabel14 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents chkRemoteImages As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkReceiveOnly As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkBlocked As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkActive As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents nudImportance As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents pnlPicture As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents rdoContactPictureCurrent As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rdoContactPictureWeb As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rdoContactPictureThisComputer As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rdoContactPictureBuiltIn As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rdoContactPictureNone As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents pbContactPicture As System.Windows.Forms.PictureBox
    Friend WithEvents rdoContactPictureGravitar As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents btnRefreshPictureFromWeb As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnChangePicture As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnLoadGravitar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtPictureURL As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents cboBuiltInPicture As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents pnlReminder As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonGroupBox2 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonGroupBox1 As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonLabel16 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel15 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel17 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel18 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtpLastMessageSent As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents dtpLastMessageReceived As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonLabel19 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents nudReminderSent As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents KryptonLabel20 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents nudReminderReceived As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents lblLastMessageSent As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblLastMessageReceived As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblLastReceivedDate As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblLastSentDate As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnClearLastReceived As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnEditLastReceived As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnEditLastSent As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnClearLastSent As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents pnlEmail As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents chkAutoRequestReturnReceipt As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents lblAutoSendReturnReceipts As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cboAutoSendReturnReceipts As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel27 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtWebMessagePassword As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txtWebMessageQuestion As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents cboSMTPAccount As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel22 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel21 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonTextBox3 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtNotes As ComponentFactory.Krypton.Toolkit.KryptonRichTextBox
    Friend WithEvents rtbNotes As ComponentFactory.Krypton.Toolkit.KryptonRichTextBox
End Class
