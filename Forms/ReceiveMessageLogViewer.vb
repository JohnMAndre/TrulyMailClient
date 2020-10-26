Friend Class ReceiveMessageLogViewer
    Private m_lst As List(Of ReceiveFileDetails)

    Public Sub New(lst As List(Of ReceiveFileDetails))

        ' This call is required by the designer.
        InitializeComponent()

        m_lst = lst
        ReloadData()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Using frm As New AboutBoxK()
            frm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        ReloadData()
    End Sub
    Private Sub ReloadData()
        '-- there might be a more efficient way to do this
        olvData.ClearObjects()
        olvData.SetObjects(m_lst)
        AutoSizeColumns(olvData)
    End Sub
    Private Sub ShowReceiveDetailsOfSelectedMessage()
        Try
            rtbDetails.Text = CType(olvData.SelectedObject, ReceiveFileDetails).Details
        Catch ex As Exception
            ShowMessageBoxError("There was an error loading the details for this entry." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub
    Private Sub olvData_ItemActivate(sender As Object, e As EventArgs) Handles olvData.ItemActivate
        ShowReceiveDetailsOfSelectedMessage()
    End Sub
    Private Sub OpenSelectedMessage()
        Try
            If olvData.SelectedObject Is Nothing Then
                ShowMessageBoxError("Please select a message to open.")
            Else
                Dim obj As ReceiveFileDetails = CType(olvData.SelectedObject, ReceiveFileDetails)
                If System.IO.File.Exists(obj.MessageFilename) Then
                    LoadMessage(obj.MessageFilename)
                Else
                    ShowMessageBoxError("The selected message no longer exists. Perhaps it was deleted or moved to another folder.")
                End If
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error open the message: " & ex.Message)
        End Try
    End Sub
    Private Sub OpenMessageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenMessageToolStripMenuItem.Click
        OpenSelectedMessage()
    End Sub

    Private Sub olvData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles olvData.SelectedIndexChanged
        If olvData.SelectedIndex > -1 Then
            ShowReceiveDetailsOfSelectedMessage()
        End If
    End Sub

    Private Sub OpenSelectedMessageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSelectedMessageToolStripMenuItem.Click
        OpenSelectedMessage()
    End Sub

End Class