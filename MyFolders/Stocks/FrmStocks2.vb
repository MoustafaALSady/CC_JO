Option Explicit Off

Imports System.Data.SqlClient


Public Class FrmStocks2
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
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Public TB4 As String
<<<<<<< HEAD
    Private Sub FrmStocks2_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
=======
    Private Sub FrmStocks2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If CheckLogReview.Checked = True Then
                Me.KeyPreview = False
            Else
                Me.KeyPreview = True
                Select Case e.KeyCode
                    Case Keys.F3
                        EDITBUTTON_Click(sender, e)
                    Case Keys.F4
                        BUTTONCANCEL_Click(sender, e)
                    Case Keys.F6
                        DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        Me.TabPage4.Show()
                        InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        Me.TabPage4.Show()
                        ButtonXP3_Click(sender, e)
                    Case Keys.B And (e.Alt And Not e.Control And Not e.Shift)
                        BALANCEBUTTON_Click(sender, e)
                    Case Keys.PageDown
                        PREVIOUSBUTTON_Click(sender, e)
                    Case Keys.PageUp
                        NEXTBUTTON_Click(sender, e)
                    Case Keys.Escape
                        Me.Close()
                End Select
            End If
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub FrmStocks2_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
=======
    Private Sub FrmStocks2_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage2.Show()
        Me.TabPage4.Show()
    End Sub

    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = False
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.TEXTID.Enabled = False
            Me.ComboStore.Enabled = False
            Me.TEXTPermissionNumber.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboPermissionType.Enabled = False
            Me.TEXTInvoiceNumber.Enabled = False
            Me.TextMovementSymbol.Enabled = False
            Me.ComboITEMNAME.Enabled = False
            Me.TextItemCode.Enabled = False
            Me.TEXTGROUPNAME.Enabled = False
            Me.TEXTMeasruingUnit.Enabled = False
            Me.ProductionDate.Enabled = False
            Me.ExpiryDate.Enabled = False
            Me.TEXTMPORTQUANTITY.Enabled = False
            Me.TEXTEXPORTQUNATITY.Enabled = False
            Me.TEXTCurrentBalance.Enabled = False
            Me.TEXTOrderLimit.Enabled = False
            Me.TEXTUnitPrice.Enabled = False
            Me.TEXTPurchasingPrice.Enabled = False
            Me.TextTotalPurchasePrice.Enabled = False
            Me.TEXTDiscount.Enabled = False
            Me.TexTSellingPrice.Enabled = False
            Me.TextSecondSellingPrice.Enabled = False
            Me.TextDiscountPercentageWhenSelling.Enabled = False
            Me.TextLowestDiscountRateWhenSelling.Enabled = False
            Me.TextHighestDiscountRateWhenSelling.Enabled = False
            Me.TextSalesTaxRate.Enabled = False
            Me.CheckPricesMentionedIncludeSalesTax.Enabled = False
            Me.CheckItemIsSubjectToSalesTax.Enabled = False

        Else
            Me.SHOWBUTTON()
            Me.ComboStore.Enabled = True
            Me.TEXTPermissionNumber.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.ComboPermissionType.Enabled = True
            Me.TEXTInvoiceNumber.Enabled = True
            Me.ComboITEMNAME.Enabled = True
            Me.TEXTGROUPNAME.Enabled = True
            Me.TEXTMeasruingUnit.Enabled = True
            Me.TEXTMPORTQUANTITY.Enabled = True
            Me.TEXTEXPORTQUNATITY.Enabled = True
            Me.TEXTOrderLimit.Enabled = True
            Me.TEXTUnitPrice.Enabled = True
            Me.TEXTPurchasingPrice.Enabled = True
            Me.TEXTDiscount.Enabled = True
            Me.TexTSellingPrice.Enabled = True
            Me.TextDiscountPercentageWhenSelling.Enabled = True
            Me.TextLowestDiscountRateWhenSelling.Enabled = True
            Me.TextHighestDiscountRateWhenSelling.Enabled = True
            Me.TextSalesTaxRate.Enabled = True
            Me.CheckPricesMentionedIncludeSalesTax.Enabled = True
            Me.CheckItemIsSubjectToSalesTax.Enabled = True
        End If
        If Me.TextST.Text.ToString <> "ST" Then
            Me.TEXTID.Enabled = False
            Me.ComboStore.Enabled = False
            Me.TEXTPermissionNumber.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboPermissionType.Enabled = False
            Me.TEXTInvoiceNumber.Enabled = False
            Me.TextMovementSymbol.Enabled = False
            Me.ComboITEMNAME.Enabled = False
            Me.TextItemCode.Enabled = False
            Me.TEXTGROUPNAME.Enabled = False
            Me.TEXTMeasruingUnit.Enabled = False
            Me.ProductionDate.Enabled = False
            Me.ExpiryDate.Enabled = False
            Me.TEXTMPORTQUANTITY.Enabled = False
            Me.TEXTEXPORTQUNATITY.Enabled = False
            Me.TEXTCurrentBalance.Enabled = False
            Me.TEXTOrderLimit.Enabled = False
            Me.TEXTUnitPrice.Enabled = False
            Me.TEXTPurchasingPrice.Enabled = False
            Me.TextTotalPurchasePrice.Enabled = False
            Me.TEXTDiscount.Enabled = False
            Me.TexTSellingPrice.Enabled = False
            Me.TextSecondSellingPrice.Enabled = False
            Me.TextDiscountPercentageWhenSelling.Enabled = False
            Me.TextLowestDiscountRateWhenSelling.Enabled = False
            Me.TextHighestDiscountRateWhenSelling.Enabled = False
            Me.TextSalesTaxRate.Enabled = False
            Me.CheckPricesMentionedIncludeSalesTax.Enabled = False
            Me.CheckItemIsSubjectToSalesTax.Enabled = False
        Else
            Me.ComboStore.Enabled = True
            Me.TEXTPermissionNumber.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.ComboPermissionType.Enabled = True
            Me.TEXTInvoiceNumber.Enabled = True
            Me.ComboITEMNAME.Enabled = True
            Me.TEXTGROUPNAME.Enabled = True
            Me.TEXTMeasruingUnit.Enabled = True
            Me.TEXTMPORTQUANTITY.Enabled = True
            Me.TEXTEXPORTQUNATITY.Enabled = True
            Me.TEXTOrderLimit.Enabled = True
            Me.TEXTUnitPrice.Enabled = True
            Me.TEXTPurchasingPrice.Enabled = True
            Me.TEXTDiscount.Enabled = True
            Me.TexTSellingPrice.Enabled = True
            Me.TextDiscountPercentageWhenSelling.Enabled = True
            Me.TextLowestDiscountRateWhenSelling.Enabled = True
            Me.TextHighestDiscountRateWhenSelling.Enabled = True
            Me.TextSalesTaxRate.Enabled = True
            Me.CheckPricesMentionedIncludeSalesTax.Enabled = True
            Me.CheckItemIsSubjectToSalesTax.Enabled = True
        End If
    End Sub

