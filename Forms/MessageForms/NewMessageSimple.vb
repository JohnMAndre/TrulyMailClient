Public Class NewMessageSimple
    Implements IComposeForm


#Region " Module-level stuff "
    Private m_strRandomGuid As String  '-- for encrypting files (reset for every new message in SendMessage)
    Private m_lngTotalAttachmentSize As Long = 0
    Private m_lngTotalAttachmentSizeUncompressed As Long = 0
    Private m_lngTotalPostingSize As Long = 0 '-- (bodyhtml * # of recip) + total attach size
    Private m_lngTotalPostedSoFar As Long = 0 '-- what has already been sent to the server
    Private m_lngPreviousBodyHTMLSize As Long = 0
    Private m_lngTotalEmbededImageSize As Long = 0
    Private m_boolCancelSending As Boolean
    Private m_strSendingErrorText As String = String.Empty
    Private m_SendingErrorButtons As MessageBoxButtons = MessageBoxButtons.OK
    Private m_SendingErrorIcon As MessageBoxIcon = MessageBoxIcon.Information
    Private m_SendingErrorAction As SendingErrorAction
    Private m_SendingErrorSendData As SendMessageData
    Private m_boolDirty As Boolean '-- true when data has changed but draft not saved
    Private m_strMessageID As String = String.Empty
    Private m_strMessageToModifyOnSent As String = String.Empty
    Private m_modifyProcess As ModifyOnSend
    Private m_dtSendLater As Date
    Private m_boolOKToClose As Boolean
    Private m_strAttachmentArchiveFilename As String = Globals.GetTempFilename()
    Private m_zip As New Ionic.Zip.ZipFile()
    Private m_boolAtLeastOneAttachmentMissing As Boolean
    Private m_lstAttachments As New List(Of AttachmentItem)
    Private WithEvents m_msgSender As MessageSender
    Private m_lngTotalMessageSize As Long
    Private m_strPreviousIEFooterSetting As String = String.Empty
    Private m_boolRestoreIEFooterSetting As Boolean
    Private m_boolFilterChanging As Boolean
    Private m_strSMTPID As String = String.Empty
    Private m_lstRecipientsToAdd As New List(Of RecipientEntry)
    Private m_lstAttachmentsToAdd As New List(Of String)
    Private m_intImagesBlocked As Integer
    Private m_boolPositionCursorAtEndOnLoad As Boolean '-- only used for replies and forwards
    Private m_recipientAddMode As RecipientType = RecipientType.Send_To
    Private m_strLastAddedRecipientID As String = String.Empty
    Private m_boolUserControlledReceiptRequest As Boolean
    Private m_boolAtLeastOneAutoRequestReceiptRecipient As Boolean
    Private m_controlToFocusOnLoad As Control
    Private m_dtTrulyMailUserOnEncryptedPackageNoticeLastShown As Date = Date.Now

    Private Const DEFAULT_SEARCH_TEXT As String = "Name or email or tag"

    Private m_boolNeedSpellCheck As Boolean = AppSettings.SpellCheckBeforeSend
    Private m_emailEncryption As EncryptedEmailType = EncryptedEmailType.ClearText
    Private m_boolNewsletterMode As Boolean
    Private m_autoTextToUse As AutoText
    Private m_boolFormFullyLoaded As Boolean
    Private m_boolDefaultToZipAttachments As Boolean = AppSettings.AutoZipEmailAttachments
    Private m_boolMovingToSubjectLine As Boolean
    Private m_defaultEncryption As DefaultEncryptionSetting

    Private m_speech As System.Speech.Synthesis.SpeechSynthesizer

    Private Enum PostSpellCheckAction
        None
        SpellCheckBody
        Send
    End Enum
    Private Enum SendingErrorAction
        GoToWebSite
        SendDelayed
    End Enum
    Private Enum DefaultEncryptionSetting
        Unknown
        ClearText
        TM2TM
    End Enum
#End Region

