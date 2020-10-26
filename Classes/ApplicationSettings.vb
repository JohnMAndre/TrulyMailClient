Friend Class ApplicationSettings

#Region " Private Data "
    Private Const DELIMITER As Char = CChar("*")
    Private _xmlDocument As New Xml.XmlDocument

    Private _profileSettingsFilePath As String
    Private _autoSendReceive As Boolean
    Private _autoSendReceiveInterval As Integer
    Private _dictionaryFilename As String
    Private _spellCheckBeforeSend As Boolean
    Private _sendAndReceiveOnStartup As Boolean
    Private _logFileLocation As String
    Private _largeToolbarIcons As Boolean
    Private _spellCheckSubject As Boolean
    Private _autoSaveDrafts As Boolean
    Private _autoSaveDraftsMinutes As Integer
    Private _defaultMessageSubject As String
    Private _addressBookWindowState As FormWindowState
    Private _mainFormWindowState As FormWindowState
    Private _newMessageWindowState As FormWindowState
    Private _optionsFormWindowState As FormWindowState
    Private _readMessageWindowState As FormWindowState
    Private _searchFormWindowState As FormWindowState
    Private _emailAutoAddRecipientsOnSend As Boolean
    Private _emailShowSenderAsSent As Boolean

    Private _popMessageIDsReceived As New Hashtable()
    Private _smtpProfiles As New List(Of SMTPProfile)
    Private _popProfiles As New List(Of POPProfile)

    Private _sendNowDelay As Integer
    Private _sendNowOnExit As Boolean
    Private _replyPostingMode As ReplyPostModeEnum
    Private _emailRequestReturnReceipt As Boolean
    Private _blockRemoteImages As Boolean
    Private _enableLogging As Boolean
    Private _doNotShowEmailRecipientNotEncrypted As Boolean
    Private _delayMinutesWhenCannotSend As Integer
    Private _doNotShowEmailRecipientNoReply As Boolean
    Private _autoEmptyTrash As Boolean
    Private _trashDaysToRetain As Integer
    Private _doNotShowReadReceiptWillNotBeRequested As Boolean
    Private _doNotProcessEmailReceipts As Boolean
    Private _defaultNewMessageFontName As String
    Private _defaultNewMessageFontSize As Integer
    Private _newMessageBackgroundColor As Color
    Private _showMessagePreviewPane As Boolean
    Private _messagePreviewPaneVertical As Boolean
    Private _messagePreviewPaneSize As Integer
    Private _indexResetDate As Date
    Private _messageListState As String
    Private _singleSpaceEditor As Boolean
    Private _showEditorSpacingStatus As Boolean
    Private _messageTags As New List(Of MessageTag)
    Private _messagePreviewLoadDelay As Decimal
    Private _publicProfileData As New Xml.XmlDocument
    Private _doNotShowReplyAllBCCNotice As Boolean

    '-- The new variables are all 2010 just direct properties
    Public Property ProperlyLoaded As Boolean '-- used in save, only save if this was properly loaded, empty settings file makes TrulyMail non-functioning
    Private Property _intraEmailSendDelay As Integer
