Option Explicit Off

Imports System.Data.SqlClient
Imports System.IO

Public Class FrmCompany
<<<<<<< HEAD
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim ds As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter
=======
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim ds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveDataBase As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub PictureBox2Callback()
    Dim A, B As String
    Dim flag As Boolean = False
    Dim flag1 As Boolean = False
    Dim RowCount As Integer = 0
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
<<<<<<< HEAD
    Private Sub FrmCompany_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub FrmCompany_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.F3
                    EDITBUTTON_Click(sender, e)
                Case Keys.F4
                    BUTTONCANCEL_Click(sender, e)
                Case Keys.F6
                    DELETEBUTTON_Click(sender, e)
                Case Keys.F11
                    LOGOBUTTON_Click(sender, e)
                Case Keys.F12
                    PHOTOEDIT_Click(sender, e)

                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub FrmCompany_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmCompany_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.EDITBUTTON.Enabled = False
        Me.BUTTONCANCEL.Enabled = False
        Me.DELETEBUTTON.Enabled = False
        Me.ButtonSearch.Enabled = False
        Me.ButtonDisplyAll.Enabled = False
        Me.LOGOBUTTON.Enabled = False
        Me.PHOTOEDIT.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
    End Sub
<<<<<<< HEAD
    Public Sub ButtonXP4_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP4.Click
        Try
            Me.ConnectDataBase = New ComponentModel.BackgroundWorker With {
=======
    Public Sub ButtonXP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP4.Click
        Try
            Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.ConnectDataBase.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try

1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())


<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim strSQL As New SqlCommand("SELECT CMP, CMP1, CMP2, CMP3, CMP4, CMP5, CMP6, CMP7, CMP8, CMP9, CMP10, CMP11, CMP12, CMP13, CMP14, CMP15, CMP16, USERNAME, CUser, COUser FROM COMPANY where CUser ='" & Strings.Trim(Me.TB1) & "'or CMP ='" & Strings.Trim(Me.TB2) & "'or CMP2 ='" & Strings.Trim(Me.TB3) & "' ORDER BY CMP1", Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)

            Me.ds.Clear()
            Me.ds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.ds, "COMPANY")
            Me.BS.DataSource = Me.ds
            Me.BS.DataMember = "COMPANY"
            Consum.Close()
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If TestNet = True Then

        Else
            Me.Close()
        End If
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.ds.Tables("COMPANY")
            Me.RowCount = Me.BS.Count
            Me.TextCMP.DataBindings.Add("text", Me.BS, "CMP", True, 1, "")
            Me.TEXTCMP1.DataBindings.Add("text", Me.BS, "CMP1", True, 1, "")
            Me.TEXTCMP2.DataBindings.Add("text", Me.BS, "CMP2", True, 1, "")
            Me.TEXTCMP3.DataBindings.Add("text", Me.BS, "CMP3", True, 1, "")
            Me.TEXTCMP4.DataBindings.Add("text", Me.BS, "CMP4", True, 1, "")
            Me.TEXTCMP5.DataBindings.Add("text", Me.BS, "CMP5", True, 1, "")
            Me.TEXTCMP6.DataBindings.Add("text", Me.BS, "CMP6", True, 1, "")
            Me.ComboCMP7.DataBindings.Add("text", Me.BS, "CMP7", True, 1, "")
            Me.ComboGovernorateName.DataBindings.Add("text", Me.BS, "CMP8", True, 1, "")
            Me.TextCMP9.DataBindings.Add("text", Me.BS, "CMP9", True, 1, "")
            Me.TextCMP11.DataBindings.Add("text", Me.BS, "CMP11", True, 1, "")
            Me.TextCMP12.DataBindings.Add("text", Me.BS, "CMP12", True, 1, "")
            Me.TextCMP13.DataBindings.Add("text", Me.BS, "CMP13", True, 1, "")
            Me.TextCMP14.DataBindings.Add("text", Me.BS, "CMP14", True, 1, "")
            Me.TextCMP15.DataBindings.Add("text", Me.BS, "CMP15", True, 1, "")
            Me.DateTimeCMP16.DataBindings.Add("text", Me.BS, "CMP16", True, 1, "")
            Me.TextUSERNAME.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TextCOUser.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
            Me.TextCuser.DataBindings.Add("text", Me.BS, "cuser", True, 1, "")

            Me.PictureCMP10.DataBindings.Add(New Binding("Image", Me.BS, "CMP10", True))
            Me.DataGridView1.DataSource = Me.BS
            Me.A = "Ã„⁄Ì…"
            Me.B = "«· ⁄«Ê‰Ì…"

            Me.List1.DataSource = Me.ds.Tables("COMPANY")
            Me.List1.DisplayMember = "cmp2"
            FILLCOMBOBOX("Governorates", "GovernorateName", Me.ComboGovernorateName)

            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.Columns(1).Visible = False
            Me.DataGridView1.Columns(5).Visible = False
            Me.DataGridView1.Columns(6).Visible = False
            Me.DataGridView1.Columns(7).Visible = False
            Me.DataGridView1.Columns(8).Visible = False
            Me.DataGridView1.Columns(9).Visible = False
            Me.DataGridView1.Columns(10).Visible = False
            Me.DataGridView1.Columns(11).Visible = False
            Me.DataGridView1.Columns(12).Visible = False
            Me.DataGridView1.Columns(13).Visible = False
            Me.DataGridView1.Columns(14).Visible = False
            Me.DataGridView1.Columns(15).Visible = False
            Me.DataGridView1.Columns(16).Visible = False
            Me.DataGridView1.Columns(17).Visible = False
            Me.DataGridView1.Columns(18).Visible = False
            Me.DataGridView1.Columns(19).Visible = False


            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            Dim Column As New DataGridViewCheckBoxColumn
            With Me.DataGridView1
                .RowsDefaultCellStyle.BackColor = Color.Bisque
                .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
            End With
            '==============================
            Call MangUsers()
            Me.SHOWBUTTON()
            Me.ButtonXP4.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveDataBase.DoWork
        Try
