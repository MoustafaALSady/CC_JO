Imports System.Data.SqlClient
Imports System.Guid
Public Class FRM_ACCOUNT
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim ds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()

    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0



    Public Acc_Level As String ' „ €Ì— Œ«’ » Õœ”œ „” ÊÏ «·Õ”«»
    Public TB1 As String
    Public CODE1 As String = "0"
    Public CODE2 As String = "0"
    Public CODEGUID As String = ""

    Dim ACCA As Integer


    Private Sub FRM_ACCOUNT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        'Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        If Text_ACC_FATHER.Text = "«·’‰œÊﬁ" Or TXT_Account_Name.Text = "«·’‰œÊﬁ" Then
            TextAccountPrivate.Text = "CH"
        End If
        If Text_ACC_FATHER.Text = "«·»‰ﬂ" Or TXT_Account_Name.Text = "«·»‰ﬂ" Then
            TextAccountPrivate.Text = "BA"
        End If
        If Text_ACC_FATHER.Text = "‘Ìﬂ« " Or TXT_Account_Name.Text = "‘Ìﬂ«  Ê«—œ…" Or TXT_Account_Name.Text = "Õ«›Ÿ… «·‘Ìﬂ« " Or
            TXT_Account_Name.Text = "‘Ìﬂ«  „Êœ∆⁄… ›Ì «·»‰ﬂ  Õ  «· Õ’Ì·" Or TXT_Account_Name.Text = "‘Ìﬂ«  „— Ã⁄… (Ê«—œ…)" Or
            TXT_Account_Name.Text = "‘Ìﬂ«  „— Ã⁄… ›Ì «·»‰ﬂ" Or TXT_Account_Name.Text = "‘Ìﬂ«  ’«œ—Â ( „ƒÃ·… )" Or
            TXT_Account_Name.Text = "‘Ìﬂ«  „— Ã⁄… (’«œ—Â)" Then
            TextAccountPrivate.Text = "KS"
        End If
    End Sub

    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())


            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlCommand("SELECT    ACC1, GUID, END_ACCOUNT, PARTENT_ACCOUNT, COUINT_ACCOUNT, ACC, account_no, account_name, ACC4, account_belong, ACC6, ACC7, ACC8, ACC9, ACC10, ACC11, ACC12 FROM ACCOUNTSTREE WHERE account_no='" & TB1 & "'", Consum)

            Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
            Me.ds.Clear()
            Consum.Open()
            Me.ds = New DataSet
            Me.SqlDataAdapter1.Fill(ds, "ACCOUNTSTREE")
            Me.BS.DataSource = ds
            Me.BS.DataMember = "ACCOUNTSTREE"
            Consum.Close()
            Select Case Me.TXT_ACC.Text
                Case 1
                    Me.CheckMasterAccount.Checked = True
                Case 2
                    Me.CheckMasterAccount.Checked = True
                Case 3
                    Me.CheckMasterAccount.Checked = True
                Case 4
                    Me.CheckMasterAccount.Checked = True
            End Select

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
        If TestNet = True Then
            'Me.LabelAccountPrivate.ForeColor = Color.Yellow
        Else
            Me.Close()
        End If
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.ds.Tables("ACCOUNTSTREE")

            Me.RowCount = Me.BS.Count
            Me.TextACC11.DataBindings.Add("text", Me.BS, "ACC1", True, 1, "")

            Me.TXT_GUID.DataBindings.Add("text", Me.BS, "GUID", True, 1, "")
            Me.TXT_END_ACCOUNT.DataBindings.Add("text", Me.BS, "END_ACCOUNT", True, 1, "")
            Me.TXT_PARENT_GUID.DataBindings.Add("text", Me.BS, "PARTENT_ACCOUNT", True, 1, "")
            Me.TXT_COUINT_ACCOUNT.DataBindings.Add("text", Me.BS, "COUINT_ACCOUNT", True, 1, "")

            Me.TXT_ACC.DataBindings.Add("text", Me.BS, "ACC", True, 1, "")
            Me.TXT_Account_NO.DataBindings.Add("text", Me.BS, "account_no", True, 1, "")
            Me.TXT_Account_Name.DataBindings.Add("text", Me.BS, "account_name", True, 1, "")
            Me.Text_ACC_FATHER.DataBindings.Add("text", Me.BS, "ACC4", True, 1, "")
            Me.TextlblGROUPACCOUNT.DataBindings.Add("text", Me.BS, "account_belong", True, 1, "")
            Me.TextAccountLevel.DataBindings.Add("text", Me.BS, "ACC6", True, 1, "")
            Me.TextlblFIRSTDEBIT.DataBindings.Add("text", Me.BS, "ACC7", True, 1, "")
            Me.TextlblFIRSTCREDIT.DataBindings.Add("text", Me.BS, "ACC8", True, 1, "")
            Me.TextNotes.DataBindings.Add("text", Me.BS, "ACC9", True, 1, "")
            Me.TextAccountPrivate.DataBindings.Add("text", Me.BS, "ACC10", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "ACC11", True, 1, "")
            Me.CheckMasterAccount.DataBindings.Add("Checked", Me.BS, "ACC12", True, 1, "")

            If Text_ACC_FATHER.Text = "«·’‰œÊﬁ" Or TXT_Account_Name.Text = "«·’‰œÊﬁ" Then
                TextAccountPrivate.Text = "CH"
            End If
            If Text_ACC_FATHER.Text = "«·»‰ﬂ" Or TXT_Account_Name.Text = "«·»‰ﬂ" Then
                TextAccountPrivate.Text = "BA"
            End If
            If Text_ACC_FATHER.Text = "‘Ìﬂ« " Or TXT_Account_Name.Text = "‘Ìﬂ«  Ê«—œ…" Or TXT_Account_Name.Text = "Õ«›Ÿ… «·‘Ìﬂ« " Or
                TXT_Account_Name.Text = "‘Ìﬂ«  „Êœ∆⁄… ›Ì «·»‰ﬂ  Õ  «· Õ’Ì·" Or TXT_Account_Name.Text = "‘Ìﬂ«  „— Ã⁄… (Ê«—œ…)" Or
                TXT_Account_Name.Text = "‘Ìﬂ«  „— Ã⁄… ›Ì «·»‰ﬂ" Or TXT_Account_Name.Text = "‘Ìﬂ«  ’«œ—Â ( „ƒÃ·… )" Or
                TXT_Account_Name.Text = "‘Ìﬂ«  „— Ã⁄… (’«œ—Â)" Then
                TextAccountPrivate.Text = "KS"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Sub FIIL_END_ACCOUNT()
    '    Dim DT As New DataTable
    '    DT.Clear()
    '    DT = CLS_ACC.LOAD_END_ACCOUNTS
    '    If DT.Rows.Count > 0 Then
    '        COM_END.DataSource = DT
    '        COM_END.ValueMember = "ID"
    '        COM_END.DisplayMember = "NAME"
    '    End If

    'End Sub
    Sub NEW_()
        'FIIL_END_ACCOUNT()
        'COM_END.SelectedIndex = 0
        TXT_Account_Name.Text = Nothing
        Text_ACC_FATHER.Text = Nothing
        TXT_PARENT_GUID.Text = Nothing
        TXT_GUID.Text = Nothing
        TXT_Account_NO.Text = Nothing
    End Sub
    Sub SHOW_ACCOUNT()
        Dim DT As New DataTable
        DT.Clear()
        DT = CLS_ACCOUNTS.SHOW_ACCOUNT(TXT_GUID.Text)
        If DT.Rows.Count > 0 Then
            TXT_Account_Name.Text = DT.Rows(0)("account_name").ToString
            TXT_PARENT_GUID.Text = DT.Rows(0)("PARTENT_ACCOUNT").ToString
            TXT_ACC.Text = DT.Rows(0)("ACC").ToString
        Else
            NEW_()
        End If

    End Sub
    Sub SHOW_FATHER()
        Dim DT As New DataTable
        DT.Clear()
        DT = CLS_ACCOUNTS.SHOW_ACCOUNT(TXT_PARENT_GUID.Text)
        If DT.Rows.Count > 0 Then
            Text_ACC_FATHER.Text = DT.Rows(0)("account_name").ToString
            TXT_Account_NO.Text = DT.Rows(0)("account_no").ToString
            TXT_ACC.Text = DT.Rows(0)("ACC").ToString
        Else
            Text_ACC_FATHER.Text = Nothing
            TXT_Account_NO.Text = Nothing
            TXT_ACC.Text = Nothing
        End If

    End Sub

    Sub GENRAT()
        Try
            If TXT_END_ACCOUNT.Text <> Nothing Then
                Dim DT As New DataTable
                DT.Clear()
                DT = CLS_ACCOUNTS.MAX_ACCOUNT(TXT_PARENT_GUID.Text)
                If DT.Rows.Count > 0 Then
                    CODE1 = DT.Rows(0)(0).ToString()
                Else
                    CODE1 = "0"
                End If

                If CODE1 = "0" Or CODE1 = Nothing Then
                    CODE1 = TXT_Account_NO.Text & "001"
                End If
                'MsgBox(CODE1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Œÿ«¡", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Me.TextACC1.Text = 0 Then
            MsgBox("ÌÃ»  ÕœÌœ Õ”«» «·«»", 16, " ‰»ÌÂ")
            Exit Sub
        Else
            UPDATE_CODEAA()
        End If

    End Sub


    Sub UPDATE_CODEAA()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim selectCommand As New SqlCommand("SELECT DISTINCT acc1 FROM ACCOUNTSTREE WHERE PARTENT_ACCOUNT = '" & TXT_PARENT_GUID.Text & " '", Consum)
            Dim dataSet As New DataSet
            Dim adapter As New SqlDataAdapter(selectCommand)
            dataSet.Clear()
            Consum.Open()
            adapter.Fill(dataSet, "ACCOUNTSTREE")
            Consum.Close()

            For r As Integer = 0 To dataSet.Tables(0).Rows.Count - 1
                ACCA = dataSet.Tables(0).Rows(r).Item(0)

                Dim r1 As Integer = 0
                Dim row As DataRow = dataSet.Tables(0).Rows(r)
                row.BeginEdit()
                row(0) = r
                r1 = CDbl(row(0))
                If Me.TXT_Account_NO1.Text = "000" Then
                    Select Case CType(r1, Integer)
                        Case 1 To 9
                            Me.TXT_Account_NO1.Text = "000"
                            If r1 + 1 = 10 Then
                                Me.TXT_Account_NO1.Text = "0"
                            End If
                        Case 10 To 99
                            Me.TXT_Account_NO1.Text = "00"
                        Case 100 To 999
                            Me.TXT_Account_NO1.Text = "0"
                    End Select
                ElseIf Me.TXT_Account_NO1.Text = "00" Then
                    Select Case CType(r1, Integer)
                        Case 1 To 9
                            Me.TXT_Account_NO1.Text = "00"
                            If r1 + 1 = 10 Then
                                Me.TXT_Account_NO1.Text = "0"
                            End If
                        Case 10 To 99
                            Me.TXT_Account_NO1.Text = "0"
                    End Select
                End If
                row(0) = Me.TextACC1.Text & Me.TXT_Account_NO1.Text & r1 + 1
                row.EndEdit()
                Dim SQL As New SqlClient.SqlCommand(" UPDATE ACCOUNTSTREE SET  account_no=@account_no  WHERE ACC1  = '" & ACCA & "'", Consum)
                Dim CMD As New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .Connection = Consum
                }
                With CMD
                    .Parameters.AddWithValue("@account_no", row(0))
                    .CommandText = SQL.CommandText
                End With
                'MsgBox(row(0))
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                CMD.Parameters.Clear()
            Next

            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            MsgBox(" „  ⁄„·Ì… ≈⁄«œ…  —ﬁÌ„ «·Õ”«»«  »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Œÿ«¡", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Consum.Close()
        End Try
    End Sub
    Sub UPDATE_CODE()

        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim UPDATE_STRING As String = "UPDATE [ACCOUNTSTREE] SET [account_no]=@account_no WHERE GUID= '" & TXT_GUID.Text & "'"
            Dim CMD As New SqlCommand(UPDATE_STRING, Consum)
            CMD.Parameters.Add(New SqlParameter("@account_no", SqlDbType.VarChar)).Value = CODE1
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Œÿ«¡", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Consum.Close()
        End Try



    End Sub

    Shared Sub UPDATE_SON(ByVal GUID As String)
        Try
            Dim COUNT_ As Integer = 0
            Dim DT As New DataTable
            DT.Clear()
            DT = CLS_ACCOUNTS.COUNT_ACCOUNTS(GUID)
            If DT.Rows.Count > 0 Then
                COUNT_ = DT.Rows(0)("COUNT_ACCOUNTS").ToString
            Else
                COUNT_ = 1
            End If
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim UPDATE_STRING As String = "UPDATE ACCOUNTSTREE SET COUINT_ACCOUNT=@COUINT_ACCOUNT WHERE GUID= '" & GUID & "'"
            Dim CMD As New SqlCommand(UPDATE_STRING, Consum)
            CMD.Parameters.Add(New SqlParameter("@COUINT_ACCOUNT", SqlDbType.Int)).Value = COUNT_
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Œÿ«¡", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Consum.Close()
        End Try
    End Sub

    Private Sub UPDATERECORD()
        Try

            GENRAT()
            Dim PARENTGUID_OLD As String = CLS_ACCOUNTS.SHOW_PARENTGUID(TXT_GUID.Text).Rows(0)(0).ToString

            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim sql As New SqlCommand("UPDATE ACCOUNTSTREE SET  ACC = @ACC, GUID = @GUID, END_ACCOUNT = @END_ACCOUNT, PARTENT_ACCOUNT = @PARTENT_ACCOUNT, COUINT_ACCOUNT = @COUINT_ACCOUNT, account_no = @account_no, account_name = @account_name, ACC4 = @ACC4, account_belong = @account_belong, ACC7 = @ACC7, ACC8 = @ACC8, ACC9 = @ACC9, ACC10 = @ACC10, ACC11 = @ACC11, ACC12 = @ACC12 WHERE ACC1 ='" & Me.TextACC11.Text & "'", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@ACC1", SqlDbType.Int).Value = Me.TextACC11.Text
                .Parameters.Add("@ACC", SqlDbType.Int).Value = Me.TXT_ACC.Text

                .Parameters.Add("@GUID", SqlDbType.NVarChar).Value = Me.TXT_GUID.Text.Trim
                .Parameters.Add("@END_ACCOUNT", SqlDbType.NVarChar).Value = Me.TXT_END_ACCOUNT.Text.Trim
                .Parameters.Add("@PARTENT_ACCOUNT", SqlDbType.NVarChar).Value = Me.TXT_PARENT_GUID.Text.Trim
                .Parameters.Add("@COUINT_ACCOUNT", SqlDbType.NVarChar).Value = Me.TXT_COUINT_ACCOUNT.Text.Trim

                .Parameters.Add("@account_no", SqlDbType.Int).Value = Me.TXT_Account_NO.Text
                .Parameters.Add("@account_name", SqlDbType.NVarChar).Value = Me.TXT_Account_Name.Text
                .Parameters.Add("@ACC4", SqlDbType.NVarChar).Value = Me.Text_ACC_FATHER.Text
                .Parameters.Add("@account_belong", SqlDbType.NVarChar).Value = Me.TextlblGROUPACCOUNT.Text
                .Parameters.Add("@ACC6", SqlDbType.NVarChar).Value = Me.TextAccountLevel.Text
                .Parameters.Add("@ACC7", SqlDbType.NVarChar).Value = Me.TextlblFIRSTDEBIT.Text
                .Parameters.Add("@ACC8", SqlDbType.NVarChar).Value = Me.TextlblFIRSTCREDIT.Text
                .Parameters.Add("@ACC9", SqlDbType.NVarChar).Value = Me.TextNotes.Text
                .Parameters.Add("@ACC10", SqlDbType.NVarChar).Value = Me.TextAccountPrivate.Text
                .Parameters.Add("@ACC11", SqlDbType.NVarChar).Value = Me.TEXTReferenceName.Text
                .Parameters.Add("@ACC12", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckMasterAccount.Checked)
                '.Parameters.Add("@ACTIVAT", SqlDbType.Bit).Value = Convert.ToInt32(Me.Chk_ACTIVAT.Checked)

                .CommandText = sql.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
            UPDATE_SON(TXT_PARENT_GUID.Text)
            UPDATE_SON(PARENTGUID_OLD)
            If TXT_PARENT_GUID.Text <> PARENTGUID_OLD Then
                UPDATE_CODE()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Public Sub ConnectData()
        On Error Resume Next
        If TestNet = True Then
            Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.ConnectDataBase.RunWorkerAsync()
        Else
            Me.Close()
        End If
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try

1:
            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.Update(ds, "ACCOUNTSTREE")
            'ds = New DataSet
            'SqlDataAdapter1.Fill(ds, "ACCOUNTSTREE")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1115812848 Or ex.Message.GetHashCode = 379362862 Then
                e.Cancel = True
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                e.Cancel = True
                TestNet = False
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            ElseIf ex.Message.GetHashCode = -652120241 Or ex.Message.GetHashCode = 2067669773 Then
                Me.DelRow = True
                Me.PictureBox2False()
                MsgBox("ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› «·”Ã· «·„Õœœ" & vbCrLf & "”Ê› Ì „  ÕœÌÀ «·”Ã·«  «·¬‰", 16, " ‰»ÌÂ")
            Else
                e.Cancel = True
                Me.PictureBox2False()
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                Try
                    If TestNet = False Then
                        MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    'Me.TextACC11.Clear()
                    Me.PictureBox2.Visible = True
                    Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
                        .WorkerReportsProgress = True,
                        .WorkerSupportsCancellation = True
                    }
                    Me.RefreshTab.RunWorkerAsync()
                Catch Ex As Exception
                    MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            'Me.BS.DataSource = Me.ds.Tables("ACCOUNTSTREE")
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            'Me.LabelAccountPrivate.Text = Now

            If Me.BS.Count < Me.RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & Me.RowCount - Me.BS.Count, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & Me.BS.Count - Me.RowCount, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")

                Exit Sub
            End If
            'Dim f As New FormTreeView
            'Call f.Refsh()
            Dim Sound As System.IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "ErrorSaveData_RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.PictureBox5.Visible = False
        End If
    End Sub
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
        On Error Resume Next
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try

1:          Me.ds = New DataSet
            Me.SqlDataAdapter1.Fill(ds, "ACCOUNTSTREE")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                Me.PictureBox2False()
                TestNet = False
                e.Cancel = True
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                Me.PictureBox2False()
                e.Cancel = True
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.ds.Tables("ACCOUNTSTREE")
            Me.PictureBox2.Visible = False
            Me.TextlblGROUPACCOUNT.Enabled = True
            Me.Cursor = Cursors.Default
            If DelRow = False Then
                If Me.BS.Count < Me.RowCount Then
                    MsgBox("  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & Me.RowCount - Me.BS.Count, 48 + 524288, " ÕœÌÀ «·”Ã·« ")
                ElseIf Me.BS.Count > Me.RowCount Then
                    MsgBox("  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & Me.BS.Count - Me.RowCount, 48 + 524288, " ÕœÌÀ «·”Ã·« ")
                End If
            Else
                Me.DelRow = False
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "ErrorRefreshData_RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            'If BS.Count = 0 Then Beep() : Exit Sub
            If InternalAuditor = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsql1 As New SqlClient.SqlCommand("SELECT DISTINCT MOVD4 FROM MOVESDATA WHERE MOVD4 = '" & Me.TXT_Account_NO.Text.Trim & "'", Consum)
            Dim ds1 As New DataSet
            Dim Adp1 As New SqlClient.SqlDataAdapter(strsql1)
            ds1.Clear()
            Adp1.Fill(ds1, "MOVESDATA")
            If ds1.Tables(0).Rows.Count > 0 Then
                MsgBox("·«Ì„ﬂ‰  ⁄œÌ·  «·”Ã· «·Õ«·Ï ·√‰Â „— »ÿ »Õ—ﬂ«  «·ﬁÌÊœ «·ÌÊ„Ì… ... ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.SEARCHUSERS()
            If flag = True Then
                MsgBox("·«Ì„ﬂ‰  „  ”ÃÌ· »Ì«‰«  «·Õ”«» ”«»ﬁ« ... ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.SaveRECORD()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Dim f As New FormTreeView
            f.TreeView1.BeginUpdate()
            f.TreeView1.Nodes.Clear()
            'f.FormTreeView_Load(sender, e)
            f.TreeView1.BeginUpdate()
            f.TreeView1.Nodes.Clear()
            f.TreeView1.EndUpdate()
            f.TreeView1.Update()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SEARCHUSERS()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT account_name  FROM ACCOUNTSTREE  WHERE (ACCOUNTSTREE.account_name)='" & Me.TXT_Account_Name.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
        ds.Clear()
        Adp1.Fill(ds, "ACCOUNTSTREE")
        If ds.Tables(0).Rows.Count >= 1 Then
            MessageBox.Show(" „  ”ÃÌ· »Ì«‰«  «·Õ”«» ”«»ﬁ«", " ﬂ—«— »Ì«‰«  Õ”«»", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Me.TXT_Account_Name.SelectAll()
            Me.TXT_Account_Name.Focus()
            flag = True
            Exit Sub
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub
    Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_Account_Name.LostFocus
        On Error Resume Next

    End Sub
    Private Sub SaveRECORD()
        Try
            GENRAT()
            Dim GUID_ As Guid = NewGuid()

            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand("INSERT INTO ACCOUNTSTREE( acc,GUID, COUINT_ACCOUNT, account_no, account_name, acc4, account_belong, acc6, acc7, acc8, acc9, acc12) VALUES     ( @acc,@GUID, @COUINT_ACCOUNT, @account_no, @account_name, @acc4, @account_belong, @acc6, @acc7, @acc8, @acc9, @acc12)", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            CMD.Parameters.Add("@acc", SqlDbType.NVarChar).Value = Me.TXT_ACC.Text.Trim

            CMD.Parameters.Add("@GUID", SqlDbType.NVarChar).Value = GUID_.ToString
            'CMD.Parameters.Add("@END_ACCOUNT", SqlDbType.NVarChar).Value = Me.TXT_END_ACCOUNT.Text
            'CMD.Parameters.Add("@PARTENT_ACCOUNT", SqlDbType.NVarChar).Value = Me.TXT_PARENT_GUID.Text
            CMD.Parameters.Add("@COUINT_ACCOUNT", SqlDbType.NVarChar).Value = Me.TXT_COUINT_ACCOUNT.Text

            CMD.Parameters.Add("@account_no", SqlDbType.NVarChar).Value = Me.TXT_Account_NO.Text
            CMD.Parameters.Add("@account_name", SqlDbType.NVarChar).Value = Me.TXT_Account_Name.Text
            CMD.Parameters.Add("@acc4", SqlDbType.NVarChar).Value = Me.Text_ACC_FATHER.Text
            CMD.Parameters.Add("@account_belong", SqlDbType.NVarChar).Value = Me.TextlblGROUPACCOUNT.Text
            CMD.Parameters.Add("@acc6", SqlDbType.NVarChar).Value = Me.TextAccountLevel.Text
            CMD.Parameters.Add("@acc7", SqlDbType.NVarChar).Value = Me.TextlblFIRSTDEBIT.Text
            CMD.Parameters.Add("@acc8", SqlDbType.NVarChar).Value = Me.TextlblFIRSTCREDIT.Text
            CMD.Parameters.Add("@acc9", SqlDbType.NVarChar).Value = Me.TextNotes.Text
            CMD.Parameters.Add("@acc12", SqlDbType.Bit).Value = Convert.ToInt32(CheckMasterAccount.Checked)
            CMD.CommandText = SQL.CommandText
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            TXT_GUID.Text = GUID_.ToString
            UPDATE_SON(TXT_PARENT_GUID.Text)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub UPDATEMOVESDATA()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand(" UPDATE MOVESDATA SET  MOVD3 = @MOVD3,  MOVD4 = @MOVD4,  MOVD8 = @MOVD8  WHERE MOVD4 = '" & Me.TXT_Account_NO.Text.Trim & "'", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOVD3", SqlDbType.NVarChar).Value = Me.TXT_Account_Name.Text
                .Parameters.Add("@MOVD4", SqlDbType.NVarChar).Value = Me.TXT_Account_NO.Text
                .Parameters.Add("@MOVD8", SqlDbType.NVarChar).Value = Me.TXT_ACC.Text
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUPDATEMOVESDATA", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Consum.Close()
        Finally
            Consum.Close()
        End Try
    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            'If BS.Count = 0 Then Beep() : Exit Sub
            If InternalAuditor = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If TXT_GUID.Text = Nothing Then
                MessageBox.Show("·«ÌÊÃœ Õ”«» · ⁄œÌ·… ﬁ„ »«·Õ›Ÿ «Ê·«", "Œÿ«¡", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Text_ACC_FATHER.Text = Nothing Then
                MessageBox.Show("›÷·« ﬁ„ »«Œ Ì«— «·Õ”«» «·—∆Ì”Ì", "Œÿ«¡", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Text_ACC_FATHER.Select()
                Exit Sub
            End If
            '==============================================
            If TXT_Account_Name.Text = Nothing Then
                MessageBox.Show("›÷·« ﬁ„ »«œŒ«· «”„ «·Õ”«»", "Œÿ«¡", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TXT_Account_Name.Select()
                Exit Sub
            End If
            CHECK_FOR_UPDATE("account_name", "ACCOUNTSTREE", TXT_Account_Name.Text, TXT_GUID.Text)
            If NUMBER_CHECK = 1 Then
                MessageBox.Show("ÌÊÃœ Õ”«» ÌÕ„· ‰›” «·«”„ «·Õ«·Ì ﬁ„ » €ÌÌ— «”„ «·Õ”«»", "Œÿ«¡", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TXT_Account_Name.Select()
                Exit Sub
            End If


            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsql1 As New SqlClient.SqlCommand("SELECT DISTINCT MOVD4 FROM MOVESDATA WHERE MOVD4 = '" & Me.TXT_Account_NO.Text & "'", Consum)
            Dim ds1 As New DataSet
            Dim Adp1 As New SqlClient.SqlDataAdapter(strsql1)
            ds1.Clear()
            Adp1.Fill(ds1, "MOVESDATA")
            If ds1.Tables(0).Rows.Count > 0 Then
                'resault = MessageBox.Show(" «·”Ã· «·Õ«·Ï „— »ÿ »Õ—ﬂ«  «·ﬁÌÊœ «·ÌÊ„Ì… ”Ì „ «· ⁄œÌ· ⁄·Ï ﬂ· Õ—ﬂ«  «·ﬁÌÊœ «·ÌÊ„Ì…" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ‰»ÌÂ Â«„", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                MsgBox("⁄›Ê« .. «·”Ã· «·Õ«·Ï „— »ÿ »Õ—ﬂ«  «·ﬁÌÊœ «·ÌÊ„Ì… ·« Ì„ﬂ‰ «· ⁄œÌ· ⁄·Ì Â–« «·Õ”«»", 16, " ‰»ÌÂ")
                'If resault = vbYes Then
                '    Me.UPDATEMOVESDATA()
                'Else
                Exit Sub
                'End If
            End If


            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.UPDATERECORD()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Dim f As New FormTreeView
            Call f.TreeView1.BeginUpdate()
            Call f.TreeView1.Nodes.Clear()
            Call f.LoadDataBase()
            Call f.TreeView1.EndUpdate()
            Call f.TreeView1.Update()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorEDITBUTTON", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try

            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TXT_PARENT_GUID.Text = F.DGV.Rows(I).Cells("COL_GUID").Value.ToString
                Me.Text_ACC_FATHER.Text = F.DGV.Rows(I).Cells("account_name").Value.ToString
                Me.TXT_Account_NO.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub Text_ACC_FATHER_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_ACC_FATHER.TextChanged

        'Dim PARENTGUID_OLD1 As String = CLS_ACC.SHOW_PARENTGUID1(Me.TXT_GUID.Text).Rows(0)(0).ToString
        'MsgBox(PARENTGUID_OLD1.ToString)
        'SHOW_PARENTGUID()
        'Me.TXT_PARENT_GUID.Text = PARENTGUID_OLD1.ToString 'CLS_ACC.SHOW_PARENTGUID(TXT_GUID.Text).Rows(0)(0).ToString
        GENRAT()
        'GENRAT()
        'TXT_Account_NO.Text = CODE_
    End Sub

    Private Sub TXT_PARENT_GUID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_PARENT_GUID.TextChanged
        If Me.TXT_PARENT_GUID.Text <> Nothing Then
            SHOW_FATHER()
        End If

    End Sub

    Private Sub TXT_GUID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_GUID.TextChanged
        If Me.TXT_GUID.Text <> Nothing Then
            SHOW_ACCOUNT()
        End If

    End Sub

    Private Sub BtnSearch1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch1.Click
        Try

            Dim F As New FRM_ALL_ACC
            NUMBER_FORM = 1
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TXT_GUID.Text = F.DGV.Rows(I).Cells("COL_GUID").Value.ToString
            End If
            NUMBER_FORM = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub



    Private Sub TextNotes_Enter(sender As Object, e As EventArgs) Handles TXT_Account_Name.Enter, TextNotes.Enter, TextlblGROUPACCOUNT.Enter, Text_ACC_FATHER.Enter
        ChangeToArabic()
    End Sub

    Private Sub TextlblFIRSTCREDIT_Enter(sender As Object, e As EventArgs) Handles TXT_Account_NO.Enter, TXT_ACC.Enter, TextlblFIRSTDEBIT.Enter, TextlblFIRSTCREDIT.Enter, TextAccountLevel.Enter
        ChangeToEnglish()
    End Sub


End Class
