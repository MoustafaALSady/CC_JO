Imports System.Data.SqlClient

Public Class FormLASTchecks
    ReadOnly f As New FrmSuppliesA
<<<<<<< HEAD
    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.DoubleClick
        Try
            'Dim resault As Integer
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Try
            'Dim resault As Integer
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

            'resault = MessageBox.Show("سبنم حذف السجلات المحددة", "حذف السجلات المحددة", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            'If resault = vbYes Then
            If Me.DataGridView1.SelectedRows.Count > 0 Then
                For i As Integer = Me.DataGridView1.SelectedRows.Count - 1 To 0
                    Dim n As Integer
                    n = CInt(Me.DataGridView1.SelectedRows(i).Cells("CH1").Value)
                    Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
<<<<<<< HEAD
                    Dim CMD2 As New SqlCommand With {
=======
                    Dim CMD2 As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    Dim SQL2 As New SqlCommand("DELETE FROM Checks WHERE CH1=" & n, Consum)
                    CMD2.CommandText = SQL2.CommandText
                    CMD2.ExecuteNonQuery()
                Next
                Consum.Close()
            Else
                MessageBox.Show(" لايوجد سجلات محددة لاتمام عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            'Else
            'MessageBox.Show("تم ايقاف عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            'Exit Sub
            'End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
        End Try
    End Sub
    Private Sub Dgv1()


        Me.DataGridView1.AutoGenerateColumns = False
        'Me.DataGridView1.CurrentCell = Me.DataGridView1("CH", Me.DataGridView1.NewRowIndex)
        'Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Selected = True
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Sort(Me.DataGridView1.Columns("CH"), System.ComponentModel.ListSortDirection.Descending)
        Me.DataGridView1.Sort(Me.DataGridView1.Columns("CH"), System.ComponentModel.ListSortDirection.Ascending)

        Me.DataGridView1.ClearSelection()
        Dim nextRow As DataGridViewRow
        nextRow = Me.DataGridView1.Rows(0)
        Me.DataGridView1.Rows(0).Selected = True

        Me.DataGridView1.Rows.Add()
        Me.DataGridView1.CurrentRow.Cells("CH").Value = Me.DataGridView1.CurrentRow.Index + 1
        Me.DataGridView1.CurrentRow.Cells("CH1").Value = Me.TextBox1.Text
        Me.DataGridView1.CurrentRow.Cells("CH3").Value = Me.TextBox2.Text
        Me.DataGridView1.CurrentRow.Cells("CH7").Value = Me.TextBox3.Text
        Me.DataGridView1.CurrentRow.Cells("CH8").Value = Me.TextBox4.Text

    End Sub



<<<<<<< HEAD
    Public Sub FormLASTchecks_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Public Sub FormLASTchecks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'DataGridView1.AllowUserToAddRows = False
        Me.TextBox1.Text = CStr(Val(f.CHA1))
        Me.TextBox2.Text = CStr(Val(f.CHA3))
        Me.TextBox3.Text = CStr(Val(f.CHA7))
        Me.TextBox4.Text = CStr(Val(f.CHA8))
    End Sub

<<<<<<< HEAD
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP5.Click
        Dgv1()
    End Sub

    Private Sub FormLASTchecks_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Deactivate
        Me.Close()
    End Sub
    Private Sub FormLASTchecks_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Leave
=======
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP5.Click
        Dgv1()
    End Sub

    Private Sub FormLASTchecks_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Close()
    End Sub
    Private Sub FormLASTchecks_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Close()
    End Sub
End Class