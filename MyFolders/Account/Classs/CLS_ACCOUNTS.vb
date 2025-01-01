Public Class CLS_ACCOUNTS
    Public Shared Function LOAD_TYPE_ACCOUNTS() As DataTable

        Dim DT As New DataTable
        DT.Clear()
        DT = SELECT_QUARY("SELECT *    FROM TB_TYPE_ACCOUNTS  ORDER BY ID")
        Return DT
    End Function
    Public Shared Function LOAD_ACCOUNTSCheck() As DataTable
        Dim DT As New DataTable
        DT.Clear()
        DT = SELECT_QUARY("SELECT   account_name FROM ACCOUNTSTREE WHERE PARTENT_ACCOUNT <> '00000000-0000-0000-0000-000000000000' AND ACC10 ='KS' ORDER BY account_no")
        Return DT
    End Function

    Public Shared Function LOAD_ACCOUNTS(ByVal ACC As Integer) As DataTable
        Dim DT As New DataTable
        DT.Clear()
        DT = SELECT_QUARY("SELECT   account_name FROM ACCOUNTSTREE WHERE PARTENT_ACCOUNT <> '00000000-0000-0000-0000-000000000000'AND ACC =  '" & ACC & "'  ORDER BY account_no")
        Return DT
    End Function

    Public Shared Function LOAD_END_ACCOUNTS() As DataTable
        Dim DT As New DataTable
        DT.Clear()
        DT = SELECT_QUARY("SELECT AND_ACCOUNTS.ID, AND_ACCOUNTS.NAME  FROM(AND_ACCOUNTS) ORDER BY AND_ACCOUNTS.ID")
        Return DT
    End Function

    Public Shared Function SEARCH_ACCOUNTS(ByVal NAME As String) As DataTable
        Dim DT As New DataTable
        DT.Clear()
        If NUMBER_FORM = 0 Then
            DT = SELECT_QUARY("SELECT GUID, account_no, account_name, ACC   FROM ACCOUNTSTREE    WHERE account_name LIKE '%' + '" & NAME & "' + '%' ORDER BY account_no")
        ElseIf NUMBER_FORM = 1 Then
            DT = SELECT_QUARY("SELECT GUID, account_no, account_name, ACC   FROM ACCOUNTSTREE    WHERE PARTENT_ACCOUNT <> '00000000-0000-0000-0000-000000000000'AND account_name LIKE '%' + '" & NAME & "' + '%' ORDER BY account_no")
            'ElseIf NUMBER_FORM = 2 Then
            '    SELECT_QUARY("")
        End If
        Return DT
    End Function

    Public Shared Function MAX_ACCOUNT(ByVal PARENTGUID As String) As DataTable
        Dim DT As New DataTable
        DT.Clear()
        DT = SELECT_QUARY("SELECT MAX(account_no)+1 FROM ACCOUNTSTREE WHERE PARTENT_ACCOUNT ='" & PARENTGUID & " '")
        Return DT
    End Function

    Public Shared Function SHOW_ACCOUNT(ByVal GUID As String) As DataTable
        Dim DT As New DataTable
        DT.Clear()
        DT = SELECT_QUARY("SELECT * FROM ACCOUNTSTREE WHERE GUID='" & GUID & "' ")
        Return DT
    End Function

    Public Shared Function COUNT_ACCOUNTS(ByVal PARENTGUID As String) As DataTable
        Dim DT As New DataTable
        DT.Clear()
        DT = SELECT_QUARY("SELECT Count(ACC1) AS COUNT_ACCOUNTS    FROM ACCOUNTSTREE WHERE PARTENT_ACCOUNT='" & PARENTGUID & "' ")
        Return DT
    End Function

    Public Shared Function SHOW_PARENTGUID(ByVal GUID As String) As DataTable
        Dim DT As New DataTable
        DT.Clear()
        DT = SELECT_QUARY("SELECT PARTENT_ACCOUNT FROM ACCOUNTSTREE WHERE GUID='" & GUID & "' ")
        Return DT
    End Function
    Public Shared Function SHOW_PARENTGUID1(ByVal GUID As String) As DataTable
        Dim DT As New DataTable
        DT.Clear()
        DT = SELECT_QUARY("SELECT PARTENT_ACCOUNT FROM ACCOUNTSTREE WHERE GUID='" & GUID & "' ")
        Return DT
    End Function
    Public Shared Function SELECT_ALL_ACCOUNTS() As DataTable
        Dim DT As New DataTable
        DT.Clear()
        DT = SELECT_QUARY("SELECT *    FROM ACCOUNTSTREE  ORDER BY ACC1")
        Return DT
    End Function
    Public Shared Function SELECT_SONS_ACCOUNTS(ByVal GUID As String) As DataTable
        Dim DT As New DataTable
        DT.Clear()
        DT = SELECT_QUARY("SELECT *    FROM ACCOUNTSTREE WHERE PARTENT_ACCOUNT  ='" & GUID & "'   ORDER BY ACC1")
        Return DT
    End Function
End Class
