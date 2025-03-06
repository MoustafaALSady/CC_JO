

Imports System.Data.SqlClient
Imports System.Threading
<<<<<<< HEAD
Imports DevExpress.XtraGrid.Views.Grid

Public Class FinaBalances2
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim SqlDataAdapter1 As New SqlDataAdapter
=======

Public Class FinaBalances2
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private Delegate Sub checkstatusDel()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    ReadOnly ds As New DataSet
    Dim ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9 As New DataSet
    ReadOnly dt2 As New DataTable()
    ReadOnly Cancelled As Boolean

<<<<<<< HEAD
    Private Sub Finabalances2_HandleCreated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.HandleCreated
        'R.Container = Me
    End Sub
    Private Sub Finabalances2_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
=======
    Private Sub Finabalances2_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        'R.Container = Me
    End Sub
    Private Sub Finabalances2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'R.ResizeControls()
    End Sub
    Private Sub BackWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker1.DoWork
        Try
            Me.CircularProgress1.Value = 0
            Me.CircularProgress1.Visible = True
            Me.CircularProgress1.IsRunning = True
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim str1 As New SqlCommand("", Consum)
            With str1
                .CommandText = "SELECT account_no, account_name , SUMDEBIT, SUMCREDIT, ACC ,Finabalances  FROM Finabalances  WHERE Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CUser='" & CUser & "'"
            End With
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Me.ds.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            SqlDataAdapter1.Fill(Me.ds, "Finabalances")
            Me.BS.DataMember = "Finabalances"
            Consum.Close()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BackWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackWorker1.ProgressChanged
        'Me.PictureBox2.Visible = True
        Me.CircularProgress1.Value = e.ProgressPercentage
    End Sub
    Private Sub BackWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker1.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = ds.Tables("Finabalances")
            Me.DataGridView1.DataSource = Me.ds
            Me.DataGridView1.DataMember = "Finabalances"

            Dim total As Double
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                total += CDbl(r.Cells("Finabalances1").Value)
            Next
            Me.TextTotalDebit.Text = total.ToString("0.000")
            Me.Sponsor()
            Me.Sponsor2()
            Me.Sponsor3()
            Me.Sponsor4()
            Me.Sponsor5()
            Me.Sponsor6()
            Me.Sponsor7()
            Me.Sponsor8()
            Me.Sponsor9()
            Me.GiveNumber()
            Me.GiveNumber1()
            Me.TabPage1.Show()
            Me.TabPage2.Show()
            Me.TabPage3.Show()
            Me.TabPage4.Show()
            Me.TabPage5.Show()
            Me.TabPage6.Show()
            Me.TabPage11.Show()
            Me.TabControl1.Refresh()
            Me.TabPage7.Show()
            Me.TabPage8.Show()
            Me.TabControl2.Refresh()
            Me.TabPage9.Show()
            Me.TabPage10.Show()
            Me.TabControl3.Refresh()
            Call MangUsers()
            If Complete() = True Then
                Me.ButtonFinalEntryFormation.Enabled = True
            Else
                Me.ButtonFinalEntryFormation.Enabled = False
            End If
            Me.PictureBox2.Visible = False
            Me.CircularProgress1.IsRunning = False
            Me.CircularProgress1.Visible = False
            Me.CircularProgress3.IsRunning = False
            Me.CircularProgress3.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error22", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
            Me.Labelstatus.Visible = True
            Me.CircularProgress3.Visible = True
            Me.CircularProgress3.IsRunning = True
            BasicDataTransfer(Me)
            Insert_Actions("1-1-" & FiscalYear_currentDateMustBeInFiscalYear() + 1, "تكوين قيد ختـامـي", Me.Text)
        Catch ex As Exception
            If ex.Message.GetHashCode = -1115812848 Or ex.Message.GetHashCode = 379362862 Then
                e.Cancel = True
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                e.Cancel = True
                TestNet = False
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = -652120241 Or ex.Message.GetHashCode = 2067669773 Then
                Me.DelRow = True
                Me.PictureBox2False()
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
            Else
                e.Cancel = True
                Me.PictureBox2False()
                MessageBox.Show(ex.Message, "ErrorSaveData_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub SaveTab_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles SaveTab.ProgressChanged
        Me.CircularProgress3.Value = e.ProgressPercentage
        'PBar1.Value = e.ProgressPercentage
        'PBar2.Value = (e.ProgressPercentage / (ncount)) * 100
        'Me.PBar2.Invoke(AddressOf Me.PBar2.Value = (e.ProgressPercentage / (ncount)) * 100)
        'Me.PBar2.Invoke(New MethodInvoker(AddressOf PBar2.Value = (e.ProgressPercentage / (ncount)) * 100), New Object() {})
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If

            Application.DoEvents()
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            PBar2.Visible = False
            Me.CircularProgress3.IsRunning = False
            Me.CircularProgress3.Visible = False
            'Me.Labelstatus.Text = "تمت عملية ترحيل الحسابات الافتتاحية بنجاح"
            'If Me.BS.Count < Me.RowCount Then
            '    MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
            '    Exit Sub
            'ElseIf Me.BS.Count > Me.RowCount Then
            '    MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & BS.Count - RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
            '    Exit Sub
            'End If
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.save
=======
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
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
        End If
    End Sub

<<<<<<< HEAD
    Private Sub Finabalances2_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub Finabalances2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.CircularProgress1.Value = 0
        Me.BackWorker1.WorkerSupportsCancellation = True
        Me.BackWorker1.WorkerReportsProgress = True
        Me.BackWorker1.RunWorkerAsync()
    End Sub

<<<<<<< HEAD
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timer1.Tick
=======
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim I As Integer
        Me.PBar2.Value += 1
        Me.PBar2.Visible = True
        Me.PBar1.Value += 1
        Me.PBar1.Increment(+1)
        Me.CircularProgress3.Value = 0
        Me.CircularProgress3.Visible = True
        Me.CircularProgress3.IsRunning = True
        Me.LabelCount.Visible = True
        Me.LabelCount.Visible = True
        'LabelCount.Invoke(Sub() Me.LabelCount.Text = Me.PBar2.Value & " " & "%")
        Me.LabelCount.Text = Me.PBar2.Value & " " & "%"
        If Me.PBar2.Value <= 10 Then
            Dim percent1 As Integer = CInt(CDbl(Me.PBar2.Value - Me.PBar2.Minimum) / CDbl(Me.PBar2.Maximum - Me.PBar2.Minimum) * 100)
            Using gr As Graphics = Me.PBar2.CreateGraphics()
                gr.DrawString(percent1.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar2.Width / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar2.Height / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
            End Using
            Me.PBar1.Value += 1
            Me.Labelstatus.Visible = True
            Me.Labelinformation.Visible = True
            Me.Labelstatus.Text = "بيانات الاعضاء"
            Me.PBar1.Visible = True
            'For Each row As DataGridViewRow In Me.DataGridView5.Rows
            For I = 0 To Me.DataGridView5.Rows.Count - 1
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = I
                Me.PBar1.Value = I
                If PBar1.Value <= 1 Then
                    Me.Labelinformation.Text = "  بداية تشغيل البرنامج ـ الاعضاء ـ ـ  "
                ElseIf PBar1.Value < 25 Then
                    Me.Labelinformation.Text = "  تحميل البرنامج ـ الاعضاء ـ ـ  "
                ElseIf PBar1.Value < 50 Then
                    Me.Labelinformation.Text = "     التحقيق من الملفات ـ الاعضاء ـ ـ"
                ElseIf PBar1.Value < 75 Then
                    Me.Labelinformation.Text = "  الرجاء الانتظار ـ-العملاء-ـ-ـ-ـ  "
                    Me.Labelinformation.Text = ""
                    Me.Labelinformation.Visible = False
                    Me.PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If
                Me.CircularProgress3.Value = I
                '    Dim percent As Integer = CInt((CDbl(Me.PBar1.Value - Me.PBar1.Minimum) / CDbl(PBar1.Maximum - Me.PBar1.Minimum)) * 100)
                '    Using gr As Graphics = Me.PBar1.CreateGraphics()
                '        gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                '    End Using
                'Next
            Next
            '=================================================================
        ElseIf Me.PBar2.Value < 20 Then
            Dim percent1 As Integer = CInt(CDbl(Me.PBar2.Value - Me.PBar2.Minimum) / CDbl(Me.PBar2.Maximum - Me.PBar2.Minimum) * 100)
            Using gr As Graphics = PBar2.CreateGraphics()
                gr.DrawString(percent1.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar2.Width / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar2.Height / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
            End Using
            Me.PBar1.Value += 1
            Me.Labelstatus.Visible = True
            Me.Labelinformation.Visible = True
            Me.Labelstatus.Text = "  بيانات العملاء  "
            Me.PBar1.Visible = True
            'For Each row As DataGridViewRow In Me.DataGridView4.Rows
            For I = 0 To Me.DataGridView4.Rows.Count - 1
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = I
                Me.PBar1.Value = I
                If Me.PBar1.Value <= 1 Then
                    Me.Labelinformation.Text = "  بداية تشغيل البرنامج ـ العملاء -ـ-ـ-ـ  "
                ElseIf Me.PBar1.Value < 25 Then
                    Me.Labelinformation.Text = "  تحميل البرنامج ـ العملاء -ـ-ـ-ـ  "
                ElseIf Me.PBar1.Value < 50 Then
                    Me.Labelinformation.Text = "  التحقيق من الملفات ـ العملاء -ـ-ـ-ـ  "
                ElseIf Me.PBar1.Value < 75 Then
                    Me.Labelinformation.Text = "  الرجاء الانتظار ـ-الموردين-ـ-ـ-ـ    "
                    Me.Labelinformation.Text = ""
                    Me.Labelstatus.Visible = False
                    Me.Labelinformation.Visible = False
                    Me.PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If
                'Dim percent As Integer = CInt((CDbl(Me.PBar1.Value - Me.PBar1.Minimum) / CDbl(Me.PBar1.Maximum - Me.PBar1.Minimum)) * 100)
                '    Using gr As Graphics = PBar1.CreateGraphics()
                '        gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                '    End Using
                '    'Sponsor3()
                'Next
                Me.CircularProgress3.Value = I
            Next
            '=================================================================
        ElseIf Me.PBar2.Value <= 30 Then
            Dim percent1 As Integer = CInt(CDbl(Me.PBar2.Value - Me.PBar2.Minimum) / CDbl(Me.PBar2.Maximum - Me.PBar2.Minimum) * 100)
            Using gr As Graphics = Me.PBar2.CreateGraphics()
                gr.DrawString(percent1.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar2.Width / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar2.Height / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
            End Using
            Me.PBar1.Value += 1
            Me.Labelstatus.Visible = True
            Me.Labelinformation.Visible = True
            Me.Labelstatus.Text = "بيانات الموردين"
            Me.PBar1.Visible = True
            'For Each row As DataGridViewRow In Me.DataGridView7.Rows
            For I = 0 To Me.DataGridView7.Rows.Count - 1
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = I
                Me.PBar1.Value = I
                If Me.PBar1.Value <= 1 Then
                    Me.Labelinformation.Text = "  بداية تشغيل البرنامج ـ الموردين ـ ـ  "
                ElseIf PBar1.Value < 25 Then
                    Me.Labelinformation.Text = "  تحميل البرنامج ـ الموردين ـ ـ  "
                ElseIf PBar1.Value < 50 Then
                    Me.Labelinformation.Text = "  التحقيق من الملفات ـ الموردين ـ ـ  "
                ElseIf PBar1.Value < 75 Then
                    Me.Labelinformation.Text = "  الرجاء الانتظار ـ-ـ-الموظفين-ـ-ـ  "
                    Me.Labelinformation.Text = ""
                    Me.Labelstatus.Visible = False
                    Me.Labelinformation.Visible = False
                    Me.PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If
                Me.CircularProgress3.Value = I
                '    Dim percent As Integer = CInt((CDbl(Me.PBar1.Value - Me.PBar1.Minimum) / CDbl(Me.PBar1.Maximum - Me.PBar1.Minimum)) * 100)
                '    Using gr As Graphics = Me.PBar1.CreateGraphics()
                '        gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                '    End Using
                '    'Sponsor4()
                'Next
            Next
            '=================================================================
        ElseIf Me.PBar2.Value <= 40 Then
            Dim percent1 As Integer = CInt(CDbl(Me.PBar2.Value - Me.PBar2.Minimum) / CDbl(Me.PBar2.Maximum - Me.PBar2.Minimum) * 100)
            Using gr As Graphics = Me.PBar2.CreateGraphics()
                gr.DrawString(percent1.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar2.Width / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar2.Height / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
            End Using
            Me.PBar1.Value += 1
            Me.Labelstatus.Visible = True
            Me.Labelinformation.Visible = True
            Me.Labelstatus.Text = "بيانات الموظفين"
            Me.PBar1.Visible = True
            'For Each row As DataGridViewRow In Me.DataGridView6.Rows
            For I = 0 To Me.DataGridView6.Rows.Count - 1
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = I
                Me.PBar1.Value = I
                If PBar1.Value <= 1 Then
                    Me.Labelinformation.Text = "  بداية تشغيل البرنامج ـ الموظفين ـ ـ  "
                ElseIf PBar1.Value < 25 Then
                    Me.Labelinformation.Text = "    تحميل البرنامج ـ الموظفين ـ ـ  "
                ElseIf PBar1.Value < 50 Then
                    Me.Labelinformation.Text = "  التحقيق من الملفات ـ الموظفين ـ ـ  "
                ElseIf PBar1.Value < 75 Then
                    Me.Labelinformation.Text = "  الرجاء الانتظار ـ-الذمم المدينة-ـ-ـ-ـ  "
                    Me.Labelinformation.Text = ""
                    Me.Labelstatus.Visible = False
                    Me.Labelinformation.Visible = False
                    Me.PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If
                Me.CircularProgress3.Value = I
                '    Dim percent As Integer = CInt((CDbl(Me.PBar1.Value - Me.PBar1.Minimum) / CDbl(Me.PBar1.Maximum - Me.PBar1.Minimum)) * 100)
                '    Using gr As Graphics = Me.PBar1.CreateGraphics()
                '        gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                '    End Using
                '    'Sponsor5()
                'Next
            Next
            '=================================================================
        ElseIf Me.PBar2.Value <= 50 Then
            Dim percent1 As Integer = CInt(CDbl(Me.PBar2.Value - Me.PBar2.Minimum) / CDbl(Me.PBar2.Maximum - Me.PBar2.Minimum) * 100)
            Using gr As Graphics = Me.PBar2.CreateGraphics()
                gr.DrawString(percent1.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar2.Width / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar2.Height / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
            End Using
            Me.PBar1.Value += 1
            Me.PBar1.Visible = True
            Me.Labelstatus.Visible = True
            Me.Labelinformation.Visible = True
            Me.Labelstatus.Text = "  بيانات الذمم المدينة    "
            'For Each row As DataGridViewRow In Me.DataGridView11.Rows
            For I = 0 To Me.DataGridView11.Rows.Count - 1
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = I
                Me.PBar1.Value = I
                If PBar1.Value <= 1 Then
                    Me.Labelinformation.Text = "    بداية تشغيل البرنامج ـ الذمم المدينة ـ ـ"
                ElseIf PBar1.Value < 25 Then
                    Me.Labelinformation.Text = "  تحميل البرنامج ـ الذمم المدينة ـ ـ  "
                ElseIf PBar1.Value < 50 Then
                    Me.Labelinformation.Text = "  التحقيق من الملفات ـ الذمم المدينة ـ ـ  "
                ElseIf PBar1.Value < 75 Then
                    Me.Labelinformation.Text = "  الرجاء الانتظار ـ-الاصناف-ـ-ـ-ـ   "
                    Me.Labelinformation.Text = "-ـ-ـ-ـ"
                    Me.Labelstatus.Visible = False
                    Me.Labelinformation.Visible = False
                    Me.PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If
                Me.CircularProgress3.Value = I
                '    Dim percent As Integer = CInt((CDbl(Me.PBar1.Value - Me.PBar1.Minimum) / CDbl(Me.PBar1.Maximum - Me.PBar1.Minimum)) * 100)
                '    Using gr As Graphics = Me.PBar1.CreateGraphics()
                '        gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                '    End Using
                '    'Sponsor6()
                'Next
            Next
            '=================================================================
        ElseIf Me.PBar2.Value <= 60 Then
            Dim percent1 As Integer = CInt(CDbl(Me.PBar2.Value - Me.PBar2.Minimum) / CDbl(Me.PBar2.Maximum - Me.PBar2.Minimum) * 100)
            Using gr As Graphics = Me.PBar2.CreateGraphics()
                gr.DrawString(percent1.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar2.Width / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar2.Height / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
            End Using
            Me.PBar1.Value += 1
            Me.PBar1.Visible = True
            Me.Labelstatus.Visible = True
            Me.Labelinformation.Visible = True
            Me.Labelstatus.Text = "  بيانات الاصناف  "
            'For Each row As DataGridViewRow In Me.DataGridView10.Rows
            For I = 0 To Me.DataGridView10.Rows.Count - 1
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = I
                Me.PBar1.Value = I
                If PBar1.Value <= 1 Then
                    Me.Labelinformation.Text = "  بداية تشغيل البرنامج ـ الاصناف ـ ـ  "
                ElseIf PBar1.Value < 25 Then
                    Me.Labelinformation.Text = "  تحميل البرنامج ـ الاصناف ـ ـ  "
                ElseIf PBar1.Value < 50 Then
                    Me.Labelinformation.Text = "    التحقيق من الملفات ـ الاصناف ـ ـ  "
                ElseIf PBar1.Value < 75 Then
                    Me.Labelinformation.Text = "    الرجاء الانتظار ـ-شيكات صادرة-ـ-ـ-ـ  "
                    Me.Labelstatus.Visible = False
                    Me.Labelinformation.Visible = False
                    Me.PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If
                Me.CircularProgress3.Value = I
                '    Dim percent As Integer = CInt((CDbl(Me.PBar1.Value - Me.PBar1.Minimum) / CDbl(Me.PBar1.Maximum - PBar1.Minimum)) * 100)
                '    Using gr As Graphics = Me.PBar1.CreateGraphics()
                '        gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                '    End Using
                '    'Sponsor7()
                'Next
            Next
            '=================================================================
        ElseIf PBar2.Value <= 70 Then
            Dim percent1 As Integer = CInt(CDbl(Me.PBar2.Value - Me.PBar2.Minimum) / CDbl(Me.PBar2.Maximum - Me.PBar2.Minimum) * 100)
            Using gr As Graphics = Me.PBar2.CreateGraphics()
                gr.DrawString(percent1.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar2.Width / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar2.Height / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
            End Using
            Me.PBar1.Value += 1
            Me.Labelstatus.Visible = True
            Me.Labelinformation.Visible = True
            Me.Labelstatus.Text = "  بيانات شيكات صادرة   "
            Me.PBar1.Visible = True

            'For Each row As DataGridViewRow In Me.DataGridView8.Rows
            For I = 0 To Me.DataGridView8.Rows.Count - 1
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = Me.DataGridView8.Rows.Count - 1
                Me.PBar1.Value = I
                If Me.PBar1.Value <= 1 Then
                    Me.Labelinformation.Text = "  بداية تشغيل البرنامج ـ شيكات صادرة ـ ـ  "
                ElseIf PBar1.Value < 25 Then
                    Me.Labelinformation.Text = "  تحميل البرنامج ـ شيكات صادرة ـ ـ  "
                ElseIf PBar1.Value < 50 Then
                    Me.Labelinformation.Text = "  التحقيق من الملفات ـ شيكات صادرة ـ ـ  "
                ElseIf PBar1.Value < 75 Then
                    Me.Labelinformation.Text = "    الرجاء الانتظار ـ-شيكات واردة-ـ-ـ-ـ  "
                    Me.Labelstatus.Visible = False
                    Me.Labelinformation.Visible = False
                    Me.PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If
                Me.CircularProgress3.Value = I
                '    Dim percent As Integer = CInt((CDbl(Me.PBar1.Value - Me.PBar1.Minimum) / CDbl(Me.PBar1.Maximum - Me.PBar1.Minimum)) * 100)
                '    Using gr As Graphics = Me.PBar1.CreateGraphics()
                '        gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                '    End Using
                '    'Sponsor8()
                'Next
            Next
            '================================================================
        ElseIf Me.PBar2.Value <= 80 Then
            Dim percent1 As Integer = CInt(CDbl(Me.PBar2.Value - Me.PBar2.Minimum) / CDbl(Me.PBar2.Maximum - Me.PBar2.Minimum) * 100)
            Using gr As Graphics = Me.PBar2.CreateGraphics()
                gr.DrawString(percent1.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar2.Width / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), PBar2.Height / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
            End Using
            Me.PBar1.Value += 1
            Me.PBar1.Visible = True
            Me.Labelinformation.Visible = True
            Me.Labelstatus.Visible = True
            Me.Labelstatus.Text = "  بيانات شيكات واردة   "
            'For Each row As DataGridViewRow In Me.DataGridView9.Rows
            For I = 0 To Me.DataGridView9.Rows.Count - 1
                Me.DataGridView9.Focus()
                Me.BS.Position = I
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = I
                Me.PBar1.Value = I
                If Me.PBar1.Value <= 1 Then
                    Me.Labelinformation.Text = "  بداية تشغيل البرنامج ـ شيكات واردة ـ ـ  "
                ElseIf PBar1.Value < 25 Then
                    Me.Labelinformation.Text = "  تحميل البرنامج ـ شيكات واردة  ـ ـ   "
                ElseIf PBar1.Value < 50 Then
                    Me.Labelinformation.Text = "  التحقيق من الملفات ـ شيكات واردة  ـ ـ "
                ElseIf PBar1.Value < 75 Then
                    Me.Labelinformation.Text = "  الرجاء الانتظار ـ-الحسابات -ـ-ـ-ـ  "
                    Me.Labelstatus.Visible = False
                    Me.Labelinformation.Visible = False
                    PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If
                Me.CircularProgress3.Value = I
                '    Dim percent As Integer = CInt((CDbl(Me.PBar1.Value - Me.PBar1.Minimum) / CDbl(Me.PBar1.Maximum - Me.PBar1.Minimum)) * 100)
                '    Using gr As Graphics = Me.PBar1.CreateGraphics()
                '        gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                '    End Using
                '    'Sponsor7()
                'Next
            Next
            '=================================================================
        ElseIf Me.PBar2.Value <= 90 Then
            Dim percent1 As Integer = CInt(CDbl(Me.PBar2.Value - Me.PBar2.Minimum) / CDbl(Me.PBar2.Maximum - Me.PBar2.Minimum) * 100)
            Using gr As Graphics = Me.PBar2.CreateGraphics()
                gr.DrawString(percent1.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar2.Width / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar2.Height / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
            End Using
            Me.PBar1.Value += 1
            Me.PBar1.Visible = True
            Me.Labelstatus.Visible = True
            Me.Labelinformation.Visible = True
            Me.Labelinformation.Text = "  تشغيل البرنامج ـ الحسابات ـ ـ  "
            For I = 0 To dt2.Rows.Count - 1
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = I
                Me.PBar1.Value = I
                If Me.PBar1.Value <= 1 Then
                    Me.Labelstatus.Text = "  بداية تشغيل البرنامج ـ الحسابات ـ ـ  "
                ElseIf Me.PBar1.Value < 25 Then
                    Me.Labelstatus.Text = "  تحميل البرنامج ـ الحسابات ـ ـ   "
                ElseIf Me.PBar1.Value < 50 Then
                    Me.Labelstatus.Text = "    التحقيق من الملفات ـ الحسابات ـ ـ  "
                ElseIf Me.PBar1.Value < 75 Then
                    Me.Labelstatus.Text = "    الرجاء الانتظار ـ-1-0-ـ-ـ-ـ  "
                    Me.PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If
                Me.CircularProgress3.Value = I
                'Dim percent As Integer = CInt((CDbl(PBar1.Value - Me.PBar1.Minimum) / CDbl(Me.PBar1.Maximum - Me.PBar1.Minimum)) * 100)
                'Using gr As Graphics = Me.PBar1.CreateGraphics()
                '    gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                'End Using
                If Consum.State = ConnectionState.Open Then Consum.Close()
                'Sponsor8()
            Next
        ElseIf Me.PBar2.Value <= 100 Then
            'Me.PictureBox2.Visible = True
            Me.Labelstatus.Text = "   الرجاء الانتظار حتى الاكتمال ـ-0-ـ-ـ-ـ   "
            Me.PBar2.Visible = False
            Me.PBar1.Visible = False
            'Me.Cursor = Cursors.Default

        End If
        '=================================================================
        If Me.PBar2.Value = 100 Then
            Dim percent1 As Integer = CInt(CDbl(Me.PBar2.Value - Me.PBar2.Minimum) / CDbl(Me.PBar2.Maximum - Me.PBar2.Minimum) * 100)
            Using gr As Graphics = PBar2.CreateGraphics()
                gr.DrawString(percent1.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar2.Width / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar2.Height / 2 - (gr.MeasureString(percent1.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
            End Using
            Me.Labelinformation.Text = "  الرجاء الانتظار حتى الاكتمال ـ-ـ-ـ-ـ-ـ  "

            Me.Timer1.Dispose()
            Me.CircularProgress3.IsRunning = False
            Me.CircularProgress3.Visible = False
            Me.ButtonFinalEntryFormation.Enabled = True
            Me.Labelstatus.Visible = False
            Me.Labelinformation.Visible = False
            Me.LabelCount.Visible = False
            Dim cur As New Form
            cur = New FinaBalances1
            cur.Show()
            If Complete() = True Then
                Me.ButtonFinalEntryFormation.Enabled = True
            Else
                Me.ButtonFinalEntryFormation.Enabled = False
            End If
        End If

    End Sub

    Private Sub BackWorker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker3.DoWork
        Try
            Me.CircularProgress2.Visible = True
            Me.CircularProgress2.IsRunning = True
            Me.TabPage3.Show()
<<<<<<< HEAD
            Dim Adp As SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
=======
            Dim Adp As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim str2 As New SqlCommand("", Consum)
            With str2
                .CommandText = "SELECT  TBNK1, TBNK6, TBNK19, TBNK119, TBNK20, TBNK21, OpeningBalance, OpeningBalance1, OpeningBalance2, CUser FROM ALLShares  WHERE Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CUser='" & CUser & "'"
                '.CommandText = "SELECT  * FROM ALLShares  WHERE Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CUser='" & CUser & "'"
            End With
            Me.ds3 = New DataSet
<<<<<<< HEAD
            Adp = New SqlDataAdapter(str2)
=======
            Adp = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Me.ds3.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Adp.Fill(Me.ds3, "ALLShares")
            Adp.Dispose()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorALLSharesLoad", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub BackWorker3_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker3.RunWorkerCompleted
        If Me.ds3.Tables(0).Rows.Count > 0 Then
            Me.DataGridView5.DataSource = Me.ds3.Tables("ALLShares")
        End If
        'Me.DataGridView5.Columns("TBNK3").Visible = False
        'Me.DataGridView5.Columns("TBNK4").Visible = False
        'Me.DataGridView5.Columns("TBNK5").Visible = False
        'Me.DataGridView5.Columns("TBNK7").Visible = False
        'Me.DataGridView5.Columns("TBNK8").Visible = False
        'Me.DataGridView5.Columns("TBNK15").Visible = False
        'Me.DataGridView5.Columns("TBNK16").Visible = False
        'Me.DataGridView5.Columns("CUser1").Visible = False
        Me.CircularProgress2.IsRunning = False
        Me.CircularProgress2.Visible = False
    End Sub

    Private Sub Sponsor()
        On Error Resume Next
<<<<<<< HEAD
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim str2 As New SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT  account_no1,  account_name1, SUMDEBIT1, SUMCREDIT1, ACC1,Debits FROM Debits  WHERE Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CUser='" & CUser & "' and account_no1<>'23007'"
        End With
<<<<<<< HEAD
        Adp = New SqlDataAdapter(str2)
=======
        Adp = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ds1 = New DataSet
        Me.ds1.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp.Fill(Me.ds1, "Debits")
        If Me.ds1.Tables(0).Rows.Count > 0 Then
            Me.DataGridView2.DataSource = Me.ds1.Tables(0)
        End If
        Adp.Dispose()
        Consum.Close()
        Dim total As Double
        Me.DataGridView2.DataSource = Me.ds1.Tables("Debits")
        For Each r As DataGridViewRow In Me.DataGridView2.Rows
            total += CDbl(r.Cells("Debits").Value)
        Next
        Me.TextTotalCred.Text = total.ToString("0.000")
    End Sub
    Private Sub Sponsor2()
        On Error Resume Next
        Me.TabPage2.Show()
<<<<<<< HEAD
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim str2 As New SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT * FROM SumCABLES  WHERE Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CUser='" & CUser & "'and CAB7>'" & 0 & "'"
        End With
        Me.ds2 = New DataSet
<<<<<<< HEAD
        Adp = New SqlDataAdapter(str2)
=======
        Adp = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ds2.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp.Fill(Me.ds2, "SumCABLES")
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.DataGridView4.DataSource = Me.ds2.Tables("SumCABLES")
        End If
        Adp.Dispose()
        Consum.Close()

        Me.DataGridView4.Columns("CAB3").Visible = False
        Me.DataGridView4.Columns("CAB13").Visible = False
        Me.DataGridView4.Columns("CAB17").Visible = False
        Me.DataGridView4.Columns("CAB18").Visible = False
        Me.DataGridView4.Columns("CAB22").Visible = False
        Me.DataGridView4.Columns("CAB23").Visible = False
        Me.DataGridView4.Columns("CAB26").Visible = False
        Me.DataGridView4.Columns("CAB27").Visible = False
        Me.DataGridView4.Columns("CAB28").Visible = False
        Me.DataGridView4.Columns("CUser").Visible = False
    End Sub
    Private Sub Sponsor3()
        On Error Resume Next
        Me.BackWorker3.WorkerSupportsCancellation = True
        Me.BackWorker3.WorkerReportsProgress = True
        Me.BackWorker3.RunWorkerAsync()

    End Sub
    Private Sub Sponsor4()
        On Error Resume Next
        Me.TabPage5.Show()
<<<<<<< HEAD
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim str2 As New SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT * FROM SumEMPSOLF  WHERE Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CUser='" & CUser & "'and Sumcsh>'" & 0 & "'"
        End With
        Me.ds4 = New DataSet
<<<<<<< HEAD
        Adp = New SqlDataAdapter(str2)
=======
        Adp = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ds4.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp.Fill(Me.ds4, "SumEMPSOLF")
        If Me.ds4.Tables(0).Rows.Count > 0 Then
            Me.DataGridView6.DataSource = Me.ds4.Tables("SumEMPSOLF")
        End If
        Adp.Dispose()
        Consum.Close()
        Me.DataGridView6.Columns("CSH2").Visible = False
        Me.DataGridView6.Columns("CSH9").Visible = False
        Me.DataGridView6.Columns("CUser").Visible = False
    End Sub
    Private Sub Sponsor5()
        On Error Resume Next
        Me.TabPage4.Show()
<<<<<<< HEAD
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim str2 As New SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT * FROM SumSuppliers  WHERE Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CUser='" & CUser & "'and Sumcsh>'" & 0 & "'"
        End With
        Me.ds5 = New DataSet
<<<<<<< HEAD
        Adp = New SqlDataAdapter(str2)
=======
        Adp = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ds5.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp.Fill(ds1, "SumSuppliers")
        Adp.Dispose()
        If Me.ds5.Tables(0).Rows.Count > 0 Then
            Me.DataGridView7.DataSource = Me.ds5.Tables("SumSuppliers")
        End If
        Adp.Dispose()
        Consum.Close()
        Me.DataGridView7.DataSource = Me.ds5.Tables("SumSuppliers")
        Me.DataGridView7.Columns("CAB7").Visible = False
        Me.DataGridView7.Columns("CAB3").Visible = False
        Me.DataGridView7.Columns("CAB20").Visible = False
        Me.DataGridView7.Columns("CAB21").Visible = False
        Me.DataGridView7.Columns("CAB22").Visible = False
        Me.DataGridView7.Columns("CAB23").Visible = False
        Me.DataGridView7.Columns("CUser").Visible = False
        Consum.Close()
    End Sub
    Private Sub Sponsor6()
        On Error Resume Next
        Me.TabPage7.Show()
<<<<<<< HEAD
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim str2 As New SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT IDCH, CH1, CH3, CH4, CH5, CH6, CH12 FROM Checks1   WHERE CH17 ='" & False & "' and CUser='" & CUser & "'"
        End With
        Me.ds6 = New DataSet
<<<<<<< HEAD
        Adp = New SqlDataAdapter(str2)
=======
        Adp = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ds6.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp.Fill(Me.ds6, "Checks1")
        Adp.Dispose()
        If Me.ds6.Tables(0).Rows.Count > 0 Then
            Me.DataGridView8.DataSource = Me.ds6.Tables("Checks1")
        End If
        Adp.Dispose()
        Consum.Close()
        Me.DataGridView8.DataSource = Me.ds6.Tables("Checks1")
        Me.DataGridView8.Columns("IDCH").Visible = False
    End Sub
    Private Sub Sponsor7()
        On Error Resume Next
        Me.TabPage8.Show()
<<<<<<< HEAD
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim str2 As New SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT IDCH, CH1, CH3, CH5, CH6, CH12 FROM Checks2  WHERE CH17 ='" & False & "' and CUser='" & CUser & "'"
        End With
        Me.ds7 = New DataSet
<<<<<<< HEAD
        Adp = New SqlDataAdapter(str2)
=======
        Adp = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ds7.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp.Fill(Me.ds7, "Checks2")
        Adp.Dispose()
        If Me.ds7.Tables(0).Rows.Count > 0 Then
            Me.DataGridView9.DataSource = Me.ds7.Tables("Checks2")
        End If
        Adp.Dispose()
        Consum.Close()
        Me.DataGridView9.DataSource = Me.ds7.Tables("Checks2")
        Me.DataGridView9.Columns("IDCH").Visible = False
    End Sub
    Private Sub Sponsor8()
        On Error Resume Next
        Me.TabPage6.Show()
<<<<<<< HEAD
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim str2 As New SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT * FROM Stockwarehouse  WHERE Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CUser='" & CUser & "'"
        End With
        Me.ds8 = New DataSet
<<<<<<< HEAD
        Adp = New SqlDataAdapter(str2)
=======
        Adp = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ds8.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp.Fill(Me.ds8, "Stockwarehouse")
        Adp.Dispose()
        If Me.ds8.Tables(0).Rows.Count > 0 Then
            Me.DataGridView10.DataSource = Me.ds8.Tables(0)
        End If
        Adp.Dispose()
        Consum.Close()
        Me.DataGridView10.DataSource = Me.ds8.Tables(0)

        'Dim total As Double
        'For Each r As DataGridViewRow In DataGridView10.Rows
        '    total += CDbl(r.Cells("STK15").Value * r.Cells("Balance1").Value)
        'Next
        'Me.DataGridView10.CurrentRow.Cells("Column38").Value = Val(Me.DataGridView10.CurrentRow.Cells("STK15").Value * Me.DataGridView10.CurrentRow.Cells("LeftQty").Value)

        'If Me.DataGridView10.CurrentCell.ColumnIndex = "Column38" Or Me.DataGridView10.CurrentCell.ColumnIndex = "STK15" Or Me.DataGridView10.CurrentCell.ColumnIndex = "LeftQty" Then
        '    Me.DataGridView10.CurrentRow.Cells(5).Value = Val(Me.DataGridView10.CurrentRow.Cells("STK15").Value * Me.DataGridView10.CurrentRow.Cells("LeftQty").Value)
        'End If
        Me.DataGridView10.Columns("STK1").Visible = False
        Me.DataGridView10.Columns("STK9").Visible = False
        Me.DataGridView10.Columns("Inside").Visible = False
        Me.DataGridView10.Columns("Outside").Visible = False
        Me.DataGridView10.Columns("Balance").Visible = False
        Me.DataGridView10.Columns("STK14").Visible = False
        Me.DataGridView10.Columns("STK4").Visible = False
        Me.DataGridView10.Columns("IT_DATEP").Visible = False
        Me.DataGridView10.Columns("IT_DATEEX").Visible = False
        Me.DataGridView10.Columns("CUser").Visible = False
        Me.DataGridView10.Columns("COUser").Visible = False

    End Sub
    Private Sub Sponsor9()
        On Error Resume Next
        TabControl1.Select()
        Me.TabPage11.Show()
<<<<<<< HEAD
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim str2 As New SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT  Lo,Lo4,Lo5,Lo2,SUMcab5,SUMcab4,CAB7,OpeningBalance1 FROM CustomersCABLES2  WHERE Year(Lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CUser='" & CUser & "'"
        End With
        Me.ds9 = New DataSet
<<<<<<< HEAD
        Adp = New SqlDataAdapter(str2)
=======
        Adp = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ds9.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp.Fill(Me.ds9, "CustomersCABLES2")
        Adp.Dispose()
        If Me.ds9.Tables(0).Rows.Count > 0 Then
            Me.DataGridView11.DataSource = Me.ds9.Tables("CustomersCABLES2")

        End If
        'Mid(, 3, 2)
        Adp.Dispose()
        Consum.Close()
        Me.DataGridView11.DataSource = Me.ds9.Tables("CustomersCABLES2")
        Me.DataGridView11.Columns("lo").Visible = False
        Me.DataGridView11.Columns("lo3").Visible = False
        Me.DataGridView11.Columns("lo6").Visible = False
        Me.DataGridView11.Columns("lo7").Visible = False
        Me.DataGridView11.Columns("lo8").Visible = False
        Me.DataGridView11.Columns("lo9").Visible = False
        Me.DataGridView11.Columns("lo10").Visible = False
        Me.DataGridView11.Columns("lo11").Visible = False
        Me.DataGridView11.Columns("lo12").Visible = False
        Me.DataGridView11.Columns("lo13").Visible = False
        Me.DataGridView11.Columns("lo15").Visible = False
        Me.DataGridView11.Columns("lo19").Visible = False
        Me.DataGridView11.Columns("OpeningBalance").Visible = False
        Me.DataGridView11.Columns("CUser").Visible = False
    End Sub
    Private Sub Sponsor10()
        On Error Resume Next
        'Me.TabPage6.Show()
        'Dim Adp As SqlClient.SqlDataAdapter
        'Dim Consum As New SqlClient.SqlConnection(constring)
        'Dim str2 As New SqlCommand("", Consum)
        'With str2
        '    .CommandText = "SELECT MOVD1 From Previouspost Where yearearlier= '" & FiscalYear_currentDateMustBeInFiscalYear() - 1 & "' And CUser= '" & CUser & "'"
        'End With
        'Dim ds1 As New DataSet
        'Adp = New SqlClient.SqlDataAdapter(str2)
        'ds1.Clear()
        'If Consum.State = ConnectionState.Open Then Consum.Close()
        'Consum.Open()
        'Adp.Fill(ds1, "Previouspost")
        'Adp.Dispose()
        'If ds1.Tables(0).Rows.Count > 0 Then
        '    Me.PSpost = True
        'End If

        'Dim Adp1 As SqlClient.SqlDataAdapter
        'Dim str3 As New SqlCommand("", Consum)
        'Dim ds2 As New DataSet
        'For i As Integer = 0 To Me.DataGridView1.RowCount - 1 Or Me.DataGridView2.RowCount - 1
        '    With str3
        '        .CommandText = "SELECT MOVD1 From Previouspost Where yearearlier= '" & FiscalYear_currentDateMustBeInFiscalYear() - 1 & "' And CUser= '" & CUser & "' And MOVD4= '" & Me.DataGridView1.Rows(i).Cells("account_no").Value & "'or MOVD4= '" & Me.DataGridView2.Rows(i).Cells("account_no1").Value & "'"
        '    End With
        'Next


        'Adp1 = New SqlClient.SqlDataAdapter(str3)
        'ds2.Clear()
        'If Consum.State = ConnectionState.Open Then Consum.Close()
        'Consum.Open()
        'Adp1.Fill(ds2, "Previouspost")

        'If ds2.Tables(0).Rows.Count > 0 Then
        '    Me.PSpost1 = True
        'Else
        '    Me.PSpost1 = False
        'End If
        'Dim Adp2 As SqlClient.SqlDataAdapter
        'Dim str4 As New SqlCommand("", Consum)
        'Dim ds3 As New DataSet
        'For IX As Integer = 0 To Me.DataGridView2.RowCount - 1
        '    With str4
        '        .CommandText = "SELECT MOVD1 From Previouspost Where yearearlier= '" & FiscalYear_currentDateMustBeInFiscalYear() - 1 & "' And CUser= '" & CUser & "' And MOVD4= '" & Me.DataGridView2.Rows(IX).Cells("account_no1").Value & "'"
        '    End With
        'Next


        'Adp2 = New SqlClient.SqlDataAdapter(str4)
        'ds3.Clear()
        'If Consum.State = ConnectionState.Open Then Consum.Close()
        'Consum.Open()
        'Adp2.Fill(ds3, "Previouspost")

        'If ds3.Tables(0).Rows.Count > 0 Then
        '    Me.PSpost2 = True
        'End If


        'Adp.Dispose()
        'Adp1.Dispose()
        'Adp2.Dispose()
        'Consum.Close()




    End Sub

<<<<<<< HEAD
    Private Sub DataGridView10_CurrentCellChanged(ByVal sender As Object, ByVal e As EventArgs)
=======
    Private Sub DataGridView10_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.TextItemBalance.Text = 0
        Me.TextTotalCred.Text = 0
        Me.TextNetItems.Text = 0
        For Each r As DataGridViewRow In DataGridView10.Rows
            Me.DataGridView10.CurrentRow.Cells(5).Value = Val(Me.DataGridView10.CurrentRow.Cells(2).Value * Me.DataGridView10.CurrentRow.Cells(4).Value)
        Next
    End Sub

    Sub GiveNumber()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows.Count > 1 Then
                DataGridView1.Rows(i).HeaderCell.Value = i.ToString
            End If
        Next
    End Sub

    Sub GiveNumber1()
        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            If DataGridView2.Rows.Count > 1 Then
                DataGridView2.Rows(i).HeaderCell.Value = i.ToString
            End If
        Next
    End Sub

<<<<<<< HEAD
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button2.Click
=======
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة الارصدة من البرنامج", 16, "تنبيه")
            Exit Sub
        End If

        Me.ButtonFinalEntryFormation.Enabled = False
        Me.Timer1.Start()
        'Me.BackWorker2.WorkerSupportsCancellation = True
        'Me.BackWorker2.WorkerReportsProgress = True
        'Me.BackWorker2.RunWorkerAsync()
    End Sub

<<<<<<< HEAD
    Private Sub ButtonFinalEntryFormation_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonFinalEntryFormation.Click
=======
    Private Sub ButtonFinalEntryFormation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFinalEntryFormation.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        LoadFiscalYear()
        If Complete() = True Then
            LockUpdate = True
        Else
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
        End If


        Dim f As New FinaBalances1
        f.Show()
<<<<<<< HEAD
        Dim currentRowIndex As Integer = f.GridView1.FocusedRowHandle
        Dim value As Object = f.GridView1.GetRowCellValue(currentRowIndex, f.GridView1.Columns("ID"))
        'For Each r As DataGridViewRow In f.DataGridView1.Rows
        For i As Integer = 0 To f.GridView1.DataRowCount - 1
            If value <> "" Then
                If f.GridView1.RowCount > 0 Then
                    MsgBox("لايمكن اعتماد الموازنة الحالية يجب مراجعة و تدقيق جميع السجلات ... ", 16, "تنبيه")
=======
        For Each r As DataGridViewRow In f.DataGridView1.Rows
            If r.Cells("IDNumber").Value <> "" Then
                If f.DataGridView1.RowCount > 0 Then
                    MsgBox("لايمكن ترحيل الحسابات الحالية يجب التخلص من الخطاء ... ", 16, "تنبيه")
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    Exit Sub
                Else
                    f.Close()
                End If
<<<<<<< HEAD
            ElseIf value = "" Then
=======
            ElseIf r.Cells("IDNumber").Value = "" Then
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                '
            End If
        Next
        f.Close()
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim strsql1 As New SqlCommand("SELECT DISTINCT MOVD1 FROM Previouspost WHERE yearearlier = '" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim ds1 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql1)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql1 As New SqlClient.SqlCommand("SELECT DISTINCT MOVD1 FROM Previouspost WHERE yearearlier = '" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim ds1 As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds1.Clear()
        Adp1.Fill(ds1, "Previouspost")
        If ds1.Tables(0).Rows.Count > 0 Then
            MsgBox("لايمكن ترحيل الحسابات الحالية لأنه تم ترحيلة ... ", 16, "تنبيه")
            Exit Sub
        End If
        Try
            Me.Labelstatus.Visible = True
<<<<<<< HEAD
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorFinalEntryFormation", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

<<<<<<< HEAD
=======
    Private Function MAXLoansA() As Object
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)

        Dim Year As String
        Dim NO As Integer = 0
        Dim NO1 As Integer = 0
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear() + 1), 3, 2)
        NO1 = CType(Year, Integer) & String.Concat(New String() {CUser})
        Dim cusera As Double = CDbl(CUser)
        Select Case cusera
            Case 1 To 9
                NO = "000"
            Case 10 To 99
                NO = "00"
            Case 100 To 999
                NO = "0"
            Case Else
                NO = "0000"
        End Select
        NO1 = CType(Year, Integer) & String.Concat(New String() {NO}) & CType(CUser, Integer)


        Dim cmd2 As New SqlClient.SqlCommand("SELECT MAX(Loans.LO) FROM Loans WHERE CUser = '" & CUser & " 'and Year(LO2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt2 As Object = cmd2.ExecuteScalar()
        Dim noD As Object = Strings.Mid(cmd2.ExecuteScalar(), 7)
        If IsDBNull(resualt2) Then
            SEARCHDATA.MAXIDLoans = CType(NO1, Integer) & 1
        Else
            SEARCHDATA.MAXIDLoans = String.Concat(New String() {NO1}) & CType(noD, Integer) + 1
        End If
        'If IsDBNull(resualt) Then
        '    MAXIDLoans = CType(NO1, Integer) & 1
        'Else
        '    MAXIDLoans = String.Concat(New String() {NO1}) & CType(noD, Integer) + 1
        'End If




        Consum.Close()

    End Function

>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub AddValue(ByVal i As Integer)
        PBar1.Value = i
        'PBar2.Value = i
    End Sub

    Private Sub FinallyWork()
        If Cancelled Then
            Me.Labelinformation.Text = "نم إلغاء العملية"
        Else
            Me.Labelinformation.Text = "انتهى التحميل بنجاح"
        End If
    End Sub

    Private Sub DoSomeWork()
        'هذه حلقة دوران لزيادة القيمة
        For i As Integer = 0 To 100
            'مع أني متأكد من أنها لن تنفع ولكن سأكتبها
            If Cancelled Then
                Exit Sub
            End If
            AddValue(i) 'Progressbar زيادة قيمة
            System.Threading.Thread.Sleep(100) 'تأخير العملية قليلاً
        Next
    End Sub

    Private Sub BackWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker2.DoWork
        Me.CircularProgress3.Value = 0
        Me.CircularProgress3.Visible = True
        Me.CircularProgress3.IsRunning = True
        If Me.BackWorker2.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If
        'Me.Timer1.Start()

    End Sub

    Private Sub BackWorker2_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackWorker2.ProgressChanged
        Me.CircularProgress3.Value = e.ProgressPercentage
        Me.AddValue(e.ProgressPercentage)
    End Sub

    Private Sub BackWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker2.RunWorkerCompleted

        'If Me.PBar2.Value = 100 Then
        '    Me.Timer1.Dispose()
        '    Me.Button1.Enabled = True
        '    Me.Label13.Visible = False
        '    Me.Label14.Visible = False
        '    Me.PictureBox2.Visible = False
        '    Dim cur As New Form
        '    cur = New Finabalances1
        '    cur.Show()
        'End If

        If e.Cancelled Then
            Me.Labelstatus.Text = "نم إلغاء العملية"
        Else
            Me.Labelstatus.Text = "انتهى التحميل بنجاح"
        End If
        Me.CircularProgress3.IsRunning = False
        Me.CircularProgress3.Visible = False


    End Sub

<<<<<<< HEAD
    Private Sub Timsum1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timsum1.Tick
=======
    Private Sub Timsum1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timsum1.Tick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim I As Integer
        Me.PBar2.Value += 1
        Me.PBar2.Visible = True
        Me.Labelstatus.Visible = True
        Me.Labelinformation.Visible = True
        Me.Labelinformation.Text = "بيانات العملاء"
        For Each row As DataGridViewRow In Me.DataGridView4.Rows
            For I = 0 To Me.DataGridView4.Rows.Count - 1
                Me.DataGridView4.Focus()
                'BS.Position = I
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = Me.DataGridView4.Rows.Count - 1
                Me.PBar1.Value = I
                '=======================================================================INSERTRECOCABLES
                If Me.DataGridView4.Rows.Count = 0 Then
                    Me.Labelinformation.Text = " لايوجد بيانات العملاء"
                Else
                    Dim counter As Integer = Me.DataGridView4.CurrentRow.Index - 1
                    Dim nextRow As DataGridViewRow
                    If counter = Me.DataGridView4.RowCount Then
                        nextRow = Me.DataGridView4.Rows(0)
                        Me.Timsum1.Stop()
                    Else
                        nextRow = Me.DataGridView4.Rows(counter)
                        nextRow.Selected = True
                        'INSERTRECOCABLES()
                        Me.DataGridView4.CurrentCell = nextRow.Cells(0)
                        nextRow.Selected = True
                        Me.DataGridView4.Rows(counter).Selected = True
                    End If
                End If
                Dim percent As Integer = CInt(CDbl(Me.PBar1.Value - Me.PBar1.Minimum) / CDbl(Me.PBar1.Maximum - Me.PBar1.Minimum) * 100)
                Using gr As Graphics = Me.PBar1.CreateGraphics()
                    gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                End Using
                If Me.PBar1.Value <= 1 Then
                    Me.Labelstatus.Text = "بداية تشغيل البرنامج ـ العملاء ـ ـ"
                ElseIf Me.PBar1.Value < 25 Then
                    Me.Labelstatus.Text = "تحميل البرنامج ـ العملاء ـ ـ"
                ElseIf Me.PBar1.Value < 50 Then
                    Me.Labelstatus.Text = "التحقيق من الملفات ـ العملاء ـ ـ"
                ElseIf Me.PBar1.Value < 75 Then
                    Me.Labelstatus.Text = "الرجاء الانتظار ـ-العملاء-ـ-ـ-ـ"
                    Me.Labelstatus.Text = ""
                    Me.Labelstatus.Visible = False
                    Me.Labelinformation.Visible = False
                    Me.PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If
            Next
        Next
        '=================================================================INSERTRECORDempsolf
        For Each row As DataGridViewRow In Me.DataGridView5.Rows
            For I = 0 To Me.DataGridView5.Rows.Count - 1
                Me.DataGridView5.Focus()
                Me.BS.Position = I
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = Me.DataGridView5.Rows.Count - 1
                Me.PBar1.Value = I
                If Me.DataGridView5.Rows.Count = 0 Then
                    Me.Labelinformation.Text = " لايوجد بيانات الاعضاء"
                Else
                    Dim counter As Integer = Me.DataGridView5.CurrentRow.Index - 1
                    Dim nextRow As DataGridViewRow
                    If counter = Me.DataGridView5.RowCount Then
                        nextRow = Me.DataGridView5.Rows(0)
                        Me.Timsum1.Stop()
                    Else
                        nextRow = Me.DataGridView5.Rows(counter)
                        nextRow.Selected = True
                        'INSERTRECORDempsolf()
                        Me.DataGridView5.CurrentCell = nextRow.Cells(1)
                        nextRow.Selected = True
                        Me.DataGridView5.Rows(counter).Selected = True
                    End If
                End If
                Dim percent As Integer = CInt(CDbl(Me.PBar1.Value - Me.PBar1.Minimum) / CDbl(PBar1.Maximum - Me.PBar1.Minimum) * 100)
                Using gr As Graphics = PBar1.CreateGraphics()
                    gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                End Using
                If Me.PBar1.Value <= 1 Then
                    Me.Labelstatus.Text = "بداية تشغيل البرنامج ـ الاعضاء ـ ـ"
                ElseIf Me.PBar1.Value < 25 Then
                    Me.Labelstatus.Text = "تحميل البرنامج ـ الاعضاء ـ ـ"
                ElseIf Me.PBar1.Value < 50 Then
                    Me.Labelstatus.Text = "التحقيق من الملفات ـ الاعضاء ـ ـ"
                ElseIf Me.PBar1.Value < 75 Then
                    Me.Labelstatus.Text = "الرجاء الانتظار ـ-الاعضاء-ـ-ـ-ـ"
                    Me.Labelstatus.Text = ""
                    Me.Labelstatus.Visible = False
                    Me.Labelinformation.Visible = False
                    Me.PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If
            Next
        Next
        ''=================================================================INSERTRECOSuppliers1
        For Each row As DataGridViewRow In Me.DataGridView7.Rows
            For I = 0 To Me.DataGridView7.Rows.Count - 1
                Me.DataGridView7.Focus()
                Me.BS.Position = I
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = Me.DataGridView7.Rows.Count - 1
                Me.PBar1.Value = I
                If Me.DataGridView7.Rows.Count = 0 Then
                    Me.Labelinformation.Text = " لايوجد بيانات الموردين"
                Else
                    Dim counter As Integer = Me.DataGridView7.CurrentRow.Index - 1
                    Dim nextRow As DataGridViewRow
                    If counter = Me.DataGridView7.RowCount Then
                        nextRow = Me.DataGridView7.Rows(0)
                        Me.Timsum1.Stop()
                    Else
                        nextRow = Me.DataGridView7.Rows(counter)
                        nextRow.Selected = True
                        'INSERTRECOSuppliers1()
                        Me.DataGridView7.CurrentCell = nextRow.Cells(0)
                        nextRow.Selected = True
                        Me.DataGridView7.Rows(counter).Selected = True
                    End If
                End If
                Dim percent As Integer = CInt(CDbl(Me.PBar1.Value - Me.PBar1.Minimum) / CDbl(Me.PBar1.Maximum - Me.PBar1.Minimum) * 100)
                Using gr As Graphics = Me.PBar1.CreateGraphics()
                    gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                End Using
                If Me.PBar1.Value <= 1 Then
                    Me.Labelstatus.Text = "بداية تشغيل البرنامج ـ الموردين ـ ـ"
                ElseIf Me.PBar1.Value < 25 Then
                    Me.Labelstatus.Text = "تحميل البرنامج ـ الموردين ـ ـ"
                ElseIf Me.PBar1.Value < 50 Then
                    Me.Labelstatus.Text = "التحقيق من الملفات ـ الموردين ـ ـ"
                ElseIf Me.PBar1.Value < 75 Then
                    Me.Labelstatus.Text = "الرجاء الانتظار ـ-الموردين-ـ-ـ-ـ"
                    Me.Labelstatus.Text = ""
                    Me.Labelstatus.Visible = False
                    Me.Labelinformation.Visible = False
                    Me.PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If
            Next
        Next
        ''=================================================================INSERTRECOEMPSOLF
        For Each row As DataGridViewRow In Me.DataGridView6.Rows
            For I = 0 To Me.DataGridView6.Rows.Count - 1
                Me.DataGridView6.Focus()
                BS.Position = I
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = Me.DataGridView6.Rows.Count - 1
                Me.PBar1.Value = I
                If Me.DataGridView6.Rows.Count = 0 Then
                    Me.Labelinformation.Text = " لايوجد بيانات الموظفين"
                Else
                    Dim counter As Integer = Me.DataGridView6.CurrentRow.Index + 1
                    Dim nextRow As DataGridViewRow
                    If counter = Me.DataGridView6.RowCount Then
                        nextRow = Me.DataGridView6.Rows(0)
                        Me.Timsum1.Stop()
                    Else
                        nextRow = DataGridView6.Rows(counter)
                        nextRow.Selected = True
                        'INSERTRECOEMPSOLF()
                        Me.DataGridView6.CurrentCell = nextRow.Cells(0)
                        nextRow.Selected = True
                        Me.DataGridView6.Rows(counter).Selected = True
                    End If
                End If
                Dim percent As Integer = CInt(CDbl(Me.PBar1.Value - Me.PBar1.Minimum) / CDbl(Me.PBar1.Maximum - Me.PBar1.Minimum) * 100)
                Using gr As Graphics = Me.PBar1.CreateGraphics()
                    gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                End Using
                If Me.PBar1.Value <= 1 Then
                    Me.Labelstatus.Text = "بداية تشغيل البرنامج ـ الموظفين ـ ـ"
                ElseIf PBar1.Value < 25 Then
                    Me.Labelstatus.Text = "تحميل البرنامج ـ الموظفين ـ ـ"
                ElseIf Me.PBar1.Value < 50 Then
                    Me.Labelstatus.Text = "التحقيق من الملفات ـ الموظفين ـ ـ"
                ElseIf Me.PBar1.Value < 75 Then
                    Me.Labelstatus.Text = "الرجاء الانتظار ـ-الموظفين-ـ-ـ-ـ"
                    Me.Labelstatus.Text = ""
                    Me.Labelstatus.Visible = False
                    Me.Labelinformation.Visible = False
                    Me.PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If
            Next
        Next
        ''=================================================================INSERTRECOSuppliers1
        For Each row As DataGridViewRow In Me.DataGridView10.Rows
            For I = 0 To DataGridView10.Rows.Count - 1
                Me.DataGridView10.Focus()
                Me.BS.Position = I
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = Me.DataGridView10.Rows.Count - 1
                Me.PBar1.Value = I
                If Me.DataGridView10.Rows.Count = 0 Then
                    Me.Labelinformation.Text = " لايوجد بيانات الاصناف"
                Else
                    Dim counter As Integer = Me.DataGridView10.CurrentRow.Index + 1
                    Dim nextRow As DataGridViewRow
                    If counter = Me.DataGridView10.RowCount Then
                        nextRow = DataGridView10.Rows(0)
                        Me.Timsum1.Stop()
                    Else
                        nextRow = Me.DataGridView10.Rows(counter)
                        nextRow.Selected = True
                        'SAVERECORD()
                        Me.DataGridView10.CurrentCell = nextRow.Cells(1)
                        nextRow.Selected = True
                        Me.DataGridView10.Rows(counter).Selected = True
                    End If
                End If
                Dim percent As Integer = CInt(CDbl(Me.PBar1.Value - Me.PBar1.Minimum) / CDbl(Me.PBar1.Maximum - Me.PBar1.Minimum) * 100)
                Using gr As Graphics = PBar1.CreateGraphics()
                    gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                End Using
                If Me.PBar1.Value <= 1 Then
                    Me.Labelstatus.Text = "بداية تشغيل البرنامج ـ الاصناف ـ ـ"
                ElseIf Me.PBar1.Value < 25 Then
                    Me.Labelstatus.Text = "تحميل البرنامج ـ الاصناف ـ ـ"
                ElseIf Me.PBar1.Value < 50 Then
                    Me.Labelstatus.Text = "التحقيق من الملفات ـ الاصناف ـ ـ"
                ElseIf Me.PBar1.Value < 75 Then
                    Me.Labelstatus.Text = "الرجاء الانتظار ـ-الاصناف-ـ-ـ-ـ"
                    Me.Labelstatus.Text = ""
                    Me.Labelstatus.Visible = False
                    Me.Labelinformation.Visible = False
                    Me.PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If

            Next
        Next
        ''=================================================================INSERTRECOSuppliers1
        For Each row As DataGridViewRow In Me.DataGridView11.Rows
            For I = 0 To Me.DataGridView11.Rows.Count - 1
                Me.DataGridView11.Focus()
                Me.BS.Position = I
                Me.PBar1.Minimum = 1
                Me.PBar1.Maximum = Me.DataGridView11.Rows.Count - 1
                Me.PBar1.Value = I

                If Me.DataGridView11.Rows.Count = 0 Then
                    Me.Labelinformation.Text = " لايوجد بيانات الذمم المدينة"
                Else
                    Dim counter As Integer = Me.DataGridView11.CurrentRow.Index + 1
                    Dim nextRow As DataGridViewRow
                    If counter = Me.DataGridView11.RowCount Then
                        nextRow = DataGridView11.Rows(0)
                        Me.Timsum1.Stop()
                    Else
                        nextRow = Me.DataGridView11.Rows(counter)
                        nextRow.Selected = True
                        'INSERTRECOLoans()
                        Me.DataGridView11.CurrentCell = nextRow.Cells(1)
                        nextRow.Selected = True
                        Me.DataGridView11.Rows(counter).Selected = True
                    End If
                End If
                Dim percent As Integer = CInt(CDbl(Me.PBar1.Value - Me.PBar1.Minimum) / CDbl(Me.PBar1.Maximum - Me.PBar1.Minimum) * 100)
                Using gr As Graphics = Me.PBar1.CreateGraphics()
                    gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.PBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.PBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
                End Using
                If Me.PBar1.Value <= 1 Then
                    Me.Labelstatus.Text = "بداية تشغيل البرنامج ـ الذمم المدينة ـ ـ"
                ElseIf Me.PBar1.Value < 25 Then
                    Me.Labelstatus.Text = "تحميل البرنامج ـ الذمم المدينة ـ ـ"
                ElseIf Me.PBar1.Value < 50 Then
                    Me.Labelstatus.Text = "التحقيق من الملفات ـ الذمم المدينة ـ ـ"
                ElseIf Me.PBar1.Value < 75 Then
                    Me.Labelstatus.Text = "الرجاء الانتظار ـ-الذمم المدينة-ـ-ـ-ـ"
                    Me.Labelstatus.Text = ""
                    Me.Labelstatus.Visible = False
                    Me.Labelinformation.Visible = False
                    Me.PBar1.Visible = False
                    Me.Cursor = Cursors.Default
                End If
            Next
        Next
        'INSERTREBANKJO()
        'INSERTCASHIER()
        'INSERTRChecks()
    End Sub

<<<<<<< HEAD
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button3.Click
=======
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim strFileName As String
        If Me.DataGridView1.RowCount <= 1 Then
            MessageBox.Show("الجدول فارغ من السجلات", " ملحوظة", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try
            If (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0) Then
                Exit Sub
            End If
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")

            Dim dset As New DataSet
            dset.Tables.Add()
            For i As Integer = 0 To Me.DataGridView1.ColumnCount - 1
                dset.Tables(0).Columns.Add(Me.DataGridView1.Columns(i).HeaderText)
            Next
            Dim dr1 As DataRow
            For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                dr1 = dset.Tables(0).NewRow
                For j As Integer = 0 To Me.DataGridView1.Columns.Count - 1
                    dr1(j) = Me.DataGridView1.Rows(i).Cells(j).Value
                Next
                dset.Tables(0).Rows.Add(dr1)
            Next
            '==============================================
            Dim dset1 As New DataSet
            dset1.Tables.Add()
            For i As Integer = 0 To Me.DataGridView2.ColumnCount - 1
                dset1.Tables(0).Columns.Add(Me.DataGridView2.Columns(i).HeaderText)
            Next
            Dim dr2 As DataRow
            For i As Integer = 0 To Me.DataGridView2.RowCount - 1
                dr2 = dset1.Tables(0).NewRow
                For j As Integer = 0 To Me.DataGridView2.Columns.Count - 1
                    dr2(j) = Me.DataGridView2.Rows(i).Cells(j).Value
                Next
                dset1.Tables(0).Rows.Add(dr2)
            Next
            '==============================================================
            Dim excel As New Microsoft.Office.Interop.Excel.Application
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
<<<<<<< HEAD
            Dim newCulture As Globalization.CultureInfo
            Dim OldCulture As Globalization.CultureInfo
            OldCulture = System.Threading.Thread.CurrentThread.CurrentCulture
            newCulture = New Globalization.CultureInfo( _
=======
            Dim newCulture As System.Globalization.CultureInfo
            Dim OldCulture As System.Globalization.CultureInfo
            OldCulture = System.Threading.Thread.CurrentThread.CurrentCulture
            newCulture = New System.Globalization.CultureInfo( _
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                excel.LanguageSettings.LanguageID(Microsoft.Office.Core.MsoAppLanguageID.msoLanguageIDUI))
            System.Threading.Thread.CurrentThread.CurrentCulture = newCulture
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "الميزان العمومي"
            '==================================================================

<<<<<<< HEAD
            Dim dt As DataTable = dset.Tables(0)
            Dim dc As DataColumn
            Dim dr As DataRow
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0
            '========================================================================
            Dim dt1 As DataTable = dset1.Tables(0)
            Dim dc1 As DataColumn
            Dim dr3 As DataRow
=======
            Dim dt As System.Data.DataTable = dset.Tables(0)
            Dim dc As System.Data.DataColumn
            Dim dr As System.Data.DataRow
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0
            '========================================================================
            Dim dt1 As System.Data.DataTable = dset1.Tables(0)
            Dim dc1 As System.Data.DataColumn
            Dim dr3 As System.Data.DataRow
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim colIndex1 As Integer = 0
            Dim rowIndex1 As Integer = 0
            '========================================================================
            For Each dc In dt.Columns
                colIndex += 1
                excel.Cells(1, colIndex) = dc.ColumnName
            Next
            '========================================================================
            For Each dc1 In dt1.Columns
                colIndex1 += 1
                excel.Cells(1, colIndex1) = dc1.ColumnName
            Next

            For Each dr In dt.Rows
                rowIndex += 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex += 1
                    excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                Next
            Next
            If dt.Rows.Count - 1 Then
                For Each dr3 In dt1.Rows
                    rowIndex1 += 1
                    colIndex1 = 0
                    For Each dc1 In dt1.Columns
                        colIndex1 += 1
                        excel.Cells(rowIndex1 + rowIndex + 2, colIndex1) = dr3(dc1.ColumnName)
                    Next
                Next
            End If
            wSheet.Columns.AutoFit()
            Dim blnFileOpen As Boolean = False
            Dim ofd As New SaveFileDialog With {
                .Filter = "Excel Files (*.xls)|*.xls"
            }
            With ofd
                .FilterIndex = 1
                .Title = "حفظ ملف"
                MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
                .InitialDirectory = MYFOLDER & "\Excel"
                .AddExtension = True
                .FileName = "الميزان العمومي" & "-" & Format(Date.Today, "dd-MM-yyyy").ToString
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    If Len(.FileName) > 0 Then
                        strFileName = ofd.FileName
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End With
            Try
<<<<<<< HEAD
                Dim fileTemp As IO.FileStream = System.IO.File.OpenWrite(strFileName)
=======
                Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                fileTemp.Close()
            Catch ex As Exception
                blnFileOpen = False
            End Try
            If System.IO.File.Exists(strFileName) Then
                System.IO.File.Delete(strFileName)
            End If
            wBook.SaveAs(strFileName)
            excel.Workbooks.Open(strFileName)
            excel.Visible = True
            System.Threading.Thread.CurrentThread.CurrentCulture = OldCulture
        Catch ex As Exception
            If ex.Message.ToString = "Old format or invalid type library. (Exception from HRESULT: 0x80028018 (TYPE_E_INVDATAREAD))" Then
                MessageBox.Show(" من فضلك غير التنسيق الى" & vbCrLf & vbCrLf & "  English(United States)")
                Dim F As New FrmWindows
                F.Show()
                F.ADDBUTTON.PerformClick()
            Else
                MsgBox(ex.Message)
                Exit Sub
            End If
        End Try
    End Sub




End Class