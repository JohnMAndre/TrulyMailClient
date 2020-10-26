<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContactSelector
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContactSelector))
        Me.olvContacts = New BrightIdeasSoftware.ObjectListView()
        Me.NameColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.AddressColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.TagsColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.LastSentColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ImportanceColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.recipientImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.llblClearFilter = New System.Windows.Forms.LinkLabel()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.ctxmnuContact = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ComposeNewMessageToSelectedContactsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForwardSelectedMessageToSelectedContactsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterMessagesByThisContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.olvContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ctxmnuContact.SuspendLayout()
        Me.SuspendLayout()
        '
        'olvContacts
        '
        Me.olvContacts.AllColumns.Add(Me.NameColumn)
        Me.olvContacts.AllColumns.Add(Me.AddressColumn)
        Me.olvContacts.AllColumns.Add(Me.TagsColumn)
        Me.olvContacts.AllColumns.Add(Me.LastSentColumn)
        Me.olvContacts.AllColumns.Add(Me.ImportanceColumn)
        Me.olvContacts.AllowColumnReorder = True
        Me.olvContacts.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvContacts.CellEditUseWholeCell = False
        Me.olvContacts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NameColumn, Me.AddressColumn, Me.TagsColumn, Me.ImportanceColumn})
        Me.olvContacts.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.olvContacts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvContacts.EmptyListMsg = "No contacts found"
        Me.olvContacts.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!)
        Me.olvContacts.FullRowSelect = True
        Me.olvContacts.GridLines = True
        Me.olvContacts.HideSelection = False
        Me.olvContacts.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvContacts.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvContacts.IsSimpleDropSink = True
        Me.olvContacts.LabelWrap = False
        Me.olvContacts.Location = New System.Drawing.Point(0, 20)
        Me.olvContacts.Name = "olvContacts"
        Me.olvContacts.SelectColumnsMenuStaysOpen = False
        Me.olvContacts.ShowCommandMenuOnRightClick = True
        Me.olvContacts.ShowGroups = False
        Me.olvContacts.ShowItemCountOnGroups = True
        Me.olvContacts.Size = New System.Drawing.Size(301, 331)
        Me.olvContacts.SmallImageList = Me.recipientImageList
        Me.olvContacts.TabIndex = 2
        Me.olvContacts.UseAlternatingBackColors = True
        Me.olvContacts.UseCompatibleStateImageBehavior = False
        Me.olvContacts.UseFilterIndicator = True
        Me.olvContacts.UseFiltering = True
        Me.olvContacts.View = System.Windows.Forms.View.Details
        '
        'NameColumn
        '
        Me.NameColumn.AspectName = "FullName"
        Me.NameColumn.Text = "Name"
        Me.NameColumn.Width = 100
        '
        'AddressColumn
        '
        Me.AddressColumn.AspectName = "Address"
        Me.AddressColumn.Text = "Address"
        Me.AddressColumn.Width = 110
        '
        'TagsColumn
        '
        Me.TagsColumn.AspectName = "Tags"
        Me.TagsColumn.Text = "Tags"
        '
        'LastSentColumn
        '
        Me.LastSentColumn.AspectName = "LastMessageSent"
        Me.LastSentColumn.DisplayIndex = 3
        Me.LastSentColumn.IsVisible = False
        Me.LastSentColumn.Text = "LastSent"
        '
        'ImportanceColumn
        '
        Me.ImportanceColumn.AspectName = "ImportanceRating"
        Me.ImportanceColumn.HeaderImageKey = "spam scales.png"
        Me.ImportanceColumn.ShowTextInHeader = False
        Me.ImportanceColumn.Text = "Importance"
        Me.ImportanceColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ImportanceColumn.ToolTipText = "Importance"
        '
        'recipientImageList
        '
        Me.recipientImageList.ImageStream = CType(resources.GetObject("recipientImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.recipientImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.recipientImageList.Images.SetKeyName(0, "Secured message.bmp")
        Me.recipientImageList.Images.SetKeyName(1, "Email.bmp")
        Me.recipientImageList.Images.SetKeyName(2, "spam scales.png")
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.llblClearFilter)
        Me.Panel1.Controls.Add(Me.txtFilter)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(301, 20)
        Me.Panel1.TabIndex = 11
        '
        'llblClearFilter
        '
        Me.llblClearFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llblClearFilter.AutoSize = True
        Me.llblClearFilter.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblClearFilter.Location = New System.Drawing.Point(280, -1)
        Me.llblClearFilter.Name = "llblClearFilter"
        Me.llblClearFilter.Size = New System.Drawing.Size(18, 18)
        Me.llblClearFilter.TabIndex = 1
        Me.llblClearFilter.TabStop = True
        Me.llblClearFilter.Text = "X"
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFilter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter.ForeColor = System.Drawing.Color.DarkGray
        Me.txtFilter.Location = New System.Drawing.Point(22, 1)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(261, 15)
        Me.txtFilter.TabIndex = 0
        Me.txtFilter.Text = "Name or email or tag"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = Global.TrulyMail.My.Resources.Resources.Search_16
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 18)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnOK)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 351)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(301, 29)
        Me.Panel2.TabIndex = 13
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancel.Location = New System.Drawing.Point(69, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnOK.Location = New System.Drawing.Point(159, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'ctxmnuContact
        '
        Me.ctxmnuContact.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuContact.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ComposeNewMessageToSelectedContactsToolStripMenuItem, Me.ForwardSelectedMessageToSelectedContactsToolStripMenuItem, Me.FilterMessagesByThisContactToolStripMenuItem, Me.EditContactToolStripMenuItem, Me.ToolStripSeparator1, Me.RefreshToolStripMenuItem})
        Me.ctxmnuContact.Name = "ContextMenuStrip1"
        Me.ctxmnuContact.Size = New System.Drawing.Size(338, 120)
        '
        'ComposeNewMessageToSelectedContactsToolStripMenuItem
        '
        Me.ComposeNewMessageToSelectedContactsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ComposeNewMessageToSelectedContactsToolStripMenuItem.Name = "ComposeNewMessageToSelectedContactsToolStripMenuItem"
        Me.ComposeNewMessageToSelectedContactsToolStripMenuItem.Size = New System.Drawing.Size(337, 22)
        Me.ComposeNewMessageToSelectedContactsToolStripMenuItem.Text = "&Compose new message to selected contact(s)..."
        '
        'ForwardSelectedMessageToSelectedContactsToolStripMenuItem
        '
        Me.ForwardSelectedMessageToSelectedContactsToolStripMenuItem.Name = "ForwardSelectedMessageToSelectedContactsToolStripMenuItem"
        Me.ForwardSelectedMessageToSelectedContactsToolStripMenuItem.Size = New System.Drawing.Size(337, 22)
        Me.ForwardSelectedMessageToSelectedContactsToolStripMenuItem.Text = "&Forward selected message to selected contact(s)..."
        '
        'FilterMessagesByThisContactToolStripMenuItem
        '
        Me.FilterMessagesByThisContactToolStripMenuItem.Name = "FilterMessagesByThisContactToolStripMenuItem"
        Me.FilterMessagesByThisContactToolStripMenuItem.Size = New System.Drawing.Size(337, 22)
        Me.FilterMessagesByThisContactToolStripMenuItem.Text = "Filter messages by this contact"
        Me.FilterMessagesByThisContactToolStripMenuItem.ToolTipText = "For premium users only"
        Me.FilterMessagesByThisContactToolStripMenuItem.Visible = False
        '
        'EditContactToolStripMenuItem
        '
        Me.EditContactToolStripMenuItem.Name = "EditContactToolStripMenuItem"
        Me.EditContactToolStripMenuItem.Size = New System.Drawing.Size(337, 22)
        Me.EditContactToolStripMenuItem.Text = "&Edit contact..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(334, 6)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(337, 22)
        Me.RefreshToolStripMenuItem.Text = "&Refresh"
        '
        'ContactSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.olvContacts)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "ContactSelector"
        Me.Size = New System.Drawing.Size(301, 380)
        CType(Me.olvContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ctxmnuContact.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents olvContacts As BrightIdeasSoftware.ObjectListView
    Friend WithEvents NameColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents AddressColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents TagsColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents llblClearFilter As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents recipientImageList As System.Windows.Forms.ImageList
    Friend WithEvents ctxmnuContact As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ComposeNewMessageToSelectedContactsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditContactToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LastSentColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ForwardSelectedMessageToSelectedContactsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterMessagesByThisContactToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportanceColumn As BrightIdeasSoftware.OLVColumn

End Class
