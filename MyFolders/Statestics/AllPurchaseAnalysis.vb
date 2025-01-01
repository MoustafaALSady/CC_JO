
Imports System.Data.SqlClient
Public Class AllPurchaseAnalysis
    Dim VTotal, VOther, VDiscount, VNet As Double
    Dim Adp As New SqlClient.SqlDataAdapter
    Private Sub MTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            If Not IsDate(MTextBox1.Text) Then
                MsgBox("ÊÇÑíÎ ÛíÑ ÕÇáÎ")
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
    Private Sub MTextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strSQL As New SqlCommand("", Consum) With {
            .CommandText = "select BUY1, BUY3, BUY5, BUY14 from BUYS  WHERE deleted ='" & False & "' and CUser='" & CUser & "'order by BUY1"
        }
        Adp = New SqlClient.SqlDataAdapter(strSQL)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp.Fill(ds, "BUYS")

        If Me.BindingContext(ds, "BUYS").Count = 0 Then
            MsgBox("áÇ íæÌÏ ÈíÇäÇÊ áÚÑÖåÇ", 64 + 524288, "ÚÑÖ ÇáÈíÇäÇÊ")
            Exit Sub
        End If
        For I As Integer = 0 To ds.Tables("BUYS").Rows.Count - 1
            If ds.Tables("BUYS").Rows(I).Item("BUY3") >= Cd1 And _
            ds.Tables("BUYS").Rows(I).Item("BUY3") <= Cd2 Then

                Dim total As Double = _
                ds.Tables("BUYS").Rows(I).Item("BUY14")

                Dim row As String() = {ds.Tables("BUYS").Rows(I).Item("BUY1"), _
                     ds.Tables("BUYS").Rows(I).Item("BUY3"), _
                     ds.Tables("BUYS").Rows(I).Item("BUY5"), _
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
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Dgrd.Rows.Clear()
        MTextBox1.Focus()
        Me.Close()
    End Sub
    Private Sub AllPurchaseAnalysis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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