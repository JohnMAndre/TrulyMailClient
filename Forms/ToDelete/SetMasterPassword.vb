Public Class SetMasterPassword

    Private Sub txtPassword_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPassword.TextChanged
        SetPasswordStrengthLabel(txtPassword.Text, lblPasswordStrengthCaption, lblPasswordStrength)
    End Sub

    Private Sub txtConfirm_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtConfirm.TextChanged
        lblPasswordsDoNotMatch.Visible = Not (txtConfirm.Text = txtPassword.Text)
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If txtConfirm.Text = txtPassword.Text Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            ShowMessageBoxError("The password and the confirm do not match. Please re-enter.")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Public ReadOnly Property Password As String
        Get
            Return txtPassword.Text
        End Get
    End Property
End Class