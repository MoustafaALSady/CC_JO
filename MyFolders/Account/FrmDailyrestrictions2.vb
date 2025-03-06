Imports System.Data.SqlClient
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Collections.Generic
<<<<<<< HEAD
Imports DevExpress.XtraGrid.Views.Base
'Imports System.Windows.Forms

Public Class FrmDailyrestrictions2
    Inherits Form
    Dim SqlDataAdapter1 As New SqlDataAdapter
    Dim dt As New DataTable

    Public Sub New()
        InitializeComponent()
        InitializeFormActions()
        AddHandler GridView1.RowCellClick, AddressOf GridView_RowCellClick
        AddHandler GridView1.FocusedRowChanged, AddressOf GridView1_CurrentCellChanged
    End Sub

    ' Dictionary to map form texts to their actions
    Private ReadOnly formActions As New Dictionary(Of String, Action)()



    Private Sub InitializeFormActions()
        ' Common pattern for simple forms: create, set TB1/TB2, show, call method
        'formActions.Add(FrmDailyrestrictions.Text, Sub()
        '                                               Dim f As New FrmDailyrestrictions With {.TB2 = TextSEARCHFROM.Text.Trim}
        '                                               f.Show()
        '                                               f.load1.PerformClick()
        '                                           End Sub)
        'formActions.Add(FrmBanks5.Text, Sub()
        '                                    Dim f As New FrmBanks5 With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                    f.Show()
        '                                    f.DanLOd()
        '                                End Sub)
        'formActions.Add(FrmJO.Text, Sub()
        '                                Dim f As New FrmJO With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                f.Show()
        '                                f.DanLOd()
        '                            End Sub)
        'formActions.Add(FrmEmpsolf.Text, Sub()
        '                                     Dim f As New FrmEmpsolf With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                     f.Show()
        '                                     f.DanLOd()
        '                                 End Sub)
        'formActions.Add(FrmChecks.Text, Sub()
        '                                    Dim f As New FrmChecks With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                    f.Show()
        '                                    f.DanLOd()
        '                                End Sub)
        'formActions.Add(FrmDeposits.Text, Sub()
        '                                      Dim f As New FrmDeposits With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                      f.Show()
        '                                      f.DanLOd()
        '                                  End Sub)
        'formActions.Add(FrmTransaction.Text, Sub()
        '                                         Dim f As New FrmTransaction With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                         f.Show()
        '                                         f.DanLOd()
        '                                     End Sub)
        'formActions.Add(FrmCUSTOMER1.Text, Sub()
        '                                       Dim f As New FrmCUSTOMER1 With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                       f.Show()
        '                                       f.DanLOd()
        '                                   End Sub)
        'formActions.Add(FrmCUSTOMER11.Text, Sub()
        '                                        Dim f As New FrmCUSTOMER11 With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                        f.Show()
        '                                        f.DanLOd()
        '                                    End Sub)
        'formActions.Add(FrmInvoice.Text, Sub()
        '                                     Dim f As New FrmInvoice With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                     f.Show()
        '                                     f.DanLOd()
        '                                 End Sub)
        'formActions.Add(FrmTRANSPORT.Text, Sub()
        '                                       Dim f As New FrmTRANSPORT With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                       f.Show()
        '                                       f.load1.PerformClick()
        '                                   End Sub)
        'formActions.Add(FrmMyCosts.Text, Sub()
        '                                     Dim f As New FrmMyCosts With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                     f.Show()
        '                                     f.DanLOd()
        '                                 End Sub)
        'formActions.Add(FrmSuppliers1.Text, Sub()
        '                                        Dim f As New FrmSuppliers1 With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                        f.Show()
        '                                        f.DanLOd()
        '                                    End Sub)
        'formActions.Add(Loans.Text, Sub()
        '                                Dim f As New Loans With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                f.Show()
        '                                f.load1.PerformClick()
        '                            End Sub)
        'formActions.Add(Loans2.Text, Sub()
        '                                 Dim f As New Loans2 With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                 f.Show()
        '                                 f.DanLOd()
        '                             End Sub)

        '' Forms with additional logic
        'formActions.Add(FrmCustomersA.Text, Sub()
        '                                        Dim currentRowIndex As Integer = GridView1.FocusedRowHandle
        '                                        SEARCHDATA.SEARCHSLSCASH(GridView1.GetRowCellValue(currentRowIndex, "MOV2"))
        '                                        RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
        '                                        Cash = RadInvoiceStatus.Checked
        '                                        Dim f As New FrmCustomersA With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                        f.Show()
        '                                        f.DanLOd()
        '                                    End Sub)

        'formActions.Add(FrmSuppliesA.Text, Sub()
        '                                       Dim currentRowIndex As Integer = GridView1.FocusedRowHandle
        '                                       SEARCHDATA.SEARCHBUYSCASH(GridView1.GetRowCellValue(currentRowIndex, "MOV2"))
        '                                       RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
        '                                       Cash = RadInvoiceStatus.Checked
        '                                       Dim f As New FrmSuppliesA With {.TB1 = TextSEARCHFROM.Text.Trim}
        '                                       f.Show()
        '                                       f.DanLOd()
        '                                   End Sub)

        'formActions.Add(Form_mabeat.Text, Sub()
        '                                      Using Consum As New SqlConnection(constring)
        '                                          Dim str As New SqlCommand("SELECT DataTS, TS9 FROM TodaySales WHERE CUser = @CUser AND YEAR(DataTS) = @FiscalYear AND TS9 = @TS9 ORDER BY ID", Consum)
        '                                          str.Parameters.AddWithValue("@CUser", ModuleGeneral.CUser)
        '                                          str.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
        '                                          str.Parameters.AddWithValue("@TS9", TextSEARCHFROM.Text.Trim)
        '                                          Dim ds As New DataSet
        '                                          Dim adapter As New SqlDataAdapter(str)
        '                                          adapter.Fill(ds, "TodaySales")
        '                                          If ds.Tables("TodaySales").Rows.Count > 0 Then
        '                                              Dim f As New Form_mabeat
        '                                              f.Textdaee1.Text = ds.Tables("TodaySales").Rows(0)("DataTS").ToString()
        '                                              f.Show()
        '                                              f.BuakrT.PerformClick()
        '                                          Else
        '                                              TextSEARCHFROM.Text = Nothing
        '                                          End If
        '                                      End Using
        '                                  End Sub)

        'formActions.Add(FormEmployees4.Text, Sub()
        '                                         Using Consum As New SqlConnection(constring)
        '                                             Dim str As New SqlCommand("SELECT SLY1 FROM SALARIES WHERE CUser = @CUser AND YEAR(SLY26) = @FiscalYear ORDER BY SLY1", Consum)
        '                                             str.Parameters.AddWithValue("@CUser", ModuleGeneral.CUser)
        '                                             str.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
        '                                             Dim ds As New DataSet
        '                                             Dim adapter As New SqlDataAdapter(str)
        '                                             adapter.Fill(ds, "SALARIES")
        '                                             Dim f As New FormEmployees4
        '                                             f.BS.DataSource = ds
        '                                             f.BS.DataMember = "SALARIES"
        '                                             Dim index As Integer = f.BS.Find("SLY1", TextSEARCHFROM.Text.Trim)
        '                                             f.Show()
        '                                             f.Load1.PerformClick()
        '                                             If index >= 0 Then f.BS.Position = index
        '                                         End Using
        '                                     End Sub)


        formActions.Add("RD", Sub()
                                  Dim f As New FrmDailyrestrictions With {.TB2 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.load1.PerformClick()
                              End Sub)
        formActions.Add("SD", Sub()
                                  Dim f As New FrmDeposits With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.DanLOd()
                              End Sub)
        formActions.Add("WD", Sub()
                                  Dim f As New FrmTransaction With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.DanLOd()
                              End Sub)
        formActions.Add("CH", Sub()
                                  Dim f As New FrmBanks5 With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.DanLOd()
                              End Sub)
        formActions.Add("PS", Sub()
                                  Dim f As New FrmEmpsolf With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.DanLOd()
                              End Sub)
        formActions.Add("KS", Sub()
                                  Dim f As New FrmChecks With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.DanLOd()
                              End Sub)
        formActions.Add("BA", Sub()
                                  Dim f As New FrmJO With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.DanLOd()
                              End Sub)
        formActions.Add("BT", Sub()
                                  Dim f As New FrmTRANSPORT With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.load1.PerformClick()
                              End Sub)
        formActions.Add("TL", Sub()
                                  Dim f As New FrmInvoice With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.DanLOd()
                              End Sub)
        formActions.Add("ER", Sub()
                                  Dim f As New FrmCUSTOMER11 With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.DanLOd()
                              End Sub)
        formActions.Add("GE", Sub()
                                  Dim f As New FrmMyCosts With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.DanLOd()
                              End Sub)
        formActions.Add("PR", Sub()
                                  Dim currentRowIndex As Integer = GridView1.FocusedRowHandle
                                  SEARCHDATA.SEARCHBUYSCASH(GridView1.GetRowCellValue(currentRowIndex, "MOV2"))
                                  RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
                                  Cash = RadInvoiceStatus.Checked
                                  Dim f As New FrmSuppliesA With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.DanLOd()
                              End Sub)
        formActions.Add("VE", Sub()
                                  Dim currentRowIndex As Integer = GridView1.FocusedRowHandle
                                  SEARCHDATA.SEARCHSLSCASH(GridView1.GetRowCellValue(currentRowIndex, "MOV2"))
                                  RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
                                  Cash = RadInvoiceStatus.Checked
                                  Dim f As New FrmCustomersA With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.DanLOd()
                              End Sub)
        formActions.Add("QR", Sub()
                                  Using Consum As New SqlConnection(constring)
                                      Dim str As New SqlCommand("SELECT DataTS, TS9 FROM TodaySales WHERE CUser = @CUser AND YEAR(DataTS) = @FiscalYear AND TS9 = @TS9 ORDER BY ID", Consum)
                                      str.Parameters.AddWithValue("@CUser", ModuleGeneral.CUser)
                                      str.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                                      str.Parameters.AddWithValue("@TS9", TextSEARCHFROM.Text.Trim)
                                      Dim ds As New DataSet
                                      Dim adapter As New SqlDataAdapter(str)
                                      adapter.Fill(ds, "TodaySales")
                                      If ds.Tables("TodaySales").Rows.Count > 0 Then
                                          Dim f As New Form_mabeat
                                          f.Textdaee1.Text = ds.Tables("TodaySales").Rows(0)("DataTS").ToString()
                                          f.Show()
                                          f.BuakrT.PerformClick()
                                      Else
                                          TextSEARCHFROM.Text = Nothing
                                      End If
                                  End Using
                              End Sub)
        formActions.Add("PA", Sub()
                                  Dim f As New Loans2 With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.DanLOd()
                              End Sub)
        formActions.Add("LO", Sub()
                                  Dim f As New Loans With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.load1.PerformClick()
                              End Sub)
        formActions.Add("SU", Sub()
                                  Dim f As New FrmSuppliers1 With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.DanLOd()
                              End Sub)
        formActions.Add("ES", Sub()
                                  Using Consum As New SqlConnection(constring)
                                      Dim str As New SqlCommand("SELECT SLY1 FROM SALARIES WHERE CUser = @CUser AND YEAR(SLY26) = @FiscalYear ORDER BY SLY1", Consum)
                                      str.Parameters.AddWithValue("@CUser", ModuleGeneral.CUser)
                                      str.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                                      Dim ds As New DataSet
                                      Dim adapter As New SqlDataAdapter(str)
                                      adapter.Fill(ds, "SALARIES")
                                      Dim f As New FormEmployees4
                                      f.BS.DataSource = ds
                                      f.BS.DataMember = "SALARIES"
                                      Dim index As Integer = f.BS.Find("SLY1", TextSEARCHFROM.Text.Trim)
                                      f.Show()
                                      f.Load1.PerformClick()
                                      If index >= 0 Then f.BS.Position = index
                                  End Using
                              End Sub)
        formActions.Add("AS", Sub()
                                  Dim f As New FrmMyCosts With {.TB1 = TextSEARCHFROM.Text.Trim}
                                  f.Show()
                                  f.DanLOd()
                              End Sub)



    End Sub


    Private Sub FrmDailyrestrictions2_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            Dim Consum As New SqlConnection(constring)
            dt = New DataTable
            Me.SqlDataAdapter1 = New SqlDataAdapter("select MOVES.MOV2 ,MOVES.MOV3,MOVES.MOV11 ,MOVES.CUser,  MOVESDATA.MOVD4, MOVESDATA.MOVD3, MOVESDATA.MOVD5, MOVESDATA.MOVD6 ,MOVES.MOV10 , MOVESDATA.MOVD10  from MOVES , MOVESDATA WHERE   MOVES.CUser='" & ModuleGeneral.CUser & "' and Year(MOVES.MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and   MOVES.MOV2 = MOVESDATA.MOV2 ", Consum)
            Me.SqlDataAdapter1.Fill(dt)
            'Me.DataGridView1.DataSource = dt
            Me.GridControl1.DataSource = dt
=======
'Imports System.Windows.Forms

Public Class FrmDailyrestrictions2
    Inherits System.Windows.Forms.Form
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Dim dt As New DataTable

    'Public Sub New()
    '    InitializeComponent()
    '    AddHandler GridView1.RowCellClick, AddressOf gridView_RowCellClick


    'End Sub


    Private Sub FrmDailyrestrictions2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'On Error Resume Next
        Try

            Dim Consum As New SqlClient.SqlConnection(constring)
            dt = New DataTable
            Me.SqlDataAdapter1 = New SqlDataAdapter("select MOVES.MOV2 ,MOVES.MOV3,MOVES.MOV11 ,MOVES.CUser,  MOVESDATA.MOVD4, MOVESDATA.MOVD3, MOVESDATA.MOVD5, MOVESDATA.MOVD6 ,MOVES.MOV10 , MOVESDATA.MOVD10  from MOVES , MOVESDATA WHERE   MOVES.CUser='" & ModuleGeneral.CUser & "' and Year(MOVES.MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and   MOVES.MOV2 = MOVESDATA.MOV2 ", Consum)
            Me.SqlDataAdapter1.Fill(dt)
            Me.DataGridView1.DataSource = dt
            Me.GridControl1.DataSource = dt
            'Me.GridControl1.
            Me.DataGridView1.Columns(2).HeaderText = "رقم القيد"
            Me.DataGridView1.Columns(3).HeaderText = "التاريخ"
            Me.DataGridView1.Columns.Item(4).Visible = False
            Me.DataGridView1.Columns.Item(5).Visible = False
            Me.DataGridView1.Columns(6).HeaderText = "رقم الحساب"
            Me.DataGridView1.Columns(7).HeaderText = "الحساب"

            Me.DataGridView1.Columns(8).HeaderText = "مدين"
            Me.DataGridView1.Columns(9).HeaderText = "دائن"

            Me.DataGridView1.Columns(10).HeaderText = "رمز القيد"
            Me.DataGridView1.Columns(11).HeaderText = "رقم الحركة"





            Me.TextRowsCount.Text = DataGridView1.Rows.Count
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

            Consum.Close()
            FILLCOMBOBOX1("MOVES", "MOV11", "CUser", ModuleGeneral.CUser, Me.ComboMovementSymbol)
            Me.ComboAccount.DataSource = GetData(NUpDownAccountLevel.Value)
            Me.ComboAccount.DisplayMember = "account_name"
<<<<<<< HEAD


=======
            Me.TotalDebit.Text = DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("MOVD5").Value))
            Me.TotalCred.Text = DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("MOVD6").Value))

            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            Dim Column As New DataGridViewCheckBoxColumn
            With Me.DataGridView1
                .RowsDefaultCellStyle.BackColor = Color.Bisque
                .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
            End With
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Call MangUsers()
            SqlDataAdapter1.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorfrmDailyrestrictions2_Load", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ButtonReloading_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonReloading.Click
