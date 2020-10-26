Public Class ManageDoNotSendList

    Private Sub AboutTrulyMailToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutTrulyMailToolStripMenuItem.Click
        Using frm As New AboutBoxK()
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ClearAllDoNotSendContactsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearAllDoNotSendContactsToolStripMenuItem.Click
        Try
            If ShowMessageBox("Permanently remove all Do Not Send contacts?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) = Windows.Forms.DialogResult.Yes Then
                '-- Remove all
                'Dim obj As DoNotSendEmailAddress
                'For Each obj In olvDoNotSendContacts.Objects()
                '    AppSettings.DoNotSendAddressList.Remove(obj)
                '    olvDoNotSendContacts.RemoveObject(obj)
                'Next
                AppSettings.DoNotSendAddressList.Clear()
                olvDoNotSendContacts.SetObjects(AppSettings.DoNotSendAddressList)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error clearing Do Not Send contacts. " & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub
    Private Sub EditSelectedContact()
        If olvDoNotSendContacts.SelectedObject() IsNot Nothing Then
            Dim objDoNotSend As DoNotSendEmailAddress = CType(olvDoNotSendContacts.SelectedObject(), DoNotSendEmailAddress)
            txtContactName.Text = objDoNotSend.Name
            txtEmailAddress.Text = objDoNotSend.Address
            txtReason.Text = objDoNotSend.Reason
        End If
    End Sub
    Private Sub olvDoNotSendContacts_ItemActivate(sender As System.Object, e As System.EventArgs) Handles olvDoNotSendContacts.ItemActivate
        '-- Edit
        Try
            EditSelectedContact()
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error with the Do Not Send contact. " & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub AddAsNewDoNotSendContactToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddAsNewDoNotSendContactToolStripMenuItem.Click
        '-- Add new
        Try
            txtEmailAddress.Text = txtEmailAddress.Text.Trim()
            If IsValidEmailAddress(txtEmailAddress.Text.Trim()) Then
                For Each obj As DoNotSendEmailAddress In AppSettings.DoNotSendAddressList
                    If obj.Address.ToLower() = txtEmailAddress.Text.ToLower() Then
                        ShowMessageBoxError("There is already a Do Not Send contact with this address.")
                        Exit Sub
                    End If
                Next

                Dim objDoNotSend As New DoNotSendEmailAddress
                objDoNotSend.Address = txtEmailAddress.Text
                objDoNotSend.Name = txtContactName.Text
                objDoNotSend.Reason = txtReason.Text

                olvDoNotSendContacts.AddObject(objDoNotSend)
                AppSettings.DoNotSendAddressList.Add(objDoNotSend)

                txtEmailAddress.Focus()
                txtEmailAddress.Text = String.Empty
                txtContactName.Text = String.Empty
                txtReason.Text = String.Empty
            Else
                ShowMessageBoxError("Please enter a valid email address.")
                txtEmailAddress.Focus()
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error adding the Do Not Send contact. " & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub DeleteSelectedDoNotSendContactToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteSelectedDoNotSendContactToolStripMenuItem.Click
        '-- Delete selected item
        Try
            Dim intCount As Integer = olvDoNotSendContacts.SelectedObjects.Count

            If intCount = 1 Then
                '-- For single delete, default to yes
                Dim obj As DoNotSendEmailAddress = CType(olvDoNotSendContacts.SelectedObjects, DoNotSendEmailAddress)

                If ShowMessageBox("Permanently remove " & obj.Address & "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    '-- Remove one
                    AppSettings.DoNotSendAddressList.Remove(obj)
                    olvDoNotSendContacts.RemoveObject(obj)
                End If
            ElseIf intCount > 1 Then
                '-- for multiple default to No
                If ShowMessageBox("Are you sure you want to permanently remove these " & intCount.ToString("#,##0") & " Do Not Send contacts?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    '-- Remove multiple (could be all)
                    Dim obj As DoNotSendEmailAddress
                    For Each obj In olvDoNotSendContacts.SelectedObjects()
                        AppSettings.DoNotSendAddressList.Remove(obj)
                        olvDoNotSendContacts.RemoveObject(obj)
                    Next
                End If
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error deleting the Do Not Send contact(s). " & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub ManageDoNotSendList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            olvDoNotSendContacts.SetObjects(AppSettings.DoNotSendAddressList)
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error loading the Do Not Send contacts. " & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub
End Class