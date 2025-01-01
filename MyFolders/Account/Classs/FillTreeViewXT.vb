Imports System.Data.SqlClient
Module FillTreeViewXT
    Public NUMBER_FORM As Integer = 0
    Public SHAHEN, AHMAD As String
    Public TREETEXT, AHMAD101 As String
    Public TREENUM As Integer

    Public Sub FindNodeByText(ByVal MTree As TreeView, ByVal Mvalue As String)
        MTree.ExpandAll()
        Dim Node As TreeNode = MTree.Nodes.Item(0)
        While Node IsNot Nothing
            If Node.Text.Contains(Mvalue.Trim) Then
                Node.BackColor = Color.Coral
                Node.Checked = True
                MTree.SelectedNode = Node
            Else
                Node.BackColor = Color.White
                Node.Checked = False
            End If
            Node = Node.NextVisibleNode
        End While
    End Sub
    Public Sub RefreshTree(ByVal XX As FormTreeView)
        XX.TreeView1.BeginUpdate()
        XX.TreeView1.Nodes.Clear()
        XX.TreeView1.TopNode.Expand()
        XX.TreeView1.Select()
        XX.TreeView1.EndUpdate()
        XX.TreeView1.Refresh()
    End Sub
    Public Sub OptionsA()
        Dim oba1 As String
        Dim oba2 As String
        Dim oba3 As String
        Dim oba4 As String
        Dim oba5 As String
        Dim oba6 As String
        Dim oba7 As String
        Dim oba8 As String
        Dim oba9 As String
        oba1 = mykey.GetValue("Openingbalance1", "False")
        oba2 = mykey.GetValue("Openingbalance2", "False")
        oba3 = mykey.GetValue("Openingbalance3", "False")
        oba4 = mykey.GetValue("Openingbalance4", "False")
        oba5 = mykey.GetValue("Openingbalance5", "False")
        oba6 = mykey.GetValue("Openingbalance6", "False")
        oba7 = mykey.GetValue("Openingbalance7", "False")
        oba8 = mykey.GetValue("Openingbalance8", "False")
        oba9 = mykey.GetValue("Openingbalance9", "False")
        If oba1 = True Then
            OBCHK1 = True
        Else
            OBCHK1 = False
        End If
        If oba2 = True Then
            OBCHK2 = True
        Else
            OBCHK2 = False
        End If
        If oba3 = True Then
            OBCHK3 = True
        Else
            OBCHK3 = False
        End If
        If oba4 = True Then
            OBCHK4 = True
        Else
            OBCHK4 = False
        End If
        If oba5 = True Then
            OBCHK5 = True
        Else
            OBCHK5 = False
        End If
        If oba6 = True Then
            OBCHK6 = True
        Else
            OBCHK6 = False
        End If
        If oba7 = True Then
            OBCHK7 = True
        Else
            OBCHK7 = False
        End If
        If oba8 = True Then
            OBCHK8 = True
        Else
            OBCHK8 = False
        End If
        If oba9 = True Then
            OBCHK9 = True
        Else
            OBCHK9 = False
        End If
    End Sub
    Public Function SELECT_QUARY(ByVal TXT_QUARY As String) As DataTable
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim DT As New DataTable
        DT.Clear()
        Dim DA As New SqlDataAdapter(TXT_QUARY, Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        DA.Fill(DT)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Return DT
    End Function

End Module
