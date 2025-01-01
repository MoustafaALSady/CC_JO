Imports System.Data.SqlClient

Public Class FrmNote
    Dim IsDown As Boolean
    Public cnn As New SqlConnection
    Public cmd As New SqlCommand
    Public SqlDataAdapter1 As New SqlDataAdapter
    Public ds As New DataSet

    Dim WithEvents BS As New BindingSource
    Private ReadOnly m_blend As New Drawing2D.Blend
    Private ReadOnly m_Factors As Single() = {0.0F, 0.2F, 0.5F, 0.7F, 1.0F, 0.7F, 0.5F, 0.2F, 0.0F}
    Private ReadOnly m_Positions As Single() = {0.0F, 0.1F, 0.3F, 0.4F, 0.5F, 0.6F, 0.7F, 0.8F, 1.0F}
    Private ReadOnly m_Font As New Font("Tahoma", 11.0F, FontStyle.Bold)
    Private ReadOnly m_Color As Color = Color.FromArgb(255, 0, 0, 192)

    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    ReadOnly Cancel As Boolean = False
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim dx, dy As Integer
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            dx = e.X
            dy = e.Y
            IsDown = True
        End If
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        If IsDown = True Then
            Me.Left = Control.MousePosition.X - dx
            Me.Top = Control.MousePosition.Y - dy
        End If

    End Sub
    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        IsDown = False

    End Sub
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then 'Escape  اغلا ق البرنامج من خلال الزر
            Me.Close()
        End If
    End Sub

    Private Sub FrmNote_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        m_blend.Factors = m_Factors
        m_blend.Positions = m_Positions
        ' Draw Fixed Parts
        '---------------------------------------------------------------------
        Dim rect As New Rectangle(20, 20, 220, 220)
        Dim lgb As New Drawing2D.LinearGradientBrush(rect, Color.FromArgb(0, 0, 0), m_Color, 90, True) With {
            .Blend = m_blend
        }

        e.Graphics.FillEllipse(lgb, 20, 20, 200, 200)

        lgb.LinearColors = New Color() {m_Color, Color.FromArgb(0, 0, 0)}
        e.Graphics.FillEllipse(lgb, 30, 30, 180, 180)

        lgb.LinearColors = New Color() {Color.FromArgb(0, 0, 0), m_Color}
        e.Graphics.FillEllipse(lgb, 33, 33, 174, 174)

        ' draw small decoration

        'lgb.LinearColors = New Color() {Color.White, Color.FromArgb(0, 0, 0, 0), m_Color}
        'e.Graphics.FillEllipse(lgb, 105, 155, 50, 50)
        'Dim rText As Rectangle = New Rectangle(105, 155, 90, 60)
        'Dim m1 As New Font("Tahoma", 8.0F, FontStyle.Bold)
        'e.Graphics.DrawString(Now.Year, m1, Brushes.NavajoWhite, rText)
        ' Draw Image too if you want
        'Dim r As Rectangle = New Rectangle(100, 60, 50, 50)

        'Dim bmp As Bitmap = New Bitmap(My.Resources.nenufar)
        'e.Graphics.DrawImage(bmp, r)

        ' draw mask for numbers area
        Dim path As New Drawing2D.GraphicsPath()
        path.AddEllipse(40, 40, 160, 160)
        path.AddEllipse(60, 60, 120, 120)

        e.Graphics.FillPath(New SolidBrush(Color.FromArgb(20, Color.White)), path)

        ' Draw Numbers
        Dim sb As New SolidBrush(Color.White)

        ' Draw Numerals        
        e.Graphics.DrawString("1", m_Font, sb, 150, 50)
        e.Graphics.DrawString("2", m_Font, sb, 173, 75)
        e.Graphics.DrawString("3", m_Font, sb, 182, 110)
        e.Graphics.DrawString("4", m_Font, sb, 173, 145)
        e.Graphics.DrawString("5", m_Font, sb, 150, 170)
        e.Graphics.DrawString("6", m_Font, sb, 113, 180)
        e.Graphics.DrawString("7", m_Font, sb, 75, 170)
        e.Graphics.DrawString("8", m_Font, sb, 52, 145)
        e.Graphics.DrawString("9", m_Font, sb, 43, 110)
        e.Graphics.DrawString("10", m_Font, sb, 47, 75)
        e.Graphics.DrawString("11", m_Font, sb, 75, 50)
        e.Graphics.DrawString("12", m_Font, sb, 109, 40)


        ' Draw non fixed Parts
        ' -----------------------------------------------------------------

        e.Graphics.TranslateTransform(120, 120, Drawing2D.MatrixOrder.Append)

        Dim m_Hours As Integer = DateTime.Now.Hour
        Dim m_Minute As Integer = DateTime.Now.Minute
        Dim m_Second As Integer = DateTime.Now.Second

        Dim sAngle As Single = 2.0 * Math.PI * m_Second / 60.0 ' seconds
        Dim mAngle As Single = 2.0 * Math.PI * (m_Minute + m_Second / 60.0) / 60.0 ' minute
        Dim hAngle As Single = 2.0 * Math.PI * (m_Hours + m_Minute / 60.0) / 12.0 ' m_Hours



        ' Draw m_Hours Hand
        Dim PathHours As New Drawing2D.GraphicsPath()
        Dim HourArrow As Point() = {New Point(Convert.ToInt32(40 * Math.Sin(hAngle)), Convert.ToInt32(-40 * Math.Cos(hAngle))),
                                    New Point(Convert.ToInt32(-5 * Math.Cos(hAngle)), Convert.ToInt32(-5 * Math.Sin(hAngle))),
                                    New Point(Convert.ToInt32(5 * Math.Cos(hAngle)), Convert.ToInt32(5 * Math.Sin(hAngle))),
                                    New Point(Convert.ToInt32(40 * Math.Sin(hAngle)), Convert.ToInt32(-40 * Math.Cos(hAngle)))}


        PathHours.AddPolygon(HourArrow)
        Dim hourBrush As New Drawing2D.LinearGradientBrush(PathHours.GetBounds(), Color.Black, Color.Turquoise, 90, False) With {
            .Blend = m_blend
        }

        e.Graphics.FillPath(hourBrush, PathHours)
        e.Graphics.FillEllipse(hourBrush, -5, -5, 10, 10)

        ' Draw Minute Hand

        Dim PathMinutes As New Drawing2D.GraphicsPath()
        Dim MinArrow As Point() = {New Point(Convert.ToInt32(60 * Math.Sin(mAngle)), Convert.ToInt32(-60 * Math.Cos(mAngle))),
                                   New Point(Convert.ToInt32(-5 * Math.Cos(mAngle)), Convert.ToInt32(-5 * Math.Sin(mAngle))),
                                   New Point(Convert.ToInt32(5 * Math.Cos(mAngle)), Convert.ToInt32(5 * Math.Sin(mAngle))),
                                   New Point(Convert.ToInt32(60 * Math.Sin(mAngle)), Convert.ToInt32(-60 * Math.Cos(mAngle)))}



        PathMinutes.AddPolygon(MinArrow)
        Dim minuteBrush As New Drawing2D.LinearGradientBrush(PathMinutes.GetBounds(), Color.Black, Color.DarkTurquoise, 90, False) With {
            .Blend = m_blend
        }

        e.Graphics.FillPath(minuteBrush, PathMinutes)
        e.Graphics.FillEllipse(hourBrush, -5, -5, 10, 10)


        ' Draw Second Hand        
        Dim secondPen As New Pen(Color.Gold, 1)
        Dim m_Point As New Point(0, 0)

        Dim secHand As New Point(Convert.ToInt32(70 * Math.Sin(sAngle)), Convert.ToInt32(-70 * Math.Cos(sAngle)))
        e.Graphics.DrawLine(secondPen, m_Point, secHand)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        Me.Refresh()
    End Sub

    Private Sub FrmNote_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        On Error Resume Next
        Me.BackgroundImage = img
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
        'Call mangUsers()
        Me.SHOWBUTTON()
        Me.SAVEBUTTON.Enabled = False
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try

