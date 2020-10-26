Friend Class InputBox
    Public Sub New(ByVal message As String, ByVal isPassword As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.lblMessage.Text = message
        If isPassword Then
            txtInput.PasswordChar = "*"
        Else
            txtInput.PasswordChar = String.Empty
        End If
    End Sub
    Public Property Input() As String
        Get
            Return txtInput.Text
        End Get
        Set(ByVal value As String)
            txtInput.Text = value
        End Set
    End Property

    Private Sub InputBox_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        SetForegroundWindow(Me.Handle)
    End Sub

    Private Sub KryptonPanel_Paint(sender As Object, e As PaintEventArgs) Handles KryptonPanel.Paint

    End Sub
End Class