=======
    Private Sub ButtonReloading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReloading.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'On Error Resume Next
        Try
            FrmDailyrestrictions2_Load(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorButtonX1_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Sub SearchDataView()
        Try
            Dim dv As DataView = dt.DefaultView
            If Me.RadioB1.Checked = True Then
                dv.RowFilter = "MOVD3 like  '%" & Me.ComboAccount.Text & "%'"
            ElseIf Me.RadioB2.Checked = True Then
                dv.RowFilter = "MOV11 like  '%" & Me.ComboMovementSymbol.Text & "%'"
            ElseIf Me.RadioB3.Checked = True Then
                dv.RowFilter = "MOVD3 like  '%" & Me.ComboAccount.Text & "%' Or  MOV11 like '%" & Me.ComboMovementSymbol.Text & "%'"
            End If
<<<<<<< HEAD
=======
            Me.TotalDebit.Text = Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("MOVD5").Value))
            Me.TotalCred.Text = Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("MOVD6").Value))
            Me.TextRowsCount.Text = Me.DataGridView1.Rows.Count

>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSearchDataView", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ButtonEnquiry_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonEnquiry.Click
=======
    Private Sub ButtonEnquiry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnquiry.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية قرات السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Try

<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Me.RadioButton2.Checked = True Then
                Dim str As New SqlCommand("", Consum)
                With str
                    .CommandText = "select MOVES.MOV2 ,MOVES.MOV3,MOVES.MOV11 ,MOVES.CUser,  MOVESDATA.MOVD4, MOVESDATA.MOVD3, MOVESDATA.MOVD5, MOVESDATA.MOVD6 ,MOVES.MOV10 , MOVESDATA.MOVD10  from MOVES , MOVESDATA WHERE   MOVES.CUser='" & ModuleGeneral.CUser & "' and Year(MOVES.MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and   MOVES.MOV2 = MOVESDATA.MOV2 and MOVES.MOV3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND MOVESDATA.MOVD3='" & Me.ComboAccount.Text & "'"
                End With
