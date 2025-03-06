Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FormStatisticalStatement
<<<<<<< HEAD
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter
=======
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveDataBase As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Private WithEvents SearchTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim IDss1 As Integer


<<<<<<< HEAD
    Private Sub ComboBoxEx2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboAssociationName.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CMP5, CMP7, CMP8, CUser    FROM COMPANY WHERE CMP2 ='" & Me.ComboAssociationName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBoxEx2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboAssociationName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CMP5, CMP7, CMP8, CUser    FROM COMPANY WHERE CMP2 ='" & Me.ComboAssociationName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextAssociationNationalNumber.Text = ds.Tables(0).Rows(0).Item(0)
            Me.TextType.Text = ds.Tables(0).Rows(0).Item(1)
            Me.TextDirectorateName.Text = ds.Tables(0).Rows(0).Item(2)

            CUser = ds.Tables(0).Rows(0).Item(3)
        Else
            Me.TextAssociationNationalNumber.Text = ""
            Me.TextType.Text = ""
            Me.TextDirectorateName.Text = ""
            CUser = ModuleGeneral.CUser
        End If
        Adp.Dispose()
        Consum.Close()
        StatisticalStatementInquiry()
        FrmMAIN.ComboGetAssociationName_SelectedIndexChanged(sender, e)
    End Sub

<<<<<<< HEAD
    Private Sub FormStatisticalStatement_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
