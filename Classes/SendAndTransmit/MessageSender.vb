Friend Class MessageSender

#Region " Module-level stuff "
    Private Enum CancelReasonEnum
        ServerError '-- stop all processing because there is an error communicating with the server
        MessageError '-- wrong invite address, cannot add recip, etc. (stop processing this message, continue others)
        CallerCanceled '-- stop all processing because user said so
    End Enum

    Private WithEvents bkw As New System.ComponentModel.BackgroundWorker()
    Private m_recipients As New List(Of RecipientEntry)
    Private m_strSubject As String
    Private m_strBody As String
    Private m_BodyFormat As EmailBodyFormatEnum
    Private m_strOriginalMessageID As String
    Private m_strOriginalMessageFilename As String
    Private m_lstAttachments As New List(Of String)
    Private m_messageType As MessageType
    Private m_boolCanceled As Boolean
    Private m_strInvitorFullName As String '-- for invite accept, reject
    Private m_strInvitorUserID As String '-- for invite accept, reject
    Private m_exception As Exception
    Private m_strRecentFilename As String = String.Empty
    Private m_htImages As New Hashtable() '-- src / new relative path
    Private m_strSMTPAccount As String = String.Empty
    Private m_boolKeepCopyAfterSend As Boolean = True
    Private m_boolReturnReceipt As Boolean
    Private m_strEmailEncryptedPackageKey As String = String.Empty
    Private m_boolNewsletterMode As Boolean

    Private CancelReason As CancelReasonEnum
    Friend Event Sent()
    Friend Event Progress(ByVal progress As Double, ByVal status As String)
    Friend Event Canceled()
