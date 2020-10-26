Imports TrulyMail.Controls
Imports BrightIdeasSoftware

#Const BUILD_WITH_EXTRA_LOGGING = False

Public Class MainForm

    Private m_currentlySelectedNode As TreeNode

    Private m_nodeInBox As TreeNode
    Private m_nodeOutBox As TreeNode
    Private m_nodeTrash As TreeNode
    Private m_nodeSent As TreeNode
    Private m_nodeDrafts As TreeNode
    Private m_SortingColumn As ColumnHeader '-- column current used for sorting listview
    Private m_boolLabelEditingAllowed As Boolean = False
    Private m_boolStopProcessing As Boolean
    Private m_boolGetReceipts As Boolean
    Private m_boolGetMessages As Boolean
    Private m_boolGetRSSArticles As Boolean
    Private m_boolGetAllEmail As Boolean
    Private m_boolSendMessages As Boolean
    Private WithEvents m_msgTransmitter As MessageTransmitter
    Private m_intNextUnsentToSend As Integer
    Private m_boolAutoSendUnsent As Boolean
    Private m_routineToCallAfterSendingUnsent As NoParamSubDelegate
    Private m_checkTypeEmail As EmailCheckingEnum

    Private m_dtTrulyMailLastChecked As Date = Date.Now
    Private m_strTrulyMailLastCheckedForDisplay As String = String.Empty
    Private m_dtRSSLastChecked As Date = Date.Now
    Private m_strRSSLastCheckedForDisplay As String = String.Empty

    Private m_lstTreeNodesToAddUnreadCountOnBackgroundThread As New List(Of TreeNode)
    Private WithEvents m_bgAddUnreadCountToTreeNodes As New System.ComponentModel.BackgroundWorker

    Private m_lstInBoxesToUpdate As New List(Of TreeNode) '-- POP inboxes to update when receiving new messages
    Private m_intSelectedMessage As Integer
    Private WithEvents m_tmrLazyUnreadUpdater As New Timers.Timer(1000)
    Private m_lstPathsToUpdate As New List(Of TreeNode) '-- for lazy updating of unread count

    Private m_boolPreventLoadingPreview As Boolean
    Private m_bytMessageListStateOriginal() As Byte
    Private m_previousWindowState As FormWindowState
    Private m_intMessageReceivedToNotifyUser As Integer


    Private m_notifier As MontgomerySoftware.Controls.TaskbarNotifier = New NewMessageNotifier()
    Private WithEvents m_notifier2 As NewMessageNotifier = CType(m_notifier, NewMessageNotifier) '-- interface for clicked event

    Private m_boolFormFullyLoaded As Boolean
    Private m_messageToRefresh As TrulyMailMessage '-- We only keep one because this process happens so fast it is unlikely we would need more than one
    Private WithEvents m_tmrFilterAutoComplete As New Windows.Forms.Timer()
    Private m_boolStillDownloadingTrulyMailMessages As Boolean '-- flag so we don't show notice while downloading TrulyMail messages
    Private WithEvents m_bgwShowUnreadOnRootNodes As System.ComponentModel.BackgroundWorker
    Private m_lstReceiveFileLog As New List(Of ReceiveFileDetails) '-- Don't persist, just keep in memory for the session

    Private ReadMessageControlRich As ReadMessageControl
    Private ReadMessageControlPlain As ReadMessage7Control
    Private m_boolUsingRichControl As Boolean

#Region " API "
    'Public Function CreateNewMessage() As NewMessage
    '    Dim frm As New NewMessage()
    '    Return frm
    'End Function
    Public Function CreateNewMessage(Optional forcePlainText As Boolean = False) As IComposeForm
        'Return NewMessage()

        Dim frm As IComposeForm
        If forcePlainText OrElse UseFallbackModeNow() Then
            frm = New NewMessageSimple()
            CType(frm, Form).Show()
            Return frm
        Else
            frm = New NewMessage()
            CType(frm, Form).Show()
            Return frm
        End If
    End Function