1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT FIELD1 ,FIELD2 ,FIELD3 ,FIELD4 ,USERNAME ,CUser ,COUser  FROM TNote  WHERE  CUser='" & CUser & "'  ORDER BY Field1"
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                SqlDataAdapter1 = New SqlDataAdapter(strSQL)
                Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
                Me.ds.Clear()
                SqlDataAdapter1.Fill(Me.ds, "TNote")
                Me.BS.DataSource = ds
                Me.BS.DataMember = "TNote"
            End With
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
            'Label2.ForeColor = Color.Yellow
            'Label20.Text = "فضلا انتظر قليلا .. يتم تحميل سجلات الحقل"
        Else
            Me.Close()
        End If


    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.ds.Tables("TNote")
            Me.RowCount = Me.BS.Count
            Me.TEXT1.DataBindings.Add("text", Me.BS, "Field1", True, 1, "")
            Me.DateTimePicker1.DataBindings.Add("text", Me.BS, "Field2", True, 1, "")
            Me.TEXTBOX1.DataBindings.Add("text", Me.BS, "Field3", True, 1, "")
            Me.DateTimePicker4.DataBindings.Add("text", BS, "Field4", True, 1, "")
            Me.TextBox4.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TextBox2.DataBindings.Add("text", Me.BS, "cuser", True, 1, "")
            Me.TextBox3.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
            If Me.DateTimePicker4.Text < ServerDateTime.ToString("yyyy-MM-dd") And Len(Me.TEXTBOX1.Text) > 0 Then
                Me.Label5.Text = "أنقضى الوقت"
            ElseIf Me.DateTimePicker4.Text >= ServerDateTime.ToString("yyyy-MM-dd") And Len(Me.TEXTBOX1.Text) > 0 Then
                Me.Label5.Text = MyResultDate(Me.DateTimePicker4.Text, ServerDateTime.ToString("yyyy-MM-dd"))
            End If
            Me.RecordCount()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub

    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
            'كود حفظ الاضافة وحفظ التعديل
