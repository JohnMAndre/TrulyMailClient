Public Class LimitEmailDownloadK

    Private Sub LimitEmailDownloadK_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        chkEnableEmailDownloadLimit.Checked = AppSettings.EmailDownloadLimit
        dtpDownloadLimitResetDate.Value = AppSettings.EmailDownloadLimitExpireDate
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        AppSettings.EmailDownloadLimit = chkEnableEmailDownloadLimit.Checked
        AppSettings.EmailDownloadLimitExpireDate = dtpDownloadLimitResetDate.Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class