#Region " New "
    ''' <summary>
    ''' Creates a new message from a mailto link
    ''' </summary>
    ''' <param name="mailToLink">Something like "mailto:astark1@unl.edu?subject=Comments from MailTo Syntax Page" this must be already URLDecoded</param>
    ''' <param name="bringToFront">Really not needed but needed another param to make a unique signature</param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal mailToLink As String, ByVal bringToFront As Boolean)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        '-- Using following format for mailto links http://www.ianr.unl.edu/internet/mailto.html
        Try
            If mailToLink.ToLower().StartsWith("mailto:") Then
                Dim strFullLink As String = mailToLink.Substring(7) '-- strip mailto:
                Dim strToList As String
                Dim boolSplitParameters As Boolean
                If strFullLink.IndexOf("?") > 0 Then
                    strToList = strFullLink.Substring(0, strFullLink.IndexOf("?"))
                    strFullLink = strFullLink.Substring(strFullLink.IndexOf("?") + 1)
                    boolSplitParameters = True
                Else
                    boolSplitParameters = False
                    strToList = strFullLink
                End If

                Dim recip As RecipientEntry
                Dim abookEntry As AddressBookEntry
                Dim addr As System.Net.Mail.MailAddress

                '-- test for multiple recips
                Dim param() As String
                param = strToList.Split(",")
                For intCounter As Integer = 0 To param.Length - 1
                    abookEntry = ABook.GetContactByAddress(param(intCounter)) 'GetAddressBookEmailEntry(param(intCounter))
                    If abookEntry Is Nothing Then
                        recip = New RecipientEntry(AddressBookEntryType.Email)
                        addr = New System.Net.Mail.MailAddress(param(intCounter))
                        recip.Address = addr.Address
                        recip.FullName = addr.DisplayName
                        recip.RecipientType = RecipientType.Send_To
                    Else
                        recip = New RecipientEntry(abookEntry)
                        recip.RecipientType = RecipientType.Send_To
                    End If
                    m_lstRecipientsToAdd.Add(recip)
                Next

                Dim strParameters() As String
                If boolSplitParameters Then
                    strParameters = strFullLink.Split("&")

                    For intCounter As Integer = 0 To strParameters.Length - 1
                        param = strParameters(intCounter).Split("=")
                        Select Case param(0).ToLower()
                            Case "cc"
                                abookEntry = ABook.GetContactByAddress(param(1)) 'GetAddressBookEmailEntry(param(1))
                                If abookEntry Is Nothing Then
                                    recip = New RecipientEntry(AddressBookEntryType.Email)
                                    addr = New System.Net.Mail.MailAddress(param(1))
                                    recip.Address = addr.Address
                                    recip.FullName = addr.DisplayName
                                    recip.RecipientType = RecipientType.Send_CC
                                Else
                                    recip = New RecipientEntry(abookEntry)
                                    recip.RecipientType = RecipientType.Send_CC
                                End If
                                m_lstRecipientsToAdd.Add(recip)
                            Case "bcc"
                                abookEntry = ABook.GetContactByAddress(param(1)) 'GetAddressBookEmailEntry(param(1))
                                If abookEntry Is Nothing Then
                                    recip = New RecipientEntry(AddressBookEntryType.Email)
                                    addr = New System.Net.Mail.MailAddress(param(1))
                                    recip.Address = addr.Address
                                    recip.FullName = addr.DisplayName
                                    recip.RecipientType = RecipientType.Send_BCC
                                Else
                                    recip = New RecipientEntry(abookEntry)
                                    recip.RecipientType = RecipientType.Send_BCC
                                End If
                                m_lstRecipientsToAdd.Add(recip)
                            Case "body"
                                txtMessageBody.Text = param(1)
                            Case "subject"
                                txtSubject.Text = param(1)
                        End Select
                    Next
                End If
            End If

            m_emailEncryption = CType(AppSettings.DefaultEmailEncryption, EncryptedEmailType)
            m_autoTextToUse = GetAutoText(MessageResponseType.Resend) '-- not a nice hack, but using resend to represent new messages
        Catch ex As Exception
            Log(ex)
            Application.DoEvents()
        End Try
    End Sub

    ''' <param name="draftMessageFilename"></param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal draftMessageFilename As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        '-- Open original message and populate the basics
        Dim xDoc As New Xml.XmlDocument()
        xDoc.Load(draftMessageFilename)

        Dim strXPath As String = "//" & MESSAGE_ATTRIBUTE_NAME_SUBJECT
        Dim xElement As Xml.XmlElement = xDoc.SelectSingleNode(strXPath)
        If xElement IsNot Nothing Then
            txtSubject.Text = xElement.InnerText
        Else
            txtSubject.Text = String.Empty
        End If


        '-- set the messageid for saving as a draft
        m_strMessageID = xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGEID)

        '-- maintain in case of reply, save, open draft, send
        If xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ORIGINALMESSAGEFILENAME).Length > 0 Then
            m_strMessageToModifyOnSent = MessageStoreRootPath & xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ORIGINALMESSAGEFILENAME)
            m_modifyProcess = [Enum].Parse(GetType(ModifyOnSend), xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_RESPONSETYPE))
        End If

        '-- Set the smtp account
        m_strSMTPID = xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SMTPACCOUNT)

        '-- Set the message body text
        Dim strBody As String = String.Empty
        strXPath = "//" & MESSAGE_ATTRIBUTE_NAME_BODY
        xElement = xDoc.SelectSingleNode(strXPath)
        If xElement IsNot Nothing Then
            Dim strFormat As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FORMAT)
            If strFormat = BODYFORMAT_PLAINTEXT Then
                strBody = xElement.InnerText
            Else
                '-- Only convert if there is actually HTML
                'strBody = StripHTML(xElement.InnerText)
                strBody = ConvertHtmlToPlainText(xElement.InnerText)
                strBody = strBody.Replace(ATTACHMENTS_FOLDER_REPLACEMENT_CODE, AttachmentsRootPath)
            End If
        End If

        '-- If the message says to show remote images, then we do not need to check settings, just show remote images
        Dim strShowRemoteImages As String = xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SHOWREMOTEIMAGES)
        Dim boolBlockRemoteImages As Boolean
        If strShowRemoteImages.Length > 0 Then
            boolBlockRemoteImages = Not Convert.ToBoolean(strShowRemoteImages)
            If boolBlockRemoteImages Then
                m_intImagesBlocked = 1 '-- just must be more than 0 to trigger blocking logic on save as draft and send
            End If
        End If

        txtMessageBody.Text = strBody

        '-- get recipients
        Dim xList As Xml.XmlNodeList
        Dim recipientItem As RecipientEntry
        xList = xDoc.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_RECIPIENT)
        Dim boolUnknownRecipient As Boolean

        For Each xElement In xList
            Dim strRecipientID As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_RECIPIENTID)
            If strRecipientID.Length > 0 Then
                Try
                    recipientItem = New RecipientEntry(ABook.GetContactByID(strRecipientID)) 'AddressBookEntry.LoadFromID(strRecipientID))
                    If recipientItem.ID = Nothing Then
                        boolUnknownRecipient = True
                    End If
                Catch ex As Exception
                    Log(ex)
                    'ShowMessageBoxError("There was an error loading one of the recipients (" & ex.Message & "). This recipient has been removed.")
                    boolUnknownRecipient = True
                End Try
            Else
                boolUnknownRecipient = True
            End If

            If boolUnknownRecipient Then
                recipientItem = New RecipientEntry(AddressBookEntryType.Email)
                recipientItem.FullName = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME)
                recipientItem.Address = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ADDRESS)
            End If

            If recipientItem IsNot Nothing Then
                recipientItem.RecipientType = GetRecipientTypeByRoleID(xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID))
                m_lstRecipientsToAdd.Add(recipientItem)
            End If
        Next

        Try
            SaveACopyToolStripButton.Checked = ConvertToBool(xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_KEEPCOPYAFTERSEND), False)
            ReturnReceiptToolStripButton.Checked = ConvertToBool(xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_REQUESTRETURNRECEIPT), False)
            RequestReturnReceiptemailOnlyToolStripMenuItem.Checked = ReturnReceiptToolStripButton.Checked
            '-- Encryption
            Dim strTemp As String = xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDEMAILTYPE)
            Select Case strTemp
                Case EncryptedEmailType.EncrypedTM2TMEmail.ToString
                    m_defaultEncryption = DefaultEncryptionSetting.TM2TM
                    SetEmailEncryption(EncryptedEmailType.EncrypedTM2TMEmail)
                Case EncryptedEmailType.ClearText.ToString
                    m_defaultEncryption = DefaultEncryptionSetting.ClearText
                    SetEmailEncryption(EncryptedEmailType.ClearText)
            End Select

        Catch ex As Exception
            '-- ignore error
        End Try

        '-- attachments
        strXPath = "//" & MESSAGE_ATTRIBUTE_NAME_ATTACHMENT
        xList = xDoc.SelectNodes(strXPath)
        For Each xElement In xList
            If Not xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME).StartsWith(IMAGES_EMBEDDED_FOLDER) Then
                Dim strFilename As String = AttachmentsRootPath & m_strMessageID & "\" & xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME)
                m_lstAttachmentsToAdd.Add(strFilename)
            End If
        Next

        '-- zip attachments
        m_boolDefaultToZipAttachments = ConvertToBool(xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ZIPATTACHMENTS), False)

        Dirty = False
    End Sub
    ''' <summary>
    ''' For reply, forward, etc.
    ''' </summary>
    ''' <param name="originalMessageFilename"></param>
    ''' <param name="responseType"></param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal originalMessageFilename As String, ByVal responseType As MessageResponseType)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            '-- Open original message and populate the basics
            Dim tmmOriginal As New TrulyMailMessage(originalMessageFilename)

            m_boolPositionCursorAtEndOnLoad = (AppSettings.ReplyPostingMode = ReplyPostModeEnum.ReplyBelowQuote)

            m_strMessageToModifyOnSent = originalMessageFilename

            Dim strXPath As String = "//" & MESSAGE_ATTRIBUTE_NAME_SUBJECT
            Dim strSubject As String = tmmOriginal.Subject
            Dim dtOriginalSentDate As Date
            '====== TEST ================
            dtOriginalSentDate = tmmOriginal.MessageDateSent
            Dim strSenderID As String = tmmOriginal.Sender.ID
            Dim strSMTPID As String
            If tmmOriginal.SMTPProfile IsNot Nothing Then
                strSMTPID = tmmOriginal.SMTPProfile.ID
            ElseIf tmmOriginal.POPProfile IsNot Nothing Then
                strSMTPID = tmmOriginal.POPProfile.SMTPProfileID
            Else
                strSMTPID = String.Empty
            End If
            Dim strSenderName As String
            Dim strSenderAddress As String = String.Empty
            Dim strCurrentUserEmailAddress As String = String.Empty
            Dim boolEncrypted As Boolean = tmmOriginal.Encrypted

            Dim tm As TrulyMailMessage = New TrulyMailMessage(originalMessageFilename)

            If strSenderID = String.Empty Then
                If tmmOriginal.Sent Then
                    If tmmOriginal.SMTPProfile IsNot Nothing Then
                        strSenderAddress = tmmOriginal.SMTPProfile.DisplayEmail
                        strSenderName = tmmOriginal.SMTPProfile.DisplayName
                    Else
                        '-- SMTP profile must have been deleted
                        strSenderAddress = String.Empty
                        strSenderName = String.Empty
                    End If
                Else
                    strSenderAddress = tmmOriginal.Sender.Address
                    strSenderName = tmmOriginal.Sender.FullName
                End If

                '-- 2014-08-31 changing from sender address to smtp id because why would we have sender address when we have smtpID (creating bug with followup sent emails)
                If strSenderAddress.Length = 0 AndAlso strSMTPID.Length = 0 Then
                    'If strSMTPID.Length = 0 Then
                    Select Case tm.TransportType
                        Case MessageTransportType.TrulyMail
                            '-- most likely, this is a follow up to a sent email
                            If strSMTPID.Length > 0 Then
                                Dim smtp As SMTPProfile = SMTPProfile.GetByID(strSMTPID)
                                strCurrentUserEmailAddress = smtp.DisplayEmail
                                m_strSMTPID = strSMTPID
                            End If
                            '-- No sender, should never get here (we would be replying to ourself)
                            strSenderName = "Unknown"
                        Case MessageTransportType.Mixed
                            '-- most likely, this is a follow up to a sent email
                            If strSMTPID.Length > 0 Then
                                Dim smtp As SMTPProfile = SMTPProfile.GetByID(strSMTPID)
                                strCurrentUserEmailAddress = smtp.DisplayEmail
                                m_strSMTPID = strSMTPID
                            End If
                            '-- No sender, should never get here (we would be replying to ourself)
                            strSenderName = "Unknown"
                        Case Else
                            '-- RSS, page monitor
                            strSenderName = tm.SenderName
                    End Select
                Else
                    '-- email
                    If strSMTPID.Length = 0 Then
                        '-- not a sent email
                        '   Must set the SMTP account and the recip (previous sender)
                        strSenderName = tmmOriginal.Sender.FullName ' xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDERFULLNAME)
                        If strSenderName.Length = 0 Then
                            strSenderName = GetUserNameFromEmailAddress(strSenderAddress)
                        End If

                        Dim popID As String
                        If tmmOriginal.POPProfile Is Nothing Then
                            popID = String.Empty
                        Else
                            popID = tmmOriginal.POPProfile.ID 'xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_POPACCOUNT)
                        End If

                        For Each pop As POPProfile In AppSettings.POPProfiles
                            If pop.ID = popID Then
                                '-- Use this as the SMTP account for this new message
                                m_strSMTPID = pop.SMTPProfileID
                                For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
                                    If smtp.ID = m_strSMTPID Then
                                        strCurrentUserEmailAddress = smtp.DisplayEmail
                                        Exit For
                                    End If
                                Next
                                Exit For
                            End If
                        Next

                    Else
                        '-- was sent, need to setup SMTP account
                        Dim smtp As SMTPProfile = SMTPProfile.GetByID(strSMTPID)
                        strCurrentUserEmailAddress = smtp.DisplayEmail
                        m_strSMTPID = strSMTPID
                    End If
                End If

            Else
                strSenderName = GetUserNameFromID(strSenderID)
            End If

            Dim recipient As RecipientEntry

            Dim strReplyTo As String = tmmOriginal.ReplyTo

            Dim boolAtLeastOneFileAttached As Boolean

            Dim strMessageID As String = tmmOriginal.MessageID
            Dim strBodyHeader As String = Environment.NewLine & Environment.NewLine & "-------- Original Message --------" _
                                          & Environment.NewLine & "Subject: " & strSubject _
                                          & Environment.NewLine & "Date: " & dtOriginalSentDate.ToString() _
                                          & Environment.NewLine & "From: " & strSenderName _
                                          & Environment.NewLine & Environment.NewLine

            Select Case responseType
                Case MessageResponseType.Reply, MessageResponseType.ReplyNoBody
                    '-- include sender only but no attachments
                    If Not strSubject.ToLower.StartsWith(SUBJECT_PREFIX_REPLY.ToLower) AndAlso Not strSubject.ToLower.StartsWith(SUBJECT_PREFIX_REPLY_ALT.ToLower) Then
                        strSubject = SUBJECT_PREFIX_REPLY & strSubject '-- Add RE: only if we don't already start with RE: or RE :
                    End If

                    '-- Include only the sender
                    '   First, see if there is a different reply-to address (used only for email)
                    If strReplyTo.Length > 0 AndAlso IsValidEmailAddress(strReplyTo) Then
                        Dim entry As AddressBookEntry = ABook.GetContactByAddress(strReplyTo) 'GetAddressBookEmailEntry(strReplyTo)
                        If entry IsNot Nothing Then
                            recipient = New RecipientEntry(entry)
                        Else
                            recipient = New RecipientEntry(AddressBookEntryType.Email)
                            If strReplyTo.Length > 0 Then
                                recipient.Address = strReplyTo
                                recipient.FullName = String.Empty
                            Else
                                recipient.Address = tmmOriginal.Sender.Address
                                recipient.FullName = tmmOriginal.Sender.FullName
                            End If
                        End If
                        recipient.RecipientType = RecipientType.Send_To
                    Else
                        If strSenderAddress.Length = 0 Then
                            Try
                                recipient = New RecipientEntry(ABook.GetContactByID(strSenderID))
                                recipient.RecipientType = RecipientType.Send_To
                            Catch ex As Exception
                                Log(ex)
                                recipient = Nothing
                            End Try
                        Else
                            recipient = New RecipientEntry(AddressBookEntryType.Email)
                            recipient.Address = tmmOriginal.Sender.Address
                            recipient.FullName = tmmOriginal.Sender.FullName
                            recipient.RecipientType = RecipientType.Send_To
                        End If
                    End If

                    If recipient IsNot Nothing Then
                        m_lstRecipientsToAdd.Add(recipient)
                    End If

                    m_modifyProcess = ModifyOnSend.MarkReply
                Case MessageResponseType.ReplyToAll, MessageResponseType.ReplyToAllNoBody
                    '-- include sender and all recipients but no attachments
                    If Not strSubject.ToLower.StartsWith(SUBJECT_PREFIX_REPLY.ToLower) AndAlso Not strSubject.ToLower.StartsWith(SUBJECT_PREFIX_REPLY_ALT.ToLower) Then
                        strSubject = SUBJECT_PREFIX_REPLY & strSubject
                    End If

                    '-- first include the sender
                    '   while first checking to see if there is an overridding reply-to header
                    If strReplyTo.Length > 0 AndAlso IsValidEmailAddress(strReplyTo) Then
                        Dim entry As AddressBookEntry = ABook.GetContactByAddress(strReplyTo)
                        If entry IsNot Nothing Then
                            recipient = New RecipientEntry(entry)
                        Else
                            recipient = New RecipientEntry(AddressBookEntryType.Email)
                            If strReplyTo.Length > 0 Then
                                recipient.Address = strReplyTo
                                recipient.FullName = String.Empty
                            Else
                                recipient.Address = tmmOriginal.Sender.Address
                                recipient.FullName = tmmOriginal.Sender.FullName
                            End If
                        End If
                        recipient.RecipientType = RecipientType.Send_To
                    Else
                        If strSenderAddress.Length = 0 Then
                            Dim addressEntry As AddressBookEntry
                            Try
                                addressEntry = ABook.GetContactByID(strSenderID)
                            Catch ex As Exception
                                Log(ex)
                                addressEntry = Nothing
                            End Try

                            If addressEntry IsNot Nothing Then
                                recipient = New RecipientEntry(addressEntry)
                                If recipient IsNot Nothing AndAlso recipient.ID IsNot Nothing Then
                                    recipient.RecipientType = RecipientType.Send_To
                                Else
                                    recipient = Nothing
                                End If
                            Else
                                recipient = Nothing
                            End If
                        Else
                            recipient = New RecipientEntry(AddressBookEntryType.Email)
                            recipient.Address = tmmOriginal.Sender.Address
                            recipient.FullName = tmmOriginal.Sender.FullName
                            recipient.RecipientType = RecipientType.Send_To
                        End If
                    End If

                    If recipient IsNot Nothing Then
                        m_lstRecipientsToAdd.Add(recipient)
                    End If


                    '=========== TEST ===================

                    Dim boolAddThisRecip As Boolean
                    For Each recip As RecipientEntry In tmmOriginal.Recipients
                        boolAddThisRecip = True '-- reset for this loop
                        If recip.RecipientType = RecipientType.Send_BCC Then
                            If Not AppSettings.DoNotShowReplyAllBCCNotice Then
                                Using frm As New NotifyForm("You were a BCC recipient on the original message. Reply to All will show everyone else that you received the original message.", NotifyForm.DoNotShowSetting.DoNotShowReplyAllBCCNotice)
                                    frm.ShowDialog(MainFormReference)
                                End Using
                            End If
                        End If

                        '-- Make sure we don't add the user...that would be silly
                        If recip.Address.ToLower() = tmmOriginal.POPProfile.Username.ToLower() Then
                            '-- skip, do nothing
                            boolAddThisRecip = False
                        Else
                            Dim smtp As SMTPProfile = GetSMTPProfileByID(tmmOriginal.POPProfile.SMTPProfileID)
                            If smtp Is Nothing Then
                                '-- no smtp means we don't know where this msg came from, so add this recip to be safe
                                '   Might have been received on an old account which was removed from TM
                                boolAddThisRecip = True
                            Else
                                If recip.Address.ToLower() = smtp.DisplayEmail.ToLower() Then
                                    '-- skip, do nothing
                                    boolAddThisRecip = False
                                Else
                                    '-- should be ok to add this recipient
                                    boolAddThisRecip = True
                                End If
                            End If
                        End If

                        If boolAddThisRecip Then
                            recipient = New RecipientEntry(AddressBookEntryType.Email)
                            recipient.Address = recip.Address
                            recipient.FullName = recip.FullName
                            recipient.RecipientType = RecipientType.Send_CC

                            m_lstRecipientsToAdd.Add(recipient)
                        End If
                    Next


                    m_modifyProcess = ModifyOnSend.MarkReply
                Case MessageResponseType.Forward, MessageResponseType.ForwardNoAttachments
                    '-- include attachments but no recipients

                    '-- strip RE: off start of subject
                    If strSubject.ToLower.StartsWith(SUBJECT_PREFIX_REPLY.ToLower) Then
                        strSubject = Trim(strSubject.Substring(SUBJECT_PREFIX_REPLY.Length))
                    End If
                    If strSubject.ToLower.StartsWith(SUBJECT_PREFIX_REPLY_ALT.ToLower) Then
                        strSubject = Trim(strSubject.Substring(SUBJECT_PREFIX_REPLY_ALT.Length))
                    End If

                    If Not strSubject.ToLower.StartsWith(SUBJECT_PREFIX_FORWARD.ToLower) Then
                        strSubject = SUBJECT_PREFIX_FORWARD & strSubject
                    End If

                    If responseType = MessageResponseType.Forward Then
                        For Each item As AttachmentItem In tmmOriginal.Attachments
                            m_lstAttachmentsToAdd.Add(item.Filename)
                            boolAtLeastOneFileAttached = True
                        Next
                    End If
                    m_modifyProcess = ModifyOnSend.MarkForward
                    m_controlToFocusOnLoad = txtAddressSearch
                Case MessageResponseType.Resend
                    '-- Resend original just as it was with all attachments and recipients
                    If Not strSubject.ToLower.StartsWith(SUBJECT_PREFIX_RESEND.ToLower) Then
                        strSubject = SUBJECT_PREFIX_RESEND & strSubject
                    End If


                    For Each item As AttachmentItem In tmmOriginal.Attachments
                        m_lstAttachmentsToAdd.Add(item.Filename)
                        boolAtLeastOneFileAttached = True
                    Next

                    For Each recip As RecipientEntry In tmmOriginal.Recipients
                        recipient = New RecipientEntry(AddressBookEntryType.Email)
                        recipient.Address = recip.Address
                        recipient.FullName = recip.FullName
                        recipient.RecipientType = recip.RecipientType

                        m_lstRecipientsToAdd.Add(recipient)
                    Next

                    m_modifyProcess = ModifyOnSend.None

                    '-- We need to keep the receipt request and encryption mode the same as the original

                    ReturnReceiptToolStripButton.Checked = tmmOriginal.ReturnReceiptRequested
                    RequestReturnReceiptemailOnlyToolStripMenuItem.Checked = ReturnReceiptToolStripButton.Checked

                    If tmmOriginal.Encrypted Then
                        m_defaultEncryption = DefaultEncryptionSetting.TM2TM
                    Else
                        m_defaultEncryption = DefaultEncryptionSetting.ClearText
                    End If
                Case MessageResponseType.FollowUp
                    '-- include sender and all recipients but no attachments
                    If Not strSubject.ToLower.StartsWith(SUBJECT_PREFIX_FOLLOWUP.ToLower) Then
                        strSubject = SUBJECT_PREFIX_FOLLOWUP & strSubject
                    End If

                    For Each recip As RecipientEntry In tmmOriginal.Recipients
                        recipient = New RecipientEntry(AddressBookEntryType.Email)
                        recipient.Address = recip.Address
                        recipient.FullName = recip.FullName
                        recipient.RecipientType = recip.RecipientType

                        m_lstRecipientsToAdd.Add(recipient)
                    Next


                    m_modifyProcess = ModifyOnSend.MarkForward
            End Select

            '-- Set the message body text
            Dim strBody As String
            If tmmOriginal.BodyFormat = EmailBodyFormatEnum.PlainText Then
                strBody = tmmOriginal.Body
            Else
                'strBody = StripHTML(tmmOriginal.Body)
                strBody = ConvertHtmlToPlainText(tmmOriginal.Body) '-- switch to HtmlAgilityPack

                '-- Extra logic because TrulyMail will 
                '   add "< {[ATTACHMENTSFOLDER]}b39f21bd-b356-474a-93a0-7f581c4b0b48\Images\image002_e041f1cf-cb56-48be-8a88-8f945d37a10d.png >
                Dim intPosStart, intPosEnd As Integer
                Do While True
                    intPosStart = strBody.IndexOf("< {[ATTACHMENTSFOLDER]}")
                    If intPosStart = -1 Then
                        Exit Do
                    End If
                    intPosEnd = strBody.IndexOf(" >", intPosStart)
                    If intPosEnd = -1 Then
                        Exit Do
                    End If
                    'Log("Old body: " & strBody)
                    'Log("Replacing: " & strBody.Substring(intPosStart, intPosEnd + 2 - intPosStart))
                    strBody = strBody.Substring(0, intPosStart - 1) & strBody.Substring(intPosEnd + 1)
                    'Log("New body: " & strBody)
                Loop
            End If

            strBody = strBodyHeader & strBody

            Select Case responseType
                Case MessageResponseType.ReplyNoBody, MessageResponseType.ReplyToAllNoBody
                    Application.DoEvents() '-- do not include body
                Case Else
                    '-- otherwise, include the body
                    txtMessageBody.Text = strBody
            End Select

            txtSubject.Text = strSubject

            If boolAtLeastOneFileAttached Then
                AttachmentsChanged()
            End If

            If tmmOriginal.Encrypted Then
                m_emailEncryption = EncryptedEmailType.EncrypedTM2TMEmail
            End If

            m_autoTextToUse = GetAutoText(responseType)


            Dirty = False

        Catch ex As Exception
            Log(ex)
            Log("originalMessageFilename is nothing: " & (originalMessageFilename Is Nothing))
            ShowMessageBoxError("There was an error creating the new message." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
            Me.Close()
        End Try
    End Sub
    ''' <summary>
    ''' For sending from addressbook
    ''' </summary>
    ''' <param name="lst">ArrayList of AddressBookEntry objects</param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal lst As ArrayList)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        '-- Add all users to message
        For Each addressEntry As AddressBookEntry In lst
            Dim entry As New RecipientEntry(addressEntry)
            m_lstRecipientsToAdd.Add(entry)
        Next
        'AddRecipientList(lst, RecipientType.Send_To)

        m_emailEncryption = CType(AppSettings.DefaultEmailEncryption, EncryptedEmailType)

        'Editor1.BackColor = AppSettings.NewMessageBackgroundColor
        m_autoTextToUse = GetAutoText(MessageResponseType.Resend) '-- not a nice hack, but using resend to represent new messages

        Dirty = False
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_emailEncryption = CType(AppSettings.DefaultEmailEncryption, EncryptedEmailType)

        'Editor1.BackColor = AppSettings.NewMessageBackgroundColor
        m_autoTextToUse = GetAutoText(MessageResponseType.Resend) '-- not a nice hack, but using resend to represent new messages

        m_controlToFocusOnLoad = txtAddressSearch
        m_boolDirty = False
    End Sub
#End Region

#Region " For external access (API) "
    Public Sub CloseDiscard()
        EnableMessage()
        Dirty = False
        Close()
    End Sub
    Public Sub CloseSaveAsDraft()
        EnableMessage()
        SaveAsDraft()
        Close()
    End Sub
    Public Property RequestReadReceipt
        Get
            Return RequestReturnReceiptemailOnlyToolStripMenuItem.Checked
        End Get
        Set(value)
            RequestReturnReceiptemailOnlyToolStripMenuItem.Checked = value
            ReturnReceiptToolStripButton.Checked = value
        End Set
    End Property
    Public Sub AddRecipient(name As String, email As String) Implements IComposeForm.AddRecipient
        Dim abe As New AddressBookEntry(AddressBookEntryType.Email)
        abe.Address = email
        abe.FullName = name
        Dim lst As New List(Of AddressBookEntry)
        lst.Add(abe)
        AddRecipientList(lst, RecipientType.Send_To)

        Application.DoEvents()

    End Sub
    Public Property Subject As String Implements IComposeForm.Subject
        Get
            Return txtSubject.Text
        End Get
        Set(value As String)
            txtSubject.Text = value
        End Set
    End Property
    Public Property Body As String Implements IComposeForm.Body
        Get
            Return Me.txtMessageBody.Text
        End Get
        Set(value As String)
            Me.txtMessageBody.Text = value
        End Set
    End Property
    Public Property SendAsPlainText As Boolean Implements IComposeForm.SendAsPlainText
        Get
            Return True '-- this form can only send as plain text...or can it?
        End Get
        Set(value As Boolean)
            Application.DoEvents() '-- ignore this api call
        End Set
    End Property
    Public Sub AddAttachment(filename As String) Implements IComposeForm.AddAttachment
        Dim boolAtLeastOneFileAttached As Boolean
        If AddAttachmentToList(filename, True) Then
            boolAtLeastOneFileAttached = True
        End If

        If boolAtLeastOneFileAttached Then
            AttachmentsChanged()
        End If
    End Sub
    Public Sub SendThisMessage(sendWhen As Date) Implements IComposeForm.SendThisMessage
        '-- used only for API
        SendMessage(sendWhen)
    End Sub
    Public Sub UseSendingAccount(index As Integer) Implements IComposeForm.UseSendingAccount
        If cboSMTPAccount.Items.Count > index Then
            cboSMTPAccount.SelectedIndex = index
        Else
            Throw New Exception("Invalid sending account selected. There are " & cboSMTPAccount.Items.Count.ToString() & " to choose from.")
        End If
    End Sub
#End Region


    ''' <summary>
    ''' Overrides global GetTempFilename to be more appropriate for this one message
    ''' </summary>
    ''' <param name="fileExtension">The file extension (for example: .jpg) for the new filename</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTempFilename(fileExtension As String) As String
        Dim strFilename As String
        Static intCounter As Integer
        Do
            intCounter += 1
            strFilename = MessageStoreTempPath & "Att-" & intCounter.ToString() & fileExtension
        Loop While System.IO.File.Exists(strFilename)
        Return strFilename
    End Function
    Friend Sub ModifyMessageOnSend(ByVal messageFilename As String, ByVal modifyHow As ModifyOnSend)
        m_modifyProcess = modifyHow
        m_strMessageToModifyOnSent = messageFilename
    End Sub

    Private Sub SendMessage(ByVal toList As List(Of RecipientEntry), ByVal subject As String,
                        ByVal body As String, ByVal attachmentList As List(Of String),
                        ByVal sendWhen As Date)
        m_msgSender = New MessageSender(MessageType.Communication)

        '-- If there are blocked images, unblock before sending
        m_msgSender.Body = body

        m_msgSender.Subject = subject
        m_msgSender.KeepCopyAfterSend = SaveACopyToolStripButton.Checked
        m_msgSender.RequestReturnReceipt = ReturnReceiptToolStripButton.Checked
        m_msgSender.NewsletterMode = m_boolNewsletterMode
        m_msgSender.ZipAttachments = chkZipAttachments.Checked

        Dim boolAtLeastOneEmailRecipient As Boolean

        For intLoopCounter As Integer = 0 To toList.Count - 1
            Dim recip As RecipientEntry = toList(intLoopCounter)
            m_msgSender.AddRecipient(recip)

            If recip.ContactType = AddressBookEntryType.Email Then
                boolAtLeastOneEmailRecipient = True
            End If
        Next

        If cboSMTPAccount.Items.Count = 0 Then
            If ShowMessageBox("Sending to an email address requires at least one email account." &
                           Environment.NewLine & Environment.NewLine &
                           "Please go to Tools->Email Accoounts (on the main TrulyMail window) to setup an email account." &
                           Environment.NewLine & Environment.NewLine &
                           "Then, select the email account from the 'From' drop down at the top of the message." &
                           Environment.NewLine & Environment.NewLine &
                           "You may need to save this message as a draft and reopen it to see the new email account listed." &
                           Environment.NewLine & Environment.NewLine &
                           "Would you like to setup an email account now?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                MainFormReference.SetupEmailAccounts()
                LoadSMTPAccounts()
            End If
            EnableMessage()
            Exit Sub
        End If

        If boolAtLeastOneEmailRecipient Then
            '-- put the smtpid on only for cleartext and encryptedpackage, since webmessage doesn't really go through client's email
            Dim smtp As SMTPProfile = cboSMTPAccount.SelectedItem

            m_msgSender.EmailEncryptionType = m_emailEncryption
            m_msgSender.SMTPAccount = smtp.ID
            m_msgSender.BodyFormat = EmailBodyFormatEnum.PlainText
        End If


        '-- if webmail, prompt for question, answer/password
        If m_emailEncryption = EncryptedEmailType.EncrypedTM2TMEmail Then
            '-- if TM2TM then prompt for password
            Dim frm As New EncryptedWebmailPasswordSelector(toList)
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                m_msgSender.TM2TMEncryptionPassword = frm.EncryptionPassword
            Else
                '-- cancelled
                EnableMessage()
                Exit Sub
            End If
        End If

        For intLoopCounter As Integer = 0 To attachmentList.Count - 1
            m_msgSender.AddAttachment(attachmentList(intLoopCounter))
        Next

        '-- The module-level variable is really for tracking drafts but we need one for the reminder
        Dim strMessageID As String
        If m_strMessageID.Length > 0 Then
            strMessageID = m_strMessageID
        Else
            strMessageID = Guid.NewGuid.ToString()
        End If

        Try
            m_msgSender.SendMessage(sendWhen, strMessageID)
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error sending this message (" & ex.Message & ")." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
            EnableMessage()
            Exit Sub
        End Try

        Dirty = False

        '-- if we have a draft and must delete it
        '   26 Aug 2010 changed to leave attachments, which means bypassing the DeleteLocalMessage routine
        If m_strMessageID.Length > 0 Then
            'DeleteLocalMessage(DraftsRootPath & m_strMessageID & MESSAGE_FILENAME_EXTENSION, True, True)
            DeleteLocalFile(DraftsRootPath & m_strMessageID & MESSAGE_FILENAME_EXTENSION)
            MainFormReference.ShowFolderContentsIfCurrent(DraftsRootPath)
        End If

        '-- modify any 'other' message as appropriate
        Select Case m_modifyProcess
            Case ModifyOnSend.None
                '-- do nothing
            Case ModifyOnSend.Delete
                DeleteLocalMessage(m_strMessageToModifyOnSent, False, True)
            Case ModifyOnSend.MarkForward
                MarkMessage(m_strMessageToModifyOnSent, MarkMessageType.Forward)
                MainFormReference.UpdateMessage(m_strMessageToModifyOnSent)
            Case ModifyOnSend.MarkReply
                MarkMessage(m_strMessageToModifyOnSent, MarkMessageType.Reply)
                MainFormReference.UpdateMessage(m_strMessageToModifyOnSent)
        End Select


        '-- always close immediately
        CloseForm()

    End Sub

    Private Sub MarkMessage(ByVal filename As String, ByVal markAs As MarkMessageType)
        'Dim xDoc As New Xml.XmlDocument()
        Dim tmm As TrulyMailMessage
        Try
            'xDoc.Load(filename)
            'If AppSettings.AddNoteWhenChangingSubject Then
            tmm = New TrulyMailMessage(filename)
            'End If
        Catch ex As Exception
            '-- cannot find original message to modify
            Exit Sub
        End Try

        Select Case markAs
            Case MarkMessageType.Forward
                'xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FORWARDED, Date.UtcNow.ToString(DATEFORMAT_XML))
                'If AppSettings.AddNoteWhenChangingSubject Then
                '    tmm.AppendNote(Date.Now.ToString("yyyy-MM-dd hh:mm") & " - message forwarded.")
                '    tmm.Save()
                'End If
                tmm.MarkForwarded()
            Case MarkMessageType.Reply
                'xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_REPLIED, Date.UtcNow.ToString(DATEFORMAT_XML))
                'If AppSettings.AddNoteWhenChangingSubject Then
                '    tmm.AppendNote(Date.Now.ToString("yyyy-MM-dd hh:mm") & " - message replied.")
                '    tmm.Save()
                'End If
                tmm.MarkReplied()
        End Select

        Try
            tmm.Save()
            MainFormReference.UpdateMessage(filename)
            'xDoc.Save(filename)
        Catch ex As Exception
            '-- cannot write to the file
            Log(ex)
            Exit Sub
        End Try
    End Sub
    ''' <summary>
    ''' Removes email recipients without an address
    ''' </summary>
    ''' <returns>True if everything is OK, false if caller should stop processing</returns>
    ''' <remarks></remarks>
    Private Function StripBadRecipients() As Boolean
        If olvRecipients.Objects IsNot Nothing Then
            For Each entry As RecipientEntry In olvRecipients.Objects
                If entry.ContactType = AddressBookEntryType.TrulyMail Then
                    ShowMessageBoxError("You can no longer send through TrulyMail servers. Please change to send to only email addresses.")
                    Return False
                Else
                    '-- email
                    If entry.Address.Trim.Length = 0 Then
                        olvRecipients.RemoveObject(entry)
                        StripBadRecipients()
                        Exit For
                    ElseIf Not IsValidEmailAddress(entry.Address.Trim) Then
                        ShowMessageBoxError(entry.Address.Trim & " is not a valid email address. Please correct this.")
                        Return False
                    End If
                End If
            Next
        End If

        Return True
    End Function
    Private Sub SendMessage(ByVal sendWhen As Date)
        If Not StripBadRecipients() Then
            Exit Sub
        End If

        AttachmentsChanged()

        If m_boolAtLeastOneAttachmentMissing Then
            ShowMessageBoxError("At least one attachment is missing so this message cannot be sent.")
            Exit Sub
        End If

        If AtLeastOneTrulyMailRecipient() Then
            ShowMessageBoxError("You can no longer send through TrulyMail servers. You should send to the contact's email address.")
            Exit Sub
        End If

        If Not AppSettings.DoNotShowMissingSubjectNotice Then
            If txtSubject.Text.Trim.Length = 0 Then
                Using frm As New NotifyForm("This message has no subject. Would you still like to send it?", NotifyForm.DoNotShowSetting.DoNotShowMissingSubjectNotice, MessageBoxButtons.YesNo)
                    If frm.ShowDialog(MainFormReference) = DialogResult.No Then
                        Exit Sub
                    End If
                End Using
            End If
        End If

        If m_boolNeedSpellCheck Then
            m_dtSendLater = sendWhen
            SpellCheck(False, True)
        Else
            m_strSendingErrorText = String.Empty '-- reset each time

            m_boolCancelSending = False

            '-- queue up recipients
            Dim boolAddToMessage As Boolean
            Dim sendList As New List(Of RecipientEntry)
            Dim boolAtLeastOneTrulyMail As Boolean
            If olvRecipients.Objects IsNot Nothing Then
                For Each entry As RecipientEntry In olvRecipients.Objects
                    boolAddToMessage = True
                    If entry.ContactType = AddressBookEntryType.TrulyMail Then
                        boolAtLeastOneTrulyMail = True
                    Else
                        If AppSettings.EmailAutoAddRecipientsOnSend AndAlso cboSMTPAccount.Items.Count > 0 Then
                            If entry.Address.Length = 0 Then
                                boolAddToMessage = False
                                Continue For
                            End If
                            If entry.ID.Length = 0 Then
                                '-- this email address needs added, store in address book
                                '   but first check that it is not already in the address book
                                Dim addressBookEntry As AddressBookEntry = ABook.GetContactByAddress(entry.Address) 'GetAddressBookEmailEntry(entry.Address)
                                If addressBookEntry Is Nothing Then
                                    '-- Add it
                                    addressBookEntry = New AddressBookEntry(AddressBookEntryType.Email)
                                    addressBookEntry.Address = entry.Address
                                    If entry.FullName.Length > 0 Then
                                        addressBookEntry.FullName = entry.FullName
                                    Else
                                        addressBookEntry.FullName = GetUserNameFromEmailAddress(entry.Address)
                                    End If

                                    '-- add SMTPID
                                    If AppSettings.EmailAutoAddRecipientsTieSMTP Then
                                        addressBookEntry.SMTPID = CType(cboSMTPAccount.SelectedItem, SMTPProfile).ID
                                    Else
                                        addressBookEntry.SMTPID = String.Empty
                                    End If
                                    ABook.Add(addressBookEntry)
                                    ABook.Save()
                                Else
                                    '-- Already in the address book, just update the name if it exists
                                    If entry.FullName.Length > 0 Then
                                        addressBookEntry.FullName = entry.FullName
                                    End If
                                    addressBookEntry.Active = True '-- re-activate it, if necessary
                                    ABook.Save()
                                End If

                                entry.ID = addressBookEntry.ID
                            End If
                        End If
                    End If
                    If boolAddToMessage Then
                        sendList.Add(entry)
                    End If
                Next
            End If

            If sendList.Count = 0 Then
                EnableMessage()
                MessageBox.Show("Nowhere to send.", Application.ProductName)
                Exit Sub
            End If

            If sendList.Count > 0 Then
                'If m_emailEncryption = EncryptedEmailType.EncryptedWebmail AndAlso m_lstAttachments.Count > 0 Then
                '    ShowMessageBoxError("Encrypted Web Messages do not support attachments (since all decryption will happen inside the recipient's browser).")
                '    Exit Sub
                'End If

                '-- queue up attachments for recipients
                Dim attachments As New List(Of String)
                For intCounter As Integer = 0 To m_lstAttachments.Count - 1
                    '-- It is possible that an attachment gets added twice, this prevents it
                    'TODO: Correct the problem from happening elsewhere
                    If Not attachments.Contains(m_lstAttachments.Item(intCounter).Filename) Then
                        attachments.Add(m_lstAttachments.Item(intCounter).Filename)
                    End If
                Next

                '-- and away we go
                Dim data As New SendMessageData
                data.recipientList = sendList
                data.subject = txtSubject.Text
                data.body = txtMessageBody.Text

                data.attachmentList = attachments
                data.sendWhen = sendWhen

                m_lngTotalPostingSize = (data.body.Length * sendList.Count) + m_lngTotalAttachmentSize
                m_lngTotalPostingSize += m_lngTotalEmbededImageSize
                m_lngTotalPostedSoFar = 0

                Dim boolOKToSend As Boolean = True

                If boolOKToSend Then
                    DisableMessage()

                    SendMessage(data.recipientList, data.subject, data.body, data.attachmentList, sendWhen)
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Add the attachment to the list if it is not already there
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <remarks></remarks>
    ''' <returns>True if file was added to attachments list</returns>
    Friend Function AddAttachmentToList(ByVal filename As String, ByVal allowResize As Boolean) As Boolean Implements IComposeForm.AddAttachmentToList
        Static intImageResizeMaxSide As Integer = GetMaxSideForSize(AppSettings.ImageResizeSize)
        Static boolPromptedForResizeAlready As Boolean

        If IsFileImage(filename) AndAlso allowResize Then
            If AppSettings.ImageResizePromptFrequency = ImageResizePromptFrequencyEnum.EveryImage OrElse (AppSettings.ImageResizePromptFrequency = ImageResizePromptFrequencyEnum.EveryMessage AndAlso boolPromptedForResizeAlready = False) Then
                Dim frm As New ImageResizePrompt()
                If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

                    boolPromptedForResizeAlready = True
                    intImageResizeMaxSide = GetMaxSideForSize(frm.ImageResizeSize)
                End If
            End If

            '-- now resize the image
            If intImageResizeMaxSide > 0 Then
                Dim strDestination As String = MessageStoreTempPath & System.IO.Path.GetFileName(filename)
                Dim imgFormat As System.Drawing.Imaging.ImageFormat = GetImageFormat(filename)
                ResizeImage(filename, strDestination, imgFormat, intImageResizeMaxSide)
                filename = strDestination
            End If

        End If


        Dim attachItem As AttachmentItem
        Dim boolExistsAlready As Boolean

        If Not System.IO.File.Exists(filename) Then
            Return False '-- file not found, cannot be attached
        Else
            For Each attachItem In m_lstAttachments
                If attachItem.Filename.ToLower = filename.ToLower Then
                    boolExistsAlready = True
                    Exit For
                End If
            Next
        End If


        If Not boolExistsAlready Then
            attachItem = New AttachmentItem
            attachItem.Filename = filename
            attachItem.DisplayName = System.IO.Path.GetFileName(filename)
            attachItem.FileSize = FileLen(filename)
            m_lstAttachments.Add(attachItem)

            Dirty = True
            olvAttachments.SetObjects(m_lstAttachments)
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub lstvAttachments_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles olvAttachments.DragDrop, olvRecipients.DragDrop
        Try
            Dim boolAtLeastOneFileAttached As Boolean
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim objFilenames As Object = e.Data.GetData(DataFormats.FileDrop)
                Dim strFilenames() As String = CType(objFilenames, String())
                For Each strFilename As String In strFilenames
                    If System.IO.Directory.Exists(strFilename) Then
                        Dim strZipfilePath As String = GetTempPath() & System.IO.Path.GetFileName(strFilename) & ".zip"
                        If System.IO.File.Exists(strZipfilePath) Then
                            DeleteLocalFile(strZipfilePath)
                        End If
                        Using zip As New Ionic.Zip.ZipFile(strZipfilePath)
                            zip.AddDirectory(strFilename, String.Empty)
                            zip.Save()
                        End Using
                        If AddAttachmentToList(strZipfilePath, True) Then
                            boolAtLeastOneFileAttached = True
                        End If
                    Else
                        If AddAttachmentToList(strFilename, True) Then
                            boolAtLeastOneFileAttached = True
                        End If
                    End If
                Next
            End If

            '-- only update things if the attachments changed
            If boolAtLeastOneFileAttached Then
                AttachmentsChanged()
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error adding the attachment. Please contact TrulyMail Support.")
        End Try
    End Sub
    Private Sub lstvAttachments_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles olvAttachments.DragOver, olvRecipients.DragOver
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Friend Sub AddRecipientList(ByVal lst As List(Of AddressBookEntry), ByVal recipientType As RecipientType)
        '-- First build up list of existing recipients, so we can eliminate dups later
        Dim existingRecipients As List(Of RecipientEntry)
        Dim existingRecipients2 As ArrayList
        If TypeOf olvRecipients.Objects Is List(Of RecipientEntry) Then
            existingRecipients = olvRecipients.Objects
        Else
            existingRecipients2 = olvRecipients.Objects
            If existingRecipients2 IsNot Nothing Then
                existingRecipients = New List(Of RecipientEntry)
                For Each item As RecipientEntry In existingRecipients2
                    existingRecipients.Add(item)
                Next
            End If
        End If

        If txtSubject.Text.Trim.Length = 0 Then
            '-- no subject yet, so put it there
            m_controlToFocusOnLoad = txtSubject
        Else
            '-- already have a subject, focus on editor
            m_controlToFocusOnLoad = txtMessageBody
        End If

        '-- If form is not visible, the ContactType (TM, Email) and RecipType (To, CC) will not show
        '   must be a bug in OLV because if the form is visible it works fine
        '   so just show it before adding the recipients
        Me.Show()
        Application.DoEvents()


        For Each address As AddressBookEntry In lst
            Dim entry As New RecipientEntry(address)
            entry.RecipientType = recipientType
            Dim boolAddEntry As Boolean = True
            '-- check that the ID is not already in the recipient list
            If existingRecipients IsNot Nothing Then
                For Each existingRecip As RecipientEntry In existingRecipients
                    If entry.ID = existingRecip.ID Then
                        '-- this user is already in the recip list, do not add it again
                        '   However, we should switch to the specified recipType (To,CC)
                        boolAddEntry = False
                        existingRecip.RecipientType = recipientType
                        'olvRecipients.RebuildColumns()
                        Exit For
                    End If
                Next
            End If

            If boolAddEntry Then
                TestEntryForWarnings(entry)

                '-- Warn if recip should receive receipt request but cannot because of user intervention
                If address.ContactType = AddressBookEntryType.Email Then
                    If address.AutoRequestReadReceipt Then
                        '-- we should request a receipt if any email recip requires it
                        If m_boolUserControlledReceiptRequest Then
                            If Not ReturnReceiptToolStripButton.Checked AndAlso Not AppSettings.DoNotShowReadReceiptWillNotBeRequested Then
                                '-- we cannot request a receipt because user has turned the receipt request off
                                Using frm As New NotifyForm(entry.FullName & " is marked to always request a read receipt but you have turned off the receipt for this message." &
                                                            Environment.NewLine & Environment.NewLine & "This message will not have a read receipt requested.", NotifyForm.DoNotShowSetting.DoNotShowReadReceiptWillNotBeRequested)
                                    frm.ShowDialog(MainFormReference)
                                End Using
                            End If
                        Else
                            ReturnReceiptToolStripButton.Checked = True
                            RequestReturnReceiptemailOnlyToolStripMenuItem.Checked = True
                            m_boolAtLeastOneAutoRequestReceiptRecipient = True
                        End If
                    End If

                    '-- Set SMTP account based on added recip
                    Dim abookEntry As AddressBookEntry = ABook.GetContactByAddress(entry.Address)
                    If abookEntry IsNot Nothing Then
                        If abookEntry.SMTPProfile IsNot Nothing Then
                            '-- set to most SMTP account of most recently added contact
                            cboSMTPAccount.SelectedItem = abookEntry.SMTPProfile
                        End If
                    End If

                    '-- set TM2TM encryption on by default if contact has encryption password
                    If entry.WebMessagePassword.Length > 0 Then
                        SetEmailEncryption(EncryptedEmailType.EncrypedTM2TMEmail)
                    End If
                End If

                olvRecipients.AddObject(entry)
                Dirty = True
                SetRecipientPanelHeight()
            End If

            m_strLastAddedRecipientID = entry.ID
        Next

        AutoSizeColumns(olvRecipients)
        SetEncryptionStatus()
        SetRecipientPanelHeight()
        Me.olvRecipients.Refresh()
    End Sub
    Private Sub TestEntryForWarnings(ByVal entry As RecipientEntry)
        Try
            If entry.ContactType = AddressBookEntryType.Email Then
                '-- warn about noreply email addresses
                Dim intPosition As Integer
                Dim strNoReplyText As String
                If Not AppSettings.DoNotShowEmailRecipientNoReply Then
                    strNoReplyText = "NoReply"
                    intPosition = entry.Address.ToLower.IndexOf(strNoReplyText.ToLower())
                    If intPosition > -1 AndAlso intPosition < entry.Address.IndexOf("@") Then
                        Using frm As New NotifyForm("Email addresses which include '" & strNoReplyText & "' are usually not intended to receive messages (telling you not to reply to the address)." &
                                                    Environment.NewLine & Environment.NewLine &
                                                    "Email address in question: " & entry.Address, NotifyForm.DoNotShowSetting.DoNotShowEmailRecipientNoReply)
                            frm.ShowDialog(MainFormReference)
                            GoTo EndOfDoNotReplyNotice
                        End Using
                    End If

                    '-- warn about no-reply email addresses (yahoo)
                    strNoReplyText = "No-Reply"
                    intPosition = entry.Address.ToLower.IndexOf(strNoReplyText.ToLower())
                    If intPosition > -1 AndAlso intPosition < entry.Address.IndexOf("@") Then
                        Using frm As New NotifyForm("Email addresses which include '" & strNoReplyText & "' are usually not intended to receive messages (telling you not to reply to the address)." &
                                                    Environment.NewLine & Environment.NewLine &
                                                    "Email address in question: " & entry.Address, NotifyForm.DoNotShowSetting.DoNotShowEmailRecipientNoReply)
                            frm.ShowDialog(MainFormReference)
                            GoTo EndOfDoNotReplyNotice
                        End Using
                    End If

                    '-- warn about do-not-reply email addresses (yahoo)
                    strNoReplyText = "Do-Not-Reply"
                    intPosition = entry.Address.ToLower.IndexOf(strNoReplyText.ToLower())
                    If intPosition > -1 AndAlso intPosition < entry.Address.IndexOf("@") Then
                        Using frm As New NotifyForm("Email addresses which include '" & strNoReplyText & "' are usually not intended to receive messages (telling you not to reply to the address)." &
                                                    Environment.NewLine & Environment.NewLine &
                                                    "Email address in question: " & entry.Address, NotifyForm.DoNotShowSetting.DoNotShowEmailRecipientNoReply)
                            frm.ShowDialog(MainFormReference)
                            GoTo EndOfDoNotReplyNotice
                        End Using
                    End If


                    strNoReplyText = "DoNotReply"
                    intPosition = entry.Address.ToLower.IndexOf(strNoReplyText.ToLower())
                    If intPosition > -1 AndAlso intPosition < entry.Address.IndexOf("@") Then
                        Using frm As New NotifyForm("Email addresses which include '" & strNoReplyText & "' are usually not intended to receive messages (telling you not to reply to the address)." &
                                                    Environment.NewLine & Environment.NewLine &
                                                    "Email address in question: " & entry.Address, NotifyForm.DoNotShowSetting.DoNotShowEmailRecipientNoReply)
                            frm.ShowDialog(MainFormReference)
                            GoTo EndOfDoNotReplyNotice
                        End Using
                    End If

                    strNoReplyText = "no_reply"
                    intPosition = entry.Address.ToLower.IndexOf(strNoReplyText.ToLower())
                    If intPosition > -1 AndAlso intPosition < entry.Address.IndexOf("@") Then
                        Using frm As New NotifyForm("Email addresses which include '" & strNoReplyText & "' are usually not intended to receive messages (telling you not to reply to the address)." &
                                                    Environment.NewLine & Environment.NewLine &
                                                    "Email address in question: " & entry.Address, NotifyForm.DoNotShowSetting.DoNotShowEmailRecipientNoReply)
                            frm.ShowDialog(MainFormReference)
                            GoTo EndOfDoNotReplyNotice
                        End Using
                    End If
                End If

EndOfDoNotReplyNotice:


                '-- test for conflicts in SMTPID for added email recipients
                Dim abookEntry As AddressBookEntry = ABook.GetContactByAddress(entry.Address)
                If abookEntry IsNot Nothing Then
                    If abookEntry.SMTPID IsNot Nothing AndAlso abookEntry.SMTPID.Length > 0 Then
                        '-- this contact has a specific SMTPID, see if it conflicts with existing contacts
                        If olvRecipients.Objects IsNot Nothing Then
                            For Each recip As RecipientEntry In olvRecipients.Objects
                                If recip.ContactType = AddressBookEntryType.Email Then
                                    Dim abookEntryExisting As AddressBookEntry = ABook.GetContactByAddress(recip.Address)
                                    If abookEntryExisting IsNot Nothing Then
                                        If abookEntryExisting.SMTPID IsNot Nothing AndAlso abookEntryExisting.SMTPID.Length > 0 Then
                                            If abookEntryExisting.SMTPID.ToLower <> abookEntry.SMTPID.ToLower Then
                                                '-- CONFLICT, but we don't want to show this msg many times in case of many conflicts
                                                '   for example, adding 25 contacts and one is diff would cause this to show 24 times in a row (frustrating)
                                                '   So we will show no more frequently than once every 5 minutes
                                                Static dtConflictWarningLastShow As Date = Date.MinValue
                                                Dim ts As TimeSpan = Date.Now - dtConflictWarningLastShow
                                                If ts.TotalSeconds > 5 Then
                                                    dtConflictWarningLastShow = Date.Now
                                                    ShowMessageBox("There is a conflict between recipients." &
                                                                   Environment.NewLine & Environment.NewLine &
                                                                   "Please verify which sending account you want to use.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                End If
                                                Exit For
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Log(ex) '-- just log and continue
        End Try
    End Sub
    Private Sub NewMessage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Dirty Then
            Select Case MessageBox.Show("Do you want to save this as a draft?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    SaveAsDraft()
                Case Windows.Forms.DialogResult.No
                    '-- do nothing, just close
                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True
            End Select
        End If

        If Not e.Cancel Then
            m_msgSender = Nothing

            '-- delete the attachment archive, if it exists
            RemoveTempAttachmentZip()

        End If


        If m_boolRestoreIEFooterSetting Then
            Dim regKey As Microsoft.Win32.RegistryKey = Nothing

            Try
                regKey = GetIEPageSetupKey()
                If regKey IsNot Nothing Then
                    regKey.SetValue("footer", m_strPreviousIEFooterSetting)
                End If
            Catch ex As Exception
                '-- do nothing
            End Try

            If regKey IsNot Nothing Then
                regKey.Close()
            End If
        End If


        If Me.WindowState <> FormWindowState.Minimized Then
            AppSettings.NewMessageWindowState = Me.WindowState
        End If

        If Me.WindowState = FormWindowState.Normal Then
            AppSettings.ComposeWindowSize = Me.Size
            AppSettings.ComposeWindowLocation = Me.Location
        End If

    End Sub
    Private Sub SetEncryptionStatus()
        Dim encrStatus As EncryptionStatus
        If (AtLeastOneEmailRecipient() AndAlso m_emailEncryption = EncryptedEmailType.ClearText) AndAlso AtLeastOneTrulyMailRecipient() Then
            encrStatus = EncryptionStatus.PartiallyEncrypted
        ElseIf (AtLeastOneEmailRecipient() AndAlso m_emailEncryption = EncryptedEmailType.ClearText) Then ' Not SendAsEncryptedPackageToEmailRecipientsToolStripMenuItem.Checked) Then
            encrStatus = EncryptionStatus.NotEncrypted
        ElseIf AtLeastOneTrulyMailRecipient() Then
            encrStatus = EncryptionStatus.Encrypted
        ElseIf m_emailEncryption = EncryptedEmailType.ClearText Then
            encrStatus = EncryptionStatus.NotEncrypted '-- Assume they will send to trulymail recip
        Else
            '-- no recipients
            encrStatus = EncryptionStatus.Encrypted '-- Assume they will send to trulymail recip
        End If

        Dim strSubject As String = txtSubject.Text
        If strSubject.Length = 0 Then
            strSubject = "New Message"
        End If

        Select Case encrStatus
            Case EncryptionStatus.Encrypted
                Text = strSubject & " " & ENCRYPTED_TITLEBAR_TEXT
                Me.Icon = My.Resources.SecuredmessageIcon
            Case EncryptionStatus.NotEncrypted
                Text = strSubject & " " & UNENCRYPTED_TITLEBAR_TEXT
                Me.Icon = My.Resources.MessageIcon
            Case EncryptionStatus.PartiallyEncrypted
                Text = strSubject & " " & PARTIALLYENCRYPTED_TITLEBAR_TEXT
                Me.Icon = My.Resources.SecuredmessageIcon
        End Select

    End Sub
    Private Sub NewMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub LoadDictionaries()
        Dim files() As String = GetDictionaries()
        Dim mi As ToolStripMenuItem
        Dim strName As String
        For Each strFilename As String In files
            strName = System.IO.Path.GetFileNameWithoutExtension(strFilename)
            mi = SpellCheckToolStripSplitButton.DropDownItems.Add(strName)
            AddHandler mi.Click, AddressOf SpellCheckToolStripButton_Click
            mi.ImageTransparentColor = Color.White
            If AppSettings.DictionaryFilename.ToLower() = strName.ToLower() & DICTIONARY_FILENAME_EXTENSION Then
                Me.SpellCheckToolStripSplitButton.ToolTipText = "Spell Check (" & mi.Text & ")"
                Me.SpellCheckToolStripMenuItem.Text = "Spell Check (" & mi.Text & ")"

                C1SpellChecker1.MainDictionary.FileName = strFilename

                If AppSettings.LargeToolbarIcons Then
                    mi.Image = My.Resources.CheckMark_32
                Else
                    mi.Image = My.Resources.CheckMark_16
                End If
            End If
        Next

        C1SpellChecker1.UserDictionary.FileName = System.IO.Path.Combine(ProfileRootPath, DICTIONARY_USER_DICT_FILENAME)
    End Sub

    Private Sub SpellCheckToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SpellCheckToolStripSplitButton.Click
        '-- Check the selected dictionary
        Dim miClicked As ToolStripMenuItem
        If sender Is SpellCheckToolStripSplitButton Then
            '-- Do nothing
            Application.DoEvents() '-- for breakpoint only
        Else
            For Each mi As ToolStripMenuItem In SpellCheckToolStripSplitButton.DropDownItems
                If mi Is sender Then
                    If AppSettings.LargeToolbarIcons Then
                        mi.Image = My.Resources.CheckMark_32
                    Else
                        mi.Image = My.Resources.CheckMark_32
                    End If
                    Me.SpellCheckToolStripSplitButton.ToolTipText = "Spell Check (" & mi.Text & ")"
                    Me.SpellCheckToolStripMenuItem.Text = "Spell Check (" & mi.Text & ")"
                    miClicked = mi
                Else
                    mi.Image = Nothing
                End If
            Next

            '-- now, load the selected dictionary
            AppSettings.DictionaryFilename = miClicked.Text & DICTIONARY_FILENAME_EXTENSION

            '-- finally, perform spell check
            SpellCheck(True, False)
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Using frm As New AboutBoxK()
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub SendToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToolStripMenuItem.Click
        SendMessageNow()
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try
            SendMessageNow()
        Catch ex As Exception
            ShowMessageBoxError("There was an error sending your message." & Environment.NewLine & Environment.NewLine &
               ex.Message)
        End Try
    End Sub
    Private Sub SendMessageNow()
        '-- Add the number of minutes the user chose (defaults to zero minutes)
        Try
            SendMessage(Date.UtcNow.AddMinutes(AppSettings.SendNowDelay))
        Catch ex As Exception
            ShowMessageBoxError("There was an error sending your message." & Environment.NewLine & Environment.NewLine &
                                ex.Message)
            EnableMessage() '-- cancel processing and do nothing
        End Try
    End Sub
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
    Private Function AttachmentRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim attachment As AttachmentItem = CType(olvi.RowObject, AttachmentItem)

        If System.IO.File.Exists(attachment.Filename) Then
            If attachment.DuplicateDisplayName Then
                olvi.BackColor = Color.Yellow
                olvi.ToolTipText = "Duplicate filenames will be corrected when sending."
            Else
                '-- normal expected path (no dups, file exists)
                olvi.BackColor = Color.White
                olvi.ToolTipText = attachment.Filename
            End If
        Else
            olvi.BackColor = Color.Red
            olvi.ToolTipText = "File missing: " & attachment.Filename
        End If

    End Function
    Private Sub AttachmentsChanged()
        '-- This should be called any time attachments change (added, removed, etc.)
        CheckForDuplicateAttachmentNames()

        If m_lstAttachments.Count > 0 Then
            If chkZipAttachments.Checked Then
                ZipAttachments()
            Else
                RemoveTempAttachmentZip()
            End If
        Else
            RemoveTempAttachmentZip()
        End If

        olvAttachments.SetObjects(m_lstAttachments)
        Dirty = True
    End Sub
    Private Sub AddAttachments()
        Dim boolAtLeastOneFileAttached As Boolean
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "*.*|*.*"
        ofd.Title = "Attach files..."
        ofd.Multiselect = True
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each strFilename As String In ofd.FileNames
                If AddAttachmentToList(strFilename, True) Then
                    boolAtLeastOneFileAttached = True
                End If
            Next
        End If

        If boolAtLeastOneFileAttached Then
            AttachmentsChanged()
        End If
    End Sub
    Private Sub AddAttachmentsToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAttachmentsToolStripButton.Click
        AddAttachments()
    End Sub
    ''' <summary>
    ''' Since two attachments cannot have the same name, this will notify the user
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckForDuplicateAttachmentNames()
        Dim ht As New Hashtable()

        For Each item As AttachmentItem In m_lstAttachments
            If ht.Contains(item.DisplayName.ToLower()) Then
                HighlightAttachmentNames(item.DisplayName)
            Else
                ht.Add(item.DisplayName.ToLower(), Nothing)
            End If
        Next
    End Sub
    Private Sub HighlightAttachmentNames(ByVal name As String)
        For Each item As AttachmentItem In m_lstAttachments
            item.DuplicateDisplayName = item.DisplayName.ToLower() = name.ToLower
        Next
    End Sub
    Private Sub RemoveTempAttachmentZip()
        Try
            If System.IO.File.Exists(m_strAttachmentArchiveFilename) Then
                DeleteLocalFile(m_strAttachmentArchiveFilename)
            End If

            Dim lngFileSize As Long
            m_lngTotalAttachmentSizeUncompressed = 0
            If m_lstAttachments IsNot Nothing Then
                For Each item As AttachmentItem In m_lstAttachments
                    Dim strFilename As String = item.Filename
                    If System.IO.File.Exists(strFilename) Then
                        lngFileSize = FileLen(strFilename)
                        m_lngTotalAttachmentSizeUncompressed += lngFileSize
                    Else
                        m_boolAtLeastOneAttachmentMissing = True
                    End If
                Next
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Private Sub ZipAttachments()
        RemoveTempAttachmentZip()

        m_zip = New Ionic.Zip.ZipFile()

        m_boolAtLeastOneAttachmentMissing = False
        m_lngTotalAttachmentSizeUncompressed = 0

        Dim lngFileSize As Long
        For Each item As AttachmentItem In m_lstAttachments
            Dim strFilename As String = item.Filename
            If System.IO.File.Exists(strFilename) Then
                m_zip.AddFile(strFilename)
                lngFileSize = FileLen(strFilename)
                m_lngTotalAttachmentSizeUncompressed += lngFileSize
            Else
                m_boolAtLeastOneAttachmentMissing = True
            End If
        Next

        m_zip.Save(m_strAttachmentArchiveFilename)

        m_lngTotalAttachmentSize = FileLen(m_strAttachmentArchiveFilename)
    End Sub
    Private Sub DeleteSelectedAttachments()
        Dim lst As ArrayList = olvAttachments.GetSelectedObjects()
        For Each item As AttachmentItem In lst
            m_lstAttachments.Remove(item)

        Next
        AttachmentsChanged()
        Dirty = True
    End Sub
    Private Sub lstvAttachments_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles olvAttachments.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                DeleteSelectedAttachments()
                Dirty = True
        End Select
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.SplitContainer1.ActiveControl IsNot Nothing Then
                If TypeOf Me.SplitContainer1.ActiveControl Is SplitContainer Then
                    If TypeOf CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl Is TextBox Then
                        Dim txt As TextBox = CType(CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl, TextBox)
                        Clipboard.SetText(txt.SelectedText)
                        txt.SelectedText = String.Empty
                    ElseIf TypeOf CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl Is BrightIdeasSoftware.ObjectListView Then
                        Dim olv As BrightIdeasSoftware.ObjectListView = CType(CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl, BrightIdeasSoftware.ObjectListView)
                        If olv Is olvAttachments Then
                            Dim files As New System.Collections.Specialized.StringCollection()
                            Dim lst As ArrayList = olvAttachments.GetSelectedObjects()
                            For Each item As AttachmentItem In lst
                                files.Add(item.Filename)
                            Next
                            If files.Count > 0 Then
                                Clipboard.SetFileDropList(files)
                            End If
                        End If
                    ElseIf TypeOf CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl Is SplitContainer Then
                        If TypeOf CType(CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl, SplitContainer).ActiveControl Is Editor Then
                            Dim ctl As Editor = CType(CType(CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl, SplitContainer).ActiveControl, Editor)
                            If ctl.SelectionType = SelectionType.Text Then
                                ctl.Cut()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.SplitContainer1.ActiveControl IsNot Nothing Then
                If TypeOf Me.SplitContainer1.ActiveControl Is SplitContainer Then
                    If TypeOf CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl Is TextBox Then
                        Dim txt As TextBox = CType(CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl, TextBox)
                        Clipboard.SetText(txt.SelectedText)
                    ElseIf TypeOf CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl Is BrightIdeasSoftware.ObjectListView Then
                        Dim olv As BrightIdeasSoftware.ObjectListView = CType(CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl, BrightIdeasSoftware.ObjectListView)
                        If olv Is olvAttachments Then
                            Dim files As New System.Collections.Specialized.StringCollection()
                            Dim lst As ArrayList = olvAttachments.GetSelectedObjects()
                            For Each item As AttachmentItem In lst
                                files.Add(item.Filename)
                            Next
                            If files.Count > 0 Then
                                Clipboard.SetFileDropList(files)
                            End If
                        End If
                    ElseIf TypeOf CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl Is SplitContainer Then
                        If TypeOf CType(CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl, SplitContainer).ActiveControl Is Editor Then
                            Dim ctl As Editor = CType(CType(CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl, SplitContainer).ActiveControl, Editor)
                            If ctl.SelectionType = SelectionType.Text Then
                                ctl.Copy()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.SplitContainer1.ActiveControl IsNot Nothing Then
                If TypeOf Me.SplitContainer1.ActiveControl Is SplitContainer Then
                    If TypeOf CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl Is TextBox Then
                        Dim txt As TextBox = CType(CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl, TextBox)
                        If Clipboard.GetText().Length > 0 Then
                            txt.SelectedText = Clipboard.GetText()
                        End If
                    ElseIf TypeOf CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl Is BrightIdeasSoftware.ObjectListView Then
                        Dim olv As BrightIdeasSoftware.ObjectListView = CType(CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl, BrightIdeasSoftware.ObjectListView)
                        If olv Is olvAttachments Then
                            Dim files As System.Collections.Specialized.StringCollection = Clipboard.GetFileDropList()
                            For Each strFilename As String In files
                                AddAttachmentToList(strFilename, True)
                            Next
                        End If
                    ElseIf TypeOf CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl Is SplitContainer Then
                        If TypeOf CType(CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl, SplitContainer).ActiveControl Is Editor Then
                            Dim ctl As Editor = CType(CType(CType(Me.SplitContainer1.ActiveControl, SplitContainer).ActiveControl, SplitContainer).ActiveControl, Editor)
                            Select Case ctl.SelectionType
                                Case SelectionType.Text, SelectionType.None
                                    ctl.Paste()
                            End Select
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub AddAttachmentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAttachmentsToolStripMenuItem.Click
        AddAttachments()
    End Sub

    Private Sub DeleteSelectedRecipients()
        If olvRecipients.GetSelectedObjects.Count > 0 Then
            Dirty = True
        End If
        olvRecipients.RemoveObjects(olvRecipients.GetSelectedObjects())
        SetRecipientPanelHeight()
    End Sub

    Private Sub olvRecipients_CellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles olvRecipients.CellEditFinishing
        Dim entry As RecipientEntry = e.RowObject
        If e.Column Is RecipientTypeColumn Then
            Dim cbo As ComboBox = e.Control
            entry.RecipientType = cbo.SelectedIndex
        ElseIf entry.ID.Length > 0 Then
            e.Cancel = True
        End If

        SetRecipientPanelHeight()
    End Sub

    Private Sub olvRecipients_CellEditStarting(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles olvRecipients.CellEditStarting
        Dim entry As RecipientEntry = e.RowObject
        If e.Column Is RecipientTypeColumn Then
            Dim cbo As New ComboBox()
            cbo.DropDownStyle = ComboBoxStyle.DropDownList
            cbo.Items.Add("To")
            cbo.Items.Add("CC")
            cbo.Items.Add("BCC")
            cbo.Bounds = e.CellBounds
            cbo.SelectedIndex = entry.RecipientType
            e.Control = cbo
        ElseIf entry.ID.Length > 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub olvRecipients_CellEditValidating(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles olvRecipients.CellEditValidating
        If e.Column Is RecipientAddressColumn Then
            Dim strEmail As String = e.Control.Text.Trim()
            If strEmail.Trim.Length > 0 AndAlso Not IsValidEmailAddress(strEmail) Then
                ShowMessageBox("'" & strEmail & "' is not a valid email address. Please use the format user@domain.com." &
                               Environment.NewLine & Environment.NewLine & "You can press the 'Esc' key on your keyboard to undo changes.",
                               MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                e.Cancel = True
            Else
                e.Control.Text = strEmail
            End If
        End If
    End Sub
    Private Sub olvRecipients_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles olvRecipients.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                DeleteSelectedRecipients()
            Case Keys.V
                If ModifierKeys = Keys.Control Then
                    '-- try to paste list of recips
                    Dim strClipboard As String = Clipboard.GetText()
                    Dim rows() As String = strClipboard.Split(Environment.NewLine)
                    Dim strName, strAddress As String
                    For Each row As String In rows
                        strName = String.Empty '-- reset
                        strAddress = String.Empty
                        Dim cells() As String = row.Split(vbTab)
                        If cells.Length > 1 Then
                            Application.DoEvents()
                            For Each cell As String In cells
                                If IsValidEmailAddress(cell.Trim()) Then
                                    strAddress = cell.Trim()
                                ElseIf cell.Trim().Length > 0 Then
                                    strName = cell.Trim
                                End If

                                '-- just need an address, otherwise skip that row
                                If strAddress.Length > 0 Then
                                    AddRecipient(strName, strAddress)
                                End If
                            Next
                        Else
                            If row.Trim.Length > 3 Then
                                AddRecipient(String.Empty, row)
                            End If
                        End If
                        Application.DoEvents()
                    Next
                    '-- Now remove any blank recips
                    RemoveBlankRecipient()
                End If
        End Select
        SetEncryptionStatus()
    End Sub
    Private Sub RemoveBlankRecipient()
        For Each recip As RecipientEntry In olvRecipients.Objects
            If recip.Address.Trim.Length = 0 AndAlso recip.FullName.Trim.Length = 0 Then
                olvRecipients.RemoveObject(recip)
                Exit For '-- can only modify one...but there should only ever be one blank one
            End If
        Next
    End Sub
    Private Sub SendLaterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendLaterToolStripMenuItem.Click
        Dim dt As Date = GetUserSelectedDate(Me)
        If dt = Date.MinValue Then
            '-- Do nothing
        Else
            dt = ConvertToUtc(dt)
            Try
                SendMessage(dt)
            Catch ex As Exception
                ShowMessageBoxError("There was an error sending your message." & Environment.NewLine & Environment.NewLine &
                    ex.Message)
                EnableMessage() '-- cancel processing and do nothing
            End Try
        End If
    End Sub

    Private Sub EnableMessage()
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf EnableMessage)
            Invoke(deleg)
        Else
            Try
                Me.MenuStrip1.Enabled = True
                Me.ToolStrip1.Enabled = True
                Me.SplitContainer1.Enabled = True
            Catch ex As Exception
                '-- log and ignore
                Log(ex)
            End Try
        End If
    End Sub
    Private Sub DisableMessage()
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf DisableMessage)
            Invoke(deleg)
        Else
            Try
                If Me IsNot Nothing Then '-- can get object ref not set to an instance, s
                    Me.SplitContainer1.Enabled = False
                    Me.MenuStrip1.Enabled = False
                    Me.ToolStrip1.Enabled = False
                End If
            Catch ex As Exception
                '-- log and ignore
                Log(ex)
            End Try
        End If
    End Sub

    Private Sub SpellCheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpellCheckToolStripMenuItem.Click
        SpellCheck(True, False)
    End Sub
    Private Sub SpellCheck(ByVal alertUser As Boolean, ByVal sendOnSuccess As Boolean)
        Try
            '-- set current dictionary
            C1SpellChecker1.MainDictionary.FileName = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(GetEXEFullPath()), DICTIONARY_FOLDER_NAME), AppSettings.DictionaryFilename)
            Dim intReturn As Integer
            If AppSettings.SpellCheckSubject Then
                intReturn = C1SpellChecker1.CheckControl(Me.txtSubject, False)
                If intReturn = -1 Then
                    '-- cancel called,don't continue
                    Exit Sub
                End If
            End If

            intReturn = C1SpellChecker1.CheckControl(Me.txtMessageBody, False)
            If intReturn = -1 Then
                '-- cancel called, just let the routine finish normally, don't send message
            Else
                '-- completed successfully
                If sendOnSuccess Then
                    m_boolNeedSpellCheck = False
                    Try
                        SendMessage(m_dtSendLater)
                    Catch ex As Exception
                        ShowMessageBoxError("There was an error sending your message." & Environment.NewLine & Environment.NewLine &
                            ex.Message)
                        EnableMessage() '-- cancel processing and do nothing
                    End Try
                End If
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error checking the spelling of this message. The error is below." &
                           Environment.NewLine & Environment.NewLine &
                           ex.Message &
                           Environment.NewLine & Environment.NewLine &
                           "Please contact TrulyMail support to fix this problem.")
        End Try
    End Sub
    Friend Sub SaveAsDraft()
        '-- Save in drafts folder, leave message window open
        If m_strMessageID.Length = 0 Then
            '-- if messageid is set, just keep using it (so draft does not get re-created, just updated)
            m_strMessageID = Guid.NewGuid.ToString()
        End If

        Dim strBody As String
        Try
            strBody = txtMessageBody.Text
        Catch ex As Exception
            If TypeOf ex Is System.IO.FileNotFoundException Then
                '-- user cancelled when embedded image was not found, exit without doing anything
                Exit Sub
            Else
                Log("MessageID: " & m_strMessageID)
                Log(ex)
                ShowMessageBoxError("There was an error saving this message (" & ex.Message & ")." & CONTACT_TRULYMAIL_MESSAGE)
                Exit Sub
            End If
        End Try

        m_lngTotalPostingSize = (strBody.Length * olvRecipients.Items.Count) + m_lngTotalAttachmentSize
        m_lngTotalPostingSize += m_lngTotalEmbededImageSize

        Dim xDoc As New Xml.XmlDocument()
        Dim xRoot As Xml.XmlElement = xDoc.AppendChild(xDoc.CreateElement("Message"))
        xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGEID, m_strMessageID) '-- Decrypted

        Dim strRelativePath As String = m_strMessageToModifyOnSent.Replace(MessageStoreRootPath, String.Empty)
        xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ORIGINALMESSAGEFILENAME, strRelativePath)
        xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_RESPONSETYPE, m_modifyProcess.ToString())


        xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENTDATE, String.Empty)
        xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGETYPEID, MESSAGETYPE_DRAFT_COMMUNICATION)
        xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDEMAILTYPE, m_emailEncryption.ToString)
        xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_READ, False)
        xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGESIZE, m_lngTotalPostingSize + 400) '-- 400 bytes extra just for extra xml stuff
        xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_LASTSAVEDATE, Date.UtcNow.ToString(DATEFORMAT_XML))
        xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ZIPATTACHMENTS, chkZipAttachments.Checked.ToString())
        If AtLeastOneEmailRecipient() Then
            Dim smtp As SMTPProfile = cboSMTPAccount.SelectedItem
            If smtp IsNot Nothing Then
                xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SMTPACCOUNT, smtp.ID)
            End If
        End If
        xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_KEEPCOPYAFTERSEND, SaveACopyToolStripButton.Checked)
        xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_REQUESTRETURNRECEIPT, ReturnReceiptToolStripButton.Checked)

        '-- Recipients
        Dim xRecipient As Xml.XmlElement
        Dim xRecipients As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_RECIPIENTS))
        If olvRecipients.Objects IsNot Nothing Then
            For Each item As RecipientEntry In olvRecipients.Objects
                xRecipient = xRecipients.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_RECIPIENT))
                Select Case item.RecipientType
                    Case RecipientType.Send_To
                        xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID, ROLEID_TO)
                    Case RecipientType.Send_CC
                        xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID, ROLEID_CC)
                    Case RecipientType.Send_BCC
                        xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID, ROLEID_BCC)
                End Select
                '-- Changed this from reciptID to UserID so we can match it to the addressbook
                Select Case item.ContactType
                    Case AddressBookEntryType.Email
                        'If item.ID.Length > 0 Then
                        '    xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_RECIPIENTID, item.ID)
                        'Else
                        xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ADDRESS, item.Address)
                        xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME, item.FullName)
                        'End If
                    Case AddressBookEntryType.TrulyMail
                        xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_RECIPIENTID, item.ID)
                End Select
            Next
        End If

        '-- subject body
        Dim xSubject As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_SUBJECT))
        xSubject.InnerText = txtSubject.Text
        Dim xBody As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_BODY))
        xBody.InnerText = strBody

        xBody.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FORMAT, BODYFORMAT_PLAINTEXT)

        SaveAttachmentsForMessage(xDoc)

        xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SHOWREMOTEIMAGES, m_intImagesBlocked = 0)
        Dim strFilename As String = DraftsRootPath & m_strMessageID & MESSAGE_FILENAME_EXTENSION
        xDoc.Save(strFilename)
        MainFormReference.ShowFolderContentsIfCurrent(System.IO.Path.GetDirectoryName(strFilename))

        Dirty = False
    End Sub

    Private Sub SaveAttachmentsForMessage(ByVal xDoc As Xml.XmlDocument)
        '-- attachments (normal only, GetHTMLAfterParseOutEmbeddedImages removed embedded images)
        Dim xRoot As Xml.XmlElement = xDoc.DocumentElement
        Dim xAttachments As Xml.XmlElement = Nothing
        If xAttachments Is Nothing Then
            xAttachments = xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ATTACHMENTS)
        End If
        Dim htAttachments As New Hashtable()
        Dim strNameOfFile As String
        Dim attachments As New List(Of String)
        For intCounter As Integer = 0 To m_lstAttachments.Count - 1
            attachments.Add(m_lstAttachments.Item(intCounter).Filename)
        Next

        For Each strFilename In attachments
            strNameOfFile = System.IO.Path.GetFileName(strFilename)
            Dim xAttachment As Xml.XmlElement = xAttachments.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ATTACHMENT))
            xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME, strNameOfFile)
            If System.IO.File.Exists(strFilename) Then
                xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILESIZE, FileLen(strFilename))
                If Not System.IO.Directory.Exists(AttachmentsRootPath & m_strMessageID) Then
                    System.IO.Directory.CreateDirectory(AttachmentsRootPath & m_strMessageID)
                End If
                Try
                    System.IO.File.Copy(strFilename, AttachmentsRootPath & m_strMessageID & "\" & strNameOfFile, True)
                Catch ex As Exception
                    Log(ex)
                    If ex.Message.Contains("The process cannot access the file") AndAlso ex.Message.Contains("because it is being used by another process") Then
                        '-- Not sure why the file would be in use but assume the source file is not changing, so skip it
                    Else
                        '-- some other error
                        ShowMessageBoxAutoClose("There was an error (" & ex.Message & ") saving the following attachment: " & strNameOfFile, STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)
                    End If
                End Try
            Else
                xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILESIZE, 0)
            End If
        Next

        If xAttachments.ChildNodes.Count > 0 Then
            xRoot.AppendChild(xAttachments)
        End If
    End Sub
    Private Sub SaveAsDraftToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsDraftToolStripMenuItem.Click
        SaveAsDraft()
    End Sub

    'Private Sub txtSubject_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubject.KeyDown
    '    If e.Control AndAlso e.KeyCode = Keys.Back Then
    '        '-- skip
    '        e.SuppressKeyPress = True
    '    End If
    'End Sub

    Private Sub txtSubject_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dirty = True
        SetEncryptionStatus()
    End Sub
    Private Sub NewMessage_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then
            SaveAsDraft()
        End If
    End Sub

    Private Sub SaveAsDraftToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsDraftToolStripButton.Click
        SaveAsDraft()
    End Sub
    Private Property Dirty() As Boolean
        Get
            Return m_boolDirty
        End Get
        Set(ByVal value As Boolean)
            m_boolDirty = value
            SetSaveEnabled(value)
        End Set
    End Property
    Private Delegate Sub SetSaveEnabledCallback(ByVal enabled As Boolean)
    Private Sub SetSaveEnabled(ByVal enabled As Boolean)
        If InvokeRequired Then
            Dim deleg As New SetSaveEnabledCallback(AddressOf SetSaveEnabled)
            Invoke(deleg, enabled)
        Else
            SaveAsDraftToolStripButton.Enabled = enabled
            SaveAsDraftToolStripMenuItem.Enabled = enabled
        End If
    End Sub

    Private Sub SetToolStripIcons(ByVal toLarge As Boolean)
        If toLarge Then
            '-- Switching from normal, small icons to large icons
            Me.ToolStrip1.ImageScalingSize = New Size(32, 32)
            Me.ToolStrip1.Height = TOOLBAR_32_HEIGHT

            btnSend.Image = My.Resources.sendmail_32
            btnSendDelayed.Image = My.Resources.sendmaildelay_32
            SaveAsDraftToolStripButton.Image = My.Resources.Savefile_32
            AddAttachmentsToolStripButton.Image = My.Resources.Attach_32
            SpellCheckToolStripSplitButton.Image = My.Resources.Spellcheck_32
            SaveACopyToolStripButton.Image = My.Resources.MessageCopy_32
            ReturnReceiptToolStripButton.Image = My.Resources.Postman_32
            AttachFromClipboardToolStripButton.Image = My.Resources.paste2_32
            UnencryptedEmailToolStripMenuItem.Image = My.Resources.email_32
            EncryptedToOtherTrulyMailUsersToolStripMenuItem.Image = My.Resources.Securedmessage_32
        Else
            '-- Switching from large icons to small, normal icons
            Me.ToolStrip1.ImageScalingSize = New Size(16, 16)
            Me.ToolStrip1.Height = TOOLBAR_16_HEIGHT

            btnSend.Image = My.Resources.Sendmail_16
            btnSendDelayed.Image = My.Resources.sendmaildelay_16
            SaveAsDraftToolStripButton.Image = My.Resources.Savefile_16
            AddAttachmentsToolStripButton.Image = My.Resources.Attach_16
            SpellCheckToolStripSplitButton.Image = My.Resources.Spellcheck_16
            SaveACopyToolStripButton.Image = My.Resources.MessageCopy_16
            ReturnReceiptToolStripButton.Image = My.Resources.Postman_16
            AttachFromClipboardToolStripButton.Image = My.Resources.paste2_16
            UnencryptedEmailToolStripMenuItem.Image = My.Resources.email_16
            EncryptedToOtherTrulyMailUsersToolStripMenuItem.Image = My.Resources.Securedmessage_16
        End If
        SetupToolStripForText(ToolStrip1)
        SetEmailEncryptionIcon()

        If AppSettings.UseLargeAllAccountDropDown Then
            SpellCheckToolStripSplitButton.DropDownButtonWidth = 40
        Else
            SpellCheckToolStripSplitButton.DropDownButtonWidth = 11
        End If
    End Sub

    Private Sub tmrAutoSave_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '-- auto-save only if something changed
        If m_boolDirty Then
            SaveAsDraft()
        End If
    End Sub

    Private Sub StopSendingReturnToMessage()
        EnableMessage()

        m_boolDirty = True

        '-- delete unsent message
        m_msgSender.DeleteMostRecentMessage()
    End Sub
    Private Sub CloseForm()
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf CloseForm)
            Invoke(deleg)
        Else
            Close()
        End If
    End Sub


    Private Sub ClearIEFooter()
        Dim regKey As Microsoft.Win32.RegistryKey = Nothing

        Try
            regKey = GetIEPageSetupKey()
            If regKey IsNot Nothing Then
                If m_strPreviousIEFooterSetting.Length = 0 Then
                    m_strPreviousIEFooterSetting = regKey.GetValue("footer")
                    regKey.SetValue("footer", String.Empty)
                End If
                m_boolRestoreIEFooterSetting = m_strPreviousIEFooterSetting.Length > 0 '
            End If
        Catch ex As Exception
            m_boolRestoreIEFooterSetting = False
        End Try

        If regKey IsNot Nothing Then
            regKey.Close()
        End If
    End Sub


    Private Sub lvAttachments_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvAttachments.ItemActivate
        Try

            Dim lst As ArrayList = olvAttachments.GetSelectedObjects()
            For Each item As AttachmentItem In lst
                Dim strFilename As String = item.Filename
                System.Diagnostics.Process.Start(strFilename)
            Next

        Catch ex As Exception
            If ex.Message.Contains("No application is associated") Then
                MessageBox.Show("There is no application associated with this attached file." & Environment.NewLine & Environment.NewLine &
                                "You can drag-and-drop to save the attachment and open the file from there.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf ex.Message.Contains("The system cannot find the file specified") Then
                MessageBox.Show("The attachment cannot be found. Perhaps it was deleted manually?", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Log(ex)
                MessageBox.Show("There was an unexpected error (" & ex.Message & ") with this attached file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Try
    End Sub


#Region " Loading and showing OLV "
    Private Function ContactToolTipGetting(ByVal column As BrightIdeasSoftware.OLVColumn, ByVal modelObject As Object) As String
        Dim contact As AddressBookEntry = CType(modelObject, AddressBookEntry)
        If contact.ContactType = AddressBookEntryType.TrulyMail Then
            Return contact.FullName & Environment.NewLine & contact.Tags
        Else
            Return contact.FullName & Environment.NewLine & contact.Address & Environment.NewLine & contact.Tags
        End If
    End Function
    Private Sub LoadAddressBookEntries()
        olvContacts.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf ContactsRowFormatter)
        olvContacts.CellToolTipGetter = New BrightIdeasSoftware.CellToolTipGetterDelegate(AddressOf ContactToolTipGetting)
        NameColumn.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf ContactImageGetter)

        Dim lst As New List(Of AddressBookEntry)
        Dim lstAllContacts As List(Of AddressBookEntry) = ABook.GetAllContacts
        Dim boolAddThisEntry As Boolean

        For i As Integer = 0 To lstAllContacts.Count - 1
            boolAddThisEntry = True

            If lstAllContacts(i).Blocked Then
                boolAddThisEntry = False
            ElseIf lstAllContacts(i).ReceiveOnly Then
                boolAddThisEntry = False
            ElseIf lstAllContacts(i).ContactType = AddressBookEntryType.TrulyMail Then
                boolAddThisEntry = False
            End If

            If boolAddThisEntry Then
                lst.Add(lstAllContacts(i))
            End If
        Next

        lst.Sort(AddressOf CompareAddressBookEntries)
        olvContacts.SetObjects(lst)

        AutoSizeColumns(olvContacts)

    End Sub
    Private Function ContactsRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        'Dim entry As AddressBookEntry = CType(olvi.RowObject, AddressBookEntry)

    End Function
    Private Function RecipientsRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim entry As RecipientEntry = CType(olvi.RowObject, RecipientEntry)
        Select Case entry.RecipientType
            Case RecipientType.Send_To
                olvi.SubItems(1).Text = "To"
            Case RecipientType.Send_CC
                olvi.SubItems(1).Text = "CC"
            Case RecipientType.Send_BCC
                olvi.SubItems(1).Text = "BCC"
        End Select

        If entry.ContactType = AddressBookEntryType.TrulyMail Then
            olvi.SubItems(2).BackColor = Color.Gray
        End If
    End Function
    Private Function ContactImageGetter(ByVal row As Object) As Object
        Dim entry As AddressBookEntry = CType(row, AddressBookEntry)
        Select Case entry.ContactType
            Case AddressBookEntryType.TrulyMail
                Return 0
            Case AddressBookEntryType.Email
                Return 1
        End Select
    End Function
    Private Function AttachmentImageGetter(ByVal row As Object) As Object
        Try
            Dim item As AttachmentItem = row
            Dim strExtension As String = System.IO.Path.GetExtension(item.Filename).ToLower()
            If Not olvAttachments.SmallImageList.Images.ContainsKey(strExtension) Then
                Dim icon As Icon = AssociatedIcon.GetAssociatedIconSmall(item.Filename)
                olvAttachments.SmallImageList.Images.Add(strExtension, icon)
            End If
            Return strExtension
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    Private Function RecipientImageGetter(ByVal row As Object) As Object
        Dim entry As RecipientEntry = CType(row, RecipientEntry)
        Select Case entry.ContactType
            Case AddressBookEntryType.TrulyMail
                Return 0
            Case AddressBookEntryType.Email
                Return 1
        End Select
    End Function
#End Region

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        txtAddressSearch.Focus()
    End Sub

    Private Sub txtAddressSearch_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAddressSearch.Enter
        If txtAddressSearch.ForeColor = Color.Gray Then
            txtAddressSearch.Text = String.Empty
        End If
    End Sub

    Private Sub txtAddressSearch_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddressSearch.Leave
        If txtAddressSearch.Text.Length = 0 Then
            m_boolFilterChanging = True
            txtAddressSearch.Text = DEFAULT_SEARCH_TEXT
            txtAddressSearch.ForeColor = Color.Gray
            m_boolFilterChanging = False
        End If
    End Sub

    Private Sub txtAddressSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddressSearch.TextChanged
        If txtAddressSearch.ForeColor = Color.Gray Then
            If Visible Then
                txtAddressSearch.ForeColor = Color.Black
            End If
        End If

        If Not (txtAddressSearch.Text = DEFAULT_SEARCH_TEXT) Then
            Try
                olvContacts.ModelFilter = New BrightIdeasSoftware.TextMatchFilter(olvContacts, txtAddressSearch.Text)
                If txtAddressSearch.Text.Length = 0 Then
                    olvContacts.EmptyListMsg = "Address book is empty"
                Else
                    olvContacts.EmptyListMsg = "No contacts match your filter"
                End If
            Catch ex As Exception
                Log(ex)
            End Try
        End If
    End Sub

    Private Sub olvContacts_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvContacts.ItemActivate
        Dim lst As New List(Of AddressBookEntry)
        For Each entry As AddressBookEntry In olvContacts.SelectedObjects()
            lst.Add(entry)
        Next
        AddRecipientList(lst, m_recipientAddMode)
    End Sub
    Private Sub LoadSMTPAccounts()
        For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
            cboSMTPAccount.Items.Add(smtp)

            If smtp.IsDefault AndAlso m_strSMTPID.Length = 0 Then
                cboSMTPAccount.SelectedItem = smtp
                m_strSMTPID = smtp.ID
            ElseIf m_strSMTPID = smtp.ID Then
                cboSMTPAccount.SelectedItem = smtp
            End If
        Next

        If cboSMTPAccount.SelectedIndex = -1 AndAlso cboSMTPAccount.Items.Count > 0 Then
            cboSMTPAccount.SelectedIndex = 0
        End If
    End Sub
    Private Function AtLeastOneTrulyMailRecipient() As Boolean
        If olvRecipients.Objects IsNot Nothing AndAlso olvRecipients.Items.Count > 0 Then
            For Each entry As RecipientEntry In olvRecipients.Objects
                If entry.ContactType = AddressBookEntryType.TrulyMail Then
                    Return True
                End If
            Next

            Return False
        Else
            Return False
        End If

    End Function
    Private Function AtLeastOneEmailRecipient() As Boolean
        If olvRecipients.Objects IsNot Nothing AndAlso olvRecipients.Items.Count > 0 Then
            For Each entry As RecipientEntry In olvRecipients.Objects
                If entry.ContactType = AddressBookEntryType.Email Then
                    Return True
                End If
            Next

            Return False
        Else
            '-- Loading?
            For Each entry As RecipientEntry In m_lstRecipientsToAdd
                If entry.ContactType = AddressBookEntryType.Email Then
                    Return True
                End If
            Next
            Return False
        End If

    End Function
    Private Sub SetRecipientPanelHeight()
        '-- if there is even one email recip, then height must be 111 and smtp panel is visible
        '   otherwise, the height must be 132 and smtp panel is not visible

        cboSMTPAccount.Visible = True

        SetEncryptionStatus()
        AutoSizeColumns(olvRecipients)
    End Sub
    Private Sub AddNewEmailRecipient()
        '-- First, ensure there is not an existing blank email recip waiting
        Dim intExistingBlankRecipientIndex As Integer = -1
        For Each item As ListViewItem In olvRecipients.Items
            If item.SubItems(2).Text = String.Empty AndAlso item.SubItems(3).Text = String.Empty Then
                intExistingBlankRecipientIndex = item.Index
                Exit For
            End If
        Next

        '-- Now, add a new blank email recip
        If intExistingBlankRecipientIndex = -1 Then
            Dim entry As New RecipientEntry(AddressBookEntryType.Email)
            entry.RecipientType = RecipientType.Send_To

            olvRecipients.AddObject(entry)

            For Each item As ListViewItem In olvRecipients.Items
                If item.SubItems(2).Text = String.Empty AndAlso item.SubItems(3).Text = String.Empty Then
                    olvRecipients.EnsureVisible(item.Index)
                    olvRecipients.StartCellEdit(item, 3)
                End If
            Next
        Else
            olvRecipients.EnsureVisible(intExistingBlankRecipientIndex)
        End If


        SetRecipientPanelHeight()
    End Sub
    Private Sub olvRecipients_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles olvRecipients.MouseDown
        Dim i As ListViewHitTestInfo = olvRecipients.HitTest(e.Location)
        If i.Item Is Nothing Then
            '-- user clicked on a blank row, add a new blank row and let the user edit all three columns
            'TODO: Fix hack - only calling this twice will actully ensure the new item is visible
            'AddNewEmailRecipient()
            AddNewEmailRecipient()
        End If
    End Sub
    Private Sub SetRecipientAddMode(ByVal newMode As RecipientType)
        m_recipientAddMode = newMode
        Select Case newMode
            Case RecipientType.Send_To
                picTo.BackColor = Color.Yellow
                picTo.Image = My.Resources.To_Hot_16
                picCC.BackColor = Color.White
                picCC.Image = My.Resources.CC_16
                picBCC.BackColor = Color.White
                picBCC.Image = My.Resources.BCC_16
            Case RecipientType.Send_CC
                picTo.BackColor = Color.White
                picTo.Image = My.Resources.To_16
                picCC.BackColor = Color.Yellow
                picCC.Image = My.Resources.CC_Hot_16
                picBCC.BackColor = Color.White
                picBCC.Image = My.Resources.BCC_16
            Case RecipientType.Send_BCC
                picTo.BackColor = Color.White
                picTo.Image = My.Resources.To_16
                picCC.BackColor = Color.White
                picCC.Image = My.Resources.CC_16
                picBCC.BackColor = Color.Yellow
                picBCC.Image = My.Resources.BCC_Hot_16
        End Select
    End Sub
    Private Sub picTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picTo.Click
        '-- If a user is selected in the list, then add that user as TO
        '   and turn 'add mode' to To
        SetRecipientAddMode(RecipientType.Send_To)
        AddSelectedContactsAs(RecipientType.Send_To)
    End Sub
    Private Sub picCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCC.Click
        SetRecipientAddMode(RecipientType.Send_CC)
        AddSelectedContactsAs(RecipientType.Send_CC)
    End Sub
    Private Sub picBCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picBCC.Click
        SetRecipientAddMode(RecipientType.Send_BCC)
        AddSelectedContactsAs(RecipientType.Send_BCC)
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        SendKeys.Send("{ESC}")
        DeleteSelectedRecipients()
    End Sub

    Private Sub picNewEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picNewEmail.Click
        'TODO: Fix hack - only calling this twice will actully ensure the new item is visible
        AddNewEmailRecipient()
        AddNewEmailRecipient()
    End Sub

    Private Sub SpellCheckToolStripSplitButton_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SpellCheck(True, False)
    End Sub

    Private Sub NewMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewMessageToolStripMenuItem.Click
        MainFormReference.NewMessage()
    End Sub


    Private Sub ManuallyChangeReturnReceiptStatus()
        If m_boolAtLeastOneAutoRequestReceiptRecipient AndAlso Not ReturnReceiptToolStripButton.Checked Then
            If Not AppSettings.DoNotShowReadReceiptWillNotBeRequested Then
                Using frm As New NotifyForm("At least one recipient is marked to always request a read receipt but you have turned off the receipt for this message." &
                                                        Environment.NewLine & Environment.NewLine & "This message will not have a read receipt requested.", NotifyForm.DoNotShowSetting.DoNotShowReadReceiptWillNotBeRequested)
                    frm.ShowDialog(MainFormReference)
                End Using
            End If
        End If
        m_boolUserControlledReceiptRequest = True
    End Sub
    Private Sub ReturnReceiptToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnReceiptToolStripButton.Click
        RequestReturnReceiptemailOnlyToolStripMenuItem.Checked = ReturnReceiptToolStripButton.Checked
        ManuallyChangeReturnReceiptStatus()
        Dirty = True
    End Sub
    Private Sub RequestReturnReceiptemailOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RequestReturnReceiptemailOnlyToolStripMenuItem.Click
        ReturnReceiptToolStripButton.Checked = RequestReturnReceiptemailOnlyToolStripMenuItem.Checked
        ManuallyChangeReturnReceiptStatus()
        Dirty = True
    End Sub

    Private Sub SaveACopyInSentItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveACopyInSentItemsToolStripMenuItem.Click
        SaveACopyToolStripButton.Checked = SaveACopyInSentItemsToolStripMenuItem.Checked
        Dirty = True
    End Sub

    Private Sub SaveACopyToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveACopyToolStripButton.Click
        SaveACopyInSentItemsToolStripMenuItem.Checked = SaveACopyToolStripButton.Checked
        Dirty = True
    End Sub



    Private Sub SpellAsTypeToolStripButton_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SpellAsTypeToolStripButton.CheckStateChanged
        Try
            C1SpellChecker1.SetActiveSpellChecking(txtMessageBody, SpellAsTypeToolStripButton.Checked)
        Catch ex As Exception
            Log(ex)
            SpellAsTypeToolStripButton.Checked = False '-- the error was most likely a bad email (embedded iframes cause some freakiness where the line in the try will throw object not set
        End Try
        If AppSettings.SpellCheckSubject Then
            C1SpellChecker1.SetActiveSpellChecking(Me.txtSubject, SpellAsTypeToolStripButton.Checked)
        End If
    End Sub

    Private Sub SpellAsTypeToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SpellAsTypeToolStripButton.Click
        AppSettings.AutoSpellCheckNewMessage = SpellAsTypeToolStripButton.Checked
    End Sub
    Private Sub SetEmailEncryptionIcon()
        Select Case m_emailEncryption
            Case EncryptedEmailType.ClearText
                EncryptedEmailTypeToolStripDropDownButton.Text = "Unencrypted"
                If Me.ToolStrip1.ImageScalingSize.Width = 16 Then
                    EncryptedEmailTypeToolStripDropDownButton.Image = My.Resources.email_16
                Else
                    EncryptedEmailTypeToolStripDropDownButton.Image = My.Resources.email_32
                End If
            Case EncryptedEmailType.EncrypedTM2TMEmail
                EncryptedEmailTypeToolStripDropDownButton.Text = "Encrypted"
                If Me.ToolStrip1.ImageScalingSize.Width = 16 Then
                    EncryptedEmailTypeToolStripDropDownButton.Image = My.Resources.Securedmessage_16
                Else
                    EncryptedEmailTypeToolStripDropDownButton.Image = My.Resources.Securedmessage_32
                End If
        End Select
    End Sub
    Private Sub UnencryptedEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnencryptedEmailToolStripMenuItem.Click
        SetEmailEncryption(EncryptedEmailType.ClearText)
    End Sub

    Private Sub ctxmnuAddressBook_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxmnuAddressBook.Opening

    End Sub

    Private Sub AddAsToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAsToToolStripMenuItem.Click
        AddSelectedContactsAs(RecipientType.Send_To)
    End Sub

    Private Sub AddAsCCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAsCCToolStripMenuItem.Click
        AddSelectedContactsAs(RecipientType.Send_CC)
    End Sub

    Private Sub AddAsBCCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAsBCCToolStripMenuItem.Click
        AddSelectedContactsAs(RecipientType.Send_BCC)
    End Sub

    Private Sub EditContactToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditContactToolStripMenuItem.Click
        If olvContacts.GetSelectedObjects.Count = 1 Then
            EditContactDetails(CType(olvContacts.GetSelectedObject, AddressBookEntry).ID)
            LoadAddressBookEntries()
        Else
            ShowMessageBoxError("You must select one contact before trying to edit.")
        End If
    End Sub
    Private Sub AddSelectedContactsAs(ByVal recipType As RecipientType)
        Dim boolAddRecipList As Boolean = True

        Dim alist As ArrayList = olvContacts.GetSelectedObjects()
        If alist.Count = 1 Then
            Dim addressEntry As AddressBookEntry = alist(0)
            If addressEntry.ID = m_strLastAddedRecipientID Then
                boolAddRecipList = False
            End If
        End If

        If boolAddRecipList Then
            Dim lst As New List(Of AddressBookEntry)
            For Each entry As AddressBookEntry In olvContacts.SelectedObjects()
                If entry.ContactType = AddressBookEntryType.TrulyMail Then
                    ShowMessageBox("You can no longer send through TrulyMail servers. You should send to the contact's email address.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    lst.Add(entry)
                End If
            Next
            AddRecipientList(lst, recipType)
        Else
            m_strLastAddedRecipientID = String.Empty
        End If
    End Sub

    Private Sub EmailEncryptionNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailEncryptionNoneToolStripMenuItem.Click
        SetEmailEncryption(EncryptedEmailType.ClearText)
    End Sub
    Private Sub SetEmailEncryption(ByVal encryption As EncryptedEmailType)
        m_emailEncryption = encryption
        Dirty = True
        SetEmailEncryptionIcon()
        SetRecipientPanelHeight()
    End Sub
    Private Sub EmailEncryptionToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailEncryptionToolStripMenuItem.DropDownOpening
        Select Case m_emailEncryption
            Case EncryptedEmailType.ClearText
                EmailEncryptionNoneToolStripMenuItem.Checked = True
                EncryptedToOtherTrulyMailUsersToolStripMenuItem.Checked = False
            Case EncryptedEmailType.EncrypedTM2TMEmail
                EmailEncryptionNoneToolStripMenuItem.Checked = False
                EncryptedToOtherTrulyMailUsersToolStripMenuItem1.Checked = True
        End Select
    End Sub

    Private Sub olvRecipients_ItemsChanged(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.ItemsChangedEventArgs) Handles olvRecipients.ItemsChanged
        lblRecipCount.Text = olvRecipients.Items.Count.ToString("#,##0")
        If AtLeastOneEmailRecipient() Then
            olvAttachments.Height = olvRecipients.Height - chkZipAttachments.Height
        Else
            olvAttachments.Height = olvRecipients.Height
        End If
        AutoSizeColumns(olvRecipients)
        Dirty = True
    End Sub

    Private Sub cboSMTPAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dirty = True
    End Sub

    Private Sub olvContacts_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        '-- F2, F3, F4 to be used for To, CC, BCC one-key adding
        '   but don't switch the default add mode
        Select Case e.KeyCode
            Case Keys.F2
                '-- To
                If olvContacts.GetSelectedObjects.Count > 0 Then
                    AddSelectedContactsAs(RecipientType.Send_To)
                End If
            Case Keys.F3
                '-- CC
                If olvContacts.GetSelectedObjects.Count > 0 Then
                    AddSelectedContactsAs(RecipientType.Send_CC)
                End If
            Case Keys.F4
                '-- BCC
                If olvContacts.GetSelectedObjects.Count > 0 Then
                    AddSelectedContactsAs(RecipientType.Send_BCC)
                End If
        End Select
    End Sub


    Private Sub lblRecipient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ModifierKeys = (Keys.Control Or Keys.Shift) Then
            lblRecipient.BackColor = Color.Yellow
            'ToolTip1.SetToolTip(lblRecipient, "Newsletter mode (transmit one recipient at a time, using replacement codes)")
            m_boolNewsletterMode = True
        Else
            lblRecipient.BackColor = Color.Transparent
            'ToolTip1.SetToolTip(lblRecipient, "")
            m_boolNewsletterMode = False
        End If
    End Sub

    Private Sub AddAutoTextItems()
        For intItem As Integer = 0 To AutoTextToolStripMenuItem.DropDownItems.Count - 1
            If intItem > 1 Then
                AutoTextToolStripMenuItem.DropDownItems.RemoveAt(2)
            End If
        Next
        If AppSettings.AutoTexts.Count > 0 Then
            Dim intCounter As Integer
            For Each auto As AutoText In AppSettings.AutoTexts
                intCounter += 1
                Dim item As ToolStripItem = AutoTextToolStripMenuItem.DropDownItems.Add(auto.Name)
                item.Tag = auto.ID
                AddHandler item.Click, AddressOf AutoTextItem_Click
            Next
            'Else
            '    Dim item As ToolStripItem = AutoTextToolStripMenuItem.DropDownItems.Add("Create AutoText")
            '    AddHandler item.Click, AddressOf CreateAutoText_Click
        End If

        olvAutoTexts.SetObjects(AppSettings.AutoTexts)
        AutoSizeColumns(olvAutoTexts)

    End Sub
    Private Sub CreateAutoText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click, ManageAutoTextToolStripMenuItem.Click
        If UseFallbackModeNow() Then
            Dim frm As New ManageAutoTextSimple()
            frm.ShowDialog(Me)
        Else
            Dim frm As New ManageAutoText()
            frm.ShowDialog(Me)
        End If
        AddAutoTextItems()
    End Sub
    Private Sub ApplyAutoText(ByVal auto As AutoText)
        If auto.HTML Then
            txtMessageBody.SelectedText = StripHTML(auto.Text)
        Else
            txtMessageBody.SelectedText = auto.Text
        End If
    End Sub
    Private Sub AutoTextItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strID As String = CType(sender, ToolStripMenuItem).Tag
        For Each auto As AutoText In AppSettings.AutoTexts
            If auto.ID = strID Then
                ApplyAutoText(auto)
                Exit For
            End If
        Next
    End Sub
    Private Function GetAutoText(ByVal msgType As MessageResponseType) As AutoText
        Select Case msgType
            Case MessageResponseType.Reply, MessageResponseType.ReplyToAll
                For Each auto As AutoText In AppSettings.AutoTexts
                    If auto.IsReply Then
                        Return auto
                    End If
                Next
            Case MessageResponseType.Forward
                For Each auto As AutoText In AppSettings.AutoTexts
                    If auto.IsForward Then
                        Return auto
                    End If
                Next
            Case MessageResponseType.FollowUp
                For Each auto As AutoText In AppSettings.AutoTexts
                    If auto.IsFollowUp Then
                        Return auto
                    End If
                Next
            Case Else '-- new
                For Each auto As AutoText In AppSettings.AutoTexts
                    If auto.IsNew Then
                        Return auto
                    End If
                Next
        End Select
        '-- no match, return nothing
        Return Nothing
    End Function

    Private Sub olvAutoTexts_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvAutoTexts.ItemActivate
        Dim auto As AutoText = CType(olvAutoTexts.SelectedObject, AutoText)
        ApplyAutoText(auto)
    End Sub

    Private Sub SplitContainerContactsAutoText_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs)
        If m_boolFormFullyLoaded Then
            AppSettings.ComposeAutoTextAreaSplitter = SplitContainerContactsAutoText.Height - SplitContainerContactsAutoText.SplitterDistance
        End If
    End Sub


    Private Sub RemoveRecipientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveRecipientToolStripMenuItem.Click
        Try
            olvRecipients.RemoveObjects(olvRecipients.SelectedObjects)
            AutoSizeColumns(olvRecipients)
            SetEncryptionStatus()
            SetRecipientPanelHeight()
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub

    Private Sub ctxmnuRecipients_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxmnuRecipients.Opening
        RemoveRecipientToolStripMenuItem.Enabled = olvRecipients.SelectedIndices.Count > 0
    End Sub

    Private Sub RemoveAttachmentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAttachmentsToolStripMenuItem.Click
        Try
            DeleteSelectedAttachments()
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub ctxmnuAttachments_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxmnuAttachments.Opening

    End Sub

    Private Sub chkZipAttachments_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dirty = True
    End Sub

    Private Sub txtSubject_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSubject.Validating
        If m_boolMovingToSubjectLine Then
            txtSubject.Focus()
        Else
            txtMessageBody.Focus()
        End If
        m_boolMovingToSubjectLine = False
    End Sub

    Private Sub SendNowAsAsNewsletterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SendNowAsAsNewsletterToolStripMenuItem.Click
        m_boolNewsletterMode = True
        SendMessageNow()
    End Sub


    Private Sub btnSubjectSpecialChar_Click(sender As System.Object, e As System.EventArgs)
        Using frm As New CharacterSelectorForm()
            frm.SelectedText = txtSubject.Text
            frm.SelectionStart = txtSubject.SelectionStart
            frm.SelectionLength = txtSubject.SelectionLength
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                txtSubject.Text = frm.SelectedText
            End If
        End Using
    End Sub


    Private Sub EncryptedToOtherTrulyMailUsersToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        SetEmailEncryption(EncryptedEmailType.EncrypedTM2TMEmail)
    End Sub

    Private Sub EncryptedToOtherTrulyMailUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncryptedToOtherTrulyMailUsersToolStripMenuItem1.Click, EncryptedToOtherTrulyMailUsersToolStripMenuItem.Click
        SetEmailEncryption(EncryptedEmailType.EncrypedTM2TMEmail)
    End Sub

    Private Sub PasteClipboardContentsAsAttachmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteClipboardContentsAsAttachmentsToolStripMenuItem.Click
        PasteClipboardAsAttachment()
    End Sub
    Private Sub PasteClipboardAsAttachment()
        Try
            Dim strFilename As String
            Dim id As IDataObject = Clipboard.GetDataObject

            Dim s() As String = id.GetFormats(True)

            If Clipboard.ContainsFileDropList Then
                '-- attach files
                Application.DoEvents()
                For Each strFilename In Clipboard.GetFileDropList
                    AddAttachment(strFilename)
                Next
            ElseIf Clipboard.ContainsImage Then
                '-- just like pasting in the body
                strFilename = GetTempFilename(".jpg")
                Dim img As System.Drawing.Image = Clipboard.GetImage()
                img.Save(strFilename, System.Drawing.Imaging.ImageFormat.Jpeg)
                AddAttachment(strFilename)
            ElseIf Clipboard.ContainsData(DataFormats.Rtf) Then
                strFilename = GetTempFilename(".rtf")
                System.IO.File.WriteAllText(strFilename, Clipboard.GetData(DataFormats.Rtf))
                AddAttachment(strFilename)
            ElseIf Clipboard.ContainsData(DataFormats.Html) Then
                strFilename = GetTempFilename(".html")
                Dim strContents As String = Clipboard.GetData(DataFormats.Html)
                Dim intPosition As Integer

                '-- Prefer to use DOCTYPE but use HTML as backup plan
                intPosition = strContents.ToLower.IndexOf("<!doctype")
                If intPosition > -1 Then
                    intPosition = strContents.ToLower.IndexOf("<html>")
                End If

                If intPosition > -1 Then
                    strContents = strContents.Substring(intPosition)
                End If
                System.IO.File.WriteAllText(strFilename, strContents)

                AddAttachment(strFilename)
            ElseIf Clipboard.ContainsText Then
                '-- create text file attachment
                strFilename = GetTempFilename(".txt")
                System.IO.File.WriteAllText(strFilename, Clipboard.GetText)
                AddAttachment(strFilename)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error pasting attachments." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub NewMessage_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If m_controlToFocusOnLoad Is Nothing Then
            txtMessageBody.Focus()
        ElseIf m_controlToFocusOnLoad Is txtSubject Then
            m_boolMovingToSubjectLine = True
            m_controlToFocusOnLoad.Focus()
        Else
            m_controlToFocusOnLoad.Focus()
        End If

        m_boolDirty = False

    End Sub

    Private Sub FileToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.DropDownOpening
        If Clipboard.ContainsText OrElse Clipboard.ContainsImage OrElse Clipboard.ContainsFileDropList Then
            AddAttachmentsFromClipboardToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub AddAttachmentsFromClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAttachmentsFromClipboardToolStripMenuItem.Click
        PasteClipboardAsAttachment()
    End Sub
    Private Sub SetBodyFont()
        Try
            txtMessageBody.Font = New Font(AppSettings.DefaultNewMessageFontName, 8 + (AppSettings.DefaultNewMessageFontSize * 2))
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error setting the font for the body of this message.")
        End Try
    End Sub

    Private Sub NewMessageSimple_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadAddressBookEntries()
            LoadSMTPAccounts()
            SetBodyFont()

            SetEncryptionStatus()

            SetToolStripIcons(AppSettings.LargeToolbarIcons)

            tmrAutoSave.Interval = AppSettings.AutoSaveDraftsMinutes * 60000 '-- setting is in minutes, property is in ms
            tmrAutoSave.Enabled = AppSettings.AutoSaveDrafts

            SetRecipientPanelHeight()
            olvRecipients.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf RecipientsRowFormatter)
            RecipientIconColumn.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf RecipientImageGetter)

            Me.olvAttachments.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf AttachmentRowFormatter)
            Me.OlvColumnFileSize.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterSize)
            AttachmentNameColumn.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf AttachmentImageGetter)

            '-- Account for opening draft with Return Receipt checked
            '   but we need to consider that this is resending from sent folder
            '   with return receipt checked but default is not to request it
            If m_strMessageID.Length = 0 AndAlso AppSettings.EmailRequestReturnReceipt Then
                ReturnReceiptToolStripButton.Checked = True
            End If
            RequestReturnReceiptemailOnlyToolStripMenuItem.Checked = ReturnReceiptToolStripButton.Checked


            '-- Now, add recipients (from New())
            For Each entry As RecipientEntry In m_lstRecipientsToAdd
                'TestEntryForWarnings(entry)

                Dim address As AddressBookEntry
                Try
                    address = ABook.GetContactByID(entry.ID) 'AddressBookEntry.LoadFromID(entry.ID)
                Catch ex As Exception
                    address = Nothing
                End Try

                If entry.ContactType = AddressBookEntryType.Email Then
                    If address IsNot Nothing Then
                        'If address.AutoRequestReadReceipt Then
                        '    ReturnReceiptToolStripButton.Checked = True
                        '    m_boolAtLeastOneAutoRequestReceiptRecipient = True
                        'End If
                    Else
                        '-- Check email address against Address Book records
                        If entry.Address.Length > 0 Then
                            address = ABook.GetContactByAddress(entry.Address) 'GetAddressBookEmailEntry(entry.Address)
                            If address IsNot Nothing Then
                                'If address.AutoRequestReadReceipt Then
                                '    ReturnReceiptToolStripButton.Checked = True
                                '    m_boolAtLeastOneAutoRequestReceiptRecipient = True
                                'End If
                            End If
                        End If
                    End If
                End If

                Dim boolAddThisAddress As Boolean

                If address Is Nothing Then
                    '-- The only way to get here is to have an email address which is not in the address book
                    address = New AddressBookEntry(AddressBookEntryType.Email)
                    address.FullName = entry.FullName
                    Try
                        If IsValidEmailAddress(entry.Address) Then
                            address.Address = entry.Address
                        Else
                            address = Nothing
                        End If
                    Catch ex As Exception
                        Log(entry.ToString()) '-- Added 2 Sept 2011 because we were getting string.empty in entry.address when loading from drafts
                        Log(ex)
                        ShowMessageBoxError("There was an error loading one of your email recipients (" & entry.Address & ")." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
                        Continue For
                    End Try
                End If

                If address Is Nothing Then
                    '-- invalid address
                    boolAddThisAddress = False
                Else
                    If olvRecipients.Objects IsNot Nothing Then
                        For Each recip As RecipientEntry In olvRecipients.Objects
                            Select Case recip.ContactType
                                Case AddressBookEntryType.Email
                                    If recip.Address.ToLower() = address.Address.ToLower() Then
                                        '- skip
                                        boolAddThisAddress = False
                                    Else
                                        boolAddThisAddress = True
                                    End If
                                Case AddressBookEntryType.TrulyMail
                                    If recip.ID = address.ID Then
                                        '- skip
                                        boolAddThisAddress = False
                                    Else
                                        boolAddThisAddress = True
                                    End If
                            End Select
                        Next
                    Else
                        boolAddThisAddress = True
                    End If
                End If


                If boolAddThisAddress Then
                    Dim lstRecip As New List(Of AddressBookEntry)
                    lstRecip.Add(address)
                    AddRecipientList(lstRecip, entry.RecipientType)
                End If
            Next

            '-- Now, add any attachments (from New())
            Dim boolAtLeastOneFileAttached As Boolean
            For Each strFilename In m_lstAttachmentsToAdd
                AddAttachmentToList(strFilename, False)
                boolAtLeastOneFileAttached = True
            Next

            If boolAtLeastOneFileAttached Then
                AttachmentsChanged()
            End If

            LoadDictionaries()
            txtAddressSearch.ForeColor = Color.Gray

            If AppSettings.NewMessageWindowState <> FormWindowState.Minimized Then
                Me.WindowState = AppSettings.NewMessageWindowState
            End If

            '-- try to move the cursor position in the editor
            Me.Show()
            Application.DoEvents()

            '-- now, set size and position of window
            Const WINDOW_MIN_WIDTH As Integer = 100
            Const WINDOW_MIN_HEIGHT As Integer = 100
            If AppSettings.ComposeWindowSize.Width > WINDOW_MIN_WIDTH AndAlso AppSettings.ComposeWindowSize.Height > WINDOW_MIN_HEIGHT Then
                Me.Size = AppSettings.ComposeWindowSize
            End If
            Me.Location = AppSettings.ComposeWindowLocation


            If SplitContainerContactsAutoText.Height - AppSettings.ComposeAutoTextAreaSplitter > 0 AndAlso AppSettings.ComposeAutoTextAreaSplitter > 0 Then
                SplitContainerContactsAutoText.SplitterDistance = SplitContainerContactsAutoText.Height - AppSettings.ComposeAutoTextAreaSplitter
            End If

            If m_controlToFocusOnLoad Is Nothing Then
                txtMessageBody.Focus()
            Else
                m_controlToFocusOnLoad.Focus()
            End If

            If m_boolPositionCursorAtEndOnLoad Then
                txtMessageBody.SelectionStart = txtMessageBody.Text.Length
            Else
                txtMessageBody.SelectionStart = 0
            End If

            If Not AppSettings.KeepSentMessages Then
                SaveACopyInSentItemsToolStripMenuItem.PerformClick()
            End If

            '-- setup autocomplete for message tags
            Dim src As New AutoCompleteStringCollection()
            For Each item As MessageTag In AppSettings.MessageTags
                src.Add(item.Text)
            Next
            RequestReturnReceiptemailOnlyToolStripMenuItem.Checked = ReturnReceiptToolStripButton.Checked
            SpellAsTypeToolStripButton.Checked = AppSettings.AutoSpellCheckNewMessage
            AddAutoTextItems()

            If m_autoTextToUse IsNot Nothing Then
                ApplyAutoText(m_autoTextToUse)
            End If

            HTMLColumn.AspectPutter = New BrightIdeasSoftware.AspectPutterDelegate(AddressOf DoNothingAspectPutter)

            chkZipAttachments.Checked = m_boolDefaultToZipAttachments

            AttachmentsChanged()

            If m_defaultEncryption <> DefaultEncryptionSetting.Unknown Then
                '-- Because of the sequence and so many options, here we will store the encryption settnig
                '   and restore at end of routine
                '   Depending on m_defaultEncryption
                Select Case m_defaultEncryption
                    Case DefaultEncryptionSetting.Unknown
                        '-- Do nothing, there is nothing to set
                    Case DefaultEncryptionSetting.ClearText
                        '-- We know this should be clear text
                        SetEmailEncryption(EncryptedEmailType.ClearText)
                    Case DefaultEncryptionSetting.TM2TM
                        '-- We know this should be TM2TM
                        SetEmailEncryption(EncryptedEmailType.EncrypedTM2TMEmail)
                End Select
            End If

            m_boolFormFullyLoaded = True

        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error loading the current message." & CONTACT_TRULYMAIL_MESSAGE)
        End Try

    End Sub

    Private Sub txtSubject_TextChanged_1(sender As Object, e As EventArgs) Handles txtSubject.TextChanged
        Dirty = True
    End Sub

    Private Sub txtMessageBody_TextChanged(sender As Object, e As EventArgs) Handles txtMessageBody.TextChanged
        Dirty = True
    End Sub

    Private Sub txtMessageBody_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMessageBody.KeyDown
        Select Case e.KeyValue
            Case Keys.S
                If (ModifierKeys And Keys.Control) = Keys.Control Then
                    SaveAsDraft()
                End If
            Case Keys.N
                If (ModifierKeys And Keys.Control) = Keys.Control Then
                    e.Handled = True
                End If
            Case Keys.Tab
                If (ModifierKeys And Keys.Shift) = Keys.Shift Then
                    m_boolMovingToSubjectLine = True
                    txtSubject.Focus()
                Else
                    SendKeys.SendWait("   ") '-- replace tab with three spaces
                    e.Handled = True
                End If
                'Case Keys.P
                '    If (ModifierKeys And Keys.Control) = Keys.Control Then
                '        PrintToolStripMenuItem.PerformClick()
                '    End If
            Case Keys.V
                If (ModifierKeys And Keys.Control) = Keys.Control Then
                    e.Handled = True '-- We do not want to paste because want to paste as plain text (but in RTB under Wine)
                    If Clipboard.GetText().Length > 0 Then
                        txtMessageBody.SelectedText = Clipboard.GetText(TextDataFormat.UnicodeText)
                    End If
                End If
            Case Keys.C
                If (ModifierKeys And Keys.Control) = Keys.Control Then
                    e.Handled = True
                    If txtMessageBody.SelectedText.Length > 0 Then
                        Clipboard.SetText(txtMessageBody.SelectedText)
                    End If
                End If
            Case Keys.X
                If (ModifierKeys And Keys.Control) = Keys.Control Then
                    e.Handled = True
                    If txtMessageBody.SelectedText.Length > 0 Then
                        Clipboard.SetText(txtMessageBody.SelectedText)
                        txtMessageBody.SelectedText = String.Empty
                    End If
                End If
            Case Keys.D0 To Keys.D9
                If (ModifierKeys And Keys.Control) = Keys.Control Then
                    '-- hotkey, loop through autotexts and app all with matching keyvalue (D1) and modifierkeys (Shift, Control)
                    For Each auto As AutoText In AppSettings.AutoTexts
                        If auto.KeyValue = e.KeyValue AndAlso auto.ModifierKeys = ModifierKeys Then
                            ApplyAutoText(auto)
                        End If
                    Next
                End If
        End Select
    End Sub

    Private Sub BulletTextToolStripButton_Click(sender As Object, e As EventArgs) Handles BulletTextToolStripButton.Click
        '-- Add bullets to selected text
        '   Start each line with an *
        ConvertTextToList(False)
    End Sub

    Private Sub NumberTextToolStripButton_Click(sender As Object, e As EventArgs) Handles NumberTextToolStripButton.Click
        '-- Add numbers to selected text
        '   Start each line with a sequential number (1, 2, etc.)
        ConvertTextToList(True)
    End Sub
    Private Sub ConvertTextToList(ordered As Boolean)
        Dim intStart, intEnd, intCurrentLineStart, intCrLfPos As Integer
        Dim intCounter As Integer
        Dim strTextToAdd As String = "* "

        intStart = txtMessageBody.SelectionStart
        intEnd = intStart + txtMessageBody.SelectionLength

        txtMessageBody.SelectionLength = 0
        txtMessageBody.SelectionStart = intStart

        Do
            intCurrentLineStart = txtMessageBody.GetFirstCharIndexOfCurrentLine()
            txtMessageBody.SelectionStart = intCurrentLineStart

            If txtMessageBody.SelectionStart = txtMessageBody.Text.Length Then
                Exit Do '-- final line has no text (text ends in CrLf)
            ElseIf txtMessageBody.SelectionStart >= intEnd AndAlso txtMessageBody.Text.Substring(txtMessageBody.SelectionStart, Environment.NewLine.Length) = Environment.NewLine Then
                Exit Do '-- end of selected text is on an empty line (not end of text for textbox but should not put an extra bullet on an empty line)
            End If

            If ordered Then
                intCounter += 1
                strTextToAdd = intCounter.ToString()
                If intCounter > 9 Then
                    strTextToAdd &= " "
                Else
                    strTextToAdd &= "  " '-- two spaces to line up numbers under and over 10
                End If
            End If
            txtMessageBody.SelectedText = strTextToAdd
            intEnd += strTextToAdd.Length '-- adjust ending marker

            Dim strNewLineMarker As String = Environment.NewLine
            intCrLfPos = txtMessageBody.Text.IndexOf(strNewLineMarker, intStart)
            If intCrLfPos = -1 Then
                '-- See if there is just vbLf
                strNewLineMarker = vbLf
                intCrLfPos = txtMessageBody.Text.IndexOf(strNewLineMarker, intStart)
            End If
            If intCrLfPos = -1 Then
                Exit Do '-- end of text, we're done
            End If

            intStart = intCrLfPos + strNewLineMarker.Length '-- move to next line

            If intStart > intEnd Then
                Exit Do
            End If

            txtMessageBody.SelectionStart = intStart

        Loop
    End Sub

    Private Sub EditToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.DropDownOpening
        SelectAllTextToolStripMenuItem.Enabled = txtMessageBody.Focused
    End Sub

    Private Sub SelectAllTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllTextToolStripMenuItem.Click
        txtMessageBody.SelectionStart = 0
        txtMessageBody.SelectionLength = txtMessageBody.Text.Length
    End Sub

    Private Sub SendToSelfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendToSelfToolStripMenuItem.Click
        '-- create a new tmm as a received one, just save to inbox no need to process through email server
        Try

            Dim tmm As New TrulyMailMessage()
            tmm.POPProfile = AppSettings.POPProfiles(0) '-- any pop profile will do, but set to be clear it is not in the sent folder
            tmm.MessageDateSent = Date.Now
            tmm.Subject = txtSubject.Text
            tmm.Body = txtMessageBody.Text
            tmm.BodyFormat = EmailBodyFormatEnum.PlainText
            tmm.MessageType = MessageType.NoteToSelf
            tmm.Filename = InBoxRootPath & tmm.MessageID & MESSAGE_FILENAME_EXTENSION
            For Each att As AttachmentItem In m_lstAttachments
                tmm.AddAttachment(att.Filename)
            Next

            tmm.Save()

            m_boolDirty = False
            MainFormReference.ShowFolderContentsIfCurrent(InBoxRootPath)

            Me.Close()
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("Error sending to self: " & ex.Message)
        End Try

    End Sub

    Private Sub AttachFromClipboardToolStripButton_Click(sender As Object, e As EventArgs) Handles AttachFromClipboardToolStripButton.Click
        PasteClipboardAsAttachment()
    End Sub

    Private Sub btnSendDelayed_Click(sender As Object, e As EventArgs) Handles btnSendDelayed.Click
        Try
            SendMessage(Date.UtcNow.AddMinutes(AppSettings.SendDelayInMinutes))
        Catch ex As Exception
            ShowMessageBoxError("There was an error sending your message." & Environment.NewLine & Environment.NewLine &
                                ex.Message)
            EnableMessage() '-- cancel processing and do nothing
        End Try
    End Sub
End Class