
Module RSSSupport
    Friend Class RSSFeed
        Public Title As String
        Public URL As String
        Public Folder As String
        Public ShowSummary As Boolean '-- false to load web page
        Public DownloadAttachments As Boolean '-- true to download Yahoo media content
        Public HTMLUrl As String
        Public ForcePlainText As Boolean
        Public AddLinkToPlainText As Boolean
        Public LastErrorMessage As String = String.Empty
    End Class
    Friend Class RSSMessage
        Public Filename As String
        Public Title As String
        Public Link As String
        Public Description As String
        Public PublicationDate As Date
        Public Originator As String
        Public GUID As String
        Public Attachments As New List(Of String)
        Public BodyFormat As EmailBodyFormatEnum

        Public Sub New()

        End Sub
        Public Sub Save(ByVal folder As String)
            If Filename Is Nothing Then
                '-- calculate a 128-bit hash, so we end up with a guid
                Dim hash As New System.Security.Cryptography.MD5Cng()
                Dim b() As Byte = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Link))
                Dim g As New Guid(b)
                hash.Clear()
                hash = Nothing
                GUID = g.ToString()
                Filename = QualifyPath(folder) & GUID & MESSAGE_FILENAME_EXTENSION
            End If

            Dim xDoc As New Xml.XmlDocument()
            Dim xRoot As Xml.XmlElement = xDoc.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_RSSITEM))
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGEID, GUID)
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_RECEIVED, Date.UtcNow.ToString(DATEFORMAT_XML))
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGETYPEID, MESSAGETYPE_RSSARTICLE)
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENTDATE, PublicationDate.ToString(DATEFORMAT_XML))
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_IMPORTANCE, 0)
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_SENDERFULLNAME, Originator)
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_RSSLINK, Link)
            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_RSSPUBDATE, PublicationDate)
            Dim xSubject As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_SUBJECT))
            xSubject.InnerText = Title
            Dim xDesc As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_BODY))
            If BodyFormat = EmailBodyFormatEnum.PlainText Then
                xDesc.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FORMAT, BODYFORMAT_PLAINTEXT)
            Else
                xDesc.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FORMAT, BODYFORMAT_HTML)
            End If
            xDesc.InnerText = Description

            Dim lngTotalMessageWithAttachmentSize As Long = xDoc.OuterXml.Length().ToString()

            Dim strAttachmentFolder As String = QualifyPath(AttachmentsRootPath & GUID)
            Dim strAttachmentFilename As String
            If Attachments.Count > 0 Then
                Dim xAttachments As Xml.XmlElement = xRoot.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ATTACHMENTS))
                For Each strAtt As String In Attachments
                    Dim xAttachment As Xml.XmlElement = xAttachments.AppendChild(xDoc.CreateElement(MESSAGE_ATTRIBUTE_NAME_ATTACHMENT))
                    strAttachmentFilename = System.IO.Path.GetFileName(strAtt)
                    xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_NAME, strAttachmentFilename)
                    xAttachment.SetAttribute(MESSAGE_ATTRIBUTE_NAME_FILESIZE, FileLen(strAtt).ToString())
                    lngTotalMessageWithAttachmentSize += FileLen(strAtt)
                Next
            End If

            xRoot.SetAttribute(MESSAGE_ATTRIBUTE_NAME_MESSAGESIZE, lngTotalMessageWithAttachmentSize.ToString())

            If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(Filename)) Then
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Filename))
            End If
            xDoc.Save(Filename)
            If Not AppSettings.RSSMessagesReceived.ContainsKey(Link) Then
                AppSettings.RSSMessagesReceived.Add(Link, Nothing) '-- track what's been downloaded and saved, so we don't re-download any articles
            End If
        End Sub
    End Class
    Friend Sub SetupFeed(ByRef feedToSetup As RSSFeed, ByVal url As String)
        Try
            Dim feed As New Argotic.Syndication.RssFeed()
            feed.Load(New System.Uri(url), System.Net.CredentialCache.DefaultNetworkCredentials, Nothing)
            feedToSetup.Title = feed.Channel.Title
            feedToSetup.HTMLUrl = feed.Channel.Link.ToString()
        Catch ex As Exception
            Log(ex)
            Log("RSS URL: " & url)
            Throw ex
        End Try
    End Sub

    Public Structure RSSDownloadResults
        Public ArticlesDownloaded As Integer
        Public ErrorText As String
    End Structure
    ''' <summary>
    ''' Returns True if any articles were downloaded
    ''' </summary>
    ''' <param name="url"></param>
    ''' <param name="folder"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetNewRSSItemsForFeed(ByVal feed As RSSFeed) As RSSDownloadResults
        Dim returnRSSDownloadResults As RSSDownloadResults

        Try
            Dim msg As RSSMessage
            Dim yahoo As New Argotic.Extensions.Core.YahooMediaSyndicationExtension()
            Dim afeed As New Argotic.Syndication.RssFeed()
            Dim wc As New System.Net.WebClient

            afeed.Load(New System.Uri(feed.URL), System.Net.CredentialCache.DefaultNetworkCredentials, Nothing)
            For Each item As Argotic.Syndication.RssItem In afeed.Channel.Items
                'Dim x As String = wc.DownloadString(item.Link.ToString())

                msg = New RSSMessage()
                msg.Link = item.Link.ToString().Trim()
                '-- don't download something that's already been downloaded
                If Not AppSettings.RSSMessagesReceived.ContainsKey(msg.Link) Then
                    msg.Title = System.Web.HttpUtility.HtmlDecode(item.Title) '-- some places will send text this way (like Slashdot.org)
                    If feed.ShowSummary Then
                        If feed.ForcePlainText Then
                            msg.Description = StripHTML(item.Description)
                            If feed.AddLinkToPlainText Then
                                msg.Description &= Environment.NewLine & Environment.NewLine & item.Link.ToString()
                            End If
                            msg.BodyFormat = EmailBodyFormatEnum.PlainText
                        Else
                            If IsHTML(item.Description) Then
                                msg.BodyFormat = EmailBodyFormatEnum.HTML
                            Else
                                msg.BodyFormat = EmailBodyFormatEnum.PlainText
                            End If
                            msg.Description = item.Description
                        End If
                    Else
                        Dim strPage As String = wc.DownloadString(item.Link.ToString())
                        msg.Description = strPage
                    End If
                    If item.PublicationDate = #12:00:00 AM# Then
                        msg.PublicationDate = Date.UtcNow
                    Else
                        msg.PublicationDate = item.PublicationDate
                    End If
                    If item.Author.Trim.Length = 0 Then
                        msg.Originator = afeed.Channel.Title
                    Else
                        msg.Originator = item.Author
                    End If
                    msg.Save(feed.Folder)

                    If feed.DownloadAttachments Then
                        '-- Get any media content which goes with this RSS article
                        For Each ext As Argotic.Extensions.ISyndicationExtension In item.Extensions
                            If ext.Name = yahoo.Name Then
                                yahoo = CType(ext, Argotic.Extensions.Core.YahooMediaSyndicationExtension)
                                For Each group As Argotic.Extensions.Core.YahooMediaGroup In yahoo.Context.Groups
                                    For Each content As Argotic.Extensions.Core.YahooMediaContent In group.Contents
                                        Dim data() = wc.DownloadData(content.Url.ToString())
                                        Dim strFilename As String = AttachmentsRootPath & msg.GUID & "\" & System.Web.HttpUtility.UrlDecode(System.IO.Path.GetFileName(content.Url.ToString()))
                                        If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strFilename)) Then
                                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strFilename))
                                        End If
                                        System.IO.File.WriteAllBytes(strFilename, data)
                                        msg.Attachments.Add(strFilename)
                                    Next
                                Next
                            End If
                        Next

                        '-- Sometimes media content is actually an enclosure so get these too
                        For Each encl As Argotic.Syndication.RssEnclosure In item.Enclosures
                            Dim data() = wc.DownloadData(encl.Url.ToString())
                            Dim strFilename As String = AttachmentsRootPath & msg.GUID & "\" & System.Web.HttpUtility.UrlDecode(System.IO.Path.GetFileName(encl.Url.ToString()))
                            If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strFilename)) Then
                                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strFilename))
                            End If
                            System.IO.File.WriteAllBytes(strFilename, data)
                            msg.Attachments.Add(strFilename)

                            'MsgBox(encl.Url.ToString() & vbNewLine & encl.Length.ToString("#,##0") & vbNewLine & item.Title)
                            'For Each ext As Argotic.Extensions.ISyndicationExtension In encl.Extensions
                            '    MsgBox(ext.Description & vbNewLine & ext.Name)
                            'Next
                        Next


                        If msg.Attachments.Count > 0 Then
                            msg.Save(feed.Folder)
                        End If
                    End If



                    returnRSSDownloadResults.ArticlesDownloaded += 1
                End If
            Next

            returnRSSDownloadResults.ErrorText = String.Empty
            Return returnRSSDownloadResults

        Catch ex As System.Net.WebException
            Log(ex) '-- cannot connect to server
            Log("RSS URL: " & feed.URL)

            returnRSSDownloadResults.ErrorText = "Cannot connect to server (" & feed.URL & ")"
            Return returnRSSDownloadResults

            '-- ignore and continue
        Catch ex As Exception
            Log(ex) '-- log and continue with next feed
            Log("RSS URL: " & feed.URL)
            returnRSSDownloadResults.ErrorText = ex.Message & " (Feed address:" & feed.URL & ")"
            Return returnRSSDownloadResults

        End Try
    End Function
End Module
