Imports System.Xml

<Serializable()> Friend Class TrulyMailMessage
#Region " Public properties "

#Region " Readonly properties "
    Public ReadOnly Property CanReply() As Boolean
        Get
            Return Not Me.Sent AndAlso (Me.MessageType = MessageType.Communication OrElse Me.MessageType = MessageType.ExternalReply)
        End Get
    End Property
    Public ReadOnly Property CanReplyAll() As Boolean
        Get
            Return Not Me.Sent AndAlso Me.MessageType = MessageType.Communication
        End Get
    End Property
    Public ReadOnly Property CanForward() As Boolean
        Get
            Return (Me.MessageType = MessageType.Communication OrElse Me.MessageType = MessageType.ExternalReply OrElse Me.MessageType = MessageType.RSSArticle OrElse Me.MessageType = MessageType.PageChangeNotice)
        End Get
    End Property
    Public ReadOnly Property CanFollowUp() As Boolean
        Get
            Return Sent AndAlso (MessageType = MessageType.Communication)  '-- if we sent it as a communication then we can follow up
        End Get
    End Property
    Public ReadOnly Property CanPrint() As Boolean
        Get
            Return (Me.MessageType = MessageType.Communication OrElse Me.MessageType = MessageType.ExternalReply OrElse Me.MessageType = MessageType.RSSArticle OrElse Me.MessageType = MessageType.PageChangeNotice)
        End Get
    End Property
    Public ReadOnly Property CanReadMessageContentsAloud() As Boolean
        Get
            Return (Me.MessageType = MessageType.Communication OrElse Me.MessageType = MessageType.ExternalReply OrElse Me.MessageType = MessageType.RSSArticle OrElse Me.MessageType = MessageType.PageChangeNotice)
        End Get
    End Property
    Public ReadOnly Property SubjectShort() As String
        Get
            If Subject.Length > SUBJECT_SHORT_LENGTH Then
                Return Subject.Substring(0, SUBJECT_SHORT_LENGTH - 3) & "..."
            Else
                Return Subject
            End If
        End Get
    End Property
    Public ReadOnly Property SenderName() As String
        Get
            If Sender.FullName.Length > 0 Then
                Return Sender.FullName
            Else
                Return Sender.Address
            End If
        End Get
    End Property
    Public ReadOnly Property RecipientNames() As String
        Get
            Const DELIMITER As String = "; "
            If m_strRecipientNames Is Nothing Then
                Dim sbReturn As New System.Text.StringBuilder()
                For Each entry As RecipientEntry In Recipients
                    If entry.FullName.Length > 0 Then
                        sbReturn.Append(DELIMITER & entry.FullName)
                    Else
                        sbReturn.Append(DELIMITER & entry.Address)
                    End If
                Next

                Do Until sbReturn.Length < 2 OrElse Not (sbReturn(0) = DELIMITER.Substring(0, 1) AndAlso sbReturn(1) = DELIMITER.Substring(1, 1))
                    sbReturn = sbReturn.Remove(0, 2)
                Loop

                m_strRecipientNames = sbReturn.ToString()
            End If

            Return m_strRecipientNames
        End Get
    End Property
    ''' <summary>
    ''' Will return the relevant date either sent, tosend, or received baesd on message details
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MainMessageDate As Date
        '-- Using this will allow sorting in drafts folder (not possible in v4.3)
        Get
            Try
                If Sent Then
                    '-- If message was not sent yet, then do show future sending date.
                    If MessageDateSent = Date.MinValue Then
                        If MessageDateToSend = Date.MinValue Then
                            If LastSaveDate > Date.MinValue Then
                                Return LastSaveDate
                            Else
                                '-- msg is to be sent but not sent yet and not saved yet (should not get here)
                                Application.DoEvents() '-- for breakpoint
                            End If
                        Else
                            Return MessageDateToSend
                        End If
                    ElseIf MessageDateUnsent > Date.MinValue Then
                        Return MessageDateUnsent
                    Else
                        Return MessageDateSent
                    End If
                Else
                    Return MessageDateSent
                End If
            Catch ex As Exception
                Log(ex)
                Return Date.MinValue
            End Try
        End Get
    End Property
    Public ReadOnly Property MainMessageDateLabel As String
        Get
            If Sent Then
                '-- If message was not sent yet, then do show future sending date.
                If MessageDateSent = Date.MinValue Then
                    If MessageDateToSend = Date.MinValue Then
                        If LastSaveDate > Date.MinValue Then
                            Return "Last saved:"
                        Else
                            '-- msg is to be sent but not sent yet and not saved yet (should not get here)
                            Application.DoEvents() '-- for breakpoint
                        End If
                    Else
                        Return "To send:"
                    End If
                ElseIf MessageDateUnsent > Date.MinValue Then
                    Return "Unsent:"
                Else
                    Return "Sent:"
                End If
            Else
                Return "Sent:"
            End If
        End Get
    End Property

    Private m_strOtherParties As String
    Public ReadOnly Property OtherParties() As String
        Get
            If m_strOtherParties Is Nothing Then
                Return String.Empty
            Else
                Return m_strOtherParties
            End If
        End Get
    End Property
    Public ReadOnly Property RecipientNamesShort() As String
        Get
            If RecipientNames IsNot Nothing Then
                If RecipientNames.Length > OTHERPARTIES_SHORT_LENGTH Then
                    Return RecipientNames.Substring(0, OTHERPARTIES_SHORT_LENGTH - 3) & "..."
                Else
                    Return RecipientNames
                End If
            Else
                Return String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property OtherPartiesShort() As String
        Get
            If m_strOtherParties IsNot Nothing Then
                If m_strOtherParties.Length > OTHERPARTIES_SHORT_LENGTH Then
                    Return m_strOtherParties.Substring(0, OTHERPARTIES_SHORT_LENGTH - 3) & "..."
                Else
                    Return m_strOtherParties
                End If
            Else
                Return String.Empty
            End If
        End Get
    End Property
    Public ReadOnly Property FolderName() As String
        Get
            Dim strFolder As String = System.IO.Path.GetDirectoryName(Filename)
            Return System.IO.Path.GetFileName(strFolder)
        End Get
    End Property

    Private m_dblReceived As Double
    ''' <summary>
    ''' % of recipients who have received the message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Received As Double
        Get
            Return m_dblReceived
        End Get
    End Property

    Private m_dblViewed As Double
    ''' <summary>
    ''' % of the recipients who have viewed the message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Viewed As Double
        Get
            Return m_dblViewed
        End Get
    End Property

    Private m_strMessageID As String
    Public ReadOnly Property MessageID As String
        Get
            Return m_strMessageID
        End Get
    End Property


    Private m_TransportType As MessageTransportType
    Public ReadOnly Property TransportType As MessageTransportType
        Get
            Return m_TransportType
        End Get
    End Property

    Private m_boolReplied As Boolean
    Public ReadOnly Property Replied As Boolean
        Get
            Return m_boolReplied
        End Get
    End Property

    Private m_boolForwarded As Boolean
    Public ReadOnly Property Forwarded As Boolean
        Get
            Return m_boolForwarded
        End Get
    End Property
   
    Private m_intSize As Integer
    Public ReadOnly Property Size As Integer
        Get
            Return m_intSize
        End Get
    End Property

    Private m_boolSent As Boolean
    Public ReadOnly Property Sent As Boolean '-- true if we sent the message, false if we received the message
        Get
            Return m_boolSent
        End Get
    End Property

    

    Private m_strReferenceURL As String
    Public ReadOnly Property ReferenceURL As String
        Get
            Return m_strReferenceURL
        End Get
    End Property

    Private m_dtMessageDateUnsent As Date
    Public ReadOnly Property MessageDateUnsent As Date
        Get
            Return m_dtMessageDateUnsent
        End Get
    End Property

    Private m_boolReturnReceiptRequested As Boolean
    Public Property ReturnReceiptRequested As Boolean
        Get
            Return m_boolReturnReceiptRequested
        End Get
        Set(value As Boolean)
            m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_REQUESTRETURNRECEIPT, value.ToString())
        End Set
    End Property

    Private m_dtLastSaveDate As Date
    Public ReadOnly Property LastSaveDate As Date
        Get
            Return m_dtLastSaveDate
        End Get
    End Property

   

#End Region '-- readonly properties


