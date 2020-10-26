<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DuplicateMessageFinderProgressForm
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
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblTotalComparisonsToMake = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblComparisonInfo = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblOverallStep = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.pbComparisonInfo = New System.Windows.Forms.PictureBox()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.prgOverallStep = New MontgomerySoftware.Controls.ProgressBar()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.pbComparisonInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.lblTotalComparisonsToMake)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel.Controls.Add(Me.lblComparisonInfo)
        Me.KryptonPanel.Controls.Add(Me.lblOverallStep)
        Me.KryptonPanel.Controls.Add(Me.pbComparisonInfo)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.prgOverallStep)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(531, 191)
        Me.KryptonPanel.TabIndex = 0
        '
        'lblTotalComparisonsToMake
        '
        Me.lblTotalComparisonsToMake.Location = New System.Drawing.Point(199, 70)
        Me.lblTotalComparisonsToMake.Name = "lblTotalComparisonsToMake"
        Me.lblTotalComparisonsToMake.Palette = Me.KryptonPalette1
        Me.lblTotalComparisonsToMake.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.lblTotalComparisonsToMake.Size = New System.Drawing.Size(18, 19)
        Me.lblTotalComparisonsToMake.TabIndex = 70
        Me.lblTotalComparisonsToMake.Values.Text = "0"
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(12, 70)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Palette = Me.KryptonPalette1
        Me.KryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel1.Size = New System.Drawing.Size(181, 19)
        Me.KryptonLabel1.TabIndex = 69
        Me.KryptonLabel1.Values.Text = "Total comparisons* to make:"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(12, 42)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Palette = Me.KryptonPalette1
        Me.KryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel2.Size = New System.Drawing.Size(117, 19)
        Me.KryptonLabel2.TabIndex = 68
        Me.KryptonLabel2.Values.Text = "Current message:"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(12, 16)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Palette = Me.KryptonPalette1
        Me.KryptonLabel4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel4.Size = New System.Drawing.Size(68, 19)
        Me.KryptonLabel4.TabIndex = 67
        Me.KryptonLabel4.Values.Text = "Progress:"
        '
        'lblComparisonInfo
        '
        Me.lblComparisonInfo.Location = New System.Drawing.Point(12, 96)
        Me.lblComparisonInfo.Name = "lblComparisonInfo"
        Me.lblComparisonInfo.Palette = Me.KryptonPalette1
        Me.lblComparisonInfo.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.lblComparisonInfo.Size = New System.Drawing.Size(460, 19)
        Me.lblComparisonInfo.TabIndex = 66
        Me.lblComparisonInfo.Values.Text = "* must compare message 1 to 2, 3, and 4 then 2 to 3 and 4, then 3 to 4, etc."
        Me.lblComparisonInfo.Visible = False
        '
        'lblOverallStep
        '
        Me.lblOverallStep.Location = New System.Drawing.Point(135, 42)
        Me.lblOverallStep.Name = "lblOverallStep"
        Me.lblOverallStep.Palette = Me.KryptonPalette1
        Me.lblOverallStep.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.lblOverallStep.Size = New System.Drawing.Size(44, 19)
        Me.lblOverallStep.TabIndex = 65
        Me.lblOverallStep.Values.Text = "0 of 0"
        '
        'pbComparisonInfo
        '
        Me.pbComparisonInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbComparisonInfo.BackColor = System.Drawing.Color.Transparent
        Me.pbComparisonInfo.Image = Global.TrulyMail.My.Resources.Resources.info_32
        Me.pbComparisonInfo.Location = New System.Drawing.Point(284, 62)
        Me.pbComparisonInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbComparisonInfo.Name = "pbComparisonInfo"
        Me.pbComparisonInfo.Size = New System.Drawing.Size(26, 27)
        Me.pbComparisonInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbComparisonInfo.TabIndex = 63
        Me.pbComparisonInfo.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(185, 149)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Palette = Me.KryptonPalette1
        Me.btnCancel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnCancel.Size = New System.Drawing.Size(163, 30)
        Me.btnCancel.TabIndex = 58
        Me.btnCancel.Values.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'prgOverallStep
        '
        Me.prgOverallStep.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prgOverallStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.prgOverallStep.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prgOverallStep.ForeColor = System.Drawing.Color.Blue
        Me.prgOverallStep.HighLowCutoff = CType(50, Byte)
        Me.prgOverallStep.HighTextDecimalPlaces = CType(2, Byte)
        Me.prgOverallStep.Location = New System.Drawing.Point(86, 16)
        Me.prgOverallStep.LowTextDecimalPlaces = CType(2, Byte)
        Me.prgOverallStep.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.prgOverallStep.Maximum = CType(4, Long)
        Me.prgOverallStep.Minimum = CType(0, Long)
        Me.prgOverallStep.Name = "prgOverallStep"
        Me.prgOverallStep.Size = New System.Drawing.Size(433, 19)
        Me.prgOverallStep.TabIndex = 54
        Me.prgOverallStep.Value = CType(0, Long)
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPalette = Me.KryptonPalette1
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom
        '
        'DuplicateMessageFinderProgressForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(531, 191)
        Me.Controls.Add(Me.KryptonPanel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DuplicateMessageFinderProgressForm"
        Me.Palette = Me.KryptonPalette1
        Me.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.ShowIcon = False
        Me.Text = "Finding Duplicate Messages"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.pbComparisonInfo, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents prgOverallStep As MontgomerySoftware.Controls.ProgressBar
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents pbComparisonInfo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTotalComparisonsToMake As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblComparisonInfo As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblOverallStep As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
