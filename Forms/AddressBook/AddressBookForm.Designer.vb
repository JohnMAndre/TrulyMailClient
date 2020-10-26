<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddressBookForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddressBookForm))
        Dim HeaderStateStyle1 As BrightIdeasSoftware.HeaderStateStyle = New BrightIdeasSoftware.HeaderStateStyle()
        Dim HeaderStateStyle2 As BrightIdeasSoftware.HeaderStateStyle = New BrightIdeasSoftware.HeaderStateStyle()
        Dim HeaderStateStyle3 As BrightIdeasSoftware.HeaderStateStyle = New BrightIdeasSoftware.HeaderStateStyle()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ContactCountStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboMessageTags = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClearMessageFilter = New System.Windows.Forms.Button()
        Me.olvAddressBook = New BrightIdeasSoftware.ObjectListView()
        Me.IconColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.HeaderFormatStyleWingDings = New BrightIdeasSoftware.HeaderFormatStyle()
        Me.NameColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.AddressColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.RemoteImagesColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ReceiveOnlyColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.DateAddedColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.RequestReturnReceiptColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.SendReturnReceiptColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.TagsColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.LastMessageReceivedColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.LastMessageSentColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.RemindReceiveColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.RemindSendColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ImportanceColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.SMTPColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.HotItemStyle1 = New BrightIdeasSoftware.HotItemStyle()
        Me.pbClearTags = New System.Windows.Forms.PictureBox()
        Me.pbAddTag = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewContactImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ResetColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewEmailContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditselectedContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ComposeMessageToSelectedContactsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlockSelectedContactsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnblockSelectedContactsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangeSendingAccountForSelectedContactsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutTrulyMailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NewEmailToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.InviteTrulyMailContactToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ComposeMessageToSelectedContactsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DeleteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ctxmnuColumnSelector = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.ImglstMessageStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.ContactPictureDisplay1 = New TrulyMail.ContactPictureDisplay()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.olvAddressBook, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClearTags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddTag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusToolStripStatusLabel, Me.ToolStripStatusLabel1, Me.ContactCountStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1194, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusToolStripStatusLabel
        '
        Me.StatusToolStripStatusLabel.BackColor = System.Drawing.Color.White
        Me.StatusToolStripStatusLabel.Name = "StatusToolStripStatusLabel"
        Me.StatusToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.StatusToolStripStatusLabel.Text = "Ready"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(1074, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ContactCountStatusLabel
        '
        Me.ContactCountStatusLabel.Name = "ContactCountStatusLabel"
        Me.ContactCountStatusLabel.Size = New System.Drawing.Size(66, 17)
        Me.ContactCountStatusLabel.Text = "Contacts: 0"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1194, 24)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1186, 0)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Contacts"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1186, 0)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Blocked Contacts"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(301, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 18)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Filter:"
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(354, 31)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(797, 20)
        Me.txtFilter.TabIndex = 7
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.StatusStrip1)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Panel1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1194, 446)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1194, 530)
        Me.ToolStripContainer1.TabIndex = 11
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cboMessageTags)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ContactPictureDisplay1)
        Me.Panel1.Controls.Add(Me.btnClearMessageFilter)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Controls.Add(Me.txtFilter)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.olvAddressBook)
        Me.Panel1.Controls.Add(Me.pbClearTags)
        Me.Panel1.Controls.Add(Me.pbAddTag)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1194, 446)
        Me.Panel1.TabIndex = 12
        '
        'cboMessageTags
        '
        Me.cboMessageTags.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cboMessageTags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMessageTags.FormattingEnabled = True
        Me.cboMessageTags.Location = New System.Drawing.Point(49, 31)
        Me.cboMessageTags.Name = "cboMessageTags"
        Me.cboMessageTags.Size = New System.Drawing.Size(159, 21)
        Me.cboMessageTags.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 18)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Tag:"
        '
        'btnClearMessageFilter
        '
        Me.btnClearMessageFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearMessageFilter.Image = CType(resources.GetObject("btnClearMessageFilter.Image"), System.Drawing.Image)
        Me.btnClearMessageFilter.Location = New System.Drawing.Point(1154, 27)
        Me.btnClearMessageFilter.Name = "btnClearMessageFilter"
        Me.btnClearMessageFilter.Size = New System.Drawing.Size(34, 26)
        Me.btnClearMessageFilter.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.btnClearMessageFilter, "Clear search filter")
        Me.btnClearMessageFilter.UseVisualStyleBackColor = True
        '
        'olvAddressBook
        '
        Me.olvAddressBook.AllColumns.Add(Me.IconColumn)
        Me.olvAddressBook.AllColumns.Add(Me.NameColumn)
        Me.olvAddressBook.AllColumns.Add(Me.AddressColumn)
        Me.olvAddressBook.AllColumns.Add(Me.RemoteImagesColumn)
        Me.olvAddressBook.AllColumns.Add(Me.ReceiveOnlyColumn)
        Me.olvAddressBook.AllColumns.Add(Me.DateAddedColumn)
        Me.olvAddressBook.AllColumns.Add(Me.RequestReturnReceiptColumn)
        Me.olvAddressBook.AllColumns.Add(Me.SendReturnReceiptColumn)
        Me.olvAddressBook.AllColumns.Add(Me.TagsColumn)
        Me.olvAddressBook.AllColumns.Add(Me.LastMessageReceivedColumn)
        Me.olvAddressBook.AllColumns.Add(Me.LastMessageSentColumn)
        Me.olvAddressBook.AllColumns.Add(Me.RemindReceiveColumn)
        Me.olvAddressBook.AllColumns.Add(Me.RemindSendColumn)
        Me.olvAddressBook.AllColumns.Add(Me.ImportanceColumn)
        Me.olvAddressBook.AllColumns.Add(Me.SMTPColumn)
        Me.olvAddressBook.AllowColumnReorder = True
        Me.olvAddressBook.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvAddressBook.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.olvAddressBook.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
        Me.olvAddressBook.CellEditUseWholeCell = False
        Me.olvAddressBook.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IconColumn, Me.NameColumn, Me.AddressColumn, Me.RemoteImagesColumn, Me.ReceiveOnlyColumn, Me.DateAddedColumn, Me.RequestReturnReceiptColumn, Me.SendReturnReceiptColumn, Me.TagsColumn, Me.LastMessageReceivedColumn, Me.LastMessageSentColumn, Me.RemindReceiveColumn, Me.RemindSendColumn, Me.ImportanceColumn, Me.SMTPColumn})
        Me.olvAddressBook.Cursor = System.Windows.Forms.Cursors.Default
        Me.olvAddressBook.EmptyListMsg = "No matching contacts found"
        Me.olvAddressBook.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvAddressBook.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvAddressBook.FullRowSelect = True
        Me.olvAddressBook.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvAddressBook.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvAddressBook.HotItemStyle = Me.HotItemStyle1
        Me.olvAddressBook.LabelWrap = False
        Me.olvAddressBook.Location = New System.Drawing.Point(1, 57)
        Me.olvAddressBook.Name = "olvAddressBook"
        Me.olvAddressBook.OverlayImage.Alignment = System.Drawing.ContentAlignment.BottomLeft
        Me.olvAddressBook.OverlayImage.ShrinkToWidth = True
        Me.olvAddressBook.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.olvAddressBook.ShowCommandMenuOnRightClick = True
        Me.olvAddressBook.ShowGroups = False
        Me.olvAddressBook.ShowImagesOnSubItems = True
        Me.olvAddressBook.ShowItemCountOnGroups = True
        Me.olvAddressBook.Size = New System.Drawing.Size(1192, 390)
        Me.olvAddressBook.SmallImageList = Me.ImglstMessageStatus
        Me.olvAddressBook.TabIndex = 10
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
        Me.IconColumn.HeaderImageKey = "Securedmessage_16.png"
        Me.IconColumn.IsEditable = False
        Me.IconColumn.MaximumWidth = 24
        Me.IconColumn.MinimumWidth = 24
        Me.IconColumn.ShowTextInHeader = False
        Me.IconColumn.Text = "Transport type"
        Me.IconColumn.ToolTipText = "Transport type (email, other)"
        Me.IconColumn.Width = 24
        '
        'HeaderFormatStyleWingDings
        '
        HeaderStateStyle1.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.HeaderFormatStyleWingDings.Hot = HeaderStateStyle1
        HeaderStateStyle2.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.HeaderFormatStyleWingDings.Normal = HeaderStateStyle2
        HeaderStateStyle3.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.HeaderFormatStyleWingDings.Pressed = HeaderStateStyle3
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
        'RemoteImagesColumn
        '
        Me.RemoteImagesColumn.AspectName = "RemoteImages"
        Me.RemoteImagesColumn.CheckBoxes = True
        Me.RemoteImagesColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RemoteImagesColumn.Text = "Remote Images"
        Me.RemoteImagesColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RemoteImagesColumn.Width = 100
        '
        'ReceiveOnlyColumn
        '
        Me.ReceiveOnlyColumn.AspectName = "ReceiveOnly"
        Me.ReceiveOnlyColumn.CheckBoxes = True
        Me.ReceiveOnlyColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ReceiveOnlyColumn.Text = "Receive Only"
        Me.ReceiveOnlyColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ReceiveOnlyColumn.Width = 100
        '
        'DateAddedColumn
        '
        Me.DateAddedColumn.AspectName = "Added"
        Me.DateAddedColumn.AspectToStringFormat = "{0:d}"
        Me.DateAddedColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DateAddedColumn.IsEditable = False
        Me.DateAddedColumn.Text = "Added"
        Me.DateAddedColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RequestReturnReceiptColumn
        '
        Me.RequestReturnReceiptColumn.AspectName = "AutoRequestReadReceipt"
        Me.RequestReturnReceiptColumn.CheckBoxes = True
        Me.RequestReturnReceiptColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RequestReturnReceiptColumn.Text = "Req Receipt"
        Me.RequestReturnReceiptColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RequestReturnReceiptColumn.Width = 83
        '
        'SendReturnReceiptColumn
        '
        Me.SendReturnReceiptColumn.AspectName = "AutoSendReadReceipt"
        Me.SendReturnReceiptColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SendReturnReceiptColumn.Text = "Send Receipt"
        Me.SendReturnReceiptColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SendReturnReceiptColumn.Width = 95
        '
        'TagsColumn
        '
        Me.TagsColumn.AspectName = "Tags"
        Me.TagsColumn.Text = "Tags"
        Me.TagsColumn.Width = 135
        '
        'LastMessageReceivedColumn
        '
        Me.LastMessageReceivedColumn.AspectName = "LastMessageReceived"
        Me.LastMessageReceivedColumn.AspectToStringFormat = "{0:d}"
        Me.LastMessageReceivedColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.LastMessageSentColumn.Text = "Sent"
        Me.LastMessageSentColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.LastMessageSentColumn.ToolTipText = "Date last message was sent to this contact"
        '
        'RemindReceiveColumn
        '
        Me.RemindReceiveColumn.AspectName = "RemindReceiveEveryXDays"
        Me.RemindReceiveColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RemindReceiveColumn.Text = "Receive Reminder"
        Me.RemindReceiveColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RemindReceiveColumn.ToolTipText = "Remind if no message received from this contact in this many days"
        '
        'RemindSendColumn
        '
        Me.RemindSendColumn.AspectName = "RemindSendEveryXDays"
        Me.RemindSendColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RemindSendColumn.Text = "Send Reminder"
        Me.RemindSendColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RemindSendColumn.ToolTipText = "Remind if no message sent to this contact in this many days"
        '
        'ImportanceColumn
        '
        Me.ImportanceColumn.AspectName = "ImportanceRating"
        Me.ImportanceColumn.HeaderImageKey = "spam scales.png"
        Me.ImportanceColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ImportanceColumn.ShowTextInHeader = False
        Me.ImportanceColumn.Text = "Importance"
        Me.ImportanceColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ImportanceColumn.ToolTipText = "Importance to be applied to messages received from this contact"
        '
        'SMTPColumn
        '
        Me.SMTPColumn.AspectName = "SMTPProfile"
        Me.SMTPColumn.Text = "Sending Account"
        '
        'HotItemStyle1
        '
        Me.HotItemStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.HotItemStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HotItemStyle1.FontStyle = System.Drawing.FontStyle.Bold
        Me.HotItemStyle1.ForeColor = System.Drawing.Color.Black
        '
        'pbClearTags
        '
        Me.pbClearTags.Image = Global.TrulyMail.My.Resources.Resources.remove_icon_48
        Me.pbClearTags.Location = New System.Drawing.Point(246, 28)
        Me.pbClearTags.Name = "pbClearTags"
        Me.pbClearTags.Size = New System.Drawing.Size(32, 26)
        Me.pbClearTags.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbClearTags.TabIndex = 15
        Me.pbClearTags.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbClearTags, "Remove all tags from selected message(s)")
        '
        'pbAddTag
        '
        Me.pbAddTag.Image = Global.TrulyMail.My.Resources.Resources.add_icon_48
        Me.pbAddTag.Location = New System.Drawing.Point(214, 28)
        Me.pbAddTag.Name = "pbAddTag"
        Me.pbAddTag.Size = New System.Drawing.Size(32, 26)
        Me.pbAddTag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddTag.TabIndex = 14
        Me.pbAddTag.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbAddTag, "Add selected tag to selected message(s)")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ContactToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1194, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportToolStripMenuItem, Me.ExportToolStripMenuItem, Me.ToolStripSeparator4, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.ImportToolStripMenuItem.Text = "&Import..."
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.ExportToolStripMenuItem.Text = "&Export"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(116, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewContactImageToolStripMenuItem, Me.ToolStripSeparator6, Me.ResetColumnsToolStripMenuItem, Me.SelectColumnsToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'ViewContactImageToolStripMenuItem
        '
        Me.ViewContactImageToolStripMenuItem.Checked = True
        Me.ViewContactImageToolStripMenuItem.CheckOnClick = True
        Me.ViewContactImageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ViewContactImageToolStripMenuItem.Name = "ViewContactImageToolStripMenuItem"
        Me.ViewContactImageToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.ViewContactImageToolStripMenuItem.Text = "Contact &image"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(160, 6)
        '
        'ResetColumnsToolStripMenuItem
        '
        Me.ResetColumnsToolStripMenuItem.Name = "ResetColumnsToolStripMenuItem"
        Me.ResetColumnsToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.ResetColumnsToolStripMenuItem.Text = "&Reset columns"
        '
        'SelectColumnsToolStripMenuItem
        '
        Me.SelectColumnsToolStripMenuItem.Name = "SelectColumnsToolStripMenuItem"
        Me.SelectColumnsToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.SelectColumnsToolStripMenuItem.Text = "&Select columns..."
        '
        'ContactToolStripMenuItem
        '
        Me.ContactToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewEmailContactToolStripMenuItem, Me.ToolStripSeparator1, Me.EditselectedContactToolStripMenuItem, Me.ToolStripSeparator5, Me.ComposeMessageToSelectedContactsToolStripMenuItem, Me.BlockSelectedContactsToolStripMenuItem, Me.UnblockSelectedContactsToolStripMenuItem, Me.RemoveContactToolStripMenuItem, Me.ToolStripSeparator7, Me.ChangeSendingAccountForSelectedContactsToolStripMenuItem})
        Me.ContactToolStripMenuItem.Name = "ContactToolStripMenuItem"
        Me.ContactToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ContactToolStripMenuItem.Text = "&Contact"
        '
        'NewEmailContactToolStripMenuItem
        '
        Me.NewEmailContactToolStripMenuItem.Image = CType(resources.GetObject("NewEmailContactToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewEmailContactToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.NewEmailContactToolStripMenuItem.Name = "NewEmailContactToolStripMenuItem"
        Me.NewEmailContactToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.NewEmailContactToolStripMenuItem.Size = New System.Drawing.Size(342, 22)
        Me.NewEmailContactToolStripMenuItem.Text = "Add new &email contact"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(339, 6)
        '
        'EditselectedContactToolStripMenuItem
        '
        Me.EditselectedContactToolStripMenuItem.Name = "EditselectedContactToolStripMenuItem"
        Me.EditselectedContactToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.EditselectedContactToolStripMenuItem.Size = New System.Drawing.Size(342, 22)
        Me.EditselectedContactToolStripMenuItem.Text = "Edit &selected contact"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(339, 6)
        '
        'ComposeMessageToSelectedContactsToolStripMenuItem
        '
        Me.ComposeMessageToSelectedContactsToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Editpencil_16
        Me.ComposeMessageToSelectedContactsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ComposeMessageToSelectedContactsToolStripMenuItem.Name = "ComposeMessageToSelectedContactsToolStripMenuItem"
        Me.ComposeMessageToSelectedContactsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.ComposeMessageToSelectedContactsToolStripMenuItem.Size = New System.Drawing.Size(342, 22)
        Me.ComposeMessageToSelectedContactsToolStripMenuItem.Text = "&Compose message to selected contact(s)..."
        '
        'BlockSelectedContactsToolStripMenuItem
        '
        Me.BlockSelectedContactsToolStripMenuItem.Name = "BlockSelectedContactsToolStripMenuItem"
        Me.BlockSelectedContactsToolStripMenuItem.Size = New System.Drawing.Size(342, 22)
        Me.BlockSelectedContactsToolStripMenuItem.Text = "&Block selected contact(s)"
        Me.BlockSelectedContactsToolStripMenuItem.Visible = False
        '
        'UnblockSelectedContactsToolStripMenuItem
        '
        Me.UnblockSelectedContactsToolStripMenuItem.Enabled = False
        Me.UnblockSelectedContactsToolStripMenuItem.Name = "UnblockSelectedContactsToolStripMenuItem"
        Me.UnblockSelectedContactsToolStripMenuItem.Size = New System.Drawing.Size(342, 22)
        Me.UnblockSelectedContactsToolStripMenuItem.Text = "&Unblock selected contact(s)"
        Me.UnblockSelectedContactsToolStripMenuItem.Visible = False
        '
        'RemoveContactToolStripMenuItem
        '
        Me.RemoveContactToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.RemoveContactToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.RemoveContactToolStripMenuItem.Name = "RemoveContactToolStripMenuItem"
        Me.RemoveContactToolStripMenuItem.ShortcutKeyDisplayString = "Del"
        Me.RemoveContactToolStripMenuItem.Size = New System.Drawing.Size(342, 22)
        Me.RemoveContactToolStripMenuItem.Text = "Re&move contact"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(339, 6)
        '
        'ChangeSendingAccountForSelectedContactsToolStripMenuItem
        '
        Me.ChangeSendingAccountForSelectedContactsToolStripMenuItem.Name = "ChangeSendingAccountForSelectedContactsToolStripMenuItem"
        Me.ChangeSendingAccountForSelectedContactsToolStripMenuItem.Size = New System.Drawing.Size(342, 22)
        Me.ChangeSendingAccountForSelectedContactsToolStripMenuItem.Text = "Change sending account for selected contacts"
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
        Me.AboutTrulyMailToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.AboutTrulyMailToolStripMenuItem.Text = "&About TrulyMail"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewEmailToolStripButton, Me.InviteTrulyMailContactToolStripButton, Me.ToolStripSeparator3, Me.ComposeMessageToSelectedContactsToolStripButton, Me.DeleteToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(223, 38)
        Me.ToolStrip1.TabIndex = 2
        '
        'NewEmailToolStripButton
        '
        Me.NewEmailToolStripButton.Image = CType(resources.GetObject("NewEmailToolStripButton.Image"), System.Drawing.Image)
        Me.NewEmailToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.NewEmailToolStripButton.Name = "NewEmailToolStripButton"
        Me.NewEmailToolStripButton.Size = New System.Drawing.Size(108, 35)
        Me.NewEmailToolStripButton.Text = "Add email contact"
        Me.NewEmailToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.NewEmailToolStripButton.ToolTipText = "Add email contact (Ctrl+E)"
        '
        'InviteTrulyMailContactToolStripButton
        '
        Me.InviteTrulyMailContactToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.AddUser_16
        Me.InviteTrulyMailContactToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.InviteTrulyMailContactToolStripButton.Name = "InviteTrulyMailContactToolStripButton"
        Me.InviteTrulyMailContactToolStripButton.Size = New System.Drawing.Size(129, 35)
        Me.InviteTrulyMailContactToolStripButton.Text = "Add TrulyMail contact"
        Me.InviteTrulyMailContactToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.InviteTrulyMailContactToolStripButton.ToolTipText = "Add TrulyMail contact (Ctrl+I)"
        Me.InviteTrulyMailContactToolStripButton.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 38)
        '
        'ComposeMessageToSelectedContactsToolStripButton
        '
        Me.ComposeMessageToSelectedContactsToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.Editpencil_16
        Me.ComposeMessageToSelectedContactsToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.ComposeMessageToSelectedContactsToolStripButton.Name = "ComposeMessageToSelectedContactsToolStripButton"
        Me.ComposeMessageToSelectedContactsToolStripButton.Size = New System.Drawing.Size(62, 35)
        Me.ComposeMessageToSelectedContactsToolStripButton.Text = "Compose"
        Me.ComposeMessageToSelectedContactsToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ComposeMessageToSelectedContactsToolStripButton.ToolTipText = "Compose new message to selected contact(s) (Ctrl+N)"
        '
        'DeleteToolStripButton
        '
        Me.DeleteToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.DeleteToolStripButton.Name = "DeleteToolStripButton"
        Me.DeleteToolStripButton.Size = New System.Drawing.Size(44, 35)
        Me.DeleteToolStripButton.Text = "Delete"
        Me.DeleteToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.DeleteToolStripButton.ToolTipText = "Remove contact"
        '
        'ctxmnuColumnSelector
        '
        Me.ctxmnuColumnSelector.Name = "ctxmnuColumnSelector"
        Me.ctxmnuColumnSelector.Size = New System.Drawing.Size(61, 4)
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(1194, 530)
        Me.KryptonPanel.TabIndex = 12
        '
        'ImglstMessageStatus
        '
        Me.ImglstMessageStatus.ImageStream = CType(resources.GetObject("ImglstMessageStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImglstMessageStatus.TransparentColor = System.Drawing.Color.Transparent
        Me.ImglstMessageStatus.Images.SetKeyName(0, "Securedmessage_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(1, "email_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(2, "Reply_2_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(3, "ForwardReply_2_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(4, "Forward_2_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(5, "MixedTransport_16.bmp")
        Me.ImglstMessageStatus.Images.SetKeyName(6, "noteTrans_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(7, "Transparent_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(8, "rss_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(9, "network_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(10, "attach.png")
        Me.ImglstMessageStatus.Images.SetKeyName(11, "spam scales.png")
        Me.ImglstMessageStatus.Images.SetKeyName(12, "redemail_16.png")
        '
        'ContactPictureDisplay1
        '
        Me.ContactPictureDisplay1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContactPictureDisplay1.Image = Nothing
        Me.ContactPictureDisplay1.Location = New System.Drawing.Point(973, 228)
        Me.ContactPictureDisplay1.Name = "ContactPictureDisplay1"
        Me.ContactPictureDisplay1.Size = New System.Drawing.Size(200, 200)
        Me.ContactPictureDisplay1.TabIndex = 11
        Me.ContactPictureDisplay1.Visible = False
        '
        'AddressBookForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1194, 530)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "AddressBookForm"
        Me.Text = "Address Book"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.olvAddressBook, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClearTags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddTag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContactToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewEmailContactToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ComposeMessageToSelectedContactsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlockSelectedContactsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnblockSelectedContactsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutTrulyMailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewEmailToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents InviteTrulyMailContactToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents NameColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents AddressColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents RemoteImagesColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ReceiveOnlyColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents DateAddedColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ComposeMessageToSelectedContactsToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DeleteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents RemoveContactToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IconColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RequestReturnReceiptColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents SendReturnReceiptColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents TagsColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ContactCountStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents olvAddressBook As BrightIdeasSoftware.ObjectListView
    Friend WithEvents btnClearMessageFilter As System.Windows.Forms.Button
    Friend WithEvents EditselectedContactToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LastMessageReceivedColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents LastMessageSentColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents RemindReceiveColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents RemindSendColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ContactPictureDisplay1 As TrulyMail.ContactPictureDisplay
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewContactImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HotItemStyle1 As BrightIdeasSoftware.HotItemStyle
    Friend WithEvents ImportanceColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents HeaderFormatStyleWingDings As BrightIdeasSoftware.HeaderFormatStyle
    Friend WithEvents ctxmnuColumnSelector As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelectColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents SMTPColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents cboMessageTags As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbClearTags As System.Windows.Forms.PictureBox
    Friend WithEvents pbAddTag As System.Windows.Forms.PictureBox
    Friend WithEvents ChangeSendingAccountForSelectedContactsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents ImglstMessageStatus As System.Windows.Forms.ImageList
End Class