<<<<<<< HEAD
                Me.SqlDataAdapter1 = New SqlDataAdapter(str)
                dt.Clear()
                dt = New DataTable
                Me.SqlDataAdapter1.Fill(dt)
                Me.GridControl1.DataSource = dt
=======
                Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                dt.Clear()
                dt = New DataTable
                Me.SqlDataAdapter1.Fill(dt)
                Me.DataGridView1.DataSource = dt
                Me.GridControl1.DataSource = dt
                Me.TotalDebit.Text = Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("MOVD5").Value))
                Me.TotalCred.Text = Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("MOVD6").Value))
                Me.TextRowsCount.Text = Me.DataGridView1.Rows.Count
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Me.SqlDataAdapter1.Dispose()
            ElseIf Me.RadioButton3.Checked = True Then
                Dim str As New SqlCommand("", Consum)
                With str
                    .CommandText = "select MOVES.MOV2 ,MOVES.MOV3,MOVES.MOV11 ,MOVES.CUser,  MOVESDATA.MOVD4, MOVESDATA.MOVD3, MOVESDATA.MOVD5, MOVESDATA.MOVD6 ,MOVES.MOV10 , MOVESDATA.MOVD10  from MOVES , MOVESDATA WHERE   MOVES.CUser='" & ModuleGeneral.CUser & "' and Year(MOVES.MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and   MOVES.MOV2 = MOVESDATA.MOV2 and MOVES.MOV3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND MOVES.MOV11='" & Me.ComboMovementSymbol.Text & "'"
                End With
