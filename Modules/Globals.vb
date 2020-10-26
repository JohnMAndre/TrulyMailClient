Module Globals


#Region " Private Data "
    Private _context As String = String.Empty
#End Region

#Region " Global Delegates "
    Friend Delegate Sub SetStatusCallback(ByVal newStatus As String)
#End Region

    Public Declare Auto Function SetForegroundWindow Lib "user32" (ByVal hwnd As IntPtr) As Integer

    Friend DataRootPath As String
    Friend ProfileRootPath As String
    Friend MessageStoreTempPath As String
    Friend MessageStoreRootPath As String
    Friend InBoxRootPath As String
    Friend OutboxRootPath As String
    Friend TrashRootPath As String
    Friend SentItemsRootPath As String
    Friend DraftsRootPath As String
    Friend AttachmentsRootPath As String
    Friend EncryptionKeyRootPath As String
    Friend PictureRootPath As String
    Friend MySoundsPath As String

    Friend AppSettings As ApplicationSettings
    Friend EXEFileExtensions As List(Of String)
    Friend MainFormReference As MainForm
    Friend BusySendingMessage As Boolean
    Friend ReloadAddressbook As Boolean = True
    Friend ShuttingDown As Boolean
    Friend SendReceiveTrigger As SendReceiveTriggerEnum
    Private UpdateNoticeLastShown As Date = Date.MinValue

    Friend PreventAnyLogin As Boolean '-- true to prevent login dialogs from showing while other dialogs are open
    Friend EncryptedPackageOpeningProgress As EncryptedPackageOpeningStatus
    Friend MyKeyPair As TrulyMail.Cryptography.KeyPair
    Private Cookies As System.Net.CookieContainer
    Friend g_ABook As AddressBook

    Public DeletedMessagesForUndo As New List(Of UndoMessageDelete)

    Public Const READ_RECEIPT_READ_SPANISH As String = "leído: "
    Public Const READ_RECEIPT_READ_DUTCH As String = "gelezen: "
    Public Const READ_RECEIPT_RECEIPT_ENGLISH As String = "receipt:" '-- DreamMail (no attachments)
    Public Const READ_RECEIPT_RECEIVED_DUTCH As String = "ontvangen:" '-- DreamMail (no attachments)
    Public Const READ_RECEIPT_READ_ENGLISH As String = "read:"
    Public Const READ_RECEIPT_READ_ENGLISH_THUNDERBIRD_TRULYMAIL As String = "return receipt (displayed) - "


    Friend Sub ForceAddressBookReload()
        g_ABook = New AddressBook(False)
    End Sub
    Friend Function ABook() As AddressBook
        If g_ABook Is Nothing Then
            g_ABook = New AddressBook(False)
        End If
        Return g_ABook
    End Function

    Public Class UndoMessageDelete
        Public FromFolder As String '-- InBox
        Public ToFolder As String '-- Trash
        Public Messages As New List(Of MessageRelocation)
    End Class
    Public Class MessageRelocation
        Public FromFilename As String '-- c:\InBox\123-123-123.tmm
        Public ToFilename As String '-- c:\Trash\123-123-123.tmm
    End Class



    Friend Class EncryptedPackageOpeningStatus
        Private _status As PackageOpeningStatus
        Public Property Status() As PackageOpeningStatus
            Get
                Return _status
            End Get
            Set(ByVal value As PackageOpeningStatus)
                _status = value
            End Set
        End Property
    End Class

    Friend DateFormats As List(Of String) '-- so user can choose which date format to use 
    Friend Function FormatDateTime(ByVal dt As Date) As String
        Try
            Dim strFormat As String = DateFormats(AppSettings.DateFormat)
            Return dt.ToString(strFormat)
        Catch ex As Exception
            Log(ex)
            Return dt.ToString("m/d/yyyy h:mm tt") '-- in case of an error, return default format
        End Try
    End Function
    Friend Function FormatDate(ByVal dt As Date) As String
        Try
            Dim strFormat As String = DateFormats(AppSettings.DateFormat).Substring(0, DateFormats(AppSettings.DateFormat).IndexOf("yyyy") + 4)
            Return dt.ToString(strFormat)
        Catch ex As Exception
            Log(ex)
            Return dt.ToString("m/d/yyyy") '-- in case of an error, return default format
        End Try
    End Function
    Friend Function FormatTime(ByVal dt As Date) As String
        Try
            Dim strFormat As String = DateFormats(AppSettings.DateFormat).Substring(DateFormats(AppSettings.DateFormat).IndexOf("yyyy") + 5)
            Return dt.ToString(strFormat)
        Catch ex As Exception
            Log(ex)
            Return dt.ToString("h:mm tt") '-- in case of an error, return default format
        End Try
    End Function
    ''' <summary>
    ''' Returns date and time for dates after today, time only for today
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function FormatDateTimeDependingForOLV(ByVal value As Object) As String
        If value IsNot Nothing Then
            Dim dt As Date = CType(value, Date)
            If dt.Date = Today Then
                Return FormatTime(dt)
            Else
                Return FormatDateTime(dt)
            End If
        End If
    End Function
    Friend Function FormatDateTimeForOLV(ByVal value As Object) As String
        If value IsNot Nothing Then
            Return FormatDateTime(CType(value, Date))
        End If
    End Function
    Friend Function FormatDateForOLV(ByVal value As Object) As String
        If value IsNot Nothing Then
            Return FormatDate(CType(value, Date))
        End If
    End Function
    Friend Function FormatTimeForOLV(ByVal value As Object) As String
        If value IsNot Nothing Then
            Return FormatTime(CType(value, Date))
        End If
    End Function
    Friend QuickShutDownRequired As Boolean

    Friend Structure Context
        Public ContextID As String
        Public ContextError As ContextError
    End Structure
    Public Class NameValuePair
        Public Name As String
        Public Value As String
    End Class
    Private Structure EmailBody
        Public Body As String
        Public Format As EmailBodyFormatEnum
    End Structure
    ''' <summary>
    ''' Returns short report (e.g., 2 days or 4 hours but not a full report like FormatTimeSpan2)
    ''' </summary>
    ''' <param name="ts"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function FormatTimeSpan(ByVal ts As TimeSpan) As String
        Dim strReturn As String = String.Empty

        If ts.Days >= 1 Then
            If ts.Days >= 2 Then
                strReturn = ts.Days.ToString("#,##0") & " days"
            Else
                strReturn = ts.Days.ToString("0") & " day"
            End If
        ElseIf ts.Hours >= 1 Then
            If ts.Hours >= 2 Then
                strReturn = ts.Hours.ToString("0") & " hours"
            Else
                strReturn = ts.Hours.ToString("0") & " hour"
            End If
        ElseIf ts.Minutes >= 1 Then
            If ts.Minutes >= 2 Then
                strReturn = ts.Minutes.ToString("0") & " minutes"
            Else
                strReturn = ts.Minutes.ToString("0") & " minute"
            End If
        Else 'if ts.Seconds >= 1 Then
            If ts.Seconds >= 2 Then
                strReturn = ts.Seconds.ToString("0") & " seconds"
            Else
                strReturn = ts.Seconds.ToString("0") & " second"
            End If
        End If

        Return strReturn
    End Function
    ''' <summary>
    ''' Returns full report (e.g., 2 days, 4 hours, 5 minutes, 1 second)
    ''' </summary>
    ''' <param name="time_span"></param>
    ''' <param name="whole_seconds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function FormatTimeSpan2(ByVal time_span As TimeSpan, Optional ByVal whole_seconds As Boolean = True) As String
        Dim txt As String = ""

        If time_span.Days > 0 Then
            If time_span.Days > 1 Then
                txt &= ", " & time_span.Days.ToString() & " days"
            Else
                txt &= ", " & time_span.Days.ToString() & " day"
            End If
            time_span = time_span.Subtract(New  _
                TimeSpan(time_span.Days, 0, 0, 0))
        End If
        If time_span.Hours > 0 Then
            If time_span.Hours > 1 Then
                txt &= ", " & time_span.Hours.ToString() & " hours"
            Else
                txt &= ", " & time_span.Hours.ToString() & " hour"
            End If
            time_span = time_span.Subtract(New TimeSpan(0, _
                time_span.Hours, 0, 0))
        End If
        If time_span.Minutes > 0 Then
            If time_span.Minutes > 1 Then
                txt &= ", " & time_span.Minutes.ToString() & " " & "minutes"
            Else
                txt &= ", " & time_span.Minutes.ToString() & " " & "minute"
            End If
            time_span = time_span.Subtract(New TimeSpan(0, 0, time_span.Minutes, 0))
        End If

        If whole_seconds Then
            ' Display only whole seconds.
            If time_span.Seconds > 0 Then
                If time_span.Seconds > 1 Then
                    txt &= ", " & time_span.Seconds.ToString() & " " & "seconds"
                Else
                    txt &= ", " & time_span.Seconds.ToString() & " " & "second"
                End If
            End If
        Else
            ' Display fractional seconds.
            If time_span.Seconds > 1 Then
                txt &= ", " & time_span.TotalSeconds.ToString() & " " & "seconds"
            Else
                txt &= ", " & time_span.TotalSeconds.ToString() & " " & "second"
            End If
        End If

        ' Remove the leading ", ".
        If txt.Length > 0 Then txt = txt.Substring(2)

        ' Return the result.
        Return txt
    End Function
    ''' <summary>
    ''' Returns full report (e.g., 2d 04:05:03 meaning 2 days, 4 hours, 5 minutes, 3 seconds)
    ''' </summary>
    ''' <param name="time_span"></param>
    ''' <param name="whole_seconds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function FormatTimeSpan2Compact(ByVal time_span As TimeSpan, Optional ByVal whole_seconds As Boolean = True) As String
        Dim strReturn As String = String.Empty

        If time_span.Days > 0 Then
            strReturn = time_span.Days.ToString("00 d ")
        End If

        If time_span.Hours > 0 OrElse strReturn.Length > 0 Then
            strReturn &= time_span.Hours.ToString("00") & ":"
        End If

        strReturn &= time_span.Minutes.ToString("00") & ":" & time_span.Seconds.ToString("00")

        Return strReturn
    End Function
    Friend Class MessageTag
        Public Text As String
        Public Color As Color
        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class
    Friend Class ReplyMode
        Public Text As String
        Public ImageIndex As Integer
        Public ForReceivedMessages As Boolean
        Public ForSentMessages As Boolean
        Public IsReply As Boolean
        Public IncludesBody As Boolean
        Public IsForward As Boolean
        Public IncludesAttachments As Boolean
        Public IsReplyAll As Boolean
    End Class
#Region " Email Support "
    Friend Enum ContactReceiptOption
        UseDefault
        Always
        Never
        AlwaysForced '-- send on read, even if no receipt was requested
    End Enum
    Friend Enum POPReceiptOption
        AskMe
        Always
        Never
    End Enum
    Friend Enum SecureConnectionOption
        None
        TLS
        SSL
    End Enum
    Friend Enum UseFallbackModeEnum
        UnderWine
        Always
        Never
    End Enum

    Friend Interface IUsernamePassword
        Property Username() As String
        Property Password() As String
    End Interface

