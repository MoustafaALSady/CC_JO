<<<<<<< HEAD
﻿Imports System.ComponentModel
Imports DevExpress.Utils.Win
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.ViewInfo

Public Class Calculatorform


    Private Sub CalcEdit1_Popup(sender As Object, e As EventArgs) Handles CalcEdit1.Popup
        'Dim buttons As Control.ControlCollection = DirectCast(sender, IPopupControl).PopupWindow.Controls
        'DirectCast(sender, IPopupControl).PopupWindow.Width -= 250
        'DirectCast(sender, IPopupControl).PopupWindow.Height -= 100
        'For i As Integer = 0 To buttons.Count - 1
        '    If i < 6 Or i = 13 Or i > 17 Then
        '        buttons(i).Hide()
        '    Else
        '        Dim point = buttons(i).Location
        '        point.Offset(-90, -70)
        '        buttons(i).Location = point
        '    End If
        'Next i
    End Sub
    Private Sub CalcEdit1_QueryCloseUp(sender As Object, e As CancelEventArgs) Handles CalcEdit1.QueryCloseUp
        'e.Cancel = True
    End Sub

    Private Sub CalcEdit1_CloseUp(sender As Object, e As CloseUpEventArgs) Handles CalcEdit1.CloseUp
        'e.AcceptValue = Not selectionCancelled

    End Sub

    Private Sub CalcEdit1_MouseDown(sender As Object, e As MouseEventArgs) Handles CalcEdit1.MouseDown

        CalcEdit1.ShowPopup()



    End Sub

    Private Sub Calculatorform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'DevExpress.XtraEditors.WindowsFormsSettings.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.True

        CalcEdit1.ShowPopup()
    End Sub

    Private Sub Calculatorform_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        CalcEdit1.ShowPopup()
    End Sub

    Private Sub Calculatorform_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        CalcEdit1.ShowPopup()
    End Sub

    Private Sub Calculatorform_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        CalcEdit1.ShowPopup()
    End Sub

    Private Sub Calculatorform_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        CalcEdit1.ShowPopup()
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp

        CalcEdit1.ShowPopup()

    End Sub

    'Private Sub Calculatorform_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
    '    CalcEdit1.ShowPopup()
    'End Sub

    'Private Sub Calculatorform_Move(sender As Object, e As EventArgs) Handles Me.Move
    '    CalcEdit1.ShowPopup()
    'End Sub

    'Private Sub Calculatorform_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
    '    CalcEdit1.ShowPopup()
    'End Sub

    Private Sub Calculatorform_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        CalcEdit1.ShowPopup()
    End Sub

    Private Sub Calculatorform_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CalcEdit1.ShowPopup()
    End Sub

=======
﻿Public Class Calculatorform
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

End Class