<<<<<<< HEAD
                Me.SqlDataAdapter1 = New SqlDataAdapter(str)
                dt.Clear()
                dt = New DataTable
                Me.SqlDataAdapter1.Fill(dt)
                Me.GridControl1.DataSource = dt
=======
                Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                dt.Clear()
                dt = New DataTable
                Me.SqlDataAdapter1.Fill(dt)
                Me.DataGridView1.DataSource = dt
                Me.TotalDebit.Text = Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("MOVD5").Value))
                Me.TotalCred.Text = Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("MOVD6").Value))
                Me.TextRowsCount.Text = Me.DataGridView1.Rows.Count
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Me.SqlDataAdapter1.Dispose()

            ElseIf Me.RadioButton1.Checked = True Then
                Me.SqlDataAdapter1 = New SqlDataAdapter("select MOVES.MOV2 ,MOVES.MOV3,MOVES.MOV11 ,MOVES.CUser,  MOVESDATA.MOVD4, MOVESDATA.MOVD3, MOVESDATA.MOVD5, MOVESDATA.MOVD6 ,MOVES.MOV10 , MOVESDATA.MOVD10 from MOVES , MOVESDATA WHERE   MOVES.CUser='" & ModuleGeneral.CUser & "' and Year(MOVES.MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and   MOVES.MOV2 = MOVESDATA.MOV2 and MOVES.MOV3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' ", Consum)
                Dim dt As New DataTable
                Me.SqlDataAdapter1.Fill(dt)
<<<<<<< HEAD
                Me.GridControl1.DataSource = dt
                Me.SqlDataAdapter1.Dispose()
=======
                Me.DataGridView1.DataSource = dt
                Me.TotalDebit.Text = Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("MOVD5").Value))
                Me.TotalCred.Text = Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("MOVD6").Value))
                Me.SqlDataAdapter1.Dispose()
                Me.TextRowsCount.Text = Me.DataGridView1.Rows.Count
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorButtonXP1_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub GridView_RowCellClick(ByVal sender As Object, ByVal e As RowCellClickEventArgs)
        Try
            Me.TextTypy.Text = ""
            Me.TextFormText.Text = ""
            Me.TextSEARCHFROM.Text = ""
            Me.GridView1.OptionsSelection.MultiSelect = True
            Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
            'SEARCHFROM()
            'Typy()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorCellClick", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub GridView1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Try
            For i As Integer = 0 To GridView1.DataRowCount - 1

                If Me.TextTypy.Text = "VE" Then
                    SEARCHDATA.SEARCHSLSCASH(Me.GridView1.GetRowCellValue(i, "MOVD4"))
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
                ElseIf Me.TextTypy.Text = "PR" Then
=======


    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Private Sub gridView_RowCellClick(ByVal sender As Object, ByVal e As RowCellClickEventArgs)


        On Error Resume Next
        'Try
        Me.TextTypy.Text = ""
        Me.TextFormText.Text = ""
        Me.TextSEARCHFROM.Text = ""
        'Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count).Selected = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect

        SEARCHFROM()
        Typy()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ErrorCellClick", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        'On Error Resume Next

    End Sub
    Private Sub GridView1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Try
            'For Each r As DataGridViewRow In Me.GridView1.Rows
            For i As Integer = 0 To GridView1.DataRowCount - 1

                If Me.TextTypy.Text.ToString.Trim = "VE" Then
                    SEARCHDATA.SEARCHSLSCASH(Me.GridView1.GetRowCellValue(i, "MOVD4"))
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
                ElseIf Me.TextTypy.Text.ToString.Trim = "PR" Then
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    SEARCHDATA.SEARCHBUYSCASH(Me.GridView1.GetRowCellValue(i, "MOVD4"))
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
                End If
            Next
