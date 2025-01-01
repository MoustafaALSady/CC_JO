Option Explicit Off

Imports System.Data.SqlClient
Public Class FrmChecks1
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Private ReadOnly myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub
    Private Sub FrmChecks1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            Me.SHOWBUTTON()
            Me.AddType1()
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            'Me.ComboCheckStatus.DataSource = GetDataCheck()
            'Me.ComboCheckStatus.DisplayMember = "account_name"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Call MangUsers()
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If


            Me.BS.Position = Me.BS.Count - 1

            Me.BS.EndEdit()
            Me.BS.AddNew()
            CLEARDATA1(Me)

            GetAutoNumber("IDCH", "Checks", "CH2")
            Me.TEXTID.EditValue = AutoNumber

            Me.TextMovementSymbol.EditValue = "KS" & Me.TEXTID.EditValue
            Me.DateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
            Me.TEXTDebit.EditValue = 0
            Me.TEXTCredit.EditValue = 0
            FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
            If ComboBN2.Items.Count > 0 Then
                Me.ComboBN2.SelectedIndex = 0
            End If
            'Me.TextBN3.Text = BANK
            'Me.TextBN4.Text = Directorate
            Me.TEXTStatement.Text = "سحب بشيك بنكي "
            Me.ComboCheckStatus.Text = "جاري"
            Me.TEXTDebit.EditValue = "0.00"
            Me.TEXTCredit.EditValue = "0.00"
            Me.ComboConstraintType.Text = "صرف"
            Me.ComboCurrentCheckStatus.Text = "جاري"
            Me.DateMovementHistory.Focus()
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            Dim Sound As System.IO.Stream = My.Resources.addv
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:

        Catch ex As Exception
            If ex.Message.GetHashCode = -1115812848 Or ex.Message.GetHashCode = 379362862 Then
                e.Cancel = True
                PictureBox2False()
            ElseIf ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                e.Cancel = True
                TestNet = False
                PictureBox2False()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            ElseIf ex.Message.GetHashCode = -652120241 Or ex.Message.GetHashCode = 2067669773 Then
                DelRow = True
                PictureBox2False()
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
            Else
                e.Cancel = True
                PictureBox2False()
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            Application.DoEvents()
            BS.DataSource = myds.Tables("Checks")
            TEXTCredit.Enabled = True
            Me.Cursor = Cursors.Default
            PictureBox2.Visible = False
            If BS.Count < RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf BS.Count > RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & BS.Count - RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
            Dim Sound As System.IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            If Click1 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "حفظ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            End If
            Click1 = False
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error6", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockSave = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If

        Static P As Integer
        P = BS.Count
        Me.SAVERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        Click1 = True
    End Sub

    Private Sub SAVERECORD()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO Checks(  IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26, CB1, BN2, USERNAME, CUser, COUser, da, ne) VALUES     (  @IDCH, @CH1, @CH2, @CH3, @CH4, @CH5, @CH6, @CH7, @CH8, @CH9, @CH10, @CH11, @CH12, @CH13, @CH14, @CH15, @CH16, @CH17, @CH18, @CH19, @CH20, @CH21, @CH22, @CH23, @CH24, @CH25, @CH26,  @CB1,  @BN2, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDCH", SqlDbType.BigInt).Value = TEXTID.EditValue
                .Parameters.Add("@CH1", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text.Trim
                .Parameters.Add("@CH2", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CH3", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CH4", SqlDbType.NVarChar).Value = Me.ComboCheckStatus.Text.Trim
                .Parameters.Add("@CH5", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@CH6", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@CH7", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text.Trim
                .Parameters.Add("@CH8", SqlDbType.NVarChar).Value = Me.TextCheckDrawerNumber.Text.Trim
                .Parameters.Add("@CH9", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text.Trim
                .Parameters.Add("@CH10", SqlDbType.NVarChar).Value = Me.ComboConstraintType.Text.Trim
                .Parameters.Add("@CH11", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text.Trim
                .Parameters.Add("@CH12", SqlDbType.NVarChar).Value = Me.TextBN3.Text.Trim
                .Parameters.Add("@CH13", SqlDbType.Date).Value = RightDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CH14", SqlDbType.NVarChar).Value = Me.TextBN4.Text.Trim
                .Parameters.Add("@CH15", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckEW.Checked)
                .Parameters.Add("@CH16", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CH17", SqlDbType.Bit).Value = False
                .Parameters.Add("@CH18", SqlDbType.Bit).Value = False
                .Parameters.Add("@CH19", SqlDbType.Bit).Value = False
                .Parameters.Add("@CH20", SqlDbType.Bit).Value = True
                .Parameters.Add("@CH21", SqlDbType.Bit).Value = False
                .Parameters.Add("@CH22", SqlDbType.Bit).Value = False
                .Parameters.Add("@CH23", SqlDbType.Bit).Value = False
                .Parameters.Add("@CH24", SqlDbType.NVarChar).Value = "0"
                .Parameters.Add("@CH25", SqlDbType.NVarChar).Value = Me.TextPreviousCheckStatus.Text.Trim
                .Parameters.Add("@CH26", SqlDbType.NVarChar).Value = Me.ComboCurrentCheckStatus.Text.Trim
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = "0"
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text.Trim

                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioResetText.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub AddType1()
        On Error Resume Next
        If Me.RadioAllCustomers.Checked = True Then
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioSUPPLIER.Checked = True Then
            FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioEMPLOYEES.Checked = True Then
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboCheckDrawerName)
        Else
            Me.ComboCheckDrawerName.ResetText()
            Me.TextCheckDrawerNumber.ResetText()
        End If
        Me.ComboCheckDrawerName.Focus()
    End Sub
    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Me.RadioAllCustomers.Checked = True Then
                Dim Adp As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlClient.SqlDataAdapter(strsql)
                ds.Clear()
                Adp.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerNumber.Text = ds.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerNumber.Text = ""
                End If
                Adp.Dispose()
                Consum.Close()
            ElseIf Me.RadioSUPPLIER.Checked = True Then
                Dim Adp1 As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds1 As New DataSet
                Adp1 = New SqlClient.SqlDataAdapter(strsql)
                ds1.Clear()
                Adp1.Fill(ds1)
                If ds1.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerNumber.Text = ds1.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerNumber.Text = ""
                End If
                Adp1.Dispose()
                Consum.Close()
            ElseIf Me.RadioEMPLOYEES.Checked = True Then
                Dim Adp2 As SqlClient.SqlDataAdapter
                Dim strsq2 As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds2 As New DataSet
                Adp2 = New SqlClient.SqlDataAdapter(strsq2)
                ds2.Clear()
                Adp2.Fill(ds2)
                If ds2.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerNumber.Text = ds2.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerNumber.Text = ""
                End If
                Adp2.Dispose()
                Consum.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboCheckDrawerName", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TEXTBOX10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboConstraintType.SelectedIndexChanged
        On Error Resume Next
         AccountsEnquiry()
    End Sub

    Private Sub  AccountsEnquiry()
        On Error Resume Next
        Select Case Me.ComboConstraintType.Text
            Case "قبض"
                Me.CheckEW.Checked = False
                Me.TEXTDebit.EditValue = 0
                Me.TEXTDebit.Enabled = True
                Me.TEXTCredit.Enabled = False
            Case "صرف"
                Me.CheckEW.Checked = True
                Me.TEXTCredit.EditValue = 0
                Me.TEXTDebit.Enabled = False
                Me.TEXTCredit.Enabled = True

        End Select
    End Sub

    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBN2.SelectedIndexChanged
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim Adp As SqlClient.SqlDataAdapter
            Dim strsql As New SqlCommand("SELECT BN3,BN4    FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
            Dim ds As New DataSet
            Adp = New SqlClient.SqlDataAdapter(strsql)
            ds.Clear()
            Consum.Open()
            Adp.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TextBN3.Text = ds.Tables(0).Rows(0).Item(0)
                Me.TextBN4.Text = ds.Tables(0).Rows(0).Item(1)
            Else
                Me.TextBN3.Text = ""
                Me.TextBN4.Text = ""
            End If
            Adp.Dispose()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboCB1_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class