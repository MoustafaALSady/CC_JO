

Partial Public Class DSCapturingSignatures
    Partial Class Previouspost1DataTable

<<<<<<< HEAD
        Private Sub Previouspost1DataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
=======
        Private Sub Previouspost1DataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If e.Column.ColumnName = Me.account_nameColumn.ColumnName Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
