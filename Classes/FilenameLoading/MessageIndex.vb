
'------------------------------------------------------------------------------------
'
'   This class used a serialized store of TrulyMailMessages
'   to speed up the loading of messages. One instance of this
'   class = one folder
'
'------------------------------------------------------------------------------------


Friend Class MessageIndex
    Implements IDisposable

    Private m_dtCreated As Date = Date.UtcNow
    Private m_boolDirty As Boolean
    Private m_ht As Hashtable
    Private m_strPath As String
    Private m_bgSave As System.ComponentModel.BackgroundWorker

    Public Sub New(ByVal path As String)
        'm_strPath = path
        'm_ht = GetMessageIndex(path)
    End Sub
    Public Sub Save()
        '-- persist the hashtable on background thread
        'TODO: Only remove bad entries if dirty or if x minutes/hours have passed

        'm_bgSave = New System.ComponentModel.BackgroundWorker()
        'AddHandler m_bgSave.DoWork, AddressOf m_bgSave_DoWork
        'm_bgSave.RunWorkerAsync()
    End Sub
    Private Sub m_bgSave_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Try
            '-- First, remove bad entries (moved or deleted messages)
            Dim lstToRemove As New List(Of String)
            Dim tmm As TrulyMailMessage
            For Each item As DictionaryEntry In m_ht
                tmm = m_ht(item.Key)
                If tmm.LastChecked < m_dtCreated Then
                    lstToRemove.Add(item.Key)
                End If
            Next

            For Each item As String In lstToRemove
                m_ht.Remove(item)
                m_boolDirty = True
            Next

            '-- Then persist the hashtable, only if something changed
            If m_boolDirty Then
                SaveMessageIndex(m_strPath, m_ht)
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Public Function GetMessage(ByVal fd As FileDetails) As TrulyMailMessage
        '-- For 5.1.0 testing, I'm removing MessageIndex support and just creating the message each time
        '   Since we are now multi-threaded, perhaps this is a good solution'
        '   The problem was that TrulyMailMessage class is now fully object oriented
        '   So there are serialization issue and I'm not sure we gain much because the message index
        '   is now a complete representation of all messages. Another issue is now the index needs to be
        '   encrypted so it just seems easier to get rid of it. The only question is whether performance will suffer
        Try
            Return New TrulyMailMessage(fd.FullName)
        Catch ex As Exception
            Log(ex)
            Throw ex
        End Try

        'Dim tmm As TrulyMailMessage
        'Dim boolCreateFromFile As Boolean

        'If m_ht.ContainsKey(fd.Name) Then
        '    Try
        '        tmm = m_ht.Item(fd.Name)
        '        tmm.Filename = fd.FullName '-- In case folder is moved, we must ensure the path is always correct
        '        If tmm.LastChecked > fd.ModifyDate Then
        '            tmm.LastChecked = Date.UtcNow
        '            '-- Just return tmm as it is
        '        Else
        '            '-- The .tmm file has been modified since it was added to the index, must remove and re-add it
        '            m_ht.Remove(fd.Name)
        '            Try
        '                tmm = New TrulyMailMessage(fd.FullName)
        '            Catch ex As Exception
        '                Log(ex)
        '                Return Nothing
        '            End Try
        '            tmm.LastChecked = Date.UtcNow
        '            m_ht.Add(fd.Name, tmm)
        '            m_boolDirty = True
        '        End If
        '    Catch ex As Exception
        '        '-- should be this error
        '        '   Unable to cast object of type 'System.Runtime.Serialization.TypeLoadExceptionHolder' to type 'TrulyMailMessage'.
        '        Log(ex) '-- log to check later
        '        boolCreateFromFile = True
        '        m_ht.Remove(fd.Name) '-- remove the offending item as it will be re-added below
        '    End Try
        'Else
        '    boolCreateFromFile = True
        'End If

        'If boolCreateFromFile Then
        '    Try
        '        tmm = New TrulyMailMessage(fd.FullName)
        '    Catch ex As Exception
        '        Log(ex)
        '        Return Nothing
        '    End Try
        '    tmm.LastChecked = Date.UtcNow
        '    m_ht.Add(fd.Name, tmm)
        '    m_boolDirty = True
        'End If
        'Return tmm
    End Function
    Public Function GetMessage(ByVal filename As String) As TrulyMailMessage
        Dim fd As New FileDetails(filename)
        Return GetMessage(fd)
    End Function

#Region " Message Index Logic (all private)"
    Private Function GetMessageIndexDate(ByVal path As String) As Date
        Const INDEX_FILENAME As String = "index.dat"
        Dim strFilename As String = QualifyPath(path) & INDEX_FILENAME
        If System.IO.File.Exists(strFilename) Then
            System.IO.File.GetLastWriteTimeUtc(strFilename)
        End If
    End Function
    Private Function GetMessageIndex(ByVal path As String) As Hashtable
        Const INDEX_FILENAME As String = "index.dat"
        Dim strFilename As String = QualifyPath(path) & INDEX_FILENAME
        If System.IO.File.Exists(strFilename) Then
            Try
                Using fs As System.IO.FileStream = System.IO.File.OpenRead(strFilename)
                    Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                    Return bf.Deserialize(fs)
                End Using
            Catch ex As Exception
                Log(ex)
                '-- The problem could well be a corruption in the index file
                '   delete it just to be safe and return a new hashtable
                Try
                    DeleteLocalFile(strFilename)
                Catch ex1 As Exception
                    Log(ex1)
                End Try
                Return New Hashtable
            End Try
        Else
            '-- index does not exist yet
            '   just use an empty hashtabel
            Return New Hashtable()
        End If
    End Function
    Private Sub SaveMessageIndex(ByVal path As String, ByVal ht As Hashtable)
        Const INDEX_FILENAME As String = "index.dat"
        Dim strFilename As String = QualifyPath(path) & INDEX_FILENAME

        '-- Delete any existing index file
        If System.IO.File.Exists(strFilename) Then
            DeleteLocalFile(strFilename)
        End If

        Using fs As System.IO.FileStream = System.IO.File.Create(strFilename, 1024)
            Try
                Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                bf.Serialize(fs, ht)
            Catch ex As Exception
                Log(ex)
            End Try

        End Using
    End Sub
#End Region

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                If m_bgSave IsNot Nothing Then
                    m_bgSave.Dispose()
                End If
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
