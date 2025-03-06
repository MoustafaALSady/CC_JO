
Imports System.Data.SqlClient
Public Class Saleslist
<<<<<<< HEAD
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim Adp As New SqlDataAdapter
    Private Sub Saleslist_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
    End Sub
    Private Sub Saleslist_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim Adp As New SqlClient.SqlDataAdapter
    Private Sub Saleslist_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
    End Sub
    Private Sub Saleslist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        TextBox1.Focus()
    End Sub
<<<<<<< HEAD
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
=======
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox1.KeyPress
=======
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextBox1.TextChanged
=======
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Trim(TextBox1.Text) <> "" Then
                Dim Consum As New SqlConnection(ModuleGeneral.constring)
                Dim ds As DataSet
                ds = New DataSet
                DataGridView1.Rows.Clear()
<<<<<<< HEAD
                Dim strSQL As New SqlCommand("", Consum)
=======
                Dim strSQL As New SqlClient.SqlCommand("", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                With strSQL

                    If Trim(TextBox1.Text) = "*" Then
                        .CommandText = "select SLS1,SLS2 from SALES  WHERE   CUser='" & CUser & "'order by SLS2 asc;"
                    Else
                        .CommandText = "SELECT SLS1,SLS2 FROM SALES where SLS2 like'" & Trim(TextBox1.Text) & "%'" & " and CUser='" & CUser & "'order by SLS2"
                    End If
                End With
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
<<<<<<< HEAD
                Adp = New SqlDataAdapter(strSQL)
=======
                Adp = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
