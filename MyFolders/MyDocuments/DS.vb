

Partial Public Class DSCapturingSignatures
    Partial Class Previouspost1DataTable

        Private Sub Previouspost1DataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If e.Column.ColumnName = Me.account_nameColumn.ColumnName Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
