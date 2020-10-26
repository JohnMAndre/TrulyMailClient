<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageSelectorForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MessageSelectorForm))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tvFolders = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.olvMessages = New BrightIdeasSoftware.ObjectListView()
        Me.olvColumnSubject = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnAttachments = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnOtherParties = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnMessageDateSent = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnSize = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnReceived = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnViewed = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnTransportType = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnHasNotes = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnTags = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ImglstMessageStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlMessageFilter = New System.Windows.Forms.Panel()
        Me.txtMessageFilter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClearMessageFilter = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.olvMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMessageFilter.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvFolders)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.olvMessages)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlMessageFilter)
        Me.SplitContainer1.Size = New System.Drawing.Size(807, 575)
        Me.SplitContainer1.SplitterDistance = 162
        Me.SplitContainer1.TabIndex = 20
        '
        'tvFolders
        '
        Me.tvFolders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvFolders.HideSelection = False
        Me.tvFolders.ImageIndex = 0
        Me.tvFolders.ImageList = Me.ImageList1
        Me.tvFolders.Indent = 27
        Me.tvFolders.ItemHeight = 24
        Me.tvFolders.Location = New System.Drawing.Point(0, 0)
        Me.tvFolders.Name = "tvFolders"
        Me.tvFolders.SelectedImageKey = "Folder_Open.png"
        Me.tvFolders.ShowNodeToolTips = True
        Me.tvFolders.Size = New System.Drawing.Size(162, 575)
        Me.tvFolders.TabIndex = 15
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
        '
        'olvMessages
        '
        Me.olvMessages.AllColumns.Add(Me.olvColumnSubject)
        Me.olvMessages.AllColumns.Add(Me.olvColumnAttachments)
        Me.olvMessages.AllColumns.Add(Me.olvColumnOtherParties)
        Me.olvMessages.AllColumns.Add(Me.olvColumnMessageDateSent)
        Me.olvMessages.AllColumns.Add(Me.olvColumnSize)
        Me.olvMessages.AllColumns.Add(Me.olvColumnReceived)
        Me.olvMessages.AllColumns.Add(Me.olvColumnViewed)
        Me.olvMessages.AllColumns.Add(Me.olvColumnTransportType)
        Me.olvMessages.AllColumns.Add(Me.olvColumnHasNotes)
        Me.olvMessages.AllColumns.Add(Me.olvColumnTags)
        Me.olvMessages.AllowColumnReorder = True
        Me.olvMessages.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
        Me.olvMessages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvColumnSubject, Me.olvColumnAttachments, Me.olvColumnOtherParties, Me.olvColumnMessageDateSent, Me.olvColumnSize, Me.olvColumnReceived, Me.olvColumnViewed, Me.olvColumnTransportType, Me.olvColumnHasNotes, Me.olvColumnTags})
        Me.olvMessages.Cursor = System.Windows.Forms.Cursors.Default
        Me.olvMessages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvMessages.EmptyListMsg = "This folder is empty"
        Me.olvMessages.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvMessages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvMessages.FullRowSelect = True
        Me.olvMessages.HideSelection = False
        Me.olvMessages.LabelWrap = False
        Me.olvMessages.Location = New System.Drawing.Point(0, 22)
        Me.olvMessages.Name = "olvMessages"
        Me.olvMessages.OwnerDraw = True
        Me.olvMessages.ShowCommandMenuOnRightClick = True
        Me.olvMessages.ShowGroups = False
        Me.olvMessages.ShowImagesOnSubItems = True
        Me.olvMessages.ShowItemCountOnGroups = True
        Me.olvMessages.Size = New System.Drawing.Size(641, 553)
        Me.olvMessages.SmallImageList = Me.ImglstMessageStatus
        Me.olvMessages.TabIndex = 2
        Me.olvMessages.UseCompatibleStateImageBehavior = False
        Me.olvMessages.UseFiltering = True
        Me.olvMessages.View = System.Windows.Forms.View.Details
        '
        'olvColumnSubject
        '
        Me.olvColumnSubject.AspectName = "SubjectShort"
        Me.olvColumnSubject.DisplayIndex = 2
        Me.olvColumnSubject.Hyperlink = True
        Me.olvColumnSubject.IsEditable = False
        Me.olvColumnSubject.Text = "Subject"
        Me.olvColumnSubject.ToolTipText = "Message Subject"
        '
        'olvColumnAttachments
        '
        Me.olvColumnAttachments.AspectName = "Attachments"
        Me.olvColumnAttachments.DisplayIndex = 3
        Me.olvColumnAttachments.IsEditable = False
        Me.olvColumnAttachments.Text = "A"
        Me.olvColumnAttachments.ToolTipText = "Number of Attachments"
        '
        'olvColumnOtherParties
        '
        Me.olvColumnOtherParties.AspectName = "OtherPartiesShort"
        Me.olvColumnOtherParties.DisplayIndex = 4
        Me.olvColumnOtherParties.IsEditable = False
        Me.olvColumnOtherParties.Text = "Sender"
        '
        'olvColumnMessageDateSent
        '
        Me.olvColumnMessageDateSent.AspectName = "MessageDateSent"
        Me.olvColumnMessageDateSent.DisplayIndex = 5
        Me.olvColumnMessageDateSent.IsEditable = False
        Me.olvColumnMessageDateSent.Text = "Date"
        Me.olvColumnMessageDateSent.ToolTipText = "Date Message Sent"
        '
        'olvColumnSize
        '
        Me.olvColumnSize.AspectName = "Size"
        Me.olvColumnSize.DisplayIndex = 6
        Me.olvColumnSize.IsEditable = False
        Me.olvColumnSize.Text = "Size"
        Me.olvColumnSize.ToolTipText = "Total Size of Message and Attachments"
        '
        'olvColumnReceived
        '
        Me.olvColumnReceived.AspectName = "Received"
        Me.olvColumnReceived.AspectToStringFormat = "{0:P0}"
        Me.olvColumnReceived.DisplayIndex = 7
        Me.olvColumnReceived.IsEditable = False
        Me.olvColumnReceived.Text = "Rec"
        Me.olvColumnReceived.ToolTipText = "Percentage of Recipients Who Have Received Message (sent messages only)"
        '
        'olvColumnViewed
        '
        Me.olvColumnViewed.AspectName = "Viewed"
        Me.olvColumnViewed.AspectToStringFormat = "{0:P0}"
        Me.olvColumnViewed.DisplayIndex = 8
        Me.olvColumnViewed.IsEditable = False
        Me.olvColumnViewed.Text = "View"
        Me.olvColumnViewed.ToolTipText = "Percentage of Recipients Who Have Viewed Message (sent messages only)"
        '
        'olvColumnTransportType
        '
        Me.olvColumnTransportType.AspectName = "TransportType"
        Me.olvColumnTransportType.DisplayIndex = 0
        Me.olvColumnTransportType.IsEditable = False
        Me.olvColumnTransportType.Text = ""
        Me.olvColumnTransportType.ToolTipText = "Transport System (email, TrulyMail, mixed))"
        '
        'olvColumnHasNotes
        '
        Me.olvColumnHasNotes.AspectName = "HasNotes"
        Me.olvColumnHasNotes.DisplayIndex = 1
        Me.olvColumnHasNotes.IsEditable = False
        Me.olvColumnHasNotes.Text = ""
        Me.olvColumnHasNotes.ToolTipText = "Message Has Notes"
        '
        'olvColumnTags
        '
        Me.olvColumnTags.AspectName = "Tags"
        Me.olvColumnTags.Text = "Tags"
        Me.olvColumnTags.Width = 120
        '
        'ImglstMessageStatus
        '
        Me.ImglstMessageStatus.ImageStream = CType(resources.GetObject("ImglstMessageStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImglstMessageStatus.TransparentColor = System.Drawing.Color.Transparent
        Me.ImglstMessageStatus.Images.SetKeyName(0, "Reply_2_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(1, "ForwardReply_2_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(2, "Forward_2_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(3, "email_16.bmp")
        Me.ImglstMessageStatus.Images.SetKeyName(4, "Securedmessage_16.bmp")
        Me.ImglstMessageStatus.Images.SetKeyName(5, "MixedTransport_16.bmp")
        Me.ImglstMessageStatus.Images.SetKeyName(6, "noteTrans_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(7, "Transparent_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(8, "redemail_16.png")
        '
        'pnlMessageFilter
        '
        Me.pnlMessageFilter.AutoSize = True
        Me.pnlMessageFilter.BackColor = System.Drawing.Color.Transparent
        Me.pnlMessageFilter.Controls.Add(Me.txtMessageFilter)
        Me.pnlMessageFilter.Controls.Add(Me.Label1)
        Me.pnlMessageFilter.Controls.Add(Me.btnClearMessageFilter)
        Me.pnlMessageFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMessageFilter.Location = New System.Drawing.Point(0, 0)
        Me.pnlMessageFilter.Name = "pnlMessageFilter"
        Me.pnlMessageFilter.Size = New System.Drawing.Size(641, 22)
        Me.pnlMessageFilter.TabIndex = 3
        '
        'txtMessageFilter
        '
        Me.txtMessageFilter.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtMessageFilter.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessageFilter.Location = New System.Drawing.Point(465, 0)
        Me.txtMessageFilter.Name = "txtMessageFilter"
        Me.txtMessageFilter.Size = New System.Drawing.Size(142, 26)
        Me.txtMessageFilter.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(419, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filter:"
        '
        'btnClearMessageFilter
        '
        Me.btnClearMessageFilter.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClearMessageFilter.Image = CType(resources.GetObject("btnClearMessageFilter.Image"), System.Drawing.Image)
        Me.btnClearMessageFilter.Location = New System.Drawing.Point(607, 0)
        Me.btnClearMessageFilter.Name = "btnClearMessageFilter"
        Me.btnClearMessageFilter.Size = New System.Drawing.Size(34, 22)
        Me.btnClearMessageFilter.TabIndex = 2
        Me.btnClearMessageFilter.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnOK)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 575)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(807, 43)
        Me.Panel1.TabIndex = 21
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(315, 7)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 29)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(411, 7)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(81, 29)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
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
        Me.KryptonPanel.Controls.Add(Me.SplitContainer1)
        Me.KryptonPanel.Controls.Add(Me.Panel1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(807, 618)
        Me.KryptonPanel.TabIndex = 22
        '
        'MessageSelectorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(807, 618)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MessageSelectorForm"
        Me.Text = "Select Message"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.olvMessages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMessageFilter.ResumeLayout(False)
        Me.pnlMessageFilter.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tvFolders As System.Windows.Forms.TreeView
    Friend WithEvents olvMessages As BrightIdeasSoftware.ObjectListView
    Friend WithEvents olvColumnSubject As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnAttachments As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnOtherParties As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnMessageDateSent As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnSize As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnReceived As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnViewed As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnTransportType As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnHasNotes As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnTags As BrightIdeasSoftware.OLVColumn
    Friend WithEvents pnlMessageFilter As System.Windows.Forms.Panel
    Friend WithEvents txtMessageFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClearMessageFilter As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ImglstMessageStatus As System.Windows.Forms.ImageList
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
End Class
