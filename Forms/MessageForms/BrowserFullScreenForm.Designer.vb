<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrowserFullScreenForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BrowserFullScreenForm))
        Me.pnlTip = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picCloseTipPanel = New System.Windows.Forms.PictureBox()
        Me.chkDoNotShowTipPanel = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlCtrlDelete = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picCloseCtrlDeletePanel = New System.Windows.Forms.PictureBox()
        Me.chkDoNotShowCtrlDeletePanel = New System.Windows.Forms.CheckBox()
        Me.pnlShiftCtrlDelete = New System.Windows.Forms.Panel()
        Me.chkDoNotShowShiftCtrlDeletePanel = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.picCloseShiftCtrlDeletePanel = New System.Windows.Forms.PictureBox()
        Me.pnlTip.SuspendLayout()
        CType(Me.picCloseTipPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCtrlDelete.SuspendLayout()
        CType(Me.picCloseCtrlDeletePanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlShiftCtrlDelete.SuspendLayout()
        CType(Me.picCloseShiftCtrlDeletePanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTip
        '
        Me.pnlTip.AutoSize = True
        Me.pnlTip.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlTip.Controls.Add(Me.Label1)
        Me.pnlTip.Controls.Add(Me.picCloseTipPanel)
        Me.pnlTip.Controls.Add(Me.chkDoNotShowTipPanel)
        Me.pnlTip.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTip.Location = New System.Drawing.Point(0, 0)
        Me.pnlTip.Name = "pnlTip"
        Me.pnlTip.Size = New System.Drawing.Size(625, 24)
        Me.pnlTip.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(9, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(237, 19)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Press <Esc> or <F11> to close"
        '
        'picCloseTipPanel
        '
        Me.picCloseTipPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCloseTipPanel.Image = Global.TrulyMail.My.Resources.Resources.simpleX_16
        Me.picCloseTipPanel.Location = New System.Drawing.Point(612, 1)
        Me.picCloseTipPanel.Name = "picCloseTipPanel"
        Me.picCloseTipPanel.Size = New System.Drawing.Size(12, 12)
        Me.picCloseTipPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCloseTipPanel.TabIndex = 10
        Me.picCloseTipPanel.TabStop = False
        '
        'chkDoNotShowTipPanel
        '
        Me.chkDoNotShowTipPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDoNotShowTipPanel.AutoSize = True
        Me.chkDoNotShowTipPanel.Location = New System.Drawing.Point(483, 4)
        Me.chkDoNotShowTipPanel.Name = "chkDoNotShowTipPanel"
        Me.chkDoNotShowTipPanel.Size = New System.Drawing.Size(115, 17)
        Me.chkDoNotShowTipPanel.TabIndex = 11
        Me.chkDoNotShowTipPanel.Text = "Do not show again"
        Me.chkDoNotShowTipPanel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 72)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(625, 264)
        Me.Panel1.TabIndex = 4
        '
        'pnlCtrlDelete
        '
        Me.pnlCtrlDelete.AutoSize = True
        Me.pnlCtrlDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlCtrlDelete.Controls.Add(Me.Label2)
        Me.pnlCtrlDelete.Controls.Add(Me.picCloseCtrlDeletePanel)
        Me.pnlCtrlDelete.Controls.Add(Me.chkDoNotShowCtrlDeletePanel)
        Me.pnlCtrlDelete.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCtrlDelete.Location = New System.Drawing.Point(0, 24)
        Me.pnlCtrlDelete.Name = "pnlCtrlDelete"
        Me.pnlCtrlDelete.Size = New System.Drawing.Size(625, 24)
        Me.pnlCtrlDelete.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(9, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(301, 19)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Press <Ctrl>+<Del> to delete and close"
        '
        'picCloseCtrlDeletePanel
        '
        Me.picCloseCtrlDeletePanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCloseCtrlDeletePanel.Image = Global.TrulyMail.My.Resources.Resources.simpleX_16
        Me.picCloseCtrlDeletePanel.Location = New System.Drawing.Point(612, 1)
        Me.picCloseCtrlDeletePanel.Name = "picCloseCtrlDeletePanel"
        Me.picCloseCtrlDeletePanel.Size = New System.Drawing.Size(12, 12)
        Me.picCloseCtrlDeletePanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCloseCtrlDeletePanel.TabIndex = 10
        Me.picCloseCtrlDeletePanel.TabStop = False
        '
        'chkDoNotShowCtrlDeletePanel
        '
        Me.chkDoNotShowCtrlDeletePanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDoNotShowCtrlDeletePanel.AutoSize = True
        Me.chkDoNotShowCtrlDeletePanel.Location = New System.Drawing.Point(483, 4)
        Me.chkDoNotShowCtrlDeletePanel.Name = "chkDoNotShowCtrlDeletePanel"
        Me.chkDoNotShowCtrlDeletePanel.Size = New System.Drawing.Size(115, 17)
        Me.chkDoNotShowCtrlDeletePanel.TabIndex = 11
        Me.chkDoNotShowCtrlDeletePanel.Text = "Do not show again"
        Me.chkDoNotShowCtrlDeletePanel.UseVisualStyleBackColor = True
        '
        'pnlShiftCtrlDelete
        '
        Me.pnlShiftCtrlDelete.AutoSize = True
        Me.pnlShiftCtrlDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlShiftCtrlDelete.Controls.Add(Me.chkDoNotShowShiftCtrlDeletePanel)
        Me.pnlShiftCtrlDelete.Controls.Add(Me.Label3)
        Me.pnlShiftCtrlDelete.Controls.Add(Me.picCloseShiftCtrlDeletePanel)
        Me.pnlShiftCtrlDelete.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlShiftCtrlDelete.Location = New System.Drawing.Point(0, 48)
        Me.pnlShiftCtrlDelete.Name = "pnlShiftCtrlDelete"
        Me.pnlShiftCtrlDelete.Size = New System.Drawing.Size(625, 24)
        Me.pnlShiftCtrlDelete.TabIndex = 6
        '
        'chkDoNotShowShiftCtrlDeletePanel
        '
        Me.chkDoNotShowShiftCtrlDeletePanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDoNotShowShiftCtrlDeletePanel.AutoSize = True
        Me.chkDoNotShowShiftCtrlDeletePanel.Location = New System.Drawing.Point(483, 4)
        Me.chkDoNotShowShiftCtrlDeletePanel.Name = "chkDoNotShowShiftCtrlDeletePanel"
        Me.chkDoNotShowShiftCtrlDeletePanel.Size = New System.Drawing.Size(115, 17)
        Me.chkDoNotShowShiftCtrlDeletePanel.TabIndex = 11
        Me.chkDoNotShowShiftCtrlDeletePanel.Text = "Do not show again"
        Me.chkDoNotShowShiftCtrlDeletePanel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(9, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(465, 19)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Press <Shift>+<Ctrl>+<Del> to delete and load next message"
        '
        'picCloseShiftCtrlDeletePanel
        '
        Me.picCloseShiftCtrlDeletePanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCloseShiftCtrlDeletePanel.Image = Global.TrulyMail.My.Resources.Resources.simpleX_16
        Me.picCloseShiftCtrlDeletePanel.Location = New System.Drawing.Point(612, 1)
        Me.picCloseShiftCtrlDeletePanel.Name = "picCloseShiftCtrlDeletePanel"
        Me.picCloseShiftCtrlDeletePanel.Size = New System.Drawing.Size(12, 12)
        Me.picCloseShiftCtrlDeletePanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCloseShiftCtrlDeletePanel.TabIndex = 10
        Me.picCloseShiftCtrlDeletePanel.TabStop = False
        '
        'BrowserFullScreenForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(625, 336)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlShiftCtrlDelete)
        Me.Controls.Add(Me.pnlCtrlDelete)
        Me.Controls.Add(Me.pnlTip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "BrowserFullScreenForm"
        Me.pnlTip.ResumeLayout(False)
        Me.pnlTip.PerformLayout()
        CType(Me.picCloseTipPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCtrlDelete.ResumeLayout(False)
        Me.pnlCtrlDelete.PerformLayout()
        CType(Me.picCloseCtrlDeletePanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlShiftCtrlDelete.ResumeLayout(False)
        Me.pnlShiftCtrlDelete.PerformLayout()
        CType(Me.picCloseShiftCtrlDeletePanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlTip As System.Windows.Forms.Panel
    Friend WithEvents picCloseTipPanel As System.Windows.Forms.PictureBox
    Friend WithEvents chkDoNotShowTipPanel As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlCtrlDelete As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents picCloseCtrlDeletePanel As System.Windows.Forms.PictureBox
    Friend WithEvents chkDoNotShowCtrlDeletePanel As System.Windows.Forms.CheckBox
    Friend WithEvents pnlShiftCtrlDelete As System.Windows.Forms.Panel
    Friend WithEvents chkDoNotShowShiftCtrlDeletePanel As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents picCloseShiftCtrlDeletePanel As System.Windows.Forms.PictureBox
End Class
