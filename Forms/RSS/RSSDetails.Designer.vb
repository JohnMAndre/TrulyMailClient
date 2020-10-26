<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSSDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RSSDetails))
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkShowSummary = New System.Windows.Forms.CheckBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.chkDownloadMedia = New System.Windows.Forms.CheckBox()
        Me.llblChangePageInbox = New System.Windows.Forms.LinkLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkHTMLToPlainText = New System.Windows.Forms.CheckBox()
        Me.chkAddLinkToPlainText = New System.Windows.Forms.CheckBox()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtURL
        '
        Me.txtURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtURL.Location = New System.Drawing.Point(138, 20)
        Me.txtURL.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(271, 26)
        Me.txtURL.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtURL, "Enter the address (URL) of the RSS feed")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Feed address:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Store articles in:"
        '
        'chkShowSummary
        '
        Me.chkShowSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShowSummary.BackColor = System.Drawing.Color.Transparent
        Me.chkShowSummary.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkShowSummary.Checked = True
        Me.chkShowSummary.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowSummary.Location = New System.Drawing.Point(12, 90)
        Me.chkShowSummary.Name = "chkShowSummary"
        Me.chkShowSummary.Size = New System.Drawing.Size(397, 22)
        Me.chkShowSummary.TabIndex = 4
        Me.chkShowSummary.Text = "Show summary instead of article:"
        Me.ToolTip1.SetToolTip(Me.chkShowSummary, "If unchecked the body of the message will be downloaded as a web page, if checked" & _
        " it comes from the contents of the RSS feed")
        Me.chkShowSummary.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.Location = New System.Drawing.Point(237, 270)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(82, 30)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.Location = New System.Drawing.Point(89, 270)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(82, 30)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
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
        'chkDownloadMedia
        '
        Me.chkDownloadMedia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDownloadMedia.BackColor = System.Drawing.Color.Transparent
        Me.chkDownloadMedia.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDownloadMedia.Location = New System.Drawing.Point(12, 116)
        Me.chkDownloadMedia.Name = "chkDownloadMedia"
        Me.chkDownloadMedia.Size = New System.Drawing.Size(397, 21)
        Me.chkDownloadMedia.TabIndex = 36
        Me.chkDownloadMedia.Text = "Download media attachments:"
        Me.ToolTip1.SetToolTip(Me.chkDownloadMedia, "If the RSS feed included media attachments, check if you want them to be download" & _
        "ed and treated as attachments")
        Me.chkDownloadMedia.UseVisualStyleBackColor = False
        '
        'llblChangePageInbox
        '
        Me.llblChangePageInbox.AutoSize = True
        Me.llblChangePageInbox.BackColor = System.Drawing.Color.Transparent
        Me.llblChangePageInbox.LinkArea = New System.Windows.Forms.LinkArea(6, 12)
        Me.llblChangePageInbox.Location = New System.Drawing.Point(138, 59)
        Me.llblChangePageInbox.Name = "llblChangePageInbox"
        Me.llblChangePageInbox.Size = New System.Drawing.Size(107, 24)
        Me.llblChangePageInbox.TabIndex = 46
        Me.llblChangePageInbox.TabStop = True
        Me.llblChangePageInbox.Text = "InBox change"
        Me.ToolTip1.SetToolTip(Me.llblChangePageInbox, "Choose the location to store new RSS messages from this feed")
        Me.llblChangePageInbox.UseCompatibleTextRendering = True
        '
        'chkHTMLToPlainText
        '
        Me.chkHTMLToPlainText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkHTMLToPlainText.BackColor = System.Drawing.Color.Transparent
        Me.chkHTMLToPlainText.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkHTMLToPlainText.Location = New System.Drawing.Point(12, 142)
        Me.chkHTMLToPlainText.Name = "chkHTMLToPlainText"
        Me.chkHTMLToPlainText.Size = New System.Drawing.Size(397, 23)
        Me.chkHTMLToPlainText.TabIndex = 47
        Me.chkHTMLToPlainText.Text = "Convert HTML to plain text:"
        Me.ToolTip1.SetToolTip(Me.chkHTMLToPlainText, "If an RSS feed contains HTML, check if you want to convert to plain text")
        Me.chkHTMLToPlainText.UseVisualStyleBackColor = False
        '
        'chkAddLinkToPlainText
        '
        Me.chkAddLinkToPlainText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAddLinkToPlainText.BackColor = System.Drawing.Color.Transparent
        Me.chkAddLinkToPlainText.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAddLinkToPlainText.Enabled = False
        Me.chkAddLinkToPlainText.Location = New System.Drawing.Point(52, 171)
        Me.chkAddLinkToPlainText.Name = "chkAddLinkToPlainText"
        Me.chkAddLinkToPlainText.Size = New System.Drawing.Size(357, 23)
        Me.chkAddLinkToPlainText.TabIndex = 48
        Me.chkAddLinkToPlainText.Text = "Add link to plain text"
        Me.ToolTip1.SetToolTip(Me.chkAddLinkToPlainText, "Add a link under the plain text of the RSS message (useful when forwarding)")
        Me.chkAddLinkToPlainText.UseVisualStyleBackColor = False
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
        Me.KryptonPanel.Controls.Add(Me.txtURL)
        Me.KryptonPanel.Controls.Add(Me.chkAddLinkToPlainText)
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.chkHTMLToPlainText)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.llblChangePageInbox)
        Me.KryptonPanel.Controls.Add(Me.Label1)
        Me.KryptonPanel.Controls.Add(Me.chkDownloadMedia)
        Me.KryptonPanel.Controls.Add(Me.Label2)
        Me.KryptonPanel.Controls.Add(Me.chkShowSummary)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(421, 312)
        Me.KryptonPanel.TabIndex = 49
        '
        'RSSDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(421, 312)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "RSSDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Subscription Details"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkShowSummary As System.Windows.Forms.CheckBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents chkDownloadMedia As System.Windows.Forms.CheckBox
    Friend WithEvents llblChangePageInbox As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkHTMLToPlainText As System.Windows.Forms.CheckBox
    Friend WithEvents chkAddLinkToPlainText As System.Windows.Forms.CheckBox
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
End Class
