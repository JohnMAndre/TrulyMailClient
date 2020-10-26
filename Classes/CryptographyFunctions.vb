Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Public Class CryptographyFunctions

    Private Const AES_KEY_SIZE As Integer = 32 '-- 32 bytes = 256 bits
    Public Sub New()

    End Sub

#Region " Public but not used, so commented out "
    'Public Sub DecryptFileSymetric1(ByRef encryptionKey As String, ByVal filenameIn As String, ByVal filenameOut As String)

    '    Dim inpuptBytes() As Byte = System.IO.File.ReadAllBytes(filenameIn)
    '    Dim result() As Byte = DecryptSymmetric1(inpuptBytes, encryptionKey)
    '    System.IO.File.WriteAllBytes(filenameOut, result)

    '    '    '-- This uses RijndaelManaged provider with a key length of 256
    '    '    '-- these bytes are arbitrary, but the length is not
    '    '    Dim IV_16 As Byte() = New Byte() {215, 19, 156, 177, 24, 16, 207, 39, 19, 20, 84, 172, 214, 222, 231, 118}
    '    '    'Dim IV_32 As Byte() = New Byte() {215, 19, 156, 177, 24, 16, 207, 39, 19, 20, 84, 172, 214, 222, 231, 118, 39, 86, 34, 127, 58, 23, 57, 1, 47, 89, 117, 53, 43, 169, 44, 85}
    '    '    Dim realKey() As Byte = DerivePassword1(encryptionKey, 32) '-- 256 / 8 = 32
    '    '    Dim provider As New System.Security.Cryptography.RijndaelManaged()
    '    '    Using trans As ICryptoTransform = provider.CreateDecryptor(realKey, IV_16)
    '    '        Dim inpuptBytes() As Byte = System.IO.File.ReadAllBytes(filenameIn)
    '    '        Dim result() As Byte = trans.TransformFinalBlock(inpuptBytes, 0, inpuptBytes.Length)
    '    '        '-- now write out decrypted file
    '    '        System.IO.File.WriteAllBytes(filenameOut, result)
    '    '    End Using
    'End Sub
    'Public Sub DecryptFileSymetric(ByRef decryptionKey As String, ByVal filenameIn As String, ByVal filenameOut As String)
    '    '-- This uses RijndaelManaged provider with a key length of 128
    '    '-- these bytes are arbitrary, but the length is not
    '    Dim IV_16 As Byte() = New Byte() {215, 19, 156, 177, 24, 16, 207, 39, 19, 20, 84, 172, 214, 222, 231, 118}
    '    Dim realKey() As Byte = DerivePassword(decryptionKey, 16) '-- 128 / 8 = 16
    '    Dim provider As New System.Security.Cryptography.RijndaelManaged()
    '    Dim trans As ICryptoTransform = provider.CreateDecryptor(realKey, IV_16)
    '    Dim inpuptBytes() As Byte = System.IO.File.ReadAllBytes(filenameIn)
    '    Dim result() As Byte = trans.TransformFinalBlock(inpuptBytes, 0, inpuptBytes.Length)

    '    '-- now write out decrypted file
    '    System.IO.File.WriteAllBytes(filenameOut, result)

    'End Sub
    'Public Sub EncryptFileSymetric(ByVal encryptionKey As String, ByVal filenameIn As String, ByVal filenameOut As String)
    '    '-- This uses RijndaelManaged provider with a key length of 128

    '    '-- these bytes are arbitrary, but the length is not
    '    Dim IV_16 As Byte() = New Byte() {215, 19, 156, 177, 24, 16, 207, 39, 19, 20, 84, 172, 214, 222, 231, 118}
    '    ' 7 Oct 2012 ---- Dim IV_32 As Byte() = New Byte() {70, 231, 209, 174, 173, 48, 95, 81, 88, 206, 133, 165, 118, 251, 60, 247, 24, 220, 61, 172, 188, 79, 207, 39, 116, 80, 88, 237, 120, 22, 198, 192}
    '    Dim realKey() As Byte = DerivePassword(encryptionKey, 16) '-- 128 bits (only used for Version 0 encryption
    '    Dim provider As New System.Security.Cryptography.RijndaelManaged()
    '    'Dim o As New System.Security.Cryptography.
    '    Dim trans As ICryptoTransform = provider.CreateEncryptor(realKey, IV_16)
    '    Dim inpuptBytes() As Byte = System.IO.File.ReadAllBytes(filenameIn)

    '    Dim result() As Byte = trans.TransformFinalBlock(inpuptBytes, 0, inpuptBytes.Length)
    '    provider.Clear()
    '    trans.Dispose()

    '    '-- now write out encrypted file
    '    System.IO.File.WriteAllBytes(filenameOut, result)

    'End Sub
    'Public Sub EncryptFileSymetric1(ByVal encryptionKey As String, ByVal filenameIn As String, ByVal filenameOut As String)
    '    Dim inpuptBytes() As Byte = System.IO.File.ReadAllBytes(filenameIn)
    '    Dim result() As Byte = EncryptSymmetric1(inpuptBytes, encryptionKey)
    '    System.IO.File.WriteAllBytes(filenameOut, result)

    'End Sub

#End Region
#Region " Private stuff "
    Private Function EncryptSymmetric1(ByVal bytesIn() As Byte, ByVal encryptionKey As String) As Byte()
        '-- This uses RijndaelManaged provider with a key length of 256
        '-- these bytes are arbitrary, but the length is not
        Dim IV_16 As Byte() = New Byte() {215, 19, 156, 177, 24, 16, 207, 39, 19, 20, 84, 172, 214, 222, 231, 118}
        Dim realKey() As Byte = DerivePassword1(encryptionKey, 32) '-- 256 / 8 = 32
        Dim provider As New System.Security.Cryptography.RijndaelManaged()
        'provider.Mode=
        'provider.Padding = PaddingMode.PKCS7
        'provider.GenerateIV
        Using trans As ICryptoTransform = provider.CreateEncryptor(realKey, IV_16)
            Dim result() As Byte = trans.TransformFinalBlock(bytesIn, 0, bytesIn.Length)
            provider.Clear()
            Return result
        End Using
    End Function
    Private Function DecryptSymmetric1(ByVal bytesIn() As Byte, ByVal decryptionKey As String) As Byte()
        '-- This uses RijndaelManaged provider with a key length of 256
        '-- these bytes are arbitrary, but the length is not
        Dim IV_16 As Byte() = New Byte() {215, 19, 156, 177, 24, 16, 207, 39, 19, 20, 84, 172, 214, 222, 231, 118}
        Dim realKey() As Byte = DerivePassword1(decryptionKey, 32) '-- 256 / 8 = 32
        Dim provider As New System.Security.Cryptography.RijndaelManaged()
        Using trans As ICryptoTransform = provider.CreateDecryptor(realKey, IV_16)
            Dim result() As Byte = trans.TransformFinalBlock(bytesIn, 0, bytesIn.Length)
            Return result
        End Using
    End Function
    Private Function StripNullCharacters(ByVal vstrStringWithNulls As String) As String

        Dim intPosition As Integer
        Dim strStringWithOutNulls As String

        intPosition = 1
        strStringWithOutNulls = vstrStringWithNulls

        Do While intPosition > 0
            intPosition = InStr(intPosition, vstrStringWithNulls, vbNullChar)

            If intPosition > 0 Then
                strStringWithOutNulls = Left$(strStringWithOutNulls, intPosition - 1) & _
                                  Right$(strStringWithOutNulls, Len(strStringWithOutNulls) - intPosition)
            End If

            If intPosition > strStringWithOutNulls.Length Then
                Exit Do
            End If
        Loop

        Return strStringWithOutNulls

    End Function


    ' We use Direct Encryption (PKCS#1 v1.5) - so we require MS Windows 2000 or later with high encryption pack installed.

    '********************************************************
    '* DerivePassword: This takes the original plain text key
    '*                 and creates a secure key using SALT
    '********************************************************
    Private Function DerivePassword(ByVal originalPassword As String, ByVal passwordLength As Integer) As Byte()
        'Salt value used to encrypt a plain text key. Again, this can be whatever you like
        Dim SALT_BYTES As Byte() = New Byte() {142, 17, 138, 15, 228, 37, 124, 130, 46, 12, 213}
        Dim derivedBytes As New Rfc2898DeriveBytes(originalPassword, SALT_BYTES, 5)
        Return derivedBytes.GetBytes(passwordLength)
    End Function
    Private Function DerivePassword1(ByVal originalPassword As String, ByVal passwordLength As Integer) As Byte()
        'Salt value used to encrypt a plain text key. Again, this can be whatever you like
        Dim SALT_BYTES As Byte() = New Byte() {101, 195, 22, 4, 7, 115, 88, 141, 95, 204, 41, 66, 5, 234, 85, 98, 39, 206, 249, 72, 46, 79}
        'Dim sw As Stopwatch = Stopwatch.StartNew
        Dim derivedBytes As New Rfc2898DeriveBytes(originalPassword, SALT_BYTES, 10000)
        'Console.WriteLine("DerivePassword1 (10,000): " & sw.ElapsedMilliseconds & " ms")
        Return derivedBytes.GetBytes(passwordLength)
    End Function
#Region " Helper Functions "

#Region " String <-> Byte Array Conversion Functions "
    Private Function StringAsByteArray(ByVal strIn As String) As Byte()
        '-- Changed 27 Apr 2011 to support Chinese (base64 signatures)
        'Return System.Text.UnicodeEncoding.Default.GetBytes(strIn)
        Dim encoding As New System.Text.UnicodeEncoding()
        Return encoding.GetBytes(strIn)
    End Function

    Private Function ByteArrayAsString(ByVal bytesIn As Byte()) As String
        'Return System.Text.UnicodeEncoding.Default.GetString(bytesIn)
        '-- Changed on 27 Apr 2011 to support Chinese (base64 signatures)
        Dim encoding As New System.Text.UnicodeEncoding()
        Return encoding.GetString(bytesIn)
    End Function
#End Region


#End Region
#End Region
#Region " Public methods "

    Public Function EncryptStringSymetricVersion5Strong(ByVal plainText As String, ByVal encryptionKey As String) As String
        '-- This routine is stronger tham  EncryptStringSymetric because the DerivePassword is called 10,000 times
        '   In version 6 this was moved from the DLL to being part of the .exe. It is changed from the DLL because now it uses unicode not ascii
        Dim inputBytes() As Byte = Encoding.Unicode.GetBytes(plainText)
        Dim result() As Byte = EncryptSymmetric1(inputBytes, encryptionKey)
        Return Convert.ToBase64String(result)
    End Function
    Public Function EncryptStringSymetricVersion5Fast(ByVal plainText As String, ByVal encryptionKey As String) As String
        '-- In version 5.1 this was moved from the DLL to being part of the .exe
        '   It is unchanged from the DLL
        '   This routine is faster but less secure than Version3 because this only calls derivepassword 1 time. Version3 calls derivepassword 10,000 times.

        Dim bytValue() As Byte
        Dim bytKey() As Byte
        Dim bytEncoded() As Byte
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim objMemoryStream As New MemoryStream()
        Dim objCryptoStream As CryptoStream
        Dim objRijndaelManaged As RijndaelManaged


        '   **********************************************************************
        '   ******  Strip any null character from string to be encrypted    ******
        '   **********************************************************************

        plainText = StripNullCharacters(plainText)

        '   **********************************************************************
        '   ******  Value must be within ASCII range (i.e., no DBCS chars)  ******
        '   **********************************************************************

        bytValue = Encoding.Unicode.GetBytes(plainText.ToCharArray)

        intLength = Len(encryptionKey)

        '   ********************************************************************
        '   ******   Encryption Key must be 256 bits long (32 bytes)      ******
        '   ******   If it is longer than 32 bytes it will be truncated.  ******
        '   ******   If it is shorter than 32 bytes it will be padded     ******
        '   ******   with upper-case Xs.                                  ****** 
        '   ********************************************************************

        If intLength >= 32 Then
            encryptionKey = Strings.Left(encryptionKey, 32)
        Else
            intLength = Len(encryptionKey)
            intRemaining = 32 - intLength
            encryptionKey = encryptionKey & Strings.StrDup(intRemaining, "X")
        End If

        bytKey = Encoding.ASCII.GetBytes(encryptionKey.ToCharArray)

        objRijndaelManaged = New RijndaelManaged()

        '   ***********************************************************************
        '   ******  Create the encryptor and write value to it after it is   ******
        '   ******  converted into a byte array                              ******
        '   ***********************************************************************

        Try

            objCryptoStream = New CryptoStream(objMemoryStream,
              objRijndaelManaged.CreateEncryptor(bytKey, bytIV),
              CryptoStreamMode.Write)
            objCryptoStream.Write(bytValue, 0, bytValue.Length)

            objCryptoStream.FlushFinalBlock()

            bytEncoded = objMemoryStream.ToArray
            objMemoryStream.Close()
            objCryptoStream.Close()
        Catch ex As Exception
            Application.DoEvents()


        End Try

        '   ***********************************************************************
        '   ******   Return encryptes value (converted from  byte Array to   ******
        '   ******   a base64 string).  Base64 is MIME encoding)             ******
        '   ***********************************************************************

        Return Convert.ToBase64String(bytEncoded)
    End Function

    Public Function DecryptStringSymetricVersion5Fast(ByVal cypherText As String, ByVal encryptionKey As String) As String
        '-- In version 5.1 this was moved from the DLL to being part of the .exe
        '   It is unchanged from the DLL
        '   This routine is faster but less secure than Version3 because this only calls derivepassword 1 time. Version3 calls derivepassword 10,000 times.

        Dim bytDataToBeDecrypted() As Byte
        Dim bytTemp() As Byte
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim objRijndaelManaged As New RijndaelManaged()
        Dim objMemoryStream As MemoryStream
        Dim objCryptoStream As CryptoStream
        Dim bytDecryptionKey() As Byte

        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim strReturnString As String = String.Empty

        '   *****************************************************************
        '   ******   Convert base64 encrypted value to byte array      ******
        '   *****************************************************************

        bytDataToBeDecrypted = Convert.FromBase64String(cypherText)

        '   ********************************************************************
        '   ******   Encryption Key must be 256 bits long (32 bytes)      ******
        '   ******   If it is longer than 32 bytes it will be truncated.  ******
        '   ******   If it is shorter than 32 bytes it will be padded     ******
        '   ******   with upper-case Xs.                                  ****** 
        '   ********************************************************************

        intLength = Len(encryptionKey)

        If intLength >= 32 Then
            encryptionKey = Strings.Left(encryptionKey, 32)
        Else
            intLength = Len(encryptionKey)
            intRemaining = 32 - intLength
            encryptionKey = encryptionKey & Strings.StrDup(intRemaining, "X")
        End If

        bytDecryptionKey = Encoding.ASCII.GetBytes(encryptionKey.ToCharArray)

        ReDim bytTemp(bytDataToBeDecrypted.Length)

        objMemoryStream = New MemoryStream(bytDataToBeDecrypted)

        '   ***********************************************************************
        '   ******  Create the decryptor and write value to it after it is   ******
        '   ******  converted into a byte array                              ******
        '   ***********************************************************************

        Try

            objCryptoStream = New CryptoStream(objMemoryStream, _
               objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), _
               CryptoStreamMode.Read)

            objCryptoStream.Read(bytTemp, 0, bytTemp.Length)

            objCryptoStream.FlushFinalBlock()
            objMemoryStream.Close()
            objCryptoStream.Close()

        Catch

        End Try

        '   *****************************************
        '   ******   Return decypted value     ******
        '   *****************************************

        Return StripNullCharacters(Encoding.Unicode.GetString(bytTemp))

    End Function
    Public Function DecryptStringSymetricVersion5Strong(ByVal cypherText As String, ByVal decryptionKey As String) As String
        '-- This routine is stronger tham DecryptStringSymetric because the DerivePassword is called 10,000 times
        '   In version 5.1 this was moved from the DLL to being part of the .exe. It is unchanged from the DLL

        Dim inputBytes() As Byte = Convert.FromBase64String(cypherText)
        Dim result() As Byte = DecryptSymmetric1(inputBytes, decryptionKey)
        Return StripNullCharacters(Encoding.Unicode.GetString(result))

    End Function
#End Region


End Class ' CryptographyFunctions

