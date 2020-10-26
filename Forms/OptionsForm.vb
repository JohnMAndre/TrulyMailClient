Friend Class OptionsForm
    Private _usernameDirty As Boolean = False
    Private _passwordDirty As Boolean = False
    Private _addressDirty As Boolean = False
    Private _emailAddressDirty As Boolean = False
    Private _fullNameDirty As Boolean = False
    Private _autoAcceptInviteDirty As Boolean = False

    Private _noticeMessageDelayDirty As Boolean = False
    Private _noticeMessageToDirty As Boolean = False
    Private _noticeMessageSubjectDirty As Boolean = False
    Private _noticeMessageBodyDirty As Boolean = False

    Private _loading As Boolean = True
    Private _cancelLoading As Boolean = True '-- true means auto-close form when it shows

    Private Sub OptionsForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.WindowState <> FormWindowState.Minimized Then
            AppSettings.OptionsFormWindowState = Me.WindowState
        End If
    End Sub

    Private Sub OptionsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            '-- Encryption
            nudPromptToRecreateEncryptionKeysDays.Value = AppSettings.PromptToRecreateEncryptionKeysDays
            nudPromptToRecreateEncryptionKeysMessages.Value = AppSettings.PromptToRecreateEncryptionKeysMessages
            If AppSettings.EncryptionVersion < cboEncryptionVersion.Items.Count Then
                cboEncryptionVersion.SelectedIndex = AppSettings.EncryptionVersion
            Else
                '-- Something's off, reset encryption to version 1
                AppSettings.EncryptionVersion = 1
                cboEncryptionVersion.SelectedIndex = 1
            End If


            '-- send/receive
            chkAutoSendReceive.Checked = AppSettings.AutoSendReceive
            txtSendReceiveEveryXMinutes.Text = AppSettings.AutoSendReceiveInterval.ToString()
            chkSendReceiveOnStartup.Checked = AppSettings.SendAndReceiveOnStartup
            txtSendNowMinutes.Text = AppSettings.SendNowDelay
            chkSendNowOnExit.Checked = AppSettings.SendNowOnExit

            chkRSSAutoCheck.Checked = AppSettings.RSSAutoCheck
            chkRSSAutoCheckOnStartup.Checked = AppSettings.RSSAutoCheckAtStartup
            txtRSSAutoCheckMinutes.Text = AppSettings.RSSAutoCheckInterval.ToString()

            nudIntraEmailSendDelay.Value = AppSettings.IntraEmailSendDelay
            chkAutomaticallyTransmitOnSend.Checked = AppSettings.AutomaticallyTransmitOnSend

            '-- composing
            cboDictionary.Items.Clear()
            Dim files() As String = GetDictionaries()
            Dim intCounter As Integer = 0
            For Each strFilename As String In files
                Dim strDictName As String = System.IO.Path.GetFileNameWithoutExtension(strFilename)
                cboDictionary.Items.Add(strDictName)
                If strDictName.ToLower() = System.IO.Path.GetFileNameWithoutExtension(AppSettings.DictionaryFilename).ToLower() Then
                    cboDictionary.SelectedIndex = intCounter
                End If
                intCounter += 1
            Next

            chkAutoSpellCheckBeforeSend.Checked = AppSettings.SpellCheckBeforeSend
            chkSpellCheckSubject.Checked = AppSettings.SpellCheckSubject
            chkKeepSentMessages.Checked = AppSettings.KeepSentMessages
            chkAutoSaveDrafts.Checked = AppSettings.AutoSaveDrafts
            nudAutoSaveDraft.Value = AppSettings.AutoSaveDraftsMinutes
            Dim intIndex As Integer = 0
            For Each fam As FontFamily In FontFamily.Families
                cboDefaultNewMessageFontName.Items.Add(fam.Name)
                If fam.Name.ToLower() = AppSettings.DefaultNewMessageFontName.ToLower() Then
                    intIndex = cboDefaultNewMessageFontName.Items.Count - 1
                End If
            Next
            If intIndex < cboDefaultNewMessageFontName.Items.Count Then
                cboDefaultNewMessageFontName.SelectedIndex = intIndex
            End If

            Try
                picNewMessageBackground.BackColor = AppSettings.NewMessageBackgroundColor
            Catch ex As Exception
                '-- Do nothing, assume newmessagecolor is set to transparent or something else which cannot be set to .backcolor for textbox
            End Try

            If AppSettings.DefaultNewMessageFontSize > 7 Then
                nudDefaultNewMessageFontSize.Value = 7
            ElseIf AppSettings.DefaultNewMessageFontSize < 1 Then
                nudDefaultNewMessageFontSize.Value = 1
            Else
                nudDefaultNewMessageFontSize.Value = AppSettings.DefaultNewMessageFontSize
            End If

            chkSingleSpaceEditor.Checked = AppSettings.SingleSpaceEditor
            chkShowEditorSpacingStatus.Checked = AppSettings.ShowEditorSpacingStatus
            Select Case AppSettings.UseFallbackModeWhen
                Case UseFallbackModeEnum.Always
                    rdoFallbackAlways.Checked = True
                Case UseFallbackModeEnum.Never
                    rdoFallbackNever.Checked = True
                Case UseFallbackModeEnum.UnderWine
                    rdoFallbackUnderWine.Checked = True
            End Select

            UpdateSampleNewMessage()
            nudSendDelayMinutes.Value = AppSettings.SendDelayInMinutes


            '-- experience
            chkToolBarsIncludeText.Checked = AppSettings.ToolBarsShowText
            chkUseLargeToolbarIcons.Checked = AppSettings.LargeToolbarIcons
            chkMinimizeToTray.Checked = AppSettings.MinimizeToTray
            chkShowNoticeForNewMessages.Checked = AppSettings.ShowNoticeForNewMessages
            PopulateNewMessageSounds()
            nudNewMessageNotifyStaysOpen.Value = AppSettings.NoticeForNewMessagesSecondsOpen

            chkAutoEmptyTrash.Checked = AppSettings.AutoEmptyTrash
            nudTrashDaysToRetain.Value = AppSettings.TrashDaysToRetain
            chkEmptyTrashOnExit.Checked = AppSettings.EmptyTrashOnExit

            chkShowReadingZoomBar.Checked = AppSettings.ShowReadingZoomBar

            txtDefaultSubject.Text = AppSettings.DefaultMessageSubject
            cboReplyPostingMode.SelectedIndex = AppSettings.ReplyPostingMode
            nudDelayWhenCannotSend.Value = AppSettings.DelayMinutesWhenCannotSend
            chkUseLargeSendReceiveButton.Checked = AppSettings.UseLargeAllAccountDropDown
            chkUseLargeSendReceiveButton.Enabled = AppSettings.POPProfiles.Count > 0 '-- only enable the checkbox if there are POP accounts
            chkRemoveDiacriticsOnReceive.Checked = AppSettings.RemoveDiacriticsWhenReceiving
            chkPreviewPanePlainText.Checked = AppSettings.PreviewPaneToReadAsPlainText

            cboDateFormat.Items.Clear()
            Dim dt As New Date(2011, 12, 31, 19, 42, 11)
            For Each strFormat As String In DateFormats
                cboDateFormat.Items.Add(dt.ToString(strFormat))
            Next
            If AppSettings.DateFormat < cboDateFormat.Items.Count Then
                cboDateFormat.SelectedIndex = AppSettings.DateFormat
            End If
            chkHideOutboxCountPastToday.Checked = AppSettings.HideOutboxCountPastToday

            '-- Message List
            LoadMessageTags()
            nudLoadMessagePreviewDelay.Value = AppSettings.MessagePreviewLoadDelay
            chkMaintainMessageZoom.Checked = AppSettings.MaintainMessageZoom
            lblAlternatingRowColor.BackColor = AppSettings.MessageListAlternatingRowColor
            chkAutoSizeMessageListColumns.Checked = AppSettings.AutoSizeColumnsMessageList

            '-- Email
            chkEmailAutoAddRecipientsToAddressBook.Checked = AppSettings.EmailAutoAddRecipientsOnSend
            If AppSettings.EmailShowSenderAsSent Then
                rbtnEmailShowSenderAsSent.Checked = True
            Else
                rbtnEmailShowSenderAsAddressBook.Checked = True
            End If
            chkAutoReturnReceipt.Checked = AppSettings.EmailRequestReturnReceipt
            chkBlockRemoteImages.Checked = AppSettings.BlockRemoteImages
            chkNeverProcessEmailReturnReceipts.Checked = AppSettings.DoNotProcessEmailReceipts
            If AppSettings.DefaultEmailEncryption < cboDefaultEmailEncryption.Items.Count Then
                cboDefaultEmailEncryption.SelectedIndex = AppSettings.DefaultEmailEncryption
            Else
                cboDefaultEmailEncryption.SelectedIndex = 0
            End If
            chkEmailAutoAddRecipientsTieSMTP.Checked = AppSettings.EmailAutoAddRecipientsTieSMTP
            chkReplyToPlainTextIsPlainText.Checked = AppSettings.ReplyToPlainTextIsPlainText
            lblFontForPlainText.Text = AppSettings.FontForPlainText.Name & ", " & AppSettings.FontForPlainText.Size
            chkAutoZipEmailAttachments.Checked = AppSettings.AutoZipEmailAttachments

            '-- Troubleshooting
            txtLogFileLocation.Text = AppSettings.LogFileLocation
            nudLoggingErrorDisplayFrequency.Value = AppSettings.DisplayErrorIntervalSeconds



            If AppSettings.PortableProfile Then
                txtLogFileLocation.ReadOnly = True
                btnBrowseForLogFile.Visible = False
                txtLogFileLocation.Width += btnBrowseForLogFile.Width
                lblPortableLogFileNotice.Visible = True
            End If
            chkEnableLogging.Checked = AppSettings.EnableLogging
            chkEnableVerboseLogging.Checked = AppSettings.EnableVerboseLogging
            grpLogging.Enabled = AppSettings.EnableLogging

            '-- Notes
            chkAddNoteForProcessingRuleAction.Checked = AppSettings.AddNoteForProcessingRuleAction
            chkAddNoteWhenChangingSubject.Checked = AppSettings.AddNoteWhenChangingSubject
            chkAddNoteWhenSendingReturnReceipt.Checked = AppSettings.AddNoteWhenSendingReturnReceipt


            _addressDirty = False
            _emailAddressDirty = False
            _passwordDirty = False
            _usernameDirty = False
            _fullNameDirty = False
            _autoAcceptInviteDirty = False
            _noticeMessageDelayDirty = False
            _noticeMessageToDirty = False
            _noticeMessageSubjectDirty = False
            _noticeMessageBodyDirty = False


            btnOK.Enabled = False

            If AppSettings.OptionsFormWindowState <> FormWindowState.Minimized Then
                Me.WindowState = AppSettings.OptionsFormWindowState
            End If

            _loading = False
            _cancelLoading = False

        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error loading your settings. " & CONTACT_TRULYMAIL_MESSAGE)
        End Try
    End Sub
    Private Sub UpdateSampleNewMessage()
        If cboDefaultNewMessageFontName.SelectedIndex > -1 Then
            Try
                txtSampleNewMessage.BackColor = picNewMessageBackground.BackColor
            Catch ex As Exception
                'Log(ex) --- no need to log because this is triggered by setting the background to a transparent color
                txtSampleNewMessage.BackColor = Color.White
            End Try
            Dim defaultFontFamily As FontFamily

            For Each fam As FontFamily In FontFamily.Families
                cboDefaultNewMessageFontName.Items.Add(fam.Name)
                If fam.Name.ToLower() = cboDefaultNewMessageFontName.Items(cboDefaultNewMessageFontName.SelectedIndex).ToLower() Then
                    defaultFontFamily = fam
                    Exit For
                End If
            Next

            Dim intFontSize As Integer
            Select Case nudDefaultNewMessageFontSize.Value
                Case Is < 1
                    intFontSize = 8
                Case 1
                    intFontSize = 8
                Case 2
                    intFontSize = 10
                Case 3
                    intFontSize = 12
                Case 4
                    intFontSize = 14
                Case 5
                    intFontSize = 16
                Case 6
                    intFontSize = 22
                Case 7
                    intFontSize = 36
                Case Else
                    intFontSize = 36
            End Select

            If defaultFontFamily IsNot Nothing Then
                Dim fnt As Font = New Font(defaultFontFamily, intFontSize, FontStyle.Regular)
                txtSampleNewMessage.Font = fnt
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        '-- roll back any changes to the krypton look and feel
        Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        '-- Encryption
        AppSettings.PromptToRecreateEncryptionKeysDays = ConvertToInt32(nudPromptToRecreateEncryptionKeysDays.Value, 90)
        AppSettings.PromptToRecreateEncryptionKeysMessages = ConvertToInt32(nudPromptToRecreateEncryptionKeysMessages.Value, 30)
        AppSettings.EncryptionVersion = cboEncryptionVersion.SelectedIndex


        '-- send/receive
        AppSettings.AutoSendReceive = chkAutoSendReceive.Checked
        If IsNumeric(txtSendReceiveEveryXMinutes.Text) Then
            AppSettings.AutoSendReceiveInterval = Convert.ToInt32(txtSendReceiveEveryXMinutes.Text)
        End If
        AppSettings.SendAndReceiveOnStartup = chkSendReceiveOnStartup.Checked
        AppSettings.SendNowDelay = Convert.ToInt32(txtSendNowMinutes.Text)
        AppSettings.SendNowOnExit = chkSendNowOnExit.Checked

        AppSettings.RSSAutoCheck = chkRSSAutoCheck.Checked
        AppSettings.RSSAutoCheckAtStartup = chkRSSAutoCheckOnStartup.Checked
        AppSettings.RSSAutoCheckInterval = ConvertToInt32(txtRSSAutoCheckMinutes.Text, 100)

        AppSettings.IntraEmailSendDelay = nudIntraEmailSendDelay.Value
        AppSettings.AutomaticallyTransmitOnSend = chkAutomaticallyTransmitOnSend.Checked

        '-- compose
        Dim boolSkipDictionaryLogic As Boolean
        If cboDictionary.SelectedIndex < 0 Then
            If cboDictionary.Items.Count = 0 Then
                ShowMessageBoxError("TrulyMail cannot find any dictionary files. Please re-install TrulyMail to correct this problem.")
                boolSkipDictionaryLogic = True
            Else
                cboDictionary.SelectedIndex = 0 '-- select first item
            End If
        End If
        If Not boolSkipDictionaryLogic Then
            AppSettings.DictionaryFilename = cboDictionary.Items(cboDictionary.SelectedIndex) & DICTIONARY_FILENAME_EXTENSION
        End If
        AppSettings.SpellCheckBeforeSend = chkAutoSpellCheckBeforeSend.Checked
        AppSettings.SpellCheckSubject = chkSpellCheckSubject.Checked
        AppSettings.KeepSentMessages = chkKeepSentMessages.Checked
        AppSettings.EncryptionVersion = cboEncryptionVersion.SelectedIndex
        AppSettings.AutoSaveDrafts = chkAutoSaveDrafts.Checked
        AppSettings.AutoSaveDraftsMinutes = nudAutoSaveDraft.Value
        AppSettings.DefaultNewMessageFontSize = nudDefaultNewMessageFontSize.Value
        AppSettings.DefaultNewMessageFontName = cboDefaultNewMessageFontName.Items(cboDefaultNewMessageFontName.SelectedIndex)
        AppSettings.NewMessageBackgroundColor = picNewMessageBackground.BackColor
        AppSettings.SingleSpaceEditor = chkSingleSpaceEditor.Checked
        AppSettings.ShowEditorSpacingStatus = chkShowEditorSpacingStatus.Checked

        If rdoFallbackAlways.Checked Then
            AppSettings.UseFallbackModeWhen = UseFallbackModeEnum.Always
        ElseIf rdoFallbackNever.Checked Then
            AppSettings.UseFallbackModeWhen = UseFallbackModeEnum.Never
        Else
            AppSettings.UseFallbackModeWhen = UseFallbackModeEnum.UnderWine
        End If

        AppSettings.SendDelayInMinutes = nudSendDelayMinutes.Value



        '-- experience
        AppSettings.ToolBarsShowText = chkToolBarsIncludeText.Checked
        AppSettings.LargeToolbarIcons = chkUseLargeToolbarIcons.Checked
        AppSettings.MinimizeToTray = chkMinimizeToTray.Checked
        AppSettings.ShowNoticeForNewMessages = chkShowNoticeForNewMessages.Checked
        AppSettings.NoticeForNewMessagesSecondsOpen = nudNewMessageNotifyStaysOpen.Value
        AppSettings.DateFormat = cboDateFormat.SelectedIndex
        AppSettings.HideOutboxCountPastToday = chkHideOutboxCountPastToday.Checked
        AppSettings.RemoveDiacriticsWhenReceiving = chkRemoveDiacriticsOnReceive.Checked
        AppSettings.PreviewPaneToReadAsPlainText = chkPreviewPanePlainText.Checked

        '-- notify sounds
        If chkPlaySoundNewMessages.Checked Then
            Select Case cboNewMessageNoticeSound.SelectedIndex
                Case 0
                    AppSettings.NewMessageNotifySound = NOTIFY_SOUND_DEFAULT
                Case cboNewMessageNoticeSound.Items.Count - 1
                    '-- should never get here, so convert to default sound
                    '   This is the brose option
                    AppSettings.NewMessageNotifySound = NOTIFY_SOUND_DEFAULT
                Case Else
                    Dim snd As NotifySound = CType(cboNewMessageNoticeSound.Items(cboNewMessageNoticeSound.SelectedIndex), NotifySound)
                    If snd.FullPath.StartsWith(MySoundsPath) Then
                        AppSettings.NewMessageNotifySound = NOTIFY_SOUND_USERSOUNDS & "\" & snd.Filename
                    Else
                        AppSettings.NewMessageNotifySound = NOTIFY_SOUND_APPSOUNDS & "\" & snd.Filename
                    End If
            End Select
        Else
            AppSettings.NewMessageNotifySound = String.Empty
        End If

        AppSettings.AutoEmptyTrash = chkAutoEmptyTrash.Checked
        AppSettings.TrashDaysToRetain = nudTrashDaysToRetain.Value
        AppSettings.EmptyTrashOnExit = chkEmptyTrashOnExit.Checked

        AppSettings.ShowReadingZoomBar = chkShowReadingZoomBar.Checked

        AppSettings.DefaultMessageSubject = txtDefaultSubject.Text
        AppSettings.ReplyPostingMode = cboReplyPostingMode.SelectedIndex
        AppSettings.DelayMinutesWhenCannotSend = nudDelayWhenCannotSend.Value
        AppSettings.UseLargeAllAccountDropDown = chkUseLargeSendReceiveButton.Checked


        '-- Message List
        AppSettings.MessagePreviewLoadDelay = nudLoadMessagePreviewDelay.Value
        AppSettings.MaintainMessageZoom = chkMaintainMessageZoom.Checked
        AppSettings.MessageListAlternatingRowColor = lblAlternatingRowColor.BackColor
        AppSettings.AutoSizeColumnsMessageList = chkAutoSizeMessageListColumns.Checked

        '-- Email
        AppSettings.EmailAutoAddRecipientsOnSend = chkEmailAutoAddRecipientsToAddressBook.Checked
        AppSettings.EmailShowSenderAsSent = rbtnEmailShowSenderAsSent.Checked
        AppSettings.EmailRequestReturnReceipt = chkAutoReturnReceipt.Checked
        AppSettings.BlockRemoteImages = chkBlockRemoteImages.Checked
        AppSettings.DoNotProcessEmailReceipts = chkNeverProcessEmailReturnReceipts.Checked
        AppSettings.DefaultEmailEncryption = cboDefaultEmailEncryption.SelectedIndex
        AppSettings.EmailAutoAddRecipientsTieSMTP = chkEmailAutoAddRecipientsTieSMTP.Checked
        AppSettings.AutoZipEmailAttachments = chkAutoZipEmailAttachments.Checked
        AppSettings.ReplyToPlainTextIsPlainText = chkReplyToPlainTextIsPlainText.Checked



        '-- Troubleshooting
        Dim boolOKToClose As Boolean = True
        If txtLogFileLocation.Text.Trim.Length > 0 Then
            If FileIsWritable(txtLogFileLocation.Text) Then
                AppSettings.LogFileLocation = txtLogFileLocation.Text
            Else
                MessageBox.Show("The log file chosen cannot be written to. Please select another location.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                boolOKToClose = False
            End If
        Else
            AppSettings.LogFileLocation = String.Empty
        End If
        AppSettings.EnableLogging = chkEnableLogging.Checked
        AppSettings.EnableVerboseLogging = chkEnableVerboseLogging.Checked

        AppSettings.DisplayErrorIntervalSeconds = nudLoggingErrorDisplayFrequency.Value

        '-- Notes
        AppSettings.AddNoteForProcessingRuleAction = chkAddNoteForProcessingRuleAction.Checked
        AppSettings.AddNoteWhenChangingSubject = chkAddNoteWhenChangingSubject.Checked
        AppSettings.AddNoteWhenSendingReturnReceipt = chkAddNoteWhenSendingReturnReceipt.Checked



        AppSettings.Save()

        If boolOKToClose Then
            Close()
        End If
    End Sub

    Private Sub EnsureTextBoxHasOnlyValidCharacters(ByVal txt As TextBox, ByVal name As String, ByVal acceptableChars As String)
        Dim strThisChar As String
        Dim intLastModifiedPosition As Integer = -1
        For intCounter As Integer = 0 To txt.Text.Length - 1
            If intCounter = txt.Text.Length Then
                Exit For
            End If
            strThisChar = txt.Text.Substring(intCounter, 1).ToUpper()
            If acceptableChars.IndexOf(strThisChar) < 0 Then
                MessageBox.Show(strThisChar & " is not an allowable character for " & name & ".", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt.Text = txt.Text.Replace(strThisChar, String.Empty)
                intLastModifiedPosition = intCounter
            End If
        Next

        If intLastModifiedPosition >= 0 Then
            txt.SelectionStart = intLastModifiedPosition
            txt.SelectionLength = 0
        End If
    End Sub

    Private Sub txtSendReceiveEveryXMinutes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSendReceiveEveryXMinutes.TextChanged
        btnOK.Enabled = True
    End Sub

    Private Sub cboDictionary_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDictionary.SelectedIndexChanged
        btnOK.Enabled = True
    End Sub

    Private Sub CheckBok_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoSpellCheckBeforeSend.CheckedChanged, chkHideOutboxCountPastToday.CheckedChanged, chkSendReceiveOnStartup.CheckedChanged, chkAutoSendReceive.CheckedChanged
        btnOK.Enabled = True
    End Sub


    Private Sub pbLogFileInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbLogFileInfo.Click
        ShowMessageBox("Your Log File is where logging information (for errors, etc.) will be stored. That file can be submitted to TrulyMail by looking under the Help Menu." & Environment.NewLine & Environment.NewLine & "This location must be writable.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub btnDeleteCurrentLogFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteCurrentLogFile.Click
        If System.IO.File.Exists(txtLogFileLocation.Text) Then
            If MessageBox.Show("Are you sure you want to delete the log file?" & Environment.NewLine & Environment.NewLine & _
                               txtLogFileLocation.Text, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Try
                    DeleteLocalFile(txtLogFileLocation.Text)
                    MessageBox.Show("The log file has been deleted.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("The log file could NOT be deleted (" & ex.Message & "). You might want to delete it manually.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("There is no file at this location." & Environment.NewLine & Environment.NewLine & "The log file only exists after at least one logged error.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtLogFileLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLogFileLocation.TextChanged
        btnOK.Enabled = True

        btnDeleteCurrentLogFile.Enabled = txtLogFileLocation.Text.Length > 2
    End Sub

    Private Sub btnBrowseForLogFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseForLogFile.Click
        Dim sfd As New SaveFileDialog()
        sfd.OverwritePrompt = False
        sfd.Filter = "All Files (*.*)|*.*"
        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtLogFileLocation.Text = sfd.FileName
        End If
    End Sub

    Private Sub chkUseLargeToolbarIcons_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseLargeToolbarIcons.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkSpellCheckSubject_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSpellCheckSubject.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkAutoSaveDrafts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoSaveDrafts.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub nudAutoSaveDraft_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudAutoSaveDraft.ValueChanged
        btnOK.Enabled = True
    End Sub

    Private Sub txtDefaultSubject_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDefaultSubject.TextChanged
        btnOK.Enabled = True
    End Sub


    Private Sub chkEmailAutoAddRecipientsToAddressBook_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEmailAutoAddRecipientsToAddressBook.CheckedChanged
        btnOK.Enabled = True
        chkEmailAutoAddRecipientsTieSMTP.Enabled = chkEmailAutoAddRecipientsToAddressBook.Checked
    End Sub

    Private Sub rbtnEmailShowSenderAsSent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnEmailShowSenderAsSent.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub rbtnEmailShowSenderAsAddressBook_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnEmailShowSenderAsAddressBook.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub pbAutoSendReceiveTrulyMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAutoSendReceiveTrulyMail.Click
        ShowMessageBox("This area is where you set if you want TrulyMail to automatically send and check for new messages on the TrulyMail server." & _
                       Environment.NewLine & Environment.NewLine & _
                       "This setting for email accounts is handled under Tools->Email Accounts.", _
                       MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub pbSecondThoughtsInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSecondThoughtsInfo.Click
        ShowMessageBox("This area allows you to delay sending your messages. If you often wish you could stop an email from going out just after you send it, set the delay to several minutes." & _
                   Environment.NewLine & Environment.NewLine & _
                   "This setting affects TrulyMail and email accounts. A setting of zero minutes will send messages immediately when you choose Send Now." & _
                   Environment.NewLine & Environment.NewLine & _
                   "You can also choose to automatically send those delayed messages when closing TrulyMail.", _
                   MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub txtSendNowMinutes_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSendNowMinutes.Leave
        If Not IsNumeric(txtSendNowMinutes.Text) OrElse Convert.ToInt32(txtSendNowMinutes.Text) < 0 Then
            ShowMessageBox("Please enter a positive number (0 or higher) for 'Send now means send in ___ minutes.'", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub txtSendNowMinutes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSendNowMinutes.TextChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkSendNowOnExit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSendNowOnExit.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub cboReplyPostingMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReplyPostingMode.SelectedIndexChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkAutoReturnReceipt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoReturnReceipt.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkBlockRemoteImages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBlockRemoteImages.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkEnableLogging_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableLogging.CheckedChanged
        grpLogging.Enabled = chkEnableLogging.Checked
        btnOK.Enabled = True
    End Sub

    Private Sub nudDelayWhenCannotSend_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDelayWhenCannotSend.ValueChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkAutoEmptyTrash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoEmptyTrash.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub nudTrashDaysToRetain_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudTrashDaysToRetain.ValueChanged
        btnOK.Enabled = True
    End Sub


    Private Sub chkNeverProcessEmailReturnReceipts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNeverProcessEmailReturnReceipts.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub cboDefaultNewMessageFontName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDefaultNewMessageFontName.SelectedIndexChanged
        btnOK.Enabled = True
        UpdateSampleNewMessage()
    End Sub

    Private Sub nudDefaultNewMessageFontSize_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDefaultNewMessageFontSize.ValueChanged
        btnOK.Enabled = True
        UpdateSampleNewMessage()
    End Sub

    Private Sub chkCheckingNewVersionIncludesBeta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnOK.Enabled = True
    End Sub

    Private Sub chkSingleSpaceEditor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSingleSpaceEditor.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkShowSendingLimtOnMainWindow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnOK.Enabled = True
    End Sub

    Private Sub chkShowEditorSpacingStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowEditorSpacingStatus.CheckedChanged
        btnOK.Enabled = True
    End Sub
    Private Sub LoadMessageTags()
        lstMessageTags.Items.Clear()
        For Each tag As MessageTag In AppSettings.MessageTags
            lstMessageTags.Items.Add(tag)
        Next
        If lstMessageTags.Items.Count > 0 Then
            lstMessageTags.SelectedIndex = 0
        End If
    End Sub

    Private Sub lstMessageTags_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstMessageTags.DrawItem
        e.DrawBackground()
        e.DrawFocusRectangle()
        If e.Index >= 0 Then
            ' Get the Color object from the Items list
            Dim tag As MessageTag = CType(CType(sender, ListBox).Items(e.Index), MessageTag)
            Dim aColor As Color = tag.Color

            ' get a square using the bounds height
            Dim rect As Rectangle = New Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 5)
            Dim br As Brush = Brushes.White
            ' call these methods first
            e.DrawBackground()
            e.DrawFocusRectangle()
            ' change brush color if item is selected
            If e.State = DrawItemState.Selected OrElse e.State = DrawItemState.ComboBoxEdit Then
                br = Brushes.White
            Else
                br = Brushes.Black
            End If

            ' draw a rectangle and fill it
            e.Graphics.DrawRectangle(New Pen(aColor), rect)
            e.Graphics.FillRectangle(New SolidBrush(aColor), rect)

            ' draw a border
            rect.Inflate(1, 1)
            e.Graphics.DrawRectangle(Pens.Black, rect)

            ' draw the Color name
            e.Graphics.DrawString(tag.Text, CType(sender, ListBox).Font, br, e.Bounds.Height + 5, ((e.Bounds.Height - CType(sender, ListBox).Font.Height) \ 2) + e.Bounds.Top)
        End If

    End Sub


    Private Sub lblMessageTagColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMessageTagColor.Click
        Dim picker As New ColorDialog()
        If picker.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblMessageTagColor.BackColor = picker.Color
        End If
    End Sub

    Private Sub nudLoadMessagePreviewDelay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudLoadMessagePreviewDelay.ValueChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkEmptyTrashOnExit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEmptyTrashOnExit.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkAutoAcceptInvites_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _autoAcceptInviteDirty = True
        btnOK.Enabled = True
    End Sub

    Private Sub chkMinimizeToTray_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMinimizeToTray.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkShowNoticeForNewMessages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowNoticeForNewMessages.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkPlaySoundNewMessages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPlaySoundNewMessages.CheckedChanged
        btnOK.Enabled = True
        cboNewMessageNoticeSound.Enabled = chkPlaySoundNewMessages.Checked
        btnPlaySelectedNotifySound.Enabled = chkPlaySoundNewMessages.Checked
    End Sub

    Private Sub btnPlaySelectedNotifySound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlaySelectedNotifySound.Click
        Select Case cboNewMessageNoticeSound.SelectedIndex
            Case -1
                ShowMessageBox("Please select a sound first.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Case 0
                Sound.PlayWaveSystem("MailBeep") '-- windows default sound
            Case cboNewMessageNoticeSound.Items.Count - 1
                '-- do nothing (browse option)
            Case Else
                Dim snd As NotifySound = CType(cboNewMessageNoticeSound.SelectedItem, NotifySound)
                Sound.PlayWaveFile(snd.FullPath)
        End Select
    End Sub
    Private Class NotifySound
        Public FolderPath As String
        Public Filename As String
        Public Sub New(ByVal fullPath As String)
            FolderPath = System.IO.Path.GetDirectoryName(fullPath)
            Filename = System.IO.Path.GetFileName(fullPath)
        End Sub
        Public ReadOnly Property FullPath As String
            Get
                Return System.IO.Path.Combine(FolderPath, Filename)
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return System.IO.Path.GetFileNameWithoutExtension(Filename)
        End Function
    End Class
    Private Sub PopulateNewMessageSounds()
        Dim files() As String
        Dim snd As NotifySound
        Dim strFilenameToMatch As String = GetNotifySoundFilename().ToLower()

        Dim strAppSoundsPath As String = System.IO.Path.GetDirectoryName(GetEXEFullPath())
        strAppSoundsPath = System.IO.Path.Combine(strAppSoundsPath, SOUNDS_FOLDER_NAME)
        If Not System.IO.Directory.Exists(strAppSoundsPath) Then
            System.IO.Directory.CreateDirectory(strAppSoundsPath)
        End If

        If strFilenameToMatch.Length = 0 Then
            chkPlaySoundNewMessages.Checked = False
            cboNewMessageNoticeSound.SelectedIndex = 0
        Else
            chkPlaySoundNewMessages.Checked = True
            If strFilenameToMatch = NOTIFY_SOUND_DEFAULT.ToLower Then
                cboNewMessageNoticeSound.SelectedIndex = 0
                strFilenameToMatch = String.Empty
            End If
        End If

        files = System.IO.Directory.GetFiles(strAppSoundsPath, "*" & NOTIFY_SOUND_VALID_EXTENSION)
        For Each strFilename As String In files
            snd = New NotifySound(strFilename)
            cboNewMessageNoticeSound.Items.Add(snd)
            If strFilenameToMatch.Length > 0 AndAlso strFilename.ToLower = strFilenameToMatch Then
                cboNewMessageNoticeSound.SelectedIndex = cboNewMessageNoticeSound.Items.Count - 1
            End If
        Next

        files = System.IO.Directory.GetFiles(MySoundsPath, "*" & NOTIFY_SOUND_VALID_EXTENSION)
        For Each strFilename As String In files
            snd = New NotifySound(strFilename)
            cboNewMessageNoticeSound.Items.Add(snd)
            If strFilenameToMatch.Length > 0 AndAlso strFilename.ToLower = strFilenameToMatch Then
                cboNewMessageNoticeSound.SelectedIndex = cboNewMessageNoticeSound.Items.Count - 1
            End If
        Next

        cboNewMessageNoticeSound.Items.Add("Add sound file...")

        If cboNewMessageNoticeSound.SelectedIndex = -1 Then
            cboNewMessageNoticeSound.SelectedIndex = 0
        End If
    End Sub
    Private Sub cboNewMessageNoticeSound_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNewMessageNoticeSound.SelectedIndexChanged
        If Not _loading Then
            Select Case cboNewMessageNoticeSound.SelectedIndex
                Case cboNewMessageNoticeSound.Items.Count - 1
                    '-- browse for sound file
                    Dim ofd As New OpenFileDialog()
                    ofd.Filter = "WAV files|*.wav"
                    ofd.Title = "Select WAV file for new message notification"
                    If ofd.ShowDialog = DialogResult.OK Then
                        '-- verify the file
                        If System.IO.Path.GetExtension(ofd.FileName).ToLower <> NOTIFY_SOUND_VALID_EXTENSION Then
                            ShowMessageBox("Only " & NOTIFY_SOUND_VALID_EXTENSION & " files are valid for new message notification.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                        '-- copy to MySounds path
                        Dim strDestinationFilename As String = MySoundsPath & System.IO.Path.GetFileName(ofd.FileName)
                        System.IO.File.Copy(ofd.FileName, strDestinationFilename, True)
                        Dim snd As NotifySound
                        snd = New NotifySound(strDestinationFilename)

                        Dim strBrowse As String = cboNewMessageNoticeSound.Items(cboNewMessageNoticeSound.Items.Count - 1)
                        cboNewMessageNoticeSound.Items.Remove(strBrowse)
                        cboNewMessageNoticeSound.Items.Add(snd)
                        cboNewMessageNoticeSound.Items.Add(strBrowse)
                        cboNewMessageNoticeSound.SelectedIndex = cboNewMessageNoticeSound.Items.Count - 2 '-- select sound just added

                        '-- change settings


                        btnOK.Enabled = True
                    Else
                        '-- revert to current setting
                    End If
                Case Else
                    btnOK.Enabled = True
            End Select
        End If
    End Sub

    Private Sub chkKeepSentMessages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKeepSentMessages.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub btnResetAllHiddenNotices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAllHiddenNotices.Click
        AppSettings.DoNotShowAddEmailAccountNotice = False
        AppSettings.DoNotShowBlockedScriptsNotice = False
        AppSettings.DoNotShowEmailRecipientNoReply = False
        AppSettings.DoNotShowEmailRecipientNotEncrypted = False
        AppSettings.DoNotShowReadReceiptWillNotBeRequested = False
        AppSettings.DoNotShowRemovedRecipientNotice = False
        AppSettings.DoNotShowReplyAllBCCNotice = False
        AppSettings.ImageResizePromptFrequency = ImageResizePromptFrequencyEnum.EveryImage
        AppSettings.DoNotShowDecryptedBodyOverwriteWarning = False
        AppSettings.DoNotShowBlockedIFramesNotice = False
        AppSettings.DoNotShowTipPanel = False
        AppSettings.DoNotShowReadMessageBlockNotice = False
        AppSettings.DoNotShowMissingSubjectNotice = False
        AppSettings.DoNotShowShutDownErrorNotice = False
        AppSettings.DoNotShowSMTPServerConnectionTimeOutErrorNotice = False
        AppSettings.DoNotShowPOPServerConnectionTimeOutErrorNotice = False
        AppSettings.DoNotShowBrowserFullScreenTipPanel = False
        AppSettings.DoNotShowBrowserFullScreenCtrlDeletePanel = False
        AppSettings.DoNotShowBrowserFullScreenShiftCtrlDeleteTipPanel = False
        AppSettings.DoNotShowRSSErrorListPrompt = False
        AppSettings.Save()
    End Sub

    Private Sub chkToolBarsIncludeText_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkToolBarsIncludeText.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkUseLargeSendReceiveButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseLargeSendReceiveButton.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkMaintainMessageZoom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMaintainMessageZoom.CheckStateChanged
        btnOK.Enabled = True
    End Sub

    Private Sub cboDefaultEmailEncryption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDefaultEmailEncryption.SelectedIndexChanged
        btnOK.Enabled = True
    End Sub

    Private Sub nudWebMessageDaysExpireAfterRead_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnOK.Enabled = True
    End Sub

    Private Sub nudWebMessageDaysExpireAfterSend_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnOK.Enabled = True
    End Sub

    Private Sub chkShowReadingZoomBar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowReadingZoomBar.CheckStateChanged
        btnOK.Enabled = True
    End Sub

    Private Sub nudNewMessageNotifyStaysOpen_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudNewMessageNotifyStaysOpen.ValueChanged
        btnOK.Enabled = True

        If nudNewMessageNotifyStaysOpen.Value > 120 Then
            Dim ts As New TimeSpan(0, 0, nudNewMessageNotifyStaysOpen.Value)
            lblNewMessageStaysOpenCalculation.Text = FormatTimeSpan2(ts)
            lblNewMessageStaysOpenCalculation.Show()
        Else
            lblNewMessageStaysOpenCalculation.Hide()
        End If
    End Sub

    Private Sub cboDateFormat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDateFormat.SelectedIndexChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkEmailAutoAddRecipientsTieSMTP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEmailAutoAddRecipientsTieSMTP.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub pbRSSInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbRSSInfo.Click
        ShowMessageBox("This area allows you to configure if and when TrulyMail automatically checks for new RSS and News articles.", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub


    Private Sub txtRSSAutoCheckMinutes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRSSAutoCheckMinutes.TextChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkRSSAutoCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRSSAutoCheck.CheckedChanged
        btnOK.Enabled = True
        txtRSSAutoCheckMinutes.Enabled = chkRSSAutoCheck.Checked
    End Sub

    Private Sub chkRSSAutoCheckOnStartup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRSSAutoCheckOnStartup.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkReplyToPlainTextIsPlainText_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReplyToPlainTextIsPlainText.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub btnChangeFontForPlainText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeFontForPlainText.Click
        Dim fd As New FontDialog()
        If fd.ShowDialog = DialogResult.OK Then
            AppSettings.FontForPlainText = fd.Font
            lblFontForPlainText.Text = AppSettings.FontForPlainText.Name & ", " & AppSettings.FontForPlainText.Size
            btnOK.Enabled = True
        End If
    End Sub

    Private Sub chkAutoZipEmailAttachments_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoZipEmailAttachments.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub pbEmailDelayInfo_Click(sender As System.Object, e As System.EventArgs) Handles pbEmailDelayInfo.Click
        ShowMessageBox("This area allows you to wait for some time between sending your email messages in Newsletter Mode. Some email servers do not allow you to send more than some number (e.g., 5) email messages within a certain number of seconds (e.g., 30). If you use Newsletter Mode to send many email messages at once and you find you often have problems sending those messages, increase this number. " & _
                  Environment.NewLine & Environment.NewLine & _
                  "This setting affects only messages sent using Newsletter Mode. A setting of zero seconds will send messages as quickly as possible but the email server might introduce its own delays." & _
                  Environment.NewLine & Environment.NewLine & _
                  "If you do not use Newsletter Mode, then this setting has no effect.", _
                  MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub nudIntraEmailSendDelay_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudIntraEmailSendDelay.ValueChanged
        btnOK.Enabled = True
    End Sub

    Private Sub cboKryptonTheme_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Try
            btnOK.Enabled = True
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error changing the theme: " & ex.Message)
        End Try
    End Sub

    Private Sub lblAlternatingRowColor_Click(sender As System.Object, e As System.EventArgs) Handles lblAlternatingRowColor.Click
        Dim picker As New ColorDialog()
        If picker.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblAlternatingRowColor.BackColor = picker.Color
            btnOK.Enabled = True
        End If
    End Sub

    Private Sub chkAutoSizeMessageListColumns_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAutoSizeMessageListColumns.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub pbDeleteMessageTag_Click(sender As System.Object, e As System.EventArgs) Handles pbDeleteMessageTag.Click
        If lstMessageTags.SelectedIndex >= 0 Then
            Dim tag As MessageTag = CType(lstMessageTags.Items(lstMessageTags.SelectedIndex), MessageTag)
            AppSettings.MessageTags.Remove(tag)

            btnOK.Enabled = True
            LoadMessageTags()
        End If
    End Sub

    Private Sub pbAddNewMessageTag_Click(sender As System.Object, e As System.EventArgs) Handles pbAddNewMessageTag.Click
        Dim strNewTagText As String = txtNewMessageTagText.Text.Trim

        If strNewTagText.Length = 0 Then
            ShowMessageBox("Please enter the label for the new message tag.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        For Each tag As MessageTag In AppSettings.MessageTags
            If tag.Text = strNewTagText Then
                ShowMessageBox("The text you entered already exists as a message tag.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Next

        Dim newtag As New MessageTag
        newtag.Color = lblMessageTagColor.BackColor
        newtag.Text = strNewTagText
        AppSettings.MessageTags.Add(newtag)

        LoadMessageTags()
    End Sub

    Private Sub pbUpdateMessageTag_Click(sender As System.Object, e As System.EventArgs) Handles pbUpdateMessageTag.Click
        If lstMessageTags.SelectedIndex >= 0 Then
            Dim changingTag As MessageTag = CType(lstMessageTags.Items(lstMessageTags.SelectedIndex), MessageTag)

            Dim strNewTagText As String = txtNewMessageTagText.Text.Trim

            If strNewTagText.Length = 0 Then
                ShowMessageBox("The label for the message tag cannot be blank.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            For Each tag As MessageTag In AppSettings.MessageTags
                If tag.Text = strNewTagText AndAlso tag IsNot changingTag Then
                    ShowMessageBox("The text you entered already exists as a message tag.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Next

            changingTag.Text = txtNewMessageTagText.Text
            changingTag.Color = lblMessageTagColor.BackColor
            LoadMessageTags()
        End If
    End Sub

    Private Sub lstMessageTags_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstMessageTags.SelectedIndexChanged
        If lstMessageTags.SelectedIndex >= 0 Then
            Dim tag As MessageTag = CType(lstMessageTags.Items(lstMessageTags.SelectedIndex), MessageTag)
            txtNewMessageTagText.Text = tag.Text
            lblMessageTagColor.BackColor = tag.Color
        End If
    End Sub

    Private Sub pbMoveMessageTagUp_Click(sender As System.Object, e As System.EventArgs) Handles pbMoveMessageTagUp.Click
        Try
            Dim intSelectedIndex As Integer = lstMessageTags.SelectedIndex
            If intSelectedIndex >= 0 Then
                If intSelectedIndex = 0 Then
                    ShowMessageBoxError("This message tag is already at the top of the list")
                Else
                    Dim tag As MessageTag = AppSettings.MessageTags.Item(intSelectedIndex)
                    AppSettings.MessageTags.RemoveAt(intSelectedIndex)

                    intSelectedIndex -= 1
                    AppSettings.MessageTags.Insert(intSelectedIndex, tag)
                    LoadMessageTags()

                    lstMessageTags.SelectedIndex = intSelectedIndex
                End If
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error modifying the message tags. " & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub pbMoveMessageTagDown_Click(sender As System.Object, e As System.EventArgs) Handles pbMoveMessageTagDown.Click
        Try
            Dim intSelectedIndex As Integer = lstMessageTags.SelectedIndex
            If intSelectedIndex >= 0 Then
                If intSelectedIndex = lstMessageTags.Items.Count - 1 Then
                    ShowMessageBoxError("This message tag is already at the bottom of the list")
                Else
                    Dim tag As MessageTag = AppSettings.MessageTags.Item(intSelectedIndex)
                    AppSettings.MessageTags.RemoveAt(intSelectedIndex)

                    intSelectedIndex += 1
                    AppSettings.MessageTags.Insert(intSelectedIndex, tag)
                    LoadMessageTags()

                    lstMessageTags.SelectedIndex = intSelectedIndex
                End If
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error modifying the message tags. " & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub pbChangeComposeBackColor_Click(sender As System.Object, e As System.EventArgs) Handles pbChangeComposeBackColor.Click
        Dim colordiag As New ColorDialog()
        colordiag.Color = picNewMessageBackground.BackColor
        If colordiag.ShowDialog = Windows.Forms.DialogResult.OK Then
            picNewMessageBackground.BackColor = colordiag.Color
            btnOK.Enabled = True
        End If

        UpdateSampleNewMessage()
    End Sub

    Private Sub nudPromptToRecreateEncryptionKeysMessages_ValueChanged(sender As System.Object, e As System.EventArgs)
        btnOK.Enabled = True
    End Sub

    Private Sub nudPromptToRecreateEncryptionKeysDays_ValueChanged(sender As System.Object, e As System.EventArgs)
        btnOK.Enabled = True
    End Sub
    Public Enum TabEnum
        UserInfo
        Encryption
    End Enum

    Private Sub chkAutomaticallyTransmitOnSend_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAutomaticallyTransmitOnSend.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub tmrAutoClose_Tick(sender As Object, e As EventArgs) Handles tmrAutoClose.Tick
        If _cancelLoading Then
            Close()
        End If
    End Sub

    Private Sub nudLoggingErrorDisplayFrequency_ValueChanged(sender As Object, e As EventArgs) Handles nudLoggingErrorDisplayFrequency.ValueChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkAddNoteForProcessingRuleAction_CheckedChanged(sender As Object, e As EventArgs) Handles chkAddNoteForProcessingRuleAction.CheckedChanged, chkAddNoteWhenChangingSubject.CheckedChanged, chkAddNoteWhenSendingReturnReceipt.CheckedChanged
        btnOK.Enabled = True
    End Sub


    Private Sub chkEnableVerboseLogging_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnableVerboseLogging.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub rdoFallbackUnderWine_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFallbackUnderWine.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub rdoFallbackAlways_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFallbackAlways.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub rdoFallbackNever_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFallbackNever.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkRemoveDiacriticsOnReceive_CheckedChanged(sender As Object, e As EventArgs) Handles chkRemoveDiacriticsOnReceive.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub chkPreviewPanePlainText_CheckedChanged(sender As Object, e As EventArgs) Handles chkPreviewPanePlainText.CheckedChanged
        btnOK.Enabled = True
    End Sub

    Private Sub nudSendDelayMinutes_ValueChanged(sender As Object, e As EventArgs) Handles nudSendDelayMinutes.ValueChanged
        btnOK.Enabled = True
    End Sub
End Class