#End Region
    Public Sub New()
        _profileSettingsFilePath = GetSettingsFilename()

    End Sub
    Friend ReadOnly Property SettingsFilename As String
        Get
            Return _profileSettingsFilePath
        End Get
    End Property
    Public Function RequiresPasswordToLoad() As Boolean
        If System.IO.File.Exists(_profileSettingsFilePath) Then
            Dim strContents As String = System.IO.File.ReadAllText(_profileSettingsFilePath)
            Return IsTextEncrypted(strContents)
        Else
            '-- There is no settings file, must be a new install
            '   so no need for a password
            Return False
        End If
    End Function

    Public Sub Load(encryptionPassword As String)

        If System.IO.File.Exists(_profileSettingsFilePath) Then
            Try
                If encryptionPassword IsNot Nothing AndAlso encryptionPassword.Length > 0 Then
                    m_strMasterPassword = encryptionPassword

                    '-- try to decrypt then load
                    Dim strEncryptedContents As String = System.IO.File.ReadAllText(_profileSettingsFilePath)
                    Dim strDecryptedContents As String = DecryptTextSymetric(encryptionPassword, strEncryptedContents)

                    _xmlDocument.LoadXml(strDecryptedContents)
                    Me.EncryptSettingsFile = True
                Else
                    '-- try to load without decrypting
                    _xmlDocument.Load(_profileSettingsFilePath)
                    Me.EncryptSettingsFile = False
                End If
            Catch ex As Exception
                '-- There is no log file at this point, so just show a msgbox
                ShowMessageBoxError("Error: " & ex.Message)
                'Log(ex)
                'Log("Password required: " & RequiresPasswordToLoad().ToString())
                If RequiresPasswordToLoad() Then
                    Throw New Exception(EXCEPTIONTEXT_APPSETTINGS_ENCRYPTED_WRONG_PASSWORD)
                Else
                    Throw New Exception(EXCEPTIONTEXT_APPSETTINGS_CANNOT_LOAD)
                End If
            End Try

            FullName = GetSettingString("FullName")

            '-- Now, load up the settings from user.config
            Dim strValue As String
            Dim strValues() As String '-- for processing arrays stored as strings

            strValue = GetSettingString("AutoSendReceive")
            _autoSendReceive = ConvertToBool(strValue, My.Settings.AutoSendReceive)

            strValue = GetSettingString("AutoSendReceiveInterval")
            _autoSendReceiveInterval = ConvertToInt32(strValue, My.Settings.AutoSendReceiveInterval)

            _dictionaryFilename = GetSettingString("SpellingDictionary") '-- changed in 3.0
            If _dictionaryFilename.Length = 0 Then
                _dictionaryFilename = My.Settings.SpellingDictionary
            End If

            strValue = GetSettingString("SpellCheckBeforeSend")
            _spellCheckBeforeSend = ConvertToBool(strValue, My.Settings.SpellCheckBeforeSend)

            strValue = GetSettingString("SendAndReceiveOnStartup")
            _sendAndReceiveOnStartup = ConvertToBool(strValue, My.Settings.SendAndReceiveOnStartup)

            strValue = GetSettingString("EnableLogging")
            _enableLogging = ConvertToBool(strValue, My.Settings.EnableLogging)

            Dim dirInfo As New System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(_profileSettingsFilePath))
            _logFileLocation = QualifyPath(dirInfo.Parent.FullName) & "Log\Log.txt" '-- Up one level from Profile must be the Data folder, then put log file under data folder
            If Not System.IO.File.Exists(_logFileLocation) Then
                '-- file does not exist, create it.
                If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(_logFileLocation)) Then
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(_logFileLocation))
                End If
                System.IO.File.WriteAllText(_logFileLocation, "x64: " & (IntPtr.Size = 8) & Environment.NewLine) '-- Just create the folders and file to make sure we don't have problems later
            End If

            strValue = GetSettingString("LargeToolbarIcons")
            _largeToolbarIcons = ConvertToBool(strValue, My.Settings.LargeToolbarIcons)

            strValue = GetSettingString("SpellCheckSubject")
            _spellCheckSubject = ConvertToBool(strValue, My.Settings.SpellCheckSubject)

            strValue = GetSettingString("AutoSaveDrafts")
            _autoSaveDrafts = ConvertToBool(strValue, My.Settings.AutoSaveDrafts)

            strValue = GetSettingString("AutoSaveDraftsMinutes")
            _autoSaveDraftsMinutes = ConvertToInt32(strValue, My.Settings.AutoSaveDraftsMinutes)

            _defaultMessageSubject = GetSettingString("DefaultMessageSubject")
            If _defaultMessageSubject.Length = 0 Then
                _defaultMessageSubject = My.Settings.DefaultMessageSubject
            End If

            strValue = GetSettingString("AddressBookWindowState")
            _addressBookWindowState = ConvertToInt32(strValue, My.Settings.AddressBookWindowState)

            strValue = GetSettingString("MainFormWindowState")
            _mainFormWindowState = ConvertToInt32(strValue, My.Settings.MainFormWindowState)

            strValue = GetSettingString("NewMessageWindowState")
            _newMessageWindowState = ConvertToInt32(strValue, My.Settings.NewMessageWindowState)

            strValue = GetSettingString("OptionsFormWindowState")
            _optionsFormWindowState = ConvertToInt32(strValue, My.Settings.OptionsFormWindowState)

            strValue = GetSettingString("ReadMessageWindowState")
            _readMessageWindowState = ConvertToInt32(strValue, My.Settings.ReadMessageWindowState)

            strValue = GetSettingString("SearchFormWindowState")
            _searchFormWindowState = ConvertToInt32(strValue, My.Settings.SearchFormWindowState)

            strValue = GetSettingString("EmailAutoAddRecipientsOnSend")
            _emailAutoAddRecipientsOnSend = ConvertToBool(strValue, My.Settings.EmailAutoAddRecipientsOnSend)

            strValue = GetSettingString("EmailShowSenderAsSent")
            _emailShowSenderAsSent = ConvertToBool(strValue, My.Settings.EmailShowSenderAsSent)

            LoadSMTPList()
            LoadPOPList()

            strValue = GetSettingString("SendNowDelay")
            _sendNowDelay = ConvertToInt32(strValue, My.Settings.SendNowDelay)

            strValue = GetSettingString("SendNowOnExit")
            _sendNowOnExit = ConvertToBool(strValue, My.Settings.SendNowOnExit)

            strValue = GetSettingString("ReplyPostingMode")
            _replyPostingMode = ConvertToInt32(strValue, My.Settings.ReplyPostingMode)

            strValue = GetSettingString("EmailRequestReturnReceipt")
            _emailRequestReturnReceipt = ConvertToBool(strValue, My.Settings.EmailRequestReturnReceipt)

            strValue = GetSettingString("BlockRemoteImages")
            _blockRemoteImages = ConvertToBool(strValue, My.Settings.BlockRemoteImages)

            strValue = GetSettingString("DoNotShowEmailRecipientNotEncrypted")
            _doNotShowEmailRecipientNotEncrypted = ConvertToBool(strValue, My.Settings.DoNotShowEmailRecipientNotEncrypted)

            strValue = GetSettingString("DelayMinutesWhenCannotSend")
            _delayMinutesWhenCannotSend = ConvertToInt32(strValue, My.Settings.DelayMinutesWhenCannotSend)

            strValue = GetSettingString("DoNotShowEmailRecipientNoReply")
            _doNotShowEmailRecipientNoReply = ConvertToBool(strValue, My.Settings.DoNotShowEmailRecipientNoReply)

            strValue = GetSettingString("AutoEmptyTrash")
            _autoEmptyTrash = ConvertToBool(strValue, My.Settings.AutoEmptyTrash)

            strValue = GetSettingString("TrashDaysToRetain")
            _trashDaysToRetain = ConvertToInt32(strValue, My.Settings.TrashDaysToRetain)

            strValue = GetSettingString("DoNotShowReadReceiptWillNotBeRequested")
            _doNotShowReadReceiptWillNotBeRequested = ConvertToBool(strValue, My.Settings.DoNotShowReadReceiptWillNotBeRequested)

            strValue = GetSettingString("DoNotProcessEmailReceipts")
            _doNotProcessEmailReceipts = ConvertToBool(strValue, My.Settings.DoNotProcessEmailReceipts)

            _defaultNewMessageFontName = GetSettingString("DefaultNewMessageFontName")
            If _defaultNewMessageFontName.Length = 0 Then
                _defaultNewMessageFontName = My.Settings.DefaultNewMessageFontName
            End If

            strValue = GetSettingString("DefaultNewMessageFontSize")
            _defaultNewMessageFontSize = ConvertToInt32(strValue, My.Settings.DefaultNewMessageFontSize)
            If _defaultNewMessageFontSize > 7 Then
                _defaultNewMessageFontSize = 7
            ElseIf _defaultNewMessageFontSize < 1 Then
                _defaultNewMessageFontSize = 1
            End If

            strValue = GetSettingString("NewMessageBackgroundColor")
            _newMessageBackgroundColor = ConvertToColor(strValue, My.Settings.NewMessageBackgroundColor)

            'LoadPublicProfile()

            strValue = GetSettingString("ShowMessagePreviewPane")
            _showMessagePreviewPane = ConvertToBool(strValue, My.Settings.ShowMessagePreviewPane)

            strValue = GetSettingString("MessagePreviewPaneVertical")
            _messagePreviewPaneVertical = ConvertToBool(strValue, My.Settings.MessagePreviewPaneVertical)

            strValue = GetSettingString("MessagePreviewPaneSize")
            _messagePreviewPaneSize = ConvertToInt32(strValue, My.Settings.MessagePreviewPaneSize)

            strValue = GetSettingString("IndexResetDate")
            If strValue.Contains("T") Then
                _indexResetDate = ConvertToDateFromXML(strValue, My.Settings.IndexResetDate)
            Else
                _indexResetDate = ConvertToDate(strValue, My.Settings.IndexResetDate)
            End If

            _messageListState = GetSettingString("MessageListState")
            If _messageListState.Length = 0 Then
                _messageListState = My.Settings.MessageListState
            End If
            _singleSpaceEditor = ConvertToBool(GetSettingString("SingleSpaceEditor"), My.Settings.SingleSpaceEditor)
            _showEditorSpacingStatus = ConvertToBool(GetSettingString("ShowEditorSpacingStatus"), My.Settings.ShowEditorSpacingStatus)

            _messagePreviewLoadDelay = ConvertToDecimal(GetSettingString("MessagePreviewLoadDelay"), My.Settings.MessagePreviewLoadDelay)

            _doNotShowReplyAllBCCNotice = ConvertToBool(GetSettingString("DoNotShowReplyAllBCCNotice"), My.Settings.DoNotShowReplyAllBCCNotice)

            EmptyTrashOnExit = ConvertToBool(GetSettingString("EmptyTrashOnExit"), My.Settings.EmptyTrashOnExit)
            DoNotShowAddEmailAccountNotice = ConvertToBool(GetSettingString("DoNotShowAddEmailAccountNotice"), My.Settings.DoNotShowAddEmailAccountNotice)
            DoNotShowBlockedScriptsNotice = ConvertToBool(GetSettingString("DoNotShowBlockedScriptsNotice"), My.Settings.DoNotShowBlockedScriptsNotice)

            _addressBookListState = GetSettingString("AddressBookListState")
            If _addressBookListState.Length = 0 Then
                _addressBookListState = My.Settings.AddressBookListState
            End If

            strValue = GetSettingString("ContactLastSentUpdated")
            If strValue.Contains("T") Then
                ContactLastSentUpdated = ConvertToDateFromXML(strValue, My.Settings.ContactLastSentUpdated)
            Else
                ContactLastSentUpdated = ConvertToDate(strValue, My.Settings.ContactLastSentUpdated)
            End If

            AutoSpellCheckNewMessage = ConvertToBool(GetSettingString("AutoSpellCheckNewMessage"), My.Settings.AutoSpellCheckNewMessage)
            DoNotShowRemovedRecipientNotice = ConvertToBool(GetSettingString("DoNotShowRemovedRecipientNotice"), My.Settings.DoNotShowRemovedRecipientNotice)
            MinimizeToTray = ConvertToBool(GetSettingString("MinimizeToTray"), My.Settings.MinimizeToTray)
            ShowNoticeForNewMessages = ConvertToBool(GetSettingString("ShowNoticeForNewMessages"), My.Settings.ShowNoticeForNewMessages)
            NewMessageNotifySound = GetSettingString("NewMessageNotifySound")
            If NewMessageNotifySound.Length = 0 Then
                NewMessageNotifySound = My.Settings.NewMessageNotifySound
            End If
            KeepSentMessages = ConvertToBool(GetSettingString("KeepSentMessages"), My.Settings.KeepSentMessages)

            strValue = GetSettingString("ImageResizePromptFrequency")
            If strValue.Length = 0 Then
                ImageResizePromptFrequency = My.Settings.ImageResizePromptFrequency
            Else
                ImageResizePromptFrequency = [Enum].Parse(GetType(ImageResizePromptFrequencyEnum), strValue)
            End If

            strValue = GetSettingString("ImageResizeSize")
            If strValue.Length = 0 Then
                ImageResizeSize = My.Settings.ImageResizeSize
            Else
                ImageResizeSize = [Enum].Parse(GetType(ImageResizeSizeEnum), strValue)
            End If

            ReadMessageHeaderCompactMode = ConvertToBool(GetSettingString("ReadMessageHeaderCompactMode"), My.Settings.ReadMessageHeaderCompactMode)
            ToolBarsShowText = ConvertToBool(GetSettingString("ToolBarsShowText"), My.Settings.ToolBarsShowText)
            EncryptionVersion = ConvertToInt32(GetSettingString("EncryptionVersion"), My.Settings.EncryptionVersion)
            If EncryptionVersion > 1 Then
                EncryptionVersion = 1
            End If
            If EncryptionVersion < 0 Then
                EncryptionVersion = 0
            End If

            UseLargeAllAccountDropDown = ConvertToBool(GetSettingString("UseLargeAllAccountDropDown"), My.Settings.UseLargeAllAccountDropDown)
            MaintainMessageZoom = ConvertToBool(GetSettingString("MaintainMessageZoom"), My.Settings.MaintainMessageZoom)
            CountOfDictionariesAvailable = ConvertToInt32(GetSettingString("CountOfDictionariesAvailable"), My.Settings.CountOfDictionariesAvailable)
            DefaultEmailEncryption = ConvertToInt32(GetSettingString("DefaultEmailEncryption"), My.Settings.DefaultEmailEncryption)
            DoNotShowDecryptedBodyOverwriteWarning = ConvertToBool(GetSettingString("DoNotShowDecryptedBodyOverwriteWarning"), My.Settings.DoNotShowDecryptedBodyOverwriteWarning)
            MainFormFilterAutoComplete = New AutoCompleteStringCollection()
            strValue = GetSettingString("MainFormFilterAutoComplete")
            If strValue.Length > 0 Then
                MainFormFilterAutoComplete.AddRange(strValue.Split(DELIMITER))
            End If
            DoNotShowBlockedIFramesNotice = ConvertToBool(GetSettingString("DoNotShowBlockedIFramesNotice"), My.Settings.DoNotShowBlockedIFramesNotice)
            DoNotShowTipPanel = ConvertToBool(GetSettingString("DoNotShowTipPanel"), My.Settings.DoNotShowTipPanel)
            ShowReadingZoomBar = ConvertToBool(GetSettingString("ShowReadingZoomBar"), My.Settings.ShowReadingZoomBar)
            NoticeForNewMessagesSecondsOpen = ConvertToDecimal(GetSettingString("NoticeForNewMessagesSecondsOpen"), My.Settings.NoticeForNewMessagesSecondsOpen)
            MainWindowLocation = New Point(ConvertToInt32(GetSettingString("MainWindowLocationX"), My.Settings.MainWindowLocationX), ConvertToInt32(GetSettingString("MainWindowLocationY"), My.Settings.MainWindowLocationY))
            MainWindowSize = New Size(ConvertToInt32(GetSettingString("MainWindowSizeWidth"), My.Settings.MainWindowSizeWidth), ConvertToInt32(GetSettingString("MainWindowSizeHeight"), My.Settings.MainWindowSizeHeight))
            ReadWindowLocation = New Point(ConvertToInt32(GetSettingString("ReadWindowLocationX"), My.Settings.ReadWindowLocationX), ConvertToInt32(GetSettingString("ReadWindowLocationY"), My.Settings.ReadWindowLocationY))
            ReadWindowSize = New Size(ConvertToInt32(GetSettingString("ReadWindowSizeWidth"), My.Settings.ReadWindowSizeWidth), ConvertToInt32(GetSettingString("ReadWindowSizeHeight"), My.Settings.ReadWindowSizeHeight))
            ComposeWindowLocation = New Point(ConvertToInt32(GetSettingString("ComposeWindowLocationX"), My.Settings.ComposeWindowLocationX), ConvertToInt32(GetSettingString("ComposeWindowLocationY"), My.Settings.ComposeWindowLocationY))
            ComposeWindowSize = New Size(ConvertToInt32(GetSettingString("ComposeWindowSizeWidth"), My.Settings.ComposeWindowSizeWidth), ConvertToInt32(GetSettingString("ComposeWindowSizeHeight"), My.Settings.ComposeWindowSizeHeight))
            ShowAutoTextComposeWindow = ConvertToBool(GetSettingString("ShowAutoTextComposeWindow"), My.Settings.ShowAutoTextComposeWindow)
            strValue = GetSettingString("EditorCustomColors")
            If strValue.Length > 0 Then
                strValues = strValue.Split(DELIMITER)
                ReDim EditorCustomColors(strValues.Length - 1)
                For intCounter As Integer = EditorCustomColors.GetLowerBound(0) To EditorCustomColors.GetUpperBound(0)
                    EditorCustomColors(intCounter) = ConvertToInt32(strValues(intCounter), 16777215)
                Next
            End If
            ComposeAutoTextAreaSplitter = ConvertToInt32(GetSettingString("ComposeAutoTextAreaSplitter"), My.Settings.ComposeAutoTextAreaSplitter)

            DateFormat = ConvertToInt32(GetSettingString("DateFormat"), My.Settings.DateFormat)
            EmailAutoAddRecipientsTieSMTP = ConvertToBool(GetSettingString("EmailAutoAddRecipientsTieSMTP"), My.Settings.EmailAutoAddRecipientsTieSMTP)

            RSSAutoCheckAtStartup = ConvertToBool(GetSettingString("RSSAutoCheckAtStartup"), My.Settings.RSSAutoCheckAtStartup)
            RSSAutoCheckInterval = ConvertToInt32(GetSettingString("RSSAutoCheckInterval"), My.Settings.RSSAutoCheckInterval)
            RSSAutoCheck = ConvertToBool(GetSettingString("RSSAutoCheck"), My.Settings.RSSAutoCheck)
            FolderTreeSplitter = ConvertToInt32(GetSettingString("FolderTreeSplitter"), My.Settings.FolderTreeSplitter)
            DoNotShowPOP3DownloadErrorNotice = ConvertToBool(GetSettingString("DoNotShowPOP3DownloadErrorNotice"), My.Settings.DoNotShowPOP3DownloadErrorNotice)

            DoNotShowReadMessageBlockNotice = ConvertToBool(GetSettingString("DoNotShowReadMessageBlockNotice"), My.Settings.DoNotShowReadMessageBlockNotice)
            DoNotShowMissingSubjectNotice = ConvertToBool(GetSettingString("DoNotShowMissingSubjectNotice"), My.Settings.DoNotShowMissingSubjectNotice)
            ShutDownProperly = ConvertToBool(GetSettingString("ShutDownProperly"), True) '-- todo: think if this is right, failure to write settings file will show it was shut down properly and it should not
            DoNotShowShutDownErrorNotice = ConvertToBool(GetSettingString("DoNotShowShutDownErrorNotice"), My.Settings.DoNotShowShutDownErrorNotice)
            WebMessageAttachmentComment = My.Settings.WebMessageAttachmentComment
            ReplyToPlainTextIsPlainText = ConvertToBool(GetSettingString("ReplyToPlainTextIsPlainText"), My.Settings.ReplyToPlainTextIsPlainText)

            Dim intValue As Integer
            Try
                strValue = GetSettingString("PlainTextFontName")
                intValue = ConvertToInt32(GetSettingString("PlainTextFontSize"), 12)
                FontForPlainText = New Font(strValue, intValue)
            Catch ex As Exception
                Log(ex)
                Using rtb As New RichTextBox
                    FontForPlainText = New Font(rtb.Font.Name, 12)
                End Using
            End Try
            AutoZipEmailAttachments = ConvertToBool(GetSettingString("AutoZipEmailAttachments"), My.Settings.AutoZipEmailAttachments)

            MessageExportTrulyMailFakeAddress = GetSettingString("MessageExportTrulyMailFakeAddress")
            MessageExportFolder = GetSettingString("MessageExportFolder")
            MasterPasswordHashLong = GetSettingString("MasterPasswordHashLong") '-- should be string.empty after the first time running >= 5.1

            DoNotShowSMTPServerConnectionTimeOutErrorNotice = ConvertToBool(GetSettingString("DoNotShowSMTPServerConnectionTimeOutErrorNotice"), My.Settings.DoNotShowSMTPServerConnectionTimeOutErrorNotice)
            DoNotShowPOPServerConnectionTimeOutErrorNotice = ConvertToBool(GetSettingString("DoNotShowPOPServerConnectionTimeOutErrorNotice"), My.Settings.DoNotShowPOPServerConnectionTimeOutErrorNotice)
            strValue = GetSettingString("IntraEmailSendDelay")
            If strValue.Length > 0 Then
                IntraEmailSendDelay = GetSettingString("IntraEmailSendDelay")
            Else
                IntraEmailSendDelay = My.Settings.IntraEmailSendDelay
            End If
            strValue = GetSettingString("BasePaletteMode")
            If strValue.Length > 0 Then
                intValue = ConvertToInt32(strValue, 6)
                '-- not less than 0
                '-- not more than 10
                If intValue > 10 OrElse intValue < 0 Then
                    intValue = 6
                End If
            End If

            strValue = GetSettingString("MessageListAlternatingRowColor")
            If IsNumeric(strValue) Then
                MessageListAlternatingRowColor = Color.FromArgb(ConvertToInt32(strValue, -1))
            Else
                MessageListAlternatingRowColor = Color.Yellow
            End If

            strValue = GetSettingString("ContactListAreaVisible")
            ContactListAreaVisible = ConvertToBool(strValue, True)

            DoNotShowBrowserFullScreenTipPanel = ConvertToBool(GetSettingString("DoNotShowBrowserFullScreenTipPanel"), False)
            DoNotShowBrowserFullScreenCtrlDeletePanel = ConvertToBool(GetSettingString("DoNotShowBrowserFullScreenCtrlDeletePanel"), False)
            DoNotShowBrowserFullScreenShiftCtrlDeleteTipPanel = ConvertToBool(GetSettingString("DoNotShowBrowserFullScreenShiftCtrlDeleteTipPanel"), False)

            AutoSizeColumnsMessageList = ConvertToBool(GetSettingString("AutoSizeColumnsMessageList"), True)

            '-- Check if screens have changed
            Dim boolResetWindowLocations As Boolean
            Dim intScreenCount As Integer = ConvertToInt32(GetSettingString("LastKnownNumberOfScreens"), 1)
            If Screen.AllScreens.Length <> intScreenCount Then
                boolResetWindowLocations = True
            End If

            intValue = ConvertToInt32(GetSettingString("LastKnownMainScreenBoundsWidth"), 100)
            If Screen.PrimaryScreen.Bounds.Width <> intValue Then
                boolResetWindowLocations = True
            End If

            intValue = ConvertToInt32(GetSettingString("LastKnownMainScreenBoundsHeight"), 100)
            If Screen.PrimaryScreen.Bounds.Height <> intValue Then
                boolResetWindowLocations = True
            End If

            If boolResetWindowLocations Then
                ResetSavedWindowsPositions()
            End If

            ReadMessagePreviewActionSplitterDistance = ConvertToInt32(GetSettingString("ReadMessagePreviewActionSplitterDistance"), 100)
            ReadMessagePreviewActionVisible = ConvertToBool(GetSettingString("ReadMessagePreviewActionVisible"), True)
            ReadMessageActionSplitterDistance = ConvertToInt32(GetSettingString("ReadMessageActionSplitterDistance"), 100)
            ReadMessageActionVisible = ConvertToBool(GetSettingString("ReadMessageActionVisible"), True)
            DoNotShowRSSErrorListPrompt = ConvertToBool(GetSettingString("DoNotShowRSSErrorListPrompt"), False)
            MessagesSentOnCurrentEncryptionKey = ConvertToInt32(GetSettingString("MessagesSentOnCurrentEncryptionKey"), 0)
            PromptToRecreateEncryptionKeysDays = ConvertToInt32(GetSettingString("PromptToRecreateEncryptionKeysDays"), 90)
            PromptToRecreateEncryptionKeysMessages = ConvertToInt32(GetSettingString("PromptToRecreateEncryptionKeysMessages"), 30)

            strValue = GetSettingString("PromptToRecreateEncryptionKeysAfter")
            If strValue.Contains("T") Then
                PromptToRecreateEncryptionKeysAfter = ConvertToDateFromXML(strValue, Date.UtcNow)
            Else
                PromptToRecreateEncryptionKeysAfter = ConvertToDate(strValue, Date.UtcNow)
            End If

            AutomaticallyTransmitOnSend = ConvertToBool(GetSettingString("AutomaticallyTransmitOnSend"), True)
            HideFilterAreaOnMainForm = ConvertToBool(GetSettingString("HideFilterAreaOnMainForm"), False)
            EmailDownloadLimit = ConvertToBool(GetSettingString("EmailDownloadLimit"), False)
            strValue = GetSettingString("EmailDownloadLimitExpireDate")
            If strValue.Contains("T") Then
                EmailDownloadLimitExpireDate = ConvertToDateFromXML(strValue, Date.Today.AddDays(-1))
            Else
                EmailDownloadLimitExpireDate = ConvertToDate(strValue, Date.Today.AddDays(-1))
            End If

            LoadDoNotSendAddressList()

            HideOutboxCountPastToday = ConvertToBool(GetSettingString("HideOutboxCountPastToday"), False)

            '-- Rule: Master password cannot be removed until all msgs are decrypted
            If Not EncryptSettingsFile Then
                '-- If settings file is not encrypted then there is no master password and all local files must be decrypted (not decrypting)
                MasterPassword = String.Empty
                EncryptLocalFiles = LocalFileEncryptionStatus.Decrypted
            Else
                strValue = GetSettingString("EncryptLocalFiles")
                If strValue.Length > 0 Then
                    EncryptLocalFiles = [Enum].Parse(GetType(LocalFileEncryptionStatus), strValue)
                Else
                    EncryptLocalFiles = LocalFileEncryptionStatus.Decrypted '-- invalid setting (or missing because the feature is new)
                End If
            End If

            '-- Here we retrieve the FileEncryptionPassword but we don't decrypt it
            '   because the user has not yet entered the masterpassword
            '   So it will be decrypted when the user enters the master password
            strValue = GetSettingString("FileEncryptionPassword")
            If strValue.Length > 0 Then
                m_strFileEncryptionPassword = strValue '-- This is stored in the XML as encrypted text (so encrypted text inside encrypted file - double-encrypted but with the same master password)
            End If

            DisplayErrorIntervalSeconds = ConvertToInt32(GetSettingString("DisplayErrorIntervalSeconds"), 10)

            AddNoteForProcessingRuleAction = ConvertToBool(GetSettingString("AddNoteForProcessingRuleAction"), True)
            AddNoteWhenChangingSubject = ConvertToBool(GetSettingString("AddNoteWhenChangingSubject"), True)
            AddNoteWhenSendingReturnReceipt = ConvertToBool(GetSettingString("AddNoteWhenSendingReturnReceipt"), True)

            strValue = GetSettingString("UseFallbackModeWhen")
            If strValue.Length = 0 Then
                UseFallbackModeWhen = UseFallbackModeEnum.UnderWine
            Else
                UseFallbackModeWhen = [Enum].Parse(GetType(UseFallbackModeEnum), strValue)
            End If


            RecentFolderList = LoadRecentFolderListFromStorage(GetSettingString("RecentFolderList"))

            FirstTimeAppIsStarted = False
            EnableVerboseLogging = ConvertToBool(GetSettingString("EnableVerboseLogging"), False)

            strValue = GetSettingString("DefaultSendLaterTime")
            If strValue.Contains("T") Then
                DefaultSendLaterTime = ConvertToDateFromXML(strValue, Date.Now)
            End If


            DarkMode = ConvertToBool(GetSettingString("DarkMode"), False)
            RemoveDiacriticsWhenReceiving = ConvertToBool(GetSettingString("RemoveDiacriticsWhenReceiving"), False)
            ShowMessageEncryptionPassword = ConvertToBool(GetSettingString("ShowMessageEncryptionPassword"), False)
            PreviewPaneToReadAsPlainText = ConvertToBool(GetSettingString("PreviewPaneToReadAsPlainText"), False)

            SendDelayInMinutes = ConvertToInt32(GetSettingString("SendDelayInMinutes"), 60)
        Else
            '-- This is only for first run, setup defaults
            FullName = String.Empty

            '-- Now load up the settings from defaults (from app.config)
            _autoSendReceive = My.Settings.AutoSendReceive
            _autoSendReceiveInterval = My.Settings.AutoSendReceiveInterval
            _dictionaryFilename = My.Settings.SpellingDictionary
            _spellCheckBeforeSend = My.Settings.SpellCheckBeforeSend
            _sendAndReceiveOnStartup = My.Settings.SendAndReceiveOnStartup

            If PortableProfile Then
                Dim dirInfo As New System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(_profileSettingsFilePath))
                _logFileLocation = QualifyPath(dirInfo.Parent.FullName) & "Log\Log.txt"
            Else
                _logFileLocation = My.Settings.LogFileLocation
            End If

            _largeToolbarIcons = My.Settings.LargeToolbarIcons
            _spellCheckSubject = My.Settings.SpellCheckSubject
            _autoSaveDrafts = My.Settings.AutoSaveDrafts
            _autoSaveDraftsMinutes = My.Settings.AutoSaveDraftsMinutes
            _defaultMessageSubject = My.Settings.DefaultMessageSubject
            _addressBookWindowState = My.Settings.AddressBookWindowState
            _mainFormWindowState = My.Settings.MainFormWindowState
            _newMessageWindowState = My.Settings.NewMessageWindowState
            _optionsFormWindowState = My.Settings.OptionsFormWindowState
            _readMessageWindowState = My.Settings.ReadMessageWindowState
            _searchFormWindowState = My.Settings.SearchFormWindowState
            _emailAutoAddRecipientsOnSend = My.Settings.EmailAutoAddRecipientsOnSend
            _emailShowSenderAsSent = My.Settings.EmailShowSenderAsSent
            _sendNowDelay = My.Settings.SendNowDelay
            _sendNowOnExit = My.Settings.SendNowOnExit
            _replyPostingMode = My.Settings.ReplyPostingMode
            _emailRequestReturnReceipt = My.Settings.EmailRequestReturnReceipt
            _blockRemoteImages = My.Settings.BlockRemoteImages
            _enableLogging = My.Settings.EnableLogging
            _doNotShowEmailRecipientNotEncrypted = My.Settings.DoNotShowEmailRecipientNotEncrypted
            _delayMinutesWhenCannotSend = My.Settings.DelayMinutesWhenCannotSend
            _doNotShowEmailRecipientNoReply = My.Settings.DoNotShowEmailRecipientNoReply
            _trashDaysToRetain = My.Settings.TrashDaysToRetain
            _doNotShowReadReceiptWillNotBeRequested = My.Settings.DoNotShowReadReceiptWillNotBeRequested
            _doNotProcessEmailReceipts = My.Settings.DoNotProcessEmailReceipts
            _defaultNewMessageFontName = My.Settings.DefaultNewMessageFontName
            _defaultNewMessageFontSize = My.Settings.DefaultNewMessageFontSize
            _newMessageBackgroundColor = My.Settings.NewMessageBackgroundColor
            _showMessagePreviewPane = My.Settings.ShowMessagePreviewPane
            _messagePreviewPaneVertical = My.Settings.MessagePreviewPaneVertical
            _messagePreviewPaneSize = My.Settings.MessagePreviewPaneSize
            _indexResetDate = My.Settings.IndexResetDate
            _messageListState = My.Settings.MessageListState
            _singleSpaceEditor = My.Settings.SingleSpaceEditor
            _showEditorSpacingStatus = My.Settings.ShowEditorSpacingStatus
            _messagePreviewLoadDelay = My.Settings.MessagePreviewLoadDelay
            _doNotShowReplyAllBCCNotice = My.Settings.DoNotShowReplyAllBCCNotice
            EmptyTrashOnExit = My.Settings.EmptyTrashOnExit
            DoNotShowAddEmailAccountNotice = My.Settings.DoNotShowAddEmailAccountNotice
            DoNotShowBlockedScriptsNotice = My.Settings.DoNotShowBlockedScriptsNotice
            _addressBookListState = My.Settings.AddressBookListState
            ContactLastSentUpdated = My.Settings.ContactLastSentUpdated
            AutoSpellCheckNewMessage = My.Settings.AutoSpellCheckNewMessage
            DoNotShowRemovedRecipientNotice = My.Settings.DoNotShowRemovedRecipientNotice
            MinimizeToTray = My.Settings.MinimizeToTray
            ShowNoticeForNewMessages = My.Settings.ShowNoticeForNewMessages
            NewMessageNotifySound = My.Settings.NewMessageNotifySound
            KeepSentMessages = My.Settings.KeepSentMessages
            ImageResizePromptFrequency = CType(My.Settings.ImageResizePromptFrequency, ImageResizePromptFrequencyEnum)
            ImageResizeSize = CType(My.Settings.ImageResizeSize, ImageResizeSizeEnum)
            ReadMessageHeaderCompactMode = My.Settings.ReadMessageHeaderCompactMode
            ToolBarsShowText = My.Settings.ToolBarsShowText
            EncryptionVersion = My.Settings.EncryptionVersion
            UseLargeAllAccountDropDown = My.Settings.UseLargeAllAccountDropDown
            MaintainMessageZoom = My.Settings.MaintainMessageZoom
            CountOfDictionariesAvailable = My.Settings.CountOfDictionariesAvailable
            DefaultEmailEncryption = My.Settings.DefaultEmailEncryption
            DoNotShowDecryptedBodyOverwriteWarning = My.Settings.DoNotShowDecryptedBodyOverwriteWarning
            MainFormFilterAutoComplete = New AutoCompleteStringCollection()
            DoNotShowBlockedIFramesNotice = My.Settings.DoNotShowBlockedIFramesNotice
            DoNotShowTipPanel = My.Settings.DoNotShowTipPanel
            ShowReadingZoomBar = My.Settings.ShowReadingZoomBar
            NoticeForNewMessagesSecondsOpen = My.Settings.NoticeForNewMessagesSecondsOpen
            MainWindowLocation = New Point(My.Settings.MainWindowLocationX, My.Settings.MainWindowLocationY)
            MainWindowSize = New Size(My.Settings.MainWindowSizeWidth, My.Settings.MainWindowSizeHeight)
            ReadWindowLocation = New Point(My.Settings.ReadWindowLocationX, My.Settings.ReadWindowLocationY)
            ReadWindowSize = New Size(My.Settings.ReadWindowSizeWidth, My.Settings.ReadWindowSizeHeight)
            ComposeWindowLocation = New Point(My.Settings.ComposeWindowLocationX, My.Settings.ComposeWindowLocationY)
            ComposeWindowSize = New Size(My.Settings.ComposeWindowSizeWidth, My.Settings.ComposeWindowSizeHeight)
            ShowAutoTextComposeWindow = My.Settings.ShowAutoTextComposeWindow
            ReDim EditorCustomColors(15)
            For intCounter As Integer = 0 To 15
                EditorCustomColors(intCounter) = 16777215
            Next
            ComposeAutoTextAreaSplitter = My.Settings.ComposeAutoTextAreaSplitter
            DateFormat = ConvertToInt32(GetSettingString("DateFormat"), My.Settings.DateFormat)
            EmailAutoAddRecipientsTieSMTP = My.Settings.EmailAutoAddRecipientsTieSMTP

            RSSAutoCheckAtStartup = My.Settings.RSSAutoCheckAtStartup
            RSSAutoCheckInterval = My.Settings.RSSAutoCheckInterval
            RSSAutoCheck = My.Settings.RSSAutoCheck
            FolderTreeSplitter = My.Settings.FolderTreeSplitter
            DoNotShowPOP3DownloadErrorNotice = My.Settings.DoNotShowPOP3DownloadErrorNotice

            DoNotShowReadMessageBlockNotice = My.Settings.DoNotShowReadMessageBlockNotice
            DoNotShowMissingSubjectNotice = My.Settings.DoNotShowMissingSubjectNotice
            ShutDownProperly = True '-- first run
            DoNotShowShutDownErrorNotice = My.Settings.DoNotShowShutDownErrorNotice
            WebMessageAttachmentComment = My.Settings.WebMessageAttachmentComment
            ReplyToPlainTextIsPlainText = My.Settings.ReplyToPlainTextIsPlainText
            Try
                FontForPlainText = New Font(My.Settings.PlainTextFontName, My.Settings.PlainTextFontSize)
            Catch ex As Exception
                Log(ex)
                Using rtb As New RichTextBox
                    FontForPlainText = New Font(rtb.Font.Name, 12)
                End Using
            End Try
            AutoZipEmailAttachments = My.Settings.AutoZipEmailAttachments

            MessageExportTrulyMailFakeAddress = My.Settings.MessageExportTrulyMailFakeAddress
            MessageExportFolder = My.Settings.MessageExportFolder
            MasterPasswordHashLong = String.Empty
            DoNotShowSMTPServerConnectionTimeOutErrorNotice = My.Settings.DoNotShowSMTPServerConnectionTimeOutErrorNotice
            DoNotShowPOPServerConnectionTimeOutErrorNotice = My.Settings.DoNotShowPOPServerConnectionTimeOutErrorNotice
            IntraEmailSendDelay = My.Settings.IntraEmailSendDelay
            MessageListAlternatingRowColor = Color.Yellow '-- default
            ContactListAreaVisible = True
            AutoSizeColumnsMessageList = True

            ReadMessagePreviewActionSplitterDistance = 100
            ReadMessagePreviewActionVisible = True
            ReadMessageActionSplitterDistance = 100
            ReadMessageActionVisible = True
            PromptToRecreateEncryptionKeysDays = 90
            PromptToRecreateEncryptionKeysMessages = 30
            PromptToRecreateEncryptionKeysAfter = Date.UtcNow

            AutomaticallyTransmitOnSend = True
            HideFilterAreaOnMainForm = False
            EmailDownloadLimit = False
            EmailDownloadLimitExpireDate = Date.Today.AddDays(-1)

            DisplayErrorIntervalSeconds = 10 '-- default to 10 seconds

            EncryptLocalFiles = LocalFileEncryptionStatus.Decrypted

            AddNoteForProcessingRuleAction = True
            AddNoteWhenChangingSubject = True
            AddNoteWhenSendingReturnReceipt = True

            RecentFolderList = New List(Of String)

            FirstTimeAppIsStarted = True
            EnableVerboseLogging = False '-- reset every startup

        End If


        '-- POP hash table
        If System.IO.File.Exists(GetPOPMessageIDHashTableFilename()) Then
            LoadPOPHashTable()
        End If

        '-- RSS article hash table
        If System.IO.File.Exists(GetRSSMessageIDHashTableFilename()) Then
            LoadRSSHashTable()
        End If

        '-- RSS senderhash table
        If System.IO.File.Exists(GetRSSSenderForRemoteImagesHashTableFilename()) Then
            LoadRSSSenderHashTable()
        End If

        LoadMessageTags()
        LoadProcessingRules()
        LoadAutoTexts()
        LoadRSSFeeds()
        LoadFolderStates()
        CreateReplyModes()
        LoadFolderTreeQuickJumpList()




        '-- Do this last
        MakeBackupCopyOfSettingsFile()

        ProperlyLoaded = True
    End Sub
    Friend Function GetXMLOfAllSettings(removePasswords As Boolean) As System.Xml.XmlDocument
        Try
            Dim xDoc As New Xml.XmlDocument()
            Dim root As Xml.XmlNode
            root = xDoc.AppendChild(xDoc.CreateElement("userSettings"))
            root.AppendChild(CreateSettingsNode(xDoc, "FullName", FullName))
            root.AppendChild(CreateSettingsNode(xDoc, "AutoSendReceive", _autoSendReceive))
            root.AppendChild(CreateSettingsNode(xDoc, "AutoSendReceiveInterval", _autoSendReceiveInterval))
            root.AppendChild(CreateSettingsNode(xDoc, "SpellingDictionary", _dictionaryFilename))
            root.AppendChild(CreateSettingsNode(xDoc, "SpellCheckBeforeSend", _spellCheckBeforeSend))
            root.AppendChild(CreateSettingsNode(xDoc, "SendAndReceiveOnStartup", _sendAndReceiveOnStartup))
            root.AppendChild(CreateSettingsNode(xDoc, "LogFileLocation", _logFileLocation))
            root.AppendChild(CreateSettingsNode(xDoc, "LargeToolbarIcons", _largeToolbarIcons))
            root.AppendChild(CreateSettingsNode(xDoc, "SpellCheckSubject", _spellCheckSubject))
            root.AppendChild(CreateSettingsNode(xDoc, "AutoSaveDrafts", _autoSaveDrafts))
            root.AppendChild(CreateSettingsNode(xDoc, "AutoSaveDraftsMinutes", _autoSaveDraftsMinutes))
            root.AppendChild(CreateSettingsNode(xDoc, "DefaultMessageSubject", _defaultMessageSubject))
            root.AppendChild(CreateSettingsNode(xDoc, "AddressBookWindowState", _addressBookWindowState))
            root.AppendChild(CreateSettingsNode(xDoc, "MainFormWindowState", _mainFormWindowState))
            root.AppendChild(CreateSettingsNode(xDoc, "NewMessageWindowState", _newMessageWindowState))
            root.AppendChild(CreateSettingsNode(xDoc, "OptionsFormWindowState", _optionsFormWindowState))
            root.AppendChild(CreateSettingsNode(xDoc, "ReadMessageWindowState", _readMessageWindowState))
            root.AppendChild(CreateSettingsNode(xDoc, "SearchFormWindowState", _searchFormWindowState))
            root.AppendChild(CreateSettingsNode(xDoc, "EmailAutoAddRecipientsOnSend", _emailAutoAddRecipientsOnSend))
            root.AppendChild(CreateSettingsNode(xDoc, "EmailShowSenderAsSent", _emailShowSenderAsSent))
            root.AppendChild(CreateSettingsNode(xDoc, "SendNowDelay", _sendNowDelay))
            root.AppendChild(CreateSettingsNode(xDoc, "SendNowOnExit", _sendNowOnExit))
            root.AppendChild(CreateSettingsNode(xDoc, "ReplyPostingMode", Convert.ToInt32(_replyPostingMode)))
            root.AppendChild(CreateSettingsNode(xDoc, "RequestReturnReceipt", _emailRequestReturnReceipt))
            root.AppendChild(CreateSettingsNode(xDoc, "BlockRemoteImages", _blockRemoteImages))
            root.AppendChild(CreateSettingsNode(xDoc, "EnableLogging", _enableLogging))
            root.AppendChild(CreateSettingsNode(xDoc, "DelayMinutesWhenCannotSend", _delayMinutesWhenCannotSend))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowEmailRecipientNotEncrypted", _doNotShowEmailRecipientNotEncrypted))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowEmailRecipientNoReply", _doNotShowEmailRecipientNoReply))
            root.AppendChild(CreateSettingsNode(xDoc, "AutoEmptyTrash", _autoEmptyTrash))
            root.AppendChild(CreateSettingsNode(xDoc, "TrashDaysToRetain", _trashDaysToRetain))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowReadReceiptWillNotBeRequested", _doNotShowReadReceiptWillNotBeRequested))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotProcessEmailReceipts", _doNotProcessEmailReceipts))
            root.AppendChild(CreateSettingsNode(xDoc, "DefaultNewMessageFontName", _defaultNewMessageFontName))
            root.AppendChild(CreateSettingsNode(xDoc, "DefaultNewMessageFontSize", _defaultNewMessageFontSize))
            root.AppendChild(CreateSettingsNode(xDoc, "NewMessageBackgroundColor", _newMessageBackgroundColor.ToArgb))
            root.AppendChild(CreateSettingsNode(xDoc, "ShowMessagePreviewPane", _showMessagePreviewPane))
            root.AppendChild(CreateSettingsNode(xDoc, "MessagePreviewPaneVertical", _messagePreviewPaneVertical))
            root.AppendChild(CreateSettingsNode(xDoc, "MessagePreviewPaneSize", _messagePreviewPaneSize))
            root.AppendChild(CreateSettingsNode(xDoc, "IndexResetDate", _indexResetDate))
            root.AppendChild(CreateSettingsNode(xDoc, "MessageListState", _messageListState))
            root.AppendChild(CreateSettingsNode(xDoc, "SingleSpaceEditor", _singleSpaceEditor))
            root.AppendChild(CreateSettingsNode(xDoc, "ShowEditorSpacingStatus", _showEditorSpacingStatus))
            root.AppendChild(CreateSettingsNode(xDoc, "MessagePreviewLoadDelay", _messagePreviewLoadDelay))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowReplyAllBCCNotice", _doNotShowReplyAllBCCNotice))
            root.AppendChild(CreateSettingsNode(xDoc, "EmptyTrashOnExit", EmptyTrashOnExit))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowAddEmailAccountNotice", DoNotShowAddEmailAccountNotice))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowBlockedScriptsNotice", DoNotShowBlockedScriptsNotice))
            root.AppendChild(CreateSettingsNode(xDoc, "AddressBookListState", _addressBookListState))
            root.AppendChild(CreateSettingsNode(xDoc, "ContactLastSentUpdated", ContactLastSentUpdated))
            root.AppendChild(CreateSettingsNode(xDoc, "AutoSpellCheckNewMessage", AutoSpellCheckNewMessage))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowRemovedRecipientNotice", DoNotShowRemovedRecipientNotice))
            root.AppendChild(CreateSettingsNode(xDoc, "MinimizeToTray", MinimizeToTray))
            root.AppendChild(CreateSettingsNode(xDoc, "ShowNoticeForNewMessages", ShowNoticeForNewMessages))
            root.AppendChild(CreateSettingsNode(xDoc, "NewMessageNotifySound", NewMessageNotifySound))
            root.AppendChild(CreateSettingsNode(xDoc, "KeepSentMessages", KeepSentMessages))
            root.AppendChild(CreateSettingsNode(xDoc, "ImageResizePromptFrequency", ImageResizePromptFrequency))
            root.AppendChild(CreateSettingsNode(xDoc, "ImageResizeSize", ImageResizeSize))
            root.AppendChild(CreateSettingsNode(xDoc, "ReadMessageHeaderCompactMode", ReadMessageHeaderCompactMode))
            root.AppendChild(CreateSettingsNode(xDoc, "ToolBarsShowText", ToolBarsShowText))
            root.AppendChild(CreateSettingsNode(xDoc, "EncryptionVersion", EncryptionVersion))
            root.AppendChild(CreateSettingsNode(xDoc, "UseLargeAllAccountDropDown", UseLargeAllAccountDropDown))
            root.AppendChild(CreateSettingsNode(xDoc, "MaintainMessageZoom", MaintainMessageZoom))
            root.AppendChild(CreateSettingsNode(xDoc, "CountOfDictionariesAvailable", CountOfDictionariesAvailable))
            root.AppendChild(CreateSettingsNode(xDoc, "DefaultEmailEncryption", DefaultEmailEncryption))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowDecryptedBodyOverwriteWarning", DoNotShowDecryptedBodyOverwriteWarning))
            root.AppendChild(CreateSettingsNode(xDoc, "MainFormFilterAutoComplete", MainFormFilterAutoComplete))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowBlockedIFramesNotice", DoNotShowBlockedIFramesNotice))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowTipPanel", DoNotShowTipPanel))
            root.AppendChild(CreateSettingsNode(xDoc, "ShowReadingZoomBar", ShowReadingZoomBar))
            root.AppendChild(CreateSettingsNode(xDoc, "NoticeForNewMessagesSecondsOpen", NoticeForNewMessagesSecondsOpen))
            root.AppendChild(CreateSettingsNode(xDoc, "MainWindowLocationX", MainWindowLocation.X))
            root.AppendChild(CreateSettingsNode(xDoc, "MainWindowLocationY", MainWindowLocation.Y))
            root.AppendChild(CreateSettingsNode(xDoc, "MainWindowSizeWidth", MainWindowSize.Width))
            root.AppendChild(CreateSettingsNode(xDoc, "MainWindowSizeHeight", MainWindowSize.Height))
            root.AppendChild(CreateSettingsNode(xDoc, "ReadWindowLocationX", ReadWindowLocation.X))
            root.AppendChild(CreateSettingsNode(xDoc, "ReadWindowLocationY", ReadWindowLocation.Y))
            root.AppendChild(CreateSettingsNode(xDoc, "ReadWindowSizeWidth", ReadWindowSize.Width))
            root.AppendChild(CreateSettingsNode(xDoc, "ReadWindowSizeHeight", ReadWindowSize.Height))
            root.AppendChild(CreateSettingsNode(xDoc, "ComposeWindowLocationX", ComposeWindowLocation.X))
            root.AppendChild(CreateSettingsNode(xDoc, "ComposeWindowLocationY", ComposeWindowLocation.Y))
            root.AppendChild(CreateSettingsNode(xDoc, "ComposeWindowSizeWidth", ComposeWindowSize.Width))
            root.AppendChild(CreateSettingsNode(xDoc, "ComposeWindowSizeHeight", ComposeWindowSize.Height))
            root.AppendChild(CreateSettingsNode(xDoc, "ShowAutoTextComposeWindow", ShowAutoTextComposeWindow))
            root.AppendChild(CreateSettingsNode(xDoc, "EditorCustomColors", GetEditorCustomColorsToSave()))
            root.AppendChild(CreateSettingsNode(xDoc, "ComposeAutoTextAreaSplitter", ComposeAutoTextAreaSplitter))
            root.AppendChild(CreateSettingsNode(xDoc, "DateFormat", DateFormat))
            root.AppendChild(CreateSettingsNode(xDoc, "EmailAutoAddRecipientsTieSMTP", EmailAutoAddRecipientsTieSMTP))
            root.AppendChild(CreateSettingsNode(xDoc, "RSSAutoCheckAtStartup", RSSAutoCheckAtStartup))
            root.AppendChild(CreateSettingsNode(xDoc, "RSSAutoCheckInterval", RSSAutoCheckInterval))
            root.AppendChild(CreateSettingsNode(xDoc, "RSSAutoCheck", RSSAutoCheck))
            root.AppendChild(CreateSettingsNode(xDoc, "FolderTreeSplitter", FolderTreeSplitter))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowPOP3DownloadErrorNotice", DoNotShowPOP3DownloadErrorNotice))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowReadMessageBlockNotice", DoNotShowReadMessageBlockNotice))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowMissingSubjectNotice", DoNotShowMissingSubjectNotice))
            root.AppendChild(CreateSettingsNode(xDoc, "ShutDownProperly", ShutDownProperly))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowShutDownErrorNotice", DoNotShowShutDownErrorNotice))
            root.AppendChild(CreateSettingsNode(xDoc, "ReplyToPlainTextIsPlainText", ReplyToPlainTextIsPlainText))
            root.AppendChild(CreateSettingsNode(xDoc, "PlainTextFontName", FontForPlainText.FontFamily.Name))
            root.AppendChild(CreateSettingsNode(xDoc, "PlainTextFontSize", FontForPlainText.Size))
            root.AppendChild(CreateSettingsNode(xDoc, "AutoZipEmailAttachments", AutoZipEmailAttachments))
            root.AppendChild(CreateSettingsNode(xDoc, "MessageExportTrulyMailFakeAddress", MessageExportTrulyMailFakeAddress))
            root.AppendChild(CreateSettingsNode(xDoc, "MessageExportFolder", MessageExportFolder))

            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowSMTPServerConnectionTimeOutErrorNotice", DoNotShowSMTPServerConnectionTimeOutErrorNotice))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowPOPServerConnectionTimeOutErrorNotice", DoNotShowPOPServerConnectionTimeOutErrorNotice))
            root.AppendChild(CreateSettingsNode(xDoc, "IntraEmailSendDelay", IntraEmailSendDelay))
            root.AppendChild(CreateSettingsNode(xDoc, "MessageListAlternatingRowColor", MessageListAlternatingRowColor.ToArgb))
            root.AppendChild(CreateSettingsNode(xDoc, "ContactListAreaVisible", ContactListAreaVisible))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowBrowserFullScreenTipPanel", DoNotShowBrowserFullScreenTipPanel))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowBrowserFullScreenCtrlDeletePanel", DoNotShowBrowserFullScreenCtrlDeletePanel))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowBrowserFullScreenShiftCtrlDeleteTipPanel", DoNotShowBrowserFullScreenShiftCtrlDeleteTipPanel))

            root.AppendChild(CreateSettingsNode(xDoc, "AutoSizeColumnsMessageList", AutoSizeColumnsMessageList))
            root.AppendChild(CreateSettingsNode(xDoc, "LastKnownMainScreenBoundsWidth", Screen.PrimaryScreen.Bounds.Width))
            root.AppendChild(CreateSettingsNode(xDoc, "LastKnownMainScreenBoundsHeight", Screen.PrimaryScreen.Bounds.Height))
            root.AppendChild(CreateSettingsNode(xDoc, "LastKnownNumberOfScreens", Screen.AllScreens.Length))
            root.AppendChild(CreateSettingsNode(xDoc, "ReadMessagePreviewActionSplitterDistance", ReadMessagePreviewActionSplitterDistance))
            root.AppendChild(CreateSettingsNode(xDoc, "ReadMessagePreviewActionVisible", ReadMessagePreviewActionVisible))
            root.AppendChild(CreateSettingsNode(xDoc, "ReadMessageActionSplitterDistance", ReadMessageActionSplitterDistance))
            root.AppendChild(CreateSettingsNode(xDoc, "ReadMessageActionVisible", ReadMessageActionVisible))
            root.AppendChild(CreateSettingsNode(xDoc, "DoNotShowRSSErrorListPrompt", DoNotShowRSSErrorListPrompt))
            root.AppendChild(CreateSettingsNode(xDoc, "MessagesSentOnCurrentEncryptionKey", MessagesSentOnCurrentEncryptionKey))
            root.AppendChild(CreateSettingsNode(xDoc, "PromptToRecreateEncryptionKeysDays", PromptToRecreateEncryptionKeysDays))
            root.AppendChild(CreateSettingsNode(xDoc, "PromptToRecreateEncryptionKeysMessages", PromptToRecreateEncryptionKeysMessages))
            root.AppendChild(CreateSettingsNode(xDoc, "PromptToRecreateEncryptionKeysAfter", PromptToRecreateEncryptionKeysAfter))

            root.AppendChild(CreateSettingsNode(xDoc, "AutomaticallyTransmitOnSend", AutomaticallyTransmitOnSend))
            root.AppendChild(CreateSettingsNode(xDoc, "HideFilterAreaOnMainForm", HideFilterAreaOnMainForm))
            root.AppendChild(CreateSettingsNode(xDoc, "EmailDownloadLimit", EmailDownloadLimit))
            root.AppendChild(CreateSettingsNode(xDoc, "EmailDownloadLimitExpireDate", EmailDownloadLimitExpireDate))

            root.AppendChild(CreateSettingsNode(xDoc, "HideOutboxCountPastToday", HideOutboxCountPastToday))
            root.AppendChild(CreateSettingsNode(xDoc, "DisplayErrorIntervalSeconds", DisplayErrorIntervalSeconds))

            root.AppendChild(CreateSettingsNode(xDoc, "EncryptLocalFiles", EncryptLocalFiles))

            root.AppendChild(CreateSettingsNode(xDoc, "AddNoteForProcessingRuleAction", AddNoteForProcessingRuleAction))
            root.AppendChild(CreateSettingsNode(xDoc, "AddNoteWhenChangingSubject", AddNoteWhenChangingSubject))
            root.AppendChild(CreateSettingsNode(xDoc, "AddNoteWhenSendingReturnReceipt", AddNoteWhenSendingReturnReceipt))
            root.AppendChild(CreateSettingsNode(xDoc, "RecentFolderList", GetRecentFolderListToSave))
            root.AppendChild(CreateSettingsNode(xDoc, "UseFallbackModeWhen", UseFallbackModeWhen))
            root.AppendChild(CreateSettingsNode(xDoc, "EnableVerboseLogging", EnableVerboseLogging))
            root.AppendChild(CreateSettingsNode(xDoc, "DefaultSendLaterTime", DefaultSendLaterTime))
            root.AppendChild(CreateSettingsNode(xDoc, "DarkMode", DarkMode))
            root.AppendChild(CreateSettingsNode(xDoc, "RemoveDiacriticsWhenReceiving", RemoveDiacriticsWhenReceiving))
            root.AppendChild(CreateSettingsNode(xDoc, "ShowMessageEncryptionPassword", ShowMessageEncryptionPassword))
            root.AppendChild(CreateSettingsNode(xDoc, "PreviewPaneToReadAsPlainText", PreviewPaneToReadAsPlainText))
            root.AppendChild(CreateSettingsNode(xDoc, "SendDelayInMinutes", SendDelayInMinutes))


            If m_strFileEncryptionPassword IsNot Nothing AndAlso m_strFileEncryptionPassword.Length > 0 Then
                root.AppendChild(CreateSettingsNode(xDoc, "FileEncryptionPassword", m_strFileEncryptionPassword))
            Else
                '-- do not write it out
            End If


            root.AppendChild(GetAccountsToSave(xDoc, removePasswords))
            'root.AppendChild(GetPublicProfileToSave())
            root.AppendChild(GetMessageTagsToSave(xDoc))
            root.AppendChild(GetProcessingRulesToSave(xDoc))
            root.AppendChild(GetAutoTextsToSave(xDoc))
            root.AppendChild(GetRSSFeedsToSave(xDoc))
            root.AppendChild(GetFolderStatesToSave(xDoc))
            root.AppendChild(GetDoNotSendAddressListNodeToSave(xDoc))
            root.AppendChild(GetFolderTreeJumpItemsToSave(xDoc))


            '-- Now, remove passwords if requested
            Return xDoc

        Catch ex As Exception
            Log(ex)
        End Try
    End Function

