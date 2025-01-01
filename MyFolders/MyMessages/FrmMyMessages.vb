Option Explicit Off
'Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class FrmMyMessages
    Inherits Form
    Dim WithEvents BS As New BindingSource
    Public SqlDataAdapter1 As New SqlDataAdapter
    Dim ds As New DataSet
    Private currentFile As String
    Private checkPrint As Integer
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    ReadOnly Cancel As Boolean = False
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0


    'Public WithEvents CommandZoom1 As Command


    'Private Sub frmMyMessages_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.HandleCreated
    '    R.Container = Me
    'End Sub
    'Private Sub frmMyMessages_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
    '    R.ResizeControls()
    'End Sub
    Private Sub FrmMyMessages_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
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
                Me.PInternalAuditorToolStripMenuItem_Click(sender, e)
            Case Keys.F6
                Me.PrintToolStripMenuItem_Click(sender, e)
            Case Keys.F7
                'Me.tbrCenter_Click(sender, e)
            Case Keys.PageDown
                Me.PREVIOUSBUTTON_Click(sender, e)
            Case Keys.PageUp
                Me.NEXTBUTTON_Click(sender, e)
            Case Keys.Escape
                Me.Close()
        End Select
        e.Handled = True
    End Sub



    Private Sub FrmMYMESSAGES_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next

            Me.ConnectDataBase = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.ConnectDataBase.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '==============================
        Call MangUsers()
        Me.ds.EnforceConstraints = True
        Me.SHOWBUTTON()
        Me.SAVEBUTTON.Enabled = False
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Dim Consum As New SqlConnection(constring)
            Me.ds.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand("", Consum)
            With str
                If RAdmin = True Then
                    .CommandText = "SELECT  MSG1,MSG2  ,MSG3 ,MSG4  ,CUser ,COUser  ,da ,ne  FROM MYMESSAGES   ORDER BY MSG1"
                ElseIf Managers = True Then
                    .CommandText = "SELECT  MSG1,MSG2  ,MSG3 ,MSG4  ,CUser ,COUser  ,da ,ne  FROM MYMESSAGES  WHERE  COUser='" & ModuleGeneral.COUser & "' ORDER BY MSG1"
                ElseIf InternalAuditor = True Then
                    .CommandText = "SELECT  MSG1,MSG2  ,MSG3 ,MSG4  ,CUser ,COUser  ,da ,ne  FROM MYMESSAGES  WHERE  COUser='" & ModuleGeneral.COUser & "' ORDER BY MSG1"
                Else
                    .CommandText = "SELECT  MSG1,MSG2  ,MSG3 ,MSG4  ,CUser ,COUser  ,da ,ne  FROM MYMESSAGES  WHERE  CUser='" & ModuleGeneral.CUser & "' ORDER BY MSG1"
                End If
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Me.SqlDataAdapter1 = New SqlDataAdapter(str)
                Dim builder3 As New SqlCommandBuilder(Me.SqlDataAdapter1)
                Me.ds.Clear()
                Me.ds = New DataSet
                Me.SqlDataAdapter1.Fill(Me.ds, "MYMESSAGES")
                Consum.Close()
            End With
            FILLCOMBOBOX1("MYMESSAGES", "MSG2", "CUser", CUser, Me.TEXTBOX2)
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
            'Label3.Text = "›÷·« «‰ Ÿ— ﬁ·Ì·« .. Ì „  Õ„Ì· ”Ã·«  «·Õﬁ·"
        Else
            Me.Close()
        End If
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            'BS.DataSource = ds
            'BS.DataMember = "MYMESSAGES"
            Me.BS.DataSource = Me.ds.Tables("MYMESSAGES")
            RowCount = Me.BS.Count
            Me.TEXTBOX1.DataBindings.Add("text", Me.BS, "MSG1", True, 1, "")
            Me.TEXTBOX2.DataBindings.Add("text", Me.BS, "MSG2", True, 1, "")
            Me.TEXTBOX3.DataBindings.Add("text", Me.BS, "MSG3", True, 1, "")
            Me.RichTextBoxEx1.DataBindings.Add("text", Me.BS, "MSG4", True, 1, "")
            Me.TextBox5.DataBindings.Add("text", Me.BS, "CUser", True, 1, "")
            Me.TextBox6.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
            Me.TextBox7.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextBox8.DataBindings.Add("text", Me.BS, "ne", True, 1, "")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorConnectDataBase_RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " „‰ " & Me.BS.Count
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try



