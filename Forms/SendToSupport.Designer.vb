<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SendToSupport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SendToSupport))
        Me.lblSMTPFrom = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkLogFile = New System.Windows.Forms.CheckBox()
        Me.chkSettings = New System.Windows.Forms.CheckBox()
        Me.chkAddressBook = New System.Windows.Forms.CheckBox()
        Me.pbLogFileInfo = New System.Windows.Forms.PictureBox()
        Me.pbSettingsFileInfo = New System.Windows.Forms.PictureBox()
        Me.pbAddressBookInfo = New System.Windows.Forms.PictureBox()
        Me.lblLogFile = New System.Windows.Forms.Label()
        Me.lblMessages = New System.Windows.Forms.Label()
        Me.bgMessageSize = New System.ComponentModel.BackgroundWorker()
        Me.llblShowLogfile = New System.Windows.Forms.LinkLabel()
        Me.pbReminderInfo = New System.Windows.Forms.PictureBox()
        Me.chkReminders = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.chkRemovePasswordsFromSettings = New System.Windows.Forms.CheckBox()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSend = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.llblOpenLogFile = New System.Windows.Forms.LinkLabel()
        CType(Me.pbLogFileInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSettingsFileInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddressBookInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbReminderInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSMTPFrom
        '
        Me.lblSMTPFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSMTPFrom.BackColor = System.Drawing.Color.Transparent
        Me.lblSMTPFrom.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSMTPFrom.Location = New System.Drawing.Point(12, 9)
        Me.lblSMTPFrom.Name = "lblSMTPFrom"
        Me.lblSMTPFrom.Size = New System.Drawing.Size(444, 48)
        Me.lblSMTPFrom.TabIndex = 24
        Me.lblSMTPFrom.Text = "Support Center"
        Me.lblSMTPFrom.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(444, 79)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'chkLogFile
        '
        Me.chkLogFile.AutoSize = True
        Me.chkLogFile.BackColor = System.Drawing.Color.Transparent
        Me.chkLogFile.Checked = True
        Me.chkLogFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLogFile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLogFile.Location = New System.Drawing.Point(73, 166)
        Me.chkLogFile.Name = "chkLogFile"
        Me.chkLogFile.Size = New System.Drawing.Size(68, 20)
        Me.chkLogFile.TabIndex = 26
        Me.chkLogFile.Text = "&Log file"
        Me.chkLogFile.UseVisualStyleBackColor = False
        '
        'chkSettings
        '
        Me.chkSettings.AutoSize = True
        Me.chkSettings.BackColor = System.Drawing.Color.Transparent
        Me.chkSettings.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSettings.Location = New System.Drawing.Point(73, 201)
        Me.chkSettings.Name = "chkSettings"
        Me.chkSettings.Size = New System.Drawing.Size(95, 20)
        Me.chkSettings.TabIndex = 27
        Me.chkSettings.Text = "Se&ttings file"
        Me.chkSettings.UseVisualStyleBackColor = False
        '
        'chkAddressBook
        '
        Me.chkAddressBook.AutoSize = True
        Me.chkAddressBook.BackColor = System.Drawing.Color.Transparent
        Me.chkAddressBook.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAddressBook.Location = New System.Drawing.Point(73, 236)
        Me.chkAddressBook.Name = "chkAddressBook"
        Me.chkAddressBook.Size = New System.Drawing.Size(109, 20)
        Me.chkAddressBook.TabIndex = 30
        Me.chkAddressBook.Text = "Address &Book"
        Me.chkAddressBook.UseVisualStyleBackColor = False
        '
        'pbLogFileInfo
        '
        Me.pbLogFileInfo.BackColor = System.Drawing.Color.Transparent
        Me.pbLogFileInfo.Image = CType(resources.GetObject("pbLogFileInfo.Image"), System.Drawing.Image)
        Me.pbLogFileInfo.Location = New System.Drawing.Point(39, 166)
        Me.pbLogFileInfo.Name = "pbLogFileInfo"
        Me.pbLogFileInfo.Size = New System.Drawing.Size(22, 22)
        Me.pbLogFileInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLogFileInfo.TabIndex = 33
        Me.pbLogFileInfo.TabStop = False
        '
        'pbSettingsFileInfo
        '
        Me.pbSettingsFileInfo.BackColor = System.Drawing.Color.Transparent
        Me.pbSettingsFileInfo.Image = CType(resources.GetObject("pbSettingsFileInfo.Image"), System.Drawing.Image)
        Me.pbSettingsFileInfo.Location = New System.Drawing.Point(39, 201)
        Me.pbSettingsFileInfo.Name = "pbSettingsFileInfo"
        Me.pbSettingsFileInfo.Size = New System.Drawing.Size(22, 22)
        Me.pbSettingsFileInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbSettingsFileInfo.TabIndex = 34
        Me.pbSettingsFileInfo.TabStop = False
        '
        'pbAddressBookInfo
        '
        Me.pbAddressBookInfo.BackColor = System.Drawing.Color.Transparent
        Me.pbAddressBookInfo.Image = CType(resources.GetObject("pbAddressBookInfo.Image"), System.Drawing.Image)
        Me.pbAddressBookInfo.Location = New System.Drawing.Point(39, 236)
        Me.pbAddressBookInfo.Name = "pbAddressBookInfo"
        Me.pbAddressBookInfo.Size = New System.Drawing.Size(22, 22)
        Me.pbAddressBookInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbAddressBookInfo.TabIndex = 37
        Me.pbAddressBookInfo.TabStop = False
        '
        'lblLogFile
        '
        Me.lblLogFile.AutoSize = True
        Me.lblLogFile.BackColor = System.Drawing.Color.Transparent
        Me.lblLogFile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogFile.Location = New System.Drawing.Point(186, 170)
        Me.lblLogFile.Name = "lblLogFile"
        Me.lblLogFile.Size = New System.Drawing.Size(0, 16)
        Me.lblLogFile.TabIndex = 38
        '
        'lblMessages
        '
        Me.lblMessages.AutoSize = True
        Me.lblMessages.BackColor = System.Drawing.Color.Transparent
        Me.lblMessages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessages.Location = New System.Drawing.Point(186, 246)
        Me.lblMessages.Name = "lblMessages"
        Me.lblMessages.Size = New System.Drawing.Size(0, 16)
        Me.lblMessages.TabIndex = 39
        '
        'bgMessageSize
        '
        Me.bgMessageSize.WorkerSupportsCancellation = True
        '
        'llblShowLogfile
        '
        Me.llblShowLogfile.AutoSize = True
        Me.llblShowLogfile.BackColor = System.Drawing.Color.Transparent
        Me.llblShowLogfile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblShowLogfile.Location = New System.Drawing.Point(292, 172)
        Me.llblShowLogfile.Name = "llblShowLogfile"
        Me.llblShowLogfile.Size = New System.Drawing.Size(81, 16)
        Me.llblShowLogfile.TabIndex = 46
        Me.llblShowLogfile.TabStop = True
        Me.llblShowLogfile.Text = "Show log file"
        Me.llblShowLogfile.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'pbReminderInfo
        '
        Me.pbReminderInfo.BackColor = System.Drawing.Color.Transparent
        Me.pbReminderInfo.Image = CType(resources.GetObject("pbReminderInfo.Image"), System.Drawing.Image)
        Me.pbReminderInfo.Location = New System.Drawing.Point(39, 271)
        Me.pbReminderInfo.Name = "pbReminderInfo"
        Me.pbReminderInfo.Size = New System.Drawing.Size(22, 22)
        Me.pbReminderInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbReminderInfo.TabIndex = 48
        Me.pbReminderInfo.TabStop = False
        '
        'chkReminders
        '
        Me.chkReminders.AutoSize = True
        Me.chkReminders.BackColor = System.Drawing.Color.Transparent
        Me.chkReminders.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkReminders.Location = New System.Drawing.Point(73, 271)
        Me.chkReminders.Name = "chkReminders"
        Me.chkReminders.Size = New System.Drawing.Size(89, 20)
        Me.chkReminders.TabIndex = 47
        Me.chkReminders.Text = "&Reminders"
        Me.chkReminders.UseVisualStyleBackColor = False
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
        Me.KryptonPanel.Controls.Add(Me.llblOpenLogFile)
        Me.KryptonPanel.Controls.Add(Me.chkRemovePasswordsFromSettings)
        Me.KryptonPanel.Controls.Add(Me.lblMessages)
        Me.KryptonPanel.Controls.Add(Me.pbReminderInfo)
        Me.KryptonPanel.Controls.Add(Me.lblLogFile)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.pbAddressBookInfo)
        Me.KryptonPanel.Controls.Add(Me.pbSettingsFileInfo)
        Me.KryptonPanel.Controls.Add(Me.chkReminders)
        Me.KryptonPanel.Controls.Add(Me.pbLogFileInfo)
        Me.KryptonPanel.Controls.Add(Me.llblShowLogfile)
        Me.KryptonPanel.Controls.Add(Me.btnSend)
        Me.KryptonPanel.Controls.Add(Me.chkLogFile)
        Me.KryptonPanel.Controls.Add(Me.chkSettings)
        Me.KryptonPanel.Controls.Add(Me.lblSMTPFrom)
        Me.KryptonPanel.Controls.Add(Me.Label1)
        Me.KryptonPanel.Controls.Add(Me.chkAddressBook)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(468, 376)
        Me.KryptonPanel.TabIndex = 49
        '
        'chkRemovePasswordsFromSettings
        '
        Me.chkRemovePasswordsFromSettings.AutoSize = True
        Me.chkRemovePasswordsFromSettings.BackColor = System.Drawing.Color.Transparent
        Me.chkRemovePasswordsFromSettings.Checked = True
        Me.chkRemovePasswordsFromSettings.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRemovePasswordsFromSettings.Enabled = False
        Me.chkRemovePasswordsFromSettings.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRemovePasswordsFromSettings.Location = New System.Drawing.Point(189, 201)
        Me.chkRemovePasswordsFromSettings.Name = "chkRemovePasswordsFromSettings"
        Me.chkRemovePasswordsFromSettings.Size = New System.Drawing.Size(227, 20)
        Me.chkRemovePasswordsFromSettings.TabIndex = 60
        Me.chkRemovePasswordsFromSettings.Text = "Remove &passwords before sending"
        Me.chkRemovePasswordsFromSettings.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.Location = New System.Drawing.Point(123, 331)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(102, 33)
        Me.btnCancel.TabIndex = 59
        Me.btnCancel.Values.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.btnCancel.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnCancel.Values.Text = "&Close"
        '
        'btnSend
        '
        Me.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSend.Location = New System.Drawing.Point(248, 331)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(102, 33)
        Me.btnSend.TabIndex = 58
        Me.btnSend.Values.Image = Global.TrulyMail.My.Resources.Resources.CheckMark_16
        Me.btnSend.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.btnSend.Values.Text = "Send"
        '
        'llblOpenLogFile
        '
        Me.llblOpenLogFile.AutoSize = True
        Me.llblOpenLogFile.BackColor = System.Drawing.Color.Transparent
        Me.llblOpenLogFile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblOpenLogFile.Location = New System.Drawing.Point(375, 172)
        Me.llblOpenLogFile.Name = "llblOpenLogFile"
        Me.llblOpenLogFile.Size = New System.Drawing.Size(39, 16)
        Me.llblOpenLogFile.TabIndex = 61
        Me.llblOpenLogFile.TabStop = True
        Me.llblOpenLogFile.Text = "Open"
        Me.llblOpenLogFile.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SendToSupport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(468, 376)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SendToSupport"
        Me.Text = "TrulyMail Support Center"
        Me.TopMost = True
        CType(Me.pbLogFileInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSettingsFileInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddressBookInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbReminderInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSMTPFrom As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkLogFile As System.Windows.Forms.CheckBox
    Friend WithEvents chkSettings As System.Windows.Forms.CheckBox
    Friend WithEvents chkAddressBook As System.Windows.Forms.CheckBox
    Friend WithEvents pbLogFileInfo As System.Windows.Forms.PictureBox
    Friend WithEvents pbSettingsFileInfo As System.Windows.Forms.PictureBox
    Friend WithEvents pbAddressBookInfo As System.Windows.Forms.PictureBox
    Friend WithEvents lblLogFile As System.Windows.Forms.Label
    Friend WithEvents lblMessages As System.Windows.Forms.Label
    Friend WithEvents bgMessageSize As System.ComponentModel.BackgroundWorker
    Friend WithEvents llblShowLogfile As System.Windows.Forms.LinkLabel
    Friend WithEvents pbReminderInfo As System.Windows.Forms.PictureBox
    Friend WithEvents chkReminders As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btnSend As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents chkRemovePasswordsFromSettings As System.Windows.Forms.CheckBox
    Friend WithEvents llblOpenLogFile As System.Windows.Forms.LinkLabel
End Class