#End Region

    Friend Sub New()
        '-- If we just want to send a file, then no need to set a messagetype
    End Sub
    Friend Sub New(ByVal messageType As MessageType)
        Select Case messageType
            Case Globals.MessageType.Invite, _
                 Globals.MessageType.InviteAccept, _
                 Globals.MessageType.InviteReject, _
                 Globals.MessageType.Communication

                m_messageType = messageType
            Case Else
                Throw New Exception("MessageType not supported.")
        End Select
    End Sub
    Friend Property EmailEncryptedPackageKey() As String
        Get
            Return m_strEmailEncryptedPackageKey
        End Get
        Set(ByVal value As String)
            m_strEmailEncryptedPackageKey = value
        End Set
    End Property
    Friend Property TM2TMEncryptionPassword As String


    Friend Property NewsletterMode As Boolean

    Friend Sub AddRecipient(ByVal recip As RecipientEntry)
        Select Case m_messageType
            Case MessageType.Communication
                If recip.ContactType = AddressBookEntryType.Email AndAlso EmailAddressIsOnDoNotSendList(recip.Address) Then
                    Throw New Exception("The address (" & recip.Address & ") is on the Do Not Send list and was not added to the message")
                Else
                    m_recipients.Add(recip)
                End If
            Case Else
                Throw New Exception("Recipients can only be added to communication-type messages.")
        End Select
    End Sub
    Friend ReadOnly Property Exception() As Exception
        Get
            Return m_exception
        End Get
    End Property
    Friend Property SMTPAccount() As String
        Get
            Return m_strSMTPAccount
        End Get
        Set(ByVal value As String)
            m_strSMTPAccount = value
        End Set
    End Property
    Friend Property ZipAttachments As Boolean
    Friend Property Subject() As String
        Get
            Return m_strSubject
        End Get
        Set(ByVal value As String)
            If m_messageType = MessageType.Communication Then
                m_strSubject = value
            Else
                Throw New Exception("Subject can only be set for communication-type messages.")
            End If
        End Set
    End Property
    Friend Property MessageTags As String
    Friend Property BodyFormat() As EmailBodyFormatEnum
        Get
            Return m_BodyFormat
        End Get
        Set(ByVal value As EmailBodyFormatEnum)
            m_BodyFormat = value
        End Set
    End Property
    Friend Property EmailEncryptionType As EncryptedEmailType
    Friend Property Body() As String
        Get
            Return m_strBody
        End Get
        Set(ByVal value As String)
            Select Case m_messageType
                Case MessageType.Invite, MessageType.Communication
                    m_strBody = value
                Case Else
                    Throw New Exception("Body can only be set for communication-type messages.")
            End Select
        End Set
    End Property
    Friend Property OriginalMessageID() As String
        Get
            Return m_strOriginalMessageID
        End Get
        Set(ByVal value As String)
            Select Case m_messageType
                Case MessageType.InviteAccept, MessageType.InviteReject
                    m_strOriginalMessageID = value
                Case Else
                    Throw New Exception("OriginalMessageID not supported on this message type.")
            End Select
        End Set
    End Property
    ''' <summary>
    ''' Defaults to True, if false, a copy will not be kept in Sent Items
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property KeepCopyAfterSend() As Boolean
        Get
            Return m_boolKeepCopyAfterSend
        End Get
        Set(ByVal value As Boolean)
            m_boolKeepCopyAfterSend = value
        End Set
    End Property
    ''' <summary>
    ''' Defaults to false, if true a return receipt will be requested of all email recipients
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property RequestReturnReceipt() As Boolean
        Get
            Return m_boolReturnReceipt
        End Get
        Set(ByVal value As Boolean)
            m_boolReturnReceipt = value
        End Set
    End Property
    Friend Sub AddAttachment(ByVal filename As String)
        If m_messageType = MessageType.Communication Then
            If System.IO.File.Exists(filename) Then
                m_lstAttachments.Add(filename)
            Else
                Throw New ArgumentException("File not found (" & filename & ").")
            End If
        Else
            Throw New Exception("Only Communication-type messages can have attachments.")
        End If
    End Sub
    Friend Sub Cancel()
        m_boolCanceled = True
    End Sub
    Friend Sub SendMessage(ByVal sendAfter As Date, Optional ByVal messageID As String = "")
        '-- This class is THE class for sending messages (on background thread)
        '   It will be called by mainform (send outbox) and newmessage (sending new message)

        '-- This routine will write to outbox folder
        Dim strErrorLocation As String = "A"

        Try
            Dim strMessageID As String = Guid.NewGuid.ToString()
            If messageID.Length = 0 Then
                strMessageID = Guid.NewGuid.ToString()
            Else
                strMessageID = messageID
            End If

            Dim strFilename As String = GetNewOutboxFilename(strMessageID)
            Dim xDoc As New Xml.XmlDocument()
            Dim xRoot As Xml.XmlElement = xDoc.AppendChild(xDoc.CreateElement("Message"))
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGEID, strMessageID) '-- Decrypted
            Dim strSendAfterDate As String = sendAfter.ToString(DATEFORMAT_XML)
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDAFTERDATE, strSendAfterDate)
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_READ, True) '-- already read
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_KEEPCOPYAFTERSEND, m_boolKeepCopyAfterSend.ToString())
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ZIPATTACHMENTS, Me.ZipAttachments.ToString)
            Dim xSubject As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_SUBJECT))

            Dim xRecipients As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_RECIPIENTS))
            If NewsletterMode Then
                xRecipients.SetAttribute(MESSAGE_ATTRIBUTE_NAME_NEWSLETTERMODE, True)
            End If

            strErrorLocation = "B"


            Dim xRecipient As Xml.XmlElement
            Dim xAttachments As Xml.XmlElement
            Dim strRandomGuid As String = String.Empty
            Dim lngSizeOfAllAttachments As Long = 0
            Dim boolOKToSend As Boolean = True

            Select Case m_messageType
                Case MessageType.Communication
                    xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGETYPEID, MESSAGETYPE_COMMUNICATION)
                    xSubject.InnerText = m_strSubject

                    xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDEMAILTYPE, EmailEncryptionType.ToString)

                    Select Case EmailEncryptionType
                        Case EncryptedEmailType.EncrypedTM2TMEmail
                            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_TM2TMPASSWORD, Me.TM2TMEncryptionPassword)
                            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTED, True.ToString())
                        Case EncryptedEmailType.ClearText
                            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTED, False.ToString())
                    End Select

                    xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_READ, False)
                    xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_REQUESTRETURNRECEIPT, m_boolReturnReceipt.ToString())

                    strErrorLocation = "C"

                    '-- set for email
                    If m_strSMTPAccount.Length > 0 Then
                        xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SMTPACCOUNT, m_strSMTPAccount)
                    Else
                        '-- no default set yet
                        '   should never get here
                        Log("Sending message without SMTP account")
                        'xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SMTPACCOUNT, m_strSMTPAccount)
                    End If


                    strErrorLocation = "D"

                    Dim strBodyHTML As String

                    If Me.BodyFormat = EmailBodyFormatEnum.HTML Then
                        Try
                            strBodyHTML = GetHTMLAfterParseOutEmbeddedImages(strMessageID, m_strBody, m_htImages)
                        Catch ex As Exception
                            If TypeOf ex Is System.IO.FileNotFoundException Then
                                '-- user cancelled when embedded image was not found
                                '-- should we just exit here or re-throw?
                                Log(ex)
                                Throw ex
                            Else
                                Log(ex)
                                Throw ex
                            End If
                        End Try
                    Else
                        '-- Plain text, so no need to modify it
                        strBodyHTML = m_strBody
                    End If

                    strErrorLocation = "E"


                    Dim xBody As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_BODY))
                    xBody.InnerText = strBodyHTML
                    Select Case m_BodyFormat
                        Case EmailBodyFormatEnum.HTML
                            xBody.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FORMAT, BODYFORMAT_HTML)
                        Case EmailBodyFormatEnum.PlainText
                            xBody.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FORMAT, BODYFORMAT_PLAINTEXT)
                        Case EmailBodyFormatEnum.MixedPainTextAndHTML
                            xBody.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FORMAT, BODYFORMAT_PLAINTEXTANDHTML)
                        Case Else
                            '-- default to html
                            xBody.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FORMAT, BODYFORMAT_HTML)
                    End Select

                    strErrorLocation = "F"


                    If Not NewsletterMode Then
                        '-- if we are in newsletter mode, then this logic will happen just before writing the output file(s)
                        Dim strRoleID As String = String.Empty
                        For Each recip As RecipientEntry In m_recipients
                            Select Case recip.RecipientType
                                Case RecipientType.Send_To
                                    strRoleID = ROLEID_TO
                                Case RecipientType.Send_CC
                                    strRoleID = ROLEID_CC
                                Case RecipientType.Send_BCC
                                    strRoleID = ROLEID_BCC
                            End Select

                            xRecipient = xRecipients.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_RECIPIENT))
                            xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID, strRoleID)
                            xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ADDRESS, recip.Address)
                            xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME, recip.FullName)
                            'xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_WEBMESSAGEQUESTION, recip.WebMessageQuestion)
                            'xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_WEBMESSAGEPASSWORD, recip.WebMessagePassword)

                            If recip.ID.Length > 0 Then
                                xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_RECIPIENTID, recip.ID)
                            End If
                        Next
                    End If


                    strErrorLocation = "G"


                    If (m_lstAttachments.Count > 0 OrElse m_htImages.Count > 0) Then
                        '-- Generate attachment symetric encryption key
                        '   512 bytes = 4096 bits, quite strong for a symetric password
                        strRandomGuid = GenerateAlphanumericString(ATTACHMENT_ENCRYPTION_KEY_LENGTH)
                    End If

                    xAttachments = xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ATTACHMENTS)
                    xAttachments.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ATTACHMENTCYPHERKEY, strRandomGuid)
                    Dim htAttachments As New Hashtable()
                    Dim strNameOfFile As String
                    Dim lngFileSize As Long

                    '-- make sure we do not have two (or more) attachments with the same filename
                    '   if we do, rename the subsequent files with _1, _2, etc. suffix to make unique
                    For intLoopCounter As Integer = 0 To m_lstAttachments.Count - 1
                        Dim strAttachmentFilename As String = m_lstAttachments(intLoopCounter)

                        strNameOfFile = System.IO.Path.GetFileName(strAttachmentFilename)
                        If htAttachments.Contains(strNameOfFile.ToLower()) Then
                            '-- rename the file until it does not match one in the attachment list
                            For intCounter As Integer = 1 To 1000000
                                Dim strTempNameOfFile As String = System.IO.Path.GetFileNameWithoutExtension(strAttachmentFilename) & "_" & intCounter & System.IO.Path.GetExtension(strAttachmentFilename)

                                If Not htAttachments.Contains(strTempNameOfFile.ToLower()) Then
                                    '-- finally, a match
                                    strNameOfFile = strTempNameOfFile
                                    Exit For
                                End If
                            Next
                        End If

                        strErrorLocation = "H"


                        htAttachments.Add(strNameOfFile.ToLower(), Nothing)

                        Dim xAttachment As Xml.XmlElement = xAttachments.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ATTACHMENT))
                        xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME, strNameOfFile)
                        lngFileSize = FileLen(strAttachmentFilename)
                        lngSizeOfAllAttachments += lngFileSize
                        xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILESIZE, lngFileSize.ToString())

                        strErrorLocation = "I"


                        '-- Copy attachment to attachment folder
                        If Not System.IO.Directory.Exists(AttachmentsRootPath & strMessageID) Then
                            System.IO.Directory.CreateDirectory(AttachmentsRootPath & strMessageID)
                        End If
                        Dim strDestination As String = AttachmentsRootPath & strMessageID & "\" & strNameOfFile
                        If strAttachmentFilename.ToLower <> strDestination.ToLower Then
                            If System.IO.File.Exists(strDestination) Then
                                Try
                                    DeleteLocalFile(strDestination)
                                Catch ex As Exception
                                    Throw New Exception("An attachment could not be saved because it was in use. Please try closing all attachments and send the message again.")
                                End Try
                            End If
                            System.IO.File.Copy(strAttachmentFilename, strDestination)
                        End If
                    Next

                    strErrorLocation = "J"

                    '-- Now, add the image attachments for the bodyHTML content
                    '   For this we just post the attachment but do not
                    '   update the message xml
                    '   and we've already moved the images into place
                    For Each item As DictionaryEntry In m_htImages

                        Dim strAttachmentFilename As String = item.Value

                        '-- add embedded images as attachemnts to message
                        Dim xAttachment As Xml.XmlElement = xAttachments.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ATTACHMENT))
                        xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME, IMAGES_EMBEDDED_FOLDER & System.IO.Path.GetFileName(strAttachmentFilename))
                        If Not System.IO.File.Exists(strAttachmentFilename) Then
                            ShowMessageBoxError("An image in your message (" & strAttachmentFilename & ") could no longer be found. Please open the message from your outbox, delete the image from the message, and resend it.")
                            boolOKToSend = False
                            lngFileSize = 0
                        Else
                            lngFileSize = FileLen(strAttachmentFilename)
                        End If
                        lngSizeOfAllAttachments += lngFileSize
                        xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILESIZE, lngFileSize.ToString())
                    Next
                    strErrorLocation = "K"

                    If xAttachments.ChildNodes.Count > 0 Then
                        xRoot.AppendChild(xAttachments)
                    End If

                    '-- add message tags
                    If MessageTags IsNot Nothing AndAlso MessageTags.Length > 0 Then
                        Dim xTags As Xml.XmlElement = xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_TAGS)
                        xRoot.AppendChild(xTags)
                        xTags.InnerText = MessageTags
                    End If
                    strErrorLocation = "L"

            End Select

            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGESIZE, xDoc.OuterXml.Length + lngSizeOfAllAttachments)
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGESIZE, xDoc.OuterXml.Length + lngSizeOfAllAttachments) '-- must do twice to get length of this attribute included

            strErrorLocation = "M"

            If Me.NewsletterMode AndAlso m_messageType = MessageType.Communication Then
                '-- in newsletter mode, we will write the contents once for each recipient, but each file only has one recipient
                Dim strRoleID As String = String.Empty

                '-- reuse the one recipient node
                Dim dtSendAfterNewsletter As Date = sendAfter
                Dim xDocNewsletter As New Xml.XmlDocument()
                Dim xBodyElement As Xml.XmlElement
                Dim xSubjectElement As Xml.XmlElement

                For Each recip As RecipientEntry In m_recipients
                    xDocNewsletter.LoadXml(xDoc.OuterXml)
                    Dim xNewsletterRecipients As Xml.XmlElement = xDocNewsletter.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_RECIPIENTS)
                    xNewsletterRecipients.SetAttribute(MESSAGE_ATTRIBUTE_NAME_NEWSLETTERMODE, True)

                    xRecipient = xNewsletterRecipients.AppendChild(xDocNewsletter.CreateElement(MESSAGE_ATTRIBUTE_NAME_RECIPIENT))
                    xBodyElement = xDocNewsletter.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_BODY)
                    xSubjectElement = xDocNewsletter.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_SUBJECT)

                    Dim strNewsletterMessageID As String = Guid.NewGuid.ToString()
                    xDocNewsletter.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGEID, strNewsletterMessageID)
                    strFilename = GetNewOutboxFilename(strNewsletterMessageID)
                    Select Case recip.RecipientType
                        Case RecipientType.Send_To
                            strRoleID = ROLEID_TO
                        Case RecipientType.Send_CC
                            strRoleID = ROLEID_CC
                        Case RecipientType.Send_BCC
                            strRoleID = ROLEID_BCC
                    End Select

                    xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID, strRoleID)
                    xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ADDRESS, recip.Address)
                    xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME, recip.FullName)
                    xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_WEBMESSAGEQUESTION, recip.WebMessageQuestion)
                    xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_WEBMESSAGEPASSWORD, recip.WebMessagePassword)
                    xDocNewsletter.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDAFTERDATE, dtSendAfterNewsletter.ToString(DATEFORMAT_XML))

                    If recip.ID.Length > 0 Then
                        xRecipient.SetAttribute(MESSAGE_ATTRIBUTE_NAME_RECIPIENTID, recip.ID)
                    End If

                    CopyOverAttachmentsForNewsletterMessage(xDocNewsletter, strMessageID, strNewsletterMessageID)
                    xBodyElement.InnerText = xBodyElement.InnerText.Replace(strMessageID, strNewsletterMessageID) '-- must replace any internal refs (embed images, etc.) with new msgid

                    '-- update body and subject replacement codes for newsletters
                    xBodyElement.InnerText = UseReplacementCodesForNewsletterMessage(xBodyElement.InnerText, recip)
                    xSubjectElement.InnerText = UseReplacementCodesForNewsletterMessage(xSubjectElement.InnerText, recip)

                    xDocNewsletter.Save(strFilename)


                    '-- MOVING THIS TO THE SENDING PROCESS BECAUSE OF THE AUTO-SEND/Recieve settings can really prevent messages from going out
                    ''-- introduce delay here, so it only affects newsletter mode
                    'dtSendAfterNewsletter = dtSendAfterNewsletter.AddSeconds(AppSettings.IntraEmailSendDelay)
                Next

                '-- Now, we've created all the outbound messages in the outbox and copied over all the attachments. 
                '   Now, we need to remove the original attachments because that message ID will not be used
                RemoveAttachmentsForNewsletterMessage(xDoc, strMessageID)
            Else
                strErrorLocation = "N"

                '-- just write to the outbox
                xDoc.Save(strFilename)
            End If
            strErrorLocation = "O"

            MainFormReference.ShowFolderContentsIfCurrent(System.IO.Path.GetDirectoryName(strFilename))
            strErrorLocation = "P"

            MainFormReference.ShowUnreadOnOutBoxNode()
            strErrorLocation = "Q"

            If boolOKToSend Then
                MainFormReference.ProcessUnsent()
            End If
            strErrorLocation = "R"

        Catch ex As Exception
            Log(ex)
            Log("Error location in SendMessage: " & strErrorLocation)
            Throw ex
        End Try

    End Sub
    Private Function UseReplacementCodesForNewsletterMessage(textWithReplacementCodes As String, recip As RecipientEntry) As String
        Try
            Dim strReturn As String = textWithReplacementCodes.Replace(NEWSLETTER_REPLACEMENTCODE_ADDRESS, recip.Address)
            strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_NAME, recip.FullName)

            '-- for the rest, we must use address book entry, which might not be there for contacts not auto-added
            Dim contact As AddressBookEntry = ABook.GetContactByID(recip.ID)

            If contact Is Nothing OrElse contact.Tags Is Nothing Then
                If textWithReplacementCodes.Contains(NEWSLETTER_REPLACEMENTCODE_TAGS) OrElse _
                   textWithReplacementCodes.Contains(NEWSLETTER_REPLACEMENTCODE_CUSTOM1) OrElse _
                   textWithReplacementCodes.Contains(NEWSLETTER_REPLACEMENTCODE_CUSTOM2) OrElse _
                   textWithReplacementCodes.Contains(NEWSLETTER_REPLACEMENTCODE_CUSTOM3) OrElse _
                   textWithReplacementCodes.Contains(NEWSLETTER_REPLACEMENTCODE_CUSTOM4) OrElse _
                   textWithReplacementCodes.Contains(NEWSLETTER_REPLACEMENTCODE_DATELASTRECEIVED) OrElse _
                   textWithReplacementCodes.Contains(NEWSLETTER_REPLACEMENTCODE_DATELASTSENT) OrElse _
                   textWithReplacementCodes.Contains(NEWSLETTER_REPLACEMENTCODE_HOME) OrElse _
                   textWithReplacementCodes.Contains(NEWSLETTER_REPLACEMENTCODE_WORK) OrElse _
                   textWithReplacementCodes.Contains(NEWSLETTER_REPLACEMENTCODE_MOBILE) OrElse _
                   textWithReplacementCodes.Contains(NEWSLETTER_REPLACEMENTCODE_WEB) OrElse _
                   textWithReplacementCodes.Contains(NEWSLETTER_REPLACEMENTCODE_DATEADDED) Then
                    '-- only throw ex if address book fields are actually used and contact is not in the address book
                    Throw New Exception("Contact not found in address book and address book replacement codes were used.")
                End If
            Else
                strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_TAGS, contact.Tags)
                strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_CUSTOM1, contact.Custom1)
                strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_CUSTOM2, contact.Custom2)
                strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_CUSTOM3, contact.Custom3)
                strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_CUSTOM4, contact.Custom4)
                If contact.LastMessageReceived Is Nothing Then
                    strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_DATELASTRECEIVED, "n/a")
                Else
                    strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_DATELASTRECEIVED, contact.LastMessageReceived.Value)
                End If
                If contact.LastMessageReceived Is Nothing Then
                    strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_DATELASTSENT, "n/a")
                Else
                    strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_DATELASTSENT, contact.LastMessageSent.Value)
                End If
                strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_HOME, contact.PhoneHome)
                strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_WORK, contact.PhoneWork)
                strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_MOBILE, contact.PhoneMobile)
                strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_WEB, contact.WebPage)
                strReturn = strReturn.Replace(NEWSLETTER_REPLACEMENTCODE_DATEADDED, contact.Added)
            End If

            Return strReturn

        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Function
    Private Sub RemoveAttachmentsForNewsletterMessage(doc As Xml.XmlDocument, originalMessageID As String)
        Try
            Dim xList As Xml.XmlNodeList = doc.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_ATTACHMENT)
            Dim strSourceFilename, strDestinationFilename As String
            For Each xNode As Xml.XmlElement In xList
                Application.DoEvents()
                strSourceFilename = AttachmentsRootPath & originalMessageID & System.IO.Path.DirectorySeparatorChar & xNode.GetAttribute(MESSAGE_ATTRIBUTE_NAME_NAME)

                DeleteLocalFile(strSourceFilename)
            Next
        Catch ex As Exception
            Log(ex)
            '-- log and continue
        End Try
    End Sub
    Private Sub CopyOverAttachmentsForNewsletterMessage(doc As Xml.XmlDocument, originalMessageID As String, newMessageID As String)
        Try
            Dim xList As Xml.XmlNodeList = doc.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_ATTACHMENT)
            Dim strSourceFilename, strDestinationFilename As String
            For Each xNode As Xml.XmlElement In xList
                Application.DoEvents()
                strSourceFilename = AttachmentsRootPath & originalMessageID & System.IO.Path.DirectorySeparatorChar & xNode.GetAttribute(MESSAGE_ATTRIBUTE_NAME_NAME)
                strDestinationFilename = AttachmentsRootPath & newMessageID & System.IO.Path.DirectorySeparatorChar & xNode.GetAttribute(MESSAGE_ATTRIBUTE_NAME_NAME)

                If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strDestinationFilename)) Then
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strDestinationFilename))
                End If

                System.IO.File.Copy(strSourceFilename, strDestinationFilename)
            Next
        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Sub
    Friend Sub RescheduleSendingDate(ByVal newDate As Date)
        RescheduleSendingDate(m_strRecentFilename, newDate)
    End Sub
    Friend Sub RescheduleSendingDate(ByVal filename As String, ByVal newDate As Date)
        Dim xDoc As New Xml.XmlDocument()
        xDoc.Load(filename)

        Dim strSendAfterDate As String = newDate.ToString(DATEFORMAT_XML)
        xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDAFTERDATE, strSendAfterDate)
        xDoc.Save(filename)
    End Sub
    Friend Sub DeleteMostRecentMessage()
        DeleteLocalFile(m_strRecentFilename)
        MainFormReference.ShowFolderContentsIfCurrent(System.IO.Path.GetDirectoryName(m_strRecentFilename))
        'g_boolFileSystemChanged = True
    End Sub
    Friend Sub MakeMostRecentDraft()
        MakeMessageDraft(m_strRecentFilename)
    End Sub
End Class
