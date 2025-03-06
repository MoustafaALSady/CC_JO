
Imports System.Data.SqlClient
Public Class CridtParchaseAnalysis
    Dim VTotal, VOther, VDiscount, VNet As Double
<<<<<<< HEAD
    Dim Adp As New SqlDataAdapter

    Private Sub MTextBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Dim Adp As New SqlClient.SqlDataAdapter

    Private Sub MTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Asc(e.KeyChar) = 13 Then
            If Not IsDate(MTextBox1.Text) Then
                MsgBox(" «—ÌŒ €Ì— ’«·Œ")
                MTextBox1.Focus()
            Else
                Dim monthes As Double
                Dim SecondDate As Date
                SecondDate = CDate(MTextBox1.Text)
                monthes = 1
                MTextBox2.Text = DateAdd(DateInterval.Month, monthes, SecondDate)
                MTextBox2.Focus()
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub MTextBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub MTextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Asc(e.KeyChar) = 13 Then
            FillGrid()
        End If
    End Sub
    Private Sub FillGrid()
        VTotal = 0
        VOther = 0
        VDiscount = 0
        VNet = 0
        Dim Cd1, Cd2 As Date, F As Boolean = False
        Cd1 = "#" + MTextBox1.Text + "#"
        Cd2 = "#" + MTextBox2.Text + "#"

        Dim ds As DataSet
        ds = New DataSet
        Dgrd.Rows.Clear()
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Using strSQL As New SqlCommand("", Consum) With {
            .CommandText = "select BUY1, BUY3, BUY5, BUY14 from BUYS where deleted ='" & F & "' and TYPE_CASH ='" & F & "' and CUser='" & CUser & "' order by BUY1"
        }
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
<<<<<<< HEAD
            Adp = New SqlDataAdapter(strSQL)
=======
            Adp = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        End Using
        Adp.Fill(ds, "BUYS")
        If Me.BindingContext(ds, "BUYS").Count = 0 Then
            MsgBox("·« ÌÊÃœ »Ì«‰«  ·⁄—÷Â«", 64 + 524288, "⁄—÷ «·»Ì«‰« ")
            Exit Sub
        End If

        For I As Integer = 0 To ds.Tables("BUYS").Rows.Count - 1

            If ds.Tables("BUYS").Rows(I).Item("BUY3") >= Cd1 And _
            ds.Tables("BUYS").Rows(I).Item("BUY3") <= Cd2 Then
                Dim total As Double = _
                ds.Tables("BUYS").Rows(I).Item("BUY14")
                Dim row As String() =
                      {ds.Tables("BUYS").Rows(I).Item("BUY1"),
                      ds.Tables("BUYS").Rows(I).Item("BUY3"),
                      ds.Tables("BUYS").Rows(I).Item("BUY5"),
                      total}
                Dgrd.Rows.Add(row)
            End If
        Next
        On Error Resume Next

        For I As Integer = 0 To Dgrd.Rows.Count - 2
            Dim row As DataGridViewRow = Dgrd.Rows(I)
            Dim VSalse As DataGridViewTextBoxCell = row.Cells(3)
            VTotal += VSalse.Value
        Next
        TEXTSalesTall.Text = VTotal
        Consum.Close()
    End Sub
<<<<<<< HEAD
    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CmdExit.Click
=======
    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dgrd.Rows.Clear()
        MTextBox1.Focus()
        Me.Close()
    End Sub
<<<<<<< HEAD
    Private Sub CridtParchaseAnalysis_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub CridtParchaseAnalysis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        MTextBox1.Focus()
    End Sub
End Class