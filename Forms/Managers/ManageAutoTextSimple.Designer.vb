<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageAutoTextSimple
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddAutoTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutTrulyMailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.olvAutoTexts = New BrightIdeasSoftware.ObjectListView()
        Me.NameColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.HTMLColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.NewColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ReplyColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ForwardColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.FollowUpColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.HotKeyColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboHotKey = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkUseForFollowUp = New System.Windows.Forms.CheckBox()
        Me.chkUseForForward = New System.Windows.Forms.CheckBox()
        Me.chkUseForReply = New System.Windows.Forms.CheckBox()
        Me.chkUseForNew = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtAutoText = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.olvAutoTexts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(878, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddAutoTextToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'AddAutoTextToolStripMenuItem
        '
        Me.AddAutoTextToolStripMenuItem.Name = "AddAutoTextToolStripMenuItem"
        Me.AddAutoTextToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.AddAutoTextToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.AddAutoTextToolStripMenuItem.Text = "&New AutoText"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(188, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutTrulyMailToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutTrulyMailToolStripMenuItem
        '
        Me.AboutTrulyMailToolStripMenuItem.Name = "AboutTrulyMailToolStripMenuItem"
        Me.AboutTrulyMailToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AboutTrulyMailToolStripMenuItem.Text = "&About TrulyMail"
        '
        'olvAutoTexts
        '
        Me.olvAutoTexts.AllColumns.Add(Me.NameColumn)
        Me.olvAutoTexts.AllColumns.Add(Me.HTMLColumn)
        Me.olvAutoTexts.AllColumns.Add(Me.NewColumn)
        Me.olvAutoTexts.AllColumns.Add(Me.ReplyColumn)
        Me.olvAutoTexts.AllColumns.Add(Me.ForwardColumn)
        Me.olvAutoTexts.AllColumns.Add(Me.FollowUpColumn)
        Me.olvAutoTexts.AllColumns.Add(Me.HotKeyColumn)
        Me.olvAutoTexts.AllowColumnReorder = True
        Me.olvAutoTexts.CellEditUseWholeCell = False
        Me.olvAutoTexts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NameColumn, Me.HTMLColumn, Me.NewColumn, Me.ReplyColumn, Me.ForwardColumn, Me.FollowUpColumn, Me.HotKeyColumn})
        Me.olvAutoTexts.Cursor = System.Windows.Forms.Cursors.Default
        Me.olvAutoTexts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvAutoTexts.EmptyListMsg = "No AutoTexts"
        Me.olvAutoTexts.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvAutoTexts.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvAutoTexts.FullRowSelect = True
        Me.olvAutoTexts.HideSelection = False
        Me.olvAutoTexts.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvAutoTexts.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvAutoTexts.LabelWrap = False
        Me.olvAutoTexts.Location = New System.Drawing.Point(0, 24)
        Me.olvAutoTexts.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.olvAutoTexts.MultiSelect = False
        Me.olvAutoTexts.Name = "olvAutoTexts"
        Me.olvAutoTexts.SelectColumnsOnRightClick = False
        Me.olvAutoTexts.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvAutoTexts.ShowGroups = False
        Me.olvAutoTexts.ShowImagesOnSubItems = True
        Me.olvAutoTexts.ShowItemCountOnGroups = True
        Me.olvAutoTexts.Size = New System.Drawing.Size(554, 342)
        Me.olvAutoTexts.TabIndex = 2
        Me.olvAutoTexts.UseCompatibleStateImageBehavior = False
        Me.olvAutoTexts.UseFiltering = True
        Me.olvAutoTexts.UseHyperlinks = True
        Me.olvAutoTexts.UseSubItemCheckBoxes = True
        Me.olvAutoTexts.View = System.Windows.Forms.View.Details
        '
        'NameColumn
        '
        Me.NameColumn.AspectName = "Name"
        Me.NameColumn.Text = "Name"
        Me.NameColumn.Width = 100
        '
        'HTMLColumn
        '
        Me.HTMLColumn.AspectName = "HTML"
        Me.HTMLColumn.CheckBoxes = True
        Me.HTMLColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.HTMLColumn.IsEditable = False
        Me.HTMLColumn.Text = "HTML"
        Me.HTMLColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NewColumn
        '
        Me.NewColumn.AspectName = "IsNew"
        Me.NewColumn.CheckBoxes = True
        Me.NewColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NewColumn.IsEditable = False
        Me.NewColumn.Text = "New"
        Me.NewColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NewColumn.ToolTipText = "Use this as signature for new messages"
        '
        'ReplyColumn
        '
        Me.ReplyColumn.AspectName = "IsReply"
        Me.ReplyColumn.CheckBoxes = True
        Me.ReplyColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ReplyColumn.IsEditable = False
        Me.ReplyColumn.Text = "Reply"
        Me.ReplyColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ReplyColumn.ToolTipText = "Use this as signature for replies"
        '
        'ForwardColumn
        '
        Me.ForwardColumn.AspectName = "IsForward"
        Me.ForwardColumn.CheckBoxes = True
        Me.ForwardColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ForwardColumn.IsEditable = False
        Me.ForwardColumn.Text = "Forward"
        Me.ForwardColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ForwardColumn.ToolTipText = "Use this as signature for forwarded messages"
        '
        'FollowUpColumn
        '
        Me.FollowUpColumn.AspectName = "IsFollowUp"
        Me.FollowUpColumn.CheckBoxes = True
        Me.FollowUpColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FollowUpColumn.IsEditable = False
        Me.FollowUpColumn.Text = "Follow-Up"
        Me.FollowUpColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FollowUpColumn.ToolTipText = "Use this as signature for follow-up messages"
        Me.FollowUpColumn.Width = 90
        '
        'HotKeyColumn
        '
        Me.HotKeyColumn.AspectName = "HotKey"
        Me.HotKeyColumn.Text = "HotKey"
        Me.HotKeyColumn.Width = 90
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.cboHotKey)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.chkUseForFollowUp)
        Me.GroupBox1.Controls.Add(Me.chkUseForForward)
        Me.GroupBox1.Controls.Add(Me.chkUseForReply)
        Me.GroupBox1.Controls.Add(Me.chkUseForNew)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.txtAutoText)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(554, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(324, 342)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'cboHotKey
        '
        Me.cboHotKey.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboHotKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHotKey.FormattingEnabled = True
        Me.cboHotKey.Location = New System.Drawing.Point(71, 227)
        Me.cboHotKey.Name = "cboHotKey"
        Me.cboHotKey.Size = New System.Drawing.Size(146, 21)
        Me.cboHotKey.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 230)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "HotKey:"
        '
        'chkUseForFollowUp
        '
        Me.chkUseForFollowUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkUseForFollowUp.AutoSize = True
        Me.chkUseForFollowUp.Location = New System.Drawing.Point(208, 282)
        Me.chkUseForFollowUp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkUseForFollowUp.Name = "chkUseForFollowUp"
        Me.chkUseForFollowUp.Size = New System.Drawing.Size(110, 17)
        Me.chkUseForFollowUp.TabIndex = 12
        Me.chkUseForFollowUp.Text = "Use for follow-ups"
        Me.chkUseForFollowUp.UseVisualStyleBackColor = True
        '
        'chkUseForForward
        '
        Me.chkUseForForward.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkUseForForward.AutoSize = True
        Me.chkUseForForward.Location = New System.Drawing.Point(208, 260)
        Me.chkUseForForward.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkUseForForward.Name = "chkUseForForward"
        Me.chkUseForForward.Size = New System.Drawing.Size(103, 17)
        Me.chkUseForForward.TabIndex = 11
        Me.chkUseForForward.Text = "Use for forwards"
        Me.chkUseForForward.UseVisualStyleBackColor = True
        '
        'chkUseForReply
        '
        Me.chkUseForReply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkUseForReply.AutoSize = True
        Me.chkUseForReply.Location = New System.Drawing.Point(13, 282)
        Me.chkUseForReply.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkUseForReply.Name = "chkUseForReply"
        Me.chkUseForReply.Size = New System.Drawing.Size(93, 17)
        Me.chkUseForReply.TabIndex = 10
        Me.chkUseForReply.Text = "Use for replies"
        Me.chkUseForReply.UseVisualStyleBackColor = True
        '
        'chkUseForNew
        '
        Me.chkUseForNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkUseForNew.AutoSize = True
        Me.chkUseForNew.Location = New System.Drawing.Point(13, 259)
        Me.chkUseForNew.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkUseForNew.Name = "chkUseForNew"
        Me.chkUseForNew.Size = New System.Drawing.Size(133, 17)
        Me.chkUseForNew.TabIndex = 9
        Me.chkUseForNew.Text = "Use for new messages"
        Me.chkUseForNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(13, 305)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(79, 27)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Name:"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(62, 15)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(249, 20)
        Me.txtName.TabIndex = 7
        '
        'txtAutoText
        '
        Me.txtAutoText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAutoText.Location = New System.Drawing.Point(6, 44)
        Me.txtAutoText.Multiline = True
        Me.txtAutoText.Name = "txtAutoText"
        Me.txtAutoText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAutoText.Size = New System.Drawing.Size(305, 177)
        Me.txtAutoText.TabIndex = 2
        '
        'ManageAutoTextSimple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 366)
        Me.Controls.Add(Me.olvAutoTexts)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "ManageAutoTextSimple"
        Me.Text = "Manage AutoText  (fallback)"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.olvAutoTexts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddAutoTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutTrulyMailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents olvAutoTexts As BrightIdeasSoftware.ObjectListView
    Friend WithEvents NameColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents HTMLColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents NewColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ReplyColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ForwardColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents FollowUpColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents HotKeyColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboHotKey As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkUseForFollowUp As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseForForward As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseForReply As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseForNew As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtAutoText As System.Windows.Forms.TextBox
End Class
