

Partial Public Class DataSetScheduler
    Partial Public Class ResourcesDataTable
        Private Sub ResourcesDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.CustomField1Column.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class

Namespace DataSetSchedulerTableAdapters

    Partial Public Class ResourcesTableAdapter
    End Class
End Namespace

Namespace DataSetSchedulerTableAdapters
    Partial Public Class ResourcesTableAdapter
    End Class
End Namespace

Namespace DataSetSchedulerTableAdapters
    Partial Public Class AppointmentsTableAdapter
    End Class
End Namespace
