Public Class AddressBookForm

    Private m_restoreStatus As RestoreStatus
    Private m_intTotalContacts As Integer
    Private m_boolImageUserHidden As Boolean
    Private m_bytContactListStateOriginal() As Byte

    Private Enum RestoreStatus
        None
        TrulyMailOnly
        BackupAndTrulyMail
    End Enum
    Private Enum ExportFormat
        TAB
        CSV
    End Enum
    Private Sub SetToolStripIcons(ByVal toLarge As Boolean)
        If toLarge Then
            '-- Switching from normal, small icons to large icons
            Me.ToolStrip1.ImageScalingSize = New Size(32, 32)
            Me.ToolStrip1.Height = TOOLBAR_32_HEIGHT

            NewEmailToolStripButton.Image = My.Resources.email_32
            InviteTrulyMailContactToolStripButton.Image = My.Resources.AddUser_32
            ComposeMessageToSelectedContactsToolStripButton.Image = My.Resources.Editpencil_32
            DeleteToolStripButton.Image = My.Resources.Erase_32
        Else
            '-- Switching from large icons to small, normal icons
            Me.ToolStrip1.ImageScalingSize = New Size(16, 16)
            Me.ToolStrip1.Height = TOOLBAR_16_HEIGHT

            NewEmailToolStripButton.Image = My.Resources.email_16
            InviteTrulyMailContactToolStripButton.Image = My.Resources.AddUser_16
            ComposeMessageToSelectedContactsToolStripButton.Image = My.Resources.Editpencil_16
            DeleteToolStripButton.Image = My.Resources.Erase_16
        End If

        SetupToolStripForText(ToolStrip1)

    End Sub
    Private Sub AboutTrulyMailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutTrulyMailToolStripMenuItem.Click
        Using frm As New AboutBoxK()
            frm.ShowDialog()
        End Using
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub
    Private Sub SetStatus(ByVal newStatus As String)
        If InvokeRequired Then
            Dim deleg As New SetStatusCallback(AddressOf SetStatus)
            Invoke(deleg, newStatus)
        Else
            StatusToolStripStatusLabel.Text = newStatus
            Application.DoEvents()
        End If
    End Sub
#Region " Loading and showing OLV "
    Private Function NoTextAspectToStringConverter(ByVal s As String) As String
        Return String.Empty
    End Function

    Private Sub LoadAddressBookEntries()
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf LoadAddressBookEntries)
            Invoke(deleg)
        Else
            olvAddressBook.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf MainRowFormatter)
            'IconColumn.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf ImageGetter)
            ''IconColumn.Renderer = New HideTextRenderer()
            'IconColumn.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf NoTextAspectToStringConverter)
            IconColumn.AspectGetter = New BrightIdeasSoftware.AspectGetterDelegate(AddressOf GetContactTypeIconName)
            IconColumn.Renderer = New BrightIdeasSoftware.MappedImageRenderer("TrulyMail", My.Resources.Securedmessage_16, "Email", My.Resources.email_16)

            '-- format dates
            LastMessageReceivedColumn.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf FormatDateForOLV)
            LastMessageSentColumn.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf FormatDateForOLV)
            DateAddedColumn.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf FormatDateForOLV)

            Dim lst As New List(Of AddressBookEntry)
            Dim lstAllContacts As List(Of AddressBookEntry) = ABook.GetAllContacts
            Dim boolAddThisEntry As Boolean

            m_intTotalContacts = 0
            For i As Integer = 0 To lstAllContacts.Count - 1
                m_intTotalContacts += 1
                boolAddThisEntry = True

                Select Case TabControl1.SelectedIndex
                    Case 0 '-- unblocked
                        If lstAllContacts(i).Blocked Then
                            boolAddThisEntry = False
                        End If
                    Case 1 '-- blocked
                        If Not lstAllContacts(i).Blocked Then
                            boolAddThisEntry = False
                        End If
                End Select

                If boolAddThisEntry Then
                    lst.Add(lstAllContacts(i))
                End If
            Next

            lst.Sort(AddressOf CompareAddressBookEntries)
            olvAddressBook.SetObjects(lst)

            AutoSizeColumns(olvAddressBook)

            UpdateContactCount()
        End If
    End Sub
    Private Function GetContactTypeIconName(row As Object) As String
        Dim entry As AddressBookEntry = CType(row, AddressBookEntry)
        Return entry.ContactType.ToString()
    End Function
    Private Sub UpdateContactCount()
        If txtFilter.Text.Length = 0 Then
            ContactCountStatusLabel.Text = "Total: " & m_intTotalContacts.ToString("#,##0")
        Else
            ContactCountStatusLabel.Text = "Filtered: " & olvAddressBook.GetItemCount.ToString("#,##0") & "    Total: " & m_intTotalContacts.ToString("#,##0")
        End If
    End Sub
    Private Function MainRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim entry As AddressBookEntry = CType(olvi.RowObject, AddressBookEntry)
        Dim intPosition As Integer = Me.olvAddressBook.Columns.IndexOf(Me.SendReturnReceiptColumn)
        If entry.AutoSendReadReceipt = ContactReceiptOption.UseDefault Then
            If intPosition >= 0 Then
                olvi.SubItems(intPosition).Text = "Use account settings"
            End If
        End If

        'intPosition = Me.olvAddressBook.Columns.IndexOf(Me.EmailEncryptionColumn)
        'If entry.EncryptMessages = EncryptMessagesOption.UseMessage Then
        '    If intPosition >= 0 Then
        '        olvi.SubItems(intPosition).Text = "Use message settings"
        '    End If
        'End If
    End Function
    Private Function ImageGetter(ByVal row As Object) As Object
        Dim entry As AddressBookEntry = CType(row, AddressBookEntry)
        Select Case entry.ContactType
            Case AddressBookEntryType.TrulyMail
                Return 0
            Case AddressBookEntryType.Email
                Return 1
        End Select
    End Function