1:          Me.SqlDataAdapter1.Update(Me.ds, "MYMESSAGES")
            Me.ds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.ds, "MYMESSAGES")
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
                MessageBox.Show(ex.Message, "ErrorDoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Me.BS.DataSource = Me.ds.Tables("MYMESSAGES")
            Me.TEXTBOX1.Enabled = True

            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.Count()
            'Me.Label3.Text = ServerDateTime.ToString("hh:mm:ss tt")
            If Me.BS.Count < Me.RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & Me.RowCount - Me.BS.Count, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & Me.BS.Count - Me.RowCount, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")

                Exit Sub
            End If
            Dim Sound As IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
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
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
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
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " „‰ " & TotalRecords.ToString
        If BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.ds.Tables("MYMESSAGES").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        'Me.DISPLAYRECORD()

        Me.TextBox5.Text = CUser.Trim
        Me.TextBox6.Text = COUser.Trim
        Me.TextBox7.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextBox8.Text = ServerDateTime.ToString("hh:mm:ss tt")
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.PrintToolStripMenuItem.Enabled = LockPrint
        'Me.ToolStripButton7.Enabled = LockPrint
    End Sub
    Private Sub DISPLAYRECORD()
        On Error Resume Next
        Me.TEXTBOX1.Text = Me.ds.Tables("MYMESSAGES").Rows(Me.BS.Position)("MSG1").ToString
        Me.TEXTBOX2.Text = Me.ds.Tables("MYMESSAGES").Rows(Me.BS.Position)("MSG2").ToString
        Me.TEXTBOX3.Text = Me.ds.Tables("MYMESSAGES").Rows(Me.BS.Position)("MSG3").ToString
        Me.RichTextBoxEx1.Rtf = Me.ds.Tables("MYMESSAGES").Rows(Me.BS.Position)("MSG4").ToString
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
        Try
            Me.ADDBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If LockAddRow = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
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
            Me.RichTextBoxEx1.Clear()
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
        Dim Sound As IO.Stream = My.Resources.addv
        My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
        Try
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = True

            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockSave = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockUpdate = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
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
            Me.RecordCount()
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        Me.EDITBUTTON.Enabled = True
        Me.BUTTONCANCEL.Enabled = True
        Me.DELETEBUTTON.Enabled = True
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If LockDelete = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… Õ–› «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        MYDELETERECORD("MYMESSAGES", "MSG1", Me.TEXTBOX1, Me.BS, True)
        FrmMYMESSAGES_Load(sender, e)
    End Sub
    Private Sub TEXTBOX2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click
        On Error Resume Next
        If Me.RichTextBoxEx1.Modified Then

            Dim answer As Integer
            answer = MessageBox.Show("«·„” ‰œ «·Õ«·Ì ·„ Ì „ Õ›ŸÂ«° Â·  —Ìœ «·«” „—«— œÊ‰ Õ›Ÿø", "Unsaved Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If answer = Windows.Forms.DialogResult.Yes Then
                RichTextBoxEx1.Clear()
            Else
                Exit Sub
            End If
        Else
            Me.RichTextBoxEx1.Clear()
        End If
        currentFile = ""
        Me.Text = "„” ‰œ ÃœÌœ"
    End Sub
    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click
        On Error Resume Next
        If Me.RichTextBoxEx1.Modified Then
            Dim answer As Integer
            answer = MessageBox.Show("≈‰ «·ÊÀÌﬁ… «·Õ«·Ì… ·„ Ì „ Õ›ŸÂ° Â·  —Ìœ «·«” „—«— œÊ‰ Õ›Ÿø", "ÊÀÌﬁ… €Ì— „Õ›ÊŸ…", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If answer = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                Me.OpenFile()
            End If
        Else
            Me.OpenFile()
        End If
    End Sub
    Private Sub OpenFile()
        On Error Resume Next
        Me.OpenFileDialog1.Title = "› Õ „·›"
        Me.OpenFileDialog1.DefaultExt = "rtf"
        Me.OpenFileDialog1.Filter = "Rich Text Files|*.rtf|Text Files|*.txt|HTML Files|*.htm|All Files|*.*"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then Exit Sub
        Dim strExt As String
        strExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
        strExt = strExt.ToUpper()

        Select Case strExt
            Case ".RTF"
                Me.RichTextBoxEx1.LoadFile(OpenFileDialog1.FileName, RichTextBoxStreamType.RichText)
            Case Else
                Dim txtReader As IO.StreamReader
                txtReader = New IO.StreamReader(OpenFileDialog1.FileName)
                Me.RichTextBoxEx1.Text = txtReader.ReadToEnd
                txtReader.Close()
                txtReader = Nothing
                Me.RichTextBoxEx1.SelectionStart = 0
                Me.RichTextBoxEx1.SelectionLength = 0
        End Select

        currentFile = Me.OpenFileDialog1.FileName
        Me.RichTextBoxEx1.ReadOnly = False
        'Error	1	Property 'Modified' is 'ReadOnly'.	E:\2019\co26\MyFolders\MyMessages\frmMyMessages.vb	484	9	co

        Me.Text = "„Õ—— «·‰’Ê’ " & currentFile.ToString()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SaveToolStripMenuItem.Click
        On Error Resume Next
        If currentFile = "" Then
            SaveAsToolStripMenuItem_Click(Me, e)
            Exit Sub
        End If
        Dim strExt As String
        strExt = System.IO.Path.GetExtension(currentFile)
        strExt = strExt.ToUpper()

        Select Case strExt
            Case ".RTF"
                Me.RichTextBoxEx1.SaveFile(currentFile)
            Case Else
                ' to save as plain text
                Dim txtWriter As IO.StreamWriter
                txtWriter = New IO.StreamWriter(currentFile)
                txtWriter.Write(RichTextBoxEx1.Text)
                txtWriter.Close()
                txtWriter = Nothing
                Me.RichTextBoxEx1.SelectionStart = 0
                Me.RichTextBoxEx1.SelectionLength = 0
                Me.RichTextBoxEx1.ReadOnly = False
        End Select
        Me.Text = "„Õ—— «·‰’Ê’ " & currentFile.ToString()
    End Sub
    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        On Error Resume Next
        Me.SaveFileDialog1.Title = "Õ›Ÿ «·„·›"
        Me.SaveFileDialog1.DefaultExt = "rtf"
        Me.SaveFileDialog1.Filter = "Rich Text Files|*.rtf|Text Files|*.txt|HTML Files|*.htm|All Files|*.*"
        Me.SaveFileDialog1.FilterIndex = 1
        Me.SaveFileDialog1.ShowDialog()

        If Me.SaveFileDialog1.FileName = "" Then Exit Sub

        Dim strExt As String
        strExt = System.IO.Path.GetExtension(SaveFileDialog1.FileName)
        strExt = strExt.ToUpper()

        Select Case strExt
            Case ".RTF"
                Me.RichTextBoxEx1.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.RichText)
            Case Else
                Dim txtWriter As IO.StreamWriter
                txtWriter = New IO.StreamWriter(SaveFileDialog1.FileName)
                txtWriter.Write(Me.RichTextBoxEx1.Text)
                txtWriter.Close()
                txtWriter = Nothing
                Me.RichTextBoxEx1.SelectionStart = 0
                Me.RichTextBoxEx1.SelectionLength = 0
        End Select

        currentFile = Me.SaveFileDialog1.FileName
        Me.RichTextBoxEx1.ReadOnly = False
        Me.Text = "„Õ—— «·‰’Ê’" & currentFile.ToString()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        On Error Resume Next
        If Me.RichTextBoxEx1.Modified Then

            Dim answer As Integer
            answer = MessageBox.Show("·„ Ì „ Õ›Ÿ «·„·› Â·  Êœ «·«” „—«—", "·„ Ì „ «·Õ›Ÿ", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)

            If answer = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                Application.Exit()
            End If
        Else
            Application.Exit()
        End If
    End Sub
    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        Try
            Me.RichTextBoxEx1.SelectAll()
        Catch exc As Exception
            MessageBox.Show(" ÕœÌœ", "·« Ì„ﬂ‰  ÕœÌœ Ã„Ì⁄ „ﬂÊ‰«  «·„” ‰œ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            Me.RichTextBoxEx1.Copy()
        Catch exc As Exception
            MessageBox.Show("‰”Œ", "€Ì— ﬁ«œ— ⁄·Ï ‰”Œ «·„·›", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        Try
            Me.RichTextBoxEx1.Cut()
        Catch exc As Exception
            MessageBox.Show("ﬁ’", "Œÿ« ›Ì «·ﬁ’", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        Try
            Me.RichTextBoxEx1.Paste()
        Catch exc As Exception
            MessageBox.Show("·’ﬁ", "·« Ì„ﬂ‰ ·’ﬁ «·„Õ ÊÏ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SelectFontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SelectFontToolStripMenuItem.Click
        On Error Resume Next
        If Me.RichTextBoxEx1.SelectionFont IsNot Nothing Then
            Me.FontDialog1.Font = Me.RichTextBoxEx1.SelectionFont
        Else
            FontDialog1.Font = Nothing
        End If
        Me.FontDialog1.ShowApply = True
        If FontDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.RichTextBoxEx1.SelectionFont = Me.FontDialog1.Font
        End If
    End Sub

    Private Sub ButtonItemFontColor_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonItemFontColor.Click
        On Error Resume Next
        ColorDialog1.Color = Me.RichTextBoxEx1.ForeColor

        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.RichTextBoxEx1.SelectionColor = ColorDialog1.Color
        End If
    End Sub
    Private Sub BoldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BoldToolStripMenuItem.Click
        On Error Resume Next
        If Me.RichTextBoxEx1.SelectionFont IsNot Nothing Then

            Dim currentFont As Font = RichTextBoxEx1.SelectionFont
            Dim newFontStyle As FontStyle

            If Me.RichTextBoxEx1.SelectionFont.Bold = True Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Bold
            End If

            Me.RichTextBoxEx1.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub
    Private Sub ItalicToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ItalicToolStripMenuItem.Click
        On Error Resume Next
        If Me.RichTextBoxEx1.SelectionFont IsNot Nothing Then

            Dim currentFont As Font = RichTextBoxEx1.SelectionFont
            Dim newFontStyle As FontStyle

            If Me.RichTextBoxEx1.SelectionFont.Italic = True Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Italic
            End If
            Me.RichTextBoxEx1.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub
    Private Sub UnderlineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles UnderlineToolStripMenuItem.Click
        On Error Resume Next
        If Me.RichTextBoxEx1.SelectionFont IsNot Nothing Then
            Dim currentFont As Font = RichTextBoxEx1.SelectionFont
            Dim newFontStyle As FontStyle

            If Me.RichTextBoxEx1.SelectionFont.Underline = True Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Underline
            End If
            Me.RichTextBoxEx1.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub
    Private Sub NormalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NormalToolStripMenuItem.Click
        On Error Resume Next
        If Me.RichTextBoxEx1.SelectionFont IsNot Nothing Then

            Dim currentFont As Font = Me.RichTextBoxEx1.SelectionFont
            Dim newFontStyle As FontStyle
            newFontStyle = FontStyle.Regular

            Me.RichTextBoxEx1.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub
    Private Sub PageColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PageColorToolStripMenuItem.Click
        On Error Resume Next
        ColorDialog1.Color = RichTextBoxEx1.BackColor

        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.RichTextBoxEx1.BackColor = ColorDialog1.Color
        End If
    End Sub
    Private Sub FontColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FontColorToolStripMenuItem.Click
        On Error Resume Next
        ColorDialog1.Color = RichTextBoxEx1.BackColor

        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.RichTextBoxEx1.BackColor = ColorDialog1.Color
        End If
    End Sub
    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mnuUndo.Click
        On Error Resume Next
        If Me.RichTextBoxEx1.CanUndo Then Me.RichTextBoxEx1.Undo()
    End Sub
    Private Sub MnuRedo_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mnuRedo.Click
        On Error Resume Next
        If Me.RichTextBoxEx1.CanRedo Then Me.RichTextBoxEx1.Redo()
    End Sub
    Private Sub LeftToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LeftToolStripMenuItem.Click
        On Error Resume Next
        Me.RichTextBoxEx1.SelectionAlignment = HorizontalAlignment.Left
    End Sub
    Private Sub CenterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CenterToolStripMenuItem.Click
        On Error Resume Next
        Me.RichTextBoxEx1.SelectionAlignment = HorizontalAlignment.Center
    End Sub
    Private Sub RightToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles RightToolStripMenuItem.Click
        RichTextBoxEx1.SelectionAlignment = HorizontalAlignment.Right
    End Sub
    Private Sub MnuIndent0_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mnuIndent0.Click
        Me.RichTextBoxEx1.SelectionIndent = 0
    End Sub
    Private Sub MnuIndent5_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mnuIndent5.Click
        Me.RichTextBoxEx1.SelectionIndent = 5
    End Sub
    Private Sub MnuIndent10_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mnuIndent10.Click
        Me.RichTextBoxEx1.SelectionIndent = 10
    End Sub
    Private Sub MnuIndent15_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mnuIndent15.Click
        Me.RichTextBoxEx1.SelectionIndent = 15
    End Sub
    Private Sub MnuIndent20_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mnuIndent20.Click
        Me.RichTextBoxEx1.SelectionIndent = 20
    End Sub
    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FindToolStripMenuItem.Click
        On Error Resume Next
        Dim f As New FrmFind()
        f.Show()
    End Sub
    Private Sub FindAndReplaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FindAndReplaceToolStripMenuItem.Click
        On Error Resume Next
        Dim f As New FrmReplace()
        f.Show()
    End Sub
    Private Sub PInternalAuditorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PInternalAuditorToolStripMenuItem.Click
        On Error Resume Next
        Me.PrintPInternalAuditorDialog1.Document = Me.PrintDocument1
        Me.PrintPInternalAuditorDialog1.ShowDialog()
    End Sub
    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PrintToolStripMenuItem.Click
        On Error Resume Next
        Me.PrintDialog1.Document = Me.PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub
    Private Sub MnuPageSetup_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mnuPageSetup.Click
        Me.PageSetupDialog1.Document = Me.PrintDocument1
        Me.PageSetupDialog1.ShowDialog()
    End Sub
    Private Sub InsertImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles InsertImageToolStripMenuItem.Click
        Me.OpenFileDialog1.Title = "≈œ—«Ã ’Ê—…"
        Me.OpenFileDialog1.DefaultExt = "rtf"
        Me.OpenFileDialog1.Filter = "Bitmap Files|*.bmp|JPEG Files|*.jpg|GIF Files|*.gif"
        Me.OpenFileDialog1.FilterIndex = 1
        Me.OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then Exit Sub
        Try
            Dim strImagePath As String = OpenFileDialog1.FileName
            Dim img As Image
            img = Image.FromFile(strImagePath)
            Clipboard.SetDataObject(img)
            Dim df As DataFormats.Format
            df = DataFormats.GetFormat(DataFormats.Bitmap)
            If Me.RichTextBoxEx1.CanPaste(df) Then
                Me.RichTextBoxEx1.Paste(df)
            End If
        Catch ex As Exception
            MessageBox.Show("€Ì— ﬁ«œ— ⁄·Ï ≈œ—«Ã ’Ê—… »Â–… «·’Ì€…", "≈œ—«Ã ’Ê—…", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ButtonItem61_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonItem61.Click
        Me.BoldToolStripMenuItem_Click(Me, e)
    End Sub
    Private Sub ButtonItem62_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonItem62.Click
        Me.ItalicToolStripMenuItem_Click(Me, e)
    End Sub
    Private Sub ButtonItem63_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonItem63.Click
        Me.UnderlineToolStripMenuItem_Click(Me, e)
    End Sub
    Private Sub ButtonItem64_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonItem64.Click
        On Error Resume Next
        If Me.RichTextBoxEx1.SelectionFont IsNot Nothing Then

            Dim currentFont As Font = Me.RichTextBoxEx1.SelectionFont
            Dim newFontStyle As FontStyle
            newFontStyle = FontStyle.Regular

            Me.RichTextBoxEx1.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub
    Private Sub ColorPickerDropDown1_SelectedColorChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ColorPickerDropDown1.SelectedColorChanged
        'If TypeOf sender Is ColorPickerDropDown Then
        '    Me.RichTextBoxEx1.SelectionColor = CType(sender, ColorPickerDropDown).SelectedColor
        'End If
    End Sub
    Private Sub TbrNew1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbrNew1.Click
        Me.NewToolStripMenuItem_Click(Me, e)
    End Sub
    Private Sub TbrOpen1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbrOpen1.Click
        Me.OpenToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub TbrSave1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbrSave1.Click
        Me.SaveToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ButtonItemFint_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonItemFint.Click
        Dim f As New FrmFind()
        f.Show()
    End Sub

    Private Sub ButtonItemReplace_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonItemReplace.Click
        Me.FindAndReplaceToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ButtonItemPrintV_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonItemPrintV.Click
        Me.PInternalAuditorToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ButtonItemPrint_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonItemPrint.Click
        Me.PrintToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ButtonItemPKCHR_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonItemPKCHR.Click
        InsertImageToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub ButtonAlignLeft_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles buttonAlignLeft.Click
        On Error Resume Next
        Me.RichTextBoxEx1.SelectionAlignment = HorizontalAlignment.Left
    End Sub
    Private Sub ButtonAlignCenter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles buttonAlignCenter.Click
        On Error Resume Next
        Me.RichTextBoxEx1.SelectionAlignment = HorizontalAlignment.Center
    End Sub
    Private Sub ButtonAlignRight_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles buttonAlignRight.Click
        Me.RichTextBoxEx1.SelectionAlignment = HorizontalAlignment.Right
    End Sub
    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        Me.checkPrint = 0
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'Me.checkPrint = Me.RichTextBoxEx1.Print(checkPrint, Me.RichTextBoxEx1.TextLength, e)

        ' Look for more pages
        If Me.checkPrint < Me.RichTextBoxEx1.TextLength Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub
    Private Sub TbrFont_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbrFont.Click
        Me.SelectFontToolStripMenuItem_Click(Me, e)
    End Sub
    Private Sub ButtonCopy_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles buttonCopy.Click
        Me.CopyToolStripMenuItem_Click(Me, e)
    End Sub


    Private Sub ButtonCut_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles buttonCut.Click
        Me.CutToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ComboFont_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles comboFont.Click
        'Me.SelectFontToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ToolStripButton4.Click
        If Me.RichTextBoxEx1.CanUndo Then Me.RichTextBoxEx1.Undo()
    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ToolStripButton5.Click
        If Me.RichTextBoxEx1.CanRedo Then Me.RichTextBoxEx1.Redo()
    End Sub
    Private Sub ButtonItemPaste_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles buttonItemPaste.Click
        Me.PasteToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub AddBulletsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As EventArgs) Handles AddBulletsToolStripMenuItem.Click
        Me.RichTextBoxEx1.BulletIndent = 10
        Me.RichTextBoxEx1.SelectionBullet = True
    End Sub
    Private Sub RemoveBulletsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As EventArgs) Handles RemoveBulletsToolStripMenuItem.Click
        Me.RichTextBoxEx1.SelectionBullet = False
    End Sub
    Private Sub MNUCOPY_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MNUCOPY.Click
        Me.CopyToolStripMenuItem_Click(Me, e)
    End Sub
    Private Sub MNUCUT_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MNUCUT.Click
        Me.CutToolStripMenuItem_Click(Me, e)
    End Sub
    Private Sub MNUPASTE_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MNUPASTE.Click
        Me.PasteToolStripMenuItem_Click(Me, e)
    End Sub
    Private Sub MNUSELECTALL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MNUSELECTALL.Click
        Me.SelectAllToolStripMenuItem_Click(Me, e)
    End Sub
    Private Sub ButtnSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtnSearch.Click
        On Error Resume Next
        Me.BS.Position = BS.Find("MSG2", Me.TEXTBOX2.Text)
        Me.RecordCount()
    End Sub
    Private Sub TEXTBOX2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTBOX2.SelectedIndexChanged
        'BS.Position = BS.Find("MSG1", Me.TEXTBOX2.Text)
        Me.RichTextBoxEx1.Focus()
        Me.RecordCount()
    End Sub

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        On Error Resume Next
        If Me.RichTextBoxEx1.Modified Then

            Dim answer As Integer
            answer = MessageBox.Show("«·„” ‰œ «·Õ«·Ì ·„ Ì „ Õ›ŸÂ«° Â·  —Ìœ «·«” „—«— œÊ‰ Õ›Ÿø", "Unsaved Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If answer = Windows.Forms.DialogResult.Yes Then
                RichTextBoxEx1.Clear()
            Else
                Exit Sub
            End If
        Else
            Me.RichTextBoxEx1.Clear()
        End If
        currentFile = ""
        Me.Text = "„” ‰œ ÃœÌœ"
    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        On Error Resume Next
        If Me.RichTextBoxEx1.Modified Then
            Dim answer As Integer
            answer = MessageBox.Show("≈‰ «·ÊÀÌﬁ… «·Õ«·Ì… ·„ Ì „ Õ›ŸÂ° Â·  —Ìœ «·«” „—«— œÊ‰ Õ›Ÿø", "ÊÀÌﬁ… €Ì— „Õ›ÊŸ…", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If answer = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                Me.OpenFile()
            End If
        Else
            Me.OpenFile()
        End If
    End Sub

    Private Sub ButtonItem4_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        On Error Resume Next
        If currentFile = "" Then
            SaveAsToolStripMenuItem_Click(Me, e)
            Exit Sub
        End If
        Dim strExt As String
        strExt = System.IO.Path.GetExtension(currentFile)
        strExt = strExt.ToUpper()

        Select Case strExt
            Case ".RTF"
                Me.RichTextBoxEx1.SaveFile(currentFile)
            Case Else
                ' to save as plain text
                Dim txtWriter As IO.StreamWriter
                txtWriter = New IO.StreamWriter(currentFile)
                txtWriter.Write(RichTextBoxEx1.Text)
                txtWriter.Close()
                txtWriter = Nothing
                Me.RichTextBoxEx1.SelectionStart = 0
                Me.RichTextBoxEx1.SelectionLength = 0
                Me.RichTextBoxEx1.ReadOnly = False
        End Select
        Me.Text = "„Õ—— «·‰’Ê’ " & currentFile.ToString()
    End Sub

    Private Sub ButtonItem7_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        On Error Resume Next
        If Me.RichTextBoxEx1.Modified Then

            Dim answer As Integer
            answer = MessageBox.Show("·„ Ì „ Õ›Ÿ «·„·› Â·  Êœ «·«” „—«—", "·„ Ì „ «·Õ›Ÿ", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)

            If answer = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                Application.Exit()
            End If
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub ButtonItem6_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        On Error Resume Next
        Me.PrintDialog1.Document = Me.PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub ButtonItem28_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        Me.PrintToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ButtonItem27_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        Me.PageSetupDialog1.Document = Me.PrintDocument1
        Me.PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub ButtonMargins_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        On Error Resume Next
        Me.PrintPInternalAuditorDialog1.Document = Me.PrintDocument1
        Me.PrintPInternalAuditorDialog1.ShowDialog()
    End Sub








End Class