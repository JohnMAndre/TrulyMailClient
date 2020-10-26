<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessRulesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProcessRulesForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.olvProcessingRules = New BrightIdeasSoftware.ObjectListView()
        Me.RuleNameColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.EnabledColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MoveUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveDownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNewRule = New System.Windows.Forms.Button()
        Me.btnEditRule = New System.Windows.Forms.Button()
        Me.btnDeleteRule = New System.Windows.Forms.Button()
        Me.btnMoveRuleUp = New System.Windows.Forms.Button()
        Me.btnMoveRuleDown = New System.Windows.Forms.Button()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.olvProcessingRules, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(429, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enabled processing rules are run automatically in the order shown below."
        '
        'olvProcessingRules
        '
        Me.olvProcessingRules.AllColumns.Add(Me.RuleNameColumn)
        Me.olvProcessingRules.AllColumns.Add(Me.EnabledColumn)
        Me.olvProcessingRules.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvProcessingRules.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.olvProcessingRules.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
        Me.olvProcessingRules.CellEditUseWholeCell = False
        Me.olvProcessingRules.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.RuleNameColumn, Me.EnabledColumn})
        Me.olvProcessingRules.ContextMenuStrip = Me.ContextMenuStrip1
        Me.olvProcessingRules.CopySelectionOnControlC = False
        Me.olvProcessingRules.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.olvProcessingRules.EmptyListMsg = "Click ""New"" to add a new processing rule"
        Me.olvProcessingRules.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!)
        Me.olvProcessingRules.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvProcessingRules.FullRowSelect = True
        Me.olvProcessingRules.GridLines = True
        Me.olvProcessingRules.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.olvProcessingRules.HideSelection = False
        Me.olvProcessingRules.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvProcessingRules.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvProcessingRules.LabelWrap = False
        Me.olvProcessingRules.Location = New System.Drawing.Point(12, 59)
        Me.olvProcessingRules.MultiSelect = False
        Me.olvProcessingRules.Name = "olvProcessingRules"
        Me.olvProcessingRules.SelectAllOnControlA = False
        Me.olvProcessingRules.SelectColumnsMenuStaysOpen = False
        Me.olvProcessingRules.SelectColumnsOnRightClick = False
        Me.olvProcessingRules.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvProcessingRules.ShowGroups = False
        Me.olvProcessingRules.ShowImagesOnSubItems = True
        Me.olvProcessingRules.Size = New System.Drawing.Size(478, 279)
        Me.olvProcessingRules.SortGroupItemsByPrimaryColumn = False
        Me.olvProcessingRules.TabIndex = 24
        Me.olvProcessingRules.UseCompatibleStateImageBehavior = False
        Me.olvProcessingRules.UseFilterIndicator = True
        Me.olvProcessingRules.UseFiltering = True
        Me.olvProcessingRules.UseSubItemCheckBoxes = True
        Me.olvProcessingRules.View = System.Windows.Forms.View.Details
        '
        'RuleNameColumn
        '
        Me.RuleNameColumn.AspectName = "Name"
        Me.RuleNameColumn.FillsFreeSpace = True
        Me.RuleNameColumn.Text = "Rule Name"
        Me.RuleNameColumn.Width = 360
        '
        'EnabledColumn
        '
        Me.EnabledColumn.AspectName = "Enabled"
        Me.EnabledColumn.AutoCompleteEditor = False
        Me.EnabledColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None
        Me.EnabledColumn.CheckBoxes = True
        Me.EnabledColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.EnabledColumn.Text = "Enabled"
        Me.EnabledColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.EnabledColumn.Width = 90
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripSeparator1, Me.MoveUpToolStripMenuItem, Me.MoveDownToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(139, 120)
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.NewToolStripMenuItem.Text = "&New..."
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.EditToolStripMenuItem.Text = "&Edit..."
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(135, 6)
        '
        'MoveUpToolStripMenuItem
        '
        Me.MoveUpToolStripMenuItem.Name = "MoveUpToolStripMenuItem"
        Me.MoveUpToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.MoveUpToolStripMenuItem.Text = "Move &Up"
        '
        'MoveDownToolStripMenuItem
        '
        Me.MoveDownToolStripMenuItem.Name = "MoveDownToolStripMenuItem"
        Me.MoveDownToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.MoveDownToolStripMenuItem.Text = "&Move Down"
        '
        'btnNewRule
        '
        Me.btnNewRule.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNewRule.Location = New System.Drawing.Point(496, 30)
        Me.btnNewRule.Name = "btnNewRule"
        Me.btnNewRule.Size = New System.Drawing.Size(90, 29)
        Me.btnNewRule.TabIndex = 25
        Me.btnNewRule.Text = "&New..."
        Me.btnNewRule.UseVisualStyleBackColor = True
        '
        'btnEditRule
        '
        Me.btnEditRule.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditRule.Location = New System.Drawing.Point(496, 59)
        Me.btnEditRule.Name = "btnEditRule"
        Me.btnEditRule.Size = New System.Drawing.Size(90, 29)
        Me.btnEditRule.TabIndex = 26
        Me.btnEditRule.Text = "&Edit..."
        Me.btnEditRule.UseVisualStyleBackColor = True
        '
        'btnDeleteRule
        '
        Me.btnDeleteRule.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteRule.Location = New System.Drawing.Point(496, 88)
        Me.btnDeleteRule.Name = "btnDeleteRule"
        Me.btnDeleteRule.Size = New System.Drawing.Size(90, 29)
        Me.btnDeleteRule.TabIndex = 27
        Me.btnDeleteRule.Text = "&Delete"
        Me.btnDeleteRule.UseVisualStyleBackColor = True
        '
        'btnMoveRuleUp
        '
        Me.btnMoveRuleUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveRuleUp.Location = New System.Drawing.Point(496, 151)
        Me.btnMoveRuleUp.Name = "btnMoveRuleUp"
        Me.btnMoveRuleUp.Size = New System.Drawing.Size(90, 29)
        Me.btnMoveRuleUp.TabIndex = 28
        Me.btnMoveRuleUp.Text = "Move &Up"
        Me.btnMoveRuleUp.UseVisualStyleBackColor = True
        '
        'btnMoveRuleDown
        '
        Me.btnMoveRuleDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveRuleDown.Location = New System.Drawing.Point(496, 180)
        Me.btnMoveRuleDown.Name = "btnMoveRuleDown"
        Me.btnMoveRuleDown.Size = New System.Drawing.Size(90, 29)
        Me.btnMoveRuleDown.TabIndex = 29
        Me.btnMoveRuleDown.Text = "&Move Down"
        Me.btnMoveRuleDown.UseVisualStyleBackColor = True
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPalette = Me.KryptonPalette1
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.btnClearFilter)
        Me.KryptonPanel.Controls.Add(Me.txtFilter)
        Me.KryptonPanel.Controls.Add(Me.Label2)
        Me.KryptonPanel.Controls.Add(Me.btnNewRule)
        Me.KryptonPanel.Controls.Add(Me.olvProcessingRules)
        Me.KryptonPanel.Controls.Add(Me.btnMoveRuleDown)
        Me.KryptonPanel.Controls.Add(Me.Label1)
        Me.KryptonPanel.Controls.Add(Me.btnEditRule)
        Me.KryptonPanel.Controls.Add(Me.btnMoveRuleUp)
        Me.KryptonPanel.Controls.Add(Me.btnDeleteRule)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(598, 350)
        Me.KryptonPanel.TabIndex = 30
        '
        'btnClearFilter
        '
        Me.btnClearFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearFilter.Image = CType(resources.GetObject("btnClearFilter.Image"), System.Drawing.Image)
        Me.btnClearFilter.Location = New System.Drawing.Point(456, 31)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(34, 26)
        Me.btnClearFilter.TabIndex = 31
        Me.btnClearFilter.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(63, 33)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(387, 22)
        Me.txtFilter.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(10, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 18)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Filter:"
        '
        'ProcessRulesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(598, 350)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ProcessRulesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Process Rules"
        CType(Me.olvProcessingRules, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents olvProcessingRules As BrightIdeasSoftware.ObjectListView
    Friend WithEvents RuleNameColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents btnNewRule As System.Windows.Forms.Button
    Friend WithEvents btnEditRule As System.Windows.Forms.Button
    Friend WithEvents btnDeleteRule As System.Windows.Forms.Button
    Friend WithEvents btnMoveRuleUp As System.Windows.Forms.Button
    Friend WithEvents btnMoveRuleDown As System.Windows.Forms.Button
    Friend WithEvents EnabledColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MoveUpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveDownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnClearFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
