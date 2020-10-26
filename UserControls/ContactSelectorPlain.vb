Friend Class ContactSelectorPlain

    Private m_boolFilterChanging As Boolean
    Private m_boolHideReceiveOnly As Boolean

    Public Event OKButtonClicked()
    Public Event CancelButtonClicked()

    Private m_lstAllThatCanShow As List(Of AddressBookEntry) '-- master list to speed up filtering

    Public Property HideReceiveOnly As Boolean
        Get
            Return m_boolHideReceiveOnly
        End Get
        Set(ByVal value As Boolean)
            m_boolHideReceiveOnly = value
            LoadAddressBookEntries()
        End Set
    End Property
    Private Property m_boolDarkMode As Boolean
    Public Property DarkMode As Boolean
        Get
            Return m_boolDarkMode
        End Get
        Set(value As Boolean)
            m_boolDarkMode = value

            'If m_boolDarkMode Then
            '    olvContacts.BackColor = Color.Black
            '    olvContacts.ForeColor = Color.White
            'Else
            '    olvContacts.BackColor = Color.White
            '    olvContacts.ForeColor = Color.Black
            'End If

            'olvContacts.Refresh()
            'If olvContacts.Objects IsNot Nothing Then
            '    olvContacts.RefreshObjects(olvContacts.Objects)
            'End If
        End Set
    End Property
    Public Property ShowButtons As Boolean
        Get
            Return Panel2.Visible
        End Get
        Set(value As Boolean)
            Panel2.Visible = False
        End Set
    End Property
    Public Property ShowShortcutMenu As Boolean
        Get
            Return dgvContacts.ContextMenuStrip IsNot Nothing
        End Get
        Set(value As Boolean)
            If value Then
                dgvContacts.ContextMenuStrip = Me.ctxmnuContact
            Else
                dgvContacts.ContextMenuStrip = Nothing
            End If
        End Set
    End Property
    Public Sub ReloadAddressBookEntries()
        ForceAddressBookReload()
        LoadAddressBookEntries()
    End Sub
    Private Sub llblClearFilter_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblClearFilter.LinkClicked
        txtFilter.Text = String.Empty
        txtFilter.Focus()
    End Sub
    Private Sub ContactSelector_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadAddressBookEntries()
    End Sub
#Region " Loading and showing OLV "
    Private Sub LoadAddressBookEntries()
        If Not DesignMode Then
            Dim lst As New List(Of AddressBookEntry)
            Dim lstAllContacts As List(Of AddressBookEntry) = ABook.GetAllContacts
            Dim boolAddThisEntry As Boolean

            For i As Integer = 0 To lstAllContacts.Count - 1
                boolAddThisEntry = True

                If lstAllContacts(i).Blocked Then
                    '-- no blocked contacts
                    boolAddThisEntry = False
                ElseIf lstAllContacts(i).ContactType = AddressBookEntryType.TrulyMail Then
                    '-- no TM contacts
                    boolAddThisEntry = False
                ElseIf lstAllContacts(i).ReceiveOnly Then
                    '-- no receive only contacts
                    boolAddThisEntry = False
                End If

                If boolAddThisEntry Then
                    lst.Add(lstAllContacts(i))
                End If
            Next

            m_lstAllThatCanShow = lst
            dgvContacts.AutoGenerateColumns = False
            dgvContacts.DataSource = m_lstAllThatCanShow

            SortByLastSent()

            dgvContacts.AutoResizeColumns()
        End If

    End Sub

    Private Function ContactImageGetter(ByVal row As Object) As Object
        Dim entry As AddressBookEntry = CType(row, AddressBookEntry)
        Select Case entry.ContactType
            Case AddressBookEntryType.TrulyMail
                Return 0
            Case AddressBookEntryType.Email
                Return 1
        End Select
    End Function

