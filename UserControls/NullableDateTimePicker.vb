Imports System
Imports System.Windows.Forms
Public Class NullableDateTimePicker
    Inherits System.Windows.Forms.DateTimePicker

    Private m_boolValueNull As Boolean

    Public Sub New()
        MyBase.New()
    End Sub

    Public Shadows Property Value() As Nullable(Of Date)
        Get
            If m_boolValueNull Then
                Return Nothing
            Else
                Return MyBase.Value
            End If
        End Get
        Set(ByVal value As Nullable(Of Date))
            If value.HasValue Then
                MyBase.Value = value.Value
                m_boolValueNull = False
                MyBase.Format = DateTimePickerFormat.Short
            Else
                m_boolValueNull = True
                MyBase.CustomFormat = ""
            End If
        End Set
    End Property
    Protected Overrides Sub OnCloseUp(ByVal eventargs As EventArgs)
        If Control.MouseButtons = MouseButtons.None Or Control.MouseButtons = Windows.Forms.MouseButtons.Left Then
            Me.Value = MyBase.Value
        End If
        MyBase.OnCloseUp(eventargs)
    End Sub
    Protected Overloads Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        MyBase.OnKeyDown(e)

        If e.KeyCode = Keys.Delete Then
            Me.Value = Nothing
            m_boolValueNull = True
            MyBase.Value = Date.Today
            Me.Invalidate()
        End If
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        'MyBase.OnPaint(e)
        If m_boolValueNull Then
            e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle)
        Else
            MyBase.OnPaint(e)
        End If
    End Sub
End Class
