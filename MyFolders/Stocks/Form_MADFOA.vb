﻿Public Class Form_MADFOA
    Private ReadOnly f As New Form_beea()
    Public clos As Boolean = False

    Public Sub New(ByVal Form_ As Form_beea)
        InitializeComponent()
        Me.f = Form_
    End Sub
<<<<<<< HEAD
    Private Sub Form_MADFOA_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
=======
    Private Sub Form_MADFOA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim a As Integer = Form_beea.TextTotalPrice.Text
        Dim b As Integer = Me.TextpaidUp.Text
        If e.KeyCode = Keys.Enter Then
            If a > b Then
                MsgBox(" المدفوع اقل من الاجمالي لا يمكن الدفع الرجاء الدفع اكبر من الاجمالي " & Environment.NewLine & Form_beea.TextTotalPrice.Text & " > " & TextpaidUp.Text.Trim, MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
            f.TextpaidUp.Text = Me.TextpaidUp.Text
            Me.clos = True
            Me.Close()
        End If
    End Sub
<<<<<<< HEAD
    Private Sub Form_MADFOA_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub Form_MADFOA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.TextpaidUp.Text = f.TextTotalPrice.Text
    End Sub
End Class