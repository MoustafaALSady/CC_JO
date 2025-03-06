Public Class FrmExpire
    Public xx As Integer = 0
    ReadOnly InvDataset As New DataSet, Flt As String
    Dim adp As New SqlClient.SqlDataAdapter

<<<<<<< HEAD
    Private Sub FrmExpire_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        Timer1.Enabled = False
    End Sub
    Private Sub FrmExpire_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmExpire_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Timer1.Enabled = False
    End Sub
    Private Sub FrmExpire_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        'FinishedItems
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.Label1.Text = CUser
        Dim N As Integer
        Dim firstDate As String, days As Integer
        Dim secondDate As Date
        DGRD.Rows.Clear()
        N = 1
        Dim ds As DataSet
        ds = New DataSet
        DGRD.Rows.Clear()
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strSQL As New SqlClient.SqlCommand("", Consum)
        With strSQL
            .CommandText = "SELECT STK1, STK7, STK25, IT_DATEP, IT_DATEEX, USERNAME, CUser, COUser, da, ne, da1, ne1 FROM STOCKS  WHERE  CUser='" & CUser & "' and STK13>'" & 0 & "' ORDER BY STK1"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
        End With
        adp = New SqlClient.SqlDataAdapter(strSQL)
        Dim oCommandBuilder As New SqlClient.SqlCommandBuilder(adp)
        adp.Fill(ds, "STOCKS")
        If Me.BindingContext(ds, "STOCKS").Count = 0 Then
            MsgBox("·« ÌÊÃœ »Ì«‰«  ·⁄—÷Â«", 64 + 524288, "⁄—÷ «·»Ì«‰« ")
            Exit Sub
        End If
        For I As Integer = 0 To ds.Tables("STOCKS").Rows.Count - 1
            firstDate = ds.Tables("STOCKS").Rows(I).Item("IT_DATEEX")
            secondDate = CDate(firstDate)
            days = DateDiff(DateInterval.Day, ServerDateTime, secondDate)
            If days <= Val(CategoriesIN) Then
                If days <= Val(CategoriesIN - 20) Then
                    DGRD.Columns(2).CellTemplate.Style.BackColor = Color.SteelBlue
                    DGRD.Columns(2).CellTemplate.Style.ForeColor = Color.Wheat
                End If
                If days > Val(CategoriesIN - 20) AndAlso days <= Val(CategoriesIN - 10) Then
                    DGRD.Columns(2).CellTemplate.Style.BackColor = Color.Orange
                    DGRD.Columns(2).CellTemplate.Style.ForeColor = Color.Wheat
                End If
                If days > Val(CategoriesIN - 10) Then
                    DGRD.Columns(2).CellTemplate.Style.BackColor = Color.BurlyWood
                    DGRD.Columns(2).CellTemplate.Style.ForeColor = Color.White
                End If
                Dim str As String() = {N,
                ds.Tables("STOCKS").Rows(I).Item("STK25"), ds.Tables("STOCKS").Rows(I).Item("STK7"),
                ds.Tables("STOCKS").Rows(I).Item("IT_DateEx"), days}
                DGRD.Rows.Add(str)
                N += 1
            End If
        Next
        Blinking()
        Consum.Close()
    End Sub
    Private Sub Blinking()

        Dim I As Integer
        For I = 0 To Me.DGRD.Rows.Count - 1
            Dim row As DataGridViewRow = Me.DGRD.Rows(I)
            Dim Days As DataGridViewTextBoxCell = row.Cells("Col_Days")
            If Days.Value <= Val(CategoriesIN - 20) Then
                Timer1.Enabled = True
                Timer1.Interval = 1
            End If
        Next
    End Sub
<<<<<<< HEAD
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timer1.Tick
=======
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If xx >= 1 And xx <= Val(CategoriesIN - 10) Then
            For I As Integer = 0 To Me.DGRD.Rows.Count - 1
                Dim row As DataGridViewRow = Me.DGRD.Rows(I)
                Dim Days As DataGridViewTextBoxCell = row.Cells("Col_Days")
                If Days.Value <= Val(CategoriesIN - 20) Then
                    row.Cells(2).Style.ForeColor = Color.Wheat
                    row.Cells(2).Style.BackColor = Color.SteelBlue
                    row.Cells("Col_Days").Style.BackColor = Color.SteelBlue
                End If
            Next
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.MouseHover
=======
            Dim Sound As System.IO.Stream = My.Resources.MouseHover
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

            If xx = 1 Then
                My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            End If
        End If
        If xx >= 21 And xx <= 50 Then

            For I As Integer = 0 To Me.DGRD.Rows.Count - 1
                Dim row As DataGridViewRow = Me.DGRD.Rows(I)
                'row.Cells("Col_Days").Style.BackColor = Color.SteelBlue
                Dim Days As DataGridViewTextBoxCell = row.Cells("Col_Days")
                If Days.Value <= 10 Then
                    row.Cells(2).Style.BackColor = Color.SteelBlue
                    row.Cells(2).Style.ForeColor = Color.Wheat
                    row.Cells("Col_Days").Style.BackColor = Color.Red
                End If
            Next
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.NoAccept
=======
            Dim Sound As System.IO.Stream = My.Resources.NoAccept
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If xx = 22 Then
                My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            End If
        End If
        If xx >= 50 Then
            xx = 1
        End If

        xx += 1
    End Sub



    Private Sub DGRD_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGRD.CellContentDoubleClick
        Dim f As New FrmStocks2
        Try
            f.TB1 = Trim(Me.DGRD.CurrentRow.Cells(1).Value)
            f.Show()
            f.Load_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class