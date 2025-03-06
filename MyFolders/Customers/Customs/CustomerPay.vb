Option Explicit Off
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class CustomerPay
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

    Public WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim Cancel As Boolean = False
    Dim DelRow As Boolean = False

    Dim RowCount As Integer = 0
    ReadOnly phieght As Integer = 1
    Public TB1 As String
    Public TB2 As String

<<<<<<< HEAD
    Public Sub CustomerPay_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Public Sub CustomerPay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next

<<<<<<< HEAD
        Me.ConnectDataBase = New ComponentModel.BackgroundWorker With {
=======
        Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()
    End Sub

    Private Sub SumAmounBALANCE()
<<<<<<< HEAD
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(Loa6)  FROM LoansPa WHERE Lo ='" & Me.TextDebtNumber.Text & "'", Consum)
        Consum = New SqlConnection(constring)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(Loa6)  FROM LoansPa WHERE Lo ='" & Me.TextDebtNumber.Text & "'", Consum)
        Consum = New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextNetDebt.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)) - Me.TextMonthlyInstallment.Text, "0.000")
        Else
            Me.TextNetDebt.Text = "0"
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

    Public Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Me.myds.EnforceConstraints = False
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, lo25, CB1, Auditor, USERNAME, CUser,COUser, da, ne, da1, ne1 FROM LoansPa    WHERE  CUser='" & CUser & "' and Loa1 ='" & Trim(Me.TB1) & "'  ORDER BY Loa1"
                SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, lo25, CB1, Auditor, USERNAME, CUser,COUser, da, ne, da1, ne1 FROM LoansPa    WHERE  CUser='" & CUser & "' and Loa1 ='" & Trim(Me.TB1) & "'  ORDER BY Loa1"
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

                Me.myds = New DataSet
                If Consum.State = ConnectionState.Closed Then Consum.Open()
                Me.SqlDataAdapter1.TableMappings.Add("Table1", "LoansPa")
                Me.SqlDataAdapter1.Fill(Me.myds, "LoansPa")
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Me.myds.RejectChanges()
            End With
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "ErrorConnectDataBase_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then

            Else

                Me.Close()
            End If
        End If
    End Sub

    Public Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            Me.BS.DataSource = Me.myds.Tables("LoansPa")
            Me.RowCount = Me.BS.Count
            Me.TextContractNumber.DataBindings.Add("text", Me.BS, "Loa", True, 1, "")
            Me.TextDebtNumber.DataBindings.Add("text", Me.BS, "Lo", True, 1, "")
            Me.TextDocumentNumber1.DataBindings.Add("text", Me.BS, "Loa1", True, 1, "")
            Me.TextPaymentStatus.DataBindings.Add("text", Me.BS, "Loa3", True, 1, "")
            Me.TextDocumentNumber.DataBindings.Add("text", Me.BS, "Loa4", True, 1, "")
            Me.DatePayment.DataBindings.Add("text", Me.BS, "Loa5", True, 1, "")
            Me.TextMonthlyInstallment.DataBindings.Add("text", Me.BS, "Loa6", True, 1, "")
            Me.DatePaymentA.DataBindings.Add("text", Me.BS, "Loa7", True, 1, "")
            Me.TextNetDebt.DataBindings.Add("text", Me.BS, "Loa8", True, 1, "")
            Me.TextTotalDebt.DataBindings.Add("text", Me.BS, "Loa9", True, 1, "")
            Me.TextCustomerNumber.DataBindings.Add("text", Me.BS, "Loa10", True, 1, "")
            Me.TextCustomerName.DataBindings.Add("text", Me.BS, "Loa11", True, 1, "")
            Me.TextMonthlyInstallmentN.DataBindings.Add("text", Me.BS, "Loa12", True, 1, "")
            Me.TextNetDebtN.DataBindings.Add("text", Me.BS, "Loa13", True, 1, "")
            Me.CheckTransferToAccounts.DataBindings.Add("Checked", Me.BS, "Loa14", True, 1, "")
            Me.CheckLogReview.DataBindings.Add("Checked", Me.BS, "Loa16", True, 1, "")
            Me.TextMovementSymbol.DataBindings.Add("text", Me.BS, "Lo25", True, 1, "")
            ComboCB1.DataBindings.Add("text", BS, "CB1", True, 1, "")

            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            'Me.InternalAuditorBalance()
            Me.SumAmount()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorConnectRunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Call MangUsers()
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
        Me.AmountLoa6()
        Me.TextMonthlyInstallment.Text = Me.DatePaymentA.Text.Trim
        Me.TextDocumentNumber.Text = Me.TextDocumentNumber1.Text.Trim
        Me.DatePayment.Text = MaxDate.ToString("yyyy-MM-dd")



        ComboCB1_SelectedIndexChanged(sender, e)
        ItWillBeAnAccountingEntryWhenAdding_Check = keyAccounts.GetValue("ItWillBeAnAccountingEntryWhenAdding_Check", ItWillBeAnAccountingEntryWhenAdding_Check)
        TestkeyAccounts(keyAccounts.GetValue("ReceivablesAccount_No", ReceivablesAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("ReceivablesAccount_No", ReceivablesAccount_No)
        End If
        If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
            TransferToAccounts_Check = True
        Else
            TransferToAccounts_Check = False
        End If
    End Sub

    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.CmdSave.Enabled = LockUpdate
        Me.PRINTBUTTON.Enabled = LockPrint
    End Sub

    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.CmdSave.Enabled = False
            Me.PRINTBUTTON.Enabled = True
        ElseIf Me.CheckTransferToAccounts.Checked = True Then
            Me.CmdSave.Enabled = True
            Me.PRINTBUTTON.Enabled = True
        ElseIf Me.CheckTransferToAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.CmdSave.Enabled = False
            Me.PRINTBUTTON.Enabled = True
        Else
            Me.SHOWBUTTON()
        End If
    End Sub

    Private Sub AmountLoa6()
<<<<<<< HEAD
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Loa7 FROM LoansPa WHERE Lo ='" & Me.TextDebtNumber.Text & "'", Consum)
        Dim ds2 As New DataSet
<<<<<<< HEAD
        Adp = New SqlDataAdapter(strsql)
=======
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds2.Clear()
        Adp.Fill(ds2)
        If ds2.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds2.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Adp.Dispose()
        Consum.Close()
        Me.TextMonthlyInstallment.Text = Format(Val(SUM1), "#,#0.00")
    End Sub

    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "LoansPa")
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
            Me.BS.DataSource = Me.myds.Tables("LoansPa")
            Me.PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            If DelRow = False Then
                If Me.BS.Count < Me.RowCount Then
                    MsgBox("  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & Me.RowCount - Me.BS.Count, 48 + 524288, " ÕœÌÀ «·”Ã·« ")
                ElseIf Me.BS.Count > Me.RowCount Then
                    MsgBox("  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & Me.BS.Count - Me.RowCount, 48 + 524288, " ÕœÌÀ «·”Ã·« ")
                End If
            Else
                DelRow = False
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error4", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:

            Me.SumAmount()
            Me.TextMonthlyInstallmentN.Text = CurrencyJO(Me.TextMonthlyInstallment.Text, "jO")
            Me.TextNetDebtN.Text = CurrencyJO(Me.TextTotalDebt.Text, "jO")

            Dim myBuilder As New SqlCommandBuilder(SqlDataAdapter1)
            myBuilder.GetUpdateCommand()
            SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()
            Me.SqlDataAdapter1.Update(Me.myds, "LoansPa")

            ButtonCUSTOMER1_Click()


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
                MsgBox("ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› «·”Ã· «·„Õœœ" & vbCrLf & "”Ê› Ì „  ÕœÌÀ «·”Ã·«  «·¬‰", 16, " ‰»ÌÂ")
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
                Me.ButtonXP5_Click(sender, e)
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "LoansPa")
            Me.myds.RejectChanges()
            Me.BS.DataSource = Me.myds.Tables("LoansPa")

            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            'Dim f As New Loans
            'f.load_Click(sender, e)


            If Me.BS.Count < Me.RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & Me.RowCount - Me.BS.Count, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & Me.BS.Count - Me.RowCount, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
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
                    Insert_Actions(Me.TextDebtNumber.Text.Trim, "Õ›Ÿ ﬁ”ÿ ⁄„Ì·", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            End If
            Click1 = False
            If Cancel = True Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ :  „  ⁄„·Ì…  ≈·€«¡  —ÕÌ· «·»Ì«‰«  " & Me.RowCount - Me.BS.Count, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
            Else
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
            End If


        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error6", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf Me.PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
        End If
    End Sub

<<<<<<< HEAD
    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextMonthlyInstallment.TextChanged, TextTotalDebt.TextChanged
=======
    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMonthlyInstallment.TextChanged, TextTotalDebt.TextChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim p As String
        If myds.Tables("LoansPa").Compute("Count(Loa1)", "Loa7 ='" & Me.TextMonthlyInstallment.Text.Trim.ToLower & "'").ToString > 0 Then
            p = " „ «· ”œÌœ"
        ElseIf myds.Tables("LoansPa").Compute("Count(Loa1)", "Loa7 >'" & Me.TextMonthlyInstallment.Text.Trim.ToLower & "'").ToString > 0 Then
            p = "·„ Ì”œœ ﬂ«„· «·«ﬁ”ÿ"
        Else
            p = "·„ Ì „ «· ”œÌœ"
        End If

        'Me.TextBox8.Text = Val(Me.TextBox8.Text) 
        Me.TextPaymentStatus.Text = p
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        'InternalAuditorBalance()
    End Sub

    Private Sub GETBANKNOWBALANCE()
        On Error Resume Next
        Dim n As Double
        Dim F As Double
        n = Me.BS.Position
        Me.BS.EndEdit()
        If BS.Position = 0 Then
            Me.TextNetDebt.Text = Val(Me.TextTotalDebt.Text) - Val(Me.TextMonthlyInstallment.Text)
        ElseIf Me.BS.Position > 0 Then
            F = 0
            Me.BS.Position = Me.BS.Position - 1
            F = Val(Me.TextTotalDebt.Text) - Val(Me.TextNetDebt.Text)
            Me.BS.Position = Me.BS.Position + 1
            Me.TextNetDebt.Text = F
        End If

    End Sub

    Private Sub SumAmount()
<<<<<<< HEAD
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim SUM1 As Double
        Dim SUM2 As Double
        Dim strsql As New SqlCommand("SELECT Sum(Loa6) FROM LoansPa WHERE Lo ='" & Me.TextDebtNumber.Text & "'", Consum)
        Dim ds2 As New DataSet
<<<<<<< HEAD
        Adp = New SqlDataAdapter(strsql)
=======
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds2.Clear()
        Adp.Fill(ds2)
        If ds2.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds2.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Adp.Dispose()
        SUM2 = Format(Val(Me.TextTotalDebt.Text) - (Val(SUM1) + Val(Me.TextMonthlyInstallment.Text)), "#,#0.00")
        Me.TextNetDebt.Text = Val(SUM2)
        Consum.Close()

    End Sub

    Private Sub InternalAuditorBalance()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT sum(Loa6)  FROM LoansPa  WHERE LoansPa.Lo='" & Me.TextDebtNumber.Text & "'AND LoansPa.Loa1 <'" & Me.TextDocumentNumber1.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsq1)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT sum(Loa6)  FROM LoansPa  WHERE LoansPa.Lo='" & Me.TextDebtNumber.Text & "'AND LoansPa.Loa1 <'" & Me.TextDocumentNumber1.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp1.Fill(ds, "LoansPa")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextNetDebt.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            Me.TextNetDebt.Text = "0"
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CmdSave.Click
=======
    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockSave = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If

        Dim p As String
        If myds.Tables("LoansPa").Compute("Count(Loa1)", "Loa7 ='" & Me.TextMonthlyInstallment.Text.Trim.ToLower & "'").ToString > 0 Then
            p = " „ «· ”œÌœ"
        ElseIf myds.Tables("LoansPa").Compute("Count(Loa1)", "Loa7 >'" & Me.TextMonthlyInstallment.Text.Trim.ToLower & "'").ToString > 0 Then
            p = "·„ Ì”œ«œ ﬂ«„· «·«ﬁ”ÿ"
        Else
            p = "·„ Ì „ «· ”œÌœ"
        End If
        If Me.ComboCB1.Text = Nothing Then
            MsgBox("ÌÃ» «Œ Ì«— «·’‰œÊﬁ", 16, " ‰»ÌÂ")
            ComboCB1.Focus()
            Exit Sub
        End If
        Static P1 As Integer
        P1 = Me.BS.Count
        SumAmount()
        'Me.GETBANKNOWBALANCE()

        Me.TextPaymentStatus.Text = p.Trim.ToLower
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
<<<<<<< HEAD
        ButtonViewrestrictions.PerformClick()
=======

>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'Me.Cursor = Cursors.WaitCursor
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
        Click1 = True

    End Sub

<<<<<<< HEAD
    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CmdCancel.Click
=======
    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.CancelEdit()
    End Sub

<<<<<<< HEAD
    Private Sub TextBox3_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextMonthlyInstallment.TextChanged
=======
    Private Sub TextBox3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextMonthlyInstallment.TextChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        'Dim x As Double = Val(Me.TextBox8.Text)
        'Me.TextBox8.Text = Format(Val(x) - Val(Me.TextBox3.Text), "0.000")
        ' TextBox12.Text = Format(Val(TextBox7.Text), "0.000")
        Me.TextMonthlyInstallmentN.Text = CurrencyJO(Me.TextMonthlyInstallment.Text, "jO")
        Me.TextNetDebtN.Text = CurrencyJO(Me.TextNetDebt.Text, "jO")
        'Me.InternalAuditorBalance()
    End Sub

<<<<<<< HEAD
    Private Sub TEXTBOX4_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextDocumentNumber.KeyPress
=======
    Private Sub TEXTBOX4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextDocumentNumber.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TextDocumentNumber.Text <> "" Then
                    Me.TextMonthlyInstallment.Focus()
                Else
                    Me.TextDocumentNumber.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub

<<<<<<< HEAD
    Private Sub TEXTBOX3_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextMonthlyInstallment.KeyPress
=======
    Private Sub TEXTBOX3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextMonthlyInstallment.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.TextMonthlyInstallment.Text <> "" Then
                    Me.DatePayment.Focus()
                Else
                    Me.TextMonthlyInstallment.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub

<<<<<<< HEAD
    Private Sub MTextBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles DatePayment.KeyPress
=======
    Private Sub MTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatePayment.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Asc(e.KeyChar) = 13 Then
                If Me.DatePayment.Text <> "" Then
                    Me.CmdSave_Click(sender, e)
                Else
                    Me.DatePayment.Focus()
                End If
                e.Handled = True
            End If
        End If
    End Sub

<<<<<<< HEAD
    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
        On Error Resume Next
=======
    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
        On Error Resume Next
        Dim HeightInInch As Double
        HeightInInch = (phieght * 0.24096) + 0.90921
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
<<<<<<< HEAD

        Dim rpt As New rptcashA
        Dim F As New FrmPRINT
        Dim txt As TextObject
        Dim Consum As New SqlConnection(constring)
        GETSERVERNAMEANDDATABASENAME(rpt, DBServer.Trim, "", "")
        Dim ds As New DataSet
        Dim str As New SqlCommand("SELECT * FROM LoansPa  WHERE (LoansPa.LO) ='" & Me.TextDebtNumber.Text & "' AND Loa=" & Me.TextContractNumber.Text, Consum)
        SqlDataAdapter1 = New SqlDataAdapter(str)
        ds.Clear()
        If Consum.State = ConnectionState.Closed Then Consum.Open()
        SqlDataAdapter1.Fill(ds, "LoansPa")
        If ds.Tables(0).Rows.Count > 0 Then
            rpt.SetDataSource(ds)
            txt = rpt.Section1.ReportObjects("TEXT2")
            txt = rpt.Section1.ReportObjects("AssociationName")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Character")
            txt.Text = Character

            txt = rpt.Section1.ReportObjects("Directorate")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("Recorded")
            txt.Text = Recorded
            txt = rpt.Section1.ReportObjects("Adrss")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            F.CrystalReportViewer1.ReportSource = rpt
            F.CrystalReportViewer1.Zoom(90%)
            F.CrystalReportViewer1.Refresh()
            F.Show()
        Else
            MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        If Consum.State = ConnectionState.Open Then Consum.Close()
=======
        Dim rpt As New rptcashA
            Dim F As New FrmPRINT
            Dim txt As TextObject
            Dim Consum As New SqlClient.SqlConnection(constring)
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlClient.SqlCommand("SELECT * FROM LoansPa  WHERE (LoansPa.LO) ='" & Me.TextDebtNumber.Text & "' AND Loa=" & Me.TextContractNumber.Text, Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "LoansPa")
            If ds.Tables(0).Rows.Count > 0 Then
                rpt.SetDataSource(ds)
                txt = rpt.Section1.ReportObjects("TEXT2")
                txt = rpt.Section1.ReportObjects("TEXT7")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT42")
                txt.Text = Character

                txt = rpt.Section1.ReportObjects("TEXT9")
                txt.Text = Directorate
                txt = rpt.Section1.ReportObjects("TEXT44")
                txt.Text = Recorded
                txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("TEXT18")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("TEXT6")
            txt.Text = Character

            txt = rpt.Section1.ReportObjects("TEXT19")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("Text49")
            txt.Text = Recorded
            txt = rpt.Section1.ReportObjects("Text45")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            F.CrystalReportViewer1.ReportSource = rpt
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.Refresh()
                F.Show()
            Else
                MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & ex.Source)
        'End Try
    End Sub

<<<<<<< HEAD
    Private Sub CustomerPay_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
=======
    Private Sub CustomerPay_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Consum.Close()
    End Sub

    Private Sub DELETEDATAempsolf()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim sql As String = "DELETE FROM CASHIER  WHERE CSH4 = '" & Me.TextMovementSymbol.Text.ToString & "'"
            Dim cmd As New SqlCommand(sql, Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim sql As String = "DELETE FROM CASHIER  WHERE CSH4 = '" & Me.TextMovementSymbol.Text.ToString & "'"
            Dim cmd As New SqlClient.SqlCommand(sql, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = "—ﬁ„" & Me.TextDebtNumber.Text & "   » «—ÌŒ:" & Me.DatePayment.Text
        ExResult += "   Õ”«» " & nem.Trim & vbNewLine
        Me.Text = ExResult
    End Sub



    Private Sub UPDATELoans()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" UPDATE  LoansPa SET  Loa14 = @Loa14  WHERE Loa1 = '" & TextDocumentNumber1.Text & "'", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" UPDATE  LoansPa SET  Loa14 = @Loa14  WHERE Loa1 = '" & TextDocumentNumber1.Text & "'", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@Loa14", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferToAccounts.Checked)
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub



    Private Sub TransforAccounts()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing

        nem = " ”œ«œ ‰ﬁœÌ „‰ «ﬁ”«ÿ «·ﬁ—÷ —ﬁ„" & " " & "_" & " " & Me.TextDebtNumber.Text.Trim
        nem1 = " ”œ«œ „‰ «·ﬁ—÷ —ﬁ„" & " " & "_" & " " & Me.TextDebtNumber.Text.Trim
        PMO2 = 1

        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_no = FundAccount_No

        DebitAccount_No = keyAccounts.GetValue("ReceivablesAccount_No", ReceivablesAccount_No)
        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", DebitAccount_No, 1)
        DebitAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", DebitAccount_No, 1)
        DebitAccount_Cod = ID_Nam

        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", Accounts_no, 1)
        FundAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
        CodAccount = ID_Nam

        SEARCHDATA.MAXIDMOVES()
        CheckTransferToAccounts.Checked = True

        AccountingEntries(T1, T2, DatePayment.Text, nem, False, TextMonthlyInstallment.Text, TextMonthlyInstallment.Text, T3, "ﬁ»÷", "PA", TextMovementSymbol.Text, False)

        DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_no, TextMonthlyInstallment.Text, 0, nem, CodAccount, TextMovementSymbol.Text, TextDebtNumber.Text, False, T2)
        DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, 0, TextMonthlyInstallment.Text, nem1, DebitAccount_Cod, TextMovementSymbol.Text, TextDebtNumber.Text, False, T2)

        Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "ﬁ»÷", TextMovementSymbol.Text, TextMonthlyInstallment.Text, 0, Me.Text,
                                              "„‰ Õ”«» Õ—ﬂ… «·⁄„Ì· «”„ Ê —ﬁ„ " & " _ " & Me.TextCustomerNumber.Text & "_" & Me.TextCustomerName.Text, False, TextDocumentNumber.Text,
                                              False, True, ComboCB1.Text, ModuleGeneral.CB2)


    End Sub



    Private Sub DELETEDATMOVESDATA()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA1()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVESFalseDELET, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Sub AccountingprocedureA()
        If Accountingprocedure = True Then
            Connection.ACONET1.Clear()
            Connection.ACONET1.Add("«·’‰œÊﬁ")
            Connection.ACONET1.Add(String.Concat(New String() {DebitAccount_Name}))
            Dim CountACONET As Integer
            Dim CountACONET1 As Integer
            Dim ACONETs0 As String
            Dim ACONETs1 As String
            Dim ACONETs2 As String
            Dim ACONETs3 As String
            Dim ACONETs4 As String
            For x1 As Integer = 0 To Connection.ACONET1.Count - 1
                CountACONET1 = x1
            Next
            Me.ACONETA.Clear()
            Connection.ACONET2.Clear()
            For x As Integer = 0 To Connection.ACONET.Count - 1
                CountACONET = x
                If CountACONET = 0 Then
                    Connection.ACONET2.Add(Connection.ACONET(x) & Connection.ACONET1(x))
                ElseIf CountACONET = 1 Then
                    If CountACONET1 = 1 Then
                        Connection.ACONET2.Add(Connection.ACONET(x) & Connection.ACONET1(x))
                    Else
                        ACONETs0 = Mid(Connection.ACONET(x), 18, 23)
                        Connection.ACONET2.Add("3- " & " „ Õ–› Õ”«»" & " " & ACONETs0)
                    End If
                ElseIf CountACONET = 2 Then
                    If CountACONET1 = 2 Then
                        Connection.ACONET2.Add(Connection.ACONET(x) & Connection.ACONET1(x))
                    Else
                        ACONETs1 = Mid(Connection.ACONET(x), 18, 23)
                        Connection.ACONET2.Add("3- " & " „ Õ–› Õ”«»" & " " & ACONETs1)
                    End If
                ElseIf CountACONET = 3 Then
                    If CountACONET1 = 3 Then
                        Connection.ACONET2.Add(" „ Õ–› Õ”«»" & "" & Connection.ACONET(3))
                    Else
                        ACONETs2 = Mid(Connection.ACONET(x), 18, 23)
                        Connection.ACONET2.Add("4- " & " „ Õ–› Õ”«»" & " " & ACONETs2)
                    End If
                ElseIf CountACONET = 4 Then
                    If CountACONET1 = 4 Then
                        Connection.ACONET2.Add(" „ Õ–› Õ”«»" & "" & Connection.ACONET(4))
                    Else
                        ACONETs3 = Mid(Connection.ACONET(x), 18, 23)
                        Connection.ACONET2.Add("4- " & " „ Õ–› Õ”«»" & " " & ACONETs3)
                    End If
                ElseIf CountACONET = 5 Then
                    If CountACONET1 = 5 Then
                        Connection.ACONET2.Add(" „ Õ–› Õ”«»" & "" & Connection.ACONET(5))
                    Else
                        ACONETs4 = Mid(Connection.ACONET(x), 18, 23)
                        Connection.ACONET2.Add("5- " & " „ Õ–› Õ”«»" & " " & ACONETs4)
                    End If
                End If
                If Not IsNothing(Connection.ACONET) Then
                    Me.ACONETA.AppendText(Connection.ACONET2(x) & vbCrLf)
                End If
                Connection.ACONET3 = Me.ACONETA.Text.Trim
            Next
            UPDATE_Auditorsnotes()
        End If
    End Sub


    Private Sub ButtonCUSTOMER1_Click()
        Try

            Dim resault As Integer
            If Me.CheckTransferToAccounts.Checked = False Then
                resault = MessageBox.Show("  ”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï Õ—ﬂ… «·’‰œÊﬁ " & "··⁄„Ì· " & Me.TextCustomerName.Text, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.CheckTransferToAccounts.Checked = True
                    TransforAccounts()
                    Me.LablAA.Visible = True
                    Me.LabStatus.Visible = True
                    Me.LabStatus.Text = " „  ⁄„·Ì…  —ÕÌ· «·»Ì«‰«  »‰Ã«Õ"
                Else
                    Cancel = True
                    Exit Sub
                End If

            Else
                resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If Me.TextMovementRestrictions.Text = "" Then
                        MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                    Else
                        Me.DELETEDATMOVESDATA()
                        Me.DELETEDATMOVESDATA1()
                    End If
                    If Me.TextFundMovementNumber.Text = "" Then
                        MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì Õ—ﬂ«  «·’‰œÊﬁ", 16, " ‰»Ì…")
                    Else
                        Me.DELETEDATAempsolf()
                    End If
                    TransforAccounts()
                    Me.LablAA.Visible = True
                    Me.LabStatus.Visible = True
                    Me.LabStatus.Text = " „  ⁄„·Ì…  —ÕÌ· «·»Ì«‰«  »‰Ã«Õ"
                    AccountingprocedureA()
                Else
                    resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· Õ—ﬂ… «·’‰œÊﬁ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextFundMovementNumber.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì Õ—ﬂ«  «·’‰œÊﬁ", 16, " ‰»Ì…")
                        Else
                            Me.DELETEDATAempsolf()
                        End If
                        If Me.TextMovementRestrictions.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                        Else
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                        End If
                        Me.CheckTransferToAccounts.Checked = False
                        Me.LablAA.Visible = True
                        Me.LabStatus.Visible = True
                        Me.LabStatus.Text = " „  ⁄„·Ì…  ≈·€«¡  —ÕÌ· «·»Ì«‰«  »‰Ã«Õ"
                    Else
                        Cancel = True
                        Exit Sub
                    End If
                End If
            End If
            UPDATELoans()
            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "LoansPa")

        Catch ex As Exception

        End Try


    End Sub



<<<<<<< HEAD
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonUpdateA.Click
=======
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateA.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Me.TextCustomerNumber.Clear()
            Me.PictureBox2.Visible = True
<<<<<<< HEAD
            Me.RefreshTab = New ComponentModel.BackgroundWorker With {
=======
            Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.RefreshTab.RunWorkerAsync()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


<<<<<<< HEAD
    Private Sub ButtonViewrestrictions_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewrestrictions.Click
        SEARCHDATA.Account_Name = SEARCHDATA.Account_Name
        SEARCHDATA.MaxIDMoves()
=======
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewrestrictions.Click
        SEARCHDATA.account_name = SEARCHDATA.account_name
        SEARCHDATA.MAXIDMOVES()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.Text)
        Me.TextMovementRestrictions.Text = SEARCHDATA.MOV1C
        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.Text)
        Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
        SEARCHDATA.SEARCHCASHIER1(Me.TextMovementSymbol.Text, Me.TextDocumentNumber.Text)
        Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1B
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
        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_no = FundAccount_No

        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", Accounts_no, 1)
        FundAccount_Name = ID_Nam

        FundBalance()

        LabelFundBalance.Text = "—’Ìœ" & " " & FundAccount_Name & " " & ":"
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

End Class