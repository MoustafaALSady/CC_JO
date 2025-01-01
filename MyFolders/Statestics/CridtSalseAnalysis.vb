Imports System.Data.SqlClient
Public Class CridtSalseAnalysis
    Dim VTotal, VOther, VDiscount, VNet As Double
    Dim adp As New SqlClient.SqlDataAdapter
    Private Sub MTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            If Not IsDate(MTextBox1.Text) Then
                MsgBox("ÊÇÑíÎ ÛíÑ ÕÇáÎ")
                MTextBox1.Focus()
            Else
                Dim monthes As Double
                Dim SecondDate As Date
                SecondDate = CDate(MTextBox1.Text)
                monthes = 1
                MTextBox2.Text = DateAdd(DateInterval.Month, monthes, SecondDate)
                MTextBox2.Focus()
            End If
        End If
    End Sub
    Private Sub MTextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            FillGrid()
        End If
    End Sub
    Private Sub FillGrid()
        VTotal = 0
        VOther = 0
        VDiscount = 0
        VNet = 0
        Dim Cd1, Cd2 As Date, F As Boolean = False, T As Boolean = True
        Cd1 = "#" + MTextBox1.Text + "#"
        Cd2 = "#" + MTextBox2.Text + "#"


        Dim ds As DataSet
        ds = New DataSet
        Dgrd.Rows.Clear()
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strSQL As New SqlCommand("", Consum)
        With strSQL
            .CommandText = "SELECT SLS2, SLS3, SLS5, SLS6, SLS8, SLS11,SLS13,SLS14, SLS16 FROM SALES  WHERE deleted ='" & False & "' and type_cash ='" & F & "' and CUser='" & CUser & "'  ORDER BY SLS1"
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

            If ds.Tables("SALES").Rows(I).Item("SLS3") >= Cd1 And _
              ds.Tables("SALES").Rows(I).Item("SLS3") <= Cd2 Then

                Dim total As Double = _
                ds.Tables("SALES").Rows(I).Item("SLS6") - _
                ds.Tables("SALES").Rows(I).Item("SLS11") + _
                ds.Tables("SALES").Rows(I).Item("SLS13")

                Dim row As String() = _
                {ds.Tables("SALES").Rows(I).Item("SLS2"), _
                 ds.Tables("SALES").Rows(I).Item("SLS3"), _
                 ds.Tables("SALES").Rows(I).Item("SLS5"), _
                 total, _
                 ds.Tables("SALES").Rows(I).Item("SLS16"), _
                 ds.Tables("SALES").Rows(I).Item("SLS11"), _
                 ds.Tables("SALES").Rows(I).Item("SLS8"), _
                 ds.Tables("SALES").Rows(I).Item("SLS14")}
                Dgrd.Rows.Add(row)
            End If
        Next
        On Error Resume Next
        For I As Integer = 0 To Dgrd.Rows.Count - 2
            Dim row As DataGridViewRow = Dgrd.Rows(I)
            Dim VSalse As DataGridViewTextBoxCell = row.Cells(3)
            Dim Vother1 As DataGridViewTextBoxCell = row.Cells(5)
            Dim Vdiscount1 As DataGridViewTextBoxCell = row.Cells(6)
            Dim Vnet1 As DataGridViewTextBoxCell = row.Cells(7)

            VTotal += VSalse.Value
            VOther += Vother1.Value
            VDiscount += Vdiscount1.Value
            VNet += Vnet1.Value
        Next
        TextVTotal.Text = VTotal
        TextVOther.Text = VOther
        TextVDiscount.Text = VDiscount
        TextVNet.Text = VNet
        Consum.Close()
    End Sub
    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dgrd.Rows.Clear()
        TextVTotal.Clear()
        TextVOther.Clear()
        TextVDiscount.Clear()
        TextVNet.Clear()
        MTextBox1.Focus()
        Me.Close()
    End Sub
    Private Sub CridtSalseAnalysis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        MTextBox1.Focus()
    End Sub
End Class