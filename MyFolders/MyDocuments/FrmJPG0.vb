Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports ALquhaliLibrary
Imports Microsoft.Win32
Imports WIA

Public Class FrmJPG0
    Public WithEvents BS As New BindingSource

    Public ID As Integer

<<<<<<< HEAD
    Dim FileStream As FileStream
    Dim Reader As BinaryReader = Nothing 'طريقة قرائة الملفات
=======
    Dim FileStream As System.IO.FileStream
    Dim Reader As System.IO.BinaryReader = Nothing 'طريقة قرائة الملفات
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Dim FileData As Byte() = Nothing           'لحفظ الملف
    Dim FileType As String = ""               ' نوع الملف
    Private ReadOnly FileType1 As String
    Dim FileName As String = ""               ' اسم الملف
    Dim FileSize As Double = 0                 ' حجم الملف
    Dim FileInfo As String = ""               ' نوعية الملف كما هو في مخزنRegistry
    Dim Pathf As String                        'مسار الملف
    Dim MyPath As String

    Private ReadOnly Fol As String
    Public SqlDataAdapter1 As SqlDataAdapter

    Private MyFileInfo As FileInfo
    Private DragDropA As Boolean = False
    Private DockStyl As Boolean = False

    Public Sub FillcombByScanners()
        Me.ComboScanners.Items.Clear()
        Dim DeviceManagera = New DeviceManager
        For i As Integer = 1 To DeviceManagera.Deviceinfos.count
            If DeviceManagera.Deviceinfos(i).type <> WiaDeviceType.ScannerDeviceType Then Continue For
            Me.ComboScanners.Items.Add(New Scanner(DeviceManagera.Deviceinfos(i)))
        Next
        If Me.ComboScanners.Items.Count > 0 Then Me.ComboScanners.SelectedIndex = 0
    End Sub
    Private Sub STarScannering(_ComboScanners As ComboBox, savedImageFoldar As String, ImgeName As String, ImageExe As Short, PIC As PictureBox)
        If _ComboScanners Is Nothing Then
            Throw New ArgumentNullException(NameOf(_ComboScanners))
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
                                                 ImgExtension = ".png"
                                             Case 1
                                                 Image = Devic.ScanJPEG
                                                 ImgExtension = ".jpeg"
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
        Me.LabFileName.Text = MyPath
        MyFileInfo = New FileInfo(Me.LabFileName.Text)
        If String.IsNullOrWhiteSpace(MyFileInfo.Extension) Then Exit Sub
        Me.ShowMyFileInfo()
    End Sub
<<<<<<< HEAD
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
=======
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Threading.Thread.Sleep(100)
        MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        If Not IO.Directory.Exists(MYFOLDER & "\FailImag") Then Directory.CreateDirectory(MYFOLDER & "\FolderImageName")
        Dim FolderImageName As String = MYFOLDER & "\FolderImageName"
        STarScannering(Me.ComboScanners, FolderImageName, ImageName, FileType1, Me.PictureBox1)
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        TryScanner()
    End Sub



<<<<<<< HEAD
    Private Sub FrmJPG0_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
=======
    Private Sub FrmJPG0_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub FrmJPG0_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub FrmJPG0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.ADDBUTTON_Click(sender, e)
                    Exit Select
                Case Keys.F2
                    Me.SAVEBUTTON_Click(sender, e)
                    Exit Select
                Case Keys.F7
                    Me.ButScan_Click(sender, e)
                    Exit Select
                Case Keys.F8
                    Me.ButSaveFile_Click(sender, e)
                    Exit Select
                Case Keys.F9
                    Me.ButLogq_Click(sender, e)
                    Exit Select
                Case Keys.F10
                    Me.ButEditImage_Click(sender, e)
                    Exit Select
                Case Keys.Escape
                    Me.Close()
                    Exit Select
            End Select
            'e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub
<<<<<<< HEAD
    Private Sub FrmJPG0_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmJPG0_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.PictureBox1.AllowDrop = True
        Me.SHOWBUTTON()
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        FillcombByScanners()
        DockStyl = True
    End Sub
