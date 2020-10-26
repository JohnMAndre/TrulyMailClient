<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportAddressBook
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportAddressBook))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFileToImport = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.chkFirstRowHeaders = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkSkipFullName = New System.Windows.Forms.CheckBox()
        Me.chkSkipEmailAddress = New System.Windows.Forms.CheckBox()
        Me.chkSkipRemoteImages = New System.Windows.Forms.CheckBox()
        Me.chkSkipReceiveOnly = New System.Windows.Forms.CheckBox()
        Me.nudFullName = New System.Windows.Forms.NumericUpDown()
        Me.nudEmailAddress = New System.Windows.Forms.NumericUpDown()
        Me.nudRemoteImages = New System.Windows.Forms.NumericUpDown()
        Me.nudReceiveOnly = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.olvAddressBook = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn5 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn6 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn7 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn19 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn20 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn21 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn22 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn8 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn9 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn10 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn11 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn12 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn13 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn14 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn15 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn16 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn17 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn18 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudBlocked = New System.Windows.Forms.NumericUpDown()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.chkSkipBlocked = New System.Windows.Forms.CheckBox()
        Me.nudRemindReceiveEveryXDays = New System.Windows.Forms.NumericUpDown()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.chkSkipRemindReceiveEveryXDays = New System.Windows.Forms.CheckBox()
        Me.nudImportanceRating = New System.Windows.Forms.NumericUpDown()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.chkSkipImportanceRating = New System.Windows.Forms.CheckBox()
        Me.nudWebMailPassword = New System.Windows.Forms.NumericUpDown()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.chkSkipWebMailPassword = New System.Windows.Forms.CheckBox()
        Me.nudWebMailQuestion = New System.Windows.Forms.NumericUpDown()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.chkSkipWebMailQuestion = New System.Windows.Forms.CheckBox()
        Me.nudNotes = New System.Windows.Forms.NumericUpDown()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.chkSkipNotes = New System.Windows.Forms.CheckBox()
        Me.nudCustom4 = New System.Windows.Forms.NumericUpDown()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chkSkipCustom4 = New System.Windows.Forms.CheckBox()
        Me.nudCustom3 = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.chkSkipCustom3 = New System.Windows.Forms.CheckBox()
        Me.nudCustom2 = New System.Windows.Forms.NumericUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chkSkipCustom2 = New System.Windows.Forms.CheckBox()
        Me.nudCustom1 = New System.Windows.Forms.NumericUpDown()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chkSkipCustom1 = New System.Windows.Forms.CheckBox()
        Me.nudWebPage = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkSkipWebPage = New System.Windows.Forms.CheckBox()
        Me.nudMobile = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkSkipMobile = New System.Windows.Forms.CheckBox()
        Me.nudWork = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkSkipWork = New System.Windows.Forms.CheckBox()
        Me.nudHome = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkSkipHome = New System.Windows.Forms.CheckBox()
        Me.nudTags = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkSkipTags = New System.Windows.Forms.CheckBox()
        Me.nudSendReceipt = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkSkipSendReceipt = New System.Windows.Forms.CheckBox()
        Me.nudReqReceipt = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkSkipReqReceipt = New System.Windows.Forms.CheckBox()
        Me.nudRemindSendEveryXDays = New System.Windows.Forms.NumericUpDown()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.chkSkipRemindSendEveryXDays = New System.Windows.Forms.CheckBox()
        Me.rbtnCSV = New System.Windows.Forms.RadioButton()
        Me.grpTextFormat = New System.Windows.Forms.GroupBox()
        Me.rbtnTAB = New System.Windows.Forms.RadioButton()
        Me.lblError = New System.Windows.Forms.Label()
        Me.lblRawDataCaption = New System.Windows.Forms.Label()
        Me.txtRawData = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblImportProgress = New System.Windows.Forms.Label()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        CType(Me.nudFullName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudEmailAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRemoteImages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudReceiveOnly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.olvAddressBook, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudBlocked, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRemindReceiveEveryXDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudImportanceRating, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudWebMailPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudWebMailQuestion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCustom4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCustom3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCustom2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCustom1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudWebPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMobile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudWork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHome, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSendReceipt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudReqReceipt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRemindSendEveryXDays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTextFormat.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(877, 91)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'txtFileToImport
        '
        Me.txtFileToImport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileToImport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileToImport.Location = New System.Drawing.Point(106, 120)
        Me.txtFileToImport.Name = "txtFileToImport"
        Me.txtFileToImport.Size = New System.Drawing.Size(712, 22)
        Me.txtFileToImport.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "File to import:"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.BackColor = System.Drawing.Color.Transparent
        Me.btnBrowse.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(819, 118)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(73, 23)
        Me.btnBrowse.TabIndex = 3
        Me.btnBrowse.Text = "&Browse"
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'btnImport
        '
        Me.btnImport.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnImport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImport.Location = New System.Drawing.Point(408, 556)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(85, 29)
        Me.btnImport.TabIndex = 4
        Me.btnImport.Text = "&Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'chkFirstRowHeaders
        '
        Me.chkFirstRowHeaders.AutoSize = True
        Me.chkFirstRowHeaders.Checked = True
        Me.chkFirstRowHeaders.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFirstRowHeaders.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFirstRowHeaders.Location = New System.Drawing.Point(112, 17)
        Me.chkFirstRowHeaders.Name = "chkFirstRowHeaders"
        Me.chkFirstRowHeaders.Size = New System.Drawing.Size(145, 20)
        Me.chkFirstRowHeaders.TabIndex = 5
        Me.chkFirstRowHeaders.Text = "Skip first row of data"
        Me.chkFirstRowHeaders.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Full name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Email address:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Remote images:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 16)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Receive only:"
        '
        'chkSkipFullName
        '
        Me.chkSkipFullName.AutoSize = True
        Me.chkSkipFullName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipFullName.Location = New System.Drawing.Point(179, 66)
        Me.chkSkipFullName.Name = "chkSkipFullName"
        Me.chkSkipFullName.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipFullName.TabIndex = 10
        Me.chkSkipFullName.Text = "Skip"
        Me.chkSkipFullName.UseVisualStyleBackColor = True
        '
        'chkSkipEmailAddress
        '
        Me.chkSkipEmailAddress.AutoSize = True
        Me.chkSkipEmailAddress.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipEmailAddress.Location = New System.Drawing.Point(179, 86)
        Me.chkSkipEmailAddress.Name = "chkSkipEmailAddress"
        Me.chkSkipEmailAddress.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipEmailAddress.TabIndex = 11
        Me.chkSkipEmailAddress.Text = "Skip"
        Me.chkSkipEmailAddress.UseVisualStyleBackColor = True
        Me.chkSkipEmailAddress.Visible = False
        '
        'chkSkipRemoteImages
        '
        Me.chkSkipRemoteImages.AutoSize = True
        Me.chkSkipRemoteImages.Checked = True
        Me.chkSkipRemoteImages.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipRemoteImages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipRemoteImages.Location = New System.Drawing.Point(179, 107)
        Me.chkSkipRemoteImages.Name = "chkSkipRemoteImages"
        Me.chkSkipRemoteImages.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipRemoteImages.TabIndex = 12
        Me.chkSkipRemoteImages.Text = "Skip"
        Me.chkSkipRemoteImages.UseVisualStyleBackColor = True
        '
        'chkSkipReceiveOnly
        '
        Me.chkSkipReceiveOnly.AutoSize = True
        Me.chkSkipReceiveOnly.Checked = True
        Me.chkSkipReceiveOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipReceiveOnly.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipReceiveOnly.Location = New System.Drawing.Point(179, 128)
        Me.chkSkipReceiveOnly.Name = "chkSkipReceiveOnly"
        Me.chkSkipReceiveOnly.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipReceiveOnly.TabIndex = 13
        Me.chkSkipReceiveOnly.Text = "Skip"
        Me.chkSkipReceiveOnly.UseVisualStyleBackColor = True
        '
        'nudFullName
        '
        Me.nudFullName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudFullName.Location = New System.Drawing.Point(112, 64)
        Me.nudFullName.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudFullName.Name = "nudFullName"
        Me.nudFullName.Size = New System.Drawing.Size(60, 22)
        Me.nudFullName.TabIndex = 14
        Me.nudFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudFullName.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudEmailAddress
        '
        Me.nudEmailAddress.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudEmailAddress.Location = New System.Drawing.Point(112, 85)
        Me.nudEmailAddress.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudEmailAddress.Name = "nudEmailAddress"
        Me.nudEmailAddress.Size = New System.Drawing.Size(60, 22)
        Me.nudEmailAddress.TabIndex = 15
        Me.nudEmailAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudEmailAddress.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'nudRemoteImages
        '
        Me.nudRemoteImages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudRemoteImages.Location = New System.Drawing.Point(112, 106)
        Me.nudRemoteImages.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudRemoteImages.Name = "nudRemoteImages"
        Me.nudRemoteImages.Size = New System.Drawing.Size(60, 22)
        Me.nudRemoteImages.TabIndex = 16
        Me.nudRemoteImages.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudRemoteImages.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'nudReceiveOnly
        '
        Me.nudReceiveOnly.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudReceiveOnly.Location = New System.Drawing.Point(112, 127)
        Me.nudReceiveOnly.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudReceiveOnly.Name = "nudReceiveOnly"
        Me.nudReceiveOnly.Size = New System.Drawing.Size(60, 22)
        Me.nudReceiveOnly.TabIndex = 17
        Me.nudReceiveOnly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudReceiveOnly.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(109, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 16)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Column"
        '
        'olvAddressBook
        '
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn1)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn2)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn3)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn4)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn5)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn6)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn7)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn19)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn20)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn21)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn22)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn8)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn9)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn10)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn11)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn12)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn13)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn14)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn15)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn16)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn17)
        Me.olvAddressBook.AllColumns.Add(Me.OlvColumn18)
        Me.olvAddressBook.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvAddressBook.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.olvAddressBook.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1, Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn5, Me.OlvColumn6, Me.OlvColumn7, Me.OlvColumn19, Me.OlvColumn20, Me.OlvColumn21, Me.OlvColumn22, Me.OlvColumn8, Me.OlvColumn9, Me.OlvColumn10, Me.OlvColumn11, Me.OlvColumn12, Me.OlvColumn13, Me.OlvColumn14, Me.OlvColumn15, Me.OlvColumn16, Me.OlvColumn17, Me.OlvColumn18})
        Me.olvAddressBook.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.olvAddressBook.EmptyListMsg = "There are no contacts"
        Me.olvAddressBook.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!)
        Me.olvAddressBook.FullRowSelect = True
        Me.olvAddressBook.GridLines = True
        Me.olvAddressBook.HideSelection = False
        Me.olvAddressBook.LabelWrap = False
        Me.olvAddressBook.Location = New System.Drawing.Point(6, 80)
        Me.olvAddressBook.Name = "olvAddressBook"
        Me.olvAddressBook.OwnerDraw = True
        Me.olvAddressBook.SelectColumnsMenuStaysOpen = False
        Me.olvAddressBook.SelectColumnsOnRightClick = False
        Me.olvAddressBook.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvAddressBook.ShowGroups = False
        Me.olvAddressBook.ShowImagesOnSubItems = True
        Me.olvAddressBook.Size = New System.Drawing.Size(376, 192)
        Me.olvAddressBook.TabIndex = 19
        Me.olvAddressBook.UseAlternatingBackColors = True
        Me.olvAddressBook.UseCompatibleStateImageBehavior = False
        Me.olvAddressBook.UseSubItemCheckBoxes = True
        Me.olvAddressBook.View = System.Windows.Forms.View.Details
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "FullName"
        Me.OlvColumn1.IsEditable = False
        Me.OlvColumn1.Text = "Name"
        Me.OlvColumn1.Width = 77
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "Address"
        Me.OlvColumn2.IsEditable = False
        Me.OlvColumn2.Text = "Address"
        Me.OlvColumn2.Width = 114
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "RemoteImages"
        Me.OlvColumn3.CheckBoxes = True
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsEditable = False
        Me.OlvColumn3.Text = "Remote Images"
        Me.OlvColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.Width = 88
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "ReceiveOnly"
        Me.OlvColumn4.CheckBoxes = True
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.IsEditable = False
        Me.OlvColumn4.Text = "Receive Only"
        Me.OlvColumn4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.Width = 79
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "AutoRequestReadReceipt"
        Me.OlvColumn5.CheckBoxes = True
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.IsEditable = False
        Me.OlvColumn5.Text = "Req Receipt"
        Me.OlvColumn5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.Width = 73
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "AutoSendReadReceipt"
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.IsEditable = False
        Me.OlvColumn6.Text = "Send Receipt"
        Me.OlvColumn6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.Width = 141
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "Tags"
        Me.OlvColumn7.IsEditable = False
        Me.OlvColumn7.Text = "Tags"
        '
        'OlvColumn19
        '
        Me.OlvColumn19.AspectName = "ImportanceRating"
        Me.OlvColumn19.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn19.IsEditable = False
        Me.OlvColumn19.Text = "Importance"
        Me.OlvColumn19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OlvColumn20
        '
        Me.OlvColumn20.AspectName = "RemindReceiveEveryXDays"
        Me.OlvColumn20.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn20.IsEditable = False
        Me.OlvColumn20.Text = "Remind receive every x days"
        Me.OlvColumn20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OlvColumn21
        '
        Me.OlvColumn21.AspectName = "RemindSendEveryXDays"
        Me.OlvColumn21.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn21.IsEditable = False
        Me.OlvColumn21.Text = "Remind send every x days"
        Me.OlvColumn21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OlvColumn22
        '
        Me.OlvColumn22.AspectName = "Blocked"
        Me.OlvColumn22.CheckBoxes = True
        Me.OlvColumn22.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn22.IsEditable = False
        Me.OlvColumn22.Text = "Blocked"
        Me.OlvColumn22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "PhoneHome"
        Me.OlvColumn8.IsEditable = False
        Me.OlvColumn8.Text = "Home"
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "PhoneWork"
        Me.OlvColumn9.IsEditable = False
        Me.OlvColumn9.Text = "Work"
        '
        'OlvColumn10
        '
        Me.OlvColumn10.AspectName = "PhoneMobile"
        Me.OlvColumn10.IsEditable = False
        Me.OlvColumn10.Text = "Mobile"
        Me.OlvColumn10.ToolTipText = ""
        '
        'OlvColumn11
        '
        Me.OlvColumn11.AspectName = "WebPage"
        Me.OlvColumn11.IsEditable = False
        Me.OlvColumn11.Text = "WebPage"
        '
        'OlvColumn12
        '
        Me.OlvColumn12.AspectName = "Custom1"
        Me.OlvColumn12.IsEditable = False
        Me.OlvColumn12.Text = "Custom1"
        '
        'OlvColumn13
        '
        Me.OlvColumn13.AspectName = "Custom2"
        Me.OlvColumn13.IsEditable = False
        Me.OlvColumn13.Text = "Custom2"
        '
        'OlvColumn14
        '
        Me.OlvColumn14.AspectName = "Custom3"
        Me.OlvColumn14.IsEditable = False
        Me.OlvColumn14.Text = "Custom3"
        '
        'OlvColumn15
        '
        Me.OlvColumn15.AspectName = "Custom4"
        Me.OlvColumn15.IsEditable = False
        Me.OlvColumn15.Text = "Custom4"
        '
        'OlvColumn16
        '
        Me.OlvColumn16.AspectName = "Notes"
        Me.OlvColumn16.IsEditable = False
        Me.OlvColumn16.Text = "Notes"
        '
        'OlvColumn17
        '
        Me.OlvColumn17.AspectName = "WebMailQuestion"
        Me.OlvColumn17.IsEditable = False
        Me.OlvColumn17.Text = "Web Question"
        '
        'OlvColumn18
        '
        Me.OlvColumn18.AspectName = "WebMailPassword"
        Me.OlvColumn18.IsEditable = False
        Me.OlvColumn18.Text = "Web Password"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 16)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Sample data from file"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.nudBlocked)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.chkSkipBlocked)
        Me.GroupBox1.Controls.Add(Me.nudRemindReceiveEveryXDays)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.chkSkipRemindReceiveEveryXDays)
        Me.GroupBox1.Controls.Add(Me.nudImportanceRating)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.chkSkipImportanceRating)
        Me.GroupBox1.Controls.Add(Me.nudWebMailPassword)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.chkSkipWebMailPassword)
        Me.GroupBox1.Controls.Add(Me.nudWebMailQuestion)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.chkSkipWebMailQuestion)
        Me.GroupBox1.Controls.Add(Me.nudNotes)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.chkSkipNotes)
        Me.GroupBox1.Controls.Add(Me.nudCustom4)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.chkSkipCustom4)
        Me.GroupBox1.Controls.Add(Me.nudCustom3)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.chkSkipCustom3)
        Me.GroupBox1.Controls.Add(Me.nudCustom2)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.chkSkipCustom2)
        Me.GroupBox1.Controls.Add(Me.nudCustom1)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.chkSkipCustom1)
        Me.GroupBox1.Controls.Add(Me.nudWebPage)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.chkSkipWebPage)
        Me.GroupBox1.Controls.Add(Me.nudMobile)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.chkSkipMobile)
        Me.GroupBox1.Controls.Add(Me.nudWork)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.chkSkipWork)
        Me.GroupBox1.Controls.Add(Me.nudHome)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.chkSkipHome)
        Me.GroupBox1.Controls.Add(Me.nudTags)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.chkSkipTags)
        Me.GroupBox1.Controls.Add(Me.nudSendReceipt)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.chkSkipSendReceipt)
        Me.GroupBox1.Controls.Add(Me.nudReqReceipt)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.chkSkipReqReceipt)
        Me.GroupBox1.Controls.Add(Me.nudReceiveOnly)
        Me.GroupBox1.Controls.Add(Me.nudRemoteImages)
        Me.GroupBox1.Controls.Add(Me.nudEmailAddress)
        Me.GroupBox1.Controls.Add(Me.nudFullName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkFirstRowHeaders)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.chkSkipFullName)
        Me.GroupBox1.Controls.Add(Me.chkSkipEmailAddress)
        Me.GroupBox1.Controls.Add(Me.chkSkipRemoteImages)
        Me.GroupBox1.Controls.Add(Me.chkSkipReceiveOnly)
        Me.GroupBox1.Controls.Add(Me.nudRemindSendEveryXDays)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.chkSkipRemindSendEveryXDays)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 219)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(483, 331)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options"
        '
        'nudBlocked
        '
        Me.nudBlocked.Enabled = False
        Me.nudBlocked.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudBlocked.Location = New System.Drawing.Point(112, 274)
        Me.nudBlocked.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudBlocked.Name = "nudBlocked"
        Me.nudBlocked.Size = New System.Drawing.Size(60, 22)
        Me.nudBlocked.TabIndex = 72
        Me.nudBlocked.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudBlocked.Value = New Decimal(New Integer() {11, 0, 0, 0})
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(10, 276)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(59, 16)
        Me.Label23.TabIndex = 70
        Me.Label23.Text = "Blocked:"
        '
        'chkSkipBlocked
        '
        Me.chkSkipBlocked.AutoSize = True
        Me.chkSkipBlocked.Checked = True
        Me.chkSkipBlocked.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipBlocked.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipBlocked.Location = New System.Drawing.Point(179, 275)
        Me.chkSkipBlocked.Name = "chkSkipBlocked"
        Me.chkSkipBlocked.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipBlocked.TabIndex = 71
        Me.chkSkipBlocked.Text = "Skip"
        Me.chkSkipBlocked.UseVisualStyleBackColor = True
        '
        'nudRemindReceiveEveryXDays
        '
        Me.nudRemindReceiveEveryXDays.Enabled = False
        Me.nudRemindReceiveEveryXDays.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudRemindReceiveEveryXDays.Location = New System.Drawing.Point(112, 253)
        Me.nudRemindReceiveEveryXDays.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudRemindReceiveEveryXDays.Name = "nudRemindReceiveEveryXDays"
        Me.nudRemindReceiveEveryXDays.Size = New System.Drawing.Size(60, 22)
        Me.nudRemindReceiveEveryXDays.TabIndex = 66
        Me.nudRemindReceiveEveryXDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudRemindReceiveEveryXDays.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(10, 255)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(88, 16)
        Me.Label25.TabIndex = 64
        Me.Label25.Text = "Remind send:"
        '
        'chkSkipRemindReceiveEveryXDays
        '
        Me.chkSkipRemindReceiveEveryXDays.AutoSize = True
        Me.chkSkipRemindReceiveEveryXDays.Checked = True
        Me.chkSkipRemindReceiveEveryXDays.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipRemindReceiveEveryXDays.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipRemindReceiveEveryXDays.Location = New System.Drawing.Point(179, 254)
        Me.chkSkipRemindReceiveEveryXDays.Name = "chkSkipRemindReceiveEveryXDays"
        Me.chkSkipRemindReceiveEveryXDays.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipRemindReceiveEveryXDays.TabIndex = 65
        Me.chkSkipRemindReceiveEveryXDays.Text = "Skip"
        Me.chkSkipRemindReceiveEveryXDays.UseVisualStyleBackColor = True
        '
        'nudImportanceRating
        '
        Me.nudImportanceRating.Enabled = False
        Me.nudImportanceRating.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudImportanceRating.Location = New System.Drawing.Point(112, 211)
        Me.nudImportanceRating.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudImportanceRating.Name = "nudImportanceRating"
        Me.nudImportanceRating.Size = New System.Drawing.Size(60, 22)
        Me.nudImportanceRating.TabIndex = 63
        Me.nudImportanceRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudImportanceRating.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(10, 213)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(76, 16)
        Me.Label26.TabIndex = 61
        Me.Label26.Text = "Importance:"
        '
        'chkSkipImportanceRating
        '
        Me.chkSkipImportanceRating.AutoSize = True
        Me.chkSkipImportanceRating.Checked = True
        Me.chkSkipImportanceRating.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipImportanceRating.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipImportanceRating.Location = New System.Drawing.Point(179, 212)
        Me.chkSkipImportanceRating.Name = "chkSkipImportanceRating"
        Me.chkSkipImportanceRating.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipImportanceRating.TabIndex = 62
        Me.chkSkipImportanceRating.Text = "Skip"
        Me.chkSkipImportanceRating.UseVisualStyleBackColor = True
        '
        'nudWebMailPassword
        '
        Me.nudWebMailPassword.Enabled = False
        Me.nudWebMailPassword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudWebMailPassword.Location = New System.Drawing.Point(356, 275)
        Me.nudWebMailPassword.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudWebMailPassword.Name = "nudWebMailPassword"
        Me.nudWebMailPassword.Size = New System.Drawing.Size(60, 22)
        Me.nudWebMailPassword.TabIndex = 60
        Me.nudWebMailPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudWebMailPassword.Value = New Decimal(New Integer() {22, 0, 0, 0})
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(254, 277)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 16)
        Me.Label22.TabIndex = 58
        Me.Label22.Text = "Web password:"
        '
        'chkSkipWebMailPassword
        '
        Me.chkSkipWebMailPassword.AutoSize = True
        Me.chkSkipWebMailPassword.Checked = True
        Me.chkSkipWebMailPassword.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipWebMailPassword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipWebMailPassword.Location = New System.Drawing.Point(423, 276)
        Me.chkSkipWebMailPassword.Name = "chkSkipWebMailPassword"
        Me.chkSkipWebMailPassword.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipWebMailPassword.TabIndex = 59
        Me.chkSkipWebMailPassword.Text = "Skip"
        Me.chkSkipWebMailPassword.UseVisualStyleBackColor = True
        '
        'nudWebMailQuestion
        '
        Me.nudWebMailQuestion.Enabled = False
        Me.nudWebMailQuestion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudWebMailQuestion.Location = New System.Drawing.Point(356, 254)
        Me.nudWebMailQuestion.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudWebMailQuestion.Name = "nudWebMailQuestion"
        Me.nudWebMailQuestion.Size = New System.Drawing.Size(60, 22)
        Me.nudWebMailQuestion.TabIndex = 57
        Me.nudWebMailQuestion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudWebMailQuestion.Value = New Decimal(New Integer() {21, 0, 0, 0})
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(254, 256)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(92, 16)
        Me.Label21.TabIndex = 55
        Me.Label21.Text = "Web question:"
        '
        'chkSkipWebMailQuestion
        '
        Me.chkSkipWebMailQuestion.AutoSize = True
        Me.chkSkipWebMailQuestion.Checked = True
        Me.chkSkipWebMailQuestion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipWebMailQuestion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipWebMailQuestion.Location = New System.Drawing.Point(423, 255)
        Me.chkSkipWebMailQuestion.Name = "chkSkipWebMailQuestion"
        Me.chkSkipWebMailQuestion.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipWebMailQuestion.TabIndex = 56
        Me.chkSkipWebMailQuestion.Text = "Skip"
        Me.chkSkipWebMailQuestion.UseVisualStyleBackColor = True
        '
        'nudNotes
        '
        Me.nudNotes.Enabled = False
        Me.nudNotes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudNotes.Location = New System.Drawing.Point(356, 233)
        Me.nudNotes.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNotes.Name = "nudNotes"
        Me.nudNotes.Size = New System.Drawing.Size(60, 22)
        Me.nudNotes.TabIndex = 54
        Me.nudNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudNotes.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(254, 235)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(46, 16)
        Me.Label20.TabIndex = 52
        Me.Label20.Text = "Notes:"
        '
        'chkSkipNotes
        '
        Me.chkSkipNotes.AutoSize = True
        Me.chkSkipNotes.Checked = True
        Me.chkSkipNotes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipNotes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipNotes.Location = New System.Drawing.Point(423, 234)
        Me.chkSkipNotes.Name = "chkSkipNotes"
        Me.chkSkipNotes.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipNotes.TabIndex = 53
        Me.chkSkipNotes.Text = "Skip"
        Me.chkSkipNotes.UseVisualStyleBackColor = True
        '
        'nudCustom4
        '
        Me.nudCustom4.Enabled = False
        Me.nudCustom4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudCustom4.Location = New System.Drawing.Point(356, 212)
        Me.nudCustom4.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCustom4.Name = "nudCustom4"
        Me.nudCustom4.Size = New System.Drawing.Size(60, 22)
        Me.nudCustom4.TabIndex = 51
        Me.nudCustom4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudCustom4.Value = New Decimal(New Integer() {19, 0, 0, 0})
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(254, 214)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 16)
        Me.Label19.TabIndex = 49
        Me.Label19.Text = "Custom 4:"
        '
        'chkSkipCustom4
        '
        Me.chkSkipCustom4.AutoSize = True
        Me.chkSkipCustom4.Checked = True
        Me.chkSkipCustom4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipCustom4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipCustom4.Location = New System.Drawing.Point(423, 213)
        Me.chkSkipCustom4.Name = "chkSkipCustom4"
        Me.chkSkipCustom4.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipCustom4.TabIndex = 50
        Me.chkSkipCustom4.Text = "Skip"
        Me.chkSkipCustom4.UseVisualStyleBackColor = True
        '
        'nudCustom3
        '
        Me.nudCustom3.Enabled = False
        Me.nudCustom3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudCustom3.Location = New System.Drawing.Point(356, 191)
        Me.nudCustom3.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCustom3.Name = "nudCustom3"
        Me.nudCustom3.Size = New System.Drawing.Size(60, 22)
        Me.nudCustom3.TabIndex = 48
        Me.nudCustom3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudCustom3.Value = New Decimal(New Integer() {18, 0, 0, 0})
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(254, 193)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 16)
        Me.Label18.TabIndex = 46
        Me.Label18.Text = "Custom 3:"
        '
        'chkSkipCustom3
        '
        Me.chkSkipCustom3.AutoSize = True
        Me.chkSkipCustom3.Checked = True
        Me.chkSkipCustom3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipCustom3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipCustom3.Location = New System.Drawing.Point(423, 192)
        Me.chkSkipCustom3.Name = "chkSkipCustom3"
        Me.chkSkipCustom3.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipCustom3.TabIndex = 47
        Me.chkSkipCustom3.Text = "Skip"
        Me.chkSkipCustom3.UseVisualStyleBackColor = True
        '
        'nudCustom2
        '
        Me.nudCustom2.Enabled = False
        Me.nudCustom2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudCustom2.Location = New System.Drawing.Point(356, 170)
        Me.nudCustom2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCustom2.Name = "nudCustom2"
        Me.nudCustom2.Size = New System.Drawing.Size(60, 22)
        Me.nudCustom2.TabIndex = 45
        Me.nudCustom2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudCustom2.Value = New Decimal(New Integer() {17, 0, 0, 0})
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(254, 172)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 16)
        Me.Label17.TabIndex = 43
        Me.Label17.Text = "Custom 2:"
        '
        'chkSkipCustom2
        '
        Me.chkSkipCustom2.AutoSize = True
        Me.chkSkipCustom2.Checked = True
        Me.chkSkipCustom2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipCustom2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipCustom2.Location = New System.Drawing.Point(423, 171)
        Me.chkSkipCustom2.Name = "chkSkipCustom2"
        Me.chkSkipCustom2.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipCustom2.TabIndex = 44
        Me.chkSkipCustom2.Text = "Skip"
        Me.chkSkipCustom2.UseVisualStyleBackColor = True
        '
        'nudCustom1
        '
        Me.nudCustom1.Enabled = False
        Me.nudCustom1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudCustom1.Location = New System.Drawing.Point(356, 149)
        Me.nudCustom1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCustom1.Name = "nudCustom1"
        Me.nudCustom1.Size = New System.Drawing.Size(60, 22)
        Me.nudCustom1.TabIndex = 42
        Me.nudCustom1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudCustom1.Value = New Decimal(New Integer() {16, 0, 0, 0})
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(254, 151)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 16)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "Custom 1:"
        '
        'chkSkipCustom1
        '
        Me.chkSkipCustom1.AutoSize = True
        Me.chkSkipCustom1.Checked = True
        Me.chkSkipCustom1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipCustom1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipCustom1.Location = New System.Drawing.Point(423, 150)
        Me.chkSkipCustom1.Name = "chkSkipCustom1"
        Me.chkSkipCustom1.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipCustom1.TabIndex = 41
        Me.chkSkipCustom1.Text = "Skip"
        Me.chkSkipCustom1.UseVisualStyleBackColor = True
        '
        'nudWebPage
        '
        Me.nudWebPage.Enabled = False
        Me.nudWebPage.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudWebPage.Location = New System.Drawing.Point(356, 128)
        Me.nudWebPage.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudWebPage.Name = "nudWebPage"
        Me.nudWebPage.Size = New System.Drawing.Size(60, 22)
        Me.nudWebPage.TabIndex = 39
        Me.nudWebPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudWebPage.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(254, 130)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 16)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Web page:"
        '
        'chkSkipWebPage
        '
        Me.chkSkipWebPage.AutoSize = True
        Me.chkSkipWebPage.Checked = True
        Me.chkSkipWebPage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipWebPage.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipWebPage.Location = New System.Drawing.Point(423, 129)
        Me.chkSkipWebPage.Name = "chkSkipWebPage"
        Me.chkSkipWebPage.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipWebPage.TabIndex = 38
        Me.chkSkipWebPage.Text = "Skip"
        Me.chkSkipWebPage.UseVisualStyleBackColor = True
        '
        'nudMobile
        '
        Me.nudMobile.Enabled = False
        Me.nudMobile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudMobile.Location = New System.Drawing.Point(356, 107)
        Me.nudMobile.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudMobile.Name = "nudMobile"
        Me.nudMobile.Size = New System.Drawing.Size(60, 22)
        Me.nudMobile.TabIndex = 36
        Me.nudMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudMobile.Value = New Decimal(New Integer() {14, 0, 0, 0})
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(254, 109)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 16)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Mobile:"
        '
        'chkSkipMobile
        '
        Me.chkSkipMobile.AutoSize = True
        Me.chkSkipMobile.Checked = True
        Me.chkSkipMobile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipMobile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipMobile.Location = New System.Drawing.Point(423, 108)
        Me.chkSkipMobile.Name = "chkSkipMobile"
        Me.chkSkipMobile.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipMobile.TabIndex = 35
        Me.chkSkipMobile.Text = "Skip"
        Me.chkSkipMobile.UseVisualStyleBackColor = True
        '
        'nudWork
        '
        Me.nudWork.Enabled = False
        Me.nudWork.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudWork.Location = New System.Drawing.Point(356, 86)
        Me.nudWork.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudWork.Name = "nudWork"
        Me.nudWork.Size = New System.Drawing.Size(60, 22)
        Me.nudWork.TabIndex = 33
        Me.nudWork.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudWork.Value = New Decimal(New Integer() {13, 0, 0, 0})
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(254, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 16)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Work:"
        '
        'chkSkipWork
        '
        Me.chkSkipWork.AutoSize = True
        Me.chkSkipWork.Checked = True
        Me.chkSkipWork.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipWork.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipWork.Location = New System.Drawing.Point(423, 87)
        Me.chkSkipWork.Name = "chkSkipWork"
        Me.chkSkipWork.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipWork.TabIndex = 32
        Me.chkSkipWork.Text = "Skip"
        Me.chkSkipWork.UseVisualStyleBackColor = True
        '
        'nudHome
        '
        Me.nudHome.Enabled = False
        Me.nudHome.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudHome.Location = New System.Drawing.Point(356, 65)
        Me.nudHome.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudHome.Name = "nudHome"
        Me.nudHome.Size = New System.Drawing.Size(60, 22)
        Me.nudHome.TabIndex = 30
        Me.nudHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudHome.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(254, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 16)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Home:"
        '
        'chkSkipHome
        '
        Me.chkSkipHome.AutoSize = True
        Me.chkSkipHome.Checked = True
        Me.chkSkipHome.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipHome.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipHome.Location = New System.Drawing.Point(423, 66)
        Me.chkSkipHome.Name = "chkSkipHome"
        Me.chkSkipHome.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipHome.TabIndex = 29
        Me.chkSkipHome.Text = "Skip"
        Me.chkSkipHome.UseVisualStyleBackColor = True
        '
        'nudTags
        '
        Me.nudTags.Enabled = False
        Me.nudTags.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudTags.Location = New System.Drawing.Point(112, 190)
        Me.nudTags.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudTags.Name = "nudTags"
        Me.nudTags.Size = New System.Drawing.Size(60, 22)
        Me.nudTags.TabIndex = 27
        Me.nudTags.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudTags.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 192)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 16)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Tags:"
        '
        'chkSkipTags
        '
        Me.chkSkipTags.AutoSize = True
        Me.chkSkipTags.Checked = True
        Me.chkSkipTags.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipTags.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipTags.Location = New System.Drawing.Point(179, 191)
        Me.chkSkipTags.Name = "chkSkipTags"
        Me.chkSkipTags.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipTags.TabIndex = 26
        Me.chkSkipTags.Text = "Skip"
        Me.chkSkipTags.UseVisualStyleBackColor = True
        '
        'nudSendReceipt
        '
        Me.nudSendReceipt.Enabled = False
        Me.nudSendReceipt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudSendReceipt.Location = New System.Drawing.Point(112, 169)
        Me.nudSendReceipt.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSendReceipt.Name = "nudSendReceipt"
        Me.nudSendReceipt.Size = New System.Drawing.Size(60, 22)
        Me.nudSendReceipt.TabIndex = 24
        Me.nudSendReceipt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudSendReceipt.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 171)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 16)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Send receipt:"
        '
        'chkSkipSendReceipt
        '
        Me.chkSkipSendReceipt.AutoSize = True
        Me.chkSkipSendReceipt.Checked = True
        Me.chkSkipSendReceipt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipSendReceipt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipSendReceipt.Location = New System.Drawing.Point(179, 170)
        Me.chkSkipSendReceipt.Name = "chkSkipSendReceipt"
        Me.chkSkipSendReceipt.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipSendReceipt.TabIndex = 23
        Me.chkSkipSendReceipt.Text = "Skip"
        Me.chkSkipSendReceipt.UseVisualStyleBackColor = True
        '
        'nudReqReceipt
        '
        Me.nudReqReceipt.Enabled = False
        Me.nudReqReceipt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudReqReceipt.Location = New System.Drawing.Point(112, 148)
        Me.nudReqReceipt.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudReqReceipt.Name = "nudReqReceipt"
        Me.nudReqReceipt.Size = New System.Drawing.Size(60, 22)
        Me.nudReqReceipt.TabIndex = 21
        Me.nudReqReceipt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudReqReceipt.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 150)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 16)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Req receipt:"
        '
        'chkSkipReqReceipt
        '
        Me.chkSkipReqReceipt.AutoSize = True
        Me.chkSkipReqReceipt.Checked = True
        Me.chkSkipReqReceipt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipReqReceipt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipReqReceipt.Location = New System.Drawing.Point(179, 149)
        Me.chkSkipReqReceipt.Name = "chkSkipReqReceipt"
        Me.chkSkipReqReceipt.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipReqReceipt.TabIndex = 20
        Me.chkSkipReqReceipt.Text = "Skip"
        Me.chkSkipReqReceipt.UseVisualStyleBackColor = True
        '
        'nudRemindSendEveryXDays
        '
        Me.nudRemindSendEveryXDays.Enabled = False
        Me.nudRemindSendEveryXDays.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudRemindSendEveryXDays.Location = New System.Drawing.Point(112, 232)
        Me.nudRemindSendEveryXDays.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudRemindSendEveryXDays.Name = "nudRemindSendEveryXDays"
        Me.nudRemindSendEveryXDays.Size = New System.Drawing.Size(60, 22)
        Me.nudRemindSendEveryXDays.TabIndex = 69
        Me.nudRemindSendEveryXDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudRemindSendEveryXDays.Value = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(10, 234)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 16)
        Me.Label24.TabIndex = 67
        Me.Label24.Text = "Remind receive:"
        '
        'chkSkipRemindSendEveryXDays
        '
        Me.chkSkipRemindSendEveryXDays.AutoSize = True
        Me.chkSkipRemindSendEveryXDays.Checked = True
        Me.chkSkipRemindSendEveryXDays.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipRemindSendEveryXDays.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipRemindSendEveryXDays.Location = New System.Drawing.Point(179, 233)
        Me.chkSkipRemindSendEveryXDays.Name = "chkSkipRemindSendEveryXDays"
        Me.chkSkipRemindSendEveryXDays.Size = New System.Drawing.Size(53, 20)
        Me.chkSkipRemindSendEveryXDays.TabIndex = 68
        Me.chkSkipRemindSendEveryXDays.Text = "Skip"
        Me.chkSkipRemindSendEveryXDays.UseVisualStyleBackColor = True
        '
        'rbtnCSV
        '
        Me.rbtnCSV.AutoSize = True
        Me.rbtnCSV.Checked = True
        Me.rbtnCSV.Location = New System.Drawing.Point(15, 18)
        Me.rbtnCSV.Name = "rbtnCSV"
        Me.rbtnCSV.Size = New System.Drawing.Size(139, 17)
        Me.rbtnCSV.TabIndex = 22
        Me.rbtnCSV.TabStop = True
        Me.rbtnCSV.Text = "CSV (comma-separated)"
        Me.rbtnCSV.UseVisualStyleBackColor = True
        '
        'grpTextFormat
        '
        Me.grpTextFormat.AutoSize = True
        Me.grpTextFormat.BackColor = System.Drawing.Color.Transparent
        Me.grpTextFormat.Controls.Add(Me.rbtnTAB)
        Me.grpTextFormat.Controls.Add(Me.rbtnCSV)
        Me.grpTextFormat.Location = New System.Drawing.Point(12, 162)
        Me.grpTextFormat.Name = "grpTextFormat"
        Me.grpTextFormat.Size = New System.Drawing.Size(481, 55)
        Me.grpTextFormat.TabIndex = 23
        Me.grpTextFormat.TabStop = False
        Me.grpTextFormat.Text = "Data Format"
        '
        'rbtnTAB
        '
        Me.rbtnTAB.AutoSize = True
        Me.rbtnTAB.Location = New System.Drawing.Point(160, 19)
        Me.rbtnTAB.Name = "rbtnTAB"
        Me.rbtnTAB.Size = New System.Drawing.Size(120, 17)
        Me.rbtnTAB.TabIndex = 23
        Me.rbtnTAB.Text = "TAB (tab-separated)"
        Me.rbtnTAB.UseVisualStyleBackColor = True
        '
        'lblError
        '
        Me.lblError.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblError.BackColor = System.Drawing.Color.Transparent
        Me.lblError.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblError.Location = New System.Drawing.Point(6, 16)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(376, 46)
        Me.lblError.TabIndex = 24
        Me.lblError.Text = "Warning: There are 9 bad records in the first 10. You should correct this error b" & _
    "efore importing."
        Me.lblError.Visible = False
        '
        'lblRawDataCaption
        '
        Me.lblRawDataCaption.AutoSize = True
        Me.lblRawDataCaption.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRawDataCaption.Location = New System.Drawing.Point(13, 289)
        Me.lblRawDataCaption.Name = "lblRawDataCaption"
        Me.lblRawDataCaption.Size = New System.Drawing.Size(83, 16)
        Me.lblRawDataCaption.TabIndex = 26
        Me.lblRawDataCaption.Text = "File contents"
        '
        'txtRawData
        '
        Me.txtRawData.AcceptsTab = True
        Me.txtRawData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRawData.DetectUrls = False
        Me.txtRawData.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRawData.Location = New System.Drawing.Point(6, 308)
        Me.txtRawData.Name = "txtRawData"
        Me.txtRawData.ReadOnly = True
        Me.txtRawData.ShortcutsEnabled = False
        Me.txtRawData.Size = New System.Drawing.Size(376, 88)
        Me.txtRawData.TabIndex = 27
        Me.txtRawData.Text = ""
        Me.txtRawData.WordWrap = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.AutoSize = True
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtRawData)
        Me.GroupBox2.Controls.Add(Me.lblError)
        Me.GroupBox2.Controls.Add(Me.lblRawDataCaption)
        Me.GroupBox2.Controls.Add(Me.olvAddressBook)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(501, 148)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(388, 402)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        '
        'lblImportProgress
        '
        Me.lblImportProgress.AutoSize = True
        Me.lblImportProgress.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportProgress.Location = New System.Drawing.Point(16, 562)
        Me.lblImportProgress.Name = "lblImportProgress"
        Me.lblImportProgress.Size = New System.Drawing.Size(0, 16)
        Me.lblImportProgress.TabIndex = 29
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.Label1)
        Me.KryptonPanel.Controls.Add(Me.grpTextFormat)
        Me.KryptonPanel.Controls.Add(Me.Label2)
        Me.KryptonPanel.Controls.Add(Me.GroupBox1)
        Me.KryptonPanel.Controls.Add(Me.GroupBox2)
        Me.KryptonPanel.Controls.Add(Me.btnBrowse)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(901, 591)
        Me.KryptonPanel.TabIndex = 30
        '
        'ImportAddressBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(901, 591)
        Me.Controls.Add(Me.lblImportProgress)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.txtFileToImport)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ImportAddressBook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import Address Book"
        CType(Me.nudFullName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudEmailAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRemoteImages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudReceiveOnly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.olvAddressBook, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudBlocked, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRemindReceiveEveryXDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudImportanceRating, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudWebMailPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudWebMailQuestion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCustom4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCustom3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCustom2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCustom1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudWebPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMobile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudWork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHome, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSendReceipt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudReqReceipt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRemindSendEveryXDays, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTextFormat.ResumeLayout(False)
        Me.grpTextFormat.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFileToImport As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents chkFirstRowHeaders As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkSkipFullName As System.Windows.Forms.CheckBox
    Friend WithEvents chkSkipEmailAddress As System.Windows.Forms.CheckBox
    Friend WithEvents chkSkipRemoteImages As System.Windows.Forms.CheckBox
    Friend WithEvents chkSkipReceiveOnly As System.Windows.Forms.CheckBox
    Friend WithEvents nudFullName As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudEmailAddress As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudRemoteImages As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudReceiveOnly As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents olvAddressBook As BrightIdeasSoftware.ObjectListView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnCSV As System.Windows.Forms.RadioButton
    Friend WithEvents grpTextFormat As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnTAB As System.Windows.Forms.RadioButton
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents nudTags As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkSkipTags As System.Windows.Forms.CheckBox
    Friend WithEvents nudSendReceipt As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkSkipSendReceipt As System.Windows.Forms.CheckBox
    Friend WithEvents nudReqReceipt As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkSkipReqReceipt As System.Windows.Forms.CheckBox
    Friend WithEvents lblRawDataCaption As System.Windows.Forms.Label
    Friend WithEvents txtRawData As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn5 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn6 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn7 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents lblImportProgress As System.Windows.Forms.Label
    Friend WithEvents nudCustom1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkSkipCustom1 As System.Windows.Forms.CheckBox
    Friend WithEvents nudWebPage As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkSkipWebPage As System.Windows.Forms.CheckBox
    Friend WithEvents nudMobile As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkSkipMobile As System.Windows.Forms.CheckBox
    Friend WithEvents nudWork As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkSkipWork As System.Windows.Forms.CheckBox
    Friend WithEvents nudHome As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkSkipHome As System.Windows.Forms.CheckBox
    Friend WithEvents nudCustom3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents chkSkipCustom3 As System.Windows.Forms.CheckBox
    Friend WithEvents nudCustom2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkSkipCustom2 As System.Windows.Forms.CheckBox
    Friend WithEvents nudNotes As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents chkSkipNotes As System.Windows.Forms.CheckBox
    Friend WithEvents nudCustom4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents chkSkipCustom4 As System.Windows.Forms.CheckBox
    Friend WithEvents nudWebMailPassword As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents chkSkipWebMailPassword As System.Windows.Forms.CheckBox
    Friend WithEvents nudWebMailQuestion As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents chkSkipWebMailQuestion As System.Windows.Forms.CheckBox
    Friend WithEvents OlvColumn8 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn9 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn10 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn11 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn12 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn13 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn14 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn15 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn16 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn17 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn18 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents nudBlocked As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents chkSkipBlocked As System.Windows.Forms.CheckBox
    Friend WithEvents nudRemindSendEveryXDays As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents chkSkipRemindSendEveryXDays As System.Windows.Forms.CheckBox
    Friend WithEvents nudRemindReceiveEveryXDays As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents chkSkipRemindReceiveEveryXDays As System.Windows.Forms.CheckBox
    Friend WithEvents nudImportanceRating As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents chkSkipImportanceRating As System.Windows.Forms.CheckBox
    Friend WithEvents OlvColumn19 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn20 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn21 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn22 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
End Class
