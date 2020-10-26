Friend Class MessageTransmitter

#Region " Module-level stuff "
    Friend Enum CancelReasonEnum
        NotCanceled '-- default value
        ServerError '-- stop all processing because there is an error communicating with the server
        MessageError '-- wrong invite address, cannot add recip, etc. (stop processing this message, continue others)
        CallerCanceled '-- stop all processing because user said so
    End Enum

    Private WithEvents bkw As New System.ComponentModel.BackgroundWorker()
    Private m_recipients As New List(Of RecipientEntry)
    Private m_strSubject As String
    Private m_strBody As String
    Private m_lstAttachments As New List(Of String)
    Private m_messageType As MessageType
    Private m_boolCanceled As Boolean
    Private m_exception As Exception
    Private m_smtpAccount As SMTPProfile '-- for errors
    Private m_strRecentFilename As String = String.Empty
    Private m_htImages As New Hashtable() '-- src / new relative path

    Friend CancelReason As CancelReasonEnum
    Friend Event Sent()
    Friend Event Progress(ByVal progress As Double, ByVal status As String)
    Friend Event Canceled()
#End Region
    Friend ReadOnly Property SMTPAccount As SMTPProfile
        Get
            Return m_smtpAccount
        End Get
    End Property
    Friend ReadOnly Property Exception() As Exception
        Get
            Return m_exception
        End Get
    End Property
    Friend Sub Cancel()
        m_boolCanceled = True
    End Sub


    ''' <summary>
    ''' Sends an unsent message or returns false
    ''' </summary>
    ''' <param name="filename">Filename of unsent message to send</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function SendMessage(ByVal filename As String) As Boolean
        If Not BusySendingMessage Then
            Dim xDoc As New Xml.XmlDocument()
            xDoc.Load(filename)
            Dim strSendAfter As String = xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDAFTERDATE)
            Dim dtWhenToSend As Date
            If strSendAfter.Length > 0 Then
                dtWhenToSend = ConvertToDateFromXML(strSendAfter, Date.UtcNow)
            Else
                '-- no date specified, just send now
                dtWhenToSend = Date.UtcNow
            End If

            '-- logic to send delayed messages on shut down
            If ShuttingDown Then
                '-- remove the number of minutes we added when sending, then see if the date is good to send
                dtWhenToSend = dtWhenToSend.AddMinutes(AppSettings.SendNowDelay * -1)
            End If

            If dtWhenToSend <= Date.UtcNow Then
                '-- Ensure we do not try to send two messages at once
                BusySendingMessage = True
                m_boolCanceled = False
                bkw.RunWorkerAsync(filename)
                m_strRecentFilename = filename
                Return True
            Else
                Return False '-- false means message will not be sent now
            End If
        Else
            '-- Should not send more than one message at a time
            Return False '-- false means message will not be sent now
        End If
    End Function
    Private Sub bkw_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bkw.DoWork
        '-- Read unsent file and send message
        Dim strFilename As String = CType(e.Argument, String)
        Dim xDoc As New Xml.XmlDocument()
        xDoc.Load(strFilename)
        Dim strMessageTypeID As String = xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGETYPEID)
        Select Case strMessageTypeID
            '-- Changing in v 5.0 since no more server communication
            '   Changing to delete bad filetypes
            Case MESSAGETYPE_COMMUNICATION
                '-- Introduce delay for newsletter mode (we're on a background thread so should not impact the UI)
                If AppSettings.IntraEmailSendDelay > 0 AndAlso IsNewsletterMode(strFilename) Then
                    Application.DoEvents()
                    Threading.Thread.Sleep(AppSettings.IntraEmailSendDelay * 1000)
                End If

                SendCommunication(strFilename)
            Case Else
                Application.DoEvents() '-- for breakpoint
        End Select
    End Sub
    Private Sub bkw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bkw.RunWorkerCompleted
        BusySendingMessage = False

        If Not m_boolCanceled Then
            RaiseEvent Sent()
        End If
    End Sub
    Private Sub SendCommunicationEmail(ByVal filename As String)
        'Dim boolEncrypt As Boolean
        Dim emailEncryption As EncryptedEmailType

        Dim xDoc As New Xml.XmlDocument()
        xDoc.Load(filename)
        emailEncryption = [Enum].Parse(GetType(EncryptedEmailType), xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDEMAILTYPE))
        'Dim xList As Xml.XmlNodeList = xDoc.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_RECIPIENT)
        'For Each xElement As Xml.XmlElement In xList
        '    If xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ADDRESS).Length > 0 Then
        '        '-- for communication type messages, only email recipients have addresses
        '        boolEncrypt = ConvertToBool(xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTED), False)
        '        Exit For '-- if one is encrypted then assume they all are
        '    End If
        'Next

        Try
            SendCommunicationEmail(filename, emailEncryption)
        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Sub

    Private Sub OnEhlo(sender As Object, e As aspNetEmail.SmtpServerResponseEventArgs)
        '-- This really should be part of the aspnetemail component, but it is not, so we do it here
        If e.SmtpState = aspNetEmail.SmtpState.Ehlo Then
            Dim msg As aspNetEmail.EmailMessage = CType(sender, aspNetEmail.EmailMessage)
            Dim resp As String = e.Response.ToLower()

            Dim sr As New System.IO.StringReader(resp)
            Dim strLine As String

            strLine = sr.ReadLine()
            Do While Not (strLine Is Nothing)
                Console.WriteLine(strLine)
                If strLine.StartsWith("250-auth") Then
                    '-- found our authentication line
                    If strLine.IndexOf("login") > -1 Then
                        msg.SmtpAuthentication = aspNetEmail.SmtpAuthentication.AuthLogin
                    ElseIf strLine.IndexOf("cram-md5") > -1 Then
                        msg.SmtpAuthentication = aspNetEmail.SmtpAuthentication.CramMD5
                    ElseIf strLine.IndexOf("plain") > -1 Then
                        msg.SmtpAuthentication = aspNetEmail.SmtpAuthentication.AuthPlain
                    ElseIf strLine.IndexOf("xoauth") > -1 Then
                        Log("Email server requires xoath support: " & strLine & " --- Server: " & msg.Server)
                        'msg.SmtpAuthentication = aspNetEmail.SmtpAuthentication.AuthPlain
                        msg.SmtpAuthentication = aspNetEmail.SmtpAuthentication.OAuth
                        'msg.OAuthString = "yyy"
                    ElseIf strLine.IndexOf("ntlm") > -1 Then
                        Log("Email server requires NTLM support: " & strLine & " --- Server: " & msg.Server)
                        msg.SmtpAuthentication = aspNetEmail.SmtpAuthentication.AuthPlain
                        'msg.SmtpAuthentication = aspNetEmail.SmtpAuthentication.Ntlm
                        'msg.Ntlm.Hostname '-- many properties to set here.
                    Else
                        msg.SmtpAuthentication = aspNetEmail.SmtpAuthentication.AuthPlain
                    End If
                End If
                strLine = sr.ReadLine()
            Loop
        End If
    End Sub
    Private Sub SendCommunicationEmail(ByVal filename As String, ByVal emailEncryption As EncryptedEmailType)
        '-- If encrypted, then
        '   Change out the body for a generic body telling user to download TrulyMail
        '   Remove any attachments since they are in the TrulyPrivate file
        '   Package up the TrulyPrivate file and attach it
        '   Transmit the cypher key to the TrulyMail server

        Dim strCurrentStep As String
        Dim intErrorSection As Integer

        Try

            Select Case emailEncryption
                Case EncryptedEmailType.ClearText
                    strCurrentStep = "Preparing unencrypted email"
                Case EncryptedEmailType.EncrypedTM2TMEmail
                    strCurrentStep = "Preparing encrypted email"
            End Select

            RaiseEvent Progress(0.33, strCurrentStep)
            '-- Check to see if caller canceled
            If m_boolCanceled Then
                CancelReason = CancelReasonEnum.CallerCanceled
                RaiseEvent Canceled()
                m_boolCanceled = True
                Exit Sub
            End If

            intErrorSection = 1

            Dim xDocFromFile As New Xml.XmlDocument
            xDocFromFile.Load(filename)

            Dim strMessageID As String = xDocFromFile.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGEID)

            intErrorSection = 2

            Dim strSubject, strBody As String
            Dim xElement As Xml.XmlElement = xDocFromFile.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_SUBJECT)
            strSubject = xElement.InnerText
            Dim msg As aspNetEmail.EmailMessage
            Dim msgutility As aspNetEmail.HtmlUtility
            Dim smtp As SMTPProfile

            intErrorSection = 3

            Dim strSMTPID As String = xDocFromFile.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SMTPACCOUNT)
            smtp = SMTPProfile.GetByID(strSMTPID)
            If smtp Is Nothing Then
                ShowMessageBoxError("Email recipients on the sending message cannot be sent because the outbound account cannot be identified." & _
                                Environment.NewLine & Environment.NewLine & _
                                "Please open the message in your outbox and send again.")
                m_boolCanceled = True
                CancelReason = CancelReasonEnum.CallerCanceled
                RaiseEvent Canceled()
                Exit Sub
            End If

            Dim strLicense As String = My.Resources.aspnetemail_xml_lic
            aspNetEmail.EmailMessage.LoadLicenseString(strLicense)
            msg = New aspNetEmail.EmailMessage() ' System.Net.Mail.MailMessage()

            '-- wire up Ehlo event
            AddHandler msg.SmtpServerResponse, AddressOf OnEhlo
            'msg.From=New System.Net.Mail.MailAddress(smtp.DisplayEmail, smtp.DisplayName)

            'msg.Logging = True
            'msg.LogPath = "C:\Users\John\Documents\Visual Studio 2010\Projects\TrulyMail\TrulyMailClient\bin\x86\Data\Profile\Messages\Sent Items\emaillog.txt"


            msgutility = New aspNetEmail.HtmlUtility(msg)
            msgutility.EmbedImageOption = aspNetEmail.EmbedImageOption.ContentId
            msgutility.Render(aspNetEmail.EmbedImageOption.ContentId)

            msg.FromAddress = smtp.DisplayEmail
            msg.FromName = smtp.DisplayName

            intErrorSection = 4

            '-- Cypher key must not be attachment key
            '   because server can never have attachment key and attachments
            Dim strCypherKey As String = GenerateAlphanumericString(ATTACHMENT_ENCRYPTION_KEY_LENGTH)
            xElement = xDocFromFile.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_ATTACHMENTS)

            intErrorSection = 5

            xElement = xDocFromFile.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_BODY)
            xDocFromFile.PreserveWhitespace = True '-- don't want CRLF's to be lost for plain text
            strBody = xElement.InnerText

            intErrorSection = 6

            '---------------------------------
            '-- TODO: setup plaintext alternateview
            '-- Include plaintext and HTML in 
            '   every email (sloppy, I know)
            '---------------------------------
            'Dim strPlainText As String = StripHTML(strBody)
            'Dim avPlainText As System.Net.Mail.AlternateView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(strPlainText, System.Text.Encoding.UTF8, System.Net.Mime.MediaTypeNames.Text.Plain)
            'msg.AlternateViews.Add(avPlainText)

            '-- Adding both because of standards issues
            msg.AddHeader(EMAIL_MAILER_HEADER_NAME_1, "TrulyMail " & Application.ProductVersion)
            msg.AddHeader(EMAIL_MAILER_HEADER_NAME_2, "TrulyMail " & Application.ProductVersion)
            'msg.Headers.Add(EMAIL_MAILER_HEADER_NAME_1, "TrulyMail " & Application.ProductVersion)
            'msg.Headers.Add(EMAIL_MAILER_HEADER_NAME_2, "TrulyMail " & Application.ProductVersion)

            '-- Some email clients can put CRLF in subject line and us replying to that will crash 
            '   when we set msg.Subject
            strSubject = strSubject.Replace(Chr(10), " ") 'cr
            strSubject = strSubject.Replace(Chr(13), " ") 'lf

            intErrorSection = 7

            msg.Subject = strSubject
            msg.Headers.Add("TrulyMail-ID", strMessageID)
            'msg.SubjectEncoding = System.Text.Encoding.UTF8
            msg.HeaderEncoding = aspNetEmail.MailEncoding.Base64

            intErrorSection = 8

            Try
                '-- If specified, add the return receipt header
                If Convert.ToBoolean(xDocFromFile.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_REQUESTRETURNRECEIPT)) Then
                    msg.Headers.Add(EMAIL_RETURN_RECEIPT_REQUEST_HEADER_NAME_1, smtp.DisplayEmail)
                End If
            Catch ex As Exception
                '-- ignore errors here
            End Try

            intErrorSection = 9

            Dim xList As Xml.XmlNodeList
            xList = xDocFromFile.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_ATTACHMENT)
            'System.IO.File.AppendAllText("C:\Users\John\Documents\Visual Studio 2008\Projects\TrulyMail\TrulyMailClient\bin\x86\test1.txt", strBody)

            intErrorSection = 10

            Dim boolPlainText As Boolean
            Select Case xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FORMAT) '-- body element
                Case BODYFORMAT_PLAINTEXT
                    '-- no need to do anything because the html was already stripped off
                    boolPlainText = True
                Case BODYFORMAT_PLAINTEXTANDHTML
                    strBody = StripHTML(strBody, False)
                    boolPlainText = True
                Case Else
                    '-- default to HTML (no need to change body content), unless it is a return receipt
                    If msg.Subject.StartsWith(RETURN_RECEIPT_SUBJECT) AndAlso xList.Count = 2 Then '-- attachments list
                        '-- We can assume this is a return receipt, so just send as text
                        boolPlainText = True
                    Else
                        boolPlainText = False
                        '-- to support Outlook Express (old but people still use), we must remove the contenteditable attribute
                        strBody = RemoveContentEditableAttribute(strBody)
                    End If
            End Select
            'System.IO.File.AppendAllText("C:\Users\John\Documents\Visual Studio 2008\Projects\TrulyMail\TrulyMailClient\bin\x86\test2.txt", strBody)

            intErrorSection = 11

            Dim strEncryptedBody As String
            Dim xDocExternalMessage As Xml.XmlDocument


            ''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''
            '''      ATTACHMENTS                    ''''''
            ''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''


            Dim strTempTM2TMZipFilename As String

            Dim strTM2TMEncryptionKey As String
            If emailEncryption = EncryptedEmailType.EncrypedTM2TMEmail Then
                strTM2TMEncryptionKey = xDocFromFile.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_TM2TMPASSWORD)
            End If

            Dim strFilename As String

            Select Case emailEncryption
                Case EncryptedEmailType.ClearText
                    intErrorSection = 12

                    'msg.IsBodyHtml = Not boolPlainText
                    'msg.Body = strBody
                    'msg.BodyEncoding = System.Text.Encoding.UTF8

                    Dim boolZipAllAttachments As Boolean = ConvertToBool(xDocFromFile.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ZIPATTACHMENTS), False)
                    If boolPlainText Then
                        '-- plain text
                        intErrorSection = 13
                        msg.BodyFormat = aspNetEmail.MailFormat.Text
                        If boolZipAllAttachments Then
                            '-- Add all attachments into a randomly named zip file and attach that zip file
                            Dim strZipFilename As String
                            Using zip As New Ionic.Zip.ZipFile()
                                intErrorSection = 14
                                For Each xElement In xList '-- attachments list
                                    strFilename = AttachmentsRootPath & strMessageID & "\" & xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME)
                                    zip.AddFile(strFilename, String.Empty)
                                Next
                                strZipFilename = GetTempFilename(".zip")
                                zip.Save(strZipFilename)
                            End Using

                            msg.AddAttachment(strZipFilename)
                        Else
                            intErrorSection = 15

                            '-- Just add all attachments directly to message
                            For Each xElement In xList '-- attachments list
                                strFilename = AttachmentsRootPath & strMessageID & "\" & xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME)
                                'msg.Attachments.Add(New System.Net.Mail.Attachment(strFilename))
                                msg.AddAttachment(strFilename)
                            Next
                        End If
                    Else
                        '-- html
                        intErrorSection = 16

                        msg.BodyFormat = aspNetEmail.MailFormat.Html
                        If boolZipAllAttachments Then
                            '-- Add all attachments into a randomly named zip file and attach that zip file
                            intErrorSection = 17
                            Dim strZipFilename As String
                            Using zip As New Ionic.Zip.ZipFile()
                                intErrorSection = 18
                                For Each xElement In xList '-- attachments list
                                    Dim strNameOfFile As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME)
                                    strFilename = AttachmentsRootPath & strMessageID & "\" & xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME)
                                    If strNameOfFile.ToLower.StartsWith(IMAGES_EMBEDDED_FOLDER.ToLower) Then
                                        '-- embeded
                                        Dim strContentID As String = Guid.NewGuid.ToString()
                                        intErrorSection = 19
                                        '-- Now replace the <img src= tag with its cid value
                                        Dim strSearchFor As String = "IMG src=""" & ATTACHMENTS_FOLDER_REPLACEMENT_CODE & strMessageID & "\" & strNameOfFile & """"
                                        Dim strReplacement As String = "IMG src=""" & EMAIL_CONTENTID_CODE & strContentID & """"
                                        strBody = strBody.Replace(strSearchFor, strReplacement)
                                        msg.EmbedImage(strContentID, strFilename)
                                    Else
                                        '-- just attached 
                                        'msg.Attachments.Add(New System.Net.Mail.Attachment(strFilename))
                                        intErrorSection = 20
                                        zip.AddFile(strFilename, String.Empty)
                                    End If
                                Next

                                intErrorSection = 21
                                strZipFilename = GetTempFilename(".zip")
                                zip.Save(strZipFilename)
                            End Using

                            intErrorSection = 22

                            msg.AddAttachment(strZipFilename)

                            intErrorSection = 23
                        Else
                            '-- Just add all attachments directly to message
                            intErrorSection = 24
                            For Each xElement In xList '-- attachments list
                                Dim strNameOfFile As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME)
                                strFilename = AttachmentsRootPath & strMessageID & "\" & xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME)
                                If strNameOfFile.ToLower.StartsWith(IMAGES_EMBEDDED_FOLDER.ToLower) Then
                                    '-- embeded
                                    Dim strContentID As String = Guid.NewGuid.ToString()

                                    intErrorSection = 25

                                    '-- Now replace the <img src= tag with its cid value
                                    Dim strSearchFor As String = "IMG src=""" & ATTACHMENTS_FOLDER_REPLACEMENT_CODE & strMessageID & "\" & strNameOfFile & """"
                                    Dim strReplacement As String = "IMG src=""" & EMAIL_CONTENTID_CODE & strContentID & """"
                                    strBody = strBody.Replace(strSearchFor, strReplacement)
                                    msg.EmbedImage(strContentID, strFilename)
                                Else
                                    '-- just attached 
                                    intErrorSection = 26

                                    msg.AddAttachment(strFilename)
                                End If
                            Next
                        End If
                    End If

                    intErrorSection = 27
                    If boolPlainText Then
                        msg.BodyFormat = aspNetEmail.MailFormat.Text
                    Else
                        '-- HTML
                        msg.BodyFormat = aspNetEmail.MailFormat.Html
                    End If
                    msg.Body = strBody '-- make sure we update the body with any cid: information
                    msg.Subject = strSubject
                Case EncryptedEmailType.EncrypedTM2TMEmail
                    '-- Need password for encryption of text and attachment (encrypted as ZipAES)
                    '-- first sort out body and subject
                    intErrorSection = 12


                    '-- now sort out the attachments (using ZipAES)
                    If xList.Count > 0 Then
                        intErrorSection = 31
                        Using webzip As New Ionic.Zip.ZipFile()
                            Dim ms As System.IO.MemoryStream
                            Dim strEncryptionPassword As String = xDocFromFile.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_TM2TMPASSWORD)
                            '-- we are going to add an unencrypted entry with a comment to tell users to use a zip utility to open the attachments
                            webzip.AddEntry("Comment.txt", AppSettings.WebMessageAttachmentComment)

                            webzip.Encryption = Ionic.Zip.EncryptionAlgorithm.WinZipAes256
                            webzip.Password = strEncryptionPassword

                            '-- now, we put all the attachments unencrypted in a zip in the bigger zip
                            '   so, outer zip has Comments.txt (unencrypted) and Attachments.zip (encrypted)
                            '   Attachments.zip has all the attachments (attachments here are unencrypted because this zip is stored encrypted within the outer container)
                            '   part of the reasoning behind this solution is that this way, others cannot even see the filenames unless they have the password
                            Using attachZip As New Ionic.Zip.ZipFile()
                                intErrorSection = 32
                                For Each xElement In xList '-- attachments list
                                    Dim strNameOfFile As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME)
                                    strFilename = AttachmentsRootPath & strMessageID & "\" & xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME)

                                    If strNameOfFile.ToLower.StartsWith(IMAGES_EMBEDDED_FOLDER.ToLower) Then
                                        '-- embeded
                                        intErrorSection = 19
                                        '-- DO NOT replace with CID because image should not be unencrypted
                                        Dim strSearchFor As String = "IMG src=""" & ATTACHMENTS_FOLDER_REPLACEMENT_CODE & strMessageID
                                        Dim strReplacement As String = "IMG src=""" & ATTACHMENTS_FOLDER_REPLACEMENT_CODE & MESSAGEID_REPLACEMENT_CODE
                                        strBody = strBody.Replace(strSearchFor, strReplacement)
                                        attachZip.AddFile(strFilename, IMAGES_EMBEDDED_FOLDER)
                                    Else
                                        intErrorSection = 20
                                        '-- just attach
                                        attachZip.AddFile(strFilename, String.Empty)
                                    End If
                                Next
                                intErrorSection = 33
                                '-- now add attachments.zip into the outerzip
                                ms = New System.IO.MemoryStream()
                                attachZip.Save(ms)
                                ' move the stream position to the beginning
                                ms.Seek(0, System.IO.SeekOrigin.Begin)
                                intErrorSection = 34

                                webzip.AddEntry("Attachments.tmz", ms)
                            End Using

                            intErrorSection = 35

                            strTempTM2TMZipFilename = GetTempFilename()
                            webzip.Save(strTempTM2TMZipFilename)
                            ms.Close()
                            ms.Dispose()
                            intErrorSection = 36
                        End Using

                        intErrorSection = 37
                        Dim strDestinationZipFilename As String = strTempTM2TMZipFilename.Substring(0, strTempTM2TMZipFilename.Length - System.IO.Path.GetExtension(strTempTM2TMZipFilename).Length()) & ".zip"
                        System.IO.File.Move(strTempTM2TMZipFilename, strDestinationZipFilename)
                        strTempTM2TMZipFilename = strDestinationZipFilename

                        msg.AddAttachment(strTempTM2TMZipFilename)
                    End If

                    '-- must do this after the above case because we change the html in some cases
                    '   notably for embedded images
                    If boolPlainText Then
                        msg.BodyFormat = aspNetEmail.MailFormat.Text
                    Else
                        '-- HTML
                        msg.BodyFormat = aspNetEmail.MailFormat.Html
                    End If
                    msg.Body = EncryptBodyForTM2TM(strTM2TMEncryptionKey, strBody, strSubject)
                    msg.Subject = "Private"
            End Select



            intErrorSection = 40

            '-----------------
            '-- Recipients ---
            '-----------------

            '===================================================================
            '===================================================================
            '   We only need xDocRecipList and children when we are sending to 
            '   only email recips. If we send to TrulyMail 
            '   also (or just TrulyMail) then no need for this if TrulyMail 
            '   recips are included then the recip list is in the xDoc sent
            '===================================================================
            '===================================================================
            Dim boolNewsletterMode As Boolean
            xElement = xDocFromFile.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_RECIPIENTS)
            If xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_NEWSLETTERMODE).Length > 0 Then
                boolNewsletterMode = ConvertToBool(xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_NEWSLETTERMODE), False)
            End If
            If boolNewsletterMode Then
                Log("Using newsletter mode to send email.")
            End If

            intErrorSection = 41

            Dim xDocRecipList As New Xml.XmlDocument() '-- to get xml to send to server with email addresses of recipents
            Dim xRecipientsRootForServer As Xml.XmlElement = xDocRecipList.AppendChild(xDocRecipList.CreateElement(MESSAGE_ATTRIBUTE_NAME_RECIPIENTS))
            Dim xRecip As Xml.XmlElement

            intErrorSection = 42

            Dim strRoleID As String
            xList = xDocFromFile.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_RECIPIENT)
            Dim strSentDate As String = Date.Now.ToString(DATEFORMAT_XML)
            Dim boolAtLeastOneTrulyMailContact As Boolean
            Dim lstContactsSent As New List(Of AddressBookEntry)

            intErrorSection = 43

            For Each xElement In xList
                '-- Only process email contacts here
                Dim strContactID As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_RECIPIENTID)
                strRoleID = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID)

                '-- Reset variables
                Dim strRecipientAddress As String = String.Empty
                Dim strRecipientName As String = String.Empty
                Dim s As String = xDocFromFile.OuterXml
                If strContactID.Length = 0 Then
                    If xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SENTDATE).Length = 0 Then
                        '-- plain email address (not address book contact), not sent yet
                        strRecipientName = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME)
                        strRecipientAddress = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ADDRESS)
                    End If
                Else
                    Dim entry As AddressBookEntry
                    Try
                        entry = ABook.GetContactByID(strContactID) ' AddressBookEntry.LoadFromID(strContactID)
                    Catch ex As Exception
                        Log(ex)
                        entry = Nothing
                    End Try

                    '-- Only send to recipients who have not been sent already
                    If entry IsNot Nothing AndAlso entry.ContactType = AddressBookEntryType.Email AndAlso xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SENTDATE).Length = 0 Then
                        strRecipientName = entry.FullName
                        strRecipientAddress = entry.Address
                        xElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENTDATE, strSentDate)

                        '-- add to list for setting LastSentDate 
                        lstContactsSent.Add(entry)
                    ElseIf entry IsNot Nothing AndAlso entry.ContactType = AddressBookEntryType.TrulyMail Then
                        boolAtLeastOneTrulyMailContact = True
                    ElseIf entry Is Nothing Then
                        '-- strange: entry has ID but ID is not in address book
                        '-- plain email address (not address book contact), not sent yet
                        strRecipientName = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME)
                        strRecipientAddress = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ADDRESS)
                    End If
                End If
                If strRecipientAddress.Length > 0 AndAlso IsValidEmailAddress(strRecipientAddress) Then
                    Select Case emailEncryption
                        Case EncryptedEmailType.ClearText, EncryptedEmailType.EncrypedTM2TMEmail
                            Select Case strRoleID
                                Case ROLEID_TO
                                    'msg.To.Add(New System.Net.Mail.MailAddress(strRecipientAddress, strRecipientName))
                                    msg.AddTo(strRecipientAddress, strRecipientName)
                                Case ROLEID_CC
                                    'msg.CC.Add(New System.Net.Mail.MailAddress(strRecipientAddress, strRecipientName))
                                    msg.AddCc(strRecipientAddress, strRecipientName)
                                Case ROLEID_BCC
                                    'msg.Bcc.Add(New System.Net.Mail.MailAddress(strRecipientAddress, strRecipientName))
                                    msg.AddBcc(strRecipientAddress)
                            End Select
                    End Select

                    '-- For transmit to server
                    xRecip = xRecipientsRootForServer.AppendChild(xDocRecipList.CreateElement(MESSAGE_ATTRIBUTE_NAME_RECIPIENT))
                    xRecip.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME, strRecipientName)
                    xRecip.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ADDRESS, strRecipientAddress)
                    xRecip.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID, strRoleID)
                End If
            Next


            intErrorSection = 50

            '-- Only add the recipients if there is no TrulyMail contact
            '   This is how we will get the contacts to the server
            If boolAtLeastOneTrulyMailContact Then
                xDocRecipList = Nothing '-- no need for this since we send the data to the server in the SendCommunicationTrulyMail routine
            Else
                xDocRecipList.AppendChild(xRecipientsRootForServer)
            End If

            intErrorSection = 51
            '============================================
            '========= Create Encrypted Package =========
            '========= Transmit key to server   =========
            '========= Only for encrypted email =========
            '============================================
            Dim strEncryptedPackageFilename As String = String.Empty

            Dim strSMTPPassword As String
            'Dim msgsender As System.Net.Mail.SmtpClient
            intErrorSection = 57

            '-- Send the message using the specified account

            'msgsender = New System.Net.Mail.SmtpClient(smtp.ServerName, smtp.ServerPort)
            strSMTPPassword = smtp.Password
            If strSMTPPassword.Length = 0 Then
                '-- user canceled logging in
                m_boolCanceled = True
                CancelReason = CancelReasonEnum.CallerCanceled
                RaiseEvent Canceled()
                Exit Sub
            End If

            intErrorSection = 58


            'msgsender.Credentials = New System.Net.NetworkCredential(smtp.Username, strSMTPPassword)
            'msgsender.EnableSsl = smtp.SecureConnection = SecureConnectionOption.SSL
            'msgsender.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            'msgsender.Timeout = 15 * 60000 '15 minutes
            msg.Server = smtp.ServerName

            If smtp.ServerName.ToLower() = "smtp.gmail.com" Then
                msg.SmtpAuthentication = aspNetEmail.SmtpAuthentication.OAuth
            End If
            intErrorSection = 59
            'msg.SmtpAuthentication = aspNetEmail.SmtpAuthentication.No
            msg.Port = smtp.ServerPort
            intErrorSection = 60
            msg.TimeOut = 15 * 60000 '15 minutes
            intErrorSection = 61
            msg.Username = smtp.Username
            intErrorSection = 62
            msg.Password = strSMTPPassword
            intErrorSection = 63
            If smtp.SecureConnection = SecureConnectionOption.SSL OrElse smtp.SecureConnection = SecureConnectionOption.TLS Then
                intErrorSection = 64
                Dim ssl As New AdvancedIntellect.Ssl.SslSocket()
                msg.LoadSslSocket(ssl)
            End If
            intErrorSection = 65

            Try
                strCurrentStep = "Sending email"

                intErrorSection = 66

                RaiseEvent Progress(0.67, strCurrentStep)
                '-- Check to see if caller canceled
                If m_boolCanceled Then
                    CancelReason = CancelReasonEnum.CallerCanceled
                    RaiseEvent Canceled()
                    m_boolCanceled = True
                    Exit Sub
                End If

                intErrorSection = 67

                Try
                    If msg.Send() Then
                        msg.Dispose() '--  for breakpoint
                    Else
                        msg.Dispose()
                        Throw New Exception("Sending mail failed: " & msg.Subject)
                    End If

                    '-- could send, so save session password
                    smtp.PasswordDuringSession = strSMTPPassword
                    intErrorSection = 68
                Catch ex As Exception
                    Log(ex)

                    If ex.Message.Contains("Exception of type 'System.OutOfMemoryException' was thrown") Then
                        msg.Dispose() '-- should not happen with CacheForSMTP=false above
                        m_exception = New Exception(EXCEPTIONTEXT_EMAIL_TOO_LARGE)
                        CancelReason = CancelReasonEnum.MessageError
                    ElseIf ex.Message.Contains("support.google.com/mail/bin/answer.py?answer=6590") Then
                        '-- Google blocks encrypted zips
                        msg.Dispose()
                        CancelReason = CancelReasonEnum.MessageError
                        m_exception = New Exception(EXCEPTIONTEXT_GOOGLE_NOT_ALLOW_ENCRYPTED_ZIPS, New Exception(ex.Message))
                        m_smtpAccount = smtp
                    Else
                        If ex.Message.Contains("System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time") OrElse ex.Message.Contains("System.Net.Sockets.SocketException: The requested name is valid, but no data of the requested type was found") Then
                            '-- This error is beause the internet connection is too weak to connect (flaky or downloading too much other stuff while trying to connect)
                            If Not AppSettings.DoNotShowSMTPServerConnectionTimeOutErrorNotice Then
                                Using frm As New NotifyForm("The server used to send email is not responding. This could be because of a weak internet connection." & _
                                                            Environment.NewLine & Environment.NewLine & _
                                                            "If you believe this is an error within TrulyMail, please contact TrulyMail Support.", NotifyForm.DoNotShowSetting.DoNotShowSMTPServerConnectionTimeOutErrorNotice, MessageBoxButtons.OK)
                                    frm.ShowDialog(MainFormReference)
                                End Using
                            End If
                            msg.Dispose()
                            Log("Cannot connect to SMTP server.  Section: " & intErrorSection.ToString() & "; Filename: " & filename)
                            m_exception = Nothing
                            CancelReason = CancelReasonEnum.ServerError
                        ElseIf ex.Message.Contains("password") Then
                            msg.Dispose()
                            CancelReason = CancelReasonEnum.MessageError
                            m_exception = New Exception(EXCEPTIONTEXT_USERNAME_PASSWORD_INVALID, New Exception(ex.Message))
                            m_smtpAccount = smtp
                        Else 'If ex.Message.Contains("") Then
                            '-- " [Additional Help:error in body: 552-5.2.3 Your message exceeded Google's message size limits. Please visit  552-5.2.3 http://mail.google.com/support/bin/answer.py?answer=8770 to review  552 5.2.3 our size guidelines. d15sm9278893ibf.7  ]"
                            '-- don't know the problem so bubble it up and let the caller present it to the user
                            msg.Dispose()
                            m_exception = New Exception(EXCEPTIONTEXT_EMAIL_UNKNOWN_ERROR, New Exception(ex.Message))
                            CancelReason = CancelReasonEnum.MessageError
                        End If
                    End If
                    m_boolCanceled = True
                    RaiseEvent Canceled()
                    Exit Sub
                End Try

                intErrorSection = 83

                '-- Delete old encrypted package, we don't need it
                If strEncryptedPackageFilename.Length > 0 AndAlso System.IO.File.Exists(strEncryptedPackageFilename) Then
                    Try
                        DeleteLocalFile(strEncryptedPackageFilename)
                    Catch ex As Exception
                        Log(ex) '-- just log and move on... no need to worry about leaving something in the temp folder, it is encrypted after all
                    End Try
                End If

                intErrorSection = 84


                '-- Save back message so we have the sent date for each TrulyMail recipient
                xDocFromFile.Save(filename)

                intErrorSection = 85

                '-- Now update the LastSentDate on contacts
                For Each entry As AddressBookEntry In lstContactsSent
                    entry.LastMessageSent = Date.UtcNow
                Next

                smtp.MessagesSent += 1

                intErrorSection = 86

                ABook.Save()

                intErrorSection = 87

                '-- Keep system informed about how many msgs have been sent on current key
                'Select Case emailEncryption
                '    Case EncryptedEmailType.EncryptedPackage
                '        AppSettings.MessagesSentOnCurrentEncryptionKey += 1
                '    Case EncryptedEmailType.EncryptedWebmail
                '        AppSettings.MessagesSentOnCurrentEncryptionKey += 1
                '    Case Else
                '        '-- do nothing
                'End Select

            Catch ex As Exception
                '-- If login failed, then prompt user again
                '-- If server cannot be contacted, schedule for sending later
                Log(ex)
                Log("Section: " & intErrorSection.ToString() & "; Filename: " & filename)
                m_exception = ex
                CancelReason = CancelReasonEnum.MessageError
                m_boolCanceled = True
                RaiseEvent Canceled()

                Exit Sub
            End Try
        Catch ex As Exception
            Log(ex)
            Log("Section: " & intErrorSection.ToString() & "; Filename: " & filename)
            Throw ex
        End Try
    End Sub
    Private Function GetMimeType(ByVal extension As String) As String
        Select Case extension.ToLower
            Case ".gif"
                Return System.Net.Mime.MediaTypeNames.Image.Gif
            Case ".tif"
                Return System.Net.Mime.MediaTypeNames.Image.Tiff
            Case ".png"
                Return "image/png"
            Case Else '".jpg"
                Return System.Net.Mime.MediaTypeNames.Image.Jpeg
        End Select
    End Function
    Private Sub SendCommunication(ByVal filename As String)
        Dim intErrorSection As Integer
        Try
            intErrorSection = 1
            Dim xDocFromFile As New Xml.XmlDocument()
            xDocFromFile.Load(filename)
            Dim strLocalMessageID As String = xDocFromFile.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGEID)

            Dim boolSendTrulyMail As Boolean
            Dim boolSendEmail As Boolean
            Dim boolTrulyMailSent As Boolean
            Dim boolEmailSent As Boolean

            intErrorSection = 2

            '-- See where the 'to send' recipients are (TrulyMail / email)
            Dim xList As Xml.XmlNodeList
            Dim contactType As AddressBookEntryType
            xList = xDocFromFile.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_RECIPIENT)

            intErrorSection = 3
            For Each xElement As Xml.XmlElement In xList
                Dim strContactID As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_RECIPIENTID)
                intErrorSection = 4
                If strContactID.Length = 0 Then
                    contactType = AddressBookEntryType.Email
                Else
                    Dim entry As AddressBookEntry
                    Try
                        intErrorSection = 5
                        entry = ABook.GetContactByID(strContactID) ' AddressBookEntry.LoadFromID(strContactID)
                        contactType = entry.ContactType
                    Catch ex As Exception
                        intErrorSection = 6
                        Log(ex)
                        Log("Entry is nothing: " & (entry Is Nothing))
                        '-- address book entry was removed
                        contactType = AddressBookEntryType.Email
                    End Try
                End If

                intErrorSection = 7
                Select Case contactType
                    Case AddressBookEntryType.Email
                        If xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SENTDATE).Length = 0 Then
                            boolSendEmail = True
                        End If
                    Case AddressBookEntryType.TrulyMail
                        If xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SENTDATE).Length = 0 Then
                            boolSendTrulyMail = True
                        End If
                End Select

                intErrorSection = 8
                If boolSendEmail AndAlso boolSendTrulyMail Then
                    Exit For '-- send both, stop looking
                End If
            Next


            '-- First send to TrulyMail recipients
            '-- We must ensure that at least one TrulyMail recipient is on the list before sending to SendTrulyMail
            intErrorSection = 9
            If boolSendTrulyMail Then
                boolTrulyMailSent = True
            End If


            '-- If successful so far, now send to email recipients
            '-- We must ensure that at least one email recipient is on the list before sending to SendEmail
            If boolSendEmail Then
                Try
                    SendCommunicationEmail(filename)
                    intErrorSection = 10
                    If m_boolCanceled AndAlso CancelReason = CancelReasonEnum.CallerCanceled Then
                        '-- caller wants to stop, do not do anything more
                        '-- Canceled event would have already been raised in SendCommunicationEmail
                        Exit Sub
                    End If

                    If m_exception IsNot Nothing Then
                        '-- There was an error and the Canceled event already fired
                        '   Now, we just need to stop processing this message
                        Exit Sub
                    End If
                    intErrorSection = 11
                    boolEmailSent = True
                Catch ex As Exception
                    '-- Should not get here since we trap errors in above routine
                    Log(ex)
                    intErrorSection = 12
                    ShowMessageBoxError("There was an error (" & ex.Message & ") sending to email recipients." & Environment.NewLine & _
                                   Environment.NewLine & "Please go to Help->Submit Log File to Server." & _
                                   Environment.NewLine & Environment.NewLine & "We will correct the problem as quickly as possible.")
                    Threading.Thread.Sleep(30000) '-- don't get stuck showing this error again and again without delay
                End Try
            End If


            '-- Update caller so they know how we are progressing
            'intTotalBytesSent += 0
            'strCurrentStep = "Cleaning up"
            'RaiseEvent Progress(intTotalBytesSent / intTotalBytesToSend, strCurrentStep)

            Dim boolAllDone As Boolean = True
            If boolSendTrulyMail Then
                If Not boolTrulyMailSent Then
                    boolAllDone = False
                End If
            End If
            intErrorSection = 13
            If boolAllDone Then
                If boolSendEmail Then
                    If Not boolEmailSent Then
                        boolAllDone = False
                    End If
                End If
            End If

            intErrorSection = 14
            If boolAllDone Then
                Dim strCurrentStep As String
                strCurrentStep = "Cleaning up"
                RaiseEvent Progress(1, strCurrentStep)
                '-- Check to see if caller canceled
                If m_boolCanceled Then
                    CancelReason = CancelReasonEnum.CallerCanceled
                    RaiseEvent Canceled()
                    m_boolCanceled = True
                    Exit Sub
                End If

                intErrorSection = 15
                Dim strSentDate As String = Date.UtcNow.ToString(DATEFORMAT_XML)

                '-- Save file in sent items
                Dim strKeepCopy As String = xDocFromFile.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_KEEPCOPYAFTERSEND)
                Dim boolKeepCopy As Boolean = True
                If strKeepCopy.Length > 0 Then
                    Try
                        If Not Convert.ToBoolean(strKeepCopy) Then
                            '-- delete only here
                            boolKeepCopy = False
                        End If
                    Catch ex As Exception
                        '-- the attribute was not set properly, do nothing
                        Application.DoEvents() '-- for breakpoint only
                    End Try
                End If

                intErrorSection = 16
                If boolKeepCopy Then
                    xDocFromFile.Load(filename) '-- reopen the file to get changes made in sending routines
                    xDocFromFile.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENTDATE, strSentDate)
                    xDocFromFile.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_READ, True)
                    Dim xBody As Xml.XmlElement = xDocFromFile.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_BODY)
                    Select Case xBody.GetAttribute("Format")
                        Case "PlainText"
                            '-- if PlainText and sent to at least one TrulyMail then remove formatting
                        Case Else
                            '-- default to html
                    End Select

                    Dim strNewFilename As String = SentItemsRootPath & strLocalMessageID & MESSAGE_FILENAME_EXTENSION
                    Do Until System.IO.File.Exists(strNewFilename)
                        xDocFromFile.Save(strNewFilename)
                        Application.DoEvents()
                        Threading.Thread.Sleep(250)
                    Loop

                    '-- Only process message rules if a copy was kept
                    Dim msg As TrulyMailMessage = New TrulyMailMessage(strNewFilename)
                    Dim objDeleteSomeDay As New ReceiveFileDetails() 'TODO: Add send message logging like receive message logging
                    MainFormReference.ProcessMessageSent(msg, objDeleteSomeDay)
                End If

                intErrorSection = 17

                '-- Delete unsent file
                DeleteLocalFile(filename)
                'MainFormReference.ShowFolderContentsIfCurrent(System.IO.Path.GetDirectoryName(filename))
                MainFormReference.RemoveMessageIfPresent(filename)
                MainFormReference.ShowUnreadOnOutBoxNode()
                intErrorSection = 18
            End If
        Catch ex As Exception
            Log(ex)
            Log("Location: " & intErrorSection.ToString())
            Throw ex
        End Try

    End Sub
    Friend Sub RescheduleSendingDate(ByVal newDate As Date)
        RescheduleSendingDate(m_strRecentFilename, newDate)
    End Sub
    Friend Sub RescheduleSendingDate(ByVal filename As String, ByVal newDate As Date)
        Try
            If System.IO.File.Exists(filename) Then
                Dim xDoc As New Xml.XmlDocument()
                xDoc.Load(filename)

                Dim strSendAfterDate As String = newDate.ToString(DATEFORMAT_XML)
                xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDAFTERDATE, strSendAfterDate)
                xDoc.Save(filename)
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Friend Sub DeleteMostRecentMessage()
        DeleteLocalFile(m_strRecentFilename)
        MainFormReference.ShowFolderContentsIfCurrent(System.IO.Path.GetDirectoryName(m_strRecentFilename))
        MainFormReference.RemoveMessageIfPresent(m_strRecentFilename)
        'g_boolFileSystemChanged = True
    End Sub
    Friend Sub MakeMostRecentDraft()
        MakeMessageDraft(m_strRecentFilename)
    End Sub
End Class
