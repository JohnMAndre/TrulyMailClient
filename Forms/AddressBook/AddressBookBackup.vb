Public Class AddressBookBackup

    Private Sub chkAutoBackup_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAutoBackup.CheckedChanged
        nudAutoBackupDays.Enabled = chkAutoBackup.Checked
    End Sub

    Private Sub AddressBookBackup_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            ApplyCurrentTheme(Me.KryptonPalette1)

            LoadSettings()
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Private Sub LoadSettings()
        chkAutoBackup.Checked = AppSettings.AutoAddressBookBackup
        nudAutoBackupDays.Value = AppSettings.AutoAddressBookBackupDays

        If AppSettings.LastAddressBookBackup = DATE_NEVER Then
            lblLastBackup.Text = "<never>"
            SetImage(pbLastBackupStatus, My.Resources.BallRed_16)
            ToolTip1.SetToolTip(pbLastBackupStatus, "Address book never backed up. You should backup soon.")
        Else
            lblLastBackup.Text = AppSettings.LastAddressBookBackup.ToString("dd MMM yyyy")
            Dim ts As TimeSpan = Date.Now - AppSettings.LastAddressBookBackup
            If ts.Days < AppSettings.AutoAddressBookBackupDays Then
                SetImage(pbLastBackupStatus, My.Resources.BallGreen_16)
                ToolTip1.SetToolTip(pbLastBackupStatus, "Address book backed up very recently.")
            Else
                SetImage(pbLastBackupStatus, My.Resources.BallYellow_16)
                ToolTip1.SetToolTip(pbLastBackupStatus, "Address book backup is too old. You should backup soon.")
            End If
        End If
    End Sub
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Try
            btnOK.Enabled = False
            lblBackupStatus.Visible = True
            Application.DoEvents()

            AppSettings.AutoAddressBookBackup = chkAutoBackup.Checked
            AppSettings.AutoAddressBookBackupDays = nudAutoBackupDays.Value

            Try
                '-- Now actually backup to server
                AddressBookSupport.BackupAddressBookToServer()

                LoadSettings()
            Catch ex As Exception
                Log(ex)
            End Try

        Catch ex As Exception
            Log(ex)
        End Try

        btnOK.Enabled = True
        lblBackupStatus.Visible = False

    End Sub

    Private Delegate Sub SetImageCallback(ByVal pb As PictureBox, ByVal image As Bitmap)
    Private Sub SetImage(ByVal pb As PictureBox, ByVal image As Bitmap)
        If InvokeRequired Then
            Dim deleg As New SetImageCallback(AddressOf SetImage)
            Invoke(deleg, pb, image)
        Else
            pb.Image = image
        End If
    End Sub
End Class