#End Region
    Private m_boolAutoChangingFilterText As Boolean
    Private Sub txtFilter_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.Enter
        If txtFilter.ForeColor = Color.DarkGray Then
            m_boolAutoChangingFilterText = True
            txtFilter.Text = String.Empty
            m_boolAutoChangingFilterText = False
        End If
    End Sub
    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        If Not DesignMode AndAlso Not m_boolAutoChangingFilterText Then
            Dim boolEmptyFilter As Boolean = txtFilter.Text.Length = 0 OrElse txtFilter.Text = "Name or email or tag"
            If txtFilter.ForeColor = Color.DarkGray Then
                If Not boolEmptyFilter Then
                    txtFilter.ForeColor = Color.Black
                End If
            End If

            '-- only show contacts which match the filter
            If boolEmptyFilter Then
                LoadAddressBookEntries()
            Else
                Try
                    Dim strSearchFor As String
                    strSearchFor = txtFilter.Text.ToLower

                    Dim lstFiltered As List(Of AddressBookEntry)
                    lstFiltered = m_lstAllThatCanShow.Where(Function(x) x.FullName.ToLower.Contains(strSearchFor) OrElse
                                                                        x.Address.ToLower.Contains(strSearchFor) OrElse
                                                                        x.Tags.ToLower.Contains(strSearchFor)).ToList

                    dgvContacts.DataSource = Nothing
                    dgvContacts.DataSource = lstFiltered
                    dgvContacts.AutoResizeColumns()
                Catch ex As Exception
                    Log(ex)
                End Try
            End If
        End If

    End Sub
    Private Sub txtFilter_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.Leave
        If txtFilter.Text.Length = 0 Then
            m_boolFilterChanging = True
            txtFilter.Text = "Name or email or tag"
            txtFilter.ForeColor = Color.DarkGray
            m_boolFilterChanging = False
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        RaiseEvent CancelButtonClicked()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        RaiseEvent OKButtonClicked()
    End Sub
    Public Function GetSelectedContacts() As List(Of AddressBookEntry)

        Dim lstReturn As New List(Of AddressBookEntry)

        Dim cells As DataGridViewSelectedCellCollection

        cells = dgvContacts.SelectedCells

        Dim row As DataGridViewRow
        Dim entry As AddressBookEntry

        Dim dict As New Dictionary(Of Integer, Object)
        For Each cell As DataGridViewCell In cells
            If Not dict.ContainsKey(cell.RowIndex) Then
                dict.Add(cell.RowIndex, Nothing)

                row = dgvContacts.Rows(cell.RowIndex)
                entry = row.DataBoundItem
                If entry IsNot Nothing Then
                    lstReturn.Add(entry)
                End If
            End If
        Next
        Return lstReturn
    End Function
    Private Sub ComposeMessageToSelectedContacts()
        Dim lst As List(Of AddressBookEntry) = GetSelectedContacts()
        If lst.Count > 0 Then
            Dim arrList As New System.Collections.ArrayList(lst)
            Dim frm As IComposeForm

            If UseFallbackModeNow() Then
                frm = New NewMessageSimple(arrList)
            Else
                frm = New NewMessage(arrList)
            End If
            CType(frm, Form).Show()
        End If
    End Sub
    Private Sub ComposeNewMessageToSelectedContactsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ComposeNewMessageToSelectedContactsToolStripMenuItem.Click
        ComposeMessageToSelectedContacts()
    End Sub
    Private Sub CopySelectedAddresses()
        Dim lst As List(Of AddressBookEntry) = GetSelectedContacts()
        If lst.Count < 1 Then
            ShowMessageBox("Please only select at one contact to copy.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim strReturn As String
            For intCounter As Integer = 0 To lst.Count - 1
                Dim entry As AddressBookEntry = CType(lst(intCounter), AddressBookEntry)
                If strReturn Is Nothing Then
                    strReturn = entry.NameWithAddress
                Else
                    strReturn &= "; " & entry.NameWithAddress
                End If
                Clipboard.SetText(strReturn)
            Next
        End If
    End Sub
    Private Sub EditSelectedContact()
        Dim lst As List(Of AddressBookEntry) = GetSelectedContacts()
        If lst.Count <> 1 Then
            ShowMessageBox("Please only select one contact to edit.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim entry As AddressBookEntry = CType(lst(0), AddressBookEntry)
            EditContactDetails(entry.ID)
        End If
    End Sub
    Private Sub EditContactToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditContactToolStripMenuItem.Click
        EditSelectedContact()
    End Sub

    Private Sub dgvContacts_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvContacts.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ModifierKeys = Keys.Alt Then
                EditSelectedContact()
            Else
                ComposeMessageToSelectedContacts()
            End If
        End If
    End Sub

    Private Sub txtFilter_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFilter.KeyDown
        If e.KeyCode = Keys.Escape Then
            txtFilter.Text = String.Empty
        ElseIf e.KeyCode = Keys.D1 Then
            If ModifierKeys = (Keys.Control Or Keys.Shift) Then
                ComposeToTop1()
            End If
        ElseIf e.KeyCode = Keys.D9 Then
            If ModifierKeys = (Keys.Control Or Keys.Shift) Then
                ComposeToAll()
            End If
        End If
    End Sub
    Public Sub SortByLastSent()
        Try
            Dim cmp As IComparer(Of AddressBookEntry) = New AddressBookEntryComparerByImportanceAndLastSent()
            Dim lst As List(Of AddressBookEntry) = dgvContacts.DataSource
            lst.Sort(cmp)
            dgvContacts.DataSource = Nothing
            dgvContacts.Refresh()
            dgvContacts.DataSource = lst
            dgvContacts.Refresh()
        Catch ex As Exception
            Log(ex) '-- log and ignore
        End Try
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Try
            LoadAddressBookEntries()
        Catch ex As Exception
            Log(ex) '-- log and ignore
            ShowMessageBoxError("There was an error refreshing your contacts." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub ctxmnuContact_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ctxmnuContact.Opening
        Try
            If Me.ParentForm Is MainFormReference Then
                FilterMessagesByThisContactToolStripMenuItem.Visible = True
            End If

        Catch ex As Exception
            Log(ex) '-- log and ignore
        End Try
    End Sub

    Private Sub ForwardSelectedMessageToSelectedContactsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ForwardSelectedMessageToSelectedContactsToolStripMenuItem.Click
        Try
            If Me.ParentForm Is MainFormReference Then
                Dim lst As List(Of AddressBookEntry) = GetSelectedContacts()
                MainFormReference.ForwardSelectedMessages(lst)
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub FilterMessagesByThisContactToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FilterMessagesByThisContactToolStripMenuItem.Click
        Dim lst As List(Of AddressBookEntry) = GetSelectedContacts()
        If lst.Count <> 1 Then
            ShowMessageBox("Please only select one contact for the filter.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim entry As AddressBookEntry = CType(lst(0), AddressBookEntry)
            MainFormReference.SetMessageFilter(entry.FullName)
            'RaiseEvent SetFilter(entry.FullName) '-- would have prefered to raise an event but the MainForm was simply not reacting to the event
        End If
    End Sub

    Private Sub dgvContacts_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvContacts.ColumnHeaderMouseClick
        '-- Manually sort
        Try
            Dim col As DataGridViewColumn = dgvContacts.Columns(e.ColumnIndex)
            Dim lst As List(Of AddressBookEntry) = dgvContacts.DataSource
            Dim cmp As IComparer(Of AddressBookEntry)
            Dim boolSort As Boolean = True

            If col IsNot Nothing Then
                Select Case col.DataPropertyName
                    Case "Tags"
                        cmp = New AddressBookEntryComparerByTags
                    Case Else
                        boolSort = False
                End Select

                If boolSort Then
                    lst.Sort(cmp)
                    dgvContacts.DataSource = Nothing
                    dgvContacts.Refresh()
                    dgvContacts.DataSource = lst
                    dgvContacts.Refresh()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("There was an error sorting: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvContacts_DragDrop(sender As Object, e As DragEventArgs) Handles dgvContacts.DragDrop
        Try
            Dim lstEntries As New List(Of AddressBookEntry) '-- recipients
            Dim row As DataGridViewRow
            Dim entry As AddressBookEntry
            Dim hi As DataGridView.HitTestInfo
            Dim pt As Point = dgvContacts.PointToClient(New Point(e.X, e.Y))
            hi = dgvContacts.HitTest(pt.X, pt.Y)

            Select Case hi.Type
                Case DataGridViewHitTestType.Cell, DataGridViewHitTestType.RowHeader
                    '-- send to drop target (only one)
                    row = dgvContacts.Rows(hi.RowIndex)
                    entry = row.DataBoundItem

                    'If entry Is Nothing Then
                    '    Exit Sub '-- nothing to do
                    'End If

                    lstEntries.Add(entry)
                Case DataGridViewHitTestType.TopLeftHeader
                    '-- send to all in list (but confirm if not filtered)
                    For Each row In dgvContacts.Rows
                        entry = row.DataBoundItem
                        lstEntries.Add(entry)
                    Next
                Case Else
                    Exit Sub
            End Select



            If e.Data.GetDataPresent("FileDrop") Then
                '-- Files
                Dim files As Array
                files = CType(e.Data.GetData(DataFormats.FileDrop), Array)

                Dim arrList As New System.Collections.ArrayList(lstEntries)

                Dim strFilename As String
                If UseFallbackModeNow() Then
                    Dim frm As New NewMessageSimple(arrList)
                    frm.Show()
                    For intCounter As Integer = 0 To files.Length - 1
                        strFilename = files.GetValue(intCounter).ToString
                        frm.AddAttachment(strFilename)
                    Next
                Else
                    Dim frm As New NewMessage(arrList)
                    frm.Show()
                    For intCounter As Integer = 0 To files.Length - 1
                        strFilename = files.GetValue(intCounter).ToString
                        frm.AddAttachment(strFilename)
                    Next
                End If

            ElseIf e.Data.GetDataPresent("System.Collections.ArrayList") Then
                '-- TMM
                Dim arr As ArrayList
                arr = CType(e.Data.GetData("System.Collections.ArrayList"), System.Collections.ArrayList)

                For Each tmm As TrulyMailMessage In arr
                    If UseFallbackModeNow() Then
                        Dim frm As New NewMessageSimple(tmm.Filename, MessageResponseType.Forward)
                        frm.AddRecipientList(lstEntries, RecipientType.Send_To)
                        frm.Show()
                    Else
                        Dim frm As New NewMessage(tmm.Filename, MessageResponseType.Forward)
                        frm.AddRecipientList(lstEntries, RecipientType.Send_To)
                        frm.Show()
                    End If
                Next
            End If

        Catch ex As Exception
            ShowMessageBoxError("There was a problem creating a new message." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try


    End Sub

    Private Sub dgvContacts_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles dgvContacts.GiveFeedback
        txtFilter.Text = MousePosition.X.ToString()
    End Sub

    Private Sub dgvContacts_DragOver(sender As Object, e As DragEventArgs) Handles dgvContacts.DragOver
        e.Effect = DragDropEffects.Move
        dgvContacts.ClearSelection()

        '-- clear all highlights
        For Each row As DataGridViewRow In dgvContacts.Rows
            row.DefaultCellStyle.BackColor = Color.White
        Next

        Dim pt As Point = dgvContacts.PointToClient(New Point(e.X, e.Y))
        Dim hi As DataGridView.HitTestInfo
        hi = dgvContacts.HitTest(pt.X, pt.Y)

        Select Case hi.Type
            Case DataGridViewHitTestType.Cell, DataGridViewHitTestType.RowHeader
                '-- highlight row
                Dim row As DataGridViewRow
                row = dgvContacts.Rows(hi.RowIndex)
                row.DefaultCellStyle.BackColor = Color.Yellow
            Case DataGridViewHitTestType.TopLeftHeader
                '-- highlight all
                For Each row As DataGridViewRow In dgvContacts.Rows
                    row.DefaultCellStyle.BackColor = Color.Yellow
                Next
            Case Else
                '-- do nothing
        End Select

    End Sub

    Private Sub dgvContacts_DragEnter(sender As Object, e As DragEventArgs) Handles dgvContacts.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub dgvContacts_MouseLeave(sender As Object, e As EventArgs) Handles dgvContacts.MouseLeave
        '-- clear all highlights
        For Each row As DataGridViewRow In dgvContacts.Rows
            row.DefaultCellStyle.BackColor = Color.White
        Next
    End Sub

    Private Sub dgvContacts_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvContacts.MouseDoubleClick
        ComposeMessageToSelectedContacts()
    End Sub

    Public Sub EnterFilter()
        txtFilter.Focus()
        txtFilter.Select()
    End Sub
    Public Sub ComposeToTop1()
        Dim lstEntries As New List(Of AddressBookEntry) '-- recipients
        Dim row As DataGridViewRow
        Dim entry As AddressBookEntry
        If dgvContacts.Rows.Count > 0 Then
            row = dgvContacts.Rows(0)
            entry = row.DataBoundItem
            lstEntries.Add(entry)
        Else
            ShowMessageBoxAutoClose("No contacts in list", 3)
        End If
        ComposeToList(lstEntries)
    End Sub
    Public Sub ComposeToAll()
        Dim lstEntries As New List(Of AddressBookEntry) '-- recipients
        Dim row As DataGridViewRow
        Dim entry As AddressBookEntry
        For Each row In dgvContacts.Rows
            entry = row.DataBoundItem
            lstEntries.Add(entry)
        Next
        ComposeToList(lstEntries)
    End Sub

    Private Sub ComposeToList(entries As List(Of AddressBookEntry))
        If UseFallbackModeNow() Then
            Dim frm As New NewMessageSimple()
            frm.AddRecipientList(entries, RecipientType.Send_To)
            frm.Show()
        Else
            Dim frm As New NewMessage()
            frm.AddRecipientList(entries, RecipientType.Send_To)
            frm.Show()
        End If
    End Sub

    Private Sub CopyaddressToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyaddressToolStripMenuItem.Click
        CopySelectedAddresses()
    End Sub
    'Protected Overrides Sub OnEnter(e As EventArgs)
    '    MyBase.OnEnter(e)
    '    txtFilter.Select()
    '    'EnterFilter()
    '    'MessageBox.Show("Hello")
    'End Sub

End Class
