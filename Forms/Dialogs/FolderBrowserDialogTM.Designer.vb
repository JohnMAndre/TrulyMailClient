<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FolderBrowserDialogTM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FolderBrowserDialogTM))
        Me.tvMessageFolders = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnNewFolder = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.pnlLabel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlQuickLinks = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.tblQuickLinks = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ClearRecentFoldersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.pnlLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLabel.SuspendLayout()
        CType(Me.pnlQuickLinks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlQuickLinks.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvMessageFolders
        '
        Me.tvMessageFolders.AllowDrop = True
        Me.tvMessageFolders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvMessageFolders.HideSelection = False
        Me.tvMessageFolders.ImageIndex = 0
        Me.tvMessageFolders.ImageList = Me.ImageList1
        Me.tvMessageFolders.Indent = 27
        Me.tvMessageFolders.ItemHeight = 24
        Me.tvMessageFolders.LabelEdit = True
        Me.tvMessageFolders.Location = New System.Drawing.Point(18, 0)
        Me.tvMessageFolders.Margin = New System.Windows.Forms.Padding(4)
        Me.tvMessageFolders.Name = "tvMessageFolders"
        Me.tvMessageFolders.SelectedImageKey = "Folder_Open.png"
        Me.tvMessageFolders.ShowNodeToolTips = True
        Me.tvMessageFolders.Size = New System.Drawing.Size(433, 245)
        Me.tvMessageFolders.TabIndex = 38
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Stuffed_Folder.png")
        Me.ImageList1.Images.SetKeyName(1, "Folder_Closed.png")
        Me.ImageList1.Images.SetKeyName(2, "Folder_Open.png")
        Me.ImageList1.Images.SetKeyName(3, "foldergreen.png")
        Me.ImageList1.Images.SetKeyName(4, "Postage stamp.bmp")
        Me.ImageList1.Images.SetKeyName(5, "Empty trash can.bmp")
        Me.ImageList1.Images.SetKeyName(6, "Full trash can.bmp")
        Me.ImageList1.Images.SetKeyName(7, "Message.bmp")
        Me.ImageList1.Images.SetKeyName(8, "Redirect.bmp")
        Me.ImageList1.Images.SetKeyName(9, "Edit_message.bmp")
        Me.ImageList1.Images.SetKeyName(10, "folder-closed-blue_24.png")
        Me.ImageList1.Images.SetKeyName(11, "folder-closed-green_24.png")
        Me.ImageList1.Images.SetKeyName(12, "folder-closed-yellow_24.png")
        Me.ImageList1.Images.SetKeyName(13, "folder-closed-orange_24.png")
        Me.ImageList1.Images.SetKeyName(14, "folder-closed-red_24.png")
        Me.ImageList1.Images.SetKeyName(15, "folder-closed-purple_24.png")
        Me.ImageList1.Images.SetKeyName(16, "folder-open-blue.png")
        Me.ImageList1.Images.SetKeyName(17, "folder-open-green.png")
        Me.ImageList1.Images.SetKeyName(18, "folder-open-yellow.png")
        Me.ImageList1.Images.SetKeyName(19, "folder-open-orange.png")
        Me.ImageList1.Images.SetKeyName(20, "folder-open-red.png")
        Me.ImageList1.Images.SetKeyName(21, "folder-open-purple.png")
        Me.ImageList1.Images.SetKeyName(22, "infinity_24.png")
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(339, 253)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 32)
        Me.btnCancel.TabIndex = 39
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(218, 253)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(112, 32)
        Me.btnOK.TabIndex = 40
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnNewFolder
        '
        Me.btnNewFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNewFolder.Location = New System.Drawing.Point(17, 253)
        Me.btnNewFolder.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNewFolder.Name = "btnNewFolder"
        Me.btnNewFolder.Size = New System.Drawing.Size(112, 32)
        Me.btnNewFolder.TabIndex = 42
        Me.btnNewFolder.Text = "&New Folder"
        Me.btnNewFolder.UseVisualStyleBackColor = True
        Me.btnNewFolder.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.btnNewFolder)
        Me.KryptonPanel.Controls.Add(Me.tvMessageFolders)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 97)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(471, 298)
        Me.KryptonPanel.TabIndex = 43
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPalette = Me.KryptonPalette1
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom
        '
        'pnlLabel
        '
        Me.pnlLabel.Controls.Add(Me.lblDescription)
        Me.pnlLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLabel.Location = New System.Drawing.Point(0, 0)
        Me.pnlLabel.Name = "pnlLabel"
        Me.pnlLabel.Palette = Me.KryptonPalette1
        Me.pnlLabel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.pnlLabel.Size = New System.Drawing.Size(471, 36)
        Me.pnlLabel.TabIndex = 45
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblDescription.Location = New System.Drawing.Point(15, 9)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(0, 18)
        Me.lblDescription.TabIndex = 41
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(15, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 18)
        Me.Label2.TabIndex = 41
        '
        'pnlQuickLinks
        '
        Me.pnlQuickLinks.Controls.Add(Me.tblQuickLinks)
        Me.pnlQuickLinks.Controls.Add(Me.Label2)
        Me.pnlQuickLinks.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlQuickLinks.Location = New System.Drawing.Point(0, 36)
        Me.pnlQuickLinks.Name = "pnlQuickLinks"
        Me.pnlQuickLinks.Palette = Me.KryptonPalette1
        Me.pnlQuickLinks.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.pnlQuickLinks.Size = New System.Drawing.Size(471, 61)
        Me.pnlQuickLinks.TabIndex = 47
        '
        'tblQuickLinks
        '
        Me.tblQuickLinks.BackColor = System.Drawing.Color.Transparent
        Me.tblQuickLinks.ColumnCount = 3
        Me.tblQuickLinks.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblQuickLinks.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblQuickLinks.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblQuickLinks.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tblQuickLinks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblQuickLinks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tblQuickLinks.Location = New System.Drawing.Point(0, 0)
        Me.tblQuickLinks.Name = "tblQuickLinks"
        Me.tblQuickLinks.RowCount = 3
        Me.tblQuickLinks.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblQuickLinks.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblQuickLinks.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblQuickLinks.Size = New System.Drawing.Size(471, 61)
        Me.tblQuickLinks.TabIndex = 42
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearRecentFoldersToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(177, 26)
        '
        'ClearRecentFoldersToolStripMenuItem
        '
        Me.ClearRecentFoldersToolStripMenuItem.Name = "ClearRecentFoldersToolStripMenuItem"
        Me.ClearRecentFoldersToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ClearRecentFoldersToolStripMenuItem.Text = "&Clear recent folders"
        '
        'FolderBrowserDialogTM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(471, 395)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Controls.Add(Me.pnlQuickLinks)
        Me.Controls.Add(Me.pnlLabel)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FolderBrowserDialogTM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Browse for folder"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.pnlLabel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLabel.ResumeLayout(False)
        Me.pnlLabel.PerformLayout()
        CType(Me.pnlQuickLinks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlQuickLinks.ResumeLayout(False)
        Me.pnlQuickLinks.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tvMessageFolders As System.Windows.Forms.TreeView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnNewFolder As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents pnlLabel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlQuickLinks As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents tblQuickLinks As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ClearRecentFoldersToolStripMenuItem As ToolStripMenuItem
End Class
