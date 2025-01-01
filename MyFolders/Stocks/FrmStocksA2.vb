Option Explicit Off

Imports System.Data.SqlClient
Public Class FrmStocksA2
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
    Private Sub FrmStocks2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
    Private Sub FrmStocks2_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Call MangUsers()
        'Me.ComboITEMNAME.AutoCompleteSource = AutoCompleteSource.CustomSource
        'Me.ComboITEMNAME.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        'Me.ComboITEMNAME.AutoCompleteSource = AutoCompleteSource.ListItems
        FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)
        FILLCOMBOBOX3("STOCKSITEMS", "SKITM5", "CUser", CUser, "WarehouseNumber", ComboStore.Text, Me.ComboITEMNAME)

    End Sub
    Private Sub FrmStocksA2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.SHOWBUTTON()
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
    End Sub


    Private Sub SaveStocks()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO STOCKS( STK1, WarehouseNumber, WarehouseName, STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, USERNAME, CUser, COUser, da, ne, IT_DATEP, IT_DATEEX) VALUES     ( @STK1, @WarehouseNumber, @WarehouseName, @STK3, @STK4, @STK5, @STK6, @STK7, @STK8, @STK9, @STK10, @STK11, @STK12, @STK13, @STK14, @STK15, @STK16, @STK17, @STK18, @STK19, @STK20, @STK21, @STK22, @STK23, @STK25, @STK24, @STK26, @USERNAME, @CUser, @COUser, @da, @ne, @IT_DATEP, @IT_DATEEX)"
            Dim CMD As New SqlClient.SqlCommand(SQL, Consum)
            With CMD.Parameters
                .AddWithValue("@STK1", Me.TEXTID.EditValue)
                .AddWithValue("@WarehouseNumber", Me.ComboStore.Text)
                .AddWithValue("@WarehouseName", Me.TextWarehouseName.Text)
                .AddWithValue("@STK3", Me.TEXTPermissionNumber.Text)
                .AddWithValue("@STK4", Me.DateMovementHistory.Value.ToString("yyyy-MM-dd"))
                .AddWithValue("@STK5", Me.ComboPermissionType.Text)
                .AddWithValue("@STK6", Me.TEXTInvoiceNumber.Text)
                .AddWithValue("@STK7", Me.ComboITEMNAME.Text)
                .AddWithValue("@STK8", Me.TEXTGROUPNAME.Text)
                .AddWithValue("@STK9", Me.TEXTMeasruingUnit.Text)
                .AddWithValue("@STK10", Me.TEXTPreviousBalance.Text)
                .AddWithValue("@STK11", Me.TEXTMPORTQUANTITY.EditValue)
                .AddWithValue("@STK12", Me.TEXTEXPORTQUNATITY.EditValue)
                .AddWithValue("@STK13", Me.TEXTCurrentBalance.Text)
                .AddWithValue("@STK14", Me.TEXTOrderLimit.EditValue)
                .AddWithValue("@STK15", Me.TEXTPurchasingPrice.EditValue)
                .AddWithValue("@STK16", Me.TextMovementSymbol.Text)
                .AddWithValue("@STK17", Me.TEXTDiscount.EditValue)
                .AddWithValue("@STK18", Me.TextTotalPurchasePrice.EditValue)
                .AddWithValue("@STK19", Me.TexTSellingPrice.EditValue)
                .AddWithValue("@STK20", Me.TextSecondSellingPrice.EditValue)
                .AddWithValue("@STK21", Me.TextDiscountPercentageWhenSelling.EditValue)
                .AddWithValue("@STK22", Me.TextLowestDiscountRateWhenSelling.EditValue)
                .AddWithValue("@STK23", Me.TextHighestDiscountRateWhenSelling.EditValue)
                .AddWithValue("@STK24", Convert.ToInt32(Me.CheckPricesMentionedIncludeSalesTax.Checked).ToString)
                .AddWithValue("@STK25", Me.TextItemCode.Text)
                .AddWithValue("@STK26", Convert.ToInt32(Me.CheckItemIsSubjectToSalesTax.Checked).ToString)
                .AddWithValue("@USERNAME", USERNAME)
                .AddWithValue("@CUser", CUser)
                .AddWithValue("@COUser", COUser)
                .AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                .AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                .AddWithValue("@IT_DATEP", ExpiryDate.Text)
                .AddWithValue("@IT_DATEEX", ProductionDate.Text)
            End With
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSaveStocks", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            myds = New DataSet
            SqlDataAdapter1.Fill(myds, "STOCKS")
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
            If DelRow = False Then
                If BS.Count < RowCount Then
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
                PictureBox2False()
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
                Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
                    .WorkerReportsProgress = True,
                    .WorkerSupportsCancellation = True
                }
                Me.RefreshTab.RunWorkerAsync()
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = myds.Tables("STOCKS")
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
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
            ElseIf Click2 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "تعديل", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click3 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "الارصدة", Me.Text)
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
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
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
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub
    Private Sub SEARCHDATAITEMS()
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql1 As New SqlClient.SqlCommand("SELECT SKITM3,SKITM4,SKITM6,SKITM8,SKITM9,SKITM11,SKITM10,IT_DATEP,IT_DATEEX,SKITM14,SKITM15,SKITM16 ,SKITM17,SKITM12,SKITM20,SKITM21,ChkPD FROM STOCKSITEMS WHERE SKITM5='" & Me.ComboITEMNAME.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql1)
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
            Me.ExpiryDate.Text = ds.Tables(0).Rows(0).Item(7)
            Me.ProductionDate.Text = ds.Tables(0).Rows(0).Item(8)
            Me.TexTSellingPrice.EditValue = ds.Tables(0).Rows(0).Item(9)
            Me.TextDiscountPercentageWhenSelling.EditValue = ds.Tables(0).Rows(0).Item(10)
            Me.TextLowestDiscountRateWhenSelling.EditValue = ds.Tables(0).Rows(0).Item(11)
            Me.TextHighestDiscountRateWhenSelling.EditValue = ds.Tables(0).Rows(0).Item(12)
            Me.TextSalesTaxRate.EditValue = ds.Tables(0).Rows(0).Item(13)
            Me.CheckPricesMentionedIncludeSalesTax.Checked = ds.Tables(0).Rows(0).Item(14)
            Me.CheckItemIsSubjectToSalesTax.Checked = ds.Tables(0).Rows(0).Item(15)
            Me.ChkPD.Checked = ds.Tables(0).Rows(0).Item(16)
        Else
            Me.TEXTGROUPNAME.Text = "0"
            Me.TextItemCode.Text = "0"
            Me.TEXTMeasruingUnit.Text = "0"
            Me.TEXTOrderLimit.EditValue = "0"
            Me.TEXTUnitPrice.EditValue = "0"
            Me.ExpiryDate.Text = "0"
            Me.ProductionDate.Text = "0"
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
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim sql As New SqlClient.SqlCommand("UPDATE STOCKSITEMS SET SKITM7 = @QUANTITY WHERE STOCKSITEMS.SKITM4='" & Me.TextItemCode.Text.Trim & "'" & " AND STOCKSITEMS.CUser='" & CUser & "'", Consum)
        Dim CMD As New SqlClient.SqlCommand With {
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
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Me.SEARCHDATAITEMS()
        Me.SEARCHBALANCEITEMS()
        ComboPermissionType_SelectedIndexChanged(sender, e)
    End Sub
    Private Sub ComboPermissionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPermissionType.SelectedIndexChanged
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
    Private Sub SEARCHBALANCEITEMS()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        Dim SUM1 As Double
        Dim strsq1 As New SqlClient.SqlCommand("SELECT Sum(STK11 - STK12) FROM STOCKS  WHERE STOCKS.CUser='" & CUser & "' AND (STOCKS.WarehouseNumber)='" & Me.ComboStore.Text.Trim & "' AND (STOCKS.STK25)='" & Me.TextItemCode.Text.Trim & "'AND STOCKS.STK1 <'" & Me.TEXTID.EditValue & "'", Consum)
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
    Private Sub TEXT6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEXTPreviousBalance.TextChanged, TEXTMPORTQUANTITY.EditValueChanged, TEXTEXPORTQUNATITY.EditValueChanged
        On Error Resume Next
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTMPORTQUANTITY.EditValue) - Val(Me.TEXTEXPORTQUNATITY.EditValue), "0.000")
        Me.TextTotalPurchasePrice.EditValue = Format(Val(Me.TEXTCurrentBalance.Text) * Val(Me.TEXTPurchasingPrice.EditValue) * (100 - Val(Me.TEXTDiscount.EditValue)) / 100, "0.000")
        Me.TextSecondSellingPrice.EditValue = Format(Val(Me.TEXTCurrentBalance.Text) * Val(Me.TexTSellingPrice.EditValue) * (100 - Val(Me.TextDiscountPercentageWhenSelling.EditValue)) / 100, "0.000")

    End Sub
    Private Sub TEXT2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTPermissionNumber.KeyDown, TEXTInvoiceNumber.KeyDown, TEXTGROUPNAME.KeyDown, TEXTMeasruingUnit.KeyDown, TEXTPreviousBalance.KeyDown, TEXTCurrentBalance.KeyDown, ComboPermissionType.KeyDown, DateMovementHistory.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
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
            Dim n As Double
            Dim s As Double
            n = Me.BS.Count
            Me.BS.Position = Me.BS.Count - 1
            s = Val(Me.TEXTID.EditValue)
            Me.BS.EndEdit()
            Me.BS.AddNew()
            CLEARDATA1(Me)
            GetAutoNumber("STK1", "STOCKS", "STK4")
            Me.TEXTID.EditValue = AutoNumber
            Me.TextMovementSymbol.Text = "ST" & Me.TEXTID.EditValue
            Me.TEXTMPORTQUANTITY.EditValue = "0"
            Me.TEXTEXPORTQUNATITY.EditValue = "0"
            Me.DateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
            Me.ComboStore.Focus()
            FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)
            Me.TextST.Text = LSet(TextMovementSymbol.Text, 2)
            Dim Sound As System.IO.Stream = My.Resources.addv
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        P = Me.BS.Count
        Me.PictureBox2.Visible = True
        Me.SaveStocks()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.SHOWBUTTON()
        Me.SAVEBUTTON.Enabled = False
        Click1 = True
    End Sub
    Private Sub TEXT15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ExpiryDate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not IsDate(ExpiryDate.Text) Then
                MsgBox("تاريخ غير صالخ")
            Else
                Dim years As Double
                Dim SecondDate As Date
                SecondDate = CDate(Me.ExpiryDate.Text)
                years = 1
                Me.ProductionDate.Text = DateAdd(DateInterval.Year, years, SecondDate)
                Me.ProductionDate.Focus()
            End If
        End If
    End Sub

    Private Sub ComboITEMNAME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboITEMNAME.SelectedIndexChanged
        On Error Resume Next
        Me.SEARCHDATAITEMS()
        Me.SEARCHBALANCEITEMS()
        ChkPD_CheckedChanged(sender, e)
    End Sub

    Private Sub ComboStore_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboStore.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)

        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT WarehouseName  FROM Warehouses WHERE WarehouseNumber ='" & Me.ComboStore.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
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