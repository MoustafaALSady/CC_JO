Option Explicit Off

Imports System.Data.SqlClient

Public Class FrmAllCustomers
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    ReadOnly ds As New DataSet

    Public SqlDataAdapter1 As New SqlDataAdapter
    Public SqlDataAdapter2 As New SqlDataAdapter

    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker

    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()

    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Public TB1 As String
    Public TB2 As String
    Public APALL As Boolean = False
    Public APALL1 As Boolean = False
    Private Sub FrmAllCustomers_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage3.Show()
        Me.TabPage5.Show()
        Me.TabPage4.Show()
    End Sub
    Private Sub FrmAllCustomers_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TabPage1.BackgroundImage = img
        'For a As Byte = 0 To 10
        '    System.Threading.Thread.Sleep(10)
        '    Application.DoEvents()
        '    Me.Opacity = a / 10
        'Next
        Me.EDITBUTTON.Enabled = False
        Me.BUTTONCANCEL.Enabled = False
        Me.PRINTBUTTON.Enabled = False
        Me.DELETEBUTTON.Enabled = False
        Me.ButtonSearch.Enabled = False
        Me.ButtonDisplyAll.Enabled = False
        Me.ButtonUpdateA.Enabled = False
        Me.ButtonEXPORTTPEXCEL.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonAttachDocument.Enabled = False
        Me.ButtonViewDocuments.Enabled = False
        Me.btnNavFirst.Enabled = False
        Me.btnNavPrev.Enabled = False
        Me.btnNavNext.Enabled = False
        Me.btnLast.Enabled = False
        Me.BackW2.WorkerReportsProgress = True
        Me.BackW2.WorkerSupportsCancellation = True


    End Sub
    Public Sub Load1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles load1.Click
        On Error Resume Next
        Me.ConnectDataBase = New ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
        Me.load1.Enabled = False
    End Sub
    Private Sub FrmAllCustomers_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If Me.CheckLogReview.Checked = True Then
                Me.KeyPreview = False
            Else
                Me.KeyPreview = True
                Select Case e.KeyCode
                    Case Keys.F3
                        Me.EDITBUTTON_Click(sender, e)
                    Case Keys.F4
                        Me.BUTTONCANCEL_Click(sender, e)
                    Case Keys.F5
                        Me.PRINTBUTTON_Click(sender, e)
                    Case Keys.F6
                        Me.DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        Me.InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        Me.ButtonCancellationAuditingAndACheckingAccounts_Click(sender, e)
                    Case Keys.R And (e.Alt And Not e.Control And Not e.Shift)
                        Me.ButtonUpdateA_Click(sender, e)
                    Case Keys.PageDown
                        Me.BtnNavPrev_Click(sender, e)
                    Case Keys.PageUp
                        Me.BtnNavNext_Click(sender, e)
                    Case Keys.Escape
                        Me.Close()
                End Select
            End If
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Text19_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextClass.SelectedIndexChanged
        Try
            If Me.TextClass.Text = "2" Then
                Me.Label3.Text = "الرقم الوطني _العسكري"
                Me.Label3.Location = New Point(324, 27)
                Me.lb1.Text = "الرتبــــــة"
                Me.lb1.Location = New Point(387, 73)
                Me.Label15.Text = "الوحـــــــــــدة"
                Me.Label15.Location = New Point(370, 98)
                Me.TextMilitaryNumber.Visible = True
                Me.TextNationalNo.Location = New Point(141, 26)
                Me.TextNationalNo.Width = CInt(174)
            Else
                Me.Label3.Text = "الرقم الوطني"
                Me.Label3.Location = New Point(373, 27)
                Me.lb1.Text = "المسمى الوظيفي"
                Me.lb1.Location = New Point(356, 73)
                Me.Label15.Text = "الدائرة _الادارة"
                Me.Label15.Location = New Point(362, 98)
                Me.TextMilitaryNumber.Visible = False
                Me.TextNationalNo.Location = New Point(3, 26)
                Me.TextNationalNo.Width = CInt(312)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub AccountsEnquiry()
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
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:

            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)

            With strSQL
                If APALL = False And Me.APALL1 = False Then
                    .CommandText = "SELECT  IDcust, cust2, cust3, cust4, cust5, cust6, cust7, cust8, cust9, cust10, cust11, cust12, cust13, cust14, cust15, cust16, cust17, cust18, cust19, cust20, cust21,cust22, cust23, cust24, cust25, cust26, cust27, cust28, cust29, cust30, cust31, cust32, cust33, USERNAME, Auditor, Cuser, COUSER, da, ne, da1, ne1 FROM AllCustomers  WHERE  CUser='" & CUser & "' and cust2 ='" & Trim(Me.TB2) & "'" & "or cust3 ='" & Trim(Me.TB1) & "'"
                ElseIf APALL = True Then
                    .CommandText = "SELECT  IDcust, cust2, cust3, cust4, cust5, cust6, cust7, cust8, cust9, cust10, cust11, cust12, cust13, cust14, cust15, cust16, cust17, cust18, cust19, cust20, cust21,cust22, cust23, cust24, cust25, cust26, cust27, cust28, cust29, cust30, cust31, cust32, cust33, USERNAME, Auditor, Cuser, COUSER, da, ne, da1, ne1 FROM AllCustomers  WHERE  CUser='" & CUser & "' "
                ElseIf APALL1 = True Then
                    .CommandText = "SELECT  IDcust, cust2, cust3, cust4, cust5, cust6, cust7, cust8, cust9, cust10, cust11, cust12, cust13, cust14, cust15, cust16, cust17, cust18, cust19, cust20, cust21,cust22, cust23, cust24, cust25, cust26, cust27, cust28, cust29, cust30, cust31, cust32, cust33, USERNAME, Auditor, Cuser, COUSER, da, ne, da1, ne1 FROM AllCustomers  WHERE  COUser='" & COUser & "'  "
                End If

            End With
            Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)

            Me.myds.Clear()
            Me.myds = New DataSet
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.myds, "AllCustomers")
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Consum.Close()
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            Consum.Close()
        End Try
    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then
                Me.PictureBox4.Image = ImageList2.Images(2)
                Me.Label2.ForeColor = Color.Yellow
                Me.Label2.Text = "... تم الاتصال بالانترنت"
            Else
                Me.Label2.ForeColor = Color.Red
                Me.Label2.Text = "الاتصال بالانترنت غير متوفر"
                Me.Close()
            End If
        End If
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.myds.Tables("AllCustomers")
            Me.RowCount = Me.BS.Count
            With Me
                .TextMembersCode.DataBindings.Add("text", Me.BS, "IDcust", True, 1, "")
                .TextMembersName.DataBindings.Add("text", Me.BS, "cust2", True, 1, "")
                .TextNationalNo.DataBindings.Add("text", Me.BS, "cust3", True, 1, "")
                .TextMilitaryNumber.DataBindings.Add("text", Me.BS, "cust4", True, 1, "")
                .TextPlaceOfBirth.DataBindings.Add("text", Me.BS, "cust5", True, 1, "")
                .DateOfBirth.DataBindings.Add("text", Me.BS, "cust6", True, 1, "")
                .TEXTADDRESS.DataBindings.Add("text", Me.BS, "cust7", True, 1, "")
                .TEXTJobTitle.DataBindings.Add("text", Me.BS, "cust8", True, 1, "")
                .TextDepartmentAdministration.DataBindings.Add("text", Me.BS, "cust9", True, 1, "")
                .TextWorkAddress.DataBindings.Add("text", Me.BS, "cust10", True, 1, "")
                .TEXTEMAIL.DataBindings.Add("text", Me.BS, "cust11", True, 1, "")
                .TEXTPHONE.DataBindings.Add("text", Me.BS, "cust12", True, 1, "")
                .TEXTFAX.DataBindings.Add("text", Me.BS, "cust13", True, 1, "")
                .TEXTMOBILE.DataBindings.Add("text", Me.BS, "cust14", True, 1, "")
                .TEXTBalance_shareLimit.DataBindings.Add("text", Me.BS, "cust15", True, 1, "")
                .TextAffiliationFee.DataBindings.Add("text", Me.BS, "cust16", True, 1, "")
                .TextGovernorate.DataBindings.Add("text", Me.BS, "cust17", True, 1, "")
                .TextSex.DataBindings.Add("text", Me.BS, "cust18", True, 1, "")
                .TextDegree.DataBindings.Add("text", Me.BS, "cust19", True, 1, "")
                .TextClass.DataBindings.Add("text", Me.BS, "cust20", True, 1, "")
                .TextCondition.DataBindings.Add("text", Me.BS, "cust21", True, 1, "")
                .TextClientType.DataBindings.Add("text", Me.BS, "cust22", True, 1, "")
                .TextNotebookName.DataBindings.Add("text", Me.BS, "cust23", True, 1, "")
                .TextContributorPageNumber.DataBindings.Add("text", Me.BS, "cust24", True, 1, "")
                .TextCustomerPageNumber.DataBindings.Add("text", Me.BS, "cust25", True, 1, "")
                .TextAffiliationDecisionNumber.DataBindings.Add("text", Me.BS, "cust26", True, 1, "")
                .JoinDate.DataBindings.Add("text", Me.BS, "cust27", True, 1, "")
                .TextWithdrawalNumber.DataBindings.Add("text", Me.BS, "cust28", True, 1, "")
                .DateWithdrawal.DataBindings.Add("text", Me.BS, "cust29", True, 1, "")
                .TextTheJudiciary.DataBindings.Add("text", Me.BS, "cust30", True, 1, "")
                .TEXTComments.DataBindings.Add("text", Me.BS, "cust31", True, 1, "")
                .CheckLogReview.DataBindings.Add("Checked", Me.BS, "cust32", True, 1, "")
                .CheckMember.DataBindings.Add("Checked", Me.BS, "cust33", True, 1, "")
                .TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
                .TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
                .TEXTCUser.DataBindings.Add("text", Me.BS, "CUser", True, 1, "")
                .TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
                .TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
                .TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
                .TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
                .TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")
            End With

            Me.RecordCount()
            Me.List1.DataSource = Me.BS
            Me.List1.DisplayMember = "cust2"
            Me.DataGridView1.DataSource = Me.BS

            Me.DataGridView1.Columns(3).Visible = False
            Me.DataGridView1.Columns(4).Visible = False
            Me.DataGridView1.Columns(5).Visible = False
            Me.DataGridView1.Columns(7).Visible = False
            Me.DataGridView1.Columns(8).Visible = False
            Me.DataGridView1.Columns(9).Visible = False
            Me.DataGridView1.Columns(10).Visible = False
            Me.DataGridView1.Columns(11).Visible = False
            Me.DataGridView1.Columns(12).Visible = False
            'Me.DataGridView1.Columns(13).Visible = False
            Me.DataGridView1.Columns(14).Visible = False
            Me.DataGridView1.Columns(15).Visible = False
            Me.DataGridView1.Columns(16).Visible = False
            Me.DataGridView1.Columns(17).Visible = False
            Me.DataGridView1.Columns(18).Visible = False
            Me.DataGridView1.Columns(19).Visible = False
            Me.DataGridView1.Columns(20).Visible = False
            Me.DataGridView1.Columns(21).Visible = False
            Me.DataGridView1.Columns(22).Visible = False
            Me.DataGridView1.Columns(23).Visible = False
            Me.DataGridView1.Columns(24).Visible = False
            Me.DataGridView1.Columns(25).Visible = False
            Me.DataGridView1.Columns(26).Visible = False
            Me.DataGridView1.Columns(27).Visible = False
            Me.DataGridView1.Columns(28).Visible = False
            Me.DataGridView1.Columns(29).Visible = False
            Me.DataGridView1.Columns(30).Visible = False
            Me.DataGridView1.Columns(31).Visible = False
            Me.DataGridView1.Columns(32).Visible = False
            Me.DataGridView1.Columns(33).Visible = False
            Me.DataGridView1.Columns(34).Visible = False
            Me.DataGridView1.Columns(35).Visible = False
            Me.DataGridView1.Columns(36).Visible = False
            Me.DataGridView1.Columns(37).Visible = False
            Me.DataGridView1.Columns(38).Visible = False
            Me.DataGridView1.Columns(39).Visible = False
            Me.DataGridView1.Columns(40).Visible = False
            'Me.DataGridView1.Columns(41).Visible = False
            Me.InternalAuditorType()
            Me.BUTTONCANCEL.Enabled = True
            Call MangUsers()
            If APALL = False And Me.APALL1 = False Then
                Me.SHOWBUTTON()
            ElseIf APALL = True Then
                Me.SHOWBUTTON()
            ElseIf APALL1 = True Then
                Me.SHOWBUTTON1()
            End If
            Me.TextCOUser.Text = COUser
            Me.TEXTCUser.Text = CUser

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Consum.Close()
    End Sub
    Private Sub UPDATERECORD()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim sql As New SqlCommand("UPDATE AllCustomers SET  cust2 = @cust2, cust3 = @cust3, cust4 = @cust4, cust5 = @cust5, cust6 = @cust6, cust7 = @cust7, cust8 = @cust8 , cust9 = @cust9, cust10 = @cust10, cust11 = @cust11,cust12 = @cust12, cust13 = @cust13, cust14 = @cust14, cust15 = @cust15, cust16 = @cust16, cust17 = @cust17, cust18 = @cust18 , cust19 = @cust19, cust20 = @cust20, cust21 = @cust21,cust22 = @cust22, cust23 = @cust23, cust24 = @cust24, cust25 = @cust25, cust26 = @cust26, cust27 = @cust27, cust28 = @cust28 , cust29 = @cust29, cust30 = @cust30, cust31 = @cust31, cust32 = @cust32, cust33 = @cust33, USERNAME = @USERNAME, Cuser = @Cuser, COUSER = @COUSER, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE IDcust = @IDcust", Consum)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDcust", SqlDbType.BigInt).Value = Me.TextMembersCode.EditValue
                '.Parameters.AddWithValue("@IDcust", x)
                .Parameters.Add("@cust2", SqlDbType.NVarChar).Value = Me.TextMembersName.Text
                .Parameters.Add("@cust3", SqlDbType.NVarChar).Value = Me.TextNationalNo.Text
                .Parameters.Add("@cust4", SqlDbType.NVarChar).Value = Me.TextMilitaryNumber.Text
                .Parameters.Add("@cust5", SqlDbType.NVarChar).Value = Me.TextPlaceOfBirth.Text
                .Parameters.Add("@cust6", SqlDbType.NVarChar).Value = Me.DateOfBirth.Text
                .Parameters.Add("@cust7", SqlDbType.NVarChar).Value = Me.TEXTADDRESS.Text
                .Parameters.Add("@cust8", SqlDbType.NVarChar).Value = Me.TEXTJobTitle.Text
                .Parameters.Add("@cust9", SqlDbType.NVarChar).Value = Me.TextDepartmentAdministration.Text
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
                .Parameters.Add("@cust23", SqlDbType.NVarChar).Value = Me.TextNotebookName.Text
                .Parameters.Add("@cust24", SqlDbType.NVarChar).Value = Me.TextContributorPageNumber.Text
                .Parameters.Add("@cust25", SqlDbType.NVarChar).Value = Me.TextCustomerPageNumber.Text
                .Parameters.Add("@cust26", SqlDbType.NVarChar).Value = Me.TextAffiliationDecisionNumber.Text
                .Parameters.Add("@cust27", SqlDbType.NVarChar).Value = Me.JoinDate.Text
                .Parameters.Add("@cust28", SqlDbType.NVarChar).Value = Me.TextWithdrawalNumber.Text
                .Parameters.Add("@cust29", SqlDbType.NVarChar).Value = Me.DateWithdrawal.Text
                .Parameters.Add("@cust30", SqlDbType.NVarChar).Value = Me.TextTheJudiciary.Text
                .Parameters.Add("@cust31", SqlDbType.NVarChar).Value = Me.TEXTComments.Text
                .Parameters.Add("@cust32", SqlDbType.NVarChar).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@cust33", SqlDbType.NVarChar).Value = Convert.ToInt32(Me.CheckMember.Checked)
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = sql.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()

            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل تعديل حساب العضو\العميل ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Count()
        On Error Resume Next
        Me.lblNavLocation.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub
    Private Sub LblNavLocation_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Label1.TextChanged
        On Error Resume Next
        Me.Count()
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
            Dim Consum As New SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