#Region " Setting Properties (all public) "
    Public Property PreviewPaneToReadAsPlainText As Boolean
    Public Property ShowMessageEncryptionPassword As Boolean
    Public Property RemoveDiacriticsWhenReceiving As Boolean
    Public Property DarkMode As Boolean
    Public Property DefaultSendLaterTime As Date
    Public Property EnableVerboseLogging As Boolean
    Public Property UseFallbackModeWhen As UseFallbackModeEnum
    Public Property RecentFolderList As List(Of String)
    Public Property AddNoteForProcessingRuleAction As Boolean
    Public Property AddNoteWhenChangingSubject As Boolean
    Public Property AddNoteWhenSendingReturnReceipt As Boolean
    Public Property DisplayErrorIntervalSeconds As Integer
    Public Property FullName As String '-- TrulyMail full name (must keep because there are old TrulyMail messages

    '-- Rule: Never persist the master password
    '   but OK to persist the fileencryptionpassword as encrypted with masterpassword
    '   We do store the salted masterpassword hash which is still a problem but the goal 
    '   has always been: We protect messages in transit but not on the user's local machine
    '   The only reason we put in the fileencryption was because messags might be stored on a cloud drive
    '   and therefore are not on user's computer
    Private m_strMasterPassword As String
    Public Property MasterPassword As String
        Get
            Return m_strMasterPassword
        End Get
        Set(value As String)
            '-- When we change the MasterPassword, we must decrypt the FileEncryptionPassword with the previous MasterPassword and re-encrypt it against the new MasterPassword 
            If m_strFileEncryptionPassword IsNot Nothing AndAlso m_strFileEncryptionPassword.Length > 0 Then
                If IsTextEncrypted(m_strFileEncryptionPassword) Then
                    Dim strTemp As String = DecryptTextSymetric(m_strMasterPassword, m_strFileEncryptionPassword) '-- decrypt to temp string
                    m_strFileEncryptionPassword = EncryptTextSymetric(value, strTemp, EncryptionLevelEnum.Version5Strong) '-- re-encrypt to proper variable
                End If
            End If

            '-- if we have a master password then we use it for encrypting settings file
            Me.EncryptSettingsFile = value.Length > 0

            m_strMasterPassword = value

        End Set
    End Property

    '-- This is a locally generated password. We use this so we can encrypt to one password and if the user changes the password
    '   we do not need to re-encrypt every file, we just need to re-encrypt this key. So, this key is stored only when it is encrypted
    '   by the master password 
    Private m_strFileEncryptionPassword As String '-- We actually store it in memory encrypted, then decrypt it in the following function
    Friend Function GetFileEncryptionPassword() As String
        Return DecryptTextSymetric(AppSettings.MasterPassword, m_strFileEncryptionPassword)
    End Function


    Private m_EncryptLocalFiles As LocalFileEncryptionStatus
    Public Property EncryptLocalFiles As LocalFileEncryptionStatus
        Get
            Return m_EncryptLocalFiles
        End Get
        Set(value As LocalFileEncryptionStatus)
            If value = LocalFileEncryptionStatus.Encrypting Then

                If m_strFileEncryptionPassword Is Nothing OrElse m_strFileEncryptionPassword.Length = 0 Then
                    '-- create a new file encryption password by hashing a new guid (yes, lazy, but this is not to protect from NSA)
                    '   but only if there is no existing password (don't change since we might have files encrypted against the existing password
                    m_strFileEncryptionPassword = EncryptTextSymetric(m_strMasterPassword, Crypto.GenerateRandomPassword, EncryptionLevelEnum.Version5Strong) '-- Encrypt it just for good measure
                End If
            End If

            m_EncryptLocalFiles = value

            Select Case value
                Case LocalFileEncryptionStatus.Decrypted
                    EncryptSettingsFile = False
                Case Else
                    EncryptSettingsFile = True '-- anything else means we need the settings file encrypted 
            End Select

            Me.Save() '-- always save immediately after changing this property
        End Set
    End Property
    Public Property SendDelayInMinutes As Integer = 60
    Public Property FolderTreeQuickJumpList As New List(Of String)
    Public Property FirstTimeAppIsStarted As Boolean
    Public Property HideOutboxCountPastToday As Boolean '-- True to ignore messages in outbox to be sent later than today when counting to show on node
    Public Property DoNotSendAddressList As New List(Of DoNotSendEmailAddress) '-- contains collection of email addresses which should never be sent to
    Public Property EmailDownloadLimit As Boolean '-- true = limit to previous 24 hours
    Public Property EmailDownloadLimitExpireDate As Date '-- date on which user should be re-prompted to set limit option
    Public Property HideFilterAreaOnMainForm As Boolean
    Public Property AutomaticallyTransmitOnSend As Boolean '-- true to actually send when user clicks send
    Public Property PromptToRecreateEncryptionKeysAfter As Date '-- Do not display prompt before this date
    Public Property PromptToRecreateEncryptionKeysDays As Integer
    Public Property PromptToRecreateEncryptionKeysMessages As Integer
    Public Property MessagesSentOnCurrentEncryptionKey As Integer
    Public Property DoNotShowRSSErrorListPrompt As Boolean
    Public Property LastSelectedFolderInFolderBrowser As String
    Public Property ReadMessagePreviewActionSplitterDistance As Integer
    Public Property ReadMessagePreviewActionVisible As Boolean
    Public Property ReadMessageActionSplitterDistance As Integer
    Public Property ReadMessageActionVisible As Boolean
    Public Property AllReplyModes As List(Of ReplyMode) '-- not persisted, just hard-coded
    Public Property AutoSizeColumnsMessageList As Boolean
    Public Property DoNotShowBrowserFullScreenTipPanel As Boolean
    Public Property DoNotShowBrowserFullScreenCtrlDeletePanel As Boolean
    Public Property DoNotShowBrowserFullScreenShiftCtrlDeleteTipPanel As Boolean
    Public Property ContactListAreaVisible As Boolean
    Public Property MessageListAlternatingRowColor As Color
    Public Property DoNotShowPOPServerConnectionTimeOutErrorNotice As Boolean
    Public Property DoNotShowSMTPServerConnectionTimeOutErrorNotice As Boolean
    Public Property MasterPasswordHashLong As String
    Public Property EncryptSettingsFile As Boolean '-- True if file is stored encrypted
    Public Property MessageExportFolder As String
    Public Property MessageExportTrulyMailFakeAddress As String
    'Public Property NewsletterFeatureEnabled As Boolean'-- Now using PremiumUser
    Public Property AutoZipEmailAttachments As Boolean
    Public Property FontForPlainText As Font
    'Public Property WebPageMonitorFeatureEnabled As Boolean'-- Now using PremiumUser
    Public Property ReplyToPlainTextIsPlainText As Boolean
    Public Property WebMessageAttachmentComment As String '-- not saved, just app setting now '-- we are going to add an unencrypted entry with a comment to tell users to use a zip utility to open the attachments
    Public Property DoNotShowShutDownErrorNotice As Boolean
    Public Property ShutDownProperly As Boolean
    Public Property DoNotShowMissingSubjectNotice As Boolean
    Public Property DoNotShowReadMessageBlockNotice As Boolean

    'Public Property ServerMessageNotificationFeatureEnabled As Boolean'-- Now using PremiumUser
    Public Property DoNotShowPOP3DownloadErrorNotice As Boolean
    Public Property FolderTreeSplitter As Integer
    Public Property FolderStates As List(Of FolderState)
    Public Property RSSSenderAllowRemoteImages As New Hashtable
    Public Property RSSMessagesReceived As New Hashtable
    Public Property RSSAutoCheck As Boolean
    Public Property RSSAutoCheckInterval As Integer
    Public Property RSSAutoCheckAtStartup As Boolean
    Public Property RSSFeeds As New List(Of RSSFeed)
    Public Property EmailAutoAddRecipientsTieSMTP As Boolean
    Public Property DateFormat As Integer
    Public Property ComposeAutoTextAreaSplitter As Integer
    Public Property EditorCustomColors As Integer()
    Public Property ShowAutoTextComposeWindow As Boolean
    Public Property AutoTexts As List(Of AutoText)
    Public Property ReadWindowState As FormWindowState
    Public Property ComposeWindowState As FormWindowState
    Public Property ComposeWindowSize As Size
    Public Property ComposeWindowLocation As Point
    Public Property ReadWindowSize As Size
    Public Property ReadWindowLocation As Point
    Public Property MainWindowSize As Size
    Public Property MainWindowLocation As Point
    Public Property NoticeForNewMessagesSecondsOpen As Decimal
    Public Property ShowReadingZoomBar As Boolean
    Public Property DoNotShowTipPanel As Boolean
    Public Property DoNotShowBlockedIFramesNotice As Boolean
    Public Property MainFormFilterAutoComplete As AutoCompleteStringCollection
    Public Property DoNotShowDecryptedBodyOverwriteWarning As Boolean
    Public Property DefaultEmailEncryption As Integer
    Public Property CountOfDictionariesAvailable As Integer
    Public Property MaintainMessageZoom As Boolean
    Public Property UseLargeAllAccountDropDown As Boolean
    Public Property EncryptionVersion As Integer
    Public Property ProcessingRules As New List(Of ProcessingRule)
    Public Property ToolBarsShowText As Boolean
    Public Property ReadMessageHeaderCompactMode As Boolean
    Public Property ImageResizePromptFrequency As ImageResizePromptFrequencyEnum
    Public Property ImageResizeSize As ImageResizeSizeEnum
    Public Property KeepSentMessages As Boolean
    Public Property NewMessageNotifySound As String
    Public Property ShowNoticeForNewMessages As Boolean
    Public Property MinimizeToTray As Boolean
    Public Property DoNotShowRemovedRecipientNotice As Boolean
    Public Property AutoSpellCheckNewMessage As Boolean
    Public Property ContactLastSentUpdated As Date
    Private Property _addressBookListState As String
    Public Property AddressBookListState() As Byte()
        Get
            Return Convert.FromBase64String(_addressBookListState)
        End Get
        Set(ByVal value As Byte())
            _addressBookListState = Convert.ToBase64String(value)
        End Set
    End Property
    Public Property DoNotShowBlockedScriptsNotice As Boolean
    Public Property DoNotShowAddEmailAccountNotice As Boolean
    Public Property EmptyTrashOnExit As Boolean
    Public Property IntraEmailSendDelay As Integer
        Get
            Return _intraEmailSendDelay
        End Get
        Set(value As Integer)
            If value < 0 Then
                _intraEmailSendDelay = 0
            Else
                _intraEmailSendDelay = value
            End If
        End Set
    End Property

    Public Property DoNotShowReplyAllBCCNotice() As Boolean
        Get
            Return _doNotShowReplyAllBCCNotice
        End Get
        Set(ByVal value As Boolean)
            _doNotShowReplyAllBCCNotice = value
        End Set
    End Property
    Public Property MessagePreviewLoadDelay() As Decimal
        Get
            Return _messagePreviewLoadDelay
        End Get
        Set(ByVal value As Decimal)
            _messagePreviewLoadDelay = value
        End Set
    End Property
    Public Property MessageTags() As List(Of MessageTag)
        Get
            Return _messageTags
        End Get
        Set(ByVal value As List(Of MessageTag))
            _messageTags = value
        End Set
    End Property
    Public Property ShowEditorSpacingStatus() As Boolean
        Get
            Return _showEditorSpacingStatus
        End Get
        Set(ByVal value As Boolean)
            _showEditorSpacingStatus = value
        End Set
    End Property
    Public Property SingleSpaceEditor() As Boolean
        Get
            Return _singleSpaceEditor
        End Get
        Set(ByVal value As Boolean)
            _singleSpaceEditor = value
        End Set
    End Property
    Public Property MessageListState() As Byte()
        Get
            Return Convert.FromBase64String(_messageListState)
        End Get
        Set(ByVal value As Byte())
            _messageListState = Convert.ToBase64String(value)
        End Set
    End Property
    Public Property IndexResetDate() As Date
        Get
            Return _indexResetDate
        End Get
        Set(ByVal value As Date)
            _indexResetDate = value
        End Set
    End Property
    Public Property MessagePreviewPaneSize() As Integer
        Get
            Return _messagePreviewPaneSize
        End Get
        Set(ByVal value As Integer)
            _messagePreviewPaneSize = value
        End Set
    End Property
    Public Property MessagePreviewPaneVertical() As Boolean
        Get
            Return _messagePreviewPaneVertical
        End Get
        Set(ByVal value As Boolean)
            _messagePreviewPaneVertical = value
        End Set
    End Property
    Public Property ShowMessagePreviewPane() As Boolean
        Get
            Return _showMessagePreviewPane
        End Get
        Set(ByVal value As Boolean)
            _showMessagePreviewPane = value
        End Set
    End Property
    Public Property NewMessageBackgroundColor() As Color
        Get
            Return _newMessageBackgroundColor
        End Get
        Set(ByVal value As Color)
            _newMessageBackgroundColor = value
        End Set
    End Property
    Public Property DefaultNewMessageFontName() As String
        Get
            Return _defaultNewMessageFontName
        End Get
        Set(ByVal value As String)
            _defaultNewMessageFontName = value
        End Set
    End Property
    Public Property DefaultNewMessageFontSize() As Integer
        Get
            Return _defaultNewMessageFontSize
        End Get
        Set(ByVal value As Integer)
            If value > 7 Then
                _defaultNewMessageFontSize = 7
            ElseIf value < 1 Then
                _defaultNewMessageFontSize = 1
            Else
                _defaultNewMessageFontSize = value
            End If
        End Set
    End Property
    Public Property DoNotProcessEmailReceipts() As Boolean
        Get
            Return _doNotProcessEmailReceipts
        End Get
        Set(ByVal value As Boolean)
            _doNotProcessEmailReceipts = value
        End Set
    End Property
    Public Property DoNotShowReadReceiptWillNotBeRequested() As Boolean
        Get
            Return _doNotShowReadReceiptWillNotBeRequested
        End Get
        Set(ByVal value As Boolean)
            _doNotShowReadReceiptWillNotBeRequested = value
        End Set
    End Property
    Public Property TrashDaysToRetain() As Integer
        Get
            Return _trashDaysToRetain
        End Get
        Set(ByVal value As Integer)
            If value <= 0 Then
                _trashDaysToRetain = 0
            Else
                _trashDaysToRetain = value
            End If
        End Set
    End Property
    Public Property AutoEmptyTrash() As Boolean
        Get
            Return _autoEmptyTrash
        End Get
        Set(ByVal value As Boolean)
            _autoEmptyTrash = value
        End Set
    End Property
    Public Property DelayMinutesWhenCannotSend() As Integer
        Get
            Return _delayMinutesWhenCannotSend
        End Get
        Set(ByVal value As Integer)
            _delayMinutesWhenCannotSend = value
        End Set
    End Property
    Public Property EnableLogging() As Boolean
        Get
            Return _enableLogging
        End Get
        Set(ByVal value As Boolean)
            _enableLogging = value
        End Set
    End Property
    Public Property BlockRemoteImages() As Boolean
        Get
            Return _blockRemoteImages
        End Get
        Set(ByVal value As Boolean)
            _blockRemoteImages = value
        End Set
    End Property
    Public Property EmailRequestReturnReceipt() As Boolean
        Get
            Return _emailRequestReturnReceipt
        End Get
        Set(ByVal value As Boolean)
            _emailRequestReturnReceipt = value
        End Set
    End Property
    Public Property ReplyPostingMode() As ReplyPostModeEnum
        Get
            Return _replyPostingMode
        End Get
        Set(ByVal value As ReplyPostModeEnum)
            _replyPostingMode = value
        End Set
    End Property
    Public Property SendNowOnExit() As Boolean
        Get
            Return _sendNowOnExit
        End Get
        Set(ByVal value As Boolean)
            _sendNowOnExit = value
        End Set
    End Property
    Public Property SendNowDelay() As Integer
        Get
            Return _sendNowDelay
        End Get
        Set(ByVal value As Integer)
            If value <= 0 Then
                _sendNowDelay = 0
            Else
                _sendNowDelay = value
            End If
        End Set
    End Property
    Public Property EmailMessagesReceived() As Hashtable
        Get
            Return _popMessageIDsReceived
        End Get
        Set(ByVal value As Hashtable)
            _popMessageIDsReceived = value
        End Set
    End Property
    Public Property EmailAutoAddRecipientsOnSend() As Boolean
        Get
            Return _emailAutoAddRecipientsOnSend
        End Get
        Set(ByVal value As Boolean)
            _emailAutoAddRecipientsOnSend = value
        End Set
    End Property
    Public Property EmailShowSenderAsSent() As Boolean
        Get
            Return _emailShowSenderAsSent
        End Get
        Set(ByVal value As Boolean)
            _emailShowSenderAsSent = value
        End Set
    End Property
    Public Property SMTPProfiles() As List(Of SMTPProfile)
        Get
            Return _smtpProfiles
        End Get
        Set(ByVal value As List(Of SMTPProfile))
            _smtpProfiles = value
        End Set
    End Property
    Public Property POPProfiles() As List(Of POPProfile)
        Get
            Return _popProfiles
        End Get
        Set(ByVal value As List(Of POPProfile))
            _popProfiles = value
        End Set
    End Property
    Public Property AddressBookWindowState() As FormWindowState
        Get
            Return _addressBookWindowState
        End Get
        Set(ByVal value As FormWindowState)
            _addressBookWindowState = value
        End Set
    End Property
    Public Property MainFormWindowState() As FormWindowState
        Get
            Return _mainFormWindowState
        End Get
        Set(ByVal value As FormWindowState)
            _mainFormWindowState = value
        End Set
    End Property
    Public Property NewMessageWindowState() As FormWindowState
        Get
            Return _newMessageWindowState
        End Get
        Set(ByVal value As FormWindowState)
            _newMessageWindowState = value
        End Set
    End Property
    Public Property OptionsFormWindowState() As FormWindowState
        Get
            Return _optionsFormWindowState
        End Get
        Set(ByVal value As FormWindowState)
            _optionsFormWindowState = value
        End Set
    End Property
    Public Property ReadMessageWindowState() As FormWindowState
        Get
            Return _readMessageWindowState
        End Get
        Set(ByVal value As FormWindowState)
            _readMessageWindowState = value
        End Set
    End Property
    Public Property SearchFormWindowState() As FormWindowState
        Get
            Return _searchFormWindowState
        End Get
        Set(ByVal value As FormWindowState)
            _searchFormWindowState = value
        End Set
    End Property
    Public Property DefaultMessageSubject() As String
        Get
            Return _defaultMessageSubject
        End Get
        Set(ByVal value As String)
            _defaultMessageSubject = value
        End Set
    End Property
    Public Property AutoSaveDraftsMinutes() As Integer
        Get
            Return _autoSaveDraftsMinutes
        End Get
        Set(ByVal value As Integer)
            _autoSaveDraftsMinutes = value
        End Set
    End Property
    Public Property AutoSaveDrafts() As Boolean
        Get
            Return _autoSaveDrafts
        End Get
        Set(ByVal value As Boolean)
            _autoSaveDrafts = value
        End Set
    End Property
    Public Property SpellCheckSubject() As Boolean
        Get
            Return _spellCheckSubject
        End Get
        Set(ByVal value As Boolean)
            _spellCheckSubject = value
        End Set
    End Property

    Public Property LargeToolbarIcons() As Boolean
        Get
            Return _largeToolbarIcons
        End Get
        Set(ByVal value As Boolean)
            _largeToolbarIcons = value
        End Set
    End Property
    Public ReadOnly Property PortableProfile() As Boolean
        Get
            Return True '-- In TM 7, there is only portable version
        End Get
    End Property
    Public Property LogFileLocation() As String
        Get
            Return _logFileLocation
        End Get
        Set(ByVal value As String)
            _logFileLocation = value
        End Set
    End Property
    Public Property DoNotShowEmailRecipientNoReply() As Boolean
        Get
            Return _doNotShowEmailRecipientNoReply
        End Get
        Set(ByVal value As Boolean)
            _doNotShowEmailRecipientNoReply = value
        End Set
    End Property
    Public Property DoNotShowEmailRecipientNotEncrypted() As Boolean
        Get
            Return _doNotShowEmailRecipientNotEncrypted
        End Get
        Set(ByVal value As Boolean)
            _doNotShowEmailRecipientNotEncrypted = value
        End Set
    End Property
    Public Property AutoSendReceive() As Boolean
        Get
            Return _autoSendReceive
        End Get
        Set(ByVal value As Boolean)
            _autoSendReceive = value
        End Set
    End Property
    Public Property AutoSendReceiveInterval() As Integer
        Get
            If _autoSendReceiveInterval < 1 Then
                Return 1
            Else
                Return _autoSendReceiveInterval
            End If
        End Get
        Set(ByVal value As Integer)
            _autoSendReceiveInterval = value
        End Set
    End Property
    Public Property SpellCheckBeforeSend() As Boolean
        Get
            Return _spellCheckBeforeSend
        End Get
        Set(ByVal value As Boolean)
            _spellCheckBeforeSend = value
        End Set
    End Property
    Public Property DictionaryFilename() As String
        Get
            Return _dictionaryFilename
        End Get
        Set(ByVal value As String)
            _dictionaryFilename = value
        End Set
    End Property
    Public Property SendAndReceiveOnStartup() As Boolean
        Get
            Return _sendAndReceiveOnStartup
        End Get
        Set(ByVal value As Boolean)
            _sendAndReceiveOnStartup = value
        End Set
    End Property