<<<<<<< HEAD
=======
            'MsgBox(1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSelectionChanged", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub GridView1_CurrentCellChanged(sender As Object, e As FocusedRowChangedEventArgs)
        SEARCHFROM()
        Typy()
        For i As Integer = 0 To GridView1.DataRowCount - 1
            If Me.TextTypy.Text = "VE" Then
                SEARCHDATA.SEARCHSLSCASH(Me.GridView1.GetRowCellValue(i, "MOVD4"))
                Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
            ElseIf Me.TextTypy.Text = "PR" Then
=======

    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.CellValueChanged
        On Error Resume Next
        'Try
        'For Each r As DataGridViewRow In Me.DataGridView1.Rows
        '    If Me.TextTypy.Text.ToString.Trim = "VE" Then
        '        SEARCHDATA.SEARCHSLSCASH(Me.DataGridView1.CurrentRow.Cells(4).Value)
        '        Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
        '    ElseIf Me.TextTypy.Text.ToString.Trim = "PR" Then
        '        SEARCHDATA.SEARCHBUYSCASH(Me.DataGridView1.CurrentRow.Cells(4).Value)
        '        Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
        '    End If
        'Next
        For i As Integer = 0 To GridView1.DataRowCount - 1

            If Me.TextTypy.Text.ToString.Trim = "VE" Then
                SEARCHDATA.SEARCHSLSCASH(Me.GridView1.GetRowCellValue(i, "MOVD4"))
                Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
            ElseIf Me.TextTypy.Text.ToString.Trim = "PR" Then
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                SEARCHDATA.SEARCHBUYSCASH(Me.GridView1.GetRowCellValue(i, "MOVD4"))
                Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
            End If
        Next
<<<<<<< HEAD
        'Dim currentCellValue As Object = GridView1.GetRowCellValue(e.FocusedRowHandle, GridView1.FocusedColumn)

    End Sub

=======
        'MsgBox(1)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ErrorCurrentCellChanged", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End Try
    End Sub



>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub RepositoryItemButtonEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit1.Click
        Try
            'If e.ColumnIndex = 0 Then
            SEARCHFROM()
            Typy()
<<<<<<< HEAD
            Dim currentRowIndex As Integer = GridView1.FocusedRowHandle
            Dim f As New FrmDailyrestrictions With {
                    .TB2 = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("MOV2"))
=======
            Dim f As New FrmDailyrestrictions With {
                    .TB2 = Me.DataGridView1.CurrentRow.Cells(2).Value
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                }
            f.Show()
            f.Load_Click(sender, e)
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorCurrentCellChanged", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub RepositoryItemButtonEdit2_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit2.Click
        Try
