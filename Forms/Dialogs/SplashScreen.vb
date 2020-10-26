Public NotInheritable Class SplashScreen

    Private Sub SplashScreen_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        SetForegroundWindow(Me.Handle)
        lblPremium.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Try
            System.Diagnostics.Process.Start("http://TrulyMail.com")
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error launching the TrulyMail website.")
        End Try
    End Sub
End Class
