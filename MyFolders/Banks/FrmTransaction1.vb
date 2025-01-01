Option Explicit Off

Imports System.Data.SqlClient
Public Class FrmTransaction1
    Inherits Form
    Public WithEvents BS As New BindingSource
    ReadOnly myds As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim Deposit As Boolean = False


    Private Sub FrmTransaction1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub
    Private Sub FrmTransaction1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles Me.Load
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Me.SHOWBUTTON()
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            FILLCOMBOBOX1("Deposits", "TBNK6", "CUser", CUser, Me.ComboAccountNumber)
            'FILLCOMBOBOX1("PTRANSACTION", "TBNK8", "CUser", CUser, Me.ComboAccountType)
            Me.FundBalance()

            ItWillBeAnAccountingEntryWhenAdding_Check = keyAccounts.GetValue("ItWillBeAnAccountingEntryWhenAdding_Check", ItWillBeAnAccountingEntryWhenAdding_Check)
            TestkeyAccounts(keyAccounts.GetValue("StockAccount_No", StockAccount_No))
            If TestkeyAccounts_Check = True Then
                AccountNoAktevd = keyAccounts.GetValue("StockAccount_No", StockAccount_No)
            End If
            SetUpComboBox(ComboAccountType)
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboAccountType.Text, 1)
            AccountNoAktevd = ID_Nam
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
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

            Me.BS.Position = BS.Count - 1

            Me.FundBalance()
            Me.BS.EndEdit()
            Me.BS.AddNew()
            CLEARDATA1(Me)

            GetAutoNumber("TBNK1", "PTRANSACTION", "TBNK3")
            Me.TEXTID.EditValue = AutoNumber

            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            If ComboBN2.Items.Count > 0 Then
                Me.ComboBN2.SelectedIndex = 0
            End If
            Me.TextMovementSymbol.EditValue = "WD" & Me.TEXTID.EditValue
            Me.TEXTDebit.Text = "0.000"
            Me.TEXTCredit.Text = "0.000"
            Me.TextValueOfCheck.EditValue = "0.000"
            Me.TextFundValue.EditValue = "0.000"
            Me.ComboConstraintType.Text = "ايداع"
            Me.ComboAccountType.Text = "امانات"
            Me.TEXTDocumentNumber.Text = 0
            Me.TEXTStatement.Text = "ايداع"
            Me.DateMovementHistory.Value = MaxDate.ToString("yyyy-MM-dd")
            Me.TextDateMovementHistory.Text = Me.DateMovementHistory.Text
            Me.DateMovementHistory.Focus()
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
                TransferToAccounts_Check = True
            Else
                TransferToAccounts_Check = False
            End If
            Dim Sound As IO.Stream = My.Resources.addv
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
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
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Finally
            Consum.Close()
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            Application.DoEvents()
            'BS.DataSource = myds.Tables("PTRANSACTION")
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            If Me.BS.Count < RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & BS.Count - RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")

                Exit Sub
            End If
            Dim Sound As IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            If Click1 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "حفظ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            End If
            Click1 = False
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error6", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    Private Sub FundBalance()
        On Error Resume Next
        Dim N As Double
        Dim Consum As New SqlConnection(constring)
        Dim cmd1 As New SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()

        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
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
        Dim ch As Double
        Dim ch1 As Double
        ch = Me.TEXTDebit.Text
        ch1 = Me.TextFundBalance.Text

        If String.IsNullOrEmpty(Me.TextMembersCode.EditValue) Or MyTextNull(Me.TextMembersName, "اسم المستخدم") = True Then
            'MsgBox("يجب إدخال رقم و اسم العضو من خلال رقم و نوع الحساب", 16, "تنبيه")
            Me.ComboAccountNumber.Focus()
            Exit Sub
        End If

        If MyCompTextEmpte(ComboPaymentMethod1, " إدخال طريقة الدفع") Then
            'MsgBox("يجب إدخال طريقة الدفع", 16, "تنبيه")
            Me.ComboPaymentMethod1.Focus()
            Exit Sub
        End If


        If Me.ComboPaymentMethod1.Text = "شيك" Then
            If MyCompTextEmpte(ComboCheckDrawerName, " إدخال طريقة الدفع") Then
                Me.ComboCheckDrawerName.Focus()
                Exit Sub
            End If
            If MyTextNull(Me.TextMembersName, "إدخال رقم الشيك") = True Then
                Me.TextCheckNumber.Focus()
                Exit Sub
            End If
            If Me.CheckDate.Value = Nothing Then
                MsgBox("يجب إدخال تاريخ الشيك", 16, "تنبيه")
                Me.CheckDate.Focus()
                Exit Sub
            End If
        ElseIf Me.ComboPaymentMethod1.Text = "شيك و نقدا" Then
            If Me.ComboCheckDrawerName.Text = "" Then
                MsgBox("يجب إدخال اسم ساحب الشيك", 16, "تنبيه")
                Me.ComboCheckDrawerName.Focus()
                Exit Sub
            End If
            If MyTextNull(Me.TextMembersName, "إدخال رقم الشيك") = True Then
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


        Select Case Me.ComboConstraintType.Text
            Case "ايداع"
                ch = "0.000"
                ch1 = "0.000"
                Dim x As Double = Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTCredit.Text)
                'If Me.TEXTBOX8.Text = "الاسهم" And Val(x) > Val(BANSL) Then
                '    MessageBox.Show("لا يمكن ان تكون قيمة اسهم العضو اكبر من قيمة اسهم الجمعة المكتتبة:" & ControlChars.CrLf & _
                '                   "1) اسهم الجمعة المكتتبة = " & "(" & Val(BANSL) & ")" & " " & "دينار اردني" & ControlChars.CrLf & _
                '                   "2) يمكن ان تغير نوع الحساب ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Exit Sub
                'End If
            Case "سحب"
                If Val(Me.TEXTDebit.Text) <> (Val(Me.TextValueOfCheck.EditValue) + Val(Me.TextFundValue.EditValue)) Then
                    MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك مساوي الى اجمالي الفاتورة", 16, "تنبيه")
                    Exit Sub
                End If
                If ch1 < ch Then
                    MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                    Exit Sub
                End If
        End Select

        Static P As Integer
        P = Me.BS.Count
        Me.SEARCHDATAITEMS10()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SAVERECORD()
        If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
            TransferToAccounts_Check = True
            TransforAccounts()
        Else
            TransferToAccounts_Check = False
        End If

        Me.SaveTab = New ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        Click1 = True
    End Sub

    Private Sub SEARCHDATAITEMS10()
        Dim Consum As New SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT TBNK20, TBNK21 FROM Deposits WHERE TBNK6 = '" & Me.ComboAccountNumber.Text & " '", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql2)
        On Error Resume Next
        ds2.Clear()
        Consum.Open()
        Adp1.Fill(ds2, "DISTINCT")
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.TextMembersName.Text = ds2.Tables(0).Rows(0).Item(0)
            Me.TextMembersCode.EditValue = ds2.Tables(0).Rows(0).Item(1)
        Else
            Me.TextMembersName.Text = ""
            Me.TextMembersCode.EditValue = ""

        End If
        Consum.Close()
    End Sub
    Private Sub InternalAuditorBalance()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim strsq1 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION  WHERE (PTRANSACTION.TBNK6)='" & Me.ComboAccountNumber.Text.Trim & "' AND (PTRANSACTION.TBNK8)='" & Me.ComboAccountType.Text.Trim & "'AND PTRANSACTION.TBNK1 <'" & Me.TEXTID.EditValue & "'", Consum)
            Dim ds As New DataSet
            Dim Adp1 As New SqlDataAdapter(strsq1)
            ds.Clear()
            Adp1.Fill(ds, "PTRANSACTION")
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TEXTPreviousBalance.Text = Format(Val(ds.Tables(0).Rows(0).Item(1)) - Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                Me.TEXTPreviousBalance.Text = "0.000"
            End If
            Adp1.Dispose()
            If Consum.State = ConnectionState.Open Then Consum.Close()
        Catch ex As Exception
            Me.TEXTPreviousBalance.Text = "0.000"
        End Try
    End Sub

    Private Sub SAVERECORD()
        Try
            Dim Consum As New SqlConnection(constring)
            GetAutoNumber("TBNK1", "PTRANSACTION", "TBNK3")
            Dim SQL As String = "INSERT INTO PTRANSACTION( TBNK1,  TBNK2, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK19, TBNK20, TBNK21, TBNK22, TBNK23, TBNK24, CB1, BN2, USERNAME, CUser, COUser, da, ne) VALUES     (@TBNK1, @TBNK2, @TBNK3, @TBNK4, @TBNK5, @TBNK6, @TBNK7, @TBNK8, @TBNK9, @TBNK10, @TBNK11, @TBNK12, @TBNK13, @TBNK14, @TBNK15, @TBNK16, @TBNK17, @TBNK18, @TBNK19, @TBNK20, @TBNK21, @TBNK22, @TBNK23, @TBNK24, @CB1, @BN2, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlCommand(SQL, Consum)
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@TBNK1", SqlDbType.BigInt).Value = TEXTID.EditValue
                .Parameters.Add("@TBNK2", SqlDbType.NVarChar).Value = Format(Val(SumAmounTOTALCASHANDCHEQUES2(Me.ComboAccountNumber.Text, Me.ComboAccountType.Text, AutoNumber)), "0.000")
                .Parameters.Add("@TBNK3", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@TBNK4", SqlDbType.NVarChar).Value = Me.TEXTDebit.Text
                .Parameters.Add("@TBNK5", SqlDbType.NVarChar).Value = Me.TEXTCredit.Text
                .Parameters.Add("@TBNK6", SqlDbType.NVarChar).Value = Me.ComboAccountNumber.Text
                .Parameters.Add("@TBNK7", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text
                .Parameters.Add("@TBNK8", SqlDbType.NVarChar).Value = Me.ComboAccountType.Text
                .Parameters.Add("@TBNK9", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@TBNK10", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@TBNK11", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@TBNK12", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@TBNK13", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@TBNK14", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod1.Text
                .Parameters.Add("@TBNK15", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@TBNK16", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@TBNK17", SqlDbType.NVarChar).Value = Convert.ToInt32(TransferToAccounts_Check)
                .Parameters.Add("@TBNK18", SqlDbType.NVarChar).Value = Me.ComboConstraintType.Text
                .Parameters.Add("@TBNK19", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@TBNK20", SqlDbType.Date).Value = Me.CheckDate.Value.ToString

                .Parameters.Add("@TBNK21", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@TBNK22", SqlDbType.NVarChar).Value = Me.TextMembersName.Text
                .Parameters.Add("@TBNK23", SqlDbType.NVarChar).Value = Me.TextMembersCode.EditValue
                .Parameters.Add("@TBNK24", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text

                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text

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
            MessageBox.Show(ex.Message, "ErrorSAVERECORD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TEXTBOX5_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTCredit.DoubleClick
        On Error Resume Next
        Me.TEXTCredit.Text = Calculator()
    End Sub
    Private Sub TEXTBOX5_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        On Error Resume Next
        If (e.KeyChar < "0" Or e.KeyChar > "9") And Asc(e.KeyChar) <> 8 And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub
    Private Sub TEXTBOX6_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboAccountNumber.SelectedIndexChanged
        Me.SEARCHDATAITEMS10()
        Me.InternalAuditorBalance()
        Me.TEXTTotalValues.Text = Format(Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue), "0.000")
    End Sub
    Private Sub TEXTBOX6_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboAccountNumber.SelectedValueChanged
        Me.InternalAuditorBalance()
        Me.TEXTTotalValues.Text = Format(Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue), "0.000")
    End Sub
    Private Sub TEXTBOX16_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.InternalAuditorBalance()
    End Sub
    Private Sub TEXTBOX23_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.InternalAuditorBalance()
    End Sub
    Private Sub TEXTBOX4_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTDebit.DoubleClick
        On Error Resume Next
        Me.TEXTDebit.Text = Calculator()
    End Sub

    Private Sub TEXTBOX2_TextChanged1(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTPreviousBalance.TextChanged, TEXTCurrentBalance.TextChanged, ComboAccountNumber.TextChanged, TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged
        On Error Resume Next
        Me.InternalAuditorBalance()

        Me.TEXTTotalValues.Text = Format(Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue), "0.000")
        Select Case Me.ComboConstraintType.Text
            Case "ايداع"
                Me.TextFundValue.EditValue = Format(Val(Me.TEXTCredit.Text), "0.000")
                Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TextFundValue.EditValue), "0.000")
            Case "سحب"
                Select Case Me.ComboPaymentMethod1.Text
                    Case "نقدا"
                        Me.TextFundValue.EditValue = Format(Val(Me.TEXTDebit.Text), "0.000")
                        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TextFundValue.EditValue), "0.000")
                    Case "شيك"
                        Me.TextValueOfCheck.EditValue = Format(Val(Me.TEXTDebit.Text), "0.000")
                        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TextValueOfCheck.EditValue), "0.000")
                    Case "نقدا_شيك"
                        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TEXTDebit.Text), "0.000")
                End Select
        End Select


    End Sub

    Private Sub ComboAccountType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboAccountType.SelectedIndexChanged
        AccountsEnquiry()
    End Sub


    Private Sub NewMethod()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboAccountType.Text, 1)
        AccountNoAktevd = ID_Nam

        GetFundAccount_No(ModuleGeneral.CB2)
        GetUpAccounts(ComboPaymentMethod1.Text, AccountNoAktevd)

        If Me.Deposit = True Then  ' ايداع
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", AccountNoAktevd, 1)
            CredAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", AccountNoAktevd, 1)
            CredAccount_Cod = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ModuleGeneral.CB2, 1)
            FundAccount_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
            FundAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", FundAccount_No, 1)
            CodAccount = ID_Nam


        Else ' سحب
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", AccountNoAktevd, 1)
            DebitAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", AccountNoAktevd, 1)
            DebitAccount_Cod = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ModuleGeneral.CB2, 1)
            FundAccount_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
            FundAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", FundAccount_No, 1)
            CodAccount = ID_Nam
        End If
    End Sub



    Private Sub TransforAccounts()
        Try
            DebitAccount_Name = Nothing
            CredAccount_Name = Nothing
            FundAccount_Name = Nothing
            ChecksAccount_Name = Nothing
            nem = "حركات السحب والايداعات "
            nem1 = "استلام نقدي من حساب" & " " & Me.ComboAccountType.Text
            nem2 = "صرف شيك رقم من حساب" & " " & Me.ComboAccountType.Text & "_" & Me.TextCheckNumber.Text
            PMO2 = 1
            ''Me.ComboCB1_SelectedIndexChanged(sender, e)
            Dim DocumentTapy As String
            If OBCHK1 = False Then
                DocumentTapy = "قبض"
            Else
                DocumentTapy = "قيد"
            End If
            NewMethod()
            SEARCHDATA.MAXIDMOVES()
            TransferToAccounts_Check = True

            AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TEXTCurrentBalance.Text, TEXTCurrentBalance.Text, T3, DocumentTapy, "WD", TextMovementSymbol.EditValue, False)
            If OBCHK1 = True Then
                If Me.Deposit = True Then  ' ايداع
                    DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTCredit.EditValue, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TEXTCredit.EditValue, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                ElseIf Me.Deposit = False Then ' سحب
                    nem1 = "صرف نقدي من حساب" & " " & Me.ComboAccountType.Text
                    DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTDebit.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TEXTDebit.EditValue, nem1, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                End If
            Else
                If Me.ComboConstraintType.Text = "ايداع" Then
                    Documenttype = "قبض"
                Else
                    Documenttype = "صرف"
                End If
                If Me.Deposit = True Then  ' ايداع
                    If Me.ComboPaymentMethod1.Text.Trim = "شيك" Then
                        MsgBox("عفوا .. لا يمكن ترحيل الحساب  في حالة طريقة الدفع(شيك) يجب تغير طريقة الدفع الى نقدا ", 16, "تنبيه")
                        Exit Sub
                    End If
                    If Me.ComboPaymentMethod1.Text.Trim = "نقدا_شيك" Then
                        MsgBox("عفوا .. لا يمكن ترحيل الحساب  في حالة طريقة الدفع(نقدا_شيك) يجب تغير طريقة الدفع الى نقدا", 16, "تنبيه")
                        Exit Sub
                    End If
                    If Me.ComboPaymentMethod1.Text.Trim = "نقدا" Then
                        DetailsAccountingEntries(PMO2, ModuleGeneral.CB2.ToString, FundAccount_No, TEXTCredit.EditValue, 0, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                        DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TEXTCredit.EditValue, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                        Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), Documenttype.ToString, TextMovementSymbol.EditValue, TextFundValue.EditValue, 0, Me.Text,
                                                                      nem1, False, TEXTID.EditValue & "0",
                                                                      False, True, ComboCB1.Text, ModuleGeneral.CB2)
                    End If
                ElseIf Me.Deposit = False Then ' سحب
                    If Me.ComboPaymentMethod1.Text.Trim = "نقدا" Then
                        nem1 = "صرف نقدي من حساب" & " " & Me.ComboAccountType.Text
                        DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TextFundValue.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                        DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, FundAccount_No, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                        Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), Documenttype.ToString, TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                      nem1, False, TEXTID.EditValue & "0",
                                                                      False, True, ComboCB1.Text, ModuleGeneral.CB2)
                    ElseIf Me.ComboPaymentMethod1.Text.Trim = "شيك" Then
                        DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TextValueOfCheck.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                        DetailsAccountingEntries(PMO2 + 1, ChecksAccount_Name, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                        Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                       TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4.ToString, True,
                       TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                    ElseIf Me.ComboPaymentMethod1.Text.Trim = "نقدا_شيك" Then
                        DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTDebit.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                        DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, FundAccount_No, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                        DetailsAccountingEntries(PMO2 + 2, ChecksAccount_Name, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                        Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), Documenttype.ToString, TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                      nem1, False, TEXTID.EditValue & "0",
                                                                      False, True, ComboCB1.Text, ModuleGeneral.CB2)

                        Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                       TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4.ToString, True,
                       TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)
                    End If
                End If
            End If
        Catch er As Exception
            MessageBox.Show(er.Message, "ErrorTransforAccounts", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub ComboPaymentMethod1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboPaymentMethod1.SelectedIndexChanged
        On Error Resume Next
        AccountsEnquiry()
    End Sub
    Private Sub AccountsEnquiry()
        On Error Resume Next
        NewMethod()
        If Me.Deposit = True Then  ' ايداع
            TextFundValue.EditValue = Val(TEXTCredit.EditValue)
        Else
            Select Case Me.ComboPaymentMethod1.Text
                Case "نقدا"
                    Me.TextFundValue.Enabled = True
                    Me.TextValueOfCheck.Enabled = False
                    Me.ComboCB1.Enabled = True
                    Me.LabelCB1.Enabled = True
                    Me.GroupCHKS.Enabled = False
                    Me.GroupCHKS1.Enabled = False
                    LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                    TextFundValue.EditValue = TEXTDebit.EditValue
                    TextValueOfCheck.EditValue = 0
                Case "شيك"
                    Me.TextFundValue.Enabled = False
                    Me.TextValueOfCheck.Enabled = True
                    Me.ComboCB1.Enabled = False
                    Me.LabelCB1.Enabled = False
                    Me.GroupCHKS.Enabled = True
                    Me.GroupCHKS1.Enabled = True
                    TextFundValue.EditValue = 0
                    TextValueOfCheck.EditValue = TEXTDebit.EditValue
                Case "نقدا_شيك"
                    Me.TextFundValue.Enabled = True
                    Me.TextValueOfCheck.Enabled = True
                    Me.ComboCB1.Enabled = True
                    Me.LabelCB1.Enabled = True
                    Me.GroupCHKS.Enabled = True
                    Me.GroupCHKS1.Enabled = True
                    LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                    TextFundValue.EditValue = Val(TEXTDebit.EditValue) - Val(TextValueOfCheck.EditValue)
                    TextValueOfCheck.EditValue = Val(TEXTDebit.EditValue) - Val(TextFundValue.EditValue)
            End Select
        End If
    End Sub
    Private Sub TextFundValue_EditValueChanged(sender As Object, e As EventArgs) Handles TextFundValue.EditValueChanged, TextValueOfCheck.EditValueChanged
        If Me.Deposit = True Then  ' ايداع
            TextFundValue.EditValue = Val(TEXTCredit.EditValue)
        Else
            Select Case Me.ComboPaymentMethod1.Text
                Case "نقدا"
                    TextFundValue.EditValue = Val(TEXTDebit.EditValue)
                    TextValueOfCheck.EditValue = 0
                Case "شيك"
                    TextFundValue.EditValue = 0
                    TextValueOfCheck.EditValue = Val(TEXTDebit.EditValue)
                Case "نقدا_شيك"
                    TextFundValue.EditValue = Val(TEXTDebit.EditValue) - Val(TextValueOfCheck.EditValue)
                    TextValueOfCheck.EditValue = Val(TEXTDebit.EditValue) - Val(TextFundValue.EditValue)
            End Select
        End If
    End Sub


    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioButton7.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioButton6.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioButton5.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioButton4.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub AddType1()
        On Error Resume Next
        If Me.RadioButton7.Checked = True Then
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioButton6.Checked = True Then
            FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioButton5.Checked = True Then
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboCheckDrawerName)
        Else
            Me.ComboCheckDrawerName.ResetText()
            Me.TextCheckDrawerCode.Text = 0
        End If
        Me.ComboCheckDrawerName.Focus()
    End Sub
    Private Sub ComboCheckDrawerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
            If Me.RadioButton7.Checked = True Then
                Dim Adp As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlDataAdapter(strsql)
                ds.Clear()
                Adp.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerCode.Text = 0
                End If
                Adp.Dispose()
                Consum.Close()
            ElseIf Me.RadioButton6.Checked = True Then
                Dim Adp1 As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds1 As New DataSet
                Adp1 = New SqlDataAdapter(strsql)
                ds1.Clear()
                Adp1.Fill(ds1)
                If ds1.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds1.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerCode.Text = 0
                End If
                Adp1.Dispose()
                Consum.Close()
            ElseIf Me.RadioButton5.Checked = True Then
                Dim Adp2 As SqlDataAdapter
                Dim strsq2 As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds2 As New DataSet
                Adp2 = New SqlDataAdapter(strsq2)
                ds2.Clear()
                Adp2.Fill(ds2)
                If ds2.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds2.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerCode.Text = 0
                End If
                Adp2.Dispose()
                Consum.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboCheckDrawerName", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ComboConstraintType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboConstraintType.SelectedIndexChanged
        On Error Resume Next
        Select Case Me.ComboConstraintType.Text
            Case "ايداع"
                Me.LabelDocumentNumber.Text = "رقم مستند (قبض)"
                Me.LabelDocumentNumber.Location = New Point(271, 128)
                Me.TEXTCredit.Enabled = True
                Me.TEXTDebit.Text = "0.000"
                Me.TEXTDebit.Enabled = False
                ComboPaymentMethod1.Text = "نقدا"
                ComboPaymentMethod1.Enabled = False
                Me.Deposit = True
            Case "سحب"
                ComboPaymentMethod1.Enabled = True
                Me.LabelDocumentNumber.Text = "رقم مستند (صرف)"
                Me.LabelDocumentNumber.Location = New Point(271, 128)
                Me.TEXTCredit.Enabled = False
                Me.TEXTCredit.Text = "0.000"
                Me.TEXTDebit.Enabled = True
                Me.Deposit = False
        End Select
        AccountsEnquiry()
    End Sub

    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCB1.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
            Dim Adp As SqlDataAdapter
            Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
            Dim ds As New DataSet
            Adp = New SqlDataAdapter(strsql)
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboBN2_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBN2.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
            Dim Adp As SqlDataAdapter
            Dim strsql As New SqlCommand("SELECT BN3,BN4    FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
            Dim ds As New DataSet
            Adp = New SqlDataAdapter(strsql)
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboBN2_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class