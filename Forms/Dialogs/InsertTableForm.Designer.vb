<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InsertTableForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InsertTableForm))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnBGColor = New ComponentFactory.Krypton.Toolkit.KryptonColorButton()
        Me.chkFullWidth = New ComponentFactory.Krypton.Toolkit.KryptonCheckBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lblEmailAddress = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.nudBorder = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.nudColumns = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.nudRows = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.PictureBox2)
        Me.KryptonPanel.Controls.Add(Me.btnBGColor)
        Me.KryptonPanel.Controls.Add(Me.chkFullWidth)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Controls.Add(Me.lblEmailAddress)
        Me.KryptonPanel.Controls.Add(Me.nudBorder)
        Me.KryptonPanel.Controls.Add(Me.nudColumns)
        Me.KryptonPanel.Controls.Add(Me.nudRows)
        Me.KryptonPanel.Controls.Add(Me.PictureBox1)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(242, 438)
        Me.KryptonPanel.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(156, 331)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(74, 26)
        Me.PictureBox2.TabIndex = 53
        Me.PictureBox2.TabStop = False
        '
        'btnBGColor
        '
        Me.btnBGColor.Location = New System.Drawing.Point(12, 331)
        Me.btnBGColor.Name = "btnBGColor"
        Me.btnBGColor.SelectedColor = System.Drawing.Color.Transparent
        Me.btnBGColor.Size = New System.Drawing.Size(119, 25)
        Me.btnBGColor.Splitter = False
        Me.btnBGColor.TabIndex = 52
        Me.btnBGColor.Values.Image = Nothing
        Me.btnBGColor.Values.Text = "Background"
        '
        'chkFullWidth
        '
        Me.chkFullWidth.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl
        Me.chkFullWidth.Location = New System.Drawing.Point(19, 359)
        Me.chkFullWidth.Name = "chkFullWidth"
        Me.chkFullWidth.Size = New System.Drawing.Size(96, 19)
        Me.chkFullWidth.TabIndex = 50
        Me.chkFullWidth.Text = "100% Width"
        Me.chkFullWidth.Values.Text = "100% Width"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(12, 301)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(55, 19)
        Me.KryptonLabel2.TabIndex = 49
        Me.KryptonLabel2.Values.Text = "Border:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(12, 275)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(67, 19)
        Me.KryptonLabel1.TabIndex = 48
        Me.KryptonLabel1.Values.Text = "Columns:"
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(12, 247)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(48, 19)
        Me.lblEmailAddress.TabIndex = 47
        Me.lblEmailAddress.Values.Text = "Rows:"
        '
        'nudBorder
        '
        Me.nudBorder.Location = New System.Drawing.Point(156, 303)
        Me.nudBorder.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudBorder.Name = "nudBorder"
        Me.nudBorder.Size = New System.Drawing.Size(74, 21)
        Me.nudBorder.TabIndex = 46
        Me.nudBorder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudBorder.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudColumns
        '
        Me.nudColumns.Location = New System.Drawing.Point(156, 275)
        Me.nudColumns.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudColumns.Name = "nudColumns"
        Me.nudColumns.Size = New System.Drawing.Size(74, 21)
        Me.nudColumns.TabIndex = 45
        Me.nudColumns.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudColumns.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudRows
        '
        Me.nudRows.Location = New System.Drawing.Point(156, 247)
        Me.nudRows.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudRows.Name = "nudRows"
        Me.nudRows.Size = New System.Drawing.Size(74, 21)
        Me.nudRows.TabIndex = 44
        Me.nudRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudRows.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.TrulyMail.My.Resources.Resources.Grid_240
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(242, 241)
        Me.PictureBox1.TabIndex = 43
        Me.PictureBox1.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.Location = New System.Drawing.Point(38, 401)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(74, 25)
        Me.btnCancel.TabIndex = 42
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.Location = New System.Drawing.Point(132, 401)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(74, 25)
        Me.btnOK.TabIndex = 41
        Me.btnOK.Values.Text = "&OK"
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
        'InsertTableForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(242, 438)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "InsertTableForm"
        Me.Text = "Insert Table"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents nudBorder As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents nudColumns As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents nudRows As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblEmailAddress As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnBGColor As ComponentFactory.Krypton.Toolkit.KryptonColorButton
    Friend WithEvents chkFullWidth As ComponentFactory.Krypton.Toolkit.KryptonCheckBox
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
End Class
