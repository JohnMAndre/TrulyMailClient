
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Diagnostics


Friend Class ReadMessage7Control

    Private m_EncryptionStatus As EncryptionStatus
    Private m_boolNotesDirty As Boolean
    Private m_strReadReceiptFromAddress As String = String.Empty

    Private Const REPLY_TO As String = "Reply To"

    Public Event EnableMessageHeaders(ByVal enabled As Boolean)
    Public Event EnableTreatAsReadReceipt(ByVal enabled As Boolean)
    Private m_boolDeleteAfterUnsend As Boolean
    Private m_speech As System.Speech.Synthesis.SpeechSynthesizer

    'Private Const READ_RECEIPT_READ_SPANISH As String = "leído: "
    'Private Const READ_RECEIPT_READ_DUTCH As String = "gelezen: "
    'Private Const READ_RECEIPT_RECEIPT_ENGLISH As String = "receipt:" '-- DreamMail (no attachments)
    'Private Const READ_RECEIPT_RECEIVED_DUTCH As String = "ontvangen:" '-- DreamMail (no attachments)
    'Private Const READ_RECEIPT_READ_ENGLISH As String = "read:"
    'Private Const READ_RECEIPT_READ_ENGLISH_THUNDERBIRD_TRULYMAIL As String = "return receipt (displayed) - "

    Private m_boolInFullScreenMode As Boolean
    Private m_frmFullScreen As BrowserFullScreenForm
    Private m_pnlReaderParentBeforeFullScreen As SplitterPanel
    Private m_boolIsFullyLoaded As Boolean

    Public Enum MessageSpecialActionEnum
        Reply
        ReplyAll
        Forward
        FollowUp
        DeleteMessage
        NewMessage
        MarkRead
        FindInMessage
    End Enum
    Public Event SpecialAction(ByVal action As MessageSpecialActionEnum)
    Private Property m_boolDarkMode As Boolean
    Public Property DarkMode As Boolean
        Get
            Return m_boolDarkMode
        End Get
        Set(value As Boolean)
            m_boolDarkMode = value

            Dim clrDark As Color
            Dim clrLight As Color

            If m_boolDarkMode Then
                clrDark = Color.Black
                clrLight = Color.White
            Else
                clrDark = Color.White
                clrLight = Color.Black
            End If

            rtbBody.BackColor = clrDark
            rtbBody.ForeColor = clrLight
            olvRecipients.BackColor = clrDark
            olvRecipients.ForeColor = clrLight
            olvAttachments.BackColor = clrDark
            olvAttachments.ForeColor = clrLight


        End Set
    End Property
    Public ReadOnly Property MessageBeingRead As TrulyMailMessage
        Get
            Return m_tm
        End Get
    End Property
    Private m_tm As TrulyMailMessage
    Public Event MouseWheel As MouseEventHandler

    Public Sub ShowMessageTextTEST()
        '-- This is for testing to get a good HTML to Text conversion process
        'rtbBody.Text = HtmlAgilityPackWrapper.HAPConvertHtml(Me.MessageBeingRead.Body)
        rtbBody.Text = ConvertHtmlToPlainText(Me.MessageBeingRead.Body)
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        m_boolIsFullyLoaded = True
    End Sub
    Public Property LoadDelay() As Integer
        Get
            Return tmrLoadMessage.Interval
        End Get
        Set(ByVal value As Integer)
            tmrLoadMessage.Stop()
            tmrLoadMessage.Interval = value
        End Set
    End Property
    Public Sub ClosePreviousMessage()
        '-- This takes the place of the form_closed event
        If m_tm IsNot Nothing Then
            If m_boolNotesDirty Then
                Select Case ShowMessageBox("Your notes have changed. Would you like to save them now?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    Case Windows.Forms.DialogResult.Yes
                        SaveNotes()
                    Case Windows.Forms.DialogResult.No
                        '-- do nothing
                End Select
            End If

            RestoreIEFooter()

            m_tm = Nothing

            If m_speech IsNot Nothing Then
                m_speech.SpeakAsyncCancelAll()
            End If
        End If
    End Sub
    Friend Sub LoadMessage(ByVal tmm As TrulyMailMessage)
        Try

            '-- since we have no close event, make sure changed notes, etc. are processed properly
            ClosePreviousMessage()

            '-- Now, setup for delayed loading of the message
            '   ensure the timer starts from now, not the previous load attempt
            tmrLoadMessage.Stop()
            m_tm = tmm
            tmrLoadMessage.Start()

        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Friend Sub CancelMessageLoad()
        tmrLoadMessage.Stop()
    End Sub
    Private Sub LoadMessageDelayed()
        Try
            tmrLoadMessage.Stop()
            llblFrom.BackColor = SystemColors.Control

            Select Case m_tm.MessageType
                Case MessageType.Communication, MessageType.Draft, MessageType.ExternalReply, MessageType.RSSArticle, MessageType.PageChangeNotice, MessageType.NoteToSelf
                    Me.Show()
                    lvMessages.Visible = False

                    Dim entry As AddressBookEntry

                    '-- Do we branch if sent/received? Maybe no need

                    If m_tm.MessageType = MessageType.RSSArticle OrElse m_tm.MessageType = MessageType.PageChangeNotice Then
                        llblRSSLink.Text = m_tm.ReferenceURL
                        llblFrom.Text = m_tm.Sender.FullName
                        llblFrom.LinkArea = New LinkArea(0, 0)
                        llblReplyTo.Visible = False
                        RaiseEvent EnableMessageHeaders(False)
                        RaiseEvent EnableTreatAsReadReceipt(False)
                    Else
                        RaiseEvent EnableMessageHeaders(m_tm.Sent = False)
                        RaiseEvent EnableTreatAsReadReceipt(m_tm.Sent = False)

                        If m_tm.Sent Then
                            If m_tm.SMTPProfile IsNot Nothing Then
                                llblFrom.Text = m_tm.SMTPProfile.Name
                                llblFrom.LinkArea = New LinkArea(0, 0)
                            Else
                                llblFrom.Text = "Unknown"
                                llblFrom.LinkArea = New LinkArea(0, 0)
                            End If
                            llblReplyTo.Visible = False
                        Else
                            '-- received
                            entry = ABook.GetContactByAddress(m_tm.Sender.Address)

                            If m_tm.Sender.FullName.Length = 0 Then
                                llblFrom.Text = m_tm.Sender.Address
                            Else
                                If AppSettings.EmailShowSenderAsSent OrElse entry Is Nothing Then
                                    llblFrom.Text = m_tm.Sender.FormattedAsStandard
                                Else
                                    llblFrom.Text = entry.FormattedAsStandard
                                End If
                            End If


                            If entry IsNot Nothing AndAlso entry.ReceiveOnly Then
                                llblFrom.LinkArea = New LinkArea(0, 0)
                            Else
                                llblFrom.LinkArea = New LinkArea(0, llblFrom.Text.Length)
                            End If


                            '-- ReplyTo
                            If m_tm.ReplyTo IsNot Nothing AndAlso m_tm.ReplyTo.Length > 0 Then
                                llblReplyTo.Visible = True
                                llblReplyTo.BackColor = Color.Transparent
                                llblReplyTo.Text = REPLY_TO
                                ToolTip1.SetToolTip(llblReplyTo, m_tm.ReplyTo)
                                llblReplyTo.AutoSize = True
                                Dim sz As Size = llblReplyTo.Size
                                llblReplyTo.AutoSize = False
                                sz.Height = 16
                                llblReplyTo.Size = sz
                                llblReplyTo.LinkArea = New LinkArea(0, llblReplyTo.Text.Length)

                                '-- press to far left
                                llblReplyTo.Left = llblFrom.Left
                                Do Until llblReplyTo.Right >= llblFrom.Right
                                    llblReplyTo.Left += 1
                                Loop
                                llblReplyTo.Left -= 1
                            Else
                                llblReplyTo.Visible = False
                            End If

                        End If
                    End If

                    '-- Date sent/tosend/etc.
                    lblSent.Text = m_tm.MainMessageDate
                    lblSentLabel.Text = m_tm.MainMessageDateLabel

                    '-- Size
                    lblMessageSize.Text = FormatDataSizeString(m_tm.Size)

                    '-- Subject
                    txtSubject.Text = m_tm.Subject

                    Dim strHTML As String = String.Empty
                    If m_tm.BodyFormat = EmailBodyFormatEnum.PlainText Then 'AndAlso m_tm.MessageType <> MessageType.Draft Then
                        '-- PlainText
                        LoadTextAsBody(m_tm.Body)
                        olvEmbeddedImages.Hide()
                    Else
                        '-- HTML
                        '-- defaults to html, even for mixed
                        '== Version 7 converts to PlainText, puts all embedded images as attachments

                        strHTML = m_tm.Body.Replace(ATTACHMENTS_FOLDER_REPLACEMENT_CODE, AttachmentsRootPath)

                        '-- Since HTML can have embedded images, we need to see any images in the \images\ folder
                        '   And include them as attachments
                        Dim item As AttachmentItem
                        m_tm.LoadEmbeddedImageList()
                        If m_tm.EmbeddedImages IsNot Nothing AndAlso m_tm.EmbeddedImages.Count > 0 Then
                            Me.olvEmbeddedImages.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf AttachmentRowFormatter)
                            Me.OlvColumnFileSizeEmbedded.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterSize)
                            olvEmbeddedImages.Show()
                            olvEmbeddedImages.SetObjects(m_tm.EmbeddedImages)
                        Else
                            olvEmbeddedImages.Hide()
                        End If

                        'Dim strText As String = StripHTML(strHTML)
                        Dim strText As String = ConvertHtmlToPlainText(strHTML) '-- 18 Feb 2018 changed to HtmlAgilityPack
                        LoadTextAsBody(strText)

                    End If

                    '-- Must display a decryption panel if this is a TM2TM message
                    If m_tm.Body.Contains(HEADER_TM2TM) AndAlso m_tm.Body.Contains(FOOTER_TM2TM) Then
                        txtDecryptionPassword.Text = String.Empty
                        pnlTM2TM.Show()
                    Else
                        pnlTM2TM.Hide()
                    End If

                    If Not AppSettings.MaintainMessageZoom Then
                        '-- reset to default zoom
                        tbZoom.Value = ZOOM_100
                    End If


                    m_tm.Read = True
                    If m_tm.ShouldPromptToSendReadReceipt Then
                        Dim strReceiptMessage As String = "The sender of this message (" & m_tm.SendReadReceiptToAddress & ") has requested to be notified when you read this message." & _
                                                            Environment.NewLine & Environment.NewLine & _
                                                            "Do you wish to notify the sender (send a read receipt)?."
                        If ShowMessageBox(strReceiptMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            m_tm.SendReadReceipt(True)
                        Else
                            m_tm.ShouldPromptToSendReadReceipt = False
                            m_tm.Notes &= Date.Today & "   " & "Chose not to send read receipt to " & m_tm.SendReadReceiptToAddress
                            m_tm.Save()
                        End If
                    End If
                    RaiseEvent SpecialAction(MessageSpecialActionEnum.MarkRead)

                    '-- Show the attachments
                    LoadAttachmentList(m_tm.Attachments())

                    '-- Show the recipients
                    olvRecipients.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf RecipientsRowFormatter)
                    RecipientIconColumn.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf RecipientImageGetter)
                    LoadRecipientList(m_tm.Recipients)

                    '-- format dates
                    ReceivedColumn.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf FormatDateTimeForOLV)
                    ViewedColumn.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf FormatDateTimeForOLV)
                    ResentColumn.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf FormatDateTimeForOLV)
                    OlvColumnMessageDate.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf FormatDateTimeForOLV)


                    '-- If this is a received message then remove three columns from recip list
                    ReceivedColumn.IsVisible = m_tm.Sent AndAlso Not m_tm.MessageType = MessageType.Draft
                    ViewedColumn.IsVisible = m_tm.Sent AndAlso Not m_tm.MessageType = MessageType.Draft
                    ResentColumn.IsVisible = m_tm.Sent AndAlso Not m_tm.MessageType = MessageType.Draft


                    Dim boolAtLeastOneEmailRecip, boolAtLeastOneTrulyMailRecip As Boolean
                    If olvRecipients.Objects IsNot Nothing AndAlso olvRecipients.Items.Count > 0 Then
                        For Each recip As RecipientEntry In olvRecipients.Objects
                            Select Case recip.ContactType
                                Case AddressBookEntryType.Email
                                    boolAtLeastOneEmailRecip = True
                                Case AddressBookEntryType.TrulyMail
                                    boolAtLeastOneTrulyMailRecip = True
                            End Select
                        Next
                    End If

                    RecipientAddressColumn.IsVisible = boolAtLeastOneEmailRecip
                    olvRecipients.RebuildColumns()


                    If Not m_tm.Sent Then
                        If m_tm.Encrypted Then
                            m_EncryptionStatus = EncryptionStatus.Encrypted
                        Else
                            m_EncryptionStatus = EncryptionStatus.NotEncrypted
                        End If
                    Else
                        '-- sent
                        If m_tm.Encrypted Then
                            If boolAtLeastOneEmailRecip AndAlso boolAtLeastOneTrulyMailRecip Then
                                '-- only encrypt to TrulyMail recips, not email recips
                                m_EncryptionStatus = EncryptionStatus.PartiallyEncrypted
                            ElseIf boolAtLeastOneEmailRecip Then
                                m_EncryptionStatus = EncryptionStatus.NotEncrypted
                            ElseIf boolAtLeastOneTrulyMailRecip Then
                                m_EncryptionStatus = EncryptionStatus.Encrypted
                            End If
                        Else
                            m_EncryptionStatus = EncryptionStatus.NotEncrypted
                        End If
                    End If

                    Select Case m_EncryptionStatus
                        Case EncryptionStatus.Encrypted
                            Me.Text = m_tm.Subject & " " & ENCRYPTED_TITLEBAR_TEXT
                        Case EncryptionStatus.NotEncrypted
                            Me.Text = m_tm.Subject & " " & UNENCRYPTED_TITLEBAR_TEXT
                        Case EncryptionStatus.PartiallyEncrypted
                            Me.Text = m_tm.Subject & " " & PARTIALLYENCRYPTED_TITLEBAR_TEXT
                    End Select


                    AutoSizeColumns(olvAttachments)
                    AutoSizeColumns(olvRecipients)

                    NotifyIfEmailSentFromTrulyMail()

                    '-- Load notes
                    If Not m_tm.HasNotes Then
                        '-- hide note panel
                        NotesBodySplitContainer.Panel1Collapsed = True
                        txtNotes.Text = String.Empty
                    Else
                        txtNotes.Enabled = False
                        NotesBodySplitContainer.Panel1Collapsed = False
                        txtNotes.Text = m_tm.Notes
                        txtNotes.Enabled = txtNotes.Text.Length > 0
                        txtNotes.ReadOnly = True
                        'NotesBodySplitContainer.SplitterDistance = ConvertToInt32(xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_NOTESSPLITTER), 150)
                        NotesEditToolStripButton.Enabled = True
                    End If
                    m_boolNotesDirty = False
                    NotesSaveToolStripButton.Enabled = False


                    '-- Check to see if this is an email receipt
                    If Not m_tm.Sent AndAlso Not AppSettings.DoNotProcessEmailReceipts Then
                        If m_tm.Subject.ToLower().StartsWith(RETURN_RECEIPT_SUBJECT.ToLower()) Then
                            '-- This looks like a return receipt from TrulyMail or Thunderbird
                            ShowReceiptProcessingPanel()
                        ElseIf m_tm.Subject.Trim.ToLower.StartsWith(READ_RECEIPT_READ_ENGLISH) Then
                            '-- This looks like a return receipt from Vista mail, outlook, or outlook express
                            ShowReceiptProcessingPanel()
                        ElseIf m_tm.Subject.Trim.ToLower.StartsWith(READ_RECEIPT_READ_SPANISH) Then
                            ShowReceiptProcessingPanel()
                        ElseIf m_tm.Subject.Trim.ToLower.StartsWith(READ_RECEIPT_READ_DUTCH) Then
                            ShowReceiptProcessingPanel()
                        ElseIf m_tm.Subject.Trim.ToLower.StartsWith(READ_RECEIPT_RECEIVED_DUTCH) Then
                            ShowReceiptProcessingPanel()
                        ElseIf m_tm.Subject.Trim.ToLower.StartsWith(READ_RECEIPT_RECEIPT_ENGLISH) Then
                            ShowReceiptProcessingPanel()
                        Else
                            HideReceiptProcessingPanel()
                        End If
                    Else
                        HideReceiptProcessingPanel()
                    End If

                    ArrangeLabels()

                    If m_speech IsNot Nothing Then
                        m_speech.SpeakAsyncCancelAll()
                        m_speech.Dispose()
                        m_speech = Nothing
                    End If

                    SetFindButtonText()

                    LoadReplyModes()

                Case Else
                    Me.Hide()
            End Select

        Catch ex As Exception
            Log(ex)

        End Try

    End Sub

    Private Sub LoadTextAsBody(ByVal text As String)
        Console.WriteLine("Loading text into RTB")
        rtbBody.Text = text & Environment.NewLine
        'rtbBody.Dock = DockStyle.Fill
        'rtbBody.BringToFront()
        'rtbBody.Show()
        'rtbBody.BackColor = Color.White
        rtbBody.Font = AppSettings.FontForPlainText

        If m_boolInFullScreenMode Then
            Application.DoEvents()
            m_frmFullScreen.LoadRTB(Me.rtbBody, m_tm.Filename)
            m_frmFullScreen.LastFilename = m_tm.Filename
        End If
    End Sub
    Private Sub LoadAttachmentList(lst As List(Of AttachmentItem))
        AttachmentNameColumn.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf AttachmentImageGetter)
        Me.olvAttachments.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf AttachmentRowFormatter)

        Me.OlvColumnFileSize.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterSize)

        olvAttachments.SetObjects(m_tm.Attachments)
        olvAttachments.ModelFilter = New AttachmentFilterEmbeddedImages()

        Me.SplitContainerRecipAttachments.Panel2Collapsed = (m_tm.Attachments.Count = 0)

    End Sub

    Private Sub LoadRecipientList(ByVal xListRecipients As Xml.XmlNodeList, ByVal xListAddresses As Xml.XmlNodeList)
        Dim boolAtLeastOneResentDate As Boolean
        Dim boolAtLeastOneReceiveDate As Boolean
        Dim boolAtLeastOneViewDate As Boolean

        Dim lstRecipients As New List(Of RecipientEntry)

        Dim intTotalOtherRecipients As Integer = 0
        For Each xElement As Xml.XmlElement In xListRecipients
            Dim strRecipUserID As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_RECIPIENTID)
            Dim strRoleID As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID)
            Dim item As RecipientEntry
            Dim boolEmailRecipNotInAddressBook As Boolean

            If strRecipUserID.Length > 0 Then
                Try
                    Dim contact As AddressBookEntry = ABook.GetContactByID(strRecipUserID)
                    If contact IsNot Nothing Then
                        item = New RecipientEntry(contact) 'AddressBookEntry.LoadFromID(strRecipUserID))
                        intTotalOtherRecipients += 1
                        boolEmailRecipNotInAddressBook = False
                    Else
                        boolEmailRecipNotInAddressBook = True
                    End If
                Catch ex As Exception
                    '-- contact removed from address book
                    Log(ex)
                    Continue For
                End Try
            Else
                boolEmailRecipNotInAddressBook = True
            End If

            If boolEmailRecipNotInAddressBook Then
                '-- email address not in address book
                Dim strRecipAddress As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ADDRESS)
                '-- Here we strip off the name and just validate the actual email address of the recip
                Dim emailAddressForRecip As System.Net.Mail.MailAddress
                Dim boolNotReallyEmailAddress As Boolean
                Try
                    emailAddressForRecip = New System.Net.Mail.MailAddress(strRecipAddress)
                Catch ex As Exception
                    boolNotReallyEmailAddress = True
                End Try
                If Not boolNotReallyEmailAddress AndAlso IsValidEmailAddress(emailAddressForRecip.Address) Then
                    '-- email user
                    item = New RecipientEntry(AddressBookEntryType.Email)
                    Dim strRecipFullName As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME)
                    item.Address = emailAddressForRecip.Address
                    If emailAddressForRecip.DisplayName.Length = 0 Then
                        item.FullName = strRecipFullName
                    Else
                        item.FullName = emailAddressForRecip.DisplayName
                    End If

                    '-- If settings say to use address book's name instead of the display name from
                    '   the sender, then use it, unless it doesn't exist, then use the way it was sent
                    If Not AppSettings.EmailShowSenderAsSent Then
                        Dim abookEntry As AddressBookEntry = ABook.GetContactByAddress(item.Address) 'GetAddressBookEmailEntry(item.Address)
                        If abookEntry IsNot Nothing Then
                            item.FullName = abookEntry.FullName
                        End If
                    End If
                    intTotalOtherRecipients += 1
                Else
                    '-- invalid recip, ignore
                    Continue For
                End If
            End If

            item.RecipientType = GetRecipientTypeByRoleID(strRoleID)


            '-- If we sent this (have receive and view date) then
            '   we show the extra information
            If ReceivedColumn.IsVisible Then
                Dim strDateReceived As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_RECEIVED)
                If strDateReceived.Length > 0 Then
                    item.ReceivedDate = ConvertToLocalTime(ConvertToDateFromXML(strDateReceived, Date.UtcNow))
                    boolAtLeastOneReceiveDate = True
                End If

                Dim strDateRead As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_READ)
                If strDateRead.Length > 0 Then
                    item.ViewedDate = ConvertToLocalTime(ConvertToDateFromXML(strDateRead, Date.UtcNow))
                    boolAtLeastOneViewDate = True
                End If
            End If

            Dim strResent As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_RESENTDATE)
            If strResent.Length > 0 Then
                boolAtLeastOneResentDate = True
                item.ResentDate = ConvertToLocalTime(ConvertToDateFromXML(strResent, Date.UtcNow))
            End If

            lstRecipients.Add(item)
        Next

        '-- Now add email addresses
        Dim intTotalAddresses As Integer = 0
        For Each xElement As Xml.XmlElement In xListAddresses
            Dim strRoleID As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID)
            Dim item As New RecipientEntry(AddressBookEntryType.Email)
            item.RecipientType = GetRecipientTypeByRoleID(strRoleID)

            item.Address = xElement.InnerText
            item.FullName = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME)
            intTotalOtherRecipients += 1

            lstRecipients.Add(item)
        Next

        '-- If there are no addresses, then no need for the email address column
        Dim boolAtLeastOneEmail As Boolean
        Dim boolAtLeaseOneTrulyMail As Boolean
        For Each entry As RecipientEntry In lstRecipients
            Select Case entry.ContactType
                Case AddressBookEntryType.Email
                    boolAtLeastOneEmail = True
                Case AddressBookEntryType.TrulyMail
                    boolAtLeaseOneTrulyMail = True
            End Select
        Next


        olvRecipients.SetObjects(lstRecipients)

        AutoSizeColumns(olvRecipients)

        '-- If there were multiple recipients, then we can reply all, otherwise, hide that option
        'If m_strFrom.Length = 0 OrElse llblFrom.Text = SERVER_FULLNAME Then
        '    '-- current user is sender
        '    ReplyToolStripButton.Enabled = False
        '    ReplyToolStripMenuItem.Enabled = False
        '    ReplyToAllToolStripButton.Enabled = False
        '    ReplyToAllToolStripMenuItem.Enabled = False
        'Else
        '    If intTotalOtherRecipients = 0 Then
        '        ReplyToAllToolStripButton.Enabled = False
        '        ReplyToAllToolStripMenuItem.Enabled = False
        '    End If
        'End If

        '-- set the height to show all of the recipients
        '   but not more than 10 or less than two
        Dim intRecipientHeight As Integer = 45
        If lstRecipients.Count <= 10 Then
            intRecipientHeight += (18 * lstRecipients.Count)
        Else
            intRecipientHeight += (180)
        End If

        Dim intAttachmentHeight As Integer = 45
        Dim lst As List(Of AttachmentItem) = olvAttachments.Objects
        If lst.Count < 10 Then
            intAttachmentHeight += (18 * lst.Count)
        Else
            intAttachmentHeight += 180
        End If

        Dim intDistance As Integer
        '-- show the most recips or attachments, whichever is more (up to 10)
        intDistance = Math.Max(intRecipientHeight, intAttachmentHeight)
        intDistance = Math.Max(intDistance, SplitContainer2.Panel1MinSize)
        intDistance = Math.Min(intDistance, SplitContainer2.Width - SplitContainer2.Panel2MinSize)


        '-- This is a stupid work around but this bug was reported in 2006 (VS2005) and still exists in VS 2010 beta)
        '   so just try our best to set it and ignore if it throws an error
        Try
            SplitContainer2.SplitterDistance = intDistance
        Catch ex As Exception
            'Log(ex) '-- stopped logging 9 June 2011
        End Try
    End Sub

    Private Sub LoadRecipientList(lst As List(Of RecipientEntry))
        Dim boolAtLeastOneResentDate As Boolean
        Dim boolAtLeastOneReceiveDate As Boolean
        Dim boolAtLeastOneViewDate As Boolean

        Dim lstRecipients As New List(Of RecipientEntry)

        Dim intTotalOtherRecipients As Integer = 0
        For Each recip As RecipientEntry In lst
            Dim strRecipUserID As String = recip.ID
            Dim item As RecipientEntry
            Dim boolEmailRecipNotInAddressBook As Boolean

            If strRecipUserID.Length > 0 Then
                Try
                    Dim contact As AddressBookEntry = ABook.GetContactByID(strRecipUserID)
                    If contact IsNot Nothing Then
                        item = New RecipientEntry(contact)
                        intTotalOtherRecipients += 1
                        boolEmailRecipNotInAddressBook = False
                    Else
                        boolEmailRecipNotInAddressBook = True
                    End If
                Catch ex As Exception
                    '-- contact removed from address book
                    Log(ex)
                    Continue For
                End Try
            Else
                boolEmailRecipNotInAddressBook = True
            End If

            If boolEmailRecipNotInAddressBook Then
                '-- email address not in address book
                Dim strRecipAddress As String = recip.Address
                '-- Here we strip off the name and just validate the actual email address of the recip
                Dim emailAddressForRecip As System.Net.Mail.MailAddress
                Dim boolNotReallyEmailAddress As Boolean
                Try
                    emailAddressForRecip = New System.Net.Mail.MailAddress(strRecipAddress)
                Catch ex As Exception
                    boolNotReallyEmailAddress = True
                End Try
                If Not boolNotReallyEmailAddress AndAlso IsValidEmailAddress(emailAddressForRecip.Address) Then
                    '-- email user
                    item = New RecipientEntry(AddressBookEntryType.Email)
                    Dim strRecipFullName As String = recip.FullName
                    item.Address = emailAddressForRecip.Address
                    If emailAddressForRecip.DisplayName.Length = 0 Then
                        item.FullName = strRecipFullName
                    Else
                        item.FullName = emailAddressForRecip.DisplayName
                    End If

                    '-- If settings say to use address book's name instead of the display name from
                    '   the sender, then use it, unless it doesn't exist, then use the way it was sent
                    If Not AppSettings.EmailShowSenderAsSent Then
                        Dim abookEntry As AddressBookEntry = ABook.GetContactByAddress(item.Address) 'GetAddressBookEmailEntry(item.Address)
                        If abookEntry IsNot Nothing Then
                            item.FullName = abookEntry.FullName
                        End If
                    End If
                    intTotalOtherRecipients += 1
                Else
                    '-- current user
                    item = New RecipientEntry(AddressBookEntryType.TrulyMail)
                    item.FullName = AppSettings.FullName
                End If
            End If

            item.RecipientType = recip.RecipientType


            '-- If we sent this (have receive and view date) then
            '   we show the extra information
            If ReceivedColumn.IsVisible Then
                'Dim strDateReceived As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_RECEIVED)
                'If strDateReceived.Length > 0 Then
                item.ReceivedDate = recip.ReceivedDate 'ConvertToLocalTime(ConvertToDateFromXML(strDateReceived, Date.UtcNow))
                boolAtLeastOneReceiveDate = True
                'End If

                'Dim strDateRead As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_READ)
                'If strDateRead.Length > 0 Then
                item.ViewedDate = recip.ViewedDate ' ConvertToLocalTime(ConvertToDateFromXML(strDateRead, Date.UtcNow))
                boolAtLeastOneViewDate = True
                'End If
            End If

            'Dim strResent As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_RESENTDATE)
            'If strResent.Length > 0 Then
            boolAtLeastOneResentDate = True
            item.ResentDate = recip.ResentDate ' ConvertToLocalTime(ConvertToDateFromXML(strResent, Date.UtcNow))
            'End If

            lstRecipients.Add(item)
        Next

        '-- Now add email addresses 
        '   (this should only exist when a msg was sent to TM recip and also email recipts)
        Dim intTotalAddresses As Integer = 0
        'For Each xElement As Xml.XmlElement In xListAddresses
        '    Dim strRoleID As String = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID)
        '    Dim item As New RecipientEntry(AddressBookEntryType.Email)
        '    item.RecipientType = GetRecipientTypeByRoleID(strRoleID)

        '    item.Address = xElement.InnerText
        '    item.FullName = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME)
        '    intTotalOtherRecipients += 1

        '    lstRecipients.Add(item)
        'Next


        olvRecipients.SetObjects(lstRecipients)

        AutoSizeColumns(olvRecipients)

        '-- set the height to show all of the recipients
        '   but not more than 10 or less than two
        Dim intRecipientHeight As Integer = 45
        If lstRecipients.Count <= 10 Then
            intRecipientHeight += (18 * lstRecipients.Count)
        Else
            intRecipientHeight += (180)
        End If

        'NOT SURE this belongs here, since it's about attachments
        Dim intAttachmentHeight As Integer = 45
        Dim lstAttachments As List(Of AttachmentItem) = olvAttachments.Objects
        If lstAttachments.Count < 10 Then
            intAttachmentHeight += (18 * lstAttachments.Count)
        Else
            intAttachmentHeight += 180
        End If

        Dim intDistance As Integer
        '-- show the most recips or attachments, whichever is more (up to 10)
        intDistance = Math.Max(intRecipientHeight, intAttachmentHeight)
        intDistance = Math.Max(intDistance, SplitContainer2.Panel1MinSize)
        intDistance = Math.Min(intDistance, SplitContainer2.Width - SplitContainer2.Panel2MinSize)


        '-- This is a stupid work around but this bug was reported in 2006 (VS2005) and still exists in VS 2010 beta)
        '   so just try our best to set it and ignore if it throws an error
        Try
            SplitContainer2.SplitterDistance = intDistance
        Catch ex As Exception
            'Log(ex) '-- stopped logging 9 June 2011
        End Try
    End Sub
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

        Dim intViewedColumnPosition As Integer = 4
        If RecipientAddressColumn.ListView Is Nothing Then
            intViewedColumnPosition -= 1
        End If

        If entry.ReceivedDate = Date.MinValue Then
            If olvi.SubItems.Count > intViewedColumnPosition Then
                olvi.SubItems(intViewedColumnPosition).Text = String.Empty
            End If
        End If

        If entry.ViewedDate = Date.MinValue Then
            If olvi.SubItems.Count > intViewedColumnPosition + 1 Then
                olvi.SubItems(intViewedColumnPosition + 1).Text = String.Empty
            End If
        End If

        If entry.ResentDate = Date.MinValue Then
            If olvi.SubItems.Count > (intViewedColumnPosition + 2) Then
                olvi.SubItems(intViewedColumnPosition + 2).Text = String.Empty
            End If
        End If

        If entry.ContactType = AddressBookEntryType.TrulyMail Then
            olvi.SubItems(2).BackColor = Color.Gray
        End If
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
    Private Function AttachmentRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim attachment As AttachmentItem = CType(olvi.RowObject, AttachmentItem)

        If System.IO.File.Exists(attachment.Filename) Then
            If attachment.DuplicateDisplayName Then
                olvi.BackColor = Color.Yellow
                olvi.ToolTipText = "Duplicate filenames will be corrected when sending."
            Else
                '-- normal expected path (no dups, file exists)
                If AppSettings.DarkMode Then
                    olvi.BackColor = Color.Black
                Else
                    olvi.BackColor = Color.White
                End If
                olvi.ToolTipText = attachment.Filename
            End If
        Else
            olvi.BackColor = Color.Red
            olvi.ToolTipText = "File missing: " & attachment.Filename
        End If

    End Function

    Private Function AttachmentImageGetter(ByVal row As Object) As Object
        Try
            Dim item As AttachmentItem = row
            Dim strExtension As String = System.IO.Path.GetExtension(item.DisplayName).ToLower()
            If Not olvAttachments.SmallImageList.Images.ContainsKey(strExtension) Then
                Dim strTempFilename As String
                If item.Encrypted Then
                    strTempFilename = System.IO.Path.Combine(GetTempPath(), "a" & strExtension)
                    If Not System.IO.File.Exists(strTempFilename) Then
                        System.IO.File.WriteAllText(strTempFilename, " ")
                    End If
                Else
                    strTempFilename = item.Filename
                End If

                Dim icon As Icon = AssociatedIcon.GetAssociatedIconSmall(strTempFilename)
                olvAttachments.SmallImageList.Images.Add(strExtension, icon)
            End If
            Return strExtension
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
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
    Private Sub NotifyIfEmailSentFromTrulyMail()
        Dim boolEmail As Boolean
        Dim boolSendFromTrulyMail As Boolean
        Dim contact As AddressBookEntry

        Dim lst As List(Of NameValuePair) = m_tm.EmailHeaders
        ToolTip1.SetToolTip(llblFrom, String.Empty)

        '-- must be received email to get this attribute
        boolEmail = Not m_tm.Sent AndAlso m_tm.POPProfile IsNot Nothing

        If boolEmail Then
            If lst IsNot Nothing Then
                For Each namevalue As NameValuePair In lst
                    If (namevalue.Name = EMAIL_MAILER_HEADER_NAME_1 OrElse namevalue.Name = EMAIL_MAILER_HEADER_NAME_2) AndAlso namevalue.Value.ToLower.StartsWith("trulymail") Then
                        boolSendFromTrulyMail = True
                        Exit For
                    End If
                Next
            Else
                boolSendFromTrulyMail = False
            End If
        End If

        If boolSendFromTrulyMail AndAlso boolEmail Then
            llblFrom.BackColor = Color.Yellow
            ToolTip1.SetToolTip(llblFrom, "Sender sent this email from TrulyMail. Ask the sender to use encrypted email messages instead of clear-text (regular) email with you.")
        Else
            If m_tm.Sent = False Then '-- must be sent
                Dim entry As RecipientEntry = m_tm.Sender
                If entry IsNot Nothing Then '-- must have sender entry
                    contact = ABook.GetContactByID(entry.ID)
                    If contact Is Nothing Then
                        contact = ABook.GetContactByAddress(entry.Address)
                    End If
                End If

                If contact Is Nothing Then
                    '-- no contact, just email, so set tooltip
                    llblFrom.BackColor = SystemColors.Control
                    ToolTip1.SetToolTip(llblFrom, "Compose message to: " & llblFrom.Text)
                Else
                    '-- contact in address book, if not receive only, set tooltip
                    If contact.ReceiveOnly = False Then
                        llblFrom.BackColor = SystemColors.Control
                        ToolTip1.SetToolTip(llblFrom, "Compose message to: " & llblFrom.Text)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub lblFrom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblFrom.LinkClicked
        If e.Button = Windows.Forms.MouseButtons.Left Then
            '-- compose new message to sender
            Dim lst As New ArrayList
            Dim entry As AddressBookEntry
            '-- it is email address, use addressbook entry if possible
            entry = ABook.GetContactByAddress(m_tm.Sender.Address) 'GetAddressBookEmailEntry(m_strSenderEmailAddress)
            If entry Is Nothing Then
                entry = New AddressBookEntry()
                entry.ID = Guid.NewGuid.ToString()
                entry.ContactType = AddressBookEntryType.Email
                entry.Address = m_tm.Sender.Address
                entry.FullName = m_tm.Sender.FullName
            End If

            lst.Add(entry)

            Dim frm As IComposeForm

            If UseFallbackModeNow() Then
                frm = New NewMessageSimple(lst)
            Else
                frm = New NewMessage(lst)
            End If

            CType(frm, Form).Show()
        End If
    End Sub
