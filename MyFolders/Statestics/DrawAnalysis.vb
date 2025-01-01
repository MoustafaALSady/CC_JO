Imports System.Data.SqlClient
Public Class DrawAnalysis
    Private Sub DrawAnalysis_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        ClsTxt()
    End Sub
    Public Sub ClsTxt()
        Dim I As Integer
        For I = 0 To Me.Controls.Count - 1
            If TypeOf Me.Controls(I) Is TextBox Then
                Me.Controls(I).Text = ""
            End If
        Next
    End Sub
    Private Sub CreatePointsAndSizes()
        Dim g As Graphics
        g = Me.GR.CreateGraphics
        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)
        Dim redpen As New Pen(Color.Red, 3)
        Dim BLUPen As New Pen(Color.Blue, 3)

        g.DrawLine(blackPen, 60, 20, 60, 350)
        g.DrawLine(BLUPen, 60, 350, 560, 350)
    End Sub
    Public Sub DrawStringPointF()
        Dim g As Graphics
        g = Me.GR.CreateGraphics
        Dim raw As String() = {"", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "«·‘ÂÊ—"}
        Dim raw1 As String() = {"", " 10 %", " 20 %", " 30 %", " 40 %", " 50 %", " 60 %", " 70 %", " 80 %", " 90 %", "100 %", "«·‰”»…"}
        ' Create font and brush.
        Dim drawFont As New Font("Arial", 11)
        Dim drawBrush As New SolidBrush(Color.Black)
        Dim drawBrush2 As New SolidBrush(Color.Blue)
        Dim drawBrush3 As New SolidBrush(Color.Red)
        Dim i As Single
        Dim str As String
        Dim str2 As String
        Dim d As Single
        For d = 20 To 720 Step 30
            str2 = raw1(11)
            Dim drawPoint1 As New PointF(15, 20)
            g.DrawString(str2, drawFont, drawBrush3, drawPoint1)
            str2 = raw1(10)
            Dim drawPoint2 As New PointF(15, 42)
            g.DrawString(str2, drawFont, drawBrush3, drawPoint2)
            str2 = raw1(5)
            Dim drawPoint3 As New PointF(15, 190)
            g.DrawString(str2, drawFont, drawBrush3, drawPoint3)
            str2 = "0 %"
            Dim drawPoint4 As New PointF(15, 340)
            g.DrawString(str2, drawFont, drawBrush3, drawPoint4)
        Next

        '/**********
        '/*********
        For i = 90 To 720 Step 40
            If i = 90 Then
                str = raw(1)
                Dim drawPoint As New PointF(i - 7, 350.0F)
                g.DrawString(str, drawFont, drawBrush, drawPoint)
            End If
            If i = 130 Then
                str = raw(2)
                Dim drawPoint As New PointF(i - 7, 350.0F)
                g.DrawString(str, drawFont, drawBrush, drawPoint)
            End If
            If i = 170 Then
                str = raw(3)
                Dim drawPoint As New PointF(i - 7, 350.0F)
                g.DrawString(str, drawFont, drawBrush, drawPoint)
            End If
            If i = 210 Then
                str = raw(4)
                Dim drawPoint As New PointF(i - 7, 350.0F)
                g.DrawString(str, drawFont, drawBrush, drawPoint)
            End If
            If i = 250 Then
                str = raw(5)
                Dim drawPoint As New PointF(i - 7, 350.0F)
                g.DrawString(str, drawFont, drawBrush, drawPoint)
            End If
            If i = 290 Then
                str = raw(6)
                Dim drawPoint As New PointF(i - 7, 350.0F)
                g.DrawString(str, drawFont, drawBrush, drawPoint)
            End If
            If i = 330 Then
                str = raw(7)
                Dim drawPoint As New PointF(i - 7, 350.0F)
                g.DrawString(str, drawFont, drawBrush, drawPoint)
            End If
            If i = 370 Then
                str = raw(8)
                Dim drawPoint As New PointF(i - 7, 350.0F)
                g.DrawString(str, drawFont, drawBrush, drawPoint)
            End If
            If i = 410 Then
                str = raw(9)
                Dim drawPoint As New PointF(i - 7, 350.0F)
                g.DrawString(str, drawFont, drawBrush, drawPoint)
            End If
            If i = 450 Then
                str = raw(10)
                Dim drawPoint As New PointF(i - 7, 350.0F)
                g.DrawString(str, drawFont, drawBrush, drawPoint)
            End If
            If i = 490 Then
                str = raw(11)
                Dim drawPoint As New PointF(i - 7, 350.0F)
                g.DrawString(str, drawFont, drawBrush, drawPoint)

            End If
            If i = 530 Then
                str = raw(12)
                Dim drawPoint As New PointF(i - 7, 350.0F)
                g.DrawString(str, drawFont, drawBrush, drawPoint)
            End If
            If i = 570 Then
                str = raw(13)
                Dim drawPoint As New PointF(560 - 50, 370.0F)
                g.DrawString(str, drawFont, drawBrush2, drawPoint)
            End If

        Next
    End Sub
    Private Sub SubtractButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles subtractButton.Click
        CreatePointsAndSizes()
        DrawStringPointF()
        Sales()
    End Sub
    Private Sub ViuSALES()
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("select *from SALES where deleted = '" & False & "'order by SLS1", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        Adp.Fill(ds, "SALES")
        If ds.Tables(0).Rows.Count > 0 Then
            '  Me.TextBox11.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            '  Me.TextBox11.Text = "0"
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

    Private Sub Sales()
        Dim VTOTAL As Double
        Dim VV As Double() = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim dat As Date
        '/**
        Dim Flt As String
        Flt = "select *from invheadout"
        Application.DoEvents()
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim ds As New DataSet
        Dim strsql As New SqlCommand("", Consum)
        Adp = New SqlDataAdapter(strsql)
        With strsql
            .CommandText = "select * from SALES  WHERE deleted ='" & False & "' and CUser='" & CUser & "'  ORDER BY SLS1"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
        End With
        ds.Clear()
        Adp.Fill(ds)
        Adp.Fill(ds, "SALES")
        If ds.Tables(0).Rows.Count > 0 Then
            For I As Integer = 0 To ds.Tables("SALES").Rows.Count - 1
                dat = CDate(ds.Tables("SALES").Rows(I).Item("SLS3"))
                If dat.Month = 1 Then
                    VV(1) += ds.Tables("SALES").Rows(I).Item("SLS14")
                End If

                If dat.Month = 2 Then
                    VV(2) += ds.Tables("SALES").Rows(I).Item("SLS14")
                End If
                If dat.Month = 3 Then
                    VV(3) += ds.Tables("SALES").Rows(I).Item("SLS14")
                End If
                If dat.Month = 4 Then
                    VV(4) += ds.Tables("SALES").Rows(I).Item("SLS14")
                End If
                If dat.Month = 5 Then
                    VV(5) += ds.Tables("SALES").Rows(I).Item("SLS14")
                End If
                If dat.Month = 6 Then
                    VV(6) += ds.Tables("SALES").Rows(I).Item("SLS14")
                End If
                If dat.Month = 7 Then
                    VV(7) += ds.Tables("SALES").Rows(I).Item("SLS14")
                End If
                If dat.Month = 8 Then
                    VV(8) += ds.Tables("SALES").Rows(I).Item("SLS14")
                End If
                If dat.Month = 9 Then
                    VV(9) += ds.Tables("SALES").Rows(I).Item("SLS14")
                End If
                If dat.Month = 10 Then
                    VV(10) += ds.Tables("SALES").Rows(I).Item("SLS14")
                End If
                If dat.Month = 11 Then
                    VV(11) += ds.Tables("SALES").Rows(I).Item("SLS14")
                End If
                If dat.Month = 12 Then
                    VV(12) += ds.Tables("SALES").Rows(I).Item("SLS14")
                End If
                VTOTAL += ds.Tables("SALES").Rows(I).Item("SLS14")
            Next
            TextBox1.Text = VV(1)
            TextBox2.Text = VV(2)
            TextBox3.Text = VV(3)
            TextBox4.Text = VV(4)
            TextBox5.Text = VV(5)
            TextBox6.Text = VV(6)
            TextBox7.Text = VV(7)
            TextBox8.Text = VV(8)
            TextBox9.Text = VV(9)
            TextBox10.Text = VV(10)
            TextBox11.Text = VV(11)
            TextBox12.Text = VV(12)
            TextBox13.Text = VTOTAL
            Dim g As Graphics
            g = Me.GR.CreateGraphics
            Dim drawFont As New Font("Arial", 8, FontStyle.Bold)
            Dim drawBrush As New SolidBrush(Color.Blue)
            Dim drawBrush2 As New SolidBrush(Color.Green)
            Dim PER As Double() = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

            For I As Integer = 1 To 12
                PER(I) = Math.Round(VV(I) * 100 / VTOTAL, 1)
            Next
            Dim x1 As Integer = 60
            Dim x2 As Integer = 600
            'direction
            Dim y1 As Integer = 350 - PER(1) * 3
            Dim y2 As Integer = 350 - PER(2) * 3
            Dim y3 As Integer = 350 - PER(3) * 3
            Dim y4 As Integer = 350 - PER(4) * 3
            Dim y5 As Integer = 350 - PER(5) * 3
            Dim y6 As Integer = 350 - PER(6) * 3
            Dim y7 As Integer = 350 - PER(7) * 3
            Dim y8 As Integer = 350 - PER(8) * 3
            Dim y9 As Integer = 350 - PER(9) * 3
            Dim y10 As Integer = 350 - PER(10) * 3
            Dim y11 As Integer = 350 - PER(11) * 3
            Dim y12 As Integer = 350 - PER(12) * 3

            Dim Pen1 As New Pen(Color.Red, 20)
            Dim Pen2 As New Pen(Color.Red, 20)
            Dim Pen3 As New Pen(Color.Red, 20)
            Dim Pen4 As New Pen(Color.Red, 20)
            Dim Pen5 As New Pen(Color.Red, 20)
            Dim Pen6 As New Pen(Color.Red, 20)
            Dim Pen7 As New Pen(Color.Red, 20)
            Dim Pen8 As New Pen(Color.Red, 20)
            Dim Pen9 As New Pen(Color.Red, 20)
            Dim Pen0 As New Pen(Color.Red, 20)
            Dim Pen10 As New Pen(Color.Red, 20)
            Dim Pen11 As New Pen(Color.Red, 20)
            Dim Pen12 As New Pen(Color.Red, 20)
            TextBox14.Text = y3
            If y1 <= 80 Then
                Pen1.Color = Color.Yellow
            End If
            If y1 < 200 And y1 > 80 Then
                Pen1.Color = Color.Blue
            End If
            If y1 > 200 Then
                Pen1.Color = Color.Red
            End If
            If y2 <= 80 Then
                Pen2.Color = Color.Yellow
            End If
            If y2 < 200 And y2 > 80 Then
                Pen2.Color = Color.Blue
            End If
            If y2 > 200 Then
                Pen2.Color = Color.Red
            End If
            If y3 <= 80 Then
                Pen3.Color = Color.Yellow
            End If
            If y3 < 200 And y3 > 80 Then
                Pen3.Color = Color.Blue
            End If
            If y3 > 200 Then
                Pen3.Color = Color.Red
            End If
            If y4 <= 80 Then
                Pen4.Color = Color.Yellow
            End If
            If y4 < 200 And y4 > 80 Then
                Pen4.Color = Color.Blue
            End If
            If y4 > 200 Then
                Pen4.Color = Color.Red
            End If
            If y5 <= 80 Then
                Pen5.Color = Color.Yellow
            End If
            If y5 < 200 And y5 > 80 Then
                Pen5.Color = Color.Blue
            End If
            If y5 > 200 Then
                Pen5.Color = Color.Red
            End If
            If y6 <= 80 Then
                Pen6.Color = Color.Yellow
            End If
            If y6 < 200 And y6 > 80 Then
                Pen6.Color = Color.Blue
            End If
            If y6 > 200 Then
                Pen6.Color = Color.Red
            End If
            If y7 <= 80 Then
                Pen7.Color = Color.Yellow
            End If
            If y7 < 200 And y7 > 80 Then
                Pen7.Color = Color.Blue
            End If
            If y7 > 200 Then
                Pen7.Color = Color.Red
            End If
            If y8 <= 80 Then
                Pen8.Color = Color.Yellow
            End If
            If y8 < 200 And y8 > 80 Then
                Pen8.Color = Color.Blue
            End If
            If y8 > 200 Then
                Pen8.Color = Color.Red
            End If
            If y9 <= 80 Then
                Pen9.Color = Color.Yellow
            End If
            If y9 < 200 And y9 > 80 Then
                Pen9.Color = Color.Blue
            End If
            If y9 > 200 Then
                Pen9.Color = Color.Red
            End If
            If y10 <= 80 Then
                Pen10.Color = Color.Yellow
            End If
            If y10 < 200 And y10 > 80 Then
                Pen10.Color = Color.Blue
            End If
            If y10 > 200 Then
                Pen10.Color = Color.Red
            End If
            If y11 <= 80 Then
                Pen11.Color = Color.Yellow
            End If
            If y11 < 200 And y11 > 80 Then
                Pen11.Color = Color.Blue
            End If
            If y11 > 200 Then
                Pen11.Color = Color.Red
            End If
            If y12 <= 80 Then
                Pen12.Color = Color.Yellow
            End If
            If y12 < 200 And y12 > 80 Then
                Pen12.Color = Color.Blue
            End If
            If y12 > 200 Then
                Pen12.Color = Color.Red
            End If

            g.DrawLine(Pen1, 90, y1, 90, 350)
            Dim drawPoint As New PointF(90 - 15, y1 - 20)
            g.DrawString(PER(1) & " %", drawFont, drawBrush, drawPoint)

            g.DrawLine(Pen2, 130, y2, 130, 350)
            Dim drawPoint2 As New PointF(130 - 15, y2 - 20)
            g.DrawString(PER(2) & " %", drawFont, drawBrush, drawPoint2)

            g.DrawLine(Pen3, 170, y3, 170, 350)
            Dim drawPoint3 As New PointF(170 - 15, y3 - 20)
            g.DrawString(PER(3) & " %", drawFont, drawBrush, drawPoint3)

            g.DrawLine(Pen4, 210, y4, 210, 350)
            Dim drawPoint4 As New PointF(210 - 15, y4 - 20)
            g.DrawString(PER(4) & " %", drawFont, drawBrush, drawPoint4)

            g.DrawLine(Pen5, 250, y5, 250, 350)
            Dim drawPoint5 As New PointF(250 - 15, y5 - 20)
            g.DrawString(PER(5) & " %", drawFont, drawBrush, drawPoint5)

            g.DrawLine(Pen6, 290, y6, 290, 350)
            Dim drawPoint6 As New PointF(290 - 15, y6 - 20)
            g.DrawString(PER(6) & " %", drawFont, drawBrush, drawPoint6)

            g.DrawLine(Pen7, 330, y7, 330, 350)
            Dim drawPoint7 As New PointF(330 - 15, y7 - 20)
            g.DrawString(PER(7) & " %", drawFont, drawBrush, drawPoint7)

            g.DrawLine(Pen8, 370, y8, 370, 350)
            Dim drawPoint8 As New PointF(370 - 15, y8 - 20)
            g.DrawString(PER(8) & " %", drawFont, drawBrush, drawPoint8)

            g.DrawLine(Pen9, 410, y9, 410, 350)
            Dim drawPoint9 As New PointF(410 - 15, y9 - 20)
            g.DrawString(PER(9) & " %", drawFont, drawBrush, drawPoint9)

            g.DrawLine(Pen10, 450, y10, 450, 350)
            Dim drawPoint10 As New PointF(450 - 15, y10 - 20)
            g.DrawString(PER(10) & " %", drawFont, drawBrush, drawPoint10)

            g.DrawLine(Pen11, 490, y11, 490, 350)
            Dim drawPoint11 As New PointF(490 - 15, y11 - 20)
            g.DrawString(PER(11) & " %", drawFont, drawBrush, drawPoint11)

            g.DrawLine(Pen12, 530, y12, 530, 350)
            Dim drawPoint12 As New PointF(530 - 15, y12 - 20)
            g.DrawString(PER(12) & " %", drawFont, drawBrush, drawPoint12)
        Else
            MsgBox("·« ÌÊÃœ »Ì«‰«  ·⁄—÷Â«", 64 + 524288, "⁄—÷ «·»Ì«‰« ")
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub


End Class