Option Explicit Off
Imports System.Data.SqlClient
Public Class FrmBilltransfer
<<<<<<< HEAD
    Inherits Form
    Public WithEvents BS As New BindingSource
    ReadOnly ds As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter
=======
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    ReadOnly ds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker

    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim TypeCustomer As String


<<<<<<< HEAD
    Private Sub FrmTRANSPORT_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmTRANSPORT_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub FrmTRANSPORT_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmTRANSPORT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.ADDBUTTON_Click(sender, e)
                Case Keys.F2
                    SAVEBUTTON_Click(sender, e)
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
    End Sub
<<<<<<< HEAD
    Private Sub FrmBilltransfer_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmBilltransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            Me.SHOWBUTTON()
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)
            Me.FundBalance()
            Call Me.AddType1()
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False

            ItWillBeAnAccountingEntryWhenAdding_Check = keyAccounts.GetValue("ItWillBeAnAccountingEntryWhenAdding_Check", ItWillBeAnAccountingEntryWhenAdding_Check)

            TestkeyAccounts(keyAccounts.GetValue("TransferAccount_No", TransferAccount_No))
            If TestkeyAccounts_Check = True Then
                AccountNoAktevd = keyAccounts.GetValue("TransferAccount_No", TransferAccount_No)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT IDcust, cust22 FROM AllCustomers WHERE cust2 ='" & Me.ComboCustomerName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT IDcust, cust22 FROM AllCustomers WHERE cust2 ='" & Me.ComboCustomerName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        Adp.Fill(ds, "AllCustomers")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextCustomerNumber.EditValue = ds.Tables(0).Rows(0).Item(0)
            TypeCustomer = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TextCustomerNumber.EditValue = ""
            TypeCustomer = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:
            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.Update(ds, "PETRO")
            'ds = New DataSet
            'SqlDataAdapter1.Fill(ds, "PETRO")
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
                DelRow = True
                Me.PictureBox2False()
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
            Else
                e.Cancel = True
                Me.PictureBox2False()
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then

                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = Me.ds.Tables("PETRO")
            Me.TEXTID.Enabled = True
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False

            If Me.BS.Count < RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf BS.Count > RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & BS.Count - RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
            If Consum.State = ConnectionState.Open Then Consum.Close()
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.save
=======
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
            Consum.Close()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Private Sub SAVERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)

            Dim sql As String = "INSERT INTO PETRO(PTRO1, PTRO2, PTRO3, PTRO4, PTRO5, PTRO6, PTRO7, PTRO8, PTRO9, PTRO10, PTRO11, PTRO12, PTRO13, PTRO14, PTRO15, PTRO16, PTRO17, PTRO18, PTRO19, PTRO20, PTRO21, PTRO22, PTRO23, PTRO24, PTRO25, PTRO26, PTRO27, PTRO28, PTRO29, PTRO30, PTRO31, CB1, BN2,WarehouseNumber, WarehouseName, USERNAME, Cuser, COUSER, da, ne) VALUES  (@PTRO1, @PTRO2, @PTRO3, @PTRO4, @PTRO5, @PTRO6, @PTRO7, @PTRO8, @PTRO9, @PTRO10, @PTRO11, @PTRO12, @PTRO13, @PTRO14, @PTRO15, @PTRO16, @PTRO17, @PTRO18, @PTRO19, @PTRO20, @PTRO21, @PTRO22, @PTRO23, @PTRO24, @PTRO25, @PTRO26, @PTRO27, @PTRO28, @PTRO29, @PTRO30, @PTRO31, @CB1, @BN2,@WarehouseNumber, @WarehouseName, @USERNAME, @Cuser, @COUSER, @da, @ne)"
            Dim cmd As New SqlCommand(sql, Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)

            Dim sql As String = "INSERT INTO PETRO(PTRO1, PTRO2, PTRO3, PTRO4, PTRO5, PTRO6, PTRO7, PTRO8, PTRO9, PTRO10, PTRO11, PTRO12, PTRO13, PTRO14, PTRO15, PTRO16, PTRO17, PTRO18, PTRO19, PTRO20, PTRO21, PTRO22, PTRO23, PTRO24, PTRO25, PTRO26, PTRO27, PTRO28, PTRO29, PTRO30, PTRO31, CB1, BN2,WarehouseNumber, WarehouseName, USERNAME, Cuser, COUSER, da, ne) VALUES  (@PTRO1, @PTRO2, @PTRO3, @PTRO4, @PTRO5, @PTRO6, @PTRO7, @PTRO8, @PTRO9, @PTRO10, @PTRO11, @PTRO12, @PTRO13, @PTRO14, @PTRO15, @PTRO16, @PTRO17, @PTRO18, @PTRO19, @PTRO20, @PTRO21, @PTRO22, @PTRO23, @PTRO24, @PTRO25, @PTRO26, @PTRO27, @PTRO28, @PTRO29, @PTRO30, @PTRO31, @CB1, @BN2,@WarehouseNumber, @WarehouseName, @USERNAME, @Cuser, @COUSER, @da, @ne)"
            Dim cmd As New SqlClient.SqlCommand(sql, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@PTRO1", SqlDbType.BigInt).Value = TEXTID.EditValue
                .Parameters.Add("@PTRO2", SqlDbType.Int).Value = Me.TEXTCarNumbers.Text
                .Parameters.Add("@PTRO3", SqlDbType.Money).Value = Me.TEXTQuantity.EditValue
                .Parameters.Add("@PTRO4", SqlDbType.NVarChar).Value = Me.TEXTLetteringQuantity.Text
                .Parameters.Add("@PTRO5", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@PTRO6", SqlDbType.NVarChar).Value = Me.TEXTUnitPrice.EditValue
                .Parameters.Add("@PTRO7", SqlDbType.NVarChar).Value = Me.TEXTTotalValue.Text
                .Parameters.Add("@PTRO8", SqlDbType.NVarChar).Value = Me.TEXTTaxRate.Text
                .Parameters.Add("@PTRO9", SqlDbType.NVarChar).Value = Me.ComboITEMNAME.Text
                .Parameters.Add("@PTRO10", SqlDbType.NVarChar).Value = "م . نقل"
                .Parameters.Add("@PTRO11", SqlDbType.NVarChar).Value = Me.TEXTNetValue.Text
                .Parameters.Add("@PTRO12", SqlDbType.NVarChar).Value = Me.TEXTLoadingExpenses.EditValue
                .Parameters.Add("@PTRO13", SqlDbType.NVarChar).Value = Me.TEXTTransfers.EditValue
                .Parameters.Add("@PTRO14", SqlDbType.NVarChar).Value = Me.TEXTTotal.Text
                .Parameters.Add("@PTRO15", SqlDbType.Bit).Value = Convert.ToInt32(TransferToAccounts_Check)
                .Parameters.Add("@PTRO16", SqlDbType.Bit).Value = False
                .Parameters.Add("@PTRO17", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@PTRO18", SqlDbType.NVarChar).Value = Me.TEXTTotalN.Text
                .Parameters.Add("@PTRO19", SqlDbType.NVarChar).Value = Me.TextTaxes.EditValue
                .Parameters.Add("@PTRO20", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text
                .Parameters.Add("@PTRO21", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
                .Parameters.Add("@PTRO22", SqlDbType.Bit).Value = False
                .Parameters.Add("@PTRO23", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@PTRO24", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@PTRO25", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@PTRO26", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@PTRO27", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@PTRO28", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@PTRO29", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@PTRO30", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text


                .Parameters.Add("@PTRO31", SqlDbType.Bit).Value = False

                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text
                .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Me.ComboStore.Text
                .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text

                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = sql
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If


            Me.BS.Position = Me.BS.Count - 1
            s = Val(Me.TEXTID.EditValue)
            Application.DoEvents()
            Me.BS.EndEdit()
            Me.BS.AddNew()
            CLEARDATA1(Me)

            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            If ComboBN2.Items.Count > 0 Then
                Me.ComboBN2.SelectedIndex = 0
            End If
            GetAutoNumber("PTRO1", "PETRO", "PTRO5")
            Me.TEXTID.EditValue = AutoNumber
            Me.TextMovementSymbol.EditValue = "BT" & Me.TEXTID.EditValue
            Me.TEXTCarNumbers.Text = 1
            Me.TEXTLoadingExpenses.EditValue = 0
            Me.TEXTTransfers.EditValue = 0
            Me.TextValueOfCheck.EditValue = 0
            Me.TextFundValue.EditValue = 0
            Me.TextTaxes.EditValue = Val(2 / 100)
            Me.TextCustomerNumber.EditValue = "0"
            Me.DateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
            Me.TextDateMovementHistory.Text = Me.DateMovementHistory.Text

            FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)
            FILLCOMBOBOX3("STOCKS", "STK7", "CUser", CUser, "WarehouseNumber", ComboStore.Text, Me.ComboITEMNAME)


            If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
                TransferToAccounts_Check = True
            Else
                TransferToAccounts_Check = False
            End If

            Me.ComboITEMNAME.Text = "PVC RESIN"
            Me.TEXTCarNumbers.Focus()
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
<<<<<<< HEAD
        Dim Sound As IO.Stream = My.Resources.addv
        My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
=======
        Dim Sound As System.IO.Stream = My.Resources.addv
        My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If Year(Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")) > FiscalYear_currentDateMustBeInFiscalYear() Then
                MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
                Exit Sub
            End If
            If Val(Me.TEXTTotal.Text) <> (Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue)) Then
                MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك مساوي الى اجمالي الفاتورة", 16, "تنبيه")
                Exit Sub
            End If
            Dim ch As Double
            Dim ch1 As Double
            ch = Format(Val(Me.TEXTTotal.Text), "0.000")
            ch1 = Format(Val(Me.TextFundBalance.Text), "0.000")
            If ch1 < ch Then
                MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                Exit Sub
            End If
            If Me.ComboPaymentMethod.Text = "شيك" Then
                If Me.ComboCheckDrawerName.Text = "" Then
                    MsgBox("يجب إدخال اسم ساحب الشيك", 16, "تنبيه")
                    Me.ComboCheckDrawerName.Focus()
                    Exit Sub
                End If
                If Me.TextCheckNumber.Text = "" Then
                    MsgBox("يجب إدخال رقم الشيك", 16, "تنبيه")
                    Me.TextCheckNumber.Focus()
                    Exit Sub
                End If
                If Me.CheckDate.Value = Nothing Then
                    MsgBox("يجب إدخال تاريخ الشيك", 16, "تنبيه")
                    Me.CheckDate.Focus()
                    Exit Sub
                End If
            ElseIf Me.ComboPaymentMethod.Text = "شيك و نقدا" Then
                If Me.ComboCheckDrawerName.Text = "" Then
                    MsgBox("يجب إدخال اسم ساحب الشيك", 16, "تنبيه")
                    Me.ComboCheckDrawerName.Focus()
                    Exit Sub
                End If
                If Me.TextCheckNumber.Text = "" Then
                    MsgBox("يجب إدخال رقم الشيك", 16, "تنبيه")
                    Me.TextCheckNumber.Focus()
                    Exit Sub
                End If
                If Me.CheckDate.Value = Nothing Then
                    MsgBox("يجب إدخال تاريخ الشيك", 16, "تنبيه")
                    Me.CheckDate.Focus()
                    Exit Sub
                End If
            End If
            GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
            If ExitSub_Check = True Then
                FrmOPTIONS.ShowDialog()
                Exit Sub
            End If


            Static P As Integer
            P = Me.BS.Count
            Me.TextMovementSymbol.EditValue = "BT" & Me.TEXTID.EditValue

            Me.TEXTBOX3_TextChanged(sender, e)
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.SAVERECORD()
            Me.BS.EndEdit()
            Me.RowCount = BS.Count

            If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
                TransferToAccounts_Check = True
                TransforAccounts()
            Else
                TransferToAccounts_Check = False
            End If

<<<<<<< HEAD
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.BS.Position = P + 1
            Me.SHOWBUTTON()
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            Insert_Actions(Me.TEXTID.EditValue, "حفظ", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX3_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTQuantity.EditValueChanged
        On Error Resume Next
        Me.TEXTLetteringQuantity.Text = CurrencyJO(Me.TEXTQuantity.EditValue, "WEIGHT")
    End Sub
    Private Sub TEXTBOX2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTNetValue.TextChanged, TEXTTotalN.TextChanged, TEXTTotalValue.TextChanged, TEXTTaxRate.TextChanged, TextTaxes.EditValueChanged, TEXTLoadingExpenses.EditValueChanged, TEXTTransfers.EditValueChanged
=======
    Private Sub TEXTBOX3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTQuantity.EditValueChanged
        On Error Resume Next
        Me.TEXTLetteringQuantity.Text = CurrencyJO(Me.TEXTQuantity.EditValue, "WEIGHT")
    End Sub
    Private Sub TEXTBOX2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTNetValue.TextChanged, TEXTTotalN.TextChanged, TEXTTotalValue.TextChanged, TEXTTaxRate.TextChanged, TextTaxes.EditValueChanged, TEXTLoadingExpenses.EditValueChanged, TEXTTransfers.EditValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.TEXTTotalValue.Text = Format(Val(TEXTQuantity.EditValue) * Val(TEXTUnitPrice.EditValue), "0.000")
        Me.TEXTTaxRate.Text = Format(Val(TEXTTotalValue.Text) * Val(TextTaxes.EditValue), "0.000")
        Me.TEXTNetValue.Text = Format(Val(TEXTTotalValue.Text) - Val(TEXTTaxRate.Text), "0.000")
        Me.TEXTTotal.Text = Format(Val(TEXTTaxRate.Text) + Val(TEXTLoadingExpenses.EditValue) + Val(TEXTTransfers.EditValue), "0.000")
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
    End Sub
    Private Sub TEXTUnitPrice_LostFocus(sender As Object, e As EventArgs) Handles TEXTUnitPrice.LostFocus
        TEXTBOX2_TextChanged(sender, e)
    End Sub

    Private Sub TransforAccounts()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        nem = " فاتورة نقل رقم" & " " & Me.TEXTID.EditValue
        nem1 = "صرف فاتورة نقل رقم" & " " & Me.TEXTID.EditValue
        nem2 = " فاتورة نقل بيموجب مستند رقم" & " " & Me.TextCheckNumber.Text
        PMO2 = 1

        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_no = FundAccount_No
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
        CodAccount = ID_Nam
        SEARCHDATA.MAXIDMOVES()
        TransferToAccounts_Check = True

        AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TEXTTotal.Text, TEXTTotal.Text, T3, "قيد", "TL", TextMovementSymbol.EditValue, False)
        If OBCHK6 = True Then
            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotal.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
            DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_no, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        Else
            Select Case Me.ComboPaymentMethod.Text
                Case "نقدا"
                    DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotal.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_no, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTID.EditValue & "0",
                                                                False, True, ComboCB1.Text, CB2)
                Case "شيك"
                    DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotal.Text, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ChecksAccount_Name, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                              TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                Case "نقدا_شيك"
                    DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotal.Text, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_no, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 2, ChecksAccount_Name, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTID.EditValue & "0",
                                                                False, True, ComboCB1.Text, CB2)

                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                               TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)


            End Select

        End If

    End Sub
    Private Sub TextFundValue_EditValueChanged(sender As Object, e As EventArgs) Handles TextFundValue.EditValueChanged, TextValueOfCheck.EditValueChanged
        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"
                TextFundValue.EditValue = Val(TEXTTotal.Text)
                TextValueOfCheck.EditValue = 0
            Case "شيك"
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text)
            Case "نقدا_شيك"
                TextFundValue.EditValue = Val(TEXTTotal.Text) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text) - Val(TextFundValue.EditValue)
        End Select
    End Sub

    Private Sub  AccountsEnquiry()
        On Error Resume Next
        DebitAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing
        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_no = FundAccount_No
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)

        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"
                Me.TextValueOfCheck.Enabled = False
                Me.TextFundValue.Enabled = True
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                TextFundValue.EditValue = Val(TEXTTotal.Text)
                TextValueOfCheck.EditValue = 0
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
            Case "شيك"
                Me.TextFundValue.EditValue = 0
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.Enabled = False
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text)
            Case "نقدا_شيك"
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = Val(TEXTTotal.Text) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text) - Val(TextFundValue.EditValue)
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox17_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
=======
    Private Sub ComboBox17_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
         AccountsEnquiry()

    End Sub
    Private Sub FundBalance()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox16_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
            If RadioAllCustomers.Checked = True Then
                Dim Adp As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust22,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBox16_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If RadioAllCustomers.Checked = True Then
                Dim Adp As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust22,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds.Clear()
                Adp.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds.Tables(0).Rows(0).Item(0)
                    TypeCustomer = ds.Tables(0).Rows(0).Item(1)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                    TypeCustomer = ""
                End If
                Adp.Dispose()
                Consum.Close()
            ElseIf RadioSUPPLIER.Checked = True Then
