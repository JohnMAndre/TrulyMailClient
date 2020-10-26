<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageResizePrompt
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
        Me.rbtn640 = New System.Windows.Forms.RadioButton()
        Me.rbtn800 = New System.Windows.Forms.RadioButton()
        Me.rbtn1024 = New System.Windows.Forms.RadioButton()
        Me.rbtnNone = New System.Windows.Forms.RadioButton()
        Me.cboPromptFrequency = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbtn1600 = New System.Windows.Forms.RadioButton()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'rbtn640
        '
        Me.rbtn640.AutoSize = True
        Me.rbtn640.BackColor = System.Drawing.Color.Transparent
        Me.rbtn640.Location = New System.Drawing.Point(16, 119)
        Me.rbtn640.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.rbtn640.Name = "rbtn640"
        Me.rbtn640.Size = New System.Drawing.Size(277, 20)
        Me.rbtn640.TabIndex = 0
        Me.rbtn640.TabStop = True
        Me.rbtn640.Text = "&Small (640 x 480) - about 50 KB per picture"
        Me.rbtn640.UseVisualStyleBackColor = False
        '
        'rbtn800
        '
        Me.rbtn800.AutoSize = True
        Me.rbtn800.BackColor = System.Drawing.Color.Transparent
        Me.rbtn800.Location = New System.Drawing.Point(16, 143)
        Me.rbtn800.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.rbtn800.Name = "rbtn800"
        Me.rbtn800.Size = New System.Drawing.Size(297, 20)
        Me.rbtn800.TabIndex = 1
        Me.rbtn800.TabStop = True
        Me.rbtn800.Text = "&Medium (800 x 600) - about 100 KB per picture"
        Me.rbtn800.UseVisualStyleBackColor = False
        '
        'rbtn1024
        '
        Me.rbtn1024.AutoSize = True
        Me.rbtn1024.BackColor = System.Drawing.Color.Transparent
        Me.rbtn1024.Location = New System.Drawing.Point(16, 165)
        Me.rbtn1024.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.rbtn1024.Name = "rbtn1024"
        Me.rbtn1024.Size = New System.Drawing.Size(290, 20)
        Me.rbtn1024.TabIndex = 2
        Me.rbtn1024.TabStop = True
        Me.rbtn1024.Text = "&Large (1024 x 768) - about 150 KB per picture"
        Me.rbtn1024.UseVisualStyleBackColor = False
        '
        'rbtnNone
        '
        Me.rbtnNone.AutoSize = True
        Me.rbtnNone.BackColor = System.Drawing.Color.Transparent
        Me.rbtnNone.Location = New System.Drawing.Point(16, 216)
        Me.rbtnNone.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.rbtnNone.Name = "rbtnNone"
        Me.rbtnNone.Size = New System.Drawing.Size(129, 20)
        Me.rbtnNone.TabIndex = 3
        Me.rbtnNone.TabStop = True
        Me.rbtnNone.Text = "&Keep original size"
        Me.rbtnNone.UseVisualStyleBackColor = False
        '
        'cboPromptFrequency
        '
        Me.cboPromptFrequency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPromptFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPromptFrequency.FormattingEnabled = True
        Me.cboPromptFrequency.Items.AddRange(New Object() {"Every image", "Once per message", "Never again (use current settings for future)"})
        Me.cboPromptFrequency.Location = New System.Drawing.Point(82, 247)
        Me.cboPromptFrequency.Margin = New System.Windows.Forms.Padding(2)
        Me.cboPromptFrequency.Name = "cboPromptFrequency"
        Me.cboPromptFrequency.Size = New System.Drawing.Size(282, 24)
        Me.cboPromptFrequency.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(356, 107)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Would you like to send smaller versions of your pictures (the original picture wi" & _
    "ll not be changed)?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Note: Images smaller than selection will not be resized (" & _
    "pictures will never be made larger)."
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(116, 295)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(65, 25)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(197, 295)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(65, 25)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 248)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 18)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Ask me:"
        '
        'rbtn1600
        '
        Me.rbtn1600.AutoSize = True
        Me.rbtn1600.BackColor = System.Drawing.Color.Transparent
        Me.rbtn1600.Location = New System.Drawing.Point(16, 190)
        Me.rbtn1600.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.rbtn1600.Name = "rbtn1600"
        Me.rbtn1600.Size = New System.Drawing.Size(332, 20)
        Me.rbtn1600.TabIndex = 9
        Me.rbtn1600.TabStop = True
        Me.rbtn1600.Text = "&Extra Large (1600 x 1200) - about 300 KB per picture"
        Me.rbtn1600.UseVisualStyleBackColor = False
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.btnOK)
        Me.KryptonPanel.Controls.Add(Me.rbtn1600)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.Label1)
        Me.KryptonPanel.Controls.Add(Me.cboPromptFrequency)
        Me.KryptonPanel.Controls.Add(Me.Label2)
        Me.KryptonPanel.Controls.Add(Me.rbtn640)
        Me.KryptonPanel.Controls.Add(Me.rbtn800)
        Me.KryptonPanel.Controls.Add(Me.rbtn1024)
        Me.KryptonPanel.Controls.Add(Me.rbtnNone)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(375, 331)
        Me.KryptonPanel.TabIndex = 10
        '
        'ImageResizePrompt
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(375, 331)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.Name = "ImageResizePrompt"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Resize Pictures"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rbtn640 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtn800 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtn1024 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnNone As System.Windows.Forms.RadioButton
    Friend WithEvents cboPromptFrequency As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbtn1600 As System.Windows.Forms.RadioButton
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
End Class
