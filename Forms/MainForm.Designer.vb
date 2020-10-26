<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim HeaderStateStyle1 As BrightIdeasSoftware.HeaderStateStyle = New BrightIdeasSoftware.HeaderStateStyle()
        Dim HeaderStateStyle2 As BrightIdeasSoftware.HeaderStateStyle = New BrightIdeasSoftware.HeaderStateStyle()
        Dim HeaderStateStyle3 As BrightIdeasSoftware.HeaderStateStyle = New BrightIdeasSoftware.HeaderStateStyle()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewMessageToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImportExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportMessagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.SendUnsentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendAndReceiveAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.EmptyTrashToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessagePreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessagePreviewNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessagePreviewVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessagePreviewHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowReplyModesInPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMessageHeadersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageHighlightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageHighlightNoHighlightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageHighlightHighlightSenderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageHighlightHighlightsubjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.FolderTreeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowContactListAreaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.AllColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageListColumnSelectorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageHTMLsourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshFolderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearFiltersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterMatchOtherPartyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterMatchSubjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DarkModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WithoutEmbeddedImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WithEmbeddedImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.MarkMessageReadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkMessageUnreadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectTopMessageInListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReplyOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReplyToSenderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReplyMessageToAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForwardMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FollowUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SendReturnReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.TreatAsReadReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNotesToMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewProcessingRuleFromMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatchingSenderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatchingSubjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.MoveToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeSubjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindInMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReadMessageContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadMessagePauseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadMessageResumeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveDuplicateMessagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LimitEmailDownloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindOrphanedAttachmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageDoNotSendListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtractAttachementsFromSelectedMessagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneragePrivacyCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewReceiveMessageLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddSelectedFolderToQuickJumpListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScheduleMessagesInOutboxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetSentDateToTodayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterContactsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddressBookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateChangeMasterPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator27 = New System.Windows.Forms.ToolStripSeparator()
        Me.MessageProcessingRulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageDictionariesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageSignaturesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.EmailAccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FeedsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RSSAndBlogFeedsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubmitLogFileToServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestConnectionToTrulyMailServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutTrulyMailClientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImglstMessageStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.FilterMessageCountToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UnreadMessagesStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TotalMessagesStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerAddressBook = New System.Windows.Forms.SplitContainer()
        Me.tvFolders = New System.Windows.Forms.TreeView()
        Me.pnlTreeViewQuickJump = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.tblLayoutTreeViewQuickJumps = New System.Windows.Forms.TableLayoutPanel()
        Me.ContactSelector1 = New TrulyMail.ContactSelectorPlain()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.olvMessages = New BrightIdeasSoftware.ObjectListView()
        Me.olvColumnSubject = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnAttachments = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.HeaderFormatStyleWingDings = New BrightIdeasSoftware.HeaderFormatStyle()
        Me.olvColumnOtherParties = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnMessageDateSent = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnSize = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnReceived = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnViewed = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnTransportType = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnHasNotes = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnTags = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnImportance = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvcolReadButton = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.pnlMessageFilter = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.llblFilter = New System.Windows.Forms.LinkLabel()
        Me.txtMessageFilter = New System.Windows.Forms.TextBox()
        Me.btnClearMessageFilter = New System.Windows.Forms.Button()
        Me.pbClearTags = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboMessageTags = New System.Windows.Forms.ComboBox()
        Me.pbAddTag = New System.Windows.Forms.PictureBox()
        Me.llblOpenSelectedMessages = New System.Windows.Forms.LinkLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.WriteMessageToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AddContactToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.AddEmailContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.SendReceiveToolStripSplitButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.SendReceiveAllAccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.SendReceiveTrulyMailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopProcessingToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddressBookToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DeleteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReplyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ReplyToAllToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ForwardToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShowContactListToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.MessageHighlightToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.MessageHighlightNothingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageHighlightSenderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageHighlightSubjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrSendReceive = New System.Windows.Forms.Timer(Me.components)
        Me.ctxmnuTree = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewSubfolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveFolderToRootToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkFolderReadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeFolderColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeFolderColorBlueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeFolderColorGreenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeFolderColorYellowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeFolderColorOrangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeFolderColorRedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeFolderColorPurpleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmptyTrashToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.bgwReceive = New System.ComponentModel.BackgroundWorker()
        Me.ctxmnuMessage = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterSenderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterSubjectToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddNotesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator()
        Me.MarkReadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkUnreadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.CreateReminderFromMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateProcessingRuleFromMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatchingSenderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatchingSubjectToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator31 = New System.Windows.Forms.ToolStripSeparator()
        Me.SendNowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DelaySendingFor1HourToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReplyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReplyToAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForwardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrInvokeNextRoutine = New System.Windows.Forms.Timer(Me.components)
        Me.bgwDownloadPOP = New System.ComponentModel.BackgroundWorker()
        Me.bgwCheckAllEmail = New System.ComponentModel.BackgroundWorker()
        Me.tmrAutoEmptyTrash = New System.Timers.Timer()
        Me.bgwAutoEmptyTrash = New System.ComponentModel.BackgroundWorker()
        Me.tmrRefreshCurrentFolder = New System.Windows.Forms.Timer(Me.components)
        Me.ctxmnuColumnSelector = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.bgwStartupBatchBackgroundStuff = New System.ComponentModel.BackgroundWorker()
        Me.tmrNotifyMessagesReceived = New System.Windows.Forms.Timer(Me.components)
        Me.bgwDownloadRSS = New System.ComponentModel.BackgroundWorker()
        Me.tmrFolderExpand = New System.Windows.Forms.Timer(Me.components)
        Me.tmrSelectedMessageChanged = New System.Windows.Forms.Timer(Me.components)
        Me.ctxmnuFilter = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FilterOnlyUnreadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterOnlyReadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator29 = New System.Windows.Forms.ToolStripSeparator()
        Me.FilterOnlyTodayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterOnlyLast2DaysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterOnlyThisWeekToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterMoreThanOneWeekToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterMoreThanOneMonthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterMoreThanThreeMonthsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterMoreThanSixMonthsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator30 = New System.Windows.Forms.ToolStripSeparator()
        Me.FilterClearAllFiltersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrFilterMessages = New System.Timers.Timer()
        Me.ctxmnuQuickJump = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenAsplainTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainerAddressBook, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerAddressBook.Panel1.SuspendLayout()
        Me.SplitContainerAddressBook.Panel2.SuspendLayout()
        Me.SplitContainerAddressBook.SuspendLayout()
        CType(Me.pnlTreeViewQuickJump, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTreeViewQuickJump.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.olvMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlMessageFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMessageFilter.SuspendLayout()
        CType(Me.pbClearTags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddTag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.ctxmnuTree.SuspendLayout()
        Me.ctxmnuMessage.SuspendLayout()
        CType(Me.tmrAutoEmptyTrash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmnuFilter.SuspendLayout()
        CType(Me.tmrFilterMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmnuQuickJump.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.MessageToolStripMenuItem, Me.ExtraToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1124, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewMessageToolStripMenuItem1, Me.ToolStripSeparator21, Me.ImportExportToolStripMenuItem, Me.ExportMessagesToolStripMenuItem, Me.PrintToolStripMenuItem, Me.ToolStripSeparator5, Me.SendUnsentToolStripMenuItem, Me.SendAndReceiveAllToolStripMenuItem, Me.ToolStripSeparator3, Me.EmptyTrashToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewMessageToolStripMenuItem1
        '
        Me.NewMessageToolStripMenuItem1.Image = CType(resources.GetObject("NewMessageToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.NewMessageToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.White
        Me.NewMessageToolStripMenuItem1.Name = "NewMessageToolStripMenuItem1"
        Me.NewMessageToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewMessageToolStripMenuItem1.Size = New System.Drawing.Size(213, 22)
        Me.NewMessageToolStripMenuItem1.Text = "&New Message..."
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(210, 6)
        '
        'ImportExportToolStripMenuItem
        '
        Me.ImportExportToolStripMenuItem.Name = "ImportExportToolStripMenuItem"
        Me.ImportExportToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ImportExportToolStripMenuItem.Text = "&Import Messages..."
        '
        'ExportMessagesToolStripMenuItem
        '
        Me.ExportMessagesToolStripMenuItem.Name = "ExportMessagesToolStripMenuItem"
        Me.ExportMessagesToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ExportMessagesToolStripMenuItem.Text = "Export &Messages..."
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.PrintToolStripMenuItem.Text = "&Print..."
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(210, 6)
        '
        'SendUnsentToolStripMenuItem
        '
        Me.SendUnsentToolStripMenuItem.Name = "SendUnsentToolStripMenuItem"
        Me.SendUnsentToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.SendUnsentToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.SendUnsentToolStripMenuItem.Text = "Send &Unsent Messages"
        '
        'SendAndReceiveAllToolStripMenuItem
        '
        Me.SendAndReceiveAllToolStripMenuItem.Image = CType(resources.GetObject("SendAndReceiveAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SendAndReceiveAllToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.SendAndReceiveAllToolStripMenuItem.Name = "SendAndReceiveAllToolStripMenuItem"
        Me.SendAndReceiveAllToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.SendAndReceiveAllToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.SendAndReceiveAllToolStripMenuItem.Text = "Send &and Receive"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(210, 6)
        '
        'EmptyTrashToolStripMenuItem1
        '
        Me.EmptyTrashToolStripMenuItem1.Image = Global.TrulyMail.My.Resources.Resources.Emptytrashcan_16
        Me.EmptyTrashToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.White
        Me.EmptyTrashToolStripMenuItem1.Name = "EmptyTrashToolStripMenuItem1"
        Me.EmptyTrashToolStripMenuItem1.Size = New System.Drawing.Size(213, 22)
        Me.EmptyTrashToolStripMenuItem1.Text = "&Empty Trash"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Enabled = False
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.UndoToolStripMenuItem.Text = "&Undo"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MessagePreviewToolStripMenuItem, Me.ViewMessageHeadersToolStripMenuItem, Me.MessageHighlightToolStripMenuItem, Me.ToolStripSeparator25, Me.FolderTreeToolStripMenuItem, Me.MessageFilterToolStripMenuItem, Me.ShowContactListAreaToolStripMenuItem, Me.ToolStripSeparator24, Me.AllColumnsToolStripMenuItem, Me.MessageListColumnSelectorToolStripMenuItem, Me.MessageHTMLsourceToolStripMenuItem, Me.RefreshFolderToolStripMenuItem1, Me.ToolStripSeparator22, Me.ClearFiltersToolStripMenuItem, Me.FilterMatchOtherPartyToolStripMenuItem, Me.FilterMatchSubjectToolStripMenuItem, Me.DarkModeToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'MessagePreviewToolStripMenuItem
        '
        Me.MessagePreviewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MessagePreviewNoneToolStripMenuItem, Me.MessagePreviewVerticalToolStripMenuItem, Me.MessagePreviewHorizontalToolStripMenuItem, Me.ShowReplyModesInPreviewToolStripMenuItem})
        Me.MessagePreviewToolStripMenuItem.Name = "MessagePreviewToolStripMenuItem"
        Me.MessagePreviewToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.MessagePreviewToolStripMenuItem.Text = "&Message Preview"
        '
        'MessagePreviewNoneToolStripMenuItem
        '
        Me.MessagePreviewNoneToolStripMenuItem.Name = "MessagePreviewNoneToolStripMenuItem"
        Me.MessagePreviewNoneToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F9), System.Windows.Forms.Keys)
        Me.MessagePreviewNoneToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.MessagePreviewNoneToolStripMenuItem.Text = "&None"
        '
        'MessagePreviewVerticalToolStripMenuItem
        '
        Me.MessagePreviewVerticalToolStripMenuItem.Name = "MessagePreviewVerticalToolStripMenuItem"
        Me.MessagePreviewVerticalToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F10), System.Windows.Forms.Keys)
        Me.MessagePreviewVerticalToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.MessagePreviewVerticalToolStripMenuItem.Text = "&Vertical"
        Me.MessagePreviewVerticalToolStripMenuItem.Visible = False
        '
        'MessagePreviewHorizontalToolStripMenuItem
        '
        Me.MessagePreviewHorizontalToolStripMenuItem.Name = "MessagePreviewHorizontalToolStripMenuItem"
        Me.MessagePreviewHorizontalToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F11), System.Windows.Forms.Keys)
        Me.MessagePreviewHorizontalToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.MessagePreviewHorizontalToolStripMenuItem.Text = "&Horizontal"
        '
        'ShowReplyModesInPreviewToolStripMenuItem
        '
        Me.ShowReplyModesInPreviewToolStripMenuItem.Name = "ShowReplyModesInPreviewToolStripMenuItem"
        Me.ShowReplyModesInPreviewToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ShowReplyModesInPreviewToolStripMenuItem.Text = "Show Action Panel in Preview"
        '
        'ViewMessageHeadersToolStripMenuItem
        '
        Me.ViewMessageHeadersToolStripMenuItem.Name = "ViewMessageHeadersToolStripMenuItem"
        Me.ViewMessageHeadersToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.ViewMessageHeadersToolStripMenuItem.Text = "Message &Headers..."
        '
        'MessageHighlightToolStripMenuItem
        '
        Me.MessageHighlightToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MessageHighlightNoHighlightToolStripMenuItem, Me.MessageHighlightHighlightSenderToolStripMenuItem, Me.MessageHighlightHighlightsubjectToolStripMenuItem})
        Me.MessageHighlightToolStripMenuItem.Name = "MessageHighlightToolStripMenuItem"
        Me.MessageHighlightToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.MessageHighlightToolStripMenuItem.Text = "Message H&ighlight"
        '
        'MessageHighlightNoHighlightToolStripMenuItem
        '
        Me.MessageHighlightNoHighlightToolStripMenuItem.Name = "MessageHighlightNoHighlightToolStripMenuItem"
        Me.MessageHighlightNoHighlightToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.MessageHighlightNoHighlightToolStripMenuItem.Text = "&No highlight"
        '
        'MessageHighlightHighlightSenderToolStripMenuItem
        '
        Me.MessageHighlightHighlightSenderToolStripMenuItem.Name = "MessageHighlightHighlightSenderToolStripMenuItem"
        Me.MessageHighlightHighlightSenderToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.MessageHighlightHighlightSenderToolStripMenuItem.Text = "&Highlight sender"
        '
        'MessageHighlightHighlightsubjectToolStripMenuItem
        '
        Me.MessageHighlightHighlightsubjectToolStripMenuItem.Name = "MessageHighlightHighlightsubjectToolStripMenuItem"
        Me.MessageHighlightHighlightsubjectToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.MessageHighlightHighlightsubjectToolStripMenuItem.Text = "Highlight &subject"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(268, 6)
        '
        'FolderTreeToolStripMenuItem
        '
        Me.FolderTreeToolStripMenuItem.Checked = True
        Me.FolderTreeToolStripMenuItem.CheckOnClick = True
        Me.FolderTreeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.FolderTreeToolStripMenuItem.Name = "FolderTreeToolStripMenuItem"
        Me.FolderTreeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.FolderTreeToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.FolderTreeToolStripMenuItem.Text = "Folder &Tree Area"
        '
        'MessageFilterToolStripMenuItem
        '
        Me.MessageFilterToolStripMenuItem.Checked = True
        Me.MessageFilterToolStripMenuItem.CheckOnClick = True
        Me.MessageFilterToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MessageFilterToolStripMenuItem.Name = "MessageFilterToolStripMenuItem"
        Me.MessageFilterToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.MessageFilterToolStripMenuItem.Text = "&Filter and Tag Area"
        '
        'ShowContactListAreaToolStripMenuItem
        '
        Me.ShowContactListAreaToolStripMenuItem.Checked = True
        Me.ShowContactListAreaToolStripMenuItem.CheckOnClick = True
        Me.ShowContactListAreaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowContactListAreaToolStripMenuItem.Name = "ShowContactListAreaToolStripMenuItem"
        Me.ShowContactListAreaToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.ShowContactListAreaToolStripMenuItem.Text = "Contact List Area"
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(268, 6)
        '
        'AllColumnsToolStripMenuItem
        '
        Me.AllColumnsToolStripMenuItem.Name = "AllColumnsToolStripMenuItem"
        Me.AllColumnsToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.AllColumnsToolStripMenuItem.Text = "&Reset Columns"
        '
        'MessageListColumnSelectorToolStripMenuItem
        '
        Me.MessageListColumnSelectorToolStripMenuItem.Name = "MessageListColumnSelectorToolStripMenuItem"
        Me.MessageListColumnSelectorToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.MessageListColumnSelectorToolStripMenuItem.Text = "&Select Columns..."
        '
        'MessageHTMLsourceToolStripMenuItem
        '
        Me.MessageHTMLsourceToolStripMenuItem.Name = "MessageHTMLsourceToolStripMenuItem"
        Me.MessageHTMLsourceToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.MessageHTMLsourceToolStripMenuItem.Text = "Message HTML &source..."
        '
        'RefreshFolderToolStripMenuItem1
        '
        Me.RefreshFolderToolStripMenuItem1.Name = "RefreshFolderToolStripMenuItem1"
        Me.RefreshFolderToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.RefreshFolderToolStripMenuItem1.Size = New System.Drawing.Size(271, 22)
        Me.RefreshFolderToolStripMenuItem1.Text = "Refresh folder"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(268, 6)
        '
        'ClearFiltersToolStripMenuItem
        '
        Me.ClearFiltersToolStripMenuItem.Name = "ClearFiltersToolStripMenuItem"
        Me.ClearFiltersToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.ClearFiltersToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.ClearFiltersToolStripMenuItem.Text = "Clear filters"
        '
        'FilterMatchOtherPartyToolStripMenuItem
        '
        Me.FilterMatchOtherPartyToolStripMenuItem.Name = "FilterMatchOtherPartyToolStripMenuItem"
        Me.FilterMatchOtherPartyToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.FilterMatchOtherPartyToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.FilterMatchOtherPartyToolStripMenuItem.Text = "Filter match other party"
        '
        'FilterMatchSubjectToolStripMenuItem
        '
        Me.FilterMatchSubjectToolStripMenuItem.Name = "FilterMatchSubjectToolStripMenuItem"
        Me.FilterMatchSubjectToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.FilterMatchSubjectToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.FilterMatchSubjectToolStripMenuItem.Text = "Filter match subject"
        '
        'DarkModeToolStripMenuItem
        '
        Me.DarkModeToolStripMenuItem.Name = "DarkModeToolStripMenuItem"
        Me.DarkModeToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.DarkModeToolStripMenuItem.Text = "&Dark mode"
        '
        'MessageToolStripMenuItem
        '
        Me.MessageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenMessageToolStripMenuItem, Me.OpenAsplainTextToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripSeparator15, Me.MarkMessageReadToolStripMenuItem, Me.MarkMessageUnreadToolStripMenuItem, Me.SelectTopMessageInListToolStripMenuItem, Me.ToolStripSeparator19, Me.DeleteMessageToolStripMenuItem, Me.ToolStripSeparator4, Me.ReplyOptionsToolStripMenuItem, Me.ToolStripSeparator18, Me.TreatAsReadReceiptToolStripMenuItem, Me.AddNotesToMessageToolStripMenuItem, Me.NewProcessingRuleFromMessageToolStripMenuItem, Me.ToolStripSeparator20, Me.MoveToToolStripMenuItem, Me.ChangeSubjectToolStripMenuItem, Me.FindInMessageToolStripMenuItem, Me.ToolStripSeparator23, Me.ReadMessageContentsToolStripMenuItem, Me.ReadMessagePauseToolStripMenuItem, Me.ReadMessageResumeToolStripMenuItem})
        Me.MessageToolStripMenuItem.Name = "MessageToolStripMenuItem"
        Me.MessageToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.MessageToolStripMenuItem.Text = "&Message"
        '
        'OpenMessageToolStripMenuItem
        '
        Me.OpenMessageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WithoutEmbeddedImagesToolStripMenuItem, Me.WithEmbeddedImagesToolStripMenuItem})
        Me.OpenMessageToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenMessageToolStripMenuItem.Name = "OpenMessageToolStripMenuItem"
        Me.OpenMessageToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.OpenMessageToolStripMenuItem.Text = "&Open HTML externally"
        '
        'WithoutEmbeddedImagesToolStripMenuItem
        '
        Me.WithoutEmbeddedImagesToolStripMenuItem.Name = "WithoutEmbeddedImagesToolStripMenuItem"
        Me.WithoutEmbeddedImagesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.WithoutEmbeddedImagesToolStripMenuItem.Size = New System.Drawing.Size(284, 22)
        Me.WithoutEmbeddedImagesToolStripMenuItem.Text = "With&out embedded images"
        '
        'WithEmbeddedImagesToolStripMenuItem
        '
        Me.WithEmbeddedImagesToolStripMenuItem.Name = "WithEmbeddedImagesToolStripMenuItem"
        Me.WithEmbeddedImagesToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.WithEmbeddedImagesToolStripMenuItem.Size = New System.Drawing.Size(284, 22)
        Me.WithEmbeddedImagesToolStripMenuItem.Text = "&With embedded images..."
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save &As..."
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(259, 6)
        '
        'MarkMessageReadToolStripMenuItem
        '
        Me.MarkMessageReadToolStripMenuItem.Name = "MarkMessageReadToolStripMenuItem"
        Me.MarkMessageReadToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.MarkMessageReadToolStripMenuItem.Text = "Mark &Read"
        '
        'MarkMessageUnreadToolStripMenuItem
        '
        Me.MarkMessageUnreadToolStripMenuItem.Name = "MarkMessageUnreadToolStripMenuItem"
        Me.MarkMessageUnreadToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.MarkMessageUnreadToolStripMenuItem.Text = "Mark &Unread"
        '
        'SelectTopMessageInListToolStripMenuItem
        '
        Me.SelectTopMessageInListToolStripMenuItem.Name = "SelectTopMessageInListToolStripMenuItem"
        Me.SelectTopMessageInListToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D1), System.Windows.Forms.Keys)
        Me.SelectTopMessageInListToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.SelectTopMessageInListToolStripMenuItem.Text = "Select top message in list"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(259, 6)
        '
        'DeleteMessageToolStripMenuItem
        '
        Me.DeleteMessageToolStripMenuItem.Image = CType(resources.GetObject("DeleteMessageToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteMessageToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.DeleteMessageToolStripMenuItem.Name = "DeleteMessageToolStripMenuItem"
        Me.DeleteMessageToolStripMenuItem.ShortcutKeyDisplayString = "Del"
        Me.DeleteMessageToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.DeleteMessageToolStripMenuItem.Text = "&Delete"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(259, 6)
        '
        'ReplyOptionsToolStripMenuItem
        '
        Me.ReplyOptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReplyToSenderToolStripMenuItem, Me.ReplyMessageToAllToolStripMenuItem, Me.ForwardMessageToolStripMenuItem, Me.FollowUpToolStripMenuItem, Me.ToolStripSeparator1, Me.SendReturnReceiptToolStripMenuItem})
        Me.ReplyOptionsToolStripMenuItem.Name = "ReplyOptionsToolStripMenuItem"
        Me.ReplyOptionsToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ReplyOptionsToolStripMenuItem.Text = "Reply options"
        '
        'ReplyToSenderToolStripMenuItem
        '
        Me.ReplyToSenderToolStripMenuItem.Image = CType(resources.GetObject("ReplyToSenderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReplyToSenderToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ReplyToSenderToolStripMenuItem.Name = "ReplyToSenderToolStripMenuItem"
        Me.ReplyToSenderToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ReplyToSenderToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ReplyToSenderToolStripMenuItem.Text = "Reply to &Sender"
        Me.ReplyToSenderToolStripMenuItem.ToolTipText = "Reply without attachments to sender"
        '
        'ReplyMessageToAllToolStripMenuItem
        '
        Me.ReplyMessageToAllToolStripMenuItem.Image = CType(resources.GetObject("ReplyMessageToAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReplyMessageToAllToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ReplyMessageToAllToolStripMenuItem.Name = "ReplyMessageToAllToolStripMenuItem"
        Me.ReplyMessageToAllToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ReplyMessageToAllToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ReplyMessageToAllToolStripMenuItem.Text = "Reply to &All"
        Me.ReplyMessageToAllToolStripMenuItem.ToolTipText = "Reply without attachments to sender and all recipients"
        '
        'ForwardMessageToolStripMenuItem
        '
        Me.ForwardMessageToolStripMenuItem.Image = CType(resources.GetObject("ForwardMessageToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ForwardMessageToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ForwardMessageToolStripMenuItem.Name = "ForwardMessageToolStripMenuItem"
        Me.ForwardMessageToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ForwardMessageToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ForwardMessageToolStripMenuItem.Text = "&Forward"
        Me.ForwardMessageToolStripMenuItem.ToolTipText = "Forward message and attachments to new recipients"
        '
        'FollowUpToolStripMenuItem
        '
        Me.FollowUpToolStripMenuItem.Name = "FollowUpToolStripMenuItem"
        Me.FollowUpToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.FollowUpToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.FollowUpToolStripMenuItem.Text = "Fo&llow Up"
        Me.FollowUpToolStripMenuItem.ToolTipText = "Send a follow up message to all recipients"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(204, 6)
        '
        'SendReturnReceiptToolStripMenuItem
        '
        Me.SendReturnReceiptToolStripMenuItem.Name = "SendReturnReceiptToolStripMenuItem"
        Me.SendReturnReceiptToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.SendReturnReceiptToolStripMenuItem.Text = "Send return receipt"
        Me.SendReturnReceiptToolStripMenuItem.ToolTipText = "Send a receipt regardless of sender's request or if one was sent already"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(259, 6)
        '
        'TreatAsReadReceiptToolStripMenuItem
        '
        Me.TreatAsReadReceiptToolStripMenuItem.Name = "TreatAsReadReceiptToolStripMenuItem"
        Me.TreatAsReadReceiptToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.TreatAsReadReceiptToolStripMenuItem.Text = "&Treat as Read Receipt"
        '
        'AddNotesToMessageToolStripMenuItem
        '
        Me.AddNotesToMessageToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Note_16
        Me.AddNotesToMessageToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.AddNotesToMessageToolStripMenuItem.Name = "AddNotesToMessageToolStripMenuItem"
        Me.AddNotesToMessageToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.AddNotesToMessageToolStripMenuItem.Text = "Add &Notes to Message"
        '
        'NewProcessingRuleFromMessageToolStripMenuItem
        '
        Me.NewProcessingRuleFromMessageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MatchingSenderToolStripMenuItem, Me.MatchingSubjectToolStripMenuItem})
        Me.NewProcessingRuleFromMessageToolStripMenuItem.Name = "NewProcessingRuleFromMessageToolStripMenuItem"
        Me.NewProcessingRuleFromMessageToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.NewProcessingRuleFromMessageToolStripMenuItem.Text = "New Processing Rule from Message"
        '
        'MatchingSenderToolStripMenuItem
        '
        Me.MatchingSenderToolStripMenuItem.Name = "MatchingSenderToolStripMenuItem"
        Me.MatchingSenderToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.MatchingSenderToolStripMenuItem.Text = "Matching sender"
        '
        'MatchingSubjectToolStripMenuItem
        '
        Me.MatchingSubjectToolStripMenuItem.Name = "MatchingSubjectToolStripMenuItem"
        Me.MatchingSubjectToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.MatchingSubjectToolStripMenuItem.Text = "Matching subject"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(259, 6)
        '
        'MoveToToolStripMenuItem
        '
        Me.MoveToToolStripMenuItem.Name = "MoveToToolStripMenuItem"
        Me.MoveToToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.MoveToToolStripMenuItem.Text = "&Move to..."
        '
        'ChangeSubjectToolStripMenuItem
        '
        Me.ChangeSubjectToolStripMenuItem.Name = "ChangeSubjectToolStripMenuItem"
        Me.ChangeSubjectToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ChangeSubjectToolStripMenuItem.Text = "Change &Subject..."
        '
        'FindInMessageToolStripMenuItem
        '
        Me.FindInMessageToolStripMenuItem.Name = "FindInMessageToolStripMenuItem"
        Me.FindInMessageToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FindInMessageToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.FindInMessageToolStripMenuItem.Text = "F&ind in Message"
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(259, 6)
        '
        'ReadMessageContentsToolStripMenuItem
        '
        Me.ReadMessageContentsToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.PlayButton_16
        Me.ReadMessageContentsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ReadMessageContentsToolStripMenuItem.Name = "ReadMessageContentsToolStripMenuItem"
        Me.ReadMessageContentsToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ReadMessageContentsToolStripMenuItem.Text = "Read Message &Contents"
        '
        'ReadMessagePauseToolStripMenuItem
        '
        Me.ReadMessagePauseToolStripMenuItem.Enabled = False
        Me.ReadMessagePauseToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.PauseButton_16
        Me.ReadMessagePauseToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ReadMessagePauseToolStripMenuItem.Name = "ReadMessagePauseToolStripMenuItem"
        Me.ReadMessagePauseToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ReadMessagePauseToolStripMenuItem.Text = "&Pause Reading"
        '
        'ReadMessageResumeToolStripMenuItem
        '
        Me.ReadMessageResumeToolStripMenuItem.Enabled = False
        Me.ReadMessageResumeToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.ResumeButton_16
        Me.ReadMessageResumeToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ReadMessageResumeToolStripMenuItem.Name = "ReadMessageResumeToolStripMenuItem"
        Me.ReadMessageResumeToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ReadMessageResumeToolStripMenuItem.Text = "R&esume Reading"
        '
        'ExtraToolStripMenuItem
        '
        Me.ExtraToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveDuplicateMessagesToolStripMenuItem, Me.LimitEmailDownloadToolStripMenuItem, Me.FindOrphanedAttachmentsToolStripMenuItem, Me.ManageDoNotSendListToolStripMenuItem, Me.ExtractAttachementsFromSelectedMessagesToolStripMenuItem, Me.GeneragePrivacyCodeToolStripMenuItem, Me.ViewReceiveMessageLogToolStripMenuItem, Me.AddSelectedFolderToQuickJumpListToolStripMenuItem, Me.ScheduleMessagesInOutboxToolStripMenuItem, Me.ResetSentDateToTodayToolStripMenuItem, Me.FilterContactsToolStripMenuItem})
        Me.ExtraToolStripMenuItem.Name = "ExtraToolStripMenuItem"
        Me.ExtraToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.ExtraToolStripMenuItem.Text = "E&xtra"
        '
        'RemoveDuplicateMessagesToolStripMenuItem
        '
        Me.RemoveDuplicateMessagesToolStripMenuItem.Name = "RemoveDuplicateMessagesToolStripMenuItem"
        Me.RemoveDuplicateMessagesToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.RemoveDuplicateMessagesToolStripMenuItem.Text = "Select &duplicate messages"
        '
        'LimitEmailDownloadToolStripMenuItem
        '
        Me.LimitEmailDownloadToolStripMenuItem.Name = "LimitEmailDownloadToolStripMenuItem"
        Me.LimitEmailDownloadToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.LimitEmailDownloadToolStripMenuItem.Text = "&Limit email download..."
        '
        'FindOrphanedAttachmentsToolStripMenuItem
        '
        Me.FindOrphanedAttachmentsToolStripMenuItem.Name = "FindOrphanedAttachmentsToolStripMenuItem"
        Me.FindOrphanedAttachmentsToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.FindOrphanedAttachmentsToolStripMenuItem.Text = "Find &orphaned attachments..."
        '
        'ManageDoNotSendListToolStripMenuItem
        '
        Me.ManageDoNotSendListToolStripMenuItem.Name = "ManageDoNotSendListToolStripMenuItem"
        Me.ManageDoNotSendListToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.ManageDoNotSendListToolStripMenuItem.Text = "Manage Do &Not Send list..."
        '
        'ExtractAttachementsFromSelectedMessagesToolStripMenuItem
        '
        Me.ExtractAttachementsFromSelectedMessagesToolStripMenuItem.Name = "ExtractAttachementsFromSelectedMessagesToolStripMenuItem"
        Me.ExtractAttachementsFromSelectedMessagesToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.ExtractAttachementsFromSelectedMessagesToolStripMenuItem.Text = "&Extract attachements from selected messages..."
        '
        'GeneragePrivacyCodeToolStripMenuItem
        '
        Me.GeneragePrivacyCodeToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Securedmessage_16
        Me.GeneragePrivacyCodeToolStripMenuItem.Name = "GeneragePrivacyCodeToolStripMenuItem"
        Me.GeneragePrivacyCodeToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.GeneragePrivacyCodeToolStripMenuItem.Text = "&Generage encryption password"
        '
        'ViewReceiveMessageLogToolStripMenuItem
        '
        Me.ViewReceiveMessageLogToolStripMenuItem.Name = "ViewReceiveMessageLogToolStripMenuItem"
        Me.ViewReceiveMessageLogToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.ViewReceiveMessageLogToolStripMenuItem.Text = "&View receive message log"
        '
        'AddSelectedFolderToQuickJumpListToolStripMenuItem
        '
        Me.AddSelectedFolderToQuickJumpListToolStripMenuItem.Name = "AddSelectedFolderToQuickJumpListToolStripMenuItem"
        Me.AddSelectedFolderToQuickJumpListToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.AddSelectedFolderToQuickJumpListToolStripMenuItem.Text = "&Add selected folder to favorites"
        '
        'ScheduleMessagesInOutboxToolStripMenuItem
        '
        Me.ScheduleMessagesInOutboxToolStripMenuItem.Name = "ScheduleMessagesInOutboxToolStripMenuItem"
        Me.ScheduleMessagesInOutboxToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.ScheduleMessagesInOutboxToolStripMenuItem.Text = "&Schedule messages in outbox..."
        '
        'ResetSentDateToTodayToolStripMenuItem
        '
        Me.ResetSentDateToTodayToolStripMenuItem.Name = "ResetSentDateToTodayToolStripMenuItem"
        Me.ResetSentDateToTodayToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.ResetSentDateToTodayToolStripMenuItem.Text = "&Reset sent date to today"
        '
        'FilterContactsToolStripMenuItem
        '
        Me.FilterContactsToolStripMenuItem.Name = "FilterContactsToolStripMenuItem"
        Me.FilterContactsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.FilterContactsToolStripMenuItem.Size = New System.Drawing.Size(323, 22)
        Me.FilterContactsToolStripMenuItem.Text = "Filter contacts"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddressBookToolStripMenuItem, Me.SearchToolStripMenuItem, Me.CreateChangeMasterPasswordToolStripMenuItem, Me.ToolStripSeparator13, Me.ToolStripSeparator27, Me.MessageProcessingRulesToolStripMenuItem, Me.ManageDictionariesToolStripMenuItem, Me.ManageSignaturesToolStripMenuItem, Me.ToolStripSeparator14, Me.EmailAccountsToolStripMenuItem, Me.FeedsToolStripMenuItem, Me.OptionsToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'AddressBookToolStripMenuItem
        '
        Me.AddressBookToolStripMenuItem.Image = CType(resources.GetObject("AddressBookToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddressBookToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.AddressBookToolStripMenuItem.Name = "AddressBookToolStripMenuItem"
        Me.AddressBookToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.AddressBookToolStripMenuItem.Text = "&Address Book..."
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Image = CType(resources.GetObject("SearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.SearchToolStripMenuItem.Text = "&Search..."
        '
        'CreateChangeMasterPasswordToolStripMenuItem
        '
        Me.CreateChangeMasterPasswordToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Securedmessage_16
        Me.CreateChangeMasterPasswordToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.CreateChangeMasterPasswordToolStripMenuItem.Name = "CreateChangeMasterPasswordToolStripMenuItem"
        Me.CreateChangeMasterPasswordToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.CreateChangeMasterPasswordToolStripMenuItem.Text = "Create / Change Startup &Password / Local Encryption"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(350, 6)
        '
        'ToolStripSeparator27
        '
        Me.ToolStripSeparator27.Name = "ToolStripSeparator27"
        Me.ToolStripSeparator27.Size = New System.Drawing.Size(350, 6)
        Me.ToolStripSeparator27.Visible = False
        '
        'MessageProcessingRulesToolStripMenuItem
        '
        Me.MessageProcessingRulesToolStripMenuItem.Name = "MessageProcessingRulesToolStripMenuItem"
        Me.MessageProcessingRulesToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.MessageProcessingRulesToolStripMenuItem.Text = "&Message Processing Rules..."
        '
        'ManageDictionariesToolStripMenuItem
        '
        Me.ManageDictionariesToolStripMenuItem.Name = "ManageDictionariesToolStripMenuItem"
        Me.ManageDictionariesToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.ManageDictionariesToolStripMenuItem.Text = "Manage &Dictionaries..."
        '
        'ManageSignaturesToolStripMenuItem
        '
        Me.ManageSignaturesToolStripMenuItem.Name = "ManageSignaturesToolStripMenuItem"
        Me.ManageSignaturesToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.ManageSignaturesToolStripMenuItem.Text = "Manage A&utoText / Signatures..."
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(350, 6)
        '
        'EmailAccountsToolStripMenuItem
        '
        Me.EmailAccountsToolStripMenuItem.Image = CType(resources.GetObject("EmailAccountsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EmailAccountsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.EmailAccountsToolStripMenuItem.Name = "EmailAccountsToolStripMenuItem"
        Me.EmailAccountsToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.EmailAccountsToolStripMenuItem.Text = "&Email Accounts (sending and receiving email)..."
        '
        'FeedsToolStripMenuItem
        '
        Me.FeedsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RSSAndBlogFeedsToolStripMenuItem})
        Me.FeedsToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.rss_16
        Me.FeedsToolStripMenuItem.Name = "FeedsToolStripMenuItem"
        Me.FeedsToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.FeedsToolStripMenuItem.Text = "&Feeds"
        '
        'RSSAndBlogFeedsToolStripMenuItem
        '
        Me.RSSAndBlogFeedsToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.rss_16
        Me.RSSAndBlogFeedsToolStripMenuItem.Name = "RSSAndBlogFeedsToolStripMenuItem"
        Me.RSSAndBlogFeedsToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.RSSAndBlogFeedsToolStripMenuItem.Text = "&RSS and News Feeds..."
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Image = CType(resources.GetObject("OptionsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OptionsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(353, 22)
        Me.OptionsToolStripMenuItem.Text = "&Options..."
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SubmitLogFileToServerToolStripMenuItem, Me.TestConnectionToTrulyMailServerToolStripMenuItem, Me.ToolStripSeparator2, Me.AboutTrulyMailClientToolStripMenuItem, Me.TestToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'SubmitLogFileToServerToolStripMenuItem
        '
        Me.SubmitLogFileToServerToolStripMenuItem.Name = "SubmitLogFileToServerToolStripMenuItem"
        Me.SubmitLogFileToServerToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.SubmitLogFileToServerToolStripMenuItem.Text = "&Send data to TrulyMail Support..."
        '
        'TestConnectionToTrulyMailServerToolStripMenuItem
        '
        Me.TestConnectionToTrulyMailServerToolStripMenuItem.Name = "TestConnectionToTrulyMailServerToolStripMenuItem"
        Me.TestConnectionToTrulyMailServerToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.TestConnectionToTrulyMailServerToolStripMenuItem.Text = "Test &internet connection..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(242, 6)
        '
        'AboutTrulyMailClientToolStripMenuItem
        '
        Me.AboutTrulyMailClientToolStripMenuItem.Name = "AboutTrulyMailClientToolStripMenuItem"
        Me.AboutTrulyMailClientToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.AboutTrulyMailClientToolStripMenuItem.Text = "&About TrulyMail..."
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.TestToolStripMenuItem.Text = "test"
        Me.TestToolStripMenuItem.Visible = False
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
        Me.ImageList1.Images.SetKeyName(10, "folder-closed-blue_24.png")
        Me.ImageList1.Images.SetKeyName(11, "folder-closed-green_24.png")
        Me.ImageList1.Images.SetKeyName(12, "folder-closed-yellow_24.png")
        Me.ImageList1.Images.SetKeyName(13, "folder-closed-orange_24.png")
        Me.ImageList1.Images.SetKeyName(14, "folder-closed-red_24.png")
        Me.ImageList1.Images.SetKeyName(15, "folder-closed-purple_24.png")
        Me.ImageList1.Images.SetKeyName(16, "folder-open-blue.png")
        Me.ImageList1.Images.SetKeyName(17, "folder-open-green.png")
        Me.ImageList1.Images.SetKeyName(18, "folder-open-yellow.png")
        Me.ImageList1.Images.SetKeyName(19, "folder-open-orange.png")
        Me.ImageList1.Images.SetKeyName(20, "folder-open-red.png")
        Me.ImageList1.Images.SetKeyName(21, "folder-open-purple.png")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewFolderToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(135, 26)
        '
        'NewFolderToolStripMenuItem
        '
        Me.NewFolderToolStripMenuItem.Name = "NewFolderToolStripMenuItem"
        Me.NewFolderToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.NewFolderToolStripMenuItem.Text = "New Folder"
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
        Me.ImglstMessageStatus.Images.SetKeyName(13, "open message.png")
        Me.ImglstMessageStatus.Images.SetKeyName(14, "message.png")
        Me.ImglstMessageStatus.Images.SetKeyName(15, "pin.png")
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
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1124, 515)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1124, 615)
        Me.ToolStripContainer1.TabIndex = 17
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1, Me.FilterMessageCountToolStripStatusLabel, Me.UnreadMessagesStatusLabel, Me.TotalMessagesStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1124, 22)
        Me.StatusStrip1.TabIndex = 18
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(1008, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Loading...please wait"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(200, 16)
        Me.ToolStripProgressBar1.Visible = False
        '
        'FilterMessageCountToolStripStatusLabel
        '
        Me.FilterMessageCountToolStripStatusLabel.Name = "FilterMessageCountToolStripStatusLabel"
        Me.FilterMessageCountToolStripStatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'UnreadMessagesStatusLabel
        '
        Me.UnreadMessagesStatusLabel.Name = "UnreadMessagesStatusLabel"
        Me.UnreadMessagesStatusLabel.Size = New System.Drawing.Size(57, 17)
        Me.UnreadMessagesStatusLabel.Text = "Unread: 0"
        '
        'TotalMessagesStatusLabel
        '
        Me.TotalMessagesStatusLabel.Name = "TotalMessagesStatusLabel"
        Me.TotalMessagesStatusLabel.Size = New System.Drawing.Size(44, 17)
        Me.TotalMessagesStatusLabel.Text = "Total: 0"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainerAddressBook)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1124, 515)
        Me.SplitContainer1.SplitterDistance = 188
        Me.SplitContainer1.TabIndex = 19
        '
        'SplitContainerAddressBook
        '
        Me.SplitContainerAddressBook.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerAddressBook.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerAddressBook.Name = "SplitContainerAddressBook"
        Me.SplitContainerAddressBook.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerAddressBook.Panel1
        '
        Me.SplitContainerAddressBook.Panel1.Controls.Add(Me.tvFolders)
        Me.SplitContainerAddressBook.Panel1.Controls.Add(Me.pnlTreeViewQuickJump)
        '
        'SplitContainerAddressBook.Panel2
        '
        Me.SplitContainerAddressBook.Panel2.Controls.Add(Me.ContactSelector1)
        Me.SplitContainerAddressBook.Size = New System.Drawing.Size(188, 515)
        Me.SplitContainerAddressBook.SplitterDistance = 323
        Me.SplitContainerAddressBook.TabIndex = 0
        '
        'tvFolders
        '
        Me.tvFolders.AllowDrop = True
        Me.tvFolders.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tvFolders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvFolders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvFolders.HideSelection = False
        Me.tvFolders.ImageIndex = 0
        Me.tvFolders.ImageList = Me.ImageList1
        Me.tvFolders.Indent = 27
        Me.tvFolders.ItemHeight = 24
        Me.tvFolders.LabelEdit = True
        Me.tvFolders.Location = New System.Drawing.Point(0, 90)
        Me.tvFolders.Name = "tvFolders"
        Me.tvFolders.SelectedImageKey = "Folder_Open.png"
        Me.tvFolders.ShowNodeToolTips = True
        Me.tvFolders.Size = New System.Drawing.Size(188, 233)
        Me.tvFolders.TabIndex = 58
        '
        'pnlTreeViewQuickJump
        '
        Me.pnlTreeViewQuickJump.Controls.Add(Me.tblLayoutTreeViewQuickJumps)
        Me.pnlTreeViewQuickJump.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTreeViewQuickJump.Location = New System.Drawing.Point(0, 0)
        Me.pnlTreeViewQuickJump.Name = "pnlTreeViewQuickJump"
        Me.pnlTreeViewQuickJump.Size = New System.Drawing.Size(188, 90)
        Me.pnlTreeViewQuickJump.TabIndex = 57
        Me.pnlTreeViewQuickJump.Visible = False
        '
        'tblLayoutTreeViewQuickJumps
        '
        Me.tblLayoutTreeViewQuickJumps.BackColor = System.Drawing.Color.Transparent
        Me.tblLayoutTreeViewQuickJumps.ColumnCount = 1
        Me.tblLayoutTreeViewQuickJumps.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutTreeViewQuickJumps.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblLayoutTreeViewQuickJumps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayoutTreeViewQuickJumps.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tblLayoutTreeViewQuickJumps.Location = New System.Drawing.Point(0, 0)
        Me.tblLayoutTreeViewQuickJumps.Name = "tblLayoutTreeViewQuickJumps"
        Me.tblLayoutTreeViewQuickJumps.RowCount = 2
        Me.tblLayoutTreeViewQuickJumps.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblLayoutTreeViewQuickJumps.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblLayoutTreeViewQuickJumps.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblLayoutTreeViewQuickJumps.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblLayoutTreeViewQuickJumps.Size = New System.Drawing.Size(188, 90)
        Me.tblLayoutTreeViewQuickJumps.TabIndex = 56
        '
        'ContactSelector1
        '
        Me.ContactSelector1.DarkMode = False
        Me.ContactSelector1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContactSelector1.HideReceiveOnly = False
        Me.ContactSelector1.Location = New System.Drawing.Point(0, 0)
        Me.ContactSelector1.Name = "ContactSelector1"
        Me.ContactSelector1.ShowButtons = False
        Me.ContactSelector1.ShowShortcutMenu = True
        Me.ContactSelector1.Size = New System.Drawing.Size(188, 188)
        Me.ContactSelector1.TabIndex = 56
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.olvMessages)
        Me.SplitContainer3.Panel1.Controls.Add(Me.pnlMessageFilter)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.llblOpenSelectedMessages)
        Me.SplitContainer3.Size = New System.Drawing.Size(932, 515)
        Me.SplitContainer3.SplitterDistance = 574
        Me.SplitContainer3.TabIndex = 4
        '
        'olvMessages
        '
        Me.olvMessages.AllColumns.Add(Me.olvColumnSubject)
        Me.olvMessages.AllColumns.Add(Me.olvColumnAttachments)
        Me.olvMessages.AllColumns.Add(Me.olvColumnOtherParties)
        Me.olvMessages.AllColumns.Add(Me.olvColumnMessageDateSent)
        Me.olvMessages.AllColumns.Add(Me.olvColumnSize)
        Me.olvMessages.AllColumns.Add(Me.olvColumnReceived)
        Me.olvMessages.AllColumns.Add(Me.olvColumnViewed)
        Me.olvMessages.AllColumns.Add(Me.olvColumnTransportType)
        Me.olvMessages.AllColumns.Add(Me.olvColumnHasNotes)
        Me.olvMessages.AllColumns.Add(Me.olvColumnTags)
        Me.olvMessages.AllColumns.Add(Me.olvColumnImportance)
        Me.olvMessages.AllColumns.Add(Me.olvcolReadButton)
        Me.olvMessages.AllowColumnReorder = True
        Me.olvMessages.AlternateRowBackColor = System.Drawing.Color.White
        Me.olvMessages.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
        Me.olvMessages.CellEditUseWholeCell = False
        Me.olvMessages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvColumnSubject, Me.olvColumnAttachments, Me.olvColumnOtherParties, Me.olvColumnMessageDateSent, Me.olvColumnSize, Me.olvColumnReceived, Me.olvColumnViewed, Me.olvColumnTransportType, Me.olvColumnHasNotes, Me.olvColumnTags, Me.olvColumnImportance, Me.olvcolReadButton})
        Me.olvMessages.CopySelectionOnControlC = False
        Me.olvMessages.CopySelectionOnControlCUsesDragSource = False
        Me.olvMessages.Cursor = System.Windows.Forms.Cursors.Default
        Me.olvMessages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvMessages.EmptyListMsg = "This folder is empty"
        Me.olvMessages.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvMessages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvMessages.FullRowSelect = True
        Me.olvMessages.HideSelection = False
        Me.olvMessages.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvMessages.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvMessages.IsSimpleDragSource = True
        Me.olvMessages.LabelWrap = False
        Me.olvMessages.Location = New System.Drawing.Point(0, 29)
        Me.olvMessages.Name = "olvMessages"
        Me.olvMessages.OwnerDrawnHeader = True
        Me.olvMessages.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.olvMessages.ShowCommandMenuOnRightClick = True
        Me.olvMessages.ShowGroups = False
        Me.olvMessages.ShowImagesOnSubItems = True
        Me.olvMessages.ShowItemCountOnGroups = True
        Me.olvMessages.Size = New System.Drawing.Size(574, 486)
        Me.olvMessages.SmallImageList = Me.ImglstMessageStatus
        Me.olvMessages.TabIndex = 0
        Me.olvMessages.UseAlternatingBackColors = True
        Me.olvMessages.UseCompatibleStateImageBehavior = False
        Me.olvMessages.UseFiltering = True
        Me.olvMessages.UseHyperlinks = True
        Me.olvMessages.View = System.Windows.Forms.View.Details
        '
        'olvColumnSubject
        '
        Me.olvColumnSubject.AspectName = "SubjectShort"
        Me.olvColumnSubject.DisplayIndex = 2
        Me.olvColumnSubject.Hyperlink = True
        Me.olvColumnSubject.IsEditable = False
        Me.olvColumnSubject.Text = "Subject"
        Me.olvColumnSubject.ToolTipText = ""
        '
        'olvColumnAttachments
        '
        Me.olvColumnAttachments.AspectName = "Attachments.Count"
        Me.olvColumnAttachments.DisplayIndex = 3
        Me.olvColumnAttachments.HeaderFont = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.olvColumnAttachments.HeaderFormatStyle = Me.HeaderFormatStyleWingDings
        Me.olvColumnAttachments.HeaderImageKey = "attach.png"
        Me.olvColumnAttachments.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.olvColumnAttachments.IsEditable = False
        Me.olvColumnAttachments.ShowTextInHeader = False
        Me.olvColumnAttachments.Text = "Attachments"
        Me.olvColumnAttachments.ToolTipText = ""
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
        'olvColumnOtherParties
        '
        Me.olvColumnOtherParties.AspectName = "OtherPartiesShort"
        Me.olvColumnOtherParties.DisplayIndex = 4
        Me.olvColumnOtherParties.IsEditable = False
        Me.olvColumnOtherParties.Text = "Sender"
        '
        'olvColumnMessageDateSent
        '
        Me.olvColumnMessageDateSent.AspectName = "MainMessageDate"
        Me.olvColumnMessageDateSent.DisplayIndex = 5
        Me.olvColumnMessageDateSent.IsEditable = False
        Me.olvColumnMessageDateSent.Text = "Date"
        Me.olvColumnMessageDateSent.ToolTipText = ""
        '
        'olvColumnSize
        '
        Me.olvColumnSize.AspectName = "Size"
        Me.olvColumnSize.DisplayIndex = 6
        Me.olvColumnSize.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.olvColumnSize.IsEditable = False
        Me.olvColumnSize.Text = "Size"
        Me.olvColumnSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.olvColumnSize.ToolTipText = ""
        '
        'olvColumnReceived
        '
        Me.olvColumnReceived.AspectName = "Received"
        Me.olvColumnReceived.AspectToStringFormat = "{0:P0}"
        Me.olvColumnReceived.DisplayIndex = 7
        Me.olvColumnReceived.IsEditable = False
        Me.olvColumnReceived.Text = "Rec"
        Me.olvColumnReceived.ToolTipText = ""
        '
        'olvColumnViewed
        '
        Me.olvColumnViewed.AspectName = "Viewed"
        Me.olvColumnViewed.AspectToStringFormat = "{0:P0}"
        Me.olvColumnViewed.DisplayIndex = 8
        Me.olvColumnViewed.IsEditable = False
        Me.olvColumnViewed.Text = "View"
        Me.olvColumnViewed.ToolTipText = ""
        '
        'olvColumnTransportType
        '
        Me.olvColumnTransportType.AspectName = "TransportType"
        Me.olvColumnTransportType.AutoCompleteEditor = False
        Me.olvColumnTransportType.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None
        Me.olvColumnTransportType.DisplayIndex = 0
        Me.olvColumnTransportType.HeaderFont = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.olvColumnTransportType.HeaderFormatStyle = Me.HeaderFormatStyleWingDings
        Me.olvColumnTransportType.HeaderImageKey = "Securedmessage_16.png"
        Me.olvColumnTransportType.IsEditable = False
        Me.olvColumnTransportType.MaximumWidth = 18
        Me.olvColumnTransportType.MinimumWidth = 18
        Me.olvColumnTransportType.ShowTextInHeader = False
        Me.olvColumnTransportType.Text = "Transport Type"
        Me.olvColumnTransportType.ToolTipText = ""
        Me.olvColumnTransportType.Width = 18
        '
        'olvColumnHasNotes
        '
        Me.olvColumnHasNotes.AspectName = "HasNotes"
        Me.olvColumnHasNotes.DisplayIndex = 1
        Me.olvColumnHasNotes.HeaderFont = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.olvColumnHasNotes.HeaderFormatStyle = Me.HeaderFormatStyleWingDings
        Me.olvColumnHasNotes.HeaderImageKey = "noteTrans_16.png"
        Me.olvColumnHasNotes.IsEditable = False
        Me.olvColumnHasNotes.MaximumWidth = 18
        Me.olvColumnHasNotes.MinimumWidth = 18
        Me.olvColumnHasNotes.ShowTextInHeader = False
        Me.olvColumnHasNotes.Text = "Notes"
        Me.olvColumnHasNotes.ToolTipText = ""
        Me.olvColumnHasNotes.Width = 18
        '
        'olvColumnTags
        '
        Me.olvColumnTags.AspectName = "Tags"
        Me.olvColumnTags.Text = "Tags"
        Me.olvColumnTags.Width = 120
        '
        'olvColumnImportance
        '
        Me.olvColumnImportance.AspectName = "Importance"
        Me.olvColumnImportance.HeaderFont = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.olvColumnImportance.HeaderFormatStyle = Me.HeaderFormatStyleWingDings
        Me.olvColumnImportance.HeaderImageKey = "spam scales.png"
        Me.olvColumnImportance.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.olvColumnImportance.ShowTextInHeader = False
        Me.olvColumnImportance.Text = "Importance"
        Me.olvColumnImportance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.olvColumnImportance.ToolTipText = ""
        Me.olvColumnImportance.Width = 40
        '
        'olvcolReadButton
        '
        Me.olvcolReadButton.AspectName = "Read"
        Me.olvcolReadButton.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds
        Me.olvcolReadButton.HeaderImageKey = "(none)"
        Me.olvcolReadButton.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.olvcolReadButton.IsButton = True
        Me.olvcolReadButton.IsEditable = False
        Me.olvcolReadButton.IsHeaderVertical = True
        Me.olvcolReadButton.MaximumWidth = 20
        Me.olvcolReadButton.MinimumWidth = 20
        Me.olvcolReadButton.Text = "•"
        Me.olvcolReadButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.olvcolReadButton.ToolTipText = ""
        Me.olvcolReadButton.Width = 20
        '
        'pnlMessageFilter
        '
        Me.pnlMessageFilter.Controls.Add(Me.llblFilter)
        Me.pnlMessageFilter.Controls.Add(Me.txtMessageFilter)
        Me.pnlMessageFilter.Controls.Add(Me.btnClearMessageFilter)
        Me.pnlMessageFilter.Controls.Add(Me.pbClearTags)
        Me.pnlMessageFilter.Controls.Add(Me.Label2)
        Me.pnlMessageFilter.Controls.Add(Me.cboMessageTags)
        Me.pnlMessageFilter.Controls.Add(Me.pbAddTag)
        Me.pnlMessageFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMessageFilter.Location = New System.Drawing.Point(0, 0)
        Me.pnlMessageFilter.Name = "pnlMessageFilter"
        Me.pnlMessageFilter.Size = New System.Drawing.Size(574, 29)
        Me.pnlMessageFilter.TabIndex = 54
        '
        'llblFilter
        '
        Me.llblFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llblFilter.AutoSize = True
        Me.llblFilter.BackColor = System.Drawing.Color.Transparent
        Me.llblFilter.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.llblFilter.LinkArea = New System.Windows.Forms.LinkArea(0, 6)
        Me.llblFilter.Location = New System.Drawing.Point(345, 3)
        Me.llblFilter.Name = "llblFilter"
        Me.llblFilter.Size = New System.Drawing.Size(47, 24)
        Me.llblFilter.TabIndex = 10
        Me.llblFilter.TabStop = True
        Me.llblFilter.Text = "Filter:"
        Me.llblFilter.UseCompatibleTextRendering = True
        '
        'txtMessageFilter
        '
        Me.txtMessageFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtMessageFilter.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtMessageFilter.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessageFilter.Location = New System.Drawing.Point(398, 0)
        Me.txtMessageFilter.Name = "txtMessageFilter"
        Me.txtMessageFilter.Size = New System.Drawing.Size(142, 26)
        Me.txtMessageFilter.TabIndex = 9
        '
        'btnClearMessageFilter
        '
        Me.btnClearMessageFilter.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClearMessageFilter.Image = CType(resources.GetObject("btnClearMessageFilter.Image"), System.Drawing.Image)
        Me.btnClearMessageFilter.Location = New System.Drawing.Point(540, 0)
        Me.btnClearMessageFilter.Name = "btnClearMessageFilter"
        Me.btnClearMessageFilter.Size = New System.Drawing.Size(34, 29)
        Me.btnClearMessageFilter.TabIndex = 8
        Me.btnClearMessageFilter.UseVisualStyleBackColor = True
        '
        'pbClearTags
        '
        Me.pbClearTags.BackColor = System.Drawing.Color.Transparent
        Me.pbClearTags.Image = Global.TrulyMail.My.Resources.Resources.remove_icon_48
        Me.pbClearTags.Location = New System.Drawing.Point(224, 1)
        Me.pbClearTags.Name = "pbClearTags"
        Me.pbClearTags.Size = New System.Drawing.Size(32, 26)
        Me.pbClearTags.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbClearTags.TabIndex = 7
        Me.pbClearTags.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tag:"
        '
        'cboMessageTags
        '
        Me.cboMessageTags.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cboMessageTags.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cboMessageTags.FormattingEnabled = True
        Me.cboMessageTags.Location = New System.Drawing.Point(48, 0)
        Me.cboMessageTags.Name = "cboMessageTags"
        Me.cboMessageTags.Size = New System.Drawing.Size(138, 27)
        Me.cboMessageTags.TabIndex = 4
        '
        'pbAddTag
        '
        Me.pbAddTag.BackColor = System.Drawing.Color.Transparent
        Me.pbAddTag.Image = Global.TrulyMail.My.Resources.Resources.add_icon_48
        Me.pbAddTag.Location = New System.Drawing.Point(192, 1)
        Me.pbAddTag.Name = "pbAddTag"
        Me.pbAddTag.Size = New System.Drawing.Size(32, 26)
        Me.pbAddTag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddTag.TabIndex = 6
        Me.pbAddTag.TabStop = False
        '
        'llblOpenSelectedMessages
        '
        Me.llblOpenSelectedMessages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.llblOpenSelectedMessages.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblOpenSelectedMessages.LinkArea = New System.Windows.Forms.LinkArea(0, 24)
        Me.llblOpenSelectedMessages.Location = New System.Drawing.Point(0, 0)
        Me.llblOpenSelectedMessages.Name = "llblOpenSelectedMessages"
        Me.llblOpenSelectedMessages.Size = New System.Drawing.Size(354, 515)
        Me.llblOpenSelectedMessages.TabIndex = 0
        Me.llblOpenSelectedMessages.TabStop = True
        Me.llblOpenSelectedMessages.Text = "Open Selected Message(s)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This preview will only show a single message"
        Me.llblOpenSelectedMessages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.llblOpenSelectedMessages.UseCompatibleTextRendering = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WriteMessageToolStripButton, Me.PrintToolStripButton, Me.AddContactToolStripDropDownButton, Me.ToolStripSeparator16, Me.SendReceiveToolStripSplitButton, Me.StopProcessingToolStripButton, Me.ToolStripSeparator12, Me.AddressBookToolStripButton, Me.DeleteToolStripButton, Me.ToolStripSeparator10, Me.ReplyToolStripButton, Me.ReplyToAllToolStripButton, Me.ForwardToolStripButton, Me.ToolStripSeparator11, Me.ShowContactListToolStripButton, Me.ToolStripSeparator9, Me.MessageHighlightToolStripDropDownButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.ShowItemToolTips = False
        Me.ToolStrip1.Size = New System.Drawing.Size(819, 54)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'WriteMessageToolStripButton
        '
        Me.WriteMessageToolStripButton.Image = CType(resources.GetObject("WriteMessageToolStripButton.Image"), System.Drawing.Image)
        Me.WriteMessageToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.WriteMessageToolStripButton.Name = "WriteMessageToolStripButton"
        Me.WriteMessageToolStripButton.Size = New System.Drawing.Size(62, 51)
        Me.WriteMessageToolStripButton.Text = "Compose"
        Me.WriteMessageToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.Print_32
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(36, 51)
        Me.PrintToolStripButton.Text = "Print"
        Me.PrintToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'AddContactToolStripDropDownButton
        '
        Me.AddContactToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEmailContactToolStripMenuItem})
        Me.AddContactToolStripDropDownButton.Image = Global.TrulyMail.My.Resources.Resources.AddUser_32
        Me.AddContactToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.White
        Me.AddContactToolStripDropDownButton.Name = "AddContactToolStripDropDownButton"
        Me.AddContactToolStripDropDownButton.Size = New System.Drawing.Size(85, 51)
        Me.AddContactToolStripDropDownButton.Text = "Add contact"
        Me.AddContactToolStripDropDownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'AddEmailContactToolStripMenuItem
        '
        Me.AddEmailContactToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.email_32
        Me.AddEmailContactToolStripMenuItem.Name = "AddEmailContactToolStripMenuItem"
        Me.AddEmailContactToolStripMenuItem.Size = New System.Drawing.Size(187, 38)
        Me.AddEmailContactToolStripMenuItem.Text = "Add email contact"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(6, 54)
        '
        'SendReceiveToolStripSplitButton
        '
        Me.SendReceiveToolStripSplitButton.DropDownButtonWidth = 40
        Me.SendReceiveToolStripSplitButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SendReceiveAllAccountsToolStripMenuItem, Me.ToolStripSeparator17, Me.SendReceiveTrulyMailToolStripMenuItem})
        Me.SendReceiveToolStripSplitButton.Image = CType(resources.GetObject("SendReceiveToolStripSplitButton.Image"), System.Drawing.Image)
        Me.SendReceiveToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.White
        Me.SendReceiveToolStripSplitButton.Name = "SendReceiveToolStripSplitButton"
        Me.SendReceiveToolStripSplitButton.Size = New System.Drawing.Size(134, 51)
        Me.SendReceiveToolStripSplitButton.Text = "Send && Receive"
        Me.SendReceiveToolStripSplitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'SendReceiveAllAccountsToolStripMenuItem
        '
        Me.SendReceiveAllAccountsToolStripMenuItem.Image = CType(resources.GetObject("SendReceiveAllAccountsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SendReceiveAllAccountsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.SendReceiveAllAccountsToolStripMenuItem.Name = "SendReceiveAllAccountsToolStripMenuItem"
        Me.SendReceiveAllAccountsToolStripMenuItem.Size = New System.Drawing.Size(155, 38)
        Me.SendReceiveAllAccountsToolStripMenuItem.Text = "All accounts"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(152, 6)
        '
        'SendReceiveTrulyMailToolStripMenuItem
        '
        Me.SendReceiveTrulyMailToolStripMenuItem.Image = CType(resources.GetObject("SendReceiveTrulyMailToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SendReceiveTrulyMailToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.SendReceiveTrulyMailToolStripMenuItem.Name = "SendReceiveTrulyMailToolStripMenuItem"
        Me.SendReceiveTrulyMailToolStripMenuItem.Size = New System.Drawing.Size(155, 38)
        Me.SendReceiveTrulyMailToolStripMenuItem.Text = "TrulyMail"
        Me.SendReceiveTrulyMailToolStripMenuItem.Visible = False
        '
        'StopProcessingToolStripButton
        '
        Me.StopProcessingToolStripButton.Enabled = False
        Me.StopProcessingToolStripButton.Image = CType(resources.GetObject("StopProcessingToolStripButton.Image"), System.Drawing.Image)
        Me.StopProcessingToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.StopProcessingToolStripButton.Name = "StopProcessingToolStripButton"
        Me.StopProcessingToolStripButton.Size = New System.Drawing.Size(36, 51)
        Me.StopProcessingToolStripButton.Text = "Stop"
        Me.StopProcessingToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 54)
        '
        'AddressBookToolStripButton
        '
        Me.AddressBookToolStripButton.Image = CType(resources.GetObject("AddressBookToolStripButton.Image"), System.Drawing.Image)
        Me.AddressBookToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.AddressBookToolStripButton.Name = "AddressBookToolStripButton"
        Me.AddressBookToolStripButton.Size = New System.Drawing.Size(83, 51)
        Me.AddressBookToolStripButton.Text = "Address book"
        Me.AddressBookToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'DeleteToolStripButton
        '
        Me.DeleteToolStripButton.Image = CType(resources.GetObject("DeleteToolStripButton.Image"), System.Drawing.Image)
        Me.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.DeleteToolStripButton.Name = "DeleteToolStripButton"
        Me.DeleteToolStripButton.Size = New System.Drawing.Size(44, 51)
        Me.DeleteToolStripButton.Text = "Delete"
        Me.DeleteToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 54)
        '
        'ReplyToolStripButton
        '
        Me.ReplyToolStripButton.Enabled = False
        Me.ReplyToolStripButton.Image = CType(resources.GetObject("ReplyToolStripButton.Image"), System.Drawing.Image)
        Me.ReplyToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.ReplyToolStripButton.Name = "ReplyToolStripButton"
        Me.ReplyToolStripButton.Size = New System.Drawing.Size(40, 51)
        Me.ReplyToolStripButton.Text = "Reply"
        Me.ReplyToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ReplyToolStripButton.ToolTipText = "Reply"
        '
        'ReplyToAllToolStripButton
        '
        Me.ReplyToAllToolStripButton.Enabled = False
        Me.ReplyToAllToolStripButton.Image = CType(resources.GetObject("ReplyToAllToolStripButton.Image"), System.Drawing.Image)
        Me.ReplyToAllToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.ReplyToAllToolStripButton.Name = "ReplyToAllToolStripButton"
        Me.ReplyToAllToolStripButton.Size = New System.Drawing.Size(71, 51)
        Me.ReplyToAllToolStripButton.Text = "Reply to All"
        Me.ReplyToAllToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ReplyToAllToolStripButton.ToolTipText = "Reply to All"
        '
        'ForwardToolStripButton
        '
        Me.ForwardToolStripButton.Enabled = False
        Me.ForwardToolStripButton.Image = CType(resources.GetObject("ForwardToolStripButton.Image"), System.Drawing.Image)
        Me.ForwardToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.ForwardToolStripButton.Name = "ForwardToolStripButton"
        Me.ForwardToolStripButton.Size = New System.Drawing.Size(54, 51)
        Me.ForwardToolStripButton.Text = "Forward"
        Me.ForwardToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ForwardToolStripButton.ToolTipText = "Forward"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 54)
        '
        'ShowContactListToolStripButton
        '
        Me.ShowContactListToolStripButton.Checked = True
        Me.ShowContactListToolStripButton.CheckOnClick = True
        Me.ShowContactListToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowContactListToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.Text_32
        Me.ShowContactListToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ShowContactListToolStripButton.Name = "ShowContactListToolStripButton"
        Me.ShowContactListToolStripButton.Size = New System.Drawing.Size(71, 51)
        Me.ShowContactListToolStripButton.Text = "Contact list"
        Me.ShowContactListToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 54)
        '
        'MessageHighlightToolStripDropDownButton
        '
        Me.MessageHighlightToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MessageHighlightNothingToolStripMenuItem, Me.MessageHighlightSenderToolStripMenuItem, Me.MessageHighlightSubjectToolStripMenuItem})
        Me.MessageHighlightToolStripDropDownButton.Image = CType(resources.GetObject("MessageHighlightToolStripDropDownButton.Image"), System.Drawing.Image)
        Me.MessageHighlightToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MessageHighlightToolStripDropDownButton.Name = "MessageHighlightToolStripDropDownButton"
        Me.MessageHighlightToolStripDropDownButton.Size = New System.Drawing.Size(70, 51)
        Me.MessageHighlightToolStripDropDownButton.Text = "Highlight"
        Me.MessageHighlightToolStripDropDownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MessageHighlightNothingToolStripMenuItem
        '
        Me.MessageHighlightNothingToolStripMenuItem.AutoToolTip = True
        Me.MessageHighlightNothingToolStripMenuItem.Name = "MessageHighlightNothingToolStripMenuItem"
        Me.MessageHighlightNothingToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.MessageHighlightNothingToolStripMenuItem.Text = "No highlight"
        '
        'MessageHighlightSenderToolStripMenuItem
        '
        Me.MessageHighlightSenderToolStripMenuItem.AutoToolTip = True
        Me.MessageHighlightSenderToolStripMenuItem.Name = "MessageHighlightSenderToolStripMenuItem"
        Me.MessageHighlightSenderToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.MessageHighlightSenderToolStripMenuItem.Text = "Highlight sender"
        '
        'MessageHighlightSubjectToolStripMenuItem
        '
        Me.MessageHighlightSubjectToolStripMenuItem.AutoToolTip = True
        Me.MessageHighlightSubjectToolStripMenuItem.Name = "MessageHighlightSubjectToolStripMenuItem"
        Me.MessageHighlightSubjectToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.MessageHighlightSubjectToolStripMenuItem.Text = "Highlight subject"
        '
        'tmrSendReceive
        '
        Me.tmrSendReceive.Interval = 1000
        '
        'ctxmnuTree
        '
        Me.ctxmnuTree.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuTree.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewSubfolderToolStripMenuItem, Me.MoveFolderToRootToolStripMenuItem, Me.DeleteFolderToolStripMenuItem, Me.RenameFolderToolStripMenuItem, Me.MarkFolderReadToolStripMenuItem, Me.ChangeFolderColorToolStripMenuItem, Me.RefreshFolderToolStripMenuItem, Me.EmptyTrashToolStripMenuItem})
        Me.ctxmnuTree.Name = "ContextMenuStrip1"
        Me.ctxmnuTree.Size = New System.Drawing.Size(184, 180)
        '
        'NewSubfolderToolStripMenuItem
        '
        Me.NewSubfolderToolStripMenuItem.Name = "NewSubfolderToolStripMenuItem"
        Me.NewSubfolderToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.NewSubfolderToolStripMenuItem.Text = "&New Subfolder"
        Me.NewSubfolderToolStripMenuItem.ToolTipText = "Create a new folder under the selected folder"
        '
        'MoveFolderToRootToolStripMenuItem
        '
        Me.MoveFolderToRootToolStripMenuItem.Image = CType(resources.GetObject("MoveFolderToRootToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MoveFolderToRootToolStripMenuItem.Name = "MoveFolderToRootToolStripMenuItem"
        Me.MoveFolderToRootToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.MoveFolderToRootToolStripMenuItem.Text = "&Move Folder to Root"
        Me.MoveFolderToRootToolStripMenuItem.ToolTipText = "Move the selected folder so it is no longer under any other folder"
        '
        'DeleteFolderToolStripMenuItem
        '
        Me.DeleteFolderToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.DeleteFolderToolStripMenuItem.Name = "DeleteFolderToolStripMenuItem"
        Me.DeleteFolderToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.DeleteFolderToolStripMenuItem.Text = "&Delete Folder"
        Me.DeleteFolderToolStripMenuItem.ToolTipText = "Remove this folder"
        '
        'RenameFolderToolStripMenuItem
        '
        Me.RenameFolderToolStripMenuItem.Name = "RenameFolderToolStripMenuItem"
        Me.RenameFolderToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.RenameFolderToolStripMenuItem.Text = "&Rename Folder"
        Me.RenameFolderToolStripMenuItem.ToolTipText = "Edit the name of this folder"
        '
        'MarkFolderReadToolStripMenuItem
        '
        Me.MarkFolderReadToolStripMenuItem.Name = "MarkFolderReadToolStripMenuItem"
        Me.MarkFolderReadToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.MarkFolderReadToolStripMenuItem.Text = "Mark &Folder Read"
        Me.MarkFolderReadToolStripMenuItem.ToolTipText = "Change every message in this folder to be marked as read"
        '
        'ChangeFolderColorToolStripMenuItem
        '
        Me.ChangeFolderColorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeFolderColorBlueToolStripMenuItem, Me.ChangeFolderColorGreenToolStripMenuItem, Me.ChangeFolderColorYellowToolStripMenuItem, Me.ChangeFolderColorOrangeToolStripMenuItem, Me.ChangeFolderColorRedToolStripMenuItem, Me.ChangeFolderColorPurpleToolStripMenuItem})
        Me.ChangeFolderColorToolStripMenuItem.Name = "ChangeFolderColorToolStripMenuItem"
        Me.ChangeFolderColorToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ChangeFolderColorToolStripMenuItem.Text = "&Change Folder Color"
        '
        'ChangeFolderColorBlueToolStripMenuItem
        '
        Me.ChangeFolderColorBlueToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.folder_closed_blue_24
        Me.ChangeFolderColorBlueToolStripMenuItem.Name = "ChangeFolderColorBlueToolStripMenuItem"
        Me.ChangeFolderColorBlueToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ChangeFolderColorBlueToolStripMenuItem.Text = "&Blue"
        '
        'ChangeFolderColorGreenToolStripMenuItem
        '
        Me.ChangeFolderColorGreenToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.folder_closed_green_24
        Me.ChangeFolderColorGreenToolStripMenuItem.Name = "ChangeFolderColorGreenToolStripMenuItem"
        Me.ChangeFolderColorGreenToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ChangeFolderColorGreenToolStripMenuItem.Text = "&Green"
        '
        'ChangeFolderColorYellowToolStripMenuItem
        '
        Me.ChangeFolderColorYellowToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.folder_closed_yellow_24
        Me.ChangeFolderColorYellowToolStripMenuItem.Name = "ChangeFolderColorYellowToolStripMenuItem"
        Me.ChangeFolderColorYellowToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ChangeFolderColorYellowToolStripMenuItem.Text = "&Yellow"
        '
        'ChangeFolderColorOrangeToolStripMenuItem
        '
        Me.ChangeFolderColorOrangeToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.folder_closed_orange_24
        Me.ChangeFolderColorOrangeToolStripMenuItem.Name = "ChangeFolderColorOrangeToolStripMenuItem"
        Me.ChangeFolderColorOrangeToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ChangeFolderColorOrangeToolStripMenuItem.Text = "&Orange"
        '
        'ChangeFolderColorRedToolStripMenuItem
        '
        Me.ChangeFolderColorRedToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.folder_closed_red_24
        Me.ChangeFolderColorRedToolStripMenuItem.Name = "ChangeFolderColorRedToolStripMenuItem"
        Me.ChangeFolderColorRedToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ChangeFolderColorRedToolStripMenuItem.Text = "&Red"
        '
        'ChangeFolderColorPurpleToolStripMenuItem
        '
        Me.ChangeFolderColorPurpleToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.folder_closed_purple_24
        Me.ChangeFolderColorPurpleToolStripMenuItem.Name = "ChangeFolderColorPurpleToolStripMenuItem"
        Me.ChangeFolderColorPurpleToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ChangeFolderColorPurpleToolStripMenuItem.Text = "&Purple"
        '
        'RefreshFolderToolStripMenuItem
        '
        Me.RefreshFolderToolStripMenuItem.Name = "RefreshFolderToolStripMenuItem"
        Me.RefreshFolderToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.RefreshFolderToolStripMenuItem.Text = "Refres&h Folder"
        '
        'EmptyTrashToolStripMenuItem
        '
        Me.EmptyTrashToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Emptytrashcan_16
        Me.EmptyTrashToolStripMenuItem.Name = "EmptyTrashToolStripMenuItem"
        Me.EmptyTrashToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.EmptyTrashToolStripMenuItem.Text = "&Empty Trash"
        Me.EmptyTrashToolStripMenuItem.ToolTipText = "Remove all items from the trash"
        '
        'StatusLabel1
        '
        Me.StatusLabel1.Name = "StatusLabel1"
        Me.StatusLabel1.Size = New System.Drawing.Size(476, 17)
        Me.StatusLabel1.Spring = True
        Me.StatusLabel1.Text = "Message size: 0 bytes"
        Me.StatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusProgressBar
        '
        Me.StatusProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StatusProgressBar.Name = "StatusProgressBar"
        Me.StatusProgressBar.Size = New System.Drawing.Size(200, 16)
        Me.StatusProgressBar.Visible = False
        '
        'bgwReceive
        '
        '
        'ctxmnuMessage
        '
        Me.ctxmnuMessage.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuMessage.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.FilterSenderToolStripMenuItem, Me.FilterSubjectToolStripMenuItem1, Me.ToolStripSeparator8, Me.AddNotesToolStripMenuItem, Me.MoveToolStripMenuItem, Me.ToolStripSeparator28, Me.MarkReadToolStripMenuItem, Me.MarkUnreadToolStripMenuItem, Me.ToolStripSeparator6, Me.CreateReminderFromMessageToolStripMenuItem, Me.CreateProcessingRuleFromMessageToolStripMenuItem, Me.ToolStripSeparator31, Me.SendNowToolStripMenuItem, Me.DelaySendingFor1HourToolStripMenuItem, Me.ReplyToolStripMenuItem, Me.ReplyToAllToolStripMenuItem, Me.ForwardToolStripMenuItem, Me.ToolStripSeparator7, Me.DeleteToolStripMenuItem})
        Me.ctxmnuMessage.Name = "ContextMenuStrip1"
        Me.ctxmnuMessage.Size = New System.Drawing.Size(273, 364)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'FilterSenderToolStripMenuItem
        '
        Me.FilterSenderToolStripMenuItem.Name = "FilterSenderToolStripMenuItem"
        Me.FilterSenderToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.FilterSenderToolStripMenuItem.Text = "Filter"
        '
        'FilterSubjectToolStripMenuItem1
        '
        Me.FilterSubjectToolStripMenuItem1.Name = "FilterSubjectToolStripMenuItem1"
        Me.FilterSubjectToolStripMenuItem1.Size = New System.Drawing.Size(272, 22)
        Me.FilterSubjectToolStripMenuItem1.Text = "Filter"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(269, 6)
        '
        'AddNotesToolStripMenuItem
        '
        Me.AddNotesToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Note_16
        Me.AddNotesToolStripMenuItem.Name = "AddNotesToolStripMenuItem"
        Me.AddNotesToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.AddNotesToolStripMenuItem.Text = "Add &Notes"
        '
        'MoveToolStripMenuItem
        '
        Me.MoveToolStripMenuItem.Name = "MoveToolStripMenuItem"
        Me.MoveToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.MoveToolStripMenuItem.Text = "&Move..."
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        Me.ToolStripSeparator28.Size = New System.Drawing.Size(269, 6)
        '
        'MarkReadToolStripMenuItem
        '
        Me.MarkReadToolStripMenuItem.Name = "MarkReadToolStripMenuItem"
        Me.MarkReadToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.MarkReadToolStripMenuItem.Text = "Mark &Read"
        '
        'MarkUnreadToolStripMenuItem
        '
        Me.MarkUnreadToolStripMenuItem.Name = "MarkUnreadToolStripMenuItem"
        Me.MarkUnreadToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.MarkUnreadToolStripMenuItem.Text = "Mark &Unread"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(269, 6)
        '
        'CreateReminderFromMessageToolStripMenuItem
        '
        Me.CreateReminderFromMessageToolStripMenuItem.Name = "CreateReminderFromMessageToolStripMenuItem"
        Me.CreateReminderFromMessageToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.CreateReminderFromMessageToolStripMenuItem.Text = "Create Reminder from Message"
        '
        'CreateProcessingRuleFromMessageToolStripMenuItem
        '
        Me.CreateProcessingRuleFromMessageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MatchingSenderToolStripMenuItem1, Me.MatchingSubjectToolStripMenuItem1})
        Me.CreateProcessingRuleFromMessageToolStripMenuItem.Name = "CreateProcessingRuleFromMessageToolStripMenuItem"
        Me.CreateProcessingRuleFromMessageToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.CreateProcessingRuleFromMessageToolStripMenuItem.Text = "Create Processing Rule from Message"
        '
        'MatchingSenderToolStripMenuItem1
        '
        Me.MatchingSenderToolStripMenuItem1.Name = "MatchingSenderToolStripMenuItem1"
        Me.MatchingSenderToolStripMenuItem1.Size = New System.Drawing.Size(166, 22)
        Me.MatchingSenderToolStripMenuItem1.Text = "Matching sender"
        '
        'MatchingSubjectToolStripMenuItem1
        '
        Me.MatchingSubjectToolStripMenuItem1.Name = "MatchingSubjectToolStripMenuItem1"
        Me.MatchingSubjectToolStripMenuItem1.Size = New System.Drawing.Size(166, 22)
        Me.MatchingSubjectToolStripMenuItem1.Text = "Matching subject"
        '
        'ToolStripSeparator31
        '
        Me.ToolStripSeparator31.Name = "ToolStripSeparator31"
        Me.ToolStripSeparator31.Size = New System.Drawing.Size(269, 6)
        '
        'SendNowToolStripMenuItem
        '
        Me.SendNowToolStripMenuItem.Name = "SendNowToolStripMenuItem"
        Me.SendNowToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.SendNowToolStripMenuItem.Text = "&Send Now"
        '
        'DelaySendingFor1HourToolStripMenuItem
        '
        Me.DelaySendingFor1HourToolStripMenuItem.Name = "DelaySendingFor1HourToolStripMenuItem"
        Me.DelaySendingFor1HourToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.DelaySendingFor1HourToolStripMenuItem.Text = "Delay sending for 1 hour"
        '
        'ReplyToolStripMenuItem
        '
        Me.ReplyToolStripMenuItem.Image = CType(resources.GetObject("ReplyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReplyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ReplyToolStripMenuItem.Name = "ReplyToolStripMenuItem"
        Me.ReplyToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.ReplyToolStripMenuItem.Text = "Reply to &Sender"
        '
        'ReplyToAllToolStripMenuItem
        '
        Me.ReplyToAllToolStripMenuItem.Image = CType(resources.GetObject("ReplyToAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReplyToAllToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ReplyToAllToolStripMenuItem.Name = "ReplyToAllToolStripMenuItem"
        Me.ReplyToAllToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.ReplyToAllToolStripMenuItem.Text = "Reply to &All"
        '
        'ForwardToolStripMenuItem
        '
        Me.ForwardToolStripMenuItem.Image = CType(resources.GetObject("ForwardToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ForwardToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ForwardToolStripMenuItem.Name = "ForwardToolStripMenuItem"
        Me.ForwardToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.ForwardToolStripMenuItem.Text = "&Forward"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(269, 6)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(272, 22)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        '
        'tmrInvokeNextRoutine
        '
        Me.tmrInvokeNextRoutine.Interval = 500
        '
        'bgwDownloadPOP
        '
        '
        'bgwCheckAllEmail
        '
        '
        'tmrAutoEmptyTrash
        '
        Me.tmrAutoEmptyTrash.Interval = 300000.0R
        Me.tmrAutoEmptyTrash.SynchronizingObject = Me
        '
        'bgwAutoEmptyTrash
        '
        '
        'tmrRefreshCurrentFolder
        '
        Me.tmrRefreshCurrentFolder.Enabled = True
        Me.tmrRefreshCurrentFolder.Interval = 670
        '
        'ctxmnuColumnSelector
        '
        Me.ctxmnuColumnSelector.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuColumnSelector.Name = "ctxmnuColumnSelector"
        Me.ctxmnuColumnSelector.Size = New System.Drawing.Size(61, 4)
        '
        'bgwStartupBatchBackgroundStuff
        '
        '
        'tmrNotifyMessagesReceived
        '
        Me.tmrNotifyMessagesReceived.Interval = 9000
        '
        'bgwDownloadRSS
        '
        '
        'tmrFolderExpand
        '
        Me.tmrFolderExpand.Interval = 1000
        '
        'tmrSelectedMessageChanged
        '
        Me.tmrSelectedMessageChanged.Interval = 200
        '
        'ctxmnuFilter
        '
        Me.ctxmnuFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuFilter.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FilterOnlyUnreadToolStripMenuItem, Me.FilterOnlyReadToolStripMenuItem, Me.ToolStripSeparator29, Me.FilterOnlyTodayToolStripMenuItem, Me.FilterOnlyLast2DaysToolStripMenuItem, Me.FilterOnlyThisWeekToolStripMenuItem, Me.FilterMoreThanOneWeekToolStripMenuItem, Me.FilterMoreThanOneMonthToolStripMenuItem, Me.FilterMoreThanThreeMonthsToolStripMenuItem, Me.FilterMoreThanSixMonthsToolStripMenuItem, Me.ToolStripSeparator30, Me.FilterClearAllFiltersToolStripMenuItem})
        Me.ctxmnuFilter.Name = "ContextMenuStrip1"
        Me.ctxmnuFilter.Size = New System.Drawing.Size(204, 236)
        '
        'FilterOnlyUnreadToolStripMenuItem
        '
        Me.FilterOnlyUnreadToolStripMenuItem.Name = "FilterOnlyUnreadToolStripMenuItem"
        Me.FilterOnlyUnreadToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.FilterOnlyUnreadToolStripMenuItem.Text = "Only unread"
        '
        'FilterOnlyReadToolStripMenuItem
        '
        Me.FilterOnlyReadToolStripMenuItem.Name = "FilterOnlyReadToolStripMenuItem"
        Me.FilterOnlyReadToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.FilterOnlyReadToolStripMenuItem.Text = "Only read"
        '
        'ToolStripSeparator29
        '
        Me.ToolStripSeparator29.Name = "ToolStripSeparator29"
        Me.ToolStripSeparator29.Size = New System.Drawing.Size(200, 6)
        '
        'FilterOnlyTodayToolStripMenuItem
        '
        Me.FilterOnlyTodayToolStripMenuItem.Name = "FilterOnlyTodayToolStripMenuItem"
        Me.FilterOnlyTodayToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.FilterOnlyTodayToolStripMenuItem.Text = "Only today"
        '
        'FilterOnlyLast2DaysToolStripMenuItem
        '
        Me.FilterOnlyLast2DaysToolStripMenuItem.Name = "FilterOnlyLast2DaysToolStripMenuItem"
        Me.FilterOnlyLast2DaysToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.FilterOnlyLast2DaysToolStripMenuItem.Text = "Only last two days"
        '
        'FilterOnlyThisWeekToolStripMenuItem
        '
        Me.FilterOnlyThisWeekToolStripMenuItem.Name = "FilterOnlyThisWeekToolStripMenuItem"
        Me.FilterOnlyThisWeekToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.FilterOnlyThisWeekToolStripMenuItem.Text = "Only this week"
        '
        'FilterMoreThanOneWeekToolStripMenuItem
        '
        Me.FilterMoreThanOneWeekToolStripMenuItem.Name = "FilterMoreThanOneWeekToolStripMenuItem"
        Me.FilterMoreThanOneWeekToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.FilterMoreThanOneWeekToolStripMenuItem.Text = "More than one week"
        '
        'FilterMoreThanOneMonthToolStripMenuItem
        '
        Me.FilterMoreThanOneMonthToolStripMenuItem.Name = "FilterMoreThanOneMonthToolStripMenuItem"
        Me.FilterMoreThanOneMonthToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.FilterMoreThanOneMonthToolStripMenuItem.Text = "More than one month"
        '
        'FilterMoreThanThreeMonthsToolStripMenuItem
        '
        Me.FilterMoreThanThreeMonthsToolStripMenuItem.Name = "FilterMoreThanThreeMonthsToolStripMenuItem"
        Me.FilterMoreThanThreeMonthsToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.FilterMoreThanThreeMonthsToolStripMenuItem.Text = "More than three months"
        '
        'FilterMoreThanSixMonthsToolStripMenuItem
        '
        Me.FilterMoreThanSixMonthsToolStripMenuItem.Name = "FilterMoreThanSixMonthsToolStripMenuItem"
        Me.FilterMoreThanSixMonthsToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.FilterMoreThanSixMonthsToolStripMenuItem.Text = "More than six months"
        '
        'ToolStripSeparator30
        '
        Me.ToolStripSeparator30.Name = "ToolStripSeparator30"
        Me.ToolStripSeparator30.Size = New System.Drawing.Size(200, 6)
        '
        'FilterClearAllFiltersToolStripMenuItem
        '
        Me.FilterClearAllFiltersToolStripMenuItem.Name = "FilterClearAllFiltersToolStripMenuItem"
        Me.FilterClearAllFiltersToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.FilterClearAllFiltersToolStripMenuItem.Text = "Clear all filters"
        '
        'tmrFilterMessages
        '
        Me.tmrFilterMessages.Interval = 400.0R
        Me.tmrFilterMessages.SynchronizingObject = Me
        '
        'ctxmnuQuickJump
        '
        Me.ctxmnuQuickJump.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuQuickJump.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveEntryToolStripMenuItem})
        Me.ctxmnuQuickJump.Name = "ctxmnuColumnSelector"
        Me.ctxmnuQuickJump.Size = New System.Drawing.Size(148, 26)
        '
        'RemoveEntryToolStripMenuItem
        '
        Me.RemoveEntryToolStripMenuItem.Name = "RemoveEntryToolStripMenuItem"
        Me.RemoveEntryToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.RemoveEntryToolStripMenuItem.Text = "Remove entry"
        Me.RemoveEntryToolStripMenuItem.ToolTipText = "Remove this entry from the list"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'OpenAsplainTextToolStripMenuItem
        '
        Me.OpenAsplainTextToolStripMenuItem.Name = "OpenAsplainTextToolStripMenuItem"
        Me.OpenAsplainTextToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.OpenAsplainTextToolStripMenuItem.Text = "Open as &plain text"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1124, 615)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "MainForm"
        Me.Text = "TrulyMail"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainerAddressBook.Panel1.ResumeLayout(False)
        Me.SplitContainerAddressBook.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerAddressBook, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerAddressBook.ResumeLayout(False)
        CType(Me.pnlTreeViewQuickJump, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTreeViewQuickJump.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.olvMessages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlMessageFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMessageFilter.ResumeLayout(False)
        Me.pnlMessageFilter.PerformLayout()
        CType(Me.pbClearTags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddTag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ctxmnuTree.ResumeLayout(False)
        Me.ctxmnuMessage.ResumeLayout(False)
        CType(Me.tmrAutoEmptyTrash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmnuFilter.ResumeLayout(False)
        CType(Me.tmrFilterMessages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmnuQuickJump.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutTrulyMailClientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddressBookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents SendUnsentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents WriteMessageToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AddressBookToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeleteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SendAndReceiveAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tmrSendReceive As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxmnuTree As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewSubfolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmptyTrashToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents StopProcessingToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents bgwReceive As System.ComponentModel.BackgroundWorker
    Friend WithEvents ctxmnuMessage As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MarkReadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkUnreadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReplyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReplyToAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ForwardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ReplyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ReplyToAllToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ForwardToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SubmitLogFileToServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tmrInvokeNextRoutine As System.Windows.Forms.Timer
    Friend WithEvents ImglstMessageStatus As System.Windows.Forms.ImageList
    Friend WithEvents EmailAccountsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bgwDownloadPOP As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bgwCheckAllEmail As System.ComponentModel.BackgroundWorker
    Friend WithEvents SendReceiveToolStripSplitButton As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents SendReceiveAllAccountsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CreateChangeMasterPasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MarkMessageReadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkMessageUnreadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnreadMessagesStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TotalMessagesStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrAutoEmptyTrash As System.Timers.Timer
    Friend WithEvents bgwAutoEmptyTrash As System.ComponentModel.BackgroundWorker
    Friend WithEvents EmptyTrashToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewMessageToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrRefreshCurrentFolder As System.Windows.Forms.Timer
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessagePreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessagePreviewNoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessagePreviewVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessagePreviewHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TreatAsReadReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNotesToMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MoveToToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeSubjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewMessageHeadersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FolderTreeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents llblOpenSelectedMessages As System.Windows.Forms.LinkLabel
    Friend WithEvents MessageFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageListColumnSelectorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxmnuColumnSelector As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ReadMessageContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReadMessagePauseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReadMessageResumeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TestConnectionToTrulyMailServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bgwStartupBatchBackgroundStuff As System.ComponentModel.BackgroundWorker
    Friend WithEvents HeaderFormatStyleWingDings As BrightIdeasSoftware.HeaderFormatStyle
    Friend WithEvents tmrNotifyMessagesReceived As System.Windows.Forms.Timer
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents FilterMessageCountToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FindInMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkFolderReadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator27 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MessageProcessingRulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterSenderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterSubjectToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageDictionariesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageSignaturesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNotesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator28 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bgwDownloadRSS As System.ComponentModel.BackgroundWorker
    Friend WithEvents ImportExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeFolderColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeFolderColorYellowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeFolderColorGreenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeFolderColorBlueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeFolderColorPurpleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeFolderColorRedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeFolderColorOrangeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportMessagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrFolderExpand As System.Windows.Forms.Timer
    Friend WithEvents tmrSelectedMessageChanged As System.Windows.Forms.Timer
    Friend WithEvents MoveFolderToRootToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxmnuFilter As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FilterOnlyUnreadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterOnlyReadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator29 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FilterOnlyTodayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterOnlyLast2DaysToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterOnlyThisWeekToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterMoreThanOneWeekToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterMoreThanOneMonthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator30 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FilterClearAllFiltersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FeedsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RSSAndBlogFeedsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrFilterMessages As System.Timers.Timer
    Friend WithEvents AddContactToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents AddEmailContactToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowContactListToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ShowContactListAreaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageHighlightToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents MessageHighlightNothingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageHighlightSenderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageHighlightSubjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageHighlightToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageHighlightNoHighlightToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageHighlightHighlightSenderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageHighlightHighlightsubjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveDuplicateMessagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowReplyModesInPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewProcessingRuleFromMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MatchingSenderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MatchingSubjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateReminderFromMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateProcessingRuleFromMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MatchingSenderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MatchingSubjectToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator31 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SendNowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LimitEmailDownloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FindOrphanedAttachmentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageDoNotSendListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterMoreThanThreeMonthsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterMoreThanSixMonthsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtractAttachementsFromSelectedMessagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DelaySendingFor1HourToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GeneragePrivacyCodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewReceiveMessageLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxmnuQuickJump As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoveEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddSelectedFolderToQuickJumpListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReplyOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReplyToSenderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReplyMessageToAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ForwardMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FollowUpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SendReturnReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ScheduleMessagesInOutboxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainerAddressBook As System.Windows.Forms.SplitContainer
    Friend WithEvents tvFolders As System.Windows.Forms.TreeView
    Friend WithEvents pnlTreeViewQuickJump As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents tblLayoutTreeViewQuickJumps As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ContactSelector1 As TrulyMail.ContactSelectorPlain
    Friend WithEvents olvMessages As BrightIdeasSoftware.ObjectListView
    Friend WithEvents olvColumnSubject As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnAttachments As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnOtherParties As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnMessageDateSent As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnSize As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnReceived As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnViewed As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnTransportType As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnHasNotes As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnTags As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnImportance As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvcolReadButton As BrightIdeasSoftware.OLVColumn
    Friend WithEvents pnlMessageFilter As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents llblFilter As System.Windows.Forms.LinkLabel
    Friend WithEvents txtMessageFilter As System.Windows.Forms.TextBox
    Friend WithEvents btnClearMessageFilter As System.Windows.Forms.Button
    Friend WithEvents pbClearTags As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboMessageTags As System.Windows.Forms.ComboBox
    Friend WithEvents pbAddTag As System.Windows.Forms.PictureBox
    Friend WithEvents SendReceiveTrulyMailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageHTMLsourceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshFolderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearFiltersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterMatchOtherPartyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterMatchSubjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents WithoutEmbeddedImagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WithEmbeddedImagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetSentDateToTodayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DarkModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterContactsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents SelectTopMessageInListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenAsplainTextToolStripMenuItem As ToolStripMenuItem
End Class