<<<<<<< HEAD
            SEARCHFROM()
            Typy()
            Dim formText As String = TextTypy.Text
            If formActions.ContainsKey(formText) Then
                formActions(formText)()
            Else
                MessageBox.Show($"Unknown form text: {formText}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Optional: Log the error to a file or system log
=======
            Dim Consum As New SqlClient.SqlConnection(constring)

            'If e.ColumnIndex = 1 Then
            SEARCHFROM()
            Typy()
            If Me.TextFormText.Text.Trim = FrmDailyrestrictions.Text Then
                Dim f1 As New FrmDailyrestrictions With {
                        .TB2 = Me.TextSEARCHFROM.Text.Trim
                    }
                f1.Show()
                f1.Load_Click(sender, e)

            ElseIf Me.TextFormText.Text.Trim = FrmBanks5.Text Then
                Dim f As New FrmBanks5 With {
                        .TB1 = Me.TextSEARCHFROM.Text.Trim
                    }
                f.Show()
                f.DanLOd()

            ElseIf Me.TextFormText.Text = FrmJO.Text Then
                Dim f2 As New FrmJO With {
                        .TB1 = Me.TextSEARCHFROM.Text
                    }
                f2.Show()
                f2.DanLOd()

            ElseIf Me.TextFormText.Text.Trim = FrmEmpsolf.Text Then
                Dim f3 As New FrmEmpsolf With {
                        .TB1 = Me.TextSEARCHFROM.Text.Trim
                    }

                f3.Show()
                f3.DanLOd()

            ElseIf Me.TextFormText.Text.Trim = FrmChecks.Text Then
                Dim f4 As New FrmChecks With {
                        .TB1 = Me.TextSEARCHFROM.Text.Trim
                    }
                f4.Show()
                f4.DanLOd()

            ElseIf Me.TextFormText.Text.Trim = Trim(FrmDeposits.Text) Then
                Dim f5 As New FrmDeposits With {
                        .TB1 = Me.TextSEARCHFROM.Text.Trim
                    }
                f5.Show()
                f5.DanLOd()

            ElseIf Me.TextFormText.Text.Trim = FrmTransaction.Text Then
                Dim f5 As New FrmTransaction With {
                        .TB1 = Me.TextSEARCHFROM.Text.Trim
                    }
                f5.Show()
                f5.DanLOd()

            ElseIf Me.TextFormText.Text.Trim = FrmCustomersA.Text Then
                SEARCHDATA.SEARCHSLSCASH(Me.DataGridView1.CurrentRow.Cells(4).Value)
                Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
                Dim f6 As New FrmCustomersA
                If Me.RadInvoiceStatus.Checked = True Then
                    Cash = True
                Else
                    Cash = False
                End If
                f6.TB1 = Trim(Me.TextSEARCHFROM.Text.Trim)
                f6.Show()
                f6.DanLOd()
            ElseIf Me.TextFormText.Text.Trim = Form_mabeat.Text Then
                Dim ds8 As New DataSet
                Dim SqlDataAdapter8 As New SqlClient.SqlDataAdapter
                Dim f8 As New Form_mabeat
                ds8.EnforceConstraints = False
                Dim str As New SqlCommand("SELECT  DataTS, TS9  FROM TodaySales WHERE   CUser='" & ModuleGeneral.CUser & "' and Year(DataTS) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and TS9 ='" & TextSEARCHFROM.Text & "'ORDER BY ID", Consum)
                SqlDataAdapter8 = New SqlClient.SqlDataAdapter(str)
                Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter8)
                ds8.Clear()
                SqlDataAdapter8.Fill(ds8, "TodaySales")
                f8.BS.DataMember = "TodaySales"
                f8.BS.DataSource = ds8
                Dim index As Integer
                index = f8.BS.Find("TS9", Me.TextSEARCHFROM.Text.Trim)
                If ds8.Tables.Item(0).Rows.Count > 0 Then
                    f8.Textdaee1.Text = ds8.Tables(0).Rows(0).Item(0)
                    f8.Show()
                    f8.BuakrT_Click(sender, e)
                Else
                    Me.TextSEARCHFROM.Text = Nothing
                End If

            ElseIf Me.TextFormText.Text.Trim = FrmSuppliesA.Text Then
                SEARCHDATA.SEARCHBUYSCASH(Me.DataGridView1.CurrentRow.Cells(4).Value)
                Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
                Dim f7 As New FrmSuppliesA
                Cash = True
                If Me.RadInvoiceStatus.Checked = True Then
                    Cash = True
                Else
                    Cash = False
                End If
                f7.TB1 = Trim(Me.TextSEARCHFROM.Text.Trim)
                f7.Show()
                f7.DanLOd()

            ElseIf Me.TextFormText.Text.Trim = FrmCUSTOMER1.Text Then
                Dim f8 As New FrmCUSTOMER1 With {
                        .TB1 = Me.TextSEARCHFROM.Text.Trim
                    }
                f8.Show()
                f8.DanLOd()

            ElseIf Me.TextFormText.Text.Trim = FrmCUSTOMER11.Text Then
                Dim f9 As New FrmCUSTOMER11 With {
                        .TB1 = Me.TextSEARCHFROM.Text.Trim
                    }
                f9.Show()
                f9.DanLOd()

            ElseIf Me.TextFormText.Text.Trim = FrmInvoice.Text Then
                Dim f10 As New FrmInvoice With {
                        .TB1 = Me.TextSEARCHFROM.Text.Trim
                    }
                f10.Show()
                f10.DanLOd()

            ElseIf Me.TextFormText.Text.Trim = FrmTRANSPORT.Text Then
                Dim f11 As New FrmTRANSPORT With {
                        .TB1 = Me.TextSEARCHFROM.Text.Trim
                    }
                f11.Show()
                f11.Load_Click(sender, e)

            ElseIf Me.TextFormText.Text.Trim = Trim(FrmMyCosts.Text) Then
                Dim f12 As New FrmMyCosts With {
                        .TB1 = Me.TextSEARCHFROM.Text.Trim
                    }
                f12.Show()
                f12.DanLOd()

            ElseIf Me.TextFormText.Text.Trim = FrmSuppliers1.Text Then
                Dim f13 As New FrmSuppliers1 With {
                        .TB1 = Me.TextSEARCHFROM.Text.Trim
                    }
                f13.Show()
                f13.DanLOd()

            ElseIf Me.TextFormText.Text.Trim = FormEmployees4.Text Then
                Dim ds14 As New DataSet
                Dim SqlDataAdapter14 As New SqlClient.SqlDataAdapter
                Dim f14 As New FormEmployees4
                ds14.EnforceConstraints = False
                Dim str As New SqlCommand("SELECT SLY1 FROM SALARIES WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  ORDER BY SLY1", Consum)
                SqlDataAdapter14 = New SqlClient.SqlDataAdapter(str)
                Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter14)
                ds14.Clear()
                SqlDataAdapter14.Fill(ds14, "SALARIES")
                f14.BS.DataMember = "SALARIES"
                f14.BS.DataSource = ds14
                Dim index As Integer
                index = f14.BS.Find("SLY1", Me.TextSEARCHFROM.Text.Trim)
                f14.Show()
                f14.Load_Click(sender, e)
                f14.BS.Position = index

            ElseIf Me.TextFormText.Text.Trim = Loans.Text Then
                Dim f15 As New Loans With {
                        .TB1 = Trim(Me.TextSEARCHFROM.Text.Trim)
                    }
                f15.Show()
                f15.Load_Click(sender, e)

            ElseIf Me.TextFormText.Text.Trim = Loans2.Text Then
                Dim f16 As New Loans2 With {
                        .TB1 = Trim(Me.TextSEARCHFROM.Text.Trim)
                    }
                f16.Show()
                f16.DanLOd()
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorCurrentCellChanged", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    'Private Sub DataGridView1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
    '    Try

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Errore.ColumnIndex", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Exit Sub
    '    End Try
    'End Sub
    'Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

    '    Try
    '        Dim f As New FrmDailyrestrictions With {
    '            .TB2 = Me.DataGridView1.CurrentRow.Cells(2).Value
    '        }
    '        f.Show()
    '        f.Load_Click(sender, e)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "ErrorCellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Exit Sub
    '    End Try
    'End Sub

    Private Sub SEARCHFROM()
        Try
            Me.TextTypy.Text = LSet(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value(), 2)
            If Me.TextTypy.Text.ToString.Trim = "RD" Then
                SEARCHDATA.SEARCHMOVES(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.MOV1.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "SD" Then
                SEARCHDATA.SEARCHID2(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.TBNK1.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "WD" Then
                SEARCHDATA.SEARCHID3(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.TBNK1A.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "CH" Then
                SEARCHDATA.SEARCHCASHIERA1(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.CSH1C.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "PS" Then
                SEARCHDATA.SEARCHEMPSOLF(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.CSH1E.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "CA" Then
                SEARCHDATA.SEARCHCABLESA(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.IDCABS3.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "BA" Then
                SEARCHDATA.SEARCHID4(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.EBNK1.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "BT" Then
                SEARCHDATA.SEARCHID5(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.PTRO1.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "TL" Then
                SEARCHDATA.SEARCHID6(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.PTRO1A.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "ER" Then
                SEARCHDATA.SEARCHID7(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.CEMP3.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "GE" Then
                SEARCHDATA.SEARCHID8(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.CST1.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "PR" Then
                SEARCHDATA.SEARCHID9(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.BUY1.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "VE" Then
                SEARCHDATA.SEARCHID10(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.SLS1.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "QR" Then
                Dim Consum As New SqlConnection(ModuleGeneral.constring)
                Dim ds8 As New DataSet
                Dim SqlDataAdapter8 As New SqlClient.SqlDataAdapter
                Dim SqlConnection8 As New SqlClient.SqlConnection
                Dim f8 As New Form_mabeat
                ds8.EnforceConstraints = False
                Dim str As New SqlCommand("SELECT TS9 FROM TodaySales WHERE   CUser='" & ModuleGeneral.CUser & "' and Year(DataTS) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY ID", Consum)
                SqlDataAdapter8 = New SqlClient.SqlDataAdapter(str)
                ds8.Clear()
                Consum.Open()
                SqlDataAdapter8.Fill(ds8, "TodaySales")
                If ds8.Tables.Item(0).Rows.Count > 0 Then
                    Me.TextSEARCHFROM.Text = ds8.Tables.Item(0).Rows.Item(0).Item(0)
                Else
                    Me.TextSEARCHFROM.Text = Nothing
                End If
                Consum.Close()

            ElseIf Me.TextTypy.Text.ToString.Trim = "PA" Then

                Me.TextSEARCHFROM.Text = SEARCHDATA.SEARCHID(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
            ElseIf Me.TextTypy.Text.ToString.Trim = "LO" Then
                SEARCHDATA.SEARCHID1(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.Lo1.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "SU" Then
                SEARCHDATA.SEARCHDSuppliersA(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.IDSuppliesA.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "KS" Then
                SEARCHDATA.SEARCHID11(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.IDCH1.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "ES" Then
                SEARCHDATA.SEARCHID12(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.SLY1.ToString
            ElseIf Me.TextTypy.Text.ToString.Trim = "AS" Then
                SEARCHDATA.SEARCHEMPCOSTID(Me.DataGridView1.Item(4, Me.DataGridView1.CurrentRow.Index).Value())
                Me.TextSEARCHFROM.Text = SEARCHDATA.IDEmpCost
            Else
                Me.TextSEARCHFROM.Text = Me.TextTypy.Text
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSEARCHFROM", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        End Try
    End Sub

    Private Sub Typy()
        Try
<<<<<<< HEAD
            Dim formMappings As New Dictionary(Of String, Form) From {
            {"RD", New FrmDailyrestrictions()},
            {"SD", New FrmDeposits()},
            {"WD", New FrmTransaction()},
            {"CH", New FrmBanks5()},
            {"PS", New FrmEmpsolf()},
            {"KS", New FrmChecks()},
            {"BA", New FrmJO()},
            {"BT", New FrmTRANSPORT()},
            {"TL", New FrmInvoice()},
            {"ER", New FrmCUSTOMER11()},
            {"GE", New FrmMyCosts()},
            {"PR", New FrmSuppliesA()},
            {"VE", New FrmCustomersA()},
            {"QR", New Form_mabeat()},
            {"PA", New CustomerPay()},
            {"LO", New Loans()},
            {"SU", New FrmSuppliers1()},
            {"ES", New FormEmployees4()},
            {"AS", New FrmEmpCost()}
        }

            Dim key As String = Me.TextTypy.Text

            If formMappings.ContainsKey(key) Then
                Me.TextFormText.Text = Trim(formMappings(key).Text)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Errortypy", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub SEARCHFROM()
        Try
            Dim currentRowIndex As Integer = GridView1.FocusedRowHandle
            Dim value As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("MOV11"))
            Me.TextTypy.Text = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("MOV10"))

            Dim searchActions As New Dictionary(Of String, Action) From {
            {"RD", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHMOVES, value, SEARCHDATA.MOV1.ToString)},
            {"SD", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHID2, value, SEARCHDATA.TBNK1.ToString)},
            {"WD", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHID3, value, SEARCHDATA.TBNK1A.ToString)},
            {"CH", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHCASHIERA1, value, SEARCHDATA.CSH1C.ToString)},
            {"PS", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHEMPSOLF, value, SEARCHDATA.CSH1E.ToString)},
            {"CA", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHCABLESA, value, SEARCHDATA.IDCABS3.ToString)},
            {"BA", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHID4, value, SEARCHDATA.EBNK1.ToString)},
            {"BT", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHID5, value, SEARCHDATA.PTRO1.ToString)},
            {"TL", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHID6, value, SEARCHDATA.PTRO1A.ToString)},
            {"ER", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHID7, value, SEARCHDATA.CEMP3.ToString)},
            {"GE", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHID8, value, SEARCHDATA.CST1.ToString)},
            {"PR", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHID9, value, SEARCHDATA.BUY1.ToString)},
            {"VE", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHID10, value, SEARCHDATA.SLS1.ToString)},
            {"QR", Sub() Me.TextSEARCHFROM.Text = SearchTodaySales()},
            {"PA", Sub() Me.TextSEARCHFROM.Text = SEARCHDATA.SEARCHID(value)},
            {"LO", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHID1, value, SEARCHDATA.Lo1.ToString)},
            {"SU", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHDSuppliersA, value, SEARCHDATA.IDSuppliesA.ToString)},
            {"KS", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHID11, value, SEARCHDATA.IDCH1.ToString)},
            {"ES", Sub() ExecuteSearchAction(AddressOf SEARCHDATA.SEARCHID12, value, SEARCHDATA.SLY1.ToString)},
            {"AS", Sub() Me.TextSEARCHFROM.Text = SEARCHDATA.IDEmpCost}
        }

            If searchActions.ContainsKey(Me.TextTypy.Text) Then
                searchActions(Me.TextTypy.Text).Invoke()
            Else
                Me.TextSEARCHFROM.Text = Me.TextTypy.Text
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSEARCHFROM", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub ExecuteSearchAction(searchMethod As Action(Of Object), value As Object, result As String)
        searchMethod(value)
        Me.TextSEARCHFROM.Text = result
    End Sub

    Private Function SearchTodaySales() As String
        Using Consum As New SqlConnection(ModuleGeneral.constring)
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT TS9 FROM TodaySales WHERE CUser='" & ModuleGeneral.CUser & "' and Year(DataTS) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY ID", Consum)
            Using SqlDataAdapter8 As New SqlDataAdapter(str)
                ds.Clear()
                Consum.Open()
                SqlDataAdapter8.Fill(ds, "TodaySales")
            End Using
            If ds.Tables.Item(0).Rows.Count > 0 Then
                Return ds.Tables.Item(0).Rows.Item(0).Item(0).ToString()
            End If
        End Using
        Return Nothing
    End Function

    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpDownAccountLevel.ValueChanged
