Public Class ProcessRulesForm

    Private Sub btnNewRule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRule.Click
        NewRule()
    End Sub
    Private Sub NewRule()
        Dim frm As New EditProcessingRuleForm()
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            olvProcessingRules.AddObject(frm.NewRule)
        End If
    End Sub
    Private Sub ProcessRulesForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        AppSettings.Save()
    End Sub

    Private Sub ProcessRulesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        olvProcessingRules.SetObjects(AppSettings.ProcessingRules)
    End Sub
    Private Sub EditSelectedRule()
        If olvProcessingRules.SelectedIndex >= 0 Then
            Dim frm As New EditProcessingRuleForm(olvProcessingRules.GetSelectedObject())
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                olvProcessingRules.RefreshObject(olvProcessingRules.GetSelectedObject())
            End If
        Else
            ShowMessageBox("Please select a processing rule to edit.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub
    Private Sub btnEditRule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditRule.Click
        EditSelectedRule()
    End Sub
    Private Sub DeleteSelectedRule()
        If olvProcessingRules.SelectedIndex >= 0 Then
            If ShowMessageBox("Are you sure you want to delete this rule?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                AppSettings.ProcessingRules.Remove(olvProcessingRules.GetSelectedObject())
                olvProcessingRules.RemoveObject(olvProcessingRules.GetSelectedObject())
            End If
        Else
            ShowMessageBox("Please select a processing rule to delete.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If

    End Sub
    Private Sub btnDeleteRule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteRule.Click
        DeleteSelectedRule()
    End Sub
    Private Sub MoveSelectedRuleUp()
        If olvProcessingRules.SelectedIndex >= 0 Then
            If olvProcessingRules.SelectedIndex = 0 Then
                ShowMessageBox("The top item cannot be moved up.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                Dim rule As ProcessingRule = AppSettings.ProcessingRules(olvProcessingRules.SelectedIndex)
                Dim intNewIndex As Integer = olvProcessingRules.SelectedIndex - 1
                AppSettings.ProcessingRules.RemoveAt(olvProcessingRules.SelectedIndex)
                AppSettings.ProcessingRules.Insert(intNewIndex, rule)

                olvProcessingRules.MoveObjects(intNewIndex, olvProcessingRules.GetSelectedObjects())
                olvProcessingRules.SelectedObject = rule
            End If
        Else
            ShowMessageBox("Please select a processing rule to move.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub
    Private Sub btnMoveRuleUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveRuleUp.Click
        MoveSelectedRuleUp()
    End Sub

    Private Sub btnMoveRuleDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveRuleDown.Click
        MoveSelectedRuleDown()
    End Sub
    Private Sub MoveSelectedRuleDown()
        If olvProcessingRules.SelectedIndex >= 0 Then
            If olvProcessingRules.SelectedIndex = AppSettings.ProcessingRules.Count - 1 Then
                ShowMessageBox("The bottom item cannot be moved down.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                Dim rule As ProcessingRule = AppSettings.ProcessingRules(olvProcessingRules.SelectedIndex)
                AppSettings.ProcessingRules.RemoveAt(olvProcessingRules.SelectedIndex)
                AppSettings.ProcessingRules.Insert(olvProcessingRules.SelectedIndex + 1, rule)

                Dim intNewIndex As Integer = olvProcessingRules.SelectedIndex + 2
                olvProcessingRules.MoveObjects(intNewIndex, olvProcessingRules.GetSelectedObjects())
                olvProcessingRules.SelectedObject = rule
            End If
        Else
            ShowMessageBox("Please select a processing rule to move.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub
    Private Sub olvProcessingRules_CellEditStarting(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles olvProcessingRules.CellEditStarting
        Select Case e.Column.AspectName
            Case EnabledColumn.AspectName
                Dim chk As New CheckBox()
                chk.Checked = Convert.ToBoolean(e.Value)
                chk.Bounds = e.CellBounds
                chk.CheckAlign = ContentAlignment.MiddleCenter
                e.Control = chk
        End Select
    End Sub

    Private Sub olvProcessingRules_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvProcessingRules.ItemActivate
        EditSelectedRule()
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        EditSelectedRule()
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim boolOK As Boolean = (olvProcessingRules.SelectedIndex >= 0)
        EditToolStripMenuItem.Enabled = boolOK
        DeleteToolStripMenuItem.Enabled = boolOK
        MoveUpToolStripMenuItem.Enabled = boolOK
        MoveDownToolStripMenuItem.Enabled = boolOK
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        NewRule()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteSelectedRule()
    End Sub

    Private Sub MoveUpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveUpToolStripMenuItem.Click
        MoveSelectedRuleUp()
    End Sub

    Private Sub MoveDownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveDownToolStripMenuItem.Click
        MoveSelectedRuleDown()
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        txtFilter.Text = String.Empty
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        '-- only show contacts which match the filter
        olvProcessingRules.ModelFilter = New BrightIdeasSoftware.TextMatchFilter(olvProcessingRules, txtFilter.Text)
        If txtFilter.Text.Length > 0 Then
            txtFilter.BackColor = Color.Yellow
        Else
            txtFilter.BackColor = Color.White
        End If
    End Sub
End Class