'-- This keeps many smaller classes in one place

Public Class DoNotSendEmailAddress
    Public Property Address As String
    Public Property Name As String
    Public Property Reason As String
End Class

Friend Class ReceiveFileDetails
    Public Property ReceiveDate As Date
    Public Property ReceiveSubject As String
    Public Property ReceiveSenderName As String
    Public Property ReceiveSenderEmailAddress As String
    Public Property ReceiveEmailAccount As POPProfile
    Public Property MessageFilename As String
    Public Property Details As String
    Public ReadOnly Property FolderName As String
        Get
            If MessageFilename.Length = 0 Then
                Return "<deleted>"
            Else
                Dim strDirName As String = System.IO.Path.GetDirectoryName(MessageFilename)

                Return System.IO.Path.GetFileName(strDirName)
            End If
        End Get
    End Property
    Public Sub New()

    End Sub
    Public Sub New(msg As aspNetMime.MimeMessage, pop As POPProfile)
        '-- parse and populate
        Try
            Me.ReceiveDate = Now
            If msg.Subject Is Nothing Then
                Me.ReceiveSubject = String.Empty
            Else
                Me.ReceiveSubject = msg.Subject.Value
            End If
            Me.ReceiveEmailAccount = pop
            Me.ReceiveSenderName = msg.From.Name
            Me.ReceiveSenderEmailAddress = msg.From.EmailAddress
        Catch ex As Exception
            Log(ex) '-- just log and continue, this is not a critical element of the app
        End Try


    End Sub
    Public Sub AddDetail(details As String)
        Me.Details &= details & Environment.NewLine
    End Sub
End Class

Friend Class SendMessageData
    Public recipientList As List(Of RecipientEntry)
    Public subject As String
    Public body As String
    Public attachmentList As List(Of String)
    Public sendWhen As Date
End Class

