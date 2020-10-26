Public Class ImportAddressBook

    Private m_boolOKToRefresh As Boolean
    Private m_boolSkipUpdateSampleData As Boolean

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Text files (*.tab, *.csv, *.txt)|*.tab;*.csv;*.txt|TrulyMail address book files (" & ADDRESS_BOOK_FILENAME & ")|" & ADDRESS_BOOK_FILENAME
        ofd.Title = "Select file to import"
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFileToImport.Text = ofd.FileName
        End If
    End Sub
    Private Sub UpdateSampleData()
        If Not m_boolSkipUpdateSampleData Then
            Import(10)
        End If
    End Sub

    Private Sub chkSkipFullName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipFullName.CheckedChanged
        UpdateSampleData()
        nudFullName.Enabled = Not chkSkipFullName.Checked
    End Sub

    Private Sub chkSkipEmailAddress_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipEmailAddress.CheckedChanged
        UpdateSampleData()
        nudEmailAddress.Enabled = Not chkSkipEmailAddress.Checked
    End Sub

    Private Sub chkSkipRemoteImages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipRemoteImages.CheckedChanged
        UpdateSampleData()
        nudRemoteImages.Enabled = Not chkSkipRemoteImages.Checked
    End Sub

    Private Sub chkSkipReceiveOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipReceiveOnly.CheckedChanged
        UpdateSampleData()
        nudReceiveOnly.Enabled = Not chkSkipReceiveOnly.Checked
    End Sub

    Private Sub nud_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudFullName.ValueChanged, nudEmailAddress.ValueChanged, nudRemoteImages.ValueChanged, nudReceiveOnly.ValueChanged
        UpdateSampleData()
    End Sub
    Private Function MainRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim entry As AddressBookEntry = CType(olvi.RowObject, AddressBookEntry)
        If entry.AutoSendReadReceipt = ContactReceiptOption.UseDefault Then
            olvi.SubItems(5).Text = "Use receiving account setting"
        End If
    End Function
    Private Sub txtFileToImport_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFileToImport.TextChanged
        If System.IO.File.Exists(txtFileToImport.Text) Then
            Dim strFilename As String = txtFileToImport.Text.Trim
            grpTextFormat.Enabled = Not strFilename.ToLower.EndsWith(ADDRESS_BOOK_FILENAME.ToLower)

            Try
                Dim strText As String = System.IO.File.ReadAllText(strFilename)
                If strText.Length > 2000 Then
                    strText = strText.Substring(0, 2000)
                End If
                txtRawData.Text = strText
            Catch ex As Exception
                If ex.Message.StartsWith("The process cannot access the file") AndAlso ex.Message.EndsWith("because it is being used by another process.") Then
                    ShowMessageBoxError("The address book file you have selected is in use by another program and cannot be used by TrulyMail.")
                    m_boolOKToRefresh = False
                Else
                    Log(ex)
                End If
                Exit Sub
            End Try

            m_boolOKToRefresh = System.IO.File.Exists(strFilename)
            If m_boolOKToRefresh Then
                UseBestGuess()
                UpdateSampleData()
            End If
        End If
    End Sub

    Private Sub chkFirstRowHeaders_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFirstRowHeaders.CheckedChanged
        UpdateSampleData()
    End Sub
    Private Sub UseBestGuess()
        If m_boolOKToRefresh Then
            Dim strFilename As String = txtFileToImport.Text.Trim
            If System.IO.Path.GetFileName(strFilename).ToLower = ADDRESS_BOOK_FILENAME.ToLower Then
                '-- Do nothing, it is address book format
                grpTextFormat.Enabled = False
            Else
                Dim data() As String
                grpTextFormat.Enabled = True
                Using fs As System.IO.FileStream = System.IO.File.OpenRead(strFilename)
                    Using sr As New System.IO.StreamReader(fs)
                        Dim intLineCounter As Integer
                        Dim strLine As String = sr.ReadLine()
                        strLine = sr.ReadLine '-- just use second line, in case first line is headers
                        If strLine.Length > 0 Then
                            intLineCounter += 1

                            '-- first, let's try tab-delimited
                            data = strLine.Split(vbTab)

                            If data.Length < 2 AndAlso (Not chkSkipFullName.Checked OrElse Not chkSkipReceiveOnly.Checked OrElse Not chkSkipRemoteImages.Checked) Then
                                '-- TAB didn't work, let's try CSV

                                '-- convert from CSV to TAB
                                strLine = ConvertCSVToTAB(strLine)

                                data = strLine.Split(vbTab)
                                If data.Length < 2 AndAlso (Not chkSkipFullName.Checked OrElse Not chkSkipReceiveOnly.Checked OrElse Not chkSkipRemoteImages.Checked) Then
                                    '-- Cannot read file
                                    Exit Sub
                                Else
                                    rbtnCSV.Checked = True
                                End If
                            Else
                                rbtnTAB.Checked = True
                            End If

                            Dim intPosition As Integer
                            Dim boolSetFullNameAlready As Boolean
                            m_boolSkipUpdateSampleData = True '-- don't trigger update logic at this point
                            For intPosition = LBound(data) To UBound(data)
                                If IsValidEmailAddress(data(intPosition)) Then
                                    '-- This is email address
                                    nudEmailAddress.Value = intPosition + 1 '-- 1-based
                                Else
                                    If Not boolSetFullNameAlready AndAlso data(intPosition).Length > 0 Then
                                        boolSetFullNameAlready = True
                                        nudFullName.Value = intPosition + 1 '-- 1-based
                                    End If
                                End If
                            Next
                            m_boolSkipUpdateSampleData = False

                        End If

                    End Using
                End Using
            End If
        End If
    End Sub
    ''' <summary>
    ''' Imports contacts
    ''' </summary>
    ''' <param name="maxRecords">Any other number than zero will just be a test import</param>
    ''' <remarks></remarks>
    Private Sub Import(ByVal maxRecords As Integer)
        btnImport.Enabled = False
        '-- false means update sample data
        '   true means update address book
        Dim boolRealImport As Boolean = (maxRecords = 0)

        If m_boolOKToRefresh Then
            Dim strBadData As String = String.Empty

            Dim lst As List(Of AddressBookEntry)
            If Not boolRealImport Then
                lst = New List(Of AddressBookEntry)
            End If

            Dim intBadRecords As Integer
            Dim intLineCounter As Integer
            Dim strFilename As String = txtFileToImport.Text.Trim

            If System.IO.Path.GetFileName(strFilename).ToLower = ADDRESS_BOOK_FILENAME.ToLower Then
                '-- This is a TrulyMail address book file
                '   super-easy, just load and copy the contact objects
                GroupBox1.Enabled = False

                Dim bookToImport As AddressBook
                Try
                    bookToImport = New AddressBook(strFilename)
                    For Each newContact In bookToImport.GetAllContacts()
                        intLineCounter += 1
                        If boolRealImport Then
                            lblImportProgress.Text = "Importing contact:" & intLineCounter.ToString("#,##0")
                        End If
                        Application.DoEvents()

                        If intLineCounter > maxRecords AndAlso Not boolRealImport Then
                            '-- we have enough sample data
                            Exit For
                        End If

                        '-- only import email contacts
                        If newContact.ContactType = AddressBookEntryType.Email Then
                            '-- make sure contact is not there already
                            Dim entry As AddressBookEntry = ABook.GetContactByAddress(newContact.Address)
                            If entry Is Nothing Then
                                ABook.Add(newContact)
                            End If
                        End If
                    Next
                    ABook.Save()
                Catch ex As Exception
                    Log(ex)

                End Try
                bookToImport = Nothing
            Else
                '-- ensure file is tab delimited
                '-- Parse and write entries to address book
                GroupBox1.Enabled = True
                Dim intContacts As Integer
                Dim data() As String
                Using fs As System.IO.FileStream = System.IO.File.OpenRead(txtFileToImport.Text)
                    Using sr As New System.IO.StreamReader(fs)

                        Dim strLine As String = sr.ReadLine()
                        Do While strLine IsNot Nothing
                            '-- this is before intLineCounter+=1 because we need to handle first row headers
                            If intLineCounter > maxRecords AndAlso Not boolRealImport Then
                                '-- we have enough sample data
                                Exit Do
                            End If
                            intLineCounter += 1
                            If boolRealImport Then
                                If chkFirstRowHeaders.Checked Then
                                    intContacts = intLineCounter - 1
                                Else
                                    intContacts = intLineCounter
                                End If
                                lblImportProgress.Text = "Importing contact:" & intContacts.ToString("#,##0")
                            End If
                            Application.DoEvents()

                            If chkFirstRowHeaders.Checked AndAlso intLineCounter = 1 Then
                                '-- Ignore the first line of data (must be headers)
                                strLine = sr.ReadLine
                                Continue Do
                            End If

                            If rbtnCSV.Checked Then
                                '-- convert from CSV to TAB
                                strLine = ConvertCSVToTAB(strLine)
                            End If

                            data = strLine.Split(vbTab)

                            If data.Length < 2 AndAlso (Not chkSkipFullName.Checked OrElse Not chkSkipReceiveOnly.Checked OrElse Not chkSkipRemoteImages.Checked OrElse Not chkSkipReqReceipt.Checked OrElse Not chkSkipSendReceipt.Checked OrElse Not chkSkipTags.Checked) Then
                                ShowMessageBoxError("The file may be corrupted. Please check your settings (including CSV vs. TAB) or select a different file.")
                                Exit Sub
                            End If

                            Try
                                Dim entry As New AddressBookEntry(AddressBookEntryType.Email)
                                If IsValidEmailAddress(data(nudEmailAddress.Value - 1).Trim) Then
                                    entry.Address = data(nudEmailAddress.Value - 1).Trim
                                Else
                                    intBadRecords += 1
                                    strBadData &= strLine & Environment.NewLine
                                    strLine = sr.ReadLine
                                    Continue Do
                                End If

                                If Not chkSkipFullName.Checked Then
                                    entry.FullName = data(nudFullName.Value - 1).Trim()
                                    If entry.FullName.Length = 0 Then
                                        entry.FullName = GetUserNameFromEmailAddress(entry.Address)
                                    End If
                                Else
                                    entry.FullName = GetUserNameFromEmailAddress(entry.Address)
                                End If

                                If Not chkSkipRemoteImages.Checked Then
                                    entry.RemoteImages = ConvertToBool(data(nudRemoteImages.Value - 1), False)
                                End If

                                If Not chkSkipReceiveOnly.Checked Then
                                    entry.ReceiveOnly = ConvertToBool(data(nudReceiveOnly.Value - 1), False)
                                End If

                                If Not chkSkipReqReceipt.Checked Then
                                    entry.AutoRequestReadReceipt = ConvertToBool(data(nudReqReceipt.Value - 1), False)
                                End If

                                If Not chkSkipSendReceipt.Checked Then
                                    If IsNumeric(data(nudSendReceipt.Value - 1)) Then
                                        '-- numeric
                                        Select Case data(nudSendReceipt.Value - 1)
                                            Case 1
                                                entry.AutoSendReadReceipt = ContactReceiptOption.Always
                                            Case 2
                                                entry.AutoSendReadReceipt = ContactReceiptOption.Never
                                            Case Else '-- 0=UseDefault
                                                entry.AutoSendReadReceipt = ContactReceiptOption.UseDefault
                                        End Select
                                    Else
                                        '-- string
                                        Select Case data(nudSendReceipt.Value - 1).ToLower()
                                            Case "always"
                                                entry.AutoSendReadReceipt = ContactReceiptOption.Always
                                            Case "never"
                                                entry.AutoSendReadReceipt = ContactReceiptOption.Never
                                            Case Else '-- UseDefault
                                                entry.AutoSendReadReceipt = ContactReceiptOption.UseDefault
                                        End Select
                                    End If
                                End If

                                If Not chkSkipTags.Checked Then
                                    entry.Tags = data(nudTags.Value - 1).Trim
                                End If

                                If Not chkSkipHome.Checked Then
                                    entry.PhoneHome = data(nudHome.Value - 1).Trim
                                End If
                                If Not chkSkipWork.Checked Then
                                    entry.PhoneWork = data(nudWork.Value - 1).Trim
                                End If
                                If Not chkSkipMobile.Checked Then
                                    entry.PhoneMobile = data(nudMobile.Value - 1).Trim
                                End If
                                If Not chkSkipWebPage.Checked Then
                                    entry.WebPage = data(nudWebPage.Value - 1).Trim
                                End If
                                If Not chkSkipCustom1.Checked Then
                                    entry.Custom1 = data(nudCustom1.Value - 1).Trim
                                End If
                                If Not chkSkipCustom2.Checked Then
                                    entry.Custom2 = data(nudCustom2.Value - 1).Trim
                                End If
                                If Not chkSkipCustom3.Checked Then
                                    entry.Custom3 = data(nudCustom3.Value - 1).Trim
                                End If
                                If Not chkSkipCustom4.Checked Then
                                    entry.Custom4 = data(nudCustom4.Value - 1).Trim
                                End If
                                If Not chkSkipNotes.Checked Then
                                    entry.Notes = data(nudNotes.Value - 1).Trim
                                End If
                                If Not chkSkipWebMailQuestion.Checked Then
                                    entry.WebMailQuestion = data(nudWebMailQuestion.Value - 1).Trim
                                End If
                                If Not chkSkipWebMailPassword.Checked Then
                                    entry.WebMailPassword = data(nudWebMailPassword.Value - 1).Trim
                                End If


                                If boolRealImport Then
                                    Dim tempEntry As AddressBookEntry = ABook.GetContactByAddress(entry.Address)
                                    If tempEntry Is Nothing Then
                                        ABook.Add(entry)
                                    End If
                                Else
                                    lst.Add(entry)
                                End If
                            Catch ex As Exception
                                strBadData &= strLine & Environment.NewLine
                                intBadRecords += 1
                            End Try

                            strLine = sr.ReadLine
                        Loop
                        ABook.Save()

                        If chkFirstRowHeaders.Checked Then
                            intLineCounter -= 1
                        End If
                    End Using
                End Using
            End If

            If Not boolRealImport Then
                olvAddressBook.SetObjects(lst)
            End If

            If intBadRecords > 0 Then
                If boolRealImport Then
                    lblRawDataCaption.Text = "Bad Records"
                    txtRawData.Text = strBadData
                    ShowMessageBoxError(intBadRecords & " bad records exist in the " & intLineCounter & " total records. These bad records were not imported. You can see them in the Bad Records list on this form.")
                Else
                    lblRawDataCaption.Text = "File Contents"
                    lblError.Text = "Warning: " & intBadRecords & " bad records exist in the first " & intLineCounter & " which can not be imported. You should correct the errors in this file before importing it."
                    lblError.Visible = True
                End If
            Else
                lblRawDataCaption.Text = "File Contents"
                lblError.Visible = False
            End If

            If boolRealImport Then
                Dim intSuccessfulRecords As Integer = intLineCounter - intBadRecords
                ShowMessageBox(intSuccessfulRecords & " total contacts were imported.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                lblImportProgress.Text = String.Empty
            End If
        Else
            If boolRealImport Then
                ShowMessageBoxError("There are errors you must correct before this file can be imported.")
            End If
        End If

        btnImport.Enabled = True
    End Sub
    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Import(0)
    End Sub

    ''' <summary>
    ''' Converts CSV data into tab-delimited data, accounting for quoted data
    ''' </summary>
    ''' <param name="strLine"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertCSVToTAB(ByVal strLine As String) As String
        Dim LineLength, Linepos, blnQuote, Quotepos
        Dim strNewLine As String
        LineLength = Len(strLine)
        Linepos = 1
        strNewLine = ""
        blnQuote = False

        Do While Linepos <= LineLength
            Quotepos = InStr(Mid(strLine, Linepos, LineLength - Linepos + 1), Chr(34))
            If Quotepos = 1 Then
                If Linepos < LineLength Then
                    If Mid(strLine, Linepos, 2) = Chr(34) & Chr(34) And blnQuote Then
                        strNewLine = strNewLine & Chr(34)
                        Linepos = Linepos + 2
                    Else 'one quote
                        If blnQuote Then
                            blnQuote = False
                        Else
                            blnQuote = True
                        End If
                        Linepos = Linepos + 1
                    End If
                Else 'last character
                    Linepos = Linepos + 1
                End If
            ElseIf Quotepos > 1 Then
                If blnQuote Then
                    strNewLine = strNewLine + Mid(strLine, Linepos, Quotepos - 1)
                Else 'not Quote
                    strNewLine = strNewLine + Replace(Mid(strLine, Linepos, Quotepos - 1), ",", vbTab)
                End If
                Linepos = Linepos + Quotepos - 1
            Else 'Quotepos =0
                strNewLine = strNewLine + Replace(Mid(strLine, Linepos, LineLength - Linepos + 1), ",", vbTab)
                Linepos = LineLength + 1
            End If
        Loop

        Return strNewLine
    End Function
   
    Private Sub chkSkipReqReceipt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipReqReceipt.CheckedChanged
        UpdateSampleData()
        nudReqReceipt.Enabled = Not chkSkipReqReceipt.Checked
    End Sub

    Private Sub chkSkipSendReceipt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipSendReceipt.CheckedChanged
        UpdateSampleData()
        nudSendReceipt.Enabled = Not chkSkipSendReceipt.Checked
    End Sub

    Private Sub chkSkipTags_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipTags.CheckedChanged
        UpdateSampleData()
        nudTags.Enabled = Not chkSkipTags.Checked
    End Sub

    Private Sub nudTags_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudTags.ValueChanged
        UpdateSampleData()
    End Sub

    Private Sub nudSendReceipt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudSendReceipt.ValueChanged
        UpdateSampleData()
    End Sub

    Private Sub nudReqReceipt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudReqReceipt.ValueChanged
        UpdateSampleData()
    End Sub

    Private Sub ImportAddressBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        olvAddressBook.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf MainRowFormatter)
        '-- disable all checkboxes (really make read only)
        For Each col As BrightIdeasSoftware.OLVColumn In olvAddressBook.Columns
            If col.CheckBoxes Then
                col.AspectPutter = New BrightIdeasSoftware.AspectPutterDelegate(AddressOf DoNothingAspectPutter)
            End If
        Next
    End Sub

    Private Sub chkSkipImportanceRating_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipImportanceRating.CheckedChanged
        UpdateSampleData()
        nudImportanceRating.Enabled = Not chkSkipImportanceRating.Checked
    End Sub

    Private Sub chkSkipRemindSendEveryXDays_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipRemindSendEveryXDays.CheckedChanged
        UpdateSampleData()
        nudRemindSendEveryXDays.Enabled = Not chkSkipRemindSendEveryXDays.Checked
    End Sub

    Private Sub chkSkipRemindReceiveEveryXDays_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipRemindReceiveEveryXDays.CheckedChanged
        UpdateSampleData()
        nudRemindReceiveEveryXDays.Enabled = Not chkSkipRemindReceiveEveryXDays.Checked
    End Sub

    Private Sub chkSkipBlocked_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipBlocked.CheckedChanged
        UpdateSampleData()
        nudBlocked.Enabled = Not chkSkipBlocked.Checked
    End Sub

    Private Sub chkSkipHome_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipHome.CheckedChanged
        UpdateSampleData()
        nudHome.Enabled = Not chkSkipHome.Checked
    End Sub

    Private Sub chkSkipWork_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipWork.CheckedChanged
        UpdateSampleData()
        nudWork.Enabled = Not chkSkipWork.Checked
    End Sub

    Private Sub chkSkipMobile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipMobile.CheckedChanged
        UpdateSampleData()
        nudMobile.Enabled = Not chkSkipMobile.Checked
    End Sub

    Private Sub chkSkipWebPage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipWebPage.CheckedChanged
        UpdateSampleData()
        nudWebPage.Enabled = Not chkSkipWebPage.Checked
    End Sub

    Private Sub chkSkipCustom1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipCustom1.CheckedChanged
        UpdateSampleData()
        nudCustom1.Enabled = Not chkSkipCustom1.Checked
    End Sub

    Private Sub chkSkipCustom2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipCustom2.CheckedChanged
        UpdateSampleData()
        nudCustom2.Enabled = Not chkSkipCustom2.Checked
    End Sub

    Private Sub chkSkipCustom3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipCustom3.CheckedChanged
        UpdateSampleData()
        nudCustom3.Enabled = Not chkSkipCustom3.Checked
    End Sub

    Private Sub chkSkipCustom4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipCustom4.CheckedChanged
        UpdateSampleData()
        nudCustom4.Enabled = Not chkSkipCustom4.Checked
    End Sub

    Private Sub chkSkipNotes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipNotes.CheckedChanged
        UpdateSampleData()
        nudNotes.Enabled = Not chkSkipNotes.Checked
    End Sub

    Private Sub chkSkipWebMailQuestion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipWebMailQuestion.CheckedChanged
        UpdateSampleData()
        nudWebMailQuestion.Enabled = Not chkSkipWebMailQuestion.Checked
    End Sub

    Private Sub chkSkipWebMailPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipWebMailPassword.CheckedChanged
        UpdateSampleData()
        nudWebMailPassword.Enabled = Not chkSkipWebMailPassword.Checked
    End Sub
    

End Class