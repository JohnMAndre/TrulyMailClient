Public Class AssociatedIcon
#Region " API "
    Private Const MAX_PATH = 260
    Private Const SHGFI_LARGEICON = &H0
    Private Const SHGFI_SMALLICON = &H1
    Private Const SHGFI_ICON = &H100

    Private Structure SHFILEINFO
        Dim hIcon As IntPtr
        Dim iIcon As Integer
        Dim dwAttributes As Integer
        <VBFixedString(MAX_PATH)> Dim szDisplayName As String
        <VBFixedString(80)> Dim szTypeName As String
    End Structure

    Private Declare Function SHGetFileInfo Lib "shell32.dll" Alias "SHGetFileInfoA" ( _
    ByVal pszPath As String, _
    ByVal dwFileAttributes As Integer, _
    ByRef psfi As SHFILEINFO, _
    ByVal cbFileInfo As Integer, _
    ByVal uFlags As Integer) As Integer
#End Region

    Private Shared Function _geticon(ByVal file As String, ByVal size As Integer) As Icon
        Dim fileIcon As Icon
        'Dim m As System.Runtime.InteropServices.Marshal
        Dim shinfo As SHFILEINFO

        'This gets the icon out of the specified file and puts it into the shinfo struct, and
        'out into an Icon object.
        If SHGetFileInfo(file, 0, shinfo, Runtime.InteropServices.Marshal.SizeOf(shinfo), SHGFI_ICON Or size) Then
            fileIcon = Icon.FromHandle(shinfo.hIcon)
            Return fileIcon
        Else
            Return Nothing
        End If
    End Function

    'Retrieves the 16x16 icon for a file
    Public Shared Function GetAssociatedIconSmall(ByVal file As String) As Icon
        If Not System.IO.File.Exists(file) Then
            Throw New IO.FileNotFoundException("The specified file was not found", file)
        Else
            Return _geticon(file, SHGFI_SMALLICON)
        End If
    End Function

    'Retrieves the 32x32 icon for a file
    Public Shared Function GetAssociatedIconLarge(ByVal file As String) As Icon
        If Not System.IO.File.Exists(file) Then
            Throw New IO.FileNotFoundException("The specified file was not found", file)
        Else
            _geticon(file, SHGFI_LARGEICON)
        End If
    End Function
End Class