#Region " Properties which persist to XML "


    Private m_SMTPProfile As SMTPProfile
    Public Property SMTPProfile As SMTPProfile
        Get
            Return m_SMTPProfile
        End Get
        Set(value As SMTPProfile)
            m_SMTPProfile = value

            '-- update xml
            m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SMTPACCOUNT, value.ID)

        End Set
    End Property

    Private m_Sender As RecipientEntry
    Public Property Sender As RecipientEntry
        Get
            Return m_Sender
        End Get
        Set(value As RecipientEntry)
            m_Sender = value

            '-- update xml
            If value IsNot Nothing Then
                m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDERADDRESS, value.Address)
                m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDERFULLNAME, value.FullName)
            Else
                '-- no sender? Remove attribute if it exists
                m_xDoc.DocumentElement.RemoveAttribute(MESSAGE_ATTRIBUTE_NAME_SENDERADDRESS)
                m_xDoc.DocumentElement.RemoveAttribute(MESSAGE_ATTRIBUTE_NAME_SENDERFULLNAME)
            End If

        End Set
    End Property


    Private m_dtMessageDateSent As Date
    Public Property MessageDateSent As Date
        Get
            Return m_dtMessageDateSent
        End Get
        Set(value As Date)
            m_dtMessageDateSent = value

            '-- update xml
            m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENTDATE, value.ToString(DATEFORMAT_XML))

        End Set
    End Property

    '=== WHAT TO DO?
    '   Caller gets a reference to the list and then can change the list contents
    '   List cannot be replaced but contents of list can be replaced
    '   How do we get notified of changes so we can persist them?
    '   I think we just don't persist changes (once loaded, changes will not be persisted)
    Private m_lstRecipeints As New List(Of RecipientEntry)
    Public ReadOnly Property Recipients As List(Of RecipientEntry)
        Get
            Return m_lstRecipeints
        End Get
    End Property
    Public Function AddRecipient(name As String, address As String, recipientType As RecipientType) As RecipientEntry
        Dim entry As New RecipientEntry(AddressBookEntryType.Email)
        entry.FullName = name
        entry.Address = address
        entry.RecipientType = recipientType
        m_lstRecipeints.Add(entry)

        '-- Update XML
        Dim xAddresses As Xml.XmlElement = m_xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_ADDRESSES)
        If xAddresses Is Nothing Then
            xAddresses = m_xDoc.DocumentElement.AppendChild(m_xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ADDRESSES))
        End If
        Dim xAddress As Xml.XmlElement

        xAddress = m_xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ADDRESS)
        xAddress.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID, GetRoleIDByRecipientType(recipientType))
        xAddress.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME, name)
        xAddress.InnerText = address
        xAddresses.AppendChild(xAddress)

        Return entry
    End Function


    Private m_MessageType As MessageType
    Public Property MessageType As MessageType
        Get
            Return m_MessageType
        End Get
        Set(value As MessageType)
            m_MessageType = value

            m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGETYPEID, GetMessageTypeIDFromMessageType(value))
        End Set
    End Property

    Private m_boolRead As Boolean
    ''' <summary>
    ''' Mark message as read and set PromptToSendReadReceipt property
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Read As Boolean
        Get
            Return m_boolRead
        End Get
        Set(value As Boolean)
            'm_boolShouldPromptToSendReadReceipt = False

            If m_boolRead <> value Then '-- If there is no change, don't do anything
                m_boolRead = value

                '-- Update xml
                If m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_READ).Length = 0 Then
                    If Me.Read = False Then
                        '-- do nothing because should be unread and no setting means unread
                    Else
                        '-- This is the first time marking the msg read, now we need to consider read receipts
                        If ReadReceiptSent = DATE_NEVER Then '-- This should ALWAYS be true (how could we have sent a receipt without previously reading the msg?)
                            Dim strReceiptAddress As String = SendReadReceiptToAddress
                            If strReceiptAddress.Length > 0 Then
                                '-- Sender requested a read receipt and it was never sent
                                '   Now we must explore the address book to see what we know about this contact
                                Dim entry As AddressBookEntry = ABook.GetContactByAddress(strReceiptAddress)

                                If entry Is Nothing Then
                                    '-- We don't know this sender, must look to global settings
                                    Select Case Me.POPProfile.SendReturnReceiptSenderNotInAddressBook
                                        Case POPReceiptOption.Always
                                            SendReadReceipt(False) '-- auto-send
                                            m_boolShouldPromptToSendReadReceipt = False
                                        Case POPReceiptOption.Never
                                            '-- do nothing
                                            m_boolShouldPromptToSendReadReceipt = False
                                        Case POPReceiptOption.AskMe
                                            '-- prompt
                                            m_boolShouldPromptToSendReadReceipt = True
                                    End Select
                                Else
                                    '-- we do know this sender, use contact's settings
                                    Select Case entry.AutoSendReadReceipt
                                        Case ContactReceiptOption.Always
                                            SendReadReceipt(False) '-- auto-send
                                            m_boolShouldPromptToSendReadReceipt = False
                                        Case ContactReceiptOption.Never
                                            m_boolShouldPromptToSendReadReceipt = False
                                        Case ContactReceiptOption.UseDefault
                                            Select Case Me.POPProfile.SendReturnReceiptSenderInAddressBook
                                                Case POPReceiptOption.Always
                                                    SendReadReceipt(False) '-- auto-send
                                                    m_boolShouldPromptToSendReadReceipt = False
                                                Case POPReceiptOption.Never
                                                    m_boolShouldPromptToSendReadReceipt = False
                                                Case POPReceiptOption.AskMe
                                                    m_boolShouldPromptToSendReadReceipt = True
                                            End Select
                                    End Select
                                End If
                            Else
                                '-- Normally, we would never send a receipt when it has not been requested
                                '   but in 2020 we added a fun new setting to allow just that
                                Dim entry As AddressBookEntry = ABook.GetContactByAddress(Me.Sender.Address)
                                If entry IsNot Nothing Then
                                    Select Case entry.AutoSendReadReceipt
                                        Case ContactReceiptOption.AlwaysForced
                                            '-- we only force send on regular messags. Don't ack the ack.
                                            If Not Me.IsReadReceipt Then
                                                SendReadReceipt(False) '-- auto-send
                                                m_boolShouldPromptToSendReadReceipt = False
                                            End If
                                    End Select
                                End If

                            End If
                        Else
                            '-- This should NEVER be true
                            Log("ReadReceiptSent was set without READ value being set.")
                            '-- regardless, we DID send a receipt so we don't need to send one now
                            m_boolShouldPromptToSendReadReceipt = False
                        End If
                    End If
                End If

                '-- Persist the changes
                m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_READ, Me.Read)
                Me.Save()
            End If
        End Set
    End Property


    Private m_dtMessageDateToSend As Date
    Public Property MessageDateToSend As Date
        Get
            Return m_dtMessageDateToSend
        End Get
        Set(value As Date)
            m_dtMessageDateToSend = value

            '-- save xml
            m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDAFTERDATE, ConvertToUtc(MessageDateToSend).ToString(DATEFORMAT_XML))
        End Set
    End Property

    Public ReadOnly Property HasNotes As Boolean
        Get
            Return Notes IsNot Nothing AndAlso Notes.Length > 0
        End Get
    End Property

    Private m_strTags As String = String.Empty
    Public Property Tags As String
        Get
            Return m_strTags
        End Get
        Set(value As String)
            m_strTags = value

            '-- Update tag
            Dim xElement As Xml.XmlElement = m_xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_TAGS)
            If xElement Is Nothing Then
                xElement = m_xDoc.DocumentElement.AppendChild(m_xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_TAGS))
            End If
            xElement.InnerText = Tags
        End Set
    End Property

    Private m_intImportance As Integer
    Public Property Importance As Integer '-- set on received message by sender's importance
        Get
            Return m_intImportance
        End Get
        Set(value As Integer)
            m_intImportance = value

            '-- Update xml
            m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_IMPORTANCE, Importance)
        End Set
    End Property

    Private m_dtMessageDateReceived As Date
    Public Property MessageDateReceived As Date
        Get
            Return m_dtMessageDateReceived
        End Get
        Set(value As Date)
            m_dtMessageDateReceived = value

            '-- update xml
            m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_RECEIVED, value.ToString(DATEFORMAT_XML))

        End Set
    End Property


    Private m_strNotes As String
    Public Property Notes As String
        Get
            Return m_strNotes
        End Get
        Set(value As String)
            m_strNotes = value

            '-- update xml
            Dim xElement As Xml.XmlElement = m_xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_NOTES)
            If value Is Nothing OrElse value.Length = 0 Then
                '-- remove notes
                xElement.ParentNode.RemoveChild(xElement)
            Else
                '-- set notes
                If xElement Is Nothing Then
                    xElement = m_xDoc.DocumentElement.AppendChild(m_xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_NOTES))
                End If
                xElement.InnerText = value
            End If

        End Set
    End Property
    Public Sub AppendNote(newNote As String)
        If Notes Is Nothing Then
            Notes = newNote
        ElseIf Notes.Length = 0 Then
            Notes = newNote
        ElseIf Notes.Length > 0 Then
            Notes &= Environment.NewLine & Environment.NewLine & newNote
        End If

    End Sub

    Private m_strSubject As String
    Public Property Subject As String
        Get
            Return m_strSubject
        End Get
        Set(value As String)
            m_strSubject = value

            '-- update xml
            Dim xElement As Xml.XmlElement = m_xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_SUBJECT)
            If xElement Is Nothing Then
                '-- Create it
                xElement = m_xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_SUBJECT)
                m_xDoc.DocumentElement.AppendChild(xElement)
            End If

            xElement.InnerText = m_strSubject
        End Set
    End Property

    Private m_strBody As String
    Public Property Body As String
        Get
            Return m_strBody
        End Get
        Set(value As String)
            m_strBody = value

            '-- update xml
            Dim xElement As Xml.XmlElement = m_xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_BODY)
            If xElement Is Nothing Then
                '-- Create it
                xElement = m_xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_BODY)
                m_xDoc.DocumentElement.AppendChild(xElement)
            End If

            xElement.InnerText = m_strBody
        End Set
    End Property
    Public ReadOnly Property BodySafeHTML As String
        Get
            '-- I basically just put the old ReadMessageControl (not 7) code in here
            '   still issues stemming from it being written with UI in mind
            Dim strHTML As String = Me.Body

            strHTML = strHTML.Replace(ATTACHMENTS_FOLDER_REPLACEMENT_CODE, AttachmentsRootPath)

            Dim strBlockedNoticeText As String = String.Empty

            Dim strAlternateHTML As String
            Dim intScripts As Integer
            strAlternateHTML = RemoveScripts(strHTML, intScripts)
            If intScripts > 0 Then
                strHTML = strAlternateHTML
                strBlockedNoticeText = "TrulyMail blocked " & intScripts.ToString() & " script(s) in this message."
            ElseIf intScripts < 0 Then
                '-- in this case, there were changes made but no scripts were removed
                '   like <a target_blank> being stripped out
                strHTML = strAlternateHTML
            End If


            Dim intBlockedImages As Integer
            strAlternateHTML = BlockRemoteImages(strHTML, intBlockedImages)
            strHTML = strAlternateHTML


            '-- Now, update the HTML to show tooltip over links
            Dim intAffected As Integer
            strAlternateHTML = AddTitleToAnchorTags(strHTML, intAffected)
            If intAffected > 0 Then
                strHTML = strAlternateHTML
            End If


            '-- Added in 3.0, remove iFrames
            Dim intIFrames As Integer
            strAlternateHTML = RemoveIFrames(strHTML, intIFrames)
            If intIFrames > 0 Then
                strHTML = strAlternateHTML
                If strBlockedNoticeText.Length > 0 Then
                    strBlockedNoticeText &= Environment.NewLine
                End If
                strBlockedNoticeText &= "TrulyMail blocked " & intIFrames.ToString() & " IFrame(s) in this message."
            End If


            '-- Added in 4.0, remove applets, and many, many more (thanks to https://emailprivacytester.com)
            Dim intRemoved As Integer
            strAlternateHTML = RemoveApplets(strHTML, intRemoved)
            If intRemoved > 0 Then
                strHTML = strAlternateHTML
                If strBlockedNoticeText.Length > 0 Then
                    strBlockedNoticeText &= Environment.NewLine
                End If
                strBlockedNoticeText &= "TrulyMail blocked " & intRemoved.ToString() & " Applets(s) in this message."
            End If

            intRemoved = 0
            strAlternateHTML = RemoveObjects(strHTML, intRemoved)
            If intRemoved > 0 Then
                strHTML = strAlternateHTML
                If strBlockedNoticeText.Length > 0 Then
                    strBlockedNoticeText &= Environment.NewLine
                End If
                strBlockedNoticeText &= "TrulyMail blocked " & intRemoved.ToString() & " object(s) in this message."
            End If

            intRemoved = 0
            strAlternateHTML = RemoveMetaRefresh(strHTML, intRemoved)
            If intRemoved > 0 Then
                strHTML = strAlternateHTML
                If strBlockedNoticeText.Length > 0 Then
                    strBlockedNoticeText &= Environment.NewLine
                End If
                strBlockedNoticeText &= "TrulyMail blocked " & intRemoved.ToString() & " meta-refresh(es) in this message."
            End If

            intRemoved = 0
            strAlternateHTML = RemoveRemoteLinkedContent(strHTML, intRemoved)
            If intRemoved > 0 Then
                strHTML = strAlternateHTML
                If strBlockedNoticeText.Length > 0 Then
                    strBlockedNoticeText &= Environment.NewLine
                End If
                strBlockedNoticeText &= "TrulyMail blocked " & intRemoved.ToString() & " remote linked content(s) in this message."
            End If

            intRemoved = 0
            strAlternateHTML = RemoveRemoteBackgroundImages(strHTML, intRemoved)
            If intRemoved > 0 Then
                strHTML = strAlternateHTML
                If strBlockedNoticeText.Length > 0 Then
                    strBlockedNoticeText &= Environment.NewLine
                End If
                strBlockedNoticeText &= "TrulyMail blocked " & intRemoved.ToString() & " remote paragraph(s) in this message."
            End If

            intRemoved = 0
            strAlternateHTML = RemoveEmbeddedAnything(strHTML, intRemoved)
            If intRemoved > 0 Then
                strHTML = strAlternateHTML
                If strBlockedNoticeText.Length > 0 Then
                    strBlockedNoticeText &= Environment.NewLine
                End If
                strBlockedNoticeText &= "TrulyMail blocked " & intRemoved.ToString() & " embedded objects(s) in this message."
            End If

            intRemoved = 0
            strAlternateHTML = RemoveImportedCSSStyles(strHTML, intRemoved)
            If intRemoved > 0 Then
                strHTML = strAlternateHTML
                If strBlockedNoticeText.Length > 0 Then
                    strBlockedNoticeText &= Environment.NewLine
                End If
                strBlockedNoticeText &= "TrulyMail blocked " & intRemoved.ToString() & " remote CSS style(s) in this message."
            End If

            intRemoved = 0
            strAlternateHTML = RemoveRemoteBodyBackground(strHTML, intRemoved)
            If intRemoved > 0 Then
                strHTML = strAlternateHTML
                If strBlockedNoticeText.Length > 0 Then
                    strBlockedNoticeText &= Environment.NewLine
                End If
                strBlockedNoticeText &= "TrulyMail blocked " & intRemoved.ToString() & " remote background image(s) in this message."
            End If

            intRemoved = 0
            strAlternateHTML = RemoveRemoteSounds(strHTML, intRemoved)
            If intRemoved > 0 Then
                strHTML = strAlternateHTML
                If strBlockedNoticeText.Length > 0 Then
                    strBlockedNoticeText &= Environment.NewLine
                End If
                strBlockedNoticeText &= "TrulyMail blocked " & intRemoved.ToString() & " remote background sound(s) in this message."
            End If

            intRemoved = 0
            strAlternateHTML = RemoveRemoteImageInputs(strHTML, intRemoved)
            If intRemoved > 0 Then
                strHTML = strAlternateHTML
                If strBlockedNoticeText.Length > 0 Then
                    strBlockedNoticeText &= Environment.NewLine
                End If
                strBlockedNoticeText &= "TrulyMail blocked " & intRemoved.ToString() & " remote image button(s) in this message."
            End If

            Return strHTML
        End Get
    End Property


    Private m_boolPOPProfile As POPProfile
    Public Property POPProfile As POPProfile
        Get
            Return m_boolPOPProfile
        End Get
        Set(value As POPProfile)
            m_boolPOPProfile = value

            '-- Update XML
            If value Is Nothing Then
                m_xDoc.DocumentElement.RemoveAttribute(MESSAGE_ATTRIBUTE_NAME_POPACCOUNT)
            Else
                m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_POPACCOUNT, value.ID)
            End If
        End Set
    End Property

    Private m_boolEncrypted As Boolean
    Public Property Encrypted As Boolean
        Get
            Return m_boolEncrypted
        End Get
        Set(value As Boolean)
            m_boolEncrypted = value

            m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTED, value.ToString())
        End Set
    End Property

    Private m_BodyFormat As EmailBodyFormatEnum
    Public Property BodyFormat As EmailBodyFormatEnum
        Get
            Return m_BodyFormat
        End Get
        Set(value As EmailBodyFormatEnum)
            m_BodyFormat = value

            '-- update xml
            Dim xElement As Xml.XmlElement = m_xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_BODY)
            If xElement Is Nothing Then
                xElement = m_xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_BODY)
                m_xDoc.DocumentElement.AppendChild(xElement)
            End If

            If value = EmailBodyFormatEnum.PlainText Then
                xElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FORMAT, "PlainText")
            Else
                xElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FORMAT, "HTML")
            End If
        End Set
    End Property

    Private m_strReplyTo As String
    Public Property ReplyTo As String
        Get
            Return m_strReplyTo
        End Get
        Set(value As String)
            m_strReplyTo = value

            '-- Update xml
            m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_EMAILREPLYTO, value)

        End Set
    End Property

