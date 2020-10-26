<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddressBookBackup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddressBookBackup))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblBackupStatus = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.pbLastBackupStatus = New System.Windows.Forms.PictureBox()
        Me.lblLastBackup = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.nudAutoBackupDays = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.chkAutoBackup = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.pbLastBackupStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.lblBackupStatus)
        Me.KryptonPanel.Controls.Add(Me.pbLastBackupStatus)
        Me.KryptonPanel.Controls.Add(Me.lblLastBackup)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel.Controls.Add(Me.nudAutoBackupDays)
        Me.KryptonPanel.Controls.Add(Me.chkAutoBackup)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(456, 164)
        Me.KryptonPanel.TabIndex = 0
        '
        'lblBackupStatus
        '
        Me.lblBackupStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblBackupStatus.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl
        Me.lblBackupStatus.Location = New System.Drawing.Point(44, 94)
        Me.lblBackupStatus.Name = "lblBackupStatus"
        Me.lblBackupStatus.Palette = Me.KryptonPalette1
        Me.lblBackupStatus.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.lblBackupStatus.Size = New System.Drawing.Size(354, 19)
        Me.lblBackupStatus.TabIndex = 64
        Me.lblBackupStatus.Values.Text = "Please wait while your address book is being backed up..."
        Me.lblBackupStatus.Visible = False
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'pbLastBackupStatus
        '
        Me.pbLastBackupStatus.BackColor = System.Drawing.Color.Transparent
        Me.pbLastBackupStatus.Location = New System.Drawing.Point(263, 13)
        Me.pbLastBackupStatus.Name = "pbLastBackupStatus"
        Me.pbLastBackupStatus.Size = New System.Drawing.Size(16, 16)
        Me.pbLastBackupStatus.TabIndex = 63
        Me.pbLastBackupStatus.TabStop = False
        '
        'lblLastBackup
        '
        Me.lblLastBackup.Location = New System.Drawing.Point(297, 12)
        Me.lblLastBackup.Name = "lblLastBackup"
        Me.lblLastBackup.Palette = Me.KryptonPalette1
        Me.lblLastBackup.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.lblLastBackup.Size = New System.Drawing.Size(60, 19)
        Me.lblLastBackup.TabIndex = 62
        Me.lblLastBackup.Values.Text = "<never>"
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.Location = New System.Drawing.Point(233, 122)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Palette = Me.KryptonPalette1
        Me.btnOK.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnOK.Size = New System.Drawing.Size(105, 30)
        Me.btnOK.TabIndex = 61
        Me.btnOK.Values.Image = Global.TrulyMail.My.Resources.Resources.CheckMark_16
        Me.btnOK.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnOK.Values.Text = "&Backup"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(121, 122)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Palette = Me.KryptonPalette1
        Me.btnCancel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnCancel.Size = New System.Drawing.Size(105, 30)
        Me.btnCancel.TabIndex = 60
        Me.btnCancel.Values.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(265, 36)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Palette = Me.KryptonPalette1
        Me.KryptonLabel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel3.Size = New System.Drawing.Size(43, 19)
        Me.KryptonLabel3.TabIndex = 58
        Me.KryptonLabel3.Values.Text = "days."
        '
        'nudAutoBackupDays
        '
        Me.nudAutoBackupDays.Enabled = False
        Me.nudAutoBackupDays.Location = New System.Drawing.Point(205, 36)
        Me.nudAutoBackupDays.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudAutoBackupDays.Name = "nudAutoBackupDays"
        Me.nudAutoBackupDays.Palette = Me.KryptonPalette1
        Me.nudAutoBackupDays.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.nudAutoBackupDays.Size = New System.Drawing.Size(54, 21)
        Me.nudAutoBackupDays.TabIndex = 57
        Me.nudAutoBackupDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudAutoBackupDays.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'chkAutoBackup
        '
        Me.chkAutoBackup.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkAutoBackup.Location = New System.Drawing.Point(12, 38)
        Me.chkAutoBackup.Name = "chkAutoBackup"
        Me.chkAutoBackup.Palette = Me.KryptonPalette1
        Me.chkAutoBackup.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.chkAutoBackup.Size = New System.Drawing.Size(187, 19)
        Me.chkAutoBackup.TabIndex = 56
        Me.chkAutoBackup.Text = "Automatically backup every"
        Me.chkAutoBackup.Values.Text = "Automatically backup every"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(12, 12)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Palette = Me.KryptonPalette1
        Me.KryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel1.Size = New System.Drawing.Size(245, 19)
        Me.KryptonLabel1.TabIndex = 9
        Me.KryptonLabel1.Values.Text = "Your address book was last backed up:"
        '
        'AddressBookBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 164)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AddressBookBackup"
        Me.Palette = Me.KryptonPalette1
        Me.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Address Book Backup"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.pbLastBackupStatus, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents chkAutoBackup As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents nudAutoBackupDays As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents lblLastBackup As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents pbLastBackupStatus As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblBackupStatus As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
