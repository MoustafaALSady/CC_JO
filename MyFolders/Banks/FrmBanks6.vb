Option Explicit Off

Imports System.Data.SqlClient
Public Class FrmBanks6
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    ReadOnly myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0

    Private Sub FrmBanks6_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Try
            Select Case CInt(e.KeyCode)
                Case Keys.F1
                    ADDBUTTON_Click(sender, e)
                Case Keys.F2
                    SAVEBUTTON_Click(sender, e)
                    Exit Select
            End Select
            e.Handled = True
        Catch exception1 As Exception
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
        End Try
    End Sub
    Private Sub MAXRECORD()
        On Error Resume Next
        Dim N As Double
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        If IsDBNull(resualt) Then
            N = 1
        Else
            N = CType(resualt, Integer) + 1
        End If
        Consum.Close()
        Me.TEXTID.EditValue = Val(N)
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub
    Private Sub InternalAuditorBalance()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsq1 As New SqlCommand("SELECT Sum(CASHIER.CSH7) AS SumDEBIT,Sum(CASHIER.CSH8) AS SumCREDIT FROM CASHIER  WHERE CUser='" & CUser & "' and  (CASHIER.CSH18)='" & Me.ComboCB1.Text & "' AND CASHIER.CSH1 <'" & Me.TEXTID.EditValue & "'", Consum)
            '(CASHIER.CSH18)='" & Me.ComboCB1.Text & "'AND CASHIER.CSH1 <'" & Me.TEXT1.Text & "'", Consum)
            'Dim strsql As New SqlCommand("SELECT Sum(CSH7-CSH8)   FROM CASHIER WHERE CUser='" & CUser & "' and Year(CSH2)  ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and (CSH18) =  '" & Me.TextCB2.Text & "'AND CSH1  <'" & Me.TEXT1.Text & "'", Consum)
            Dim ds As New DataSet
            Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
            ds.Clear()
            Adp1.Fill(ds, "CASHIER")
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TEXTPreviousBalance.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)) - Val(ds.Tables(0).Rows(0).Item(1)), "0.000")
            Else

            End If
            Adp1.Dispose()
            Consum.Close()

            'Dim Consum As New SqlClient.SqlConnection(constring)
            'Dim N As Double
            'Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
            'If Consum.State = ConnectionState.Open Then Consum.Close()
            'Consum.Open()
            'Dim resualt As Object = cmd1.ExecuteScalar()
            'If IsDBNull(resualt) Then
            '    N = 1
            'Else
            '    N = CType(resualt, Integer)
            'End If
            'Consum.Close()
            'Me.TEXT3.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
        Catch ex As Exception
            Me.TEXTPreviousBalance.Text = "0"
        End Try
    End Sub

    Private Sub TEXT3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCB1.TextChanged, TEXTPreviousBalance.TextChanged, TEXTCurrentBalance.TextChanged, TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged
        On Error Resume Next
        Me.InternalAuditorBalance()
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTDebit.EditValue) - Val(Me.TEXTCredit.EditValue), "0.000")

    End Sub
    Private Sub FrmBanks6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub ADDBUTTON_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
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
            Me.BS.EndEdit()
            Me.BS.AddNew()
            CLEARDATA1(Me)

            GetAutoNumber("CSH1", "CASHIER", "CSH2")
            Me.TEXTID.EditValue = AutoNumber

            SEARCHDATA.MAXIDCASHIER()
            Me.TEXTDocumentNumber.Text = SEARCHDATA.BoxDocumentNumber
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            Me.TextMovementSymbol.EditValue = "CH" & Me.TEXTID.EditValue
            Me.DateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
            Me.TextDateMovementHistory.Text = Me.DateMovementHistory.Text
            Me.ComboMotionSource.Text = "الصندوق"
            Me.ComboConstraintType.Text = "صرف"

            Me.ComboPaymentMethod.Text = "نقداً"
            Me.TEXTDebit.EditValue = "0.000"
            Me.TEXTCredit.EditValue = "0.000"
            Me.ComboDetails.Text = "صرف  نقدي"
            Me.TEXTStatement.Text = "صرف  نقدي"
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            Dim Sound As System.IO.Stream = My.Resources.addv
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorADDBUTTON.Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockSave = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Count
        Me.TEXTCurrentBalance.Text = Format(Val(TEXTPreviousBalance.Text) - Val(TEXTCredit.EditValue) + Val(TEXTDebit.EditValue), "0.000")
        Me.BS.EndEdit()
        Me.RowCount = BS.Count
        Me.DateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
        Me.SAVERECORD()
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Me.SAVEBUTTON.Enabled = False
        Click1 = True
    End Sub
    Private Sub SAVERECORD()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO CASHIER(  CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH14, CSH15, CSH16, CSH17, CSH18, CSH19, USERNAME, CUser, COUser, da, ne) VALUES     (  @CSH1, @CSH2, @CSH3, @CSH4, @CSH5, @CSH6, @CSH7, @CSH8, @CSH9, @CSH10, @CSH11, @CSH12, @CSH14, @CSH15, @CSH16, @CSH17, @CSH18, @CSH19, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CSH1", SqlDbType.BigInt).Value = Me.TEXTID.EditValue
                .Parameters.Add("@CSH2", SqlDbType.NVarChar).Value = Me.TextDateMovementHistory.Text
                .Parameters.Add("@CSH3", SqlDbType.NVarChar).Value = Me.ComboConstraintType.Text
                .Parameters.Add("@CSH4", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CSH5", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@CSH6", SqlDbType.NVarChar).Value = Format(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, TEXTID.EditValue), "0.000")
                .Parameters.Add("@CSH7", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@CSH8", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@CSH9", SqlDbType.NVarChar).Value = Format(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, TEXTID.EditValue), "0.000")
                .Parameters.Add("@CSH10", SqlDbType.NVarChar).Value = Me.ComboMotionSource.Text
                .Parameters.Add("@CSH11", SqlDbType.NVarChar).Value = Me.ComboDetails.Text
                .Parameters.Add("@CSH12", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@CSH14", SqlDbType.Bit).Value = False
                .Parameters.Add("@CSH15", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@CSH16", SqlDbType.Bit).Value = False
                .Parameters.Add("@CSH17", SqlDbType.Bit).Value = False

                .Parameters.Add("@CSH18", SqlDbType.Int).Value = Me.ComboCB1.Text
                .Parameters.Add("@CSH19", SqlDbType.NVarChar).Value = Me.TextCB2.Text


                'insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), ComboConstraintType.Text, TextMovementSymbol.EditValue, TEXTDebit.EditValue, TEXTCredit.EditValue, ComboMotionSource.Text,
                '                            ComboDetails.Text, False, TEXTDocumentNumber.Text,
                '                             False, True, ComboCB1.Text, TextCB2.Text)





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
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:
            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()

            'SqlDataAdapter1.Update(myds, "CASHIER")
            'myds = New DataSet
            'SqlDataAdapter1.Fill(myds, "CASHIER")
            'myds.RejectChanges()
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
                PictureBox2False()
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
            Application.DoEvents()
            Me.BS.DataSource = myds.Tables("CASHIER")
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False

            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
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
            ElseIf Click4 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click5 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click6 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click7 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "ترحيل االى حركة عهدة الموظفين", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click8 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل حركة عهدة الموظفين", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click9 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل حركة عهدة الموظفين", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click10 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "المراجع", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click11 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "إلغاء المراجعة", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            End If
            Click1 = False
            Click2 = False
            Click3 = False
            Click4 = False
            Click5 = False
            Click6 = False
            Click7 = False
            Click8 = False
            Click9 = False
            Click10 = False
            Click11 = False
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
            Me.PictureBox2.Visible = False
            Me.PictureBox5.Visible = False
        End If
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
            Me.TextCB2.Text = ds.Tables(0).Rows(0).Item(0)

        Else
            Me.TextCB2.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

    Private Sub ComboConstraintType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboConstraintType.SelectedIndexChanged
        If Me.ComboConstraintType.Text = "قبض" Then
            Me.TEXTDebit.Enabled = True
            Me.TEXTCredit.EditValue = "0"
            Me.TEXTCredit.Enabled = False
        ElseIf Me.ComboConstraintType.Text = "صرف" Then
            Me.TEXTCredit.Enabled = True
            Me.TEXTDebit.EditValue = "0"
            Me.TEXTDebit.Enabled = False
        End If
    End Sub


End Class