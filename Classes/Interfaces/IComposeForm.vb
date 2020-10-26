Public Interface IComposeForm
    Function AddAttachmentToList(ByVal filename As String, ByVal allowResize As Boolean) As Boolean
    Sub AddRecipient(name As String, email As String)
    Sub UseSendingAccount(index As Integer)
    Sub SendThisMessage(sendWhen As Date)
    Sub AddAttachment(filename As String)
    Property Subject As String
    Property Body As String
    Property SendAsPlainText As Boolean
End Interface
