Public Class ScheduleMessagesInOutboxForm

    Private Sub rbtnSendNow_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSendNow.CheckedChanged
        MonthCalendar1.Enabled = rbtnAtTime.Checked
        DateTimePicker1.Enabled = rbtnAtTime.Checked
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim files() As String = System.IO.Directory.GetFiles(OutboxRootPath)
        If files.Length = 0 Then
            Exit Sub
        End If
        Dim tmm As TrulyMailMessage
        Dim dtStartDate As Date
        If rbtnAtTime.Checked Then
            dtStartDate = MonthCalendar1.SelectionRange.Start.Date
            dtStartDate = dtStartDate.AddHours(DateTimePicker1.Value.Hour)
            dtStartDate = dtStartDate.AddMinutes(DateTimePicker1.Value.Minute)
            dtStartDate = dtStartDate.AddSeconds(DateTimePicker1.Value.Second)
            'dtStartDate = ConvertToUtc(dtStartDate)
            If Date.Now > dtStartDate Then
                dtStartDate = Date.Now
            End If
        Else
            dtStartDate = Date.Now
        End If

        Dim intCounter As Integer
        For Each file As String In files
            lblUpdateStatus.Text = "Processing " & intCounter.ToString("#,##0") & " of " & files.Count.ToString("#,##0")
            Application.DoEvents()
            tmm = New TrulyMailMessage(file)
            tmm.MessageDateToSend = dtStartDate
            tmm.Save()
            dtStartDate = dtStartDate.AddSeconds(nudSendInterval.Value)
        Next
        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub ScheduleMessagesInOutboxForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MonthCalendar1.MinDate = Date.Today()
        MonthCalendar1.SelectionRange.Start = Date.Today
        MonthCalendar1.SelectionRange.End = Date.Today
        DateTimePicker1.Value = Date.Now()

    End Sub
End Class