#End Region
    Public Sub Save()
        '-- Save settings to disk, if properly loaded
        If ProperlyLoaded Then
            _xmlDocument = GetXMLOfAllSettings(False)


            '-- save settings file
            If EncryptSettingsFile Then
                '-- must encrypt first, then save
                Dim strDecryptedContents As String = _xmlDocument.OuterXml
                Dim strEncryptedContents As String = EncryptTextSymetric(EncryptionPassword, strDecryptedContents, EncryptionLevelEnum.Version5Strong)

                System.IO.File.WriteAllText(_profileSettingsFilePath, strEncryptedContents)
            Else
                _xmlDocument.Save(_profileSettingsFilePath)
            End If

            'todo: Should encrypt everything, including the following

            '-- save in separate file
            SavePOPHashTable()
            SaveRSSHashTable()
            SaveRSSSenderHashTable()
        End If

    End Sub
    Private Const MESSAGE_STORE_ROOT_REPLACEMENT_CODE As String = "[MESSAGESTOREROOT]"
    Public Function LoadRecentFolderListFromStorage(stored As String) As List(Of String)
        Dim lstReturn As New List(Of String)
        Dim arr() As String = stored.Split(DELIMITER)
        If stored.Length > 0 Then
            For intCounter As Integer = 0 To arr.Count - 1
                lstReturn.Add(arr(intCounter))
            Next
        End If

        Return lstReturn
    End Function
    Public Function GetRecentFolderListToSave() As String
        Dim strReturn As String = String.Empty
        Dim intCounter As Integer
        Dim intItemCount As Integer
        Dim intMax As Integer = RecentFolderList.Count - 1

        '-- the most recently used is on top
        For intCounter = 0 To intMax
            Dim item As String = RecentFolderList(intCounter)
            If strReturn.Length > 0 Then
                strReturn &= DELIMITER
            End If
            strReturn &= item
            intItemCount += 1

            '-- We only want to save the most recent 9 items in the recently used list
            If intItemCount = 9 Then
                Exit For
            End If
        Next

        Return strReturn
    End Function
    Private Function GetEditorCustomColorsToSave() As String
        Dim strReturn As String = String.Empty
        If EditorCustomColors Is Nothing Then
            strReturn = String.Empty
        Else
            For intCounter As Integer = EditorCustomColors.GetLowerBound(0) To EditorCustomColors.GetUpperBound(0)
                strReturn &= EditorCustomColors(intCounter) & DELIMITER
            Next
            If strReturn.EndsWith(DELIMITER) Then
                strReturn = strReturn.Substring(0, strReturn.Length - 1)
            End If
        End If
        Return strReturn
    End Function
    Private Sub LoadDoNotSendAddressList()
        Dim xList As Xml.XmlNodeList = _xmlDocument.SelectNodes("//DoNotSendAddress")
        Dim objDoNotSendAddress As DoNotSendEmailAddress
        DoNotSendAddressList.Clear()
        For Each xAddress As Xml.XmlElement In xList
            If IsValidEmailAddress(xAddress.InnerText) Then
                objDoNotSendAddress = New DoNotSendEmailAddress()
                objDoNotSendAddress.Address = xAddress.InnerText
                objDoNotSendAddress.Name = xAddress.GetAttribute("Name")
                objDoNotSendAddress.Reason = xAddress.GetAttribute("Reason")
                DoNotSendAddressList.Add(objDoNotSendAddress)
            End If
        Next
    End Sub
    Private Function GetDoNotSendAddressListNodeToSave(xdoc As System.Xml.XmlDocument) As Xml.XmlElement
        Dim xRoot As Xml.XmlElement = xdoc.CreateElement("DoNotSendAddresses")
        Dim xElement As Xml.XmlElement
        Dim objDoNotSendAddress As DoNotSendEmailAddress
        For Each objDoNotSendAddress In DoNotSendAddressList
            xElement = xdoc.CreateElement("DoNotSendAddress")
            xElement.InnerText = objDoNotSendAddress.Address
            xElement.SetAttribute("Name", objDoNotSendAddress.Name)
            xElement.SetAttribute("Reason", objDoNotSendAddress.Reason)
            xRoot.AppendChild(xElement)
        Next

        Return xRoot
    End Function
    Private Sub LoadProcessingRules()
        Dim xList As Xml.XmlNodeList = _xmlDocument.SelectNodes("//ProcessingRule")
        Dim rule As ProcessingRule
        For Each xRule As Xml.XmlElement In xList
            Try
                rule = New ProcessingRule()
                rule.Name = xRule.GetAttribute("Name")
                rule.Enabled = ConvertToBool(xRule.GetAttribute("Enabled"), False)
                rule.TriggerType = [Enum].Parse(GetType(ProcessingRuleTriggerTypeEnum), xRule.GetAttribute("TriggerType"))
                rule.MatchType = [Enum].Parse(GetType(ProcessingRuleMatchTypeEnum), xRule.GetAttribute("MatchType"))

                Dim xMatchList As Xml.XmlNodeList = xRule.SelectNodes("Matches/Match")
                Dim match As ProcessingRuleMatchData
                For Each xMatch As Xml.XmlElement In xMatchList
                    match = New ProcessingRuleMatchData()
                    match.MatchField = [Enum].Parse(GetType(ProcessingRuleMatchFieldEnum), xMatch.GetAttribute("MatchField"))
                    match.CompareType = [Enum].Parse(GetType(ProcessingRuleMatchDataCompareTypeEnum), xMatch.GetAttribute("CompareType"))
                    match.CompareValue = xMatch.GetAttribute("CompareValue")
                    rule.MatchDatas.Add(match)
                Next

                Dim xActionList As Xml.XmlNodeList = xRule.SelectNodes("Actions/Action")
                Dim action As ProcessingRuleActionData
                For Each xAction As Xml.XmlElement In xActionList
                    action = New ProcessingRuleActionData
                    action.ActionType = [Enum].Parse(GetType(ProcessingRuleActionTypeEnum), xAction.GetAttribute("ActionType"))

                    Dim strValue As String = xAction.GetAttribute("ActionValue")
                    If action.ActionType = ProcessingRuleActionTypeEnum.MoveMessageTo Then
                        strValue = strValue.Replace(MESSAGE_STORE_ROOT_REPLACEMENT_CODE, MessageStoreRootPath)
                    End If
                    action.ActionValue = strValue
                    rule.Actions.Add(action)
                Next

                '-- only add processing rule if there were no errors
                '   this logic was changed in 3.0.3 to support downgrading 
                '   to a version with fewer processing rule options
                '-- without this logic, TrulyMail would not be able to load
                ProcessingRules.Add(rule)
            Catch ex As Exception
                Log(ex)
            End Try
        Next
    End Sub
    Private Function GetProcessingRulesToSave(xdoc As System.Xml.XmlDocument) As Xml.XmlElement
        Dim xRules As Xml.XmlElement = xdoc.CreateElement("ProcessingRules")
        Dim xRule, xMatches, xMatch, xActions, xAction As Xml.XmlElement
        For Each Rule As ProcessingRule In ProcessingRules
            xRule = xdoc.CreateElement("ProcessingRule")
            xRules.AppendChild(xRule)
            xRule.SetAttribute("Name", Rule.Name)
            xRule.SetAttribute("Enabled", Rule.Enabled.ToString())
            xRule.SetAttribute("TriggerType", Rule.TriggerType.ToString())
            xRule.SetAttribute("MatchType", Rule.MatchType.ToString())

            If Not (Rule.MatchType = ProcessingRuleMatchTypeEnum.MatchAll) Then
                xMatches = xdoc.CreateElement("Matches")
                xRule.AppendChild(xMatches)
                For Each match In Rule.MatchDatas
                    xMatch = xdoc.CreateElement("Match")
                    xMatch.SetAttribute("MatchField", match.MatchField.ToString())
                    xMatch.SetAttribute("CompareType", match.CompareType.ToString())
                    xMatch.SetAttribute("CompareValue", match.CompareValue)
                    xMatches.AppendChild(xMatch)
                Next
            End If

            xActions = xdoc.CreateElement("Actions")
            xRule.AppendChild(xActions)
            For Each action In Rule.Actions
                xAction = xdoc.CreateElement("Action")
                xAction.SetAttribute("ActionType", action.ActionType.ToString())
                Dim strValue As String = action.ActionValue
                If action.ActionType = ProcessingRuleActionTypeEnum.MoveMessageTo Then
                    strValue = strValue.Replace(MessageStoreRootPath, MESSAGE_STORE_ROOT_REPLACEMENT_CODE)
                End If
                xAction.SetAttribute("ActionValue", strValue)
                xActions.AppendChild(xAction)
            Next
        Next

        Return xRules
    End Function
    Private Function GetMessageTagsToSave(xdoc As System.Xml.XmlDocument) As Xml.XmlElement
        Dim xElement As Xml.XmlElement = xdoc.CreateElement("MessageTags")

        '-- First, add all SMTP nodes
        For Each tag As MessageTag In _messageTags
            Dim xTag As Xml.XmlElement = xdoc.CreateElement("MessageTag")
            xTag.SetAttribute("Color", tag.Color.ToArgb.ToString())
            xTag.InnerText = tag.Text
            xElement.AppendChild(xTag)
        Next

        Return xElement
    End Function
    Private Sub LoadMessageTags()
        Dim xList As Xml.XmlNodeList = _xmlDocument.SelectNodes("//MessageTag")
        If xList.Count > 0 Then
            For Each xElement As Xml.XmlElement In xList
                Dim tag As New MessageTag()
                tag.Text = xElement.InnerText
                tag.Color = Color.FromArgb(Convert.ToInt32(xElement.GetAttribute("Color")))
                _messageTags.Add(tag)
            Next
        Else
            '-- Load default tags
            Dim tag As New MessageTag()
            tag.Text = "Important"
            tag.Color = Color.Red
            _messageTags.Add(tag)

            tag = New MessageTag()
            tag.Text = "Work"
            tag.Color = Color.Orange
            _messageTags.Add(tag)

            tag = New MessageTag()
            tag.Text = "Personal"
            tag.Color = Color.Green
            _messageTags.Add(tag)

            tag = New MessageTag()
            tag.Text = "To Do"
            tag.Color = Color.Blue
            _messageTags.Add(tag)

            tag = New MessageTag()
            tag.Text = "Later"
            tag.Color = Color.Purple
            _messageTags.Add(tag)
        End If
    End Sub

    Private Function GetRSSSenderForRemoteImagesHashTableFilename() As String
        '-- Load user settings
        Dim dirInfo As System.IO.DirectoryInfo
        Dim strFolder As String

        If IsPortableProfile() Then
            '-- store with application (portable)
            dirInfo = New System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(GetEXEFullPath())) '-- this gets us to the exe (TrulyMail) folder
            dirInfo = dirInfo.Parent '-- this gets us to the TrulyMailPortable folder
            strFolder = QualifyPath(dirInfo.FullName) & "Data\Settings"
        Else
            '-- Store under window's profile (local)
            strFolder = QualifyPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) & Application.ProductName & "\Data\Settings"
        End If

        If Not System.IO.Directory.Exists(strFolder) Then
            System.IO.Directory.CreateDirectory(strFolder)
        End If

        Return QualifyPath(strFolder) & "rsssenderdata.bin"
    End Function
    Private Shared Function GetRSSMessageIDHashTableFilename() As String
        '-- Load user settings
        Dim dirInfo As System.IO.DirectoryInfo
        Dim strFolder As String

        If IsPortableProfile() Then
            '-- store with application (portable)
            dirInfo = New System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(GetEXEFullPath())) '-- this gets us to the exe (TrulyMail) folder
            dirInfo = dirInfo.Parent '-- this gets us to the TrulyMailPortable folder
            strFolder = QualifyPath(dirInfo.FullName) & "Data\Settings"
        Else
            '-- Store under window's profile (local)
            strFolder = QualifyPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) & Application.ProductName & "\Data\Settings"
        End If

        If Not System.IO.Directory.Exists(strFolder) Then
            System.IO.Directory.CreateDirectory(strFolder)
        End If

        Return QualifyPath(strFolder) & "rssdata.bin"
    End Function
    Private Shared Function GetPOPMessageIDHashTableFilename() As String
        '-- Load user settings
        Dim dirInfo As System.IO.DirectoryInfo
        Dim strFolder As String

        If IsPortableProfile() Then
            '-- store with application (portable)
            dirInfo = New System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(GetEXEFullPath())) '-- this gets us to the exe (TrulyMail) folder
            dirInfo = dirInfo.Parent '-- this gets us to the TrulyMailPortable folder
            strFolder = QualifyPath(dirInfo.FullName) & "Data\Settings"
        Else
            '-- Store under window's profile (local)
            strFolder = QualifyPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) & Application.ProductName & "\Data\Settings"
        End If

        If Not System.IO.Directory.Exists(strFolder) Then
            System.IO.Directory.CreateDirectory(strFolder)
        End If

        Return QualifyPath(strFolder) & "popdata.bin"
    End Function
    Private Shared Function GetSettingsFolderName() As String


        '-- Load user settings
        Dim dirInfo As System.IO.DirectoryInfo
        Dim strFolder As String

        If IsPortableProfile() Then
            '-- store with application (portable)
            dirInfo = New System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(GetEXEFullPath())) '-- this gets us to the exe (TrulyMail) folder
            dirInfo = dirInfo.Parent '-- this gets us to the TrulyMailPortable folder
            strFolder = QualifyPath(dirInfo.FullName) & "Data\Settings"
        Else
            '-- Store under window's profile (local)
            strFolder = QualifyPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) & Application.ProductName & "\Data\Settings"
        End If

        If Not System.IO.Directory.Exists(strFolder) Then
            System.IO.Directory.CreateDirectory(strFolder)
        End If

        Return QualifyPath(strFolder)
    End Function
    Friend Shared Function GetSettingsFilename() As String
        Return GetSettingsFolderName() & "user.config"
    End Function


