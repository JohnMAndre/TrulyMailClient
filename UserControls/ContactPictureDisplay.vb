Public Class ContactPictureDisplay

    Public Event UserHidden()

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        RaiseEvent UserHidden()
        Visible = False
    End Sub
    Public Property Image As Image
        Get
            Return pbImage.Image
        End Get
        Set(ByVal value As Image)
            pbImage.Image = value
        End Set
    End Property

    Private Sub ContactPictureDisplay_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        btnClose.Left = (Me.Width - btnClose.Width) - 1 '-- so top and right edges are 1 px from edge of control
    End Sub
End Class
