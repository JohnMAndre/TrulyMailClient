Module AddressBookSupport

    'Friend Enum EncryptMessagesOption
    '    UseMessage '-- encrypted if msg is set to encrypted
    '    Always
    '    Never
    'End Enum
    Friend Class AddressBookEntry
        Implements IComparable(Of AddressBookEntry)

        Private m_boolAutoRequestReadReceipt As Boolean '-- only applicable for email contacts
        Private m_AutoSendReadReceipt As ContactReceiptOption '-- only applicable for email contacts
        Private m_strAddress As String = String.Empty '-- only for email contact types
        Private m_boolReceiveOnlyCanChange As Boolean

        Public Property ID As String
        Public Property FullName As String
        Public Property RemoteImages As Boolean
        Public Property Added As Date
        Public ReadOnly Property AddedDisply As Date
            Get
                Return ConvertToLocalTime(Added)
            End Get
        End Property
        Public ReadOnly Property FormattedAsStandard As String
            Get
                Return FullName & " <" & m_strAddress & ">"
            End Get
        End Property
        Public Property Blocked As Boolean
        Public Property ContactType As AddressBookEntryType
        Public Property Tags As String '-- things like 'work' and 'family updates' - can use this in place of groups
        Public Property Active As Boolean '-- false = deleted, used for email contacts only
        Public Property LastMessageReceived As Nullable(Of Date)
        Public Property LastMessageSent As Nullable(Of Date)
        Public Property RemindReceiveEveryXDays As Integer
        Public Property RemindSendEveryXDays As Integer
        Public Property ImportanceRating As Integer
        'Public Property EncryptMessages As EncryptMessagesOption
        Public Property ReceiveOnlyCanChange As Boolean
        Public Property WebMailQuestion As String = String.Empty
        Public Property WebMailPassword As String = String.Empty

        Public Property PhoneWork As String
        Public Property PhoneHome As String
        Public Property PhoneMobile As String
        Public Property Custom1 As String
        Public Property Custom2 As String
        Public Property Custom3 As String
        Public Property Custom4 As String
        Public Property WebPage As String
        Public Property Notes As String
        Public Property SMTPID As String '-- ID of SMTP account to default to (only used for email contacts)
        Public Property TrulyMailVersion As String = String.Empty '-- which version of TrulyMail they are using, used for determining which encryption we can use
        Private m_Picture As Image

        Public Sub New(ByVal type As AddressBookEntryType)
            Active = True
            Added = Date.UtcNow
            ID = Guid.NewGuid.ToString()
            ContactType = type
            ReceiveOnlyCanChange = True
            'Select Case type
            '    Case AddressBookEntryType.TrulyMail
            '        EncryptMessages = EncryptMessagesOption.Always
            '        RemoteImages = True
            '    Case AddressBookEntryType.Email
            '        RemoteImages = False
            '        EncryptMessages = EncryptMessagesOption.UseMessage
            'End Select

        End Sub
        Public Sub New()
            Active = True
            Added = Date.UtcNow
            ReceiveOnlyCanChange = True
            ID = Guid.NewGuid.ToString()
        End Sub

        Private m_boolReceiveOnly As Boolean
        Public Property SMTPProfile As SMTPProfile
            Get
                If Me.SMTPID IsNot Nothing AndAlso Me.SMTPID.Length > 0 Then
                    Return SMTPProfile.GetByID(Me.SMTPID)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As SMTPProfile)
                If value IsNot Nothing Then
                    Me.SMTPID = value.ID
                End If
            End Set
        End Property
        Public Property ReceiveOnly() As Boolean
            Get
                Return m_boolReceiveOnly
            End Get
            Set(ByVal value As Boolean)
                If ReceiveOnlyCanChange Then
                    m_boolReceiveOnly = value
                Else
                    '-- do nothing
                End If
            End Set
        End Property

        Public Property Picture As Image
            Get
                If m_Picture Is Nothing Then
                    If System.IO.File.Exists(GetContactPicturePath()) Then
                        m_Picture = Image.FromFile(GetContactPicturePath())
                    End If
                End If

                Return m_Picture
            End Get
            Set(ByVal value As Image)
                m_Picture = value
            End Set
        End Property

        Public Property Address() As String
            Get
                Return m_strAddress
            End Get
            Set(ByVal value As String)
                If ContactType = AddressBookEntryType.TrulyMail Then
                    If value.Length > 0 Then
                        m_strAddress = String.Empty
                        Throw New Exception("A TrulyMail contact never has an email address.")
                    Else
                        m_strAddress = value
                    End If
                Else
                    If IsValidEmailAddress(value.Trim()) Then
                        m_strAddress = value.Trim()
                    Else
                        Log("Invalid email address: " & value)
                        Throw New Exception("Invalid email address format.")
                    End If
                End If
            End Set
        End Property

        Public Property AutoSendReadReceipt() As ContactReceiptOption
            Get
                If ContactType = AddressBookEntryType.TrulyMail Then
                    '-- TrulyMail contacts don't use this property
                    Return ContactReceiptOption.Always
                Else
                    Return m_AutoSendReadReceipt
                End If
            End Get
            Set(ByVal value As ContactReceiptOption)
                m_AutoSendReadReceipt = value
            End Set
        End Property
        Public Property AutoRequestReadReceipt() As Boolean
            Get
                If ContactType = AddressBookEntryType.TrulyMail Then
                    '-- TrulyMail contacts don't use this property
                    Return True
                Else
                    Return m_boolAutoRequestReadReceipt
                End If
            End Get
            Set(ByVal value As Boolean)
                m_boolAutoRequestReadReceipt = value
            End Set
        End Property

        Public Function CompareTo(ByVal other As AddressBookEntry) As Integer Implements System.IComparable(Of AddressBookEntry).CompareTo
            Return FullName.CompareTo(other.FullName)
        End Function
        Public ReadOnly Property NameWithAddress() As String
            Get
                If ContactType = AddressBookEntryType.Email Then
                    Return FullName & " <" & Address & ">"
                Else
                    Return FullName
                End If
            End Get
        End Property
        Private Function GetContactPicturePath() As String
            Return PictureRootPath & ID & CONTACT_PICTURE_FILENAME_EXTENSION
        End Function
        Public Overrides Function ToString() As String
            If ContactType = AddressBookEntryType.TrulyMail Then
                Return FullName & " (TrulyMail)"
            Else
                Return FullName & " (" & Address & ")"
            End If
        End Function
    End Class
