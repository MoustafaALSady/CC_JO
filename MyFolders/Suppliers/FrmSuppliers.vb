Option Explicit Off
Imports System.Data.SqlClient
Imports System.Diagnostics

Public Class FrmSuppliers
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
    Public TB1 As String
    Public TB2 As String
    Private Sub TEXTBOX1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub FrmSuppliers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F3
                    Me.EDITBUTTON_Click(sender, e)
                Case Keys.F4
                    Me.BUTTONCANCEL_Click(sender, e)
                Case Keys.F6
                    Me.DELETEBUTTON_Click(sender, e)
                Case Keys.F9
                    Me.EMAILBUTTON_Click(sender, e)
                Case Keys.F10
                    Me.NETBUTTON_Click(sender, e)
                Case Keys.F12
                    Me.ButtonXP1_Click(sender, e)
                Case Keys.PageDown
                    Me.PREVIOUSBUTTON_Click(sender, e)
                Case Keys.PageUp
                    Me.NEXTBUTTON_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmSUPPLIER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.EDITBUTTON.Enabled = False
        Me.BUTTONCANCEL.Enabled = False
        Me.DELETEBUTTON.Enabled = False
        Me.ButtonResourcePayment.Enabled = False
        Me.EMAILBUTTON.Enabled = False
        Me.NETBUTTON.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
        Me.BackWorker2 = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.BackWorker2.RunWorkerAsync()
        Me.load1.Enabled = False

    End Sub
    Private Sub BackWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker2.DoWork
        Try
