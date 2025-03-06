Option Explicit Off
Imports System.Data.SqlClient
Public Class FormTreeView
<<<<<<< HEAD
    Inherits Form
    Dim WithEvents BS As New BindingSource
    Dim ds As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter
=======
    Inherits System.Windows.Forms.Form
    Dim WithEvents BS As New BindingSource
    Dim ds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public WithEvents RefreshTab As System.ComponentModel.BackgroundWorker

    Dim RowCount As Integer = 0
    Private Acc_Level As Integer ' متغير خاص بتحدسد مستوى الحساب
    Private Acc_Leve2 As String = 0
    Private AccLevel As Integer
    Private Acc_Name As String ' متغير خاص بإسم الحساب الذي سيتم ارساله لشاشة التعامل مع الحسابات كما أوضحت في الشرح في المدونة
    Private Acc_Name1 As String
    Private Acc_Name2 As String
    Private Acc_Name3 As String
    Private Acc_Index As String ' متغير يسجل فيه التكست الخاص بالفرع الذي تم اختياره من الشجرة
    Private Acc_ID As String
    Private Acc_ID1 As Integer
    Private Acc_ID2 As Integer
    Private New_ID As String ' المتغير

<<<<<<< HEAD
    Public Sub FormTreeView_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
=======
    Public Sub FormTreeView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next

