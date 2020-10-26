Friend Class HTMLEditorK

    Public Property MessageWindow As NewMessage

    Public Property HTMLText As String
        Get
            Return RichTextBox1.Text
        End Get
        Set(value As String)
            RichTextBox1.Text = value
        End Set
    End Property

    Private Sub RichTextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles RichTextBox1.TextChanged
        btnSave.Enabled = True
        If UpdateMessageWindowToolStripMenuItem.Checked AndAlso MessageWindow IsNot Nothing Then
            MessageWindow.Editor1.SetHTMLContents(RichTextBox1.Text)
        End If
    End Sub

    Private Sub HTMLEditorRaw_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        btnSave.Enabled = False
    End Sub

    Private Sub AboutTrulyMailToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutTrulyMailToolStripMenuItem.Click
        Using frm As New AboutBoxK()
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub ContactNameToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContactNameToolStripMenuItem.Click
        RichTextBox1.SelectedText = NEWSLETTER_REPLACEMENTCODE_NAME
    End Sub

    Private Sub ContactEmailaddressToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContactEmailaddressToolStripMenuItem.Click
        RichTextBox1.SelectedText = NEWSLETTER_REPLACEMENTCODE_ADDRESS
    End Sub

    Private Sub ContactTagsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContactTagsToolStripMenuItem.Click
        RichTextBox1.SelectedText = NEWSLETTER_REPLACEMENTCODE_TAGS
    End Sub

    Private Sub DateLastMessageSentToContactToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DateLastMessageSentToContactToolStripMenuItem.Click
        RichTextBox1.SelectedText = NEWSLETTER_REPLACEMENTCODE_DATELASTSENT
    End Sub

    Private Sub DateLastMessageWasReceivedFromContactToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DateLastMessageWasReceivedFromContactToolStripMenuItem.Click
        RichTextBox1.SelectedText = NEWSLETTER_REPLACEMENTCODE_DATELASTRECEIVED
    End Sub

    Private Sub ContactCustomField1ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContactCustomField1ToolStripMenuItem.Click
        RichTextBox1.SelectedText = NEWSLETTER_REPLACEMENTCODE_CUSTOM1
    End Sub

    Private Sub ContactCustomField2ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContactCustomField2ToolStripMenuItem.Click
        RichTextBox1.SelectedText = NEWSLETTER_REPLACEMENTCODE_CUSTOM2
    End Sub

    Private Sub ContactCustomField3ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContactCustomField3ToolStripMenuItem.Click
        RichTextBox1.SelectedText = NEWSLETTER_REPLACEMENTCODE_CUSTOM3
    End Sub

    Private Sub ContactCustomField4ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContactCustomField4ToolStripMenuItem.Click
        RichTextBox1.SelectedText = NEWSLETTER_REPLACEMENTCODE_CUSTOM4
    End Sub

    Private Sub ContactHomePhoneNumberToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContactHomePhoneNumberToolStripMenuItem.Click
        RichTextBox1.SelectedText = NEWSLETTER_REPLACEMENTCODE_HOME
    End Sub

    Private Sub ContactWorkPhoneNumberToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContactWorkPhoneNumberToolStripMenuItem.Click
        RichTextBox1.SelectedText = NEWSLETTER_REPLACEMENTCODE_WORK
    End Sub

    Private Sub ContactMobilePhoneNumberToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContactMobilePhoneNumberToolStripMenuItem.Click
        RichTextBox1.SelectedText = NEWSLETTER_REPLACEMENTCODE_MOBILE
    End Sub

    Private Sub ContactWebAddressToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContactWebAddressToolStripMenuItem.Click
        RichTextBox1.SelectedText = NEWSLETTER_REPLACEMENTCODE_WEB
    End Sub

    Private Sub ContactDateAddedToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContactDateAddedToolStripMenuItem.Click
        RichTextBox1.SelectedText = NEWSLETTER_REPLACEMENTCODE_DATEADDED
    End Sub

    Private Sub UpdateMessageWindowToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UpdateMessageWindowToolStripMenuItem.Click
        If UpdateMessageWindowToolStripMenuItem.Checked AndAlso MessageWindow IsNot Nothing Then
            MessageWindow.Editor1.SetHTMLContents(RichTextBox1.Text)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