<<<<<<< HEAD
                Dim Adp1 As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds1 As New DataSet
                Adp1 = New SqlDataAdapter(strsql)
=======
                Dim Adp1 As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds1 As New DataSet
                Adp1 = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds1.Clear()
                Adp1.Fill(ds1)
                If ds1.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds1.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                End If
                Adp1.Dispose()
                Consum.Close()
            ElseIf RadioEMPLOYEES.Checked = True Then
<<<<<<< HEAD
                Dim Adp2 As SqlDataAdapter
                Dim strsq2 As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds2 As New DataSet
                Adp2 = New SqlDataAdapter(strsq2)
=======
                Dim Adp2 As SqlClient.SqlDataAdapter
                Dim strsq2 As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds2 As New DataSet
                Adp2 = New SqlClient.SqlDataAdapter(strsq2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds2.Clear()
                Adp2.Fill(ds2)
                If ds2.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds2.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                End If
                Adp2.Dispose()
                Consum.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboCheckDrawerName", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioResetText.CheckedChanged
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Call Me.AddType1()
    End Sub
    Private Sub AddType1()
        On Error Resume Next
        If RadioAllCustomers.Checked = True Then
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioSUPPLIER.Checked = True Then
            FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioEMPLOYEES.Checked = True Then
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboCheckDrawerName)
        Else
            Me.ComboCheckDrawerName.ResetText()
        End If
        Me.ComboCheckDrawerName.Focus()
    End Sub




