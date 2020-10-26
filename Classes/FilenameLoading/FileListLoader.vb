Friend Class FileListLoader

#Region " Module level stuff "
    Private m_regex As System.Text.RegularExpressions.Regex
    Private m_lst As List(Of FileDetails)

    Private Const MAX_DWORD As Integer = &HFFFFFFFF
    Private Const MAX_PATH As Integer = 260
    Private Const INVALID_HANDLE_VALUE As Integer = -1
    Private Const FILE_ATTRIBUTE_ARCHIVE As Integer = &H20S
    Private Const FILE_ATTRIBUTE_COMPRESSED As Integer = &H800S
    Private Const FILE_ATTRIBUTE_DIRECTORY As Integer = &H10S
    Private Const FILE_ATTRIBUTE_HIDDEN As Integer = &H2S
    Private Const FILE_ATTRIBUTE_NORMAL As Integer = &H80S
    Private Const FILE_ATTRIBUTE_READONLY As Integer = &H1S
    Private Const FILE_ATTRIBUTE_TEMPORARY As Integer = &H100S
    Private Const FILE_ATTRIBUTE_FLAGS As Long = FILE_ATTRIBUTE_ARCHIVE Or FILE_ATTRIBUTE_HIDDEN Or FILE_ATTRIBUTE_NORMAL Or FILE_ATTRIBUTE_READONLY
    Private Const SEARCH_PATTERN As String = "*.*"

#End Region

#Region " Windows API "
    '== Name Loading
    ' If the function succeeds, the return value is a search handle
    ' used in a subsequent call to FindNextFile or FindClose
    Friend Declare Function FindFirstFile Lib "kernel32" Alias "FindFirstFileA" (ByVal lpFileName As String, ByRef lpFindFileData As WIN32_FIND_DATA) As Integer
    Friend Declare Function FileTimeToSystemTime Lib "kernel32" (ByRef lpFileTime As FILETIME, ByRef lpSystemTime As SYSTEMTIME) As Integer
    Friend Declare Function FileTimeToLocalFileTime Lib "kernel32" (ByRef lpFileTime As FILETIME, ByRef lpLocalFileTime As FILETIME) As Integer

    ' Rtns (non zero) on succes, False on failure
    Friend Declare Function FindNextFile Lib "kernel32" Alias "FindNextFileA" (ByVal hFindFile As Integer, ByRef lpFindFileData As WIN32_FIND_DATA) As Integer

    ' Rtns (non zero) on succes, False on failure
    Friend Declare Function FindClose Lib "kernel32" (ByVal hFindFile As Integer) As Integer
    '== Name Loading
