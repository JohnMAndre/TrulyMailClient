<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditContact
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditContact))
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbContctType = New System.Windows.Forms.PictureBox()
        Me.lblEmailAddress = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDateAdded = New System.Windows.Forms.Label()
        Me.chkAutoRequestReturnReceipt = New System.Windows.Forms.CheckBox()
        Me.cboAutoSendReturnReceipts = New System.Windows.Forms.ComboBox()
        Me.lblAutoSendReturnReceipts = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTags = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pbContactPicture = New System.Windows.Forms.PictureBox()
        Me.btnChangePicture = New System.Windows.Forms.Button()
        Me.nudReminderReceived = New System.Windows.Forms.NumericUpDown()
        Me.nudReminderSent = New System.Windows.Forms.NumericUpDown()
        Me.btnEditLastSent = New System.Windows.Forms.Button()
        Me.btnClearLastSent = New System.Windows.Forms.Button()
        Me.btnRefreshPictureFromWeb = New System.Windows.Forms.Button()
        Me.nudImportance = New System.Windows.Forms.NumericUpDown()
        Me.cboSMTPAccount = New System.Windows.Forms.ComboBox()
        Me.btnLoadGravitar = New System.Windows.Forms.Button()
        Me.btnEditLastReceived = New System.Windows.Forms.Button()
        Me.btnClearLastReceived = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblLastSentDate = New System.Windows.Forms.Label()
        Me.lblLastReceivedDate = New System.Windows.Forms.Label()
        Me.dtpLastMessageReceived = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpLastMessageSent = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblLastMessageReceived = New System.Windows.Forms.Label()
        Me.lblLastMessageSent = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabEmail = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtWebMessagePassword = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtWebMessageQuestion = New System.Windows.Forms.TextBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.rdoContactPictureGravitar = New System.Windows.Forms.RadioButton()
        Me.rdoContactPictureCurrent = New System.Windows.Forms.RadioButton()
        Me.txtPictureURL = New System.Windows.Forms.TextBox()
        Me.cboBuiltInPicture = New System.Windows.Forms.ComboBox()
        Me.rdoContactPictureNone = New System.Windows.Forms.RadioButton()
        Me.rdoContactPictureWeb = New System.Windows.Forms.RadioButton()
        Me.rdoContactPictureThisComputer = New System.Windows.Forms.RadioButton()
        Me.rdoContactPictureBuiltIn = New System.Windows.Forms.RadioButton()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkRemoteImages = New System.Windows.Forms.CheckBox()
        Me.chkBlocked = New System.Windows.Forms.CheckBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.chkReceiveOnly = New System.Windows.Forms.CheckBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtCustom4 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtWebPage = New System.Windows.Forms.RichTextBox()
        Me.txtCustom3 = New System.Windows.Forms.TextBox()
        Me.txtCustom2 = New System.Windows.Forms.TextBox()
        Me.txtCustom1 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtMobilePhone = New System.Windows.Forms.TextBox()
        Me.txtWorkPhone = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtHomePhone = New System.Windows.Forms.TextBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtNotes = New System.Windows.Forms.RichTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        CType(Me.pbContctType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbContactPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudReminderReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudReminderSent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudImportance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tabEmail.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFullName
        '
        Me.txtFullName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFullName.Location = New System.Drawing.Point(184, 10)
        Me.txtFullName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(335, 22)
        Me.txtFullName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name:"
        '
        'pbContctType
        '
        Me.pbContctType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbContctType.Location = New System.Drawing.Point(526, 10)
        Me.pbContctType.Name = "pbContctType"
        Me.pbContctType.Size = New System.Drawing.Size(32, 32)
        Me.pbContctType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbContctType.TabIndex = 2
        Me.pbContctType.TabStop = False
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.AutoSize = True
        Me.lblEmailAddress.Location = New System.Drawing.Point(13, 42)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(96, 16)
        Me.lblEmailAddress.TabIndex = 4
        Me.lblEmailAddress.Text = "Email Address:"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmailAddress.Location = New System.Drawing.Point(184, 39)
        Me.txtEmailAddress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(335, 22)
        Me.txtEmailAddress.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Date added:"
        '
        'lblDateAdded
        '
        Me.lblDateAdded.AutoSize = True
        Me.lblDateAdded.Location = New System.Drawing.Point(189, 100)
        Me.lblDateAdded.Name = "lblDateAdded"
        Me.lblDateAdded.Size = New System.Drawing.Size(0, 16)
        Me.lblDateAdded.TabIndex = 6
        '
        'chkAutoRequestReturnReceipt
        '
        Me.chkAutoRequestReturnReceipt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAutoRequestReturnReceipt.Location = New System.Drawing.Point(6, 66)
        Me.chkAutoRequestReturnReceipt.Name = "chkAutoRequestReturnReceipt"
        Me.chkAutoRequestReturnReceipt.Size = New System.Drawing.Size(224, 20)
        Me.chkAutoRequestReturnReceipt.TabIndex = 10
        Me.chkAutoRequestReturnReceipt.Text = "Auto-Request Return Receipt:"
        Me.chkAutoRequestReturnReceipt.UseVisualStyleBackColor = True
        '
        'cboAutoSendReturnReceipts
        '
        Me.cboAutoSendReturnReceipts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAutoSendReturnReceipts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAutoSendReturnReceipts.FormattingEnabled = True
        Me.cboAutoSendReturnReceipts.Items.AddRange(New Object() {"Use Receiving Account Settings", "Always", "Never"})
        Me.cboAutoSendReturnReceipts.Location = New System.Drawing.Point(214, 33)
        Me.cboAutoSendReturnReceipts.Name = "cboAutoSendReturnReceipts"
        Me.cboAutoSendReturnReceipts.Size = New System.Drawing.Size(308, 24)
        Me.cboAutoSendReturnReceipts.TabIndex = 11
        '
        'lblAutoSendReturnReceipts
        '
        Me.lblAutoSendReturnReceipts.AutoSize = True
        Me.lblAutoSendReturnReceipts.Location = New System.Drawing.Point(6, 36)
        Me.lblAutoSendReturnReceipts.Name = "lblAutoSendReturnReceipts"
        Me.lblAutoSendReturnReceipts.Size = New System.Drawing.Size(170, 16)
        Me.lblAutoSendReturnReceipts.TabIndex = 12
        Me.lblAutoSendReturnReceipts.Text = "Auto-Send Return Receipts:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Tags:"
        '
        'txtTags
        '
        Me.txtTags.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTags.Location = New System.Drawing.Point(184, 69)
        Me.txtTags.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTags.Name = "txtTags"
        Me.txtTags.Size = New System.Drawing.Size(335, 22)
        Me.txtTags.TabIndex = 13
        '
        'pbContactPicture
        '
        Me.pbContactPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbContactPicture.Location = New System.Drawing.Point(3, 19)
        Me.pbContactPicture.Name = "pbContactPicture"
        Me.pbContactPicture.Size = New System.Drawing.Size(140, 140)
        Me.pbContactPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbContactPicture.TabIndex = 31
        Me.pbContactPicture.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbContactPicture, "Contact picture")
        '
        'btnChangePicture
        '
        Me.btnChangePicture.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangePicture.Enabled = False
        Me.btnChangePicture.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangePicture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChangePicture.Location = New System.Drawing.Point(356, 101)
        Me.btnChangePicture.Name = "btnChangePicture"
        Me.btnChangePicture.Size = New System.Drawing.Size(94, 24)
        Me.btnChangePicture.TabIndex = 35
        Me.btnChangePicture.Text = "Browse"
        Me.ToolTip1.SetToolTip(Me.btnChangePicture, "Change picture for contact")
        Me.btnChangePicture.UseVisualStyleBackColor = True
        '
        'nudReminderReceived
        '
        Me.nudReminderReceived.Location = New System.Drawing.Point(232, 49)
        Me.nudReminderReceived.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.nudReminderReceived.Name = "nudReminderReceived"
        Me.nudReminderReceived.Size = New System.Drawing.Size(54, 22)
        Me.nudReminderReceived.TabIndex = 18
        Me.nudReminderReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.nudReminderReceived, "Set to zero (0) for no reminders")
        '
        'nudReminderSent
        '
        Me.nudReminderSent.Location = New System.Drawing.Point(232, 48)
        Me.nudReminderSent.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.nudReminderSent.Name = "nudReminderSent"
        Me.nudReminderSent.Size = New System.Drawing.Size(54, 22)
        Me.nudReminderSent.TabIndex = 27
        Me.nudReminderSent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.nudReminderSent, "Set to zero (0) for no reminders")
        '
        'btnEditLastSent
        '
        Me.btnEditLastSent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditLastSent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditLastSent.Image = Global.TrulyMail.My.Resources.Resources.Editpencil_16
        Me.btnEditLastSent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditLastSent.Location = New System.Drawing.Point(527, 14)
        Me.btnEditLastSent.Name = "btnEditLastSent"
        Me.btnEditLastSent.Size = New System.Drawing.Size(24, 24)
        Me.btnEditLastSent.TabIndex = 38
        Me.btnEditLastSent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEditLastSent, "Manually set the date of last message sent")
        Me.btnEditLastSent.UseVisualStyleBackColor = True
        '
        'btnClearLastSent
        '
        Me.btnClearLastSent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearLastSent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearLastSent.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.btnClearLastSent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearLastSent.Location = New System.Drawing.Point(497, 14)
        Me.btnClearLastSent.Name = "btnClearLastSent"
        Me.btnClearLastSent.Size = New System.Drawing.Size(24, 24)
        Me.btnClearLastSent.TabIndex = 40
        Me.btnClearLastSent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnClearLastSent, "Remove picture for contact")
        Me.btnClearLastSent.UseVisualStyleBackColor = True
        '
        'btnRefreshPictureFromWeb
        '
        Me.btnRefreshPictureFromWeb.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshPictureFromWeb.Enabled = False
        Me.btnRefreshPictureFromWeb.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshPictureFromWeb.Image = Global.TrulyMail.My.Resources.Resources.Refresh_16
        Me.btnRefreshPictureFromWeb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefreshPictureFromWeb.Location = New System.Drawing.Point(528, 127)
        Me.btnRefreshPictureFromWeb.Name = "btnRefreshPictureFromWeb"
        Me.btnRefreshPictureFromWeb.Size = New System.Drawing.Size(24, 24)
        Me.btnRefreshPictureFromWeb.TabIndex = 43
        Me.btnRefreshPictureFromWeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnRefreshPictureFromWeb, "Refresh from web")
        Me.btnRefreshPictureFromWeb.UseVisualStyleBackColor = True
        '
        'nudImportance
        '
        Me.nudImportance.Location = New System.Drawing.Point(306, 146)
        Me.nudImportance.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.nudImportance.Name = "nudImportance"
        Me.nudImportance.Size = New System.Drawing.Size(54, 22)
        Me.nudImportance.TabIndex = 26
        Me.nudImportance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.nudImportance, "Set to zero (0) for no reminders")
        '
        'cboSMTPAccount
        '
        Me.cboSMTPAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSMTPAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSMTPAccount.FormattingEnabled = True
        Me.cboSMTPAccount.Items.AddRange(New Object() {"<use default email account>"})
        Me.cboSMTPAccount.Location = New System.Drawing.Point(214, 155)
        Me.cboSMTPAccount.Name = "cboSMTPAccount"
        Me.cboSMTPAccount.Size = New System.Drawing.Size(308, 24)
        Me.cboSMTPAccount.TabIndex = 24
        Me.ToolTip1.SetToolTip(Me.cboSMTPAccount, "The 'From' drop down is only used for email recipients. TrulyMail Recipients are " & _
        "processed through the TrulyMail server")
        '
        'btnLoadGravitar
        '
        Me.btnLoadGravitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadGravitar.Enabled = False
        Me.btnLoadGravitar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadGravitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoadGravitar.Location = New System.Drawing.Point(354, 153)
        Me.btnLoadGravitar.Name = "btnLoadGravitar"
        Me.btnLoadGravitar.Size = New System.Drawing.Size(94, 24)
        Me.btnLoadGravitar.TabIndex = 45
        Me.btnLoadGravitar.Text = "&Load"
        Me.ToolTip1.SetToolTip(Me.btnLoadGravitar, "Change picture for contact")
        Me.btnLoadGravitar.UseVisualStyleBackColor = True
        '
        'btnEditLastReceived
        '
        Me.btnEditLastReceived.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditLastReceived.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditLastReceived.Image = Global.TrulyMail.My.Resources.Resources.Editpencil_16
        Me.btnEditLastReceived.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditLastReceived.Location = New System.Drawing.Point(527, 14)
        Me.btnEditLastReceived.Name = "btnEditLastReceived"
        Me.btnEditLastReceived.Size = New System.Drawing.Size(24, 24)
        Me.btnEditLastReceived.TabIndex = 37
        Me.btnEditLastReceived.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEditLastReceived, "Manually set the date of last message received")
        Me.btnEditLastReceived.UseVisualStyleBackColor = True
        '
        'btnClearLastReceived
        '
        Me.btnClearLastReceived.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearLastReceived.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearLastReceived.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.btnClearLastReceived.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearLastReceived.Location = New System.Drawing.Point(497, 14)
        Me.btnClearLastReceived.Name = "btnClearLastReceived"
        Me.btnClearLastReceived.Size = New System.Drawing.Size(24, 24)
        Me.btnClearLastReceived.TabIndex = 39
        Me.btnClearLastReceived.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnClearLastReceived, "Remove picture for contact")
        Me.btnClearLastReceived.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(183, 378)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(89, 42)
        Me.btnDelete.TabIndex = 15
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.Enabled = False
        Me.btnSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.TrulyMail.My.Resources.Resources.Savefile_32
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(297, 378)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(89, 42)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "&Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblLastSentDate
        '
        Me.lblLastSentDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastSentDate.Location = New System.Drawing.Point(235, 18)
        Me.lblLastSentDate.Name = "lblLastSentDate"
        Me.lblLastSentDate.Size = New System.Drawing.Size(246, 17)
        Me.lblLastSentDate.TabIndex = 33
        Me.lblLastSentDate.Text = "No messages sent to contact"
        Me.lblLastSentDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLastReceivedDate
        '
        Me.lblLastReceivedDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastReceivedDate.Location = New System.Drawing.Point(235, 18)
        Me.lblLastReceivedDate.Name = "lblLastReceivedDate"
        Me.lblLastReceivedDate.Size = New System.Drawing.Size(246, 17)
        Me.lblLastReceivedDate.TabIndex = 32
        Me.lblLastReceivedDate.Text = "No messages received from contact"
        Me.lblLastReceivedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpLastMessageReceived
        '
        Me.dtpLastMessageReceived.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpLastMessageReceived.Location = New System.Drawing.Point(232, 16)
        Me.dtpLastMessageReceived.Name = "dtpLastMessageReceived"
        Me.dtpLastMessageReceived.Size = New System.Drawing.Size(314, 22)
        Me.dtpLastMessageReceived.TabIndex = 19
        Me.dtpLastMessageReceived.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(221, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Last message received from contact:"
        '
        'dtpLastMessageSent
        '
        Me.dtpLastMessageSent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpLastMessageSent.Location = New System.Drawing.Point(232, 15)
        Me.dtpLastMessageSent.Name = "dtpLastMessageSent"
        Me.dtpLastMessageSent.Size = New System.Drawing.Size(314, 22)
        Me.dtpLastMessageSent.TabIndex = 21
        Me.dtpLastMessageSent.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(185, 16)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Last message sent to contact:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(224, 16)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Remind me if nothing received in last "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(202, 16)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Remind me if nothing sent in last "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(292, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 16)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "days"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(292, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 16)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "days"
        '
        'lblLastMessageReceived
        '
        Me.lblLastMessageReceived.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastMessageReceived.Location = New System.Drawing.Point(324, 52)
        Me.lblLastMessageReceived.Name = "lblLastMessageReceived"
        Me.lblLastMessageReceived.Size = New System.Drawing.Size(225, 16)
        Me.lblLastMessageReceived.TabIndex = 29
        Me.lblLastMessageReceived.Text = "Message received 0 days ago"
        Me.lblLastMessageReceived.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLastMessageSent
        '
        Me.lblLastMessageSent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastMessageSent.Location = New System.Drawing.Point(324, 53)
        Me.lblLastMessageSent.Name = "lblLastMessageSent"
        Me.lblLastMessageSent.Size = New System.Drawing.Size(225, 16)
        Me.lblLastMessageSent.TabIndex = 30
        Me.lblLastMessageSent.Text = "Message sent 0 days ago"
        Me.lblLastMessageSent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabEmail)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(2, 132)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(567, 228)
        Me.TabControl1.TabIndex = 41
        '
        'tabEmail
        '
        Me.tabEmail.Controls.Add(Me.Label7)
        Me.tabEmail.Controls.Add(Me.cboSMTPAccount)
        Me.tabEmail.Controls.Add(Me.Label21)
        Me.tabEmail.Controls.Add(Me.txtWebMessagePassword)
        Me.tabEmail.Controls.Add(Me.Label22)
        Me.tabEmail.Controls.Add(Me.txtWebMessageQuestion)
        Me.tabEmail.Controls.Add(Me.lblAutoSendReturnReceipts)
        Me.tabEmail.Controls.Add(Me.chkAutoRequestReturnReceipt)
        Me.tabEmail.Controls.Add(Me.cboAutoSendReturnReceipts)
        Me.tabEmail.Location = New System.Drawing.Point(4, 25)
        Me.tabEmail.Name = "tabEmail"
        Me.tabEmail.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEmail.Size = New System.Drawing.Size(559, 199)
        Me.tabEmail.TabIndex = 2
        Me.tabEmail.Text = "Email"
        Me.tabEmail.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 158)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(151, 16)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Default sending account:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(7, 129)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(155, 16)
        Me.Label21.TabIndex = 20
        Me.Label21.Text = "Web message password:"
        '
        'txtWebMessagePassword
        '
        Me.txtWebMessagePassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWebMessagePassword.Location = New System.Drawing.Point(214, 126)
        Me.txtWebMessagePassword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtWebMessagePassword.MaxLength = 100
        Me.txtWebMessagePassword.Name = "txtWebMessagePassword"
        Me.txtWebMessagePassword.Size = New System.Drawing.Size(308, 22)
        Me.txtWebMessagePassword.TabIndex = 19
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(7, 99)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(149, 16)
        Me.Label22.TabIndex = 18
        Me.Label22.Text = "Web message question:"
        '
        'txtWebMessageQuestion
        '
        Me.txtWebMessageQuestion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWebMessageQuestion.Location = New System.Drawing.Point(214, 96)
        Me.txtWebMessageQuestion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtWebMessageQuestion.MaxLength = 100
        Me.txtWebMessageQuestion.Name = "txtWebMessageQuestion"
        Me.txtWebMessageQuestion.Size = New System.Drawing.Size(308, 22)
        Me.txtWebMessageQuestion.TabIndex = 17
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(559, 199)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Reminders"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.btnClearLastReceived)
        Me.GroupBox2.Controls.Add(Me.lblLastMessageReceived)
        Me.GroupBox2.Controls.Add(Me.btnEditLastReceived)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lblLastReceivedDate)
        Me.GroupBox2.Controls.Add(Me.nudReminderReceived)
        Me.GroupBox2.Controls.Add(Me.dtpLastMessageReceived)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(552, 80)
        Me.GroupBox2.TabIndex = 42
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Received"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnClearLastSent)
        Me.GroupBox1.Controls.Add(Me.nudReminderSent)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.btnEditLastSent)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblLastSentDate)
        Me.GroupBox1.Controls.Add(Me.lblLastMessageSent)
        Me.GroupBox1.Controls.Add(Me.dtpLastMessageSent)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 108)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 80)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sent"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.rdoContactPictureGravitar)
        Me.TabPage2.Controls.Add(Me.btnLoadGravitar)
        Me.TabPage2.Controls.Add(Me.rdoContactPictureCurrent)
        Me.TabPage2.Controls.Add(Me.btnRefreshPictureFromWeb)
        Me.TabPage2.Controls.Add(Me.txtPictureURL)
        Me.TabPage2.Controls.Add(Me.cboBuiltInPicture)
        Me.TabPage2.Controls.Add(Me.rdoContactPictureNone)
        Me.TabPage2.Controls.Add(Me.rdoContactPictureWeb)
        Me.TabPage2.Controls.Add(Me.rdoContactPictureThisComputer)
        Me.TabPage2.Controls.Add(Me.rdoContactPictureBuiltIn)
        Me.TabPage2.Controls.Add(Me.pbContactPicture)
        Me.TabPage2.Controls.Add(Me.btnChangePicture)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(559, 199)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Picture"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'rdoContactPictureGravitar
        '
        Me.rdoContactPictureGravitar.AutoSize = True
        Me.rdoContactPictureGravitar.Location = New System.Drawing.Point(151, 155)
        Me.rdoContactPictureGravitar.Name = "rdoContactPictureGravitar"
        Me.rdoContactPictureGravitar.Size = New System.Drawing.Size(88, 17)
        Me.rdoContactPictureGravitar.TabIndex = 46
        Me.rdoContactPictureGravitar.Text = "From Gravitar"
        Me.rdoContactPictureGravitar.UseVisualStyleBackColor = True
        '
        'rdoContactPictureCurrent
        '
        Me.rdoContactPictureCurrent.AutoSize = True
        Me.rdoContactPictureCurrent.Checked = True
        Me.rdoContactPictureCurrent.Location = New System.Drawing.Point(151, 19)
        Me.rdoContactPictureCurrent.Name = "rdoContactPictureCurrent"
        Me.rdoContactPictureCurrent.Size = New System.Drawing.Size(94, 17)
        Me.rdoContactPictureCurrent.TabIndex = 44
        Me.rdoContactPictureCurrent.TabStop = True
        Me.rdoContactPictureCurrent.Text = "Current picture"
        Me.rdoContactPictureCurrent.UseVisualStyleBackColor = True
        '
        'txtPictureURL
        '
        Me.txtPictureURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPictureURL.Enabled = False
        Me.txtPictureURL.Location = New System.Drawing.Point(284, 128)
        Me.txtPictureURL.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPictureURL.Name = "txtPictureURL"
        Me.txtPictureURL.Size = New System.Drawing.Size(239, 22)
        Me.txtPictureURL.TabIndex = 42
        '
        'cboBuiltInPicture
        '
        Me.cboBuiltInPicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboBuiltInPicture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBuiltInPicture.Enabled = False
        Me.cboBuiltInPicture.FormattingEnabled = True
        Me.cboBuiltInPicture.Items.AddRange(New Object() {"Standard female", "Standard male"})
        Me.cboBuiltInPicture.Location = New System.Drawing.Point(284, 73)
        Me.cboBuiltInPicture.Name = "cboBuiltInPicture"
        Me.cboBuiltInPicture.Size = New System.Drawing.Size(268, 24)
        Me.cboBuiltInPicture.TabIndex = 41
        '
        'rdoContactPictureNone
        '
        Me.rdoContactPictureNone.AutoSize = True
        Me.rdoContactPictureNone.Location = New System.Drawing.Point(151, 47)
        Me.rdoContactPictureNone.Name = "rdoContactPictureNone"
        Me.rdoContactPictureNone.Size = New System.Drawing.Size(74, 17)
        Me.rdoContactPictureNone.TabIndex = 40
        Me.rdoContactPictureNone.Text = "No picture"
        Me.rdoContactPictureNone.UseVisualStyleBackColor = True
        '
        'rdoContactPictureWeb
        '
        Me.rdoContactPictureWeb.AutoSize = True
        Me.rdoContactPictureWeb.Location = New System.Drawing.Point(151, 129)
        Me.rdoContactPictureWeb.Name = "rdoContactPictureWeb"
        Me.rdoContactPictureWeb.Size = New System.Drawing.Size(89, 17)
        Me.rdoContactPictureWeb.TabIndex = 39
        Me.rdoContactPictureWeb.Text = "From the web"
        Me.rdoContactPictureWeb.UseVisualStyleBackColor = True
        '
        'rdoContactPictureThisComputer
        '
        Me.rdoContactPictureThisComputer.AutoSize = True
        Me.rdoContactPictureThisComputer.Location = New System.Drawing.Point(151, 103)
        Me.rdoContactPictureThisComputer.Name = "rdoContactPictureThisComputer"
        Me.rdoContactPictureThisComputer.Size = New System.Drawing.Size(114, 17)
        Me.rdoContactPictureThisComputer.TabIndex = 38
        Me.rdoContactPictureThisComputer.Text = "From this computer"
        Me.rdoContactPictureThisComputer.UseVisualStyleBackColor = True
        '
        'rdoContactPictureBuiltIn
        '
        Me.rdoContactPictureBuiltIn.AutoSize = True
        Me.rdoContactPictureBuiltIn.Location = New System.Drawing.Point(151, 75)
        Me.rdoContactPictureBuiltIn.Name = "rdoContactPictureBuiltIn"
        Me.rdoContactPictureBuiltIn.Size = New System.Drawing.Size(91, 17)
        Me.rdoContactPictureBuiltIn.TabIndex = 37
        Me.rdoContactPictureBuiltIn.Text = "Built-in picture"
        Me.rdoContactPictureBuiltIn.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.nudImportance)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.chkRemoteImages)
        Me.TabPage4.Controls.Add(Me.chkBlocked)
        Me.TabPage4.Controls.Add(Me.chkActive)
        Me.TabPage4.Controls.Add(Me.chkReceiveOnly)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(559, 199)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Settings"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 148)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(268, 16)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Importance (used when receiving messages):"
        '
        'chkRemoteImages
        '
        Me.chkRemoteImages.AutoSize = True
        Me.chkRemoteImages.Location = New System.Drawing.Point(10, 116)
        Me.chkRemoteImages.Name = "chkRemoteImages"
        Me.chkRemoteImages.Size = New System.Drawing.Size(411, 17)
        Me.chkRemoteImages.TabIndex = 18
        Me.chkRemoteImages.Text = "Show Remote Images (do not block remote images in messages from this contact)"
        Me.chkRemoteImages.UseVisualStyleBackColor = True
        '
        'chkBlocked
        '
        Me.chkBlocked.AutoSize = True
        Me.chkBlocked.Location = New System.Drawing.Point(10, 52)
        Me.chkBlocked.Name = "chkBlocked"
        Me.chkBlocked.Size = New System.Drawing.Size(261, 17)
        Me.chkBlocked.TabIndex = 15
        Me.chkBlocked.Text = "Blocked (this contact cannot send you messages)"
        Me.chkBlocked.UseVisualStyleBackColor = True
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(10, 20)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(260, 17)
        Me.chkActive.TabIndex = 16
        Me.chkActive.Text = "Active (uncheck to permanently hide this contact)"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'chkReceiveOnly
        '
        Me.chkReceiveOnly.AutoSize = True
        Me.chkReceiveOnly.Location = New System.Drawing.Point(10, 84)
        Me.chkReceiveOnly.Name = "chkReceiveOnly"
        Me.chkReceiveOnly.Size = New System.Drawing.Size(298, 17)
        Me.chkReceiveOnly.TabIndex = 17
        Me.chkReceiveOnly.Text = "Receive Only (you cannot send messages to this contact)"
        Me.chkReceiveOnly.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtCustom4)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.txtWebPage)
        Me.TabPage3.Controls.Add(Me.txtCustom3)
        Me.TabPage3.Controls.Add(Me.txtCustom2)
        Me.TabPage3.Controls.Add(Me.txtCustom1)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.txtMobilePhone)
        Me.TabPage3.Controls.Add(Me.txtWorkPhone)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.txtHomePhone)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(559, 199)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "Other"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtCustom4
        '
        Me.txtCustom4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustom4.Location = New System.Drawing.Point(80, 159)
        Me.txtCustom4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCustom4.Name = "txtCustom4"
        Me.txtCustom4.Size = New System.Drawing.Size(471, 22)
        Me.txtCustom4.TabIndex = 33
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 162)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 16)
        Me.Label19.TabIndex = 32
        Me.Label19.Text = "Custom 4:"
        '
        'txtWebPage
        '
        Me.txtWebPage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWebPage.Location = New System.Drawing.Point(323, 39)
        Me.txtWebPage.MaxLength = 400
        Me.txtWebPage.Multiline = False
        Me.txtWebPage.Name = "txtWebPage"
        Me.txtWebPage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.txtWebPage.ShortcutsEnabled = False
        Me.txtWebPage.Size = New System.Drawing.Size(228, 24)
        Me.txtWebPage.TabIndex = 31
        Me.txtWebPage.Text = ""
        '
        'txtCustom3
        '
        Me.txtCustom3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustom3.Location = New System.Drawing.Point(81, 129)
        Me.txtCustom3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCustom3.Name = "txtCustom3"
        Me.txtCustom3.Size = New System.Drawing.Size(471, 22)
        Me.txtCustom3.TabIndex = 29
        '
        'txtCustom2
        '
        Me.txtCustom2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustom2.Location = New System.Drawing.Point(81, 99)
        Me.txtCustom2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCustom2.Name = "txtCustom2"
        Me.txtCustom2.Size = New System.Drawing.Size(471, 22)
        Me.txtCustom2.TabIndex = 28
        '
        'txtCustom1
        '
        Me.txtCustom1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustom1.Location = New System.Drawing.Point(81, 69)
        Me.txtCustom1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCustom1.Name = "txtCustom1"
        Me.txtCustom1.Size = New System.Drawing.Size(471, 22)
        Me.txtCustom1.TabIndex = 27
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(280, 42)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 16)
        Me.Label20.TabIndex = 25
        Me.Label20.Text = "Web:"
        '
        'txtMobilePhone
        '
        Me.txtMobilePhone.Location = New System.Drawing.Point(81, 39)
        Me.txtMobilePhone.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMobilePhone.Name = "txtMobilePhone"
        Me.txtMobilePhone.Size = New System.Drawing.Size(193, 22)
        Me.txtMobilePhone.TabIndex = 24
        '
        'txtWorkPhone
        '
        Me.txtWorkPhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWorkPhone.Location = New System.Drawing.Point(323, 9)
        Me.txtWorkPhone.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtWorkPhone.Name = "txtWorkPhone"
        Me.txtWorkPhone.Size = New System.Drawing.Size(228, 22)
        Me.txtWorkPhone.TabIndex = 23
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 72)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 16)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Custom 1:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 132)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 16)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Custom 3:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 102)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 16)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Custom 2:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 42)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 16)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Mobile:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(280, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 16)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Work:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 13)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 16)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Home:"
        '
        'txtHomePhone
        '
        Me.txtHomePhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHomePhone.Location = New System.Drawing.Point(81, 9)
        Me.txtHomePhone.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtHomePhone.Name = "txtHomePhone"
        Me.txtHomePhone.Size = New System.Drawing.Size(193, 22)
        Me.txtHomePhone.TabIndex = 14
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Panel1)
        Me.TabPage5.Controls.Add(Me.Label17)
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(559, 199)
        Me.TabPage5.TabIndex = 5
        Me.TabPage5.Text = "Notes"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.txtNotes)
        Me.Panel1.Location = New System.Drawing.Point(59, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(494, 185)
        Me.Panel1.TabIndex = 34
        '
        'txtNotes
        '
        Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNotes.Location = New System.Drawing.Point(0, 0)
        Me.txtNotes.MaxLength = 400
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(494, 185)
        Me.txtNotes.TabIndex = 32
        Me.txtNotes.Text = ""
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 11)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 16)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Notes:"
        '
        'EditContact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(570, 432)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTags)
        Me.Controls.Add(Me.lblDateAdded)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblEmailAddress)
        Me.Controls.Add(Me.txtEmailAddress)
        Me.Controls.Add(Me.pbContctType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFullName)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "EditContact"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Contact"
        CType(Me.pbContctType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbContactPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudReminderReceived, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudReminderSent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudImportance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tabEmail.ResumeLayout(False)
        Me.tabEmail.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbContctType As System.Windows.Forms.PictureBox
    Friend WithEvents lblEmailAddress As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblDateAdded As System.Windows.Forms.Label
    Friend WithEvents chkAutoRequestReturnReceipt As System.Windows.Forms.CheckBox
    Friend WithEvents cboAutoSendReturnReceipts As System.Windows.Forms.ComboBox
    Friend WithEvents lblAutoSendReturnReceipts As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTags As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pbContactPicture As System.Windows.Forms.PictureBox
    Friend WithEvents btnChangePicture As System.Windows.Forms.Button
    Friend WithEvents lblLastSentDate As System.Windows.Forms.Label
    Friend WithEvents lblLastReceivedDate As System.Windows.Forms.Label
    Friend WithEvents nudReminderReceived As System.Windows.Forms.NumericUpDown
    Friend WithEvents dtpLastMessageReceived As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpLastMessageSent As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents nudReminderSent As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblLastMessageReceived As System.Windows.Forms.Label
    Friend WithEvents lblLastMessageSent As System.Windows.Forms.Label
    Friend WithEvents btnEditLastSent As System.Windows.Forms.Button
    Friend WithEvents btnClearLastSent As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents tabEmail As System.Windows.Forms.TabPage
    Friend WithEvents rdoContactPictureWeb As System.Windows.Forms.RadioButton
    Friend WithEvents rdoContactPictureThisComputer As System.Windows.Forms.RadioButton
    Friend WithEvents rdoContactPictureBuiltIn As System.Windows.Forms.RadioButton
    Friend WithEvents rdoContactPictureNone As System.Windows.Forms.RadioButton
    Friend WithEvents cboBuiltInPicture As System.Windows.Forms.ComboBox
    Friend WithEvents btnRefreshPictureFromWeb As System.Windows.Forms.Button
    Friend WithEvents txtPictureURL As System.Windows.Forms.TextBox
    Friend WithEvents rdoContactPictureCurrent As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents chkBlocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents chkReceiveOnly As System.Windows.Forms.CheckBox
    Friend WithEvents nudImportance As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkRemoteImages As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtCustom3 As System.Windows.Forms.TextBox
    Friend WithEvents txtCustom2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCustom1 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtMobilePhone As System.Windows.Forms.TextBox
    Friend WithEvents txtWorkPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtHomePhone As System.Windows.Forms.TextBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents txtWebPage As System.Windows.Forms.RichTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents txtCustom4 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtWebMessagePassword As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtWebMessageQuestion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSMTPAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdoContactPictureGravitar As System.Windows.Forms.RadioButton
    Friend WithEvents btnLoadGravitar As System.Windows.Forms.Button
    Friend WithEvents btnClearLastReceived As System.Windows.Forms.Button
    Friend WithEvents btnEditLastReceived As System.Windows.Forms.Button
End Class
