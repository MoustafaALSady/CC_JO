Public Class ListRestrictions
    Inherits Form
    Dim adp As New SqlClient.SqlDataAdapter
    Public WithEvents BS As New BindingSource
    Private Sub Listrestrictions_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        Consum.Close()
    End Sub
    Private Sub Listrestrictions_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.BackgroundImage = img
        TextBox1.Focus()
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim f As New FrmDailyrestrictions
        Try
            f.TB1 = Trim(Me.DataGridView1.Item("MOV2", Me.DataGridView1.CurrentRow.Index).Value)
            f.Show()
            f.Load_Click(sender, e)
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
                DataGridView1.Rows.Clear()
                Dim ds As DataSet
                ds = New DataSet
                DataGridView1.Rows.Clear()
                Dim Consum As New SqlClient.SqlConnection(constring)
                Dim strSQL As New SqlClient.SqlCommand("", Consum)
                With strSQL
                    If Trim(TextBox1.Text) = "*" Then
                        .CommandText = "select MOV1 , MOV2  from MOVES  WHERE   CUser='" & CUser & "'order by MOV2 asc;"
                    Else
                        .CommandText = "SELECT MOV1 , MOV2  FROM MOVES where MOV2 like'" & Trim(TextBox1.Text) & "%'" & " and CUser='" & CUser & "'order by MOV2"
                    End If
                End With
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                adp = New SqlClient.SqlDataAdapter(strSQL)
                adp.Fill(ds, "MOVES")

                If Me.BindingContext(ds, "MOVES").Count = 0 Then
                    MsgBox("·« ÌÊÃœ »Ì«‰«  ·⁄—÷Â«", 64 + 524288, "⁄—÷ «·»Ì«‰« ")
                    Exit Sub
                End If
                Consum.Close()
                For I As Integer = 0 To ds.Tables("MOVES").Rows.Count - 1
                    Dim row As String() = {ds.Tables("MOVES").Rows(I).Item("MOV1"),
                    ds.Tables("MOVES").Rows(I).Item("MOV2")}
                    DataGridView1.Rows.Add(row)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

End Class
