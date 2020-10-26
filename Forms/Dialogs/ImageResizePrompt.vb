Public Class ImageResizePrompt

    Private Sub ImageResizePrompt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case AppSettings.ImageResizeSize
            Case ImageResizeSizeEnum.None
                rbtnNone.Checked = True
            Case ImageResizeSizeEnum.x640
                rbtn640.Checked = True
            Case ImageResizeSizeEnum.x800
                rbtn800.Checked = True
            Case ImageResizeSizeEnum.x1024
                rbtn1024.Checked = True
            Case ImageResizeSizeEnum.x1600
                rbtn1600.Checked = True
        End Select

        cboPromptFrequency.SelectedIndex = CType(AppSettings.ImageResizePromptFrequency, Integer)
    End Sub
    Friend Function ImageResizeSize() As ImageResizeSizeEnum
        Return AppSettings.ImageResizeSize
    End Function
    Friend Function ImageResizePromptFrequency() As ImageResizePromptFrequencyEnum
        Return AppSettings.ImageResizePromptFrequency
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        AppSettings.ImageResizePromptFrequency = CType(cboPromptFrequency.SelectedIndex, ImageResizePromptFrequencyEnum)

        If rbtnNone.Checked Then
            AppSettings.ImageResizeSize = ImageResizeSizeEnum.None
        ElseIf rbtn640.Checked Then
            AppSettings.ImageResizeSize = ImageResizeSizeEnum.x640
        ElseIf rbtn800.Checked Then
            AppSettings.ImageResizeSize = ImageResizeSizeEnum.x800
        ElseIf rbtn1024.Checked Then
            AppSettings.ImageResizeSize = ImageResizeSizeEnum.x1024
        ElseIf rbtn1600.Checked Then
            AppSettings.ImageResizeSize = ImageResizeSizeEnum.x1600
        End If
    End Sub
End Class