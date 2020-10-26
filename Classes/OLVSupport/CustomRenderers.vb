Public Class ReadButtonRenderer
    Inherits BrightIdeasSoftware.ColumnButtonRenderer

   
End Class
Public Class ViewReceiveRenderer
    Inherits BrightIdeasSoftware.BaseRenderer

    Public Overrides Sub Render(ByVal g As System.Drawing.Graphics, ByVal r As System.Drawing.Rectangle)
        Dim strText As String = Me.GetText

        If strText.Length > 0 Then
            Dim i As Integer = Convert.ToInt32(strText.Substring(0, strText.Length - 1).Trim)

            Dim tm As TrulyMailMessage = CType(Me.ListItem.RowObject, TrulyMailMessage)
            If tm.MessageType = MessageType.Draft Then
                strText = "Draft"
                i = -1
            End If

            Select Case i
                Case -1
                    g.FillRectangle(Brushes.White, r)
                Case 0
                    g.FillRectangle(Brushes.Pink, r)
                Case 100
                    g.FillRectangle(Brushes.LightGreen, r)
                Case Else
                    g.FillRectangle(Brushes.LightBlue, r)
            End Select

            g.DrawString(strText, Me.ListView.Font, Brushes.Black, r)
        Else
            MyBase.Render(g, r)
        End If
    End Sub
End Class

Public Class HideTextRenderer
    Inherits BrightIdeasSoftware.BaseRenderer

    Public Overrides Sub Render(ByVal g As System.Drawing.Graphics, ByVal r As System.Drawing.Rectangle)
        Dim strText As String = Me.GetText
        Dim rectIcon As New Rectangle(r.Location, New Size(16, 16))
        Select Case strText
            Case "TrulyMail"
                g.DrawImage(My.Resources.Securedmessage_16, rectIcon)
            Case "Email"
                g.DrawImage(My.Resources.email_16, rectIcon)
            Case "EncryptedWebMessage"
                g.DrawImage(My.Resources.redemail_16, rectIcon)
            Case Else
                '-- do nothing
                Application.DoEvents()
        End Select
        'g.FillRectangle(Brushes.Pink, r)
        'g.DrawString(strText, Me.ListView.Font, Brushes.Black, r)
    End Sub
End Class

Public Class ColoredRenderer
    Inherits BrightIdeasSoftware.BaseRenderer

    Public Overrides Sub Render(ByVal g As System.Drawing.Graphics, ByVal r As System.Drawing.Rectangle)
        Dim strText As String = Me.GetText
        g.FillRectangle(Brushes.Pink, r)
        g.DrawString(strText, Me.ListView.Font, Brushes.Black, r)
    End Sub
End Class

Public Class ColoredErrorRenderer
    Inherits BrightIdeasSoftware.BaseRenderer

    Public Overrides Sub Render(ByVal g As System.Drawing.Graphics, ByVal r As System.Drawing.Rectangle)
        Dim strText As String = Me.GetText
        If strText.ToLower.StartsWith("error:") Then
            g.FillRectangle(Brushes.Pink, r)
            g.DrawString(GetText, Me.ListView.Font, Brushes.Black, r)
        Else
            MyBase.Render(g, r)
        End If
    End Sub
End Class

''' <summary>
''' When the path is "E:\TrulyMailPortable\Data\Messages\InBox", drawn will be "InBox"
''' </summary>
''' <remarks></remarks>
Public Class FolderPathRenderer
    Inherits BrightIdeasSoftware.BaseRenderer

    Public Overrides Sub Render(ByVal g As System.Drawing.Graphics, ByVal r As System.Drawing.Rectangle)
        Dim strText As String = Me.GetText

        If strText.Length > 0 Then
            strText = System.IO.Path.GetFileName(UnQualifyPath(strText))
            g.FillRectangle(Brushes.White, r)
            Dim sz As SizeF = g.MeasureString(strText, Me.ListView.Font)
            If sz.Height < r.Height Then
                g.DrawString(strText, Me.ListView.Font, Brushes.Black, r.X, r.Y + ((r.Height - sz.Height) / 2))
            Else
                g.DrawString(strText, Me.ListView.Font, Brushes.Black, r)
            End If
        Else
            MyBase.Render(g, r)
        End If
    End Sub

End Class
''' <summary>
''' Showing processing rule compare values is complex because it depends on the compare type
''' </summary>
''' <remarks></remarks>
Public Class ProcessingRuleCompareValueRenderer
    Inherits BrightIdeasSoftware.BaseRenderer

    Public Overrides Sub Render(ByVal g As System.Drawing.Graphics, ByVal r As System.Drawing.Rectangle)
        Dim strText As String = Me.GetText

        If strText.Length > 0 Then
            Dim match As ProcessingRuleMatchData = CType(Me.ListItem.RowObject, ProcessingRuleMatchData)
            Select Case match.EditorType
                Case ProcessingRuleEditorTypeEnum.None
                    '-- do nothing, actually should never get here because strText.Length should = 0
                Case ProcessingRuleEditorTypeEnum.TextBox
                    '-- do nothing
                Case ProcessingRuleEditorTypeEnum.TrulyMailContactSelector
                    Dim contact As AddressBookEntry = ABook.GetContactByID(strText)
                    If contact Is Nothing Then
                        strText = "--- MISSING CONTACT ---"
                    Else
                        strText = contact.ToString
                    End If
                Case ProcessingRuleEditorTypeEnum.EmailContactSelector
                    Dim contact As AddressBookEntry = ABook.GetContactByAddress(strText)
                    If contact Is Nothing Then
                        strText = "--- MISSING CONTACT ---"
                    Else
                        strText = contact.ToString
                    End If
                Case ProcessingRuleEditorTypeEnum.SMTPAccountSelector
                    Dim smtp As SMTPProfile = SMTPProfile.GetByID(strText)
                    If smtp Is Nothing Then
                        strText = "--- MISSING ACCOUNT ---"
                    Else
                        strText = smtp.ToString
                    End If
            End Select

            g.FillRectangle(Brushes.White, r)
            Dim sz As SizeF = g.MeasureString(strText, Me.ListView.Font)
            If sz.Height < r.Height Then
                g.DrawString(strText, Me.ListView.Font, Brushes.Black, r.X, r.Y + ((r.Height - sz.Height) / 2))
            Else
                g.DrawString(strText, Me.ListView.Font, Brushes.Black, r)
            End If
        Else
            g.FillRectangle(Brushes.White, r)
            MyBase.Render(g, r)
        End If
    End Sub
End Class
