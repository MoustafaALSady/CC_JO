Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraSplashScreen

Public Class FormExcel
    'Inherits DevExpress.XtraBars.Ribbon.RibbonForm
    Dim WithEvents BS As New BindingSource
<<<<<<< HEAD
    Public SqlDataAdapter1 As New SqlDataAdapter
    Dim ds As New DataSet
    Private ReadOnly currentFile As String
    Private ReadOnly checkPrint As Integer
    Private WithEvents ConnectDataBase As BackgroundWorker
    Private WithEvents SaveTab As BackgroundWorker
=======
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Dim ds As New DataSet
    Private ReadOnly currentFile As String
    Private ReadOnly checkPrint As Integer
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    ReadOnly Cancel As Boolean = False
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim ID As Integer

    <Bindable(True)>
    <Browsable(False)>
    Public Property OpenXmlBytes As Byte()
    Private Sub FormExcel_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.F1
                Me.ADDBUTTON_Click(sender, e)
            Case Keys.F2
                Me.SAVEBUTTON_Click(sender, e)
            Case Keys.F3
                Me.EDITBUTTON_Click(sender, e)
            Case Keys.F4
                Me.BUTTONCANCEL_Click(sender, e)
            Case Keys.F5
                'Me.PInternalAuditorToolStripMenuItem_Click(sender, e)
            Case Keys.F6
                'Me.PrintToolStripMenuItem_Click(sender, e)
            Case Keys.F7
                'Me.tbrCenter_Click(sender, e)
            Case Keys.PageDown
                Me.PREVIOUSBUTTON_Click(sender, e)
            Case Keys.PageUp
                Me.NEXTBUTTON_Click(sender, e)
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub FormExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Call MangUsers()
<<<<<<< HEAD
            Me.ConnectDataBase = New BackgroundWorker With {
=======
            Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
            Me.ConnectDataBase.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '==============================

        Me.ds.EnforceConstraints = True
        Me.SHOWBUTTON()
        Me.SAVEBUTTON.Enabled = False
    End Sub

<<<<<<< HEAD
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles ConnectDataBase.DoWork
=======
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm), True, True, False)
1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Me.ds.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand("", Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Me.ds.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlClient.SqlCommand("", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With str
                If RAdmin = True Then
                    'MsgBox(1)
                    .CommandText = "SELECT   EW1, EW2 ,EW3 ,WorksheetData  ,CUser ,COUser  ,da ,ne  FROM ExcelWorksheet   ORDER BY EW1"
                ElseIf Managers = True Then
                    'MsgBox(2)
                    .CommandText = "SELECT   EW1, EW2  ,EW3  ,WorksheetData  ,CUser ,COUser  ,da ,ne  FROM ExcelWorksheet  WHERE  COUser='" & ModuleGeneral.COUser & "' ORDER BY EW1"
                ElseIf InternalAuditor = True Then
                    'MsgBox(3)
                    .CommandText = "SELECT   EW1, EW2  ,EW3  ,WorksheetData  ,CUser ,COUser  ,da ,ne  FROM ExcelWorksheet  WHERE  COUser='" & ModuleGeneral.COUser & "' ORDER BY EW1"
                Else
                    .CommandText = "SELECT   EW1, EW2  ,EW3  ,WorksheetData  ,CUser ,COUser  ,da ,ne  FROM ExcelWorksheet  WHERE  CUser='" & ModuleGeneral.CUser & "' ORDER BY EW1"

                End If
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Me.SqlDataAdapter1 = New SqlDataAdapter(str)
                Me.ds.Clear()
                Me.ds = New DataSet
                Me.SqlDataAdapter1.Fill(Me.ds, "ExcelWorksheet")

                'Dim receivedBytes() As Byte
                'If Me.ds.Tables(0).Rows.Count > 0 Then
                '    Dim sqlReader As SqlDataReader = str.ExecuteReader()
                '    sqlReader.Read()
                '    receivedBytes = CType(sqlReader("MSG4"), Byte())
                '    Me.SpreadsheetControl1.Document.LoadDocument(receivedBytes, DevExpress.Spreadsheet.DocumentFormat.OpenXml)
                '    'Me.SpreadsheetControl1.LoadDocument(Me.ds.Tables(0).Rows(Me.BS.Position)("MSG4").ToString)
                '    AddHandler ds.Tables(0).ColumnChanged, AddressOf Cars_ColumnChanged
                '    UpdateCommandsState()
                'End If
                Consum.Close()
            End With
            'RtfContent
            FILLCOMBOBOX1("ExcelWorksheet", "EW2", "CUser", CUser, Me.TEXTBOX2)
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
        If TestNet = True Then
            'Label3.ForeColor = Color.Yellow
            'Label3.Text = "فضلا انتظر قليلا .. يتم تحميل سجلات الحقل"
        Else
            Me.Close()
        End If
    End Sub


<<<<<<< HEAD
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
=======
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try

            'Dim text As Byte()
            'RichEditControl1.LoadDocument("Documents/FirstLook.docx")
            'text = RichEditControl1.OpenXmlBytes

            If e.Cancelled Then Exit Sub
            'BS.DataSource = ds
            'BS.DataMember = "MYMESSAGES"
            Me.BS.DataSource = Me.ds.Tables("ExcelWorksheet")
            RowCount = Me.BS.Count
            Me.TEXTBOX1.DataBindings.Add("text", Me.BS, "EW1", True, 1, "")
            Me.TEXTBOX2.DataBindings.Add("text", Me.BS, "EW2", True, 1, "")
            Me.TEXTBOX3.DataBindings.Add("text", Me.BS, "EW3", True, 1, "")

            Me.TextCUser.DataBindings.Add("text", Me.BS, "CUser", True, 1, "")
            Me.TextCOUser.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
            Me.TextDa.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextNe.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            Dim receivedBytes() As Byte
            If Me.ds.Tables(0).Rows.Count > 0 Then
                receivedBytes = CType(Me.ds.Tables(0).Rows(Me.BS.Position)("WorksheetData"), Byte())
                Me.SpreadsheetControl1.Document.LoadDocument(receivedBytes, DevExpress.Spreadsheet.DocumentFormat.OpenXml)
                'AddHandler ds.Tables(0).ColumnChanged, AddressOf Cars_ColumnChanged
                'UpdateCommandsState()
            End If


            'SurroundingSub()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorConnectDataBase_RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SurroundingSub()
        'Me.RichEditControl1.Document.DefaultParagraphProperties.Alignment = ParagraphAlignment.Right
        Dim document As DevExpress.XtraRichEdit.API.Native.Document = SpreadsheetControl1.Document
        document.DefaultParagraphProperties.RightToLeft = True


    End Sub
    Private Sub Cars_ColumnChanged(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
        If Not SpreadsheetControl1.Modified Then
            e.Row.AcceptChanges()
        End If
    End Sub
    Private Sub RichEditControl1_ModifiedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SpreadsheetControl1.ModifiedChanged
        'UpdateCommandsState()
    End Sub
    'Private Sub UpdateCommandsState()
    '    ' Update control level commands state
    '    'dataNavigator1.Buttons.CancelEdit.Enabled = RichEditControl1.Modified
    '    'dataNavigator1.Buttons.EndEdit.Enabled = RichEditControl1.Modified
    '    'Static P As Integer
    '    'P = Me.BS.Position
    '    '' Update data (in-memory) level commands state
    '    Dim currentDataRow As DataRow = Me.ds.Tables(0).Rows(Me.BS.Position)
    '    Me.BUTTONCANCEL.Enabled = (currentDataRow.RowState <> DataRowState.Unchanged) AndAlso Not Me.SpreadsheetControl1.Modified
    '    'Me.EDITBUTTON.Enabled = Me.ds.HasChanges() AndAlso Not Me.RichEditControl1.Modified

    '    '' Update info panel
    '    If Me.ds.Tables(0).Rows.Count > 0 Then
    '        Me.lblCurrentRecordInfo.Text = String.Format("Current Record: {0}{1}", Me.BS.Position, IIf(Me.BUTTONCANCEL.Enabled, "*", ""))
    '    End If



    'End Sub
    Private Sub SAVERECORD()
        Try
            Dim N As Double
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim cmd1 As New SqlCommand("SELECT MAX(EW1) FROM ExcelWorksheet", Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(EW1) FROM ExcelWorksheet", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim resualt As Object = cmd1.ExecuteScalar()
            If IsDBNull(resualt) Then
                N = 1
            Else
                N = CType(resualt, Integer) + 1
            End If
            Consum.Close()

            Dim command As SqlCommand = Consum.CreateCommand()
            command.CommandText = "INSERT INTO ExcelWorksheet( EW2, EW3, WorksheetData , CUser, COUser, da, ne) VALUES     ( @EW2, @EW3, @WorksheetData , @CUser, @COUser, @da, @ne)"
            'Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
            With command
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@EW1", SqlDbType.Int).Value = Val(N) + 1
                .Parameters.Add("@EW2", SqlDbType.NVarChar).Value = Me.TEXTBOX2.Text
<<<<<<< HEAD
                .Parameters.Add("@EW3", SqlDbType.NVarChar).Value = Me.TEXTBOX3.Value.ToString("yyyy-MM-dd")
=======
                .Parameters.Add("@EW3", SqlDbType.NVarChar).Value = TEXTBOX3.Text
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

                Dim dataParameter As New SqlParameter("@WorksheetData", SqlDbType.VarBinary) With {
                    .Value = SpreadsheetControl1.SaveDocument(DevExpress.Spreadsheet.DocumentFormat.OpenXml)
                }
                .Parameters.Add(dataParameter)
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            command.ExecuteNonQuery()

            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UPDATERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim command As SqlCommand = Consum.CreateCommand()
            command.CommandText = " Update ExcelWorksheet SET  EW2 = @EW2, EW3 = @EW3, WorksheetData = @WorksheetData, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne  WHERE EW1 =" & Val(ID)
            Dim N As Integer
            With command
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@EW1", SqlDbType.Int).Value = Val(N) + 1
                .Parameters.Add("@EW2", SqlDbType.NVarChar).Value = Me.TEXTBOX2.Text
                .Parameters.Add("@EW3", SqlDbType.NVarChar).Value = Me.TEXTBOX3.Value.ToString("yyyy-MM-dd")
                Dim dataParameter As New SqlParameter("@WorksheetData", SqlDbType.VarBinary) With {
                    .Value = SpreadsheetControl1.SaveDocument(DevExpress.Spreadsheet.DocumentFormat.OpenXml)
                }
                .Parameters.Add(dataParameter)
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            command.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUPDATERECORD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub
<<<<<<< HEAD
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles SaveTab.DoWork
=======
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try

            'Me.RichEditControl1.RtfText

1:


            '            


            'Me.SqlDataAdapter1.Update(Me.ds, "MYMESSAGES")
            'Me.ds = New DataSet
            'Me.ds.Tables("MYMESSAGES").AcceptChanges()

            'Me.SqlDataAdapter1.Fill(Me.ds, "MYMESSAGES")

            'Me.UpdateCommandsState()


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
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
            Else
                e.Cancel = True
                Me.PictureBox2False()
                MessageBox.Show(ex.Message, "ErrorDoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
=======
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If DelRow = True Then

                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = Me.ds.Tables(0)
            Me.TEXTBOX1.Enabled = True

            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.Count()
            'Me.Label3.Text = ServerDateTime.ToString("hh:mm:ss tt")
            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")

                Exit Sub
            End If
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.save
=======
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "ErrorRunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Me.TEXTBOX2.Focus()
            Me.TEXTBOX2.SelectAll()
        End If
    End Sub
<<<<<<< HEAD
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
=======
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.RecordCount()
    End Sub
    Private Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.ds.Tables("ExcelWorksheet").Rows.Count - 1 Then
            Forward = True
        End If
        If Me.ds.Tables(0).Rows.Count > 0 Then
            ID = Me.ds.Tables("ExcelWorksheet").Rows(Me.BS.Position).Item("EW1")

            Dim receivedBytes() As Byte
            If Me.ds.Tables(0).Rows.Count > 0 Then
                receivedBytes = CType(Me.ds.Tables(0).Rows(Me.BS.Position)("WorksheetData"), Byte())
                Me.SpreadsheetControl1.Document.LoadDocument(receivedBytes, DevExpress.Spreadsheet.DocumentFormat.OpenXml)
            End If
            'AddHandler ds.Tables(0).ColumnChanged, AddressOf Cars_ColumnChanged
            'UpdateCommandsState()
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        'Me.DISPLAYRECORD()
        'Me.SurroundingSub()
        'Me.TextBox5.Text = CUser.Trim
        'Me.TextBox6.Text = COUser.Trim
        'Me.TextBox7.Text = ServerDateTime.ToString("yyyy-MM-dd")
        'Me.TextBox8.Text = ServerDateTime.ToString("hh:mm:ss tt")
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        'Me.PrintToolStripMenuItem.Enabled = LockPrint
        'Me.ToolStripButton7.Enabled = LockPrint
    End Sub
    Private Sub DISPLAYRECORD()
        On Error Resume Next
        Me.TEXTBOX1.Text = Me.ds.Tables("MYMESSAGES").Rows(Me.BS.Position)("MSG1").ToString
        Me.TEXTBOX2.Text = Me.ds.Tables("MYMESSAGES").Rows(Me.BS.Position)("MSG2").ToString
        Me.TEXTBOX3.Text = Me.ds.Tables("MYMESSAGES").Rows(Me.BS.Position)("MSG3").ToString
        'Me.SpreadsheetControl1.RtfText = Me.ds.Tables("MYMESSAGES").Rows(Me.BS.Position)("MSG4").ToString
    End Sub
<<<<<<< HEAD
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FIRSTBUTTON.Click
=======
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PREVIOUSBUTTON.Click
=======
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Position - 1
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NEXTBUTTON.Click
=======
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Position + 1
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
=======
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
=======
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.ADDBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Me.Count()

            Dim n As Double
            Dim s As Double
            n = Me.BS.Count
            Me.BS.Position = Me.BS.Count - 1
            s = Val(Me.TEXTBOX1.Text)

            Me.BS.EndEdit()
            Me.BS.AddNew()
            CLEARDATA1(Me)
            'Me.RichEditControl1.ClearUndo()

            If n = 0 Then
                Me.TEXTBOX1.Text = 1
            Else
                If n >= s Then
                    Me.TEXTBOX1.Text = Val(n) + 1
                Else
                    Me.TEXTBOX1.Text = Val(s) + 1
                End If
            End If
            Me.TEXTBOX2.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
<<<<<<< HEAD
        Dim Sound As IO.Stream = My.Resources.addv
        My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
=======
        Dim Sound As System.IO.Stream = My.Resources.addv
        My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = True

            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockSave = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SAVERECORD()
<<<<<<< HEAD
            Me.SaveTab = New BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
=======
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = True
            Static P As Integer
            P = Me.BS.Position
            Me.BS.Position = P

            'Me.RecordCount()
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.UPDATERECORD()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count


<<<<<<< HEAD
            Me.SaveTab = New BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
=======
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        Me.EDITBUTTON.Enabled = True
        Me.BUTTONCANCEL.Enabled = True
        Me.DELETEBUTTON.Enabled = True
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
=======
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        MYDELETERECORD("ExcelWorksheet", "EW1", Me.TEXTBOX1, Me.BS, True)
        FormExcel_Load(sender, e)
    End Sub

    Private Sub ButtnSearch_Click(sender As Object, e As EventArgs) Handles ButtnSearch.Click
        On Error Resume Next
        Me.BS.Position = BS.Find("EW2", Me.TEXTBOX2.Text)
        Me.RecordCount()
    End Sub

<<<<<<< HEAD
    Private Sub TEXTBOX2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTBOX2.SelectedIndexChanged
=======
    Private Sub TEXTBOX2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTBOX2.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'BS.Position = BS.Find("MSG1", Me.TEXTBOX2.Text)
        Me.SpreadsheetControl1.Focus()
        Me.RecordCount()
    End Sub

End Class