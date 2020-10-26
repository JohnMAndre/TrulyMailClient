Public Class SetMasterPasswordK

    Private Sub txtPassword_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPassword.TextChanged
        SetPasswordStrengthLabel(txtPassword.Text, lblPasswordStrengthCaption, lblPasswordStrength)
    End Sub

    Private Sub txtConfirm_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtConfirm.TextChanged
        lblPasswordsDoNotMatch.Visible = Not (txtConfirm.Text = txtPassword.Text)
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If txtConfirm.Text = txtPassword.Text Then
            If chkEncryptLocally.Checked AndAlso txtPassword.Text.Length = 0 Then
                ShowMessageBox("Local file encryption requires you to set a startup password to act as your decryption key.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf chkEncryptLocally.Checked AndAlso AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Decrypted Then
                If ShowMessageBox("Are you sure you want to encrypt your local files? This will take time to complete (depending on how many local messages you have).", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    '-- begin encryption process
                    AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypting
                Else
                    chkEncryptLocally.Checked = False
                    Exit Sub
                End If
            ElseIf chkEncryptLocally.Checked = False AndAlso AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypted Then
                If ShowMessageBox("Are you sure you want to decrypt your local files? This will take time to complete (depending on how many local messages you have).", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    '-- begin decryption process
                    AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Decrypting
                Else
                    chkEncryptLocally.Checked = True
                    Exit Sub
                End If

            ElseIf txtPassword.Text.Length = 0 AndAlso Not AppSettings.EncryptSettingsFile Then
                '-- Was no password, still no password, so it is the same as hitting cancel 
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Exit Sub
            End If

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

    Private Sub chkShowPassword_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtPassword.PasswordChar = String.Empty
        Else
            txtPassword.PasswordChar = "*"c
        End If
        txtConfirm.PasswordChar = txtPassword.PasswordChar
    End Sub

    Private Sub SetMasterPasswordK_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If AppSettings.EncryptSettingsFile Then
            lblPasswordStatus.Text = "Password set"
        Else
            lblPasswordStatus.Text = "Password not set"
        End If

        lblLocalEncryptionStatus.Text = "Local files are " & AppSettings.EncryptLocalFiles.ToString().ToLower()

        If AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Decrypting OrElse AppSettings.EncryptLocalFiles = LocalFileEncryptionStatus.Encrypting Then
            btnOK.Enabled = False
        End If
    End Sub

    Private Sub pbEncryptLocallyInfo_Click(sender As Object, e As EventArgs) Handles pbEncryptLocallyInfo.Click
        ShowMessageBox("If you choose to encrypt messages locally, then whenever TrulyMail saves any emails, RSS, etc. to your local drive, it will encrypt it first. While it might be possible for someone to break this encryption, we do our best to make it very difficult for them." _
                       & Environment.NewLine & Environment.NewLine & _
                       "Turning on local encryption will make your data safer but it means Windows will not be able to index your messages (so you must use TrulyMail search to find messages)." _
                       & Environment.NewLine & Environment.NewLine & _
                       "If you lose your password you will not be able to recover your messages. TrulyMail does not keep a copy of your password (for your safety)." _
                       & Environment.NewLine & Environment.NewLine & _
                       "Attachments will also be encrypted. When you open (for example to read ) them, they will be decrypted into a special folder and TrulyMail will do its best to remove unencrypted versions regularly." _
                       & Environment.NewLine & Environment.NewLine & _
                       "When you copy attachments, they will be decrypted and it will be up to you to control privacy issues." _
                       , MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

    End Sub
End Class
