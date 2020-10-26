Public Class InsertTableForm

    Private WithEvents m_TrackRectangle As TrackRectanglePictureBox

   
    Public Property Columns As Integer
        Get
            Return ConvertToInt32(nudColumns.Value.ToString(), 2)
        End Get
        Set(value As Integer)
            nudColumns.Value = value
        End Set
    End Property
    Public Property Rows As Integer
        Get
            Return ConvertToInt32(nudRows.Value.ToString(), 2)
        End Get
        Set(value As Integer)
            nudColumns.Value = value
        End Set
    End Property
    Public Property Border As Integer
        Get
            Return ConvertToInt32(nudBorder.Value.ToString(), 1)
        End Get
        Set(value As Integer)
            nudBorder.Value = value
        End Set
    End Property
    Public Property FullWidth As Boolean
        Get
            Return chkFullWidth.Checked
        End Get
        Set(value As Boolean)
            chkFullWidth.Checked = value
        End Set
    End Property
    Public Property TableBGColor As Color
        Get
            Return PictureBox2.BackColor
        End Get
        Set(value As Color)
            PictureBox2.BackColor = value
        End Set
    End Property
    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click


        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub PictureBox1_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
    End Sub

    Private Sub m_TrackRectangle_TrackCompleted(ByVal sender As Object, ByVal rect As System.Drawing.Rectangle) Handles m_TrackRectangle.TrackCompleted
        Dim pt1 As Point = ScreenToImage(Me.PictureBox1, rect.Location) '-- Upper left point
        Dim pt2 As New Point(rect.X + rect.Width, rect.Y + rect.Height) '-- Lower right point
        pt2 = ScreenToImage(Me.PictureBox1, pt2)

        Me.PictureBox1.Invalidate()
    End Sub

    Private Function ScreenToImage(ByVal pb As PictureBox, ByVal ScreenPoint As Point) As Point
        '-- Convert from where it was clicked to where the point would be if the
        '   top-left corner of image was 0,0 and zoom factor was 1
        If pb.Image IsNot Nothing Then
            Dim intPhysicalHeight As Integer = pb.Image.Height
            Dim intPhysicalWidth As Integer = pb.Image.Width

            Dim intCurrentHeight As Integer = pb.Height
            Dim intCurrentWidth As Integer = pb.Width

            Dim dblZoomFactorHeight As Double = intCurrentHeight / intPhysicalHeight
            Dim dblZoomFactorWidth As Double = intCurrentWidth / intPhysicalWidth
            Dim dblZoomFactor As Double = Math.Min(dblZoomFactorWidth, dblZoomFactorHeight)

            Dim x, y As Integer
            x = ScreenPoint.X
            y = ScreenPoint.Y

            If dblZoomFactorWidth > dblZoomFactor Then
                Dim intAdjustedImageWidth As Integer = Convert.ToInt32(intPhysicalWidth * dblZoomFactor)
                x -= Convert.ToInt32((intCurrentWidth - intAdjustedImageWidth) / 2)
            ElseIf dblZoomFactorHeight > dblZoomFactor Then
                Dim intAdjustedImageHeight As Integer = Convert.ToInt32(intPhysicalHeight * dblZoomFactor)
                y -= Convert.ToInt32((intCurrentHeight - intAdjustedImageHeight) / 2)
            End If

            Dim pt As New Point(Convert.ToInt32(x / dblZoomFactor), Convert.ToInt32(y / dblZoomFactor))

            Return pt
        Else
            Return Nothing
        End If
    End Function

    Private Sub InsertTableForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Me.PictureBox1.Cursor = Cursors.Cross
        m_TrackRectangle = New TrackRectanglePictureBox(Me.PictureBox1)

    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If m_TrackRectangle IsNot Nothing AndAlso m_TrackRectangle.Tracking Then
            Dim intRows As Integer = e.Location.Y / 24
            If intRows < 1 Then
                intRows = 1
            End If
            nudRows.Value = intRows

            Dim intColumns As Integer = e.Location.X / 24
            If intColumns < 1 Then
                intColumns = 1
            End If
            nudColumns.Value = intColumns

        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        Try
            If m_TrackRectangle IsNot Nothing AndAlso m_TrackRectangle.Tracking Then
                m_TrackRectangle.CancelTracking()
                'm_TrackRectangle.Dispose()
                'm_TrackRectangle = Nothing
            End If
        Catch ex As Exception
            Log(ex) '-- log and ignore
        End Try
    End Sub

    Private Sub btnBGColor_SelectedColorChanged(sender As System.Object, e As ComponentFactory.Krypton.Toolkit.ColorEventArgs) Handles btnBGColor.SelectedColorChanged
        Me.PictureBox2.BackColor = btnBGColor.SelectedColor
    End Sub
End Class