1:

            Dim Consum As New SqlClient.SqlConnection(constring)
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Me.myds.EnforceConstraints = False
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = String.Concat(New String() {"SELECT  sup1, sup2, sup3, sup4, sup5, sup7, USERNAME, Auditor, Cuser, COUser, da, ne FROM SUPPLIER  WHERE  CUser='", ModuleGeneral.CUser, "' and sup1 ='", Strings.Trim(Me.TB1), "' or sup3 ='", Strings.Trim(Me.TB2), "' ORDER BY sup1"})
            End With
            Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
            Me.myds = New DataSet
            If Consum.State = ConnectionState.Closed Then Consum.Open()
            Me.SqlDataAdapter1.TableMappings.Add("Table1", "SUPPLIER")
            Me.SqlDataAdapter1.Fill(Me.myds, "SUPPLIER")
            Me.myds.RejectChanges()
            If Consum.State = ConnectionState.Open Then Consum.Close()
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub BackWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker2.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.myds.Tables("SUPPLIER")
            Me.RowCount = Me.BS.Count
            With Me
                .TEXTBOX1.DataBindings.Add("text", BS, "sup1", True, 1, "")
                .TEXTAgentName.DataBindings.Add("text", BS, "sup2", True, 1, "")
                .TEXTSupplierName.DataBindings.Add("text", BS, "sup3", True, 1, "")
                .TEXTPHONE.DataBindings.Add("text", BS, "sup4", True, 1, "")
                .TextE_mail.DataBindings.Add("text", BS, "sup5", True, 1, "")
                .TextITEMNAME.DataBindings.Add("text", BS, "sup7", True, 1, "")
                .TEXTUserName.DataBindings.Add("text", BS, "USERNAME", True, 1, "")
                .TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
                .TextDefinitionDirectorate.DataBindings.Add("text", BS, "COUser", True, 1, "")
                .TEXTAddDate.DataBindings.Add("text", BS, "da", True, 1, "")
                .TextTimeAdd.DataBindings.Add("text", BS, "ne", True, 1, "")
            End With
            Me.TxtSearch.DataSource = myds.Tables("SUPPLIER")
            Me.TxtSearch.DisplayMember = "sup2"
            Me.ListBox1.DataSource = myds.Tables("SUPPLIER")
            Me.ListBox1.DisplayMember = "sup2"
            Call MangUsers()
            Me.RecordCount()
            Me.SHOWBUTTON()
            Me.BUTTONCANCEL.Enabled = True
            Me.LabelLoadDataBase.Visible = False
            Call CloseDB()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load1.Click
        On Error Resume Next
        Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()
        Me.load1.Enabled = False
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:

            Dim Consum As New SqlClient.SqlConnection(constring)
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Me.myds.EnforceConstraints = False
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = String.Concat(New String() {"SELECT  sup1, sup2, sup3, sup4, sup5, sup7, USERNAME, Auditor, Cuser, COUser, da, ne FROM SUPPLIER  WHERE  CUser='", ModuleGeneral.CUser, "'and sup1 ='", Strings.Trim(Me.TB1), "' or sup3 ='", Strings.Trim(Me.TB2), "'ORDER BY sup1"})
            End With
            Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
            Me.myds = New DataSet
            If Consum.State = ConnectionState.Closed Then Consum.Open()
            Me.SqlDataAdapter1.TableMappings.Add("Table1", "SUPPLIER")
            Me.SqlDataAdapter1.Fill(Me.myds, "SUPPLIER")
            Me.myds.RejectChanges()
            If Consum.State = ConnectionState.Open Then Consum.Close()
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then
                Me.LabelLoadDataBase.Visible = True
                Me.LabelLoadDataBase.ForeColor = Color.Yellow
                Me.LabelLoadDataBase.Text = "..  „ «·« ’«· »«·«‰ —‰  .. Ì „ «·«‰  Õ„Ì· ”Ã·«  «·ﬁ«⁄œ…"
            Else
                Me.LabelLoadDataBase.ForeColor = Color.Red
                Me.LabelLoadDataBase.Text = "«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—"
                Me.Close()
            End If
        End If
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.myds.Tables("SUPPLIER")
            Me.RowCount = Me.BS.Count
            With Me
                .TEXTBOX1.DataBindings.Add("text", BS, "sup1", True, 1, "")
                .TEXTAgentName.DataBindings.Add("text", BS, "sup2", True, 1, "")
                .TEXTSupplierName.DataBindings.Add("text", BS, "sup3", True, 1, "")
                .TEXTPHONE.DataBindings.Add("text", BS, "sup4", True, 1, "")
                .TextE_mail.DataBindings.Add("text", BS, "sup5", True, 1, "")
                .TextITEMNAME.DataBindings.Add("text", BS, "sup7", True, 1, "")
                .TEXTUserName.DataBindings.Add("text", BS, "USERNAME", True, 1, "")
                .TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
                .TextDefinitionDirectorate.DataBindings.Add("text", BS, "COUser", True, 1, "")
                .TEXTAddDate.DataBindings.Add("text", BS, "da", True, 1, "")
                .TextTimeAdd.DataBindings.Add("text", BS, "ne", True, 1, "")
            End With
            Me.TxtSearch.DataSource = myds.Tables("SUPPLIER")
            Me.TxtSearch.DisplayMember = "sup2"
            Me.ListBox1.DataSource = myds.Tables("SUPPLIER")
            Me.ListBox1.DisplayMember = "sup2"
            Call MangUsers()
            Me.RecordCount()
            Me.SHOWBUTTON()
            Me.BUTTONCANCEL.Enabled = True
            Me.LabelLoadDataBase.Visible = False
            Call CloseDB()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UPDATERECORD()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As String = " Update SUPPLIER SET   sup2 = @sup2, sup3 = @sup3, sup4 = @sup4, sup5 = @sup5, sup7 = @sup7 WHERE sup1 = @sup1"
        Dim CMD As New SqlClient.SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@sup1", SqlDbType.Int).Value = Me.TEXTBOX1.Text
            .Parameters.Add("@sup2", SqlDbType.NVarChar).Value = Me.TEXTAgentName.Text
            .Parameters.Add("@sup3", SqlDbType.NVarChar).Value = Me.TEXTSupplierName.Text
            .Parameters.Add("@sup4", SqlDbType.NVarChar).Value = Me.TEXTPHONE.EditValue
            .Parameters.Add("@sup5", SqlDbType.NVarChar).Value = Me.TextE_mail.EditValue
            .Parameters.Add("@sup7", SqlDbType.NVarChar).Value = Me.TextITEMNAME.Text
            .CommandText = SQL
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        CMD.ExecuteNonQuery()
        Consum.Close()
    End Sub

    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " „‰ " & Me.BS.Count
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:
            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.Update(myds, "SUPPLIER")
            'myds = New DataSet
            'SqlDataAdapter1.Fill(myds, "SUPPLIER")
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
                MsgBox("ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› «·”Ã· «·„Õœœ" & vbCrLf & "”Ê› Ì „  ÕœÌÀ «·”Ã·«  «·¬‰", 16, " ‰»ÌÂ")
            Else
                e.Cancel = True
                PictureBox2False()
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                'Button9.PerformClick()
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = Me.myds.Tables("SUPPLIER")

            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.Count()
            If Me.BS.Count < Me.RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & Me.RowCount - Me.BS.Count, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            ElseIf BS.Count > RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & Me.BS.Count - Me.RowCount, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")

                Exit Sub
            End If
            Dim Sound As System.IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            If Click1 = True Then
                Try
                    Insert_Actions(Me.TEXTBOX1.Text, "Õ›Ÿ", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click2 = True Then
                Try
                    Insert_Actions(Me.TEXTBOX1.Text, " ⁄œÌ·", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            End If
            Click1 = False
            Click2 = False
            MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
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
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.ButtonResourcePayment.Enabled = LockUpdate
        Me.EMAILBUTTON.Enabled = True
        Me.NETBUTTON.Enabled = True
    End Sub
    Private Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " „‰ " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.myds.Tables("SUPPLIER").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
    End Sub
    Private Sub NETBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NETBUTTON.Click
        On Error Resume Next
        Dim CON As Integer
        Dim s As String
        If Len(Me.TEXTPHONE.EditValue) > 0 Then
            CON = ShellExecute(0, vbNullString, Me.TEXTPHONE.EditValue, vbNullString, "C:\", SW_SHOWNORMAL)
        Else
            s = InputBox("„‰ ›÷·ﬂ «œŒ· ⁄‰Ê«‰ «·„Êﬁ⁄ ⁄·Ï «·«‰ —‰ ", "«·« ’«· »«·«‰ —‰ ", "http://www.")
            CON = ShellExecute(0, vbNullString, s, vbNullString, "C:\", SW_SHOWNORMAL)
        End If
    End Sub
    Private Sub EMAILBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EMAILBUTTON.Click
        On Error Resume Next
        'Dim CON As Integer
        'Dim s As String
        'If Len(Me.TEXTBOX4.Text) > 0 Then
        '    CON = ShellExecute(0, vbNullString, "http://by20fd.bay20.hotmail.msn.com/cgi-bin/compose?&esus=1&curmbox=F000000001&a=99cef75e7433353215cf31134942a5f1d4fc5a0a6e79a1f301bb31372b48b321", vbNullString, "C:\", SW_SHOWNORMAL)
        'Else
        '    s = InputBox("„‰ ›÷·ﬂ «œŒ· ⁄‰Ê«‰ «·„Êﬁ⁄ ⁄·Ï «·«‰ —‰ ", "«·« ’«· »«·«‰ —‰ ", "http://www.")
        '    CON = ShellExecute(0, vbNullString, s, vbNullString, "C:\", SW_SHOWNORMAL)
        'End If
        Process.Start("mailto:" & Me.TextE_mail.EditValue)
    End Sub
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Position - 1
        Me.RecordCount()
    End Sub
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Position + 1
        Me.RecordCount()
    End Sub
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If LockUpdate = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Static P As Integer
        P = BS.Count
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.EDITBUTTON.Enabled = True
        Me.BUTTONCANCEL.Enabled = True
        Me.DELETEBUTTON.Enabled = True
        Me.EMAILBUTTON.Enabled = True
        Click2 = True
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        Me.EDITBUTTON.Enabled = True
        Me.BUTTONCANCEL.Enabled = True
        Me.DELETEBUTTON.Enabled = True
        Me.NETBUTTON.Enabled = True
        Me.EMAILBUTTON.Enabled = True
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockDelete = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… Õ–› «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim strsql1 As New SqlClient.SqlCommand("SELECT DISTINCT IDCAB FROM Suppliers1 WHERE CAB11 = '" & Me.TEXTBOX1.Text & "'", Consum)
        Dim ds1 As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql1)
        On Error Resume Next
        ds1.Clear()
        Adp1.Fill(ds1, "Suppliers1")
        If ds1.Tables(0).Rows.Count > 0 Then
            MsgBox("·«Ì„ﬂ‰ Õ–›  «·”Ã· «·Õ«·Ï ·√‰Â „— »ÿ »Õ—ﬂ«  «·„Ê—œÌ‰ ... ", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Dim strsql2 As New SqlClient.SqlCommand("SELECT DISTINCT BUY1 FROM BUYS WHERE BUY5 = '" & Me.TEXTSupplierName.Text & "'", Consum)
        Dim ds2 As New DataSet
        Dim Adp2 As New SqlClient.SqlDataAdapter(strsql1)
        On Error Resume Next
        ds2.Clear()
        Adp2.Fill(ds2, "BUYS")
        If ds2.Tables(0).Rows.Count > 0 Then
            MsgBox("·«Ì„ﬂ‰ Õ–›  «·”Ã· «·Õ«·Ï ·√‰Â „— »ÿ »Õ—ﬂ«  «·„‘ —Ì«  ... ", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Dim strsql3 As New SqlClient.SqlCommand("SELECT DISTINCT IDCH FROM Checks WHERE CH8 = '" & Me.TEXTBOX1.Text & "'", Consum)
        Dim ds3 As New DataSet
        Dim Adp3 As New SqlClient.SqlDataAdapter(strsql3)
        On Error Resume Next
        ds3.Clear()
        Adp3.Fill(ds3, "Checks")
        If ds3.Tables(0).Rows.Count > 0 Then
            MsgBox("·«Ì„ﬂ‰ Õ–›  «·”Ã· «·Õ«·Ï ·√‰Â „— »ÿ »Õ—ﬂ«  «·‘Ìﬂ«  ... ", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        MYDELETERECORD("SUPPLIER", "sup1", Me.TEXTBOX1, Me.BS, True)
        CLEARDATA1(Me)
        Consum.Close()
        Me.RecordCount()
        Insert_Actions(Me.TEXTBOX1.Text.Trim, "Õ–›", Me.Text)

    End Sub
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        On Error Resume Next
        Me.BS.Position = Me.ListBox1.SelectedIndex
        Me.RecordCount()
    End Sub
    Private Sub TEXTBOX24_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSearch.SelectedIndexChanged
        On Error Resume Next
        Me.BS.Position = Me.TxtSearch.SelectedIndex
        Me.RecordCount()
    End Sub
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonResourcePayment.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If LockUpdate = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim F As New SuppliersPay
        ds.EnforceConstraints = False
        Dim str As New SqlCommand("SELECT * FROM SupplierPay  WHERE  CUser='" & CUser & "'  ORDER BY lo1", Consum)
        SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
        Dim builder68 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
        ds.Clear()
        SqlDataAdapter1.Fill(ds, "SupplierPay")
        F.BS.DataMember = "SupplierPay"
        F.BS.DataSource = ds
        Dim index As Integer
        index = F.BS.Find("Loa10", Me.TEXTBOX1.Text)
        F.TextBox1.Text = Me.TEXTBOX1.Text
        F.TextBox2.Text = Me.TEXTSupplierName.Text
        F.BS.Position = index
        F.Show()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class