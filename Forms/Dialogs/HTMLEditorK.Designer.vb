<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HTMLEditorK
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HTMLEditorK))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.RichTextBox1 = New ComponentFactory.Krypton.Toolkit.KryptonRichTextBox()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSave = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.InsertReplacementCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactEmailaddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactTagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateLastMessageSentToContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateLastMessageWasReceivedFromContactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactCustomField1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactCustomField2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactCustomField3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactCustomField4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactHomePhoneNumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactWorkPhoneNumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactMobilePhoneNumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactWebAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactDateAddedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateMessageWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutTrulyMailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.KryptonPanel)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(480, 350)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(480, 374)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.RichTextBox1)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(480, 350)
        Me.KryptonPanel.TabIndex = 1
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Palette = Me.KryptonPalette1
        Me.RichTextBox1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.RichTextBox1.Size = New System.Drawing.Size(480, 289)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = ""
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.btnCancel)
        Me.KryptonPanel1.Controls.Add(Me.btnSave)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 289)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Palette = Me.KryptonPalette1
        Me.KryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel1.Size = New System.Drawing.Size(480, 61)
        Me.KryptonPanel1.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(102, 7)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Palette = Me.KryptonPalette1
        Me.btnCancel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnCancel.Size = New System.Drawing.Size(114, 46)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Values.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSave.Location = New System.Drawing.Point(267, 7)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Palette = Me.KryptonPalette1
        Me.btnSave.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnSave.Size = New System.Drawing.Size(114, 46)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Values.Image = Global.TrulyMail.My.Resources.Resources.Savefile_16
        Me.btnSave.Values.Text = "&Save"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InsertReplacementCodeToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(480, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'InsertReplacementCodeToolStripMenuItem
        '
        Me.InsertReplacementCodeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContactNameToolStripMenuItem, Me.ContactEmailaddressToolStripMenuItem, Me.ContactTagsToolStripMenuItem, Me.DateLastMessageSentToContactToolStripMenuItem, Me.DateLastMessageWasReceivedFromContactToolStripMenuItem, Me.ContactCustomField1ToolStripMenuItem, Me.ContactCustomField2ToolStripMenuItem, Me.ContactCustomField3ToolStripMenuItem, Me.ContactCustomField4ToolStripMenuItem, Me.ContactHomePhoneNumberToolStripMenuItem, Me.ContactWorkPhoneNumberToolStripMenuItem, Me.ContactMobilePhoneNumberToolStripMenuItem, Me.ContactWebAddressToolStripMenuItem, Me.ContactDateAddedToolStripMenuItem})
        Me.InsertReplacementCodeToolStripMenuItem.Name = "InsertReplacementCodeToolStripMenuItem"
        Me.InsertReplacementCodeToolStripMenuItem.Size = New System.Drawing.Size(151, 20)
        Me.InsertReplacementCodeToolStripMenuItem.Text = "&Insert Replacement Code"
        '
        'ContactNameToolStripMenuItem
        '
        Me.ContactNameToolStripMenuItem.Name = "ContactNameToolStripMenuItem"
        Me.ContactNameToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.ContactNameToolStripMenuItem.Text = "Contact name"
        '
        'ContactEmailaddressToolStripMenuItem
        '
        Me.ContactEmailaddressToolStripMenuItem.Name = "ContactEmailaddressToolStripMenuItem"
        Me.ContactEmailaddressToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.ContactEmailaddressToolStripMenuItem.Text = "Contact email &address"
        '
        'ContactTagsToolStripMenuItem
        '
        Me.ContactTagsToolStripMenuItem.Name = "ContactTagsToolStripMenuItem"
        Me.ContactTagsToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.ContactTagsToolStripMenuItem.Text = "Contact tags"
        '
        'DateLastMessageSentToContactToolStripMenuItem
        '
        Me.DateLastMessageSentToContactToolStripMenuItem.Name = "DateLastMessageSentToContactToolStripMenuItem"
        Me.DateLastMessageSentToContactToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.DateLastMessageSentToContactToolStripMenuItem.Text = "Date last message was sent to contact"
        '
        'DateLastMessageWasReceivedFromContactToolStripMenuItem
        '
        Me.DateLastMessageWasReceivedFromContactToolStripMenuItem.Name = "DateLastMessageWasReceivedFromContactToolStripMenuItem"
        Me.DateLastMessageWasReceivedFromContactToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.DateLastMessageWasReceivedFromContactToolStripMenuItem.Text = "Date last message was received from contact"
        '
        'ContactCustomField1ToolStripMenuItem
        '
        Me.ContactCustomField1ToolStripMenuItem.Name = "ContactCustomField1ToolStripMenuItem"
        Me.ContactCustomField1ToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.ContactCustomField1ToolStripMenuItem.Text = "Contact custom field 1"
        '
        'ContactCustomField2ToolStripMenuItem
        '
        Me.ContactCustomField2ToolStripMenuItem.Name = "ContactCustomField2ToolStripMenuItem"
        Me.ContactCustomField2ToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.ContactCustomField2ToolStripMenuItem.Text = "Contact custom field 2"
        '
        'ContactCustomField3ToolStripMenuItem
        '
        Me.ContactCustomField3ToolStripMenuItem.Name = "ContactCustomField3ToolStripMenuItem"
        Me.ContactCustomField3ToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.ContactCustomField3ToolStripMenuItem.Text = "Contact custom field 3"
        '
        'ContactCustomField4ToolStripMenuItem
        '
        Me.ContactCustomField4ToolStripMenuItem.Name = "ContactCustomField4ToolStripMenuItem"
        Me.ContactCustomField4ToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.ContactCustomField4ToolStripMenuItem.Text = "Contact custom field 4"
        '
        'ContactHomePhoneNumberToolStripMenuItem
        '
        Me.ContactHomePhoneNumberToolStripMenuItem.Name = "ContactHomePhoneNumberToolStripMenuItem"
        Me.ContactHomePhoneNumberToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.ContactHomePhoneNumberToolStripMenuItem.Text = "Contact home phone number"
        '
        'ContactWorkPhoneNumberToolStripMenuItem
        '
        Me.ContactWorkPhoneNumberToolStripMenuItem.Name = "ContactWorkPhoneNumberToolStripMenuItem"
        Me.ContactWorkPhoneNumberToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.ContactWorkPhoneNumberToolStripMenuItem.Text = "Contact work phone number"
        '
        'ContactMobilePhoneNumberToolStripMenuItem
        '
        Me.ContactMobilePhoneNumberToolStripMenuItem.Name = "ContactMobilePhoneNumberToolStripMenuItem"
        Me.ContactMobilePhoneNumberToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.ContactMobilePhoneNumberToolStripMenuItem.Text = "Contact mobile phone number"
        '
        'ContactWebAddressToolStripMenuItem
        '
        Me.ContactWebAddressToolStripMenuItem.Name = "ContactWebAddressToolStripMenuItem"
        Me.ContactWebAddressToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.ContactWebAddressToolStripMenuItem.Text = "Contact web address"
        '
        'ContactDateAddedToolStripMenuItem
        '
        Me.ContactDateAddedToolStripMenuItem.Name = "ContactDateAddedToolStripMenuItem"
        Me.ContactDateAddedToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.ContactDateAddedToolStripMenuItem.Text = "Contact date added"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateMessageWindowToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        Me.ToolsToolStripMenuItem.ToolTipText = "Activate to update the message window as you change the HTML here"
        '
        'UpdateMessageWindowToolStripMenuItem
        '
        Me.UpdateMessageWindowToolStripMenuItem.CheckOnClick = True
        Me.UpdateMessageWindowToolStripMenuItem.Name = "UpdateMessageWindowToolStripMenuItem"
        Me.UpdateMessageWindowToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.UpdateMessageWindowToolStripMenuItem.Text = "&Update message window"
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
        Me.AboutTrulyMailToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AboutTrulyMailToolStripMenuItem.Text = "&About TrulyMail"
        '
        'HTMLEditorK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(480, 374)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "HTMLEditorK"
        Me.Palette = Me.KryptonPalette1
        Me.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.Text = "HTML Editor"
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents RichTextBox1 As ComponentFactory.Krypton.Toolkit.KryptonRichTextBox
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnSave As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents InsertReplacementCodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContactNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContactEmailaddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContactTagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents DateLastMessageSentToContactToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents DateLastMessageWasReceivedFromContactToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContactCustomField1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContactCustomField2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContactCustomField3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContactCustomField4ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContactHomePhoneNumberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContactWorkPhoneNumberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContactMobilePhoneNumberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContactWebAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContactDateAddedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents AboutTrulyMailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateMessageWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
End Class
