Friend Class MessageSelectorForm

#Region " TreeView Logic "
    Private m_nodeInBox As TreeNode
    Private Function CreateTreeNode(ByVal name As String, ByVal path As String, ByVal imageIndex As Integer, ByVal selectedImageIndex As Integer) As TreeNode
        Dim tn As TreeNode
        tn = tvFolders.Nodes.Add(String.Empty, name)
        tn.Tag = path

        Dim dirInfo As New System.IO.DirectoryInfo(path)
        If Not dirInfo.Exists Then
            dirInfo.Create()
        Else
            If dirInfo.GetDirectories.Length > 0 Then
                AddBlankNode(tn)
            End If
        End If

        tn.ImageIndex = imageIndex
        tn.SelectedImageIndex = selectedImageIndex
        Return tn
    End Function
    Private Sub LoadFolderTree()
        Dim di As New System.IO.DirectoryInfo(MessageStoreRootPath)
        Dim dis() As System.IO.DirectoryInfo = di.GetDirectories()
        Dim tn As TreeNode

        '-- Add the system folders in fixed order
        CreateTreeNode(DRAFTS_FOLDER_NAME, DraftsRootPath, 9, 9)
        m_nodeInBox = CreateTreeNode(INBOX_NAME, InBoxRootPath, 7, 7)
        CreateTreeNode(OUTBOX_NAME, OutboxRootPath, 8, 8)
        CreateTreeNode(SENTITEMS_NAME, SentItemsRootPath, 7, 7)
        CreateTreeNode(TRASH_NAME, TrashRootPath, 5, 5)

        Dim lst As New List(Of String)

        For Each dirInfo As System.IO.DirectoryInfo In dis
            Select Case QualifyPath(dirInfo.FullName.ToLower())
                Case InBoxRootPath.ToLower
                    'ShowUnreadOnNodeText(m_nodeInBox, INBOX_NAME)
                Case SentItemsRootPath.ToLower
                Case OutboxRootPath.ToLower
                    'ShowUnreadOnNodeText(m_nodeOutBox, OUTBOX_NAME)
                Case TrashRootPath.ToLower
                    'CheckTrashIconStatus()
                Case DraftsRootPath.ToLower
                    'ShowUnreadOnNodeText(m_nodeDrafts, DRAFTS_FOLDER_NAME)
                Case Else
                    lst.Add(dirInfo.Name)
            End Select
        Next

        lst.Sort()
        For Each strFolderName In lst
            tn = CreateTreeNode(strFolderName, MessageStoreRootPath & strFolderName, 1, 2)
        Next

        tvFolders.SelectedNode = m_nodeInBox '-- always select inbox
    End Sub
    Private Sub AddBlankNode(ByVal node As TreeNode)
        node.Nodes.Add(String.Empty)
    End Sub
    Private Sub AddChildrenNodes(ByVal node As TreeNode)
        node.Nodes.Clear()
        Dim di As New System.IO.DirectoryInfo(node.Tag.ToString())
        Dim dis() As System.IO.DirectoryInfo = di.GetDirectories()
        Dim tn As TreeNode
        For Each dirInfo As System.IO.DirectoryInfo In dis
            tn = node.Nodes.Add(String.Empty, dirInfo.Name, 1, 2)
            tn.Tag = dirInfo.FullName
            If dirInfo.GetDirectories.Length > 0 Then
                AddBlankNode(tn)
            End If
        Next
    End Sub
    Private Sub tvFolders_BeforeExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvFolders.BeforeExpand
        AddChildrenNodes(e.Node)
    End Sub
    Private Sub tvFolders_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvFolders.AfterSelect
        txtMessageFilter.Text = String.Empty
        ShowCurrentFolderContents()
    End Sub
