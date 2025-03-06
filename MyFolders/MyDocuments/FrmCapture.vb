Public Class FrmCapture
    ReadOnly sc As frmcaptureclass
<<<<<<< HEAD
    Private Sub Buttoncapture_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles buttoncapture.Click
=======
    Private Sub Buttoncapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttoncapture.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Clipboard.Clear()
        PictureBox1.Image = Nothing
        ' sc = New frmcaptureclass(Me)
        sc.GetScreenShot()
    End Sub
<<<<<<< HEAD
    Private Sub Buttonsave_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles buttonsave.Click
=======
    Private Sub Buttonsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonsave.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If PictureBox1.Image Is Nothing Then
            Exit Sub
        End If

        Dim SaveFileDialog1 As New SaveFileDialog With {
            .Filter = "Bitmap file (*.bmp)|*.bmp|TIFF file (*.tif)|*.tif|JPEG file (*.jpg)|*.jpg|PNG file (*.png)|*.png|GIF file (*.gif)|*.gif|All files (*.*)|*.*"
        }
        With SaveFileDialog1
            .FilterIndex = 3
            .Title = "حفظ ملف"
            MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            .InitialDirectory = MYFOLDER & "\Photos"
            .ShowDialog()
            If PictureBox1.Image IsNot Nothing Then
                If Len(.FileName) > 0 Then
                    If .FilterIndex = 3 Then
                        PictureBox1.Image.Save(.FileName & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                    ElseIf .FilterIndex = 1 Then
                        PictureBox1.Image.Save(.FileName & ".bmp", System.Drawing.Imaging.ImageFormat.Bmp)
                    ElseIf .FilterIndex = 2 Then
                        PictureBox1.Image.Save(.FileName & ".Tiff", System.Drawing.Imaging.ImageFormat.Tiff)
                    ElseIf .FilterIndex = 4 Then
                        PictureBox1.Image.Save(.FileName & ".Png", System.Drawing.Imaging.ImageFormat.Png)
                    ElseIf .FilterIndex = 5 Then
                        PictureBox1.Image.Save(.FileName & ".Gif", System.Drawing.Imaging.ImageFormat.Gif)
                    End If
                End If
            Else
                MessageBox.Show("لاتوجد صورة حالية للحفظ", "معلومة")
            End If
        End With
        PictureBox1.Image = Nothing
    End Sub
<<<<<<< HEAD
    Private Sub FrmCapture_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
=======
    Private Sub FrmCapture_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap) Then
            PictureBox1.Image = CType(Clipboard.GetData(DataFormats.Bitmap), Bitmap)
            PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub
<<<<<<< HEAD
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP1.Click
=======
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim OpenFileDialog1 As New OpenFileDialog With {
            .Filter = "Bitmap file (*.bmp)|*.bmp|TIFF file (*.tif)|*.tif|JPEG file (*.jpg)|*.jpg|PNG file (*.png)|*.png|GIF file (*.gif)|*.gif|All files (*.*)|*.*"
        }
        With OpenFileDialog1
            .FilterIndex = 5
            .Title = "اختيار صورة"
            .InitialDirectory = "D:\CO_MAS\MyDATA\Photos"
            .ShowDialog()
            If Len(.FileName) > 0 Then
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        End With
    End Sub
<<<<<<< HEAD
    Private Sub FrmCapture_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub FrmCapture_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Buttoncapture_Click(sender, e)
                Case Keys.F2
                    Buttonsave_Click(sender, e)
                Case Keys.F3
                    ButtonXP1_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub ButtonPrintScreen_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonPrintScreen.Click
=======
    Private Sub ButtonPrintScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrintScreen.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.WindowState = FormWindowState.Minimized
            Clipboard.Clear()
            Me.PictureBox1.Image = Nothing
            Threading.Thread.Sleep(2000)
            SendKeys.SendWait("{PRTSC}")
            Me.WindowState = FormWindowState.Normal
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
=======
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Clipboard.ContainsImage() Then
            PictureBox1.Image = Clipboard.GetImage()
        End If
    End Sub

<<<<<<< HEAD
    Private Sub FrmCapture_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmCapture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub
End Class