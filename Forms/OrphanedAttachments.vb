Imports System.Net.Mail

Public Class OrphanedAttachments

    Private m_boolCancelSearch As Boolean

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        m_boolCancelSearch = False
        pnlMessageFilter.Hide()
        olvAttachments.EmptyListMsg = "Please wait while TrulyMail searches."
        SearchForAttachments()

        RemoveEmptyFolders()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        m_boolCancelSearch = True
    End Sub

    Private Sub btnClearMessageFilter_Click(sender As System.Object, e As System.EventArgs) Handles btnClearMessageFilter.Click
        txtMessageFilter.Text = String.Empty
    End Sub

    Private Sub txtMessageFilter_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMessageFilter.TextChanged
        tmrFilterMessages.Stop()
        tmrFilterMessages.Start()
    End Sub

    Private Sub tmrFilterMessages_Elapsed(sender As System.Object, e As System.Timers.ElapsedEventArgs) Handles tmrFilterMessages.Elapsed
        FilterMessages()
    End Sub
    Private Sub FilterMessages()
        Try
            tmrFilterMessages.Stop()
            olvAttachments.ModelFilter = Nothing

            olvAttachments.ModelFilter = New BrightIdeasSoftware.TextMatchFilter(olvAttachments, txtMessageFilter.Text)


            If txtMessageFilter.Text.Length = 0 Then
                olvAttachments.EmptyListMsg = "There are no orphaned attachments"
            Else
                olvAttachments.EmptyListMsg = "No orphaned attachments match your filter"
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Private Sub SearchForAttachments()
        Try
            btnSearch.Enabled = False

            lblSearchProgress.Visible = True
            prgSearchProgress.Visible = True
            btnCancel.Visible = True
            prgSearchProgress.Value = 0
            Application.DoEvents()

            Dim attachments() As String
            attachments = System.IO.Directory.GetFiles(AttachmentsRootPath, "*.*", IO.SearchOption.AllDirectories)

            '-- build a list of messageIDs to compare against
            Dim messages() As String
            Dim strFilename As String
            Dim lstMessageIDs As New List(Of String)
            messages = System.IO.Directory.GetFiles(MessageStoreRootPath, "*" & MESSAGE_FILENAME_EXTENSION, IO.SearchOption.AllDirectories)
            For Each msg As String In messages
                strFilename = System.IO.Path.GetFileNameWithoutExtension(msg)
                lstMessageIDs.Add(strFilename)
            Next


            Dim lst As New List(Of TrulyMailOrphanedAttachmentSearchResult)
            Me.olvAttachments.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf AttachmentRowFormatter)
            olvColumnAttachmentName.ImageGetter = New BrightIdeasSoftware.ImageGetterDelegate(AddressOf AttachmentImageGetter)
            Me.OlvColumnAttachmentSize.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterSize)
            Me.OlvColumnSelected.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.NoTextAspectToStringConverter)
            'Me.olvColumnAttachmentDate.AspectToStringConverter = New BrightIdeasSoftware.AspectToStringConverterDelegate(AddressOf Me.AspectToStringConverterDate)

            prgSearchProgress.Maximum = attachments.Length
            Dim strMessageID As String
            For Each strFilename In attachments
                If m_boolCancelSearch Then
                    Exit For
                End If

                prgSearchProgress.Value += 1
                TotalStatusLabel.Text = "Scanned: " & prgSearchProgress.Value.ToString("#,##0")

                Application.DoEvents()

                strMessageID = GetMessageIDFromFullPath(strFilename)

                If lstMessageIDs.Contains(strMessageID) Then
                    '-- skip this attachment, the message exists
                    Continue For
                End If

                Application.DoEvents()

                '-- do not show embeded images
                'If Attachment.DisplayName.StartsWith(IMAGES_EMBEDDED_FOLDER) Then
                '    Continue For
                'End If


                Dim item As New TrulyMailOrphanedAttachmentSearchResult
                item.Filename = strFilename
                item.AttachmentFileSize = FileLen(strFilename)
                item.AttachmentFilename = System.IO.Path.GetFileName(strFilename)
                item.AttachmentFullPath = strFilename

                lst.Add(item)
            Next

            Me.olvAttachments.SetObjects(lst)
            olvAttachments.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

            olvAttachments.Show()
            

        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error searching for attachments. Please contact TrulyMail Support for assistance.")
        End Try

        btnSearch.Enabled = True
        lblSearchProgress.Visible = False
        prgSearchProgress.Visible = False
        btnCancel.Visible = False
        pnlMessageFilter.Show()
    End Sub
    Private Sub UpdateStatusBarCounts()
        Dim intTotal As Integer
        Dim intSelected As Integer
        If olvAttachments.Objects IsNot Nothing Then
            For Each obj As TrulyMailOrphanedAttachmentSearchResult In olvAttachments.Objects
                intTotal += 1
                If obj.Selected Then
                    intSelected += 1
                End If
            Next
            TotalStatusLabel.Text = "Total: " & intTotal.ToString("#,##0")
            SelectedStatusLabel.Text = "Checked: " & intSelected.ToString("#,##0")
        End If
    End Sub
    Private Function GetMessageIDFromFullPath(fullpath As String) As String
        Dim strReturn As String
        strReturn = fullpath.Substring(AttachmentsRootPath.Length)
        strReturn = strReturn.Substring(0, strReturn.IndexOf(System.IO.Path.DirectorySeparatorChar))
        Return strReturn
    End Function
    Private Class TrulyMailOrphanedAttachmentSearchResult
        Public Filename As String
        Public AttachmentFilename As String
        Public AttachmentFullPath As String
        Public AttachmentFileSize As Long
        Public Selected As Boolean
    End Class
    Private Function AspectToStringConverterDate(ByVal d As Date) As String
        If d.Date = Date.Today Then
            Return d.ToShortTimeString
        Else
            Return d.ToShortDateString & " " & d.ToShortTimeString
        End If
    End Function
    Private Function NoTextAspectToStringConverter(ByVal s As String) As String
        Return String.Empty
    End Function
    Private Function AspectToStringConverterSize(ByVal i As Integer) As String
        Dim size As Long = CType(i, Long)
        Dim limits() As Integer = {1024 * 1024 * 1024, 1024 * 1024, 1024}
        Dim units() As String = {"GB", "MB", "KB"}
        For intCounter As Integer = 0 To limits.Length - 1
            If size >= limits(intCounter) Then
                Return String.Format("{0:#,##0.#} " & units(intCounter), ((Convert.ToDouble(size) / limits(intCounter))))
            End If
        Next

        Return String.Format("{0} B", size)
    End Function
    Private Function AttachmentRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        
    End Function
    Private Function AttachmentImageGetter(ByVal row As Object) As Object
        Try
            Dim item As TrulyMailOrphanedAttachmentSearchResult = row
            Dim strExtension As String = System.IO.Path.GetExtension(item.AttachmentFilename).ToLower()
            If Not olvAttachments.SmallImageList.Images.ContainsKey(strExtension) Then
                Dim icon As Icon = AssociatedIcon.GetAssociatedIconSmall(item.AttachmentFullPath)
                olvAttachments.SmallImageList.Images.Add(strExtension, icon)
            End If
            Return strExtension
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Sub btnSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectAll.Click
        Try
            If olvAttachments.Objects IsNot Nothing Then
                For Each obj As TrulyMailOrphanedAttachmentSearchResult In olvAttachments.Objects
                    obj.Selected = True
                    olvAttachments.RefreshObject(obj)
                Next
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub btnToggleGroups_Click(sender As System.Object, e As System.EventArgs) Handles btnToggleGroups.Click
        olvAttachments.ShowGroups = Not olvAttachments.ShowGroups
        olvAttachments.BuildGroups(OlvColumnFullPath, SortOrder.Ascending)
    End Sub
    Private Sub RemoveEmptyFolders()
        Try
            Dim folders() As String = System.IO.Directory.GetDirectories(AttachmentsRootPath, "*.*", IO.SearchOption.AllDirectories)
            For Each folder As String In folders
                Dim files() As String = System.IO.Directory.GetFiles(folder, "*.*", IO.SearchOption.AllDirectories)
                If files.Length = 0 Then
                    Try
                        System.IO.Directory.Delete(folder)
                    Catch ex As Exception
                        Log(ex)
                    End Try
                End If
            Next
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Private Sub btnDeleteSelected_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteSelected.Click
        Try
            Dim intCount As Integer
            If olvAttachments.Objects IsNot Nothing Then
                For Each item As TrulyMailOrphanedAttachmentSearchResult In olvAttachments.Objects
                    If item.Selected Then
                        intCount += 1
                    End If
                Next

                Dim lstToRemove As New List(Of TrulyMailOrphanedAttachmentSearchResult)
                Dim intDeleted As Integer
                Dim intFailed As Integer
                If intCount = 0 Then
                    ShowMessageBox("There is nothing selected to delete. Please check the items to select them.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    If ShowMessageBox("Really delete these " & intCount.ToString("#,##0") & " attachments forever?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) = Windows.Forms.DialogResult.Yes Then
                        For Each obj As TrulyMailOrphanedAttachmentSearchResult In olvAttachments.Objects
                            If obj.Selected Then
                                Try
                                    DeleteLocalFile(obj.AttachmentFullPath)
                                    lstToRemove.Add(obj)
                                    intDeleted += 1
                                Catch ex As Exception
                                    intFailed += 1
                                    Log(ex)
                                End Try
                            End If
                        Next

                        For Each obj As TrulyMailOrphanedAttachmentSearchResult In lstToRemove
                            olvAttachments.RemoveObject(obj)
                        Next

                    End If

                    Dim strMessage As String = "Successfully deleted " & intDeleted.ToString("#,##0") & " files."
                    If intFailed > 0 Then
                        strMessage &= Environment.NewLine & Environment.NewLine & intFailed.ToString("#,##0") & " could not be deleted (probably they were in use somewhere). Try again later."
                    End If
                    ShowMessageBox(strMessage, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If

        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error deleting the selected files. " & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub KryptonButton1_Click(sender As System.Object, e As System.EventArgs) Handles KryptonButton1.Click
        Try
            If olvAttachments.Objects IsNot Nothing Then
                For Each obj As TrulyMailOrphanedAttachmentSearchResult In olvAttachments.Objects
                    obj.Selected = False
                    olvAttachments.RefreshObject(obj)
                Next
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
        
    End Sub

    Private Sub OpenAttachmentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenAttachmentToolStripMenuItem.Click
        OpenCurrentlySelectedAttachments()
    End Sub

    Private Sub OpenCurrentlySelectedAttachments()
        OpenSelectedItem()
    End Sub
    Private Sub OpenSelectedItem()
        Dim list As ArrayList = olvAttachments.GetSelectedObjects
        For Each tma As TrulyMailOrphanedAttachmentSearchResult In list
            Try
                System.Diagnostics.Process.Start(tma.AttachmentFullPath)
            Catch ex As Exception
                If ex.Message.Contains("No application is associated") Then
                    MessageBox.Show("There is no application associated with this attached file." & Environment.NewLine & Environment.NewLine & _
                                    "You can drag-and-drop to save the attachment and open the file from there.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf ex.Message.Contains("The system cannot find the file specified") Then
                    MessageBox.Show("The attachment cannot be found. Perhaps it was deleted manually?", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Log(ex)
                    MessageBox.Show("There was an unexpected error (" & ex.Message & ") with this attached file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End Try
        Next
    End Sub
    Private Sub OpenSelectedItemLocation()
        Dim lst As ArrayList = olvAttachments.SelectedObjects()
        If lst.Count > 0 Then
            Dim item As TrulyMailOrphanedAttachmentSearchResult = lst(0)
            Dim strFilename As String = item.Filename
            If Not System.IO.File.Exists(strFilename) Then
                ShowMessageBoxError("The attachment cannot be found. It might have been deleted manually.")
            Else
                Dim psi As New System.Diagnostics.ProcessStartInfo("explorer.exe", "/select, """ & strFilename & """")
                System.Diagnostics.Process.Start(psi) '"explorer.exe /select, ""C:\TrulyMailPortableJMA\Data\Profile\Attachments\0b4d177b-a901-427b-b5fb-d880b6160b94\D02EE404.txt""")
            End If
        End If
    End Sub
    Private Sub OpenFileLocationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenFileLocationToolStripMenuItem.Click
        OpenSelectedItemLocation()
    End Sub

    Private Sub btnCheckSelected_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckSelected.Click
        Try
            If olvAttachments.Objects IsNot Nothing Then
                For Each obj As TrulyMailOrphanedAttachmentSearchResult In olvAttachments.SelectedObjects
                    obj.Selected = Not obj.Selected
                    olvAttachments.RefreshObject(obj)
                Next
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub

    Private Sub tmrStatusUpdater_Elapsed(sender As System.Object, e As System.Timers.ElapsedEventArgs) Handles tmrStatusUpdater.Elapsed
        UpdateStatusBarCounts()
    End Sub

    Private Sub olvAttachments_ItemActivate(sender As System.Object, e As System.EventArgs) Handles olvAttachments.ItemActivate
        OpenSelectedItem()
    End Sub

End Class
