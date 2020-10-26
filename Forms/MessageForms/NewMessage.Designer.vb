<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewMessage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewMessage))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddAttachmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddAttachmentsFromClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendNowAsAsNewsletterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendLaterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsDraftToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteAsTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditMessageHTMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HorizontalLineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.AutoTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageAutoTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendPlainTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailEncryptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailEncryptionNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncryptedToOtherTrulyMailUsersToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequestReturnReceiptemailOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveACopyInSentItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.RecordingMicrophoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadMessageContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadMessagePauseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadMessageResumeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.SpellCheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ServerStatusToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.FillerToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusLabelMessageSize = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.StopSendingToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.EncryptedToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmrStartClean = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerContactsAutoText = New System.Windows.Forms.SplitContainer()
        Me.olvContacts = New BrightIdeasSoftware.ObjectListView()
        Me.NameColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.AddressColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.TagsColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ctxmnuAddressBook = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddAsToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddAsCCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddAsBCCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.recipientImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtAddressSearch = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SplitContainerAutoTextArea = New System.Windows.Forms.SplitContainer()
        Me.olvAutoTexts = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.HTMLColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.KeyCodeColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ctxmnuAutoText = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EditorAutoText = New TrulyMail.Editor()
        Me.SplitContainerRecipsEditor = New System.Windows.Forms.SplitContainer()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlRecipients = New System.Windows.Forms.Panel()
        Me.olvRecipients = New BrightIdeasSoftware.ObjectListView()
        Me.RecipientIconColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.RecipientTypeColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.RecipientNameColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.RecipientAddressColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ctxmnuRecipients = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveRecipientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.olvAttachments = New BrightIdeasSoftware.ObjectListView()
        Me.AttachmentNameColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnFileSize = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ctxmnuAttachments = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveAttachmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteClipboardContentsAsAttachmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.attachmentImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.chkZipAttachments = New System.Windows.Forms.CheckBox()
        Me.picNewEmail = New System.Windows.Forms.PictureBox()
        Me.picTo = New System.Windows.Forms.PictureBox()
        Me.picCC = New System.Windows.Forms.PictureBox()
        Me.picBCC = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtSubject = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnSubjectSpecialChar = New ComponentFactory.Krypton.Toolkit.ButtonSpecAny()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRecipient = New System.Windows.Forms.Label()
        Me.lblRecipCount = New System.Windows.Forms.Label()
        Me.Editor1 = New TrulyMail.Editor()
        Me.pnlSMTPAccount = New System.Windows.Forms.Panel()
        Me.cboSMTPAccount = New System.Windows.Forms.ComboBox()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblSMTPFrom = New System.Windows.Forms.Label()
        Me.WebBrowser2 = New System.Windows.Forms.WebBrowser()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSend = New System.Windows.Forms.ToolStripButton()
        Me.SaveAsDraftToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.btnToggleAddressBook = New System.Windows.Forms.ToolStripButton()
        Me.AddAttachmentsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SpellCheckToolStripSplitButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.SpellAsTypeToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveACopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.HighPriorityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NormalPriorityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LowPriorityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReturnReceiptToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.EncryptedEmailTypeToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.UnencryptedEmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncryptedToOtherTrulyMailUsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlainTextToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ShowAutoTextToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.MessageTagsToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkCreateReminder = New System.Windows.Forms.CheckBox()
        Me.tmrAutoSave = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrSetDefaultFont = New System.Windows.Forms.Timer(Me.components)
        Me.tmrFlashInfo = New System.Windows.Forms.Timer(Me.components)
        Me.tmrDelayedSettingBackColor = New System.Windows.Forms.Timer(Me.components)
        Me.C1SpellChecker1 = New C1.Win.C1SpellChecker.C1SpellChecker(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainerContactsAutoText, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerContactsAutoText.Panel1.SuspendLayout()
        Me.SplitContainerContactsAutoText.Panel2.SuspendLayout()
        Me.SplitContainerContactsAutoText.SuspendLayout()
        CType(Me.olvContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmnuAddressBook.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerAutoTextArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerAutoTextArea.Panel1.SuspendLayout()
        Me.SplitContainerAutoTextArea.Panel2.SuspendLayout()
        Me.SplitContainerAutoTextArea.SuspendLayout()
        CType(Me.olvAutoTexts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmnuAutoText.SuspendLayout()
        CType(Me.SplitContainerRecipsEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerRecipsEditor.Panel1.SuspendLayout()
        Me.SplitContainerRecipsEditor.Panel2.SuspendLayout()
        Me.SplitContainerRecipsEditor.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlRecipients.SuspendLayout()
        CType(Me.olvRecipients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmnuRecipients.SuspendLayout()
        CType(Me.olvAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmnuAttachments.SuspendLayout()
        CType(Me.picNewEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.pnlSMTPAccount.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.C1SpellChecker1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.InsertToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(979, 24)
        Me.MenuStrip1.TabIndex = 16
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewMessageToolStripMenuItem, Me.ToolStripSeparator4, Me.AddAttachmentsToolStripMenuItem, Me.AddAttachmentsFromClipboardToolStripMenuItem, Me.SendToolStripMenuItem, Me.SendNowAsAsNewsletterToolStripMenuItem, Me.SendLaterToolStripMenuItem, Me.SaveAsDraftToolStripMenuItem, Me.ToolStripSeparator2, Me.PrintToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewMessageToolStripMenuItem
        '
        Me.NewMessageToolStripMenuItem.Image = CType(resources.GetObject("NewMessageToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewMessageToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.NewMessageToolStripMenuItem.Name = "NewMessageToolStripMenuItem"
        Me.NewMessageToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewMessageToolStripMenuItem.Size = New System.Drawing.Size(351, 22)
        Me.NewMessageToolStripMenuItem.Text = "New &Message"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(348, 6)
        '
        'AddAttachmentsToolStripMenuItem
        '
        Me.AddAttachmentsToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Attach_16
        Me.AddAttachmentsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.AddAttachmentsToolStripMenuItem.Name = "AddAttachmentsToolStripMenuItem"
        Me.AddAttachmentsToolStripMenuItem.Size = New System.Drawing.Size(351, 22)
        Me.AddAttachmentsToolStripMenuItem.Text = "&Add Attachments"
        Me.AddAttachmentsToolStripMenuItem.ToolTipText = "Add attachments to this message"
        '
        'AddAttachmentsFromClipboardToolStripMenuItem
        '
        Me.AddAttachmentsFromClipboardToolStripMenuItem.Enabled = False
        Me.AddAttachmentsFromClipboardToolStripMenuItem.Name = "AddAttachmentsFromClipboardToolStripMenuItem"
        Me.AddAttachmentsFromClipboardToolStripMenuItem.ShortcutKeys = CType((((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.AddAttachmentsFromClipboardToolStripMenuItem.Size = New System.Drawing.Size(351, 22)
        Me.AddAttachmentsFromClipboardToolStripMenuItem.Text = "Add attachment(s) from &clipboard"
        Me.AddAttachmentsFromClipboardToolStripMenuItem.ToolTipText = "Add clipboard contents as attachment"
        '
        'SendToolStripMenuItem
        '
        Me.SendToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Sendmail_16
        Me.SendToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.SendToolStripMenuItem.Name = "SendToolStripMenuItem"
        Me.SendToolStripMenuItem.Size = New System.Drawing.Size(351, 22)
        Me.SendToolStripMenuItem.Text = "Send &Now"
        Me.SendToolStripMenuItem.ToolTipText = "Send now as normal message"
        '
        'SendNowAsAsNewsletterToolStripMenuItem
        '
        Me.SendNowAsAsNewsletterToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Text_16
        Me.SendNowAsAsNewsletterToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.SendNowAsAsNewsletterToolStripMenuItem.Name = "SendNowAsAsNewsletterToolStripMenuItem"
        Me.SendNowAsAsNewsletterToolStripMenuItem.Size = New System.Drawing.Size(351, 22)
        Me.SendNowAsAsNewsletterToolStripMenuItem.Text = "Send Now as Newsle&tter"
        Me.SendNowAsAsNewsletterToolStripMenuItem.ToolTipText = "Send now as Newsletter Mode message (each recipient gets own message)"
        '
        'SendLaterToolStripMenuItem
        '
        Me.SendLaterToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.clock_16
        Me.SendLaterToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SendLaterToolStripMenuItem.Name = "SendLaterToolStripMenuItem"
        Me.SendLaterToolStripMenuItem.Size = New System.Drawing.Size(351, 22)
        Me.SendLaterToolStripMenuItem.Text = "Send &Later"
        Me.SendLaterToolStripMenuItem.ToolTipText = "Send as normal message after a certain date and time"
        '
        'SaveAsDraftToolStripMenuItem
        '
        Me.SaveAsDraftToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Savefile_16
        Me.SaveAsDraftToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.SaveAsDraftToolStripMenuItem.Name = "SaveAsDraftToolStripMenuItem"
        Me.SaveAsDraftToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAsDraftToolStripMenuItem.Size = New System.Drawing.Size(351, 22)
        Me.SaveAsDraftToolStripMenuItem.Text = "&Save as Draft"
        Me.SaveAsDraftToolStripMenuItem.ToolTipText = "Save this message to the drafts folder"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(348, 6)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Print_16
        Me.PrintToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(351, 22)
        Me.PrintToolStripMenuItem.Text = "&Print"
        Me.PrintToolStripMenuItem.ToolTipText = "Print this message"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(348, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeyDisplayString = ""
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(351, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.PasteAsTextToolStripMenuItem, Me.ToolStripSeparator10, Me.EditMessageHTMLToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Cut_16
        Me.CutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.CutToolStripMenuItem.Text = "Cu&t"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Copy_16
        Me.CopyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.CopyToolStripMenuItem.Text = "&Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Paste_16
        Me.PasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.PasteToolStripMenuItem.Text = "&Paste"
        '
        'PasteAsTextToolStripMenuItem
        '
        Me.PasteAsTextToolStripMenuItem.Enabled = False
        Me.PasteAsTextToolStripMenuItem.Name = "PasteAsTextToolStripMenuItem"
        Me.PasteAsTextToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.PasteAsTextToolStripMenuItem.Text = "Paste as &Text"
        Me.PasteAsTextToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(153, 6)
        '
        'EditMessageHTMLToolStripMenuItem
        '
        Me.EditMessageHTMLToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.earth_16
        Me.EditMessageHTMLToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.EditMessageHTMLToolStripMenuItem.Name = "EditMessageHTMLToolStripMenuItem"
        Me.EditMessageHTMLToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.EditMessageHTMLToolStripMenuItem.Text = "Message &HTML"
        '
        'InsertToolStripMenuItem
        '
        Me.InsertToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImageToolStripMenuItem, Me.HorizontalLineToolStripMenuItem, Me.InsertTableToolStripMenuItem, Me.ToolStripSeparator6, Me.AutoTextToolStripMenuItem})
        Me.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem"
        Me.InsertToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.InsertToolStripMenuItem.Text = "&Insert"
        '
        'ImageToolStripMenuItem
        '
        Me.ImageToolStripMenuItem.Name = "ImageToolStripMenuItem"
        Me.ImageToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ImageToolStripMenuItem.Text = "&Image"
        '
        'HorizontalLineToolStripMenuItem
        '
        Me.HorizontalLineToolStripMenuItem.Name = "HorizontalLineToolStripMenuItem"
        Me.HorizontalLineToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.HorizontalLineToolStripMenuItem.Text = "H&orizontal Line"
        '
        'InsertTableToolStripMenuItem
        '
        Me.InsertTableToolStripMenuItem.Name = "InsertTableToolStripMenuItem"
        Me.InsertTableToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.InsertTableToolStripMenuItem.Text = "&Table"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(151, 6)
        '
        'AutoTextToolStripMenuItem
        '
        Me.AutoTextToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManageAutoTextToolStripMenuItem, Me.ToolStripSeparator8})
        Me.AutoTextToolStripMenuItem.Name = "AutoTextToolStripMenuItem"
        Me.AutoTextToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.AutoTextToolStripMenuItem.Text = "&AutoText"
        '
        'ManageAutoTextToolStripMenuItem
        '
        Me.ManageAutoTextToolStripMenuItem.Name = "ManageAutoTextToolStripMenuItem"
        Me.ManageAutoTextToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ManageAutoTextToolStripMenuItem.Text = "&Manage AutoText"
        Me.ManageAutoTextToolStripMenuItem.ToolTipText = "Manage AutoTexts / Signatures"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(164, 6)
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SendPlainTextToolStripMenuItem, Me.EmailEncryptionToolStripMenuItem, Me.RequestReturnReceiptemailOnlyToolStripMenuItem, Me.SaveACopyInSentItemsToolStripMenuItem, Me.ToolStripSeparator5, Me.RecordingMicrophoneToolStripMenuItem, Me.ReadMessageContentsToolStripMenuItem, Me.ReadMessagePauseToolStripMenuItem, Me.ReadMessageResumeToolStripMenuItem, Me.ToolStripSeparator9, Me.SpellCheckToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'SendPlainTextToolStripMenuItem
        '
        Me.SendPlainTextToolStripMenuItem.CheckOnClick = True
        Me.SendPlainTextToolStripMenuItem.Name = "SendPlainTextToolStripMenuItem"
        Me.SendPlainTextToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.SendPlainTextToolStripMenuItem.Text = "Send as &Plain Text (no formatting)"
        Me.SendPlainTextToolStripMenuItem.ToolTipText = "Send this message as plain text to email recipients (use if recipient does not su" & _
    "pport HTML email)"
        '
        'EmailEncryptionToolStripMenuItem
        '
        Me.EmailEncryptionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailEncryptionNoneToolStripMenuItem, Me.EncryptedToOtherTrulyMailUsersToolStripMenuItem1})
        Me.EmailEncryptionToolStripMenuItem.Name = "EmailEncryptionToolStripMenuItem"
        Me.EmailEncryptionToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.EmailEncryptionToolStripMenuItem.Text = "Email encryption"
        '
        'EmailEncryptionNoneToolStripMenuItem
        '
        Me.EmailEncryptionNoneToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.email_16
        Me.EmailEncryptionNoneToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.EmailEncryptionNoneToolStripMenuItem.Name = "EmailEncryptionNoneToolStripMenuItem"
        Me.EmailEncryptionNoneToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.EmailEncryptionNoneToolStripMenuItem.Text = "Unencrypted"
        '
        'EncryptedToOtherTrulyMailUsersToolStripMenuItem1
        '
        Me.EncryptedToOtherTrulyMailUsersToolStripMenuItem1.Image = Global.TrulyMail.My.Resources.Resources.Securedmessage_16
        Me.EncryptedToOtherTrulyMailUsersToolStripMenuItem1.Name = "EncryptedToOtherTrulyMailUsersToolStripMenuItem1"
        Me.EncryptedToOtherTrulyMailUsersToolStripMenuItem1.Size = New System.Drawing.Size(254, 22)
        Me.EncryptedToOtherTrulyMailUsersToolStripMenuItem1.Text = "Encrypted to other TrulyMail users"
        Me.EncryptedToOtherTrulyMailUsersToolStripMenuItem1.ToolTipText = "Keeps message contents private but can only be read by other TrulyMail users"
        '
        'RequestReturnReceiptemailOnlyToolStripMenuItem
        '
        Me.RequestReturnReceiptemailOnlyToolStripMenuItem.CheckOnClick = True
        Me.RequestReturnReceiptemailOnlyToolStripMenuItem.Name = "RequestReturnReceiptemailOnlyToolStripMenuItem"
        Me.RequestReturnReceiptemailOnlyToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.RequestReturnReceiptemailOnlyToolStripMenuItem.Text = "Request &Return Receipt"
        '
        'SaveACopyInSentItemsToolStripMenuItem
        '
        Me.SaveACopyInSentItemsToolStripMenuItem.Checked = True
        Me.SaveACopyInSentItemsToolStripMenuItem.CheckOnClick = True
        Me.SaveACopyInSentItemsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SaveACopyInSentItemsToolStripMenuItem.Name = "SaveACopyInSentItemsToolStripMenuItem"
        Me.SaveACopyInSentItemsToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.SaveACopyInSentItemsToolStripMenuItem.Text = "Save a &Copy in Sent Items"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(249, 6)
        '
        'RecordingMicrophoneToolStripMenuItem
        '
        Me.RecordingMicrophoneToolStripMenuItem.Name = "RecordingMicrophoneToolStripMenuItem"
        Me.RecordingMicrophoneToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.RecordingMicrophoneToolStripMenuItem.Text = "Recording Microphone"
        '
        'ReadMessageContentsToolStripMenuItem
        '
        Me.ReadMessageContentsToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.PlayButton_16
        Me.ReadMessageContentsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ReadMessageContentsToolStripMenuItem.Name = "ReadMessageContentsToolStripMenuItem"
        Me.ReadMessageContentsToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.ReadMessageContentsToolStripMenuItem.Text = "Read &Message Contents"
        Me.ReadMessageContentsToolStripMenuItem.ToolTipText = "Read message contents aloud from the beginning (or beginning of selection, if tex" & _
    "t is selected)"
        '
        'ReadMessagePauseToolStripMenuItem
        '
        Me.ReadMessagePauseToolStripMenuItem.Enabled = False
        Me.ReadMessagePauseToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.PauseButton_16
        Me.ReadMessagePauseToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ReadMessagePauseToolStripMenuItem.Name = "ReadMessagePauseToolStripMenuItem"
        Me.ReadMessagePauseToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.ReadMessagePauseToolStripMenuItem.Text = "&Pause Reading"
        '
        'ReadMessageResumeToolStripMenuItem
        '
        Me.ReadMessageResumeToolStripMenuItem.Enabled = False
        Me.ReadMessageResumeToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.ResumeButton_16
        Me.ReadMessageResumeToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ReadMessageResumeToolStripMenuItem.Name = "ReadMessageResumeToolStripMenuItem"
        Me.ReadMessageResumeToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.ReadMessageResumeToolStripMenuItem.Text = "R&esume Reading"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(249, 6)
        '
        'SpellCheckToolStripMenuItem
        '
        Me.SpellCheckToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Spellcheck_16
        Me.SpellCheckToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.SpellCheckToolStripMenuItem.Name = "SpellCheckToolStripMenuItem"
        Me.SpellCheckToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.SpellCheckToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.SpellCheckToolStripMenuItem.Text = "&Spell Check"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AboutToolStripMenuItem.Text = "&About TrulyMail"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ServerStatusToolStripStatusLabel, Me.FillerToolStripStatusLabel, Me.StatusLabelMessageSize, Me.StatusProgressBar, Me.StopSendingToolStripDropDownButton, Me.EncryptedToolStripStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.ShowItemToolTips = True
        Me.StatusStrip1.Size = New System.Drawing.Size(979, 22)
        Me.StatusStrip1.TabIndex = 17
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ServerStatusToolStripStatusLabel
        '
        Me.ServerStatusToolStripStatusLabel.Name = "ServerStatusToolStripStatusLabel"
        Me.ServerStatusToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ServerStatusToolStripStatusLabel.Text = "Ready"
        '
        'FillerToolStripStatusLabel
        '
        Me.FillerToolStripStatusLabel.Name = "FillerToolStripStatusLabel"
        Me.FillerToolStripStatusLabel.Size = New System.Drawing.Size(791, 17)
        Me.FillerToolStripStatusLabel.Spring = True
        '
        'StatusLabelMessageSize
        '
        Me.StatusLabelMessageSize.Name = "StatusLabelMessageSize"
        Me.StatusLabelMessageSize.Size = New System.Drawing.Size(118, 17)
        Me.StatusLabelMessageSize.Text = "Message size: 0 bytes"
        Me.StatusLabelMessageSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StatusProgressBar
        '
        Me.StatusProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StatusProgressBar.Name = "StatusProgressBar"
        Me.StatusProgressBar.Size = New System.Drawing.Size(200, 16)
        Me.StatusProgressBar.Visible = False
        '
        'StopSendingToolStripDropDownButton
        '
        Me.StopSendingToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StopSendingToolStripDropDownButton.Image = Global.TrulyMail.My.Resources.Resources.Stop_16
        Me.StopSendingToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.White
        Me.StopSendingToolStripDropDownButton.Name = "StopSendingToolStripDropDownButton"
        Me.StopSendingToolStripDropDownButton.Size = New System.Drawing.Size(29, 20)
        Me.StopSendingToolStripDropDownButton.Text = "ToolStripDropDownButton1"
        Me.StopSendingToolStripDropDownButton.ToolTipText = "Stop sending message"
        Me.StopSendingToolStripDropDownButton.Visible = False
        '
        'EncryptedToolStripStatusLabel
        '
        Me.EncryptedToolStripStatusLabel.Image = Global.TrulyMail.My.Resources.Resources.Securedmessage_16
        Me.EncryptedToolStripStatusLabel.ImageTransparentColor = System.Drawing.Color.White
        Me.EncryptedToolStripStatusLabel.Name = "EncryptedToolStripStatusLabel"
        Me.EncryptedToolStripStatusLabel.Size = New System.Drawing.Size(16, 17)
        '
        'tmrStartClean
        '
        Me.tmrStartClean.Enabled = True
        Me.tmrStartClean.Interval = 700
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.StatusStrip1)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SplitContainer1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(979, 473)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(979, 557)
        Me.ToolStripContainer1.TabIndex = 18
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainerContactsAutoText)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainerRecipsEditor)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlSMTPAccount)
        Me.SplitContainer1.Panel2.Controls.Add(Me.WebBrowser2)
        Me.SplitContainer1.Size = New System.Drawing.Size(979, 473)
        Me.SplitContainer1.SplitterDistance = 256
        Me.SplitContainer1.TabIndex = 19
        '
        'SplitContainerContactsAutoText
        '
        Me.SplitContainerContactsAutoText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerContactsAutoText.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerContactsAutoText.Name = "SplitContainerContactsAutoText"
        Me.SplitContainerContactsAutoText.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerContactsAutoText.Panel1
        '
        Me.SplitContainerContactsAutoText.Panel1.Controls.Add(Me.olvContacts)
        Me.SplitContainerContactsAutoText.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainerContactsAutoText.Panel2
        '
        Me.SplitContainerContactsAutoText.Panel2.Controls.Add(Me.SplitContainerAutoTextArea)
        Me.SplitContainerContactsAutoText.Size = New System.Drawing.Size(256, 473)
        Me.SplitContainerContactsAutoText.SplitterDistance = 235
        Me.SplitContainerContactsAutoText.TabIndex = 4
        '
        'olvContacts
        '
        Me.olvContacts.AllColumns.Add(Me.NameColumn)
        Me.olvContacts.AllColumns.Add(Me.AddressColumn)
        Me.olvContacts.AllColumns.Add(Me.TagsColumn)
        Me.olvContacts.AllowColumnReorder = True
        Me.olvContacts.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvContacts.CellEditUseWholeCell = False
        Me.olvContacts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NameColumn, Me.AddressColumn, Me.TagsColumn})
        Me.olvContacts.ContextMenuStrip = Me.ctxmnuAddressBook
        Me.olvContacts.CopySelectionOnControlC = False
        Me.olvContacts.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.olvContacts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvContacts.EmptyListMsg = "No contacts found"
        Me.olvContacts.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!)
        Me.olvContacts.FullRowSelect = True
        Me.olvContacts.GridLines = True
        Me.olvContacts.HideSelection = False
        Me.olvContacts.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvContacts.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvContacts.LabelWrap = False
        Me.olvContacts.Location = New System.Drawing.Point(0, 20)
        Me.olvContacts.Name = "olvContacts"
        Me.olvContacts.SelectColumnsMenuStaysOpen = False
        Me.olvContacts.ShowCommandMenuOnRightClick = True
        Me.olvContacts.ShowGroups = False
        Me.olvContacts.ShowItemCountOnGroups = True
        Me.olvContacts.ShowItemToolTips = True
        Me.olvContacts.Size = New System.Drawing.Size(256, 215)
        Me.olvContacts.SmallImageList = Me.recipientImageList
        Me.olvContacts.TabIndex = 1
        Me.olvContacts.UseAlternatingBackColors = True
        Me.olvContacts.UseCompatibleStateImageBehavior = False
        Me.olvContacts.UseFiltering = True
        Me.olvContacts.View = System.Windows.Forms.View.Details
        '
        'NameColumn
        '
        Me.NameColumn.AspectName = "FullName"
        Me.NameColumn.Text = "Name"
        Me.NameColumn.Width = 100
        '
        'AddressColumn
        '
        Me.AddressColumn.AspectName = "Address"
        Me.AddressColumn.Text = "Address"
        Me.AddressColumn.Width = 110
        '
        'TagsColumn
        '
        Me.TagsColumn.AspectName = "Tags"
        Me.TagsColumn.Text = "Tags"
        '
        'ctxmnuAddressBook
        '
        Me.ctxmnuAddressBook.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuAddressBook.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddAsToToolStripMenuItem, Me.AddAsCCToolStripMenuItem, Me.AddAsBCCToolStripMenuItem, Me.EditContactToolStripMenuItem})
        Me.ctxmnuAddressBook.Name = "ctxmnuAddressBook"
        Me.ctxmnuAddressBook.Size = New System.Drawing.Size(140, 92)
        '
        'AddAsToToolStripMenuItem
        '
        Me.AddAsToToolStripMenuItem.Name = "AddAsToToolStripMenuItem"
        Me.AddAsToToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.AddAsToToolStripMenuItem.Text = "Add as &To"
        '
        'AddAsCCToolStripMenuItem
        '
        Me.AddAsCCToolStripMenuItem.Name = "AddAsCCToolStripMenuItem"
        Me.AddAsCCToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.AddAsCCToolStripMenuItem.Text = "Add as &CC"
        '
        'AddAsBCCToolStripMenuItem
        '
        Me.AddAsBCCToolStripMenuItem.Name = "AddAsBCCToolStripMenuItem"
        Me.AddAsBCCToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.AddAsBCCToolStripMenuItem.Text = "Add as &BCC"
        '
        'EditContactToolStripMenuItem
        '
        Me.EditContactToolStripMenuItem.Name = "EditContactToolStripMenuItem"
        Me.EditContactToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.EditContactToolStripMenuItem.Text = "&Edit Contact"
        '
        'recipientImageList
        '
        Me.recipientImageList.ImageStream = CType(resources.GetObject("recipientImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.recipientImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.recipientImageList.Images.SetKeyName(0, "Secured message.bmp")
        Me.recipientImageList.Images.SetKeyName(1, "Email.bmp")
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtAddressSearch)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(256, 20)
        Me.Panel1.TabIndex = 3
        '
        'txtAddressSearch
        '
        Me.txtAddressSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddressSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAddressSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddressSearch.ForeColor = System.Drawing.Color.DarkGray
        Me.txtAddressSearch.Location = New System.Drawing.Point(22, 1)
        Me.txtAddressSearch.Name = "txtAddressSearch"
        Me.txtAddressSearch.Size = New System.Drawing.Size(247, 15)
        Me.txtAddressSearch.TabIndex = 0
        Me.txtAddressSearch.Text = "Name or email or tag"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = Global.TrulyMail.My.Resources.Resources.Search_16
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 18)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'SplitContainerAutoTextArea
        '
        Me.SplitContainerAutoTextArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerAutoTextArea.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerAutoTextArea.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerAutoTextArea.Name = "SplitContainerAutoTextArea"
        Me.SplitContainerAutoTextArea.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerAutoTextArea.Panel1
        '
        Me.SplitContainerAutoTextArea.Panel1.Controls.Add(Me.olvAutoTexts)
        Me.SplitContainerAutoTextArea.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainerAutoTextArea.Panel2
        '
        Me.SplitContainerAutoTextArea.Panel2.Controls.Add(Me.EditorAutoText)
        Me.SplitContainerAutoTextArea.Size = New System.Drawing.Size(256, 234)
        Me.SplitContainerAutoTextArea.SplitterDistance = 117
        Me.SplitContainerAutoTextArea.TabIndex = 7
        '
        'olvAutoTexts
        '
        Me.olvAutoTexts.AllColumns.Add(Me.OlvColumn1)
        Me.olvAutoTexts.AllColumns.Add(Me.HTMLColumn)
        Me.olvAutoTexts.AllColumns.Add(Me.KeyCodeColumn)
        Me.olvAutoTexts.AllowColumnReorder = True
        Me.olvAutoTexts.CellEditUseWholeCell = False
        Me.olvAutoTexts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1, Me.HTMLColumn, Me.KeyCodeColumn})
        Me.olvAutoTexts.ContextMenuStrip = Me.ctxmnuAutoText
        Me.olvAutoTexts.CopySelectionOnControlC = False
        Me.olvAutoTexts.Cursor = System.Windows.Forms.Cursors.Default
        Me.olvAutoTexts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvAutoTexts.EmptyListMsg = "No AutoTexts"
        Me.olvAutoTexts.EmptyListMsgFont = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvAutoTexts.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvAutoTexts.FullRowSelect = True
        Me.olvAutoTexts.HideSelection = False
        Me.olvAutoTexts.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvAutoTexts.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvAutoTexts.LabelWrap = False
        Me.olvAutoTexts.Location = New System.Drawing.Point(0, 23)
        Me.olvAutoTexts.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.olvAutoTexts.MultiSelect = False
        Me.olvAutoTexts.Name = "olvAutoTexts"
        Me.olvAutoTexts.SelectColumnsOnRightClick = False
        Me.olvAutoTexts.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvAutoTexts.ShowGroups = False
        Me.olvAutoTexts.ShowImagesOnSubItems = True
        Me.olvAutoTexts.ShowItemCountOnGroups = True
        Me.olvAutoTexts.Size = New System.Drawing.Size(256, 94)
        Me.olvAutoTexts.TabIndex = 5
        Me.olvAutoTexts.UseCompatibleStateImageBehavior = False
        Me.olvAutoTexts.UseFiltering = True
        Me.olvAutoTexts.UseHyperlinks = True
        Me.olvAutoTexts.UseSubItemCheckBoxes = True
        Me.olvAutoTexts.View = System.Windows.Forms.View.Details
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "Name"
        Me.OlvColumn1.Text = "Name"
        Me.OlvColumn1.Width = 130
        '
        'HTMLColumn
        '
        Me.HTMLColumn.AspectName = "HTML"
        Me.HTMLColumn.CheckBoxes = True
        Me.HTMLColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.HTMLColumn.IsEditable = False
        Me.HTMLColumn.Text = "HTML"
        Me.HTMLColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'KeyCodeColumn
        '
        Me.KeyCodeColumn.AspectName = "HotKey"
        Me.KeyCodeColumn.Text = "HotKey"
        '
        'ctxmnuAutoText
        '
        Me.ctxmnuAutoText.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3})
        Me.ctxmnuAutoText.Name = "ctxmnuAddressBook"
        Me.ctxmnuAutoText.Size = New System.Drawing.Size(168, 26)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem3.Text = "&Manage AutoText"
        Me.ToolStripMenuItem3.ToolTipText = "Manage AutoTexts / Signatures"
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(256, 23)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "AutoText"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'EditorAutoText
        '
        Me.EditorAutoText.BackColor = System.Drawing.Color.White
        Me.EditorAutoText.BodyHtml = ""
        Me.EditorAutoText.BodyText = Nothing
        Me.EditorAutoText.ContentEditable = True
        Me.EditorAutoText.CustomColors = Nothing
        Me.EditorAutoText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditorAutoText.DocumentText = resources.GetString("EditorAutoText.DocumentText")
        Me.EditorAutoText.EditorBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.EditorAutoText.EditorForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.EditorAutoText.EmojiGroup1Image = Nothing
        Me.EditorAutoText.EmojiGroup1Path = ""
        Me.EditorAutoText.EmojiGroup1Title = ""
        Me.EditorAutoText.EmojiGroup2Image = Nothing
        Me.EditorAutoText.EmojiGroup2Path = ""
        Me.EditorAutoText.EmojiGroup2Title = ""
        Me.EditorAutoText.EmojiGroup3Image = Nothing
        Me.EditorAutoText.EmojiGroup3Path = ""
        Me.EditorAutoText.EmojiGroup3Title = ""
        Me.EditorAutoText.EmojiGroup4Image = Nothing
        Me.EditorAutoText.EmojiGroup4Path = ""
        Me.EditorAutoText.EmojiGroup4Title = ""
        Me.EditorAutoText.EmojiGroup5Image = Nothing
        Me.EditorAutoText.EmojiGroup5Path = ""
        Me.EditorAutoText.EmojiGroup5Title = ""
        Me.EditorAutoText.EmojiGroup6Image = Nothing
        Me.EditorAutoText.EmojiGroup6Path = ""
        Me.EditorAutoText.EmojiGroup6Title = ""
        Me.EditorAutoText.EmojiGroup7Image = Nothing
        Me.EditorAutoText.EmojiGroup7Path = ""
        Me.EditorAutoText.EmojiGroup7Title = ""
        Me.EditorAutoText.EmojiVisible = False
        Me.EditorAutoText.FontSize = TrulyMail.FontSize.Three
        Me.EditorAutoText.HideContextMenu = True
        Me.EditorAutoText.HTMLToolBar = True
        Me.EditorAutoText.KeyPreview = True
        Me.EditorAutoText.Location = New System.Drawing.Point(0, 0)
        Me.EditorAutoText.Name = "EditorAutoText"
        Me.EditorAutoText.Size = New System.Drawing.Size(256, 113)
        Me.EditorAutoText.TabIndex = 6
        Me.EditorAutoText.ToolBarVisible = False
        '
        'SplitContainerRecipsEditor
        '
        Me.SplitContainerRecipsEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerRecipsEditor.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerRecipsEditor.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainerRecipsEditor.Name = "SplitContainerRecipsEditor"
        Me.SplitContainerRecipsEditor.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerRecipsEditor.Panel1
        '
        Me.SplitContainerRecipsEditor.Panel1.AutoScroll = True
        Me.SplitContainerRecipsEditor.Panel1.Controls.Add(Me.Panel3)
        Me.SplitContainerRecipsEditor.Panel1.Controls.Add(Me.Panel4)
        '
        'SplitContainerRecipsEditor.Panel2
        '
        Me.SplitContainerRecipsEditor.Panel2.AutoScroll = True
        Me.SplitContainerRecipsEditor.Panel2.Controls.Add(Me.Editor1)
        Me.SplitContainerRecipsEditor.Size = New System.Drawing.Size(719, 448)
        Me.SplitContainerRecipsEditor.SplitterDistance = 143
        Me.SplitContainerRecipsEditor.TabIndex = 37
        Me.SplitContainerRecipsEditor.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.Controls.Add(Me.pnlRecipients)
        Me.Panel3.Controls.Add(Me.picNewEmail)
        Me.Panel3.Controls.Add(Me.picTo)
        Me.Panel3.Controls.Add(Me.picCC)
        Me.Panel3.Controls.Add(Me.picBCC)
        Me.Panel3.Controls.Add(Me.PictureBox6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(719, 107)
        Me.Panel3.TabIndex = 38
        '
        'pnlRecipients
        '
        Me.pnlRecipients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlRecipients.Controls.Add(Me.olvRecipients)
        Me.pnlRecipients.Controls.Add(Me.olvAttachments)
        Me.pnlRecipients.Controls.Add(Me.chkZipAttachments)
        Me.pnlRecipients.Location = New System.Drawing.Point(64, 3)
        Me.pnlRecipients.Name = "pnlRecipients"
        Me.pnlRecipients.Size = New System.Drawing.Size(655, 103)
        Me.pnlRecipients.TabIndex = 24
        '
        'olvRecipients
        '
        Me.olvRecipients.AllColumns.Add(Me.RecipientIconColumn)
        Me.olvRecipients.AllColumns.Add(Me.RecipientTypeColumn)
        Me.olvRecipients.AllColumns.Add(Me.RecipientNameColumn)
        Me.olvRecipients.AllColumns.Add(Me.RecipientAddressColumn)
        Me.olvRecipients.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvRecipients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.olvRecipients.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
        Me.olvRecipients.CellEditUseWholeCell = False
        Me.olvRecipients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.RecipientIconColumn, Me.RecipientTypeColumn, Me.RecipientNameColumn, Me.RecipientAddressColumn})
        Me.olvRecipients.ContextMenuStrip = Me.ctxmnuRecipients
        Me.olvRecipients.CopySelectionOnControlC = False
        Me.olvRecipients.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.olvRecipients.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!)
        Me.olvRecipients.FullRowSelect = True
        Me.olvRecipients.GridLines = True
        Me.olvRecipients.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvRecipients.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvRecipients.LabelWrap = False
        Me.olvRecipients.Location = New System.Drawing.Point(1, 1)
        Me.olvRecipients.Name = "olvRecipients"
        Me.olvRecipients.SelectColumnsMenuStaysOpen = False
        Me.olvRecipients.SelectColumnsOnRightClick = False
        Me.olvRecipients.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvRecipients.ShowCommandMenuOnRightClick = True
        Me.olvRecipients.ShowGroups = False
        Me.olvRecipients.ShowItemCountOnGroups = True
        Me.olvRecipients.Size = New System.Drawing.Size(435, 100)
        Me.olvRecipients.SmallImageList = Me.recipientImageList
        Me.olvRecipients.SortGroupItemsByPrimaryColumn = False
        Me.olvRecipients.TabIndex = 3
        Me.olvRecipients.UseAlternatingBackColors = True
        Me.olvRecipients.UseCompatibleStateImageBehavior = False
        Me.olvRecipients.View = System.Windows.Forms.View.Details
        '
        'RecipientIconColumn
        '
        Me.RecipientIconColumn.AspectName = ""
        Me.RecipientIconColumn.IsEditable = False
        Me.RecipientIconColumn.MaximumWidth = 25
        Me.RecipientIconColumn.MinimumWidth = 25
        Me.RecipientIconColumn.Text = ""
        Me.RecipientIconColumn.Width = 25
        '
        'RecipientTypeColumn
        '
        Me.RecipientTypeColumn.AspectName = ""
        Me.RecipientTypeColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RecipientTypeColumn.Text = "Type"
        Me.RecipientTypeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RecipientTypeColumn.Width = 50
        '
        'RecipientNameColumn
        '
        Me.RecipientNameColumn.AspectName = "FullName"
        Me.RecipientNameColumn.Text = "Name"
        Me.RecipientNameColumn.Width = 100
        '
        'RecipientAddressColumn
        '
        Me.RecipientAddressColumn.AspectName = "Address"
        Me.RecipientAddressColumn.Text = "Email Address"
        Me.RecipientAddressColumn.Width = 90
        '
        'ctxmnuRecipients
        '
        Me.ctxmnuRecipients.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveRecipientToolStripMenuItem})
        Me.ctxmnuRecipients.Name = "ctxmnuAddressBook"
        Me.ctxmnuRecipients.Size = New System.Drawing.Size(183, 26)
        '
        'RemoveRecipientToolStripMenuItem
        '
        Me.RemoveRecipientToolStripMenuItem.Name = "RemoveRecipientToolStripMenuItem"
        Me.RemoveRecipientToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.RemoveRecipientToolStripMenuItem.Text = "&Remove Recipient(s)"
        '
        'olvAttachments
        '
        Me.olvAttachments.AllColumns.Add(Me.AttachmentNameColumn)
        Me.olvAttachments.AllColumns.Add(Me.OlvColumnFileSize)
        Me.olvAttachments.AllowDrop = True
        Me.olvAttachments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.olvAttachments.CellEditUseWholeCell = False
        Me.olvAttachments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.AttachmentNameColumn, Me.OlvColumnFileSize})
        Me.olvAttachments.ContextMenuStrip = Me.ctxmnuAttachments
        Me.olvAttachments.CopySelectionOnControlC = False
        Me.olvAttachments.Cursor = System.Windows.Forms.Cursors.Default
        Me.olvAttachments.FullRowSelect = True
        Me.olvAttachments.GridLines = True
        Me.olvAttachments.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvAttachments.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvAttachments.LabelWrap = False
        Me.olvAttachments.Location = New System.Drawing.Point(439, 1)
        Me.olvAttachments.Name = "olvAttachments"
        Me.olvAttachments.SelectColumnsMenuStaysOpen = False
        Me.olvAttachments.SelectColumnsOnRightClick = False
        Me.olvAttachments.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvAttachments.ShowCommandMenuOnRightClick = True
        Me.olvAttachments.ShowGroups = False
        Me.olvAttachments.ShowItemToolTips = True
        Me.olvAttachments.Size = New System.Drawing.Size(216, 77)
        Me.olvAttachments.SmallImageList = Me.attachmentImageList
        Me.olvAttachments.TabIndex = 6
        Me.olvAttachments.UseCompatibleStateImageBehavior = False
        Me.olvAttachments.View = System.Windows.Forms.View.Details
        '
        'AttachmentNameColumn
        '
        Me.AttachmentNameColumn.AspectName = "DisplayName"
        Me.AttachmentNameColumn.Text = "Attachment Name"
        Me.AttachmentNameColumn.Width = 118
        '
        'OlvColumnFileSize
        '
        Me.OlvColumnFileSize.AspectName = "FileSize"
        Me.OlvColumnFileSize.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnFileSize.Text = "Size"
        Me.OlvColumnFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ctxmnuAttachments
        '
        Me.ctxmnuAttachments.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuAttachments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveAttachmentsToolStripMenuItem, Me.PasteClipboardContentsAsAttachmentsToolStripMenuItem})
        Me.ctxmnuAttachments.Name = "ctxmnuAddressBook"
        Me.ctxmnuAttachments.Size = New System.Drawing.Size(296, 48)
        '
        'RemoveAttachmentsToolStripMenuItem
        '
        Me.RemoveAttachmentsToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.RemoveAttachmentsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.RemoveAttachmentsToolStripMenuItem.Name = "RemoveAttachmentsToolStripMenuItem"
        Me.RemoveAttachmentsToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.RemoveAttachmentsToolStripMenuItem.Text = "&Remove Attachment(s)"
        '
        'PasteClipboardContentsAsAttachmentsToolStripMenuItem
        '
        Me.PasteClipboardContentsAsAttachmentsToolStripMenuItem.Enabled = False
        Me.PasteClipboardContentsAsAttachmentsToolStripMenuItem.Image = CType(resources.GetObject("PasteClipboardContentsAsAttachmentsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PasteClipboardContentsAsAttachmentsToolStripMenuItem.Name = "PasteClipboardContentsAsAttachmentsToolStripMenuItem"
        Me.PasteClipboardContentsAsAttachmentsToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.PasteClipboardContentsAsAttachmentsToolStripMenuItem.Text = "Paste clipboard contents as attachment(s)"
        Me.PasteClipboardContentsAsAttachmentsToolStripMenuItem.ToolTipText = "Paste clipboard contents as attachment (premium users only)"
        '
        'attachmentImageList
        '
        Me.attachmentImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.attachmentImageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.attachmentImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'chkZipAttachments
        '
        Me.chkZipAttachments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkZipAttachments.Location = New System.Drawing.Point(443, 79)
        Me.chkZipAttachments.Name = "chkZipAttachments"
        Me.chkZipAttachments.Size = New System.Drawing.Size(102, 23)
        Me.chkZipAttachments.TabIndex = 7
        Me.chkZipAttachments.Text = "Zip attachments"
        Me.ToolTip1.SetToolTip(Me.chkZipAttachments, "Check this box to compress all attachments into a zip file before emailing (not n" & _
        "ecessary for TrulyMail recipients)")
        Me.chkZipAttachments.UseVisualStyleBackColor = True
        '
        'picNewEmail
        '
        Me.picNewEmail.BackColor = System.Drawing.Color.White
        Me.picNewEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picNewEmail.Image = Global.TrulyMail.My.Resources.Resources.NewEmail_16
        Me.picNewEmail.Location = New System.Drawing.Point(3, 0)
        Me.picNewEmail.Name = "picNewEmail"
        Me.picNewEmail.Size = New System.Drawing.Size(42, 21)
        Me.picNewEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picNewEmail.TabIndex = 26
        Me.picNewEmail.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picNewEmail, "Add new email recipient")
        '
        'picTo
        '
        Me.picTo.BackColor = System.Drawing.Color.Yellow
        Me.picTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picTo.Image = Global.TrulyMail.My.Resources.Resources.To_Hot_16
        Me.picTo.Location = New System.Drawing.Point(3, 21)
        Me.picTo.Name = "picTo"
        Me.picTo.Size = New System.Drawing.Size(42, 21)
        Me.picTo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picTo.TabIndex = 27
        Me.picTo.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picTo, "Add selected contacts to 'TO' list (or press F2)")
        '
        'picCC
        '
        Me.picCC.BackColor = System.Drawing.Color.White
        Me.picCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picCC.Image = Global.TrulyMail.My.Resources.Resources.CC_16
        Me.picCC.Location = New System.Drawing.Point(3, 42)
        Me.picCC.Name = "picCC"
        Me.picCC.Size = New System.Drawing.Size(42, 21)
        Me.picCC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picCC.TabIndex = 28
        Me.picCC.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picCC, "Add selected contacts to 'CC' list (or press F3)")
        '
        'picBCC
        '
        Me.picBCC.BackColor = System.Drawing.Color.White
        Me.picBCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picBCC.Image = Global.TrulyMail.My.Resources.Resources.BCC_16
        Me.picBCC.Location = New System.Drawing.Point(3, 63)
        Me.picBCC.Name = "picBCC"
        Me.picBCC.Size = New System.Drawing.Size(42, 21)
        Me.picBCC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picBCC.TabIndex = 29
        Me.picBCC.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picBCC, "Add selected contacts to 'BCC' list (or press F4)")
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.White
        Me.PictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(3, 84)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(42, 21)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox6.TabIndex = 30
        Me.PictureBox6.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox6, "Remove selected recipients (or press Del)")
        '
        'Panel4
        '
        Me.Panel4.AutoSize = True
        Me.Panel4.Controls.Add(Me.txtSubject)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.lblRecipient)
        Me.Panel4.Controls.Add(Me.lblRecipCount)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 107)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(719, 36)
        Me.Panel4.TabIndex = 36
        '
        'txtSubject
        '
        Me.txtSubject.AcceptsReturn = True
        Me.txtSubject.AcceptsTab = True
        Me.txtSubject.AllowButtonSpecToolTips = True
        Me.txtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecAny() {Me.btnSubjectSpecialChar})
        Me.txtSubject.Location = New System.Drawing.Point(66, 5)
        Me.txtSubject.MaxLength = 200
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Palette = Me.KryptonPalette1
        Me.txtSubject.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtSubject.Size = New System.Drawing.Size(298, 28)
        Me.txtSubject.TabIndex = 35
        '
        'btnSubjectSpecialChar
        '
        Me.btnSubjectSpecialChar.Image = Global.TrulyMail.My.Resources.Resources.add_icon_16
        Me.btnSubjectSpecialChar.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Custom1
        Me.btnSubjectSpecialChar.ToolTipBody = "Add special characters to the subject"
        Me.btnSubjectSpecialChar.UniqueName = "EDBB1B43E7184E668C8141F115A2B58A"
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.LongText.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.KryptonPalette1.Common.StateCommon.Content.Padding = New System.Windows.Forms.Padding(2)
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonPalette1.InputControlStyles.InputControlCommon.StateNormal.Content.LongText.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.KryptonPalette1.InputControlStyles.InputControlCommon.StateNormal.Content.ShortText.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Subject:"
        '
        'lblRecipient
        '
        Me.lblRecipient.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRecipient.AutoSize = True
        Me.lblRecipient.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecipient.Location = New System.Drawing.Point(418, 7)
        Me.lblRecipient.Name = "lblRecipient"
        Me.lblRecipient.Size = New System.Drawing.Size(82, 16)
        Me.lblRecipient.TabIndex = 35
        Me.lblRecipient.Text = "Recipient(s)"
        '
        'lblRecipCount
        '
        Me.lblRecipCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRecipCount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecipCount.Location = New System.Drawing.Point(348, 7)
        Me.lblRecipCount.Name = "lblRecipCount"
        Me.lblRecipCount.Size = New System.Drawing.Size(71, 16)
        Me.lblRecipCount.TabIndex = 35
        Me.lblRecipCount.Text = "0"
        Me.lblRecipCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Editor1
        '
        Me.Editor1.BodyHtml = ""
        Me.Editor1.BodyText = Nothing
        Me.Editor1.ContentEditable = True
        Me.Editor1.CustomColors = Nothing
        Me.Editor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Editor1.DocumentText = resources.GetString("Editor1.DocumentText")
        Me.Editor1.EditorBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Editor1.EditorForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Editor1.EmojiGroup1Image = Global.TrulyMail.My.Resources.Resources.PeopleSmile
        Me.Editor1.EmojiGroup1Path = "Emoji\People"
        Me.Editor1.EmojiGroup1Title = "People and faces"
        Me.Editor1.EmojiGroup2Image = Global.TrulyMail.My.Resources.Resources.FeelingsHeart
        Me.Editor1.EmojiGroup2Path = "Emoji\Feelings"
        Me.Editor1.EmojiGroup2Title = "Feelings"
        Me.Editor1.EmojiGroup3Image = Global.TrulyMail.My.Resources.Resources.FoodAvocado
        Me.Editor1.EmojiGroup3Path = "Emoji\Food"
        Me.Editor1.EmojiGroup3Title = "Food"
        Me.Editor1.EmojiGroup4Image = Global.TrulyMail.My.Resources.Resources.AnimalsMouse
        Me.Editor1.EmojiGroup4Path = "Emoji\Animals"
        Me.Editor1.EmojiGroup4Title = "Animals"
        Me.Editor1.EmojiGroup5Image = Global.TrulyMail.My.Resources.Resources.NatureMoon
        Me.Editor1.EmojiGroup5Path = "Emoji\Nature"
        Me.Editor1.EmojiGroup5Title = "Nature"
        Me.Editor1.EmojiGroup6Image = Global.TrulyMail.My.Resources.Resources.ActionPiano
        Me.Editor1.EmojiGroup6Path = "Emoji\Action"
        Me.Editor1.EmojiGroup6Title = "Action"
        Me.Editor1.EmojiGroup7Image = Global.TrulyMail.My.Resources.Resources.OtherMoney
        Me.Editor1.EmojiGroup7Path = "Emoji\Other"
        Me.Editor1.EmojiGroup7Title = "Other"
        Me.Editor1.EmojiVisible = True
        Me.Editor1.FontSize = TrulyMail.FontSize.Three
        Me.Editor1.HideContextMenu = False
        Me.Editor1.HTMLToolBar = True
        Me.Editor1.KeyPreview = True
        Me.Editor1.Location = New System.Drawing.Point(0, 0)
        Me.Editor1.Name = "Editor1"
        Me.Editor1.Size = New System.Drawing.Size(719, 301)
        Me.Editor1.TabIndex = 37
        Me.Editor1.ToolBarVisible = True
        '
        'pnlSMTPAccount
        '
        Me.pnlSMTPAccount.Controls.Add(Me.cboSMTPAccount)
        Me.pnlSMTPAccount.Controls.Add(Me.lblFrom)
        Me.pnlSMTPAccount.Controls.Add(Me.lblSMTPFrom)
        Me.pnlSMTPAccount.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSMTPAccount.Location = New System.Drawing.Point(0, 0)
        Me.pnlSMTPAccount.Name = "pnlSMTPAccount"
        Me.pnlSMTPAccount.Size = New System.Drawing.Size(719, 25)
        Me.pnlSMTPAccount.TabIndex = 25
        '
        'cboSMTPAccount
        '
        Me.cboSMTPAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSMTPAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSMTPAccount.FormattingEnabled = True
        Me.cboSMTPAccount.Location = New System.Drawing.Point(66, 2)
        Me.cboSMTPAccount.Name = "cboSMTPAccount"
        Me.cboSMTPAccount.Size = New System.Drawing.Size(641, 21)
        Me.cboSMTPAccount.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cboSMTPAccount, "The 'From' drop down is only used for email recipients. TrulyMail Recipients are " & _
        "processed through the TrulyMail server")
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom.Location = New System.Drawing.Point(70, 4)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(0, 16)
        Me.lblFrom.TabIndex = 24
        '
        'lblSMTPFrom
        '
        Me.lblSMTPFrom.AutoSize = True
        Me.lblSMTPFrom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSMTPFrom.Location = New System.Drawing.Point(8, 4)
        Me.lblSMTPFrom.Name = "lblSMTPFrom"
        Me.lblSMTPFrom.Size = New System.Drawing.Size(45, 16)
        Me.lblSMTPFrom.TabIndex = 23
        Me.lblSMTPFrom.Text = "From:"
        '
        'WebBrowser2
        '
        Me.WebBrowser2.AllowWebBrowserDrop = False
        Me.WebBrowser2.Location = New System.Drawing.Point(66, 165)
        Me.WebBrowser2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser2.Name = "WebBrowser2"
        Me.WebBrowser2.Size = New System.Drawing.Size(207, 121)
        Me.WebBrowser2.TabIndex = 20
        Me.WebBrowser2.Visible = False
        Me.WebBrowser2.WebBrowserShortcutsEnabled = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSend, Me.SaveAsDraftToolStripButton, Me.btnToggleAddressBook, Me.AddAttachmentsToolStripButton, Me.SpellCheckToolStripSplitButton, Me.SpellAsTypeToolStripButton, Me.PrintToolStripButton, Me.ToolStripSeparator3, Me.SaveACopyToolStripButton, Me.ToolStripDropDownButton1, Me.ReturnReceiptToolStripButton, Me.EncryptedEmailTypeToolStripDropDownButton, Me.PlainTextToolStripButton, Me.ShowAutoTextToolStripButton, Me.ToolStripSeparator7, Me.ToolStripLabel1, Me.MessageTagsToolStripTextBox})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(888, 38)
        Me.ToolStrip1.TabIndex = 16
        '
        'btnSend
        '
        Me.btnSend.Image = Global.TrulyMail.My.Resources.Resources.sendmail_32
        Me.btnSend.ImageTransparentColor = System.Drawing.Color.White
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(65, 35)
        Me.btnSend.Text = "Send Now"
        Me.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSend.ToolTipText = "Send Message"
        '
        'SaveAsDraftToolStripButton
        '
        Me.SaveAsDraftToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.Savefile_32
        Me.SaveAsDraftToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveAsDraftToolStripButton.Name = "SaveAsDraftToolStripButton"
        Me.SaveAsDraftToolStripButton.Size = New System.Drawing.Size(35, 35)
        Me.SaveAsDraftToolStripButton.Text = "Save"
        Me.SaveAsDraftToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.SaveAsDraftToolStripButton.ToolTipText = "Save as draft (Ctrl+S)"
        '
        'btnToggleAddressBook
        '
        Me.btnToggleAddressBook.Checked = True
        Me.btnToggleAddressBook.CheckOnClick = True
        Me.btnToggleAddressBook.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnToggleAddressBook.Image = Global.TrulyMail.My.Resources.Resources.Addressbook_32
        Me.btnToggleAddressBook.ImageTransparentColor = System.Drawing.Color.White
        Me.btnToggleAddressBook.Name = "btnToggleAddressBook"
        Me.btnToggleAddressBook.Size = New System.Drawing.Size(58, 35)
        Me.btnToggleAddressBook.Text = "Contacts"
        Me.btnToggleAddressBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnToggleAddressBook.ToolTipText = "Show or Hide the Address Book"
        '
        'AddAttachmentsToolStripButton
        '
        Me.AddAttachmentsToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.Attach_32
        Me.AddAttachmentsToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.AddAttachmentsToolStripButton.Name = "AddAttachmentsToolStripButton"
        Me.AddAttachmentsToolStripButton.Size = New System.Drawing.Size(46, 35)
        Me.AddAttachmentsToolStripButton.Text = "Attach"
        Me.AddAttachmentsToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.AddAttachmentsToolStripButton.ToolTipText = "Add Attachments"
        '
        'SpellCheckToolStripSplitButton
        '
        Me.SpellCheckToolStripSplitButton.Image = Global.TrulyMail.My.Resources.Resources.Spellcheck_16
        Me.SpellCheckToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.White
        Me.SpellCheckToolStripSplitButton.Name = "SpellCheckToolStripSplitButton"
        Me.SpellCheckToolStripSplitButton.Size = New System.Drawing.Size(84, 35)
        Me.SpellCheckToolStripSplitButton.Text = "Spell Check"
        Me.SpellCheckToolStripSplitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'SpellAsTypeToolStripButton
        '
        Me.SpellAsTypeToolStripButton.CheckOnClick = True
        Me.SpellAsTypeToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.SpellAsYouType_32
        Me.SpellAsTypeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SpellAsTypeToolStripButton.Name = "SpellAsTypeToolStripButton"
        Me.SpellAsTypeToolStripButton.Size = New System.Drawing.Size(65, 35)
        Me.SpellAsTypeToolStripButton.Text = "Auto Spell"
        Me.SpellAsTypeToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.SpellAsTypeToolStripButton.ToolTipText = "Auto Spell Check"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.Print_16
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(36, 35)
        Me.PrintToolStripButton.Text = "Print"
        Me.PrintToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 38)
        '
        'SaveACopyToolStripButton
        '
        Me.SaveACopyToolStripButton.Checked = True
        Me.SaveACopyToolStripButton.CheckOnClick = True
        Me.SaveACopyToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SaveACopyToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.MessageCopy_16
        Me.SaveACopyToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.SaveACopyToolStripButton.Name = "SaveACopyToolStripButton"
        Me.SaveACopyToolStripButton.Size = New System.Drawing.Size(66, 35)
        Me.SaveACopyToolStripButton.Text = "Save Copy"
        Me.SaveACopyToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.SaveACopyToolStripButton.ToolTipText = "Save a copy of this message in Sent Items"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HighPriorityToolStripMenuItem, Me.NormalPriorityToolStripMenuItem, Me.LowPriorityToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 35)
        Me.ToolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripDropDownButton1.Visible = False
        '
        'HighPriorityToolStripMenuItem
        '
        Me.HighPriorityToolStripMenuItem.Name = "HighPriorityToolStripMenuItem"
        Me.HighPriorityToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.HighPriorityToolStripMenuItem.Text = "High Priority"
        '
        'NormalPriorityToolStripMenuItem
        '
        Me.NormalPriorityToolStripMenuItem.Name = "NormalPriorityToolStripMenuItem"
        Me.NormalPriorityToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.NormalPriorityToolStripMenuItem.Text = "Normal Priority"
        '
        'LowPriorityToolStripMenuItem
        '
        Me.LowPriorityToolStripMenuItem.Name = "LowPriorityToolStripMenuItem"
        Me.LowPriorityToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.LowPriorityToolStripMenuItem.Text = "Low Priority"
        '
        'ReturnReceiptToolStripButton
        '
        Me.ReturnReceiptToolStripButton.CheckOnClick = True
        Me.ReturnReceiptToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.Postman_16
        Me.ReturnReceiptToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.ReturnReceiptToolStripButton.Name = "ReturnReceiptToolStripButton"
        Me.ReturnReceiptToolStripButton.Size = New System.Drawing.Size(50, 35)
        Me.ReturnReceiptToolStripButton.Text = "Receipt"
        Me.ReturnReceiptToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ReturnReceiptToolStripButton.ToolTipText = "Request Return Receipt from Email Recipients"
        '
        'EncryptedEmailTypeToolStripDropDownButton
        '
        Me.EncryptedEmailTypeToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnencryptedEmailToolStripMenuItem, Me.EncryptedToOtherTrulyMailUsersToolStripMenuItem})
        Me.EncryptedEmailTypeToolStripDropDownButton.Image = CType(resources.GetObject("EncryptedEmailTypeToolStripDropDownButton.Image"), System.Drawing.Image)
        Me.EncryptedEmailTypeToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EncryptedEmailTypeToolStripDropDownButton.Name = "EncryptedEmailTypeToolStripDropDownButton"
        Me.EncryptedEmailTypeToolStripDropDownButton.Size = New System.Drawing.Size(88, 35)
        Me.EncryptedEmailTypeToolStripDropDownButton.Text = "Unencrypted"
        Me.EncryptedEmailTypeToolStripDropDownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'UnencryptedEmailToolStripMenuItem
        '
        Me.UnencryptedEmailToolStripMenuItem.Image = CType(resources.GetObject("UnencryptedEmailToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UnencryptedEmailToolStripMenuItem.Name = "UnencryptedEmailToolStripMenuItem"
        Me.UnencryptedEmailToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.UnencryptedEmailToolStripMenuItem.Text = "Unencrypted"
        '
        'EncryptedToOtherTrulyMailUsersToolStripMenuItem
        '
        Me.EncryptedToOtherTrulyMailUsersToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Securedmessage_16
        Me.EncryptedToOtherTrulyMailUsersToolStripMenuItem.Name = "EncryptedToOtherTrulyMailUsersToolStripMenuItem"
        Me.EncryptedToOtherTrulyMailUsersToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.EncryptedToOtherTrulyMailUsersToolStripMenuItem.Text = "Encrypted to other TrulyMail users"
        Me.EncryptedToOtherTrulyMailUsersToolStripMenuItem.ToolTipText = "Keeps message contents private but can only be read by other TrulyMail users"
        '
        'PlainTextToolStripButton
        '
        Me.PlainTextToolStripButton.CheckOnClick = True
        Me.PlainTextToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.Text_16
        Me.PlainTextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PlainTextToolStripButton.Name = "PlainTextToolStripButton"
        Me.PlainTextToolStripButton.Size = New System.Drawing.Size(61, 35)
        Me.PlainTextToolStripButton.Text = "Plain Text"
        Me.PlainTextToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.PlainTextToolStripButton.ToolTipText = "Send message as plain text (email only)"
        '
        'ShowAutoTextToolStripButton
        '
        Me.ShowAutoTextToolStripButton.Checked = True
        Me.ShowAutoTextToolStripButton.CheckOnClick = True
        Me.ShowAutoTextToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowAutoTextToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.AutoText_32
        Me.ShowAutoTextToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.ShowAutoTextToolStripButton.Name = "ShowAutoTextToolStripButton"
        Me.ShowAutoTextToolStripButton.Size = New System.Drawing.Size(58, 35)
        Me.ShowAutoTextToolStripButton.Text = "AutoText"
        Me.ShowAutoTextToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 38)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(39, 35)
        Me.ToolStripLabel1.Text = "Tags:"
        Me.ToolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MessageTagsToolStripTextBox
        '
        Me.MessageTagsToolStripTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.MessageTagsToolStripTextBox.AutoSize = False
        Me.MessageTagsToolStripTextBox.AutoToolTip = True
        Me.MessageTagsToolStripTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.MessageTagsToolStripTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MessageTagsToolStripTextBox.MaxLength = 250
        Me.MessageTagsToolStripTextBox.Name = "MessageTagsToolStripTextBox"
        Me.MessageTagsToolStripTextBox.Size = New System.Drawing.Size(120, 23)
        Me.MessageTagsToolStripTextBox.ToolTipText = "Enter tags you want applied to this message (not transmitted to recipients)"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chkCreateReminder)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(265, 22)
        Me.Panel2.TabIndex = 1
        '
        'chkCreateReminder
        '
        Me.chkCreateReminder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkCreateReminder.Location = New System.Drawing.Point(6, 3)
        Me.chkCreateReminder.Name = "chkCreateReminder"
        Me.chkCreateReminder.Size = New System.Drawing.Size(206, 16)
        Me.chkCreateReminder.TabIndex = 8
        Me.chkCreateReminder.Text = "Create Reminder"
        Me.chkCreateReminder.UseVisualStyleBackColor = True
        '
        'tmrAutoSave
        '
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 2500
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'tmrSetDefaultFont
        '
        Me.tmrSetDefaultFont.Enabled = True
        Me.tmrSetDefaultFont.Interval = 1000
        '
        'tmrFlashInfo
        '
        Me.tmrFlashInfo.Enabled = True
        Me.tmrFlashInfo.Interval = 333
        '
        'tmrDelayedSettingBackColor
        '
        Me.tmrDelayedSettingBackColor.Enabled = True
        Me.tmrDelayedSettingBackColor.Interval = 500
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6})
        Me.ContextMenuStrip1.Name = "ctxmnuAddressBook"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(140, 92)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(139, 22)
        Me.ToolStripMenuItem2.Text = "‡"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(139, 22)
        Me.ToolStripMenuItem4.Text = "Add as &CC"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(139, 22)
        Me.ToolStripMenuItem5.Text = "Add as &BCC"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(139, 22)
        Me.ToolStripMenuItem6.Text = "&Edit Contact"
        '
        'NewMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(979, 557)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "NewMessage"
        Me.Text = "New Message"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainerContactsAutoText.Panel1.ResumeLayout(False)
        Me.SplitContainerContactsAutoText.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerContactsAutoText, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerContactsAutoText.ResumeLayout(False)
        CType(Me.olvContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmnuAddressBook.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerAutoTextArea.Panel1.ResumeLayout(False)
        Me.SplitContainerAutoTextArea.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerAutoTextArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerAutoTextArea.ResumeLayout(False)
        CType(Me.olvAutoTexts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmnuAutoText.ResumeLayout(False)
        Me.SplitContainerRecipsEditor.Panel1.ResumeLayout(False)
        Me.SplitContainerRecipsEditor.Panel1.PerformLayout()
        Me.SplitContainerRecipsEditor.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerRecipsEditor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerRecipsEditor.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pnlRecipients.ResumeLayout(False)
        CType(Me.olvRecipients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmnuRecipients.ResumeLayout(False)
        CType(Me.olvAttachments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmnuAttachments.ResumeLayout(False)
        CType(Me.picNewEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlSMTPAccount.ResumeLayout(False)
        Me.pnlSMTPAccount.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.C1SpellChecker1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddAttachmentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabelMessageSize As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents SendLaterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopSendingToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpellCheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsDraftToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tmrStartClean As System.Windows.Forms.Timer
    Friend WithEvents EncryptedToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ServerStatusToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FillerToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents InsertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HorizontalLineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrAutoSave As System.Windows.Forms.Timer
    Friend WithEvents olvAttachments As BrightIdeasSoftware.ObjectListView
    Friend WithEvents AttachmentNameColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnFileSize As BrightIdeasSoftware.OLVColumn
    Friend WithEvents WebBrowser2 As System.Windows.Forms.WebBrowser
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Editor1 As TrulyMail.Editor
    Friend WithEvents txtAddressSearch As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents olvContacts As BrightIdeasSoftware.ObjectListView
    Friend WithEvents NameColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents AddressColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents recipientImageList As System.Windows.Forms.ImageList
    Friend WithEvents olvRecipients As BrightIdeasSoftware.ObjectListView
    Friend WithEvents lblSMTPFrom As System.Windows.Forms.Label
    Friend WithEvents cboSMTPAccount As System.Windows.Forms.ComboBox
    Friend WithEvents pnlRecipients As System.Windows.Forms.Panel
    Friend WithEvents pnlSMTPAccount As System.Windows.Forms.Panel
    Friend WithEvents RecipientTypeColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents RecipientNameColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents RecipientAddressColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents RecipientIconColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents picNewEmail As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents picBCC As System.Windows.Forms.PictureBox
    Friend WithEvents picCC As System.Windows.Forms.PictureBox
    Friend WithEvents picTo As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents attachmentImageList As System.Windows.Forms.ImageList
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents NewMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tmrSetDefaultFont As System.Windows.Forms.Timer
    Friend WithEvents TagsColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents PasteAsTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendPlainTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RequestReturnReceiptemailOnlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveACopyInSentItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrFlashInfo As System.Windows.Forms.Timer
    Friend WithEvents tmrDelayedSettingBackColor As System.Windows.Forms.Timer
    Friend WithEvents C1SpellChecker1 As C1.Win.C1SpellChecker.C1SpellChecker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSend As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveAsDraftToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnToggleAddressBook As System.Windows.Forms.ToolStripButton
    Friend WithEvents AddAttachmentsToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SpellCheckToolStripSplitButton As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents SpellAsTypeToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveACopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents HighPriorityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NormalPriorityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LowPriorityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReturnReceiptToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents MessageTagsToolStripTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents EncryptedEmailTypeToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents UnencryptedEmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxmnuAddressBook As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddAsToToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddAsCCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddAsBCCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditContactToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailEncryptionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailEncryptionNoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainerRecipsEditor As System.Windows.Forms.SplitContainer
    Friend WithEvents lblRecipCount As System.Windows.Forms.Label
    Friend WithEvents lblRecipient As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AutoTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageAutoTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SplitContainerContactsAutoText As System.Windows.Forms.SplitContainer
    Friend WithEvents ShowAutoTextToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents olvAutoTexts As BrightIdeasSoftware.ObjectListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents HTMLColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents EditorAutoText As TrulyMail.Editor
    Friend WithEvents SplitContainerAutoTextArea As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RecordingMicrophoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents KeyCodeColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ctxmnuRecipients As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoveRecipientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxmnuAttachments As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoveAttachmentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkZipAttachments As System.Windows.Forms.CheckBox
    Friend WithEvents PlainTextToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SendNowAsAsNewsletterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkCreateReminder As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditMessageHTMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxmnuAutoText As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSubject As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnSubjectSpecialChar As ComponentFactory.Krypton.Toolkit.ButtonSpecAny
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents InsertTableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReadMessageContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReadMessagePauseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReadMessageResumeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EncryptedToOtherTrulyMailUsersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EncryptedToOtherTrulyMailUsersToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteClipboardContentsAsAttachmentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddAttachmentsFromClipboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
