Imports System.Data.Common
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine


Public Class FrmDailyrestrictions
<<<<<<< HEAD
    Inherits Form
    Public WithEvents BS As New BindingSource
    ReadOnly rpt As New rptAccounts2
    ReadOnly ds1 As New DataSet
    Dim SqlDataAdapter1 As New SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlDataAdapter
=======
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    ReadOnly rpt As New rptAccounts2
    ReadOnly ds1 As New DataSet
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    ReadOnly account_name As New DataTable

    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Public TB1 As String
    Public TB2 As String
    Dim chk As Boolean

<<<<<<< HEAD
    Private Sub FrmDailyrestrictions_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
        Try
            If Me.CheckLogReview.Checked Then
                Me.KeyPreview = False
                Return
            End If
            
            Me.KeyPreview = True
            Select Case e.KeyCode
                Case Keys.F3
                    Me.EDITBUTTON_Click(sender, e)
                Case Keys.F4
                    Me.BUTTONCANCEL_Click(sender, e)
                Case Keys.F5
                    Me.TabPage4.Show()
                    Me.PRINTBUTTON_Click(sender, e)
                Case Keys.F6
                    Me.DELETEBUTTON_Click(sender, e)
                Case Keys.F7
                    Me.TabPage4.Show()
                    Me.InternalAuditorERBUTTON_Click(sender, e)
                Case Keys.F8
                    Me.TabPage4.Show()
                    Me.ButtonCancellationAuditingAndACheckingAccounts_Click(sender, e)
                Case Keys.F12
                    Me.BUTTONDELRECORD_Click(sender, e)
                Case Keys.PageDown
                    Me.PREVIOUSBUTTON_Click(sender, e)
                Case Keys.PageUp
                    Me.NEXTBUTTON_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show("Error processing keyboard input: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmDailyrestrictions_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            Me.BackgroundImage = img
            Me.TabPage1.BackgroundImage = img
            
            ' Fade in form
            For opacity As Double = 0 To 1 Step 0.1
                Me.Opacity = opacity
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
            Next
            
            ' Initialize button states
            InitializeButtonStates(False)
            
        Catch ex As Exception
            MessageBox.Show("Error loading form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeButtonStates(ByVal enabled As Boolean)
        Me.EDITBUTTON.Enabled = enabled
        Me.BUTTONCANCEL.Enabled = enabled
        Me.PRINTBUTTON.Enabled = enabled
        Me.DELETEBUTTON.Enabled = enabled
        Me.BUTTONDELRECORD.Enabled = enabled
        Me.InternalAuditorERBUTTON.Enabled = enabled
        Me.PREVIOUSBUTTON.Enabled = enabled
        Me.FIRSTBUTTON.Enabled = enabled
        Me.NEXTBUTTON.Enabled = enabled
        Me.LASTBUTTON.Enabled = enabled
    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        Try
            If Me.DataGridView1.SelectedRows.Count = 0 OrElse e.RowIndex < 0 Then
                Return
            End If

            ' Update row index
            Me.DataGridView1.Item("MOVD2", e.RowIndex).Value = e.RowIndex + 1

            ' Initialize MOVD5 if null
            If Me.DataGridView1.Item("MOVD5", e.RowIndex).Value Is DBNull.Value Then
                Me.DataGridView1.Item("MOVD5", e.RowIndex).Value = "0.000"
            End If

            ' Calculate totals
            CalculateGridTotals()

        Catch ex As Exception
            MessageBox.Show("Error processing grid cell: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CalculateGridTotals()
        Try
            Dim debit As Decimal = 0
            Dim credit As Decimal = 0

            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                If row.Cells("MOVD6").Value?.ToString().ToUpper() = "DEBIT" Then
                    debit += Decimal.Parse(If(row.Cells("MOVD5").Value?.ToString(), "0"))
                ElseIf row.Cells("MOVD6").Value?.ToString().ToUpper() = "CREDIT" Then
                    credit += Decimal.Parse(If(row.Cells("MOVD5").Value?.ToString(), "0"))
                End If
            Next

            Me.TextDebit.Text = debit.ToString("N3")
            Me.TextCredit.Text = credit.ToString("N3")
            Me.TextDifference.Text = Math.Abs(debit - credit).ToString("N3")

        Catch ex As Exception
            MessageBox.Show("Error calculating totals: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles load1.Click
        On Error Resume Next
        Me.ds1.EnforceConstraints = False
        Dim Consum As New SqlConnection(constring)
        Dim str1 As New SqlCommand("", Consum)
        With str1
            .CommandText = "SELECT MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, USERNAME, Auditor, Realname, cuser, COUser, da, ne, da1, ne1 FROM MOVES  WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and MOV1 ='" & Strings.Trim(Me.TB1) & "'or MOV2 ='" & Strings.Trim(Me.TB2) & "'ORDER BY MOV2"
            Dim builder50 As New SqlCommandBuilder(SqlDataAdapter1)
        End With
        Dim str2 As New SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT MOVD1, MOV2, MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3 FROM MOVESDATA  ORDER BY MOV2"
            Dim builder51 As New SqlCommandBuilder(SqlDataAdapter2)
        End With
        Me.ds1.EnforceConstraints = False
        Consum.Open()
        Me.SqlDataAdapter1 = New SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlDataAdapter(str2)
=======
    Private Sub FrmDailyrestrictions_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Try
            If Me.CheckLogReview.Checked = True Then
                Me.KeyPreview = False
            Else
                Me.KeyPreview = True
                Select Case e.KeyCode
                    Case Keys.F3
                        Me.EDITBUTTON_Click(sender, e)
                    Case Keys.F4
                        Me.BUTTONCANCEL_Click(sender, e)
                    Case Keys.F5
                        Me.TabPage4.Show()
                        Me.PRINTBUTTON_Click(sender, e)
                    Case Keys.F6
                        Me.DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        Me.TabPage4.Show()
                        Me.InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        Me.TabPage4.Show()
                        Me.ButtonCancellationAuditingAndACheckingAccounts_Click(sender, e)
                    Case Keys.F12
                        Me.BUTTONDELRECORD_Click(sender, e)
                    Case Keys.PageDown
                        Me.PREVIOUSBUTTON_Click(sender, e)
                    Case Keys.PageUp
                        Me.NEXTBUTTON_Click(sender, e)
                    Case Keys.Escape
                        Me.Close()
                End Select
            End If
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmDailyrestrictions_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage4.Show()
    End Sub

    Private Sub FrmDailyrestrictions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TabPage1.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.EDITBUTTON.Enabled = False
        Me.BUTTONCANCEL.Enabled = False
        Me.PRINTBUTTON.Enabled = False
        Me.DELETEBUTTON.Enabled = False
        Me.BUTTONDELRECORD.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        'Me.ButtonXP1.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
    End Sub

    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load1.Click
        On Error Resume Next
        Me.ds1.EnforceConstraints = False
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim str1 As New SqlClient.SqlCommand("", Consum)
        With str1
            .CommandText = "SELECT MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, USERNAME, Auditor, Realname, cuser, COUser, da, ne, da1, ne1 FROM MOVES  WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and MOV1 ='" & Strings.Trim(Me.TB1) & "'or MOV2 ='" & Strings.Trim(Me.TB2) & "'ORDER BY MOV2"
            Dim builder50 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
        End With
        Dim str2 As New SqlClient.SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT MOVD1, MOV2, MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3 FROM MOVESDATA  ORDER BY MOV2"
            Dim builder51 As New SqlClient.SqlCommandBuilder(SqlDataAdapter2)
        End With
        Me.ds1.EnforceConstraints = False
        Consum.Open()
        Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ds1.Clear()
        Me.SqlDataAdapter1.Fill(Me.ds1, "MOVES")
        Me.SqlDataAdapter2.Fill(Me.ds1, "MOVESDATA")
        Me.ds1.Relations.Add("REL1", Me.ds1.Tables("MOVES").Columns("MOV2"), Me.ds1.Tables("MOVESDATA").Columns("MOV2"), True)
        Me.ds1.EnforceConstraints = True
        Me.LoadData()
        Me.BS.DataSource = Me.ds1
        Me.BS.DataMember = "MOVES"
        Me.DataGridView1.DataSource = Me.BS
        Me.DataGridView1.DataMember = "REL1"
        Me.DataGridView1.Columns("MOV3").Visible = False
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Me.ComboRegistrationNumber.DataSource = Me.ds1.Tables("MOVES")
        Me.ComboRegistrationNumber.DisplayMember = "MOV2"
        Consum.Close()
        Auditor("MOVES", "USERNAME", "MOV2", Me.TEXTRegistrationNumber.EditValue, "")
        Logentry = Uses
        Me.DataGridView1.AutoGenerateColumns = False
        'Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        'Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        'Dim Column As New DataGridViewCheckBoxColumn
        'With Me.DataGridView1
        '    .RowsDefaultCellStyle.BackColor = Color.Bisque
        '    .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        'End With
        Me.RecordCount()
        Call MangUsers()
        Me.TextTypy.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
        Me.load1.Enabled = False
        Me.PictureBox2.Visible = False
        Me.LabelLoadDataBase.Visible = False
        ButtonViewAuditorsNotes_Click(sender, e)

    End Sub

    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then
                Me.PictureBox2.Visible = True
                Me.LabelLoadDataBase.ForeColor = Color.Yellow
                Me.LabelLoadDataBase.Text = "... تم الاتصال بالانترنت"
            Else
                Me.LabelLoadDataBase.ForeColor = Color.Red
                Me.LabelLoadDataBase.Text = "الاتصال بالانترنت غير متوفر"
                Me.Close()
            End If
        End If
    End Sub


    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing

        If TypeOf e.Control Is DataGridViewComboBoxEditingControl Then
            'Dim comb As DataGridViewComboBoxEditingControl = TryCast(e.Control, DataGridViewComboBoxEditingControl)
            CType(e.Control, ComboBox).DropDownStyle = ComboBoxStyle.DropDown
            CType(e.Control, ComboBox).AutoCompleteSource = AutoCompleteSource.ListItems
            CType(e.Control, ComboBox).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        End If


    End Sub

    Private Sub LoadData()
<<<<<<< HEAD
        Try
            Using Consum As New SqlConnection(constring)
                ' Optimize query by using NOT IN for better performance
                Using cmd As New SqlCommand("SELECT acc1, account_no, account_name FROM ACCOUNTSTREE WHERE account_no NOT IN ('1','2','3','4','11','12','211','212','311','312','411','412') ORDER BY account_no", Consum)
                    Consum.Open()
                    Using dreader As SqlDataReader = cmd.ExecuteReader()
                        account_name.Clear()
                        account_name.Load(dreader)
                        MOVD3.Items.Clear()
                        For Each row As DataRow In account_name.Rows
                            MOVD3.Items.Add(row("account_name"))
                        Next
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading account data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboEntryType, e, )
    End Sub

    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Using cmd As New SqlClient.SqlCommand("Select   acc1, account_no, account_name from ACCOUNTSTREE  WHERE  account_no<>'" & "1" & "'" & "AND account_no<>'" & "2" & "'" & "AND account_no<>'" & "3" & "'" & "AND account_no<>'" & "4" & "'" & "AND account_no<>'" & "11" & "'" & "AND account_no<>'" & "12" & "'" & "AND account_no<>'" & "211" & "'" & "AND account_no<>'" & "212" & "'" & "AND account_no<>'" & "311" & "'" & "AND account_no<>'" & "312" & "'" & "AND account_no<>'" & "411" & "'" & "AND account_no<>'" & "412" & "'ORDER BY account_no", Consum)
            Consum.Open()
            Using dreader As SqlClient.SqlDataReader = cmd.ExecuteReader
                account_name.Clear()
                account_name.Load(dreader)
                For i As Integer = 0 To account_name.Rows.Count - 1
                    MOVD3.Items.Add(account_name(i)(2))
                Next
            End Using
        End Using
        Consum.Close()
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboEntryType, e, )
    End Sub

    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        AutoComplete(Me.ComboRegistrationNumber, e, )
    End Sub

    Private Sub DISPLAYRECORD()
        On Error Resume Next
        With Me
            .TEXT1.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("MOV1").ToString
            .TEXTRegistrationNumber.EditValue = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("MOV2").ToString
            .DATETIMEPICKER.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("MOV3").ToString
            .TEXTStatement.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("MOV4").ToString
            .TEXTAddDate.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("MOV5").ToString
            .TEXTDebit.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("MOV6").ToString
            .TEXTCredit.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("MOV7").ToString
            .TextJournalNo.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("MOV8").ToString
            .ComboEntryType.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("MOV9").ToString
            .TextTypy.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("MOV10").ToString
            .TextMovementSymbol.EditValue = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("MOV11").ToString
            .CheckLogReview.Checked = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("MOV12").ToString
            .TEXTUserName.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("USERNAME").ToString
            .TEXTReferenceName.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("Auditor").ToString
            .TextDefinitionDirectorate.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("COUser").ToString
            .TEXTAddDate.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("da").ToString
            .TextTimeAdd.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("ne").ToString
            .TEXTReviewDate.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("da1").ToString
            .TextreviewTime.Text = Me.ds1.Tables("MOVES").Rows(Me.BS.Position)("ne1").ToString
        End With
        Auditor("MOVES", "USERNAME", "MOV2", Me.TEXTRegistrationNumber.EditValue, "")
        Logentry = Uses

    End Sub

    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub

    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:

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
                DelRow = True
                Me.PictureBox2False()
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
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
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.Count()
            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.save
=======
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub SumAmount()
<<<<<<< HEAD
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(MOVD5) AS SUMDEBIT,Sum(MOVD6) AS SUMCREDIT FROM MOVESDATA WHERE MOV2 = " & Me.TEXTRegistrationNumber.EditValue & " GROUP BY MOV2", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(MOVD5) AS SUMDEBIT,Sum(MOVD6) AS SUMCREDIT FROM MOVESDATA WHERE MOV2 = " & Me.TEXTRegistrationNumber.EditValue & " GROUP BY MOV2", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXTDebit.Text = ds.Tables(0).Rows(0).Item(0)
            Me.TEXTCredit.Text = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TEXTDebit.Text = "0.000"
            Me.TEXTCredit.Text = "0.000"
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

    Public Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.ds1.Tables("MOVES").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.DISPLAYRECORD()
        Me.SumAmount()
        Me.InternalAuditorType()
        ButtonViewAuditorsNotes.PerformClick()
    End Sub

<<<<<<< HEAD
    Private Sub Bmp_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
=======
    Private Sub Bmp_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.RecordCount()
    End Sub

    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.BUTTONDELRECORD.Enabled = LockDelete
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
        'Me.Button3.Enabled = LockUpdate
        Me.ButtonRecordingAuditorsNotes.Enabled = InternalAuditor
        Me.ButtonCloseAuditorsNotes.Enabled = InternalAuditor


    End Sub

<<<<<<< HEAD
    Private Sub TEXT2_LostFocus(ByVal sender As System.Object, ByVal e As EventArgs) Handles TEXTRegistrationNumber.LostFocus
=======
    Private Sub TEXT2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEXTRegistrationNumber.LostFocus
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Static Dim P As Integer
        P = Me.BS.Position
    End Sub

<<<<<<< HEAD
    Private Sub TEXT2_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles TEXTRegistrationNumber.KeyDown, TEXT1.KeyDown, TEXTUserName.KeyDown, TEXTReferenceName.KeyDown, TEXTReviewDate.KeyDown, DATETIMEPICKER.KeyDown
=======
    Private Sub TEXT2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTRegistrationNumber.KeyDown, TEXT1.KeyDown, TEXTUserName.KeyDown, TEXTReferenceName.KeyDown, TEXTReviewDate.KeyDown, DATETIMEPICKER.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub

<<<<<<< HEAD
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
=======
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockDelete = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If Me.TextTypy.Text.ToString <> "RD" Then
                Dim resault As Integer
                resault = MessageBox.Show("لايمكن حذف  السجل الحالى لأنه مرحل" & vbCrLf & vbCrLf & "يجب الغاء الترحيل للسجل الحالى ", "سجل مرحل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            If MsgBox("  استمرار حذف السجل الحالي" & " ؟ ", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.OkCancel, "حذف سجل") = MsgBoxResult.Cancel Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.RowCount = Me.BS.Count
            MYDELETERECORD("MOVES", "MOV2", Me.TEXTRegistrationNumber, Me.BS, True)
            MYDELETERECORD("MOVESDATA", "MOV2", Me.TEXTRegistrationNumber, Me.BS, True)
            Me.Load_Click(sender, e)
<<<<<<< HEAD
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Insert_Actions(Me.TEXT1.Text.Trim, "حذف", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

<<<<<<< HEAD
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
=======
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim txtFROMDate As String
        Dim txtToDate As String
        Dim f As New FrmPRINT
        Dim txt As TextObject
        txtFROMDate = Format(Me.DateFrom.Value, "yyy, MM, dd, 00, 00, 000")
        txtToDate = Format(Me.DateTO.Value, "yyy, MM, dd, 00, 00, 00")
        On Error Resume Next
<<<<<<< HEAD
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Me.RBRegistrationNumber.Checked Then
            Dim rpt As New rptAccounts2
            If Len(Me.ComboRegistrationNumber.Text) = 0 Then
                MessageBox.Show("من فضلك ادخل رقم القيد  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboRegistrationNumber.Focus()
                Exit Sub
            End If
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            Dim ds1 As New DataSet
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim str As New SqlCommand("SELECT * FROM MOVES  WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and MOV3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND MOV2='" & ComboRegistrationNumber.Text & "'", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds1.Clear()
            SqlDataAdapter1.Fill(ds1, "MOVES")
            rpt.SetDataSource(ds1.Tables("MOVES"))
            If ds1.Tables(0).Rows.Count > 0 Then
                txt = rpt.Section1.ReportObjects("Text9")
                'txt.Text = "خلال الفترة من" & Format(Me.DateTimePicker1.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTimePicker2.Value, "dd - MM - yyyy")
                txt = rpt.Section1.ReportObjects("Text15")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("Text16")
                txt.Text = Directorate
                f.CrystalReportViewer1.ReportSource = rpt
                f.CrystalReportViewer1.Zoom(90%)
                f.CrystalReportViewer1.Refresh()
                f.Show()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        ElseIf Me.RadioButton2.Checked Then
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            Dim ds1 As New DataSet
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
<<<<<<< HEAD
            Dim str1 As New SqlCommand("SELECT * FROM MOVES  WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and MOV3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
            Dim builder51 As New SqlCommandBuilder(SqlDataAdapter2)
            SqlDataAdapter2 = New SqlDataAdapter(str1)
=======
            Dim str1 As New SqlClient.SqlCommand("SELECT * FROM MOVES  WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and MOV3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
            Dim builder51 As New SqlCommandBuilder(SqlDataAdapter2)
            SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds1.Clear()
            SqlDataAdapter2.Fill(ds1, "MOVES")
            rpt.SetDataSource(ds1.Tables("MOVES"))
            If ds1.Tables(0).Rows.Count > 0 Then
                txt = rpt.Section1.ReportObjects("Text9")
                txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt.Section1.ReportObjects("Text15")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("Text16")
                txt.Text = Directorate
                f.CrystalReportViewer1.ReportSource = rpt
                f.CrystalReportViewer1.Zoom(90%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        ElseIf Me.RadioButton3.Checked Then
            Dim rpt1 As New rptAccounts9
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            Dim ds1 As New DataSet
            GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
            Dim str2 As New SqlCommand("SELECT * FROM MOVES  WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and MOV3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND MOV12='" & False & "'", Consum)
            Dim builder51 As New SqlCommandBuilder(SqlDataAdapter2)
<<<<<<< HEAD
            SqlDataAdapter2 = New SqlDataAdapter(str2)
=======
            SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds1.Clear()
            SqlDataAdapter2.Fill(ds1, "MOVES")
            rpt1.SetDataSource(ds1.Tables("MOVES"))
            If ds1.Tables(0).Rows.Count > 0 Then
                txt = rpt1.Section1.ReportObjects("Text9")
                txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt1.Section1.ReportObjects("Text15")
                txt.Text = AssociationName
                txt = rpt1.Section1.ReportObjects("TEXT16")
                txt.Text = Directorate
                f.CrystalReportViewer1.ReportSource = rpt1
                f.CrystalReportViewer1.Zoom(90%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        End If
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles InternalAuditorERBUTTON.Click
=======
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalAuditorERBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Me.RecordCount()
        Static Dim P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = True
        Me.TEXTReferenceName.Text = USERNAME
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Auditor("MOVES", "USERNAME", "MOV2", Me.TEXTRegistrationNumber.EditValue, "")
        Logentry = Uses
        P = Me.BS.Position
        Me.UPDATEMOVES()
        Me.Load_Click(sender, e)
        Me.UPDATEMOVES()
        Me.BS.Position = P
        Insert_Actions(Me.TEXT1.Text.Trim, "مراجعة", Me.Text)
        MsgBox("تمت عملية المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
    End Sub

<<<<<<< HEAD
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FIRSTBUTTON.Click
=======
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
        Me.TextTypy.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
    End Sub

<<<<<<< HEAD
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PREVIOUSBUTTON.Click
=======
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Position - 1
        Me.RecordCount()
        Me.TextTypy.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
    End Sub

<<<<<<< HEAD
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NEXTBUTTON.Click
=======
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Position + 1
        Me.RecordCount()
        Me.TextTypy.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
    End Sub

<<<<<<< HEAD
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
=======
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
        Me.TextTypy.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
    End Sub

<<<<<<< HEAD
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
=======
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Year(Me.DATETIMEPICKER.Value.ToString("yyyy-MM-dd")) <> FiscalYear_currentDateMustBeInFiscalYear() Then
            MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
            Exit Sub
        End If
        If Me.TextTypy.Text.ToString <> "RD" Then
            Dim resault As Integer
            resault = MessageBox.Show("لايمكن تعدبل  السجل الحالى لأنه مرحل" & vbCrLf & vbCrLf & "يجب الغاء الترحيل للسجل الحالى ", "سجل مرحل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        If Val(Me.TEXTDebit.Text) <> Val(Me.TEXTCredit.Text) Then
            MessageBox.Show("اجمالى الطرف المدين لايساوى اجمالى الطرف الدائن", "حفظ سجل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        DataGridView1.Rows(0).Selected = True
        DataGridView1.CurrentCell = DataGridView1("MOVD2", DataGridView1.Rows(0).Index)
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Static Dim P As Integer
        P = Me.BS.Position
        Auditor("MOVES", "USERNAME", "MOV2", Me.TEXTRegistrationNumber.EditValue, "")
        Logentry = Uses
        Me.CHECK()
        Me.SumAmount()
        Me.UPDATEMOVES()
        Me.SaveMOVESDATA()
        Me.UPDATEMOVESDATA()

        Me.Load_Click(sender, e)
        Me.BS.Position = P
        Me.SumAmount()
        Me.UPDATEMOVES()
        Me.SaveMOVESDATA()
        Me.UPDATEMOVESDATA()

        Me.RecordCount()


        Me.PictureBox2.Visible = True
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
<<<<<<< HEAD
        Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Insert_Actions(Me.TEXT1.Text.Trim, "تعديل", Me.Text)
    End Sub

    Private Sub SaveMOVESDATA()
<<<<<<< HEAD
        Try
            Using Consum As New SqlConnection(constring)
                Dim sql As String = "INSERT INTO MOVESDATA (MOV2, MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10,  MOV3) " & _
                                  "VALUES (@MOV2, @MOVD2, @MOVD3, @MOVD4, @MOVD5, @MOVD6, @MOVD7, @MOVD8, @MOVD9, @MOVD10, @MOV3)"
                
                Using cmd As New SqlCommand(sql, Consum)
                    ' Add parameters with proper data types for better performance and security
                    With cmd.Parameters
                        .Add("@MOV2", SqlDbType.VarChar).Value = If(Me.TEXTRegistrationNumber.EditValue, DBNull.Value)
                        .Add("@MOVD2", SqlDbType.VarChar).Value = If(Me.DataGridView1.CurrentRow?.Cells("MOVD2").Value, DBNull.Value)
                        .Add("@MOVD3", SqlDbType.VarChar).Value = If(Me.DataGridView1.CurrentRow?.Cells("MOVD3").Value, DBNull.Value)
                        .Add("@MOVD4", SqlDbType.VarChar).Value = If(Me.DataGridView1.CurrentRow?.Cells("MOVD4").Value, DBNull.Value)
                        .Add("@MOVD5", SqlDbType.Decimal).Value = If(IsNumeric(Me.DataGridView1.CurrentRow?.Cells("MOVD5").Value), _
                            Decimal.Parse(Me.DataGridView1.CurrentRow.Cells("MOVD5").Value.ToString()), 0D)
                        .Add("@MOVD6", SqlDbType.VarChar).Value = If(Me.DataGridView1.CurrentRow?.Cells("MOVD6").Value, DBNull.Value)
                        .Add("@MOVD7", SqlDbType.VarChar).Value = If(Me.DataGridView1.CurrentRow?.Cells("MOVD7").Value, DBNull.Value)
                        .Add("@MOVD8", SqlDbType.VarChar).Value = If(Me.DataGridView1.CurrentRow?.Cells("MOVD8").Value, DBNull.Value)
                        .Add("@MOVD9", SqlDbType.VarChar).Value = If(Me.DataGridView1.CurrentRow?.Cells("MOVD9").Value, DBNull.Value)
                        .Add("@MOVD10", SqlDbType.VarChar).Value = If(Me.DataGridView1.CurrentRow?.Cells("MOVD10").Value, DBNull.Value)
                        .Add("@MOV3", SqlDbType.DateTime).Value = DateTime.Now
                    End With

                    Consum.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
=======
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO MOVESDATA(MOV2, MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3) VALUES     (@MOV2, @MOVD2, @MOVD3, @MOVD4, @MOVD5, @MOVD6, @MOVD7, @MOVD8, @MOVD9, @MOVD10, @MOV3)", Consum)
        Dim CMD As New SqlClient.SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@MOVD1", SqlDbType.Int, 4, "MOVD1")
            .Parameters.Add("@MOV2", SqlDbType.Int, 4, "MOV2").Value = Me.TEXTRegistrationNumber.EditValue
            .Parameters.Add("@MOVD2", SqlDbType.BigInt, 8, "MOVD2")
            .Parameters.Add("@MOVD3", SqlDbType.NVarChar, 100, "MOVD3")
            .Parameters.Add("@MOVD4", SqlDbType.Int, 4, "MOVD4")
            .Parameters.Add("@MOVD5", SqlDbType.Float, 8, "MOVD5")
            .Parameters.Add("@MOVD6", SqlDbType.Float, 8, "MOVD6")
            .Parameters.Add("@MOVD7", SqlDbType.NVarChar, 150, "MOVD7")
            .Parameters.Add("@MOVD8", SqlDbType.Int, 4, "MOVD8")
            .Parameters.Add("@MOVD9", SqlDbType.NVarChar, 25, "MOVD9").Value = Me.TextMovementSymbol.EditValue
            .Parameters.Add("@MOVD10", SqlDbType.NVarChar, 25, "MOVD10").Value = Me.TEXT1.Text
            .Parameters.Add("@MOV3", SqlDbType.Bit, 1, "MOV3").Value = 0
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table", "MOVESDATA", New DataColumnMapping() {New DataColumnMapping("MOVD1", "MOVD1"), New DataColumnMapping("MOV2", "MOV2"), New DataColumnMapping("MOVD2", "MOVD2"), New DataColumnMapping("MOVD3", "MOVD3"), New DataColumnMapping("MOVD4", "MOVD4"), New DataColumnMapping("MOVD5", "MOVD5"), New DataColumnMapping("MOVD6", "MOVD6"), New DataColumnMapping("MOVD7", "MOVD7"), New DataColumnMapping("MOVD8", "MOVD8"), New DataColumnMapping("MOVD9", "MOVD9"), New DataColumnMapping("MOVD10", "MOVD10"), New DataColumnMapping("MOV3", "MOV3")})})
        SqlDataAdapter2.InsertCommand = CMD
        SqlDataAdapter2.Update(ds1, "MOVESDATA")
        Consum.Close()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ErrorSaveMovesData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    End Sub

    Private Sub UPDATEMOVES()
        'On Error Resume Next
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" UPDATE  MOVES SET   MOV3 = @MOV3, MOV4 = @MOV4, MOV6 = @MOV6, MOV7 = @MOV7, MOV8 = @MOV8, MOV9 = @MOV9, MOV10 = @MOV10, MOV11 = @MOV11, MOV12 = @MOV12, Realname = @Realname, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, USERNAME = @USERNAME, Auditor = @Auditor, da1 = @da1, ne1 = @ne1 WHERE MOV2 = @MOV2", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" UPDATE  MOVES SET   MOV3 = @MOV3, MOV4 = @MOV4, MOV6 = @MOV6, MOV7 = @MOV7, MOV8 = @MOV8, MOV9 = @MOV9, MOV10 = @MOV10, MOV11 = @MOV11, MOV12 = @MOV12, Realname = @Realname, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, USERNAME = @USERNAME, Auditor = @Auditor, da1 = @da1, ne1 = @ne1 WHERE MOV2 = @MOV2", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                '.Parameters.Add("@MOV1", SqlDbType.Int).Value = Me.TEXT1.Text.Trim
                .Parameters.Add("@MOV2", SqlDbType.BigInt).Value = Me.TEXTRegistrationNumber.EditValue
                .Parameters.Add("@MOV3", SqlDbType.Date).Value = Me.DATETIMEPICKER.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text.Trim
                .Parameters.Add("@MOV5", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TEXTDebit.Text.Trim
                .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TEXTCredit.Text.Trim
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = Me.TextJournalNo.Text.Trim
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = Me.ComboEntryType.Text.Trim
                .Parameters.Add("@MOV10", SqlDbType.NVarChar).Value = Me.TextTypy.Text.Trim
                .Parameters.Add("@MOV11", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@MOV12", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@Realname", SqlDbType.NVarChar).Value = Realname
                .Parameters.Add("@cuser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                If InternalAuditor = True Then
                    .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Logentry
                    .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = USERNAME
                    .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                    .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                Else
                    .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                    .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = DBNull.Value
                    .Parameters.Add("@da1", SqlDbType.NVarChar).Value = DBNull.Value
                    .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = DBNull.Value
                End If
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUpdate", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Consum.Close()
        Finally
            Consum.Close()
        End Try
    End Sub

    Private Sub UPDATEMOVESDATA()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" UPDATE MOVESDATA SET MOV2 = @MOV2, MOVD2 = @MOVD2, MOVD3 = @MOVD3, MOVD4 = @MOVD4, MOVD5 = @MOVD5, MOVD6 = @MOVD6, MOVD7 = @MOVD7, MOVD8 = @MOVD8, MOVD9 = @MOVD9, MOVD10 = @MOVD10,  MOV3 = @MOV3  WHERE MOVD1 = @MOVD1", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand(" UPDATE MOVESDATA SET MOV2 = @MOV2, MOVD2 = @MOVD2, MOVD3 = @MOVD3, MOVD4 = @MOVD4, MOVD5 = @MOVD5, MOVD6 = @MOVD6, MOVD7 = @MOVD7, MOVD8 = @MOVD8, MOVD9 = @MOVD9, MOVD10 = @MOVD10,  MOV3 = @MOV3  WHERE MOVD1 = @MOVD1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOVD1", SqlDbType.Int, 4, "MOVD1")
                .Parameters.Add("@MOV2", SqlDbType.Int, 4, "MOV2").Value = Me.TEXTRegistrationNumber.EditValue
                .Parameters.Add("@MOVD2", SqlDbType.BigInt, 8, "MOVD2")
                .Parameters.Add("@MOVD3", SqlDbType.NVarChar, 100, "MOVD3")
                .Parameters.Add("@MOVD4", SqlDbType.Int, 4, "MOVD4")
                .Parameters.Add("@MOVD5", SqlDbType.Float, 8, "MOVD5")
                .Parameters.Add("@MOVD6", SqlDbType.Float, 8, "MOVD6")
                .Parameters.Add("@MOVD7", SqlDbType.NVarChar, 150, "MOVD7")
                .Parameters.Add("@MOVD8", SqlDbType.Int, 4, "MOVD8")
                .Parameters.Add("@MOVD9", SqlDbType.NVarChar, 25, "MOVD9").Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@MOVD10", SqlDbType.NVarChar, 25, "MOVD10").Value = Me.TEXT1.Text
                .Parameters.Add("@MOV3", SqlDbType.Bit, 1, "MOV3").Value = 0
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table1", "MOVESDATA", New DataColumnMapping() {New DataColumnMapping("MOVD1", "MOVD1"), New DataColumnMapping("MOVD2", "MOVD2"), New DataColumnMapping("MOVD3", "MOVD3"), New DataColumnMapping("MOVD4", "MOVD4"), New DataColumnMapping("MOVD5", "MOVD5"), New DataColumnMapping("MOVD6", "MOVD6"), New DataColumnMapping("MOVD7", "MOVD7"), New DataColumnMapping("MOVD8", "MOVD8"), New DataColumnMapping("MOVD9", "MOVD9"), New DataColumnMapping("MOVD10", "MOVD10"), New DataColumnMapping("MOV3", "MOV3"), New DataColumnMapping("MOV2", "MOV2")})})
            SqlDataAdapter2.UpdateCommand = CMD
            SqlDataAdapter2.Update(ds1, "MOVESDATA")
            SqlDataAdapter2.TableMappings.Clear()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUpdate", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SqlDataAdapter2.TableMappings.Clear()
            Consum.Close()
        Finally
            Consum.Close()
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RBRegistrationNumber.Click
=======
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBRegistrationNumber.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.ComboRegistrationNumber.Enabled = True
    End Sub

<<<<<<< HEAD
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton2.Click
=======
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.ComboRegistrationNumber.Enabled = False
    End Sub

    Private Sub CHECK()
        If Val(Me.TEXTDebit.Text) <> Val(Me.TEXTCredit.Text) Then
            MessageBox.Show("اجمالى الطرف المدين لايساوى اجمالى الطرف الدائن", "حفظ سجل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
    End Sub

<<<<<<< HEAD
    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name FROM ACCOUNTSTREE WHERE account_name = '" & Me.DataGridView1.CurrentRow.Cells("MOVD3").Value & " '", Consum)
        Dim ds3 As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name FROM ACCOUNTSTREE WHERE account_name = '" & Me.DataGridView1.CurrentRow.Cells("MOVD3").Value & " '", Consum)
        Dim ds3 As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds3.Clear()
        Consum.Open()
        Adp.Fill(ds3)
        If Me.DataGridView1.CurrentCell.ColumnIndex = "MOVD3" Then
            If ds3.Tables(0).Rows.Count > 0 Then
                Me.DataGridView1.CurrentRow.Cells("MOVD4").Value = ds3.Tables(0).Rows(0).Item(0)
                Me.DataGridView1.CurrentRow.Cells("MOVD8").Value = ds3.Tables(0).Rows(0).Item(1)
            End If
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        Try
            If Me.DataGridView1.SelectedRows.Count = 0 OrElse e.RowIndex < 0 Then
                Return
            End If

            ' Update row index
            Me.DataGridView1.Item("MOVD2", e.RowIndex).Value = e.RowIndex + 1

            ' Initialize MOVD5 if null
            If Me.DataGridView1.Item("MOVD5", e.RowIndex).Value Is DBNull.Value Then
                Me.DataGridView1.Item("MOVD5", e.RowIndex).Value = "0.000"
            End If

            ' Calculate totals
            CalculateGridTotals()

        Catch ex As Exception
            MessageBox.Show("Error processing grid cell: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.CurrentCellChanged
=======
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        Try
            If Me.DataGridView1.SelectedRows.Count = 0 Then
                Me.DataGridView1.Item("MOVD2", e.RowIndex).Value = Me.DataGridView1.CurrentRow.Index + 1
                If Me.DataGridView1.Item("MOVD5", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("MOVD5", e.RowIndex).Value = "0.000"
                If Me.DataGridView1.Item("MOVD6", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("MOVD6", e.RowIndex).Value = "0.000"
                Me.DataGridView1.Item("MOVD9", e.RowIndex).Value = Trim(Me.TextMovementSymbol.EditValue)
                Me.DataGridView1.Item("MOVD10", e.RowIndex).Value = Trim(Me.TEXT1.Text)
                Me.DataGridView1.Item("MOV3", e.RowIndex).Value = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim total As Double = "0.000"
        Dim tota2 As Double = "0.000"
        For Each r As DataGridViewRow In Me.DataGridView1.Rows
            total += CDbl(r.Cells("MOVD5").Value)
            tota2 += CDbl(r.Cells("MOVD6").Value)
        Next
        Me.TEXTDebit.Text = total.ToString("0.000")
        Me.TEXTCredit.Text = tota2.ToString("0.000")
    End Sub

<<<<<<< HEAD
    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
=======
    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        'Exit Sub
    End Sub

<<<<<<< HEAD
    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
=======
    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Me.DataGridView1.SelectedRows.Count > 0 Then
                For i As Integer = Me.DataGridView1.SelectedRows.Count - 1 To 0
                    Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
                Next
            Else
                MsgBox("حدد الصف بشكل جيد ", MsgBoxStyle.Critical, "تنبيه")
            End If
            Exit Sub

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub BUTTONDELRECORD_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONDELRECORD.Click
=======
    Private Sub BUTTONDELRECORD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONDELRECORD.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If

        Static Dim S As Integer
        S = Me.BS.Position
        Dim resault As Integer
        If Me.TextTypy.Text.ToString <> "RD" Then
            resault = MessageBox.Show("لايمكن حذف  السجل الحالى لأنه مرحل" & vbCrLf & vbCrLf & "يجب الغاء الترحيل للسجل الحالى ", "سجل مرحل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Me.BS.Count > 0 Then
            resault = MessageBox.Show("سبنم حذف السجلات المحددة", "حذف السجلات المحددة", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                For Each row As DataGridViewRow In Me.DataGridView1.SelectedRows
                    Dim n As Integer
                    n = Me.DataGridView1.Rows(row.Index).Cells("MOVD1").Value
<<<<<<< HEAD
                    Dim CMD2 As New SqlCommand With {
=======
                    Dim CMD2 As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    Dim SQL2 As New SqlCommand("DELETE FROM MOVESDATA WHERE MOVD1=" & n, Consum)
                    CMD2.CommandText = SQL2.CommandText
                    CMD2.ExecuteNonQuery()
                Next
                Consum.Close()
                Me.Load_Click(sender, e)
                Me.BS.Position = S
                Me.Load_Click(sender, e)
                ' Me.TEXT13.Text = CurrencyJO(TEXT12.Text, "jO")
                Insert_Actions(Me.TEXT1.Text.Trim, "حذف سجل من الشبكة", Me.Text)
            Else
                MessageBox.Show("تم ايقاف عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Else
            MessageBox.Show(" لايوجد سجلات محددة لاتمام عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
    End Sub


<<<<<<< HEAD
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
=======
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.BS.CancelEdit()
        Me.ds1.RejectChanges()
        Me.RecordCount()
    End Sub

    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.DELETEBUTTON.Enabled = False
            Me.PRINTBUTTON.Enabled = True
            Me.BUTTONDELRECORD.Enabled = False
            Me.DataGridView1.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
        Else
            Me.SHOWBUTTON()
        End If
    End Sub

<<<<<<< HEAD
    Private Sub ButtonCancellationAuditingAndACheckingAccounts_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
=======
    Private Sub ButtonCancellationAuditingAndACheckingAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Me.RecordCount()
        Static Dim P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = False
        Me.TEXTReferenceName.Text = USERNAME
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Auditor("MOVES", "USERNAME", "MOV2", Me.TEXTRegistrationNumber.EditValue, "")
        Logentry = Uses
        Me.UPDATEMOVES()
        P = Me.BS.Position
        Me.Load_Click(sender, e)
        Me.CheckLogReview.Checked = False
        Me.UPDATEMOVES()
        Me.BS.Position = P
        Insert_Actions(Me.TEXT1.Text.Trim, "إلغاء المراجع", Me.Text)
        MsgBox("تمت عملية إلغاء المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتحديث")
    End Sub

    Private Sub Enquiry1()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim Adp1 As SqlDataAdapter
            Dim strsql As New SqlCommand("SELECT  AN, AN4, AN6, AN7  FROM Auditorsnotes WHERE CUser ='" & CUser & "' and Year(AN3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and AN2 ='" & Me.TextMovementSymbol.EditValue & "'and AN7 ='" & True & "' ", Consum)
            Dim ds1 As New DataSet
            Adp1 = New SqlDataAdapter(strsql)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim Adp1 As SqlClient.SqlDataAdapter
            Dim strsql As New SqlCommand("SELECT  AN, AN4, AN6, AN7  FROM Auditorsnotes WHERE CUser ='" & CUser & "' and Year(AN3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and AN2 ='" & Me.TextMovementSymbol.EditValue & "'and AN7 ='" & True & "' ", Consum)
            Dim ds1 As New DataSet
            Adp1 = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds1.Clear()
            Consum.Open()
            Adp1.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                Me.TextAN.Text = ds1.Tables(0).Rows(0).Item(0)
                Me.TextAN4.Text = ds1.Tables(0).Rows(0).Item(1)
                Me.TextAN6.Text = ds1.Tables(0).Rows(0).Item(2)
                chk = ds1.Tables(0).Rows(0).Item(3)
            Else
                chk = False
            End If
            Adp1.Dispose()
            Consum.Close()
            If chk = False Then
                ButtonRecordingAuditorsNotes.Text = "تسجيل ملاحظات مدقق الحسابات"
            Else
                ButtonRecordingAuditorsNotes.Text = "تعديل ملاحظات مدقق الحسابات"

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorEnquiry1", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ButtonViewAuditorsNotes_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewAuditorsNotes.Click
=======
    Private Sub ButtonViewAuditorsNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewAuditorsNotes.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Auditor("MOVES", "USERNAME", "MOV2", Me.TEXTRegistrationNumber.EditValue, "")
            Logentry = Uses
            SEARCHFROM()
            Typy()
            Enquiry1()
            Me.ButtonRecordingAuditorsNotes.Enabled = InternalAuditor
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ButtonRecordingAuditorsNotes_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonRecordingAuditorsNotes.Click
=======
    Private Sub ButtonRecordingAuditorsNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRecordingAuditorsNotes.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية تسجيل ملاحظات مدقق الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        Try
            Dim TextRecordingAuditorsNotes As String = Me.TextAN4.Text
            ButtonViewAuditorsNotes_Click(sender, e)
            Auditor("MOVES", "USERNAME", "MOV1", Me.TEXT1.Text, "")
            Logentry = Uses
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            If chk = False Then
                Dim sql As String = "INSERT INTO Auditorsnotes(AN1, AN2, AN3, AN4, AN5, AN6, AN7, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1) VALUES     (@AN1, @AN2, @AN3, @AN4, @AN5, @AN6, @AN7, @USERNAME, @Auditor, @CUser, @COUser, @da, @ne, @da1, @ne1)"
                Dim cmd As New SqlCommand(sql, Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            If chk = False Then
                Dim sql As String = "INSERT INTO Auditorsnotes(AN1, AN2, AN3, AN4, AN5, AN6, AN7, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1) VALUES     (@AN1, @AN2, @AN3, @AN4, @AN5, @AN6, @AN7, @USERNAME, @Auditor, @CUser, @COUser, @da, @ne, @da1, @ne1)"
                Dim cmd As New SqlClient.SqlCommand(sql, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                With cmd
                    .CommandType = CommandType.Text
                    .Connection = Consum
                    .Parameters.Add("@AN1", SqlDbType.BigInt).Value = Me.TextSearchFrom.Text
                    .Parameters.Add("@AN2", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                    .Parameters.Add("@AN3", SqlDbType.Date).Value = Me.DATETIMEPICKER.Value.ToString("yyyy-MM-dd")
                    .Parameters.Add("@AN4", SqlDbType.NVarChar).Value = TextRecordingAuditorsNotes
                    .Parameters.Add("@AN5", SqlDbType.NVarChar).Value = Me.TextMeText.Text
                    .Parameters.Add("@AN6", SqlDbType.NVarChar).Value = "انتظار إجراءت المحاسب"
                    .Parameters.Add("@AN7", SqlDbType.NVarChar).Value = True
                    If InternalAuditor = True Then
                        .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Logentry
                        .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = USERNAME
                        .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                        .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                    Else
                        .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                        .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = DBNull.Value
                        .Parameters.Add("@da1", SqlDbType.NVarChar).Value = DBNull.Value
                        .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = DBNull.Value
                    End If
                    .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                    .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                    .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                    .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                    .CommandText = sql
                End With

                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                cmd.ExecuteNonQuery()
                Consum.Close()
                MsgBox("تمت عملية تسجيل الملاحظة بنجاح", 64 + 524288, "نجاح الحفظ والتحديث")
                Insert_Actions(Me.TEXT1.Text.Trim, "تسجيل ملاحظات مدقق الحسابات", Me.Text)

            Else
<<<<<<< HEAD
                Dim SQL As New SqlCommand("Update Auditorsnotes SET   AN4 = @AN4, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser WHERE AN = @AN ")
                Dim CMD As New SqlCommand With {
=======
                Dim SQL As New SqlClient.SqlCommand("Update Auditorsnotes SET   AN4 = @AN4, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser WHERE AN = @AN ")
                Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    .CommandType = CommandType.Text,
                    .Connection = Consum
                }
                With CMD
                    .CommandType = CommandType.Text
                    .Connection = Consum
                    .Parameters.Add("@AN", SqlDbType.NVarChar).Value = Me.TextAN.Text.Trim
                    .Parameters.Add("@AN4", SqlDbType.NVarChar).Value = TextRecordingAuditorsNotes
                    If InternalAuditor = True Then
                        .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Logentry
                        .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = USERNAME
                    Else
                        .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                        .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = DBNull.Value
                    End If
                    .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                    .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                    .CommandText = SQL.CommandText
                End With
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Consum.Close()
                MsgBox("تمت تعديل الملاحظة  بنجاح", 64 + 524288, "نجاح التغييرات والتحديث")
                Insert_Actions(Me.TEXT1.Text.Trim, "تعديل ملاحظات مدقق الحسابات", Me.Text)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ButtonCloseAuditorsNotes_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCloseAuditorsNotes.Click
=======
    Private Sub ButtonCloseAuditorsNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCloseAuditorsNotes.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية إغـلاق مـلاحـظات مدقـق الحسـابات", 16, "تنبيه")
            Exit Sub
        End If
        Try
            Auditor("Auditorsnotes", "USERNAME", "AN1", Me.TextSearchFrom.Text, "")
            Logentry = Uses

<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand("Update Auditorsnotes SET   AN7 = @AN7, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser WHERE AN = @AN ")
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand("Update Auditorsnotes SET   AN7 = @AN7, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser WHERE AN = @AN ")
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@AN", SqlDbType.NVarChar).Value = Me.TextAN.Text.Trim
                .Parameters.Add("@AN7", SqlDbType.NVarChar).Value = False
                If InternalAuditor = True Then
                    .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Logentry
                    .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = USERNAME
                Else
                    .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                    .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = DBNull.Value
                End If
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
            MsgBox("تمت إلغاء الملاحظة  بنجاح", 64 + 524288, "نجاح التغييرات والتحديث")
            Insert_Actions(Me.TEXT1.Text.Trim, "إغلاق ملاحظات مدقق الحسابات", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Typy()
        Try
            If Me.TextTypy.Text = "RD" Then ' القيود اليومية DR
                Me.TextMeText.Text = Me.Text
            ElseIf Me.TextTypy.Text = "SD" Then ' شهادات الاسهم _ الودائع SD
                Dim f1 As New FrmDeposits
                Me.TextMeText.Text = f1.Text
            ElseIf Me.TextTypy.Text = "WD" Then 'السحب والإيداع WD
                Dim f2 As New FrmTransaction
                Me.TextMeText.Text = f2.Text
            ElseIf Me.TextTypy.Text = "CH" Then  'الصندوق 
                Dim f3 As New FrmBanks5
                Me.TextMeText.Text = f3.Text
            ElseIf Me.TextTypy.Text = "PS" Then  'عهدة الموظفين 
                Dim f3 As New FrmEmpsolf
                Me.TextMeText.Text = f3.Text
            ElseIf Me.TextTypy.Text = "KS" Then  'الشيكات 
                Dim f3 As New FrmChecks
                Me.TextMeText.Text = f3.Text
            ElseIf Me.TextTypy.Text = "BA" Then  'البنك 
                Dim f3 As New FrmJO
                Me.TextMeText.Text = f3.Text
            ElseIf Me.TextTypy.Text = "CA" Then  'العملاء 
                Dim f3 As New FrmCUSTOMER1
                Me.TextMeText.Text = f3.Text
            ElseIf Me.TextTypy.Text = "BT" Then   'فاتورة نقل   
                Dim f4 As New FrmTRANSPORT
                Me.TextMeText.Text = f4.Text
            ElseIf Me.TextTypy.Text = "TL" Then   'فاتورة نقل تفصيلية  
                Dim f5 As New FrmInvoice
                Me.TextMeText.Text = f5.Text
            ElseIf Me.TextTypy.Text = "ER" Then 'م تخليص 
                Dim f6 As New FrmCUSTOMER11
                Me.TextMeText.Text = f6.Text
            ElseIf Me.TextTypy.Text = "GE" Then  'م . عامة  
                Dim f7 As New FrmMyCosts
                Me.TextMeText.Text = f7.Text
            ElseIf Me.TextTypy.Text = "PR" Then 'المشتريات 
                Dim f8 As New FrmSuppliesA
                Me.TextMeText.Text = f8.Text
            ElseIf Me.TextTypy.Text = "VE" Then 'المبيعات 
                Dim f9 As New FrmCustomersA
                Me.TextMeText.Text = f9.Text
            ElseIf Me.TextTypy.Text = "QR" Then 'المبيعات 
                Dim f9 As New Form_mabeat
                Me.TextMeText.Text = f9.Text
            ElseIf Me.TextTypy.Text = "PA" Then 'الدفعات
                Dim f As New CustomerPay
                Me.TextMeText.Text = f.Text
            ElseIf Me.TextTypy.Text = "LO" Then 'الذمم المدينة
                Dim f As New Loans
                Me.TextMeText.Text = f.Text
            ElseIf Me.TextTypy.Text = "SU" Then 'الموردين
                Dim f As New FrmSuppliers1
                Me.TextMeText.Text = f.Text
            ElseIf Me.TextTypy.Text = "ES" Then
                Dim employees As New FormEmployees4
                Me.TextMeText.Text = employees.Text
            ElseIf Me.TextTypy.Text = "AS" Then
                Dim employees As New FrmEmpCost
                Me.TextMeText.Text = employees.Text
            Else

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SearchFrom()
        Try

            If Me.TextTypy.Text = "RD" Then
                SEARCHDATA.SEARCHMOVES(Me.TEXTRegistrationNumber.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.MOV1.ToString
            ElseIf Me.TextTypy.Text = "SD" Then
                SEARCHDATA.SEARCHID2(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.TBNK1.ToString
            ElseIf Me.TextTypy.Text = "WD" Then
                SEARCHDATA.SEARCHID3(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.TBNK1A.ToString
            ElseIf Me.TextTypy.Text = "CH" Then
                SEARCHDATA.SEARCHCASHIERA1(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.CSH1C.ToString
            ElseIf Me.TextTypy.Text = "PS" Then
                SEARCHDATA.SEARCHEMPSOLF(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.CSH1E.ToString
            ElseIf Me.TextTypy.Text = "CA" Then
                SEARCHDATA.SEARCHCABLESA(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.IDCABS3.ToString
            ElseIf Me.TextTypy.Text = "BA" Then
                SEARCHDATA.SEARCHID4(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.EBNK1.ToString
            ElseIf Me.TextTypy.Text = "BT" Then
                SEARCHDATA.SEARCHID5(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.PTRO1.ToString
            ElseIf Me.TextTypy.Text = "TL" Then
                SEARCHDATA.SEARCHID6(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.PTRO1A.ToString
            ElseIf Me.TextTypy.Text = "ER" Then
                SEARCHDATA.SEARCHID7(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.CEMP3.ToString
            ElseIf Me.TextTypy.Text = "GE" Then
                SEARCHDATA.SEARCHID8(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.CST1.ToString
            ElseIf Me.TextTypy.Text = "PR" Then
                SEARCHDATA.SEARCHID9(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.BUY1.ToString
            ElseIf Me.TextTypy.Text = "VE" Then
                SEARCHDATA.SEARCHID10(Me.TextMovementSymbol.EditValue)
            ElseIf Me.TextTypy.Text = "VE" Then
                SEARCHDATA.SEARCHID10(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.SLS1.ToString
                'Or "QRA" Or "QRB"
            ElseIf Me.TextTypy.Text = "QR" Then
                Dim Consum As New SqlConnection(constring)
                Dim ds8 As New DataSet
<<<<<<< HEAD
                Dim SqlDataAdapter8 As New SqlDataAdapter
                Dim f8 As New Form_mabeat
                ds8.EnforceConstraints = False
                Dim str As New SqlCommand("SELECT DataTS FROM TodaySales WHERE   CUser='" & CUser & "' and Year(DataTS) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY ID", Consum)
                SqlDataAdapter8 = New SqlDataAdapter(str)
=======
                Dim SqlDataAdapter8 As New SqlClient.SqlDataAdapter
                Dim f8 As New Form_mabeat
                ds8.EnforceConstraints = False
                Dim str As New SqlCommand("SELECT DataTS FROM TodaySales WHERE   CUser='" & CUser & "' and Year(DataTS) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY ID", Consum)
                SqlDataAdapter8 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds8.Clear()
                Consum.Open()
                SqlDataAdapter8.Fill(ds8, "TodaySales")
                If ds8.Tables.Item(0).Rows.Count > 0 Then
                    Me.TextSearchFrom.Text = ds8.Tables.Item(0).Rows.Item(0).Item(0)
                Else
                    Me.TextSearchFrom.Text = Nothing
                End If
                Consum.Close()
            ElseIf Me.TextTypy.Text = "PA" Then
                SEARCHDATA.SEARCHID(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.Loa1.ToString
            ElseIf Me.TextTypy.Text = "LO" Then
                SEARCHDATA.SEARCHID1(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.Lo1.ToString
            ElseIf Me.TextTypy.Text = "SU" Then
                SEARCHDATA.SEARCHDSuppliersA(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.IDSuppliesA.ToString
            ElseIf Me.TextTypy.Text = "KS" Then
                SEARCHDATA.SEARCHID11(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.IDCH1.ToString
            ElseIf Me.TextTypy.Text = "ES" Then
                SEARCHDATA.SEARCHID12(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.SLY1.ToString
            ElseIf Me.TextTypy.Text = "AS" Then
                SEARCHDATA.SEARCHEMPCOSTID(Me.TextMovementSymbol.EditValue)
                Me.TextSearchFrom.Text = SEARCHDATA.IDEmpCost
            Else
                Me.TextSearchFrom.Text = Me.TextTypy.Text
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "ErrorSearchFrom", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


<<<<<<< HEAD
    Private Sub ButtonAttachDocument_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAttachDocument.Click
        Try
=======
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAttachDocument.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("ععفوا .. قام الأدمن بمنع خاصية إرفاق المستندات", 16, "تنبيه")
                Exit Sub
            End If
<<<<<<< HEAD
            GetAutoNumberMyDOCUMENTSFL(TextMovementSymbol.EditValue)
            Dim documentId As Object = SEARCHDATA.NumberMyDOCUMENTSFL
            Dim f As New FrmJPG0
            f.Show()
            f.ADDBUTTON.Enabled = False
            f.SAVEBUTTON.Enabled = True
=======
           Dim XLO As Int64
            XLO = Me.TEXTRegistrationNumber.EditValue
            Dim f As New FrmJPG0
            f.ADDBUTTON.Enabled = False
            f.SAVEBUTTON.Enabled = True

>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            f.ButScan.Enabled = True
            f.ButSaveFile.Enabled = False
            f.ButLogq.Enabled = True
            f.ButEditImage.Enabled = False
<<<<<<< HEAD
            f.BS.EndEdit()
            f.BS.AddNew()
            f.MAXRECORD()
            f.DateP1.Text = Me.DATETIMEPICKER.Value.ToString("yyyy-MM-dd")
            f.TextLO.Text = Me.TextMovementSymbol.EditValue
            f.TEXTFileNo.Text = documentId
=======

            f.Show()
            f.ADDBUTTON_Click(sender, e)
            f.BS.Position = BS.Count - 1
            f.BS.EndEdit()
            f.BS.AddNew()
            CLEARDATA1(Me)
            f.DateP1.Text = Me.DATETIMEPICKER.Value.ToString("yyyy-MM-dd")
            f.TextLO.Text = Me.TextMovementSymbol.EditValue
            f.TEXTFileNo.Text = Val(XLO)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            f.TEXTFileSubject.Text = "مستندات القيود"
            f.TextFileDescription.Text = "ارفاق مستندات القيود"
            f.PictureBox1.Image = Nothing
            f.TEXTBOX1.Enabled = False
            f.TextLO.Enabled = False
            f.TEXTFileNo.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CMDBROWSE.Click
        Try
            Dim ds41 As New DataSet
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE.Click
        Try
            Dim ds41 As New DataSet
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim f As New FrmJPG
            ds41.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand("SELECT DOC1, LO FROM MYDOCUMENTSHOME  WHERE  CUser='" & CUser & "'and  LO ='" & Trim(Me.TextMovementSymbol.EditValue) & "'ORDER BY DOC1", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds41.Clear()
            SqlDataAdapter1.Fill(ds41, "MYDOCUMENTSHOME")
            f.BS.DataMember = "MYDOCUMENTSHOME"
            f.BS.DataSource = ds41
            f.PictureBox1.Dock = DockStyle.Fill
            Dim txt As Control
            For Each txt In f.Controls
                If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Or TypeOf txt Is Label Or TypeOf txt Is Panel Then
                    txt.Visible = False
                End If
            Next
            Dim index As Integer
            If ds41.Tables(0).Rows.Count > 0 Then
                Dim DOC1 As String = Strings.Trim(ds41.Tables(0).Rows(0).Item(0))
                Dim LO As String = Trim(ds41.Tables(0).Rows(0).Item(1))
                index = f.BS.Find("DOC1", DOC1)
                f.Show()
                f.FrmJPG_Load(sender, e)
                f.TEXTBOX1.Text = Strings.Trim(DOC1)
                f.TextTransactionNumber.Text = Strings.Trim(LO)
                f.DanLOd()
                f.BS.Position = index
                f.PHOTO = True
                f.RecordCount()
                If Me.CheckLogReview.Checked = True Then
                    f.ButScan.Enabled = False
                    f.ButLogq.Enabled = False
                    f.EDITBUTTON.Enabled = False
                    f.DELETEBUTTON.Enabled = False
                End If
            Else
                MsgBox("لا يوجد اي مستندات", 64 + 524288, "تنبيه")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()

    End Sub

End Class