Imports System.ComponentModel
Imports System.Diagnostics
Imports System.IO
Imports ALquhaliLibrary
Imports Microsoft.Win32
Imports TwainLib
Imports WIA

Public Class FormScan
    ReadOnly cls As New Process
    ReadOnly mypic As Image
    Private ReadOnly FileStream As FileStream
    Private ReadOnly Reader As BinaryReader
    Private ReadOnly FileData As Byte()
    Private ReadOnly FileType As String
    Private ReadOnly FileName As String
    Private ReadOnly FileSize As Double
    Private ReadOnly FileInfo As String
    Private ReadOnly Pathf As String
    Private MyPath As String
    Private m_PanStartPoint As New Point

    Public Sub FillcombByScanners()
        Me.ComboScanners.Items.Clear()
        Dim DeviceManagera = New DeviceManager
        For i As Integer = 1 To DeviceManagera.Deviceinfos.count
            If DeviceManagera.Deviceinfos(i).type <> WiaDeviceType.ScannerDeviceType Then Continue For
            Me.ComboScanners.Items.Add(New Scanner(DeviceManagera.Deviceinfos(i)))
        Next
        If Me.ComboScanners.Items.Count > 0 Then Me.ComboScanners.SelectedIndex = 0
    End Sub

    Private Sub STarScannering(ByVal ComboScanners As ComboBox, savedImageFoldar As String, ImgeName As String, ImageExe As Short, PIC As PictureBox)
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
            ElseIf String.IsNullOrEmpty(ImgeName) Then
                MessageBox.Show("من فضلك إدخل اسم للصورة المراد مسحها من خلال إعدادات المسح الضوئي", "رسالة تنبية")
                Return
            End If
            Dim scanImageName As String = ImgeName & Now.ToString("yyyy-MM-dd-hhmmssff")
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

    Private Sub TryScanner()
        If Me.ComboScanners.SelectedItem Is Nothing Or Me.PictureBox1.Image Is Nothing Then Return
        Me.CheckedListBox1.Items.Add(MyPath)
        Me.Lblcaut.Text = Me.CheckedListBox1.Items.Count
        Me.LablImagespath.Text = MyPath
        If MessageBox.Show("هل تود عمل مسح جديد", "رسالة تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.ButScan.PerformClick()
        End If
    End Sub

    Private Sub FormScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Classcontrol()
        FillcombByScanners()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Threading.Thread.Sleep(100)
        MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        If Not IO.Directory.Exists(MYFOLDER & "\FailImag") Then Directory.CreateDirectory(MYFOLDER & "\FolderImageName")

        Dim FolderImageName As String = MYFOLDER & "\FolderImageName"
        STarScannering(Me.ComboScanners, FolderImageName, ImageName, FileType, Me.PictureBox1)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        TryScanner()
    End Sub

    Private Sub ButScan_Click(sender As Object, e As EventArgs) Handles ButScan.Click
        Try
            If Me.ComboScanners.Items Is Nothing Then FillcombByScanners()
            Me.BackgroundWorker1.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CreatePDF_Click(sender As Object, e As EventArgs) Handles CreatePDF.Click
        CraeteToPDF(Me)
    End Sub

    'Private Sub craeteToPDF(formScan As FormScan)
    '    Throw New NotImplementedException()
    'End Sub

    Private Sub PutOpen_Click(sender As Object, e As EventArgs) Handles putOpen.Click
        Try
            Dim OBD As New FolderBrowserDialog
            If OBD.ShowDialog = DialogResult.OK Then
                Me.CheckedListBox1.Items.Clear()
                Dim XPATH As New DirectoryInfo(OBD.SelectedPath)
                For Each FILE As FileInfo In XPATH.GetFiles
                    Select Case FILE.Extension.ToLower
                        Case ".jpg", ".bmp ", ".gif", ".png", ".tif", ".tiff", ".jpeg", ".enf", ".wmf"
                            Me.CheckedListBox1.Items.Add(FILE.FullName)
                    End Select
                Next
                Me.Lblcaut.Text = Me.CheckedListBox1.Items.Count
                Me.LablImagespath.Text = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'OpenFileDialog1.Filter = "Bitmap file (*.bmp)|*.bmp|TIFF file (*.tif)|*.tif|JPEG file (*.jpg)|*.jpg|PNG file (*.png)|*.png|GIF file (*.gif)|*.gif|All files (*.*)|*.*"


        'Me.OpenFileDialog1.Title = "اضافة الملفات"
        'Me.OpenFileDialog1.Filter = "All Files|*.*"
        'If (Me.OpenFileDialog1.ShowDialog <> DialogResult.Cancel) Then
        '    Me.LabFileName.Visible = True
        '    Me.LabFileSize.Visible = True
        '    Me.LabFileName.Text = Me.OpenFileDialog1.FileName
        '    Me.FileName = Path.GetFileNameWithoutExtension(Me.OpenFileDialog1.FileName)
        '    Me.FileType = Path.GetExtension(Me.OpenFileDialog1.FileName).ToLower
        '    Me.FileInfo = Me.GetFileDescription(Me.OpenFileDialog1.FileName)
        '    If (Me.FileType = ".pdf") Then
        '        Me.FileInfo = "Adobe Acrobat PDF Files"
        '    End If
        '    If (Me.FileInfo = "") Then
        '        Me.FileInfo = " "
        '    End If
        '    Me.TEXTFileType.Text = Me.FileType
        '    Me.TextFileInfo.Text = Me.FileInfo
        '    If (Me.LabFileName.Text.Length <= 0) Then
        '        MessageBox.Show("يجب كتابة اسم للملف", Me.Text)
        '    Else
        '        Try
        '            Me.FileStream = New FileStream(Me.LabFileName.Text, FileMode.Open, FileAccess.Read)
        '            Me.Reader = New BinaryReader(Me.FileStream)
        '            Me.FileData = Nothing
        '            Me.FileData = Me.Reader.ReadBytes(CInt(Me.FileStream.Length))
        '            Me.FileSize = Me.FileData.Length
        '            Me.LabFileSize.Text = Module1.FrombytestoMB(CInt(Math.Round(Me.FileSize)))
        '            Me.FileStream.Close()
        '            Me.Pathf = Me.OpenFileDialog1.FileName.ToLower
        '            Me.LabFileName.Text = Me.OpenFileDialog1.FileName
        '            If (Strings.Len(Me.OpenFileDialog1.FileName) > 0) Then
        '                Module1.SCANFILE = Me.OpenFileDialog1.FileName
        '                Me.PictureBox1.Image = Image.FromFile(Module1.SCANFILE)
        '            Else
        '                Module1.SCANFILE = ""
        '                Me.PictureBox1.Image = Nothing
        '                Return
        '            End If
        '        Catch ex As Exception
        '            MessageBox.Show(Information.Err.Description, "خطأ في جلب الملف")
        '        Finally
        '            MessageBox.Show("تم جلب الملف", "File ( Load )", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '        End Try

        '        Me.LabFileName.Text = Me.OpenFileDialog1.FileName
        '        If (Me.LabFileName.Text = Nothing) Then
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub ButDefaultScan_Click(sender As Object, e As EventArgs) Handles ButDefaultScan.Click
        My.Settings.DefaultScaner = GetScanSource()
        My.Settings.Save()
    End Sub

    Shared Function GetFileDescription(ByVal filePath As String) As String
        Dim regKey As RegistryKey = Nothing
        Try
            regKey = Registry.ClassesRoot.OpenSubKey(New System.IO.FileInfo(filePath).Extension)
            If regKey IsNot Nothing Then
                Dim className As String = regKey.GetValue("")
                If className.Length > 0 Then
                    Dim regKey2 As RegistryKey = Nothing
                    Try
                        regKey2 = Registry.ClassesRoot.OpenSubKey _
                            (className)
                        Return regKey2.GetValue("")
                    Catch e As Exception
                    Finally
                        If regKey2 IsNot Nothing Then regKey2.Close()
                    End Try
                End If
            End If
        Catch e As Exception
        Finally
            If regKey IsNot Nothing Then regKey.Close()
        End Try
        Return Nothing
    End Function

    Private Sub SHOSelectedItemsListBox()
        Try
            If Me.CheckedListBox1.Items.Count > 0 Then
                Dim BT As New Bitmap(Me.CheckedListBox1.SelectedItem.ToString)
                Me.PictureBox1.Image = BT
                Me.LablImagespath.Text = Me.CheckedListBox1.SelectedItem.ToString
            End If
        Catch ex As Exception
            Return
        End Try
    End Sub

    Private Sub PrintPage(ByVal sender As Object, e As Printing.PrintPageEventArgs)
        Try
            e.Graphics.DrawImage(PictureBox1.Image, 0, 0, PictureBox1.Width, PictureBox1.Height)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Printimage(ByVal pb As PictureBox)
        Try
            If pb.Image Is Nothing Then Return
            If MessageBox.Show("هل تود طباعة الصوره", "رسالة تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                pb.SizeMode = PictureBoxSizeMode.AutoSize
                Dim pd As New PrintDialog
                Dim dok As New Printing.PrintDocument
                AddHandler dok.PrintPage, AddressOf PrintPage
                pd.Document = dok
                If pd.ShowDialog() = DialogResult.OK Then dok.Print()
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub Classcontrol()
        Try
            Me.CheckedListBox1.Items.Clear()
            Me.Lblcaut.Text = 0
            Me.LablImagespath.Text = ""
            Me.PictureBox1.Image = Nothing
            Me.ComboSizeimges.SelectedIndex = 1

            Me.PanelImage.AutoScroll = True
            Me.PanelImage.VerticalScroll.Visible = True
            Me.PanelImage.HorizontalScroll.Visible = True


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReloadItems()
        Try
            If Me.CheckedListBox1.Items.Count = 0 Then Return
            Dim Items As Object() = New Object(Me.CheckedListBox1.Items.Count - 1) {}
            Me.CheckedListBox1.Items.CopyTo(Items, 0)
            Me.CheckedListBox1.Items.Clear()
            Me.CheckedListBox1.Items.AddRange(Items)
            Me.Lblcaut.Text = Me.CheckedListBox1.Items.Count
            Me.LablImagespath.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        SHOSelectedItemsListBox()
    End Sub

    Private Sub CheckedListBox1_Click(sender As Object, e As EventArgs) Handles CheckedListBox1.Click
        SHOSelectedItemsListBox()
    End Sub

    Private Sub PictureBox1_SizeChanged(sender As Object, e As EventArgs) Handles PictureBox1.SizeChanged
        'Me.Size = New Size(Me.Width + Me.PictureBox1.Width - Me.PanelImage.Width,
        '               Me.Height + Me.PictureBox1.Height - Me.PanelImage.Height)
        PictureBox1.Location = New Point((PanelImage.Width / 2) - (PictureBox1.Width / 2), (PanelImage.Height / 2) - (PictureBox1.Height / 2))

    End Sub

    Private Sub ButZoomin_Click(sender As Object, e As EventArgs) Handles ButZoomin.Click
        ZoominoutPictureBox(Me.PictureBox1, 1.2)
    End Sub

    Private Sub ButZoomout_Click(sender As Object, e As EventArgs) Handles ButZoomout.Click
        ZoominoutPictureBox(Me.PictureBox1, 0.8)
    End Sub

    Private Sub ButPDF_Foldar_Click(sender As Object, e As EventArgs) Handles ButPDF_Foldar.Click
        If Me.CheckedListBox1.Items.Count = 0 Then Return
        Try
            Me.PictureBox1.Image = Nothing
            Dim Foldarpath As String = Path.GetDirectoryName(Me.CheckedListBox1.Items(0))
            Process.Start(Foldarpath)

        Catch ex As Exception
            Return
        End Try
    End Sub

    Private Sub ButLeft_Click(sender As Object, e As EventArgs) Handles ButLeft.Click
        If Me.CheckedListBox1.Items.Count = 0 Then Return
        If Me.CheckedListBox1.SelectedItem = Nothing Then
            Me.CheckedListBox1.SetSelected(Me.CheckedListBox1.Items.Count - 1, True)
        Else
            Dim i As Short = Me.CheckedListBox1.SelectedIndex
            If i = 0 Then Return
            Me.CheckedListBox1.SetSelected(i - 1, True)
        End If
    End Sub

    Private Sub TButRaet_Click(sender As Object, e As EventArgs) Handles TButRaet.Click
        If Me.CheckedListBox1.Items.Count = 0 Then Return
        If Me.CheckedListBox1.SelectedItem = Nothing Then
            Me.CheckedListBox1.SetSelected(0, True)
        Else
            Dim i As Short = Me.CheckedListBox1.SelectedIndex
            If i = Me.CheckedListBox1.Items.Count - 1 Then Return
            Me.CheckedListBox1.SetSelected(i + 1, True)
        End If
    End Sub

    Private Sub Butrotolaeft_Click(sender As Object, e As EventArgs) Handles Butrotolaeft.Click
        Rotatlaft(Me.PictureBox1)
    End Sub

    Private Sub ButDown_Click(sender As Object, e As EventArgs) Handles ButDown.Click
        If Me.CheckedListBox1.Items.Count = 0 Or Me.CheckedListBox1.SelectedItem = Nothing Then Return
        Dim i As Short = Me.CheckedListBox1.SelectedIndex
        Dim STR As String = Me.CheckedListBox1.SelectedItem.ToString
        If i < Me.CheckedListBox1.Items.Count - 1 Then
            Me.CheckedListBox1.Items.RemoveAt(i)
            Me.CheckedListBox1.Items.Insert(i + 1, STR)
            Me.CheckedListBox1.SetSelected(i + 1, True)
        End If
    End Sub

    Private Sub ButUP_Click(sender As Object, e As EventArgs) Handles ButUP.Click
        If Me.CheckedListBox1.Items.Count = 0 Or Me.CheckedListBox1.SelectedItem = Nothing Then Return
        Dim i As Short = Me.CheckedListBox1.SelectedIndex
        Dim STR As String = Me.CheckedListBox1.SelectedItem.ToString
        If i > 0 Then
            Me.CheckedListBox1.Items.RemoveAt(i)
            Me.CheckedListBox1.Items.Insert(i - 1, STR)
            Me.CheckedListBox1.SetSelected(i - 1, True)
        End If
    End Sub

    Private Sub ButDELET_Click(sender As Object, e As EventArgs) Handles ButDELET.Click
        Me.CheckedListBox1.Items.Clear()
        Me.Lblcaut.Text = Me.CheckedListBox1.Items.Count
        Me.LablImagespath.Text = ""
        Me.PictureBox1.Image = Nothing
    End Sub

    Private Sub Butrotorait_Click(sender As Object, e As EventArgs) Handles Butrotorait.Click
        Rotatraeit(Me.PictureBox1)
    End Sub

    Private Sub Butprint_Click(sender As Object, e As EventArgs) Handles Butprint.Click
        Printimage(Me.PictureBox1)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboSizeimges.SelectedIndexChanged
        Select Case ComboSizeimges.SelectedIndex
            Case 0
                Me.PictureBox1.SizeMode = PictureBoxSizeMode.Normal
            Case 1
                Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Case 2
                Me.PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
            Case 3
                Me.PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
            Case 4
                Me.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        End Select
    End Sub

    Private Sub Butclar_Click(sender As Object, e As EventArgs) Handles Butclar.Click
        If Me.CheckedListBox1.Items.Count = 0 Or Me.CheckedListBox1.SelectedItem = Nothing Then Return
        If MessageBox.Show("سيتم حذف الصوره", "هل ترغب بالاستمرار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.CheckedListBox1.Items.RemoveAt(Me.CheckedListBox1.SelectedIndex)
            Me.Lblcaut.Text = Me.CheckedListBox1.Items.Count
            Me.PictureBox1.Image = Nothing
            Me.LablImagespath.Text = ""
        End If
    End Sub

    Private Sub Butrfresh_Click(sender As Object, e As EventArgs) Handles Butrfresh.Click
        ReloadItems()
    End Sub

    Private Sub Pb1_MouseDown(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs) _
         Handles PictureBox1.MouseDown
        'Capture the initial point 
        m_PanStartPoint = New Point(e.X, e.Y)
    End Sub
    Private Sub Pb1_MouseMove(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles PictureBox1.MouseMove
        'Verify Left Button is pressed while the mouse is moving
        If e.Button = Windows.Forms.MouseButtons.Left Then

            'Here we get the change in coordinates.
            Dim DeltaX As Integer = m_PanStartPoint.X - e.X
            Dim DeltaY As Integer = m_PanStartPoint.Y - e.Y

            'Then we set the new autoscroll position.
            'ALWAYS pass positive integers to the panels autoScrollPosition method
            PanelImage.AutoScrollPosition =
            New Drawing.Point(DeltaX - PanelImage.AutoScrollPosition.X,
                            DeltaY - PanelImage.AutoScrollPosition.Y)
        End If

    End Sub

    Private Sub PanelImage_SizeChanged(sender As Object, e As EventArgs) Handles PanelImage.SizeChanged
        PictureBox1.Location = New Point((PanelImage.Width / 2) - (PictureBox1.Width / 2), (PanelImage.Height / 2) - (PictureBox1.Height / 2))

    End Sub
End Class