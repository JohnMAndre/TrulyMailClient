<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadMessageControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadMessageControl))
        Dim HeaderStateStyle1 As BrightIdeasSoftware.HeaderStateStyle = New BrightIdeasSoftware.HeaderStateStyle()
        Dim HeaderStateStyle2 As BrightIdeasSoftware.HeaderStateStyle = New BrightIdeasSoftware.HeaderStateStyle()
        Dim HeaderStateStyle3 As BrightIdeasSoftware.HeaderStateStyle = New BrightIdeasSoftware.HeaderStateStyle()
        Me.pnlRemoteImages = New System.Windows.Forms.Panel()
        Me.pbNeverBlockRemoteImagesForSender = New System.Windows.Forms.PictureBox()
        Me.pbUnblockRemoteImages = New System.Windows.Forms.PictureBox()
        Me.pbShowRemoteImageURLs = New System.Windows.Forms.PictureBox()
        Me.pbRemoteImageInfo = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerRecipAttachments = New System.Windows.Forms.SplitContainer()
        Me.olvRecipients = New BrightIdeasSoftware.ObjectListView()
        Me.RecipientIconColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.RecipientTypeColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.RecipientNameColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.RecipientAddressColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ReceivedColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ViewedColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ResentColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ctxmnuRecipients = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewEmailToThisContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToAddressBookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkReadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyemailAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaunchSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.NewMessageProcessingruleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaunchURLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.recipientImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.olvAttachments = New BrightIdeasSoftware.ObjectListView()
        Me.AttachmentNameColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnFileSize = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ctxmnuAttachments = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenAttachmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileLocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.attachmentImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.NotesBodySplitContainer = New System.Windows.Forms.SplitContainer()
        Me.txtNotes = New System.Windows.Forms.RichTextBox()
        Me.ctxReadText = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.NotesEditToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.NotesSaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteNotesToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SplitContainerPadding = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerReaderReplyBox = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.rtbBody = New System.Windows.Forms.RichTextBox()
        Me.pnlBlockedNotice = New System.Windows.Forms.Panel()
        Me.llblBlockedScriptsInfo = New System.Windows.Forms.LinkLabel()
        Me.picCloseBlockPanel = New System.Windows.Forms.PictureBox()
        Me.chkDoNotShowBlockPanel = New System.Windows.Forms.CheckBox()
        Me.lblBlockText = New System.Windows.Forms.Label()
        Me.pnlRSSLink = New System.Windows.Forms.Panel()
        Me.llblRSSLink = New System.Windows.Forms.LinkLabel()
        Me.ctxmnuRSSLink = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyLinkAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlTM2TM = New System.Windows.Forms.Panel()
        Me.txtDecryptionPassword = New System.Windows.Forms.TextBox()
        Me.btnDecrypt = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlAudioPlayer = New System.Windows.Forms.Panel()
        Me.AudioPlayer1 = New TrulyMail.AudioPlayer()
        Me.WebBrowser2 = New System.Windows.Forms.WebBrowser()
        Me.pnlBrowserZoom = New System.Windows.Forms.Panel()
        Me.tbZoom = New System.Windows.Forms.TrackBar()
        Me.lblZoomValue = New System.Windows.Forms.Label()
        Me.lblZoom = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkDoNotShowProcessReceiptPanel = New System.Windows.Forms.CheckBox()
        Me.pbCloseReceiptPanel = New System.Windows.Forms.PictureBox()
        Me.pbFindMessagesForReceipts = New System.Windows.Forms.PictureBox()
        Me.pbReturnReceiptInfo = New System.Windows.Forms.PictureBox()
        Me.lvMessages = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumnSubject = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnMessageAttachments = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.HeaderFormatStyleWingDings = New BrightIdeasSoftware.HeaderFormatStyle()
        Me.OlvColumnRecipients = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnMessageDate = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnSize = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnReceived = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnViewed = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ctxmnuMatchingMessages = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkMessageReadAndDeleteThisReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImglstMessageStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.olvReplyModes = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumnReplyModeText = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.replyModeImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlFind = New System.Windows.Forms.Panel()
        Me.btnFindNext = New System.Windows.Forms.Button()
        Me.txtFindText = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.picCloseFindPanel = New System.Windows.Forms.PictureBox()
        Me.pnlHeaderAreaCompact = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSubject2 = New System.Windows.Forms.RichTextBox()
        Me.lblSent2 = New System.Windows.Forms.Label()
        Me.picHeaderAreaExpand = New System.Windows.Forms.PictureBox()
        Me.llblFrom2 = New System.Windows.Forms.LinkLabel()
        Me.pnlHeaderAreaFull = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSubject = New System.Windows.Forms.RichTextBox()
        Me.lblSent = New System.Windows.Forms.Label()
        Me.llblReplyTo = New System.Windows.Forms.LinkLabel()
        Me.picHeaderAreaCollapse = New System.Windows.Forms.PictureBox()
        Me.lblSentLabel = New System.Windows.Forms.Label()
        Me.llblFrom = New System.Windows.Forms.LinkLabel()
        Me.lblSizeLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblMessageSize = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.tmrLoadMessage = New System.Windows.Forms.Timer(Me.components)
        Me.DescribedTaskRenderer1 = New BrightIdeasSoftware.DescribedTaskRenderer()
        Me.pnlRemoteImages.SuspendLayout()
        CType(Me.pbNeverBlockRemoteImagesForSender, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbUnblockRemoteImages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbShowRemoteImageURLs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbRemoteImageInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainerRecipAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerRecipAttachments.Panel1.SuspendLayout()
        Me.SplitContainerRecipAttachments.Panel2.SuspendLayout()
        Me.SplitContainerRecipAttachments.SuspendLayout()
        CType(Me.olvRecipients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmnuRecipients.SuspendLayout()
        CType(Me.olvAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmnuAttachments.SuspendLayout()
        CType(Me.NotesBodySplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NotesBodySplitContainer.Panel1.SuspendLayout()
        Me.NotesBodySplitContainer.Panel2.SuspendLayout()
        Me.NotesBodySplitContainer.SuspendLayout()
        Me.ctxReadText.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.SplitContainerPadding, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerPadding.Panel1.SuspendLayout()
        Me.SplitContainerPadding.SuspendLayout()
        CType(Me.SplitContainerReaderReplyBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerReaderReplyBox.Panel1.SuspendLayout()
        Me.SplitContainerReaderReplyBox.Panel2.SuspendLayout()
        Me.SplitContainerReaderReplyBox.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlBlockedNotice.SuspendLayout()
        CType(Me.picCloseBlockPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRSSLink.SuspendLayout()
        Me.ctxmnuRSSLink.SuspendLayout()
        Me.pnlTM2TM.SuspendLayout()
        Me.pnlAudioPlayer.SuspendLayout()
        Me.pnlBrowserZoom.SuspendLayout()
        CType(Me.tbZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbCloseReceiptPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbFindMessagesForReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbReturnReceiptInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lvMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmnuMatchingMessages.SuspendLayout()
        CType(Me.olvReplyModes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFind.SuspendLayout()
        CType(Me.picCloseFindPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeaderAreaCompact.SuspendLayout()
        CType(Me.picHeaderAreaExpand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeaderAreaFull.SuspendLayout()
        CType(Me.picHeaderAreaCollapse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlRemoteImages
        '
        Me.pnlRemoteImages.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pnlRemoteImages.Controls.Add(Me.pbNeverBlockRemoteImagesForSender)
        Me.pnlRemoteImages.Controls.Add(Me.pbUnblockRemoteImages)
        Me.pnlRemoteImages.Controls.Add(Me.pbShowRemoteImageURLs)
        Me.pnlRemoteImages.Controls.Add(Me.pbRemoteImageInfo)
        Me.pnlRemoteImages.Controls.Add(Me.Label2)
        Me.pnlRemoteImages.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRemoteImages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlRemoteImages.Location = New System.Drawing.Point(0, 0)
        Me.pnlRemoteImages.Name = "pnlRemoteImages"
        Me.pnlRemoteImages.Size = New System.Drawing.Size(1076, 49)
        Me.pnlRemoteImages.TabIndex = 22
        '
        'pbNeverBlockRemoteImagesForSender
        '
        Me.pbNeverBlockRemoteImagesForSender.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbNeverBlockRemoteImagesForSender.Image = Global.TrulyMail.My.Resources.Resources.Sender_Good_32
        Me.pbNeverBlockRemoteImagesForSender.Location = New System.Drawing.Point(906, 17)
        Me.pbNeverBlockRemoteImagesForSender.Name = "pbNeverBlockRemoteImagesForSender"
        Me.pbNeverBlockRemoteImagesForSender.Size = New System.Drawing.Size(36, 36)
        Me.pbNeverBlockRemoteImagesForSender.TabIndex = 17
        Me.pbNeverBlockRemoteImagesForSender.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbNeverBlockRemoteImagesForSender, "Click to always allow remote images from this sender")
        '
        'pbUnblockRemoteImages
        '
        Me.pbUnblockRemoteImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbUnblockRemoteImages.Image = Global.TrulyMail.My.Resources.Resources.Unlock_32
        Me.pbUnblockRemoteImages.Location = New System.Drawing.Point(1037, 17)
        Me.pbUnblockRemoteImages.Name = "pbUnblockRemoteImages"
        Me.pbUnblockRemoteImages.Size = New System.Drawing.Size(36, 36)
        Me.pbUnblockRemoteImages.TabIndex = 16
        Me.pbUnblockRemoteImages.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbUnblockRemoteImages, "Click to unblock remote images for this message")
        '
        'pbShowRemoteImageURLs
        '
        Me.pbShowRemoteImageURLs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbShowRemoteImageURLs.Image = Global.TrulyMail.My.Resources.Resources.ShowRemoteImageURLs_32
        Me.pbShowRemoteImageURLs.Location = New System.Drawing.Point(995, 17)
        Me.pbShowRemoteImageURLs.Name = "pbShowRemoteImageURLs"
        Me.pbShowRemoteImageURLs.Size = New System.Drawing.Size(36, 36)
        Me.pbShowRemoteImageURLs.TabIndex = 15
        Me.pbShowRemoteImageURLs.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbShowRemoteImageURLs, "Click to show the addresses of all the remote images in this message (allowing yo" & _
        "u to remove some and leave others)")
        '
        'pbRemoteImageInfo
        '
        Me.pbRemoteImageInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbRemoteImageInfo.Image = Global.TrulyMail.My.Resources.Resources.info_32
        Me.pbRemoteImageInfo.Location = New System.Drawing.Point(953, 17)
        Me.pbRemoteImageInfo.Name = "pbRemoteImageInfo"
        Me.pbRemoteImageInfo.Size = New System.Drawing.Size(36, 36)
        Me.pbRemoteImageInfo.TabIndex = 14
        Me.pbRemoteImageInfo.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbRemoteImageInfo, "Click for more information about remote images")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(465, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "For security reasons, remote images in this message have been blocked"
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.SplitContainer2)
        Me.pnlMain.Controls.Add(Me.pnlHeaderAreaCompact)
        Me.pnlMain.Controls.Add(Me.pnlHeaderAreaFull)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 49)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1076, 738)
        Me.pnlMain.TabIndex = 23
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 65)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainerRecipAttachments)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.NotesBodySplitContainer)
        Me.SplitContainer2.Size = New System.Drawing.Size(1076, 673)
        Me.SplitContainer2.SplitterDistance = 54
        Me.SplitContainer2.TabIndex = 9
        '
        'SplitContainerRecipAttachments
        '
        Me.SplitContainerRecipAttachments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerRecipAttachments.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerRecipAttachments.Name = "SplitContainerRecipAttachments"
        '
        'SplitContainerRecipAttachments.Panel1
        '
        Me.SplitContainerRecipAttachments.Panel1.Controls.Add(Me.olvRecipients)
        '
        'SplitContainerRecipAttachments.Panel2
        '
        Me.SplitContainerRecipAttachments.Panel2.Controls.Add(Me.olvAttachments)
        Me.SplitContainerRecipAttachments.Size = New System.Drawing.Size(1076, 54)
        Me.SplitContainerRecipAttachments.SplitterDistance = 701
        Me.SplitContainerRecipAttachments.TabIndex = 19
        '
        'olvRecipients
        '
        Me.olvRecipients.AllColumns.Add(Me.RecipientIconColumn)
        Me.olvRecipients.AllColumns.Add(Me.RecipientTypeColumn)
        Me.olvRecipients.AllColumns.Add(Me.RecipientNameColumn)
        Me.olvRecipients.AllColumns.Add(Me.RecipientAddressColumn)
        Me.olvRecipients.AllColumns.Add(Me.ReceivedColumn)
        Me.olvRecipients.AllColumns.Add(Me.ViewedColumn)
        Me.olvRecipients.AllColumns.Add(Me.ResentColumn)
        Me.olvRecipients.AllowColumnReorder = True
        Me.olvRecipients.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvRecipients.CellEditUseWholeCell = False
        Me.olvRecipients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.RecipientIconColumn, Me.RecipientTypeColumn, Me.RecipientNameColumn, Me.RecipientAddressColumn, Me.ReceivedColumn, Me.ViewedColumn, Me.ResentColumn})
        Me.olvRecipients.ContextMenuStrip = Me.ctxmnuRecipients
        Me.olvRecipients.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.olvRecipients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvRecipients.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!)
        Me.olvRecipients.FullRowSelect = True
        Me.olvRecipients.GridLines = True
        Me.olvRecipients.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvRecipients.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvRecipients.LabelWrap = False
        Me.olvRecipients.Location = New System.Drawing.Point(0, 0)
        Me.olvRecipients.Name = "olvRecipients"
        Me.olvRecipients.SelectColumnsMenuStaysOpen = False
        Me.olvRecipients.SelectColumnsOnRightClick = False
        Me.olvRecipients.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvRecipients.ShowGroups = False
        Me.olvRecipients.Size = New System.Drawing.Size(701, 54)
        Me.olvRecipients.SmallImageList = Me.recipientImageList
        Me.olvRecipients.SortGroupItemsByPrimaryColumn = False
        Me.olvRecipients.TabIndex = 22
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
        Me.RecipientTypeColumn.AspectName = "RecipientType"
        Me.RecipientTypeColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RecipientTypeColumn.Text = "Type"
        Me.RecipientTypeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RecipientTypeColumn.Width = 50
        '
        'RecipientNameColumn
        '
        Me.RecipientNameColumn.AspectName = "FullName"
        Me.RecipientNameColumn.Text = "Recipient Name"
        Me.RecipientNameColumn.Width = 100
        '
        'RecipientAddressColumn
        '
        Me.RecipientAddressColumn.AspectName = "Address"
        Me.RecipientAddressColumn.Text = "Email Address"
        Me.RecipientAddressColumn.Width = 90
        '
        'ReceivedColumn
        '
        Me.ReceivedColumn.AspectName = "ReceivedDate"
        Me.ReceivedColumn.Text = "Received"
        '
        'ViewedColumn
        '
        Me.ViewedColumn.AspectName = "ViewedDate"
        Me.ViewedColumn.Text = "Viewed"
        '
        'ResentColumn
        '
        Me.ResentColumn.AspectName = "ResentDate"
        Me.ResentColumn.Text = "Resent"
        '
        'ctxmnuRecipients
        '
        Me.ctxmnuRecipients.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuRecipients.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditContactToolStripMenuItem, Me.NewEmailToThisContactToolStripMenuItem, Me.AddToAddressBookToolStripMenuItem, Me.MarkReadToolStripMenuItem, Me.CopyemailAddressToolStripMenuItem, Me.LaunchSeparator, Me.NewMessageProcessingruleToolStripMenuItem, Me.LaunchURLToolStripMenuItem})
        Me.ctxmnuRecipients.Name = "ctxmnuRecipients"
        Me.ctxmnuRecipients.Size = New System.Drawing.Size(231, 186)
        '
        'EditContactToolStripMenuItem
        '
        Me.EditContactToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Userprofile_16
        Me.EditContactToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.EditContactToolStripMenuItem.Name = "EditContactToolStripMenuItem"
        Me.EditContactToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.EditContactToolStripMenuItem.Text = "Edit &contact"
        '
        'NewEmailToThisContactToolStripMenuItem
        '
        Me.NewEmailToThisContactToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Editpencil_16
        Me.NewEmailToThisContactToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.NewEmailToThisContactToolStripMenuItem.Name = "NewEmailToThisContactToolStripMenuItem"
        Me.NewEmailToThisContactToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.NewEmailToThisContactToolStripMenuItem.Text = "New email to this address..."
        '
        'AddToAddressBookToolStripMenuItem
        '
        Me.AddToAddressBookToolStripMenuItem.Image = CType(resources.GetObject("AddToAddressBookToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToAddressBookToolStripMenuItem.Name = "AddToAddressBookToolStripMenuItem"
        Me.AddToAddressBookToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.AddToAddressBookToolStripMenuItem.Text = "&Add to address book"
        '
        'MarkReadToolStripMenuItem
        '
        Me.MarkReadToolStripMenuItem.Enabled = False
        Me.MarkReadToolStripMenuItem.Name = "MarkReadToolStripMenuItem"
        Me.MarkReadToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.MarkReadToolStripMenuItem.Text = "Mark &read"
        '
        'CopyemailAddressToolStripMenuItem
        '
        Me.CopyemailAddressToolStripMenuItem.Name = "CopyemailAddressToolStripMenuItem"
        Me.CopyemailAddressToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.CopyemailAddressToolStripMenuItem.Text = "Copy &email address"
        '
        'LaunchSeparator
        '
        Me.LaunchSeparator.Name = "LaunchSeparator"
        Me.LaunchSeparator.Size = New System.Drawing.Size(227, 6)
        '
        'NewMessageProcessingruleToolStripMenuItem
        '
        Me.NewMessageProcessingruleToolStripMenuItem.Name = "NewMessageProcessingruleToolStripMenuItem"
        Me.NewMessageProcessingruleToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.NewMessageProcessingruleToolStripMenuItem.Text = "New message processing &rule"
        '
        'LaunchURLToolStripMenuItem
        '
        Me.LaunchURLToolStripMenuItem.Name = "LaunchURLToolStripMenuItem"
        Me.LaunchURLToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.LaunchURLToolStripMenuItem.Text = "&Launch "
        '
        'recipientImageList
        '
        Me.recipientImageList.ImageStream = CType(resources.GetObject("recipientImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.recipientImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.recipientImageList.Images.SetKeyName(0, "Secured message.bmp")
        Me.recipientImageList.Images.SetKeyName(1, "Email.bmp")
        '
        'olvAttachments
        '
        Me.olvAttachments.AllColumns.Add(Me.AttachmentNameColumn)
        Me.olvAttachments.AllColumns.Add(Me.OlvColumnFileSize)
        Me.olvAttachments.AllowColumnReorder = True
        Me.olvAttachments.AllowDrop = True
        Me.olvAttachments.CellEditUseWholeCell = False
        Me.olvAttachments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.AttachmentNameColumn, Me.OlvColumnFileSize})
        Me.olvAttachments.ContextMenuStrip = Me.ctxmnuAttachments
        Me.olvAttachments.Cursor = System.Windows.Forms.Cursors.Default
        Me.olvAttachments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvAttachments.FullRowSelect = True
        Me.olvAttachments.GridLines = True
        Me.olvAttachments.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvAttachments.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvAttachments.LabelWrap = False
        Me.olvAttachments.Location = New System.Drawing.Point(0, 0)
        Me.olvAttachments.Name = "olvAttachments"
        Me.olvAttachments.SelectColumnsMenuStaysOpen = False
        Me.olvAttachments.ShowCommandMenuOnRightClick = True
        Me.olvAttachments.ShowGroups = False
        Me.olvAttachments.ShowItemToolTips = True
        Me.olvAttachments.Size = New System.Drawing.Size(371, 54)
        Me.olvAttachments.SmallImageList = Me.attachmentImageList
        Me.olvAttachments.TabIndex = 19
        Me.olvAttachments.UseCompatibleStateImageBehavior = False
        Me.olvAttachments.UseFiltering = True
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
        Me.ctxmnuAttachments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyFileToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.SaveallToolStripMenuItem, Me.ToolStripSeparator2, Me.OpenAttachmentToolStripMenuItem, Me.OpenFileLocationToolStripMenuItem})
        Me.ctxmnuAttachments.Name = "ctxmnuAttachments"
        Me.ctxmnuAttachments.Size = New System.Drawing.Size(181, 120)
        '
        'CopyFileToolStripMenuItem
        '
        Me.CopyFileToolStripMenuItem.Name = "CopyFileToolStripMenuItem"
        Me.CopyFileToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CopyFileToolStripMenuItem.Text = "&Copy file(s)"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveAsToolStripMenuItem.Text = "&Save as..."
        '
        'SaveallToolStripMenuItem
        '
        Me.SaveallToolStripMenuItem.Name = "SaveallToolStripMenuItem"
        Me.SaveallToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveallToolStripMenuItem.Text = "Save &all..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(177, 6)
        '
        'OpenAttachmentToolStripMenuItem
        '
        Me.OpenAttachmentToolStripMenuItem.Name = "OpenAttachmentToolStripMenuItem"
        Me.OpenAttachmentToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenAttachmentToolStripMenuItem.Text = "&Open attachment(s)"
        '
        'OpenFileLocationToolStripMenuItem
        '
        Me.OpenFileLocationToolStripMenuItem.Name = "OpenFileLocationToolStripMenuItem"
        Me.OpenFileLocationToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenFileLocationToolStripMenuItem.Text = "Open file &location"
        '
        'attachmentImageList
        '
        Me.attachmentImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.attachmentImageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.attachmentImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'NotesBodySplitContainer
        '
        Me.NotesBodySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NotesBodySplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.NotesBodySplitContainer.Name = "NotesBodySplitContainer"
        '
        'NotesBodySplitContainer.Panel1
        '
        Me.NotesBodySplitContainer.Panel1.Controls.Add(Me.txtNotes)
        Me.NotesBodySplitContainer.Panel1.Controls.Add(Me.ToolStrip2)
        Me.NotesBodySplitContainer.Panel1Collapsed = True
        '
        'NotesBodySplitContainer.Panel2
        '
        Me.NotesBodySplitContainer.Panel2.Controls.Add(Me.SplitContainerPadding)
        Me.NotesBodySplitContainer.Size = New System.Drawing.Size(1076, 615)
        Me.NotesBodySplitContainer.SplitterDistance = 250
        Me.NotesBodySplitContainer.TabIndex = 5
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNotes.ContextMenuStrip = Me.ctxReadText
        Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNotes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotes.Location = New System.Drawing.Point(0, 25)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(250, 75)
        Me.txtNotes.TabIndex = 19
        Me.txtNotes.Text = ""
        '
        'ctxReadText
        '
        Me.ctxReadText.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxReadText.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem})
        Me.ctxReadText.Name = "ctxmnuAttachments"
        Me.ctxReadText.Size = New System.Drawing.Size(103, 70)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.CutToolStripMenuItem.Text = "Cu&t"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.CopyToolStripMenuItem.Text = "&Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.PasteToolStripMenuItem.Text = "&Paste"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NotesEditToolStripButton, Me.NotesSaveToolStripButton, Me.ToolStripSeparator5, Me.DeleteNotesToolStripButton, Me.ToolStripLabel2, Me.ToolStripLabel1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(250, 25)
        Me.ToolStrip2.TabIndex = 18
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'NotesEditToolStripButton
        '
        Me.NotesEditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NotesEditToolStripButton.Image = CType(resources.GetObject("NotesEditToolStripButton.Image"), System.Drawing.Image)
        Me.NotesEditToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.NotesEditToolStripButton.Name = "NotesEditToolStripButton"
        Me.NotesEditToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NotesEditToolStripButton.Text = "NotesEditToolStripButton"
        Me.NotesEditToolStripButton.ToolTipText = "Edit notes"
        '
        'NotesSaveToolStripButton
        '
        Me.NotesSaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NotesSaveToolStripButton.Enabled = False
        Me.NotesSaveToolStripButton.Image = CType(resources.GetObject("NotesSaveToolStripButton.Image"), System.Drawing.Image)
        Me.NotesSaveToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.NotesSaveToolStripButton.Name = "NotesSaveToolStripButton"
        Me.NotesSaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NotesSaveToolStripButton.Text = "NotesSaveToolStripButton"
        Me.NotesSaveToolStripButton.ToolTipText = "Save changes to notes"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'DeleteNotesToolStripButton
        '
        Me.DeleteNotesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DeleteNotesToolStripButton.Image = CType(resources.GetObject("DeleteNotesToolStripButton.Image"), System.Drawing.Image)
        Me.DeleteNotesToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.DeleteNotesToolStripButton.Name = "DeleteNotesToolStripButton"
        Me.DeleteNotesToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.DeleteNotesToolStripButton.Text = "DeleteNodtesToolStripButton"
        Me.DeleteNotesToolStripButton.ToolTipText = "Delete all notes in this message"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel2.Text = "            "
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripLabel1.Text = "Notes"
        '
        'SplitContainerPadding
        '
        Me.SplitContainerPadding.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerPadding.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerPadding.IsSplitterFixed = True
        Me.SplitContainerPadding.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerPadding.Name = "SplitContainerPadding"
        Me.SplitContainerPadding.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerPadding.Panel1
        '
        Me.SplitContainerPadding.Panel1.Controls.Add(Me.SplitContainerReaderReplyBox)
        Me.SplitContainerPadding.Panel1.Controls.Add(Me.pnlFind)
        '
        'SplitContainerPadding.Panel2
        '
        Me.SplitContainerPadding.Panel2.Enabled = False
        Me.SplitContainerPadding.Panel2Collapsed = True
        Me.SplitContainerPadding.Size = New System.Drawing.Size(1076, 615)
        Me.SplitContainerPadding.SplitterDistance = 396
        Me.SplitContainerPadding.TabIndex = 6
        '
        'SplitContainerReaderReplyBox
        '
        Me.SplitContainerReaderReplyBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerReaderReplyBox.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerReaderReplyBox.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerReaderReplyBox.Name = "SplitContainerReaderReplyBox"
        '
        'SplitContainerReaderReplyBox.Panel1
        '
        Me.SplitContainerReaderReplyBox.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'SplitContainerReaderReplyBox.Panel2
        '
        Me.SplitContainerReaderReplyBox.Panel2.Controls.Add(Me.olvReplyModes)
        Me.SplitContainerReaderReplyBox.Size = New System.Drawing.Size(1076, 589)
        Me.SplitContainerReaderReplyBox.SplitterDistance = 936
        Me.SplitContainerReaderReplyBox.TabIndex = 14
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.WebBrowser1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rtbBody)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlBlockedNotice)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlRSSLink)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlTM2TM)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlAudioPlayer)
        Me.SplitContainer1.Panel1.Controls.Add(Me.WebBrowser2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlBrowserZoom)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(936, 589)
        Me.SplitContainer1.SplitterDistance = 370
        Me.SplitContainer1.TabIndex = 5
        '
        'WebBrowser1
        '
        Me.WebBrowser1.AllowWebBrowserDrop = False
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 162)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.Size = New System.Drawing.Size(936, 208)
        Me.WebBrowser1.TabIndex = 3
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False
        '
        'rtbBody
        '
        Me.rtbBody.BackColor = System.Drawing.Color.White
        Me.rtbBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbBody.CausesValidation = False
        Me.rtbBody.ContextMenuStrip = Me.ctxReadText
        Me.rtbBody.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbBody.HideSelection = False
        Me.rtbBody.Location = New System.Drawing.Point(96, 134)
        Me.rtbBody.Name = "rtbBody"
        Me.rtbBody.ReadOnly = True
        Me.rtbBody.ShowSelectionMargin = True
        Me.rtbBody.Size = New System.Drawing.Size(356, 85)
        Me.rtbBody.TabIndex = 6
        Me.rtbBody.Text = ""
        Me.rtbBody.Visible = False
        '
        'pnlBlockedNotice
        '
        Me.pnlBlockedNotice.AutoSize = True
        Me.pnlBlockedNotice.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlBlockedNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBlockedNotice.Controls.Add(Me.llblBlockedScriptsInfo)
        Me.pnlBlockedNotice.Controls.Add(Me.picCloseBlockPanel)
        Me.pnlBlockedNotice.Controls.Add(Me.chkDoNotShowBlockPanel)
        Me.pnlBlockedNotice.Controls.Add(Me.lblBlockText)
        Me.pnlBlockedNotice.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBlockedNotice.Location = New System.Drawing.Point(0, 120)
        Me.pnlBlockedNotice.Name = "pnlBlockedNotice"
        Me.pnlBlockedNotice.Size = New System.Drawing.Size(936, 42)
        Me.pnlBlockedNotice.TabIndex = 13
        Me.pnlBlockedNotice.Visible = False
        '
        'llblBlockedScriptsInfo
        '
        Me.llblBlockedScriptsInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llblBlockedScriptsInfo.AutoSize = True
        Me.llblBlockedScriptsInfo.Location = New System.Drawing.Point(810, 3)
        Me.llblBlockedScriptsInfo.Name = "llblBlockedScriptsInfo"
        Me.llblBlockedScriptsInfo.Size = New System.Drawing.Size(85, 13)
        Me.llblBlockedScriptsInfo.TabIndex = 20
        Me.llblBlockedScriptsInfo.TabStop = True
        Me.llblBlockedScriptsInfo.Text = "More information"
        '
        'picCloseBlockPanel
        '
        Me.picCloseBlockPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCloseBlockPanel.Image = Global.TrulyMail.My.Resources.Resources.simpleX_16
        Me.picCloseBlockPanel.Location = New System.Drawing.Point(920, 2)
        Me.picCloseBlockPanel.Name = "picCloseBlockPanel"
        Me.picCloseBlockPanel.Size = New System.Drawing.Size(12, 12)
        Me.picCloseBlockPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCloseBlockPanel.TabIndex = 18
        Me.picCloseBlockPanel.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picCloseBlockPanel, "Click to close")
        '
        'chkDoNotShowBlockPanel
        '
        Me.chkDoNotShowBlockPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDoNotShowBlockPanel.AutoSize = True
        Me.chkDoNotShowBlockPanel.Location = New System.Drawing.Point(774, 20)
        Me.chkDoNotShowBlockPanel.Name = "chkDoNotShowBlockPanel"
        Me.chkDoNotShowBlockPanel.Size = New System.Drawing.Size(158, 17)
        Me.chkDoNotShowBlockPanel.TabIndex = 19
        Me.chkDoNotShowBlockPanel.Text = "Do not show this area again"
        Me.chkDoNotShowBlockPanel.UseVisualStyleBackColor = True
        '
        'lblBlockText
        '
        Me.lblBlockText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBlockText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlockText.Location = New System.Drawing.Point(2, 2)
        Me.lblBlockText.Name = "lblBlockText"
        Me.lblBlockText.Size = New System.Drawing.Size(758, 35)
        Me.lblBlockText.TabIndex = 17
        Me.lblBlockText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlRSSLink
        '
        Me.pnlRSSLink.AutoSize = True
        Me.pnlRSSLink.Controls.Add(Me.llblRSSLink)
        Me.pnlRSSLink.Controls.Add(Me.Label11)
        Me.pnlRSSLink.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRSSLink.Location = New System.Drawing.Point(0, 99)
        Me.pnlRSSLink.Name = "pnlRSSLink"
        Me.pnlRSSLink.Size = New System.Drawing.Size(936, 21)
        Me.pnlRSSLink.TabIndex = 12
        Me.pnlRSSLink.Visible = False
        '
        'llblRSSLink
        '
        Me.llblRSSLink.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llblRSSLink.AutoEllipsis = True
        Me.llblRSSLink.ContextMenuStrip = Me.ctxmnuRSSLink
        Me.llblRSSLink.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblRSSLink.Location = New System.Drawing.Point(45, 2)
        Me.llblRSSLink.Name = "llblRSSLink"
        Me.llblRSSLink.Size = New System.Drawing.Size(889, 19)
        Me.llblRSSLink.TabIndex = 16
        '
        'ctxmnuRSSLink
        '
        Me.ctxmnuRSSLink.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuRSSLink.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyLinkAddressToolStripMenuItem})
        Me.ctxmnuRSSLink.Name = "ContextMenuStrip1"
        Me.ctxmnuRSSLink.Size = New System.Drawing.Size(168, 26)
        '
        'CopyLinkAddressToolStripMenuItem
        '
        Me.CopyLinkAddressToolStripMenuItem.Name = "CopyLinkAddressToolStripMenuItem"
        Me.CopyLinkAddressToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.CopyLinkAddressToolStripMenuItem.Text = "&Copy link address"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 2)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 16)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Link:"
        '
        'pnlTM2TM
        '
        Me.pnlTM2TM.AutoSize = True
        Me.pnlTM2TM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlTM2TM.Controls.Add(Me.txtDecryptionPassword)
        Me.pnlTM2TM.Controls.Add(Me.btnDecrypt)
        Me.pnlTM2TM.Controls.Add(Me.Label9)
        Me.pnlTM2TM.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTM2TM.Location = New System.Drawing.Point(0, 74)
        Me.pnlTM2TM.Name = "pnlTM2TM"
        Me.pnlTM2TM.Size = New System.Drawing.Size(936, 25)
        Me.pnlTM2TM.TabIndex = 11
        Me.pnlTM2TM.Visible = False
        '
        'txtDecryptionPassword
        '
        Me.txtDecryptionPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDecryptionPassword.Location = New System.Drawing.Point(71, 3)
        Me.txtDecryptionPassword.Name = "txtDecryptionPassword"
        Me.txtDecryptionPassword.Size = New System.Drawing.Size(175, 20)
        Me.txtDecryptionPassword.TabIndex = 4
        '
        'btnDecrypt
        '
        Me.btnDecrypt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDecrypt.BackColor = System.Drawing.SystemColors.Control
        Me.btnDecrypt.Location = New System.Drawing.Point(259, 0)
        Me.btnDecrypt.Name = "btnDecrypt"
        Me.btnDecrypt.Size = New System.Drawing.Size(105, 25)
        Me.btnDecrypt.TabIndex = 10
        Me.btnDecrypt.Text = "&Decrypt Message"
        Me.btnDecrypt.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 16)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Password:"
        '
        'pnlAudioPlayer
        '
        Me.pnlAudioPlayer.Controls.Add(Me.AudioPlayer1)
        Me.pnlAudioPlayer.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAudioPlayer.Location = New System.Drawing.Point(0, 30)
        Me.pnlAudioPlayer.Name = "pnlAudioPlayer"
        Me.pnlAudioPlayer.Size = New System.Drawing.Size(936, 44)
        Me.pnlAudioPlayer.TabIndex = 10
        Me.pnlAudioPlayer.Visible = False
        '
        'AudioPlayer1
        '
        Me.AudioPlayer1.CurrentLength = CType(0, Long)
        Me.AudioPlayer1.CurrentPosition = CType(0, Long)
        Me.AudioPlayer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AudioPlayer1.Location = New System.Drawing.Point(0, 0)
        Me.AudioPlayer1.Mute = False
        Me.AudioPlayer1.Name = "AudioPlayer1"
        Me.AudioPlayer1.Size = New System.Drawing.Size(936, 44)
        Me.AudioPlayer1.Status = TrulyMail.AudioPlayer.PlayerStatus.NoMedia
        Me.AudioPlayer1.TabIndex = 0
        Me.AudioPlayer1.Volume = 5
        '
        'WebBrowser2
        '
        Me.WebBrowser2.AllowWebBrowserDrop = False
        Me.WebBrowser2.Location = New System.Drawing.Point(-88, -59)
        Me.WebBrowser2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser2.Name = "WebBrowser2"
        Me.WebBrowser2.Size = New System.Drawing.Size(82, 151)
        Me.WebBrowser2.TabIndex = 4
        Me.WebBrowser2.Visible = False
        Me.WebBrowser2.WebBrowserShortcutsEnabled = False
        '
        'pnlBrowserZoom
        '
        Me.pnlBrowserZoom.Controls.Add(Me.tbZoom)
        Me.pnlBrowserZoom.Controls.Add(Me.lblZoomValue)
        Me.pnlBrowserZoom.Controls.Add(Me.lblZoom)
        Me.pnlBrowserZoom.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBrowserZoom.Location = New System.Drawing.Point(0, 0)
        Me.pnlBrowserZoom.Name = "pnlBrowserZoom"
        Me.pnlBrowserZoom.Size = New System.Drawing.Size(936, 30)
        Me.pnlBrowserZoom.TabIndex = 8
        '
        'tbZoom
        '
        Me.tbZoom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbZoom.AutoSize = False
        Me.tbZoom.LargeChange = 1
        Me.tbZoom.Location = New System.Drawing.Point(40, 2)
        Me.tbZoom.Maximum = 11
        Me.tbZoom.Minimum = 1
        Me.tbZoom.Name = "tbZoom"
        Me.tbZoom.Size = New System.Drawing.Size(889, 25)
        Me.tbZoom.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.tbZoom, "Make the text display larger or smaller")
        Me.tbZoom.Value = 3
        '
        'lblZoomValue
        '
        Me.lblZoomValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblZoomValue.AutoSize = True
        Me.lblZoomValue.Location = New System.Drawing.Point(2, 16)
        Me.lblZoomValue.Name = "lblZoomValue"
        Me.lblZoomValue.Size = New System.Drawing.Size(33, 13)
        Me.lblZoomValue.TabIndex = 10
        Me.lblZoomValue.Text = "100%"
        '
        'lblZoom
        '
        Me.lblZoom.AutoSize = True
        Me.lblZoom.Location = New System.Drawing.Point(2, 2)
        Me.lblZoom.Name = "lblZoom"
        Me.lblZoom.Size = New System.Drawing.Size(37, 13)
        Me.lblZoom.TabIndex = 8
        Me.lblZoom.Text = "Zoom:"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.chkDoNotShowProcessReceiptPanel)
        Me.Panel1.Controls.Add(Me.pbCloseReceiptPanel)
        Me.Panel1.Controls.Add(Me.pbFindMessagesForReceipts)
        Me.Panel1.Controls.Add(Me.pbReturnReceiptInfo)
        Me.Panel1.Controls.Add(Me.lvMessages)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(936, 215)
        Me.Panel1.TabIndex = 22
        '
        'chkDoNotShowProcessReceiptPanel
        '
        Me.chkDoNotShowProcessReceiptPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDoNotShowProcessReceiptPanel.AutoSize = True
        Me.chkDoNotShowProcessReceiptPanel.Location = New System.Drawing.Point(805, 21)
        Me.chkDoNotShowProcessReceiptPanel.Name = "chkDoNotShowProcessReceiptPanel"
        Me.chkDoNotShowProcessReceiptPanel.Size = New System.Drawing.Size(134, 20)
        Me.chkDoNotShowProcessReceiptPanel.TabIndex = 20
        Me.chkDoNotShowProcessReceiptPanel.Text = "Do not show again"
        Me.chkDoNotShowProcessReceiptPanel.UseVisualStyleBackColor = True
        '
        'pbCloseReceiptPanel
        '
        Me.pbCloseReceiptPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbCloseReceiptPanel.Image = Global.TrulyMail.My.Resources.Resources.simpleX_16
        Me.pbCloseReceiptPanel.Location = New System.Drawing.Point(921, 3)
        Me.pbCloseReceiptPanel.Name = "pbCloseReceiptPanel"
        Me.pbCloseReceiptPanel.Size = New System.Drawing.Size(12, 12)
        Me.pbCloseReceiptPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbCloseReceiptPanel.TabIndex = 19
        Me.pbCloseReceiptPanel.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbCloseReceiptPanel, "Click to close")
        '
        'pbFindMessagesForReceipts
        '
        Me.pbFindMessagesForReceipts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbFindMessagesForReceipts.Image = Global.TrulyMail.My.Resources.Resources.searchmessage_32
        Me.pbFindMessagesForReceipts.Location = New System.Drawing.Point(762, 3)
        Me.pbFindMessagesForReceipts.Name = "pbFindMessagesForReceipts"
        Me.pbFindMessagesForReceipts.Size = New System.Drawing.Size(36, 36)
        Me.pbFindMessagesForReceipts.TabIndex = 14
        Me.pbFindMessagesForReceipts.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbFindMessagesForReceipts, "Click to find original message")
        '
        'pbReturnReceiptInfo
        '
        Me.pbReturnReceiptInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbReturnReceiptInfo.Image = Global.TrulyMail.My.Resources.Resources.info_32
        Me.pbReturnReceiptInfo.Location = New System.Drawing.Point(721, 3)
        Me.pbReturnReceiptInfo.Name = "pbReturnReceiptInfo"
        Me.pbReturnReceiptInfo.Size = New System.Drawing.Size(36, 36)
        Me.pbReturnReceiptInfo.TabIndex = 13
        Me.pbReturnReceiptInfo.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbReturnReceiptInfo, "Click for more information about return receipt processing")
        '
        'lvMessages
        '
        Me.lvMessages.AllColumns.Add(Me.OlvColumnSubject)
        Me.lvMessages.AllColumns.Add(Me.OlvColumnMessageAttachments)
        Me.lvMessages.AllColumns.Add(Me.OlvColumnRecipients)
        Me.lvMessages.AllColumns.Add(Me.OlvColumnMessageDate)
        Me.lvMessages.AllColumns.Add(Me.OlvColumnSize)
        Me.lvMessages.AllColumns.Add(Me.OlvColumnReceived)
        Me.lvMessages.AllColumns.Add(Me.OlvColumnViewed)
        Me.lvMessages.AllowColumnReorder = True
        Me.lvMessages.AllowDrop = True
        Me.lvMessages.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lvMessages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvMessages.CellEditUseWholeCell = False
        Me.lvMessages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumnSubject, Me.OlvColumnMessageAttachments, Me.OlvColumnRecipients, Me.OlvColumnMessageDate, Me.OlvColumnSize, Me.OlvColumnReceived, Me.OlvColumnViewed})
        Me.lvMessages.ContextMenuStrip = Me.ctxmnuMatchingMessages
        Me.lvMessages.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvMessages.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvMessages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvMessages.FullRowSelect = True
        Me.lvMessages.HideSelection = False
        Me.lvMessages.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.lvMessages.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.lvMessages.LabelWrap = False
        Me.lvMessages.Location = New System.Drawing.Point(1, 41)
        Me.lvMessages.Name = "lvMessages"
        Me.lvMessages.SelectColumnsMenuStaysOpen = False
        Me.lvMessages.SelectColumnsOnRightClick = False
        Me.lvMessages.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.lvMessages.ShowGroups = False
        Me.lvMessages.ShowImagesOnSubItems = True
        Me.lvMessages.Size = New System.Drawing.Size(935, 109)
        Me.lvMessages.SmallImageList = Me.ImglstMessageStatus
        Me.lvMessages.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.lvMessages.TabIndex = 3
        Me.lvMessages.UseCompatibleStateImageBehavior = False
        Me.lvMessages.View = System.Windows.Forms.View.Details
        Me.lvMessages.Visible = False
        '
        'OlvColumnSubject
        '
        Me.OlvColumnSubject.AspectName = "Subject"
        Me.OlvColumnSubject.Text = "Subject"
        '
        'OlvColumnMessageAttachments
        '
        Me.OlvColumnMessageAttachments.AspectName = "Attachments.Count"
        Me.OlvColumnMessageAttachments.HeaderFont = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.OlvColumnMessageAttachments.HeaderFormatStyle = Me.HeaderFormatStyleWingDings
        Me.OlvColumnMessageAttachments.HeaderImageKey = "attach.png"
        Me.OlvColumnMessageAttachments.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnMessageAttachments.IsEditable = False
        Me.OlvColumnMessageAttachments.ShowTextInHeader = False
        Me.OlvColumnMessageAttachments.Text = "A"
        Me.OlvColumnMessageAttachments.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnMessageAttachments.ToolTipText = "Number of attachments"
        Me.OlvColumnMessageAttachments.Width = 100
        '
        'HeaderFormatStyleWingDings
        '
        HeaderStateStyle1.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.HeaderFormatStyleWingDings.Hot = HeaderStateStyle1
        HeaderStateStyle2.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.HeaderFormatStyleWingDings.Normal = HeaderStateStyle2
        HeaderStateStyle3.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.HeaderFormatStyleWingDings.Pressed = HeaderStateStyle3
        '
        'OlvColumnRecipients
        '
        Me.OlvColumnRecipients.AspectName = "OtherParties"
        Me.OlvColumnRecipients.Text = "Recipients"
        '
        'OlvColumnMessageDate
        '
        Me.OlvColumnMessageDate.AspectName = "MessageDateSent"
        Me.OlvColumnMessageDate.Text = "Date"
        '
        'OlvColumnSize
        '
        Me.OlvColumnSize.AspectName = "Size"
        Me.OlvColumnSize.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnSize.Text = "Size"
        Me.OlvColumnSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OlvColumnReceived
        '
        Me.OlvColumnReceived.AspectName = "Received"
        Me.OlvColumnReceived.AspectToStringFormat = "{0:P0}"
        Me.OlvColumnReceived.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnReceived.Text = "Rec"
        Me.OlvColumnReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OlvColumnViewed
        '
        Me.OlvColumnViewed.AspectName = "Viewed"
        Me.OlvColumnViewed.AspectToStringFormat = "{0:P0}"
        Me.OlvColumnViewed.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnViewed.Text = "View"
        Me.OlvColumnViewed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ctxmnuMatchingMessages
        '
        Me.ctxmnuMatchingMessages.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuMatchingMessages.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenMessageToolStripMenuItem, Me.MarkMessageReadAndDeleteThisReceiptToolStripMenuItem})
        Me.ctxmnuMatchingMessages.Name = "ContextMenuStrip1"
        Me.ctxmnuMatchingMessages.Size = New System.Drawing.Size(296, 48)
        '
        'OpenMessageToolStripMenuItem
        '
        Me.OpenMessageToolStripMenuItem.Name = "OpenMessageToolStripMenuItem"
        Me.OpenMessageToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.OpenMessageToolStripMenuItem.Text = "&Open message"
        '
        'MarkMessageReadAndDeleteThisReceiptToolStripMenuItem
        '
        Me.MarkMessageReadAndDeleteThisReceiptToolStripMenuItem.Name = "MarkMessageReadAndDeleteThisReceiptToolStripMenuItem"
        Me.MarkMessageReadAndDeleteThisReceiptToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.MarkMessageReadAndDeleteThisReceiptToolStripMenuItem.Text = "&Mark message read and delete this receipt"
        '
        'ImglstMessageStatus
        '
        Me.ImglstMessageStatus.ImageStream = CType(resources.GetObject("ImglstMessageStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImglstMessageStatus.TransparentColor = System.Drawing.Color.Transparent
        Me.ImglstMessageStatus.Images.SetKeyName(0, "Reply_2_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(1, "ForwardReply_2_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(2, "Forward_2_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(3, "email_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(4, "Securedmessage_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(5, "MixedTransport_16.bmp")
        Me.ImglstMessageStatus.Images.SetKeyName(6, "noteTrans_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(7, "Transparent_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(8, "rss_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(9, "network_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(10, "attach.png")
        Me.ImglstMessageStatus.Images.SetKeyName(11, "spam scales.png")
        Me.ImglstMessageStatus.Images.SetKeyName(12, "redemail_16.png")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Return Receipts"
        '
        'olvReplyModes
        '
        Me.olvReplyModes.AllColumns.Add(Me.OlvColumnReplyModeText)
        Me.olvReplyModes.CellEditUseWholeCell = False
        Me.olvReplyModes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumnReplyModeText})
        Me.olvReplyModes.Cursor = System.Windows.Forms.Cursors.Default
        Me.olvReplyModes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvReplyModes.HasCollapsibleGroups = False
        Me.olvReplyModes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.olvReplyModes.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvReplyModes.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvReplyModes.IsSearchOnSortColumn = False
        Me.olvReplyModes.LargeImageList = Me.replyModeImageList
        Me.olvReplyModes.Location = New System.Drawing.Point(0, 0)
        Me.olvReplyModes.MultiSelect = False
        Me.olvReplyModes.Name = "olvReplyModes"
        Me.olvReplyModes.SelectAllOnControlA = False
        Me.olvReplyModes.SelectColumnsMenuStaysOpen = False
        Me.olvReplyModes.SelectColumnsOnRightClick = False
        Me.olvReplyModes.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvReplyModes.ShowFilterMenuOnRightClick = False
        Me.olvReplyModes.ShowGroups = False
        Me.olvReplyModes.ShowHeaderInAllViews = False
        Me.olvReplyModes.Size = New System.Drawing.Size(136, 589)
        Me.olvReplyModes.SmallImageList = Me.replyModeImageList
        Me.olvReplyModes.TabIndex = 20
        Me.olvReplyModes.UseCompatibleStateImageBehavior = False
        Me.olvReplyModes.View = System.Windows.Forms.View.Details
        '
        'OlvColumnReplyModeText
        '
        Me.OlvColumnReplyModeText.AspectName = "Text"
        Me.OlvColumnReplyModeText.FillsFreeSpace = True
        Me.OlvColumnReplyModeText.Hideable = False
        Me.OlvColumnReplyModeText.ImageAspectName = "ImageIndex"
        Me.OlvColumnReplyModeText.IsEditable = False
        Me.OlvColumnReplyModeText.ShowTextInHeader = False
        Me.OlvColumnReplyModeText.Text = "Action"
        Me.OlvColumnReplyModeText.Width = 118
        '
        'replyModeImageList
        '
        Me.replyModeImageList.ImageStream = CType(resources.GetObject("replyModeImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.replyModeImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.replyModeImageList.Images.SetKeyName(0, "reply_WithBody_32.png")
        Me.replyModeImageList.Images.SetKeyName(1, "reply_NoBody_32.png")
        Me.replyModeImageList.Images.SetKeyName(2, "reply_all_WithBody_32.png")
        Me.replyModeImageList.Images.SetKeyName(3, "reply_all_NoBody_32.png")
        Me.replyModeImageList.Images.SetKeyName(4, "Forward_WithAttachments_32.png")
        Me.replyModeImageList.Images.SetKeyName(5, "Forward_NoAttachments_32.png")
        Me.replyModeImageList.Images.SetKeyName(6, "FollowUp_32.png")
        Me.replyModeImageList.Images.SetKeyName(7, "Resend_32.png")
        '
        'pnlFind
        '
        Me.pnlFind.AutoSize = True
        Me.pnlFind.Controls.Add(Me.btnFindNext)
        Me.pnlFind.Controls.Add(Me.txtFindText)
        Me.pnlFind.Controls.Add(Me.Label7)
        Me.pnlFind.Controls.Add(Me.picCloseFindPanel)
        Me.pnlFind.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFind.Location = New System.Drawing.Point(0, 589)
        Me.pnlFind.Name = "pnlFind"
        Me.pnlFind.Size = New System.Drawing.Size(1076, 26)
        Me.pnlFind.TabIndex = 13
        Me.pnlFind.Visible = False
        '
        'btnFindNext
        '
        Me.btnFindNext.BackColor = System.Drawing.SystemColors.Control
        Me.btnFindNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindNext.Location = New System.Drawing.Point(246, 1)
        Me.btnFindNext.Name = "btnFindNext"
        Me.btnFindNext.Size = New System.Drawing.Size(136, 22)
        Me.btnFindNext.TabIndex = 22
        Me.btnFindNext.Text = "&Find next"
        Me.btnFindNext.UseVisualStyleBackColor = False
        '
        'txtFindText
        '
        Me.txtFindText.Location = New System.Drawing.Point(62, 3)
        Me.txtFindText.Name = "txtFindText"
        Me.txtFindText.Size = New System.Drawing.Size(178, 20)
        Me.txtFindText.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(28, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 16)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Find:"
        '
        'picCloseFindPanel
        '
        Me.picCloseFindPanel.Image = Global.TrulyMail.My.Resources.Resources.close_cold_16
        Me.picCloseFindPanel.Location = New System.Drawing.Point(1, 4)
        Me.picCloseFindPanel.Name = "picCloseFindPanel"
        Me.picCloseFindPanel.Size = New System.Drawing.Size(16, 16)
        Me.picCloseFindPanel.TabIndex = 20
        Me.picCloseFindPanel.TabStop = False
        '
        'pnlHeaderAreaCompact
        '
        Me.pnlHeaderAreaCompact.AutoSize = True
        Me.pnlHeaderAreaCompact.Controls.Add(Me.Label5)
        Me.pnlHeaderAreaCompact.Controls.Add(Me.txtSubject2)
        Me.pnlHeaderAreaCompact.Controls.Add(Me.lblSent2)
        Me.pnlHeaderAreaCompact.Controls.Add(Me.picHeaderAreaExpand)
        Me.pnlHeaderAreaCompact.Controls.Add(Me.llblFrom2)
        Me.pnlHeaderAreaCompact.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderAreaCompact.Location = New System.Drawing.Point(0, 42)
        Me.pnlHeaderAreaCompact.Name = "pnlHeaderAreaCompact"
        Me.pnlHeaderAreaCompact.Size = New System.Drawing.Size(1076, 23)
        Me.pnlHeaderAreaCompact.TabIndex = 21
        Me.pnlHeaderAreaCompact.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(669, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "From:"
        '
        'txtSubject2
        '
        Me.txtSubject2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSubject2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubject2.Location = New System.Drawing.Point(27, -1)
        Me.txtSubject2.Multiline = False
        Me.txtSubject2.Name = "txtSubject2"
        Me.txtSubject2.ReadOnly = True
        Me.txtSubject2.Size = New System.Drawing.Size(635, 21)
        Me.txtSubject2.TabIndex = 18
        Me.txtSubject2.Text = ""
        '
        'lblSent2
        '
        Me.lblSent2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSent2.AutoSize = True
        Me.lblSent2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSent2.Location = New System.Drawing.Point(934, 3)
        Me.lblSent2.Name = "lblSent2"
        Me.lblSent2.Size = New System.Drawing.Size(131, 16)
        Me.lblSent2.TabIndex = 3
        Me.lblSent2.Text = "2008-09-09 23:23 AM"
        '
        'picHeaderAreaExpand
        '
        Me.picHeaderAreaExpand.Image = Global.TrulyMail.My.Resources.Resources.plus_9
        Me.picHeaderAreaExpand.Location = New System.Drawing.Point(6, 3)
        Me.picHeaderAreaExpand.Name = "picHeaderAreaExpand"
        Me.picHeaderAreaExpand.Size = New System.Drawing.Size(16, 16)
        Me.picHeaderAreaExpand.TabIndex = 19
        Me.picHeaderAreaExpand.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picHeaderAreaExpand, "Switch to full header area")
        '
        'llblFrom2
        '
        Me.llblFrom2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.llblFrom2.AutoEllipsis = True
        Me.llblFrom2.ContextMenuStrip = Me.ctxmnuRecipients
        Me.llblFrom2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblFrom2.LinkArea = New System.Windows.Forms.LinkArea(0, 6)
        Me.llblFrom2.Location = New System.Drawing.Point(711, 1)
        Me.llblFrom2.Name = "llblFrom2"
        Me.llblFrom2.Size = New System.Drawing.Size(214, 19)
        Me.llblFrom2.TabIndex = 15
        Me.llblFrom2.TabStop = True
        Me.llblFrom2.Text = "sender"
        '
        'pnlHeaderAreaFull
        '
        Me.pnlHeaderAreaFull.AutoSize = True
        Me.pnlHeaderAreaFull.Controls.Add(Me.Label1)
        Me.pnlHeaderAreaFull.Controls.Add(Me.txtSubject)
        Me.pnlHeaderAreaFull.Controls.Add(Me.lblSent)
        Me.pnlHeaderAreaFull.Controls.Add(Me.llblReplyTo)
        Me.pnlHeaderAreaFull.Controls.Add(Me.picHeaderAreaCollapse)
        Me.pnlHeaderAreaFull.Controls.Add(Me.lblSentLabel)
        Me.pnlHeaderAreaFull.Controls.Add(Me.llblFrom)
        Me.pnlHeaderAreaFull.Controls.Add(Me.lblSizeLabel)
        Me.pnlHeaderAreaFull.Controls.Add(Me.Label3)
        Me.pnlHeaderAreaFull.Controls.Add(Me.lblMessageSize)
        Me.pnlHeaderAreaFull.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderAreaFull.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeaderAreaFull.Name = "pnlHeaderAreaFull"
        Me.pnlHeaderAreaFull.Size = New System.Drawing.Size(1076, 42)
        Me.pnlHeaderAreaFull.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From:"
        '
        'txtSubject
        '
        Me.txtSubject.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSubject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubject.Location = New System.Drawing.Point(68, 18)
        Me.txtSubject.Multiline = False
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.ReadOnly = True
        Me.txtSubject.Size = New System.Drawing.Size(456, 21)
        Me.txtSubject.TabIndex = 18
        Me.txtSubject.Text = ""
        '
        'lblSent
        '
        Me.lblSent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSent.AutoSize = True
        Me.lblSent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSent.Location = New System.Drawing.Point(936, 0)
        Me.lblSent.Name = "lblSent"
        Me.lblSent.Size = New System.Drawing.Size(131, 16)
        Me.lblSent.TabIndex = 3
        Me.lblSent.Text = "2008-09-09 23:23 AM"
        '
        'llblReplyTo
        '
        Me.llblReplyTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llblReplyTo.BackColor = System.Drawing.Color.Transparent
        Me.llblReplyTo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblReplyTo.LinkArea = New System.Windows.Forms.LinkArea(0, 7)
        Me.llblReplyTo.LinkColor = System.Drawing.Color.DarkMagenta
        Me.llblReplyTo.Location = New System.Drawing.Point(713, 1)
        Me.llblReplyTo.Name = "llblReplyTo"
        Me.llblReplyTo.Size = New System.Drawing.Size(54, 16)
        Me.llblReplyTo.TabIndex = 17
        Me.llblReplyTo.TabStop = True
        Me.llblReplyTo.Text = "ReplyTo"
        Me.llblReplyTo.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.llblReplyTo.Visible = False
        '
        'picHeaderAreaCollapse
        '
        Me.picHeaderAreaCollapse.Image = Global.TrulyMail.My.Resources.Resources.minus_9
        Me.picHeaderAreaCollapse.Location = New System.Drawing.Point(6, 3)
        Me.picHeaderAreaCollapse.Name = "picHeaderAreaCollapse"
        Me.picHeaderAreaCollapse.Size = New System.Drawing.Size(16, 16)
        Me.picHeaderAreaCollapse.TabIndex = 19
        Me.picHeaderAreaCollapse.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picHeaderAreaCollapse, "Switch to compact header area")
        '
        'lblSentLabel
        '
        Me.lblSentLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSentLabel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSentLabel.Location = New System.Drawing.Point(884, 0)
        Me.lblSentLabel.Name = "lblSentLabel"
        Me.lblSentLabel.Size = New System.Drawing.Size(58, 16)
        Me.lblSentLabel.TabIndex = 3
        Me.lblSentLabel.Text = "Sent:"
        Me.lblSentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'llblFrom
        '
        Me.llblFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llblFrom.AutoEllipsis = True
        Me.llblFrom.ContextMenuStrip = Me.ctxmnuRecipients
        Me.llblFrom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblFrom.LinkArea = New System.Windows.Forms.LinkArea(0, 6)
        Me.llblFrom.Location = New System.Drawing.Point(65, 0)
        Me.llblFrom.Name = "llblFrom"
        Me.llblFrom.Size = New System.Drawing.Size(668, 19)
        Me.llblFrom.TabIndex = 15
        Me.llblFrom.TabStop = True
        Me.llblFrom.Text = "sender"
        '
        'lblSizeLabel
        '
        Me.lblSizeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSizeLabel.AutoSize = True
        Me.lblSizeLabel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSizeLabel.Location = New System.Drawing.Point(968, 19)
        Me.lblSizeLabel.Name = "lblSizeLabel"
        Me.lblSizeLabel.Size = New System.Drawing.Size(38, 16)
        Me.lblSizeLabel.TabIndex = 10
        Me.lblSizeLabel.Text = "Size:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Subject:"
        '
        'lblMessageSize
        '
        Me.lblMessageSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessageSize.AutoSize = True
        Me.lblMessageSize.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessageSize.Location = New System.Drawing.Point(1010, 19)
        Me.lblMessageSize.Name = "lblMessageSize"
        Me.lblMessageSize.Size = New System.Drawing.Size(0, 16)
        Me.lblMessageSize.TabIndex = 11
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator1, Me.ToolStripButton3, Me.ToolStripLabel3, Me.ToolStripLabel4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 49)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1076, 25)
        Me.ToolStrip1.TabIndex = 27
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "NotesEditToolStripButton"
        Me.ToolStripButton1.ToolTipText = "Edit notes"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Enabled = False
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "NotesSaveToolStripButton"
        Me.ToolStripButton2.ToolTipText = "Save changes to notes"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "DeleteNodtesToolStripButton"
        Me.ToolStripButton3.ToolTipText = "Delete all notes in this message"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel3.Text = "            "
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripLabel4.Text = "Notes"
        '
        'tmrLoadMessage
        '
        '
        'ReadMessageControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlRemoteImages)
        Me.Name = "ReadMessageControl"
        Me.Size = New System.Drawing.Size(1076, 787)
        Me.pnlRemoteImages.ResumeLayout(False)
        Me.pnlRemoteImages.PerformLayout()
        CType(Me.pbNeverBlockRemoteImagesForSender, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbUnblockRemoteImages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbShowRemoteImageURLs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbRemoteImageInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainerRecipAttachments.Panel1.ResumeLayout(False)
        Me.SplitContainerRecipAttachments.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerRecipAttachments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerRecipAttachments.ResumeLayout(False)
        CType(Me.olvRecipients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmnuRecipients.ResumeLayout(False)
        CType(Me.olvAttachments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmnuAttachments.ResumeLayout(False)
        Me.NotesBodySplitContainer.Panel1.ResumeLayout(False)
        Me.NotesBodySplitContainer.Panel1.PerformLayout()
        Me.NotesBodySplitContainer.Panel2.ResumeLayout(False)
        CType(Me.NotesBodySplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NotesBodySplitContainer.ResumeLayout(False)
        Me.ctxReadText.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.SplitContainerPadding.Panel1.ResumeLayout(False)
        Me.SplitContainerPadding.Panel1.PerformLayout()
        CType(Me.SplitContainerPadding, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerPadding.ResumeLayout(False)
        Me.SplitContainerReaderReplyBox.Panel1.ResumeLayout(False)
        Me.SplitContainerReaderReplyBox.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerReaderReplyBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerReaderReplyBox.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlBlockedNotice.ResumeLayout(False)
        Me.pnlBlockedNotice.PerformLayout()
        CType(Me.picCloseBlockPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRSSLink.ResumeLayout(False)
        Me.pnlRSSLink.PerformLayout()
        Me.ctxmnuRSSLink.ResumeLayout(False)
        Me.pnlTM2TM.ResumeLayout(False)
        Me.pnlTM2TM.PerformLayout()
        Me.pnlAudioPlayer.ResumeLayout(False)
        Me.pnlBrowserZoom.ResumeLayout(False)
        Me.pnlBrowserZoom.PerformLayout()
        CType(Me.tbZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbCloseReceiptPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbFindMessagesForReceipts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbReturnReceiptInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lvMessages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmnuMatchingMessages.ResumeLayout(False)
        CType(Me.olvReplyModes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFind.ResumeLayout(False)
        Me.pnlFind.PerformLayout()
        CType(Me.picCloseFindPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeaderAreaCompact.ResumeLayout(False)
        Me.pnlHeaderAreaCompact.PerformLayout()
        CType(Me.picHeaderAreaExpand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeaderAreaFull.ResumeLayout(False)
        Me.pnlHeaderAreaFull.PerformLayout()
        CType(Me.picHeaderAreaCollapse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlRemoteImages As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents llblReplyTo As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainerRecipAttachments As System.Windows.Forms.SplitContainer
    Friend WithEvents olvRecipients As BrightIdeasSoftware.ObjectListView
    Friend WithEvents olvAttachments As BrightIdeasSoftware.ObjectListView
    Friend WithEvents NotesBodySplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lvMessages As BrightIdeasSoftware.ObjectListView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents WebBrowser2 As System.Windows.Forms.WebBrowser
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMessageSize As System.Windows.Forms.Label
    Friend WithEvents lblSent As System.Windows.Forms.Label
    Friend WithEvents lblSentLabel As System.Windows.Forms.Label
    Friend WithEvents lblSizeLabel As System.Windows.Forms.Label
    Friend WithEvents llblFrom As System.Windows.Forms.LinkLabel
    Friend WithEvents ctxmnuMatchingMessages As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxmnuAttachments As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ctxmnuRecipients As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents txtSubject As System.Windows.Forms.RichTextBox
    Friend WithEvents SplitContainerPadding As System.Windows.Forms.SplitContainer
    Friend WithEvents rtbBody As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlBrowserZoom As System.Windows.Forms.Panel
    Friend WithEvents lblZoom As System.Windows.Forms.Label
    Friend WithEvents tbZoom As System.Windows.Forms.TrackBar
    Friend WithEvents lblZoomValue As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlAudioPlayer As System.Windows.Forms.Panel
    Friend WithEvents AudioPlayer1 As TrulyMail.AudioPlayer
    Friend WithEvents picHeaderAreaCollapse As System.Windows.Forms.PictureBox
    Friend WithEvents pnlHeaderAreaFull As System.Windows.Forms.Panel
    Friend WithEvents pnlHeaderAreaCompact As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSubject2 As System.Windows.Forms.RichTextBox
    Friend WithEvents lblSent2 As System.Windows.Forms.Label
    Friend WithEvents picHeaderAreaExpand As System.Windows.Forms.PictureBox
    Friend WithEvents llblFrom2 As System.Windows.Forms.LinkLabel
    Friend WithEvents pnlFind As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents picCloseFindPanel As System.Windows.Forms.PictureBox
    Friend WithEvents txtFindText As System.Windows.Forms.TextBox
    Friend WithEvents btnFindNext As System.Windows.Forms.Button
    Friend WithEvents pnlTM2TM As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDecryptionPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnDecrypt As System.Windows.Forms.Button
    Friend WithEvents pnlRSSLink As System.Windows.Forms.Panel
    Friend WithEvents llblRSSLink As System.Windows.Forms.LinkLabel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pnlBlockedNotice As System.Windows.Forms.Panel
    Friend WithEvents lblBlockText As System.Windows.Forms.Label
    Friend WithEvents picCloseBlockPanel As System.Windows.Forms.PictureBox
    Friend WithEvents chkDoNotShowBlockPanel As System.Windows.Forms.CheckBox
    Friend WithEvents llblBlockedScriptsInfo As System.Windows.Forms.LinkLabel
    Private WithEvents RecipientIconColumn As BrightIdeasSoftware.OLVColumn
    Private WithEvents RecipientTypeColumn As BrightIdeasSoftware.OLVColumn
    Private WithEvents RecipientNameColumn As BrightIdeasSoftware.OLVColumn
    Private WithEvents RecipientAddressColumn As BrightIdeasSoftware.OLVColumn
    Private WithEvents ReceivedColumn As BrightIdeasSoftware.OLVColumn
    Private WithEvents ViewedColumn As BrightIdeasSoftware.OLVColumn
    Private WithEvents ResentColumn As BrightIdeasSoftware.OLVColumn
    Private WithEvents AttachmentNameColumn As BrightIdeasSoftware.OLVColumn
    Private WithEvents OlvColumnFileSize As BrightIdeasSoftware.OLVColumn
    Private WithEvents NotesEditToolStripButton As System.Windows.Forms.ToolStripButton
    Private WithEvents NotesSaveToolStripButton As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents DeleteNotesToolStripButton As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Private WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Private WithEvents OlvColumnSubject As BrightIdeasSoftware.OLVColumn
    Private WithEvents OlvColumnRecipients As BrightIdeasSoftware.OLVColumn
    Private WithEvents OlvColumnMessageDate As BrightIdeasSoftware.OLVColumn
    Private WithEvents OlvColumnSize As BrightIdeasSoftware.OLVColumn
    Private WithEvents OlvColumnReceived As BrightIdeasSoftware.OLVColumn
    Private WithEvents OlvColumnViewed As BrightIdeasSoftware.OLVColumn
    Private WithEvents OpenMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents MarkMessageReadAndDeleteThisReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents SaveallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents OpenAttachmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents OpenFileLocationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents attachmentImageList As System.Windows.Forms.ImageList
    Private WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents recipientImageList As System.Windows.Forms.ImageList
    Private WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Private WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Private WithEvents AddToAddressBookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents MarkReadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents LaunchSeparator As System.Windows.Forms.ToolStripSeparator
    Private WithEvents LaunchURLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tmrLoadMessage As System.Windows.Forms.Timer
    Private WithEvents CopyemailAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents EditContactToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxmnuRSSLink As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyLinkAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewMessageProcessingruleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbReturnReceiptInfo As System.Windows.Forms.PictureBox
    Friend WithEvents pbFindMessagesForReceipts As System.Windows.Forms.PictureBox
    Friend WithEvents pbCloseReceiptPanel As System.Windows.Forms.PictureBox
    Friend WithEvents chkDoNotShowProcessReceiptPanel As System.Windows.Forms.CheckBox
    Friend WithEvents pbRemoteImageInfo As System.Windows.Forms.PictureBox
    Friend WithEvents pbShowRemoteImageURLs As System.Windows.Forms.PictureBox
    Friend WithEvents pbUnblockRemoteImages As System.Windows.Forms.PictureBox
    Friend WithEvents pbNeverBlockRemoteImagesForSender As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainerReaderReplyBox As System.Windows.Forms.SplitContainer
    Private WithEvents replyModeImageList As System.Windows.Forms.ImageList
    Friend WithEvents DescribedTaskRenderer1 As BrightIdeasSoftware.DescribedTaskRenderer
    Friend WithEvents olvReplyModes As BrightIdeasSoftware.ObjectListView
    Private WithEvents OlvColumnReplyModeText As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ctxReadText As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImglstMessageStatus As System.Windows.Forms.ImageList
    Friend WithEvents HeaderFormatStyleWingDings As BrightIdeasSoftware.HeaderFormatStyle
    Friend WithEvents OlvColumnMessageAttachments As BrightIdeasSoftware.OLVColumn
    Friend WithEvents CopyFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewEmailToThisContactToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
