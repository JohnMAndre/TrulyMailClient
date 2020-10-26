Friend Class ReceiptSender
    Private WithEvents bkw As New System.ComponentModel.BackgroundWorker()
    Private m_strMessageID As String

    Friend Sub MarkMessageRead(ByVal messageID As String)
        '-- Try to tell the server asyncronously
        '   if that fails, write a message out in the unsent folder
        m_strMessageID = messageID
        'bkw.RunWorkerAsync() -- Removing this so receipts do not get put in the outbox (v 5.0) since there is no more server-communication
    End Sub

    Private Sub bkw_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bkw.DoWork
        Try
            Dim ctx As String = GetContext(MainFormReference).ContextID
            If ctx.Length > 0 Then
                If Not WebServiceWrapper.MarkMessageRead(ctx, EncryptTextAsymetric(m_strMessageID, SERVER_KEY_FILENAME), STANDARD_SERVER_TIMEOUT) Then
                    '-- timed out, write message to unsent
                    SendReadReceiptLater(m_strMessageID)
                End If
            Else
                '-- cannot connect, send later
                SendReadReceiptLater(m_strMessageID)
            End If
        Catch ex As Exception
            '-- something went wrong, log and send later
            Log(ex)
            SendReadReceiptLater(m_strMessageID)
        End Try
    End Sub

    Private Sub bkw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bkw.RunWorkerCompleted
        bkw.Dispose()
    End Sub
End Class
