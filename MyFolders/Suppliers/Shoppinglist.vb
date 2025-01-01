Public Class Shoppinglist
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim Adp As New SqlClient.SqlDataAdapter
    Private Sub Shoppinglist_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
    End Sub
    Private Sub Shoppinglist_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        If Consum.State = ConnectionState.Closed Then Consum.Open()
        Consum.Close()
    End Sub
    Private Sub Shoppinglist_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        TextBox1.Focus()
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim f As New FrmSuppliesA
        Try
            If Me.CheckBox1.Checked = True Then
                Cash = True
            Else
                Cash = False
            End If
            f.TB1 = Trim(Me.DataGridView1.CurrentRow.Cells("BUY2").Value)
            f.Show()
            f.DanLOd()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If TestNet = False Then
                    MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                    Exit Sub
                End If
                If BS.Count = 0 Then Beep() : Exit Sub
                If TextBox1.Text.Trim = "" Then
                    MsgBox("«·—Ã«¡ «œŒ«· ﬁÌ„… ··»ÕÀ ⁄‰Â«", 16 + 524288, "«·»ÕÀ ⁄‰ ﬁÌ„…")
                    TextBox1.Text = ""
                    TextBox1.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextBox1.TextChanged
        Try
            If Trim(TextBox1.Text) <> "" Then
                Dim ds As DataSet
                ds = New DataSet
                DataGridView1.Rows.Clear()
                Dim Consum As New SqlClient.SqlConnection(constring)
                Dim strSQL As New SqlClient.SqlCommand("", Consum)
                With strSQL
                    If Trim(TextBox1.Text) = "*" Then
                        .CommandText = "select BUY1,BUY2 from BUYS  WHERE  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'order by BUY2 asc;"
                    Else
                        .CommandText = "SELECT BUY1,BUY2 FROM BUYS WHERE  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and BUY2 like'" & Trim(TextBox1.Text) & "%'"
                    End If
                End With
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Adp = New SqlClient.SqlDataAdapter(strSQL)
                Adp.Fill(ds, "BUYS")
                If Me.BindingContext(ds, "BUYS").Count = 0 Then
                    MsgBox("·« ÌÊÃœ »Ì«‰«  ·⁄—÷Â«", 64 + 524288, "⁄—÷ «·»Ì«‰« ")
                    Exit Sub
                End If
                For I As Integer = 0 To ds.Tables("BUYS").Rows.Count - 1
                    Dim row As String() = {ds.Tables("BUYS").Rows(I).Item("BUY1"),
                    ds.Tables("BUYS").Rows(I).Item("BUY2")}
                    DataGridView1.Rows.Add(row)
                Next
            End If
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

End Class
