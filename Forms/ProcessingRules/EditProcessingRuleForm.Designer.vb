<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditProcessingRuleForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditProcessingRuleForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRuleName = New System.Windows.Forms.TextBox()
        Me.cboProcessRuleRunTime = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbtnMatchAll = New System.Windows.Forms.RadioButton()
        Me.rbtnMatchOr = New System.Windows.Forms.RadioButton()
        Me.rbtnMatchAnd = New System.Windows.Forms.RadioButton()
        Me.olvMatching = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.MatchFieldColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.CompareTypeColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.CompareValueColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.AddMatchColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.DeleteMatchColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.olvActions = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumn6 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ActionTypeColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ActionValueColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.AddActionColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.DeleteActionColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Panel1.SuspendLayout()
        CType(Me.olvMatching, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.olvActions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(14, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Processing Rule Name:"
        '
        'txtRuleName
        '
        Me.txtRuleName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRuleName.Location = New System.Drawing.Point(165, 6)
        Me.txtRuleName.Name = "txtRuleName"
        Me.txtRuleName.Size = New System.Drawing.Size(604, 22)
        Me.txtRuleName.TabIndex = 1
        '
        'cboProcessRuleRunTime
        '
        Me.cboProcessRuleRunTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboProcessRuleRunTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProcessRuleRunTime.FormattingEnabled = True
        Me.cboProcessRuleRunTime.Items.AddRange(New Object() {"When receiving messages", "When sending messages"})
        Me.cboProcessRuleRunTime.Location = New System.Drawing.Point(165, 38)
        Me.cboProcessRuleRunTime.Name = "cboProcessRuleRunTime"
        Me.cboProcessRuleRunTime.Size = New System.Drawing.Size(604, 24)
        Me.cboProcessRuleRunTime.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(14, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Run processing rule:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.rbtnMatchAll)
        Me.Panel1.Controls.Add(Me.rbtnMatchOr)
        Me.Panel1.Controls.Add(Me.rbtnMatchAnd)
        Me.Panel1.Location = New System.Drawing.Point(14, 68)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(755, 26)
        Me.Panel1.TabIndex = 4
        '
        'rbtnMatchAll
        '
        Me.rbtnMatchAll.AutoSize = True
        Me.rbtnMatchAll.BackColor = System.Drawing.Color.Transparent
        Me.rbtnMatchAll.Location = New System.Drawing.Point(377, 3)
        Me.rbtnMatchAll.Name = "rbtnMatchAll"
        Me.rbtnMatchAll.Size = New System.Drawing.Size(143, 20)
        Me.rbtnMatchAll.TabIndex = 2
        Me.rbtnMatchAll.TabStop = True
        Me.rbtnMatchAll.Text = "Match all &messages"
        Me.rbtnMatchAll.UseVisualStyleBackColor = False
        '
        'rbtnMatchOr
        '
        Me.rbtnMatchOr.AutoSize = True
        Me.rbtnMatchOr.BackColor = System.Drawing.Color.Transparent
        Me.rbtnMatchOr.Location = New System.Drawing.Point(186, 3)
        Me.rbtnMatchOr.Name = "rbtnMatchOr"
        Me.rbtnMatchOr.Size = New System.Drawing.Size(176, 20)
        Me.rbtnMatchOr.TabIndex = 1
        Me.rbtnMatchOr.TabStop = True
        Me.rbtnMatchOr.Text = "Match any &of the following"
        Me.rbtnMatchOr.UseVisualStyleBackColor = False
        '
        'rbtnMatchAnd
        '
        Me.rbtnMatchAnd.AutoSize = True
        Me.rbtnMatchAnd.BackColor = System.Drawing.Color.Transparent
        Me.rbtnMatchAnd.Location = New System.Drawing.Point(3, 3)
        Me.rbtnMatchAnd.Name = "rbtnMatchAnd"
        Me.rbtnMatchAnd.Size = New System.Drawing.Size(168, 20)
        Me.rbtnMatchAnd.TabIndex = 0
        Me.rbtnMatchAnd.TabStop = True
        Me.rbtnMatchAnd.Text = "Match &all of the following"
        Me.rbtnMatchAnd.UseVisualStyleBackColor = False
        '
        'olvMatching
        '
        Me.olvMatching.AllColumns.Add(Me.OlvColumn1)
        Me.olvMatching.AllColumns.Add(Me.MatchFieldColumn)
        Me.olvMatching.AllColumns.Add(Me.CompareTypeColumn)
        Me.olvMatching.AllColumns.Add(Me.CompareValueColumn)
        Me.olvMatching.AllColumns.Add(Me.AddMatchColumn)
        Me.olvMatching.AllColumns.Add(Me.DeleteMatchColumn)
        Me.olvMatching.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvMatching.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.olvMatching.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
        Me.olvMatching.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1, Me.MatchFieldColumn, Me.CompareTypeColumn, Me.CompareValueColumn, Me.AddMatchColumn, Me.DeleteMatchColumn})
        Me.olvMatching.CopySelectionOnControlC = False
        Me.olvMatching.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.olvMatching.EmptyListMsg = ""
        Me.olvMatching.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!)
        Me.olvMatching.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvMatching.FullRowSelect = True
        Me.olvMatching.GridLines = True
        Me.olvMatching.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.olvMatching.LabelWrap = False
        Me.olvMatching.Location = New System.Drawing.Point(14, 98)
        Me.olvMatching.MultiSelect = False
        Me.olvMatching.Name = "olvMatching"
        Me.olvMatching.OwnerDraw = True
        Me.olvMatching.SelectAllOnControlA = False
        Me.olvMatching.SelectColumnsMenuStaysOpen = False
        Me.olvMatching.SelectColumnsOnRightClick = False
        Me.olvMatching.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvMatching.ShowGroups = False
        Me.olvMatching.ShowHeaderInAllViews = False
        Me.olvMatching.ShowImagesOnSubItems = True
        Me.olvMatching.ShowItemToolTips = True
        Me.olvMatching.ShowSortIndicators = False
        Me.olvMatching.Size = New System.Drawing.Size(755, 155)
        Me.olvMatching.SmallImageList = Me.ImageList1
        Me.olvMatching.SortGroupItemsByPrimaryColumn = False
        Me.olvMatching.TabIndex = 25
        Me.olvMatching.UseCompatibleStateImageBehavior = False
        Me.olvMatching.UseSubItemCheckBoxes = True
        Me.olvMatching.View = System.Windows.Forms.View.Details
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AutoCompleteEditor = False
        Me.OlvColumn1.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None
        Me.OlvColumn1.IsEditable = False
        Me.OlvColumn1.Width = 1
        '
        'MatchFieldColumn
        '
        Me.MatchFieldColumn.AspectName = "MatchFieldText"
        Me.MatchFieldColumn.Text = ""
        Me.MatchFieldColumn.Width = 150
        '
        'CompareTypeColumn
        '
        Me.CompareTypeColumn.AspectName = "CompareTypeText"
        Me.CompareTypeColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CompareTypeColumn.Text = ""
        Me.CompareTypeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CompareTypeColumn.Width = 235
        '
        'CompareValueColumn
        '
        Me.CompareValueColumn.AspectName = "CompareValue"
        Me.CompareValueColumn.FillsFreeSpace = True
        Me.CompareValueColumn.Text = ""
        Me.CompareValueColumn.Width = 280
        '
        'AddMatchColumn
        '
        Me.AddMatchColumn.IsEditable = False
        Me.AddMatchColumn.Text = ""
        Me.AddMatchColumn.ToolTipText = "Add new match rule"
        Me.AddMatchColumn.Width = 36
        '
        'DeleteMatchColumn
        '
        Me.DeleteMatchColumn.IsEditable = False
        Me.DeleteMatchColumn.Text = ""
        Me.DeleteMatchColumn.ToolTipText = "Remove this match rule"
        Me.DeleteMatchColumn.Width = 36
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "add-icon_48.png")
        Me.ImageList1.Images.SetKeyName(1, "remove-icon_48.png")
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(694, 415)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 27)
        Me.btnCancel.TabIndex = 26
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(613, 415)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 27)
        Me.btnOK.TabIndex = 27
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'olvActions
        '
        Me.olvActions.AllColumns.Add(Me.OlvColumn6)
        Me.olvActions.AllColumns.Add(Me.ActionTypeColumn)
        Me.olvActions.AllColumns.Add(Me.ActionValueColumn)
        Me.olvActions.AllColumns.Add(Me.AddActionColumn)
        Me.olvActions.AllColumns.Add(Me.DeleteActionColumn)
        Me.olvActions.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvActions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.olvActions.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
        Me.olvActions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn6, Me.ActionTypeColumn, Me.ActionValueColumn, Me.AddActionColumn, Me.DeleteActionColumn})
        Me.olvActions.CopySelectionOnControlC = False
        Me.olvActions.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.olvActions.EmptyListMsg = ""
        Me.olvActions.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!)
        Me.olvActions.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvActions.FullRowSelect = True
        Me.olvActions.GridLines = True
        Me.olvActions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.olvActions.LabelWrap = False
        Me.olvActions.Location = New System.Drawing.Point(14, 281)
        Me.olvActions.MultiSelect = False
        Me.olvActions.Name = "olvActions"
        Me.olvActions.OwnerDraw = True
        Me.olvActions.SelectAllOnControlA = False
        Me.olvActions.SelectColumnsMenuStaysOpen = False
        Me.olvActions.SelectColumnsOnRightClick = False
        Me.olvActions.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvActions.ShowGroups = False
        Me.olvActions.ShowHeaderInAllViews = False
        Me.olvActions.ShowImagesOnSubItems = True
        Me.olvActions.Size = New System.Drawing.Size(755, 128)
        Me.olvActions.SmallImageList = Me.ImageList1
        Me.olvActions.SortGroupItemsByPrimaryColumn = False
        Me.olvActions.TabIndex = 28
        Me.olvActions.UseCompatibleStateImageBehavior = False
        Me.olvActions.UseSubItemCheckBoxes = True
        Me.olvActions.View = System.Windows.Forms.View.Details
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AutoCompleteEditor = False
        Me.OlvColumn6.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None
        Me.OlvColumn6.IsEditable = False
        Me.OlvColumn6.Width = 1
        '
        'ActionTypeColumn
        '
        Me.ActionTypeColumn.AspectName = "ActionTypeText"
        Me.ActionTypeColumn.Text = ""
        Me.ActionTypeColumn.Width = 250
        '
        'ActionValueColumn
        '
        Me.ActionValueColumn.AspectName = "ActionValue"
        Me.ActionValueColumn.Text = ""
        Me.ActionValueColumn.Width = 300
        '
        'AddActionColumn
        '
        Me.AddActionColumn.IsEditable = False
        Me.AddActionColumn.Text = ""
        Me.AddActionColumn.Width = 40
        '
        'DeleteActionColumn
        '
        Me.DeleteActionColumn.IsEditable = False
        Me.DeleteActionColumn.Text = ""
        Me.DeleteActionColumn.Width = 40
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(14, 262)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(174, 16)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Perform the following actions"
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
        Me.KryptonPanel.Controls.Add(Me.Label3)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.olvActions)
        Me.KryptonPanel.Controls.Add(Me.Label1)
        Me.KryptonPanel.Controls.Add(Me.txtRuleName)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.cboProcessRuleRunTime)
        Me.KryptonPanel.Controls.Add(Me.olvMatching)
        Me.KryptonPanel.Controls.Add(Me.Label2)
        Me.KryptonPanel.Controls.Add(Me.Panel1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(779, 454)
        Me.KryptonPanel.TabIndex = 30
        '
        'EditProcessingRuleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(779, 454)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "EditProcessingRuleForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Processing Rule Details"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.olvMatching, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.olvActions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRuleName As System.Windows.Forms.TextBox
    Friend WithEvents cboProcessRuleRunTime As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbtnMatchAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnMatchOr As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnMatchAnd As System.Windows.Forms.RadioButton
    Friend WithEvents olvMatching As BrightIdeasSoftware.ObjectListView
    Friend WithEvents MatchFieldColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents CompareTypeColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents CompareValueColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents AddMatchColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents DeleteMatchColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents olvActions As BrightIdeasSoftware.ObjectListView
    Friend WithEvents ActionTypeColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ActionValueColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents AddActionColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents DeleteActionColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn6 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
End Class