#Region " Read Receipt Panel Logic "
    Private Sub HideReceiptProcessingPanel()
        Me.SplitContainer1.Panel2Collapsed = True
        Me.lvMessages.Visible = False
        pbFindMessagesForReceipts.Enabled = True
    End Sub
    Private Sub ShowReceiptProcessingPanel()
        Me.SplitContainer1.Panel2Collapsed = False
        Me.SplitContainer1.SplitterDistance = Math.Max(Me.SplitContainer1.Height - 50, 50)
        'Me.btnCloseReceiptPanel.Location = New Point(Panel1.Width - 69, 21)
        pbFindMessagesForReceipts.Enabled = True
    End Sub
    Private Sub SearchForMessages()
        Me.lvMessages.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf MainRowFormatter)
        Me.OlvColumnSize.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterSize)
        Me.OlvColumnMessageDate.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterDate)
        Me.OlvColumnSubject.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf MessageImageGetter)

        lvMessages.EmptyListMsg = "Searching for messages..."

        pbFindMessagesForReceipts.Enabled = False
        lvMessages.Visible = True

        Me.SplitContainer1.SplitterDistance = Math.Max(Me.SplitContainer1.Height - 200, 200)
        Me.lvMessages.Height = Math.Max(SplitContainer1.Panel2.Height - lvMessages.Top, 50)
        Me.lvMessages.Width = SplitContainer1.Panel2.Width
        Me.lvMessages.Left = 0

        '-- Now try to find the most appropriate messages
        '   If there is an MDNPart3.txt that is ideal as it may 
        '   have the TrulyMail-ID header which is great!

        Dim lst As List(Of AttachmentItem) = olvAttachments.Objects
        Dim strMDNPart3Filename As String = String.Empty
        For Each item As AttachmentItem In lst
            If item.DisplayName.ToLower = "mdnpart3.txt" Then
                '-- Good news
                strMDNPart3Filename = item.Filename
                Exit For
            End If
        Next

        Dim strTrulyMailMessageID As String = String.Empty
        If strMDNPart3Filename.Length > 0 Then
            Try
                '-- Look for the TrulyMail-ID header
                Dim strData As String = System.IO.File.ReadAllText(strMDNPart3Filename)
                Dim strLines() As String = strData.Split(Environment.NewLine)
                For Each strLine As String In strLines
                    Dim strNameValue() As String = strLine.Split(": ")
                    If strNameValue(0).Trim().ToLower() = "trulymail-id" Then
                        strTrulyMailMessageID = strNameValue(1).Trim.ToLower()
                    ElseIf strNameValue(0).Trim.ToLower() = "delivered-to" Then
                        m_strReadReceiptFromAddress = strNameValue(1).Trim
                    End If
                Next
            Catch ex As Exception
                Log(ex)
            End Try
        End If

        If strTrulyMailMessageID.Length > 0 Then
            '-- we have the message ID, now we just need to find the message
            '   first we search sent items
            Dim loader As New FileListLoader(REGEX_MESSAGE_FILENAME)
            Dim lstFiles As List(Of FileDetails) = loader.GetFilesInPath(SentItemsRootPath, True)
            Dim lstMessages As New List(Of TrulyMailMessage)
            Using msgIndex As New MessageIndex(SentItemsRootPath)

                For Each detail As FileDetails In lstFiles
                    If System.IO.Path.GetFileNameWithoutExtension(detail.Name) = strTrulyMailMessageID Then
                        '-- match
                        Dim tmm As TrulyMailMessage = msgIndex.GetMessage(detail)
                        If tmm IsNot Nothing Then
                            lstMessages.Add(tmm)
                            lvMessages.SetObjects(lstMessages)
                            'lvMessages.RebuildColumns()
                            Exit For
                        End If
                    End If
                Next
            End Using
        Else
            '-- if we got here then we do not have MDNPart3.txt
            '   All we have that we can depend on is the 
            '   recip's address in the body of the message and 
            '   the subject from the subject of this message

            '-- First, let's get the original subject
            Dim strOriginalSubject As String = String.Empty
            Dim boolEndsWithMatching As Boolean '-- True for outlook receipts since they remove leading 'Re:' and 'Fwd:'
            If txtSubject.Text.ToLower.StartsWith(READ_RECEIPT_READ_ENGLISH) Then '-- Outlook, Outlook Express
                strOriginalSubject = txtSubject.Text.Substring(READ_RECEIPT_READ_ENGLISH.Length).Trim
                boolEndsWithMatching = True '-- Outlook can send a read receipt to "Re: Something" as "READ: Something" so we must match using string.EndsWith
            ElseIf txtSubject.Text.ToLower.StartsWith(READ_RECEIPT_READ_ENGLISH_THUNDERBIRD_TRULYMAIL) Then '-- Thunderbird, TrulyMail
                strOriginalSubject = txtSubject.Text.Substring(READ_RECEIPT_READ_ENGLISH_THUNDERBIRD_TRULYMAIL.Length).Trim
                boolEndsWithMatching = False
            ElseIf txtSubject.Text.ToLower.StartsWith(READ_RECEIPT_READ_SPANISH) Then '-- outlook in Spanish
                strOriginalSubject = txtSubject.Text.Substring(READ_RECEIPT_READ_SPANISH.Length).Trim
                boolEndsWithMatching = True '-- Outlook can send a read receipt to "Re: Something" as "READ: Something" so we must match using string.EndsWith
            ElseIf txtSubject.Text.ToLower.StartsWith(READ_RECEIPT_READ_DUTCH) Then '-- outlook in dutch
                strOriginalSubject = txtSubject.Text.Substring(READ_RECEIPT_READ_DUTCH.Length).Trim
                boolEndsWithMatching = True '-- Outlook can send a read receipt to "Re: Something" as "READ: Something" so we must match using string.EndsWith
            ElseIf txtSubject.Text.ToLower.StartsWith(READ_RECEIPT_RECEIVED_DUTCH) Then '-- outlook in dutch
                strOriginalSubject = txtSubject.Text.Substring(READ_RECEIPT_RECEIVED_DUTCH.Length).Trim
                boolEndsWithMatching = True '-- DreamMail does not return and id of the original message
            ElseIf txtSubject.Text.ToLower.StartsWith(READ_RECEIPT_RECEIPT_ENGLISH) Then '-- outlook in dutch
                strOriginalSubject = txtSubject.Text.Substring(READ_RECEIPT_RECEIPT_ENGLISH.Length).Trim
                boolEndsWithMatching = True '-- DreamMail does not return and id of the original message
            Else
                '-- Last chance, assume the READ: is in another language and just take everything after the last colon (:)
                If txtSubject.Text.Contains(":") Then
                    strOriginalSubject = txtSubject.Text.Substring(txtSubject.Text.LastIndexOf(":") + 1).Trim
                    boolEndsWithMatching = True
                Else
                    ShowMessageBoxError("The original subject could not be found. This receipt is in an unknown format and cannot be processed." _
                                   & Environment.NewLine & Environment.NewLine & _
                                   "Please contact TrulyMail Support so they can add this format to future versions of TrulyMail.")
                    lvMessages.EmptyListMsg = "No matching messages found"
                    Exit Sub
                End If
            End If

            Dim strRecipientAddress As String

            If IsValidEmailAddress(m_tm.Sender.Address) Then
                strRecipientAddress = m_tm.Sender.Address
            Else
                strRecipientAddress = String.Empty
            End If

            Dim lstFound As List(Of TrulyMailMessage) = FindMessagesBySubject(strOriginalSubject, SentItemsRootPath, True, boolEndsWithMatching)

            'TODO: Parse body for recipient's email address
            Dim lstToShow As New List(Of TrulyMailMessage)
            For Each tmm As TrulyMailMessage In lstFound
                '-- Only consider messages where a return receipt was requested
                '   but ignore messages which have already been marked received by recip in question
                If tmm.ReturnReceiptRequested Then

                    If strRecipientAddress.Length > 0 Then
                        '-- Only include if the recipient is in the message
                        For Each recip As RecipientEntry In tmm.Recipients
                            If recip.ContactType = AddressBookEntryType.Email AndAlso recip.Address.ToLower = strRecipientAddress Then
                                If recip.ViewedDate = #12:00:00 AM# Then '-- Only show those messages not already marked as read
                                    lstToShow.Add(tmm)
                                End If
                                Exit For '-- don't run the risk of adding the same message twice because a recip is on the list twice
                            End If
                        Next
                    Else
                        '-- Include all of these messages
                        lstToShow.Add(tmm)
                    End If
                End If
            Next

            lvMessages.Sort(3) '-- sort by date

            '-- now load the grid
            If lstToShow.Count > 0 Then
                lvMessages.SetObjects(lstToShow)
            Else
                '-- Could not find any really good matches, just show all which match closely
                lvMessages.SetObjects(lstFound)
            End If
        End If

        lvMessages.EmptyListMsg = "No matching messages found"

        AutoSizeColumns(lvMessages)

    End Sub
    Private Sub OpenMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenMessageToolStripMenuItem.Click
        Dim tmm As TrulyMailMessage = lvMessages.GetSelectedObject()
        Globals.LoadMessage(tmm.Filename)
    End Sub
    Private Sub MarkMessageReadAndDeleteThisReceipt()
        Try
            Dim tmm As TrulyMailMessage = lvMessages.GetSelectedObject()
            Dim entry As AddressBookEntry
            Dim strRecipientID As String = String.Empty

            '-- If we didn't get the address from the read receipt, then use the sender's and 
            '   see if it works (should work 90%+ of the time)
            If m_strReadReceiptFromAddress.Length = 0 Then
                m_strReadReceiptFromAddress = m_tm.Sender.Address
            End If

            If m_strReadReceiptFromAddress.Length > 0 Then
                entry = ABook.GetContactByAddress(m_strReadReceiptFromAddress) 'GetAddressBookEmailEntry(m_strReadReceiptFromAddress)
                If entry IsNot Nothing Then
                    strRecipientID = entry.ID
                End If
            End If

            Dim boolProcessed As Boolean

            If strRecipientID.Length > 0 Then
                UpdateReadDateWithinMessage(tmm.Filename, strRecipientID, m_tm.MessageDateSent.ToString(DATEFORMAT_XML))
                boolProcessed = True
            Else
                If m_strReadReceiptFromAddress.Length > 0 Then
                    If Not UpdateReadDateWithinMessage(tmm.Filename, m_tm.MessageDateSent.ToString(DATEFORMAT_XML), m_strReadReceiptFromAddress, String.Empty) Then
                        ShowMessageBoxError("The recipient to update could not be automatically identified. Try opening the message, right-click on the recipient, and manually mark the message read.")
                    Else
                        boolProcessed = True
                    End If
                Else
                    '--This call will only work if there was a single recipient, but better to try, maybe we will get lucky
                    If Not UpdateReadDateWithinMessage(tmm.Filename, m_tm.MessageDateSent.ToString(DATEFORMAT_XML), m_strReadReceiptFromAddress, String.Empty) Then
                        ShowMessageBoxError("The recipient to update could not be automatically identified. Try opening the message, right-click on the recipient, and manually mark the message read.")
                    Else
                        boolProcessed = True
                    End If
                End If
            End If

            If boolProcessed Then
                RaiseEvent SpecialAction(MessageSpecialActionEnum.DeleteMessage)
            End If
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub
    Private Sub MarkMessageReadAndDeleteThisReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkMessageReadAndDeleteThisReceiptToolStripMenuItem.Click
        MarkMessageReadAndDeleteThisReceipt()

    End Sub
