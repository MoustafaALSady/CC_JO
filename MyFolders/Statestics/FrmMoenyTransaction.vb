
Imports System.Data.SqlClient
Public Class FrmMoenyTransaction
    ReadOnly ds1 As New DataSet, Con As String, F As Boolean = False, T As Boolean = True
    Dim adp As New SqlClient.SqlDataAdapter
    Private Sub INCOME()
        Dim Vcash, Vcrdt As Double
        Dim Tcash, Tcrdt As Double
        Dim Vdate As Date
        DGRD1.Rows.Clear()
        Dim CDATE1, CDATE2 As String
        ' Filter to Get From  invoices in the range of Followig  dates
        CDATE1 = "#" + Dt1.Value.Date + "#"
        CDATE2 = "#" + Dt2.Value.Date + "#"

        Application.DoEvents()
        Dim ds As DataSet
        ds = New DataSet
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strSQL As New SqlCommand("", Consum)
        With strSQL
            .CommandText = "select * from SALES  WHERE deleted ='" & False & "' and CUser='" & CUser & "'  ORDER BY SLS1"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
        End With
        adp = New SqlClient.SqlDataAdapter(strSQL)
        Dim oCommandBuilder As New SqlClient.SqlCommandBuilder(adp)
        adp.Fill(ds, "SALES")

        If Me.BindingContext(ds, "SALES").Count = 0 Then
            MsgBox("áÇ íæÌÏ ÈíÇäÇÊ áÚÑÖåÇ", 64 + 524288, "ÚÑÖ ÇáÈíÇäÇÊ")
            Exit Sub
        End If
        For I As Integer = 0 To ds.Tables("SALES").Rows.Count - 1
            If ds.Tables("SALES").Rows(I).Item("SLS3") >= CDATE1 And
               ds.Tables("SALES").Rows(I).Item("SLS3") <= CDATE2 Then

                If ds.Tables("SALES").Rows(I).Item("type_cash") = T Then Vcash = ds.Tables("SALES").Rows(I).Item("SLS14")
                If ds.Tables("SALES").Rows(I).Item("type_crdt") = T Then Vcrdt = ds.Tables("SALES").Rows(I).Item("SLS14")
                Vdate = ds.Tables("SALES").Rows(I).Item("SLS3")

                Dim row As String() = {Vdate, Vcash, Vcrdt, " ÝÇÊæÑÉ ÈíÚ ÑÞã" & " : " & ds.Tables("SALES").Rows(I).Item("SLS2")}
                DGRD1.Rows.Add(row)
                Tcash += Vcash : Tcrdt += Vcrdt
                Vcash = 0 : Vcrdt = 0
            End If
        Next
        TextBox1.Text = Tcash : TextBox4.Text = Tcrdt
        Consum.Close()
    End Sub
    Private Sub OUTGOING()
        Dim Vcash, Vcrdt As Double
        Dim Tcash, Tcrdt As Double
        Dim Vdate As Date
        DGRD2.Rows.Clear()
        Dim CDATE1, CDATE2 As String
        CDATE1 = "#" + Dt1.Value.Date + "#"
        CDATE2 = "#" + Dt2.Value.Date + "#"

        Application.DoEvents()
        Dim ds2 As DataSet
        ds2 = New DataSet
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strSQL As New SqlCommand("", Consum)
        With strSQL
            .CommandText = "select *from BUYS  WHERE deleted ='" & False & "' and CUser='" & CUser & "'order by BUY1"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
        End With
        adp = New SqlClient.SqlDataAdapter(strSQL)
        Dim oCommandBuilder As New SqlClient.SqlCommandBuilder(adp)
        adp.Fill(ds2, "BUYS")
        If Me.BindingContext(ds2, "BUYS").Count = 0 Then
            MsgBox("áÇ íæÌÏ ÈíÇäÇÊ áÚÑÖåÇ", 64 + 524288, "ÚÑÖ ÇáÈíÇäÇÊ")
            Exit Sub
        End If

        For I As Integer = 0 To ds2.Tables("BUYS").Rows.Count - 1
            If ds2.Tables("BUYS").Rows(I).Item("BUY3") >= CDATE1 And
               ds2.Tables("BUYS").Rows(I).Item("BUY3") <= CDATE2 Then

                If ds2.Tables("BUYS").Rows(I).Item("type_cash") = T Then Vcash = ds2.Tables("BUYS").Rows(I).Item("BUY14")
                If ds2.Tables("BUYS").Rows(I).Item("type_crdt") = T Then Vcrdt = ds2.Tables("BUYS").Rows(I).Item("BUY14")
                Vdate = ds2.Tables("BUYS").Rows(I).Item("BUY3")
                Dim row As String() = {Vdate, Vcash, Vcrdt, " ÝÇÊæÑÉ ÔÑÇÁ ÑÞã" & " : " & ds2.Tables("BUYS").Rows(I).Item("BUY2")}
                DGRD2.Rows.Add(row)
                Tcash += Vcash : Tcrdt += Vcrdt
                Vcash = 0 : Vcrdt = 0
            End If
        Next
        TextBox5.Text = Tcash : TextBox8.Text = Tcrdt
    End Sub
    Private Sub FrmMoenyTransaction_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Dt1.Focus()
    End Sub
    Private Sub FrmMoenyTransaction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        DGRD1.Rows.Clear()
        DGRD2.Rows.Clear()
        Dt1.Focus()
    End Sub


    Private Sub Dt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dt1.KeyPress
        Dim ASCI As Short = Asc(e.KeyChar)
        If ASCI = 13 Then
            Dt2.Focus()
        End If
    End Sub
    Private Sub Dt2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dt2.KeyPress
        Dim ASCI As Short = Asc(e.KeyChar)
        If ASCI = 13 Then
            INCOME()
            OUTGOING()
            TextBox9.Text = Val(TextBox1.Text) + Val(TextBox4.Text)
            TextBox10.Text = Val(TextBox5.Text) + Val(TextBox8.Text)
            TextBox2.Text = Math.Round(Val(TextBox1.Text) * 100 / Val(TextBox9.Text), 2)
            TextBox3.Text = Math.Round(Val(TextBox4.Text) * 100 / Val(TextBox9.Text), 2)
            TextBox7.Text = Math.Round(Val(TextBox5.Text) * 100 / Val(TextBox10.Text), 2)
            TextBox6.Text = Math.Round(Val(TextBox8.Text) * 100 / Val(TextBox10.Text), 2)
            TextBox11.Text = Val(TextBox9.Text) - Val(TextBox10.Text)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class