Module EmailSupport
    ''' <summary>
    ''' Returns true if email address is on Do Not Send list
    ''' </summary>
    ''' <param name="emailAddress"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EmailAddressIsOnDoNotSendList(emailAddress As String) As Boolean
        For Each obj As DoNotSendEmailAddress In AppSettings.DoNotSendAddressList
            If obj.Address.ToLower() = emailAddress.ToLower() Then
                Return True
            End If
        Next

        Return False
    End Function
End Module