#Region " Address Book Logic "
    Friend Function GetAddressBookPath() As String
        Return ProfileRootPath & ADDRESS_BOOK_FILENAME
    End Function
    Friend Function AddressBookExists() As Boolean
        Dim strAddressBookFilePath As String = GetAddressBookPath()
        If System.IO.File.Exists(strAddressBookFilePath) Then
            Return True
        Else
            Return False
        End If
    End Function
    Friend Sub DeactivateUserInAddressBook(ByVal userID As String)
        Dim entry As AddressBookEntry = ABook.GetContactByID(userID)
        If entry IsNot Nothing Then
            entry.Active = False
            ABook.Save()
        End If
    End Sub
    Friend Sub BlockUserInAddressBook(ByVal userID As String)
        Dim entry As AddressBookEntry = ABook.GetContactByID(userID)
        If entry IsNot Nothing Then
            entry.Blocked = True
            ABook.Save()
        End If
    End Sub
    Friend Sub UnBlockUserInAddressBook(ByVal userID As String)
        Dim entry As AddressBookEntry = ABook.GetContactByID(userID)
        If entry IsNot Nothing Then
            entry.Blocked = False
            ABook.Save()
        End If
    End Sub
    Friend Sub DeleteUserFromAddressBook(ByVal entry As AddressBookEntry)
        If entry IsNot Nothing Then
            ABook.Remove(entry)
            ABook.Save()
        End If
    End Sub
    Friend Sub ImportAddressBook(ByVal filename As String)
        Dim strDestinationFile As String = GetAddressBookPath()
        If System.IO.File.Exists(strDestinationFile) Then
            DeleteLocalFile(strDestinationFile)
        End If
        System.IO.File.Copy(filename, strDestinationFile)
    End Sub
    Friend Function GetUserNameFromID(ByVal userID As String) As String
        Dim entry As AddressBookEntry = ABook.GetContactByID(userID)
        If entry Is Nothing Then
            Return UNKNOWN_USER
        Else
            Return entry.FullName
        End If
    End Function
