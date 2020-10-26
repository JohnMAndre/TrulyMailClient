Public Class EditContact
    Private m_entry As AddressBookEntry
    Private m_boolCancel As Boolean
    Private m_dtLastReceivedAsEntered As Nullable(Of Date)
    Private m_dtLastSentAsEntered As Nullable(Of Date)
    Private m_imgLocal As Image
    Private m_imgWeb As Image
    Private m_boolEntryCreated As Boolean

    ''' <summary>
    ''' For adding a new email contact
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        m_entry = New AddressBookEntry(AddressBookEntryType.Email)
        m_boolEntryCreated = True


        txtFullName.Text = m_entry.FullName
        txtEmailAddress.Text = m_entry.Address
        chkActive.Checked = True
        lblDateAdded.Text = FormatDateTime(m_entry.AddedDisply)
        chkAutoRequestReturnReceipt.Checked = m_entry.AutoRequestReadReceipt
        cboAutoSendReturnReceipts.SelectedIndex = ConvertToInt32(m_entry.AutoSendReadReceipt, 0)
        chkBlocked.Checked = m_entry.Blocked
        pbContctType.Image = My.Resources.email_32
        ToolTip1.SetToolTip(pbContctType, "This is an email contact.")
        chkReceiveOnly.Checked = m_entry.ReceiveOnly
        chkRemoteImages.Checked = m_entry.RemoteImages
        txtTags.Text = m_entry.Tags

        rdoContactPictureNone.Checked = True
        rdoContactPictureCurrent.Enabled = False

        m_dtLastReceivedAsEntered = m_entry.LastMessageReceived
        m_dtLastSentAsEntered = m_entry.LastMessageSent

        UpdateLastMessageReceived()
        UpdateLastMessageSent()

        nudReminderReceived.Value = m_entry.RemindReceiveEveryXDays
        nudReminderSent.Value = m_entry.RemindSendEveryXDays

        nudImportance.Value = m_entry.ImportanceRating
        'cboEmailEncryption.SelectedIndex = CType(m_entry.EncryptMessages, Integer)

        cboBuiltInPicture.SelectedIndex = 0

        '-- other
        txtHomePhone.Text = m_entry.PhoneHome
        txtWorkPhone.Text = m_entry.PhoneWork
        txtMobilePhone.Text = m_entry.PhoneMobile
        txtWebPage.Text = m_entry.WebPage
        txtCustom1.Text = m_entry.Custom1
        txtCustom2.Text = m_entry.Custom2
        txtCustom3.Text = m_entry.Custom3
        txtCustom4.Text = m_entry.Custom4

        txtWebMessageQuestion.Text = m_entry.WebMailQuestion
        txtWebMessagePassword.Text = m_entry.WebMailPassword

        For Each profile As SMTPProfile In AppSettings.SMTPProfiles
            cboSMTPAccount.Items.Add(profile)
            'If m_entry.SMTPID.Length > 0 Then
            '    If profile.ID.ToLower = m_entry.SMTPID.ToLower Then
            '        cboSMTPAccount.SelectedIndex = cboSMTPAccount.Items.Count - 1
            '    End If
            'End If
        Next
        If m_entry.SMTPProfile IsNot Nothing Then
            cboSMTPAccount.SelectedItem = m_entry.SMTPProfile
        Else
            cboSMTPAccount.SelectedIndex = 0
        End If


        txtNotes.Text = m_entry.Notes
    End Sub
    Public Sub New(ByVal userID As String)

        ' This call is required by the designer.
        InitializeComponent()


        '-- Lookup and fill in form
        m_entry = ABook.GetContactByID(userID)
        If m_entry Is Nothing Then
            ShowMessageBoxError("This user was not found in your address book. Please contact TrulyMail Support.")
            m_boolCancel = True
        Else
            txtFullName.Text = m_entry.FullName
            txtEmailAddress.Text = m_entry.Address
            chkActive.Checked = m_entry.Active
            lblDateAdded.Text = FormatDateTime(m_entry.AddedDisply)
            chkAutoRequestReturnReceipt.Checked = m_entry.AutoRequestReadReceipt
            cboAutoSendReturnReceipts.SelectedIndex = ConvertToInt32(m_entry.AutoSendReadReceipt, 0)
            chkBlocked.Checked = m_entry.Blocked
            If m_entry.ContactType = AddressBookEntryType.TrulyMail Then
                pbContctType.Image = My.Resources.Securedmessage_32
                txtEmailAddress.Enabled = False
                lblEmailAddress.Enabled = False
                ToolTip1.SetToolTip(pbContctType, "This is a TrulyMail contact.")
                lblAutoSendReturnReceipts.Enabled = False
                cboAutoSendReturnReceipts.Enabled = False
                chkAutoRequestReturnReceipt.Enabled = False
                chkReceiveOnly.Enabled = False
                TabControl1.TabPages.Remove(tabEmail)
            Else
                pbContctType.Image = My.Resources.email_32
                ToolTip1.SetToolTip(pbContctType, "This is an email contact.")
            End If
            chkReceiveOnly.Checked = m_entry.ReceiveOnly
            chkRemoteImages.Checked = m_entry.RemoteImages
            txtTags.Text = m_entry.Tags

            If System.IO.File.Exists(GetContactPicturePath) Then
                rdoContactPictureCurrent.Checked = True
                pbContactPicture.Load(GetContactPicturePath)
            Else
                rdoContactPictureNone.Checked = True
                rdoContactPictureCurrent.Enabled = False
            End If

            m_dtLastReceivedAsEntered = m_entry.LastMessageReceived
            m_dtLastSentAsEntered = m_entry.LastMessageSent

            UpdateLastMessageReceived()
            UpdateLastMessageSent()

            nudReminderReceived.Value = m_entry.RemindReceiveEveryXDays
            nudReminderSent.Value = m_entry.RemindSendEveryXDays

            nudImportance.Value = m_entry.ImportanceRating
            'cboEmailEncryption.SelectedIndex = CType(m_entry.EncryptMessages, Integer)

            cboBuiltInPicture.SelectedIndex = 0

            '-- other
            txtHomePhone.Text = m_entry.PhoneHome
            txtWorkPhone.Text = m_entry.PhoneWork
            txtMobilePhone.Text = m_entry.PhoneMobile
            txtWebPage.Text = m_entry.WebPage
            txtCustom1.Text = m_entry.Custom1
            txtCustom2.Text = m_entry.Custom2
            txtCustom3.Text = m_entry.Custom3
            txtCustom4.Text = m_entry.Custom4

            txtWebMessageQuestion.Text = m_entry.WebMailQuestion
            txtWebMessagePassword.Text = m_entry.WebMailPassword

            For Each profile As SMTPProfile In AppSettings.SMTPProfiles
                cboSMTPAccount.Items.Add(profile)
                'If m_entry.SMTPID.Length > 0 Then
                '    If profile.ID.ToLower = m_entry.SMTPID.ToLower Then
                '        cboSMTPAccount.SelectedIndex = cboSMTPAccount.Items.Count - 1
                '    End If
                'End If
            Next
            If m_entry.SMTPProfile IsNot Nothing Then
                cboSMTPAccount.SelectedItem = m_entry.SMTPProfile
            Else
                cboSMTPAccount.SelectedIndex = 0
            End If


            txtNotes.Text = m_entry.Notes
        End If
    End Sub
    Private Function GetContactPicturePath() As String
        Return PictureRootPath & m_entry.ID & CONTACT_PICTURE_FILENAME_EXTENSION
    End Function
    Private Sub UpdateLastMessageReceived()
        If Not m_dtLastReceivedAsEntered.HasValue Then
            btnClearLastReceived.Hide()
            dtpLastMessageReceived.Value = Date.Today
            lblLastReceivedDate.Text = "No messages received from contact"
            lblLastMessageReceived.Text = "No messages received"
            lblLastMessageReceived.BackColor = Color.White
        Else
            dtpLastMessageReceived.Value = m_dtLastReceivedAsEntered.Value
            lblLastReceivedDate.Text = FormatDate(m_dtLastReceivedAsEntered.Value)
            Dim ts As TimeSpan = Date.UtcNow - m_dtLastReceivedAsEntered.Value
            Select Case ts.Days
                Case 0
                    lblLastMessageReceived.Text = "Message received today"
                Case 1
                    lblLastMessageReceived.Text = "Message received yesterday"
                Case Else
                    lblLastMessageReceived.Text = "Message received " & ts.Days.ToString("#,##0") & " days ago"
            End Select
            If nudReminderReceived.Value > 0 AndAlso ts.TotalDays >= nudReminderReceived.Value Then
                lblLastMessageReceived.BackColor = Color.Yellow
            Else
                lblLastMessageReceived.BackColor = Color.White
            End If
        End If
    End Sub
    Private Sub UpdateLastMessageSent()
        If Not m_dtLastSentAsEntered.HasValue Then
            btnClearLastSent.Hide()
            dtpLastMessageSent.Value = Date.Today
            lblLastSentDate.Text = "No messages sent to contact"
            lblLastMessageSent.Text = "No messages sent"
            lblLastMessageSent.BackColor = Color.White
        Else
            dtpLastMessageSent.Value = m_dtLastSentAsEntered.Value
            lblLastSentDate.Text = FormatDate(m_dtLastSentAsEntered.Value)
            Dim ts As TimeSpan = Date.UtcNow - m_dtLastSentAsEntered.Value
            Select Case ts.Days
                Case 0
                    lblLastMessageSent.Text = "Message sent today"
                Case 1
                    lblLastMessageSent.Text = "Message sent yesterday"
                Case Else
                    lblLastMessageSent.Text = "Message sent " & ts.Days.ToString("#,##0") & " days ago"
            End Select
            If nudReminderSent.Value > 0 AndAlso ts.TotalDays >= nudReminderSent.Value Then
                lblLastMessageSent.BackColor = Color.Yellow
            Else
                lblLastMessageSent.BackColor = Color.White
            End If
        End If
    End Sub

