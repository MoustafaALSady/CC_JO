
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Text
Imports DevExpress.Office.Services
Imports DevExpress.Office.Utils
Imports DevExpress.Utils
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.Export

Public Class FrmSendEMail
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm
    Dim WithEvents BS As New BindingSource
    Dim ds As New DataSet
    Dim SqlDataAdapter1 As New SqlDataAdapter
    Private currentFile As String
    Private WithEvents SmtpServer As New SmtpClient()
    Public cmd As New SqlCommand
    Dim FileStream As FileStream
    Dim Reader As BinaryReader = Nothing 'طريقة قرائة الملفات
    Dim FileData As Byte() = Nothing           'لحفظ الملف
    Dim FileSize As Double = 0                 ' حجم الملف
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveDataBase As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim ID As Integer

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FrmSendEMail_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub FrmSendEMail_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next

            ConnectDataBase = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            ConnectDataBase.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try

1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())

            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT FIELD1,FIELD2,FIELD3,FIELD4,FIELD5,FIELD6,FIELD7,FIELD8,FIELD9,FIELD10,FIELD11,FIELD12,FIELD13,FIELD14,FIELD15,FIELD16,CUser,COUser,da,ne FROM TSendEMail  WHERE  CUser='" & CUser & "'  ORDER BY Field1"
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
            End With
            Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
            Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
            Me.ds.Clear()
            Me.ds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.ds, "TSendEMail")
            Consum.Close()


            Dim ds1 As New DataSet
            Dim SqlDataAdapter2 As SqlDataAdapter
            Dim strSQL1 As New SqlCommand("SELECT * FROM TNewMail ORDER BY Field1", Consum)
            SqlDataAdapter2 = New SqlDataAdapter(strSQL1)
            ds1.Clear()
            SqlDataAdapter2.Fill(ds1, "TNewMail")
            Dim ds2 As New DataSet
            Dim SqlDataAdapter3 As SqlDataAdapter
            Dim strSQL2 As New SqlCommand("SELECT * FROM TSettingEmail WHERE  CUser='" & CUser & "'ORDER BY FIELD1", Consum)
            SqlDataAdapter3 = New SqlDataAdapter(strSQL2)
            ds2.Clear()
            SqlDataAdapter3.Fill(ds2, "TSettingEmail")

            Me.CheckedListEmails.DataSource = ds1.Tables("TNewMail")
            Me.CheckedListEmails.DisplayMember = "FIELD3"

            Me.CBSender.DataSource = ds2.Tables("TSettingEmail")
            Me.CBSender.DisplayMember = "FIELD6"
            Me.CBEmailSent.DataSource = ds2.Tables("TSettingEmail")
            Me.CBEmailSent.DisplayMember = "FIELD4"

            Me.CBConsignee.DataSource = ds1.Tables("TNewMail")
            Me.CBConsignee.DisplayMember = "FIELD2"
            Me.CBEmailSentToYou.DataSource = ds1.Tables("TNewMail")
            Me.CBEmailSentToYou.DisplayMember = "FIELD3"

            'FILLCOMBOBOX1("TSettingEmail", "FIELD6", "CUser", CUser, Me.ComboBox3)
            'FILLCOMBOBOX1("TSettingEmail", "FIELD4", "CUser", CUser, Me.ComboBox4)



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

    Public Sub LoadDataBase()
        On Error Resume Next
        If TestNet = True Then
            'Me.Label1.ForeColor = Color.Yellow
        Else
            Me.Close()
        End If
    End Sub

    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.ds.Tables("TSendEMail")
            Me.RowCount = Me.BS.Count
            Me.TextCod.DataBindings.Add("text", Me.BS, "Field1", True, 1, "")
            Me.TextSubject.DataBindings.Add("text", Me.BS, "Field2", True, 1, "")
            Me.DateMovementHistory.DataBindings.Add("text", Me.BS, "Field3", True, 1, "")
            Me.CBSender.DataBindings.Add("text", Me.BS, "Field4", True, 1, "")
            Me.CBEmailSent.DataBindings.Add("text", Me.BS, "Field5", True, 1, "")
            Me.CBConsignee.DataBindings.Add("text", Me.BS, "Field6", True, 1, "")
            Me.CBEmailSentToYou.DataBindings.Add("text", Me.BS, "Field7", True, 1, "")
            Me.LinkLabelAttached1.DataBindings.Add("text", Me.BS, "Field8", True, 1, "")
            'Me.RichEditControl1.DataBindings.Add("text", Me.BS, "Field9", True, 1, "")
            Me.LabelField10.DataBindings.Add("text", Me.BS, "Field10", True, 1, "")
            Me.LabelField11.DataBindings.Add("text", Me.BS, "Field11", True, 1, "")
            Me.LabelField12.DataBindings.Add("text", Me.BS, "Field12", True, 1, "")
            Me.LinkLabelAttached2.DataBindings.Add("text", Me.BS, "Field13", True, 1, "")
            Me.LinkLabelAttached3.DataBindings.Add("text", Me.BS, "Field14", True, 1, "")
            Me.TextMovementHistory.DataBindings.Add("text", Me.BS, "Field15", True, 1, "")
            Me.ListBox1.DataBindings.Add("text", Me.BS, "Field16", True, 1, "")
            Me.TextCUser.DataBindings.Add("text", Me.BS, "cuser", True, 1, "")
            Me.TextCOUser.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")

            If Me.ds.Tables("TSendEMail").Rows.Count > 0 Then
                Me.RichEditControl1.RtfText = Me.ds.Tables(0).Rows(Me.BS.Position)("Field9").ToString
                AddHandler ds.Tables(0).ColumnChanged, AddressOf Cars_ColumnChanged
                UpdateCommandsState()
            End If
            Call MangUsers()
            Me.SHOWBUTTON()
            Me.SAVEBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            'Me.RecordCount()
            'SurroundingSub()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ConnectDataBase_RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub
    Private Sub SurroundingSub()
        'Me.RichEditControl1.Document.DefaultParagraphProperties.Alignment = ParagraphAlignment.Right
        Dim document As Document = RichEditControl1.Document
        document.DefaultParagraphProperties.RightToLeft = True

    End Sub
    Private Sub Cars_ColumnChanged(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
        If Not RichEditControl1.Modified Then
            e.Row.AcceptChanges()
        End If
    End Sub
    Private Sub RichEditControl1_ModifiedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RichEditControl1.ModifiedChanged
        UpdateCommandsState()
    End Sub
    Private Sub UpdateCommandsState()
        ' Update control level commands state
        'dataNavigator1.Buttons.CancelEdit.Enabled = RichEditControl1.Modified
        'dataNavigator1.Buttons.EndEdit.Enabled = RichEditControl1.Modified
        'Static P As Integer
        'P = Me.BS.Position
        '' Update data (in-memory) level commands state
        Dim currentDataRow As DataRow = Me.ds.Tables(0).Rows(Me.BS.Position)
        Me.BUTTONCANCEL.Enabled = (currentDataRow.RowState <> DataRowState.Unchanged) AndAlso Not Me.RichEditControl1.Modified
        'Me.EDITBUTTON.Enabled = Me.ds.HasChanges() AndAlso Not Me.RichEditControl1.Modified

        '' Update info panel
        If Me.ds.Tables(0).Rows.Count > 0 Then
            Me.lblCurrentRecordInfo.Text = String.Format("Current Record: {0}{1}", Me.BS.Position, IIf(Me.BUTTONCANCEL.Enabled, "*", ""))
        End If
    End Sub
    Private Sub SAVERECORD()
        Try
            Dim N As Double
            Dim Consum As New SqlConnection(constring)
            Dim cmd1 As New SqlCommand("SELECT MAX(Field1) FROM TSendEMail", Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim resualt As Object = cmd1.ExecuteScalar()
            If IsDBNull(resualt) Then
                N = 1
            Else
                N = CType(resualt, Integer) + 1
            End If
            Consum.Close()


            Dim SQL As String = "INSERT INTO TSendEMail( Field2, Field3 , Field4, Field5, Field6 , Field7, Field8, Field9 , Field10, Field11, Field12 , Field13, Field14, Field15 , Field16, CUser, COUser) VALUES     ( @Field2, @Field3 , @Field4, @Field5, @Field6 , @Field7, @Field8, @Field9 , @Field10, @Field11, @Field12 , @Field13, @Field14, @Field15 , @Field16, @CUser, @COUser)"

            Dim cmd As New SqlCommand(SQL, Consum)
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@Field1", SqlDbType.Int).Value = Val(N) + 1
                .Parameters.Add("@Field2", SqlDbType.NVarChar).Value = Me.TextSubject.Text
                .Parameters.Add("@Field3", SqlDbType.Date).Value = Me.DateMovementHistory.Text
                .Parameters.Add("@Field4", SqlDbType.NVarChar).Value = CBSender.Text
                .Parameters.Add("@Field5", SqlDbType.NVarChar).Value = Me.CBEmailSent.Text
                .Parameters.Add("@Field6", SqlDbType.NVarChar).Value = Me.CBConsignee.Text
                .Parameters.Add("@Field7", SqlDbType.NVarChar).Value = Me.CBEmailSentToYou.Text
                .Parameters.Add("@Field8", SqlDbType.NVarChar).Value = Me.LinkLabelAttached1.Text
                .Parameters.Add("@Field9", SqlDbType.VarChar).Value = Me.RichEditControl1.RtfText.ToArray
                .Parameters.Add("@Field10", SqlDbType.NVarChar).Value = Me.LabelField10.Text
                .Parameters.Add("@Field11", SqlDbType.NVarChar).Value = Me.LabelField11.Text
                .Parameters.Add("@Field12", SqlDbType.NVarChar).Value = LabelField12.Text
                .Parameters.Add("@Field13", SqlDbType.NVarChar).Value = Me.LinkLabelAttached2.Text
                .Parameters.Add("@Field14", SqlDbType.NVarChar).Value = Me.LinkLabelAttached3.Text
                .Parameters.Add("@Field15", SqlDbType.NVarChar).Value = TextMovementHistory.Text
                .Parameters.Add("@Field16", SqlDbType.NVarChar).Value = Me.ListBox1.Text
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
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
    Private Sub UPDATERECORD()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As String = " Update TSendEMail Set  Field2 = @Field2, Field3 = @Field3, Field4 = @Field4,Field5 = @Field5, Field6 = @Field6, Field7 = @Field7, Field8 = @Field8, Field9 = @Field9, Field10 = @Field10,Field11 = @Field11, Field12 = @Field12, Field13 = @Field13,Field14 = @Field14, Field15 = @Field15, Field16 = @Field16, CUser = @CUser  WHERE Field1 =" & Val(ID)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            Dim N As Integer
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@Field1", SqlDbType.Int).Value = Val(N) + 1
                .Parameters.Add("@Field2", SqlDbType.NVarChar).Value = Me.TextSubject.Text
                .Parameters.Add("@Field3", SqlDbType.Date).Value = Me.DateMovementHistory.Text
                .Parameters.Add("@Field4", SqlDbType.NVarChar).Value = CBSender.Text
                .Parameters.Add("@Field5", SqlDbType.NVarChar).Value = Me.CBEmailSent.Text
                .Parameters.Add("@Field6", SqlDbType.NVarChar).Value = Me.CBConsignee.Text
                .Parameters.Add("@Field7", SqlDbType.NVarChar).Value = Me.CBEmailSentToYou.Text
                .Parameters.Add("@Field8", SqlDbType.NVarChar).Value = Me.LinkLabelAttached1.Text
                .Parameters.Add("@Field9", SqlDbType.VarChar).Value = Me.RichEditControl1.RtfText.ToArray
                .Parameters.Add("@Field10", SqlDbType.NVarChar).Value = Me.LabelField10.Text
                .Parameters.Add("@Field11", SqlDbType.NVarChar).Value = Me.LabelField11.Text
                .Parameters.Add("@Field12", SqlDbType.NVarChar).Value = LabelField12.Text
                .Parameters.Add("@Field13", SqlDbType.NVarChar).Value = Me.LinkLabelAttached2.Text
                .Parameters.Add("@Field14", SqlDbType.NVarChar).Value = Me.LinkLabelAttached3.Text
                .Parameters.Add("@Field15", SqlDbType.NVarChar).Value = TextMovementHistory.Text
                .Parameters.Add("@Field16", SqlDbType.NVarChar).Value = Me.ListBox1.Text
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUPDATERECORD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:
            Me.UpdateCommandsState()
            'Me.SqlDataAdapter1.Update(Me.ds, "TSendEMail")
            'Me.ds = New DataSet
            'Me.SqlDataAdapter1.Fill(Me.ds, "TSendEMail")
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
                PictureBox2False()
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
            Me.BS.DataSource = Me.ds.Tables("TSendEMail")
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.Count()

            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")

                Exit Sub
            End If
            Dim Sound As Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf Me.PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.PictureBox5.Visible = False

        End If
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
        'Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.ButtonDELALL.Enabled = LockDelete
    End Sub
    Private Sub FILLCOMBOBOXITEMS1(ByVal TABLE As String, ByVal FIELD As String, ByVal COMBO As Object)
        On Error Resume Next
        'constring = ("workstation id=coj.ddns.net;packet size=4096;user id=sa;pwd=2710/m;data source=coj.ddns.net;persist security info=False;initial catalog=co")
        Dim Consum As New SqlConnection(constring)
        Dim BS As New BindingSource
        Dim I As Integer
        Dim DS As New DataSet
        Dim str As New SqlCommand("SELECT DISTINCT " & FIELD & " FROM " & TABLE, Consum)
        Dim ADP As New SqlDataAdapter(str)
        DS.Clear()
        ADP.Fill(DS, "TBL")
        COMBO.Items.Clear()
        For I = 0 To DS.Tables("TBL").Rows.Count - 1
            COMBO.Items.Add(DS.Tables("TBL").Rows(I).Item(0))
        Next I
        ADP.Dispose()
    End Sub
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        RecordCount()
    End Sub
    Private Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < ds.Tables("TSendEMail").Rows.Count - 1 Then
            Forward = True
        End If
        If Me.ds.Tables(0).Rows.Count > 0 Then
            ID = Me.ds.Tables(0).Rows(Me.BS.Position).Item("Field1")
            Me.RichEditControl1.RtfText = Me.ds.Tables(0).Rows(Me.BS.Position)("Field9").ToString
            AddHandler ds.Tables(0).ColumnChanged, AddressOf Cars_ColumnChanged
            UpdateCommandsState()
        End If


        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.RichEditControl1.SelectAll()


    End Sub
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FIRSTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PREVIOUSBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Position - 1
        Me.RecordCount()
    End Sub
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NEXTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Position + 1
        Me.RecordCount()
    End Sub
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
        Me.ADDBUTTON.Enabled = False
        Me.EDITBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = True
        Me.BUTTONCANCEL.Enabled = True
        Me.DELETEBUTTON.Enabled = False
        Me.ButtonDELALL.Enabled = False
        Me.ButtonDELATTACHFILE.Enabled = False
        Me.ButtonXP2.Enabled = False
        Me.ButtonXSETINGEMAIL.Enabled = False
        Me.ButtonXNEWEMAIL.Enabled = False
        Me.ButtonSELECTALL.Enabled = False
        Me.ButtonDESELECT.Enabled = False
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockAddRow = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        CLEARDATA1(Me)
        Dim n As Double
        Dim s As Double
        n = Me.BS.Count
        Me.BS.Position = Me.BS.Count - 1
        s = Val(Me.TextCod.Text)
        If n = 0 Then
            Me.TextCod.Text = 1
        Else
            If n >= s Then
                Me.TextCod.Text = Val(n) + 1
            Else
                Me.TextCod.Text = Val(s) + 1
            End If
        End If

        Me.TextSubject.Focus()
        Me.TextSubject.Text = ""
        Me.DateMovementHistory.Text = ""
        'Me.ComboBox1.Text = ""
        Me.CBEmailSent.Text = ""
        Me.CBConsignee.Text = ""
        Me.CBEmailSentToYou.Text = ""
        Me.LinkLabelAttached1.Text = ""
        Me.LinkLabelAttached2.Text = ""
        Me.LinkLabelAttached3.Text = ""
        Me.RichEditControl1.RtfText = ""
        Me.TextMovementHistory.Text = ""
        Me.LabelField10.Text = ""
        Me.LabelField11.Text = ""
        Me.LabelField12.Text = ""
        Me.TextCUser.Text = CUser.ToString.Trim
        Me.TextCOUser.Text = COUser.ToString.Trim
        Dim Sound As Stream = My.Resources.addv
        My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            'If BS.Count = 0 Then Beep() : Exit Sub
            If LockSave = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = True
            Me.ButtonDELALL.Enabled = False
            Me.ButtonDELATTACHFILE.Enabled = True
            Me.ButtonXP2.Enabled = True
            Me.ButtonXSETINGEMAIL.Enabled = True
            Me.ButtonXNEWEMAIL.Enabled = True
            Me.ButtonSELECTALL.Enabled = True
            Me.ButtonDESELECT.Enabled = True
            Me.TextCUser.Text = CUser.ToString.Trim
            Me.TextCOUser.Text = COUser.ToString.Trim
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SAVERECORD()
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & ex.Source)
        End Try
    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            'If LockUpdate = False Then
            '    MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            '    Exit Sub
            'End If

            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = True
            Me.ButtonDELALL.Enabled = False
            Me.ButtonDELATTACHFILE.Enabled = True
            Me.ButtonXP2.Enabled = True
            Me.ButtonXSETINGEMAIL.Enabled = True
            Me.ButtonXNEWEMAIL.Enabled = True
            Me.ButtonSELECTALL.Enabled = True
            Me.ButtonDESELECT.Enabled = True
            Me.TextCUser.Text = CUser.ToString.Trim
            Me.TextCOUser.Text = COUser.ToString.Trim
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.UPDATERECORD()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & ex.Source)
        End Try
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        Me.EDITBUTTON.Enabled = True
        Me.BUTTONCANCEL.Enabled = True
        Me.DELETEBUTTON.Enabled = True
        Me.ButtonDELALL.Enabled = False
        Me.ButtonDELATTACHFILE.Enabled = True
        Me.ButtonXP2.Enabled = True
        Me.ButtonXSETINGEMAIL.Enabled = True
        Me.ButtonXNEWEMAIL.Enabled = True
        Me.ButtonSELECTALL.Enabled = True
        Me.ButtonDESELECT.Enabled = True
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
        Try
            If LockDelete = True Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Dim Consum As New SqlConnection(constring)
            Dim resault As Integer
            If Me.BS.Count > 0 Then
                resault = MessageBox.Show("سبنم حذف السجل الحالى", "حذف سجل ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    cmd.Connection = Consum
                    cmd.CommandText = "delete from TSendEMail where FIELD1=" & TextCod.Text
                    Consum.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show(" تمت عملية الحذف", "حذف بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.RecordCount()
                    Consum.Close()
                    FrmSendEMail_Load(sender, e)
                Else
                    MessageBox.Show("تم ايقاف عملية الحذف", "حذف سجل", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            Else
                MessageBox.Show(" لايوجد سجل حالى لاتمام عملية الحذف", "حذف سجل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TEXTBOX2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextSubject.SelectedIndexChanged
        On Error Resume Next
        Me.BS.Position = Me.TextSubject.SelectedIndex
        Me.RecordCount()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        If RichEditControl1.Modified Then
            Dim answer As Integer
            answer = MessageBox.Show("لم يتم حفظ المستند الحالي، تريد أن تستمر دون حفظ?", "الوثيقة لم يتم حفظها", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If answer = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                OpenFile()
            End If
        Else
            OpenFile()
        End If
    End Sub
    Private Sub OpenFile()
        OpenFileDialog1.Title = "فتح ملف"
        OpenFileDialog1.DefaultExt = "rtf"
        OpenFileDialog1.Filter = "Rich Text Files|*.rtf|Text Files|*.txt|HTML Files|*.htm|All Files|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then Exit Sub
        Dim strExt As String
        strExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
        Dim unused As String = strExt.ToUpper()

        currentFile = OpenFileDialog1.FileName
        Me.RichEditControl1.Modified = False
        Me.Text = "محرر النصوص " & currentFile.ToString()
    End Sub

    Private Sub OpenFileD1()
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Title = "إدراج ملف"
        OpenFileDialog1.Filter = "Bitmap Files|*.bmp|JPEG Files|*.jpg|GIF Files|*.gif|All Files|*.*"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then Exit Sub
        Try
            Dim strImagePath As String = OpenFileDialog1.FileName
            Me.LinkLabelAttached1.Text = strImagePath
            FileStream = New FileStream(strImagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Reader = New BinaryReader(FileStream) ' تعريف القارئ
            FileData = Nothing
            FileData = Reader.ReadBytes(CType(FileStream.Length, Integer)) 'قراءة الملف
            FileSize = FileData.LongLength 'حجم الملف
            Me.LabelField10.Text = FrombytestoMB(FileSize)
            FileStream.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "إدراج ملف", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub OpenFileD2()
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Title = "إدراج ملف"
        OpenFileDialog1.Filter = "Bitmap Files|*.bmp|JPEG Files|*.jpg|GIF Files|*.gif|All Files|*.*"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then Exit Sub
        Try
            Dim strImagePath As String = OpenFileDialog1.FileName
            Me.LinkLabelAttached2.Text = strImagePath
            FileStream = New FileStream(strImagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Reader = New BinaryReader(FileStream) ' تعريف القارئ
            FileData = Nothing
            FileData = Reader.ReadBytes(CType(FileStream.Length, Integer)) 'قراءة الملف
            FileSize = FileData.LongLength 'حجم الملف
            Me.LabelField11.Text = FrombytestoMB(FileSize)
            FileStream.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "إدراج ملف", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub OpenFileD3()
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Title = "إدراج ملف"
        OpenFileDialog1.Filter = "Bitmap Files|*.bmp|JPEG Files|*.jpg|GIF Files|*.gif|All Files|*.*"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then Exit Sub
        Try
            Dim strImagePath As String = OpenFileDialog1.FileName
            Me.LinkLabelAttached3.Text = strImagePath
            FileStream = New FileStream(strImagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Reader = New BinaryReader(FileStream) ' تعريف القارئ
            FileData = Nothing
            FileData = Reader.ReadBytes(CType(FileStream.Length, Integer)) 'قراءة الملف
            FileSize = FileData.LongLength 'حجم الملف
            Me.LabelField12.Text = FrombytestoMB(FileSize)
            FileStream.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "إدراج ملف", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function SourceFileExists1() As Boolean ' وظيفة للبحث عن الملف
        If Not IO.File.Exists(Me.LinkLabelAttached1.Text) Then
            'MessageBox.Show("المرفق (1) غير موجود !")
        Else
            SourceFileExists1 = True
        End If
        Return SourceFileExists1
    End Function
    Private Function SourceFileExists2() As Boolean ' وظيفة للبحث عن الملف
        If Not IO.File.Exists(Me.LinkLabelAttached2.Text) Then
            'MessageBox.Show("المرفق (2) غير موجود !")
        Else
            SourceFileExists2 = True
        End If
        Return SourceFileExists2
    End Function
    Private Function SourceFileExists3() As Boolean ' وظيفة للبحث عن الملف
        If Not IO.File.Exists(Me.LinkLabelAttached3.Text) Then
            'MessageBox.Show("المرفق (3) غير موجود !")
        Else
            SourceFileExists3 = True
        End If
        Return SourceFileExists3
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs)


        If Equals(CBEmailSent.Text.Trim(), "") OrElse Equals(TextSubject.Text.Trim(), "") OrElse Equals(TextSubject.Text.Trim(), "") Then
            MessageBox.Show("Fill in required fields")
            Return
        End If
        Try
            Dim mailMessage As New MailMessage("XtraRichEdit@devexpress.com", CBEmailSent.Text) With {
                .Subject = TextSubject.Text
            }

            Dim exporter As New RichEditMailMessageExporter(RichEditControl1, mailMessage)
            exporter.Export()
            Dim mailSender As New SmtpClient(TextSubject.Text) With {
                .Credentials = New Net.NetworkCredential("ma965880@gmail.com", "bjbdzimflqmatrke")
            }
            mailSender.Send(mailMessage)
            MessageBox.Show("Message sent", "RichEditSendMail", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch exc As Exception
            MessageBox.Show(exc.Message)
        End Try
    End Sub

    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP2.Click
        Dim s As Integer
        Dim DS5 As New DataSet

        If Me.CBEmailSent.Text = "mycustoms2010@gmail.com" Then
            MessageBox.Show("من فضلك غير أيميل شاشة الأعدادات الى ألأيميل الخاص بك على جوجل وأدخل كلمة السر له", "أعدادات الأيميل", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim F As New FrmSettingEmail
            F.Show()
            Exit Sub
        End If
        Try
            Dim Consum As New SqlConnection(constring)
            Me.PictureBox1.Image = My.Resources.Resources.Doveofpeace
            Me.ButtonXP2.Enabled = False
            'ButtonXP5.Enabled = True
            Dim str5 As New SqlCommand("SELECT FIELD1, FIELD2, FIELD3, FIELD4, FIELD5, FIELD6, CUser FROM  TSettingEmail WHERE   CUser='" & CUser & "' and FIELD4='" & Me.CBEmailSent.Text & "'", Consum)
            Dim ADP5 As New SqlDataAdapter(str5)
            DS5.Clear()
            ADP5.Fill(DS5, "TBL")
            Dim S1 As String = DS5.Tables("TBL").Rows(0).Item(1)
            Dim S2 As String = DS5.Tables("TBL").Rows(0).Item(2)
            Dim S3 As String = DS5.Tables("TBL").Rows(0).Item(3)
            Dim S4 As String = DS5.Tables("TBL").Rows(0).Item("Field5")

            Dim mailMessage As New MailMessage()
            SmtpServer.Port = S2
            SmtpServer.Host = S1
            SmtpServer.EnableSsl = True
            SmtpServer.UseDefaultCredentials = False
            SmtpServer.Credentials = New Net.NetworkCredential(S3, S4)

            If Me.RadioButton1.Checked = True Then
                mailMessage.To.Add(Me.CBEmailSentToYou.Text)
                Me.TextMovementHistory.Text = Me.TextMovementHistory.Text & vbNewLine & ServerDateTime.ToString("yyyy-MM-dd - hh:mm:ss tt") & vbNewLine & Me.CBEmailSentToYou.Text.ToString & vbNewLine
            ElseIf Me.RadioButton2.Checked = True Then
                If Me.CountItems > 0 Then
                    For s = 0 To Me.CheckedListEmails.Items.Count - 1
                        If Me.CheckedListEmails.GetItemChecked(s) = True Then
                            mailMessage.To.Add(Me.CheckedListEmails.GetItemText(Me.CheckedListEmails.Items(s)).ToString)
                            Me.TextMovementHistory.Text = Me.TextMovementHistory.Text & vbNewLine & ServerDateTime.ToString("yyyy-MM-dd - hh:mm:ss tt") & vbNewLine & Me.CheckedListEmails.GetItemText(Me.CheckedListEmails.Items(s)).ToString & vbNewLine
                        End If
                    Next
                Else
                    MessageBox.Show("من فضلك حدد المرسل اليهم", "المرسل اليهم", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.CheckedListEmails.Focus()
                    Exit Sub
                End If
            End If

            SourceFileExists1()
            SourceFileExists2()
            SourceFileExists3()

            Dim i As Integer
            For i = 0 To 2
                If i = 0 Then
                    If SourceFileExists1() = True Then
                        If Me.LinkLabelAttached1.Text.Length > 0 Then
                            mailMessage.Attachments.Add(New Attachment(Me.LinkLabelAttached1.Text))
                        End If
                    End If

                End If
                If i = 1 Then
                    If SourceFileExists2() = True Then
                        If Me.LinkLabelAttached2.Text.Length > 0 Then
                            mailMessage.Attachments.Add(New Attachment(Me.LinkLabelAttached2.Text))
                        End If
                    End If
                End If
                If i = 2 Then
                    If SourceFileExists3() = True Then
                        If Me.LinkLabelAttached3.Text.Length > 0 Then
                            mailMessage.Attachments.Add(New Attachment(Me.LinkLabelAttached3.Text))
                        End If
                    End If
                End If
            Next

            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            SmtpServer.EnableSsl = True
            mailMessage.From = New MailAddress(Me.CBEmailSent.Text, Me.CBSender.Text, System.Text.Encoding.UTF8)
            mailMessage.Subject = " إدارة الجمعيات التعاونية _" & TextSubject.Text
            mailMessage.Priority = MailPriority.High
            Dim exporter As New RichEditMailMessageExporter(RichEditControl1, mailMessage)
            exporter.Export()



            SmtpServer.SendAsync(mailMessage, Nothing)
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.RecordCount()
        Catch ex As Exception
            Me.ButtonXP2.Enabled = True
            Me.PictureBox1.Image = My.Resources.Resources.logCO2
            'ButtonXP5.Enabled = False
            MessageBox.Show(ex.Message, "رسالة غير ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CountItems() As Integer
        Dim n As Integer
        Try
            Dim i As Integer
            For i = 0 To Me.CheckedListEmails.Items.Count - 1
                If Me.CheckedListEmails.GetItemChecked(i) = True Then
                    n += 1
                End If
            Next
            CountItems = Val(n)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return n
    End Function
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP1.Click
        OpenFileD1()
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP3.Click
        OpenFileD2()
    End Sub
    Private Sub ButtonXP4_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP4.Click
        OpenFileD3()
    End Sub
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton1.Click
        On Error Resume Next
        If Me.RadioButton1.Checked = True Then
            Me.CheckedListEmails.Enabled = False
            Me.CBConsignee.Enabled = True
            Me.CBEmailSentToYou.Enabled = True
        Else
            Me.CheckedListEmails.Enabled = True
            Me.CBConsignee.Enabled = False
            Me.CBEmailSentToYou.Enabled = False
        End If
    End Sub
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton2.Click
        On Error Resume Next
        If Me.RadioButton2.Checked = True Then
            Me.CheckedListEmails.Enabled = True
            Me.CBConsignee.Enabled = False
            Me.CBEmailSentToYou.Enabled = False
        Else
            Me.CheckedListEmails.Enabled = False
            Me.CBConsignee.Enabled = True
            Me.CBEmailSentToYou.Enabled = True
        End If
    End Sub
    Private Sub ButtonXSETINGEMAIL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXSETINGEMAIL.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If

        Dim F As New FrmSettingEmail
        F.Show()
    End Sub

    Private Sub ButtonXNEWEMAIL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXNEWEMAIL.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim F As New FrmewMail1
        F.Show()
    End Sub
    Private Sub CBConsignee_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CBConsignee.SelectedIndexChanged
        On Error Resume Next
        Dim I As Integer
        Dim Consum As New SqlConnection(constring)
        Dim DS As New DataSet
        Dim str As String = "SELECT DISTINCT FIELD3 FROM  TNewMail WHERE FIELD2='" & Me.CBConsignee.Text & "'"
        Dim ADP As New SqlDataAdapter(str, Consum)
        DS.Clear()
        ADP.Fill(DS, "TBL")
        Me.CBEmailSentToYou.Items.Clear()
        For I = 0 To DS.Tables("TBL").Rows.Count - 1
            Me.CBEmailSentToYou.Items.Add(DS.Tables("TBL").Rows(I).Item(0))
        Next I
        ADP.Dispose()
    End Sub
    Private Sub CBSender_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CBSender.SelectedIndexChanged
        On Error Resume Next
        Dim I As Integer
        Dim DS As New DataSet
        Dim Consum As New SqlConnection(constring)
        Dim str As String = "SELECT DISTINCT FIELD4 FROM  TSettingEmail WHERE FIELD6='" & Me.CBSender.Text & "'"
        Dim ADP As New SqlDataAdapter(str, Consum)
        DS.Clear()
        ADP.Fill(DS, "TBL")
        Me.CBEmailSent.Items.Clear()
        For I = 0 To DS.Tables("TBL").Rows.Count - 1
            Me.CBEmailSent.Items.Add(DS.Tables("TBL").Rows(I).Item(0))
        Next I
        ADP.Dispose()
    End Sub
    Private Sub CBSender_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles CBSender.KeyPress
        AutoComplete(Me.CBSender, e, )
    End Sub
    Private Sub CBConsignee_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles CBConsignee.KeyPress
        AutoComplete(Me.CBConsignee, e, )
    End Sub
    Private Sub ButtonSELECTALL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonSELECTALL.Click
        On Error Resume Next
        Dim s As Integer
        For s = 0 To Me.CheckedListEmails.Items.Count - 1
            If Me.CheckedListEmails.GetItemChecked(s) = False Then
                Me.CheckedListEmails.SetItemChecked(s, True)
            End If
        Next
    End Sub
    Private Sub ButtonDESELECT_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonDESELECT.Click
        On Error Resume Next
        Dim s As Integer
        For s = 0 To Me.CheckedListEmails.Items.Count - 1
            If Me.CheckedListEmails.GetItemChecked(s) = True Then
                Me.CheckedListEmails.SetItemChecked(s, False)
            End If
        Next
    End Sub
    Private Sub MNUDELALL_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            Dim resault As Integer
            Dim Consum As New SqlConnection(constring)
            If Me.BS.Count > 0 Then
                resault = MessageBox.Show("سبنم مسح كل السجلات ", "مصح بيانات جدول ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    cmd.Connection = Consum
                    cmd.CommandText = "delete from TSendEMail "
                    Consum.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show(" تمت عملية الحذف", "حذف بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.RecordCount()
                    Consum.Close()
                    Me.FrmSendEMail_Load(sender, e)
                Else
                    MessageBox.Show("تم ايقاف عملية الحذف", "حذف سجل", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            Else
                MessageBox.Show(" لايوجد سجلات حالىة لاتمام عملية الحذف", "حذف سجل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SmtpServer_SendCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles SmtpServer.SendCompleted
        Try
            Me.ButtonXP2.Enabled = True
            Me.PictureBox1.Image = My.Resources.Resources.logCO2
            'ButtonXP5.Enabled = False
            MessageBox.Show("تم ارسال الأيميل بنجاح", "رسالة تاجحة", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            Me.ButtonXP2.Enabled = True
            Me.PictureBox1.Image = My.Resources.Resources.logCO2
            'Me.ButtonXP5.Enabled = False
            SmtpServer.SendAsyncCancel()
            MessageBox.Show("تم ايقاف عملية الأرسال", "الغاء الأرسال", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonDELALL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonDELALL.Click
        If LockDelete = True Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Me.MNUDELALL_Click(sender, e)
    End Sub
    Private Sub ButtonDELATTACHFILE_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonDELATTACHFILE.Click
        Try
            If LockDelete = True Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Me.LinkLabelAttached1.Text = ""
            Me.LinkLabelAttached2.Text = ""
            Me.LinkLabelAttached3.Text = ""
            Me.LabelField10.Text = ""
            Me.LabelField11.Text = ""
            Me.LabelField12.Text = ""
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Class RichEditMailMessageExporter
        Implements IUriProvider
        Private ReadOnly control As RichEditControl
        Private ReadOnly message As MailMessage
        Private attachments As List(Of AttachementInfo)
        Private imageId As Integer

        Public Sub New(ByVal control As RichEditControl, ByVal message As MailMessage)
            Guard.ArgumentNotNull(control, "control")
            Guard.ArgumentNotNull(message, "message")
            Me.control = control
            Me.message = message
        End Sub

        Public Overridable Sub Export()
            attachments = New List(Of AttachementInfo)()
            Dim htmlView As AlternateView = CreateHtmlView()
            message.AlternateViews.Add(htmlView)
            message.IsBodyHtml = True
        End Sub

        Protected Friend Overridable Function CreateHtmlView() As AlternateView
            AddHandler control.BeforeExport, AddressOf OnBeforeExport
            Dim htmlBody As String = control.Document.GetHtmlText(control.Document.Range, Me)
            Dim view As AlternateView = AlternateView.CreateAlternateViewFromString(htmlBody, Encoding.UTF8, MediaTypeNames.Text.Html)
            RemoveHandler control.BeforeExport, AddressOf OnBeforeExport
            Dim count As Integer = attachments.Count
            For i As Integer = 0 To count - 1
                Dim info As AttachementInfo = attachments(i)
                Dim resource As New LinkedResource(info.Stream, info.MimeType) With {
                    .ContentId = info.ContentId
                }
                view.LinkedResources.Add(resource)
            Next
            Return view
        End Function

        Private Sub OnBeforeExport(ByVal sender As Object, ByVal e As BeforeExportEventArgs)
            Dim options As HtmlDocumentExporterOptions = TryCast(e.Options, HtmlDocumentExporterOptions)
            If options IsNot Nothing Then
                options.Encoding = Encoding.UTF8
            End If
        End Sub

#Region "IUriProvider Members"
        Public Function CreateCssUri(ByVal rootUri As String, ByVal styleText As String, ByVal relativeUri As String) As String Implements IUriProvider.CreateCssUri
            Return String.Empty
        End Function

        Public Function CreateImageUri(ByVal rootUri As String, ByVal image As OfficeImage, ByVal relativeUri As String) As String Implements IUriProvider.CreateImageUri
            Dim imageName As String = String.Format("image{0}", imageId)
            imageId += 1
            Dim imageFormat As OfficeImageFormat = GetActualImageFormat(image.RawFormat)
            Dim stream As Stream = New MemoryStream(image.GetImageBytes(imageFormat))
            Dim mediaContentType As String = OfficeImage.GetContentType(imageFormat)
            Dim info As New AttachementInfo(stream, mediaContentType, imageName)
            attachments.Add(info)
            Return "cid:" & imageName
        End Function

        Private Shared Function GetActualImageFormat(ByVal _officeImageFormat As OfficeImageFormat) As OfficeImageFormat
            If _officeImageFormat = OfficeImageFormat.Exif OrElse _officeImageFormat = OfficeImageFormat.MemoryBmp Then
                Return OfficeImageFormat.Png
            Else
                Return _officeImageFormat
            End If
        End Function
#End Region

    End Class

    Public Class AttachementInfo
        Private ReadOnly streamField As Stream
        Private ReadOnly mimeTypeField As String
        Private ReadOnly contentIdField As String
        Public Sub New(ByVal stream As Stream, ByVal mimeType As String, ByVal contentId As String)
            streamField = stream
            mimeTypeField = mimeType
            contentIdField = contentId
        End Sub
        Public ReadOnly Property Stream As Stream
            Get
                Return streamField
            End Get
        End Property
        Public ReadOnly Property MimeType As String
            Get
                Return mimeTypeField
            End Get
        End Property
        Public ReadOnly Property ContentId As String
            Get
                Return contentIdField
            End Get
        End Property
    End Class

End Class