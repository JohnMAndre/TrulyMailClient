<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.tmrSetSize = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip4 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblKeyNotUsed = New System.Windows.Forms.Label()
        Me.tmrAutoClose = New System.Windows.Forms.Timer(Me.components)
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.Keyboardcontrol1 = New KeyboardClassLibrary.Keyboardcontrol()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.pbKeyboard = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkRememberPassword = New System.Windows.Forms.CheckBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tmrHideMessage = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnKBAbc = New System.Windows.Forms.Button()
        Me.btnKBQwerty = New System.Windows.Forms.Button()
        Me.btnKBFun = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.pbContactType = New System.Windows.Forms.PictureBox()
        Me.pnlKBType = New System.Windows.Forms.Panel()
        CType(Me.pbKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbContactType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlKBType.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrSetSize
        '
        Me.tmrSetSize.Enabled = True
        Me.tmrSetSize.Interval = 1000
        '
        'ToolTip4
        '
        Me.ToolTip4.Active = False
        Me.ToolTip4.IsBalloon = True
        Me.ToolTip4.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.ToolTip4.ToolTipTitle = "Caps Lock is On!"
        '
        'lblKeyNotUsed
        '
        Me.lblKeyNotUsed.AutoSize = True
        Me.lblKeyNotUsed.BackColor = System.Drawing.Color.Gold
        Me.lblKeyNotUsed.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKeyNotUsed.Location = New System.Drawing.Point(523, 92)
        Me.lblKeyNotUsed.Name = "lblKeyNotUsed"
        Me.lblKeyNotUsed.Size = New System.Drawing.Size(85, 16)
        Me.lblKeyNotUsed.TabIndex = 45
        Me.lblKeyNotUsed.Text = "Key not used"
        Me.lblKeyNotUsed.Visible = False
        '
        'tmrAutoClose
        '
        Me.tmrAutoClose.Enabled = True
        Me.tmrAutoClose.Interval = 1000
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = True
        Me.chkShowPassword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkShowPassword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowPassword.Location = New System.Drawing.Point(152, 88)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(124, 20)
        Me.chkShowPassword.TabIndex = 44
        Me.chkShowPassword.Text = "Show Password:"
        Me.ToolTip2.SetToolTip(Me.chkShowPassword, "Check this box to have TrulyMail remember your password (not ask you in the futur" & _
        "e)")
        Me.chkShowPassword.UseVisualStyleBackColor = True
        '
        'Keyboardcontrol1
        '
        Me.Keyboardcontrol1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Keyboardcontrol1.KeyboardType = KeyboardClassLibrary.BoW.Standard
        Me.Keyboardcontrol1.Location = New System.Drawing.Point(-2, 114)
        Me.Keyboardcontrol1.Margin = New System.Windows.Forms.Padding(4)
        Me.Keyboardcontrol1.Name = "Keyboardcontrol1"
        Me.Keyboardcontrol1.Size = New System.Drawing.Size(436, 15)
        Me.Keyboardcontrol1.TabIndex = 42
        Me.Keyboardcontrol1.Visible = False
        '
        'txtServer
        '
        Me.txtServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServer.Enabled = False
        Me.txtServer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServer.Location = New System.Drawing.Point(81, 3)
        Me.txtServer.MaxLength = 50
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(298, 22)
        Me.txtServer.TabIndex = 40
        '
        'pbKeyboard
        '
        Me.pbKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbKeyboard.Image = Global.TrulyMail.My.Resources.Resources.keyboard_white
        Me.pbKeyboard.Location = New System.Drawing.Point(362, 92)
        Me.pbKeyboard.Name = "pbKeyboard"
        Me.pbKeyboard.Size = New System.Drawing.Size(46, 13)
        Me.pbKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbKeyboard.TabIndex = 41
        Me.pbKeyboard.TabStop = False
        Me.ToolTip2.SetToolTip(Me.pbKeyboard, "Show / hide on-screen keyboard")
        '
        'ToolTip1
        '
        Me.ToolTip1.Active = False
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.ToolTip1.ToolTipTitle = "Caps Lock is On!"
        '
        'chkRememberPassword
        '
        Me.chkRememberPassword.AutoSize = True
        Me.chkRememberPassword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRememberPassword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRememberPassword.Location = New System.Drawing.Point(4, 88)
        Me.chkRememberPassword.Name = "chkRememberPassword"
        Me.chkRememberPassword.Size = New System.Drawing.Size(94, 20)
        Me.chkRememberPassword.TabIndex = 34
        Me.chkRememberPassword.Text = "Remember:"
        Me.ToolTip2.SetToolTip(Me.chkRememberPassword, "Check this box to have TrulyMail remember your password (not ask you in the futur" & _
        "e)")
        Me.chkRememberPassword.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.Enabled = False
        Me.btnOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(218, 135)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 27)
        Me.btnOK.TabIndex = 35
        Me.btnOK.Text = "&Login"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(122, 135)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 27)
        Me.btnCancel.TabIndex = 36
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Username:"
        '
        'txtUsername
        '
        Me.txtUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUsername.Enabled = False
        Me.txtUsername.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(81, 32)
        Me.txtUsername.MaxLength = 50
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(339, 22)
        Me.txtUsername.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Server:"
        '
        'tmrHideMessage
        '
        Me.tmrHideMessage.Interval = 500
        '
        'btnKBAbc
        '
        Me.btnKBAbc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKBAbc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKBAbc.Location = New System.Drawing.Point(62, 2)
        Me.btnKBAbc.Name = "btnKBAbc"
        Me.btnKBAbc.Size = New System.Drawing.Size(60, 25)
        Me.btnKBAbc.TabIndex = 12
        Me.btnKBAbc.Text = "&Abc"
        Me.ToolTip2.SetToolTip(Me.btnKBAbc, "Use alphabetical keyboard layout")
        Me.btnKBAbc.UseVisualStyleBackColor = True
        '
        'btnKBQwerty
        '
        Me.btnKBQwerty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKBQwerty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKBQwerty.Location = New System.Drawing.Point(122, 2)
        Me.btnKBQwerty.Name = "btnKBQwerty"
        Me.btnKBQwerty.Size = New System.Drawing.Size(60, 25)
        Me.btnKBQwerty.TabIndex = 11
        Me.btnKBQwerty.Text = "&Qwerty"
        Me.ToolTip2.SetToolTip(Me.btnKBQwerty, "Use QWERTY / standard keyboard layout")
        Me.btnKBQwerty.UseVisualStyleBackColor = True
        '
        'btnKBFun
        '
        Me.btnKBFun.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKBFun.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKBFun.Location = New System.Drawing.Point(2, 2)
        Me.btnKBFun.Name = "btnKBFun"
        Me.btnKBFun.Size = New System.Drawing.Size(60, 25)
        Me.btnKBFun.TabIndex = 13
        Me.btnKBFun.Text = "&Fun"
        Me.ToolTip2.SetToolTip(Me.btnKBFun, "Use fun keyboard layout")
        Me.btnKBFun.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(81, 60)
        Me.txtPassword.MaxLength = 50
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(339, 22)
        Me.txtPassword.TabIndex = 46
        '
        'pbContactType
        '
        Me.pbContactType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbContactType.Location = New System.Drawing.Point(388, 0)
        Me.pbContactType.Name = "pbContactType"
        Me.pbContactType.Size = New System.Drawing.Size(32, 32)
        Me.pbContactType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbContactType.TabIndex = 47
        Me.pbContactType.TabStop = False
        '
        'pnlKBType
        '
        Me.pnlKBType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlKBType.Controls.Add(Me.btnKBFun)
        Me.pnlKBType.Controls.Add(Me.btnKBQwerty)
        Me.pnlKBType.Controls.Add(Me.btnKBAbc)
        Me.pnlKBType.Location = New System.Drawing.Point(249, 132)
        Me.pnlKBType.Name = "pnlKBType"
        Me.pnlKBType.Size = New System.Drawing.Size(185, 30)
        Me.pnlKBType.TabIndex = 43
        Me.pnlKBType.Visible = False
        '
        'Login
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(432, 164)
        Me.Controls.Add(Me.pbContactType)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblKeyNotUsed)
        Me.Controls.Add(Me.chkShowPassword)
        Me.Controls.Add(Me.pnlKBType)
        Me.Controls.Add(Me.Keyboardcontrol1)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.pbKeyboard)
        Me.Controls.Add(Me.chkRememberPassword)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.Text = "Login"
        Me.TopMost = True
        CType(Me.pbKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbContactType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlKBType.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip4 As System.Windows.Forms.ToolTip
    Friend WithEvents lblKeyNotUsed As System.Windows.Forms.Label
    Friend WithEvents tmrAutoClose As System.Windows.Forms.Timer
    Friend WithEvents chkShowPassword As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents Keyboardcontrol1 As KeyboardClassLibrary.Keyboardcontrol
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents pbKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkRememberPassword As System.Windows.Forms.CheckBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tmrHideMessage As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents pbContactType As System.Windows.Forms.PictureBox
    Friend WithEvents tmrSetSize As System.Windows.Forms.Timer
    Friend WithEvents btnKBAbc As System.Windows.Forms.Button
    Friend WithEvents btnKBQwerty As System.Windows.Forms.Button
    Friend WithEvents btnKBFun As System.Windows.Forms.Button
    Friend WithEvents pnlKBType As System.Windows.Forms.Panel

End Class
