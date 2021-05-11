Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Threading
Imports System.Security.Cryptography
Imports XnaFan.ImageComparison
Imports Constants
Imports System.Text
Imports Microsoft

Public Class Form1
    Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Integer, ByVal uParam As Integer, ByRef lpvParam As Integer, ByVal fuWinIni As Integer) As Integer
    Private Declare Sub keybd_event Lib "user32.dll" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResponsiveSleep(5000)


again:
        KeyDownUp(Keys.E, False, 250, False)

        'point at cloth buy
        SetCursorPos(3403, 1237)
        ResponsiveSleep(500)
        SetCursorPos(3403, 1237)
        ResponsiveSleep(500)


        'cick cloth
        For i = 0 To 16
            LeftMouseClick()
            ResponsiveSleep(300)
        Next i

        KeyDownUp(Keys.Escape, False, 250, False)
        ResponsiveSleep(7000)


        GoTo again


    End Sub
    Public Sub KeyDownUp(ByVal key As Byte, shift As Boolean, ByVal durationInMilli As Integer, jumping As Boolean)
        Dim targetTime As DateTime = DateTime.Now().AddMilliseconds(durationInMilli)
        Dim kb_delay As Integer
        Dim kb_speed As Integer

        SystemParametersInfo(Constants.SPI_GETKEYBOARDDELAY, 0, kb_delay, 0)
        SystemParametersInfo(Constants.SPI_GETKEYBOARDSPEED, 0, kb_speed, 0)

        keybd_event(key, MapVirtualKey(key, 0), 0, 0) ' key pressed      

        While targetTime.Subtract(DateTime.Now()).TotalMilliseconds > 0
            System.Threading.Thread.Sleep(kb_delay + kb_speed)
        End While

        keybd_event(key, MapVirtualKey(key, 0), 2, 0) ' key released              
    End Sub


    Public Sub LeftMouseClick()
        mouse_event(Constants.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
        ResponsiveSleep(250)
        mouse_event(Constants.MOUSEEVENTF_LEFTUP, 6, 0, 0, 0)
        ResponsiveSleep(250)
    End Sub
    Public Sub ResponsiveSleep(ByRef iMilliSeconds As Integer)
        Dim i As Integer, iHalfSeconds As Integer = iMilliSeconds / 50
        For i = 1 To iHalfSeconds
            Application.DoEvents()
            Threading.Thread.Sleep(50)
            Application.DoEvents()
        Next i
    End Sub
End Class
