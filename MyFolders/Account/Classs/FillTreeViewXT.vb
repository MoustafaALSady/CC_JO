﻿Imports System.Data.SqlClient
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
        Dim openingBalances As String() = {"Openingbalance1", "Openingbalance2", "Openingbalance3", "Openingbalance4", "Openingbalance5", "Openingbalance6", "Openingbalance7", "Openingbalance8", "Openingbalance9"}
        Dim OBCHK() As Boolean = {OBCHK1, OBCHK2, OBCHK3, OBCHK4, OBCHK5, OBCHK6, OBCHK7, OBCHK8, OBCHK9}

        For i As Integer = 0 To openingBalances.Length - 1
            OBCHK(i) = mykey.GetValue(openingBalances(i), "False") = "True"
        Next

        OBCHK1 = OBCHK(0)
        OBCHK2 = OBCHK(1)
        OBCHK3 = OBCHK(2)
        OBCHK4 = OBCHK(3)
        OBCHK5 = OBCHK(4)
        OBCHK6 = OBCHK(5)
        OBCHK7 = OBCHK(6)
        OBCHK8 = OBCHK(7)
        OBCHK9 = OBCHK(8)
    End Sub




    Public Function SELECT_QUARY(ByVal TXT_QUARY As String) As DataTable
        Dim DT As New DataTable
        Using Consum As New SqlConnection(constring)
            Using DA As New SqlDataAdapter(TXT_QUARY, Consum)
                Try
                    Consum.Open()
                    DA.Fill(DT)
                Catch ex As Exception
                    ' Handle exception (e.g., log it)
                Finally
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                End Try
            End Using
        End Using
        Return DT
    End Function

End Module
