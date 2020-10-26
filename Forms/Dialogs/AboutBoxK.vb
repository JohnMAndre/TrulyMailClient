Public Class AboutBoxK

    Private Sub AboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        lblPremium.Show()
        ApplicationTitle &= " Premium"

        Me.Text = String.Format("About {0}", ApplicationTitle)

        If AppSettings.PortableProfile Then
            Me.Text &= " Portable"
        Else
            Me.Text &= " Standard"
        End If
        Me.Text &= String.Format(" Version {0}", Application.ProductVersion)

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub LogoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoPictureBox.Click
        Close()
    End Sub

    Private Sub AboutBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Close()
    End Sub

    Private Sub llblGoToWebsite_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblGoToWebsite.LinkClicked
        If ModifierKeys = (Keys.Shift Or Keys.Control) Then
            '-- if user presses ctrl+shift while clicking, then show the workingset
            Dim info As New Microsoft.VisualBasic.Devices.ComputerInfo()
            llblGoToWebsite.Text = "WSet: " & FormatDataSizeString(Environment.WorkingSet) & " (" & FormatDataSizeString(info.AvailablePhysicalMemory) & " of " & FormatDataSizeString(info.TotalPhysicalMemory) & " free)"
        Else
            System.Diagnostics.Process.Start("http://TrulyMail.com")
            Close()
        End If
    End Sub

    Private Sub AboutBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Close()
        End Select
    End Sub
End Class
