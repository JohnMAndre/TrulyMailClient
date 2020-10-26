Imports System.Security.Cryptography

Module Crypto


    Private Const ENCRYPTION_KEY_SIZE As Integer = 4096
    Private Const SIGNATURE_XML_OPEN As String = "<signature>"
    Private Const SIGNATURE_XML_CLOSED As String = "</signature>"
    Private Const UNENCRYPTED_KEY_STARTSWITH As String = "<RSAKeyValue>"

    Private Function GetEncryptionEncoder() As System.Text.Encoding
        Return New System.Text.UTF8Encoding()
    End Function
    Friend Function ArraysMatch(ByVal a() As Byte, ByVal b() As Byte) As Boolean
        If a.Length <> b.Length Then
            Return False
        Else
            Dim boolReturn As Boolean = True '-- assume they match
            Dim intCounterMax As Integer = a.Length - 1
            For intCounter As Integer = 0 To intCounterMax
                If a(intCounter) <> b(intCounter) Then
                    boolReturn = False
                    Exit For
                End If
            Next
            Return boolReturn
        End If
    End Function
    Public Function ContactKeyExists(ByVal userID As String) As Boolean
        Dim strFilename As String = EncryptionKeyRootPath & userID & KEY_FILENAME_EXTENSION
        Return System.IO.File.Exists(strFilename)
    End Function
    
    
#Region " TM2TM Logic "

    Public HEADER_TM2TM As String = "------- TM2TM ENCRYPTED MESSAGE START -------" & Environment.NewLine
    Public FOOTER_TM2TM As String = Environment.NewLine & "------- TM2TM ENCRYPTED MESSAGE END -------"
    Private Const SUBJECT_BODY_SEPARATER As String = "###!!!SUBJECT_SEPARATER!!!###"
    Private Const TM2TMLEADING_PADDING_LENGTH As Integer = 4 '-- how many random characters there are to create unique cyphertext every time
    Friend Function EncryptBodyForTM2TM(ByVal encryptionKey As String, ByVal body As String, ByVal subject As String) As String
        Try
            '-- Here we combine body and subject then wrap in the indicators
            '   We are going to add on 4 random leading characters into what gets encrypted so the same 2 messages will actually be quite different
            Dim strRandom As String = GenerateAlphanumericString(TM2TMLEADING_PADDING_LENGTH)
            Dim strPlainText As String = strRandom & subject & SUBJECT_BODY_SEPARATER & body

            Dim crypto As New TrulyMail.Cryptography.CryptographyFunctions()
            Dim strEncrypted As String = ENCRYPTION_2_SYMMETRIC_IDENTIFIER & crypto.EncryptStringSymetric1(strPlainText, encryptionKey)
            Return HEADER_TM2TM & strEncrypted & FOOTER_TM2TM

        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Function
    Public Class TM2TMMessageContents
        Public Property Subject As String
        Public Property Body As String
    End Class
    Friend Function DecryptBodyForTM2TM(ByVal encryptionKey As String, ByVal message As String) As TM2TMMessageContents
        Try
            Dim strDecrypted As String
            strDecrypted = message.Substring(message.IndexOf(HEADER_TM2TM) + HEADER_TM2TM.Length, message.IndexOf(FOOTER_TM2TM) - (HEADER_TM2TM.Length))
            strDecrypted = DecryptTextSymetric(encryptionKey, strDecrypted)
            strDecrypted = strDecrypted.Substring(TM2TMLEADING_PADDING_LENGTH)

            '-- Here we combine body and subject then wrap in the indicators
            Dim objMsg As New TM2TMMessageContents()
            objMsg.Subject = strDecrypted.Substring(0, strDecrypted.IndexOf(SUBJECT_BODY_SEPARATER))
            objMsg.Body = strDecrypted.Substring(strDecrypted.IndexOf(SUBJECT_BODY_SEPARATER) + SUBJECT_BODY_SEPARATER.Length)

            Return objMsg
        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Function