<<<<<<< HEAD
    Public Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
=======
    Public Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Not Connection.TestNet Then
                Interaction.MsgBox("الاتصال بالانترنت غير متوفر", MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
            Call MangUsers()
            If Not ModuleGeneral.LockAddRow Then
                Interaction.MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
            GetAutoNumberMyDOCUMENTS()
<<<<<<< HEAD
            Dim Year As Integer = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
            Dim NumberDOCUMENTS As Object = "DO" & Year & SEARCHDATA.NumberMyDocuments
=======
            Dim NumberDOCUMENTS As Object = "DO" & NoMyDocuments
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            GetAutoNumberMyDOCUMENTSFL(NumberDOCUMENTS)
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            Me.ButScan.Enabled = True
            Me.ButSaveFile.Enabled = False
            Me.ButLogq.Enabled = True
            Me.ButEditImage.Enabled = False
            Me.BS.Position = Me.BS.Count - 1
            Me.BS.EndEdit()
            Me.BS.AddNew()
            ModuleGeneral.CLEARDATA1(Me)
            Me.MAXRECORD()
            'Me.TextLO.Enabled = True
            'Me.TEXTFileNo.Enabled = True
            Me.PictureBox1.Image = Nothing
            Me.TextLO.Text = NumberDOCUMENTS
            Me.TEXTFileNo.Text = SEARCHDATA.NumberMyDOCUMENTSFL
            Me.DateP1.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TEXTFileNo.Focus()
<<<<<<< HEAD
            Dim Sound As Stream = My.Resources.addv
=======
            Dim Sound As System.IO.Stream = My.Resources.addv
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error96", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
=======
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockSave = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Me.SAVERECORD()

            Insert_Actions(Me.TEXTBOX1.Text.Trim, "حفظ", Me.Text)
            Me.SAVEBUTTON.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error96", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub ButScan_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButScan.Click
=======
    Private Sub ButScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButScan.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'Dim scan As New FormScan1
        'Dim f As FormScan1 = New FormScan1(AddressOf ShowImage)
        'f.Show()
        Try
            If Me.ComboScanners.Items Is Nothing Then FillcombByScanners()
            Me.BackgroundWorker1.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ShowImage(ByVal image As Image)
        PictureBox1.Image = image
    End Sub

<<<<<<< HEAD
    Private Sub ButSaveFile_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButSaveFile.Click
=======
    Private Sub ButSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSaveFile.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim bmap As Image
        Clipboard.SetImage(Me.PictureBox1.Image)
        bmap = Clipboard.GetImage
        SaveFileDialog1.Filter = "Bitmap file (*.bmp)|*.bmp|TIFF file (*.tif)|*.tif|JPEG file (*.jpg)|*.jpg|PNG file (*.png)|*.png|GIF file (*.gif)|*.gif|All files (*.*)|*.*"
        With Me.SaveFileDialog1
            .FilterIndex = 3
            .Title = "حفظ ملف"
            MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            .InitialDirectory = MYFOLDER & "\Photos"
            .ShowDialog()
            If Len(.FileName) > 0 Then
                Select Case SaveFileDialog1.FilterIndex
                    Case 1
                        bmap.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Bmp)
                    Case 2
                        bmap.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Tiff)
                    Case 3
                        bmap.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Jpeg)
                    Case 4
                        bmap.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Png)
                    Case 5
                        bmap.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Gif)
                End Select
            End If
        End With
    End Sub

    Shared Function GetFileDescription(ByVal filePath As String) As String
        Dim regKey As RegistryKey = Nothing
        Try
<<<<<<< HEAD
            regKey = Registry.ClassesRoot.OpenSubKey(New FileInfo(filePath).Extension)
=======
            regKey = Registry.ClassesRoot.OpenSubKey(New System.IO.FileInfo(filePath).Extension)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
    Private Sub PHOTOEDIT()
        On Error Resume Next
        Dim Consum As New SqlConnection(ModuleGeneral.constring)
        Dim SQL As String = " Update DOCUMENTS SET  DOC5 = @DOC5 WHERE DOC1 = @DOC1"
