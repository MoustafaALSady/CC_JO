Imports System.Data.SqlClient

Public Class FrmCheckslsta
    Public xx As Integer = 0
    Private adp As New SqlClient.SqlDataAdapter
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Private Sub FrmCheckslsta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Timer1.Enabled = False
        Timer2.Enabled = False
    End Sub
    Private Sub FrmCheckslsta_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage2.Show()
        Me.TabPage1.Show()
    End Sub
    Private Sub FrmCheckslsta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.BackgroundImage = img
            Me.TabPage1.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            Me.Label1.Text = CUser
            Me.Label2.Text = Val(ChecksIN)
            Showcustomsaccountbyquery1()
            Showcustomsaccountbyquery()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Blinking()
        Dim I As Integer
        For I = 0 To Me.DGRD.Rows.Count - 1
            Dim row As DataGridViewRow = Me.DGRD.Rows(I)
            Dim Days As DataGridViewTextBoxCell = row.Cells("Column2")
            If Days.Value <= Val(ChecksIN - 25) Then
                Timer1.Enabled = True
                Timer1.Interval = 1
            End If
            Dim I1 As Integer
            For I1 = 0 To Me.DataGridView1.Rows.Count - 1
                Dim row1 As DataGridViewRow = Me.DataGridView1.Rows(I1)
                Dim Days1 As DataGridViewTextBoxCell = row1.Cells(5)
                If Days1.Value <= Val(ChecksIN - 25) Then
                    Timer2.Enabled = True
                    Timer2.Interval = 1
                End If
            Next
        Next
    End Sub
    Private Sub Showcustomsaccountbyquery1()
        Try
            Dim N As Integer
            Dim firstDate As String, days As Integer
            Dim secondDate As Date
            N = 1
            Dim ds1 As DataSet
            ds1 = New DataSet
            DGRD.Rows.Clear()
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            Consum.Open()
            With strSQL
                .CommandText = "select  IDCH, CH1, CH3, CH7, CH8  from Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & True & "' and CH17 ='" & False & "'  and IDCH>'" & 0 & "' ORDER BY IDCH"
            End With
            adp = New SqlClient.SqlDataAdapter(strSQL)
            adp.Fill(ds1, "Checks")
            If Me.BindingContext(ds1, "Checks").Count = 0 Then
                MsgBox("·« ÌÊÃœ »Ì«‰«  ·⁄—÷Â«", 64 + 524288, "⁄—÷ «·»Ì«‰« ")
                Exit Sub
            End If
            For I As Integer = 0 To ds1.Tables("Checks").Rows.Count - 1
                firstDate = ds1.Tables("Checks").Rows(I).Item("CH3")
                secondDate = CDate(firstDate)
                days = DateDiff(DateInterval.Day, ServerDateTime, secondDate)

                If days <= Val(ChecksIN) Then
                    If days <= Val(ChecksIN - 25) Then
                        DGRD.Columns(4).CellTemplate.Style.BackColor = Color.DarkRed
                        DGRD.Columns(4).CellTemplate.Style.ForeColor = Color.Yellow
                    End If
                    If days > Val(ChecksIN - 20) AndAlso days <= Val(ChecksIN - 10) Then
                        DGRD.Columns(4).CellTemplate.Style.BackColor = Color.HotPink
                        DGRD.Columns(4).CellTemplate.Style.ForeColor = Color.DarkBlue
                        DGRD.Columns(2).CellTemplate.Style.ForeColor = Color.Red
                    End If
                    If days > Val(ChecksIN - 10) Then
                        DGRD.Columns(4).CellTemplate.Style.BackColor = Color.Pink
                        DGRD.Columns(4).CellTemplate.Style.ForeColor = Color.DarkBlue
                        DGRD.Columns(2).CellTemplate.Style.ForeColor = Color.DarkBlue

                    End If
                    Dim str As String() = {ds1.Tables("Checks").Rows(I).Item("IDCH"), ds1.Tables("Checks").Rows(I).Item("ch1"),
                        ds1.Tables("Checks").Rows(I).Item("ch7"), ds1.Tables("Checks").Rows(I).Item("ch8"),
                        ds1.Tables("Checks").Rows(I).Item("ch3"), days}
                    DGRD.Rows.Add(str)
                    N += 1
                End If
            Next
            Blinking()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub Showcustomsaccountbyquery()
        Try
            Dim N As Integer
            Dim firstDate As String, days As Integer
            Dim secondDate As Date
            DataGridView1.Rows.Clear()
            N = 1
            Dim ds1 As DataSet
            ds1 = New DataSet
            DataGridView1.Rows.Clear()
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "select IDCH, CH1, CH3, CH7, CH8 from Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "'  and CH17 ='" & False & "' and IDCH>'" & 0 & "' ORDER BY IDCH"
            End With
            adp = New SqlClient.SqlDataAdapter(strSQL)
            Consum.Open()
            adp.Fill(ds1, "Checks")
            If Me.BindingContext(ds1, "Checks").Count = 0 Then
                MsgBox("·« ÌÊÃœ »Ì«‰«  ·⁄—÷Â«", 64 + 524288, "⁄—÷ «·»Ì«‰« ")
                Exit Sub
            End If
            For I As Integer = 0 To ds1.Tables("Checks").Rows.Count - 1
                firstDate = ds1.Tables("Checks").Rows(I).Item("CH3")
                secondDate = CDate(firstDate)
                days = DateDiff(DateInterval.Day, ServerDateTime, secondDate)
                If days <= Val(ChecksIN) Then
                    If days <= Val(ChecksIN - 20) Then
                        DataGridView1.Columns(4).CellTemplate.Style.BackColor = Color.DarkRed
                        DataGridView1.Columns(4).CellTemplate.Style.ForeColor = Color.Yellow
                    End If
                    If days > Val(ChecksIN - 20) AndAlso days <= Val(ChecksIN - 10) Then
                        DataGridView1.Columns(4).CellTemplate.Style.BackColor = Color.HotPink
                        DataGridView1.Columns(4).CellTemplate.Style.ForeColor = Color.DarkBlue
                        DataGridView1.Columns(2).CellTemplate.Style.ForeColor = Color.Red
                    End If
                    If days > Val(ChecksIN - 10) Then
                        DataGridView1.Columns(4).CellTemplate.Style.BackColor = Color.Pink
                        DataGridView1.Columns(4).CellTemplate.Style.ForeColor = Color.DarkBlue
                        DataGridView1.Columns(2).CellTemplate.Style.ForeColor = Color.DarkBlue

                    End If
                    Dim str As String() = {ds1.Tables("Checks").Rows(I).Item("IDCH"), ds1.Tables("Checks").Rows(I).Item("CH1"),
                    ds1.Tables("Checks").Rows(I).Item("CH7"), ds1.Tables("Checks").Rows(I).Item("CH8"),
                    ds1.Tables("Checks").Rows(I).Item("CH3"), days}
                    DataGridView1.Rows.Add(str)
                    N += 1
                End If
            Next
            Blinking()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If xx >= 1 And xx <= Val(ChecksIN - 10) Then
            For I As Integer = 0 To Me.DGRD.Rows.Count - 1
                Dim row As DataGridViewRow = Me.DGRD.Rows(I)
                Dim Days As DataGridViewTextBoxCell = row.Cells(5)
                If Days.Value <= Val(ChecksIN - 25) Then
                    row.Cells(2).Style.ForeColor = Color.Yellow
                    row.Cells(2).Style.BackColor = Color.Red
                    row.Cells(5).Style.BackColor = Color.Yellow
                End If
            Next
            Dim Sound As System.IO.Stream = My.Resources.MouseHover
            If xx = 1 Then
                My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            End If
        End If
        If xx >= 21 And xx <= 50 Then
            For I As Integer = 0 To Me.DGRD.Rows.Count - 1
                Dim row As DataGridViewRow = Me.DGRD.Rows(I)

                Dim Days As DataGridViewTextBoxCell = row.Cells(5)
                If Days.Value <= Val(ChecksIN - 25) Then
                    row.Cells(2).Style.ForeColor = Color.Red
                    row.Cells(2).Style.BackColor = Color.Yellow
                    row.Cells(5).Style.BackColor = Color.Red
                End If
            Next
            Dim Sound As System.IO.Stream = My.Resources.MouseHover
            If xx = 22 Then
                My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            End If
        End If
        If xx >= 50 Then
            xx = 1
        End If

        xx += 1
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If xx >= 1 And xx <= 20 Then
            For I As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                Dim row As DataGridViewRow = Me.DataGridView1.Rows(I)
                Dim Days As DataGridViewTextBoxCell = row.Cells(5)
                If Days.Value <= 10 Then
                    row.Cells(2).Style.ForeColor = Color.Yellow
                    row.Cells(2).Style.BackColor = Color.Black
                    row.Cells(5).Style.BackColor = Color.Yellow
                End If
            Next
            Dim Sound As System.IO.Stream = My.Resources.MouseHover
            If xx = 1 Then
                My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            End If
        End If
        If xx >= 21 And xx <= 50 Then
            For I As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                Dim row As DataGridViewRow = Me.DataGridView1.Rows(I)

                Dim Days As DataGridViewTextBoxCell = row.Cells(5)
                If Days.Value <= 10 Then
                    row.Cells(2).Style.ForeColor = Color.Black
                    row.Cells(2).Style.BackColor = Color.Yellow
                    row.Cells(5).Style.BackColor = Color.Black
                End If
            Next
            Dim Sound As System.IO.Stream = My.Resources.MouseHover
            If xx = 22 Then
                My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            End If
        End If
        If xx >= 50 Then
            xx = 1
        End If
        xx += 1
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Timer1.Stop()
        Timer2.Stop()
        Me.Close()
    End Sub
    Private Sub DGRD_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGRD.CellDoubleClick
        Dim ds As New DataSet
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmChecks
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCH FROM Checks WHERE   CUser='" & CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCH", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Checks")
            f.BS.DataMember = "Checks"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCH", Me.DGRD.CurrentRow.Cells("Column4").Value)
            f.TB1 = Me.DGRD.CurrentRow.Cells("Column4").Value
            f.Show()
            f.DanLOd()
            f.BS.Position = index
            f.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim ds1 As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmChecks
        Try
            ds1.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCH FROM Checks WHERE  CUser='" & CUser & "' and CH15 ='" & False & "'", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds1.Clear()
            SqlDataAdapter1.Fill(ds1, "Checks")
            f.BS.DataMember = "Checks"
            f.BS.DataSource = ds1
            Dim index As Integer
            index = f.BS.Find("IDCH", Me.DataGridView1.CurrentRow.Cells("IDCH").Value)
            f.TB1 = Me.DataGridView1.CurrentRow.Cells("IDCH").Value
            f.Show()
            f.DanLOd()
            f.BS.Position = index
            f.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub
End Class