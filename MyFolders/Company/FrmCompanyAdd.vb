Option Explicit Off

Imports System.Data.SqlClient
Imports System.IO

Public Class FrmCompanyAdd
<<<<<<< HEAD
    Inherits Form
=======
    Inherits System.Windows.Forms.Form
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Dim WithEvents BS As New BindingSource
    ReadOnly ds As New DataSet
    Private WithEvents SaveDataBase As System.ComponentModel.BackgroundWorker
    Dim A, B As String
    Dim flag As Boolean = False
    Dim flag1 As Boolean = False
    ReadOnly RowCount As Integer = 0

<<<<<<< HEAD
    Private Sub FrmCompany_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub FrmCompany_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.ADDBUTTON_Click(sender, e)
                Case Keys.F2
                    Me.SAVEBUTTON_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        'AutoComplete(Me.ComboBox2, e, )
    End Sub
    Private Sub FrmCompanyAdd_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'AutoComplete(Me.ComboBox2, e, )
    End Sub
    Private Sub FrmCompanyAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        A = "جمعية"
        B = "التعاونية"
    End Sub
    Private Sub SaveDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveDataBase.DoWork
        Try
1:
            'SqlDataAdapter1.Update(ds, "COMPANY")
            'ds = New DataSet
            'SqlDataAdapter1.Fill(ds, "COMPANY")
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveDataBase.RunWorkerCompleted
        Try
            Application.DoEvents()
            Me.BS.DataSource = ds.Tables("COMPANY")
<<<<<<< HEAD
            Me.TEXTCMP5.Enabled = True
=======
            Me.TEXTBOX5.Enabled = True
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            'If Me.BS.Count < Me.RowCount Then
            '    MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
            '    Exit Sub
            'ElseIf Me.BS.Count > Me.RowCount Then
            '    MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
            '    Exit Sub
            'End If
<<<<<<< HEAD
            Dim Sound As Stream = My.Resources.save
=======
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub
    Private Sub SHOWPHOTO()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim sql As String = "SELECT CMP7 FROM COMPANY WHERE cuser = '" & Me.TextCUser.Text & "'"
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim cmd As New SqlCommand(sql, Consum)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim sql As String = "SELECT CMP7 FROM COMPANY WHERE cuser = '" & Me.TEXTCMP1.Text & "'"
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim cmd As New SqlClient.SqlCommand(sql, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim b() As Byte
        b = cmd.ExecuteScalar()
        If b.Length > 0 Then
            Dim stream As New MemoryStream(b, True)
            stream.Write(b, 0, b.Length)
            Me.PictureBox1.Image = New Bitmap(stream)
            stream.Close()
        Else
            Me.PictureBox1.Image = Nothing
        End If
        Consum.Close()
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX1_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles TEXTCMP1.KeyDown
=======
    Private Sub TEXTBOX1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTCMP1.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub MAXRECORD()
<<<<<<< HEAD
        Try
            Dim N As Integer
            Using Consum As New SqlClient.SqlConnection(constring)
                Using cmd1 As New SqlClient.SqlCommand("SELECT ISNULL(MAX(CMP), 0) + 1 FROM COMPANY", Consum)
                    Consum.Open()
                    N = Convert.ToInt32(cmd1.ExecuteScalar())
                End Using
            End Using
            Me.TextCMP.Text = N.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MAXRECORD1()
        Try
            Using Consum As New SqlClient.SqlConnection(constring)
                Dim SQL As String = "SELECT MAX(cuser) FROM COMPANY"
                Using CMD As New SqlClient.SqlCommand(SQL, Consum)
                    Consum.Open()
                    Dim result As Object = CMD.ExecuteScalar()
                    If IsDBNull(result) Then
                        Me.TextCUser.Text = 1
                    Else
                        Me.TextCUser.Text = CType(result, Integer) + 1
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in MAXRECORD1", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LOGOBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LOGOBUTTON.Click
=======
        On Error Resume Next
        Dim N As Double
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CMP1) FROM COMPANY", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        If IsDBNull(resualt) Then
            N = 1
        Else
            N = CType(resualt, Integer) + 1
        End If
        Consum.Close()
        Me.TEXTCMP1.Text = Val(N)
    End Sub
    Private Sub MAXRECORD1()
        On Error Resume Next
        Dim V As Integer
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(cuser) FROM COMPANY", Consum)
        Dim CMD As New SqlClient.SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        If IsDBNull(resualt) Then
            Me.TextCUser.Text = 1
        Else
            Me.TextCUser.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub

    Private Sub LOGOBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOGOBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        OpenFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|AllFiles (*.*)|*.*"
        With Me.OpenFileDialog1
            .FilterIndex = 1
            .Title = "حدد شعار الجمعية"
            .ShowDialog()
            If Len(.FileName) > 0 Then
                Me.PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        End With
    End Sub
