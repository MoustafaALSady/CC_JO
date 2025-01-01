Imports System.Diagnostics
Imports System.Reflection

Public NotInheritable Class AboutBox1
    ReadOnly fs As IO.FileStream
    ReadOnly sr As IO.StreamReader
    ReadOnly VProject As String
    Dim versionNumber As Version
    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Call TxtURL1()
        Me.versionNumber = Assembly.GetExecutingAssembly().GetName().Version
        Me.LinkLabel3.Text = "http://jcc.gov.jo"
        Me.Text = "حول : " & " " & ApplicationTitle
        Me.LabelProductName.Text = "اسم المنتج : " & " " & My.Application.Info.ProductName
        Me.LabelVersion.Text = "الاصدار : " & " " & Trim(Me.versionNumber.ToString)
        Me.LabelCopyright.Text = "جميع الحقوق محفوظة : " & " " & My.Application.Info.Copyright
        Me.LabelCompanyName.Text = "اسم المؤسسة : " & " " & My.Application.Info.CompanyName
        Me.LabelRegste.Text = "ProductID  : " & " " & mykey.GetValue("CORegCode", COManagement.Md5ha(COManagement.SECU().Trim + "muostafa.76"))
        Me.Button1.Visible = False
        Me.LinkLabel2.Text = "أحدث إصـدار"
        If Trim(tmpV) > Trim(mykey.GetValue("ProductVersion", "")) Then
            Me.LinkLabel2.Text = "قم بتنزيل الإصدار الجديد "
            Me.Button1.Visible = True
        End If
    End Sub
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        On Error Resume Next
        Process.Start("mailto:ma965880@gmail.com")
    End Sub
    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("http://jcc.gov.jo/")
    End Sub
    Private Sub AboutBox1_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Trim(tmpV) > Trim(mykey.GetValue("ProductVersion", "")) Then
            Dim MSG_ As Integer = MessageBox.Show("هل تريد اتمام تحديث البرنامج للاصدار الجديد؟", "تنبيه بوجود تحديثات جديدة", MessageBoxButtons.YesNo)
            If MSG_ = DialogResult.Yes Then
                Process.Start(Application.StartupPath & "\Update_CO.exe")
                Application.Exit()
            Else
                MsgBox("شكراً لك.")
            End If
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If VersionCheckDB.SetupDatabase() = False Then
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
End Class