1:
            'Me.SqlDataAdapter1.Update(Me.ds, "COMPANY")
            'Me.ds = New DataSet
            'Me.SqlDataAdapter1.Fill(Me.ds, "COMPANY")
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
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
            Me.BS.DataSource = Me.ds.Tables("COMPANY")
            Me.TEXTCMP5.Enabled = True
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            If Me.BS.Count < Me.RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & Me.RowCount - Me.BS.Count, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & Me.BS.Count - Me.RowCount, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            End If
<<<<<<< HEAD
            Dim Sound As Stream = My.Resources.save
=======
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.PHOTOEDIT.Enabled = LockUpdate
        Me.ButtonSearch.Enabled = LockPrint
        Me.ButtonDisplyAll.Enabled = True
        Me.LOGOBUTTON.Enabled = LockUpdate
        Me.PHOTOEDIT.Enabled = LockUpdate
    End Sub
    Private Sub SHOWPHOTO()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim sql As String = "SELECT CMP7 FROM COMPANY WHERE cuser = '" & Me.TEXTCMP1.Text & "'"
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
            Me.PictureCMP10.Image = New Bitmap(stream)
            stream.Close()
        Else
            Me.PictureCMP10.Image = Nothing
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
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim V As Integer
        Dim SQL As New SqlCommand("SELECT MAX(cuser) FROM COMPANY", Consum)
        Dim CMD As New SqlCommand
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim V As Integer
        Dim SQL As New SqlCommand("SELECT MAX(cuser) FROM COMPANY", Consum)
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
            TextCuser.Text = 1
        Else
            TextCuser.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub
    Private Sub DISPLAYRECORD()
        On Error Resume Next
        With Me
            .TEXTCMP1.Text = ds.Tables("COMPANY").Rows(Me.BS.Position)("CMP1").ToString
            .TEXTCMP2.Text = ds.Tables("COMPANY").Rows(Me.BS.Position)("CMP2").ToString
            .TEXTCMP3.Text = ds.Tables("COMPANY").Rows(Me.BS.Position)("CMP3").ToString
            .TEXTCMP4.Text = ds.Tables("COMPANY").Rows(Me.BS.Position)("CMP4").ToString
            .TEXTCMP5.Text = ds.Tables("COMPANY").Rows(Me.BS.Position)("CMP5").ToString
            .TEXTCMP6.Text = ds.Tables("COMPANY").Rows(Me.BS.Position)("CMP6").ToString
            .PictureCMP10.DataBindings.Add(New Binding("Image", BS, "CMP7", True))
        End With
    End Sub
    Private Sub UPDATERECORD()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim SQL As String = " Update COMPANY SET    CMP = @CMP, CMP2 = @CMP2, CMP3 = @CMP3, CMP4 = @CMP4, CMP5 = @CMP5, CMP6 = @CMP6, CMP7 = @CMP7, CMP8 = @CMP8, CMP9 = @CMP9, CMP11 = @CMP11, CMP12 = @CMP12, CMP13 = @CMP13, CMP14 = @CMP14, CMP15 = @CMP15, CMP16 = @CMP16, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser WHERE CMP1 = @CMP1"
        Dim CMD As New SqlCommand With {
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As String = " Update COMPANY SET    CMP = @CMP, CMP2 = @CMP2, CMP3 = @CMP3, CMP4 = @CMP4, CMP5 = @CMP5, CMP6 = @CMP6, CMP7 = @CMP7, CMP8 = @CMP8, CMP9 = @CMP9, CMP11 = @CMP11, CMP12 = @CMP12, CMP13 = @CMP13, CMP14 = @CMP14, CMP15 = @CMP15, CMP16 = @CMP16, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser WHERE CMP1 = @CMP1"
        Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@CMP", SqlDbType.Int).Value = Me.TextCMP.Text
            .Parameters.Add("@CMP1", SqlDbType.Int).Value = Me.TEXTCMP1.Text
            .Parameters.Add("@CMP2", SqlDbType.NVarChar).Value = Me.TEXTCMP2.Text
            .Parameters.Add("@CMP3", SqlDbType.NVarChar).Value = Me.TEXTCMP3.Text
            .Parameters.Add("@CMP4", SqlDbType.NVarChar).Value = Me.TEXTCMP4.Text
            .Parameters.Add("@CMP5", SqlDbType.NVarChar).Value = Me.TEXTCMP5.Text
            .Parameters.Add("@CMP6", SqlDbType.NVarChar).Value = Me.TEXTCMP6.Text
            .Parameters.Add("@CMP7", SqlDbType.NVarChar).Value = Me.ComboCMP7.Text
            .Parameters.Add("@CMP8", SqlDbType.NVarChar).Value = Me.ComboGovernorateName.Text
            .Parameters.Add("@CMP9", SqlDbType.NVarChar).Value = Me.TextCMP9.Text
            .Parameters.Add("@CMP11", SqlDbType.NVarChar).Value = Me.TextCMP11.Text
            .Parameters.Add("@CMP12", SqlDbType.NVarChar).Value = Me.TextCMP12.Text
            .Parameters.Add("@CMP13", SqlDbType.Float).Value = Me.TextCMP13.Text
            .Parameters.Add("@CMP14", SqlDbType.NVarChar).Value = Me.TextCMP14.Text
            .Parameters.Add("@CMP15", SqlDbType.NVarChar).Value = Me.TextCMP15.Text
            .Parameters.Add("@CMP16", SqlDbType.NVarChar).Value = Me.DateTimeCMP16.Value.ToString("yyyy-MM-dd")
            .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Me.TextUSERNAME.Text
            .Parameters.Add("@CUser", SqlDbType.Int).Value = Me.TextCuser.Text
            .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = Me.TextCOUser.Text
            .CommandText = SQL
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        CMD.ExecuteNonQuery()
        Consum.Close()
    End Sub
<<<<<<< HEAD
    Private Sub LOGOBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LOGOBUTTON.Click
=======
    Private Sub LOGOBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOGOBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        OpenFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|AllFiles (*.*)|*.*"
        With Me.OpenFileDialog1
            .FilterIndex = 1
            .Title = "Õœœ ‘⁄«— «·Ã„⁄Ì…"
            .ShowDialog()
            If Len(.FileName) > 0 Then
                Me.PictureCMP10.Image = Image.FromFile(OpenFileDialog1.FileName)
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
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT CMP2  FROM COMPANY  WHERE (COMPANY. CMP2)='" & Me.TEXTCMP2.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsq1)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT CMP2  FROM COMPANY  WHERE (COMPANY. CMP2)='" & Me.TEXTCMP2.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp1.Fill(ds, "COMPANY")
        If ds.Tables(0).Rows.Count >= 1 Then
            MessageBox.Show(" „  ”ÃÌ· «”„ «·Ã„⁄Ì… ”«»ﬁ«", " ﬂ—«— »Ì«‰«  Ã„⁄Ì…", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Me.TEXTCMP2.Focus()
            flag = True
            Exit Sub
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub
    Private Sub SEARCHUSERS1()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT CMP  FROM COMPANY  WHERE (COMPANY. CMP)='" & Me.TextCMP.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsq1)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT CMP  FROM COMPANY  WHERE (COMPANY. CMP)='" & Me.TextCMP.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp1.Fill(ds, "COMPANY")
        If ds.Tables(0).Rows.Count >= 1 Then
            MessageBox.Show(" „  ”ÃÌ· —ﬁ„  ”ÃÌ· «·Ã„⁄Ì… ”«»ﬁ«", " ﬂ—«— »Ì«‰«  Ã„⁄Ì…", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Me.TextCMP.Focus()
            flag1 = True
            Exit Sub
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub
<<<<<<< HEAD
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
=======
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockUpdate = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Me.PictureBox2.Visible = True
        Me.BS.EndEdit()
        Me.UPDATERECORD()
<<<<<<< HEAD
        Me.SaveDataBase = New ComponentModel.BackgroundWorker With {
=======
        Me.SaveDataBase = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveDataBase.RunWorkerAsync()
    End Sub
<<<<<<< HEAD
    Private Sub List1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles List1.SelectedIndexChanged
=======
    Private Sub List1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles List1.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        BS.Position = Me.List1.SelectedIndex
        RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
=======
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockDelete = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… Õ–› «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        MYDELETERECORD("COMPANY", "CMP", TEXTCMP1, BS, True)
        FrmCompany_Load(sender, e)
        CLEARDATA1(Me)
    End Sub
<<<<<<< HEAD
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
=======
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        BS.CancelEdit()
        ds.RejectChanges()
        RecordCount()
    End Sub
    Private Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = BS.Count
        CurrenRecordst = BS.Position + 1
        RECORDSLABEL.Text = CurrenRecordst.ToString & " „‰ " & TotalRecords.ToString
        If BS.Position > 0 Then
            Back = True
        End If
        If BS.Position < ds.Tables("COMPANY").Rows.Count - 1 Then
            Forward = True
        End If
        FIRSTBUTTON.Enabled = Back
        PREVIOUSBUTTON.Enabled = Back
        NEXTBUTTON.Enabled = Forward
        LASTBUTTON.Enabled = Forward
        SHOWPHOTO()
    End Sub
<<<<<<< HEAD
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FIRSTBUTTON.Click
=======
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        BS.Position = 0
        RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PREVIOUSBUTTON.Click
=======
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        BS.Position = BS.Position - 1
        RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NEXTBUTTON.Click
=======
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        BS.Position = BS.Position + 1
        RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
=======
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        BS.Position = BS.Count - 1
        RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonSearch.Click
=======
    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TextSearch.Text = "" Then
            MessageBox.Show("«·—Ã«¡ Ê÷⁄ ﬁÌ„… ··»ÕÀ ⁄‰Â«", " «·»ÕÀ ›Ì œ« « Ã—Ìœ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TEXTCMP2.Focus()
            Exit Sub
        End If
        DataGridView1.ClearSelection()
        Label2.Text = ""
        Dim InStrCunot As Integer = 0
        If IsDate(Me.TEXTCMP2.Text) Then
            Me.TEXTCMP2.Text = Format(CDate(Me.TEXTCMP2.Text), "yyyy/MM/dd")
        ElseIf IsNumeric(Me.TEXTCMP2.Text) Then
            Me.TEXTCMP2.Text = Format(Val(Me.TEXTCMP2.Text), "#,#0.00")
        End If
        If RadioButton9.Checked Then
            DataGridView1.ClearSelection()
            InStrCunot = 0
            For intcount As Integer = 0 To DataGridView1.RowCount - 1
                For intcolmn As Integer = 0 To DataGridView1.Columns.Count - 1
                    If Trim(TEXTCMP2.Text) = DataGridView1.Rows(intcount).Cells(intcolmn).FormattedValue.ToString Then
                        DataGridView1.Rows(intcount).Cells(intcolmn).Selected = True
                        DataGridView1.Rows(intcount).Cells(intcolmn).Style.BackColor = Color.Red
                        DataGridView1.Rows(intcount).Cells(intcolmn).Style.ForeColor = Color.White
                        InStrCunot += 1
                    End If
                Next intcolmn
            Next intcount
        Else
            DataGridView1.ClearSelection()
            InStrCunot = 0
            Dim b As Boolean
            For intcount As Integer = 0 To DataGridView1.RowCount - 1
                For intcolmn As Integer = 0 To DataGridView1.Columns.Count - 1
                    b = InStr(DataGridView1.Rows(intcount).Cells(intcolmn).FormattedValue, Trim(TEXTCMP2.Text))
                    If b = True Then
                        DataGridView1.Rows(intcount).Cells(intcolmn).Selected = True
                        DataGridView1.Rows(intcount).Cells(intcolmn).Style.BackColor = Color.Red
                        DataGridView1.Rows(intcount).Cells(intcolmn).Style.ForeColor = Color.White
                        InStrCunot += 1
                    End If
                Next intcolmn
            Next intcount
        End If
        Label1.Text = IIf(InStrCunot > 0, InStrCunot & " ”Ã·  ", 0 & " ”Ã·  ")
        If InStrCunot = 0 Then
            MessageBox.Show("·„ Ì „ «·⁄ÀÊ— ⁄·Ï ‘Ì", " «·»ÕÀ ›Ì œ« « Ã—Ìœ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextSearch.Focus()
            Label1.Text = "0" & "   ”Ã·   "
        End If
        ListBox3.Items.Clear()
        For Each cell As DataGridViewCell In DataGridView1.SelectedCells
            ListBox3.Items.Add(cell.RowIndex + 1 & " - " & cell.Value)
            ListBox3.Refresh()
            DataGridView1.ClearSelection()
            ListBox3.SelectedIndex = ListBox3.Items.Count - 1
        Next
    End Sub
<<<<<<< HEAD
    Private Sub ButtonDisplyAll_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonDisplyAll.Click
=======
    Private Sub ButtonDisplyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDisplyAll.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            ds = New DataSet
            SqlDataAdapter1.Fill(ds, "COMPANY")
            Me.ListBox3.Items.Clear()
            Me.TextSearch.Text = ""
            Me.Label1.Text = ""
            Me.Label2.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListBox3.SelectedIndexChanged
=======
    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox3.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Dim Str As String = ListBox3.Text
            Dim strArr() As String
            Dim a As String
            strArr = Str.Split("-")
            a = strArr.First()
            DataGridView1.CurrentCell = DataGridView1.Rows(a - 1).Cells(0)
            BS.Position = Val(a) - 1
            RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTCMP2.KeyDown
=======
    Private Sub TEXTBOX2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTCMP2.KeyDown
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
    Private Sub TEXTBOX2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTCMP2.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If TEXTCMP2.Text <> "" Then
                    ComboCMP7.Focus()
                    Me.TEXTCMP2.Text = A & " " & TEXTCMP2.Text.Trim & " " & B
                Else
                    TEXTCMP2.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTCMP2.LostFocus
        On Error Resume Next
        ComboCMP7.Focus()
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ComboCMP7.KeyPress
=======
    Private Sub TEXTBOX2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTCMP2.LostFocus
        On Error Resume Next
        ComboCMP7.Focus()
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboCMP7.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If ComboCMP7.Text <> "" Then
                    SEARCHUSERS()
                    ComboGovernorateName.Focus()
                Else
                    ComboCMP7.Focus()
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
                If ComboGovernorateName.Text <> "" Then
                    TextCMP.Focus()
                Else
                    ComboGovernorateName.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox11_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextCMP.KeyPress
=======
    Private Sub TextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextCMP.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If TextCMP.Text <> "" Then
                    SEARCHUSERS1()
                    TEXTCMP3.Focus()
                Else
                    TextCMP.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTCMP3.KeyPress
=======
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTCMP3.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If TEXTCMP3.Text <> "" Then
                    TEXTCMP4.Focus()
                Else
                    TEXTCMP3.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTCMP4.KeyPress
=======
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTCMP4.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If TEXTCMP4.Text <> "" Then
                    TextCMP9.Focus()
                Else
                    TEXTCMP4.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextCMP9.KeyPress
=======
    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextCMP9.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If TextCMP9.Text <> "" Then
                    TEXTCMP5.Focus()
                Else
                    TextCMP9.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTCMP5.KeyPress
=======
    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTCMP5.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If TEXTCMP5.Text <> "" Then
                    TEXTCMP6.Focus()
                Else
                    TEXTCMP5.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTCMP6.KeyPress
=======
    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTCMP6.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If TEXTCMP6.Text <> "" Then
                    TextCMP12.Focus()
                Else
                    TEXTCMP6.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextCMP12.KeyPress
=======
    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextCMP12.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If TextCMP12.Text <> "" Then
                    TextCMP14.Focus()
                Else
                    TextCMP12.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox15_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextCMP14.KeyPress
=======
    Private Sub TextBox15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextCMP14.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If TextCMP14.Text <> "" Then
                    TextCMP13.Focus()
                Else
                    TextCMP14.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox14_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextCMP13.KeyPress
=======
    Private Sub TextBox14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextCMP13.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If TextCMP13.Text <> "" Then
                    TextCMP13.Focus()
                Else
                    TextSearch.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub TextCMP_TextChanged(sender As Object, e As EventArgs) Handles TextCMP.TextChanged

    End Sub

    Private Sub RECORDSLABEL_Click(sender As Object, e As EventArgs) Handles RECORDSLABEL.Click

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