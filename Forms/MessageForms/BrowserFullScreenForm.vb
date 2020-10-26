Public Class BrowserFullScreenForm

    Private m_boolLoaded As Boolean
    Private m_controlToFocus As Control
    Private m_boolPreventClosing As Boolean

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        PrepareTipPanels()

        Me.WindowState = FormWindowState.Maximized
        Application.DoEvents()

    End Sub

    Public Sub LoadHTML(browser As Windows.Forms.WebBrowser, messageFilename As String)
        LastFilename = messageFilename

        browser.Parent = Panel1
        browser.BringToFront()
        browser.Dock = DockStyle.Fill

        RemoveHandler browser.PreviewKeyDown, AddressOf WebBrowser1_PreviewKeyDown
        Application.DoEvents()
        AddHandler browser.PreviewKeyDown, AddressOf WebBrowser1_PreviewKeyDown

        RemoveHandler browser.Navigating, AddressOf WebBrowser1_Navigating
        Application.DoEvents()
        AddHandler browser.Navigating, AddressOf WebBrowser1_Navigating

        m_controlToFocus = browser
        LastReaderControl = browser

    End Sub
    Public Sub LoadRTB(rtb As Windows.Forms.RichTextBox, messageFilename As String)
        LastFilename = messageFilename
        rtb.Parent = Panel1
        RemoveHandler rtb.LinkClicked, AddressOf rtb_LinkClicked
        AddHandler rtb.LinkClicked, AddressOf rtb_LinkClicked

        RemoveHandler rtb.PreviewKeyDown, AddressOf rtb_PreviewKeyDown
        AddHandler rtb.PreviewKeyDown, AddressOf rtb_PreviewKeyDown

        RemoveHandler rtb.TextChanged, AddressOf rtb_TextChanged
        AddHandler rtb.TextChanged, AddressOf rtb_TextChanged

        m_controlToFocus = rtb
        LastReaderControl = rtb
    End Sub

    Public Property LastFilename As String
    Public Property LastReaderControl As Control


    Private Sub PrepareTipPanels()
        If AppSettings.DoNotShowBrowserFullScreenTipPanel Then
            pnlTip.Hide()
        End If
        If AppSettings.DoNotShowBrowserFullScreenCtrlDeletePanel Then
            pnlCtrlDelete.Hide()
        End If
        If AppSettings.DoNotShowBrowserFullScreenShiftCtrlDeleteTipPanel Then
            pnlShiftCtrlDelete.Hide()
        End If
    End Sub

    Private Sub rtb_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
        ProcessKeyDown(e)
    End Sub
    Private Sub rtb_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs)
        Try
            System.Diagnostics.Process.Start(e.LinkText)
        Catch ex As Exception
            Log(ex)
        End Try
    End Sub
    Private Sub WebBrowser1_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
        Try
            ProcessKeyDown(e)
        Catch ex As Exception
            Log(ex) '-- log and continue
        End Try
    End Sub
    Private Sub CloseThisForm()
        'If Me.Visible Then
        Close()
        'End If
    End Sub
    Private Sub ProcessKeyDown(ByVal e As PreviewKeyDownEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Escape
                    CloseThisForm()
                Case Keys.F11
                    CloseThisForm()
                Case Keys.D
                    If ModifierKeys = (Keys.Control Or Keys.Shift) Then
                        '-- Shift-Delete is a premium feature
                            m_boolPreventClosing = True
                            LastFilename = String.Empty
                    Else
                        m_boolPreventClosing = False
                        CloseThisForm()
                    End If
            End Select
        Catch ex As Exception
            Log(ex) '-- log and ignore
        End Try
    End Sub

    Private Sub BrowserFullScreenForm_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        If m_boolLoaded Then
            If Not m_boolPreventClosing Then
                CloseThisForm()
            End If
        End If
    End Sub

    Private Sub BrowserFullScreenForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        m_boolLoaded = True
        Me.Panel1.Controls(0).Dock = DockStyle.None
        Application.DoEvents()
        Me.Panel1.Controls(0).Dock = DockStyle.Fill
    End Sub
    Private Sub WebBrowser1_Navigating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs)
        If m_boolPreventClosing Then
            m_boolPreventClosing = False
            Console.WriteLine("False 1")
        Else
            CloseThisForm()
        End If
    End Sub
    Private Sub rtb_TextChanged(sender As Object, e As System.EventArgs)
        If m_boolPreventClosing Then
            m_boolPreventClosing = False
            Console.WriteLine("False 3")
        Else
            CloseThisForm()
        End If
    End Sub

    Private Sub picCloseTipPanel_Click(sender As System.Object, e As System.EventArgs) Handles picCloseTipPanel.Click
        If chkDoNotShowTipPanel.Checked Then
            AppSettings.DoNotShowBrowserFullScreenTipPanel = True
        End If
        pnlTip.Hide()
        Me.Panel1.Controls(0).Focus()
    End Sub

    Private Sub BrowserFullScreenForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If m_controlToFocus IsNot Nothing Then
            m_controlToFocus.Focus()
        End If
    End Sub

    Private Sub picCloseCtrlDeletePanel_Click(sender As System.Object, e As System.EventArgs) Handles picCloseCtrlDeletePanel.Click
        If chkDoNotShowCtrlDeletePanel.Checked Then
            AppSettings.DoNotShowBrowserFullScreenCtrlDeletePanel = True
        End If
        pnlCtrlDelete.Hide()
        Me.Panel1.Controls(0).Focus()
    End Sub

    Private Sub picCloseShiftCtrlDeletePanel_Click(sender As System.Object, e As System.EventArgs) Handles picCloseShiftCtrlDeletePanel.Click
        If chkDoNotShowShiftCtrlDeletePanel.Checked Then
            AppSettings.DoNotShowBrowserFullScreenShiftCtrlDeleteTipPanel = True
        End If
        pnlShiftCtrlDelete.Hide()
        Me.Panel1.Controls(0).Focus()
    End Sub

   
End Class