<<<<<<< HEAD
        Dim CMD As New SqlCommand With {
=======
        Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        Dim fs As New FileStream(op.FileName, FileMode.Open, FileAccess.Read)
        Dim r As New BinaryReader(fs)
        Dim FileByteArray(fs.Length - 1) As Byte
        r.Read(FileByteArray, 0, CInt(fs.Length))
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@DOC1", SqlDbType.Int).Value = Me.TEXTBOX1.Text.Trim
            .Parameters.Add("@DOC6", SqlDbType.Image).Value = FileByteArray
            .CommandText = SQL
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        CMD.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Public Sub MAXRECORD()
        On Error Resume Next
        Dim V As Integer
        Dim Consum As New SqlConnection(ModuleGeneral.constring)
        Dim SQL As New SqlCommand("SELECT MAX(DOC1) FROM MYDOCUMENTSHOME", Consum)
<<<<<<< HEAD
        Dim CMD As New SqlCommand
=======
        Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        If IsDBNull(resualt) Then
            Me.TEXTBOX1.Text = 1
        Else
            Me.TEXTBOX1.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub
<<<<<<< HEAD
    Private Sub ButLogq_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButLogq.Click
=======
    Private Sub ButLogq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButLogq.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.op.Title = "اضافة الملفات"
        Me.op.Filter = "All Files|*.*"
        If Me.op.ShowDialog <> DialogResult.Cancel Then
            Me.LabFileName.Visible = True
            Me.LabFileSize.Visible = True
            Me.LabFileName.Text = Me.op.FileName
            Me.FileName = Path.GetFileNameWithoutExtension(Me.op.FileName)
            Me.FileType = Path.GetExtension(Me.op.FileName).ToLower
            Me.FileInfo = GetFileDescription(Me.op.FileName)
            If Me.FileType = ".pdf" Then
                Me.FileInfo = "Adobe Acrobat PDF Files"
            End If
            If Me.FileInfo = "" Then
                Me.FileInfo = " "
            End If


            If Me.LabFileName.Text.Length <= 0 Then
                MessageBox.Show("يجب كتابة اسم للملف", Me.Text)
            Else
                Try
                    Me.FileStream = New FileStream(Me.LabFileName.Text, FileMode.Open, FileAccess.Read)
                    Me.Reader = New BinaryReader(Me.FileStream)
                    Me.FileData = Nothing
                    Me.FileData = Me.Reader.ReadBytes(CInt(Me.FileStream.Length))
                    Me.FileSize = Me.FileData.Length
                    Me.LabFileSize.Text = ModuleGeneral.FrombytestoMB(CInt(Math.Round(Me.FileSize)))
                    Me.FileStream.Close()
                    Me.Pathf = Me.op.FileName.ToLower
                    Me.LabFileName.Text = Me.op.FileName
                    If Strings.Len(Me.op.FileName) > 0 Then
                        ModuleGeneral.SCANFILE = Me.op.FileName
                        Me.PictureBox1.Image = Image.FromFile(ModuleGeneral.SCANFILE)
                    Else
                        ModuleGeneral.SCANFILE = ""
                        Me.PictureBox1.Image = Nothing
                        Return
                    End If
                Catch exception1 As Exception
                    MessageBox.Show(Information.Err.Description, "خطأ في جلب الملف")
                Finally
                    MessageBox.Show("تم جلب الملف", "File ( Load )", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End Try
                Try
                    Me.LabFileName.Text = Me.op.FileName
                    If Me.LabFileName.Text = Nothing Then
                    End If
                Catch ex As Exception

                End Try
            End If
        End If

    End Sub
<<<<<<< HEAD
    Private Sub ButEditImage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButEditImage.Click
=======
    Private Sub ButEditImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButEditImage.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Static P As Integer
        P = Me.BS.Position
        Me.PHOTOEDIT()
        Me.FrmJPG0_Load(sender, e)
        Me.BS.Position = P
    End Sub
<<<<<<< HEAD
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As EventArgs)
=======
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Me.PictureBox1.Dock = DockStyle.None Then
            Me.PictureBox1.BringToFront()
            Me.PictureBox1.Dock = DockStyle.Fill
        Else
            Me.PictureBox1.Dock = DockStyle.None
        End If
    End Sub
    Private Sub SAVERECORD()
        Try
            Dim Consum As New SqlConnection(ModuleGeneral.constring)
            If Me.TextLO.Text = "" Then
                MessageBox.Show("يجب تعبئة كافة الحقول قبل الحفظ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            ElseIf Me.TEXTFileNo.Text = "" Then
                MessageBox.Show("يجب تعبئة كافة الحقول قبل الحفظ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            ElseIf Me.TEXTFileSubject.Text = "" Then
                MessageBox.Show("يجب تعبئة كافة الحقول قبل الحفظ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            ElseIf Me.TextFileDescription.Text = "" Then
                MessageBox.Show("يجب تعبئة كافة الحقول قبل الحفظ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                Dim cmdText As String = "INSERT INTO MYDOCUMENTSHOME(LO, DOC2, DOC3, DOC4, DOC5, DOC6, DOC7, DOC8, date_1, USERNAME, CUser, COUser, da, ne) VALUES     (@LO, @DOC2, @DOC3, @DOC4, @DOC5, @DOC6, @DOC7, @DOC8, @date_1, @USERNAME, @CUser, @COUser, @da, @ne)"
                Dim command As New SqlCommand(cmdText, Consum)
                Me.FileStream = New FileStream(Me.LabFileName.Text, FileMode.Open, FileAccess.Read)
                Me.Reader = New BinaryReader(Me.FileStream)
                Me.FileData = Nothing
                Me.FileData = Me.Reader.ReadBytes(CInt(Me.FileStream.Length))
                Me.FileType = Path.GetExtension(Me.op.FileName).ToLower
                Me.FileSize = Me.FileData.Length
                Me.FileStream.Close()
                Dim command2 As SqlCommand = command
                command2.CommandType = CommandType.Text
                command2.Connection = Consum
                command2.Parameters.Add("@DOC1", SqlDbType.Int).Value = Me.TEXTBOX1.Text
                command2.Parameters.Add("@LO", SqlDbType.NVarChar).Value = Me.TextLO.Text
<<<<<<< HEAD
                command2.Parameters.Add("@DOC2", SqlDbType.NVarChar).Value = Me.TEXTFileNo.Text
=======
                command2.Parameters.Add("@DOC2", SqlDbType.Int).Value = Me.TEXTFileNo.Text
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                command2.Parameters.Add("@DOC3", SqlDbType.NVarChar).Value = Me.FileType
                command2.Parameters.Add("@DOC4", SqlDbType.NVarChar).Value = Me.TEXTFileSubject.Text
                command2.Parameters.Add("@DOC5", SqlDbType.NVarChar).Value = Me.TextFileDescription.Text
                command2.Parameters.Add("@DOC6", SqlDbType.Image).Value = File.ReadAllBytes(Me.LabFileName.Text)
                command2.Parameters.Add("@DOC7", SqlDbType.NVarChar).Value = Me.FileInfo
                command2.Parameters.Add("@DOC8", SqlDbType.NVarChar).Value = ModuleGeneral.FrombytestoMB(CInt(Math.Round(Conversion.Val(Me.FileSize))))
                command2.Parameters.Add("@date_1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                command2.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                command2.Parameters.Add("@CUser", SqlDbType.NVarChar).Value = ModuleGeneral.CUser
                command2.Parameters.Add("@COUser", SqlDbType.NVarChar).Value = ModuleGeneral.COUser
                command2.Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                command2.Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                command2 = Nothing
                If Consum.State = ConnectionState.Open Then
                    Consum.Close()
                End If
                Consum.Open()
                command.ExecuteNonQuery()
                Consum.Close()
                File.Copy(Me.LabFileName.Text, Me.Fol & Me.TEXTBOX1.Text, True)
                MessageBox.Show("تم حفظ المعاملة بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.ADDBUTTON.Enabled = True
                Me.SAVEBUTTON.Enabled = False
                Me.ButScan.Enabled = True
                Me.ButSaveFile.Enabled = False
                Me.ButLogq.Enabled = True
                Me.ButEditImage.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Consum.Close()
        End Try
    End Sub
    Private Sub Butrotolaeft_Click(sender As Object, e As EventArgs) Handles Butrotolaeft.Click
        Rotatlaft(Me.PictureBox1)
    End Sub

    Private Sub Butrotorait_Click(sender As Object, e As EventArgs) Handles Butrotorait.Click
        Rotatraeit(Me.PictureBox1)
    End Sub

    Private Sub PictureBox1_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox1.DragDrop
        Dim FileName As String = e.Data.GetData(DataFormats.FileDrop)(0)
        MyFileInfo = New FileInfo(FileName)
        If String.IsNullOrWhiteSpace(MyFileInfo.Extension) Then Exit Sub
        Me.PictureBox1.Image = Image.FromFile(FileName)
        Me.ShowMyFileInfo()


    End Sub

    Private Sub PictureBox1_DragEnter(sender As Object, e As DragEventArgs) Handles PictureBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
            Me.DragDropA = True
        End If
    End Sub
    Private Sub ShowMyFileInfo()
        Me.LabFileName.Text = Me.MyFileInfo.FullName

        Me.FileSize = Me.MyFileInfo.Length
        Me.FileType = Me.MyFileInfo.Extension
        Me.FileInfo = GetFileDescription(Me.MyFileInfo.FullName)
        Me.FileName = Me.MyFileInfo.Name

        Me.LabFileSize.Text = ModuleGeneral.FrombytestoMB(CInt(Math.Round(Me.FileSize)))
        Me.LabFileType.Text = Me.FileType
        Me.LabFileInfo.Text = Me.FileInfo

        'Me.PictureBox1.Image = Icon.ExtractAssociatedIcon(Me.MyFileInfo.FullName).ToBitmap
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim current As Control
        If DockStyl = False Then
            DockStyl = True
            Dim enumerator As IEnumerator
            Try
                enumerator = Me.Controls.GetEnumerator
                Do While enumerator.MoveNext
                    current = DirectCast(enumerator.Current, Control)
                    If TypeOf current Is TextBox Or TypeOf current Is ComboBox Or TypeOf current Is Label Or TypeOf current Is Panel Or TypeOf current Is GroupBox Or TypeOf current Is ListView Then
                        current.Visible = False
                    End If
                    Me.PanelImage.Visible = True
                    Me.PanelImage.BringToFront()
                Loop
            Finally

            End Try
            Me.PictureBox1.BringToFront()
            Me.PictureBox1.Dock = DockStyle.Fill
        Else
            DockStyl = False
            Dim enumerator As IEnumerator
            Try
                enumerator = Me.Controls.GetEnumerator
                Do While enumerator.MoveNext
                    current = DirectCast(enumerator.Current, Control)
                    If TypeOf current Is TextBox Or TypeOf current Is ComboBox Or TypeOf current Is Label Or TypeOf current Is Panel Or TypeOf current Is GroupBox Or TypeOf current Is ListView Then
                        current.Visible = True
                    End If
                Loop
            Finally

            End Try
            Me.PictureBox1.Dock = DockStyle.Fill
        End If

    End Sub

    Private Sub TextFileDescription_TextChanged(sender As Object, e As EventArgs) Handles TextFileDescription.TextChanged
        LabMaxCh.Text = "عدد الحروف : " & (300 - TextFileDescription.Text.Length).ToString() & " " & "حرف"
        If TextFileDescription.Text.Length >= 300 Then
            MessageBox.Show("لا يجب ان يكون عدد حروف حقل وصف الملف اكثر من" & " " & "(300)" & " " & "حرف", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            SAVEBUTTON.Enabled = False
            Exit Sub
        Else
            SAVEBUTTON.Enabled = True
        End If
    End Sub

End Class