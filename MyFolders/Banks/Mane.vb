Option Explicit Off

Public Class Mane
    'Public CASH As Boolean = False
<<<<<<< HEAD
    Private Sub Mane_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub Mane_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
    Private Sub Mane_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub Mane_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
=======
    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTValues.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs)
=======
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEXTValues.TextChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim Frm As New FrmBanks5
        Dim Frm1 As New FrmEmpsolf
        Dim Frm2 As New FrmJO
        'If CASH = True Then
        Frm.TEXTCredit.Enabled = True
        Frm.DateMovementHistory.Enabled = True
<<<<<<< HEAD
        Frm.TEXTCredit.Text = Me.TEXTValues.EditValue
=======
        Frm.TEXTCredit.Text = Me.TEXTValues.Text
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c


        'ElseIf Frm1.Visible = True Then
        Frm1.TEXTCredit.Enabled = True
        Frm1.DateMovementHistory.Enabled = True
<<<<<<< HEAD
        Frm1.TEXTCredit.Text = Me.TEXTValues.EditValue
        Frm1.TEXTCredit.Text = Me.TEXTValues.EditValue
=======
        Frm1.TEXTCredit.Text = Me.TEXTValues.Text
        Frm1.TEXTCredit.Text = Me.TEXTValues.Text
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'Me.Tag = Me.TextBox1.Text
        'Frm1.TEXT5.Text = Me.Tag

        'ElseIf Frm2.Visible = True Then
        Frm2.TEXTCredit.Enabled = True
        Frm2.DateMovementHistory.Enabled = True
<<<<<<< HEAD
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
=======
        Frm2.TEXTCredit.Text = Me.TEXTValues.Text

    End Sub

    Private Sub TextBox3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextPermissionNumber.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim dt1 As DateTime = ServerDateTime.ToString("yyyy-MM-dd")
            Me.Tag = Me.TEXTValues.Text.ToString

            FrmEmpsolf.TEXTCredit.Text = Me.TEXTValues.Text.Trim
            Me.Tag = Me.TEXTValues.Text.ToString.Trim
            FrmEmpsolf.TEXTCredit.Text = Me.Tag

            FrmBanks5.TEXTCredit.Text = Me.TEXTValues.Text.Trim
            Me.Tag = Me.TEXTValues.Text.ToString.Trim
            FrmBanks5.TEXTCredit.Text = Me.Tag

            FrmJO.TEXTCredit.Text = Me.TEXTValues.Text.Trim
            Me.Tag = Me.TEXTValues.Text.ToString.Trim
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            FrmJO.TEXTCredit.Text = Me.Tag
            Me.Close()
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextPermissionNumber.TextChanged
=======
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextPermissionNumber.TextChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim Frm As New FrmBanks5
        Dim Frm1 As New FrmEmpsolf
        Dim Frm2 As New FrmJO
        'If Frm.Visible = True Then
        Frm.TEXTCredit.Enabled = True
        Frm.DateMovementHistory.Enabled = True
<<<<<<< HEAD
        Frm.TEXTCredit.Text = Me.TEXTValues.EditValue
=======
        Frm.TEXTCredit.Text = Me.TEXTValues.Text
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        'ElseIf Frm1.Visible = True Then
        Frm1.TEXTCredit.Enabled = True
        Frm1.DateMovementHistory.Enabled = True
<<<<<<< HEAD
        Frm1.TEXTCredit.Text = Me.TEXTValues.EditValue

        Frm1.TEXTCredit.Text = Me.TEXTValues.EditValue
=======
        Frm1.TEXTCredit.Text = Me.TEXTValues.Text

        Frm1.TEXTCredit.Text = Me.TEXTValues.Text
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'Me.Tag = Me.TextBox1.Text
        'frmempsolf.TEXT5.Text = Me.Tag
        'ElseIf Frm2.Visible = True Then
        Frm2.TEXTCredit.Enabled = True
        Frm2.DateMovementHistory.Enabled = True
<<<<<<< HEAD
        Frm2.TEXTCredit.Text = Me.TEXTValues.EditValue
=======
        Frm2.TEXTCredit.Text = Me.TEXTValues.Text
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        'End If
    End Sub

End Class