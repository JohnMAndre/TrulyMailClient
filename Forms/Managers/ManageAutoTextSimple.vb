Public Class ManageAutoTextSimple

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AboutTrulyMailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutTrulyMailToolStripMenuItem.Click
        Using frm As New AboutBoxK()
            frm.ShowDialog()
        End Using
    End Sub
    Private Sub LoadAutoTexts()
        Dim intIndex As Integer = olvAutoTexts.SelectedIndex

        olvAutoTexts.SetObjects(AppSettings.AutoTexts)
        If intIndex > -1 Then
            olvAutoTexts.SelectedIndex = intIndex
        End If
    End Sub
    Private Sub AddAutoTextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAutoTextToolStripMenuItem.Click
        Dim auto As New AutoText
        auto.ID = Guid.NewGuid.ToString()
        auto.Name = "New AutoText"
        auto.Text = ""
        auto.HTML = False
        auto.IsNew = False
        auto.IsReply = False
        auto.IsForward = False
        auto.IsFollowUp = False
        AppSettings.AutoTexts.Add(auto)
        LoadAutoTexts()
        olvAutoTexts.SelectedObject = auto
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If olvAutoTexts.SelectedObject Is Nothing Then
            ShowMessageBoxError("Please select an AutoText to delete.")
        Else
            Dim auto As AutoText = CType(olvAutoTexts.SelectedObject, AutoText)
            AppSettings.AutoTexts.Remove(auto)
            olvAutoTexts.SelectedIndex = -1
            LoadAutoTexts()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If olvAutoTexts.SelectedObject Is Nothing Then
            ShowMessageBoxError("Please select an AutoText to update.")
        Else
            Dim auto As AutoText = CType(olvAutoTexts.SelectedObject, AutoText)
            auto.Name = txtName.Text
            auto.HTML = False
            auto.Text = txtAutoText.Text
            auto.IsNew = chkUseForNew.Checked
            '-- make sure this is the only autotext used for new messages
            If auto.IsNew Then
                For Each auto2 As AutoText In AppSettings.AutoTexts
                    If auto2 IsNot auto Then
                        auto2.IsNew = False
                    End If
                Next
            End If

            auto.IsReply = chkUseForReply.Checked
            '-- make sure this is the only autotext used for replies
            If auto.IsReply Then
                For Each auto2 As AutoText In AppSettings.AutoTexts
                    If auto2 IsNot auto Then
                        auto2.IsReply = False
                    End If
                Next
            End If

            auto.IsForward = chkUseForForward.Checked
            '-- make sure this is the only autotext used for forwards
            If auto.IsForward Then
                For Each auto2 As AutoText In AppSettings.AutoTexts
                    If auto2 IsNot auto Then
                        auto2.IsForward = False
                    End If
                Next
            End If

            auto.IsFollowUp = chkUseForFollowUp.Checked
            '-- make sure this is the only autotext used for follow-ups
            If auto.IsFollowUp Then
                For Each auto2 As AutoText In AppSettings.AutoTexts
                    If auto2 IsNot auto Then
                        auto2.IsFollowUp = False
                    End If
                Next
            End If

            Select Case cboHotKey.SelectedIndex
                Case 1 To 10 '-- Control
                    auto.KeyValue = Keys.D0 + cboHotKey.SelectedIndex - 1
                    auto.ModifierKeys = Keys.Control
                Case 11 To 20 '-- Control + Shift
                    auto.KeyValue = Keys.D0 + cboHotKey.SelectedIndex - 11
                    auto.ModifierKeys = Keys.Control Or Keys.Shift
                Case Else '-- 0 or -1
                    auto.KeyValue = 0
                    auto.ModifierKeys = 0
            End Select


            LoadAutoTexts()
        End If
    End Sub

    Private Sub olvAutoTexts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvAutoTexts.SelectedIndexChanged
        If olvAutoTexts.SelectedIndices.Count = 0 Then
            'SplitContainer1.Panel2Collapsed = True
        Else
            '-- load selected autotext
            Dim auto As AutoText = CType(olvAutoTexts.SelectedObject, AutoText)
            txtName.Text = auto.Name
            chkUseForNew.Checked = auto.IsNew
            chkUseForReply.Checked = auto.IsReply
            chkUseForForward.Checked = auto.IsForward
            chkUseForFollowUp.Checked = auto.IsFollowUp
            Dim intIndex As Integer = 0
            If auto.ModifierKeys = 0 Then
                '-- do nothing
            ElseIf (auto.ModifierKeys And Keys.Shift) = Keys.Shift Then
                '-- control and shift
                intIndex += 11

                '-- adjust for number
                intIndex -= Keys.D0
                intIndex += auto.KeyValue
            Else
                '-- just control
                intIndex += 1

                '-- adjust for number
                intIndex -= Keys.D0
                intIndex += auto.KeyValue
            End If

            cboHotKey.SelectedIndex = intIndex

            If auto.HTML Then
                txtAutoText.Text = StripHTML(auto.Text)
            Else
                txtAutoText.Text = auto.Text
            End If

            Application.DoEvents()

            btnSave.Enabled = False
        End If
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        btnSave.Enabled = True
    End Sub

    Private Sub txtAutoText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAutoText.TextChanged
        btnSave.Enabled = True
    End Sub

    Private Sub ManageAutoText_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim fontfam As New FontFamily(AppSettings.DefaultNewMessageFontName)
        txtAutoText.Font = New Font(fontfam, 12)

        For Each col As BrightIdeasSoftware.OLVColumn In olvAutoTexts.Columns
            If col.CheckBoxes Then
                col.AspectPutter = New BrightIdeasSoftware.AspectPutterDelegate(AddressOf DoNothingAspectPutter)
            End If
        Next

        LoadAutoTexts()
        LoadHotKeys()
    End Sub
    Private Class HotKeyInfo
        Public Text As String
        Public KeyValue As Keys
        Public ModifierKeys As Keys
        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class
    Private Sub LoadHotKeys()
        Dim info As New HotKeyInfo()
        info.Text = "<none>"
        info.KeyValue = 0
        info.ModifierKeys = 0
        cboHotKey.Items.Add(info)


        For intCounter As Integer = 0 To 9
            info = New HotKeyInfo
            info.Text = "Ctrl + " & intCounter.ToString()
            info.KeyValue = Keys.D0 + intCounter
            info.ModifierKeys = Keys.Control
            cboHotKey.Items.Add(info)
        Next

        For intCounter As Integer = 0 To 9
            info = New HotKeyInfo
            info.Text = "Ctrl + Shift + " & intCounter.ToString()
            info.KeyValue = Keys.D0 + intCounter
            info.ModifierKeys = Keys.Control Or Keys.Shift
            cboHotKey.Items.Add(info)
        Next
    End Sub

    Private Sub chkUseForNew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseForNew.CheckedChanged
        btnSave.Enabled = True
    End Sub

    Private Sub chkUseForReply_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseForReply.CheckedChanged
        btnSave.Enabled = True
    End Sub

    Private Sub chkUseForForward_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseForForward.CheckedChanged
        btnSave.Enabled = True
    End Sub

    Private Sub chkUseForFollowUp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseForFollowUp.CheckedChanged
        btnSave.Enabled = True
    End Sub

    Private Sub cboHotKey_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHotKey.SelectedIndexChanged
        btnSave.Enabled = True
    End Sub

End Class