#End Region

    Private Enum StartupBatchBackgroundProcess
        All
        BatchUpdateLastReceivedSent
    End Enum

    Public Sub New()

        '-- hack but need reference in globals to this form
        MainFormReference = Me

        LoadGlobalSettings()

        If AppSettings IsNot Nothing Then
            ' This call is required by the Windows Form Designer.
            '-- Must call after LoadGlobalSettings
            InitializeComponent()
        Else
            '-- do nothing, form_load will close app without AppSettings
        End If


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim boolWarnAboutShutDownProblems As Boolean
        Try

            SplashScreen.Show(Me)
            Application.DoEvents()

            If AppSettings Is Nothing Then
                Me.Close()
                Exit Sub
            End If

            If ModifierKeys = Keys.Shift Then
                '-- reset main windows to 0,0
                '   this was put in for TM6 after two users had problem with main form starting off the screen (not multi-monitor issue)
                AppSettings.MainWindowLocation = New Point(0, 0)
                AppSettings.MainWindowSize = New Size(800, 600)
                AppSettings.PreviewPaneToReadAsPlainText = True '--because browser might have problems (under Wine) but a text box should never have.
            End If


            boolWarnAboutShutDownProblems = Not AppSettings.ShutDownProperly
            AppSettings.ShutDownProperly = False '-- only mark true as we are closing app

            m_bytMessageListStateOriginal = olvMessages.SaveState()
            olvMessages.RestoreState(AppSettings.MessageListState)

            SetToolStripIcons(AppSettings.LargeToolbarIcons)

            SetupPreviewControl()

            SetupMenusForPOPAccountsAndRSSFeeds()

            '=========== This block used to be after Me.Show before Sept 2012 =======================
            '-- Delete all index.dat files
            If AppSettings.IndexResetDate < #6/1/2010# Then
                Dim files() As String = System.IO.Directory.GetFiles(MessageStoreRootPath, "index.dat", IO.SearchOption.AllDirectories)
                Dim intFailedDeletes As Integer
                For Each strFilename As String In files
                    Try
                        DeleteLocalFile(strFilename)
                    Catch ex As Exception
                        '-- likely could not delete because it was in use, forget it and move on
                        intFailedDeletes += 1
                        Log(ex)
                    End Try
                Next
                If intFailedDeletes = 0 Then
                    '-- let's make sure we don't do this process again
                    AppSettings.IndexResetDate = Date.Now()
                    AppSettings.Save()
                End If
                Log("Deleted index.dat files with " & intFailedDeletes & " errors.")
            End If

            LoadFolderTree()
            Me.ContactSelector1.SortByLastSent()

            If AppSettings.HideFilterAreaOnMainForm Then
                pnlMessageFilter.Visible = False
                MessageFilterToolStripMenuItem.Checked = False
            End If

            If AppSettings.FirstTimeAppIsStarted Then
                SeedInitialMessages()
                ShowCurrentFolderContents()
            End If

            Me.Show()


            '-- now, set size and position of main window
            Const MAIN_WINDOW_MIN_WIDTH As Integer = 100
            Const MAIN_WINDOW_MIN_HEIGHT As Integer = 100
            If AppSettings.MainWindowSize.Width > MAIN_WINDOW_MIN_WIDTH AndAlso AppSettings.MainWindowSize.Height > MAIN_WINDOW_MIN_HEIGHT Then
                Me.Size = AppSettings.MainWindowSize
            End If
            Me.Location = AppSettings.MainWindowLocation

            If AppSettings.MainFormWindowState <> FormWindowState.Minimized Then
                Me.WindowState = AppSettings.MainFormWindowState
            End If

            Application.DoEvents()

            ''-- Addressbook is missing?
            'If Not AddressBookExists() Then
            '    Dim frm As New AddressBookForm()
            '    SplashScreen.Hide()
            '    frm.ShowDialog() '-- wait until user downloads addressbook
            'End If

            Try
                SetMessagePreview(AppSettings.ShowMessagePreviewPane, AppSettings.MessagePreviewPaneVertical)
            Catch ex As Exception
                Log(ex) '-- log and ignore
            End Try

            If AppSettings.FolderTreeSplitter > 0 Then
                Try
                    SplitContainer1.SplitterDistance = AppSettings.FolderTreeSplitter
                Catch ex As Exception
                    '-- do nothing
                End Try
            End If

            Try
                If AppSettings.MessagePreviewPaneSize > 10 Then
                    SplitContainer3.SplitterDistance = AppSettings.MessagePreviewPaneSize
                End If
            Catch ex As Exception
                '-- do nothing
            End Try


            If AppSettings.SendAndReceiveOnStartup Then
                SendReceiveTrulyMailPlusEmail(EmailCheckingEnum.AtStartup)
            Else
                bgwCheckAllEmail.RunWorkerAsync(EmailCheckingEnum.AtStartup)
            End If

            If Command.Length > 0 Then
                RespondToLaunchWithParameters(My.Application.CommandLineArgs)
            End If

            tmrSendReceive.Interval = 60000 '-- check every minute
            tmrSendReceive.Start()

            '-- These next few lines setup catch-all exception handlers
            Dim currentDomain As AppDomain = AppDomain.CurrentDomain
            AddHandler currentDomain.UnhandledException, AddressOf MasterExceptionHandler
            AddHandler Application.ThreadException, AddressOf MasterThreadExceptionHandler

            UpdateMenuText()

            tmrAutoEmptyTrash.Enabled = AppSettings.AutoEmptyTrash
            'm_tmrShowUnreadAllRootNodes.Start()
            m_bgwShowUnreadOnRootNodes = New System.ComponentModel.BackgroundWorker()
            m_bgwShowUnreadOnRootNodes.WorkerReportsProgress = False
            m_bgwShowUnreadOnRootNodes.WorkerSupportsCancellation = False
            m_bgwShowUnreadOnRootNodes.RunWorkerAsync()

            'olvMessages.MakeColumnSelectMenu(ctxmnuColumnSelector)

            LoadMessageTags()

            '-- setup custom renderers
            Me.olvColumnReceived.Renderer = New ViewReceiveRenderer()
            Me.olvColumnViewed.Renderer = New ViewReceiveRenderer()

            Me.olvMessages.AlternateRowBackColor = AppSettings.MessageListAlternatingRowColor

            SplashScreen.Close()

            If Not AppSettings.DoNotShowAddEmailAccountNotice Then
                If AppSettings.POPProfiles.Count = 0 Then
                    Using frm As New NotifyForm("Would you like to add an email account to TrulyMail so you can send and receive email?", NotifyForm.DoNotShowSetting.DoNotShowAddEmailAccountNotice, MessageBoxButtons.YesNo)
                        If frm.ShowDialog(MainFormReference) = Windows.Forms.DialogResult.Yes Then
                            SetupEmailAccounts()
                        End If
                    End Using
                End If
            End If


            '-- run batch process to update all contact lastsent/lastreceived properties
            '   when complete, the setting will be sent to the current date and we will just generate reminders on startup
            bgwStartupBatchBackgroundStuff.RunWorkerAsync(StartupBatchBackgroundProcess.All)

            m_tmrFilterAutoComplete.Interval = 5000 '-- only add to the autocompletesource if filter typed has stayed there for a while
            txtMessageFilter.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtMessageFilter.AutoCompleteCustomSource = AppSettings.MainFormFilterAutoComplete

            If AppSettings.RSSAutoCheckAtStartup Then
                GetNewRSSArticles()
            End If

            ShowContactListArea(AppSettings.ContactListAreaVisible)

            LimitEmailDownloadToolStripMenuItem.Enabled = True
            LimitEmailDownloadToolStripMenuItem.Checked = AppSettings.EmailDownloadLimit
            FindOrphanedAttachmentsToolStripMenuItem.Enabled = True
            ManageDoNotSendListToolStripMenuItem.Enabled = True
            ExtractAttachementsFromSelectedMessagesToolStripMenuItem.Enabled = True
            GeneragePrivacyCodeToolStripMenuItem.Enabled = True
            ViewReceiveMessageLogToolStripMenuItem.Enabled = True
            AddSelectedFolderToQuickJumpListToolStripMenuItem.Enabled = True
            ScheduleMessagesInOutboxToolStripMenuItem.Enabled = True


            If boolWarnAboutShutDownProblems Then
                If Not AppSettings.DoNotShowShutDownErrorNotice Then
                    Using frm As New NotifyForm("TrulyMail looks like it was not shut down properly. Would you like to send an error report to TrulyMail?", NotifyForm.DoNotShowSetting.DoNotShowShutDownErrorNotice, MessageBoxButtons.YesNo)
                        If frm.ShowDialog(MainFormReference) = Windows.Forms.DialogResult.Yes Then
                            Using frm2 As New SendToSupport()
                                frm2.ShowDialog()
                            End Using
                        End If
                    End Using
                End If
            End If

            LoadQuickJumps()

            SetupDarkMode()


            SetStatus(STATUS_READY)
            m_boolFormFullyLoaded = True



        Catch ex As Exception
            Log(ex)
            SplashScreen.Close()
            ShowMessageBoxError("There was an error starting TrulyMail." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
            Close()
        End Try
    End Sub

    Private Sub MasterExceptionHandler(ByVal EventNumber As Integer, ByVal ExceptionText As String)
        '-- This will catch all unhandled exceptions so the users don't get an ugly 
        '   dialog asking them if they want to debug the application.
        '   Application state will be unstable so better to just close it down
        Console.WriteLine()
        Console.WriteLine(ExceptionText)
        Log("Master Exception: " & EventNumber & Environment.NewLine & "Exception Text: " & ExceptionText & Environment.NewLine & "Event Number: ")
        MessageBox.Show("There was an unexpected error in TrulyMail. Please restart the application." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE, "TrulyMail", MessageBoxButtons.OK, MessageBoxIcon.Error)

        '-- Always save crash file
        'Dim strFilename As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) & "\" & GetProductName() & "LogFiles\" & Date.Now.ToString(DATE_FILENAME_FORMAT) & ".log"
        'Diagnostics.SaveDiagnostics(strFilename, g_colChannels, ExceptionText, Me)

        Me.Close()
    End Sub
    Private Sub MasterExceptionHandler(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        Dim ex As Exception = CType(e.ExceptionObject, Exception)
        Dim dt As Date = Date.Now '-- for debugging only
        If ex.Message.StartsWith("Cannot access a disposed object.") Then
            Application.DoEvents() '-- Ignore this error
            'ElseIf ex.InnerException.Message.StartsWith("Object is currently in use elsewhere.") Then
            '    Application.DoEvents()
        Else
            Dim strInner As String = "Inner: "
            If ex.InnerException IsNot Nothing Then
                strInner &= ex.InnerException.Message & Environment.NewLine & Environment.NewLine & ex.InnerException.StackTrace
            Else
                strInner &= "<nothing>"
            End If
            MasterExceptionHandler(9000, ex.Message & Environment.NewLine & Environment.NewLine & ex.StackTrace & Environment.NewLine & Environment.NewLine & strInner & Environment.NewLine() & Environment.NewLine & "InnerEx: " & ex.InnerException.ToString())
        End If
    End Sub

    Private Sub MasterThreadExceptionHandler(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
        If e.Exception.Message.StartsWith("Cannot access a disposed object.") Then
            Application.DoEvents() '-- Ignore this error
        Else
            AppSettings.UseFallbackModeWhen = UseFallbackModeEnum.UnderWine '-- common error
            AppSettings.Save()
            MasterExceptionHandler(9100, e.Exception.ToString())
        End If
    End Sub

#Region " TreeView Logic "
    Private Function CreateTreeNode(ByVal name As String, ByVal path As String, ByVal imageIndex As Integer, ByVal selectedImageIndex As Integer) As TreeNode
        Dim tn As TreeNode
        tn = tvFolders.Nodes.Add(String.Empty, name)
        tn.Tag = path

        Dim dirInfo As New System.IO.DirectoryInfo(path)
        If Not dirInfo.Exists Then
            dirInfo.Create()
        Else
            Dim folder As FolderState = GetFolderState(dirInfo.FullName)
            If folder.Expanded Then
                AddChildrenNodes(tn)
                Application.DoEvents()
                tn.Expand()
            Else
                If dirInfo.GetDirectories.Length > 0 Then
                    AddBlankNode(tn)
                End If
            End If
        End If

        tn.ContextMenuStrip = ctxmnuTree
        tn.ImageIndex = imageIndex
        tn.SelectedImageIndex = selectedImageIndex
        Return tn
    End Function
    Private Sub LoadFolderTree()

        Me.tvFolders.Nodes.Clear()
        Dim di As New System.IO.DirectoryInfo(MessageStoreRootPath)
        Dim dis() As System.IO.DirectoryInfo = di.GetDirectories()
        Dim tn As TreeNode

        '-- Add the system folders in fixed order
        m_nodeDrafts = CreateTreeNode(DRAFTS_FOLDER_NAME, DraftsRootPath, 9, 9)
        m_nodeInBox = CreateTreeNode(INBOX_NAME, InBoxRootPath, 7, 7)
        m_nodeOutBox = CreateTreeNode(OUTBOX_NAME, OutboxRootPath, 8, 8)
        m_nodeSent = CreateTreeNode(SENTITEMS_NAME, SentItemsRootPath, 7, 7)
        m_nodeTrash = CreateTreeNode(TRASH_NAME, TrashRootPath, 5, 5)

        Dim lst As New List(Of String)

        For Each dirInfo As System.IO.DirectoryInfo In dis
            Select Case QualifyPath(dirInfo.FullName.ToLower())
                Case InBoxRootPath.ToLower
                    ShowUnreadOnNodeText(m_nodeInBox, INBOX_NAME, True)
                Case SentItemsRootPath.ToLower
                Case OutboxRootPath.ToLower
                    ShowUnreadOnNodeText(m_nodeOutBox, OUTBOX_NAME, True)
                Case TrashRootPath.ToLower
                    CheckTrashIconStatus()
                Case DraftsRootPath.ToLower
                    ShowUnreadOnNodeText(m_nodeDrafts, DRAFTS_FOLDER_NAME, True)
                Case Else
                    lst.Add(dirInfo.Name)
            End Select
        Next

        lst.Sort()
        For Each strFolderName In lst
            Dim folder As FolderState = GetFolderState(MessageStoreRootPath & strFolderName)
            Dim intFolderIcon As Integer = FOLDER_COLOR_BASE_CLOSED_INDEX + folder.Icon
            Dim intFolderSelectedIcon As Integer = FOLDER_COLOR_BASE_OPEN_INDEX + folder.Icon

            tn = CreateTreeNode(strFolderName, MessageStoreRootPath & strFolderName, intFolderIcon, intFolderSelectedIcon)
        Next

        tvFolders.SelectedNode = m_nodeInBox '-- always select inbox
        m_currentlySelectedNode = m_nodeInBox
    End Sub
    Private Sub AddBlankNode(ByVal node As TreeNode)
        node.Nodes.Add(String.Empty)
    End Sub
    Private Function AddChildNode(ByVal node As TreeNode, ByVal fullPath As String, ByVal folderIcon As Integer, ByVal folderSelectedIcon As Integer) As TreeNode
        Dim tn As TreeNode
        Dim dirInfo As New System.IO.DirectoryInfo(fullPath)
        tn = node.Nodes.Add(String.Empty, dirInfo.Name, folderIcon, folderSelectedIcon)
        tn.Tag = dirInfo.FullName

        Return tn
    End Function
    Private Delegate Sub AddChildrenNodesCallback(ByVal node As TreeNode)
    Private Sub AddChildrenNodes(ByVal node As TreeNode)
        If InvokeRequired Then
            Dim deleg As New AddChildrenNodesCallback(AddressOf AddChildrenNodes)
            Invoke(deleg, node)
        Else
            Try
                node.Nodes.Clear()
                'Dim di As New System.IO.DirectoryInfo(node.Tag.ToString())
                'Dim dis() As System.IO.DirectoryInfo = di.GetDirectories()
                Dim directories() As String = System.IO.Directory.GetDirectories(node.Tag.ToString(), "*.*", IO.SearchOption.TopDirectoryOnly)
                Dim directory As String
                Dim tn As TreeNode

                Array.Sort(directories)
                'For Each dirInfo As System.IO.DirectoryInfo In dis
                For Each directory In directories
                    'Dim folder As FolderState = GetFolderState(dirInfo.FullName)
                    Dim folder As FolderState = GetFolderState(directory)
                    Dim intFolderIcon As Integer = FOLDER_COLOR_BASE_CLOSED_INDEX + folder.Icon
                    Dim intFolderSelectedIcon As Integer = FOLDER_COLOR_BASE_OPEN_INDEX + folder.Icon

                    'tn = AddChildNode(node, dirInfo.FullName, intFolderIcon, intFolderSelectedIcon)
                    tn = AddChildNode(node, directory, intFolderIcon, intFolderSelectedIcon)
                    
                    If folder.Expanded Then
                        AddChildrenNodes(tn)
                        Application.DoEvents()
                        tn.Expand()
                    Else
                        If System.IO.Directory.GetDirectories(directory).Length > 0 Then
                            AddBlankNode(tn)
                        End If
                    End If

                    tn.ContextMenuStrip = ctxmnuTree
                    m_lstTreeNodesToAddUnreadCountOnBackgroundThread.Add(tn)
                    'ShowUnreadOnNodeText(tn, dirInfo.Name, m_boolFormFullyLoaded)
                Next

                If m_bgAddUnreadCountToTreeNodes.IsBusy Then
                    '-- Do Nothing, just let it process the nodes we just added
                Else
                    m_bgAddUnreadCountToTreeNodes.RunWorkerAsync()
                End If
            Catch ex As Exception
                Log(ex)
                ShowMessageBoxError("There was an error reading the folders within TrulyMail." & CONTACT_TRULYMAIL_MESSAGE)
            End Try
        End If

    End Sub
    Private Sub UpdateFolderState(ByVal fullPath As String, ByVal expanded As Boolean)
        Dim folder As FolderState = GetFolderState(fullPath)
        folder.Expanded = expanded
    End Sub
    Private Sub UpdateFolderState(ByVal fullPath As String, ByVal unreadCount As Integer)
        Dim folder As FolderState = GetFolderState(fullPath)
        folder.UnreadCount = unreadCount
    End Sub
    Private Sub UpdateFolderStateIcon(ByVal fullPath As String, ByVal icon As Integer)
        Dim folder As FolderState = GetFolderState(fullPath)
        folder.Icon = icon
    End Sub
    Private Sub tvFolders_AfterCollapse(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvFolders.AfterCollapse
        '-- update folderstate
        Dim strPath As String = e.Node.Tag.ToString()
        UpdateFolderState(strPath, False)
    End Sub
    Private Sub tvFolders_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvFolders.AfterExpand
        Try
            '-- Add unread count on all children
            For Each node As TreeNode In e.Node.Nodes
                ShowUnreadOnNodeText(node, System.IO.Path.GetFileName(node.Tag.ToString()), False)
            Next

            '-- update folderstate
            Dim strPath As String = e.Node.Tag.ToString()
            UpdateFolderState(strPath, True)
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub
    Private Sub tvFolders_BeforeExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvFolders.BeforeExpand
        AddChildrenNodes(e.Node)
    End Sub
#End Region
    ''' <summary>
    ''' Updates the menu text and tooltips to include "all accounts" or not based on whether there are email accounts setup or not
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateMenuText()
        Const ALL_ACCOUNTS_TEXT As String = " (all accounts)"
        Const SEND_UNSENT_TEXT As String = "Send &Unsent Messages"
        Const SEND_RECEIVE_TEXT As String = "Send &and Receive"
        Const MESSAGES As String = "&Messages"
        Const MESSAGES_AND_RECEIPTS As String = "Messages &and Receipts"

        If AppSettings.POPProfiles.Count > 0 Then
            SendUnsentToolStripMenuItem.Text = SEND_UNSENT_TEXT & ALL_ACCOUNTS_TEXT
            SendAndReceiveAllToolStripMenuItem.Text = SEND_RECEIVE_TEXT & ALL_ACCOUNTS_TEXT
        Else
            SendUnsentToolStripMenuItem.Text = SEND_UNSENT_TEXT
            SendAndReceiveAllToolStripMenuItem.Text = SEND_RECEIVE_TEXT
        End If
    End Sub
    Private Delegate Sub ShowOptionsFormCallback(tabToShow As OptionsForm.TabEnum)
    Private Sub ShowOptionsForm(tabToShow As OptionsForm.TabEnum)
        If InvokeRequired Then
            Dim deleg As New ShowOptionsFormCallback(AddressOf ShowOptionsForm)
            Invoke(deleg, tabToShow)
        Else
            Dim boolPreviousLargeToolbarIcons As Boolean = AppSettings.LargeToolbarIcons

            Dim frm As New OptionsForm()
            frm.ShowDialog(Me)

            '-- if changed, then we must update the toolbar icon size
            SetToolStripIcons(AppSettings.LargeToolbarIcons)

            tmrAutoEmptyTrash.Enabled = AppSettings.AutoEmptyTrash
            LoadMessageTags()
            If m_boolUsingRichControl Then
                ReadMessageControlRich.LoadDelay = AppSettings.MessagePreviewLoadDelay * 1000 '-- convert to ms
            Else
                ReadMessageControlPlain.LoadDelay = AppSettings.MessagePreviewLoadDelay * 1000 '-- convert to ms
            End If
            'Me.Text = "TrulyMail Client  -  " & AppSettings.Address '-- show updated TrulyMail address on title bar 
            If olvMessages.AlternateRowBackColor <> AppSettings.MessageListAlternatingRowColor Then
                olvMessages.AlternateRowBackColor = AppSettings.MessageListAlternatingRowColor
                ShowCurrentFolderContents()
            End If
        End If
    End Sub
    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        ShowOptionsForm(OptionsForm.TabEnum.UserInfo)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AboutTrulyMailClientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutTrulyMailClientToolStripMenuItem.Click
        Using frm As New AboutBoxK()
            frm.ShowDialog(Me)
        End Using
    End Sub
    Friend Function NewMessage() As IComposeForm
        Dim frm As IComposeForm
        If UseFallbackModeNow() Then
            frm = New NewMessageSimple()
        Else
            frm = New NewMessage()
        End If
        CType(frm, Form).Show()
        Return frm
    End Function
    Private Sub RunReceiveBackgroundWorker()
        tmrSendReceive.Stop()
        bgwReceive.RunWorkerAsync()
    End Sub

    Friend Sub SetStatus(ByVal newStatus As String)
        If InvokeRequired Then
            Dim deleg As New SetStatusCallback(AddressOf SetStatus)
            Invoke(deleg, newStatus)
        Else
            ToolStripStatusLabel1.Text = newStatus
            Application.DoEvents()
        End If
    End Sub
    Private Delegate Sub SetMessageCountCallback(ByVal totalMessages As Integer, ByVal unReadMessages As Integer)
    Private Sub SetMessageCount(ByVal totalMessages As Integer, ByVal unReadMessages As Integer)
        If InvokeRequired Then
            Dim deleg As New SetMessageCountCallback(AddressOf SetMessageCount)
            Invoke(deleg, totalMessages, unReadMessages)
        Else
            UnreadMessagesStatusLabel.Text = "Unread: " & unReadMessages.ToString("#,##0")
            TotalMessagesStatusLabel.Text = "Total: " & totalMessages.ToString("#,##0")
            Application.DoEvents()
        End If
    End Sub
    Friend Sub GetNewMessages(Optional ByVal forceMessageDownloadAttempt As Boolean = False)
        '-- removed in 5.0

        SetStatus(STATUS_READY)
        m_boolStillDownloadingTrulyMailMessages = False
    End Sub
    Private Sub SetRSSLastCheckedToNow()
        m_dtRSSLastChecked = Date.Now
        m_strRSSLastCheckedForDisplay = Date.Now.ToString("t")
    End Sub
    Public Sub ShowUnreadOnOutBoxNode()
        Dim strFolderName As String = System.IO.Path.GetFileName(UnQualifyPath(OutboxRootPath))
        ShowUnreadOnNodeText(m_nodeOutBox, strFolderName, True)
    End Sub
    Private Delegate Sub SetNodeDisplayTextCallback(ByVal node As TreeNode, ByVal normalText As String, ByVal unread As Integer)
    Private Sub SetNodeDisplayText(ByVal node As TreeNode, ByVal normalText As String, ByVal unread As Integer)
        If InvokeRequired Then
            Dim deleg As New SetNodeDisplayTextCallback(AddressOf SetNodeDisplayText)
            Invoke(deleg, node, normalText, unread)
        Else
            Try
                If unread > 0 Then
                    node.NodeFont = New Font(tvFolders.Font, FontStyle.Bold)
                    node.Text = normalText & " (" & unread.ToString("#,##0") & ")"
                Else
                    node.NodeFont = New Font(tvFolders.Font, FontStyle.Regular)
                    node.Text = normalText
                End If
            Catch ex As Exception
                Log(ex) '-- log and continue
            End Try
        End If
    End Sub
    Private Delegate Sub ShowUnreadOnNodeTextCallback(ByVal node As TreeNode, ByVal normalText As String, ByVal forceFileFilesystemCount As Boolean)
    Private Sub ShowUnreadOnNodeText(ByVal node As TreeNode, ByVal normalText As String, Optional ByVal forceFileFilesystemCount As Boolean = True)
        Try
            If node IsNot Nothing Then
                Dim strPath As String = node.Tag.ToString()
                Dim folder As FolderState = GetFolderState(strPath)
                Dim intUnread As Integer
                If GetCurrentlySelectedTreeViewNode() Is node OrElse forceFileFilesystemCount Then
                    '-- For the currently selected node, we will actually query the file system
                    intUnread = GetUnreadMessageCount(strPath)
                    folder.UnreadCount = intUnread
                Else
                    '-- For other nodes, we will query the last saved value from our saved settings
                    '   user can get an updated count by selecting the node in question
                    intUnread = folder.UnreadCount
                End If
                '-- Changed this next line to its own routine so that the count
                '   can happen on a background threat
                SetNodeDisplayText(node, normalText, intUnread)
            End If
        Catch ex As Exception
            If ex.Message.Contains("Cannot access a disposed object.") Then
                '-- Here we will just log
                Log(ex)
            Else
                Log(ex)
                ShowMessageBoxError("There was an error in TrulyMail." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
            End If
        End Try
    End Sub

    Private Sub tvFolders_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvFolders.AfterSelect
        txtMessageFilter.Text = String.Empty
        ShowCurrentFolderContents()
    End Sub
    'Private Function GetUnreadMessageCount(ByVal fullpath As String, ignoreTimeout As Boolean) As Integer
    Private Function GetUnreadMessageCount(ByVal fullpath As String) As Integer
        Dim boolAllAreUnread As Boolean
        Dim boolOutboxJustCountToday As Boolean

        If QualifyPath(fullpath).ToLower() = OutboxRootPath.ToLower() Then
            If AppSettings.HideOutboxCountPastToday Then
                boolOutboxJustCountToday = True
            Else
                boolAllAreUnread = True
            End If
        ElseIf QualifyPath(fullpath).ToLower() = DraftsRootPath.ToLower() Then
            boolAllAreUnread = True
        End If

        'Dim sw As Stopwatch = Stopwatch.StartNew

        Dim intReturn As Integer = 0
        Dim di As New System.IO.DirectoryInfo(fullpath)
        Dim fis() As System.IO.FileInfo = di.GetFiles("*" & MESSAGE_FILENAME_EXTENSION)
        Dim xDoc As New Xml.XmlDocument()
        Dim boolRead As Boolean
        Dim boolFirstProcessed As Boolean = False
        For Each fi As System.IO.FileInfo In fis
            ''-- if we are not ignoring the timeout and the time is greater than 
            ''   10 seconds, then stop trying to get the unread count
            'If Not ignoreTimeout AndAlso sw.Elapsed.TotalSeconds > 10 Then
            'If sw.Elapsed.TotalSeconds > 10 Then
            '    Exit For
            'End If
            If boolAllAreUnread Then
                intReturn += 1
            Else
                If TrulyMailMessage.PeekIsUnread(fi, boolOutboxJustCountToday) Then
                    intReturn += 1
                End If
            End If

            Application.DoEvents() '-- to make it more responsive on startup
        Next
        Return intReturn
    End Function

    Private Function NoTextAspectToStringConverter(ByVal s As String) As String
        Return String.Empty
    End Function
    Private Function AspectToStringConverterMessageRead(read As Boolean) As String
        If read Then
            Return "○"
        Else
            Return "●"
        End If
    End Function
    Private Function AspectToStringConverterSize(ByVal i As Integer) As String
        Dim size As Long = CType(i, Long)
        Dim limits() As Integer = {1024 * 1024 * 1024, 1024 * 1024, 1024}
        Dim units() As String = {"GB", "MB", "KB"}
        Dim dblReturnValue As Double
        For intCounter As Integer = 0 To limits.Length - 1
            If size >= limits(intCounter) Then
                dblReturnValue = ((Convert.ToDouble(size) / limits(intCounter)))
                If dblReturnValue > 4 Then
                    Return String.Format("{0:#,##0} " & units(intCounter), dblReturnValue)
                Else
                    Return String.Format("{0:#,##0.#} " & units(intCounter), dblReturnValue)
                End If
            End If
        Next

        Return String.Format("{0} B", size)
    End Function
    Private Function MainRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim msg As TrulyMailMessage = CType(olvi.RowObject, TrulyMailMessage)

        Dim LAST_SAVE_DATE_COLOR As Color = Color.Salmon
        Dim TO_SEND_DATE_COLOR As Color = Color.Blue
        Dim UNSENT_DATE_COLOR As Color = Color.Red

        Dim intPositionReceived As Integer = Me.olvMessages.Columns.IndexOf(Me.olvColumnReceived)
        Dim intPositionViewed As Integer = Me.olvMessages.Columns.IndexOf(Me.olvColumnViewed)
        Dim intPositionAttachments As Integer = Me.olvMessages.Columns.IndexOf(Me.olvColumnAttachments)
        'Dim intPositionSubject As Integer = Me.olvMessages.Columns.IndexOf(Me.olvColumnSubject)
        'Dim intPositionOtherParties As Integer = Me.olvMessages.Columns.IndexOf(Me.olvColumnOtherParties)

        '-- unread messages should be bold
        If msg IsNot Nothing AndAlso msg.Read = False Then
            olvi.Font = New Font(olvi.Font, FontStyle.Bold)
            For intCounter As Integer = 0 To olvi.SubItems.Count - 1
                olvi.SubItems(intCounter).Font = olvi.Font
            Next
        End If

        If msg IsNot Nothing Then
            If msg.Attachments.Count = 0 Then
                If intPositionAttachments >= 0 Then
                    olvi.SubItems(intPositionAttachments).Text = String.Empty
                End If
            End If

            '-- Coloring rows based on message tags
            Dim newForeColor As Color

            If AppSettings.DarkMode Then
                newForeColor = Color.White
            Else
                For Each tag As MessageTag In AppSettings.MessageTags
                    If msg.Tags IsNot Nothing AndAlso msg.Tags.Contains(tag.Text) Then
                        newForeColor = tag.Color
                        Exit For
                    End If
                Next
            End If

            olvi.ForeColor = newForeColor
            For intCounter As Integer = 0 To olvi.SubItems.Count - 1
                olvi.SubItems(intCounter).ForeColor = newForeColor
            Next

            If msg.Sent Then
                olvi.UseItemStyleForSubItems = False

                '-- If message was not sent yet, then do show future sending date.
                If msg.MessageDateSent = Date.MinValue Then
                    Dim intPositionDate As Integer = Me.olvMessages.Columns.IndexOf(Me.olvColumnMessageDateSent)
                    If msg.MessageDateToSend = Date.MinValue Then
                        If msg.LastSaveDate > Date.MinValue Then
                            If intPositionDate >= 0 Then
                                olvi.SubItems(intPositionDate).Text = AspectToStringConverterDate(msg.LastSaveDate).ToString()
                                olvi.SubItems(intPositionDate).ForeColor = LAST_SAVE_DATE_COLOR
                            End If
                        Else
                            If intPositionDate >= 0 Then
                                olvi.SubItems(intPositionDate).Text = String.Empty
                            End If
                        End If
                    Else
                        olvi.SubItems(intPositionDate).Text = AspectToStringConverterDate(msg.MessageDateToSend).ToString()
                        olvi.SubItems(intPositionDate).ForeColor = TO_SEND_DATE_COLOR
                    End If
                ElseIf msg.MessageDateUnsent > Date.MinValue Then
                    Dim intPositionDate As Integer = Me.olvMessages.Columns.IndexOf(Me.olvColumnMessageDateSent)
                    If intPositionDate >= 0 Then
                        olvi.SubItems(intPositionDate).ForeColor = UNSENT_DATE_COLOR
                    End If
                End If
            Else
                '-- message received
                If intPositionReceived >= 0 Then
                    olvi.SubItems(intPositionReceived).Text = String.Empty
                End If

                If intPositionViewed >= 0 Then
                    olvi.SubItems(intPositionViewed).Text = String.Empty
                End If
            End If
        End If
    End Function

    Private Function ReadButtonImageGetter(ByVal row As Object) As Object
        Dim msg As TrulyMailMessage = CType(row, TrulyMailMessage)
        If msg.Read Then
            Return 13
        Else
            Return 14
        End If
    End Function
    Private Function HasNotesImageGetter(ByVal row As Object) As Object
        Dim msg As TrulyMailMessage = CType(row, TrulyMailMessage)
        If msg.HasNotes Then
            Return 6
        Else
            Return Nothing
        End If
    End Function
    Private Function TransportTypeImageGetter(ByVal row As Object) As Object
        Dim msg As TrulyMailMessage = CType(row, TrulyMailMessage)
        Select Case msg.TransportType
            Case MessageTransportType.TrulyMail
                Return 4
            Case MessageTransportType.Email
                Return 3
            Case MessageTransportType.Mixed
                Return 5
            Case MessageTransportType.RSS
                Return 8
            Case MessageTransportType.WebPageMonitor
                Return 9
            Case MessageTransportType.EncryptedWebMessage
                Return 12
            Case MessageTransportType.TM2TM
                Return 4 '-- this type just added in TM v5 when TM msgs were removed so we will change the icon to that icon
            Case MessageTransportType.InternalOnly
                Return 15 '-- this type just added 7.0.5 for NoteToSelf
            Case Else
                '-- default to email
                Return 4
        End Select
    End Function
    Private Function MessageImageGetter(ByVal row As Object) As Object
        Dim msg As TrulyMailMessage = CType(row, TrulyMailMessage)
        If msg.Replied Then
            If msg.Forwarded Then
                '-- both
                Return 1
            Else
                '-- just replied
                Return 0
            End If
        Else
            If msg.Forwarded Then
                '-- just forwarded
                Return 2
            Else
                '-- transparent image
                Return 7
            End If
        End If
    End Function

    Private Sub OpenCurrentlySelectedMessages(asPlainText As Boolean)
        Dim list As ArrayList = olvMessages.GetSelectedObjects
        Dim boolAtLeastOneUnread As Boolean
        For Each tm As TrulyMailMessage In list
            If Not tm.Read Then
                boolAtLeastOneUnread = True
            End If
            tm.Read = True
            If asPlainText Then
                LoadCommunicationMessage(tm.Filename, asPlainText)
            Else
                LoadMessage(tm.Filename)
            End If
        Next

        '-- Update unread count on node because it should have just changed.
        If boolAtLeastOneUnread Then
            ShowUnreadOnCurrentNodeText()
        End If

        '-- used to reload the olv but this is much more polished
        olvMessages.RefreshSelectedObjects()

        If olvMessages.SelectedIndices.Count > 0 Then
            m_intSelectedMessage = olvMessages.SelectedIndices(0)
        Else
            m_intSelectedMessage = olvMessages.SelectedIndex
            Exit Sub '-- nothing to delete
        End If
    End Sub

    Private Sub olvMessages_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvMessages.ItemActivate
        '-- July 2019 changed so double click opens in browser
        Dim msg As TrulyMailMessage = GetCurrentlySelectedMessages(0)
        Select Case msg.MessageType
            Case MessageType.Draft
                LoadMessage(msg.Filename)
            Case Else
                If QualifyPath(System.IO.Path.GetDirectoryName(msg.Filename)) = OutboxRootPath Then
                    LoadMessage(msg.Filename)
                Else
                    LoadSelectedMessagesExternally()
                End If
        End Select
    End Sub
    Private Sub LoadSelectedMessagesExternally()
        Dim msgs As ArrayList = GetCurrentlySelectedMessages()
        Dim contact As AddressBookEntry
        For Each msg As TrulyMailMessage In msgs
            contact = ABook.GetContactByAddress(msg.Sender.Address)
            If contact Is Nothing Then
                OpenSpecificMessageInBrowser(msg, False)
            Else
                OpenSpecificMessageInBrowser(msg, contact.RemoteImages)
            End If
        Next
        'If contact Is Nothing Then
        '    OpenCurrentMessageInBrowser(False)
        'Else
        '    OpenCurrentMessageInBrowser(contact.RemoteImages)
        'End If
    End Sub
    Private Sub ShowAddressBook()
        Dim frm As New AddressBookForm()
        frm.ShowDialog()
    End Sub
    Private Sub AddressBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddressBookToolStripMenuItem.Click
        ShowAddressBook()
    End Sub

    Private Sub olvMessages_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles olvMessages.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                DeleteCurrentlySelectedMessages()
            Case Keys.A
                If ModifierKeys = Keys.Control Then
                    SelectAllMessages()
                End If
            Case Keys.Apps
                If olvMessages.SelectedItem IsNot Nothing Then
                    ctxmnuMessage.Show(olvMessages, olvMessages.SelectedItem.Bounds.Location)
                End If
        End Select
    End Sub
    Private Sub SelectAllMessages()
        Me.olvMessages.SelectAll()
    End Sub
    Friend Sub DeleteMessage(ByVal filename As String, ByVal permanentDelete As Boolean)
        Try
            If filename.ToLower.StartsWith(TrashRootPath.ToLower()) Then
                '-- msg already in trash
                permanentDelete = True
            End If

            If permanentDelete Then
                DeleteLocalMessage(filename, True, True)
            Else
                Dim strDestination As String = TrashRootPath & System.IO.Path.GetFileName(filename)

                MoveMessage(filename, strDestination)
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    ''' <summary>
    ''' Moves message and also adds to undo stack
    ''' </summary>
    ''' <param name="sourceFilename"></param>
    ''' <param name="destinationFilename"></param>
    ''' <remarks></remarks>
    Friend Sub MoveMessage(ByVal sourceFilename As String, ByVal destinationFilename As String)
        Try
            If System.IO.File.Exists(sourceFilename) Then
                If sourceFilename.ToLower() = destinationFilename.ToLower() Then
                    '-- do nothing
                Else
                    Dim undo As UndoMessageDelete
                    undo = New UndoMessageDelete()
                    Dim strFolderPath As String = GetCurrentlySelectedTreeViewNode.Tag.ToString
                    undo.FromFolder = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(sourceFilename))
                    undo.ToFolder = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(destinationFilename))

                    Dim undoItem As MessageRelocation
                    undoItem = New MessageRelocation()
                    undoItem.FromFilename = sourceFilename
                    undoItem.ToFilename = destinationFilename
                    undo.Messages.Add(undoItem)
                    DeletedMessagesForUndo.Add(undo)

                    If System.IO.File.Exists(destinationFilename) Then
                        Try
                            DeleteLocalFile(destinationFilename)
                        Catch ex As Exception
                            Log(ex)
                            ShowMessageBox("There was an error moving this message. Restart TrulyMail and try again." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End Try
                    End If

                    System.IO.File.Move(sourceFilename, destinationFilename)

                    CheckTrashIconStatus()
                    SetUndoTextAndStatus()

                    ShowFolderContentsIfCurrent(System.IO.Path.GetDirectoryName(sourceFilename))
                    ShowFolderContentsIfCurrent(System.IO.Path.GetDirectoryName(destinationFilename))

                    Dim intUnreadMessages As Integer = ShowUnreadOnCurrentNodeText()
                    Dim lst2 As List(Of TrulyMailMessage) = GetAllMessagesInListView()
                    SetMessageCount(lst2.Count, intUnreadMessages)
                    SelectNewCurrentlySelectedMessage()
                End If
            Else
                ShowMessageBoxError("The message is not found at the original location. Perhaps it was already moved." & _
                               Environment.NewLine & Environment.NewLine & _
                               "Close this window and re-open the message before moving again.")
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("The message could not be moved because of an error (" & ex.Message & ")." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try

    End Sub
    Private Sub DeleteCurrentlySelectedMessages()
        Try

            If m_boolUsingRichControl Then
                ReadMessageControlRich.Hide()
            Else
                ReadMessageControlPlain.Hide()
            End If

            '-- keep track of what was selected
            If olvMessages.SelectedIndices.Count > 0 Then
                m_intSelectedMessage = olvMessages.SelectedIndices(0)
            Else
                m_intSelectedMessage = olvMessages.SelectedIndex
                Exit Sub '-- nothing to delete
            End If

            Dim boolUpdateUnreadCount As Boolean

            Dim boolPermDelete As Boolean = (ModifierKeys = Keys.Shift) OrElse GetCurrentlySelectedTreeViewNode.Tag.ToString.ToLower.StartsWith(TrashRootPath.ToLower)
            Dim undo As UndoMessageDelete
            If Not boolPermDelete Then
                undo = New UndoMessageDelete()
                Dim strFolderPath As String = GetCurrentlySelectedTreeViewNode.Tag.ToString
                undo.FromFolder = System.IO.Path.GetFileName(UnQualifyPath(strFolderPath))
                undo.ToFolder = System.IO.Path.GetFileName(UnQualifyPath(TrashRootPath))
            End If

            Dim tm As ArrayList = olvMessages.GetSelectedObjects()

            Dim undoItem As MessageRelocation


            For Each tmm As TrulyMailMessage In tm
                undoItem = New MessageRelocation()
                undoItem.FromFilename = tmm.Filename
                undoItem.ToFilename = QualifyPath(TrashRootPath) & System.IO.Path.GetFileName(tmm.Filename)
                If Not boolPermDelete Then
                    undo.Messages.Add(undoItem)
                End If
                DeleteLocalMessage(tmm.Filename, boolPermDelete, False)

                '-- Only update the unread count if we have deleted unread msgs
                If tmm.Read = False Then
                    boolUpdateUnreadCount = True
                End If
                Application.DoEvents()
            Next
            olvMessages.RemoveObjects(olvMessages.SelectedObjects)
            CheckTrashIconStatus()

            If m_intSelectedMessage >= olvMessages.Items.Count Then
                '-- if we past the end, then select the last message
                m_intSelectedMessage = olvMessages.Items.Count - 1
            End If

            If Not boolPermDelete Then
                DeletedMessagesForUndo.Add(undo)
                SetUndoTextAndStatus()
            End If

            '-- This extra logic is to stop the treeview from reloading each time we delete a message
            Dim intUnreadMessages As Integer
            If boolUpdateUnreadCount Then
                intUnreadMessages = ShowUnreadOnCurrentNodeText()
            Else
                Dim lst As List(Of TrulyMailMessage) = GetAllMessagesInListView()
                For Each tmm As TrulyMailMessage In lst
                    If Not tmm.Read Then
                        intUnreadMessages += 1
                    End If
                Next
            End If
            Dim lst2 As List(Of TrulyMailMessage) = GetAllMessagesInListView()
            SetMessageCount(lst2.Count, intUnreadMessages)
            SelectNewCurrentlySelectedMessage()
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error deleting the current message." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub
    Friend Sub SetUndoTextAndStatus()
        If DeletedMessagesForUndo.Count = 0 Then
            UndoToolStripMenuItem.Text = "&Undo"
            UndoToolStripMenuItem.Enabled = False
        Else
            Dim strMessage As String = "message"
            If DeletedMessagesForUndo(DeletedMessagesForUndo.Count - 1).Messages.Count > 1 Then
                strMessage &= "s"
            End If

            '-- 2020-02 Note: Adding move to Search Form and that means we could have a group of messages from various folders
            '   Since the next line considers only the final message in the group for displaying the undo menu text, it could technically be too simple
            '   However since I'm the only user, I do not care
            UndoToolStripMenuItem.Text = "&Undo move (" & DeletedMessagesForUndo(DeletedMessagesForUndo.Count - 1).Messages.Count.ToString("#,##0") & " " & strMessage & " from " & DeletedMessagesForUndo(DeletedMessagesForUndo.Count - 1).FromFolder & " to " & DeletedMessagesForUndo(DeletedMessagesForUndo.Count - 1).ToFolder & ")"

            UndoToolStripMenuItem.Enabled = True
        End If
    End Sub
    Private Sub CheckTrashIconStatus()
        Dim tn As TreeNode = m_nodeTrash
        If System.IO.Directory.GetDirectories(tn.Tag.ToString).Length = 0 Then
            If System.IO.Directory.GetFiles(tn.Tag.ToString, "*" & MESSAGE_FILENAME_EXTENSION, IO.SearchOption.TopDirectoryOnly).Length > 0 Then
                tn.ImageIndex = 6
                tn.SelectedImageIndex = 6
            Else
                tn.ImageIndex = 5
                tn.SelectedImageIndex = 5
            End If
        Else
            tn.ImageIndex = 6
            tn.SelectedImageIndex = 6
        End If
    End Sub
    Private Sub SendUnsentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendUnsentToolStripMenuItem.Click
        Try
            If bgwReceive.IsBusy Then
                'ShowMessageBoxAutoClose("Please wait until the current operation has completed.", 5)
                ShowOpacityNotice("Please wait until the current operation has completed.", 1)
            Else
                StartProcessing()
                m_boolGetMessages = False
                m_boolGetReceipts = False
                SendReceiveTrigger = SendReceiveTriggerEnum.Manual
                SendUnsent()
            End If
        Catch ex As Exception
            Log(ex)

            If MessageBox.Show("There was an error sending unsent messages. Would you like to see more information about the error?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                MessageBox.Show(ex.Message)
            End If
        End Try
    End Sub

    Private Sub SendAndReceiveAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendAndReceiveAllToolStripMenuItem.Click
        If bgwReceive.IsBusy Then
            'ShowMessageBoxAutoClose("Please wait until the current operation has completed.", 5)
            ShowOpacityNotice("Please wait until the current operation has completed.", 1)
        Else
            SendReceiveTrigger = SendReceiveTriggerEnum.Manual
            SendReceiveTrulyMailPlusEmail(EmailCheckingEnum.ForceAll)
        End If
    End Sub

    Private Sub DeleteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripButton.Click
        DeleteCurrentlySelectedMessages()
    End Sub

    Private Sub AddressBookToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddressBookToolStripButton.Click
        ShowAddressBook()
    End Sub

    'Private Sub SendReceiveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If bgwReceive.IsBusy Then
    '        'ShowMessageBoxAutoClose("Please wait until the current operation has completed.", 5)
    '        ShowOpacityNotice("Please wait until the current operation has completed.", 1)
    '    Else
    '        SendReceiveTrigger = SendReceiveTriggerEnum.Manual
    '        SendReceiveTrulyMail()
    '    End If
    'End Sub

    Private Sub WriteMessageToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WriteMessageToolStripButton.Click, NewMessageToolStripMenuItem1.Click
        NewMessage()
    End Sub

    Private Sub tmrSendReceive_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSendReceive.Tick
        '-- Check TrulyMail if the target time has passed
        Try
            '   then check email no matter what
            tmrSendReceive.Stop()

            '-- If there is no internet, then do not check
            '   Manual check will still check even if internet is not present (because 
            '   some how internet might be "magically" present)
            If IsInternetAvailable() Then
                SendReceiveTrigger = SendReceiveTriggerEnum.Automatic
                Dim dtTarget As Date = m_dtTrulyMailLastChecked.AddMinutes(AppSettings.AutoSendReceiveInterval)
                If dtTarget <= Date.Now AndAlso AppSettings.AutoSendReceive Then
                    '-- we are schedule to check TrulyMail, do that first, then get email
                    SendReceiveTrulyMailPlusEmail(EmailCheckingEnum.DueToCheck)
                Else
                    If Not bgwCheckAllEmail.IsBusy Then
                        '-- No TrulyMail check, just get email from scheduled accounts
                        bgwCheckAllEmail.RunWorkerAsync(EmailCheckingEnum.DueToCheck)
                    End If
                End If

                '-- Add RSS check here
                dtTarget = m_dtRSSLastChecked.AddMinutes(AppSettings.RSSAutoCheckInterval)
                If dtTarget < Date.Now AndAlso AppSettings.RSSAutoCheck Then
                    If Not bgwDownloadRSS.IsBusy Then
                        GetNewRSSArticles()
                    End If
                End If

            End If
        Catch ex As Exception
            Log(ex)
            '-- It's a timer, not sure what to do so just ignoring it
        End Try
    End Sub

    Private Sub ctxmnuTree_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxmnuTree.Opening
        Dim node As TreeNode = GetCurrentlySelectedTreeViewNode()
        Select Case QualifyPath(node.Tag.ToString.ToLower)
            Case InBoxRootPath.ToLower, SentItemsRootPath.ToLower, OutboxRootPath.ToLower
                NewSubfolderToolStripMenuItem.Enabled = True
                DeleteFolderToolStripMenuItem.Enabled = False
                RenameFolderToolStripMenuItem.Enabled = False
                ChangeFolderColorToolStripMenuItem.Enabled = False
                EmptyTrashToolStripMenuItem.Visible = False
                MarkFolderReadToolStripMenuItem.Enabled = True
            Case TrashRootPath.ToLower
                NewSubfolderToolStripMenuItem.Enabled = False
                DeleteFolderToolStripMenuItem.Enabled = False
                RenameFolderToolStripMenuItem.Enabled = False
                ChangeFolderColorToolStripMenuItem.Enabled = False
                EmptyTrashToolStripMenuItem.Visible = True
                MarkFolderReadToolStripMenuItem.Enabled = True
            Case DraftsRootPath.ToLower
                NewSubfolderToolStripMenuItem.Enabled = True
                DeleteFolderToolStripMenuItem.Enabled = False
                RenameFolderToolStripMenuItem.Enabled = False
                ChangeFolderColorToolStripMenuItem.Enabled = False
                EmptyTrashToolStripMenuItem.Visible = False
                MarkFolderReadToolStripMenuItem.Enabled = False
            Case Else
                NewSubfolderToolStripMenuItem.Enabled = True
                DeleteFolderToolStripMenuItem.Enabled = True
                RenameFolderToolStripMenuItem.Enabled = True
                ChangeFolderColorToolStripMenuItem.Enabled = True
                EmptyTrashToolStripMenuItem.Visible = False
                MarkFolderReadToolStripMenuItem.Enabled = True
        End Select

        MoveFolderToRootToolStripMenuItem.Enabled = node.Parent IsNot Nothing

    End Sub

    Private Sub tvFolders_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvFolders.NodeMouseClick
        '-- workaround because the right-click context menu does not show the clicked node, 
        '   only the previously selected node
        Me.tvFolders.SelectedNode = e.Node
    End Sub
    Private Sub CreateNewFolder(ByVal parentPath As String, ByVal parentNodesCollection As TreeNodeCollection)
        Const NEW_FOLDER_BASE_NAME As String = "New Folder"
        Dim strNewFolderName As String = NEW_FOLDER_BASE_NAME
        Dim intCounter As Integer = 0
        Do While System.IO.Directory.Exists(parentPath & strNewFolderName)
            intCounter += 1
            strNewFolderName = NEW_FOLDER_BASE_NAME & " " & intCounter.ToString()
        Loop

        System.IO.Directory.CreateDirectory(parentPath & strNewFolderName)
        Dim tn As TreeNode = parentNodesCollection.Add(strNewFolderName)
        tn.Tag = parentPath & strNewFolderName
        tn.ContextMenuStrip = ctxmnuTree
        tn.ImageIndex = FOLDER_COLOR_BASE_CLOSED_INDEX
        tn.SelectedImageIndex = FOLDER_COLOR_BASE_OPEN_INDEX
    End Sub
    Private Sub NewFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewFolderToolStripMenuItem.Click
        CreateNewFolder(MessageStoreRootPath, tvFolders.Nodes)
    End Sub

    Private Sub DeleteFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteFolderToolStripMenuItem.Click
        Try
            Dim tn As TreeNode = GetCurrentlySelectedTreeViewNode()
            Dim strDirectoryPath As String = tn.Tag.ToString.ToLower
            Select Case strDirectoryPath
                Case InBoxRootPath, SentItemsRootPath, TrashRootPath, OutboxRootPath
                    '-- do nothing, cannot delete system folders
                Case Else
                    '-- if we are under the trash folder, then delete
                    If strDirectoryPath.StartsWith(TrashRootPath.ToLower()) Then
                        If MessageBox.Show("Are you sure you want to permanently delete this (" & tn.Text & ") folder?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            DeleteFolder(strDirectoryPath, True)
                            tn.Remove()
                        End If
                    Else
                        '-- otherwise, move to trash folder
                        If MessageBox.Show("Are you sure you want to delete this (" & tn.Text & ") folder?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Dim strNewPath As String = TrashRootPath & System.IO.Path.GetFileName(strDirectoryPath)
                            tn.Tag = strNewPath
                            Try
                                System.IO.Directory.Move(strDirectoryPath, strNewPath)
                                tn.Remove()
                                m_nodeTrash.Nodes.Add(tn)
                            Catch ex As Exception
                                If ex.Message.Contains("when that file already exists") Then
                                    If MessageBox.Show("This would cause duplicate folder names under the same folder." & Environment.NewLine & Environment.NewLine & _
                                                       "Would you like to permanently delete this folder instead?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                                        DeleteFolder(strDirectoryPath, True)
                                        tn.Remove()
                                    End If
                                Else
                                    Log(ex)
                                    MessageBox.Show("There was an error with " & Application.ProductName & ". Please restart the application and try again.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                            End Try
                            CheckTrashIconStatus()
                        End If
                    End If
            End Select

            CheckTrashIconStatus()
        Catch ex As System.IO.DirectoryNotFoundException
            '-- just ignore, deleting a folder that no longer exists

        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error: " & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Delete all messages (and attachments) in the folder and then delete the folder and sub-folders
    ''' </summary>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Private Sub DeleteFolder(ByVal path As String, ByVal deletePassedFolderAlso As Boolean)
        Dim files() As String = System.IO.Directory.GetFiles(path, "*" & MESSAGE_FILENAME_EXTENSION, IO.SearchOption.AllDirectories)
        For Each strFilename As String In files
            '-- delete the message and attachments
            DeleteLocalMessage(strFilename, False, False)
        Next

        If deletePassedFolderAlso Then
            '-- and remove all directories (including the one passed)
            System.IO.Directory.Delete(path, True)
        Else
            Dim dirs() As String = System.IO.Directory.GetDirectories(path, "*.*", IO.SearchOption.TopDirectoryOnly)
            For Each strDirName As String In dirs
                Try
                    System.IO.Directory.Delete(strDirName, True)
                Catch ex As Exception
                    MessageBox.Show("There was a problem removing all the folders in the trash. Please try again.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit For
                End Try
            Next
        End If
    End Sub

    Private Sub EmptyTrash()
        DeleteFolder(TrashRootPath, False)
        m_nodeTrash.Nodes.Clear()
        m_nodeTrash.ImageIndex = 5
        m_nodeTrash.SelectedImageIndex = 5
        CheckTrashIconStatus()
        ShowUnreadOnNodeText(m_nodeTrash, TRASH_NAME)

        '-- only refresh UI if the trash is currently selected
        MainFormReference.ShowFolderContentsIfCurrent(TrashRootPath)
    End Sub
    Private Sub EmptyTrashToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmptyTrashToolStripMenuItem.Click
        EmptyTrash()
    End Sub

    Private Sub RenameFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameFolderToolStripMenuItem.Click
        Try
            GetCurrentlySelectedTreeViewNode.Text = System.IO.Path.GetFileName(GetCurrentlySelectedTreeViewNode.Tag.ToString())
            GetCurrentlySelectedTreeViewNode.BeginEdit()
        Catch ex As Exception
            Log(ex) '-- log and ignore
        End Try
    End Sub

    Private Sub tvFolders_BeforeLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles tvFolders.BeforeLabelEdit
        Dim node As TreeNode = GetCurrentlySelectedTreeViewNode()
        Select Case QualifyPath(node.Tag.ToString.ToLower)
            Case InBoxRootPath.ToLower, SentItemsRootPath.ToLower, OutboxRootPath.ToLower, TrashRootPath.ToLower, DraftsRootPath.ToLower
                e.CancelEdit = True
            Case Else
                '-- do nothing, allow edit
                node.Text = System.IO.Path.GetFileName(node.Tag.ToString())
        End Select
    End Sub

    Private Sub tvFolders_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles tvFolders.AfterLabelEdit
        '-- rename underlying folder and update nodes
        Try
            '-- label is nothing when user hits {ESC} to cancel out (but cancel does not become true)
            '   If label = node.text then the user typed the same name, no need to change anything
            If e.Label IsNot Nothing AndAlso Not e.Node.Text.ToLower.Equals(e.Label.ToLower) Then
                If e.Label.EndsWith(")") Then
                    ShowMessageBoxError("Folders cannot end with ')' so please change it.")
                    e.CancelEdit = True
                    Exit Sub
                End If
                Dim strOldPath As String = e.Node.Tag.ToString
                Dim srNewPath As String = System.IO.Path.GetDirectoryName(e.Node.Tag.ToString()) & "\" & e.Label
                If Not strOldPath.ToLower.Equals(srNewPath.ToLower) Then
                    System.IO.Directory.Move(strOldPath, srNewPath)
                    e.Node.Tag = srNewPath
                    e.Node.Collapse()
                End If
            End If
        Catch ex As Exception
            e.CancelEdit = True
            MessageBox.Show("There was an error renaming the folder (" & ex.Message & ").", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub NewSubfolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewSubfolderToolStripMenuItem.Click
        CreateNewFolder(QualifyPath(GetCurrentlySelectedTreeViewNode.Tag.ToString()), GetCurrentlySelectedTreeViewNode.Nodes)
    End Sub

#Region " Drag and Drop Logic "
    Private Sub olvMessages_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles olvMessages.ItemDrag
        DoDragDrop(olvMessages.SelectedObjects, DragDropEffects.Move)
    End Sub

    Dim _lastHighlightedNode As New TreeNode()
    Private Sub StartFolderExpandTimer()
        tmrFolderExpand.Stop()
        tmrFolderExpand.Start()
    End Sub
    Private Sub tmrFolderExpand_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrFolderExpand.Tick
        tmrFolderExpand.Stop()
        If _lastHighlightedNode IsNot Nothing Then
            _lastHighlightedNode.Expand()
        End If
    End Sub
    Private Sub tvFolders_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvFolders.DragOver
        Dim pt As Point = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
        Dim targetNode As TreeNode = tvFolders.GetNodeAt(pt)

        If targetNode IsNot Nothing Then
            If e.Data.GetDataPresent("System.Collections.ArrayList", True) OrElse e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
                If Not GetCurrentlySelectedTreeViewNode() Is targetNode Then
                    If _lastHighlightedNode IsNot Nothing Then
                        _lastHighlightedNode.BackColor = Color.White
                    End If
                    targetNode.BackColor = Color.Yellow

                    If _lastHighlightedNode IsNot targetNode Then
                        Console.WriteLine(Date.Now)
                        StartFolderExpandTimer()
                    End If

                    _lastHighlightedNode = targetNode

                    Dim dropnode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
                    Do Until targetNode Is Nothing
                        If targetNode Is dropnode Then
                            e.Effect = DragDropEffects.None
                            Exit Sub
                        End If
                        targetNode = targetNode.Parent
                    Loop
                    e.Effect = DragDropEffects.Move
                End If
            End If
        Else
            e.Effect = DragDropEffects.None
            _lastHighlightedNode.BackColor = Color.White
        End If
    End Sub

    Private Sub tvFolders_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvFolders.DragDrop
        _lastHighlightedNode.BackColor = Color.White

        If e.Data.GetDataPresent("System.Collections.ArrayList", True) Then
            '-- move message
            Dim strDestinationFolder As String = _lastHighlightedNode.Tag.ToString()
            Dim strSourceFolder As String

            Dim items As System.Collections.ArrayList
            Dim item As TrulyMailMessage
            Dim strSource, strDestination As String
            items = CType(e.Data.GetData("System.Collections.ArrayList"), System.Collections.ArrayList)

            '-- prepare undo data
            Dim undo As New UndoMessageDelete()
            undo.ToFolder = System.IO.Path.GetFileName(UnQualifyPath(strDestinationFolder))

            Dim message As MessageRelocation
            Dim intUnreadCount As Integer
            Dim intTotalCount As Integer = items.Count

            For Each item In items
                strSource = item.Filename
                If strSourceFolder Is Nothing Then
                    strSourceFolder = System.IO.Path.GetDirectoryName(item.Filename)
                End If
                strDestination = QualifyPath(strDestinationFolder) & System.IO.Path.GetFileName(strSource)
                '-- Overwrite destination file, if it exists
                If System.IO.File.Exists(strDestination) Then
                    DeleteLocalFile(strDestination)
                End If

                '-- prepare undo data
                message = New MessageRelocation
                message.FromFilename = strSource
                message.ToFilename = strDestination
                undo.Messages.Add(message)

                System.IO.File.Move(strSource, strDestination)

                '-- Get change in unread count by
                '   only considering the files moved, so we don't have to rescan every file
                '   in the two folders
                Dim boolRead As Boolean
                Dim fi As System.IO.FileInfo
                fi = New System.IO.FileInfo(strDestination)
                If TrulyMailMessage.PeekIsUnread(fi, False) Then
                    intUnreadCount += 1
                End If

                Application.DoEvents() '-- to make it more responsive to user
            Next

            If strSource IsNot Nothing Then
                undo.FromFolder = System.IO.Path.GetFileName(UnQualifyPath(System.IO.Path.GetDirectoryName(strSource)))
                DeletedMessagesForUndo.Add(undo)
                SetUndoTextAndStatus()
            End If

            m_boolPreventLoadingPreview = True
            olvMessages.RemoveObjects(items)
            m_boolPreventLoadingPreview = False


            '-- Update folderstate for the source and destination folders
            Dim folderState As FolderState
            folderState = GetFolderState(strDestinationFolder)
            folderState.UnreadCount += intUnreadCount
            folderState.TotalCount += intTotalCount

            folderState = GetFolderState(strSourceFolder)
            folderState.UnreadCount -= intUnreadCount
            folderState.TotalCount -= intTotalCount


            '-- Recount on the two nodes in question
            ShowUnreadOnNodeText(_lastHighlightedNode, System.IO.Path.GetFileName(UnQualifyPath(_lastHighlightedNode.Tag.ToString)), False)
            SetNodeDisplayText(GetCurrentlySelectedTreeViewNode, System.IO.Path.GetFileName(UnQualifyPath(GetCurrentlySelectedTreeViewNode.Tag.ToString)), folderState.UnreadCount)

            '-- update unread and total count for current
            SetMessageCount(folderState.TotalCount, folderState.UnreadCount)

            If m_boolUsingRichControl Then
                ReadMessageControlPlain.Hide()
            Else
                ReadMessageControlRich.Hide()
            End If

            SelectNewCurrentlySelectedMessage()
        ElseIf e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            Dim tnToMove As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
            If tnToMove Is m_nodeInBox OrElse _
                tnToMove Is m_nodeTrash OrElse _
                tnToMove Is m_nodeOutBox OrElse _
                tnToMove Is m_nodeSent OrElse _
                tnToMove Is m_nodeDrafts OrElse _
                tnToMove Is m_nodeInBox Then

                MessageBox.Show("Cannot move system folders.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                '-- move folder
                Dim strOriginalFolderPath As String = tnToMove.Tag.ToString()
                Dim strNewFolderPath As String = QualifyPath(_lastHighlightedNode.Tag.ToString()) & System.IO.Path.GetFileName(strOriginalFolderPath)
                g_boolFileSystemChanged = True
                System.IO.Directory.Move(strOriginalFolderPath, strNewFolderPath)

                tnToMove.Tag = strNewFolderPath

                '-- move treenode to new parent
                tnToMove.Remove()
                _lastHighlightedNode.Nodes.Add(tnToMove)
            End If
        End If
    End Sub

    Private Sub tvFolders_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvFolders.DragEnter
        If e.Data.GetDataPresent("System.Collections.ArrayList", True) Then
            '-- move message
            e.Effect = DragDropEffects.Move
        ElseIf e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            e.Effect = DragDropEffects.Move
        End If
    End Sub

    Private Sub tvFolders_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles tvFolders.ItemDrag
        DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub tvFolders_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvFolders.DragLeave
        _lastHighlightedNode.BackColor = Color.White
    End Sub
#End Region

    Private Delegate Sub UpdateDownloadProgressBarCallback(ByVal progress As Double)
    Private Sub UpdateDownloadProgressBar(ByVal progress As Double)
        If InvokeRequired Then
            Dim deleg As New UpdateDownloadProgressBarCallback(AddressOf UpdateDownloadProgressBar)
            Invoke(deleg, progress)
        Else
            ToolStripProgressBar1.Value = Math.Min(progress, 100)
            ToolStripProgressBar1.Visible = ToolStripProgressBar1.Value > 0
            Application.DoEvents()
        End If
    End Sub
    Private Delegate Sub DownloadProgressBarVisibleCallback(ByVal visible As Boolean)
    Private Sub DownloadProgressBarVisible(ByVal visible As Boolean)
        If InvokeRequired Then
            Dim deleg As New DownloadProgressBarVisibleCallback(AddressOf DownloadProgressBarVisible)
            Invoke(deleg, visible)
        Else
            Try
                ToolStripProgressBar1.Visible = visible
                ToolStripProgressBar1.Value = 0
                Application.DoEvents()
            Catch ex As Exception
                Log(ex)
            End Try
        End If
    End Sub
    '<DebuggerHiddenAttribute()> _
    Private Sub tmrRefreshCurrentFolder_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefreshCurrentFolder.Tick
        tmrRefreshCurrentFolder.Stop()

        '-- If something in the file system has changed, then reload the current folder
        '   this is to ensure the user always sees what is there.
        If g_boolFileSystemChanged Then
            g_boolFileSystemChanged = False
            ShowCurrentFolderContents()
        End If

        '-- This next block removed for TM6
        '-- To refresh the changed message (notes added, reply status changed, etc.)
        '   we will remove the existing message, re-create from file, and re-add
        '   This should keep everything looking good to the user.
        'If m_messageToRefresh IsNot Nothing Then
        '    olvMessages.RemoveObject(m_messageToRefresh)
        '    If System.IO.File.Exists(m_messageToRefresh.Filename) Then
        '        m_messageToRefresh = New TrulyMailMessage(m_messageToRefresh.Filename)
        '        olvMessages.AddObject(m_messageToRefresh)
        '    End If
        '    m_messageToRefresh = Nothing
        'End If

        tmrRefreshCurrentFolder.Start()
    End Sub
    Private Sub StopProcessingToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopProcessingToolStripButton.Click
        StopProcessing()
    End Sub
    Private Sub StopProcessing()
        m_boolStopProcessing = True
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf StopProcessing)
            Invoke(deleg)
        Else
            StopProcessingToolStripButton.Enabled = False
            StopProcessingToolStripButton.Checked = False
            SetStatus(STATUS_READY)
            SendReceiveTrigger = SendReceiveTriggerEnum.None
        End If
    End Sub
    Private Sub StartProcessing()
        m_boolStopProcessing = False
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf StartProcessing)
            Invoke(deleg)
        Else
            Try
                StopProcessingToolStripButton.Enabled = True
                StopProcessingToolStripButton.Checked = False
                ToolStripProgressBar1.Visible = False '-- hide periodically, incase it gets stuck showing
            Catch ex As Exception
                Log(ex) '-- for now, just log and ignore
            End Try
        End If
    End Sub


    Private Sub MainForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If AppSettings Is Nothing Then
                Exit Sub
            End If

            If AppSettings.SendNowOnExit AndAlso Not QuickShutDownRequired Then
                '-- Send everything in the outbox upto the sendNowDelay setting
                ShuttingDown = True
                SendReceiveTrigger = SendReceiveTriggerEnum.Automatic
                ProcessUnsent()

                '--now wait until all sending is complete
                Do While BusySendingMessage
                    Application.DoEvents()
                Loop
            Else
                If bgwReceive.IsBusy OrElse BusySendingMessage Then
                    If ShowMessageBox("TrulyMail is currently busy sending/receiving messages." & _
                                      Environment.NewLine & Environment.NewLine & _
                                      "Are you sure you want to close and cancel this process?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        e.Cancel = True
                    Else
                        '-- let it close
                    End If
                End If
            End If

            If Me.WindowState <> FormWindowState.Minimized Then
                AppSettings.MainFormWindowState = Me.WindowState
            End If

            If Me.WindowState = WindowState.Normal Then
                AppSettings.MainWindowSize = Me.Size
                AppSettings.MainWindowLocation = Me.Location
            End If

            AppSettings.HideFilterAreaOnMainForm = Not MessageFilterToolStripMenuItem.Checked

            '-- olvMessages state
            AppSettings.MessageListState = olvMessages.SaveState()
            AppSettings.ShutDownProperly = True '-- only mark true as we are closing app
            AppSettings.Save()

            '-- for quick shutdown, skip some things that might hang with message boxes
            If Not QuickShutDownRequired Then
                If AppSettings.EmptyTrashOnExit Then
                    EmptyTrash()
                End If

                '-- empty temp store (.eml files, resized picts, etc.)
                EmptyMessageStoreTempPath()
            End If

            Dim intCounterMax As Integer = Application.OpenForms.Count - 1
            For intCounter As Integer = 0 To intCounterMax
                Dim frm As Form = CType(Application.OpenForms(intCounter), Form)
                If frm IsNot Me Then
                    frm.Close()
                    intCounter -= 1
                    intCounterMax -= 1
                    If intCounter >= intCounterMax Then
                        Exit For
                    End If
                End If
            Next
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxAutoClose("There was an error trying to close TrulyMail." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE, 10)
        End Try
    End Sub

    Private Sub olvMessages_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles olvMessages.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If olvMessages.HitTest(e.Location).Item IsNot Nothing Then
                If Not olvMessages.HitTest(e.Location).Item.Selected Then
                    '-- select object receiving right-click
                    olvMessages.SelectedItem = olvMessages.HitTest(e.Location).Item
                End If
                ctxmnuMessage.Show(olvMessages, e.Location)
            End If
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteCurrentlySelectedMessages()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        OpenCurrentlySelectedMessages(False)
    End Sub
    Private Function GetCurrentlySelectedMessages() As ArrayList
        Return olvMessages.GetSelectedObjects()
    End Function
    Private Function GetCurrentlySelectedMessageFilename() As String
        If GetCurrentlySelectedMessages.Count > 0 Then
            Dim tm As TrulyMailMessage = GetCurrentlySelectedMessages(0)
            If tm Is Nothing Then
                Return String.Empty
            Else
                Return tm.Filename
            End If
        Else
            Return String.Empty
        End If
    End Function
    Private Sub MarkMessageReadUnread(tmm As TrulyMailMessage, markUnread As Boolean)
        tmm.Read = Not markUnread
        'MarkLocalMessageRead(tmm.Filename, markUnread)
        tmm.Save()

        olvMessages.RefreshObject(tmm)

        Dim intUnreadMessages As Integer = ShowUnreadOnCurrentNodeText()
        Dim lst2 As List(Of TrulyMailMessage) = GetAllMessagesInListView()
        SetMessageCount(lst2.Count, intUnreadMessages)
    End Sub
    Private Sub MarkSelectedMessagesReadUnread(ByVal markUnread As Boolean)
        Dim lst As ArrayList = GetCurrentlySelectedMessages()
        For Each tm As TrulyMailMessage In lst
            tm.Read = Not markUnread
            MarkLocalMessageRead(tm.Filename, markUnread)
        Next

        olvMessages.RefreshSelectedObjects()

        UpdateUnreadCount()
    End Sub
    Private Sub UpdateUnreadCount()
        Dim intUnreadMessages As Integer = ShowUnreadOnCurrentNodeText()
        Dim lst2 As List(Of TrulyMailMessage) = GetAllMessagesInListView()
        SetMessageCount(lst2.Count, intUnreadMessages)
    End Sub
    Private Function GetAllMessagesInListView() As List(Of TrulyMailMessage)
        Dim lst1 As ArrayList
        Dim lst2 As List(Of TrulyMailMessage)
        If TypeOf olvMessages.Objects Is ArrayList Then
            lst1 = olvMessages.Objects
            lst2 = New List(Of TrulyMailMessage)
            For Each tm As TrulyMailMessage In lst1
                lst2.Add(tm)
            Next
        Else
            lst2 = olvMessages.Objects
        End If
        Return lst2
    End Function
    Private Function ShowUnreadOnCurrentNodeText() As Integer
        Try
            If GetCurrentlySelectedTreeViewNode() IsNot Nothing Then
                Dim strPath As String = GetCurrentlySelectedTreeViewNode.Tag.ToString
                Dim strNormalText As String = System.IO.Path.GetFileName(UnQualifyPath(strPath))
                Dim lst As List(Of TrulyMailMessage) = GetAllMessagesInListView()
                Dim intUnread As Integer = 0

                If lst Is Nothing Then
                    Log("lst is null in ShowUnreadOnCurrentNodeText: " & strPath)
                    Return 0
                Else
                    For Each tm As TrulyMailMessage In lst
                        If Not tm.Read Then
                            intUnread += 1
                        End If
                    Next

                    Dim folder As FolderState = GetFolderState(strPath)
                    folder.UnreadCount = intUnread
                    folder.TotalCount = lst.Count

                    If intUnread > 0 Then
                        GetCurrentlySelectedTreeViewNode.NodeFont = New Font(tvFolders.Font, FontStyle.Bold)
                        GetCurrentlySelectedTreeViewNode.Text = strNormalText & " (" & intUnread.ToString("#,##0") & ")"
                    Else
                        GetCurrentlySelectedTreeViewNode.NodeFont = New Font(tvFolders.Font, FontStyle.Regular)
                        GetCurrentlySelectedTreeViewNode.Text = strNormalText
                    End If
                    Return intUnread
                End If
            Else
                Return 0
            End If
        Catch ex As Exception
            If ex.Message.Contains("Cannot access a disposed object.") Then
                '-- Here we will just log
                Log(ex)
            Else
                Log(ex)
                ShowMessageBoxError("There was an error in TrulyMail." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
            End If

            Return 0
        End Try
    End Function
    Private Sub MarkReadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkReadToolStripMenuItem.Click
        MarkSelectedMessagesReadUnread(False)
    End Sub
    Private Sub MarkUnreadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkUnreadToolStripMenuItem.Click
        MarkSelectedMessagesReadUnread(True)
    End Sub

    Private Sub ctxmnuMessage_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxmnuMessage.Opening
        '-- if one message is selected
        '   disable either mark read/unread based on current message's status
        '-- If multiple messages are selected, then canculate what is best
        Dim list As ArrayList = GetCurrentlySelectedMessages()
        Select Case list.Count
            Case 0
                MarkReadToolStripMenuItem.Enabled = False
                MarkUnreadToolStripMenuItem.Enabled = False
            Case 1
                Dim tm As TrulyMailMessage = list(0)
                MarkReadToolStripMenuItem.Enabled = Not tm.Read
                MarkUnreadToolStripMenuItem.Enabled = tm.Read


            Case Else
                Dim boolAtLeastOneRead As Boolean = False
                Dim boolAtLeaseOneUnread As Boolean = False
                For Each tm As TrulyMailMessage In list
                    If tm.Read Then
                        boolAtLeastOneRead = True
                    Else
                        boolAtLeaseOneUnread = True
                    End If
                Next
                MarkReadToolStripMenuItem.Enabled = boolAtLeaseOneUnread
                MarkUnreadToolStripMenuItem.Enabled = boolAtLeastOneRead
        End Select


        If list.Count = 1 Then
            Dim tm As TrulyMailMessage = olvMessages.GetSelectedObject()

            '-- disable reply and reply to all if sender is current user
            '-- also disable reply if sender is server
            ReplyToolStripMenuItem.Enabled = Not tm.Sent AndAlso tm.MessageType = MessageType.Communication
            ReplyToAllToolStripMenuItem.Enabled = Not tm.Sent AndAlso tm.MessageType = MessageType.Communication
            ForwardToolStripMenuItem.Enabled = tm.MessageType = MessageType.Communication

            Dim strBaseOtherParties As String = GetBaseOtherParty(tm.OtherPartiesShort)
            FilterSenderToolStripMenuItem.Text = "Filter = '" & strBaseOtherParties.Replace("&", "&&") & "'"
            FilterSenderToolStripMenuItem.Tag = strBaseOtherParties
            FilterSenderToolStripMenuItem.Enabled = True

            Dim strBaseSubject As String = GetBaseSubject(tm.SubjectShort)
            FilterSubjectToolStripMenuItem1.Text = "Filter = '" & strBaseSubject.Replace("&", "&&") & "'"
            FilterSubjectToolStripMenuItem1.Tag = strBaseSubject
            FilterSubjectToolStripMenuItem1.Enabled = strBaseSubject.Length > 0
            CreateReminderFromMessageToolStripMenuItem.Enabled = True
            CreateProcessingRuleFromMessageToolStripMenuItem.Enabled = True
        Else
            FilterSenderToolStripMenuItem.Text = "Filter"
            FilterSenderToolStripMenuItem.Enabled = False
            FilterSubjectToolStripMenuItem1.Text = "Filter"
            FilterSubjectToolStripMenuItem1.Enabled = False
            ReplyToolStripMenuItem.Enabled = False
            ReplyToAllToolStripMenuItem.Enabled = False
            ForwardToolStripMenuItem.Enabled = False
            CreateReminderFromMessageToolStripMenuItem.Enabled = False
            CreateProcessingRuleFromMessageToolStripMenuItem.Enabled = False
        End If

        '-- If on outbox msg, enable send Now, otherwise, disable it
        If list.Count >= 1 Then
            If GetCurrentlySelectedTreeViewNode.Tag.Equals(OutboxRootPath) Then
                SendNowToolStripMenuItem.Enabled = True
                DelaySendingFor1HourToolStripMenuItem.Enabled = True
            Else
                SendNowToolStripMenuItem.Enabled = False
                DelaySendingFor1HourToolStripMenuItem.Enabled = False
            End If
        Else
            SendNowToolStripMenuItem.Enabled = False
        End If

    End Sub
    Private Function GetBaseOtherParty(ByVal otherParties As String) As String
        Dim strOtherParties As String = otherParties.Trim.ToLower()

        If strOtherParties.EndsWith(" ...") Then
            strOtherParties = strOtherParties.Substring(0, strOtherParties.Length - 4).Trim()
        ElseIf strOtherParties.EndsWith("...") Then
            strOtherParties = strOtherParties.Substring(0, strOtherParties.Length - 3).Trim()
        End If

        Return strOtherParties

    End Function
    Friend Sub ForwardSelectedMessages(recipients As List(Of AddressBookEntry))
        Try
            Select Case olvMessages.SelectedObjects.Count
                Case 0
                    ShowMessageBox("No messages selected.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Case Else
                    For Each obj As TrulyMailMessage In olvMessages.SelectedObjects
                        '-- forward and add contacts
                        If UseFallbackModeNow() Then
                            Dim frm As New NewMessageSimple(obj.Filename, MessageResponseType.Forward)
                            frm.AddRecipientList(recipients, RecipientType.Send_To)
                            frm.Show()
                        Else
                            Dim frm As New NewMessage(obj.Filename, MessageResponseType.Forward)
                            frm.AddRecipientList(recipients, RecipientType.Send_To)
                            frm.Show()
                        End If
                    Next
            End Select
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error forwarding the selected messages." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub
    Private Sub ReplyToSender()
        Dim strFilename As String = GetCurrentlySelectedMessageFilename()
        Globals.ReplyToSender(strFilename)
    End Sub
    Private Sub ReplyToAll()
        Dim strFilename As String = GetCurrentlySelectedMessageFilename()
        Globals.ReplyToAll(strFilename)
    End Sub
    Private Sub FollowUp()
        Dim strFilename As String = GetCurrentlySelectedMessageFilename()
        Globals.FollowUpMessage(strFilename)
    End Sub
    Private Sub Forward()
        Dim strFilename As String = GetCurrentlySelectedMessageFilename()
        Globals.ForwardMessage(strFilename)
    End Sub
    Private Sub ReplyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplyToolStripMenuItem.Click
        ReplyToSender()
    End Sub
    Private Sub ReplyToAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplyToAllToolStripMenuItem.Click, ReplyMessageToAllToolStripMenuItem.Click
        ReplyToAll()
    End Sub
    Private Sub ForwardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForwardToolStripMenuItem.Click
        Forward()
    End Sub
    Private Sub ReplyToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplyToolStripButton.Click
        ReplyToSender()
    End Sub
    Private Sub ReplyToAllToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplyToAllToolStripButton.Click
        ReplyToAll()
    End Sub
    Private Sub ForwardToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForwardToolStripButton.Click
        Forward()
    End Sub
    Private Sub LoadMessagePreview()
        If olvMessages.SelectedObjects.Count = 1 Then
            If AppSettings.ShowMessagePreviewPane Then
                Dim tm As TrulyMailMessage = CType(olvMessages.GetSelectedObject, TrulyMailMessage)
                If m_boolUsingRichControl Then
                    ReadMessageControlRich.LoadMessage(tm)
                Else
                    ReadMessageControlPlain.LoadMessage(tm)
                End If

                Dim boolUpdateUnreadCount As Boolean = tm.Read = False '-- Only if the msg is read do we need to update the unread count

                If m_boolUsingRichControl Then
                    If ReadMessageControlRich.Visible Then
                        tm.Read = True
                    End If
                Else
                    If ReadMessageControlPlain.Visible Then
                        tm.Read = True
                    End If
                End If

                If boolUpdateUnreadCount Then
                    ShowUnreadOnCurrentNodeText()
                End If

                ReadMessagePauseToolStripMenuItem.Enabled = False
                ReadMessageResumeToolStripMenuItem.Enabled = False

            End If
        Else
            If m_boolUsingRichControl Then
                ReadMessageControlRich.CancelMessageLoad()
                ReadMessageControlRich.Hide()
            Else
                ReadMessageControlPlain.CancelMessageLoad()
                ReadMessageControlPlain.Hide()
            End If
        End If
    End Sub
    Private Sub UpdateReplyToolStripItems()
        If olvMessages.SelectedObjects.Count = 1 Then
            Dim tm As TrulyMailMessage = olvMessages.GetSelectedObject()

            '-- disable reply and reply to all if sender is current user
            '-- also disable reply if sender is server
            ReplyToolStripButton.Enabled = tm.CanReply 'Not tm.Sent AndAlso tm.SenderName <> SERVER_FULLNAME AndAlso (tm.MessageType = MessageType.Communication OrElse tm.MessageType = MessageType.ExternalReply)
            ReplyToAllToolStripButton.Enabled = tm.CanReplyAll 'Not tm.Sent AndAlso tm.SenderName <> SERVER_FULLNAME AndAlso tm.MessageType = MessageType.Communication
            ForwardToolStripButton.Enabled = tm.CanForward ' (tm.MessageType = MessageType.Communication OrElse tm.MessageType = MessageType.ExternalReply OrElse tm.MessageType = MessageType.RSSArticle OrElse tm.MessageType = MessageType.PageChangeNotice)
            FollowUpToolStripMenuItem.Enabled = tm.CanFollowUp 'tm.Sent AndAlso tm.MessageType = MessageType.Communication
            PrintToolStripMenuItem.Enabled = tm.CanPrint '(tm.MessageType = MessageType.Communication OrElse tm.MessageType = MessageType.ExternalReply OrElse tm.MessageType = MessageType.RSSArticle OrElse tm.MessageType = MessageType.PageChangeNotice)

            AddNotesToMessageToolStripMenuItem.Enabled = AppSettings.ShowMessagePreviewPane
            ChangeSubjectToolStripMenuItem.Enabled = True
            TreatAsReadReceiptToolStripMenuItem.Enabled = True
            SaveAsToolStripMenuItem.Enabled = True
            NewProcessingRuleFromMessageToolStripMenuItem.Enabled = True
        Else
            ForwardToolStripButton.Enabled = False
            ReplyToolStripButton.Enabled = False
            ReplyToAllToolStripButton.Enabled = False
            FollowUpToolStripMenuItem.Enabled = False

            PrintToolStripMenuItem.Enabled = False
            TreatAsReadReceiptToolStripMenuItem.Enabled = False
            AddNotesToMessageToolStripMenuItem.Enabled = False
            ChangeSubjectToolStripMenuItem.Enabled = False

            SaveAsToolStripMenuItem.Enabled = False
            NewProcessingRuleFromMessageToolStripMenuItem.Enabled = False
        End If

        ReplyToSenderToolStripMenuItem.Enabled = ReplyToolStripButton.Enabled
        ReplyMessageToAllToolStripMenuItem.Enabled = ReplyToAllToolStripButton.Enabled
        ForwardMessageToolStripMenuItem.Enabled = ForwardToolStripButton.Enabled

    End Sub
    Private Sub olvMessages_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvMessages.SelectedIndexChanged
        tmrSelectedMessageChanged.Stop()
        tmrSelectedMessageChanged.Start()
    End Sub
    Private Sub SubmitLogFileToServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitLogFileToServerToolStripMenuItem.Click
        Using frm As New SendToSupport()
            frm.ShowDialog()
        End Using
    End Sub
    Private Sub SetToolStripIcons(ByVal toLarge As Boolean)
        If toLarge Then
            '-- Switching from normal, small icons to large icons
            Me.ToolStrip1.ImageScalingSize = New Size(32, 32)
            Me.ToolStrip1.Height = TOOLBAR_32_HEIGHT

            WriteMessageToolStripButton.Image = My.Resources.Editpencil_32
            AddContactToolStripDropDownButton.Image = My.Resources.AddUser_32
            AddEmailContactToolStripMenuItem.Image = My.Resources.email_32

            SendReceiveToolStripSplitButton.Image = My.Resources.Synchronize_32
            SendReceiveTrulyMailToolStripMenuItem.Image = My.Resources.Securedmessage_32
            SendReceiveAllAccountsToolStripMenuItem.Image = My.Resources.Synchronize_32
            For Each mi As ToolStripItem In SendReceiveToolStripSplitButton.DropDownItems
                If mi.Name <> SendReceiveTrulyMailToolStripMenuItem.Name AndAlso _
                    mi.Name <> SendReceiveAllAccountsToolStripMenuItem.Name AndAlso _
                    mi.Text.Length > 0 Then '-- skip first two plus separator

                    If mi.Tag IsNot Nothing AndAlso mi.Tag.ToString() = "rss" Then
                        mi.Image = My.Resources.rss_32
                        mi.ImageTransparentColor = Color.White
                    Else
                        mi.Image = My.Resources.email_32
                        mi.ImageTransparentColor = Color.White
                    End If
                End If
            Next

            AddressBookToolStripButton.Image = My.Resources.Addressbook_32
            DeleteToolStripButton.Image = My.Resources.Erase_32

            ReplyToolStripButton.Image = My.Resources.reply_3_32
            ReplyToAllToolStripButton.Image = My.Resources.reply_all_3_32
            ForwardToolStripButton.Image = My.Resources.Forward_3_32
            'ReadMessageContentsToolStripButton.Image = My.Resources.PlayButton_32
            'ReadMessagePauseToolStripButton.Image = My.Resources.PauseButton_32
            'ReadMessageResumeToolStripButton.Image = My.Resources.ResumeButton_32
            StopProcessingToolStripButton.Image = My.Resources.Stop_32
            ShowContactListToolStripButton.Image = My.Resources.Text_32
            PrintToolStripButton.Image = My.Resources.Print_32

            If MessageHighlightHighlightSenderToolStripMenuItem.Checked Then
                MessageHighlightToolStripDropDownButton.Image = My.Resources.HighlightSender2_32
            ElseIf MessageHighlightHighlightsubjectToolStripMenuItem.Checked Then
                MessageHighlightToolStripDropDownButton.Image = My.Resources.HighlightSubject2_32
            Else
                MessageHighlightToolStripDropDownButton.Image = My.Resources.HighlightNothing_32
            End If
        Else
            '-- Switching from large icons to small, normal icons
            Me.ToolStrip1.ImageScalingSize = New Size(16, 16)
            Me.ToolStrip1.Height = TOOLBAR_16_HEIGHT

            WriteMessageToolStripButton.Image = My.Resources.Editpencil_16
            AddContactToolStripDropDownButton.Image = My.Resources.AddUser_16
            AddEmailContactToolStripMenuItem.Image = My.Resources.email_16

            SendReceiveToolStripSplitButton.Image = My.Resources.Synchronize_16
            SendReceiveTrulyMailToolStripMenuItem.Image = My.Resources.Securedmessage_16
            SendReceiveAllAccountsToolStripMenuItem.Image = My.Resources.Synchronize_16
            For Each mi As ToolStripItem In SendReceiveToolStripSplitButton.DropDownItems
                Application.DoEvents()
                If mi.Name <> SendReceiveTrulyMailToolStripMenuItem.Name AndAlso _
                    mi.Name <> SendReceiveAllAccountsToolStripMenuItem.Name AndAlso _
                    mi.Text.Length > 0 Then '-- skip first two plus separator

                    If mi.Tag IsNot Nothing AndAlso mi.Tag.ToString() = "rss" Then
                        mi.Image = My.Resources.rss_16
                        mi.ImageTransparentColor = Color.White
                    Else
                        mi.Image = My.Resources.email_16
                        mi.ImageTransparentColor = Color.White
                    End If
                End If
            Next

            AddressBookToolStripButton.Image = My.Resources.Addressbook_16
            DeleteToolStripButton.Image = My.Resources.Erase_16

            ReplyToolStripButton.Image = My.Resources.reply_3_16
            ReplyToAllToolStripButton.Image = My.Resources.reply_all_3_16
            ForwardToolStripButton.Image = My.Resources.Forward_3_16
            'ReadMessageContentsToolStripButton.Image = My.Resources.PlayButton_16
            'ReadMessagePauseToolStripButton.Image = My.Resources.PauseButton_16
            'ReadMessageResumeToolStripButton.Image = My.Resources.ResumeButton_16
            StopProcessingToolStripButton.Image = My.Resources.Stop_16
            ShowContactListToolStripButton.Image = My.Resources.Text_16
            PrintToolStripButton.Image = My.Resources.Print_16


            If MessageHighlightHighlightSenderToolStripMenuItem.Checked Then
                MessageHighlightToolStripDropDownButton.Image = My.Resources.HighlightSender2_16

            ElseIf MessageHighlightHighlightsubjectToolStripMenuItem.Checked Then
                MessageHighlightToolStripDropDownButton.Image = My.Resources.HighlightSubject2_16
            Else
                MessageHighlightToolStripDropDownButton.Image = My.Resources.HighlightNothing_16
            End If
        End If

        If AppSettings.UseLargeAllAccountDropDown Then
            SendReceiveToolStripSplitButton.DropDownButtonWidth = 40
        Else
            SendReceiveToolStripSplitButton.DropDownButtonWidth = 11
        End If

        SetupToolStripForText(ToolStrip1)

    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Dim frm As New SearchForm
        frm.Show(Me)
    End Sub

#Region " Send-Receive Logic "
    Private Sub m_msgSender_Canceled() Handles m_msgTransmitter.Canceled
        Select Case m_msgTransmitter.CancelReason
            Case MessageTransmitter.CancelReasonEnum.CallerCanceled
                '-- stop all processing, show nothing to the user
                StopProcessing()
            Case MessageTransmitter.CancelReasonEnum.MessageError
                If m_msgTransmitter.Exception.Message = EXCEPTIONTEXT_HASH_VALUES_DO_NOT_MATCH Then
                    ShowMessageBoxAutoClose("There was an error sending an attachment on one of your messages." & Environment.NewLine & Environment.NewLine & _
                                   "The message has been rescheduled to send in 2 hours.", STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)
                    m_msgTransmitter.RescheduleSendingDate(Date.UtcNow.AddHours(2))
                ElseIf m_msgTransmitter.Exception.Message = EXCEPTIONTEXT_FILE_DOES_NOT_EXIST Then
                    ShowMessageBoxAutoClose("There was an error sending an attachment on one of your messages." & Environment.NewLine & Environment.NewLine & _
                                   "The message has been rescheduled to send in 2 hours.", STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)
                    m_msgTransmitter.RescheduleSendingDate(Date.UtcNow.AddHours(2))
                ElseIf m_msgTransmitter.Exception.Message = EXCEPTIONTEXT_ERROR_ADDING_ATTACHMENT Then
                    ShowMessageBoxAutoClose("There was an error sending an attachment on one of your messages." & Environment.NewLine & Environment.NewLine & _
                                   "The message has been rescheduled to send in 2 hours.", STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)
                    m_msgTransmitter.RescheduleSendingDate(Date.UtcNow.AddHours(2))
                ElseIf m_msgTransmitter.Exception.Message = EXCEPTIONTEXT_ALL_RECIPIENTS_SENDONLY Then
                    ShowMessageBoxAutoClose("None of the recipients on a message have an account which receives messages." & Environment.NewLine & Environment.NewLine & _
                                            "The message has been removed from your Outbox and saved in your Drafts folder.", STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)
                    m_msgTransmitter.MakeMostRecentDraft()
                ElseIf m_msgTransmitter.Exception.Message = EXCEPTIONTEXT_EMAIL_TOO_LARGE Then
                    ShowMessageBoxError("You are trying to send a message that is too large." & Environment.NewLine & Environment.NewLine & _
                                   "The message has been removed from your Outbox and saved in your Drafts folder.")
                    m_msgTransmitter.MakeMostRecentDraft()
                ElseIf m_msgTransmitter.Exception.Message = EXCEPTIONTEXT_EMAIL_UNKNOWN_ERROR Then
                    If ShowMessageBox("An unknown error occurred." & Environment.NewLine & Environment.NewLine & _
                                      "Would you like to see the message from the email server?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        ShowMessageBoxError("Message from email server: " & Environment.NewLine & Environment.NewLine & m_msgTransmitter.Exception.InnerException.Message)
                        If ShowMessageBox("Would you like to stop trying to send the message and save it in your drafts folder?" & Environment.NewLine & Environment.NewLine & _
                                          "Yes = Save in drafts" & Environment.NewLine & _
                                          "No  = Keep in outbox and try sending again", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            m_msgTransmitter.MakeMostRecentDraft()
                        End If
                    End If
                ElseIf m_msgTransmitter.Exception.Message = EXCEPTIONTEXT_USERNAME_PASSWORD_INVALID AndAlso m_msgTransmitter.SMTPAccount IsNot Nothing AndAlso m_msgTransmitter.SMTPAccount.EncryptedPassword.Length > 0 Then
                    If ShowMessageBox("It looks like there is a problem with your saved sending (SMTP) email password." & _
                                             Environment.NewLine & Environment.NewLine & _
                                             "Would you like to clear your saved email password (for " & m_msgTransmitter.SMTPAccount.Name & ") so you will be prompted next time?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        m_msgTransmitter.SMTPAccount.Password = String.Empty
                        AppSettings.Save()
                        m_msgTransmitter.RescheduleSendingDate(Date.UtcNow.AddMinutes(1)) '-- delay sending for one minute
                    End If
                Else
                    '-- could be an error sending email
                    ShowMessageBoxAutoClose("There was an error sending one of your messages." & Environment.NewLine & Environment.NewLine & _
                                            "Server response: " & m_msgTransmitter.Exception.Message & Environment.NewLine & Environment.NewLine & _
                                            "The message has been rescheduled to send in " & AppSettings.DelayMinutesWhenCannotSend & " minutes.", STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)
                    m_msgTransmitter.RescheduleSendingDate(Date.UtcNow.AddMinutes(AppSettings.DelayMinutesWhenCannotSend))
                End If

                '-- Continue on with next message
                StartNextRoutineTimer()
            Case MessageTransmitter.CancelReasonEnum.ServerError
                '-- stop all processing
                StopProcessing()
                'TODO: Fill this area out
                If m_msgTransmitter.Exception IsNot Nothing Then

                    '-- Only show this message if there is an exception - this is how msgtransmitter communicates that msg should be shown
                    ShowMessageBoxAutoClose("The server cannot be contacted. Unsent messages will be sent later.", STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)

                    If m_msgTransmitter.Exception.Message = EXCEPTIONTEXT_INVALID_CONTEXTID Then
                        '-- Login again
                    ElseIf m_msgTransmitter.Exception.Message = EXCEPTIONTEXT_UNABLE_TO_CONNECT_TO_SERVER Then
                        '-- cannot connect, so just wait it out
                    Else

                    End If
                Else
                    '-- cannot connect, so just wait it out
                End If
        End Select

        SetStatus(STATUS_READY)
        DownloadProgressBarVisible(False)
    End Sub

    Private Sub m_msgTransmitter_Progress(ByVal progress As Double, ByVal status As String) Handles m_msgTransmitter.Progress
        SetStatus(status)
        DownloadProgressBarVisible(True)
        UpdateDownloadProgressBar(progress * 100)
        If progress = 1 Then
            DownloadProgressBarVisible(False)
        End If

        If m_boolStopProcessing Then
            m_msgTransmitter.Cancel()
        End If

    End Sub

    Private Sub m_msgTransmitter_Sent() Handles m_msgTransmitter.Sent
        '-- Recent message sent just fine
        '   Must use timer because we are synchronous with the UI thread and we need
        '   to give it a chance to exit from raising this event in the messengersender class
        SetStatus(STATUS_READY)
        DownloadProgressBarVisible(False)
        StartNextRoutineTimer()
        ShowUnreadOnOutBoxNode()
        ShowFolderContentsIfCurrent(SentItemsRootPath) '-- do reload sent items if it selected
    End Sub
    Friend Sub ProcessUnsent()
        Try
            If bgwReceive.IsBusy OrElse BusySendingMessage Then
                '-- already sending, ignore this request
            Else
                If AppSettings.AutomaticallyTransmitOnSend Then
                    StartProcessing()
                    m_boolGetMessages = False
                    m_boolGetReceipts = False
                    SendUnsent()
                End If
            End If
        Catch ex As Exception
            Log(ex) '-- log it but ignore it for now
            'TODO: Handle errors
        End Try
    End Sub
    Private Sub SendUnsent()
        '-- Do not do anything here if user hit stop, if we are receiving, or if we are sending something
        If m_boolStopProcessing OrElse bgwReceive.IsBusy OrElse BusySendingMessage Then
            Exit Sub
        Else
            If SendNextUnsent() Then
                m_routineToCallAfterSendingUnsent = AddressOf SendUnsent '-- call this routine when done
            Else
                m_routineToCallAfterSendingUnsent = Nothing
                If m_boolGetMessages OrElse m_boolGetReceipts Then
                    '-- never will SendNextUnsent return false while sending a message
                    '   so just call ReceiveAll directly
                    ReceiveAll()
                Else
                    StopProcessing()
                End If
            End If
        End If
    End Sub
    Private Sub SendReceiveTrulyMailPlusEmail(ByVal checkType As EmailCheckingEnum)
        '-- only check if internet is available or if manual check was called
        If IsInternetAvailable() OrElse checkType = EmailCheckingEnum.ForceAll Then
            m_checkTypeEmail = checkType
            m_boolGetAllEmail = True
            m_boolGetMessages = True
            m_boolGetRSSArticles = True
            m_boolGetReceipts = True
            m_boolSendMessages = True
            StartProcessing()
            SendUnsent()
        End If
    End Sub
    'Private Sub SendReceiveTrulyMail()
    '    m_boolGetMessages = True
    '    m_boolGetReceipts = True
    '    m_boolSendMessages = True
    '    m_boolGetRSSArticles = False
    '    StartProcessing()
    '    SendUnsent()
    'End Sub
    Private Sub StartNextRoutineTimer()
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf StartNextRoutineTimer)
            Invoke(deleg)
        Else
            tmrInvokeNextRoutine.Start()
        End If
    End Sub
    Private Sub tmrInvokeNextRoutine_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrInvokeNextRoutine.Tick
        tmrInvokeNextRoutine.Stop()

        '-- Do not call the next routine if cancel was clicked by user
        If m_routineToCallAfterSendingUnsent IsNot Nothing AndAlso Not m_boolStopProcessing Then
            m_routineToCallAfterSendingUnsent.Invoke()
        End If
    End Sub
    Private Sub ReceiveAll()
        Try
            If bgwReceive.IsBusy Then
                'ShowMessageBoxAutoClose("Please wait until the current operation has completed.", 5)
                ShowOpacityNotice("Please wait until the current operation has completed.", 1)
            Else
                StartProcessing()
                m_boolGetMessages = True
                m_boolGetReceipts = True

                RunReceiveBackgroundWorker()
            End If
        Catch ex As Exception
            '-- ignore if we stopped because user clicked stop
            If Not StopProcessingToolStripButton.Checked Then
                If ex.Message.Contains("File hash does not match.") Then
                    '-- ignore
                Else
                    Log(ex)

                    If MessageBox.Show("There was an error sending and receiving. Would you like to see more information about the error?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        End Try
    End Sub
    ''' <summary>
    ''' Returns false if there are no unsent items ready to be sent
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SendNextUnsent() As Boolean
        '-- This replaces SendUnsent
        Try
            Dim files() As String = System.IO.Directory.GetFiles(OutboxRootPath, "*" & MESSAGE_FILENAME_EXTENSION)
            If files.Length > 0 Then
                If files.Length <= m_intNextUnsentToSend Then
                    m_intNextUnsentToSend = 0 '-- reset if we pass all existing files
                End If

                SetStatus(STATUS_SENDING_UNSENT)
                Dim intCounter As Integer = 0
                Dim strFilename As String
                Dim intStartingPosition As Integer = m_intNextUnsentToSend
                m_msgTransmitter = New MessageTransmitter()

                While True
                    strFilename = files(m_intNextUnsentToSend)

                    If m_boolStopProcessing Then
                        Exit While
                    End If

                    If m_msgTransmitter.SendMessage(strFilename) Then
                        '-- message was accepted, exit routine
                        '   will pick back up on sent or canceled event


                        Exit While
                    Else
                        '-- loop around and try to send the next file
                        '   This file must be set to send in the future
                        m_intNextUnsentToSend += 1

                        If files.Length <= m_intNextUnsentToSend Then
                            m_intNextUnsentToSend = 0 '-- reset if we pass all existing files
                        End If

                        If m_intNextUnsentToSend = intStartingPosition Then
                            '-- we have checked every waiting file, exit and try again later
                            Return False '-- nothing to be sent now
                        End If
                    End If

                    Application.DoEvents()
                End While

                Return True '-- There is something to send, so call this routine again when the msgsender completes
            Else
                Return False '-- no files to process
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxAutoClose("There was an error sending unsent items (" & ex.Message & "). Please try again later.", STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)
        End Try
    End Function
    Private Sub bgwSendReceive_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwReceive.DoWork
        '-- Do not check if just a normal scheduled check unless internet is available
        If m_checkTypeEmail = EmailCheckingEnum.ForceAll OrElse IsInternetAvailable() Then
            If m_boolGetMessages AndAlso Not m_boolStopProcessing Then
                m_boolGetMessages = False
                GetNewMessages()
            End If
            If m_boolGetRSSArticles AndAlso Not m_boolStopProcessing Then
                m_boolGetRSSArticles = False
                If Not bgwDownloadRSS.IsBusy Then
                    GetNewRSSArticles()
                End If
            End If
            If m_boolGetAllEmail AndAlso Not m_boolStopProcessing Then
                m_boolGetAllEmail = False
                CheckAllEmailAccounts(m_checkTypeEmail)
            End If
        End If
    End Sub

    Private Sub bgwSendReceive_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwReceive.RunWorkerCompleted
        StopProcessing()
        '-- Only refresh folder if something has changed
        If g_boolFileSystemChanged Then
            ShowCurrentFolderContents()
        End If
        SetStatus(STATUS_READY)

        '-- In case user sent message while receiving (part of send/receive)
        '   we should send what is in the outbox
        If m_boolSendMessages Then
            m_boolSendMessages = False
            ProcessUnsent()
        End If

        tmrSendReceive.Start()

    End Sub

#End Region
    Friend Sub SetupEmailAccounts()
        Dim frm As New AccountList
        frm.ShowDialog(Me)
        SetupMenusForPOPAccountsAndRSSFeeds()
        UpdateMenuText()
    End Sub
    Private Sub EmailAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailAccountsToolStripMenuItem.Click
        SetupEmailAccounts()
    End Sub

    Private Sub SetupMenusForPOPAccountsAndRSSFeeds()
        '-- If user has setup POP accounts, then replace the get messages button 
        '   with a drop down allowing getting messages on any single account

        '-- First clear our existing email menu items
        Dim lstToRemove As New List(Of ToolStripItem)
        For Each item As ToolStripItem In SendReceiveToolStripSplitButton.DropDownItems
            If item.Tag IsNot Nothing Then
                If item.Tag.ToString() = "rss" Then
                    '-- RSS item
                    lstToRemove.Add(item)
                Else
                    '-- email item
                    lstToRemove.Add(item)
                End If
            End If
        Next

        For Each item As ToolStripItem In lstToRemove
            SendReceiveToolStripSplitButton.DropDownItems.Remove(item)
        Next

        If AppSettings.POPProfiles.Count > 0 OrElse AppSettings.RSSFeeds.Count > 0 Then
            SendReceiveToolStripSplitButton.Visible = True

            '-- just one menu item for all RSS feeds
            If AppSettings.RSSFeeds.Count > 0 Then
                Dim mi As ToolStripItem = SendReceiveToolStripSplitButton.DropDownItems.Add("RSS and News Feeds")
                mi.Tag = "rss"
                AddHandler mi.Click, AddressOf GetNewRSSArticles
            End If

            For Each pop As POPProfile In AppSettings.POPProfiles
                Dim mi As ToolStripItem = SendReceiveToolStripSplitButton.DropDownItems.Add(pop.Name)
                mi.Tag = pop.ID
                AddHandler mi.Click, AddressOf GetNewPOPMessages
            Next
            'Else
            'SendReceiveToolStripSplitButton.Visible = False
        End If

        SetToolStripIcons(AppSettings.LargeToolbarIcons)
    End Sub
    Private Sub GetNewRSSArticles(ByVal sender As Object, ByVal e As EventArgs)
        GetNewRSSArticles()
    End Sub
    Private Sub GetNewRSSArticles()
        If bgwDownloadRSS.IsBusy Then
            'ShowMessageBoxError("Please wait until the current process has completed.")
            ShowOpacityNotice("Please wait until the current operation has completed.", 1)
        Else
            bgwDownloadRSS.RunWorkerAsync()
        End If
    End Sub
    Private Sub bgwDownloadRSS_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwDownloadRSS.DoWork
        Try
            Dim boolAtLeastOneError As Boolean

            For Each feed As RSSFeed In AppSettings.RSSFeeds
                Dim results As RSSDownloadResults = GetNewRSSItemsForFeed(feed)

                If results.ArticlesDownloaded > 0 Then
                    '-- only refresh count if we changed the contents of the folder
                    ShowFolderContentsIfCurrent(feed.Folder)
                End If

                If results.ErrorText.Length > 0 Then
                    boolAtLeastOneError = True
                    feed.LastErrorMessage = "Error: " & results.ErrorText
                Else
                    feed.LastErrorMessage = "OK"
                End If
            Next

            e.Result = boolAtLeastOneError

            SetRSSLastCheckedToNow()
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub bgwDownloadRSS_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwDownloadRSS.RunWorkerCompleted
        Try
            If Convert.ToBoolean(e.Result) Then
                If Not AppSettings.DoNotShowRSSErrorListPrompt Then
                    Using frmNotify As New NotifyForm("Downloading RSS feeds experienced some errors." & _
                                                       Environment.NewLine & Environment.NewLine & _
                                                       "Would you like to see the list of erros for each RSS feed?", NotifyForm.DoNotShowSetting.DoNotShowRSSErrorListPrompt, MessageBoxButtons.YesNo)
                        frmNotify.AutoClose(30, MessageBoxDefaultButton.Button2)
                        If frmNotify.ShowDialog(MainFormReference) = Windows.Forms.DialogResult.Yes Then
                            ShowRSSForm(True)
                        End If
                    End Using
                End If
            End If
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub

    Private Sub GetNewPOPMessages(ByVal sender As Object, ByVal e As EventArgs)
        Dim mi As ToolStripItem = CType(sender, ToolStripItem)
        Dim strPOPAccountID As String = mi.Tag.ToString()
        If bgwDownloadPOP.IsBusy Then
            'ShowMessageBoxError("Please wait until the current process has completed.")
            ShowOpacityNotice("Please wait until the current operation has completed.", 1)
        Else
            bgwDownloadPOP.RunWorkerAsync(strPOPAccountID)
        End If
    End Sub
    ''' <summary>
    ''' Downloads new messages from given pop account, according to current settings
    ''' </summary>
    ''' <param name="popAccountID"></param>
    ''' <remarks></remarks>
    Friend Sub GetNewMessagesFromPOPAccount(ByVal popAccountID As String)

        Dim popToUse As POPProfile
        Dim popServer As aspNetPOP3.POP3
        'Dim intMessagesDownloaded As Integer
        Dim lstDeletedMessages As New List(Of String) '-- used only when we lose network connection while downloading
        Dim ht As Hashtable
        Dim tnInBox As TreeNode
        Dim boolAccountChecked As Boolean '-- True if we should update the last checked time
        Dim intDownloadRequestFailures As Integer

        Try
            If AppSettings.EnableVerboseLogging Then
                Log("Starting POP download using accountID: " & popAccountID & ".")
            End If

            StartProcessing()

            '-- first, get the account
            For Each pop As POPProfile In AppSettings.POPProfiles
                If pop.ID = popAccountID Then
                    popToUse = pop
                    Exit For
                End If
            Next
            If AppSettings.EnableVerboseLogging Then
                Log("Configuring pop settings.")
            End If

            Dim strLicense As String = My.Resources.aspnetpop3_xml_lic
            aspNetPOP3.POP3.LoadLicenseString(strLicense)

            popServer = New aspNetPOP3.POP3()
            Dim intMessagesOnServer As Integer

            popServer.TimeOut = 15 * 60000 '-- setting timeout to 15 minutes, by default it seems to be 90 seconds

            If popToUse IsNot Nothing Then
                SetStatus("Checking for new email messages on " & popToUse.Name & ". Please enter your password.")
                If AppSettings.EnableVerboseLogging Then
                    Log("Checking for new email messages on " & popToUse.Name & ".")
                End If
                Dim strPassword As String = popToUse.Password
                If strPassword.Length = 0 Then
                    '-- User canceled
                    If AppSettings.EnableVerboseLogging Then
                        Log("Password not entered.")
                    End If
                    Exit Sub
                End If

                '-- First, we connect to the POP server and populate inbox stats
                popServer = New aspNetPOP3.POP3(popToUse.ServerAddress, popToUse.Username, strPassword, popToUse.ServerPort)
                'popServer.LogInMemory = True

                Dim ssl As New AdvancedIntellect.Ssl.SslSocket()
                '== Replaced Oct 2018
                'If popToUse.SecureConnection = SecureConnectionOption.None Then
                '    popServer.LoadSslSocket(Nothing)
                '    If AppSettings.EnableVerboseLogging Then
                '        Log("SSL not being used.")
                '    End If
                'Else
                '    popServer.LoadSslSocket(ssl)
                '    If AppSettings.EnableVerboseLogging Then
                '        Log("SSL being used.")
                '    End If
                'End If
                '== Now using TLS 1.2
                Select Case popToUse.SecureConnection
                    Case SecureConnectionOption.None
                        popServer.LoadSslSocket(Nothing)
                        If AppSettings.EnableVerboseLogging Then
                            Log("SSL not being used.")
                        End If
                    Case SecureConnectionOption.SSL
                        popServer.LoadSslSocket(ssl)
                        If AppSettings.EnableVerboseLogging Then
                            Log("SSL being used.")
                        End If
                    Case SecureConnectionOption.TLS
                        ssl.SslProtocols = Security.Authentication.SslProtocols.Tls12
                        popServer.LoadSslSocket(ssl)
                        If AppSettings.EnableVerboseLogging Then
                            Log("TLS1.2 being used.")
                        End If
                End Select
                Try
                    SetStatus("connecting to " & popToUse.ServerAddress & " (" & popToUse.Name & ")")
                    If AppSettings.EnableVerboseLogging Then
                        Log("connecting to " & popToUse.ServerAddress & " (" & popToUse.Name & ")")
                    End If
                    popServer.Connect()
                    SetStatus("connected to " & popToUse.ServerAddress)
                    If AppSettings.EnableVerboseLogging Then
                        Log("connected to " & popToUse.ServerAddress & ".")
                    End If
                    '-- connected, save password for session
                    popToUse.PasswordDuringSession = strPassword
                Catch ex As Exception
                    Log(ex)

                    Dim strMessage As String
                    If ex.Message = EXCEPTIONTEXT_INVOCATION_TARGET_EXCEPTION Then
                        '-- Something strange, let's hope it does not repeat
                        'ShowMessageBoxAutoClose("There was an error connecting to the email server." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE, STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)

                        '-- This error is beause the internet connection is too weak to connect (flaky or downloading too much other stuff while trying to connect)
                        If Not AppSettings.DoNotShowPOPServerConnectionTimeOutErrorNotice Then
                            Using frm As New NotifyForm("The server used to download email is not responding. This could be because of a weak internet connection." & _
                                                        Environment.NewLine & Environment.NewLine & _
                                                        "If you believe this is an error within TrulyMail, please contact TrulyMail Support.", NotifyForm.DoNotShowSetting.DoNotShowPOPServerConnectionTimeOutErrorNotice, MessageBoxButtons.OK)
                                frm.ShowDialog(MainFormReference)
                            End Using
                        End If

                    ElseIf ex.Message.Contains(EXCEPTIONTEXT_INVOCATION_TARGET_EXCEPTION) Then
                        '-- Something strange, let's hope it does not repeat
                        'ShowMessageBoxAutoClose("There was an error connecting to the email server." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE, STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)

                        '-- This error is beause the internet connection is too weak to connect (flaky or downloading too much other stuff while trying to connect)
                        If Not AppSettings.DoNotShowPOPServerConnectionTimeOutErrorNotice Then
                            Using frm As New NotifyForm("The server used to download email is not responding. This could be because of a weak internet connection." & _
                                                        Environment.NewLine & Environment.NewLine & _
                                                        "If you believe this is an error within TrulyMail, please contact TrulyMail Support.", NotifyForm.DoNotShowSetting.DoNotShowPOPServerConnectionTimeOutErrorNotice, MessageBoxButtons.OK)
                                frm.ShowDialog(MainFormReference)
                            End Using
                        End If
                    Else
                        '-- Remove reference to POP3 component from dialog
                        Dim intPosition As Integer = ex.Message.ToLower().IndexOf("aspnetpop3")
                        If intPosition > 0 Then
                            strMessage = ex.Message.Substring(0, intPosition)
                        Else
                            strMessage = ex.Message
                        End If

                        '-- Remove internal AspNetPOP3 messages
                        intPosition = strMessage.ToLower().IndexOf("if you have not enabled logging")
                        If intPosition > 0 Then
                            strMessage = strMessage.Substring(0, intPosition)
                        End If


                        If strMessage.Contains("failed DNS resolution") Then
                            ShowMessageBoxAutoClose("Cannot connect to server (" & popToUse.ServerAddress & "). Could not resolve address.", STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)
                            Exit Sub
                        End If

                        ShowMessageBoxAutoClose("There was an error connecting to the email server. Response received is as follows:" & _
                                       Environment.NewLine & Environment.NewLine & _
                                       strMessage, STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)

                        If ex.Message.ToLower.Contains("password") AndAlso popToUse.EncryptedPassword.Length > 0 Then
                            If ShowMessageBox("It looks like there is a problem with your saved receiving (POP3) email password." & _
                                              Environment.NewLine & Environment.NewLine & _
                                              "Would you like to clear your saved email password (for " & popToUse.Name & ") so you will be prompted next time?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                popToUse.Password = String.Empty
                                AppSettings.Save()
                            End If
                        End If
                    End If
                    Exit Sub
                End Try

                strLicense = My.Resources.aspnetmime_xml_lic
                aspNetMime.MimeMessage.LoadLicenseString(strLicense)

                SetStatus("Checking InBox")
                If AppSettings.EnableVerboseLogging Then
                    Log("Checking InBox.")
                End If
                popServer.PopulateInboxStats()
                If AppSettings.EnableVerboseLogging Then
                    Log("Processing data.")
                End If
                SetStatus("Processing data")

                '-- Next, we loop through the messages, downloading all that have not yet been downloaded.
                intMessagesOnServer = popServer.InboxMessageCount()
                Dim intSkippedMessages As Integer

                If AppSettings.EnableVerboseLogging Then
                    Log("Messages on server: " & intMessagesOnServer.ToString("#,##0"))
                End If

                boolAccountChecked = True

                SetStatus("Examining messages")
                If AppSettings.EnableVerboseLogging Then
                    Log("Examining messages")
                End If
                Dim intMessagesDownloadedThisTime As Integer
                If intMessagesOnServer > 0 Then
                    Dim messageUniqueIDListing() As aspNetPOP3.MessageStat = popServer.MessageUniqueIdListing()

                    Dim intCounter As Integer

                    Dim strInBoxPath As String = MessageStoreRootPath & popToUse.InBoxPath
                    If AppSettings.EnableVerboseLogging Then
                        Log("InBox path: " & strInBoxPath)
                    End If

                    tnInBox = GetTreeNodeByPath(strInBoxPath)

                    Dim strHeaders As String
                    Dim dtEarliestReceivedFromHeader As Date
                    Dim objReceiveFile As ReceiveFileDetails

                    For intCounter = 0 To intMessagesOnServer - 1
                        If m_boolStopProcessing Then
                            Exit For
                        End If

                        '-- Check if message has been processed before, if so, skip it
                        ht = AppSettings.EmailMessagesReceived
                        Dim strMessageUniqueID As String = messageUniqueIDListing(intCounter).UniqueId
                        If ht.ContainsKey(strMessageUniqueID) Then
                            intSkippedMessages += 1
                            SetStatus("Skipping " & intSkippedMessages.ToString("#,##0") & " messages already downloaded")

                            '-- skip this message, we've already processed it
                            '   but FIRST, if we are not leaving messages on the server and we are here
                            '   then we must delete the message from the server
                            '   This allows user to uncheck 'leave on server' to clear out server
                            If Not popToUse.LeaveOnServer Then
                                '-- Remove from server and from persisted hashtable
                                Try
                                    popServer.Delete(intCounter)
                                    ht.Remove(strMessageUniqueID)
                                Catch ex As Exception
                                    Log(ex)
                                    ShowMessageBoxError("There was an error deleting an old message from the server: " & ex.Message)
                                End Try
                            End If

                            Continue For
                        End If


                        SetStatus("Downloading message " & intCounter - intSkippedMessages + 1 & " of " & intMessagesOnServer - intSkippedMessages & " for " & popToUse.Name)
                        If AppSettings.EnableVerboseLogging Then
                            Log("Downloading message " & intCounter - intSkippedMessages + 1 & " of " & intMessagesOnServer - intSkippedMessages)
                        End If

                        'Dim strHeaders As String = popServer.GetHeaders(intCounter)
                        '                    "Delivered-To: john@montgomerysoftware.com Received: by 10.142.116.20 with SMTP id o20cs26574wfc;         Tue, 24 Feb 2009 01:10:13 -0800 (PST) Received: by 10.142.237.19 with SMTP id k19mr2429429wfh.209.1235466613256;         Tue, 24 Feb 2009 01:10:13 -0800 (PST) Return-Path: <v-cemflo_dlglffhhl_ebaejpk_ebaejpk_a@bounce.rm04.net> Received: from mail1033c.rm04.net (mail1033c.rm04.net [208.85.49.70])         by mx.google.com with ESMTP id 30si14116825wfa.38.2009.02.24.01.10.11;         Tue, 24 Feb 2009 01:10:12 -0800 (PST) Received-SPF: pass (google.com: domain of v-cemflo_dlglffhhl_ebaejpk_ebaejpk_a@bounce.rm04.net designates 208.85.49.70 as permitted sender) client-ip=208.85.49.70; Authentication-Results: mx.google.com; spf=pass (google.com: domain of v-cemflo_dlglffhhl_ebaejpk_ebaejpk_a@bounce.rm04.net designates 208.85.49.70 as permitted sender) smtp.mail=v-cemflo_dlglffhhl_ebaejpk_ebaejpk_a@bounce.rm04.net Received: by mail1033c.rm04.net (PowerMTA(TM) v3.5r8) id hkesn40iiksc for <john@montgomerysoftware.co
                        'm>; Tue, 24 Feb 2009 04:10:10 -0500 (envelope-from <v-cemflo_dlglffhhl_ebaejpk_ebaejpk_a@bounce.rm04.net>) Message-ID: <17662966.273104581235466610272.JavaMail.app@rbg11.atlis1> Date: Tue, 24 Feb 2009 04:10:10 -0500 (EST) From: Handango Champion <champion@handango.com> Reply-To: champion@handango.com To: john@montgomerysoftware.com Subject: John: Top apps & new savings for your Windows Mobile device MIME-Version: 1.0 Content-Type: multipart/alternative;  	boundary="----=_Part_210620_13175446.1235466607022" x-job: 2409918 x-mid: 2409918 List-Unsubscribe: <mailto:v-cemflo_dlglffhhl_ebaejpk_ebaejpk_a@bounce.rm04.net?subject=Unsubscribe>"
                        Dim msg As aspNetMime.MimeMessage
                        Dim dtStartDL, dtStopDL As Date
                        Try
                            If AppSettings.EnableVerboseLogging Then
                                Log("About to get next message: " & intCounter.ToString("#,##0"))
                            End If
                            If AppSettings.EmailDownloadLimit Then
                                strHeaders = popServer.GetHeaders(intCounter)
                                Dim mime As aspNetMime.MimeMessage = aspNetMime.MimeMessage.ParseString(strHeaders)
                                Dim ts As TimeSpan = Date.UtcNow - mime.ReceivedDate
                                If ts.TotalHours > 24 Then
                                    Continue For '-- this msg is too old, skip it
                                End If
                            End If

                            Dim intMessageSize As Integer = popServer.MessageSize(intCounter)
                            SetStatus("Downloading message " & intCounter - intSkippedMessages + 1 & " of " & intMessagesOnServer - intSkippedMessages & " for " & popToUse.Name & " (size: " & FormatDataSizeString(intMessageSize) & ")")
                            popServer.TimeOut = 15 * 60000 '-- setting timeout to 15 minutes, by default it seems to be 90 seconds
                            dtStartDL = Now
                            msg = popServer.GetMessage(intCounter)
                            popToUse.MessagesReceived += 1

                            '-- This is to show on the menu's tooltip when last got msgs and how many msgs came down that time
                            intMessagesDownloadedThisTime += 1
                            If intMessagesDownloadedThisTime > 0 Then
                                popToUse.LastNumberOfMessagesReceived = intMessagesDownloadedThisTime
                            End If
                            popToUse.LastTimeMessageReceived = Date.Now

                            If AppSettings.EnableVerboseLogging Then
                                Log("Got message: " & intCounter.ToString("#,##0"))
                            End If
                            objReceiveFile = New ReceiveFileDetails(msg, popToUse)
                            If objReceiveFile IsNot Nothing Then
                                m_lstReceiveFileLog.Add(objReceiveFile)
                            End If

                        Catch ex As Exception
                            dtStopDL = Now
                            Log(ex)
                            If ex.InnerException IsNot Nothing Then
                                Log(ex.InnerException)
                            End If
                            intDownloadRequestFailures += 1

                            If AppSettings.EnableVerboseLogging Then
                                Log("Difficult message raw text (A): " & msg.RawText)
                                If msg.Subject IsNot Nothing Then
                                    Log("Difficult message subject (A): " & msg.Subject.ToString())
                                End If
                                ShowMessageBox("The offending message has been logged for review.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If
                            '-- Write out log, if there is anything good
                            'If intDownloadRequestFailures > 0 AndAlso popServer IsNot Nothing And popServer.Log IsNot Nothing Then
                            '    Log("Download Request Failures: " & intDownloadRequestFailures)
                            '    'Log("POP3Log: " & popServer.Log)
                            '    MsgBox("Error Complete")
                            '    Exit Sub
                            'End If
                            Continue For '-- can't process the message if we didn't get it
                        End Try
                        'intMessagesDownloaded += 1

                        '-- For debugging only
                        'Dim strMimeFilename As String = "C:\Temp\test" & Environment.TickCount.ToString & ".eml"
                        'If System.IO.File.Exists(strMimeFilename) Then
                        '    System.IO.File.Delete(strMimeFilename)
                        'End If
                        'msg.SaveToFile(strMimeFilename)

                        '-- See if sender is blocked, if so, just delete and do not save it
                        Dim intImportance As Integer
                        dtStopDL = Now
                        If msg.From Is Nothing Then
                            Log("A message has no From address.")
                            If msg.ReturnPath Is Nothing Then
                                If IsValidEmailAddress(popToUse.Username) Then
                                    msg.From = New aspNetMime.Address(popToUse.Username)
                                Else
                                    msg.From = New aspNetMime.Address("test@test.com") '-- need something
                                End If
                            Else
                                If msg.ReturnPath.Addresses.Count > 0 Then
                                    msg.From = msg.ReturnPath.Addresses(0)
                                Else
                                    msg.From = New aspNetMime.Address("test@test.com") '-- need something
                                End If
                            End If
                        End If
                        Dim senderEntry As AddressBookEntry = ABook.GetContactByAddress(msg.From.EmailAddress) 'GetAddressBookEmailEntry(msg.From.EmailAddress)
                        If senderEntry IsNot Nothing Then
                            If senderEntry.Blocked Then
                                '-- This sender has been blocked, so we will not store this message
                                If popToUse.LeaveOnServer Then
                                    ht.Add(strMessageUniqueID, Nothing)
                                Else
                                    popServer.Delete(intCounter)
                                    lstDeletedMessages.Add(strMessageUniqueID) '-- Only used if we throw exception in the middle of downloading
                                End If
                                Continue For
                            Else
                                senderEntry.LastMessageReceived = Date.UtcNow
                                ABook.Save()

                                intImportance = senderEntry.ImportanceRating
                            End If
                        End If


                        Dim strTMMFilename As String

                        '-- decrypt if the password is stored
                        If msg.MainBody IsNot Nothing AndAlso msg.MainBody.Contains(Crypto.HEADER_TM2TM) Then
                            Dim strDecryptionPassword As String = senderEntry.WebMailPassword
                            If strDecryptionPassword.Length = 0 Then
                                '-- Simply download and they can decrypt when reading
                                strTMMFilename = ConvertEmailToTrulyMail(email:=msg, popID:=popToUse.ID, folderForMessage:=MessageStoreRootPath & popToUse.InBoxPath, tm2tmEncrypted:=True, importing:=False)
                            Else
                                Try
                                    Dim tm2tm As TM2TMMessageContents
                                    Try
                                        tm2tm = DecryptBodyForTM2TM(strDecryptionPassword, msg.MainBody)
                                    Catch ex As Exception
                                        Log(ex)
                                        '-- must be decryption error so we just pick the default and let the next method handle the real problem
                                        tm2tm = New TM2TMMessageContents
                                        tm2tm.Subject = msg.Subject.Value
                                        tm2tm.Body = msg.MainBody
                                    End Try
                                    '-- test for possible incorrect encryption key
                                    strTMMFilename = ConvertEmailToTrulyMail(msg, popToUse.ID, MessageStoreRootPath & popToUse.InBoxPath, tm2tm.Subject, tm2tm.Body, strDecryptionPassword, tm2tmEncrypted:=True, importing:=False)
                                Catch ex As Exception
                                    '-- should be bad encryption key
                                    Log(ex)

                                    '-- We don't want to keep prompting user for a key which they might not have
                                    '   blocking all other email downloads
                                    '   then we will decrypt it when trying to read it

                                End Try
                            End If
                        Else
                            strTMMFilename = ConvertEmailToTrulyMail(msg, popToUse, MessageStoreRootPath & popToUse.InBoxPath, importing:=False, removeDiacritics:=AppSettings.RemoveDiacriticsWhenReceiving)
                        End If



                        Dim tm As TrulyMailMessage = New TrulyMailMessage(strTMMFilename)
                        tm.Importance = intImportance

                        ProcessMessageReceived(tm, objReceiveFile)

                        '-- Now that it has been processed, log the final location, if it even exists
                        objReceiveFile.MessageFilename = tm.Filename

                        '-- if everything went well, then store the message ID if we are to leave messages on the server
                        '   otherwise, delete the message
                        'If popToUse.LeaveOnServer Then
                        '    '-- Unique message ID can actually be duplicated between messages
                        '    If Not ht.Contains(strMessageUniqueID) Then
                        '        ht.Add(strMessageUniqueID, Nothing)
                        '    End If
                        'Else
                        '    popServer.Delete(intCounter)
                        'End If

                        '-- Changing the above block for TM6 so we will always track deleted msgs
                        '   for the Finally block when we have an error after DL

                        '-- Unique message ID can actually be duplicated between messages
                        If Not ht.Contains(strMessageUniqueID) Then
                            lstDeletedMessages.Add(strMessageUniqueID) '-- Only used if we throw exception in the middle of downloading
                        End If
                        If Not popToUse.LeaveOnServer Then
                            Try
                                popServer.Delete(intCounter)
                            Catch ex As Exception
                                Log(ex)
                                If AppSettings.EnableVerboseLogging Then
                                    Log("Difficult message raw text (B): " & msg.RawText)
                                    If msg.Subject IsNot Nothing Then
                                        Log("Difficult message subject (B): " & msg.Subject.ToString())
                                    End If
                                End If
                                ShowMessageBoxAutoClose("There was a problem deleting a message from the server: " & ex.Message, 10)
                                If AppSettings.EnableVerboseLogging Then
                                    ShowMessageBox("The offending message has been logged for review.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                End If
                            End Try
                        End If

                    Next
                End If
            Else
                '-- should not get here
                Application.DoEvents() '-- for breakpoint only
                If AppSettings.EnableVerboseLogging Then
                    Log("popToUse is nothing... should not be")
                End If
            End If

            '-- be nice and release the server's connection
            popServer.Disconnect()

            If intMessagesOnServer = 0 Then
                SetStatus("No new messages to download")
            Else
                SetStatus("Cleaning up")
            End If

            '-- resize columns if we are looking at the inbox for this POP account
            If tnInBox IsNot Nothing Then
                Dim tnCurrentNode As TreeNode = GetCurrentlySelectedTreeViewNode()
                If tnCurrentNode IsNot Nothing Then
                    If tnCurrentNode Is tnInBox Then
                        AutoSizeMessageList()
                    End If
                End If
            End If


            '-- if we fail on many messages
            If intDownloadRequestFailures > 0 AndAlso (Not AppSettings.DoNotShowPOP3DownloadErrorNotice) Then
                Dim strMessage As String = "TrulyMail could not download " & intDownloadRequestFailures.ToString("#,##0") & " message(s)." & _
                                           Environment.NewLine & Environment.NewLine & _
                                           "This is caused by an error in the email server, not in TrulyMail." & _
                                           Environment.NewLine & Environment.NewLine & _
                                           "If you see this problem often, please contact TrulyMail Support."
                Using frm As New NotifyForm(strMessage, NotifyForm.DoNotShowSetting.DoNotShowPOP3DownloadErrorNotice)
                    frm.ShowDialog(MainFormReference)
                End Using
            End If

            '-- Write out log, if there is anything good
            'If intDownloadRequestFailures > 0 AndAlso popServer IsNot Nothing And popServer.Log IsNot Nothing Then
            '    Log("Download Request Failures: " & intDownloadRequestFailures)
            '    Log("POP3Log: " & popServer.Log)
            'End If

        Catch ex As Exception
            Log(ex)
            If popServer IsNot Nothing And popServer.Log IsNot Nothing Then
                Log("POP3Log: " & popServer.Log)
            End If

            ShowMessageBoxAutoClose("There was an error downloading your messages." & CONTACT_TRULYMAIL_MESSAGE, STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)
        Finally
            '-- If we added any messageIDs to the hashtable, then we need to save it back to disk
            If popToUse IsNot Nothing Then
                If popToUse.LeaveOnServer Then
                    AppSettings.Save()
                Else
                    Try
                        'If popServer IsNot Nothing AndAlso popServer.IsConnected Then
                        '    popServer.CommitDeletes()
                        'End If

                        '-- Adding for TM6 to handle cases where there is an error after download
                        '   if we are connected and call CommitDeletes aspnetpop3 will delete 
                        '   msgs even when .Delete was never called
                        If ht IsNot Nothing Then
                            For Each strMessageUniqueID As String In lstDeletedMessages
                                ht.Add(strMessageUniqueID, Nothing)
                            Next
                            AppSettings.Save()
                        End If
                    Catch ex As Exception
                        Log(ex)
                        If popServer IsNot Nothing And popServer.Log IsNot Nothing Then
                            Log("POP3Log: " & popServer.Log)
                        End If

                        '-- Since we might simply have lost our internet connection mid-stream
                        '   we need to mark the download messages as downloaded
                        '   so we do not download again.
                        If ht IsNot Nothing Then
                            For Each strMessageUniqueID As String In lstDeletedMessages
                                ht.Add(strMessageUniqueID, Nothing)
                            Next
                            AppSettings.Save()
                        End If
                    End Try
                End If

                If boolAccountChecked Then
                    popToUse.LastChecked = Date.Now
                End If
            End If

        End Try
    End Sub
    Private Sub AutoSizeMessageList()
        If AppSettings.AutoSizeColumnsMessageList Then
            If InvokeRequired Then
                Dim deleg As New NoParamSubDelegate(AddressOf AutoSizeMessageList)
                Invoke(deleg)
            Else
                For Each col As BrightIdeasSoftware.OLVColumn In olvMessages.ColumnsInDisplayOrder
                    If col Is olvColumnSubject Then
                        Dim intWidth As Integer = col.Width
                        col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                        col.Width += 26
                    Else
                        AutoSizeColumn(col, True)
                    End If
                Next
                AutoSizeColumn(olvMessages.Columns(olvMessages.Columns.Count - 1), True) '-- do not expand final column
            End If
        End If
    End Sub
    Private Delegate Function GetCurrentlySelectedTreeViewNodeCallback() As TreeNode
    Private Function GetCurrentlySelectedTreeViewNode() As TreeNode
        If InvokeRequired Then
            Dim deleg As New GetCurrentlySelectedTreeViewNodeCallback(AddressOf GetCurrentlySelectedTreeViewNode)
            Return Invoke(deleg)
        Else
            Return tvFolders.SelectedNode
        End If
    End Function
    Private Delegate Sub AddTrulyMailMessageToListView2Callback(ByVal tm As TrulyMailMessage, ByVal folderPath As String)
    Private Sub AddTrulyMailMessageToListView(ByVal tm As TrulyMailMessage, ByVal folderPath As String)
        If InvokeRequired Then
            Dim deleg As New AddTrulyMailMessageToListView2Callback(AddressOf AddTrulyMailMessageToListView)
            Invoke(deleg, tm, folderPath)
        Else
            If folderPath.Length > 0 Then

                If Not tm.Sent Then
                    NotifyUserNewMessageReceived(1)
                End If

                Dim tnCurrentNode As TreeNode = GetCurrentlySelectedTreeViewNode()
                If tnCurrentNode IsNot Nothing Then
                    If UnQualifyPath(tnCurrentNode.Tag.ToString.ToLower()) = UnQualifyPath(folderPath.ToLower()) Then
                        olvMessages.AddObject(tm)
                        olvMessages.RefreshObject(tm)
                        If olvMessages.Items.Count = 1 Then
                            AutoSizeMessageList()
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Function GetTreeNodeByPath(ByVal parentNode As TreeNode, ByVal directoryFullPath As String) As TreeNode
        If parentNode.Tag Is Nothing Then
            Return Nothing
        Else
            If parentNode.Nodes.Count > 0 Then
                For Each tn2 As TreeNode In parentNode.Nodes
                    Dim nodeReturn As TreeNode = GetTreeNodeByPath(tn2, directoryFullPath)
                    If nodeReturn IsNot Nothing Then
                        Return nodeReturn
                    End If
                Next
            End If

            If QualifyPath(parentNode.Tag.ToString).ToLower = QualifyPath(directoryFullPath).ToLower Then
                Return parentNode
            End If
        End If
    End Function
    Private Function GetTreeNodeByPath(ByVal directoryFullPath As String) As TreeNode
        For Each tn As TreeNode In tvFolders.Nodes
            '-- scan children
            If tn.Nodes.Count > 0 Then
                For Each tn2 As TreeNode In tn.Nodes
                    Dim nodeReturn As TreeNode = GetTreeNodeByPath(tn, directoryFullPath)
                    If nodeReturn IsNot Nothing Then
                        Return nodeReturn
                    End If
                Next
            End If

            If QualifyPath(tn.Tag.ToString).ToLower = QualifyPath(directoryFullPath).ToLower Then
                Return tn
            End If
        Next
        Return Nothing
    End Function

    Private Sub bgwDownloadPOP_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwDownloadPOP.DoWork
        Try
            Dim strPOPAccountID As String = e.Argument.ToString()
            GetNewMessagesFromPOPAccount(strPOPAccountID)
        Catch ex As Exception
            Log("Error bgwDownloadPOP_DoWork: " & ex.ToString)
        End Try
    End Sub

    Private Sub bgwDownloadPOP_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwDownloadPOP.RunWorkerCompleted
        SetStatus(STATUS_READY)
        StopProcessing()
    End Sub
    Private Sub CheckTrulyMailAndAllEmailNow()
        CheckAllEmailAccounts(EmailCheckingEnum.ForceAll)
    End Sub
    Private Sub CheckAllEmailAccounts(ByVal checkType As EmailCheckingEnum)
        For Each pop As POPProfile In AppSettings.POPProfiles
            If m_boolStopProcessing Then
                Exit Sub
            End If
            Select Case checkType
                Case EmailCheckingEnum.AtStartup
                    If pop.DownloadOnStartup Then
                        GetNewMessagesFromPOPAccount(pop.ID)
                    End If
                Case EmailCheckingEnum.ForceAll
                    If pop.IncludeInReceiveAll Then
                        GetNewMessagesFromPOPAccount(pop.ID)
                    End If
                Case EmailCheckingEnum.DueToCheck
                    If pop.DownloadAtInterval Then
                        '-- calculate time due for next check, if past that time, then check
                        Dim dtTarget As Date = pop.LastChecked.AddMinutes(pop.DownloadInterval)
                        If dtTarget <= Date.Now Then
                            GetNewMessagesFromPOPAccount(pop.ID)
                        End If
                    End If
            End Select
        Next
    End Sub

    Private Sub SendReceiveAllAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendReceiveAllAccountsToolStripMenuItem.Click
        If bgwReceive.IsBusy Then
            'ShowMessageBoxAutoClose("Please wait until the current operation has completed.", 5)
            ShowOpacityNotice("Please wait until the current operation has completed.", 1)
        Else
            SendReceiveTrigger = SendReceiveTriggerEnum.Manual
            SendReceiveTrulyMailPlusEmail(EmailCheckingEnum.ForceAll)
        End If
    End Sub

    Private Sub bgwCheckAllEmail_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwCheckAllEmail.DoWork
        Dim checkType As EmailCheckingEnum = CType(e.Argument, EmailCheckingEnum)
        CheckAllEmailAccounts(checkType)
    End Sub

    Private Sub bgwCheckAllEmail_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwCheckAllEmail.RunWorkerCompleted
        tmrSendReceive.Start() '-- restart the timer for checking for new messages
        SetStatus(STATUS_READY)
    End Sub

    Private Sub SendReceiveToolStripSplitButton_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendReceiveToolStripSplitButton.ButtonClick
        If bgwReceive.IsBusy Then
            'ShowMessageBoxAutoClose("Please wait until the current operation has completed.", 5)
            ShowOpacityNotice("Please wait until the current operation has completed.", 1)
        Else
            SendReceiveTrigger = SendReceiveTriggerEnum.Manual
            SendReceiveTrulyMailPlusEmail(EmailCheckingEnum.ForceAll)
        End If
    End Sub

    Private Sub CreateChangeMasterPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateChangeMasterPasswordToolStripMenuItem.Click
        If Not AppSettings.EncryptSettingsFile Then
            '-- We do not encrypt now so give fair warning what user is getting into
            If ShowMessageBox("Your Startup Password will be REQUIRED to start TrulyMail in the future." & _
                                       Environment.NewLine & Environment.NewLine & _
                                       "Are you sure you want to set a Startup Password?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                ApplyMasterPassword(Me)
            End If
        Else
            ApplyMasterPassword(Me)
        End If
    End Sub

    Private Sub ReplyToSenderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplyToSenderToolStripMenuItem.Click
        ReplyToSender()
    End Sub

    Private Sub ReplyToAddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ReplyToAll()
    End Sub

    Private Sub ForwardMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForwardMessageToolStripMenuItem.Click
        Forward()
    End Sub

    Private Sub DeleteMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMessageToolStripMenuItem.Click
        DeleteCurrentlySelectedMessages()
    End Sub


    Private Sub MarkMessageReadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkMessageReadToolStripMenuItem.Click
        MarkSelectedMessagesReadUnread(False)
    End Sub

    Private Sub MarkMessageUnreadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkMessageUnreadToolStripMenuItem.Click
        MarkSelectedMessagesReadUnread(True)
    End Sub

    Private Sub MessageToolStripMenuItem_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageToolStripMenuItem.DropDownOpened
        '-- if one message is selected
        '   disable either mark read/unread based on current message's status
        '-- If multiple messages are selected, then canculate what is best
        Dim list As ArrayList = GetCurrentlySelectedMessages()
        Select Case list.Count
            Case 0
                MarkMessageReadToolStripMenuItem.Enabled = False
                MarkMessageUnreadToolStripMenuItem.Enabled = False
                OpenMessageToolStripMenuItem.Enabled = False
                DeleteMessageToolStripMenuItem.Enabled = False
                ReplyToSenderToolStripMenuItem.Enabled = False
                ReplyMessageToAllToolStripMenuItem.Enabled = False
                ForwardMessageToolStripMenuItem.Enabled = False
                AddNotesToMessageToolStripMenuItem.Enabled = False
                ReadMessageContentsToolStripMenuItem.Enabled = False
            Case 1
                Dim tm As TrulyMailMessage = list(0)
                MarkMessageReadToolStripMenuItem.Enabled = Not tm.Read
                MarkMessageUnreadToolStripMenuItem.Enabled = tm.Read
                OpenMessageToolStripMenuItem.Enabled = True
                DeleteMessageToolStripMenuItem.Enabled = True
                AddNotesToMessageToolStripMenuItem.Enabled = True
                ReadMessageContentsToolStripMenuItem.Enabled = tm.MessageType = MessageType.Communication OrElse tm.MessageType = MessageType.Draft
                ''-- disable reply and reply to all if sender is current user
                ''-- also disable reply if sender is server
                'ReplyToSenderToolStripMenuItem.Enabled = Not tm.Sent AndAlso Not tm.RecipientNames.Contains(SERVER_FULLNAME) AndAlso tm.MessageType = MessageType.Communication
                'ReplyMessageToAllToolStripMenuItem.Enabled = Not tm.Sent AndAlso Not tm.RecipientNames.Contains(SERVER_FULLNAME) AndAlso tm.MessageType = MessageType.Communication
                'ForwardMessageToolStripMenuItem.Enabled = tm.MessageType = MessageType.Communication
            Case Else
                Dim boolAtLeastOneRead As Boolean = False
                Dim boolAtLeaseOneUnread As Boolean = False
                For Each tm As TrulyMailMessage In list
                    If tm.Read Then
                        boolAtLeastOneRead = True
                    Else
                        boolAtLeaseOneUnread = True
                    End If
                Next
                MarkMessageReadToolStripMenuItem.Enabled = boolAtLeaseOneUnread
                MarkMessageUnreadToolStripMenuItem.Enabled = boolAtLeastOneRead
                OpenMessageToolStripMenuItem.Enabled = True
                DeleteMessageToolStripMenuItem.Enabled = True
                ReplyToSenderToolStripMenuItem.Enabled = False
                ReplyMessageToAllToolStripMenuItem.Enabled = False
                ForwardMessageToolStripMenuItem.Enabled = False
                AddNotesToMessageToolStripMenuItem.Enabled = False
                ReadMessageContentsToolStripMenuItem.Enabled = False
        End Select

        'ReadMessagePauseToolStripButton.Enabled = ReadMessagePauseToolStripMenuItem.Enabled
        'ReadMessageResumeToolStripButton.Enabled = ReadMessageResumeToolStripMenuItem.Enabled
    End Sub

    Private Sub olvMessages_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles olvMessages.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim objFilenames As Object = e.Data.GetData(DataFormats.FileDrop)
            Dim strFilenames() As String = CType(objFilenames, String())
            Dim msg As IComposeForm = NewMessage()
            Application.DoEvents()
            For Each strFilename As String In strFilenames
                msg.AddAttachmentToList(strFilename, True)
            Next
        End If
    End Sub

    Private Sub olvMessages_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles olvMessages.DragOver
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        '-- Move back the last group of moved messages
        Dim strSourceFolder As String
        Dim strDestinationFolder As String

        For Each message As MessageRelocation In DeletedMessagesForUndo(DeletedMessagesForUndo.Count - 1).Messages
            '-- now, undo the move for each message
            If System.IO.File.Exists(message.FromFilename) AndAlso System.IO.File.Exists(message.ToFilename) Then
                '-- file is already at destination, delete that file so we can restore properly
                DeleteLocalFile(message.FromFilename)
            End If

            '-- only try to restore the file if it actually exists
            If System.IO.File.Exists(message.ToFilename) Then
                System.IO.File.Move(message.ToFilename, message.FromFilename)
                strSourceFolder = System.IO.Path.GetDirectoryName(message.FromFilename)
                strDestinationFolder = System.IO.Path.GetDirectoryName(message.ToFilename)
            End If
        Next

        '-- now, remove the last entry from the list
        DeletedMessagesForUndo.RemoveAt(DeletedMessagesForUndo.Count - 1)
        SetUndoTextAndStatus()
        ShowCurrentFolderContents()

        Dim tn As TreeNode
        Try
            tn = GetTreeNodeByPath(strSourceFolder)
            If tn IsNot Nothing Then
                ShowUnreadOnNodeText(tn, System.IO.Path.GetFileName(UnQualifyPath(tn.Tag.ToString)))
            End If
            tn = GetTreeNodeByPath(strDestinationFolder)
            If tn IsNot Nothing Then
                ShowUnreadOnNodeText(tn, System.IO.Path.GetFileName(UnQualifyPath(tn.Tag.ToString)))
            End If
        Catch ex As Exception
            Log(ex)
            Log("Exception ignored")
        End Try

    End Sub

    Private Sub MainForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            StopProcessingToolStripButton.PerformClick()
        End If
    End Sub

    Private Sub tmrAutoEmptyTrash_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles tmrAutoEmptyTrash.Elapsed
        Try
            tmrAutoEmptyTrash.Stop()
            bgwAutoEmptyTrash.RunWorkerAsync()
        Catch ex As Exception
            Log(ex) '-- no big problem... just try to auto-empty trash and log if there's a problem
            '-- usually problem is the BGW is still busy and stop doesn't happen fast enough
        End Try
    End Sub

    Private Sub bgwAutoEmptyTrash_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwAutoEmptyTrash.DoWork
        '-- Automatically remove from trash messages more than setting number of days old
        Dim dtCutOff As Date = Date.Now.AddDays(AppSettings.TrashDaysToRetain * -1)

        '-- First, get all the files
        Dim loader As New FileListLoader(REGEX_MESSAGE_FILENAME)
        Dim lstFiles As List(Of FileDetails) = loader.GetFilesInPath(TrashRootPath, True)
        Dim fi As System.IO.FileInfo
        For Each fileDetail As FileDetails In lstFiles
            If fileDetail.ModifyDate <= dtCutOff Then
                DeleteLocalMessage(fileDetail.FullName, True, False)
            End If
            Application.DoEvents()
        Next

        MainFormReference.ShowFolderContentsIfCurrent(TrashRootPath)

        '-- next, delete any empty folders
        Dim dirs() As String = System.IO.Directory.GetDirectories(TrashRootPath, "*.*", IO.SearchOption.AllDirectories)
        For Each strDirectoryName As String In dirs
            Dim intDirCount As Integer = System.IO.Directory.GetDirectories(strDirectoryName).Length
            If intDirCount = 0 Then
                Dim intFileCount As Integer = System.IO.Directory.GetFiles(strDirectoryName, "*.*", IO.SearchOption.TopDirectoryOnly).Length
                If intFileCount = 0 Then
                    '-- try to delete
                    Try
                        System.IO.Directory.Delete(strDirectoryName)
                    Catch ex As Exception
                        '-- don't worry if it cannot be deleted, but log for research purposes
                        Log(ex)
                    End Try
                End If
            End If
            Application.DoEvents()
        Next

    End Sub

    Private Sub bgwAutoEmptyTrash_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwAutoEmptyTrash.RunWorkerCompleted
        tmrAutoEmptyTrash.Enabled = AppSettings.AutoEmptyTrash
        CheckTrashIconStatus()
    End Sub

    ''' <summary>
    ''' If a message based on the given filename is in the current message objectlistview, it will be removed
    ''' </summary>
    ''' <param name="messageFilename"></param>
    ''' <remarks></remarks>
    Friend Sub RemoveMessageIfPresent(messageFilename As String)
        '-- This routine replaces a call to ShowFolderContentsIfCurrent when sending
        '   No need to reload the entire folder when we just want to remove one msg from the list
        '   That was causing errors before because while reading to refresh the folder it was trying to save the msg to a new folder (sent)
        Try
            For Each tm As TrulyMailMessage In olvMessages.Objects
                If tm.Filename.ToLower() = messageFilename.ToLower() Then
                    olvMessages.RemoveObject(tm)
                    Exit For '-- No need to continue
                End If
            Next
        Catch ex As Exception
            Log(ex)
            Log("Problem message: " & messageFilename)
            ShowMessageBoxError("Error removing msg")
        End Try
    End Sub


    Private Delegate Sub ShowFolderContentsIfCurrentCallback(ByVal matchingPath As String)

    ''' <summary>
    ''' Refresh current folder if current folder matches the matchingPath passed in, otherwise
    ''' it will just update the unread count
    ''' </summary>
    ''' <param name="matchingPath"></param>
    ''' <remarks></remarks>
    Friend Sub ShowFolderContentsIfCurrent(ByVal matchingPath As String)
        If InvokeRequired Then
            Dim deleg As New ShowFolderContentsIfCurrentCallback(AddressOf ShowFolderContentsIfCurrent)
            Invoke(deleg, matchingPath)
        Else
            If GetCurrentlySelectedTreeViewNode() IsNot Nothing Then
                Dim strCurrentFolderPath As String = GetCurrentlySelectedTreeViewNode.Tag.ToString
                If QualifyPath(matchingPath.ToLower()) = QualifyPath(strCurrentFolderPath.ToLower()) Then
                    'g_boolFileSystemChanged = True
                    ShowCurrentFolderContents()
                Else
                    For Each tn As TreeNode In m_lstInBoxesToUpdate
                        ShowUnreadOnNodeText(tn, System.IO.Path.GetFileName(UnQualifyPath(tn.Tag.ToString)))
                    Next
                    m_lstInBoxesToUpdate.Clear()
                    ShowUnreadOnNodeText(GetTreeNodeByPath(UnQualifyPath(matchingPath)), System.IO.Path.GetFileName(UnQualifyPath(matchingPath)))
                End If
            Else
                For Each tn As TreeNode In m_lstInBoxesToUpdate
                    ShowUnreadOnNodeText(tn, System.IO.Path.GetFileName(UnQualifyPath(tn.Tag.ToString)))
                Next
                m_lstInBoxesToUpdate.Clear()
            End If
        End If
    End Sub
    'Private Delegate Sub LazyUpdateOfUnreadCallback(ByVal node As TreeNode)
    ''' <summary>
    ''' Updates the unread count on this single node. This is called from a Timers.Timer
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LazyUpdateOfUnread(ByVal node As TreeNode)
        'If InvokeRequired Then
        '    Dim deleg As New LazyUpdateOfUnreadCallback(AddressOf LazyUpdateOfUnread)
        '    Invoke(deleg, node)
        'Else
        ShowUnreadOnNodeText(node, System.IO.Path.GetFileName(UnQualifyPath(node.Tag.ToString)))
        'End If
    End Sub

    Private Delegate Sub LazyUpdateOfAddedTreeNodesCallback(node As TreeNode)
    Private Sub LazyUpdateOfAddedTreeNodes(ByVal node As TreeNode)
        If InvokeRequired Then
            Dim deleg As New LazyUpdateOfAddedTreeNodesCallback(AddressOf LazyUpdateOfAddedTreeNodes)
            Invoke(deleg, node)
        Else
            If node.IsExpanded Then '-- only worry about adding nodes if the parent node is expanded (otherwise, it gets added on expand event)
                AddChildrenNodes(node)
            End If
        End If
    End Sub
#Region " Message Loading Logic "
    '-- These three routines
    '   ShowCurrentFolderContents = what is called to start things off (UI logic)
    '   ShowCurrentFolderContentsLoadMessages = called on background thread so it can be canceled (no UI logic)
    '   ShowCurrentFolderContentsFinalize = called after background worker is done to do finally loading (UI logic)
    Friend Class FolderContentData
        Public Messages As List(Of TrulyMailMessage)
        Public TotalMessages As Integer
        Public UnReadMessages As Integer
        Public FolderPath As String
    End Class
    Private m_folderContentData As FolderContentData

    Private WithEvents m_bgwShowFolderContents As New System.ComponentModel.BackgroundWorker
    Private Sub m_bgwShowFolderContents_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles m_bgwShowFolderContents.DoWork
        Try
            ShowCurrentFolderContentsLoadMessages(e.Argument)
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Private Sub m_bgwShowFolderContents_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles m_bgwShowFolderContents.RunWorkerCompleted
        Try
            ShowCurrentFolderContentsFinalize()
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error showing the contents of this folder." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub
    Private Sub ShowCurrentFolderContents()
        If m_boolUsingRichControl Then
            ReadMessageControlRich.CancelMessageLoad()
            ReadMessageControlRich.Hide()
        Else
            ReadMessageControlPlain.CancelMessageLoad()
            ReadMessageControlPlain.Hide()
        End If
        'm_intSelectedMessage = 0

        olvMessages.EmptyListMsg = "Loading folder..." & Environment.NewLine & "This could take minutes for large folders."
        olvMessages.Items.Clear()
        Application.DoEvents()

        '-- set reply buttons, etc. to disabled
        ReplyToolStripButton.Enabled = False
        ReplyToAllToolStripButton.Enabled = False
        ForwardToolStripButton.Enabled = False
        FollowUpToolStripMenuItem.Enabled = False

        If GetCurrentlySelectedTreeViewNode() Is Nothing Then
            tvFolders.SelectedNode = tvFolders.Nodes(0)
        End If
        Dim strFolderPath As String = GetCurrentlySelectedTreeViewNode.Tag.ToString

        Dim boolFirstProcessed As Boolean = False
        Static boolLastRunThroughShowedViewColumn As Boolean = True

        m_folderContentData = Nothing

        If m_bgwShowFolderContents.IsBusy Then
            m_bgwShowFolderContents.CancelAsync()
        End If
        m_bgwShowFolderContents = New System.ComponentModel.BackgroundWorker()
        m_bgwShowFolderContents.WorkerReportsProgress = False
        m_bgwShowFolderContents.WorkerSupportsCancellation = True
        m_bgwShowFolderContents.RunWorkerAsync(strFolderPath)
    End Sub
    Private Sub ShowCurrentFolderContentsLoadMessages(ByVal folderPath As String)
        Try
            Dim lst As New List(Of TrulyMailMessage)
            Dim item As TrulyMailMessage
            Dim intTotalMessages, intUnreadMessages As Integer

            '-- synclock objects to prevent threads from walking on each other
            Dim lockUnread As New Object()
            Dim lockAll As New Object()
            Dim lockErrors As New Object
            Dim lockLstMsgs As New Object
            Dim lockLog As New Object

            Dim strErrors As String = String.Empty



            '-- Uses message index for speed
            Using msgIndex As New MessageIndex(folderPath)
                Dim loader As New FileListLoader(REGEX_MESSAGE_FILENAME)
                '-- TM6 changed to threadsafe list (queue)
                Dim queueFileDetails As New System.Collections.Concurrent.ConcurrentQueue(Of FileDetails)
                Dim lstFileDetails As List(Of FileDetails) = loader.GetFilesInPath(folderPath, False)

                '-- Trying to find a faster way (than iterating the list
                '   http://stackoverflow.com/questions/35388523/fastest-way-to-add-listt-contents-to-concurrentqueuet
                For Each detail As FileDetails In lstFileDetails
                    queueFileDetails.Enqueue(detail)
                Next

                '-- Parallel for even more speed
                System.Threading.Tasks.Parallel.ForEach(queueFileDetails, Sub(fd As FileDetails)
                                                                              Try
                                                                                  If m_bgwShowFolderContents.CancellationPending Then
                                                                                      Exit Sub
                                                                                  End If


                                                                                  '== Speed tracking logic ===
                                                                                  Dim sw As New Stopwatch()
                                                                                  sw.Start()

                                                                                  item = msgIndex.GetMessage(fd)

                                                                                  'SyncLock lockLog
                                                                                  '    Log("Loading message: ~" & sw.ElapsedMilliseconds.ToString("0000") & "~ms: " & AppSettings.EncryptLocalFiles.ToString() & ": " & fd.FullName)
                                                                                  'End SyncLock
                                                                                  '== Speed tracking logic ===



                                                                                  If item IsNot Nothing Then
                                                                                      '-- Not sure if we need to lock when adding to a list like this
                                                                                      SyncLock lockLstMsgs
                                                                                          lst.Add(item)
                                                                                      End SyncLock

                                                                                      If Not item.Read Then
                                                                                          SyncLock lockUnread
                                                                                              intUnreadMessages += 1
                                                                                          End SyncLock
                                                                                      End If

                                                                                      SyncLock lockAll
                                                                                          intTotalMessages += 1
                                                                                      End SyncLock
                                                                                  End If
                                                                              Catch ex As Exception
                                                                                  SyncLock lockErrors
                                                                                      strErrors &= ex.Message & Environment.NewLine & ex.StackTrace & Environment.NewLine
                                                                                  End SyncLock
                                                                              End Try
                                                                          End Sub)



                'For Each fd As FileDetails In lstFileDetails
                '    If m_bgwShowFolderContents.CancellationPending Then
                '        Exit Sub
                '    End If

                '    item = msgIndex.GetMessage(fd)

                '    If item IsNot Nothing Then
                '        lst.Add(item)

                '        If Not item.Read Then
                '            intUnreadMessages += 1
                '        End If

                '        intTotalMessages += 1
                '    End If
                'Next

                If strErrors.Length > 0 Then
                    Log("Error(s) in ShowCurrentFolderContentsLoadMessages: " & strErrors)
                End If

                msgIndex.Save()
            End Using

            m_folderContentData = New FolderContentData
            m_folderContentData.Messages = lst
            m_folderContentData.TotalMessages = intTotalMessages
            m_folderContentData.UnReadMessages = intUnreadMessages
            m_folderContentData.FolderPath = folderPath

            Dim folder As FolderState = GetFolderState(folderPath)
            folder.UnreadCount -= intUnreadMessages

        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Sub

    Private Sub ShowCurrentFolderContentsFinalize()
        Dim intErrorLocation As Integer
        Try
            Me.olvMessages.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf MainRowFormatter)
            Me.olvColumnSize.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterSize)
            Me.olvColumnMessageDateSent.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf AspectToStringConverterDate)
            Me.olvColumnSubject.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf MessageImageGetter)
            Me.olvColumnTransportType.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf TransportTypeImageGetter)
            Me.olvColumnHasNotes.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf HasNotesImageGetter)
            Me.olvColumnHasNotes.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf NoTextAspectToStringConverter)
            Me.olvcolReadButton.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf AspectToStringConverterMessageRead)

            intErrorLocation = 1

            '-- format dates
            olvColumnMessageDateSent.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf FormatDateTimeDependingForOLV)

            intErrorLocation = 2

            olvMessages.EmptyListMsg = "This folder is empty"

            intErrorLocation = 3

            If m_folderContentData IsNot Nothing Then
                If m_folderContentData.Messages.Count > 0 Then
                    If m_folderContentData.Messages(0).Sent Then
                        olvColumnOtherParties.Text = "Recipients"
                    Else
                        olvColumnOtherParties.Text = "Sender"
                    End If
                End If

                intErrorLocation = 4

                If m_folderContentData.Messages IsNot Nothing Then
                    Me.olvMessages.SetObjects(m_folderContentData.Messages)
                End If

                intErrorLocation = 5

                If m_folderContentData Is Nothing Then
                    Log("m_folderContentData is nothing")
                ElseIf m_folderContentData.FolderPath Is Nothing Then
                    Log("m_folderContentData.FolderPath is nothing")
                ElseIf m_folderContentData.Messages Is Nothing Then
                    Log("m_folderContentData.Messages is nothing")
                End If

                Try

                    '-- Show unread messages in InBox and invites received
                    Select Case QualifyPath(m_folderContentData.FolderPath).ToLower()
                        '-- Inbox
                        Case QualifyPath(m_nodeInBox.Tag.ToString.ToLower())
                            ShowUnreadOnNodeText(m_nodeInBox, INBOX_NAME)
                        Case Else
                            '-- strange to use getfilename but since the tag containts the path to the folder, .getdirectory returns the parent folder
                            If GetCurrentlySelectedTreeViewNode() Is m_nodeOutBox Then
                                '-- skip this folder
                            ElseIf GetCurrentlySelectedTreeViewNode() Is m_nodeDrafts Then
                                '-- skip this folder
                            Else
                                Dim strFolderName As String = System.IO.Path.GetDirectoryName(QualifyPath(GetCurrentlySelectedTreeViewNode.Tag.ToString()))
                                ShowUnreadOnCurrentNodeText()
                            End If
                    End Select
                Catch ex As Exception
                    Log(ex)
                    If m_folderContentData.FolderPath IsNot Nothing Then
                        Log("Error ignored at ShowCurrentFolderContentsFinalize location 5: " & m_folderContentData.FolderPath)
                    Else
                        Log("Error ignored at ShowCurrentFolderContentsFinalize location 5")
                    End If
                End Try

                intErrorLocation = 6

                Try
                    SetMessageCount(m_folderContentData.TotalMessages, m_folderContentData.UnReadMessages)
                Catch ex As Exception
                    Log(ex)
                    Log("Error ignored at ShowCurrentFolderContentsFinalize location 6")
                End Try

                intErrorLocation = 7

            End If

            '-- We should always show unsent and drafts, unless they were just done

            intErrorLocation = 8

            ShowUnreadOnNodeText(m_nodeOutBox, OUTBOX_NAME)
            ShowUnreadOnNodeText(m_nodeDrafts, DRAFTS_FOLDER_NAME)
            intErrorLocation = 9

            For Each tn As TreeNode In m_lstInBoxesToUpdate
                ShowUnreadOnNodeText(tn, System.IO.Path.GetFileName(UnQualifyPath(tn.Tag.ToString)))
            Next

            intErrorLocation = 10

            m_lstInBoxesToUpdate.Clear()

            intErrorLocation = 11

            UpdateReplyToolStripItems()

            intErrorLocation = 12

            SelectNewCurrentlySelectedMessage()

            intErrorLocation = 13

            '-- Only resize message list if there are messages
            '   if no messages, leave columns sized as they were
            If m_folderContentData IsNot Nothing AndAlso m_folderContentData.TotalMessages > 0 Then
                AutoSizeMessageList()
            End If


            intErrorLocation = 14

            m_folderContentData = Nothing
        Catch ex As Exception
            Log("Error location: " & intErrorLocation.ToString())
            Log(ex)
            Throw ex
        End Try
    End Sub
#End Region
    ''' <summary>
    ''' Selects what should be selected after deletes, etc.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SelectNewCurrentlySelectedMessage()
        Try
            If m_intSelectedMessage < 0 Then
                m_intSelectedMessage = 0
            ElseIf m_intSelectedMessage >= olvMessages.Items.Count Then
                m_intSelectedMessage = 0
            End If

            If olvMessages.Items.Count > 0 Then
                olvMessages.SelectedIndex = m_intSelectedMessage
                olvMessages.FocusedItem = olvMessages.SelectedItem
                olvMessages.EnsureVisible(m_intSelectedMessage)
            Else
                If m_boolUsingRichControl Then
                    ReadMessageControlRich.Visible = False
                Else
                    ReadMessageControlPlain.Visible = False
                End If
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Private Sub SendReceiveToolStripSplitButton_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendReceiveToolStripSplitButton.DropDownOpening
        '-- On each POP account, show when last checked
        For Each mi As ToolStripItem In SendReceiveToolStripSplitButton.DropDownItems
            If mi.Tag IsNot Nothing Then '-- only deal with POP accounts here
                If mi.Tag.ToString() = "rss" Then
                    If m_strRSSLastCheckedForDisplay.Length > 0 Then
                        Dim ts As TimeSpan = Date.Now - m_dtRSSLastChecked
                        If ts.TotalMilliseconds > 0 Then
                            m_strRSSLastCheckedForDisplay = FormatTimeSpan(ts) & " ago"
                        End If
                        mi.Text = "RSS and News Feeds     (checked " & m_strRSSLastCheckedForDisplay & ")"
                    Else
                        mi.Text = "RSS and News Feeds"
                    End If
                Else
                    '-- Email account
                    For intCounter As Integer = 0 To AppSettings.POPProfiles.Count - 1
                        If AppSettings.POPProfiles(intCounter).ID = mi.Tag.ToString Then
                            Dim strLastChecked As String = AppSettings.POPProfiles(intCounter).LastCheckedForDisplay
                            If strLastChecked.Length > 0 Then
                                mi.Text = AppSettings.POPProfiles(intCounter).Name & "     (checked " & strLastChecked & ")"
                                '--2018 Removing since tooltips cause problems under Wine
                                'If AppSettings.POPProfiles(intCounter).LastTimeMessageReceivedForDisplay.Length > 0 Then
                                '    Select Case AppSettings.POPProfiles(intCounter).LastNumberOfMessagesReceived
                                '        Case 0
                                '            mi.ToolTipText = "No messages received since startup"
                                '        Case 1
                                '            mi.ToolTipText = "1 message received " & AppSettings.POPProfiles(intCounter).LastTimeMessageReceivedForDisplay
                                '        Case Else
                                '            mi.ToolTipText = AppSettings.POPProfiles(intCounter).LastNumberOfMessagesReceived.ToString("#,##0") & " messages received " & AppSettings.POPProfiles(intCounter).LastTimeMessageReceivedForDisplay
                                '    End Select
                                'End If
                            Else
                                mi.Text = AppSettings.POPProfiles(intCounter).Name
                            End If
                            Exit For
                        End If
                    Next
                End If
            ElseIf mi.Text.StartsWith("TrulyMail") Then
                If m_strTrulyMailLastCheckedForDisplay.Length > 0 Then
                    Dim ts As TimeSpan = Date.Now - m_dtTrulyMailLastChecked
                    If ts.TotalMilliseconds > 0 Then
                        m_strTrulyMailLastCheckedForDisplay = FormatTimeSpan(ts) & " ago"
                    End If
                    mi.Text = "TrulyMail     (checked " & m_strTrulyMailLastCheckedForDisplay & ")"
                Else
                    mi.Text = "TrulyMail"
                End If
            End If
        Next
    End Sub
    Private Sub UpdateUnreadCountAllRootNodes()
        Try
            Dim tn As TreeNode
            Dim strFolderName As String
            For Each tn In tvFolders.Nodes
                strFolderName = System.IO.Path.GetFileName(UnQualifyPath(tn.Tag.ToString))
                ShowUnreadOnNodeText(tn, strFolderName)
                Application.DoEvents()
            Next
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Private Sub FollowUpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FollowUpToolStripMenuItem.Click
        FollowUp()
    End Sub

    Private Sub EmptyTrashToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmptyTrashToolStripMenuItem1.Click
        EmptyTrash()
    End Sub

    Private Sub m_tmrLazyUnreadUpdater_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles m_tmrLazyUnreadUpdater.Elapsed
        '-- System.Timers.Timer should run on background thread
        m_tmrLazyUnreadUpdater.Stop()
        If m_lstPathsToUpdate.Count > 0 Then
            LazyUpdateOfUnread(m_lstPathsToUpdate(0))
            m_lstPathsToUpdate.RemoveAt(0)
        End If
        m_tmrLazyUnreadUpdater.Start()
    End Sub

    Private Sub tvFolders_BeforeSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvFolders.BeforeSelect
        Dim tn As TreeNode = GetCurrentlySelectedTreeViewNode()
        If tn IsNot Nothing Then
            '-- Do this only if current node is not outbox or drafts
            '   because those two folders have special rules
            If tn IsNot m_nodeOutBox AndAlso tn IsNot m_nodeDrafts Then
                ShowUnreadOnCurrentNodeText()
            End If
        End If
    End Sub

    Private Sub SetMessagePreview(ByVal show As Boolean, ByVal vertical As Boolean)
        AppSettings.ShowMessagePreviewPane = show
        AppSettings.MessagePreviewPaneVertical = vertical
        AppSettings.Save()

        If show Then
            '-- always horizontal now
            MessagePreviewNoneToolStripMenuItem.Checked = False
            MessagePreviewHorizontalToolStripMenuItem.Checked = True
            MessagePreviewVerticalToolStripMenuItem.Checked = False
            SplitContainer3.Panel2Collapsed = False
            If m_boolUsingRichControl Then
                ReadMessageControlRich.Parent = SplitContainer3.Panel2

                llblOpenSelectedMessages.Parent = ReadMessageControlRich.Parent
                ReadMessageControlRich.BringToFront()
                LoadMessagePreview()
                ReadMessageControlRich.ReadMessageActionSplitterDistance = AppSettings.ReadMessagePreviewActionSplitterDistance
                ReadMessageControlRich.ReplyModeVisible = AppSettings.ReadMessagePreviewActionVisible
            Else
                ReadMessageControlPlain.Parent = SplitContainer3.Panel2

                llblOpenSelectedMessages.Parent = ReadMessageControlPlain.Parent
                ReadMessageControlPlain.BringToFront()
                LoadMessagePreview()
                ReadMessageControlPlain.ReadMessageActionSplitterDistance = AppSettings.ReadMessagePreviewActionSplitterDistance
                ReadMessageControlPlain.ReplyModeVisible = AppSettings.ReadMessagePreviewActionVisible
            End If
        Else
            '-- None
            MessagePreviewNoneToolStripMenuItem.Checked = True
            MessagePreviewHorizontalToolStripMenuItem.Checked = False
            MessagePreviewVerticalToolStripMenuItem.Checked = False
            SplitContainer3.Panel2Collapsed = True
        End If
    End Sub

    Private Sub MessagePreviewNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessagePreviewNoneToolStripMenuItem.Click
        SetMessagePreview(False, False)
    End Sub

    Private Sub MessagePreviewVerticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessagePreviewVerticalToolStripMenuItem.Click
        SetMessagePreview(True, True)
    End Sub

    Private Sub MessagePreviewHorizontalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessagePreviewHorizontalToolStripMenuItem.Click
        SetMessagePreview(True, False)
    End Sub

    Private Sub SplitContainer3_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer3.SplitterMoved
        'If AppSettings IsNot Nothing AndAlso Me.Text.EndsWith(AppSettings.Address) Then
        If m_boolFormFullyLoaded AndAlso AppSettings IsNot Nothing Then
            AppSettings.MessagePreviewPaneSize = SplitContainer3.SplitterDistance
            AppSettings.Save()
        End If
    End Sub

    Private Sub ReadMessageControl1_EnableMessageHeaders(ByVal enabled As Boolean)
        ViewMessageHeadersToolStripMenuItem.Enabled = enabled
    End Sub

    Private Sub ReadMessageControl1_EnableTreatAsReadReceipt(ByVal enabled As Boolean)
        TreatAsReadReceiptToolStripMenuItem.Enabled = enabled
    End Sub

    Private Sub ViewMessageHeadersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewMessageHeadersToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ShowEmailHeaders()
        Else
            ReadMessageControlPlain.ShowEmailHeaders()
        End If
    End Sub

    Private Sub TreatAsReadReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreatAsReadReceiptToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.TreatAsReadReceipt()
        Else
            ReadMessageControlPlain.TreatAsReadReceipt()
        End If
    End Sub

    Private Sub ChangeSubjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeSubjectToolStripMenuItem.Click
        If olvMessages.GetSelectedObject IsNot Nothing Then
            Dim tm As TrulyMailMessage = CType(olvMessages.GetSelectedObject, TrulyMailMessage)
            Dim strNewSubject As String = GetInput("Enter the new subject for this message.", False, tm.Subject)
            If strNewSubject <> Chr(0) Then
                If AppSettings.AddNoteWhenChangingSubject Then
                    If m_boolUsingRichControl Then
                        ReadMessageControlRich.AppendNote("Previous subject: " & tm.Subject)
                    Else
                        ReadMessageControlPlain.AppendNote("Previous subject: " & tm.Subject)
                    End If
                End If

                tm.Subject = strNewSubject

                tm.Save()
                MainFormReference.UpdateMessage(tm)
                olvMessages.RefreshObject(tm)
                LoadMessagePreview()
            End If
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            If ReadMessageControlRich.Visible Then
                ReadMessageControlRich.PrintMessage()
            End If
        Else
            If ReadMessageControlPlain.Visible Then
                ReadMessageControlPlain.PrintMessage()
            End If
        End If
    End Sub

    Private Sub AddNotesToMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNotesToMessageToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.AddNotes()
        Else
            ReadMessageControlPlain.AddNotes()
        End If
    End Sub
    Private Sub MoveSelectedMessages()
        Try
            Dim fbd As New FolderBrowserDialogTM()
            fbd.ShowNewFolderButton = True
            fbd.ShowAllFolders = False
            fbd.Description = "Select new folder for message(s)"
            If AppSettings.LastSelectedFolderInFolderBrowser Is Nothing Then
                fbd.SelectedPath = GetCurrentlySelectedTreeViewNode.Tag.ToString()
            End If

            If fbd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                '-- move message
                Dim strDestinationFolder As String = fbd.SelectedPath
                Dim strSourceFolder As String

                Dim items As System.Collections.ArrayList = olvMessages.GetSelectedObjects
                Dim item As TrulyMailMessage
                Dim strSource, strDestination As String

                '-- prepare undo data
                Dim undo As New UndoMessageDelete()
                undo.ToFolder = System.IO.Path.GetFileName(UnQualifyPath(strDestinationFolder))

                Dim message As MessageRelocation
                Dim intUnreadCount As Integer
                Dim intTotalCount As Integer = items.Count

                For Each item In items
                    strSource = item.Filename
                    If strSourceFolder Is Nothing Then
                        strSourceFolder = System.IO.Path.GetDirectoryName(item.Filename)
                    End If

                    strDestination = QualifyPath(strDestinationFolder) & System.IO.Path.GetFileName(strSource)
                    '-- Overwrite destination file, if it exists
                    If System.IO.File.Exists(strDestination) Then
                        DeleteLocalFile(strDestination)
                    End If

                    '-- prepare undo data
                    message = New MessageRelocation
                    message.FromFilename = strSource
                    message.ToFilename = strDestination
                    undo.Messages.Add(message)

                    Try
                        System.IO.File.Move(strSource, strDestination)
                    Catch ex As Exception
                        '-- Sometimes there will be an error where a message already moved
                        '   so we will just blow past the error, if any comes up
                        Log(ex)
                    End Try

                    '-- Get change in unread count
                    Dim boolRead As Boolean
                    Try
                        Dim xDoc As New Xml.XmlDocument()
                        xDoc.Load(strDestination)
                        Dim strMessageTypeID As String = xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGETYPEID)
                        Dim strRead As String = xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_READ)
                        If strRead = String.Empty Then
                            boolRead = False
                        Else
                            boolRead = Convert.ToBoolean(strRead)
                        End If

                        If Not boolRead Then
                            '-- messages without sizes were not downloaded completely
                            Dim strSize As String = xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGESIZE)
                            If strSize.Length > 0 Then
                                intUnreadCount += 1
                            End If
                        End If
                    Catch ex As System.Xml.XmlException
                        Log("Malformed XML. Deleting old file: " & strDestination)
                        DeleteLocalMessage(strDestination, False, False)
                    Catch ex As Exception
                        '-- problem reading file
                        Log(ex)
                        Log("Filename: " & strDestination)
                        '-- ignore the error
                    End Try
                    Application.DoEvents() '-- to make it more responsive to user
                Next

                If strSource IsNot Nothing Then
                    undo.FromFolder = System.IO.Path.GetFileName(UnQualifyPath(System.IO.Path.GetDirectoryName(strSource)))
                    DeletedMessagesForUndo.Add(undo)
                    SetUndoTextAndStatus()
                End If

                m_boolPreventLoadingPreview = True
                olvMessages.RemoveObjects(items)
                m_boolPreventLoadingPreview = False


                '-- Update folderstate for the source and destination folders
                '-- instead of recounding the two folders, just adjust by what we moved
                Dim folderState As FolderState
                folderState = GetFolderState(strDestinationFolder)
                folderState.UnreadCount += intUnreadCount
                folderState.TotalCount += intTotalCount

                folderState = GetFolderState(strSourceFolder)
                folderState.UnreadCount -= intUnreadCount
                folderState.TotalCount -= intTotalCount

                '-- Recount on the two nodes in question
                Dim nodeDestination = GetTreeNodeByPath(strDestinationFolder)
                'If nodeDestination IsNot Nothing Then
                '    ShowUnreadOnNodeText(nodeDestination, System.IO.Path.GetFileName(UnQualifyPath(nodeDestination.Tag.ToString)))
                'End If

                '-- Don't force file system scan, just reduce the unread count by the total moved
                If nodeDestination IsNot Nothing Then
                    '-- Node is not exposed at this time (parent node is collapsed)
                    ShowUnreadOnNodeText(nodeDestination, System.IO.Path.GetFileName(UnQualifyPath(nodeDestination.Tag.ToString)), False)
                End If
                SetNodeDisplayText(GetCurrentlySelectedTreeViewNode, System.IO.Path.GetFileName(UnQualifyPath(GetCurrentlySelectedTreeViewNode.Tag.ToString)), folderState.UnreadCount)

                '-- update unread and total count for current
                SetMessageCount(folderState.TotalCount, folderState.UnreadCount)

                'ShowUnreadOnNodeText(GetCurrentlySelectedTreeViewNode, System.IO.Path.GetFileName(UnQualifyPath(GetCurrentlySelectedTreeViewNode.Tag.ToString)), False)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error moving the message. " & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
            ShowCurrentFolderContents() '-- reload the folder since the message did not move
        End Try
    End Sub
    Private Sub MoveToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveToToolStripMenuItem.Click
        MoveSelectedMessages()
    End Sub

    Private Sub ReadMessageControl1_ReadMessageActionSplitterDistanceChanged(splitterDistance As Integer) 'Handles ReadMessageControl1.ReadMessageActionSplitterDistanceChanged
        If m_boolFormFullyLoaded Then
            If m_boolUsingRichControl Then
                AppSettings.ReadMessagePreviewActionSplitterDistance = Me.ReadMessageControlRich.ReadMessageActionSplitterDistance
            Else
                AppSettings.ReadMessagePreviewActionSplitterDistance = Me.ReadMessageControlPlain.ReadMessageActionSplitterDistance
            End If
        End If
    End Sub

    Private Sub ReadMessageControl1_SpecialAction(ByVal action As TrulyMail.ReadMessageControl.MessageSpecialActionEnum)
        Try
            Select Case action
                Case ReadMessageControl.MessageSpecialActionEnum.DeleteMessage
                    DeleteCurrentlySelectedMessages()
                Case ReadMessageControl.MessageSpecialActionEnum.FollowUp
                    FollowUp()
                Case ReadMessageControl.MessageSpecialActionEnum.Forward
                    Forward()
                Case ReadMessageControl.MessageSpecialActionEnum.NewMessage
                    NewMessage()
                Case ReadMessageControl.MessageSpecialActionEnum.Reply
                    ReplyToSender()
                Case ReadMessageControl.MessageSpecialActionEnum.ReplyAll
                    ReplyToAll()
                Case ReadMessageControl.MessageSpecialActionEnum.MarkRead
                    '-- TMM object handled the data, now we just refresh the ui
                    If olvMessages.SelectedObjects.Count = 1 Then
                        'MarkSelectedMessagesReadUnread(False)
                        Dim tmm As TrulyMailMessage = CType(olvMessages.SelectedObject, TrulyMailMessage)
                        tmm.Read = True
                    End If
                    olvMessages.RefreshSelectedObjects()
            End Select
        Catch ex As Exception
            Log(ex) '-- just log and continue
        End Try
    End Sub

    Private Sub ViewToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewToolStripMenuItem.DropDownOpening
        Dim boolContinue As Boolean
        If m_boolUsingRichControl Then
            boolContinue = ReadMessageControlRich.Visible
        Else
            boolContinue = ReadMessageControlPlain.Visible
        End If

        If boolContinue Then
            Dim list As ArrayList = GetCurrentlySelectedMessages()
            If list.Count = 1 Then
                Dim tm As TrulyMailMessage = list(0)
                ViewMessageHeadersToolStripMenuItem.Enabled = (tm.TransportType = MessageTransportType.Email)
            Else
                ViewMessageHeadersToolStripMenuItem.Enabled = False
            End If
        Else
            ViewMessageHeadersToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub FolderTreeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FolderTreeToolStripMenuItem.Click
        SplitContainer1.Panel1Collapsed = Not FolderTreeToolStripMenuItem.Checked
    End Sub

    Private Sub llblOpenSelectedMessages_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblOpenSelectedMessages.LinkClicked
        If olvMessages.SelectedIndices.Count > 0 Then
            OpenMessageToolStripMenuItem.PerformClick()
        Else
            ShowMessageBox("Please selected a message before trying to open it.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub MessageFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageFilterToolStripMenuItem.Click
        pnlMessageFilter.Visible = MessageFilterToolStripMenuItem.Checked
    End Sub

    Private Sub AllColumnsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllColumnsToolStripMenuItem.Click
        olvMessages.RestoreState(m_bytMessageListStateOriginal)
        AutoSizeColumns(olvMessages)
    End Sub

    Private Sub MessageListColumnSelectorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageListColumnSelectorToolStripMenuItem.Click
        olvMessages.MakeColumnSelectMenu(ctxmnuColumnSelector)
        ctxmnuColumnSelector.Show(olvMessages, 10, 10)
    End Sub
    Private Sub TryToReadContents()
        Dim boolContinue As Boolean
        If m_boolUsingRichControl Then
            boolContinue = ReadMessageControlRich.Visible
        Else
            boolContinue = ReadMessageControlPlain.Visible
        End If
        If boolContinue Then
            If m_boolUsingRichControl Then
                ReadMessageControlRich.ReadMessageAloud()
            Else
                ReadMessageControlPlain.ReadMessageAloud()
            End If
            ReadMessagePauseToolStripMenuItem.Enabled = True
            ReadMessageResumeToolStripMenuItem.Enabled = True
        Else
            ReadMessagePauseToolStripMenuItem.Enabled = False
            ReadMessageResumeToolStripMenuItem.Enabled = False
            ShowMessageBox("Please select a message in the preview window before trying to read it." & _
                           Environment.NewLine & Environment.NewLine & _
                           "To show the preview window, go to View->MessagePreview.", _
                           MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If

        'ReadMessagePauseToolStripButton.Enabled = ReadMessagePauseToolStripMenuItem.Enabled
        'ReadMessageResumeToolStripButton.Enabled = ReadMessageResumeToolStripMenuItem.Enabled
    End Sub
    Private Sub ReadMessageContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadMessageContentsToolStripMenuItem.Click
        TryToReadContents()
    End Sub

    Private Sub ReadMessagePauseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadMessagePauseToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ReadMessagePause()
        Else
            ReadMessageControlPlain.ReadMessagePause()
        End If
    End Sub

    Private Sub ReadMessageResumeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadMessageResumeToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ReadMessageResume()
        Else
            ReadMessageControlPlain.ReadMessageResume()
        End If
    End Sub

    Private Sub olvMessages_CellEditFinishing(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles olvMessages.CellEditFinishing
        Dim tmm As TrulyMailMessage = CType(e.RowObject, TrulyMailMessage)
        Select Case e.Column.AspectName
            Case olvColumnImportance.AspectName
                tmm.Importance = Convert.ToInt32(e.Control.Text)
            Case olvColumnTags.AspectName
                tmm.Tags = e.Control.Text
        End Select
        tmm.Save()
        olvMessages.RefreshObject(tmm)
    End Sub

    Private Sub olvMessages_IsHyperlink(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.IsHyperlinkEventArgs) Handles olvMessages.IsHyperlink
        If Not IsValidURL(e.Text) Then
            e.Url = String.Empty
        End If
    End Sub



    Private Sub cboMessageTags_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboMessageTags.DrawItem
        e.DrawBackground()
        e.DrawFocusRectangle()
        If e.Index >= 0 Then
            ' Get the Color object from the Items list
            Dim tag As MessageTag = CType(CType(sender, ComboBox).Items(e.Index), MessageTag)
            Dim aColor As Color = tag.Color

            ' get a square using the bounds height
            Dim rect As Rectangle = New Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 5)
            Dim br As Brush = Brushes.White
            ' call these methods first
            e.DrawBackground()
            e.DrawFocusRectangle()
            ' change brush color if item is selected
            'If e.State = DrawItemState.Selected OrElse e.State = DrawItemState.ComboBoxEdit Then
            '    br = Brushes.White
            'Else
            br = Brushes.Black
            'End If

            ' draw a rectangle and fill it
            e.Graphics.DrawRectangle(New Pen(aColor), rect)
            e.Graphics.FillRectangle(New SolidBrush(aColor), rect)

            ' draw a border
            rect.Inflate(1, 1)
            e.Graphics.DrawRectangle(Pens.Black, rect)

            ' draw the Color name
            e.Graphics.DrawString(tag.Text, CType(sender, ComboBox).Font, br, e.Bounds.Height + 5, ((e.Bounds.Height - CType(sender, ComboBox).Font.Height) \ 2) + e.Bounds.Top)
        End If

    End Sub
    Private Sub LoadMessageTags()
        cboMessageTags.Items.Clear()
        For Each tag As MessageTag In AppSettings.MessageTags
            cboMessageTags.Items.Add(tag)
        Next
        If cboMessageTags.Items.Count > 0 Then
            cboMessageTags.SelectedIndex = 0
        End If
    End Sub


    Friend Sub UpdateMessage(tmm As TrulyMailMessage)
        olvMessages.RefreshObject(tmm)
        '-- Changed to drastically simpler in TM6
        'For Each tm As TrulyMailMessage In olvMessages.Objects
        '    If tm.Filename.ToLower = filename.ToLower Then
        '        m_messageToRefresh = tm
        '    End If
        'Next
    End Sub
    Friend Sub UpdateMessage(filename As String)
        '-- Should use the object-oriented method whenever possible
        '   but in some cases (like loading a draft which is a reply) we don't
        '   have a reference to the base message to update, so we use this more expensive routine
        'todo: Change things like opening drafts that are replies to create the tmm object, not pass around the filename
        For Each tm As TrulyMailMessage In olvMessages.Objects
            If tm.Filename.ToLower = filename.ToLower Then
                m_messageToRefresh = tm
            End If
        Next
    End Sub


    Private Sub ReadMessageContentsToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TryToReadContents()
    End Sub

    Private Sub ReadMessagePauseToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ReadMessagePause()
        Else
            ReadMessageControlPlain.ReadMessagePause()
        End If
    End Sub

    Private Sub ReadMessageResumeToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ReadMessageResume()
        Else
            ReadMessageControlPlain.ReadMessageResume()
        End If
    End Sub



    Private Sub TestConnectionToTrulyMailServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestConnectionToTrulyMailServerToolStripMenuItem.Click
        Dim frm As New ServerConnectionTest()
        frm.ShowDialog()
    End Sub

    Private Sub bgwStartupBatchBackgroundStuff_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwStartupBatchBackgroundStuff.DoWork
        Try
            Dim proc As StartupBatchBackgroundProcess = CType(e.Argument, StartupBatchBackgroundProcess)
            Select Case proc
                Case StartupBatchBackgroundProcess.All
                    '-- Check if we crashed while in the process of encrypting/decrypting local files
                    '   resume process if necessary
                    Select Case AppSettings.EncryptLocalFiles
                        Case LocalFileEncryptionStatus.Encrypting, LocalFileEncryptionStatus.Decrypting
                            ResumeEncryptingDecryptingLocalFilesOnStartup()
                    End Select
            End Select
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    
    Private Sub olvMessages_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles olvMessages.ColumnClick
        Select Case olvMessages.GetColumn(e.Column).AspectName
            Case olvColumnMessageDateSent.AspectName
                olvMessages.SecondarySortColumn = olvColumnImportance
            Case Else
                olvMessages.SecondarySortColumn = olvColumnMessageDateSent
        End Select
        olvMessages.Sort()
    End Sub

    Private Sub ctxmnuColumnSelector_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles ctxmnuColumnSelector.Closed
        ctxmnuColumnSelector.Items.Clear()
    End Sub

    Private Sub ctxmnuColumnSelector_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxmnuColumnSelector.Opening
        For Each mi As ToolStripItem In ctxmnuColumnSelector.Items
            '-- re-title the menu items
            mi.Text = mi.Text.Replace("'&'", "'Has Notes'")
            mi.Text = mi.Text.Replace("'+'", "'Transport System'")
            mi.Text = mi.Text.Replace("'4'", "'Attachments'")
            mi.Text = mi.Text.Replace("'['", "'Importance'")
            Select Case mi.Text
                Case "&"
                    mi.Text = "Has Notes"
                Case "+"
                    mi.Text = "Transport System"
                Case "4"
                    mi.Text = "Attachments"
                Case "["
                    mi.Text = "Importance"
            End Select
        Next
    End Sub

    Private Sub olvMessages_ColumnRightClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles olvMessages.ColumnRightClick
        'olvMessages.MakeColumnCommandMenu(ctxmnuColumnSelector, e.Column)
        ''olvMessages.MakeColumnSelectMenu( ctxmnuColumnSelector)
        'ctxmnuColumnSelector.Show(MousePosition)
    End Sub
    
    Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If AppSettings IsNot Nothing AndAlso AppSettings.MinimizeToTray Then
            If Me.WindowState = FormWindowState.Minimized Then
                Me.Hide()
            Else
                m_previousWindowState = Me.WindowState
            End If
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.Exit()
    End Sub

    Private Sub OpenTrulyMailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BringBackFromTray()
    End Sub
    Private Sub NotifyIcon1_BalloonTipClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BringBackFromTray()
    End Sub
    Private Sub NotifyIcon1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BringBackFromTray()
    End Sub
    Friend Sub BringBackFromTray()
        Try
            If Not Me.Visible Then
                Me.Show()
            End If
            If Me.WindowState = FormWindowState.Minimized Then
                Me.WindowState = m_previousWindowState
            End If
            Me.BringToFront()
            SetForegroundWindow(Me.Handle)
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    'Private Sub ShowSysTrayBaloon(ByVal title As String, ByVal text As String)
    '    NotifyIcon1.ShowBalloonTip(4, title, text, Windows.Forms.ToolTipIcon.Info)
    'End Sub
    Private Sub NotifyUserNewMessageReceived(ByVal newMessages As Integer)
        '-- increment counter and restart few-second tick for timer
        m_intMessageReceivedToNotifyUser += newMessages
        tmrNotifyMessagesReceived.Stop()
        tmrNotifyMessagesReceived.Start()
    End Sub
    Private Sub tmrNotifyMessagesReceived_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrNotifyMessagesReceived.Tick
        Try
            tmrNotifyMessagesReceived.Stop()
            If m_boolStillDownloadingTrulyMailMessages Then
                '-- make sure we don't show notice while we are still downloading TrulyMail messages
                tmrNotifyMessagesReceived.Start()
            Else
                If m_intMessageReceivedToNotifyUser > 0 Then
                    '-- Notify sound
                    Try
                        Dim strSoundFilename As String = GetNotifySoundFilename()
                        If strSoundFilename.Length = 0 Then
                            '-- no sound
                        ElseIf strSoundFilename = NOTIFY_SOUND_DEFAULT Then
                            Sound.PlayWaveSystem("MailBeep")
                        Else
                            Sound.PlayWaveFile(strSoundFilename)
                        End If
                    Catch ex As Exception
                        Log(ex)
                    End Try

                    '-- Notify window
                    If AppSettings.ShowNoticeForNewMessages Then
                        Dim strMessage As String = m_intMessageReceivedToNotifyUser.ToString("#,##0") & " new messages received." ' & Environment.NewLine & "(click to open TrulyMail)"
                        If m_intMessageReceivedToNotifyUser = 1 Then
                            strMessage = strMessage.Replace("messages", "message")
                        End If

                        CType(m_notifier, NewMessageNotifier).MessageText = strMessage
                        m_notifier.StayOpenMilliseconds = Math.Min(Integer.MaxValue, Convert.ToInt32(AppSettings.NoticeForNewMessagesSecondsOpen * 1000))
                        If Form.ActiveForm IsNot Nothing AndAlso Form.ActiveForm.InvokeRequired Then
                            '-- ignore trying to focus on active window because it is on another thread
                            m_notifier.Show()
                            m_notifier.Notify()
                        Else
                            Dim frm As Form = Form.ActiveForm '-- get active window so the notifier does not steal focus (from composing, for example)
                            m_notifier.Show()
                            m_notifier.Notify()
                            If frm IsNot Nothing Then
                                frm.BringToFront()
                            End If
                        End If

                    End If

                    m_intMessageReceivedToNotifyUser = 0
                End If
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub m_notifier2_Clicked() Handles m_notifier2.Clicked
        BringBackFromTray()
    End Sub

    Private Sub FindInMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindInMessageToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ShowFind()
        Else
            ReadMessageControlPlain.ShowFind()
        End If
    End Sub

    Private Sub MarkFolderReadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkFolderReadToolStripMenuItem.Click
        '-- mark all messages in folder as read
        MarkCurrentFolderRead()
    End Sub
    Private Sub MarkCurrentFolderRead()
        Try
            If GetCurrentlySelectedTreeViewNode() IsNot Nothing Then
                Dim strNormalText As String = System.IO.Path.GetFileName(UnQualifyPath(GetCurrentlySelectedTreeViewNode.Tag.ToString))
                Dim lst As List(Of TrulyMailMessage) = GetAllMessagesInListView()
                Dim intMarkedRead As Integer = 0
                For Each tm As TrulyMailMessage In lst
                    If Not tm.Read Then
                        intMarkedRead += 1
                        MarkLocalMessageRead(tm.Filename, False)
                        tm.Read = True
                        olvMessages.RefreshObject(tm)
                        Application.DoEvents()
                    End If
                Next

                '-- if we changed anything, then update the unread count
                GetCurrentlySelectedTreeViewNode.NodeFont = New Font(tvFolders.Font, FontStyle.Regular)
                GetCurrentlySelectedTreeViewNode.Text = strNormalText
            End If
        Catch ex As Exception
            If ex.Message.Contains("Cannot access a disposed object.") Then
                '-- Here we will just log
                Log(ex)
            Else
                Log(ex)
                ShowMessageBoxError("There was an error in TrulyMail." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
            End If
        End Try
    End Sub

    Private Sub TestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            'ReadMessageControlRich.ShowMessageTextTEST()
        Else
            ReadMessageControlPlain.ShowMessageTextTEST()
        End If
        'Dim frm As New TestForm()
        'frm.Show()

        'AppSettings.PremiumFeaturesEnabled = Not AppSettings.PremiumFeaturesEnabled
        'ShowMessageBox("Premium enabled: " & AppSettings.PremiumFeaturesEnabled, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        'Dim tm As NewMessage
        'tm = Me.CreateNewMessage()
        'tm.Show()

        'tm.AddRecipient("test recip", "tesdfg@trulymail.com")
        'tm.UseSendingAccount(4) 'todo
        'tm.Subject = "testing 12345" 'todo
        'tm.Body = "this is the body"
        'tm.SendAsPlainText = False
        'tm.SendThisMessage(Date.Now) 'todo
        'ShowOpacityNotice("Please wait until the current operation has completed.", ConvertToDouble(txtMessageFilter.Text, 5))

        'GetNewRSSItemsForFeed("http://rss.slashdot.org/Slashdot/slashdot", MessageStoreRootPath & "rss1")
        'GetNewRSSItemsForFeed("http://feeds.bbci.co.uk/news/rss.xml", MessageStoreRootPath & "rss1")
        'GetNewRSSItemsForFeed("http://digg.com/rss/indexnews.xml", MessageStoreRootPath & "rss1")
        'GetNewRSSItemsForFeed("http://rss.cnn.com/rss/cnn_topstories.rss", MessageStoreRootPath & "rss1")
        'GetNewRSSItemsForFeed("http://msdn.microsoft.com/en-us/magazine/rss/default.aspx?z=z&all=1", MessageStoreRootPath & "rss1")
        'System.IO.File.WriteAllText(ProfileRootPath & Date.Now.ToString(DATEFORMAT_FILENAME), MyKeyPair.PrivateKey.Key & vbNewLine & vbNewLine & MyKeyPair.PublicKey.Key)
    End Sub

    Private Sub ProcessMessageReceived(ByVal msg As TrulyMailMessage, logDetails As ReceiveFileDetails)
        For Each rule As ProcessingRule In AppSettings.ProcessingRules
            If rule.Enabled AndAlso rule.TriggerType = ProcessingRuleTriggerTypeEnum.ReceiveMessage Then
                If MessageMatchesMatchRule(msg, rule) Then
                    If Not PerformRuleActionOnMessage(msg, rule, logDetails) Then
                        '-- signal to break out, msg was deleted or the like
                        Exit For
                    End If
                End If
            End If
        Next

        If msg.Filename.Length > 0 Then
            Dim strFolder As String = System.IO.Path.GetDirectoryName(msg.Filename)
            AddTrulyMailMessageToListView(msg, strFolder)
            Dim tn As TreeNode = GetTreeNodeByPath(strFolder)
            Dim strFolderName As String = System.IO.Path.GetFileName(UnQualifyPath(strFolder))
            ShowUnreadOnNodeText(tn, strFolderName, True)
        End If
    End Sub
    Friend Sub ProcessMessageSent(ByVal msg As TrulyMailMessage, logDetails As ReceiveFileDetails)
        For Each rule As ProcessingRule In AppSettings.ProcessingRules
            If rule.Enabled AndAlso rule.TriggerType = ProcessingRuleTriggerTypeEnum.SendMessage Then
                If MessageMatchesMatchRule(msg, rule) Then
                    If Not PerformRuleActionOnMessage(msg, rule, logDetails) Then
                        '-- signal to break out, msg was deleted or the like
                        Exit For
                    End If
                End If
            End If
        Next

        If msg.Filename.Length > 0 Then
            Dim strFolder As String = System.IO.Path.GetDirectoryName(msg.Filename)
            AddTrulyMailMessageToListView(msg, strFolder)
            Dim tn As TreeNode = GetTreeNodeByPath(strFolder)
            Dim strFolderName As String = System.IO.Path.GetFileName(UnQualifyPath(strFolder))
            ShowUnreadOnNodeText(tn, strFolderName, True)
        End If
    End Sub

    Private Sub MessageProcessingRulesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageProcessingRulesToolStripMenuItem.Click
        Dim frm As New ProcessRulesForm()
        frm.Show(Me)
    End Sub
    Private Sub AddTag()
        Try
            '-- Add selected tag to selected messages, unless the tag already exists
            Dim strNewTagText As String
            If cboMessageTags.SelectedIndex >= 0 Then
                strNewTagText = CType(cboMessageTags.Items(cboMessageTags.SelectedIndex), MessageTag).Text
            Else
                strNewTagText = cboMessageTags.Text
            End If

            If strNewTagText.Length > 0 Then
                Dim list As ArrayList = olvMessages.GetSelectedObjects
                For Each tm As TrulyMailMessage In list
                    If tm.Tags Is Nothing Then
                        tm.Tags = String.Empty
                    End If
                    If Not tm.Tags.Contains(strNewTagText) Then
                        If tm.Tags.Trim.Length = 0 Then
                            tm.Tags = strNewTagText
                        Else
                            tm.Tags &= " " & strNewTagText
                        End If
                    End If
                    tm.Save() '-- persist tag change
                Next
                olvMessages.RefreshSelectedObjects()
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error applying the message tag. " & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try

    End Sub
    Private Sub ClearTags()
        Dim list As ArrayList = olvMessages.GetSelectedObjects
        For Each tm As TrulyMailMessage In list
            tm.Tags = String.Empty
            tm.Save() '-- persist tag change
        Next
        olvMessages.RefreshSelectedObjects()
    End Sub
    Private Sub pbAddTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAddTag.Click
        AddTag()
    End Sub

    Private Sub pbClearTags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbClearTags.Click
        ClearTags()
    End Sub

    Private Sub FilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilterSenderToolStripMenuItem.Click, FilterSubjectToolStripMenuItem1.Click
        Dim menu As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        txtMessageFilter.Text = menu.Tag.ToString()
    End Sub


    Private Sub m_tmrFilterAutoComplete_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_tmrFilterAutoComplete.Tick
        '-- This should only fire after filter text has stayed unmodified for > 2 seconds
        m_tmrFilterAutoComplete.Stop()

        Dim strText As String = txtMessageFilter.Text

        If strText.Trim.Length > 0 Then
            '-- make sure there are no more than 10 items in the lis
            '   make sure no item repeats
            If AppSettings.MainFormFilterAutoComplete.Contains(strText) Then
                AppSettings.MainFormFilterAutoComplete.Remove(strText)
            End If

            Do Until AppSettings.MainFormFilterAutoComplete.Count <= 30
                AppSettings.MainFormFilterAutoComplete.RemoveAt(AppSettings.MainFormFilterAutoComplete.Count - 1)
            Loop

            AppSettings.MainFormFilterAutoComplete.Add(strText)
        End If
    End Sub


    Private Sub ManageSignaturesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageSignaturesToolStripMenuItem.Click
        If UseFallbackModeNow() Then
            Dim frm As New ManageAutoTextSimple()
            frm.Show()
        Else
            Dim frm As New ManageAutoText()
            frm.Show()
        End If

    End Sub

    Private Sub AddNotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNotesToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.AddNotes()
        Else
            ReadMessageControlPlain.AddNotes()
        End If
    End Sub

    Private Sub MoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveToolStripMenuItem.Click
        MoveSelectedMessages()
    End Sub

    Private Sub RSSAndBlogFeedsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RSSAndBlogFeedsToolStripMenuItem.Click
        ShowRSSForm(False)
    End Sub
    Private Sub ShowRSSForm(showLastError As Boolean)
        Try
            Dim frm As New RSSList(showLastError)
            If showLastError Then
                '-- show form with RSS feed errors
                'frm.Show(Me)
                'frm.ForceShowErrorColumn()
            End If

            frm.ShowDialog(Me)
            frm.Dispose()

            SetupMenusForPOPAccountsAndRSSFeeds()
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Private Sub NewMessageToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NewMessage()
    End Sub

    Private Sub ImportExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportExportToolStripMenuItem.Click
        'Dim frm As New ImportExportManager()
        'frm.ShowDialog(Me)
        'LoadFolderTree()
    End Sub

#Region " Folder Icon Colors "
    Private Const FOLDER_COLOR_BASE_CLOSED_INDEX = 10
    Private Const FOLDER_COLOR_BASE_OPEN_INDEX = 16
    Private Enum FolderIconColors
        Blue
        Green
        Yellow
        Orange
        Red
        Purple
    End Enum
    Private Sub ChangeFolderColorBlueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeFolderColorBlueToolStripMenuItem.Click
        Try
            Dim intColor As Integer = FolderIconColors.Blue
            Dim tn As TreeNode = GetCurrentlySelectedTreeViewNode()
            tn.SelectedImageIndex = FOLDER_COLOR_BASE_OPEN_INDEX + intColor
            tn.ImageIndex = FOLDER_COLOR_BASE_CLOSED_INDEX + intColor
            UpdateFolderStateIcon(tn.Tag.ToString(), intColor)
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub

    Private Sub ChangeFolderColorGreenToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeFolderColorGreenToolStripMenuItem.Click
        Try
            Dim intColor As Integer = FolderIconColors.Green
            Dim tn As TreeNode = GetCurrentlySelectedTreeViewNode()
            tn.SelectedImageIndex = FOLDER_COLOR_BASE_OPEN_INDEX + intColor
            tn.ImageIndex = FOLDER_COLOR_BASE_CLOSED_INDEX + intColor
            UpdateFolderStateIcon(tn.Tag.ToString(), intColor)
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub

    Private Sub ChangeFolderColorYellowToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeFolderColorYellowToolStripMenuItem.Click
        Try
            Dim intColor As Integer = FolderIconColors.Yellow
            Dim tn As TreeNode = GetCurrentlySelectedTreeViewNode()
            tn.SelectedImageIndex = FOLDER_COLOR_BASE_OPEN_INDEX + intColor
            tn.ImageIndex = FOLDER_COLOR_BASE_CLOSED_INDEX + intColor
            UpdateFolderStateIcon(tn.Tag.ToString(), intColor)
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub

    Private Sub ChangeFolderColorOrangeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeFolderColorOrangeToolStripMenuItem.Click
        Try
            Dim intColor As Integer = FolderIconColors.Orange
            Dim tn As TreeNode = GetCurrentlySelectedTreeViewNode()
            tn.SelectedImageIndex = FOLDER_COLOR_BASE_OPEN_INDEX + intColor
            tn.ImageIndex = FOLDER_COLOR_BASE_CLOSED_INDEX + intColor
            UpdateFolderStateIcon(tn.Tag.ToString(), intColor)
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub

    Private Sub ChangeFolderColorRedToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeFolderColorRedToolStripMenuItem.Click
        Try
            Dim intColor As Integer = FolderIconColors.Red
            Dim tn As TreeNode = GetCurrentlySelectedTreeViewNode()
            tn.SelectedImageIndex = FOLDER_COLOR_BASE_OPEN_INDEX + intColor
            tn.ImageIndex = FOLDER_COLOR_BASE_CLOSED_INDEX + intColor
            UpdateFolderStateIcon(tn.Tag.ToString(), intColor)
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub

    Private Sub ChangeFolderColorPurpleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeFolderColorPurpleToolStripMenuItem.Click
        Try
            Dim intColor As Integer = FolderIconColors.Purple
            Dim tn As TreeNode = GetCurrentlySelectedTreeViewNode()
            tn.SelectedImageIndex = FOLDER_COLOR_BASE_OPEN_INDEX + intColor
            tn.ImageIndex = FOLDER_COLOR_BASE_CLOSED_INDEX + intColor
            UpdateFolderStateIcon(tn.Tag.ToString(), intColor)
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub
#End Region

    Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        If m_boolFormFullyLoaded Then
            AppSettings.FolderTreeSplitter = SplitContainer1.SplitterDistance
        End If
    End Sub

    Private Sub ExportMessagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportMessagesToolStripMenuItem.Click
        Dim frm As New ExportMessages()
        frm.Show(Me)
    End Sub
    Public Delegate Sub AddFolderToFolderTreeCallback(path As String)
    Public Sub AddFolderToFolderTree(ByVal path As String)
        If InvokeRequired Then
            Dim deleg As New AddFolderToFolderTreeCallback(AddressOf AddFolderToFolderTree)
            Invoke(deleg, path)
        Else
            Try
                '-- if Parent is visible and expanded, then add node
                '   if parent is visible, not expanded, without children, then add child and expand
                '   if parent is visible, not expanded, with children, do nothing (handled on expand)
                '   if parent is not visible then do nothing
                Dim node As TreeNode = GetTreeNodeByPath(System.IO.Path.GetDirectoryName(UnQualifyPath(path)))
                If node IsNot Nothing Then
                    If node.Nodes.Count > 0 Then
                        If node.IsExpanded Then
                            AddChildNode(node, path, FOLDER_COLOR_BASE_CLOSED_INDEX, FOLDER_COLOR_BASE_OPEN_INDEX)
                        Else
                            '-- do nothing, will be handled when it expands
                        End If
                    Else
                        AddChildrenNodes(node)
                        node.Expand()
                    End If
                End If
            Catch ex As Exception
                Log(ex)
            End Try
        End If
    End Sub
    Private Function GetStartingXForColumn(ByVal columnIndex As Integer) As Integer
        Dim intPosition As Integer = olvMessages.Columns(columnIndex).DisplayIndex - 1
        Dim intX As Integer
        If intPosition >= 0 Then
            For intCounter As Integer = 0 To intPosition
                Try
                    intX += olvMessages.ColumnsInDisplayOrder(intCounter).Width
                Catch ex As Exception
                    '-- ignore
                End Try
            Next

            Return intX
        End If
    End Function
    Private Sub olvMessages_DrawColumnHeader(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles olvMessages.DrawColumnHeader
        Dim col As BrightIdeasSoftware.OLVColumn = olvMessages.Columns(e.ColumnIndex)
        Dim intStartingX As Integer = GetStartingXForColumn(e.ColumnIndex)
        intStartingX += (col.Width / 2) - 8 '-- 16 px /2 = 8
        Dim intStartingY As Integer = 4
        Select Case col.Text
            Case "Transport Type"
                e.DrawDefault = False
                e.DrawBackground()
                e.Graphics.DrawImage(Me.ImglstMessageStatus.Images(4), New Point(intStartingX, intStartingY))
            Case "Importance"
                e.DrawDefault = False
                e.DrawBackground()
                e.Graphics.DrawImage(Me.ImglstMessageStatus.Images(11), New Point(intStartingX, intStartingY))
            Case "Notes"
                e.DrawDefault = False
                e.DrawBackground()
                e.Graphics.DrawImage(Me.ImglstMessageStatus.Images(6), New Point(intStartingX, intStartingY))
            Case "Attachments"
                e.DrawDefault = False
                e.DrawBackground()
                e.Graphics.DrawImage(Me.ImglstMessageStatus.Images(10), New Point(intStartingX, intStartingY))
            Case Else
                e.DrawDefault = True
        End Select
    End Sub

    Private Sub tmrSelectedMessageChanged_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSelectedMessageChanged.Tick
        tmrSelectedMessageChanged.Stop()
        UpdateReplyToolStripItems()
        If olvMessages.SelectedIndices.Count > 0 Then
            If Not m_boolPreventLoadingPreview Then
                Select Case olvMessages.GetSelectedObjects.Count
                    Case 0
                        If m_boolUsingRichControl Then
                            ReadMessageControlRich.Hide()
                        Else
                            ReadMessageControlPlain.Hide()
                        End If
                    Case 1
                        LoadMessagePreview()
                        HighlightMatchingMessages(MessageHighlightHighlightSenderToolStripMenuItem.Checked, MessageHighlightHighlightsubjectToolStripMenuItem.Checked)
                    Case Else '-- 2 or more
                        'TODO: We never get here, clean up logic
                        If m_boolUsingRichControl Then
                            ReadMessageControlRich.Hide()
                        Else
                            ReadMessageControlPlain.Hide()
                        End If
                        llblOpenSelectedMessages.Show()
                End Select
            End If
            olvMessages.RefreshSelectedObjects()
        Else
            If m_boolUsingRichControl Then
                ReadMessageControlRich.Hide()
                ReadMessageControlRich.NothingToDisplay()
            Else
                ReadMessageControlPlain.Hide()
                ReadMessageControlPlain.NothingToDisplay()
            End If
        End If
    End Sub
    Private Sub HighlightMatchingMessages(highlightSender As Boolean, highlightSubject As Boolean)
        Dim filter As BrightIdeasSoftware.TextMatchFilter
        Dim tmSelected As TrulyMailMessage = olvMessages.GetSelectedObject
        Dim brushFill As Brush = Brushes.MediumSeaGreen

        If tmSelected IsNot Nothing Then
            If Not highlightSender AndAlso Not highlightSubject Then
                olvMessages.DefaultRenderer = Nothing
            ElseIf highlightSender Then
                filter = New BrightIdeasSoftware.TextMatchFilter(olvMessages, tmSelected.SenderName)
                Dim highlightRenderer As New BrightIdeasSoftware.HighlightTextRenderer(filter)
                highlightRenderer.FillBrush = brushFill
                olvMessages.DefaultRenderer = highlightRenderer
            ElseIf highlightSubject Then
                filter = New BrightIdeasSoftware.TextMatchFilter(olvMessages, GetBaseSubject(tmSelected.Subject))
                Dim highlightRenderer As New BrightIdeasSoftware.HighlightTextRenderer(filter)
                highlightRenderer.FillBrush = brushFill
                olvMessages.DefaultRenderer = highlightRenderer
            End If
            olvMessages.Refresh()
        End If
    End Sub
    Private Sub m_bgwShowUnreadOnRootNodes_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles m_bgwShowUnreadOnRootNodes.DoWork
        UpdateUnreadCountAllRootNodes()
    End Sub

    Private Sub MoveFolderToRootToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveFolderToRootToolStripMenuItem.Click
        Try
            Dim tnToMove As TreeNode = GetCurrentlySelectedTreeViewNode()
            Dim strOriginalFolderPath As String = tnToMove.Tag.ToString()
            Dim strNewFolderPath As String = MessageStoreRootPath & System.IO.Path.GetFileName(strOriginalFolderPath)

            System.IO.Directory.Move(strOriginalFolderPath, strNewFolderPath)

            tnToMove.Tag = strNewFolderPath

            '-- move treenode to new parent
            tnToMove.Remove()
            tvFolders.Nodes.Add(tnToMove)
            tnToMove.EnsureVisible()
            tvFolders.SelectedNode = tnToMove
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error moving the folder." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub llblFilter_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblFilter.LinkClicked
        ctxmnuFilter.Show(Me.MousePosition)
    End Sub


#Region " OLV Filtering "
    '-- Note: Quick filters OR text filter, one cancels the other

    Private Sub FilterOnlyUnreadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FilterOnlyUnreadToolStripMenuItem.Click
        ClearReadFilters()
        FilterOnlyUnreadToolStripMenuItem.Checked = True
        ApplyFilters()
    End Sub

    Private Sub FilterOnlyReadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FilterOnlyReadToolStripMenuItem.Click
        ClearReadFilters()
        FilterOnlyReadToolStripMenuItem.Checked = True
        ApplyFilters()
    End Sub

    Private Sub FilterOnlyTodayToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FilterOnlyTodayToolStripMenuItem.Click
        ClearDateFilters()
        FilterOnlyTodayToolStripMenuItem.Checked = True
        ApplyFilters()
    End Sub

    Private Sub FilterOnlyLast2DaysToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FilterOnlyLast2DaysToolStripMenuItem.Click
        ClearDateFilters()
        FilterOnlyLast2DaysToolStripMenuItem.Checked = True
        ApplyFilters()
    End Sub

    Private Sub FilterOnlyThisWeekToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FilterOnlyThisWeekToolStripMenuItem.Click
        ClearDateFilters()
        FilterOnlyThisWeekToolStripMenuItem.Checked = True
        ApplyFilters()
    End Sub

    Private Sub FilterMoreThanOneWeekToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FilterMoreThanOneWeekToolStripMenuItem.Click
        ClearDateFilters()
        FilterMoreThanOneWeekToolStripMenuItem.Checked = True
        ApplyFilters()
    End Sub

    Private Sub FilterMoreThanOneMonthToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FilterMoreThanOneMonthToolStripMenuItem.Click
        ClearDateFilters()
        FilterMoreThanOneMonthToolStripMenuItem.Checked = True
        ApplyFilters()
    End Sub
    Private Sub FilterMoreThanThreeMonthsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FilterMoreThanThreeMonthsToolStripMenuItem.Click
        ClearDateFilters()
        FilterMoreThanThreeMonthsToolStripMenuItem.Checked = True
        ApplyFilters()
    End Sub

    Private Sub FilterMoreThanSixMonthsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FilterMoreThanSixMonthsToolStripMenuItem.Click
        ClearDateFilters()
        FilterMoreThanSixMonthsToolStripMenuItem.Checked = True
        ApplyFilters()
    End Sub

    Private Sub ClearReadFilters()
        FilterOnlyUnreadToolStripMenuItem.Checked = False
        FilterOnlyReadToolStripMenuItem.Checked = False
        txtMessageFilter.Text = String.Empty
    End Sub
    Private Sub ClearDateFilters()
        FilterOnlyTodayToolStripMenuItem.Checked = False
        FilterOnlyLast2DaysToolStripMenuItem.Checked = False
        FilterOnlyThisWeekToolStripMenuItem.Checked = False
        FilterMoreThanOneWeekToolStripMenuItem.Checked = False
        FilterMoreThanOneMonthToolStripMenuItem.Checked = False
        txtMessageFilter.Text = String.Empty
    End Sub
    Private Sub ClearQuickFilters()
        FilterOnlyUnreadToolStripMenuItem.Checked = False
        FilterOnlyReadToolStripMenuItem.Checked = False
        FilterOnlyTodayToolStripMenuItem.Checked = False
        FilterOnlyLast2DaysToolStripMenuItem.Checked = False
        FilterOnlyThisWeekToolStripMenuItem.Checked = False
        FilterMoreThanOneWeekToolStripMenuItem.Checked = False
        FilterMoreThanOneMonthToolStripMenuItem.Checked = False
        FilterMoreThanThreeMonthsToolStripMenuItem.Checked = False
        FilterMoreThanSixMonthsToolStripMenuItem.Checked = False
        ApplyFilters()
    End Sub
    Private Sub ClearAllFilters()
        txtMessageFilter.Text = String.Empty
        ClearQuickFilters()
        ApplyFilters()
        txtMessageFilter.Focus()
    End Sub
    Private Sub FilterClearAllFiltersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FilterClearAllFiltersToolStripMenuItem.Click
        ClearAllFilters()
    End Sub
    Private Class OLVQuickFilter
        Implements BrightIdeasSoftware.IModelFilter
        Public Enum ReadStateEnum
            All
            Read
            Unread
        End Enum

        Private m_readState As ReadStateEnum
        Private m_boolUseMaxDate As Boolean
        Private m_boolUseMinDate As Boolean
        Private m_dtMaxDate As Date
        Private m_dtMinDate As Date

        Public Sub New(readState As ReadStateEnum, maxDate As Nullable(Of Date), minDate As Nullable(Of Date))
            m_readState = readState
            If maxDate.HasValue Then
                m_boolUseMaxDate = True
                m_dtMaxDate = maxDate.Value
            Else
                m_boolUseMaxDate = False
            End If

            If minDate.HasValue Then
                m_boolUseMinDate = True
                m_dtMinDate = minDate.Value
            Else
                m_boolUseMinDate = False
            End If
        End Sub
        Public Function Filter(modelObject As Object) As Boolean Implements BrightIdeasSoftware.IModelFilter.Filter
            Dim boolReturn As Boolean

            If m_readState = ReadStateEnum.All AndAlso Not m_boolUseMaxDate AndAlso Not m_boolUseMinDate Then
                Return True '-- everyone matches, skip all the logic
            Else
                Dim tm As TrulyMailMessage = CType(modelObject, TrulyMailMessage)
                Select Case m_readState
                    Case ReadStateEnum.All
                        '-- everyone matches
                        boolReturn = True
                    Case ReadStateEnum.Read
                        boolReturn = tm.Read
                    Case ReadStateEnum.Unread
                        boolReturn = Not tm.Read
                End Select

                If boolReturn AndAlso m_boolUseMaxDate Then
                    boolReturn = tm.MessageDateSent <= m_dtMaxDate
                End If

                If boolReturn AndAlso m_boolUseMinDate Then
                    boolReturn = tm.MessageDateSent >= m_dtMinDate
                End If

                Return boolReturn
            End If
        End Function
    End Class
    Private Sub ApplyFilters() '-- used only with quick filters
        Dim readFilter As OLVQuickFilter.ReadStateEnum
        If FilterOnlyUnreadToolStripMenuItem.Checked Then
            readFilter = OLVQuickFilter.ReadStateEnum.Unread
        ElseIf FilterOnlyReadToolStripMenuItem.Checked Then
            readFilter = OLVQuickFilter.ReadStateEnum.Read
        Else
            readFilter = OLVQuickFilter.ReadStateEnum.All

        End If
        Dim dtMaxDate, dtMinDate As Nullable(Of Date)

        If FilterOnlyTodayToolStripMenuItem.Checked Then
            dtMinDate = Date.Today
            dtMaxDate = Nothing
        ElseIf FilterOnlyLast2DaysToolStripMenuItem.Checked Then
            dtMinDate = Date.Today.AddDays(-1)
            dtMaxDate = Nothing
        ElseIf FilterOnlyThisWeekToolStripMenuItem.Checked Then
            dtMinDate = Date.Today.AddDays(-7)
            dtMaxDate = Nothing
        ElseIf FilterMoreThanOneWeekToolStripMenuItem.Checked Then
            dtMinDate = Nothing
            dtMaxDate = Date.Today.AddDays(-7)
        ElseIf FilterMoreThanOneMonthToolStripMenuItem.Checked Then
            dtMinDate = Nothing
            dtMaxDate = Date.Today.AddMonths(-1)
        ElseIf FilterMoreThanThreeMonthsToolStripMenuItem.Checked Then
            dtMinDate = Nothing
            dtMaxDate = Date.Today.AddMonths(-3)
        ElseIf FilterMoreThanSixMonthsToolStripMenuItem.Checked Then
            dtMinDate = Nothing
            dtMaxDate = Date.Today.AddMonths(-6)
        Else
            dtMinDate = Nothing
            dtMaxDate = Nothing

            If readFilter = OLVQuickFilter.ReadStateEnum.All Then
                olvMessages.ModelFilter = Nothing
                llblFilter.BackColor = Color.Transparent
                'ToolTip1.SetToolTip(llblFilter, "No quick filters are in effect, click to set quick filters.")
                olvMessages.EmptyListMsg = "This folder is empty"
                FilterMessageCountToolStripStatusLabel.Visible = False
                UnreadMessagesStatusLabel.Visible = True
                TotalMessagesStatusLabel.Visible = True
                Exit Sub
            End If
        End If
        llblFilter.BackColor = Color.Yellow
        'ToolTip1.SetToolTip(llblFilter, "Quick filters are in effect, click to see details.")
        olvMessages.ModelFilter = New OLVQuickFilter(readFilter, dtMaxDate, dtMinDate)


        olvMessages.EmptyListMsg = "No messages match your filter"

        Dim intFilteredCount As Integer = 0
        For Each o As Object In olvMessages.FilteredObjects
            intFilteredCount += 1
        Next
        FilterMessageCountToolStripStatusLabel.Text = "Filtered: " & intFilteredCount.ToString("#,##0")

        FilterMessageCountToolStripStatusLabel.Visible = True
        UnreadMessagesStatusLabel.Visible = False
        TotalMessagesStatusLabel.Visible = False
    End Sub

    Private Sub txtMessageFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMessageFilter.KeyDown
        If e.KeyCode = Keys.Escape Then
            txtMessageFilter.Clear()
        End If
    End Sub

    Private Sub FilterMessages()
        Try
            tmrFilterMessages.Stop()
            ClearQuickFilters()

            'olvMessages.ModelFilter = New BrightIdeasSoftware.TextMatchFilter(olvMessages, txtMessageFilter.Text)
            Dim strings() As String = txtMessageFilter.Text.Split(" ")
            If strings.Length > 1 Then
                Dim lstFilters As New List(Of BrightIdeasSoftware.IModelFilter)
                Dim objFilter As BrightIdeasSoftware.TextMatchFilter
                For Each str As String In strings
                    objFilter = New BrightIdeasSoftware.TextMatchFilter(olvMessages, str)
                    lstFilters.Add(objFilter)
                Next
                olvMessages.ModelFilter = New BrightIdeasSoftware.CompositeAllFilter(lstFilters)
            Else
                '-- Simple one word match 
                olvMessages.ModelFilter = New BrightIdeasSoftware.TextMatchFilter(olvMessages, txtMessageFilter.Text)
            End If


            m_tmrFilterAutoComplete.Stop()
            m_tmrFilterAutoComplete.Start()

            If txtMessageFilter.Text.Length = 0 Then
                olvMessages.EmptyListMsg = "This folder is empty"
                FilterMessageCountToolStripStatusLabel.Visible = False
                UnreadMessagesStatusLabel.Visible = True
                TotalMessagesStatusLabel.Visible = True
            Else
                olvMessages.EmptyListMsg = "No messages match your filter"

                Dim intFilteredCount As Integer = 0
                For Each o As Object In olvMessages.FilteredObjects
                    intFilteredCount += 1
                Next
                FilterMessageCountToolStripStatusLabel.Text = "Filtered: " & intFilteredCount.ToString("#,##0")

                FilterMessageCountToolStripStatusLabel.Visible = True
                UnreadMessagesStatusLabel.Visible = False
                TotalMessagesStatusLabel.Visible = False
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Private Sub txtMessageFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMessageFilter.TextChanged
        tmrFilterMessages.Stop()
        tmrFilterMessages.Start()
    End Sub

    Private Sub btnClearMessageFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearMessageFilter.Click
        ClearAllFilters()
    End Sub
#End Region

    Private Sub SaveAsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        Try
            If GetCurrentlySelectedMessages.Count = 1 Then
                Dim tm As TrulyMailMessage
                Try
                    tm = New TrulyMailMessage(GetCurrentlySelectedMessageFilename)
                Catch ex As Exception
                    Log(ex)
                    ShowMessageBoxError("The file you are trying to save no longer exists. It might have been deleted.")
                    Exit Sub
                End Try
                Dim sfd As New SaveFileDialog()
                sfd.OverwritePrompt = True
                sfd.Filter = "Email Files|*.eml"
                sfd.Title = "Select location to save file..."
                sfd.DefaultExt = ".eml"
                If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim strFilename As String = sfd.FileName

                    If Not ConvertTrulyMailMessageToEMLFile(tm, sfd.FileName, "autodelete@trulymail.com") Then
                        Log("eml file not created.")
                        ShowMessageBoxError("There was an error saving your message. Please contact TrulyMail Support.")
                    End If
                End If
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error saving your message. Please contact TrulyMail Support.")
        End Try
    End Sub

    Private Sub tmrFilterMessages_Elapsed(sender As Object, e As System.Timers.ElapsedEventArgs) Handles tmrFilterMessages.Elapsed
        FilterMessages()
    End Sub

    Private Sub AddEmailContactToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles AddEmailContactToolStripMenuItem.Click
        Dim frm As New EditContactK()
        frm.Show(Me)
    End Sub

    Private Sub ShowContactListToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ShowContactListToolStripButton.Click
        ShowContactListArea(ShowContactListToolStripButton.Checked)
    End Sub

    Private Sub ShowContactListAreaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShowContactListAreaToolStripMenuItem.Click
        ShowContactListArea(ShowContactListAreaToolStripMenuItem.Checked)
    End Sub

    Private Sub ShowContactListArea(show As Boolean)
        If show Then
            ContactSelector1 = New ContactSelectorPlain()
            ContactSelector1.Parent = SplitContainerAddressBook.Panel2
            ContactSelector1.Dock = DockStyle.Fill
            ContactSelector1.Visible = True
            ContactSelector1.ShowButtons = False
            ContactSelector1.ShowShortcutMenu = True
            ContactSelector1.ReloadAddressBookEntries()
            ContactSelector1.SortByLastSent()
        Else
            If ContactSelector1 IsNot Nothing Then
                ContactSelector1.Dispose()
            End If
            ContactSelector1 = Nothing
        End If

        ShowContactListToolStripButton.Checked = show
        ShowContactListAreaToolStripMenuItem.Checked = show
        SplitContainerAddressBook.Panel2Collapsed = Not show
        AppSettings.ContactListAreaVisible = show
    End Sub


    Private Sub SetMessageHighlight(sender As Boolean, subject As Boolean)
        'MessageHighlightNothingToolStripMenuItem.Checked = Not sender AndAlso Not subject
        MessageHighlightNoHighlightToolStripMenuItem.Checked = Not sender AndAlso Not subject

        'MessageHighlightSenderToolStripMenuItem.Checked = sender
        MessageHighlightHighlightSenderToolStripMenuItem.Checked = sender

        'MessageHighlightSubjectToolStripMenuItem.Checked = subject
        MessageHighlightHighlightsubjectToolStripMenuItem.Checked = subject

        If sender Then
            If AppSettings.LargeToolbarIcons Then
                MessageHighlightToolStripDropDownButton.Image = My.Resources.HighlightSender2_32
            Else
                MessageHighlightToolStripDropDownButton.Image = My.Resources.HighlightSender2_16
            End If
            'MessageHighlightToolStripDropDownButton.ToolTipText = "Highlight matching sender"
        ElseIf subject Then
            If AppSettings.LargeToolbarIcons Then
                MessageHighlightToolStripDropDownButton.Image = My.Resources.HighlightSubject2_32
            Else
                MessageHighlightToolStripDropDownButton.Image = My.Resources.HighlightSubject2_16
            End If
            'MessageHighlightToolStripDropDownButton.ToolTipText = "Highlight matching subject"
        Else
            If AppSettings.LargeToolbarIcons Then
                MessageHighlightToolStripDropDownButton.Image = My.Resources.HighlightNothing_32
            Else
                MessageHighlightToolStripDropDownButton.Image = My.Resources.HighlightNothing_16
            End If
            'MessageHighlightToolStripDropDownButton.ToolTipText = "Do not highlight"
        End If


        HighlightMatchingMessages(sender, subject)
    End Sub
    Private Sub MessageHighlightNothingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MessageHighlightNothingToolStripMenuItem.Click
        SetMessageHighlight(False, False)
    End Sub

    Private Sub MessageHighlightSenderToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles MessageHighlightSenderToolStripMenuItem.Click
        SetMessageHighlight(True, False)
    End Sub

    Private Sub MessageHighlightSubjectToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles MessageHighlightSubjectToolStripMenuItem.Click
        SetMessageHighlight(False, True)
    End Sub

    Private Sub MessageHighlightNoHighlightToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MessageHighlightNoHighlightToolStripMenuItem.Click
        SetMessageHighlight(False, False)
    End Sub

    Private Sub MessageHighlightHighlightSenderToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles MessageHighlightHighlightSenderToolStripMenuItem.Click
        SetMessageHighlight(True, False)
    End Sub

    Private Sub MessageHighlightHighlightsubjectToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles MessageHighlightHighlightsubjectToolStripMenuItem.Click
        SetMessageHighlight(False, True)
    End Sub

    Private Sub RemoveDuplicateMessagesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoveDuplicateMessagesToolStripMenuItem.Click
        Try
            Dim tmm As TrulyMailMessage
            Dim tmm2 As TrulyMailMessage
            Dim strSubject As String
            Dim intLastObject As Integer = olvMessages.Items.Count - 1
            Dim intTotalObjects As Integer = olvMessages.Items.Count
            Me.olvMessages.SelectedObject = Nothing
            Dim intDuplicateCount As Integer
            Using frmProgress As New DuplicateMessageFinderProgressForm(intTotalObjects)
                Dim boolProgressFormLoaded As Boolean
                Dim sw As Stopwatch
                sw = Stopwatch.StartNew()

                For intCounter As Integer = 0 To intLastObject
                    tmm = CType(olvMessages.GetNthItemInDisplayOrder(intCounter).RowObject, TrulyMailMessage)
                    For intCounter2 As Integer = intCounter + 1 To intLastObject
                        tmm2 = CType(olvMessages.GetNthItemInDisplayOrder(intCounter2).RowObject, TrulyMailMessage)
                        If tmm IsNot tmm2 Then
                            If tmm.MessageDateSent = tmm2.MessageDateSent AndAlso _
                                tmm.SenderName = tmm2.SenderName AndAlso _
                                tmm.TransportType = tmm2.TransportType AndAlso _
                                tmm.Subject = tmm2.Subject AndAlso _
                                tmm.Body = tmm2.Body AndAlso _
                                tmm.Attachments.Count = tmm2.Attachments.Count Then

                                If Not Me.olvMessages.IsSelected(tmm2) Then
                                    Me.olvMessages.SelectObject(tmm2)
                                    intDuplicateCount += 1
                                End If
                            End If
                        End If
                        Application.DoEvents()
                    Next
                    '-- If it takes over 3 seconds, then show the progress form
                    If sw.Elapsed.TotalSeconds > 3 Then
                        If Not boolProgressFormLoaded Then
                            boolProgressFormLoaded = True
                            frmProgress.Show(Me)
                            frmProgress.TopMost = True
                        Else
                            Dim boolCancel As Boolean
                            frmProgress.SetStatus(intCounter, intTotalObjects, boolCancel)
                            If boolCancel Then
                                GoTo FinishedCounting
                            End If
                        End If
                    End If
                Next
            End Using

FinishedCounting:

            If intDuplicateCount = 0 Then
                ShowMessageBox("No duplicates were found.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                'intDuplicateCount -= 1
                ShowMessageBox(intDuplicateCount.ToString("#,##0") & " duplicates have been selected. You may delete or move them as you want.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error selecting duplicate messages. " & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try

    End Sub

    Private Sub MessagePreviewToolStripMenuItem_DropDownOpening(sender As System.Object, e As System.EventArgs) Handles MessagePreviewToolStripMenuItem.DropDownOpening
        Try
            If m_boolUsingRichControl Then
                ShowReplyModesInPreviewToolStripMenuItem.Checked = ReadMessageControlRich.ReplyModeVisible
            Else
                ShowReplyModesInPreviewToolStripMenuItem.Checked = ReadMessageControlPlain.ReplyModeVisible
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub ShowReplyModesInPreviewToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles ShowReplyModesInPreviewToolStripMenuItem.Click
        Try
            If m_boolUsingRichControl Then
                ReadMessageControlRich.ReplyModeVisible = Not ReadMessageControlRich.ReplyModeVisible
                AppSettings.ReadMessagePreviewActionVisible = ReadMessageControlRich.ReplyModeVisible
            Else
                ReadMessageControlPlain.ReplyModeVisible = Not ReadMessageControlPlain.ReplyModeVisible
                AppSettings.ReadMessagePreviewActionVisible = ReadMessageControlPlain.ReplyModeVisible
            End If

        Catch ex As Exception
            Log(ex)
        End Try
    End Sub


    Private Sub tvFolders_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles tvFolders.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                If GetCurrentlySelectedTreeViewNode() IsNot Nothing Then
                    GetCurrentlySelectedTreeViewNode.Text = System.IO.Path.GetFileName(GetCurrentlySelectedTreeViewNode.Tag.ToString())
                    GetCurrentlySelectedTreeViewNode().BeginEdit()
                End If
            End If
        Catch ex As Exception
            Log(ex) '-- log and ignore
        End Try

    End Sub

    Private Sub m_bgAddUnreadCountToTreeNodes_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles m_bgAddUnreadCountToTreeNodes.DoWork
        Try
            Do While m_lstTreeNodesToAddUnreadCountOnBackgroundThread.Count > 0
                Dim tn As TreeNode = m_lstTreeNodesToAddUnreadCountOnBackgroundThread(0)
                m_lstTreeNodesToAddUnreadCountOnBackgroundThread.Remove(tn)
                ShowUnreadOnNodeText(tn, System.IO.Path.GetFileName(tn.Tag.ToString()), m_boolFormFullyLoaded)
                Application.DoEvents() '-- keep system responsive
            Loop
        Catch ex As Exception
            Log(ex) '-- log and ignore
        End Try
    End Sub

    Private Sub MatchingSenderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MatchingSenderToolStripMenuItem.Click, MatchingSenderToolStripMenuItem1.Click
        Try
            Dim alst As ArrayList = GetCurrentlySelectedMessages()
            If alst.Count <> 1 Then
                ShowMessageBoxAutoClose("Please select one message to use.", STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)
            Else
                Dim tm As TrulyMailMessage = CType(alst(0), TrulyMailMessage)
                NewProcessingRuleFromSender(tm)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBox("There was an error creating a new message processing rule. Please contact TrulyMail Support to check for a solution to this problem.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub MatchingSubjectToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles MatchingSubjectToolStripMenuItem.Click, MatchingSubjectToolStripMenuItem1.Click
        Try
            Dim alst As ArrayList = GetCurrentlySelectedMessages()
            If alst.Count <> 1 Then
                ShowMessageBoxAutoClose("Please select one message to use.", STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)
            Else
                Dim tm As TrulyMailMessage = CType(alst(0), TrulyMailMessage)
                NewProcessingRuleFromSubject(tm)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBox("There was an error creating a new message processing rule. Please contact TrulyMail Support to check for a solution to this problem.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    Private Sub SendNowToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SendNowToolStripMenuItem.Click
        Try
            Dim list As ArrayList = GetCurrentlySelectedMessages()
            For Each tm As TrulyMailMessage In list
                If tm.MessageDateToSend > Date.Now.AddMinutes(-1) Then
                    tm.MessageDateToSend = Date.Now.AddMinutes(-1)
                    tm.Save()
                    olvMessages.RefreshObject(tm)
                End If
            Next

            SendUnsentToolStripMenuItem.PerformClick()
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub

    Private Sub LimitEmailDownloadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LimitEmailDownloadToolStripMenuItem.Click
        Try
            If AppSettings.EmailDownloadLimit Then
                LimitEmailDownloadToolStripMenuItem.Checked = False
                AppSettings.EmailDownloadLimit = False
            Else
                Using frm As New LimitEmailDownloadK()
                    If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        LimitEmailDownloadToolStripMenuItem.Checked = AppSettings.EmailDownloadLimit
                    End If
                End Using
            End If
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub

    Private Sub ExtraToolStripMenuItem_DropDownOpening(sender As System.Object, e As System.EventArgs) Handles ExtraToolStripMenuItem.DropDownOpening
        Try
            If AppSettings.EmailDownloadLimit Then
                LimitEmailDownloadToolStripMenuItem.ToolTipText = "Ask again: " & AppSettings.EmailDownloadLimitExpireDate.ToString("dd MMMM yyyy")
            Else
                LimitEmailDownloadToolStripMenuItem.ToolTipText = ""
            End If
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub

    Private Sub FindOrphanedAttachmentsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FindOrphanedAttachmentsToolStripMenuItem.Click
        Dim frm As New OrphanedAttachments()
        frm.Show()
    End Sub

    Private Sub ManageDoNotSendListToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ManageDoNotSendListToolStripMenuItem.Click
        Dim frm As New ManageDoNotSendList
        frm.Show()
    End Sub

    Private Sub ExtractAttachementsFromSelectedMessagesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExtractAttachementsFromSelectedMessagesToolStripMenuItem.Click
        Try
            Dim ofd As New FolderBrowserDialog()
            ofd.Description = "Please select folder to save attachments in."
            Dim intAttachmentCounter As Integer
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim undoItem As MessageRelocation
                Dim lstAttachments As List(Of AttachmentItem)
                Dim strDestination As String
                Dim strExtension As String
                Dim tm As ArrayList = olvMessages.GetSelectedObjects()
                Dim strSuffix As String = "_dup_"
                Dim intSuffixCounter As Integer

                For Each tmm As TrulyMailMessage In tm
                    If tmm.Attachments.Count > 0 Then
                        lstAttachments = tmm.Attachments()
                        For Each item As AttachmentItem In lstAttachments
                            Application.DoEvents() '-- for breakpoint
                            strDestination = System.IO.Path.Combine(ofd.SelectedPath, item.DisplayName)
                            intSuffixCounter = 0
                            Do Until Not System.IO.File.Exists(strDestination)
                                intSuffixCounter += 1
                                strExtension = System.IO.Path.GetExtension(strDestination)
                                strDestination = System.IO.Path.Combine(ofd.SelectedPath, System.IO.Path.GetFileNameWithoutExtension(item.DisplayName)) & strSuffix & intSuffixCounter.ToString() & strExtension

                            Loop
                            item.CopyDecryptdFileToLocation(strDestination)
                            'System.IO.File.Copy(item.Filename, strDestination)
                            intAttachmentCounter += 1
                        Next
                    End If
                Next
            Else
                '-- do nothing
                Application.DoEvents() '-- for breakpoint
            End If

            ShowMessageBox(intAttachmentCounter.ToString("#,##0") & " attachments were saved.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was a problem saving all the attachments." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub RefreshFolderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshFolderToolStripMenuItem.Click
        ShowCurrentFolderContents()
    End Sub

    Private Sub DelaySendingFor1HourToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DelaySendingFor1HourToolStripMenuItem.Click
        Try
            Dim list As ArrayList = GetCurrentlySelectedMessages()
            For Each tm As TrulyMailMessage In list
                tm.MessageDateToSend = tm.MessageDateToSend.AddMinutes(60)
                tm.Save()
                olvMessages.RefreshObject(tm)
            Next

            SendUnsentToolStripMenuItem.PerformClick()
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub


    Public Sub SetMessageFilter(filter As String)
        Try
            txtMessageFilter.Text = filter
        Catch ex As Exception
            '-- log and continue
            Log(ex)
        End Try
    End Sub

    Private Sub GeneragePrivacyCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneragePrivacyCodeToolStripMenuItem.Click
        Try
            Dim frm As New TM2TMEncryptionKeyGenerator()
            frm.Show()
            'Dim strNewCode = GenerateAlphanumericString(56)
            'If ShowMessageBox("Privacy code has been generated. Would you like to copy it to your clipboard so you can paste it?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            '    Clipboard.SetText(strNewCode)
            'End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub ViewReceiveMessageLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewReceiveMessageLogToolStripMenuItem.Click
        Try
            Dim frm As New ReceiveMessageLogViewer(m_lstReceiveFileLog)
            frm.Show()
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error viewing the receive message log." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub llblJump_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Try
            Dim llbl As LinkLabel = CType(sender, LinkLabel)
            Dim tnToJumpTo As TreeNode = GetTreeNodeByPath(llbl.Tag.ToString())
            tvFolders.SelectedNode = tnToJumpTo
            tnToJumpTo.EnsureVisible()
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub LoadQuickJumps()
        tblLayoutTreeViewQuickJumps.Controls.Clear()
        tblLayoutTreeViewQuickJumps.RowCount = 1
        For Each strPath As String In AppSettings.FolderTreeQuickJumpList
            CreateQuickJump(strPath)
        Next

        pnlTreeViewQuickJump.Visible = AppSettings.FolderTreeQuickJumpList.Count > 0

        '-- Auto-height panel so can always see all jump items
        pnlTreeViewQuickJump.Height = tblLayoutTreeViewQuickJumps.RowStyles(0).Height * tblLayoutTreeViewQuickJumps.RowCount
    End Sub
    Private Sub CreateQuickJump(path As String)
        tblLayoutTreeViewQuickJumps.RowCount = tblLayoutTreeViewQuickJumps.Controls.Count + 1
        Dim llbl As New LinkLabel()
        llbl.Text = System.IO.Path.GetFileName(path)
        llbl.Tag = path
        llbl.Visible = True
        'Me.ToolTip1.SetToolTip(llbl, "Right-click to remove")
        llbl.Font = tblLayoutTreeViewQuickJumps.Font
        AddHandler llbl.LinkClicked, AddressOf llblJump_LinkClicked
        llbl.ContextMenuStrip = ctxmnuQuickJump

        tblLayoutTreeViewQuickJumps.Controls.Add(llbl, 0, tblLayoutTreeViewQuickJumps.RowCount - 1)
    End Sub
    Private Sub RemoveEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveEntryToolStripMenuItem.Click
        '-- Remove item from list then regenerate all controls
        Dim item As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim strip As ContextMenuStrip = item.Owner
        Dim llbl As LinkLabel = CType(strip.SourceControl, LinkLabel)
        AppSettings.FolderTreeQuickJumpList.Remove(llbl.Tag.ToString())

        LoadQuickJumps()
    End Sub

    Private Sub AddSelectedFolderToQuickJumpListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddSelectedFolderToQuickJumpListToolStripMenuItem.Click
        Try
            Dim strPath As String = tvFolders.SelectedNode.Tag
            If strPath.EndsWith("\") Then
                strPath = strPath.Substring(0, strPath.Length - 1)
            End If
            If AppSettings.FolderTreeQuickJumpList.Contains(strPath) Then
                ShowMessageBoxAutoClose("This folder is already in the list.", 4)
                Exit Sub
            End If
            AppSettings.FolderTreeQuickJumpList.Add(strPath)
            CreateQuickJump(strPath)
            pnlTreeViewQuickJump.Visible = True

            '-- Auto-height panel so can always see all jump items
            pnlTreeViewQuickJump.Height = tblLayoutTreeViewQuickJumps.RowStyles(0).Height * tblLayoutTreeViewQuickJumps.RowCount
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub olvMessages_ButtonClick(sender As Object, e As BrightIdeasSoftware.CellClickEventArgs) Handles olvMessages.ButtonClick
        Dim tmm As TrulyMailMessage = CType(e.Model, TrulyMailMessage)
        tmm.Read = Not tmm.Read
        tmm.Save()

        olvMessages.RefreshItem(e.Item)

        UpdateUnreadCount()

    End Sub

  
    Private Sub SendReturnReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendReturnReceiptToolStripMenuItem.Click
        Try
            If GetCurrentlySelectedMessages.Count > 0 Then
                For Each tm As TrulyMailMessage In GetCurrentlySelectedMessages()
                    If tm IsNot Nothing Then
                        tm.SendReadReceipt(True)
                        olvMessages.RefreshObject(tm)
                    End If
                Next
            End If
        Catch ex As Exception
            Log(ex) '-- just log and continue
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        If m_boolUsingRichControl Then
            If ReadMessageControlRich.Visible Then
                ReadMessageControlRich.PrintMessage()
            End If
        Else
            If ReadMessageControlPlain.Visible Then
                ReadMessageControlPlain.PrintMessage()
            End If
        End If
        
    End Sub

    Private Sub ScheduleMessagesInOutboxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScheduleMessagesInOutboxToolStripMenuItem.Click
        Using frm As New ScheduleMessagesInOutboxForm()
            frm.ShowDialog()
        End Using
    End Sub




    Private Sub ReadMessageControl1_SpecialAction(action As ReadMessage7Control.MessageSpecialActionEnum)

    End Sub

    Private Sub MessageHTMLsourceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MessageHTMLsourceToolStripMenuItem.Click
        Try
            Dim frm As New HTMLEditorK()
            If m_boolUsingRichControl Then
                frm.HTMLText = ReadMessageControlRich.MessageBeingRead.Body
            Else
                frm.HTMLText = ReadMessageControlPlain.MessageBeingRead.Body
            End If

            frm.Show()
        Catch ex As Exception
            ShowMessageBoxError("There was an error: " & ex.Message)
        End Try
    End Sub

    Private Sub RefreshFolderToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RefreshFolderToolStripMenuItem1.Click
        ShowCurrentFolderContents()
    End Sub

    Private Sub ClearFiltersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearFiltersToolStripMenuItem.Click
        ClearAllFilters()
    End Sub

    Private Sub FilterMatchOtherPartyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilterMatchOtherPartyToolStripMenuItem.Click
        Try
            Dim tm As TrulyMailMessage = olvMessages.GetSelectedObject()
            Dim strBaseOtherParties As String = GetBaseOtherParty(tm.OtherPartiesShort)
            txtMessageFilter.Text = strBaseOtherParties
        Catch ex As Exception
            '-- ignore errors
        End Try
    End Sub

    Private Sub FilterMatchSubjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilterMatchSubjectToolStripMenuItem.Click
        Try
            Dim tm As TrulyMailMessage = olvMessages.GetSelectedObject()
            Dim strBaseSubject As String = GetBaseSubject(tm.SubjectShort)
            txtMessageFilter.Text = strBaseSubject
        Catch ex As Exception
            '-- ignore
        End Try
    End Sub

    Private Sub WithoutEmbeddedImagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WithoutEmbeddedImagesToolStripMenuItem.Click
        OpenCurrentMessageInBrowser(False)
    End Sub

    Private Sub WithEmbeddedImagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WithEmbeddedImagesToolStripMenuItem.Click
        OpenCurrentMessageInBrowser(True)

    End Sub

    Private Sub ResetSentDateToTodayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetSentDateToTodayToolStripMenuItem.Click
        Try
            Dim tmm As TrulyMailMessage
            If m_boolUsingRichControl Then
                tmm = ReadMessageControlRich.MessageBeingRead
            Else
                tmm = ReadMessageControlPlain.MessageBeingRead
            End If


            tmm.MessageDateSent = Date.UtcNow
            tmm.Save()
        Catch ex As Exception
            '-- ignore
            Application.DoEvents()
        End Try
    End Sub

    Private Sub DarkModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DarkModeToolStripMenuItem.Click
        AppSettings.DarkMode = Not AppSettings.DarkMode
        DarkModeToolStripMenuItem.Checked = AppSettings.DarkMode
        SetupDarkMode()
    End Sub
    Private Sub SetupDarkMode()
        Dim clrDark As Color
        Dim clrLight As Color

        If AppSettings.DarkMode Then
            clrDark = Color.Black
            clrLight = Color.White
            Me.olvMessages.AlternateRowBackColor = Color.Gray
        Else
            '-- normal
            clrDark = Color.White
            clrLight = Color.Black
            Me.olvMessages.AlternateRowBackColor = AppSettings.MessageListAlternatingRowColor
        End If

        tvFolders.BackColor = clrDark
        tvFolders.ForeColor = clrLight
        olvMessages.BackColor = clrDark
        olvMessages.ForeColor = clrLight

        If m_boolUsingRichControl Then
            Me.ReadMessageControlRich.DarkMode = AppSettings.DarkMode
        Else
            Me.ReadMessageControlPlain.DarkMode = AppSettings.DarkMode
        End If
        Me.ContactSelector1.DarkMode = AppSettings.DarkMode

        Me.Refresh()
        If olvMessages.Objects IsNot Nothing Then
            Me.olvMessages.RefreshObjects(olvMessages.Objects) '-- refresh everything
        End If
    End Sub
    Private Sub SetupPreviewControl()
        '-- Note: We ignore AppSettings.UseFallbackModeWhen here because that is only for composing messages, not for reading
        '       Here we use AppSettings.PreviewPaneToReadAsPlainText 

        If AppSettings.ShowMessagePreviewPane Then

            If AppSettings.PreviewPaneToReadAsPlainText Then
                '-- use ReadMessage7Control to read everything as plaintext
                m_boolUsingRichControl = False
                Dim ctrl As ReadMessage7Control
                ctrl = New ReadMessage7Control()

                ctrl.Parent = SplitContainer3.Panel2
                ctrl.Dock = DockStyle.Fill

                'ctrl.DarkMode = False '-- Not yet implemented in the rich control
                ctrl.Dock = System.Windows.Forms.DockStyle.Fill
                ctrl.LoadDelay = 100
                ctrl.Location = New System.Drawing.Point(0, 0)
                ctrl.Name = "ReadMessageControl1"
                ctrl.Size = New System.Drawing.Size(354, 515)
                ctrl.TabIndex = 1
                ctrl.LoadDelay = AppSettings.MessagePreviewLoadDelay * 1000 '-- convert to ms


                AddHandler ctrl.EnableMessageHeaders, AddressOf ReadMessageControl1_EnableMessageHeaders
                AddHandler ctrl.EnableTreatAsReadReceipt, AddressOf ReadMessageControl1_EnableTreatAsReadReceipt
                AddHandler ctrl.SpecialAction, AddressOf ReadMessageControl1_SpecialAction
                AddHandler ctrl.ReadMessageActionSplitterDistanceChanged, AddressOf ReadMessageControl1_ReadMessageActionSplitterDistanceChanged
                AddHandler ctrl.ReadMessageActionSplitterDistanceChanged, AddressOf ReadMessageControl1_ReadMessageActionSplitterDistanceChanged

                ReadMessageControlPlain = ctrl
            Else
                '-- use ReadMessageControl to read as HTML or plaintext, depending on how it was sent
                m_boolUsingRichControl = True

                '-- Setup read message control based on settings and if we are running under WINE
                Dim ctrl As ReadMessageControl
                ctrl = New ReadMessageControl()

                ctrl.Parent = SplitContainer3.Panel2
                ctrl.Dock = DockStyle.Fill

                'ctrl.DarkMode = False '-- Not yet implemented in the rich control
                ctrl.Dock = System.Windows.Forms.DockStyle.Fill
                ctrl.LoadDelay = 100
                ctrl.Location = New System.Drawing.Point(0, 0)
                ctrl.Name = "ReadMessageControl1"
                ctrl.Size = New System.Drawing.Size(354, 515)
                ctrl.TabIndex = 1
                ctrl.LoadDelay = AppSettings.MessagePreviewLoadDelay * 1000 '-- convert to ms


                AddHandler ctrl.EnableMessageHeaders, AddressOf ReadMessageControl1_EnableMessageHeaders
                AddHandler ctrl.EnableTreatAsReadReceipt, AddressOf ReadMessageControl1_EnableTreatAsReadReceipt
                AddHandler ctrl.SpecialAction, AddressOf ReadMessageControl1_SpecialAction
                AddHandler ctrl.ReadMessageActionSplitterDistanceChanged, AddressOf ReadMessageControl1_ReadMessageActionSplitterDistanceChanged

                ReadMessageControlRich = ctrl
            End If

        Else
            '-- do not show preview pane
        End If
    End Sub
    Private Sub OpenCurrentMessageInBrowser(loadRemoteImages As Boolean)
        '-- write out html to temp folder
        '   then open as a process
        Dim strFilename As String = GetTempFilename(".html")
        Dim strContents As String
        If m_boolUsingRichControl Then
            strContents = ReadMessageControlRich.MessageBeingRead.BodySafeHTML
        Else
            strContents = ReadMessageControlPlain.MessageBeingRead.BodySafeHTML
        End If


        '-- Ensure we wrap it in html tags properly
        If strContents.ToLower().IndexOf("<html") = -1 Then
            strContents = "<html>" & strContents & "</html>"
        End If

        If loadRemoteImages Then
            '-- Only unblock images (even remote ones) but no scripts, etc.
            System.IO.File.WriteAllText(strFilename, UnBlockImagesOnlyInHtml(strContents))
        Else
            System.IO.File.WriteAllText(strFilename, strContents)
        End If

        System.Diagnostics.Process.Start(strFilename)

    End Sub

    Private Sub OpenSpecificMessageInBrowser(msg As TrulyMailMessage, loadRemoteImages As Boolean)
        '-- write out html to temp folder
        '   then open as a process
        Dim strFilename As String = GetTempFilename(".html")
        Dim strContents As String
        strContents = msg.BodySafeHTML

        '-- Ensure we wrap it in html tags properly
        If strContents.ToLower().IndexOf("<html") = -1 Then
            strContents = "<html>" & strContents & "</html>"
        End If

        If loadRemoteImages Then
            '-- Only unblock images (even remote ones) but no scripts, etc.
            System.IO.File.WriteAllText(strFilename, UnBlockImagesOnlyInHtml(strContents))
        Else
            System.IO.File.WriteAllText(strFilename, strContents)
        End If

        System.Diagnostics.Process.Start(strFilename)

    End Sub

    Private Sub FilterContactsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilterContactsToolStripMenuItem.Click
        Me.ContactSelector1.Select()
        'Me.ActiveControl = ContactSelector1
        Application.DoEvents()
        Me.ContactSelector1.EnterFilter()
    End Sub

    Private Sub ComposeToTopContactToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.ContactSelector1.ComposeToTop1()
        Timer1.Start()
    End Sub

    Private Sub ComposeToAllContactsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.ContactSelector1.ComposeToAll()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Text = Date.Now.ToString("ss") & " " & Me.ActiveControl.Name
    End Sub

    Private Sub SelectTopMessageInListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectTopMessageInListToolStripMenuItem.Click
        If Me.olvMessages.Items.Count > 0 Then
            Me.olvMessages.SelectedItem = Me.olvMessages.Items(0)
            Me.olvMessages.Focus()
        End If
    End Sub

    Private Sub OpenAsplainTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenAsplainTextToolStripMenuItem.Click
        OpenCurrentlySelectedMessages(True)
    End Sub
End Class