#Region " User.Config support routines (all private) "
    Private Sub LoadFolderTreeQuickJumpList()
        Dim xList As Xml.XmlNodeList = _xmlDocument.SelectNodes("//FolderTreeQuickJump")
        For Each xElement As Xml.XmlElement In xList
            Dim strPath As String = xElement.InnerText
            FolderTreeQuickJumpList.Add(strPath)
        Next
    End Sub
    Private Function GetFolderTreeJumpItemsToSave(xdoc As System.Xml.XmlDocument) As Xml.XmlElement
        Dim xRoot As Xml.XmlElement = xdoc.CreateElement("FolderTreeQuickJumps")
        Dim xElement As Xml.XmlElement
        For Each strPath As String In FolderTreeQuickJumpList
            xElement = xdoc.CreateElement("FolderTreeQuickJump")
            xElement.InnerText = strPath
            xRoot.AppendChild(xElement)
        Next
        Return xRoot
    End Function
    Private Sub LoadPOPList()
        Dim xList As Xml.XmlNodeList = _xmlDocument.SelectNodes("//Account[@Type='POP3']")
        For Each xElement As Xml.XmlElement In xList
            Dim pop As New POPProfile()
            pop.ID = xElement.GetAttribute("ID")
            pop.Name = xElement.GetAttribute("Name")

            pop.ServerAddress = xElement.GetAttribute("ServerAddress")
            pop.ServerPort = Convert.ToInt32(xElement.GetAttribute("ServerPort"))
            pop.Username = xElement.GetAttribute("Username")
            pop.EncryptedPassword = xElement.GetAttribute("Password")
            pop.SecureConnection = [Enum].Parse(GetType(SecureConnectionOption), xElement.GetAttribute("SecureConnection"))
            If pop.SecureConnection = SecureConnectionOption.None Then
                pop.UseSecureAuthentication = False
            Else
                pop.UseSecureAuthentication = Convert.ToBoolean(xElement.GetAttribute("UseSecureAuthentication"))
            End If

            pop.InBoxPath = xElement.GetAttribute("InBox")
            pop.LeaveOnServer = xElement.GetAttribute("LeaveOnServer")
            pop.DownloadAtInterval = xElement.GetAttribute("DownloadAtInterval")
            pop.DownloadInterval = xElement.GetAttribute("DownloadInterval")
            pop.DownloadOnStartup = xElement.GetAttribute("DownloadOnStartup")
            pop.SendReturnReceiptSenderInAddressBook = [Enum].Parse(GetType(POPReceiptOption), xElement.GetAttribute("SendReturnReceiptSenderInAddressBook"))
            pop.SendReturnReceiptSenderNotInAddressBook = [Enum].Parse(GetType(POPReceiptOption), xElement.GetAttribute("SendReturnReceiptSenderNotInAddressBook"))
            pop.SMTPProfileID = xElement.GetAttribute("SMTPProfileID")
            pop.MessagesReceived = ConvertToInt32(xElement.GetAttribute("MessagesReceived"), 0)
            pop.IncludeInReceiveAll = ConvertToBool(xElement.GetAttribute("IncludeInReceiveAll"), True)

            _popProfiles.Add(pop)
        Next
    End Sub
    Private Sub LoadRSSSenderHashTable()
        Try
            Using fs As System.IO.FileStream = System.IO.File.OpenRead(GetRSSSenderForRemoteImagesHashTableFilename())
                Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                RSSSenderAllowRemoteImages = bf.Deserialize(fs)
            End Using
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxAutoClose("There was an error trying to load your RSS sender remote image list. This could result in remote images not automatically being shows for some RSS senders.", 10)

            '-- Likely corrupted RSSArticle file
            Try
                DeleteLocalFile(GetRSSSenderForRemoteImagesHashTableFilename())
            Catch ex1 As Exception
                '-- Just log an ignore, could not delete RSSArticle file for some reason
                Log(ex1)
            End Try
        End Try
    End Sub
    Private Sub LoadRSSHashTable()
        Try
            Using fs As System.IO.FileStream = System.IO.File.OpenRead(GetRSSMessageIDHashTableFilename())
                Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                RSSMessagesReceived = bf.Deserialize(fs)
            End Using
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxAutoClose("There was an error trying to load your RSS download history. This could result in previous RSS articles being downloaded again.", 10)

            '-- Likely corrupted RSSArticle file
            Try
                DeleteLocalFile(GetRSSMessageIDHashTableFilename())
            Catch ex1 As Exception
                '-- Just log an ignore, could not delete RSSArticle file for some reason
                Log(ex1)
            End Try
        End Try
    End Sub
    Private Sub LoadPOPHashTable()
        Try
            Using fs As System.IO.FileStream = System.IO.File.OpenRead(GetPOPMessageIDHashTableFilename())
                Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                _popMessageIDsReceived = bf.Deserialize(fs)
            End Using
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxAutoClose("There was an error trying to load email download history. This could result in previous messages being downloaded again next time you get email messages.", 10)

            '-- Likely corrupted POPMessage file
            Try
                DeleteLocalFile(GetPOPMessageIDHashTableFilename())
            Catch ex1 As Exception
                '-- Just log an ignore, could not delete POPMessage file for some reason
                Log(ex1)
            End Try
        End Try
    End Sub
    Private Sub SaveRSSSenderHashTable()
        Try
            If RSSSenderAllowRemoteImages.Count = 0 Then
                DeleteLocalFile(GetRSSSenderForRemoteImagesHashTableFilename())
            Else
                Using fs As System.IO.FileStream = System.IO.File.Create(GetRSSSenderForRemoteImagesHashTableFilename(), 1024)
                    Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                    bf.Serialize(fs, RSSSenderAllowRemoteImages)
                End Using
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxAutoClose("There was an error trying to save your RSS sender remote image list. This could result in remote images not automatically being shows for some RSS senders.", 10)

            '-- Likely corrupted rss sender file
            Try
                DeleteLocalFile(GetRSSSenderForRemoteImagesHashTableFilename())
            Catch ex1 As Exception
                '-- Just log an ignore, could not delete POPMessage file for some reason
                Log(ex1)
            End Try
        End Try
    End Sub
    Private Sub SaveRSSHashTable()
        Try
            If RSSMessagesReceived.Count = 0 Then
                DeleteLocalFile(GetRSSMessageIDHashTableFilename())
            Else
                Using fs As System.IO.FileStream = System.IO.File.Create(GetRSSMessageIDHashTableFilename(), 1024)
                    Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                    bf.Serialize(fs, RSSMessagesReceived)
                End Using
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxAutoClose("There was an error trying to save your RSS download history. This could result in previous messages being downloaded again.", 10)

            '-- Likely corrupted POPMessage file
            Try
                DeleteLocalFile(GetRSSMessageIDHashTableFilename())
            Catch ex1 As Exception
                '-- Just log an ignore, could not delete POPMessage file for some reason
                Log(ex1)
            End Try
        End Try
    End Sub
    Private Sub SavePOPHashTable()
        Try
            If _popMessageIDsReceived.Count = 0 Then
                DeleteLocalFile(GetPOPMessageIDHashTableFilename())
            Else
                Using fs As System.IO.FileStream = System.IO.File.Create(GetPOPMessageIDHashTableFilename(), 1024)
                    Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                    bf.Serialize(fs, _popMessageIDsReceived)
                End Using
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxAutoClose("There was an error trying to save email download history. This could result in previous messages being downloaded again next time you get email messages.", 10)

            '-- Likely corrupted POPMessage file
            Try
                DeleteLocalFile(GetPOPMessageIDHashTableFilename())
            Catch ex1 As Exception
                '-- Just log an ignore, could not delete POPMessage file for some reason
                Log(ex1)
            End Try
        End Try
    End Sub
    Private Sub LoadSMTPList()
        Dim xList As Xml.XmlNodeList = _xmlDocument.SelectNodes("//Account[@Type='SMTP']")
        Dim boolAtLeastOneIsDefault As Boolean
        For Each xElement As Xml.XmlElement In xList
            Dim smtp As New SMTPProfile()
            smtp.ID = xElement.GetAttribute("ID")
            smtp.Name = xElement.GetAttribute("Name")
            smtp.IsDefault = Convert.ToBoolean(xElement.GetAttribute("IsDefault"))
            If smtp.IsDefault Then
                boolAtLeastOneIsDefault = True
            End If

            smtp.ServerName = xElement.GetAttribute("ServerAddress")
            smtp.ServerPort = Convert.ToInt32(xElement.GetAttribute("ServerPort"))
            smtp.Username = xElement.GetAttribute("Username")
            smtp.EncryptedPassword = xElement.GetAttribute("Password")
            smtp.SecureConnection = [Enum].Parse(GetType(SecureConnectionOption), xElement.GetAttribute("SecureConnection"))
            'If smtp.SecureConnection = SecureConnectionOption.None Then
            '    smtp.UseSecureAuthentication = False
            'Else
            '    smtp.UseSecureAuthentication = Convert.ToBoolean(xElement.GetAttribute("UseSecureAuthentication"))
            'End If

            smtp.DisplayEmail = xElement.GetAttribute("DisplayEmail")
            smtp.DisplayName = xElement.GetAttribute("DisplayName")
            smtp.ReplyTo = xElement.GetAttribute("ReplyTo")
            'smtp.SmtpAuthentication = Convert.ToInt32(xElement.GetAttribute("SmtpAuthentication"), 1) '-- default to 1, this maps to AspNetEmail component
            'smtp.DraftsFolder = xElement.GetAttribute("DraftsFolder")
            'smtp.SentItems = xElement.GetAttribute("SentItems")
            smtp.MessagesSent = ConvertToInt32(xElement.GetAttribute("MessagesSent"), 0)

            _smtpProfiles.Add(smtp)
        Next

        If Not boolAtLeastOneIsDefault Then
            '-- no SMTP are default (most likely, default account was deleted) so now make a new one the default
            '   Just pick the first one, as long as it exists
            If _smtpProfiles.Count > 0 Then
                _smtpProfiles(0).IsDefault = True
            End If
        End If
    End Sub
    Private Function GetFolderStatesToSave(xdoc As System.Xml.XmlDocument) As Xml.XmlElement
        Dim xRoot As Xml.XmlElement = xdoc.CreateElement("FolderStates")
        Dim xElement As Xml.XmlElement
        For Each folder As FolderState In FolderStates
            xElement = xdoc.CreateElement("FolderState")
            xElement.SetAttribute("Expanded", folder.Expanded)
            xElement.SetAttribute("UnreadCount", folder.UnreadCount.ToString())
            xElement.SetAttribute("Icon", folder.Icon.ToString())
            xElement.InnerText = folder.FullPath.Substring(MessageStoreRootPath.Length) '-- path relative to message store root

            xRoot.AppendChild(xElement)
        Next
        Return xRoot
    End Function
    Private Function GetRSSFeedsToSave(xdoc As System.Xml.XmlDocument) As Xml.XmlElement
        Dim xRoot As Xml.XmlElement = xdoc.CreateElement("RSSFeeds")
        Dim xElement As Xml.XmlElement
        For Each feed As RSSFeed In RSSFeeds
            xElement = xdoc.CreateElement("RSSFeed")
            xElement.SetAttribute("Folder", feed.Folder.Substring(MessageStoreRootPath.Length)) '-- store path relative to messagestore root folder
            xElement.SetAttribute("URL", feed.URL)
            xElement.SetAttribute("ShowSummary", feed.ShowSummary)
            xElement.SetAttribute("DownloadAttachments", feed.DownloadAttachments)
            xElement.SetAttribute("ForcePlainText", feed.ForcePlainText)
            xElement.SetAttribute("AddLinkToPlainText", feed.AddLinkToPlainText)
            xElement.SetAttribute("HTMLUrl", feed.HTMLUrl)
            xElement.InnerText = feed.Title

            xRoot.AppendChild(xElement)
        Next
        Return xRoot
    End Function
    Private Function GetAutoTextsToSave(xdoc As System.Xml.XmlDocument) As Xml.XmlElement
        Dim xRoot As Xml.XmlElement = xdoc.CreateElement("AutoTexts")
        Dim xElement As Xml.XmlElement
        For Each auto As AutoText In AutoTexts
            xElement = xdoc.CreateElement("AutoText")
            xElement.SetAttribute("ID", auto.ID)
            xElement.SetAttribute("Name", auto.Name)
            xElement.SetAttribute("HTML", auto.HTML.ToString())
            xElement.SetAttribute("IsNew", auto.IsNew.ToString())
            xElement.SetAttribute("IsReply", auto.IsReply.ToString())
            xElement.SetAttribute("IsForward", auto.IsForward.ToString())
            xElement.SetAttribute("IsFollowUp", auto.IsFollowUp.ToString())
            xElement.SetAttribute("KeyValue", Convert.ToInt32(auto.KeyValue))
            xElement.SetAttribute("ModifierKeys", Convert.ToInt32(auto.ModifierKeys))

            xElement.InnerText = auto.Text
            xRoot.AppendChild(xElement)
        Next
        Return xRoot
    End Function
    Private Sub LoadFolderStates()
        FolderStates = New List(Of FolderState)
        Dim xList As Xml.XmlNodeList = _xmlDocument.SelectNodes("//FolderState")
        Dim intCounter As Integer = 0
        For Each xElement As Xml.XmlElement In xList
            intCounter += 1
            Dim folder As New FolderState()
            folder.Expanded = ConvertToBool(xElement.GetAttribute("Expanded"), False)
            folder.UnreadCount = ConvertToInt32(xElement.GetAttribute("UnreadCount"), 0)
            folder.Icon = ConvertToInt32(xElement.GetAttribute("Icon"), 0)
            folder.FullPath = QualifyPath(MessageStoreRootPath & xElement.InnerText).ToLower()
            FolderStates.Add(folder)
        Next
    End Sub
    Private Sub LoadRSSFeeds()
        RSSFeeds = New List(Of RSSFeed)
        Dim xList As Xml.XmlNodeList = _xmlDocument.SelectNodes("//RSSFeed")
        Dim intCounter As Integer = 0
        For Each xElement As Xml.XmlElement In xList
            intCounter += 1
            Dim feed As New RSSFeed()
            feed.URL = xElement.GetAttribute("URL")
            feed.ShowSummary = ConvertToBool(xElement.GetAttribute("ShowSummary"), False)
            feed.Folder = QualifyPath(MessageStoreRootPath & xElement.GetAttribute("Folder"))
            feed.DownloadAttachments = ConvertToBool(xElement.GetAttribute("DownloadAttachments"), False)
            feed.ForcePlainText = ConvertToBool(xElement.GetAttribute("ForcePlainText"), False)
            feed.AddLinkToPlainText = ConvertToBool(xElement.GetAttribute("AddLinkToPlainText"), False)
            feed.Title = xElement.InnerText
            feed.HTMLUrl = xElement.GetAttribute("HTMLUrl")
            RSSFeeds.Add(feed)
        Next
    End Sub
    Private Sub LoadAutoTexts()
        Const OLD_AUTO_TEXT_ERROR As String = "&lt;P&gt;&amp;nbsp;&lt;br&gt;/P&gt;&lt;P&gt;&amp;nbsp;&lt;br&gt;/P&gt;&lt;P&gt;<BR>--------&lt;BR&gt;Sent using TrulyMail&lt;BR&gt;Learn more at &lt;A href='http://trulymail.com/'&gt;http://TrulyMail.com&lt;/A&gt;&lt;BR&gt;&lt;/P&gt;"

        AutoTexts = New List(Of AutoText)
        Dim xList As Xml.XmlNodeList = _xmlDocument.SelectNodes("//AutoText")
        If xList.Count > 0 Then
            Dim intCounter As Integer = 0
            For Each xElement As Xml.XmlElement In xList
                intCounter += 1
                Dim auto As New AutoText()
                auto.ID = xElement.GetAttribute("ID")
                auto.Name = xElement.GetAttribute("Name")
                auto.HTML = ConvertToBool(xElement.GetAttribute("HTML"), False)
                auto.IsNew = ConvertToBool(xElement.GetAttribute("IsNew"), False)
                auto.IsReply = ConvertToBool(xElement.GetAttribute("IsReply"), False)
                auto.IsForward = ConvertToBool(xElement.GetAttribute("IsForward"), False)
                auto.IsFollowUp = ConvertToBool(xElement.GetAttribute("IsFollowUp"), False)
                auto.KeyValue = ConvertToInt32(xElement.GetAttribute("KeyValue"), 0)
                auto.ModifierKeys = ConvertToInt32(xElement.GetAttribute("ModifierKeys"), 0)

                auto.Text = xElement.InnerText

                If auto.Text <> OLD_AUTO_TEXT_ERROR Then
                    AutoTexts.Add(auto)
                End If
            Next
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="removePassword">If false, passwords will be included. If true, passwords will not be included</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAccountsToSave(xdoc As System.Xml.XmlDocument, removePassword As Boolean) As Xml.XmlElement
        Dim xElement As Xml.XmlElement = xdoc.CreateElement("Accounts")

        '-- First, add all SMTP nodes
        For Each smtp As SMTPProfile In _smtpProfiles
            Dim xSMTP As Xml.XmlElement = xdoc.CreateElement("Account")
            xSMTP.SetAttribute("Type", "SMTP")
            xSMTP.SetAttribute("ID", smtp.ID)
            xSMTP.SetAttribute("Name", smtp.Name)
            xSMTP.SetAttribute("IsDefault", smtp.IsDefault)
            xSMTP.SetAttribute("ServerAddress", smtp.ServerName)
            xSMTP.SetAttribute("ServerPort", smtp.ServerPort)
            xSMTP.SetAttribute("Username", smtp.Username)
            If Not removePassword Then
                xSMTP.SetAttribute("Password", smtp.EncryptedPassword)
            End If
            xSMTP.SetAttribute("SecureConnection", smtp.SecureConnection.ToString())
            'xSMTP.SetAttribute("UseSecureAuthentication", smtp.UseSecureAuthentication)
            xSMTP.SetAttribute("DisplayEmail", smtp.DisplayEmail)
            xSMTP.SetAttribute("DisplayName", smtp.DisplayName)
            xSMTP.SetAttribute("ReplyTo", smtp.ReplyTo)
            'xSMTP.SetAttribute("SmtpAuthentication", smtp.SmtpAuthentication.ToString())
            xSMTP.SetAttribute("MessagesSent", smtp.MessagesSent)

            xElement.AppendChild(xSMTP)
        Next

        '-- Then add POP nodes
        For Each pop As POPProfile In _popProfiles
            Dim xPOP As Xml.XmlElement = xdoc.CreateElement("Account")
            xPOP.SetAttribute("Type", "POP3")
            xPOP.SetAttribute("ID", pop.ID)
            xPOP.SetAttribute("Name", pop.Name)
            xPOP.SetAttribute("SMTPProfileID", pop.SMTPProfileID)
            xPOP.SetAttribute("DownloadOnStartup", pop.DownloadOnStartup)
            xPOP.SetAttribute("DownloadInterval", pop.DownloadInterval)
            xPOP.SetAttribute("DownloadAtInterval", pop.DownloadAtInterval)
            xPOP.SetAttribute("InBox", pop.InBoxPath)
            xPOP.SetAttribute("LeaveOnServer", pop.LeaveOnServer)
            xPOP.SetAttribute("Username", pop.Username)
            If Not removePassword Then
                xPOP.SetAttribute("Password", pop.EncryptedPassword)
            End If
            xPOP.SetAttribute("SecureConnection", pop.SecureConnection.ToString())
            xPOP.SetAttribute("UseSecureAuthentication", pop.UseSecureAuthentication)
            xPOP.SetAttribute("SendReturnReceiptSenderInAddressBook", pop.SendReturnReceiptSenderInAddressBook.ToString())
            xPOP.SetAttribute("SendReturnReceiptSenderNotInAddressBook", pop.SendReturnReceiptSenderNotInAddressBook.ToString())
            xPOP.SetAttribute("ServerAddress", pop.ServerAddress)
            xPOP.SetAttribute("ServerPort", pop.ServerPort)
            xPOP.SetAttribute("MessagesReceived", pop.MessagesReceived)
            xPOP.SetAttribute("IncludeInReceiveAll", pop.IncludeInReceiveAll)

            xElement.AppendChild(xPOP)
        Next

        Return xElement
    End Function
    Private Function GetSettingString(ByVal settingName As String) As String
        Dim strXPath As String = "//setting[@name='" & settingName & "']"
        Dim objNode As Xml.XmlNode = _xmlDocument.SelectSingleNode(strXPath)
        If objNode IsNot Nothing Then
            Return objNode.InnerText
        Else
            Return String.Empty
        End If
    End Function
    Private Function CreateSettingsNode(xdoc As System.Xml.XmlDocument, ByVal name As String, ByVal value As Object) As Xml.XmlElement
        Dim settingNode As Xml.XmlElement = xdoc.CreateElement("setting")
        settingNode.SetAttribute("name", name)
        settingNode.SetAttribute("serializeAs", "String")

        Dim valueNode As Xml.XmlNode = xdoc.CreateElement("value")
        Select Case TypeName(value)
            Case "Color"
                valueNode.InnerText = CType(value, Color).Name
                'Case "Date()"
                '    For Each dt As Date In CType(value, Date())
                '        valueNode.InnerText &= DELIMITER & dt.ToString()
                '    Next
                '    valueNode.InnerText = valueNode.InnerText.Substring(1)
                'Case "Boolean()"
                '    For Each bool As Boolean In CType(value, Boolean())
                '        valueNode.InnerText &= DELIMITER & bool.ToString()
                '    Next
                '    valueNode.InnerText = valueNode.InnerText.Substring(1)
            Case "FormWindowState"
                valueNode.InnerText = Convert.ToInt32(value) '-- otherwise we get the string
            Case "AutoCompleteStringCollection"
                Dim tmp As AutoCompleteStringCollection = CType(value, AutoCompleteStringCollection)
                Dim strValue As String = String.Empty
                For Each strItem As String In tmp
                    strValue &= strItem & DELIMITER
                Next
                If strValue.EndsWith(DELIMITER) Then
                    strValue = strValue.Substring(0, strValue.Length - 1)
                End If
                valueNode.InnerText = strValue
            Case "Date"
                valueNode.InnerText = CType(value, Date).ToString(DATEFORMAT_XML)
            Case Else
                valueNode.InnerText = value.ToString
        End Select
        settingNode.AppendChild(valueNode)
        Return settingNode
    End Function
    Friend Shared Sub RestoreFromBackupCopyOfSettingsFile()
        '-- Same as making the backup copy but it reverses the File.Copy call
        Dim strDestination As String
        Try
            '-- First, user.config file
            strDestination = GetSettingsFilename()
            RestoreFromBackupOfIndividualSettingsFile(strDestination)

            '-- Next, the popdata.bin file
            strDestination = GetPOPMessageIDHashTableFilename()
            RestoreFromBackupOfIndividualSettingsFile(strDestination)

            '-- Next, the rssdata.bin file
            strDestination = GetRSSMessageIDHashTableFilename()
            RestoreFromBackupOfIndividualSettingsFile(strDestination)

        Catch ex As Exception
            Log(ex)
            If strDestination IsNot Nothing Then
                Log("Destination: " & strDestination)
            End If
        End Try
    End Sub
    Private Shared Sub RestoreFromBackupOfIndividualSettingsFile(ByVal settingsFilename As String)
        Dim strSource As String
        strSource = settingsFilename & ".backup"
        If System.IO.File.Exists(strSource) Then
            If System.IO.File.Exists(settingsFilename) Then
                DeleteLocalFile(settingsFilename)
            End If
            System.IO.File.Copy(strSource, settingsFilename)
        End If
    End Sub
    Private Sub BackupIndividualSettingsFile(ByVal settingsFilename As String)
        Dim strDestination As String
        If System.IO.File.Exists(settingsFilename) Then
            strDestination = settingsFilename & ".backup"
            If System.IO.File.Exists(strDestination) Then
                DeleteLocalFile(strDestination)
            End If
            System.IO.File.Copy(settingsFilename, strDestination)
        End If
    End Sub
    Private Sub MakeBackupCopyOfSettingsFile()
        '-- this should be called after successfully loading all settings, so the backup copy is always a known good copy
        Dim strSource As String
        Try
            '-- First, copy the user.config file
            strSource = GetSettingsFilename()
            BackupIndividualSettingsFile(strSource)

            '-- Next, the popdata.bin file
            strSource = GetPOPMessageIDHashTableFilename()
            BackupIndividualSettingsFile(strSource)

            '-- Next, the rssdata.bin file
            strSource = GetRSSMessageIDHashTableFilename()
            BackupIndividualSettingsFile(strSource)


        Catch ex As Exception
            Log(ex)
            If strSource IsNot Nothing Then
                Log("Source: " & strSource)
            End If
        End Try
    End Sub
    Public Sub ResetSavedWindowsPositions()
        '-- called when startup detects that screens have changed
        '   either Screen.PrimaryScreen.WorkingArea.Width or Screen.AllScreens.Length changed
        Me.ReadWindowLocation = New Point(0, 0)
        Me.MainWindowLocation = New Point(0, 0)
        Me.ComposeWindowLocation = New Point(0, 0)
    End Sub
    Private Sub CreateReplyModes()
        AllReplyModes = New List(Of ReplyMode)

        Dim mode As ReplyMode

        mode = New ReplyMode
        mode.Text = "Reply to Sender"
        mode.ImageIndex = 0
        mode.ForReceivedMessages = True
        mode.ForSentMessages = False
        mode.IsReply = True
        mode.IsForward = False
        mode.IncludesBody = True
        mode.IncludesAttachments = False
        mode.IsReplyAll = False
        AllReplyModes.Add(mode)

        mode = New ReplyMode
        mode.Text = "Reply to sender without body"
        mode.ImageIndex = 1
        mode.ForReceivedMessages = True
        mode.ForSentMessages = False
        mode.IsReply = True
        mode.IsForward = False
        mode.IncludesAttachments = False
        mode.IsReplyAll = False
        AllReplyModes.Add(mode)

        mode = New ReplyMode
        mode.Text = "Reply to all"
        mode.ImageIndex = 2
        mode.ForReceivedMessages = True
        mode.ForSentMessages = False
        mode.IsReply = True
        mode.IsForward = False
        mode.IncludesBody = True
        mode.IncludesAttachments = False
        mode.IsReplyAll = True
        AllReplyModes.Add(mode)

        mode = New ReplyMode
        mode.Text = "Reply to all without body"
        mode.ImageIndex = 3
        mode.ForReceivedMessages = True
        mode.ForSentMessages = False
        mode.IsReply = True
        mode.IsForward = False
        mode.IncludesAttachments = False
        mode.IsReplyAll = True
        AllReplyModes.Add(mode)

        mode = New ReplyMode
        mode.Text = "Forward with attachments"
        mode.ImageIndex = 4
        mode.ForReceivedMessages = True
        mode.ForSentMessages = True
        mode.IsReply = False
        mode.IsForward = True
        mode.IncludesBody = True
        mode.IncludesAttachments = True
        mode.IsReplyAll = False
        AllReplyModes.Add(mode)

        mode = New ReplyMode
        mode.Text = "Forward without attachments"
        mode.ImageIndex = 5
        mode.ForReceivedMessages = True
        mode.ForSentMessages = True
        mode.IsReply = False
        mode.IsForward = True
        mode.IncludesBody = True
        mode.IncludesAttachments = False
        mode.IsReplyAll = False
        AllReplyModes.Add(mode)

        mode = New ReplyMode
        mode.Text = "Follow up"
        mode.ImageIndex = 6
        mode.ForReceivedMessages = False
        mode.ForSentMessages = True
        mode.IncludesBody = True
        mode.IncludesAttachments = False
        mode.IsReplyAll = False
        AllReplyModes.Add(mode)

        mode = New ReplyMode
        mode.Text = "Resend"
        mode.ImageIndex = 7
        mode.ForReceivedMessages = False
        mode.ForSentMessages = True
        mode.IncludesBody = True
        mode.IncludesAttachments = True
        mode.IsReplyAll = False
        AllReplyModes.Add(mode)

        mode = New ReplyMode
        mode.Text = "Reply with attachments"
        mode.ImageIndex = 0
        mode.ForReceivedMessages = True
        mode.ForSentMessages = False
        mode.IsReply = True
        mode.IsForward = False
        mode.IncludesBody = True
        mode.IncludesAttachments = True
        mode.IsReplyAll = False
        AllReplyModes.Add(mode)

        mode = New ReplyMode
        mode.Text = "Reply all with attachments"
        mode.ImageIndex = 2
        mode.ForReceivedMessages = True
        mode.ForSentMessages = False
        mode.IsReply = True
        mode.IsForward = False
        mode.IncludesBody = True
        mode.IncludesAttachments = True
        mode.IsReplyAll = True
        AllReplyModes.Add(mode)

    End Sub
#End Region


End Class