<<<<<<< HEAD
    Private Sub FrmStocks2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmStocks2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TabPage1.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.EDITBUTTON.Enabled = False
        Me.BUTTONCANCEL.Enabled = False
        Me.DELETEBUTTON.Enabled = False
        Me.BALANCEBUTTON.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
    End Sub

<<<<<<< HEAD
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles load1.Click
        On Error Resume Next
        Me.ConnectDataBase = New ComponentModel.BackgroundWorker With {
=======
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load1.Click
        On Error Resume Next
        Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()
        Me.load1.Enabled = False
    End Sub
    Public Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.myds.Tables("STOCKS ").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
        Me.TextST.Text = LSet(Me.TextMovementSymbol.Text, 2)
        'ChkPD_CheckedChanged(sender, e)
        Call MangUsers()
    End Sub
<<<<<<< HEAD
    Private Sub ComboITEMNAME_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub ComboITEMNAME_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        AutoComplete(Me.ComboITEMNAME, e, )
    End Sub

    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:

<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Me.myds.EnforceConstraints = False
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If

<<<<<<< HEAD
            Dim strSQL As New SqlCommand("", Consum)
=======
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With strSQL
                .CommandText = "SELECT STK1, WarehouseNumber, WarehouseName, STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, IT_DATEP, IT_DATEEX, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM STOCKS  WHERE  CUser='" & ModuleGeneral.CUser & "'and STK25 ='" & Strings.Trim(Me.TB1) & "'or STK7 ='" & Strings.Trim(Me.TB2) & "'or STK16 ='" & Strings.Trim(Me.TB3) & "'or STK3 ='" & Strings.Trim(Me.TB4) & "'ORDER BY STK25"
                '                                                                                                                                                                                                                                                                                        WHERE  CUser='" & Module1.CUser & "'and LO    ='" & Strings.Trim(Me.t2   & "'OR DOC2 ='" & Trim(Me.t2.Text)     & "'OR DOC4 ='" & Trim(Me.t1.Text)     & "'OR DOC5 ='" & Trim(Me.t3.Text)     & "'ORDER BY DOC1"

                Consum.Open()
<<<<<<< HEAD
                SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                Me.myds = New DataSet
                SqlDataAdapter1.Fill(Me.myds, "STOCKS")
                Me.myds.RejectChanges()
            End With
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "ErrorConnectDataBase.DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then
                Me.Label12.Visible = True
                Me.Label12.ForeColor = Color.Yellow
                Me.Label12.Text = "فضلا انتظر قليلا .. يتم تحميل سجلات الحقل"
            Else
                Me.Close()
            End If
        End If
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            If Me.myds.Tables("STOCKS").Rows.Count > 0 Then
                Me.BS.DataSource = Me.myds.Tables("STOCKS")
                Me.RowCount = Me.BS.Count

                FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)
                FILLCOMBOBOX3("STOCKS", "STK7", "CUser", CUser, "WarehouseNumber", ComboStore.Text, Me.ComboITEMNAME)

                With Me
                    .TEXTID.DataBindings.Add("text", Me.BS, "STK1", True, 1, "")
                    .ComboStore.DataBindings.Add("text", Me.BS, "WarehouseNumber", True, 1, "")
                    .TextWarehouseName.DataBindings.Add("text", Me.BS, "WarehouseName", True, 1, "")
                    .TEXTPermissionNumber.DataBindings.Add("text", Me.BS, "STK3", True, 1, "")
                    .DateMovementHistory.DataBindings.Add("text", BS, "STK4", True, 1, "")
                    .ComboPermissionType.DataBindings.Add("text", Me.BS, "STK5", True, 1, "")
                    .TEXTInvoiceNumber.DataBindings.Add("text", Me.BS, "STK6", True, 1, "")
                    .ComboITEMNAME.DataBindings.Add("text", Me.BS, "STK7", True, 1, "")
                    .TextItemCode.DataBindings.Add("text", Me.BS, "STK25", True, 1, "")
                    .TEXTGROUPNAME.DataBindings.Add("text", Me.BS, "STK8", True, 1, "")
                    .TEXTMeasruingUnit.DataBindings.Add("text", Me.BS, "STK9", True, 1, "")
                    .TEXTPreviousBalance.DataBindings.Add("text", Me.BS, "STK10", True, 1, "")
                    .TEXTMPORTQUANTITY.DataBindings.Add("text", Me.BS, "STK11", True, 1, "")
                    .TEXTEXPORTQUNATITY.DataBindings.Add("text", Me.BS, "STK12", True, 1, "")
                    .TEXTCurrentBalance.DataBindings.Add("text", Me.BS, "STK13", True, 1, "")
                    .TEXTOrderLimit.DataBindings.Add("text", Me.BS, "STK14", True, 1, "")
                    .TEXTPurchasingPrice.DataBindings.Add("text", Me.BS, "STK15", True, 1, "") ' سعر الشراء
                    .TextMovementSymbol.DataBindings.Add("text", Me.BS, "STK16", True, 1, "")
                    '.TEXTDiscount.DataBindings.Add("text", Me.BS, "STK17", True, 1, "") '  نسبة خصم الشراء
                    .TextTotalPurchasePrice.DataBindings.Add("text", Me.BS, "STK18", True, 1, "") '  اجمالي سعر الشراء

                    .TexTSellingPrice.DataBindings.Add("text", Me.BS, "STK19", True, 1, "") ' سعر البيع
                    .TextSecondSellingPrice.DataBindings.Add("text", Me.BS, "STK20", True, 1, "") '  اجمالي سعر البيع
                    ' ============ نسب خصم البيع
                    '.TextDiscountPercentageWhenSelling.DataBindings.Add("text", Me.BS, "STK21", True, 1, "")

                    '.TextLowestDiscountRateWhenSelling.DataBindings.Add("text", Me.BS, "STK22", True, 1, "")

                    '.TextHighestDiscountRateWhenSelling.DataBindings.Add("text", Me.BS, "STK23", True, 1, "")

                    .TEXTDiscount.Text = Me.myds.Tables("STOCKS").Rows(Me.BS.Position)("STK17").ToString
                    .TextDiscountPercentageWhenSelling.Text = Me.myds.Tables("STOCKS").Rows(Me.BS.Position)("STK21").ToString
                    .TextLowestDiscountRateWhenSelling.Text = Me.myds.Tables("STOCKS").Rows(Me.BS.Position)("STK22").ToString
                    .TextHighestDiscountRateWhenSelling.Text = Me.myds.Tables("STOCKS").Rows(Me.BS.Position)("STK23").ToString

                    .CheckPricesMentionedIncludeSalesTax.DataBindings.Add("Checked", Me.BS, "STK24", True, 1, "")
                    .CheckItemIsSubjectToSalesTax.DataBindings.Add("Checked", Me.BS, "STK26", True, 1, "")
                    .ProductionDate.DataBindings.Add("text", Me.BS, "IT_DATEP", True, 1, "")
                    .ExpiryDate.DataBindings.Add("text", Me.BS, "IT_DATEEX", True, 1, "")

                    .TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
                    .TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
                    .TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "couser", True, 1, "")
                    .TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
                    .TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
                    .TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
                    .TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")
                End With
                Auditor("STOCKS", "USERNAME", "STK1", Me.TEXTID.EditValue, "")
                Logentry = Uses
                ChkPD_CheckedChanged(sender, e)
                Consum.Close()
            Else
                MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
                Exit Sub
            End If
            Me.RecordCount()
            Me.TextST.Text = LSet(Me.TextMovementSymbol.Text, 2)
            Call MangUsers()
            Me.BUTTONCANCEL.Enabled = True
            Me.Label12.Visible = False
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorConnectDataBase.RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub UPDATERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand("Update STOCKS SET  WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName, STK3 = @STK3, STK4 = @STK4, STK5 = @STK5, STK6 = @STK6, STK7 = @STK7, STK8 = @STK8, STK9 = @STK9, STK10 = @STK10, STK11 = @STK11, STK12 = @STK12, STK13 = @STK13, STK14 = @STK14, STK15 = @STK15, STK16 = @STK16, STK17 = @STK17, STK18 = @STK18, STK19 = @STK19, STK20 = @STK20, STK21 = @STK21, STK22 = @STK22, STK23 = @STK23, STK24 = @STK24, STK25 = @STK25, STK26 = @STK26, IT_DATEP = @IT_DATEP, IT_DATEEX = @IT_DATEEX, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE STK1 = @STK1  ", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand("Update STOCKS SET  WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName, STK3 = @STK3, STK4 = @STK4, STK5 = @STK5, STK6 = @STK6, STK7 = @STK7, STK8 = @STK8, STK9 = @STK9, STK10 = @STK10, STK11 = @STK11, STK12 = @STK12, STK13 = @STK13, STK14 = @STK14, STK15 = @STK15, STK16 = @STK16, STK17 = @STK17, STK18 = @STK18, STK19 = @STK19, STK20 = @STK20, STK21 = @STK21, STK22 = @STK22, STK23 = @STK23, STK24 = @STK24, STK25 = @STK25, STK26 = @STK26, IT_DATEP = @IT_DATEP, IT_DATEEX = @IT_DATEEX, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE STK1 = @STK1  ", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@STK1", SqlDbType.BigInt).Value = Me.TEXTID.EditValue
                .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Me.ComboStore.Text
                .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text
                .Parameters.Add("@STK3", SqlDbType.NVarChar).Value = Me.TEXTPermissionNumber.Text
                .Parameters.Add("@STK4", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@STK5", SqlDbType.NVarChar).Value = Me.ComboPermissionType.Text
                .Parameters.Add("@STK6", SqlDbType.NVarChar).Value = Me.TEXTInvoiceNumber.Text
                .Parameters.Add("@STK7", SqlDbType.NVarChar).Value = Me.ComboITEMNAME.Text
                .Parameters.Add("@STK8", SqlDbType.NVarChar).Value = Me.TEXTGROUPNAME.Text
                .Parameters.Add("@STK9", SqlDbType.NVarChar).Value = Me.TEXTMeasruingUnit.Text
                .Parameters.Add("@STK10", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text
                .Parameters.Add("@STK11", SqlDbType.NVarChar).Value = Me.TEXTMPORTQUANTITY.EditValue
                .Parameters.Add("@STK12", SqlDbType.NVarChar).Value = Me.TEXTEXPORTQUNATITY.EditValue
                .Parameters.Add("@STK13", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text
                .Parameters.Add("@STK14", SqlDbType.NVarChar).Value = Me.TEXTOrderLimit.EditValue
                .Parameters.Add("@STK15", SqlDbType.NVarChar).Value = Me.TEXTPurchasingPrice.EditValue
                .Parameters.Add("@STK16", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.Text
                .Parameters.Add("@STK17", SqlDbType.NVarChar).Value = Me.TEXTDiscount.EditValue
                .Parameters.Add("@STK18", SqlDbType.NVarChar).Value = Me.TextTotalPurchasePrice.EditValue
                .Parameters.Add("@STK19", SqlDbType.NVarChar).Value = Me.TexTSellingPrice.EditValue
                .Parameters.Add("@STK20", SqlDbType.NVarChar).Value = Me.TextSecondSellingPrice.Text
                .Parameters.Add("@STK21", SqlDbType.NVarChar).Value = Me.TextDiscountPercentageWhenSelling.EditValue
                .Parameters.Add("@STK22", SqlDbType.NVarChar).Value = Me.TextLowestDiscountRateWhenSelling.EditValue
                .Parameters.Add("@STK23", SqlDbType.NVarChar).Value = Me.TextHighestDiscountRateWhenSelling.EditValue
                .Parameters.Add("@STK24", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckPricesMentionedIncludeSalesTax.Checked)
                .Parameters.Add("@STK25", SqlDbType.NVarChar).Value = Me.TextItemCode.Text
                .Parameters.Add("@STK26", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckItemIsSubjectToSalesTax.Checked)
                .Parameters.Add("@IT_DATEP", SqlDbType.NVarChar).Value = Me.ProductionDate.Text
                .Parameters.Add("@IT_DATEEX", SqlDbType.NVarChar).Value = Me.ExpiryDate.Text
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                If InternalAuditor = True Then
                    .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Logentry
                    .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = USERNAME
                    .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                    .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                Else
                    .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                    .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = DBNull.Value
                    .Parameters.Add("@da1", SqlDbType.NVarChar).Value = DBNull.Value
                    .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = DBNull.Value
                End If
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            Me.myds = New DataSet
            SqlDataAdapter1.Fill(Me.myds, "STOCKS")
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
            Me.BS.DataSource = myds.Tables("STOCKS")
            Me.PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            If Me.DelRow = False Then
                If Me.BS.Count < Me.RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 48 + 524288, "تحديث السجلات")
                ElseIf Me.BS.Count > Me.RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 48 + 524288, "تحديث السجلات")
                End If
            Else
                Me.DelRow = False
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

            'SqlDataAdapter1.Update(myds, "STOCKS")
            'myds = New DataSet
            'SqlDataAdapter1.Fill(myds, "STOCKS")
            'myds.RejectChanges()

            Return
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
                Me.DelRow = True
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
            If Me.DelRow = True Then
<<<<<<< HEAD
                Me.RefreshTab = New ComponentModel.BackgroundWorker With {
=======
                Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    .WorkerReportsProgress = True,
                    .WorkerSupportsCancellation = True
                }
                Me.RefreshTab.RunWorkerAsync()
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = Me.myds.Tables("STOCKS")
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
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
                    Insert_Actions(Me.TEXTID.EditValue.Trim, "حفظ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click2 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue.Trim, "تعديل", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click3 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue.Trim, "الارصدة", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            End If
            Click1 = False
            Click2 = False
            Click3 = False
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
<<<<<<< HEAD
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
=======
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.RecordCount()
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.BALANCEBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
    End Sub
    Private Sub SEARCHDATAITEMS()
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim strsql1 As New SqlCommand("SELECT SKITM3,SKITM4,SKITM6,SKITM8,SKITM9, SKITM11, SKITM10 , IT_DATEP, IT_DATEEX, SKITM14,SKITM15,SKITM16 ,SKITM17,SKITM12,SKITM20,SKITM21,ChkPD  FROM STOCKSITEMS WHERE  CUser='" & CUser & "'" & " AND  SKITM5='" & Me.ComboITEMNAME.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql1)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql1 As New SqlClient.SqlCommand("SELECT SKITM3,SKITM4,SKITM6,SKITM8,SKITM9, SKITM11, SKITM10 , IT_DATEP, IT_DATEEX, SKITM14,SKITM15,SKITM16 ,SKITM17,SKITM12,SKITM20,SKITM21,ChkPD  FROM STOCKSITEMS WHERE  CUser='" & CUser & "'" & " AND  SKITM5='" & Me.ComboITEMNAME.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        ds.Clear()
        Adp1.Fill(ds, "STOCKSITEMS")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXTGROUPNAME.Text = ds.Tables(0).Rows(0).Item(0)
            Me.TextItemCode.Text = ds.Tables(0).Rows(0).Item(1)
            Me.TEXTMeasruingUnit.Text = ds.Tables(0).Rows(0).Item(2)
            Me.TEXTPurchasingPrice.EditValue = ds.Tables(0).Rows(0).Item(3)
            Me.TEXTUnitPrice.EditValue = ds.Tables(0).Rows(0).Item(3)
            Me.TEXTDiscount.EditValue = ds.Tables(0).Rows(0).Item(4)
            Me.TEXTOrderLimit.EditValue = ds.Tables(0).Rows(0).Item(5)
            Me.TextTotalPurchasePrice.EditValue = ds.Tables(0).Rows(0).Item(6)
            Me.ProductionDate.Text = ds.Tables(0).Rows(0).Item(7)
            Me.ExpiryDate.Text = ds.Tables(0).Rows(0).Item(8)

            Me.TexTSellingPrice.EditValue = ds.Tables(0).Rows(0).Item(9)
            Me.TextDiscountPercentageWhenSelling.EditValue = ds.Tables(0).Rows(0).Item(10)
            Me.TextLowestDiscountRateWhenSelling.EditValue = ds.Tables(0).Rows(0).Item(11)
            Me.TextHighestDiscountRateWhenSelling.EditValue = ds.Tables(0).Rows(0).Item(12)
            Me.TextSalesTaxRate.EditValue = ds.Tables(0).Rows(0).Item(13)
            Me.CheckPricesMentionedIncludeSalesTax.Checked = ds.Tables(0).Rows(0).Item(14)
            Me.CheckItemIsSubjectToSalesTax.Checked = ds.Tables(0).Rows(0).Item(15)
            Me.ChkPD.Checked = ds.Tables(0).Rows(0).Item("ChkPD")
        Else
            Me.TEXTGROUPNAME.Text = "0"
            Me.TextItemCode.Text = "0"
            Me.TEXTMeasruingUnit.Text = "0"
            Me.TEXTOrderLimit.EditValue = "0"
            Me.TEXTUnitPrice.EditValue = "0"
            Me.ProductionDate.Text = "0"
            Me.ExpiryDate.Text = "0"
            Me.TexTSellingPrice.EditValue = "0"
            Me.TEXTPurchasingPrice.EditValue = "0"
            Me.TextTotalPurchasePrice.EditValue = "0"
            Me.TEXTDiscount.EditValue = "0"
            Me.TextDiscountPercentageWhenSelling.EditValue = "0"
            Me.TextLowestDiscountRateWhenSelling.EditValue = "0"
            Me.TextHighestDiscountRateWhenSelling.EditValue = "0"
            Me.TextSalesTaxRate.EditValue = "0"
            Me.CheckPricesMentionedIncludeSalesTax.Checked = False
            Me.CheckItemIsSubjectToSalesTax.Checked = False
            Me.ChkPD.Checked = False
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub
    Private Sub UPDATEBALANCEITEMS()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim sql As New SqlCommand("UPDATE STOCKSITEMS SET SKITM7 = @QUANTITY WHERE STOCKSITEMS.SKITM4='" & Me.TextItemCode.Text.Trim & "'" & " AND STOCKSITEMS.CUser='" & CUser & "'", Consum)
        Dim CMD As New SqlCommand With {
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim sql As New SqlClient.SqlCommand("UPDATE STOCKSITEMS SET SKITM7 = @QUANTITY WHERE STOCKSITEMS.SKITM4='" & Me.TextItemCode.Text.Trim & "'" & " AND STOCKSITEMS.CUser='" & CUser & "'", Consum)
        Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@QUANTITY", System.Data.SqlDbType.Float).Value = Val(Me.TEXTCurrentBalance.Text)
            '.Parameters.Add("@Price", System.Data.SqlDbType.Float).Value = Val(Me.TEXT11.Text), SKITM8 = @Price
            .CommandText = sql.CommandText
        End With
        CMD.ExecuteNonQuery()
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub ComboPermissionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboPermissionType.SelectedIndexChanged
=======
    Private Sub ComboPermissionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPermissionType.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        On Error Resume Next
        Select Case Me.ComboPermissionType.Text
            Case "استلام"
                Me.TEXTMPORTQUANTITY.Enabled = True
                Me.TEXTEXPORTQUNATITY.Enabled = False
                Me.TEXTMPORTQUANTITY.Focus()
            Case "صرف"
                Me.TEXTMPORTQUANTITY.Enabled = False
                Me.TEXTEXPORTQUNATITY.Enabled = True
                Me.TEXTEXPORTQUNATITY.Focus()
            Case "تسوية بالعجز"
                Me.TEXTMPORTQUANTITY.Enabled = False
                Me.TEXTEXPORTQUNATITY.Enabled = True
                Me.TEXTEXPORTQUNATITY.Focus()
            Case "تسوية بالزيادة"
                Me.TEXTMPORTQUANTITY.Enabled = True
                Me.TEXTEXPORTQUNATITY.Enabled = False
                Me.TEXTMPORTQUANTITY.Focus()
            Case "مردودات مشتريات"
                Me.TEXTMPORTQUANTITY.Enabled = False
                Me.TEXTEXPORTQUNATITY.Enabled = True
                Me.TEXTEXPORTQUNATITY.Focus()
            Case "مردودات مبيعات"
                Me.TEXTMPORTQUANTITY.Enabled = True
                Me.TEXTEXPORTQUNATITY.Enabled = False
                Me.TEXTMPORTQUANTITY.Focus()
            Case "اصناف غير سليمة"
                Me.TEXTMPORTQUANTITY.Enabled = False
                Me.TEXTEXPORTQUNATITY.Enabled = True
                Me.TEXTEXPORTQUNATITY.Focus()
            Case "استبدال صنف (استلام)"
                Me.TEXTMPORTQUANTITY.Enabled = True
                Me.TEXTEXPORTQUNATITY.Enabled = False
                Me.TEXTMPORTQUANTITY.Focus()
            Case "استبدال صنف (صرف)"
                Me.TEXTMPORTQUANTITY.Enabled = False
                Me.TEXTEXPORTQUNATITY.Enabled = True
                Me.TEXTEXPORTQUNATITY.Focus()
        End Select
    End Sub
<<<<<<< HEAD
    'Private Sub SEARCHBALANCEITEMS()
    '    On Error Resume Next
    '    Dim Consum As New SqlConnection(constring)
    '    If Consum.State = ConnectionState.Open Then
    '        Consum.Close()
    '    End If
    '    Consum.Open()
    '    Dim SUM1 As Double
    '    Dim strsq1 As New SqlCommand("SELECT Sum(STK11 - STK12) FROM STOCKS  WHERE STOCKS.CUser='" & CUser & "' AND (STOCKS.WarehouseNumber)='" & Me.ComboStore.Text & "' AND (STOCKS.STK25)='" & Me.TextItemCode.Text.Trim & "'AND STOCKS.STK1 <'" & Me.TEXTID.EditValue & "'", Consum)
    '    '                                                                              WHERE STOCKS.SKITM4 ='" & Me.TextItemCode.Text.Trim & "'AND STOCKS.CUser='" & CUser & "'"
    '    Dim ds1 As New DataSet
    '    Dim Adp1 As New SqlDataAdapter(strsq1)
    '    ds1.Clear()
    '    Adp1.Fill(ds1, "STOCKS")
    '    If ds1.Tables(0).Rows.Count > 0 Then
    '        SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
    '        If Me.TEXTPreviousBalance.Text = "" Then Me.TEXTPreviousBalance.Text = "0"
    '    Else
    '        SUM1 = "0"
    '    End If
    '    Adp1.Dispose()
    '    Me.TEXTPreviousBalance.Text = Format(Val(SUM1), "0.000")
    '    Consum.Close()
    'End Sub

    Private Sub SEARCHBALANCEITEMS()
        Try
            Using Consum As New SqlConnection(constring)
                Consum.Open()
                Dim SUM1 As Double
                Dim query As String = "SELECT Sum(STK11 - STK12) FROM STOCKS WHERE STOCKS.CUser = @CUser AND STOCKS.WarehouseNumber = @WarehouseNumber AND STOCKS.STK25 = @ItemCode AND STOCKS.STK1 < @StockID"
                Using strsq1 As New SqlCommand(query, Consum)
                    strsq1.Parameters.AddWithValue("@CUser", CUser)
                    strsq1.Parameters.AddWithValue("@WarehouseNumber", Me.ComboStore.Text)
                    strsq1.Parameters.AddWithValue("@ItemCode", Me.TextItemCode.Text.Trim)
                    strsq1.Parameters.AddWithValue("@StockID", Me.TEXTID.EditValue)
                    Using reader As SqlDataReader = strsq1.ExecuteReader()
                        If reader.Read() AndAlso Not IsDBNull(reader(0)) Then
                            SUM1 = Format(Val(reader(0)), "0.000")
                        Else
                            SUM1 = 0
                        End If
                    End Using
                End Using
                Me.TEXTPreviousBalance.Text = Format(Val(SUM1), "0.000")
            End Using
        Catch ex As Exception
            ' Handle exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub


=======
    Private Sub SEARCHBALANCEITEMS()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        Dim SUM1 As Double
        Dim strsq1 As New SqlClient.SqlCommand("SELECT Sum(STK11 - STK12) FROM STOCKS  WHERE STOCKS.CUser='" & CUser & "' AND (STOCKS.WarehouseNumber)='" & Me.ComboStore.Text.Trim & "' AND (STOCKS.STK25)='" & Me.TextItemCode.Text.Trim & "'AND STOCKS.STK1 <'" & Me.TEXTID.EditValue & "'", Consum)
        '                                                                              WHERE STOCKS.SKITM4 ='" & Me.TextItemCode.Text.Trim & "'AND STOCKS.CUser='" & CUser & "'"
        Dim ds1 As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Adp1.Fill(ds1, "STOCKS")
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
            If Me.TEXTPreviousBalance.Text = "" Then Me.TEXTPreviousBalance.Text = "0"
        Else
            SUM1 = "0"
        End If
        Adp1.Dispose()
        Me.TEXTPreviousBalance.Text = Format(Val(SUM1), "0.000")
        Consum.Close()
    End Sub
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub GETBANKNOWBALANCE()
        On Error Resume Next
        Dim n As Double
        Dim F As Double
        n = Me.BS.Position
        Me.BS.EndEdit()
        If Me.BS.Position = 0 Then
            Me.TEXTPreviousBalance.Text = 0
        ElseIf Me.BS.Position > 0 Then
            F = 0
            Me.BS.Position = Me.BS.Position - 1
            F = Val(Me.TEXTCurrentBalance.Text)
            Me.BS.Position = Me.BS.Position + 1
            Me.TEXTPreviousBalance.Text = F
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TEXT6_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TEXTPreviousBalance.TextChanged, TEXTMPORTQUANTITY.EditValueChanged, TEXTEXPORTQUNATITY.EditValueChanged, TEXTDiscount.EditValueChanged, TextDiscountPercentageWhenSelling.EditValueChanged
=======
    Private Sub TEXT6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEXTPreviousBalance.TextChanged, TEXTMPORTQUANTITY.EditValueChanged, TEXTEXPORTQUNATITY.EditValueChanged, TEXTDiscount.EditValueChanged, TextDiscountPercentageWhenSelling.EditValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTMPORTQUANTITY.EditValue) - Val(Me.TEXTEXPORTQUNATITY.EditValue), "0.000")
        Me.TextTotalPurchasePrice.EditValue = Format(Val(Me.TEXTCurrentBalance.Text) * Val(Me.TEXTPurchasingPrice.EditValue), "0.000")
        Me.TextSecondSellingPrice.Text = Format(Val(Me.TEXTCurrentBalance.Text) * Val(Me.TexTSellingPrice.EditValue), "0.000")

    End Sub
<<<<<<< HEAD
    Private Sub TEXT2_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles TEXTPermissionNumber.KeyDown, TEXTInvoiceNumber.KeyDown, TEXTGROUPNAME.KeyDown, TEXTMeasruingUnit.KeyDown, TEXTPreviousBalance.KeyDown, TEXTCurrentBalance.KeyDown, ComboPermissionType.KeyDown, DateMovementHistory.KeyDown
=======
    Private Sub TEXT2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTPermissionNumber.KeyDown, TEXTInvoiceNumber.KeyDown, TEXTGROUPNAME.KeyDown, TEXTMeasruingUnit.KeyDown, TEXTPreviousBalance.KeyDown, TEXTCurrentBalance.KeyDown, ComboPermissionType.KeyDown, DateMovementHistory.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub CLEARDATA()
        On Error Resume Next
        Dim txt As Control
        For Each txt In Me.Controls
            If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Then
                txt.Text = ""
            End If
        Next
    End Sub
<<<<<<< HEAD
    Private Sub StepBALANCE_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles stepBALANCE.Click
=======
    Private Sub StepBALANCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stepBALANCE.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Me.BackW3.IsBusy Then
            Me.BackW3.CancelAsync()
        End If

    End Sub
<<<<<<< HEAD
    Private Sub BALANCEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BALANCEBUTTON.Click
=======
    Private Sub BALANCEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BALANCEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة الارصدة من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim I As Integer
        'On Error Resume Next
        'Me.BS.Position = 0
        'For I = 0 To Me.BS.Count + 1
        '    Me.BS.Position = I
        '    Me.ProgressBar1.Visible = True
        '    Me.ProgressBar1.Minimum = 1
        '    Me.ProgressBar1.Maximum = Me.BS.Count - 1
        '    Me.ProgressBar1.Value = I
        '    Me.SEARCHBALANCEITEMS()
        '    UPDATERECORD()
        '    UPDATEBALANCEITEMS()
        '    Dim percent As Integer = CInt((CDbl(Me.ProgressBar1.Value - Me.ProgressBar1.Minimum) / CDbl(Me.ProgressBar1.Maximum - Me.ProgressBar1.Minimum)) * 100)
        '    Using gr As Graphics = Me.ProgressBar1.CreateGraphics()
        '        gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.ProgressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.ProgressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
        '    End Using
        '    If Consum.State = ConnectionState.Open Then Consum.Close()

        'Next
        'SaveBALANCE()
        'Me.TextTotalPurchasePrice.EditValue = Format(Val(Me.TEXTCurrentBalance.Text) * Val(Me.TEXTPurchasingPrice.EditValue) * (100 - Val(Me.TEXTDiscount.EditValue)) / 100, "0.000")
        'Me.TextSecondSellingPrice.Text = Format(Val(Me.TEXTCurrentBalance.Text) * Val(Me.TexTSellingPrice.EditValue) * (100 - Val(Me.TextDiscountPercentageWhenSelling.EditValue)) / 100, "0.000")
        'Me.BS.Position = 0
        'Me.ProgressBar1.Visible = False
        'Click3 = True
        'Me.SaveBALANCE()
        Me.ProgressBar1.Visible = True
        'Me.PictureBox2.Visible = True
        Me.Label15.Visible = True
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = CInt(Me.BS.Count)
        'Me.ProgressBar1.Value = 0
        If Not Me.BackW3.IsBusy Then

<<<<<<< HEAD
            Me.BackW3 = New ComponentModel.BackgroundWorker With {
=======
            Me.BackW3 = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.BackW3.RunWorkerAsync()
        End If
    End Sub
    Private Sub BackW3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackW3.DoWork
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة الارصدة من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            For I = 1 To CInt(Me.BS.Count)
                If Me.BackW3.CancellationPending Then
                    e.Cancel = True
                    Return
                End If
                Me.BS.Position = I
                Me.BackW3.ReportProgress(I)
            Next
            Me.SEARCHBALANCEITEMS()
            Me.UPDATERECORD()
            Me.UPDATEBALANCEITEMS()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorDoWorkBALANCE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub BackW3_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackW3.ProgressChanged
        On Error Resume Next
        Me.ProgressBar1.Value = e.ProgressPercentage
        Dim num2 As Integer = CInt(Math.Round(CDbl(CDbl(Me.ProgressBar1.Value - Me.ProgressBar1.Minimum) / CDbl(Me.ProgressBar1.Maximum - Me.ProgressBar1.Minimum) * 100)))
        Using graphics As Graphics = Me.ProgressBar1.CreateGraphics
            Dim point As New PointF(CSng(CDbl(Me.ProgressBar1.Width) / 2) - (graphics.MeasureString(num2.ToString & "%", SystemFonts.DefaultFont).Width / 2.0!), CSng(CDbl(Me.ProgressBar1.Height) / 2) - (graphics.MeasureString(num2.ToString & "%", SystemFonts.DefaultFont).Height / 2.0!))
            graphics.DrawString(num2.ToString & "%", SystemFonts.DefaultFont, Brushes.Black, point)
        End Using
    End Sub

    Private Sub BackW3_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackW3.RunWorkerCompleted
        Try
            If e.Cancelled Then
                Me.BackW3.CancelAsync()
                Me.ProgressBar1.Visible = False
                Me.PictureBox2.Visible = False
                Me.Label15.Text = 0
                Me.Label15.Visible = False
            ElseIf e.Error IsNot Nothing Then
                Me.Label15.Text = "Error: " & e.Error.Message
            Else
                Me.BackW3.CancelAsync()
                Me.ProgressBar1.Visible = False
                Me.PictureBox2.Visible = False
                Me.Label15.Text = 0
                Me.Label15.Visible = False
                Me.SaveBALANCE()
                Me.BS.Position = 0
                ModuleGeneral.Click3 = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorRunWorkerCompletedBALANCE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub SaveBALANCE()
        On Error Resume Next
        Me.PictureBox2.Visible = True
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
    End Sub
<<<<<<< HEAD
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FIRSTBUTTON.Click
=======
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PREVIOUSBUTTON.Click
=======
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Position - 1
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NEXTBUTTON.Click
=======
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Position + 1
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
=======
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
=======
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.CancelEdit()
        Me.RecordCount()
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
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Year(Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")) > FiscalYear_currentDateMustBeInFiscalYear() Then
            MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
            Exit Sub
        End If
        If Me.TextST.Text.ToString <> "ST" Then
            Dim resault As Integer
            resault = MessageBox.Show("لايمكن تعدبل  السجل الحالى لأنه مرحل" & vbCrLf & vbCrLf & "يجب الغاء الترحيل للسجل الحالى ", "سجل مرحل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If

        Static P As Integer
        P = Me.BS.Position
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")

        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.UPDATEBALANCEITEMS()
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
        Me.RecordCount()
        Click2 = True
    End Sub
<<<<<<< HEAD
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles InternalAuditorERBUTTON.Click
=======
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalAuditorERBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
        Me.CheckLogReview.Checked = True
        Me.TextDefinitionDirectorate.Text = USERNAME
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Static P As Integer
        P = Me.BS.Position
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
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
        Me.BS.Position = P
        MsgBox("تمت عملية المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Insert_Actions(Me.TEXTID.EditValue.Trim, "المراجع", Me.Text)
    End Sub
<<<<<<< HEAD
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
=======
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.TextST.Text.ToString <> "ST" Then
            Dim resault As Integer
            resault = MessageBox.Show("لايمكن حذف  السجل الحالى لأنه مرحل" & vbCrLf & vbCrLf & "يجب الغاء الترحيل للسجل الحالى ", "سجل مرحل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        MYDELETERECORD("STOCKS", "STK1", TEXTID, Me.BS, True)
        Insert_Actions(Me.TEXTID.EditValue.Trim, "حذف", Me.Text)
    End Sub
<<<<<<< HEAD
    Private Sub TEXT15_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ProductionDate.KeyPress
=======
    Private Sub TEXT15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ProductionDate.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Asc(e.KeyChar) = 13 Then
            If Not IsDate(ProductionDate.Text) Then
                MsgBox("تاريخ غير صالخ")
                Me.ProductionDate.Focus()
            Else
                Dim years As Double
                Dim SecondDate As Date
                SecondDate = CDate(Me.ProductionDate.Text)
                years = 1
                Me.ExpiryDate.Text = DateAdd(DateInterval.Year, years, SecondDate)
                Me.ExpiryDate.Focus()
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
=======
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
        Me.TextDefinitionDirectorate.Text = USERNAME
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.PictureBox2.Visible = True
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
        Me.BS.Position = P
        Me.RecordCount()
        MsgBox("تمت عملية إلغاء المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Insert_Actions(Me.TEXTID.EditValue.Trim, "إلغاء المراجعة", Me.Text)
        Consum.Close()
    End Sub

    Private Sub ComboITEMNAME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboITEMNAME.SelectedIndexChanged
        On Error Resume Next
        Me.SEARCHDATAITEMS()
        Me.SEARCHBALANCEITEMS()
        ChkPD_CheckedChanged(sender, e)

    End Sub
    Private Sub ComboStore_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboStore.SelectedIndexChanged
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)

        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT WarehouseName  FROM Warehouses WHERE WarehouseNumber ='" & Me.ComboStore.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)

        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT WarehouseName  FROM Warehouses WHERE WarehouseNumber ='" & Me.ComboStore.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextWarehouseName.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextWarehouseName.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()

        'Me.SEARCHDATAITEMS()
        'Me.SEARCHBALANCEITEMS()
        Me.ComboPermissionType_SelectedIndexChanged(sender, e)
        Me.ComboITEMNAME.Text = Nothing
        FILLCOMBOBOX3("STOCKS", "STK7", "CUser", CUser, "WarehouseNumber", ComboStore.Text, Me.ComboITEMNAME)
    End Sub

    Private Sub ChkPD_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPD.CheckedChanged
        If ChkPD.Checked = True Then
            ProductionDate.Enabled = True
            ExpiryDate.Enabled = True
        Else
            ProductionDate.Enabled = False
            ExpiryDate.Enabled = False
        End If
    End Sub


End Class