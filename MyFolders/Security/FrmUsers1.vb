Option Explicit Off
Imports System.Data.SqlClient
Public Class FrmUsers1
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim ds As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter

    Private WithEvents TimerTestNet As New Timer
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveDataBase As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()


    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Private WithEvents SearchTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()

    Dim flag As Boolean = False
    ReadOnly Cancel As Boolean = False
    Dim DelRow As Boolean = False
    ReadOnly RowCount As Integer = 0
    Private Sub FrmUSERS_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub FrmUsers1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.SAVEBUTTON.Enabled = False
        Call MangUsers()
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.ds.Tables("USERS")
            Me.PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            If DelRow = False Then
                If Me.BS.Count < Me.RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 48 + 524288, "تحديث السجلات")
                ElseIf Me.BS.Count > RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 48 + 524288, "تحديث السجلات")
                End If
            Else
                DelRow = False
            End If
            Consum.Close()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveDataBase.DoWork
        Try

1:

            'SqlDataAdapter1.Update(ds, "Users")
            'ds = New DataSet
            'SqlDataAdapter1.Fill(ds, "Users")
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
    Private Sub SaveDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveDataBase.RunWorkerCompleted
        Try
            If DelRow = True Then
                Me.PictureBox2.Visible = True
                Me.RefreshTab = New ComponentModel.BackgroundWorker With {
                    .WorkerReportsProgress = True,
                    .WorkerSupportsCancellation = True
                }
                Me.RefreshTab.RunWorkerAsync()
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Me.BS.DataSource = Me.ds.Tables("Users")
            Me.PictureBox1.Visible = False
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
            Consum.Close()

        Catch ex As Exception
            PictureBox1.Visible = False
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then
                Me.TimerTestNet.Interval = 100
                Me.TimerTestNet.Start()
            Else
                Me.Close()
                Me.TimerTestNet.Stop()
            End If
        End If
    End Sub
    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
        End If
    End Sub
    Private Sub SAVERECORD()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim sql As String = "INSERT INTO USERS( UserName, Pws, Realname, UserType, CUser, COUser, BlockUser, LockAddRow, LockDelete, LockSave, LockUpdate, Printpreview, TransferofAccounts, InternalAuditor, CollaborationManager, HeadofAuditingDepartment, ExternalAuditor, FileList, ListOFClients, CashAndMembers, ListOFAccounts, ListOFelectronicArchives, StaffMenu,Internet,RAdmin1) VALUES   ( @UserName, @Pws, @Realname, @UserType, @CUser, @COUser, @BlockUser, @LockAddRow, @LockDelete, @LockSave, @LockUpdate, @Printpreview, @TransferofAccounts, @InternalAuditor, @CollaborationManager, @HeadofAuditingDepartment, @ExternalAuditor, @FileList, @ListOFClients, @CashAndMembers, @ListOFAccounts, @ListOFelectronicArchives, @StaffMenu,@Internet,@RAdmin1)"

            Dim cmd As New SqlCommand(sql, Consum)
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Me.TEXTUserName.Text
                .Parameters.Add("@Pws", SqlDbType.NVarChar).Value = Me.TEXTPws.Text
                .Parameters.Add("@Realname", SqlDbType.NVarChar).Value = Me.TextUsersRealName.Text
                .Parameters.Add("@UserType", SqlDbType.NVarChar).Value = Me.ComboUsersType.Text
                .Parameters.Add("@cuser", SqlDbType.NVarChar).Value = Me.TextCuser.Text
                .Parameters.Add("@couser", SqlDbType.NVarChar).Value = Me.TextCOuser.Text
                .Parameters.Add("@BlockUser", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckBlockUser.Checked)

                'قائمة الازرار
                .Parameters.Add("@LockAddRow", SqlDbType.Bit).Value = Convert.ToInt32(Me.LockAddRow.Checked)
                .Parameters.Add("@LockSave", SqlDbType.Bit).Value = Convert.ToInt32(Me.LockSave.Checked)
                .Parameters.Add("@LockUpdate", SqlDbType.Bit).Value = Convert.ToInt32(Me.LockUpdate.Checked)
                .Parameters.Add("@LockDelete", SqlDbType.Bit).Value = Convert.ToInt32(Me.LockDelete.Checked)
                .Parameters.Add("@Printpreview", SqlDbType.Bit).Value = Convert.ToInt32(Me.PrintpInternalAuditor.Checked)
                .Parameters.Add("@TransferofAccounts", SqlDbType.Bit).Value = Convert.ToInt32(Me.TransferofAccounts.Checked)



                .Parameters.Add("@InternalAuditor", SqlDbType.Bit).Value = Convert.ToInt32(Me.InternalAuditor.Checked)
                .Parameters.Add("@CollaborationManager", SqlDbType.Bit).Value = Convert.ToInt32(Me.Managers.Checked)
                .Parameters.Add("@HeadofAuditingDepartment", SqlDbType.Bit).Value = Convert.ToInt32(Me.HeadofAuditingDepartment.Checked)
                .Parameters.Add("@ExternalAuditor", SqlDbType.Bit).Value = Convert.ToInt32(Me.ExternalAuditor.Checked)
                .Parameters.Add("@RAdmin1", SqlDbType.Bit).Value = Convert.ToInt32(Me.RAdmin1.Checked)

                'القائمة الاولى
                .Parameters.Add("@FileList", SqlDbType.Bit).Value = Convert.ToInt32(Me.FileList.Checked)
                .Parameters.Add("@ListOFClients", SqlDbType.Bit).Value = Convert.ToInt32(Me.ListOFClients.Checked)
                .Parameters.Add("@CashAndMembers", SqlDbType.Bit).Value = Convert.ToInt32(Me.CashAndMembers.Checked)
                .Parameters.Add("@ListOFAccounts", SqlDbType.Bit).Value = Convert.ToInt32(Me.ListOFAccounts.Checked)

                'القائمة االثانية

                .Parameters.Add("@ListOFelectronicArchives", SqlDbType.Bit).Value = Convert.ToInt32(Me.ListOFelectronicArchives.Checked)
                .Parameters.Add("@StaffMenu", SqlDbType.Bit).Value = Convert.ToInt32(Me.StaffMenu.Checked)
                .Parameters.Add("@Internet", SqlDbType.Bit).Value = Convert.ToInt32(Me.Internet.Checked)


                .CommandText = sql
            End With

            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error12", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub MAXRECORD()
        On Error Resume Next
        Dim V As Integer
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(ID) FROM USERS", Consum)
        Dim CMD As New SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        If IsDBNull(resualt) Then
            TEXTBOX1.Text = 1
        Else
            TEXTBOX1.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub
    Private Sub SEARCHUSERS()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT UserName  FROM USERS  WHERE (USERS.UserName)='" & Me.TEXTUserName.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsq1)
        ds.Clear()
        Adp1.Fill(ds, "USERS")
        If ds.Tables(0).Rows.Count >= 1 Then
            MessageBox.Show("تم تسجيل اسم المستخدم سابقاً", "تكرار بيانات مستخدم", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Me.TEXTUserName.Focus()
            flag = True
            Exit Sub
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub
    Private Sub SEARCHUSERS1()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT Realname  FROM USERS  WHERE (USERS.Realname)='" & Me.TextUsersRealName.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsq1)
        ds.Clear()
        Adp1.Fill(ds, "USERS")
        If ds.Tables(0).Rows.Count >= 1 Then
            MessageBox.Show("تم تسجيل الاسم الحقيقي للمستخدم سابقاً", "تكرار بيانات مستخدم", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Me.TEXTUserName.Focus()
            flag = True
            Exit Sub
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub
    Private Sub SEARCHUSERS2()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT CUser, COUser  FROM COMPANY  WHERE (COMPANY.CMP2)='" & FrmMAIN.ComboGetAssociationName.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsq1)
        ds.Clear()
        Adp1.Fill(ds, "COMPANY")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextCuser.Text = ds.Tables(0).Rows(0).Item(0)
            Me.TextCOuser.Text = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TextCuser.Text = ""
            Me.TextCOuser.Text = ""
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
        Try
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Me.BS.Position = Me.BS.Count - 1
            Me.BS.EndEdit()
            Me.BS.AddNew()
            CLEARDATA(Me, Me.GroupBox1)
            Me.MAXRECORD()
            Me.TextCuser.Text = CUser
            Me.TextCOuser.Text = COUser
            Me.TEXTUserName.Focus()
            SEARCHUSERS2()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Dim Sound As IO.Stream = My.Resources.addv
        My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If RAdmin = False Then
                MsgBox("عفوا .. هذا الامر للمشرف العام فقط", 16, "تنبيه")
                Exit Sub
            End If
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            Static P As Integer
            P = Me.BS.Count
            Me.SEARCHUSERS()
            Me.SEARCHUSERS1()
            If flag = True Then Exit Sub
            If Me.TEXTPws.Text <> Me.TEXTConfirmPassword.Text Then
                MessageBox.Show("من فضلك تأكد من صحة كلمة المرور", "حفظ سجل", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Me.TEXTConfirmPassword.Focus()
            Else
                Me.SEARCHUSERS()
                Me.SEARCHUSERS1()
                Me.BS.Position = P + 1
            End If
            Me.SAVERECORD()
            Me.PictureBox1.Visible = True
            Me.BS.EndEdit()
            Me.SaveDataBase = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveDataBase.RunWorkerAsync()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButtonSELALL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonSELALL.Click
        On Error Resume Next
        If Me.ButtonSELALL.Text = "تحديدالكل" Then
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
            Me.ButtonSELALL.Text = "الغاءالتحديد"
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
            Me.ButtonSELALL.Text = "تحديدالكل"
            Me.ButtonSELALL.Image = My.Resources.Resources.SelectAll_16x16
        End If
    End Sub

End Class
