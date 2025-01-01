Public Class Formsignature1
    ReadOnly DrawU As Boolean = False
    ReadOnly Draw As Boolean

    Dim DOWN As Boolean = False
    Dim MYbrush = Brushes.Black
    ReadOnly convert As Object
    Private Sub Formsignature1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub PBoxSignature_MouseDown(sender As Object, e As MouseEventArgs) Handles pBoxSignature.MouseDown
        DOWN = True
    End Sub

    Private Sub PBoxSignature_MouseUp(sender As Object, e As MouseEventArgs) Handles pBoxSignature.MouseUp
        DOWN = False
    End Sub

    Private Sub PBoxSignature_MouseMove(sender As Object, e As MouseEventArgs) Handles pBoxSignature.MouseMove
        If DOWN = True Then
            pBoxSignature.CreateGraphics.FillEllipse(MYbrush, e.X, e.Y, 2, 2)
        End If

        If Me.RGA1.SelectedIndex = 1 Then
            pBoxSignature.CreateGraphics.FillEllipse(MYbrush, e.X, e.Y, 2, 2)
        ElseIf Me.RGA1.SelectedIndex = 2 Then
            pBoxSignature.CreateGraphics.FillEllipse(MYbrush, e.X, e.Y, 3, 3)
        ElseIf Me.RGA1.SelectedIndex = 3 Then
            pBoxSignature.CreateGraphics.FillEllipse(MYbrush, e.X, e.Y, 4, 4)
        Else
            pBoxSignature.CreateGraphics.FillEllipse(MYbrush, e.X, e.Y, 5, 5)
        End If




    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        MYbrush = Brushes.Black
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        MYbrush = Brushes.White
    End Sub
End Class