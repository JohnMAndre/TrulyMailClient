<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsForm))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabAutoSendReceive = New System.Windows.Forms.TabPage()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.GroupBox27 = New System.Windows.Forms.GroupBox()
        Me.pbEmailDelayInfo = New System.Windows.Forms.PictureBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.nudIntraEmailSendDelay = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.pbSecondThoughtsInfo = New System.Windows.Forms.PictureBox()
        Me.chkSendNowOnExit = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtSendNowMinutes = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.chkAutomaticallyTransmitOnSend = New System.Windows.Forms.CheckBox()
        Me.pbAutoSendReceiveTrulyMail = New System.Windows.Forms.PictureBox()
        Me.chkAutoSendReceive = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkSendReceiveOnStartup = New System.Windows.Forms.CheckBox()
        Me.txtSendReceiveEveryXMinutes = New System.Windows.Forms.TextBox()
        Me.GroupBox23 = New System.Windows.Forms.GroupBox()
        Me.chkRSSAutoCheck = New System.Windows.Forms.CheckBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtRSSAutoCheckMinutes = New System.Windows.Forms.TextBox()
        Me.pbRSSInfo = New System.Windows.Forms.PictureBox()
        Me.chkRSSAutoCheckOnStartup = New System.Windows.Forms.CheckBox()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.tabComposing = New System.Windows.Forms.TabPage()
        Me.KryptonPanel3 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.rdoFallbackNever = New System.Windows.Forms.RadioButton()
        Me.rdoFallbackAlways = New System.Windows.Forms.RadioButton()
        Me.rdoFallbackUnderWine = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkSpellCheckSubject = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkAutoSpellCheckBeforeSend = New System.Windows.Forms.CheckBox()
        Me.cboDictionary = New System.Windows.Forms.ComboBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudSendDelayMinutes = New System.Windows.Forms.NumericUpDown()
        Me.pbChangeComposeBackColor = New System.Windows.Forms.PictureBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.nudAutoSaveDraft = New System.Windows.Forms.NumericUpDown()
        Me.chkAutoSaveDrafts = New System.Windows.Forms.CheckBox()
        Me.chkKeepSentMessages = New System.Windows.Forms.CheckBox()
        Me.txtSampleNewMessage = New System.Windows.Forms.TextBox()
        Me.chkShowEditorSpacingStatus = New System.Windows.Forms.CheckBox()
        Me.chkSingleSpaceEditor = New System.Windows.Forms.CheckBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.picNewMessageBackground = New System.Windows.Forms.PictureBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cboDefaultNewMessageFontName = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.nudDefaultNewMessageFontSize = New System.Windows.Forms.NumericUpDown()
        Me.tabExperience = New System.Windows.Forms.TabPage()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.lblNewMessageStaysOpenCalculation = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.nudNewMessageNotifyStaysOpen = New System.Windows.Forms.NumericUpDown()
        Me.btnResetAllHiddenNotices = New System.Windows.Forms.Button()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.btnPlaySelectedNotifySound = New System.Windows.Forms.Button()
        Me.cboNewMessageNoticeSound = New System.Windows.Forms.ComboBox()
        Me.chkPlaySoundNewMessages = New System.Windows.Forms.CheckBox()
        Me.chkShowNoticeForNewMessages = New System.Windows.Forms.CheckBox()
        Me.GroupBox21 = New System.Windows.Forms.GroupBox()
        Me.chkPreviewPanePlainText = New System.Windows.Forms.CheckBox()
        Me.cboDateFormat = New System.Windows.Forms.ComboBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.nudDelayWhenCannotSend = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkRemoveDiacriticsOnReceive = New System.Windows.Forms.CheckBox()
        Me.chkHideOutboxCountPastToday = New System.Windows.Forms.CheckBox()
        Me.chkUseLargeSendReceiveButton = New System.Windows.Forms.CheckBox()
        Me.chkToolBarsIncludeText = New System.Windows.Forms.CheckBox()
        Me.chkUseLargeToolbarIcons = New System.Windows.Forms.CheckBox()
        Me.chkMinimizeToTray = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cboReplyPostingMode = New System.Windows.Forms.ComboBox()
        Me.txtDefaultSubject = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.grpAutomation = New System.Windows.Forms.GroupBox()
        Me.chkEmptyTrashOnExit = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.nudTrashDaysToRetain = New System.Windows.Forms.NumericUpDown()
        Me.chkAutoEmptyTrash = New System.Windows.Forms.CheckBox()
        Me.tabMessageList = New System.Windows.Forms.TabPage()
        Me.KryptonPanel4 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.GroupBox28 = New System.Windows.Forms.GroupBox()
        Me.chkAutoSizeMessageListColumns = New System.Windows.Forms.CheckBox()
        Me.lblAlternatingRowColor = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.pbMoveMessageTagDown = New System.Windows.Forms.PictureBox()
        Me.pbMoveMessageTagUp = New System.Windows.Forms.PictureBox()
        Me.pbUpdateMessageTag = New System.Windows.Forms.PictureBox()
        Me.pbDeleteMessageTag = New System.Windows.Forms.PictureBox()
        Me.pbAddNewMessageTag = New System.Windows.Forms.PictureBox()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.lblMessageTagColor = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtNewMessageTagText = New System.Windows.Forms.TextBox()
        Me.lstMessageTags = New System.Windows.Forms.ListBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.chkMaintainMessageZoom = New System.Windows.Forms.CheckBox()
        Me.chkShowReadingZoomBar = New System.Windows.Forms.CheckBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.nudLoadMessagePreviewDelay = New System.Windows.Forms.NumericUpDown()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.tabEmail = New System.Windows.Forms.TabPage()
        Me.KryptonPanel5 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkAutoZipEmailAttachments = New System.Windows.Forms.CheckBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.rbtnEmailShowSenderAsAddressBook = New System.Windows.Forms.RadioButton()
        Me.rbtnEmailShowSenderAsSent = New System.Windows.Forms.RadioButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox26 = New System.Windows.Forms.GroupBox()
        Me.btnChangeFontForPlainText = New System.Windows.Forms.Button()
        Me.lblFontForPlainText = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.chkEmailAutoAddRecipientsToAddressBook = New System.Windows.Forms.CheckBox()
        Me.chkReplyToPlainTextIsPlainText = New System.Windows.Forms.CheckBox()
        Me.chkAutoReturnReceipt = New System.Windows.Forms.CheckBox()
        Me.chkEmailAutoAddRecipientsTieSMTP = New System.Windows.Forms.CheckBox()
        Me.chkBlockRemoteImages = New System.Windows.Forms.CheckBox()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.cboDefaultEmailEncryption = New System.Windows.Forms.ComboBox()
        Me.chkNeverProcessEmailReturnReceipts = New System.Windows.Forms.CheckBox()
        Me.tabProfileType = New System.Windows.Forms.TabPage()
        Me.KryptonPanel7 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkAddNoteWhenChangingSubject = New System.Windows.Forms.CheckBox()
        Me.chkAddNoteWhenSendingReturnReceipt = New System.Windows.Forms.CheckBox()
        Me.chkAddNoteForProcessingRuleAction = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tabTroubleshooting = New System.Windows.Forms.TabPage()
        Me.KryptonPanel9 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkEnableVerboseLogging = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudLoggingErrorDisplayFrequency = New System.Windows.Forms.NumericUpDown()
        Me.pbLogFileInfo = New System.Windows.Forms.PictureBox()
        Me.btnDeleteCurrentLogFile = New System.Windows.Forms.Button()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.nudPromptToRecreateEncryptionKeysDays = New System.Windows.Forms.NumericUpDown()
        Me.nudPromptToRecreateEncryptionKeysMessages = New System.Windows.Forms.NumericUpDown()
        Me.cboEncryptionVersion = New System.Windows.Forms.ComboBox()
        Me.chkEnableLogging = New System.Windows.Forms.CheckBox()
        Me.grpLogging = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLogFileLocation = New System.Windows.Forms.TextBox()
        Me.lblPortableLogFileNotice = New System.Windows.Forms.Label()
        Me.btnBrowseForLogFile = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tmrHideKeyChangeProgress = New System.Windows.Forms.Timer(Me.components)
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.tmrAutoClose = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.tabAutoSendReceive.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        Me.GroupBox27.SuspendLayout()
        CType(Me.pbEmailDelayInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIntraEmailSendDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox10.SuspendLayout()
        CType(Me.pbSecondThoughtsInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        CType(Me.pbAutoSendReceiveTrulyMail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox23.SuspendLayout()
        CType(Me.pbRSSInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabComposing.SuspendLayout()
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel3.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.nudSendDelayMinutes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbChangeComposeBackColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAutoSaveDraft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picNewMessageBackground, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDefaultNewMessageFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabExperience.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        CType(Me.nudNewMessageNotifyStaysOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox21.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        CType(Me.nudDelayWhenCannotSend, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.grpAutomation.SuspendLayout()
        CType(Me.nudTrashDaysToRetain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMessageList.SuspendLayout()
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel4.SuspendLayout()
        Me.GroupBox28.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        CType(Me.pbMoveMessageTagDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbMoveMessageTagUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbUpdateMessageTag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbDeleteMessageTag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddNewMessageTag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        CType(Me.nudLoadMessagePreviewDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEmail.SuspendLayout()
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel5.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox26.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.tabProfileType.SuspendLayout()
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel7.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tabTroubleshooting.SuspendLayout()
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel9.SuspendLayout()
        CType(Me.nudLoggingErrorDisplayFrequency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLogFileInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox19.SuspendLayout()
        CType(Me.nudPromptToRecreateEncryptionKeysDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPromptToRecreateEncryptionKeysMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpLogging.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabAutoSendReceive)
        Me.TabControl1.Controls.Add(Me.tabComposing)
        Me.TabControl1.Controls.Add(Me.tabExperience)
        Me.TabControl1.Controls.Add(Me.tabMessageList)
        Me.TabControl1.Controls.Add(Me.tabEmail)
        Me.TabControl1.Controls.Add(Me.tabProfileType)
        Me.TabControl1.Controls.Add(Me.tabTroubleshooting)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(784, 508)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.TabControl1.TabIndex = 33
        '
        'tabAutoSendReceive
        '
        Me.tabAutoSendReceive.Controls.Add(Me.KryptonPanel2)
        Me.tabAutoSendReceive.Location = New System.Drawing.Point(4, 25)
        Me.tabAutoSendReceive.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabAutoSendReceive.Name = "tabAutoSendReceive"
        Me.tabAutoSendReceive.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabAutoSendReceive.Size = New System.Drawing.Size(776, 479)
        Me.tabAutoSendReceive.TabIndex = 0
        Me.tabAutoSendReceive.Text = "Send/Receive"
        Me.tabAutoSendReceive.UseVisualStyleBackColor = True
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.GroupBox27)
        Me.KryptonPanel2.Controls.Add(Me.GroupBox10)
        Me.KryptonPanel2.Controls.Add(Me.GroupBox11)
        Me.KryptonPanel2.Controls.Add(Me.GroupBox23)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.Location = New System.Drawing.Point(3, 4)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Palette = Me.KryptonPalette1
        Me.KryptonPanel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel2.Size = New System.Drawing.Size(770, 471)
        Me.KryptonPanel2.TabIndex = 52
        '
        'GroupBox27
        '
        Me.GroupBox27.AutoSize = True
        Me.GroupBox27.Controls.Add(Me.Label55)
        Me.GroupBox27.Controls.Add(Me.nudIntraEmailSendDelay)
        Me.GroupBox27.Controls.Add(Me.pbEmailDelayInfo)
        Me.GroupBox27.Controls.Add(Me.Label53)
        Me.GroupBox27.Location = New System.Drawing.Point(407, 177)
        Me.GroupBox27.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox27.Name = "GroupBox27"
        Me.GroupBox27.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox27.Size = New System.Drawing.Size(360, 95)
        Me.GroupBox27.TabIndex = 31
        Me.GroupBox27.TabStop = False
        Me.GroupBox27.Text = "Newsletter mode"
        '
        'pbEmailDelayInfo
        '
        Me.pbEmailDelayInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbEmailDelayInfo.Image = Global.TrulyMail.My.Resources.Resources.info_32
        Me.pbEmailDelayInfo.Location = New System.Drawing.Point(334, 7)
        Me.pbEmailDelayInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbEmailDelayInfo.Name = "pbEmailDelayInfo"
        Me.pbEmailDelayInfo.Size = New System.Drawing.Size(26, 27)
        Me.pbEmailDelayInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEmailDelayInfo.TabIndex = 30
        Me.pbEmailDelayInfo.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbEmailDelayInfo, "Click for information on delayed sending")
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(11, 37)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(182, 16)
        Me.Label53.TabIndex = 7
        Me.Label53.Text = "Wait between sending emails:"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(288, 37)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(61, 16)
        Me.Label55.TabIndex = 6
        Me.Label55.Text = "seconds."
        '
        'nudIntraEmailSendDelay
        '
        Me.nudIntraEmailSendDelay.Location = New System.Drawing.Point(224, 35)
        Me.nudIntraEmailSendDelay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudIntraEmailSendDelay.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.nudIntraEmailSendDelay.Name = "nudIntraEmailSendDelay"
        Me.nudIntraEmailSendDelay.Size = New System.Drawing.Size(56, 22)
        Me.nudIntraEmailSendDelay.TabIndex = 39
        Me.nudIntraEmailSendDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudIntraEmailSendDelay.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBox10
        '
        Me.GroupBox10.AutoSize = True
        Me.GroupBox10.Controls.Add(Me.pbSecondThoughtsInfo)
        Me.GroupBox10.Controls.Add(Me.chkSendNowOnExit)
        Me.GroupBox10.Controls.Add(Me.Label18)
        Me.GroupBox10.Controls.Add(Me.txtSendNowMinutes)
        Me.GroupBox10.Controls.Add(Me.Label17)
        Me.GroupBox10.Location = New System.Drawing.Point(407, 25)
        Me.GroupBox10.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox10.Size = New System.Drawing.Size(360, 137)
        Me.GroupBox10.TabIndex = 8
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Second Thoughts"
        '
        'pbSecondThoughtsInfo
        '
        Me.pbSecondThoughtsInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbSecondThoughtsInfo.Image = Global.TrulyMail.My.Resources.Resources.info_32
        Me.pbSecondThoughtsInfo.Location = New System.Drawing.Point(334, 7)
        Me.pbSecondThoughtsInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbSecondThoughtsInfo.Name = "pbSecondThoughtsInfo"
        Me.pbSecondThoughtsInfo.Size = New System.Drawing.Size(26, 27)
        Me.pbSecondThoughtsInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbSecondThoughtsInfo.TabIndex = 30
        Me.pbSecondThoughtsInfo.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbSecondThoughtsInfo, "Click for information on delayed sending")
        '
        'chkSendNowOnExit
        '
        Me.chkSendNowOnExit.AutoSize = True
        Me.chkSendNowOnExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSendNowOnExit.Location = New System.Drawing.Point(13, 68)
        Me.chkSendNowOnExit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkSendNowOnExit.Name = "chkSendNowOnExit"
        Me.chkSendNowOnExit.Size = New System.Drawing.Size(279, 20)
        Me.chkSendNowOnExit.TabIndex = 6
        Me.chkSendNowOnExit.Text = "Send these unsent messages when closing"
        Me.chkSendNowOnExit.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(21, 37)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(154, 16)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "Send now means send in"
        '
        'txtSendNowMinutes
        '
        Me.txtSendNowMinutes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSendNowMinutes.Location = New System.Drawing.Point(208, 33)
        Me.txtSendNowMinutes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSendNowMinutes.Name = "txtSendNowMinutes"
        Me.txtSendNowMinutes.Size = New System.Drawing.Size(49, 22)
        Me.txtSendNowMinutes.TabIndex = 5
        Me.txtSendNowMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(267, 37)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 16)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "minutes."
        '
        'GroupBox11
        '
        Me.GroupBox11.AutoSize = True
        Me.GroupBox11.Controls.Add(Me.Label7)
        Me.GroupBox11.Controls.Add(Me.txtSendReceiveEveryXMinutes)
        Me.GroupBox11.Controls.Add(Me.chkAutomaticallyTransmitOnSend)
        Me.GroupBox11.Controls.Add(Me.pbAutoSendReceiveTrulyMail)
        Me.GroupBox11.Controls.Add(Me.chkAutoSendReceive)
        Me.GroupBox11.Controls.Add(Me.chkSendReceiveOnStartup)
        Me.GroupBox11.Location = New System.Drawing.Point(12, 24)
        Me.GroupBox11.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox11.Size = New System.Drawing.Size(389, 143)
        Me.GroupBox11.TabIndex = 9
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Auto Send/Receive"
        '
        'chkAutomaticallyTransmitOnSend
        '
        Me.chkAutomaticallyTransmitOnSend.AutoSize = True
        Me.chkAutomaticallyTransmitOnSend.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutomaticallyTransmitOnSend.Location = New System.Drawing.Point(9, 100)
        Me.chkAutomaticallyTransmitOnSend.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkAutomaticallyTransmitOnSend.Name = "chkAutomaticallyTransmitOnSend"
        Me.chkAutomaticallyTransmitOnSend.Size = New System.Drawing.Size(263, 20)
        Me.chkAutomaticallyTransmitOnSend.TabIndex = 31
        Me.chkAutomaticallyTransmitOnSend.Text = "Automatically send when send is clicked"
        Me.ToolTip1.SetToolTip(Me.chkAutomaticallyTransmitOnSend, "Uncheck if you want messages to stay in outbox until next send/receive")
        Me.chkAutomaticallyTransmitOnSend.UseVisualStyleBackColor = True
        '
        'pbAutoSendReceiveTrulyMail
        '
        Me.pbAutoSendReceiveTrulyMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbAutoSendReceiveTrulyMail.Image = Global.TrulyMail.My.Resources.Resources.info_32
        Me.pbAutoSendReceiveTrulyMail.Location = New System.Drawing.Point(363, 7)
        Me.pbAutoSendReceiveTrulyMail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbAutoSendReceiveTrulyMail.Name = "pbAutoSendReceiveTrulyMail"
        Me.pbAutoSendReceiveTrulyMail.Size = New System.Drawing.Size(26, 27)
        Me.pbAutoSendReceiveTrulyMail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbAutoSendReceiveTrulyMail.TabIndex = 30
        Me.pbAutoSendReceiveTrulyMail.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbAutoSendReceiveTrulyMail, "Click for information on automatic sending and receiving")
        '
        'chkAutoSendReceive
        '
        Me.chkAutoSendReceive.AutoSize = True
        Me.chkAutoSendReceive.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoSendReceive.Location = New System.Drawing.Point(9, 37)
        Me.chkAutoSendReceive.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkAutoSendReceive.Name = "chkAutoSendReceive"
        Me.chkAutoSendReceive.Size = New System.Drawing.Size(241, 20)
        Me.chkAutoSendReceive.TabIndex = 0
        Me.chkAutoSendReceive.Text = "Automatically send and receive every"
        Me.chkAutoSendReceive.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(325, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 16)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "minutes."
        '
        'chkSendReceiveOnStartup
        '
        Me.chkSendReceiveOnStartup.AutoSize = True
        Me.chkSendReceiveOnStartup.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSendReceiveOnStartup.Location = New System.Drawing.Point(9, 69)
        Me.chkSendReceiveOnStartup.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkSendReceiveOnStartup.Name = "chkSendReceiveOnStartup"
        Me.chkSendReceiveOnStartup.Size = New System.Drawing.Size(269, 20)
        Me.chkSendReceiveOnStartup.TabIndex = 4
        Me.chkSendReceiveOnStartup.Text = "Automatically send and receive on startup"
        Me.chkSendReceiveOnStartup.UseVisualStyleBackColor = True
        '
        'txtSendReceiveEveryXMinutes
        '
        Me.txtSendReceiveEveryXMinutes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSendReceiveEveryXMinutes.Location = New System.Drawing.Point(277, 35)
        Me.txtSendReceiveEveryXMinutes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSendReceiveEveryXMinutes.Name = "txtSendReceiveEveryXMinutes"
        Me.txtSendReceiveEveryXMinutes.Size = New System.Drawing.Size(44, 22)
        Me.txtSendReceiveEveryXMinutes.TabIndex = 2
        Me.txtSendReceiveEveryXMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox23
        '
        Me.GroupBox23.AutoSize = True
        Me.GroupBox23.Controls.Add(Me.Label46)
        Me.GroupBox23.Controls.Add(Me.txtRSSAutoCheckMinutes)
        Me.GroupBox23.Controls.Add(Me.chkRSSAutoCheck)
        Me.GroupBox23.Controls.Add(Me.pbRSSInfo)
        Me.GroupBox23.Controls.Add(Me.chkRSSAutoCheckOnStartup)
        Me.GroupBox23.Location = New System.Drawing.Point(12, 170)
        Me.GroupBox23.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox23.Name = "GroupBox23"
        Me.GroupBox23.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox23.Size = New System.Drawing.Size(389, 102)
        Me.GroupBox23.TabIndex = 32
        Me.GroupBox23.TabStop = False
        Me.GroupBox23.Text = "RSS and News Feeds"
        '
        'chkRSSAutoCheck
        '
        Me.chkRSSAutoCheck.AutoSize = True
        Me.chkRSSAutoCheck.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRSSAutoCheck.Location = New System.Drawing.Point(9, 59)
        Me.chkRSSAutoCheck.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkRSSAutoCheck.Name = "chkRSSAutoCheck"
        Me.chkRSSAutoCheck.Size = New System.Drawing.Size(241, 20)
        Me.chkRSSAutoCheck.TabIndex = 31
        Me.chkRSSAutoCheck.Text = "Automatically send and receive every"
        Me.chkRSSAutoCheck.UseVisualStyleBackColor = True
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(325, 61)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(58, 16)
        Me.Label46.TabIndex = 33
        Me.Label46.Text = "minutes."
        '
        'txtRSSAutoCheckMinutes
        '
        Me.txtRSSAutoCheckMinutes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRSSAutoCheckMinutes.Location = New System.Drawing.Point(280, 57)
        Me.txtRSSAutoCheckMinutes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtRSSAutoCheckMinutes.Name = "txtRSSAutoCheckMinutes"
        Me.txtRSSAutoCheckMinutes.Size = New System.Drawing.Size(44, 22)
        Me.txtRSSAutoCheckMinutes.TabIndex = 32
        Me.txtRSSAutoCheckMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pbRSSInfo
        '
        Me.pbRSSInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbRSSInfo.Image = Global.TrulyMail.My.Resources.Resources.info_32
        Me.pbRSSInfo.Location = New System.Drawing.Point(363, 7)
        Me.pbRSSInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbRSSInfo.Name = "pbRSSInfo"
        Me.pbRSSInfo.Size = New System.Drawing.Size(26, 27)
        Me.pbRSSInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbRSSInfo.TabIndex = 30
        Me.pbRSSInfo.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbRSSInfo, "Click for information on TrulyMail sending limits")
        '
        'chkRSSAutoCheckOnStartup
        '
        Me.chkRSSAutoCheckOnStartup.AutoSize = True
        Me.chkRSSAutoCheckOnStartup.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRSSAutoCheckOnStartup.Location = New System.Drawing.Point(9, 31)
        Me.chkRSSAutoCheckOnStartup.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkRSSAutoCheckOnStartup.Name = "chkRSSAutoCheckOnStartup"
        Me.chkRSSAutoCheckOnStartup.Size = New System.Drawing.Size(217, 20)
        Me.chkRSSAutoCheckOnStartup.TabIndex = 6
        Me.chkRSSAutoCheckOnStartup.Text = "Check for new articles on startup"
        Me.chkRSSAutoCheckOnStartup.UseVisualStyleBackColor = True
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'tabComposing
        '
        Me.tabComposing.Controls.Add(Me.KryptonPanel3)
        Me.tabComposing.Location = New System.Drawing.Point(4, 25)
        Me.tabComposing.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabComposing.Name = "tabComposing"
        Me.tabComposing.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabComposing.Size = New System.Drawing.Size(776, 479)
        Me.tabComposing.TabIndex = 10
        Me.tabComposing.Text = "Composing"
        Me.tabComposing.ToolTipText = "Options when writing new messages"
        Me.tabComposing.UseVisualStyleBackColor = True
        '
        'KryptonPanel3
        '
        Me.KryptonPanel3.Controls.Add(Me.GroupBox8)
        Me.KryptonPanel3.Controls.Add(Me.GroupBox4)
        Me.KryptonPanel3.Controls.Add(Me.GroupBox6)
        Me.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel3.Location = New System.Drawing.Point(3, 4)
        Me.KryptonPanel3.Name = "KryptonPanel3"
        Me.KryptonPanel3.Palette = Me.KryptonPalette1
        Me.KryptonPanel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel3.Size = New System.Drawing.Size(770, 471)
        Me.KryptonPanel3.TabIndex = 52
        '
        'GroupBox8
        '
        Me.GroupBox8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox8.AutoSize = True
        Me.GroupBox8.Controls.Add(Me.rdoFallbackNever)
        Me.GroupBox8.Controls.Add(Me.rdoFallbackAlways)
        Me.GroupBox8.Controls.Add(Me.rdoFallbackUnderWine)
        Me.GroupBox8.Location = New System.Drawing.Point(5, 403)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox8.Size = New System.Drawing.Size(762, 72)
        Me.GroupBox8.TabIndex = 41
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Use fallback mode (plain text only)"
        '
        'rdoFallbackNever
        '
        Me.rdoFallbackNever.AutoSize = True
        Me.rdoFallbackNever.Location = New System.Drawing.Point(356, 30)
        Me.rdoFallbackNever.Name = "rdoFallbackNever"
        Me.rdoFallbackNever.Size = New System.Drawing.Size(58, 20)
        Me.rdoFallbackNever.TabIndex = 13
        Me.rdoFallbackNever.TabStop = True
        Me.rdoFallbackNever.Text = "&Never"
        Me.rdoFallbackNever.UseVisualStyleBackColor = True
        '
        'rdoFallbackAlways
        '
        Me.rdoFallbackAlways.AutoSize = True
        Me.rdoFallbackAlways.Location = New System.Drawing.Point(252, 30)
        Me.rdoFallbackAlways.Name = "rdoFallbackAlways"
        Me.rdoFallbackAlways.Size = New System.Drawing.Size(68, 20)
        Me.rdoFallbackAlways.TabIndex = 12
        Me.rdoFallbackAlways.TabStop = True
        Me.rdoFallbackAlways.Text = "&Always"
        Me.rdoFallbackAlways.UseVisualStyleBackColor = True
        '
        'rdoFallbackUnderWine
        '
        Me.rdoFallbackUnderWine.AutoSize = True
        Me.rdoFallbackUnderWine.Location = New System.Drawing.Point(17, 30)
        Me.rdoFallbackUnderWine.Name = "rdoFallbackUnderWine"
        Me.rdoFallbackUnderWine.Size = New System.Drawing.Size(203, 20)
        Me.rdoFallbackUnderWine.TabIndex = 11
        Me.rdoFallbackUnderWine.TabStop = True
        Me.rdoFallbackUnderWine.Text = "Only under &Wine (Linux / Mac)"
        Me.rdoFallbackUnderWine.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.AutoSize = True
        Me.GroupBox4.Controls.Add(Me.cboDictionary)
        Me.GroupBox4.Controls.Add(Me.chkSpellCheckSubject)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.chkAutoSpellCheckBeforeSend)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 320)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(776, 76)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Spelling"
        '
        'chkSpellCheckSubject
        '
        Me.chkSpellCheckSubject.AutoSize = True
        Me.chkSpellCheckSubject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSpellCheckSubject.Location = New System.Drawing.Point(521, 28)
        Me.chkSpellCheckSubject.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkSpellCheckSubject.Name = "chkSpellCheckSubject"
        Me.chkSpellCheckSubject.Size = New System.Drawing.Size(223, 20)
        Me.chkSpellCheckSubject.TabIndex = 6
        Me.chkSpellCheckSubject.Text = "Include subject during spell check"
        Me.chkSpellCheckSubject.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 16)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Dictionary to use:"
        '
        'chkAutoSpellCheckBeforeSend
        '
        Me.chkAutoSpellCheckBeforeSend.AutoSize = True
        Me.chkAutoSpellCheckBeforeSend.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoSpellCheckBeforeSend.Location = New System.Drawing.Point(306, 28)
        Me.chkAutoSpellCheckBeforeSend.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkAutoSpellCheckBeforeSend.Name = "chkAutoSpellCheckBeforeSend"
        Me.chkAutoSpellCheckBeforeSend.Size = New System.Drawing.Size(183, 20)
        Me.chkAutoSpellCheckBeforeSend.TabIndex = 5
        Me.chkAutoSpellCheckBeforeSend.Text = "Spell check before sending"
        Me.chkAutoSpellCheckBeforeSend.UseVisualStyleBackColor = True
        '
        'cboDictionary
        '
        Me.cboDictionary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDictionary.FormattingEnabled = True
        Me.cboDictionary.Location = New System.Drawing.Point(135, 23)
        Me.cboDictionary.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboDictionary.Name = "cboDictionary"
        Me.cboDictionary.Size = New System.Drawing.Size(151, 24)
        Me.cboDictionary.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.AutoSize = True
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.nudSendDelayMinutes)
        Me.GroupBox6.Controls.Add(Me.pbChangeComposeBackColor)
        Me.GroupBox6.Controls.Add(Me.Label13)
        Me.GroupBox6.Controls.Add(Me.nudAutoSaveDraft)
        Me.GroupBox6.Controls.Add(Me.chkAutoSaveDrafts)
        Me.GroupBox6.Controls.Add(Me.chkKeepSentMessages)
        Me.GroupBox6.Controls.Add(Me.txtSampleNewMessage)
        Me.GroupBox6.Controls.Add(Me.chkShowEditorSpacingStatus)
        Me.GroupBox6.Controls.Add(Me.chkSingleSpaceEditor)
        Me.GroupBox6.Controls.Add(Me.Label26)
        Me.GroupBox6.Controls.Add(Me.picNewMessageBackground)
        Me.GroupBox6.Controls.Add(Me.Label23)
        Me.GroupBox6.Controls.Add(Me.cboDefaultNewMessageFontName)
        Me.GroupBox6.Controls.Add(Me.Label25)
        Me.GroupBox6.Controls.Add(Me.Label24)
        Me.GroupBox6.Controls.Add(Me.nudDefaultNewMessageFontSize)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 4)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox6.Size = New System.Drawing.Size(776, 311)
        Me.GroupBox6.TabIndex = 13
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "New Messages"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 268)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 16)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Send delay (in minutes):"
        '
        'nudSendDelayMinutes
        '
        Me.nudSendDelayMinutes.Location = New System.Drawing.Point(197, 266)
        Me.nudSendDelayMinutes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudSendDelayMinutes.Maximum = New Decimal(New Integer() {1500, 0, 0, 0})
        Me.nudSendDelayMinutes.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSendDelayMinutes.Name = "nudSendDelayMinutes"
        Me.nudSendDelayMinutes.Size = New System.Drawing.Size(74, 22)
        Me.nudSendDelayMinutes.TabIndex = 40
        Me.nudSendDelayMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudSendDelayMinutes.ThousandsSeparator = True
        Me.nudSendDelayMinutes.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'pbChangeComposeBackColor
        '
        Me.pbChangeComposeBackColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbChangeComposeBackColor.Image = Global.TrulyMail.My.Resources.Resources.Savefile_32
        Me.pbChangeComposeBackColor.Location = New System.Drawing.Point(466, 62)
        Me.pbChangeComposeBackColor.Name = "pbChangeComposeBackColor"
        Me.pbChangeComposeBackColor.Size = New System.Drawing.Size(36, 36)
        Me.pbChangeComposeBackColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbChangeComposeBackColor.TabIndex = 39
        Me.pbChangeComposeBackColor.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbChangeComposeBackColor, "Change background message color")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(237, 235)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 16)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "minutes."
        '
        'nudAutoSaveDraft
        '
        Me.nudAutoSaveDraft.Location = New System.Drawing.Point(179, 235)
        Me.nudAutoSaveDraft.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudAutoSaveDraft.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudAutoSaveDraft.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudAutoSaveDraft.Name = "nudAutoSaveDraft"
        Me.nudAutoSaveDraft.Size = New System.Drawing.Size(51, 22)
        Me.nudAutoSaveDraft.TabIndex = 38
        Me.nudAutoSaveDraft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudAutoSaveDraft.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkAutoSaveDrafts
        '
        Me.chkAutoSaveDrafts.AutoSize = True
        Me.chkAutoSaveDrafts.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoSaveDrafts.Location = New System.Drawing.Point(10, 234)
        Me.chkAutoSaveDrafts.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkAutoSaveDrafts.Name = "chkAutoSaveDrafts"
        Me.chkAutoSaveDrafts.Size = New System.Drawing.Size(154, 20)
        Me.chkAutoSaveDrafts.TabIndex = 36
        Me.chkAutoSaveDrafts.Text = "Auto-save drafts every"
        Me.chkAutoSaveDrafts.UseVisualStyleBackColor = True
        '
        'chkKeepSentMessages
        '
        Me.chkKeepSentMessages.AutoSize = True
        Me.chkKeepSentMessages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkKeepSentMessages.Location = New System.Drawing.Point(10, 203)
        Me.chkKeepSentMessages.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkKeepSentMessages.Name = "chkKeepSentMessages"
        Me.chkKeepSentMessages.Size = New System.Drawing.Size(421, 20)
        Me.chkKeepSentMessages.TabIndex = 35
        Me.chkKeepSentMessages.Text = "Keep copy of sent messages (can override in new message window)"
        Me.chkKeepSentMessages.UseVisualStyleBackColor = True
        '
        'txtSampleNewMessage
        '
        Me.txtSampleNewMessage.BackColor = System.Drawing.Color.White
        Me.txtSampleNewMessage.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSampleNewMessage.Location = New System.Drawing.Point(330, 103)
        Me.txtSampleNewMessage.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSampleNewMessage.MaxLength = 70
        Me.txtSampleNewMessage.Multiline = True
        Me.txtSampleNewMessage.Name = "txtSampleNewMessage"
        Me.txtSampleNewMessage.ReadOnly = True
        Me.txtSampleNewMessage.Size = New System.Drawing.Size(228, 52)
        Me.txtSampleNewMessage.TabIndex = 15
        Me.txtSampleNewMessage.Text = "I love TrulyMail!!!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "I Truly do!!!"
        Me.ToolTip1.SetToolTip(Me.txtSampleNewMessage, "Example of what your messages should look like when composing")
        '
        'chkShowEditorSpacingStatus
        '
        Me.chkShowEditorSpacingStatus.AutoSize = True
        Me.chkShowEditorSpacingStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowEditorSpacingStatus.Location = New System.Drawing.Point(457, 160)
        Me.chkShowEditorSpacingStatus.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkShowEditorSpacingStatus.Name = "chkShowEditorSpacingStatus"
        Me.chkShowEditorSpacingStatus.Size = New System.Drawing.Size(259, 20)
        Me.chkShowEditorSpacingStatus.TabIndex = 34
        Me.chkShowEditorSpacingStatus.Text = "Show spacing status on message editor"
        Me.chkShowEditorSpacingStatus.UseVisualStyleBackColor = True
        Me.chkShowEditorSpacingStatus.Visible = False
        '
        'chkSingleSpaceEditor
        '
        Me.chkSingleSpaceEditor.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkSingleSpaceEditor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSingleSpaceEditor.Location = New System.Drawing.Point(10, 162)
        Me.chkSingleSpaceEditor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkSingleSpaceEditor.Name = "chkSingleSpaceEditor"
        Me.chkSingleSpaceEditor.Size = New System.Drawing.Size(450, 43)
        Me.chkSingleSpaceEditor.TabIndex = 7
        Me.chkSingleSpaceEditor.Text = "Use single spacing when creating messages" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Note: this may impact your ability to" &
    " format messages properly)"
        Me.chkSingleSpaceEditor.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkSingleSpaceEditor.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(7, 107)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(200, 16)
        Me.Label26.TabIndex = 33
        Me.Label26.Text = "New messages will look like this:"
        '
        'picNewMessageBackground
        '
        Me.picNewMessageBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picNewMessageBackground.Location = New System.Drawing.Point(330, 64)
        Me.picNewMessageBackground.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.picNewMessageBackground.Name = "picNewMessageBackground"
        Me.picNewMessageBackground.Size = New System.Drawing.Size(130, 32)
        Me.picNewMessageBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picNewMessageBackground.TabIndex = 31
        Me.picNewMessageBackground.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picNewMessageBackground, "The background color of future messages you compose")
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(573, 31)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(38, 16)
        Me.Label23.TabIndex = 14
        Me.Label23.Text = "Size:"
        '
        'cboDefaultNewMessageFontName
        '
        Me.cboDefaultNewMessageFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefaultNewMessageFontName.FormattingEnabled = True
        Me.cboDefaultNewMessageFontName.Location = New System.Drawing.Point(330, 31)
        Me.cboDefaultNewMessageFontName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboDefaultNewMessageFontName.Name = "cboDefaultNewMessageFontName"
        Me.cboDefaultNewMessageFontName.Size = New System.Drawing.Size(228, 24)
        Me.cboDefaultNewMessageFontName.TabIndex = 12
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(7, 66)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(272, 16)
        Me.Label25.TabIndex = 10
        Me.Label25.Text = "Use this background color for new messages:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(7, 32)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(251, 16)
        Me.Label24.TabIndex = 10
        Me.Label24.Text = "Use this font when writing new messages:"
        '
        'nudDefaultNewMessageFontSize
        '
        Me.nudDefaultNewMessageFontSize.Location = New System.Drawing.Point(624, 31)
        Me.nudDefaultNewMessageFontSize.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudDefaultNewMessageFontSize.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.nudDefaultNewMessageFontSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudDefaultNewMessageFontSize.Name = "nudDefaultNewMessageFontSize"
        Me.nudDefaultNewMessageFontSize.Size = New System.Drawing.Size(56, 22)
        Me.nudDefaultNewMessageFontSize.TabIndex = 11
        Me.nudDefaultNewMessageFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudDefaultNewMessageFontSize.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'tabExperience
        '
        Me.tabExperience.Controls.Add(Me.KryptonPanel1)
        Me.tabExperience.Location = New System.Drawing.Point(4, 25)
        Me.tabExperience.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabExperience.Name = "tabExperience"
        Me.tabExperience.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabExperience.Size = New System.Drawing.Size(776, 479)
        Me.tabExperience.TabIndex = 2
        Me.tabExperience.Text = "Experience"
        Me.tabExperience.UseVisualStyleBackColor = True
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.GroupBox14)
        Me.KryptonPanel1.Controls.Add(Me.GroupBox21)
        Me.KryptonPanel1.Controls.Add(Me.GroupBox13)
        Me.KryptonPanel1.Controls.Add(Me.GroupBox5)
        Me.KryptonPanel1.Controls.Add(Me.GroupBox7)
        Me.KryptonPanel1.Controls.Add(Me.grpAutomation)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(3, 4)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Palette = Me.KryptonPalette1
        Me.KryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel1.Size = New System.Drawing.Size(770, 471)
        Me.KryptonPanel1.TabIndex = 53
        '
        'GroupBox14
        '
        Me.GroupBox14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox14.AutoSize = True
        Me.GroupBox14.Controls.Add(Me.lblNewMessageStaysOpenCalculation)
        Me.GroupBox14.Controls.Add(Me.Label44)
        Me.GroupBox14.Controls.Add(Me.Label43)
        Me.GroupBox14.Controls.Add(Me.nudNewMessageNotifyStaysOpen)
        Me.GroupBox14.Controls.Add(Me.btnResetAllHiddenNotices)
        Me.GroupBox14.Controls.Add(Me.Label36)
        Me.GroupBox14.Controls.Add(Me.btnPlaySelectedNotifySound)
        Me.GroupBox14.Controls.Add(Me.cboNewMessageNoticeSound)
        Me.GroupBox14.Controls.Add(Me.chkPlaySoundNewMessages)
        Me.GroupBox14.Controls.Add(Me.chkShowNoticeForNewMessages)
        Me.GroupBox14.Location = New System.Drawing.Point(6, 318)
        Me.GroupBox14.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox14.Size = New System.Drawing.Size(762, 164)
        Me.GroupBox14.TabIndex = 12
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Notification"
        '
        'lblNewMessageStaysOpenCalculation
        '
        Me.lblNewMessageStaysOpenCalculation.AutoSize = True
        Me.lblNewMessageStaysOpenCalculation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewMessageStaysOpenCalculation.ForeColor = System.Drawing.Color.Maroon
        Me.lblNewMessageStaysOpenCalculation.Location = New System.Drawing.Point(443, 83)
        Me.lblNewMessageStaysOpenCalculation.Name = "lblNewMessageStaysOpenCalculation"
        Me.lblNewMessageStaysOpenCalculation.Size = New System.Drawing.Size(0, 16)
        Me.lblNewMessageStaysOpenCalculation.TabIndex = 37
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(364, 83)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(57, 16)
        Me.Label44.TabIndex = 36
        Me.Label44.Text = "seconds"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(16, 83)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(117, 16)
        Me.Label43.TabIndex = 35
        Me.Label43.Text = "Notice stays open:"
        '
        'nudNewMessageNotifyStaysOpen
        '
        Me.nudNewMessageNotifyStaysOpen.DecimalPlaces = 1
        Me.nudNewMessageNotifyStaysOpen.Location = New System.Drawing.Point(261, 81)
        Me.nudNewMessageNotifyStaysOpen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudNewMessageNotifyStaysOpen.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nudNewMessageNotifyStaysOpen.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNewMessageNotifyStaysOpen.Name = "nudNewMessageNotifyStaysOpen"
        Me.nudNewMessageNotifyStaysOpen.Size = New System.Drawing.Size(91, 22)
        Me.nudNewMessageNotifyStaysOpen.TabIndex = 34
        Me.nudNewMessageNotifyStaysOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudNewMessageNotifyStaysOpen.ThousandsSeparator = True
        Me.nudNewMessageNotifyStaysOpen.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnResetAllHiddenNotices
        '
        Me.btnResetAllHiddenNotices.Location = New System.Drawing.Point(260, 108)
        Me.btnResetAllHiddenNotices.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnResetAllHiddenNotices.Name = "btnResetAllHiddenNotices"
        Me.btnResetAllHiddenNotices.Size = New System.Drawing.Size(136, 33)
        Me.btnResetAllHiddenNotices.TabIndex = 0
        Me.btnResetAllHiddenNotices.Text = "&Reset Notices"
        Me.btnResetAllHiddenNotices.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(15, 114)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(193, 16)
        Me.Label36.TabIndex = 11
        Me.Label36.Text = "Reset all notices to show again:"
        '
        'btnPlaySelectedNotifySound
        '
        Me.btnPlaySelectedNotifySound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPlaySelectedNotifySound.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlaySelectedNotifySound.Image = Global.TrulyMail.My.Resources.Resources.PlayButton_16
        Me.btnPlaySelectedNotifySound.Location = New System.Drawing.Point(685, 47)
        Me.btnPlaySelectedNotifySound.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPlaySelectedNotifySound.Name = "btnPlaySelectedNotifySound"
        Me.btnPlaySelectedNotifySound.Size = New System.Drawing.Size(37, 28)
        Me.btnPlaySelectedNotifySound.TabIndex = 33
        Me.ToolTip1.SetToolTip(Me.btnPlaySelectedNotifySound, "Play selected sound")
        Me.btnPlaySelectedNotifySound.UseVisualStyleBackColor = True
        '
        'cboNewMessageNoticeSound
        '
        Me.cboNewMessageNoticeSound.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboNewMessageNoticeSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNewMessageNoticeSound.FormattingEnabled = True
        Me.cboNewMessageNoticeSound.Items.AddRange(New Object() {"Windows 'New Mail' sound"})
        Me.cboNewMessageNoticeSound.Location = New System.Drawing.Point(261, 49)
        Me.cboNewMessageNoticeSound.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboNewMessageNoticeSound.Name = "cboNewMessageNoticeSound"
        Me.cboNewMessageNoticeSound.Size = New System.Drawing.Size(418, 24)
        Me.cboNewMessageNoticeSound.TabIndex = 10
        '
        'chkPlaySoundNewMessages
        '
        Me.chkPlaySoundNewMessages.AutoSize = True
        Me.chkPlaySoundNewMessages.Checked = True
        Me.chkPlaySoundNewMessages.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPlaySoundNewMessages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPlaySoundNewMessages.Location = New System.Drawing.Point(19, 51)
        Me.chkPlaySoundNewMessages.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkPlaySoundNewMessages.Name = "chkPlaySoundNewMessages"
        Me.chkPlaySoundNewMessages.Size = New System.Drawing.Size(201, 20)
        Me.chkPlaySoundNewMessages.TabIndex = 9
        Me.chkPlaySoundNewMessages.Text = "Play sound for new messages"
        Me.chkPlaySoundNewMessages.UseVisualStyleBackColor = True
        '
        'chkShowNoticeForNewMessages
        '
        Me.chkShowNoticeForNewMessages.AutoSize = True
        Me.chkShowNoticeForNewMessages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowNoticeForNewMessages.Location = New System.Drawing.Point(19, 25)
        Me.chkShowNoticeForNewMessages.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkShowNoticeForNewMessages.Name = "chkShowNoticeForNewMessages"
        Me.chkShowNoticeForNewMessages.Size = New System.Drawing.Size(233, 20)
        Me.chkShowNoticeForNewMessages.TabIndex = 8
        Me.chkShowNoticeForNewMessages.Text = "Show tray notice for new messages"
        Me.chkShowNoticeForNewMessages.UseVisualStyleBackColor = True
        '
        'GroupBox21
        '
        Me.GroupBox21.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox21.AutoSize = True
        Me.GroupBox21.Controls.Add(Me.chkPreviewPanePlainText)
        Me.GroupBox21.Controls.Add(Me.cboDateFormat)
        Me.GroupBox21.Controls.Add(Me.Label45)
        Me.GroupBox21.Location = New System.Drawing.Point(369, 76)
        Me.GroupBox21.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox21.Size = New System.Drawing.Size(396, 113)
        Me.GroupBox21.TabIndex = 14
        Me.GroupBox21.TabStop = False
        Me.GroupBox21.Text = "Reading"
        '
        'chkPreviewPanePlainText
        '
        Me.chkPreviewPanePlainText.AutoSize = True
        Me.chkPreviewPanePlainText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPreviewPanePlainText.Location = New System.Drawing.Point(10, 70)
        Me.chkPreviewPanePlainText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkPreviewPanePlainText.Name = "chkPreviewPanePlainText"
        Me.chkPreviewPanePlainText.Size = New System.Drawing.Size(321, 20)
        Me.chkPreviewPanePlainText.TabIndex = 34
        Me.chkPreviewPanePlainText.Text = "Preview pane to read as plain text (requires restart)"
        Me.chkPreviewPanePlainText.UseVisualStyleBackColor = True
        '
        'cboDateFormat
        '
        Me.cboDateFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDateFormat.FormattingEnabled = True
        Me.cboDateFormat.Location = New System.Drawing.Point(92, 28)
        Me.cboDateFormat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboDateFormat.Name = "cboDateFormat"
        Me.cboDateFormat.Size = New System.Drawing.Size(288, 24)
        Me.cboDateFormat.TabIndex = 11
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(7, 31)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(79, 16)
        Me.Label45.TabIndex = 12
        Me.Label45.Text = "Date format:"
        '
        'GroupBox13
        '
        Me.GroupBox13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox13.AutoSize = True
        Me.GroupBox13.Controls.Add(Me.Label21)
        Me.GroupBox13.Controls.Add(Me.Label20)
        Me.GroupBox13.Controls.Add(Me.nudDelayWhenCannotSend)
        Me.GroupBox13.Location = New System.Drawing.Point(6, 220)
        Me.GroupBox13.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox13.Size = New System.Drawing.Size(340, 94)
        Me.GroupBox13.TabIndex = 11
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Delays"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(73, 49)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(86, 16)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "minutes later."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(7, 23)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(278, 16)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "When message cannot be sent, reschedule for"
        '
        'nudDelayWhenCannotSend
        '
        Me.nudDelayWhenCannotSend.Location = New System.Drawing.Point(12, 49)
        Me.nudDelayWhenCannotSend.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudDelayWhenCannotSend.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudDelayWhenCannotSend.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudDelayWhenCannotSend.Name = "nudDelayWhenCannotSend"
        Me.nudDelayWhenCannotSend.Size = New System.Drawing.Size(56, 22)
        Me.nudDelayWhenCannotSend.TabIndex = 11
        Me.nudDelayWhenCannotSend.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudDelayWhenCannotSend.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'GroupBox5
        '
        Me.GroupBox5.AutoSize = True
        Me.GroupBox5.Controls.Add(Me.chkRemoveDiacriticsOnReceive)
        Me.GroupBox5.Controls.Add(Me.chkHideOutboxCountPastToday)
        Me.GroupBox5.Controls.Add(Me.chkUseLargeSendReceiveButton)
        Me.GroupBox5.Controls.Add(Me.chkToolBarsIncludeText)
        Me.GroupBox5.Controls.Add(Me.chkUseLargeToolbarIcons)
        Me.GroupBox5.Controls.Add(Me.chkMinimizeToTray)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox5.Size = New System.Drawing.Size(352, 207)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Look and Feel"
        '
        'chkRemoveDiacriticsOnReceive
        '
        Me.chkRemoveDiacriticsOnReceive.AutoSize = True
        Me.chkRemoveDiacriticsOnReceive.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRemoveDiacriticsOnReceive.Location = New System.Drawing.Point(19, 159)
        Me.chkRemoveDiacriticsOnReceive.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkRemoveDiacriticsOnReceive.Name = "chkRemoveDiacriticsOnReceive"
        Me.chkRemoveDiacriticsOnReceive.Size = New System.Drawing.Size(191, 20)
        Me.chkRemoveDiacriticsOnReceive.TabIndex = 33
        Me.chkRemoveDiacriticsOnReceive.Text = "Remove diacritics on receive"
        Me.chkRemoveDiacriticsOnReceive.UseVisualStyleBackColor = True
        '
        'chkHideOutboxCountPastToday
        '
        Me.chkHideOutboxCountPastToday.AutoSize = True
        Me.chkHideOutboxCountPastToday.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHideOutboxCountPastToday.Location = New System.Drawing.Point(19, 134)
        Me.chkHideOutboxCountPastToday.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkHideOutboxCountPastToday.Name = "chkHideOutboxCountPastToday"
        Me.chkHideOutboxCountPastToday.Size = New System.Drawing.Size(197, 20)
        Me.chkHideOutboxCountPastToday.TabIndex = 32
        Me.chkHideOutboxCountPastToday.Text = "Hide outbox count past today"
        Me.ToolTip1.SetToolTip(Me.chkHideOutboxCountPastToday, "Unchecked means to show all messages in outbox as unread")
        Me.chkHideOutboxCountPastToday.UseVisualStyleBackColor = True
        '
        'chkUseLargeSendReceiveButton
        '
        Me.chkUseLargeSendReceiveButton.AutoSize = True
        Me.chkUseLargeSendReceiveButton.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUseLargeSendReceiveButton.Location = New System.Drawing.Point(19, 106)
        Me.chkUseLargeSendReceiveButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkUseLargeSendReceiveButton.Name = "chkUseLargeSendReceiveButton"
        Me.chkUseLargeSendReceiveButton.Size = New System.Drawing.Size(252, 20)
        Me.chkUseLargeSendReceiveButton.TabIndex = 9
        Me.chkUseLargeSendReceiveButton.Text = "Use large all account drop down button"
        Me.chkUseLargeSendReceiveButton.UseVisualStyleBackColor = True
        '
        'chkToolBarsIncludeText
        '
        Me.chkToolBarsIncludeText.AutoSize = True
        Me.chkToolBarsIncludeText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkToolBarsIncludeText.Location = New System.Drawing.Point(19, 49)
        Me.chkToolBarsIncludeText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkToolBarsIncludeText.Name = "chkToolBarsIncludeText"
        Me.chkToolBarsIncludeText.Size = New System.Drawing.Size(186, 20)
        Me.chkToolBarsIncludeText.TabIndex = 8
        Me.chkToolBarsIncludeText.Text = "Toolbar buttons include text"
        Me.chkToolBarsIncludeText.UseVisualStyleBackColor = True
        '
        'chkUseLargeToolbarIcons
        '
        Me.chkUseLargeToolbarIcons.AutoSize = True
        Me.chkUseLargeToolbarIcons.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUseLargeToolbarIcons.Location = New System.Drawing.Point(19, 21)
        Me.chkUseLargeToolbarIcons.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkUseLargeToolbarIcons.Name = "chkUseLargeToolbarIcons"
        Me.chkUseLargeToolbarIcons.Size = New System.Drawing.Size(160, 20)
        Me.chkUseLargeToolbarIcons.TabIndex = 6
        Me.chkUseLargeToolbarIcons.Text = "Use large toolbar icons"
        Me.chkUseLargeToolbarIcons.UseVisualStyleBackColor = True
        '
        'chkMinimizeToTray
        '
        Me.chkMinimizeToTray.AutoSize = True
        Me.chkMinimizeToTray.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMinimizeToTray.Location = New System.Drawing.Point(19, 78)
        Me.chkMinimizeToTray.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkMinimizeToTray.Name = "chkMinimizeToTray"
        Me.chkMinimizeToTray.Size = New System.Drawing.Size(167, 20)
        Me.chkMinimizeToTray.TabIndex = 7
        Me.chkMinimizeToTray.Text = "Minimize to system tray"
        Me.chkMinimizeToTray.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.AutoSize = True
        Me.GroupBox7.Controls.Add(Me.cboReplyPostingMode)
        Me.GroupBox7.Controls.Add(Me.txtDefaultSubject)
        Me.GroupBox7.Controls.Add(Me.Label19)
        Me.GroupBox7.Controls.Add(Me.Label14)
        Me.GroupBox7.Location = New System.Drawing.Point(369, 220)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox7.Size = New System.Drawing.Size(396, 95)
        Me.GroupBox7.TabIndex = 8
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Message Defaults"
        '
        'cboReplyPostingMode
        '
        Me.cboReplyPostingMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboReplyPostingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReplyPostingMode.FormattingEnabled = True
        Me.cboReplyPostingMode.Items.AddRange(New Object() {"Above the existing message", "Below the existing message"})
        Me.cboReplyPostingMode.Location = New System.Drawing.Point(124, 48)
        Me.cboReplyPostingMode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboReplyPostingMode.Name = "cboReplyPostingMode"
        Me.cboReplyPostingMode.Size = New System.Drawing.Size(256, 24)
        Me.cboReplyPostingMode.TabIndex = 1
        '
        'txtDefaultSubject
        '
        Me.txtDefaultSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDefaultSubject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDefaultSubject.Location = New System.Drawing.Point(205, 17)
        Me.txtDefaultSubject.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDefaultSubject.MaxLength = 70
        Me.txtDefaultSubject.Name = "txtDefaultSubject"
        Me.txtDefaultSubject.Size = New System.Drawing.Size(174, 22)
        Me.txtDefaultSubject.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(7, 53)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(94, 16)
        Me.Label19.TabIndex = 10
        Me.Label19.Text = "Start my reply:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(7, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(171, 16)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Empty subject replacement:"
        '
        'grpAutomation
        '
        Me.grpAutomation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAutomation.Controls.Add(Me.chkEmptyTrashOnExit)
        Me.grpAutomation.Controls.Add(Me.Label22)
        Me.grpAutomation.Controls.Add(Me.nudTrashDaysToRetain)
        Me.grpAutomation.Controls.Add(Me.chkAutoEmptyTrash)
        Me.grpAutomation.Location = New System.Drawing.Point(369, 7)
        Me.grpAutomation.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpAutomation.Name = "grpAutomation"
        Me.grpAutomation.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpAutomation.Size = New System.Drawing.Size(383, 67)
        Me.grpAutomation.TabIndex = 8
        Me.grpAutomation.TabStop = False
        Me.grpAutomation.Text = "Trash"
        '
        'chkEmptyTrashOnExit
        '
        Me.chkEmptyTrashOnExit.AutoSize = True
        Me.chkEmptyTrashOnExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEmptyTrashOnExit.Location = New System.Drawing.Point(10, 41)
        Me.chkEmptyTrashOnExit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkEmptyTrashOnExit.Name = "chkEmptyTrashOnExit"
        Me.chkEmptyTrashOnExit.Size = New System.Drawing.Size(208, 20)
        Me.chkEmptyTrashOnExit.TabIndex = 13
        Me.chkEmptyTrashOnExit.Text = "Completely empty trash on exit"
        Me.chkEmptyTrashOnExit.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(286, 21)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 16)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "days."
        '
        'nudTrashDaysToRetain
        '
        Me.nudTrashDaysToRetain.Location = New System.Drawing.Point(227, 19)
        Me.nudTrashDaysToRetain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudTrashDaysToRetain.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudTrashDaysToRetain.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudTrashDaysToRetain.Name = "nudTrashDaysToRetain"
        Me.nudTrashDaysToRetain.Size = New System.Drawing.Size(51, 22)
        Me.nudTrashDaysToRetain.TabIndex = 12
        Me.nudTrashDaysToRetain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudTrashDaysToRetain.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'chkAutoEmptyTrash
        '
        Me.chkAutoEmptyTrash.AutoSize = True
        Me.chkAutoEmptyTrash.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoEmptyTrash.Location = New System.Drawing.Point(10, 19)
        Me.chkAutoEmptyTrash.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkAutoEmptyTrash.Name = "chkAutoEmptyTrash"
        Me.chkAutoEmptyTrash.Size = New System.Drawing.Size(184, 20)
        Me.chkAutoEmptyTrash.TabIndex = 10
        Me.chkAutoEmptyTrash.Text = "Auto-delete from trash after"
        Me.chkAutoEmptyTrash.UseVisualStyleBackColor = True
        '
        'tabMessageList
        '
        Me.tabMessageList.Controls.Add(Me.KryptonPanel4)
        Me.tabMessageList.Location = New System.Drawing.Point(4, 25)
        Me.tabMessageList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabMessageList.Name = "tabMessageList"
        Me.tabMessageList.Size = New System.Drawing.Size(776, 479)
        Me.tabMessageList.TabIndex = 8
        Me.tabMessageList.Text = "Message List"
        Me.tabMessageList.UseVisualStyleBackColor = True
        '
        'KryptonPanel4
        '
        Me.KryptonPanel4.Controls.Add(Me.GroupBox28)
        Me.KryptonPanel4.Controls.Add(Me.GroupBox17)
        Me.KryptonPanel4.Controls.Add(Me.GroupBox18)
        Me.KryptonPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel4.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel4.Name = "KryptonPanel4"
        Me.KryptonPanel4.Palette = Me.KryptonPalette1
        Me.KryptonPanel4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel4.Size = New System.Drawing.Size(776, 479)
        Me.KryptonPanel4.TabIndex = 52
        '
        'GroupBox28
        '
        Me.GroupBox28.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox28.AutoSize = True
        Me.GroupBox28.Controls.Add(Me.chkAutoSizeMessageListColumns)
        Me.GroupBox28.Controls.Add(Me.lblAlternatingRowColor)
        Me.GroupBox28.Controls.Add(Me.Label58)
        Me.GroupBox28.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox28.Location = New System.Drawing.Point(30, 249)
        Me.GroupBox28.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox28.Name = "GroupBox28"
        Me.GroupBox28.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox28.Size = New System.Drawing.Size(710, 69)
        Me.GroupBox28.TabIndex = 16
        Me.GroupBox28.TabStop = False
        Me.GroupBox28.Text = "Message List"
        '
        'chkAutoSizeMessageListColumns
        '
        Me.chkAutoSizeMessageListColumns.AutoSize = True
        Me.chkAutoSizeMessageListColumns.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoSizeMessageListColumns.Location = New System.Drawing.Point(21, 26)
        Me.chkAutoSizeMessageListColumns.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkAutoSizeMessageListColumns.Name = "chkAutoSizeMessageListColumns"
        Me.chkAutoSizeMessageListColumns.Size = New System.Drawing.Size(146, 20)
        Me.chkAutoSizeMessageListColumns.TabIndex = 15
        Me.chkAutoSizeMessageListColumns.Text = "Auto-resize columns"
        Me.ToolTip1.SetToolTip(Me.chkAutoSizeMessageListColumns, "Check to have TrulyMail resize the message list columns when messages are added")
        Me.chkAutoSizeMessageListColumns.UseVisualStyleBackColor = True
        '
        'lblAlternatingRowColor
        '
        Me.lblAlternatingRowColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAlternatingRowColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblAlternatingRowColor.Location = New System.Drawing.Point(433, 20)
        Me.lblAlternatingRowColor.Name = "lblAlternatingRowColor"
        Me.lblAlternatingRowColor.Size = New System.Drawing.Size(39, 28)
        Me.lblAlternatingRowColor.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.lblAlternatingRowColor, "Click to change the color for this tag")
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(277, 27)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(130, 16)
        Me.Label58.TabIndex = 5
        Me.Label58.Text = "Alternating row color:"
        '
        'GroupBox17
        '
        Me.GroupBox17.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox17.AutoSize = True
        Me.GroupBox17.Controls.Add(Me.pbMoveMessageTagDown)
        Me.GroupBox17.Controls.Add(Me.pbMoveMessageTagUp)
        Me.GroupBox17.Controls.Add(Me.pbUpdateMessageTag)
        Me.GroupBox17.Controls.Add(Me.pbDeleteMessageTag)
        Me.GroupBox17.Controls.Add(Me.pbAddNewMessageTag)
        Me.GroupBox17.Controls.Add(Me.GroupBox16)
        Me.GroupBox17.Controls.Add(Me.lstMessageTags)
        Me.GroupBox17.Controls.Add(Me.Label32)
        Me.GroupBox17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox17.Location = New System.Drawing.Point(30, 23)
        Me.GroupBox17.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox17.Size = New System.Drawing.Size(726, 222)
        Me.GroupBox17.TabIndex = 8
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "Message Tags"
        '
        'pbMoveMessageTagDown
        '
        Me.pbMoveMessageTagDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbMoveMessageTagDown.Image = Global.TrulyMail.My.Resources.Resources.BlueArrowDown_32
        Me.pbMoveMessageTagDown.Location = New System.Drawing.Point(666, 116)
        Me.pbMoveMessageTagDown.Name = "pbMoveMessageTagDown"
        Me.pbMoveMessageTagDown.Size = New System.Drawing.Size(36, 36)
        Me.pbMoveMessageTagDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbMoveMessageTagDown.TabIndex = 22
        Me.pbMoveMessageTagDown.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbMoveMessageTagDown, "Move selected message tag down")
        '
        'pbMoveMessageTagUp
        '
        Me.pbMoveMessageTagUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbMoveMessageTagUp.Image = Global.TrulyMail.My.Resources.Resources.BlueArrowUp_32
        Me.pbMoveMessageTagUp.Location = New System.Drawing.Point(666, 77)
        Me.pbMoveMessageTagUp.Name = "pbMoveMessageTagUp"
        Me.pbMoveMessageTagUp.Size = New System.Drawing.Size(36, 36)
        Me.pbMoveMessageTagUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbMoveMessageTagUp.TabIndex = 21
        Me.pbMoveMessageTagUp.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbMoveMessageTagUp, "Move selected message tag up")
        '
        'pbUpdateMessageTag
        '
        Me.pbUpdateMessageTag.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbUpdateMessageTag.Image = Global.TrulyMail.My.Resources.Resources.Savefile_32
        Me.pbUpdateMessageTag.Location = New System.Drawing.Point(259, 158)
        Me.pbUpdateMessageTag.Name = "pbUpdateMessageTag"
        Me.pbUpdateMessageTag.Size = New System.Drawing.Size(36, 36)
        Me.pbUpdateMessageTag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbUpdateMessageTag.TabIndex = 20
        Me.pbUpdateMessageTag.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbUpdateMessageTag, "Change selected message tag")
        '
        'pbDeleteMessageTag
        '
        Me.pbDeleteMessageTag.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbDeleteMessageTag.Image = Global.TrulyMail.My.Resources.Resources.remove_icon_48
        Me.pbDeleteMessageTag.Location = New System.Drawing.Point(259, 116)
        Me.pbDeleteMessageTag.Name = "pbDeleteMessageTag"
        Me.pbDeleteMessageTag.Size = New System.Drawing.Size(36, 36)
        Me.pbDeleteMessageTag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbDeleteMessageTag.TabIndex = 19
        Me.pbDeleteMessageTag.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbDeleteMessageTag, "Remove selected message tag")
        '
        'pbAddNewMessageTag
        '
        Me.pbAddNewMessageTag.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbAddNewMessageTag.Image = Global.TrulyMail.My.Resources.Resources.add_icon_48
        Me.pbAddNewMessageTag.Location = New System.Drawing.Point(259, 77)
        Me.pbAddNewMessageTag.Name = "pbAddNewMessageTag"
        Me.pbAddNewMessageTag.Size = New System.Drawing.Size(36, 36)
        Me.pbAddNewMessageTag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddNewMessageTag.TabIndex = 18
        Me.pbAddNewMessageTag.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbAddNewMessageTag, "Add new message tag")
        '
        'GroupBox16
        '
        Me.GroupBox16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox16.AutoSize = True
        Me.GroupBox16.Controls.Add(Me.lblMessageTagColor)
        Me.GroupBox16.Controls.Add(Me.Label31)
        Me.GroupBox16.Controls.Add(Me.Label30)
        Me.GroupBox16.Controls.Add(Me.txtNewMessageTagText)
        Me.GroupBox16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox16.Location = New System.Drawing.Point(21, 66)
        Me.GroupBox16.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox16.Size = New System.Drawing.Size(233, 133)
        Me.GroupBox16.TabIndex = 2
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "New Message Tag"
        '
        'lblMessageTagColor
        '
        Me.lblMessageTagColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMessageTagColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblMessageTagColor.Location = New System.Drawing.Point(64, 50)
        Me.lblMessageTagColor.Name = "lblMessageTagColor"
        Me.lblMessageTagColor.Size = New System.Drawing.Size(39, 28)
        Me.lblMessageTagColor.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.lblMessageTagColor, "Click to change the color for this tag")
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(7, 54)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(42, 16)
        Me.Label31.TabIndex = 3
        Me.Label31.Text = "Color:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(7, 27)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(43, 16)
        Me.Label30.TabIndex = 2
        Me.Label30.Text = "Label:"
        '
        'txtNewMessageTagText
        '
        Me.txtNewMessageTagText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewMessageTagText.Location = New System.Drawing.Point(64, 23)
        Me.txtNewMessageTagText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNewMessageTagText.Name = "txtNewMessageTagText"
        Me.txtNewMessageTagText.Size = New System.Drawing.Size(161, 22)
        Me.txtNewMessageTagText.TabIndex = 1
        '
        'lstMessageTags
        '
        Me.lstMessageTags.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstMessageTags.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.lstMessageTags.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstMessageTags.FormattingEnabled = True
        Me.lstMessageTags.ItemHeight = 18
        Me.lstMessageTags.Location = New System.Drawing.Point(311, 77)
        Me.lstMessageTags.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lstMessageTags.Name = "lstMessageTags"
        Me.lstMessageTags.Size = New System.Drawing.Size(349, 121)
        Me.lstMessageTags.TabIndex = 0
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(21, 25)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(583, 48)
        Me.Label32.TabIndex = 7
        Me.Label32.Text = "These message tags will be used for color-coding but you can always manually ente" &
    "r any tag you wish by typing directly into the Tags column."
        '
        'GroupBox18
        '
        Me.GroupBox18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox18.AutoSize = True
        Me.GroupBox18.Controls.Add(Me.chkMaintainMessageZoom)
        Me.GroupBox18.Controls.Add(Me.chkShowReadingZoomBar)
        Me.GroupBox18.Controls.Add(Me.Label33)
        Me.GroupBox18.Controls.Add(Me.nudLoadMessagePreviewDelay)
        Me.GroupBox18.Controls.Add(Me.Label35)
        Me.GroupBox18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox18.Location = New System.Drawing.Point(30, 323)
        Me.GroupBox18.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox18.Size = New System.Drawing.Size(710, 130)
        Me.GroupBox18.TabIndex = 6
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "Message Preview"
        '
        'chkMaintainMessageZoom
        '
        Me.chkMaintainMessageZoom.AutoSize = True
        Me.chkMaintainMessageZoom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMaintainMessageZoom.Location = New System.Drawing.Point(21, 87)
        Me.chkMaintainMessageZoom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkMaintainMessageZoom.Name = "chkMaintainMessageZoom"
        Me.chkMaintainMessageZoom.Size = New System.Drawing.Size(538, 20)
        Me.chkMaintainMessageZoom.TabIndex = 15
        Me.chkMaintainMessageZoom.Text = "Maintain message zoom level (uncheck to restore to 100% when loading each message" &
    ")"
        Me.chkMaintainMessageZoom.UseVisualStyleBackColor = True
        '
        'chkShowReadingZoomBar
        '
        Me.chkShowReadingZoomBar.AutoSize = True
        Me.chkShowReadingZoomBar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowReadingZoomBar.Location = New System.Drawing.Point(21, 63)
        Me.chkShowReadingZoomBar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkShowReadingZoomBar.Name = "chkShowReadingZoomBar"
        Me.chkShowReadingZoomBar.Size = New System.Drawing.Size(261, 20)
        Me.chkShowReadingZoomBar.TabIndex = 14
        Me.chkShowReadingZoomBar.Text = "Show zoom bar when reading messages"
        Me.chkShowReadingZoomBar.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(226, 35)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(69, 16)
        Me.Label33.TabIndex = 11
        Me.Label33.Text = "second(s)."
        '
        'nudLoadMessagePreviewDelay
        '
        Me.nudLoadMessagePreviewDelay.DecimalPlaces = 1
        Me.nudLoadMessagePreviewDelay.Increment = New Decimal(New Integer() {2, 0, 0, 65536})
        Me.nudLoadMessagePreviewDelay.Location = New System.Drawing.Point(168, 33)
        Me.nudLoadMessagePreviewDelay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudLoadMessagePreviewDelay.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudLoadMessagePreviewDelay.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudLoadMessagePreviewDelay.Name = "nudLoadMessagePreviewDelay"
        Me.nudLoadMessagePreviewDelay.Size = New System.Drawing.Size(51, 22)
        Me.nudLoadMessagePreviewDelay.TabIndex = 10
        Me.nudLoadMessagePreviewDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudLoadMessagePreviewDelay.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(18, 35)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(122, 16)
        Me.Label35.TabIndex = 2
        Me.Label35.Text = "Load message after"
        '
        'tabEmail
        '
        Me.tabEmail.Controls.Add(Me.KryptonPanel5)
        Me.tabEmail.Location = New System.Drawing.Point(4, 25)
        Me.tabEmail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabEmail.Name = "tabEmail"
        Me.tabEmail.Size = New System.Drawing.Size(776, 479)
        Me.tabEmail.TabIndex = 7
        Me.tabEmail.Text = "Email"
        Me.tabEmail.UseVisualStyleBackColor = True
        '
        'KryptonPanel5
        '
        Me.KryptonPanel5.Controls.Add(Me.chkAutoZipEmailAttachments)
        Me.KryptonPanel5.Controls.Add(Me.GroupBox9)
        Me.KryptonPanel5.Controls.Add(Me.GroupBox26)
        Me.KryptonPanel5.Controls.Add(Me.chkEmailAutoAddRecipientsToAddressBook)
        Me.KryptonPanel5.Controls.Add(Me.chkReplyToPlainTextIsPlainText)
        Me.KryptonPanel5.Controls.Add(Me.chkAutoReturnReceipt)
        Me.KryptonPanel5.Controls.Add(Me.chkEmailAutoAddRecipientsTieSMTP)
        Me.KryptonPanel5.Controls.Add(Me.chkBlockRemoteImages)
        Me.KryptonPanel5.Controls.Add(Me.GroupBox20)
        Me.KryptonPanel5.Controls.Add(Me.chkNeverProcessEmailReturnReceipts)
        Me.KryptonPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel5.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel5.Name = "KryptonPanel5"
        Me.KryptonPanel5.Palette = Me.KryptonPalette1
        Me.KryptonPanel5.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel5.Size = New System.Drawing.Size(776, 479)
        Me.KryptonPanel5.TabIndex = 52
        '
        'chkAutoZipEmailAttachments
        '
        Me.chkAutoZipEmailAttachments.AutoSize = True
        Me.chkAutoZipEmailAttachments.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoZipEmailAttachments.Location = New System.Drawing.Point(397, 121)
        Me.chkAutoZipEmailAttachments.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkAutoZipEmailAttachments.Name = "chkAutoZipEmailAttachments"
        Me.chkAutoZipEmailAttachments.Size = New System.Drawing.Size(307, 20)
        Me.chkAutoZipEmailAttachments.TabIndex = 16
        Me.chkAutoZipEmailAttachments.Text = "Automatically zip (compress) email attachments"
        Me.ToolTip1.SetToolTip(Me.chkAutoZipEmailAttachments, "Check this to automatically send all attachments as a compressed zip file")
        Me.chkAutoZipEmailAttachments.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox9.Controls.Add(Me.rbtnEmailShowSenderAsAddressBook)
        Me.GroupBox9.Controls.Add(Me.rbtnEmailShowSenderAsSent)
        Me.GroupBox9.Controls.Add(Me.Label16)
        Me.GroupBox9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(8, 158)
        Me.GroupBox9.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox9.Size = New System.Drawing.Size(341, 126)
        Me.GroupBox9.TabIndex = 8
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Sender Name"
        '
        'rbtnEmailShowSenderAsAddressBook
        '
        Me.rbtnEmailShowSenderAsAddressBook.AutoSize = True
        Me.rbtnEmailShowSenderAsAddressBook.Location = New System.Drawing.Point(22, 97)
        Me.rbtnEmailShowSenderAsAddressBook.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtnEmailShowSenderAsAddressBook.Name = "rbtnEmailShowSenderAsAddressBook"
        Me.rbtnEmailShowSenderAsAddressBook.Size = New System.Drawing.Size(273, 20)
        Me.rbtnEmailShowSenderAsAddressBook.TabIndex = 1
        Me.rbtnEmailShowSenderAsAddressBook.Text = "The name in my address book (my choice)"
        Me.rbtnEmailShowSenderAsAddressBook.UseVisualStyleBackColor = True
        '
        'rbtnEmailShowSenderAsSent
        '
        Me.rbtnEmailShowSenderAsSent.AutoSize = True
        Me.rbtnEmailShowSenderAsSent.Checked = True
        Me.rbtnEmailShowSenderAsSent.Location = New System.Drawing.Point(22, 68)
        Me.rbtnEmailShowSenderAsSent.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtnEmailShowSenderAsSent.Name = "rbtnEmailShowSenderAsSent"
        Me.rbtnEmailShowSenderAsSent.Size = New System.Drawing.Size(216, 20)
        Me.rbtnEmailShowSenderAsSent.TabIndex = 0
        Me.rbtnEmailShowSenderAsSent.TabStop = True
        Me.rbtnEmailShowSenderAsSent.Text = "Their name as sent (their choice)"
        Me.rbtnEmailShowSenderAsSent.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(19, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(316, 38)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "When receiving emails, if the sender is in my address book then the name of the s" &
    "ender should show as..."
        '
        'GroupBox26
        '
        Me.GroupBox26.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox26.Controls.Add(Me.btnChangeFontForPlainText)
        Me.GroupBox26.Controls.Add(Me.lblFontForPlainText)
        Me.GroupBox26.Controls.Add(Me.Label54)
        Me.GroupBox26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox26.Location = New System.Drawing.Point(371, 158)
        Me.GroupBox26.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox26.Name = "GroupBox26"
        Me.GroupBox26.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox26.Size = New System.Drawing.Size(382, 126)
        Me.GroupBox26.TabIndex = 9
        Me.GroupBox26.TabStop = False
        Me.GroupBox26.Text = "Plain Text"
        '
        'btnChangeFontForPlainText
        '
        Me.btnChangeFontForPlainText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangeFontForPlainText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeFontForPlainText.Location = New System.Drawing.Point(248, 42)
        Me.btnChangeFontForPlainText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnChangeFontForPlainText.Name = "btnChangeFontForPlainText"
        Me.btnChangeFontForPlainText.Size = New System.Drawing.Size(91, 28)
        Me.btnChangeFontForPlainText.TabIndex = 31
        Me.btnChangeFontForPlainText.Text = "Chan&ge"
        Me.btnChangeFontForPlainText.UseVisualStyleBackColor = True
        '
        'lblFontForPlainText
        '
        Me.lblFontForPlainText.AutoSize = True
        Me.lblFontForPlainText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFontForPlainText.Location = New System.Drawing.Point(36, 48)
        Me.lblFontForPlainText.Name = "lblFontForPlainText"
        Me.lblFontForPlainText.Size = New System.Drawing.Size(222, 16)
        Me.lblFontForPlainText.TabIndex = 16
        Me.lblFontForPlainText.Text = "Use this font when reading plain text:"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(6, 26)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(222, 16)
        Me.Label54.TabIndex = 15
        Me.Label54.Text = "Use this font when reading plain text:"
        '
        'chkEmailAutoAddRecipientsToAddressBook
        '
        Me.chkEmailAutoAddRecipientsToAddressBook.AutoSize = True
        Me.chkEmailAutoAddRecipientsToAddressBook.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEmailAutoAddRecipientsToAddressBook.Location = New System.Drawing.Point(13, 25)
        Me.chkEmailAutoAddRecipientsToAddressBook.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkEmailAutoAddRecipientsToAddressBook.Name = "chkEmailAutoAddRecipientsToAddressBook"
        Me.chkEmailAutoAddRecipientsToAddressBook.Size = New System.Drawing.Size(406, 20)
        Me.chkEmailAutoAddRecipientsToAddressBook.TabIndex = 7
        Me.chkEmailAutoAddRecipientsToAddressBook.Text = "Automatically add email recipients to address book when sending"
        Me.chkEmailAutoAddRecipientsToAddressBook.UseVisualStyleBackColor = True
        '
        'chkReplyToPlainTextIsPlainText
        '
        Me.chkReplyToPlainTextIsPlainText.AutoSize = True
        Me.chkReplyToPlainTextIsPlainText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkReplyToPlainTextIsPlainText.Location = New System.Drawing.Point(397, 97)
        Me.chkReplyToPlainTextIsPlainText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkReplyToPlainTextIsPlainText.Name = "chkReplyToPlainTextIsPlainText"
        Me.chkReplyToPlainTextIsPlainText.Size = New System.Drawing.Size(362, 20)
        Me.chkReplyToPlainTextIsPlainText.TabIndex = 15
        Me.chkReplyToPlainTextIsPlainText.Text = "Default to plain text when replying to a plain text message"
        Me.chkReplyToPlainTextIsPlainText.UseVisualStyleBackColor = True
        '
        'chkAutoReturnReceipt
        '
        Me.chkAutoReturnReceipt.AutoSize = True
        Me.chkAutoReturnReceipt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoReturnReceipt.Location = New System.Drawing.Point(13, 73)
        Me.chkAutoReturnReceipt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkAutoReturnReceipt.Name = "chkAutoReturnReceipt"
        Me.chkAutoReturnReceipt.Size = New System.Drawing.Size(598, 20)
        Me.chkAutoReturnReceipt.TabIndex = 9
        Me.chkAutoReturnReceipt.Text = "Automatically request a return receipt on all email sent (unless address book set" &
    "tings override this)"
        Me.chkAutoReturnReceipt.UseVisualStyleBackColor = True
        '
        'chkEmailAutoAddRecipientsTieSMTP
        '
        Me.chkEmailAutoAddRecipientsTieSMTP.AutoSize = True
        Me.chkEmailAutoAddRecipientsTieSMTP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEmailAutoAddRecipientsTieSMTP.Location = New System.Drawing.Point(34, 49)
        Me.chkEmailAutoAddRecipientsTieSMTP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkEmailAutoAddRecipientsTieSMTP.Name = "chkEmailAutoAddRecipientsTieSMTP"
        Me.chkEmailAutoAddRecipientsTieSMTP.Size = New System.Drawing.Size(318, 20)
        Me.chkEmailAutoAddRecipientsTieSMTP.TabIndex = 14
        Me.chkEmailAutoAddRecipientsTieSMTP.Text = "Automatically connect to sending (SMTP) account"
        Me.chkEmailAutoAddRecipientsTieSMTP.UseVisualStyleBackColor = True
        '
        'chkBlockRemoteImages
        '
        Me.chkBlockRemoteImages.AutoSize = True
        Me.chkBlockRemoteImages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBlockRemoteImages.Location = New System.Drawing.Point(13, 97)
        Me.chkBlockRemoteImages.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkBlockRemoteImages.Name = "chkBlockRemoteImages"
        Me.chkBlockRemoteImages.Size = New System.Drawing.Size(347, 20)
        Me.chkBlockRemoteImages.TabIndex = 10
        Me.chkBlockRemoteImages.Text = "Block remote images from senders not in address book"
        Me.chkBlockRemoteImages.UseVisualStyleBackColor = True
        '
        'GroupBox20
        '
        Me.GroupBox20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox20.AutoSize = True
        Me.GroupBox20.Controls.Add(Me.Label38)
        Me.GroupBox20.Controls.Add(Me.cboDefaultEmailEncryption)
        Me.GroupBox20.Location = New System.Drawing.Point(8, 291)
        Me.GroupBox20.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox20.Size = New System.Drawing.Size(758, 184)
        Me.GroupBox20.TabIndex = 13
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Email Encryption Defaults"
        '
        'Label38
        '
        Me.Label38.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(14, 33)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(151, 16)
        Me.Label38.TabIndex = 3
        Me.Label38.Text = "Default email encryption:"
        '
        'cboDefaultEmailEncryption
        '
        Me.cboDefaultEmailEncryption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDefaultEmailEncryption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefaultEmailEncryption.FormattingEnabled = True
        Me.cboDefaultEmailEncryption.Items.AddRange(New Object() {"ClearText email (unencrypted)", "Encrypted email (requires recipient to also use TrulyMail)"})
        Me.cboDefaultEmailEncryption.Location = New System.Drawing.Point(199, 32)
        Me.cboDefaultEmailEncryption.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboDefaultEmailEncryption.Name = "cboDefaultEmailEncryption"
        Me.cboDefaultEmailEncryption.Size = New System.Drawing.Size(550, 24)
        Me.cboDefaultEmailEncryption.TabIndex = 12
        '
        'chkNeverProcessEmailReturnReceipts
        '
        Me.chkNeverProcessEmailReturnReceipts.AutoSize = True
        Me.chkNeverProcessEmailReturnReceipts.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNeverProcessEmailReturnReceipts.Location = New System.Drawing.Point(13, 121)
        Me.chkNeverProcessEmailReturnReceipts.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkNeverProcessEmailReturnReceipts.Name = "chkNeverProcessEmailReturnReceipts"
        Me.chkNeverProcessEmailReturnReceipts.Size = New System.Drawing.Size(196, 20)
        Me.chkNeverProcessEmailReturnReceipts.TabIndex = 11
        Me.chkNeverProcessEmailReturnReceipts.Text = "Never process return receipts"
        Me.chkNeverProcessEmailReturnReceipts.UseVisualStyleBackColor = True
        '
        'tabProfileType
        '
        Me.tabProfileType.Controls.Add(Me.KryptonPanel7)
        Me.tabProfileType.Location = New System.Drawing.Point(4, 25)
        Me.tabProfileType.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabProfileType.Name = "tabProfileType"
        Me.tabProfileType.Size = New System.Drawing.Size(776, 479)
        Me.tabProfileType.TabIndex = 4
        Me.tabProfileType.Text = "Notes"
        Me.tabProfileType.UseVisualStyleBackColor = True
        '
        'KryptonPanel7
        '
        Me.KryptonPanel7.Controls.Add(Me.GroupBox3)
        Me.KryptonPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel7.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel7.Name = "KryptonPanel7"
        Me.KryptonPanel7.Palette = Me.KryptonPalette1
        Me.KryptonPanel7.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel7.Size = New System.Drawing.Size(776, 479)
        Me.KryptonPanel7.TabIndex = 52
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.AutoSize = True
        Me.GroupBox3.Controls.Add(Me.chkAddNoteWhenChangingSubject)
        Me.GroupBox3.Controls.Add(Me.chkAddNoteWhenSendingReturnReceipt)
        Me.GroupBox3.Controls.Add(Me.chkAddNoteForProcessingRuleAction)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 6)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(727, 203)
        Me.GroupBox3.TabIndex = 39
        Me.GroupBox3.TabStop = False
        '
        'chkAddNoteWhenChangingSubject
        '
        Me.chkAddNoteWhenChangingSubject.AutoSize = True
        Me.chkAddNoteWhenChangingSubject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAddNoteWhenChangingSubject.Location = New System.Drawing.Point(10, 109)
        Me.chkAddNoteWhenChangingSubject.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkAddNoteWhenChangingSubject.Name = "chkAddNoteWhenChangingSubject"
        Me.chkAddNoteWhenChangingSubject.Size = New System.Drawing.Size(237, 20)
        Me.chkAddNoteWhenChangingSubject.TabIndex = 38
        Me.chkAddNoteWhenChangingSubject.Text = "Add note when changing the subject"
        Me.chkAddNoteWhenChangingSubject.UseVisualStyleBackColor = True
        '
        'chkAddNoteWhenSendingReturnReceipt
        '
        Me.chkAddNoteWhenSendingReturnReceipt.AutoSize = True
        Me.chkAddNoteWhenSendingReturnReceipt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAddNoteWhenSendingReturnReceipt.Location = New System.Drawing.Point(10, 81)
        Me.chkAddNoteWhenSendingReturnReceipt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkAddNoteWhenSendingReturnReceipt.Name = "chkAddNoteWhenSendingReturnReceipt"
        Me.chkAddNoteWhenSendingReturnReceipt.Size = New System.Drawing.Size(242, 20)
        Me.chkAddNoteWhenSendingReturnReceipt.TabIndex = 37
        Me.chkAddNoteWhenSendingReturnReceipt.Text = "Add note when sending return receipt"
        Me.chkAddNoteWhenSendingReturnReceipt.UseVisualStyleBackColor = True
        '
        'chkAddNoteForProcessingRuleAction
        '
        Me.chkAddNoteForProcessingRuleAction.AutoSize = True
        Me.chkAddNoteForProcessingRuleAction.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAddNoteForProcessingRuleAction.Location = New System.Drawing.Point(10, 53)
        Me.chkAddNoteForProcessingRuleAction.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkAddNoteForProcessingRuleAction.Name = "chkAddNoteForProcessingRuleAction"
        Me.chkAddNoteForProcessingRuleAction.Size = New System.Drawing.Size(259, 20)
        Me.chkAddNoteForProcessingRuleAction.TabIndex = 36
        Me.chkAddNoteForProcessingRuleAction.Text = "Add note for all processing rule changes"
        Me.chkAddNoteForProcessingRuleAction.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(713, 63)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Here you can configure which activities create notes."
        '
        'tabTroubleshooting
        '
        Me.tabTroubleshooting.Controls.Add(Me.KryptonPanel9)
        Me.tabTroubleshooting.Location = New System.Drawing.Point(4, 25)
        Me.tabTroubleshooting.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabTroubleshooting.Name = "tabTroubleshooting"
        Me.tabTroubleshooting.Size = New System.Drawing.Size(776, 479)
        Me.tabTroubleshooting.TabIndex = 6
        Me.tabTroubleshooting.Text = "Troubleshooting"
        Me.tabTroubleshooting.UseVisualStyleBackColor = True
        '
        'KryptonPanel9
        '
        Me.KryptonPanel9.Controls.Add(Me.Label1)
        Me.KryptonPanel9.Controls.Add(Me.nudLoggingErrorDisplayFrequency)
        Me.KryptonPanel9.Controls.Add(Me.chkEnableVerboseLogging)
        Me.KryptonPanel9.Controls.Add(Me.Label2)
        Me.KryptonPanel9.Controls.Add(Me.pbLogFileInfo)
        Me.KryptonPanel9.Controls.Add(Me.btnDeleteCurrentLogFile)
        Me.KryptonPanel9.Controls.Add(Me.GroupBox19)
        Me.KryptonPanel9.Controls.Add(Me.chkEnableLogging)
        Me.KryptonPanel9.Controls.Add(Me.grpLogging)
        Me.KryptonPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel9.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel9.Name = "KryptonPanel9"
        Me.KryptonPanel9.Palette = Me.KryptonPalette1
        Me.KryptonPanel9.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel9.Size = New System.Drawing.Size(776, 479)
        Me.KryptonPanel9.TabIndex = 54
        '
        'chkEnableVerboseLogging
        '
        Me.chkEnableVerboseLogging.AutoSize = True
        Me.chkEnableVerboseLogging.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEnableVerboseLogging.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEnableVerboseLogging.Location = New System.Drawing.Point(25, 53)
        Me.chkEnableVerboseLogging.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkEnableVerboseLogging.Name = "chkEnableVerboseLogging"
        Me.chkEnableVerboseLogging.Size = New System.Drawing.Size(149, 20)
        Me.chkEnableVerboseLogging.TabIndex = 55
        Me.chkEnableVerboseLogging.Text = "Enable extra logging:"
        Me.ToolTip1.SetToolTip(Me.chkEnableVerboseLogging, "Check to add much more detail to the log (use only when TrulyMail Support request" &
        "s it)")
        Me.chkEnableVerboseLogging.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(235, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(234, 16)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Display errors no more than once every"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(569, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "seconds."
        '
        'nudLoggingErrorDisplayFrequency
        '
        Me.nudLoggingErrorDisplayFrequency.Location = New System.Drawing.Point(512, 23)
        Me.nudLoggingErrorDisplayFrequency.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudLoggingErrorDisplayFrequency.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudLoggingErrorDisplayFrequency.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudLoggingErrorDisplayFrequency.Name = "nudLoggingErrorDisplayFrequency"
        Me.nudLoggingErrorDisplayFrequency.Size = New System.Drawing.Size(51, 22)
        Me.nudLoggingErrorDisplayFrequency.TabIndex = 53
        Me.nudLoggingErrorDisplayFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudLoggingErrorDisplayFrequency.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'pbLogFileInfo
        '
        Me.pbLogFileInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbLogFileInfo.Image = CType(resources.GetObject("pbLogFileInfo.Image"), System.Drawing.Image)
        Me.pbLogFileInfo.Location = New System.Drawing.Point(735, 18)
        Me.pbLogFileInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbLogFileInfo.Name = "pbLogFileInfo"
        Me.pbLogFileInfo.Size = New System.Drawing.Size(26, 27)
        Me.pbLogFileInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLogFileInfo.TabIndex = 33
        Me.pbLogFileInfo.TabStop = False
        '
        'btnDeleteCurrentLogFile
        '
        Me.btnDeleteCurrentLogFile.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnDeleteCurrentLogFile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteCurrentLogFile.Location = New System.Drawing.Point(230, 55)
        Me.btnDeleteCurrentLogFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDeleteCurrentLogFile.Name = "btnDeleteCurrentLogFile"
        Me.btnDeleteCurrentLogFile.Size = New System.Drawing.Size(122, 31)
        Me.btnDeleteCurrentLogFile.TabIndex = 35
        Me.btnDeleteCurrentLogFile.Text = "&Delete Log"
        Me.btnDeleteCurrentLogFile.UseVisualStyleBackColor = True
        '
        'GroupBox19
        '
        Me.GroupBox19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox19.AutoSize = True
        Me.GroupBox19.Controls.Add(Me.nudPromptToRecreateEncryptionKeysDays)
        Me.GroupBox19.Controls.Add(Me.nudPromptToRecreateEncryptionKeysMessages)
        Me.GroupBox19.Controls.Add(Me.cboEncryptionVersion)
        Me.GroupBox19.Location = New System.Drawing.Point(8, 226)
        Me.GroupBox19.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox19.Size = New System.Drawing.Size(787, 286)
        Me.GroupBox19.TabIndex = 51
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "Hidden stuff for 5.0"
        Me.GroupBox19.Visible = False
        '
        'nudPromptToRecreateEncryptionKeysDays
        '
        Me.nudPromptToRecreateEncryptionKeysDays.Location = New System.Drawing.Point(69, 60)
        Me.nudPromptToRecreateEncryptionKeysDays.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudPromptToRecreateEncryptionKeysDays.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.nudPromptToRecreateEncryptionKeysDays.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPromptToRecreateEncryptionKeysDays.Name = "nudPromptToRecreateEncryptionKeysDays"
        Me.nudPromptToRecreateEncryptionKeysDays.Size = New System.Drawing.Size(56, 22)
        Me.nudPromptToRecreateEncryptionKeysDays.TabIndex = 43
        Me.nudPromptToRecreateEncryptionKeysDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudPromptToRecreateEncryptionKeysDays.ThousandsSeparator = True
        Me.nudPromptToRecreateEncryptionKeysDays.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudPromptToRecreateEncryptionKeysMessages
        '
        Me.nudPromptToRecreateEncryptionKeysMessages.Location = New System.Drawing.Point(7, 60)
        Me.nudPromptToRecreateEncryptionKeysMessages.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudPromptToRecreateEncryptionKeysMessages.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudPromptToRecreateEncryptionKeysMessages.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPromptToRecreateEncryptionKeysMessages.Name = "nudPromptToRecreateEncryptionKeysMessages"
        Me.nudPromptToRecreateEncryptionKeysMessages.Size = New System.Drawing.Size(56, 22)
        Me.nudPromptToRecreateEncryptionKeysMessages.TabIndex = 42
        Me.nudPromptToRecreateEncryptionKeysMessages.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudPromptToRecreateEncryptionKeysMessages.ThousandsSeparator = True
        Me.nudPromptToRecreateEncryptionKeysMessages.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cboEncryptionVersion
        '
        Me.cboEncryptionVersion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEncryptionVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEncryptionVersion.FormattingEnabled = True
        Me.cboEncryptionVersion.Items.AddRange(New Object() {"Version 1 (only if you have problems with version 2)", "Version 2 (Recommended)"})
        Me.cboEncryptionVersion.Location = New System.Drawing.Point(6, 23)
        Me.cboEncryptionVersion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboEncryptionVersion.Name = "cboEncryptionVersion"
        Me.cboEncryptionVersion.Size = New System.Drawing.Size(543, 24)
        Me.cboEncryptionVersion.TabIndex = 0
        '
        'chkEnableLogging
        '
        Me.chkEnableLogging.AutoSize = True
        Me.chkEnableLogging.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEnableLogging.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEnableLogging.Location = New System.Drawing.Point(25, 25)
        Me.chkEnableLogging.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkEnableLogging.Name = "chkEnableLogging"
        Me.chkEnableLogging.Size = New System.Drawing.Size(116, 20)
        Me.chkEnableLogging.TabIndex = 37
        Me.chkEnableLogging.Text = "Enable logging:"
        Me.chkEnableLogging.UseVisualStyleBackColor = True
        '
        'grpLogging
        '
        Me.grpLogging.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpLogging.AutoSize = True
        Me.grpLogging.Controls.Add(Me.Label12)
        Me.grpLogging.Controls.Add(Me.txtLogFileLocation)
        Me.grpLogging.Controls.Add(Me.lblPortableLogFileNotice)
        Me.grpLogging.Controls.Add(Me.btnBrowseForLogFile)
        Me.grpLogging.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLogging.Location = New System.Drawing.Point(14, 94)
        Me.grpLogging.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpLogging.Name = "grpLogging"
        Me.grpLogging.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpLogging.Size = New System.Drawing.Size(766, 152)
        Me.grpLogging.TabIndex = 38
        Me.grpLogging.TabStop = False
        Me.grpLogging.Text = "Logging"
        Me.grpLogging.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 36)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 16)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Log File:"
        Me.Label12.Visible = False
        '
        'txtLogFileLocation
        '
        Me.txtLogFileLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLogFileLocation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogFileLocation.Location = New System.Drawing.Point(82, 32)
        Me.txtLogFileLocation.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtLogFileLocation.Name = "txtLogFileLocation"
        Me.txtLogFileLocation.Size = New System.Drawing.Size(585, 22)
        Me.txtLogFileLocation.TabIndex = 31
        Me.txtLogFileLocation.Visible = False
        '
        'lblPortableLogFileNotice
        '
        Me.lblPortableLogFileNotice.AutoSize = True
        Me.lblPortableLogFileNotice.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPortableLogFileNotice.Location = New System.Drawing.Point(78, 117)
        Me.lblPortableLogFileNotice.Name = "lblPortableLogFileNotice"
        Me.lblPortableLogFileNotice.Size = New System.Drawing.Size(366, 16)
        Me.lblPortableLogFileNotice.TabIndex = 36
        Me.lblPortableLogFileNotice.Text = "TrulyMail Portable's log file location cannot be changed."
        Me.lblPortableLogFileNotice.Visible = False
        '
        'btnBrowseForLogFile
        '
        Me.btnBrowseForLogFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseForLogFile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseForLogFile.Location = New System.Drawing.Point(672, 32)
        Me.btnBrowseForLogFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrowseForLogFile.Name = "btnBrowseForLogFile"
        Me.btnBrowseForLogFile.Size = New System.Drawing.Size(91, 28)
        Me.btnBrowseForLogFile.TabIndex = 34
        Me.btnBrowseForLogFile.Text = "&Browse"
        Me.btnBrowseForLogFile.UseVisualStyleBackColor = True
        Me.btnBrowseForLogFile.Visible = False
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(137, 89)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(157, 25)
        Me.Button2.TabIndex = 32
        Me.Button2.Text = "Remove"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(435, 51)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "To remove your profile (data, messages, login, etc.) from this computer, but leav" &
    "e your account on the server, click the Remove button."
        '
        'tmrHideKeyChangeProgress
        '
        Me.tmrHideKeyChangeProgress.Interval = 1200
        '
        'GroupBox12
        '
        Me.GroupBox12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox12.Controls.Add(Me.Label27)
        Me.GroupBox12.Controls.Add(Me.TextBox1)
        Me.GroupBox12.Controls.Add(Me.Label28)
        Me.GroupBox12.Controls.Add(Me.Button3)
        Me.GroupBox12.Controls.Add(Me.Button4)
        Me.GroupBox12.Location = New System.Drawing.Point(8, 54)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(655, 119)
        Me.GroupBox12.TabIndex = 38
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Logging"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(6, 29)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(58, 16)
        Me.Label27.TabIndex = 32
        Me.Label27.Text = "Log File:"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(70, 26)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(500, 22)
        Me.TextBox1.TabIndex = 31
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(67, 95)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(366, 16)
        Me.Label28.TabIndex = 36
        Me.Label28.Text = "TrulyMail Portable's log file location cannot be changed."
        Me.Label28.Visible = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(574, 26)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(78, 23)
        Me.Button3.TabIndex = 34
        Me.Button3.Text = "&Browse"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(304, 54)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(105, 25)
        Me.Button4.TabIndex = 35
        Me.Button4.Text = "&Delete Log"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(17, 20)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(120, 20)
        Me.CheckBox1.TabIndex = 37
        Me.CheckBox1.Text = "Enable Logging:"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(675, 43)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 22)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 33
        Me.PictureBox1.TabStop = False
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPalette = Me.KryptonPalette1
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.TabControl1)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(788, 556)
        Me.KryptonPanel.TabIndex = 51
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.Location = New System.Drawing.Point(284, 515)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(102, 33)
        Me.btnCancel.TabIndex = 59
        Me.btnCancel.Values.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.btnCancel.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.Location = New System.Drawing.Point(400, 515)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(102, 33)
        Me.btnOK.TabIndex = 58
        Me.btnOK.Values.Image = Global.TrulyMail.My.Resources.Resources.CheckMark_16
        Me.btnOK.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnOK.Values.Text = "&Save"
        '
        'tmrAutoClose
        '
        Me.tmrAutoClose.Enabled = True
        Me.tmrAutoClose.Interval = 500
        '
        'OptionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(788, 556)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "OptionsForm"
        Me.Text = "TrulyMail Options"
        Me.TabControl1.ResumeLayout(False)
        Me.tabAutoSendReceive.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        Me.GroupBox27.ResumeLayout(False)
        Me.GroupBox27.PerformLayout()
        CType(Me.pbEmailDelayInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIntraEmailSendDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.pbSecondThoughtsInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        CType(Me.pbAutoSendReceiveTrulyMail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox23.ResumeLayout(False)
        Me.GroupBox23.PerformLayout()
        CType(Me.pbRSSInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabComposing.ResumeLayout(False)
        CType(Me.KryptonPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel3.ResumeLayout(False)
        Me.KryptonPanel3.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.nudSendDelayMinutes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbChangeComposeBackColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAutoSaveDraft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picNewMessageBackground, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDefaultNewMessageFontSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabExperience.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        CType(Me.nudNewMessageNotifyStaysOpen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox21.ResumeLayout(False)
        Me.GroupBox21.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        CType(Me.nudDelayWhenCannotSend, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.grpAutomation.ResumeLayout(False)
        Me.grpAutomation.PerformLayout()
        CType(Me.nudTrashDaysToRetain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMessageList.ResumeLayout(False)
        CType(Me.KryptonPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel4.ResumeLayout(False)
        Me.KryptonPanel4.PerformLayout()
        Me.GroupBox28.ResumeLayout(False)
        Me.GroupBox28.PerformLayout()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        CType(Me.pbMoveMessageTagDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbMoveMessageTagUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbUpdateMessageTag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbDeleteMessageTag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddNewMessageTag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        CType(Me.nudLoadMessagePreviewDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEmail.ResumeLayout(False)
        CType(Me.KryptonPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel5.ResumeLayout(False)
        Me.KryptonPanel5.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox26.ResumeLayout(False)
        Me.GroupBox26.PerformLayout()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.tabProfileType.ResumeLayout(False)
        CType(Me.KryptonPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel7.ResumeLayout(False)
        Me.KryptonPanel7.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tabTroubleshooting.ResumeLayout(False)
        CType(Me.KryptonPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel9.ResumeLayout(False)
        Me.KryptonPanel9.PerformLayout()
        CType(Me.nudLoggingErrorDisplayFrequency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLogFileInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox19.ResumeLayout(False)
        CType(Me.nudPromptToRecreateEncryptionKeysDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPromptToRecreateEncryptionKeysMessages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpLogging.ResumeLayout(False)
        Me.grpLogging.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabAutoSendReceive As System.Windows.Forms.TabPage
    Friend WithEvents chkAutoSendReceive As System.Windows.Forms.CheckBox
    Friend WithEvents txtSendReceiveEveryXMinutes As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tabExperience As System.Windows.Forms.TabPage
    Friend WithEvents chkSendReceiveOnStartup As System.Windows.Forms.CheckBox
    Friend WithEvents tabProfileType As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tabTroubleshooting As System.Windows.Forms.TabPage
    Friend WithEvents btnBrowseForLogFile As System.Windows.Forms.Button
    Friend WithEvents pbLogFileInfo As System.Windows.Forms.PictureBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtLogFileLocation As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteCurrentLogFile As System.Windows.Forms.Button
    Friend WithEvents tmrHideKeyChangeProgress As System.Windows.Forms.Timer
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkUseLargeToolbarIcons As System.Windows.Forms.CheckBox
    Friend WithEvents grpAutomation As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDefaultSubject As System.Windows.Forms.TextBox
    Friend WithEvents lblPortableLogFileNotice As System.Windows.Forms.Label
    Friend WithEvents tabEmail As System.Windows.Forms.TabPage
    Friend WithEvents chkEmailAutoAddRecipientsToAddressBook As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnEmailShowSenderAsAddressBook As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnEmailShowSenderAsSent As System.Windows.Forms.RadioButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSendNowMinutes As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSendNowOnExit As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents pbAutoSendReceiveTrulyMail As System.Windows.Forms.PictureBox
    Friend WithEvents pbSecondThoughtsInfo As System.Windows.Forms.PictureBox
    Friend WithEvents cboReplyPostingMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents chkAutoReturnReceipt As System.Windows.Forms.CheckBox
    Friend WithEvents chkBlockRemoteImages As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableLogging As System.Windows.Forms.CheckBox
    Friend WithEvents grpLogging As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents nudDelayWhenCannotSend As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents nudTrashDaysToRetain As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkAutoEmptyTrash As System.Windows.Forms.CheckBox
    Friend WithEvents chkNeverProcessEmailReturnReceipts As System.Windows.Forms.CheckBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tabMessageList As System.Windows.Forms.TabPage
    Friend WithEvents lstMessageTags As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMessageTagColor As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtNewMessageTagText As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents nudLoadMessagePreviewDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents chkEmptyTrashOnExit As System.Windows.Forms.CheckBox
    Friend WithEvents tabComposing As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSpellCheckSubject As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkAutoSpellCheckBeforeSend As System.Windows.Forms.CheckBox
    Friend WithEvents cboDictionary As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSampleNewMessage As System.Windows.Forms.TextBox
    Friend WithEvents chkShowEditorSpacingStatus As System.Windows.Forms.CheckBox
    Friend WithEvents chkSingleSpaceEditor As System.Windows.Forms.CheckBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents picNewMessageBackground As System.Windows.Forms.PictureBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboDefaultNewMessageFontName As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents nudDefaultNewMessageFontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkMinimizeToTray As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowNoticeForNewMessages As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents cboNewMessageNoticeSound As System.Windows.Forms.ComboBox
    Friend WithEvents chkPlaySoundNewMessages As System.Windows.Forms.CheckBox
    Friend WithEvents btnPlaySelectedNotifySound As System.Windows.Forms.Button
    Friend WithEvents chkKeepSentMessages As System.Windows.Forms.CheckBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents btnResetAllHiddenNotices As System.Windows.Forms.Button
    Friend WithEvents chkToolBarsIncludeText As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents nudAutoSaveDraft As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkAutoSaveDrafts As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseLargeSendReceiveButton As System.Windows.Forms.CheckBox
    Friend WithEvents cboDefaultEmailEncryption As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox21 As System.Windows.Forms.GroupBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents nudNewMessageNotifyStaysOpen As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblNewMessageStaysOpenCalculation As System.Windows.Forms.Label
    Friend WithEvents cboDateFormat As System.Windows.Forms.ComboBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents chkEmailAutoAddRecipientsTieSMTP As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox23 As System.Windows.Forms.GroupBox
    Friend WithEvents pbRSSInfo As System.Windows.Forms.PictureBox
    Friend WithEvents chkRSSAutoCheckOnStartup As System.Windows.Forms.CheckBox
    Friend WithEvents chkRSSAutoCheck As System.Windows.Forms.CheckBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtRSSAutoCheckMinutes As System.Windows.Forms.TextBox
    Friend WithEvents chkReplyToPlainTextIsPlainText As System.Windows.Forms.CheckBox
    Friend WithEvents chkMaintainMessageZoom As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowReadingZoomBar As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox26 As System.Windows.Forms.GroupBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents lblFontForPlainText As System.Windows.Forms.Label
    Friend WithEvents btnChangeFontForPlainText As System.Windows.Forms.Button
    Friend WithEvents chkAutoZipEmailAttachments As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox27 As System.Windows.Forms.GroupBox
    Friend WithEvents pbEmailDelayInfo As System.Windows.Forms.PictureBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents nudIntraEmailSendDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox28 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAlternatingRowColor As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents chkAutoSizeMessageListColumns As System.Windows.Forms.CheckBox
    Friend WithEvents pbUpdateMessageTag As System.Windows.Forms.PictureBox
    Friend WithEvents pbDeleteMessageTag As System.Windows.Forms.PictureBox
    Friend WithEvents pbAddNewMessageTag As System.Windows.Forms.PictureBox
    Friend WithEvents pbMoveMessageTagDown As System.Windows.Forms.PictureBox
    Friend WithEvents pbMoveMessageTagUp As System.Windows.Forms.PictureBox
    Friend WithEvents pbChangeComposeBackColor As System.Windows.Forms.PictureBox
    Friend WithEvents chkAutomaticallyTransmitOnSend As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents nudPromptToRecreateEncryptionKeysDays As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudPromptToRecreateEncryptionKeysMessages As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboEncryptionVersion As System.Windows.Forms.ComboBox
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel3 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel4 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel5 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel7 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel9 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents tmrAutoClose As System.Windows.Forms.Timer
    Friend WithEvents chkHideOutboxCountPastToday As System.Windows.Forms.CheckBox
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudLoggingErrorDisplayFrequency As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAddNoteWhenChangingSubject As System.Windows.Forms.CheckBox
    Friend WithEvents chkAddNoteWhenSendingReturnReceipt As System.Windows.Forms.CheckBox
    Friend WithEvents chkAddNoteForProcessingRuleAction As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkEnableVerboseLogging As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoFallbackNever As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFallbackAlways As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFallbackUnderWine As System.Windows.Forms.RadioButton
    Friend WithEvents chkRemoveDiacriticsOnReceive As System.Windows.Forms.CheckBox
    Friend WithEvents chkPreviewPanePlainText As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents nudSendDelayMinutes As NumericUpDown
End Class
