Public Class FrmStoreWornning
    ReadOnly ItDataset As New DataSet, Flt As String
    Dim adp As New SqlClient.SqlDataAdapter
    Dim WithEvents BS As New BindingSource
    Public Balance1 As Integer

    Private Sub FrmStoreWornning_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
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
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strSQL As New SqlClient.SqlCommand("", Consum)
        With strSQL
            .CommandText = "select * from Stockwarehouse  WHERE STK14 <='" & Balance1 & "' and  CUser='" & CUser & "'by STK25 asc;"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
        End With
        adp = New SqlClient.SqlDataAdapter(strSQL)
        Dim oCommandBuilder As New SqlClient.SqlCommandBuilder(adp)
        adp.Fill(ds, "Stockwarehouse")
        If Me.BindingContext(ds, "Stockwarehouse").Count = 0 Then
            MsgBox("áÇ íæÌÏ ÈíÇäÇÊ áÚÑÖåÇ", 64 + 524288, "ÚÑÖ ÇáÈíÇäÇÊ")
            Exit Sub
        End If
        For I As Integer = 0 To ds.Tables("Stockwarehouse").Rows.Count - 1
            Dim str As String() = {N, ds.Tables("Stockwarehouse").Rows(I).Item("STK25"),
            ds.Tables("Stockwarehouse").Rows(I).Item("STK7"),
            ds.Tables("Stockwarehouse").Rows(I).Item("STK14"),
            ds.Tables("Stockwarehouse").Rows(I).Item("Balance1")}
            DGRD.Rows.Add(str)
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
    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As EventArgs)
        Me.Close()
    End Sub
End Class