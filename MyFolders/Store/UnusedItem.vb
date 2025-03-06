Imports System.Data.SqlClient
Public Class UnusedItem
    Public Pr, Pr2 As Double
    ReadOnly ItDataset As New DataSet, Flt As String
<<<<<<< HEAD
    Dim adp As New SqlDataAdapter
    Private Sub FrmStoreWornning_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Dim adp As New SqlClient.SqlDataAdapter
    Private Sub FrmStoreWornning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Dim N As Integer
        DGRD.Rows.Clear()
        N = 1
        Dim ds As DataSet
        ds = New DataSet
        DGRD.Rows.Clear()
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim strSQL As New SqlCommand("select * from Stockwarehouse where Balance1 > 0 order by STK25 asc;", Consum)
        With strSQL
            .CommandText = "select * from Stockwarehouse  WHERE Balance1 >'" & 0 & "' and  CUser='" & CUser & "' order by STK25"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
        End With
<<<<<<< HEAD
        adp = New SqlDataAdapter(strSQL)
        Dim oCommandBuilder As New SqlCommandBuilder(adp)
=======
        adp = New SqlClient.SqlDataAdapter(strSQL)
        Dim oCommandBuilder As New SqlClient.SqlCommandBuilder(adp)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        adp.Fill(ds, "Stockwarehouse")
        If Me.BindingContext(ds, "Stockwarehouse").Count = 0 Then
            MsgBox("·« ÌÊÃœ »Ì«‰«  ·⁄—÷Â«", 64 + 524288, "⁄—÷ «·»Ì«‰« ")
            Exit Sub
        End If
        For I As Integer = 0 To ds.Tables("Stockwarehouse").Rows.Count - 1
            Pr = ds.Tables("Stockwarehouse").Rows(I).Item("Balance1") * 10 / 100
            Pr2 = Math.Round(ds.Tables("Stockwarehouse").Rows(I).Item("Outside") / ds.Tables("Stockwarehouse").Rows(I).Item("Balance1"), 2)
            If ds.Tables("Stockwarehouse").Rows(I).Item("Outside") <= Pr Then

                Dim str As String() = {N,
                ds.Tables("Stockwarehouse").Rows(I).Item("STK25"), ds.Tables("Stockwarehouse").Rows(I).Item("STK7"),
                Pr2 & "%", ds.Tables("Stockwarehouse").Rows(I).Item("Balance1")}
                DGRD.Rows.Add(str)
            End If
            N += 1
        Next
        Consum.Close()
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
<<<<<<< HEAD
    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As EventArgs)
=======
    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Close()
    End Sub
End Class