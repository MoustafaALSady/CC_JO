Public Class FrmFinabalances
    Public xx As Integer = 0
    ReadOnly InvDataset As New DataSet
    Dim adp As New SqlClient.SqlDataAdapter

    Dim MouseX As Integer
    Dim MouseY As Integer
    Dim Drag As Boolean

    Private Sub FrmDATE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        On Error Resume Next
        Me.Timer1.Enabled = False
        Me.Close()
    End Sub
    Private Sub FrmDATE_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub FrmDATE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Dim N As Integer
        Dim firstDate As String, days As Integer
        Dim secondDate As Date
        Dim D As Double = 7
        Dim s As Date = DateAdd(DateInterval.Day, D, Now.Date)




        Me.DataGridView1.Rows.Clear()
        N = 1
        Dim ds As DataSet
        ds = New DataSet
        DataGridView1.Rows.Clear()
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strSQL As New SqlClient.SqlCommand("", Consum)
        With strSQL
            '.CommandText = "select FIELD1 ,FIELD2 ,FIELD3 ,FIELD4 ,USERNAME ,CUser ,COUser from TNote  WHERE  USERNAME='" & USERNAME & "'and  Field4>= '" & Now.Date.ToString("yyyy/MM/dd") & "' AND Field4<= '" & B.ToString("yyyy/MM/dd") & "'" & " ORDER BY Field4"
            .CommandText = "SELECT FIELD1  ,FIELD3 ,FIELD4 ,USERNAME ,CUser ,COUser FROM TNote  WHERE  USERNAME='" & USERNAME & "'and  Field4>= '" & Now.Date.ToString("yyyy-MM-dd") & "'" & "AND Field4 <= '" & s.ToString("yyyy-MM-dd") & "'ORDER BY Field4"
            '                                                                                                                                                   someDate.ToString("MM/dd/yyyy"

            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
        End With
        adp = New SqlClient.SqlDataAdapter(strSQL)
        Dim oCommandBuilder As New SqlClient.SqlCommandBuilder(adp)
        adp.Fill(ds, "TNote")
        If Me.BindingContext(ds, "TNote").Count = 0 Then
            MsgBox("لا يوجد اي مواعيد لعرضها", 64 + 524288, "عرض البيانات")
            Exit Sub
            'Me.Close()
        Else
            For I As Integer = 0 To ds.Tables("TNote").Rows.Count - 1
                firstDate = ds.Tables("TNote").Rows(I).Item("Field4")
                secondDate = CDate(firstDate)
                days = DateDiff(DateInterval.Day, Now, secondDate)
                If days <= 31 Then
                    If days <= 10 Then
                        Me.DataGridView1.Columns(1).CellTemplate.Style.BackColor = Color.DarkRed
                        Me.DataGridView1.Columns(1).CellTemplate.Style.ForeColor = Color.Yellow
                    End If
                    If days > 10 AndAlso days <= 20 Then
                        Me.DataGridView1.Columns(1).CellTemplate.Style.BackColor = Color.HotPink
                        Me.DataGridView1.Columns(1).CellTemplate.Style.ForeColor = Color.DarkBlue
                        Me.DataGridView1.Columns(0).CellTemplate.Style.ForeColor = Color.Red
                    End If
                    If days > 20 Then
                        Me.DataGridView1.Columns(1).CellTemplate.Style.BackColor = Color.Pink
                        Me.DataGridView1.Columns(1).CellTemplate.Style.ForeColor = Color.DarkBlue
                        Me.DataGridView1.Columns(0).CellTemplate.Style.ForeColor = Color.DarkBlue

                    End If
                    Dim str As String() = {N, ds.Tables("TNote").Rows(I).Item("FIELD4"),
                    ds.Tables("TNote").Rows(I).Item("FIELD3"), days}
                    'Me.DataGridView1.Columns("taimA").DefaultCellStyle.Format = "HH:mm:ss tt"
                    Me.DataGridView1.Rows.Add(str)
                    N += 1
                End If
            Next
            Blinking()
        End If
        Consum.Close()
    End Sub
    Private Sub Blinking()
        Dim I As Integer

        For I = 0 To Me.DataGridView1.Rows.Count - 1
            Dim row As DataGridViewRow = Me.DataGridView1.Rows(I)
            Dim Days As DataGridViewTextBoxCell = row.Cells("FIELD2")
            If Days.Value <= 10 Then
                Me.Timer1.Enabled = True
                Me.Timer1.Interval = 1
            End If

        Next
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If xx >= 1 And xx <= 20 Then
            For I As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                Dim row As DataGridViewRow = Me.DataGridView1.Rows(I)
                Dim Days As DataGridViewTextBoxCell = row.Cells("FIELD2")
                If Days.Value <= 10 Then
                    row.Cells(2).Style.ForeColor = Color.Yellow
                    row.Cells(2).Style.BackColor = Color.Black
                    row.Cells("FIELD2").Style.BackColor = Color.Yellow
                End If
            Next
            If xx = 1 Then
                My.Computer.Audio.PlaySystemSound(
                                       System.Media.SystemSounds.Exclamation)
            End If
        End If
        If xx >= 21 And xx <= 50 Then
            For I As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                Dim row As DataGridViewRow = Me.DataGridView1.Rows(I)

                Dim Days As DataGridViewTextBoxCell = row.Cells("FIELD2")
                If Days.Value <= 10 Then
                    row.Cells(2).Style.ForeColor = Color.Black
                    row.Cells(2).Style.BackColor = Color.Yellow
                    row.Cells(3).Style.BackColor = Color.Black
                End If
            Next
            If xx = 22 Then
                My.Computer.Audio.PlaySystemSound(
                  System.Media.SystemSounds.Exclamation)
            End If
        End If
        If xx >= 50 Then
            xx = 1
        End If
        xx += 1
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, Label1.MouseDown, DataGridView1.MouseDown
        Drag = True
        MouseX = Cursor.Position.X - Me.Left
        MouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, Label1.MouseMove, DataGridView1.MouseMove
        If Drag = True Then
            Me.Left = Cursor.Position.X - MouseX
            Me.Top = Cursor.Position.Y - MouseY
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, Label1.MouseUp, DataGridView1.MouseUp
        Drag = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

End Class