#End Region

#Region " Public non-persisted properties "
    Public Property Filename As String
    Public Property LastChecked As Date '-- Last time the data was updated in the message index file
#End Region

#End Region

    Private m_strRecipientNames As String
    Public m_xDoc As Xml.XmlDocument

    Private Const SUBJECT_SHORT_LENGTH As Integer = 55
    Private Const OTHERPARTIES_SHORT_LENGTH As Integer = 40

#Region " Attachment logic "
    Private m_lstEmbeddedImages As List(Of AttachmentItem)
    Public ReadOnly Property EmbeddedImages As List(Of AttachmentItem)
        Get
            Return m_lstEmbeddedImages
        End Get
    End Property
    Public Function AddEmbeddedImage(imageFilename As String, Optional copyFileToImagesFolder As Boolean = True) As AttachmentItem
        Try
            If Not System.IO.File.Exists(imageFilename) Then
                Throw New System.IO.FileNotFoundException()
            End If

            If m_lstEmbeddedImages Is Nothing Then
                LoadEmbeddedImageList()
            End If

            Dim objDupAttachmentItem As AttachmentItem '-- return this if dup is found

            '-- Make sure this is not a duplicate
            Dim boolIsDuplicate As Boolean
            If m_lstAttachments IsNot Nothing Then
                For Each item As AttachmentItem In m_lstAttachments
                    If System.IO.Path.GetFileName(item.Filename.ToLower()) = System.IO.Path.GetFileName(imageFilename.ToLower()) Then
                        objDupAttachmentItem = item
                        boolIsDuplicate = True
                    End If
                Next
            End If

            '-- make sure the images folder exists
            Dim strImagesFolder As String = QualifyPath(AttachmentsRootPath) & System.IO.Path.GetFileNameWithoutExtension(Me.Filename) & "\" & IMAGES_EMBEDDED_FOLDER
            If Not System.IO.Directory.Exists(strImagesFolder) Then
                System.IO.Directory.CreateDirectory(strImagesFolder)
            End If


            If boolIsDuplicate Then
                '-- ignore
                Return objDupAttachmentItem
            Else
                Dim item As AttachmentItem
                item = New AttachmentItem()
                item.FileSize = FileLen(imageFilename)
                item.DisplayName = System.IO.Path.GetFileName(imageFilename)
                item.Filename = QualifyPath(AttachmentsRootPath) & System.IO.Path.GetFileNameWithoutExtension(Me.Filename) & "\" & IMAGES_EMBEDDED_FOLDER & item.DisplayName '-- I put this here so can use it in a test under encrypted branch below

                If AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypting OrElse AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypted Then
                    '-- We must encrypt in the attachments folder
                    '   So, no need to check if we need to copy, we MUST copy by encrypting
                    If System.IO.File.Exists(imageFilename) Then
                        Dim strTempFilename, strEncryptedFilename As String
                        strTempFilename = System.IO.Path.GetFileName(GetTempFilename(".encrypted"))
                        strEncryptedFilename = QualifyPath(AttachmentsRootPath) & m_strMessageID & "\" & IMAGES_EMBEDDED_FOLDER & strTempFilename
                        EncryptFile(AppSettings.GetFileEncryptionPassword, imageFilename, 1, strEncryptedFilename)

                        '-- Delete unencrypted file in attachments folder (if it is there)
                        If imageFilename.ToLower.Equals(item.Filename.ToLower) Then
                            DeleteLocalFile(imageFilename)
                        End If

                        item.Encrypted = True
                        item.Filename = strEncryptedFilename
                    Else
                        '-- File was not there, just log and continue
                        Log("Embedded image not found for encryption: " & imageFilename)
                    End If

                Else
                    '-- Not encrypted. If necessary, copy unencrypted file over
                    '   If the file exists already then it must have been an error 
                    '   for the sender but there might be two references to same image, 
                    '   still just need the image one time so ignore subsequent copies
                    If copyFileToImagesFolder AndAlso Not imageFilename.ToLower.Equals(item.Filename.ToLower) AndAlso Not System.IO.File.Exists(item.Filename) Then
                        System.IO.File.Copy(imageFilename, item.Filename)
                    End If

                End If

                m_lstEmbeddedImages.Add(item)

                '-- We do not update the xml for embedded images (but maybe we should?)

                Return item
            End If

        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try

    End Function

    Public Sub LoadEmbeddedImageList()
        '-- We do not persist this data in the xml so...should we start doing that?
        '   If we do we could keep the display name as the embedded image unencrypted name while the filename would be the actual encrypted filename
        m_lstEmbeddedImages = New List(Of AttachmentItem)



        '-- None of the following works because it deals only with regular attachments, not embedded attachments

        ' '' ''Dim xList As Xml.XmlNodeList = m_xDoc.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_ATTACHMENT)
        ' '' ''For Each xElement As Xml.XmlElement In xList
        ' '' ''    item = New AttachmentItem()
        ' '' ''    item.FileSize = Convert.ToInt32(xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILESIZE))
        ' '' ''    item.DisplayName = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME)

        ' '' ''    '-- If there is an encrypted filename, then the attachment is encrypted, otherwise it is not
        ' '' ''    If xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDFILENAME).Length > 0 Then
        ' '' ''        item.Encrypted = True
        ' '' ''        item.Filename = QualifyPath(AttachmentsRootPath) & System.IO.Path.GetFileNameWithoutExtension(Filename) & "\" & xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDFILENAME)
        ' '' ''    Else
        ' '' ''        item.Encrypted = False
        ' '' ''        item.Filename = QualifyPath(AttachmentsRootPath) & System.IO.Path.GetFileNameWithoutExtension(Filename) & "\" & item.DisplayName
        ' '' ''    End If

        ' '' ''    m_lstEmbeddedImages.Add(item)
        ' '' ''Next


        '   It seems embedded attachments do not get saved in the XML as anything
        '   OPTION 1: Change so that we do that (but what about old messages??)
        '   OPTION 2: Parse the HTML for IMG tags
        '   OPTION 3: Scan the images folder under attachments

        '-- Option 3 seems easiest, so we will do that for now
        Dim strAttachmentFolder As String = AttachmentsRootPath
        strAttachmentFolder &= System.IO.Path.GetFileNameWithoutExtension(Filename)
        strAttachmentFolder &= "\" & IMAGES_EMBEDDED_FOLDER
        If System.IO.Directory.Exists(strAttachmentFolder) Then
            Dim files As String() = System.IO.Directory.GetFiles(strAttachmentFolder)
            Dim item As AttachmentItem
            For Each strFilename As String In files
                item = New AttachmentItem()
                item.Filename = strFilename
                item.FileSize = FileLen(strFilename)
                item.DisplayName = System.IO.Path.GetFileName(strFilename)
                m_lstEmbeddedImages.Add(item)
            Next
        End If

    End Sub



    Private m_lstAttachments As List(Of AttachmentItem)

    ''' <summary>
    ''' Adds the attachment, if the attachment cannot be found, an error is thrown
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <param name="copyFileToAttachmentsFolder"></param>
    ''' <returns>AttachmentItem created and added to message</returns>
    ''' <remarks></remarks>
    Public Function AddAttachment(filename As String, Optional copyFileToAttachmentsFolder As Boolean = True) As AttachmentItem

        If Not System.IO.File.Exists(filename) Then
            Throw New System.IO.FileNotFoundException()
        End If

        If m_lstAttachments Is Nothing Then
            LoadAttachmentList()
        End If

        '-- Make sure this is not a duplicate
        Dim boolIsDuplicate As Boolean
        For Each item As AttachmentItem In m_lstAttachments
            If item.Filename.ToLower = filename.ToLower() Then
                boolIsDuplicate = True
            End If
        Next

        If boolIsDuplicate Then
            '-- ignore
            Return Nothing
        Else
            Dim item As AttachmentItem
            item = New AttachmentItem()
            item.FileSize = FileLen(filename)
            item.DisplayName = System.IO.Path.GetFileName(filename)
            item.Filename = QualifyPath(AttachmentsRootPath) & System.IO.Path.GetFileNameWithoutExtension(Me.Filename) & "\" & item.DisplayName '-- I put this here so can use it in a test under encrypted branch below

            If AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypting OrElse AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypted Then
                '-- We must encrypt in the attachments folder
                '   So, no need to check if we need to copy, we MUST copy by encrypting
                If System.IO.File.Exists(filename) Then
                    Dim strTempFilename, strEncryptedFilename As String
                    strTempFilename = System.IO.Path.GetFileName(GetTempFilename(".encrypted"))
                    strEncryptedFilename = QualifyPath(AttachmentsRootPath) & m_strMessageID & "\" & strTempFilename
                    EncryptFile(AppSettings.GetFileEncryptionPassword, filename, 1, strEncryptedFilename)

                    '-- Delete unencrypted file in attachments folder (if it is there)
                    If filename.ToLower.Equals(item.Filename.ToLower) Then
                        DeleteLocalFile(filename)
                    End If

                    item.Encrypted = True
                    item.Filename = strEncryptedFilename
                Else
                    '-- File was not there, just log and continue
                    Log("Attachment not found for encryption: " & filename)
                End If

            Else
                '-- Not encrypted. If necessary, copy unencrypted file over
                If copyFileToAttachmentsFolder AndAlso Not filename.ToLower.Equals(item.Filename.ToLower) Then
                    If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(item.Filename)) Then
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(item.Filename))
                    End If
                    If Not System.IO.File.Exists(item.Filename) Then '-- Added this to circumvent issue with dup attachments (same attachment name multiple times in a msg received)
                        System.IO.File.Copy(filename, item.Filename)
                    End If
                End If

            End If

            m_lstAttachments.Add(item)

            '-- also add to the XML
            Dim xAttachments As Xml.XmlElement = m_xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_ATTACHMENTS)

            '-- Add attachments element if it does not exist
            If xAttachments Is Nothing Then
                xAttachments = m_xDoc.DocumentElement.AppendChild(m_xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ATTACHMENTS))
            End If

            Dim xAttachment As Xml.XmlElement = m_xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ATTACHMENT)
            xAttachments.AppendChild(xAttachment)
            xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME, item.DisplayName)
            xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILESIZE, item.FileSize.ToString())
            If item.Encrypted Then
                xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDFILENAME, item.Filename) '-- Set encrypted filename in .tmm file 
            End If

            Return item
        End If


    End Function
    ''' <summary>
    ''' Removes the attachment. If the attachment does not exist, it is ignored
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RemoveAttachment(item As AttachmentItem)
        If m_lstAttachments Is Nothing Then
            LoadAttachmentList()
        End If

        '-- remove this item from internal list
        m_lstAttachments.Remove(item)

        '-- also remove from the xml
        Dim xList As Xml.XmlNodeList = m_xDoc.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_ATTACHMENT)
        For Each xElement As Xml.XmlElement In xList
            If xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME).ToLower() = item.DisplayName.ToLower() Then
                xElement.ParentNode.RemoveChild(xElement)
            End If
        Next

        '-- also delete from attachments folder
        If System.IO.File.Exists(item.Filename) Then

        End If

    End Sub
    ''' <summary>
    ''' Returns a list of AttachmentItems for this message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Attachments() As List(Of AttachmentItem)
        Get
            If m_lstAttachments Is Nothing Then
                LoadAttachmentList()
            End If

            Return m_lstAttachments
        End Get
    End Property
    Private Sub LoadAttachmentList()
        m_lstAttachments = New List(Of AttachmentItem)
        Dim item As AttachmentItem
        Dim xList As Xml.XmlNodeList = m_xDoc.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_ATTACHMENT)
        For Each xElement As Xml.XmlElement In xList
            item = New AttachmentItem()
            item.FileSize = Convert.ToInt32(xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILESIZE))
            item.DisplayName = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME)

            '-- If there is an encrypted filename, then the attachment is encrypted, otherwise it is not
            If xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDFILENAME).Length > 0 Then
                item.Encrypted = True
                item.Filename = QualifyPath(AttachmentsRootPath) & System.IO.Path.GetFileNameWithoutExtension(Filename) & "\" & xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDFILENAME)
            Else
                item.Encrypted = False
                item.Filename = QualifyPath(AttachmentsRootPath) & System.IO.Path.GetFileNameWithoutExtension(Filename) & "\" & item.DisplayName
            End If

            m_lstAttachments.Add(item)
        Next
    End Sub

