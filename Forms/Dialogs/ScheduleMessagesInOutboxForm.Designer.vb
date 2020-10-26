<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScheduleMessagesInOutboxForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScheduleMessagesInOutboxForm))
        Me.Label13 = New System.Windows.Forms.Label()
        Me.nudSendInterval = New System.Windows.Forms.NumericUpDown()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbtnSendNow = New System.Windows.Forms.RadioButton()
        Me.rbtnAtTime = New System.Windows.Forms.RadioButton()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblUpdateStatus = New System.Windows.Forms.Label()
        CType(Me.nudSendInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(279, 193)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 16)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "seconds."
        '
        'nudSendInterval
        '
        Me.nudSendInterval.Location = New System.Drawing.Point(200, 193)
        Me.nudSendInterval.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudSendInterval.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.nudSendInterval.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSendInterval.Name = "nudSendInterval"
        Me.nudSendInterval.Size = New System.Drawing.Size(73, 20)
        Me.nudSendInterval.TabIndex = 40
        Me.nudSendInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudSendInterval.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker1.Location = New System.Drawing.Point(553, 16)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(114, 20)
        Me.DateTimePicker1.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 16)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "First message to be sent at:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 193)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 16)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Schedule one message every:"
        '
        'rbtnSendNow
        '
        Me.rbtnSendNow.AutoSize = True
        Me.rbtnSendNow.Checked = True
        Me.rbtnSendNow.Location = New System.Drawing.Point(190, 41)
        Me.rbtnSendNow.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtnSendNow.Name = "rbtnSendNow"
        Me.rbtnSendNow.Size = New System.Drawing.Size(47, 17)
        Me.rbtnSendNow.TabIndex = 44
        Me.rbtnSendNow.TabStop = True
        Me.rbtnSendNow.Text = "Now"
        Me.rbtnSendNow.UseVisualStyleBackColor = True
        '
        'rbtnAtTime
        '
        Me.rbtnAtTime.AutoSize = True
        Me.rbtnAtTime.Location = New System.Drawing.Point(190, 16)
        Me.rbtnAtTime.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbtnAtTime.Name = "rbtnAtTime"
        Me.rbtnAtTime.Size = New System.Drawing.Size(98, 17)
        Me.rbtnAtTime.TabIndex = 45
        Me.rbtnAtTime.Text = "at specific time:"
        Me.rbtnAtTime.UseVisualStyleBackColor = True
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Enabled = False
        Me.MonthCalendar1.Location = New System.Drawing.Point(300, 16)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 46
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(235, 240)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 47
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.Location = New System.Drawing.Point(386, 240)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 48
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblUpdateStatus
        '
        Me.lblUpdateStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUpdateStatus.AutoSize = True
        Me.lblUpdateStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdateStatus.Location = New System.Drawing.Point(483, 240)
        Me.lblUpdateStatus.Name = "lblUpdateStatus"
        Me.lblUpdateStatus.Size = New System.Drawing.Size(28, 16)
        Me.lblUpdateStatus.TabIndex = 49
        Me.lblUpdateStatus.Text = "     "
        '
        'ScheduleMessagesInOutboxForm
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(675, 275)
        Me.Controls.Add(Me.lblUpdateStatus)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.rbtnAtTime)
        Me.Controls.Add(Me.rbtnSendNow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.nudSendInterval)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ScheduleMessagesInOutboxForm"
        Me.Text = "Schedule Messages in OutboxForm"
        CType(Me.nudSendInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents nudSendInterval As System.Windows.Forms.NumericUpDown
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbtnSendNow As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnAtTime As System.Windows.Forms.RadioButton
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblUpdateStatus As System.Windows.Forms.Label
End Class
