Imports System.Data.Common
Imports System.Data.SqlClient


Public Class FrmDailyrestrictions1
    Inherits Form
    Public WithEvents BS As New BindingSource
    ReadOnly ds1 As New DataSet
    Dim SqlDataAdapter1 As New SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlDataAdapter
    ReadOnly account_name As New DataTable
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0

    Private Sub FrmDailyrestrictions_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub FrmDailyrestrictions1_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
    End Sub

    Private Sub FrmDailyrestrictions1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next

        Me.SHOWBUTTON()
        SEARCHDATA.MAXIDMOVES()
        'FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NumericUpDown1.Value, Me.MOVD3)
        Me.LoadData()
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
    End Sub

    Private Sub NumericUpDown1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles NUpDownAccountLevel.LostFocus
        Call LoadData()
    End Sub

    Private Sub NumericUpDown1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpDownAccountLevel.ValueChanged
        'FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NumericUpDown1.Value, Me.MOVD3)
        Call LoadData()
    End Sub

    Public Sub DanLOd()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim str1 As New SqlCommand("", Consum)
        With str1
            .CommandText = "SELECT MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, USERNAME, Auditor, Realname, cuser, COUser, da, ne, da1, ne1 FROM MOVES  WHERE MOV2 ='" & Me.TEXTRegistrationNumber.EditValue & "'ORDER BY MOV2"
            Dim builder50 As New SqlCommandBuilder(SqlDataAdapter1)
        End With
        Dim str2 As New SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT MOVD1, MOV2, MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3 FROM MOVESDATA  ORDER BY MOV2"
            Dim builder51 As New SqlCommandBuilder(SqlDataAdapter2)
        End With
        Me.ds1.EnforceConstraints = False
        Consum.Open()
        Me.SqlDataAdapter1 = New SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlDataAdapter(str2)
        Me.ds1.Clear()
        Me.SqlDataAdapter1.Fill(Me.ds1, "MOVES")
        Me.SqlDataAdapter2.Fill(Me.ds1, "MOVESDATA")
        Me.ds1.Relations.Add("REL1", Me.ds1.Tables("MOVES").Columns("MOV2"), Me.ds1.Tables("MOVESDATA").Columns("MOV2"), True)
        Me.ds1.EnforceConstraints = True
        Me.LoadData()
        Me.BS.DataSource = Me.ds1
        Me.BS.DataMember = "MOVES"
        Me.DataGridView1.DataSource = Me.BS
        Me.DataGridView1.DataMember = "REL1"
        Me.DataGridView1.Columns("MOV3").Visible = False
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Consum.Close()

        Me.DataGridView1.AutoGenerateColumns = False
        Call MangUsers()
        Me.TextLSet.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
        Me.PictureBox2.Visible = False
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ErrorDanLOd", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub


    Private Sub LoadData()
        Dim Consum As New SqlConnection(constring)
        Using cmd As New SqlCommand("Select acc1, account_no, account_name  from ACCOUNTSTREE  WHERE   account_no<>'" & "1" & "'" & "AND account_no<>'" & "2" & "'" & "AND account_no<>'" & "3" & "'" & "AND account_no<>'" & "4" & "'" & "AND account_no<>'" & "11" & "'" & "AND account_no<>'" & "12" & "'" & "AND account_no<>'" & "211" & "'" & "AND account_no<>'" & "212" & "'" & "AND account_no<>'" & "311" & "'" & "AND account_no<>'" & "312" & "'" & "AND account_no<>'" & "411" & "'" & "AND account_no<>'" & "412" & "'ORDER BY account_no", Consum)
            Consum.Open()
            Using dreader As SqlDataReader = cmd.ExecuteReader
                account_name.Clear()
                account_name.Load(dreader)
                For i As Integer = 0 To account_name.Rows.Count - 1
                    Me.MOVD3.Items.Add(account_name(i)(2))
                Next
            End Using
        End Using
        Consum.Close()
    End Sub

    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:

        Catch ex As Exception
            If ex.Message.GetHashCode = -1115812848 Or ex.Message.GetHashCode = 379362862 Then
                e.Cancel = True
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                e.Cancel = True
                TestNet = False
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            ElseIf ex.Message.GetHashCode = -652120241 Or ex.Message.GetHashCode = 2067669773 Then
                DelRow = True
                Me.PictureBox2False()
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
            Else
                e.Cancel = True
                Me.PictureBox2False()
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
            Dim Sound As IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.PictureBox5.Visible = False
        End If
    End Sub

    Private Sub SaveMOVES()
        'On Error Resume Next
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand("INSERT INTO MOVES (MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, USERNAME, Realname, cuser, COUser, da, ne) VALUES     (@MOV1, @MOV2, @MOV3, @MOV4, @MOV5, @MOV6, @MOV7, @MOV8, @MOV9, @MOV10, @MOV11, @MOV12, @USERNAME, @Realname, @cuser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOV1", SqlDbType.Int).Value = Me.TEXTID.Text
                .Parameters.Add("@MOV2", SqlDbType.BigInt).Value = Me.TEXTRegistrationNumber.EditValue
                .Parameters.Add("@MOV3", SqlDbType.Date).Value = Me.DATETIMEPICKER.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@MOV5", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TEXTDebit.Text
                .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TEXTCredit.Text
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = Me.TextJournalNo.Text
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = Me.ComboEntryType.Text
                .Parameters.Add("@MOV10", SqlDbType.NVarChar).Value = Me.TextLSet.Text
                .Parameters.Add("@MOV11", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@MOV12", SqlDbType.Bit).Value = False
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@Realname", SqlDbType.NVarChar).Value = Realname
                .Parameters.Add("@cuser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSaveMOVES", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveMOVESDATA()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        'DanLOd()
        Dim SQL As New SqlCommand("INSERT INTO MOVESDATA(MOV2, MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3) VALUES     (@MOV2, @MOVD2, @MOVD3, @MOVD4, @MOVD5, @MOVD6, @MOVD7, @MOVD8, @MOVD9, @MOVD10, @MOV3)", Consum)
        Dim CMD As New SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@MOVD1", SqlDbType.Int, 4, "MOVD1")
            .Parameters.Add("@MOV2", SqlDbType.Int, 4, "MOV2").Value = Me.TEXTRegistrationNumber.EditValue
            .Parameters.Add("@MOVD2", SqlDbType.BigInt, 8, "MOVD2")
            .Parameters.Add("@MOVD3", SqlDbType.NVarChar, 100, "MOVD3")
            .Parameters.Add("@MOVD4", SqlDbType.Int, 4, "MOVD4")
            .Parameters.Add("@MOVD5", SqlDbType.Float, 8, "MOVD5")
            .Parameters.Add("@MOVD6", SqlDbType.Float, 8, "MOVD6")
            .Parameters.Add("@MOVD7", SqlDbType.NVarChar, 150, "MOVD7")
            .Parameters.Add("@MOVD8", SqlDbType.Int, 4, "MOVD8")
            .Parameters.Add("@MOVD9", SqlDbType.NVarChar, 25, "MOVD9").Value = Me.TextMovementSymbol.EditValue
            .Parameters.Add("@MOVD10", SqlDbType.NVarChar, 25, "MOVD10").Value = Me.TEXTID.Text
            .Parameters.Add("@MOV3", SqlDbType.Bit, 1, "MOV3").Value = 0
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table", "MOVESDATA", New DataColumnMapping() {New DataColumnMapping("MOVD1", "MOVD1"), New DataColumnMapping("MOV2", "MOV2"), New DataColumnMapping("MOVD2", "MOVD2"), New DataColumnMapping("MOVD3", "MOVD3"), New DataColumnMapping("MOVD4", "MOVD4"), New DataColumnMapping("MOVD5", "MOVD5"), New DataColumnMapping("MOVD6", "MOVD6"), New DataColumnMapping("MOVD7", "MOVD7"), New DataColumnMapping("MOVD8", "MOVD8"), New DataColumnMapping("MOVD9", "MOVD9"), New DataColumnMapping("MOVD10", "MOVD10"), New DataColumnMapping("MOV3", "MOV3")})})
        SqlDataAdapter2.InsertCommand = CMD
        SqlDataAdapter2.Update(ds1, "MOVESDATA")
        Consum.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ErrorSaveMovesData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub UPDATEMOVES()
        'On Error Resume Next
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" UPDATE  MOVES SET   MOV2 = @MOV2, MOV3 = @MOV3, MOV4 = @MOV4, MOV6 = @MOV6, MOV7 = @MOV7, MOV8 = @MOV8, MOV9 = @MOV9, MOV10 = @MOV10, MOV11 = @MOV11, MOV12 = @MOV12, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1, cuser = @cuser, COUser = @COUser, USERNAME = @USERNAME, Realname = @Realname WHERE MOV1 = @MOV1", Consum)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOV1", SqlDbType.Int).Value = Me.TEXTID.Text
                .Parameters.Add("@MOV2", SqlDbType.BigInt).Value = Me.TEXTRegistrationNumber.EditValue
                .Parameters.Add("@MOV3", SqlDbType.Date).Value = Me.DATETIMEPICKER.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@MOV5", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TEXTDebit.Text
                .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TEXTCredit.Text
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = Me.TextJournalNo.Text
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = Me.ComboEntryType.Text
                .Parameters.Add("@MOV10", SqlDbType.NVarChar).Value = Me.TextLSet.Text
                .Parameters.Add("@MOV11", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@MOV12", SqlDbType.Bit).Value = False
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@Realname", SqlDbType.NVarChar).Value = Realname
                .Parameters.Add("@cuser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = SQL.CommandText
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
            End With
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUpdateMoves", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub UPDATEMOVESDATA()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" UPDATE MOVESDATA SET MOV2 = @MOV2, MOVD2 = @MOVD2, MOVD3 = @MOVD3, MOVD4 = @MOVD4, MOVD5 = @MOVD5, MOVD6 = @MOVD6, MOVD7 = @MOVD7, MOVD8 = @MOVD8, MOVD9 = @MOVD9, MOVD10 = @MOVD10,  MOVESDATA.MOV3 = @MOV3  WHERE MOVD1 = @MOVD1", Consum)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOVD1", SqlDbType.Int, 4, "MOVD1")
                .Parameters.Add("@MOV2", SqlDbType.Int, 4, "MOV2").Value = Me.TEXTRegistrationNumber.EditValue
                .Parameters.Add("@MOVD2", SqlDbType.BigInt, 8, "MOVD2")
                .Parameters.Add("@MOVD3", SqlDbType.NVarChar, 100, "MOVD3")
                .Parameters.Add("@MOVD4", SqlDbType.Int, 4, "MOVD4")
                .Parameters.Add("@MOVD5", SqlDbType.Float, 8, "MOVD5")
                .Parameters.Add("@MOVD6", SqlDbType.Float, 8, "MOVD6")
                .Parameters.Add("@MOVD7", SqlDbType.NVarChar, 150, "MOVD7")
                .Parameters.Add("@MOVD8", SqlDbType.Int, 4, "MOVD8")
                .Parameters.Add("@MOVD9", SqlDbType.NVarChar, 25, "MOVD9").Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@MOVD10", SqlDbType.NVarChar, 25, "MOVD10").Value = Me.TEXTID.Text
                .Parameters.Add("@MOV3", SqlDbType.Bit, 1, "MOVESDATA.MOV3").Value = 0
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table1", "MOVESDATA", New DataColumnMapping() {New DataColumnMapping("MOVD1", "MOVD1"), New DataColumnMapping("MOVD2", "MOVD2"), New DataColumnMapping("MOVD3", "MOVD3"), New DataColumnMapping("MOVD4", "MOVD4"), New DataColumnMapping("MOVD5", "MOVD5"), New DataColumnMapping("MOVD6", "MOVD6"), New DataColumnMapping("MOVD7", "MOVD7"), New DataColumnMapping("MOVD8", "MOVD8"), New DataColumnMapping("MOVD9", "MOVD9"), New DataColumnMapping("MOVD10", "MOVD10"), New DataColumnMapping("MOV3", "MOV3"), New DataColumnMapping("MOV2", "MOV2")})})
            SqlDataAdapter2.UpdateCommand = CMD
            SqlDataAdapter2.Update(ds1, "MOVESDATA")
            SqlDataAdapter2.TableMappings.Clear()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUpdateMovesData", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub CHECK()
        If Val(Me.TEXTDebit.Text) <> Val(Me.TEXTCredit.Text) Then
            MessageBox.Show("اجمالى الطرف المدين لايساوى اجمالى الطرف الدائن", "حفظ سجل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
        End If
    End Sub

    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub

    Private Sub TEXTRegistrationNumber_LostFocus(ByVal sender As System.Object, ByVal e As EventArgs) Handles TEXTRegistrationNumber.LostFocus
        Static Dim P As Integer
        P = Me.BS.Position
        Me.DanLOd()
        Me.BS.Position = P
        Me.TEXTRegistrationNumber.Enabled = False
        TextJournalNo.Focus()
    End Sub
    Private Sub TEXTRegistrationNumber_GotFocus(sender As Object, e As EventArgs) Handles TEXTRegistrationNumber.GotFocus
        Me.TEXTRegistrationNumber.Enabled = True
        Me.SaveMOVES()
    End Sub
    Private Sub TEXT2_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles TEXTRegistrationNumber.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub




    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        Call MangUsers()
        If LockAddRow = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        SEARCHDATA.MAXIDMOVES()

        On Error Resume Next
        Me.BS.EndEdit()
        CLEARDATA1(Me)
        Application.DoEvents()
        Me.LoadData()
        Me.BS.CancelEdit()
        Me.BS.AddNew()
        Me.TEXTID.Text = T1
        Me.TEXTRegistrationNumber.EditValue = T2
        Me.TextJournalNo.Text = T3


        Me.TextMovementSymbol.EditValue = "RD" & Me.TEXTRegistrationNumber.EditValue
        Me.TextLSet.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
        Me.DATETIMEPICKER.Value = MaxDate.ToString("yyyy-MM-dd")
        Me.ComboEntryType.Text = "قيد"
        Me.TextJournalNo.Text = "1"
        Me.TEXTStatement.Text = ""

        Me.TEXTDebit.Text = "0"
        Me.TEXTCredit.Text = "0"
        Me.ADDBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = True
        DataGridView1.AutoGenerateColumns = True
        Me.TEXTRegistrationNumber.Enabled = True
        Me.TEXTRegistrationNumber.Focus()
    End Sub

    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockSave = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Static Dim P As Integer
            P = Me.BS.Position
            Me.TextMovementSymbol.EditValue = "RD" & Me.TEXTRegistrationNumber.EditValue
            Me.CHECK()
            Me.UPDATEMOVES()
            Me.SaveMOVESDATA()
            Me.DanLOd()
            Me.BS.Position = P
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.UPDATEMOVES()
            Me.SaveMOVESDATA()
            Me.BS.EndEdit()
            Me.RowCount = BS.Count
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Insert_Actions(Me.TEXTID.Text, "حفظ", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSAVEBUTTON", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name FROM ACCOUNTSTREE WHERE account_name = '" & Me.DataGridView1.CurrentRow.Cells("MOVD3").Value & " '", Consum)
        Dim dsACCOUNTSTREE As New DataSet
        Adp = New SqlDataAdapter(strsql)
        dsACCOUNTSTREE.Clear()
        Consum.Open()
        Adp.Fill(dsACCOUNTSTREE, "ACCOUNTSTREE")
        If Me.DataGridView1.CurrentCell.ColumnIndex = "MOVD3" Then
            If dsACCOUNTSTREE.Tables(0).Rows.Count > 0 Then
                Me.DataGridView1.CurrentRow.Cells("MOVD4").Value = dsACCOUNTSTREE.Tables(0).Rows(0).Item(0)
                Me.DataGridView1.CurrentRow.Cells("MOVD8").Value = dsACCOUNTSTREE.Tables(0).Rows(0).Item(1)
            End If
        End If


        Adp.Dispose()
        Consum.Close()
    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        Try

            If Me.DataGridView1.SelectedRows.Count = 0 Then
                Me.DataGridView1.Item("MOVD2", e.RowIndex).Value = Me.DataGridView1.CurrentRow.Index + 1
                If Me.DataGridView1.Item("MOVD5", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("MOVD5", e.RowIndex).Value = "0.000"
                If Me.DataGridView1.Item("MOVD6", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("MOVD6", e.RowIndex).Value = "0.000"
                Me.DataGridView1.Item("MOVD9", e.RowIndex).Value = Trim(Me.TextMovementSymbol.EditValue)
                Me.DataGridView1.Item("MOVD10", e.RowIndex).Value = Trim(Me.TEXTID.Text)
                'Me.DataGridView1.Item("MOV3", e.RowIndex).Value = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorDataGridView.CellEnter", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        On Error Resume Next
        'Exit Sub
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
        Try
            If Me.DataGridView1.SelectedRows.Count > 0 Then
                For i As Integer = Me.DataGridView1.SelectedRows.Count - 1 To 0
                    Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
                Next
            Else
                MsgBox("حدد الصف بشكل جيد ", MsgBoxStyle.Critical, "تنبيه")
            End If
            Exit Sub

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
        End Try
    End Sub

    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.CurrentCellChanged
        On Error Resume Next
        Dim total As Double = "0.000"
        Dim tota2 As Double = "0.000"
        For Each r As DataGridViewRow In Me.DataGridView1.Rows
            total += CDbl(r.Cells("MOVD5").Value)
            tota2 += CDbl(r.Cells("MOVD6").Value)
        Next
        Me.TEXTDebit.Text = total.ToString("0.000")
        Me.TEXTCredit.Text = tota2.ToString("0.000")
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        'If DataGridView1.CurrentCell.ColumnIndex = 1 Then
        If TypeOf e.Control Is DataGridViewComboBoxEditingControl Then
            'Dim comb As DataGridViewComboBoxEditingControl = TryCast(e.Control, DataGridViewComboBoxEditingControl)
            CType(e.Control, ComboBox).DropDownStyle = ComboBoxStyle.DropDown
            CType(e.Control, ComboBox).AutoCompleteSource = AutoCompleteSource.ListItems
            CType(e.Control, ComboBox).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        End If

        'End If

    End Sub


End Class