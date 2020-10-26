<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DateSelectorK
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
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.MonthCalendar1 = New ComponentFactory.Krypton.Toolkit.KryptonMonthCalendar()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.llblDefaultTime = New System.Windows.Forms.LinkLabel()
        Me.llblSetDefaultTime = New System.Windows.Forms.LinkLabel()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.llblDefaultTime)
        Me.KryptonPanel.Controls.Add(Me.DateTimePicker1)
        Me.KryptonPanel.Controls.Add(Me.lblMessage)
        Me.KryptonPanel.Controls.Add(Me.btnCancel)
        Me.KryptonPanel.Controls.Add(Me.KryptonButton1)
        Me.KryptonPanel.Controls.Add(Me.MonthCalendar1)
        Me.KryptonPanel.Controls.Add(Me.llblSetDefaultTime)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Palette = Me.KryptonPalette1
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel.Size = New System.Drawing.Size(231, 319)
        Me.KryptonPanel.TabIndex = 0
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker1.Location = New System.Drawing.Point(7, 199)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(118, 22)
        Me.DateTimePicker1.TabIndex = 4
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(4, 220)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(224, 61)
        Me.lblMessage.TabIndex = 65
        Me.lblMessage.Text = "Send in..."
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(7, 284)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Palette = Me.KryptonPalette1
        Me.btnCancel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.btnCancel.Size = New System.Drawing.Size(103, 29)
        Me.btnCancel.TabIndex = 64
        Me.btnCancel.Values.Image = Global.TrulyMail.My.Resources.Resources.Erase_16
        Me.btnCancel.Values.Text = "&Cancel"
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.Common.StateCommon.Content.LongText.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.KryptonPalette1.Common.StateCommon.Content.Padding = New System.Windows.Forms.Padding(2)
        Me.KryptonPalette1.Common.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.KryptonPalette1.InputControlStyles.InputControlCommon.StateNormal.Content.LongText.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.KryptonPalette1.InputControlStyles.InputControlCommon.StateNormal.Content.ShortText.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.KryptonButton1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.KryptonButton1.Location = New System.Drawing.Point(122, 284)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Size = New System.Drawing.Size(103, 29)
        Me.KryptonButton1.TabIndex = 62
        Me.KryptonButton1.Values.Image = Global.TrulyMail.My.Resources.Resources.CheckMark_16
        Me.KryptonButton1.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.KryptonButton1.Values.Text = "&OK"
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.MonthCalendar1.Location = New System.Drawing.Point(0, 0)
        Me.MonthCalendar1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MonthCalendar1.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.Palette = Me.KryptonPalette1
        Me.MonthCalendar1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.MonthCalendar1.Size = New System.Drawing.Size(230, 192)
        Me.MonthCalendar1.TabIndex = 0
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPalette = Me.KryptonPalette1
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom
        '
        'llblDefaultTime
        '
        Me.llblDefaultTime.AutoSize = True
        Me.llblDefaultTime.BackColor = System.Drawing.Color.Transparent
        Me.llblDefaultTime.Location = New System.Drawing.Point(156, 202)
        Me.llblDefaultTime.Name = "llblDefaultTime"
        Me.llblDefaultTime.Size = New System.Drawing.Size(63, 16)
        Me.llblDefaultTime.TabIndex = 66
        Me.llblDefaultTime.TabStop = True
        Me.llblDefaultTime.Text = "12:34 AM"
        '
        'llblSetDefaultTime
        '
        Me.llblSetDefaultTime.AutoSize = True
        Me.llblSetDefaultTime.BackColor = System.Drawing.Color.Transparent
        Me.llblSetDefaultTime.Location = New System.Drawing.Point(128, 202)
        Me.llblSetDefaultTime.Name = "llblSetDefaultTime"
        Me.llblSetDefaultTime.Size = New System.Drawing.Size(26, 16)
        Me.llblSetDefaultTime.TabIndex = 67
        Me.llblSetDefaultTime.TabStop = True
        Me.llblSetDefaultTime.Text = "set"
        '
        'DateSelectorK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(231, 319)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DateSelectorK"
        Me.Palette = Me.KryptonPalette1
        Me.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Date"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents MonthCalendar1 As ComponentFactory.Krypton.Toolkit.KryptonMonthCalendar
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents llblDefaultTime As System.Windows.Forms.LinkLabel
    Friend WithEvents llblSetDefaultTime As System.Windows.Forms.LinkLabel
End Class
