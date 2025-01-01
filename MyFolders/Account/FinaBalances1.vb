Imports System.Data.SqlClient
Imports CC_JO.PrintGridView
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraVerticalGrid.Events

Public Class FinaBalances1
    Inherits Form

    Public Sub New()
        InitializeComponent()
        ' Add the event handler for CurrentCellChanged
        AddHandler GridView1.RowCellClick, AddressOf GridView_RowCellClick
        'AddHandler GridView1.FocusedRowChanged, AddressOf GridView1_CurrentCellChanged
    End Sub

    Private Sub Finabalances1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.BackWorker1 = New ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.BackWorker1.RunWorkerAsync()

    End Sub

    Sub SELECT_mov()

        'On Error Resume Next
        'Dim dataTable As New DataTable()

        If AccountantA = True Then
            'Call SELECT_MOVES2(Me.DataGridView1)
            'Call SELECT_MOVES2(Me.GridView1)
        ElseIf FinanceAuditA = True Then
            'Call SELECT_MOVES3(Me.DataGridView1)
            'Call SELECT_MOVES3(Me.GridView1)
        Else
            'Call SELECT_MOVES1(Me.DataGridView1)
            Call SELECT_MOVES1(Me.GridControl1)
        End If
        'GridView1.Columns
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ErrorFinabalances1_Load", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Sub CircularProgressA()
        On Error Resume Next
        Me.CircularProgress1.Value = 0
        Me.CircularProgress1.Visible = True
        Me.CircularProgress1.IsRunning = True
        AccountantA = False
        FinanceAuditA = False
    End Sub

    Private Sub BackWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker1.DoWork
        Me.CircularProgressA()

        BackWorker1.ReportProgress(100)
        Threading.Thread.Sleep(100)
    End Sub

    Private Sub BackWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackWorker1.ProgressChanged
        Me.CircularProgress1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker1.RunWorkerCompleted
        Me.SELECT_mov()
        ' InitializeDataGridView()
        Me.CircularProgress1.IsRunning = False
        Me.CircularProgress1.Visible = False
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub GridView1_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Try
            Dim currentRowIndex As Integer = GridView1.FocusedRowHandle
            Dim value As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("ID"))
            Dim value1 As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("Date"))
            Dim TypeName As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("TypeName"))
            For i As Integer = 0 To GridView1.DataRowCount - 1
                If TypeName = "المبيعات" Then
                    SEARCHDATA.SEARCHSLSCASH(value)
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
                ElseIf TypeName = "المشتريات" Then
                    SEARCHDATA.SEARCHBUYSCASH(value)
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSelectionChanged", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub GridView1_CurrentCellChanged(sender As Object, e As FocusedRowChangedEventArgs)
        Try
            Dim currentRowIndex As Integer = GridView1.FocusedRowHandle
            Dim value As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("ID"))
            Dim value1 As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("Date"))
            Dim TypeName As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("TypeName"))
            For i As Integer = 0 To GridView1.DataRowCount - 1
                If TypeName = "المبيعات" Then
                    SEARCHDATA.SEARCHSLSCASH(value)
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
                ElseIf TypeName = "المشتريات" Then
                    SEARCHDATA.SEARCHBUYSCASH(value)
                    Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSelectionChanged", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub GridView_RowCellClick(ByVal sender As Object, ByVal e As RowCellClickEventArgs)
        Try
            Me.GridView1.OptionsSelection.MultiSelect = True
            Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorCellClick", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Dim Consum As New SqlConnection(constring)
        Dim currentRowIndex As Integer = GridView1.FocusedRowHandle
        Dim value As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("ID"))
        Dim value1 As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("Date"))
        Dim TypeName As Object = GridView1.GetRowCellValue(currentRowIndex, GridView1.Columns("TypeName"))

        If TypeName = "القيود المحاسبة" Then
            Dim f1 As New FrmDailyrestrictions With {
                .TB2 = value
            }
            f1.Show()
            f1.Load_Click(sender, e)

        ElseIf TypeName = "الصندوق" Then
            Dim f As New FrmBanks5 With {
                .TB1 = value
            }
            f.Show()
            f.DanLOd()

        ElseIf TypeName = "البنك" Then
            Dim f2 As New FrmJO With {
                .TB1 = value
            }
            f2.Show()
            f2.DanLOd()

        ElseIf TypeName = "الموظفين" Then
            Dim f3 As New FrmEmpsolf With {
                .TB1 = value
            }
            f3.Show()
            f3.DanLOd()

        ElseIf TypeName = "الشيكات" Then
            Dim f4 As New FrmChecks With {
                .TB1 = value
            }
            f4.Show()
            f4.DanLOd()

        ElseIf TypeName = "الاسهم" Then
            Dim f5 As New FrmDeposits With {
                .TB1 = value
            }
            f5.Show()
            f5.DanLOd()

        ElseIf TypeName = "حركات السحب والايداعات النقدية" Then
            Dim f5 As New FrmTransaction With {
                .TB1 = value
            }
            f5.Show()
            f5.DanLOd()

        ElseIf TypeName = "المبيعات" Then
            SEARCHDATA.SEARCHSLSCASH(value)
            Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
            Dim f6 As New FrmCustomersA
            If Me.RadInvoiceStatus.Checked = True Then
                Cash = True
            Else
                Cash = False
            End If
            f6.TB1 = value
            f6.Show()
            f6.DanLOd()
        ElseIf TypeName = "المببعات_اليومية" Then
            Dim f8 As New Form_mabeat With {
                .TEST = True
            }
            f8.Textdaee1.Value = value1
            f8.Show()
            f8.BuakrT_Click(sender, e)

        ElseIf TypeName = "المشتريات" Then
            SEARCHDATA.SEARCHBUYSCASH(value)
            Me.RadInvoiceStatus.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
            Dim f7 As New FrmSuppliesA
            Cash = True
            If Me.RadInvoiceStatus.Checked = True Then
                Cash = True
            Else
                Cash = False
            End If
            f7.TB1 = value
            f7.Show()
            f7.DanLOd()

        ElseIf TypeName = "العملاء" Then
            Dim f8 As New FrmCUSTOMER1 With {
                .TB1 = value
            }
            f8.Show()
            f8.DanLOd()

        ElseIf TypeName = "مصاريف المشتريات" Then
            Dim f9 As New FrmCUSTOMER11 With {
                .TB1 = value
            }
            f9.Show()
            f9.DanLOd()

        ElseIf TypeName = "فاتورة نقل تفصيلية" Then
            Dim f10 As New FrmInvoice With {
                .TB1 = value,
                .TB1_chk = True
            }
            f10.Show()
            f10.DanLOd()

        ElseIf TypeName = "فاتورة نقل" Then
            Dim f11 As New FrmTRANSPORT With {
                .TB1 = value,
                .TB1_chk = True
            }
            f11.Show()
            f11.Load_Click(sender, e)
        ElseIf TypeName = "المصاريف العامة" Then
            Dim f12 As New FrmMyCosts With {
                .TB1 = value
            }
            f12.Show()
            f12.DanLOd()

        ElseIf TypeName = "الموردين" Then
            Dim f13 As New FrmSuppliers1 With {
                .TB1 = value
            }
            f13.Show()
            f13.DanLOd()

        ElseIf TypeName = "المرتبات والاجور" Then
            Dim ds14 As New DataSet
            Dim f14 As New FormEmployees4
            ds14.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT SLY1 FROM SALARIES WHERE  CUser='" & CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  ORDER BY SLY1", Consum)
            Dim SqlDataAdapter14 As New SqlDataAdapter(str)
            ds14.Clear()
            SqlDataAdapter14.Fill(ds14, "SALARIES")
            f14.BS.DataMember = "SALARIES"
            f14.BS.DataSource = ds14
            Dim index As Integer
            index = f14.BS.Find("SLY1", value)
            f14.Show()
            f14.Load_Click(sender, e)
            f14.BS.Position = index

        ElseIf TypeName = "القروض" Then
            Dim f15 As New Loans With {
                .TB1 = Trim(value)
            }
            f15.Show()
            f15.Load_Click(sender, e)

        ElseIf TypeName = "تسديدات العملاء" Then
            Dim f16 As New Loans2 With {
                .TB1 = Trim(value)
            }
            f16.Show()
            f16.DanLOd()
        End If

    End Sub

    Sub ShowGridPreview(ByVal grid As GridControl)
        ' Check whether the GridControl can be previewed.
        If Not grid.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
            Return
        End If

        ' Opens the Preview window.
        grid.ShowPrintPreview()
    End Sub

    Sub PrintGrid(ByVal grid As GridControl)
        ' Check whether the GridControl can be printed.
        If Not grid.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
            Return
        End If

        ' Print.
        grid.Print()
    End Sub

    Private Sub PrintDocument_Click(sender As Object, e As EventArgs) Handles PrintDocument.Click
        ShowGridPreview(GridControl1)
    End Sub

    Private Sub PrintPInternalAuditor_Click(sender As Object, e As EventArgs) Handles PrintPInternalAuditor.Click
        PrintGrid(GridControl1)
    End Sub

End Class