Public Class FolderBrowserDialogTM

    Public Property ShowAllFolders As Boolean = False
    Private m_strSelectedPath As String
    Private m_boolFullyLoaded As Boolean
    Private m_nodeDelayedSelectNode As TreeNode
    Private m_strDelayedSelectNodePath As String

    Public Property Description As String
        Get
            Return lblDescription.Text
        End Get
        Set(ByVal value As String)
            lblDescription.Text = value
        End Set
    End Property
    Public Property Title As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property
    Public Property SelectedPath As String
        Get
            Return Me.tvMessageFolders.SelectedNode.Tag.ToString()
        End Get
        Set(ByVal value As String)
            m_strSelectedPath = QualifyPath(value.ToLower())
        End Set
    End Property
    Public Property ShowNewFolderButton As Boolean
        Get
            Return btnNewFolder.Visible
        End Get
        Set(ByVal value As Boolean)
            btnNewFolder.Visible = value
        End Set
    End Property

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        '-- Add the most recent path, duplicates here are expected
        If AppSettings.RecentFolderList.Contains(SelectedPath) Then
            AppSettings.RecentFolderList.Remove(SelectedPath)
        End If
        AppSettings.RecentFolderList.Insert(0, SelectedPath) '-- Add it to the top of the list

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Function CreateTreeNode(ByVal name As String, ByVal path As String, ByVal imageIndex As Integer, ByVal selectedImageIndex As Integer) As TreeNode
        Try
            Dim tn As TreeNode
            tn = tvMessageFolders.Nodes.Add(String.Empty, name)
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

            tn.ImageIndex = imageIndex
            tn.SelectedImageIndex = selectedImageIndex
            Return tn
        Catch ex As Exception
            Log(ex)
            Log("Path: " & path)
            Return Nothing
        End Try

    End Function
    Private Sub AddBlankNode(ByVal node As TreeNode)
        node.Nodes.Add(String.Empty)
    End Sub
    Private Sub LoadMessageFolderTree()
        Me.tvMessageFolders.Nodes.Clear()
        Dim di As New System.IO.DirectoryInfo(MessageStoreRootPath)
        'Dim dis() As System.IO.DirectoryInfo = di.GetDirectories()
        Dim directories() As String = System.IO.Directory.GetDirectories(di.FullName, "*.*", IO.SearchOption.TopDirectoryOnly)
        Array.Sort(directories)

        Dim tn As TreeNode

        '-- Add All Folders node at the top
        If Me.ShowAllFolders Then
            tn = tvMessageFolders.Nodes.Add(String.Empty, "All Folders")
            tn.ImageIndex = 22
            tn.SelectedImageIndex = 22
            tn.Tag = MessageStoreRootPath
        End If

        '-- Add the system folders in fixed order
        CreateTreeNode(DRAFTS_FOLDER_NAME, DraftsRootPath, 9, 9)
        CreateTreeNode(INBOX_NAME, InBoxRootPath, 7, 7)
        CreateTreeNode(OUTBOX_NAME, OutboxRootPath, 8, 8)
        CreateTreeNode(SENTITEMS_NAME, SentItemsRootPath, 7, 7)
        CreateTreeNode(TRASH_NAME, TrashRootPath, 5, 5)

        Dim lst As New List(Of String)

        Array.Sort(directories)

        For Each strDirectory As String In directories
            Select Case QualifyPath(strDirectory.ToLower())
                Case InBoxRootPath.ToLower
                Case SentItemsRootPath.ToLower
                Case OutboxRootPath.ToLower
                Case TrashRootPath.ToLower
                Case DraftsRootPath.ToLower
                Case Else
                    lst.Add(strDirectory)
            End Select
        Next

        For Each strFolderName In lst
            Dim folder As FolderState = GetFolderState(MessageStoreRootPath & strFolderName)
            Dim intFolderIcon As Integer = FOLDER_COLOR_BASE_CLOSED_INDEX + folder.Icon
            Dim intFolderSelectedIcon As Integer = FOLDER_COLOR_BASE_OPEN_INDEX + folder.Icon

            tn = CreateTreeNode(System.IO.Path.GetFileName(strFolderName), strFolderName, intFolderIcon, intFolderSelectedIcon)
        Next

    End Sub
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
    Private Sub AddChildrenNodes(ByVal node As TreeNode)
        Try
            node.Nodes.Clear()
            Dim di As New System.IO.DirectoryInfo(node.Tag.ToString())
            Dim dis() As System.IO.DirectoryInfo = di.GetDirectories()
            Dim tn As TreeNode
            For Each dirInfo As System.IO.DirectoryInfo In dis
                Dim folder As FolderState = GetFolderState(dirInfo.FullName)
                Dim intFolderIcon As Integer = FOLDER_COLOR_BASE_CLOSED_INDEX + folder.Icon
                Dim intFolderSelectedIcon As Integer = FOLDER_COLOR_BASE_OPEN_INDEX + folder.Icon

                tn = node.Nodes.Add(String.Empty, dirInfo.Name, intFolderIcon, intFolderSelectedIcon)
                tn.Tag = QualifyPath(dirInfo.FullName)

                AddChildrenNodes(tn)
                Application.DoEvents()
                tn.Expand()

            Next
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error reading the folders within TrulyMail." & CONTACT_TRULYMAIL_MESSAGE)
        End Try
    End Sub

    Private Sub FolderBrowserDialogTM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '-- load up the quick links
        For Each item As String In AppSettings.RecentFolderList
            CreateQuickLink(item)
        Next


        'Dim dict As New Dictionary(Of String, Integer)
        'Dim lst As New List(Of String)
        ''-- load up the quick links
        ''   Put the most frequently used (of the past 30) first
        'For Each strPath As String In AppSettings.RecentFolderList
        '    If dict.ContainsKey(strPath) Then
        '        dict(strPath) += 1 '-- increment
        '    Else
        '        dict.Add(strPath, 1) '-- add to dict
        '    End If
        'Next

        '-- sort by value
        'Dim sortedDict = (From entry In dict Order By entry.Value Descending Select entry)
        'For Each item In sortedDict
        '    CreateQuickLink(item.Key)
        'Next



        LoadMessageFolderTree()
    End Sub
    Private Sub CreateQuickLink(path As String)
        Static intCounter As Integer

        If intCounter > 8 Then
            Exit Sub '-- We just handle the 9 most frequently used paths
        End If

        Dim llbl As New LinkLabel()
        llbl.Tag = path
        Me.ToolTip1.SetToolTip(llbl, path)

        If path.EndsWith(System.IO.Path.DirectorySeparatorChar) Then
            path = path.Substring(0, path.Length - 1)
        End If
        llbl.Text = System.IO.Path.GetFileName(path)
        llbl.Visible = True
        llbl.Anchor = AnchorStyles.None
        llbl.Font = tblQuickLinks.Font
        AddHandler llbl.LinkClicked, AddressOf llblQuickLink_LinkClicked

        tblQuickLinks.Controls.Add(llbl, intCounter Mod tblQuickLinks.ColumnCount, intCounter \ tblQuickLinks.ColumnCount)

        intCounter += 1
    End Sub
    Private Sub llblQuickLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Try
            Dim llbl As LinkLabel = CType(sender, LinkLabel)
            SelectFolderFromPath(llbl.Tag)
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Private Function SelectFolder(ByVal node As TreeNode, ByVal path As String) As Boolean
        '-- recurse
        If node.Nodes.Count > 0 Then
            For Each tn As TreeNode In node.Nodes
                If tn.Tag Is Nothing AndAlso path.Contains(node.Tag.ToString) AndAlso Not node.IsExpanded Then
                    node.Expand()
                    m_nodeDelayedSelectNode = node
                    m_strDelayedSelectNodePath = path
                    Timer1.Start()
                    Return True '-- delay and select should act like folder was already selected
                End If

                If tn.Tag IsNot Nothing Then
                    If SelectFolder(tn, path) Then
                        Return True
                    End If
                End If
            Next
        End If

        If QualifyPath(node.Tag.ToString.ToLower()) = path Then
            tvMessageFolders.SelectedNode = node
            Return True
        End If

        Return False
    End Function
    Private Sub FolderBrowserDialogTM_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            m_boolFullyLoaded = True

            If m_strSelectedPath IsNot Nothing Then
                SelectFolderFromPath(m_strSelectedPath)
            Else
                SelectLastSelectedNode()
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub SelectFolderFromPath(path As String)
        For Each tn As TreeNode In tvMessageFolders.Nodes
            If tn.Nodes.Count > 0 Then
                For Each tn2 As TreeNode In tn.Nodes
                    If tn2.Tag IsNot Nothing Then
                        If SelectFolder(tn, path) Then
                            Exit Sub
                        End If
                    End If
                Next
            End If

            If tn.Tag.ToString.ToLower = path Then
                tvMessageFolders.SelectedNode = tn
                Exit For
            End If
        Next
    End Sub

    Private Sub btnNewFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewFolder.Click
        Try
            If tvMessageFolders.SelectedNode IsNot Nothing Then
                Dim strPath As String = tvMessageFolders.SelectedNode.Tag.ToString()
                Const NEWFOLDER_BASENAME As String = "New Folder"
                Dim strNewFolderName As String = NEWFOLDER_BASENAME
                Dim strNewPath As String = System.IO.Path.Combine(strPath, strNewFolderName)
                Dim intCounter As Integer
                Do Until Not System.IO.Directory.Exists(strNewPath)
                    intCounter += 1
                    strNewFolderName = NEWFOLDER_BASENAME & " " & intCounter
                    strNewPath = System.IO.Path.Combine(strPath, strNewFolderName)
                Loop

                System.IO.Directory.CreateDirectory(strNewPath)
                tvMessageFolders.SelectedNode.Nodes.Clear()
                AddChildrenNodes(tvMessageFolders.SelectedNode)
                tvMessageFolders.SelectedNode.Expand()
                SelectFolder(tvMessageFolders.SelectedNode, QualifyPath(strNewPath.ToLower()))
                MainFormReference.AddFolderToFolderTree(strNewPath)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error creating your new folder. " & CONTACT_TRULYMAIL_MESSAGE)
        End Try
    End Sub

    Private Sub tvMessageFolders_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles tvMessageFolders.AfterLabelEdit
        '-- rename underlying folder and update nodes
        Try
            '-- label is nothing when user hits {ESC} to cancel out (but cancel does not become true)
            '   If label = node.text then the user typed the same name, no need to change anything
            If e.Label IsNot Nothing AndAlso Not e.Node.Text.ToLower.Equals(e.Label.ToLower) Then
                Dim strOldPath As String = UnQualifyPath(e.Node.Tag.ToString)
                Dim srNewPath As String = System.IO.Path.GetDirectoryName(strOldPath) & "\" & e.Label
                If Not strOldPath.ToLower.Equals(srNewPath.ToLower) Then
                    System.IO.Directory.Move(strOldPath, srNewPath)
                    e.Node.Tag = QualifyPath(srNewPath)
                    e.Node.Collapse()
                    e.Node.Expand()
                End If
            End If
        Catch ex As Exception
            e.CancelEdit = True
            MessageBox.Show("There was an error renaming the folder (" & ex.Message & ").", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub tvMessageFolders_BeforeExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvMessageFolders.BeforeExpand
        AddChildrenNodes(e.Node)
    End Sub
    Private Function SelectLastSelectedNode() As Boolean
        Try
            If AppSettings.LastSelectedFolderInFolderBrowser IsNot Nothing AndAlso AppSettings.LastSelectedFolderInFolderBrowser.Length > 0 Then
                For Each tn As TreeNode In tvMessageFolders.Nodes
                    If AppSettings.LastSelectedFolderInFolderBrowser.Contains(tn.Tag.ToString()) Then
                        SelectFolder(tn, AppSettings.LastSelectedFolderInFolderBrowser)
                        Return True
                    End If
                Next
            End If

            Return False
        Catch ex As Exception
            Log(ex) '-- Log and continue
            Return False
        End Try
    End Function

    Private Sub tvMessageFolders_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvMessageFolders.AfterSelect
        Try
            If m_boolFullyLoaded Then
                AppSettings.LastSelectedFolderInFolderBrowser = e.Node.Tag.ToString()
            End If
        Catch ex As Exception
            Log(ex) '-- Log and continue
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        SelectFolder(m_nodeDelayedSelectNode, m_strDelayedSelectNodePath)
    End Sub

    Private Sub ClearRecentFoldersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearRecentFoldersToolStripMenuItem.Click
        AppSettings.RecentFolderList.Clear()
        tblQuickLinks.Controls.Clear()
    End Sub
End Class