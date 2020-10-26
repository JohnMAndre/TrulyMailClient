Public Class DuplicateMessageFinderProgressForm

    Private m_boolCancel As Boolean
    Private m_intMaximum As Integer

    Public Sub New(totalCount As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        m_intMaximum = totalCount
        prgOverallStep.Maximum = totalCount

        m_boolCancel = False
        lblTotalComparisonsToMake.Text = CalculateComparisons(totalCount - 1).ToString("#,##0")
    End Sub
    Private Function CalculateComparisons(base As Long) As Long
        Return Convert.ToInt64((base * (base - 1)) / 2)
        'Dim lngReturn As Long
        'For lngCounter As Long = 1 To base
        '    lngReturn += lngCounter
        'Next
        'Return lngReturn
    End Function

    Private Sub DuplicateMessageFinderProgressForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not m_boolCancel Then
            e.Cancel = True
        End If
    End Sub
    Private Sub DuplicateMessageFinderProgressForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        m_boolCancel = False
    End Sub

    Public Sub SetStatus(item As Integer, itemCount As Integer, ByRef cancel As Boolean)
        prgOverallStep.Value = item
        lblOverallStep.Text = "Message " & item.ToString("#,##0") & " of " & itemCount.ToString("#,##0")

        cancel = m_boolCancel
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        m_boolCancel = True
        btnCancel.Enabled = False
    End Sub

    Private Sub pbComparisonInfo_Click(sender As System.Object, e As System.EventArgs) Handles pbComparisonInfo.Click
        lblComparisonInfo.Visible = Not lblComparisonInfo.Visible
    End Sub

    Private Sub DuplicateMessageFinderProgressForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        SetForegroundWindow(Me.Handle)
    End Sub
End Class
