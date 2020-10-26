<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginK
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginK))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblKeyNotUsed = New System.Windows.Forms.Label()
        Me.pnlKBType = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkbtnKBRandom = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.chkbtnKBFun = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.chkbtnKBABC = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.chkbtnKBQwerty = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.Keyboardcontrol1 = New KeyboardClassLibrary.Keyboardcontrol()
        Me.pbKeyboard = New System.Windows.Forms.PictureBox()
        Me.chkShowPassword = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.chkRememberPassword = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtPassword = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtUsername = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.pbContactType = New System.Windows.Forms.PictureBox()
        Me.txtServer = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.lblEmailAddress = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrAutoClose = New System.Windows.Forms.Timer(Me.components)
        Me.tmrSetSize = New System.Windows.Forms.Timer(Me.components)
        Me.tmrHideMessage = New System.Windows.Forms.Timer(Me.components)
        Me.KryptonCheckSet1 = New ComponentFactory.Krypton.Toolkit.KryptonCheckSet(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.pnlKBType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlKBType.SuspendLayout()
        CType(Me.pbKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbContactType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonCheckSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.lblKeyNotUsed)
        Me.KryptonPanel.Controls.Add(Me.pnlKBType)
        Me.KryptonPanel.Controls.Add(Me.Keyboardcontrol1)
        Me.KryptonPanel.Controls.Add(Me.pbKeyboard)
        Me.KryptonPanel.Controls.Add(Me.chkShowPassword)
        Me.KryptonPanel.Controls.Add(Me.chkRememberPassword)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.txtPassword)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel.Controls.Add(Me.txtUsername)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Controls.Add(Me.pbContactType)
        Me.KryptonPanel.Controls.Add(Me.txtServer)
        Me.KryptonPanel.Controls.Add(Me.lblEmailAddress)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(452, 168)
        Me.KryptonPanel.TabIndex = 0
        '
        'lblKeyNotUsed
        '
        Me.lblKeyNotUsed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblKeyNotUsed.AutoSize = True
        Me.lblKeyNotUsed.BackColor = System.Drawing.Color.Gold
        Me.lblKeyNotUsed.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKeyNotUsed.Location = New System.Drawing.Point(301, 95)
        Me.lblKeyNotUsed.Name = "lblKeyNotUsed"
        Me.lblKeyNotUsed.Size = New System.Drawing.Size(85, 16)
        Me.lblKeyNotUsed.TabIndex = 46
        Me.lblKeyNotUsed.Text = "Key not used"
        Me.lblKeyNotUsed.Visible = False
        '
        'pnlKBType
        '
        Me.pnlKBType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlKBType.Controls.Add(Me.chkbtnKBRandom)
        Me.pnlKBType.Controls.Add(Me.chkbtnKBFun)
        Me.pnlKBType.Controls.Add(Me.chkbtnKBABC)
        Me.pnlKBType.Controls.Add(Me.chkbtnKBQwerty)
        Me.pnlKBType.Location = New System.Drawing.Point(259, 130)
        Me.pnlKBType.Name = "pnlKBType"
        Me.pnlKBType.Size = New System.Drawing.Size(193, 38)
        Me.pnlKBType.TabIndex = 59
        Me.pnlKBType.Visible = False
        '
        'chkbtnKBRandom
        '
        Me.chkbtnKBRandom.Location = New System.Drawing.Point(129, 3)
        Me.chkbtnKBRandom.Name = "chkbtnKBRandom"
        Me.chkbtnKBRandom.Size = New System.Drawing.Size(60, 25)
        Me.chkbtnKBRandom.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.chkbtnKBRandom, "Choose random to make it much more difficult for mouse-click loggers to track you" & _
        "")
        Me.chkbtnKBRandom.Values.Text = "Random"
        '
        'chkbtnKBFun
        '
        Me.chkbtnKBFun.Location = New System.Drawing.Point(2, 3)
        Me.chkbtnKBFun.Name = "chkbtnKBFun"
        Me.chkbtnKBFun.Size = New System.Drawing.Size(40, 25)
        Me.chkbtnKBFun.TabIndex = 2
        Me.chkbtnKBFun.Values.Text = "Fun"
        '
        'chkbtnKBABC
        '
        Me.chkbtnKBABC.Location = New System.Drawing.Point(45, 3)
        Me.chkbtnKBABC.Name = "chkbtnKBABC"
        Me.chkbtnKBABC.Size = New System.Drawing.Size(40, 25)
        Me.chkbtnKBABC.TabIndex = 1
        Me.chkbtnKBABC.Values.Text = "ABC"
        '
        'chkbtnKBQwerty
        '
        Me.chkbtnKBQwerty.Checked = True
        Me.chkbtnKBQwerty.Location = New System.Drawing.Point(87, 3)
        Me.chkbtnKBQwerty.Name = "chkbtnKBQwerty"
        Me.chkbtnKBQwerty.Size = New System.Drawing.Size(40, 25)
        Me.chkbtnKBQwerty.TabIndex = 0
        Me.chkbtnKBQwerty.Values.Text = "QWE"
        '
        'Keyboardcontrol1
        '
        Me.Keyboardcontrol1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Keyboardcontrol1.KeyboardType = KeyboardClassLibrary.BoW.Standard
        Me.Keyboardcontrol1.Location = New System.Drawing.Point(-7, 119)
        Me.Keyboardcontrol1.Margin = New System.Windows.Forms.Padding(4)
        Me.Keyboardcontrol1.Name = "Keyboardcontrol1"
        Me.Keyboardcontrol1.Size = New System.Drawing.Size(466, 4)
        Me.Keyboardcontrol1.TabIndex = 58
        Me.Keyboardcontrol1.Visible = False
        '
        'pbKeyboard
        '
        Me.pbKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbKeyboard.Image = Global.TrulyMail.My.Resources.Resources.keyboard_white
        Me.pbKeyboard.Location = New System.Drawing.Point(394, 96)
        Me.pbKeyboard.Name = "pbKeyboard"
        Me.pbKeyboard.Size = New System.Drawing.Size(46, 13)
        Me.pbKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbKeyboard.TabIndex = 57
        Me.pbKeyboard.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbKeyboard, "Show / hide on-screen keyboard")
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = False
        Me.chkShowPassword.CheckPosition = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right
        Me.chkShowPassword.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkShowPassword.Location = New System.Drawing.Point(185, 92)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Palette = Me.KryptonPalette1
        Me.chkShowPassword.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkShowPassword.Size = New System.Drawing.Size(148, 19)
        Me.chkShowPassword.TabIndex = 56
        Me.chkShowPassword.Text = "Show password:"
        Me.ToolTip1.SetToolTip(Me.chkShowPassword, "Check this box to show your password as you type it (make sure no one is looking)" & _
        "")
        Me.chkShowPassword.Values.Text = "Show password:"
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'chkRememberPassword
        '
        Me.chkRememberPassword.AutoSize = False
        Me.chkRememberPassword.CheckPosition = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right
        Me.chkRememberPassword.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkRememberPassword.Location = New System.Drawing.Point(12, 92)
        Me.chkRememberPassword.Name = "chkRememberPassword"
        Me.chkRememberPassword.Palette = Me.KryptonPalette1
        Me.chkRememberPassword.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkRememberPassword.Size = New System.Drawing.Size(118, 19)
        Me.chkRememberPassword.TabIndex = 55
        Me.chkRememberPassword.Text = "Remember:"
        Me.ToolTip1.SetToolTip(Me.chkRememberPassword, "Check this box to have TrulyMail remember your password (not ask you in the futur" & _
        "e)")
        Me.chkRememberPassword.Values.Text = "Remember:"
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.Location = New System.Drawing.Point(233, 131)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Palette = Me.KryptonPalette1
        Me.btnOK.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnOK.Size = New System.Drawing.Size(105, 30)
        Me.btnOK.TabIndex = 54
        Me.btnOK.Values.Image = Global.TrulyMail.My.Resources.Resources.CheckMark_16
        Me.btnOK.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnOK.Values.Text = "&Login"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(121, 131)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Palette = Me.KryptonPalette1
        Me.btnCancel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnCancel.Size = New System.Drawing.Size(105, 30)
        Me.btnCancel.TabIndex = 53
        Me.btnCancel.Values.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(117, 62)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Palette = Me.KryptonPalette1
        Me.txtPassword.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(281, 19)
        Me.txtPassword.TabIndex = 52
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(12, 62)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Palette = Me.KryptonPalette1
        Me.KryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel2.Size = New System.Drawing.Size(73, 19)
        Me.KryptonLabel2.TabIndex = 51
        Me.KryptonLabel2.Values.Text = "Password:"
        '
        'txtUsername
        '
        Me.txtUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUsername.Location = New System.Drawing.Point(117, 37)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Palette = Me.KryptonPalette1
        Me.txtUsername.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtUsername.Size = New System.Drawing.Size(281, 19)
        Me.txtUsername.TabIndex = 50
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(12, 37)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Palette = Me.KryptonPalette1
        Me.KryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel1.Size = New System.Drawing.Size(76, 19)
        Me.KryptonLabel1.TabIndex = 49
        Me.KryptonLabel1.Values.Text = "Username:"
        '
        'pbContactType
        '
        Me.pbContactType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbContactType.BackColor = System.Drawing.Color.Transparent
        Me.pbContactType.Location = New System.Drawing.Point(408, 12)
        Me.pbContactType.Name = "pbContactType"
        Me.pbContactType.Size = New System.Drawing.Size(32, 32)
        Me.pbContactType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbContactType.TabIndex = 48
        Me.pbContactType.TabStop = False
        '
        'txtServer
        '
        Me.txtServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServer.Location = New System.Drawing.Point(117, 12)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Palette = Me.KryptonPalette1
        Me.txtServer.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtServer.Size = New System.Drawing.Size(281, 19)
        Me.txtServer.TabIndex = 8
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(12, 12)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Palette = Me.KryptonPalette1
        Me.lblEmailAddress.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.lblEmailAddress.Size = New System.Drawing.Size(54, 19)
        Me.lblEmailAddress.TabIndex = 7
        Me.lblEmailAddress.Values.Text = "Server:"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPalette = Me.KryptonPalette1
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom
        '
        'tmrAutoClose
        '
        Me.tmrAutoClose.Enabled = True
        Me.tmrAutoClose.Interval = 1000
        '
        'tmrSetSize
        '
        Me.tmrSetSize.Enabled = True
        Me.tmrSetSize.Interval = 1000
        '
        'tmrHideMessage
        '
        Me.tmrHideMessage.Interval = 500
        '
        'KryptonCheckSet1
        '
        Me.KryptonCheckSet1.CheckButtons.Add(Me.chkbtnKBRandom)
        Me.KryptonCheckSet1.CheckButtons.Add(Me.chkbtnKBFun)
        Me.KryptonCheckSet1.CheckButtons.Add(Me.chkbtnKBABC)
        Me.KryptonCheckSet1.CheckButtons.Add(Me.chkbtnKBQwerty)
        Me.KryptonCheckSet1.CheckedButton = Me.chkbtnKBQwerty
        '
        'LoginK
        '
        Me.AcceptButton = Me.btnOK
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(452, 168)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginK"
        Me.Palette = Me.KryptonPalette1
        Me.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Login"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.pnlKBType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlKBType.ResumeLayout(False)
        CType(Me.pbKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbContactType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonCheckSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents txtServer As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents lblEmailAddress As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents pbContactType As System.Windows.Forms.PictureBox
    Friend WithEvents txtPassword As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtUsername As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents chkRememberPassword As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkShowPassword As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents pbKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Keyboardcontrol1 As KeyboardClassLibrary.Keyboardcontrol
    Friend WithEvents pnlKBType As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents tmrAutoClose As System.Windows.Forms.Timer
    Friend WithEvents tmrSetSize As System.Windows.Forms.Timer
    Friend WithEvents tmrHideMessage As System.Windows.Forms.Timer
    Friend WithEvents lblKeyNotUsed As System.Windows.Forms.Label
    Friend WithEvents chkbtnKBRandom As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents chkbtnKBFun As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents chkbtnKBABC As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents chkbtnKBQwerty As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonCheckSet1 As ComponentFactory.Krypton.Toolkit.KryptonCheckSet
End Class
