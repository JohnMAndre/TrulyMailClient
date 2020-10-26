Public Class OpacityNoticeForm

    Private m_dblOpacity As Double
    Private m_boolShowing As Boolean = True

    Public Sub New(ByVal message As String, ByVal seconds As Double)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        lblMessage.Text = message

        '-- We want to show and hide over the time passed in
        Dim dblInterval As Double = seconds * 100 / 2 '100 = 1000ms/s divided by 10% opacity change per interval
        Timer1.Interval = ConvertToInt32(dblInterval, 250)
        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '-- Now we must increase/decrease the opactiy until the form shows, or is hidden completely
        If m_boolShowing Then
            m_dblOpacity += 0.1
            If m_dblOpacity >= 1 Then
                m_boolShowing = False
            Else
                Me.Opacity = m_dblOpacity
            End If
        Else
            m_dblOpacity -= 0.1
            If m_dblOpacity <= 0 Then
                Close()
            Else
                Me.Opacity = m_dblOpacity
            End If
        End If
    End Sub

    Private Sub OpacityNoticeForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '-- manually center on parent
        If Me.Owner IsNot Nothing Then
            Me.Left = Me.Owner.Left + (Me.Owner.Width / 2) - (Me.Width / 2)
            Me.Top = Me.Owner.Top + (Me.Owner.Height / 2) - (Me.Height / 2)
        Else
            Me.StartPosition = FormStartPosition.CenterScreen
        End If
    End Sub
End Class
