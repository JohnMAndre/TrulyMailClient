<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportMessages
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportMessages))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblMessagesExported = New System.Windows.Forms.Label()
        Me.lblMessagesExportedCaption = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkIncludeEmail = New System.Windows.Forms.CheckBox()
        Me.chkIncludeAllRecipients = New System.Windows.Forms.CheckBox()
        Me.chkIncludeTrulyMailMessages = New System.Windows.Forms.CheckBox()
        Me.txtTrulyMailEmailAddress = New System.Windows.Forms.TextBox()
        Me.pbIncludeEmail = New System.Windows.Forms.PictureBox()
        Me.pbIncludeTrulyMail = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New MontgomerySoftware.Controls.ProgressBar()
        Me.llblChangePage = New System.Windows.Forms.LinkLabel()
        Me.pbFilename = New System.Windows.Forms.PictureBox()
        Me.pbIncludeSubFolders = New System.Windows.Forms.PictureBox()
        Me.pbSelectFolder = New System.Windows.Forms.PictureBox()
        Me.pbExportPath = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlFilenameMethod = New System.Windows.Forms.Panel()
        Me.rbtnFilenameSubject = New System.Windows.Forms.RadioButton()
        Me.rbtnFilenameGUID = New System.Windows.Forms.RadioButton()
        Me.chkIncludeSubFolders = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblMessagesProcessed = New System.Windows.Forms.Label()
        Me.lblMessagesProcessedCaption = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBrowseForData = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDataPath = New System.Windows.Forms.TextBox()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbIncludeEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbIncludeTrulyMail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbFilename, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbIncludeSubFolders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSelectFolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbExportPath, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFilenameMethod.SuspendLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.KryptonPanel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(607, 419)
        Me.Panel1.TabIndex = 13
        '
        'lblMessagesExported
        '
        Me.lblMessagesExported.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessagesExported.AutoSize = True
        Me.lblMessagesExported.BackColor = System.Drawing.Color.Transparent
        Me.lblMessagesExported.Location = New System.Drawing.Point(504, 345)
        Me.lblMessagesExported.Name = "lblMessagesExported"
        Me.lblMessagesExported.Size = New System.Drawing.Size(15, 16)
        Me.lblMessagesExported.TabIndex = 54
        Me.lblMessagesExported.Text = "0"
        Me.lblMessagesExported.Visible = False
        '
        'lblMessagesExportedCaption
        '
        Me.lblMessagesExportedCaption.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessagesExportedCaption.AutoSize = True
        Me.lblMessagesExportedCaption.BackColor = System.Drawing.Color.Transparent
        Me.lblMessagesExportedCaption.Location = New System.Drawing.Point(368, 345)
        Me.lblMessagesExportedCaption.Name = "lblMessagesExportedCaption"
        Me.lblMessagesExportedCaption.Size = New System.Drawing.Size(130, 16)
        Me.lblMessagesExportedCaption.TabIndex = 53
        Me.lblMessagesExportedCaption.Text = "Messages exported: "
        Me.lblMessagesExportedCaption.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkIncludeEmail)
        Me.GroupBox1.Controls.Add(Me.chkIncludeAllRecipients)
        Me.GroupBox1.Controls.Add(Me.chkIncludeTrulyMailMessages)
        Me.GroupBox1.Controls.Add(Me.txtTrulyMailEmailAddress)
        Me.GroupBox1.Controls.Add(Me.pbIncludeEmail)
        Me.GroupBox1.Controls.Add(Me.pbIncludeTrulyMail)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 196)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(550, 100)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Recipients"
        '
        'chkIncludeEmail
        '
        Me.chkIncludeEmail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIncludeEmail.Checked = True
        Me.chkIncludeEmail.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncludeEmail.Enabled = False
        Me.chkIncludeEmail.Location = New System.Drawing.Point(17, 67)
        Me.chkIncludeEmail.Name = "chkIncludeEmail"
        Me.chkIncludeEmail.Size = New System.Drawing.Size(226, 21)
        Me.chkIncludeEmail.TabIndex = 20
        Me.chkIncludeEmail.Text = "&Include email recipients:"
        Me.chkIncludeEmail.UseVisualStyleBackColor = True
        '
        'chkIncludeAllRecipients
        '
        Me.chkIncludeAllRecipients.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIncludeAllRecipients.Checked = True
        Me.chkIncludeAllRecipients.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncludeAllRecipients.Location = New System.Drawing.Point(17, 21)
        Me.chkIncludeAllRecipients.Name = "chkIncludeAllRecipients"
        Me.chkIncludeAllRecipients.Size = New System.Drawing.Size(226, 21)
        Me.chkIncludeAllRecipients.TabIndex = 51
        Me.chkIncludeAllRecipients.Text = "&Include &all recipients:"
        Me.chkIncludeAllRecipients.UseVisualStyleBackColor = True
        '
        'chkIncludeTrulyMailMessages
        '
        Me.chkIncludeTrulyMailMessages.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIncludeTrulyMailMessages.Enabled = False
        Me.chkIncludeTrulyMailMessages.Location = New System.Drawing.Point(17, 44)
        Me.chkIncludeTrulyMailMessages.Name = "chkIncludeTrulyMailMessages"
        Me.chkIncludeTrulyMailMessages.Size = New System.Drawing.Size(226, 21)
        Me.chkIncludeTrulyMailMessages.TabIndex = 21
        Me.chkIncludeTrulyMailMessages.Text = "Include TrulyMail &recipients:"
        Me.chkIncludeTrulyMailMessages.UseVisualStyleBackColor = True
        '
        'txtTrulyMailEmailAddress
        '
        Me.txtTrulyMailEmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTrulyMailEmailAddress.Location = New System.Drawing.Point(364, 41)
        Me.txtTrulyMailEmailAddress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTrulyMailEmailAddress.Name = "txtTrulyMailEmailAddress"
        Me.txtTrulyMailEmailAddress.Size = New System.Drawing.Size(154, 22)
        Me.txtTrulyMailEmailAddress.TabIndex = 22
        '
        'pbIncludeEmail
        '
        Me.pbIncludeEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbIncludeEmail.Image = CType(resources.GetObject("pbIncludeEmail.Image"), System.Drawing.Image)
        Me.pbIncludeEmail.Location = New System.Drawing.Point(524, 63)
        Me.pbIncludeEmail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbIncludeEmail.Name = "pbIncludeEmail"
        Me.pbIncludeEmail.Size = New System.Drawing.Size(26, 27)
        Me.pbIncludeEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbIncludeEmail.TabIndex = 35
        Me.pbIncludeEmail.TabStop = False
        '
        'pbIncludeTrulyMail
        '
        Me.pbIncludeTrulyMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbIncludeTrulyMail.Image = CType(resources.GetObject("pbIncludeTrulyMail.Image"), System.Drawing.Image)
        Me.pbIncludeTrulyMail.Location = New System.Drawing.Point(524, 37)
        Me.pbIncludeTrulyMail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbIncludeTrulyMail.Name = "pbIncludeTrulyMail"
        Me.pbIncludeTrulyMail.Size = New System.Drawing.Size(26, 27)
        Me.pbIncludeTrulyMail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbIncludeTrulyMail.TabIndex = 36
        Me.pbIncludeTrulyMail.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(261, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 16)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Email address:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(179, 370)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(94, 36)
        Me.btnCancel.TabIndex = 50
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ProgressBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Blue
        Me.ProgressBar1.HighLowCutoff = CType(90, Byte)
        Me.ProgressBar1.HighTextDecimalPlaces = CType(0, Byte)
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 302)
        Me.ProgressBar1.LowTextDecimalPlaces = CType(0, Byte)
        Me.ProgressBar1.Maximum = CType(100, Long)
        Me.ProgressBar1.Minimum = CType(0, Long)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(576, 27)
        Me.ProgressBar1.TabIndex = 49
        Me.ProgressBar1.Value = CType(0, Long)
        Me.ProgressBar1.Visible = False
        '
        'llblChangePage
        '
        Me.llblChangePage.AutoSize = True
        Me.llblChangePage.BackColor = System.Drawing.Color.Transparent
        Me.llblChangePage.LinkArea = New System.Windows.Forms.LinkArea(6, 12)
        Me.llblChangePage.Location = New System.Drawing.Point(227, 111)
        Me.llblChangePage.Name = "llblChangePage"
        Me.llblChangePage.Size = New System.Drawing.Size(87, 20)
        Me.llblChangePage.TabIndex = 47
        Me.llblChangePage.TabStop = True
        Me.llblChangePage.Text = "InBox change"
        Me.llblChangePage.UseCompatibleTextRendering = True
        '
        'pbFilename
        '
        Me.pbFilename.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbFilename.BackColor = System.Drawing.Color.Transparent
        Me.pbFilename.Image = CType(resources.GetObject("pbFilename.Image"), System.Drawing.Image)
        Me.pbFilename.Location = New System.Drawing.Point(567, 168)
        Me.pbFilename.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbFilename.Name = "pbFilename"
        Me.pbFilename.Size = New System.Drawing.Size(26, 27)
        Me.pbFilename.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbFilename.TabIndex = 34
        Me.pbFilename.TabStop = False
        '
        'pbIncludeSubFolders
        '
        Me.pbIncludeSubFolders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbIncludeSubFolders.BackColor = System.Drawing.Color.Transparent
        Me.pbIncludeSubFolders.Image = CType(resources.GetObject("pbIncludeSubFolders.Image"), System.Drawing.Image)
        Me.pbIncludeSubFolders.Location = New System.Drawing.Point(567, 138)
        Me.pbIncludeSubFolders.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbIncludeSubFolders.Name = "pbIncludeSubFolders"
        Me.pbIncludeSubFolders.Size = New System.Drawing.Size(26, 27)
        Me.pbIncludeSubFolders.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbIncludeSubFolders.TabIndex = 33
        Me.pbIncludeSubFolders.TabStop = False
        '
        'pbSelectFolder
        '
        Me.pbSelectFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbSelectFolder.BackColor = System.Drawing.Color.Transparent
        Me.pbSelectFolder.Image = CType(resources.GetObject("pbSelectFolder.Image"), System.Drawing.Image)
        Me.pbSelectFolder.Location = New System.Drawing.Point(567, 109)
        Me.pbSelectFolder.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbSelectFolder.Name = "pbSelectFolder"
        Me.pbSelectFolder.Size = New System.Drawing.Size(26, 27)
        Me.pbSelectFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbSelectFolder.TabIndex = 32
        Me.pbSelectFolder.TabStop = False
        '
        'pbExportPath
        '
        Me.pbExportPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbExportPath.BackColor = System.Drawing.Color.Transparent
        Me.pbExportPath.Image = CType(resources.GetObject("pbExportPath.Image"), System.Drawing.Image)
        Me.pbExportPath.Location = New System.Drawing.Point(567, 77)
        Me.pbExportPath.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbExportPath.Name = "pbExportPath"
        Me.pbExportPath.Size = New System.Drawing.Size(26, 27)
        Me.pbExportPath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbExportPath.TabIndex = 31
        Me.pbExportPath.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(17, 173)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 16)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Filename should be:"
        '
        'pnlFilenameMethod
        '
        Me.pnlFilenameMethod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFilenameMethod.BackColor = System.Drawing.Color.Transparent
        Me.pnlFilenameMethod.Controls.Add(Me.rbtnFilenameSubject)
        Me.pnlFilenameMethod.Controls.Add(Me.rbtnFilenameGUID)
        Me.pnlFilenameMethod.Location = New System.Drawing.Point(227, 167)
        Me.pnlFilenameMethod.Name = "pnlFilenameMethod"
        Me.pnlFilenameMethod.Size = New System.Drawing.Size(336, 27)
        Me.pnlFilenameMethod.TabIndex = 18
        '
        'rbtnFilenameSubject
        '
        Me.rbtnFilenameSubject.AutoSize = True
        Me.rbtnFilenameSubject.Checked = True
        Me.rbtnFilenameSubject.Location = New System.Drawing.Point(3, 4)
        Me.rbtnFilenameSubject.Name = "rbtnFilenameSubject"
        Me.rbtnFilenameSubject.Size = New System.Drawing.Size(70, 20)
        Me.rbtnFilenameSubject.TabIndex = 14
        Me.rbtnFilenameSubject.TabStop = True
        Me.rbtnFilenameSubject.Text = "Su&bject"
        Me.rbtnFilenameSubject.UseVisualStyleBackColor = True
        '
        'rbtnFilenameGUID
        '
        Me.rbtnFilenameGUID.AutoSize = True
        Me.rbtnFilenameGUID.Location = New System.Drawing.Point(134, 4)
        Me.rbtnFilenameGUID.Name = "rbtnFilenameGUID"
        Me.rbtnFilenameGUID.Size = New System.Drawing.Size(94, 20)
        Me.rbtnFilenameGUID.TabIndex = 15
        Me.rbtnFilenameGUID.Text = "&TrulyMail ID"
        Me.rbtnFilenameGUID.UseVisualStyleBackColor = True
        '
        'chkIncludeSubFolders
        '
        Me.chkIncludeSubFolders.BackColor = System.Drawing.Color.Transparent
        Me.chkIncludeSubFolders.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIncludeSubFolders.Location = New System.Drawing.Point(16, 138)
        Me.chkIncludeSubFolders.Name = "chkIncludeSubFolders"
        Me.chkIncludeSubFolders.Size = New System.Drawing.Size(226, 21)
        Me.chkIncludeSubFolders.TabIndex = 16
        Me.chkIncludeSubFolders.Text = "Include sub-&folders:"
        Me.chkIncludeSubFolders.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(18, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Folder to export:"
        '
        'lblMessagesProcessed
        '
        Me.lblMessagesProcessed.AutoSize = True
        Me.lblMessagesProcessed.BackColor = System.Drawing.Color.Transparent
        Me.lblMessagesProcessed.Location = New System.Drawing.Point(154, 345)
        Me.lblMessagesProcessed.Name = "lblMessagesProcessed"
        Me.lblMessagesProcessed.Size = New System.Drawing.Size(15, 16)
        Me.lblMessagesProcessed.TabIndex = 9
        Me.lblMessagesProcessed.Text = "0"
        Me.lblMessagesProcessed.Visible = False
        '
        'lblMessagesProcessedCaption
        '
        Me.lblMessagesProcessedCaption.AutoSize = True
        Me.lblMessagesProcessedCaption.BackColor = System.Drawing.Color.Transparent
        Me.lblMessagesProcessedCaption.Location = New System.Drawing.Point(12, 345)
        Me.lblMessagesProcessedCaption.Name = "lblMessagesProcessedCaption"
        Me.lblMessagesProcessedCaption.Size = New System.Drawing.Size(140, 16)
        Me.lblMessagesProcessedCaption.TabIndex = 8
        Me.lblMessagesProcessedCaption.Text = "Messages processed: "
        Me.lblMessagesProcessedCaption.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(16, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(577, 18)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Please select the where you would like to store your exported messages."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnBrowseForData
        '
        Me.btnBrowseForData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseForData.Location = New System.Drawing.Point(531, 77)
        Me.btnBrowseForData.Name = "btnBrowseForData"
        Me.btnBrowseForData.Size = New System.Drawing.Size(30, 23)
        Me.btnBrowseForData.TabIndex = 5
        Me.btnBrowseForData.Text = "..."
        Me.btnBrowseForData.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(18, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Path to store exported messages:"
        '
        'txtDataPath
        '
        Me.txtDataPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDataPath.Location = New System.Drawing.Point(227, 77)
        Me.txtDataPath.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDataPath.Name = "txtDataPath"
        Me.txtDataPath.Size = New System.Drawing.Size(302, 22)
        Me.txtDataPath.TabIndex = 3
        '
        'btnImport
        '
        Me.btnImport.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnImport.Location = New System.Drawing.Point(327, 370)
        Me.btnImport.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(94, 36)
        Me.btnImport.TabIndex = 2
        Me.btnImport.Text = "&Export"
        Me.btnImport.UseVisualStyleBackColor = True
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
        Me.KryptonPanel.Controls.Add(Me.txtDataPath)
        Me.KryptonPanel.Controls.Add(Me.ProgressBar1)
        Me.KryptonPanel.Controls.Add(Me.GroupBox1)
        Me.KryptonPanel.Controls.Add(Me.btnBrowseForData)
        Me.KryptonPanel.Controls.Add(Me.pbFilename)
        Me.KryptonPanel.Controls.Add(Me.lblMessagesExported)
        Me.KryptonPanel.Controls.Add(Me.pbIncludeSubFolders)
        Me.KryptonPanel.Controls.Add(Me.btnImport)
        Me.KryptonPanel.Controls.Add(Me.pbSelectFolder)
        Me.KryptonPanel.Controls.Add(Me.llblChangePage)
        Me.KryptonPanel.Controls.Add(Me.pbExportPath)
        Me.KryptonPanel.Controls.Add(Me.lblMessagesExportedCaption)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.lblMessagesProcessedCaption)
        Me.KryptonPanel.Controls.Add(Me.lblMessagesProcessed)
        Me.KryptonPanel.Controls.Add(Me.Label2)
        Me.KryptonPanel.Controls.Add(Me.Label6)
        Me.KryptonPanel.Controls.Add(Me.Label1)
        Me.KryptonPanel.Controls.Add(Me.pnlFilenameMethod)
        Me.KryptonPanel.Controls.Add(Me.Label4)
        Me.KryptonPanel.Controls.Add(Me.chkIncludeSubFolders)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(607, 419)
        Me.KryptonPanel.TabIndex = 55
        '
        'ExportMessages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(607, 419)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ExportMessages"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export Messages"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbIncludeEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbIncludeTrulyMail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbFilename, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbIncludeSubFolders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSelectFolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbExportPath, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFilenameMethod.ResumeLayout(False)
        Me.pnlFilenameMethod.PerformLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblMessagesProcessed As System.Windows.Forms.Label
    Friend WithEvents lblMessagesProcessedCaption As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBrowseForData As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDataPath As System.Windows.Forms.TextBox
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents chkIncludeSubFolders As System.Windows.Forms.CheckBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlFilenameMethod As System.Windows.Forms.Panel
    Friend WithEvents rbtnFilenameSubject As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnFilenameGUID As System.Windows.Forms.RadioButton
    Friend WithEvents chkIncludeTrulyMailMessages As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncludeEmail As System.Windows.Forms.CheckBox
    Friend WithEvents txtTrulyMailEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents pbIncludeTrulyMail As System.Windows.Forms.PictureBox
    Friend WithEvents pbIncludeEmail As System.Windows.Forms.PictureBox
    Friend WithEvents pbFilename As System.Windows.Forms.PictureBox
    Friend WithEvents pbIncludeSubFolders As System.Windows.Forms.PictureBox
    Friend WithEvents pbSelectFolder As System.Windows.Forms.PictureBox
    Friend WithEvents pbExportPath As System.Windows.Forms.PictureBox
    Friend WithEvents llblChangePage As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As MontgomerySoftware.Controls.ProgressBar
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkIncludeAllRecipients As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMessagesExported As System.Windows.Forms.Label
    Friend WithEvents lblMessagesExportedCaption As System.Windows.Forms.Label
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
End Class
