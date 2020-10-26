Friend Class ReadMessage2

    '-- removed for TM6 Private m_strFilename As String
    Private m_tm As TrulyMailMessage
    Private m_boolIsFullyLoaded As Boolean

    Private ReadMessageControlRich As ReadMessageControl
    Private ReadMessageControlPlain As ReadMessage7Control
    Private m_boolUsingRichControl As Boolean

    Public Sub New(tmm As TrulyMailMessage, asPlainText As Boolean)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        m_boolUsingRichControl = Not asPlainText

        m_tm = tmm
    End Sub
    Private Sub Reply()
        ReplyToSender(m_tm.Filename)
        Close()
    End Sub
    Private Sub ReplyToAll()
        Globals.ReplyToAll(m_tm.Filename)
        Close()
    End Sub
    Private Sub Forward()
        ForwardMessage(m_tm.Filename)
        Close()
    End Sub
    Private Sub DeleteMessage()
        Globals.DeleteLocalMessage(m_tm.Filename, ModifierKeys = Keys.Shift, True)
        Close()
    End Sub
    Private Sub BeginReadingAloud()
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ReadMessageAloud()
        Else
            ReadMessageControlPlain.ReadMessageAloud()
        End If
        ReadMessagePauseToolStripMenuItem.Enabled = True
        ReadMessageResumeToolStripMenuItem.Enabled = True

        ReadMessagePauseToolStripButton.Enabled = True
        ReadMessageResumeToolStripButton.Enabled = True
    End Sub
    Private Sub ChangeSubject()
        Dim strOldSubject As String
        Dim strNewSubject As String

        If m_boolUsingRichControl Then
            strOldSubject = ReadMessageControlRich.txtSubject.Text
            strNewSubject = GetInput("Enter the new subject for this message.", False, strOldSubject)
            If strNewSubject <> Chr(0) AndAlso strNewSubject <> strOldSubject Then
                ReadMessageControlRich.txtSubject.Text = strNewSubject
                ReadMessageControlRich.AppendNote("Previous subject: " & strOldSubject)
                ReadMessageControlRich.MessageBeingRead.Subject = strNewSubject
                ReadMessageControlRich.MessageBeingRead.Save()
                MainFormReference.UpdateMessage(m_tm)
            End If
        Else
            strOldSubject = ReadMessageControlPlain.txtSubject.Text
            strNewSubject = GetInput("Enter the new subject for this message.", False, strOldSubject)
            If strNewSubject <> Chr(0) AndAlso strNewSubject <> strOldSubject Then
                ReadMessageControlPlain.txtSubject.Text = strNewSubject
                ReadMessageControlPlain.AppendNote("Previous subject: " & strOldSubject)
                ReadMessageControlPlain.MessageBeingRead.Subject = strNewSubject
                ReadMessageControlPlain.MessageBeingRead.Save()
                MainFormReference.UpdateMessage(m_tm)
            End If
        End If
    End Sub
    Private Sub MoveMessage()
        Try
            Dim fbd As New FolderBrowserDialogTM()
            fbd.ShowNewFolderButton = True
            fbd.ShowAllFolders = False
            fbd.Description = "Select new folder for message(s)"
            fbd.SelectedPath = System.IO.Path.GetDirectoryName(m_tm.Filename)
            If fbd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                '-- move message
                Dim strDetinationFolder As String = fbd.SelectedPath

                Dim strDestination As String = QualifyPath(strDetinationFolder) & System.IO.Path.GetFileName(m_tm.Filename)
                MainFormReference.MoveMessage(m_tm.Filename, strDestination)

                '-- Close message
                Close()
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error moving the message. " & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try
    End Sub
