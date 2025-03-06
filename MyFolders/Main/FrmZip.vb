Imports System.IO
Public Class FrmZip

    Private Sub ButtonEdit1_Click(sender As Object, e As EventArgs) Handles ButtonEdit1.Click
        Try
            MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            Dim fbd As New FolderBrowserDialog With {
                .RootFolder = Environment.SpecialFolder.MyComputer,
                .Description = "حدد المجلد المراد ضغطه ZIP"
            }
            If fbd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ButtonEdit1.Text = fbd.SelectedPath
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonEdit2_Click(sender As Object, e As EventArgs) Handles ButtonEdit2.Click
        Try
            MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            Dim sfd As New SaveFileDialog With {
                .Filter = "Zip compressed files (*.zip)|*.zip",
                .InitialDirectory = MYFOLDER & "\Compress"
            }
            If sfd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ButtonEdit2.Text = sfd.FileName
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            If Len(ButtonEdit1.Text) = 0 Then
                MessageBox.Show("من فضلك حدد المجلد الذى تريد ضغطه  ", "حدد المجلد", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.ButtonEdit1.Focus()
                Exit Sub
            End If
            If Len(ButtonEdit2.Text) = 0 Then
                MessageBox.Show("من فضلك حدد مسار الملف المضغوط  ", "حدد مسار الملف المضغوط", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.ButtonEdit2.Focus()
                Exit Sub
            End If
            Dim B(21) As Byte
            B(0) = 80 : B(1) = 75 : B(2) = 5 : B(3) = 6
            IO.File.WriteAllBytes(ButtonEdit2.Text, B)
            Dim sh As New Shell32.Shell
            Dim sf As Shell32.Folder = sh.NameSpace(ButtonEdit2.Text) ' مسار المجلد المراد ضغطه
            Dim df As Shell32.Folder = sh.NameSpace(ButtonEdit1.Text) ' اسم و مسار ملف زيب الذي سيستقبل محتوى المجلد
            sf.CopyHere(df)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try
            If Len(ButtonEdit4.Text) = 0 Then
                MessageBox.Show("من فضلك حدد المجلد الذى تريد فك الضغط عليه  ", "حدد المجلد", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.ButtonEdit4.Focus()
                Exit Sub
            End If
            If Len(ButtonEdit3.Text) = 0 Then
                MessageBox.Show("من فضلك حدد مسار الملف المضغوط  ", "حدد مسار الملف المضغوط", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.ButtonEdit3.Focus()
                Exit Sub
            End If
            MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            Dim shl As New Shell32.Shell()
            Dim src As Shell32.Folder = shl.NameSpace(Me.ButtonEdit3.Text)
            Dim dst As Shell32.Folder = shl.NameSpace(Me.ButtonEdit4.Text)
            dst.CopyHere(src.Items)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub FrmZip_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
=======
    Private Sub FrmZip_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            If Not IO.Directory.Exists(MYFOLDER & "\Compress") Then Directory.CreateDirectory(MYFOLDER & "\Compress")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonEdit3_Click(sender As Object, e As EventArgs) Handles ButtonEdit3.Click
        Try
            MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            Dim sfd As New OpenFileDialog With {
                .Filter = "Zip compressed files (*.zip)|*.zip",
                .InitialDirectory = MYFOLDER & "\Compress"
            }
            If sfd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ButtonEdit3.Text = sfd.FileName
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonEdit4_Click(sender As Object, e As EventArgs) Handles ButtonEdit4.Click
        Try
            MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            Dim fbd As New FolderBrowserDialog With {
                .RootFolder = Environment.SpecialFolder.MyComputer,
                .Description = "حدد المجلد المراد فك الضغط عليه ZIP"
            }
            If fbd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ButtonEdit4.Text = fbd.SelectedPath
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class