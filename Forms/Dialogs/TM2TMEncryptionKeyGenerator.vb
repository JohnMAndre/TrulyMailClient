Public Class TM2TMEncryptionKeyGenerator

    Private m_strKey As String = String.Empty
    Private m_boolKeyAppliedToContact As Boolean

    Private Sub TM2TMEncryptionKeyGenerator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.SplitContainer1.Panel2Collapsed = True
            Me.RichTextBox1.Rtf = My.Resources.EncryptionKeyRTF
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error loading the encryption password generation form." & CONTACT_TRULYMAIL_MESSAGE)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim boolCancel As Boolean

        If Not m_boolKeyAppliedToContact AndAlso m_strKey.Length > 0 Then
            If ShowMessageBox("Are you sure you want to close without saving the new password for one of your contacts?" & Environment.NewLine & Environment.NewLine & _
                              "You should select the contact from the list and click 'Use this contact' before closing." & Environment.NewLine & Environment.NewLine & _
                              "Yes = close this window without saving the password for a contact" & Environment.NewLine & _
                              "No = return to the window to select a contact.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) <> Windows.Forms.DialogResult.Yes Then
                boolCancel = True
            End If
        End If

        If Not boolCancel Then
            Close()
        End If
    End Sub

    Private Sub btnCopyKeyToClipboard_Click(sender As Object, e As EventArgs) Handles btnCopyKeyToClipboard.Click
        Try
            If m_strKey.Length = 0 Then
                GenerateKey()
            End If
            Clipboard.SetText(m_strKey)
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnWriteKeyToTextFile_Click(sender As Object, e As EventArgs) Handles btnWriteKeyToTextFile.Click
        Try
            If m_strKey.Length = 0 Then
                GenerateKey()
            End If
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            sfd.OverwritePrompt = True
            If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                System.IO.File.WriteAllText(sfd.FileName, m_strKey)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error creating the text file: " & ex.Message)
        End Try
    End Sub
    Private Sub LoadAddressBookEntries()
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf LoadAddressBookEntries)
            Invoke(deleg)
        Else
            olvAddressBook.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf MainRowFormatter)
            IconColumn.AspectGetter = New BrightIdeasSoftware.AspectGetterDelegate(AddressOf GetContactTypeIconName)
            IconColumn.Renderer = New BrightIdeasSoftware.MappedImageRenderer("TrulyMail", My.Resources.Securedmessage_16, "Email", My.Resources.email_16)

            '-- format dates
            LastMessageReceivedColumn.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf FormatDateForOLV)
            LastMessageSentColumn.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf FormatDateForOLV)

            Dim lst As New List(Of AddressBookEntry)
            Dim lstAllContacts As List(Of AddressBookEntry) = ABook.GetAllContacts

            For i As Integer = 0 To lstAllContacts.Count - 1
                If lstAllContacts(i).ContactType = AddressBookEntryType.Email Then
                    lst.Add(lstAllContacts(i))
                End If
            Next

            lst.Sort(AddressOf CompareAddressBookEntries)
            olvAddressBook.SetObjects(lst)

            AutoSizeColumns(olvAddressBook)

        End If
    End Sub
    Private Function GetContactTypeIconName(row As Object) As String
        Dim entry As AddressBookEntry = CType(row, AddressBookEntry)
        Return entry.ContactType.ToString()
    End Function

    Private Function MainRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim entry As AddressBookEntry = CType(olvi.RowObject, AddressBookEntry)
        Dim intPosition As Integer = Me.olvAddressBook.Columns.IndexOf(Me.SendReturnReceiptColumn)
        If entry.AutoSendReadReceipt = ContactReceiptOption.UseDefault Then
            If intPosition >= 0 Then
                olvi.SubItems(intPosition).Text = "Use account settings"
            End If
        End If
    End Function
    Private Sub btnGenerateKey_Click(sender As Object, e As EventArgs) Handles btnGenerateKey.Click
        GenerateKey()
    End Sub
    Private Sub GenerateKey()
        m_strKey = GenerateAlphanumericString(56)
        SplitContainer1.Panel2Collapsed = False '-- make the list of contacts visible
        LoadAddressBookEntries()
    End Sub

    Private Sub btnUseThisContact_Click(sender As Object, e As EventArgs) Handles btnUseThisContact.Click
        Try
            If m_strKey.Length = 0 Then
                ShowMessageBoxError("Please click 'Generate encryption password' before saving that key to a contact.")
                Exit Sub
            End If

            Dim boolOverwriteKey As Boolean = True

            Dim entry As AddressBookEntry = olvAddressBook.SelectedObject
            If entry Is Nothing Then
                ShowMessageBoxError("Please select a contact to use.")
            Else
                If entry.WebMailPassword.Length > 0 Then
                    '-- contact already has a password, overwrite?
                    If ShowMessageBox("This contact already has an encryption password. Overwrite it with this new one?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        boolOverwriteKey = False
                    End If
                End If

                If boolOverwriteKey Then
                    entry.WebMailPassword = m_strKey
                    m_boolKeyAppliedToContact = True
                    If ShowMessageBox("Password saved for: " & entry.FullName & Environment.NewLine & Environment.NewLine & _
                                   "Do you want to turn on automatic 2-way return receipts also?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        entry.AutoSendReadReceipt = ContactReceiptOption.Always
                        entry.AutoRequestReadReceipt = True
                        olvAddressBook.RefreshObject(entry)
                        ShowMessageBox("2 way return receipts enabled for: " & entry.FullName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                Else
                    m_boolKeyAppliedToContact = False
                End If
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error saving the password: " & ex.Message)
        End Try
    End Sub
End Class