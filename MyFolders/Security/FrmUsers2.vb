Imports System.Data.SqlClient
Public Class FrmUsers2
<<<<<<< HEAD
    ReadOnly Consum As New SqlConnection(constring)
    ReadOnly ds As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter

    Dim SQLstr As String = "SELECT * FROM Users"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button1.Click
=======
    ReadOnly Consum As New SqlClient.SqlConnection(constring)
    ReadOnly ds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter

    Dim SQLstr As String = "SELECT * FROM Users"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Me.TextBox1.Text = "" Then
            MsgBox("إدخل كلمة المرور", MsgBoxStyle.OkOnly, "تنبيه")
            Exit Sub
        End If
        Me.ds.Clear()
        SQLstr = "SELECT Pws FROM Users where UserName='" & USERNAME & "' and Pws='" & Me.TextBox1.Text.Trim & "'"
        Consum.Open()
        Dim DataAdapter1 As New SqlDataAdapter(SQLstr, Consum)
        DataAdapter1.Fill(Me.ds, "Users")
        Consum.Close()

        Me.TextBox4.DataBindings.Clear()
        Me.TextBox4.DataBindings.Add("Text", ds, "Users.Pws")

        If Me.TextBox4.Text = Me.TextBox1.Text Then
            Me.GroupBox1.Enabled = False
            Me.GroupBox2.Enabled = True

        Else
            MsgBox("خطأ في كلمة المرور", MsgBoxStyle.OkOnly, "تنبيه")
            Me.TextBox1.Text = ""
            Me.TextBox1.Focus()
            Exit Sub
        End If
    End Sub

<<<<<<< HEAD
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button2.Click
=======
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.TextBox2.Text = Nothing Then
            MsgBox("الرجاء ادخال كلمة المرورالجديدة")
            Exit Sub
        End If
        If Me.TextBox2.Text <> Me.TextBox3.Text Then
            MsgBox("كلمتان المرور غير متطابقتان")
            Exit Sub
        Else
            Dim SavInto As New SqlCommand
            Dim adapter2 As New SqlDataAdapter(SQLstr, Consum)
            SavInto.Connection = Consum
            SavInto.CommandType = CommandType.Text
            SavInto.CommandText = "UPDATE Users SET [Pws] = '" & Me.TextBox3.Text & "' WHERE UserName = '" & USERNAME & "'"
            Consum.Open()
            SavInto.ExecuteNonQuery()
            Consum.Close()
            MsgBox("تمت عملية الحفظ بنجاح")
            Me.Button3.Text = "انهاء"
            Me.GroupBox1.Enabled = False
            Me.GroupBox2.Enabled = False
        End If
    End Sub
<<<<<<< HEAD
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub FrmUsers2_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub FrmUsers2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
    End Sub

End Class