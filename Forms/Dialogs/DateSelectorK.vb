Public Class DateSelectorK
    Public Property DateTime() As Date
        Get
            Dim dt As Date = Me.MonthCalendar1.SelectionStart
            dt = dt.Add(Me.DateTimePicker1.Value.TimeOfDay)
            Return dt
        End Get
        Set(ByVal value As Date)
            MonthCalendar1.SelectionStart = value.Date
            MonthCalendar1.SelectionEnd = value.Date
            DateTimePicker1.Value = value.Date
        End Set
    End Property
    Private Sub DateSelector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MonthCalendar1.MinDate = Date.Today
        Me.MonthCalendar1.MaxDate = Date.Today.AddYears(2)
        Me.DateTimePicker1.Value = Date.Now

        LoadDefaults()
    End Sub
    Private Sub LoadDefaults()
        llblDefaultTime.Text = AppSettings.DefaultSendLaterTime.ToString("h:mm tt")
    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        UpdateTimeEstimate()
    End Sub

    Private Sub UpdateTimeEstimate()
        Dim dt As Date = DateTime
        Dim ts As TimeSpan = dt - Date.Now
        If ts.TotalSeconds <= 0 Then
            lblMessage.Text = "Send immediately."
        Else
            lblMessage.Text = "Send in " & FormatTimeSpan2(ts)
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        UpdateTimeEstimate()
    End Sub

    Private Sub llblDefaultTime_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblDefaultTime.LinkClicked
        Dim dt As Date = Me.MonthCalendar1.SelectionStart
        dt = dt.Add(AppSettings.DefaultSendLaterTime.TimeOfDay)
        DateTimePicker1.Value = dt
    End Sub

    Private Sub llblSetDefaultTime_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblSetDefaultTime.LinkClicked
        AppSettings.DefaultSendLaterTime = DateTimePicker1.Value
        LoadDefaults()
    End Sub
End Class
