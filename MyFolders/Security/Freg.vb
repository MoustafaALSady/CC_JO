Imports System.Diagnostics

Public Class Freg
<<<<<<< HEAD
    Private Sub Freg_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub Freg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Call URL_F()
            'Me.TextBox1.Text = URLI.ToString.Trim
            If mykey.GetValue("CORegCode", "") = COManagement.Md5ha(COManagement.SECU().Trim + "muostafa.76") Then
                L1.Text = "البرنامج مفعل"
                Me.TextBoxReg.Text = COManagement.SECU().Trim()
            Else
                L1.Text = "للتفعيل البرنامج ارسال رقم تسجيل نسخة البرنامج الى المؤسسة التعاونية الاردنية"
                Me.TextBoxReg.Text = "MS" + COManagement.SECU().Trim()

            End If
        Catch ex As Exception

        End Try

    End Sub
<<<<<<< HEAD
    Private Sub ButtonOk_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonOk.Click
=======
    Private Sub ButtonOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOk.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Me.TextBoxUser.Text.Trim = COManagement.Md5ha(COManagement.SECU().Trim + "muostafa.76") Then
                mykey.SetValue("CORegCode", COManagement.Md5ha(COManagement.SECU().Trim + "muostafa.76"))
                mykey.SetValue("URL", URL.ToString.Trim)
                mykey.SetValue("URL1", URL1.ToString.Trim)
                mykey.SetValue("URL2", URL2.ToString.Trim)
                Me.Label1.Text = "تم تفعيل البرنامج بنجاح"
                MsgBox("مبروك... لقد تم تفعيل البرنامج بنجاح")
                Me.Close()
                Process.Start(Application.StartupPath & "\" & "CC_JO.exe")
                Application.Exit()
            Else
                Me.Label1.Text = "رقم التفعيل خاطئ , احصل على كود التفعيل من المؤسسة التعاونية الاردنية"
                'End
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "خادم شبكة")
        End Try
    End Sub



End Class