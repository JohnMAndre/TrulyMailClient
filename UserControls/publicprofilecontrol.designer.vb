<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PublicProfileControl
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
        Me.chkPublicUser = New System.Windows.Forms.CheckBox()
        Me.llblWhatMeanPublicProfile = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtMobilePhone = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtOfficePhone = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtHomePhone = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtWebsite = New System.Windows.Forms.TextBox()
        Me.cboBirthDay = New System.Windows.Forms.ComboBox()
        Me.cboBirthMonth = New System.Windows.Forms.ComboBox()
        Me.cboBirthYear = New System.Windows.Forms.ComboBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.cboGender = New System.Windows.Forms.ComboBox()
        Me.cboLanguage = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCountry = New System.Windows.Forms.ComboBox()
        Me.txtAboutMe = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkPublicUser
        '
        Me.chkPublicUser.AutoSize = True
        Me.chkPublicUser.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPublicUser.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPublicUser.Location = New System.Drawing.Point(3, 13)
        Me.chkPublicUser.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkPublicUser.Name = "chkPublicUser"
        Me.chkPublicUser.Size = New System.Drawing.Size(182, 22)
        Me.chkPublicUser.TabIndex = 0
        Me.chkPublicUser.Text = "Make my profile public"
        Me.chkPublicUser.UseVisualStyleBackColor = True
        '
        'llblWhatMeanPublicProfile
        '
        Me.llblWhatMeanPublicProfile.AutoSize = True
        Me.llblWhatMeanPublicProfile.Location = New System.Drawing.Point(216, 16)
        Me.llblWhatMeanPublicProfile.Name = "llblWhatMeanPublicProfile"
        Me.llblWhatMeanPublicProfile.Size = New System.Drawing.Size(139, 16)
        Me.llblWhatMeanPublicProfile.TabIndex = 1
        Me.llblWhatMeanPublicProfile.TabStop = True
        Me.llblWhatMeanPublicProfile.Text = "What does this mean?"
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.txtMobilePhone)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtOfficePhone)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtHomePhone)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtWebsite)
        Me.GroupBox1.Controls.Add(Me.cboBirthDay)
        Me.GroupBox1.Controls.Add(Me.cboBirthMonth)
        Me.GroupBox1.Controls.Add(Me.cboBirthYear)
        Me.GroupBox1.Controls.Add(Me.txtCity)
        Me.GroupBox1.Controls.Add(Me.txtState)
        Me.GroupBox1.Controls.Add(Me.cboGender)
        Me.GroupBox1.Controls.Add(Me.cboLanguage)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboCountry)
        Me.GroupBox1.Controls.Add(Me.txtAboutMe)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(593, 252)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User Profile"
        '
        'txtMobilePhone
        '
        Me.txtMobilePhone.Location = New System.Drawing.Point(430, 91)
        Me.txtMobilePhone.MaxLength = 50
        Me.txtMobilePhone.Name = "txtMobilePhone"
        Me.txtMobilePhone.Size = New System.Drawing.Size(156, 22)
        Me.txtMobilePhone.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(335, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Mobile phone:"
        '
        'txtOfficePhone
        '
        Me.txtOfficePhone.Location = New System.Drawing.Point(430, 63)
        Me.txtOfficePhone.MaxLength = 50
        Me.txtOfficePhone.Name = "txtOfficePhone"
        Me.txtOfficePhone.Size = New System.Drawing.Size(156, 22)
        Me.txtOfficePhone.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(335, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 16)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Office phone:"
        '
        'txtHomePhone
        '
        Me.txtHomePhone.Location = New System.Drawing.Point(430, 33)
        Me.txtHomePhone.MaxLength = 50
        Me.txtHomePhone.Name = "txtHomePhone"
        Me.txtHomePhone.Size = New System.Drawing.Size(156, 22)
        Me.txtHomePhone.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(335, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Home phone:"
        '
        'txtWebsite
        '
        Me.txtWebsite.Location = New System.Drawing.Point(121, 209)
        Me.txtWebsite.MaxLength = 255
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.Size = New System.Drawing.Size(197, 22)
        Me.txtWebsite.TabIndex = 10
        Me.txtWebsite.Text = "http://"
        '
        'cboBirthDay
        '
        Me.cboBirthDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBirthDay.FormattingEnabled = True
        Me.cboBirthDay.Location = New System.Drawing.Point(121, 179)
        Me.cboBirthDay.Name = "cboBirthDay"
        Me.cboBirthDay.Size = New System.Drawing.Size(42, 24)
        Me.cboBirthDay.TabIndex = 7
        '
        'cboBirthMonth
        '
        Me.cboBirthMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBirthMonth.FormattingEnabled = True
        Me.cboBirthMonth.Items.AddRange(New Object() {"", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboBirthMonth.Location = New System.Drawing.Point(169, 179)
        Me.cboBirthMonth.Name = "cboBirthMonth"
        Me.cboBirthMonth.Size = New System.Drawing.Size(89, 24)
        Me.cboBirthMonth.TabIndex = 8
        '
        'cboBirthYear
        '
        Me.cboBirthYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBirthYear.FormattingEnabled = True
        Me.cboBirthYear.Location = New System.Drawing.Point(264, 179)
        Me.cboBirthYear.Name = "cboBirthYear"
        Me.cboBirthYear.Size = New System.Drawing.Size(56, 24)
        Me.cboBirthYear.TabIndex = 9
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(121, 91)
        Me.txtCity.MaxLength = 100
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(197, 22)
        Me.txtCity.TabIndex = 4
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(121, 63)
        Me.txtState.MaxLength = 100
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(197, 22)
        Me.txtState.TabIndex = 3
        '
        'cboGender
        '
        Me.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGender.FormattingEnabled = True
        Me.cboGender.Items.AddRange(New Object() {"", "Female", "Male"})
        Me.cboGender.Location = New System.Drawing.Point(121, 149)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(197, 24)
        Me.cboGender.TabIndex = 6
        '
        'cboLanguage
        '
        Me.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLanguage.FormattingEnabled = True
        Me.cboLanguage.Location = New System.Drawing.Point(121, 119)
        Me.cboLanguage.Name = "cboLanguage"
        Me.cboLanguage.Size = New System.Drawing.Size(197, 24)
        Me.cboLanguage.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(335, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "About me:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 152)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 16)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Gender:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 182)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Birth date:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 212)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Website:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Language:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "City:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "State / Province:"
        '
        'cboCountry
        '
        Me.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCountry.FormattingEnabled = True
        Me.cboCountry.Location = New System.Drawing.Point(121, 33)
        Me.cboCountry.Name = "cboCountry"
        Me.cboCountry.Size = New System.Drawing.Size(197, 24)
        Me.cboCountry.TabIndex = 2
        '
        'txtAboutMe
        '
        Me.txtAboutMe.Location = New System.Drawing.Point(430, 119)
        Me.txtAboutMe.MaxLength = 50
        Me.txtAboutMe.Multiline = True
        Me.txtAboutMe.Name = "txtAboutMe"
        Me.txtAboutMe.Size = New System.Drawing.Size(156, 109)
        Me.txtAboutMe.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Country / Region:"
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.Location = New System.Drawing.Point(312, 312)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(115, 28)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "&Cancel Changes"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.AutoSize = True
        Me.btnUpdate.Location = New System.Drawing.Point(178, 312)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(115, 28)
        Me.btnUpdate.TabIndex = 15
        Me.btnUpdate.Text = "&Update Profile"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel1.Controls.Add(Me.chkPublicUser)
        Me.Panel1.Controls.Add(Me.llblWhatMeanPublicProfile)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(600, 39)
        Me.Panel1.TabIndex = 26
        '
        'PublicProfileControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "PublicProfileControl"
        Me.Size = New System.Drawing.Size(600, 350)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkPublicUser As System.Windows.Forms.CheckBox
    Friend WithEvents llblWhatMeanPublicProfile As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCountry As System.Windows.Forms.ComboBox
    Friend WithEvents txtAboutMe As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtWebsite As System.Windows.Forms.TextBox
    Friend WithEvents cboBirthDay As System.Windows.Forms.ComboBox
    Friend WithEvents cboBirthMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cboBirthYear As System.Windows.Forms.ComboBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents cboGender As System.Windows.Forms.ComboBox
    Friend WithEvents cboLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMobilePhone As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOfficePhone As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtHomePhone As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
