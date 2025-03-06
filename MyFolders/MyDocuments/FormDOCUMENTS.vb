Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.Threading
Imports ALquhaliLibrary
Imports DevExpress.XtraSplashScreen
Imports Microsoft.Win32
Imports WIA

Public Class FormDOCUMENTS
    Public ID As Integer
<<<<<<< HEAD
    Private FileStream As FileStream
    Private Reader As BinaryReader = Nothing 'طريقة قرائة الملفات
=======
    Private FileStream As System.IO.FileStream
    Private Reader As System.IO.BinaryReader = Nothing 'طريقة قرائة الملفات
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private FileData As Byte() = Nothing           'لحفظ الملف
    Private FileType As String = ""               ' نوع الملف
    Private ReadOnly FileType1 As String
    Private FileName As String = ""               ' اسم الملف
    Private FileSize As Double = 0                 ' حجم الملف
    Private FileInfo As String = ""               ' نوعية الملف كما هو في مخزنRegistry
    Private Pathf As String                        'مسار الملف
    Private MyPath As String
<<<<<<< HEAD
    ReadOnly op As New Windows.Forms.OpenFileDialog
=======
    ReadOnly op As New System.Windows.Forms.OpenFileDialog
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    ReadOnly Fol As String = mykey.GetValue("MYFOLDER", Application.StartupPath & "\CO_MAS\Folder pdf\")
    Public BUD As Boolean = False
    Public XU As String
    Dim dt As New DataTable
    Dim dt1 As New DataTable
    Dim dt2 As New DataTable

    Private dtSource As DataTable
    Private PageCount As Integer
    Private maxRec As Integer
    Private pageSize As Integer
    Private currentPage As Integer
    Private recNo As Integer

    Public WithEvents BS As New BindingSource

    Private MyFileInfo As FileInfo
    Private DragDropA As Boolean = False
    Private DockStyl As Boolean = False

    Public FPath As String
    Dim F_Data As Byte()

    ReadOnly ieProcess As New Process()

    Public Sub FillcombByScanners()
        Me.ComboScanners.Items.Clear()
        Dim DeviceManagera = New DeviceManager
        For i As Integer = 1 To DeviceManagera.DeviceInfos.Count
            If DeviceManagera.DeviceInfos(i).Type <> WiaDeviceType.ScannerDeviceType Then Continue For
            Me.ComboScanners.Items.Add(New Scanner(DeviceManagera.DeviceInfos(i)))
        Next
        If Me.ComboScanners.Items.Count > 0 Then Me.ComboScanners.SelectedIndex = 0
    End Sub

    Private Sub STarScannering(ByVal _ComboScanners As ComboBox, savedImageFoldar As String, ImgeName As String, ImageExe As Short, PIC As PictureBox)
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
        Me.Panel5.Visible = True
        Me.LabFileName.Visible = True
        Me.LabFileSize.Visible = True
        Me.LabFileName.BringToFront()
        Me.LabFileName.Text = MyPath
        MyFileInfo = New FileInfo(Me.LabFileName.Text)
        If String.IsNullOrWhiteSpace(MyFileInfo.Extension) Then Exit Sub
        Me.ShowMyFileInfo()
    End Sub

<<<<<<< HEAD
    Private Sub BackWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackWorker1.DoWork
=======
    Private Sub BackWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker1.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Threading.Thread.Sleep(100)
        MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        If Not IO.Directory.Exists(MYFOLDER & "\FailImag") Then Directory.CreateDirectory(MYFOLDER & "\FolderImageName")
        Dim FolderImageName As String = MYFOLDER & "\FolderImageName"
        STarScannering(Me.ComboScanners, FolderImageName, ImageName, FileType1, Me.PictureBox1)
    End Sub

    Private Sub BackWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackWorker1.RunWorkerCompleted
        TryScanner()
    End Sub

    Private Sub INS_PDF()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            If Me.TEXTFileSubject.Text = "" Then MessageBox.Show("يجب تعبئة كافة الحقول قبل الحفظ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If Me.TextTransactionNumber.Text = "" Then MessageBox.Show("يجب تعبئة كافة الحقول قبل الحفظ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If Me.TextFileDescription.Text = "" Then MessageBox.Show("يجب تعبئة كافة الحقول قبل الحفظ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Dim sql As String = "INSERT INTO DOCUMENTS(LO, DOC2, DOC3, DOC4, DOC5, DOC6, DOC7, DOC8, date_1, USERNAME, CUser, COUser, da, ne) VALUES     (@LO, @DOC2, @DOC3, @DOC4, @DOC5, @DOC6, @DOC7, @DOC8, @date_1, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlCommand(sql, Consum)
<<<<<<< HEAD
            FileStream = New FileStream(LabFileName.Text, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Reader = New BinaryReader(FileStream) ' تعريف القارئ
=======
            FileStream = New System.IO.FileStream(LabFileName.Text, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Reader = New System.IO.BinaryReader(FileStream) ' تعريف القارئ
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            FileData = Nothing 'تفريغ البيانات
            FileData = Reader.ReadBytes(CType(FileStream.Length, Integer)) 'قراءة الملف
            FileSize = FileData.Length 'حجم الملف
            FileStream.Close()
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@LO", SqlDbType.NVarChar).Value = Me.TextTransactionNumber.Text.Trim
                .Parameters.Add("@DOC2", SqlDbType.NVarChar).Value = Me.TextFileNo.Text.Trim
                .Parameters.Add("@DOC3", SqlDbType.NVarChar).Value = Me.LabFileType.Text.Trim
                .Parameters.Add("@DOC4", SqlDbType.NVarChar).Value = Me.TEXTFileSubject.Text.Trim
                .Parameters.Add("@DOC5", SqlDbType.NVarChar).Value = Me.TextFileDescription.Text.Trim
                .Parameters.Add("@DOC6", SqlDbType.Image).Value = File.ReadAllBytes(Me.LabFileName.Text)
                .Parameters.Add("@DOC7", SqlDbType.NVarChar).Value = FileInfo
                .Parameters.Add("@DOC8", SqlDbType.NVarChar).Value = FrombytestoMB(Val(FileSize))
                .Parameters.Add("@date_1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                '.Parameters.Add("@Deleted", SqlDbType.Bit).Value = False
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
            Dim FilePath As String = Me.LabFileName.Text
            File.Copy(FilePath, Fol & Me.TextFileName.Text, True)
            MessageBox.Show("تم حفظ المعاملة بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TEXTFileSubject.Text = ""
            Me.TextTransactionNumber.Text = ""
            Me.TextFileDescription.Text = ""
            Me.TextFileNo.Text = ""
            Me.PictureBox1.Image = Nothing
            Pp5()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Consum.Close()
        End Try
    End Sub

    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub

    Public Sub FormDOCUMENTS_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        If Not Directory.Exists(Fol) Then
            Directory.CreateDirectory(Fol)
        End If
        Me.PanelImage.Visible = True
        Me.PanelImage.BringToFront()
        Me.PictureBox1.AllowDrop = True
        Me.FillcombByScanners()
    End Sub

    Public Sub DanLOd()
        On Error Resume Next
        If Me.BUD = False Then
            Me.CircularProgress1.Visible = True
            Me.CircularProgress2.Visible = False
            Me.CircularProgress3.Visible = False
            Me.CircularProgress4.Visible = False
            Me.CircularProgress1.Value = 0
            Me.BackgroundWorker1.WorkerSupportsCancellation = True
            Me.BackgroundWorker1.WorkerReportsProgress = True
            Me.BackgroundWorker1.RunWorkerAsync()
            Me.CircularProgress1.IsRunning = True
        End If
    End Sub

<<<<<<< HEAD
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If Me.BUD = False Then
            Try
                Dim Consum As New SqlConnection(constring)
=======
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If Me.BUD = False Then
            Try
                Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                'ds = New DataSet
                Dim sql As String = "SELECT DOC1 ,LO ,DOC2 ,DOC3 ,DOC4,DOC5,DOC6,date_1 FROM DOCUMENTS WHERE  CUser='" & ModuleGeneral.CUser & "'and LO ='" & Me.TextTransactionNumber.Text & "'OR DOC2 ='" & Trim(Me.TextFileNo.Text) & "'OR DOC4 ='" & Trim(Me.TEXTFileSubject.Text) & "'OR DOC5 ='" & Trim(Me.TextFileDescription.Text) & "'ORDER BY DOC1"
                '                                                                                     WHERE  CUser='" & ModuleGeneral.CUser & "'and LO ='" & Me.t2.Text & "'OR DOC2 ='" & Trim(Me.t2.Text) & "'OR DOC4 ='" & Trim(Me.t1.Text) & "'OR DOC5 ='" & Trim(Me.t3.Text) & "'ORDER BY DOC1"
                Dim cmd As New SqlCommand(sql, Consum)
                Dim da As New SqlDataAdapter(cmd)
                'ds.Clear()
                dt = New DataTable
                da.Fill(dt)
            Catch ex As Exception
                MsgBox(ex.Message)
                Consum.Close()
            End Try
        End If
    End Sub

<<<<<<< HEAD
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'Me.CircularProgress1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
=======
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'Me.CircularProgress1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            'Me.BS.DataSource = dt.TableName("DOCUMENTS")
            'Me.RowCount = Me.BS.Count
            Me.dgv1.DataSource = dt
            Me.dgv1.Columns.Item(0).Visible = False
            Me.dgv1.Columns.Item(6).Visible = False
            Me.dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            Me.dgv1.Columns(0).HeaderText = "الرقم"
            Me.dgv1.Columns(1).HeaderText = "رقم المعاملة"
            Me.dgv1.Columns(2).HeaderText = "رقم الملف"
            Me.dgv1.Columns(3).HeaderText = "نوع الملف"
            Me.dgv1.Columns(4).HeaderText = "موضوع المعاملة"
            Me.dgv1.Columns(5).HeaderText = "بيان المعاملة"
            Me.dgv1.Columns(7).HeaderText = "تاريخ المعاملة"
            Me.dgv1.Columns(0).Width = 60
            Me.dgv1.Columns(1).Width = 85
            Me.dgv1.Columns(2).Width = 85
            Me.dgv1.Columns(3).Width = 100
            Me.dgv1.Columns(4).Width = 100
            Me.dgv1.Columns(5).Width = 300
            'Me.Panel4.Enabled = True
            'Me.Panel9.Enabled = True
            Me.SHOWBUTTON()
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False

            dtSource = dt
            pageSize = 6
            maxRec = dtSource.Rows.Count
            PageCount = maxRec \ pageSize
            If (maxRec Mod pageSize) > 0 Then
                PageCount += 1
            End If
            currentPage = 1
            recNo = 0
            LoadPage()
            Me.CircularProgress1.IsRunning = False
            Me.CircularProgress1.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "الارشيف ")
        End Try
    End Sub

    Public Sub ADDBUTTON_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
        If Not Connection.TestNet Then
            Interaction.MsgBox("الاتصال بالانترنت غير متوفر", MsgBoxStyle.Critical, "تنبيه")
            Exit Sub
        End If
        Call MangUsers()

        If InternalAuditor = True Or Managers = True Or HeadofAuditingDepartment = True Or ExternalAuditor = True Then
            'MsgBox(1)
        Else
            If ModuleGeneral.LockAddRow = False Then
                Interaction.MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
        End If
        Dim Year As Integer = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
<<<<<<< HEAD
        GetAutoNumberMyDOCUMENTS()
        Dim NumberDOCUMENTS As Object = "DO" & Year & SEARCHDATA.NumberMyDocuments
        GetAutoNumberMyDOCUMENTSFL(NumberDOCUMENTS)
=======
        GetAutoNumberDOCUMENTS()
        Dim NumberDOCUMENTS As Object = "DO" & NoDocuments
        GetAutoNumberDOCUMENTSFL(NumberDOCUMENTS)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        Me.TEXTFileSubject.Text = "مرفقات الجمعية"
        Me.TextTransactionNumber.Text = NumberDOCUMENTS
        Me.TextFileDescription.Text = "ارفاق مستند جديد"
<<<<<<< HEAD
        Me.TextFileNo.Text = SEARCHDATA.NumberMyDOCUMENTSFL
=======
        Me.TextFileNo.Text = SEARCHDATA.NumberDOCUMENTSFL
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TextFileName.Text = "مستند جديد"
        Me.PictureBox1.Image = Nothing

        Me.TEXTFileSubject.Enabled = True
        Me.TextTransactionNumber.Enabled = True
        Me.TextFileDescription.Enabled = True
        Me.TextFileNo.Enabled = True

        Me.ADDBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = True
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Using Consum
            If Me.dgv1.SelectedRows.Count = 0 Then MessageBox.Show("يجب أختيار أسم المعاملة أولاً ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
            Dim msg As String = String.Format("{1}{0} هل أنت متأكد من حذف المعالمة بشكل نهائي ", Environment.NewLine, Me.dgv1(1, Me.dgv1.SelectedRows(0).Index).Value.ToString())
            If MessageBox.Show(msg, "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign) <> Windows.Forms.DialogResult.Yes Then Return
            Dim str As String = String.Format("Delete from [PD_T] where ID = {0}", dgv1(0, dgv1.SelectedRows(0).Index).Value.ToString())
            Dim cmd As New SqlCommand(str, Consum)
            If Consum.State = ConnectionState.Closed Then
                Consum.Open()
            End If
            cmd.ExecuteNonQuery()
            MessageBox.Show("تم حذف المعاملة بنجاح ", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Consum.Close()
            Pp5()
            Me.TEXTFileSubject.Text = ""
            Me.TextTransactionNumber.Text = ""
            Me.TextFileDescription.Text = ""
            Me.TextFileNo.Text = ""
            Me.PictureBox1.Image = Nothing
        End Using
    End Sub

    Private Sub Dgv1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles dgv1.Click
        Me.Se()
    End Sub

    Private Sub Dgv1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgv1.KeyDown
        Me.Se()
    End Sub

    Private Sub Dgv1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles dgv1.KeyPress
        Me.Se()
    End Sub

    Private Sub Dgv1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgv1.KeyUp
        Me.Se()
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
        Try
            If Me.TEXTFileSubject.Enabled = False Then
                Me.TEXTFileSubject.Enabled = True
                Me.TextTransactionNumber.Enabled = True
                Me.TextFileDescription.Enabled = True
                Me.TextFileNo.Enabled = True
                Return
            End If
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            If Me.TEXTFileSubject.Text = "" Or Me.TextTransactionNumber.Text = "" Or Me.TextFileNo.Text = "" Or Me.LabFileName.Text = "" Then MessageBox.Show("جميع الحقول مطلوبة ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
            ID = Me.dgv1(0, Me.dgv1.SelectedRows(0).Index).Value.ToString()
            Dim SQL As String = "Update DOCUMENTS SET  lo = @lo, DOC2 = @DOC2, DOC3 = @DOC3, DOC4 = @DOC4, DOC5 = @DOC5, DOC6 = @DOC6, DOC7 = @DOC7, DOC8 = @DOC8, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser,da = @da, ne = @ne WHERE DOC1 =" & Val(ID)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Me.TEXTFileSubject.Text = "" Or Me.TextTransactionNumber.Text = "" Or Me.TextFileNo.Text = "" Or Me.LabFileName.Text = "" Then MessageBox.Show("جميع الحقول مطلوبة ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
            ID = Me.dgv1(0, Me.dgv1.SelectedRows(0).Index).Value.ToString()
            Dim SQL As String = "Update DOCUMENTS SET  lo = @lo, DOC2 = @DOC2, DOC3 = @DOC3, DOC4 = @DOC4, DOC5 = @DOC5, DOC6 = @DOC6, DOC7 = @DOC7, DOC8 = @DOC8, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser,da = @da, ne = @ne WHERE DOC1 =" & Val(ID)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }

            If Me.DragDropA = True Then
                ShowMyFileInfo()
            Else
                If Me.LabFileName.Text.Length <= 0 Then
                    MessageBox.Show("يجب جلب الملف", Me.Text)
                    Exit Sub
                Else
                    Me.FileStream = New FileStream(Me.LabFileName.Text, FileMode.Open, FileAccess.Read)
                    Me.Reader = New BinaryReader(Me.FileStream)
                    Me.FileData = Nothing
                    Me.FileData = Me.Reader.ReadBytes(CInt(Me.FileStream.Length))
                    Me.FileSize = Me.FileData.Length
                    Me.FileStream.Close()
                End If
            End If

            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@lo", SqlDbType.NVarChar).Value = Me.TextTransactionNumber.Text.Trim
                .Parameters.Add("@DOC2", SqlDbType.NVarChar).Value = Me.TextFileNo.Text.Trim
                .Parameters.Add("@DOC3", SqlDbType.NVarChar).Value = Me.LabFileType.Text.Trim
                .Parameters.Add("@DOC4", SqlDbType.NVarChar).Value = Me.TEXTFileSubject.Text.Trim
                .Parameters.Add("@DOC5", SqlDbType.NVarChar).Value = Me.TextFileDescription.Text.Trim
                .Parameters.Add("@DOC6", SqlDbType.Image).Value = File.ReadAllBytes(Me.LabFileName.Text)
                .Parameters.Add("@DOC7", SqlDbType.NVarChar).Value = FileInfo
                .Parameters.Add("@DOC8", SqlDbType.NVarChar).Value = FrombytestoMB(Val(Me.FileSize))
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
            File.Copy(Me.LabFileName.Text, Me.Fol & Me.TextFileName.Text, True)
            MessageBox.Show("تم تعديل المعاملة بنجاح ", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Pp5()
            Me.TEXTFileSubject.Text = ""
            Me.TextTransactionNumber.Text = ""
            Me.TextFileNo.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Ts_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.PictureBox2.Visible = False
    End Sub

    Private Sub Ts_Validated(ByVal sender As Object, ByVal e As EventArgs)
        Me.PictureBox2.Visible = True
    End Sub

    Public Sub Cty()
        Me.dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue
        Me.dgv1.Columns(0).Width = 60
        Me.dgv1.Columns(0).Width = 60
        Me.dgv1.Columns(1).Width = 85
        Me.dgv1.Columns(2).Width = 85
        Me.dgv1.Columns(3).Width = 100
        Me.dgv1.Columns(4).Width = 100
        Me.dgv1.Columns(5).Width = 300
    End Sub

    Public Sub Pp5()
        Me.CircularProgress1.Visible = False
        Me.CircularProgress2.Visible = False
        Me.CircularProgress3.Visible = False
        Me.CircularProgress4.Visible = False
        Me.CircularProgress5.Visible = True
        Me.CircularProgress5.Value = 0
        Me.BackgroundWorker5.WorkerSupportsCancellation = True
        Me.BackgroundWorker5.WorkerReportsProgress = True
        Me.BackgroundWorker5.RunWorkerAsync()
        Me.CircularProgress5.IsRunning = True

    End Sub

<<<<<<< HEAD
    Private Sub BackgroundWorker5_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker5.DoWork
        Try
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub BackgroundWorker5_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker5.DoWork
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim sql As String = "SELECT DOC1 ,lo ,DOC2 ,DOC3 ,DOC4,DOC5,DOC6 FROM DOCUMENTS  WHERE DOC1 =" & Val(ID)
            Dim cmd As New SqlCommand(sql, Consum)
            Dim da As New SqlDataAdapter(cmd)
            dt2 = New DataTable
            da.Fill(dt2)
            Consum.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Consum.Close()
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub BackgroundWorker5_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker5.RunWorkerCompleted
=======
    Private Sub BackgroundWorker5_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker5.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.dgv1.DataSource = dt2
        Me.dgv1.Columns.Item(6).Visible = False
        Me.Cty()
        Me.LabFileName.Visible = False
        Me.LabFileSize.Visible = False
        Me.CircularProgress5.IsRunning = False
        Me.CircularProgress5.Visible = False
    End Sub

    Public Sub Ts_TextChanged()
        Me.CircularProgress1.Visible = False
        Me.CircularProgress2.Visible = True
        Me.CircularProgress3.Visible = False
        Me.CircularProgress4.Visible = False
        'Me.Panel4.Enabled = False
        'Me.Panel9.Enabled = False
        Me.CircularProgress2.Value = 0
        Me.BackgroundWorker2.WorkerSupportsCancellation = True
        Me.BackgroundWorker2.WorkerReportsProgress = True
        Me.BackgroundWorker2.RunWorkerAsync()
        Me.CircularProgress2.IsRunning = True
    End Sub

<<<<<<< HEAD
    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Me.BUD = True Then
                Try
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    Dim sql As String = "SELECT DOC1 ,LO ,DOC2 ,DOC3 ,DOC4,DOC5,DOC6,date_1 FROM DOCUMENTS WHERE  lo='" & XU & "'ORDER BY DOC1"
                    Dim cmd As New SqlCommand(sql, Consum)
                    Dim da1 As New SqlDataAdapter(cmd)
                    dt1 = New DataTable
                    da1.Fill(dt1)

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Consum.Close()
                End Try
                Consum.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "الارشيف ")
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub BackgroundWorker2_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        'Me.CircularProgress1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
=======
    Private Sub BackgroundWorker2_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        'Me.CircularProgress1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.dgv1.DataSource = dt1
        Me.dgv1.Columns.Item(0).Visible = False
        Me.dgv1.Columns.Item(6).Visible = False
        Me.dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue
        Me.dgv1.Columns(0).HeaderText = "الرقم"
        Me.dgv1.Columns(1).HeaderText = "رقم المعاملة"
        Me.dgv1.Columns(2).HeaderText = "رقم الملف"
        Me.dgv1.Columns(3).HeaderText = "نوع الملف"
        Me.dgv1.Columns(4).HeaderText = "موضوع المعاملة"
        Me.dgv1.Columns(5).HeaderText = "بيان المعاملة"
        Me.dgv1.Columns(7).HeaderText = "تاريخ المعاملة"
        Me.dgv1.Columns(0).Width = 60
        Me.dgv1.Columns(1).Width = 85
        Me.dgv1.Columns(2).Width = 85
        Me.dgv1.Columns(3).Width = 100
        Me.dgv1.Columns(4).Width = 100
        Me.dgv1.Columns(5).Width = 300
        Me.Cty()
        'Me.Panel4.Enabled = True
        'Me.Panel9.Enabled = True
        Me.SHOWBUTTON()
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        Me.CircularProgress2.IsRunning = False
        Me.CircularProgress2.Visible = False
    End Sub

    Private Sub ButLogq_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButLogq.Click
        op.Title = "اضافة الملفات"
        op.Filter = "All Files|*.*"
        If op.ShowDialog = DialogResult.Cancel Then
            Return
        End If
        'MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        'op.InitialDirectory = MYFOLDER & "\DOCUMENTS"
        'op.RestoreDirectory = True
        Me.LabFileName.Visible = True
        Me.LabFileSize.Visible = True
        Me.LabFileName.Text = op.FileName
        Me.FileName = System.IO.Path.GetFileNameWithoutExtension(op.FileName)
        Me.FileType = System.IO.Path.GetExtension(op.FileName).ToLower
        Me.FileInfo = GetFileDescription(op.FileName) ' Registryقراءة بينات الملف من 
        If FileType = ".pdf" Then FileInfo = "Adobe Acrobat PDF Files"
        If FileInfo = "" Then FileInfo = " "

        Me.LabFileType.Text = Me.FileType

        If Me.LabFileName.Text.Length <= 0 Then
            MessageBox.Show("يجب كتابة اسم للملف", Text)
            Return
        End If
        Try
<<<<<<< HEAD
            FileStream = New FileStream(Me.LabFileName.Text, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Reader = New BinaryReader(FileStream) ' تعريف القارئ
=======
            FileStream = New System.IO.FileStream(Me.LabFileName.Text, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Reader = New System.IO.BinaryReader(FileStream) ' تعريف القارئ
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            FileData = Nothing 'تفريغ البيانات
            FileData = Reader.ReadBytes(CType(FileStream.Length, Integer)) 'قراءة الملف
            FileSize = FileData.LongLength 'حجم الملف
            Me.LabFileSize.Text = FrombytestoMB(FileSize).ToString.Trim
            FileStream.Close()
            Pathf = op.FileName.ToLower 'اسم الملف
            Me.LabFileName.Text = op.FileName
            Me.TextFileName.Text = Path.GetFileName(op.FileName)

        Catch ex As Exception
            MessageBox.Show(Err.Description, "خطأ في جلب الملف")
        Finally
            MessageBox.Show("تم جلب الملف", "File ( Load )", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
        Try
            Me.LabFileName.Text = op.FileName
            If Me.LabFileName.Text = Nothing Then
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButShowFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButShowFile.Click
        Me.BackgroundWorker3.WorkerSupportsCancellation = True
        Me.BackgroundWorker3.WorkerReportsProgress = True
        Me.BackgroundWorker3.RunWorkerAsync()
        Me.CircularProgress3.IsRunning = True
        'Me.dgv1.Enabled = False
    End Sub

    Private Sub SAVEBUTTON_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
        Me.Cursor = Cursors.WaitCursor
        Me.INS_PDF()
        Me.Cursor = Cursors.Default
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
    End Sub

    Public Sub Se()
        Me.CircularProgress4.Visible = True
        Me.CircularProgress4.Value = 0
        Me.dgv1.Enabled = False
        Me.BackgroundWorker4.WorkerSupportsCancellation = True
        Me.BackgroundWorker4.WorkerReportsProgress = True
        Me.BackgroundWorker4.RunWorkerAsync()
        Me.CircularProgress4.IsRunning = True
    End Sub

<<<<<<< HEAD
    Private Sub BackgroundWorker4_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker4.DoWork
=======
    Private Sub BackgroundWorker4_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker4.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Me.dgv1.SelectedRows.Count = 0 Then MessageBox.Show("يجب أختيار المعاملة المطلوبة ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        Dim indx As Integer = dgv1.SelectedRows(0).Index
        Me.TEXTFileSubject.Text = Me.dgv1(4, indx).Value.ToString
        Me.TextTransactionNumber.Text = Me.dgv1(1, indx).Value.ToString
        Me.TextFileDescription.Text = Me.dgv1(5, indx).Value.ToString
        Me.TextFileNo.Text = Me.dgv1(2, indx).Value.ToString
        ID = Me.dgv1(0, indx).Value.ToString
        LabFileType.Text = Me.dgv1(3, indx).Value.ToString

        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Me.dgv1(3, indx).Value = ".png" Or dgv1(3, indx).Value = ".jpg" Or Me.dgv1(3, indx).Value = ".gif" Or Me.dgv1(3, indx).Value = ".bmp" Then
                Me.ButShowFile.Image = Me.ImageList1.Images(0)
                'Me.ButShowFile.BackColor = Color.Black
                'Me.ButShowFile.ForeColor = Color.Yellow
                Me.ButShowFile.Text = "عرض Images"
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Dim reader As SqlDataReader
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("SELECT DOC6 FROM DOCUMENTS WHERE DOC1 = @id3", Consum)
                cmd.Parameters.Add(New SqlParameter("@id3", Me.dgv1.CurrentRow().Cells(0).Value))
                reader = cmd.ExecuteReader()
                reader.Read()
                Dim sw() As Byte = CType(reader("DOC6"), Byte())
                Dim ms As New MemoryStream(sw)
                Me.PictureBox1.Image = Image.FromStream(ms)
                reader.Close()
                Consum.Close()
            ElseIf Me.dgv1(3, indx).Value = ".docx" Then
                Me.ButShowFile.Image = Me.ImageList1.Images(1)
                'Me.ButShowFile.BackColor = Color.SteelBlue
                'Me.ButShowFile.ForeColor = Color.Yellow
                Me.ButShowFile.Text = "عرض Word"
                Me.PictureBox1.Image = Nothing
            ElseIf Me.dgv1(3, indx).Value = ".doc" Then
                Me.ButShowFile.Image = Me.ImageList1.Images(1)
                'Me.ButShowFile.BackColor = Color.SteelBlue
                'Me.ButShowFile.ForeColor = Color.Yellow
                Me.ButShowFile.Text = "عرض Word"
                Me.PictureBox1.Image = Nothing
            ElseIf Me.dgv1(3, indx).Value = ".pdf" Then
                Me.ButShowFile.Image = Me.ImageList1.Images(2)
                'Me.ButShowFile.BackColor = Color.Red
                'Me.ButShowFile.ForeColor = Color.Wheat
                Me.ButShowFile.Text = "عرض PDF"
                Me.PictureBox1.Image = Nothing
            ElseIf Me.dgv1(3, indx).Value = ".xlsx" Then
                Me.ButShowFile.Image = Me.ImageList1.Images(3)
                'Me.ButShowFile.BackColor = Color.DodgerBlue
                'Me.ButShowFile.ForeColor = Color.Yellow
                Me.ButShowFile.Text = "عرض Excel"
                Me.PictureBox1.Image = Nothing
            Else
                Me.ButShowFile.Image = Me.ImageList1.Images(4)
                'Me.ButShowFile.BackColor = Color.Black
                'Me.ButShowFile.ForeColor = Color.Wheat
                Me.ButShowFile.Text = "عرض FaiL"
            End If
            Consum.Close()
            'If String.IsNullOrWhiteSpace(MyFileInfo.Extension) Then
            '    Exit Sub
            'Else
            '    Me.PictureBox1.Image = Image.FromFile(FileName)
            '    Me.ShowMyFileInfo()
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "الارشيف ")
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub BackgroundWorker4_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker4.ProgressChanged

    End Sub

    Private Sub BackgroundWorker4_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker4.RunWorkerCompleted
=======
    Private Sub BackgroundWorker4_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker4.ProgressChanged

    End Sub

    Private Sub BackgroundWorker4_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker4.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.dgv1.Enabled = True
        Me.CircularProgress4.IsRunning = False
        Me.CircularProgress4.Visible = False
    End Sub

<<<<<<< HEAD
    Private Sub BackgroundWorker3_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        Me.dgv1.Enabled = False
        Me.ButShowFile.Enabled = False
        Dim indx As Integer = dgv1.SelectedRows(0).Index
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub BackgroundWorker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        Me.dgv1.Enabled = False
        Me.ButShowFile.Enabled = False
        Dim indx As Integer = dgv1.SelectedRows(0).Index
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim sql As String = "select  DOC2 ,  DOC3 ,   DOC6  from DOCUMENTS where DOC1=" & dgv1.CurrentRow().Cells(0).Value
        'Dim cmd As SqlCommand = New SqlCommand(sql, Consum)
<<<<<<< HEAD
        Dim da As New SqlDataAdapter(sql, Consum)
=======
        Dim da As New SqlClient.SqlDataAdapter(sql, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim dt As New DataTable
        da.Fill(dt)
        Consum.Close()
        MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        Dim StoredPath As String = MYFOLDER & "\Archived File\Temp"

        'MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA") & MYFOLDER & "\Archived File\Temp"
        If dgv1.RowCount > 0 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm), True, True, False)
            F_Data = CType(dt.Rows(0)(2), Byte())
            FPath = StoredPath & "\" & dt.Rows(0)(0).ToString() & dt.Rows(0)(1).ToString()
            Dim FFS As New FileStream(FPath, FileMode.Create, FileAccess.Write)
            FFS.Write(F_Data, 0, F_Data.Length)
            FFS.Close()
            ieProcess.StartInfo.FileName = FPath
            Dim TheIcon As Icon = IconFromFilePath(FPath)
            Me.ButShowFile.Image = TheIcon.ToBitmap
            Me.PicIcon.Image = TheIcon.ToBitmap
            ieProcess.Start()
            For i As Double = 0 To 100 Step 0.5
                lablCount.Text = i & " " & "%"
            Next
            SplashScreenManager.CloseForm(False)
            ieProcess.WaitForWindowHandleToClose(1000, 20000, 20000)
        Else
            MsgBox("الرجاء إضافة البيانات حتى تتمكن من فتح الملف المحدد")
        End If

    End Sub

<<<<<<< HEAD
    Private Sub BackgroundWorker3_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker3.ProgressChanged
        '   
    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
=======
    Private Sub BackgroundWorker3_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker3.ProgressChanged
        '   
    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            File.Delete(FPath)
            lablCount.Text = 0 & " " & "%"
            Me.dgv1.Enabled = True
            Me.ButShowFile.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PictureBox1.Click
=======
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim y As Integer = 490
        Dim x As Integer = (Me.Width - y)

        If DockStyl = False Then
            Me.PanelUp.Visible = False
            Me.PanelButtan.Visible = False
            DockStyl = True
            Me.PanelImage.BringToFront()
            Me.PanelImage.Dock = DockStyle.Fill
            Me.PictureBox1.Dock = DockStyle.Fill
        Else
            Me.PanelUp.Visible = True
            Me.PanelButtan.Visible = True
            DockStyl = False
            Me.PanelImage.Dock = DockStyle.None
            Me.PanelImage.Size = New Size(x, 261)
            Me.PanelImage.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
            Me.PictureBox1.Dock = DockStyle.Fill

            'Me.PictureBox1.Anchor = (AnchorStyles.Top AndAlso AnchorStyles.Bottom AndAlso AnchorStyles.Left AndAlso AnchorStyles.Right)
            '

        End If
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

<<<<<<< HEAD
    Private Sub ButScan_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButScan.Click
=======
    Private Sub ButScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButScan.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'On Error Resume Next
        'Dim f As FormScan2 = New FormScan2(AddressOf ShowImage)

        'f.TextBox1.Text = Val(ID)
        'f.Show()
        Try
            If Me.ComboScanners.Items Is Nothing Then FillcombByScanners()
            Me.BackWorker1.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ShowImage(ByVal image As Image)
        PictureBox1.Image = image
    End Sub

    Private Sub LoadPage()
        Dim i As Integer
        Dim startRec As Integer
        Dim endRec As Integer
        Dim dtTemp As DataTable
        dtTemp = dtSource.Clone
        If currentPage = PageCount Then
            endRec = maxRec
        Else
            endRec = pageSize * currentPage
        End If
        startRec = recNo
        If dtSource.Rows.Count > 0 Then
            For i = startRec To endRec - 1
                dtTemp.ImportRow(dtSource.Rows(i))
                recNo += 1
            Next
        End If
        dgv1.DataSource = dtTemp
        DisplayPageInfo()
    End Sub

    Private Sub DisplayPageInfo()
        txtDisplayPageNo.Text = "صفحة " & currentPage.ToString & "/ " & PageCount.ToString
    End Sub

    Private Function CheckFillButton() As Boolean
        If pageSize = 0 Then
            MessageBox.Show("ضبط حجم الصفحة، ثم انقر فوق ""ملء الشبكة"" زر!")
            CheckFillButton = False
        Else
            CheckFillButton = True
        End If
    End Function

<<<<<<< HEAD
    Private Sub BtnNextPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNextPage.Click
=======
    Private Sub BtnNextPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextPage.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Not CheckFillButton() Then Return
        currentPage -= 1
        If currentPage < 1 Then
            MessageBox.Show("أنت في الصفحة الأولى!")
            currentPage = 1
            Return
        Else
            recNo = pageSize * (currentPage - 1)
        End If
        LoadPage()
    End Sub

<<<<<<< HEAD
    Private Sub BtnPreviousPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnPreviousPage.Click
=======
    Private Sub BtnPreviousPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviousPage.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Not CheckFillButton() Then Return
        If pageSize = 0 Then
            MessageBox.Show("ضبط حجم الصفحة، ثم انقر فوق ""ملء الشبكة"" زر!")
            Return
        End If
        currentPage += 1
        If currentPage > PageCount Then
            currentPage = PageCount
            If recNo = maxRec Then
                MessageBox.Show("أنت في الصفحة الأولى!")
                Return
            End If
        End If
        LoadPage()
    End Sub

<<<<<<< HEAD
    Private Sub BtnFirstPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnFirstPage.Click
=======
    Private Sub BtnFirstPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirstPage.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Not CheckFillButton() Then Return
        If recNo = maxRec Then
            MessageBox.Show("أنت في الصفحة الأخيرة!")
            Return
        End If
        currentPage = PageCount
        recNo = pageSize * (currentPage - 1)
        LoadPage()
    End Sub

<<<<<<< HEAD
    Private Sub BtnLastPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnLastPage.Click
=======
    Private Sub BtnLastPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLastPage.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Not CheckFillButton() Then Return
        If currentPage = 1 Then
            MessageBox.Show("أنت في الصفحة الأولى!")
            Return
        End If
        currentPage = 1
        recNo = 0
        LoadPage()
    End Sub

    Private Sub Butrotolaeft_Click(sender As Object, e As EventArgs) Handles Butrotolaeft.Click
        Rotatlaft(Me.PictureBox1)
    End Sub

    Private Sub Butrotorait_Click(sender As Object, e As EventArgs) Handles Butrotorait.Click
        Rotatraeit(Me.PictureBox1)
    End Sub

    Private Sub PictureBox1_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox1.DragDrop
        Dim FileName As String = e.Data.GetData(DataFormats.FileDrop)(0)
        Me.MyFileInfo = New FileInfo(FileName)
        If String.IsNullOrWhiteSpace(MyFileInfo.Extension) Then Exit Sub
        Me.PictureBox1.Image = Image.FromFile(FileName)
        Me.Panel5.Visible = True
        Me.LabFileName.Visible = True
        Me.LabFileSize.Visible = True
        Me.ShowMyFileInfo()
        Me.dgv1.Enabled = False
    End Sub

    Private Sub PictureBox1_DragEnter(sender As Object, e As DragEventArgs) Handles PictureBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
            Me.DragDropA = True
        End If
    End Sub

    Private Sub ShowMyFileInfo()

        Me.LabFileName.Text = Me.MyFileInfo.FullName
        Me.TextFileName.Text = Path.GetFileName(Me.LabFileName.Text)

        Me.FileSize = Me.MyFileInfo.Length
        Me.FileType = Me.MyFileInfo.Extension
        Me.FileInfo = GetFileDescription(Me.MyFileInfo.FullName)
        Me.FileName = Me.MyFileInfo.Name

        Me.LabFileSize.Text = ModuleGeneral.FrombytestoMB(CInt(Math.Round(Me.FileSize)))
        Me.LabFileType.Text = Me.FileType
        Me.LabFileInfo.Text = Me.FileInfo

        'Me.PictureBox1.Image = Icon.ExtractAssociatedIcon(Me.MyFileInfo.FullName).ToBitmap
    End Sub

    Private Sub FormDOCUMENTS_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Try
            Select Case e.KeyCode
                Case Keys.Escape
                    Me.DragDropA = False
                    Me.MyFileInfo = Nothing
                    Me.LabFileName.Text = Nothing
                    Me.LabFileInfo.Text = Nothing
                    Me.LabFileType.Text = Nothing
                    Me.LabFileSize.Text = Nothing
                    Me.dgv1.Enabled = True
                    Me.Se()
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ClerPictureBox()
        PictureBox1.Image = Nothing
    End Sub

    Private Sub DeletTempFile()
        Thread.Sleep(1000)
        MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        DeletDirectory("MYFOLDER\Archived File\Temp")
    End Sub

    Private Sub FormDOCUMENTS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim Thr1 As New Thread(AddressOf ClerPictureBox)
        Thr1.Start()
        Dim Thr2 As New Thread(AddressOf DeletTempFile)
        Thr2.Start()
        Thr1.Join()
    End Sub
End Class