=======
    Private Sub FormStatisticalStatement_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    ADDBUTTON_Click(sender, e)
                Case Keys.F2
                    SAVEBUTTON_Click(sender, e)
                Case Keys.F3
                    EDITBUTTON_Click(sender, e)
                Case Keys.F4
                    BUTTONCANCEL_Click(sender, e)
                Case Keys.F5
                    PRINTBUTTON_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
        Me.EDITBUTTON.Enabled = LockUpdate
    End Sub
    Private Sub MAXRECORD()
        On Error Resume Next
        Dim V As Integer
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(IDSS) FROM StatisticalStatement", Consum)
        Dim CMD As New SqlCommand
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(IDSS) FROM StatisticalStatement", Consum)
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
            IDss.Text = 1
        Else
            IDss.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub
    Private Sub StatisticalStatementInquiryID()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim MC1 As SqlDataAdapter
        Dim strSQLmc1 As New SqlCommand("SELECT IDSS  FROM StatisticalStatement WHERE CUser ='" & ModuleGeneral.CUser & "' and Year(convert(date,SS1, 103)) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim dsMC1 As New DataSet
        MC1 = New SqlDataAdapter(strSQLmc1)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim MC1 As SqlClient.SqlDataAdapter
        Dim strSQLmc1 As New SqlCommand("SELECT IDSS  FROM StatisticalStatement WHERE CUser ='" & ModuleGeneral.CUser & "' and Year(convert(date,SS1, 103)) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim dsMC1 As New DataSet
        MC1 = New SqlClient.SqlDataAdapter(strSQLmc1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        dsMC1.Clear()
        MC1.Fill(dsMC1)
        If dsMC1.Tables(0).Rows.Count > 0 Then
            IDss1 = dsMC1.Tables(0).Rows(0).Item(0)

        Else
            IDss1 = 0

        End If
        MC1.Dispose()
        Consum.Close()
    End Sub
    Private Sub StatisticalStatementInquiry()
        On Error Resume Next

        Dim EMA As Integer = 0
        Dim EMB As Integer = 0
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim MC1 As SqlDataAdapter
        Dim strSQLmc1 As New SqlCommand("SELECT COUNT(IDmc)  FROM ManagementCommittee WHERE CUser ='" & ModuleGeneral.CUser & "' and mc7 ='" & Trim("True") & "' and mc3 <>'" & Trim("محاسب") & "'", Consum)
        Dim dsMC1 As New DataSet
        MC1 = New SqlDataAdapter(strSQLmc1)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim MC1 As SqlClient.SqlDataAdapter
        Dim strSQLmc1 As New SqlCommand("SELECT COUNT(IDmc)  FROM ManagementCommittee WHERE CUser ='" & ModuleGeneral.CUser & "' and mc7 ='" & Trim("True") & "' and mc3 <>'" & Trim("محاسب") & "'", Consum)
        Dim dsMC1 As New DataSet
        MC1 = New SqlClient.SqlDataAdapter(strSQLmc1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        dsMC1.Clear()
        MC1.Fill(dsMC1)
        If dsMC1.Tables(0).Rows.Count > 0 Then
            Me.TextNumberOfManagementCommittee.Text = dsMC1.Tables(0).Rows(0).Item(0)
        Else
            Me.TextNumberOfManagementCommittee.Text = "0"
        End If
        MC1.Dispose()

<<<<<<< HEAD
        Dim MC2 As SqlDataAdapter
        Dim strSQLmc2 As New SqlCommand("SELECT COUNT(IDmc)  FROM ManagementCommittee WHERE CUser ='" & ModuleGeneral.CUser & "' and mc7 ='" & Trim("False") & "'", Consum)
        Dim dsMC2 As New DataSet
        MC2 = New SqlDataAdapter(strSQLmc2)
=======
        Dim MC2 As SqlClient.SqlDataAdapter
        Dim strSQLmc2 As New SqlCommand("SELECT COUNT(IDmc)  FROM ManagementCommittee WHERE CUser ='" & ModuleGeneral.CUser & "' and mc7 ='" & Trim("False") & "'", Consum)
        Dim dsMC2 As New DataSet
        MC2 = New SqlClient.SqlDataAdapter(strSQLmc2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        dsMC2.Clear()
        MC2.Fill(dsMC2)
        If dsMC2.Tables(0).Rows.Count > 0 Then
            Me.TextNumberOfMonitoringCommittee.Text = dsMC2.Tables(0).Rows(0).Item(0)
        Else
            Me.TextNumberOfMonitoringCommittee.Text = "0"
        End If
        MC2.Dispose()

<<<<<<< HEAD
        Dim MC3 As SqlDataAdapter
        Dim strSQLmc3 As New SqlCommand("SELECT mc1  FROM ManagementCommittee WHERE CUser ='" & ModuleGeneral.CUser & "' and mc3 ='" & Trim("سكرتير") & "'", Consum)
        Dim dsMC3 As New DataSet
        MC3 = New SqlDataAdapter(strSQLmc3)
=======
        Dim MC3 As SqlClient.SqlDataAdapter
        Dim strSQLmc3 As New SqlCommand("SELECT mc1  FROM ManagementCommittee WHERE CUser ='" & ModuleGeneral.CUser & "' and mc3 ='" & Trim("سكرتير") & "'", Consum)
        Dim dsMC3 As New DataSet
        MC3 = New SqlClient.SqlDataAdapter(strSQLmc3)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        dsMC3.Clear()
        MC3.Fill(dsMC3)
        If dsMC3.Tables(0).Rows.Count > 0 Then
            Me.TextSecretary.Text = dsMC3.Tables(0).Rows(0).Item(0)
        Else
            Me.TextSecretary.Text = "0"
        End If
        MC3.Dispose()

<<<<<<< HEAD
        Dim MC4 As SqlDataAdapter
        Dim strSQLmc4 As New SqlCommand("SELECT mc1  FROM ManagementCommittee WHERE CUser ='" & ModuleGeneral.CUser & "' and mc3 ='" & Trim("امين الصندوق") & "'", Consum)
        Dim dsMC4 As New DataSet
        MC4 = New SqlDataAdapter(strSQLmc4)
=======
        Dim MC4 As SqlClient.SqlDataAdapter
        Dim strSQLmc4 As New SqlCommand("SELECT mc1  FROM ManagementCommittee WHERE CUser ='" & ModuleGeneral.CUser & "' and mc3 ='" & Trim("امين الصندوق") & "'", Consum)
        Dim dsMC4 As New DataSet
        MC4 = New SqlClient.SqlDataAdapter(strSQLmc4)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        dsMC4.Clear()
        MC4.Fill(dsMC4)
        If dsMC4.Tables(0).Rows.Count > 0 Then
            Me.TextCashier.Text = dsMC4.Tables(0).Rows(0).Item(0)
        Else
            Me.TextCashier.Text = "0"
        End If
        MC4.Dispose()

<<<<<<< HEAD
        Dim MC5 As SqlDataAdapter
        Dim strSQLmc5 As New SqlCommand("SELECT mc1  FROM ManagementCommittee WHERE CUser ='" & ModuleGeneral.CUser & "' and mc3 ='" & Trim("محاسب") & "'", Consum)
        Dim dsMC5 As New DataSet
        MC5 = New SqlDataAdapter(strSQLmc5)
=======
        Dim MC5 As SqlClient.SqlDataAdapter
        Dim strSQLmc5 As New SqlCommand("SELECT mc1  FROM ManagementCommittee WHERE CUser ='" & ModuleGeneral.CUser & "' and mc3 ='" & Trim("محاسب") & "'", Consum)
        Dim dsMC5 As New DataSet
        MC5 = New SqlClient.SqlDataAdapter(strSQLmc5)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        dsMC5.Clear()
        MC5.Fill(dsMC5)
        If dsMC5.Tables(0).Rows.Count > 0 Then
            Me.TextAssociationAccountant.Text = dsMC5.Tables(0).Rows(0).Item(0)
        Else
            Me.TextAssociationAccountant.Text = "0"
        End If
        MC5.Dispose()

<<<<<<< HEAD
        Dim EM1 As SqlDataAdapter
        Dim strSQLEM1 As New SqlCommand("SELECT COUNT(EMP1)  FROM EMPLOYEES WHERE CUser ='" & ModuleGeneral.CUser & "' and EMP22 ='" & Trim("True") & "'", Consum)
        Dim dsEM1 As New DataSet
        EM1 = New SqlDataAdapter(strSQLEM1)
=======
        Dim EM1 As SqlClient.SqlDataAdapter
        Dim strSQLEM1 As New SqlCommand("SELECT COUNT(EMP1)  FROM EMPLOYEES WHERE CUser ='" & ModuleGeneral.CUser & "' and EMP22 ='" & Trim("True") & "'", Consum)
        Dim dsEM1 As New DataSet
        EM1 = New SqlClient.SqlDataAdapter(strSQLEM1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        dsEM1.Clear()
        EM1.Fill(dsEM1)
        If dsEM1.Tables(0).Rows.Count > 0 Then
            EMA = dsEM1.Tables(0).Rows(0).Item(0)
        Else
            EMA = "0"
        End If
        EM1.Dispose()

<<<<<<< HEAD
        Dim EM2 As SqlDataAdapter
        Dim strSQLEM2 As New SqlCommand("SELECT COUNT(EMP1)  FROM EMPLOYEES WHERE CUser ='" & ModuleGeneral.CUser & "' and EMP22 ='" & Trim("False") & "'", Consum)
        Dim dsEM2 As New DataSet
        EM2 = New SqlDataAdapter(strSQLEM2)
=======
        Dim EM2 As SqlClient.SqlDataAdapter
        Dim strSQLEM2 As New SqlCommand("SELECT COUNT(EMP1)  FROM EMPLOYEES WHERE CUser ='" & ModuleGeneral.CUser & "' and EMP22 ='" & Trim("False") & "'", Consum)
        Dim dsEM2 As New DataSet
        EM2 = New SqlClient.SqlDataAdapter(strSQLEM2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        dsEM2.Clear()
        EM2.Fill(dsEM2)
        If dsEM2.Tables(0).Rows.Count > 0 Then
            EMB = dsEM2.Tables(0).Rows(0).Item(0)
        Else
            EMB = "0"
        End If
        EM2.Dispose()

<<<<<<< HEAD
        Dim AP1 As SqlDataAdapter
        Dim strSQLAP1 As New SqlCommand("SELECT AP7, AP8  FROM AssociationProjects WHERE CUser ='" & ModuleGeneral.CUser & "' ", Consum)
        Dim dsAP1 As New DataSet
        AP1 = New SqlDataAdapter(strSQLAP1)
=======
        Dim AP1 As SqlClient.SqlDataAdapter
        Dim strSQLAP1 As New SqlCommand("SELECT AP7, AP8  FROM AssociationProjects WHERE CUser ='" & ModuleGeneral.CUser & "' ", Consum)
        Dim dsAP1 As New DataSet
        AP1 = New SqlClient.SqlDataAdapter(strSQLAP1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        dsAP1.Clear()
        AP1.Fill(dsAP1)
        If dsAP1.Tables(0).Rows.Count > 0 Then
            Me.TextNumberOfPermanentWorkers.Text = Val(EMA) + dsAP1.Tables(0).Rows(0).Item(0)
            Me.TextNumberOfSeasonalWorkers.Text = Val(EMB) + dsAP1.Tables(0).Rows(0).Item(1)

        Else
            Me.TextNumberOfPermanentWorkers.Text = Val(EMA) + "0"
            Me.TextNumberOfSeasonalWorkers.Text = Val(EMB) + "0"
        End If
        AP1.Dispose()

<<<<<<< HEAD
        Dim Adp1 As SqlDataAdapter
        Dim strSQL1 As New SqlCommand("SELECT COUNT(IDcust)  FROM AllCustomers WHERE CUser ='" & ModuleGeneral.CUser & "' and cust33 ='" & Trim("True") & "' and Year(convert(date,cust27, 103)) <>'" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlDataAdapter(strSQL1)
=======
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim strSQL1 As New SqlCommand("SELECT COUNT(IDcust)  FROM AllCustomers WHERE CUser ='" & ModuleGeneral.CUser & "' and cust33 ='" & Trim("True") & "' and Year(convert(date,cust27, 103)) <>'" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strSQL1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds1.Clear()
        Adp1.Fill(ds1)
        If ds1.Tables(0).Rows.Count > 0 Then
            Me.TextNumberOfMembersAtBeginningOfYear.Text = ds1.Tables(0).Rows(0).Item(0)
        Else
            Me.TextNumberOfMembersAtBeginningOfYear.Text = "0"
        End If
        Adp1.Dispose()
<<<<<<< HEAD
        Dim Adp2 As SqlDataAdapter
        Dim SQL2 As New SqlCommand("SELECT Count(IDcust)  FROM AllCustomers WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(convert(date,cust27, 103)) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim ds2 As New DataSet
        Adp2 = New SqlDataAdapter(SQL2)
=======
        Dim Adp2 As SqlClient.SqlDataAdapter
        Dim SQL2 As New SqlCommand("SELECT Count(IDcust)  FROM AllCustomers WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(convert(date,cust27, 103)) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim ds2 As New DataSet
        Adp2 = New SqlClient.SqlDataAdapter(SQL2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds2.Clear()
        Adp2.Fill(ds2)
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.TextNumberOfMembersWhoWereAcceptedDuringYear.Text = ds2.Tables(0).Rows(0).Item(0)
        Else
            Me.TextNumberOfMembersWhoWereAcceptedDuringYear.Text = "0"
        End If
        Adp2.Dispose()
<<<<<<< HEAD
        Dim Adp3 As SqlDataAdapter
        Dim SQL3 As New SqlCommand("SELECT Count(IDcust)  FROM AllCustomers WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(convert(date,cust29, 103)) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim ds3 As New DataSet
        Adp3 = New SqlDataAdapter(SQL3)
=======
        Dim Adp3 As SqlClient.SqlDataAdapter
        Dim SQL3 As New SqlCommand("SELECT Count(IDcust)  FROM AllCustomers WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(convert(date,cust29, 103)) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim ds3 As New DataSet
        Adp3 = New SqlClient.SqlDataAdapter(SQL3)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds3.Clear()
        Adp3.Fill(ds3)
        If ds3.Tables(0).Rows.Count > 0 Then
            Me.TextNumberOfWithdrawnMembers.Text = ds3.Tables(0).Rows(0).Item(0)
        Else
            Me.TextNumberOfWithdrawnMembers.Text = "0"
        End If
        Adp3.Dispose()
        Me.TextNumberOfMembersAtEndOfYear.Text = Val(Me.TextNumberOfMembersAtBeginningOfYear.Text) + Val(Me.TextNumberOfMembersWhoWereAcceptedDuringYear.Text) - Val(Me.TextNumberOfWithdrawnMembers.Text)
        Me.TextSharesSubscribedAtBeginningOfYear.EditValue = Val(BANSL) * Val(Me.TextNumberOfMembersAtEndOfYear.Text)

<<<<<<< HEAD
        Dim AS1 As SqlDataAdapter
        Dim SQLAS1 As New SqlCommand("SELECT SUM(OpeningBalance2)  FROM ALLShares WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(convert(date,TBNK3, 103)) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim dsAS1 As New DataSet
        AS1 = New SqlDataAdapter(SQLAS1)
=======
        Dim AS1 As SqlClient.SqlDataAdapter
        Dim SQLAS1 As New SqlCommand("SELECT SUM(OpeningBalance2)  FROM ALLShares WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(convert(date,TBNK3, 103)) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim dsAS1 As New DataSet
        AS1 = New SqlClient.SqlDataAdapter(SQLAS1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        dsAS1.Clear()
        AS1.Fill(dsAS1)
        If dsAS1.Tables(0).Rows.Count > 0 Then
            Me.TextSharesPaidAtBeginningOfYear.EditValue = dsAS1.Tables(0).Rows(0).Item(0)
        Else
            Me.TextSharesPaidAtBeginningOfYear.EditValue = "0"
        End If
        AS1.Dispose()
<<<<<<< HEAD
        Dim ME1 As SqlDataAdapter
        Dim SQLME1 As New SqlCommand("SELECT Count(IDME)  FROM Meetings WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(convert(date,ME3, 103)) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim dsME1 As New DataSet
        ME1 = New SqlDataAdapter(SQLME1)
=======
        Dim ME1 As SqlClient.SqlDataAdapter
        Dim SQLME1 As New SqlCommand("SELECT Count(IDME)  FROM Meetings WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(convert(date,ME3, 103)) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim dsME1 As New DataSet
        ME1 = New SqlClient.SqlDataAdapter(SQLME1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        dsME1.Clear()
        ME1.Fill(dsME1)
        If dsME1.Tables(0).Rows.Count > 0 Then
            Me.TextNumberOfManagementCommitteeMeetings.Text = dsME1.Tables(0).Rows(0).Item(0)
        Else
            Me.TextNumberOfManagementCommitteeMeetings.Text = "0"
        End If
        ME1.Dispose()
        Consum.Close()

    End Sub
<<<<<<< HEAD
    Private Sub FormStatisticalStatement_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FormStatisticalStatement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next

<<<<<<< HEAD
            Me.BackWorker2 = New ComponentModel.BackgroundWorker With {
=======
            Me.BackWorker2 = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.BackWorker2.RunWorkerAsync()
            Me.SHOWBUTTON()
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
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
                Me.PictureBox2False()
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            'If DelRow = True Then
            '    Me.ButtonXP5_Click(sender, e)
            '    Exit Sub
            'ElseIf e.Cancelled Then
            '    Exit Sub
            'End If
            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "StatisticalStatement")

            Application.DoEvents()
            Me.BS.DataSource = Me.myds.Tables("StatisticalStatement")
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.Count()
            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & BS.Count - RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.save
=======
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            If Click1 = True Then
                Try
                    Insert_Actions(Me.TextAssociationNationalNumber.Text.Trim, "حفظ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click2 = True Then
                Try
                    Insert_Actions(Me.TextAssociationNationalNumber.Text.Trim, "تعديل", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click3 = True Then
                Try
                    Insert_Actions(Me.TextAssociationNationalNumber.Text.Trim, "الارصدة", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click4 = True Then
                Try
                    Insert_Actions(Me.TextAssociationNationalNumber.Text.Trim, "ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click5 = True Then
                Try
                    Insert_Actions(Me.TextAssociationNationalNumber.Text.Trim, "تعديل ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click6 = True Then
                Try
                    Insert_Actions(Me.TextAssociationNationalNumber.Text.Trim, "حذف ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click7 = True Then
                Try
                    Insert_Actions(Me.TextAssociationNationalNumber.Text.Trim, "ترحيل الحركة الى الصندوق", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click8 = True Then
                Try
                    Insert_Actions(Me.TextAssociationNationalNumber.Text.Trim, "تعديل ترحيل الحركة الى الصندوق ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click9 = True Then
                Try
                    Insert_Actions(Me.TextAssociationNationalNumber.Text.Trim, "حذف ترحيل الحركة الى الصندوق ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click10 = True Then
                Try
                    Insert_Actions(Me.TextAssociationNationalNumber.Text.Trim, "المراجع", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click11 = True Then
                Try
                    Insert_Actions(Me.TextAssociationNationalNumber.Text.Trim, "إلغاء المراجعة", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            End If
            Click1 = False
            Click2 = False
            Click3 = False
            Click4 = False
            Click5 = False
            Click6 = False
            Click7 = False
            Click8 = False
            Click9 = False
            Click10 = False
            Click11 = False
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
    Public Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.myds.Tables("BANKJO").Rows.Count - 1 Then
            Forward = True
        End If
        Me.SHOWBUTTON()
    End Sub
    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
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
            Call MangUsers()
            'If LockAddRow = False Then
            '    MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات ", 16, "تنبيه")
            '    Exit Sub
            'End If
            StatisticalStatementInquiryID()
            If Val(IDss1) > 0 Then
                MsgBox("عفوا .. تم تسجيل بيان احصائي لهذا العام", 16, "تنبيه")
                Me.ADDBUTTON.Enabled = False
                Me.SAVEBUTTON.Enabled = False
                Exit Sub
            End If
            StatisticalStatementInquiry()
            Me.MAXRECORD()
            Me.TextNumberOfPermanentWorkers.Text = 0
            Me.TextNumberOfSeasonalWorkers.Text = 0
            Me.TextWorkOfAssociation.Text = 0
            Me.DateT.Value = MaxDate.ToString("yyyy-MM-dd")
            Me.TextNumberOfGeneralAssemblyMeetings.Text = 1
            Me.TextNumberOfAttendeesAtEachMeeting.Text = "النصب قانوني"
            'Me.TextBox8.Text = Me.CSH
            'Me.TextBox9.Text = CurrencyJO(Me.TextBox8.Text, "jO")
            'Me.TextBox2.Focus()
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.addv
=======
            Dim Sound As System.IO.Stream = My.Resources.addv
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
=======
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        'If Me.BS.Count = 0 Then Beep() : Exit Sub
        If HeadofAuditingDepartment = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Me.SAVEBUTTON.Enabled = False

        Static P As Integer
        P = Me.BS.Count
        Me.SAVERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
<<<<<<< HEAD
        Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Me.SAVEBUTTON.Enabled = False
        Click1 = True
    End Sub

    Private Sub SAVERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As String = "INSERT INTO StatisticalStatement(  SS1, SS2, SS3, SS4, SS5, SS7, SS6, SS8, SS9, SS10, SS11, SS12, SS13, SS14, SS15, SS16, SS17, SS18, SS19, SS20, SS21, SS22, SS23, SS24, SS25, SS26, SS27, SS28, SS29, SS30, SS31, SS32, USERNAME, CUser, COUser, da, ne) VALUES   (  @SS1, @SS2, @SS3, @SS4, @SS5, @SS7, @SS6, @SS8, @SS9, @SS10, @SS11, @SS12, @SS13, @SS14, @SS15, @SS16, @SS17, @SS18, @SS19, @SS20, @SS21, @SS22, @SS23, @SS24, @SS25, @SS26, @SS27, @SS28, @SS29, @SS30, @SS31, @SS32, @USERNAME, @CUser, @COUser, @da, @ne)"

            Dim cmd As New SqlCommand(SQL, Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO StatisticalStatement(  SS1, SS2, SS3, SS4, SS5, SS7, SS6, SS8, SS9, SS10, SS11, SS12, SS13, SS14, SS15, SS16, SS17, SS18, SS19, SS20, SS21, SS22, SS23, SS24, SS25, SS26, SS27, SS28, SS29, SS30, SS31, SS32, USERNAME, CUser, COUser, da, ne) VALUES   (  @SS1, @SS2, @SS3, @SS4, @SS5, @SS7, @SS6, @SS8, @SS9, @SS10, @SS11, @SS12, @SS13, @SS14, @SS15, @SS16, @SS17, @SS18, @SS19, @SS20, @SS21, @SS22, @SS23, @SS24, @SS25, @SS26, @SS27, @SS28, @SS29, @SS30, @SS31, @SS32, @USERNAME, @CUser, @COUser, @da, @ne)"

            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@SS1", SqlDbType.Date).Value = Me.DateT.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@SS2", SqlDbType.NVarChar).Value = Me.ComboAssociationName.Text
                .Parameters.Add("@SS3", SqlDbType.NVarChar).Value = Me.TextAssociationNationalNumber.Text
                .Parameters.Add("@SS4", SqlDbType.NVarChar).Value = Me.TextType.Text
                .Parameters.Add("@SS5", SqlDbType.NVarChar).Value = Me.TextDirectorateName.Text
                .Parameters.Add("@SS6", SqlDbType.NVarChar).Value = Me.TextWorkOfAssociation.Text
                .Parameters.Add("@SS7", SqlDbType.Int).Value = Me.ComboFiscalYear.Text
                .Parameters.Add("@SS8", SqlDbType.Int).Value = Me.TextNumberOfManagementCommittee.Text
                .Parameters.Add("@SS9", SqlDbType.NVarChar).Value = Me.TextSecretary.Text
                .Parameters.Add("@SS10", SqlDbType.NVarChar).Value = Me.TextCashier.Text
                .Parameters.Add("@SS11", SqlDbType.Int).Value = Me.TextNumberOfMonitoringCommittee.Text
                .Parameters.Add("@SS12", SqlDbType.NVarChar).Value = Me.TextAssociationAccountant.Text
                .Parameters.Add("@SS13", SqlDbType.Int).Value = Me.TextNumberOfPermanentWorkers.Text
                .Parameters.Add("@SS14", SqlDbType.Int).Value = Me.TextNumberOfSeasonalWorkers.Text
                .Parameters.Add("@SS15", SqlDbType.Int).Value = Me.TextNumberOfMembersAtBeginningOfYear.Text
                .Parameters.Add("@SS16", SqlDbType.Int).Value = Me.TextNumberOfMembersWhoWereAcceptedDuringYear.Text
                .Parameters.Add("@SS17", SqlDbType.Int).Value = Me.TextNumberOfWithdrawnMembers.Text
                .Parameters.Add("@SS18", SqlDbType.Int).Value = Me.TextNumberOfMembersAtEndOfYear.Text
                .Parameters.Add("@SS19", SqlDbType.Float).Value = Me.TextSharesSubscribedAtBeginningOfYear.EditValue
                .Parameters.Add("@SS20", SqlDbType.Float).Value = Me.TextSharesPaidAtBeginningOfYear.EditValue
                .Parameters.Add("@SS21", SqlDbType.Float).Value = Me.TextRatioOfPrivateCapitalToAssetsOfAssociation.EditValue
                .Parameters.Add("@SS22", SqlDbType.Float).Value = Me.TextInvestmentRate.EditValue
                .Parameters.Add("@SS23", SqlDbType.Float).Value = Me.TextLoanAmountAtEndOfYear.EditValue
                .Parameters.Add("@SS24", SqlDbType.Float).Value = Me.TextSavingsAreReturnsOnStocks.EditValue
                .Parameters.Add("@SS25", SqlDbType.Float).Value = Me.TextSeasonalLending.EditValue
                .Parameters.Add("@SS26", SqlDbType.Float).Value = Me.TextMediumTerm.EditValue
                .Parameters.Add("@SS27", SqlDbType.Float).Value = Me.TextSales.EditValue
                .Parameters.Add("@SS28", SqlDbType.Float).Value = Me.TextMarketing.EditValue
                .Parameters.Add("@SS29", SqlDbType.Int).Value = Me.TextNumberOfGeneralAssemblyMeetings.Text
                .Parameters.Add("@SS30", SqlDbType.NVarChar).Value = Me.TextNumberOfAttendeesAtEachMeeting.Text
                .Parameters.Add("@SS31", SqlDbType.Int).Value = Me.TextNumberOfManagementCommitteeMeetings.Text
                .Parameters.Add("@SS32", SqlDbType.Int).Value = Me.TextNumberOfOversightCommitteeMeetings.Text



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
            Insert_Actions(Me.TextAssociationNationalNumber.Text, "حفظ", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then

            Else

                Me.Close()
            End If
        End If
    End Sub
    Private Sub BackWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker2.DoWork
        Try

1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())

<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum) With {
                .CommandText = String.Concat(New String() {"SELECT   IDSS, SS1, SS2, SS3, SS4, SS5, SS7, SS6, SS8, SS9, SS10, SS11, SS12, SS13, SS14, SS15, SS16, SS17, SS18, SS19, SS20, SS21, SS22, SS23, SS24, SS25, SS26, SS27, SS28, SS29, SS30, SS31, SS32, USERNAME, CUser, COUser, da, ne FROM StatisticalStatement  WHERE  CUser='", ModuleGeneral.CUser, "' and Year(SS1) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDSS"})
            }

            Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum) With {
                .CommandText = String.Concat(New String() {"SELECT   IDSS, SS1, SS2, SS3, SS4, SS5, SS7, SS6, SS8, SS9, SS10, SS11, SS12, SS13, SS14, SS15, SS16, SS17, SS18, SS19, SS20, SS21, SS22, SS23, SS24, SS25, SS26, SS27, SS28, SS29, SS30, SS31, SS32, USERNAME, CUser, COUser, da, ne FROM StatisticalStatement  WHERE  CUser='", ModuleGeneral.CUser, "' and Year(SS1) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDSS"})
            }

            Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
            Me.myds = New DataSet
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.myds, "StatisticalStatement")
            Me.myds.RejectChanges()
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
        End Try
    End Sub

    Private Sub BackWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker2.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.myds.Tables("StatisticalStatement")
            RowCount = BS.Count
            IDss.DataBindings.Add("text", BS, "IDss", True, 1, "")
            DateT.DataBindings.Add("text", BS, "SS1", True, 1, "")
            ComboAssociationName.DataBindings.Add("text", BS, "SS2", True, 1, "")
            TextAssociationNationalNumber.DataBindings.Add("text", BS, "SS3", True, 1, "")
            TextType.DataBindings.Add("text", BS, "SS4", True, 1, "")
            TextDirectorateName.DataBindings.Add("text", BS, "SS5", True, 1, "")
            TextWorkOfAssociation.DataBindings.Add("text", BS, "SS6", True, 1, "")
            ComboFiscalYear.DataBindings.Add("text", BS, "SS7", True, 1, "")
            TextNumberOfManagementCommittee.DataBindings.Add("text", BS, "SS8", True, 1, "")
            TextSecretary.DataBindings.Add("text", BS, "SS9", True, 1, "")
            TextCashier.DataBindings.Add("text", BS, "SS10", True, 1, "")
            TextNumberOfMonitoringCommittee.DataBindings.Add("text", BS, "SS11", True, 1, "")
            TextAssociationAccountant.DataBindings.Add("text", BS, "SS12", True, 1, "")
            TextNumberOfPermanentWorkers.DataBindings.Add("text", BS, "SS13", True, 1, "")
            TextNumberOfSeasonalWorkers.DataBindings.Add("text", BS, "SS14", True, 1, "")
            TextNumberOfMembersAtBeginningOfYear.DataBindings.Add("text", BS, "SS15", True, 1, "")
            TextNumberOfMembersWhoWereAcceptedDuringYear.DataBindings.Add("text", BS, "SS16", True, 1, "")
            TextNumberOfWithdrawnMembers.DataBindings.Add("text", BS, "SS17", True, 1, "")
            TextNumberOfMembersAtEndOfYear.DataBindings.Add("text", BS, "SS18", True, 1, "")
            TextSharesSubscribedAtBeginningOfYear.DataBindings.Add("text", BS, "SS19", True, 1, "")
            TextSharesPaidAtBeginningOfYear.DataBindings.Add("text", BS, "SS20", True, 1, "")
            TextRatioOfPrivateCapitalToAssetsOfAssociation.DataBindings.Add("text", BS, "SS21", True, 1, "")
            TextInvestmentRate.DataBindings.Add("text", BS, "SS22", True, 1, "")
            TextLoanAmountAtEndOfYear.DataBindings.Add("text", BS, "SS23", True, 1, "")
            TextSavingsAreReturnsOnStocks.DataBindings.Add("text", BS, "SS24", True, 1, "")
            TextSeasonalLending.DataBindings.Add("text", BS, "SS25", True, 1, "")
            TextMediumTerm.DataBindings.Add("text", BS, "SS26", True, 1, "")
            TextSales.DataBindings.Add("text", BS, "SS27", True, 1, "")
            TextMarketing.DataBindings.Add("text", BS, "SS28", True, 1, "")
            TextNumberOfGeneralAssemblyMeetings.DataBindings.Add("text", BS, "SS29", True, 1, "")
            TextNumberOfAttendeesAtEachMeeting.DataBindings.Add("text", BS, "SS30", True, 1, "")
            TextNumberOfManagementCommitteeMeetings.DataBindings.Add("text", BS, "SS31", True, 1, "")
            TextNumberOfOversightCommitteeMeetings.DataBindings.Add("text", BS, "SS32", True, 1, "")
            FILLCOMBOBOX1("COMPANY", "CMP2", "COUser", COUser, Me.ComboAssociationName)
            FILLCOMBOBOX3("Users", "UserName", "COUser", COUser, "InternalAuditor", Trim("True"), Me.ComboAuditor)
            FILLCOMBOBOX1("FiscalYear", "Year(Year4)", "CUser", CUser, Me.ComboFiscalYear)
            Call MangUsers()
            Auditor("StatisticalStatement", "USERNAME", "IDss", Me.IDss.Text, "")
            Logentry = Uses
            If InternalAuditor = False Then

                'MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            Else

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub UPDATERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update StatisticalStatement SET  SS1 = @SS1, SS2 = @SS2, SS3 = @SS3, SS4 = @SS4, SS5 = @SS5, SS6 = @SS6, SS7 = @SS7, SS8 = @SS8, SS9 = @SS9, SS10 = @SS10,SS11 = @SS11, SS12 = @SS12, SS13 = @SS13, SS14 = @SS14, SS15 = @SS15, SS16 = @SS16, SS17 = @SS17, SS18 = @SS18, SS19 = @SS19, SS20 = @SS20,SS21 = @SS21, SS22 = @SS22, SS23 = @SS23, SS24 = @SS24, SS25 = @SS25, SS26 = @SS26, SS27 = @SS27, SS28 = @SS28, SS29 = @SS29, SS30 = @SS30, SS31 = @SS31, SS32 = @SS32, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDSS = @IDSS", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update StatisticalStatement SET  SS1 = @SS1, SS2 = @SS2, SS3 = @SS3, SS4 = @SS4, SS5 = @SS5, SS6 = @SS6, SS7 = @SS7, SS8 = @SS8, SS9 = @SS9, SS10 = @SS10,SS11 = @SS11, SS12 = @SS12, SS13 = @SS13, SS14 = @SS14, SS15 = @SS15, SS16 = @SS16, SS17 = @SS17, SS18 = @SS18, SS19 = @SS19, SS20 = @SS20,SS21 = @SS21, SS22 = @SS22, SS23 = @SS23, SS24 = @SS24, SS25 = @SS25, SS26 = @SS26, SS27 = @SS27, SS28 = @SS28, SS29 = @SS29, SS30 = @SS30, SS31 = @SS31, SS32 = @SS32, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDSS = @IDSS", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD


                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDSS", SqlDbType.Int).Value = Me.IDss.Text

                .Parameters.Add("@SS1", SqlDbType.Date).Value = Me.DateT.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@SS2", SqlDbType.NVarChar).Value = Me.ComboAssociationName.Text
                .Parameters.Add("@SS3", SqlDbType.NVarChar).Value = Me.TextAssociationNationalNumber.Text
                .Parameters.Add("@SS4", SqlDbType.NVarChar).Value = Me.TextType.Text.Trim
                .Parameters.Add("@SS5", SqlDbType.NVarChar).Value = Me.TextDirectorateName.Text
                .Parameters.Add("@SS6", SqlDbType.NVarChar).Value = Me.TextWorkOfAssociation.Text
                .Parameters.Add("@SS7", SqlDbType.Int).Value = Me.ComboFiscalYear.Text.Trim
                .Parameters.Add("@SS8", SqlDbType.Int).Value = Me.TextNumberOfManagementCommittee.Text
                .Parameters.Add("@SS9", SqlDbType.NVarChar).Value = Me.TextSecretary.Text
                .Parameters.Add("@SS10", SqlDbType.NVarChar).Value = Me.TextCashier.Text
                .Parameters.Add("@SS11", SqlDbType.Int).Value = Me.TextNumberOfMonitoringCommittee.Text
                .Parameters.Add("@SS12", SqlDbType.NVarChar).Value = Me.TextAssociationAccountant.Text
                .Parameters.Add("@SS13", SqlDbType.Int).Value = Me.TextNumberOfPermanentWorkers.Text
                .Parameters.Add("@SS14", SqlDbType.Int).Value = Me.TextNumberOfSeasonalWorkers.Text
                .Parameters.Add("@SS15", SqlDbType.Int).Value = Me.TextNumberOfMembersAtBeginningOfYear.Text
                .Parameters.Add("@SS16", SqlDbType.Int).Value = Me.TextNumberOfMembersWhoWereAcceptedDuringYear.Text
                .Parameters.Add("@SS17", SqlDbType.Int).Value = Me.TextNumberOfWithdrawnMembers.Text
                .Parameters.Add("@SS18", SqlDbType.Int).Value = Me.TextNumberOfMembersAtEndOfYear.Text
                .Parameters.Add("@SS19", SqlDbType.Float).Value = Me.TextSharesSubscribedAtBeginningOfYear.EditValue
                .Parameters.Add("@SS20", SqlDbType.Float).Value = Me.TextSharesPaidAtBeginningOfYear.EditValue
                .Parameters.Add("@SS21", SqlDbType.Float).Value = Me.TextRatioOfPrivateCapitalToAssetsOfAssociation.EditValue
                .Parameters.Add("@SS22", SqlDbType.Float).Value = Me.TextInvestmentRate.EditValue
                .Parameters.Add("@SS23", SqlDbType.Float).Value = Me.TextLoanAmountAtEndOfYear.EditValue
                .Parameters.Add("@SS24", SqlDbType.Float).Value = Me.TextSavingsAreReturnsOnStocks.EditValue
                .Parameters.Add("@SS25", SqlDbType.Float).Value = Me.TextSeasonalLending.EditValue
                .Parameters.Add("@SS26", SqlDbType.Float).Value = Me.TextMediumTerm.EditValue
                .Parameters.Add("@SS27", SqlDbType.Float).Value = Me.TextSales.EditValue
                .Parameters.Add("@SS28", SqlDbType.Float).Value = Me.TextMarketing.EditValue
                .Parameters.Add("@SS29", SqlDbType.Int).Value = Me.TextNumberOfGeneralAssemblyMeetings.Text
                .Parameters.Add("@SS30", SqlDbType.NVarChar).Value = Me.TextNumberOfAttendeesAtEachMeeting.Text
                .Parameters.Add("@SS31", SqlDbType.Int).Value = Me.TextNumberOfManagementCommitteeMeetings.Text
                .Parameters.Add("@SS32", SqlDbType.Int).Value = Me.TextNumberOfOversightCommitteeMeetings.Text


                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                If InternalAuditor = True Then
                    .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Logentry
                    .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = USERNAME
                Else
                    .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                    .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = DBNull.Value
                End If
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
            Insert_Actions(Me.TextAssociationNationalNumber.Text, "تعديل", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub






<<<<<<< HEAD
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
=======
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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

        'If Me.CheckBox3.Checked = True Then
        '    MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
        '    Exit Sub
        'End If
        Static P As Integer
        P = Me.BS.Position

        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
<<<<<<< HEAD
        Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Click2 = True
    End Sub

<<<<<<< HEAD
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
=======
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        BS.CancelEdit()

    End Sub

<<<<<<< HEAD
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
=======
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim rpt As New CrystalStatisticalStatement
        Dim F As New FrmPRINT
        GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
        Dim ds As New DataSet
        Dim str As New SqlCommand("SELECT * FROM StatisticalStatement   WHERE  CUser='" & ModuleGeneral.CUser & "' and SS7 ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  ", Consum)
        Dim builder19 As New SqlCommandBuilder(SqlDataAdapter1)
<<<<<<< HEAD
        SqlDataAdapter1 = New SqlDataAdapter(str)
=======
        SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        SqlDataAdapter1.Fill(ds, "StatisticalStatement")
        rpt.SetDataSource(ds)
        Dim txt As TextObject
        F.CrystalReportViewer1.ReportSource = rpt
        F.CrystalReportViewer1.Zoom(90%)
        F.CrystalReportViewer1.Refresh()
        F.Show()

    End Sub

End Class