#End Region
    Friend Sub BatchUpdateLastReceivedSent()
        '-- This should only be called once, when starting 3.x for the first time
        '   it will scan all messages (in background) and update the address book
        '   contacts with LastMessageSent and LastMessageReceived
        BatchUpdateLastReceivedSentChildren(MessageStoreRootPath)
        ABook.Save() '-- Only save when we complete the entire process
        AppSettings.ContactLastSentUpdated = Date.Now
        AppSettings.Save()
    End Sub
    Private Sub BatchUpdateLastReceivedSentChildren(ByVal folder As String)
        Dim folders() As String = System.IO.Directory.GetDirectories(folder)
        For Each childFolder As String In folders
            BatchUpdateLastReceivedSentChildren(childFolder)
        Next

        Log("BatchUpdateLastReceivedSentChildren: " & folder)
        Using msgIndex As New MessageIndex(SentItemsRootPath)
            Dim builder As New FileListLoader(REGEX_MESSAGE_FILENAME)
            Dim fds As List(Of FileDetails) = builder.GetFilesInPath(folder, False)
            Dim contact As AddressBookEntry
            For Each fd As FileDetails In fds
                Dim tmm As TrulyMailMessage = msgIndex.GetMessage(fd)
                If tmm IsNot Nothing Then
                    If tmm.Sent = False Then
                        '-- received
                        If tmm.Sender.ContactType = AddressBookEntryType.TrulyMail Then
                            If tmm.Sender.ID.Length = 0 Then
                                '-- user is sender, skip (should never get here)
                            Else
                                contact = ABook.GetContactByID(tmm.Sender.ID)
                                If contact IsNot Nothing Then
                                    If contact.LastMessageReceived.HasValue Then
                                        If contact.LastMessageReceived.Value < tmm.MessageDateSent Then
                                            contact.LastMessageReceived = tmm.MessageDateSent
                                        End If
                                    Else
                                        contact.LastMessageReceived = tmm.MessageDateSent
                                    End If
                                Else
                                    '-- TrulyMail contact not in address book (should not get here)
                                End If
                            End If
                        Else
                            '-- email
                            contact = ABook.GetContactByAddress(tmm.Sender.Address)
                            If contact IsNot Nothing Then
                                If contact.LastMessageReceived.HasValue Then
                                    If contact.LastMessageReceived.Value < tmm.MessageDateSent Then
                                        contact.LastMessageReceived = tmm.MessageDateSent
                                    End If
                                Else
                                    contact.LastMessageReceived = tmm.MessageDateSent
                                End If
                            Else
                                '-- email contact not in address book, ignore
                            End If
                        End If
                    Else
                        '-- sent
                        For Each recip As RecipientEntry In tmm.Recipients
                            If recip.ContactType = AddressBookEntryType.TrulyMail Then
                                '-- TrulyMail
                                contact = ABook.GetContactByID(recip.ID)
                                If contact IsNot Nothing Then
                                    If contact.LastMessageSent.HasValue Then
                                        If contact.LastMessageSent.Value < tmm.MessageDateSent Then
                                            contact.LastMessageSent = tmm.MessageDateSent
                                        End If
                                    Else
                                        contact.LastMessageSent = tmm.MessageDateSent
                                    End If
                                Else
                                    '-- TrulyMail contact not in address book (should not get here)
                                End If
                            Else
                                '-- email
                                contact = ABook.GetContactByAddress(recip.Address)
                                If contact IsNot Nothing Then
                                    If contact.LastMessageSent.HasValue Then
                                        If contact.LastMessageSent.Value < tmm.MessageDateSent Then
                                            contact.LastMessageSent = tmm.MessageDateSent
                                        End If
                                    Else
                                        contact.LastMessageSent = tmm.MessageDateSent
                                    End If
                                Else
                                    '-- email contact not in address book, ignore
                                End If
                            End If
                        Next
                    End If
                End If
            Next
        End Using

    End Sub


End Module
