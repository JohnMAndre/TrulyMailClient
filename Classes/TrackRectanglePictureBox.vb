Imports System.Windows.Forms

Public Class TrackRectanglePictureBox
    Public Event TrackStart() ' these events are somewhat useless, since the main form really should not care what we do..
    Public Event TrackFinished()
    Public Event TrackCanceled()
    Public Event TrackCompleted(ByVal sender As Object, ByVal rect As Rectangle)
    Public Point1, Point2 As Point

    Private m_Tracking As Boolean
    Private WithEvents m_viewer As PictureBox ' grab the events and handle here, instead of cluttering the main form
    Private g As Graphics
    Private Pen As New Pen(Color.Blue)
    Private Brush As New SolidBrush(Color.FromArgb(64, Color.Blue))
    Private r As Rectangle

    Public Sub New(ByVal viewer As PictureBox)
        m_viewer = viewer
    End Sub

    Public ReadOnly Property Tracking() As Boolean
        Get
            Return m_Tracking
        End Get
    End Property

    Public Sub BeginTracking(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_viewer = DirectCast(sender, PictureBox)
        If g IsNot Nothing Then
            Dim hd As IntPtr = g.GetHdc
            g.ReleaseHdc(hd)
            g.Dispose()
            g = Nothing
        End If

        g = m_viewer.CreateGraphics
        Point1 = New Point(0, 0) 'e.Location
        Point2 = New Point

        m_Tracking = True
        RaiseEvent TrackStart()
    End Sub

    Public Sub Draw(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Not m_Tracking Then
            Exit Sub
        End If

        m_viewer.Refresh()
        Point2.X = Math.Min(e.Location.X, m_viewer.Width)
        Point2.Y = Math.Min(e.Location.Y, m_viewer.Height)

        r = New Rectangle(Math.Min(Point1.X, Point2.X), Math.Min(Point1.Y, Point2.Y), Math.Abs(Point2.X - Point1.X), Math.Abs(Point2.Y - Point1.Y))
        g.DrawRectangle(Pen, r)
        g.FillRectangle(Brush, r)
    End Sub

    Public Sub CancelTracking()
        m_Tracking = False
        Point1 = New Point
        Point2 = New Point
        r.Width = 0
        r.Height = 0
        If m_viewer IsNot Nothing Then
            m_viewer.Invalidate()
        End If

        RaiseEvent TrackCanceled()
    End Sub

    Public Sub FinishTracking(ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim OutOfBounds As Boolean = False
        Dim InvalidRectangle As Boolean = False

        If Not m_Tracking Then
            Exit Sub
        End If

        If e.X < 0 Then OutOfBounds = True
        If e.Y < 0 Then OutOfBounds = True
        If e.X > m_viewer.DisplayRectangle.Width Then OutOfBounds = True
        If e.Y > m_viewer.DisplayRectangle.Height Then OutOfBounds = True

        If r.Width <= 20 Then InvalidRectangle = True
        If r.Height <= 20 Then InvalidRectangle = True

        If OutOfBounds OrElse InvalidRectangle Then
            CancelTracking()
            Exit Sub
        End If

        If Not g Is Nothing Then g.Dispose()
        g = Nothing

        Point2 = e.Location
        m_Tracking = False
        RaiseEvent TrackFinished()

        RaiseEvent TrackCompleted(Me, r)

        CancelTracking()

    End Sub

    Private Sub m_viewer_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles m_viewer.KeyUp
        If e.KeyCode = Keys.Escape Then
            CancelTracking()
        End If
    End Sub

    Private Sub m_viewer_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m_viewer.MouseDown
        If e.Button = MouseButtons.Left Then
            BeginTracking(sender, e)
        End If
    End Sub

    Private Sub m_viewer_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m_viewer.MouseMove
        Draw(e)
    End Sub

    Private Sub m_viewer_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m_viewer.MouseUp
        'Console.WriteLine("RasterImageViewer1_MouseUp " & Date.Now.ToString(DATE_DISPLAY_FORMAT_HD))
        If e.Button = MouseButtons.Left Then
            FinishTracking(e)
        Else
            CancelTracking()
        End If
    End Sub
    Public Sub Dispose()
        m_viewer = Nothing
    End Sub

End Class