#End Region

    Friend Class AttachmentItem
        Public Property Filename As String '-- Full path to the file on disk (will be encrypted name, if Encrypted=true)
            
        Private m_strDisplayName As String
        Public Property DisplayName As String '-- This is what the users sees in a list
            Get
                Return m_strDisplayName
            End Get
            Set(value As String)
                m_strDisplayName = value
                Embedded = value.ToUpper().StartsWith("IMAGES\")
            End Set
        End Property
        Public Property FileSize As Long '-- This is the size of the unencrypted file on disk (symmetric encryption does not enough size to worry about it)
        Public Property DuplicateDisplayName As Boolean
        Public Property Encrypted As Boolean '-- true if file is encrypted on disk (giving it a different, gibberish name like PriceList.xls -> hD4fE.tmp)
        Public Property Embedded As Boolean '-- true if path starts with \Images\ which means it is embedded into the body, not part of the true attachments

        ''' <summary>
        ''' If encrypted, file will be decrypted to Temp folder under Profile. If decrypted, the filename will be returned.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDecryptedFilenameToOpen() As String
            Try
                If Encrypted Then
                    Dim strDecryptedFilename As String
                    strDecryptedFilename = System.IO.Path.Combine(GetTempPath(), Me.DisplayName)
                    DecryptFile1(AppSettings.GetFileEncryptionPassword, Me.Filename, strDecryptedFilename)
                    Return strDecryptedFilename
                Else
                    '-- Not encrypted, just return the normal filename
                    Return Filename
                End If
            Catch ex As Exception
                Log(ex)
                Throw ex
            End Try
        End Function
        ''' <summary>
        ''' If encrypted, file will be decrypted to the destination passed in. If already decrypted, file will simply be copied to the destination.
        ''' </summary>
        ''' <param name="decryptedFilename"></param>
        ''' <remarks></remarks>
        Public Sub CopyDecryptdFileToLocation(decryptedFilename As String)
            Try
                If Encrypted Then
                    Dim strDecryptedFilename As String
                    strDecryptedFilename = System.IO.Path.Combine(GetTempPath(), Me.DisplayName)
                    DecryptFile1(AppSettings.GetFileEncryptionPassword, Me.Filename, decryptedFilename)
                Else
                    '-- Not encrypted, just copy the file
                    System.IO.File.Copy(Me.Filename, decryptedFilename)
                End If
            Catch ex As Exception
                Log(ex)
                Throw ex
            End Try
        End Sub
    End Class

    Friend Delegate Sub NoParamSubDelegate()
    Friend g_boolFileSystemChanged As Boolean '-- true when timer on main form needs to reload the current folder

    'Private m_strMasterPassword As String = String.Empty
    Friend ReadOnly Property EncryptionPassword() As String
        Get
            'Dim bool As Boolean
            'bool = AppSettings Is Nothing
            'Log("AppSettings is nothing: " & bool.ToString)
            'bool = AppSettings.MasterPassword Is Nothing
            'Log("AppSettings.MasterPassword is nothing: " & bool.ToString)

            If AppSettings.MasterPassword Is Nothing Then
                Return PASSWORD_ENCRYPTION_KEY
            ElseIf AppSettings.MasterPassword.Length = 0 Then
                Return PASSWORD_ENCRYPTION_KEY
            Else
                Return AppSettings.MasterPassword
            End If
        End Get
        'Set(ByVal value As String)
        '    AppSettings.MasterPassword = value
        'End Set
    End Property
    Friend Function StartupPasswordInUse() As Boolean
        If AppSettings Is Nothing Then
            Return False
        ElseIf AppSettings.MasterPassword Is Nothing Then
            Return False
        ElseIf AppSettings.MasterPassword.Length = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

#Region " Global Constants "
    Public Const MASTER_PASSWORD_SALT As String = "€$~`"
#End Region

#Region " Global Routines "
    Public Function IsPortableProfile() As Boolean
        Return True
    End Function
    Friend Sub ApplyMasterPassword(parentForm As Form)
        Dim boolOKToChange As Boolean
        Dim strEnteredPassword1 As String
        Dim strPreviousMasterPassword As String = EncryptionPassword

        If AppSettings.EncryptSettingsFile Then

            '-- User might leave TM on so force them to authenticate again before changing master password
            strEnteredPassword1 = GetInput("Please enter your startup password.", True)
            If strEnteredPassword1 = Chr(0) Then
                '-- User canceled
                Exit Sub
            Else
                If strEnteredPassword1.Equals(AppSettings.MasterPassword) Then
                    boolOKToChange = True
                    strPreviousMasterPassword = strEnteredPassword1
                Else
                    ShowMessageBoxError("The entered password is not your startup password.")
                    boolOKToChange = False
                End If
            End If
        Else
            '-- No password currently set
            boolOKToChange = True
        End If




        If boolOKToChange Then
            Dim boolEncryptOrDecryptLocalFiles As Boolean
            Using frm As New SetMasterPasswordK()
                If frm.ShowDialog(parentForm) = DialogResult.OK Then
                    '-- user did not click cancel
                    strEnteredPassword1 = frm.Password

                    Select Case AppSettings.EncryptLocalFiles
                        Case LocalFileEncryptionStatus.Encrypting, LocalFileEncryptionStatus.Decrypting
                            boolEncryptOrDecryptLocalFiles = True
                        Case Else
                            boolEncryptOrDecryptLocalFiles = False
                    End Select
                Else
                    '--- user clicked cancel
                    Exit Sub
                End If
            End Using

            '-- begin the encryption/ decryption process
            Dim frmEncrypt As LocationFileEncryptionProcess
            If boolEncryptOrDecryptLocalFiles Then
                frmEncrypt = New LocationFileEncryptionProcess()
                frmEncrypt.Show(MainFormReference)
                Application.DoEvents()
            End If

            '-- First, get all pop and smtp passwords (unencrypted) into a hashtable for later encrypting

            Dim htPasswords As New Hashtable

            For Each pop As POPProfile In AppSettings.POPProfiles
                If pop.EncryptedPassword.Length > 0 Then
                    htPasswords.Add(pop.ID, pop.Password)
                End If
            Next
            Application.DoEvents()

            For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
                If smtp.EncryptedPassword.Length > 0 Then
                    htPasswords.Add(smtp.ID, smtp.Password)
                End If
            Next
            Application.DoEvents()


            '-- If we are encrypting/decrypting on the form, then we can only
            '   notify the user now if the form has completed (could happen if there are few messages)
            '   Otherwise, we must end this routine without notifying the user and let the form
            '   notify the user when it is complete
            If frmEncrypt IsNot Nothing Then
                If frmEncrypt.ProcessComplete Then
                    '-- The form has finished encrypting local files (fast)
                    ApplyMasterPasswordFinalize(strEnteredPassword1, htPasswords)
                Else
                    '-- We are still processing local files, so we need to tell the form
                    '   to call the Finalize method for us, then we exit and wait for the form to complete
                    frmEncrypt.NotifyUserOnComplete(strEnteredPassword1, htPasswords)

                    '-- Because TM can crash in the middle of encrypting a large number of files
                    '   we must save the settings file with the encryption passwords so TM can 
                    '   automatically resume on next launch
                    '-  BUT we only save the password when ENCRYPTING
                    '   If decrypting then we need to NOT save the password (because it will be blank and 
                    '   resuming decrypting on startup would not work.
                    Select Case AppSettings.EncryptLocalFiles
                        Case LocalFileEncryptionStatus.Encrypting
                            AppSettings.MasterPassword = strEnteredPassword1 '-- do not clear MasterPassword until all files are decrypted
                            AppSettings.MasterPasswordHashLong = String.Empty '-- We actually do not use this if v >= 5.1
                            AppSettings.Save()
                        Case Else
                            '-- do nothing (leave settings file encrypted)
                    End Select


                End If
            Else
                '-- We never were encrypting local files, so just call finalize now
                ApplyMasterPasswordFinalize(strEnteredPassword1, htPasswords)
            End If


        End If
    End Sub
    ''' <summary>
    ''' If on startup, TM crashed while in process of encrypting/decrypting local files, call this routine to resume the process
    ''' </summary>
    Public Sub ResumeEncryptingDecryptingLocalFilesOnStartup()
        Try
            If MainFormReference.InvokeRequired Then
                Dim deleg As New NoParamSubDelegate(AddressOf ResumeEncryptingDecryptingLocalFilesOnStartup)
                MainFormReference.Invoke(deleg)
            Else
                Dim boolEncryptOrDecryptLocalFiles As Boolean

                Select Case AppSettings.EncryptLocalFiles
                    Case LocalFileEncryptionStatus.Encrypting, LocalFileEncryptionStatus.Decrypting
                        boolEncryptOrDecryptLocalFiles = True
                    Case Else
                        boolEncryptOrDecryptLocalFiles = False
                End Select


                '-- begin the encryption/ decryption process
                Dim frmEncrypt As LocationFileEncryptionProcess
                If boolEncryptOrDecryptLocalFiles Then
                    frmEncrypt = New LocationFileEncryptionProcess()
                    frmEncrypt.Show(MainFormReference)
                    Application.DoEvents()
                End If
            End If
        Catch ex As Exception
            Application.DoEvents()
            Log(ex)
        End Try
    End Sub
    ''' <summary>
    ''' wraps up things like re-encrypting email passwords, etc.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub ApplyMasterPasswordFinalize(newMasterPassword As String, passwordHashtable As Hashtable)

        '-- If we are removing the MasterPassword, then we must call this logic (clearing the MasterPassword, re-encrypting email passwords)
        '   AFTER all local files are decrypted
        '   So, we will ALWAYS call this either from the form (if we are encrypting/decrypting local files)
        '   or immediately


        '-- Then store the new password (in memory only) and remove the hash code
        AppSettings.MasterPassword = newMasterPassword '-- do not clear MasterPassword until all files are decrypted
        AppSettings.MasterPasswordHashLong = String.Empty '-- We actually do not use this if v >= 5.1
        AppSettings.Save()
        Application.DoEvents()


        '-- Now, save all the passwords back encrypted with the user's entered password
        For Each pop As POPProfile In AppSettings.POPProfiles
            If passwordHashtable.ContainsKey(pop.ID) Then
                pop.Password = passwordHashtable(pop.ID)
            End If
        Next
        Application.DoEvents()

        For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
            If smtp.EncryptedPassword.Length > 0 Then
                smtp.Password = passwordHashtable(smtp.ID)
            End If
        Next
        Application.DoEvents()

        '-- encrypt address book
        ABook.Save()

        Dim strMessage As String = "Your Startup Password "

        If AppSettings.EncryptSettingsFile Then
            strMessage &= "has been set. "
        Else
            strMessage &= "has been cleared. "
        End If

        strMessage &= "And your local files are "

        Select Case AppSettings.EncryptLocalFiles
            Case LocalFileEncryptionStatus.Decrypted
                strMessage &= "NOT encrypted."
            Case LocalFileEncryptionStatus.Encrypted
                strMessage &= "encrypted."
            Case Else
                '-- Should not get here because that means we are still processing files
                Log("Problem: EncryptLocalFiles = " & AppSettings.EncryptLocalFiles.ToString())
                strMessage &= "UNKNOWN. " & CONTACT_TRULYMAIL_MESSAGE
        End Select

        ShowMessageBox(strMessage, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

    End Sub
    Friend Sub LoadGlobalSettings()
        Try
            Dim dirInfo As System.IO.DirectoryInfo
            If IsPortableProfile() Then
                '-- Portable app, on USB drive
                'MsgBox("A: " & AppDomain.CurrentDomain.BaseDirectory)
                'MsgBox("B: " & Application.ExecutablePath)
                'MsgBox("C: " & System.Reflection.Assembly.GetExecutingAssembly.Location)
                'MsgBox("D: " & System.Reflection.Assembly.GetEntryAssembly.Location)

                '-- Replaced in 4.0 to support an API
                'dirInfo = New System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(Application.ExecutablePath)) '-- this gets us to the exe (TrulyMail) folder
                dirInfo = New System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(GetEXEFullPath())) '-- this gets us to the exe (TrulyMail) folder
                'dirInfo = dirInfo.Parent '-- this gets us to the App folder
                dirInfo = dirInfo.Parent '-- this gets us to the TrulyMailPortable folder

                DataRootPath = QualifyPath(dirInfo.FullName) & "Data\"
            Else
                '-- Installed on Windows, use user's profile
                DataRootPath = QualifyPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) & "TrulyMail\Data\"
            End If
            ProfileRootPath = DataRootPath & "Profile\" '-- relative to data is the same for portable and standard

            '-- setup profile path first
            MessageStoreRootPath = ProfileRootPath & "Messages\"


            '-- Here we are loading the AppSettings
            '   These could be encrypted (whole file encrypted in 5.1)
            '   And entering the wrong password stops the settings from loading, 
            '   which stops app from loading. So we need to loop until user enters the correct password
            Dim strEncryptionPassword As String
            Do
                strEncryptionPassword = Nothing
                Try
                    AppSettings = New ApplicationSettings()
                    If AppSettings.RequiresPasswordToLoad Then
                        strEncryptionPassword = GetInput("Please enter your startup password.", True)
                        If strEncryptionPassword = Chr(0) Then
                            '-- User clicked cancel, should exit
                            Exit Sub
                        Else
                            '-- should be OK to load the settings file
                        End If
                    Else
                        strEncryptionPassword = String.Empty
                    End If
                    AppSettings.Load(strEncryptionPassword)
                    Exit Do '-- loaded, so exit the loop and contine loading
                Catch ex As Exception
                    Log(ex)
                    If ex.Message = EXCEPTIONTEXT_APPSETTINGS_ENCRYPTED_WRONG_PASSWORD Then
                        Dim rslt As DialogResult = ShowMessageBox("There was an error loading your settings. If this is the first time you have seen this message, please make sure you are entering the correct startup password." & _
                                            Environment.NewLine & Environment.NewLine & "If you have seen this message several times and are sure you have the correct startup password, you can delete your settings and use your backup settings." & _
                                            Environment.NewLine & Environment.NewLine & "Do you want to enter your password again?" & _
                                            Environment.NewLine & Environment.NewLine & "Yes = Enter your startup password again." & _
                                            Environment.NewLine & "No = Delete settings file and use backup settings file." & _
                                            Environment.NewLine & "Cancel = Quit TrulyMail and do nothing.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button3)
                        Select Case rslt
                            Case DialogResult.Yes
                                '-- Do nothing, just loop around again
                            Case DialogResult.No
                                '-- delete settings file and use backup settings file and loop around
                                ApplicationSettings.RestoreFromBackupCopyOfSettingsFile()
                            Case DialogResult.Cancel
                                '-- quit app
                                Exit Sub
                        End Select
                    ElseIf ex.Message = EXCEPTIONTEXT_APPSETTINGS_CANNOT_LOAD Then
                        ShowMessageBoxError("There was an error loading your settings. TrulyMail is going to load your backup settings.")
                        Log("Restoring backup settings files")
                        ApplicationSettings.RestoreFromBackupCopyOfSettingsFile()
                    Else
                        ShowMessageBoxError("There was an error loading your settings. TrulyMail is going to use your backup settings.")
                        Log("Restoring backup settings files")
                        ApplicationSettings.RestoreFromBackupCopyOfSettingsFile()
                    End If
                End Try
            Loop

            MessageStoreTempPath = ProfileRootPath & "Temp\" '-- for temp messages (converting .eml files, etc.)
            InBoxRootPath = MessageStoreRootPath & INBOX_NAME & "\"
            OutboxRootPath = MessageStoreRootPath & OUTBOX_NAME & "\"
            TrashRootPath = MessageStoreRootPath & TRASH_NAME & "\"
            SentItemsRootPath = MessageStoreRootPath & SENTITEMS_NAME & "\"
            DraftsRootPath = MessageStoreRootPath & DRAFTS_FOLDER_NAME & "\"

            '-- Attachment folder should be at same level as Messages, i.e.:
            '-- Profile
            '   |
            '   --- Messages
            '   |   |
            '   |   --- InBox
            '   |   |
            '   |   --- Sent Items
            '   |   |
            '   |   --- Invitations Sent
            '   |
            '   --- Attachments
            '       |
            '       --- 123-123-123
            '       |   |
            '       |   --- file1.txt
            '       |
            '       --- 124-124-124
            '           |   
            '           --- file2.txt
            AttachmentsRootPath = ProfileRootPath & ATTACHMENTS_FOLDER_NAME & "\"
            EncryptionKeyRootPath = ProfileRootPath & ENCRYPTION_KEYS_FOLDER_NAME & "\"
            PictureRootPath = ProfileRootPath & PICTURES_FOLDER_NAME & "\"
            MySoundsPath = ProfileRootPath & SOUNDS_FOLDER_NAME & "\"

            '-- ensure paths exist
            If Not System.IO.Directory.Exists(MessageStoreRootPath) Then
                System.IO.Directory.CreateDirectory(MessageStoreRootPath)
            End If
            If Not System.IO.Directory.Exists(MessageStoreTempPath) Then
                System.IO.Directory.CreateDirectory(MessageStoreTempPath)
            End If
            If Not System.IO.Directory.Exists(InBoxRootPath) Then
                System.IO.Directory.CreateDirectory(InBoxRootPath)
            End If

            '-- See if we are upgrading from an earlier version which used different unsent foldername
            If Not System.IO.Directory.Exists(OutboxRootPath) Then
                Dim strUnsentRootPathPrevious = MessageStoreRootPath & UNSENT_NAME_PREVIOUS & "\"
                If Not System.IO.Directory.Exists(strUnsentRootPathPrevious) Then
                    System.IO.Directory.CreateDirectory(OutboxRootPath)
                Else
                    '-- rename previous foldername to current foldername
                    '   only if there was no folder with the current foldername
                    System.IO.Directory.Move(strUnsentRootPathPrevious, OutboxRootPath)
                End If
            End If

            If Not System.IO.Directory.Exists(SentItemsRootPath) Then
                System.IO.Directory.CreateDirectory(SentItemsRootPath)
            End If
            If Not System.IO.Directory.Exists(AttachmentsRootPath) Then
                System.IO.Directory.CreateDirectory(AttachmentsRootPath)
            End If
            'If Not System.IO.Directory.Exists(EncryptionKeyRootPath) Then
            '    System.IO.Directory.CreateDirectory(EncryptionKeyRootPath)
            '    '-- copy the server's public key to the keys folder
            '    Dim strSource As String = QualifyPath(System.IO.Path.GetDirectoryName(GetEXEFullPath())) & SERVER_KEY_FILENAME & KEY_FILENAME_EXTENSION
            '    Dim strDestination As String = EncryptionKeyRootPath & SERVER_KEY_FILENAME & KEY_FILENAME_EXTENSION
            '    System.IO.File.Copy(strSource, strDestination)
            'End If
            If Not System.IO.Directory.Exists(TrashRootPath) Then
                System.IO.Directory.CreateDirectory(TrashRootPath)
            End If
            If Not System.IO.Directory.Exists(DraftsRootPath) Then
                System.IO.Directory.CreateDirectory(DraftsRootPath)
            End If
            If Not System.IO.Directory.Exists(PictureRootPath) Then
                System.IO.Directory.CreateDirectory(PictureRootPath)
            End If

            If Not System.IO.Directory.Exists(MySoundsPath) Then
                System.IO.Directory.CreateDirectory(MySoundsPath)
            End If
            CopyAppSoundsToMySounds()


            '-- Setup global list if executable file extensions
            EXEFileExtensions = New List(Of String)
            EXEFileExtensions.AddRange(EXE_FILE_EXTENSIONS.Split(";"))

            '-- add date formats
            DateFormats = New List(Of String)
            DateFormats.Add("M/d/yyyy h:mm tt")
            DateFormats.Add("d/M/yyyy h:mm tt")
            DateFormats.Add("d MMM yyyy h:mm tt")
            DateFormats.Add("d MMMM yyyy h:mm tt")
            DateFormats.Add("M/d/yyyy HH:mm")
            DateFormats.Add("d/M/yyyy HH:mm")
            DateFormats.Add("d MMM yyyy HH:mm")
            DateFormats.Add("d MMMM yyyy HH:mm")


            '-- Check master password
            If AppSettings.MasterPasswordHashLong.Length > 0 Then
                '-- This must be the first time running v>=5.1 because we used to store as hash
                '   but now we encrypt the whole settings file and no need to store anything
                Dim strInput As String = GetInput("Please enter your Startup Password.", True)
                If strInput = Chr(0) Then
                    '-- User canceled
                    AppSettings = Nothing
                    Application.ExitThread()
                    Exit Sub
                Else
                    Dim hash() As Byte = GetContentHash(strInput)
                    Dim strHash As String = Convert.ToBase64String(hash)

                    If strHash = AppSettings.MasterPasswordHashLong Then
                        '-- Here we change from keeping the hash to keeping (in memory only) the master password
                        '   we never persist the master password and we also never persist the hash (would leave
                        '   the system open to a rainbow table attack)
                        AppSettings.MasterPassword = strInput

                    Else
                        ShowMessageBoxError("The entered password is not your startup password.")
                        AppSettings = Nothing
                        Application.ExitThread()
                        Exit Sub
                    End If
                End If
            End If


            'If AppSettings.Address.Length > 0 Then
            '    ABook = New AddressBook(True)
            'End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error loading your settings. TrulyMail cannot start. Try re-installing the latest version of TrulyMail." & _
                           Environment.NewLine & Environment.NewLine & _
                           "Please contact TrulyMail Support (at support@trulymail.com).")

            '-- REMOVE FOR LIVE
            'ShowMessageBoxError("The error: " & ex.Message & _
            '               Environment.NewLine & Environment.NewLine & _
            '               ex.StackTrace.ToString())

        End Try
    End Sub
    Private Sub CopyAppSoundsToMySounds()
        Try
            Dim strAppSoundsPath As String = System.IO.Path.GetDirectoryName(GetEXEFullPath())
            strAppSoundsPath = System.IO.Path.Combine(strAppSoundsPath, SOUNDS_FOLDER_NAME)
            Dim files() As String = System.IO.Directory.GetFiles(strAppSoundsPath, "*" & NOTIFY_SOUND_VALID_EXTENSION)
            For Each strFilename As String In files
                If Not System.IO.File.Exists(MySoundsPath & System.IO.Path.GetFileName(strFilename)) Then
                    System.IO.File.Copy(strFilename, MySoundsPath & System.IO.Path.GetFileName(strFilename))
                End If
            Next
        Catch ex As Exception
            Log("Failed to copy AppSounds to MySounds: " & ex.ToString())
        End Try
    End Sub
    Friend Function UnQualifyPath(ByVal path As String) As String
        If path.EndsWith("\") Then
            Return path.Substring(0, path.Length - 1)
        Else
            Return path
        End If
    End Function
    Friend Function ConvertPathToLocalDirectorSeparator(ByVal path As String) As String
        Return path.Replace("\", System.IO.Path.DirectorySeparatorChar).Replace(":", System.IO.Path.VolumeSeparatorChar)
    End Function
    Friend Function QualifyPath(ByVal path As String) As String
        If path.EndsWith("\") Then
            Return path
        Else
            Return path & System.IO.Path.DirectorySeparatorChar.ToString()
        End If
    End Function
    ''' <summary>
    ''' Returns as SHA512Managed has code
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetContentHash(ByVal text As String) As Byte()
        Try
            Dim sha As New System.Security.Cryptography.SHA512Managed()
            Dim hash As Byte() = sha.ComputeHash(System.Text.ASCIIEncoding.UTF8.GetBytes(text))
            Return hash
        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Function
    Friend Function GetFileHash(ByVal filePath As String) As Byte()
        Try
            Dim sha As New System.Security.Cryptography.SHA512Managed()
            Dim fs As System.IO.FileStream = System.IO.File.OpenRead(filePath)
            Dim hash As Byte() = sha.ComputeHash(fs)
            fs.Close()
            Return hash
        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Function
    Private Function UpdateAvailable(ByVal minimumVersion As String, ByVal latestVersion As String) As UpdateType
        If VersionIsSameLater(latestVersion, Application.ProductVersion) Then
            Return UpdateType.NoUpdate
        Else
            '-- current version must be between minimum and maximum or update is required
            If VersionIsSameLater(minimumVersion, Application.ProductVersion) Then
                Return UpdateType.RecommendedUpdate
            Else
                Return UpdateType.RequiredUpdate
            End If
        End If
    End Function
    Public Class VersionUpdateData
        Public Property UpdateType As UpdateType
        Public Property LastestVersion As String
        Public Property UpdateFileHash As String
        Public Property UpdateDateAvailable As Date
        Public Property IsBeta As Boolean
    End Class
    ''' <summary>
    ''' Returns true if versionToTest has the same or a later version number to it
    ''' </summary>
    ''' <param name="version"></param>
    ''' <param name="versionToTest"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function VersionIsSameLater(ByVal version As String, ByVal versionToTest As String) As Boolean
        '-- 1.0.0 vs. 1.2.3

        Dim intMajor1, intMinor1, intRevision1 As Integer
        Dim intMajor2, intMinor2, intRevision2 As Integer
        Const VERSION_DELIMITER As String = "."
        Dim intStartPos1 As Integer = 0
        Dim intStartPos2 As Integer = 0
        Dim intEndPos1 As Integer = version.IndexOf(VERSION_DELIMITER)
        Dim intEndPos2 As Integer = versionToTest.IndexOf(VERSION_DELIMITER)

        intMajor1 = Convert.ToInt32(version.Substring(intStartPos1, intEndPos1))
        intMajor2 = Convert.ToInt32(versionToTest.Substring(intStartPos2, intEndPos2))

        If intMajor2 > intMajor1 Then
            '-- Major is higher, nothing else matters
            Return True
        ElseIf intMajor2 < intMajor1 Then
            '-- major is lower, nothing else matters
            Return False
        End If

        intStartPos1 = intEndPos1 + 1
        intStartPos2 = intEndPos2 + 1
        intEndPos1 = version.IndexOf(VERSION_DELIMITER, intStartPos1)
        intEndPos2 = versionToTest.IndexOf(VERSION_DELIMITER, intStartPos2)

        intMinor1 = Convert.ToInt32(version.Substring(intStartPos1, intEndPos1 - intStartPos1))
        intMinor2 = Convert.ToInt32(versionToTest.Substring(intStartPos2, intEndPos2 - intStartPos2))
        If intMinor2 > intMinor1 Then
            Return True
        ElseIf intMinor2 < intMinor1 Then
            Return False
        End If

        intStartPos1 = intEndPos1 + 1
        intStartPos2 = intEndPos2 + 1

        intRevision1 = Convert.ToInt32(version.Substring(intStartPos1))
        intRevision2 = Convert.ToInt32(versionToTest.Substring(intStartPos2))
        If intRevision2 >= intRevision1 Then
            Return True
        Else
            Return False
        End If

    End Function

#End Region
#Region " Validation Logic "
    Friend Function IsValidServerAddress(ByVal address As String) As Boolean
        Dim regExPattern As String = "([\w\d:#@%/;$()~_?\+-=\\\.&]*)"
        Return MatchString(address, regExPattern)
    End Function
    Friend Function IsValidURL(ByVal url As String) As Boolean
        Dim regExPattern As String = "^https?://." '-- This one is super-simple. Http(s):// followed by any character becomes valid
        Return MatchString(url, regExPattern)
    End Function
    Friend Function IsGuid(ByVal value As String) As Boolean
        Dim regExPattern As String = "^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$"
        Return MatchString(value, regExPattern)
    End Function
    Friend Function IsValidEmailAddress(ByVal email As String) As Boolean
        ' Allows common email address that can start with a alphanumeric char and contain word, dash and period characters
        ' followed by a domain name meeting the same criteria followed by a alpha suffix between 2 and 9 character lone
        'Dim regExPattern As String = "^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
        '-- must allow forward slash because "20_166024_+zdFx9IeMoTCduG/wf/DyA@newsletters.microsoft.com" is a valid email addresss
        '-- must allow quotes because "Dr. John D. Andre" <drjdandre@gmail.com> is a valid email address
        '-- Nov 2012 added = because sgs_news-sc.1353389060.jbpdmdgfkiamnhciegmj-John=JohnMAndre.com@lists.shadowstats.com is a valid email address
        Dim regExPattern As String = "^[A-Z0-9._=%+-/]+@[A-Z0-9.-]+\.[A-Z]{2,4}$"
        Return MatchString(email, regExPattern)
    End Function
    Friend Function IsValidUserName(ByVal username As String) As Boolean
        ' Allows word characters [A-Za-z0-9_], single quote, dash and period
        ' must be at least two characters long and less then 128
        Dim regExPattern As String = "^[\w-'\.]{2,50}$"


        ' We also permit email address characters in user name. Set to false
        ' if you don't permit email addresses as usernames. 
        Dim allowEmailUsernames As Boolean = True


        If allowEmailUsernames Then
            Return MatchString(username, regExPattern) OrElse IsValidEmailAddress(username)
        Else
            Return MatchString(username, regExPattern)
        End If
    End Function
    Private Function MatchString(ByVal str As String, ByVal regexstr As String) As Boolean
        Dim pattern As New System.Text.RegularExpressions.Regex(regexstr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

        Return pattern.IsMatch(str)
    End Function
    Friend Sub EnsureTextBoxHasOnlyValidCharacters(ByVal txt As TextBox, ByVal name As String, ByVal acceptableChars As String)
        Dim strThisChar As String
        Dim intLastModifiedPosition As Integer = -1
        For intCounter As Integer = 0 To txt.Text.Length - 1
            If intCounter = txt.Text.Length Then
                Exit For
            End If
            strThisChar = txt.Text.Substring(intCounter, 1).ToUpper()
            If acceptableChars.IndexOf(strThisChar) < 0 Then
                If strThisChar = " " Then
                    MessageBox.Show("Space (' ') is not an allowable character for " & name & ".", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(strThisChar & " is not an allowable character for " & name & ".", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                txt.Text = txt.Text.Replace(strThisChar, String.Empty)
                intLastModifiedPosition = intCounter
            End If
        Next

        If intLastModifiedPosition >= 0 Then
            txt.SelectionStart = intLastModifiedPosition
            txt.SelectionLength = 0
        End If
    End Sub
#End Region



    ''' <summary>
    ''' Returns size formatted in KB, MB, or GB as appropriate
    ''' </summary>
    ''' <param name="TotalBytes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function FormatDataSizeString(ByVal TotalBytes As Long) As String
        Dim KB As Long = 1024
        Dim MB As Long = Convert.ToInt64(1024 ^ 2)
        Dim GB As Long = Convert.ToInt64(1024 ^ 3)
        Dim dbl As Double

        '-- compare to 90%
        Select Case TotalBytes
            Case Is >= GB * 0.9
                dbl = TotalBytes / GB
                If dbl >= 100 Then
                    Return dbl.ToString("#,##0 GB")
                Else
                    Return dbl.ToString("#,##0.# GB")
                End If
            Case Is >= MB * 0.9
                dbl = TotalBytes / MB
                If dbl >= 100 Then
                    Return dbl.ToString("#,##0 MB")
                Else
                    Return dbl.ToString("#,##0.# MB")
                End If
            Case Is >= KB * 0.9
                dbl = TotalBytes / KB
                If dbl >= 100 Then
                    Return dbl.ToString("#,##0 KB")
                Else
                    Return dbl.ToString("#,##0.# KB")
                End If
            Case Else
                Return TotalBytes.ToString("#,##0 B")
        End Select
    End Function
    Friend Function ConvertToUtc(ByVal localTime As Date) As Date
        '-- Convert the local time (for the current time zone for this machine)
        '   to UTC (time stored in createdate on server)
        Dim ts As TimeSpan
        Try
            If localTime = Date.MinValue Then
                Return Date.MinValue
            Else
                ts = TimeZone.CurrentTimeZone.GetUtcOffset(localTime)
                Return localTime.Subtract(ts)
            End If
        Catch ex As Exception
            Log(ex)
            Log("localTime: " * localTime.ToString() & Environment.NewLine & "ts hours: " & ts.TotalHours)
            Return Date.MinValue
        End Try
    End Function
    Friend Function ConvertToLocalTime(ByVal utcTime As Date) As Date
        '-- Convert the UTC time (time stored in createdate on server)
        '   to localtime (for the current time zone for this machine)
        Dim ts As TimeSpan
        Try
            If utcTime = Date.MinValue Then
                Return Date.MinValue
            Else
                ts = TimeZone.CurrentTimeZone.GetUtcOffset(Date.Now)
                Return utcTime.Add(ts)
            End If
        Catch ex As Exception
            Log(ex)
            Log("localTime: " * utcTime.ToString() & Environment.NewLine & "ts hours: " & ts.TotalHours)
            Return Date.MinValue
        End Try
    End Function
    ''' <summary>
    ''' Deletes a file, best efforts. Throws error if cannot delete
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <remarks></remarks>
    Friend Sub DeleteLocalFile(filename As String)
        Try
            '-- No need to throw an error just because the file doesn't exist
            If System.IO.File.Exists(filename) Then
                System.IO.File.SetAttributes(filename, IO.FileAttributes.Normal)
                System.IO.File.Delete(filename)
            End If
        Catch ex As Exception
            '-- Perhaps could not delete
            '   Log it and move on
            Log("Error: Could not delete local file: " & filename)
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Deletes a messages and its attachments
    ''' </summary>
    ''' <param name="filename">name of message file</param>
    ''' <param name="permanent">True to avoid trash and just delete the message</param>
    ''' <remarks></remarks>
    Friend Sub DeleteLocalMessage(ByVal filename As String, ByVal permanent As Boolean, ByVal markFileSystemChanged As Boolean)
        '-- if item is in trash, delete permanently, otherwise, move to trash
        If System.IO.File.Exists(filename) Then
            If filename.ToLower.StartsWith(TrashRootPath.ToLower()) OrElse permanent Then
                '-- delete attachments folder (if any)
                Try
                    Dim strMessageID As String = System.IO.Path.GetFileNameWithoutExtension(filename)
                    Dim strAttachmentsFolder As String = AttachmentsRootPath & strMessageID
                    If System.IO.Directory.Exists(strAttachmentsFolder) Then
                        ''-- First, delete all files in the folder
                        Dim files() As String = System.IO.Directory.GetFiles(strAttachmentsFolder, "*.*", IO.SearchOption.AllDirectories)
                        For Each strFilename As String In files
                            Try
                                Dim attr As System.IO.FileAttributes = System.IO.File.GetAttributes(strFilename)
                                If attr And System.IO.FileAttributes.ReadOnly = System.IO.FileAttributes.ReadOnly Then
                                    System.IO.File.SetAttributes(strFilename, IO.FileAttributes.Normal)
                                End If
                                DeleteLocalFile(strFilename)
                            Catch ex As Exception
                                Log(ex) '-- delete the files we can, log, and continue
                            End Try
                        Next
                        System.IO.Directory.Delete(strAttachmentsFolder, True)
                    End If

                    '-- delete message itself
                    DeleteLocalFile(filename)
                Catch ex As Exception
                    ShowMessageBox("The message could not be deleted because it or an attachment is in use. Please try again later.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End Try
            Else
                '-- Copy and delete
                '   This is so the createdate gets updated which we will use
                '   with the 'auto-delete after X- days' feature
                If System.IO.File.Exists(TrashRootPath & System.IO.Path.GetFileName(filename)) Then
                    DeleteLocalFile(TrashRootPath & System.IO.Path.GetFileName(filename))
                End If
                System.IO.File.Copy(filename, TrashRootPath & System.IO.Path.GetFileName(filename))
                DeleteLocalFile(filename)
            End If
        End If

        If markFileSystemChanged Then
            MainFormReference.ShowFolderContentsIfCurrent(System.IO.Path.GetDirectoryName(filename))
        End If
    End Sub
    Friend Function GetMessageAttachmentNames(ByVal messageXML As String) As String
        Dim xDoc As New Xml.XmlDocument()
        xDoc.LoadXml(messageXML)
        Dim xList As Xml.XmlNodeList = xDoc.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_ATTACHMENT)
        Dim xElement As Xml.XmlElement
        Dim strReturn As String = String.Empty
        For Each xElement In xList
            strReturn &= ", " & xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME)
        Next
        If strReturn.Length > 2 Then
            Return strReturn.Substring(2)
        Else
            Return "<none>"
        End If
    End Function
    Friend Function GetMessageAttachmentReference(ByVal messageXML As String) As String
        Dim xDoc As New Xml.XmlDocument()
        xDoc.LoadXml(messageXML)
        Dim xElement As Xml.XmlElement = xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_ATTACHMENTS)
        If xElement Is Nothing Then
            Return String.Empty
        Else
            Return xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_ATTACHMENTCYPHERKEY)
        End If
    End Function
    Friend Function GetMessageBody(ByVal messageXML As String) As String
        Dim xDoc As New Xml.XmlDocument()
        xDoc.LoadXml(messageXML)
        Dim xElement As Xml.XmlElement = xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_BODY)
        If xElement Is Nothing Then
            Return String.Empty
        Else
            Return xElement.InnerText.Trim
        End If
    End Function
    Friend Function GetMessageSubject(ByVal messageXML As String) As String
        Dim xDoc As New Xml.XmlDocument()
        xDoc.LoadXml(messageXML)
        Dim xElement As Xml.XmlElement = xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_SUBJECT)
        If xElement Is Nothing Then
            Return String.Empty
        Else
            Return xElement.InnerText.Trim
        End If
    End Function
    Friend Sub MarkLocalMessageRead(ByVal messageFilename As String, ByVal markUnread As Boolean)
        '-- Mark read, if not already so marked
        Try
            'Dim boolEmailReceiptSentManually As Boolean
            Dim tmm As New TrulyMailMessage(messageFilename)
            tmm.Read = Not markUnread '-- All logic has been moved to here

            If tmm.ShouldPromptToSendReadReceipt Then
                Dim strReceiptMessage As String = "The sender of this message (" & tmm.SendReadReceiptToAddress & ") has requested to be notified when you read this message." & _
                                                    Environment.NewLine & Environment.NewLine & _
                                                    "Do you wish to notify the sender (send a read receipt)?."
                If ShowMessageBox(strReceiptMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    tmm.SendReadReceipt(True)
                Else
                    tmm.ShouldPromptToSendReadReceipt = False

                    If AppSettings.AddNoteWhenSendingReturnReceipt Then
                        tmm.Notes &= Date.Today & "   " & "Chose not to send read receipt to " & tmm.SendReadReceiptToAddress & Environment.NewLine() & Environment.NewLine()
                    End If
                    tmm.Save()
                End If
            End If

            'If tmm.MessageType = MessageType.Communication Then

            '    If Not tmm.Read Then
            '        '-- Now we check whether we should send read receipt for this message


            '        If tmm.ReturnReceiptRequested AndAlso tmm.POPProfile IsNot Nothing AndAlso tmm.SendReadReceiptToAddress.Length > 0 Then
            '            Dim boolSendreceipt As Boolean
            '            Dim strReceiptMessage As String = "The sender of this message (" & tmm.SendReadReceiptToAddress & ") has requested to be notified when you read this message." & _
            '                                              Environment.NewLine & Environment.NewLine & "Do you wish to notify the sender."

            '            '-- is sender in address book?
            '            Dim entry As AddressBookEntry = ABook.GetContactByAddress(tmm.Sender.Address)
            '            If entry Is Nothing Then
            '                '-- unknown sender, use POP account settings
            '                Select Case tmm.POPProfile.SendReturnReceiptSenderNotInAddressBook
            '                    Case POPReceiptOption.Always
            '                        boolSendreceipt = True
            '                        boolEmailReceiptSentManually = False
            '                    Case POPReceiptOption.AskMe
            '                        If ShowMessageBox(strReceiptMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            '                            boolSendreceipt = True
            '                            boolEmailReceiptSentManually = True
            '                        Else
            '                            boolSendreceipt = False
            '                        End If
            '                    Case POPReceiptOption.Never
            '                        boolSendreceipt = False
            '                End Select
            '            Else
            '                '-- known sender, first check contact settings
            '                Select Case entry.AutoSendReadReceipt
            '                    Case ContactReceiptOption.UseDefault
            '                        '-- Get setting from POP account
            '                        Select Case tmm.POPProfile.SendReturnReceiptSenderInAddressBook
            '                            Case POPReceiptOption.Always
            '                                boolEmailReceiptSentManually = False
            '                                boolSendreceipt = True
            '                            Case POPReceiptOption.AskMe
            '                                If ShowMessageBox(strReceiptMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            '                                    boolSendreceipt = True
            '                                    boolEmailReceiptSentManually = True
            '                                Else
            '                                    boolSendreceipt = False
            '                                End If
            '                            Case POPReceiptOption.Never
            '                                boolSendreceipt = False
            '                        End Select
            '                    Case ContactReceiptOption.Always
            '                        boolEmailReceiptSentManually = False
            '                        boolSendreceipt = True
            '                    Case ContactReceiptOption.Never
            '                        boolSendreceipt = False
            '                End Select
            '            End If

            '            If boolSendreceipt Then
            '                SendEmailReadReceipt(messageFilename, tmm.SendReadReceiptToAddress, boolEmailReceiptSentManually)
            '                tmm.Notes &= Date.Today & "   " & "Sent read receipt to " & tmm.SendReadReceiptToAddress
            '            Else
            '                '-- We must record that user decided not to send receipt, or we keep prompting them
            '                tmm.ReturnReceiptRequested = False
            '                tmm.Notes &= Date.Today & "   " & "Chose to not send read receipt to " & tmm.SendReadReceiptToAddress
            '            End If
            '        Else
            '            '-- Nothing to do
            '            If tmm.POPProfile Is Nothing AndAlso tmm.SendReadReceiptToAddress.Length > 0 Then
            '                '-- the specified pop account does not exist
            '                Log("Specified pop account (" & tmm.POPProfile.ID & ") does not exist. Cannot send receipt.")
            '                ShowMessageBox("The sender (" & tmm.SendReadReceiptToAddress & ") requested a return receipt but your incoming email account has been removed so it cannot be sent.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            '            End If
            '        End If
            '    End If
            'End If

            'tmm.Read = Not markUnread
            'tmm.Save()
        Catch ex As Exception
            '-- Don't be overly worried about errors in this routine (but do log them).
            '   After all, at worse, we will send more than one 
            '   receipt (duplicates will be ignored by the other client)
            Log(ex)
        End Try
    End Sub
    Friend Sub SendEmailReadReceipt(ByVal messageFilename As String, ByVal sendToAddress As String, ByVal sentManually As Boolean)

        Dim xDoc As New Xml.XmlDocument()
        xDoc.Load(messageFilename)

        Dim strOriginalSubject As String = xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_SUBJECT).InnerText
        Dim strPOPID As String = xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_POPACCOUNT)
        Dim strOriginalRecipient As String = String.Empty
        Dim pop As POPProfile
        For Each popToCheck In AppSettings.POPProfiles
            If popToCheck.ID = strPOPID Then
                pop = popToCheck
                Exit For
            End If
        Next
        If IsValidEmailAddress(pop.Username) Then
            strOriginalRecipient = pop.Username
        Else
            For Each smtpToCheck In AppSettings.SMTPProfiles
                If smtpToCheck.ID = pop.SMTPProfileID Then
                    strOriginalRecipient = smtpToCheck.DisplayEmail
                    Exit For
                End If
            Next
        End If

        Dim lst As List(Of NameValuePair) = GetEmailHeaders(messageFilename)

        If strOriginalRecipient.Length = 0 Then
            '-- no email address to use, guess based on username@server
            'strOriginalRecipient = pop.Username & "@" & pop.ServerAddress
            For Each header As NameValuePair In lst
                If header.Name.ToLower() = "delivered-to" Then
                    strOriginalRecipient = header.Value
                    Exit For
                End If
            Next
            If Not IsValidEmailAddress(strOriginalRecipient) Then
                '-- cannot figure out a valid email address so skip this process
                Log("Cannot determine proper email address to use for return receipt.")
                ShowMessageBoxError("TrulyMail cannot determine what address to use for the return receipt. Please contact TrulyMail technical support.")
                Exit Sub
            End If
        End If

        Dim msgSender As New MessageSender(MessageType.Communication)
        msgSender.Subject = RETURN_RECEIPT_SUBJECT & strOriginalSubject
        msgSender.Body = "This is a Return Receipt for the mail that you sent to " & strOriginalRecipient & "." & _
                         Environment.NewLine & Environment.NewLine & _
                         "Note: This Return Receipt only acknowledges that the message was displayed on the recipient's computer. There is no guarantee that the recipient has read or understood the message contents."

        msgSender.BodyFormat = EmailBodyFormatEnum.PlainText

        Dim entry As New RecipientEntry(AddressBookEntryType.Email)
        entry.Address = sendToAddress
        msgSender.AddRecipient(entry)
        msgSender.SMTPAccount = GetSMTPAccountIDFromPOPAccountID(strPOPID)

        '-- Add MDNPart2.txt
        Dim strFilename As String
        Dim strContents As String

        Dim strFinalRecip As String = String.Empty
        If IsValidEmailAddress(pop.Username) Then
            strFinalRecip = pop.Username
        Else
            For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
                If smtp.ID = pop.SMTPProfileID Then
                    strFinalRecip = smtp.DisplayEmail
                    Exit For
                End If
            Next
        End If
        If strFinalRecip.Length = 0 Then
            '-- No idea the final address for this message
            '   default to the Delivered-To address
            For Each header As NameValuePair In lst
                If header.Name.ToLower() = "delivered-to" Then
                    strFinalRecip = header.Value
                    Exit For
                End If
            Next
        End If

        If strFinalRecip.Length = 0 Then
            '-- cannot send receipt
            Log("Cannot identify final recipient for email return receipt. Message: " & messageFilename)
            ShowMessageBoxError("TrulyMail cannot identify all necessary information (final recipient) to send the receipt. It will not be sent.")
            Exit Sub
        End If

        Dim strEmailMessageID As String = String.Empty

        For Each header As NameValuePair In lst
            If header.Name.ToLower() = "message-id" Then
                strEmailMessageID = header.Value
                Exit For
            End If
        Next


        If strFinalRecip.Length = 0 Then
            '-- cannot send receipt
            Log("Cannot identify Message-ID for email return receipt. Message: " & messageFilename)
            ShowMessageBoxError("TrulyMail cannot identify all necessary information (Message ID) to send the receipt. It will not be sent.")
            Exit Sub
        End If


        strFilename = QualifyPath(GetTempPath()) & "MDNPart2.txt"
        strContents = "Reporting-UA: TrulyMail " & Application.ProductVersion '"Reporting-UA: Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.8.1.19) Gecko/20081209 Thunderbird/2.0.0.19" & Environment.NewLine
        strContents &= "Final-Recipient: rfc822;" & strFinalRecip & Environment.NewLine
        strContents &= "Original-Message-ID: <" & strEmailMessageID & ">" & Environment.NewLine

        '-- Notify if it was processed manually or automatically
        If sentManually Then
            strContents &= "Disposition: manual-action/MDN-sent-manually; displayed" & Environment.NewLine
        Else
            strContents &= "Disposition: automatic-action/MDN-sent-automatically; displayed" & Environment.NewLine
        End If

        System.IO.File.WriteAllText(strFilename, strContents)
        msgSender.AddAttachment(strFilename)

        '-- Add MDNPart3.txt (all headers from original message)
        strFilename = QualifyPath(GetTempPath()) & "MDNPart3.txt"
        strContents = String.Empty
        For Each header As NameValuePair In lst
            strContents &= header.Name & ": " & header.Value & Environment.NewLine
        Next
        System.IO.File.WriteAllText(strFilename, strContents)
        msgSender.AddAttachment(strFilename)

        msgSender.SendMessage(Date.UtcNow)

    End Sub
    Friend Function GetEmailHeaders(ByVal filename As String) As List(Of NameValuePair)
        Dim lst As New List(Of NameValuePair)
        Dim pair As NameValuePair
        Try
            Dim xDoc As New Xml.XmlDocument()
            xDoc.Load(filename)
            Dim xList As Xml.XmlNodeList = xDoc.SelectNodes("//" & MESSAGE_ATTRIBUTE_NAME_HEADER)
            For Each xElement As Xml.XmlElement In xList
                pair = New NameValuePair()
                pair.Name = xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_NAME)
                pair.Value = xElement.InnerText
                lst.Add(pair)
            Next
            Return lst
        Catch ex As Exception
            Log(ex)
            Return lst
        End Try
    End Function
    ''' <summary>
    ''' Returns nothing if the SMTPProfile is not found
    ''' </summary>
    ''' <param name="smtpProfileID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetSMTPProfileByID(smtpProfileID As String) As SMTPProfile
        Try
            For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
                If smtp.ID = smtpProfileID Then
                    Return smtp
                End If
            Next

            '-- if we get here, we didn't find one
            Return Nothing
        Catch ex As Exception
            Log(ex)
            Return Nothing
        End Try
    End Function
    Friend Function GetSMTPAccountIDFromPOPAccountID(ByVal popID As String) As String
        For Each pop As POPProfile In AppSettings.POPProfiles
            If pop.ID = popID Then
                Return pop.SMTPProfileID
            End If
        Next
        Return String.Empty '-- default to empty string
    End Function
    Friend Enum MessageType
        Invite
        InviteAccept
        InviteReject
        Communication
        PublicKeyChange
        ReadReceipt
        Draft
        ResendEntireMessage
        ResendUndeliveredMessages
        AccountClosed
        LatestProfile
        ExternalReply
        RSSArticle
        PageChangeNotice
        NoteToSelf
    End Enum
    Friend Class ResendItem
        Public ResendAttachments As Boolean '- false to resend just body, subject, and attachment reference
        Public RecipientUserID As String '-- blank to resend to all, otherwise resend just to one
        Public RecipientID As String '-- MessageUserID, used when resending to a single recipient
        Public Filename As String '-- filename of message to resend
        Public Resendable As Boolean '-- false if message is missing from sent folder
    End Class
    Friend Enum AddressBookEntryType
        TrulyMail
        Email
    End Enum
    <Serializable()> Public Class RecipientEntry
        Private m_strAddress As String = String.Empty '-- not for TrulyMail contact types
        Private m_contactType As AddressBookEntryType '-- TrulyMail/email
        Private m_strID As String
        Private m_strFullName As String = String.Empty
        Private m_recipientType As RecipientType = RecipientType.Send_To '-- TO/CC/BCC
        Public ReceivedDate As Date
        Public ViewedDate As Date
        Public ResentDate As Date
        Public WebMessageQuestion As String = String.Empty
        Public WebMessagePassword As String = String.Empty

        Public Sub New(ByVal contactType As AddressBookEntryType)
            m_contactType = contactType
            m_strID = String.Empty
        End Sub
        Public Sub New(ByVal entry As AddressBookEntry)
            If entry IsNot Nothing Then
                m_strAddress = entry.Address
                m_strID = entry.ID
                m_contactType = entry.ContactType
                m_strFullName = entry.FullName
                Me.WebMessagePassword = entry.WebMailPassword
            End If
        End Sub
        ''' <summary>
        ''' Returns formatted 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return m_strFullName & "~" & m_strAddress & "~" & m_recipientType.ToString() & "~" & m_strID & "~" & m_contactType.ToString()
        End Function
        Public ReadOnly Property FormattedAsStandard As String
            Get
                If Me.ContactType = AddressBookEntryType.TrulyMail Then
                    Return m_strFullName
                Else
                    Return m_strFullName & " <" & m_strAddress & ">"
                End If
            End Get
        End Property

        Public Property Address() As String
            Get
                Return m_strAddress
            End Get
            Set(ByVal value As String)
                If m_contactType = AddressBookEntryType.TrulyMail Then
                    Throw New Exception("TrulyMail contacts do not have email addresses.")
                Else
                    m_strAddress = value
                End If
            End Set
        End Property
        Public Property ID() As String
            Get
                Return m_strID
            End Get
            Set(ByVal value As String)
                m_strID = value
            End Set
        End Property
        Public Property FullName() As String
            Get
                If m_contactType = AddressBookEntryType.Email Then
                    If AppSettings.EmailShowSenderAsSent Then
                        Return m_strFullName
                    Else
                        '-- get sender's name from address book, if it exists
                        Dim entry As AddressBookEntry = ABook.GetContactByAddress(m_strAddress) 'GetAddressBookEmailEntry(m_strAddress)
                        If entry Is Nothing Then
                            '-- Not in address book
                            Return m_strFullName
                        ElseIf entry.FullName.Length = 0 Then
                            '-- in address book but name is not in address book
                            Return m_strFullName
                        Else
                            '-- Use name from address book
                            Return entry.FullName
                        End If
                    End If
                Else
                    Return m_strFullName
                End If
            End Get
            Set(ByVal value As String)
                m_strFullName = value
            End Set
        End Property
        Public ReadOnly Property ContactType() As AddressBookEntryType
            Get
                Return m_contactType
            End Get
        End Property
        Public Property RecipientType() As RecipientType
            Get
                Return m_recipientType
            End Get
            Set(ByVal value As RecipientType)
                m_recipientType = value
            End Set
        End Property
        Public ReadOnly Property NameWithAddress() As String
            Get
                Return FullName & " <" & Address & ">"
            End Get
        End Property
    End Class

    Private m_dtLastErrorDisplayed As Date '-- We will only display errors every x seconds (AppSetting)
    Private Function OKToShowError() As Boolean
        '-- Simple logic, if it's been over x seconds, then return true
        Dim ts As TimeSpan = Date.Now - m_dtLastErrorDisplayed
        Return ts.TotalSeconds > AppSettings.DisplayErrorIntervalSeconds
    End Function
    ''' <summary>
    ''' Shows message box with error icon and ok button
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Friend Sub ShowMessageBoxError(ByVal message As String)
        If OKToShowError() Then
            ShowMessageBox(message, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            m_dtLastErrorDisplayed = Date.Now '-- reset for next time
        End If
    End Sub
    Private Delegate Function ShowMessageBoxCallback(ByVal message As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
    ''' <summary>
    ''' Show messagebox even from background thread
    ''' </summary>
    ''' <param name="message"></param>
    ''' <param name="buttons"></param>
    ''' <param name="icon"></param>
    ''' <remarks></remarks>
    Friend Function ShowMessageBox(ByVal message As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
        If MainFormReference.InvokeRequired Then
            Dim deleg As New ShowMessageBoxCallback(AddressOf ShowMessageBox)
            Return MainFormReference.Invoke(deleg, message, buttons, icon, defaultButton)
        Else
            Return MessageBox.Show(message, Application.ProductName, buttons, icon, defaultButton)
        End If
    End Function
    Private Delegate Sub ShowMessageBoxAutoCloseCallback(ByVal message As String, ByVal seconds As Integer)
    ''' <summary>
    ''' Show an auto-closing messagebox even from background thread
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Friend Sub ShowMessageBoxAutoClose(ByVal message As String, ByVal seconds As Integer)
        If MainFormReference.InvokeRequired Then
            Dim deleg As New ShowMessageBoxAutoCloseCallback(AddressOf ShowMessageBoxAutoClose)
            MainFormReference.Invoke(deleg, message, seconds)
        Else
            Dim frm As New AutoCloseMessageBox(message, seconds)
            frm.ShowDialog(MainFormReference)
        End If
    End Sub
    Friend Sub ShowOpacityNotice(ByVal message As String, ByVal seconds As Double)
        If MainFormReference.InvokeRequired Then
            Dim deleg As New ShowMessageBoxAutoCloseCallback(AddressOf ShowOpacityNotice)
            MainFormReference.Invoke(deleg, message, seconds)
        Else
            Dim frm As New OpacityNoticeForm(message, seconds)
            frm.Show(MainFormReference)
        End If
    End Sub
    ''' <summary>
    ''' Returns the new draft filename
    ''' </summary>
    ''' <param name="filename">Filename of the non-draft message to be modified</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function MakeMessageDraft(ByVal filename As String) As String
        Dim xDoc As New Xml.XmlDocument()
        xDoc.Load(filename)
        Select Case xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGETYPEID)
            Case MESSAGETYPE_COMMUNICATION
                xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGETYPEID, MESSAGETYPE_DRAFT_COMMUNICATION)
        End Select
        Dim strMessageID As String = xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGEID)

        '-- We keep the same messageID and the existing attachments folder
        Dim strDraftFilename As String = GetNewDraftFilename(strMessageID)

        If filename.ToLower <> strDraftFilename.ToLower Then
            DeleteLocalFile(filename) '-- just delete the message file, not the attachments folder
        End If

        '-- save as draft, delete unsent, update UI
        xDoc.Save(strDraftFilename)

        g_boolFileSystemChanged = True

        Return strDraftFilename
    End Function
    Friend Sub LoadCommunicationMessage(ByVal filename As String, asPlainText As Boolean)
        '-- if communication is has not yet been sent, then open in editor
        '   otherwise, open in reader
        Dim xDoc As New Xml.XmlDocument()
        xDoc.Load(filename)
        If xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_SENTDATE).Length > 0 Then
            '-- open in reader
            Dim tmm As New TrulyMailMessage(filename) 'todo: Change this to have the whole call stack deal with tmm objects, not just going to the file system all the time
            Dim frm As New ReadMessage2(tmm, asPlainText)
            frm.Show()
        Else
            '-- not yet sent, open in editor
            '   Make a draft out of the existing message
            Dim strDraftFilename As String = MakeMessageDraft(filename)

            '   then open the draft
            Dim frm As IComposeForm
            If UseFallbackModeNow() Then
                frm = New NewMessageSimple(strDraftFilename)
            Else
                frm = New NewMessage(strDraftFilename)
            End If
            CType(frm, Form).Show()
        End If
    End Sub
    Friend Function CompareAddressBookEntries(ByVal x As AddressBookEntry, ByVal y As AddressBookEntry) As Integer
        '-- < 0 means x comes before y
        '   = 0 means x and y are the same
        '   > 0 means x comes after y
        If x Is Nothing Then
            If y Is Nothing Then
                Return 0 '-- equal
            Else
                Return -1 '--y is higher
            End If
        Else
            If y Is Nothing Then
                Return 1 '-- x is higher
            Else
                '-- x and y are something
                If x.ContactType = AddressBookEntryType.TrulyMail Then
                    If y.ContactType = AddressBookEntryType.TrulyMail Then
                        '-- two TM contacts, sort by name and address
                        Return x.NameWithAddress.CompareTo(y.NameWithAddress)
                    Else
                        Return -1 '-- TM contacts come first
                    End If
                Else
                    If y.ContactType = AddressBookEntryType.TrulyMail Then
                        Return 1 '-- TM contacts come first
                    Else
                        '-- two email contacts, sort by name and address
                        Return x.NameWithAddress.CompareTo(y.NameWithAddress)
                    End If
                End If
            End If
        End If
    End Function

    Friend Sub EditContactDetails(ByVal userID As String)
        If IsGuid(userID) Then
            Dim frm As New EditContactK(userID)
            frm.ShowDialog()
        Else
            ShowMessageBoxError("This user is not in your address book.")
        End If
    End Sub
    Friend Sub LoadMessage(ByVal filename As String)
        If System.IO.File.Exists(filename) Then
            Dim xDoc As New Xml.XmlDocument()
            xDoc.Load(filename)
            Dim strMessageTypeID As String = xDoc.DocumentElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGETYPEID)
            xDoc = Nothing

            Select Case strMessageTypeID
                Case MESSAGETYPE_COMMUNICATION, MESSAGETYPE_RSSARTICLE
                    LoadCommunicationMessage(filename, False)
                Case MESSAGETYPE_DRAFT_COMMUNICATION
                    Dim frm As IComposeForm
                    If UseFallbackModeNow() Then
                        frm = New NewMessageSimple(filename)
                    Else
                        frm = New NewMessage(filename)
                    End If
                    CType(frm, Form).Show()
                Case Else
                    '-- should never get here
                    Log("Unknown messagetypeID: " & strMessageTypeID)
                    Application.DoEvents() '-- for breakpoint only
            End Select
        Else
            Log("Cannot find message: " & filename)
            MessageBox.Show("The selected message cannot be found.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Public Function GetNewOutboxFilename(ByVal messageID As String) As String
        Return OutboxRootPath & messageID & MESSAGE_FILENAME_EXTENSION
    End Function
    Public Function GetNewDraftFilename(ByVal messageID As String) As String
        Return DraftsRootPath & messageID & MESSAGE_FILENAME_EXTENSION
    End Function

    ' We will queue up error msgs to display so we can limit to displaying one no more often than every 10 seconds
#Region " Error Logging "
    Private m_LogQueue As New Concurrent.ConcurrentQueue(Of String) '-- This is thread-safe (normal queue is not)
    Private m_boolProcessingLogQueue As Boolean '-- True if we are busy writing the queue to the log file
    Private Sub ProcessLogQueue()
        '-- Here is where we actually write the log
        If m_boolProcessingLogQueue Then
            Exit Sub '-- We are already in here (perhaps on another thread) so just get out
        End If

        Dim strData As String
        Dim strNextItem As String

        Try
            m_boolProcessingLogQueue = True


            Do While m_LogQueue.TryDequeue(strNextItem) '-- will return false if the queue is empty
                strData = Date.Now & vbTab & Application.ProductVersion & vbTab & strNextItem & Environment.NewLine & Environment.NewLine

                If System.IO.File.Exists(AppSettings.LogFileLocation) Then
                    System.IO.File.AppendAllText(AppSettings.LogFileLocation, strData)
                Else
                    If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(AppSettings.LogFileLocation)) Then
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(AppSettings.LogFileLocation))
                    End If
                    System.IO.File.WriteAllText(AppSettings.LogFileLocation, "x64: " & (IntPtr.Size = 8) & Environment.NewLine)
                    System.IO.File.AppendAllText(AppSettings.LogFileLocation, strData)
                End If
            Loop

        Catch ex As Exception
            '-- Now that we use a queue in 6.0 we should never get here (because the file can't be locked)
            '-- Let user see the error logging and also the error that was originally being logged
            Dim strMessageText As String = "There was an error writing to the error log file. Would you like to see the message?"

            '-- Only try to show the contents of the msg to be logged if we have the message in the string variable
            If strNextItem IsNot Nothing AndAlso strData.Length > 0 Then
                If MessageBox.Show(strMessageText, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If MessageBox.Show(ex.Message & Environment.NewLine & Environment.NewLine & "Would you like to see what was going to be logged?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        MessageBox.Show(strNextItem & Environment.NewLine & Environment.NewLine & ex.StackTrace, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        End Try

        m_boolProcessingLogQueue = False '-- Reset for next time
    End Sub
    Friend Sub Log(ByVal text As String)
        Try
            If AppSettings IsNot Nothing AndAlso AppSettings.EnableLogging AndAlso AppSettings.LogFileLocation IsNot Nothing AndAlso AppSettings.LogFileLocation.Length > 0 Then
                '-- Queue it up so multiple threads don't lock the log file causing problems
                Dim strData As String = Date.Now & vbTab & Application.ProductVersion & vbTab & text & Environment.NewLine & Environment.NewLine

                '-- Queue it up and let the processing element handle it
                m_LogQueue.Enqueue(strData)
                ProcessLogQueue()
            End If
        Catch ex As Exception
            '-- Let user see the error logging and also the error that was originally being logged
            Dim strMessageText As String = "There was an error writing to the error log. Would you like to see the message?"
            'Dim a As New AutoCloseMessageBox(strMessageText, STANDARD_MESSAGEBOX_ATUO_CLOSE_DELAY)
            'If a.ShowDialog = DialogResult.Yes Then

            'End If
            If MessageBox.Show(strMessageText, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If MessageBox.Show(ex.Message & Environment.NewLine & Environment.NewLine & "Would you like to see what was going to be logged?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    MessageBox.Show(text & Environment.NewLine & Environment.NewLine & ex.StackTrace, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End Try
    End Sub
    Friend Sub Log(ByVal ex As Exception)
        Try
            If AppSettings.LogFileLocation.Length > 0 Then
                Log(ex.Message & Environment.NewLine & ex.StackTrace)
            End If
        Catch ex1 As Exception
            'TODO: warn user every 15 minutes if cannot log
            Application.DoEvents() '-- for breakpoint only
        End Try
    End Sub
    ''' <summary>
    ''' Returns true if the file given can be written to
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function FileIsWritable(ByVal filename As String) As Boolean
        Try
            If System.IO.File.Exists(filename) Then
                '-- try to append a CRLF (should be harmless to any text file
                Dim sw As System.IO.StreamWriter = System.IO.File.AppendText(filename)
                sw.WriteLine()
                sw.Close()
                Return True
            Else
                '-- try to create, write, then delete the file
                If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(filename)) Then
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filename))
                End If
                Dim sw As System.IO.StreamWriter = System.IO.File.CreateText(filename)
                sw.Write("This is a test. This is only a test.")
                sw.Close()
                DeleteLocalFile(filename)
                '-- if we get here, then all is fine
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region
    Public Function GetUserSelectedDate(caller As Form) As Date
        Try
            Dim frm As New DateSelectorK()
            If frm.ShowDialog(caller) = DialogResult.OK Then
                Return frm.DateTime
            Else
                Return Date.MinValue
            End If
        Catch ex As Exception
            '-- There is a problem inside krypton control, so just blow paste it
            '   return the minimum
            Log(ex)
            Return Date.MinValue
        End Try

    End Function
    Friend Sub CopyDirectory(ByVal sourcePath As String, ByVal destPath As String, Optional ByVal Overwrite As Boolean = False)
        Dim SourceDir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(sourcePath)
        Dim DestDir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(destPath)

        ' the source directory must exist, otherwise throw an exception
        If SourceDir.Exists Then
            ' if destination SubDir's parent SubDir does not exist throw an exception
            If Not DestDir.Parent.Exists Then
                Throw New System.IO.DirectoryNotFoundException _
                    ("Destination directory does not exist: " + DestDir.Parent.FullName)
            End If

            If Not DestDir.Exists Then
                DestDir.Create()
            End If

            ' copy all the files of the current directory
            Dim ChildFile As System.IO.FileInfo
            For Each ChildFile In SourceDir.GetFiles()
                If Overwrite Then
                    If (ChildFile.Attributes And IO.FileAttributes.ReadOnly) = IO.FileAttributes.ReadOnly Then
                        ChildFile.Attributes = ChildFile.Attributes - IO.FileAttributes.ReadOnly
                    End If
                    ChildFile.CopyTo(System.IO.Path.Combine(DestDir.FullName, ChildFile.Name), True)
                Else
                    ' if Overwrite = false, copy the file only if it does not exist
                    ' this is done to avoid an IOException if a file already exists
                    ' this way the other files can be copied anyway...
                    If Not System.IO.File.Exists(System.IO.Path.Combine(DestDir.FullName, ChildFile.Name)) Then
                        If (ChildFile.Attributes And IO.FileAttributes.ReadOnly) = IO.FileAttributes.ReadOnly Then
                            ChildFile.Attributes = ChildFile.Attributes - IO.FileAttributes.ReadOnly
                        End If
                        ChildFile.CopyTo(System.IO.Path.Combine(DestDir.FullName, ChildFile.Name), False)
                    End If
                End If
            Next

            ' copy all the sub-directories by recursively calling this same routine
            Dim SubDir As System.IO.DirectoryInfo
            For Each SubDir In SourceDir.GetDirectories()
                CopyDirectory(SubDir.FullName, System.IO.Path.Combine(DestDir.FullName, _
                    SubDir.Name), Overwrite)
            Next
        Else
            Throw New System.IO.DirectoryNotFoundException("Source directory does not exist: " + SourceDir.FullName)
        End If
    End Sub
    '''' <summary>
    '''' Adds attributes to address book entries to support email contacts
    '''' </summary>
    '''' <remarks></remarks>
    'Friend Sub UpgradeAddressBookToVersion2()
    '    Dim xDoc As Xml.XmlDocument = LoadAddressBook()
    '    Dim xList As Xml.XmlNodeList = xDoc.SelectNodes("//" & ADDRESSBOOK_ATTRIBUTE_NAME_CONTACT)
    '    For Each xContact As Xml.XmlElement In xList
    '        If xContact.GetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_CONTACTTYPE).Length = 0 Then
    '            xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_ADDRESS, String.Empty)
    '            xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_CONTACTTYPE, [Enum].GetName(GetType(AddressBookEntryType), AddressBookEntryType.TrulyMail))
    '            xContact.SetAttribute(ADDRESSBOOK_ATTRIBUTE_NAME_REMOTEIMAGES, True) '-- Assume trulymail contacts get remote images loaded automatically
    '        Else
    '            '-- addressbook entry is already at version 2.0 or above so nothing to change
    '        End If
    '    Next
    '    SaveAddressBook(xDoc)
    'End Sub

    Friend Function LoadAddressBook() As Xml.XmlDocument
        '-- These two routines should allow us to save time loading the address book file
        '   from disk so many times
        Static xDoc As Xml.XmlDocument
        If xDoc Is Nothing OrElse ReloadAddressbook Then
            xDoc = New Xml.XmlDocument()

            If AddressBookExists() Then
                xDoc.Load(GetAddressBookPath())
            Else
                xDoc.AppendChild(xDoc.CreateElement("AddressBook"))
            End If

            ReloadAddressbook = False
        End If
        Return xDoc
    End Function
    Friend Sub SaveAddressBook(ByVal addressBook As Xml.XmlDocument)
        Try
            addressBook.Save(GetAddressBookPath())
            ReloadAddressbook = True
        Catch ex As Exception
            Log(ex)
            If ex.Message.StartsWith("The requested operation cannot be performed on a file with a user-mapped section open.") Then
                Application.DoEvents() '-- ignore, don't know what is really causing this error but it is frustrating.
            Else
                ShowMessageBoxError("There was an error trying to update your address book. If this error repeats, please contact TrulyMail Support for assistance.")
            End If
        End Try
    End Sub
    Friend Function GetIEPageSetupKey() As Microsoft.Win32.RegistryKey
        Return Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Internet Explorer\PageSetup", True)
    End Function
    Friend Function GetInput(ByVal message As String, ByVal isPassword As Boolean, Optional ByVal defaultText As String = "") As String
        Dim frm As New InputBox(message, isPassword)
        frm.Input = defaultText
        If frm.ShowDialog() = DialogResult.OK Then
            Return frm.Input
        Else
            Return Chr(0)
        End If

    End Function
    Friend Function UnURLEncodeFilePath(ByVal filename As String) As String
        Dim strReturn As String = filename
        If filename.ToLower.StartsWith("file:///") Then
            strReturn = filename.Substring(8)
        End If

        strReturn = strReturn.Replace("%20", " ") '-- no need to url encode but the control does so automatically
        strReturn = strReturn.Replace("/", "\") '-- in the url encoding, it switches the directory separator character
        strReturn = strReturn.Replace("%5C", "\")
        strReturn = strReturn.Replace("%255C", "\")

        Return strReturn
    End Function

    Friend Function GetHTMLAfterParseOutEmbeddedImages(ByVal messageID As String, ByVal bodyHTML As String, ByRef htImages As Hashtable) As String
        '-- This routine will parse all img HTML tags, change the image locations (src=) 
        '   to the attachments folder, it will move all the images from their source location
        '   to the attachemnts folder, it will populate the hashtable with the images so they can be uploaded
        '   as attachments to this message
        Const MAX_EMBEDDED_IMAGE_FILENAME_LENGTH As Integer = 40

        htImages.Clear()
        Dim browser As New WebBrowser()
        browser.DocumentText = bodyHTML
        Application.DoEvents()
        Dim imageNodes As HtmlElementCollection = browser.Document.GetElementsByTagName("img")

        Dim strImageFolderAbsoluteName As String = AttachmentsRootPath & messageID & "\" & IMAGES_EMBEDDED_FOLDER
        Dim strImageFolderRelativeName As String = ATTACHMENTS_FOLDER_REPLACEMENT_CODE & messageID & "\" & IMAGES_EMBEDDED_FOLDER
        Dim strFullName As String
        Dim strNewAsolutePath As String
        Dim strNewRelativePath As String
        Dim strBaseFilename As String
        Dim strFileExtention As String
        Dim intCounter As Integer
        Dim item As HtmlElement

        '-- I'm not crazy about this but I see no other way
        '   if an image is not found when trying to copy it, then
        '   we will strip out the <img tag altogether. I tried setting the outerhtml 
        '   but is always remains unchanged
        Dim lstStringsToRemove As New List(Of String)

        For intImageCounter As Integer = 0 To imageNodes.Count - 1
            item = imageNodes(intImageCounter)

            Try
                strFullName = item.GetAttribute("src")
            Catch ex As Exception
                Log(ex)
                Log("No src tag for image. intImageCounter: " & intImageCounter.ToString & "; imageNodes.Count: " & imageNodes.Count.ToString() & "; item is nothing: " & (item Is Nothing))
                Continue For '-- cannot process without src tag, so just move on
            End Try

            strFullName = UnURLEncodeFilePath(strFullName)

            If Not strFullName.Contains("://") AndAlso strFullName.Length > 1 AndAlso strFullName.Substring(1, 1) = ":" Then
                '-- img tag points to web reference or a local file in the format 'c:\blah.jpg'
                Dim strName As String = System.IO.Path.GetFileName(strFullName)

                If Not htImages.ContainsKey(strFullName) Then
                    '-- If filename is too long, change to guid
                    If strName.Length > MAX_EMBEDDED_IMAGE_FILENAME_LENGTH Then
                        strName = Guid.NewGuid.ToString & System.IO.Path.GetExtension(strFullName)
                    End If
                    strNewRelativePath = strImageFolderRelativeName & strName
                    strNewAsolutePath = strImageFolderAbsoluteName & strName

                    If System.IO.File.Exists(strNewAsolutePath) Then
                        strBaseFilename = System.IO.Path.GetFileNameWithoutExtension(strFullName)
                        strFileExtention = System.IO.Path.GetExtension(strFullName)
                        intCounter = 0
                        Do Until Not System.IO.File.Exists(strNewAsolutePath) OrElse Not htImages.ContainsValue(strNewAsolutePath)
                            '-- Generate unique filename by counting up until the name is unique
                            intCounter += 1
                            strNewAsolutePath = strImageFolderAbsoluteName & strBaseFilename & intCounter.ToString() & strFileExtention
                            strNewRelativePath = strImageFolderRelativeName & strBaseFilename & intCounter.ToString() & strFileExtention
                        Loop
                    End If

                    '-- copy image to attachments folder
                    If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strNewAsolutePath)) Then
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strNewAsolutePath))
                    End If

                    Try
                        System.IO.File.Copy(strFullName, strNewAsolutePath, True)
                    Catch ex As Exception
                        Log(ex)
                        If ex.Message.Contains("The process cannot access the file") AndAlso ex.Message.Contains("because it is being used by another process") Then
                            '-- Not sure why the file would be in use but assume the source file is not changing, so skip it
                        ElseIf ex.Message.Contains("Could not find a part of the path ") OrElse ex.Message.Contains("Could not find file ") Then
                            Dim strFilename As String
                            '-- if image is in the attachments folder, assuming the user just needs the name
                            '   otherwise, show the full path to the problem file
                            If strFullName.ToLower.StartsWith(AttachmentsRootPath.ToLower) Then
                                strFilename = System.IO.Path.GetFileName(strFullName)
                            Else
                                strFilename = strFullName
                            End If
                            Dim rslt As DialogResult = ShowMessageBox("One of your attachments (" & strFilename & ") could not be found. Would you like to remove it?" & _
                                              Environment.NewLine & Environment.NewLine & _
                                              "Yes = remove the missing image from the message" & Environment.NewLine & _
                                              "No = do not remove the missing image and continue" & Environment.NewLine & _
                                              "Cancel = do nothing, return to message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            Select Case rslt
                                Case DialogResult.Yes
                                    '-- file not found, remove the img tag
                                    lstStringsToRemove.Add(item.OuterHtml)
                                    Continue For
                                Case DialogResult.No
                                    '-- Ignore and keep going
                                    Continue For
                                Case DialogResult.Cancel
                                    '-- throw exception so we don't keep doing whatever we were doing
                                    Throw New System.IO.FileNotFoundException()
                            End Select
                        Else
                            '-- some other error, should never get here
                            ShowMessageBoxAutoClose("There was an error (" & ex.Message & ")." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE, 30)
                            Throw ex
                        End If
                    End Try

                    '-- No need to process image that has already been processed here
                    If Not htImages.ContainsKey(strFullName) Then
                        htImages.Add(strFullName, strNewAsolutePath)
                    Else
                        Dim x As Integer = 0 '-- For breakpoint only, should never get here
                    End If
                    'TODO: Catch error if strFullName does not exist on disk
                    item.SetAttribute("src", strNewRelativePath)
                Else
                    '-- same image may be embeded more than once
                    '   here we must repoint the source attribute to 
                    '   the Message's image folder, not the app's smily folder
                    strNewAsolutePath = htImages(strFullName)
                    strNewRelativePath = strImageFolderRelativeName & System.IO.Path.GetFileName(strNewAsolutePath)
                    item.SetAttribute("src", strNewRelativePath)
                End If
            End If
        Next

        Dim strReturn As String
        'for debugging: System.IO.File.WriteAllText(SentItemsRootPath & "test.html", doc.HTML)
        If htImages.Count > 0 AndAlso browser.Document.Body IsNot Nothing Then
            strReturn = browser.Document.Body.OuterHtml
        Else
            strReturn = bodyHTML '-- getting here means the html was not loaded at the start of this routine or there were no images
        End If

        For Each strToRemove As String In lstStringsToRemove
            strReturn = strReturn.Replace(strToRemove, String.Empty)
        Next

        Return strReturn
    End Function
#Region " ObjectListView Helpers "
    Friend Sub AutoSizeColumn(ByVal col As ColumnHeader, Optional ByVal SkipHeaderSize As Boolean = False)
        If SkipHeaderSize Then
            col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        Else
            col.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
            Dim intWidth As Integer = col.Width
            col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)

            If intWidth > col.Width Then
                col.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
            End If
        End If
    End Sub
    Friend Delegate Sub AutoSizeColumnsCallback(ByVal lv As ListView)
    Friend Sub AutoSizeColumns(ByVal lv As ListView)
        If lv.InvokeRequired Then
            Dim deleg As New AutoSizeColumnsCallback(AddressOf AutoSizeColumns)
            lv.Invoke(deleg, lv)
        Else
            'Dim intColumn As Integer
            For Each col As ColumnHeader In lv.Columns
                'intColumn += 1
                'If intColumn = lv.Columns.Count Then
                '    AutoSizeColumn(col, True)
                'Else
                AutoSizeColumn(col)
                'End If

                '-- special logic for subject column to account for the image which takes up some space
                If MainFormReference IsNot Nothing Then
                    If col.Text = MainFormReference.olvColumnSubject.Text Then
                        col.Width += 16
                    End If
                End If
            Next
        End If
    End Sub
