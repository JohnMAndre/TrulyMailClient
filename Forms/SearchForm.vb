Public Class SearchForm

    Private Const BLOCKED As String = " ( blocked )"
    Private Const RECEIVE_ONLY As String = " ( receive only )"
    Private Const INACTIVE As String = " ( deleted )"

    Private Class MessageTypeItem
        Public DisplayName As String
        Public ID As String
    End Class
   
    Friend Class TrulyMailAttachmentSearchResult
        Public Subject As String
        Public Attachments As Integer
        Public Recipients As String
        Public Sender As String
        Public MessageDateSent As Date
        Public MessageDateToSend As Date
        Public LastSaveDate As Date
        Public MessageDateUnsent As Date
        Public MessageSize As Integer
        Public Read As Boolean
        Public Sent As Boolean '-- true if we sent the message, false if we received the message
        Public Filename As String
        Public MessageType As MessageType
        Public AttachmentFilename As String
        Public AttachmentFullPath As String
        Public AttachmentFileSize As Integer
        Public Tags As String
    End Class

    Private m_lstMessageMessageTypes As List(Of MessageTypeItem)
    Private m_lstAttachmentMessageTypes As List(Of MessageTypeItem)
    Private m_lstAddressBook As List(Of AddressBookEntry)
    Private m_strTopSearchFolder As String = MessageStoreRootPath
    Private m_boolCancelSearch As Boolean


    Private Sub cboSearchType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchType.SelectedIndexChanged
        Select Case cboSearchType.SelectedIndex
            Case 0
                LoadMessageParameters()
            Case 1
                LoadAttachmentParameters()
        End Select
    End Sub
    Private Sub LoadMessageParameters()
        grpMessages.Show()
        grpAttachments.Hide()
        txtMessageTags.Text = String.Empty
        cboMessageRead.SelectedIndex = 0
        cboMessageAttachments.SelectedIndex = 0
        cboMessageSubject.SelectedIndex = 0
        txtMessageSubject.Hide()
        txtMessageSubject.Text = String.Empty
        cboMessageBody.SelectedIndex = 0
        txtMessageBody.Hide()
        txtMessageBody.Text = String.Empty
        cboMessageFrom.SelectedIndex = 0
        cboMessageTo.SelectedIndex = 0
        cboMessageCC.SelectedIndex = 0
        cboMessageBCC.SelectedIndex = 0
        cboMessageSize.SelectedIndex = 0
        txtMessageSize.Text = "0"
        dtpMessageSentAfter.Value = dtpMessageSentAfter.MinDate
        dtpMessageSentBefore.Value = dtpMessageSentBefore.MaxDate
        chkMessageSubfolders.Checked = True
    End Sub
    Private Sub LoadAttachmentParameters()
        grpMessages.Hide()
        grpAttachments.Show()
        txtAttachmentMessageTag.Text = String.Empty
        cboAttachmentRead.SelectedIndex = 0
        cboAttachmentSubject.SelectedIndex = 0
        txtAttachmentSubject.Hide()
        txtAttachmentSubject.Text = String.Empty
        cboAttachmentBody.SelectedIndex = 0
        txtAttachmentBody.Hide()
        txtAttachmentBody.Text = String.Empty
        cboAttachmentFrom.SelectedIndex = 0
        cboAttachmentTo.SelectedIndex = 0
        cboAttachmentCC.SelectedIndex = 0
        cboAttachmentBCC.SelectedIndex = 0
        cboAttachmentAttachmentSize.SelectedIndex = 0
        cboAttachmentMessageSize.SelectedIndex = 0
        dtpAttachmentAfter.Value = dtpAttachmentAfter.MinDate
        dtpAttachmentBefore.Value = dtpAttachmentBefore.MaxDate
        chkAttachmentSubfolders.Checked = True
        cboAttachmentName.SelectedIndex = 0
        txtAttachmentName.Hide()
        txtAttachmentName.Text = String.Empty
    End Sub
    Private Sub cboMessageSubject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMessageSubject.SelectedIndexChanged
        txtMessageSubject.Visible = cboMessageSubject.SelectedIndex
    End Sub
    Private Sub cboMessageBody_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMessageBody.SelectedIndexChanged
        txtMessageBody.Visible = cboMessageBody.SelectedIndex > 0
    End Sub

    Private Sub SearchForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.WindowState <> FormWindowState.Minimized Then
            AppSettings.SearchFormWindowState = Me.WindowState
        End If
    End Sub

    Private Sub SearchForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateMessageTypes()
        PopulateFromAddressBook()

        SetMessageFolderPathLabel(m_strTopSearchFolder)
        SetAttachmentFolderPathLabel(m_strTopSearchFolder)

        cboSearchType.SelectedIndex = 0

        If AppSettings.SearchFormWindowState <> FormWindowState.Minimized Then
            Me.WindowState = AppSettings.SearchFormWindowState
        End If

        LoadMessageTags()
    End Sub
    Private Sub PopulateMessageTypes()
        m_lstMessageMessageTypes = New List(Of MessageTypeItem)
        m_lstAttachmentMessageTypes = New List(Of MessageTypeItem)
        Dim item As MessageTypeItem

        item = New MessageTypeItem
        item.DisplayName = "Message"
        item.ID = MESSAGETYPE_DRAFT_COMMUNICATION
        m_lstMessageMessageTypes.Add(item)
        m_lstAttachmentMessageTypes.Add(item)

        item = New MessageTypeItem
        item.DisplayName = "Draft"
        item.ID = MESSAGETYPE_DRAFT_COMMUNICATION
        m_lstMessageMessageTypes.Add(item)
        m_lstAttachmentMessageTypes.Add(item)

        lvMessageTypes.SetObjects(m_lstMessageMessageTypes)
        lvAttachmentMessageType.SetObjects(m_lstAttachmentMessageTypes)

        '-- check all
        lvMessageTypes.CheckObject(m_lstMessageMessageTypes.Item(0))
        lvMessageTypes.CheckObject(m_lstMessageMessageTypes.Item(1))

        lvAttachmentMessageType.SetObjects(m_lstAttachmentMessageTypes)

        '-- check all
        lvAttachmentMessageType.CheckObject(m_lstAttachmentMessageTypes.Item(0))
        lvAttachmentMessageType.CheckObject(m_lstAttachmentMessageTypes.Item(1))

    End Sub
    Private Sub PopulateFromAddressBook()
        m_lstAddressBook = New List(Of AddressBookEntry)
        Dim item As AddressBookEntry
        Dim strSuffix As String

        Dim lstMasterAddressBook As List(Of AddressBookEntry) = ABook.GetAllContacts()
        For i As Integer = 0 To lstMasterAddressBook.Count - 1
            strSuffix = String.Empty
            item = New AddressBookEntry(lstMasterAddressBook(i).ContactType)
            If item.ContactType = AddressBookEntryType.Email Then
                item.Address = lstMasterAddressBook(i).Address
            End If
            item.ID = lstMasterAddressBook(i).ID


            If Not item.Active Then
                strSuffix &= INACTIVE
            End If

            If item.Blocked Then
                strSuffix &= BLOCKED
            End If

            If item.ReceiveOnly Then
                strSuffix &= RECEIVE_ONLY
            End If

            item.FullName = lstMasterAddressBook(i).FullName & strSuffix

            m_lstAddressBook.Add(item)
        Next

        m_lstAddressBook.Sort()

        For Each item In m_lstAddressBook
            Dim strName As String = item.FullName

            cboMessageFrom.Items.Add(strName)
            cboMessageTo.Items.Add(strName)
            cboMessageCC.Items.Add(strName)
            cboMessageBCC.Items.Add(strName)

            cboAttachmentFrom.Items.Add(strName)
            cboAttachmentTo.Items.Add(strName)
            cboAttachmentCC.Items.Add(strName)
            cboAttachmentBCC.Items.Add(strName)
        Next

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        m_boolCancelSearch = False

        Select Case cboSearchType.SelectedIndex
            Case -1
                ShowMessageBoxError("Please choose a search type first searching.")
            Case 0
                SearchForMessages()
            Case 1
                SearchForAttachments()
        End Select
    End Sub
    Private Function AspectToStringConverterDate(ByVal d As Date) As String
        If d.Date = Date.Today Then
            Return d.ToShortTimeString
        Else
            Return d.ToShortDateString & " " & d.ToShortTimeString
        End If
    End Function
    Private Function NoTextAspectToStringConverter(ByVal s As String) As String
        Return String.Empty
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
    Private Function MainRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim msg As TrulyMailMessage = CType(olvi.RowObject, TrulyMailMessage)


        Dim LAST_SAVE_DATE_COLOR As Color = Color.Salmon
        Dim TO_SEND_DATE_COLOR As Color = Color.Blue
        Dim UNSENT_DATE_COLOR As Color = Color.Red


        Dim intPositionReceived As Integer = Me.olvMessages.Columns.IndexOf(Me.OlvColumnReceived)
        Dim intPositionViewed As Integer = Me.olvMessages.Columns.IndexOf(Me.OlvColumnViewed)
        Dim intPositionAttachments As Integer = Me.olvMessages.Columns.IndexOf(Me.OlvColumnAttachments)


        '-- unread messages should be bold
        If msg IsNot Nothing AndAlso msg.Read = False Then
            olvi.Font = New Font(olvi.Font, FontStyle.Bold)
            For intCounter As Integer = 0 To olvi.SubItems.Count - 1
                olvi.SubItems(intCounter).Font = olvi.Font
            Next
        End If

        If msg IsNot Nothing Then
            If msg.Attachments.Count = 0 Then
                If intPositionAttachments >= 1 Then
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
                    Dim intPositionDate As Integer = Me.olvMessages.Columns.IndexOf(Me.OlvColumnMessageDateSent)
                    If msg.MessageDateToSend = Date.MinValue Then
                        If msg.LastSaveDate > Date.MinValue Then
                            olvi.SubItems(intPositionDate).Text = AspectToStringConverterDate(msg.LastSaveDate).ToString()
                            olvi.SubItems(intPositionDate).ForeColor = LAST_SAVE_DATE_COLOR
                        Else
                            olvi.SubItems(intPositionDate).Text = String.Empty
                        End If
                    Else
                        olvi.SubItems(intPositionDate).Text = AspectToStringConverterDate(msg.MessageDateToSend).ToString()
                        olvi.SubItems(intPositionDate).ForeColor = TO_SEND_DATE_COLOR
                    End If
                ElseIf msg.MessageDateUnsent > Date.MinValue Then
                    Dim intPositionDate As Integer = Me.olvMessages.Columns.IndexOf(Me.OlvColumnMessageDateSent)
                    olvi.SubItems(intPositionDate).ForeColor = UNSENT_DATE_COLOR
                End If

                If intPositionReceived >= 0 AndAlso intPositionViewed >= 0 Then
                    '-- format received column
                    Select Case msg.Received
                        Case 0
                            olvi.SubItems(intPositionReceived).BackColor = Color.Pink
                        Case 1
                            olvi.SubItems(intPositionReceived).BackColor = Color.LightGreen
                        Case Else
                            olvi.SubItems(intPositionReceived).BackColor = Color.LightBlue
                    End Select

                    '-- format viewed column
                    Select Case msg.Viewed
                        Case 0
                            olvi.SubItems(intPositionViewed).BackColor = Color.Pink
                        Case 1
                            olvi.SubItems(intPositionViewed).BackColor = Color.LightGreen
                        Case Else
                            olvi.SubItems(intPositionViewed).BackColor = Color.LightBlue
                    End Select
                End If
            Else
                '-- message received
                If intPositionReceived > -1 Then
                    olvi.SubItems(intPositionReceived).Text = String.Empty
                End If

                If intPositionViewed > -1 Then
                    olvi.SubItems(intPositionViewed).Text = String.Empty
                End If
            End If
        ElseIf msg IsNot Nothing Then '-- not sent but received
            olvi.SubItems(intPositionReceived).Text = String.Empty
            olvi.SubItems(intPositionViewed).Text = String.Empty
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
    Private Function AttachmentRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim msg As TrulyMailAttachmentSearchResult = CType(olvi.RowObject, TrulyMailAttachmentSearchResult)

        Dim LAST_SAVE_DATE_COLOR As Color = Color.Salmon
        Dim TO_SEND_DATE_COLOR As Color = Color.Blue
        Dim UNSENT_DATE_COLOR As Color = Color.Red

        '-- unread messages should be bold
        If msg IsNot Nothing AndAlso msg.Read = False Then
            olvi.Font = New Font(olvi.Font, FontStyle.Bold)
            For intCounter As Integer = 0 To olvi.SubItems.Count - 1
                olvi.SubItems(intCounter).Font = olvi.Font
            Next
        End If

        If msg IsNot Nothing Then
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
                    Dim intPositionDate As Integer = Me.olvAttachments.Columns.IndexOf(Me.olvColumnAttachmentDate)
                    If msg.MessageDateToSend = Date.MinValue Then
                        If msg.LastSaveDate > Date.MinValue Then
                            olvi.SubItems(intPositionDate).Text = AspectToStringConverterDate(msg.LastSaveDate).ToString()
                            olvi.SubItems(intPositionDate).ForeColor = LAST_SAVE_DATE_COLOR
                        Else
                            olvi.SubItems(intPositionDate).Text = String.Empty
                        End If
                    Else
                        olvi.SubItems(intPositionDate).Text = AspectToStringConverterDate(msg.MessageDateToSend).ToString()
                        olvi.SubItems(intPositionDate).ForeColor = TO_SEND_DATE_COLOR
                    End If
                ElseIf msg.MessageDateUnsent > Date.MinValue Then
                    Dim intPositionDate As Integer = Me.olvAttachments.Columns.IndexOf(Me.olvColumnAttachmentDate)
                    olvi.SubItems(intPositionDate).ForeColor = UNSENT_DATE_COLOR
                End If
            End If
        End If
    End Function
    Private Function AttachmentImageGetter(ByVal row As Object) As Object
        Try
            Dim item As TrulyMailAttachmentSearchResult = row
            Dim strExtension As String = System.IO.Path.GetExtension(item.AttachmentFilename).ToLower()
            If Not olvAttachments.SmallImageList.Images.ContainsKey(strExtension) Then
                Dim icon As Icon = AssociatedIcon.GetAssociatedIconSmall(item.AttachmentFullPath)
                olvAttachments.SmallImageList.Images.Add(strExtension, icon)
            End If
            Return strExtension
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Sub SearchForMessages()
        btnSearch.Enabled = False

        m_strTopSearchFolder = ToolTip1.GetToolTip(llblChangeMessageFolder)

        Me.lblSearchProgress.Visible = True
        Me.prgSearchProgress.Visible = True
        btnCancel.Visible = True
        prgSearchProgress.Value = 0
        Application.DoEvents()

        Dim files() As String
        If chkMessageSubfolders.Checked Then
            files = System.IO.Directory.GetFiles(m_strTopSearchFolder, "*" & MESSAGE_FILENAME_EXTENSION, IO.SearchOption.AllDirectories)
        Else
            files = System.IO.Directory.GetFiles(m_strTopSearchFolder, "*" & MESSAGE_FILENAME_EXTENSION, IO.SearchOption.TopDirectoryOnly)
        End If

        Dim xDoc As New Xml.XmlDocument()
        Dim intMessagesFound As Integer = 0

        Dim boolApplyTagFilter As Boolean = txtMessageTags.Text.Trim.Length > 0
        Dim strTagFilter As String = txtMessageTags.Text.Trim

        Dim boolApplyReadFilter As Boolean = cboMessageRead.SelectedIndex > 0
        Dim boolReadFilter As Boolean = cboMessageRead.SelectedIndex = 1

        Dim boolApplyAttachmentsFilter As Boolean = cboMessageAttachments.SelectedIndex > 0
        Dim boolAttachmentsFilter As Boolean = cboMessageAttachments.SelectedIndex = 1

        Dim boolApplySubjectFilter As Boolean = cboMessageSubject.SelectedIndex > 0
        Dim boolSubjectFilter As Boolean = cboMessageSubject.SelectedIndex = 1

        Dim boolApplyBodyFilter As Boolean = cboMessageBody.SelectedIndex > 0

        Dim boolApplyFromFilter As Boolean
        Dim strFromUserIDFilter As String = String.Empty '-- can only be userid
        Dim strMessageFromFilter As String = String.Empty '-- could be address or name 
        If txtMessageFrom.Text.Trim.Length > 0 Then
            boolApplyFromFilter = True
            strMessageFromFilter = txtMessageFrom.Text.Trim
        ElseIf cboMessageFrom.SelectedIndex > 0 Then
            Dim entry As AddressBookEntry = m_lstAddressBook.Item(cboMessageFrom.SelectedIndex - 2)
            If entry.ContactType = AddressBookEntryType.Email Then
                '-- best to search on email address, if we can
                strMessageFromFilter = entry.Address
            End If
            boolApplyFromFilter = True
        Else
            boolApplyFromFilter = False
        End If

        Dim boolApplyTOFilter As Boolean
        Dim strToUserIDFilter As String = String.Empty
        Dim strMessageToFilter As String = String.Empty
        If txtMessageTo.Text.Trim.Length > 0 Then
            boolApplyTOFilter = True
            strMessageToFilter = txtMessageTo.Text.Trim
        ElseIf cboMessageTo.SelectedIndex > 2 Then
            boolApplyTOFilter = True
            Dim entry As AddressBookEntry = m_lstAddressBook.Item(cboMessageTo.SelectedIndex - 2)
            If entry.ContactType = AddressBookEntryType.Email Then
                '-- best to search on email address, if we can
                strMessageToFilter = entry.Address
            Else
                '-- for TrulyMail contacts, searching on the ID is fine
                strToUserIDFilter = entry.ID
            End If
        Else
            boolApplyTOFilter = False
        End If

        Dim boolApplyCCFilter As Boolean
        Dim strCCUserIDFilter As String = String.Empty
        Dim strMessageCCFilter As String = String.Empty
        If txtMessageCC.Text.Trim.Length > 0 Then
            boolApplyCCFilter = True
            strMessageCCFilter = txtMessageCC.Text.Trim
        ElseIf cboMessageCC.SelectedIndex > 2 Then
            boolApplyCCFilter = True
            Dim entry As AddressBookEntry = m_lstAddressBook.Item(cboMessageCC.SelectedIndex - 2)
            If entry.ContactType = AddressBookEntryType.Email Then
                '-- best to search on email address, if we can
                strMessageCCFilter = entry.Address
            Else
                '-- for TrulyMail contacts, searching on the ID is fine
                strCCUserIDFilter = entry.ID
            End If
        Else
            boolApplyCCFilter = False
        End If

        Dim boolApplyBCCFilter As Boolean
        Dim strBCCUserIDFilter As String = String.Empty
        Dim strMessageBCCFilter As String = String.Empty
        If txtMessageBCC.Text.Trim.Length > 0 Then
            boolApplyBCCFilter = True
            strMessageBCCFilter = txtMessageBCC.Text.Trim
        ElseIf cboMessageBCC.SelectedIndex > 2 Then
            boolApplyBCCFilter = True
            Dim entry As AddressBookEntry = m_lstAddressBook.Item(cboMessageBCC.SelectedIndex - 2)
            If entry.ContactType = AddressBookEntryType.Email Then
                '-- best to search on email address, if we can
                strMessageBCCFilter = entry.Address
            Else
                '-- for TrulyMail contacts, searching on the ID is fine
                strBCCUserIDFilter = entry.ID
            End If
        Else
            boolApplyBCCFilter = False
        End If

        Dim intTotalSizeFilter As Integer = Convert.ToInt32(txtMessageSize.Text)

        Dim boolApplyMessageTypeFilter As Boolean
        Dim lstMessageTypeFilter As New List(Of String)
        If lvMessageTypes.CheckedObjects.Count = lvMessageTypes.Items.Count Then
            boolApplyMessageTypeFilter = False
        Else
            boolApplyMessageTypeFilter = True
            Dim arr As ArrayList = lvMessageTypes.CheckedObjects()
            Dim messageType As MessageTypeItem
            For Each messageType In arr
                lstMessageTypeFilter.Add(messageType.ID)
            Next

            If lstMessageTypeFilter.Count = 0 Then
                '-- user selected no message types
                ShowMessageBoxError("You must check at least one message type.")
                Exit Sub
            End If
        End If

        '-- Variables representing the data in the message
        Dim boolAttachments As Boolean
        Dim strMessageTypeID As String

        Dim lst As New List(Of TrulyMailMessage)

        '-- do it here so, hopefully, we can see the list build as search progresses
        Me.olvMessages.SetObjects(lst)
        Me.olvMessages.BringToFront()
        TabControl1.SelectTab(tabResults)
        pnlResults.Show()


        Me.olvMessages.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf MainRowFormatter)
        Me.OlvColumnSize.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterSize)
        Me.OlvColumnMessageDateSent.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterDate)
        Me.OlvColumnSubject.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf MessageImageGetter)
        Me.olvColumnTransportType.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf TransportTypeImageGetter)
        Me.olvColumnTransportType.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf NoTextAspectToStringConverter)
        Me.olvColumnHasNotes.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf HasNotesImageGetter)
        Me.olvColumnHasNotes.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf NoTextAspectToStringConverter)

        Dim item As TrulyMailMessage

        prgSearchProgress.Maximum = files.Length
        For Each strFilename As String In files
            If m_boolCancelSearch Then
                Exit For
            End If
            prgSearchProgress.Value += 1
            Application.DoEvents()
            '-- look at each file and see if it matches all of our criteria
            Try
                item = New TrulyMailMessage(strFilename)
            Catch ex As Exception
                Log(ex)
                Continue For
            End Try

            If item Is Nothing Then
                Continue For
            End If

            If boolApplyTagFilter Then
                If Not item.Tags.ToLower.Contains(strTagFilter.ToLower()) Then
                    '-- didn't match the entered tag
                    Continue For
                End If
            End If

            If boolApplyReadFilter Then
                If Not item.Read = boolReadFilter Then
                    '-- didn't match the read filter
                    Continue For
                End If
            End If
            If boolApplyAttachmentsFilter Then
                If item.Attachments.Count > 0 Then
                    boolAttachments = True
                Else
                    '-- no attachments tag, there are none
                    boolAttachments = False
                End If
                If Not boolAttachments = boolAttachmentsFilter Then
                    '-- didn't match the attachments filter
                    Continue For
                End If
            End If
            If boolApplySubjectFilter Then
                If boolSubjectFilter Then
                    '-- requires exact match
                    If Not item.Subject.Trim.ToLower = txtMessageSubject.Text.Trim.ToLower Then
                        Continue For
                    End If
                Else
                    '-- requires contains match
                    If Not item.Subject.Trim.ToLower.Contains(txtMessageSubject.Text.Trim.ToLower) Then
                        Continue For
                    End If
                End If
            End If
            If boolApplyBodyFilter Then
                '-- requires contains match
                If Not item.Body.Trim.ToLower.Contains(txtMessageBody.Text.Trim.ToLower) Then
                    Continue For
                End If
            End If
            Dim dtDefault As Date
            If item.MessageDateSent <> dtDefault AndAlso item.MessageDateSent < dtpMessageSentAfter.Value Then
                Continue For
            End If

            '-- add one day to include the entire final date of search range
            If item.MessageDateSent <> dtDefault AndAlso item.MessageDateSent > dtpMessageSentBefore.Value.AddDays(1) Then
                Continue For
            End If

            Select Case cboMessageSize.SelectedIndex
                Case 0
                    '-- >
                    If item.Size <= intTotalSizeFilter Then
                        Continue For
                    End If
                Case 1
                    '-- =
                    If item.Size <> intTotalSizeFilter Then
                        Continue For
                    End If
                Case 2
                    '-- <
                    If item.Size >= intTotalSizeFilter Then
                        Continue For
                    End If
            End Select
            If boolApplyMessageTypeFilter Then
                strMessageTypeID = GetMessageTypeIDFromMessageType(item.MessageType)
                If Not lstMessageTypeFilter.Contains(strMessageTypeID) Then
                    Continue For
                End If
            End If

            If boolApplyFromFilter Then
                If strMessageFromFilter.Length > 0 Then
                    '-- filter based on name or address of sender
                    If Not item.Sender.FullName.ToLower.Contains(strMessageFromFilter.ToLower) AndAlso Not item.Sender.Address.ToLower.Contains(strMessageFromFilter.ToLower) Then
                        '-- The from does not match the filter, skip it
                        Continue For
                    End If
                ElseIf strFromUserIDFilter.Length = 0 Then
                    '-- from me
                    If Not item.Sent Then
                        '-- actually from someone else (since it was received)
                        Continue For
                    End If
                Else
                    '-- from specific user
                    If Not item.Sent Then
                        If Not item.Sender.ID.ToLower = strFromUserIDFilter.ToLower Then
                            '-- This was from a different user
                            Continue For
                        End If
                    Else
                        '-- this was actually from me
                        Continue For
                    End If
                End If
            End If

            If boolApplyTOFilter Then
                Dim boolMatch As Boolean = False
                If strMessageToFilter.Length > 0 Then
                    '-- filter based on name or address with TO role
                    For Each recip As RecipientEntry In item.Recipients
                        If recip.RecipientType = RecipientType.Send_To AndAlso (recip.FullName.ToLower.Contains(strMessageToFilter) OrElse recip.Address.ToLower.Contains(strMessageToFilter)) Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        Continue For
                    End If
                ElseIf strToUserIDFilter.Length = 0 Then
                    '-- to me
                    For Each recip As RecipientEntry In item.Recipients
                        If recip.RecipientType = RecipientType.Send_To AndAlso recip.ID = String.Empty AndAlso recip.ContactType = AddressBookEntryType.TrulyMail Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        '-- I am not in the to list
                        Continue For
                    End If
                Else
                    '-- to specific userID
                    For Each recip As RecipientEntry In item.Recipients
                        If recip.RecipientType = RecipientType.Send_To AndAlso recip.ID = strToUserIDFilter Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        '-- no match in the to list
                        Continue For
                    End If
                End If
            End If

            If boolApplyCCFilter Then
                Dim boolMatch As Boolean = False
                If strMessageCCFilter.Length > 0 Then
                    '-- filter based on name or address with CC role
                    For Each recip As RecipientEntry In item.Recipients
                        If recip.RecipientType = RecipientType.Send_CC AndAlso (recip.FullName.ToLower.Contains(strMessageCCFilter) OrElse recip.Address.ToLower.Contains(strMessageCCFilter)) Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        Continue For
                    End If
                ElseIf strCCUserIDFilter.Length = 0 Then
                    '-- CC me
                    For Each recip As RecipientEntry In item.Recipients
                        If recip.RecipientType = RecipientType.Send_CC AndAlso recip.ID = String.Empty AndAlso recip.ContactType = AddressBookEntryType.TrulyMail Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        '-- I am not in the cc list
                        Continue For
                    End If
                Else
                    '-- CC specific user
                    For Each recip As RecipientEntry In item.Recipients
                        If recip.RecipientType = RecipientType.Send_CC AndAlso recip.ID = strCCUserIDFilter Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        '-- no macth in the cc list
                        Continue For
                    End If
                End If
            End If

            If boolApplyBCCFilter Then
                Dim boolMatch As Boolean = False
                If strMessageBCCFilter.Length > 0 Then
                    '-- filter based on name or address with CC role
                    For Each recip As RecipientEntry In item.Recipients
                        If recip.RecipientType = RecipientType.Send_BCC AndAlso (recip.FullName.ToLower.Contains(strMessageBCCFilter) OrElse recip.Address.ToLower.Contains(strMessageBCCFilter)) Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        Continue For
                    End If
                ElseIf strBCCUserIDFilter.Length = 0 Then
                    For Each recip As RecipientEntry In item.Recipients
                        If recip.RecipientType = RecipientType.Send_BCC AndAlso recip.ID = String.Empty AndAlso recip.ContactType = AddressBookEntryType.TrulyMail Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        '-- I am not in the bcc list
                        Continue For
                    End If
                Else
                    '-- BCC specific user
                    For Each recip As RecipientEntry In item.Recipients
                        If recip.RecipientType = RecipientType.Send_BCC AndAlso recip.ID = strBCCUserIDFilter Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        '-- no macth in the bcc list
                        Continue For
                    End If
                End If
            End If

            lst.Add(item)
        Next

        olvMessages.SetObjects(lst)
        olvColumnAttachmentMessageTag.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        OlvColumnSubject.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        OlvColumnRecipients.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        OlvColumnSender.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)


        olvAttachments.Hide()
        btnSearch.Enabled = True
        Me.lblSearchProgress.Visible = False
        Me.prgSearchProgress.Visible = False
        btnCancel.Visible = False
    End Sub
    Private Sub SearchForAttachments()
        btnSearch.Enabled = False

        lblSearchProgress.Visible = True
        prgSearchProgress.Visible = True
        btnCancel.Visible = True
        prgSearchProgress.Value = 0
        Application.DoEvents()

        m_strTopSearchFolder = ToolTip1.GetToolTip(llblChangeAttachmentFolder)

        Dim files() As String
        If chkAttachmentSubfolders.Checked Then
            files = System.IO.Directory.GetFiles(m_strTopSearchFolder, "*" & MESSAGE_FILENAME_EXTENSION, IO.SearchOption.AllDirectories)
        Else
            files = System.IO.Directory.GetFiles(m_strTopSearchFolder, "*" & MESSAGE_FILENAME_EXTENSION, IO.SearchOption.TopDirectoryOnly)
        End If

        Dim xDoc As New Xml.XmlDocument()
        Dim intMessagesFound As Integer = 0

        Dim boolApplyMessageTagFilter As Boolean = txtAttachmentMessageTag.Text.Trim.Length > 0
        Dim strMessageTagFilter As String = txtAttachmentMessageTag.Text.Trim

        Dim boolApplyReadFilter As Boolean = cboAttachmentRead.SelectedIndex > 0
        Dim boolReadFilter As Boolean = cboAttachmentRead.SelectedIndex = 1

        Dim boolApplySubjectFilter As Boolean = cboAttachmentSubject.SelectedIndex > 0
        Dim boolSubjectFilter As Boolean = cboAttachmentSubject.SelectedIndex = 1

        Dim boolApplyBodyFilter As Boolean = cboAttachmentBody.SelectedIndex > 0

        Dim boolApplyFromFilter As Boolean
        Dim strFromUserIDFilter As String = String.Empty '-- can only be userid
        Dim strMessageFromFilter As String = String.Empty '-- could be address or name 
        If txtAttachmentFrom.Text.Trim.Length > 0 Then
            boolApplyFromFilter = True
            strMessageFromFilter = txtAttachmentFrom.Text.Trim
        ElseIf cboAttachmentFrom.SelectedIndex > 2 Then
            Dim entry As AddressBookEntry = m_lstAddressBook.Item(cboAttachmentFrom.SelectedIndex - 2)
            If entry.ContactType = AddressBookEntryType.Email Then
                '-- best to search on email address, if we can
                strMessageFromFilter = entry.Address
            Else
                '-- for TrulyMail contacts, searching on the ID is fine
                strFromUserIDFilter = entry.ID
            End If
            boolApplyFromFilter = True
        Else
            boolApplyFromFilter = False
        End If

        Dim boolApplyTOFilter As Boolean
        Dim strToUserIDFilter As String = String.Empty
        Dim strMessageToFilter As String = String.Empty
        If txtAttachmentTo.Text.Trim.Length > 0 Then
            boolApplyTOFilter = True
            strMessageToFilter = txtAttachmentTo.Text.Trim
        ElseIf cboAttachmentTo.SelectedIndex > 2 Then
            boolApplyTOFilter = True
            Dim entry As AddressBookEntry = m_lstAddressBook.Item(cboAttachmentTo.SelectedIndex - 2)
            If entry.ContactType = AddressBookEntryType.Email Then
                '-- best to search on email address, if we can
                strMessageToFilter = entry.Address
            Else
                '-- for TrulyMail contacts, searching on the ID is fine
                strToUserIDFilter = entry.ID
            End If
        Else
            boolApplyTOFilter = False
        End If

        Dim boolApplyCCFilter As Boolean
        Dim strCCUserIDFilter As String = String.Empty
        Dim strMessageCCFilter As String = String.Empty
        If txtAttachmentCC.Text.Trim.Length > 0 Then
            boolApplyCCFilter = True
            strMessageCCFilter = txtAttachmentCC.Text.Trim
        ElseIf cboAttachmentCC.SelectedIndex > 2 Then
            boolApplyCCFilter = True
            Dim entry As AddressBookEntry = m_lstAddressBook.Item(cboAttachmentCC.SelectedIndex - 2)
            If entry.ContactType = AddressBookEntryType.Email Then
                '-- best to search on email address, if we can
                strMessageCCFilter = entry.Address
            Else
                '-- for TrulyMail contacts, searching on the ID is fine
                strCCUserIDFilter = entry.ID
            End If
        Else
            boolApplyCCFilter = False
        End If

        Dim boolApplyBCCFilter As Boolean
        Dim strBCCUserIDFilter As String = String.Empty
        Dim strMessageBCCFilter As String = String.Empty
        If txtAttachmentBCC.Text.Trim.Length > 0 Then
            boolApplyBCCFilter = True
            strMessageBCCFilter = txtAttachmentBCC.Text.Trim
        ElseIf cboAttachmentBCC.SelectedIndex > 2 Then
            boolApplyBCCFilter = True
            Dim entry As AddressBookEntry = m_lstAddressBook.Item(cboAttachmentBCC.SelectedIndex - 2)
            If entry.ContactType = AddressBookEntryType.Email Then
                '-- best to search on email address, if we can
                strMessageBCCFilter = entry.Address
            Else
                '-- for TrulyMail contacts, searching on the ID is fine
                strBCCUserIDFilter = entry.ID
            End If
        Else
            boolApplyBCCFilter = False
        End If

        Dim intTotalSizeFilter As Integer = Convert.ToInt32(txtAttachmentMessageSize.Text)
        Dim intAttachmentSizeFilter As Integer = Convert.ToInt32(txtAttachmentAttachmentSize.Text)

        Dim boolApplyMessageTypeFilter As Boolean
        Dim lstMessageTypeFilter As New List(Of String)
        If lvMessageTypes.CheckedObjects.Count = lvMessageTypes.Items.Count Then
            boolApplyMessageTypeFilter = False
        Else
            boolApplyMessageTypeFilter = True
            Dim arr As ArrayList = lvAttachmentMessageType.CheckedObjects()
            Dim item As MessageTypeItem
            For Each item In arr
                lstMessageTypeFilter.Add(item.ID)
            Next

            If lstMessageTypeFilter.Count = 0 Then
                '-- user selected no message types
                ShowMessageBoxError("You must check at least one message type.")
                Exit Sub
            End If
        End If

        '-- Variables representing the data in the message
        Dim strMessageTypeID As String

        Dim lst As New List(Of TrulyMailAttachmentSearchResult)
        Me.olvAttachments.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf AttachmentRowFormatter)
        olvColumnAttachmentName.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf AttachmentImageGetter)
        Me.OlvColumnMessageSize.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterSize)
        Me.OlvColumnAttachmentSize.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterSize)
        Me.olvColumnAttachmentDate.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterDate)

        Dim message As TrulyMailMessage
        prgSearchProgress.Maximum = files.Length
        For Each strFilename As String In files
            If m_boolCancelSearch Then
                Exit For
            End If

            prgSearchProgress.Value += 1
            Application.DoEvents()

            '-- look at each file and see if it matches all of our criteria
            Try
                message = New TrulyMailMessage(strFilename)
            Catch ex As Exception
                Log(ex)
                Continue For
            End Try

            If message Is Nothing Then
                Continue For
            End If

            '-- Fastest way is to eliminate any messages without attachments
            If message.Attachments.Count = 0 Then
                Continue For
            End If

            If boolApplyMessageTagFilter Then
                If Not message.Tags.ToLower.Contains(strMessageTagFilter.ToLower()) Then
                    '-- didn't match the tag filter
                    Continue For
                End If
            End If

            If boolApplyReadFilter Then
                If Not message.Read = boolReadFilter Then
                    '-- didn't match the read filter
                    Continue For
                End If
            End If

            If boolApplySubjectFilter Then
                If boolSubjectFilter Then
                    '-- requires exact match
                    If Not message.Subject.Trim.ToLower = txtMessageSubject.Text.Trim.ToLower Then
                        Continue For
                    End If
                Else
                    '-- requires contains match
                    If Not message.Subject.Trim.ToLower.Contains(txtMessageSubject.Text.Trim.ToLower) Then
                        Continue For
                    End If
                End If
            End If

            If boolApplyBodyFilter Then
                '-- requires contains match
                If Not message.Body.Trim.ToLower.Contains(txtMessageBody.Text.Trim.ToLower) Then
                    Continue For
                End If
            End If

            If boolApplyFromFilter Then
                If strMessageFromFilter.Length > 0 Then
                    '-- filter based on name or address of sender
                    If Not message.Sender.FullName.ToLower.Contains(strMessageFromFilter.ToLower) AndAlso Not message.Sender.Address.ToLower.Contains(strMessageFromFilter.ToLower) Then
                        '-- The from does not match the filter, skip it
                        Continue For
                    End If
                ElseIf strFromUserIDFilter.Length = 0 Then
                    '-- from me
                    If Not message.Sent Then
                        '-- actually from someone else (since it was received)
                        Continue For
                    End If
                Else
                    '-- from specific user
                    If Not message.Sent Then
                        If Not message.Sender.ID.ToLower = strFromUserIDFilter.ToLower Then
                            '-- This was from a different user
                            Continue For
                        End If
                    Else
                        '-- this was actually from me
                        Continue For
                    End If
                End If
            End If

            If boolApplyTOFilter Then
                Dim boolMatch As Boolean = False
                If strMessageToFilter.Length > 0 Then
                    '-- filter based on name or address with TO role
                    For Each recip As RecipientEntry In message.Recipients
                        If recip.RecipientType = RecipientType.Send_To AndAlso (recip.FullName.ToLower.Contains(strMessageToFilter) OrElse recip.Address.ToLower.Contains(strMessageToFilter)) Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        Continue For
                    End If
                ElseIf strToUserIDFilter.Length = 0 Then
                    '-- to me
                    For Each recip As RecipientEntry In message.Recipients
                        If recip.RecipientType = RecipientType.Send_To AndAlso recip.ID = String.Empty AndAlso recip.ContactType = AddressBookEntryType.TrulyMail Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        '-- I am not in the to list
                        Continue For
                    End If
                Else
                    '-- to specific user
                    For Each recip As RecipientEntry In message.Recipients
                        If recip.RecipientType = RecipientType.Send_To AndAlso recip.ID.ToLower = strToUserIDFilter.ToLower Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        '-- no match in the to list
                        Continue For
                    End If
                End If
            End If

            If boolApplyCCFilter Then
                Dim boolMatch As Boolean = False
                If strMessageCCFilter.Length > 0 Then
                    '-- filter based on name or address with CC role
                    For Each recip As RecipientEntry In message.Recipients
                        If recip.RecipientType = RecipientType.Send_CC AndAlso (recip.FullName.ToLower.Contains(strMessageCCFilter) OrElse recip.Address.ToLower.Contains(strMessageCCFilter)) Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        Continue For
                    End If
                ElseIf strCCUserIDFilter.Length = 0 Then
                    '-- CC me
                    For Each recip As RecipientEntry In message.Recipients
                        If recip.RecipientType = RecipientType.Send_CC AndAlso recip.ID = String.Empty AndAlso recip.ContactType = AddressBookEntryType.TrulyMail Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        '-- I am not in the cc list
                        Continue For
                    End If
                Else
                    '-- CC specific user
                    For Each recip As RecipientEntry In message.Recipients
                        If recip.RecipientType = RecipientType.Send_CC AndAlso recip.ID.ToLower = strCCUserIDFilter.ToLower() Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        '-- no macth in the cc list
                        Continue For
                    End If
                End If
            End If

            If boolApplyBCCFilter Then
                Dim boolMatch As Boolean = False
                If strMessageBCCFilter.Length > 0 Then
                    '-- filter based on name or address with CC role
                    For Each recip As RecipientEntry In message.Recipients
                        If recip.RecipientType = RecipientType.Send_BCC AndAlso (recip.FullName.ToLower.Contains(strMessageBCCFilter) OrElse recip.Address.ToLower.Contains(strMessageBCCFilter)) Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        Continue For
                    End If
                ElseIf strBCCUserIDFilter.Length = 0 Then
                    For Each recip As RecipientEntry In message.Recipients
                        If recip.RecipientType = RecipientType.Send_BCC AndAlso recip.ID = String.Empty AndAlso recip.ContactType = AddressBookEntryType.TrulyMail Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        '-- I am not in the bcc list
                        Continue For
                    End If
                Else
                    '-- BCC specific user
                    For Each recip As RecipientEntry In message.Recipients
                        If recip.RecipientType = RecipientType.Send_BCC AndAlso recip.ID = strBCCUserIDFilter Then
                            boolMatch = True
                            Exit For
                        End If
                    Next
                    If Not boolMatch Then
                        '-- no macth in the bcc list
                        Continue For
                    End If
                End If
            End If


            Dim dtDefault As Date
            If message.MessageDateSent <> dtDefault AndAlso message.MessageDateSent < dtpAttachmentAfter.Value Then
                Continue For
            End If

            '-- add one day to include the entire final date of search range
            If message.MessageDateSent <> dtDefault AndAlso message.MessageDateSent > dtpAttachmentBefore.Value.AddDays(1) Then
                Continue For
            End If

            '-- size filters
            Select Case cboMessageSize.SelectedIndex
                Case 0
                    '-- >
                    If message.Size <= intTotalSizeFilter Then
                        Continue For
                    End If
                Case 1
                    '-- =
                    If message.Size <> intTotalSizeFilter Then
                        Continue For
                    End If
                Case 2
                    '-- <
                    If message.Size >= intTotalSizeFilter Then
                        Continue For
                    End If
            End Select

            '-- Check the message type
            If boolApplyMessageTypeFilter Then
                strMessageTypeID = GetMessageTypeIDFromMessageType(message.MessageType)
                If Not lstMessageTypeFilter.Contains(strMessageTypeID) Then
                    Continue For
                End If
            End If


            '-- Now we add one item for each attachment herein
            Dim lstAttachments As List(Of AttachmentItem) = message.Attachments()
            For Each attachment As AttachmentItem In lstAttachments
                Select Case cboAttachmentAttachmentSize.SelectedIndex
                    Case 0
                        '-- >
                        If attachment.FileSize <= intAttachmentSizeFilter Then
                            Continue For
                        End If
                    Case 1
                        '-- =
                        If attachment.FileSize <> intAttachmentSizeFilter Then
                            Continue For
                        End If
                    Case 2
                        '-- <
                        If attachment.FileSize >= intAttachmentSizeFilter Then
                            Continue For
                        End If
                End Select

                Select Case cboAttachmentName.SelectedIndex
                    Case 0 '-- all
                        '-- no filter, do nothing
                    Case 1 '-- is exactly
                        If Not attachment.DisplayName.ToLower = txtAttachmentName.Text.ToLower Then
                            Continue For
                        End If
                    Case 2 '-- contains
                        If Not attachment.DisplayName.ToLower.Contains(txtAttachmentName.Text.ToLower) Then
                            Continue For
                        End If
                    Case 3 '-- starts with
                        If Not attachment.DisplayName.ToLower.StartsWith(txtAttachmentName.Text.ToLower) Then
                            Continue For
                        End If
                    Case 4 '-- ends with
                        If Not attachment.DisplayName.ToLower.EndsWith(txtAttachmentName.Text.ToLower) Then
                            Continue For
                        End If
                End Select

                '-- do not show embeded images
                If attachment.DisplayName.StartsWith(IMAGES_EMBEDDED_FOLDER) Then
                    Continue For
                End If


                Dim item As New TrulyMailAttachmentSearchResult
                item.Subject = message.SubjectShort
                item.Read = message.Read
                item.MessageDateSent = message.MessageDateSent
                item.Filename = strFilename
                item.MessageSize = message.Size
                item.Sent = message.Sent
                item.Sender = message.SenderName
                item.Recipients = message.RecipientNamesShort
                item.Attachments = message.Attachments.Count
                item.Tags = message.Tags
                item.MessageDateToSend = message.MessageDateToSend
                item.LastSaveDate = message.LastSaveDate
                item.MessageDateUnsent = message.MessageDateUnsent


                item.AttachmentFileSize = attachment.FileSize
                item.AttachmentFilename = attachment.DisplayName
                item.AttachmentFullPath = attachment.Filename

                lst.Add(item)
            Next
        Next

        Me.olvAttachments.SetObjects(lst)
        olvColumnAttachmentMessageTag.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        olvMessageFolder.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        OlvColumnSubject.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        OlvColumnRecipients.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        OlvColumnSender.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)


        TabControl1.SelectTab(tabResults)
        olvAttachments.Show()
        pnlResults.Hide()
        btnSearch.Enabled = True
        lblSearchProgress.Visible = False
        prgSearchProgress.Visible = False
        btnCancel.Visible = False
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        OpenCurrentlySelectedMessage()
    End Sub
    Private Sub OpenCurrentlySelectedMessage()
        If pnlResults.Visible Then
            Dim list As ArrayList = olvMessages.GetSelectedObjects
            For Each tm As TrulyMailMessage In list
                LoadMessage(tm.Filename)
            Next
        ElseIf olvAttachments.Visible Then
            Dim list As ArrayList = olvAttachments.GetSelectedObjects
            For Each tm As TrulyMailAttachmentSearchResult In list
                LoadMessage(tm.Filename)
            Next
        End If
    End Sub

    Private Sub lvMessages_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvMessages.ItemActivate
        OpenCurrentlySelectedMessage()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteCurrentlySelectedMessages()
    End Sub

    Private Sub MoveToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveToToolStripMenuItem.Click
        MoveSelectedMessages()
    End Sub
    Private Sub MoveSelectedMessages()
        Try
            Dim fbd As New FolderBrowserDialogTM()
            fbd.ShowNewFolderButton = True
            fbd.ShowAllFolders = False
            fbd.Description = "Select new folder for message(s)"
            If AppSettings.LastSelectedFolderInFolderBrowser Is Nothing Then
                'fbd.SelectedPath =  GetCurrentlySelectedTreeViewNode.Tag.ToString()
            End If

            If fbd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                '-- move message
                Dim strDestinationFolder As String = fbd.SelectedPath
                Dim strSourceFolder As String

                Dim items As System.Collections.ArrayList = olvMessages.SelectedObjects
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
                    MainFormReference.SetUndoTextAndStatus()
                End If

                'm_boolPreventLoadingPreview = True
                olvMessages.RemoveObjects(items)
                'm_boolPreventLoadingPreview = False


                '-- Update folderstate for the source and destination folders
                '-- instead of recounding the two folders, just adjust by what we moved
                Dim folderState As FolderState
                folderState = GetFolderState(strDestinationFolder)
                folderState.UnreadCount += intUnreadCount
                folderState.TotalCount += intTotalCount

                folderState = GetFolderState(strSourceFolder)
                folderState.UnreadCount -= intUnreadCount
                folderState.TotalCount -= intTotalCount

            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error moving the message(s): " & ex.Message)
        End Try
    End Sub
    Private Sub DeleteCurrentlySelectedMessages()
        Dim tm As ArrayList = olvMessages.GetSelectedObjects()
        For Each tmm As TrulyMailMessage In tm
            DeleteLocalMessage(tmm.Filename, ModifierKeys = Keys.Shift, True)
            olvMessages.RemoveObject(tmm)
        Next
    End Sub

    Private Sub lvMessages_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles olvMessages.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                DeleteCurrentlySelectedMessages()
        End Select
    End Sub

    Private Sub cboAttachmentSubject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAttachmentSubject.SelectedIndexChanged
        txtAttachmentSubject.Visible = cboAttachmentSubject.SelectedIndex > 0
    End Sub

    Private Sub cboAttachmentBody_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAttachmentBody.SelectedIndexChanged
        txtAttachmentBody.Visible = cboAttachmentBody.SelectedIndex > 0
    End Sub

    Private Sub cboAttachmentName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAttachmentName.SelectedIndexChanged
        txtAttachmentName.Visible = cboAttachmentName.SelectedIndex > 0
    End Sub

    Private Sub OpenAttachmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenAttachmentToolStripMenuItem.Click
        OpenCurrentlySelectedAttachments()
    End Sub

    Private Sub OpenMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenMessageToolStripMenuItem.Click
        OpenCurrentlySelectedMessage()
    End Sub

    Private Sub lvAttachments_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvAttachments.ItemActivate
        OpenCurrentlySelectedAttachments()
    End Sub
    Private Sub OpenCurrentlySelectedAttachments()
        Dim list As IList = olvAttachments.SelectedObjects
        For Each tma As TrulyMailAttachmentSearchResult In list
            Try
                OpenAttachment(tma.AttachmentFullPath)
            Catch ex As Exception
                If ex.Message.Contains("No application is associated") Then
                    MessageBox.Show("There is no application associated with this attached file." & Environment.NewLine & Environment.NewLine & _
                                    "You can drag-and-drop to save the attachment and open the file from there.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf ex.Message.Contains("The system cannot find the file specified") Then
                    MessageBox.Show("The attachment cannot be found. Perhaps it was deleted manually?", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Log(ex)
                    MessageBox.Show("There was an unexpected error (" & ex.Message & ") with this attached file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End Try
        Next
    End Sub

    Private Sub txtMessageFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMessageFrom.TextChanged
        cboMessageFrom.Enabled = txtMessageFrom.Text.Length = 0
    End Sub

    Private Sub txtMessageTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMessageTo.TextChanged
        cboMessageTo.Enabled = txtMessageTo.Text.Length = 0
    End Sub

    Private Sub txtMessageCC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMessageCC.TextChanged
        cboMessageCC.Enabled = txtMessageCC.Text.Length = 0
    End Sub

    Private Sub txtMessageBCC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMessageBCC.TextChanged
        cboMessageBCC.Enabled = txtMessageBCC.Text.Length = 0
    End Sub

    Private Sub txtAttachmentFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAttachmentFrom.TextChanged
        cboAttachmentFrom.Enabled = txtAttachmentFrom.Text.Length = 0
    End Sub

    Private Sub txtAttachmentTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAttachmentTo.TextChanged
        cboAttachmentTo.Enabled = txtAttachmentTo.Text.Length = 0
    End Sub

    Private Sub txtAttachmentCC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAttachmentCC.TextChanged
        cboAttachmentCC.Enabled = txtAttachmentCC.Text.Length = 0
    End Sub

    Private Sub txtAttachmentBCC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAttachmentBCC.TextChanged
        cboAttachmentBCC.Enabled = txtAttachmentBCC.Text.Length = 0
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        m_boolCancelSearch = True
    End Sub
    Private Sub SetAttachmentFolderPathLabel(ByVal fullPath As String)
        Const CHANGE As String = " change"
        Dim strNewPath As String = UnQualifyPath(fullPath.Substring(MessageStoreRootPath.Length)) & CHANGE
        If UnQualifyPath(MessageStoreRootPath).Length = UnQualifyPath(fullPath).Length Then
            strNewPath = "All Folders" & CHANGE
        Else
            strNewPath = UnQualifyPath(fullPath.Substring(MessageStoreRootPath.Length)) & CHANGE
            Dim intReduction As Integer
            Dim strBasePath As String = UnQualifyPath(fullPath.Substring(MessageStoreRootPath.Length))
            Do Until llblChangeAttachmentFolder.Right <= txtAttachmentSubject.Width
                intReduction += 1
                strNewPath = strBasePath.Substring(0, strBasePath.Length - intReduction) & "..." & CHANGE
                llblChangeAttachmentFolder.Text = strNewPath
            Loop
        End If
        llblChangeAttachmentFolder.Text = strNewPath
        llblChangeAttachmentFolder.LinkArea = New LinkArea(strNewPath.Length - CHANGE.Length + 1, CHANGE.Length)
        ToolTip1.SetToolTip(llblChangeAttachmentFolder, fullPath)
    End Sub
    Private Sub SetMessageFolderPathLabel(ByVal fullPath As String)
        Const CHANGE As String = " change"
        Dim strNewPath As String
        If UnQualifyPath(MessageStoreRootPath).Length = UnQualifyPath(fullPath).Length Then
            strNewPath = "All Folders" & CHANGE
            chkMessageSubfolders.Enabled = False
        Else
            chkMessageSubfolders.Enabled = True
            strNewPath = UnQualifyPath(fullPath.Substring(MessageStoreRootPath.Length)) & CHANGE
            Dim intReduction As Integer
            Dim strBasePath As String = UnQualifyPath(fullPath.Substring(MessageStoreRootPath.Length))
            Do Until llblChangeMessageFolder.Right <= txtMessageSubject.Width
                intReduction += 1
                strNewPath = strBasePath.Substring(0, strBasePath.Length - intReduction) & "..." & CHANGE
                llblChangeMessageFolder.Text = strNewPath
            Loop
        End If
        llblChangeMessageFolder.Text = strNewPath
        llblChangeMessageFolder.LinkArea = New LinkArea(strNewPath.Length - CHANGE.Length + 1, CHANGE.Length)
        ToolTip1.SetToolTip(llblChangeMessageFolder, fullPath)
    End Sub


    Private Sub llblChangeAttachmentFolder_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblChangeAttachmentFolder.LinkClicked
        Try
            Dim fbd As New FolderBrowserDialogTM()
            fbd.ShowAllFolders = True
            fbd.SelectedPath = ToolTip1.GetToolTip(llblChangeAttachmentFolder)
            fbd.ShowNewFolderButton = False
            fbd.Description = "Select folder for searching"
            If fbd.ShowDialog(Me) = DialogResult.OK Then
                SetAttachmentFolderPathLabel(fbd.SelectedPath)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error changing the folder for searching. " & CONTACT_TRULYMAIL_MESSAGE)
        End Try
    End Sub

    Private Sub llblChangeMessageFolder_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblChangeMessageFolder.LinkClicked
        Try
            Dim fbd As New FolderBrowserDialogTM()
            fbd.ShowAllFolders = True
            fbd.SelectedPath = ToolTip1.GetToolTip(llblChangeMessageFolder)
            fbd.ShowNewFolderButton = False
            fbd.Description = "Select folder for searching"
            If fbd.ShowDialog(Me) = DialogResult.OK Then
                SetMessageFolderPathLabel(fbd.SelectedPath)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error changing the folder for searching. " & CONTACT_TRULYMAIL_MESSAGE)
        End Try
    End Sub

    Private Sub SearchForm_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub txtMessageFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMessageFilter.TextChanged
        tmrFilterMessages.Stop()
        tmrFilterMessages.Start()
    End Sub

    Private Sub tmrFilterMessages_Elapsed(sender As System.Object, e As System.Timers.ElapsedEventArgs) Handles tmrFilterMessages.Elapsed
        FilterMessages()
    End Sub
    Private Sub FilterMessages()
        Try
            tmrFilterMessages.Stop()
            olvMessages.ModelFilter = Nothing

            olvMessages.ModelFilter = New BrightIdeasSoftware.TextMatchFilter(olvMessages, txtMessageFilter.Text)


            If txtMessageFilter.Text.Length = 0 Then
                olvMessages.EmptyListMsg = "There are no messages"
            Else
                olvMessages.EmptyListMsg = "No messages match your filter"
            End If
        Catch ex As Exception
            Log(ex)
        End Try
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
            br = Brushes.Black

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


    Private Sub pbAddTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAddTag.Click
        AddTag()
    End Sub

    Private Sub pbClearTags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbClearTags.Click
        ClearTags()
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

    Private Sub btnClearMessageFilter_Click(sender As System.Object, e As System.EventArgs) Handles btnClearMessageFilter.Click
        txtMessageFilter.Text = String.Empty
    End Sub
End Class