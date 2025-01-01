Imports System.Data.SqlClient

Public Class Form_FATORAMALK0
    Dim pagingAdapter As SqlDataAdapter
    Dim pagingDS As DataSet
    ReadOnly scrollVal As Integer
    Private Sub Form_FATORAMALK0_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Ra1.Checked = False And Ra2.Checked = False Then
                MsgBox("حدد الفاتورة مبيعات او فواتير باركود", MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If

            If TexFIND.Text.Trim = "" Then
                MsgBox("كم رقم الفاتورة !!", MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
            Try
                Dim Consum As New SqlClient.SqlConnection(constring)
                If Ra1.Checked = True Then
                    Form_beea.Datab.Columns.Clear()
                    Form_beea.Timsum.Start()
                    If Consum.State = ConnectionState.Open Then
                        Consum.Close()
                    End If
                    Consum.Open()
                    'البيانات بالتدريج
                    Dim sql As String = "SELECT * FROM  TaleekFatoBEEA where NUMfatora = '" & TexFIND.Text.Trim & "' AND ID > 1  "
                    pagingAdapter = New SqlDataAdapter(sql, Consum)
                    pagingDS = New DataSet()
                    pagingAdapter.Fill(pagingDS, scrollVal, 100000, "TaleekFatoBEEA")
                    Consum.Close()
                    Form_beea.Datab.DataSource = pagingDS
                    Form_beea.Datab.DataMember = "TaleekFatoBEEA"
                    Form_beea.Datab.Sort(Form_beea.Datab.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    Form_beea.Datab.Columns(0).HeaderText = "الباركود"
                    Form_beea.Datab.Columns(1).HeaderText = "اسم الصنف"
                    Form_beea.Datab.Columns(2).HeaderText = "العدد"
                    Form_beea.Datab.Columns(3).HeaderText = "السعر"
                    Form_beea.Datab.Columns(4).HeaderText = "الخصم"
                    Form_beea.Datab.Columns(5).HeaderText = "المجموع"
                    Form_beea.Datab.Columns(6).HeaderText = "مجموع الخصم"
                    Form_beea.Datab.Columns(7).HeaderText = "سعر الشراء"
                    Form_beea.M1.Text = "بيع"
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
            End Try
        End If

        Me.Close()

    End Sub

    Private Sub Form_FATORAMALK0_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub
End Class