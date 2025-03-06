

Public Class SearchCash

<<<<<<< HEAD
    Private Sub SEARCHCASH_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
=======
    Private Sub SEARCHCASH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        'If Char.IsControl(e.KeyChar) = False Then
        '    If Char.IsDigit(e.KeyChar) Then
        '    Else
        '        e.Handled = True
        '    End If
        'End If
        'If Asc(e.KeyChar) = Keys.Enter Then
        '    SearchBUTTON_Click(sender, e)
        'End If
    End Sub
<<<<<<< HEAD
    Private Sub Texser_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Texser.KeyPress
=======
    Private Sub Texser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Texser.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            SearchBUTTON_Click(sender, e)
        End If
    End Sub

<<<<<<< HEAD
    Private Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SearchBUTTON.Click
=======
    Private Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Try
            If Me.RadioB1.Checked = True Then
                AddType1()
                Dim f As New FrmBanks5
                ds.EnforceConstraints = False
                If Me.RB1.Checked = True Then
                    f.TB1 = Trim(Texser.Text)
                ElseIf Me.RB2.Checked = True Then
                    f.TB2 = Trim(Texser.Text)
                ElseIf Me.RB3.Checked = True Then
                    f.TB3 = Trim(Texser.Text)
                End If
                f.Show()
                f.DanLOd()
            ElseIf Me.RadioB2.Checked = True Then
                AddType1()
                Dim f As New FrmJO
                If Me.RB1.Checked = True Then
                    f.TB1 = Trim(Texser.Text)
                ElseIf Me.RB2.Checked = True Then
                    f.TB2 = Trim(Texser.Text)
                ElseIf Me.RB3.Checked = True Then
                    f.TB3 = Trim(Texser.Text)
                End If
                f.Show()
                f.DanLOd()
            ElseIf Me.RadioB3.Checked = True Then
                AddType1()
                Dim f As New FrmChecks
                If Me.RB1.Checked = True Then
                    f.TB1 = Trim(Me.Texser.Text)
                ElseIf Me.RB2.Checked = True Then
                    f.TB4 = Trim(Me.Texser.Text)
                ElseIf Me.RB3.Checked = True Then
                    f.TB3 = Strings.Trim(Me.Texser.Text)
                ElseIf Me.RB5.Checked = True Then
                    f.TB2 = Trim(Me.Texser.Text)
                End If
                f.Show()
                f.DanLOd()
            ElseIf Me.RadioB4.Checked = True Then
                AddType1()
                Dim f As New FrmEmpsolf
                If Me.RB1.Checked = True Then
                    f.TB1 = Trim(Texser.Text)
                ElseIf Me.RB3.Checked = True Then
                    f.TB2 = Trim(Texser.Text)
                ElseIf Me.RB2.Checked = True Then
                    f.TB3 = Trim(Texser.Text)
                End If
                f.Show()
                f.DanLOd()
            ElseIf Me.RadioB5.Checked = True Then
                AddType1()
                Dim f As New FrmDeposits
                If Me.RB1.Checked = True Then
                    f.TB1 = Trim(Texser.Text)
                ElseIf Me.RB4.Checked = True Then
                    f.TB2 = Trim(Texser.Text)
                ElseIf Me.RB5.Checked = True Then
                    f.TB4 = Trim(Texser.Text)
                ElseIf Me.RB6.Checked = True Then
                    f.TB3 = Trim(Texser.Text)
                End If
                f.Show()
                f.DanLOd()
            ElseIf Me.RadioB6.Checked = True Then
                AddType1()
                Dim f As New FrmTransaction
                If Me.RB1.Checked = True Then
                    f.TB1 = Trim(Texser.Text)
                ElseIf Me.RB4.Checked = True Then
                    f.TB2 = Trim(Texser.Text)
                ElseIf Me.RB5.Checked = True Then
                    f.TB4 = Trim(Texser.Text)
                ElseIf Me.RB6.Checked = True Then
                    f.TB3 = Trim(Texser.Text)
                End If
                f.Show()
                f.DanLOd()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub AddType1()
        On Error Resume Next
        If RadioB1.Checked = True Then
            Me.RB2.Text = "رمز الحركة"
            Me.RB3.Text = "رقم المستند"
            Me.RB4.Text = "رقم شهادة الاسهم"
            Me.RB5.Text = "رقم الشيك"
            Me.RB6.Text = "اسم العضو"
            Me.RB1.Enabled = True
            Me.RB2.Enabled = True
            Me.RB3.Enabled = True
            Me.RB4.Enabled = False
            Me.RB5.Enabled = False
            Me.RB6.Enabled = False
        ElseIf RadioB2.Checked = True Then
            Me.RB2.Text = "رقم المستند"
            Me.RB3.Text = "رقم الحساب"
            Me.RB4.Text = "رقم شهادة الاسهم"
            Me.RB5.Text = "رقم الشيك"
            Me.RB6.Text = "اسم العضو"

            Me.RB1.Enabled = True
            Me.RB2.Enabled = True
            Me.RB3.Enabled = True
            Me.RB4.Enabled = False
            Me.RB5.Enabled = False
            Me.RB6.Enabled = False
        ElseIf RadioB3.Checked = True Then
            Me.RB2.Text = "رقم العميل"
            Me.RB3.Text = "اسم العميل"
            Me.RB4.Text = "رقم شهادة الاسهم"
            Me.RB5.Text = "رقم الشيك"
            Me.RB6.Text = "اسم العضو"

            Me.RB1.Enabled = True
            Me.RB2.Enabled = True
            Me.RB3.Enabled = True
            Me.RB4.Enabled = False
            Me.RB5.Enabled = True
            Me.RB6.Enabled = False
        ElseIf RadioB4.Checked = True Then
            Me.RB2.Text = "رقم الموظف"
            Me.RB3.Text = "اسم الموظف"
            Me.RB4.Text = "رقم شهادة الاسهم"
            Me.RB5.Text = "رقم الشيك"
            Me.RB6.Text = "اسم العضو"

            Me.RB1.Enabled = True
            Me.RB2.Enabled = True
            Me.RB3.Enabled = True
            Me.RB4.Enabled = False
            Me.RB5.Enabled = False
            Me.RB6.Enabled = False
        ElseIf RadioB5.Checked = True Then
            Me.RB2.Text = "رقم المستند"
            Me.RB3.Text = "رقم الحساب"
            Me.RB4.Text = "رقم شهادة الاسهم"
            Me.RB5.Text = "رقم العضو"
            Me.RB6.Text = "اسم العضو"
            Me.RB1.Enabled = True
            Me.RB2.Enabled = False
            Me.RB3.Enabled = False
            Me.RB4.Enabled = True
            Me.RB5.Enabled = True
            Me.RB6.Enabled = True
        ElseIf RadioB6.Checked = True Then
            Me.RB2.Text = "رقم المستند"
            Me.RB3.Text = "رقم الحساب"
            Me.RB4.Text = "رقم شهادة الاسهم"
            Me.RB5.Text = "رقم العضو"
            Me.RB6.Text = "اسم العضو"
            Me.RB1.Enabled = True
            Me.RB2.Enabled = False
            Me.RB3.Enabled = False
            Me.RB4.Enabled = True
            Me.RB5.Enabled = True
            Me.RB6.Enabled = True
        End If
    End Sub
<<<<<<< HEAD
    Private Sub RadioB1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioB1.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioB2_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioB2.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioB3_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioB3.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioB4_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioB4.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioB5_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioB5.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioB6_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioB6.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub SEARCHCASH_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub RadioB1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioB1.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioB2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioB2.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioB3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioB3.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioB4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioB4.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioB5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioB5.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioB6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioB6.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub SEARCHCASH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Call Me.AddType1()
    End Sub


End Class