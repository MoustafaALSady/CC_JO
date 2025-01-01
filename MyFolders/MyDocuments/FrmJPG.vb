'Imports System.Data.OleDb
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports ALquhaliLibrary
Imports Microsoft.Win32
Imports WIA

Public Class FrmJPG
    Public WithEvents BS As New BindingSource
    Public SqlDataAdapter1 As New SqlDataAdapter
    Public ds As New DataSet
    Dim RowCount As Integer = 0
    Public ID As Integer
    Private FileStream As FileStream
    Private Reader As BinaryReader
    Private FileData As Byte()
    Private FileType As String
    Private ReadOnly FileType1 As String
    Private FileName As String
    Private FileSize As Double
    Private FileInfo As String
    Private Pathf As String
    Private MyPath As String
    Private ReadOnly Fol As String
    Public PHOTO As Boolean = False
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
                MessageBox.Show("„‰ ›÷·ﬂ  «ﬂœ „‰ ÊÃœ „«”Õ ÷Ê∆Ì „ ’· »ÃÂ«“", "—”«·…  ‰»Ì…")
                Return
            ElseIf String.IsNullOrEmpty(ImgeName) Then
                MessageBox.Show("„‰ ›÷·ﬂ ≈œŒ· «”„ ··’Ê—… «·„—«œ „”ÕÂ« „‰ Œ·«· ≈⁄œ«œ«  «·„”Õ «·÷Ê∆Ì", "—”«·…  ‰»Ì…")
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
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Threading.Thread.Sleep(100)
        MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        If Not IO.Directory.Exists(MYFOLDER & "\FailImag") Then Directory.CreateDirectory(MYFOLDER & "\FolderImageName")
        Dim FolderImageName As String = MYFOLDER & "\FolderImageName"
        STarScannering(Me.ComboScanners, FolderImageName, ImageName, FileType1, Me.PictureBox1)
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        TryScanner()
    End Sub
    Private Sub SHOWPHOTO()
        On Error Resume Next
        Dim Consum As New SqlConnection(ModuleGeneral.constring)
        Dim sql As String = "SELECT DOC6 FROM MYDOCUMENTSHOME WHERE DOC1 = @id3 OR LO ='" & Trim(Me.TextTransactionNumber.Text) & "'"
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim reader As SqlDataReader
        Dim cmd As New SqlCommand(sql, Consum)
        cmd.Parameters.Add(New SqlParameter("@id3", Me.TEXTBOX1.Text))
        reader = cmd.ExecuteReader()
        reader.Read()
        Dim sw() As Byte = CType(reader("DOC6"), Byte())
        Dim ms As New MemoryStream(sw)
        PictureBox1.Image = Image.FromStream(ms)
        reader.Close()
        Consum.Close()
        'Dim b() As Byte = CType(Reader("DOC6"), Byte())
        'b = cmd.ExecuteScalar()
        'If (b.Length > 0) Then
        '    Dim stream As New MemoryStream(b, True)
        '    stream.Write(b, 0, b.Length)
        '    Me.PictureBox1.Image = Image.FromStream(stream)
        '    stream.Close()
        'Else
        '    Me.PictureBox1.Image = Nothing
        'End If
        'Consum.Close()
    End Sub
    Private Sub SHOWPHOTO1()
        On Error Resume Next
        Dim Consum As New SqlConnection(ModuleGeneral.constring)
        Dim sql As String = "SELECT DOC6 FROM MYDOCUMENTSHOME WHERE DOC1 = @id3 and LO ='" & Trim(Me.TextTransactionNumber.Text) & "'"
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim reader As SqlDataReader
        Dim cmd As New SqlCommand(sql, Consum)
        cmd.Parameters.Add(New SqlParameter("@id3", Me.TEXTBOX1.Text))
        reader = cmd.ExecuteReader()
        reader.Read()
        Dim sw() As Byte = CType(reader("DOC6"), Byte())
        Dim ms As New MemoryStream(sw)
        PictureBox1.Image = Image.FromStream(ms)
        reader.Close()
        Consum.Close()
        'Dim b() As Byte = CType(Reader("DOC6"), Byte())
        'b = cmd.ExecuteScalar()
        'If (b.Length > 0) Then
        '    Dim stream As New MemoryStream(b, True)
        '    stream.Write(b, 0, b.Length)
        '    Me.PictureBox1.Image = Image.FromStream(stream)
        '    stream.Close()
        'Else
        '    Me.PictureBox1.Image = Nothing
        'End If
        'Consum.Close()
    End Sub
    Private Sub SHOWPHOTOSELECT()
        On Error Resume Next
        Me.PictureBox1.Image = Image.FromFile(SCANFILE)
    End Sub
    Private Sub MAXRECORD()
        On Error Resume Next
        Dim Consum As New SqlConnection(ModuleGeneral.constring)
        Dim SQL As String = "SELECT MAX(DOC1) FROM MYDOCUMENTSHOME"
        Dim CMD As New SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        If IsDBNull(resualt) Then
            Me.TEXTBOX1.Text = 1
        Else
            Me.TEXTBOX1.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub
    Private Sub DISPLAYRECORD()
        On Error Resume Next
        With Me
            '.TextBox6.Text = Format(Val(ds.Tables("MYDOCUMENTSHOME").Rows(Me.BS.Position)("DOC7").ToString), "0.000")
            .TEXTBOX1.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("DOC1").ToString
            .TextTransactionNumber.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("LO").ToString
            .TEXTFileNo.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("DOC2").ToString
            .LabFileType.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("DOC3").ToString
            .TEXTFileSubject.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("DOC4").ToString
            .TextFileDescription.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("DOC5").ToString
            .TextFileInfo.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("DOC7").ToString
            .LabFileSize.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("DOC8").ToString
            .DateP1.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("date_1").ToString
            .TEXTUserName.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("USERNAME").ToString
            .TEXTReferenceName.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("CUser").ToString
            .TextDefinitionDirectorate.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("COUser").ToString
            .TEXTAddDate.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("da").ToString
            .TextTimeAdd.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("ne").ToString
            .TEXTReviewDate.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("da1").ToString
            .TextreviewTime.Text = Me.ds.Tables.Item("MYDOCUMENTSHOME").Rows.Item(Me.BS.Position).Item("ne1").ToString
            .PictureBox1.DataBindings.Clear()
            .SHOWPHOTO()
        End With
    End Sub
    Private Sub UPDATERECORD()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As String = " Update MYDOCUMENTSHOME SET   DOC2 = @DOC2, DOC3 = @DOC3, DOC4 = @DOC4, DOC5 = @DOC5, DOC7 = @DOC7 WHERE DOC1 = @DOC1"
        Dim CMD As New SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@DOC1", SqlDbType.Int).Value = Me.TEXTBOX1.Text.Trim
            .Parameters.Add("@DOC2", SqlDbType.NVarChar).Value = Me.TEXTFileNo.Text.Trim
            .Parameters.Add("@DOC3", SqlDbType.NVarChar).Value = Me.LabFileType.Text.Trim
            .Parameters.Add("@DOC4", SqlDbType.NVarChar).Value = Me.TEXTFileSubject.Text.Trim
            .Parameters.Add("@DOC5", SqlDbType.NVarChar).Value = Me.TextFileDescription.Text.Trim
            .Parameters.Add("@DOC7", SqlDbType.NVarChar).Value = Me.TextFileInfo.Text.Trim
            .CommandText = SQL
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        CMD.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub FrmJPG_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        Me.Dispose()
        'Form_Scanner.Close()
    End Sub
    Private Sub FrmJPG_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F3
                    Me.EDITBUTTON_Click(sender, e)
                Case Keys.F4
                    Me.BUTTONCANCEL_Click(sender, e)
                Case Keys.F5
                    Me.PRINTBUTTON_Click(sender, e)
                Case Keys.F7
                    Me.ButScan_Click(sender, e)
                Case Keys.F8
                    Me.ButSaveFile_Click(sender, e)
                Case Keys.F9
                    Me.ButLogq_Click(sender, e)
                Case Keys.F10
                    Me.ButEditImage_Click(sender, e)
                Case Keys.R And (e.Alt And Not e.Control And Not e.Shift)
                    Me.ButtonXP5_Click(sender, e)

                Case Keys.PageDown
                    Me.PREVIOUSBUTTON_Click(sender, e)
                Case Keys.PageUp
                    Me.NEXTBUTTON_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PictureBox1.Click
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
    Private Sub BackWorker2_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackWorker2.DoWork
        Try
            'If Not File.Exists("C:\WINDOWS\system32\TWAIN32d.dll") Then
            '    File.Copy((Application.StartupPath & "\TWAIN32d.dll"), "C:\WINDOWS\system32\TWAIN32d.dll")
            'End If
            ModuleGeneral.MYFOLDER = ModuleGeneral.mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            If Not Directory.Exists(ModuleGeneral.MYFOLDER & "\Photos") Then
                Directory.CreateDirectory(ModuleGeneral.MYFOLDER & "\Photos")
            End If
            Me.ds.EnforceConstraints = False
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  DOC1, LO, DOC2, DOC3, DOC4, DOC5, DOC6, DOC7, DOC8, date_1, USERNAME, CUser, COUser, da, ne, da1, ne1  FROM MYDOCUMENTSHOME WHERE  CUser='" & ModuleGeneral.CUser & "'and DOC1 ='" & Me.TEXTBOX1.Text & "'OR LO ='" & Trim(Me.TextTransactionNumber.Text) & "'OR DOC2 ='" & Trim(Me.TEXTFileNo.Text) & "'ORDER BY DOC1"
            End With
            SqlDataAdapter1 = New SqlDataAdapter(strSQL)
            Me.ds = New DataSet
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.ds, "MYDOCUMENTSHOME")
            Consum.Close()
            Me.ds.RejectChanges()

        Catch exception1 As Exception
            MessageBox.Show(exception1.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub
    Private Sub BackWorker2_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackWorker2.ProgressChanged
        Me.PictureBox2.Visible = True
    End Sub
    Private Sub BackWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackWorker2.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = ds.Tables("MYDOCUMENTSHOME")
            Me.RowCount = Me.BS.Count
            Me.TEXTBOX1.DataBindings.Add("text", Me.BS, "DOC1", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.TextTransactionNumber.DataBindings.Add("text", Me.BS, "LO", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.TEXTFileNo.DataBindings.Add("text", Me.BS, "DOC2", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.LabFileType.DataBindings.Add("text", Me.BS, "DOC3", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.TEXTFileSubject.DataBindings.Add("text", Me.BS, "DOC4", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.TextFileDescription.DataBindings.Add("text", Me.BS, "DOC5", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.TextFileInfo.DataBindings.Add("text", Me.BS, "DOC7", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.LabFileSize.DataBindings.Add("text", Me.BS, "DOC8", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.DateP1.DataBindings.Add("text", Me.BS, "date_1", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "CUser", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "CoUser", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, DataSourceUpdateMode.OnPropertyChanged, "")
            Me.PictureBox1.DataBindings.Clear()
            Me.PictureBox2.Visible = False
            Me.RecordCount()
            'Me.SHOWPHOTO()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
        Me.BackWorker2 = New BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.BackWorker2.RunWorkerAsync()
    End Sub
    Public Sub FrmJPG_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        'If Me.PictureBox1.Dock = DockStyle.Fill Then
        Me.PanelImage.Visible = True
        Me.PanelImage.BringToFront()
        Me.LabFileName.Text = ""
        Me.PictureBox1.AllowDrop = True
        Me.FillcombByScanners()
        'End If
        'If Not IO.File.Exists("C:\WINDOWS\system32\TWAIN32d.dll") Then
        '    File.Copy(Application.StartupPath & "\TWAIN32d.dll", "C:\WINDOWS\system32\TWAIN32d.dll")
        'End If
        'Module1.MYFOLDER = Module1.mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        'If Not IO.Directory.Exists(MYFOLDER & "\Photos") Then
        '    Directory.CreateDirectory(MYFOLDER & "\Photos")
        'End If
        'constring = "Data Source=" + My.Computer.Name & "\SQLEXPRESS" + ";Initial Catalog=StoringDB;Integrated Security=SSPI;persist security info=False;"
        'Dim Consum As New SqlConnection(Module1.constring)
        'ds.EnforceConstraints = False
        'Consum.Open()
        'Dim str As String = "SELECT * FROM MYDOCUMENTSHOME"
        'SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
        'ds.Clear()
        'SqlDataAdapter1.Fill(ds, "MYDOCUMENTSHOME")
        'BS.DataMember = "MYDOCUMENTSHOME"
        'BS.DataSource = ds
        'RecordCount()
        'ds.EnforceConstraints = True
        'FILLCOMBOBOX("MYDOCUMENTSHOME", "DOC3", Me.TEXTBOX3)
        'SqlDataAdapter1.Dispose()
        'Consum.Close()
        'Me.SHOWBUTTON()
        DockStyl = True
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.ButSaveFile.Enabled = LockUpdate
        Me.ButEditImage.Enabled = LockUpdate
    End Sub
    Public Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " „‰ " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.ds.Tables("MYDOCUMENTSHOME").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        If Me.PHOTO = True Then
            Me.SHOWPHOTO1()
        Else
            Me.SHOWPHOTO()
        End If
    End Sub
    Private Function PicToByte(ByVal f As String) As Byte()
        On Error Resume Next
        Dim fs As New FileStream(f, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs)
        Return br.ReadBytes(Convert.ToInt32(br.BaseStream.Length))
    End Function

    Shared Function GetFileDescription(ByVal filePath As String) As String
        Dim regKey As RegistryKey = Nothing
        Try
            regKey = Registry.ClassesRoot.OpenSubKey(New FileInfo(filePath).Extension)
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
    Private Sub ButLogq_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButLogq.Click
        'On Error Resume Next
        'OpenFileDialog1.Filter = "Bitmap file (*.bmp)|*.bmp|TIFF file (*.tif)|*.tif|JPEG file (*.jpg)|*.jpg|PNG file (*.png)|*.png|GIF file (*.gif)|*.gif|All files (*.*)|*.*"
        'With Me.OpenFileDialog1
        '    .FilterIndex = 5
        '    .Title = "«Œ Ì«— ’Ê—…"
        '     Module1.MYFOLDER = Conversions.ToString(Module1.mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA"))
        '    .InitialDirectory = MYFOLDER & "\Photos"
        '    .ShowDialog()
        '    If Len(.FileName) > 0 Then
        '        SCANFILE = OpenFileDialog1.FileName
        '        Me.PictureBox1.Image = Image.FromFile(SCANFILE)
        '    Else
        '        SCANFILE = ""
        '        Me.PictureBox1.Image = Nothing
        '        Exit Sub
        '    End If
        'End With

        Me.OpenFileDialog1.Title = "«÷«›… «·„·›« "
        Me.OpenFileDialog1.Filter = "All Files|*.*"
        If Me.OpenFileDialog1.ShowDialog <> DialogResult.Cancel Then
            Me.LabFileName.Visible = True
            Me.LabFileSize.Visible = True
            Me.LabFileName.Text = Me.OpenFileDialog1.FileName
            Me.FileName = Path.GetFileNameWithoutExtension(Me.OpenFileDialog1.FileName)
            Me.FileType = Path.GetExtension(Me.OpenFileDialog1.FileName).ToLower
            Me.FileInfo = GetFileDescription(Me.OpenFileDialog1.FileName)
            If Me.FileType = ".pdf" Then
                Me.FileInfo = "Adobe Acrobat PDF Files"
            End If
            If Me.FileInfo = "" Then
                Me.FileInfo = " "
            End If
            Me.LabFileType.Text = Me.FileType
            Me.TextFileInfo.Text = Me.FileInfo
            If Me.LabFileName.Text.Length <= 0 Then
                MessageBox.Show("ÌÃ» ﬂ «»… «”„ ··„·›", Me.Text)
            Else
                Try
                    Me.FileStream = New FileStream(Me.LabFileName.Text, FileMode.Open, FileAccess.Read)
                    Me.Reader = New BinaryReader(Me.FileStream)
                    Me.FileData = Nothing
                    Me.FileData = Me.Reader.ReadBytes(CInt(Me.FileStream.Length))
                    Me.FileSize = Me.FileData.Length
                    Me.LabFileSize.Text = ModuleGeneral.FrombytestoMB(CInt(Math.Round(Me.FileSize)))
                    Me.FileStream.Close()
                    Me.Pathf = Me.OpenFileDialog1.FileName.ToLower
                    Me.LabFileName.Text = Me.OpenFileDialog1.FileName
                    If Strings.Len(Me.OpenFileDialog1.FileName) > 0 Then
                        ModuleGeneral.SCANFILE = Me.OpenFileDialog1.FileName
                        Me.PictureBox1.Image = Image.FromFile(ModuleGeneral.SCANFILE)
                    Else
                        ModuleGeneral.SCANFILE = ""
                        Me.PictureBox1.Image = Nothing
                        Return
                    End If
                Catch ex As Exception
                    MessageBox.Show(Information.Err.Description, "Œÿ√ ›Ì Ã·» «·„·›")
                Finally
                    MessageBox.Show(" „ Ã·» «·„·›", "File ( Load )", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End Try

                Me.LabFileName.Text = Me.OpenFileDialog1.FileName
                If Me.LabFileName.Text = Nothing Then
                End If
            End If
        End If
    End Sub
    Public Sub PHOTOEDIT()
        On Error Resume Next
        Dim Consum As New SqlConnection(ModuleGeneral.constring)
        Dim SQL As String = " Update MYDOCUMENTSHOME SET  DOC6 = @DOC6 WHERE DOC1 = @DOC1"
        Dim CMD As New SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        Dim fs As New FileStream(SCANFILE, FileMode.Open, FileAccess.Read)
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
        SCANFILE = ""
    End Sub
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FIRSTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PREVIOUSBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Position - 1
        Me.RecordCount()
    End Sub
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NEXTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Position + 1
        Me.RecordCount()
    End Sub
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
        Try

            If Not TestNet Then
                Interaction.MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", MsgBoxStyle.Critical, " ‰»ÌÂ")
                Exit Sub
            End If
            If Not ModuleGeneral.LockUpdate Then
                Interaction.MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", MsgBoxStyle.Critical, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.EDITBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.ButScan.Enabled = True
            Me.ButSaveFile.Enabled = True
            Me.ButLogq.Enabled = True
            Me.ButEditImage.Enabled = True



            Me.ID = CInt(Math.Round(Conversion.Val(Me.TEXTBOX1.Text)))
            Dim connection As New SqlConnection(ModuleGeneral.constring)

            If Me.RadioSaveImage.Checked Then
                Dim str2 As String = "Update MYDOCUMENTSHOME SET  lo = @lo, DOC2 = @DOC2, DOC3 = @DOC3, DOC4 = @DOC4, DOC5 = @DOC5, DOC6 = @DOC6, DOC7 = @DOC7, DOC8 = @DOC8, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser,da = @da, ne = @ne, da1 = @da1, ne1 = @ne1  WHERE DOC1 =" & Conversion.Val(Me.ID)
                Dim command As New SqlCommand With {
                    .CommandType = CommandType.Text,
                    .Connection = connection
                }
                If Me.DragDropA = True Then
                    ShowMyFileInfo()
                Else
                    If Me.LabFileName.Text.Length <= 0 Then
                        MessageBox.Show("ÌÃ» Ã·» «·„·›", Me.Text)
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

                Dim command3 As SqlCommand = command
                command3.CommandType = CommandType.Text
                command3.Connection = connection
                command3.Parameters.Add("@LO", SqlDbType.NVarChar).Value = Me.TextTransactionNumber.Text.Trim
                command3.Parameters.Add("@DOC2", SqlDbType.Int).Value = Me.TEXTFileNo.Text.Trim
                command3.Parameters.Add("@DOC3", SqlDbType.NVarChar).Value = Me.LabFileType.Text.Trim
                command3.Parameters.Add("@DOC4", SqlDbType.NVarChar).Value = Me.TEXTFileSubject.Text.Trim
                command3.Parameters.Add("@DOC5", SqlDbType.NVarChar).Value = Me.TextFileDescription.Text.Trim
                command3.Parameters.Add("@DOC6", SqlDbType.Image).Value = File.ReadAllBytes(Me.LabFileName.Text)
                command3.Parameters.Add("@DOC7", SqlDbType.NVarChar).Value = Me.FileInfo
                command3.Parameters.Add("@DOC8", SqlDbType.NVarChar).Value = ModuleGeneral.FrombytestoMB(CInt(Math.Round(Conversion.Val(Me.FileSize))))
                command3.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                command3.Parameters.Add("@CUser", SqlDbType.NVarChar).Value = ModuleGeneral.CUser
                command3.Parameters.Add("@COUser", SqlDbType.NVarChar).Value = ModuleGeneral.COUser
                command3.Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                command3.Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                command3.Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                command3.Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                command3.CommandText = str2
                command3 = Nothing
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                File.Copy(Me.LabFileName.Text, Me.Fol & Me.TEXTBOX1.Text, True)
            ElseIf Me.RadioNotSaveImage.Checked Then
                Dim str3 As String = "Update MYDOCUMENTSHOME SET  lo = @lo, DOC2 = @DOC2, DOC4 = @DOC4, DOC5 = @DOC5, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser,da = @da, ne = @ne, da1 = @da1, ne1 = @ne1  WHERE DOC1 =" & Conversion.Val(Me.ID)
                Dim command2 As New SqlCommand With {
                    .CommandType = CommandType.Text,
                    .Connection = connection
                }
                Dim command4 As SqlCommand = command2
                command4.CommandType = CommandType.Text
                command4.Connection = connection
                command4.Parameters.Add("@LO", SqlDbType.NVarChar).Value = Me.TextTransactionNumber.Text.Trim
                command4.Parameters.Add("@DOC2", SqlDbType.Int).Value = Me.TEXTFileNo.Text.Trim
                command4.Parameters.Add("@DOC4", SqlDbType.NVarChar).Value = Me.TEXTFileSubject.Text.Trim
                command4.Parameters.Add("@DOC5", SqlDbType.NVarChar).Value = Me.TextFileDescription.Text.Trim
                command4.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                command4.Parameters.Add("@CUser", SqlDbType.NVarChar).Value = ModuleGeneral.CUser
                command4.Parameters.Add("@COUser", SqlDbType.NVarChar).Value = ModuleGeneral.COUser
                command4.Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                command4.Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                command4.Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                command4.Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                command4.CommandText = str3
                command4 = Nothing
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
                connection.Open()
                command2.ExecuteNonQuery()
                connection.Close()
            End If
            MessageBox.Show(" „  ⁄œÌ· «·„⁄«„·… »‰Ã«Õ ", " „", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            connection.Close()
            Me.RecordCount()
            Insert_Actions(CInt(Me.TEXTBOX1.Text.Trim), " ⁄œÌ·", Me.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next

        Me.DragDropA = False
        Me.MyFileInfo = Nothing
        Me.LabFileName.Text = Nothing
        Me.LabFileInfo.Text = Nothing
        Me.LabFileType.Text = Nothing
        Me.LabFileSize.Text = Nothing
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
        MYDELETERECORD("MYDOCUMENTSHOME", "DOC1", Me.TEXTBOX1, Me.BS, True)
        FrmJPG_Load(sender, e)
        CLEARDATA1(Me)
        Me.PictureBox1.Image = Nothing
        RecordCount()
    End Sub
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
        On Error Resume Next
        Dim F As New FrmPRINT
        If Len(Me.TextFileDescription.Text) = 0 Then
            MessageBox.Show("„‰ ›÷·ﬂ «÷€ÿ “— «Œ Ì«— ’Ê—… À„ Õœœ «·„” ‰œ  «·–Ï  —Ìœ ÿ»«⁄ …", "ÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            'Me.ButLogq.Focus()
            Exit Sub
        End If

        Dim Consum As New SqlConnection(ModuleGeneral.constring)
        Dim sql As String = "SELECT DOC6 FROM MYDOCUMENTSHOME WHERE DOC1 = '" & Me.TEXTBOX1.Text & "'"
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim cmd As New SqlCommand(sql, Consum)
        Dim b() As Byte
        b = cmd.ExecuteScalar()
        If b.Length > 0 Then
            Dim stream As New MemoryStream(b, True)
            stream.Write(b, 0, b.Length)
            stream.Close()
        End If
        Dim rpt1 As New rptJPG
        GETSERVERNAMEANDDATABASENAME(rpt1, MYDATABASE1, "", "")
        Dim ds As New DsImage
        Dim dr As DsImage.MYDOCUMENTSHOMERow = ds.MYDOCUMENTSHOME.NewMYDOCUMENTSHOMERow
        dr.DOC1 = Me.TEXTBOX1.Text
        dr.DOC2 = Me.TEXTFileNo.Text
        dr.DOC3 = Me.LabFileType.Text
        dr.DOC4 = Me.TEXTFileSubject.Text
        dr.DOC5 = Me.TextFileDescription.Text
        dr.DOC6 = b
        ds.MYDOCUMENTSHOME.Rows.Add(dr)
        rpt1.SetDataSource(ds)
        F.CrystalReportViewer1.ReportSource = rpt1
        F.CrystalReportViewer1.Zoom(90%)
        F.CrystalReportViewer1.Refresh()
        F.Show()
        Consum.Close()
    End Sub

    Private Sub TEXTBOX1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTBOX1.KeyDown, TEXTFileNo.KeyDown, TEXTFileSubject.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub

    Private Sub ButScan_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButScan.Click
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
    Public Sub ButEditImage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButEditImage.Click
        On Error Resume Next
        Static P As Integer
        P = Me.BS.Position
        Me.PHOTOEDIT()
        Me.FrmJPG_Load(sender, e)
        Me.BS.Position = P
        Me.RecordCount()
    End Sub

    Public Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP5.Click
        Try
            If Not Connection.TestNet Then
                Interaction.MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", MsgBoxStyle.Critical, " ‰»ÌÂ")
            Else
                Me.FrmJPG_Load(sender, e)
            End If
            Me.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub



    Private Sub ButSaveFile_Click(sender As Object, e As EventArgs) Handles ButSaveFile.Click

        On Error Resume Next
        Dim bmap As Image
        Clipboard.SetImage(Me.PictureBox1.Image)
        bmap = Clipboard.GetImage
        SaveFileDialog1.Filter = "Bitmap file (*.bmp)|*.bmp|TIFF file (*.tif)|*.tif|JPEG file (*.jpg)|*.jpg|PNG file (*.png)|*.png|GIF file (*.gif)|*.gif|All files (*.*)|*.*"
        With Me.SaveFileDialog1
            .FilterIndex = 3
            .Title = "Õ›Ÿ „·›"
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
    Private Sub Butrotorait_Click(sender As Object, e As EventArgs) Handles Butrotorait.Click
        Rotatraeit(Me.PictureBox1)

    End Sub

    Private Sub Butrotolaeft_Click(sender As Object, e As EventArgs) Handles Butrotolaeft.Click
        Rotatlaft(Me.PictureBox1)
    End Sub

    Private Sub PictureBox1_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox1.DragDrop
        Dim FileName As String = e.Data.GetData(DataFormats.FileDrop)(0)
        MyFileInfo = New FileInfo(FileName)
        If String.IsNullOrWhiteSpace(MyFileInfo.Extension) Then Exit Sub
        Me.PictureBox1.Image = Image.FromFile(FileName)
        Me.ShowMyFileInfo()

        Me.FIRSTBUTTON.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
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

    Private Sub TextFileDescription_TextChanged(sender As Object, e As EventArgs) Handles TextFileDescription.TextChanged
        LabMaxCh.Text = "⁄œœ «·Õ—Ê› : " & (300 - TextFileDescription.Text.Length).ToString() & " " & "Õ—›"
        If TextFileDescription.Text.Length >= 300 Then
            MessageBox.Show("·« ÌÃ» «‰ ÌﬂÊ‰ ⁄œœ Õ—Ê› Õﬁ· Ê’› «·„·› «ﬂÀ— „‰" & " " & "(300)" & " " & "Õ—›", "„⁄·Ê„« ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            EDITBUTTON.Enabled = False
            Exit Sub
        Else
            EDITBUTTON.Enabled = True
        End If
    End Sub
End Class