#Region " Control Changed Events "
    Private Sub txtFullName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFullName.TextChanged
        btnSave.Enabled = True
    End Sub

    Private Sub txtEmailAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmailAddress.TextChanged
        btnSave.Enabled = True
    End Sub

    Private Sub txtTags_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTags.TextChanged
        btnSave.Enabled = True
    End Sub

    Private Sub cboAutoSendReturnReceipts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAutoSendReturnReceipts.SelectedIndexChanged
        btnSave.Enabled = True
    End Sub

    Private Sub chkAutoRequestReturnReceipt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoRequestReturnReceipt.CheckedChanged
        btnSave.Enabled = True
    End Sub

    Private Sub chkBlocked_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnSave.Enabled = True
    End Sub

    Private Sub chkActive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnSave.Enabled = True
    End Sub

    Private Sub chkReceiveOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnSave.Enabled = True
    End Sub

    Private Sub chkRemoteImages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnSave.Enabled = True
    End Sub
#End Region

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtFullName.Text.Trim.Length = 0 Then
            ShowMessageBoxError("Contact's name is missing.")
            Exit Sub
        End If

        If m_entry.ContactType = AddressBookEntryType.Email AndAlso Not IsValidEmailAddress(txtEmailAddress.Text.Trim) Then
            ShowMessageBoxError("Contact's email address is not valid (must be in the format: user@domain.com).")
            Exit Sub
        End If

        '-- picture
        If rdoContactPictureNone.Checked Then
            If m_entry.Picture IsNot Nothing Then
                m_entry.Picture.Dispose()
            End If
            m_entry.Picture = Nothing
            If System.IO.File.Exists(GetContactPicturePath) Then
                System.IO.File.Delete(GetContactPicturePath)
            End If
        ElseIf rdoContactPictureCurrent.Checked Then
            '-- do nothing
        Else
            If pbContactPicture.Image Is Nothing Then
                ShowMessageBoxError("Please select a picture for this contact or choose the 'No picture' option.")
                Exit Sub
            Else
                '-- disconnect from existing picture file
                If m_entry.Picture IsNot Nothing Then
                    m_entry.Picture.Dispose()
                End If
                m_entry.Picture = Nothing

                Dim img As Image
                If rdoContactPictureWeb.Checked OrElse rdoContactPictureGravitar.Checked Then
                    img = m_imgWeb
                ElseIf rdoContactPictureBuiltIn.Checked Then
                    Select Case cboBuiltInPicture.SelectedIndex
                        Case 0
                            img = My.Resources.profile_female
                        Case 1
                            img = My.Resources.profile_male
                    End Select
                ElseIf rdoContactPictureThisComputer.Checked Then
                    img = m_imgLocal
                End If

                '-- either built-in, web, or local computer. Either way, save what's showing in the picturebox and be done
                '   if the image is larger than limit on any side, then resize so largest side is set to limit, ratio maintained
                Const MAX_LENGTH As Integer = 120
                If pbContactPicture.Image.Width > MAX_LENGTH OrElse
                    pbContactPicture.Image.Height > MAX_LENGTH Then

                    ResizeImage(img, GetContactPicturePath(), Imaging.ImageFormat.Png, MAX_LENGTH)
                Else
                    SaveImage(img, GetContactPicturePath(), Imaging.ImageFormat.Png)
                End If

                img.Dispose()
            End If
        End If

        m_entry.Tags = txtTags.Text.Trim
        m_entry.RemoteImages = chkRemoteImages.Checked
        m_entry.ReceiveOnly = chkReceiveOnly.Checked
        m_entry.FullName = txtFullName.Text.Trim
        m_entry.Blocked = chkBlocked.Checked
        m_entry.Active = chkActive.Checked
        m_entry.Address = txtEmailAddress.Text.Trim
        m_entry.AutoRequestReadReceipt = chkAutoRequestReturnReceipt.Checked
        m_entry.AutoSendReadReceipt = CType(cboAutoSendReturnReceipts.SelectedIndex, ContactReceiptOption)
        If dtpLastMessageReceived.Visible Then
            m_entry.LastMessageReceived = dtpLastMessageReceived.Value
        ElseIf m_dtLastReceivedAsEntered.HasValue Then
            m_entry.LastMessageReceived = m_dtLastReceivedAsEntered.Value
        Else
            m_entry.LastMessageReceived = Nothing
        End If

        If dtpLastMessageSent.Visible Then
            m_entry.LastMessageSent = dtpLastMessageSent.Value
        ElseIf m_dtLastSentAsEntered.HasValue Then
            m_entry.LastMessageSent = m_dtLastSentAsEntered.Value
        Else
            m_entry.LastMessageSent = Nothing
        End If

        m_entry.RemindReceiveEveryXDays = nudReminderReceived.Value
        m_entry.RemindSendEveryXDays = nudReminderSent.Value
        If System.IO.File.Exists(GetContactPicturePath()) Then
            m_entry.Picture = Image.FromFile(GetContactPicturePath())
        End If

        'm_entry.EncryptMessages = CType(cboEmailEncryption.SelectedIndex, EncryptMessagesOption)
        m_entry.ImportanceRating = nudImportance.Value

        '-- other
        m_entry.PhoneHome = txtHomePhone.Text
        m_entry.PhoneWork = txtWorkPhone.Text
        m_entry.PhoneMobile = txtMobilePhone.Text
        m_entry.WebPage = txtWebPage.Text
        m_entry.Custom1 = txtCustom1.Text
        m_entry.Custom2 = txtCustom2.Text
        m_entry.Custom3 = txtCustom3.Text
        m_entry.Custom4 = txtCustom4.Text

        m_entry.WebMailQuestion = txtWebMessageQuestion.Text
        m_entry.WebMailPassword = txtWebMessagePassword.Text

        If cboSMTPAccount.SelectedIndex = 0 Then
            m_entry.SMTPID = String.Empty '-- use default acct
        Else
            m_entry.SMTPProfile = CType(cboSMTPAccount.SelectedItem, SMTPProfile)
        End If
        m_entry.Notes = txtNotes.Text

        '-- add to address book if created
        If m_boolEntryCreated Then
            ABook.Add(m_entry)
        End If

        ABook.Save()
        Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim strMessage As String = String.Empty

        If m_boolEntryCreated Then
            '-- user is really canceling the creation process
            Close()
        Else
            If m_entry.FullName = SERVER_FULLNAME AndAlso m_entry.ContactType = AddressBookEntryType.TrulyMail Then
                ShowMessageBoxError("You cannot remove TrulyMail Server.")
                Exit Sub
            ElseIf m_entry.ContactType = AddressBookEntryType.TrulyMail Then
                strMessage = "Deleting TrulyMail contacts is the same as blocking them (which stops both of you from sending messages to each other)."
            Else
                strMessage = "Deleting email contacts will remove them from your address book but you can still send messages to each other."
            End If

            If ShowMessageBox(strMessage & Environment.NewLine & Environment.NewLine & _
                              "Are you sure you want to do this?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                              MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                DeleteUserFromAddressBook(m_entry)
                Close()
            End If
        End If

    End Sub

    Private Sub EditContact_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If m_boolCancel Then
            Close()
        End If
    End Sub

    Private Sub EditContact_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub btnChangePicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePicture.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "All Files|*.*"
        ofd.Title = "Select contact picture"

        If ofd.ShowDialog = DialogResult.OK Then
            Try
                m_imgLocal = Image.FromFile(ofd.FileName)
                pbContactPicture.Image = m_imgLocal
            Catch ex As Exception
                Log(ex)
            End Try
        End If
    End Sub

    Private Sub btnEditLastReceived_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditLastReceived.Click
        btnEditLastReceived.Hide()
        btnClearLastReceived.Hide()
        dtpLastMessageReceived.Show()
        dtpLastMessageReceived.BringToFront()
        dtpLastMessageReceived.MaxDate = Date.Today
        If m_dtLastReceivedAsEntered.HasValue Then
            dtpLastMessageReceived.Value = m_dtLastReceivedAsEntered
        End If

        UpdateDaysAgoReceived()
    End Sub

    Private Sub btnEditLastSent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditLastSent.Click
        btnEditLastSent.Hide()
        btnClearLastSent.Hide()

        dtpLastMessageSent.Show()
        dtpLastMessageSent.BringToFront()
        dtpLastMessageSent.MaxDate = Date.Today
        If m_dtLastSentAsEntered.HasValue Then
            dtpLastMessageSent.Value = m_dtLastSentAsEntered.Value
        End If

        UpdateDaysAgoSent()
    End Sub

    Private Sub UpdateDaysAgoReceived()
        Dim ts As TimeSpan = Date.Now - dtpLastMessageReceived.Value.Date
        lblLastMessageReceived.Text = "Message received " & ts.TotalDays.ToString("#,##0") & " day(s) ago"
        If nudReminderReceived.Value > 0 AndAlso ts.TotalDays >= nudReminderReceived.Value Then
            lblLastMessageReceived.BackColor = Color.Yellow
        Else
            lblLastMessageReceived.BackColor = Color.White
        End If
    End Sub
    Private Sub UpdateDaysAgoSent()
        Dim ts As TimeSpan = Date.Now - dtpLastMessageSent.Value.Date
        lblLastMessageSent.Text = "Message sent " & ts.TotalDays.ToString("#,##0") & " day(s) ago"
        If nudReminderSent.Value > 0 AndAlso ts.TotalDays >= nudReminderSent.Value Then
            lblLastMessageSent.BackColor = Color.Yellow
        Else
            lblLastMessageSent.BackColor = Color.White
        End If
    End Sub
    Private Sub dtpLastMessageSent_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLastMessageSent.ValueChanged
        UpdateDaysAgoSent()
    End Sub

    Private Sub dtpLastMessageReceived_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLastMessageReceived.ValueChanged
        UpdateDaysAgoReceived()
    End Sub

    Private Sub btnClearLastReceived_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLastReceived.Click
        btnClearLastReceived.Hide()
        m_dtLastReceivedAsEntered = Nothing
        UpdateLastMessageReceived()
    End Sub

    Private Sub btnClearLastSent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLastSent.Click
        btnClearLastSent.Hide()
        m_dtLastSentAsEntered = Nothing
        UpdateLastMessageSent()
    End Sub

    Private Sub nudReminderReceived_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudReminderReceived.ValueChanged
        UpdateDaysAgoReceived()
    End Sub

    Private Sub nudReminderSent_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudReminderSent.ValueChanged
        UpdateDaysAgoSent()
    End Sub

    Private Sub rdoContactPictureNone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoContactPictureNone.CheckedChanged
        If rdoContactPictureNone.Checked Then
            If pbContactPicture.Image IsNot Nothing Then
                pbContactPicture.Image = Nothing
            End If
        End If
    End Sub

    Private Sub rdoContactPictureBuiltIn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoContactPictureBuiltIn.CheckedChanged
        cboBuiltInPicture.Enabled = rdoContactPictureBuiltIn.Checked

        If rdoContactPictureBuiltIn.Checked Then
            SelectBuildInPicture()
        End If
    End Sub
    Private Sub SelectBuildInPicture()
        Select Case cboBuiltInPicture.SelectedIndex
            Case 0 '-- standard female
                pbContactPicture.Image = My.Resources.profile_female
            Case 1 '-- standard male
                pbContactPicture.Image = My.Resources.profile_male
        End Select
    End Sub
    Private Sub rdoContactPictureWeb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoContactPictureWeb.CheckedChanged
        txtPictureURL.Enabled = rdoContactPictureWeb.Checked
        btnRefreshPictureFromWeb.Enabled = rdoContactPictureWeb.Checked

        If rdoContactPictureWeb.Checked Then
            If pbContactPicture.Image IsNot Nothing Then
                pbContactPicture.Image = Nothing
            End If
            If m_imgWeb IsNot Nothing Then
                pbContactPicture.Image = m_imgWeb
            End If
        End If
    End Sub

    Private Sub rdoContactPictureThisComputer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoContactPictureThisComputer.CheckedChanged
        btnChangePicture.Enabled = rdoContactPictureThisComputer.Checked

        If rdoContactPictureThisComputer.Checked Then
            If pbContactPicture.Image IsNot Nothing Then
                pbContactPicture.Image = Nothing
            End If
            If m_imgLocal IsNot Nothing Then
                pbContactPicture.Image = m_imgLocal
            End If
        End If
    End Sub

    Private Sub btnRefreshPictureFromWeb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshPictureFromWeb.Click
        If IsValidURL(txtPictureURL.Text) Then
            Using wc As New System.Net.WebClient()
                m_imgWeb = Image.FromStream(wc.OpenRead(txtPictureURL.Text))
            End Using
            pbContactPicture.Image = m_imgWeb
        Else
            ShowMessageBoxError("Please check that your picture address starts with HTTP:// or HTTPS://")
        End If
    End Sub

    Private Sub rdoContactPictureCurrent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoContactPictureCurrent.CheckedChanged
        If rdoContactPictureCurrent.Checked AndAlso m_entry IsNot Nothing Then
            pbContactPicture.Load(GetContactPicturePath())
        End If
    End Sub

    Private Sub cboBuiltInPicture_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBuiltInPicture.SelectedIndexChanged
        If rdoContactPictureBuiltIn.Checked Then
            SelectBuildInPicture()
        End If
    End Sub

    Private Sub txtWebPage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtWebPage.LinkClicked
        Dim strURL As String = e.LinkText
        If IsValidURL(strURL) Then
            System.Diagnostics.Process.Start(strURL)
        Else
            ShowMessageBoxError("The address (" & strURL & ") does not appear to be a valid web address. If this is wrong, please notify TrulyMail Support.")
        End If
    End Sub

    Private Sub txtNotes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtNotes.LinkClicked
        Dim strURL As String = e.LinkText
        If IsValidURL(strURL) Then
            System.Diagnostics.Process.Start(strURL)
        Else
            ShowMessageBoxError("The address (" & strURL & ") does not appear to be a valid web address. If this is wrong, please notify TrulyMail Support.")
        End If
    End Sub

    Private Sub rdoContactPictureGravitar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoContactPictureGravitar.CheckedChanged
        btnLoadGravitar.Enabled = rdoContactPictureGravitar.Checked AndAlso m_entry.ContactType = AddressBookEntryType.Email
    End Sub

    Private Sub btnLoadGravitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadGravitar.Click
        btnLoadGravitar.Enabled = False

        Dim md As New System.Security.Cryptography.MD5CryptoServiceProvider()
        If m_entry.ContactType = AddressBookEntryType.Email Then
            Dim strEmail As String = txtEmailAddress.Text.Trim.ToLower()
            If IsValidEmailAddress(strEmail) Then
                Try
                    Dim arrData() As Byte
                    Dim arrHash() As Byte

                    arrData = System.Text.Encoding.UTF8.GetBytes(strEmail)
                    arrHash = md.ComputeHash(arrData)

                    Dim sb As New System.Text.StringBuilder(arrHash.Length)
                    For intCounter As Integer = 0 To arrHash.Length - 1
                        sb.Append(arrHash(intCounter).ToString("X2"))
                    Next

                    Dim strHash As String = sb.ToString().ToLower()

                    Dim strURL As String = "http://www.gravatar.com/avatar/" & strHash & "?s=200"
                    Using wc As New System.Net.WebClient()
                        m_imgWeb = Image.FromStream(wc.OpenRead(strURL))
                    End Using
                    pbContactPicture.Image = m_imgWeb
                Catch ex As Exception
                    Log(ex)
                    ShowMessageBoxError("There was an error loading the gravatar image.")
                End Try
            Else
                ShowMessageBoxError("Email address not in the proper format.")
                btnLoadGravitar.Enabled = True
            End If
        Else
            ShowMessageBoxError("TrulyMail contacts do not have email addresses and cannot use Gravatar.")
        End If
        
        

    End Sub

    Private Sub EditContact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txtTags.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtTags.AutoCompleteSource = AutoCompleteSource.CustomSource
            Dim col As New AutoCompleteStringCollection()

            Dim strNewTag As String
            For Each contact As AddressBookEntry In ABook.GetAllContacts
                Dim tags() As String = contact.Tags.Split(" "c)
                For intCounter As Integer = 0 To tags.Length - 1
                    strNewTag = tags(intCounter)
                    If strNewTag.Trim.Length > 0 Then
                        If Not col.Contains(strNewTag) Then
                            col.Add(strNewTag)
                        End If
                    End If
                Next
            Next

            txtTags.AutoCompleteCustomSource = col
        Catch ex As Exception
            Log(ex) '-- just log and contine, who cares if tags don't get added properly, not even worth notifying the user
        End Try
    End Sub
End Class