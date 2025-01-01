Public Class SuppliersPay1

    Private Sub SuppliersPay1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        On Error Resume Next
        Dim a As Integer = FrmSuppliers1.TEXTDebit.Text
        Dim b As Integer = TextB1.Text
        If e.KeyCode = Keys.Enter Then
            If a > b Then
                MsgBox(" المدفوع اقل من الاجمالي لا يمكن الدفع الرجاء الدفع اكبر من الاجمالي " & Environment.NewLine & Form_beea.TextTotalPrice.Text & " > " & TextB1.Text.Trim, MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
            FrmSuppliers1.TEXTDebit.Text = Me.TextB1.Text.Trim
            Me.Tag = Me.TextB1.Text.ToString.Trim
            FrmSuppliers1.TEXTDebit.Text = Me.Tag
            Me.Close()
        End If
    End Sub

    Private Sub SuppliersPay1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub
End Class