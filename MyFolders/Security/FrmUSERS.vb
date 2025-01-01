Option Explicit Off
Imports System.Data.SqlClient
Public Class FrmUSERS
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim ds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim flag As Boolean = False
    ReadOnly Cancel As Boolean = False
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Private Sub FrmUSERS_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Consum.Close()
    End Sub
    Private Sub FrmUSERS_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmUSERS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F3
                    Me.EDITBUTTON_Click(sender, e)
                Case Keys.F4
                    Me.BUTTONCANCEL_Click(sender, e)
                Case Keys.F6
                    Me.DELETEBUTTON_Click(sender, e)
                Case Keys.A And (e.Alt And Not e.Control And Not e.Shift)
                    Me.ButtonSELALL_Click(sender, e)
                Case Keys.R And (e.Alt And Not e.Control And Not e.Shift)
                    Me.ButtonXP11_Click(sender, e)
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
    Private Sub FrmUSERS_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
        Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()
    End Sub
    Public Sub FrmUSERS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try

1:

            Dim Consum As New SqlClient.SqlConnection(constring)
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Dim strSQL As New SqlClient.SqlCommand("", Consum) With {
                .CommandText = String.Concat(New String() {"SELECT ID ,UserName ,Pws  ,TimeEnter, MacAddress ,LoginName ,Realname ,UserType  ,CUser, COUser ,BlockUser,LockAddRow ,LockDelete,LockSave  ,LockUpdate,Printpreview ,TransferofAccounts,InternalAuditor ,CollaborationManager ,HeadofAuditingDepartment ,ExternalAuditor   ,FileList ,ListOFClients,CashAndMembers,ListOFAccounts,ListOFelectronicArchives,StaffMenu,Internet,RAdmin1  FROM USERS WHERE   ID ='", Strings.Trim(Me.TB1), "' or UserName ='", Strings.Trim(Me.TB2), "'or Realname ='", Strings.Trim(Me.TB3), "' ORDER BY ID"})
            }
            Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
            Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
            Me.ds = New DataSet
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.ds, "USERS")
            Me.ds.RejectChanges()
            Consum.Close()
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "ErrorConnectDataBase_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Try
    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then
                Me.Label30.Visible = True
                Me.Label30.ForeColor = Color.Yellow
                Me.Label30.Text = "..  „ «·« ’«· »«·«‰ —‰  .. Ì „ «·«‰  Õ„Ì· ”Ã·«  «·ﬁ«⁄œ…"
            Else
                Me.Label30.ForeColor = Color.Red
                Me.Label30.Text = "«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—"
                Me.Close()
            End If
        End If
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.ds.Tables("USERS")
            Me.RowCount = Me.BS.Count

            Me.TEXTBOX1.DataBindings.Add("text", Me.BS, "ID", True, 1, "")
            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "UserName", True, 1, "")
            Me.TEXTPws.DataBindings.Add("text", Me.BS, "Pws", True, 1, "")
            '   Me.TEXTBOX4.DataBindings.Add("text",  Me.BS, "TimeEnter", True, 1, "")
            Me.TextMacAddress.DataBindings.Add("text", Me.BS, "MacAddress", True, 1, "")
            Me.TextUsersRealName.DataBindings.Add("text", Me.BS, "Realname", True, 1, "")
            Me.ComboUsersType.DataBindings.Add("text", Me.BS, "UserType", True, 1, "")
            Me.TextCuser.DataBindings.Add("text", Me.BS, "cuser", True, 1, "")
            Me.TextCOuser.DataBindings.Add("text", Me.BS, "couser", True, 1, "")

            Me.CheckBlockUser.DataBindings.Add("Checked", Me.BS, "BlockUser", True, 1, "")
            '«·ﬁ«∆„… «·«Ê·Ï
            Me.FileList.DataBindings.Add("Checked", Me.BS, "FileList", True, 1, "")
            Me.ListOFClients.DataBindings.Add("Checked", Me.BS, "ListOFClients", True, 1, "")
            Me.CashAndMembers.DataBindings.Add("Checked", Me.BS, "CashAndMembers", True, 1, "")



            Me.InternalAuditor.DataBindings.Add("Checked", Me.BS, "InternalAuditor", True, 1, "")
            Me.Managers.DataBindings.Add("Checked", Me.BS, "CollaborationManager", True, 1, "")
            Me.HeadofAuditingDepartment.DataBindings.Add("Checked", Me.BS, "HeadofAuditingDepartment", True, 1, "")
            Me.ExternalAuditor.DataBindings.Add("Checked", Me.BS, "ExternalAuditor", True, 1, "")
            Me.RAdmin1.DataBindings.Add("Checked", Me.BS, "RAdmin1", True, 1, "")

            '«·ﬁ«∆„… ««·À«‰Ì…
            Me.ListOFAccounts.DataBindings.Add("Checked", Me.BS, "ListOFAccounts", True, 1, "")
            Me.ListOFelectronicArchives.DataBindings.Add("Checked", Me.BS, "ListOFelectronicArchives", True, 1, "")
            Me.StaffMenu.DataBindings.Add("Checked", Me.BS, "StaffMenu", True, 1, "")
            Me.Internet.DataBindings.Add("Checked", Me.BS, "Internet", True, 1, "")
            'ﬁ«∆„… «·«“—«—
            Me.LockAddRow.DataBindings.Add("Checked", Me.BS, "LockAddRow", True, 1, "")
            Me.LockSave.DataBindings.Add("Checked", Me.BS, "LockSave", True, 1, "")
            Me.LockUpdate.DataBindings.Add("Checked", Me.BS, "LockUpdate", True, 1, "")
            Me.LockDelete.DataBindings.Add("Checked", Me.BS, "LockDelete", True, 1, "")
            Me.PrintpInternalAuditor.DataBindings.Add("Checked", Me.BS, "Printpreview", True, 1, "")
            Me.TransferofAccounts.DataBindings.Add("Checked", Me.BS, "TransferofAccounts", True, 1, "")

            Me.RecordCount()
            Call MangUsers()
            Me.Label30.ForeColor = Color.White
            Me.Label30.Text = "«·«‰  Õ„Ì· ”Ã·«  «·ﬁ«⁄œ…"
            Me.Label30.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorRunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            Me.ds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.ds, "USERS")
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.ds.Tables("USERS")
            Me.PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            Me.Count()
            If DelRow = False Then
                If Me.BS.Count < Me.RowCount Then
                    MsgBox("  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & Me.RowCount - Me.BS.Count, 48 + 524288, " ÕœÌÀ «·”Ã·« ")
                ElseIf Me.BS.Count > RowCount Then
                    MsgBox("  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & Me.BS.Count - Me.RowCount, 48 + 524288, " ÕœÌÀ «·”Ã·« ")
                End If
            Else
                DelRow = False
            End If
            Consum.Close()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try

1:

            Me.SqlDataAdapter1.Update(Me.ds, "Users")
            Me.ds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.ds, "Users")
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                Me.ButtonXP11_Click(sender, e)
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Me.BS.DataSource = Me.ds.Tables("Users")
            Me.PictureBox1.Visible = False
            MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
        Catch ex As Exception
            Me.PictureBox1.Visible = False
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " „‰ " & Me.BS.Count
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
        If Me.BS.Position < Me.ds.Tables("USERS").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward

    End Sub
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        Me.RecordCount()
    End Sub
    Private Sub MAXRECORD()
        On Error Resume Next
        Dim V As Integer
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(ID) FROM USERS", Consum)
        Dim CMD As New SqlClient.SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        If IsDBNull(resualt) Then
            Me.TEXTBOX1.Text = 1
        Else
            Me.TEXTBOX1.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub
    Private Sub SEARCHUSERS()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT UserName  FROM USERS  WHERE (USERS.UserName)='" & Me.TEXTUserName.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
        ds.Clear()
        Adp1.Fill(ds, "USERS")
        If ds.Tables(0).Rows.Count >= 1 Then
            MessageBox.Show(" „  ”ÃÌ· »Ì«‰«  «·„” Œœ„ ”«»ﬁ«", " ﬂ—«— »Ì«‰«  „” Œœ„", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Me.TEXTUserName.Focus()
            flag = True
            Exit Sub
        End If
        Adp1.Dispose()
        Consum.Close()
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
    Private Sub TextBox19_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            '  If Me.TextBox19.TextLength > 0 Then
            '  Dim index As Integer
            'index = Bs.Find("UserName", Me.TextBox19.Text.Trim)
            '   Bs.Position = index
            Me.RecordCount()
            '  Else
            ' Bs.Position = 0
            '   End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmUsers_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        On Error Resume Next
        'Consum.Dispose()
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
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If RAdmin = False Then
                MsgBox("⁄›Ê« .. Â–« «·«„— ··„‘—› «·⁄«„ ›ﬁÿ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.EDITBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = True
            Static P As Integer
            P = Me.BS.Position
            If flag = True Then Exit Sub
            If Me.TEXTPws.Text <> Me.TEXTConfirmPassword.Text Then
                MessageBox.Show("„‰ ›÷·ﬂ  √ﬂœ „‰ ’Õ… ﬂ·„… «·„—Ê—", "Õ›Ÿ ”Ã·", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Me.TEXTConfirmPassword.Focus()
            Else
                Me.BS.EndEdit()
                Me.RowCount = Me.BS.Count
            End If
            Me.PictureBox1.Visible = True
            Me.BS.EndEdit()
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        Me.EDITBUTTON.Enabled = True
        Me.BUTTONCANCEL.Enabled = True
        Me.DELETEBUTTON.Enabled = True
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If RAdmin = False Then
                MsgBox("⁄›Ê« .. Â–« «·«„— ··„‘—› «·⁄«„ ›ﬁÿ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub

            If MsgBox("  «” „—«— Õ–› «·”Ã· «·Õ«·Ì" & " ø ", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.OkCancel, "Õ–› ’Ê—…") = MsgBoxResult.Cancel Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.RemoveCurrent()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TEXTBOX2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTUserName.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub ButtonSELALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSELALL.Click
        On Error Resume Next
        If Me.ButtonSELALL.Text = " ÕœÌœ«·ﬂ·" Then
            For Each chk1 In PanelGB1.Controls
                If TypeOf chk1 Is CheckBox Then
                    chk1.Checked = True
                End If
            Next
            For Each chk1 In PanelGB2.Controls
                If TypeOf chk1 Is CheckBox Then
                    chk1.Checked = True
                End If
            Next
            For Each chk1 In PanelGB3.Controls
                If TypeOf chk1 Is CheckBox Then
                    chk1.Checked = True
                End If
            Next
            Me.ButtonSELALL.Text = "«·€«¡«· ÕœÌœ"
            Me.ButtonSELALL.Image = My.Resources.Resources.SelectAll2_16x16
        Else
            For Each chk1 In PanelGB1.Controls
                If TypeOf chk1 Is CheckBox Then
                    chk1.Checked = False
                End If
            Next
            For Each chk1 In PanelGB2.Controls
                If TypeOf chk1 Is CheckBox Then
                    chk1.Checked = False
                End If
            Next
            For Each chk1 In PanelGB3.Controls
                If TypeOf chk1 Is CheckBox Then
                    chk1.Checked = False
                End If
            Next
            Me.ButtonSELALL.Text = " ÕœÌœ«·ﬂ·"
            Me.ButtonSELALL.Image = My.Resources.Resources.SelectAll_16x16
        End If

    End Sub
    Private Sub ButtonXP11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP11.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Me.TEXTBOX1.Clear()
            Me.PictureBox2.Visible = True
            Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.RefreshTab.RunWorkerAsync()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class