<<<<<<< HEAD
            Me.ConnectDataBase = New ComponentModel.BackgroundWorker With {
=======
            Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.ConnectDataBase.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Call CloseDB()
        End Try
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim strSQL As New SqlCommand("SELECT  acc1, GUID, END_ACCOUNT, PARTENT_ACCOUNT, COUINT_ACCOUNT, acc, account_no, account_name, acc4, account_belong, acc6, acc7, acc8, acc9, acc10, acc11, acc12  FROM ACCOUNTSTREE ORDER BY account_no", Consum)
            Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
            Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
            Me.ds.Clear()
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.ds, "ACCOUNTSTREE")
            Me.BS.DataSource = Me.ds
            Me.BS.DataMember = "ACCOUNTSTREE"
            Consum.Close()
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            'If TestNet = True Then
            'Me.Label5.Visible = True
            'Me.Label5.ForeColor = Color.Yellow
            'Me.Label5.Text = "فضلا انتظر قليلا .. يتم تحميل سجلات الحقل"
            'Else
            'Me.Label5.ForeColor = Color.Red
            'Me.Label5.Text = "الاتصال بالانترنت غير متوفر"
            '    Me.Close()
            'End If
        End If
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.ds.Tables("ACCOUNTSTREE")
            Me.RowCount = BS.Count
            Me.TextACC1.DataBindings.Add("text", Me.BS, "acc1", True, 1, "")
            Me.TextPARTENT_ACCOUNT.DataBindings.Add("text", Me.BS, "PARTENT_ACCOUNT", True, 1, "")
            Me.CreateTree()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            Me.ds.Clear()
            Me.ds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.ds, "ACCOUNTSTREE")
            Me.TreeView1.Refresh()
        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                TestNet = False
                e.Cancel = True
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                e.Cancel = True
                MessageBox.Show(ex.Message, "ErrorRefreshDoWork", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Try
    End Sub
    Public Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.ds.Tables("ACCOUNTSTREE")
            Me.TreeView1.Nodes.Clear()
            Me.CreateTree()
            Me.PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            'If DelRow = False Then
            '    If Me.BS.Count < Me.RowCount Then
            '        MsgBox(" تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 48 + 524288, "تحديث السجلات")
            '    ElseIf Me.BS.Count > Me.RowCount Then
            '        MsgBox(" تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 48 + 524288, "تحديث السجلات")
            '    End If
            'Else
            '    Me.DelRow = False
            'End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "ErrorRefreshRunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Public Sub Refsh()
        'On Error Resume Next
<<<<<<< HEAD
        Me.RefreshTab = New ComponentModel.BackgroundWorker With {
=======
        Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.RefreshTab.RunWorkerAsync()
        Me.TreeView1.Refresh()
    End Sub
    Private Sub MAXRECORD()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim f As New FRM_ACCOUNT
        Dim V As Integer
        Dim SQL As New SqlCommand("SELECT MAX(ACC1) FROM ACCOUNTSTREE", Consum)
        Dim CMD As New SqlCommand
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FRM_ACCOUNT
        Dim V As Integer
        Dim SQL As New SqlCommand("SELECT MAX(ACC1) FROM ACCOUNTSTREE", Consum)
        Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        If IsDBNull(resualt) Then
            V = 1
        Else
            V = CType(resualt, Integer) + 1
        End If
        f.TextACC11.Text = V
        Consum.Close()
    End Sub
<<<<<<< HEAD
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
=======
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FRM_ACCOUNT
        Try
            Dim V As Integer
            Dim SQL As New SqlCommand("SELECT MAX(ACC1) FROM ACCOUNTSTREE", Consum)
<<<<<<< HEAD
            Dim CMD As New SqlCommand
=======
            Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                .CommandText = SQL.CommandText
            End With
            Dim resualt As Object = CMD.ExecuteScalar()
            If IsDBNull(resualt) Then
                V = 1
            Else
                V = CType(resualt, Integer) + 1
            End If
            f.TextACC11.Text = V
            f.TXT_Account_Name.Text = ""
            f.TXT_Account_Name.Focus()
            f.TXT_Account_NO.Text = New_ID + 1
            f.Text_ACC_FATHER.Text = Acc_Name
            f.TextlblGROUPACCOUNT.Text = Acc_Name1
            f.TextAccountLevel.Text = Acc_Name2
            f.TextlblFIRSTDEBIT.Text = "0"
            f.TextlblFIRSTCREDIT.Text = "0"
            f.TXT_ACC.Text = AccLevel
            f.CheckMasterAccount.Checked = Me.CheckMasterAccount.Checked
            f.Show()
            f.SAVEBUTTON.Enabled = True
            f.EDITBUTTON.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Consum.Close()
    End Sub
    Private Sub CreateTree()
        Me.TreeView1.BeginUpdate()
        Me.TreeView1.Nodes.Clear()
        Dim MainHeader As New TreeNode("دليل الحسابات") With {
            .Tag = New TagField("رئيسي", Nothing, Nothing, Nothing, Nothing, Nothing),
            .ImageIndex = 1
        }
        Me.TreeView1.Nodes.Add(MainHeader)
        Me.AddSubNode(MainHeader)
        Me.TreeView1.TopNode.Expand()
        Me.TreeView1.Select()
        Me.TreeView1.EndUpdate()
        Me.TreeView1.Refresh()
    End Sub
    Private Sub AddSubNode(ByVal Node As TreeNode)
        Dim unused As New TagField
        Dim Ta1 As New TagField
        Dim Ta As TagField = DirectCast(Node.Tag, TagField)
        Me.BS.DataSource = Me.ds.Tables("ACCOUNTSTREE").DefaultView
        Me.BS.Filter = "ACC4 ='" & Ta.acc_name.Trim & "'"
        Dim cridet As Double = 0
        Dim dept As Double = 0
        Try
            For Each drLine As DataRowView In Me.BS
                Dim SubNode As New TreeNode(drLine("account_no").ToString & "-" & drLine("account_name").ToString)
                Ta = New TagField(drLine("account_name"), drLine("account_no"), drLine("account_belong"), cridet - dept, cridet, dept)
                SubNode.Tag = Ta
                SubNode.ImageIndex = Node.Level + 1
                If CType(Node.Tag, TagField).acc_name = "رئيسي" Then
                    Me.TreeView1.Nodes.Add(SubNode)
                Else
                    Node.Nodes.Add(SubNode)
                End If
                If SubNode.Tag IsNot Nothing Then
                    AddSubNode(SubNode)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Class TagField
        Public Sub New()
        End Sub
        Public Sub New(ByVal na As String, ByVal no As Integer, ByVal bl As String, ByVal bal As Double, ByVal crd As Double, ByVal dep As Double)
            acc_name = na
            acc_no = no
            acc_blng = bl
            acc_bal = bal
            acc_crd = crd
            acc_dep = dep
        End Sub
        Public acc_no As Integer = 0
        Public acc_name As String = String.Empty
        Public acc_blng As String = String.Empty
        Public acc_bal As Double = 0.0
        Public acc_crd As Double = 0.0
        Public acc_dep As Double = 0.0
    End Class
<<<<<<< HEAD
    Private Sub TreeView1_NodeMouseClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsql1 As New SqlCommand("SELECT * FROM ACCOUNTSTREE WHERE account_no = '" & Split(e.Node.Text, "-")(0) & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql1)
=======
    Private Sub TreeView1_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql1 As New SqlCommand("SELECT * FROM ACCOUNTSTREE WHERE account_no = '" & Split(e.Node.Text, "-")(0) & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.Acc_Name3 = ds.Tables(0).Rows(0).Item("account_name")
            Me.Acc_Name1 = ds.Tables(0).Rows(0).Item("account_belong")
            Me.Acc_Name2 = ds.Tables(0).Rows(0).Item("acc6")
            Me.AccLevel = Val(ds.Tables(0).Rows(0).Item("acc"))
            Me.TextACC1.Text = Val(ds.Tables(0).Rows(0).Item("ACC1"))
            Me.TextPARTENT_ACCOUNT.Text = ds.Tables(0).Rows(0).Item("PARTENT_ACCOUNT").ToString
            Me.CheckMasterAccount.Checked = Val(ds.Tables(0).Rows(0).Item("ACC12"))
        End If
        Adp.Dispose()
        Consum.Close()
        If Me.TextPARTENT_ACCOUNT.Text = "00000000-0000-0000-0000-000000000000" Then
            Me.MenuItem4.Visible = False
            Me.EDITBUTTON.Enabled = False
        Else
            Me.MenuItem4.Visible = True
            Me.EDITBUTTON.Enabled = True
        End If
        If Me.TreeView1.SelectedNode.Level = 1 Then
            Me.MenuItem4.Visible = False
            Me.EDITBUTTON.Enabled = False
        ElseIf Me.TreeView1.SelectedNode.Level = 2 Then
            If Me.TreeView1.SelectedNode.Nodes.Count = 0 Then
                Me.MenuItem4.Visible = True
                Me.EDITBUTTON.Enabled = True
            Else
                Me.MenuItem4.Visible = False
                Me.EDITBUTTON.Enabled = False
            End If
        Else
            Me.MenuItem4.Visible = True
            Me.EDITBUTTON.Enabled = True
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        For Each row As DataRowView In BS
        Next
        Me.BS.Filter = Nothing
        Me.BS.Filter = "(account_name='" & Split(Me.TreeView1.SelectedNode.Text, "-")(1) & "')"
        Dim strsql1 As New SqlCommand("SELECT * FROM ACCOUNTSTREE WHERE account_no = '" & Split(Me.TreeView1.SelectedNode.Text, "-")(0) & "'", Consum)
        Dim ds As New DataSet
<<<<<<< HEAD
        Adp = New SqlDataAdapter(strsql1)
=======
        Adp = New SqlClient.SqlDataAdapter(strsql1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            'Acc_ID1 = ds.Tables(0).Rows(0).Item("account_no")
            Me.Acc_Name3 = ds.Tables(0).Rows(0).Item("account_name")
            Me.Acc_Name1 = ds.Tables(0).Rows(0).Item("account_belong")
            Me.Acc_Name2 = ds.Tables(0).Rows(0).Item("acc6")
            Me.AccLevel = Val(ds.Tables(0).Rows(0).Item("acc"))
            Me.TextACC1.Text = Val(ds.Tables(0).Rows(0).Item("ACC1"))
            Me.TextPARTENT_ACCOUNT.Text = ds.Tables(0).Rows(0).Item("PARTENT_ACCOUNT").ToString
            Me.CheckMasterAccount.Checked = Val(ds.Tables(0).Rows(0).Item("ACC12"))
        End If
        Adp.Dispose()
        Consum.Close()
        If Me.TextPARTENT_ACCOUNT.Text = "00000000-0000-0000-0000-000000000000" Then
            Me.MenuItem4.Visible = False
            Me.EDITBUTTON.Enabled = False
        Else
            Me.MenuItem4.Visible = True
            Me.EDITBUTTON.Enabled = True
        End If
        If Me.TreeView1.SelectedNode.Level < 4 Then
            Me.Acc_Level = Me.TreeView1.SelectedNode.Level
            Me.Acc_Name = Split(Me.TreeView1.SelectedNode.Text, "-")(1)
            Me.Acc_ID = Split(Me.TreeView1.SelectedNode.Text, "-")(0)
            If Me.TreeView1.SelectedNode.Nodes.Count > 0 Then
                Me.Acc_Index = Me.TreeView1.SelectedNode.Nodes(Me.TreeView1.SelectedNode.Nodes.Count - 1).Text
                Me.Acc_ID1 = Split(Me.TreeView1.SelectedNode.Text, "-")(0)
                Me.New_ID = Split(Acc_Index, "-")(0)
                Me.Acc_ID2 = Me.Acc_ID1
                If Me.TreeView1.SelectedNode.Level = 1 Then
                    Me.MenuItem4.Visible = False
                    Me.EDITBUTTON.Enabled = False
                ElseIf Me.TreeView1.SelectedNode.Level = 2 Then
                    If Me.TreeView1.SelectedNode.Nodes.Count = 0 Then
                        Me.MenuItem4.Visible = True
                        Me.EDITBUTTON.Enabled = True
                    Else
                        Me.MenuItem4.Visible = False
                        Me.EDITBUTTON.Enabled = False
                    End If
                Else
                    Me.MenuItem4.Visible = True
                    Me.EDITBUTTON.Enabled = True
                End If
            ElseIf Me.TreeView1.SelectedNode.Nodes.Count = 0 Then
                If Me.TreeView1.SelectedNode.Level = 1 Then
                    Me.MenuItem4.Visible = False
                    Me.EDITBUTTON.Enabled = False
                ElseIf Me.TreeView1.SelectedNode.Level = 2 Then
                    If Me.TreeView1.SelectedNode.Nodes.Count = 0 Then
                        Me.MenuItem4.Visible = True
                        Me.EDITBUTTON.Enabled = True
                    Else
                        Me.MenuItem4.Visible = False
                        Me.EDITBUTTON.Enabled = False
                    End If
                Else
                    Me.MenuItem4.Visible = True
                    Me.EDITBUTTON.Enabled = True
                End If
                Select Case CType(Me.Acc_Level, Integer)
                    Case 1
                        Me.New_ID = Me.Acc_ID & "00"
                        Me.Acc_Leve2 = "00"
                    Case 2
                        Me.New_ID = Me.Acc_ID & "00"
                        Me.Acc_Leve2 = "00"
                    Case 3, 4
                        Me.New_ID = Me.Acc_ID & "00"
                        Me.Acc_Leve2 = "00"
                End Select
            End If
        Else
            Exit Sub
        End If
    End Sub

    '    Sub AddChildNodeData(ByVal node As TreeNode)
    '        For i As Integer = 0 To node.Nodes.Count - 1
    '            Dim t As New TagField
    '            t = DirectCast(node.Nodes(i).Tag, TagField)
    '            'If t.acc_crd > 0 Or t.acc_dep > 0 Then
    '            ' tot_crd += DirectCast(node.Nodes(i).Tag, TagField).acc_crd
    '            ' tot_dep += DirectCast(node.Nodes(i).Tag, TagField).acc_dep
    '            '  DataGridView1.Rows.Add(node.Nodes(i).Text, t.acc_name, t.acc_crd, t.acc_dep, tot_crd - tot_dep, t.acc_no)
    '            ' End If
    '7:          '  DataGridView1.Rows.Add(node.Nodes(i).Text, node.Nodes(i).Tag)
    '            AddChildNodeData(node.Nodes(i))
    '        Next i
    '    End Sub
<<<<<<< HEAD
    Private Sub FormTreeView_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
=======
    Private Sub FormTreeView_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Me.BS.Filter IsNot Nothing Then
            Me.BS.Filter = Nothing
        End If
        Me.BS.CancelEdit()
        Me.ds.RejectChanges()
    End Sub
<<<<<<< HEAD
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
=======
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim ds As New DataSet
<<<<<<< HEAD
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FRM_ACCOUNT
        Try
            If Me.TreeView1.SelectedNode.Level < 4 Then
                If Me.TreeView1.SelectedNode.Nodes.Count > 0 Then
                    Me.Acc_ID1 = Split(Me.TreeView1.SelectedNode.Text, "-")(0)
                    Acc_ID2 = Me.Acc_ID1
                ElseIf Me.TreeView1.SelectedNode.Nodes.Count = 0 Then
                    Me.Acc_ID1 = Split(Me.TreeView1.SelectedNode.Text, "-")(0)
                    'MsgBox(Acc_ID1)
                    Select Case CType(Me.Acc_Level, Integer)
                        Case 1
                            Me.New_ID = Me.Acc_ID & "00"
                            Me.Acc_Leve2 = "00"
                        Case 2
                            Me.New_ID = Acc_ID & "00"
                            Me.Acc_Leve2 = "00"
                        Case 3, 4
                            Me.New_ID = Acc_ID & "00"
                            Me.Acc_Leve2 = "00"
                    End Select
                End If
            Else
                Exit Sub
            End If
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT account_no FROM ACCOUNTSTREE", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "ACCOUNTSTREE")
            f.BS.DataMember = "ACCOUNTSTREE"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("account_no", Split(Me.TreeView1.SelectedNode.Text, "-")(0))
            f.TB1 = Trim(Split(Me.TreeView1.SelectedNode.Text, "-")(0))
            f.TextACC1.Text = Me.Acc_ID2
            f.TXT_Account_NO1.Text = Me.Acc_Leve2
            f.Show()
            f.ConnectData()
            f.BS.Position = index
            f.TextACC11.Enabled = False
            f.SAVEBUTTON.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub
<<<<<<< HEAD
    Private Sub TreeView1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TreeView1.DoubleClick
=======
    Private Sub TreeView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.DoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'If InternalAuditor = False Then
        '    MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
        '    Exit Sub
        'End If
        'Dim ds As New DataSet
        'Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        'Dim Consum As New SqlClient.SqlConnection(constring)
        'Dim f As New FRM_ACCOUNT
        'Try
        '    If Me.TreeView1.SelectedNode.Level < 4 Then
        '        If Me.TreeView1.SelectedNode.Nodes.Count > 0 Then
        '            Acc_ID1 = Split(Me.TreeView1.SelectedNode.Text, "-")(0)
        '        ElseIf Me.TreeView1.SelectedNode.Nodes.Count = 0 Then
        '            Select Case CType(Me.Acc_Level, Integer)
        '                Case 1
        '                    New_ID = Acc_ID & "00"
        '                    Acc_Leve2 = "00"
        '                Case 2
        '                    New_ID = Acc_ID & "00"
        '                    Acc_Leve2 = "00"
        '                Case 3, 4
        '                    New_ID = Acc_ID & "00"
        '                    Acc_Leve2 = "00"
        '            End Select
        '        End If
        '    Else
        '        Exit Sub
        '    End If
        '    ds.EnforceConstraints = False
        '    Dim str As New SqlCommand("SELECT account_no FROM ACCOUNTSTREE", Consum)
        '    SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
        '    Dim builder33 As SqlClient.SqlCommandBuilder = New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
        '    ds.Clear()
        '    SqlDataAdapter1.Fill(ds, "ACCOUNTSTREE")
        '    f.BS.DataMember = "ACCOUNTSTREE"
        '    f.BS.DataSource = ds
        '    Dim index As Integer
        '    index = f.BS.Find("account_no", Split(Me.TreeView1.SelectedNode.Text, "-")(0))
        '    f.TB1 = Trim(Split(Me.TreeView1.SelectedNode.Text, "-")(0))
        '    f.Acc_Level = Acc_Leve2
        '    f.TextBox2.Text = Acc_ID2
        '    f.TextBox3.Text = Acc_Leve2
        '    f.Show()
        '    f.ConnectData()
        '    f.BS.Position = index
        '    f.TextBox1.Enabled = False
        '    f.Button1.Enabled = False
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        'SqlDataAdapter1.Dispose()
        'Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub ButtonUpdateA_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonUpdateA.Click
        Me.Refsh()
    End Sub
    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MenuItem1.Click
        Me.TreeView1.CollapseAll()
    End Sub
    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MenuItem2.Click
        Me.TreeView1.ExpandAll()
    End Sub
    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MenuItem3.Click
        Me.ADDBUTTON_Click(sender, e)
    End Sub
    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MenuItem4.Click
=======
    Private Sub ButtonUpdateA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateA.Click
        Me.Refsh()
    End Sub
    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.TreeView1.CollapseAll()
    End Sub
    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Me.TreeView1.ExpandAll()
    End Sub
    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Me.ADDBUTTON_Click(sender, e)
    End Sub
    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.EDITBUTTON_Click(sender, e)
    End Sub



<<<<<<< HEAD
    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnSearch.Click
        Dim Consum As New SqlConnection(constring)
        Dim StrSQL As String = "Select * From ACCOUNTSTREE  Where account_name Like '%" & Me.TxtSearch.Text & "%'"
        If Consum.State = ConnectionState.Closed Then Consum.Open()
        Dim da As New SqlDataAdapter(StrSQL, Consum)
=======
    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim StrSQL As String = "Select * From ACCOUNTSTREE  Where account_name Like '%" & Me.TxtSearch.Text & "%'"
        If Consum.State = ConnectionState.Closed Then Consum.Open()
        Dim da As New SqlClient.SqlDataAdapter(StrSQL, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Me.TreeView1.SelectedNode = Nothing
        FindNodeByText(Me.TreeView1, Me.TxtSearch.Text)
    End Sub


End Class