<<<<<<< HEAD
    Private Sub PHOTOEDIT_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PHOTOEDIT.Click
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As String = " Update COMPANY SET  CMP10 = @CMP10 WHERE cuser = @cuser"
        Dim CMD As New SqlCommand With {
=======
    Private Sub PHOTOEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PHOTOEDIT.Click
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As String = " Update COMPANY SET  CMP10 = @CMP10 WHERE cuser = @cuser"
        Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        Dim fs As New FileStream(OpenFileDialog1.FileName, FileMode.Open, FileAccess.Read)
        Dim r As New BinaryReader(fs)
        Dim FileByteArray(fs.Length - 1) As Byte
        r.Read(FileByteArray, 0, CInt(fs.Length))
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
<<<<<<< HEAD
            .Parameters.Add("@CMP1", SqlDbType.Int).Value = Me.TEXTCMP1.Text
=======
            .Parameters.Add("@CMP1", SqlDbType.Int).Value = Me.TEXTCMP1.Text.Trim
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .Parameters.Add("@CMP10", SqlDbType.Image).Value = FileByteArray
            .CommandText = SQL
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        CMD.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub SEARCHUSERS()
<<<<<<< HEAD
        Try
            Using Consum As New SqlClient.SqlConnection(constring)
                Dim strsq1 As New SqlCommand("SELECT CMP2 FROM COMPANY WHERE CMP2 = @CMP2", Consum)
                strsq1.Parameters.AddWithValue("@CMP2", Me.TEXTCMP2.Text)
                Dim ds As New DataSet
                Using Adp1 As New SqlClient.SqlDataAdapter(strsq1)
                    ds.Clear()
                    Adp1.Fill(ds, "COMPANY")
                End Using

                If ds.Tables(0).Rows.Count >= 1 Then
                    MessageBox.Show("تم تسجيل اسم الجمعية سابقاً", "تكرار بيانات جمعية", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    Me.TEXTCMP2.Text = Nothing
                    Me.TEXTCMP2.Focus()
                    flag = True
                    Me.SAVEBUTTON.Enabled = False
                Else
                    flag = False
                    Me.SAVEBUTTON.Enabled = True
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SEARCHUSERS1()
        Try
            Using Consum As New SqlClient.SqlConnection(constring)
                Dim strsq1 As New SqlCommand("SELECT CMP FROM COMPANY WHERE CMP = @CMP", Consum)
                strsq1.Parameters.AddWithValue("@CMP", Me.TextCMP.Text)

                Dim ds As New DataSet
                Using Adp1 As New SqlClient.SqlDataAdapter(strsq1)
                    ds.Clear()
                    Adp1.Fill(ds, "COMPANY")
                End Using

                If ds.Tables(0).Rows.Count >= 1 Then
                    MessageBox.Show("تم تسجيل رقم تسجيل الجمعية سابقاً", "تكرار بيانات جمعية", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    Me.TextCMP.Text = Nothing
                    Me.TextCMP.Focus()
                    flag1 = True
                    Me.SAVEBUTTON.Enabled = False
                Else
                    flag1 = False
                    Me.SAVEBUTTON.Enabled = True
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SAVERECORD()
        Try
            Using Consum As New SqlClient.SqlConnection(constring)
                Dim SQL1 As String = "INSERT INTO COMPANY(CMP, CMP1, CMP2, CMP3, CMP4, CMP5, CMP6, CMP7, CMP8, CMP9, CMP11, CMP12, CMP13, CMP14, CMP15, CMP16, USERNAME, CUser, COUser) VALUES (@CMP, @CMP1, @CMP2, @CMP3, @CMP4, @CMP5, @CMP6, @CMP7, @CMP8, @CMP9, @CMP11, @CMP12, @CMP13, @CMP14, @CMP15, @CMP16, @USERNAME, @CUser, @COUser)"
                Dim SQL2 As String = "INSERT INTO COMPANY(CMP, CMP1, CMP2, CMP3, CMP4, CMP5, CMP6, CMP7, CMP8, CMP9, CMP10, CMP11, CMP12, CMP13, CMP14, CMP15, CMP16, USERNAME, CUser, COUser) VALUES (@CMP, @CMP1, @CMP2, @CMP3, @CMP4, @CMP5, @CMP6, @CMP7, @CMP8, @CMP9, @CMP10, @CMP11, @CMP12, @CMP13, @CMP14, @CMP15, @CMP16, @USERNAME, @CUser, @COUser)"

                Using CMD As New SqlClient.SqlCommand()
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.Parameters.AddWithValue("@CMP", Me.TextCMP.Text)
                    CMD.Parameters.AddWithValue("@CMP1", Me.TEXTCMP1.Text)
                    CMD.Parameters.AddWithValue("@CMP2", Me.TEXTCMP2.Text)
                    CMD.Parameters.AddWithValue("@CMP3", Me.TEXTCMP3.Text)
                    CMD.Parameters.AddWithValue("@CMP4", Me.TEXTCMP4.Text)
                    CMD.Parameters.AddWithValue("@CMP5", Me.TEXTCMP5.Text)
                    CMD.Parameters.AddWithValue("@CMP6", Me.TEXTCMP6.Text)
                    CMD.Parameters.AddWithValue("@CMP7", Me.ComboCMP7.SelectedItem)
                    CMD.Parameters.AddWithValue("@CMP8", Me.ComboGovernorateName.SelectedItem)
                    CMD.Parameters.AddWithValue("@CMP9", Me.TextCMP9.Text)
                    CMD.Parameters.AddWithValue("@CMP11", Me.TextCMP11.Text)
                    CMD.Parameters.AddWithValue("@CMP12", Me.TextCMP12.Text)
                    CMD.Parameters.AddWithValue("@CMP13", Me.TextCMP13.Text)
                    CMD.Parameters.AddWithValue("@CMP14", Me.TextCMP14.Text)
                    CMD.Parameters.AddWithValue("@CMP15", Me.TextCMP15.Text)
                    CMD.Parameters.AddWithValue("@CMP16", Me.DateCMP16.Value.ToString("yyyy-MM-dd"))
                    CMD.Parameters.AddWithValue("@USERNAME", Me.TextUSERNAME.Text)
                    CMD.Parameters.AddWithValue("@CUser", Me.TextCUser.Text)
                    CMD.Parameters.AddWithValue("@COUser", Me.TextCOUser.Text)

                    If Me.PictureBox1.Image Is Nothing Then
                        CMD.CommandText = SQL1
                    Else
                        Using fs As New FileStream(OpenFileDialog1.FileName, FileMode.Open, FileAccess.Read)
                            Using r As New BinaryReader(fs)
                                Dim FileByteArray(fs.Length - 1) As Byte
                                r.Read(FileByteArray, 0, CInt(fs.Length))
                                CMD.Parameters.AddWithValue("@CMP10", FileByteArray)
                                CMD.CommandText = SQL2
                            End Using
                        End Using
                    End If

                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                End Using
            End Using
=======
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT CMP2  FROM COMPANY  WHERE (COMPANY. CMP2)='" & Me.TEXTBOX2.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
        ds.Clear()
        Adp1.Fill(ds, "COMPANY")
        If ds.Tables(0).Rows.Count >= 1 Then
            MessageBox.Show("تم تسجيل اسم الجمعية سابقاً", "تكرار بيانات جمعية", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Me.TEXTBOX2.Text = Nothing
            Me.TEXTBOX2.Focus()
            flag = True
            Me.SAVEBUTTON.Enabled = False
            Exit Sub
        Else
            flag = False
            Me.SAVEBUTTON.Enabled = True
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub
    Private Sub SEARCHUSERS1()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT CMP  FROM COMPANY  WHERE (COMPANY. CMP)='" & Me.TextBox11.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
        ds.Clear()
        Adp1.Fill(ds, "COMPANY")
        If ds.Tables(0).Rows.Count >= 1 Then
            MessageBox.Show("تم تسجيل رقم تسجيل الجمعية سابقاً", "تكرار بيانات جمعية", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Me.TextBox11.Text = Nothing
            Me.TextBox11.Focus()
            flag1 = True
            Me.SAVEBUTTON.Enabled = False
            Exit Sub
        Else
            flag = False
            Me.SAVEBUTTON.Enabled = True
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub
    Private Sub SAVERECORD()
        'On Error Resume Next
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL1 As New SqlClient.SqlCommand("INSERT INTO COMPANY(CMP, CMP1, CMP2, CMP3, CMP4, CMP5, CMP6, CMP7, CMP8, CMP9, CMP11, CMP12, CMP13, CMP14, CMP15, CMP16, USERNAME, CUser, COUser) VALUES     (@CMP, @CMP1, @CMP2, @CMP3, @CMP4, @CMP5, @CMP6, @CMP7, @CMP8, @CMP9, @CMP11, @CMP12, @CMP13, @CMP14, @CMP15, @CMP16, @USERNAME, @CUser, @COUser)", Consum)
            Dim SQL2 As New SqlClient.SqlCommand("INSERT INTO COMPANY(CMP, CMP1, CMP2, CMP3, CMP4, CMP5, CMP6, CMP7, CMP8, CMP9, CMP10, CMP11, CMP12, CMP13, CMP14, CMP15, CMP16, USERNAME, CUser, COUser) VALUES    (@CMP, @CMP1, @CMP2, @CMP3, @CMP4, @CMP5, @CMP6, @CMP7, @CMP8, @CMP9, @CMP10, @CMP11, @CMP12, @CMP13, @CMP14, @CMP15, @CMP16, @USERNAME, @CUser, @COUser)", Consum)
            Dim CMD As New SqlClient.SqlCommand

            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CMP", SqlDbType.Int).Value = Me.TextBox11.Text
                .Parameters.Add("@CMP1", SqlDbType.Int).Value = Me.TEXTCMP1.Text
                .Parameters.Add("@CMP2", SqlDbType.NVarChar).Value = Me.TEXTBOX2.Text
                .Parameters.Add("@CMP3", SqlDbType.NVarChar).Value = Me.TEXTBOX3.Text
                .Parameters.Add("@CMP4", SqlDbType.NVarChar).Value = Me.TEXTBOX4.Text
                .Parameters.Add("@CMP5", SqlDbType.NVarChar).Value = Me.TEXTBOX5.Text
                .Parameters.Add("@CMP6", SqlDbType.NVarChar).Value = Me.TEXTBOX6.Text
                .Parameters.Add("@CMP7", SqlDbType.NVarChar).Value = Me.ComboBox1.Text
                .Parameters.Add("@CMP8", SqlDbType.NVarChar).Value = Me.ComboGovernorateName.Text
                .Parameters.Add("@CMP9", SqlDbType.NVarChar).Value = Me.TextBox7.Text
                .Parameters.Add("@CMP11", SqlDbType.NVarChar).Value = Me.TextBox8.Text
                .Parameters.Add("@CMP12", SqlDbType.NVarChar).Value = Me.TextBox13.Text
                .Parameters.Add("@CMP13", SqlDbType.Float).Value = Me.TextBox14.Text
                .Parameters.Add("@CMP14", SqlDbType.NVarChar).Value = Me.TextBox15.Text
                .Parameters.Add("@CMP15", SqlDbType.NVarChar).Value = Me.TextBox10.Text
                .Parameters.Add("@CMP16", SqlDbType.NVarChar).Value = Me.DateTimePicker1.Value.ToString("yyyy-MM-dd")

                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Me.TextBox16.Text
                .Parameters.Add("@CUser", SqlDbType.Int).Value = Me.TextCUser.Text
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = Me.TextCOUser.Text
                If Me.PictureBox1.Image Is Nothing = True Then
                    Me.PictureBox1.Image = Nothing
                    .CommandText = SQL1.CommandText
                Else
                    Dim fs As New FileStream(OpenFileDialog1.FileName, FileMode.Open, FileAccess.Read)
                    Dim r As New BinaryReader(fs)
                    Dim FileByteArray(fs.Length - 1) As Byte
                    r.Read(FileByteArray, 0, CInt(fs.Length))
                    .Parameters.Add("@CMP10", SqlDbType.Image).Value = FileByteArray
                    .CommandText = SQL2.CommandText
                End If
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSAVERECORD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD

    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
=======
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            'If LockAddRow = False Then
            '    MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            '    Exit Sub
            'End If
            FILLCOMBOBOX("Governorates", "GovernorateName", Me.ComboGovernorateName)
            Me.SAVEBUTTON.Enabled = True
            Me.PHOTOEDIT.Enabled = False
            Application.DoEvents()
            Me.BS.CancelEdit()
            Me.BS.AddNew()
            Me.MAXRECORD()
            Me.MAXRECORD1()
<<<<<<< HEAD
            Me.ComboCMP7.Text = "متعددة الأغراض"
            Me.TextCMP11.Text = "محمدودة المسؤولية م.ع"
            Me.TEXTCMP6.Text = "CO@gmail.com"
            Me.TextCOUser.Text = COUser
            Me.TEXTCMP2.Focus()
=======
            Me.ComboBox1.Text = "متعددة الأغراض"
            Me.TextBox8.Text = "محمدودة المسؤولية م.ع"
            Me.TEXTBOX6.Text = "CO@gmail.com"
            Me.TextCOUser.Text = COUser
            Me.TEXTBOX2.Focus()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            Me.TextCUser.Text = GetAutoNumberCOUser()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            'If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Static P As Integer
            P = Me.BS.Count
            Me.SEARCHUSERS()
            If flag = True Then Exit Sub
            Me.SEARCHUSERS1()
            If flag1 = True Then Exit Sub
            Me.BS.Position = P + 1
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.SAVERECORD()
<<<<<<< HEAD
            Me.SaveDataBase = New ComponentModel.BackgroundWorker With {
=======
            Me.SaveDataBase = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveDataBase.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSAVEBUTTON_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub TEXTBOX2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTCMP2.KeyDown
=======
    Private Sub TEXTBOX2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTBOX2.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTCMP2.KeyPress
=======
    Private Sub TEXTBOX2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTBOX2.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                Me.SEARCHUSERS()
<<<<<<< HEAD
                If Me.TEXTCMP2.Text = "" Then
                    Me.TEXTCMP2.Focus()
                Else
                    Me.ComboCMP7.Focus()
                    Me.TEXTCMP2.Text = A & " " & Me.TEXTCMP2.Text.Trim & " " & B
=======
                If Me.TEXTBOX2.Text = "" Then
                    Me.TEXTBOX2.Focus()
                Else
                    Me.ComboBox1.Focus()
                    Me.TEXTBOX2.Text = A & " " & Me.TEXTBOX2.Text.Trim & " " & B
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTCMP2.LostFocus
        On Error Resume Next
        Me.SEARCHUSERS()
        If Me.TEXTCMP2.Text = "" Then
            Me.TEXTCMP2.Focus()
        Else
            Me.ComboCMP7.Focus()
        End If
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ComboCMP7.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.ComboCMP7.Text <> "" Then
                    Me.SEARCHUSERS()
                    Me.ComboGovernorateName.Focus()
                Else
                    Me.ComboCMP7.Focus()
=======
    Private Sub TEXTBOX2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTBOX2.LostFocus
        On Error Resume Next
        Me.SEARCHUSERS()
        If Me.TEXTBOX2.Text = "" Then
            Me.TEXTBOX2.Focus()
        Else
            Me.ComboBox1.Focus()
        End If
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.ComboBox1.Text <> "" Then
                    Me.SEARCHUSERS()
                    Me.ComboGovernorateName.Focus()
                Else
                    Me.ComboBox1.Focus()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ComboGovernorateName.KeyPress
=======
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboGovernorateName.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.ComboGovernorateName.Text <> "" Then
<<<<<<< HEAD
                    Me.TextCMP.Focus()
=======
                    Me.TextBox11.Focus()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Else
                    Me.ComboGovernorateName.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox11_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextCMP.KeyPress
=======
    Private Sub TextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox11.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                Me.SEARCHUSERS1()
<<<<<<< HEAD
                If Me.TextCMP.Text = "" Then
                    Me.TextCMP.Focus()
                Else
                    Me.TEXTCMP3.Focus()
=======
                If Me.TextBox11.Text = "" Then
                    Me.TextBox11.Focus()
                Else
                    Me.TEXTBOX3.Focus()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTCMP3.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TEXTCMP3.Text <> "" Then
                    Me.TEXTCMP4.Focus()
                Else
                    Me.TEXTCMP3.Focus()
=======
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTBOX3.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TEXTBOX3.Text <> "" Then
                    Me.TEXTBOX4.Focus()
                Else
                    Me.TEXTBOX3.Focus()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTCMP4.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TEXTCMP4.Text <> "" Then
                    Me.TextCMP9.Focus()
                Else
                    Me.TEXTCMP4.Focus()
=======
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTBOX4.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TEXTBOX4.Text <> "" Then
                    Me.TextBox7.Focus()
                Else
                    Me.TEXTBOX4.Focus()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextCMP9.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TextCMP9.Text <> "" Then
                    Me.TEXTCMP5.Focus()
                Else
                    Me.TextCMP9.Focus()
=======
    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TextBox7.Text <> "" Then
                    Me.TEXTBOX5.Focus()
                Else
                    Me.TextBox7.Focus()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTCMP5.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TEXTCMP5.Text <> "" Then
                    Me.TEXTCMP6.Focus()
                Else
                    Me.TEXTCMP5.Focus()
=======
    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTBOX5.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TEXTBOX5.Text <> "" Then
                    Me.TEXTBOX6.Focus()
                Else
                    Me.TEXTBOX5.Focus()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTCMP6.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TEXTCMP6.Text <> "" Then
                    Me.TextCMP12.Focus()
                Else
                    Me.TEXTCMP6.Focus()
=======
    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTBOX6.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TEXTBOX6.Text <> "" Then
                    Me.TextBox13.Focus()
                Else
                    Me.TEXTBOX6.Focus()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextCMP12.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TextCMP12.Text <> "" Then
                    Me.TextCMP14.Focus()
                Else
                    Me.TextCMP12.Focus()
=======
    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TextBox13.Text <> "" Then
                    Me.TextBox15.Focus()
                Else
                    Me.TextBox13.Focus()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox15_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextCMP14.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TextCMP14.Text <> "" Then
                    Me.TextCMP13.Focus()
                Else
                    Me.TextCMP14.Focus()
=======
    Private Sub TextBox15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox15.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TextBox15.Text <> "" Then
                    Me.TextBox14.Focus()
                Else
                    Me.TextBox15.Focus()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox14_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextCMP13.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TextCMP13.Text <> "" Then
                    Me.TextCMP13.Focus()
=======
    Private Sub TextBox14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox14.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TextBox14.Text <> "" Then
                    Me.TextBox14.Focus()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub ComboGovernorateName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboGovernorateName.SelectedIndexChanged
        Try
            Dim Adp As SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim strsql As New SqlCommand("SELECT ID_Governorate  FROM Governorates WHERE GovernorateName ='" & Me.ComboGovernorateName.Text & "'", Consum)
            Dim ds As New DataSet
            Adp = New SqlDataAdapter(strsql)
=======


    Private Sub ComboGovernorateName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboGovernorateName.SelectedIndexChanged
        Try
            Dim Adp As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsql As New SqlCommand("SELECT ID_Governorate  FROM Governorates WHERE GovernorateName ='" & Me.ComboGovernorateName.Text & "'", Consum)
            Dim ds As New DataSet
            Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            Consum.Open()
            Adp.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TextCOUser.Text = ds.Tables(0).Rows(0).Item(0)
            Else
                Me.TextCOUser.Text = ""
            End If
            Adp.Dispose()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboGovernorat_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class