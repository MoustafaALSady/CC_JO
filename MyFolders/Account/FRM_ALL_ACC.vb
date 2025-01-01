Public Class FRM_ALL_ACC
    Public ACCEPT As Boolean = False

    Sub LOAD_ACCOUNT()
        Dim DT As New DataTable
        DT.Clear()
        DT = CLS_ACCOUNTS.SEARCH_ACCOUNTS(TXT_SEARCH.Text)
        If DT.Rows.Count > 0 Then
            Dim RO_ As Integer = 0
            DGV.RowCount = DT.Rows.Count
            For I As Integer = 0 To DT.Rows.Count - 1
                DGV.Rows(RO_).Cells("COL_GUID").Value = DT.Rows(I)("GUID").ToString
                DGV.Rows(RO_).Cells("account_name").Value = DT.Rows(I)("account_name").ToString
                DGV.Rows(RO_).Cells("account_no").Value = DT.Rows(I)("account_no").ToString
                DGV.Rows(RO_).Cells("ACC").Value = DT.Rows(I)("ACC").ToString
                RO_ += 1
            Next



        End If
    End Sub

    Private Sub FRM_ALL_ACC_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        LOAD_ACCOUNT()
    End Sub



    Private Sub DGV_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DGV.CellDoubleClick
        ACCEPT = True
        Me.Close()
    End Sub

    Private Sub DGV_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DGV.CellFormatting
        AUTO_NUMER_NUM(DGV, Color.SaddleBrown, e, Color.White)
    End Sub

    Private Sub TXT_SEARCH_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TXT_SEARCH.TextChanged
        LOAD_ACCOUNT()
    End Sub

    Private Sub BTN_OK_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BTN_OK.Click
        ACCEPT = True
        Me.Close()
    End Sub

    Private Sub BTN_CANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BTN_CANCEL.Click
        ACCEPT = False
        Me.Close()
    End Sub

    Private Sub BTN_NEW_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BTN_NEW.Click
        Dim F As New FRM_ACCOUNT
        F.NEW_()
        F.ShowDialog()
    End Sub

End Class