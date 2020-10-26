Friend Class NotifyForm

    Private m_buttons As MessageBoxButtons
    Private m_autoCloseButton As MessageBoxDefaultButton

    Public Enum DoNotShowSetting
        DoNotShowEmailRecipientNotEncrypted
        DoNotShowEmailRecipientNoReply
        DoNotShowReadReceiptWillNotBeRequested
        DoNotShowReplyAllBCCNotice
        DoNotShowAddEmailAccountNotice
        DoNotShowBlockedScriptsNotice
        DoNotShowRemovedRecipientNotice
        DoNotShowDecryptedBodyOverwriteWarning
        DoNotShowBlockedIFramesNotice
        DoNotShowPOP3DownloadErrorNotice
        DoNotShowMissingSubjectNotice
        DoNotShowShutDownErrorNotice
        DoNotShowSMTPServerConnectionTimeOutErrorNotice
        DoNotShowPOPServerConnectionTimeOutErrorNotice
        DoNotShowRSSErrorListPrompt
    End Enum
    Private m_doNotShowSetting As DoNotShowSetting

    Friend Sub New(ByVal description As String, ByVal noShowSetting As DoNotShowSetting, Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Label1.Text = description
        m_doNotShowSetting = noShowSetting
        m_buttons = buttons

        Select Case buttons
            Case MessageBoxButtons.OK
                btnOK.Visible = True
            Case MessageBoxButtons.YesNo
                btnYes.Visible = True
                btnYes.Focus()
                btnNo.Visible = True
        End Select
    End Sub
    Private Sub ResizeFormToFixLabel()
        Me.Height = Label1.Height + 195
        Me.Width = Label1.Width + 60
    End Sub
    Private Sub NotifyForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = Application.ProductName
        ResizeFormToFixLabel()
    End Sub

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click, btnYes.Click, btnNo.Click
        If chkDoNotShowAgain.Checked Then
            Select Case m_doNotShowSetting
                Case DoNotShowSetting.DoNotShowEmailRecipientNotEncrypted
                    AppSettings.DoNotShowEmailRecipientNotEncrypted = True
                Case DoNotShowSetting.DoNotShowEmailRecipientNoReply
                    AppSettings.DoNotShowEmailRecipientNoReply = True
                Case DoNotShowSetting.DoNotShowReadReceiptWillNotBeRequested
                    AppSettings.DoNotShowReadReceiptWillNotBeRequested = True
                Case DoNotShowSetting.DoNotShowReplyAllBCCNotice
                    AppSettings.DoNotShowReplyAllBCCNotice = True
                Case DoNotShowSetting.DoNotShowAddEmailAccountNotice
                    AppSettings.DoNotShowAddEmailAccountNotice = True
                Case DoNotShowSetting.DoNotShowBlockedScriptsNotice
                    AppSettings.DoNotShowBlockedScriptsNotice = True
                Case DoNotShowSetting.DoNotShowRemovedRecipientNotice
                    AppSettings.DoNotShowRemovedRecipientNotice = True
                Case DoNotShowSetting.DoNotShowDecryptedBodyOverwriteWarning
                    AppSettings.DoNotShowDecryptedBodyOverwriteWarning = True
                Case DoNotShowSetting.DoNotShowBlockedIFramesNotice
                    AppSettings.DoNotShowBlockedIFramesNotice = True
                Case DoNotShowSetting.DoNotShowPOP3DownloadErrorNotice
                    AppSettings.DoNotShowPOP3DownloadErrorNotice = True
                Case DoNotShowSetting.DoNotShowMissingSubjectNotice
                    AppSettings.DoNotShowMissingSubjectNotice = True
                Case DoNotShowSetting.DoNotShowShutDownErrorNotice
                    AppSettings.DoNotShowShutDownErrorNotice = True
                Case DoNotShowSetting.DoNotShowSMTPServerConnectionTimeOutErrorNotice
                    AppSettings.DoNotShowSMTPServerConnectionTimeOutErrorNotice = True
                Case DoNotShowSetting.DoNotShowPOPServerConnectionTimeOutErrorNotice
                    AppSettings.DoNotShowPOPServerConnectionTimeOutErrorNotice = True
                Case DoNotShowSetting.DoNotShowRSSErrorListPrompt
                    AppSettings.DoNotShowRSSErrorListPrompt = True
            End Select
            AppSettings.Save()
        End If
    End Sub

    Private Sub NotifyForm_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        SetForegroundWindow(Me.Handle)

        '-- make sure the height is correct
        Const MARGIN As Integer = 176
        If Me.Height - Label1.Height < MARGIN Then
            Me.Height = Label1.Height + MARGIN
        End If
    End Sub

    Private Sub Label1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.TextChanged
        ResizeFormToFixLabel()
    End Sub


    Public Sub AutoClose(seconds As Integer, defaultButton As MessageBoxDefaultButton)
        m_autoCloseButton = defaultButton
        tmrAutoClose.Interval = seconds * 1000
        tmrAutoClose.Start()
    End Sub

    Private Sub tmrAutoClose_Tick(sender As Object, e As System.EventArgs) Handles tmrAutoClose.Tick
        tmrAutoClose.Stop()
        Select Case m_buttons
            Case MessageBoxButtons.OK
                Me.btnOK.PerformClick()
            Case MessageBoxButtons.YesNo
                If m_autoCloseButton = MessageBoxDefaultButton.Button1 Then
                    Me.btnYes.PerformClick()
                Else
                    Me.btnNo.PerformClick()
                End If
        End Select
    End Sub
End Class