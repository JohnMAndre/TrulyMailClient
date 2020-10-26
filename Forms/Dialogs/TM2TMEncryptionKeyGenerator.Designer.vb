<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TM2TMEncryptionKeyGenerator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TM2TMEncryptionKeyGenerator))
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.olvAddressBook = New BrightIdeasSoftware.ObjectListView()
        Me.IconColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.NameColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.AddressColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.TagsColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.RequestReturnReceiptColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.SendReturnReceiptColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.LastMessageReceivedColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.LastMessageSentColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnUseThisContact = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCopyKeyToClipboard = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnWriteKeyToTextFile = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnGenerateKey = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.olvAddressBook, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.KryptonPanel.Controls.Add(Me.SplitContainer1)
        Me.KryptonPanel.Controls.Add(Me.btnCopyKeyToClipboard)
        Me.KryptonPanel.Controls.Add(Me.btnWriteKeyToTextFile)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.btnGenerateKey)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(889, 537)
        Me.KryptonPanel.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.RichTextBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.olvAddressBook)
        Me.SplitContainer1.Panel2.Controls.Add(Me.KryptonPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(886, 475)
        Me.SplitContainer1.SplitterDistance = 270
        Me.SplitContainer1.TabIndex = 62
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(270, 475)
        Me.RichTextBox1.TabIndex = 59
        Me.RichTextBox1.Text = ""
        '
        'olvAddressBook
        '
        Me.olvAddressBook.AllColumns.Add(Me.IconColumn)
        Me.olvAddressBook.AllColumns.Add(Me.NameColumn)
        Me.olvAddressBook.AllColumns.Add(Me.AddressColumn)
        Me.olvAddressBook.AllColumns.Add(Me.TagsColumn)
        Me.olvAddressBook.AllColumns.Add(Me.RequestReturnReceiptColumn)
        Me.olvAddressBook.AllColumns.Add(Me.SendReturnReceiptColumn)
        Me.olvAddressBook.AllColumns.Add(Me.LastMessageReceivedColumn)
        Me.olvAddressBook.AllColumns.Add(Me.LastMessageSentColumn)
        Me.olvAddressBook.AllowColumnReorder = True
        Me.olvAddressBook.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvAddressBook.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
        Me.olvAddressBook.CellEditUseWholeCell = False
        Me.olvAddressBook.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IconColumn, Me.NameColumn, Me.AddressColumn, Me.TagsColumn, Me.RequestReturnReceiptColumn, Me.SendReturnReceiptColumn, Me.LastMessageReceivedColumn, Me.LastMessageSentColumn})
        Me.olvAddressBook.Cursor = System.Windows.Forms.Cursors.Default
        Me.olvAddressBook.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvAddressBook.EmptyListMsg = "No matching contacts found"
        Me.olvAddressBook.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvAddressBook.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvAddressBook.FullRowSelect = True
        Me.olvAddressBook.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvAddressBook.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvAddressBook.LabelWrap = False
        Me.olvAddressBook.Location = New System.Drawing.Point(0, 41)
        Me.olvAddressBook.Name = "olvAddressBook"
        Me.olvAddressBook.OverlayImage.Alignment = System.Drawing.ContentAlignment.BottomLeft
        Me.olvAddressBook.OverlayImage.ShrinkToWidth = True
        Me.olvAddressBook.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.olvAddressBook.ShowCommandMenuOnRightClick = True
        Me.olvAddressBook.ShowGroups = False
        Me.olvAddressBook.ShowImagesOnSubItems = True
        Me.olvAddressBook.ShowItemCountOnGroups = True
        Me.olvAddressBook.Size = New System.Drawing.Size(612, 434)
        Me.olvAddressBook.SmallImageList = Me.ImageList1
        Me.olvAddressBook.TabIndex = 11
        Me.olvAddressBook.UseAlternatingBackColors = True
        Me.olvAddressBook.UseCompatibleStateImageBehavior = False
        Me.olvAddressBook.UseFiltering = True
        Me.olvAddressBook.UseHotItem = True
        Me.olvAddressBook.UseHyperlinks = True
        Me.olvAddressBook.UseSubItemCheckBoxes = True
        Me.olvAddressBook.View = System.Windows.Forms.View.Details
        '
        'IconColumn
        '
        Me.IconColumn.AspectName = "ContactType"
        Me.IconColumn.HeaderFont = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.IconColumn.IsEditable = False
        Me.IconColumn.MaximumWidth = 24
        Me.IconColumn.MinimumWidth = 24
        Me.IconColumn.Text = "+"
        Me.IconColumn.ToolTipText = "Transport type (TrulyMail, email)"
        Me.IconColumn.Width = 24
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
        Me.TagsColumn.DisplayIndex = 5
        Me.TagsColumn.Text = "Tags"
        Me.TagsColumn.Width = 135
        '
        'RequestReturnReceiptColumn
        '
        Me.RequestReturnReceiptColumn.AspectName = "AutoRequestReadReceipt"
        Me.RequestReturnReceiptColumn.CheckBoxes = True
        Me.RequestReturnReceiptColumn.DisplayIndex = 3
        Me.RequestReturnReceiptColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RequestReturnReceiptColumn.Text = "Req Receipt"
        Me.RequestReturnReceiptColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RequestReturnReceiptColumn.Width = 83
        '
        'SendReturnReceiptColumn
        '
        Me.SendReturnReceiptColumn.AspectName = "AutoSendReadReceipt"
        Me.SendReturnReceiptColumn.DisplayIndex = 4
        Me.SendReturnReceiptColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SendReturnReceiptColumn.Text = "Send Receipt"
        Me.SendReturnReceiptColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SendReturnReceiptColumn.Width = 95
        '
        'LastMessageReceivedColumn
        '
        Me.LastMessageReceivedColumn.AspectName = "LastMessageReceived"
        Me.LastMessageReceivedColumn.AspectToStringFormat = "{0:d}"
        Me.LastMessageReceivedColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.LastMessageReceivedColumn.IsEditable = False
        Me.LastMessageReceivedColumn.Text = "Received"
        Me.LastMessageReceivedColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.LastMessageReceivedColumn.ToolTipText = "Data last message was received from this contact"
        Me.LastMessageReceivedColumn.Width = 80
        '
        'LastMessageSentColumn
        '
        Me.LastMessageSentColumn.AspectName = "LastMessageSent"
        Me.LastMessageSentColumn.AspectToStringFormat = "{0:d}"
        Me.LastMessageSentColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.LastMessageSentColumn.IsEditable = False
        Me.LastMessageSentColumn.Text = "Sent"
        Me.LastMessageSentColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.LastMessageSentColumn.ToolTipText = "Date last message was sent to this contact"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "secured message.png")
        Me.ImageList1.Images.SetKeyName(1, "e-mail.png")
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.btnUseThisContact)
        Me.KryptonPanel1.Controls.Add(Me.Label1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Palette = Me.KryptonPalette1
        Me.KryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel1.Size = New System.Drawing.Size(612, 41)
        Me.KryptonPanel1.TabIndex = 60
        '
        'btnUseThisContact
        '
        Me.btnUseThisContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUseThisContact.Location = New System.Drawing.Point(443, 4)
        Me.btnUseThisContact.Name = "btnUseThisContact"
        Me.btnUseThisContact.Size = New System.Drawing.Size(165, 33)
        Me.btnUseThisContact.TabIndex = 57
        Me.btnUseThisContact.Values.Image = Global.TrulyMail.My.Resources.Resources.CheckMark_16
        Me.btnUseThisContact.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnUseThisContact.Values.Text = "Use this contact"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(555, 31)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Please choose the contact for this password."
        '
        'btnCopyKeyToClipboard
        '
        Me.btnCopyKeyToClipboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyKeyToClipboard.Location = New System.Drawing.Point(508, 495)
        Me.btnCopyKeyToClipboard.Name = "btnCopyKeyToClipboard"
        Me.btnCopyKeyToClipboard.Size = New System.Drawing.Size(198, 30)
        Me.btnCopyKeyToClipboard.TabIndex = 61
        Me.btnCopyKeyToClipboard.Values.Image = Global.TrulyMail.My.Resources.Resources.Copy_16
        Me.btnCopyKeyToClipboard.Values.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopyKeyToClipboard.Values.Text = "Copy password to clipboard"
        '
        'btnWriteKeyToTextFile
        '
        Me.btnWriteKeyToTextFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnWriteKeyToTextFile.Location = New System.Drawing.Point(278, 495)
        Me.btnWriteKeyToTextFile.Name = "btnWriteKeyToTextFile"
        Me.btnWriteKeyToTextFile.Size = New System.Drawing.Size(220, 30)
        Me.btnWriteKeyToTextFile.TabIndex = 60
        Me.btnWriteKeyToTextFile.Values.Image = Global.TrulyMail.My.Resources.Resources.Text_16
        Me.btnWriteKeyToTextFile.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnWriteKeyToTextFile.Values.Text = "Write password to text file"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(720, 495)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(157, 30)
        Me.btnCancel.TabIndex = 57
        Me.btnCancel.Values.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.btnCancel.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnCancel.Values.Text = "&Close"
        '
        'btnGenerateKey
        '
        Me.btnGenerateKey.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateKey.Location = New System.Drawing.Point(13, 495)
        Me.btnGenerateKey.Name = "btnGenerateKey"
        Me.btnGenerateKey.Size = New System.Drawing.Size(259, 30)
        Me.btnGenerateKey.TabIndex = 56
        Me.btnGenerateKey.Values.Image = Global.TrulyMail.My.Resources.Resources.Securedmessage_16
        Me.btnGenerateKey.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnGenerateKey.Values.Text = "Generate encryption password"
        '
        'TM2TMEncryptionKeyGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 537)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TM2TMEncryptionKeyGenerator"
        Me.Text = "Encryption password"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.olvAddressBook, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnGenerateKey As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents btnWriteKeyToTextFile As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCopyKeyToClipboard As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents olvAddressBook As BrightIdeasSoftware.ObjectListView
    Friend WithEvents IconColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents NameColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents AddressColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents TagsColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents RequestReturnReceiptColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents SendReturnReceiptColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents LastMessageReceivedColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents LastMessageSentColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnUseThisContact As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
End Class