#End Region

    Private Function AspectToStringConverterDate(ByVal d As Date) As String
        If d.Date = Date.Today Then
            Return d.ToShortTimeString
        Else
            Return d.ToShortDateString & " " & d.ToShortTimeString
        End If
    End Function
    Private Function MainRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim msg As TrulyMailMessage = CType(olvi.RowObject, TrulyMailMessage)

        '-- unread messages should be bold
        If msg IsNot Nothing AndAlso msg.Read = False Then
            olvi.Font = New Font(olvi.Font, FontStyle.Bold)
            For intCounter As Integer = 0 To olvi.SubItems.Count - 1
                olvi.SubItems(intCounter).Font = olvi.Font
            Next
        End If

        If msg IsNot Nothing Then
            Dim intPositionAttachments As Integer = Me.lvMessages.Columns.IndexOf(Me.OlvColumnMessageAttachments)
            If msg.Attachments.Count = 0 Then
                olvi.SubItems(intPositionAttachments).Text = String.Empty
            End If
        End If

        If msg IsNot Nothing AndAlso msg.Sent Then
            olvi.UseItemStyleForSubItems = False

            '-- If message was not sent yet, then do show future sending date.
            Dim defaultDate As Date
            If msg.MessageDateSent = defaultDate Then
                Dim intPositionDate As Integer = Me.lvMessages.Columns.IndexOf(Me.OlvColumnMessageDate)
                olvi.SubItems(intPositionDate).Text = AspectToStringConverterDate(msg.MessageDateToSend).ToString()
                olvi.SubItems(intPositionDate).ForeColor = Color.Blue
            ElseIf msg.MessageDateUnsent > defaultDate Then
                Dim intPositionDate As Integer = Me.lvMessages.Columns.IndexOf(Me.OlvColumnMessageDate)
                olvi.SubItems(intPositionDate).ForeColor = Color.Red
            End If

            Dim intPositionReceived As Integer = Me.lvMessages.Columns.IndexOf(Me.OlvColumnReceived)
            Dim intPositionViewed As Integer = Me.lvMessages.Columns.IndexOf(Me.OlvColumnViewed)

            If intPositionReceived >= 0 AndAlso intPositionViewed >= 0 Then
                '-- format received column
                Select Case msg.Received
                    Case 0
                        olvi.SubItems(intPositionReceived).BackColor = Color.Pink
                    Case 1
                        olvi.SubItems(intPositionReceived).BackColor = Color.LightGreen
                    Case Else
                        olvi.SubItems(intPositionReceived).BackColor = Color.LightBlue
                End Select

                '-- format viewed column
                Select Case msg.Viewed
                    Case 0
                        olvi.SubItems(intPositionViewed).BackColor = Color.Pink
                    Case 1
                        olvi.SubItems(intPositionViewed).BackColor = Color.LightGreen
                    Case Else
                        olvi.SubItems(intPositionViewed).BackColor = Color.LightBlue
                End Select
            End If
        End If
    End Function
    Private Function MessageImageGetter(ByVal row As Object) As Object
        Dim msg As TrulyMailMessage = CType(row, TrulyMailMessage)
        If msg.Replied Then
            If msg.Forwarded Then
                '-- both
                Return 1
            Else
                '-- just replied
                Return 0
            End If
        Else
            If msg.Forwarded Then
                '-- just forwarded
                Return 2
            Else
                '-- no image
                Return Nothing
            End If
        End If
    End Function
    Private Sub ArrangeLabels()
        llblFrom.Width = llblFrom.Left + ((lblSentLabel.Left - llblFrom.Left) - 75)
        llblReplyTo.Left = (llblFrom.Left + llblFrom.Width) - (llblReplyTo.Width)
        txtSubject.Width = txtSubject.Left + ((lblSizeLabel.Left - txtSubject.Left) - (pnlHeaderAreaFull.Width - lblSizeLabel.Left))
    End Sub

    Private Sub ReadMessageControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtSubject.BackColor = SystemColors.Control

    End Sub
    Private Sub ReadMessageControl_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ArrangeLabels()
    End Sub

    Private Sub txtSubject_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtSubject.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub
    Friend Sub TreatAsReadReceipt()
        ShowReceiptProcessingPanel()
        SearchForMessages()
    End Sub
    Friend Sub ShowEmailHeaders()
        Dim lst As List(Of NameValuePair) = m_tm.EmailHeaders

        If lst IsNot Nothing AndAlso lst.Count > 0 Then
            Dim frm As New ListViewForm(lst)
            frm.Show()
        Else
            ShowMessageBox("There are no headers in this message.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Friend Sub PrintMessage()
        Dim strErrorLocation As String = "a"
        Try
            ClearIEFooter()
            strErrorLocation = "b"

            Dim strHTML As String = String.Empty '"<title>" & txtSubject.Text & "</title>"
            strHTML &= "<table width='100%' border='0'><tr><td>"
            strErrorLocation = "c"

            strHTML &= "<b>From:</b></td><td>" & llblFrom.Text & "</td>"
            strHTML &= "<td align='right'><b>Sent:</b></td><td align='right' nowrap>" & FormatDateTime(ConvertToLocalTime(m_tm.MessageDateSent)) & "</td></tr>"

            strErrorLocation = "d"


            Dim strEncryptedStatus As String = String.Empty
            Select Case m_EncryptionStatus
                Case EncryptionStatus.Encrypted
                    strEncryptedStatus = ENCRYPTED_TITLEBAR_TEXT
                Case EncryptionStatus.NotEncrypted
                    strEncryptedStatus = UNENCRYPTED_TITLEBAR_TEXT
                Case EncryptionStatus.PartiallyEncrypted
                    strEncryptedStatus = PARTIALLYENCRYPTED_TITLEBAR_TEXT
            End Select

            strErrorLocation = "e"

            strHTML &= "<tr><td valign='top'><b>Subject:</b></td><td>" & txtSubject.Text & "</td>" '& " " & strEncryptedStatus

            strErrorLocation = "f"

            strHTML &= "<td align='right'><b>Size:</b></td><td align='right'>" & lblMessageSize.Text & "</td></tr>"

            strErrorLocation = "g"


            '====================================================
            '=============== Attachments ========================
            '====================================================
            If olvAttachments.Items.Count > 0 Then
                strHTML &= "<td valign='top'><b>Attached:</b></td><td colspan='3'>"
                Dim strFileList As String = String.Empty
                For Each item As ListViewItem In olvAttachments.Items
                    strFileList &= "; " & item.Text
                Next
                If strFileList.Length > 2 Then
                    strFileList = strFileList.Substring(2)
                End If
                strHTML &= strFileList & "</td></tr>"
            End If

            strErrorLocation = "h"


            Dim strRecipientLabel As String
            If olvRecipients.Items.Count > 1 Then
                strRecipientLabel = "Recipients"
            Else
                strRecipientLabel = "Recipient"
            End If

            strErrorLocation = "i"

            strHTML &= "<td valign='top'><b>" & strRecipientLabel & ":</b></td><td colspan='3'>"
            Dim strRecipientList As String = String.Empty

            strErrorLocation = "j"

            '====================================================
            '=============== Recipients  ========================
            '====================================================
            Dim boolHasReceiveViewData As Boolean
            Dim strReceiveViewData As String
            For Each item As RecipientEntry In olvRecipients.Objects
                strReceiveViewData = String.Empty
                boolHasReceiveViewData = False

                '-- Calculate received and read dates
                If item.ReceivedDate > Date.MinValue Then
                    boolHasReceiveViewData = True
                    strReceiveViewData = "Rec: " & FormatDateTime(item.ReceivedDate)
                End If
                If item.ViewedDate > Date.MinValue Then
                    If boolHasReceiveViewData Then
                        strReceiveViewData &= "; "
                    End If
                    boolHasReceiveViewData = True
                    strReceiveViewData &= "Read: " & FormatDateTime(item.ViewedDate)
                End If
                If boolHasReceiveViewData Then
                    strReceiveViewData = "{" & strReceiveViewData & "}"
                End If


                Select Case item.RecipientType
                    Case RecipientType.Send_To
                        strRecipientList &= "; To: <STRONG>" & item.FullName & "</STRONG>"
                    Case RecipientType.Send_CC
                        strRecipientList &= "; CC: <STRONG>" & item.FullName & "</STRONG>"
                    Case RecipientType.Send_BCC
                        strRecipientList &= "; BCC: <STRONG>" & item.FullName & "</STRONG>"
                End Select
                strErrorLocation = "k"

                If item.Address.Length > 0 Then
                    strRecipientList &= " &lt;" & item.Address & "&gt;"
                End If
                strRecipientList &= " " & strReceiveViewData
                strErrorLocation = "l"
            Next

            strErrorLocation = "m"

            If strRecipientList.Length > 2 Then
                strRecipientList = strRecipientList.Substring(2)
            End If

            strErrorLocation = "n"
            strHTML &= strRecipientList & "</td></tr>"
            strErrorLocation = "o"

            strHTML &= "</table>"
            strHTML &= "<hr />"
            strHTML &= "<br />"
            strErrorLocation = "p"

            If WebBrowser2.Document IsNot Nothing AndAlso WebBrowser2.Document.Body IsNot Nothing Then
                WebBrowser2.Document.Body.InnerHtml = String.Empty
            Else
                WebBrowser2.DocumentText = "<html><body></body></html>"
            End If
            strErrorLocation = "q"

            Dim doc As mshtml.IHTMLDocument2 = CType(WebBrowser2.Document.DomDocument, mshtml.IHTMLDocument2)
            WebBrowser2.Document.Write(strHTML)
            strErrorLocation = "r"

            If Me.rtbBody.Visible Then
                For Each s As String In rtbBody.Lines
                    WebBrowser2.Document.Write("<P>" & s & "</P>")
                Next
            End If
            strErrorLocation = "s"

            doc.close()
            strErrorLocation = "t"

            Application.DoEvents()
            WebBrowser2.ShowPrintDialog()
            strErrorLocation = "u"

        Catch ex As Exception
            Log(ex)
            Log("Print Error Location: " & strErrorLocation)
            ShowMessageBoxError("There was an error trying to print. Please contact TrulyMail Support.")
        End Try
    End Sub
    Friend Sub AddNotes()
        NotesBodySplitContainer.Panel1Collapsed = False
        NotesEditToolStripButton.Enabled = True
    End Sub
    Friend Sub AppendNote(ByVal text As String)
        NotesBodySplitContainer.Panel1Collapsed = False
        NotesEditToolStripButton.PerformClick()
        If txtNotes.Text.Length > 0 Then
            txtNotes.AppendText(Environment.NewLine)
        End If
        txtNotes.AppendText(text)
        SaveNotes()
    End Sub
    Private Sub txtNotes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotes.TextChanged
        NotesSaveToolStripButton.Enabled = True
        m_boolNotesDirty = True
    End Sub

    Private Sub NotesEditToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotesEditToolStripButton.Click
        txtNotes.Enabled = True
        txtNotes.ReadOnly = False
        NotesEditToolStripButton.Enabled = False
    End Sub

    Private Sub NotesSaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotesSaveToolStripButton.Click
        SaveNotes()
    End Sub

    Private Sub SaveNotes()
        Try
            If m_tm IsNot Nothing Then
                m_tm.Notes = txtNotes.Text
                m_tm.Save()

                NotesSaveToolStripButton.Enabled = False
                m_boolNotesDirty = False
                MainFormReference.UpdateMessage(m_tm)
            Else
                '-- must be deleted, ignore
            End If

        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Sub
    Private Sub DeleteNotesToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteNotesToolStripButton.Click
        If System.IO.File.Exists(m_tm.Filename) Then
            If ShowMessageBox("Are you sure you want to permanently delete all notes related to this message?" & _
                              Environment.NewLine & Environment.NewLine & _
                              "Yes = Delete notes" & Environment.NewLine & _
                              "No = Do nothing", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                m_tm.RemoveNotes()
                m_tm.Save()

                NotesBodySplitContainer.Panel1Collapsed = True
                txtNotes.Enabled = False
                NotesEditToolStripButton.Enabled = True
                NotesSaveToolStripButton.Enabled = False

                m_boolNotesDirty = False
                MainFormReference.UpdateMessage(m_tm)
            End If
        Else
            ShowMessageBoxError("The message file could not be found. Perhaps it was deleted.")
        End If
    End Sub
    Private Sub olvAttachments_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles olvAttachments.ItemDrag
        'Dim files As String() = GetSelectedAttachents()
        'If files IsNot Nothing Then
        '    DoDragDrop(New DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy)
        'End If

        '-- in 5.1 changed this to decrypt if necessary then call DoDragDrop on decrypted files (so user can drag-and-drop out of TM even though attachments are encrypted)
        Dim intCounter As Integer = 0
        Dim strFilesToProcess() As String
        For Each item As AttachmentItem In olvAttachments.SelectedObjects
            ReDim Preserve strFilesToProcess(intCounter)
            '-- This routine will handle the decryption issues, if any
            strFilesToProcess(intCounter) = item.GetDecryptedFilenameToOpen
            intCounter += 1
        Next

        If strFilesToProcess IsNot Nothing Then
            DoDragDrop(New DataObject(DataFormats.FileDrop, strFilesToProcess), DragDropEffects.Copy)
        End If

    End Sub
    Private Function GetSelectedAttachents() As String()
        Dim strReturn() As String
        Dim intCounter As Integer = 0
        For Each item As AttachmentItem In olvAttachments.SelectedObjects
            ReDim Preserve strReturn(intCounter)
            strReturn(intCounter) = item.Filename
            intCounter += 1
        Next
        Return strReturn
    End Function
    Private Sub OpenSelectedAttachments()
        Dim lst As ArrayList = olvAttachments.GetSelectedObjects()
        For Each item As AttachmentItem In lst
            OpenAttachment(item.GetDecryptedFilenameToOpen())
        Next
    End Sub
    Private Sub olvAttachments_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvAttachments.ItemActivate
        OpenSelectedAttachments()
    End Sub

    Private Sub WebBrowser1_Navigating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs)
        Try
            If e.Url Is Nothing Then
                Log("Non-URL clicked")
            ElseIf e.Url.ToString.ToLower.StartsWith("about") Then
                '-- do nothing, must be initial load
            ElseIf e.Url.ToString.ToLower.StartsWith("mailto:") Then
                Dim frm As New NewMessage(e.Url.ToString(), True)
                frm.Show()
                e.Cancel = True
            ElseIf IsValidURL(e.Url.AbsoluteUri) Then
                e.Cancel = True
                System.Diagnostics.Process.Start(e.Url.AbsoluteUri)
            Else
                e.Cancel = True
                Log("Invalid URL: " & e.Url.AbsoluteUri)
                ShowMessageBoxError("The address (" & e.Url.AbsoluteUri & ") does not seem valid. Please contact the sender to send a valid link.")
            End If
        Catch ex As Exception
            Log(ex)
            If e.Url IsNot Nothing Then
                Log("URL: " & e.Url.ToString())
            End If
            ShowMessageBoxError("There was an error in TrulyMail (" & ex.Message & "). Please contact TrulyMail Support for assistance.")
        End Try
    End Sub
    Private Sub ProcessKeyDown(ByVal e As PreviewKeyDownEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.C
                    If e.Control Then
                        rtbBody.Copy()
                    End If
                Case Keys.D
                    If ModifierKeys = Keys.Control Then
                        RaiseEvent SpecialAction(MessageSpecialActionEnum.DeleteMessage)
                    ElseIf ModifierKeys = Keys.Control Or Keys.Shift Then
                        RaiseEvent SpecialAction(MessageSpecialActionEnum.DeleteMessage)
                        'Application.DoEvents()
                        'ShowBodyFullScreen()
                    End If
                Case Keys.N
                    If ModifierKeys = Keys.Control Then
                        RaiseEvent SpecialAction(MessageSpecialActionEnum.NewMessage)
                    End If
                Case Keys.P
                    If ModifierKeys = Keys.Control Then
                        PrintMessage()
                    End If
                Case Keys.F
                    If ModifierKeys = Keys.Control Then
                        RaiseEvent SpecialAction(MessageSpecialActionEnum.Forward)
                    ElseIf ModifierKeys = (Keys.Shift Or Keys.Control) Then
                        ShowFind()
                    End If
                Case Keys.R
                    If ModifierKeys = Keys.Control Then
                        If m_tm.CanReply Then
                            RaiseEvent SpecialAction(MessageSpecialActionEnum.Reply)
                        End If
                    ElseIf ModifierKeys = (Keys.Control Or Keys.Shift) Then
                        If m_tm.CanReplyAll Then
                            RaiseEvent SpecialAction(MessageSpecialActionEnum.ReplyAll)
                        End If
                    End If
                Case Keys.A
                    If ModifierKeys = Keys.Control Then
                        rtbBody.SelectAll()
                    End If
                Case Keys.F11
                    ShowBodyFullScreen()
                Case Keys.Add
                    If ModifierKeys = Keys.Control Then
                        ZoomUpOneStep()
                    End If
                Case Keys.Subtract
                    If ModifierKeys = Keys.Control Then
                        ZoomDownOneStep()
                    End If
            End Select
        Catch ex As Exception
            Log(ex) '-- log and ignore
        End Try
    End Sub
    Public Sub ShowBodyFullScreen()
        Try
            '-- create new form and maximize for browser
            '-- use richtextbox
            m_pnlReaderParentBeforeFullScreen = Me.rtbBody.Parent
            If m_frmFullScreen Is Nothing Then
                m_frmFullScreen = New BrowserFullScreenForm()
            End If

            m_frmFullScreen.LoadRTB(Me.rtbBody, m_tm.Filename)
            m_boolInFullScreenMode = True
            m_frmFullScreen.ShowDialog(Me)
            m_boolInFullScreenMode = False
            Me.rtbBody.Parent = m_pnlReaderParentBeforeFullScreen
            Me.rtbBody.BringToFront()

            m_frmFullScreen.Close()
            m_frmFullScreen.Dispose()
            m_frmFullScreen = Nothing
        Catch ex As Exception
            Log(ex) '-- log and ignore
        End Try
    End Sub
    Private Sub WebBrowser1_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
        Try
            ProcessKeyDown(e)
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub
    Private Sub RichTextBox1_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles rtbBody.PreviewKeyDown
        ProcessKeyDown(e)
    End Sub
    Private Sub RichTextBox1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles rtbBody.LinkClicked
        'System.Diagnostics.Process.Start(e.LinkText)
        System.Diagnostics.Process.Start("explorer.exe", e.LinkText) '-- Modified 28 Jan 2017 after realizing that the old way could allow running the link with elevated rights

    End Sub

    Private m_strSelectedEmailAddress As String = String.Empty '-- for right-click, copy email address
    Private Sub ctxmnuRecipients_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxmnuRecipients.Opening
        Dim ctxmnu As ContextMenuStrip = CType(sender, ContextMenuStrip)
        MarkReadToolStripMenuItem.Enabled = False
        Dim strEmailAddress As String

        If ctxmnu.SourceControl Is llblFrom Then
            strEmailAddress = m_tm.Sender.Address
            Dim entry As AddressBookEntry = ABook.GetContactByAddress(strEmailAddress) 'GetAddressBookEmailEntry(m_strSenderEmailAddress)
            If entry Is Nothing Then
                '-- can add
                AddToAddressBookToolStripMenuItem.Enabled = IsValidEmailAddress(strEmailAddress)
                AddToAddressBookToolStripMenuItem.Visible = True
                EditContactToolStripMenuItem.Visible = False
            Else
                '-- already there
                EditContactToolStripMenuItem.Visible = True
                AddToAddressBookToolStripMenuItem.Visible = False
            End If

            m_strSelectedEmailAddress = strEmailAddress
        ElseIf ctxmnu.SourceControl Is llblReplyTo Then
            strEmailAddress = llblReplyTo.Text.Substring(REPLY_TO.Length)
            Dim entry As AddressBookEntry = ABook.GetContactByAddress(strEmailAddress) 'GetAddressBookEmailEntry(llblReplyTo.Text.Substring(REPLY_TO.Length))
            If entry Is Nothing Then
                '-- can add
                AddToAddressBookToolStripMenuItem.Enabled = IsValidEmailAddress(strEmailAddress)
                AddToAddressBookToolStripMenuItem.Visible = True
                EditContactToolStripMenuItem.Visible = False
            Else
                '-- already there
                EditContactToolStripMenuItem.Visible = True
                AddToAddressBookToolStripMenuItem.Visible = False
            End If

            m_strSelectedEmailAddress = strEmailAddress
        ElseIf ctxmnu.SourceControl Is olvRecipients Then
            '-- Only enable add to address book if selected recipient is email address
            Dim entry As RecipientEntry = olvRecipients.GetSelectedObject()
            If entry IsNot Nothing AndAlso entry.ContactType = AddressBookEntryType.Email Then
                strEmailAddress = entry.Address
                Dim existingEntry As AddressBookEntry = ABook.GetContactByAddress(entry.Address) 'GetAddressBookEmailEntry(entry.Address)
                If existingEntry Is Nothing Then
                    AddToAddressBookToolStripMenuItem.Enabled = IsValidEmailAddress(strEmailAddress)
                    AddToAddressBookToolStripMenuItem.Visible = True
                    EditContactToolStripMenuItem.Visible = False
                Else
                    EditContactToolStripMenuItem.Visible = True
                    AddToAddressBookToolStripMenuItem.Visible = False
                End If

                '-- If message was sent, and the recip is email
                Dim dtDefault As New Date()
                If m_tm.Sent AndAlso entry.ViewedDate = dtDefault Then
                    MarkReadToolStripMenuItem.Enabled = True
                End If

                '-- Allow user to launch best-guess URL from here
                m_strSelectedEmailAddress = strEmailAddress
            Else
                m_strSelectedEmailAddress = String.Empty
                AddToAddressBookToolStripMenuItem.Enabled = False
                EditContactToolStripMenuItem.Visible = False
            End If
        End If

        If IsValidEmailAddress(m_strSelectedEmailAddress) Then
            LaunchURLToolStripMenuItem.Text = "&Launch www." & GetDomainFromEmailAddress(m_strSelectedEmailAddress)
            LaunchURLToolStripMenuItem.Tag = "www." & GetDomainFromEmailAddress(m_strSelectedEmailAddress)
            LaunchURLToolStripMenuItem.Visible = True
            LaunchSeparator.Visible = True
            CopyemailAddressToolStripMenuItem.Enabled = True
        Else
            LaunchURLToolStripMenuItem.Visible = False
            LaunchSeparator.Visible = False
            CopyemailAddressToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub CopyemailAddressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyemailAddressToolStripMenuItem.Click
        Try
            Clipboard.SetText(m_strSelectedEmailAddress)
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxAutoClose("There was an error copying the email address (" & ex.Message & ").", STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)
        End Try
    End Sub
    Private Sub AddToAddressBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToAddressBookToolStripMenuItem.Click
        '-- Add selected email address to address book
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim ctxmnu As ContextMenuStrip = menuItem.Owner

        Dim entry As RecipientEntry
        Dim addressBookEntry As New AddressBookEntry(AddressBookEntryType.Email)

        If ctxmnu.SourceControl Is llblFrom Then
            addressBookEntry.FullName = m_tm.Sender.FullName
            addressBookEntry.Address = m_tm.Sender.Address
        ElseIf ctxmnu.SourceControl Is llblReplyTo Then
            addressBookEntry.FullName = GetUserNameFromEmailAddress(llblReplyTo.Text.Substring(REPLY_TO.Length))
            addressBookEntry.Address = llblReplyTo.Text.Substring(REPLY_TO.Length)
        ElseIf ctxmnu.SourceControl Is olvRecipients Then
            entry = olvRecipients.GetSelectedObject()
            If entry.FullName.Trim.Length = 0 Then
                addressBookEntry.FullName = GetUserNameFromEmailAddress(entry.Address)
            Else
                addressBookEntry.FullName = entry.FullName
            End If
            addressBookEntry.Address = entry.Address
        End If

        Try
            If AppSettings.EmailAutoAddRecipientsTieSMTP Then
                If m_tm.SMTPProfile Is Nothing Then
                    If m_tm.POPProfile Is Nothing Then
                        '-- cannot connect to an account
                    Else
                        addressBookEntry.SMTPID = m_tm.POPProfile.SMTPProfileID
                    End If
                Else
                    addressBookEntry.SMTPID = m_tm.SMTPProfile.ID
                End If
            End If
        Catch ex As Exception
            Log(ex)
            Log("Error tying SMTPID to new contact ignored.")
        End Try


        'Dim tempEntry As AddressBookEntry = ABook.GetContactByAddress(addressBookEntry.Address)
        'If tempEntry Is Nothing Then
        Dim frm As New EditContactK()
        frm.FullName = addressBookEntry.FullName
        frm.EmailAddress = addressBookEntry.Address
        frm.SMTPID = addressBookEntry.SMTPID
        If frm.ShowDialog() = DialogResult.OK Then
            'ABook.Add(addressBookEntry)
            ABook.Save()
        End If
        'End If
    End Sub

    Private Sub MarkReadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkReadToolStripMenuItem.Click
        Dim entry As RecipientEntry = olvRecipients.GetSelectedObject()
        Dim strRecipID As String = entry.ID

        If strRecipID.Length > 0 Then
            UpdateReadDateWithinMessage(m_tm.Filename, strRecipID, Date.UtcNow.ToString(DATEFORMAT_XML))
        Else
            UpdateReadDateWithinMessage(m_tm.Filename, Date.UtcNow.ToString(DATEFORMAT_XML), entry.Address, entry.FullName)
        End If

        entry.ReceivedDate = Date.Now
        entry.ViewedDate = Date.Now
        olvRecipients.RefreshSelectedObjects()
    End Sub

    Private Sub LaunchURLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaunchURLToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start(LaunchURLToolStripMenuItem.Tag.ToString())
        Catch ex As Exception
            '-- Just best efforts
            Log(ex)
        End Try
    End Sub
    Private Sub ctxmnuAttachments_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxmnuAttachments.Opening
        Dim strFiles() As String = GetSelectedAttachents()
        If strFiles Is Nothing OrElse strFiles.Length = 0 Then
            SaveAsToolStripMenuItem.Enabled = False
            OpenAttachmentToolStripMenuItem.Enabled = False
            'OpenFileLocationToolStripMenuItem.Enabled = False
            CopyFileToolStripMenuItem.Enabled = False
        Else
            SaveAsToolStripMenuItem.Enabled = True
            OpenAttachmentToolStripMenuItem.Enabled = True
            'OpenFileLocationToolStripMenuItem.Enabled = True
            CopyFileToolStripMenuItem.Enabled = True
        End If

        If olvAttachments.Items.Count = 0 Then
            SaveallToolStripMenuItem.Enabled = False
        Else
            SaveallToolStripMenuItem.Enabled = True
        End If
    End Sub
    Private Sub SaveAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveallToolStripMenuItem.Click
        '-- User to select folder for attachments
        Dim fbd As New FolderBrowserDialog()
        fbd.ShowNewFolderButton = True
        fbd.Description = "Select destination folder for attachments."

        If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            '-- copy files to selected folder
            For Each item As AttachmentItem In olvAttachments.Objects
                If Not System.IO.File.Exists(item.Filename) Then
                    ShowMessageBoxError("'" & item.DisplayName & "' cannot be found. It might have been deleted manually.")
                Else
                    Dim strDestinationFilename As String = System.IO.Path.Combine(fbd.SelectedPath, item.DisplayName)
                    If System.IO.File.Exists(strDestinationFilename) Then
                        If ShowMessageBox(item.DisplayName & " already exists in the destination folder. Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                            Continue For
                        Else
                            Try
                                DeleteLocalFile(strDestinationFilename)
                            Catch ex As Exception
                                Log(ex)
                                ShowMessageBoxError(System.IO.Path.GetFileName(item.Filename) & " cannot be overwritten because it is use.")
                                Continue For
                            End Try
                        End If
                    End If
                    item.CopyDecryptdFileToLocation(strDestinationFilename) 'System.IO.File.Copy(item.Filename, strDestinationFilename)
                End If
            Next
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        If olvAttachments.SelectedItems.Count > 1 Then
            ShowMessageBoxError("Please select only one attachment to save, or save them all.")
            Exit Sub
        End If

        '-- use savefiledialog
        Dim sfd As New SaveFileDialog()
        Dim item As AttachmentItem = olvAttachments.GetSelectedObject
        If Not System.IO.File.Exists(item.Filename) Then
            ShowMessageBoxError("The attachment cannot be found. It might have been deleted manually.")
        Else
            If item IsNot Nothing Then
                sfd.OverwritePrompt = False
                sfd.FileName = item.DisplayName
                sfd.Filter = "All files|*.*"
                If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If System.IO.File.Exists(sfd.FileName) Then
                        If ShowMessageBox(sfd.FileName & " already exists. Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Try
                                DeleteLocalFile(sfd.FileName)
                            Catch ex As Exception
                                Log(ex)
                                ShowMessageBoxError(sfd.FileName & " cannot be overwritten because it is use.")
                                Exit Sub
                            End Try
                        End If
                    End If
                    item.CopyDecryptdFileToLocation(sfd.FileName)
                End If
            End If
        End If
    End Sub
    Private Sub OpenAttachmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenAttachmentToolStripMenuItem.Click
        OpenSelectedAttachments()
    End Sub
    Private Sub OpenFileLocationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFileLocationToolStripMenuItem.Click
        Dim lst As ArrayList = olvAttachments.GetSelectedObjects()
        If lst.Count > 0 Then
            Dim item As AttachmentItem = lst(0)
            Dim strFilename As String = item.Filename
            If Not System.IO.File.Exists(strFilename) Then
                ShowMessageBoxError("The attachment cannot be found. It might have been deleted manually.")
            Else
                Dim psi As New System.Diagnostics.ProcessStartInfo("explorer.exe", "/select, """ & strFilename & """")
                System.Diagnostics.Process.Start(psi) '"explorer.exe /select, ""C:\TrulyMailPortableJMA\Data\Profile\Attachments\0b4d177b-a901-427b-b5fb-d880b6160b94\D02EE404.txt""")
            End If
        Else
            If System.IO.Directory.Exists(AttachmentsRootPath & m_tm.MessageID) Then
                System.Diagnostics.Process.Start(AttachmentsRootPath & m_tm.MessageID)
            Else
                ShowMessageBoxError("The file location cannot be found. It might have been deleted manually.")
            End If
        End If
    End Sub

    Private Sub HideControl()
        If InvokeRequired Then
            Dim deleg As New NoParamSubDelegate(AddressOf HideControl)
            Invoke(deleg)
        Else
            Hide()
        End If
    End Sub

    Friend Sub ReadMessageAloud()
        If m_speech IsNot Nothing Then
            m_speech.SpeakAsyncCancelAll()
            m_speech.Dispose()
            m_speech = Nothing
        End If
        m_speech = New System.Speech.Synthesis.SpeechSynthesizer()

        Dim strToRead As String
        If rtbBody.SelectionLength > 0 Then
            strToRead = rtbBody.SelectedText
        Else
            strToRead = rtbBody.Text
        End If

        m_speech.SpeakAsync(strToRead)
    End Sub
    ''' <summary>
    ''' Sets either RTB or browser text
    ''' </summary>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Private Sub SetBodyText(text As String)
        If rtbBody.Visible Then
            Application.DoEvents()
        Else
            Application.DoEvents()
        End If
    End Sub
    ''' <summary>
    ''' Returns either RTB or Browser text
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetBodyText() As String
        Return rtbBody.Text
    End Function
    Friend Sub ReadMessagePause()
        If m_speech IsNot Nothing Then
            m_speech.Pause()
        End If
    End Sub
    Friend Sub ReadMessageResume()
        If m_speech IsNot Nothing Then
            m_speech.Resume()
        End If
    End Sub

    Private Sub tmrLoadMessage_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLoadMessage.Tick
        LoadMessageDelayed()
    End Sub

    Private Const ZOOM_100 As Integer = 3
    Private Sub ZoomUpOneStep()
        If tbZoom.Value = tbZoom.Maximum Then
            '-- do nothing
        Else
            tbZoom.Value += 1
        End If
    End Sub
    Private Sub ZoomDownOneStep()
        If tbZoom.Value = tbZoom.Minimum Then
            '-- do nothing
        Else
            tbZoom.Value -= 1
        End If
    End Sub
    Private Sub Zoom(ByVal zoomLevel As Byte)
        Try
            Dim dblValue As Double

            '-- I know it looks strange to hard code numbers lik 50, 75, 100 in the case statement below
            '   however, using a variable does not work. Might be a 32/64 bit issue, not sure
            '   but this is the only way I could get it to work

            Select Case zoomLevel
                Case 1
                    dblValue = 0.5
                Case 2
                    dblValue = 0.75
                Case 3
                    dblValue = 1
                Case 4
                    dblValue = 1.25
                Case 5
                    dblValue = 1.5
                Case 6
                    dblValue = 1.75
                Case 7
                    dblValue = 2
                Case 8
                    dblValue = 2.5
                Case 9
                    dblValue = 3
                Case 10
                    dblValue = 3.5
                Case Else
                    dblValue = 4
            End Select

            rtbBody.ZoomFactor = Convert.ToSingle(dblValue)
            lblZoomValue.Text = dblValue.ToString("0%")
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Private Sub lblZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblZoom.Click
        tbZoom.Value = ZOOM_100
    End Sub

    Private Sub tbZoom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbZoom.ValueChanged
        Zoom(tbZoom.Value)
    End Sub

    Private Sub lblZoomValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblZoomValue.Click
        tbZoom.Value = ZOOM_100
    End Sub

    Private Sub txtNotes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtNotes.LinkClicked
        Try
            System.Diagnostics.Process.Start(e.LinkText)
        Catch ex As Exception
            ShowMessageBoxError("There was an error with the link you clicked (" & e.LinkText & ")." & _
                           Environment.NewLine & Environment.NewLine & _
                           "If it looks correct, please contact TrulyMail Support.")
        End Try
    End Sub
    ''' <summary>
    ''' Returns selected filename if only one attachment is selected AND that attachment is an audio file
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SelectedAttachmentIsAudio() As String
        If olvAttachments.GetSelectedObjects.Count = 1 Then
            Dim item As AttachmentItem = olvAttachments.GetSelectedObject()
            Dim strExt As String = System.IO.Path.GetExtension(item.Filename).ToLower()
            If strExt.Trim.Length = 0 Then
                Return String.Empty
            Else
                Const VALID_AUDIO_EXTENSIONS As String = ".wav;.wma;cda;aif;aifc;aiff;mid;midi"
                If VALID_AUDIO_EXTENSIONS.Contains(strExt) Then
                    Return item.Filename
                Else
                    Return String.Empty
                End If
            End If
        Else
            Return String.Empty
        End If
    End Function

    Friend Sub ShowFind()
        pnlFind.Show()
        txtFindText.Focus()
        txtFindText.SelectAll()
    End Sub

    Private Sub CloseFindPanel()
        pnlFind.Hide()
    End Sub
    Private Sub picCloseFindPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCloseFindPanel.Click
        CloseFindPanel()
    End Sub

    Private Sub btnFindNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindNext.Click
        Try
            Dim intStart, intEnd As Integer
            intEnd = rtbBody.Text.Length
            intStart = rtbBody.SelectionStart + 1
            If intStart > intEnd Then
                intStart = 0
            End If

            If rtbBody.Find(txtFindText.Text, intStart, intEnd, RichTextBoxFinds.None) = -1 Then
                '-- not found, start from beginning
                If intStart > 0 Then
                    intStart = 0
                    If rtbBody.Find(txtFindText.Text, intStart, intEnd, RichTextBoxFinds.None) = -1 Then
                        '-- still not found, do nothing
                    Else
                        '-- found, show it
                        'rtbBody.ScrollToCaret()
                    End If
                End If
            Else
                '-- found, show it
                'rtbBody.ScrollToCaret()
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("Error: " & ex.Message)
        End Try

    End Sub

    Private Sub txtFindText_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFindText.KeyDown
        Select Case e.KeyCode
            Case Keys.Return, Keys.F3
                btnFindNext.PerformClick()
                e.Handled = True
            Case Keys.Escape
                CloseFindPanel()
        End Select
    End Sub
    Private Sub SetFindButtonText()
        If rtbBody.Visible Then
            btnFindNext.Text = "&Find next"
        Else
            btnFindNext.Text = "&Find all"
        End If
    End Sub
    Private Sub pnlFind_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlFind.VisibleChanged
        SetFindButtonText()
    End Sub

    Private Sub picCloseFindPanel_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCloseFindPanel.MouseEnter
        picCloseFindPanel.Image = My.Resources.close_hot_16
    End Sub

    Private Sub picCloseFindPanel_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCloseFindPanel.MouseLeave
        picCloseFindPanel.Image = My.Resources.close_cold_16
    End Sub

    Private Sub btnDecryptBody_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecrypt.Click
        Try
            Dim tm2tm As TM2TMMessageContents = DecryptBodyForTM2TM(txtDecryptionPassword.Text, m_tm.Body)

            If m_tm.Attachments.Count > 0 Then
                ProcessTM2TMAttachment(m_tm, m_tm.Attachments(0), txtDecryptionPassword.Text)
            End If

            m_tm.Subject = tm2tm.Subject

            '-- need to change the MessageID reference to match the incoming ID (not the sent ID)
            tm2tm.Body = tm2tm.Body.Replace(ATTACHMENTS_FOLDER_REPLACEMENT_CODE & MESSAGEID_REPLACEMENT_CODE, ATTACHMENTS_FOLDER_REPLACEMENT_CODE & m_tm.MessageID)
            m_tm.Body = tm2tm.Body

            m_tm.Save()
            LoadMessage(m_tm)
            MainFormReference.UpdateMessage(m_tm)

            If ShowMessageBox("Save this password for this sender to decrypt future messages automatically?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                '-- find contact in address book (create if needed)
                Dim entry As AddressBookEntry = ABook.GetContactByAddress(m_tm.Sender.Address)
                If entry Is Nothing Then
                    '-- create it
                    entry = New AddressBookEntry(AddressBookEntryType.Email)
                    entry.FullName = m_tm.Sender.FullName
                    entry.Address = m_tm.Sender.Address
                    entry.WebMailPassword = txtDecryptionPassword.Text
                    entry.LastMessageReceived = Date.UtcNow
                    entry.Added = Date.UtcNow
                    ABook.Add(entry)
                    ABook.Save()
                Else
                    '-- update it
                    entry.WebMailPassword = txtDecryptionPassword.Text
                    ABook.Save()
                End If
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error decrypting this message. Please make sure the password is correct.")
        End Try
    End Sub

    Private Sub llblRSSLink_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblRSSLink.LinkClicked
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                System.Diagnostics.Process.Start(llblRSSLink.Text)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error opening the link in your default browser.")
        End Try
    End Sub

    Private Sub EditContactToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditContactToolStripMenuItem.Click
        Dim intErrorLocation As Integer
        Try
            '-- Add selected email address to address book
            Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
            intErrorLocation = 1
            Dim ctxmnu As ContextMenuStrip = menuItem.Owner
            intErrorLocation = 2

            Dim entry As RecipientEntry
            Dim addressBookEntry As AddressBookEntry

            intErrorLocation = 3
            If ctxmnu.SourceControl Is llblFrom Then
                intErrorLocation = 4
                addressBookEntry = ABook.GetContactByAddress(m_tm.Sender.Address)
            ElseIf ctxmnu.SourceControl Is llblReplyTo Then
                intErrorLocation = 6
                addressBookEntry = ABook.GetContactByAddress(llblReplyTo.Text.Substring(REPLY_TO.Length))
            ElseIf ctxmnu.SourceControl Is olvRecipients Then
                intErrorLocation = 7
                entry = olvRecipients.GetSelectedObject()
                intErrorLocation = 8
                addressBookEntry = ABook.GetContactByAddress(entry.Address)
            End If
            intErrorLocation = 9
            If addressBookEntry IsNot Nothing Then
                intErrorLocation = 10
                Dim frm As New EditContactK(addressBookEntry.ID)
                intErrorLocation = 11
                frm.ShowDialog()
                intErrorLocation = 12
            End If

        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error loading this contact. Please contact TrulyMail Support.")
        End Try
    End Sub

    Private Sub CopyLinkAddressToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyLinkAddressToolStripMenuItem.Click
        Clipboard.SetText(llblRSSLink.Text)
    End Sub

    Private Sub AddMessageProcessingruleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewMessageProcessingruleToolStripMenuItem.Click
        Try
            Dim rule As New ProcessingRule()
            rule.MatchType = ProcessingRuleMatchTypeEnum.MatchAnd
            Dim matchData As New ProcessingRuleMatchData()

            Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
            Dim ctxmnu As ContextMenuStrip = menuItem.Owner


            If ctxmnu.SourceControl Is llblFrom Then
                matchData.MatchField = ProcessingRuleMatchFieldEnum.FieldFrom

                'If m_tm.Sender.ContactType = AddressBookEntryType.TrulyMail Then
                '    If m_tm.Sent Then
                '        'rule.TriggerType = ProcessingRuleTriggerTypeEnum.SendMessage
                '        '-- do nothing, msg was sent so I am the sender (actually, cannot get here)
                '        Exit Sub
                '    Else
                '        '-- received
                '        rule.TriggerType = ProcessingRuleTriggerTypeEnum.ReceiveMessage
                '    End If
                '    matchData.CompareType = ProcessingRuleMatchDataCompareTypeEnum.SpecificTrulyMailContact
                '    matchData.CompareValue = m_tm.Sender.ID

                'ElseIf m_tm.Sender.ContactType = AddressBookEntryType.Email Then
                If m_tm.Sender.ContactType = AddressBookEntryType.Email Then
                    If m_tm.Sent Then
                        rule.TriggerType = ProcessingRuleTriggerTypeEnum.SendMessage
                    Else
                        '-- received
                        rule.TriggerType = ProcessingRuleTriggerTypeEnum.ReceiveMessage
                    End If

                    '-- if sender is in address book, then use specific email contact
                    '   otherwise, match on address
                    matchData.CompareType = ProcessingRuleMatchDataCompareTypeEnum.EmailAddressContains
                    Dim emlAddr As New System.Net.Mail.MailAddress(llblFrom.Text)
                    matchData.CompareValue = emlAddr.Address

                End If
            ElseIf ctxmnu.SourceControl Is olvRecipients Then
                Dim recip As RecipientEntry = olvRecipients.GetSelectedObject()
                If m_tm.Sent Then
                    rule.TriggerType = ProcessingRuleTriggerTypeEnum.SendMessage
                Else
                    rule.TriggerType = ProcessingRuleTriggerTypeEnum.ReceiveMessage
                End If

                'If recip.ContactType = AddressBookEntryType.TrulyMail Then
                '    If recip.ID = String.Empty Then
                '        '-- recip = user's own TM account
                '        ShowMessageBox("Cannot create a rule for this combinaion.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                '        Exit Sub
                '    Else
                '        matchData.MatchField = ProcessingRuleMatchFieldEnum.FieldToOrCC
                '        matchData.CompareType = ProcessingRuleMatchDataCompareTypeEnum.SpecificTrulyMailContact
                '        matchData.CompareValue = recip.ID
                '    End If
                'ElseIf recip.ContactType = AddressBookEntryType.Email Then
                If recip.ContactType = AddressBookEntryType.Email Then
                    matchData.CompareType = ProcessingRuleMatchDataCompareTypeEnum.EmailAddressContains
                    Dim emlAddr As New System.Net.Mail.MailAddress(recip.Address)
                    matchData.CompareValue = emlAddr.Address
                End If

                Select Case recip.RecipientType
                    Case RecipientType.Send_To
                        matchData.MatchField = ProcessingRuleMatchFieldEnum.FieldTo
                    Case RecipientType.Send_CC
                        matchData.MatchField = ProcessingRuleMatchFieldEnum.FieldCC
                    Case RecipientType.Send_BCC
                        matchData.MatchField = ProcessingRuleMatchFieldEnum.FieldBCC
                End Select
            End If

            rule.MatchDatas.Add(matchData)
            rule.Name = "New processing rule created " & Date.Now.ToString("yyyy-MM-dd hh:mm")

            Dim action As New ProcessingRuleActionData()
            action.ActionType = ProcessingRuleActionTypeEnum.MoveMessageTo

            action.ActionValue = InBoxRootPath
            rule.Actions.Add(action)

            AppSettings.ProcessingRules.Add(rule)

            CreateNewProcessingRule(rule, Me.ParentForm)
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error trying to create the new processing rule. Please contact TrulyMail Support.")
        End Try
    End Sub

    Private Sub pbReturnReceiptInfo_Click(sender As System.Object, e As System.EventArgs) Handles pbReturnReceiptInfo.Click
        Dim strMessage As String = "Unlike TrulyMail messages, email return receipts are not automatic." & _
                                    Environment.NewLine & Environment.NewLine & _
                                    "When you receive a read receipt for a message, you still have to match it to the original message." & _
                                    Environment.NewLine & Environment.NewLine & _
                                    "Click the 'Search' button to find the best possible matches then right click on the message to apply the receipt."

        ShowMessageBox(strMessage, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub pbFindMessagesForReceipts_Click(sender As System.Object, e As System.EventArgs) Handles pbFindMessagesForReceipts.Click
        SearchForMessages()
    End Sub

    Private Sub pbCloseReceiptPanel_Click(sender As System.Object, e As System.EventArgs) Handles pbCloseReceiptPanel.Click
        HideReceiptProcessingPanel()

        If chkDoNotShowProcessReceiptPanel.Checked Then
            AppSettings.DoNotProcessEmailReceipts = True
            AppSettings.Save()
            Me.SplitContainer1.Panel2Collapsed = True
        End If
    End Sub

    Private Sub pbRemoteImageInfo_Click(sender As System.Object, e As System.EventArgs)
        Dim strMessage As String = "Remote images are contained on a server somewhere." & _
                                    Environment.NewLine & Environment.NewLine & _
                                    "To show them means communicating with that server. This can be a security risk." & _
                                    Environment.NewLine & Environment.NewLine & _
                                    "You can configure when you load remote images and when you do not in the address book."

        ShowMessageBox(strMessage, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub LoadReplyModes()
        Try
            If m_tm Is Nothing Then
                '-- no actions
                olvReplyModes.ClearObjects()
            Else
                Dim lst As New List(Of ReplyMode)
                For Each mode As ReplyMode In AppSettings.AllReplyModes
                    If m_tm.Sent Then
                        If mode.ForSentMessages Then
                            lst.Add(mode)
                        End If
                    Else
                        If mode.ForReceivedMessages Then
                            If m_tm.MessageType = MessageType.Communication Then
                                If mode.IncludesAttachments Then
                                    If m_tm.Attachments.Count > 0 Then
                                        If mode.IsReplyAll Then
                                            If m_tm.Recipients.Count > 1 Then
                                                lst.Add(mode)
                                            End If
                                        Else
                                            lst.Add(mode)
                                        End If
                                    End If
                                ElseIf mode.IsReplyAll Then
                                    If m_tm.Recipients.Count > 1 Then
                                        lst.Add(mode)
                                    End If
                                Else
                                    lst.Add(mode)
                                End If
                            Else
                                '-- Cannot reply to other message types
                                If Not mode.IsReply Then
                                    If mode.IncludesAttachments Then
                                        If m_tm.Attachments.Count > 0 Then
                                            lst.Add(mode)
                                        End If
                                    Else
                                        lst.Add(mode)
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
                olvReplyModes.SetObjects(lst)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error creating the message actions. " & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub olvReplyModes_ItemActivate(sender As System.Object, e As System.EventArgs) Handles olvReplyModes.ItemActivate
        Try
            If olvReplyModes.SelectedItem IsNot Nothing Then
                Select Case olvReplyModes.SelectedItem.Text
                    Case "Reply to sender"
                        ReplyToSender(m_tm.Filename)
                    Case "Reply to sender without body"
                        ReplyToSenderNoBody(m_tm.Filename)
                    Case "Reply to all"
                        ReplyToAll(m_tm.Filename)
                    Case "Reply to all without body"
                        ReplyToAllNoBody(m_tm.Filename)
                    Case "Forward with attachments"
                        ForwardMessage(m_tm.Filename)
                    Case "Forward without attachments"
                        ForwardMessageNoAttachments(m_tm.Filename)
                    Case "Follow up"
                        FollowUpMessage(m_tm.Filename)
                    Case "resend"
                        ResendMessage(m_tm.Filename)
                    Case "Reply with attachments"
                        ReplyToSender(m_tm.Filename, True)
                    Case "Reply all with attachments"
                        ReplyToAll(m_tm.Filename, True)
                End Select
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error performing your selected action on this message." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub
    Friend Property ReplyModeVisible As Boolean
        Get
            Return SplitContainerReaderReplyBox.Panel2Collapsed = False
        End Get
        Set(value As Boolean)
            SplitContainerReaderReplyBox.Panel2Collapsed = Not value
        End Set
    End Property
    Friend Event ReadMessageActionSplitterDistanceChanged(splitterDistance As Integer)

    Friend Property ReadMessageActionSplitterDistance As Integer
        Get
            Return SplitContainerReaderReplyBox.Width - SplitContainerReaderReplyBox.SplitterDistance
        End Get
        Set(value As Integer)
            SplitContainerReaderReplyBox.SplitterDistance = SplitContainerReaderReplyBox.Width - value
        End Set
    End Property

    Private Sub SplitContainerReaderReplyBox_SplitterMoved(sender As System.Object, e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainerReaderReplyBox.SplitterMoved
        Try
            RaiseEvent ReadMessageActionSplitterDistanceChanged(SplitContainerReaderReplyBox.Width - SplitContainerReaderReplyBox.SplitterDistance)
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub lvMessages_ItemActivate(sender As System.Object, e As System.EventArgs) Handles lvMessages.ItemActivate
        MarkMessageReadAndDeleteThisReceipt()
    End Sub
    ''' <summary>
    ''' Handles any processing needed when there are no more msgs in the current folder
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub NothingToDisplay()
        If m_frmFullScreen IsNot Nothing Then
            Me.rtbBody.Parent = m_pnlReaderParentBeforeFullScreen
            Me.rtbBody.BringToFront()

            m_frmFullScreen.Close()
            m_frmFullScreen.Dispose()
            m_frmFullScreen = Nothing

            m_boolInFullScreenMode = False

        End If
    End Sub

    Private Sub ctxReadText_Opening(sender As Object, e As CancelEventArgs) Handles ctxReadText.Opening
        Try
            Dim menu As ContextMenuStrip = CType(sender, ContextMenuStrip)
            Dim ctrl As Control = menu.SourceControl

            If ctrl.Name = rtbBody.Name Then
                If rtbBody.SelectedText.Length = 0 Then
                    Me.CopyToolStripMenuItem.Enabled = False
                End If
                CutToolStripMenuItem.Visible = False
                PasteToolStripMenuItem.Visible = False
            ElseIf ctrl.Name = txtNotes.Name Then
                Me.CopyToolStripMenuItem.Enabled = txtNotes.SelectedText.Length > 0
                Me.CutToolStripMenuItem.Enabled = txtNotes.SelectedText.Length > 0

                CutToolStripMenuItem.Visible = True
                PasteToolStripMenuItem.Visible = True

                PasteToolStripMenuItem.Enabled = Clipboard.ContainsText()
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            Dim menu As ContextMenuStrip = CType(sender, ToolStripMenuItem).GetCurrentParent
            Dim ctrl As Control = menu.SourceControl

            If ctrl.Name = rtbBody.Name Then
                Clipboard.SetText(rtbBody.SelectedText)
            ElseIf ctrl.Name = txtNotes.Name Then
                Clipboard.SetText(txtNotes.SelectedText)
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        Try
            Dim menu As ContextMenuStrip = CType(sender, ToolStripMenuItem).GetCurrentParent
            Dim ctrl As Control = menu.SourceControl

            If ctrl.Name = rtbBody.Name Then
                Clipboard.SetText(rtbBody.SelectedText)
                rtbBody.SelectedText = String.Empty
            ElseIf ctrl.Name = txtNotes.Name Then
                Clipboard.SetText(txtNotes.SelectedText)
                txtNotes.SelectedText = String.Empty
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        txtNotes.SelectedText = Clipboard.GetText
    End Sub


    Private Sub CopyFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyFileToolStripMenuItem.Click
        Try

            Dim intCounter As Integer = 0
            Dim strFilesToProcess() As String
            For Each item As AttachmentItem In olvAttachments.SelectedObjects
                ReDim Preserve strFilesToProcess(intCounter)
                '-- This routine will handle the decryption issues, if any
                strFilesToProcess(intCounter) = item.GetDecryptedFilenameToOpen
                intCounter += 1
            Next

            If strFilesToProcess IsNot Nothing Then
                Clipboard.SetDataObject(New DataObject(DataFormats.FileDrop, strFilesToProcess))
            End If

        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub NewEmailToThisContactToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewEmailToThisContactToolStripMenuItem.Click
        Dim intErrorLocation As Integer
        Try
            '-- Add selected email address to address book
            Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
            intErrorLocation = 1
            Dim ctxmnu As ContextMenuStrip = menuItem.Owner
            intErrorLocation = 2

            Dim strName, strAddress As String
            Dim entry As RecipientEntry

            intErrorLocation = 3
            If ctxmnu.SourceControl Is llblFrom Then
                intErrorLocation = 4
                strName = m_tm.Sender.FullName
                strAddress = m_tm.Sender.Address
            ElseIf ctxmnu.SourceControl Is llblReplyTo Then
                intErrorLocation = 6
                strName = String.Empty
                strAddress = llblReplyTo.Text.Substring(REPLY_TO.Length)
            ElseIf ctxmnu.SourceControl Is olvRecipients Then
                intErrorLocation = 7
                entry = olvRecipients.GetSelectedObject()
                intErrorLocation = 8
                strName = entry.FullName
                strAddress = entry.Address
            End If
            intErrorLocation = 9

            If strAddress IsNot Nothing Then
                intErrorLocation = 10
                Dim msg As NewMessageSimple = MainFormReference.NewMessage()
                msg.AddRecipient(strName, strAddress)
                intErrorLocation = 12
            End If

        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error loading this contact. Please contact TrulyMail Support.")
        End Try
    End Sub
    Private Sub OpenSelectedEmbeddedImages()
        Dim lst As ArrayList = olvEmbeddedImages.GetSelectedObjects()
        For Each item As AttachmentItem In lst
            OpenAttachment(item.Filename)
        Next
    End Sub

    Private Sub olvEmbeddedImages_ItemActivate(sender As Object, e As EventArgs) Handles olvEmbeddedImages.ItemActivate
        OpenSelectedEmbeddedImages()
    End Sub

    Private Sub mnuEmbeddedSaveAs_Click(sender As Object, e As EventArgs) Handles mnuEmbeddedSaveAs.Click
        If olvEmbeddedImages.SelectedItems.Count > 1 Then
            ShowMessageBoxError("Please select only one attachment to save, or save them all.")
            Exit Sub
        End If

        '-- use savefiledialog
        Dim sfd As New SaveFileDialog()
        Dim item As AttachmentItem = olvEmbeddedImages.GetSelectedObject
        If item Is Nothing Then
            Exit Sub
        End If
        If Not System.IO.File.Exists(item.Filename) Then
            ShowMessageBoxError("The attachment cannot be found. It might have been deleted manually.")
        Else
            If item IsNot Nothing Then
                sfd.OverwritePrompt = False
                sfd.FileName = item.DisplayName
                sfd.Filter = "All files|*.*"
                If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If System.IO.File.Exists(sfd.FileName) Then
                        If ShowMessageBox(sfd.FileName & " already exists. Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Try
                                DeleteLocalFile(sfd.FileName)
                            Catch ex As Exception
                                Log(ex)
                                ShowMessageBoxError(sfd.FileName & " cannot be overwritten because it is use.")
                                Exit Sub
                            End Try
                        End If
                    End If
                    item.CopyDecryptdFileToLocation(sfd.FileName)
                End If
            End If
        End If
    End Sub

    Private Sub mnuEmbeddedSaveAll_Click(sender As Object, e As EventArgs) Handles mnuEmbeddedSaveAll.Click
        '-- User to select folder for attachments
        Dim fbd As New FolderBrowserDialog()
        fbd.ShowNewFolderButton = True
        fbd.Description = "Select destination folder for attachments."

        If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            '-- copy files to selected folder
            For Each item As AttachmentItem In olvEmbeddedImages.Objects
                If Not System.IO.File.Exists(item.Filename) Then
                    ShowMessageBoxError("'" & item.DisplayName & "' cannot be found. It might have been deleted manually.")
                Else
                    Dim strDestinationFilename As String = System.IO.Path.Combine(fbd.SelectedPath, item.DisplayName)
                    If System.IO.File.Exists(strDestinationFilename) Then
                        If ShowMessageBox(item.DisplayName & " already exists in the destination folder. Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                            Continue For
                        Else
                            Try
                                DeleteLocalFile(strDestinationFilename)
                            Catch ex As Exception
                                Log(ex)
                                ShowMessageBoxError(System.IO.Path.GetFileName(item.Filename) & " cannot be overwritten because it is use.")
                                Continue For
                            End Try
                        End If
                    End If
                    item.CopyDecryptdFileToLocation(strDestinationFilename) 'System.IO.File.Copy(item.Filename, strDestinationFilename)
                End If
            Next
        End If
    End Sub
End Class