1:
            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "AllCustomers")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                Me.PictureBox2False()
                TestNet = False
                e.Cancel = True
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                Me.PictureBox2False()
                e.Cancel = True
                MessageBox.Show(ex.Message, "Error3", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.myds.Tables("AllCustomers")
            Me.PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            Count()
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
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                Me.ButtonUpdateA_Click(sender, e)
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = Me.myds.Tables("AllCustomers")
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.Count()
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
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.ButtonUpdateA.Enabled = True
        Me.ButtonSearch.Enabled = True
        Me.ButtonDisplyAll.Enabled = True
        Me.ButtonEXPORTTPEXCEL.Enabled = True
        Me.ButtonAttachDocument.Enabled = LockUpdate
        Me.ButtonViewDocuments.Enabled = LockPrint
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
    End Sub
    Public Sub SHOWBUTTON1()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = False
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.DELETEBUTTON.Enabled = False
        Me.ButtonUpdateA.Enabled = False
        Me.ButtonSearch.Enabled = True
        Me.ButtonDisplyAll.Enabled = True
        Me.ButtonEXPORTTPEXCEL.Enabled = False
        Me.ButtonAttachDocument.Enabled = False
        Me.ButtonViewDocuments.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        Me.DataGridView3.Enabled = False
    End Sub
    Private Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        lblNavLocation.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.myds.Tables("AllCustomers").Rows.Count - 1 Then
            Forward = True
        End If
        Me.btnNavFirst.Enabled = Back
        Me.btnNavPrev.Enabled = Back
        Me.btnNavNext.Enabled = Forward
        Me.btnLast.Enabled = Forward
        Me.InternalAuditorType()
        Dim Consum As New SqlConnection(constring)
        Dim strSQL1 As New SqlCommand("SELECT  DOC1, LO, DOC2, DOC4, DOC5 FROM MYDOCUMENTSHOME WHERE  CUser='" & ModuleGeneral.CUser & "' and LO ='" & Me.TextNationalNo.Text.Trim & "'", Consum)
        Me.SqlDataAdapter2 = New SqlDataAdapter(strSQL1)
        Me.ds.Clear()
        Consum.Open()
        Me.SqlDataAdapter2.Fill(Me.ds, "MYDOCUMENTSHOME")
        Consum.Close()
        Me.DataGridView3.DataSource = Me.ds
        Me.DataGridView3.DataMember = "MYDOCUMENTSHOME"
        Me.TextCOUser.Text = COUser
    End Sub
    Private Sub BtnNavFirst_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNavFirst.Click
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub
    Private Sub BtnNavPrev_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNavPrev.Click
        On Error Resume Next
        Me.BS.Position = BS.Position - 1
        Me.RecordCount()
    End Sub
    Private Sub BtnNavNext_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNavNext.Click
        On Error Resume Next
        Me.BS.Position = BS.Position + 1
        Me.RecordCount()
    End Sub
    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnLast.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub
    Private Sub TEXT2_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextMembersName.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextClass.Focus()
        End Select
    End Sub
    Private Sub TEXT20_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextClass.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextNationalNo.Focus()
        End Select
    End Sub
    Private Sub TEXT3_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextNationalNo.KeyUp
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
    Private Sub TEXT4_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextMilitaryNumber.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextPlaceOfBirth.Focus()
        End Select
    End Sub
    Private Sub TEXT5_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextPlaceOfBirth.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.DateOfBirth.Focus()
        End Select
    End Sub
    Private Sub TEXT6_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DateOfBirth.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTJobTitle.Focus()
        End Select
    End Sub
    Private Sub TEXT8_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTJobTitle.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextDepartmentAdministration.Focus()
        End Select
    End Sub
    Private Sub TEXT9_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextDepartmentAdministration.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TabPage2.Show()
                Me.TextDegree.Focus()
        End Select
    End Sub
    Private Sub TEXT19_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextDegree.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextCondition.Focus()
        End Select
    End Sub
    Private Sub TEXT21_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextCondition.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextSex.Focus()
        End Select
    End Sub
    Private Sub TEXT18_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextSex.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextClientType.Focus()
        End Select
    End Sub
    Private Sub TEXT22_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextClientType.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTBalance_shareLimit.Focus()
        End Select
    End Sub
    Private Sub TEXT15_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTBalance_shareLimit.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextAffiliationFee.Focus()
        End Select
    End Sub
    Private Sub TEXT16_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextAffiliationFee.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextNotebookName.Focus()
        End Select
    End Sub
    Private Sub TEXT23_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextNotebookName.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextContributorPageNumber.Focus()
        End Select
    End Sub
    Private Sub TEXT24_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextContributorPageNumber.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextCustomerPageNumber.Focus()
        End Select
    End Sub
    Private Sub TEXT25_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextCustomerPageNumber.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextAffiliationDecisionNumber.Focus()
        End Select
    End Sub
    Private Sub TEXT26_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextAffiliationDecisionNumber.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.JoinDate.Focus()
        End Select
    End Sub
    Private Sub TEXT27_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles JoinDate.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextWithdrawalNumber.Focus()
        End Select
    End Sub
    Private Sub TEXT28_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextWithdrawalNumber.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.DateWithdrawal.Focus()
        End Select
    End Sub
    Private Sub TEXT29_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DateWithdrawal.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTComments.Focus()
        End Select
    End Sub
    Private Sub TEXT31_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTComments.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TabPage3.Show()
                Me.TEXTADDRESS.Focus()
        End Select
    End Sub
    Private Sub TEXT7_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTADDRESS.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextWorkAddress.Focus()
        End Select
    End Sub
    Private Sub TEXT10_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextWorkAddress.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextTheJudiciary.Focus()
        End Select
    End Sub
    Private Sub TEXT30_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextTheJudiciary.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextGovernorate.Focus()
        End Select
    End Sub
    Private Sub TEXT17_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextGovernorate.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTPHONE.Focus()
        End Select
    End Sub
    Private Sub TEXT12_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTFAX.Focus()
        End Select
    End Sub
    Private Sub TEXT13_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTMOBILE.Focus()
        End Select
    End Sub
    Private Sub TEXT14_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)

    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Position
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTCUser.Text = CUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TextDefinitionDirectorate.Text = COUser




        'Me.RecordCount()
        'Me.Cursor = Cursors.WaitCursor
        'Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = BS.Count
        Me.SaveTab = New ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Me.SHOWBUTTON()
        Insert_Actions(Me.TextMembersCode.EditValue, "تعديل", Me.Text)
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockDelete = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Dim Consum As New SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim strsql1 As New SqlCommand("SELECT DISTINCT IDCAB FROM CABLES WHERE CAB11 = '" & Me.TextMembersCode.EditValue & "'", Consum)
            Dim ds1 As New DataSet
            Dim Adp1 As New SqlDataAdapter(strsql1)
            ds1.Clear()
            Adp1.Fill(ds1, "CABLES")
            If ds1.Tables(0).Rows.Count > 0 Then
                MsgBox("لايمكن حذف  السجل الحالى لأنه مرتبط بحركات العملاء ... ", 16, "تنبيه")
                Exit Sub
            End If

            Dim strsql2 As New SqlCommand("SELECT DISTINCT CEMP1 FROM CABLESCOEMPLOYEES WHERE CEMP29 = '" & Me.TextMembersCode.EditValue & "'", Consum)
            Dim ds2 As New DataSet
            Dim Adp2 As New SqlDataAdapter(strsql2)
            ds2.Clear()
            Adp2.Fill(ds2, "CABLESCOEMPLOYEES")
            If ds2.Tables(0).Rows.Count > 0 Then
                MsgBox("لايمكن حذف  السجل الحالى لأنه مرتبط بحركات مصاريف المشتريات ... ", 16, "تنبيه")
                Exit Sub
            End If

            Dim strsql3 As New SqlCommand("SELECT DISTINCT PTRO1 FROM Invoice WHERE PTRO21 = '" & Me.TextMembersCode.EditValue & "'", Consum)
            Dim ds3 As New DataSet
            Dim Adp3 As New SqlDataAdapter(strsql3)
            ds3.Clear()
            Adp3.Fill(ds3, "Invoice")
            If ds3.Tables(0).Rows.Count > 0 Then
                MsgBox("لايمكن حذف  السجل الحالى لأنه مرتبط بحركات فاتورة نقل مفصلة ... ", 16, "تنبيه")
                Exit Sub
            End If

            Dim strsql4 As New SqlCommand("SELECT DISTINCT PTRO1 FROM PETRO WHERE PTRO21 = '" & Me.TextMembersCode.EditValue & "'", Consum)
            Dim ds4 As New DataSet
            Dim Adp4 As New SqlDataAdapter(strsql4)
            ds4.Clear()
            Adp4.Fill(ds4, "PETRO")
            If ds4.Tables(0).Rows.Count > 0 Then
                MsgBox("لايمكن حذف  السجل الحالى لأنه مرتبط بحركات فاتورة نقل مجمعة ... ", 16, "تنبيه")
                Exit Sub
            End If

            Dim strsql5 As New SqlCommand("SELECT DISTINCT SLS1 FROM SALES WHERE SLS5 = '" & Me.TextMembersName.Text & "'", Consum)
            Dim ds5 As New DataSet
            Dim Adp5 As New SqlDataAdapter(strsql5)
            ds5.Clear()
            Adp5.Fill(ds5, "SALES")
            If ds5.Tables(0).Rows.Count > 0 Then
                MsgBox("لايمكن حذف  السجل الحالى لأنه مرتبط بحركات فاتورة مبيعات ... ", 16, "تنبيه")
                Exit Sub
            End If

            Dim strsql6 As New SqlCommand("SELECT DISTINCT CST1 FROM MYCOSTS WHERE CST9 = '" & Me.TextMembersCode.EditValue & "'", Consum)
            Dim ds6 As New DataSet
            Dim Adp6 As New SqlDataAdapter(strsql6)
            ds6.Clear()
            Adp6.Fill(ds6, "MYCOSTS")
            If ds6.Tables(0).Rows.Count > 0 Then
                MsgBox("لايمكن حذف  السجل الحالى لأنه مرتبط بحركات مصاريف عمومية ... ", 16, "تنبيه")
                Exit Sub
            End If

            Dim strsql7 As New SqlCommand("SELECT DISTINCT IDCH FROM Checks WHERE CH8 = '" & Me.TextMembersCode.EditValue & "'", Consum)
            Dim ds7 As New DataSet
            Dim Adp7 As New SqlDataAdapter(strsql7)
            ds7.Clear()
            Adp7.Fill(ds7, "Checks")
            If ds7.Tables(0).Rows.Count > 0 Then
                MsgBox("لايمكن حذف  السجل الحالى لأنه مرتبط بحركات الشيكات ... ", 16, "تنبيه")
                Exit Sub
            End If

            Dim strsql8 As New SqlCommand("SELECT DISTINCT Lo1 FROM Loans WHERE Lo4 = '" & Me.TextMembersCode.EditValue & "'", Consum)
            Dim ds8 As New DataSet
            Dim Adp8 As New SqlDataAdapter(strsql8)
            ds8.Clear()
            Adp8.Fill(ds8, "EMPSOLF")
            If ds8.Tables(0).Rows.Count > 0 Then
                MsgBox("لايمكن حذف  السجل الحالى لأنه مرتبط بحركات القروض ... ", 16, "تنبيه")
                Exit Sub
            End If

            Dim strsql9 As New SqlCommand("SELECT DISTINCT TBNK1 FROM Deposits WHERE TBNK21 = '" & Me.TextMembersCode.EditValue & "'", Consum)
            Dim ds9 As New DataSet
            Dim Adp9 As New SqlDataAdapter(strsql9)
            ds9.Clear()
            Adp9.Fill(ds9, "Deposits")
            If ds9.Tables(0).Rows.Count > 0 Then
                MsgBox("لايمكن حذف  السجل الحالى لأنه مرتبط بحركات شهادة الادخار ... ", 16, "تنبيه")
                Exit Sub
            End If

            Dim strsq20 As New SqlCommand("SELECT DISTINCT TBNK1 FROM PTRANSACTION WHERE TBNK23 = '" & Me.TextMembersCode.EditValue & "'", Consum)
            Dim ds10 As New DataSet
            Dim Adp10 As New SqlDataAdapter(strsq20)
            ds10.Clear()
            Adp10.Fill(ds10, "PTRANSACTION")
            If ds10.Tables(0).Rows.Count > 0 Then
                MsgBox("لايمكن حذف  السجل الحالى لأنه مرتبط بحركات المدينة والدائنة ... ", 16, "تنبيه")
                Exit Sub
            End If


            If MsgBox("  استمرار حذف السجل الحالي" & " ؟ ", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.OkCancel, "حذف صورة") = MsgBoxResult.Cancel Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.RemoveCurrent()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Insert_Actions(Me.TextMembersCode.EditValue, "حذف", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub List1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles List1.SelectedIndexChanged
        On Error Resume Next
        Me.BS.Position = Me.List1.SelectedIndex
        Me.RecordCount()
    End Sub
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
        On Error Resume Next
        Dim F As New FrmPRINT
        Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject

        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim Consum As New SqlConnection(constring)
        If Me.RadioButton1.Checked Then
            Dim rpt As New rptAllCustomers
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM AllCustomers  WHERE cust2 ='" & Me.List1.Text & "'", Consum)
            Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "AllCustomers")
            rpt.SetDataSource(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                txt = rpt.Section1.ReportObjects("TEXT2")
                txt.Text = "تقرير بيانــات عضو \عميـــــــل"
                txt = rpt.Section1.ReportObjects("TEXT9")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT10")
                txt.Text = Directorate

                F.CrystalReportViewer1.ReportSource = rpt
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.RefreshReport()
                F.Show()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        ElseIf Me.RadioButton2.Checked Then
            Dim rpt As New rptAllCustomers
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM AllCustomers WHERE  CUser='" & CUser & "' ORDER BY IDcust", Consum)
            Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "AllCustomers")
            rpt.SetDataSource(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                txt = rpt.Section1.ReportObjects("TEXT2")
                txt.Text = "تقرير بيانــات الإعضاء \ العملاء"
                txt = rpt.Section1.ReportObjects("TEXT9")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT10")
                txt.Text = Directorate
                F.CrystalReportViewer1.ReportSource = rpt
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.RefreshReport()
                F.Show()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        ElseIf Me.RadioButton3.Checked Then
            Dim rpt As New rptAllCustomers
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM AllCustomers  WHERE CUser='" & CUser & "' And cust15 <'" & Val(BANSL) & "'  ORDER BY IDcust", Consum)
            Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "AllCustomers")
            rpt.SetDataSource(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                txt = rpt.Section1.ReportObjects("TEXT2")
                txt.Text = " تقرير بيانــات الإعضـــــــــاء لم يستوف الاسهم المكتتبة "
                txt = rpt.Section1.ReportObjects("TEXT9")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT10")
                txt.Text = Directorate
                F.CrystalReportViewer1.ReportSource = rpt
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.RefreshReport()
                F.Show()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        ElseIf Me.RadioButton4.Checked Then
            Dim rpt As New rptAllCustomers
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM AllCustomers  WHERE CUser='" & CUser & "' And cust33 ='" & True & "'  ORDER BY IDcust", Consum)
            Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "AllCustomers")
            rpt.SetDataSource(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                txt = rpt.Section1.ReportObjects("TEXT2")
                txt.Text = " تقرير بيانــات الإعضاء "
                txt = rpt.Section1.ReportObjects("TEXT9")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT10")
                txt.Text = Directorate
                F.CrystalReportViewer1.ReportSource = rpt
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.RefreshReport()
                F.Show()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        ElseIf Me.RadioButton5.Checked Then
            Dim rpt As New rptAllCustomers
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM AllCustomers  WHERE CUser='" & CUser & "' And cust33 ='" & False & "'  ORDER BY IDcust", Consum)
            Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "AllCustomers")
            rpt.SetDataSource(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                txt = rpt.Section1.ReportObjects("TEXT2")
                txt.Text = " تقرير بيانــات العملاء "
                txt = rpt.Section1.ReportObjects("TEXT9")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT10")
                txt.Text = Directorate
                F.CrystalReportViewer1.ReportSource = rpt
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.RefreshReport()
                F.Show()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If

        End If
    End Sub
    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonSearch.Click
        On Error Resume Next
        If Me.TxtSearch.Text = "" Then
            MessageBox.Show("الرجاء وضع قيمة للبحث عنها", " البحث في داتا جريد", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtSearch.Focus()
            Exit Sub
        End If
        Me.DataGridView1.ClearSelection()
        Me.Label2.Text = ""
        Dim InStrCunot As Integer = 0
        If IsDate(Me.TxtSearch.Text) Then
            Me.TxtSearch.Text = Format(CDate(Me.TxtSearch.Text), "yyyy/MM/dd")
        ElseIf IsNumeric(Me.TxtSearch.Text) Then
            Me.TxtSearch.Text = Val(Me.TxtSearch.Text)
        End If
        If Me.RadioButton9.Checked Then
            Me.DataGridView1.ClearSelection()
            InStrCunot = 0
            For intcount As Integer = 0 To Me.DataGridView1.RowCount - 1
                For intcolmn As Integer = 0 To Me.DataGridView1.Columns.Count - 1
                    If Trim(Me.TxtSearch.Text) = DataGridView1.Rows(intcount).Cells(intcolmn).FormattedValue.ToString Then
                        Me.DataGridView1.Rows(intcount).Cells(intcolmn).Selected = True
                        Me.DataGridView1.Rows(intcount).Cells(intcolmn).Style.BackColor = Color.Red
                        Me.DataGridView1.Rows(intcount).Cells(intcolmn).Style.ForeColor = Color.White
                        InStrCunot += 1
                    End If
                Next intcolmn
            Next intcount
        Else

            Me.DataGridView1.ClearSelection()
            InStrCunot = 0
            Dim b As Boolean
            For intcount As Integer = 0 To Me.DataGridView1.RowCount - 1
                For intcolmn As Integer = 0 To DataGridView1.Columns.Count - 1
                    b = InStr(Me.DataGridView1.Rows(intcount).Cells(intcolmn).FormattedValue, Trim(Me.TxtSearch.Text))
                    If b = True Then
                        Me.DataGridView1.Rows(intcount).Cells(intcolmn).Selected = True
                        Me.DataGridView1.Rows(intcount).Cells(intcolmn).Style.BackColor = Color.Red
                        Me.DataGridView1.Rows(intcount).Cells(intcolmn).Style.ForeColor = Color.White
                        InStrCunot += 1
                    End If
                Next intcolmn
            Next intcount
        End If
        Me.Label1.Text = IIf(InStrCunot > 0, InStrCunot & " سجل  ", 0 & " سجل  ")
        If InStrCunot = 0 Then
            MessageBox.Show("لم يتم العثور على شي", " البحث في داتا جريد", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtSearch.Focus()
            Me.Label1.Text = "0" & "   سجل   "
        End If
        Me.ListBox3.Items.Clear()
        For Each cell As DataGridViewCell In Me.DataGridView1.SelectedCells
            Me.ListBox3.Items.Add(cell.RowIndex + 1 & " - " & cell.Value)
            Me.ListBox3.Refresh()
            Me.DataGridView1.ClearSelection()
            Me.ListBox3.SelectedIndex = Me.ListBox3.Items.Count - 1
        Next
    End Sub
    Private Sub ButtonDisplyAll_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonDisplyAll.Click
        Try
            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(myds, "AllCustomers")
            Me.ListBox3.Items.Clear()
            Me.TxtSearch.Text = ""
            Me.Label1.Text = ""
            Me.Label2.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ButtonEXPORTTPEXCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonEXPORTTPEXCEL.Click
        Dim strFileName As String
        If Me.DataGridView1.RowCount <= 1 Then
            MessageBox.Show("الجدول فارغ من السجلات", " ملحوظة", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
            If (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0) Then
                Exit Sub
            End If
            Dim dset As New DataSet
            dset.Tables.Add()
            For i As Integer = 0 To Me.DataGridView1.ColumnCount - 1
                dset.Tables(0).Columns.Add(Me.DataGridView1.Columns(i).HeaderText)
            Next
            Dim dr1 As DataRow
            For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                dr1 = dset.Tables(0).NewRow
                For j As Integer = 0 To Me.DataGridView1.Columns.Count - 1
                    dr1(j) = Me.DataGridView1.Rows(i).Cells(j).Value
                Next
                dset.Tables(0).Rows.Add(dr1)
            Next
            Dim excel As New Microsoft.Office.Interop.Excel.Application
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim newCulture As Globalization.CultureInfo
            Dim OldCulture As Globalization.CultureInfo
            OldCulture = System.Threading.Thread.CurrentThread.CurrentCulture
            newCulture = New Globalization.CultureInfo(
                excel.LanguageSettings.LanguageID(Microsoft.Office.Core.MsoAppLanguageID.msoLanguageIDUI))
            System.Threading.Thread.CurrentThread.CurrentCulture = newCulture
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "بيانات_الاعضاء_العملاء"
            Dim dt As DataTable = dset.Tables(0)
            Dim dc As DataColumn
            Dim dr As DataRow
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0
            For Each dc In dt.Columns
                colIndex += 1
                excel.Cells(1, colIndex) = dc.ColumnName
            Next
            For Each dr In dt.Rows
                rowIndex += 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex += 1
                    excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                Next
            Next
            wSheet.Columns.AutoFit()
            Dim blnFileOpen As Boolean = False
            Dim ofd As New SaveFileDialog With {
                .Filter = "Excel Files (*.xls)|*.xls"
            }
            With ofd
                .FilterIndex = 1
                .Title = "حفظ ملف"
                MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
                .InitialDirectory = MYFOLDER & "\Excel"
                .AddExtension = True
                .FileName = "بيانات_الاعضاء_العملاء"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    If Len(.FileName) > 0 Then
                        strFileName = ofd.FileName
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End With
            Try
                Dim fileTemp As IO.FileStream = System.IO.File.OpenWrite(strFileName)
                fileTemp.Close()
            Catch ex As Exception
                blnFileOpen = False
            End Try
            If System.IO.File.Exists(strFileName) Then
                System.IO.File.Delete(strFileName)
            End If
            wBook.SaveAs(strFileName)
            excel.Workbooks.Open(strFileName)
            excel.Visible = True
            System.Threading.Thread.CurrentThread.CurrentCulture = OldCulture
        Catch ex As Exception
            If ex.Message.ToString = "Old format or invalid type library. (Exception from HRESULT: 0x80028018 (TYPE_E_INVDATAREAD))" Then
                MessageBox.Show(" من فضلك غير التنسيق الى" & vbCrLf & vbCrLf & "  English(United States)")
                Dim F As New FrmWindows
                F.Show()
                F.ADDBUTTON.PerformClick()
            Else
                MessageBox.Show(ex.Message)
                Exit Sub
            End If
        End Try
    End Sub
    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListBox3.SelectedIndexChanged
        Try
            Dim Str As String = Me.ListBox3.Text
            Dim strArr() As String
            Dim a As String
            strArr = Str.Split("-")
            a = strArr.First()
            Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(a - 1).Cells(0)
            Me.BS.Position = Val(a) - 1
            Me.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.DELETEBUTTON.Enabled = False
        Else
            If APALL = False And Me.APALL1 = False Then
                Me.SHOWBUTTON()
            ElseIf APALL = True Then
                Me.SHOWBUTTON()
            ElseIf APALL1 = True Then
                Me.SHOWBUTTON1()
            End If
        End If
    End Sub
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles InternalAuditorERBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Static P As Integer
        P = BS.Position
        Me.CheckLogReview.Checked = True
        Me.UPDATERECORD()
        Me.TEXTCUser.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.RecordCount()
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Insert_Actions(Me.TextMembersCode.EditValue, "المراجع", Me.Text)
        MsgBox("تمت عملية المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
    End Sub
    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        'لتجاوز رسائل اخطاء داتا جريد
        MsgBox(e.Exception.Message, 16, "Error")
    End Sub
    Private Sub ButtonCancellationAuditingAndACheckingAccounts_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Static Dim P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = False
        Me.TEXTCUser.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")

        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Insert_Actions(Me.TextMembersCode.EditValue, "إلغاء المراجعة", Me.Text)
        MsgBox("تمت عملية إلغاء المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
    End Sub
    Private Sub ButtonUpdateA_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonUpdateA.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            'Me.TextMembersCode.Clear()
            Me.PictureBox2.Visible = True
            Me.RefreshTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.RefreshTab.RunWorkerAsync()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Text22_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextClientType.SelectedIndexChanged
        Me.AccountsEnquiry()
    End Sub
    Private Sub ButtonAttachDocument_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAttachDocument.Click
        Try
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Dim XLO As Int64
            XLO = Me.DataGridView3.RowCount
            Dim f As New FrmJPG0
            f.Show()
            f.ADDBUTTON.Enabled = False
            f.SAVEBUTTON.Enabled = True
            f.ButScan.Enabled = True
            f.ButSaveFile.Enabled = False
            f.ButLogq.Enabled = True
            f.ButEditImage.Enabled = False
            f.BS.EndEdit()
            f.BS.AddNew()
            f.MAXRECORD()
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
    Private Sub ButtonViewDocuments_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewDocuments.Click
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
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim f As New FrmJPG
            ds.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand(String.Concat(New String() {"SELECT DOC1 FROM MYDOCUMENTSHOME WHERE  CUser='", ModuleGeneral.CUser, "' and DOC1 ='", Trim(Me.TextDOC1.Text), "'"}), Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
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
            If ds.Tables(0).Rows(0).Item("DOC1") = Me.TextDOC1.Text Then
                index = f.BS.Find(NameOf(DOC1), Me.TextDOC1.Text)
                f.Show()
                f.TEXTBOX1.Text = Trim(Me.TextDOC1.Text)
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
    Private Sub DataGridView3_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView3.CellEnter
        Try
            Me.TextDOC1.Text = CDbl(DataGridView3("DOC1", Me.DataGridView3.CurrentRow.Index).Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub DataGridView3_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView3.DoubleClick
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
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim f As New FrmJPG
            ds.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand(String.Concat(New String() {"SELECT DOC1 FROM MYDOCUMENTSHOME WHERE  CUser='", ModuleGeneral.CUser, "' and DOC1 ='", Trim(Me.TextDOC1.Text), "'"}), Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
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
            If ds.Tables(0).Rows(0).Item("DOC1") = Me.TextDOC1.Text Then
                index = f.BS.Find(NameOf(DOC1), Me.TextDOC1.Text)
                f.Show()
                f.TEXTBOX1.Text = Trim(Me.TextDOC1.Text)
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
    Private Sub TextTheJudiciary_Enter(sender As Object, e As EventArgs) Handles TEXTEMAIL.Enter, TextWorkAddress.Enter, TextTheJudiciary.Enter, TextPlaceOfBirth.Enter, TextMembersName.Enter, TextDepartmentAdministration.Enter, TEXTComments.Enter, TEXTADDRESS.Enter
        ChangeToArabic()
    End Sub

    Private Sub TEXTEMAIL_Enter(sender As Object, e As EventArgs) Handles TEXTEMAIL.Enter, TextWithdrawalNumber.Enter, TEXTPHONE.Enter, TEXTMOBILE.Enter, TEXTFAX.Enter, TextCustomerPageNumber.Enter, TextContributorPageNumber.Enter, TEXTBalance_shareLimit.Enter, TextAffiliationFee.Enter, TextAffiliationDecisionNumber.Enter
        ChangeToEnglish()
    End Sub
    Private Sub TextNationalNo_Enter(sender As Object, e As EventArgs) Handles TextNationalNo.Enter, TextMilitaryNumber.Enter
        ChangeToEnglish()
    End Sub

End Class