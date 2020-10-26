<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSSSenderRemoteImages
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RSSSenderRemoteImages))
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.olvRSSSenders = New BrightIdeasSoftware.ObjectListView()
        Me.TitleColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        CType(Me.olvRSSSenders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(361, 94)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(120, 36)
        Me.btnDelete.TabIndex = 37
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.Location = New System.Drawing.Point(361, 51)
        Me.btnNew.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(120, 36)
        Me.btnNew.TabIndex = 35
        Me.btnNew.Text = "&New..."
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'olvRSSSenders
        '
        Me.olvRSSSenders.AllColumns.Add(Me.TitleColumn)
        Me.olvRSSSenders.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvRSSSenders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.olvRSSSenders.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
        Me.olvRSSSenders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TitleColumn})
        Me.olvRSSSenders.CopySelectionOnControlC = False
        Me.olvRSSSenders.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.olvRSSSenders.EmptyListMsg = "Click ""New"" to add a new RSS source"
        Me.olvRSSSenders.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!)
        Me.olvRSSSenders.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvRSSSenders.FullRowSelect = True
        Me.olvRSSSenders.GridLines = True
        Me.olvRSSSenders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.olvRSSSenders.HideSelection = False
        Me.olvRSSSenders.LabelWrap = False
        Me.olvRSSSenders.Location = New System.Drawing.Point(13, 51)
        Me.olvRSSSenders.Margin = New System.Windows.Forms.Padding(4)
        Me.olvRSSSenders.MultiSelect = False
        Me.olvRSSSenders.Name = "olvRSSSenders"
        Me.olvRSSSenders.OwnerDraw = True
        Me.olvRSSSenders.SelectAllOnControlA = False
        Me.olvRSSSenders.SelectColumnsMenuStaysOpen = False
        Me.olvRSSSenders.SelectColumnsOnRightClick = False
        Me.olvRSSSenders.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvRSSSenders.ShowGroups = False
        Me.olvRSSSenders.ShowImagesOnSubItems = True
        Me.olvRSSSenders.Size = New System.Drawing.Size(340, 351)
        Me.olvRSSSenders.SortGroupItemsByPrimaryColumn = False
        Me.olvRSSSenders.TabIndex = 38
        Me.olvRSSSenders.UseCompatibleStateImageBehavior = False
        Me.olvRSSSenders.UseSubItemCheckBoxes = True
        Me.olvRSSSenders.View = System.Windows.Forms.View.Details
        '
        'TitleColumn
        '
        Me.TitleColumn.AspectName = "Title"
        Me.TitleColumn.IsEditable = False
        Me.TitleColumn.Text = "Source"
        Me.TitleColumn.Width = 250
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(425, 16)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "RSS articles from these sources will always allow remote images."
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
        Me.KryptonPanel.Controls.Add(Me.olvRSSSenders)
        Me.KryptonPanel.Controls.Add(Me.Label1)
        Me.KryptonPanel.Controls.Add(Me.btnNew)
        Me.KryptonPanel.Controls.Add(Me.btnDelete)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(494, 415)
        Me.KryptonPanel.TabIndex = 40
        '
        'RSSSenderRemoteImages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(494, 415)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RSSSenderRemoteImages"
        Me.Text = "RSS Remote Images"
        CType(Me.olvRSSSenders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents olvRSSSenders As BrightIdeasSoftware.ObjectListView
    Friend WithEvents TitleColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
End Class
