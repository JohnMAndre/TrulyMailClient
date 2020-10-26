Module Conversion
    Public Function ConvertToBool(ByVal value As String, ByVal valueIfCannotConvert As Boolean) As Boolean
        Try
            Return Convert.ToBoolean(value)
        Catch ex As Exception
            Return valueIfCannotConvert
        End Try
    End Function
    Public Function ConvertToDouble(ByVal value As String, ByVal valueIfCannotConvert As Double) As Double
        Try
            Return Convert.ToDouble(value)
        Catch ex As Exception
            Return valueIfCannotConvert
        End Try
    End Function
    Public Function ConvertToDecimal(ByVal value As String, ByVal valueIfCannotConvert As Decimal) As Decimal
        Try
            Return Convert.ToDecimal(value)
        Catch ex As Exception
            Return valueIfCannotConvert
        End Try
    End Function
    Public Function ConvertToInt32(ByVal value As String, ByVal valueIfCannotConvert As Integer) As Integer
        Try
            If value.Contains(".") Then
                value = value.Substring(0, value.IndexOf("."))
            End If
            Return Convert.ToInt32(value)
        Catch ex As Exception
            Return valueIfCannotConvert
        End Try
    End Function
    Public Function ConvertToInt64(ByVal value As String, ByVal valueIfCannotConvert As Long) As Long
        Try
            If value.Contains(".") Then
                value = value.Substring(0, value.IndexOf("."))
            End If
            Return Convert.ToInt64(value)
        Catch ex As Exception
            Return valueIfCannotConvert
        End Try
    End Function
    Public Function ConvertToColor(ByVal value As String, ByVal valueIfCannotConvert As Color) As Color
        If value.Length = 0 Then
            Return valueIfCannotConvert
        Else
            Try
                Return Color.FromArgb(value)
            Catch ex As Exception
                Return valueIfCannotConvert
            End Try
        End If
    End Function
    Public Function ConvertToNullableDate(ByVal value As String, ByVal valueIfCannotConvert As Nullable(Of Date)) As Nullable(Of Date)
        Try
            If value Is Nothing OrElse value.Length = 0 Then
                Return valueIfCannotConvert
            Else
                Try
                    Return Date.Parse(value)
                Catch ex As Exception
                    Return valueIfCannotConvert
                End Try
            End If
        Catch ex As Exception
            Log(ex)
            Return valueIfCannotConvert
        End Try
    End Function
    Public Function ConvertToDate(ByVal value As String, ByVal valueIfCannotConvert As Date) As Date
        Try
            If value Is Nothing OrElse value.Length = 0 Then
                Return valueIfCannotConvert
            Else
                Try
                    Return Date.Parse(value)
                Catch ex As Exception
                    Return valueIfCannotConvert
                End Try
            End If
        Catch ex As Exception
            Log(ex)
            Return valueIfCannotConvert
        End Try
    End Function
    Public Function ConvertToDateFromXML(ByVal value As String, ByVal valueIfCannotConvert As Date) As Date
        '-- Italian windows, for example, seems to store xml dates (even formated with literals h:mm) as h.mm as in "2011-01-24T19.09.28.125"
        '   now, try to get date and time, then date, then use default value if all else fails
        If value.Length < 5 Then '1/1/01 = min of 6 characters
            Return valueIfCannotConvert
        Else
            Try
                '-- Try simple conversion
                Return Xml.XmlConvert.ToDateTime(value, Xml.XmlDateTimeSerializationMode.Unspecified)
            Catch ex As Exception
                Log("Error in ConvertToDateFromXML: " & value)
                Log(ex)
                Try
                    '-- Try converting without the time
                    If value.IndexOf("T") > 0 Then
                        Dim strDateOnly As String = value.Substring(0, value.IndexOf("T"))
                        Return Convert.ToDateTime(strDateOnly)
                    End If
                Catch ex2 As Exception
                    Log(ex2)
                    Return valueIfCannotConvert
                End Try
            End Try
        End If
    End Function
    Public Function ConvertHtmlToPlainText(html As String) As String
        Dim strReturn As String = HtmlToText.ConvertHtml(html)
        strReturn = strReturn.Replace(Environment.NewLine & Environment.NewLine & Environment.NewLine & Environment.NewLine & Environment.NewLine & Environment.NewLine, Environment.NewLine & Environment.NewLine) '-- 6 newlines become 2
        strReturn = strReturn.Replace(Environment.NewLine & Environment.NewLine & Environment.NewLine & Environment.NewLine & Environment.NewLine, Environment.NewLine & Environment.NewLine) '-- 5 newlines become 2
        strReturn = strReturn.Replace(Environment.NewLine & Environment.NewLine & Environment.NewLine & Environment.NewLine, Environment.NewLine & Environment.NewLine) '-- 4 newlines become 2
        strReturn = strReturn.Replace(Environment.NewLine & Environment.NewLine & Environment.NewLine, Environment.NewLine & Environment.NewLine) '-- 3 newlines become 2
        Return strReturn
    End Function
    Public Function UnBlockImagesOnlyInHtml(html As String) As String
        Return html.Replace("src=""---", "src=""")
    End Function
    Public Function RemoveAccents(accentedText As String) As String
        Try
            Dim strWorking As String = accentedText.Normalize(System.Text.NormalizationForm.FormKD)
            Dim sb As New System.Text.StringBuilder()
            For Each c As Char In strWorking
                Select Case System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c)
                    Case System.Globalization.UnicodeCategory.NonSpacingMark, System.Globalization.UnicodeCategory.SpacingCombiningMark, System.Globalization.UnicodeCategory.EnclosingMark
                        Application.DoEvents() '-- do nothing
                    Case Else
                        sb.Append(c)
                End Select
            Next

            sb.Replace("Đ", "D")

            Return sb.ToString().Replace("  ", " ") '-- remove extra spaces
        Catch ex As Exception
            Return accentedText
            Log(ex)
        End Try
    End Function

    'Public Function ConvertHtmlToPlainText(html As String) As String
    '    '-- Answer found here: https://stackoverflow.com/a/16407272

    '    Const tagWhiteSpace As String = "(>|$)(\W|\n|\r)+<" ' matches one or more (white space or line breaks) between '>' and '<'
    '    Const stripFormatting As String = "<[^>]*(>|$)" ' match any character between '<' and '>', even when end tag is missing

    '    Const pTagsConvertToLineBreak As String = "<[p|P>]*(>|$)"
    '    Dim pTagsConvertToLineBreakRegex As New System.Text.RegularExpressions.Regex(pTagsConvertToLineBreak, System.Text.RegularExpressions.RegexOptions.Multiline)

    '    Const lineBreak As String = "<(br|BR)\s{0,1}\/{0,1}>" ' matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
    '    Dim lineBreakRegex As New System.Text.RegularExpressions.Regex(lineBreak, System.Text.RegularExpressions.RegexOptions.Multiline)

    '    Dim stripFormattingRegex As New System.Text.RegularExpressions.Regex(stripFormatting, System.Text.RegularExpressions.RegexOptions.Multiline)
    '    Dim tagWhiteSpaceRegex As New System.Text.RegularExpressions.Regex(tagWhiteSpace, System.Text.RegularExpressions.RegexOptions.Multiline)
    '    Dim spaceRegex As New System.Text.RegularExpressions.Regex("[ ]{2,}", System.Text.RegularExpressions.RegexOptions.None)

    '    Dim strReturn As String = html

    '    'Remove p-tag (replace with br)
    '    strReturn = pTagsConvertToLineBreakRegex.Replace(strReturn, "<br>")
    '    'Remove tag whitespace/line breaks
    '    strReturn = tagWhiteSpaceRegex.Replace(strReturn, "><")
    '    'Replace <br /> with line breaks
    '    strReturn = lineBreakRegex.Replace(strReturn, Environment.NewLine)
    '    'Strip formatting
    '    strReturn = stripFormattingRegex.Replace(strReturn, String.Empty)

    '    strReturn = spaceRegex.Replace(strReturn, String.Empty)

    '    'Decode html specific characters
    '    strReturn = System.Net.WebUtility.HtmlDecode(strReturn)

    '    Return strReturn

    'End Function

End Module
