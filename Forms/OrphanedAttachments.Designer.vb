<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrphanedAttachments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrphanedAttachments))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.pnlResults = New System.Windows.Forms.Panel()
        Me.olvAttachments = New BrightIdeasSoftware.ObjectListView()
        Me.olvColumnAttachmentName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnAttachmentSize = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnFullPath = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnSelected = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ctxmnuAttachments = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenAttachmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileLocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelSizeOfMessages = New System.Windows.Forms.ToolStripStatusLabel()
        Me.FilterMessageCountToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SelectedStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TotalStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlMessageFilter = New System.Windows.Forms.Panel()
        Me.btnCheckSelected = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnToggleGroups = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnDeleteSelected = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSelectAll = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtMessageFilter = New System.Windows.Forms.TextBox()
        Me.btnClearMessageFilter = New System.Windows.Forms.Button()
        Me.llblFilter = New System.Windows.Forms.LinkLabel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSearch = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblSearchProgress = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.prgSearchProgress = New MontgomerySoftware.Controls.ProgressBar()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tmrFilterMessages = New System.Timers.Timer()
        Me.tmrStatusUpdater = New System.Timers.Timer()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.pnlResults.SuspendLayout()
        CType(Me.olvAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmnuAttachments.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.pnlMessageFilter.SuspendLayout()
        CType(Me.tmrFilterMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tmrStatusUpdater, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.pnlResults)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnSearch)
        Me.KryptonPanel.Controls.Add(Me.lblSearchProgress)
        Me.KryptonPanel.Controls.Add(Me.prgSearchProgress)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(914, 565)
        Me.KryptonPanel.TabIndex = 0
        '
        'pnlResults
        '
        Me.pnlResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlResults.AutoSize = True
        Me.pnlResults.BackColor = System.Drawing.Color.Transparent
        Me.pnlResults.Controls.Add(Me.olvAttachments)
        Me.pnlResults.Controls.Add(Me.StatusStrip1)
        Me.pnlResults.Controls.Add(Me.pnlMessageFilter)
        Me.pnlResults.Location = New System.Drawing.Point(0, 35)
        Me.pnlResults.Name = "pnlResults"
        Me.pnlResults.Size = New System.Drawing.Size(914, 530)
        Me.pnlResults.TabIndex = 58
        '
        'olvAttachments
        '
        Me.olvAttachments.AllColumns.Add(Me.olvColumnAttachmentName)
        Me.olvAttachments.AllColumns.Add(Me.OlvColumnAttachmentSize)
        Me.olvAttachments.AllColumns.Add(Me.OlvColumnFullPath)
        Me.olvAttachments.AllColumns.Add(Me.OlvColumnSelected)
        Me.olvAttachments.AllowColumnReorder = True
        Me.olvAttachments.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.olvAttachments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvColumnAttachmentName, Me.OlvColumnAttachmentSize, Me.OlvColumnFullPath, Me.OlvColumnSelected})
        Me.olvAttachments.ContextMenuStrip = Me.ctxmnuAttachments
        Me.olvAttachments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvAttachments.EmptyListMsg = "Please click the Search button above."
        Me.olvAttachments.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvAttachments.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvAttachments.FullRowSelect = True
        Me.olvAttachments.HideSelection = False
        Me.olvAttachments.LabelWrap = False
        Me.olvAttachments.Location = New System.Drawing.Point(0, 36)
        Me.olvAttachments.Name = "olvAttachments"
        Me.olvAttachments.OwnerDraw = True
        Me.olvAttachments.SelectColumnsMenuStaysOpen = False
        Me.olvAttachments.ShowCommandMenuOnRightClick = True
        Me.olvAttachments.ShowGroups = False
        Me.olvAttachments.ShowImagesOnSubItems = True
        Me.olvAttachments.ShowItemCountOnGroups = True
        Me.olvAttachments.Size = New System.Drawing.Size(914, 472)
        Me.olvAttachments.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.olvAttachments.TabIndex = 8
        Me.olvAttachments.UseCompatibleStateImageBehavior = False
        Me.olvAttachments.UseFiltering = True
        Me.olvAttachments.UseSubItemCheckBoxes = True
        Me.olvAttachments.View = System.Windows.Forms.View.Details
        '
        'olvColumnAttachmentName
        '
        Me.olvColumnAttachmentName.AspectName = "AttachmentFilename"
        Me.olvColumnAttachmentName.AspectToStringFormat = ""
        Me.olvColumnAttachmentName.DisplayIndex = 1
        Me.olvColumnAttachmentName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.olvColumnAttachmentName.IsEditable = False
        Me.olvColumnAttachmentName.Text = "Filename"
        Me.olvColumnAttachmentName.Width = 150
        '
        'OlvColumnAttachmentSize
        '
        Me.OlvColumnAttachmentSize.AspectName = "AttachmentFileSize"
        Me.OlvColumnAttachmentSize.DisplayIndex = 2
        Me.OlvColumnAttachmentSize.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnAttachmentSize.IsEditable = False
        Me.OlvColumnAttachmentSize.Text = "File Size"
        Me.OlvColumnAttachmentSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnAttachmentSize.Width = 100
        '
        'OlvColumnFullPath
        '
        Me.OlvColumnFullPath.AspectName = "AttachmentFullPath"
        Me.OlvColumnFullPath.DisplayIndex = 3
        Me.OlvColumnFullPath.IsEditable = False
        Me.OlvColumnFullPath.Text = "Path"
        Me.OlvColumnFullPath.Width = 550
        '
        'OlvColumnSelected
        '
        Me.OlvColumnSelected.AspectName = "Selected"
        Me.OlvColumnSelected.CheckBoxes = True
        Me.OlvColumnSelected.DisplayIndex = 0
        Me.OlvColumnSelected.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnSelected.IsEditable = False
        Me.OlvColumnSelected.MinimumWidth = 80
        Me.OlvColumnSelected.Text = "Delete"
        Me.OlvColumnSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnSelected.Width = 90
        '
        'ctxmnuAttachments
        '
        Me.ctxmnuAttachments.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuAttachments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenAttachmentToolStripMenuItem, Me.OpenFileLocationToolStripMenuItem})
        Me.ctxmnuAttachments.Name = "ctxmnuMessages"
        Me.ctxmnuAttachments.Size = New System.Drawing.Size(191, 48)
        '
        'OpenAttachmentToolStripMenuItem
        '
        Me.OpenAttachmentToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenAttachmentToolStripMenuItem.Name = "OpenAttachmentToolStripMenuItem"
        Me.OpenAttachmentToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.OpenAttachmentToolStripMenuItem.Text = "&Open selected file(s)"
        '
        'OpenFileLocationToolStripMenuItem
        '
        Me.OpenFileLocationToolStripMenuItem.Name = "OpenFileLocationToolStripMenuItem"
        Me.OpenFileLocationToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.OpenFileLocationToolStripMenuItem.Text = "Open file &location"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabelSizeOfMessages, Me.FilterMessageCountToolStripStatusLabel, Me.SelectedStatusLabel, Me.TotalStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 508)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(914, 22)
        Me.StatusStrip1.TabIndex = 19
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(784, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = " "
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabelSizeOfMessages
        '
        Me.ToolStripStatusLabelSizeOfMessages.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabelSizeOfMessages.Name = "ToolStripStatusLabelSizeOfMessages"
        Me.ToolStripStatusLabelSizeOfMessages.Size = New System.Drawing.Size(4, 17)
        '
        'FilterMessageCountToolStripStatusLabel
        '
        Me.FilterMessageCountToolStripStatusLabel.Name = "FilterMessageCountToolStripStatusLabel"
        Me.FilterMessageCountToolStripStatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'SelectedStatusLabel
        '
        Me.SelectedStatusLabel.Name = "SelectedStatusLabel"
        Me.SelectedStatusLabel.Size = New System.Drawing.Size(65, 17)
        Me.SelectedStatusLabel.Text = "Checked: 0"
        '
        'TotalStatusLabel
        '
        Me.TotalStatusLabel.Name = "TotalStatusLabel"
        Me.TotalStatusLabel.Size = New System.Drawing.Size(46, 17)
        Me.TotalStatusLabel.Text = "Total: 0"
        '
        'pnlMessageFilter
        '
        Me.pnlMessageFilter.AutoSize = True
        Me.pnlMessageFilter.BackColor = System.Drawing.Color.Transparent
        Me.pnlMessageFilter.Controls.Add(Me.btnCheckSelected)
        Me.pnlMessageFilter.Controls.Add(Me.KryptonButton1)
        Me.pnlMessageFilter.Controls.Add(Me.btnToggleGroups)
        Me.pnlMessageFilter.Controls.Add(Me.btnDeleteSelected)
        Me.pnlMessageFilter.Controls.Add(Me.btnSelectAll)
        Me.pnlMessageFilter.Controls.Add(Me.txtMessageFilter)
        Me.pnlMessageFilter.Controls.Add(Me.btnClearMessageFilter)
        Me.pnlMessageFilter.Controls.Add(Me.llblFilter)
        Me.pnlMessageFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMessageFilter.Location = New System.Drawing.Point(0, 0)
        Me.pnlMessageFilter.Name = "pnlMessageFilter"
        Me.pnlMessageFilter.Size = New System.Drawing.Size(914, 36)
        Me.pnlMessageFilter.TabIndex = 7
        Me.pnlMessageFilter.Visible = False
        '
        'btnCheckSelected
        '
        Me.btnCheckSelected.Location = New System.Drawing.Point(186, 3)
        Me.btnCheckSelected.Name = "btnCheckSelected"
        Me.btnCheckSelected.Size = New System.Drawing.Size(106, 30)
        Me.btnCheckSelected.TabIndex = 63
        Me.btnCheckSelected.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnCheckSelected.Values.Text = "&Toggle selected"
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Location = New System.Drawing.Point(95, 3)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Size = New System.Drawing.Size(79, 30)
        Me.KryptonButton1.TabIndex = 62
        Me.KryptonButton1.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.KryptonButton1.Values.Text = "&Uncheck all"
        '
        'btnToggleGroups
        '
        Me.btnToggleGroups.Location = New System.Drawing.Point(446, 3)
        Me.btnToggleGroups.Name = "btnToggleGroups"
        Me.btnToggleGroups.Size = New System.Drawing.Size(114, 30)
        Me.btnToggleGroups.TabIndex = 61
        Me.btnToggleGroups.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnToggleGroups.Values.Text = "Toggle &groups"
        '
        'btnDeleteSelected
        '
        Me.btnDeleteSelected.Location = New System.Drawing.Point(315, 3)
        Me.btnDeleteSelected.Name = "btnDeleteSelected"
        Me.btnDeleteSelected.Size = New System.Drawing.Size(114, 30)
        Me.btnDeleteSelected.TabIndex = 60
        Me.btnDeleteSelected.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnDeleteSelected.Values.Text = "&Delete checked"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(3, 3)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(79, 30)
        Me.btnSelectAll.TabIndex = 59
        Me.btnSelectAll.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnSelectAll.Values.Text = "Check &all"
        '
        'txtMessageFilter
        '
        Me.txtMessageFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtMessageFilter.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtMessageFilter.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessageFilter.Location = New System.Drawing.Point(626, 0)
        Me.txtMessageFilter.Name = "txtMessageFilter"
        Me.txtMessageFilter.Size = New System.Drawing.Size(254, 26)
        Me.txtMessageFilter.TabIndex = 1
        '
        'btnClearMessageFilter
        '
        Me.btnClearMessageFilter.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClearMessageFilter.Image = CType(resources.GetObject("btnClearMessageFilter.Image"), System.Drawing.Image)
        Me.btnClearMessageFilter.Location = New System.Drawing.Point(880, 0)
        Me.btnClearMessageFilter.Name = "btnClearMessageFilter"
        Me.btnClearMessageFilter.Size = New System.Drawing.Size(34, 36)
        Me.btnClearMessageFilter.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnClearMessageFilter, "Clear message filters")
        Me.btnClearMessageFilter.UseVisualStyleBackColor = True
        '
        'llblFilter
        '
        Me.llblFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llblFilter.AutoSize = True
        Me.llblFilter.BackColor = System.Drawing.Color.Transparent
        Me.llblFilter.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.llblFilter.LinkArea = New System.Windows.Forms.LinkArea(0, 0)
        Me.llblFilter.Location = New System.Drawing.Point(569, 3)
        Me.llblFilter.Name = "llblFilter"
        Me.llblFilter.Size = New System.Drawing.Size(47, 18)
        Me.llblFilter.TabIndex = 10
        Me.llblFilter.Text = "Filter:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(806, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(105, 30)
        Me.btnCancel.TabIndex = 57
        Me.btnCancel.Values.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.btnCancel.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnCancel.Values.Text = "&Cancel"
        Me.btnCancel.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(3, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(105, 30)
        Me.btnSearch.TabIndex = 56
        Me.btnSearch.Values.Image = Global.TrulyMail.My.Resources.Resources.Search_16
        Me.btnSearch.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnSearch.Values.Text = "&Search"
        '
        'lblSearchProgress
        '
        Me.lblSearchProgress.Location = New System.Drawing.Point(122, 7)
        Me.lblSearchProgress.Name = "lblSearchProgress"
        Me.lblSearchProgress.Size = New System.Drawing.Size(68, 19)
        Me.lblSearchProgress.TabIndex = 55
        Me.lblSearchProgress.Values.Text = "Progress:"
        Me.lblSearchProgress.Visible = False
        '
        'prgSearchProgress
        '
        Me.prgSearchProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prgSearchProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.prgSearchProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prgSearchProgress.ForeColor = System.Drawing.Color.Blue
        Me.prgSearchProgress.HighLowCutoff = CType(90, Byte)
        Me.prgSearchProgress.HighTextDecimalPlaces = CType(0, Byte)
        Me.prgSearchProgress.Location = New System.Drawing.Point(188, 4)
        Me.prgSearchProgress.LowTextDecimalPlaces = CType(0, Byte)
        Me.prgSearchProgress.Maximum = CType(100, Long)
        Me.prgSearchProgress.Minimum = CType(0, Long)
        Me.prgSearchProgress.Name = "prgSearchProgress"
        Me.prgSearchProgress.Size = New System.Drawing.Size(612, 25)
        Me.prgSearchProgress.TabIndex = 23
        Me.prgSearchProgress.Value = CType(0, Long)
        Me.prgSearchProgress.Visible = False
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'KryptonManager
        '
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonManager.GlobalPalette = Me.KryptonPalette1
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom
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
        Me.ImageList1.Images.SetKeyName(10, "infinity_24.png")
        '
        'tmrFilterMessages
        '
        Me.tmrFilterMessages.Interval = 400.0R
        Me.tmrFilterMessages.SynchronizingObject = Me
        '
        'tmrStatusUpdater
        '
        Me.tmrStatusUpdater.Enabled = True
        Me.tmrStatusUpdater.Interval = 2000.0R
        Me.tmrStatusUpdater.SynchronizingObject = Me
        '
        'OrphanedAttachments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(914, 565)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OrphanedAttachments"
        Me.Text = "Find Orphaned Attachments"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.pnlResults.ResumeLayout(False)
        Me.pnlResults.PerformLayout()
        CType(Me.olvAttachments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmnuAttachments.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pnlMessageFilter.ResumeLayout(False)
        Me.pnlMessageFilter.PerformLayout()
        CType(Me.tmrFilterMessages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tmrStatusUpdater, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ctxmnuAttachments As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenAttachmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents prgSearchProgress As MontgomerySoftware.Controls.ProgressBar
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tmrFilterMessages As System.Timers.Timer
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnSearch As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblSearchProgress As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents pnlResults As System.Windows.Forms.Panel
    Friend WithEvents olvAttachments As BrightIdeasSoftware.ObjectListView
    Friend WithEvents olvColumnAttachmentName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnAttachmentSize As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnFullPath As BrightIdeasSoftware.OLVColumn
    Friend WithEvents pnlMessageFilter As System.Windows.Forms.Panel
    Friend WithEvents txtMessageFilter As System.Windows.Forms.TextBox
    Friend WithEvents btnClearMessageFilter As System.Windows.Forms.Button
    Friend WithEvents llblFilter As System.Windows.Forms.LinkLabel
    Friend WithEvents btnToggleGroups As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnDeleteSelected As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnSelectAll As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents OpenFileLocationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCheckSelected As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelSizeOfMessages As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FilterMessageCountToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SelectedStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TotalStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmrStatusUpdater As System.Timers.Timer
    Friend WithEvents OlvColumnSelected As BrightIdeasSoftware.OLVColumn
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
End Class
