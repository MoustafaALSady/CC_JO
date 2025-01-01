Option Explicit Off

Imports System.Data.SqlClient
Public Class FrmJO1
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    ReadOnly myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0

    Private Sub FrmJO1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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


    Private Sub FrmJO1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            Me.SHOWBUTTON()
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            CLEARDATA1(Me)

            GetAutoNumber("EBNK1", "BANKJO", "EBNK3")
            Me.TEXTID.EditValue = AutoNumber
            Me.TextMovementSymbol.EditValue = "BA" & Me.TEXTID.EditValue
            Me.DateMovementHistory.Value = MaxDate.ToString("yyyy-MM-dd")
            Me.TextDateMovementHistory.Text = Me.DateMovementHistory.Text
            FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.TEXTBN2)
            Me.TEXTBN2.SelectedIndex = 0
            Me.TEXTDebit.EditValue = 0
            Me.TEXTCredit.EditValue = 0
            Me.ComboConstraintType.Text = "ايداع"
            Me.TEXTDocumentNumber.Text = "0"
            Me.TEXTStatement.Text = "ايداع في البنك"
            DateMovementHistory.Focus()

            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            Dim Sound As System.IO.Stream = My.Resources.addv
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
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
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockSave = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Me.SAVEBUTTON.Enabled = False

        Static P As Integer
        P = Me.BS.Count
        Me.SAVERECORD()
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
            BS.DataSource = myds.Tables("BANKJO")
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
            Me.PictureBox2.Visible = False
            Me.PictureBox5.Visible = False
        End If
    End Sub

    Private Sub SAVERECORD()
        Try

            Dim Consum As New SqlClient.SqlConnection(constring)

            Dim SQL As String = "INSERT INTO BANKJO(  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16, USERNAME, CUser, COUser, da, ne) VALUES     (  @EBNK1, @EBNK2, @EBNK3, @EBNK4, @EBNK5, @EBNK6, @EBNK7, @EBNK8, @EBNK9, @EBNK10, @EBNK11, @EBNK12, @EBNK13, @EBNK14, @EBNK15, @EBNK16, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum

                .Parameters.Add("@EBNK1", SqlDbType.Int).Value = Me.TEXTID.EditValue
                .Parameters.Add("@EBNK2", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text
                .Parameters.Add("@EBNK3", SqlDbType.Date).Value = Me.TextDateMovementHistory.Text
                .Parameters.Add("@EBNK4", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@EBNK5", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@EBNK6", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@EBNK7", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text
                .Parameters.Add("@EBNK8", SqlDbType.NVarChar).Value = Me.ComboConstraintType.Text
                .Parameters.Add("@EBNK9", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@EBNK10", SqlDbType.NVarChar).Value = Me.TEXTBN2.Text
                .Parameters.Add("@EBNK11", SqlDbType.NVarChar).Value = Me.TextBN3.Text
                .Parameters.Add("@EBNK12", SqlDbType.Bit).Value = False
                .Parameters.Add("@EBNK13", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@EBNK14", SqlDbType.Bit).Value = False
                .Parameters.Add("@EBNK15", SqlDbType.Bit).Value = False
                .Parameters.Add("@EBNK16", SqlDbType.Bit).Value = False

                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
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

    Private Sub TEXTBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEXTBN2.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT BN3    FROM BankNames WHERE BN2 ='" & Me.TEXTBN2.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextBN3.Text = ds.Tables(0).Rows(0).Item(0)

        Else
            Me.TextBN3.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

    Private Sub TEXTBOX8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboConstraintType.SelectedIndexChanged
        On Error Resume Next
        Select Case Me.ComboConstraintType.Text
            Case "ايداع"
                Me.TEXTDebit.Enabled = True
                Me.TEXTCredit.EditValue = 0
                Me.TEXTCredit.Enabled = False
            Case "سحب"
                Me.TEXTDebit.Enabled = False
                Me.TEXTDebit.EditValue = 0
                Me.TEXTCredit.Enabled = True
        End Select
    End Sub


End Class