#End Region
    Public Sub MarkForwarded()
        m_boolForwarded = True
        m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FORWARDED, Date.UtcNow.ToString(DATEFORMAT_XML))
        If AppSettings.AddNoteWhenChangingSubject Then '-- simplifying by re-using this setting
            AppendNote(Date.Now.ToString("yyyy-MM-dd hh:mm") & " - message forwarded.")
        End If
    End Sub
    Public Sub MarkReplied()
        m_boolReplied = True
        m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_REPLIED, Date.UtcNow.ToString(DATEFORMAT_XML))
        If AppSettings.AddNoteWhenChangingSubject Then '-- simplifying by re-using this setting
            AppendNote(Date.Now.ToString("yyyy-MM-dd hh:mm") & " - message replied.")
        End If

    End Sub

    Private Sub SetOtherParties()
        If Sender Is Nothing Then
            m_strOtherParties = Nothing
        Else
            If Me.Sent Then
                m_strOtherParties = RecipientNames
            Else
                If Sender.FullName Is Nothing OrElse Sender.FullName.Length = 0 Then
                    m_strOtherParties = Sender.Address
                Else
                    m_strOtherParties = Sender.FullName
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Create an empty TrulyMailMessage object
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Function LoadMessageFromFile(filename As String) As Xml.XmlDocument
        Try

            Dim xDoc As New Xml.XmlDocument()

            '-- Load the file (encrypted or not)
            If AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Decrypted Then
                '-- should be stored as XML, try to just load
                '   backup plan is to catch the error and decrypt and load
                Try
                    xDoc.Load(filename)
                Catch ex As Exception
                    Log(ex)
                    Throw ex
                End Try
            ElseIf AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypted
                Try
                    '-- load the text, decrypt to xml, then load the xml
                    Dim strEncryptedContents As String = System.IO.File.ReadAllText(filename)
                    Dim strPlainContents As String

                    If IsTextEncrypted(strEncryptedContents) Then
                        strPlainContents = DecryptTextSymetric(AppSettings.GetFileEncryptionPassword, strEncryptedContents)
                    Else
                        strPlainContents = strEncryptedContents '-- was not actually encrypted
                    End If

                    xDoc.LoadXml(strPlainContents)
                Catch ex As Exception
                    Log(ex)
                    Throw ex
                End Try
            Else
                '-- could be encrypting or decrypting so we don't know if THIS file is encrypted or not, so
                '   Try reading cleartext, Then try decrypting (if error reading cleartext), then throw error if neither works
                Try
                    xDoc.Load(filename)
                Catch ex As Exception
                    Try
                        '-- load the text, decrypt to xml, then load the xml
                        Dim strEncryptedContents As String = System.IO.File.ReadAllText(filename)
                        Dim strPlainContents As String

                        If IsTextEncrypted(strEncryptedContents) Then
                            strPlainContents = DecryptTextSymetric(AppSettings.GetFileEncryptionPassword, strEncryptedContents)
                        Else
                            strPlainContents = strEncryptedContents '-- was not actually encrypted
                        End If

                        xDoc.LoadXml(strPlainContents)
                    Catch ex1 As Exception
                        Log(ex1)
                        Throw ex1
                    End Try
                End Try
            End If

            Return xDoc
        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Creates a new, empty TrulyMail message in the given folder
    ''' </summary>
    ''' <param name="folderForMessage"></param>
    ''' <remarks></remarks>
    Public Sub New()
        Try
            m_xDoc = New XmlDocument()
            Dim xRoot As Xml.XmlElement = m_xDoc.AppendChild(m_xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_MESSAGE))

            '-- Create and set the MessageID
            m_strMessageID = Guid.NewGuid.ToString()

            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGEID, m_strMessageID)



        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Loads a TrulyMail message from file
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <remarks></remarks>
    Public Sub New(filename As String)
        Try

            Dim dtSent As Date
            Dim strSubject, strSenderID, strRecipientID, strRecipientList, strXPath As String
            Dim strSize As String
            Dim boolRead As Boolean
            Dim intAttachments As Integer
            Dim xElement As Xml.XmlElement

            If Not System.IO.File.Exists(filename) Then
                Throw New System.IO.FileNotFoundException
            End If

            Me.Filename = filename

            m_xDoc = LoadMessageFromFile(filename)

            m_strMessageID = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGEID)

            Dim strSaveDate As String = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_LASTSAVEDATE)
            If strSaveDate.Length > 0 Then
                Try
                    Dim dt As Date = ConvertToLocalTime(Date.Parse(strSaveDate))
                    m_dtLastSaveDate = dt
                Catch ex As Exception
                    '-- completely ignore
                    Application.DoEvents() '-- for breakpoint only
                End Try
            End If


            strSize = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGESIZE)

            If strSize.Length > 0 Then
                Dim strDateSent As String = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SENTDATE)
                If strDateSent.Length > 0 Then
                    dtSent = ConvertToLocalTime(ConvertToDateFromXML(strDateSent, Date.UtcNow))
                End If

                Dim strRead As String = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_READ)
                If strRead = String.Empty Then
                    boolRead = False
                Else
                    boolRead = Convert.ToBoolean(strRead)
                End If

                If m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_IMPORTANCE).Length > 0 Then
                    Importance = ConvertToInt32(m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_IMPORTANCE), 0)
                End If

                strXPath = "//" & MESSAGE_ATTRIBUTE_NAME_SUBJECT
                xElement = m_xDoc.SelectSingleNode(strXPath)
                If xElement IsNot Nothing Then
                    strSubject = xElement.InnerText
                Else
                    strSubject = String.Empty
                End If

                If strSubject.Length = 0 Then
                    strSubject = AppSettings.DefaultMessageSubject
                End If

                Dim xList As Xml.XmlNodeList

                Subject = strSubject

                m_boolRead = boolRead '-- changing 17 June 2019. Was Read= but that was causing all files to be written to disk (causing delays in syncing)
                m_dtMessageDateSent = dtSent
                filename = filename

                If m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_REPLIED).Length > 0 Then
                    m_boolReplied = True
                End If
                If m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FORWARDED).Length > 0 Then
                    m_boolForwarded = True
                End If

                If m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTED).Length > 0 Then
                    m_boolEncrypted = Convert.ToBoolean(m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTED))
                Else
                    m_boolEncrypted = False
                End If

                m_MessageType = GetMessageTypeFromMessageTypeID(m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGETYPEID))
                If m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGETYPEID).Trim.Length = 0 Then
                    'If AppSettings.EnableVerboseLogging Then
                    '    Log("MessageID: " & m_strMessageID & " -- Filename: " & filename)
                    'End If
                End If

                Dim dblTemp As Double

                strSenderID = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDERUSERID)

                '-- extra check to see if the sender sent through email
                Dim strSenderFullName As String = String.Empty
                Dim strSenderAddress As String = String.Empty

                strSenderFullName = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDERFULLNAME)
                strSenderAddress = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDERADDRESS)

                xElement = m_xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_BODY)
                If xElement IsNot Nothing Then
                    Body = xElement.InnerText
                    Select Case xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FORMAT)
                        Case BODYFORMAT_PLAINTEXT
                            m_BodyFormat = EmailBodyFormatEnum.PlainText
                        Case BODYFORMAT_HTML
                            m_BodyFormat = EmailBodyFormatEnum.HTML
                        Case BODYFORMAT_PLAINTEXTANDHTML
                            m_BodyFormat = EmailBodyFormatEnum.MixedPainTextAndHTML
                        Case Else
                            m_BodyFormat = EmailBodyFormatEnum.HTML
                    End Select
                Else
                    Body = String.Empty
                    m_BodyFormat = EmailBodyFormatEnum.PlainText
                End If

                xElement = m_xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_TAGS)
                If xElement IsNot Nothing Then
                    Tags = xElement.InnerText
                Else
                    Tags = String.Empty
                End If

                Dim recip As RecipientEntry

                Dim intTotalRecipients As Integer
                Dim intReceivedRecipients As Integer
                Dim intViewedRecipients As Integer
                Dim strFullNameFromMessage As String
                Dim strAddressFromMessage As String

                If strSenderID.Length = 0 AndAlso strSenderFullName.Length = 0 AndAlso strSenderAddress.Length = 0 Then
                    '-- This message was sent or will be sent in the future
                    m_boolSent = True
                    strRecipientList = String.Empty

                    '-- Current user is the sender
                    m_Sender = New RecipientEntry(AddressBookEntryType.TrulyMail)
                    m_Sender.FullName = AppSettings.FullName
                    m_Sender.ID = String.Empty
                Else
                    '-- This message was received
                    m_boolSent = False

                    If strSenderID.Length = 0 Then
                        If AppSettings.EmailShowSenderAsSent Then
                            '-- do nothing, already have sender's name and address from message
                        Else
                            Dim entry As AddressBookEntry = ABook.GetContactByAddress(strSenderAddress) 'GetAddressBookEmailEntry(strSenderAddress)
                            If entry IsNot Nothing Then
                                strSenderFullName = entry.FullName
                            End If
                        End If

                        recip = New RecipientEntry(AddressBookEntryType.Email)
                        recip.FullName = strSenderFullName
                        recip.Address = strSenderAddress
                    Else
                        '-- Set the sender by building a recipent object (must be in address book)
                        recip = New RecipientEntry(ABook.GetContactByID(strSenderID)) 'GetAddressBookEntry(strSenderID))
                        If recip.FullName.Length = 0 Then
                            recip.FullName = strSenderFullName
                        End If

                        '-- The ID can be nothing if a user's address book does not have a certain
                        '   TrulyMail contact, usually when using on two different computers
                        '   and the address books get out of sync
                        If recip.ID Is Nothing Then
                            recip.ID = String.Empty
                        End If
                    End If

                    m_Sender = recip

                    m_dtMessageDateSent = dtSent
                End If

                '-- Get ReplyTo
                m_strReplyTo = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_EMAILREPLYTO)
                If m_strReplyTo.Length > 0 Then
                    If Not IsValidEmailAddress(m_strReplyTo) Then
                        '-- try to parse out the email address. 
                        '   The string might be something like "Network Solutions <NSCC4+2815466100@networksolutions.com>"
                        '   and we simply need the email address "NSCC4+2815466100@networksolutions.com"
                        Dim addr As New System.Net.Mail.MailAddress(m_strReplyTo)
                        m_strReplyTo = addr.Address
                    End If

                    If m_strReplyTo.ToLower() = Sender.Address.ToLower() Then
                        '-- The ReplyTo is not really a ReplyTo, it is just the sender's address
                        '   so remove it
                        m_strReplyTo = String.Empty
                    End If
                Else
                    m_strReplyTo = String.Empty
                End If

                '-- get TransportType (TrulyMail/Email)
                If Sent Then
                    '-- Get from recip's node
                    xList = m_xDoc.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_RECIPIENT)
                    Dim boolAtLeastOneEmail, boolAtLeastOneTrulyMail, boolAtLeastOneEncryptedEmail As Boolean
                    For Each xElement In xList
                        If xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_WEBMESSAGEPASSWORD).Trim.Length > 0 Then
                            boolAtLeastOneEncryptedEmail = True
                        ElseIf xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ADDRESS).Length > 0 AndAlso IsValidEmailAddress(xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ADDRESS)) Then
                            boolAtLeastOneEmail = True
                        Else
                            boolAtLeastOneTrulyMail = True
                        End If
                    Next

                    If Me.MessageType = Globals.MessageType.NoteToSelf Then
                        m_TransportType = MessageTransportType.InternalOnly
                    ElseIf boolAtLeastOneEmail AndAlso boolAtLeastOneTrulyMail Then
                        m_TransportType = MessageTransportType.Mixed
                    ElseIf boolAtLeastOneEmail AndAlso boolAtLeastOneEncryptedEmail Then
                        m_TransportType = MessageTransportType.Mixed
                    ElseIf boolAtLeastOneTrulyMail AndAlso boolAtLeastOneEncryptedEmail Then
                        m_TransportType = MessageTransportType.Mixed
                    ElseIf boolAtLeastOneEncryptedEmail Then
                        m_TransportType = MessageTransportType.EncryptedWebMessage
                    ElseIf boolAtLeastOneEmail Then
                        '-- If we get here, we have email, no TM
                        '   So check if encrypted flag is set
                        If Encrypted Then
                            m_TransportType = MessageTransportType.TM2TM
                        Else
                            m_TransportType = MessageTransportType.Email
                        End If
                    ElseIf boolAtLeastOneTrulyMail Then
                        m_TransportType = MessageTransportType.TrulyMail
                    Else
                        '-- assume TrulyMail
                        m_TransportType = MessageTransportType.TrulyMail
                    End If
                Else
                    '-- Get from DocumentElement
                    If m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_POPACCOUNT).Length > 0 Then
                        '-- If we get here, we have email
                        '   So check if encrypted flag is set
                        If Encrypted Then
                            m_TransportType = MessageTransportType.TM2TM
                        Else
                            m_TransportType = MessageTransportType.Email
                        End If

                        '-- also store POPProfile
                        Dim strPOPProfileID As String = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_POPACCOUNT)
                        For Each pop As POPProfile In AppSettings.POPProfiles
                            If pop.ID = strPOPProfileID Then
                                m_boolPOPProfile = pop
                                Exit For
                            End If
                        Next
                    Else
                        If MessageType = MessageType.RSSArticle Then
                            m_TransportType = MessageTransportType.RSS
                        ElseIf MessageType = MessageType.PageChangeNotice Then
                            m_TransportType = MessageTransportType.WebPageMonitor
                        Else
                            m_TransportType = MessageTransportType.TrulyMail
                        End If
                    End If
                End If

                '-- populate reference url
                If TransportType = MessageTransportType.RSS OrElse TransportType = MessageTransportType.WebPageMonitor Then
                    m_strReferenceURL = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_RSSLINK)
                End If

                Dim strRoleID As String
                Dim addressEntry As AddressBookEntry
                strXPath = "//" & MESSAGE_ATTRIBUTE_NAME_RECIPIENT
                xList = m_xDoc.SelectNodes(strXPath)
                Dim strTemp As String

                '=========================================================
                '-- Get the TrulyMail recipients
                For Each xElement In xList
                    strRecipientID = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_RECIPIENTID)
                    strFullNameFromMessage = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME)
                    strAddressFromMessage = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ADDRESS)
                    strRoleID = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID)

                    If strAddressFromMessage.Length > 0 AndAlso Not strAddressFromMessage.Contains("@") Then
                        If strRecipientID.Length = 0 Then
                            If Sent Then
                                '-- draft invitation
                                recip = New RecipientEntry(AddressBookEntryType.TrulyMail)
                                recip.FullName = strFullNameFromMessage
                            Else
                                '-- current user is recip
                                recip = New RecipientEntry(AddressBookEntryType.TrulyMail)
                                recip.FullName = AppSettings.FullName
                            End If
                        Else
                            '-- another trulymail user is the recip
                            Try
                                addressEntry = ABook.GetContactByID(strRecipientID) 'AddressBookEntry.LoadFromID(strRecipientID)
                                recip = New RecipientEntry(addressEntry)
                            Catch ex As Exception
                                addressEntry = Nothing
                            End Try
                        End If
                    Else
                        Try
                            If strRecipientID.Length = 0 Then
                                '-- sometimes email address go into recipient
                                addressEntry = ABook.GetContactByAddress(strAddressFromMessage) 'GetAddressBookEmailEntry(strAddressFromMessage)
                            Else
                                addressEntry = ABook.GetContactByID(strRecipientID) ' AddressBookEntry.LoadFromID(strRecipientID)
                            End If
                            If addressEntry IsNot Nothing Then
                                recip = New RecipientEntry(addressEntry)
                            End If
                        Catch ex As Exception
                            addressEntry = Nothing
                        End Try
                    End If

                    If addressEntry Is Nothing AndAlso recip Is Nothing Then
                        If strAddressFromMessage.Length > 0 AndAlso strAddressFromMessage.Contains("@") Then
                            recip = New RecipientEntry(AddressBookEntryType.Email)
                            recip.Address = strAddressFromMessage
                        Else
                            recip = New RecipientEntry(AddressBookEntryType.TrulyMail)
                        End If
                        recip.FullName = strFullNameFromMessage
                    End If

                    recip.RecipientType = GetRecipientTypeByRoleID(strRoleID)

                    Recipients.Add(recip)

                    If Sent Then
                        intTotalRecipients += 1
                        strTemp = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_RECEIVED)
                        If strTemp.Length > 0 Then
                            intReceivedRecipients += 1
                            recip.ReceivedDate = ConvertToDate(strTemp, #12:00:00 AM#)
                        End If
                        strTemp = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_READ)
                        If strTemp.Length > 0 Then
                            intViewedRecipients += 1
                            recip.ViewedDate = ConvertToDate(strTemp, #12:00:00 AM#)
                        End If
                    End If

                    recip = Nothing
                Next

                '=========================================================




                '-- Then get the email recipients
                xList = m_xDoc.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_ADDRESS)
                For Each xElement In xList
                    strFullNameFromMessage = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME)
                    strAddressFromMessage = xElement.InnerText
                    strRoleID = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID)

                    addressEntry = ABook.GetContactByAddress(strAddressFromMessage) 'GetAddressBookEmailEntry(strAddressFromMessage)
                    If addressEntry Is Nothing Then
                        recip = New RecipientEntry(AddressBookEntryType.Email)
                        recip.FullName = strFullNameFromMessage
                        recip.Address = strAddressFromMessage
                    Else
                        recip = New RecipientEntry(addressEntry)
                    End If

                    recip.RecipientType = GetRecipientTypeByRoleID(strRoleID)

                    Recipients.Add(recip)
                Next

                m_dtMessageDateSent = dtSent

                If Sent Then
                    Dim strSendAfterDate As String = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDAFTERDATE)
                    If strSendAfterDate.Length > 0 Then
                        MessageDateToSend = ConvertToLocalTime(Convert.ToDateTime(strSendAfterDate))
                    End If

                    Dim strUnsentDate As String = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_UNSENTDATE)
                    If strUnsentDate.Length > 0 Then
                        m_dtMessageDateUnsent = ConvertToLocalTime(Convert.ToDateTime(strUnsentDate))
                    End If

                    dblTemp = intReceivedRecipients / intTotalRecipients
                    If dblTemp < 0 OrElse dblTemp > 1 OrElse Double.IsNaN(dblTemp) Then
                        dblTemp = 0
                    End If
                    m_dblReceived = dblTemp

                    dblTemp = intViewedRecipients / intTotalRecipients
                    If dblTemp < 0 OrElse dblTemp > 1 OrElse Double.IsNaN(dblTemp) Then
                        dblTemp = 0
                    End If
                    m_dblViewed = dblTemp

                    strTemp = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_REQUESTRETURNRECEIPT)
                    m_boolReturnReceiptRequested = ConvertToBool(strTemp, False)
                End If

                '-- store the size
                m_intSize = Convert.ToInt32(strSize)

                '-- Has Notes?
                xElement = m_xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_NOTES)
                If xElement IsNot Nothing Then
                    m_strNotes = xElement.InnerText
                End If

                '-- get the info for the POP or SMTP profile
                If m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SMTPACCOUNT).Length > 0 Then
                    m_SMTPProfile = SMTPProfile.GetByID(m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SMTPACCOUNT))
                Else
                    m_SMTPProfile = Nothing
                End If

                '-- Load up the read receipt information
                strTemp = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_READRECEIPTSENT)
                m_dtDateReadReceiptSent = ConvertToDateFromXML(strTemp, DATE_NEVER)

            Else
                '-- there is no size so this message was partially downloaded
                '   If the file is more than 10 minutes old, delete it
                Try
                    Dim fi As New System.IO.FileInfo(filename)
                    Dim ts As TimeSpan = Date.Now - fi.LastWriteTime
                    If ts.TotalMinutes > 10 Then
                        DeleteLocalFile(filename)
                    End If
                Catch ex As Exception
                    Log(ex)
                End Try
                Exit Sub
            End If

            SetOtherParties()


        Catch ex As Exception
            Log(ex)
            Log("Problem filename: " & filename)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Saves message back to original filename
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()
        Dim intErrorLocation As Integer
        Try
            '-- Update filesize
            Dim lngSizeOfAllAttachments As Long
            If m_lstAttachments IsNot Nothing Then
                For Each item As AttachmentItem In m_lstAttachments
                    lngSizeOfAllAttachments += item.FileSize
                Next
            End If
            intErrorLocation = 1
            m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGESIZE, m_xDoc.OuterXml.Length + lngSizeOfAllAttachments)
            intErrorLocation = 2
            If AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypted OrElse AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypting Then
                intErrorLocation = 3
                '-- encrypt the xml then save it
                Dim strXML As String = m_xDoc.OuterXml
                Dim strEncryptedXML As String = Crypto.EncryptTextSymetric(AppSettings.GetFileEncryptionPassword, strXML, EncryptionLevelEnum.Version5Fast) '-- Needs to be fast (very important)
                intErrorLocation = 4
                If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(Filename)) Then
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Filename))
                End If
                intErrorLocation = 5
                System.IO.File.WriteAllText(Filename, strEncryptedXML)
            Else
                '-- must be decrypted or decrypting so save decrypted
                '-- Just save the xml directly
                intErrorLocation = 10
                m_xDoc.Save(Filename)
            End If
        Catch ex As Exception
            Log(ex)
            Log("Error section: " & intErrorLocation.ToString())
            ShowMessageBoxError("There was an error saving one of your messages." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub


    ''' <summary>
    ''' Returns true if according to all settings message should have remote images blocked
    ''' </summary>
    ''' <param name="messageFilename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ShouldBlockRemoteImages() As Boolean
        Dim boolBlockRemoteImages As Boolean = AppSettings.BlockRemoteImages
        Dim boolCheckRemoteImageSettings As Boolean = True
        Dim boolRSSArticle As Boolean
        Dim strSenderName As String = String.Empty

        '-- If the message says to show remote images, then we do not need to check settings, just show remote images
        Dim strShowRemoteImages As String = m_xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SHOWREMOTEIMAGES)
        If strShowRemoteImages.Length > 0 Then
            boolBlockRemoteImages = Not Convert.ToBoolean(strShowRemoteImages)
            boolCheckRemoteImageSettings = False
        End If

        If boolCheckRemoteImageSettings Then
            Dim boolMessageWasReceived As Boolean
            Dim entry As AddressBookEntry

            If Sent Then
                '-- no need to block on sent messages
                boolBlockRemoteImages = False
            Else
                If boolRSSArticle Then
                    If AppSettings.RSSSenderAllowRemoteImages.ContainsKey(Sender.FullName.ToLower()) Then
                        boolBlockRemoteImages = False
                    Else
                        boolBlockRemoteImages = AppSettings.BlockRemoteImages
                    End If
                Else
                    If Sender Is Nothing Then
                        '-- sender not in address book
                        boolBlockRemoteImages = AppSettings.BlockRemoteImages
                    ElseIf Sender.ID.Length > 0 Then
                        entry = ABook.GetContactByID(Sender.ID)
                        If entry Is Nothing Then
                            boolBlockRemoteImages = AppSettings.BlockRemoteImages
                        Else
                            boolBlockRemoteImages = Not entry.RemoteImages '-- setting to show remote images
                        End If
                    ElseIf Sender.Address.Length > 0 Then
                        entry = ABook.GetContactByAddress(Sender.Address)
                        If entry Is Nothing Then
                            boolBlockRemoteImages = AppSettings.BlockRemoteImages
                        Else
                            boolBlockRemoteImages = Not entry.RemoteImages '-- setting to show remote images
                        End If
                    End If
                End If
            End If
        End If

        Return boolBlockRemoteImages
    End Function
#Region " Shared methods "
    ''' <summary>
    ''' Will return true if message is unread but will not fully load the message (just peek at it)
    ''' </summary>
    ''' <param name="fileInfo"></param>
    ''' <param name="justCountToday"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PeekIsUnread(fileInfo As System.IO.FileInfo, justCountToday As Boolean) As Boolean
        '-- A quick way to see if a message is read or not without a full xml load
        Dim xDocMessage As New Xml.XmlDocument()
        Dim boolRead As Boolean
        Try
            xDocMessage = LoadMessageFromFile(fileInfo.FullName)
            If justCountToday Then
                '-- This is the outbox so everything is unread
                '   but everything in this case excludes messages scheduled to be sent after today (sending delayed past upcoming midnight)
                Dim strSendAfterDate As String = xDocMessage.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDAFTERDATE)
                Dim dt As Date = ConvertToDateFromXML(strSendAfterDate, Date.MinValue)
                If dt.Date > Date.UtcNow.Date Then
                    boolRead = True
                Else
                    boolRead = False
                End If
            Else
                Dim strRead As String = xDocMessage.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_READ)
                If strRead.Length = 0 Then
                    boolRead = False
                Else
                    boolRead = ConvertToBool(strRead, False)
                End If
            End If

            If Not boolRead Then
                '-- messages without sizes were not downloaded completely
                Dim strSize As String = xDocMessage.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGESIZE)
                If strSize.Length = 0 Then
                    boolRead = False
                End If
            End If

            Return Not boolRead '-- must flip to unread
        Catch ex As System.Xml.XmlException
            '-- badly formed xml, check file date and delete (to trash) if older than one day
            If fileInfo.LastWriteTime < Date.Now.AddDays(-1) Then
                Log("Malformed XML. Deleting old file: " & fileInfo.FullName)
                DeleteLocalMessage(fileInfo.FullName, False, False)
            End If
            Return False
        Catch ex As Exception
            '-- problem reading file
            Log(ex)
            Log("Filename: " & fileInfo.FullName)

            Return False
        End Try
    End Function
    ''' <summary>
    ''' Will convert from encrypted to decrypted or the opposite, depending on fileencryption settings
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <remarks></remarks>
    Public Shared Sub QuickConvert(filename As String)
        Try
            '-- First load the file 
            Dim xDoc As Xml.XmlDocument = LoadMessageFromFile(filename)

            Dim lstToDeleteAfterSave As New List(Of String)

            '-- If there are any attachments then we must encrypt/decrypt the attachments and update the .tmm file
            Dim xList As Xml.XmlNodeList = xDoc.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_ATTACHMENT)
            Dim strUnencryptedFilename, strEncryptedFilename, strTempFilename As String

            If AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypted OrElse AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypting Then
                '-- Now we loop through all attachments, encrypt the attachment, set the encryptedfilename, update the message, delete the unencrypted attachment

                For Each xElement As Xml.XmlElement In xList
                    strUnencryptedFilename = QualifyPath(AttachmentsRootPath) & System.IO.Path.GetFileNameWithoutExtension(filename) & "\" & xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME)
                    If System.IO.File.Exists(strUnencryptedFilename) Then
                        strTempFilename = System.IO.Path.GetFileName(GetTempFilename(".encrypted"))
                        strEncryptedFilename = QualifyPath(AttachmentsRootPath) & System.IO.Path.GetFileNameWithoutExtension(filename) & "\" & strTempFilename
                        xElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDFILENAME, System.IO.Path.GetFileName(strEncryptedFilename)) '-- Set encrypted filename in .tmm file 
                        lstToDeleteAfterSave.Add(strUnencryptedFilename) '-- Should only delete the unencrypted file after saving the encrypted .tmm file, in case computer crashes mid-routine
                        EncryptFile(AppSettings.GetFileEncryptionPassword, strUnencryptedFilename, 1, strEncryptedFilename)
                    Else
                        '-- File was not there, just log and continue
                        Log("Attachment not found for encryption: " & strUnencryptedFilename)
                    End If
                Next
            Else
                '-- must be decrypting or decrypted, either way, we remove the file encryption
                '-- Now we loop through all attachments, decrypt the attachment, remove the encryptedfilename, update the message, delete the encrypted attachment

                For Each xElement As Xml.XmlElement In xList
                    strEncryptedFilename = QualifyPath(AttachmentsRootPath) & System.IO.Path.GetFileNameWithoutExtension(filename) & "\" & xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDFILENAME)
                    If System.IO.File.Exists(strEncryptedFilename) Then
                        strUnencryptedFilename = QualifyPath(AttachmentsRootPath) & System.IO.Path.GetFileNameWithoutExtension(filename) & "\" & xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME)
                        xElement.RemoveAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDFILENAME) '-- clear encrypted filename in .tmm file 
                        lstToDeleteAfterSave.Add(strEncryptedFilename) '-- Should only delete the unencrypted file after saving the encrypted .tmm file, in case computer crashes mid-routine
                        DecryptFile1(AppSettings.GetFileEncryptionPassword, strEncryptedFilename, strUnencryptedFilename)
                    Else
                        '-- File was not there, just log and continue
                        Log("Attachment not found for decryption: " & strEncryptedFilename)
                    End If
                Next
            End If


            '-- Then save the file (encrypted or not)
            If AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypted OrElse AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypting Then
                '-- encrypt the xml then save it
                Dim strXML As String = xDoc.OuterXml
                Dim strEncryptedXML As String = Crypto.EncryptTextSymetric(AppSettings.GetFileEncryptionPassword, strXML, EncryptionLevelEnum.Version5Fast) '-- needs to be fast (Fast=660ms; Strong=740ms)
                System.IO.File.WriteAllText(filename, strEncryptedXML, System.Text.Encoding.Unicode)
            Else
                '-- must be decrypted or decrypting so save decrypted
                '-- Just save the xml directly
                xDoc.Save(filename)
            End If

            For Each strFilename As String In lstToDeleteAfterSave
                '-- Do not raise error if cannot delete
                Try
                    DeleteLocalFile(strFilename)
                Catch ex As Exception
                    '-- Perhaps could not delete
                    '   Log it and move on
                    Log("Error: Could not remove file during encryption/decryption QuickConvert: " & strFilename)
                End Try
            Next
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