#End Region
    Friend Function GetDictionaryPath() As String
        Return QualifyPath(System.IO.Path.GetDirectoryName(GetEXEFullPath())) & DICTIONARY_FOLDER_NAME
    End Function
    Friend Function GetDictionaries() As String()
        Dim strPath As String = GetDictionaryPath()
        If Not System.IO.Directory.Exists(strPath) Then
            System.IO.Directory.CreateDirectory(strPath)
        End If
        Dim files() As String = System.IO.Directory.GetFiles(strPath, "*" & DICTIONARY_FILENAME_EXTENSION)
        Return files
    End Function
    Friend Function GetDomainFromEmailAddress(ByVal emailAddress As String) As String
        Return emailAddress.Substring(emailAddress.IndexOf("@") + 1)
    End Function
    Friend Function GetUserNameFromEmailAddress(ByVal emailAddress As String) As String
        Return emailAddress.Substring(0, emailAddress.IndexOf("@"))
    End Function
    


#Region " HTML Manipulation Code "
    Friend Function BlockRemoteImages(ByVal html As String, ByRef imagesBlocked As Integer) As String
        Dim p As New Majestic12.HTMLparser(html)
        p.SetChunkHashMode(False)
        p.bAutoKeepScripts = False
        p.bAutoKeepComments = False

        Dim chunk As Majestic12.HTMLchunk
        Dim sbReturn As New System.Text.StringBuilder()
        Dim intStartingPosition As Integer = 0
        Dim strNewFullTag As String = String.Empty
        Const BLOCK_PREFIX As String = "---"
        Dim boolNodeAffected As Boolean

        imagesBlocked = 0

        Do While True
            chunk = p.ParseNext()
            If chunk Is Nothing Then
                Exit Do
            End If

            boolNodeAffected = False
            Select Case chunk.oType
                Case Majestic12.HTMLchunkType.OpenTag
                    Select Case chunk.sTag
                        Case Is = "img"
                            strNewFullTag = String.Empty
                            For intCounter As Integer = 0 To chunk.iParams - 1
                                If chunk.sParams(intCounter) = "src" Then
                                    If chunk.sValues(intCounter).IndexOf("://") >= 0 AndAlso Not chunk.sValues(intCounter).StartsWith(BLOCK_PREFIX) AndAlso Not chunk.sValues(intCounter).ToLower.IndexOf("file:///") >= 0 Then
                                        '-- remote image
                                        '   add prefix to src to prevent it from loading
                                        chunk.sValues(intCounter) = BLOCK_PREFIX & chunk.sValues(intCounter)
                                        strNewFullTag = chunk.GenerateHTML
                                        imagesBlocked += 1
                                        boolNodeAffected = True
                                    End If
                                    Exit For
                                End If
                            Next

                            If boolNodeAffected Then
                                '-- First get the unaffected part before the current chunk
                                If html.Length > intStartingPosition Then
                                    sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))
                                End If

                                '-- Next, append the current chunk with modifications
                                sbReturn.Append(strNewFullTag)

                                '-- Next, reposition for the next time around
                                intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength
                            End If
                    End Select
            End Select
        Loop

        '-- get trailing html after last tag was processed
        If html.Length > intStartingPosition Then
            sbReturn.Append(html.Substring(intStartingPosition))
        End If

        Return sbReturn.ToString()
    End Function

    Friend Function UnBlockRemoteImages(ByVal html As String, ByVal markMessage As Boolean, ByVal messageFilename As String) As String
        Dim p As New Majestic12.HTMLparser(html)
        p.SetChunkHashMode(False)
        p.bAutoKeepScripts = False
        p.bAutoKeepComments = False

        Dim chunk As Majestic12.HTMLchunk
        Dim sbReturn As New System.Text.StringBuilder()
        Dim intStartingPosition As Integer = 0
        Dim strNewFullTag As String = String.Empty
        Const BLOCK_PREFIX As String = "---"
        Dim boolNodeAffected As Boolean
        Dim bytCParamChar As Byte

        Do While True
            chunk = p.ParseNext()
            If chunk Is Nothing Then
                Exit Do
            End If

            boolNodeAffected = False
            Select Case chunk.oType
                Case Majestic12.HTMLchunkType.OpenTag
                    Select Case chunk.sTag
                        Case "img"
                            strNewFullTag = String.Empty
                            For intCounter As Integer = 0 To chunk.iParams - 1
                                If chunk.sParams(intCounter) = "src" Then
                                    If chunk.sValues(intCounter).IndexOf("://") >= 0 AndAlso chunk.sValues(intCounter).StartsWith(BLOCK_PREFIX) AndAlso Not chunk.sValues(intCounter).ToLower.IndexOf("file:///") >= 0 Then
                                        '-- remote image
                                        '   remove prefix to src to allow it loading
                                        chunk.sValues(intCounter) = chunk.sValues(intCounter).Substring(BLOCK_PREFIX.Length)
                                        strNewFullTag = chunk.GenerateHTML
                                        boolNodeAffected = True
                                    End If
                                    Exit For
                                End If
                            Next

                            If boolNodeAffected Then
                                '-- First get the unaffected part before the current chunk
                                sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                                '-- Next, append the current chunk with modifications
                                sbReturn.Append(strNewFullTag)

                                '-- Next, reposition for the next time around
                                intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength
                            End If
                    End Select
            End Select
        Loop

        '-- get trailing html after last tag was processed
        sbReturn.Append(html.Substring(intStartingPosition))

        If markMessage Then
            Dim xDoc As New Xml.XmlDocument()
            xDoc.Load(messageFilename)
            xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SHOWREMOTEIMAGES, True)
            xDoc.Save(messageFilename)
        End If

        Return sbReturn.ToString()
    End Function
    ''' <summary>
    ''' Removes IFrame HTML tags and notifies caller how many were removed
    ''' </summary>
    ''' <param name="html"></param>
    ''' <param name="iFramesRemoved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function RemoveIFrames(ByVal html As String, ByRef iFramesRemoved As Integer) As String
        Try
            Dim p As New Majestic12.HTMLparser(html)
            p.SetChunkHashMode(False)
            p.bAutoKeepScripts = False
            p.bAutoKeepComments = False

            Dim chunk As Majestic12.HTMLchunk
            Dim sbReturn As New System.Text.StringBuilder()
            Dim intStartingPosition As Integer = 0
            Dim strNewFullTag As String = String.Empty

            iFramesRemoved = 0
            Dim boolOpenTagWasiFrame As Boolean

            Do While True
                chunk = p.ParseNext()
                If chunk Is Nothing Then
                    Exit Do
                End If

                Select Case chunk.oType
                    Case Majestic12.HTMLchunkType.OpenTag
                        If chunk.sTag.ToLower() = "iframe" Then
                            '-- remove entire tag from html
                            strNewFullTag = String.Empty

                            '-- First get the unaffected part before the current chunk
                            sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                            '-- Next, append the current chunk with modifications
                            sbReturn.Append(strNewFullTag)

                            '-- Next, reposition for the next time around
                            intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                            iFramesRemoved += 1

                            boolOpenTagWasiFrame = True
                        Else
                            boolOpenTagWasiFrame = False
                        End If
                    Case Majestic12.HTMLchunkType.CloseTag
                        If boolOpenTagWasiFrame Then
                            strNewFullTag = String.Empty

                            '-- First get the unaffected part before the current chunk
                            sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                            '-- Next, append the current chunk with modifications
                            sbReturn.Append(strNewFullTag)

                            '-- Next, reposition for the next time around
                            intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                            boolOpenTagWasiFrame = False
                        End If
                End Select
            Loop

            '-- get trailing html after last tag was processed
            sbReturn.Append(html.Substring(intStartingPosition))

            Return sbReturn.ToString()
        Catch ex As Exception
            Log(ex)
        End Try
    End Function
    ''' <summary>
    ''' Removes scripts from HTML and notifies caller how many were removed
    ''' </summary>
    ''' <param name="html"></param>
    ''' <param name="scriptsRemoved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function RemoveScripts(ByVal html As String, ByRef scriptsRemoved As Integer) As String
        Try
            Dim p As New Majestic12.HTMLparser(html)
            p.SetChunkHashMode(False)
            p.bAutoKeepScripts = False
            p.bAutoKeepComments = False

            Dim chunk As Majestic12.HTMLchunk
            Dim sbReturn As New System.Text.StringBuilder()
            Dim intStartingPosition As Integer = 0
            Dim strNewFullTag As String = String.Empty

            Dim lstToRemove As New List(Of String)
            Dim boolChangesMade As Boolean

            scriptsRemoved = 0

            Do While True
                chunk = p.ParseNext()
                If chunk Is Nothing Then
                    Exit Do
                End If

                Select Case chunk.oType
                    Case Majestic12.HTMLchunkType.Script
                        '-- remove entire tag from html
                        strNewFullTag = String.Empty

                        '-- First get the unaffected part before the current chunk
                        sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                        '-- Next, append the current chunk with modifications
                        sbReturn.Append(strNewFullTag)

                        '-- Next, reposition for the next time around
                        intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                        scriptsRemoved += 1
                    Case Majestic12.HTMLchunkType.OpenTag
                        If chunk.sTag.ToLower() = "a" Then
                            For intCounter As Integer = 0 To chunk.iParams - 1
                                If chunk.sParams(intCounter).ToLower = "target" Then
                                    lstToRemove.Add(chunk.GenerateParamHTML(chunk.sParams(intCounter), chunk.sValues(intCounter), Chr(chunk.cParamChars(intCounter))))
                                    boolChangesMade = True
                                    Exit For
                                End If
                            Next
                        End If
                End Select
            Loop

            '-- get trailing html after last tag was processed
            sbReturn.Append(html.Substring(intStartingPosition))

            Dim strAlt As String
            For Each s As String In lstToRemove
                sbReturn = sbReturn.Replace(s, String.Empty)
                strAlt = s.Replace("=", "=""") & """"
                sbReturn = sbReturn.Replace(strAlt, String.Empty)

                strAlt = s.Replace("=", "='") & "'"
                sbReturn = sbReturn.Replace(strAlt, String.Empty)
            Next

            If boolChangesMade AndAlso scriptsRemoved = 0 Then
                scriptsRemoved = -1 '-- flag as changes were made without removing scripts
            End If

            Return sbReturn.ToString()
        Catch ex As Exception
            Log(ex)
        End Try
    End Function
    ''' <summary>
    ''' Removes applets from HTML and notifies caller how many were removed
    ''' </summary>
    ''' <param name="html"></param>
    ''' <param name="scriptsRemoved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function RemoveApplets(ByVal html As String, ByRef appletsRemoved As Integer) As String
        Try

            Dim p As New Majestic12.HTMLparser(html)
            p.SetChunkHashMode(False)
            p.bAutoKeepScripts = False
            p.bAutoKeepComments = False

            Dim chunk As Majestic12.HTMLchunk
            Dim sbReturn As New System.Text.StringBuilder()
            Dim intStartingPosition As Integer = 0
            Dim strNewFullTag As String = String.Empty

            appletsRemoved = 0
            Dim boolOpenTagWasApplet As Boolean

            Do While True
                chunk = p.ParseNext()
                If chunk Is Nothing Then
                    Exit Do
                End If

                Select Case chunk.oType
                    Case Majestic12.HTMLchunkType.OpenTag
                        If chunk.sTag.ToLower() = "applet" Then
                            '-- remove entire tag from html
                            strNewFullTag = String.Empty

                            '-- First get the unaffected part before the current chunk
                            sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                            '-- Next, append the current chunk with modifications
                            sbReturn.Append(strNewFullTag)

                            '-- Next, reposition for the next time around
                            intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                            appletsRemoved += 1

                            boolOpenTagWasApplet = True
                        Else
                            boolOpenTagWasApplet = False
                        End If
                    Case Majestic12.HTMLchunkType.CloseTag
                        If boolOpenTagWasApplet Then
                            strNewFullTag = String.Empty

                            '-- First get the unaffected part before the current chunk
                            sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                            '-- Next, append the current chunk with modifications
                            sbReturn.Append(strNewFullTag)

                            '-- Next, reposition for the next time around
                            intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                            boolOpenTagWasApplet = False
                        End If
                End Select
            Loop

            '-- get trailing html after last tag was processed
            sbReturn.Append(html.Substring(intStartingPosition))

            Return sbReturn.ToString()
        Catch ex As Exception
            Log(ex)
        End Try
    End Function
    ''' <summary>
    ''' Removes objects from HTML and notifies caller how many were removed
    ''' </summary>
    ''' <param name="html"></param>
    ''' <param name="scriptsRemoved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function RemoveObjects(ByVal html As String, ByRef objectsRemoved As Integer) As String
        Try

            Dim p As New Majestic12.HTMLparser(html)
            p.SetChunkHashMode(False)
            p.bAutoKeepScripts = False
            p.bAutoKeepComments = False

            Dim chunk As Majestic12.HTMLchunk
            Dim sbReturn As New System.Text.StringBuilder()
            Dim intStartingPosition As Integer = 0
            Dim strNewFullTag As String = String.Empty

            objectsRemoved = 0
            Dim boolOpenTagWasObject As Boolean

            Do While True
                chunk = p.ParseNext()
                If chunk Is Nothing Then
                    Exit Do
                End If

                Select Case chunk.oType
                    Case Majestic12.HTMLchunkType.OpenTag
                        If chunk.sTag.ToLower() = "object" Then
                            '-- remove entire tag from html
                            strNewFullTag = String.Empty

                            '-- First get the unaffected part before the current chunk
                            sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                            '-- Next, append the current chunk with modifications
                            sbReturn.Append(strNewFullTag)

                            '-- Next, reposition for the next time around
                            intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                            objectsRemoved += 1

                            boolOpenTagWasObject = True
                        End If
                    Case Majestic12.HTMLchunkType.CloseTag
                        If boolOpenTagWasObject AndAlso chunk.sTag.ToLower() = "object" Then
                            strNewFullTag = String.Empty

                            '-- First get the unaffected part before the current chunk
                            sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                            '-- Next, append the current chunk with modifications
                            sbReturn.Append(strNewFullTag)

                            '-- Next, reposition for the next time around
                            intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                            boolOpenTagWasObject = False
                        End If
                End Select
            Loop

            '-- get trailing html after last tag was processed
            sbReturn.Append(html.Substring(intStartingPosition))

            Return sbReturn.ToString()
        Catch ex As Exception
            Log(ex)
        End Try
    End Function
    ''' <summary>
    ''' Removes embedded (flash, etc.) from HTML and notifies caller how many were removed
    ''' </summary>
    ''' <param name="html"></param>
    ''' <param name="scriptsRemoved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function RemoveEmbeddedAnything(ByVal html As String, ByRef removed As Integer) As String
        Try

            Dim p As New Majestic12.HTMLparser(html)
            p.SetChunkHashMode(False)
            p.bAutoKeepScripts = False
            p.bAutoKeepComments = False

            Dim chunk As Majestic12.HTMLchunk
            Dim sbReturn As New System.Text.StringBuilder()
            Dim intStartingPosition As Integer = 0
            Dim strNewFullTag As String = String.Empty

            removed = 0
            Dim boolOpenTagWasEmbedded As Boolean

            Do While True
                chunk = p.ParseNext()
                If chunk Is Nothing Then
                    Exit Do
                End If

                Select Case chunk.oType
                    Case Majestic12.HTMLchunkType.OpenTag
                        If chunk.sTag.ToLower() = "embed" Then
                            '-- remove entire tag from html
                            strNewFullTag = String.Empty

                            '-- First get the unaffected part before the current chunk
                            sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                            '-- Next, append the current chunk with modifications
                            sbReturn.Append(strNewFullTag)

                            '-- Next, reposition for the next time around
                            intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                            removed += 1

                            boolOpenTagWasEmbedded = True
                        End If
                    Case Majestic12.HTMLchunkType.CloseTag
                        If boolOpenTagWasEmbedded AndAlso chunk.sTag.ToLower() = "embed" Then
                            strNewFullTag = String.Empty

                            '-- First get the unaffected part before the current chunk
                            sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                            '-- Next, append the current chunk with modifications
                            sbReturn.Append(strNewFullTag)

                            '-- Next, reposition for the next time around
                            intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                            boolOpenTagWasEmbedded = False
                        End If
                End Select
            Loop

            '-- get trailing html after last tag was processed
            sbReturn.Append(html.Substring(intStartingPosition))

            Return sbReturn.ToString()
        Catch ex As Exception
            Log(ex)
        End Try
    End Function
    ''' <summary>
    ''' Removes remote background images from HTML and notifies caller how many were removed
    ''' </summary>
    ''' <param name="html"></param>
    ''' <param name="scriptsRemoved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function RemoveImportedCSSStyles(ByVal html As String, ByRef removed As Integer) As String
        Try

            Dim p As New Majestic12.HTMLparser(html)
            p.SetChunkHashMode(False)
            p.bAutoKeepScripts = False
            p.bAutoKeepComments = False

            Dim chunk As Majestic12.HTMLchunk
            Dim sbReturn As New System.Text.StringBuilder()
            Dim intStartingPosition As Integer = 0
            Dim strNewFullTag As String = String.Empty

            removed = 0
            Dim boolOpenTagWasStyle As Boolean

            Do While True
                chunk = p.ParseNext()
                If chunk Is Nothing Then
                    Exit Do
                End If

                Select Case chunk.oType
                    Case Majestic12.HTMLchunkType.OpenTag
                        If chunk.sTag.ToLower() = "style" Then
                            '-- First get the unaffected part before the current chunk
                            sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                            '-- Next, append the current chunk with modifications
                            sbReturn.Append(chunk.GenerateHTML())

                            '-- Next, reposition for the next time around
                            intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                            boolOpenTagWasStyle = True
                        End If
                    Case Majestic12.HTMLchunkType.CloseTag
                        If boolOpenTagWasStyle AndAlso chunk.sTag.ToLower() = "style" Then
                            'strNewFullTag = String.Empty

                            '-- First get the unaffected part before the current chunk
                            sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                            '-- Next, append the current chunk with modifications
                            sbReturn.Append(chunk.GenerateHTML())

                            '-- Next, reposition for the next time around
                            intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                            boolOpenTagWasStyle = False
                        End If
                    Case Majestic12.HTMLchunkType.Text
                        If boolOpenTagWasStyle Then
                            If chunk.oHTML.ToLower.StartsWith("@import") Then
                                '-- strip off imports but least style tag there
                                intStartingPosition += chunk.oHTML.Length
                                removed += 1
                            End If
                        End If
                End Select
            Loop

            '-- get trailing html after last tag was processed
            sbReturn.Append(html.Substring(intStartingPosition))

            Return sbReturn.ToString()
        Catch ex As Exception
            Log(ex)
        End Try
    End Function
    ''' <summary>
    ''' Removes remote background images from HTML and notifies caller how many were removed
    ''' </summary>
    ''' <param name="html"></param>
    ''' <param name="scriptsRemoved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function RemoveRemoteBodyBackground(ByVal html As String, ByRef removed As Integer) As String
        Try

            Dim p As New Majestic12.HTMLparser(html)
            p.SetChunkHashMode(False)
            p.bAutoKeepScripts = False
            p.bAutoKeepComments = False

            Dim chunk As Majestic12.HTMLchunk
            Dim sbReturn As New System.Text.StringBuilder()
            Dim intStartingPosition As Integer = 0
            Dim strNewFullTag As String = String.Empty

            removed = 0

            Do While True
                chunk = p.ParseNext()
                If chunk Is Nothing Then
                    Exit Do
                End If

                Select Case chunk.oType
                    Case Majestic12.HTMLchunkType.OpenTag
                        If chunk.sTag.ToLower() = "body" Then
                            For intCounter As Integer = 0 To chunk.iParams - 1
                                If chunk.sParams(intCounter).ToLower() = "background" AndAlso (chunk.sValues(intCounter).ToLower().StartsWith("http://") OrElse chunk.sValues(intCounter).ToLower().StartsWith("https://")) Then
                                    '-- First get the unaffected part before the current chunk
                                    sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                                    '-- Next, append the current chunk with modifications
                                    Dim strNewHTML As String = chunk.GenerateHTML().Replace(chunk.GenerateParamsHTML, String.Empty)
                                    sbReturn.Append(strNewHTML)

                                    '-- Next, reposition for the next time around
                                    intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                                    removed += 1

                                    Exit For
                                End If
                            Next
                        End If

                End Select
            Loop

            '-- get trailing html after last tag was processed
            sbReturn.Append(html.Substring(intStartingPosition))

            Return sbReturn.ToString()
        Catch ex As Exception
            Log(ex)
        End Try
    End Function
    ''' <summary>
    ''' Removes remote sounds from HTML and notifies caller how many were removed
    ''' </summary>
    ''' <param name="html"></param>
    ''' <param name="scriptsRemoved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function RemoveRemoteSounds(ByVal html As String, ByRef removed As Integer) As String
        Try

            Dim p As New Majestic12.HTMLparser(html)
            p.SetChunkHashMode(False)
            p.bAutoKeepScripts = False
            p.bAutoKeepComments = False

            Dim chunk As Majestic12.HTMLchunk
            Dim sbReturn As New System.Text.StringBuilder()
            Dim intStartingPosition As Integer = 0
            Dim strNewFullTag As String = String.Empty

            removed = 0

            Do While True
                chunk = p.ParseNext()
                If chunk Is Nothing Then
                    Exit Do
                End If

                Select Case chunk.oType
                    Case Majestic12.HTMLchunkType.OpenTag, Majestic12.HTMLchunkType.CloseTag
                        If chunk.sTag.ToLower() = "bgsound" Then
                            '-- First get the unaffected part before the current chunk
                            sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                            '-- Next, append the current chunk with modifications
                            'sbReturn.Append(String.Empty)

                            '-- Next, reposition for the next time around
                            intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                            removed += 1
                        End If

                End Select
            Loop

            '-- get trailing html after last tag was processed
            sbReturn.Append(html.Substring(intStartingPosition))

            Return sbReturn.ToString()
        Catch ex As Exception
            Log(ex)
        End Try
    End Function

    ''' <summary>
    ''' Removes remote image input controls from HTML and notifies caller how many were removed
    ''' </summary>
    ''' <param name="html"></param>
    ''' <param name="scriptsRemoved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function RemoveRemoteImageInputs(ByVal html As String, ByRef removed As Integer) As String
        Try

            Dim p As New Majestic12.HTMLparser(html)
            p.SetChunkHashMode(False)
            p.bAutoKeepScripts = False
            p.bAutoKeepComments = False

            Dim chunk As Majestic12.HTMLchunk
            Dim sbReturn As New System.Text.StringBuilder()
            Dim intStartingPosition As Integer = 0
            Dim strNewFullTag As String = String.Empty

            removed = 0

            Do While True
                chunk = p.ParseNext()
                If chunk Is Nothing Then
                    Exit Do
                End If

                Select Case chunk.oType
                    Case Majestic12.HTMLchunkType.OpenTag, Majestic12.HTMLchunkType.CloseTag
                        If chunk.sTag.ToLower() = "input" Then
                            For intCounter As Integer = 0 To chunk.iParams - 1
                                If chunk.sParams(intCounter).ToLower() = "src" Then
                                    '-- First get the unaffected part before the current chunk
                                    sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                                    '-- Next, append the current chunk with modifications
                                    Dim strNewHTML As String = chunk.GenerateHTML().Replace(chunk.sValues(intCounter), String.Empty)
                                    sbReturn.Append(strNewHTML)

                                    '-- Next, reposition for the next time around
                                    intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                                    removed += 1

                                    Exit For
                                End If
                            Next
                        End If

                End Select
            Loop

            '-- get trailing html after last tag was processed
            sbReturn.Append(html.Substring(intStartingPosition))

            Return sbReturn.ToString()
        Catch ex As Exception
            Log(ex)
        End Try
    End Function

    ''' <summary>
    ''' Removes meta-refresh from HTML and notifies caller how many were removed
    ''' </summary>
    ''' <param name="html"></param>
    ''' <param name="scriptsRemoved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function RemoveMetaRefresh(ByVal html As String, ByRef removed As Integer) As String
        Try

            Dim p As New Majestic12.HTMLparser(html)
            p.SetChunkHashMode(False)
            p.bAutoKeepScripts = False
            p.bAutoKeepComments = False

            Dim chunk As Majestic12.HTMLchunk
            Dim sbReturn As New System.Text.StringBuilder()
            Dim intStartingPosition As Integer = 0
            Dim strNewFullTag As String = String.Empty

            removed = 0
            Dim boolOpenTagWasApplet As Boolean

            Do While True
                chunk = p.ParseNext()
                If chunk Is Nothing Then
                    Exit Do
                End If

                Select Case chunk.oType
                    Case Majestic12.HTMLchunkType.OpenTag
                        If chunk.sTag.ToLower() = "meta" Then
                            For intCounter As Integer = 0 To chunk.iParams - 1
                                If chunk.sParams(intCounter).ToLower() = "http-equiv" AndAlso chunk.sValues(intCounter).ToLower() = "refresh" Then
                                    '-- remove entire tag from html
                                    strNewFullTag = String.Empty

                                    '-- First get the unaffected part before the current chunk
                                    sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                                    '-- Next, append the current chunk with modifications
                                    'sbReturn.Append(strNewFullTag)

                                    '-- Next, reposition for the next time around
                                    intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                                    'sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                                    removed += 1
                                    Exit For
                                End If
                            Next
                        End If
                End Select
            Loop

            '-- get trailing html after last tag was processed
            sbReturn.Append(html.Substring(intStartingPosition))

            Return sbReturn.ToString()
        Catch ex As Exception
            Log(ex)
        End Try
    End Function
    ''' <summary>
    ''' Removes css and other linked content to web server from HTML and notifies caller how many were removed
    ''' </summary>
    ''' <param name="html"></param>
    ''' <param name="scriptsRemoved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function RemoveRemoteLinkedContent(ByVal html As String, ByRef removed As Integer) As String
        Try

            Dim p As New Majestic12.HTMLparser(html)
            p.SetChunkHashMode(False)
            p.bAutoKeepScripts = False
            p.bAutoKeepComments = False

            Dim chunk As Majestic12.HTMLchunk
            Dim sbReturn As New System.Text.StringBuilder()
            Dim intStartingPosition As Integer = 0
            Dim strNewFullTag As String = String.Empty

            removed = 0

            Do While True
                chunk = p.ParseNext()
                If chunk Is Nothing Then
                    Exit Do
                End If

                Select Case chunk.oType
                    Case Majestic12.HTMLchunkType.OpenTag
                        If chunk.sTag.ToLower() = "link" Then
                            For intCounter As Integer = 0 To chunk.iParams - 1
                                If chunk.sParams(intCounter).ToLower() = "href" Then
                                    '-- remove entire tag from html
                                    strNewFullTag = String.Empty

                                    '-- First get the unaffected part before the current chunk
                                    sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                                    '-- Next, reposition for the next time around
                                    intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                                    removed += 1
                                    Exit For
                                End If
                            Next
                        End If
                End Select
            Loop

            '-- get trailing html after last tag was processed
            sbReturn.Append(html.Substring(intStartingPosition))

            Return sbReturn.ToString()
        Catch ex As Exception
            Log(ex)
        End Try
    End Function
    ''' <summary>
    ''' Removes background images from paragraph tags which connect to web server from HTML and notifies caller how many were removed
    ''' </summary>
    ''' <param name="html"></param>
    ''' <param name="scriptsRemoved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function RemoveRemoteBackgroundImages(ByVal html As String, ByRef removed As Integer) As String
        Try

            Dim p As New Majestic12.HTMLparser(html)
            p.SetChunkHashMode(False)
            p.bAutoKeepScripts = False
            p.bAutoKeepComments = False

            Dim chunk As Majestic12.HTMLchunk
            Dim sbReturn As New System.Text.StringBuilder()
            Dim intStartingPosition As Integer = 0
            Dim strNewFullTag As String = String.Empty

            removed = 0

            Do While True
                chunk = p.ParseNext()
                If chunk Is Nothing Then
                    Exit Do
                End If

                Select Case chunk.oType
                    Case Majestic12.HTMLchunkType.OpenTag
                        If chunk.sTag.ToLower() = "p" Then
                            For intCounter As Integer = 0 To chunk.iParams - 1
                                If chunk.sParams(intCounter).ToLower() = "style" AndAlso (chunk.sValues(intCounter).ToLower().StartsWith("background-image:url") OrElse chunk.sValues(intCounter).ToLower().StartsWith("content:url") OrElse chunk.sValues(intCounter).ToLower().StartsWith("behavior:url")) Then
                                    '-- remove entire tag from html
                                    strNewFullTag = "<p>" '-- try cheap and easy way, just replace with plain p tag

                                    '-- First get the unaffected part before the current chunk
                                    sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                                    '-- Next, append the current chunk with modifications
                                    sbReturn.Append(strNewFullTag)

                                    '-- Next, reposition for the next time around
                                    intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                                    removed += 1
                                    Exit For
                                End If
                            Next
                        End If
                End Select
            Loop

            '-- get trailing html after last tag was processed
            sbReturn.Append(html.Substring(intStartingPosition))

            Return sbReturn.ToString()
        Catch ex As Exception
            Log(ex)
        End Try
    End Function
    ''' <summary>
    ''' Removes contenteditable attribute from body
    ''' </summary>
    ''' <param name="html"></param>
    ''' <param name="scriptsRemoved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function RemoveContentEditableAttribute(ByVal html As String) As String
        Try
            Using p As New Majestic12.HTMLparser(html)
                p.SetChunkHashMode(False)
                p.bAutoKeepScripts = False
                p.bAutoKeepComments = False

                Dim chunk As Majestic12.HTMLchunk
                Dim sbReturn As New System.Text.StringBuilder()
                Dim intStartingPosition As Integer = 0
                Dim strNewFullTag As String = String.Empty

                Dim intOriginalStart, intOriginalLength As Integer
                Dim strReturn As String

                Dim boolChangesMade As Boolean
                Const BADNESS As String = "contenteditable"

                Do While True
                    chunk = p.ParseNext()
                    If chunk Is Nothing Then
                        Exit Do
                    End If

                    Select Case chunk.oType
                        Case Majestic12.HTMLchunkType.OpenTag
                            If chunk.sTag.ToLower() = "body" Then
                                For intCounter As Integer = 0 To chunk.iParams - 1
                                    If chunk.sParams(intCounter).ToLower = BADNESS Then
                                        strNewFullTag = chunk.GenerateHTML().Replace(chunk.GenerateParamHTML(chunk.sParams(intCounter), chunk.sValues(intCounter), Chr(chunk.cParamChars(intCounter))), String.Empty)
                                        boolChangesMade = True
                                        Exit For
                                    End If
                                Next
                            End If
                    End Select
                    If boolChangesMade Then
                        intOriginalStart = chunk.iChunkOffset
                        intOriginalLength = chunk.iChunkLength
                        sbReturn.Append(html.Substring(0, intOriginalStart - 1))
                        sbReturn.Append(strNewFullTag)
                        sbReturn.Append(html.Substring(intOriginalStart + intOriginalLength))
                        Exit Do
                    End If
                Loop

                Return sbReturn.ToString()
            End Using

        Catch ex As Exception
            Log(ex)
        End Try
    End Function
    Friend Function AddTitleToAnchorTags(ByVal html As String, ByRef tagsAffected As Integer) As String
        Dim p As New Majestic12.HTMLparser(html)
        p.SetChunkHashMode(False)
        p.bAutoKeepScripts = False
        p.bAutoKeepComments = False

        Dim chunk As Majestic12.HTMLchunk
        Dim sbReturn As New System.Text.StringBuilder()
        Dim intStartingPosition As Integer = 0
        Dim strNewFullTag As String = String.Empty
        Dim boolNodeAffected As Boolean
        Dim bytCParamChar As Byte

        tagsAffected = 0

        Do While True
            chunk = p.ParseNext()
            If chunk Is Nothing Then
                Exit Do
            End If

            boolNodeAffected = False
            Select Case chunk.oType
                Case Majestic12.HTMLchunkType.OpenTag
                    Select Case chunk.sTag
                        Case "a"
                            '-- add tooltips to show href to user
                            Dim boolExistingTitleAttribute As Boolean
                            Dim strHREF As String = String.Empty
                            Dim intExistingTitlePosition As Integer

                            boolExistingTitleAttribute = False

                            For intCounter As Integer = 0 To chunk.iParams - 1
                                Select Case chunk.sParams(intCounter)
                                    Case "title"
                                        boolExistingTitleAttribute = True
                                        intExistingTitlePosition = intCounter
                                    Case "href"
                                        strHREF = chunk.sValues(intCounter)
                                        bytCParamChar = chunk.cParamChars(intCounter)
                                    Case Else
                                        '-- ignore
                                End Select
                            Next

                            Dim strValue As String = strHREF & "  (notice by TrulyMail)"
                            tagsAffected += 1
                            If boolExistingTitleAttribute Then
                                '-- replace the title tag
                                chunk.sValues(intExistingTitlePosition) = strValue
                            Else
                                '-- no title tag, just add one
                                chunk.AddParam("title", strValue, bytCParamChar)
                            End If

                            '-- First get the unaffected part before the current chunk
                            sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

                            '-- Next, append the current chunk with modifications
                            sbReturn.Append(chunk.GenerateHTML)

                            '-- Next, reposition for the next time around
                            intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

                            chunk.Clear()
                    End Select

            End Select
        Loop

        '-- get trailing html after last tag was processed
        If html.Length > intStartingPosition Then
            sbReturn.Append(html.Substring(intStartingPosition))
        End If

        Return sbReturn.ToString()
    End Function
    Private Function GetBodyFromPOPMessage(ByVal msg As aspNetMime.MimeMessage) As EmailBody
        Dim strBody As String = String.Empty
        Dim ret As EmailBody

        Try
            If msg.HtmlMimePart IsNot Nothing Then
                strBody = msg.HtmlMimePart.DecodedText
                ret.Format = EmailBodyFormatEnum.HTML
            Else
                '-- Plain text
                strBody = msg.MainBodyPart.DecodedText
                ret.Format = EmailBodyFormatEnum.PlainText
            End If
        Catch ex As Exception
            Log(ex)
            ret.Format = EmailBodyFormatEnum.PlainText
        End Try

        ret.Body = strBody
        Return ret
    End Function

#Region " Original, block remote images, strip scripts, and add title to <a> tags "
    'Private Function BlockImages(ByVal html As String, ByRef imagesBlocked As Integer, ByRef scriptsRemoved As Integer) As String
    '    Dim p As New Majestic12.HTMLparser(html)
    '    p.SetChunkHashMode(False)
    '    p.bAutoKeepScripts = False
    '    p.bAutoKeepComments = False

    '    Dim dtStart As Date = Date.Now
    '    Dim chunk As Majestic12.HTMLchunk
    '    Dim sbReturn As New System.Text.StringBuilder()
    '    Dim intStartingPosition As Integer = 0
    '    Dim strNewFullTag As String = String.Empty
    '    Const BLOCK_PREFIX As String = "---"
    '    Dim boolNodeAffected As Boolean
    '    Dim bytCParamChar As Byte

    '    imagesBlocked = 0
    '    scriptsRemoved = 0

    '    Do While True
    '        chunk = p.ParseNext()
    '        If chunk Is Nothing Then
    '            Exit Do
    '        End If

    '        boolNodeAffected = False
    '        Select Case chunk.oType
    '            Case Majestic12.HTMLchunkType.OpenTag
    '                Select Case chunk.sTag
    '                    Case Is = "img"
    '                        strNewFullTag = String.Empty
    '                        For intCounter As Integer = 0 To chunk.iParams - 1
    '                            If chunk.sParams(intCounter) = "src" Then
    '                                If chunk.sValues(intCounter).IndexOf("://") >= 0 Then
    '                                    '-- remote image
    '                                    '   add prefix to src to prevent it from loading
    '                                    chunk.sValues(intCounter) = BLOCK_PREFIX & chunk.sValues(intCounter)
    '                                    strNewFullTag = chunk.GenerateHTML
    '                                    'strNewFullTag = chunk.GenerateHTML().Replace(chunk.sValues(intCounter), BLOCK_PREFIX & chunk.sValues(intCounter))
    '                                    imagesBlocked += 1
    '                                    boolNodeAffected = True
    '                                Else
    '                                    '-- Just use this tag as-is
    '                                    'strNewFullTag = chunk.GenerateHTML()
    '                                End If
    '                                Exit For
    '                            End If
    '                        Next

    '                        If boolNodeAffected Then
    '                            '-- First get the unaffected part before the current chunk
    '                            sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

    '                            '-- Next, append the current chunk with modifications
    '                            sbReturn.Append(strNewFullTag)

    '                            '-- Next, reposition for the next time around
    '                            intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength
    '                        End If
    '                    Case "a"
    '                        '-- add tooltips to show href to user
    '                        Dim boolExistingTitleAttribute As Boolean
    '                        Dim strHREF As String = String.Empty
    '                        Dim intExistingTitlePosition As Integer

    '                        boolExistingTitleAttribute = False

    '                        For intCounter As Integer = 0 To chunk.iParams - 1
    '                            Select Case chunk.sParams(intCounter)
    '                                Case "title"
    '                                    boolExistingTitleAttribute = True
    '                                    intExistingTitlePosition = intCounter
    '                                Case "href"
    '                                    strHREF = chunk.sValues(intCounter)
    '                                    bytCParamChar = chunk.cParamChars(intCounter)
    '                                Case Else
    '                                    '-- ignore
    '                            End Select
    '                        Next

    '                        Dim strValue As String = strHREF & "  (notice by TrulyMail)"
    '                        If boolExistingTitleAttribute Then
    '                            '-- replace the title tag
    '                            chunk.sValues(intExistingTitlePosition) = strValue
    '                        Else
    '                            '-- no title tag, just add one
    '                            chunk.AddParam("title", strValue, bytCParamChar)
    '                        End If

    '                        '-- First get the unaffected part before the current chunk
    '                        sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

    '                        '-- Next, append the current chunk with modifications
    '                        sbReturn.Append(chunk.GenerateHTML)

    '                        '-- Next, reposition for the next time around
    '                        intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

    '                        chunk.Clear()
    '                End Select

    '            Case Majestic12.HTMLchunkType.Script
    '                '-- remove entire tag from html
    '                strNewFullTag = String.Empty

    '                '-- First get the unaffected part before the current chunk
    '                sbReturn.Append(html.Substring(intStartingPosition, chunk.iChunkOffset - intStartingPosition))

    '                '-- Next, append the current chunk with modifications
    '                sbReturn.Append(strNewFullTag)

    '                '-- Next, reposition for the next time around
    '                intStartingPosition = chunk.iChunkOffset + chunk.iChunkLength

    '                scriptsRemoved += 1
    '        End Select
    '    Loop

    '    '-- get trailing html after last tag was processed
    '    sbReturn.Append(html.Substring(intStartingPosition))

    '    Dim dtStop As Date = Date.Now
    '    Dim ts As TimeSpan = dtStop - dtStart
    '    Me.Text = ts.TotalMilliseconds.ToString("#,##0")

    '    Return sbReturn.ToString()
    'End Function
#End Region
#End Region

#Region " Old HTML Manipulation code, using mshtml as parser "
    '''' <summary>
    '''' Returns the passed in html with remote images' elements' src tag prefixed to prevent loading
    '''' </summary>
    '''' <param name="html"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Friend Function BlockRemoteImages(ByVal html As String, ByRef imagesBlocked As Integer) As String
    '    Try
    '        Dim browser As New System.Windows.Forms.WebBrowser()
    '        browser.DocumentText = html
    '        Do Until browser.ReadyState = WebBrowserReadyState.Complete OrElse browser.ReadyState = WebBrowserReadyState.Interactive
    '            Application.DoEvents()
    '        Loop
    '        Dim colImages As HtmlElementCollection
    '        colImages = browser.Document.Images ' GetElementsByTagName("img")
    '        '-- block the remote image
    '        imagesBlocked = 0
    '        For Each element As HtmlElement In colImages
    '            If element.GetAttribute("src").IndexOf("://") >= 0 Then
    '                element.SetAttribute("src", BLOCKED_IMAGE_SCR_PREFIX & element.GetAttribute("src"))
    '                imagesBlocked += 1
    '            End If
    '        Next
    '        If imagesBlocked > 0 Then
    '            Return browser.Document.Body.OuterHtml
    '        Else
    '            '-- nothing blocked
    '            Return html
    '        End If
    '    Catch ex As Exception
    '        '-- If there is an error, log it
    '        Log(ex)
    '        ShowMessageBox("There was an error reading the message to block remote images. Please contact TrulyMail Support.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '        Return html
    '    End Try
    'End Function
    '''' <summary>
    '''' Returns the passed in html with remote images' elements' src tag's prefixed to prevent loading removed
    '''' </summary>
    '''' <param name="html"></param>
    '''' <param name="markMessage"></param>
    '''' <param name="messageFilename"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Friend Function UnBlockRemoteImages(ByVal html As String, ByVal markMessage As Boolean, ByVal messageFilename As String) As String
    '    Dim browser As New System.Windows.Forms.WebBrowser()
    '    browser.DocumentText = html
    '    Do Until browser.ReadyState = WebBrowserReadyState.Complete OrElse browser.ReadyState = WebBrowserReadyState.Interactive
    '        Application.DoEvents() '-- needed to force loading by the browser
    '    Loop
    '    Dim colImages As HtmlElementCollection
    '    colImages = browser.Document.GetElementsByTagName("img")
    '    '-- unblock the remote image
    '    For Each element As HtmlElement In colImages
    '        If element.GetAttribute("src").StartsWith(BLOCKED_IMAGE_SCR_PREFIX) Then
    '            element.SetAttribute("src", element.GetAttribute("src").Substring(BLOCKED_IMAGE_SCR_PREFIX.Length))
    '        End If
    '    Next

    '    If markMessage Then
    '        Dim xDoc As New Xml.XmlDocument()
    '        xDoc.Load(messageFilename)
    '        xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SHOWREMOTEIMAGES, True)
    '        xDoc.Save(messageFilename)
    '    End If

    '    Return browser.Document.Body.OuterHtml
    'End Function
    '''' <summary>
    '''' Returns html after removing all script tags from the passed in html
    '''' </summary>
    '''' <param name="html"></param>
    '''' <param name="nodesRemoved"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Friend Function RemoveScriptNodes(ByVal html As String, ByRef nodesRemoved As Integer) As String
    '    '        System.IO.File.WriteAllText("c:\output.txt", html)
    '    Dim scriptNodes As HtmlElementCollection
    '    Dim scriptTag As HtmlElement
    '    Dim browser As New WebBrowser()
    '    browser.ScriptErrorsSuppressed = True
    '    browser.DocumentText = html
    '    Do Until browser.ReadyState = WebBrowserReadyState.Complete OrElse browser.ReadyState = WebBrowserReadyState.Interactive
    '        Application.DoEvents() '-- needed to force loading by the browser
    '    Loop

    '    nodesRemoved = 0
    '    scriptNodes = browser.Document.GetElementsByTagName("script")
    '    For Each scriptTag In scriptNodes
    '        '-- remove the script completely
    '        scriptNodes.Item(0).OuterHtml = String.Empty
    '        nodesRemoved += 1
    '    Next

    '    Return browser.Document.Body.OuterHtml

    'End Function
#End Region

    Private m_strPreviousIEFooterSetting As String = String.Empty
    Private m_boolRestoreIEFooterSetting As Boolean

    Friend Sub ClearIEFooter()
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
    Friend Sub RestoreIEFooter()
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
    End Sub
    ''' <summary>
    ''' Changes illegal characters (e.g., ":" or "?") into spaces
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function MakeFilenameLegal(ByVal filename As String) As String
        Dim strBadChars() As String = {"\", "/", ":", "*", "?", """", "<", ">", "|", vbCr, vbLf}
        Dim sb As New System.Text.StringBuilder(filename)
        For Each character As String In strBadChars
            sb.Replace(character, " ")
        Next
        Return sb.ToString()
    End Function
    ''' <summary>
    ''' Converts a .eml file to a .tmm file and returns the path to that new file
    ''' </summary>
    ''' <param name="emailFilename"></param>
    ''' <returns>Path to .tmm file</returns>
    ''' <remarks></remarks>
    Friend Function ConvertEmailToTrulyMail(ByVal emailFilename As String, Optional ByVal popID As String = "", Optional ByVal folderForMessage As String = "") As String
        Dim strLicense As String
        strLicense = My.Resources.aspnetmime_xml_lic
        aspNetMime.MimeMessage.LoadLicenseString(strLicense)

        Dim msg As aspNetMime.MimeMessage
        msg = aspNetMime.MimeMessage.ParseFile(emailFilename)
        Return ConvertEmailToTrulyMail(msg, popID, folderForMessage)
    End Function
    ''' <summary>
    '''  Convert a mime mail message to a .tmm file and returns the path to that new file
    ''' </summary>
    ''' <param name="email">mime message to convert</param>
    ''' <param name="popID">ID of pop account used to get this message</param>
    ''' <param name="folderForMessage">Folder in which to store the .tmm file, leave blank for temp file</param>
    ''' <param name="overrideSubject"></param>
    ''' <param name="overrideBody"></param>
    ''' <param name="tm2TMDecryptionKey"></param>
    ''' <param name="tm2tmEncrypted"></param>
    ''' <param name="importing"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function ConvertEmailToTrulyMail(ByVal email As aspNetMime.MimeMessage, Optional ByVal popProfile As POPProfile = Nothing, Optional ByVal folderForMessage As String = "", _
                                            Optional overrideSubject As String = "", Optional overrideBody As String = "", Optional tm2TMDecryptionKey As String = "", _
                                            Optional tm2tmEncrypted As Boolean = False, Optional importing As Boolean = False, Optional removeDiacritics As Boolean = False) As String
        Try
            Dim strLicense As String
            strLicense = My.Resources.aspnetmime_xml_lic
            aspNetMime.MimeMessage.LoadLicenseString(strLicense)

            '-- we parse it out because it could be a .eml file attached to another email, which is not a message but a mimepart
            Dim msg As aspNetMime.MimeMessage = email


            Dim tmm As New TrulyMailMessage()

            'Dim strAttachmentFolder As String = QualifyPath(AttachmentsRootPath & strMessageID)
            'Dim strImagesFolder As String = strAttachmentFolder & IMAGES_EMBEDDED_FOLDER


            tmm.POPProfile = popProfile
            If popProfile Is Nothing Then
                tmm.Filename = System.IO.Path.Combine(InBoxRootPath, tmm.MessageID & MESSAGE_FILENAME_EXTENSION)
            Else
                tmm.Filename = System.IO.Path.Combine(MessageStoreRootPath, popProfile.InBoxPath, tmm.MessageID & MESSAGE_FILENAME_EXTENSION)
            End If

            tmm.MessageType = MessageType.Communication
            tmm.Encrypted = tm2tmEncrypted
            tmm.MessageDateReceived = Date.UtcNow


            If msg.From IsNot Nothing Then
                '-- We must check. If the From address is one of our email addresses, then we sent it (these two should NOT be blank)
                '   Otherwise, we received it (these two should be blank)
                '   but this is only true when importing, not when receiving
                Dim strSMTPID As String = String.Empty

                If importing Then
                    For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
                        If smtp.DisplayEmail.ToLower = msg.From.EmailAddress.Trim.ToLower Then
                            '-- we sent this
                            strSMTPID = smtp.ID
                            Exit For
                        End If

                        If smtp.Username.ToLower = msg.From.EmailAddress.Trim.ToLower Then
                            '-- we sent this
                            strSMTPID = smtp.ID
                            Exit For
                        End If
                    Next
                End If

                If strSMTPID.Length = 0 Then
                    '-- Not sent by us, it was received
                    Dim entry As New RecipientEntry(AddressBookEntryType.Email)
                    If removeDiacritics Then
                        entry.FullName = RemoveAccents(msg.From.Name.Trim)
                    Else
                        entry.FullName = msg.From.Name.Trim
                    End If
                    entry.Address = msg.From.EmailAddress.Trim
                    tmm.Sender = entry
                Else
                    '-- It was sent by us
                    tmm.SMTPProfile = SMTPProfile.GetByID(strSMTPID)
                End If
            Else
                Application.DoEvents() '-- for breakpoint only (should never get here)
            End If


            'Dim strMimeFilename As String = "c:\mimeMessage_" & intCounter & ".eml"
            'If System.IO.File.Exists(strMimeFilename) Then
            '    System.IO.File.Delete(strMimeFilename)
            'End If
            'msg.SaveToFile(strMimeFilename)


            Dim h As aspNetMime.Header

            If msg.To IsNot Nothing Then
                For Each emailAddress As aspNetMime.Address In msg.To
                    If IsValidEmailAddress(emailAddress.EmailAddress) Then
                        '-- This test is because some servers, like gmail, when there are only BCC recip
                        '   will include a TO address of "Undisclosed-Recipient:;" and that is not a valid address so I remove it
                        '   add add the user as a BCC recip below when it sees there are no recipients
                        If removeDiacritics Then
                            tmm.AddRecipient(RemoveAccents(emailAddress.Name.Trim), emailAddress.EmailAddress, RecipientType.Send_To)
                        Else
                            tmm.AddRecipient(emailAddress.Name.Trim, emailAddress.EmailAddress, RecipientType.Send_To)
                        End If
                    End If
                Next
            End If

            If msg.CC IsNot Nothing Then
                For Each emailAddress As aspNetMime.Address In msg.CC
                    If removeDiacritics Then
                        tmm.AddRecipient(RemoveAccents(emailAddress.Name.Trim), emailAddress.EmailAddress, RecipientType.Send_CC)
                    Else
                        tmm.AddRecipient(emailAddress.Name.Trim, emailAddress.EmailAddress, RecipientType.Send_CC)
                    End If
                Next
            End If

            Dim dtSentDate As Date = Date.UtcNow '-- default value
            For Each h In msg.Headers()
                '-- write out all headers so user can see them should they so choose
                Select Case h.Name.ToLower()
                    Case "date"
                        If IsDate(h.Value) Then
                            Try
                                dtSentDate = Convert.ToDateTime(h.Value).ToUniversalTime
                            Catch ex As Exception
                                Log(ex)
                                Log("Could not convert " & h.Value & " to UTC")
                            End Try
                        Else
                            Dim strBestGuess As String = String.Empty
                            If h.Value.Contains("(") AndAlso h.Value.Contains(")") Then
                                '-- Strip off time zone trailer, like '(PST)'
                                strBestGuess = h.Value.Substring(0, h.Value.IndexOf("(") - 1)
                            End If
                            If IsDate(strBestGuess) Then
                                Try
                                    dtSentDate = Convert.ToDateTime(strBestGuess).ToUniversalTime
                                Catch ex As Exception
                                    Log(ex)
                                    Log("Could not convert BG " & h.Value & " to UTC")
                                End Try
                            End If
                        End If
                    Case "reply-to"
                        Dim addr As System.Net.Mail.MailAddress
                        Try
                            addr = New System.Net.Mail.MailAddress(h.Value) '-- some times reply-to is "<user@domain.com>" so this gets just the address

                            If IsValidEmailAddress(addr.Address) Then
                                tmm.ReplyTo = h.Value
                            Else
                                Log("Invalid Reply-To address: " & addr.Address)
                            End If
                        Catch ex As Exception
                            Log(ex)
                            Log("Invalid Reply-To header: " & h.Value)
                        End Try
                End Select

                '-- Write all headers, even special ones so user can view them
                tmm.AddEmailHeader(h.Name, h.Value)
            Next

            '-- If there were no recipients, assume the user was BBC'd (and everyone else was too)
            If tmm.Recipients.Count = 0 Then
                Dim strName, strAddress As String
                Dim smtp As SMTPProfile = GetSMTPProfileByID(popProfile.SMTPProfileID)
                If smtp Is Nothing Then
                    '-- Nothing we can do here
                Else
                    '-- add user as BCC'd recip
                    tmm.AddRecipient(smtp.DisplayName, smtp.DisplayEmail, RecipientType.Send_BCC)
                End If
            End If

            tmm.MessageDateSent = dtSentDate

            Dim strBody As String
            Dim strSubject As String


            If overrideSubject.Length > 0 Then
                tmm.Subject = overrideSubject
            Else
                If msg.Subject Is Nothing Then
                    '-- this can happen, but it is rare
                    tmm.Subject = String.Empty
                Else
                    If removeDiacritics Then
                        tmm.Subject = RemoveAccents(msg.Subject.Value.Trim)
                    Else
                        tmm.Subject = msg.Subject.Value.Trim
                    End If
                End If
            End If

            Dim body As EmailBody = GetBodyFromPOPMessage(msg) '-- needs to be here because need to get the format later (html/text)
            If overrideBody.Length > 0 Then
                strBody = overrideBody
            Else
                If removeDiacritics Then
                    strBody = RemoveAccents(body.Body)
                Else
                    strBody = body.Body
                End If
            End If

            Dim strOriginalBody As String = strBody

            Dim lngFileSize As Long
            Dim strAttachmentFilename As String
            Dim attachType As EmailAttachmentType

            '-- Note, an attachment can be any of these:
            '   Attachment
            '   InlinePart
            '   EmbeddedPart

            '-- First get attachments and inline parts
            Dim attachments As aspNetMime.MimePartCollection = msg.AttachmentInLineParts
            Dim attachment As aspNetMime.MimePart
            Dim lstMimeParts As New List(Of aspNetMime.MimePart)
            Dim htAttachments As New Hashtable

            For Each attachment In attachments
                lstMimeParts.Add(attachment)
            Next

            '-- Now get embedded items
            attachments = msg.EmbeddedParts
            For Each attachment In attachments
                lstMimeParts.Add(attachment)
            Next

            '-- Now that we have one collection of all attachments, now we can deal with them in a uniform way
            If lstMimeParts.Count > 0 Then
                'if there are attachments, then write out their names
                For Each attachment In lstMimeParts
                    attachType = EmailAttachmentType.Ignore '-- reset variable

                    If attachment.IsAttachment Then
                        '-- write out to attachments folder
                        attachType = EmailAttachmentType.Attachment
                    ElseIf attachment.IsEmbedded OrElse attachment.IsInline Then
                        If attachment.IsImage Then
                            '--must test original body because we change strBody
                            If attachment.EmbeddedName IsNot Nothing AndAlso strOriginalBody.Contains(EMAIL_CONTENTID_CODE & attachment.EmbeddedName) Then
                                '-- write out to images folder
                                attachType = EmailAttachmentType.Embedded
                            Else
                                '-- no reference in the body to show this image, so count as attachment
                                attachType = EmailAttachmentType.Attachment
                            End If
                        Else
                            '-- change so that it is attachment (could be a document embedded in the message)
                            attachType = EmailAttachmentType.Attachment
                        End If
                    End If

                    Select Case attachType
                        Case EmailAttachmentType.Attachment
                            If attachment.Filename Is Nothing Then
                                If attachment.Name Is Nothing Then
                                    '-- random filename
                                    strAttachmentFilename = GenerateAlphanumericString(8).ToUpper

                                    '-- some eml attachments come through without anything but the content type
                                    'If attachment.IsMessage Then
                                    '    strAttachmentFilename &= ".eml"
                                    'Else
                                    Select Case attachment.ContentTypeString.ToLower
                                        Case "text/plain"
                                            strAttachmentFilename &= ".txt"
                                        Case "text/html"
                                            strAttachmentFilename &= ".html"
                                        Case "message/disposition-notification"
                                            strAttachmentFilename &= ".txt"
                                        Case "message/delivery-status"
                                            strAttachmentFilename &= ".txt"
                                        Case "message/rfc822"
                                            strAttachmentFilename &= ".eml"
                                        Case Else
                                            Log("ContentType not found: " & attachment.ContentTypeString)
                                    End Select
                                    'End If
                                Else
                                    strAttachmentFilename = attachment.Name
                                End If
                            Else
                                strAttachmentFilename = attachment.Filename
                            End If

                            strAttachmentFilename = MakeFilenameLegal(strAttachmentFilename)

                            '-- We will save to the temp folder then let the TMM object move it into place
                            '   and encrypt it if need be
                            strAttachmentFilename = System.IO.Path.Combine(GetTempPath(), strAttachmentFilename)
                            attachment.SaveAs(strAttachmentFilename)
                            Dim attachItem As AttachmentItem = tmm.AddAttachment(strAttachmentFilename)


                            If tm2TMDecryptionKey.Length > 0 Then
                                '-- this attachment must be a zip containing all the attached and embedded files
                                '   so need to handle this in a special way
                                '   Note: There can be only one (definition of TM2TM message)
                                Try
                                    ProcessTM2TMAttachment(tmm, attachItem, tm2TMDecryptionKey)

                                    '-- need to change the MessageID reference to match the incoming ID (not the sent ID)
                                    strBody = strBody.Replace(ATTACHMENTS_FOLDER_REPLACEMENT_CODE & MESSAGEID_REPLACEMENT_CODE, ATTACHMENTS_FOLDER_REPLACEMENT_CODE & tmm.MessageID)
                                Catch ex As Exception
                                    Log(ex)
                                    '-- most likely the encryption key is wrong

                                    '-- We don't want to keep prompting user for a key which they might not have
                                    '   blocking all other email downloads, so just attach encrypted zip and 
                                    '   then we will decrypt it when trying to read it
                                    '-- We've already attached the file to the message so nothing to do here
                                End Try
                            Else
                                If tm2tmEncrypted Then
                                    '-- flag as encrypted so reader knows
                                    'xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDEMAILTYPE, EncryptedEmailType.EncrypedTM2TMEmail.ToString)
                                End If
                                'tmm.AddAttachment(strAttachmentFilename)-- already attached above

                                'xAttachment = xAttachments.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ATTACHMENT))
                                'xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME, strAttachmentFilename)
                                'Try
                                '    lngFileSize = FileLen(strAttachmentFolder & strAttachmentFilename)
                                'Catch ex As Exception
                                '    '-- File not there for some reason, just ignore
                                '    Log(ex)
                                '    lngFileSize = 0
                                'End Try

                                ''-- Add attachment reference
                                'xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILESIZE, lngFileSize.ToString())
                            End If

                        Case EmailAttachmentType.Embedded
                            If attachment.Filename Is Nothing Then
                                Dim strFileExtension As String
                                Select Case attachment.ContentSubType.Substring(attachment.ContentSubType.Length - 3).ToLower
                                    Case "gif"
                                        strFileExtension = ".gif"
                                    Case "jpg"
                                        strFileExtension = ".jpg"
                                    Case "bmp"
                                        strFileExtension = ".bmp"
                                    Case "tif"
                                        strFileExtension = ".tif"
                                    Case "png"
                                        strFileExtension = ".png"
                                    Case "peg" '-- actually /jpeg
                                        strFileExtension = ".jpg"
                                    Case Else
                                        strFileExtension = ".jpg" '-- need to default to something
                                End Select
                                strAttachmentFilename = Guid.NewGuid.ToString & strFileExtension
                            Else
                                strAttachmentFilename = attachment.Filename
                            End If

                            strAttachmentFilename = MakeFilenameLegal(strAttachmentFilename)

                            '-- We will save to the temp folder then let the TMM object move it into place
                            '   and encrypt it if need be
                            strAttachmentFilename = System.IO.Path.Combine(GetTempPath(), strAttachmentFilename)
                            attachment.SaveAs(strAttachmentFilename)
                            Dim attachItem As AttachmentItem = tmm.AddEmbeddedImage(strAttachmentFilename)


                            '-- Now, replace the embedded name with the file just saved
                            If attachItem IsNot Nothing Then '-- Adding this to deal with dup names in attachments (image003.jpg and image003.jpg causes problems)
                                strBody = strBody.Replace(EMAIL_CONTENTID_CODE & attachment.EmbeddedName, ATTACHMENTS_FOLDER_REPLACEMENT_CODE & tmm.MessageID & "\" & IMAGES_EMBEDDED_FOLDER & attachItem.DisplayName)
                            End If
                    End Select
                Next
            End If

            tmm.Body = strBody

            Select Case body.Format
                Case EmailBodyFormatEnum.PlainText
                    tmm.BodyFormat = EmailBodyFormatEnum.PlainText
                Case EmailBodyFormatEnum.HTML
                    tmm.BodyFormat = EmailBodyFormatEnum.HTML
            End Select

            tmm.Save()

            Return tmm.Filename

        Catch ex As Exception
            Log(ex)
            If email IsNot Nothing Then
                For Each header As aspNetMime.Header In email.Headers
                    Log("Header: " & header.ToString())
                Next
                Log("Raw Text: " & email.RawText) '-- does not include headers
            End If
            Throw ex '-- for breakpoint only
        End Try
    End Function

    ''' <summary>
    '''  Convert a mime mail message to a .tmm file and returns the path to that new file
    ''' </summary>
    ''' <param name="email">mime message to convert</param>
    ''' <param name="popID">ID of pop account used to get this message</param>
    ''' <param name="folderForMessage">Folder in which to store the .tmm file, leave blank for temp file</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function ConvertEmailToTrulyMail(ByVal email As aspNetMime.MimeMessage, Optional ByVal popID As String = "", Optional ByVal folderForMessage As String = "", _
                                            Optional overrideSubject As String = "", Optional overrideBody As String = "", Optional tm2TMDecryptionKey As String = "", _
                                            Optional tm2tmEncrypted As Boolean = False, Optional importing As Boolean = False) As String
        Try
            Dim strLicense As String
            strLicense = My.Resources.aspnetmime_xml_lic
            aspNetMime.MimeMessage.LoadLicenseString(strLicense)

            '-- we parse it out because it could be a .eml file attached to another email, which is not a message but a mimepart
            Dim msg As aspNetMime.MimeMessage = email


            Dim strMessageID As String = Guid.NewGuid.ToString()
            Dim strMessageFilename As String
            If folderForMessage.Length > 0 Then
                If Not System.IO.Directory.Exists(folderForMessage) Then
                    System.IO.Directory.CreateDirectory(folderForMessage)
                End If
                strMessageFilename = QualifyPath(folderForMessage) & strMessageID & MESSAGE_FILENAME_EXTENSION
            Else
                strMessageFilename = QualifyPath(MessageStoreTempPath) & strMessageID & MESSAGE_FILENAME_EXTENSION
            End If

            Dim strAttachmentFolder As String = QualifyPath(AttachmentsRootPath & strMessageID)
            Dim strImagesFolder As String = strAttachmentFolder & IMAGES_EMBEDDED_FOLDER

            Dim xDoc As New Xml.XmlDocument()
            Dim xRoot As Xml.XmlElement = xDoc.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_MESSAGE))
            Dim strReceived As String = Date.UtcNow.ToString(DATEFORMAT_XML)
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_RECEIVED, strReceived)
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGETYPEID, MESSAGETYPE_COMMUNICATION)
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGEID, strMessageID) '-- Decrypted
            If popID.Length > 0 Then
                xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_POPACCOUNT, popID)
            End If
            If tm2tmEncrypted Then
                xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTED, True) '-- TM2TM email is encrypted
            Else
                xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTED, False) '-- normal email is not encrypted
            End If
            If msg.From IsNot Nothing Then
                '-- We must check. If the From address is one of our email addresses, then we sent it (these two should NOT be blank)
                '   Otherwise, we received it (these two should be blank)
                '   but this is only true when importing, not when receiving
                Dim strSMTPID As String = String.Empty

                If importing Then
                    For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
                        If smtp.DisplayEmail.ToLower = msg.From.EmailAddress.Trim.ToLower Then
                            '-- we sent this
                            strSMTPID = smtp.ID
                            Exit For
                        End If

                        If smtp.Username.ToLower = msg.From.EmailAddress.Trim.ToLower Then
                            '-- we sent this
                            strSMTPID = smtp.ID
                            Exit For
                        End If
                    Next
                End If

                If strSMTPID.Length = 0 Then
                    '-- Not sent by us, it was received
                    xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDERADDRESS, msg.From.EmailAddress.Trim)
                    xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDERFULLNAME, msg.From.Name.Trim)
                Else
                    '-- It was sent by us
                    xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SMTPACCOUNT, strSMTPID)
                End If
            Else
                Application.DoEvents() '-- for breakpoint only (should never get here)
            End If

            Dim xRecipients As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_RECIPIENTS))
            Dim xSubject As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_SUBJECT))
            Dim xBody As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_BODY))
            Dim xHeaders As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_HEADERS))
            Dim xAttachments As Xml.XmlElement = xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ATTACHMENTS) '-- only appent to xroot once we actually have attachment
            Dim xAttachment As Xml.XmlElement
            Dim xAddresses As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ADDRESSES))
            Dim xAddress As Xml.XmlElement


            'Dim strMimeFilename As String = "c:\mimeMessage_" & intCounter & ".eml"
            'If System.IO.File.Exists(strMimeFilename) Then
            '    System.IO.File.Delete(strMimeFilename)
            'End If
            'msg.SaveToFile(strMimeFilename)


            Dim h As aspNetMime.Header

            If msg.To IsNot Nothing Then
                For Each emailAddress As aspNetMime.Address In msg.To
                    xAddress = xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ADDRESS)
                    xAddress.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID, ROLEID_TO)
                    xAddress.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME, emailAddress.Name.Trim)
                    xAddress.InnerText = emailAddress.EmailAddress
                    xAddresses.AppendChild(xAddress)
                Next
            End If

            If msg.CC IsNot Nothing Then
                For Each emailAddress As aspNetMime.Address In msg.CC
                    xAddress = xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ADDRESS)
                    xAddress.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ROLEID, ROLEID_CC)
                    xAddress.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FULLNAME, emailAddress.Name.Trim)
                    xAddress.InnerText = emailAddress.EmailAddress
                    xAddresses.AppendChild(xAddress)
                Next
            End If

            Dim xHeader As Xml.XmlElement
            Dim dtSentDate As Date = Date.UtcNow '-- default value
            For Each h In msg.Headers()
                '-- write out all headers so user can see them should they so choose
                Select Case h.Name.ToLower()
                    Case "date"
                        If IsDate(h.Value) Then
                            Try
                                dtSentDate = Convert.ToDateTime(h.Value).ToUniversalTime
                            Catch ex As Exception
                                Log(ex)
                                Log("Could not convert " & h.Value & " to UTC")
                            End Try
                        Else
                            Dim strBestGuess As String = String.Empty
                            If h.Value.Contains("(") AndAlso h.Value.Contains(")") Then
                                '-- Strip off time zone trailer, like '(PST)'
                                strBestGuess = h.Value.Substring(0, h.Value.IndexOf("(") - 1)
                            End If
                            If IsDate(strBestGuess) Then
                                Try
                                    dtSentDate = Convert.ToDateTime(strBestGuess).ToUniversalTime
                                Catch ex As Exception
                                    Log(ex)
                                    Log("Could not convert BG " & h.Value & " to UTC")
                                End Try
                            End If
                        End If
                    Case "reply-to"
                        Dim addr As System.Net.Mail.MailAddress
                        Try
                            addr = New System.Net.Mail.MailAddress(h.Value) '-- some times reply-to is "<user@domain.com>" so this gets just the address

                            If IsValidEmailAddress(addr.Address) Then
                                xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_EMAILREPLYTO, h.Value)
                            Else
                                Log("Invalid Reply-To address: " & addr.Address)
                            End If
                        Catch ex As Exception
                            Log(ex)
                            Log("Invalid Reply-To header: " & h.Value)
                        End Try
                End Select

                '-- Write all headers, even special ones so user can view them
                xHeader = xHeaders.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_HEADER))
                xHeader.SetAttribute(MESSAGE_ATTRIBUTE_NAME_NAME, h.Name)
                xHeader.InnerText = h.Value
            Next

            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENTDATE, dtSentDate.ToString(DATEFORMAT_XML))

            Dim strBody As String
            Dim strSubject As String

            If msg.Subject Is Nothing Then
                strSubject = String.Empty '-- this can happen, but it is rare
            Else
                strSubject = msg.Subject.Value.Trim
            End If
            If overrideSubject.Length > 0 Then
                xSubject.InnerText = overrideSubject
            Else
                xSubject.InnerText = strSubject
            End If

            Dim body As EmailBody = GetBodyFromPOPMessage(msg) '-- needs to be here because need to get the format later (html/text)
            If overrideBody.Length > 0 Then
                strBody = overrideBody
            Else
                strBody = body.Body
            End If



            Dim strOriginalBody As String = strBody

            Dim lngFileSize As Long
            Dim lngSizeOfAllAttachments As Long = 0
            Dim strAttachmentFilename As String
            Dim attachType As EmailAttachmentType

            '-- Note, an attachment can be any of these:
            '   Attachment
            '   InlinePart
            '   EmbeddedPart

            '-- First get attachments and inline parts
            Dim attachments As aspNetMime.MimePartCollection = msg.AttachmentInLineParts
            Dim attachment As aspNetMime.MimePart
            Dim lstMimeParts As New List(Of aspNetMime.MimePart)
            Dim htAttachments As New Hashtable

            For Each attachment In attachments
                lstMimeParts.Add(attachment)
            Next

            '-- Now get embedded items
            attachments = msg.EmbeddedParts
            For Each attachment In attachments
                lstMimeParts.Add(attachment)
            Next

            '-- Now that we have one collection of all attachments, now we can deal with them in a uniform way
            If lstMimeParts.Count > 0 Then
                'if there are attachments, then write out their names
                For Each attachment In lstMimeParts
                    attachType = EmailAttachmentType.Ignore '-- reset variable

                    If attachment.IsAttachment Then
                        '-- write out to attachments folder
                        attachType = EmailAttachmentType.Attachment
                    ElseIf attachment.IsEmbedded OrElse attachment.IsInline Then
                        If attachment.IsImage Then
                            '--must test original body because we change strBody
                            If attachment.EmbeddedName IsNot Nothing AndAlso strOriginalBody.Contains(EMAIL_CONTENTID_CODE & attachment.EmbeddedName) Then
                                '-- write out to images folder
                                attachType = EmailAttachmentType.Embedded
                            Else
                                '-- no reference in the body to show this image, so count as attachment
                                attachType = EmailAttachmentType.Attachment
                            End If
                        Else
                            '-- change so that it is attachment (could be a document embedded in the message)
                            attachType = EmailAttachmentType.Attachment
                        End If
                    End If

                    Select Case attachType
                        Case EmailAttachmentType.Attachment
                            If attachment.Filename Is Nothing Then
                                If attachment.Name Is Nothing Then
                                    '-- random filename
                                    strAttachmentFilename = Guid.NewGuid.ToString.Substring(0, 8).ToUpper

                                    '-- some eml attachments come through without anything but the content type
                                    'If attachment.IsMessage Then
                                    '    strAttachmentFilename &= ".eml"
                                    'Else
                                    Select Case attachment.ContentTypeString.ToLower
                                        Case "text/plain"
                                            strAttachmentFilename &= ".txt"
                                        Case "text/html"
                                            strAttachmentFilename &= ".html"
                                        Case "message/disposition-notification"
                                            strAttachmentFilename &= ".txt"
                                        Case "message/delivery-status"
                                            strAttachmentFilename &= ".txt"
                                        Case "message/rfc822"
                                            strAttachmentFilename &= ".eml"
                                        Case Else
                                            Log("ContentType not found: " & attachment.ContentTypeString)
                                    End Select
                                    'End If
                                Else
                                    strAttachmentFilename = attachment.Name
                                End If
                            Else
                                strAttachmentFilename = attachment.Filename
                            End If

                            strAttachmentFilename = MakeFilenameLegal(strAttachmentFilename)
                            '-- create as needed
                            If Not System.IO.Directory.Exists(strAttachmentFolder) Then
                                System.IO.Directory.CreateDirectory(strAttachmentFolder)
                            End If

                            Try
                                attachment.SaveAs(strAttachmentFolder & strAttachmentFilename)
                            Catch ex As Exception
                                Log(ex) '-- log and continue
                            End Try

                            If tm2TMDecryptionKey.Length > 0 Then
                                '-- this attachment must be a zip containing all the attached and embedded files
                                '   so need to handle this in a special way
                                '   Note: There can be only one (definition of TM2TM message)
                                Try
                                    lngSizeOfAllAttachments = ProcessTM2TMAttachment(strAttachmentFolder & strAttachmentFilename, xAttachments, xDoc, tm2TMDecryptionKey)

                                    '-- need to change the MessageID reference to match the incoming ID (not the sent ID)
                                    strBody = strBody.Replace(ATTACHMENTS_FOLDER_REPLACEMENT_CODE & MESSAGEID_REPLACEMENT_CODE, ATTACHMENTS_FOLDER_REPLACEMENT_CODE & strMessageID)
                                Catch ex As Exception
                                    Log(ex)
                                    '-- most likely the encryption key is wrong

                                    '-- We don't want to keep prompting user for a key which they might not have
                                    '   blocking all other email downloads, so just attach encrypted zip and 
                                    '   then we will decrypt it when trying to read it
                                    xAttachment = xAttachments.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ATTACHMENT))
                                    xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME, strAttachmentFilename)
                                    xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDEMAILTYPE, EncryptedEmailType.EncrypedTM2TMEmail.ToString)
                                    Try
                                        lngFileSize = FileLen(strAttachmentFolder & strAttachmentFilename)
                                    Catch ex1 As Exception
                                        '-- File not there for some reason, just ignore
                                        Log(ex)
                                        lngFileSize = 0
                                    End Try
                                    lngSizeOfAllAttachments += lngFileSize

                                    '-- Add attachment reference
                                    xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILESIZE, lngFileSize.ToString())
                                End Try
                            Else
                                If tm2tmEncrypted Then
                                    '-- flag as encrypted so reader knows
                                    xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_ENCRYPTEDEMAILTYPE, EncryptedEmailType.EncrypedTM2TMEmail.ToString)
                                End If
                                xAttachment = xAttachments.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ATTACHMENT))
                                xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME, strAttachmentFilename)
                                Try
                                    lngFileSize = FileLen(strAttachmentFolder & strAttachmentFilename)
                                Catch ex As Exception
                                    '-- File not there for some reason, just ignore
                                    Log(ex)
                                    lngFileSize = 0
                                End Try
                                lngSizeOfAllAttachments += lngFileSize

                                '-- Add attachment reference
                                xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILESIZE, lngFileSize.ToString())
                            End If

                        Case EmailAttachmentType.Embedded
                            If attachment.Filename Is Nothing Then
                                Dim strFileExtension As String
                                Select Case attachment.ContentSubType.Substring(attachment.ContentSubType.Length - 3).ToLower
                                    Case "gif"
                                        strFileExtension = ".gif"
                                    Case "jpg"
                                        strFileExtension = ".jpg"
                                    Case "bmp"
                                        strFileExtension = ".bmp"
                                    Case "tif"
                                        strFileExtension = ".tif"
                                    Case "png"
                                        strFileExtension = ".png"
                                    Case "peg" '-- actually /jpeg
                                        strFileExtension = ".jpg"
                                    Case Else
                                        strFileExtension = ".jpg" '-- need to default to something
                                End Select
                                strAttachmentFilename = Guid.NewGuid.ToString & strFileExtension
                            Else
                                strAttachmentFilename = attachment.Filename
                            End If

                            '-- Create only when needed (here)
                            If Not System.IO.Directory.Exists(strImagesFolder) Then
                                System.IO.Directory.CreateDirectory(strImagesFolder)
                            End If
                            attachment.SaveAs(strImagesFolder & strAttachmentFilename)
                            lngFileSize = FileLen(strImagesFolder & strAttachmentFilename)
                            lngSizeOfAllAttachments += lngFileSize

                            '-- Now, replace the embedded name with the file just saved
                            strBody = strBody.Replace(EMAIL_CONTENTID_CODE & attachment.EmbeddedName, ATTACHMENTS_FOLDER_REPLACEMENT_CODE & strMessageID & "\" & IMAGES_EMBEDDED_FOLDER & strAttachmentFilename)
                    End Select
                Next
            End If

            If xAttachments.ChildNodes.Count > 0 Then
                xRoot.AppendChild(xAttachments)
            End If

            xBody.InnerText = strBody
            Select Case body.Format
                Case EmailBodyFormatEnum.PlainText
                    xBody.SetAttribute("Format", "PlainText")
                Case EmailBodyFormatEnum.HTML
                    xBody.SetAttribute("Format", "HTML")
            End Select
            xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGESIZE, xDoc.OuterXml.Length + lngSizeOfAllAttachments)
            xDoc.Save(strMessageFilename)

            Return strMessageFilename
        Catch ex As Exception
            Log(ex)
            If email IsNot Nothing Then
                For Each header As aspNetMime.Header In email.Headers
                    Log("Header: " & header.ToString())
                Next
                Log("Raw Text: " & email.RawText) '-- does not include headers
            End If
            Throw ex '-- for breakpoint only
        End Try
    End Function
    Friend Function ProcessTM2TMAttachment(tmm As TrulyMailMessage, item As AttachmentItem, decryptionKey As String) As Long
        Try
            Dim strAttachmentPath As String = System.IO.Path.GetDirectoryName(item.Filename)
            Dim strEncryptedZip As String
            '-- first open
            Using zip As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(item.Filename)
                zip.Password = decryptionKey
                For Each file As Ionic.Zip.ZipEntry In zip.Entries
                    Select Case file.FileName.ToLower
                        Case "comment.txt"
                            '-- do not extract, just ignore this file
                        Case "attachments.zip", "attachments.tmz"
                            strEncryptedZip = System.IO.Path.Combine(strAttachmentPath, file.FileName)
                            If System.IO.File.Exists(strEncryptedZip) Then
                                Try
                                    DeleteLocalFile(strEncryptedZip)
                                Catch ex As Exception
                                    Log(ex)
                                    Log("Failed trying to delete file before unzipping it TM2TM.")
                                End Try
                            End If
                            file.Extract(strAttachmentPath)
                        Case Else
                            '-- WTF??
                            Log("TM2TM with unexpected file: " & file.FileName)
                            Application.DoEvents()
                    End Select
                Next
            End Using

            Dim lngFileSize As Long
            Dim lngSizeOfAllAttachments As Long

            Dim strDestinationFilename As String

            '-- open inner zip (no longer encrypted)
            Using zip As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(strEncryptedZip)
                '-- extra all files
                For Each file As Ionic.Zip.ZipEntry In zip.Entries
                    strDestinationFilename = System.IO.Path.Combine(strAttachmentPath, file.FileName)
                    If System.IO.File.Exists(strDestinationFilename) Then
                        Try
                            DeleteLocalFile(strDestinationFilename)
                        Catch ex As Exception
                            Log(ex)
                            Log("Failed trying to delete file before unzipping it TM2TM.")
                        End Try
                    End If

                    file.Extract(strAttachmentPath)

                    Try
                        lngFileSize = FileLen(System.IO.Path.Combine(strAttachmentPath, file.FileName))
                    Catch ex As Exception
                        '-- File not there for some reason, just ignore
                        Log(ex)
                        lngFileSize = 0
                    End Try

                    If file.FileName.StartsWith(IMAGES_EMBEDDED_FOLDER_IN_ZIP) Then
                        '-- do nothing, just add total size later but this is embedded so no need to add it as an attachment reference
                    Else
                        '-- Add the attachment but don't copy because we already did that above
                        tmm.AddAttachment(strDestinationFilename, False)
                    End If

                    lngSizeOfAllAttachments += lngFileSize
                Next
            End Using

            '-- remove encrypted zip attachment reference
            tmm.RemoveAttachment(item)

            '-- delete inner zip
            DeleteLocalFile(strEncryptedZip)

            '-- delete outer zip
            DeleteLocalFile(item.Filename)


            '-- return total size extracted
            Return lngSizeOfAllAttachments


        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Function
    Friend Function ProcessTM2TMAttachment(zipFilename As String, attachmentsElement As Xml.XmlElement, xDoc As Xml.XmlDocument, decryptionKey As String) As Long
        Try
            Dim strAttachmentPath As String = System.IO.Path.GetDirectoryName(zipFilename)
            Dim strEncryptedZip As String
            '-- first open
            Using zip As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(zipFilename)
                zip.Password = decryptionKey
                For Each file As Ionic.Zip.ZipEntry In zip.Entries
                    Select Case file.FileName.ToLower
                        Case "comment.txt"
                            '-- do not extract, just ignore this file
                        Case "attachments.zip", "attachments.tmz"
                            strEncryptedZip = System.IO.Path.Combine(strAttachmentPath, file.FileName)
                            If System.IO.File.Exists(strEncryptedZip) Then
                                Try
                                    DeleteLocalFile(strEncryptedZip)
                                Catch ex As Exception
                                    Log(ex)
                                    Log("Failed trying to delete file before unzipping it TM2TM.")
                                End Try
                            End If
                            file.Extract(strAttachmentPath)
                        Case Else
                            '-- WTF??
                            Log("TM2TM with unexpected file: " & file.FileName)
                            Application.DoEvents()
                    End Select
                Next
            End Using

            Dim xAttachment As Xml.XmlElement
            Dim lngFileSize As Long
            Dim lngSizeOfAllAttachments As Long

            Dim xElementToRemove As Xml.XmlElement
            If attachmentsElement.ChildNodes.Count > 0 Then
                For Each xElement As Xml.XmlElement In attachmentsElement.ChildNodes
                    If xElement.GetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME).ToLower() = System.IO.Path.GetFileName(zipFilename).ToLower Then
                        xElementToRemove = xElement
                        Exit For
                    End If
                Next
            End If

            Dim strDestinationFilename As String

            '-- open inner zip (no longer encrypted)
            Using zip As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(strEncryptedZip)
                '-- extra all files
                For Each file As Ionic.Zip.ZipEntry In zip.Entries
                    strDestinationFilename = System.IO.Path.Combine(strAttachmentPath, file.FileName)
                    If System.IO.File.Exists(strDestinationFilename) Then
                        Try
                            DeleteLocalFile(strDestinationFilename)
                        Catch ex As Exception
                            Log(ex)
                            Log("Failed trying to delete file before unzipping it TM2TM.")
                        End Try
                    End If

                    file.Extract(strAttachmentPath)

                    Try
                        lngFileSize = FileLen(System.IO.Path.Combine(strAttachmentPath, file.FileName))
                    Catch ex As Exception
                        '-- File not there for some reason, just ignore
                        Log(ex)
                        lngFileSize = 0
                    End Try

                    If file.FileName.StartsWith(IMAGES_EMBEDDED_FOLDER_IN_ZIP) Then
                        '-- do nothing, just add total size later but this is embedded so no need to add it as an attachment reference
                    Else
                        xAttachment = attachmentsElement.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ATTACHMENT))
                        xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILENAME, file.FileName)

                        '-- Add attachment reference
                        xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILESIZE, lngFileSize.ToString())
                    End If

                    lngSizeOfAllAttachments += lngFileSize
                Next
            End Using


            Application.DoEvents() '-- stop

            If xElementToRemove IsNot Nothing Then
                attachmentsElement.RemoveChild(xElementToRemove)
            End If

            '-- delete inner zip
            DeleteLocalFile(strEncryptedZip)

            '-- delete outer zip
            DeleteLocalFile(zipFilename)


            '-- return total size extracted
            Return lngSizeOfAllAttachments


        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Function
    Friend Function GetMessageTypeFromMessageTypeID(ByVal messageTypeID As String) As MessageType
        Select Case messageTypeID
            Case MESSAGETYPE_COMMUNICATION
                Return MessageType.Communication
            Case MESSAGETYPE_DRAFT_COMMUNICATION
                Return MessageType.Draft
            Case MESSAGETYPE_RSSARTICLE
                Return MessageType.RSSArticle
            Case MESSAGETYPE_NOTE_TO_SELF, String.Empty
                Return MessageType.NoteToSelf
            Case Else
                Log("Invalid MessageTypeID: " & messageTypeID)
                Return MessageType.Communication '-- should never get here
        End Select
    End Function
    Friend Function GetMessageTypeIDFromMessageType(ByVal messageType As MessageType) As String
        Select Case messageType
            Case Globals.MessageType.Communication
                Return MESSAGETYPE_COMMUNICATION
            Case Globals.MessageType.Draft
                Return MESSAGETYPE_DRAFT_COMMUNICATION
            Case Globals.MessageType.RSSArticle
                Return MESSAGETYPE_RSSARTICLE
            Case Globals.MessageType.NoteToSelf
                Return MESSAGETYPE_NOTE_TO_SELF
            Case Else
                '-- should never get here
                Log("Invalid MessageType: " & messageType.ToString)
                Return String.Empty
        End Select
    End Function
    Private Function UpdateReceiveDateWithinMessage(ByVal whenRead As Date, ByVal filename As String, ByVal recipientXPath As String) As Boolean
        Dim xDoc As New Xml.XmlDocument()
        xDoc.Load(filename)
        Dim boolShouldSave As Boolean
        Dim nodes As Xml.XmlNodeList = xDoc.SelectNodes(recipientXPath)

        '-- Only update if a unique recip was identified
        If nodes.Count = 1 Then
            Dim element As Xml.XmlElement = CType(nodes(0), Xml.XmlElement)
            '-- only set the attribute if we have not gotten a receipt for this before 
            '   this is to protect against multiple receipts causing in accurate results
            If element.GetAttribute(ATTRIBUTE_NAME_RECEIVED_DATE) = String.Empty Then
                element.SetAttribute(ATTRIBUTE_NAME_RECEIVED_DATE, whenRead.ToString(DATEFORMAT_XML))
                boolShouldSave = True
            Else
                '-- there is a value, update only if the new value is earlier
                Dim dtExisting As Date = ConvertToDateFromXML(element.GetAttribute(ATTRIBUTE_NAME_RECEIVED_DATE), Date.MinValue)
                If whenRead < dtExisting Then
                    element.SetAttribute(ATTRIBUTE_NAME_RECEIVED_DATE, whenRead.ToString(DATEFORMAT_XML))
                    boolShouldSave = True
                End If
            End If

            If boolShouldSave Then
                xDoc.Save(filename)
                Return True
            Else
                Return False
            End If
        Else
            '-- Problem, could not find matching recipient
            Log("UpdateReceiveDateWithinMessage did not find recipient on message. XPath=" & recipientXPath & " --- Found=" & nodes.Count.ToString())
            Return False
        End If
    End Function
    Private Function UpdateReadDateWithinMessage(ByVal whenRead As Date, ByVal filename As String, ByVal recipientXPath As String) As Boolean
        Dim xDoc As New Xml.XmlDocument()
        xDoc.Load(filename)
        Dim boolShouldSave As Boolean
        Dim nodes As Xml.XmlNodeList = xDoc.SelectNodes(recipientXPath)

        '-- Only update if a unique recip was identified
        If nodes.Count = 1 Then
            Dim element As Xml.XmlElement = CType(nodes(0), Xml.XmlElement)
            '-- only set the attribute if we have not gotten a receipt for this before 
            '   this is to protect against multiple receipts causing in accurate results
            If element.GetAttribute(ATTRIBUTE_NAME_READ_DATE) = String.Empty Then
                element.SetAttribute(ATTRIBUTE_NAME_READ_DATE, whenRead.ToString(DATEFORMAT_XML))
                boolShouldSave = True
            Else
                '-- there is a value, update only if the new value is earlier
                Dim dtExisting As Date = ConvertToDateFromXML(element.GetAttribute(ATTRIBUTE_NAME_READ_DATE), Date.MinValue)
                If whenRead < dtExisting Then
                    element.SetAttribute(ATTRIBUTE_NAME_READ_DATE, whenRead.ToString(DATEFORMAT_XML))
                    boolShouldSave = True
                End If
            End If
            If element.GetAttribute(ATTRIBUTE_NAME_RECEIVED_DATE) = String.Empty Then
                element.SetAttribute(ATTRIBUTE_NAME_RECEIVED_DATE, whenRead.ToString(DATEFORMAT_XML))
                boolShouldSave = True
            Else
                '-- there is a value, update only if the new value is earlier
                Dim dtExisting As Date = ConvertToDateFromXML(element.GetAttribute(ATTRIBUTE_NAME_RECEIVED_DATE), Date.MinValue)
                If whenRead < dtExisting Then
                    element.SetAttribute(ATTRIBUTE_NAME_RECEIVED_DATE, whenRead.ToString(DATEFORMAT_XML))
                    boolShouldSave = True
                End If
            End If

            If boolShouldSave Then
                xDoc.Save(filename)
                Return True
            Else
                Return False
            End If
        Else
            '-- Problem, could not find matching recipient
            Log("UpdateReadDateWithinMessage did not find recipient on message. XPath=" & recipientXPath & " --- Found=" & nodes.Count.ToString())
            Return False
        End If
    End Function
    ''' <summary>
    ''' Updates an email message as read
    ''' </summary>
    ''' <param name="filename">Filename of message</param>
    ''' <param name="whenRead">When the recip read the message</param>
    ''' <param name="emailAddress">Email address of the recipient</param>
    ''' <param name="fullName">Optional full name of the recipient (use string.empty to ignore names)</param>
    ''' <returns>True if recipient was updated</returns>
    ''' <remarks></remarks>
    Friend Function UpdateReadDateWithinMessage(ByVal filename As String, ByVal whenRead As Date, ByVal emailAddress As String, ByVal fullName As String) As Boolean
        Dim strXPath As String
        If fullName.Length > 0 Then
            strXPath = "Message/Recipients/Recipient[translate(@Address, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = '" & emailAddress & "' and @FullName='" & fullName & "']"
        ElseIf emailAddress.Length > 0 Then
            strXPath = "Message/Recipients/Recipient[translate(@Address, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = '" & emailAddress & "']"
        Else
            '-- If there is only one recipient, then just update that one
            '   otherwise we will return false and the caller can notify the user
            strXPath = "Message/Recipients/Recipient"
        End If

        Return UpdateReadDateWithinMessage(whenRead, filename, strXPath)
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <param name="recipientID"></param>
    ''' <param name="whenRead"></param>
    ''' <returns>True if recipient was updated</returns>
    ''' <remarks></remarks>
    Friend Function UpdateReadDateWithinMessage(ByVal filename As String, ByVal recipientID As String, ByVal whenRead As Date) As Boolean
        Dim strXPath As String = "Message/Recipients/Recipient[@RecipientID='" & recipientID & "']"
        Return UpdateReadDateWithinMessage(whenRead, filename, strXPath)
    End Function
    Friend Function UpdateReceiveDateWithinMessage(ByVal filename As String, ByVal recipientID As String, ByVal whenRead As Date) As Boolean
        Dim strXPath As String = "Message/Recipients/Recipient[@RecipientID='" & recipientID & "']"
        Return UpdateReceiveDateWithinMessage(whenRead, filename, strXPath)
    End Function
    ''' <summary>
    ''' This is used for processing receipts for sent encrypted email messages and encrypted web messages (called from GetNewReceipts)
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <param name="whenRead"></param>
    ''' <param name="recipientAddress"></param>
    ''' <remarks></remarks>
    Friend Sub UpdateReceivedAndReadDateWithinMessageByAddress(ByVal filename As String, ByVal whenRead As Date, ByVal recipientAddress As String)
        Dim strXPath As String = "Message/Recipients/Recipient[@Address='" & recipientAddress & "']"
        UpdateReceiveDateWithinMessage(whenRead, filename, strXPath)
        UpdateReadDateWithinMessage(whenRead, filename, strXPath)
    End Sub
    ''' <summary>
    ''' Returns a list of TrulyMailMessage objects with matching subjects found in the folder specified
    ''' </summary>
    ''' <param name="subject"></param>
    ''' <param name="folder"></param>
    ''' <param name="subFolders"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function FindMessagesBySubject(ByVal subject As String, ByVal folder As String, ByVal subFolders As Boolean, ByVal endsWithMatching As Boolean) As List(Of TrulyMailMessage)
        Dim loader As New FileListLoader(REGEX_MESSAGE_FILENAME)
        Dim lstReturn As New List(Of TrulyMailMessage)
        Dim lst As List(Of FileDetails) = loader.GetFilesInPath(folder, subFolders)
        Using msgIndex As New MessageIndex(SentItemsRootPath)

            Dim tmm As TrulyMailMessage
            Dim xDoc As New Xml.XmlDocument()
            For Each detail As FileDetails In lst
                Try
                    tmm = msgIndex.GetMessage(detail) '-- 29 July 2010 replaced with index to speed up search

                    If tmm IsNot Nothing Then
                        If endsWithMatching Then
                            If tmm.Subject.ToLower.EndsWith(subject.ToLower.Trim) Then
                                lstReturn.Add(tmm)
                            End If
                        Else
                            If tmm.Subject.ToLower = subject.ToLower.Trim Then
                                lstReturn.Add(tmm)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Log(ex)
                End Try
            Next
        End Using

        Return lstReturn
    End Function
    Friend Function GetRoleIDByRecipientType(recipientType As RecipientType) As String
        Select Case recipientType
            Case GlobalEnums.RecipientType.Send_To
                Return ROLEID_FROM
            Case GlobalEnums.RecipientType.Send_CC
                Return ROLEID_CC
            Case GlobalEnums.RecipientType.Send_BCC
                Return ROLEID_BCC
        End Select
    End Function
    Friend Function GetRecipientTypeByRoleID(ByVal roleID As String) As RecipientType
        Select Case roleID
            Case ROLEID_TO
                Return RecipientType.Send_To
            Case ROLEID_CC
                Return RecipientType.Send_CC
            Case ROLEID_BCC
                Return RecipientType.Send_BCC
        End Select
    End Function
    Friend Function GenerateAlphanumericString(ByVal length As Integer) As String
        'Make sure length and numberOfNonAlphanumericCharacters are valid....
        '... checks omitted for brevity ... see live demo for full code ...

        Do While True
            Dim i As Integer
            Dim buffer1 As Byte() = New Byte(length - 1) {}

            'chPassword contains the password's characters as it's built up
            Dim chPassword As Char() = New Char(length - 1) {}

            'chPunctionations contains the list of legal non-alphanumeric characters
            Dim chPunctuations As Char() = "!@@$%^^*()_-+=[{]};:>|./?".ToCharArray()

            'Get a cryptographically strong series of bytes
            Dim rng As New System.Security.Cryptography.RNGCryptoServiceProvider
            rng.GetBytes(buffer1)

            For i = 0 To length - 1
                'Convert each byte into its representative character
                Dim rndChr As Integer = (buffer1(i) Mod 62)
                If (rndChr < 10) Then
                    chPassword(i) = Convert.ToChar(Convert.ToUInt16(48 + rndChr))
                Else
                    If (rndChr < 36) Then
                        chPassword(i) = Convert.ToChar(Convert.ToUInt16((65 + rndChr) - 10))
                    Else
                        If (rndChr < 62) Then
                            chPassword(i) = Convert.ToChar(Convert.ToUInt16((97 + rndChr) - 36))
                        Else
                            '-- above where you see "Dim rndChr As Integer = (buffer1(i) Mod 62)"
                            '   Change the number after mod to 87 and you can throw in some non-alphanumeric characters
                            '   If the number is 62, then we never go in this branch
                            chPassword(i) = chPunctuations(rndChr - 62)
                            'nonANcount += 1
                        End If
                    End If
                End If
            Next

            Return New String(chPassword)
        Loop
    End Function
    Friend Sub ProcessLatestProfile(ByVal xml As String)
        Dim xDoc As New Xml.XmlDocument()
        xDoc.Load(xml)

        For Each xElement As Xml.XmlElement In xDoc.DocumentElement.ChildNodes
            Select Case xElement.Name
                Case ""
                Case ""
                Case ""
                Case ""
                Case ""
                Case ""
                Case ""
                Case ""
                Case ""
                Case ""
                Case "Website"
                Case "AboutMe"
                Case "PublicUser"
            End Select
        Next
    End Sub
    Public Function StripHTML(source As String) As String
        '-- finding aspnet's html removing logic more polished
        Dim strLicense As String = My.Resources.aspnetemail_xml_lic
        aspNetEmail.EmailMessage.LoadLicenseString(strLicense)
        Dim h As New aspNetEmail.HtmlUtility()
        Dim strToReturn As String = h.ToPlainText(source, aspNetEmail.HtmlRemovalOptions.All)

        '-- just strip upper and lower...comes in from errors in feed-providers
        strToReturn = strToReturn.Replace("&nbsp;", " ")
        strToReturn = strToReturn.Replace("&NBSP;", " ")

        Return strToReturn
    End Function
    Public Function StripHTML(ByVal source As String, ByVal keepBreaks As Boolean) As String
        '-- From: http://www.codeproject.com/KB/HTML/HTML_to_Plain_Text.aspx
        Try
            Dim result As String = source

            ' Remove HTML Development formatting
            ' Replace line breaks with space
            ' because browsers inserts space
            result = source.Replace(ControlChars.Cr, " ")
            ' Replace line breaks with space
            ' because browsers inserts space
            result = result.Replace(ControlChars.Lf, " ")
            'System.IO.File.AppendAllText("C:\Users\John\Documents\Visual Studio 2008\Projects\TrulyMail\TrulyMailClient\bin\x86\test5.txt", result)
            ' Remove step-formatting
            result = result.Replace(ControlChars.Tab, String.Empty)
            ' Remove repeating spaces because browsers ignore them
            result = System.Text.RegularExpressions.Regex.Replace(result, "( )+", " ")

            ' Remove the header (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*head([^>])*>", "<head>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<( )*(/)( )*head( )*>)", "</head>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<head>).*(</head>)", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' remove all scripts (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*script([^>])*>", "<script>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<( )*(/)( )*script( )*>)", "</script>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            'result = System.Text.RegularExpressions.Regex.Replace(result,
            '         @"(<script>)([^(<script>\.</script>)])*(</script>)",
            '         string.Empty,
            '         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<script>).*(</script>)", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' remove all styles (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*style([^>])*>", "<style>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<( )*(/)( )*style( )*>)", "</style>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(<style>).*(</style>)", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' insert tabs in spaces of <td> tags
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*td([^>])*>", vbTab, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' insert line breaks in places of <BR> and <LI> tags
            If Not keepBreaks Then
                result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*br( )*>", vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            End If
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*li( )*>", vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' insert line paragraphs (double line breaks) in place
            ' if <P>, <DIV> and <TR> tags
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*div([^>])*>", vbNewLine & vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*tr([^>])*>", vbNewLine & vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "<( )*p([^>])*>", vbNewLine & vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' Remove remaining tags like <a>, links, images,
            ' comments etc - anything that's enclosed inside < >
            result = System.Text.RegularExpressions.Regex.Replace(result, "<[^>]*>", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            '-- At this point we may start with space-newline-newline, if so, strip it off
            Dim strLeadingStringToReplace As String = " " & vbNewLine & vbNewLine
            If result.StartsWith(strLeadingStringToReplace) Then
                result = result.Substring(strLeadingStringToReplace.Length)
            End If

            ' replace special characters:
            result = System.Text.RegularExpressions.Regex.Replace(result, " ", " ", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&bull;", " * ", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&lsaquo;", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&rsaquo;", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&trade;", "(tm)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&frasl;", "/", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&lt;", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&gt;", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&copy;", "(c)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "&reg;", "(r)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' Remove all others. More can be added, see
            ' http://hotwired.lycos.com/webmonkey/reference/special_characters/
            result = System.Text.RegularExpressions.Regex.Replace(result, "&(.{2,6});", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            ' for testing
            'System.Text.RegularExpressions.Regex.Replace(result,
            '       this.txtRegex.Text,string.Empty,
            '       System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            ' make line breaking consistent
            'result = result.Replace(ControlChars.Lf, ControlChars.Cr)
            'System.IO.File.AppendAllText("C:\Users\John\Documents\Visual Studio 2008\Projects\TrulyMail\TrulyMailClient\bin\x86\Data\test4.txt", result)

            ' Remove extra line breaks and tabs:
            ' replace over 2 breaks with 2 and over 4 tabs with 4.
            ' Prepare first to remove any whitespaces in between
            ' the escaped characters and remove redundant tabs in between line breaks
            result = System.Text.RegularExpressions.Regex.Replace(result, "(" + ControlChars.Cr + ")( )+(" + ControlChars.Cr + ")", ControlChars.Cr + ControlChars.Cr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(" + ControlChars.Tab + ")( )+(" + ControlChars.Tab + ")", ControlChars.Tab + ControlChars.Tab, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(" + ControlChars.Tab + ")( )+(" + ControlChars.Cr + ")", ControlChars.Tab + ControlChars.Cr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            result = System.Text.RegularExpressions.Regex.Replace(result, "(" + ControlChars.Cr + ")( )+(" + ControlChars.Tab + ")", ControlChars.Cr + ControlChars.Tab, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            ' Remove redundant tabs
            result = System.Text.RegularExpressions.Regex.Replace(result, "(" + ControlChars.Cr + ")(" + ControlChars.Tab + ")+(" + ControlChars.Cr + ")", ControlChars.Cr + ControlChars.Cr, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            ' Remove multiple tabs following a line break with just one tab
            result = System.Text.RegularExpressions.Regex.Replace(result, "(" + ControlChars.Cr + ")(" + ControlChars.Tab + ")+", ControlChars.Cr + ControlChars.Tab, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            ' Initial replacement target string for line breaks
            Dim breaks As String = ControlChars.Cr + ControlChars.Cr + ControlChars.Cr
            ' Initial replacement target string for tabs
            Dim tabs As String = ControlChars.Tab + ControlChars.Tab + ControlChars.Tab + ControlChars.Tab + ControlChars.Tab
            Dim index As Integer
            For index = 0 To result.Length - 1
                result = result.Replace(breaks, ControlChars.Cr + ControlChars.Cr)
                result = result.Replace(tabs, ControlChars.Tab + ControlChars.Tab + ControlChars.Tab + ControlChars.Tab)
                breaks = breaks + ControlChars.Cr
                tabs = tabs + ControlChars.Tab
            Next index

            ' That's it.
            Return result
        Catch
        End Try
    End Function 'StripHTML
    Friend Sub RespondToLaunchWithParameters(ByVal params As System.Collections.ObjectModel.ReadOnlyCollection(Of String))
        Dim lstAttachments As New List(Of String)

        For Each strParam As String In params
            If strParam.ToLower().EndsWith(MESSAGE_FILENAME_EXTENSION) AndAlso System.IO.File.Exists(strParam) Then
                '-- opening message by launching a .tmm file
                LoadMessage(strParam)
            ElseIf strParam.ToLower().StartsWith("mailto:") Then
                strParam = strParam.Replace("%0A", "<br>")
                Dim msg As New NewMessage(System.Web.HttpUtility.UrlDecode(strParam), True)
                msg.Show()
                msg.BringToFront()
            ElseIf System.IO.File.Exists(strParam) Then
                '-- some other file being passed in, let's assume user wants to attach it to a new message
                lstAttachments.Add(strParam)
            Else
                '-- Log and ignore
                Log("Unknown Launch Parameter: " & strParam)
            End If
        Next

        If lstAttachments.Count > 0 Then
            Dim frm As New NewMessage()
            frm.Show()
            frm.BringToFront()
            For Each strFilename As String In lstAttachments
                frm.AddAttachmentToList(strFilename, True)
            Next
        End If
    End Sub

    ''' <summary>
    ''' Centralized routine for opening attachments
    ''' </summary>
    ''' <param name="attachmentFilename"></param>
    ''' <param name="sourceMessageFilename"></param>
    ''' <remarks></remarks>
    Friend Sub OpenAttachment(ByVal attachmentFilename As String)
        Try
            '-- Let's prompt the user if the file is an executable or dangerous in some other way
            'TODO: Allow user to remember the answer and avoid prompt every time
            Dim strExtension As String = System.IO.Path.GetExtension(attachmentFilename).ToLower()
            If EXEFileExtensions.Contains(strExtension) Then
                If ShowMessageBox("This file seems to be an executable program (or potentially dangerous in some way). Are you sure you want to open it?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            ElseIf strExtension = ".zip" Then
                '-- need to test if there are dangerous attachments inside the zip file
                Dim intTotalEntries As Integer
                Dim intDangerousEntries As Integer
                Using zip As New Ionic.Zip.ZipFile(attachmentFilename)
                    For Each entry As Ionic.Zip.ZipEntry In zip.Entries
                        intTotalEntries += 1
                        strExtension = System.IO.Path.GetExtension(entry.FileName).ToLower()
                        If EXEFileExtensions.Contains(strExtension) Then
                            intDangerousEntries += 1
                        End If
                    Next
                End Using

                If intDangerousEntries > 0 Then
                    If ShowMessageBox("This attachment contains:" & _
                                      Environment.NewLine & Environment.NewLine & _
                                      "Total files: " & intTotalEntries.ToString("#,##0") & Environment.NewLine & _
                                      "Potentially dangerous files: " & intDangerousEntries.ToString("#,##0") & _
                                      Environment.NewLine & Environment.NewLine & _
                                      "Zip files (like this attachment) are one way hackers try to infect your computer. Are you sure you want to open it?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                End If
            End If

            If attachmentFilename.ToLower.EndsWith(".eml") Then
                Dim strNewFilename As String = ConvertEmailToTrulyMail(attachmentFilename)
                LoadMessage(strNewFilename)
            Else
                System.Diagnostics.Process.Start(attachmentFilename)
            End If

        Catch ex As Exception
            If ex.Message.Contains("No application is associated") Then
                MessageBox.Show("There is no application associated with this attached file (" & System.IO.Path.GetFileName(attachmentFilename) & ")." & Environment.NewLine & Environment.NewLine & _
                                "You can drag-and-drop to save the attachment and open the file from there.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf ex.Message.Contains("The system cannot find the file specified") Then
                MessageBox.Show("The attachment cannot be found. Perhaps it was deleted manually?", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Log(ex)
                MessageBox.Show("There was an unexpected error (" & ex.Message & ") with this attached file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Try

    End Sub
    Friend Sub MarkMessageUnsent(ByVal filename As String)
        Try
            Dim xDoc As New Xml.XmlDocument()
            xDoc.Load(filename)
            xDoc.DocumentElement.SetAttribute(MESSAGE_ATTRIBUTE_NAME_UNSENTDATE, Date.UtcNow.ToString(DATEFORMAT_XML))
            xDoc.Save(filename)
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error updating the existing message. Please contact TrulyMail Support.")
        End Try
    End Sub
    Friend Function GetEXEFullPath() As String
        '-- returns the full path to the TrulyMail.exe file 
        '   this might be different if other app is calling via API
        'Return System.Reflection.Assembly.GetExecutingAssembly.Location
        '-- by the way "Application.ExecutablePath" will give the same result: The API-calling app, not TrulyMail.exe

        '-- Changing 12 Dec 2016 to support API calls not messing up settings file
        Dim codeBase As String = System.Reflection.Assembly.GetExecutingAssembly().CodeBase
        Dim uri As UriBuilder = New UriBuilder(codeBase)
        Dim path As String = uri.Uri.UnescapeDataString(uri.Path)
        Return path
    End Function
    
    Friend Sub ReplyToSenderNoBody(ByVal filename As String)
        If filename.Length > 0 Then
            If System.IO.File.Exists(filename) Then
                Dim msg As IComposeForm
                If UseFallbackModeNow() Then
                    msg = New NewMessageSimple(filename, MessageResponseType.ReplyNoBody)
                Else
                    msg = New NewMessage(filename, MessageResponseType.ReplyNoBody)
                End If
                CType(msg, Form).Show()

                MarkLocalMessageRead(filename, False)
            Else
                ShowMessageBoxError("This message has already been deleted.")
                g_boolFileSystemChanged = True
            End If
        End If
    End Sub
    Friend Sub ReplyToSender(ByVal filename As String, Optional includeAttachments As Boolean = False)
        If filename.Length > 0 Then
            If System.IO.File.Exists(filename) Then
                Dim msg As IComposeForm
                If UseFallbackModeNow() Then
                    msg = New NewMessageSimple(filename, MessageResponseType.Reply)
                Else
                    msg = New NewMessage(filename, MessageResponseType.Reply)
                End If
                CType(msg, Form).Show()

                If includeAttachments Then
                    Dim tm As New TrulyMailMessage(filename)
                    For Each item As AttachmentItem In tm.Attachments
                        msg.AddAttachmentToList(item.Filename, True)
                    Next
                End If

                MarkLocalMessageRead(filename, False)
            Else
                ShowMessageBoxError("This message has already been deleted.")
                g_boolFileSystemChanged = True
            End If
        End If
    End Sub
    Friend Sub ReplyToAllNoBody(filename As String)
        If filename.Length > 0 Then
            If System.IO.File.Exists(filename) Then
                Dim msg As IComposeForm
                If UseFallbackModeNow() Then
                    msg = New NewMessageSimple(filename, MessageResponseType.ReplyToAllNoBody)
                Else
                    msg = New NewMessage(filename, MessageResponseType.ReplyToAllNoBody)
                End If
                CType(msg, Form).Show()

                MarkLocalMessageRead(filename, False)
            Else
                ShowMessageBoxError("This message has already been deleted.")
                g_boolFileSystemChanged = True
            End If
        End If
    End Sub
    Friend Sub ReplyToAll(ByVal filename As String, Optional includeAttachments As Boolean = False)
        If filename.Length > 0 Then
            If System.IO.File.Exists(filename) Then
                Dim msg As IComposeForm
                If UseFallbackModeNow() Then
                    msg = New NewMessageSimple(filename, MessageResponseType.ReplyToAll)
                Else
                    msg = New NewMessage(filename, MessageResponseType.ReplyToAll)
                End If
                CType(msg, Form).Show()

                If includeAttachments Then
                    Dim tm As New TrulyMailMessage(filename)
                    For Each item As AttachmentItem In tm.Attachments
                        msg.AddAttachmentToList(item.Filename, True)
                    Next
                End If

                MarkLocalMessageRead(filename, False)
            Else
                ShowMessageBoxError("This message has already been deleted.")
                g_boolFileSystemChanged = True
            End If
        End If
    End Sub
    Friend Sub ForwardMessageNoAttachments(ByVal filename As String)
        If filename.Length > 0 Then
            If System.IO.File.Exists(filename) Then
                Dim msg As IComposeForm
                If UseFallbackModeNow() Then
                    msg = New NewMessageSimple(filename, MessageResponseType.ForwardNoAttachments)
                Else
                    msg = New NewMessage(filename, MessageResponseType.ForwardNoAttachments)
                End If
                CType(msg, Form).Show()

                MarkLocalMessageRead(filename, False)
            Else
                ShowMessageBoxError("This message has already been deleted.")
                g_boolFileSystemChanged = True
            End If
        End If
    End Sub
    Friend Sub ForwardMessage(ByVal filename As String)
        Try
            If filename.Length > 0 Then
                If System.IO.File.Exists(filename) Then
                    Dim msg As IComposeForm
                    If UseFallbackModeNow() Then
                        msg = New NewMessageSimple(filename, MessageResponseType.Forward)
                    Else
                        msg = New NewMessage(filename, MessageResponseType.Forward)
                    End If
                    CType(msg, Form).Show()

                    MarkLocalMessageRead(filename, False)
                Else
                    ShowMessageBoxError("This message has already been deleted.")
                    g_boolFileSystemChanged = True
                End If
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Friend Sub FollowUpMessage(ByVal filename As String)
        If filename.Length > 0 Then
            If System.IO.File.Exists(filename) Then
                Dim msg As IComposeForm
                If UseFallbackModeNow() Then
                    msg = New NewMessageSimple(filename, MessageResponseType.FollowUp)
                Else
                    msg = New NewMessage(filename, MessageResponseType.FollowUp)
                End If
                CType(msg, Form).Show()

                MarkLocalMessageRead(filename, False)
            Else
                ShowMessageBoxError("This message has already been deleted.")
                g_boolFileSystemChanged = True
            End If
        End If
    End Sub
    Friend Sub ResendMessage(ByVal filename As String)
        If filename.Length > 0 Then
            If System.IO.File.Exists(filename) Then
                Dim msg As IComposeForm
                If UseFallbackModeNow() Then
                    msg = New NewMessageSimple(filename, MessageResponseType.Resend)
                Else
                    msg = New NewMessage(filename, MessageResponseType.Resend)
                End If
                CType(msg, Form).Show()

                MarkLocalMessageRead(filename, False)
            Else
                ShowMessageBoxError("This message has already been deleted.")
                g_boolFileSystemChanged = True
            End If
        End If
    End Sub
    Friend Function GetMainAppFolder() As String
        Return System.IO.Path.GetDirectoryName(GetEXEFullPath())
    End Function
    Friend Function GetNotifySoundFilename() As String
        Dim strAppSoundsPath As String = GetMainAppFolder()
        strAppSoundsPath = System.IO.Path.Combine(strAppSoundsPath, SOUNDS_FOLDER_NAME)
        Dim strFilename As String = String.Empty

        If AppSettings.NewMessageNotifySound.Length = 0 Then
            '-- play nothing
            Return String.Empty
        Else
            If AppSettings.NewMessageNotifySound = NOTIFY_SOUND_DEFAULT Then
                Return NOTIFY_SOUND_DEFAULT
            Else
                If AppSettings.NewMessageNotifySound.StartsWith(NOTIFY_SOUND_APPSOUNDS) Then
                    strFilename = AppSettings.NewMessageNotifySound.Replace(NOTIFY_SOUND_APPSOUNDS, strAppSoundsPath)
                    If System.IO.File.Exists(strFilename) Then
                        Return strFilename
                    Else
                        Return NOTIFY_SOUND_DEFAULT
                    End If
                ElseIf AppSettings.NewMessageNotifySound.StartsWith(NOTIFY_SOUND_USERSOUNDS) Then
                    strFilename = AppSettings.NewMessageNotifySound.Replace(QualifyPath(NOTIFY_SOUND_USERSOUNDS), MySoundsPath)
                    If System.IO.File.Exists(strFilename) Then
                        Return strFilename
                    Else
                        Return NOTIFY_SOUND_DEFAULT
                    End If
                Else
                    '-- illegal sound, reset to default
                    Return NOTIFY_SOUND_DEFAULT
                End If
            End If
        End If
    End Function
    Friend Function GetTempPath() As String
        '-- In 5.1 changed this to ALWAYS be under the profile
        '   because we need to clean up decrypted attachments
        'If AppSettings.PortableProfile Then
        Return MessageStoreTempPath
        'Else
        ''-- use computer's temp path
        'Return System.IO.Path.GetTempPath()
        'End If
    End Function
    Friend Function GetTempFilename(Optional ByVal fileExtension As String = ".tmp") As String
        Dim strFilename As String
        Do
            strFilename = MessageStoreTempPath & GenerateAlphanumericString(8) & fileExtension
        Loop While System.IO.File.Exists(strFilename)

        Return strFilename
    End Function
    Friend Sub SetupToolStripForText(ByVal strip As ToolStrip)
        For Each item As ToolStripItem In strip.Items
            If TypeOf item Is ToolStripButton Then
                Dim button As ToolStripButton = CType(item, ToolStripButton)
                If AppSettings.ToolBarsShowText Then
                    item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                Else
                    item.DisplayStyle = ToolStripItemDisplayStyle.Image
                End If
            ElseIf TypeOf item Is ToolStripSplitButton Then
                Dim button As ToolStripSplitButton = CType(item, ToolStripSplitButton)
                If AppSettings.ToolBarsShowText Then
                    item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                Else
                    item.DisplayStyle = ToolStripItemDisplayStyle.Image
                End If
            ElseIf TypeOf item Is ToolStripDropDownButton Then
                Dim button As ToolStripDropDownButton = CType(item, ToolStripDropDownButton)
                If AppSettings.ToolBarsShowText Then
                    item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                Else
                    item.DisplayStyle = ToolStripItemDisplayStyle.Image
                End If
            End If
        Next
    End Sub
    Public Sub EmptyMessageStoreTempPath()
        Try
            Dim files() As String = System.IO.Directory.GetFiles(MessageStoreTempPath, "*.*", IO.SearchOption.AllDirectories)
            For Each strFilename As String In files
                Try
                    DeleteLocalFile(strFilename)
                Catch ex As Exception
                    Log("Cannot delete temp file: " & strFilename)
                End Try
            Next

            Dim dirs() As String = System.IO.Directory.GetDirectories(MessageStoreTempPath, "*.*", IO.SearchOption.AllDirectories)
            For Each strFolder As String In dirs
                Try
                    System.IO.Directory.Delete(strFolder, True)
                Catch ex As Exception
                    Log("Cannot delete temp folder: " & strFolder)
                End Try
            Next

        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Public Sub DoNothingAspectPutter(ByVal rowObject As Object, ByVal newValue As Object)
        '-- do nothing
    End Sub
    Public Function GetFolderState(ByVal fullpath As String) As FolderState
        Dim folder As FolderState
        Dim boolFound As Boolean
        Dim strPath As String = QualifyPath(fullpath.ToLower())
        For Each folder In AppSettings.FolderStates
            If folder.FullPath = strPath Then
                boolFound = True
                Exit For
            End If
        Next

        '-- folder is not found
        If Not boolFound Then
            folder = New FolderState()
            folder.FullPath = strPath
            folder.Expanded = False
            folder.Icon = 0
            folder.UnreadCount = 0
            folder.TotalCount = 0
            AppSettings.FolderStates.Add(folder)
        End If

        Return folder
    End Function
    ''' <summary>
    ''' Converts a TrulyMail message into an eml file
    ''' </summary>
    ''' <param name="tm">The TrulyMail message to convert</param>
    ''' <param name="emlFilename">The name of the eml file to create</param>
    ''' <param name="trulyMailContactEmailAddress">Leave blank to ignore TrulyMail contacts</param>
    ''' <returns>true if message was exported, false if not for any reason</returns>
    ''' <remarks></remarks>
    Public Function ConvertTrulyMailMessageToEMLFile(ByVal tm As TrulyMailMessage, ByVal emlFilename As String, ByVal trulyMailContactEmailAddress As String) As Boolean
        Try
            Dim strLicense As String = My.Resources.aspnetemail_xml_lic
            aspNetEmail.EmailMessage.LoadLicenseString(strLicense)
            Dim msg As New aspNetEmail.EmailMessage()


            msg.CharSet = "UTF-8"
            msg.ContentTransferEncoding = aspNetEmail.MailEncoding.QuotedPrintable
            msg.HeaderEncoding = aspNetEmail.MailEncoding.QuotedPrintable
            msg.RequireRecipients = False

            If tm.Subject Is Nothing Then
                msg.Subject = String.Empty
            Else
                msg.Subject = tm.Subject
            End If
            Dim boolScanForEmbeddedImages As Boolean

            If Not tm.Sent Then
                If tm.Sender.ContactType = AddressBookEntryType.Email Then
                    If msg.IsValidEmail(tm.Sender.Address) Then
                        msg.FromAddress = tm.Sender.Address
                    Else
                        msg.FromAddress = trulyMailContactEmailAddress '-- should not normally get here (it means an email was recevied without a valid sender address)
                    End If
                Else
                    If trulyMailContactEmailAddress.Length = 0 Then
                        '-- must be received via TrulyMail but an email recipient was also on the message
                        '   so, we won't export this message
                        Return False
                    Else
                        msg.FromAddress = trulyMailContactEmailAddress
                    End If
                End If
                msg.FromName = tm.Sender.FullName
            Else
                If tm.SMTPProfile IsNot Nothing Then
                    msg.FromAddress = tm.SMTPProfile.DisplayEmail
                    msg.FromName = tm.SMTPProfile.DisplayName
                Else
                    msg.FromAddress = trulyMailContactEmailAddress
                    msg.FromName = tm.Sender.FullName
                End If
            End If

            Select Case tm.BodyFormat
                Case EmailBodyFormatEnum.HTML
                    msg.BodyFormat = aspNetEmail.MailFormat.Html
                    boolScanForEmbeddedImages = True
                Case (EmailBodyFormatEnum.PlainText)
                    msg.BodyFormat = aspNetEmail.MailFormat.Text
                Case EmailBodyFormatEnum.MixedPainTextAndHTML
                    '-- email gets plain text, trulymail gets html... however, we must pick, so we pick email's format since we're saving in .eml format
                    msg.BodyFormat = aspNetEmail.MailFormat.Text
            End Select

            If boolScanForEmbeddedImages Then
                'Dim strImageFolderAbsolutePath As String = ATTACHMENTS_FOLDER_REPLACEMENT_CODE & messageID & "\" & IMAGES_EMBEDDED_FOLDER
                If tm.Body.Contains(ATTACHMENTS_FOLDER_REPLACEMENT_CODE) Then
                    '-- There are embedded images, though we might not have them on disk (hopefully we do)
                    Dim intPositionStart As Integer = tm.Body.IndexOf(ATTACHMENTS_FOLDER_REPLACEMENT_CODE)
                    Dim intPositionEnd As Integer
                    Dim strFilename As String
                    Dim strFileReference As String
                    Dim strID As String = Guid.NewGuid().ToString()

                    Do Until intPositionStart = -1
                        intPositionEnd = tm.Body.IndexOf("""", intPositionStart)
                        strFileReference = tm.Body.Substring(intPositionStart, intPositionEnd - intPositionStart)
                        strFilename = strFileReference.Replace(ATTACHMENTS_FOLDER_REPLACEMENT_CODE, AttachmentsRootPath)
                        tm.Body = tm.Body.Replace(strFileReference, strFilename)
                        msg.EmbedImage(strID, strFilename)

                        intPositionStart = tm.Body.IndexOf(ATTACHMENTS_FOLDER_REPLACEMENT_CODE)
                    Loop
                End If
            End If
            msg.Body = tm.Body

            For Each recip As RecipientEntry In tm.Recipients
                Select Case recip.ContactType
                    Case AddressBookEntryType.TrulyMail
                        If trulyMailContactEmailAddress.Length > 0 Then
                            Select Case recip.RecipientType
                                Case RecipientType.Send_To
                                    msg.AddTo(trulyMailContactEmailAddress, recip.FullName)
                                Case RecipientType.Send_CC
                                    msg.AddCc(trulyMailContactEmailAddress, recip.FullName)
                                Case RecipientType.Send_BCC
                                    msg.AddBcc(trulyMailContactEmailAddress) '-- not sure about this but I don't see a way to put the name in
                            End Select
                        End If

                    Case AddressBookEntryType.Email
                        Select Case recip.RecipientType
                            Case RecipientType.Send_To
                                msg.AddTo(recip.Address, recip.FullName)
                            Case RecipientType.Send_CC
                                msg.AddCc(recip.Address, recip.FullName)
                            Case RecipientType.Send_BCC
                                msg.AddCc(recip.Address, recip.FullName)
                        End Select
                End Select
            Next

            If tm.Attachments.Count > 0 Then
                For Each item As AttachmentItem In tm.Attachments
                    If System.IO.File.Exists(item.Filename) Then
                        msg.AddAttachment(item.Filename)
                    End If
                Next
            End If

            If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(emlFilename)) Then
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(emlFilename))
            End If
            msg.ValidateAddress = False
            msg.SaveToFile(emlFilename, True)
            Return True
        Catch ex As Exception
            Log(ex)
            '-- just log and continue
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Returns the full path of the first found file matching the filename, under the messagestore folder
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetFullPathToFile(ByVal filename As String) As String
        Try
            Dim files() As String = System.IO.Directory.GetFiles(MessageStoreRootPath, filename, IO.SearchOption.AllDirectories)
            If files.Length > 0 Then
                Return files(0)
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Log(ex)
            Return String.Empty
        End Try
    End Function
   
    Friend Function AspectToStringConverterDate(ByVal d As Date) As String
        If d.Date = Date.Today Then
            Return d.ToShortTimeString
        Else
            Return d.ToShortDateString & " " & d.ToShortTimeString
        End If
    End Function
    ''' <summary>
    ''' Returns true if text contains &gt; and &lt; (escaped HTML codes)
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function IsHTML(text As String) As Boolean
        Dim strWorking As String = text.ToLower()
        If strWorking.Contains("&lt;") AndAlso strWorking.Contains("&gt;") Then
            '-- seems to contain escaped html
            Return True
        Else
            '-- using simple tag (only check for open, not close) because some quote in some rss feeds were causing problems with the other regex
            Dim strRegex As String = "<[^>]+>" '--"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>"
            If System.Text.RegularExpressions.Regex.IsMatch(strWorking, strRegex, System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then
                '-- contains at least one html-like tag
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Friend Function IsNewsletterMode(filename As String) As Boolean
        Try
            Dim xDoc As New Xml.XmlDocument
            xDoc.Load(filename)
            Dim xRecipients As Xml.XmlElement = xDoc.SelectSingleNode("//" & MESSAGE_ATTRIBUTE_NAME_RECIPIENTS)
            If xRecipients IsNot Nothing Then
                Return ConvertToBool(xRecipients.GetAttribute(MESSAGE_ATTRIBUTE_NAME_NEWSLETTERMODE), False)
            Else
                Return False
            End If
        Catch ex As Exception
            Log(ex)
            Return False
        End Try
    End Function
    Friend Sub CreateNewProcessingRule(rule As ProcessingRule, parentform As Form)
        Dim frm As New ProcessRulesForm()
        frm.Show(parentform)
        frm.BringToFront()
        Dim frm2 As New EditProcessingRuleForm(rule)
        frm2.ShowDialog(frm)
    End Sub

    Public Function GetBaseSubject(ByVal subject As String) As String
        Dim boolChangeMade As Boolean
        Dim strSubject As String = subject.Trim.ToLower()
        Do
            boolChangeMade = False

            If strSubject.StartsWith(SUBJECT_PREFIX_REPLY.ToLower()) Then
                strSubject = strSubject.Substring(SUBJECT_PREFIX_REPLY.Length).Trim()
                boolChangeMade = True
            End If

            If strSubject.StartsWith(SUBJECT_PREFIX_FORWARD.ToLower()) Then
                strSubject = strSubject.Substring(SUBJECT_PREFIX_FORWARD.Length).Trim()
                boolChangeMade = True
            End If

            If strSubject.StartsWith(SUBJECT_PREFIX_FOLLOWUP.ToLower()) Then
                strSubject = strSubject.Substring(SUBJECT_PREFIX_FOLLOWUP.Length).Trim()
                boolChangeMade = True
            End If

            If strSubject.StartsWith(SUBJECT_PREFIX_RESEND.ToLower()) Then
                strSubject = strSubject.Substring(SUBJECT_PREFIX_RESEND.Length).Trim()
                boolChangeMade = True
            End If

            '-- since some email clients use 'fw:' instead of 'fwd:' we should include it here
            Const SUBJECT_PREFIX_FORWARD2 As String = "fw:"
            If strSubject.StartsWith(SUBJECT_PREFIX_FORWARD2) Then
                strSubject = strSubject.Substring(SUBJECT_PREFIX_FORWARD2.Length).Trim()
                boolChangeMade = True
            End If
        Loop While boolChangeMade

        If strSubject.EndsWith(" ...") Then
            strSubject = strSubject.Substring(0, strSubject.Length - 4).Trim()
        ElseIf strSubject.EndsWith("...") Then
            strSubject = strSubject.Substring(0, strSubject.Length - 3).Trim()
        End If

        Return strSubject

    End Function
    Public Function GetZipContentFileText(filename As String) As String
        Dim strText As String

        Using zip As New Ionic.Zip.ZipFile(filename)
            Dim ms As New System.IO.MemoryStream()
            zip.Item(0).Extract(ms)
            ms.Position = 0

            Using sr As System.IO.StreamReader = New System.IO.StreamReader(ms)
                strText = sr.ReadToEnd()
                sr.Close()
                ms.Close()
            End Using
        End Using

        Return strText
    End Function
    Public Sub SeedInitialMessages()
        '-- copy over the welcome and getting started messages for this user
        '   but only if there are no messages in this user's inbox
        If System.IO.Directory.GetFiles(InBoxRootPath).Length = 0 Then
            Dim strDefaultDataPath As String = System.IO.Path.GetDirectoryName(GetEXEFullPath()) & "\DefaultData"
            Dim strDefaultInBoxPath As String = QualifyPath(strDefaultDataPath) & "Messages\" & INBOX_NAME
            strDefaultInBoxPath = QualifyPath(strDefaultInBoxPath)
            Dim strDefaultAttachmentsPath As String = QualifyPath(strDefaultDataPath) & ATTACHMENTS_FOLDER_NAME
            strDefaultAttachmentsPath = QualifyPath(strDefaultAttachmentsPath)

            Dim files() As String = System.IO.Directory.GetFiles(strDefaultInBoxPath, "*" & MESSAGE_FILENAME_EXTENSION)
            Dim strNewFilename As String
            For Each strFilename As String In files
                strNewFilename = InBoxRootPath & System.IO.Path.GetFileName(strFilename)
                If Not System.IO.File.Exists(strNewFilename) Then
                    '-- copy over message
                    System.IO.File.Copy(strFilename, strNewFilename)

                    ''-- Update default data
                    'UpdateDataInDefaultMessage(strNewFilename)

                    '-- copy over attachments, if any, for this message
                    Dim strOldDirectory As String = QualifyPath(strDefaultAttachmentsPath) & System.IO.Path.GetFileNameWithoutExtension(strFilename)
                    Dim strNewDirectory As String = AttachmentsRootPath & System.IO.Path.GetFileNameWithoutExtension(strFilename)
                    If System.IO.Directory.Exists(strOldDirectory) Then
                        CopyDirectory(strOldDirectory, strNewDirectory)
                    End If
                End If
            Next
        End If
    End Sub
    ''' <summary>
    ''' Will return true if there is any network (not necessarily internet access)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsInternetAvailable() As Boolean
        Dim boolReturn As Boolean
        Dim arr() As System.Net.NetworkInformation.NetworkInterface = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
        For Each interf As System.Net.NetworkInformation.NetworkInterface In arr
            If Not interf.Description.ToLower.StartsWith("vmware virtual") AndAlso Not interf.Description.StartsWith("Software Loopback") Then
                'MsgBox(interf.Description & " ~ " & interf.OperationalStatus.ToString())
                If interf.OperationalStatus = Net.NetworkInformation.OperationalStatus.Up Then
                    boolReturn = True
                    Exit For
                End If
            End If
        Next

        Return boolReturn
    End Function

    Public Function RunningUnderWine() As Boolean
        Dim key As Microsoft.Win32.RegistryKey
        key = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Default).OpenSubKey("Software\Wine")
        If key Is Nothing Then
            Return False
        ElseIf key.GetSubKeyNames.Count = 0 Then
            key.Close()
            Return False
        Else
            key.Close()
            Return True
        End If
    End Function
    Public Function UseFallbackModeNow() As Boolean
        Select Case AppSettings.UseFallbackModeWhen
            Case UseFallbackModeEnum.Always
                Return True
            Case UseFallbackModeEnum.Never
                Return False
            Case UseFallbackModeEnum.UnderWine
                Return RunningUnderWine()
        End Select
    End Function
End Module