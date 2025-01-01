Option Explicit Off

Imports System.Data.SqlClient
Imports System.IO

Public Class FrmCompanyAdd
    Inherits System.Windows.Forms.Form
    Dim WithEvents BS As New BindingSource
    ReadOnly ds As New DataSet
    Private WithEvents SaveDataBase As System.ComponentModel.BackgroundWorker
    Dim A, B As String
    Dim flag As Boolean = False
    Dim flag1 As Boolean = False
    ReadOnly RowCount As Integer = 0

    Private Sub FrmCompany_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'AutoComplete(Me.ComboBox2, e, )
    End Sub
    Private Sub FrmCompanyAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
            Me.TEXTBOX5.Enabled = True
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            'If Me.BS.Count < Me.RowCount Then
            '    MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
            '    Exit Sub
            'ElseIf Me.BS.Count > Me.RowCount Then
            '    MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
            '    Exit Sub
            'End If
            Dim Sound As System.IO.Stream = My.Resources.save
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
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim sql As String = "SELECT CMP7 FROM COMPANY WHERE cuser = '" & Me.TEXTCMP1.Text & "'"
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim cmd As New SqlClient.SqlCommand(sql, Consum)
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
    Private Sub TEXTBOX1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTCMP1.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub MAXRECORD()
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
    Private Sub PHOTOEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PHOTOEDIT.Click
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As String = " Update COMPANY SET  CMP10 = @CMP10 WHERE cuser = @cuser"
        Dim CMD As New SqlClient.SqlCommand With {
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
            .Parameters.Add("@CMP1", SqlDbType.Int).Value = Me.TEXTCMP1.Text.Trim
            .Parameters.Add("@CMP10", SqlDbType.Image).Value = FileByteArray
            .CommandText = SQL
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        CMD.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub SEARCHUSERS()
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSAVERECORD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
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
            Me.ComboBox1.Text = "متعددة الأغراض"
            Me.TextBox8.Text = "محمدودة المسؤولية م.ع"
            Me.TEXTBOX6.Text = "CO@gmail.com"
            Me.TextCOUser.Text = COUser
            Me.TEXTBOX2.Focus()
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            Me.TextCUser.Text = GetAutoNumberCOUser()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
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
            Me.SaveDataBase = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveDataBase.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSAVEBUTTON_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TEXTBOX2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTBOX2.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub TEXTBOX2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTBOX2.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                Me.SEARCHUSERS()
                If Me.TEXTBOX2.Text = "" Then
                    Me.TEXTBOX2.Focus()
                Else
                    Me.ComboBox1.Focus()
                    Me.TEXTBOX2.Text = A & " " & Me.TEXTBOX2.Text.Trim & " " & B
                End If
                e.Handled = True
            End If
        End If
    End Sub
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
                End If
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboGovernorateName.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.ComboGovernorateName.Text <> "" Then
                    Me.TextBox11.Focus()
                Else
                    Me.ComboGovernorateName.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox11.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                Me.SEARCHUSERS1()
                If Me.TextBox11.Text = "" Then
                    Me.TextBox11.Focus()
                Else
                    Me.TEXTBOX3.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTBOX3.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TEXTBOX3.Text <> "" Then
                    Me.TEXTBOX4.Focus()
                Else
                    Me.TEXTBOX3.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTBOX4.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TEXTBOX4.Text <> "" Then
                    Me.TextBox7.Focus()
                Else
                    Me.TEXTBOX4.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TextBox7.Text <> "" Then
                    Me.TEXTBOX5.Focus()
                Else
                    Me.TextBox7.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTBOX5.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TEXTBOX5.Text <> "" Then
                    Me.TEXTBOX6.Focus()
                Else
                    Me.TEXTBOX5.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTBOX6.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TEXTBOX6.Text <> "" Then
                    Me.TextBox13.Focus()
                Else
                    Me.TEXTBOX6.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TextBox13.Text <> "" Then
                    Me.TextBox15.Focus()
                Else
                    Me.TextBox13.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox15.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TextBox15.Text <> "" Then
                    Me.TextBox14.Focus()
                Else
                    Me.TextBox15.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox14.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TextBox14.Text <> "" Then
                    Me.TextBox14.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub ComboGovernorateName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboGovernorateName.SelectedIndexChanged
        Try
            Dim Adp As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsql As New SqlCommand("SELECT ID_Governorate  FROM Governorates WHERE GovernorateName ='" & Me.ComboGovernorateName.Text & "'", Consum)
            Dim ds As New DataSet
            Adp = New SqlClient.SqlDataAdapter(strsql)
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