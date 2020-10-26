Public Class EncryptedWebmailPasswordSelector
    Public Class RecipItem
        Public Property ID As String
        Public Property Address As String
        Public Property FullName As String
        Public Property Question As String
        Public Property Password As String
        Public Property SaveContactPassword As Boolean
        Public Property PasswordStrength As String
    End Class

    Private m_lstRecipItems As List(Of RecipItem)
    Private m_lstRecipients As List(Of RecipientEntry)
    Private m_senderEntry As AddressBookEntry
    Public ReadOnly Property EncryptionPassword As String
        Get
            Return txtPassword.Text.Trim
        End Get
    End Property
    Public ReadOnly Property SaveEncryptionPassword As Boolean
        Get
            Return chkSavePasswordWithContacts.Checked
        End Get
    End Property
    Public Property RecipItems As List(Of RecipItem)
        Get
            Return m_lstRecipItems
        End Get
        Private Set(ByVal value As List(Of RecipItem))
            m_lstRecipItems = value
        End Set
    End Property
    Public Property ShowAttachmentPassword As Boolean
        Get
            Return lblAttachmentPassword.Visible
        End Get
        Set(ByVal value As Boolean)
            lblAttachmentPassword.Visible = value
            txtPassword.Visible = value
        End Set
    End Property
    Public Property AttachmentPassword As String
        Get
            Return txtPassword.Text
        End Get
        Set(ByVal value As String)
            txtPassword.Text = value
        End Set
    End Property
    ''' <summary>
    ''' This should be called for decryption (receiving)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal sender As AddressBookEntry)

        ' This call is required by the designer.
        InitializeComponent()

        m_senderEntry = sender

        If sender.ContactType = AddressBookEntryType.Email Then
            If sender.WebMailPassword.Trim.Length > 0 Then
                txtPassword.Text = sender.WebMailPassword.Trim
                chkSavePasswordWithContacts.Checked = True
            End If
        End If
    End Sub
    ''' <summary>
    ''' This should be called for encryption (sending)
    ''' </summary>
    ''' <param name="recipients"></param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal recipients As List(Of RecipientEntry))

        ' This call is required by the designer.
        InitializeComponent()

        m_lstRecipients = recipients

        For Each contact As RecipientEntry In m_lstRecipients
            If contact.ContactType = AddressBookEntryType.Email Then
                If contact.WebMessagePassword.Trim.Length > 0 Then
                    txtPassword.Text = contact.WebMessagePassword.Trim '-- just take the first one
                    chkSavePasswordWithContacts.Checked = True
                    Exit For
                End If
            End If
        Next
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If txtPassword.Text.Length = 0 Then
            ShowMessageBoxError("Please include a password for the encrypted email (all recipients will share the same password).")
            Exit Sub
        End If

        If chkSavePasswordWithContacts.Checked Then
            If m_senderEntry Is Nothing Then
                For Each recip In m_lstRecipients
                    recip.WebMessagePassword = txtPassword.Text.Trim
                Next
            Else
                m_senderEntry.WebMailPassword = txtPassword.Text.Trim
            End If
        End If
        AppSettings.ShowMessageEncryptionPassword = chkShowPassword.Checked
        ABook.Save()
        Me.DialogResult = DialogResult.OK
    End Sub
    Private Sub NotifyForm_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        SetForegroundWindow(Me.Handle)
        Me.chkShowPassword.Checked = AppSettings.ShowMessageEncryptionPassword

        If chkShowPassword.Checked Then
            Me.txtPassword.PasswordChar = ""
        Else
            Me.txtPassword.PasswordChar = "*"
        End If

    End Sub

    Private Sub txtPassword_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPassword.TextChanged
        SetPasswordStrengthLabel(txtPassword.Text, lblPasswordStrengthCaption, lblPasswordStrength)
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            Me.txtPassword.PasswordChar = ""
        Else
            Me.txtPassword.PasswordChar = "*"
        End If
    End Sub
End Class