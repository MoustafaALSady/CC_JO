

Imports System.Data.SqlClient

Public Class FrmStocks4

    Dim Store As Integer
    Dim MovementSymbol1 As String
<<<<<<< HEAD
    Private Sub FrmStocks4_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
=======
    Private Sub FrmStocks4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            SearchBUTTON_Click(sender, e)
        End If
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
    Private Sub SearchMovementSymbol()
        If Me.RBPR.Checked = True Then
            TextMovementSymbol1.Text = "PR"
        ElseIf Me.RBVE.Checked = True Then
            TextMovementSymbol1.Text = "VE"
        ElseIf Me.RBQR.Checked = True Then
            TextMovementSymbol1.Text = "QR"
        ElseIf Me.RBST.Checked = True Then
            TextMovementSymbol1.Text = "ST"
        End If
    End Sub

<<<<<<< HEAD
    Private Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SearchBUTTON.Click
=======
    Private Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmStocks2
        Try
            If Me.RBItemCode.Checked = True Then
                f.TB1 = Trim(Me.Texser.Text)
            ElseIf Me.RBITEMNAME.Checked = True Then
                f.TB2 = Trim(Me.Texser.Text)
            ElseIf Me.RBnvoiceNumber.Checked = True Then
                f.TB3 = Trim(Me.Texser.Text)
            ElseIf Me.RBPermissionNumber.Checked = True Then
                f.TB4 = Trim(Me.Texser.Text)
            End If
            f.Show()
            f.Load_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub FrmStocks4_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmStocks4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)
        SearchMovementSymbol()


    End Sub

    Private Sub ComboStore_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboStore.SelectedIndexChanged
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT WarehouseName  FROM Warehouses WHERE WarehouseNumber ='" & Me.ComboStore.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT WarehouseName  FROM Warehouses WHERE WarehouseNumber ='" & Me.ComboStore.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Store = Me.ComboStore.Text
            Me.TextWarehouseName.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextWarehouseName.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

    Private Sub RBPR_CheckedChanged(sender As Object, e As EventArgs) Handles RBPR.CheckedChanged, RBVE.CheckedChanged, RBST.CheckedChanged
        SearchMovementSymbol()
    End Sub

    Private Sub Texser_TextChanged(sender As Object, e As EventArgs) Handles Texser.LostFocus

        If Me.RBnvoiceNumber.Checked = True Then
            MovementSymbol1 = Texser.Text
            Texser.Text = TextMovementSymbol1.Text & MovementSymbol1
        End If

    End Sub

    Private Sub Texser_GotFocus(sender As Object, e As EventArgs) Handles Texser.GotFocus

        If Me.RBnvoiceNumber.Checked = True Then
            SearchMovementSymbol()
        End If
        MovementSymbol1 = Nothing
        Texser.Clear()

    End Sub


End Class