#End Region

    Private Sub AddressBookForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.WindowState <> FormWindowState.Minimized Then
            AppSettings.AddressBookWindowState = Me.WindowState
        End If

        '-- See if there are any new contacts (like email contacts) to add
        Try
            '-- could be list of arraylist (not sure why) so just make it late-bound
            Dim lst = olvAddressBook.Objects
            For Each contact As AddressBookEntry In lst
                If ABook.GetContactByID(contact.ID) Is Nothing Then
                    '-- need to add
                    ABook.Add(contact)
                End If
            Next
            ABook.Save() '-- save all changes only when the form is closed
        Catch ex As Exception
            '-- log error and ignore
            Log(ex)
        End Try

        AppSettings.AddressBookListState = olvAddressBook.SaveState()
    End Sub
    Private Sub AddressBookForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not AddressBookExists() Then
            Application.DoEvents() '-- create??
        Else
            LoadAddressBookEntries()
        End If

        SetToolStripIcons(AppSettings.LargeToolbarIcons)

        If AppSettings.AddressBookWindowState <> FormWindowState.Minimized Then
            Me.WindowState = AppSettings.AddressBookWindowState
        End If

        m_bytContactListStateOriginal = olvAddressBook.SaveState()
        olvAddressBook.RestoreState(AppSettings.AddressBookListState)

        txtFilter.Focus()
        LoadMessageTags()

        For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
            Dim mi As ToolStripMenuItem = ChangeSendingAccountForSelectedContactsToolStripMenuItem.DropDownItems.Add("To " & smtp.ToString())
            mi.Tag = smtp
            AddHandler mi.Click, AddressOf ChangeSendingAccountForSelectedContacts_Click
        Next

    End Sub

    Private Sub ChangeSendingAccountForSelectedContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        For Each obj As AddressBookEntry In olvAddressBook.SelectedObjects
            If obj.ContactType = AddressBookEntryType.Email Then
                obj.SMTPProfile = CType(mi.Tag, SMTPProfile)
                olvAddressBook.RefreshObject(obj)
                Application.DoEvents()
            End If
        Next
    End Sub

#Region " Adding contacts logic "
    Private Sub NewEmailContactToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewEmailContactToolStripMenuItem.Click
        AddEmailContact()
    End Sub
    Private Sub AddEmailContact()
        Dim entry As New AddressBookEntry(AddressBookEntryType.Email)

        entry.ID = Guid.NewGuid.ToString()
        Const NEW_EMAIL_CONTACT_NAME As String = "A New Email Contact"
        entry.FullName = NEW_EMAIL_CONTACT_NAME

        Dim frm As New EditContactK()
        frm.ShowDialog()

        TabControl1.SelectedIndex = 0
        LoadAddressBookEntries()
        'olvAddressBook.AddObject(entry)

        '-- clear filter so we can see newly added contact
        'txtFilter.Text = NEW_EMAIL_CONTACT_NAME

        '-- edit name of new contact
        olvAddressBook.EditSubItem(olvAddressBook.GetItem(0), 1)
    End Sub

    Private Sub NewEmailToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewEmailToolStripButton.Click
        AddEmailContact()
    End Sub

#End Region