#End Region
    ''' <summary>
    ''' Returns the name of a temporary file which is an encrypted version of the file passed in 
    ''' </summary>
    ''' <param name="encryptionKey"></param>
    ''' <param name="filename">Full path to the file to encrypt</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function EncryptFile(ByVal encryptionKey As String, ByVal filename As String, Optional ByVal overrideEncryptionVersion As Integer = -1, Optional destinationFilename As String = "") As String
        Try
            Dim strEncryptedFilename As String
            If destinationFilename.Length = 0 Then
                strEncryptedFilename = GetTempFilename()
            Else
                strEncryptedFilename = destinationFilename
            End If

            Dim objCrypto As New TrulyMail.Cryptography.CryptographyFunctions()
            Select Case overrideEncryptionVersion '-- first, base on override passed in
                Case 0
                    objCrypto.EncryptFileSymetric(encryptionKey, filename, strEncryptedFilename)
                Case 1
                    objCrypto.EncryptFileSymetric1(encryptionKey, filename, strEncryptedFilename)
                    'Case 2
                    '    '-- New for 4.0
                    '    EncryptFileLocal(encryptionKey, iv, filename, strEncryptedFilename)
                Case Else '-- override not passed in, so use the appsettings
                    Select Case AppSettings.EncryptionVersion
                        Case 0
                            objCrypto.EncryptFileSymetric(encryptionKey, filename, strEncryptedFilename)
                        Case 1
                            objCrypto.EncryptFileSymetric1(encryptionKey, filename, strEncryptedFilename)
                            'Case 2
                            '    EncryptFileLocal(encryptionKey, iv, filename, strEncryptedFilename)
                    End Select
            End Select
            Return strEncryptedFilename
        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="encryptionKey"></param>
    ''' <param name="plainText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function EncryptTextSymetric(ByVal encryptionKey As String, ByVal plainText As String, Optional ByVal version As EncryptionLevelEnum = EncryptionLevelEnum.Unknown) As String
        Try
            '-- Changed in TMv5.1     

            Dim cryptoVersion As EncryptionLevelEnum = version

            '-- Need to get the right encryption version
            If cryptoVersion = EncryptionLevelEnum.Unknown Then
                '-- Caller said nothing so we must default to something (will default to Version5Strong)
                Select Case AppSettings.EncryptionVersion
                    Case 0
                        '-- Set to old TMv3 encryption level
                        '-- Should not use (too old) so set to Version5Strong
                        cryptoVersion = EncryptionLevelEnum.Version5Strong
                    Case 1
                        '-- Set to TMv4 encryption level
                        '-- Upgrading to StrongVersion5 (which is actually the same as Version4)
                        cryptoVersion = EncryptionLevelEnum.Version5Strong
                    Case Else
                        '-- Not set or bad setting
                        '-- Set to StrongVersion5 because that is a safe (but slow) default.
                        '   If caller wants speed (including for decryption) then they can pass in FastVersion5
                        cryptoVersion = EncryptionLevelEnum.Version5Strong
                End Select
            End If

            '-- Now encrypt based on the encryption version
            Select Case cryptoVersion
                Case EncryptionLevelEnum.Unknown
                    '-- Should NEVER get here
                    Application.DoEvents()
                Case EncryptionLevelEnum.Version3
                    '-- get here means old code: fix it
                    Application.DoEvents()
                    Dim crypto As New TrulyMail.Cryptography.CryptographyFunctions()
                    Return crypto.EncryptStringSymetric(plainText, encryptionKey)
                Case EncryptionLevelEnum.Version4
                    '-- get here means old code: fix it
                    Application.DoEvents()
                    Dim crypto As New TrulyMail.Cryptography.CryptographyFunctions()
                    Return ENCRYPTION_1_SYMMETRIC_IDENTIFIER & crypto.EncryptStringSymetric1(plainText, encryptionKey)
                Case EncryptionLevelEnum.Version5Strong
                    Dim crypto As New CryptographyFunctions()
                    Return ENCRYPTION_5STRONG_SYMMETRIC_IDENTIFIER & crypto.EncryptStringSymetricVersion5Strong(plainText, encryptionKey)
                Case EncryptionLevelEnum.Version5Fast
                    Dim crypto As New CryptographyFunctions()
                    Return ENCRYPTION_5FAST_SYMMETRIC_IDENTIFIER & crypto.EncryptStringSymetricVersion5Fast(plainText, encryptionKey)
            End Select
        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="encryptionKey"></param>
    ''' <param name="cypherText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function DecryptTextSymetric(ByVal encryptionKey As String, ByVal cypherText As String) As String
        Try
            Dim strReturn As String

            Select Case cypherText.Substring(0, 1)
                Case ENCRYPTION_1_SYMMETRIC_IDENTIFIER
                    Dim crypto As New TrulyMail.Cryptography.CryptographyFunctions()
                    strReturn = crypto.DecryptStringSymetric1(cypherText.Substring(1), encryptionKey)
                Case ENCRYPTION_2_SYMMETRIC_IDENTIFIER
                    Dim crypto As New TrulyMail.Cryptography.CryptographyFunctions()
                    strReturn = crypto.DecryptStringSymetric1(cypherText.Substring(1), encryptionKey)
                Case ENCRYPTION_5STRONG_SYMMETRIC_IDENTIFIER
                    Dim crypto As New CryptographyFunctions()
                    strReturn = crypto.DecryptStringSymetricVersion5Strong(cypherText.Substring(1), encryptionKey)
                Case ENCRYPTION_5FAST_SYMMETRIC_IDENTIFIER
                    Dim crypto As New CryptographyFunctions()
                    strReturn = crypto.DecryptStringSymetricVersion5Fast(cypherText.Substring(1), encryptionKey)
                Case Else
                    '-- Must be something old (TMv3 or before)
                    Dim crypto As New TrulyMail.Cryptography.CryptographyFunctions()
                    strReturn = crypto.DecryptStringSymetric(cypherText, encryptionKey)
            End Select

            Return strReturn
        Catch ex As System.FormatException
            Log(ex)
            Log("cypherText: " & cypherText)
            Throw ex
        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Throws an error if signature failed, otherwise, returns decrypted text
    ''' </summary>
    ''' <param name="cipherText"></param>
    ''' <param name="privateKey"></param>
    ''' <param name="publicKey"></param>
    ''' <returns></returns>
    ''' <remarks>Added in 3.0.20 to support Chinese Windows and to replace the TrulyMail.Cryptography component</remarks>
    'Private Function DecryptAndAuthenticateText(ByVal cipherText As String, ByVal privateKey As String, ByVal publicKey As String) As String
    '    Try
    '        ' Use Private Key to Decrypt 
    '        Dim encoder As System.Text.Encoding = GetEncryptionEncoder()

    '        Dim strPlainText As String = ""
    '        Dim bytPlain(0) As Byte
    '        Dim intPlainLength As Integer = 0
    '        Dim bytCipherMain() As Byte = Convert.FromBase64String(cipherText)

    '        Using objRSA As New System.Security.Cryptography.RSACryptoServiceProvider(ENCRYPTION_KEY_SIZE)
    '            objRSA.FromXmlString(privateKey)

    '            ' When decrypting, if the EncryptedText string > Modulus size, it will be split into segments of size equal to Modulus Size
    '            ' Each of these EncryptedText segments will be decrypted individually with the resulting PlainText segments re-assembled.

    '            Dim intBlockSize As Integer = (ENCRYPTION_KEY_SIZE / 8)
    '            Dim bytThisPass() As Byte
    '            Dim bytCipherThisPass() As Byte
    '            ReDim bytCipherThisPass(intBlockSize - 1)

    '            Dim intProcessedBytesPlain, intProcessedBytesCipher As Integer
    '            While intProcessedBytesCipher < bytCipherMain.Length
    '                For intCounter = 0 To intBlockSize - 1
    '                    If bytCipherMain.Length - 1 >= (intCounter + intProcessedBytesCipher) Then
    '                        bytCipherThisPass(intCounter) = bytCipherMain(intCounter + intProcessedBytesCipher)
    '                    Else
    '                        bytCipherThisPass(intCounter) = 0 '-- padding... should never hit this line
    '                    End If
    '                Next
    '                bytThisPass = objRSA.Decrypt(bytCipherThisPass, False)

    '                ReDim Preserve bytPlain(intPlainLength + bytThisPass.Length - 1)
    '                intPlainLength = bytPlain.Length

    '                For intCounter = 0 To bytThisPass.Length - 1
    '                    bytPlain(intCounter + intProcessedBytesPlain) = bytThisPass(intCounter)
    '                Next
    '                intProcessedBytesPlain += bytThisPass.Length
    '                intProcessedBytesCipher += bytCipherThisPass.Length
    '            End While

    '        End Using
    '        Dim strPlain As String = encoder.GetString(bytPlain)

    '        '-- Now, verify signature
    '        Using objRSA As New System.Security.Cryptography.RSACryptoServiceProvider(ENCRYPTION_KEY_SIZE)
    '            objRSA.FromXmlString(publicKey)

    '            'Strip Signature from message and use it to validate message
    '            Dim intStartPosition As Integer = strPlain.ToLower().IndexOf(SIGNATURE_XML_OPEN)
    '            Dim strSignatureData As String = strPlain.Substring(intStartPosition)
    '            strSignatureData = Replace(strSignatureData, SIGNATURE_XML_OPEN, String.Empty)
    '            strSignatureData = Replace(strSignatureData, SIGNATURE_XML_CLOSED, String.Empty)
    '            strPlain = strPlain.Substring(0, intStartPosition)

    '            If strSignatureData <> "" Then
    '                Dim bytSig() As Byte = Convert.FromBase64String(strSignatureData)

    '                If objRSA.VerifyData(encoder.GetBytes(strPlain), System.Security.Cryptography.HashAlgorithm.Create(), bytSig) Then
    '                    '-- everything is good
    '                Else
    '                    Throw New Exception("Message authentication failed.")
    '                End If
    '            Else
    '                Throw New Exception("Digital signature is missing or not formatted properly.")
    '            End If
    '        End Using

    '        Return strPlain
    '    Catch ex As Exception
    '        Log(ex)
    '        Throw ex
    '    End Try
    'End Function
   
    ''' <summary>
    ''' Decrypts using NEW RIJN256 and if that fails, tries again using OLD RIJN256
    ''' </summary>
    ''' <param name="encryptionKey"></param>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function DecryptFile1(ByVal encryptionKey As String, ByVal filename As String, Optional destinationFilename As String = "") As String
        '-- Added in version 3.0
        Try
            Dim strDecryptedFilename As String
            If destinationFilename.Length = 0 Then
                strDecryptedFilename = GetTempFilename()
            Else
                strDecryptedFilename = destinationFilename
            End If

            Dim objCrypto As New TrulyMail.Cryptography.CryptographyFunctions()
            Try
                '-- new RIJN256
                objCrypto.DecryptFileSymetric1(encryptionKey, filename, strDecryptedFilename)
            Catch ex As Exception
                '-- old RIJN256
                objCrypto.DecryptFileSymetric(encryptionKey, filename, strDecryptedFilename)
            End Try

            Return strDecryptedFilename
        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try
    End Function
    'Friend Function KeysProperlySetup() As Boolean
    '    Try
    '        Dim boolPublicKeyPresent As Boolean = System.IO.File.Exists(GetMyPublicKeyFilename)
    '        Dim boolPrivateKeyPresent As Boolean = System.IO.File.Exists(GetMyPrivateKeyFilename)
    '        If Not boolPublicKeyPresent OrElse Not boolPrivateKeyPresent Then
    '            '-- no key pair for self
    '            Log("Problem with keys. Public key present: " & boolPublicKeyPresent.ToString() & ". Private key present: " & boolPrivateKeyPresent.ToString() & ".")

    '            Return False
    '        Else
    '            '-- Load keys from local file
    '            MyKeyPair = New TrulyMail.Cryptography.KeyPair()
    '            MyKeyPair.PublicKey = New TrulyMail.Cryptography.Key
    '            MyKeyPair.PublicKey.KeyType = Cryptography.Key.KeyTypeEnum.PublicKey
    '            MyKeyPair.PublicKey.Key = System.IO.File.ReadAllText(GetMyPublicKeyFilename())
    '            MyKeyPair.PrivateKey = New TrulyMail.Cryptography.Key
    '            MyKeyPair.PrivateKey.KeyType = Cryptography.Key.KeyTypeEnum.PrivateKey
    '            Dim strPrivateKey As String = System.IO.File.ReadAllText(GetMyPrivateKeyFilename())
    '            If strPrivateKey.StartsWith(UNENCRYPTED_KEY_STARTSWITH) Then
    '                '-- key is not encrypted (likely from 2.x) so encrypt it now
    '                MyKeyPair.PrivateKey.Key = strPrivateKey
    '                WritePrivateKey(False, EncryptionPassword) '-- do not allow unencrypted private key to be backed up
    '            Else
    '                '-- decrypt
    '                strPrivateKey = DecryptTextSymetric(EncryptionPassword, strPrivateKey)
    '                MyKeyPair.PrivateKey.Key = strPrivateKey
    '            End If

    '            Return True
    '        End If
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
    'Friend Function GetMyPublicKeyFilename() As String
    '    Return EncryptionKeyRootPath & PUBLIC_KEY_FILENAME
    'End Function
    'Friend Function GetMyPrivateKeyFilename() As String
    '    Return EncryptionKeyRootPath & PRIVATE_KEY_FILENAME
    'End Function
#Region " Key Generator "
    Public Function GetRSA() As System.Security.Cryptography.RSACryptoServiceProvider
        Dim objCspParameters As System.Security.Cryptography.CspParameters = New System.Security.Cryptography.CspParameters()

        objCspParameters.Flags = System.Security.Cryptography.CspProviderFlags.UseArchivableKey
        Dim objRSA As New System.Security.Cryptography.RSACryptoServiceProvider(ENCRYPTION_KEY_SIZE, objCspParameters)

        Return objRSA
    End Function

    Public Function MakeKeyPair() As TrulyMail.Cryptography.KeyPair
        Using objRSA As System.Security.Cryptography.RSA = GetRSA()
            Dim objPublicKey As TrulyMail.Cryptography.Key = New TrulyMail.Cryptography.Key()
            Dim objPrivateKey As TrulyMail.Cryptography.Key = New TrulyMail.Cryptography.Key()
            Dim objKeyPair As New TrulyMail.Cryptography.KeyPair()

            objPublicKey.KeyType = TrulyMail.Cryptography.Key.KeyTypeEnum.PublicKey
            objPublicKey.Key = objRSA.ToXmlString(False)
            objKeyPair.PublicKey = objPublicKey

            objPrivateKey.KeyType = TrulyMail.Cryptography.Key.KeyTypeEnum.PrivateKey
            objPrivateKey.Key = objRSA.ToXmlString(True)
            objKeyPair.PrivateKey = objPrivateKey

            Return objKeyPair

            objPublicKey = Nothing
            objPrivateKey = Nothing
            objKeyPair = Nothing
        End Using
    End Function
#End Region
    'Friend Sub SetupKeys(ByVal allowKeyKeyArchiving As Boolean)
    '    Try
    '        Log("Setting up keys.")
    '        MyKeyPair = MakeKeyPair()
    '        SaveEncryptionKey("public", MyKeyPair.PublicKey.Key)
    '        WritePrivateKey(True, EncryptionPassword)
    '        Log("Setting up keys complete.")
    '        Application.DoEvents()
    '        Log("Testing keys.")
    '        If KeysProperlySetup() Then
    '            Log("Keys appear to be setup properly.")
    '        Else
    '            Log("Keys not setup properly.")
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub
    'Friend Sub WritePrivateKey(ByVal allowKeyKeyArchiving As Boolean, ByVal decryptionKey As String)
    '    Try
    '        Dim strFilename As String = GetMyPrivateKeyFilename()
    '        Dim strKeyToWrite As String = MyKeyPair.PrivateKey.Key
    '        Dim boolUnencryptedKeyFound As Boolean

    '        If System.IO.File.Exists(strFilename) Then
    '            Dim strEncryptedCurrentPrivateKey As String = System.IO.File.ReadAllText(strFilename)
    '            Dim strUnencryptedCurrentPrivateKey As String
    '            If strEncryptedCurrentPrivateKey.StartsWith(UNENCRYPTED_KEY_STARTSWITH) Then
    '                strUnencryptedCurrentPrivateKey = strEncryptedCurrentPrivateKey
    '                boolUnencryptedKeyFound = True
    '            Else
    '                strUnencryptedCurrentPrivateKey = DecryptTextSymetric(decryptionKey, strEncryptedCurrentPrivateKey)
    '            End If

    '            Dim boolKeyChanged As Boolean = Not (strUnencryptedCurrentPrivateKey = strKeyToWrite)

    '            '-- test if key changed, if it's unencrypted, or if the encryption key (startup password) changed
    '            If (Not boolKeyChanged) AndAlso (Not boolUnencryptedKeyFound) AndAlso (decryptionKey = EncryptionPassword) Then
    '                '-- Key is unchanged and is already encrypted
    '                Log("Private key unchanged.")
    '            Else
    '                strKeyToWrite = EncryptTextSymetric(EncryptionPassword, strKeyToWrite)

    '                If allowKeyKeyArchiving AndAlso boolKeyChanged Then
    '                    '-- rename existing file to archive key
    '                    Dim strArchiveFilename As String = GetNewArchiveKeyFilename(strFilename)
    '                    Log("Archiving key: " & strArchiveFilename)
    '                    System.IO.File.Move(strFilename, strArchiveFilename)
    '                End If

    '                System.IO.File.WriteAllText(strFilename, strKeyToWrite)
    '            End If
    '        Else
    '            strKeyToWrite = EncryptTextSymetric(EncryptionPassword, strKeyToWrite)
    '            System.IO.File.WriteAllText(strFilename, strKeyToWrite)
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    ''' <summary>
    ''' Opens all archived private keys and writes back encrypted with current master password
    ''' </summary>
    ''' <remarks></remarks>
    'Friend Sub UpdateAllPrivateKeys(ByVal previousMasterPassword As String)
    '    Dim strEncryptedContents, strUnencryptedContents As String

    '    '-- Get all archived private keys (all will be encrypted with the same key)
    '    Dim files() As String = System.IO.Directory.GetFiles(EncryptionKeyRootPath, "private.*.key")
    '    For Each strFilename As String In files
    '        '-- Get encrypted contents
    '        strEncryptedContents = System.IO.File.ReadAllText(strFilename)

    '        '-- Decrypt the key in the file, using the old master password
    '        strUnencryptedContents = DecryptTextSymetric(previousMasterPassword, strEncryptedContents)

    '        '-- re-encrypt the key with the current master password
    '        strEncryptedContents = EncryptTextSymetric(EncryptionPassword, strUnencryptedContents)

    '        '-- Write it back to the original file
    '        System.IO.File.WriteAllText(strFilename, strEncryptedContents)
    '    Next

    '    '-- write out current private key
    '    WritePrivateKey(True, previousMasterPassword)
    'End Sub
    'Friend Function UserKeyExists(ByVal userID As String) As Boolean
    '    Dim strFilename As String = EncryptionKeyRootPath & userID & KEY_FILENAME_EXTENSION
    '    If System.IO.File.Exists(strFilename) Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function
    'Private Function GetNewArchiveKeyFilename(ByVal baseFilename As String) As String
    '    Dim strDate As String = Date.UtcNow.ToString(DATEFORMAT_FILENAME)
    '    Dim strArchiveFilename As String = EncryptionKeyRootPath & System.IO.Path.GetFileNameWithoutExtension(baseFilename) & "." & strDate & KEY_FILENAME_EXTENSION
    '    Do Until Not System.IO.File.Exists(strArchiveFilename)
    '        strDate = Date.UtcNow.ToString(DATEFORMAT_FILENAME)
    '        strArchiveFilename = EncryptionKeyRootPath & System.IO.Path.GetFileNameWithoutExtension(baseFilename) & "." & strDate & KEY_FILENAME_EXTENSION
    '        Log("Changing archiving key filename: " & strArchiveFilename)
    '    Loop
    '    Return strArchiveFilename
    'End Function
    'Friend Sub SaveEncryptionKey(ByVal contactID As String, ByVal key As String)
    '    Dim strFilename As String = EncryptionKeyRootPath & contactID & KEY_FILENAME_EXTENSION
    '    If System.IO.File.Exists(strFilename) Then
    '        Dim strCurrentKey As String = System.IO.File.ReadAllText(strFilename)

    '        If strCurrentKey = key Then '-- found string and hash comparison both take zero seconds, so go with the safer option
    '            '-- no reason to update key, it is the same as what is currently stored
    '            Log("Unchanged key ignored for contact: " & contactID)
    '        Else
    '            '-- rename existing file to archive key
    '            Dim strArchiveFilename As String = GetNewArchiveKeyFilename(strFilename)
    '            Log("Archiving key: " & strArchiveFilename)
    '            System.IO.File.Move(strFilename, strArchiveFilename)
    '        End If
    '    End If

    '    '-- Write out current key
    '    System.IO.File.WriteAllText(strFilename, key)
    'End Sub


    Public Enum PasswordScore
        Blank = 0
        VeryWeak = 1
        Weak = 2
        Medium = 3
        Strong = 4
        VeryStrong = 5
        Ideal = 6
    End Enum
    Public Function CheckPasswordStrength(ByVal password As String) As PasswordScore

        Dim score As Int32 = 1

        If password.Length = 0 Then
            Return PasswordScore.Blank
        End If

        If password.Length >= 1 Then
            score += 1
        End If
        If password.Length >= 8 Then
            score += 1
        End If
        If password.Length >= 18 Then
            score += 1
        End If
        If System.Text.RegularExpressions.Regex.IsMatch(password, "\d+") AndAlso (System.Text.RegularExpressions.Regex.IsMatch(password, "[a-z]") OrElse System.Text.RegularExpressions.Regex.IsMatch(password, "[A-Z]")) Then
            '-- at least one number and one letter (upper or lower)
            score += 1
        End If
        If System.Text.RegularExpressions.Regex.IsMatch(password, "[a-z]") AndAlso System.Text.RegularExpressions.Regex.IsMatch(password, "[A-Z]") Then
            '-- at least one upper and one lower
            score += 1
        End If
        If System.Text.RegularExpressions.Regex.IsMatch(password, "[!@#\$%\^&\*\?_~\-\(\);\.\+:]+") Then
            '-- at least one special char
            score += 1
        End If

        score = Math.Min(score, 6)

        '-- This is to calculate the number of possibilities (guage for cracking through brute-force
        'Dim lngPossibilities As Long
        'If System.Text.RegularExpressions.Regex.IsMatch(password, "\d+") Then
        '    '-- digits give 10 possibilities for each position
        '    lngPossibilities += 10
        'End If
        'If System.Text.RegularExpressions.Regex.IsMatch(password, "[a-z]") Then
        '    '-- lower-case letters give 26 more possibilities for each position
        '    lngPossibilities += 26
        'End If
        'If System.Text.RegularExpressions.Regex.IsMatch(password, "[A-Z]") Then
        '    '-- upper-case letters give 26 more possibilities for each position
        '    lngPossibilities += 26
        'End If
        'If System.Text.RegularExpressions.Regex.IsMatch(password, "[!@#\$%\^&\*\?_~\-\(\);\.\+:]+") Then
        '    '-- special characters give 18 more possibilities for each position
        '    lngPossibilities += 18
        'End If

        'lngPossibilities *= password.Length


        Return CType(score, PasswordScore)

    End Function

    Public Sub SetPasswordStrengthLabel(passwordText As String, strengthCaption As Label, strength As Label)
        Select Case CheckPasswordStrength(passwordText)
            Case PasswordScore.Blank
                strengthCaption.Visible = False
                strength.Visible = False
            Case PasswordScore.VeryWeak
                strengthCaption.Visible = True
                strength.Visible = True
                strength.Text = "Very weak"
                strength.ForeColor = Color.DarkRed
            Case PasswordScore.Weak
                strengthCaption.Visible = True
                strength.Visible = True
                strength.Text = "Weak"
                strength.ForeColor = Color.Red
            Case PasswordScore.Medium
                strengthCaption.Visible = True
                strength.Visible = True
                strength.Text = "Medium"
                strength.ForeColor = Color.Blue
            Case PasswordScore.Strong
                strengthCaption.Visible = True
                strength.Visible = True
                strength.Text = "Strong"
                strength.ForeColor = Color.CadetBlue
            Case PasswordScore.VeryStrong
                strengthCaption.Visible = True
                strength.Visible = True
                strength.Text = "Very strong"
                strength.ForeColor = Color.Green
            Case PasswordScore.Ideal
                strengthCaption.Visible = True
                strength.Visible = True
                strength.Text = "Ideal"
                strength.ForeColor = Color.DarkGreen
        End Select
    End Sub

    Private Function DerivePassword1(ByVal originalPassword As String, ByVal passwordLength As Integer) As Byte()
        'Salt value used to encrypt a plain text key. Again, this can be whatever you like
        Dim SALT_BYTES As Byte() = New Byte() {101, 195, 22, 4, 7, 115, 88, 141, 95, 204, 41, 66, 5, 234, 85, 98, 39, 206, 249, 72, 46, 79}
        Dim derivedBytes As New Rfc2898DeriveBytes(originalPassword, SALT_BYTES, 10000)
        Return derivedBytes.GetBytes(passwordLength)
    End Function

    ''' <summary>
    ''' Takes in an email address, spits back a hash
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUgradeCode(input As String) As String
        Dim email As String = input.ToLower()
        Dim md5 As MD5 = md5.Create()
        Dim hash() As Byte = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input.ToLower()))
        Dim strReturn As String = Convert.ToBase64String(hash)
        Return strReturn
    End Function
    Public Function GenerateRandomPassword() As String
        '-- Should convert this to secure string but then you must have unsafe code
        '   which VB does not support...but perhaps can use Marshal but not sure
        '   http://stackoverflow.com/questions/1560732/is-it-possible-to-safely-get-a-securestring-value-from-vb-net
        Try
            'Dim sbReturn As New System.Text.StringBuilder(31)
            Dim rng As New System.Security.Cryptography.RNGCryptoServiceProvider()
            Dim data(31) As Byte
            rng.GetBytes(data)
            'For intLoop As Integer = 0 To data.Length - 1
            Return Convert.ToBase64String(data)
            'sbReturn.Append(Convert.ToChar(data(intLoop)))
            'Next

            'Return sbReturn.ToString()
        Catch ex As Exception
            Log(ex)
        End Try
    End Function
    ''' <summary>
    ''' Returns true if text starts with any TrulyMail encryption prefix
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsTextEncrypted(text As String) As Boolean
        Select Case text.Substring(0, 1)
            Case ENCRYPTION_1_SYMMETRIC_IDENTIFIER
                Return True
            Case ENCRYPTION_2_SYMMETRIC_IDENTIFIER
                Return True
            Case ENCRYPTION_5STRONG_SYMMETRIC_IDENTIFIER
                Return True
            Case ENCRYPTION_5FAST_SYMMETRIC_IDENTIFIER
                Return True
            Case Else
                Return False
        End Select
    End Function
End Module