#Region " Menus and ToolBar Events "
    Private Sub NewMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewMessageToolStripMenuItem.Click
        MainFormReference.NewMessage()
    End Sub
    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.PrintMessage()
        Else
            ReadMessageControlPlain.PrintMessage()
        End If
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ClosePreviousMessage()
        Else
            ReadMessageControlPlain.ClosePreviousMessage()
        End If
        Close()
    End Sub
    Private Sub MessageHeadersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageHeadersToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ShowEmailHeaders()
        Else
            ReadMessageControlPlain.ShowEmailHeaders()
        End If
    End Sub
    Private Sub ReplyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplyToolStripMenuItem.Click
        Reply()
    End Sub
    Private Sub ReplyToAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplyToAllToolStripMenuItem.Click
        ReplyToAll()
    End Sub
    Private Sub ForwardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForwardToolStripMenuItem.Click
        Forward()
    End Sub
    Private Sub FollowUpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FollowUpToolStripMenuItem.Click
        FollowUpMessage(m_tm.Filename)
        Close()
    End Sub
    Private Sub DeletToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeletToolStripMenuItem.Click
        DeleteMessage()
    End Sub
    Private Sub TreatAsReadReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreatAsReadReceiptToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.TreatAsReadReceipt()
        Else
            ReadMessageControlPlain.TreatAsReadReceipt()
        End If
    End Sub
    Private Sub AddNotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNotesToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.AddNotes()
        Else
            ReadMessageControlPlain.AddNotes()
        End If
    End Sub
    Private Sub MoveToToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveToToolStripMenuItem1.Click
        MoveMessage()
    End Sub
    Private Sub ChangeSubjectToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeSubjectToolStripMenuItem1.Click
        ChangeSubject()
    End Sub
    Private Sub ReadMessageContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadMessageContentsToolStripMenuItem.Click
        BeginReadingAloud()
    End Sub
    Private Sub ReadMessagePauseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadMessagePauseToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ReadMessagePause()
        Else
            ReadMessageControlPlain.ReadMessagePause()
        End If
    End Sub
    Private Sub ReadMessageResumeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadMessageResumeToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ReadMessageResume()
        Else
            ReadMessageControlPlain.ReadMessageResume()
        End If
    End Sub
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Using frm As New AboutBoxK()
            frm.ShowDialog()
        End Using
    End Sub
    Private Sub ReplyToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplyToolStripButton.Click
        Reply()
    End Sub
    Private Sub ReplyToAllToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplyToAllToolStripButton.Click
        ReplyToAll()
    End Sub
    Private Sub ForwardToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForwardToolStripButton.Click
        Forward()
    End Sub
    Private Sub DeleteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripButton.Click
        DeleteMessage()
    End Sub
    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.PrintMessage()
        Else
            ReadMessageControlPlain.PrintMessage()
        End If
    End Sub
    Private Sub NotesToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotesToolStripButton.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.AddNotes()
        Else
            ReadMessageControlPlain.AddNotes()
        End If
    End Sub
    Private Sub ReadMessageContentsToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadMessageContentsToolStripButton.Click
        BeginReadingAloud()
    End Sub
    Private Sub ReadMessagePauseToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadMessagePauseToolStripButton.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ReadMessagePause()
        Else
            ReadMessageControlPlain.ReadMessagePause()
        End If
    End Sub
    Private Sub ReadMessageResumeToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadMessageResumeToolStripButton.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ReadMessageResume()
        Else
            ReadMessageControlPlain.ReadMessageResume()
        End If
    End Sub
