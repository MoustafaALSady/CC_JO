Option Explicit Off

Imports System.Data.SqlClient
Public Class FrmEmpsolf1
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    ReadOnly myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0

    Private Sub Frmempsolf1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub
    Private Sub Frmempsolf1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            Me.SHOWBUTTON()
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboStaffMovement)
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ItWillBeAnAccountingEntryWhenAdding_Check = keyAccounts.GetValue("ItWillBeAnAccountingEntryWhenAdding_Check", ItWillBeAnAccountingEntryWhenAdding_Check)
        TestkeyAccounts(keyAccounts.GetValue("CalculationEmployeeEngagement_No", CalculationEmployeeEngagement_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("CalculationEmployeeEngagement_No", CalculationEmployeeEngagement_No)
        End If
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
            BS.Position = BS.Count - 1
            BS.EndEdit()
            BS.AddNew()
            CLEARDATA()

            GetAutoNumber("CSH1", "EMPSOLF", "CSH2")
            TEXTID.EditValue = AutoNumber

            Me.TextMovementSymbol.EditValue = "PS" & Me.TEXTID.EditValue

            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            Me.ComboMotionSource.Text = "حركة عهدة الموظفين"
            Me.ComboConstraintType.Text = "ايداع"
            Me.TEXTDocumentNumber.Text = TEXTID.EditValue
            Me.ComboPaymentMethod.Text = "نقدا"
            Me.TEXTDebit.EditValue = "0"
            Me.TEXTTotal.Text = "0"
            Me.ComboNotes.Text = "حركة عهدة الموظفين"
            Me.TEXTStatement.Text = "عهدة الموظفين"
            Me.DateMovementHistory.Value = MaxDate.ToString("yyyy-MM-dd")
            Me.TextDateMovementHistory.Text = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            Me.DateMovementHistory.Focus()
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
                TransferToAccounts_Check = True
            Else
                TransferToAccounts_Check = False
            End If

            Dim Sound As System.IO.Stream = My.Resources.addv
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
        Static P As Integer
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockSave = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            'GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
            'If ExitSub_Check = True Then
            '    frmOPTIONS.ShowDialog()
            '    Exit Sub
            'End If
            Me.SAVEBUTTON.Enabled = False

            P = Me.BS.Count
            'Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTDebit.EditValue) - Val(Me.TEXTDebit.EditValue.Text), "0.000")
            'Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")

            Insert_EMPSOLF(ComboConstraintType.Text, TEXTID.EditValue, Me.TEXTDebit.EditValue, Me.TEXTCredit.EditValue, Me.ComboMotionSource.Text, Me.TEXTStatement.Text, Convert.ToInt32(TransferToAccounts_Check), Me.ComboStaffMovement.Text, Me.TextStaffNumber.Text, Me.TextMovementSymbol.EditValue, False, Me.ComboCB1.Text, 0)

            If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
                TransferToAccounts_Check = True
                TransforAccounts()
            Else
                TransferToAccounts_Check = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSAVEBUTTON", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Me.SAVEBUTTON.Enabled = False
        Click1 = True
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
            BS.DataSource = myds.Tables("EMPSOLF")
            Me.Cursor = Cursors.Default
            PictureBox2.Visible = False
            If BS.Count < RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf BS.Count > RowCount Then
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
            ComboStaffMovement.Focus()
            ComboStaffMovement.SelectAll()
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboStaffMovement.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboStaffMovement.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        Adp.Fill(ds, "EMPLOYEES")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextStaffNumber.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextStaffNumber.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
        InternalAuditorBalance()
    End Sub
    Private Sub InternalAuditorBalance()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsq1 As New SqlCommand("SELECT Sum(EMPSOLF.CSH7) AS SumDEBIT,Sum(EMPSOLF.CSH8) AS SumCREDIT FROM EMPSOLF  WHERE (EMPSOLF.CSH15)='" & Me.TextStaffNumber.Text & "'AND EMPSOLF.CSH1 <'" & Me.TEXTID.EditValue & "'", Consum)
            Dim DataSetTab20 As New DataSet
            Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
            DataSetTab20.Clear()
            Adp1.Fill(DataSetTab20, "EMPSOLF")
            If DataSetTab20.Tables(0).Rows.Count > 0 Then
                Me.TEXTPreviousBalance.Text = Format(Val(DataSetTab20.Tables(0).Rows(0).Item(0)) - Val(DataSetTab20.Tables(0).Rows(0).Item(1)), "0.000")
            Else
                Me.TEXTPreviousBalance.Text = "0"
            End If
            Adp1.Dispose()
            Consum.Close()
        Catch ex As Exception
            Me.TEXTPreviousBalance.Text = "0"
        End Try
    End Sub

    Private Sub ComboPaymentMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        AccountsEnquiry()
    End Sub

    Private Sub TransforAccounts()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing

        nem = " حساب عهدة الموظفين"
        nem1 = " حساب عهدة الموظفين الى الصندوق"
        PMO2 = 1
        If keyAccounts.GetValue("CalculationEmployeeEngagement_No", CalculationEmployeeEngagement_No) IsNot Nothing Then
            DebitAccount_No = keyAccounts.GetValue("CalculationEmployeeEngagement_No", CalculationEmployeeEngagement_No)
        End If
        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", DebitAccount_No, 1)
        DebitAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", DebitAccount_No, 1)
        DebitAccount_Cod = ID_Nam

        GetFundAccount_No(ModuleGeneral.CB2)
        GetUpAccounts(ComboPaymentMethod.Text, DebitAccount_No)

        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", FundAccount_No, 1)
        FundAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", FundAccount_No, 1)
        CodAccount = ID_Nam

        SEARCHDATA.MAXIDMOVES()

        AccountingEntries(T1, T2, MaxDate.ToString("yyyy-MM-dd"), nem, False, TEXTDebit.EditValue, TEXTDebit.EditValue, T3, "قيد", "PS", TextMovementSymbol.EditValue, False)
        DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTDebit.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        DetailsAccountingEntries(PMO2 + 1, FundAccount_Name, FundAccount_No, 0, TEXTDebit.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

        Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TEXTDebit.EditValue, Me.Text,
                                              "من حساب حركة عهدة الموظفين اسم و رقم " & " _ " & Me.ComboStaffMovement.Text & "_" & Me.TextStaffNumber.Text, False, TEXTDocumentNumber.Text,
                                              False, True, ComboCB1.Text, ModuleGeneral.CB2)

    End Sub

    Private Sub AccountsEnquiry()
        On Error Resume Next

        GetFundAccount_No(ModuleGeneral.CB2)
        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", FundAccount_No, 1)
        FundAccount_Name = ID_Nam
        Me.ComboCB1.Enabled = True
        Me.LabelCB1.Enabled = True
        LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
    End Sub

    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCB1.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            ModuleGeneral.CB2 = ds.Tables(0).Rows(0).Item(0)
        Else
            ModuleGeneral.CB2 = ""
        End If
        Adp.Dispose()
        Consum.Close()

        AccountsEnquiry()
        FundBalance()
    End Sub

    Private Sub ComboConstraintType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboConstraintType.SelectedIndexChanged
        Select Case Trim(Me.ComboConstraintType.Text)
            Case "ايداع"
                Me.TEXTCredit.Enabled = False
                Me.TEXTDebit.Enabled = True
                Me.TEXTCredit.EditValue = "0.00"
            Case "سحب"
                Me.TEXTCredit.Enabled = True
                Me.TEXTDebit.Enabled = False
                Me.TEXTDebit.EditValue = "0.00"
        End Select
    End Sub

    Private Sub FundBalance()
        On Error Resume Next
        Dim N As Double
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()

        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub
End Class