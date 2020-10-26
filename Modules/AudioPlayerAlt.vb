'Module AudioPlayerAlt
'    Public Declare Function mciSendString Lib "winmm.dll" _
'Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, _
'ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer

'    Public Sub audioOpen(ByVal audioAlias As String, ByVal audioPath As String)
'        'open the sound prepare for use  
'        mciSendString("Open " & Chr(34) & audioPath & Chr(34) & " alias " & audioAlias, CStr(0), 0, 0)
'    End Sub
'    Public Sub audioPlay(ByVal audioAlias As String)
'        'Play the sound  

'        mciSendString("play " & audioAlias & " FROM 0", CStr(0), 0, 0)
'    End Sub
'    Public Sub audioPauze(ByVal audioAlias As String)
'        'Pauses the sound  
'        mciSendString("pause " & audioAlias, CStr(0), 0, 0)
'    End Sub
'    Public Sub audioResume(ByVal audioAlias As String)
'        'Resumes the paused sound  
'        mciSendString("resume " & audioAlias, CStr(0), 0, 0)
'    End Sub
'    Public Sub audioStop(ByVal audioAlias As String)
'        'Stop the playing sound  
'        mciSendString("stop " & audioAlias, CStr(0), 0, 0)
'    End Sub
'    Public Sub audioClose(ByVal audioAlias As String)
'        'Close the sound, this is the opposite to Open and will make so  
'        'you can't use the sound any more'unless you open it again of course.  
'        mciSendString("close " & audioAlias, CStr(0), 0, 0)
'    End Sub
'    Public Sub test()
'        ' MCI_STATUS_PARMS status;  
'        'status.dwItem = MCI_STATUS_POSITION;  
'        'status.dwCallback = 0;  

'        'dwReturn = mciSendCommand(m_iDeviceIDPlayer,MCI_STATUS,MCI_STATUS_ITEM|MCI_WAIT,(DWORD_PTR)&status);  
'        'Position -> status.dwReturn is the required position.  
'    End Sub
'End Module
''[code]  

''In je Load method van de hoofd form :  
''[code]  
''openaudio("bullet","bulletsound.wma")  
''[/code]  
''In je gamplay na het afvuren :  
''[code]  
''audioplay("bullet")  
''[/code]  

' ''Indien het geluid voortijdig moet stoppen :  
''[code]  
''audiostop("bullet")  
