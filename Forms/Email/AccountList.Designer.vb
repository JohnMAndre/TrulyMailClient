<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountList))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.olvPOPAccounts = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.POPasswordColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn5 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn6 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn7 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn8 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn9 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn10 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn11 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn12 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn13 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn26 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn19 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn25 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SetAsdefaultToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditAccountToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteAccountToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.MoveUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveDownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ResetNumberOfMessagesSentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetNumberOfMessagesReceivedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToggleIncludeInReceiveAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.olvSMTPAccounts = New BrightIdeasSoftware.ObjectListView()
        Me.OlvColumn14 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn15 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn16 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn17 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn18 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn20 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn21 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn22 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn23 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.SMTPPasswordColumn = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn24 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearPasswordToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutTrulyMailClientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.AddAccountToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.EditAccountToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteAccountToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.olvPOPAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.olvSMTPAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TabControl1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(921, 269)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(921, 347)
        Me.ToolStripContainer1.TabIndex = 18
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(921, 269)
        Me.TabControl1.TabIndex = 19
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.olvPOPAccounts)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(913, 240)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Receiving (POP3)"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'olvPOPAccounts
        '
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn1)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn2)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn3)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn4)
        Me.olvPOPAccounts.AllColumns.Add(Me.POPasswordColumn)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn5)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn6)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn7)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn8)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn9)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn10)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn11)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn12)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn13)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn26)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn19)
        Me.olvPOPAccounts.AllColumns.Add(Me.OlvColumn25)
        Me.olvPOPAccounts.AllowColumnReorder = True
        Me.olvPOPAccounts.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvPOPAccounts.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick
        Me.olvPOPAccounts.CellEditUseWholeCell = False
        Me.olvPOPAccounts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1, Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.POPasswordColumn, Me.OlvColumn5, Me.OlvColumn6, Me.OlvColumn7, Me.OlvColumn8, Me.OlvColumn9, Me.OlvColumn10, Me.OlvColumn11, Me.OlvColumn12, Me.OlvColumn13, Me.OlvColumn26, Me.OlvColumn19, Me.OlvColumn25})
        Me.olvPOPAccounts.ContextMenuStrip = Me.ContextMenuStrip1
        Me.olvPOPAccounts.Cursor = System.Windows.Forms.Cursors.Default
        Me.olvPOPAccounts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvPOPAccounts.EmptyListMsg = "There are no POP3 accounts, yet."
        Me.olvPOPAccounts.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvPOPAccounts.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvPOPAccounts.FullRowSelect = True
        Me.olvPOPAccounts.GridLines = True
        Me.olvPOPAccounts.HideSelection = False
        Me.olvPOPAccounts.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvPOPAccounts.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvPOPAccounts.LabelWrap = False
        Me.olvPOPAccounts.Location = New System.Drawing.Point(3, 3)
        Me.olvPOPAccounts.MultiSelect = False
        Me.olvPOPAccounts.Name = "olvPOPAccounts"
        Me.olvPOPAccounts.SelectAllOnControlA = False
        Me.olvPOPAccounts.SelectColumnsMenuStaysOpen = False
        Me.olvPOPAccounts.SelectColumnsOnRightClick = False
        Me.olvPOPAccounts.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvPOPAccounts.ShowCommandMenuOnRightClick = True
        Me.olvPOPAccounts.ShowGroups = False
        Me.olvPOPAccounts.ShowImagesOnSubItems = True
        Me.olvPOPAccounts.ShowItemCountOnGroups = True
        Me.olvPOPAccounts.Size = New System.Drawing.Size(907, 234)
        Me.olvPOPAccounts.TabIndex = 3
        Me.olvPOPAccounts.UseAlternatingBackColors = True
        Me.olvPOPAccounts.UseCompatibleStateImageBehavior = False
        Me.olvPOPAccounts.View = System.Windows.Forms.View.Details
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "Name"
        Me.OlvColumn1.Text = "Name"
        Me.OlvColumn1.Width = 50
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "ServerAddress"
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.Text = "Server"
        Me.OlvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.Width = 53
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "ServerPort"
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.Text = "Port"
        Me.OlvColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.Width = 39
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "Username"
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.Text = "Username"
        Me.OlvColumn4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.Width = 74
        '
        'POPasswordColumn
        '
        Me.POPasswordColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.POPasswordColumn.Text = "Password"
        Me.POPasswordColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "SecureConnection"
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.Text = "Secure Connection"
        Me.OlvColumn5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.Width = 133
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "UseSecureAuthentication"
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.Text = "Secure Login"
        Me.OlvColumn6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.Width = 101
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "DownloadOnStartup"
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.Text = "Download on Startup"
        Me.OlvColumn7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.Width = 144
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "DownloadAtInterval"
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.Text = "Download Regularly"
        Me.OlvColumn8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.Width = 132
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "DownloadInterval"
        Me.OlvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.Text = "Download Frequency (minutes)"
        Me.OlvColumn9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.Width = 207
        '
        'OlvColumn10
        '
        Me.OlvColumn10.AspectName = "LeaveOnServer"
        Me.OlvColumn10.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn10.Text = "Leave on Server"
        Me.OlvColumn10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OlvColumn11
        '
        Me.OlvColumn11.AspectName = "InBoxPath"
        Me.OlvColumn11.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn11.Text = "InBox"
        Me.OlvColumn11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OlvColumn12
        '
        Me.OlvColumn12.AspectName = "SendReturnReceiptSenderInAddressBook"
        Me.OlvColumn12.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn12.Text = "Receipt (in Address Book)"
        Me.OlvColumn12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OlvColumn13
        '
        Me.OlvColumn13.AspectName = "SendReturnReceiptSenderNotInAddressBook"
        Me.OlvColumn13.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn13.Text = "Receipt (not in Address Book)"
        Me.OlvColumn13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OlvColumn26
        '
        Me.OlvColumn26.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn26.IsEditable = False
        Me.OlvColumn26.Text = "SMTP Acct"
        Me.OlvColumn26.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OlvColumn19
        '
        Me.OlvColumn19.AspectName = "MessagesReceived"
        Me.OlvColumn19.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn19.Text = "Msgs Recd"
        Me.OlvColumn19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn19.ToolTipText = "Messages received since last counter reset"
        '
        'OlvColumn25
        '
        Me.OlvColumn25.AspectName = "IncludeInReceiveAll"
        Me.OlvColumn25.Text = "RecAll"
        Me.OlvColumn25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetAsdefaultToolStripMenuItem, Me.ToolStripSeparator2, Me.EditAccountToolStripMenuItem1, Me.DeleteAccountToolStripMenuItem1, Me.ToolStripSeparator3, Me.ClearPasswordToolStripMenuItem, Me.ToolStripSeparator5, Me.MoveUpToolStripMenuItem, Me.MoveDownToolStripMenuItem, Me.ToolStripSeparator7, Me.ResetNumberOfMessagesSentToolStripMenuItem, Me.ResetNumberOfMessagesReceivedToolStripMenuItem, Me.ToggleIncludeInReceiveAllToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(263, 226)
        '
        'SetAsdefaultToolStripMenuItem
        '
        Me.SetAsdefaultToolStripMenuItem.Name = "SetAsdefaultToolStripMenuItem"
        Me.SetAsdefaultToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.SetAsdefaultToolStripMenuItem.Text = "&Set as default"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(259, 6)
        '
        'EditAccountToolStripMenuItem1
        '
        Me.EditAccountToolStripMenuItem1.Image = Global.TrulyMail.My.Resources.Resources.Checkboxes_16
        Me.EditAccountToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.White
        Me.EditAccountToolStripMenuItem1.Name = "EditAccountToolStripMenuItem1"
        Me.EditAccountToolStripMenuItem1.Size = New System.Drawing.Size(262, 22)
        Me.EditAccountToolStripMenuItem1.Text = "&Edit account..."
        '
        'DeleteAccountToolStripMenuItem1
        '
        Me.DeleteAccountToolStripMenuItem1.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.DeleteAccountToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.White
        Me.DeleteAccountToolStripMenuItem1.Name = "DeleteAccountToolStripMenuItem1"
        Me.DeleteAccountToolStripMenuItem1.Size = New System.Drawing.Size(262, 22)
        Me.DeleteAccountToolStripMenuItem1.Text = "&Delete account"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(259, 6)
        '
        'ClearPasswordToolStripMenuItem
        '
        Me.ClearPasswordToolStripMenuItem.Name = "ClearPasswordToolStripMenuItem"
        Me.ClearPasswordToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ClearPasswordToolStripMenuItem.Text = "&Clear password"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(259, 6)
        '
        'MoveUpToolStripMenuItem
        '
        Me.MoveUpToolStripMenuItem.Name = "MoveUpToolStripMenuItem"
        Me.MoveUpToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.MoveUpToolStripMenuItem.Text = "Move &up"
        Me.MoveUpToolStripMenuItem.ToolTipText = "Move selected POP account up in the list"
        '
        'MoveDownToolStripMenuItem
        '
        Me.MoveDownToolStripMenuItem.Name = "MoveDownToolStripMenuItem"
        Me.MoveDownToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.MoveDownToolStripMenuItem.Text = "Move do&wn"
        Me.MoveDownToolStripMenuItem.ToolTipText = "Move the selected POP account down in the list"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(259, 6)
        '
        'ResetNumberOfMessagesSentToolStripMenuItem
        '
        Me.ResetNumberOfMessagesSentToolStripMenuItem.Name = "ResetNumberOfMessagesSentToolStripMenuItem"
        Me.ResetNumberOfMessagesSentToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ResetNumberOfMessagesSentToolStripMenuItem.Text = "Reset number of messages sent"
        '
        'ResetNumberOfMessagesReceivedToolStripMenuItem
        '
        Me.ResetNumberOfMessagesReceivedToolStripMenuItem.Name = "ResetNumberOfMessagesReceivedToolStripMenuItem"
        Me.ResetNumberOfMessagesReceivedToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ResetNumberOfMessagesReceivedToolStripMenuItem.Text = "Reset number of messages received"
        '
        'ToggleIncludeInReceiveAllToolStripMenuItem
        '
        Me.ToggleIncludeInReceiveAllToolStripMenuItem.Name = "ToggleIncludeInReceiveAllToolStripMenuItem"
        Me.ToggleIncludeInReceiveAllToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ToggleIncludeInReceiveAllToolStripMenuItem.Text = "&Toggle include in receive all"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.olvSMTPAccounts)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(913, 240)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Sending (SMTP)"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'olvSMTPAccounts
        '
        Me.olvSMTPAccounts.AllColumns.Add(Me.OlvColumn14)
        Me.olvSMTPAccounts.AllColumns.Add(Me.OlvColumn15)
        Me.olvSMTPAccounts.AllColumns.Add(Me.OlvColumn16)
        Me.olvSMTPAccounts.AllColumns.Add(Me.OlvColumn17)
        Me.olvSMTPAccounts.AllColumns.Add(Me.OlvColumn18)
        Me.olvSMTPAccounts.AllColumns.Add(Me.OlvColumn20)
        Me.olvSMTPAccounts.AllColumns.Add(Me.OlvColumn21)
        Me.olvSMTPAccounts.AllColumns.Add(Me.OlvColumn22)
        Me.olvSMTPAccounts.AllColumns.Add(Me.OlvColumn23)
        Me.olvSMTPAccounts.AllColumns.Add(Me.SMTPPasswordColumn)
        Me.olvSMTPAccounts.AllColumns.Add(Me.OlvColumn24)
        Me.olvSMTPAccounts.AllowColumnReorder = True
        Me.olvSMTPAccounts.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olvSMTPAccounts.CellEditUseWholeCell = False
        Me.olvSMTPAccounts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn14, Me.OlvColumn15, Me.OlvColumn16, Me.OlvColumn17, Me.OlvColumn18, Me.OlvColumn20, Me.OlvColumn21, Me.OlvColumn22, Me.OlvColumn23, Me.SMTPPasswordColumn, Me.OlvColumn24})
        Me.olvSMTPAccounts.ContextMenuStrip = Me.ContextMenuStrip1
        Me.olvSMTPAccounts.Cursor = System.Windows.Forms.Cursors.Default
        Me.olvSMTPAccounts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.olvSMTPAccounts.EmptyListMsg = "There are no SMTP accounts, yet."
        Me.olvSMTPAccounts.EmptyListMsgFont = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvSMTPAccounts.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.olvSMTPAccounts.FullRowSelect = True
        Me.olvSMTPAccounts.GridLines = True
        Me.olvSMTPAccounts.HideSelection = False
        Me.olvSMTPAccounts.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.olvSMTPAccounts.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.olvSMTPAccounts.LabelWrap = False
        Me.olvSMTPAccounts.Location = New System.Drawing.Point(3, 3)
        Me.olvSMTPAccounts.MultiSelect = False
        Me.olvSMTPAccounts.Name = "olvSMTPAccounts"
        Me.olvSMTPAccounts.SelectAllOnControlA = False
        Me.olvSMTPAccounts.SelectColumnsMenuStaysOpen = False
        Me.olvSMTPAccounts.SelectColumnsOnRightClick = False
        Me.olvSMTPAccounts.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
        Me.olvSMTPAccounts.ShowCommandMenuOnRightClick = True
        Me.olvSMTPAccounts.ShowGroups = False
        Me.olvSMTPAccounts.ShowImagesOnSubItems = True
        Me.olvSMTPAccounts.ShowItemCountOnGroups = True
        Me.olvSMTPAccounts.Size = New System.Drawing.Size(907, 234)
        Me.olvSMTPAccounts.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.olvSMTPAccounts.TabIndex = 4
        Me.olvSMTPAccounts.UseAlternatingBackColors = True
        Me.olvSMTPAccounts.UseCompatibleStateImageBehavior = False
        Me.olvSMTPAccounts.View = System.Windows.Forms.View.Details
        '
        'OlvColumn14
        '
        Me.OlvColumn14.AspectName = "Name"
        Me.OlvColumn14.Text = "Name"
        Me.OlvColumn14.Width = 50
        '
        'OlvColumn15
        '
        Me.OlvColumn15.AspectName = "ServerName"
        Me.OlvColumn15.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn15.Text = "Server"
        Me.OlvColumn15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn15.Width = 53
        '
        'OlvColumn16
        '
        Me.OlvColumn16.AspectName = "ServerPort"
        Me.OlvColumn16.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn16.Text = "Port"
        Me.OlvColumn16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn16.Width = 39
        '
        'OlvColumn17
        '
        Me.OlvColumn17.AspectName = "Username"
        Me.OlvColumn17.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn17.Text = "Username"
        Me.OlvColumn17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn17.Width = 74
        '
        'OlvColumn18
        '
        Me.OlvColumn18.AspectName = "SecureConnection"
        Me.OlvColumn18.DisplayIndex = 5
        Me.OlvColumn18.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn18.Text = "Secure Connection"
        Me.OlvColumn18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn18.Width = 64
        '
        'OlvColumn20
        '
        Me.OlvColumn20.AspectName = "IsDefault"
        Me.OlvColumn20.DisplayIndex = 6
        Me.OlvColumn20.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn20.Text = "Default"
        Me.OlvColumn20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn20.Width = 144
        '
        'OlvColumn21
        '
        Me.OlvColumn21.AspectName = "DisplayName"
        Me.OlvColumn21.DisplayIndex = 7
        Me.OlvColumn21.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn21.Text = "Display Name"
        Me.OlvColumn21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn21.Width = 132
        '
        'OlvColumn22
        '
        Me.OlvColumn22.AspectName = "DisplayEmail"
        Me.OlvColumn22.DisplayIndex = 8
        Me.OlvColumn22.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn22.Text = "Display Email"
        Me.OlvColumn22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn22.Width = 139
        '
        'OlvColumn23
        '
        Me.OlvColumn23.AspectName = "ReplyTo"
        Me.OlvColumn23.DisplayIndex = 9
        Me.OlvColumn23.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn23.Text = "Reply To"
        Me.OlvColumn23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn23.Width = 86
        '
        'SMTPPasswordColumn
        '
        Me.SMTPPasswordColumn.AspectName = ""
        Me.SMTPPasswordColumn.DisplayIndex = 4
        Me.SMTPPasswordColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SMTPPasswordColumn.Text = "Password"
        Me.SMTPPasswordColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SMTPPasswordColumn.Width = 75
        '
        'OlvColumn24
        '
        Me.OlvColumn24.AspectName = "MessagesSent"
        Me.OlvColumn24.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn24.Text = "Msgs sent"
        Me.OlvColumn24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn24.ToolTipText = "Messages sent since last counter reset"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(921, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        Me.ExitToolStripMenuItem.ToolTipText = "Close TrulyMail"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddAccountToolStripMenuItem, Me.ToolStripSeparator1, Me.EditAccountToolStripMenuItem, Me.DeleteAccountToolStripMenuItem, Me.ToolStripSeparator4, Me.ClearPasswordToolStripMenuItem1})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.ToolsToolStripMenuItem.Text = "&Account"
        '
        'AddAccountToolStripMenuItem
        '
        Me.AddAccountToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Editpencil_16
        Me.AddAccountToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.AddAccountToolStripMenuItem.Name = "AddAccountToolStripMenuItem"
        Me.AddAccountToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.AddAccountToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.AddAccountToolStripMenuItem.Text = "&New email account..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(225, 6)
        '
        'EditAccountToolStripMenuItem
        '
        Me.EditAccountToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Checkboxes_16
        Me.EditAccountToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.EditAccountToolStripMenuItem.Name = "EditAccountToolStripMenuItem"
        Me.EditAccountToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.EditAccountToolStripMenuItem.Text = "&Edit account..."
        '
        'DeleteAccountToolStripMenuItem
        '
        Me.DeleteAccountToolStripMenuItem.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.DeleteAccountToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.DeleteAccountToolStripMenuItem.Name = "DeleteAccountToolStripMenuItem"
        Me.DeleteAccountToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.DeleteAccountToolStripMenuItem.Text = "&Delete account"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(225, 6)
        '
        'ClearPasswordToolStripMenuItem1
        '
        Me.ClearPasswordToolStripMenuItem1.Name = "ClearPasswordToolStripMenuItem1"
        Me.ClearPasswordToolStripMenuItem1.Size = New System.Drawing.Size(228, 22)
        Me.ClearPasswordToolStripMenuItem1.Text = "&Clear Password"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutTrulyMailClientToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutTrulyMailClientToolStripMenuItem
        '
        Me.AboutTrulyMailClientToolStripMenuItem.Name = "AboutTrulyMailClientToolStripMenuItem"
        Me.AboutTrulyMailClientToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.AboutTrulyMailClientToolStripMenuItem.Text = "&About TrulyMail..."
        Me.AboutTrulyMailClientToolStripMenuItem.ToolTipText = "See TrulyMail version"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddAccountToolStripButton, Me.EditAccountToolStripButton, Me.ToolStripSeparator6, Me.DeleteAccountToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(257, 54)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'AddAccountToolStripButton
        '
        Me.AddAccountToolStripButton.Image = CType(resources.GetObject("AddAccountToolStripButton.Image"), System.Drawing.Image)
        Me.AddAccountToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.AddAccountToolStripButton.Name = "AddAccountToolStripButton"
        Me.AddAccountToolStripButton.Size = New System.Drawing.Size(81, 51)
        Me.AddAccountToolStripButton.Text = "New account"
        Me.AddAccountToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.AddAccountToolStripButton.ToolTipText = "New email account"
        '
        'EditAccountToolStripButton
        '
        Me.EditAccountToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.Checkboxes_32
        Me.EditAccountToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.EditAccountToolStripButton.Name = "EditAccountToolStripButton"
        Me.EditAccountToolStripButton.Size = New System.Drawing.Size(77, 51)
        Me.EditAccountToolStripButton.Text = "Edit account"
        Me.EditAccountToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.EditAccountToolStripButton.ToolTipText = "Edit account settings"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 54)
        '
        'DeleteAccountToolStripButton
        '
        Me.DeleteAccountToolStripButton.Image = Global.TrulyMail.My.Resources.Resources.Erase_32
        Me.DeleteAccountToolStripButton.ImageTransparentColor = System.Drawing.Color.White
        Me.DeleteAccountToolStripButton.Name = "DeleteAccountToolStripButton"
        Me.DeleteAccountToolStripButton.Size = New System.Drawing.Size(90, 51)
        Me.DeleteAccountToolStripButton.Text = "Delete account"
        Me.DeleteAccountToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.DeleteAccountToolStripButton.ToolTipText = "Delete selected account"
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
        'AccountList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(921, 347)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AccountList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Account Settings"
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.olvPOPAccounts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.olvSMTPAccounts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents AddAccountToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditAccountToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeleteAccountToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutTrulyMailClientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents olvPOPAccounts As BrightIdeasSoftware.ObjectListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn5 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn6 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn7 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn8 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn9 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn10 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn11 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn12 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn13 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn26 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents olvSMTPAccounts As BrightIdeasSoftware.ObjectListView
    Friend WithEvents OlvColumn14 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn15 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn16 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn17 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn18 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn20 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn21 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn22 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn23 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AddAccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditAccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteAccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SetAsdefaultToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditAccountToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteAccountToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SMTPPasswordColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearPasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents POPasswordColumn As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearPasswordToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MoveUpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveDownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OlvColumn19 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ResetNumberOfMessagesSentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetNumberOfMessagesReceivedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OlvColumn24 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents OlvColumn25 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ToggleIncludeInReceiveAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
