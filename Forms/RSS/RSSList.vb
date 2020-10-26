Public Class RSSList

    Private m_boolForceShowErrorColumn As Boolean

    Public Sub New(forceShowErrorColumn As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        m_boolForceShowErrorColumn = forceShowErrorColumn
        
    End Sub
    Private Sub btnNewRule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRule.Click
        Dim frm As New RSSDetails()
        If frm.ShowDialog(Me) = DialogResult.OK Then
            LoadRSSFeeds()
        End If
    End Sub

    Private Sub RSSList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.olvRSSSubscriptions.RowFormatter = New BrightIdeasSoftware.RowFormatterDelegate(AddressOf MainRowFormatter)
        SummaryColumn.AspectPutter = New BrightIdeasSoftware.AspectPutterDelegate(AddressOf DoNothingAspectPutter)
        MediaColumn.AspectPutter = New BrightIdeasSoftware.AspectPutterDelegate(AddressOf DoNothingAspectPutter)

        LoadRSSFeeds()
        AutoSizeColumns(olvRSSSubscriptions)

        If m_boolForceShowErrorColumn Then
            tmrShowErrorColumn.Start()
        End If
    End Sub
    Private Sub LoadRSSFeeds()
        olvRSSSubscriptions.SetObjects(AppSettings.RSSFeeds)
    End Sub

    Private Function MainRowFormatter(ByVal olvi As BrightIdeasSoftware.OLVListItem) As Object
        Dim feed As RSSFeed = CType(olvi.RowObject, RSSFeed)

        If feed IsNot Nothing Then
            Dim intPositionFolder As Integer = Me.olvRSSSubscriptions.Columns.IndexOf(Me.FolderColumn)
            olvi.SubItems(intPositionFolder).Text = UnQualifyPath(feed.Folder.Substring(MessageStoreRootPath.Length))
        End If
    End Function

    Private Sub btnDeleteRule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteRule.Click
        Dim feed As RSSFeed = CType(olvRSSSubscriptions.SelectedObject, RSSFeed)
        If feed IsNot Nothing Then
            AppSettings.RSSFeeds.Remove(feed)
            LoadRSSFeeds()
        End If
    End Sub
    Private Sub EditSelectedItem()
        Dim feed As RSSFeed = CType(olvRSSSubscriptions.SelectedObject, RSSFeed)
        If feed IsNot Nothing Then
            Dim frm As New RSSDetails(feed)
            If frm.ShowDialog = DialogResult.OK Then
                LoadRSSFeeds()
            End If
        End If
    End Sub
    Private Sub btnEditRule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditRule.Click
        EditSelectedItem()
    End Sub

    Private Sub olvRSSSubscriptions_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvRSSSubscriptions.ItemActivate
        EditSelectedItem()
    End Sub

    Private Sub btnRemoteImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoteImages.Click
        Dim frm As New RSSSenderRemoteImages()
        frm.ShowDialog()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "OPML Files|*.opml"
            If sfd.ShowDialog() = DialogResult.OK Then
                Dim xDoc As New Xml.XmlDocument()
                Dim xRoot As Xml.XmlElement = xDoc.AppendChild(xDoc.CreateElement("opml"))
                xRoot.SetAttribute("version", "1.0")
                Dim xHead As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement("head"))
                Dim xTitle As Xml.XmlElement = xHead.AppendChild(xDoc.CreateElement("title"))
                xTitle.InnerText = "TrulyMail OPML Export"
                Dim xDate As Xml.XmlElement = xHead.AppendChild(xDoc.CreateElement("dateCreated"))
                xDate.InnerText = Date.UtcNow.ToString(DATEFORMAT_XML)

                Dim xBody As Xml.XmlElement = xHead.AppendChild(xDoc.CreateElement("body"))
                Dim xOutline As Xml.XmlElement
                For Each feed As RSSFeed In AppSettings.RSSFeeds
                    xOutline = xBody.AppendChild(xDoc.CreateElement("outline"))
                    xOutline.SetAttribute("title", feed.Title)
                    xOutline.SetAttribute("text", feed.Title)
                    xOutline.SetAttribute("type", "rss")
                    xOutline.SetAttribute("version", "RSS")
                    xOutline.SetAttribute("xmlUrl", feed.URL)
                    xOutline.SetAttribute("htmlUrl", feed.HTMLUrl)
                Next
                xDoc.Save(sfd.FileName)
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error exporting your RSS settings." & CONTACT_TRULYMAIL_IFPROBLEMSPERSIST_MESSAGE)
        End Try

    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Try
            Dim ofd As New OpenFileDialog()
            ofd.Filter = "OPML Files|*.opml|XML Files|*.xml|All Files|*.*"
            If ofd.ShowDialog() = DialogResult.OK Then
                Dim boolAlreadySetup As Boolean
                Dim xDocRSS As New Xml.XmlDocument()
                xDocRSS.Load(ofd.FileName)
                Dim xList As Xml.XmlNodeList = xDocRSS.SelectNodes("//outline[@type='rss']")
                For Each xElement As Xml.XmlElement In xList
                    boolAlreadySetup = False
                    For Each feed As RSSFeed In AppSettings.RSSFeeds
                        If feed.URL.ToLower() = xElement.GetAttribute("xmlUrl").ToLower() Then
                            '-- already have it
                            boolAlreadySetup = True
                            Exit For
                        End If
                    Next
                    If Not boolAlreadySetup Then
                        '-- add it
                        Dim newFeed As New RSSFeed
                        newFeed.URL = xElement.GetAttribute("xmlUrl")
                        newFeed.HTMLUrl = xElement.GetAttribute("htmlUrl")
                        newFeed.Title = xElement.GetAttribute("title")
                        newFeed.Folder = MessageStoreRootPath & "RSS"
                        AppSettings.RSSFeeds.Add(newFeed)
                    End If
                Next
                LoadRSSFeeds()
            End If
        Catch ex As Exception
            Log(ex)
            ShowMessageBoxError("There was an error importing your RSS settings." & CONTACT_TRULYMAIL_MESSAGE)
        End Try
    End Sub

    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
    (ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, _
     ByVal lParam As Integer) As Integer

    Const LVM_FIRST As Integer = &H1000
    Const LVM_SCROLL As Integer = (LVM_FIRST + 20)




    Private Sub SetColumn(ByVal ColumnToSet As Integer)

        Dim Wid As Integer
        Dim BackToZero As Integer

        For x As Integer = 0 To ColumnToSet
            BackToZero += olvRSSSubscriptions.Columns(x).Width
        Next

        'BackToZero = olvRSSSubscriptions.Width

        SendMessage(olvRSSSubscriptions.Handle, LVM_SCROLL, -BackToZero, 0)

        For i As Integer = 0 To ColumnToSet - 2
            Wid += olvRSSSubscriptions.Columns(i).Width
        Next

        SendMessage(olvRSSSubscriptions.Handle, LVM_SCROLL, Wid, 0)

    End Sub

    Private Sub tmrShowErrorColumn_Tick(sender As System.Object, e As System.EventArgs) Handles tmrShowErrorColumn.Tick
        Try
            tmrShowErrorColumn.Stop()

            SetColumn(ErrorColumn.DisplayIndex)
            ErrorColumn.Renderer = New ColoredErrorRenderer()

            For Each item As RSSFeed In olvRSSSubscriptions.Objects
                If item.LastErrorMessage.StartsWith("Error:") Then
                    olvRSSSubscriptions.EnsureModelVisible(item)
                    Exit For
                End If
            Next
        Catch ex As Exception
            Log(ex)
        End Try

    End Sub
End Class