#End Region
    Private Delegate Function GetCurrentlySelectedTreeViewNodeCallback() As TreeNode
    Private Function GetCurrentlySelectedTreeViewNode() As TreeNode
        If InvokeRequired Then
            Dim deleg As New GetCurrentlySelectedTreeViewNodeCallback(AddressOf GetCurrentlySelectedTreeViewNode)
            Return Invoke(deleg)
        Else
            Return tvFolders.SelectedNode
        End If
    End Function
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
        ShowCurrentFolderContentsLoadMessages(e.Argument)
    End Sub
    Private Sub m_bgwShowFolderContents_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles m_bgwShowFolderContents.RunWorkerCompleted
        ShowCurrentFolderContentsFinalize()
    End Sub
    Private Sub ShowCurrentFolderContents()
        olvMessages.EmptyListMsg = "Loading folder..."
        olvMessages.Items.Clear()
        Application.DoEvents()

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
        Dim lst As New List(Of TrulyMailMessage)
        Dim item As TrulyMailMessage
        Dim intTotalMessages, intUnreadMessages As Integer

        '-- Uses message index for speed
        Using msgIndex As New MessageIndex(SentItemsRootPath)
            Dim loader As New FileListLoader(REGEX_MESSAGE_FILENAME)
            Dim lstFileDetails As List(Of FileDetails) = loader.GetFilesInPath(folderPath, False)


            For Each fd As FileDetails In lstFileDetails
                If m_bgwShowFolderContents.CancellationPending Then
                    Exit Sub
                End If

                item = msgIndex.GetMessage(fd)

                If item IsNot Nothing Then
                    lst.Add(item)

                    If Not item.Read Then
                        intUnreadMessages += 1
                    End If

                    intTotalMessages += 1
                End If
            Next

            msgIndex.Save()
        End Using

        m_folderContentData = New FolderContentData
        m_folderContentData.Messages = lst
        m_folderContentData.TotalMessages = intTotalMessages
        m_folderContentData.UnReadMessages = intUnreadMessages
        m_folderContentData.FolderPath = folderPath

    End Sub

    Private Sub ShowCurrentFolderContentsFinalize()
        Me.olvMessages.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf MainRowFormatter)
        Me.olvColumnSize.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterSize)
        Me.olvColumnMessageDateSent.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterDate)
        Me.olvColumnSubject.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf MessageImageGetter)
        Me.olvColumnTransportType.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf TransportTypeImageGetter)
        Me.olvColumnTransportType.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf NoTextAspectToStringConverter)
        Me.olvColumnHasNotes.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf HasNotesImageGetter)
        Me.olvColumnHasNotes.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf NoTextAspectToStringConverter)

        olvMessages.EmptyListMsg = "This folder is empty"

        If m_folderContentData IsNot Nothing Then
            If m_folderContentData.Messages.Count > 0 Then
                If m_folderContentData.Messages(0).Sent Then
                    olvColumnOtherParties.Text = "Recipients"
                Else
                    olvColumnOtherParties.Text = "Sender"
                End If
            End If

            Me.olvMessages.SetObjects(m_folderContentData.Messages)
        End If

        AutoSizeMessageList()

        m_folderContentData = Nothing
    End Sub
    Private Sub AutoSizeMessageList()
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf AutoSizeMessageList)
            Invoke(deleg)
        Else
            AutoSizeColumns(olvMessages)
        End If
    End Sub
    Private Function MainRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim msg As TrulyMailMessage = CType(olvi.RowObject, TrulyMailMessage)

        Dim LAST_SAVE_DATE_COLOR As Color = Color.Salmon
        Dim TO_SEND_DATE_COLOR As Color = Color.Blue
        Dim UNSENT_DATE_COLOR As Color = Color.Red

        Dim intPositionReceived As Integer = Me.olvMessages.Columns.IndexOf(Me.olvColumnReceived)
        Dim intPositionViewed As Integer = Me.olvMessages.Columns.IndexOf(Me.olvColumnViewed)
        Dim intPositionAttachments As Integer = Me.olvMessages.Columns.IndexOf(Me.olvColumnAttachments)
        Dim intPositionSubject As Integer = Me.olvMessages.Columns.IndexOf(Me.olvColumnSubject)
        Dim intPositionOtherParties As Integer = Me.olvMessages.Columns.IndexOf(Me.olvColumnOtherParties)

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
            For Each tag As MessageTag In AppSettings.MessageTags
                If msg.Tags.Contains(tag.Text) Then
                    newForeColor = tag.Color
                    Exit For
                End If
            Next

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
    Private Function NoTextAspectToStringConverter(ByVal s As String) As String
        Return String.Empty
    End Function
    Private Function AspectToStringConverterDate(ByVal d As Date) As String
        If d.Date = Date.Today Then
            Return d.ToShortTimeString
        Else
            Return d.ToShortDateString & " " & d.ToShortTimeString
        End If
    End Function
    Private Function AspectToStringConverterSize(ByVal i As Integer) As String
        Dim size As Long = CType(i, Long)
        Dim limits() As Integer = {1024 * 1024 * 1024, 1024 * 1024, 1024}
        Dim units() As String = {"GB", "MB", "KB"}
        For intCounter As Integer = 0 To limits.Length - 1
            If size >= limits(intCounter) Then
                Return String.Format("{0:#,##0.#} " & units(intCounter), ((Convert.ToDouble(size) / limits(intCounter))))
            End If
        Next

        Return String.Format("{0} B", size)
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
            Case MessageTransportType.EncryptedWebMessage
                Return 8
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
#End Region

    Private Sub MessageSelectorForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadFolderTree()
        Me.tvFolders.SelectedNode = m_nodeInBox
    End Sub

    Private Sub btnClearMessageFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearMessageFilter.Click
        txtMessageFilter.Text = String.Empty
    End Sub

    Private Sub txtMessageFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMessageFilter.TextChanged
        Try
            olvMessages.ModelFilter = New BrightIdeasSoftware.TextMatchFilter(olvMessages, txtMessageFilter.Text)
            If txtMessageFilter.Text.Length = 0 Then
                olvMessages.EmptyListMsg = "This folder is empty"
            Else
                olvMessages.EmptyListMsg = "No messages match your filter"
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Public Function GetSelectedMessages() As List(Of TrulyMailMessage)
        Dim lstReturn As New List(Of TrulyMailMessage)

        Dim lst As ArrayList = olvMessages.GetSelectedObjects()
        For Each tm As TrulyMailMessage In lst
            lstReturn.Add(tm)
        Next
        Return lstReturn
    End Function
End Class