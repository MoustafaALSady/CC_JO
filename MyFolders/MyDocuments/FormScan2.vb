'Option Explicit Off
Imports System.ComponentModel
Imports System.IO
Imports ALquhaliLibrary
Imports EZTwainLibrary
Imports WIA

Public Class FormScan2
    ReadOnly OFD As New OpenFileDialog
    ReadOnly F As New FormDOCUMENTS
    Private FileType As String
    Public MyPath As String
    Dim Drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer
    Public Delegate Sub Del(ByVal image As Image)
    Private ReadOnly _del As Del

    Public Sub New(ByVal del As Del)
        InitializeComponent()
        Me._del = del
    End Sub
    Public Sub FillcombByScanners()
        Me.ComboScanners.Items.Clear()
        Dim DeviceManagera = New DeviceManager
        For i As Integer = 1 To DeviceManagera.Deviceinfos.count
            If DeviceManagera.Deviceinfos(i).type <> WiaDeviceType.ScannerDeviceType Then Continue For
            Me.ComboScanners.Items.Add(New Scanner(DeviceManagera.Deviceinfos(i)))
        Next
        If Me.ComboScanners.Items.Count > 0 Then Me.ComboScanners.SelectedIndex = 0
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        EZTwain.SelectTwainsource(0)
    End Sub
    Private Sub ButScan_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButScan.Click
        'If My.Computer.FileSystem.FileExists(Application.StartupPath & "MyImage.Bmp") = True Then
        '    My.Computer.FileSystem.DeleteFile(Application.StartupPath & "MyImage.Bmp")
        'End If
        'EZTwain.AcquireToFileName(Me.Handle, Application.StartupPath & "MyImage.Bmp")
        'PictureBox1.ImageLocation = Application.StartupPath + "MyImage.Bmp"
        'OFD.FileName = Application.StartupPath + "MyImage.Bmp"
        Try
            If Me.ComboScanners.Items Is Nothing Then FillcombByScanners()
            Me.BackgroundWorker1.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ButSave_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButSave.Click
        If OFD.FileName = "" Then
            MsgBox("لم يتم تحديد صورة")
            'Button1.Select()
            Exit Sub
        End If
        F.Activate()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand(" Update DOCUMENTS SET  DOC6 = @DOC6 WHERE DOC1 = '" & Me.TextBox1.Text & "'", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            Dim p() As Byte = My.Computer.FileSystem.ReadAllBytes(OFD.FileName)
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@DOC6", SqlDbType.Image).Value = p
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
            OFD.FileName = ""
            MsgBox("تم الإضافة بنجاح", MsgBoxStyle.Information, "نجاح")
            PictureBox1.Image = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub FormScan2_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        FillcombByScanners()
    End Sub
    Private Sub STarScannering(ByVal ComboScanners As ComboBox, savedImageFoldar As String, ImageName As String, ImageExe As Short, PIC As PictureBox)
        If ComboScanners Is Nothing Then
            Throw New ArgumentNullException(NameOf(ComboScanners))
        End If

        Try
            Dim Devic As Scanner = Nothing
            Invoke(New MethodInvoker(Function()
                                         Devic = CType(Me.ComboScanners.SelectedItem, Scanner)
                                         Return Devic
                                     End Function))
            If Devic Is Nothing Then
                MessageBox.Show("من فضلك تاكد من وجد ماسح ضوئي متصل بجهاز", "رسالة تنبية")
                Return
            ElseIf String.IsNullOrEmpty(ImageName) Then
                MessageBox.Show("من فضلك إدخل اسم للصورة المراد مسحها من خلال إعدادات المسح الضوئي", "رسالة تنبية")
                Return
            End If
            FileType = ModuleGeneral.ImageExe
            Dim scanImageName As String = ImageName & Now.ToString("yyyy-MM-dd-hhmmssff")
            PIC.Image = Nothing
            Dim ImgExtension As String = ""
            Dim Image As New ImageFile()
            Invoke(New MethodInvoker(Function()
                                         Select Case ImageExe
                                             Case 0
                                                 Image = Devic.ScanPNG
                                                 ImgExtension = ".PNG"
                                             Case 1
                                                 Image = Devic.ScanJPEG
                                                 ImgExtension = ".JPEG"
                                             Case 2
                                                 Image = Devic.ScanTIFF
                                                 ImgExtension = ".TIFF"
                                         End Select
                                         Return ImgExtension
                                     End Function))
            MyPath = Path.Combine(savedImageFoldar, scanImageName & ImgExtension)
            Image.SaveFile(MyPath)
            PIC.Image = New Bitmap(MyPath)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Threading.Thread.Sleep(100)
        MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        If Not IO.Directory.Exists(MYFOLDER & "\FailImag") Then Directory.CreateDirectory(MYFOLDER & "\FolderImageName")
        Dim FolderImageName As String = MYFOLDER & "\FolderImageName"
        STarScannering(Me.ComboScanners, FolderImageName, ImageName, FileType, Me.PictureBox1)
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        _del(PictureBox1.Image)
        Me.Close()
    End Sub


    Private Sub Butrotolaeft_Click(sender As Object, e As EventArgs) Handles Butrotolaeft.Click
        Rotatlaft(Me.PictureBox1)
    End Sub

    Private Sub Butrotorait_Click(sender As Object, e As EventArgs) Handles Butrotorait.Click
        Rotatraeit(Me.PictureBox1)
    End Sub


    Private Sub Panel_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _
         Panel5.MouseDown, Panel6.MouseDown, Panel7.MouseDown, Panel8.MouseDown, Panel9.MouseDown,
        Panel10.MouseDown, PictureBox1.MouseDown, PictureBox2.MouseDown

        Drag = True
        MouseX = Cursor.Position.X - Me.Left
        MouseY = Cursor.Position.Y - Me.Top
    End Sub
    Private Sub Panel_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _
         Panel5.MouseMove, Panel6.MouseMove, Panel7.MouseMove, Panel8.MouseMove, Panel9.MouseMove,
        Panel10.MouseMove, PictureBox1.MouseMove, PictureBox2.MouseMove
        If Drag = True Then
            Me.Left = Cursor.Position.X - MouseX
            Me.Top = Cursor.Position.Y - MouseY
        End If
    End Sub
    Private Sub Panel_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _
         Panel5.MouseUp, Panel6.MouseUp, Panel7.MouseUp, Panel8.MouseUp, Panel9.MouseUp,
         Panel10.MouseUp, PictureBox1.MouseUp, PictureBox2.MouseUp
        Drag = False
    End Sub
    Private Sub FormScan2_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        Drag = True
        MouseX = Cursor.Position.X - Me.Left
        MouseY = Cursor.Position.Y - Me.Top
    End Sub
    Private Sub FormScan2_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        If Drag = True Then
            Me.Left = Cursor.Position.X - MouseX
            Me.Top = Cursor.Position.Y - MouseY
        End If
    End Sub
    Private Sub FormScan2_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        Drag = False
    End Sub

    Private Sub ButClose_Click(sender As Object, e As EventArgs) Handles ButClose.Click
        Me.Close()
    End Sub


End Class
