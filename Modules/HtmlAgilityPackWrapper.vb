Imports System.IO
Imports HtmlAgilityPack

Module HtmlAgilityPackWrapper

#Region " Public Methods "
    Public Function HAPConvert(Path As String) As String
        Dim doc As New HtmlDocument()
        doc.Load(Path)
        Dim sw As New StringWriter()
        HAPConvertTo(doc.DocumentNode, sw)
        sw.Flush()
        Return sw.ToString()
    End Function
    Public Function HAPConvertHtml(html As String) As String
        Dim doc As New HtmlDocument()
        doc.LoadHtml(html)
        Dim sw As New StringWriter()
        HAPConvertTo(doc.DocumentNode, sw)
        sw.Flush()
        Return sw.ToString()
    End Function

    Public Sub HAPConvertTo(node As HtmlNode, outText As TextWriter)

        Dim html As String
        Select Case node.NodeType
            Case HtmlNodeType.Comment
                '-- Don't output comments
                '   do nothing
            Case HtmlNodeType.Document
                ConvertContentTo(node, outText)
            Case HtmlNodeType.Text
                '-- script and style must not be output
                Dim parentName As String = node.ParentNode.Name
                If parentName = "script" OrElse parentName = "style" Then
                    '-- Do nothing
                Else
                    '-- Get text
                    html = CType(node, HtmlTextNode).Text

                    '-- is it in fact a special closing node output as text?
                    If HtmlNode.IsOverlappedClosingElement(html) Then
                        '-- Do nothing
                    Else
                        '-- check the text is meaningful and not a bunch of whitespaces
                        If html.Trim().Length > 0 Then
                            outText.Write(HtmlEntity.DeEntitize(html))
                        End If
                    End If
                End If
            Case HtmlNodeType.Element
                Select Case node.Name
                    Case "p"
                        '--  treat paragraphs as crlf
                        outText.Write(Environment.NewLine)

                        If node.HasChildNodes Then
                            ConvertContentTo(node, outText)
                        End If
                End Select
        End Select
    End Sub
#End Region


#Region " Private Methods "
    Private Sub ConvertContentTo(node As HtmlNode, outText As TextWriter)
        For Each subnode As HtmlNode In node.ChildNodes
            HAPConvertTo(subnode, outText)
        Next
    End Sub
#End Region
End Module
