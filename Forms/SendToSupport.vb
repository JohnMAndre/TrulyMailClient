Public Class SendToSupport

    Private m_boolRecheckMessageSize As Boolean = True
    Private m_lngMessageSize As Long
    Private m_lngAttachmentSize As Long
    Private m_lngAddressBookSize As Long
    Private m_lngLogFileSize As Long
    Private m_lngSettingsSize As Long
    Private m_lngRemindersSize As Long
    Private m_strMessageTopFolder As String = MessageStoreRootPath


    Private Sub pbLogFileInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbLogFileInfo.Click
        ShowMessageBox("Your log file contains a log of TrulyMail activities. If you experience problems, you should always send this." & _
                       Environment.NewLine & Environment.NewLine & _
                       "If the log file checkbox is disabled then you have no errors logged. On the main TrulyMail window go to Tools->Options->Troubleshooting to enable logging.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub pbSettingsFileInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSettingsFileInfo.Click
        ShowMessageBox("Your settings file contains all of your TrulyMail settings. If you have saved passwords, they are encrypted within this file.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub pbMessagesInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowMessageBox("This will send all of your messages but not your attachments.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub pbAttachmentsInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowMessageBox("This will send all of the attachments. If you send this, you should send your messages also.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub pbAddressBookInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAddressBookInfo.Click
        ShowMessageBox("This contains your address book including your TrulyMail and email contacts.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub SendToSupport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '-- Show user size of each option, disable options which cannot be sent
        Dim strFilename As String
        strFilename = AppSettings.LogFileLocation
        If System.IO.File.Exists(strFilename) Then
            chkLogFile.Enabled = True
            m_lngLogFileSize = FileLen(strFilename)
            lblLogFile.Text = "Size: " & FormatDataSizeString(m_lngLogFileSize)
            chkLogFile.Checked = True
        Else
            chkLogFile.Enabled = False
            lblLogFile.Text = String.Empty
            chkLogFile.Checked = False
        End If

        If AddressBookExists() Then
            chkAddressBook.Enabled = True
            chkAddressBook.Checked = False
            m_lngAddressBookSize = FileLen(GetAddressBookPath())
        Else
            chkAddressBook.Enabled = False
            chkAddressBook.Checked = False
        End If

        strFilename = AppSettings.GetSettingsFilename()
        If System.IO.File.Exists(strFilename) Then
            chkSettings.Enabled = True
            chkSettings.Checked = False
            m_lngSettingsSize = FileLen(strFilename)
        Else
            chkSettings.Enabled = False
            chkSettings.Checked = False
        End If

        Dim files() As String = System.IO.Directory.GetFiles(ProfileRootPath, "Reminders.*xml", IO.SearchOption.TopDirectoryOnly)
        If files.Length = 0 Then
            chkReminders.Enabled = False
            chkReminders.Checked = False
        Else
            chkReminders.Enabled = True
            chkReminders.Checked = False
            For Each strFilename In files
                m_lngRemindersSize += FileLen(strFilename)
            Next
        End If

        SetSendButtonState()
        UpdateTotalSize()
    End Sub

    Private Sub CalculateMessageSize()
        Dim lstMessages, lstAttachments As List(Of FileDetails)
        Dim messageLoader As New FileListLoader(REGEX_MESSAGE_FILENAME)
        Dim attachmentLoader As New FileListLoader(REGEX_ALL_FILES)
        lstMessages = messageLoader.GetFilesInPath(m_strMessageTopFolder, True)

        m_lngAttachmentSize = 0
        m_lngMessageSize = 0

        For Each fd As FileDetails In lstMessages
            m_lngMessageSize += FileLen(fd.FullName)

            '-- Must also calculate attachment size
            lstAttachments = attachmentLoader.GetFilesInPath(AttachmentsRootPath & System.IO.Path.GetFileNameWithoutExtension(fd.Name), True)
            For Each fdAttachment As FileDetails In lstAttachments
                m_lngAttachmentSize += FileLen(fdAttachment.FullName)
            Next

            Application.DoEvents()
        Next

        m_boolRecheckMessageSize = False
    End Sub

    Private Sub bgMessageSize_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgMessageSize.DoWork
        CalculateMessageSize()
    End Sub

    Private Sub chkLogFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLogFile.CheckedChanged
        SetSendButtonState()
        UpdateTotalSize()
    End Sub
    Private Sub SetSendButtonState()
        If chkLogFile.Checked OrElse _
            chkSettings.Checked OrElse _
            chkAddressBook.Checked OrElse _
            chkReminders.Checked Then

            btnSend.Enabled = True
        Else
            btnSend.Enabled = False
        End If
    End Sub

    Private Sub chkSettings_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSettings.CheckedChanged
        SetSendButtonState()
        chkRemovePasswordsFromSettings.Enabled = chkSettings.Checked '-- Only enable if send settings is checked
        UpdateTotalSize()
    End Sub

    Private Sub chkAttachments_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UpdateTotalSize()
        SetSendButtonState()
    End Sub

    Private Sub chkAddressBook_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddressBook.CheckedChanged
        SetSendButtonState()
        UpdateTotalSize()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub
    Private Sub UpdateTotalSize()
        Dim lngTotalSize As Long

        If chkLogFile.Checked Then
            lngTotalSize += m_lngLogFileSize
        End If
        If chkAddressBook.Checked Then
            lngTotalSize += m_lngAddressBookSize
        End If
        If chkSettings.Checked Then
            lngTotalSize += m_lngSettingsSize
        End If
        If chkReminders.Checked Then
            lngTotalSize += m_lngRemindersSize
        End If

        btnSend.Enabled = lngTotalSize > 0
    End Sub
    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Dim boolSubmitted As Boolean

        Try
            btnSend.Enabled = False

            '-- Zip up the data
            Dim strTempZipFilename As String = GetTempFilename(".zip")
            Dim zip As New Ionic.Zip.ZipFile()

            If chkLogFile.Checked Then
                zip.AddFile(AppSettings.LogFileLocation, "Data\Log")
            End If
            If chkAddressBook.Checked Then
                zip.AddFile(GetAddressBookPath, "Data\Profile")
            End If
            If chkSettings.Checked Then
                Dim strSettingsContents As String = AppSettings.GetXMLOfAllSettings(chkRemovePasswordsFromSettings.Checked).OuterXml
                zip.AddEntry("Data\Settings\user.config", strSettingsContents)
            End If

            If chkReminders.Checked Then
                Dim files() As String = System.IO.Directory.GetFiles(ProfileRootPath, "Reminders.*xml", IO.SearchOption.TopDirectoryOnly)
                For Each strFilename As String In files
                    zip.AddFile(strFilename, "Data\Profile")
                Next
            End If

            zip.Save(strTempZipFilename)

            '-- Now compose message
            Dim frm As New NewMessage()
            frm.Show()
            frm.AddAttachment(strTempZipFilename)
            frm.AddRecipient("TrulyMail Support", "support@trulymail.com")
            frm.Subject = "Data from user: "
            frm.Body = "Please include any information you think will help us better understand your situation."

            If chkLogFile.Checked Then
                '-- delete existing log file
                DeleteLocalFile(AppSettings.LogFileLocation)
            End If

            Me.Hide()

            frm.BringToFront()

            Me.Close()


        Catch ex As Exception
            Log(ex)
            If boolSubmitted Then
                'ShowMessageBox("Your data was sent to TrulyMail Support.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Close()
            Else
                ShowMessageBox("There was an error (" & ex.Message & ") sending the selected information to TrulyMail Support. Please try again later or use the TrulyMail website.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        End Try
    End Sub

    Private Sub llblOpenLogfile_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblShowLogfile.LinkClicked
        Try
            Dim strFilename As String = AppSettings.LogFileLocation
            If System.IO.File.Exists(strFilename) Then
                Dim psi As New System.Diagnostics.ProcessStartInfo("explorer.exe", "/select, """ & strFilename & """")
                System.Diagnostics.Process.Start(psi) '"explorer.exe /select, ""C:\TrulyMailPortableJMA\Data\Profile\Attachments\0b4d177b-a901-427b-b5fb-d880b6160b94\D02EE404.txt""")
            Else
                ShowMessageBox("The log file does not exist and is only created when there are errors to be logged.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBox("There was an error: " & ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    Private Sub pbReminderInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbReminderInfo.Click
        ShowMessageBox("This contains your reminder data. Normally, you would only send this if you're having problems with your reminders.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub chkReminders_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReminders.CheckedChanged
        SetSendButtonState()
        UpdateTotalSize()
    End Sub
   

    
    Private Sub chkRemovePasswordsFromSettings_CheckedChanged(sender As Object, e As EventArgs) Handles chkRemovePasswordsFromSettings.CheckedChanged
        If Not chkRemovePasswordsFromSettings.Checked Then
            ShowMessageBox("We will only ask for your passwords if we need to connect to your email server (very rare).", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub llblOpenLogFile_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblOpenLogFile.LinkClicked
        Try
            Dim strFilename As String = AppSettings.LogFileLocation
            If System.IO.File.Exists(strFilename) Then
                Dim psi As New System.Diagnostics.ProcessStartInfo(strFilename)
                System.Diagnostics.Process.Start(psi)
            Else
                ShowMessageBox("The log file does not exist and is only created when there are errors to be logged.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBox("There was an error: " & ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
End Class