#End Region

    Private m_lstEmailHeaders As List(Of NameValuePair)
    Public ReadOnly Property EmailHeaders As List(Of NameValuePair)
        Get
            If m_lstEmailHeaders Is Nothing Then
                LoadEmailHeaders()
            End If

            Return m_lstEmailHeaders
        End Get
    End Property
#Region " Read receipt stuff "
    ''' <summary>
    ''' Returns the email address (test@some.com) the sender wants the read receipt to go to. If the sender is not request a read receipt (or if the address is not valid) a zero-lenth string will be returned
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SendReadReceiptToAddress As String
        Get
            Dim strReturnReceiptToAddress As String = String.Empty '-- return blank if there is no receipt requested
            Try
                Dim lstHeaders As List(Of NameValuePair) = EmailHeaders
                For Each obj As NameValuePair In lstHeaders
                    '-- Check headers for both standards
                    If obj.Name.ToLower() = EMAIL_RETURN_RECEIPT_REQUEST_HEADER_NAME_1.ToLower() _
                        OrElse obj.Name.ToLower() = EMAIL_RETURN_RECEIPT_REQUEST_HEADER_NAME_2.ToLower() Then

                        '-- can be in this format: "John M. Andre" <John@TrulyMail.com>
                        Dim strReturnEmailAddress As String = obj.Value
                        If IsValidEmailAddress(strReturnEmailAddress) Then
                            '-- straight address (John@TrulyMail.com)
                            strReturnReceiptToAddress = strReturnEmailAddress
                        Else
                            '-- Complex address with name and address
                            Dim addr As New System.Net.Mail.MailAddress(strReturnEmailAddress)
                            If IsValidEmailAddress(addr.Address) Then
                                strReturnReceiptToAddress = addr.Address
                            Else
                                Log("Return Address Invalid: " & strReturnEmailAddress)
                                strReturnReceiptToAddress = String.Empty
                            End If
                        End If
                        Exit For
                    End If
                Next
                Return strReturnReceiptToAddress
            Catch ex As Exception
                Log(ex)
                Return String.Empty
            End Try
        End Get
    End Property
    ''' <summary>
    ''' Sends a read receipt regardless of whether sender requested one
    ''' </summary>
    ''' <param name="sendManually">False if we are sending automatically, true if user chose to send it</param>
    ''' <remarks></remarks>
    Public Sub SendReadReceipt(sendManually As Boolean)
        '-- We will send a read receipt to the read receipt address
        '   if that address is missing we will send to the sender
        '-- This routine is only for received msgs
        Try
            If Me.Sent Then
                '-- do nothing
            Else
                'todo: Complete SendReturnReceipt
                Dim strReturnReceiptToAddress As String = SendReadReceiptToAddress
                If Not IsValidEmailAddress(strReturnReceiptToAddress) Then
                    '-- If there is no read receipt address, then just use the sender's address
                    strReturnReceiptToAddress = Me.Sender.Address
                End If
                SendEmailReadReceipt(Me.Filename, strReturnReceiptToAddress, sendManually)
                ReadReceiptSent = Date.UtcNow

                '-- Add note to msg
                If AppSettings.AddNoteWhenSendingReturnReceipt Then
                    Notes &= Date.Today & "   " & "Sent read receipt to " & strReturnReceiptToAddress
                    If sendManually Then
                        Notes &= " (manually)" & Environment.NewLine()
                    Else
                        Notes &= " (automatically)" & Environment.NewLine()
                    End If
                    Notes &= Environment.NewLine() & Environment.NewLine()
                End If
                Me.Save() '-- must persist the receipt sent date
            End If

        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private m_dtDateReadReceiptSent As Date = DATE_NEVER '-- populated in load and the property setter below
    ''' <summary>
    ''' Returns the most receipt date the read receipt was sent
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReadReceiptSent As Date
        Get
            Return m_dtDateReadReceiptSent
        End Get
        Private Set(value As Date)
            m_dtDateReadReceiptSent = value
            m_xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_READRECEIPTSENT, value.ToString(DATEFORMAT_XML))
            m_boolShouldPromptToSendReadReceipt = False
        End Set
    End Property
    Private m_boolShouldPromptToSendReadReceipt As Boolean '-- This gets set when me.read is set to true, the first time
    Public Property ShouldPromptToSendReadReceipt As Boolean
        Get
            If Me.Sent Then
                Return False '-- this routine is just for received msgs
            Else
                Return m_boolShouldPromptToSendReadReceipt
            End If
        End Get
        Set(value As Boolean)
            '-- Callers decide to send return receipt or not
            '   even if they choose not to, they must turn this prompt off
            '   To remember, we will simply record this having sent the receipt
            '   even if we never sent the receipt
            ReadReceiptSent = Date.UtcNow()
        End Set
    End Property
#End Region
    Public Function AddEmailHeader(name As String, value As String) As NameValuePair
        If m_lstEmailHeaders Is Nothing Then
            LoadEmailHeaders()
        End If

        Dim item As New NameValuePair
        item.Name = name
        item.Value = value

        m_lstEmailHeaders.Add(item)

        '-- Update XML
        Dim xHeaders As Xml.XmlElement = m_xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_HEADERS)
        If xHeaders Is Nothing Then
            xHeaders = m_xDoc.DocumentElement.AppendChild(m_xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_HEADERS))
        End If

        Dim xHeader As Xml.XmlElement = xHeaders.AppendChild(m_xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_HEADER))
        xHeader.SetAttribute(MESSAGE_ATTRIBUTE_NAME_NAME, name)
        xHeader.InnerText = value

    End Function
    Private Sub LoadEmailHeaders()
        m_lstEmailHeaders = New List(Of NameValuePair)

        Dim item As NameValuePair
        Dim xList As Xml.XmlNodeList = m_xDoc.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_HEADER)
        For Each xElement As Xml.XmlElement In xList
            item = New NameValuePair
            item.Name = xElement.GetAttribute("Name")
            item.Value = xElement.InnerText
            m_lstEmailHeaders.Add(item)
        Next
    End Sub

    Public Sub RemoveNotes()
        Me.Notes = String.Empty
    End Sub
    Public Function IsReadReceipt() As Boolean
        '-- best guess only

        '-- Now try to find the most appropriate messages
        '   If there is an MDNPart3.txt that is ideal as it 
        '   is a very specific filename

        Dim lst As List(Of AttachmentItem) = Me.Attachments
        Dim strMDNPart3Filename As String = String.Empty
        For Each item As AttachmentItem In lst
            If item.DisplayName.ToLower = "mdnpart3.txt" Then
                '-- Good news
                Return True
            End If
        Next


        '-- if we got here then we do not have MDNPart3.txt
        '   All we have that we can depend on is the 
        '   recip's address in the body of the message and 
        '   the subject from the subject of this message

        '-- First, let's get the original subject
        Dim strOriginalSubject As String = String.Empty
        Dim boolEndsWithMatching As Boolean '-- True for outlook receipts since they remove leading 'Re:' and 'Fwd:'
        If Subject.ToLower.StartsWith(READ_RECEIPT_READ_ENGLISH) Then '-- Outlook, Outlook Express
            boolEndsWithMatching = True '-- Outlook can send a read receipt to "Re: Something" as "READ: Something" so we must match using string.EndsWith
        ElseIf Subject.ToLower.StartsWith(READ_RECEIPT_READ_ENGLISH_THUNDERBIRD_TRULYMAIL) Then '-- Thunderbird, TrulyMail
            boolEndsWithMatching = False
        ElseIf Subject.ToLower.StartsWith(READ_RECEIPT_READ_SPANISH) Then '-- outlook in Spanish
            boolEndsWithMatching = True '-- Outlook can send a read receipt to "Re: Something" as "READ: Something" so we must match using string.EndsWith
        ElseIf Subject.ToLower.StartsWith(READ_RECEIPT_READ_DUTCH) Then '-- outlook in dutch
            boolEndsWithMatching = True '-- Outlook can send a read receipt to "Re: Something" as "READ: Something" so we must match using string.EndsWith
        ElseIf Subject.ToLower.StartsWith(READ_RECEIPT_RECEIVED_DUTCH) Then '-- outlook in dutch
            boolEndsWithMatching = True '-- DreamMail does not return and id of the original message
        ElseIf Subject.ToLower.StartsWith(READ_RECEIPT_RECEIPT_ENGLISH) Then '-- outlook in dutch
            boolEndsWithMatching = True '-- DreamMail does not return and id of the original message
        End If

        Return boolEndsWithMatching

    End Function
End Class

