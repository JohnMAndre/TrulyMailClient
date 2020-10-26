<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ContactSelectorPlain
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.llblClearFilter = New System.Windows.Forms.LinkLabel()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.dgvContacts = New System.Windows.Forms.DataGridView()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTags = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLastMessageSent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colImportance = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn()
        Me.ctxmnuContact = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ComposeNewMessageToSelectedContactsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForwardSelectedMessageToSelectedContactsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterMessagesByThisContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyaddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmnuContact.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.TabIndex = 12
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
        Me.Panel2.TabIndex = 14
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
        'dgvContacts
        '
        Me.dgvContacts.AllowDrop = True
        Me.dgvContacts.AllowUserToAddRows = False
        Me.dgvContacts.AllowUserToDeleteRows = False
        Me.dgvContacts.AllowUserToResizeRows = False
        Me.dgvContacts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContacts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colName, Me.colAddress, Me.colTags, Me.colLastMessageSent, Me.colImportance})
        Me.dgvContacts.ContextMenuStrip = Me.ctxmnuContact
        Me.dgvContacts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvContacts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvContacts.Location = New System.Drawing.Point(0, 20)
        Me.dgvContacts.Name = "dgvContacts"
        Me.dgvContacts.ReadOnly = True
        Me.dgvContacts.RowHeadersWidth = 20
        Me.dgvContacts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvContacts.ShowCellErrors = False
        Me.dgvContacts.ShowCellToolTips = False
        Me.dgvContacts.ShowEditingIcon = False
        Me.dgvContacts.ShowRowErrors = False
        Me.dgvContacts.Size = New System.Drawing.Size(301, 331)
        Me.dgvContacts.TabIndex = 15
        '
        'colName
        '
        Me.colName.DataPropertyName = "FullName"
        Me.colName.HeaderText = "Name"
        Me.colName.Name = "colName"
        Me.colName.ReadOnly = True
        '
        'colAddress
        '
        Me.colAddress.DataPropertyName = "Address"
        Me.colAddress.HeaderText = "Address"
        Me.colAddress.Name = "colAddress"
        Me.colAddress.ReadOnly = True
        '
        'colTags
        '
        Me.colTags.DataPropertyName = "Tags"
        Me.colTags.HeaderText = "Tags"
        Me.colTags.Name = "colTags"
        Me.colTags.ReadOnly = True
        '
        'colLastMessageSent
        '
        Me.colLastMessageSent.DataPropertyName = "LastMessageSent"
        Me.colLastMessageSent.HeaderText = "Last"
        Me.colLastMessageSent.Name = "colLastMessageSent"
        Me.colLastMessageSent.ReadOnly = True
        '
        'colImportance
        '
        Me.colImportance.DataPropertyName = "ImportanceRating"
        Me.colImportance.HeaderText = "Importance"
        Me.colImportance.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.colImportance.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.colImportance.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.colImportance.Name = "colImportance"
        Me.colImportance.ReadOnly = True
        Me.colImportance.Width = 100
        '
        'ctxmnuContact
        '
        Me.ctxmnuContact.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuContact.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ComposeNewMessageToSelectedContactsToolStripMenuItem, Me.ForwardSelectedMessageToSelectedContactsToolStripMenuItem, Me.FilterMessagesByThisContactToolStripMenuItem, Me.CopyaddressToolStripMenuItem, Me.EditContactToolStripMenuItem, Me.ToolStripSeparator1, Me.RefreshToolStripMenuItem})
        Me.ctxmnuContact.Name = "ContextMenuStrip1"
        Me.ctxmnuContact.Size = New System.Drawing.Size(338, 164)
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
        'CopyaddressToolStripMenuItem
        '
        Me.CopyaddressToolStripMenuItem.Name = "CopyaddressToolStripMenuItem"
        Me.CopyaddressToolStripMenuItem.Size = New System.Drawing.Size(337, 22)
        Me.CopyaddressToolStripMenuItem.Text = "Copy &address(es)"
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
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'ContactSelectorPlain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgvContacts)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ContactSelectorPlain"
        Me.Size = New System.Drawing.Size(301, 380)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmnuContact.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents llblClearFilter As LinkLabel
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents dgvContacts As DataGridView
    Friend WithEvents ctxmnuContact As ContextMenuStrip
    Friend WithEvents ComposeNewMessageToSelectedContactsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ForwardSelectedMessageToSelectedContactsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FilterMessagesByThisContactToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditContactToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colAddress As DataGridViewTextBoxColumn
    Friend WithEvents colTags As DataGridViewTextBoxColumn
    Friend WithEvents colLastMessageSent As DataGridViewTextBoxColumn
    Friend WithEvents colImportance As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn
    Friend WithEvents Timer1 As Timer
    Friend WithEvents CopyaddressToolStripMenuItem As ToolStripMenuItem
End Class