#Region " Cell editing logic "

    Private Sub olvAddressBook_CellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles olvAddressBook.CellEditFinishing
        '-- we cancel here because we updated everything in the validating event (below)
        e.Cancel = True
        olvAddressBook.RefreshSelectedObjects()
    End Sub
    Private Sub olvAddressBook_CellEditStarting(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles olvAddressBook.CellEditStarting
        Select Case CType(e.RowObject, AddressBookEntry).ContactType
            Case AddressBookEntryType.TrulyMail
                Select Case e.Column.AspectName
                    Case AddressColumn.AspectName
                        e.Cancel = True '-- TrulyMail contacts never have addresses
                    Case ReceiveOnlyColumn.AspectName
                        e.Cancel = True '-- For TrulyMail contacts, receiveonly is determined by the server
                    Case DateAddedColumn.AspectName
                        e.Cancel = True '-- date added can never be changed
                    Case RequestReturnReceiptColumn.AspectName
                        e.Cancel = True
                    Case SendReturnReceiptColumn.AspectName
                        e.Cancel = True
                    Case RemoteImagesColumn.AspectName
                        Dim chk As New CheckBox()
                        chk.Checked = Convert.ToBoolean(e.Value)
                        chk.Bounds = e.CellBounds
                        chk.CheckAlign = ContentAlignment.MiddleCenter
                        e.Control = chk
                        'Case EmailEncryptionColumn.AspectName
                        '    e.Cancel = True
                    Case LastMessageReceivedColumn.AspectName, LastMessageSentColumn.AspectName
                        Dim ndtp As New NullableDateTimePicker()
                        ndtp.Format = DateTimePickerFormat.Short
                        ndtp.Value = e.Value
                        ndtp.Bounds = e.CellBounds
                        e.Control = ndtp
                    Case SMTPColumn.AspectName
                        e.Cancel = True
                End Select
            Case AddressBookEntryType.Email
                Select Case e.Column.AspectName
                    Case DateAddedColumn.AspectName
                        e.Cancel = True '-- date added can never be changed
                    Case SendReturnReceiptColumn.AspectName
                        Dim cbo As New ComboBox()
                        cbo.Items.Add("Use account settings")
                        cbo.Items.Add("Always")
                        cbo.Items.Add("Never")
                        cbo.DropDownStyle = ComboBoxStyle.DropDownList
                        cbo.SelectedIndex = CType(e.Value, Integer)
                        cbo.Bounds = e.CellBounds
                        e.Control = cbo
                    Case RemoteImagesColumn.AspectName
                        Dim chk As New CheckBox()
                        chk.Checked = Convert.ToBoolean(e.Value)
                        chk.Bounds = e.CellBounds
                        chk.CheckAlign = ContentAlignment.MiddleCenter
                        e.Control = chk
                    Case ReceiveOnlyColumn.AspectName
                        Dim chk As New CheckBox()
                        chk.Checked = Convert.ToBoolean(e.Value)
                        chk.Bounds = e.CellBounds
                        chk.CheckAlign = ContentAlignment.MiddleCenter
                        e.Control = chk
                    Case RequestReturnReceiptColumn.AspectName
                        Dim chk As New CheckBox()
                        chk.Checked = Convert.ToBoolean(e.Value)
                        chk.Bounds = e.CellBounds
                        chk.CheckAlign = ContentAlignment.MiddleCenter
                        e.Control = chk
                        'Case EmailEncryptionColumn.AspectName
                        '    Dim cbo As New ComboBox()
                        '    cbo.Items.Add("Use message settings")
                        '    cbo.Items.Add("Always")
                        '    cbo.Items.Add("Never")
                        '    cbo.DropDownStyle = ComboBoxStyle.DropDownList
                        '    cbo.SelectedIndex = CType(e.Value, Integer)
                        '    cbo.Bounds = e.CellBounds
                        '    e.Control = cbo
                    Case LastMessageReceivedColumn.AspectName, LastMessageSentColumn.AspectName
                        Dim ndtp As New NullableDateTimePicker()
                        ndtp.Format = DateTimePickerFormat.Short
                        ndtp.Value = e.Value
                        ndtp.Bounds = e.CellBounds
                        e.Control = ndtp
                    Case SMTPColumn.AspectName
                        Dim cbo As New ComboBox()
                        cbo.Items.Add("<use default email account>")
                        For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
                            cbo.Items.Add(smtp)
                        Next
                        If e.Value IsNot Nothing Then
                            cbo.SelectedItem = e.Value
                        Else
                            cbo.SelectedIndex = 0 '-- use default email account
                        End If
                        cbo.DropDownStyle = ComboBoxStyle.DropDownList
                        cbo.Bounds = e.CellBounds
                        e.Control = cbo
                End Select
        End Select
    End Sub

    Private Sub olvAddressBook_CellEditValidating(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles olvAddressBook.CellEditValidating
        '-- Fired unless editing was canceled (e.cancel or escape was pressed)
        Select Case CType(e.RowObject, AddressBookEntry).ContactType
            Case AddressBookEntryType.TrulyMail
                Select Case e.Column.AspectName
                    Case NameColumn.AspectName
                        If e.Control.Text.Trim.Length = 0 Then
                            ShowMessageBoxError("Every contact needs a name. Please give this contact a name.")
                            e.Cancel = True
                        End If
                End Select
            Case AddressBookEntryType.Email
                Select Case e.Column.AspectName
                    Case NameColumn.AspectName
                        If e.Control.Text.Trim.Length = 0 Then
                            ShowMessageBoxError("Every contact needs a name. Please give this contact a name.")
                            e.Cancel = True
                        End If
                    Case AddressColumn.AspectName
                        '-- validate the address as a valid email address or tell the user
                        Dim strEmailAddressEntered As String = e.Control.Text
                        If Not IsValidEmailAddress(strEmailAddressEntered) Then
                            ShowMessageBoxError("'" & strEmailAddressEntered & "' is not a valid email address. Please use the format user@domain.com.")

                            '-- change text back to what it was before
                            e.Cancel = True
                        End If
                End Select
        End Select

        '-- If we didn't cancel then update the addressbook file
        If Not e.Cancel Then
            '-- here we will write the changes back to the addressbook (saving on close)
            Dim entry As AddressBookEntry = CType(e.RowObject, AddressBookEntry)

            Select Case e.Column.AspectName
                Case NameColumn.AspectName
                    entry.FullName = e.Control.Text
                Case AddressColumn.AspectName
                    entry.Address = e.Control.Text
                Case RemoteImagesColumn.AspectName
                    If e.Control.GetType().Name = "CheckBox" Then
                        Dim chk As CheckBox = CType(e.Control, CheckBox)
                        entry.RemoteImages = Convert.ToBoolean(chk.Checked)
                    Else
                        entry.RemoteImages = Convert.ToBoolean(e.Control.Text)
                    End If
                Case ReceiveOnlyColumn.AspectName
                    If e.Control.GetType().Name = "CheckBox" Then
                        Dim chk As CheckBox = CType(e.Control, CheckBox)
                        entry.ReceiveOnly = Convert.ToBoolean(chk.Checked)
                    Else
                        entry.ReceiveOnly = Convert.ToBoolean(e.Control.Text)
                    End If
                Case SendReturnReceiptColumn.AspectName
                    Dim cbo As ComboBox = CType(e.Control, ComboBox)
                    entry.AutoSendReadReceipt = Convert.ToInt32(cbo.SelectedIndex)
                Case RequestReturnReceiptColumn.AspectName
                    If e.Control.GetType().Name = "CheckBox" Then
                        Dim chk As CheckBox = CType(e.Control, CheckBox)
                        entry.AutoRequestReadReceipt = Convert.ToBoolean(chk.Checked)
                    Else
                        entry.AutoRequestReadReceipt = Convert.ToBoolean(e.Control.Text)
                    End If
                Case TagsColumn.AspectName
                    entry.Tags = e.Control.Text
                Case LastMessageReceivedColumn.AspectName
                    If IsDate(e.Control.Text) Then
                        entry.LastMessageReceived = CType(e.Control.Text, Date)
                    Else
                        entry.LastMessageReceived = Nothing
                    End If
                Case LastMessageSentColumn.AspectName
                    If IsDate(e.Control.Text) Then
                        entry.LastMessageSent = CType(e.Control.Text, Date)
                    Else
                        entry.LastMessageSent = Nothing
                    End If
                Case RemindReceiveColumn.AspectName
                    entry.RemindReceiveEveryXDays = ConvertToInt32(e.Control.Text, 0)
                Case RemindSendColumn.AspectName
                    entry.RemindSendEveryXDays = ConvertToInt32(e.Control.Text, 0)
                Case ImportanceColumn.AspectName
                    entry.ImportanceRating = ConvertToInt32(e.Control.Text, 0)
                Case SMTPColumn.AspectName
                    If e.Control.GetType().Name = "ComboBox" Then
                        Dim cbo As ComboBox = CType(e.Control, ComboBox)
                        If cbo.SelectedIndex > 0 Then
                            entry.SMTPProfile = cbo.SelectedItem
                        Else
                            entry.SMTPID = String.Empty
                        End If
                    End If
            End Select

            entry.Active = True
        End If
    End Sub
#End Region


#Region " Compose message logic "
    Private Sub ComposeMessageToSelectedContactsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComposeMessageToSelectedContactsToolStripMenuItem.Click
        ComposeMessageToSelectedContacts()
    End Sub
    Private Sub ComposeMessageToSelectedContactsToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComposeMessageToSelectedContactsToolStripButton.Click
        ComposeMessageToSelectedContacts()
    End Sub
    Private Sub ComposeMessageToSelectedContacts()
        If olvAddressBook.SelectedObjects.Count > 0 Then
            CreateNewMessageToSelectedContacts()
        Else
            ShowMessageBoxError("No contacts are selected.")
        End If
    End Sub
    Private Sub CreateNewMessageToSelectedContacts()
        Dim lst As New ArrayList()
        Dim entries As ArrayList = olvAddressBook.SelectedObjects()

        For Each entry As AddressBookEntry In entries
            If entry.ReceiveOnly Then
                '-- Receive only = true
            Else
                lst.Add(entry)
            End If
        Next

        If lst.Count > 0 Then
            CreateNewMessageToContacts(lst)
        End If
    End Sub
    Private Sub CreateNewMessageToContacts(ByVal lst As ArrayList)
        Dim msg As New NewMessage(lst)
        msg.ShowDialog()
    End Sub
#End Region

#Region " Blocking and unblocking contacts "
#Region " Blocking contacts "
    Private Sub BlockSelectedContactsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlockSelectedContactsToolStripMenuItem.Click
        If olvAddressBook.SelectedItems.Count = 0 Then
            ShowMessageBox("There are no selected contacts to block.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            SendKeys.Send("{ESC}")

            Dim boolAtLeastOneTrulyMailEntry As Boolean = False
            Dim boolAtLeaseOneEmailEntry As Boolean = False
            Dim entries As ArrayList = olvAddressBook.SelectedObjects()
            For Each entry As AddressBookEntry In entries
                Select Case entry.ContactType
                    Case AddressBookEntryType.Email
                        boolAtLeaseOneEmailEntry = True
                    Case AddressBookEntryType.TrulyMail
                        boolAtLeastOneTrulyMailEntry = True
                End Select

                If boolAtLeaseOneEmailEntry AndAlso boolAtLeastOneTrulyMailEntry Then
                    Exit For
                End If
            Next

            BlockOnlyTrulyMailContacts(entries)
            BlockOnlyEmailContacts(entries)


        End If
        LoadAddressBookEntries()
    End Sub
    Private Sub BlockOnlyTrulyMailContacts(ByVal entries As ArrayList)
        For Each entry As AddressBookEntry In entries
            If entry.ContactType = AddressBookEntryType.TrulyMail Then
                If entry.ReceiveOnly Then
                    '-- relationship would be removed on the server, not blocked so just delete from address book
                    DeleteUserFromAddressBook(entry)
                Else
                    BlockUserInAddressBook(entry.ID)
                End If
            End If
        Next
    End Sub
    Private Sub BlockOnlyEmailContacts(ByVal entries As ArrayList)
        For Each entry As AddressBookEntry In entries
            If entry.ContactType = AddressBookEntryType.Email Then
                Try
                    '-- update contact to blocked status
                    BlockUserInAddressBook(entry.ID)
                Catch ex As Exception
                    Log(ex)
                    Throw New Exception(EXCEPTIONTEXT_UNEXPECTED_ERROR)
                End Try
            End If
        Next
    End Sub
#End Region
#Region " Unblocking contacts "
    Private Sub UnblockSelectedContactsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnblockSelectedContactsToolStripMenuItem.Click
        If olvAddressBook.SelectedItems.Count = 0 Then
            ShowMessageBox("There are no selected contacts to unblock.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            SendKeys.Send("{ESC}")

            Dim entries As ArrayList = olvAddressBook.SelectedObjects()

            UnBlockOnlyEmailContacts(entries)
            UnBlockOnlyTrulyMailContacts(entries)

        End If
        LoadAddressBookEntries()
    End Sub
    Private Sub UnBlockOnlyTrulyMailContacts(ByVal entries As ArrayList)
        For Each entry As AddressBookEntry In entries
            If entry.ContactType = AddressBookEntryType.TrulyMail Then
                UnBlockUserInAddressBook(entry.ID)
            End If
        Next
    End Sub
    Private Sub UnBlockOnlyEmailContacts(ByVal entries As ArrayList)
        For Each entry As AddressBookEntry In entries
            If entry.ContactType = AddressBookEntryType.Email Then
                Try
                    '-- update contact to unblocked status
                    UnBlockUserInAddressBook(entry.ID)
                Catch ex As Exception
                    Log(ex)
                    Throw New Exception(EXCEPTIONTEXT_UNEXPECTED_ERROR)
                End Try
            End If
        Next
    End Sub
#End Region
#End Region

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        LoadAddressBookEntries()
        Select Case TabControl1.SelectedIndex
            Case 0
                UnblockSelectedContactsToolStripMenuItem.Enabled = False
                BlockSelectedContactsToolStripMenuItem.Enabled = True
            Case 1
                UnblockSelectedContactsToolStripMenuItem.Enabled = True
                BlockSelectedContactsToolStripMenuItem.Enabled = False
        End Select
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        '-- only show contacts which match the filter
        olvAddressBook.ModelFilter = New BrightIdeasSoftware.TextMatchFilter(olvAddressBook, txtFilter.Text)
        If txtFilter.Text.Length > 0 Then
            txtFilter.BackColor = Color.Yellow
        Else
            txtFilter.BackColor = Color.White
        End If
        UpdateContactCount()
    End Sub

    Private Sub DeleteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripButton.Click
        DeleteSelectedContacts()
    End Sub

    Private Sub RemoveContactToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveContactToolStripMenuItem.Click
        DeleteSelectedContacts()
    End Sub
    Private Sub DeleteSelectedContacts()
        Dim lst As ArrayList = olvAddressBook.SelectedObjects
        Dim boolAtLeastOneEmail As Boolean
        Dim boolAtLeastOneTrulyMail As Boolean

        If lst.Count > 0 Then
            For Each entry As AddressBookEntry In lst
                Select Case entry.ContactType
                    Case AddressBookEntryType.Email
                        boolAtLeastOneEmail = True
                    Case AddressBookEntryType.TrulyMail
                        boolAtLeastOneTrulyMail = True
                End Select

                If boolAtLeastOneEmail AndAlso boolAtLeastOneTrulyMail Then
                    Exit For
                End If
            Next
        End If

        Dim strMessage As String = String.Empty

        If boolAtLeastOneTrulyMail Then
            strMessage = "Deleting TrulyMail contacts is the same as blocking them (which stops both of you from sending messages to each other)."
        End If

        If boolAtLeastOneEmail Then
            If strMessage.Length > 0 Then
                strMessage &= Environment.NewLine & Environment.NewLine
            End If
            strMessage &= "Deleting email contacts will stop you from emailing them but they can still email you."
        End If

        If strMessage.Length = 0 Then
            Exit Sub
        End If

        strMessage &= Environment.NewLine & Environment.NewLine & "Are you sure you want to do this?"


        If ShowMessageBox(strMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            '-- For email contacts, we just set active=false
            For Each entry As AddressBookEntry In lst
                DeleteUserFromAddressBook(entry)
            Next
            olvAddressBook.RemoveObjects(olvAddressBook.SelectedObjects)
        End If
    End Sub

    Private Sub olvAddressBook_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles olvAddressBook.KeyDown
        If e.KeyCode = Keys.Delete AndAlso Not olvAddressBook.IsCellEditing Then
            DeleteSelectedContacts()
        End If
    End Sub

    Private Sub ImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripMenuItem.Click
        Using frm As New ImportAddressBook()
            frm.ShowDialog(Me)
            LoadAddressBookEntries()
        End Using
    End Sub

    Private Sub ExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem.Click
        Dim sfd As New SaveFileDialog()
        sfd.Title = "Export address book to..."
        sfd.Filter = "Tab-delimited files (*.tab)|*.tab|Comma-delimited files (*.csv)|*.csv"
        sfd.OverwritePrompt = True
        If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Select Case sfd.FilterIndex
                Case 1 '-- TAB
                    ExportAddresses(ExportFormat.TAB, sfd.FileName)
                Case 2 '-- CSV
                    ExportAddresses(ExportFormat.CSV, sfd.FileName)
            End Select
        End If
    End Sub
    Private Sub ExportAddresses(ByVal format As ExportFormat, ByVal filename As String)
        If System.IO.File.Exists(filename) Then
            Try
                DeleteLocalFile(filename)
            Catch ex As Exception
                ShowMessageBoxError(filename & " cannot be overwritten.")
                Exit Sub
            End Try
        End If

        Using sw As System.IO.StreamWriter = System.IO.File.CreateText(filename)

            '-- write headers
            Select Case format
                Case ExportFormat.TAB
                    sw.Write("Name" & vbTab & "Address" & vbTab & "Remote Images" & vbTab & "Receive Only" & vbTab & "AutoRequestReceipt" & vbTab & "AutoSendReceipt" & vbTab & "Tags" & vbTab & "ImportanceRating" & vbTab & "RemindReceiveEveryXDays" & vbTab & "RemindSendEveryXDays" & vbTab & "Blocked" & vbTab & "PhoneHome" & vbTab & "PhoneWork" & vbTab & "PhoneMobile" & vbTab & "WebPage" & vbTab & "Custom1" & vbTab & "Custom2" & vbTab & "Custom3" & vbTab & "Custom4" & vbTab & "Notes" & vbTab & "WebMailQuestion" & vbTab & "WebMailPassword" & vbTab & "LastMessageReceived" & vbTab & "LastMessageSent" & vbTab & "Added" & Environment.NewLine)
                Case ExportFormat.CSV
                    sw.Write("""Name"",""Address"",""Remote Images"",""Receive Only"",""Auto-Request Receipt"",""Auto-Send Receipt"",""Tags"",""ImportanceRating"",""RemindReceiveEveryXDays"",""RemindSendEveryXDays"",""Blocked"",""PhoneHome"",""PhoneWork"",""PhoneMobile"",""WebPage"",""Custom1"",""Custom2"",""Custom3"",""Custom4"",""Notes"",""WebMailQuestion"",""WebMailPassword"",""LastMessageReceived"",""LastMessageSent"",""Added""" & Environment.NewLine)
            End Select

            '-- write contacts
            Dim lst As IEnumerable 'List(Of AddressBookEntry)

            If txtFilter.Text.Trim.Length = 0 Then
                lst = olvAddressBook.Objects
            Else
                lst = olvAddressBook.FilteredObjects
            End If
            Dim strLastMessageReceived, strLastMessageSent As String
            For Each entry As AddressBookEntry In lst
                '-- only export email entries
                If entry.ContactType = AddressBookEntryType.Email Then
                    If entry.LastMessageReceived.HasValue Then
                        strLastMessageReceived = entry.LastMessageReceived.Value.ToString(DATEFORMAT_XML_DATEONLY)
                    Else
                        strLastMessageReceived = String.Empty
                    End If

                    If entry.LastMessageSent.HasValue Then
                        strLastMessageSent = entry.LastMessageSent.Value.ToString(DATEFORMAT_XML_DATEONLY)
                    Else
                        strLastMessageSent = String.Empty
                    End If

                    Select Case format
                        Case ExportFormat.TAB
                            sw.Write(entry.FullName & vbTab & entry.Address & vbTab & entry.RemoteImages & vbTab & entry.ReceiveOnly & vbTab & entry.AutoRequestReadReceipt & vbTab & entry.AutoSendReadReceipt.ToString() & vbTab & entry.Tags & vbTab & entry.ImportanceRating.ToString() & vbTab & entry.RemindReceiveEveryXDays.ToString() & vbTab & entry.RemindSendEveryXDays.ToString() & vbTab & entry.Blocked & vbTab & entry.PhoneHome & vbTab & entry.PhoneWork & vbTab & entry.PhoneMobile & vbTab & entry.WebPage & vbTab & entry.Custom1 & vbTab & entry.Custom2 & vbTab & entry.Custom3 & vbTab & entry.Custom4 & vbTab & entry.Notes.Replace(vbLf, "<CR>") & vbTab & entry.WebMailQuestion & vbTab & entry.WebMailPassword & vbTab & strLastMessageReceived & vbTab & strLastMessageSent & vbTab & entry.Added.ToString() & Environment.NewLine)
                        Case ExportFormat.CSV
                            sw.Write("""" & entry.FullName & """,""" & entry.Address & """,""" & entry.RemoteImages & """,""" & entry.ReceiveOnly & """,""" & entry.AutoRequestReadReceipt & """,""" & entry.AutoSendReadReceipt.ToString() & """,""" & entry.Tags & """,""" & entry.ImportanceRating.ToString() & """,""" & entry.RemindReceiveEveryXDays.ToString() & """,""" & entry.RemindSendEveryXDays.ToString() & """,""" & entry.Blocked & """,""" & entry.PhoneHome & """,""" & entry.PhoneWork & """,""" & entry.PhoneMobile & """,""" & entry.WebPage & """,""" & entry.Custom1 & """,""" & entry.Custom2 & """,""" & entry.Custom3 & """,""" & entry.Custom4 & """,""" & entry.Notes.Replace(vbLf, "<CR>") & """,""" & entry.WebMailQuestion & """,""" & entry.WebMailPassword & """,""" & strLastMessageReceived & """,""" & strLastMessageSent & """,""" & entry.Added.ToString() & """" & Environment.NewLine)
                    End Select
                End If

            Next

            sw.Close()
        End Using
    End Sub

    Private Sub AddressBookForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub FileToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.DropDownOpening
        If txtFilter.Text.Length = 0 Then
            ExportToolStripMenuItem.Text = "&Export All Contacts"
        Else
            ExportToolStripMenuItem.Text = "&Export Filtered Contacts"
        End If
    End Sub

    Private Sub btnClearMessageFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearMessageFilter.Click
        txtFilter.Text = String.Empty
    End Sub

    Private Sub olvAddressBook_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvAddressBook.ItemActivate
        EditCurrentContact()
    End Sub
    Private Sub EditCurrentContact()
        If olvAddressBook.SelectedObjects.Count = 1 Then
            EditContactDetails(CType(olvAddressBook.SelectedObject, AddressBookEntry).ID)
            LoadAddressBookEntries()
        Else
            ShowMessageBoxError("You must select one contact before trying to edit.")
        End If
    End Sub

    Private Sub ContactToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactToolStripMenuItem.DropDownOpening
        EditselectedContactToolStripMenuItem.Enabled = (olvAddressBook.SelectedObjects.Count = 1)
    End Sub

    Private Sub EditselectedContactToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditselectedContactToolStripMenuItem.Click
        EditCurrentContact()
    End Sub

    Private Sub olvAddressBook_HotItemChanged(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.HotItemChangedEventArgs) Handles olvAddressBook.HotItemChanged
        If Not m_boolImageUserHidden Then
            Dim item As BrightIdeasSoftware.OLVListItem = olvAddressBook.GetItem(e.HotRowIndex)
            If item IsNot Nothing Then
                Dim entry As AddressBookEntry = CType(item.RowObject, AddressBookEntry)
                If entry.Picture IsNot Nothing Then
                    ContactPictureDisplay1.Image = entry.Picture
                    ContactPictureDisplay1.Show()
                Else
                    ContactPictureDisplay1.Image = Nothing
                    ContactPictureDisplay1.Hide()
                End If
            End If
        End If
    End Sub

    Private Sub ContactPictureDisplay1_UserHidden() Handles ContactPictureDisplay1.UserHidden
        m_boolImageUserHidden = True '-- do not show again
        ViewContactImageToolStripMenuItem.Checked = False
    End Sub

    Private Sub ViewContactImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewContactImageToolStripMenuItem.CheckedChanged
        m_boolImageUserHidden = Not ViewContactImageToolStripMenuItem.Checked
        ContactPictureDisplay1.Visible = ViewContactImageToolStripMenuItem.Checked
    End Sub

    Private Sub SelectColumnsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectColumnsToolStripMenuItem.Click
        olvAddressBook.MakeColumnSelectMenu(ctxmnuColumnSelector)
        ctxmnuColumnSelector.Show(olvAddressBook, 10, 10)
    End Sub

    Private Sub ResetColumnsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetColumnsToolStripMenuItem.Click
        olvAddressBook.RestoreState(m_bytContactListStateOriginal)
        AutoSizeColumns(olvAddressBook)
    End Sub

    Private Sub ctxmnuColumnSelector_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxmnuColumnSelector.Opening
        For Each mi As ToolStripItem In ctxmnuColumnSelector.Items
            '-- re-title the menu items
            mi.Text = mi.Text.Replace("'+'", "'Transport System'")
            mi.Text = mi.Text.Replace("'['", "'Importance'")
            Select Case mi.Text
                Case "+"
                    mi.Text = "Transport System"
                Case "["
                    mi.Text = "Importance"
            End Select
        Next
    End Sub

    Private Sub ctxmnuColumnSelector_Closed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles ctxmnuColumnSelector.Closed
        ctxmnuColumnSelector.Items.Clear()
    End Sub

    Private Sub olvAddressBook_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvAddressBook.MouseLeave
        ContactPictureDisplay1.Image = Nothing
        ContactPictureDisplay1.Hide()
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
    Private Sub AddTag()
        '-- Add selected tag to selected messages, unless the tag already exists
        If cboMessageTags.SelectedIndex >= 0 Then
            Dim strNewTagText As String = CType(cboMessageTags.Items(cboMessageTags.SelectedIndex), MessageTag).Text

            Dim list As ArrayList = olvAddressBook.SelectedObjects
            For Each entry As AddressBookEntry In list
                If entry.Tags Is Nothing Then
                    entry.Tags = String.Empty
                End If
                If Not entry.Tags.Contains(strNewTagText) Then
                    If entry.Tags.Trim.Length = 0 Then
                        entry.Tags = strNewTagText
                    Else
                        entry.Tags &= " " & strNewTagText
                    End If
                End If
                'entry.Save() '-- persist tag change
                olvAddressBook.RefreshObject(entry)
            Next
            ABook.Save()
            olvAddressBook.RefreshSelectedObjects()
        End If
    End Sub
    Private Sub ClearTags()
        '-- Add selected tag to selected messages, unless the tag already exists
        If cboMessageTags.SelectedIndex >= 0 Then
            Dim list As ArrayList = olvAddressBook.SelectedObjects
            For Each entry As AddressBookEntry In list
                entry.Tags = String.Empty
                'entry.Save() '-- persist tag change
            Next
            ABook.Save()
            olvAddressBook.RefreshSelectedObjects()
        End If
    End Sub
    Private Sub pbAddTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAddTag.Click
        AddTag()
    End Sub

    Private Sub pbClearTags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbClearTags.Click
        ClearTags()
    End Sub

End Class