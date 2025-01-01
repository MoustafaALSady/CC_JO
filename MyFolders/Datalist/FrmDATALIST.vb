Public Class FrmDATALIST
    Private Sub FrmDATALIST_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmDLG_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        On Error Resume Next
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        FILLCOMBOBOX1("BASICDATA", "BDATA6", "CUser", CUser, Me.ListBox1)
        FILLCOMBOBOX1("BASICDATA", "BDATA7", "CUser", CUser, Me.ListBox2)
    End Sub
    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListBox1.DoubleClick, ListBox1.SelectedIndexChanged
        On Error Resume Next
        Me.Tag = Me.ListBox1.Text.ToString
        If My.Forms.FrmCUSTOMER11 Is Nothing = False Then
            My.Forms.FrmCUSTOMER11.DataGridView1.CurrentRow.Cells(4).Value = Me.Tag
        End If
        Me.Hide()
    End Sub
    Private Sub ListBox2_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListBox2.DoubleClick
        On Error Resume Next
        Me.Tag = Me.ListBox2.Text.ToString
        If My.Forms.FrmCUSTOMER11 Is Nothing = False Then
            My.Forms.FrmCUSTOMER11.DataGridView2.CurrentRow.Cells(4).Value = Me.Tag
        End If
        Me.Hide()
    End Sub
End Class