=======
            If Me.TextTypy.Text.ToString.Trim = "RD" Then
                Dim FDailyrestrictions As New FrmDailyrestrictions
                Me.TextFormText.Text = Trim(FDailyrestrictions.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "SD" Then ' شهادات الاسهم _ الودائع SD
                Dim FrmDeposits As New FrmDeposits
                Me.TextFormText.Text = Trim(FrmDeposits.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "WD" Then 'السحب والإيداع WD
                Dim FTransaction As New FrmTransaction
                Me.TextFormText.Text = Trim(FTransaction.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "CH" Then  'الصندوق 
                Dim FrmBanks As New FrmBanks5
                Me.TextFormText.Text = Trim(FrmBanks.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "PS" Then  'عهدة الموظفين 
                Dim FEmpsolf As New FrmEmpsolf
                Me.TextFormText.Text = Trim(FEmpsolf.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "KS" Then  'الشيكات 
                Dim FChecks As New FrmChecks
                Me.TextFormText.Text = Trim(FChecks.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "BA" Then  'البنك 
                Dim FJO As New FrmJO
                Me.TextFormText.Text = Trim(FJO.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "BT" Then   'فاتورة نقل   
                Dim FTRANSPORT As New FrmTRANSPORT
                Me.TextFormText.Text = Trim(FTRANSPORT.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "TL" Then   'فاتورة نقل تفصيلية  
                Dim FInvoice As New FrmInvoice
                Me.TextFormText.Text = Trim(FInvoice.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "ER" Then 'م تخليص 
                Dim FCUSTOMER As New FrmCUSTOMER11
                Me.TextFormText.Text = Trim(FCUSTOMER.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "GE" Then  'م . عامة  
                Dim FMyCosts As New FrmMyCosts
                Me.TextFormText.Text = Trim(FMyCosts.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "PR" Then 'المشتريات 
                Dim FSuppliesA As New FrmSuppliesA
                Me.TextFormText.Text = FSuppliesA.Text
            ElseIf Me.TextTypy.Text.ToString.Trim = "VE" Then 'المبيعات 
                Dim FCustomersA As New FrmCustomersA
                Me.TextFormText.Text = Trim(FCustomersA.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "QR" Then 'المبيعات 
                Dim F_mabeat As New Form_mabeat
                Me.TextFormText.Text = Trim(F_mabeat.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "PA" Then 'الدفعات
                Dim FCustomerPay As New CustomerPay
                Me.TextFormText.Text = Trim(FCustomerPay.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "LO" Then 'الذمم المدينة
                Dim FLoans As New Loans
                Me.TextFormText.Text = Trim(FLoans.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "SU" Then 'الذمم الدائنة
                Dim FSuppliers As New FrmSuppliers1
                Me.TextFormText.Text = Trim(FSuppliers.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "ES" Then
                Dim employees As New FormEmployees4
                Me.TextFormText.Text = Trim(employees.Text)
            ElseIf Me.TextTypy.Text.ToString.Trim = "AS" Then
                Dim employees As New FrmEmpCost
                Me.TextFormText.Text = Trim(employees.Text)
            Else

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Errortypy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpDownAccountLevel.ValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ComboAccount.DataSource = GetData(NUpDownAccountLevel.Value)
        Me.ComboAccount.DisplayMember = "account_name"
    End Sub

<<<<<<< HEAD
    Private Sub ButtonSearchWithinNetwork_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonSearchWithinNetwork.Click
=======
    Private Sub ButtonSearchWithinNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearchWithinNetwork.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            SearchDataView()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorButtonX2_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub Panel9_Paint(sender As Object, e As PaintEventArgs) Handles Panel9.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel9.ClientRectangle, Color.Wheat, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel3.ClientRectangle, Color.Wheat, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel4.ClientRectangle, Color.Wheat, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel5.ClientRectangle, Color.Wheat, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel6.ClientRectangle, Color.Wheat, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel7.ClientRectangle, Color.Wheat, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) Handles Panel8.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel8.ClientRectangle, Color.Wheat, ButtonBorderStyle.Solid)
    End Sub

<<<<<<< HEAD



End Class

=======
End Class
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
