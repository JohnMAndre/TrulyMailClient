Public Class AccountList

    Private Sub AccountSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetToolStripIcons(AppSettings.LargeToolbarIcons)
        LoadPOP()
        LoadSMTP()

        If AppSettings.POPProfiles.Count = 0 Then
            AddNewAccount()
        End If
    End Sub
    Private Sub SetToolStripIcons(ByVal toLarge As Boolean)
        If toLarge Then
            '-- Switching from normal, small icons to large icons
            Me.ToolStrip1.ImageScalingSize = New Size(32, 32)
            Me.ToolStrip1.Height = TOOLBAR_32_HEIGHT

            AddAccountToolStripButton.Image = My.Resources.Editpencil_32
            EditAccountToolStripButton.Image = My.Resources.Checkboxes_32
            DeleteAccountToolStripButton.Image = My.Resources.Erase_32
        Else
            '-- Switching from large icons to small, normal icons
            Me.ToolStrip1.ImageScalingSize = New Size(16, 16)
            Me.ToolStrip1.Height = TOOLBAR_16_HEIGHT

            AddAccountToolStripButton.Image = My.Resources.Editpencil_16
            EditAccountToolStripButton.Image = My.Resources.Checkboxes_16
            DeleteAccountToolStripButton.Image = My.Resources.Erase_16
        End If

        SetupToolStripForText(ToolStrip1)

    End Sub
    Private Function RowFormatterPOP(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim pop As POPProfile = CType(olvi.RowObject, POPProfile)
        If pop.DownloadAtInterval = False Then
            olvi.SubItems(9).Text = String.Empty '-- download freq. has no meaning if we do not download at freq
        End If

        If pop.EncryptedPassword.Length > 0 Then
            olvi.SubItems(4).Text = "Saved"
        End If


        '-- Show SMTP account name so user can see on other tab
        For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
            If smtp.ID = pop.SMTPProfileID Then
                olvi.SubItems(14).Text = smtp.Name
            End If
        Next
    End Function
    Private Function RowFormatterSMTP(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim smtp As SMTPProfile = CType(olvi.RowObject, SMTPProfile)
        If smtp.EncryptedPassword.Length > 0 Then
            olvi.SubItems(9).Text = "Saved"
        End If
    End Function
    Private Sub LoadPOP()
        olvPOPAccounts.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf RowFormatterPOP)
        olvPOPAccounts.ClearObjects()
        olvPOPAccounts.SetObjects(AppSettings.POPProfiles)
        AutoSizeColumns(olvPOPAccounts)
    End Sub
    Private Sub LoadSMTP()
        olvSMTPAccounts.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf RowFormatterSMTP)
        olvSMTPAccounts.SetObjects(AppSettings.SMTPProfiles)
        AutoSizeColumns(olvSMTPAccounts)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutTrulyMailClientToolStripMenuItem.Click
        Using frm As New AboutBoxK()
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AddNewAccount()
        Dim frm As New AddEmailGuide() ' NewAccount()
        frm.ShowDialog(Me)
        LoadPOP()
        LoadSMTP()
    End Sub
    Private Sub DeletePOPAccount(ByVal id As String)
        For Each pop As POPProfile In AppSettings.POPProfiles
            If pop.ID = id Then
                AppSettings.POPProfiles.Remove(pop)
                AppSettings.Save()
                Exit For
            End If
        Next
    End Sub
    Private Sub DeleteSMTPAccount(ByVal id As String)
        For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
            If smtp.ID = id Then
                AppSettings.SMTPProfiles.Remove(smtp)
                AppSettings.Save()
                Exit For
            End If
        Next
    End Sub
    Private Sub DeleteSelectedAccount()
        Select Case TabControl1.SelectedIndex
            Case 0
                '-- Deleting POP
                '   first, check if the connected SMTP is only connected to this pop account
                '   If so, prompt user to delete both (yes=both, no=just pop, cancel=do nothing)
                '   otherwise, prompt user to confirm deletion of smtp
                '   also let user know that they should backup before making big changes
                If olvPOPAccounts.SelectedObjects.Count = 0 Then
                    ShowMessageBox("Please select a receiving account to delete.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    Dim pop As POPProfile = CType(olvPOPAccounts.GetSelectedObject(), POPProfile)
                    Dim strSMTPID As String = pop.SMTPProfileID
                    Dim intRelations As Integer = 0
                    For Each smtp As SMTPProfile In AppSettings.SMTPProfiles
                        If smtp.ID = strSMTPID Then
                            intRelations += 1
                        End If
                    Next
                    If intRelations > 1 Then
                        If ShowMessageBox("The related sending account is related to other receiving accounts so it will not be removed." _
                                          & Environment.NewLine & Environment.NewLine & _
                                          "Are you sure you want to remove this receiving account?" _
                                          & Environment.NewLine & Environment.NewLine & _
                                          "Yes = Delete 1 receiving account" & Environment.NewLine & _
                                          "No = Do nothing", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            '-- delete only POP account
                            DeletePOPAccount(pop.ID)
                        Else
                            '-- do nothing
                        End If
                    Else
                        Select Case ShowMessageBox("The related sending account is related only to this receiving account." _
                                          & Environment.NewLine & Environment.NewLine & _
                                          "Do you want to remove this sending account also?" _
                                          & Environment.NewLine & Environment.NewLine & _
                                          "Yes = Delete 1 receiving and 1 sending account" & Environment.NewLine & _
                                          "No = Delete 1 receiving account" & Environment.NewLine & _
                                          "Cancel = Do nothing", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
                            Case Windows.Forms.DialogResult.Yes
                                '-- delete POP and SMTP accounts
                                DeletePOPAccount(pop.ID)
                                DeleteSMTPAccount(strSMTPID)
                            Case Windows.Forms.DialogResult.No
                                '-- delete only POP account
                                DeletePOPAccount(pop.ID)
                            Case Windows.Forms.DialogResult.Cancel
                                '-- do nothing
                        End Select
                    End If
                End If
            Case 1
                If olvSMTPAccounts.SelectedObjects.Count = 0 Then
                    ShowMessageBox("Please select a sending account to delete.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    '-- Delete SMTP
                    '-- First, check if this SMTP is only connect to one POP account
                    '   if so, prompt user to delete both (yes=both, no=just smtp, cancel=do nothing
                    '   otherwise, prompt user to confirm deletion of smtp
                    '   also let user know that they should backup before making big changes
                    Dim smtp As SMTPProfile = CType(olvSMTPAccounts.GetSelectedObject(), SMTPProfile)
                    Dim intRelations As Integer = 0
                    For Each pop As POPProfile In AppSettings.POPProfiles
                        If pop.SMTPProfileID = smtp.ID Then
                            intRelations += 1
                        End If
                    Next

                    Select Case intRelations
                        Case 0
                            If ShowMessageBox("Are you sure you want to delete this sending account?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                DeleteSMTPAccount(smtp.ID)
                            End If
                        Case 1
                            If ShowMessageBox("The selected sending account is related to a receiving account. This related receiving account will also be removed." _
                                    & Environment.NewLine & Environment.NewLine & _
                                    "Are you sure you want to remove this semdomg account and the related receiving account?" _
                                    & Environment.NewLine & Environment.NewLine & _
                                    "Yes = Delete 1 sending and 1 receiving account" & Environment.NewLine & _
                                    "No = Do nothing", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                '-- delete only POP account
                                For Each pop As POPProfile In AppSettings.POPProfiles
                                    If pop.SMTPProfileID = smtp.ID Then
                                        DeletePOPAccount(pop.ID)
                                        Exit For
                                    End If
                                Next
                                DeleteSMTPAccount(smtp.ID)
                            Else
                                '-- do nothing
                            End If
                        Case Else
                            If ShowMessageBox("The selected sending account is related to multiple receiving accounts. All (" & intRelations.ToString() & ") related receiving accounts will also be removed." _
                                                  & Environment.NewLine & Environment.NewLine & _
                                                  "Are you sure you want to remove this sending account and all (" & intRelations.ToString() & ") related receiving accounts?" _
                                                  & Environment.NewLine & Environment.NewLine & _
                                                  "Yes = Delete 1 sending and " & intRelations.ToString() & " receiving accounts" & Environment.NewLine & _
                                                  "No = Do nothing", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                '-- delete only POP account
                                For Each pop As POPProfile In AppSettings.POPProfiles
                                    If pop.SMTPProfileID = smtp.ID Then
                                        DeletePOPAccount(pop.ID)
                                    End If
                                Next
                                DeleteSMTPAccount(smtp.ID)
                            Else
                                '-- do nothing
                            End If
                    End Select
                End If
        End Select

        LoadPOP()
        LoadSMTP()
    End Sub

    Private Sub EditSelectedAccount()
        Select Case TabControl1.SelectedIndex
            Case 0
                '-- POP
                If olvPOPAccounts.SelectedObjects.Count = 1 Then
                    Dim frm As New NewAccount(CType(olvPOPAccounts.GetSelectedObject(), POPProfile))
                    frm.ShowDialog(Me)
                Else
                    ShowMessageBoxError("Please select a receiving account to edit.")
                End If
            Case 1
                '-- SMTP
                If olvSMTPAccounts.SelectedObjects.Count = 1 Then
                    Dim frm As New NewAccount(CType(olvSMTPAccounts.GetSelectedObject(), SMTPProfile))
                    frm.ShowDialog(Me)
                Else
                    ShowMessageBoxError("Please select a sending account to edit.")
                End If
        End Select
        LoadPOP()
        LoadSMTP()
    End Sub
    Private Sub AddAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAccountToolStripMenuItem.Click
        AddNewAccount()
    End Sub

    Private Sub EditAccountToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditAccountToolStripButton.Click
        EditSelectedAccount()
    End Sub

    Private Sub AddAccountToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAccountToolStripButton.Click
        AddNewAccount()
    End Sub

    Private Sub DeleteAccountToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAccountToolStripButton.Click
        DeleteSelectedAccount()
    End Sub

    Private Sub DeleteAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAccountToolStripMenuItem.Click
        DeleteSelectedAccount()
    End Sub

    Private Sub DeleteAccountToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAccountToolStripMenuItem1.Click
        DeleteSelectedAccount()
    End Sub

    Private Sub EditAccountToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditAccountToolStripMenuItem1.Click
        EditSelectedAccount()
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Select Case TabControl1.SelectedIndex
            Case 0
                SetAsdefaultToolStripMenuItem.Enabled = False
                MoveUpToolStripMenuItem.Enabled = True
                MoveDownToolStripMenuItem.Enabled = True
                ResetNumberOfMessagesReceivedToolStripMenuItem.Visible = True
                ToggleIncludeInReceiveAllToolStripMenuItem.Visible = True
                ResetNumberOfMessagesSentToolStripMenuItem.Visible = False
            Case 1
                SetAsdefaultToolStripMenuItem.Enabled = True
                MoveUpToolStripMenuItem.Enabled = False
                MoveDownToolStripMenuItem.Enabled = False
                ResetNumberOfMessagesReceivedToolStripMenuItem.Visible = False
                ToggleIncludeInReceiveAllToolStripMenuItem.Visible = False
                ResetNumberOfMessagesSentToolStripMenuItem.Visible = True
        End Select
    End Sub
    Private Sub SetAsDefaultSMTP()
        Dim smtp As SMTPProfile = olvSMTPAccounts.GetSelectedObject()
        For Each sm As SMTPProfile In AppSettings.SMTPProfiles
            If sm Is smtp Then
                sm.IsDefault = True
            Else
                sm.IsDefault = False
            End If
        Next
        LoadSMTP()
    End Sub
    Private Sub SetAsdefaultToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetAsdefaultToolStripMenuItem.Click
        SetAsDefaultSMTP()
        AppSettings.Save()
    End Sub
    Private Sub ClearSelectedPassword()
        Select Case TabControl1.SelectedIndex
            Case 0
                '-- POP
                Dim lst As ArrayList = olvPOPAccounts.GetSelectedObjects
                For Each entry As POPProfile In lst
                    entry.Password = String.Empty
                Next
                AppSettings.Save()
                LoadPOP()
            Case 1
                '-- SMTP
                Dim lst As ArrayList = olvSMTPAccounts.GetSelectedObjects
                For Each entry As SMTPProfile In lst
                    entry.Password = String.Empty
                Next
                AppSettings.Save()
                LoadSMTP()
        End Select
    End Sub
    Private Sub ClearPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearPasswordToolStripMenuItem.Click
        ClearSelectedPassword()
    End Sub

    Private Sub ClearPasswordToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearPasswordToolStripMenuItem1.Click
        ClearSelectedPassword()
    End Sub

    Private Sub AboutTrulyMailClientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutTrulyMailClientToolStripMenuItem.Click
        Using frm As New AboutBoxK()
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub EditAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditAccountToolStripMenuItem.Click
        EditSelectedAccount()
    End Sub

    Private Sub olvPOPAccounts_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvPOPAccounts.ItemActivate
        EditSelectedAccount()
    End Sub

    Private Sub olvSMTPAccounts_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvSMTPAccounts.ItemActivate
        EditSelectedAccount()
    End Sub

    Private Sub MoveUpToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MoveUpToolStripMenuItem.Click
        Try
            Dim objSelectedPOP As POPProfile = CType(olvPOPAccounts.GetSelectedObject(), POPProfile)
            Dim intPreviousIndex As Integer = AppSettings.POPProfiles.IndexOf(objSelectedPOP)
            If intPreviousIndex > 0 Then
                AppSettings.POPProfiles.RemoveAt(intPreviousIndex)
                AppSettings.POPProfiles.Insert(intPreviousIndex - 1, objSelectedPOP)
                LoadPOP()
            Else
                ShowMessageBoxError("The selected POP account is already at the top of the list")
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error moving the POP account." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub MoveDownToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MoveDownToolStripMenuItem.Click
        Try
            Dim objSelectedPOP As POPProfile = CType(olvPOPAccounts.GetSelectedObject(), POPProfile)
            Dim intPreviousIndex As Integer = AppSettings.POPProfiles.IndexOf(objSelectedPOP)
            If intPreviousIndex < AppSettings.POPProfiles.Count - 1 Then
                AppSettings.POPProfiles.RemoveAt(intPreviousIndex)
                AppSettings.POPProfiles.Insert(intPreviousIndex + 1, objSelectedPOP)
                LoadPOP()
            Else
                ShowMessageBoxError("The selected POP account is already at the bottom of the list")
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error moving the POP account." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub ResetNumberOfMessagesSentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetNumberOfMessagesSentToolStripMenuItem.Click
        Try
            Dim objSelectedSMTP As SMTPProfile = CType(olvSMTPAccounts.GetSelectedObject(), SMTPProfile)
            objSelectedSMTP.MessagesSent = 0
            olvSMTPAccounts.RefreshObject(objSelectedSMTP)
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was a problem resetting the number of messages sent." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub ResetNumberOfMessagesReceivedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetNumberOfMessagesReceivedToolStripMenuItem.Click
        Try
            Dim objSelectedPOP As POPProfile = CType(olvPOPAccounts.GetSelectedObject(), POPProfile)
            objSelectedPOP.MessagesReceived = 0
            olvPOPAccounts.RefreshObject(objSelectedPOP)
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was a problem resetting the number of messages sent." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub ToggleIncludeInReceiveAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToggleIncludeInReceiveAllToolStripMenuItem.Click
        Try
            Dim objSelectedPOP As POPProfile = CType(olvPOPAccounts.GetSelectedObject(), POPProfile)
            objSelectedPOP.IncludeInReceiveAll = Not objSelectedPOP.IncludeInReceiveAll
            olvPOPAccounts.RefreshObject(objSelectedPOP)
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was a problem changing this setting." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub
End Class