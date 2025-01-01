Imports System.Data.SqlClient
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Collections.Generic
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

            Consum.Close()
            FILLCOMBOBOX1("MOVES", "MOV11", "CUser", ModuleGeneral.CUser, Me.ComboMovementSymbol)
            Me.ComboAccount.DataSource = GetData(NUpDownAccountLevel.Value)
            Me.ComboAccount.DisplayMember = "account_name"


            Call MangUsers()
            SqlDataAdapter1.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorfrmDailyrestrictions2_Load", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub ButtonReloading_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonReloading.Click
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSearchDataView", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub ButtonEnquiry_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonEnquiry.Click
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية قرات السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Try

            Dim Consum As New SqlConnection(constring)
            If Me.RadioButton2.Checked = True Then
                Dim str As New SqlCommand("", Consum)
                With str
                    .CommandText = "select MOVES.MOV2 ,MOVES.MOV3,MOVES.MOV11 ,MOVES.CUser,  MOVESDATA.MOVD4, MOVESDATA.MOVD3, MOVESDATA.MOVD5, MOVESDATA.MOVD6 ,MOVES.MOV10 , MOVESDATA.MOVD10  from MOVES , MOVESDATA WHERE   MOVES.CUser='" & ModuleGeneral.CUser & "' and Year(MOVES.MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and   MOVES.MOV2 = MOVESDATA.MOV2 and MOVES.MOV3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND MOVESDATA.MOVD3='" & Me.ComboAccount.Text & "'"
                End With
                Me.SqlDataAdapter1 = New SqlDataAdapter(str)
                dt.Clear()
                dt = New DataTable
                Me.SqlDataAdapter1.Fill(dt)
                Me.GridControl1.DataSource = dt
                Me.SqlDataAdapter1.Dispose()
            ElseIf Me.RadioButton3.Checked = True Then
                Dim str As New SqlCommand("", Consum)
                With str
                    .CommandText = "select MOVES.MOV2 ,MOVES.MOV3,MOVES.MOV11 ,MOVES.CUser,  MOVESDATA.MOVD4, MOVESDATA.MOVD3, MOVESDATA.MOVD5, MOVESDATA.MOVD6 ,MOVES.MOV10 , MOVESDATA.MOVD10  from MOVES , MOVESDATA WHERE   MOVES.CUser='" & ModuleGeneral.CUser & "' and Year(MOVES.MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and   MOVES.MOV2 = MOVESDATA.MOV2 and MOVES.MOV3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND MOVES.MOV11='" & Me.ComboMovementSymbol.Text & "'"
                End With
                Me.SqlDataAdapter1 = New SqlDataAdapter(str)
                dt.Clear()
                dt = New DataTable
                Me.SqlDataAdapter1.Fill(dt)
                Me.GridControl1.DataSource = dt
                Me.SqlDataAdapter1.Dispose()

            ElseIf Me.RadioButton1.Checked = True Then
                Me.SqlDataAdapter1 = New SqlDataAdapter("select MOVES.MOV2 ,MOVES.MOV3,MOVES.MOV11 ,MOVES.CUser,  MOVESDATA.MOVD4, MOVESDATA.MOVD3, MOVESDATA.MOVD5, MOVESDATA.MOVD6 ,MOVES.MOV10 , MOVESDATA.MOVD10 from MOVES , MOVESDATA WHERE   MOVES.CUser='" & ModuleGeneral.CUser & "' and Year(MOVES.MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and   MOVES.MOV2 = MOVESDATA.MOV2 and MOVES.MOV3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' ", Consum)
                Dim dt As New DataTable
                Me.SqlDataAdapter1.Fill(dt)
                Me.GridControl1.DataSource = dt
                Me.SqlDataAdapter1.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorButtonXP1_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

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
                    SEARCHDATA.SEARCHBUYSCASH(Me.GridView1.GetRowCellValue(i, "MOVD4"))
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSelectionChanged", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub GridView1_CurrentCellChanged(sender As Object, e As FocusedRowChangedEventArgs)
        SEARCHFROM()
        Typy()
        For i As Integer = 0 To GridView1.DataRowCount - 1
            If Me.TextTypy.Text = "VE" Then
                SEARCHDATA.SEARCHSLSCASH(Me.GridView1.GetRowCellValue(i, "MOVD4"))
                Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
            ElseIf Me.TextTypy.Text = "PR" Then
                SEARCHDATA.SEARCHBUYSCASH(Me.GridView1.GetRowCellValue(i, "MOVD4"))
                Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
            End If
        Next
        'Dim currentCellValue As Object = GridView1.GetRowCellValue(e.FocusedRowHandle, GridView1.FocusedColumn)

    End Sub

    Private Sub RepositoryItemButtonEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit1.Click
        Try
            'If e.ColumnIndex = 0 Then
            SEARCHFROM()
            Typy()
            Dim currentRowIndex As Integer = GridView1.FocusedRowHandle
            Dim f As New FrmDailyrestrictions With {
                    .TB2 = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("MOV2"))
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
        End Try
    End Sub

    Private Sub Typy()
        Try
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
        Me.ComboAccount.DataSource = GetData(NUpDownAccountLevel.Value)
        Me.ComboAccount.DisplayMember = "account_name"
    End Sub

    Private Sub ButtonSearchWithinNetwork_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonSearchWithinNetwork.Click
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




End Class

