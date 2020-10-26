Friend Class Login

    Private m_dtAutoCloseTime As Date = Date.Now.AddSeconds(30)
    Private m_profile As IUsernamePassword
    Private m_szSmall As Size
    Private m_boolShown As Boolean
    Public Sub New(ByVal profile As IUsernamePassword)
        'Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        If profile Is Nothing Then
            '-- use TrulyMail
            m_profile = Nothing
        Else
            m_profile = profile
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.chkRememberPassword.Checked Then
            If m_profile Is Nothing Then
                AppSettings.PasswordTrulyMail = txtPassword.Text.Trim
                AppSettings.Save()
            Else
                m_profile.Password = txtPassword.Text.Trim
                AppSettings.Save()
            End If
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If m_profile Is Nothing Then
            txtUsername.Text = AppSettings.Username
            txtServer.Text = "TrulyMail.com"
            pbContactType.Image = My.Resources.Securedmessage_32
        Else
            txtServer.Text = m_profile.ToString()
            txtUsername.Text = m_profile.Username
            pbContactType.Image = My.Resources.email_32
        End If

        SetupKeyboard()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Friend ReadOnly Property Password() As String
        Get
            Return txtPassword.Text.Trim
        End Get
    End Property

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If IsKeyLocked(Keys.CapsLock) Then
            ToolTip1.Show("Caps lock is on which can cause problems entering your password.", txtPassword)
        End If
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        btnOK.Enabled = txtPassword.Text.Length > 0
    End Sub

    Private Sub tmrAutoClose_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAutoClose.Tick
        Dim ts As TimeSpan = m_dtAutoCloseTime - Date.Now
        Dim intSecondsLeft As Integer = ts.TotalSeconds
        If intSecondsLeft <= 0 Then
            btnCancel.PerformClick()
        Else
            Me.btnCancel.Text = "&Cancel (" & intSecondsLeft.ToString & ")"
        End If
    End Sub

    Private Sub Login_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        '-- Really having problems with this form showing behind the mainform
        '   hopefully this solves the problem
        SetForegroundWindow(Me.Handle)
        txtPassword.Focus()
        m_boolShown = True
    End Sub

    Private Sub btnKBQwerty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKBQwerty.Click
        Me.Keyboardcontrol1.KeyboardType = KeyboardClassLibrary.BoW.Standard
    End Sub

    Private Sub btnKBAbc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKBAbc.Click
        Me.Keyboardcontrol1.KeyboardType = KeyboardClassLibrary.BoW.Alphabetical
    End Sub

    Private Sub btnKBFun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKBFun.Click
        Me.Keyboardcontrol1.KeyboardType = KeyboardClassLibrary.BoW.Kids
    End Sub

    Private Sub pbKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbKeyboard.Click
        pnlKBType.Visible = Not pnlKBType.Visible
        SetupKeyboard()
    End Sub
    Private Sub SetupKeyboard()
        Me.Keyboardcontrol1.Visible = pnlKBType.Visible
        Application.DoEvents()
        If pnlKBType.Visible Then
            '-- show
            Me.Width = 760
            Me.Height = 460
        Else
            '-- hide
            If m_boolShown Then
                Me.Size = m_szSmall
            End If
            'Me.Width = 438
            'Me.Height = 192
        End If

    End Sub

    Private Sub Keyboardcontrol1_UserKeyPressed(ByVal sender As System.Object, ByVal e As KeyboardClassLibrary.KeyboardEventArgs) Handles Keyboardcontrol1.UserKeyPressed
        Try
            If e.KeyboardKeyPressed IsNot Nothing Then
                Select Case e.KeyboardKeyPressed.ToUpper()
                    Case "{BACKSPACE}"
                        txtPassword.Text = txtPassword.Text.Substring(0, txtPassword.Text.Length - 1)
                    Case "{ENTER}", "{DELETE}", "{INSERT}", "{HOME}", "{END}", "{LEFT}", "{RIGHT}", "{UP}", "{DOWN}"
                        lblKeyNotUsed.Show()
                        tmrHideMessage.Start()
                    Case Else
                        '-- normal key
                        txtPassword.AppendText(e.KeyboardKeyPressed)
                End Select
            End If
        Catch ex As Exception
            'Log(ex)
        End Try
    End Sub

    Private Sub chkShowPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.PasswordChar = IIf(chkShowPassword.Checked, String.Empty, "*")
    End Sub

    Private Sub tmrHideMessage_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHideMessage.Tick
        tmrHideMessage.Stop()
        lblKeyNotUsed.Hide()
    End Sub

    Private Sub txtPassword_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtPassword.DragEnter
        ' Check the format of the data being dropped.
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub txtPassword_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtPassword.DragDrop
        txtPassword.Text = e.Data.GetData(DataFormats.Text)
        Me.Text = txtPassword.Text
    End Sub

    Private Sub tmrSetSize_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSetSize.Tick
        If m_boolShown Then
            tmrSetSize.Stop()
            m_szSmall = Me.Size
        End If
    End Sub
End Class