#End Region

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="regEx">Regular expression to match filenames (e.g., .\.tmm for TrulyMail message files)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal regEx As String)
        m_regex = New System.Text.RegularExpressions.Regex(regEx, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Sub
    Private Function FileIsViewable(ByVal FullName As String) As Boolean
        Return m_regex.Match(FullName).Success
    End Function
    Public Function GetFilesInPath(ByVal path As String, ByVal searchSubFolders As Boolean) As List(Of FileDetails)
        Dim FP As New FILE_PARAMS

        With FP
            .sFileRoot = QualifyPath(path)
            .sFileNameExt = SEARCH_PATTERN '-- Unfortunately, passing in "*.jpg;*.vob" does nothing here
            .bRecurse = searchSubFolders
            .bList = False
        End With

        m_lst = New List(Of FileDetails)

        SearchAndLoadFiles(FP)

        Return m_lst
    End Function

    Private Sub SearchAndLoadFiles(ByRef FP As FILE_PARAMS)
        Dim files() As String
        If FP.bRecurse Then
            files = System.IO.Directory.GetFiles(FP.sFileRoot, SEARCH_PATTERN, IO.SearchOption.AllDirectories)
        Else
            files = System.IO.Directory.GetFiles(FP.sFileRoot, SEARCH_PATTERN, IO.SearchOption.TopDirectoryOnly)
        End If

        For Each strFilename As String In files
            If FileIsViewable(strFilename) Then
                '-- Add image details to array
                Dim file As New FileDetails()
                file.Path = FP.sFileRoot
                file.Name = System.IO.Path.GetFileName(strFilename)

                '-- I am not sure I need this information
                '   I think everything I do is with the date/time stored in the XML
                'FileTimeToLocalFileTime(WFD.ftLastWriteTime, localFileTime)
                'FileTimeToSystemTime(localFileTime, sysTime)
                'file.ModifyDate = sysTime.ToDateTime().ToUniversalTime()

                'FileTimeToLocalFileTime(WFD.ftCreationTime, localFileTime)
                'FileTimeToSystemTime(localFileTime, sysTime)
                'file.CreateDate = sysTime.ToDateTime().ToUniversalTime()

                m_lst.Add(file)
            End If
        Next
    End Sub

    '-- Version 6.0.4: I am removing this call to platform invoke
    '   Going to use method above for stability reasons
    'Private Sub SearchAndLoadFiles(ByRef FP As FILE_PARAMS)
    '    'local working variables
    '    Dim WFD As WIN32_FIND_DATA
    '    Dim hFile As Integer
    '    Dim strRoot As String = QualifyPath(FP.sFileRoot)
    '    Dim strPath As String = String.Concat(strRoot, SEARCH_PATTERN)
    '    Dim strTemp As String
    '    Dim sysTime As SYSTEMTIME
    '    Dim localFileTime As FILETIME

    '    'obtain handle to the first match
    '    hFile = FindFirstFile(strPath, WFD)

    '    'if valid ...
    '    If hFile <> INVALID_HANDLE_VALUE Then

    '        'This is where the method obtains the file
    '        'list and data for the folder passed.
    '        Do
    '            'if the returned item is a folder...
    '            If (WFD.dwFileAttributes And FILE_ATTRIBUTE_DIRECTORY) = FILE_ATTRIBUTE_DIRECTORY Then

    '                '..and the Recurse flag was specified
    '                If FP.bRecurse Then

    '                    'remove trailing nulls
    '                    strTemp = TrimNull(WFD.cFileName)

    '                    'and if the folder is not the default
    '                    'self and parent folders...
    '                    If Not strTemp.Equals(".") And Not strTemp.Equals("..") Then

    '                        '..then the item is a real folder, which
    '                        'may contain other sub folders, so assign
    '                        'the new folder name to FP.sFileRoot and
    '                        'recursively call this function again with
    '                        'the ammended information.
    '                        FP.sFileRoot = String.Concat(strRoot, strTemp)
    '                        SearchAndLoadFiles(FP)
    '                    End If
    '                End If
    '            Else
    '                '-- Not a folder, must be a file
    '                '-- Either there is not filenamePrefix or this file has a filename that starts with the given prefix
    '                If FileIsViewable(WFD.cFileName) Then
    '                    '-- Add image details to array
    '                    Dim file As New FileDetails()
    '                    file.Path = strRoot
    '                    file.Name = WFD.cFileName

    '                    FileTimeToLocalFileTime(WFD.ftLastWriteTime, localFileTime)
    '                    FileTimeToSystemTime(localFileTime, sysTime)
    '                    file.ModifyDate = sysTime.ToDateTime().ToUniversalTime()

    '                    FileTimeToLocalFileTime(WFD.ftCreationTime, localFileTime)
    '                    FileTimeToSystemTime(localFileTime, sysTime)
    '                    file.CreateDate = sysTime.ToDateTime().ToUniversalTime()

    '                    m_lst.Add(file)
    '                End If
    '            End If

    '            Application.DoEvents()
    '        Loop While FindNextFile(hFile, WFD) <> 0

    '        'close the find handle
    '        hFile = FindClose(hFile)
    '    End If
    'End Sub
    Private Shared Function TrimNull(ByVal TestString As String) As String

        'returns the string up to the first
        'null, if present, otherwise the passed string
        Dim pos As Integer = TestString.IndexOf(Chr(0))

        If pos > -1 Then
            Return TestString.Substring(pos - 1)
        Else
            Return TestString
        End If

    End Function
End Class

Friend Class FileDetails
    Implements IComparable(Of FileDetails), IEquatable(Of FileDetails)
    Private Shared m_arrFileDetailPaths(0) As String
    Private Shared m_htFileDetailPaths As New Hashtable
    Private m_intPathIndex As Integer = -1
    Public CreateDate As Date
    Public ModifyDate As Date
    Public Name As String
    Public Sub New(ByVal filename As String)
        Path = System.IO.Path.GetDirectoryName(filename)
        Name = System.IO.Path.GetFileName(filename)
        ModifyDate = System.IO.File.GetLastWriteTime(filename)
    End Sub
    Public Sub New()

    End Sub
    ''' <summary>
    ''' Just the folder name, example: C:\test\temp\
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Path() As String
        Get
            Return m_arrFileDetailPaths(m_intPathIndex)
        End Get
        Set(ByVal value As String)
            m_intPathIndex = GetPathIndex(value)
        End Set
    End Property
    Public Function FullName() As String
        Return String.Concat(Path, Name)
    End Function
    Public Function CompareTo(ByVal other As FileDetails) As Integer Implements IComparable(Of FileDetails).CompareTo
        '-- Default comparer
        '   We need to use path + name to ensure proper sorting
        Dim s1 As String = String.Concat(Path, Name)
        Dim s2 As String = String.Concat(other.Path, other.Name)
        Return s1.CompareTo(s2)
    End Function

    '-- These next three are implemented to avoid boxing/unboxing
    Public Function Equals(ByVal other As FileDetails) As Boolean Implements IEquatable(Of FileDetails).Equals
        Return FullName() = other.FullName
    End Function
    Public Shared Operator =(ByVal a As FileDetails, ByVal b As FileDetails) As Boolean
        Return a.FullName = b.FullName
    End Operator
    Public Shared Operator <>(ByVal a As FileDetails, ByVal b As FileDetails) As Boolean
        Return a.FullName <> b.FullName
    End Operator

    Friend Shared Function GetPathIndex(ByVal path As String) As Integer
        If m_htFileDetailPaths.Contains(path) Then
            Return Convert.ToInt32(m_htFileDetailPaths.Item(path))
        Else
            Dim intPathIndex As Integer = m_htFileDetailPaths.Count
            m_htFileDetailPaths.Add(path, intPathIndex)
            ReDim Preserve m_arrFileDetailPaths(intPathIndex)
            m_arrFileDetailPaths(intPathIndex) = path
            Return intPathIndex
        End If
    End Function
End Class
Friend Structure SYSTEMTIME
    Private wYear As Short
    Private wMonth As Short
    Private wDayOfWeek As Short
    Private wDay As Short
    Private wHour As Short
    Private wMinute As Short
    Private wSecond As Short
    Private wMilliseconds As Short

    Private dtDefaultDate As Date
    Public Overrides Function ToString() As String
        '-- We don't include milliseconds here because it is always -0-
        Return String.Concat(wYear.ToString("0000"), wMonth.ToString("00"), wDay.ToString("00"), _
                wHour.ToString("00"), wMinute.ToString("00"), wSecond.ToString("00"), wMilliseconds.ToString("000"))
    End Function
    Public Sub New(ByVal FormattedDate As String)
        dtDefaultDate = Date.MinValue.AddYears(1) '-- just not min date

        If Not IsNumeric(FormattedDate) Then
            wYear = Convert.ToInt16(dtDefaultDate.Year)
            wMonth = Convert.ToInt16(dtDefaultDate.Month)
            wDay = Convert.ToInt16(dtDefaultDate.Day)
            wHour = Convert.ToInt16(dtDefaultDate.Hour)
            wMinute = Convert.ToInt16(dtDefaultDate.Minute)
            wSecond = Convert.ToInt16(dtDefaultDate.Second)
            wMilliseconds = Convert.ToInt16(dtDefaultDate.Millisecond)
        Else
            wYear = Short.Parse(FormattedDate.Substring(0, 4))
            wMonth = Short.Parse(FormattedDate.Substring(4, 2))
            wDay = Short.Parse(FormattedDate.Substring(6, 2))
            wHour = Short.Parse(FormattedDate.Substring(8, 2))
            wMinute = Short.Parse(FormattedDate.Substring(10, 2))
            wSecond = Short.Parse(FormattedDate.Substring(12, 2))
            wMilliseconds = Short.Parse(FormattedDate.Substring(14, 3))
        End If
    End Sub
    Public Function ToDateTime() As Date
        Try
            Return New Date(wYear, wMonth, wDay, wHour, wMinute, wSecond, wMilliseconds)
        Catch ex As Exception
            Return dtDefaultDate '-- default date since the filename must have an invalid date
        End Try
    End Function
    Public Sub FromDateTime(ByVal dt As Date)
        With dt
            '-- ignore dayofweek to speed it up and we don't care about that in this app
            wYear = Convert.ToInt16(.Year)
            wMonth = Convert.ToInt16(.Month)
            wDay = Convert.ToInt16(.Day)
            wHour = Convert.ToInt16(.Hour)
            wMinute = Convert.ToInt16(.Minute)
            wSecond = Convert.ToInt16(.Second)
            wMilliseconds = Convert.ToInt16(.Millisecond)
        End With
    End Sub
End Structure
Friend Structure FILETIME
    Public dwLowDateTime As Integer
    Public dwHighDateTime As Integer
End Structure
Friend Structure WIN32_FIND_DATA
    Public dwFileAttributes As Integer
    Public ftCreationTime As FILETIME
    Public ftLastAccessTime As FILETIME
    Public ftLastWriteTime As FILETIME
    Public nFileSizeHigh As Integer
    Public nFileSizeLow As Integer
    Public dwReserved0 As Integer
    Public dwReserved1 As Integer
    'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
    <VBFixedString(MAX_LONG_FILENAME_PATH), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=MAX_LONG_FILENAME_PATH)> Public cFileName As String
    'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
    <VBFixedString(14), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=14)> Public cShortFileName As String
    Private Const MAX_LONG_FILENAME_PATH As Short = 260
End Structure
'custom structure for searching - add additional members if required
Friend Structure FILE_PARAMS
    Public bRecurse As Boolean 'set True to perform a recursive search
    Public bList As Boolean 'set True to add results to listbox
    Public bFound As Boolean 'set only with SearchTreeForFile methods
    Public sFileRoot As String 'search starting point, ie c:\, c:\winnt\
    Public sFileNameExt As String 'filename/filespec to locate, ie *.dll, notepad.exe
    Public sResult As String 'path to file. Set only with SearchTreeForFile methods
    Public nFileCount As Integer 'total file count matching filespec. Set in FindXXX only
    Public nFileSize As Double 'total file size matching filespec. Set in FindXXX only
End Structure