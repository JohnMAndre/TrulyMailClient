<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetMasterPasswordK
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetMasterPasswordK))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblLocalEncryptionStatus = New System.Windows.Forms.Label()
        Me.lblPasswordStatus = New System.Windows.Forms.Label()
        Me.grpLocalEncryption = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.pbEncryptLocallyInfo = New System.Windows.Forms.PictureBox()
        Me.chkEncryptLocally = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chkShowPassword = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.lblPasswordStrength = New System.Windows.Forms.Label()
        Me.lblPasswordStrengthCaption = New System.Windows.Forms.Label()
        Me.lblPasswordsDoNotMatch = New System.Windows.Forms.Label()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txtConfirm = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtPassword = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.lblMessage = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.grpLocalEncryption.SuspendLayout()
        CType(Me.pbEncryptLocallyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.Label2)
        Me.KryptonPanel.Controls.Add(Me.Label1)
        Me.KryptonPanel.Controls.Add(Me.lblLocalEncryptionStatus)
        Me.KryptonPanel.Controls.Add(Me.lblPasswordStatus)
        Me.KryptonPanel.Controls.Add(Me.grpLocalEncryption)
        Me.KryptonPanel.Controls.Add(Me.PictureBox1)
        Me.KryptonPanel.Controls.Add(Me.chkShowPassword)
        Me.KryptonPanel.Controls.Add(Me.lblPasswordStrength)
        Me.KryptonPanel.Controls.Add(Me.lblPasswordStrengthCaption)
        Me.KryptonPanel.Controls.Add(Me.lblPasswordsDoNotMatch)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Controls.Add(Me.txtConfirm)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.txtPassword)
        Me.KryptonPanel.Controls.Add(Me.lblMessage)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(729, 534)
        Me.KryptonPanel.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 16)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Encryption status:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 16)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Password status:"
        '
        'lblLocalEncryptionStatus
        '
        Me.lblLocalEncryptionStatus.AutoSize = True
        Me.lblLocalEncryptionStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblLocalEncryptionStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocalEncryptionStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblLocalEncryptionStatus.Location = New System.Drawing.Point(135, 108)
        Me.lblLocalEncryptionStatus.Name = "lblLocalEncryptionStatus"
        Me.lblLocalEncryptionStatus.Size = New System.Drawing.Size(68, 16)
        Me.lblLocalEncryptionStatus.TabIndex = 60
        Me.lblLocalEncryptionStatus.Text = "Working..."
        '
        'lblPasswordStatus
        '
        Me.lblPasswordStatus.AutoSize = True
        Me.lblPasswordStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblPasswordStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasswordStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblPasswordStatus.Location = New System.Drawing.Point(135, 86)
        Me.lblPasswordStatus.Name = "lblPasswordStatus"
        Me.lblPasswordStatus.Size = New System.Drawing.Size(68, 16)
        Me.lblPasswordStatus.TabIndex = 60
        Me.lblPasswordStatus.Text = "Working..."
        '
        'grpLocalEncryption
        '
        Me.grpLocalEncryption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpLocalEncryption.AutoSize = True
        Me.grpLocalEncryption.BackColor = System.Drawing.Color.Transparent
        Me.grpLocalEncryption.Controls.Add(Me.Label3)
        Me.grpLocalEncryption.Controls.Add(Me.KryptonLabel3)
        Me.grpLocalEncryption.Controls.Add(Me.pbEncryptLocallyInfo)
        Me.grpLocalEncryption.Controls.Add(Me.chkEncryptLocally)
        Me.grpLocalEncryption.Controls.Add(Me.Label4)
        Me.grpLocalEncryption.Location = New System.Drawing.Point(12, 252)
        Me.grpLocalEncryption.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpLocalEncryption.Name = "grpLocalEncryption"
        Me.grpLocalEncryption.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpLocalEncryption.Size = New System.Drawing.Size(704, 204)
        Me.grpLocalEncryption.TabIndex = 55
        Me.grpLocalEncryption.TabStop = False
        Me.grpLocalEncryption.Text = "Encrypt locally"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(10, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(675, 36)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Important: Encrypting files will make TrulyMail slower (decrypting messages each " & _
    "time you select a different folder)."
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(9, 56)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Palette = Me.KryptonPalette1
        Me.KryptonLabel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel3.Size = New System.Drawing.Size(395, 79)
        Me.KryptonLabel3.TabIndex = 56
        Me.KryptonLabel3.Values.Text = "Your password will be used to protect your local messages, etc." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "TrulyMail does" & _
    " not keep copy of your password, anywhere." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Choose a password you can remember" & _
    " but others cannot guess."
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'pbEncryptLocallyInfo
        '
        Me.pbEncryptLocallyInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbEncryptLocallyInfo.Image = Global.TrulyMail.My.Resources.Resources.info_32
        Me.pbEncryptLocallyInfo.Location = New System.Drawing.Point(678, 7)
        Me.pbEncryptLocallyInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbEncryptLocallyInfo.Name = "pbEncryptLocallyInfo"
        Me.pbEncryptLocallyInfo.Size = New System.Drawing.Size(26, 27)
        Me.pbEncryptLocallyInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEncryptLocallyInfo.TabIndex = 30
        Me.pbEncryptLocallyInfo.TabStop = False
        '
        'chkEncryptLocally
        '
        Me.chkEncryptLocally.CheckPosition = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right
        Me.chkEncryptLocally.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkEncryptLocally.Location = New System.Drawing.Point(9, 26)
        Me.chkEncryptLocally.Name = "chkEncryptLocally"
        Me.chkEncryptLocally.Palette = Me.KryptonPalette1
        Me.chkEncryptLocally.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkEncryptLocally.Size = New System.Drawing.Size(179, 19)
        Me.chkEncryptLocally.TabIndex = 52
        Me.chkEncryptLocally.Text = "Encrypt messages locally:"
        Me.chkEncryptLocally.Values.Text = "Encrypt messages locally:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(618, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(99, 73)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 51
        Me.PictureBox1.TabStop = False
        '
        'chkShowPassword
        '
        Me.chkShowPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShowPassword.CheckPosition = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right
        Me.chkShowPassword.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkShowPassword.Location = New System.Drawing.Point(598, 204)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Palette = Me.KryptonPalette1
        Me.chkShowPassword.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkShowPassword.Size = New System.Drawing.Size(118, 19)
        Me.chkShowPassword.TabIndex = 2
        Me.chkShowPassword.Text = "Show password"
        Me.chkShowPassword.Values.Text = "Show password"
        '
        'lblPasswordStrength
        '
        Me.lblPasswordStrength.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPasswordStrength.AutoSize = True
        Me.lblPasswordStrength.BackColor = System.Drawing.Color.Transparent
        Me.lblPasswordStrength.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasswordStrength.Location = New System.Drawing.Point(627, 138)
        Me.lblPasswordStrength.Name = "lblPasswordStrength"
        Me.lblPasswordStrength.Size = New System.Drawing.Size(0, 16)
        Me.lblPasswordStrength.TabIndex = 50
        Me.ToolTip1.SetToolTip(Me.lblPasswordStrength, "To make your password stronger, add upper case (A) and lower case (a) and numbers" & _
        " (5) and symbols (&$€)")
        Me.lblPasswordStrength.Visible = False
        '
        'lblPasswordStrengthCaption
        '
        Me.lblPasswordStrengthCaption.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPasswordStrengthCaption.AutoSize = True
        Me.lblPasswordStrengthCaption.BackColor = System.Drawing.Color.Transparent
        Me.lblPasswordStrengthCaption.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasswordStrengthCaption.Location = New System.Drawing.Point(560, 138)
        Me.lblPasswordStrengthCaption.Name = "lblPasswordStrengthCaption"
        Me.lblPasswordStrengthCaption.Size = New System.Drawing.Size(61, 16)
        Me.lblPasswordStrengthCaption.TabIndex = 49
        Me.lblPasswordStrengthCaption.Text = "Strength:"
        Me.ToolTip1.SetToolTip(Me.lblPasswordStrengthCaption, "To make your password stronger, add upper case (A) and lower case (a) and numbers" & _
        " (5) and symbols (&$€)")
        Me.lblPasswordStrengthCaption.Visible = False
        '
        'lblPasswordsDoNotMatch
        '
        Me.lblPasswordsDoNotMatch.AutoSize = True
        Me.lblPasswordsDoNotMatch.BackColor = System.Drawing.Color.Transparent
        Me.lblPasswordsDoNotMatch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasswordsDoNotMatch.ForeColor = System.Drawing.Color.DarkRed
        Me.lblPasswordsDoNotMatch.Location = New System.Drawing.Point(88, 204)
        Me.lblPasswordsDoNotMatch.Name = "lblPasswordsDoNotMatch"
        Me.lblPasswordsDoNotMatch.Size = New System.Drawing.Size(162, 16)
        Me.lblPasswordsDoNotMatch.TabIndex = 48
        Me.lblPasswordsDoNotMatch.Text = "Passwords do not match"
        Me.lblPasswordsDoNotMatch.Visible = False
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(12, 157)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Palette = Me.KryptonPalette1
        Me.KryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel2.Size = New System.Drawing.Size(73, 19)
        Me.KryptonLabel2.TabIndex = 16
        Me.KryptonLabel2.Values.Text = "Password:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(12, 182)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Palette = Me.KryptonPalette1
        Me.KryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel1.Size = New System.Drawing.Size(61, 19)
        Me.KryptonLabel1.TabIndex = 15
        Me.KryptonLabel1.Values.Text = "Confirm:"
        '
        'txtConfirm
        '
        Me.txtConfirm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConfirm.Location = New System.Drawing.Point(90, 182)
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.Palette = Me.KryptonPalette1
        Me.txtConfirm.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirm.Size = New System.Drawing.Size(627, 19)
        Me.txtConfirm.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(243, 476)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Palette = Me.KryptonPalette1
        Me.btnCancel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnCancel.Size = New System.Drawing.Size(114, 46)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Values.Image = Global.TrulyMail.My.Resources.Resources.Erase_32
        Me.btnCancel.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.Location = New System.Drawing.Point(378, 476)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Palette = Me.KryptonPalette1
        Me.btnOK.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnOK.Size = New System.Drawing.Size(114, 46)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Values.Image = Global.TrulyMail.My.Resources.Resources.Savefile_32
        Me.btnOK.Values.Text = "&Save"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(90, 157)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Palette = Me.KryptonPalette1
        Me.txtPassword.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(627, 19)
        Me.txtPassword.TabIndex = 0
        '
        'lblMessage
        '
        Me.lblMessage.Location = New System.Drawing.Point(12, 12)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Palette = Me.KryptonPalette1
        Me.lblMessage.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.lblMessage.Size = New System.Drawing.Size(327, 49)
        Me.lblMessage.TabIndex = 10
        Me.lblMessage.Values.Text = "Please enter and confirm your new startup password." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Leave both blank to remove" & _
    " your startup password."
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkRed
        Me.Label4.Location = New System.Drawing.Point(203, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(469, 36)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Warning: ""Encrypt messages locally"" is in ""beta"" and should only be used by users" & _
    " willing to test less stable features."
        '
        'SetMasterPasswordK
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(729, 534)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SetMasterPasswordK"
        Me.Palette = Me.KryptonPalette1
        Me.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Set Startup Password"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.grpLocalEncryption.ResumeLayout(False)
        Me.grpLocalEncryption.PerformLayout()
        CType(Me.pbEncryptLocallyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtPassword As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents lblMessage As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txtConfirm As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblPasswordsDoNotMatch As System.Windows.Forms.Label
    Friend WithEvents lblPasswordStrength As System.Windows.Forms.Label
    Friend WithEvents lblPasswordStrengthCaption As System.Windows.Forms.Label
    Friend WithEvents chkShowPassword As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents chkEncryptLocally As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents grpLocalEncryption As System.Windows.Forms.GroupBox
    Friend WithEvents pbEncryptLocallyInfo As System.Windows.Forms.PictureBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLocalEncryptionStatus As System.Windows.Forms.Label
    Friend WithEvents lblPasswordStatus As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