1:
            SqlDataAdapter1.Update(ds, "TNote")
            ds = New DataSet
            SqlDataAdapter1.Fill(ds, "TNote")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1115812848 Or ex.Message.GetHashCode = 379362862 Then
                e.Cancel = True
                PictureBox2False()
                MsgBox("يوجد تكرار في رقم الهاتف المدخل", 16, "تنبيه")
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If Me.DelRow = True Then
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            'تابع كود حفظ الاضافة والتعديل
            Application.DoEvents()
            Me.BS.DataSource = ds.Tables("TNote")
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
            Dim Sound As IO.Stream = My.Resources.save
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
        End If
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
    End Sub
#Region "AddButton"
    Private Sub AddButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
        ADDBUTTON.Enabled = False
        EDITBUTTON.Enabled = False
        SAVEBUTTON.Enabled = True
        BUTTONCANCEL.Enabled = True
        DELETEBUTTON.Enabled = False
        Dim n As Double
        Dim s As Double
        n = BS.Count
        On Error Resume Next
        BS.Position = BS.Count - 1
        s = Val(Me.TEXT1.Text)
        BS.EndEdit()
        BS.AddNew()
        If n = 0 Then
            Me.TEXT1.Text = 1
        Else
            If n >= s Then
                Me.TEXT1.Text = Val(n) + 1
            Else
                Me.TEXT1.Text = Val(s) + 1
            End If
        End If
        Me.DateTimePicker1.Text = Now.ToString("yyyy-MM-dd HH:mm:ss tt")
        Me.DateTimePicker4.Text = Now.ToString("yyyy-MM-dd")
        Me.TEXTBOX1.Text = ""
        Me.TextBox3.Text = COUser.ToString.Trim
        Me.TextBox2.Text = CUser.ToString.Trim
        Me.TextBox4.Text = USERNAME.ToString.Trim
    End Sub
#End Region
#Region "SaveButton"
    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
        Static Dim P As Integer
        P = BS.Position
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            'If LockAddRow = False Then
            '    MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            '    Exit Sub
            'End If
            Me.TextBox2.Text = CUser.ToString.Trim
            Me.TextBox3.Text = COUser.ToString.Trim
            Me.Cursor = Cursors.WaitCursor
            PictureBox2.Visible = True
            BS.EndEdit()
            RowCount = BS.Count
            SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            SaveTab.RunWorkerAsync()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'frmNote_Load(sender, e)
        ' LastButton_Click(sender, e)
    End Sub
#End Region
#Region "EditButton"
    Private Sub EditButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
        Static n As Integer
        Try
            ADDBUTTON.Enabled = True
            SAVEBUTTON.Enabled = False
            EDITBUTTON.Enabled = True
            BUTTONCANCEL.Enabled = True
            DELETEBUTTON.Enabled = True

            Me.Cursor = Cursors.WaitCursor
            PictureBox2.Visible = True
            BS.EndEdit()
            RowCount = BS.Count
            SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            SaveTab.RunWorkerAsync()

            BS.Position = n
            RecordCount()

        Catch ex As SqlException
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
#End Region
#Region "RecordCount"
    Private Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = BS.Count
        CurrenRecordst = BS.Position + 1
        RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If BS.Position > 0 Then
            Back = True
        End If
        If BS.Position < ds.Tables("TNote").Rows.Count - 1 Then
            Forward = True
        End If
        FIRSTBUTTON.Enabled = Back
        PREVIOUSBUTTON.Enabled = Back
        NEXTBUTTON.Enabled = Forward
        LASTBUTTON.Enabled = Forward
    End Sub
