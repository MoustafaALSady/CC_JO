Imports System.Data.SqlClient
Module MD_PUBLIC
    Public NUMBER_CHECK As Integer = 0
    Public Sub AUTO_NUMER_NUM(ByVal DGV As DataGridView, ByVal CLR As Color, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs, ByVal FON As Color)
        Try
            Dim ROW = DGV.Rows(e.RowIndex)
            Dim CELL = ROW.Cells(0)
            If Not ROW.IsNewRow Then
                Dim NUMBER As Integer = e.RowIndex + 1.ToString(System.Globalization.CultureInfo.CurrentUICulture)
                CELL.Value = NUMBER.ToString
                CELL.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                CELL.Style.ForeColor = FON
                CELL.Style.BackColor = CLR
            End If

        Catch ex As Exception

        End Try
    End Sub


    Public Function CHECK_FOR_AD(ByVal COL As String, ByVal TB_ As String, ByVal NAME_ As String) As DataTable
        Dim DT As New DataTable
        DT.Clear()
        DT = SELECT_QUARY("SELECT " & COL & " FROM " & TB_ & " WHERE (" & COL & " = '" & NAME_ & "'  )")
        If DT.Rows.Count > 0 Then
            NUMBER_CHECK = 1
        Else
            NUMBER_CHECK = 0
        End If
        Return DT
    End Function
    Public Function CHECK_FOR_UPDATE(ByVal COL As String, ByVal TB_ As String, ByVal NAME_ As String, ByVal GUID_ As String) As DataTable
        Dim DT As New DataTable
        DT.Clear()
        DT = SELECT_QUARY("SELECT " & COL & " FROM " & TB_ & " WHERE (" & COL & " = '" & NAME_ & "'  )AND(GUID<> '" & GUID_ & "')")
        If DT.Rows.Count > 0 Then
            NUMBER_CHECK = 1
        Else
            NUMBER_CHECK = 0
        End If
        Return DT
    End Function
    Public Function CHECK_ACTIV(ByVal GUID As String) As DataTable
        Dim DT As New DataTable
        DT.Clear()
        DT = SELECT_QUARY("SELECT ACTIVAT FROM ACCOUNTSTREE  WHERE GUID= '" & GUID & "' ")
        If DT.Rows.Count > 0 Then
            NUMBER_CHECK = DT.Rows(0)("ACTIVAT").ToString
        End If
        Return DT
    End Function

    Public Sub ACTIVAT(ByVal GUID As String, ByVal VAL_ As Integer)
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim UPDATE_STRING As String = "UPDATE [ACCOUNTSTREE] SET [ACTIVAT]=@ACTIVAT WHERE GUID= '" & GUID & "'"
            Dim CMD As New SqlCommand(UPDATE_STRING, Consum)
            CMD.Parameters.Add(New SqlParameter("@ACTIVAT", SqlDbType.Int)).Value = VAL_
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Consum.Close()
        End Try
    End Sub


End Module
