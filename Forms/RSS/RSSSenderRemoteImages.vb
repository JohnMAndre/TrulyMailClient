Public Class RSSSenderRemoteImages
    Private Class RSSSender
        Public Title As String
    End Class
    Private Sub RSSSenderRemoteImages_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadList()
    End Sub
    Private Sub LoadList()
        Dim lst As New List(Of RSSSender)
        For Each strKey As String In AppSettings.RSSSenderAllowRemoteImages.Keys
            Dim sender As New RSSSender()
            sender.Title = strKey
            lst.Add(sender)
        Next
        olvRSSSenders.SetObjects(lst)
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim s As String = GetInput("Enter name of RSS source.", False)
        AppSettings.RSSSenderAllowRemoteImages.Add(s, Nothing)
        LoadList()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim rsssender As RSSSender = CType(olvRSSSenders.SelectedObject, RSSSender)
        If rsssender IsNot Nothing Then
            AppSettings.RSSSenderAllowRemoteImages.Remove(rsssender.Title)
            LoadList()
        End If
    End Sub
End Class