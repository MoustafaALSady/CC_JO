Option Explicit Off

Imports System.Data.SqlClient
Public Class FrmDeposits1
    Inherits Form
    Public WithEvents BS As New BindingSource
    ReadOnly myds As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0

    Private Sub FrmDeposits1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    ADDBUTTON_Click(sender, e)
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
    Private Sub FrmDeposits1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            Me.SHOWBUTTON()
            FILLCOMBOBOXDISTINCT("AllCustomers", "cust2", "IDcust", "CUser", CUser, Me.ComboMembersCode)
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
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

            BS.Position = BS.Count - 1
            'F = Val(TEXTBOX7.Text)
            's = Val(Me.TEXTBOX1.Text)
            BS.EndEdit()
            BS.AddNew()
            CLEARDATA1(Me)

            'If OBCHK1 = False Then
            '    Me.TEXTPreviousBalance.Enabled = False
            'Else
            '    Me.TEXTPreviousBalance.Enabled = True
            'End If
            SEARCHDATA.MAXIDDeposits()
            GetAutoNumber("TBNK1", "Deposits", "TBNK3")
            Me.TEXTID.EditValue = AutoNumber

            Me.TextMovementSymbol.EditValue = "SD" & Me.TEXTID.EditValue
            Me.ComboAccountType.Text = "الاسهم"
            Me.TEXTReturnRatio.EditValue = 0
            Me.TEXTDuration.EditValue = 1
            Me.ComboAccountNumber.Text = SEARCHDATA.MAXDeposits
            Me.TEXTReleaseDate.Text = MaxDate.ToString("yyyy-MM-dd")
            Me.ComboDistributionRate.Text = "سنوى"
            Me.TEXTCurrentBatch.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TEXTEndCertificate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TEXTDocumentNumber.Text = 0
            Me.TextNumberPayments.Text = 0
            Me.TextPaymentValue.Text = 0
            Me.TextResidualYield.Text = 0
            Me.TextRemainingPayments.Text = 0
            Me.TEXTReturnValue.Text = 0
            Me.TEXTPreviousBalance.Text = 0
            Me.TextCertificateAmount.EditValue = 0
            Me.TEXTReleaseDate.Focus()
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
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
        'Dim x As Double = Val(Me.TextBox29.Text) + Val(Me.TEXTBOX2.Text)
        'If Me.TEXT3.Text = "الاسهم" And Val(x) > Val(BANSL) Then
        '    MessageBox.Show("لا يمكن ان تكون قيمة اسهم العضو اكبر من قيمة اسهم الجمعة المكتتبة:" & ControlChars.CrLf & _
        '                   "1) اسهم الجمعة المكتتبة = " & "(" & Val(BANSL) & ")" & " " & "دينار اردني" & ControlChars.CrLf & _
        '                   "2) يمكن ان تغير نوع الحساب ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If


        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        Static P As Integer
        P = Me.BS.Count
        Me.TEXTReleaseDate.Text = MaxDate.ToString("yyyy-MM-dd")
        Me.SumAmounBALANCE()
        Me.SAVERECORD()
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
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
        Me.BS.Position = P + 1
        Me.SHOWBUTTON()
        Me.SAVEBUTTON.Enabled = False
        Click1 = True
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
                PictureBox2False()
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            Application.DoEvents()
            BS.DataSource = myds.Tables("Deposits")
            Me.Cursor = Cursors.Default
            PictureBox2.Visible = False
            If BS.Count < RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf BS.Count > RowCount Then
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
            MessageBox.Show(Ex.Message, "Error6", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            PictureBox2.Visible = False
            PictureBox5.Visible = False
        End If
    End Sub
    Private Sub SumAmounBALANCE()
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsql As New SqlCommand("SELECT Sum(TBNK2 + TBNK15)  FROM Deposits WHERE CUser='" & CUser & "'", Consum)
        Dim ds1 As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds1.Clear()
        Consum.Open()
        Adp.Fill(ds1)
        If ds1.Tables(0).Rows.Count > 0 Then
            Me.TEXTTotal.Text = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            Me.TEXTTotal.Text = 0
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub SAVERECORD()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As String = "INSERT INTO Deposits( TBNK1, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK19, TBNK20, TBNK21, TBNK22, TBNK23, TBNK24, CB1, USERNAME, CUser, COUser, da, ne) VALUES     (@TBNK1, @TBNK3, @TBNK4, @TBNK5, @TBNK6, @TBNK7, @TBNK8, @TBNK9, @TBNK10, @TBNK11, @TBNK12, @TBNK13, @TBNK14, @TBNK15, @TBNK16, @TBNK17, @TBNK18, @TBNK19, @TBNK20, @TBNK21, @TBNK22, @TBNK23, @TBNK24, @CB1, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlCommand(SQL, Consum)
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@TBNK1", SqlDbType.BigInt).Value = TEXTID.EditValue
                .Parameters.Add("@TBNK2", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text
                .Parameters.Add("@TBNK3", SqlDbType.Date).Value = Me.TEXTReleaseDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@TBNK4", SqlDbType.Money).Value = Me.TEXTReturnRatio.EditValue
                .Parameters.Add("@TBNK5", SqlDbType.Money).Value = Me.TextCertificateAmount.EditValue
                .Parameters.Add("@TBNK6", SqlDbType.Int).Value = Me.ComboAccountNumber.Text
                .Parameters.Add("@TBNK7", SqlDbType.Money).Value = Me.TEXTReturnValue.Text
                .Parameters.Add("@TBNK8", SqlDbType.NVarChar).Value = Me.ComboDistributionRate.Text
                .Parameters.Add("@TBNK9", SqlDbType.Date).Value = Me.TEXTEndCertificate.Value.ToString
                .Parameters.Add("@TBNK10", SqlDbType.Date).Value = Me.TEXTCurrentBatch.Value.ToString
                .Parameters.Add("@TBNK11", SqlDbType.NVarChar).Value = Me.TEXTTotal.Text
                .Parameters.Add("@TBNK12", SqlDbType.Bit).Value = False
                .Parameters.Add("@TBNK13", SqlDbType.Money).Value = Me.TextNumberPayments.Text
                .Parameters.Add("@TBNK14", SqlDbType.Money).Value = Me.TextPaymentValue.Text
                .Parameters.Add("@TBNK15", SqlDbType.Money).Value = Me.TextResidualYield.Text
                .Parameters.Add("@TBNK16", SqlDbType.Money).Value = Me.TextRemainingPayments.Text
                .Parameters.Add("@TBNK17", SqlDbType.Bit).Value = False
                .Parameters.Add("@TBNK18", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@TBNK19", SqlDbType.NVarChar).Value = Me.ComboAccountType.Text
                .Parameters.Add("@TBNK20", SqlDbType.NVarChar).Value = Me.TextMembersName.Text
                .Parameters.Add("@TBNK21", SqlDbType.NVarChar).Value = Me.TextMembersCode.EditValue
                .Parameters.Add("@TBNK22", SqlDbType.Bit).Value = Convert.ToInt32(TransferToAccounts_Check)
                .Parameters.Add("@TBNK23", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@TBNK24", SqlDbType.NVarChar).Value = Me.TEXTDuration.EditValue
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.Int).Value = CUser
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
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
        Me.ButtonXP2.Enabled = LockUpdate
    End Sub
    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP2.Click
        Try
            Me.ComboMembersCode.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ComboBox2_KeyPress1(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(ComboMembersCode, e, )
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ComboMembersCode.KeyPress

        On Error Resume Next
        If Char.IsControl(e.KeyChar) = False Then
            If Char.IsDigit(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.ComboMembersCode.Enabled = False
        End If
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboMembersCode.SelectedIndexChanged
        Dim Str1 As String = Me.ComboMembersCode.Text
        Dim strArr() As String
        Dim a As String
        strArr = Str1.Split("-")
        a = strArr(0)
        If Me.ComboMembersCode.Text.Length > 0 Then
            Me.TextMembersName.Text = strArr(1)
            Me.TextMembersCode.EditValue = strArr(0)
            Me.ComboMembersCode.Enabled = False
            Dim Consum As New SqlConnection(constring)
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT TBNK6 FROM Deposits WHERE  CUser='" & ModuleGeneral.CUser & "'and  TBNK21 ='" & Strings.Trim(Me.TextMembersCode.EditValue) & "'ORDER BY TBNK1", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            Consum.Open()
            SqlDataAdapter1.Fill(ds, "Deposits")
            If ds.Tables(0).Rows.Count > 0 Then
                MsgBox("يوجد بالفعل رقم حساب هو " & " " & "(" & ds.Tables(0).Rows(0).Item(0) & ")", 64 + 524288, "الاستعلام عن رقم الحساب")
                Me.SAVEBUTTON.Enabled = False
                Me.KeyPreview = False
                Exit Sub
            Else
                Me.KeyPreview = True
                Me.SAVEBUTTON.Enabled = True
            End If
        Else
            Me.TextMembersName.Text = ""
            Me.TextMembersCode.EditValue = ""
        End If

    End Sub


    Private Function MYGROUPS(ByVal str As String) As Double
        On Error Resume Next
        Select Case str
            Case "شهرى"
                MYGROUPS = 1
            Case "ريع سنوى"
                MYGROUPS = 3
            Case "نصف سنوى"
                MYGROUPS = 6
            Case "نصف سنوى تصاعدى"
                MYGROUPS = 6
            Case "سنوى"
                MYGROUPS = 12
        End Select
    End Function

    Private Sub InternalAuditorBalance()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT Sum(Deposits.TBNK2) AS SumDEBIT,Sum(Deposits.TBNK5) AS SumDEBIT1,Sum(Deposits.TBNK7) AS SumCREDIT FROM Deposits  WHERE (Deposits.TBNK6)='" & Me.ComboAccountNumber.Text.Trim & "'AND (Deposits.TBNK19)='" & Me.ComboAccountType.Text.Trim & "'AND Deposits.TBNK1 <'" & Me.TEXTID.EditValue & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsq1)
        ds.Clear()
        Consum.Open()
        Adp1.Fill(ds, "Deposits")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXTTotal.Text = Format(Val(ds.Tables(0).Rows(0).Item(1)) + Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            Me.TEXTTotal.Text = "0"
        End If
        Me.TEXTEndCertificate.Text = Format(DateAdd(DateInterval.Year, Convert.ToDouble(Me.TEXTDuration.EditValue), Convert.ToDateTime(Me.TEXTReleaseDate.Text)), "yyyy/MM/dd")
        Me.TextRemainingPayments.Text = DateDiff(DateInterval.Month, Convert.ToDateTime(Me.TEXTCurrentBatch.Text), Convert.ToDateTime(Me.TEXTEndCertificate.Text)) / Val(MYGROUPS(Me.ComboDistributionRate.Text))
        Adp1.Dispose()
        Consum.Close()
    End Sub
    Private Sub TEXTBOX2_TextChanged1(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTPreviousBalance.TextChanged, TEXTReturnValue.TextChanged, ComboAccountNumber.TextChanged, TEXTReleaseDate.ValueChanged, TextNumberPayments.TextChanged, TextPaymentValue.TextChanged, TextResidualYield.TextChanged, TextRemainingPayments.TextChanged, TEXTCurrentBatch.ValueChanged, ComboDistributionRate.TextChanged, TEXTPreviousBalance.TextChanged, TEXTReturnRatio.EditValueChanged, TEXTDuration.EditValueChanged
        On Error Resume Next
        Me.InternalAuditorBalance()
        Me.TEXTReturnValue.Text = Format(Val((Val(Me.TEXTPreviousBalance.Text) + Val(Me.TextCertificateAmount.EditValue)) * Val(Me.TEXTReturnRatio.EditValue) / 100) * Val(Me.TEXTDuration.EditValue), "0.000")
        Me.TextNumberPayments.Text = Format(Val(Val(Me.TEXTDuration.EditValue) * 12) / Val(Me.MYGROUPS(Me.ComboDistributionRate.Text)), "0.000")
        Me.TextPaymentValue.Text = Format(Val(Me.TEXTReturnValue.Text) / Val(Me.TextNumberPayments.Text), "0.000")
        Me.TextResidualYield.Text = Format(Val(Me.TextRemainingPayments.Text) * Val(Me.TextPaymentValue.Text), "0.000")
        Me.TEXTEndCertificate.Text = Format(DateAdd(DateInterval.Year, Convert.ToDouble(Me.TEXTDuration.EditValue), Convert.ToDateTime(Me.TEXTReleaseDate.Text)), "yyyy/MM/dd")
        Me.TEXTCurrentBatch.Text = Format(DateAdd(DateInterval.Month, Convert.ToDouble(Me.TEXTDuration.EditValue), Convert.ToDateTime(Me.TEXTReleaseDate.Text)), "yyyy/MM/dd")

        Me.TextRemainingPayments.Text = DateDiff(DateInterval.Month, Convert.ToDateTime(Me.TEXTCurrentBatch.Text), Convert.ToDateTime(Me.TEXTEndCertificate.Text)) / Val(Me.MYGROUPS(ComboDistributionRate.Text))

        If Me.ComboDistributionRate.Text = "نصف سنوى تصاعدى" Then
            Select Case Val(Me.TextRemainingPayments.Text) / 2
                Case Is = 0
                    Me.TEXTReturnRatio.EditValue = 0.12
                Case Is <= 1
                    Me.TEXTReturnRatio.EditValue = 0.1125
                Case Is <= 2
                    Me.TEXTReturnRatio.EditValue = 0.1075
                Case Is <= 3
                    Me.TEXTReturnRatio.EditValue = 0.105
                Case Is <= 4
                    Me.TEXTReturnRatio.EditValue = 0.10375
                Case Is <= 5
                    Me.TEXTReturnRatio.EditValue = 0.1025
                Case Is <= 6
                    Me.TEXTReturnRatio.EditValue = 0.10125
                Case Is <= 7
                    Me.TEXTReturnRatio.EditValue = 0.1
                Case Is <= 8
                    Me.TEXTReturnRatio.EditValue = 0.9875
                Case Is <= 9
                    Me.TEXTReturnRatio.EditValue = 0.0975
            End Select
        End If
    End Sub
    Private Sub INSERTPTRANSACTION()

        Try
            Dim Consum As New SqlConnection(constring)
            Dim N As Int64
            GetAutoNumber("TBNK1", "PTRANSACTION", "TBNK3")
            N = AutoNumber


            Dim SQL As String = "INSERT INTO PTRANSACTION( TBNK1, TBNK2, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK22, TBNK23, CB1, BN2, USERNAME, CUser, COUser, da, ne) VALUES     (@TBNK1, @TBNK2, @TBNK3, @TBNK4, @TBNK5, @TBNK6, @TBNK7, @TBNK8, @TBNK9, @TBNK10, @TBNK11, @TBNK12, @TBNK13, @TBNK14, @TBNK15, @TBNK16, @TBNK17, @TBNK18, @TBNK22, @TBNK23, @CB1, @BN2, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlCommand(SQL, Consum)
            With cmd
                cmd.CommandType = CommandType.Text
                cmd.Connection = Consum
                cmd.Parameters.Add("@TBNK1", SqlDbType.BigInt).Value = N
                cmd.Parameters.Add("@TBNK2", SqlDbType.NVarChar).Value = Format(Val(SumAmounTOTALCASHANDCHEQUES2(CType(ComboAccountNumber.Text, Integer), ComboAccountType.Text, N)), "0.000")
                cmd.Parameters.Add("@TBNK3", SqlDbType.Date).Value = Me.TEXTReleaseDate.Value.ToString("yyyy-MM-dd")
                cmd.Parameters.Add("@TBNK4", SqlDbType.NVarChar).Value = 0
                'If OBCHK1 = False Then
                cmd.Parameters.Add("@TBNK5", SqlDbType.NVarChar).Value = Me.TextCertificateAmount.EditValue
                'Else
                '    cmd.Parameters.Add("@TBNK5", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text.Trim
                'End If
                cmd.Parameters.Add("@TBNK6", SqlDbType.NVarChar).Value = Me.ComboAccountNumber.Text
                cmd.Parameters.Add("@TBNK7", SqlDbType.NVarChar).Value = Format(Val(SumAmounTOTALCASHANDCHEQUES2(CType(ComboAccountNumber.Text, Integer), Me.ComboAccountType.Text, N)), "0.000")
                cmd.Parameters.Add("@TBNK8", SqlDbType.NVarChar).Value = Me.ComboAccountType.Text
                cmd.Parameters.Add("@TBNK9", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                cmd.Parameters.Add("@TBNK10", SqlDbType.NVarChar).Value = Me.ComboDistributionRate.Text
                cmd.Parameters.Add("@TBNK11", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                cmd.Parameters.Add("@TBNK12", SqlDbType.NVarChar).Value = False
                cmd.Parameters.Add("@TBNK13", SqlDbType.NVarChar).Value = False
                cmd.Parameters.Add("@TBNK14", SqlDbType.NVarChar).Value = "نقدا"
                cmd.Parameters.Add("@TBNK15", SqlDbType.NVarChar).Value = 0.000
                cmd.Parameters.Add("@TBNK16", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text
                cmd.Parameters.Add("@TBNK17", SqlDbType.NVarChar).Value = True
                cmd.Parameters.Add("@TBNK18", SqlDbType.NVarChar).Value = "ايداع"
                cmd.Parameters.Add("@TBNK22", SqlDbType.NVarChar).Value = Me.TextMembersName.Text
                cmd.Parameters.Add("@TBNK23", SqlDbType.NVarChar).Value = Me.TextMembersCode.EditValue
                cmd.Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                cmd.Parameters.Add("@BN2", SqlDbType.NVarChar).Value = 0

                cmd.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                cmd.Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                cmd.Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                cmd.Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                cmd.Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                cmd.Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                cmd.Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                cmd.CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch er As Exception
            MessageBox.Show(er.Message, "ErrorINSERTPTRANSACTION", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub





    Private Sub TransforAccounts()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        nem = "تسجيل حساب" & " " & Me.ComboAccountType.Text
        nem1 = "استلام نقدي من حساب" & " " & Me.ComboAccountType.Text
        PMO2 = 1

        GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboAccountType.Text, 1)
        CredAccount_NO = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", CredAccount_NO, 1)
        CredAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", CredAccount_NO, 1)
        CredAccount_Cod = ID_Nam

        GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ModuleGeneral.CB2, 1)
        FundAccount_No = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
        FundAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", FundAccount_No, 1)
        CodAccount = ID_Nam
        SEARCHDATA.MAXIDMOVES()
        TransferToAccounts_Check = True
        Dim DocumentTapy As String
        If OBCHK1 = False Then
            DocumentTapy = "قبض"
        Else
            DocumentTapy = "قيد"
        End If
        INSERTPTRANSACTION()
        AccountingEntries(T1, T2, TEXTReleaseDate.Value.ToString("yyyy-MM-dd"), nem, False, TextCertificateAmount.EditValue, TextCertificateAmount.EditValue, T3, DocumentTapy, "SD", TextMovementSymbol.EditValue, False)
        DetailsAccountingEntries(PMO2, ModuleGeneral.CB2.ToString, FundAccount_No, TextCertificateAmount.EditValue, 0, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TextCertificateAmount.EditValue, nem1, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

        If OBCHK1 = False Then
            Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "قبض", TextMovementSymbol.EditValue, TextCertificateAmount.EditValue, 0, Me.Text,
                                            nem1, False, TEXTDocumentNumber.Text,
                                              False, True, ComboCB1.Text, ModuleGeneral.CB2)
        End If


    End Sub


    Private Sub ComboAccountType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboAccountType.SelectedIndexChanged
        If ComboAccountType.Text = "الحسابات فارغة" Then
        Else
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboAccountType.Text, 1)
            AccountNoAktevd = ID_Nam
        End If

    End Sub

    Private Sub ComboCB1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboCB1.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
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
        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetUpAccounts("نقدا", AccountNoAktevd)

        LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"

        FundBalance()
    End Sub

    Private Sub FundBalance()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub

End Class