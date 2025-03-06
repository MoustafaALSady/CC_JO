Option Explicit Off

Imports System.Data.SqlClient
Public Class Loans3
<<<<<<< HEAD
    Inherits Form
=======
    Inherits System.Windows.Forms.Form
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public WithEvents BS As New BindingSource
    Public SqlDataAdapter1 As SqlDataAdapter
    ReadOnly ds As New DataSet
    Dim xxk As Double
<<<<<<< HEAD
    Private Sub Loans3_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub Loans3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub
<<<<<<< HEAD
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextTBNK1.TextChanged
        Try
            Dim f As New Loans2
            Me.DataGridView1.AutoGenerateColumns = False
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextTBNK1.TextChanged
        Try
            Dim f As New Loans2
            Me.DataGridView1.AutoGenerateColumns = False
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  TBNK4,TBNK6, TBNK8, TBNK9, TBNK10, TBNK11, TBNK22, TBNK23 FROM PTRANSACTION  WHERE  CUser='" & CUser & "' and TBNK1 ='" & Me.TextTBNK1.Text & "'"
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            SqlDataAdapter1 = New SqlDataAdapter(strSQL)
            Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "LoansPa")
            BS.DataSource = ds
            BS.DataMember = "LoansPa"
            Consum.Close()
            DataGridView1.DataSource = BS
            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            Dim Column As New DataGridViewCheckBoxColumn
            With Me.DataGridView1
                .RowsDefaultCellStyle.BackColor = Color.Bisque
                .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
                .DataBindings.Clear()
                .DataSource = BS
                .AutoGenerateColumns = False
            End With


            For ri As Integer = 0 To DataGridView1.Rows.Count - 1
                xxk += CDbl(DataGridView1.Rows(ri).Cells("co1").Value)
            Next
            Me.TextTotalPayments.Text = Val(xxk)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class