#End Region
#Region "DISPLAYRECORD"
    Private Sub DISPLAYRECORD()
        On Error Resume Next
        With Me
            .TEXT1.Text = ds.Tables("TNote").Rows(BS.Position)("Field1").ToString
            .DateTimePicker1.Text = ds.Tables("TNote").Rows(BS.Position)("Field2").ToString
            .TEXTBOX1.Text = ds.Tables("TNote").Rows(BS.Position)("Field3").ToString
            .DateTimePicker4.Text = ds.Tables("TNote").Rows(BS.Position)("Field4").ToString
            If Me.DateTimePicker4.Text < Format(Now, "yyyy/MM/dd") Then
                Me.Label5.Text = "أنقضى الوقت"
            ElseIf Me.DateTimePicker4.Text >= Format(Now, "yyyy/MM/dd") Then
                Me.Label5.Text = MyResultDate(Me.DateTimePicker4.Text, Format(Now, "yyyy/MM/dd"))
            End If
        End With
    End Sub
#End Region
#Region "FirstButton"
    Private Sub FirstButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FIRSTBUTTON.Click
        On Error Resume Next
        BS.Position = 0
        RecordCount()
    End Sub
#End Region
#Region "PreviousButton"
    Private Sub PreviousButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PREVIOUSBUTTON.Click
        On Error Resume Next
        BS.Position = BS.Position - 1
        RecordCount()
    End Sub
#End Region
#Region "NextButton"
    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NEXTBUTTON.Click
        On Error Resume Next
        BS.Position = BS.Position + 1
        RecordCount()
    End Sub
#End Region
#Region "LastButton"
    Private Sub LastButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
        On Error Resume Next
        BS.Position = BS.Count - 1
        RecordCount()
    End Sub
#End Region
#Region "ButtonCancel"
    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        ADDBUTTON.Enabled = True
        SAVEBUTTON.Enabled = False
        EDITBUTTON.Enabled = True
        BUTTONCANCEL.Enabled = True
        DELETEBUTTON.Enabled = True
        BS.CancelEdit()
        RecordCount()
    End Sub
#End Region
#Region "DeleteButton"
    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
        Try
            cmd.Connection = cnn
            cmd.CommandText = "delete from TNote where FIELD1=" & TEXT1.Text
            cnn.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show(" تمت عملية الحذف", "حذف بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RecordCount()
            cnn.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try
        FrmNote_Load(sender, e)
    End Sub
#End Region
#Region "Text2_KeyUp"
    Private Sub Text2_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
#End Region

    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles InternalAuditorERBUTTON.Click
        On Error Resume Next
        Me.Timer3.Enabled = False
        Me.Timer3.Stop()
        My.Computer.Audio.Stop()
    End Sub
    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer2.Tick
        Try
            If Me.DateTimePicker4.Text < ServerDateTime.ToString("yyyy-MM-dd") Then
                Me.Label5.Text = "أنقضى الوقت"
                Dim Sound As IO.Stream = My.Resources.Windows_Pop_up_Blocked
                My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)

            ElseIf Me.DateTimePicker4.Text >= ServerDateTime.ToString("yyyy-MM-dd") Then
                Me.Label5.Text = MyResultDate(Me.DateTimePicker4.Text, ServerDateTime.ToString("yyyy-MM-dd"))
            End If
            If Me.DateTimePicker4.Text = ServerDateTime.ToString("yyyy-MM-dd") Then
                Me.Timer3.Enabled = True
                Me.Timer2.Enabled = False
                MessageBox.Show(Me.TEXTBOX1.Text, "اجندة المواعيد", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP1.Click
        Me.Label4.Text = ""
        If Me.DateTimePicker2.Text >= Me.DateTimePicker3.Text Then
            MessageBox.Show("يجب انا تكون المدة الاولى اقل من الثانية", "اجندة المواعيد", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
        Else
            Me.Label4.Text = MyResultDate(Me.DateTimePicker3.Text, Me.DateTimePicker2.Text)
        End If
    End Sub


    Private Sub Timer3_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer3.Tick
        Try
            Dim Sound As IO.Stream = My.Resources.Windows_Pop_up_Blocked
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            'My.Computer.Audio.Play(Application.StartupPath & "\Windows XP Notify.wav", AudioPlayMode.BackgroundLoop)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
            Exit Sub
        End Try
    End Sub

End Class