<<<<<<< HEAD
    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCB1.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCB1.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            CB2 = ds.Tables(0).Rows(0).Item(0)
        Else
            CB2 = ""
        End If
        Adp.Dispose()
        Consum.Close()
         AccountsEnquiry()
        FundBalance()
    End Sub

<<<<<<< HEAD
    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBN2.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT BN3,BN4    FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBN2.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT BN3,BN4    FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextBN3.Text = ds.Tables(0).Rows(0).Item(0)
            BN4 = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TextBN3.Text = ""
            BN4 = ""
        End If
        Adp.Dispose()
        Consum.Close()
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

        FILLCOMBOBOX3("STOCKS", "STK7", "CUser", CUser, "WarehouseNumber", ComboStore.Text, Me.ComboITEMNAME)
    End Sub

    Private Sub TEXTStatement_TextChanged(sender As Object, e As EventArgs) Handles TEXTStatement.TextChanged

    End Sub

    Private Sub TEXTCarNumbers_EditValueChanged(sender As Object, e As EventArgs) Handles TEXTCarNumbers.EditValueChanged

    End Sub

    Private Sub DateMovementHistory_ValueChanged(sender As Object, e As EventArgs) Handles DateMovementHistory.ValueChanged

    End Sub

    Private Sub TextDateMovementHistory_TextChanged(sender As Object, e As EventArgs) Handles TextDateMovementHistory.TextChanged

    End Sub
End Class