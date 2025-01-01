Option Explicit Off
Imports System.Data.SqlClient

Public Class FrmAllCustomers1
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0

    Private Sub FrmAllCustomers_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage5.Show()
    End Sub
    Private Sub FrmAllCustomers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.BtnAdd_Click(sender, e)
                Case Keys.F2
                    Me.BtnUpdate_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select

            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmAllCustomers1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TabPage1.BackgroundImage = img
        'For a As Byte = 0 To 10
        '    System.Threading.Thread.Sleep(10)
        '    Application.DoEvents()
        '    Me.Opacity = a / 10
        'Next
        Me.SHOWBUTTON()
        Me.btnAdd.Enabled = True
        Me.btnUpdate.Enabled = False
    End Sub
    Private Sub Text19_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextClass.SelectedIndexChanged
        Try
            If Me.TextClass.Text = "2" Then
                Me.Label3.Text = "الرقم الوطني _العسكري"
                Me.Label3.Location = New Point(314, 70)
                Me.lb1.Text = "الرتبــــــة"
                Me.lb1.Location = New Point(376, 119)
                Me.Label15.Text = "الوحـــــــــــدة"
                Me.Label15.Location = New Point(360, 146)
                Me.TextMilitaryNumber.Visible = True
                Me.TextNationalNo.Location = New Point(140, 70)
                Me.TextNationalNo.Width = CInt(173)
            Else
                Me.Label3.Text = "الرقم الوطني"
                Me.Label3.Location = New Point(362, 70)
                Me.lb1.Text = "المسمى الوظيفي"
                Me.lb1.Location = New Point(345, 119)
                Me.Label15.Text = "الدائرة _الادارة"
                Me.Label15.Location = New Point(351, 146)
                Me.TextMilitaryNumber.Visible = False
                Me.TextNationalNo.Location = New Point(4, 70)
                Me.TextNationalNo.Width = CInt(309)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub  AccountsEnquiry()
        'On Error Resume Next
        Try
            Select Case Me.TextClientType.Text
                Case "مساهم"
                    Me.CheckMember.Checked = True
                Case "مودئع"
                    Me.CheckMember.Checked = True
                Case "عميل"
                    Me.CheckMember.Checked = False
                Case "مساهم_مودئع"
                    Me.CheckMember.Checked = True
                Case "مساهم_عميل"
                    Me.CheckMember.Checked = True
                Case "مساهم_مودئع_عميل"
                    Me.CheckMember.Checked = True
                Case "مودئع_عميل"
                    Me.CheckMember.Checked = True
                Case "مساهم_كفيل"
                    Me.CheckMember.Checked = True
                Case "مودئع_كفيل"
                    Me.CheckMember.Checked = True
                Case "عميل_كفيل"
                    Me.CheckMember.Checked = False
                Case "كفيل_اول"
                    Me.CheckMember.Checked = False
                Case "كفيل_ثاني"
                    Me.CheckMember.Checked = False
            End Select
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SAVERECORD()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO AllCustomers( IDcust,  cust2, cust3, cust4, cust5, cust6, cust7, cust8, cust9, cust10, cust11, cust12, cust13, cust14, cust15, cust16, cust17, cust18, cust19, cust20, cust21,cust22, cust23, cust24, cust25, cust26, cust27, cust28, cust29, cust30, cust31, cust32, cust33, USERNAME, Cuser, COUSER, da, ne) VALUES     ( @IDcust,  @cust2, @cust3, @cust4, @cust5, @cust6, @cust7, @cust8, @cust9, @cust10, @cust11,@cust12, @cust13, @cust14, @cust15, @cust16, @cust17, @cust18, @cust19, @cust20, @cust21,@cust22, @cust23, @cust24, @cust25, @cust26, @cust27, @cust28, @cust29, @cust30, @cust31, @cust33, @cust33, @USERNAME, @Cuser, @COUSER, @da, @ne)"
            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDcust", SqlDbType.BigInt).Value = Me.TextMembersCode.EditValue
                .Parameters.Add("@cust2", SqlDbType.NVarChar).Value = Me.TextMembersName.Text.Trim
                .Parameters.Add("@cust3", SqlDbType.NVarChar).Value = Me.TextNationalNo.Text.Trim
                .Parameters.Add("@cust4", SqlDbType.NVarChar).Value = Me.TextMilitaryNumber.Text.Trim
                .Parameters.Add("@cust5", SqlDbType.NVarChar).Value = Me.TextPlaceOfBirth.Text.Trim
                .Parameters.Add("@cust6", SqlDbType.NVarChar).Value = Me.DateOfBirth.Text.Trim
                .Parameters.Add("@cust7", SqlDbType.NVarChar).Value = Me.TEXTADDRESS.Text.Trim
                .Parameters.Add("@cust8", SqlDbType.NVarChar).Value = Me.TEXTJobTitle.Text.Trim
                .Parameters.Add("@cust9", SqlDbType.NVarChar).Value = Me.TextDepartmentAdministration.Text.Trim
                .Parameters.Add("@cust10", SqlDbType.NVarChar).Value = Me.TextWorkAddress.Text
                .Parameters.Add("@cust11", SqlDbType.NVarChar).Value = Me.TEXTEMAIL.EditValue
                .Parameters.Add("@cust12", SqlDbType.NVarChar).Value = Me.TEXTPHONE.EditValue
                .Parameters.Add("@cust13", SqlDbType.NVarChar).Value = Me.TEXTFAX.EditValue
                .Parameters.Add("@cust14", SqlDbType.NVarChar).Value = Me.TEXTMOBILE.EditValue
                .Parameters.Add("@cust15", SqlDbType.NVarChar).Value = Me.TEXTBalance_shareLimit.Text
                .Parameters.Add("@cust16", SqlDbType.NVarChar).Value = Me.TextAffiliationFee.Text
                .Parameters.Add("@cust17", SqlDbType.NVarChar).Value = Me.TextGovernorate.Text
                .Parameters.Add("@cust18", SqlDbType.NVarChar).Value = Me.TextSex.Text
                .Parameters.Add("@cust19", SqlDbType.NVarChar).Value = Me.TextDegree.Text
                .Parameters.Add("@cust20", SqlDbType.NVarChar).Value = Me.TextClass.Text
                .Parameters.Add("@cust21", SqlDbType.NVarChar).Value = Me.TextCondition.Text
                .Parameters.Add("@cust22", SqlDbType.NVarChar).Value = Me.TextClientType.Text
                .Parameters.Add("@cust23", SqlDbType.NVarChar).Value = Me.TextNotebookName.Text.Trim
                .Parameters.Add("@cust24", SqlDbType.NVarChar).Value = Me.TextContributorPageNumber.Text.Trim
                .Parameters.Add("@cust25", SqlDbType.NVarChar).Value = Me.TextCustomerPageNumber.Text.Trim
                .Parameters.Add("@cust26", SqlDbType.NVarChar).Value = Me.TextAffiliationDecisionNumber.Text.Trim
                .Parameters.Add("@cust27", SqlDbType.NVarChar).Value = Me.JoinDate.Text.Trim
                .Parameters.Add("@cust28", SqlDbType.NVarChar).Value = Me.TextWithdrawalNumber.Text.Trim
                .Parameters.Add("@cust29", SqlDbType.NVarChar).Value = Me.DateWithdrawal.Text.Trim
                .Parameters.Add("@cust30", SqlDbType.NVarChar).Value = Me.TextTheJudiciary.Text.Trim
                .Parameters.Add("@cust31", SqlDbType.NVarChar).Value = Me.TEXTComments.Text.Trim
                .Parameters.Add("@cust32", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@cust33", SqlDbType.NVarChar).Value = Convert.ToInt32(Me.CheckMember.Checked)
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
            MessageBox.Show(ex.Message, "فشل حفظ حساب العضو\العميل ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()

1:          myds = New DataSet
            SqlDataAdapter1.Fill(myds, "AllCustomers")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                PictureBox2False()
                TestNet = False
                e.Cancel = True
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                PictureBox2False()
                e.Cancel = True
                MessageBox.Show(ex.Message, "Error3", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = myds.Tables("AllCustomers")
            Me.PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            If DelRow = False Then
                If Me.BS.Count < Me.RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 48 + 524288, "تحديث السجلات")
                ElseIf Me.BS.Count > Me.RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 48 + 524288, "تحديث السجلات")
                End If
            Else
                DelRow = False
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error4", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub RefreshData()
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            'Me.TextCOUser.Clear()
            Me.PictureBox2.Visible = True
            Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.RefreshTab.RunWorkerAsync()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:
            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.Update(myds, "AllCustomers")
            'myds = New DataSet
            'SqlDataAdapter1.Fill(myds, "AllCustomers")
            'myds.RejectChanges()
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
            If DelRow = True Then
                Me.RefreshData()
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = myds.Tables("AllCustomers")
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False

            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error6", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Consum.Close()
    End Sub
    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
        End If
    End Sub
    Private Sub MAXRECORD()
        On Error Resume Next
        Dim V As Integer
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT Max (AllCustomers.IDcust) FROM AllCustomers WHERE cuser = '" & CUser & "'", Consum)
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
            V = 1 & Val(CUser)
        Else
            V = (CType(resualt, Integer) + 1) & Val(CUser)

        End If
        Consum.Close()
        Me.TextMembersCode.EditValue = Val(V)
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.btnAdd.Enabled = LockAddRow
        Me.btnUpdate.Enabled = LockSave
        Me.ButtonXP4.Enabled = LockUpdate
        Me.CMDBROWSE.Enabled = LockPrint
    End Sub
    Private Sub RecordCount()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strSQL1 As New SqlClient.SqlCommand("SELECT * FROM MYDOCUMENTSHOME WHERE  LO='" & TextNationalNo.Text & "'", Consum)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim Adp1 As New SqlClient.SqlDataAdapter(strSQL1)
        ds.Clear()
        Adp1.Fill(ds, "MYDOCUMENTSHOME")
        Adp1.Fill(dt)
        DataGridView3.DataSource = ds
        DataGridView3.DataMember = "MYDOCUMENTSHOME"
        DataGridView3.Columns("DOC3").Visible = False
        DataGridView3.Columns("DOC6").Visible = False
        DataGridView3.Columns("DOC7").Visible = False
        DataGridView3.Columns("DOC8").Visible = False
        DataGridView3.Columns("date_1").Visible = False
        DataGridView3.Columns("USERNAME").Visible = False
        DataGridView3.Columns("CUser").Visible = False
        DataGridView3.Columns("COUser").Visible = False
        DataGridView3.Columns("DA").Visible = False
        DataGridView3.Columns("NE").Visible = False
        DataGridView3.Columns("DA1").Visible = False
        DataGridView3.Columns("NE1").Visible = False
    End Sub
    Private Sub TEXT2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextMembersName.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextClass.Focus()
        End Select
    End Sub
    Private Sub TEXT20_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextClass.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextNationalNo.Focus()
        End Select
    End Sub
    Private Sub TEXT3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextNationalNo.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                If Me.TextMilitaryNumber.Visible = True Then
                    Me.TextMilitaryNumber.Focus()
                Else
                    Me.TextPlaceOfBirth.Focus()
                End If

        End Select
    End Sub
    Private Sub TEXT4_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextMilitaryNumber.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextPlaceOfBirth.Focus()
        End Select
    End Sub
    Private Sub TEXT5_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextPlaceOfBirth.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.DateOfBirth.Focus()
        End Select
    End Sub
    Private Sub TEXT6_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateOfBirth.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTJobTitle.Focus()
        End Select
    End Sub
    Private Sub TEXT8_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTJobTitle.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextDepartmentAdministration.Focus()
        End Select
    End Sub
    Private Sub TEXT9_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextDepartmentAdministration.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextDegree.Focus()
        End Select
    End Sub
    Private Sub TEXT19_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextDegree.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextCondition.Focus()
        End Select
    End Sub
    Private Sub TEXT21_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextCondition.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextSex.Focus()
        End Select
    End Sub
    Private Sub TEXT18_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextSex.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextClientType.Focus()
        End Select
    End Sub
    Private Sub TEXT22_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextClientType.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTBalance_shareLimit.Focus()
        End Select
    End Sub
    Private Sub TEXT15_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTBalance_shareLimit.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextAffiliationFee.Focus()
        End Select
    End Sub
    Private Sub TEXT16_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextAffiliationFee.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextNotebookName.Focus()
        End Select
    End Sub
    Private Sub TEXT23_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextNotebookName.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextContributorPageNumber.Focus()
        End Select
    End Sub
    Private Sub TEXT24_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextContributorPageNumber.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextCustomerPageNumber.Focus()
        End Select
    End Sub
    Private Sub TEXT25_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextCustomerPageNumber.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextAffiliationDecisionNumber.Focus()
        End Select
    End Sub
    Private Sub TEXT26_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextAffiliationDecisionNumber.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.JoinDate.Focus()
        End Select
    End Sub
    Private Sub TEXT27_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles JoinDate.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextWithdrawalNumber.Focus()
        End Select
    End Sub
    Private Sub TEXT28_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextWithdrawalNumber.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.DateWithdrawal.Focus()
        End Select
    End Sub
    Private Sub TEXT29_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateWithdrawal.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTComments.Focus()
        End Select
    End Sub
    Private Sub TEXT31_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTComments.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTADDRESS.Focus()
        End Select
    End Sub
    Private Sub TEXT7_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTADDRESS.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextWorkAddress.Focus()
        End Select
    End Sub
    Private Sub TEXT10_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextWorkAddress.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextTheJudiciary.Focus()
        End Select
    End Sub
    Private Sub TEXT30_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextTheJudiciary.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextGovernorate.Focus()
        End Select
    End Sub
    Private Sub TEXT17_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextGovernorate.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTPHONE.Focus()
        End Select
    End Sub
    Private Sub TEXT12_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTFAX.Focus()
        End Select
    End Sub
    Private Sub TEXT13_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTMOBILE.Focus()
        End Select
    End Sub
    Private Sub TEXT14_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTEMAIL.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTEMAIL.Focus()
        End Select
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
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
            Me.BS.EndEdit()
            Me.BS.AddNew()
            CLEARDATA1(Me)
            Me.TextMembersName.Text = ""
            Me.TextNationalNo.Text = "0"
            Me.TextMilitaryNumber.Text = "0"
            Me.TextPlaceOfBirth.Text = ""
            Me.DateOfBirth.Text = ""
            Me.TEXTADDRESS.Text = ""
            Me.TEXTJobTitle.SelectedIndex = 0
            Me.TextDepartmentAdministration.Text = ""
            Me.TextWorkAddress.Text = ""
            Me.TEXTEMAIL.EditValue = "CC_JO@gmail.com"
            Me.TEXTPHONE.EditValue = "07"
            Me.TEXTFAX.EditValue = "07"
            Me.TEXTMOBILE.EditValue = "07"
            Me.TEXTBalance_shareLimit.Text = "0.000"
            Me.TextAffiliationFee.Text = "0.000"
            Me.TextGovernorate.SelectedItem = Directorate
            Me.TextSex.SelectedIndex = 0
            Me.TextDegree.SelectedIndex = 0
            Me.TextClass.SelectedIndex = 0
            Me.TextCondition.SelectedIndex = 0
            Me.TextClientType.SelectedIndex = 0
            Me.TextNotebookName.SelectedIndex = 0
            Me.TextContributorPageNumber.Text = "0"
            Me.TextCustomerPageNumber.Text = "0"
            Me.TextAffiliationDecisionNumber.Text = "0"
            Me.JoinDate.Value = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextWithdrawalNumber.Text = "0"
            Me.DateWithdrawal.Text = ""
            Me.TextTheJudiciary.Text = "محكمة بداية حقوق" & " " & Directorate
            Me.TEXTComments.Text = "انظمام جديد"
            MAXAllCustomers()
            Me.TextMembersCode.EditValue = SEARCHDATA.MAXIDAllCustomers
            'Label4.Text = LSet(Me.TextMembersCode.EditValue, 5)
            'Label15.Text = Mid(Me.TextMembersCode.EditValue, 5, 4)
            Me.TEXTCUser.Text = CUser
            Me.TextCOUser.Text = COUser
            Me.CheckMember.Checked = True
            Me.btnUpdate.Enabled = True
            Me.btnAdd.Enabled = False
            Me.TextMembersName.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        'If BS.Count = 0 Then Beep() : Exit Sub
        If LockSave = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Count
        Me.RecordCount()
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.SAVERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.SHOWBUTTON()
        Me.btnAdd.Enabled = True
        Me.btnUpdate.Enabled = False
        Insert_Actions(Me.TextMembersCode.EditValue, "حفظ", Me.Text)
    End Sub
    Private Sub Text22_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextClientType.SelectedIndexChanged
        Me. AccountsEnquiry()
    End Sub
    Private Sub ButtonXP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP4.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
           Dim XLO As Int64
            XLO = Me.DataGridView3.RowCount
            Dim f As New FrmJPG0
            f.ADDBUTTON.Enabled = False
            f.SAVEBUTTON.Enabled = True
            f.ButScan.Enabled = True
            f.ButSaveFile.Enabled = False
            f.ButLogq.Enabled = True
            f.ButEditImage.Enabled = False
            f.Show()
            f.ADDBUTTON_Click(sender, e)
            f.BS.Position = BS.Count - 1
            f.BS.EndEdit()
            f.BS.AddNew()
            CLEARDATA1(Me)
            f.DateP1.Text = ServerDateTime.ToString("yyyy-MM-dd")
            f.TextLO.Text = TextNationalNo.Text
            f.TEXTFileNo.Text = Val(XLO) + 1
            f.TEXTFileSubject.Text = "مستندات الإعضاء \ العملاء"
            f.TextFileDescription.Text = ""
            f.PictureBox1.Image = Nothing
            f.TEXTBOX1.Enabled = False
            f.TextLO.Enabled = False
            f.TEXTFileNo.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Dim ds As New DataSet
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim f As New FrmJPG
            ds.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand(String.Concat(New String() {"SELECT DOC1 FROM MYDOCUMENTSHOME WHERE  CUser='", ModuleGeneral.CUser, "' and DOC1 ='", Trim(Me.TextBox5.Text), "'"}), Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "MYDOCUMENTSHOME")
            f.BS.DataMember = "MYDOCUMENTSHOME"
            f.BS.DataSource = ds
            f.PictureBox1.Dock = DockStyle.Fill
            Dim txt As Control
            For Each txt In f.Controls
                If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Or TypeOf txt Is Label Or TypeOf txt Is Panel Then
                    txt.Visible = False
                End If
            Next
            Dim index As Integer
            If ds.Tables(0).Rows(0).Item("DOC1") = Me.TextBox5.Text Then
                index = f.BS.Find(NameOf(DOC1), Me.TextBox5.Text)
                f.Show()
                f.TEXTBOX1.Text = Trim(Me.TextBox5.Text)
                f.FrmJPG_Load(sender, e)
                f.DanLOd()
                f.BS.Position = index
                f.RecordCount()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()

    End Sub
    Private Sub DataGridView3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellEnter
        Try
            TextBox5.Text = CDbl(DataGridView3("DOC1", DataGridView3.CurrentRow.Index).Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub DataGridView3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView3.DoubleClick
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Dim ds As New DataSet
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim f As New FrmJPG
            ds.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand(String.Concat(New String() {"SELECT DOC1 FROM MYDOCUMENTSHOME WHERE  CUser='", ModuleGeneral.CUser, "' and DOC1 ='", Trim(Me.TextBox5.Text), "'"}), Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "MYDOCUMENTSHOME")
            f.BS.DataMember = "MYDOCUMENTSHOME"
            f.BS.DataSource = ds
            f.PictureBox1.Dock = DockStyle.Fill
            Dim txt As Control
            For Each txt In f.Controls
                If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Or TypeOf txt Is Label Or TypeOf txt Is Panel Then
                    txt.Visible = False
                End If
            Next
            Dim index As Integer
            If ds.Tables(0).Rows(0).Item("DOC1") = Me.TextBox5.Text Then
                index = f.BS.Find(NameOf(DOC1), Me.TextBox5.Text)
                f.Show()
                f.TEXTBOX1.Text = Trim(Me.TextBox5.Text)
                f.FrmJPG_Load(sender, e)
                f.DanLOd()
                f.BS.Position = index
                f.RecordCount()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub

    Private Sub TextTheJudiciary_Enter(sender As Object, e As EventArgs) Handles TEXTEMAIL.Enter, TextWorkAddress.Enter, TextTheJudiciary.Enter, TextPlaceOfBirth.Enter, TextMembersName.Enter, TextDepartmentAdministration.Enter, TEXTADDRESS.Enter, TEXTComments.Enter
        ChangeToArabic()
    End Sub
    Private Sub TEXTEMAIL_Enter(sender As Object, e As EventArgs) Handles TEXTEMAIL.Enter, TextWithdrawalNumber.Enter, TEXTPHONE.Enter, TEXTMOBILE.Enter, TEXTFAX.Enter, TextCustomerPageNumber.Enter, TextContributorPageNumber.Enter, TEXTBalance_shareLimit.Enter, TextAffiliationFee.Enter, TextAffiliationDecisionNumber.Enter
        ChangeToEnglish()
    End Sub
    Private Sub TextNationalNo_Enter(sender As Object, e As EventArgs) Handles TextNationalNo.Enter, TextMilitaryNumber.Enter
        ChangeToEnglish()
    End Sub

End Class