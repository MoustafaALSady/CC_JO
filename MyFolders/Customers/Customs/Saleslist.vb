
Imports System.Data.SqlClient
Public Class Saleslist
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim Adp As New SqlDataAdapter
    Private Sub Saleslist_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
    End Sub
    Private Sub Saleslist_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
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
        Dim f As New FrmCustomersA
        Try
            If Me.CheckBox1.Checked = True Then
                Cash = True
            Else
                Cash = False
            End If
            f.TB1 = Trim(Me.DataGridView1.Item("SLS2", Me.DataGridView1.CurrentRow.Index).Value)
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
                Dim Consum As New SqlConnection(ModuleGeneral.constring)
                Dim ds As DataSet
                ds = New DataSet
                DataGridView1.Rows.Clear()
                Dim strSQL As New SqlCommand("", Consum)
                With strSQL

                    If Trim(TextBox1.Text) = "*" Then
                        .CommandText = "select SLS1,SLS2 from SALES  WHERE   CUser='" & CUser & "'order by SLS2 asc;"
                    Else
                        .CommandText = "SELECT SLS1,SLS2 FROM SALES where SLS2 like'" & Trim(TextBox1.Text) & "%'" & " and CUser='" & CUser & "'order by SLS2"
                    End If
                End With
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Adp = New SqlDataAdapter(strSQL)
                Adp.Fill(ds, "SALES")
                If Me.BindingContext(ds, "SALES").Count = 0 Then
                    MsgBox("·« ÌÊÃœ »Ì«‰«  ·⁄—÷Â«", 64 + 524288, "⁄—÷ «·»Ì«‰« ")
                    Exit Sub
                End If
                For I As Integer = 0 To ds.Tables("SALES").Rows.Count - 1
                    Dim row As String() = {ds.Tables("SALES").Rows(I).Item("SLS1"),
                    ds.Tables("SALES").Rows(I).Item("SLS2")}
                    DataGridView1.Rows.Add(row)
                Next
                '/**
            End If
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
