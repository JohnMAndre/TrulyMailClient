Friend Class RSSDetails

    Private m_strInBoxFolder As String = String.Empty
    Private m_boolNewFeed As Boolean
    Private m_feed As RSSFeed
    Private m_boolURLChanged As Boolean

    Public Sub New(ByVal feed As RSSFeed)

        ' This call is required by the designer.
        InitializeComponent()

        m_boolNewFeed = False
        m_feed = feed
        m_strInBoxFolder = feed.Folder
        chkDownloadMedia.Checked = feed.DownloadAttachments
        chkHTMLToPlainText.Checked = feed.ForcePlainText
        chkAddLinkToPlainText.Checked = feed.AddLinkToPlainText

        txtURL.Text = feed.URL
        chkShowSummary.Checked = feed.ShowSummary
        m_boolURLChanged = False
    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        m_strInBoxFolder = InBoxRootPath
        m_boolNewFeed = True
    End Sub
    Private Sub RSSDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetInBoxPathLabel(m_strInBoxFolder)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        '-- verify feed
        Dim newFeed As RSSFeed
        Try
            If m_strInBoxFolder.Length = 0 Then
                ShowMessageBoxError("Please select a folder for this feed.")
                Exit Sub
            End If
            If m_boolNewFeed Then
                newFeed = New RSSFeed()
                newFeed.URL = txtURL.Text
                newFeed.ShowSummary = chkShowSummary.Checked
                newFeed.DownloadAttachments = chkDownloadMedia.Checked
                newFeed.ForcePlainText = chkHTMLToPlainText.Checked
                newFeed.Folder = m_strInBoxFolder
                newFeed.AddLinkToPlainText = chkAddLinkToPlainText.Checked AndAlso chkAddLinkToPlainText.Enabled
                SetupFeed(newFeed, txtURL.Text)
                AppSettings.RSSFeeds.Add(newFeed)
            Else
                '-- Update existing feed
                If m_boolURLChanged Then
                    SetupFeed(m_feed, txtURL.Text)
                End If
                m_feed.URL = txtURL.Text
                m_feed.Folder = m_strInBoxFolder
                m_feed.ShowSummary = chkShowSummary.Checked
                m_feed.DownloadAttachments = chkDownloadMedia.Checked
                m_feed.ForcePlainText = chkHTMLToPlainText.Checked
                m_feed.AddLinkToPlainText = chkAddLinkToPlainText.Checked AndAlso chkAddLinkToPlainText.Enabled
            End If
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            Log(ex)
            If m_boolNewFeed Then
                If ShowMessageBox("Could not connect to RSS server. Add anyway?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    newFeed.Title = txtURL.Text
                    newFeed.HTMLUrl = txtURL.Text
                    AppSettings.RSSFeeds.Add(newFeed)
                    Me.DialogResult = DialogResult.OK
                End If
            Else
                If ShowMessageBox("Could not connect to RSS server. Update settings anyway?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    m_feed.URL = txtURL.Text
                    m_feed.Folder = m_strInBoxFolder
                    m_feed.ShowSummary = chkShowSummary.Checked
                    m_feed.DownloadAttachments = chkDownloadMedia.Checked
                    m_feed.ForcePlainText = chkHTMLToPlainText.Checked
                    m_feed.AddLinkToPlainText = chkAddLinkToPlainText.Checked AndAlso chkAddLinkToPlainText.Enabled
                    Me.DialogResult = DialogResult.OK
                End If
            End If

        End Try
    End Sub

    Private Sub txtURL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtURL.TextChanged
        m_boolURLChanged = True
    End Sub
    Private Sub SetInBoxPathLabel(ByVal fullPath As String)
        Const CHANGE As String = " change"
        Dim strNewPath As String = UnQualifyPath(fullPath.Substring(MessageStoreRootPath.Length)) & CHANGE
        llblChangePageInbox.Text = strNewPath
        Dim intReduction As Integer
        Dim strBasePath As String = UnQualifyPath(fullPath.Substring(MessageStoreRootPath.Length))
        Do Until llblChangePageInbox.Right <= (Me.Width - 10)
            intReduction += 1
            strNewPath = strBasePath.Substring(0, strBasePath.Length - intReduction) & "..." & CHANGE
            llblChangePageInbox.Text = strNewPath
        Loop
        llblChangePageInbox.LinkArea = New LinkArea(strNewPath.Length - CHANGE.Length + 1, CHANGE.Length)
        ToolTip1.SetToolTip(llblChangePageInbox, fullPath)
    End Sub

    Private Sub llblChangePageInbox_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblChangePageInbox.LinkClicked
        Try
            Dim fbd As New FolderBrowserDialogTM()
            fbd.ShowAllFolders = False
            fbd.SelectedPath = m_strInBoxFolder
            fbd.ShowNewFolderButton = True
            fbd.Description = "Select folder for RSS articles"
            If fbd.ShowDialog(Me) = DialogResult.OK Then
                SetInBoxPathLabel(fbd.SelectedPath)
                m_strInBoxFolder = fbd.SelectedPath
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error changing the folder for RSS articles. " & CONTACT_TRULYMAIL_MESSAGE)
        End Try
    End Sub

    Private Sub chkHTMLToPlainText_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkHTMLToPlainText.CheckedChanged
        chkAddLinkToPlainText.Enabled = chkHTMLToPlainText.Checked
    End Sub
End Class