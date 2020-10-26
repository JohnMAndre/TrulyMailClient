Friend Class ListViewForm

    Public Sub New(ByVal lst As List(Of NameValuePair))

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        olvHeaders.SetObjects(lst)
    End Sub
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Using frm As New AboutBoxK()
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        PrintListView()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        PrintListView()
    End Sub
    Private Sub PrintListView()
        'TODO: Print list view
    End Sub
    Public Property Column1Header() As String
        Get
            Return OlvColumn1.Text
        End Get
        Set(ByVal value As String)
            OlvColumn1.Text = value
        End Set
    End Property
    Public Property Column2Header() As String
        Get
            Return OlvColumn2.Text
        End Get
        Set(ByVal value As String)
            OlvColumn2.Text = value
            OlvColumn2.IsVisible = (value = String.Empty)
        End Set
    End Property
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ListViewForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Show()
        AutoSizeColumns(Me.olvHeaders)
    End Sub

    Private Sub ListViewForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub
End Class