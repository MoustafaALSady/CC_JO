Imports System.Runtime.InteropServices
Public Class FrmCamera
    Const WM_CAP As Short = &H400S
    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Const WM_CAP_SET_PInternalAuditor As Integer = WM_CAP + 50
    Const WM_CAP_SET_PInternalAuditorRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1
    Private ReadOnly iDevice As Integer = 0 ' «·ﬂ«„Ì—« «·Õ«·Ì…
    Private ReadOnly hHwnd As Integer ' ·„⁄«Ì‰… «·’Ê—…

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer,
        <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (hwnd As Integer,
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer,
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Declare Function DestroyWindow Lib "user32" (hndw As Integer) As Boolean

    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
        (ByVal lpszWindowName As String, ByVal dwStyle As Integer,
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer,
        ByVal nHeight As Short, ByVal hWndParent As Integer,
        ByVal nID As Integer) As Integer

    Declare Function CapGetDriverDescriptionA Lib "avicap32.dll" (wDriver As Short,
        ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String,
        ByVal cbVer As Integer) As Boolean



    'Private Sub LoadDeviceList()
    '    Dim strName As String = Space(1000)
    '    Dim strVer As String = Space(1000)
    '    Dim bReturn As Boolean
    '    Dim x As Integer = 0
    '    '  Õ„Ì· ﬂ· «·ﬂ«„Ì—« 
    '    Do
    '        '   «·«”„ + «·„ÊœÌ·
    '        bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
    '        ' «÷«›… «·ﬂ«„»—«  ··ﬂ„»Ê »Êﬂ”
    '        If bReturn Then ComboBox1.Items.Add(strName.Trim)
    '        x += 1
    '    Loop Until bReturn = False
    'End Sub
    Private Sub OpenPInternalAuditorWindow()
        'Dim iHeight As Integer = PictureBox1.Height
        'Dim iWidth As Integer = PictureBox1.Width
        '' ⁄—÷ «·’Ê—… ›Ï «·»ﬂ ‘—
        'hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640,
        '    480, PictureBox1.Handle.ToInt32, 0)
        ' «·« ’«· »«·ﬂ«„Ì—«
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
            '⁄„· ”ﬂÌ· ··’Ê—…
            Dim unused = SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)
            '«⁄œ«œ «·‰«›–…
            Dim unused1 = SendMessage(hHwnd, WM_CAP_SET_PInternalAuditorRATE, 66, 0)
            '«»œ√  Õ„Ì· «·’Ê—… „‰ «·ﬂ„Ì—«
            Dim unused2 = SendMessage(hHwnd, WM_CAP_SET_PInternalAuditor, True, 0)
            ' ⁄„· —Ì“«Ì“ ··’Ê—…
            'Dim unused3 = SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, PictureBox1.Width, PictureBox1.Height,
            '        SWP_NOMOVE Or SWP_NOZORDER)
            'SAVEBUTTON.Enabled = True
            'STOPBUTTON.Enabled = True
            'STARTBUTTON.Enabled = False
        Else
            ' ›Ï Õ«·… ÊÃÊœ «Œÿ«¡
            DestroyWindow(hHwnd)
            'SAVEBUTTON.Enabled = False
        End If
    End Sub



    Private Sub FrmCamera_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    STARTBUTTON_Click(sender, e)
                Case Keys.F2
                    STOPBUTTON_Click(sender, e)
                Case Keys.F3
                    SAVEBUTTON_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmVideoCapture_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        'LoadDeviceList()
        'If ComboBox1.Items.Count > 0 Then
        '    STARTBUTTON.Enabled = True
        '    ComboBox1.SelectedIndex = 0
        '    STARTBUTTON.Enabled = True
        'Else
        '    ComboBox1.Items.Add("NO CAMERA")
        '    STARTBUTTON.Enabled = False
        'End If
        'STOPBUTTON.Enabled = False
        'SAVEBUTTON.Enabled = False
        'PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub
    Private Sub STARTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        'iDevice = ComboBox1.SelectedIndex
        OpenPInternalAuditorWindow()
    End Sub
    Private Sub ClosePInternalAuditorWindow()
        ' Êﬁ› ⁄„· «·ﬂ«„Ì—«
        Dim unused = SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)
        ' «€·«ﬁ «·‰«›–…
        DestroyWindow(hHwnd)
    End Sub
    Private Sub STOPBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        ClosePInternalAuditorWindow()
        'SAVEBUTTON.Enabled = False
        'STARTBUTTON.Enabled = True
        'STOPBUTTON.Enabled = False
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim data As IDataObject
        Dim bmap As Image
        ' ‰”Œ «·’Ê—… ··ﬂ·Ì»»Ê—œ
        Dim unused = SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
        ' ﬁ—«¡… «·’Ê—… „‰ «·ﬂ·Ì»»Ê—œ Ê ÕÊÌ·Â« «·Ï «„ÌœÃ
        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(Bitmap)) Then
            bmap = CType(data.GetData(GetType(Bitmap)), Image)
            'PictureBox1.Image = bmap
            ClosePInternalAuditorWindow()
            'SAVEBUTTON.Enabled = False
            'STOPBUTTON.Enabled = False
            'STARTBUTTON.Enabled = True
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                bmap.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Bmp)
            End If
        End If
    End Sub
    Private Sub FrmVideoCapture_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'If STOPBUTTON.Enabled Then
        '    ClosePInternalAuditorWindow()
        'End If
    End Sub


End Class