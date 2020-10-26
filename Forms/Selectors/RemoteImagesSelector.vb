Friend Class RemoteImagesSelector

    Private m_strHTML As String
    Private m_boolImagesRemain As Boolean

    Public Sub New(ByVal html As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_strHTML = html
    End Sub
    Private Sub btnExplain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExplain.Click
        ShowMessageBox("Remote images in a message require TrulyMail to communicate with the server which hosts those images." & _
                       Environment.NewLine & Environment.NewLine & _
                       "Communicating with the server might send information about you to that server, which is a security risk." & _
                       Environment.NewLine & Environment.NewLine & _
                       "The most common (but certainly not only) warning about sending information about you is when an image location includes a '?' in the location. This is why we have highlighted those images." & _
                       Environment.NewLine & Environment.NewLine & _
                       "You can select any remote images you wish and have them removed from the message permanently. The remote images which remain will be shown when you choose Show Remote Images in the main message window.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub RemoteImagesSelector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.olvURLs.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf MainRowFormatter)

        '-- Show URLs for remote images
        Dim imageNodes As HtmlElementCollection
        Dim imageTag As HtmlElement
        Dim lst As New List(Of NameValuePair)
        Dim item As NameValuePair
        Dim browser As New WebBrowser()
        browser.DocumentText = m_strHTML
        Do Until browser.ReadyState = WebBrowserReadyState.Complete
            Application.DoEvents()
        Loop
        imageNodes = browser.Document.Images '.GetElementsByTagName("img")

        For Each imageTag In imageNodes
            If imageTag.GetAttribute("src").IndexOf("://") > -1 AndAlso imageTag.GetAttribute("src").StartsWith("---") Then
                item = New NameValuePair
                item.Name = imageTag.GetAttribute("src").Substring(3)
                lst.Add(item)
            End If
        Next

        olvURLs.SetObjects(lst)

        Me.Show()
        AutoSizeColumns(Me.olvURLs)
    End Sub

    Private Sub RemoteImagesSelector_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub
    Public ReadOnly Property ImagesRemain() As Boolean
        Get
            Return m_boolImagesRemain
        End Get
    End Property
    Public Property HTML() As String
        Get
            Return m_strHTML
        End Get
        Set(ByVal value As String)
            m_strHTML = value
        End Set
    End Property
    Private Sub btnRemoveSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSelected.Click
        '-- Notify the calling read message window to remove the specified image tag src attributes
        Dim lst As ArrayList

        lst = olvURLs.GetCheckedObjects()

        If lst.Count = 0 Then
            ShowMessageBox("Nothing checked to remove.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Dim imageNodes As HtmlElementCollection
        Dim imageTag As HtmlElement
        Dim item As NameValuePair
        Dim browser As New WebBrowser()
        browser.DocumentText = m_strHTML
        Do Until browser.ReadyState = WebBrowserReadyState.Complete
            Application.DoEvents()
        Loop

        For Each item In lst
            imageNodes = browser.Document.Images '.GetElementsByTagName("img")
            For Each imageTag In imageNodes
                If imageTag.GetAttribute("src").IndexOf("://") > -1 AndAlso imageTag.GetAttribute("src").StartsWith("---") AndAlso imageTag.GetAttribute("src").Substring(3) = item.Name Then
                    imageTag.SetAttribute("src", String.Empty) '-- clear the image's source
                End If
            Next
        Next

        '-- am not sure this is needed
        '   but am still having problems with the html getting blanked out
        Do Until browser.ReadyState = WebBrowserReadyState.Complete
            Application.DoEvents()
        Loop

        If browser.Document.Body IsNot Nothing Then
            Dim strPrevHTML As String = m_strHTML '-- for debugging only
            m_strHTML = browser.Document.Body.OuterHtml
            If m_strHTML.Length < 20 Then
                ShowMessageBox("There was an error removing the remote image. Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                m_strHTML = strPrevHTML
                Exit Sub
            End If
            Application.DoEvents()
        Else
            '-- just use the original html
            Application.DoEvents() '-- for breakpoint only
        End If

        m_boolImagesRemain = (lst.Count <> olvURLs.Items.Count)

        DialogResult = Windows.Forms.DialogResult.OK

        Hide()
    End Sub
    Private Function MainRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim item As NameValuePair = CType(olvi.RowObject, NameValuePair)
        If item.Name.IndexOf("?") > -1 Then
            olvi.BackColor = Color.Yellow
        End If
    End Function

    Private Sub olvURLs_PreviewKeyDown(sender As System.Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles olvURLs.PreviewKeyDown
        If e.KeyCode = Keys.Delete And olvURLs.GetSelectedObjects.Count > 0 Then
            For Each item As ListViewItem In olvURLs.SelectedItems
                item.Checked = True
            Next
            olvURLs.RefreshSelectedObjects()
        End If
    End Sub

    Private Sub olvURLs_ItemCheck(sender As System.Object, e As System.Windows.Forms.ItemCheckEventArgs) Handles olvURLs.ItemCheck
        olvURLs.Items(e.Index).Checked = Not olvURLs.Items(e.Index).Checked
        olvURLs.RefreshObjects(olvURLs.Objects)
    End Sub
End Class