<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EncryptedWebmailPasswordSelector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EncryptedWebmailPasswordSelector))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkSavePasswordWithContacts = New System.Windows.Forms.CheckBox()
        Me.lblPasswordStrength = New System.Windows.Forms.Label()
        Me.lblPasswordStrengthCaption = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblAttachmentPassword = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.chkShowPassword)
        Me.KryptonPanel.Controls.Add(Me.chkSavePasswordWithContacts)
        Me.KryptonPanel.Controls.Add(Me.lblPasswordStrength)
        Me.KryptonPanel.Controls.Add(Me.lblPasswordStrengthCaption)
        Me.KryptonPanel.Controls.Add(Me.txtPassword)
        Me.KryptonPanel.Controls.Add(Me.lblAttachmentPassword)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.Label5)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(612, 259)
        Me.KryptonPanel.TabIndex = 8
        '
        'chkSavePasswordWithContacts
        '
        Me.chkSavePasswordWithContacts.AutoSize = True
        Me.chkSavePasswordWithContacts.BackColor = System.Drawing.Color.Transparent
        Me.chkSavePasswordWithContacts.Location = New System.Drawing.Point(86, 42)
        Me.chkSavePasswordWithContacts.Name = "chkSavePasswordWithContacts"
        Me.chkSavePasswordWithContacts.Size = New System.Drawing.Size(194, 20)
        Me.chkSavePasswordWithContacts.TabIndex = 63
        Me.chkSavePasswordWithContacts.Text = "Save password for contact(s)"
        Me.chkSavePasswordWithContacts.UseVisualStyleBackColor = False
        '
        'lblPasswordStrength
        '
        Me.lblPasswordStrength.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPasswordStrength.AutoSize = True
        Me.lblPasswordStrength.BackColor = System.Drawing.Color.Transparent
        Me.lblPasswordStrength.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasswordStrength.Location = New System.Drawing.Point(507, 39)
        Me.lblPasswordStrength.Name = "lblPasswordStrength"
        Me.lblPasswordStrength.Size = New System.Drawing.Size(0, 16)
        Me.lblPasswordStrength.TabIndex = 62
        Me.lblPasswordStrength.Visible = False
        '
        'lblPasswordStrengthCaption
        '
        Me.lblPasswordStrengthCaption.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPasswordStrengthCaption.AutoSize = True
        Me.lblPasswordStrengthCaption.BackColor = System.Drawing.Color.Transparent
        Me.lblPasswordStrengthCaption.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasswordStrengthCaption.Location = New System.Drawing.Point(440, 39)
        Me.lblPasswordStrengthCaption.Name = "lblPasswordStrengthCaption"
        Me.lblPasswordStrengthCaption.Size = New System.Drawing.Size(61, 16)
        Me.lblPasswordStrengthCaption.TabIndex = 61
        Me.lblPasswordStrengthCaption.Text = "Strength:"
        Me.lblPasswordStrengthCaption.Visible = False
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(83, 14)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(522, 22)
        Me.txtPassword.TabIndex = 60
        Me.ToolTip1.SetToolTip(Me.txtPassword, "This is the password to open the .zip or .exe containing the attachments for this" & _
        " message." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Every recipient will have the same Attachment Password but can have" & _
        " different web message passwords.")
        '
        'lblAttachmentPassword
        '
        Me.lblAttachmentPassword.AutoSize = True
        Me.lblAttachmentPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblAttachmentPassword.Location = New System.Drawing.Point(8, 17)
        Me.lblAttachmentPassword.Name = "lblAttachmentPassword"
        Me.lblAttachmentPassword.Size = New System.Drawing.Size(69, 16)
        Me.lblAttachmentPassword.TabIndex = 59
        Me.lblAttachmentPassword.Text = "Password:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(591, 132)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(112, 208)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(163, 36)
        Me.btnCancel.TabIndex = 51
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(330, 208)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(163, 36)
        Me.btnOK.TabIndex = 50
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPalette = Me.KryptonPalette1
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom
        '
        'chkShowPassword
        '
        Me.chkShowPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShowPassword.AutoSize = True
        Me.chkShowPassword.BackColor = System.Drawing.Color.Transparent
        Me.chkShowPassword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkShowPassword.Location = New System.Drawing.Point(477, 58)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(122, 20)
        Me.chkShowPassword.TabIndex = 64
        Me.chkShowPassword.Text = "Show password:"
        Me.chkShowPassword.UseVisualStyleBackColor = False
        '
        'EncryptedWebmailPasswordSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(612, 259)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "EncryptedWebmailPasswordSelector"
        Me.Text = "Encryption Passwords"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents chkSavePasswordWithContacts As System.Windows.Forms.CheckBox
    Friend WithEvents lblPasswordStrength As System.Windows.Forms.Label
    Friend WithEvents lblPasswordStrengthCaption As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblAttachmentPassword As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents chkShowPassword As System.Windows.Forms.CheckBox
End Class
