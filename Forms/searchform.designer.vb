<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchForm))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboSearchType = New System.Windows.Forms.ComboBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabCriteria = New System.Windows.Forms.TabPage()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.grpMessages = New System.Windows.Forms.GroupBox()
        Me.llblChangeMessageFolder = New System.Windows.Forms.LinkLabel()
        Me.txtMessageTags = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMessageBCC = New System.Windows.Forms.TextBox()
        Me.txtMessageCC = New System.Windows.Forms.TextBox()
        Me.txtMessageTo = New System.Windows.Forms.TextBox()
        Me.txtMessageFrom = New System.Windows.Forms.TextBox()
        Me.txtMessageSize = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboMessageSize = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboMessageBCC = New System.Windows.Forms.ComboBox()
        Me.dtpMessageSentBefore = New System.Windows.Forms.DateTimePicker()
        Me.dtpMessageSentAfter = New System.Windows.Forms.DateTimePicker()
        Me.cboMessageCC = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboMessageTo = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboMessageFrom = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkMessageSubfolders = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lvMessageTypes = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.txtMessageBody = New System.Windows.Forms.TextBox()
        Me.cboMessageBody = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMessageSubject = New System.Windows.Forms.TextBox()
        Me.cboMessageSubject = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboMessageAttachments = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboMessageRead = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpAttachments = New System.Windows.Forms.GroupBox()
        Me.llblChangeAttachmentFolder = New System.Windows.Forms.LinkLabel()
        Me.txtAttachmentMessageTag = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtAttachmentBCC = New System.Windows.Forms.TextBox()
        Me.txtAttachmentCC = New System.Windows.Forms.TextBox()
        Me.txtAttachmentTo = New System.Windows.Forms.TextBox()
        Me.txtAttachmentFrom = New System.Windows.Forms.TextBox()
        Me.txtAttachmentName = New System.Windows.Forms.TextBox()
        Me.cboAttachmentName = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtAttachmentAttachmentSize = New System.Windows.Forms.TextBox()
        Me.txtAttachmentMessageSize = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboAttachmentAttachmentSize = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboAttachmentMessageSize = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboAttachmentBCC = New System.Windows.Forms.ComboBox()
        Me.dtpAttachmentBefore = New System.Windows.Forms.DateTimePicker()
        Me.dtpAttachmentAfter = New System.Windows.Forms.DateTimePicker()
        Me.cboAttachmentCC = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboAttachmentTo = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboAttachmentFrom = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.chkAttachmentSubfolders = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lvAttachmentMessageType = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.txtAttachmentBody = New System.Windows.Forms.TextBox()
        Me.cboAttachmentBody = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtAttachmentSubject = New System.Windows.Forms.TextBox()
        Me.cboAttachmentSubject = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboAttachmentRead = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.tabResults = New System.Windows.Forms.TabPage()
        Me.pnlResults = New System.Windows.Forms.Panel()
        Me.olvMessages = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumnSubject = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnAttachments = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnSender = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnRecipients = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnMessageDateSent = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnSize = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnReceived = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnViewed = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvMessageFolder = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnTransportType = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnHasNotes = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvMessageTags = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ctxmnuMessages = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImglstMessageStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlMessageFilter = New System.Windows.Forms.Panel()
        Me.cboMessageTags = New System.Windows.Forms.ComboBox()
        Me.txtMessageFilter = New System.Windows.Forms.TextBox()
        Me.btnClearMessageFilter = New System.Windows.Forms.Button()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.pbClearTags = New System.Windows.Forms.PictureBox()
        Me.llblFilter = New System.Windows.Forms.LinkLabel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.pbAddTag = New System.Windows.Forms.PictureBox()
        Me.olvAttachments = New BrightIdeasSoftware.ObjectListView()
        Me.olvColumnAttachmentName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnAttachmentSize = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn5 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn6 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnAttachmentDate = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnMessageSize = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.olvColumnAttachmentMessageTag = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ctxmnuAttachments = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenAttachmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.prgSearchProgress = New MontgomerySoftware.Controls.ProgressBar()
        Me.lblSearchProgress = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tmrFilterMessages = New System.Timers.Timer()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.tabCriteria.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.grpMessages.SuspendLayout()
        CType(Me.lvMessageTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAttachments.SuspendLayout()
        CType(Me.lvAttachmentMessageType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabResults.SuspendLayout()
        Me.pnlResults.SuspendLayout()
        CType(Me.olvMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmnuMessages.SuspendLayout()
        Me.pnlMessageFilter.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.pbClearTags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddTag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.olvAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmnuAttachments.SuspendLayout()
        CType(Me.tmrFilterMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Search for:"
        '
        'cboSearchType
        '
        Me.cboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchType.FormattingEnabled = True
        Me.cboSearchType.Items.AddRange(New Object() {"Messages", "Attachments"})
        Me.cboSearchType.Location = New System.Drawing.Point(110, 4)
        Me.cboSearchType.Name = "cboSearchType"
        Me.cboSearchType.Size = New System.Drawing.Size(153, 21)
        Me.cboSearchType.TabIndex = 1
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
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(272, 2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(106, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabCriteria)
        Me.TabControl1.Controls.Add(Me.tabResults)
        Me.TabControl1.Location = New System.Drawing.Point(-5, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(925, 545)
        Me.TabControl1.TabIndex = 14
        '
        'tabCriteria
        '
        Me.tabCriteria.Controls.Add(Me.KryptonPanel1)
        Me.tabCriteria.Location = New System.Drawing.Point(4, 22)
        Me.tabCriteria.Name = "tabCriteria"
        Me.tabCriteria.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCriteria.Size = New System.Drawing.Size(917, 519)
        Me.tabCriteria.TabIndex = 0
        Me.tabCriteria.Text = "Criteria"
        Me.tabCriteria.UseVisualStyleBackColor = True
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.grpMessages)
        Me.KryptonPanel1.Controls.Add(Me.grpAttachments)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(3, 3)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Palette = Me.KryptonPalette1
        Me.KryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel1.Size = New System.Drawing.Size(911, 513)
        Me.KryptonPanel1.TabIndex = 54
        '
        'grpMessages
        '
        Me.grpMessages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMessages.Controls.Add(Me.llblChangeMessageFolder)
        Me.grpMessages.Controls.Add(Me.txtMessageTags)
        Me.grpMessages.Controls.Add(Me.Label1)
        Me.grpMessages.Controls.Add(Me.txtMessageBCC)
        Me.grpMessages.Controls.Add(Me.txtMessageCC)
        Me.grpMessages.Controls.Add(Me.txtMessageTo)
        Me.grpMessages.Controls.Add(Me.txtMessageFrom)
        Me.grpMessages.Controls.Add(Me.txtMessageSize)
        Me.grpMessages.Controls.Add(Me.Label3)
        Me.grpMessages.Controls.Add(Me.cboMessageSize)
        Me.grpMessages.Controls.Add(Me.Label16)
        Me.grpMessages.Controls.Add(Me.cboMessageBCC)
        Me.grpMessages.Controls.Add(Me.dtpMessageSentBefore)
        Me.grpMessages.Controls.Add(Me.dtpMessageSentAfter)
        Me.grpMessages.Controls.Add(Me.cboMessageCC)
        Me.grpMessages.Controls.Add(Me.Label14)
        Me.grpMessages.Controls.Add(Me.cboMessageTo)
        Me.grpMessages.Controls.Add(Me.Label13)
        Me.grpMessages.Controls.Add(Me.cboMessageFrom)
        Me.grpMessages.Controls.Add(Me.Label12)
        Me.grpMessages.Controls.Add(Me.chkMessageSubfolders)
        Me.grpMessages.Controls.Add(Me.Label11)
        Me.grpMessages.Controls.Add(Me.lvMessageTypes)
        Me.grpMessages.Controls.Add(Me.txtMessageBody)
        Me.grpMessages.Controls.Add(Me.cboMessageBody)
        Me.grpMessages.Controls.Add(Me.Label10)
        Me.grpMessages.Controls.Add(Me.Label9)
        Me.grpMessages.Controls.Add(Me.txtMessageSubject)
        Me.grpMessages.Controls.Add(Me.cboMessageSubject)
        Me.grpMessages.Controls.Add(Me.Label8)
        Me.grpMessages.Controls.Add(Me.cboMessageAttachments)
        Me.grpMessages.Controls.Add(Me.Label7)
        Me.grpMessages.Controls.Add(Me.Label6)
        Me.grpMessages.Controls.Add(Me.Label4)
        Me.grpMessages.Controls.Add(Me.cboMessageRead)
        Me.grpMessages.Controls.Add(Me.Label2)
        Me.grpMessages.Location = New System.Drawing.Point(3, 3)
        Me.grpMessages.Name = "grpMessages"
        Me.grpMessages.Size = New System.Drawing.Size(798, 435)
        Me.grpMessages.TabIndex = 13
        Me.grpMessages.TabStop = False
        Me.grpMessages.Text = "Search for Messages"
        Me.grpMessages.Visible = False
        '
        'llblChangeMessageFolder
        '
        Me.llblChangeMessageFolder.AutoSize = True
        Me.llblChangeMessageFolder.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblChangeMessageFolder.LinkArea = New System.Windows.Forms.LinkArea(6, 12)
        Me.llblChangeMessageFolder.Location = New System.Drawing.Point(332, 189)
        Me.llblChangeMessageFolder.Name = "llblChangeMessageFolder"
        Me.llblChangeMessageFolder.Size = New System.Drawing.Size(87, 20)
        Me.llblChangeMessageFolder.TabIndex = 47
        Me.llblChangeMessageFolder.TabStop = True
        Me.llblChangeMessageFolder.Text = "InBox change"
        Me.llblChangeMessageFolder.UseCompatibleTextRendering = True
        '
        'txtMessageTags
        '
        Me.txtMessageTags.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessageTags.Location = New System.Drawing.Point(98, 20)
        Me.txtMessageTags.Name = "txtMessageTags"
        Me.txtMessageTags.Size = New System.Drawing.Size(153, 22)
        Me.txtMessageTags.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 16)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Tags:"
        '
        'txtMessageBCC
        '
        Me.txtMessageBCC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessageBCC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessageBCC.Location = New System.Drawing.Point(543, 99)
        Me.txtMessageBCC.Name = "txtMessageBCC"
        Me.txtMessageBCC.Size = New System.Drawing.Size(249, 22)
        Me.txtMessageBCC.TabIndex = 44
        Me.ToolTip1.SetToolTip(Me.txtMessageBCC, "Enter part of BCC recipient's name or email address")
        '
        'txtMessageCC
        '
        Me.txtMessageCC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessageCC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessageCC.Location = New System.Drawing.Point(543, 72)
        Me.txtMessageCC.Name = "txtMessageCC"
        Me.txtMessageCC.Size = New System.Drawing.Size(249, 22)
        Me.txtMessageCC.TabIndex = 43
        Me.ToolTip1.SetToolTip(Me.txtMessageCC, "Enter part of CC recipient's name or email address")
        '
        'txtMessageTo
        '
        Me.txtMessageTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessageTo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessageTo.Location = New System.Drawing.Point(543, 45)
        Me.txtMessageTo.Name = "txtMessageTo"
        Me.txtMessageTo.Size = New System.Drawing.Size(249, 22)
        Me.txtMessageTo.TabIndex = 42
        Me.ToolTip1.SetToolTip(Me.txtMessageTo, "Enter part of main recipient's name or email address")
        '
        'txtMessageFrom
        '
        Me.txtMessageFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessageFrom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessageFrom.Location = New System.Drawing.Point(543, 20)
        Me.txtMessageFrom.Name = "txtMessageFrom"
        Me.txtMessageFrom.Size = New System.Drawing.Size(249, 22)
        Me.txtMessageFrom.TabIndex = 41
        Me.ToolTip1.SetToolTip(Me.txtMessageFrom, "Enter part of sender's name or email address")
        '
        'txtMessageSize
        '
        Me.txtMessageSize.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessageSize.Location = New System.Drawing.Point(153, 104)
        Me.txtMessageSize.Name = "txtMessageSize"
        Me.txtMessageSize.Size = New System.Drawing.Size(98, 22)
        Me.txtMessageSize.TabIndex = 28
        Me.txtMessageSize.Text = "0"
        Me.txtMessageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 16)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Total Size:"
        '
        'cboMessageSize
        '
        Me.cboMessageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMessageSize.FormattingEnabled = True
        Me.cboMessageSize.Items.AddRange(New Object() {">", "=", "<"})
        Me.cboMessageSize.Location = New System.Drawing.Point(98, 105)
        Me.cboMessageSize.Name = "cboMessageSize"
        Me.cboMessageSize.Size = New System.Drawing.Size(49, 21)
        Me.cboMessageSize.TabIndex = 27
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(271, 102)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 16)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "BCC:"
        '
        'cboMessageBCC
        '
        Me.cboMessageBCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMessageBCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMessageBCC.FormattingEnabled = True
        Me.cboMessageBCC.Items.AddRange(New Object() {"All", "Me (TrulyMail)"})
        Me.cboMessageBCC.Location = New System.Drawing.Point(332, 101)
        Me.cboMessageBCC.Name = "cboMessageBCC"
        Me.cboMessageBCC.Size = New System.Drawing.Size(204, 21)
        Me.cboMessageBCC.TabIndex = 39
        '
        'dtpMessageSentBefore
        '
        Me.dtpMessageSentBefore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpMessageSentBefore.Location = New System.Drawing.Point(363, 366)
        Me.dtpMessageSentBefore.MaxDate = New Date(2199, 12, 31, 0, 0, 0, 0)
        Me.dtpMessageSentBefore.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.dtpMessageSentBefore.Name = "dtpMessageSentBefore"
        Me.dtpMessageSentBefore.Size = New System.Drawing.Size(429, 20)
        Me.dtpMessageSentBefore.TabIndex = 32
        Me.dtpMessageSentBefore.Value = New Date(2199, 12, 31, 0, 0, 0, 0)
        '
        'dtpMessageSentAfter
        '
        Me.dtpMessageSentAfter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpMessageSentAfter.Location = New System.Drawing.Point(363, 340)
        Me.dtpMessageSentAfter.MaxDate = New Date(2199, 12, 31, 0, 0, 0, 0)
        Me.dtpMessageSentAfter.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.dtpMessageSentAfter.Name = "dtpMessageSentAfter"
        Me.dtpMessageSentAfter.Size = New System.Drawing.Size(429, 20)
        Me.dtpMessageSentAfter.TabIndex = 30
        '
        'cboMessageCC
        '
        Me.cboMessageCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMessageCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMessageCC.FormattingEnabled = True
        Me.cboMessageCC.Items.AddRange(New Object() {"All", "Me (TrulyMail)"})
        Me.cboMessageCC.Location = New System.Drawing.Point(332, 74)
        Me.cboMessageCC.Name = "cboMessageCC"
        Me.cboMessageCC.Size = New System.Drawing.Size(204, 21)
        Me.cboMessageCC.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(271, 79)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 16)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "CC:"
        '
        'cboMessageTo
        '
        Me.cboMessageTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMessageTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMessageTo.FormattingEnabled = True
        Me.cboMessageTo.Items.AddRange(New Object() {"All", "Me (TrulyMail)"})
        Me.cboMessageTo.Location = New System.Drawing.Point(332, 47)
        Me.cboMessageTo.Name = "cboMessageTo"
        Me.cboMessageTo.Size = New System.Drawing.Size(204, 21)
        Me.cboMessageTo.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(271, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(25, 16)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "To:"
        '
        'cboMessageFrom
        '
        Me.cboMessageFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMessageFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMessageFrom.FormattingEnabled = True
        Me.cboMessageFrom.Items.AddRange(New Object() {"All", "Me (TrulyMail)"})
        Me.cboMessageFrom.Location = New System.Drawing.Point(332, 20)
        Me.cboMessageFrom.Name = "cboMessageFrom"
        Me.cboMessageFrom.Size = New System.Drawing.Size(204, 21)
        Me.cboMessageFrom.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(271, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 16)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "From:"
        '
        'chkMessageSubfolders
        '
        Me.chkMessageSubfolders.AutoSize = True
        Me.chkMessageSubfolders.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkMessageSubfolders.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.chkMessageSubfolders.Location = New System.Drawing.Point(268, 213)
        Me.chkMessageSubfolders.Name = "chkMessageSubfolders"
        Me.chkMessageSubfolders.Size = New System.Drawing.Size(135, 20)
        Me.chkMessageSubfolders.TabIndex = 25
        Me.chkMessageSubfolders.Text = "Search subfolders:"
        Me.chkMessageSubfolders.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(271, 189)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 16)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Folder:"
        '
        'lvMessageTypes
        '
        Me.lvMessageTypes.AllColumns.Add(Me.OlvColumn1)
        Me.lvMessageTypes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvMessageTypes.CellEditUseWholeCell = False
        Me.lvMessageTypes.CheckBoxes = True
        Me.lvMessageTypes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1})
        Me.lvMessageTypes.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvMessageTypes.HideSelection = False
        Me.lvMessageTypes.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.lvMessageTypes.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.lvMessageTypes.Location = New System.Drawing.Point(98, 203)
        Me.lvMessageTypes.Name = "lvMessageTypes"
        Me.lvMessageTypes.ShowGroups = False
        Me.lvMessageTypes.Size = New System.Drawing.Size(153, 225)
        Me.lvMessageTypes.TabIndex = 16
        Me.lvMessageTypes.UseCompatibleStateImageBehavior = False
        Me.lvMessageTypes.View = System.Windows.Forms.View.Details
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "DisplayName"
        Me.OlvColumn1.Text = "Type"
        Me.OlvColumn1.Width = 132
        '
        'txtMessageBody
        '
        Me.txtMessageBody.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessageBody.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessageBody.Location = New System.Drawing.Point(277, 156)
        Me.txtMessageBody.Name = "txtMessageBody"
        Me.txtMessageBody.Size = New System.Drawing.Size(515, 22)
        Me.txtMessageBody.TabIndex = 14
        '
        'cboMessageBody
        '
        Me.cboMessageBody.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMessageBody.FormattingEnabled = True
        Me.cboMessageBody.Items.AddRange(New Object() {"All", "Contains"})
        Me.cboMessageBody.Location = New System.Drawing.Point(98, 157)
        Me.cboMessageBody.Name = "cboMessageBody"
        Me.cboMessageBody.Size = New System.Drawing.Size(153, 21)
        Me.cboMessageBody.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 207)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 16)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Type(s):"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 158)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Body:"
        '
        'txtMessageSubject
        '
        Me.txtMessageSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessageSubject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessageSubject.Location = New System.Drawing.Point(277, 129)
        Me.txtMessageSubject.Name = "txtMessageSubject"
        Me.txtMessageSubject.Size = New System.Drawing.Size(515, 22)
        Me.txtMessageSubject.TabIndex = 11
        '
        'cboMessageSubject
        '
        Me.cboMessageSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMessageSubject.FormattingEnabled = True
        Me.cboMessageSubject.Items.AddRange(New Object() {"All", "Is exactly", "Contains"})
        Me.cboMessageSubject.Location = New System.Drawing.Point(98, 130)
        Me.cboMessageSubject.Name = "cboMessageSubject"
        Me.cboMessageSubject.Size = New System.Drawing.Size(153, 21)
        Me.cboMessageSubject.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Subject:"
        '
        'cboMessageAttachments
        '
        Me.cboMessageAttachments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMessageAttachments.FormattingEnabled = True
        Me.cboMessageAttachments.Items.AddRange(New Object() {"All", "With attachments", "Without attachments"})
        Me.cboMessageAttachments.Location = New System.Drawing.Point(98, 77)
        Me.cboMessageAttachments.Name = "cboMessageAttachments"
        Me.cboMessageAttachments.Size = New System.Drawing.Size(153, 21)
        Me.cboMessageAttachments.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Attachments:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(271, 368)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 16)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Sent before:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(271, 342)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Sent after:"
        '
        'cboMessageRead
        '
        Me.cboMessageRead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMessageRead.FormattingEnabled = True
        Me.cboMessageRead.Items.AddRange(New Object() {"All", "Read", "Not read"})
        Me.cboMessageRead.Location = New System.Drawing.Point(98, 51)
        Me.cboMessageRead.Name = "cboMessageRead"
        Me.cboMessageRead.Size = New System.Drawing.Size(153, 21)
        Me.cboMessageRead.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Read:"
        '
        'grpAttachments
        '
        Me.grpAttachments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAttachments.Controls.Add(Me.llblChangeAttachmentFolder)
        Me.grpAttachments.Controls.Add(Me.txtAttachmentMessageTag)
        Me.grpAttachments.Controls.Add(Me.Label29)
        Me.grpAttachments.Controls.Add(Me.txtAttachmentBCC)
        Me.grpAttachments.Controls.Add(Me.txtAttachmentCC)
        Me.grpAttachments.Controls.Add(Me.txtAttachmentTo)
        Me.grpAttachments.Controls.Add(Me.txtAttachmentFrom)
        Me.grpAttachments.Controls.Add(Me.txtAttachmentName)
        Me.grpAttachments.Controls.Add(Me.cboAttachmentName)
        Me.grpAttachments.Controls.Add(Me.Label30)
        Me.grpAttachments.Controls.Add(Me.txtAttachmentAttachmentSize)
        Me.grpAttachments.Controls.Add(Me.txtAttachmentMessageSize)
        Me.grpAttachments.Controls.Add(Me.Label25)
        Me.grpAttachments.Controls.Add(Me.cboAttachmentAttachmentSize)
        Me.grpAttachments.Controls.Add(Me.Label15)
        Me.grpAttachments.Controls.Add(Me.cboAttachmentMessageSize)
        Me.grpAttachments.Controls.Add(Me.Label17)
        Me.grpAttachments.Controls.Add(Me.cboAttachmentBCC)
        Me.grpAttachments.Controls.Add(Me.dtpAttachmentBefore)
        Me.grpAttachments.Controls.Add(Me.dtpAttachmentAfter)
        Me.grpAttachments.Controls.Add(Me.cboAttachmentCC)
        Me.grpAttachments.Controls.Add(Me.Label18)
        Me.grpAttachments.Controls.Add(Me.cboAttachmentTo)
        Me.grpAttachments.Controls.Add(Me.Label19)
        Me.grpAttachments.Controls.Add(Me.cboAttachmentFrom)
        Me.grpAttachments.Controls.Add(Me.Label20)
        Me.grpAttachments.Controls.Add(Me.chkAttachmentSubfolders)
        Me.grpAttachments.Controls.Add(Me.Label21)
        Me.grpAttachments.Controls.Add(Me.lvAttachmentMessageType)
        Me.grpAttachments.Controls.Add(Me.txtAttachmentBody)
        Me.grpAttachments.Controls.Add(Me.cboAttachmentBody)
        Me.grpAttachments.Controls.Add(Me.Label22)
        Me.grpAttachments.Controls.Add(Me.Label23)
        Me.grpAttachments.Controls.Add(Me.txtAttachmentSubject)
        Me.grpAttachments.Controls.Add(Me.cboAttachmentSubject)
        Me.grpAttachments.Controls.Add(Me.Label24)
        Me.grpAttachments.Controls.Add(Me.Label26)
        Me.grpAttachments.Controls.Add(Me.Label27)
        Me.grpAttachments.Controls.Add(Me.cboAttachmentRead)
        Me.grpAttachments.Controls.Add(Me.Label28)
        Me.grpAttachments.Location = New System.Drawing.Point(3, 3)
        Me.grpAttachments.Name = "grpAttachments"
        Me.grpAttachments.Size = New System.Drawing.Size(798, 435)
        Me.grpAttachments.TabIndex = 15
        Me.grpAttachments.TabStop = False
        Me.grpAttachments.Text = "Search for Attachments"
        Me.grpAttachments.Visible = False
        '
        'llblChangeAttachmentFolder
        '
        Me.llblChangeAttachmentFolder.AutoSize = True
        Me.llblChangeAttachmentFolder.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblChangeAttachmentFolder.LinkArea = New System.Windows.Forms.LinkArea(6, 12)
        Me.llblChangeAttachmentFolder.Location = New System.Drawing.Point(332, 218)
        Me.llblChangeAttachmentFolder.Name = "llblChangeAttachmentFolder"
        Me.llblChangeAttachmentFolder.Size = New System.Drawing.Size(87, 20)
        Me.llblChangeAttachmentFolder.TabIndex = 51
        Me.llblChangeAttachmentFolder.TabStop = True
        Me.llblChangeAttachmentFolder.Text = "InBox change"
        Me.llblChangeAttachmentFolder.UseCompatibleTextRendering = True
        '
        'txtAttachmentMessageTag
        '
        Me.txtAttachmentMessageTag.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAttachmentMessageTag.Location = New System.Drawing.Point(123, 20)
        Me.txtAttachmentMessageTag.Name = "txtAttachmentMessageTag"
        Me.txtAttachmentMessageTag.Size = New System.Drawing.Size(136, 22)
        Me.txtAttachmentMessageTag.TabIndex = 50
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(6, 23)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(96, 16)
        Me.Label29.TabIndex = 49
        Me.Label29.Text = "Message Tags:"
        '
        'txtAttachmentBCC
        '
        Me.txtAttachmentBCC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAttachmentBCC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAttachmentBCC.Location = New System.Drawing.Point(544, 99)
        Me.txtAttachmentBCC.Name = "txtAttachmentBCC"
        Me.txtAttachmentBCC.Size = New System.Drawing.Size(249, 22)
        Me.txtAttachmentBCC.TabIndex = 48
        Me.ToolTip1.SetToolTip(Me.txtAttachmentBCC, "Enter part of BCC recipient's name or email address")
        '
        'txtAttachmentCC
        '
        Me.txtAttachmentCC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAttachmentCC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAttachmentCC.Location = New System.Drawing.Point(543, 72)
        Me.txtAttachmentCC.Name = "txtAttachmentCC"
        Me.txtAttachmentCC.Size = New System.Drawing.Size(249, 22)
        Me.txtAttachmentCC.TabIndex = 47
        Me.ToolTip1.SetToolTip(Me.txtAttachmentCC, "Enter part of CC recipient's name or email address")
        '
        'txtAttachmentTo
        '
        Me.txtAttachmentTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAttachmentTo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAttachmentTo.Location = New System.Drawing.Point(544, 45)
        Me.txtAttachmentTo.Name = "txtAttachmentTo"
        Me.txtAttachmentTo.Size = New System.Drawing.Size(249, 22)
        Me.txtAttachmentTo.TabIndex = 46
        Me.ToolTip1.SetToolTip(Me.txtAttachmentTo, "Enter part of main recipient's name or email address")
        '
        'txtAttachmentFrom
        '
        Me.txtAttachmentFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAttachmentFrom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAttachmentFrom.Location = New System.Drawing.Point(543, 18)
        Me.txtAttachmentFrom.Name = "txtAttachmentFrom"
        Me.txtAttachmentFrom.Size = New System.Drawing.Size(249, 22)
        Me.txtAttachmentFrom.TabIndex = 45
        Me.ToolTip1.SetToolTip(Me.txtAttachmentFrom, "Enter part of sender's name or email address")
        '
        'txtAttachmentName
        '
        Me.txtAttachmentName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAttachmentName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAttachmentName.Location = New System.Drawing.Point(277, 183)
        Me.txtAttachmentName.Name = "txtAttachmentName"
        Me.txtAttachmentName.Size = New System.Drawing.Size(515, 22)
        Me.txtAttachmentName.TabIndex = 43
        '
        'cboAttachmentName
        '
        Me.cboAttachmentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttachmentName.FormattingEnabled = True
        Me.cboAttachmentName.Items.AddRange(New Object() {"All", "Is exactly", "Contains", "Starts with", "Ends with"})
        Me.cboAttachmentName.Location = New System.Drawing.Point(123, 184)
        Me.cboAttachmentName.Name = "cboAttachmentName"
        Me.cboAttachmentName.Size = New System.Drawing.Size(136, 21)
        Me.cboAttachmentName.TabIndex = 42
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(6, 185)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(115, 16)
        Me.Label30.TabIndex = 41
        Me.Label30.Text = "Attachment name:"
        '
        'txtAttachmentAttachmentSize
        '
        Me.txtAttachmentAttachmentSize.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAttachmentAttachmentSize.Location = New System.Drawing.Point(168, 78)
        Me.txtAttachmentAttachmentSize.Name = "txtAttachmentAttachmentSize"
        Me.txtAttachmentAttachmentSize.Size = New System.Drawing.Size(91, 22)
        Me.txtAttachmentAttachmentSize.TabIndex = 28
        Me.txtAttachmentAttachmentSize.Text = "0"
        Me.txtAttachmentAttachmentSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAttachmentMessageSize
        '
        Me.txtAttachmentMessageSize.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAttachmentMessageSize.Location = New System.Drawing.Point(168, 104)
        Me.txtAttachmentMessageSize.Name = "txtAttachmentMessageSize"
        Me.txtAttachmentMessageSize.Size = New System.Drawing.Size(91, 22)
        Me.txtAttachmentMessageSize.TabIndex = 28
        Me.txtAttachmentMessageSize.Text = "0"
        Me.txtAttachmentMessageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(6, 80)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(107, 16)
        Me.Label25.TabIndex = 26
        Me.Label25.Text = "Attachment size:"
        '
        'cboAttachmentAttachmentSize
        '
        Me.cboAttachmentAttachmentSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttachmentAttachmentSize.FormattingEnabled = True
        Me.cboAttachmentAttachmentSize.Items.AddRange(New Object() {">", "=", "<"})
        Me.cboAttachmentAttachmentSize.Location = New System.Drawing.Point(123, 79)
        Me.cboAttachmentAttachmentSize.Name = "cboAttachmentAttachmentSize"
        Me.cboAttachmentAttachmentSize.Size = New System.Drawing.Size(39, 21)
        Me.cboAttachmentAttachmentSize.TabIndex = 27
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 106)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 16)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Message size:"
        '
        'cboAttachmentMessageSize
        '
        Me.cboAttachmentMessageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttachmentMessageSize.FormattingEnabled = True
        Me.cboAttachmentMessageSize.Items.AddRange(New Object() {">", "=", "<"})
        Me.cboAttachmentMessageSize.Location = New System.Drawing.Point(123, 105)
        Me.cboAttachmentMessageSize.Name = "cboAttachmentMessageSize"
        Me.cboAttachmentMessageSize.Size = New System.Drawing.Size(39, 21)
        Me.cboAttachmentMessageSize.TabIndex = 27
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(271, 102)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 16)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "BCC:"
        '
        'cboAttachmentBCC
        '
        Me.cboAttachmentBCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAttachmentBCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttachmentBCC.FormattingEnabled = True
        Me.cboAttachmentBCC.Items.AddRange(New Object() {"All", "Me (TrulyMail)"})
        Me.cboAttachmentBCC.Location = New System.Drawing.Point(332, 101)
        Me.cboAttachmentBCC.Name = "cboAttachmentBCC"
        Me.cboAttachmentBCC.Size = New System.Drawing.Size(203, 21)
        Me.cboAttachmentBCC.TabIndex = 39
        '
        'dtpAttachmentBefore
        '
        Me.dtpAttachmentBefore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpAttachmentBefore.Location = New System.Drawing.Point(363, 366)
        Me.dtpAttachmentBefore.MaxDate = New Date(2199, 12, 31, 0, 0, 0, 0)
        Me.dtpAttachmentBefore.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.dtpAttachmentBefore.Name = "dtpAttachmentBefore"
        Me.dtpAttachmentBefore.Size = New System.Drawing.Size(429, 20)
        Me.dtpAttachmentBefore.TabIndex = 32
        Me.dtpAttachmentBefore.Value = New Date(2199, 12, 31, 0, 0, 0, 0)
        '
        'dtpAttachmentAfter
        '
        Me.dtpAttachmentAfter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpAttachmentAfter.Location = New System.Drawing.Point(363, 340)
        Me.dtpAttachmentAfter.MaxDate = New Date(2199, 12, 31, 0, 0, 0, 0)
        Me.dtpAttachmentAfter.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.dtpAttachmentAfter.Name = "dtpAttachmentAfter"
        Me.dtpAttachmentAfter.Size = New System.Drawing.Size(429, 20)
        Me.dtpAttachmentAfter.TabIndex = 30
        '
        'cboAttachmentCC
        '
        Me.cboAttachmentCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAttachmentCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttachmentCC.FormattingEnabled = True
        Me.cboAttachmentCC.Items.AddRange(New Object() {"All", "Me (TrulyMail)"})
        Me.cboAttachmentCC.Location = New System.Drawing.Point(332, 74)
        Me.cboAttachmentCC.Name = "cboAttachmentCC"
        Me.cboAttachmentCC.Size = New System.Drawing.Size(203, 21)
        Me.cboAttachmentCC.TabIndex = 22
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(271, 79)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 16)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "CC:"
        '
        'cboAttachmentTo
        '
        Me.cboAttachmentTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAttachmentTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttachmentTo.FormattingEnabled = True
        Me.cboAttachmentTo.Items.AddRange(New Object() {"All", "Me (TrulyMail)"})
        Me.cboAttachmentTo.Location = New System.Drawing.Point(332, 47)
        Me.cboAttachmentTo.Name = "cboAttachmentTo"
        Me.cboAttachmentTo.Size = New System.Drawing.Size(203, 21)
        Me.cboAttachmentTo.TabIndex = 20
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(271, 52)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(25, 16)
        Me.Label19.TabIndex = 19
        Me.Label19.Text = "To:"
        '
        'cboAttachmentFrom
        '
        Me.cboAttachmentFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAttachmentFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttachmentFrom.FormattingEnabled = True
        Me.cboAttachmentFrom.Items.AddRange(New Object() {"All", "Me (TrulyMail)"})
        Me.cboAttachmentFrom.Location = New System.Drawing.Point(332, 20)
        Me.cboAttachmentFrom.Name = "cboAttachmentFrom"
        Me.cboAttachmentFrom.Size = New System.Drawing.Size(203, 21)
        Me.cboAttachmentFrom.TabIndex = 18
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(271, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 16)
        Me.Label20.TabIndex = 17
        Me.Label20.Text = "From:"
        '
        'chkAttachmentSubfolders
        '
        Me.chkAttachmentSubfolders.AutoSize = True
        Me.chkAttachmentSubfolders.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAttachmentSubfolders.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.chkAttachmentSubfolders.Location = New System.Drawing.Point(268, 242)
        Me.chkAttachmentSubfolders.Name = "chkAttachmentSubfolders"
        Me.chkAttachmentSubfolders.Size = New System.Drawing.Size(135, 20)
        Me.chkAttachmentSubfolders.TabIndex = 25
        Me.chkAttachmentSubfolders.Text = "Search subfolders:"
        Me.chkAttachmentSubfolders.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(271, 218)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 16)
        Me.Label21.TabIndex = 23
        Me.Label21.Text = "Folder:"
        '
        'lvAttachmentMessageType
        '
        Me.lvAttachmentMessageType.AllColumns.Add(Me.OlvColumn2)
        Me.lvAttachmentMessageType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvAttachmentMessageType.CellEditUseWholeCell = False
        Me.lvAttachmentMessageType.CheckBoxes = True
        Me.lvAttachmentMessageType.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2})
        Me.lvAttachmentMessageType.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvAttachmentMessageType.HideSelection = False
        Me.lvAttachmentMessageType.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.lvAttachmentMessageType.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.lvAttachmentMessageType.Location = New System.Drawing.Point(123, 211)
        Me.lvAttachmentMessageType.Name = "lvAttachmentMessageType"
        Me.lvAttachmentMessageType.ShowGroups = False
        Me.lvAttachmentMessageType.Size = New System.Drawing.Size(136, 217)
        Me.lvAttachmentMessageType.TabIndex = 16
        Me.lvAttachmentMessageType.UseCompatibleStateImageBehavior = False
        Me.lvAttachmentMessageType.View = System.Windows.Forms.View.Details
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "DisplayName"
        Me.OlvColumn2.Text = "Type"
        Me.OlvColumn2.Width = 132
        '
        'txtAttachmentBody
        '
        Me.txtAttachmentBody.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAttachmentBody.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAttachmentBody.Location = New System.Drawing.Point(277, 156)
        Me.txtAttachmentBody.Name = "txtAttachmentBody"
        Me.txtAttachmentBody.Size = New System.Drawing.Size(515, 22)
        Me.txtAttachmentBody.TabIndex = 14
        '
        'cboAttachmentBody
        '
        Me.cboAttachmentBody.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttachmentBody.FormattingEnabled = True
        Me.cboAttachmentBody.Items.AddRange(New Object() {"All", "Contains"})
        Me.cboAttachmentBody.Location = New System.Drawing.Point(123, 157)
        Me.cboAttachmentBody.Name = "cboAttachmentBody"
        Me.cboAttachmentBody.Size = New System.Drawing.Size(136, 21)
        Me.cboAttachmentBody.TabIndex = 13
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(6, 211)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(54, 16)
        Me.Label22.TabIndex = 15
        Me.Label22.Text = "Type(s):"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 158)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(42, 16)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "Body:"
        '
        'txtAttachmentSubject
        '
        Me.txtAttachmentSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAttachmentSubject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAttachmentSubject.Location = New System.Drawing.Point(277, 129)
        Me.txtAttachmentSubject.Name = "txtAttachmentSubject"
        Me.txtAttachmentSubject.Size = New System.Drawing.Size(515, 22)
        Me.txtAttachmentSubject.TabIndex = 11
        '
        'cboAttachmentSubject
        '
        Me.cboAttachmentSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttachmentSubject.FormattingEnabled = True
        Me.cboAttachmentSubject.Items.AddRange(New Object() {"All", "Is exactly", "Contains"})
        Me.cboAttachmentSubject.Location = New System.Drawing.Point(123, 130)
        Me.cboAttachmentSubject.Name = "cboAttachmentSubject"
        Me.cboAttachmentSubject.Size = New System.Drawing.Size(136, 21)
        Me.cboAttachmentSubject.TabIndex = 10
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(6, 131)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 16)
        Me.Label24.TabIndex = 9
        Me.Label24.Text = "Subject:"
        '
        'Label26
        '
        Me.Label26.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(271, 368)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(78, 16)
        Me.Label26.TabIndex = 31
        Me.Label26.Text = "Sent before:"
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(271, 342)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(68, 16)
        Me.Label27.TabIndex = 29
        Me.Label27.Text = "Sent after:"
        '
        'cboAttachmentRead
        '
        Me.cboAttachmentRead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttachmentRead.FormattingEnabled = True
        Me.cboAttachmentRead.Items.AddRange(New Object() {"All", "Read", "Not read"})
        Me.cboAttachmentRead.Location = New System.Drawing.Point(123, 51)
        Me.cboAttachmentRead.Name = "cboAttachmentRead"
        Me.cboAttachmentRead.Size = New System.Drawing.Size(136, 21)
        Me.cboAttachmentRead.TabIndex = 6
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(6, 52)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(42, 16)
        Me.Label28.TabIndex = 5
        Me.Label28.Text = "Read:"
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'tabResults
        '
        Me.tabResults.Controls.Add(Me.pnlResults)
        Me.tabResults.Controls.Add(Me.olvAttachments)
        Me.tabResults.Location = New System.Drawing.Point(4, 22)
        Me.tabResults.Name = "tabResults"
        Me.tabResults.Padding = New System.Windows.Forms.Padding(3)
        Me.tabResults.Size = New System.Drawing.Size(917, 519)
        Me.tabResults.TabIndex = 1
        Me.tabResults.Text = "Results"
        Me.tabResults.UseVisualStyleBackColor = True
        '
        'pnlResults
        '
        Me.pnlResults.AutoSize = True
        Me.pnlResults.Controls.Add(Me.olvMessages)
        Me.pnlResults.Controls.Add(Me.pnlMessageFilter)
        Me.pnlResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlResults.Location = New System.Drawing.Point(3, 3)
        Me.pnlResults.Name = "pnlResults"
        Me.pnlResults.Size = New System.Drawing.Size(911, 513)
        Me.pnlResults.TabIndex = 19
        Me.pnlResults.Visible = False
        '
        'olvMessages
        '
        Me.olvMessages.AllColumns.Add(Me.OlvColumnSubject)
        Me.olvMessages.AllColumns.Add(Me.OlvColumnAttachments)
        Me.olvMessages.AllColumns.Add(Me.OlvColumnSender)
        Me.olvMessages.AllColumns.Add(Me.OlvColumnRecipients)
        Me.olvMessages.AllColumns.Add(Me.OlvColumnMessageDateSent)
        Me.olvMessages.AllColumns.Add(Me.OlvColumnSize)
        Me.olvMessages.AllColumns.Add(Me.OlvColumnReceived)
        Me.olvMessages.AllColumns.Add(Me.OlvColumnViewed)
        Me.olvMessages.AllColumns.Add(Me.olvMessageFolder)
        Me.olvMessages.AllColumns.Add(Me.olvColumnTransportType)
        Me.olvMessages.AllColumns.Add(Me.olvColumnHasNotes)
        Me.olvMessages.AllColumns.Add(Me.olvMessageTags)
        Me.olvMessages.AllowColumnReorder = True
        Me.olvMessages.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.olvMessages.CellEditUseWholeCell = False
        Me.olvMessages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumnSubject, Me.OlvColumnAttachments, Me.OlvColumnSender, Me.OlvColumnRecipients, Me.OlvColumnMessageDateSent, Me.OlvColumnSize, Me.OlvColumnReceived, Me.OlvColumnViewed, Me.olvMessageFolder, Me.olvColumnTransportType, Me.olvColumnHasNotes, Me.olvMessageTags})
        Me.olvMessages.ContextMenuStrip = Me.ctxmnuMessages
        Me.olvMessages.Cursor = System.Windows.Forms.Cursors.Default
        Me.olvMessages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvMessages.EmptyListMsg = "There are no messages to display"
        Me.olvMessages.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvMessages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvMessages.FullRowSelect = True
        Me.olvMessages.HasCollapsibleGroups = False
        Me.olvMessages.HideSelection = False
        Me.olvMessages.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvMessages.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvMessages.LabelWrap = False
        Me.olvMessages.Location = New System.Drawing.Point(0, 27)
        Me.olvMessages.Name = "olvMessages"
        Me.olvMessages.OwnerDraw = False
        Me.olvMessages.SelectColumnsMenuStaysOpen = False
        Me.olvMessages.ShowCommandMenuOnRightClick = True
        Me.olvMessages.ShowGroups = False
        Me.olvMessages.ShowImagesOnSubItems = True
        Me.olvMessages.ShowItemCountOnGroups = True
        Me.olvMessages.Size = New System.Drawing.Size(911, 486)
        Me.olvMessages.SmallImageList = Me.ImglstMessageStatus
        Me.olvMessages.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.olvMessages.TabIndex = 3
        Me.olvMessages.UseCompatibleStateImageBehavior = False
        Me.olvMessages.UseFiltering = True
        Me.olvMessages.View = System.Windows.Forms.View.Details
        '
        'OlvColumnSubject
        '
        Me.OlvColumnSubject.AspectName = "SubjectShort"
        Me.OlvColumnSubject.DisplayIndex = 2
        Me.OlvColumnSubject.Text = "Subject"
        Me.OlvColumnSubject.Width = 146
        '
        'OlvColumnAttachments
        '
        Me.OlvColumnAttachments.AspectName = "Attachments.Count"
        Me.OlvColumnAttachments.AspectToStringFormat = "{0:#}"
        Me.OlvColumnAttachments.DisplayIndex = 3
        Me.OlvColumnAttachments.HeaderImageKey = "attach.png"
        Me.OlvColumnAttachments.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnAttachments.ShowTextInHeader = False
        Me.OlvColumnAttachments.Text = "A"
        Me.OlvColumnAttachments.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnAttachments.Width = 40
        '
        'OlvColumnSender
        '
        Me.OlvColumnSender.AspectName = "SenderName"
        Me.OlvColumnSender.DisplayIndex = 4
        Me.OlvColumnSender.Text = "Sender"
        Me.OlvColumnSender.Width = 109
        '
        'OlvColumnRecipients
        '
        Me.OlvColumnRecipients.AspectName = "RecipientNamesShort"
        Me.OlvColumnRecipients.DisplayIndex = 5
        Me.OlvColumnRecipients.Text = "Recipients"
        Me.OlvColumnRecipients.Width = 112
        '
        'OlvColumnMessageDateSent
        '
        Me.OlvColumnMessageDateSent.AspectName = "MessageDateSent"
        Me.OlvColumnMessageDateSent.DisplayIndex = 6
        Me.OlvColumnMessageDateSent.Text = "Date"
        Me.OlvColumnMessageDateSent.Width = 155
        '
        'OlvColumnSize
        '
        Me.OlvColumnSize.AspectName = "Size"
        Me.OlvColumnSize.AspectToStringFormat = ""
        Me.OlvColumnSize.DisplayIndex = 7
        Me.OlvColumnSize.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnSize.Text = "Size"
        Me.OlvColumnSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnSize.Width = 73
        '
        'OlvColumnReceived
        '
        Me.OlvColumnReceived.AspectName = "Received"
        Me.OlvColumnReceived.AspectToStringFormat = "{0:##0%}"
        Me.OlvColumnReceived.DisplayIndex = 8
        Me.OlvColumnReceived.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnReceived.Text = "Rec"
        Me.OlvColumnReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OlvColumnViewed
        '
        Me.OlvColumnViewed.AspectName = "Viewed"
        Me.OlvColumnViewed.AspectToStringFormat = "{0:##0%}"
        Me.OlvColumnViewed.DisplayIndex = 9
        Me.OlvColumnViewed.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnViewed.Text = "View"
        Me.OlvColumnViewed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'olvMessageFolder
        '
        Me.olvMessageFolder.AspectName = "FolderName"
        Me.olvMessageFolder.DisplayIndex = 10
        Me.olvMessageFolder.Text = "Folder"
        Me.olvMessageFolder.Width = 120
        '
        'olvColumnTransportType
        '
        Me.olvColumnTransportType.AspectName = "TransportType"
        Me.olvColumnTransportType.DisplayIndex = 0
        Me.olvColumnTransportType.HeaderImageKey = "Securedmessage_16.bmp"
        Me.olvColumnTransportType.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.olvColumnTransportType.Text = ""
        Me.olvColumnTransportType.Width = 40
        '
        'olvColumnHasNotes
        '
        Me.olvColumnHasNotes.AspectName = "HasNotes"
        Me.olvColumnHasNotes.DisplayIndex = 1
        Me.olvColumnHasNotes.HeaderImageKey = "Note_16.bmp"
        Me.olvColumnHasNotes.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.olvColumnHasNotes.ShowTextInHeader = False
        Me.olvColumnHasNotes.Text = ""
        Me.olvColumnHasNotes.Width = 40
        '
        'olvMessageTags
        '
        Me.olvMessageTags.AspectName = "Tags"
        Me.olvMessageTags.Text = "Tags"
        '
        'ctxmnuMessages
        '
        Me.ctxmnuMessages.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuMessages.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.MoveToToolStripMenuItem})
        Me.ctxmnuMessages.Name = "ctxmnuMessages"
        Me.ctxmnuMessages.Size = New System.Drawing.Size(181, 92)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.DeleteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        '
        'MoveToToolStripMenuItem
        '
        Me.MoveToToolStripMenuItem.Name = "MoveToToolStripMenuItem"
        Me.MoveToToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MoveToToolStripMenuItem.Text = "&Move to..."
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
        Me.ImglstMessageStatus.Images.SetKeyName(6, "Note_16.bmp")
        Me.ImglstMessageStatus.Images.SetKeyName(7, "Transparent_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(8, "redemail_16.png")
        Me.ImglstMessageStatus.Images.SetKeyName(9, "attach.png")
        '
        'pnlMessageFilter
        '
        Me.pnlMessageFilter.AutoSize = True
        Me.pnlMessageFilter.Controls.Add(Me.cboMessageTags)
        Me.pnlMessageFilter.Controls.Add(Me.txtMessageFilter)
        Me.pnlMessageFilter.Controls.Add(Me.btnClearMessageFilter)
        Me.pnlMessageFilter.Controls.Add(Me.KryptonPanel2)
        Me.pnlMessageFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMessageFilter.Location = New System.Drawing.Point(0, 0)
        Me.pnlMessageFilter.Name = "pnlMessageFilter"
        Me.pnlMessageFilter.Size = New System.Drawing.Size(911, 27)
        Me.pnlMessageFilter.TabIndex = 7
        '
        'cboMessageTags
        '
        Me.cboMessageTags.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cboMessageTags.FormattingEnabled = True
        Me.cboMessageTags.Location = New System.Drawing.Point(38, 3)
        Me.cboMessageTags.Name = "cboMessageTags"
        Me.cboMessageTags.Size = New System.Drawing.Size(124, 21)
        Me.cboMessageTags.TabIndex = 4
        '
        'txtMessageFilter
        '
        Me.txtMessageFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtMessageFilter.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtMessageFilter.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessageFilter.Location = New System.Drawing.Point(735, 0)
        Me.txtMessageFilter.Name = "txtMessageFilter"
        Me.txtMessageFilter.Size = New System.Drawing.Size(142, 26)
        Me.txtMessageFilter.TabIndex = 1
        '
        'btnClearMessageFilter
        '
        Me.btnClearMessageFilter.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClearMessageFilter.Image = CType(resources.GetObject("btnClearMessageFilter.Image"), System.Drawing.Image)
        Me.btnClearMessageFilter.Location = New System.Drawing.Point(877, 0)
        Me.btnClearMessageFilter.Name = "btnClearMessageFilter"
        Me.btnClearMessageFilter.Size = New System.Drawing.Size(34, 27)
        Me.btnClearMessageFilter.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnClearMessageFilter, "Clear message filters")
        Me.btnClearMessageFilter.UseVisualStyleBackColor = True
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.pbClearTags)
        Me.KryptonPanel2.Controls.Add(Me.llblFilter)
        Me.KryptonPanel2.Controls.Add(Me.Label31)
        Me.KryptonPanel2.Controls.Add(Me.pbAddTag)
        Me.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel2.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.Palette = Me.KryptonPalette1
        Me.KryptonPanel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel2.Size = New System.Drawing.Size(911, 27)
        Me.KryptonPanel2.TabIndex = 54
        '
        'pbClearTags
        '
        Me.pbClearTags.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbClearTags.Image = Global.TrulyMail.My.Resources.Resources.remove_icon_48
        Me.pbClearTags.Location = New System.Drawing.Point(200, 1)
        Me.pbClearTags.Name = "pbClearTags"
        Me.pbClearTags.Size = New System.Drawing.Size(32, 26)
        Me.pbClearTags.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbClearTags.TabIndex = 7
        Me.pbClearTags.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbClearTags, "Remove all tags from selected message(s)")
        '
        'llblFilter
        '
        Me.llblFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llblFilter.AutoSize = True
        Me.llblFilter.BackColor = System.Drawing.Color.Transparent
        Me.llblFilter.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.llblFilter.LinkArea = New System.Windows.Forms.LinkArea(0, 0)
        Me.llblFilter.Location = New System.Drawing.Point(682, 3)
        Me.llblFilter.Name = "llblFilter"
        Me.llblFilter.Size = New System.Drawing.Size(47, 18)
        Me.llblFilter.TabIndex = 10
        Me.llblFilter.Text = "Filter:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(2, 4)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(37, 18)
        Me.Label31.TabIndex = 3
        Me.Label31.Text = "Tag:"
        '
        'pbAddTag
        '
        Me.pbAddTag.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbAddTag.Image = Global.TrulyMail.My.Resources.Resources.add_icon_48
        Me.pbAddTag.Location = New System.Drawing.Point(168, 1)
        Me.pbAddTag.Name = "pbAddTag"
        Me.pbAddTag.Size = New System.Drawing.Size(32, 26)
        Me.pbAddTag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAddTag.TabIndex = 6
        Me.pbAddTag.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbAddTag, "Add selected tag to selected message(s)")
        '
        'olvAttachments
        '
        Me.olvAttachments.AllColumns.Add(Me.olvColumnAttachmentName)
        Me.olvAttachments.AllColumns.Add(Me.OlvColumnAttachmentSize)
        Me.olvAttachments.AllColumns.Add(Me.OlvColumn3)
        Me.olvAttachments.AllColumns.Add(Me.OlvColumn5)
        Me.olvAttachments.AllColumns.Add(Me.OlvColumn6)
        Me.olvAttachments.AllColumns.Add(Me.olvColumnAttachmentDate)
        Me.olvAttachments.AllColumns.Add(Me.OlvColumnMessageSize)
        Me.olvAttachments.AllColumns.Add(Me.olvColumnAttachmentMessageTag)
        Me.olvAttachments.AllowColumnReorder = True
        Me.olvAttachments.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.olvAttachments.CellEditUseWholeCell = False
        Me.olvAttachments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvColumnAttachmentName, Me.OlvColumnAttachmentSize, Me.OlvColumn3, Me.OlvColumn5, Me.OlvColumn6, Me.olvColumnAttachmentDate, Me.OlvColumnMessageSize, Me.olvColumnAttachmentMessageTag})
        Me.olvAttachments.ContextMenuStrip = Me.ctxmnuAttachments
        Me.olvAttachments.Cursor = System.Windows.Forms.Cursors.Default
        Me.olvAttachments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvAttachments.EmptyListMsg = "There are no attachments to display"
        Me.olvAttachments.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvAttachments.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvAttachments.FullRowSelect = True
        Me.olvAttachments.HideSelection = False
        Me.olvAttachments.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvAttachments.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvAttachments.LabelWrap = False
        Me.olvAttachments.Location = New System.Drawing.Point(3, 3)
        Me.olvAttachments.Name = "olvAttachments"
        Me.olvAttachments.SelectColumnsMenuStaysOpen = False
        Me.olvAttachments.ShowCommandMenuOnRightClick = True
        Me.olvAttachments.ShowGroups = False
        Me.olvAttachments.ShowImagesOnSubItems = True
        Me.olvAttachments.ShowItemCountOnGroups = True
        Me.olvAttachments.Size = New System.Drawing.Size(911, 513)
        Me.olvAttachments.SmallImageList = Me.ImglstMessageStatus
        Me.olvAttachments.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.olvAttachments.TabIndex = 4
        Me.olvAttachments.UseCompatibleStateImageBehavior = False
        Me.olvAttachments.View = System.Windows.Forms.View.Details
        Me.olvAttachments.Visible = False
        '
        'olvColumnAttachmentName
        '
        Me.olvColumnAttachmentName.AspectName = "AttachmentFilename"
        Me.olvColumnAttachmentName.AspectToStringFormat = ""
        Me.olvColumnAttachmentName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.olvColumnAttachmentName.Text = "Filename"
        Me.olvColumnAttachmentName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.olvColumnAttachmentName.Width = 87
        '
        'OlvColumnAttachmentSize
        '
        Me.OlvColumnAttachmentSize.AspectName = "AttachmentFileSize"
        Me.OlvColumnAttachmentSize.Text = "File Size"
        Me.OlvColumnAttachmentSize.Width = 72
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "Subject"
        Me.OlvColumn3.Text = "Subject"
        Me.OlvColumn3.Width = 146
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "Sender"
        Me.OlvColumn5.Text = "Sender"
        Me.OlvColumn5.Width = 109
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "Recipients"
        Me.OlvColumn6.Text = "Recipients"
        Me.OlvColumn6.Width = 112
        '
        'olvColumnAttachmentDate
        '
        Me.olvColumnAttachmentDate.AspectName = "MessageDateSent"
        Me.olvColumnAttachmentDate.Text = "Date"
        Me.olvColumnAttachmentDate.Width = 155
        '
        'OlvColumnMessageSize
        '
        Me.OlvColumnMessageSize.AspectName = "MessageSize"
        Me.OlvColumnMessageSize.AspectToStringFormat = ""
        Me.OlvColumnMessageSize.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnMessageSize.Text = "Size"
        Me.OlvColumnMessageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumnMessageSize.Width = 73
        '
        'olvColumnAttachmentMessageTag
        '
        Me.olvColumnAttachmentMessageTag.AspectName = "Tags"
        Me.olvColumnAttachmentMessageTag.Text = "Tags"
        '
        'ctxmnuAttachments
        '
        Me.ctxmnuAttachments.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ctxmnuAttachments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenAttachmentToolStripMenuItem, Me.OpenMessageToolStripMenuItem})
        Me.ctxmnuAttachments.Name = "ctxmnuMessages"
        Me.ctxmnuAttachments.Size = New System.Drawing.Size(175, 48)
        '
        'OpenAttachmentToolStripMenuItem
        '
        Me.OpenAttachmentToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenAttachmentToolStripMenuItem.Name = "OpenAttachmentToolStripMenuItem"
        Me.OpenAttachmentToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.OpenAttachmentToolStripMenuItem.Text = "&Open Attachment"
        '
        'OpenMessageToolStripMenuItem
        '
        Me.OpenMessageToolStripMenuItem.Name = "OpenMessageToolStripMenuItem"
        Me.OpenMessageToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.OpenMessageToolStripMenuItem.Text = "O&pen Message"
        '
        'prgSearchProgress
        '
        Me.prgSearchProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prgSearchProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.prgSearchProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prgSearchProgress.ForeColor = System.Drawing.Color.Blue
        Me.prgSearchProgress.HighLowCutoff = CType(90, Byte)
        Me.prgSearchProgress.HighTextDecimalPlaces = CType(2, Byte)
        Me.prgSearchProgress.Location = New System.Drawing.Point(454, 4)
        Me.prgSearchProgress.LowTextDecimalPlaces = CType(2, Byte)
        Me.prgSearchProgress.Maximum = CType(100, Long)
        Me.prgSearchProgress.Minimum = CType(0, Long)
        Me.prgSearchProgress.Name = "prgSearchProgress"
        Me.prgSearchProgress.Size = New System.Drawing.Size(390, 25)
        Me.prgSearchProgress.TabIndex = 16
        Me.prgSearchProgress.Value = CType(0, Long)
        Me.prgSearchProgress.Visible = False
        '
        'lblSearchProgress
        '
        Me.lblSearchProgress.AutoSize = True
        Me.lblSearchProgress.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchProgress.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchProgress.Location = New System.Drawing.Point(384, 5)
        Me.lblSearchProgress.Name = "lblSearchProgress"
        Me.lblSearchProgress.Size = New System.Drawing.Size(64, 16)
        Me.lblSearchProgress.TabIndex = 17
        Me.lblSearchProgress.Text = "Progress:"
        Me.lblSearchProgress.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(844, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(66, 27)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'tmrFilterMessages
        '
        Me.tmrFilterMessages.Interval = 400.0R
        Me.tmrFilterMessages.SynchronizingObject = Me
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.Label5)
        Me.KryptonPanel.Controls.Add(Me.lblSearchProgress)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(915, 568)
        Me.KryptonPanel.TabIndex = 54
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPalette = Me.KryptonPalette1
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom
        '
        'SearchForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(915, 568)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.prgSearchProgress)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.cboSearchType)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(665, 449)
        Me.Name = "SearchForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search"
        Me.TabControl1.ResumeLayout(False)
        Me.tabCriteria.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.grpMessages.ResumeLayout(False)
        Me.grpMessages.PerformLayout()
        CType(Me.lvMessageTypes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAttachments.ResumeLayout(False)
        Me.grpAttachments.PerformLayout()
        CType(Me.lvAttachmentMessageType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabResults.ResumeLayout(False)
        Me.tabResults.PerformLayout()
        Me.pnlResults.ResumeLayout(False)
        Me.pnlResults.PerformLayout()
        CType(Me.olvMessages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmnuMessages.ResumeLayout(False)
        Me.pnlMessageFilter.ResumeLayout(False)
        Me.pnlMessageFilter.PerformLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.pbClearTags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddTag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.olvAttachments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmnuAttachments.ResumeLayout(False)
        CType(Me.tmrFilterMessages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboSearchType As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabCriteria As System.Windows.Forms.TabPage
    Friend WithEvents tabResults As System.Windows.Forms.TabPage
    Friend WithEvents ctxmnuMessages As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveToToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents olvMessages As BrightIdeasSoftware.ObjectListView
    Friend WithEvents OlvColumnSubject As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnAttachments As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnRecipients As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnMessageDateSent As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnSize As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnReceived As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnViewed As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnSender As BrightIdeasSoftware.OLVColumn
    Friend WithEvents grpAttachments As System.Windows.Forms.GroupBox
    Friend WithEvents txtAttachmentMessageSize As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboAttachmentMessageSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboAttachmentBCC As System.Windows.Forms.ComboBox
    Friend WithEvents dtpAttachmentBefore As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpAttachmentAfter As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboAttachmentCC As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboAttachmentTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboAttachmentFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents chkAttachmentSubfolders As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lvAttachmentMessageType As BrightIdeasSoftware.ObjectListView
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents txtAttachmentBody As System.Windows.Forms.TextBox
    Friend WithEvents cboAttachmentBody As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtAttachmentSubject As System.Windows.Forms.TextBox
    Friend WithEvents cboAttachmentSubject As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboAttachmentRead As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtAttachmentAttachmentSize As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboAttachmentAttachmentSize As System.Windows.Forms.ComboBox
    Friend WithEvents txtAttachmentName As System.Windows.Forms.TextBox
    Friend WithEvents cboAttachmentName As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents olvAttachments As BrightIdeasSoftware.ObjectListView
    Friend WithEvents olvColumnAttachmentName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnAttachmentSize As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn5 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn6 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnAttachmentDate As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnMessageSize As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ctxmnuAttachments As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenAttachmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblSearchProgress As System.Windows.Forms.Label
    Friend WithEvents prgSearchProgress As MontgomerySoftware.Controls.ProgressBar
    Friend WithEvents olvMessageFolder As BrightIdeasSoftware.OLVColumn
    Friend WithEvents txtAttachmentBCC As System.Windows.Forms.TextBox
    Friend WithEvents txtAttachmentCC As System.Windows.Forms.TextBox
    Friend WithEvents txtAttachmentTo As System.Windows.Forms.TextBox
    Friend WithEvents txtAttachmentFrom As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grpMessages As System.Windows.Forms.GroupBox
    Friend WithEvents txtMessageBCC As System.Windows.Forms.TextBox
    Friend WithEvents txtMessageCC As System.Windows.Forms.TextBox
    Friend WithEvents txtMessageTo As System.Windows.Forms.TextBox
    Friend WithEvents txtMessageFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtMessageSize As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboMessageSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboMessageBCC As System.Windows.Forms.ComboBox
    Friend WithEvents dtpMessageSentBefore As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpMessageSentAfter As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboMessageCC As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboMessageTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboMessageFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkMessageSubfolders As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lvMessageTypes As BrightIdeasSoftware.ObjectListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents txtMessageBody As System.Windows.Forms.TextBox
    Friend WithEvents cboMessageBody As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMessageSubject As System.Windows.Forms.TextBox
    Friend WithEvents cboMessageSubject As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboMessageAttachments As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboMessageRead As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents olvMessageTags As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnTransportType As BrightIdeasSoftware.OLVColumn
    Friend WithEvents olvColumnHasNotes As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ImglstMessageStatus As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMessageTags As System.Windows.Forms.TextBox
    Friend WithEvents txtAttachmentMessageTag As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents olvColumnAttachmentMessageTag As BrightIdeasSoftware.OLVColumn
    Friend WithEvents llblChangeMessageFolder As System.Windows.Forms.LinkLabel
    Friend WithEvents llblChangeAttachmentFolder As System.Windows.Forms.LinkLabel
    Friend WithEvents pnlResults As System.Windows.Forms.Panel
    Friend WithEvents pnlMessageFilter As System.Windows.Forms.Panel
    Friend WithEvents pbClearTags As System.Windows.Forms.PictureBox
    Friend WithEvents cboMessageTags As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtMessageFilter As System.Windows.Forms.TextBox
    Friend WithEvents btnClearMessageFilter As System.Windows.Forms.Button
    Friend WithEvents pbAddTag As System.Windows.Forms.PictureBox
    Friend WithEvents llblFilter As System.Windows.Forms.LinkLabel
    Friend WithEvents tmrFilterMessages As System.Timers.Timer
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
End Class
