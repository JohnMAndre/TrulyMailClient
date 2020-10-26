Public Class RTFForm

    Private Sub RTFForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.RichTextBox1.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}}" & Environment.NewLine & _
                                "\viewkind4\uc1\pard\b\f0\fs20 What is TrulyMail\b0\par" & Environment.NewLine & _
                                "\par" & Environment.NewLine & _
                                "TrulyMail is two things: \par" & Environment.NewLine & _
                                "\par" & Environment.NewLine & _
                                "1) A very powerful email client, and\par" & Environment.NewLine & _
                                "\par" & Environment.NewLine & _
                                "2) A reliable, private, secure messaging system\par" & Environment.NewLine & _
                                "\par" & Environment.NewLine & _
                                "This TrulyMail application supports sending and receiving messages via email servers (can be encrypted or not encrypted) and via TrulyMail servers (always encrypted).\par" & Environment.NewLine & _
                                "\par" & Environment.NewLine & _
                                "When you send a message to \b TrulyMail recipients\b0 , the message does NOT go through any email server. Your messages to \b TrulyMail recipients\b0  are ALWAYS \b encrypted \b0 so no one (not even TrulyMail employees) can read your messages while they are traveling to your intended recipient.\par" & Environment.NewLine & _
                                "\par" & Environment.NewLine & _
                                "You need a \b TrulyMail account \b0 to use any service (including the free services) on TrulyMail servers (including checking for updated TrulyMail applications, requesting keys to open encrypted emails, and auto-completing settings when setting up an email account). Setting up a TrulyMail account is easy and free and you can close it at any time.\par" & Environment.NewLine & _
                                "\par" & Environment.NewLine & _
                                "We hope you enjoy TrulyMail as much as we do!\par" & Environment.NewLine & _
                                "\par" & Environment.NewLine & _
                                "}"
        Me.Text = "Why do I need a TrulyMail Account"
    End Sub
End Class