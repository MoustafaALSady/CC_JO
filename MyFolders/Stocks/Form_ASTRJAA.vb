Imports System.Data.SqlClient

Public Class Form_ASTRJAA

    Dim pagingAdapter As SqlDataAdapter
    Dim pagingDS As DataSet
    ReadOnly scrollVal As Integer
    Dim Tax As Boolean
    Dim Tax1 As Boolean
    Dim TaxBarCod As String


    Dim trakee As String
    Dim Store As Integer
    Dim ChkPD As Boolean = False

    Dim ItemName As String = Nothing
    Dim GROUPNAME As String = Nothing
    Dim MeasruingUnit As String = Nothing
    Dim QUANTITY As Double = 0
    Dim UnitPrice As Double = 0
    Dim Discount As Double = 0
    Dim OrderLimit As Double = 0
    Dim SellingPriceS As Double = 0
    Dim DiscountPercentageWhenSelling As Double = 0
    Dim LowestDiscountRateWhenSelling As Double = 0
    Dim HighestDiscountRateWhenSelling As Double = 0
    Dim CheckTax As Boolean = Nothing
    Dim CheckTax1 As Boolean = Nothing
    Dim ProductionDate As String = Nothing
    Dim ExpiryDate As String = Nothing
    Dim TotaiDiscount As Double = 0
    Dim TotaiPurchasingPrice As Double = 0
    Dim sumItemCount As Double
    Dim SearchData_Chk As Boolean = False
    Dim DiscountAA As Double = 0
    Dim DiscountBB As Double = 0
    Dim UnitPriceA As Double = 0
    Dim SellingPriceA As Double = 0
    Private Sub BuF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BuF.Click
        Me.Datab.Columns.Clear()
        If Me.TextB7.Text = "" Then
            MsgBox("ادخل رقم الفاتورة", MsgBoxStyle.Information, "تنبيه")
            Exit Sub
        End If

        If Me.RadiRecovery.Checked = False And Me.RadiRecoveryALL.Checked = False And Me.RadiReplacing.Checked = False And Me.RadiReplacingALL.Checked = False Then
            MsgBox("حدد نوع العملية استرجاع أو استبدال ", MsgBoxStyle.Information, "تنبيه")
            Exit Sub
        End If
        Dim Consum As New SqlConnection(constring)
        Try
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            'البيانات بالتدريج
            Dim sql As String = "SELECT ID, DataTS,BarCod, TS1, TS2, TS3, TS4, TS5, TS6, TS7, TS8, TS9, TS10, TS11, TS12, TS13, TS14,  TS15, WarehouseName, USERNAME   FROM  TodaySales where  CUser='" & CUser & "' and TS9 = '" & TextB7.Text & "' "
            pagingAdapter = New SqlDataAdapter(sql, Consum)
            pagingDS = New DataSet()
            pagingAdapter.Fill(pagingDS, scrollVal, 50000, "TodaySales")
            Consum.Close()
            If pagingDS.Tables(0).Rows.Count > 0 Then
                Me.Datab.DataSource = pagingDS
                Me.Datab.DataMember = "TodaySales"
                Me.Datab.Sort(Datab.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Me.Datab.Columns(3).Width = "200"
                Me.Datab.Columns(0).HeaderText = "ID"
                Me.Datab.Columns(1).HeaderText = "التاريخ"
                Me.Datab.Columns(2).HeaderText = "الباركود"
                Me.Datab.Columns(3).HeaderText = "اسم الصنف"
                Me.Datab.Columns(4).HeaderText = "العدد"
                Me.Datab.Columns(5).HeaderText = "السعر"
                Me.Datab.Columns(6).HeaderText = "الخصم"
                Me.Datab.Columns(7).HeaderText = "مجموع السعر"
                Me.Datab.Columns(8).HeaderText = "مجموع الخصم"
                Me.Datab.Columns(9).HeaderText = "مجموع عدد الصنف"
                Me.Datab.Columns(10).HeaderText = "خصم الشراء"
                Me.Datab.Columns(11).HeaderText = "رقم الفاتورة"
                Me.Datab.Columns(12).HeaderText = "نوع العملية"
                Me.Datab.Columns(13).HeaderText = "المدفوع"
                Me.Datab.Columns(14).HeaderText = "الاجمالي"
                Me.Datab.Columns(15).HeaderText = "الباقي"
                Me.Datab.Columns(16).HeaderText = "سعر الشراء"
                Me.Datab.Columns(17).HeaderText = "رمز الفاتوره"
                Me.Datab.Columns(18).HeaderText = "المستودع"
                Me.Datab.Columns(19).HeaderText = "المستخدم"
                'كود تلوين الداتا قريد
                Dim dgvRow As New DataGridViewRow
                For Each dgvRow In Datab.Rows
                    If dgvRow.Index Mod 2 = 0 Then
                        Datab.Rows(dgvRow.Index).DefaultCellStyle.BackColor = Color.LightYellow
                    End If
                Next
                Me.SEARCHDATAITEMS()
                SearchData_Chk = False
                RadiRecovery.Enabled = True
                RadiRecoveryALL.Enabled = True
                RadiReplacing.Enabled = True
            Else
                RadiRecovery.Enabled = False
                RadiRecoveryALL.Enabled = False
                RadiReplacing.Enabled = False
                MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub Datab_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Datab.CellClick
        'On Error Resume Next
        Try
            'TexBAR.Text = ""
            If SearchData_Chk = False Then
                LID.Text = Me.Datab(0, e.RowIndex).Value
                Me.Tedate.Text = Me.Datab(1, e.RowIndex).Value
                Me.TexBAR.Text = Me.Datab(2, e.RowIndex).Value
                Me.TextItemName.Text = Me.Datab(3, e.RowIndex).Value
                Me.TextItemCount.Text = Me.Datab(4, e.RowIndex).Value
                Me.TexTSellingPrice.Text = Me.Datab(5, e.RowIndex).Value
                Me.TEXTDiscountA.EditValue = Me.Datab(6, e.RowIndex).Value
                Me.TextTotaiItem.Text = Me.Datab(7, e.RowIndex).Value
                Me.TEXTTotaiDiscount.Text = Me.Datab(8, e.RowIndex).Value
                Me.TextItemCount1.Text = Me.Datab(9, e.RowIndex).Value
                Me.TEXTDiscountB.Text = Me.Datab(10, e.RowIndex).Value
                Me.TEXTInvoiceNumber.Text = Me.Datab(11, e.RowIndex).Value
                Me.TextTabyP.Text = Me.Datab(12, e.RowIndex).Value
                Me.TextpaidUp.Text = Me.Datab(13, e.RowIndex).Value
                Me.TextTotai.Text = Me.Datab(14, e.RowIndex).Value
                Me.TextRest.Text = Me.Datab(15, e.RowIndex).Value
                Me.TEXTTotaiPurchasingPrice.Text = Me.Datab(16, e.RowIndex).Value
                Me.TextMovementSymbol.Text = Me.Datab(17, e.RowIndex).Value
                Me.TextUSERNAME.Text = Me.Datab(19, e.RowIndex).Value
                Me.SEARCHDATAITEMS()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorDatab_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SEARCHDATAITEMS()
        Try
            Dim Consum As New SqlConnection(constring)
            LID.Text = Me.Datab(0, Me.Datab.CurrentRow.Index).Value
            Me.Tedate.Text = Me.Datab(1, Me.Datab.CurrentRow.Index).Value
            Me.TexBAR.Text = Me.Datab(2, Me.Datab.CurrentRow.Index).Value
            Me.TextItemName.Text = Me.Datab(3, Me.Datab.CurrentRow.Index).Value
            Me.TextItemCount.Text = Me.Datab(4, Me.Datab.CurrentRow.Index).Value
            Me.TexTSellingPrice.Text = Me.Datab(5, Me.Datab.CurrentRow.Index).Value
            Me.TEXTDiscountA.EditValue = Me.Datab(6, Me.Datab.CurrentRow.Index).Value
            Me.TextTotaiItem.Text = Me.Datab(7, Me.Datab.CurrentRow.Index).Value
            Me.TEXTTotaiDiscount.Text = Me.Datab(8, Me.Datab.CurrentRow.Index).Value
            Me.TextItemCount1.Text = Me.Datab(9, Me.Datab.CurrentRow.Index).Value
            Me.TEXTDiscountB.EditValue = Me.Datab(10, Me.Datab.CurrentRow.Index).Value
            Me.TEXTInvoiceNumber.Text = Me.Datab(11, Me.Datab.CurrentRow.Index).Value
            Me.TextTabyP.Text = Me.Datab(12, Me.Datab.CurrentRow.Index).Value
            Me.TextpaidUp.Text = Me.Datab(13, Me.Datab.CurrentRow.Index).Value
            Me.TextTotai.Text = Me.Datab(14, Me.Datab.CurrentRow.Index).Value
            Me.TextRest.Text = Me.Datab(15, Me.Datab.CurrentRow.Index).Value
            Me.TEXTTotaiPurchasingPrice.Text = Me.Datab(16, Me.Datab.CurrentRow.Index).Value
            Me.TextMovementSymbol.Text = Me.Datab(17, Me.Datab.CurrentRow.Index).Value
            Me.TextUSERNAME.Text = Me.Datab(19, Me.Datab.CurrentRow.Index).Value

            DiscountAA = Format(Val(TexTSellingPrice.Text * Me.TextItemCount.Text) * Val(TEXTDiscountA.EditValue) / 100, "0.000")
            DiscountBB = Format(Val(TextUnitPrice.Text * Me.TextItemCount.Text) * Val(TEXTDiscountB.EditValue) / 100, "0.000")
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim cmdDX As New SqlCommand("SELECT * FROM STOCKSITEMS WHERE SKITM4='" & Me.Datab.Item(2, Me.Datab.CurrentRow.Index).Value & "'", Consum)
            Dim drDX As SqlDataReader = cmdDX.ExecuteReader
            If drDX.Read = True Then
                Me.TEXTGROUPNAME.Text = drDX.Item("SKITM3")
                Me.TaxBarCod = drDX.Item("SKITM4")
                Me.TextMeasruingUnit.Text = drDX.Item("SKITM6")
                Me.TextQUANTITY.Text = drDX.Item("SKITM7")
                Me.TextUnitPrice.Text = drDX.Item("SKITM8")
                Me.TextDiscount.EditValue = drDX.Item("SKITM9")
                Me.TextOrderLimit.Text = drDX.Item("SKITM11")
                Me.SellingPrice.Text = drDX.Item("SKITM14")
                Me.TextDiscountPercentageWhenSelling.Text = drDX.Item("SKITM15")
                Me.TextLowestDiscountRateWhenSelling.Text = drDX.Item("SKITM16")
                Me.TextHighestDiscountRateWhenSelling.Text = drDX.Item("SKITM17")
                Me.Tax = drDX.Item("SKITM20")
                Me.Tax1 = drDX.Item("SKITM21")
                ChkPD = drDX.Item("ChkPD")
                If ChkPD = True Then
                    Me.TEXTProductionDate.Text = drDX.Item("IT_DATEP")
                    Me.TEXTExpiryDate.Text = drDX.Item("IT_DATEEX")
                End If
                Me.CheckPricesMentionedIncludeSalesTax.Checked = Tax.ToString
                Me.CheckItemIsSubjectToSalesTax.Checked = Tax1.ToString
                Me.TextTotai.Text = Datab.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells(7).Value))
                Me.TextRest.Text = Me.TextTotai.Text - TextpaidUp.Text
                Consum.Close()
                cmdDX.Dispose()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSEARCHDATAITEMS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub NewVal()


        If Me.RadiReplacing.Checked = True Or Me.RadiReplacingALL.Checked = True Then
            DiscountAA = Format(Val(TexTSellingPrice.Text * Me.TextQUANTITY.Text) * Val(TEXTDiscountA.EditValue) / 100, "0.000")
            DiscountBB = Format(Val(TextUnitPrice.Text * Me.TextQUANTITY.Text) * Val(TEXTDiscountB.EditValue) / 100, "0.000")
            If Val(Me.Datab.Rows(Datab.CurrentRow.Index).Cells(5).Value) > Val(TexTSellingPrice.Text) Then

                UnitPriceA = Val(Me.TEXTTotaiPurchasingPrice.Text) - (Val(Me.Datab.Rows(Datab.CurrentRow.Index).Cells(16).Value) * Val(Textadd.Text))

                SellingPriceA = (Val(Me.TexTSellingPrice.Text) * Val(TextQUANTITY.Text)) - Val(Me.Datab.Rows(Datab.CurrentRow.Index).Cells(5).Value)
            ElseIf Val(Me.Datab.Rows(Datab.CurrentRow.Index).Cells(5).Value) < Val(TexTSellingPrice.Text) Then

                UnitPriceA = (Val(Me.Datab.Rows(Datab.CurrentRow.Index).Cells(16).Value) * Val(Textadd.Text)) - Val(TEXTTotaiPurchasingPrice.Text)

                SellingPriceA = Val(Me.Datab.Rows(Datab.CurrentRow.Index).Cells(5).Value) - Val(TexTSellingPrice.Text)

            End If
            Math.Abs(UnitPriceA)
            Math.Abs(SellingPriceA)
        ElseIf Me.RadiRecovery.Checked = True Or Me.RadiRecoveryALL.Checked = True Then
            UnitPriceA = Val(Me.TEXTTotaiPurchasingPrice.Text)
            SellingPriceA = Val(Me.TexTSellingPrice.Text)
        End If




    End Sub
    Private Sub Busave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Busave.Click

        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.TextB7.Text.Trim = "" Then
            MsgBox("ادخل رقم الفاتورة", MsgBoxStyle.Critical, "تنبيه")
            Exit Sub
        End If
        Try
            Dim Consum As New SqlConnection(constring)
            Dim trakee As String
            If Me.RadiRecovery.Checked = True Then
                Try
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    Dim cmdW As New SqlCommand(" Select NumFatorh12 From ASTRGA_ASTRDA Where NumFatorh12 = '" & TEXTInvoiceNumber.Text.Trim & "'and Noaamlea13 ='" & "مسترجع" & "'  and CUser='" & CUser & "'", Consum)
                    Dim drW As SqlDataReader = cmdW.ExecuteReader()
                    If drW.Read Then
                        MsgBox(" الفاتورة تم استرجاعها مسبقاً", MsgBoxStyle.Critical)
                        For Each t As Control In Gro2.Controls
                            If TypeOf t Is TextBox Then
                                t.Text = ""
                            End If
                        Next
                        Exit Sub
                    End If
                    cmdW.Dispose()
                    drW.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
                End Try

                TaxBarCod = TexBAR.Text
                ItemName = TextItemName.Text
                GROUPNAME = TEXTGROUPNAME.Text
                MeasruingUnit = TextMeasruingUnit.Text
                QUANTITY = TextQUANTITY.Text
                UnitPrice = TextUnitPrice.Text
                Discount = TextDiscount.EditValue
                OrderLimit = TextOrderLimit.Text
                SellingPriceS = SellingPrice.Text
                DiscountPercentageWhenSelling = TextDiscountPercentageWhenSelling.Text
                LowestDiscountRateWhenSelling = TextLowestDiscountRateWhenSelling.Text
                HighestDiscountRateWhenSelling = TextHighestDiscountRateWhenSelling.Text
                CheckTax = Tax
                CheckTax1 = Tax1
                ProductionDate = TEXTProductionDate.Text
                ExpiryDate = TEXTExpiryDate.Text
                TotaiDiscount = Val(UnitPrice) * Val(Textadd.Text) * Val(Discount)
                TotaiPurchasingPrice = Val(UnitPrice) * Val(Textadd.Text) - Val(Discount)

                NewVal()

                trakee = Me.RadiRecovery.Text.Trim
                Dim cmd98 As New SqlCommand("insert into ASTRGA_ASTRDA (pros0,Barcodd1,Asmmantg1,Addmantg2,Sarmantg3,Kasmmantg4,SumMANTG5,SumKASM6,ALbaky1,ALbaky2,ADDM7,DataD10,KASM11,NumFatorh12,Noaamlea13,Almadfaa14,Aljmalee15,ALbaky16,CodNumFatorh,chk,chk1,chk2, USERNAME, CUser, COUser, da, ne) values (@pros0,@Barcodd1,@Asmmantg1,@Addmantg2,@Sarmantg3,@Kasmmantg4,@SumMANTG5,@SumKASM6,@ALbaky1,@ALbaky2,@ADDM7,@DataD10,@KASM11,@NumFatorh12,@Noaamlea13,@Almadfaa14,@Aljmalee15,@ALbaky16,@CodNumFatorh,@chk,@chk1,@chk2, @USERNAME, @CUser, @COUser, @da, @ne)", Consum)
                cmd98.Parameters.AddWithValue("@pros0", trakee) '
                cmd98.Parameters.AddWithValue("@Barcodd1", TaxBarCod) '
                cmd98.Parameters.AddWithValue("@Asmmantg1", ItemName) '
                cmd98.Parameters.AddWithValue("@Addmantg2", Me.TextItemCount.Text) '
                cmd98.Parameters.AddWithValue("@Sarmantg3", SellingPriceS) '
                cmd98.Parameters.AddWithValue("@Kasmmantg4", TEXTDiscountA.EditValue) '
                cmd98.Parameters.AddWithValue("@SumMANTG5", Math.Abs(SellingPriceA)) '
                cmd98.Parameters.AddWithValue("@SumKASM6", DiscountAA) '
                cmd98.Parameters.AddWithValue("@ALbaky1", Val(Me.TEXTTotaiPurchasingPrice.Text))
                cmd98.Parameters.AddWithValue("@ALbaky2", Me.TEXTDiscountB.EditValue)

                cmd98.Parameters.AddWithValue("@ADDM7", Me.TextItemCount1.Text.Trim) '
                cmd98.Parameters.AddWithValue("@DataD10", MaxDate.ToString("yyyy-MM-dd"))
                cmd98.Parameters.AddWithValue("@KASM11", DiscountBB) '
                cmd98.Parameters.AddWithValue("@NumFatorh12", Me.TEXTInvoiceNumber.Text) '
                cmd98.Parameters.AddWithValue("@Noaamlea13", "مسترجع") '
                cmd98.Parameters.AddWithValue("@Almadfaa14", Me.TextpaidUp.Text) '
                cmd98.Parameters.AddWithValue("@Aljmalee15", Me.TextTotai.Text) '
                cmd98.Parameters.AddWithValue("@ALbaky16", Math.Abs(UnitPriceA))
                cmd98.Parameters.AddWithValue("@CodNumFatorh", Me.TextMovementSymbol.Text)
                cmd98.Parameters.AddWithValue("@Chk", False) '
                cmd98.Parameters.AddWithValue("@Chk1", False) '
                cmd98.Parameters.AddWithValue("@Chk2", False) '
                cmd98.Parameters.AddWithValue("@USERNAME", USERNAME) '
                cmd98.Parameters.AddWithValue("@CUser", CUser) '
                cmd98.Parameters.AddWithValue("@COUser", COUser) '
                cmd98.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd")) '
                cmd98.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                cmd98.ExecuteNonQuery()
                cmd98.Dispose()
                Me.SAVERECORD1()
            ElseIf Me.RadiRecoveryALL.Checked = True Then
                Dim nextRow As DataGridViewRow
                nextRow = Me.Datab.Rows(0)
                Me.Datab.Rows(0).Selected = True
                Try
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    Dim cmdW As New SqlCommand(" Select NumFatorh12 From ASTRGA_ASTRDA Where NumFatorh12 = '" & TEXTInvoiceNumber.Text.Trim & "'and Noaamlea13 ='" & "مسترجع" & "'  and CUser='" & CUser & "'", Consum)
                    Dim drW As SqlDataReader = cmdW.ExecuteReader()
                    If drW.Read Then
                        MsgBox(" الفاتورة تم استرجاعها مسبقاً", MsgBoxStyle.Critical)
                        For Each t As Control In Gro2.Controls
                            If TypeOf t Is TextBox Then
                                t.Text = ""
                            End If
                        Next
                        Exit Sub
                    End If
                    cmdW.Dispose()
                    drW.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
                End Try
                trakee = Me.RadiRecoveryALL.Text
                Me.Chern.Checked = True
            ElseIf Me.RadiReplacing.Checked = True Then
                trakee = Me.RadiReplacing.Text
                Me.SAVERECORD2()
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
            ElseIf Me.RadiReplacingALL.Checked = True Then
                Dim nextRow As DataGridViewRow
                nextRow = Me.Datab.Rows(0)
                trakee = Me.RadiReplacingALL.Text
                Me.Chern.Checked = True
            End If
            Insert_Actions(Me.TextB7.Text, " استرجاع فاتورة مبيعات رقم".ToString.Trim, Me.Text)
            Consum.Close()
            Busave.BackColor = Color.Transparent
            Busave.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorBusave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ASTRGA_ASTRDA()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim trakee As String
            If Me.RadiRecoveryALL.Checked = True Then
                trakee = Me.RadiRecovery.Text.Trim
            ElseIf Me.RadiReplacingALL.Checked = True Then
                trakee = Me.RadiReplacingALL.Text.Trim
            ElseIf Me.RadiReplacing.Checked = True Then
                trakee = Me.RadiReplacing.Text.Trim
            Else
                trakee = Me.RadiReplacingALL.Text.Trim
            End If
            NewVal()
            Dim cmd98 As New SqlCommand("insert into ASTRGA_ASTRDA (pros0,Barcodd1,Asmmantg1,Addmantg2,Sarmantg3,Kasmmantg4,SumMANTG5,SumKASM6,ALbaky1,ALbaky2,ADDM7,DataD10,KASM11,NumFatorh12,Noaamlea13,Almadfaa14,Aljmalee15,ALbaky16,CodNumFatorh,chk,chk1,chk2, USERNAME, CUser, COUser, da, ne) values (@pros0,@Barcodd1,@Asmmantg1,@Addmantg2,@Sarmantg3,@Kasmmantg4,@SumMANTG5,@SumKASM6,@ALbaky1,@ALbaky2,@ADDM7,@DataD10,@KASM11,@NumFatorh12,@Noaamlea13,@Almadfaa14,@Aljmalee15,@ALbaky16,@CodNumFatorh,@chk,@chk1,@chk2, @USERNAME, @CUser, @COUser, @da, @ne)", Consum)
            cmd98.Parameters.AddWithValue("@pros0", trakee) '
            cmd98.Parameters.AddWithValue("@Barcodd1", TexBAR.Text) '
            cmd98.Parameters.AddWithValue("@Asmmantg1", TextItemName.Text) '
            cmd98.Parameters.AddWithValue("@Addmantg2", Me.TextItemCount.Text) '
            cmd98.Parameters.AddWithValue("@Sarmantg3", SellingPrice.Text) '
            cmd98.Parameters.AddWithValue("@Kasmmantg4", TEXTDiscountA.EditValue) '
            cmd98.Parameters.AddWithValue("@SumMANTG5", Math.Abs(SellingPriceA)) '
            cmd98.Parameters.AddWithValue("@SumKASM6", DiscountAA) '
            cmd98.Parameters.AddWithValue("@ALbaky1", Val(Me.TEXTTotaiPurchasingPrice.Text))
            cmd98.Parameters.AddWithValue("@ALbaky2", Me.TEXTDiscountB.EditValue)

            cmd98.Parameters.AddWithValue("@ADDM7", Me.TextItemCount1.Text) '
            cmd98.Parameters.AddWithValue("@DataD10", MaxDate.ToString("yyyy-MM-dd"))
            cmd98.Parameters.AddWithValue("@KASM11", DiscountBB) '
            cmd98.Parameters.AddWithValue("@NumFatorh12", Me.TEXTInvoiceNumber.Text) '
            cmd98.Parameters.AddWithValue("@Noaamlea13", "مسترجع") '
            cmd98.Parameters.AddWithValue("@Almadfaa14", Me.TextpaidUp.Text) '
            cmd98.Parameters.AddWithValue("@Aljmalee15", Me.TextTotai.Text) '
            cmd98.Parameters.AddWithValue("@ALbaky16", Math.Abs(UnitPriceA))
            cmd98.Parameters.AddWithValue("@CodNumFatorh", Me.TextMovementSymbol.Text)
            cmd98.Parameters.AddWithValue("@Chk", False) '
            cmd98.Parameters.AddWithValue("@Chk1", False) '
            cmd98.Parameters.AddWithValue("@Chk2", False) '
            cmd98.Parameters.AddWithValue("@USERNAME", USERNAME) '
            cmd98.Parameters.AddWithValue("@CUser", CUser) '
            cmd98.Parameters.AddWithValue("@COUser", COUser) '
            cmd98.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd")) '
            cmd98.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd98.ExecuteNonQuery()
            cmd98.Dispose()
            Consum.Close()
            Me.Busave.Enabled = False
            Me.Busave.BackColor = Color.Transparent
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorASTRGA_ASTRDA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SAVERECORD()
        Try
            Dim Consum As New SqlConnection(constring)

            Dim trakee As String
            If Me.RadiRecoveryALL.Checked = True Then
                trakee = Me.RadiRecoveryALL.Text.Trim
                GetAutoIDSTK()
                Dim SQL As String = "INSERT INTO STOCKS(  STK1, WarehouseNumber, WarehouseName,  STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, USERNAME, CUser, COUser, da, ne, IT_DATEP, IT_DATEEX) VALUES     (@STK1, @WarehouseNumber, @WarehouseName, @STK3, @STK4, @STK5, @STK6, @STK7, @STK8, @STK9, @STK10, @STK11, @STK12, @STK13, @STK14, @STK15, @STK16, @STK17, @STK18, @STK19, @STK20, @STK21, @STK22, @STK23, @STK25, @STK24, @STK26, @USERNAME, @CUser, @COUser, @da, @ne, @IT_DATEP, @IT_DATEEX)"
                Dim CMD As New SqlCommand(SQL, Consum)
                With CMD.Parameters
                    .AddWithValue("@STK1", IDSTK)
                    .AddWithValue("@WarehouseNumber", Me.ComboStore.Text)
                    .AddWithValue("@WarehouseName", Me.TextWarehouseName.Text)
                    .AddWithValue("@STK3", "0")
                    .AddWithValue("@STK4", MaxDate.ToString("yyyy-MM-dd"))
                    .AddWithValue("@STK5", "مردودات مبيعات")
                    .AddWithValue("@STK6", Me.TEXTInvoiceNumber.Text)
                    .AddWithValue("@STK7", Me.TextItemName.Text)
                    .AddWithValue("@STK8", Me.TEXTGROUPNAME.Text)
                    .AddWithValue("@STK9", Me.TextMeasruingUnit.Text)
                    .AddWithValue("@STK10", Format(Val(SumAmounTOTALSTOCKS(Me.Datab.Rows(Me.Datab.CurrentRow.Index).Cells(2).Value, IDSTK)), "0.000"))
                    .AddWithValue("@STK11", Me.TextItemCount.Text)
                    .AddWithValue("@STK12", "0")
                    .AddWithValue("@STK13", Format(Me.TextItemCount.Text + Val(Format(Val(SumAmounTOTALSTOCKS(Me.Datab.Rows(Datab.CurrentRow.Index).Cells(2).Value, IDSTK)), "0.000")), "0.000"))
                    .AddWithValue("@STK14", Me.TextOrderLimit.Text)
                    .AddWithValue("@STK15", Me.TextUnitPrice.Text)
                    .AddWithValue("@STK16", Me.TextMovementSymbol.Text)
                    .AddWithValue("@STK17", Me.TextDiscount.EditValue)
                    .AddWithValue("@STK18", Format(Val(Me.TextUnitPrice.Text) * Val(Format(Val(TextQUANTITY.Text), "0.000")) * (100 - Val(Me.TextDiscount.EditValue)) / 100, "0.000"))
                    .AddWithValue("@STK19", Me.TexTSellingPrice.Text)
                    .AddWithValue("@STK20", Format(Val(Me.TexTSellingPrice.Text) * Val(Format(Val(TextQUANTITY.Text), "0.000")) * (100 - Val(Me.TextDiscountPercentageWhenSelling.Text)) / 100, "0.000"))
                    .AddWithValue("@STK21", Me.TextDiscountPercentageWhenSelling.Text)
                    .AddWithValue("@STK22", Me.TextLowestDiscountRateWhenSelling.Text)
                    .AddWithValue("@STK23", Me.TextHighestDiscountRateWhenSelling.Text)
                    .AddWithValue("@STK25", Me.Datab.Item(2, Me.Datab.CurrentRow.Index).Value)
                    .AddWithValue("@STK24", Convert.ToInt32(Me.CheckPricesMentionedIncludeSalesTax.Checked).ToString)
                    .AddWithValue("@STK26", Convert.ToInt32(Me.CheckItemIsSubjectToSalesTax.Checked).ToString)
                    .AddWithValue("@USERNAME", USERNAME)
                    .AddWithValue("@CUser", CUser)
                    .AddWithValue("@COUser", COUser)
                    .AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                    .AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                    .AddWithValue("@IT_DATEP", Me.TEXTProductionDate.Text)
                    .AddWithValue("@IT_DATEEX", Me.TEXTExpiryDate.Text)
                End With
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Me.UPDATEBALANCEITEMS()
                Consum.Close()
                Me.SAVERECORD1()
            ElseIf Me.RadiReplacingALL.Checked = True Then
                trakee = Me.RadiReplacingALL.Text.Trim
                GetAutoIDSTK()
                Dim SQL As String = "INSERT INTO STOCKS(  STK1, WarehouseNumber, WarehouseName,  STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, USERNAME, CUser, COUser, da, ne, IT_DATEP, IT_DATEEX) VALUES     (@STK1, @WarehouseNumber, @WarehouseName, @STK3, @STK4, @STK5, @STK6, @STK7, @STK8, @STK9, @STK10, @STK11, @STK12, @STK13, @STK14, @STK15, @STK16, @STK17, @STK18, @STK19, @STK20, @STK21, @STK22, @STK23, @STK25, @STK24, @STK26, @USERNAME, @CUser, @COUser, @da, @ne, @IT_DATEP, @IT_DATEEX)"
                Dim CMD As New SqlCommand(SQL, Consum)
                With CMD.Parameters
                    .AddWithValue("@STK1", IDSTK)
                    .AddWithValue("@WarehouseNumber", Me.ComboStore.Text)
                    .AddWithValue("@WarehouseName", Me.TextWarehouseName.Text)
                    .AddWithValue("@STK3", "0")
                    .AddWithValue("@STK4", MaxDate.ToString("yyyy-MM-dd"))
                    .AddWithValue("@STK5", trakee.ToString)
                    .AddWithValue("@STK6", Me.TextB7.Text)
                    .AddWithValue("@STK7", Me.TextItemName.Text)
                    .AddWithValue("@STK8", Me.TEXTGROUPNAME.Text)
                    .AddWithValue("@STK9", Me.TextMeasruingUnit.Text)
                    .AddWithValue("@STK10", Format(Val(SumAmounTOTALSTOCKS(Me.Datab.Rows(Me.Datab.CurrentRow.Index).Cells(2).Value, IDSTK)), "0.000"))
                    .AddWithValue("@STK11", Me.TextItemCount.Text)
                    .AddWithValue("@STK12", "0")
                    .AddWithValue("@STK13", Format(Me.TextItemCount.Text + Val(Format(Val(SumAmounTOTALSTOCKS(Me.Datab.Rows(Me.Datab.CurrentRow.Index).Cells(2).Value, IDSTK)), "0.000")), "0.000"))
                    .AddWithValue("@STK14", Me.TextOrderLimit.Text)
                    .AddWithValue("@STK15", Me.TextUnitPrice.Text)
                    .AddWithValue("@STK16", Me.TextMovementSymbol.Text)
                    .AddWithValue("@STK17", Me.TextDiscount.EditValue)
                    .AddWithValue("@STK18", Format(Val(Me.TextUnitPrice.Text) * Val(Format(Val(TextQUANTITY.Text), "0.000")) * (100 - Val(Me.TextDiscount.EditValue)) / 100, "0.000"))
                    .AddWithValue("@STK19", Me.TexTSellingPrice.Text)
                    .AddWithValue("@STK20", Format(Val(Me.TexTSellingPrice.Text) * Val(Format(Val(TextQUANTITY.Text), "0.000")) * (100 - Val(Me.TextDiscountPercentageWhenSelling.Text)) / 100, "0.000"))
                    .AddWithValue("@STK21", Me.TextDiscountPercentageWhenSelling.Text)
                    .AddWithValue("@STK22", Me.TextLowestDiscountRateWhenSelling.Text)
                    .AddWithValue("@STK23", Me.TextHighestDiscountRateWhenSelling.Text)
                    .AddWithValue("@STK25", Me.TexBAR.Text)
                    .AddWithValue("@STK24", Convert.ToInt32(Me.CheckPricesMentionedIncludeSalesTax.Checked).ToString)
                    .AddWithValue("@STK26", Convert.ToInt32(Me.CheckItemIsSubjectToSalesTax.Checked).ToString)
                    .AddWithValue("@USERNAME", USERNAME)
                    .AddWithValue("@CUser", CUser)
                    .AddWithValue("@COUser", COUser)
                    .AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                    .AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                    .AddWithValue("@IT_DATEP", Me.TEXTProductionDate.Text)
                    .AddWithValue("@IT_DATEEX", Me.TEXTExpiryDate.Text)
                End With
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Me.UPDATEBALANCEITEMS()
                Consum.Close()
                Me.SAVERECORD1()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSAVERECORD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SAVERECORD1()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim trakee As String
            QUANTITY = TextQUANTITY.Text
            DiscountAA = Format(Val(TexTSellingPrice.Text * Me.TextItemCount.Text) * Val(TEXTDiscountA.EditValue) / 100, "0.000")
            DiscountBB = Format(Val(TextUnitPrice.Text * Me.TextItemCount.Text) * Val(TEXTDiscountB.EditValue) / 100, "0.000")
            If Me.RadiRecovery.Checked = True Then
                sumItemCount = Format(Val(SumAmounTOTALSTOCKS(TexBAR.Text, IDSTK)), "0.000")
                trakee = Me.RadiRecovery.Text
                GetAutoIDSTK()
                Dim SQL As String = "INSERT INTO STOCKS(  STK1, WarehouseNumber, WarehouseName,  STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, USERNAME, CUser, COUser, da, ne, IT_DATEP, IT_DATEEX) VALUES     (@STK1, @WarehouseNumber, @WarehouseName, @STK3, @STK4, @STK5, @STK6, @STK7, @STK8, @STK9, @STK10, @STK11, @STK12, @STK13, @STK14, @STK15, @STK16, @STK17, @STK18, @STK19, @STK20, @STK21, @STK22, @STK23, @STK25, @STK24, @STK26, @USERNAME, @CUser, @COUser, @da, @ne, @IT_DATEP, @IT_DATEEX)"
                Dim CMD As New SqlCommand(SQL, Consum)
                With CMD.Parameters
                    .AddWithValue("@STK1", IDSTK)
                    .AddWithValue("@WarehouseNumber", Me.ComboStore.Text)
                    .AddWithValue("@WarehouseName", Me.TextWarehouseName.Text)
                    .AddWithValue("@STK3", "0")
                    .AddWithValue("@STK4", MaxDate.ToString("yyyy-MM-dd"))
                    .AddWithValue("@STK5", "مردودات مبيعات")
                    .AddWithValue("@STK6", Me.TEXTInvoiceNumber.Text)
                    .AddWithValue("@STK7", Me.TextItemName.Text)
                    .AddWithValue("@STK8", TEXTGROUPNAME.Text)
                    .AddWithValue("@STK9", TextMeasruingUnit.Text)
                    .AddWithValue("@STK10", Format(Val(SumAmounTOTALSTOCKS(TaxBarCod, IDSTK)), "0.000"))
                    .AddWithValue("@STK11", Me.TextItemCount.Text)
                    .AddWithValue("@STK12", "0")
                    .AddWithValue("@STK13", Format(Val(SumAmounTOTALSTOCKS(TaxBarCod, IDSTK)), "0.000") + Val(TextItemCount.Text))
                    .AddWithValue("@STK14", TextOrderLimit.Text)
                    .AddWithValue("@STK15", Val(Me.TEXTTotaiPurchasingPrice.Text + DiscountBB))
                    .AddWithValue("@STK16", Me.TextMovementSymbol.Text)
                    .AddWithValue("@STK17", Me.TEXTDiscountB.EditValue)
                    .AddWithValue("@STK18", Format(Val(UnitPrice) * Val(QUANTITY), "0.000"))
                    .AddWithValue("@STK19", TexTSellingPrice.Text)
                    .AddWithValue("@STK20", Format(Val(Me.TexTSellingPrice.Text) * Val(QUANTITY), "0.000"))
                    .AddWithValue("@STK21", DiscountPercentageWhenSelling)
                    .AddWithValue("@STK22", LowestDiscountRateWhenSelling)
                    .AddWithValue("@STK23", HighestDiscountRateWhenSelling)
                    .AddWithValue("@STK25", TexBAR.Text)
                    .AddWithValue("@STK24", Convert.ToInt32(Me.CheckPricesMentionedIncludeSalesTax.Checked).ToString)
                    .AddWithValue("@STK26", Convert.ToInt32(Me.CheckItemIsSubjectToSalesTax.Checked).ToString)
                    .AddWithValue("@USERNAME", USERNAME)
                    .AddWithValue("@CUser", CUser)
                    .AddWithValue("@COUser", COUser)
                    .AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                    .AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                    .AddWithValue("@IT_DATEP", Me.TEXTProductionDate.Text)
                    .AddWithValue("@IT_DATEEX", Me.TEXTExpiryDate.Text)
                End With
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Me.UPDATEBALANCEITEMS()
                Consum.Close()
            ElseIf Me.RadiReplacing.Checked = True Then
                trakee = Me.RadiReplacing.Text & " " & "استبدال صنف (استلام)"
                GetAutoIDSTK()
                sumItemCount = Format(Val(SumAmounTOTALSTOCKS(TexBAR.Text, IDSTK)), "0.000")
                Dim SQL As String = "INSERT INTO STOCKS(  STK1, WarehouseNumber, WarehouseName,  STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, USERNAME, CUser, COUser, da, ne, IT_DATEP, IT_DATEEX) VALUES     (@STK1, @WarehouseNumber, @WarehouseName, @STK3, @STK4, @STK5, @STK6, @STK7, @STK8, @STK9, @STK10, @STK11, @STK12, @STK13, @STK14, @STK15, @STK16, @STK17, @STK18, @STK19, @STK20, @STK21, @STK22, @STK23, @STK25, @STK24, @STK26, @USERNAME, @CUser, @COUser, @da, @ne, @IT_DATEP, @IT_DATEEX)"
                Dim CMD As New SqlCommand(SQL, Consum)
                With CMD.Parameters
                    .AddWithValue("@STK1", IDSTK)
                    .AddWithValue("@WarehouseNumber", Me.ComboStore.Text)
                    .AddWithValue("@WarehouseName", Me.TextWarehouseName.Text)
                    .AddWithValue("@STK3", "0")
                    .AddWithValue("@STK4", MaxDate.ToString("yyyy-MM-dd"))
                    .AddWithValue("@STK5", "استبدال صنف (استلام)")
                    .AddWithValue("@STK6", Me.TextB7.Text)
                    .AddWithValue("@STK7", ItemName)
                    .AddWithValue("@STK8", TEXTGROUPNAME.Text)
                    .AddWithValue("@STK9", TextMeasruingUnit.Text)
                    .AddWithValue("@STK10", Format(Val(SumAmounTOTALSTOCKS(TaxBarCod, IDSTK)), "0.000"))
                    .AddWithValue("@STK11", Me.TextItemCount.Text)
                    .AddWithValue("@STK12", "0")
                    .AddWithValue("@STK13", Format(Val(SumAmounTOTALSTOCKS(TaxBarCod, IDSTK)), "0.000") + Val(TextItemCount.Text))
                    .AddWithValue("@STK14", TextOrderLimit.Text)
                    .AddWithValue("@STK15", UnitPrice)
                    .AddWithValue("@STK16", Me.TextMovementSymbol.Text)
                    .AddWithValue("@STK17", Me.TEXTDiscountB.EditValue)
                    .AddWithValue("@STK18", Format(Val(UnitPrice) * Val(QUANTITY), "0.000"))
                    .AddWithValue("@STK19", TexTSellingPrice.Text)
                    .AddWithValue("@STK20", Format(Val(Me.TexTSellingPrice.Text) * Val(QUANTITY), "0.000"))
                    .AddWithValue("@STK21", DiscountPercentageWhenSelling)
                    .AddWithValue("@STK22", LowestDiscountRateWhenSelling)
                    .AddWithValue("@STK23", HighestDiscountRateWhenSelling)
                    .AddWithValue("@STK25", TaxBarCod)
                    .AddWithValue("@STK24", Convert.ToInt32(CheckTax))
                    .AddWithValue("@STK26", Convert.ToInt32(CheckTax1))
                    .AddWithValue("@IT_DATEP", TEXTProductionDate.Text)
                    .AddWithValue("@IT_DATEEX", TEXTExpiryDate.Text)
                    'DiscountBB = Format(Val(UnitPrice * TEXTDiscountB.EditValue) / 100, "0.000")
                    .AddWithValue("@USERNAME", USERNAME)
                    .AddWithValue("@CUser", CUser)
                    .AddWithValue("@COUser", COUser)
                    .AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                    .AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                End With

                'TotaiDiscount = Val(UnitPrice) * Val(Textadd.Text) * Val(Discount)
                'TotaiPurchasingPrice = Val(UnitPrice) * Val(Textadd.Text) - Val(Discount)
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Me.UPDATEBALANCEITEMS()
                Consum.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSAVERECORD1", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SAVERECORD2()
        Try

            'TaxBarCod = TexBAR.Text
            'ItemName = TextItemName.Text
            'GROUPNAME = TEXTGROUPNAME.Text
            'MeasruingUnit = TextMeasruingUnit.Text
            'QUANTITY = TextQUANTITY.Text
            'UnitPrice = TextUnitPrice.Text
            'Discount = TextDiscount.EditValue
            'OrderLimit = TextOrderLimit.Text
            'SellingPriceS = SellingPrice.Text
            'DiscountPercentageWhenSelling = TextDiscountPercentageWhenSelling.Text
            'LowestDiscountRateWhenSelling = TextLowestDiscountRateWhenSelling.Text
            'HighestDiscountRateWhenSelling = TextHighestDiscountRateWhenSelling.Text
            'CheckTax = Tax
            'CheckTax1 = Tax1
            'ProductionDate = TEXTProductionDate.Text
            'ExpiryDate = TEXTExpiryDate.Text
            'TotaiDiscount = Val(UnitPrice) * Val(Textadd.Text) * Val(Discount)
            'TotaiPurchasingPrice = Val(UnitPrice) * Val(Textadd.Text) - Val(Discount)
            QUANTITY = TextQUANTITY.Text
            Dim Consum As New SqlConnection(constring)
            Dim trakee As String
            If Me.RadiReplacing.Checked = True Then
                trakee = Me.RadiReplacing.Text.Trim
                GetAutoIDSTK()
                Dim SQL As String = "INSERT INTO STOCKS(  STK1, WarehouseNumber, WarehouseName,  STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, USERNAME, CUser, COUser, da, ne, IT_DATEP, IT_DATEEX) VALUES     (@STK1, @WarehouseNumber, @WarehouseName, @STK3, @STK4, @STK5, @STK6, @STK7, @STK8, @STK9, @STK10, @STK11, @STK12, @STK13, @STK14, @STK15, @STK16, @STK17, @STK18, @STK19, @STK20, @STK21, @STK22, @STK23, @STK25, @STK24, @STK26, @USERNAME, @CUser, @COUser, @da, @ne, @IT_DATEP, @IT_DATEEX)"
                Dim CMD As New SqlCommand(SQL, Consum)
                With CMD.Parameters
                    .AddWithValue("@STK1", IDSTK)
                    .AddWithValue("@WarehouseNumber", Me.ComboStore.Text)
                    .AddWithValue("@WarehouseName", Me.TextWarehouseName.Text)
                    .AddWithValue("@STK3", "0")
                    .AddWithValue("@STK4", MaxDate.ToString("yyyy-MM-dd"))
                    .AddWithValue("@STK5", "استبدال صنف (صرف)")
                    .AddWithValue("@STK6", Me.TextB7.Text)
                    .AddWithValue("@STK7", Me.TextItemName.Text)
                    .AddWithValue("@STK8", Me.TEXTGROUPNAME.Text)
                    .AddWithValue("@STK9", Me.TextMeasruingUnit.Text)
                    .AddWithValue("@STK10", Format(Val(SumAmounTOTALSTOCKS(TexBAR.Text, IDSTK)), "0.000"))
                    .AddWithValue("@STK11", "0")
                    .AddWithValue("@STK12", Me.TextItemCount.Text)
                    .AddWithValue("@STK13", Format(Val(SumAmounTOTALSTOCKS(TexBAR.Text, IDSTK)), "0.000") - Val(TextItemCount.Text))
                    .AddWithValue("@STK14", Me.TextOrderLimit.Text)
                    .AddWithValue("@STK15", Me.TEXTTotaiPurchasingPrice.Text)
                    .AddWithValue("@STK16", Me.TextMovementSymbol.Text)
                    .AddWithValue("@STK17", Me.TextDiscount.EditValue)
                    .AddWithValue("@STK18", Format(Val(Me.TEXTTotaiPurchasingPrice.Text) * Val(QUANTITY), "0.000"))
                    .AddWithValue("@STK19", Me.TexTSellingPrice.Text)
                    .AddWithValue("@STK20", Format(Val(Me.TexTSellingPrice.Text) * Val(QUANTITY), "0.000"))


                    .AddWithValue("@STK21", Me.TextDiscountPercentageWhenSelling.Text)
                    .AddWithValue("@STK22", Me.TextLowestDiscountRateWhenSelling.Text)
                    .AddWithValue("@STK23", Me.TextHighestDiscountRateWhenSelling.Text)
                    .AddWithValue("@STK25", Me.TexBAR.Text)
                    .AddWithValue("@STK24", Convert.ToInt32(Me.CheckPricesMentionedIncludeSalesTax.Checked).ToString)
                    .AddWithValue("@STK26", Convert.ToInt32(Me.CheckItemIsSubjectToSalesTax.Checked).ToString)
                    .AddWithValue("@USERNAME", USERNAME)
                    .AddWithValue("@CUser", CUser)
                    .AddWithValue("@COUser", COUser)
                    .AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                    .AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                    .AddWithValue("@IT_DATEP", Me.TEXTProductionDate.Text)
                    .AddWithValue("@IT_DATEEX", Me.TEXTExpiryDate.Text)
                End With
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Me.UPDATEBALANCEITEMS()
                Consum.Close()
            ElseIf Me.RadiReplacingALL.Checked = True Then
                trakee = RadiReplacingALL.Text.Trim
                GetAutoIDSTK()
                Dim SQL As String = "INSERT INTO STOCKS(  STK1, WarehouseNumber, WarehouseName,  STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, USERNAME, CUser, COUser, da, ne, IT_DATEP, IT_DATEEX) VALUES     (@STK1, @WarehouseNumber, @WarehouseName, @STK3, @STK4, @STK5, @STK6, @STK7, @STK8, @STK9, @STK10, @STK11, @STK12, @STK13, @STK14, @STK15, @STK16, @STK17, @STK18, @STK19, @STK20, @STK21, @STK22, @STK23, @STK25, @STK24, @STK26, @USERNAME, @CUser, @COUser, @da, @ne, @IT_DATEP, @IT_DATEEX)"
                Dim CMD As New SqlCommand(SQL, Consum)
                With CMD.Parameters
                    .AddWithValue("@STK1", IDSTK)
                    .AddWithValue("@WarehouseNumber", Me.ComboStore.Text)
                    .AddWithValue("@WarehouseName", Me.TextWarehouseName.Text)
                    .AddWithValue("@STK3", "0")
                    .AddWithValue("@STK4", MaxDate.ToString("yyyy-MM-dd"))
                    .AddWithValue("@STK5", "استبدال صنف (صرف)")
                    .AddWithValue("@STK6", Me.TextB7.Text)
                    .AddWithValue("@STK7", Me.TextItemName.Text)
                    .AddWithValue("@STK8", Me.TEXTGROUPNAME.Text)
                    .AddWithValue("@STK9", Me.TextMeasruingUnit.Text)
                    .AddWithValue("@STK10", Format(Val(SumAmounTOTALSTOCKS(Datab.Rows(Me.Datab.CurrentRow.Index).Cells(2).Value, IDSTK)), "0.000"))
                    .AddWithValue("@STK11", "0")
                    .AddWithValue("@STK12", Me.TextItemCount.Text)
                    .AddWithValue("@STK13", Format(Val(SumAmounTOTALSTOCKS(Me.Datab.Rows(Datab.CurrentRow.Index).Cells(2).Value, IDSTK)), "0.000") - Me.TextItemCount.Text)
                    .AddWithValue("@STK14", Me.TextOrderLimit.Text)
                    .AddWithValue("@STK15", Me.TextUnitPrice.Text)
                    .AddWithValue("@STK16", Me.TextMovementSymbol.Text)
                    .AddWithValue("@STK17", Me.TextDiscount.EditValue)
                    .AddWithValue("@STK18", Format(Val(Me.TextUnitPrice.Text) * Val(Format(Me.TextItemCount.Text, "0.000")) * (100 - Val(Me.TextDiscount.EditValue)) / 100, "0.000"))
                    .AddWithValue("@STK19", Me.TexTSellingPrice.Text)
                    .AddWithValue("@STK20", Format(Val(Me.TexTSellingPrice.Text) * Val(Format(Me.TextItemCount.Text, "0.000")) * (100 - Val(Me.TextDiscountPercentageWhenSelling.Text)) / 100, "0.000"))
                    .AddWithValue("@STK21", Me.TextDiscountPercentageWhenSelling.Text)
                    .AddWithValue("@STK22", Me.TextLowestDiscountRateWhenSelling.Text)
                    .AddWithValue("@STK23", Me.TextHighestDiscountRateWhenSelling.Text)
                    .AddWithValue("@STK25", Me.TexBAR.Text)
                    .AddWithValue("@STK24", Convert.ToInt32(Me.CheckPricesMentionedIncludeSalesTax.Checked).ToString)
                    .AddWithValue("@STK26", Convert.ToInt32(Me.CheckItemIsSubjectToSalesTax.Checked).ToString)
                    .AddWithValue("@USERNAME", USERNAME)
                    .AddWithValue("@CUser", CUser)
                    .AddWithValue("@COUser", COUser)
                    .AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                    .AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                    .AddWithValue("@IT_DATEP", Me.TEXTProductionDate.Text)
                    .AddWithValue("@IT_DATEEX", Me.TEXTExpiryDate.Text)
                End With
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Me.UPDATEBALANCEITEMS()
                Consum.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSAVERECORD2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UPDATEBALANCEITEMS()
        Try
            Dim Consum As New SqlConnection(constring)
            If Me.Datab.Rows.Count > 0 Then
                For i As Integer = 0 To Me.Datab.Rows.Count - 1
                    Dim row As DataGridViewRow = Me.Datab.Rows(i)
                    If row.IsNewRow Then Continue For 'حتى لا يتم السطر الجديد الفارغ
                    Dim sql As New SqlCommand("UPDATE STOCKSITEMS SET SKITM7 = @QUANTITY WHERE STOCKSITEMS.SKITM4='" & Datab.Item(2, Datab.CurrentRow.Index).Value & "'", Consum)
                    Dim CMD As New SqlCommand With {
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    With CMD
                        .CommandType = CommandType.Text
                        .Connection = Consum
                        .Parameters.Add("@QUANTITY", System.Data.SqlDbType.Float).Value = Val(Me.TextQUANTITY.Text)
                        .CommandText = sql.CommandText
                    End With
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    CMD.Parameters.Clear()
                    Consum.Close()
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUPDATEBALANCEITEMS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UPDATERECORD()
        Try

            If Me.RadiReplacing.Checked = True Then
                trakee = Me.RadiReplacing.Text
            ElseIf Me.RadiReplacingALL.Checked = True Then
                trakee = Me.RadiReplacingALL.Text
            End If
            Dim Consum As New SqlConnection(constring)
            DiscountAA = Format(Val(TexTSellingPrice.Text * Me.TextItemCount.Text) * Val(TEXTDiscountA.EditValue) / 100, "0.000")
            DiscountBB = Format(Val(TextUnitPrice.Text * Me.TextItemCount.Text) * Val(TEXTDiscountB.EditValue) / 100, "0.000")
            If Me.Datab.Rows.Count > 0 Then
                For i As Integer = 0 To Me.Datab.Rows.Count - 1

                    Dim row As DataGridViewRow = Datab.Rows(i)
                    If row.IsNewRow Then Continue For 'حتى لا يتم السطر الجديد الفارغ
                    Dim SQL As New SqlCommand(" Update TodaySales SET  BarCod = @BarCod, TS1 = @TS1, TS2 = @TS2, TS3 = @TS3, TS4 = @TS4, TS5 = @TS5, TS6 = @TS6, TS7 = @TS7, TS8 = @TS8,TS9 = @TS9, TS10 = @TS10, TS11 = @TS11, TS12 = @TS12, TS14 = @TS14, WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName,  USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne where TS9 = '" & TextB7.Text.Trim & "' and ID='" & Datab.Item(0, Datab.CurrentRow.Index).Value & "'", Consum)
                    Dim CMD As New SqlCommand(SQL.CommandText) With {
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    With CMD
                        .Parameters.Add("@BarCod", SqlDbType.NVarChar).Value = Me.TaxBarCod.ToString
                        .Parameters.Add("@TS1", SqlDbType.NVarChar).Value = Me.TextItemName.Text
                        .Parameters.Add("@TS2", SqlDbType.NVarChar).Value = Val(Me.Textadd.Text)
                        .Parameters.Add("@TS3", SqlDbType.Float).Value = Val(Me.SellingPrice.Text) * Val(Me.Textadd.Text)
                        .Parameters.Add("@TS4", SqlDbType.Float).Value = Me.TEXTDiscountA.EditValue
                        .Parameters.Add("@TS5", SqlDbType.Float).Value = Me.TexTSellingPrice.Text
                        .Parameters.Add("@TS6", SqlDbType.Float).Value = DiscountAA
                        .Parameters.Add("@TS7", SqlDbType.NVarChar).Value = Val(Me.TextItemCount.Text)
                        .Parameters.Add("@TS8", SqlDbType.Float).Value = Val(DiscountBB)
                        .Parameters.Add("@TS9", SqlDbType.BigInt).Value = Me.TEXTInvoiceNumber.Text
                        .Parameters.Add("@TS10", SqlDbType.NVarChar).Value = trakee.ToString
                        .Parameters.Add("@TS11", SqlDbType.NVarChar).Value = Me.TextpaidUp.Text
                        .Parameters.Add("@TS12", SqlDbType.Float).Value = Me.TextTotai.Text
                        .Parameters.Add("@TS14", SqlDbType.Float).Value = Val(Me.TextUnitPrice.Text) * Val(Me.Textadd.Text)

                        .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Me.ComboStore.Text
                        .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text
                        .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                        .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                        .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                        .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd") '
                        .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt") '
                    End With
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    CMD.Parameters.Clear()
                    Consum.Close()
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUPDATERECORD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Timsum1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timsum1.Tick
        On Error Resume Next
        If Me.RadiRecoveryALL.Checked = True Then
            If Me.Chern.Checked = True Then
                Me.SEARCHDATAITEMS()
                Me.TextQUANTITY.Text = Format(Datab.Item(4, Datab.CurrentRow.Index).Value + Val(Me.TextQUANTITY.Text), "0.000")
                Me.Datab.Rows(0).Selected = True
                If Me.Datab.Rows.Count = 0 Then
                    Me.SEARCHDATAITEMS()
                Else
                    Dim counter1 As Integer = Datab.CurrentRow.Index + 1
                    Dim nextRow1 As DataGridViewRow
                    If counter1 = Me.Datab.RowCount Then
                        Me.ASTRGA_ASTRDA()
                        Me.SAVERECORD()
                        nextRow1 = Datab.Rows(0)
                        Me.SEARCHDATAITEMS()
                        Me.Chern.Checked = False
                        Me.Timsum1.Stop()
                        MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
                    Else
                        nextRow1 = Datab.Rows(counter1)
                        Me.Datab_CellClick(sender, e)
                        nextRow1.Selected = True
                        Me.SEARCHDATAITEMS()
                        Me.ASTRGA_ASTRDA()
                        Me.SAVERECORD()
                    End If
                    Me.Datab.CurrentCell = nextRow1.Cells(0)
                    nextRow1.Selected = True
                    Me.Datab.Rows(counter1).Selected = True
                    Me.SEARCHDATAITEMS()
                End If
            End If
        ElseIf Me.RadiReplacingALL.Checked = True Then
            If Me.Chern.Checked = True Then
                Me.SEARCHDATAITEMS()
                Me.TextQUANTITY.Text = Format(Me.Datab.Item(4, Me.Datab.CurrentRow.Index).Value + Val(Me.TextQUANTITY.Text), "0.000")
                Me.Datab.Rows(0).Selected = True
                If Me.Datab.Rows.Count = 0 Then
                    Me.SEARCHDATAITEMS()
                Else
                    Dim counter1 As Integer = Me.Datab.CurrentRow.Index + 1
                    Dim nextRow1 As DataGridViewRow
                    If counter1 = Me.Datab.RowCount Then
                        Me.SAVERECORD2()
                        nextRow1 = Me.Datab.Rows(0)
                        Me.SEARCHDATAITEMS()
                        Me.Chern.Checked = False
                        Me.Timsum1.Stop()
                    Else
                        nextRow1 = Me.Datab.Rows(counter1)
                        Me.Datab_CellClick(sender, e)
                        nextRow1.Selected = True
                        Me.Datab_CellClick(sender, e)
                        Me.SEARCHDATAITEMS()
                        Me.SAVERECORD2()
                    End If
                    Me.Datab.CurrentCell = nextRow1.Cells(0)
                    nextRow1.Selected = True
                    Me.Datab.Rows(counter1).Selected = True
                    Me.SEARCHDATAITEMS()
                End If
            End If
        End If

    End Sub
    Private Sub Timsum_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timsum.Tick
        On Error Resume Next
        If Me.RadiRecoveryALL.Checked = True Then
            If Me.Ch3.Checked = True Then
                Me.SEARCHDATAITEMS()
                Me.Datab.Rows(0).Selected = True
                If Me.Datab.Rows.Count = 0 Then
                    Me.SEARCHDATAITEMS()
                Else
                    Dim counter1 As Integer = Me.Datab.CurrentRow.Index + 1
                    Dim nextRow1 As DataGridViewRow
                    If counter1 = Datab.RowCount Then
                        Me.UPDATERECORD()
                        nextRow1 = Datab.Rows(0)
                        Me.SEARCHDATAITEMS()
                        Me.Ch3.Checked = False
                        Me.Timsum.Stop()
                    Else
                        nextRow1 = Datab.Rows(counter1)
                        nextRow1.Selected = True
                        Me.SEARCHDATAITEMS()
                        Me.UPDATERECORD()
                    End If
                    Me.Datab.CurrentCell = nextRow1.Cells(0)
                    nextRow1.Selected = True
                    Me.Datab.Rows(counter1).Selected = True
                    Me.SEARCHDATAITEMS()
                    Me.UPDATERECORD()
                End If
            End If
        ElseIf Me.RadiReplacingALL.Checked = True Then
            If Me.Ch3.Checked = True Then
                Me.SEARCHDATAITEMS()
                Me.Datab.Rows(0).Selected = True
                If Me.Datab.Rows.Count = 0 Then
                    Me.SEARCHDATAITEMS()
                Else
                    Dim counter1 As Integer = Me.Datab.CurrentRow.Index + 1
                    Dim nextRow1 As DataGridViewRow
                    If counter1 = Datab.RowCount Then
                        Me.UPDATERECORD()
                        nextRow1 = Me.Datab.Rows(0)
                        Me.SEARCHDATAITEMS()
                        Me.Ch3.Checked = False
                        For Each t As Control In Gro2.Controls
                            If TypeOf t Is TextBox Then
                                t.Text = ""
                            End If
                        Next
                        Me.Timsum.Stop()
                    Else
                        nextRow1 = Me.Datab.Rows(counter1)
                        nextRow1.Selected = True
                        Me.SEARCHDATAITEMS()
                        Me.UPDATERECORD()
                    End If
                    Me.Datab.CurrentCell = nextRow1.Cells(0)
                    nextRow1.Selected = True
                    Me.Datab.Rows(counter1).Selected = True
                    Me.SEARCHDATAITEMS()
                    Me.UPDATERECORD()
                End If
            End If
        End If
    End Sub
    Private Sub Timsum2_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timsum2.Tick
        On Error Resume Next
        If Me.Ch2.Checked = True Then
            Me.SEARCHDATAITEMS()
            If Me.Datab.Rows.Count = 0 Then

            Else
                Dim counter As Integer = Datab.CurrentRow.Index + 1
                Dim nextRow As DataGridViewRow
                If counter = Datab.RowCount Then
                    nextRow = Datab.Rows(0)
                    Me.ASTRGA_ASTRDA()
                    Me.SAVERECORD()
                    Me.SEARCHDATAITEMS()
                    Me.Ch2.Checked = False
                    Me.Timsum2.Stop()
                Else
                    nextRow = Datab.Rows(counter)
                    nextRow.Selected = True
                    Me.SEARCHDATAITEMS()
                    Me.ASTRGA_ASTRDA()
                    Me.SAVERECORD()
                End If
                Datab.CurrentCell = nextRow.Cells(0)
                nextRow.Selected = True
                Me.Datab.Rows(counter).Selected = True
                Me.SEARCHDATAITEMS()
            End If
        End If
    End Sub
    Private Sub Form_ASTRJAA_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            Call MangUsers()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)
        If ComboStore.Items.Count > 0 Then
            Me.ComboStore.SelectedIndex = 0
        End If
    End Sub
    Private Sub Subtxtname_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtname.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                Me.CmdSearch_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CmdSearch.Click
        Try
            If Me.Datab.Rows.Count > 0 Then
                TaxBarCod = TexBAR.Text
                ItemName = TextItemName.Text
                GROUPNAME = TEXTGROUPNAME.Text
                MeasruingUnit = TextMeasruingUnit.Text
                QUANTITY = TextQUANTITY.Text
                UnitPrice = TextUnitPrice.Text
                Discount = TextDiscount.EditValue
                OrderLimit = TextOrderLimit.Text
                SellingPriceS = SellingPrice.Text
                DiscountPercentageWhenSelling = TextDiscountPercentageWhenSelling.Text
                LowestDiscountRateWhenSelling = TextLowestDiscountRateWhenSelling.Text
                HighestDiscountRateWhenSelling = TextHighestDiscountRateWhenSelling.Text
                CheckTax = Tax
                CheckTax1 = Tax1
                ProductionDate = TEXTProductionDate.Text
                ExpiryDate = TEXTExpiryDate.Text
                TotaiDiscount = Val(UnitPrice) * Val(Textadd.Text) * Val(Discount)
                TotaiPurchasingPrice = Val(UnitPrice) * Val(Textadd.Text) - Val(Discount)
            End If

            Dim Consum As New SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim cmdDX As New SqlCommand("", Consum)
            With cmdDX
                If FIFO = True Then
                    .CommandText = "SELECT * FROM FIFOStocks WHERE CUser ='" & CUser & "'  and WarehouseNumber ='" & Trim(Me.ComboStore.Text) & "' And STK25 Like'" & Trim(Me.txtname.Text) & "%'" & "or STK7 like'" & Trim(Me.txtname.Text) & "%'"
                ElseIf LIFO = True Then
                    .CommandText = "SELECT * FROM  LIFOStock WHERE CUser ='" & CUser & "' and WarehouseNumber ='" & Trim(Me.ComboStore.Text) & "' and STK25 like'" & Trim(Me.txtname.Text) & "%'" & "or STK7 like'" & Trim(Me.txtname.Text) & "%'"
                ElseIf AVG = True Then
                    .CommandText = "SELECT * FROM  AvgStocks WHERE  CUser ='" & CUser & "' and WarehouseNumber ='" & Trim(Me.ComboStore.Text) & "' and STK25 like'" & Trim(Me.txtname.Text) & "%'" & "or STK7 like'" & Trim(Me.txtname.Text) & "%'"
                End If
            End With
            Dim drDX As SqlDataReader = cmdDX.ExecuteReader
            If drDX.Read = True Then



                Me.TEXTGROUPNAME.Text = drDX.Item("STK8")
                Me.TexBAR.Text = drDX.Item("STK25")
                Me.TextItemName.Text = drDX.Item("STK7")
                Me.TextMeasruingUnit.Text = drDX.Item("SKITM6")
                Me.TextQUANTITY.Text = drDX.Item("LeftQty")
                Me.TextItemCount1.Text = drDX.Item("LeftQty")
                Me.TextUnitPrice.Text = drDX.Item("STK15")
                Me.TextDiscount.EditValue = drDX.Item("SKITM9")

                Me.TextOrderLimit.Text = drDX.Item("SKITM11")
                Me.SellingPrice.Text = drDX.Item("SKITM14")
                Me.TextDiscountPercentageWhenSelling.Text = drDX.Item("SKITM15")
                Me.TextLowestDiscountRateWhenSelling.Text = drDX.Item("SKITM16")
                Me.TextHighestDiscountRateWhenSelling.Text = drDX.Item("SKITM17")
                Me.Tax = drDX.Item("SKITM20")
                Me.Tax1 = drDX.Item("SKITM21")
                ChkPD = drDX.Item("ChkPD")
                Me.TEXTProductionDate.Text = drDX.Item("IT_DATEP")
                Me.TEXTExpiryDate.Text = drDX.Item("IT_DATEEX")
                Me.CheckPricesMentionedIncludeSalesTax.Checked = Tax.ToString
                Me.CheckItemIsSubjectToSalesTax.Checked = Tax1.ToString
                Consum.Close()
                cmdDX.Dispose()
            Else
                MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
                Exit Sub
            End If
            Dim sum As Double
            Dim sum1 As Double
            Dim A1 As Double = Me.SellingPrice.Text ' السعر
            Dim A2 As Double = Me.TextDiscountPercentageWhenSelling.Text ' الخصم
            Dim A3 As Double = Me.Textadd.Text ' العدد
            sum = Format(Val(Me.SellingPrice.Text) * Val(Me.Textadd.Text) * (100 - Val(A2)) / 100, "0.000")
            sum1 = Format(Val(A1 * A3) * Val(A2) / 100, "0.000")
            DiscountAA = Format(Val(SellingPriceS * Me.TextItemCount.Text) * Val(TEXTDiscountA.EditValue) / 100, "0.000")
            DiscountBB = Format(Val(UnitPrice * Me.TextItemCount.Text) * Val(TEXTDiscountB.EditValue) / 100, "0.000")
            If Me.Datab.Rows.Count > 0 Then
                If Me.Datab.CurrentCell.ColumnIndex = 0 Or 1 Or 2 Or 3 Or 4 Or 5 Or 6 Or 7 Or 8 Or 9 Or 10 Or 11 Or 12 Or 13 Or 14 Or 15 Or 16 Or 17 Or 18 Then
                    Me.Datab.CurrentRow.Cells(2).Value = Me.TexBAR.Text
                    Me.Datab.CurrentRow.Cells(3).Value = Me.TextItemName.Text
                    Me.Datab.CurrentRow.Cells(4).Value = Me.Textadd.Text
                    Me.Datab.CurrentRow.Cells(5).Value = Me.SellingPrice.Text
                    Me.Datab.CurrentRow.Cells(6).Value = Me.TextDiscountPercentageWhenSelling.Text
                    Me.Datab.CurrentRow.Cells(7).Value = sum.ToString("0.000")
                    Me.Datab.CurrentRow.Cells(8).Value = sum1.ToString("0.000")
                    Me.Datab.CurrentRow.Cells(9).Value = Me.TextItemCount1.Text
                    Me.Datab.CurrentRow.Cells(10).Value = Me.TextDiscount.EditValue
                    Me.Datab.CurrentRow.Cells(13).Value = Me.TextpaidUp.Text
                    Me.Datab.CurrentRow.Cells(14).Value = Me.TextTotai.Text
                    Me.Datab.CurrentRow.Cells(15).Value = Me.TextRest.Text
                    Me.Datab.CurrentRow.Cells(16).Value = Me.TextUnitPrice.Text
                End If
                Me.TextTotai.Text = Datab.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells(7).Value))
            Else
                MsgBox("لا يوجد اصناف لعرضها", 64 + 524288, "عرض الاصناف")
                Exit Sub
            End If

            ' حساب مجموع السلعة 
            Dim Total As Double
            Dim Tota2 As Double
            Dim Tota3 As Double
            Dim Tota4 As Double
            Dim Tota5 As Double
            For Each r As DataGridViewRow In Me.Datab.Rows
                Total += CDbl(r.Cells(4).Value) 'العدد
                Tota2 += CDbl(r.Cells(5).Value) 'السعر
                Tota3 += CDbl(r.Cells(6).Value) ' الخصم
                Tota4 += CDbl(r.Cells(7).Value) 'مجموع السعر
                Tota5 += CDbl(r.Cells(8).Value) 'مجموع الخصم
            Next
            Me.TextItemCount1.Text = Total.ToString("0.00")
            '--------------------------------------------
            If TextpaidUp.Text > 0 Then
                Dim S1 As Double = Me.TextpaidUp.Text ' المدفوع
                Dim S2 As Double = Me.TextTotai.Text ' الاجمالي
                Dim S3 As Double = Me.TEXTTotaiDiscount.Text ' الخصم
                Dim suming As Double
                suming = Format(Val(S1 - S2) + Val(S3), "0.000")
                Me.TextRest.Text = suming.ToString("0.000")
            End If
            If Me.TextRest.Text.Trim.Contains("-") Then
                Me.TextRest.Text = "0"
            End If
            If Me.TextTotai.Text.Trim = "0" Then
                Me.TextRest.Text = "0"
            End If
            If Me.TextpaidUp.Text = "0" Or Me.TextpaidUp.Text = "" Then
                Me.TextRest.Text = "0"
            End If
            SearchData_Chk = True
            'SEARCHDATAITEMS()
            If Me.RadiReplacing.Checked = True Then
                CmdSearch.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try

    End Sub
    Private Sub RadiReplacing_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadiReplacing.CheckedChanged
        Me.grpCat.Visible = True
        Me.Buadd.Enabled = True
        Me.Buadd.BackColor = Color.White
        Me.Busave.Enabled = False
        Me.Busave.BackColor = Color.Transparent
        Me.Button1.Enabled = False
        Me.Button1.BackColor = Color.Transparent
    End Sub
    Private Sub Cmdcancel_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdcancel.Click
        Me.grpCat.Visible = False
    End Sub
    Private Sub Chern_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles Chern.CheckedChanged
        On Error Resume Next
        If Me.Chern.Checked = True Then
            Me.Datab.Focus()
            Me.Timsum1.Start()
        ElseIf Chern.Checked = False Then
            Me.Timsum1.Stop()
        End If
    End Sub
    Private Sub Ch2_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles Ch2.CheckedChanged
        On Error Resume Next
        If Me.Ch2.Checked = True Then
            Me.Datab.Focus()
            Me.Timsum2.Start()
        ElseIf Me.Ch2.Checked = False Then
            Me.Timsum2.Stop()
        End If
    End Sub
    Private Sub Ch3_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles Ch3.CheckedChanged
        On Error Resume Next
        If Me.Ch3.Checked = True Then
            Me.Datab.Focus()
            Me.Timsum.Start()
        ElseIf Me.Ch3.Checked = False Then
            Me.Timsum.Stop()
        End If
    End Sub
    Private Sub Buadd_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Buadd.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If Me.Textadd.Text.Trim = "" Or Me.Textadd.Text.Trim = "0" Then
                MsgBox("كم عدد السلعة  ", MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
            If CDbl(Val(Me.Textadd.Text)) > CDbl(Val(Me.TextQUANTITY.Text)) Then
                MsgBox("لا يجب ان يكون العدد الفاتورة أكبر من رصيد المخزون ")
                Exit Sub
            End If
            Dim nextRow As DataGridViewRow
            nextRow = Me.Datab.Rows(0)
            Me.Datab.Rows(0).Selected = True
            Dim firstDate As String
            Dim secondDate As Date
            firstDate = Me.TEXTExpiryDate.Text.Trim
            secondDate = CDate(firstDate)

            If ItemsExpirationDate = True Then
                If ChkPD = True Then
                    If ServerDateTime.ToString("yyyy-MM-dd") >= secondDate Then
                        MsgBox("إنتهاء صالحية السلعة  ", MsgBoxStyle.Critical, "تنبيه")
                        Exit Sub
                    End If
                End If
            End If
            SearchData_Chk = False
            Dim Consum As New SqlConnection(constring)
            If Me.RadiReplacing.Checked = True Then
                Try
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    Dim cmdW As New SqlCommand(" Select NumFatorh12 From ASTRGA_ASTRDA Where NumFatorh12 = '" & Me.TEXTInvoiceNumber.Text.Trim & "'and Noaamlea13 ='" & "مسترجع" & "'  and CUser='" & CUser & "'", Consum)
                    Dim drW As SqlDataReader = cmdW.ExecuteReader()
                    If drW.Read Then
                        MsgBox(" الفاتورة تم استرجاعها مسبقاً", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    cmdW.Dispose()
                    drW.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
                End Try
                Me.ASTRGA_ASTRDA()
                Me.SAVERECORD1()
                SearchData_Chk = False
                SEARCHDATAITEMS()
            ElseIf Me.RadiReplacingALL.Checked = True Then
                'If Datab.SelectedRows.Count = 0 Then Return
                'Datab.FirstDisplayedScrollingRowIndex = Datab.SelectedRows(0).Index

                Try
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    Dim cmdW As New SqlCommand(" Select NumFatorh12 From ASTRGA_ASTRDA Where NumFatorh12 = '" & Me.TEXTInvoiceNumber.Text.Trim & "'and Noaamlea13 ='" & "مسترجع" & "'  and CUser='" & CUser & "'", Consum)
                    Dim drW As SqlDataReader = cmdW.ExecuteReader()
                    If drW.Read Then
                        MsgBox(" الفاتورة تم استرجاعها مسبقاً", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    cmdW.Dispose()
                    drW.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
                End Try

                nextRow = Me.Datab.Rows(0)
                Me.Datab.Rows(0).Selected = True
                Me.Ch2.Checked = True
            End If
            Me.Buadd.Enabled = False
            Me.Buadd.BackColor = Color.Transparent
            Me.Button1.Enabled = True
            Me.Button1.BackColor = Color.White
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button1.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.SellingPrice.Text.Trim = "" And Me.SellingPrice.Text.Trim = "0" Then
            MsgBox("سعر الصنف غير موجود ", MsgBoxStyle.Critical, "تنبيه")
            Exit Sub
        End If
        If Me.Textadd.Text.Trim = "" Or Me.Textadd.Text.Trim = "0" Then
            MsgBox("كم عدد الصنف  ", MsgBoxStyle.Critical, "تنبيه")
            Exit Sub
        End If
        If CDbl(Val(Me.Textadd.Text)) > CDbl(Val(Me.TextQUANTITY.Text)) Then
            MsgBox("لا يجب ان يكون العدد الفاتورة أكبر من رصيد المخزون ")
            Exit Sub
        End If
        Dim firstDate As String, days As Integer
        Dim secondDate As Date
        firstDate = Me.TEXTExpiryDate.Text.Trim
        secondDate = CDate(firstDate)
        If ItemsExpirationDate = True Then
            If ChkPD = True Then
                If ServerDateTime.ToString("yyyy-MM-dd") >= secondDate Then
                    MsgBox("إنتهاء صالحية السلعة  ", MsgBoxStyle.Critical, "تنبيه")
                    Exit Sub
                End If
            End If

        End If

        If Me.RadiReplacing.Checked = True Then
            Me.UPDATERECORD()
        ElseIf Me.RadiReplacingALL.Checked = True Then
            Dim nextRow As DataGridViewRow
            nextRow = Datab.Rows(0)
            Me.Ch3.Checked = True
        End If
        Me.Button1.Enabled = False
        Me.Button1.BackColor = Color.Transparent
        Me.Busave.Enabled = True
        Me.Busave.BackColor = Color.White
    End Sub
    Private Sub Radi1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadiRecovery.CheckedChanged
        Me.Busave.Enabled = True
        Me.Busave.BackColor = Color.White

        Me.Buadd.Enabled = False
        Me.Buadd.BackColor = Color.Transparent
        Me.Button1.Enabled = False
        Me.Button1.BackColor = Color.Transparent
    End Sub
    Private Sub Radi2_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadiRecoveryALL.CheckedChanged
        Me.Busave.Enabled = True
        Me.Busave.BackColor = Color.White

        Me.Buadd.Enabled = False
        Me.Buadd.BackColor = Color.Transparent
        Me.Button1.Enabled = False
        Me.Button1.BackColor = Color.Transparent
    End Sub
    Private Sub Radi4_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadiReplacingALL.CheckedChanged, RadiReplacingALL.CheckedChanged
        Me.Buadd.Enabled = True
        Me.Buadd.BackColor = Color.White

        Me.Busave.Enabled = False
        Me.Busave.BackColor = Color.Transparent
        Me.Button1.Enabled = False
        Me.Button1.BackColor = Color.Transparent
    End Sub

    Private Sub ComboStore_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboStore.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT WarehouseName  FROM Warehouses WHERE WarehouseNumber ='" & Me.ComboStore.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Store = Me.ComboStore.Text
            Me.TextWarehouseName.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextWarehouseName.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub


End Class