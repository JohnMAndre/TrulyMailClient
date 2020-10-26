<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AudioPlayer
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AudioPlayer))
        Me.picPlay = New System.Windows.Forms.PictureBox()
        Me.picStop = New System.Windows.Forms.PictureBox()
        Me.picMute = New System.Windows.Forms.PictureBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tmrUpdateStatus = New System.Windows.Forms.Timer(Me.components)
        Me.progressSlider = New MB.Controls.ColorSlider()
        Me.volumeSlider = New MB.Controls.ColorSlider()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.lblDuration = New System.Windows.Forms.Label()
        Me.tmrSeek = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.picPlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picPlay
        '
        Me.picPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picPlay.Image = CType(resources.GetObject("picPlay.Image"), System.Drawing.Image)
        Me.picPlay.Location = New System.Drawing.Point(2, 11)
        Me.picPlay.Name = "picPlay"
        Me.picPlay.Size = New System.Drawing.Size(32, 32)
        Me.picPlay.TabIndex = 1
        Me.picPlay.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picPlay, "Play")
        '
        'picStop
        '
        Me.picStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picStop.Image = CType(resources.GetObject("picStop.Image"), System.Drawing.Image)
        Me.picStop.Location = New System.Drawing.Point(40, 11)
        Me.picStop.Name = "picStop"
        Me.picStop.Size = New System.Drawing.Size(32, 32)
        Me.picStop.TabIndex = 2
        Me.picStop.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picStop, "Stop")
        '
        'picMute
        '
        Me.picMute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picMute.Image = CType(resources.GetObject("picMute.Image"), System.Drawing.Image)
        Me.picMute.Location = New System.Drawing.Point(78, 11)
        Me.picMute.Name = "picMute"
        Me.picMute.Size = New System.Drawing.Size(32, 32)
        Me.picMute.TabIndex = 3
        Me.picMute.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picMute, "Mute")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "speakerOff")
        Me.ImageList1.Images.SetKeyName(1, "speakerOn")
        Me.ImageList1.Images.SetKeyName(2, "pausebutton")
        Me.ImageList1.Images.SetKeyName(3, "stopbutton")
        Me.ImageList1.Images.SetKeyName(4, "playbutton")
        '
        'tmrUpdateStatus
        '
        Me.tmrUpdateStatus.Interval = 1000
        '
        'progressSlider
        '
        Me.progressSlider.BackColor = System.Drawing.Color.Transparent
        Me.progressSlider.BarInnerColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.progressSlider.BorderRoundRectSize = New System.Drawing.Size(8, 8)
        Me.progressSlider.Dock = System.Windows.Forms.DockStyle.Top
        Me.progressSlider.ElapsedInnerColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.progressSlider.LargeChange = CType(5UI, UInteger)
        Me.progressSlider.Location = New System.Drawing.Point(0, 0)
        Me.progressSlider.Name = "progressSlider"
        Me.progressSlider.Size = New System.Drawing.Size(231, 14)
        Me.progressSlider.SmallChange = CType(1UI, UInteger)
        Me.progressSlider.TabIndex = 4
        Me.progressSlider.Text = "ColorSlider1"
        Me.progressSlider.ThumbRoundRectSize = New System.Drawing.Size(8, 8)
        Me.progressSlider.Value = 0
        '
        'volumeSlider
        '
        Me.volumeSlider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.volumeSlider.BackColor = System.Drawing.Color.Transparent
        Me.volumeSlider.BarInnerColor = System.Drawing.Color.Silver
        Me.volumeSlider.BorderRoundRectSize = New System.Drawing.Size(8, 8)
        Me.volumeSlider.ElapsedInnerColor = System.Drawing.Color.Black
        Me.volumeSlider.LargeChange = CType(5UI, UInteger)
        Me.volumeSlider.Location = New System.Drawing.Point(116, 27)
        Me.volumeSlider.Name = "volumeSlider"
        Me.volumeSlider.Size = New System.Drawing.Size(107, 17)
        Me.volumeSlider.SmallChange = CType(1UI, UInteger)
        Me.volumeSlider.TabIndex = 5
        Me.volumeSlider.ThumbRoundRectSize = New System.Drawing.Size(8, 8)
        Me.volumeSlider.ThumbSize = 8
        Me.ToolTip1.SetToolTip(Me.volumeSlider, "Adjust volume")
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.Location = New System.Drawing.Point(119, 14)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(0, 13)
        Me.lblPosition.TabIndex = 6
        '
        'lblDuration
        '
        Me.lblDuration.AutoSize = True
        Me.lblDuration.Location = New System.Drawing.Point(179, 14)
        Me.lblDuration.Name = "lblDuration"
        Me.lblDuration.Size = New System.Drawing.Size(0, 13)
        Me.lblDuration.TabIndex = 7
        '
        'tmrSeek
        '
        Me.tmrSeek.Interval = 250
        '
        'AudioPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.lblDuration)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.volumeSlider)
        Me.Controls.Add(Me.progressSlider)
        Me.Controls.Add(Me.picMute)
        Me.Controls.Add(Me.picStop)
        Me.Controls.Add(Me.picPlay)
        Me.Name = "AudioPlayer"
        Me.Size = New System.Drawing.Size(231, 45)
        CType(Me.picPlay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMute, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picPlay As System.Windows.Forms.PictureBox
    Friend WithEvents picStop As System.Windows.Forms.PictureBox
    Friend WithEvents picMute As System.Windows.Forms.PictureBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tmrUpdateStatus As System.Windows.Forms.Timer
    Friend WithEvents progressSlider As MB.Controls.ColorSlider
    Friend WithEvents volumeSlider As MB.Controls.ColorSlider
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents lblDuration As System.Windows.Forms.Label
    Friend WithEvents tmrSeek As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