#End Region

    Private Sub ReadMessageControl1_EnableMessageHeaders(ByVal enabled As System.Boolean)
        MessageHeadersToolStripMenuItem.Enabled = enabled
    End Sub

    Private Sub ReadMessageControl1_EnableTreatAsReadReceipt(ByVal enabled As System.Boolean)
        TreatAsReadReceiptToolStripMenuItem.Enabled = enabled
    End Sub


    Private Sub ReadMessageControl1_ReadMessageActionSplitterDistanceChanged(splitterDistance As Integer)
        If m_boolIsFullyLoaded Then
            If m_boolUsingRichControl Then
                AppSettings.ReadMessageActionSplitterDistance = Me.ReadMessageControlRich.ReadMessageActionSplitterDistance
            Else
                AppSettings.ReadMessageActionSplitterDistance = Me.ReadMessageControlPlain.ReadMessageActionSplitterDistance
            End If
        End If
    End Sub

    Private Sub ReadMessageControl1_SpecialAction(ByVal action As TrulyMail.ReadMessageControl.MessageSpecialActionEnum)
        Select Case action
            Case ReadMessageControl.MessageSpecialActionEnum.DeleteMessage
                DeletToolStripMenuItem.PerformClick()
            Case ReadMessageControl.MessageSpecialActionEnum.FollowUp
                FollowUpToolStripMenuItem.PerformClick()
            Case ReadMessageControl.MessageSpecialActionEnum.Forward
                ForwardToolStripMenuItem.PerformClick()
            Case ReadMessageControl.MessageSpecialActionEnum.MarkRead
                '- ignore since opening the message marks it as read
            Case ReadMessageControl.MessageSpecialActionEnum.NewMessage
                NewMessageToolStripMenuItem.PerformClick()
            Case ReadMessageControl.MessageSpecialActionEnum.Reply
                ReplyToolStripMenuItem.PerformClick()
            Case ReadMessageControl.MessageSpecialActionEnum.ReplyAll
                ReplyToAllToolStripMenuItem.PerformClick()
        End Select
    End Sub

    Private Sub tmrSubjectLoader_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSubjectLoader.Tick
        tmrSubjectLoader.Stop()

        Me.Text = m_tm.Subject
    End Sub
    Private Sub SetToolStripIcons(ByVal toLarge As Boolean)
        If toLarge Then
            '-- Switching from small icons to large icons
            Me.ToolStrip1.ImageScalingSize = New Size(32, 32)
            Me.ToolStrip1.Height = TOOLBAR_32_HEIGHT

            PrintToolStripButton.Image = My.Resources.Print_32
            NotesToolStripButton.Image = My.Resources.Note_32
            DeleteToolStripButton.Image = My.Resources.Erase_32

            ReplyToolStripButton.Image = My.Resources.reply_3_32
            ReplyToAllToolStripButton.Image = My.Resources.reply_all_3_32
            ForwardToolStripButton.Image = My.Resources.Forward_3_32
            FindInMessageToolStripButton.Image = My.Resources.searchmessage_32
            ReadMessageContentsToolStripButton.Image = My.Resources.PlayButton_32
            ReadMessagePauseToolStripButton.Image = My.Resources.PauseButton_32
            ReadMessageResumeToolStripButton.Image = My.Resources.ResumeButton_32
        Else
            '-- Switching from large icons to small icons
            Me.ToolStrip1.ImageScalingSize = New Size(16, 16)
            Me.ToolStrip1.Height = TOOLBAR_16_HEIGHT

            PrintToolStripButton.Image = My.Resources.Print_16
            NotesToolStripButton.Image = My.Resources.Note_16
            DeleteToolStripButton.Image = My.Resources.Erase_16

            ReplyToolStripButton.Image = My.Resources.reply_3_16
            ReplyToAllToolStripButton.Image = My.Resources.reply_all_3_16
            ForwardToolStripButton.Image = My.Resources.Forward_3_16
            FindInMessageToolStripButton.Image = My.Resources.searchmessage_16
            ReadMessageContentsToolStripButton.Image = My.Resources.PlayButton_16
            ReadMessagePauseToolStripButton.Image = My.Resources.PauseButton_16
            ReadMessageResumeToolStripButton.Image = My.Resources.ResumeButton_16
        End If
        SetupToolStripForText(ToolStrip1)
    End Sub

    Private Sub ReadMessage2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ReadMessagePause()
        Else
            ReadMessageControlPlain.ReadMessagePause()
        End If

        If Me.WindowState = FormWindowState.Normal Then
            AppSettings.ReadWindowSize = Me.Size
            AppSettings.ReadWindowLocation = Me.Location
        End If
    End Sub

    Private Sub ReadMessage2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetToolStripIcons(AppSettings.LargeToolbarIcons)

        SetupReaderControl()

        If m_boolUsingRichControl Then
            ReadMessageControlRich.LoadDelay = 10
            ReadMessageControlRich.LoadMessage(m_tm)
        Else
            ReadMessageControlPlain.LoadDelay = 10
            ReadMessageControlPlain.LoadMessage(m_tm)
        End If
        '-- maximize it always
        Me.WindowState = FormWindowState.Maximized

        Me.Location = AppSettings.ReadWindowLocation
        If m_boolUsingRichControl Then
            Me.ReadMessageControlRich.ReadMessageActionSplitterDistance = AppSettings.ReadMessageActionSplitterDistance
            Me.ReadMessageControlRich.ReplyModeVisible = AppSettings.ReadMessageActionVisible
        Else
            Me.ReadMessageControlPlain.ReadMessageActionSplitterDistance = AppSettings.ReadMessageActionSplitterDistance
            Me.ReadMessageControlPlain.ReplyModeVisible = AppSettings.ReadMessageActionVisible
        End If

        m_boolIsFullyLoaded = True
    End Sub

    Private Sub SetupReaderControl()
        If Not m_boolUsingRichControl Then
            '-- use ReadMessage7Control to read everything as plaintext
            m_boolUsingRichControl = False
            Dim ctrl As ReadMessage7Control
            ctrl = New ReadMessage7Control()

            ctrl.Parent = ToolStripContainer1.ContentPanel
            ctrl.Dock = DockStyle.Fill

            'ctrl.DarkMode = False '-- Not yet implemented in the rich control
            ctrl.Dock = System.Windows.Forms.DockStyle.Fill
            ctrl.LoadDelay = 100
            ctrl.Location = New System.Drawing.Point(0, 0)
            ctrl.Name = "ReadMessageControl1"
            ctrl.Size = New System.Drawing.Size(354, 515)
            ctrl.TabIndex = 1
            ctrl.LoadDelay = AppSettings.MessagePreviewLoadDelay * 1000 '-- convert to ms


            AddHandler ctrl.EnableMessageHeaders, AddressOf ReadMessageControl1_EnableMessageHeaders
            AddHandler ctrl.EnableTreatAsReadReceipt, AddressOf ReadMessageControl1_EnableTreatAsReadReceipt
            AddHandler ctrl.SpecialAction, AddressOf ReadMessageControl1_SpecialAction
            AddHandler ctrl.ReadMessageActionSplitterDistanceChanged, AddressOf ReadMessageControl1_ReadMessageActionSplitterDistanceChanged

            ReadMessageControlPlain = ctrl
        Else
            '-- use ReadMessageControl to read as HTML or plaintext, depending on how it was sent
            m_boolUsingRichControl = True

            '-- Setup read message control based on settings and if we are running under WINE
            Dim ctrl As ReadMessageControl
            ctrl = New ReadMessageControl()

            ctrl.Parent = ToolStripContainer1.ContentPanel
            ctrl.Dock = DockStyle.Fill

            'ctrl.DarkMode = False '-- Not yet implemented in the rich control
            ctrl.Dock = System.Windows.Forms.DockStyle.Fill
            ctrl.LoadDelay = 100
            ctrl.Location = New System.Drawing.Point(0, 0)
            ctrl.Name = "ReadMessageControl1"
            ctrl.Size = New System.Drawing.Size(354, 515)
            ctrl.TabIndex = 1
            ctrl.LoadDelay = AppSettings.MessagePreviewLoadDelay * 1000 '-- convert to ms


            AddHandler ctrl.EnableMessageHeaders, AddressOf ReadMessageControl1_EnableMessageHeaders
            AddHandler ctrl.EnableTreatAsReadReceipt, AddressOf ReadMessageControl1_EnableTreatAsReadReceipt
            AddHandler ctrl.SpecialAction, AddressOf ReadMessageControl1_SpecialAction
            AddHandler ctrl.ReadMessageActionSplitterDistanceChanged, AddressOf ReadMessageControl1_ReadMessageActionSplitterDistanceChanged

            ReadMessageControlRich = ctrl
        End If
    End Sub
    Private Sub FindInMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindInMessageToolStripMenuItem.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ShowFind()
        Else
            ReadMessageControlPlain.ShowFind()
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        Try
            Dim sfd As New SaveFileDialog()
            sfd.OverwritePrompt = True
            sfd.Filter = "Email Files|*.eml"
            sfd.Title = "Select location to save file..."
            sfd.DefaultExt = ".eml"
            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim strFilename As String = sfd.FileName

                If Not ConvertTrulyMailMessageToEMLFile(m_tm, sfd.FileName, "autodelete@trulymail.com") Then
                    Log("eml file not created.")
                    ShowMessageBoxError("There was an error saving your message. Please contact TrulyMail Support.")
                End If
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error saving your message. Please contact TrulyMail Support.")
        End Try
    End Sub

    Private Sub BodyFullScreenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BodyFullScreenToolStripMenuItem.Click
        Try
            If m_boolUsingRichControl Then
                Me.ReadMessageControlRich.ShowBodyFullScreen()
            Else
                Me.ReadMessageControlPlain.ShowBodyFullScreen()
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub ViewToolStripMenuItem_DropDownOpening(sender As System.Object, e As System.EventArgs) Handles ViewToolStripMenuItem.DropDownOpening
        Try
            If m_boolUsingRichControl Then
                ViewReplyModesToolStripMenuItem.Checked = ReadMessageControlRich.ReplyModeVisible
            Else
                ViewReplyModesToolStripMenuItem.Checked = ReadMessageControlPlain.ReplyModeVisible
            End If
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub ViewReplyModesToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles ViewReplyModesToolStripMenuItem.Click
        Try
            If m_boolUsingRichControl Then
                ReadMessageControlRich.ReplyModeVisible = Not ReadMessageControlRich.ReplyModeVisible
                AppSettings.ReadMessageActionVisible = ReadMessageControlRich.ReplyModeVisible
            Else
                ReadMessageControlPlain.ReplyModeVisible = Not ReadMessageControlPlain.ReplyModeVisible
                AppSettings.ReadMessageActionVisible = ReadMessageControlPlain.ReplyModeVisible
            End If

        Catch ex As Exception
            Log(ex)
        End Try
    End Sub

    Private Sub FindInMessageToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles FindInMessageToolStripButton.Click
        If m_boolUsingRichControl Then
            ReadMessageControlRich.ShowFind()
        Else
            ReadMessageControlPlain.ShowFind()
        End If
    End Sub

End Class