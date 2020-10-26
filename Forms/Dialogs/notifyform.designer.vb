<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotifyForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotifyForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkDoNotShowAgain = New System.Windows.Forms.CheckBox()
        Me.tmrAutoClose = New System.Windows.Forms.Timer(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnNo = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnYes = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'chkDoNotShowAgain
        '
        Me.chkDoNotShowAgain.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.chkDoNotShowAgain.AutoSize = True
        Me.chkDoNotShowAgain.BackColor = System.Drawing.Color.Transparent
        Me.chkDoNotShowAgain.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDoNotShowAgain.Location = New System.Drawing.Point(26, 86)
        Me.chkDoNotShowAgain.Name = "chkDoNotShowAgain"
        Me.chkDoNotShowAgain.Size = New System.Drawing.Size(159, 20)
        Me.chkDoNotShowAgain.TabIndex = 4
        Me.chkDoNotShowAgain.Text = "Do not show this again"
        Me.chkDoNotShowAgain.UseVisualStyleBackColor = False
        '
        'tmrAutoClose
        '
        Me.tmrAutoClose.Interval = 1000
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.btnNo)
        Me.KryptonPanel.Controls.Add(Me.btnYes)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.Label1)
        Me.KryptonPanel.Controls.Add(Me.chkDoNotShowAgain)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(219, 154)
        Me.KryptonPanel.TabIndex = 54
        '
        'btnNo
        '
        Me.btnNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNo.DialogResult = System.Windows.Forms.DialogResult.No
        Me.btnNo.Location = New System.Drawing.Point(115, 112)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(92, 29)
        Me.btnNo.TabIndex = 64
        Me.btnNo.Values.Image = Global.TrulyMail.My.Resources.Resources.erase_trans_16
        Me.btnNo.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnNo.Values.Text = "&No"
        Me.btnNo.Visible = False
        '
        'btnYes
        '
        Me.btnYes.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btnYes.Location = New System.Drawing.Point(12, 113)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(92, 29)
        Me.btnYes.TabIndex = 63
        Me.btnYes.Values.Image = Global.TrulyMail.My.Resources.Resources.CheckMark_16
        Me.btnYes.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnYes.Values.Text = "&Yes"
        Me.btnYes.Visible = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(62, 112)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(92, 29)
        Me.btnOK.TabIndex = 62
        Me.btnOK.Values.Image = Global.TrulyMail.My.Resources.Resources.CheckMark_16
        Me.btnOK.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnOK.Values.Text = "&OK"
        Me.btnOK.Visible = False
        '
        'KryptonManager
        '
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonManager.GlobalPalette = Me.KryptonPalette1
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'NotifyForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(219, 154)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NotifyForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "NotifyForm"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkDoNotShowAgain As System.Windows.Forms.CheckBox
    Friend WithEvents tmrAutoClose As System.Windows.Forms.Timer
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnNo As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnYes As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
End Class
