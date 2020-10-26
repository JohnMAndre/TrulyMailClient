Friend Class AddressBook


    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_ACTIVE As String = "Active"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_ADDED As String = "Added"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_ADDRESS As String = "Address"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_BLOCKED As String = "Blocked"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_CONTACT As String = "Contact"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_CONTACTTYPE As String = "ContactType"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_FULLNAME As String = "FullName"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_ID As String = "ID"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_RECEIVEONLY As String = "ReceiveOnly"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_RECEIVEONLYCANCHANGE As String = "ReceiveOnlyCanChange"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_REMOTEIMAGES As String = "RemoteImages"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_AUTOREQUESTRETURNRECEIPT As String = "AutoRequestReturnReceipt"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_AUTOSENDRETURNRECEIPT As String = "AutoSendReturnReceipt"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_TAGS As String = "Tags"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_IMPORTANCERATING As String = "ImportanceRating"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_LASTMESSAGERECEIVED As String = "LastMessageReceived"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_LASTMESSAGESENT As String = "LastMessageSent"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_REMINDRECEIVEEVERYXDAYS As String = "RemindReceiveEveryXDays"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_REMINDSENDEVERYXDAYS As String = "RemindSendEveryXDays"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_ENCRYPTMESSAGES As String = "EncryptMessages"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_HOMEPHONE As String = "HomePhone"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_WORKPHONE As String = "WorkPhone"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_MOBILEPHONE As String = "MobilePhone"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_WEBPAGE As String = "WebPage"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_CUSTOM1 As String = "Custom1"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_CUSTOM2 As String = "Custom2"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_CUSTOM3 As String = "Custom3"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_CUSTOM4 As String = "Custom4"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_NOTES As String = "Notes"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_WEBMAILQUESTION As String = "WebMailQuestion"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_WEBMAILPASSWORD As String = "WebMailPassword"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_SMTPID As String = "SMTPID"
    Private Const ADDRESSBOOK_ATTRIBUTE_NAME_TRULYMAILVERSION As String = "TrulyMailVersion"


    Private m_lstContacts As New List(Of AddressBookEntry)

    Public Sub New(ByVal addressBookMustExist As Boolean)
        If Not System.IO.File.Exists(GetAddressBookPath()) Then
            If addressBookMustExist Then
                ShowMessageBoxError("Your address book cannot be loaded (open your address book, then click File->Restore from Server). Please contact TrulyMail Support if you have any questions.")
            Else
                '-- do nothing, there is no address book file to load (just signing up with new account)
            End If
        Else
            LoadAddressBookFromFile(GetAddressBookPath())
        End If
    End Sub
    Public Sub New(ByVal addressBookFilename As String)
        LoadAddressBookFromFile(addressBookFilename)
    End Sub
    Private Sub LoadAddressBookFromFile(ByVal filename As String)
        Try
            Dim strXML As String = System.IO.File.ReadAllText(filename)
            If strXML.Substring(0, 1) = "<" Then
                '-- unencrypted, do nothing
            Else
                '-- encrypted
                strXML = DecryptTextSymetric(EncryptionPassword, strXML)
            End If
            Dim xDocAddressBook As New Xml.XmlDocument()
            xDocAddressBook.LoadXml(strXML)
            m_lstContacts = New List(Of AddressBookEntry)
            Dim contact As AddressBookEntry
            Dim strValue As String
            Dim contactType As AddressBookEntryType
            Dim intLoadErrors As Integer

            Dim xList As Xml.XmlNodeList = xDocAddressBook.SelectNodes("//" & ADDRESSBOOK_ATTRIBUTE_NAME_CONTACT)
            For Each xContact As Xml.XmlElement In xList
                Try
                    strValue = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_CONTACTTYPE)
                    If strValue.Length > 0 Then
                        contactType = [Enum].Parse(GetType(AddressBookEntryType), strValue, True)
                    Else
                        contactType = AddressBookEntryType.TrulyMail '-- no contact type = TrulyMail from previous version of TrulyMail
                    End If

                    contact = New AddressBookEntry(contactType)
                    contact.Active = ConvertToBool(xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ACTIVE), True)

                    '-- Italian windows, for example, seems to store xml dates (even formated with literals h:mm) as h.mm as in "2011-01-24T19.09.28.125"
                    '   now, try to get date and time, then date, then use UTCNow if all else fails
                    Try
                        contact.Added = Convert.ToDateTime(xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ADDED))
                    Catch ex As Exception
                        Log(ex)
                        Try
                            If xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ADDED).IndexOf("T") > 0 Then
                                Dim strDateOnly As String = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ADDED).Substring(0, xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ADDED).IndexOf("T"))
                                contact.Added = Convert.ToDateTime(strDateOnly)
                            End If
                        Catch ex2 As Exception
                            Log(ex2)
                            contact.Added = Date.UtcNow
                        End Try
                    End Try

                    If contactType = AddressBookEntryType.Email Then
                        Try
                            contact.Address = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ADDRESS)
                        Catch ex As Exception
                            If ex.Message.StartsWith("Invalid email address format.") Then
                                ShowMessageBoxAutoClose("One of your email contacts has an invalid email address ('" & xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ADDRESS) & "') and will not be loaded.", 5)
                            End If
                            Throw ex
                        End Try
                    End If

                    If contact.ContactType = AddressBookEntryType.TrulyMail Then
                        contact.AutoRequestReadReceipt = True
                    Else
                        contact.AutoRequestReadReceipt = ConvertToBool(xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_AUTOREQUESTRETURNRECEIPT), False)
                    End If

                    If contact.ContactType = AddressBookEntryType.TrulyMail Then
                        contact.AutoSendReadReceipt = ContactReceiptOption.Always
                    Else
                        strValue = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_AUTOSENDRETURNRECEIPT)
                        If strValue.Length > 0 Then
                            contact.AutoSendReadReceipt = [Enum].Parse(GetType(ContactReceiptOption), strValue, ContactReceiptOption.UseDefault)
                        Else
                            contact.AutoSendReadReceipt = ContactReceiptOption.UseDefault
                        End If
                    End If

                    contact.Blocked = ConvertToBool(xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_BLOCKED), False)

                    'If contact.ContactType = AddressBookEntryType.TrulyMail Then
                    '    '-- TrulyMail recipients always get encrypted messages
                    '    contact.EncryptMessages = EncryptMessagesOption.Always
                    'Else
                    '    strValue = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ENCRYPTMESSAGES)
                    '    If strValue.Length > 0 Then
                    '        contact.EncryptMessages = [Enum].Parse(GetType(EncryptMessagesOption), strValue, True)
                    '    Else
                    '        contact.EncryptMessages = EncryptMessagesOption.UseMessage
                    '    End If
                    'End If

                    contact.FullName = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_FULLNAME)
                    contact.ID = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ID)
                    contact.ImportanceRating = ConvertToInt32(xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_IMPORTANCERATING), 0)
                    contact.LastMessageReceived = ConvertToNullableDate(xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_LASTMESSAGERECEIVED), Nothing)
                    contact.LastMessageSent = ConvertToNullableDate(xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_LASTMESSAGESENT), Nothing)

                    contact.ReceiveOnly = ConvertToBool(xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_RECEIVEONLY), False)
                    contact.ReceiveOnlyCanChange = ConvertToBool(xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_RECEIVEONLYCANCHANGE), True)
                    'If Not ContactKeyExists(contact.ID) Then
                    '    contact.ReceiveOnlyCanChange = False '-- pending contacts cannot have receive only change
                    'End If
                    'If contact.FullName = SERVER_FULLNAME Then
                    '    contact.ReceiveOnlyCanChange = False '-- server cannot have receive only change
                    'End If

                    contact.RemindReceiveEveryXDays = ConvertToInt32(xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_REMINDRECEIVEEVERYXDAYS), 0)
                    contact.RemindSendEveryXDays = ConvertToInt32(xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_REMINDSENDEVERYXDAYS), 0)
                    contact.RemoteImages = ConvertToBool(xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_REMOTEIMAGES), False)
                    contact.Tags = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_TAGS)

                    contact.PhoneHome = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_HOMEPHONE)
                    contact.PhoneWork = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_WORKPHONE)
                    contact.PhoneMobile = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_MOBILEPHONE)
                    contact.WebPage = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_WEBPAGE)
                    contact.Custom1 = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_CUSTOM1)
                    contact.Custom2 = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_CUSTOM2)
                    contact.Custom3 = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_CUSTOM3)
                    contact.Custom4 = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_CUSTOM4)
                    contact.Notes = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_NOTES)
                    contact.WebMailQuestion = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_WEBMAILQUESTION)
                    contact.WebMailPassword = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_WEBMAILPASSWORD)
                    If contact.ContactType = AddressBookEntryType.Email Then
                        contact.SMTPID = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_SMTPID)
                    Else
                        contact.SMTPID = String.Empty
                    End If

                    '-- Get version for this contact
                    If contact.ContactType = AddressBookEntryType.TrulyMail Then
                        strValue = xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_TRULYMAILVERSION)
                        If strValue.Length > 0 Then
                            contact.TrulyMailVersion = strValue
                        End If
                    End If

                    m_lstContacts.Add(contact)
                Catch ex As Exception
                    Log(ex)
                    intLoadErrors += 1
                End Try
            Next

            If intLoadErrors > 0 Then
                ShowMessageBoxError("There were " & intLoadErrors.ToString("#,##0") & " contacts with errors. These contacts were not loaded. If you have questions, please contact TrulyMail Support for assistance.")
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error loading your address book. Please contact TrulyMail Support for assistance.")
        End Try
    End Sub
    Private Sub SaveAddressBookToFile(ByVal filename As String, ByVal encrypt As Boolean)
        Dim intCounter As Integer
        Try
            Dim xDoc As New Xml.XmlDocument()
            Dim xRoot As Xml.XmlElement = xDoc.CreateElement("AddressBook")
            xRoot = xDoc.AppendChild(xRoot)
            Dim xContact As Xml.XmlElement
            Dim contact As AddressBookEntry

            For i As Integer = 0 To m_lstContacts.Count - 1
                contact = m_lstContacts(i)
                xContact = xDoc.CreateElement(ADDRESSBOOK_ATTRIBUTE_NAME_CONTACT)
                intCounter = i
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ACTIVE, contact.Active.ToString())
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ADDED, contact.Added.ToString(DATEFORMAT_XML))
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ADDRESS, contact.Address)
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_CONTACTTYPE, contact.ContactType.ToString())
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_AUTOREQUESTRETURNRECEIPT, contact.AutoRequestReadReceipt.ToString())
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_AUTOSENDRETURNRECEIPT, contact.AutoSendReadReceipt.ToString)
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_BLOCKED, contact.Blocked.ToString())
                'xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ENCRYPTMESSAGES, contact.EncryptMessages.ToString())
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_FULLNAME, contact.FullName)
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ID, contact.ID)
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_IMPORTANCERATING, contact.ImportanceRating.ToString())

                If contact.LastMessageReceived.HasValue Then
                    xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_LASTMESSAGERECEIVED, contact.LastMessageReceived.Value.ToString(DATEFORMAT_XML_DATEONLY))
                End If
                If contact.LastMessageSent.HasValue Then
                    xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_LASTMESSAGESENT, contact.LastMessageSent.Value.ToString(DATEFORMAT_XML_DATEONLY))
                End If

                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_RECEIVEONLY, contact.ReceiveOnly.ToString())
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_RECEIVEONLYCANCHANGE, contact.ReceiveOnlyCanChange.ToString())
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_REMINDRECEIVEEVERYXDAYS, contact.RemindReceiveEveryXDays.ToString())
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_REMINDSENDEVERYXDAYS, contact.RemindSendEveryXDays.ToString())
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_REMOTEIMAGES, contact.RemoteImages.ToString())
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_TAGS, contact.Tags)

                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_HOMEPHONE, contact.PhoneHome)
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_WORKPHONE, contact.PhoneWork)
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_MOBILEPHONE, contact.PhoneMobile)
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_WEBPAGE, contact.WebPage)
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_CUSTOM1, contact.Custom1)
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_CUSTOM2, contact.Custom2)
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_CUSTOM3, contact.Custom3)
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_CUSTOM4, contact.Custom4)
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_NOTES, contact.Notes)
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_WEBMAILQUESTION, contact.WebMailQuestion)
                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_WEBMAILPASSWORD, contact.WebMailPassword)
                If contact.ContactType = AddressBookEntryType.Email Then
                    xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_SMTPID, contact.SMTPID)
                Else
                    xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_SMTPID, String.Empty)
                End If

                xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_TRULYMAILVERSION, contact.TrulyMailVersion)

                xRoot.AppendChild(xContact)
            Next

            'xDoc.Save(filename)
            If System.IO.File.Exists(filename) Then
                Try
                    DeleteLocalFile(filename)
                Catch ex As Exception
                    Log(ex)
                    ShowMessageBoxError("Your address book could not be saved because another application is using your address book file.")
                    Exit Sub
                End Try
            End If
            Dim strXML As String = xDoc.OuterXml

            '-- Here we will encrypt the address book, but only if a startup password has been set
            If encrypt Then
                If StartupPasswordInUse() Then
                    strXML = EncryptTextSymetric(EncryptionPassword, strXML, EncryptionLevelEnum.Version5Strong)
                End If
            End If
            System.IO.File.WriteAllText(filename, strXML)
        Catch ex As System.IO.IOException
            Log(ex)
            ShowMessageBoxError("Your address book could not be saved because another application is using your address book file.")
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error saving your address book. Please contact TrulyMail Support for assistance.")
        End Try
    End Sub
    ''' <summary>
    ''' Returns all active contacts
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllContacts() As List(Of AddressBookEntry)
        Dim lstReturn As New List(Of AddressBookEntry)
        For Each contact As AddressBookEntry In m_lstContacts
            If contact.Active Then
                lstReturn.Add(contact)
            End If
        Next

        Return lstReturn
    End Function
    Public Function GetContactByID(ByVal id As String) As AddressBookEntry
        For intCounter As Integer = 0 To m_lstContacts.Count - 1
            If String.Compare(m_lstContacts(intCounter).ID, id, True) = 0 Then
                Return m_lstContacts(intCounter)
            End If
        Next

        Return Nothing '-- no match found
    End Function
    Public Function GetContactByAddress(ByVal address As String) As AddressBookEntry
        If address Is Nothing OrElse address.Length = 0 Then
            Return Nothing
        Else
            For intCounter As Integer = 0 To m_lstContacts.Count - 1
                If String.Compare(m_lstContacts(intCounter).Address, address, True) = 0 Then
                    Return m_lstContacts(intCounter)
                End If
            Next
        End If

        Return Nothing '-- no match found
    End Function
    Public Sub Add(ByVal contact As AddressBookEntry)
        m_lstContacts.Add(contact)
    End Sub
    Public Sub Save()
        SaveAddressBookToFile(GetAddressBookPath(), True)
    End Sub
    Public Sub SaveAs(ByVal filename As String)
        SaveAddressBookToFile(filename, False)
    End Sub
    Public Sub Remove(ByVal entry As AddressBookEntry)
        If m_lstContacts.Contains(entry) Then
            m_lstContacts.Remove(entry)
        Else
            Log("Request to remove contact which does not exist (ID: " & entry.ID & ")")
        End If
    End Sub
End Class
