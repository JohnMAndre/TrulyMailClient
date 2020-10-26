Public Class ExportMessages

    Private m_strFolderToExport As String = MessageStoreRootPath
    Private m_boolCancel As Boolean

    Private Sub pbExportPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbExportPath.Click
        ShowMessageBox("This is the top-level folder. All messages will be stored inside folders under this folder in .eml format.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub pbSelectFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSelectFolder.Click
        ShowMessageBox("Choose the folder within TrulyMail that you would like to export. 'All folders' is an option.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub pbIncludeSubFolders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbIncludeSubFolders.Click
        ShowMessageBox("Check the 'Include sub-folders' box if you want to export all TrulyMail folders which are under the folder selected above.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub pbFilename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbFilename.Click
        ShowMessageBox("If you choose Subject, then any duplicate subjects in the same folder will have random characters appended to make the filenames unique." & _
                       Environment.NewLine & Environment.NewLine & _
                       "If you choose TrulyMail ID, then the filenames will match the filenames used within TrulyMail.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub pbIncludeEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbIncludeEmail.Click
        ShowMessageBox("Check the 'Include email messages' box to export email messages found in the choosen folder(s).", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub pbIncludeTrulyMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbIncludeTrulyMail.Click
        ShowMessageBox("Check the 'Include TrulyMail messages' box to export TrulyMail messages." & _
                       Environment.NewLine & Environment.NewLine & _
                       "Note: .eml files require email address and TrulyMail contacts do not have email addresses." & _
                       Environment.NewLine & Environment.NewLine & _
                       "For this reason, you will need to choose a 'dummy' email address to use for TrulyMail contacts.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub chkIncludeTrulyMailMessages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncludeTrulyMailMessages.CheckedChanged
        txtTrulyMailEmailAddress.Enabled = chkIncludeTrulyMailMessages.Checked
    End Sub

    Private Sub btnBrowseForData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseForData.Click
        Dim fbd As New FolderBrowserDialog()
        fbd.Description = "Select folder to save exported .eml files."
        If fbd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtDataPath.Text = fbd.SelectedPath
        End If
    End Sub

    Private Sub ExportMessages_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetPathLabel(m_strFolderToExport)
        txtTrulyMailEmailAddress.Text = AppSettings.MessageExportTrulyMailFakeAddress
        txtDataPath.Text = AppSettings.MessageExportFolder
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        If chkIncludeTrulyMailMessages.Checked OrElse chkIncludeAllRecipients.Checked Then
            If Not IsValidEmailAddress(txtTrulyMailEmailAddress.Text) Then
                ShowMessageBoxError("If you are exporting TrulyMail contacts, you must must include a 'fake' email address for them." & _
                                    Environment.NewLine & Environment.NewLine & _
                                    "This is because email messages require email address but TrulyMail contacts do not have email addresses.")
                Exit Sub
            End If
        End If

        If Not chkIncludeEmail.Checked AndAlso Not chkIncludeTrulyMailMessages.Checked Then
            ShowMessageBoxError("You have selected not to export email messages or TrulyMail messages." & _
                                Environment.NewLine & Environment.NewLine & _
                                "Setup this way, there is nothing to export.")
            Exit Sub
        End If

        If Not System.IO.Directory.Exists(txtDataPath.Text) Then
            ShowMessageBoxError("Your chosen 'Path to store exported messages' does not exist." & _
                                Environment.NewLine & Environment.NewLine & _
                                "Please select a new path.")
            Exit Sub
        End If

        AppSettings.MessageExportFolder = txtDataPath.Text
        If IsValidEmailAddress(txtTrulyMailEmailAddress.Text) Then
            AppSettings.MessageExportTrulyMailFakeAddress = txtTrulyMailEmailAddress.Text
        End If
        ExportMessages()
    End Sub
    Private Sub ExportMessages()
        '-- Select messages to export
        m_boolCancel = False
        btnImport.Enabled = False
        btnCancel.Enabled = True

        Dim strTopPath As String = m_strFolderToExport
        Dim files() As String

        If strTopPath.ToLower = MessageStoreRootPath.ToLower Then
            files = System.IO.Directory.GetFiles(strTopPath, "*" & MESSAGE_FILENAME_EXTENSION, IO.SearchOption.AllDirectories)
        Else
            If chkIncludeSubFolders.Checked Then
                files = System.IO.Directory.GetFiles(strTopPath, "*" & MESSAGE_FILENAME_EXTENSION, IO.SearchOption.AllDirectories)
            Else
                files = System.IO.Directory.GetFiles(strTopPath, "*" & MESSAGE_FILENAME_EXTENSION, IO.SearchOption.TopDirectoryOnly)
            End If
        End If

        If files.Length = 0 Then
            ShowMessageBox("No messages found to export.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            lblMessagesProcessed.Visible = False
            lblMessagesProcessedCaption.Visible = False
            lblMessagesExported.Visible = False
            lblMessagesExportedCaption.Visible = False
            ProgressBar1.Visible = False
            Exit Sub
        End If

        '-- Loop through messages and export to .eml format
        Dim strDestination As String
        Const EML_FILENAME_EXTENSION As String = ".eml"
        Dim boolIsEmail As Boolean
        Dim boolIsTrulyMail As Boolean
        Dim strTestDestinationFilename As String
        Dim boolExport As Boolean

        '-- Load once for export process
        Dim strLicense As String = My.Resources.aspnetemail_xml_lic
        aspNetEmail.EmailMessage.LoadLicenseString(strLicense)

        Dim intProcessedCounter, intExportCounter As Integer
        lblMessagesProcessed.Text = "0"
        lblMessagesProcessed.Visible = True
        lblMessagesProcessedCaption.Visible = True
        lblMessagesExported.Visible = True
        lblMessagesExportedCaption.Visible = True
        ProgressBar1.Visible = True
        ProgressBar1.Maximum = files.Length
        ProgressBar1.Value = 0

        For Each strFilename As String In files
            '-- reset 
            boolIsEmail = False
            boolIsTrulyMail = False
            boolExport = False

            Dim tm As TrulyMailMessage = New TrulyMailMessage(strFilename)
            For Each recip As RecipientEntry In tm.Recipients
                If recip.ContactType = AddressBookEntryType.Email Then
                    boolIsEmail = True
                ElseIf recip.ContactType = AddressBookEntryType.TrulyMail Then
                    boolIsTrulyMail = True
                End If
            Next

            If chkIncludeAllRecipients.Checked Then
                boolExport = True
            Else
                If chkIncludeEmail.Checked AndAlso boolIsEmail Then
                    boolExport = True
                End If
                If chkIncludeTrulyMailMessages.Checked AndAlso boolIsTrulyMail Then
                    boolExport = True
                End If
            End If

            If boolExport Then
                If rbtnFilenameGUID.Checked Then
                    '-- Use existing guid filename for new filename, but change extension to .eml
                    strDestination = QualifyPath(txtDataPath.Text) & strFilename.Substring(strTopPath.Length)
                    strDestination = strDestination.Substring(0, strDestination.Length - MESSAGE_FILENAME_EXTENSION.Length) & EML_FILENAME_EXTENSION
                Else
                    Dim strNameOfFile As String = MakeFilenameLegal(tm.Subject)
                    Dim strSubject As String = MakeFilenameLegal(tm.Subject)

                    strDestination = System.IO.Path.GetDirectoryName(tm.Filename)
                    strDestination = strDestination.Replace(MessageStoreRootPath, QualifyPath(txtDataPath.Text))
                    strTestDestinationFilename = System.IO.Path.Combine(strDestination, strNameOfFile) & EML_FILENAME_EXTENSION
                    If System.IO.File.Exists(strTestDestinationFilename) Then
                        strSubject &= "_"
                        Do While System.IO.File.Exists(strTestDestinationFilename)
                            strSubject &= GenerateAlphanumericString(1)
                            strTestDestinationFilename = System.IO.Path.Combine(strDestination, strSubject) & EML_FILENAME_EXTENSION
                        Loop
                    End If
                    strDestination = strTestDestinationFilename
                End If


                If tm.MessageType = MessageType.Communication OrElse tm.MessageType = MessageType.Draft Then
                    If chkIncludeTrulyMailMessages.Checked OrElse chkIncludeAllRecipients.Checked Then
                        If ConvertTrulyMailMessageToEMLFile(tm, strDestination, txtTrulyMailEmailAddress.Text) Then
                            intExportCounter += 1
                        End If
                    Else
                        If ConvertTrulyMailMessageToEMLFile(tm, strDestination, String.Empty) Then
                            intExportCounter += 1
                        End If
                    End If
                End If
            Else
                Application.DoEvents()
            End If
            intProcessedCounter += 1
            ProgressBar1.Value = intProcessedCounter
            lblMessagesProcessed.Text = intProcessedCounter.ToString("#,##0")
            lblMessagesExported.Text = intExportCounter.ToString("#,##0")
            Application.DoEvents()
            If m_boolCancel Then
                Exit For
            End If
        Next

        btnImport.Enabled = True
        btnCancel.Enabled = False
    End Sub
    Private Sub SetPathLabel(ByVal fullPath As String)
        Const CHANGE As String = " change"
        Dim strNewPath As String
        If UnQualifyPath(MessageStoreRootPath).Length = UnQualifyPath(fullPath).Length Then
            strNewPath = "All Folders" & CHANGE
        Else
            strNewPath = UnQualifyPath(fullPath.Substring(MessageStoreRootPath.Length)) & CHANGE
            Dim intReduction As Integer
            Dim strBasePath As String = UnQualifyPath(fullPath.Substring(MessageStoreRootPath.Length))
            llblChangePage.Text = strNewPath
            Do Until llblChangePage.Right <= pnlFilenameMethod.Right
                intReduction += 1
                strNewPath = strBasePath.Substring(0, strBasePath.Length - intReduction) & "..." & CHANGE
                llblChangePage.Text = strNewPath
            Loop
        End If
        llblChangePage.Text = strNewPath
        llblChangePage.LinkArea = New LinkArea(strNewPath.Length - CHANGE.Length + 1, CHANGE.Length)
        ToolTip1.SetToolTip(llblChangePage, fullPath)
    End Sub
    Private Sub llblChangePageInbox_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblChangePage.LinkClicked
        Try
            Dim fbd As New FolderBrowserDialogTM()
            fbd.ShowAllFolders = True
            fbd.SelectedPath = m_strFolderToExport
            fbd.ShowNewFolderButton = False
            fbd.Description = "Select folder to export"
            If fbd.ShowDialog(Me) = DialogResult.OK Then
                SetPathLabel(fbd.SelectedPath)
                m_strFolderToExport = fbd.SelectedPath
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error changing the folder for export. " & CONTACT_TRULYMAIL_MESSAGE)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        m_boolCancel = True
    End Sub

    Private Sub chkIncludeAllRecipients_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncludeAllRecipients.CheckedChanged
        chkIncludeEmail.Enabled = Not chkIncludeAllRecipients.Checked
        chkIncludeTrulyMailMessages.Enabled = Not chkIncludeAllRecipients.Checked
        txtTrulyMailEmailAddress.Enabled = chkIncludeAllRecipients.Checked OrElse chkIncludeTrulyMailMessages.Checked
    End Sub
End Class