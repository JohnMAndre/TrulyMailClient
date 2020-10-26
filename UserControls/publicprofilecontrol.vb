Public Class PublicProfileControl

    Public Event Updated()
    Public Event Canceled()
    Public Event UpdateError(ByVal message As String)

    Private m_boolPublicChanged As Boolean

    Private Sub llblWhatMeanPublicProfile_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblWhatMeanPublicProfile.LinkClicked
        ShowMessageBox("Making your profile public means that anyone can " & _
                       "find you (based on any of the information " & _
                       "you enter here, including your name, email " & _
                       "address, and TrulyMail Address) using TrulyMail's search ability " & _
                       "(to send you an invitation to communicate with them). " & _
                       Environment.NewLine & Environment.NewLine & _
                       "If your profile is NOT public (if it is private), " & _
                       "then others can only find you if they know your " & _
                       "TrulyMail Address." & _
                       Environment.NewLine & Environment.NewLine & _
                        "If you want people to find you easily, check the box  " & _
                        "'Make my profile public' otherwise it will be hard  " & _
                        "for others to find you on TrulyMail.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

    End Sub

    Private Sub PublicProfileControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not DesignMode Then
            Try
                LoadBirthYears()
                LoadBirthMonths()
                LoadBirthDays()
                LoadCountries()
                LoadLanguages()
                cboGender.SelectedIndex = 0

                SetCurrentData()
            Catch ex As Exception
                Log(ex)
                ShowMessageBox("There was an error loading your existing profile. Please contact TrulyMail Support for assistance.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                RaiseEvent Canceled()
            End Try
        End If
    End Sub
    Private Sub SetCurrentData()
        Dim xElement As Xml.XmlElement

        xElement = AppSettings.PublicProfile.SelectSingleNode("//Country")
        If xElement IsNot Nothing Then
            For i As Integer = 0 To cboCountry.Items.Count - 1
                If cboCountry.Items(i).ToString().ToLower() = xElement.InnerText.ToLower() Then
                    cboCountry.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
        If cboCountry.SelectedIndex = -1 Then
            cboCountry.SelectedIndex = 0
        End If

        xElement = AppSettings.PublicProfile.SelectSingleNode("//Province")
        If xElement IsNot Nothing Then
            txtState.Text = xElement.InnerText
        End If

        xElement = AppSettings.PublicProfile.SelectSingleNode("//City")
        If xElement IsNot Nothing Then
            txtCity.Text = xElement.InnerText
        End If

        xElement = AppSettings.PublicProfile.SelectSingleNode("//Language")
        If xElement IsNot Nothing Then
            For i As Integer = 0 To cboLanguage.Items.Count - 1
                If cboLanguage.Items(i).ToString().ToLower() = xElement.InnerText.ToLower() Then
                    cboLanguage.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
        If cboLanguage.SelectedIndex = -1 Then
            cboLanguage.SelectedIndex = 0
        End If

        xElement = AppSettings.PublicProfile.SelectSingleNode("//Gender")
        If xElement IsNot Nothing Then
            If xElement.InnerText.ToLower() = "female" Then
                cboGender.SelectedIndex = 1
            ElseIf xElement.InnerText.ToLower() = "male" Then
                cboGender.SelectedIndex = 2
            Else
                cboGender.SelectedIndex = 0
            End If
        End If

        xElement = AppSettings.PublicProfile.SelectSingleNode("//BirthDay")
        If xElement IsNot Nothing Then
            For i As Integer = 0 To cboBirthDay.Items.Count - 1
                If cboBirthDay.Items(i).ToString().ToLower() = xElement.InnerText.ToLower() Then
                    cboBirthDay.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
        If cboBirthDay.SelectedIndex = -1 Then
            cboBirthDay.SelectedIndex = 0
        End If

        xElement = AppSettings.PublicProfile.SelectSingleNode("//BirthMonth")
        If xElement IsNot Nothing Then
            For i As Integer = 0 To cboBirthMonth.Items.Count - 1
                If xElement.InnerText = i.ToString() Then
                    cboBirthMonth.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
        If cboBirthMonth.SelectedIndex = -1 Then
            cboBirthMonth.SelectedIndex = 0
        End If

        xElement = AppSettings.PublicProfile.SelectSingleNode("//BirthYear")
        If xElement IsNot Nothing Then
            For i As Integer = 0 To cboBirthYear.Items.Count - 1
                If cboBirthYear.Items(i).ToString().ToLower() = xElement.InnerText.ToLower() Then
                    cboBirthYear.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
        If cboBirthYear.SelectedIndex = -1 Then
            cboBirthYear.SelectedIndex = 0
        End If

        xElement = AppSettings.PublicProfile.SelectSingleNode("//HomePhone")
        If xElement IsNot Nothing Then
            txtHomePhone.Text = xElement.InnerText
        End If

        xElement = AppSettings.PublicProfile.SelectSingleNode("//WorkPhone")
        If xElement IsNot Nothing Then
            txtOfficePhone.Text = xElement.InnerText
        End If

        xElement = AppSettings.PublicProfile.SelectSingleNode("//MobilePhone")
        If xElement IsNot Nothing Then
            txtMobilePhone.Text = xElement.InnerText
        End If

        xElement = AppSettings.PublicProfile.SelectSingleNode("//Website")
        If xElement IsNot Nothing Then
            txtWebsite.Text = xElement.InnerText
        End If
        If txtWebsite.Text.Length = 0 Then
            txtWebsite.Text = "http://"
        End If

        xElement = AppSettings.PublicProfile.SelectSingleNode("//AboutMe")
        If xElement IsNot Nothing Then
            txtAboutMe.Text = xElement.InnerText
        End If

        xElement = AppSettings.PublicProfile.SelectSingleNode("//PublicUser")
        If xElement IsNot Nothing Then
            chkPublicUser.Checked = (xElement.InnerText.ToLower() = "true")
        End If
    End Sub
#Region " Load ComboBoxes "
    Private Sub LoadCountries()
        Dim str As String = My.Resources.Countries.ResourceManager.GetObject("CountryList")
        Dim data() As String = str.Split(Environment.NewLine)

        cboCountry.Items.Add(String.Empty)
        For Each str In data
            cboCountry.Items.Add(str.Trim())
            Application.DoEvents()
        Next
        cboCountry.SelectedIndex = 0
    End Sub
    Private Sub LoadLanguages()
        Dim str As String = My.Resources.ResourceManager.GetObject("LanguageList")
        Dim data() As String = str.Split(Environment.NewLine)

        cboLanguage.Items.Add(String.Empty)
        For Each str In data
            cboLanguage.Items.Add(str.Trim())
            Application.DoEvents()
        Next
        cboLanguage.SelectedIndex = 0
    End Sub
    Private Sub LoadBirthYears()
        Dim intCurrentIndex As Integer = cboBirthYear.SelectedIndex

        cboBirthYear.Items.Clear()
        cboBirthYear.Items.Add(String.Empty)
        For i As Integer = 1900 To Date.Now.Year
            cboBirthYear.Items.Add(i)
            Application.DoEvents()
        Next

        cboBirthYear.SelectedIndex = 0

    End Sub
    Private Sub LoadBirthMonths()
        Dim intCurrentIndex As Integer = cboBirthMonth.SelectedIndex

        cboBirthMonth.Items.Clear()
        cboBirthMonth.Items.Add(String.Empty)

        For i As Integer = 1 To 12
            cboBirthMonth.Items.Add(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i))
        Next

        cboBirthMonth.SelectedIndex = 0

    End Sub
    Private Sub LoadBirthDays()
        Dim intCurrentIndex As Integer = cboBirthDay.SelectedIndex

        cboBirthDay.Items.Clear()
        Dim intMaxDays As Integer
        Select Case cboBirthMonth.SelectedIndex
            Case 1, 3, 5, 7, 8, 10, 12
                intMaxDays = 31
            Case 4, 6, 9, 11
                intMaxDays = 30
            Case 2
                intMaxDays = 29
            Case Else
                intMaxDays = 31
        End Select

        cboBirthDay.Items.Add(String.Empty)

        For i As Integer = 1 To intMaxDays
            cboBirthDay.Items.Add(i)
            Application.DoEvents()
        Next

        If cboBirthDay.Items.Count > intCurrentIndex Then
            cboBirthDay.SelectedIndex = intCurrentIndex
        Else
            cboBirthDay.SelectedIndex = 0
        End If
    End Sub
#End Region

    Private Sub cboBirthMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBirthMonth.SelectedIndexChanged
        LoadBirthDays()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        RaiseEvent Canceled()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Not m_boolPublicChanged AndAlso chkPublicUser.Checked = False Then
            Select Case ShowMessageBox("Do you want to make your profile public?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Case DialogResult.Yes
                    chkPublicUser.Checked = True
                    Application.DoEvents()
                Case DialogResult.No
                    '-- do nothing
                Case DialogResult.Cancel
                    '-- stop current process
                    Exit Sub
            End Select
        End If

        UpdateServer()
    End Sub

    Private Sub chkPublicUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPublicUser.CheckedChanged
        m_boolPublicChanged = True
    End Sub

    Public Sub UpdateServer()
        btnUpdate.Enabled = False
        btnCancel.Enabled = False
        Dim boolSuccess As Boolean
        Dim strMessage As String = String.Empty

        Dim ctx As String = GetContext(MainFormReference).ContextID
        If ctx.Length = 0 Then
            boolSuccess = False
            strMessage = "TrulyMail server could not be contacted so your profile could not be updated. Please try again later."
        Else
            Try
                Dim xDoc As New Xml.XmlDocument()
                Dim xRoot As Xml.XmlElement = xDoc.AppendChild(xDoc.CreateElement("TrulyMailProfile"))

                If cboCountry.SelectedIndex > 0 Then
                    xRoot.AppendChild(xDoc.CreateElement("Country")).InnerText = cboCountry.Items(cboCountry.SelectedIndex)
                Else
                    xRoot.AppendChild(xDoc.CreateElement("Country")).InnerText = String.Empty
                End If

                xRoot.AppendChild(xDoc.CreateElement("Province")).InnerText = txtState.Text
                xRoot.AppendChild(xDoc.CreateElement("City")).InnerText = txtCity.Text

                If cboLanguage.SelectedIndex > 0 Then
                    xRoot.AppendChild(xDoc.CreateElement("Language")).InnerText = cboLanguage.Items(cboLanguage.SelectedIndex)
                Else
                    xRoot.AppendChild(xDoc.CreateElement("Language")).InnerText = String.Empty
                End If

                If cboGender.SelectedIndex > 0 Then
                    xRoot.AppendChild(xDoc.CreateElement("Gender")).InnerText = cboGender.Items(cboGender.SelectedIndex)
                Else
                    xRoot.AppendChild(xDoc.CreateElement("Gender")).InnerText = String.Empty
                End If

                If cboBirthDay.SelectedIndex > 0 Then
                    xRoot.AppendChild(xDoc.CreateElement("BirthDay")).InnerText = cboBirthDay.SelectedIndex
                Else
                    xRoot.AppendChild(xDoc.CreateElement("BirthDay")).InnerText = String.Empty '-- 0 and -1 are the same here
                End If

                If cboBirthMonth.SelectedIndex > 0 Then
                    xRoot.AppendChild(xDoc.CreateElement("BirthMonth")).InnerText = cboBirthMonth.SelectedIndex
                Else
                    xRoot.AppendChild(xDoc.CreateElement("BirthMonth")).InnerText = String.Empty
                End If

                If cboBirthYear.SelectedIndex > 0 Then
                    xRoot.AppendChild(xDoc.CreateElement("BirthYear")).InnerText = cboBirthYear.Items(cboBirthYear.SelectedIndex)
                Else
                    xRoot.AppendChild(xDoc.CreateElement("BirthYear")).InnerText = String.Empty
                End If
                xRoot.AppendChild(xDoc.CreateElement("HomePhone")).InnerText = txtHomePhone.Text
                xRoot.AppendChild(xDoc.CreateElement("WorkPhone")).InnerText = txtOfficePhone.Text
                xRoot.AppendChild(xDoc.CreateElement("MobilePhone")).InnerText = txtMobilePhone.Text

                '-- ensure website is not simply a protocol
                Dim strWebSite As String = txtWebsite.Text
                If strWebSite.ToLower() = "http://" Then
                    strWebSite = String.Empty
                ElseIf strWebSite.ToLower() = "https://" Then
                    strWebSite = String.Empty
                Else
                    strMessage = "Website must start with http:// or https://"
                    boolSuccess = False
                End If

                xRoot.AppendChild(xDoc.CreateElement("Website")).InnerText = strWebSite
                xRoot.AppendChild(xDoc.CreateElement("AboutMe")).InnerText = txtAboutMe.Text
                xRoot.AppendChild(xDoc.CreateElement("PublicUser")).InnerText = chkPublicUser.Checked

                Dim xVersion As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement("Version"))
                xVersion.InnerText = Application.ProductVersion
                Dim xPortable As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement("Portable"))
                xPortable.InnerText = AppSettings.PortableProfile

                Dim strXML As String = EncryptTextAsymetric(xDoc.OuterXml(), SERVER_KEY_FILENAME)

                If WebServiceWrapper.UpdateProfile(ctx, strXML, STANDARD_SERVER_TIMEOUT) Then
                    '-- Updated
                    boolSuccess = True
                    '-- Remove two non-important nodes
                    xDoc.DocumentElement.RemoveChild(xVersion)
                    xDoc.DocumentElement.RemoveChild(xPortable)
                    '-- Save to settings
                    AppSettings.PublicProfile.LoadXml(xDoc.OuterXml())
                    AppSettings.Save()
                Else
                    '-- Timeout
                    strMessage = "TrulyMail server could not be contacted. Please try again or contact TrulyMail Support if this problem repeats."
                    boolSuccess = False
                End If
            Catch ex As Exception
                Log(ex)
                strMessage = "General error. Please try again or contact TrulyMail Support if this problem repeats"
                boolSuccess = False
            End Try

            If boolSuccess Then
                RaiseEvent Updated()

                '-- Make sure we do not show the notice to the user again
                AppSettings.LastNoticeForProfile = Date.Now().AddYears(10) '-- set next notice to 10 years from now
                AppSettings.Save()
            Else
                RaiseEvent UpdateError(strMessage)
            End If
        End If

        btnUpdate.Enabled = True
        btnCancel.Enabled = True

    End Sub
    Public Property ButtonsVisible As Boolean
        Get
            Return btnUpdate.Visible
        End Get
        Set(ByVal value As Boolean)
            btnUpdate.Visible = value
            btnCancel.Visible = value
            If value Then
                GroupBox1.Height = Me.Height - 100
            Else
                GroupBox1.Height = Me.Height - 60
            End If
        End Set
    End Property
    Public Property MakeProfilePublic As Boolean
        Get
            Return chkPublicUser.Checked
        End Get
        Set(ByVal value As Boolean)
            chkPublicUser.Checked = value
        End Set
    End Property
End Class

