<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSSList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RSSList))
        Me.btnDeleteRule = New System.Windows.Forms.Button()
        Me.btnEditRule = New System.Windows.Forms.Button()
        Me.btnNewRule = New System.Windows.Forms.Button()
        Me.olvRSSSubscriptions = New BrightIdeasSoftware.ObjectListView()
        Me.TitleColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.FolderColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.URLColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.SummaryColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.MediaColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ErrorColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnRemoteImages = New System.Windows.Forms.Button()
        Me.tmrShowErrorColumn = New System.Windows.Forms.Timer(Me.components)
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        CType(Me.olvRSSSubscriptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDeleteRule
        '
        Me.btnDeleteRule.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteRule.Location = New System.Drawing.Point(688, 70)
        Me.btnDeleteRule.Name = "btnDeleteRule"
        Me.btnDeleteRule.Size = New System.Drawing.Size(90, 29)
        Me.btnDeleteRule.TabIndex = 34
        Me.btnDeleteRule.Text = "&Delete"
        Me.btnDeleteRule.UseVisualStyleBackColor = True
        '
        'btnEditRule
        '
        Me.btnEditRule.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditRule.Location = New System.Drawing.Point(688, 41)
        Me.btnEditRule.Name = "btnEditRule"
        Me.btnEditRule.Size = New System.Drawing.Size(90, 29)
        Me.btnEditRule.TabIndex = 33
        Me.btnEditRule.Text = "&Edit..."
        Me.btnEditRule.UseVisualStyleBackColor = True
        '
        'btnNewRule
        '
        Me.btnNewRule.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNewRule.Location = New System.Drawing.Point(688, 12)
        Me.btnNewRule.Name = "btnNewRule"
        Me.btnNewRule.Size = New System.Drawing.Size(90, 29)
        Me.btnNewRule.TabIndex = 32
        Me.btnNewRule.Text = "&New..."
        Me.btnNewRule.UseVisualStyleBackColor = True
        '
        'olvRSSSubscriptions
        '
        Me.olvRSSSubscriptions.AllColumns.Add(Me.TitleColumn)
        Me.olvRSSSubscriptions.AllColumns.Add(Me.FolderColumn)
        Me.olvRSSSubscriptions.AllColumns.Add(Me.URLColumn)
        Me.olvRSSSubscriptions.AllColumns.Add(Me.SummaryColumn)
        Me.olvRSSSubscriptions.AllColumns.Add(Me.MediaColumn)
        Me.olvRSSSubscriptions.AllColumns.Add(Me.ErrorColumn)
        Me.olvRSSSubscriptions.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvRSSSubscriptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.olvRSSSubscriptions.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
        Me.olvRSSSubscriptions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TitleColumn, Me.FolderColumn, Me.URLColumn, Me.SummaryColumn, Me.MediaColumn, Me.ErrorColumn})
        Me.olvRSSSubscriptions.CopySelectionOnControlC = False
        Me.olvRSSSubscriptions.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.olvRSSSubscriptions.EmptyListMsg = "Click ""New"" to add a new subscription"
        Me.olvRSSSubscriptions.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!)
        Me.olvRSSSubscriptions.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvRSSSubscriptions.FullRowSelect = True
        Me.olvRSSSubscriptions.GridLines = True
        Me.olvRSSSubscriptions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.olvRSSSubscriptions.HideSelection = False
        Me.olvRSSSubscriptions.LabelWrap = False
        Me.olvRSSSubscriptions.Location = New System.Drawing.Point(12, 12)
        Me.olvRSSSubscriptions.MultiSelect = False
        Me.olvRSSSubscriptions.Name = "olvRSSSubscriptions"
        Me.olvRSSSubscriptions.OwnerDraw = True
        Me.olvRSSSubscriptions.SelectAllOnControlA = False
        Me.olvRSSSubscriptions.SelectColumnsMenuStaysOpen = False
        Me.olvRSSSubscriptions.SelectColumnsOnRightClick = False
        Me.olvRSSSubscriptions.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvRSSSubscriptions.ShowGroups = False
        Me.olvRSSSubscriptions.ShowImagesOnSubItems = True
        Me.olvRSSSubscriptions.Size = New System.Drawing.Size(671, 328)
        Me.olvRSSSubscriptions.SortGroupItemsByPrimaryColumn = False
        Me.olvRSSSubscriptions.TabIndex = 31
        Me.olvRSSSubscriptions.UseCompatibleStateImageBehavior = False
        Me.olvRSSSubscriptions.UseSubItemCheckBoxes = True
        Me.olvRSSSubscriptions.View = System.Windows.Forms.View.Details
        '
        'TitleColumn
        '
        Me.TitleColumn.AspectName = "Title"
        Me.TitleColumn.IsEditable = False
        Me.TitleColumn.Text = "Title"
        Me.TitleColumn.Width = 150
        '
        'FolderColumn
        '
        Me.FolderColumn.AspectName = "Folder"
        Me.FolderColumn.AutoCompleteEditor = False
        Me.FolderColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None
        Me.FolderColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FolderColumn.IsEditable = False
        Me.FolderColumn.Text = "Folder"
        Me.FolderColumn.Width = 150
        '
        'URLColumn
        '
        Me.URLColumn.AspectName = "URL"
        Me.URLColumn.IsEditable = False
        Me.URLColumn.Text = "Address"
        Me.URLColumn.Width = 150
        '
        'SummaryColumn
        '
        Me.SummaryColumn.AspectName = "ShowSummary"
        Me.SummaryColumn.CheckBoxes = True
        Me.SummaryColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SummaryColumn.IsEditable = False
        Me.SummaryColumn.Text = "Summary"
        Me.SummaryColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SummaryColumn.ToolTipText = "Show summary instead of web page?"
        Me.SummaryColumn.Width = 100
        '
        'MediaColumn
        '
        Me.MediaColumn.AspectName = "DownloadAttachments"
        Me.MediaColumn.CheckBoxes = True
        Me.MediaColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MediaColumn.IsEditable = False
        Me.MediaColumn.Text = "Media"
        Me.MediaColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MediaColumn.ToolTipText = "Download media attachments?"
        '
        'ErrorColumn
        '
        Me.ErrorColumn.AspectName = "LastErrorMessage"
        Me.ErrorColumn.IsEditable = False
        Me.ErrorColumn.Text = "Last Error"
        Me.ErrorColumn.Width = 120
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(688, 165)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(90, 29)
        Me.btnExport.TabIndex = 36
        Me.btnExport.Text = "E&xport"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Location = New System.Drawing.Point(688, 136)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(90, 29)
        Me.btnImport.TabIndex = 35
        Me.btnImport.Text = "&Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnRemoteImages
        '
        Me.btnRemoteImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoteImages.Location = New System.Drawing.Point(688, 224)
        Me.btnRemoteImages.Name = "btnRemoteImages"
        Me.btnRemoteImages.Size = New System.Drawing.Size(90, 29)
        Me.btnRemoteImages.TabIndex = 37
        Me.btnRemoteImages.Text = "&Remote Images"
        Me.btnRemoteImages.UseVisualStyleBackColor = True
        '
        'tmrShowErrorColumn
        '
        Me.tmrShowErrorColumn.Interval = 1000
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
        Me.KryptonPanel.Controls.Add(Me.olvRSSSubscriptions)
        Me.KryptonPanel.Controls.Add(Me.btnRemoteImages)
        Me.KryptonPanel.Controls.Add(Me.btnNewRule)
        Me.KryptonPanel.Controls.Add(Me.btnExport)
        Me.KryptonPanel.Controls.Add(Me.btnEditRule)
        Me.KryptonPanel.Controls.Add(Me.btnImport)
        Me.KryptonPanel.Controls.Add(Me.btnDeleteRule)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(790, 348)
        Me.KryptonPanel.TabIndex = 38
        '
        'RSSList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(790, 348)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RSSList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RSS and News Feeds"
        CType(Me.olvRSSSubscriptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDeleteRule As System.Windows.Forms.Button
    Friend WithEvents btnEditRule As System.Windows.Forms.Button
    Friend WithEvents btnNewRule As System.Windows.Forms.Button
    Friend WithEvents olvRSSSubscriptions As BrightIdeasSoftware.ObjectListView
    Friend WithEvents TitleColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents FolderColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents URLColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents SummaryColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents MediaColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents btnRemoteImages As System.Windows.Forms.Button
    Friend WithEvents ErrorColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents tmrShowErrorColumn As System.Windows.Forms.Timer
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
End Class
