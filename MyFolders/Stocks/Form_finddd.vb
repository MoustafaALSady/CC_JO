Imports System.Data.SqlClient
Public Class Form_finddd
    Private Sub Form_finddd_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            SearchBUTTON_Click(sender, e)
        End If
    End Sub
    Private Sub Texser_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Texser.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            SearchBUTTON_Click(sender, e)
        End If
    End Sub
    Private Sub Texser_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Texser.TextChanged

    End Sub
    Private Sub Form_finddd_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.Close()
        End If
    End Sub
    Private Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SearchBUTTON.Click
        Try
            Dim f As New FrmStocks1
            Dim Consum As New SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim dp As New SqlDataAdapter("SELECT SKITM4, SKITM5  FROM STOCKSITEMS WHERE CUser ='" & CUser & "'", Consum)
            Dim ds As New DataSet
            ds.Clear()
            dp.Fill(ds, "STOCKSITEMS")
            f.BS.DataMember = "STOCKSITEMS"
            f.BS.DataSource = ds
            Dim index As Integer
            If Me.RadioBSKITM4.Checked = True Then
                index = f.BS.Find("SKITM4", Trim(Me.Texser.Text))
                f.TB1 = Trim(Me.Texser.Text)
            ElseIf Me.RadioBSKITM5.Checked = True Then
                index = f.BS.Find("SKITM5", Trim(Me.Texser.Text))
                f.TB2 = Trim(Me.Texser.Text)

            End If



            f.Show()
            f.RowVisible = True
            f.Load_Click(sender, e)
            f.BS.Position = index
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
        End Try
    End Sub

    Private Sub Form_finddd_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub
End Class