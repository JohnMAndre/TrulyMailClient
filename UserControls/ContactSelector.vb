Friend Class ContactSelector

    Private m_boolFilterChanging As Boolean
    Private m_boolHideReceiveOnly As Boolean

    Public Event OKButtonClicked()
    Public Event CancelButtonClicked()
    'Public Event SetFilter(filter As String)

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

            If m_boolDarkMode Then
                olvContacts.BackColor = Color.Black
                olvContacts.ForeColor = Color.White
            Else
                olvContacts.BackColor = Color.White
                olvContacts.ForeColor = Color.Black
            End If

            olvContacts.Refresh()
            If olvContacts.Objects IsNot Nothing Then
                olvContacts.RefreshObjects(olvContacts.Objects)
            End If
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
            Return olvContacts.ContextMenuStrip IsNot Nothing
        End Get
        Set(value As Boolean)
            If value Then
                olvContacts.ContextMenuStrip = Me.ctxmnuContact
            Else
                olvContacts.ContextMenuStrip = Nothing
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
            NameColumn.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf ContactImageGetter)

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

            olvContacts.SetObjects(lst)

            AutoSizeColumns(olvContacts)
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
    Private Sub txtFilter_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.Enter
        If txtFilter.ForeColor = Color.DarkGray Then
            txtFilter.Text = String.Empty
        End If
    End Sub
    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        If Not DesignMode Then
            Dim boolEmptyFilter As Boolean = txtFilter.Text.Length = 0 OrElse txtFilter.Text = "Name or email or tag"
            If txtFilter.ForeColor = Color.DarkGray Then
                If Not boolEmptyFilter Then
                    txtFilter.ForeColor = Color.Black
                End If
            End If

            '-- only show contacts which match the filter
            If Not boolEmptyFilter Then
                Try
                    olvContacts.ModelFilter = New BrightIdeasSoftware.TextMatchFilter(olvContacts, txtFilter.Text)
                Catch ex As Exception
                    Log(ex)
                End Try
            Else
                olvContacts.ModelFilter = Nothing
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
        Dim lst As ArrayList = olvContacts.SelectedObjects()
        Dim lstReturn As New List(Of AddressBookEntry)
        For Each entry As AddressBookEntry In lst
            lstReturn.Add(entry)
        Next
        Return lstReturn
    End Function
    Private Sub ComposeMessageToSelectedContacts()
        If olvContacts.SelectedObjects().Count > 0 Then
            Dim lst As ArrayList = olvContacts.SelectedObjects()
            Dim frm As IComposeForm

            If UseFallbackModeNow() Then
                frm = New NewMessageSimple(lst)
            Else
                frm = New NewMessage(lst)
            End If
            CType(frm, Form).Show()
        End If
    End Sub
    Private Sub ComposeNewMessageToSelectedContactsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ComposeNewMessageToSelectedContactsToolStripMenuItem.Click
        ComposeMessageToSelectedContacts()
    End Sub
    Private Sub EditSelectedContact()
        If olvContacts.SelectedObjects().Count <> 1 Then
            ShowMessageBox("Please only select one contact to edit.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim entry As AddressBookEntry = CType(olvContacts.GetSelectedObject, AddressBookEntry)
            EditContactDetails(entry.ID)
        End If
    End Sub
    Private Sub EditContactToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditContactToolStripMenuItem.Click
        EditSelectedContact()
    End Sub

    Private Sub olvContacts_ItemActivate(sender As System.Object, e As System.EventArgs) Handles olvContacts.ItemActivate
        If ModifierKeys = Keys.Alt Then
            EditSelectedContact()
        Else
            ComposeMessageToSelectedContacts()
        End If
    End Sub

    Private Sub txtFilter_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFilter.KeyDown
        If e.KeyCode = Keys.Escape Then
            txtFilter.Text = String.Empty
        End If
    End Sub
    Public Sub SortByLastSent()
        Try
            olvContacts.PrimarySortColumn = ImportanceColumn
            olvContacts.PrimarySortOrder = SortOrder.Descending
            olvContacts.SecondarySortColumn = LastSentColumn
            olvContacts.SecondarySortOrder = SortOrder.Descending
            olvContacts.Sort()
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
                Dim lst As New List(Of AddressBookEntry)
                For Each contact As AddressBookEntry In olvContacts.SelectedObjects
                    lst.Add(contact)
                Next
                MainFormReference.ForwardSelectedMessages(lst)
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub FilterMessagesByThisContactToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FilterMessagesByThisContactToolStripMenuItem.Click
        If olvContacts.SelectedObjects().Count <> 1 Then
            ShowMessageBox("Please only select one contact for the filter.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim entry As AddressBookEntry = CType(olvContacts.GetSelectedObject, AddressBookEntry)
            MainFormReference.SetMessageFilter(entry.FullName)
            'RaiseEvent SetFilter(entry.FullName) '-- would have prefered to raise an event but the MainForm was simply not reacting to the event
        End If
    End Sub

    Private Sub olvContacts_Dropped(sender As Object, e As BrightIdeasSoftware.OlvDropEventArgs) Handles olvContacts.Dropped
        Try
            Dim dataobj As System.Windows.Forms.DataObject = CType(e.DataObject, System.Windows.Forms.DataObject)
            If dataobj.ContainsFileDropList Then
                Dim lst As New ArrayList()
                lst.Add(CType(e.DropTargetItem.RowObject, AddressBookEntry))
                If UseFallbackModeNow() Then
                    Dim frm As New NewMessageSimple(lst)
                    frm.Show()

                    Dim files As System.Collections.Specialized.StringCollection = dataobj.GetFileDropList()
                    For Each strFilename As String In files
                        frm.AddAttachment(strFilename)
                    Next
                Else
                    Dim frm As New NewMessage(lst)
                    frm.Show()

                    Dim files As System.Collections.Specialized.StringCollection = dataobj.GetFileDropList()
                    For Each strFilename As String In files
                        frm.AddAttachment(strFilename)
                    Next
                End If

            Else
                '-- do nothing

            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was a problem creating a new message." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub olvContacts_CanDrop(sender As Object, e As BrightIdeasSoftware.OlvDropEventArgs) Handles olvContacts.CanDrop
        Try
            If e.DropTargetItem Is Nothing Then
                e.Effect = DragDropEffects.None
                Exit Sub
            End If

            Dim dataobj As System.Windows.Forms.DataObject = CType(e.DataObject, System.Windows.Forms.DataObject)

            If Not dataobj.ContainsFileDropList Then
                '-- It is ok to drop from msgs olv
                Dim arrList As New System.Collections.ArrayList()
                Dim typArrayList As Type = arrList.GetType()
                If dataobj.GetDataPresent(typArrayList) Then
                    arrList = CType(dataobj.GetData(typArrayList), ArrayList)
                    Application.DoEvents()
                    If arrList.Count > 0 Then
                        If TypeOf arrList(0) Is TrulyMailMessage Then
                            e.Effect = DragDropEffects.Copy
                            Exit Sub
                        End If
                    End If

                End If

                e.Effect = DragDropEffects.None
                e.InfoMessage = "You can only drop files to send to contacts."

                'Dim strFormats() As String = dataobj.GetFormats(True)
                'For Each strfmt As String In strFormats
                '    MsgBox(strfmt)
                'Next

                Exit Sub
            End If


            If CType(e.DropTargetItem.RowObject, AddressBookEntry).ReceiveOnly Then
                e.Effect = DragDropEffects.None
                e.InfoMessage = "This contact is receive-only."
            Else
                e.Effect = DragDropEffects.Copy
            End If
        Catch ex As Exception
            Log(ex) '-- just log and continue, user can contact support
        End Try
    End Sub

    Private Sub olvContacts_ModelCanDrop(sender As Object, e As BrightIdeasSoftware.ModelDropEventArgs) Handles olvContacts.ModelCanDrop
        Try
            e.Effect = DragDropEffects.Copy
            e.Handled = True '-- stop CanDrop from firing...but ModelCanDrop seems to only fire after drop, not during drag

            'Dim entry As AddressBookEntry = CType(e.TargetModel, AddressBookEntry)
            'If entry Is Nothing Then
            'ElseIf entry.ReceiveOnly Then
            '    e.Effect = DragDropEffects.None
            '    e.InfoMessage = "Cannot forward to someone who is 'receive only'"
            'Else
            '    e.Effect = DragDropEffects.Copy
            'End If
        Catch ex As Exception
            Log(ex) '-- just log and continue, user can contact support
            e.Effect = DragDropEffects.None
        End Try
    End Sub

    Private Sub olvContacts_ModelDropped(sender As Object, e As BrightIdeasSoftware.ModelDropEventArgs) Handles olvContacts.ModelDropped
        Try
            '-- This is designed to accept drops from msglist so we can forward  msgs to another contact
            e.Handled = True '-- no matter what, do not call the other drop routine

            If TypeOf (e.SourceModels(0)) Is TrulyMailMessage Then
                For Each tmm As TrulyMailMessage In e.SourceModels
                    Dim lst As New List(Of AddressBookEntry)
                    lst.Add(CType(e.DropTargetItem.RowObject, AddressBookEntry))
                    If UseFallbackModeNow() Then
                        Dim frm As New NewMessageSimple(tmm.Filename, MessageResponseType.Forward)
                        frm.AddRecipientList(lst, RecipientType.Send_To)
                        frm.Show()
                    Else
                        Dim frm As New NewMessage(tmm.Filename, MessageResponseType.Forward)
                        frm.AddRecipientList(lst, RecipientType.Send_To)
                        frm.Show()
                    End If
                Next
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was a problem creating a new message." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub
End Class
