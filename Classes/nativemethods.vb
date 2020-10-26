Imports System.Runtime.InteropServices

Friend Class NativeMethods
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Friend Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function
    Friend Const BCM_FIRST As Integer = &H1600
    Friend Const BCM_SETSHIELD As Integer = (BCM_FIRST + &HC)

End Class
