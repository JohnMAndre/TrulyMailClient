Module AutoTextSupport
    Public Class AutoText
        Public ID As String
        Public Name As String
        Public Text As String
        Public HTML As Boolean
        Public IsNew As Boolean
        Public IsReply As Boolean
        Public IsForward As Boolean
        Public IsFollowUp As Boolean
        Public KeyValue As Keys '-- key, like Keys.D1
        Public ModifierKeys As Keys '-- modifier keys like Keys.Control or Keys.Shift
        Public Function HotKey() As String
            Dim strReturn As String = String.Empty
            If KeyValue <> Keys.None Then
                If (Me.ModifierKeys And Keys.Control) = Keys.Control Then
                    strReturn &= "Ctrl+"
                End If
                If (Me.ModifierKeys And Keys.Shift) = Keys.Shift Then
                    strReturn &= "Shift+"
                End If
                strReturn &= KeyValue.ToString().Substring(KeyValue.ToString().Length - 1)
            End If
            
            Return strReturn
        End Function
    End Class

End Module
