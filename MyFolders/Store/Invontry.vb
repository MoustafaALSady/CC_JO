Imports System.Data.SqlClient
Public Class Invontry
    ReadOnly ItDataset As New DataSet, Flt As String
    Dim adp As New SqlDataAdapter
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        Me.Close()
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextBox1.TextChanged
        'On Error Resume Next
        'Try
        If Trim(TextBox1.Text) <> "" Then
            DGRD.Rows.Clear()
            Dim ds As DataSet
            ds = New DataSet
            DGRD.Rows.Clear()
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL

                If Trim(TextBox1.Text) = "*" Then
                    .CommandText = "select * from Stockwarehouse  WHERE   CUser='" & CUser & "'order by STK25 asc;"
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                Else
                    .CommandText = "SELECT * FROM Stockwarehouse WHERE CUser ='" & CUser & "'  and STK25 like'" & Trim(Me.TextBox1.Text) & "%'" & "or STK7 like'" & Trim(Me.TextBox1.Text) & "%'order by STK25"
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                End If
            End With
            Dim builder63 As New SqlCommandBuilder(adp)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            adp = New SqlDataAdapter(strSQL)
            Dim oCommandBuilder As New SqlCommandBuilder(adp)
            adp.Fill(ds, "Stockwarehouse")
            If Me.BindingContext(ds, "Stockwarehouse").Count = 0 Then
                MsgBox("·« ÌÊÃœ »Ì«‰«  ·⁄—÷Â«", 64 + 524288, "⁄—÷ «·»Ì«‰« ")
                Exit Sub
            End If
            For I As Integer = 0 To ds.Tables("Stockwarehouse").Rows.Count - 1
                Dim row As String() = {ds.Tables("Stockwarehouse").Rows(I).Item("STK25"),
                ds.Tables("Stockwarehouse").Rows(I).Item("STK7"),
                ds.Tables("Stockwarehouse").Rows(I).Item("balanceformer"),
                ds.Tables("Stockwarehouse").Rows(I).Item("Inside"),
                ds.Tables("Stockwarehouse").Rows(I).Item("Outside"),
                ds.Tables("Stockwarehouse").Rows(I).Item("Balance1"),
                ds.Tables("Stockwarehouse").Rows(I).Item("IT_DATEP"),
                ds.Tables("Stockwarehouse").Rows(I).Item("IT_DATEEX")}
                DGRD.Rows.Add(row)
            Next
            '/**
        End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        Consum.Close()
    End Sub
    Private Sub DGRD_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGRD.CellContentDoubleClick
        Dim f As New FrmStocks2
        Try
            f.TB1 = Trim(Me.DGRD.CurrentRow.Cells(0).Value)
            f.Show()
            f.Load_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Invontry_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        TextBox1.Focus()
    End Sub
End Class