<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RemoteImagesSelector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RemoteImagesSelector))
        Me.olvURLs = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.btnExplain = New System.Windows.Forms.Button()
        Me.btnRemoveSelected = New System.Windows.Forms.Button()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        CType(Me.olvURLs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'olvURLs
        '
        Me.olvURLs.AllColumns.Add(Me.OlvColumn1)
        Me.olvURLs.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvURLs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.olvURLs.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.F2Only
        Me.olvURLs.CellEditUseWholeCell = False
        Me.olvURLs.CheckBoxes = True
        Me.olvURLs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1})
        Me.olvURLs.CopySelectionOnControlC = False
        Me.olvURLs.CopySelectionOnControlCUsesDragSource = False
        Me.olvURLs.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.olvURLs.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!)
        Me.olvURLs.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvURLs.FullRowSelect = True
        Me.olvURLs.GridLines = True
        Me.olvURLs.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvURLs.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvURLs.LabelWrap = False
        Me.olvURLs.Location = New System.Drawing.Point(0, 0)
        Me.olvURLs.Name = "olvURLs"
        Me.olvURLs.SelectColumnsMenuStaysOpen = False
        Me.olvURLs.SelectColumnsOnRightClick = False
        Me.olvURLs.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvURLs.ShowGroups = False
        Me.olvURLs.ShowImagesOnSubItems = True
        Me.olvURLs.Size = New System.Drawing.Size(379, 293)
        Me.olvURLs.SortGroupItemsByPrimaryColumn = False
        Me.olvURLs.TabIndex = 23
        Me.olvURLs.UseCompatibleStateImageBehavior = False
        Me.olvURLs.UseSubItemCheckBoxes = True
        Me.olvURLs.View = System.Windows.Forms.View.Details
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "Name"
        Me.OlvColumn1.FillsFreeSpace = True
        Me.OlvColumn1.Text = "Image Location"
        Me.OlvColumn1.Width = 360
        '
        'btnExplain
        '
        Me.btnExplain.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnExplain.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExplain.Location = New System.Drawing.Point(11, 300)
        Me.btnExplain.Name = "btnExplain"
        Me.btnExplain.Size = New System.Drawing.Size(175, 27)
        Me.btnExplain.TabIndex = 24
        Me.btnExplain.Text = "&Explain"
        Me.btnExplain.UseVisualStyleBackColor = True
        '
        'btnRemoveSelected
        '
        Me.btnRemoveSelected.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnRemoveSelected.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveSelected.Location = New System.Drawing.Point(193, 300)
        Me.btnRemoveSelected.Name = "btnRemoveSelected"
        Me.btnRemoveSelected.Size = New System.Drawing.Size(175, 27)
        Me.btnRemoveSelected.TabIndex = 25
        Me.btnRemoveSelected.Text = "&Remove Checked Images"
        Me.btnRemoveSelected.UseVisualStyleBackColor = True
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
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.olvURLs)
        Me.KryptonPanel.Controls.Add(Me.btnRemoveSelected)
        Me.KryptonPanel.Controls.Add(Me.btnExplain)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(379, 329)
        Me.KryptonPanel.TabIndex = 26
        '
        'RemoteImagesSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(379, 329)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "RemoteImagesSelector"
        Me.Text = "Remote Image Selector"
        CType(Me.olvURLs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents olvURLs As BrightIdeasSoftware.ObjectListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents btnExplain As System.Windows.Forms.Button
    Friend WithEvents btnRemoveSelected As System.Windows.Forms.Button
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
End Class
