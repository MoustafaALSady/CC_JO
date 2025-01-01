Option Explicit Off

Public Class Mane
    'Public CASH As Boolean = False
    Private Sub Mane_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub Mane_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Dim Frm As New FrmBanks5
        Dim dt1 As DateTime = ServerDateTime.ToString("yyyy-MM-dd")
    End Sub
    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                If Cash = True Then
                    Dim dt1 As DateTime = ServerDateTime.ToString("yyyy-MM-dd")
                    'Me.TextPermissionNumber.Focus()
                    Me.Close()
                Else
                    Dim dt1 As DateTime = ServerDateTime.ToString("yyyy-MM-dd")
                    Me.TextPermissionNumber.Focus()
                End If
        End Select
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        On Error Resume Next
        Dim Frm As New FrmBanks5
        Dim Frm1 As New FrmEmpsolf
        Dim Frm2 As New FrmJO
        'If CASH = True Then
        Frm.TEXTCredit.Enabled = True
        Frm.DateMovementHistory.Enabled = True
        Frm.TEXTCredit.Text = Me.TEXTValues.EditValue


        'ElseIf Frm1.Visible = True Then
        Frm1.TEXTCredit.Enabled = True
        Frm1.DateMovementHistory.Enabled = True
        Frm1.TEXTCredit.Text = Me.TEXTValues.EditValue
        Frm1.TEXTCredit.Text = Me.TEXTValues.EditValue
        'Me.Tag = Me.TextBox1.Text
        'Frm1.TEXT5.Text = Me.Tag

        'ElseIf Frm2.Visible = True Then
        Frm2.TEXTCredit.Enabled = True
        Frm2.DateMovementHistory.Enabled = True
        Frm2.TEXTCredit.Text = Me.TEXTValues.EditValue

    End Sub

    Private Sub TextBox3_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextPermissionNumber.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim dt1 As DateTime = ServerDateTime.ToString("yyyy-MM-dd")
            Me.Tag = Me.TEXTValues.EditValue

            FrmEmpsolf.TEXTCredit.Text = Me.TEXTValues.EditValue
            Me.Tag = Me.TEXTValues.EditValue
            FrmEmpsolf.TEXTCredit.Text = Me.Tag

            FrmBanks5.TEXTCredit.Text = Me.TEXTValues.EditValue
            Me.Tag = Me.TEXTValues.EditValue
            FrmBanks5.TEXTCredit.Text = Me.Tag

            FrmJO.TEXTCredit.Text = Me.TEXTValues.EditValue
            Me.Tag = Me.TEXTValues.EditValue
            FrmJO.TEXTCredit.Text = Me.Tag
            Me.Close()
        End If
    End Sub
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextPermissionNumber.TextChanged
        On Error Resume Next
        Dim Frm As New FrmBanks5
        Dim Frm1 As New FrmEmpsolf
        Dim Frm2 As New FrmJO
        'If Frm.Visible = True Then
        Frm.TEXTCredit.Enabled = True
        Frm.DateMovementHistory.Enabled = True
        Frm.TEXTCredit.Text = Me.TEXTValues.EditValue

        'ElseIf Frm1.Visible = True Then
        Frm1.TEXTCredit.Enabled = True
        Frm1.DateMovementHistory.Enabled = True
        Frm1.TEXTCredit.Text = Me.TEXTValues.EditValue

        Frm1.TEXTCredit.Text = Me.TEXTValues.EditValue
        'Me.Tag = Me.TextBox1.Text
        'frmempsolf.TEXT5.Text = Me.Tag
        'ElseIf Frm2.Visible = True Then
        Frm2.TEXTCredit.Enabled = True
        Frm2.DateMovementHistory.Enabled = True
        Frm2.TEXTCredit.Text = Me.TEXTValues.EditValue

        'End If
    End Sub

End Class