Public Class AutoCloseMessageBox
    Private m_dtAutoCloseTime As Date
    Private m_intTotalSeconds As Integer

    Public Sub New(ByVal message As String, ByVal seconds As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Label1.Text = message
        Application.DoEvents()

        m_intTotalSeconds = seconds
        m_dtAutoCloseTime = Date.Now.AddSeconds(seconds)
        Timer1.Start()

        ResizeFormToFixLabel()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '-- This is the auto-close part
        If m_dtAutoCloseTime < Date.Now Then
            Me.Close()
        Else
            '-- for first 50% of the time, don't do anything
            '   for second 50%, show count-down
            Dim ts As TimeSpan = m_dtAutoCloseTime - Date.Now
            If ts.TotalSeconds < (m_intTotalSeconds / 2) Then
                btnOK.Text = "&OK (" & ts.TotalSeconds.ToString("#,##0") & ")"
            End If
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub AutoCloseMessageBox_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        SetForegroundWindow(Me.Handle)
        Me.Height = Label1.Height + 160
    End Sub
    Private Sub ResizeFormToFixLabel()
        Me.Height = Label1.Height + 160
        Me.Width = Label1.Width + 60
    End Sub

    Private Sub Label1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.TextChanged
        ResizeFormToFixLabel()
    End Sub

End Class