Option Explicit Off


Imports System.Data.SqlClient

Public Class FrmStocks1
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim dsSTOCK As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Public RowVisible As Boolean = False
    Dim DelRow As Boolean = False

    Dim RowCount As Integer = 0
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Private Sub FrmStocks1_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage2.Show()
        Me.TabPage4.Show()
    End Sub
    Private Sub FrmStocks1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
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
        Me.DELETEBUTTON.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
    End Sub

    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles load1.Click
        On Error Resume Next
        Me.ConnectDataBase = New ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()
        Me.load1.Enabled = False
    End Sub
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        Me.RecordCount()
    End Sub
    Private Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < dsSTOCK.Tables("STOCKSITEMS ").Rows.Count - 1 Then
            Forward = True
        End If

        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.SHOWBUTTON()
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
    End Sub
    Private Sub TEXT2_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles TEXTUserName.KeyDown, TEXTReviewDate.KeyDown, TEXTReferenceName.KeyDown, TEXTITEMNAME.KeyDown, TEXTITEMCODE.KeyDown, TEXTGROUPCODE.KeyDown, ComboHashUnit.KeyDown, ComboGROUPNAME.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub

    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try

1:

            Dim Consum As New SqlConnection(constring)
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Dim strSQL As New SqlCommand("", Consum)

            With strSQL
                If Me.RowVisible = True Then
                    If Me.TB1 <> "" Then
                        .CommandText = "SELECT  SKITM1, SKITM2, SKITM3, SKITM4, SKITM5, SKITM6, SKITM7, SKITM8, SKITM9, SKITM10, SKITM11, SKITM12, SKITM13, SKITM14, SKITM15, SKITM16, SKITM17, SKITM18, SKITM19, SKITM20, SKITM21, SKITM22, SKITM23, SKITM24, SKITM25, SKITM26, SKITM27, SKITM28, ChkPD, IT_DATEP, IT_DATEEX, USERNAME, Cuser, COUSER, da, ne, da1, ne1 FROM STOCKSITEMS  WHERE  CUser='" & CUser & "'and SKITM4 ='" & Strings.Trim(Me.TB1) & "'ORDER BY SKITM4"
                    ElseIf Me.TB2 <> "" Then
                        .CommandText = "SELECT  SKITM1, SKITM2, SKITM3, SKITM4, SKITM5, SKITM6, SKITM7, SKITM8, SKITM9, SKITM10, SKITM11, SKITM12, SKITM13, SKITM14, SKITM15, SKITM16, SKITM17, SKITM18, SKITM19, SKITM20, SKITM21, SKITM22, SKITM23, SKITM24, SKITM25, SKITM26, SKITM27, SKITM28, ChkPD, IT_DATEP, IT_DATEEX, USERNAME, Cuser, COUSER, da, ne, da1, ne1 FROM STOCKSITEMS  WHERE  CUser='" & CUser & "'and  SKITM5 like'" & Trim(Me.TB2) & "%'ORDER BY SKITM4"
                    End If
                Else
                    .CommandText = "SELECT  SKITM1, SKITM2, SKITM3, SKITM4, SKITM5, SKITM6, SKITM7, SKITM8, SKITM9, SKITM10, SKITM11, SKITM12, SKITM13, SKITM14, SKITM15, SKITM16, SKITM17, SKITM18, SKITM19, SKITM20, SKITM21, SKITM22, SKITM23, SKITM24, SKITM25, SKITM26, SKITM27, SKITM28, ChkPD, IT_DATEP, IT_DATEEX, USERNAME, Cuser, COUSER, da, ne, da1, ne1 FROM STOCKSITEMS  WHERE  CUser='" & CUser & "'ORDER BY SKITM4"
                End If

                Consum.Open()
                SqlDataAdapter1 = New SqlDataAdapter(strSQL)
                dsSTOCK = New DataSet
                SqlDataAdapter1.Fill(dsSTOCK, "STOCKSITEMS")
                dsSTOCK.RejectChanges()
            End With

        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If TestNet = True Then

        Else
            Me.Close()
        End If
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try

            If e.Cancelled Then
                Return
            End If
            Me.BS.DataSource = Me.dsSTOCK.Tables.Item("STOCKSITEMS")
            Me.RowCount = Me.BS.Count
            Me.TEXT1.DataBindings.Add("text", Me.BS, "SKITM1", True, 1, "")
            Me.TEXTGROUPCODE.DataBindings.Add("text", Me.BS, "SKITM2", True, 1, "")
            Me.ComboGROUPNAME.DataBindings.Add("text", Me.BS, "SKITM3", True, 1, "")
            Me.TEXTITEMCODE.DataBindings.Add("text", Me.BS, "SKITM4", True, 1, "")
            Me.TEXTITEMNAME.DataBindings.Add("text", Me.BS, "SKITM5", True, 1, "")
            Me.ComboHashUnit.DataBindings.Add("text", Me.BS, "SKITM6", True, 1, "")
            Me.TextQUANTITY.DataBindings.Add("text", Me.BS, "SKITM7", True, 1, "")
            Me.TEXTUnitPrice.DataBindings.Add("text", Me.BS, "SKITM8", True, 1, "")
            'Me.TEXTDiscount.DataBindings.Add("text", Me.BS, "SKITM9", True, 1, "")
            Me.TEXTDiscount.Text = Me.dsSTOCK.Tables("STOCKSITEMS").Rows(Me.BS.Position)("SKITM9").ToString
            Me.TEXTPurchasingPrice.DataBindings.Add("text", Me.BS, "SKITM10", True, 1, "")
            Me.TEXTOrderLimit.DataBindings.Add("text", Me.BS, "SKITM11", True, 1, "")
            'Me.TextSalesTaxRate.DataBindings.Add("text", Me.BS, "SKITM12", True, 1, "")
            Me.TextSalesTaxRate.Text = Me.dsSTOCK.Tables("STOCKSITEMS").Rows(Me.BS.Position)("SKITM12").ToString
            Me.TextInitialBalance.DataBindings.Add("text", Me.BS, "SKITM13", True, 1, "")
            Me.TexTSellingPrice.DataBindings.Add("text", Me.BS, "SKITM14", True, 1, "")
            'Me.TextDiscountPercentageWhenSelling.DataBindings.Add("text", Me.BS, "SKITM15", True, 1, "")
            'Me.TextLowestDiscountRateWhenSelling.DataBindings.Add("text", Me.BS, "SKITM16", True, 1, "")
            'Me.TextHighestDiscountRateWhenSelling.DataBindings.Add("text", Me.BS, "SKITM17", True, 1, "")

            Me.TextDiscountPercentageWhenSelling.Text = Me.dsSTOCK.Tables("STOCKSITEMS").Rows(Me.BS.Position)("SKITM15").ToString
            Me.TextLowestDiscountRateWhenSelling.Text = Me.dsSTOCK.Tables("STOCKSITEMS").Rows(Me.BS.Position)("SKITM16").ToString
            Me.TextHighestDiscountRateWhenSelling.Text = Me.dsSTOCK.Tables("STOCKSITEMS").Rows(Me.BS.Position)("SKITM17").ToString


            Me.TextTotalSecondSellingPrice.DataBindings.Add("text", Me.BS, "SKITM18", True, 1, "")
            Me.TextTotalThirdSalePrice.DataBindings.Add("text", Me.BS, "SKITM19", True, 1, "")
            Me.CheckPricesMentionedIncludeSalesTax.DataBindings.Add("Checked", Me.BS, "SKITM20", True, 1, "")
            Me.CheckItemIsSubjectToSalesTax.DataBindings.Add("Checked", Me.BS, "SKITM21", True, 1, "")
            Me.ComboHashUnit1.DataBindings.Add("text", Me.BS, "SKITM22", True, 1, "")
            Me.ComboHashUnit2.DataBindings.Add("text", Me.BS, "SKITM23", True, 1, "")
            Me.TextHashUnitNumber.DataBindings.Add("text", Me.BS, "SKITM24", True, 1, "")
            Me.TextHashUnitNumber1.DataBindings.Add("text", Me.BS, "SKITM25", True, 1, "")
            Me.TextHashUnitNumber2.DataBindings.Add("text", Me.BS, "SKITM26", True, 1, "")
            Me.TextSecondSellingPrice.DataBindings.Add("text", Me.BS, "SKITM27", True, 1, "")
            Me.TextThirdSalePrice.DataBindings.Add("text", Me.BS, "SKITM28", True, 1, "")
            Me.ChkPD.DataBindings.Add("Checked", Me.BS, "ChkPD", True, 1, "")




            Me.ProductionDate.DataBindings.Add("text", Me.BS, "IT_DATEP", True, 1, "")
            Me.ExpiryDate.DataBindings.Add("text", Me.BS, "IT_DATEEX", True, 1, "")
            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "CUser", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")
            Me.LISTBOX.DataSource = Me.BS
            Me.LISTBOX.DisplayMember = "SKITM5"
            ModuleGeneral.FILLCOMBOBOX1("STOCKSITEMS", "SKITM3", "CUser", ModuleGeneral.CUser, Me.ComboGROUPNAME)

            Me.RecordCount()
            MdlConnection.MangUsers()
            Auditor("STOCKSITEMS", "USERNAME", "SKITM1", Me.TEXT1.Text, "")
            Logentry = Uses
            Me.SHOWBUTTON()
            ChkPD_CheckedChanged(sender, e)
            Me.BUTTONCANCEL.Enabled = True

            MdlConnection.Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Consum.Close()
    End Sub
    Private Sub UPDATERECORD()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim sql As New SqlCommand("UPDATE STOCKSITEMS SET SKITM2 = @SKITM2, SKITM3 = @SKITM3, SKITM4 = @SKITM4, SKITM5 = @SKITM5, SKITM6 = @SKITM6, SKITM7 = @SKITM7, SKITM8 = @SKITM8, SKITM9 = @SKITM9, SKITM10 = @SKITM10, SKITM11 = @SKITM12, SKITM13 = @SKITM13, SKITM14 = @SKITM14, SKITM15 = @SKITM15, SKITM16 = @SKITM16, SKITM17 = @SKITM17, SKITM18 = @SKITM18, SKITM19 = @SKITM19, SKITM20 = @SKITM20, SKITM21 = @SKITM21, SKITM22 = @SKITM22, SKITM23 = @SKITM23, SKITM24 = @SKITM24, SKITM25 = @SKITM25, SKITM26 = @SKITM26, SKITM27 = @SKITM27, SKITM28 = @SKITM28, IT_DATEP = @IT_DATEP, IT_DATEEX = @IT_DATEEX, ChkPD = @ChkPD, USERNAME = @USERNAME, Auditor = @Auditor, Cuser = @Cuser, COUSER = @COUSER, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE SKITM1 = @SKITM1", Consum)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@SKITM1", SqlDbType.Int).Value = Me.TEXT1.Text
                .Parameters.Add("@SKITM2", SqlDbType.NVarChar).Value = Me.TEXTGROUPCODE.Text
                .Parameters.Add("@SKITM3", SqlDbType.NVarChar).Value = Me.ComboGROUPNAME.Text
                .Parameters.Add("@SKITM4", SqlDbType.Int).Value = Me.TEXTITEMCODE.Text
                .Parameters.Add("@SKITM5", SqlDbType.NVarChar).Value = Me.TEXTITEMNAME.Text
                .Parameters.Add("@SKITM6", SqlDbType.NVarChar).Value = Me.ComboHashUnit.Text
                .Parameters.Add("@SKITM7", SqlDbType.NVarChar).Value = Me.TextQUANTITY.Text
                .Parameters.Add("@SKITM8", SqlDbType.NVarChar).Value = Me.TEXTUnitPrice.EditValue
                .Parameters.Add("@SKITM9", SqlDbType.NVarChar).Value = Me.TEXTDiscount.EditValue
                .Parameters.Add("@SKITM10", SqlDbType.NVarChar).Value = Me.TEXTPurchasingPrice.EditValue
                .Parameters.Add("@SKITM11", SqlDbType.NVarChar).Value = Me.TEXTOrderLimit.EditValue
                .Parameters.Add("@SKITM12", SqlDbType.NVarChar).Value = Me.TextSalesTaxRate.EditValue
                .Parameters.Add("@SKITM13", SqlDbType.NVarChar).Value = Me.TextInitialBalance.Text
                .Parameters.Add("@SKITM14", SqlDbType.NVarChar).Value = Me.TexTSellingPrice.EditValue
                .Parameters.Add("@SKITM15", SqlDbType.NVarChar).Value = Me.TextDiscountPercentageWhenSelling.EditValue
                .Parameters.Add("@SKITM16", SqlDbType.NVarChar).Value = Me.TextLowestDiscountRateWhenSelling.EditValue
                .Parameters.Add("@SKITM17", SqlDbType.NVarChar).Value = Me.TextHighestDiscountRateWhenSelling.EditValue
                .Parameters.Add("@SKITM18", SqlDbType.NVarChar).Value = Me.TextTotalSecondSellingPrice.EditValue
                .Parameters.Add("@SKITM19", SqlDbType.NVarChar).Value = Me.TextTotalThirdSalePrice.EditValue
                .Parameters.Add("@SKITM20", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckPricesMentionedIncludeSalesTax.Checked)
                .Parameters.Add("@SKITM21", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckItemIsSubjectToSalesTax.Checked)
                .Parameters.Add("@SKITM22", SqlDbType.NVarChar).Value = Me.ComboHashUnit1.Text
                .Parameters.Add("@SKITM23", SqlDbType.NVarChar).Value = Me.ComboHashUnit2.Text
                .Parameters.Add("@SKITM24", SqlDbType.NVarChar).Value = Me.TextHashUnitNumber.EditValue
                .Parameters.Add("@SKITM25", SqlDbType.NVarChar).Value = Me.TextHashUnitNumber1.EditValue
                .Parameters.Add("@SKITM26", SqlDbType.NVarChar).Value = Me.TextHashUnitNumber2.EditValue
                .Parameters.Add("@SKITM27", SqlDbType.NVarChar).Value = Me.TextSecondSellingPrice.EditValue
                .Parameters.Add("@SKITM28", SqlDbType.NVarChar).Value = Me.TextThirdSalePrice.EditValue
                .Parameters.Add("@ChkPD", SqlDbType.Bit).Value = Convert.ToInt32(Me.ChkPD.Checked)
                If ChkPD.Checked = True Then
                    .Parameters.Add("@IT_DATEP", SqlDbType.Date).Value = CDate(ProductionDate.Value.ToString)
                    .Parameters.Add("@IT_DATEEX", SqlDbType.Date).Value = CDate(ExpiryDate.Value.ToString)
                Else
                    .Parameters.Add("@IT_DATEP", SqlDbType.Date).Value = DBNull.Value
                    .Parameters.Add("@IT_DATEEX", SqlDbType.Date).Value = DBNull.Value
                End If

                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
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
                .CommandText = sql.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error13", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            dsSTOCK = New DataSet
            SqlDataAdapter1.Fill(dsSTOCK, "STOCKSITEMS")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                PictureBox2False()
                TestNet = False
                e.Cancel = True
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                PictureBox2False()
                e.Cancel = True
                MessageBox.Show(ex.Message, "Error3", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            BS.DataSource = dsSTOCK.Tables("STOCKSITEMS")
            PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            If DelRow = False Then
                If BS.Count < RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 48 + 524288, "تحديث السجلات")
                ElseIf BS.Count > RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين باضافة سجلات عدد " & BS.Count - RowCount, 48 + 524288, "تحديث السجلات")
                End If
            Else
                DelRow = False
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error4", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:
            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()

            'SqlDataAdapter1.Update(dsSTOCK, "STOCKSITEMS")
            'dsSTOCK = New DataSet
            'SqlDataAdapter1.Fill(dsSTOCK, "STOCKSITEMS")
            'dsSTOCK.RejectChanges()
        Catch ex As Exception
            If ex.Message.GetHashCode = -1115812848 Or ex.Message.GetHashCode = 379362862 Then
                e.Cancel = True
                PictureBox2False()
            ElseIf ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                e.Cancel = True
                TestNet = False
                PictureBox2False()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            ElseIf ex.Message.GetHashCode = -652120241 Or ex.Message.GetHashCode = 2067669773 Then
                DelRow = True
                PictureBox2False()
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
            Else
                e.Cancel = True
                PictureBox2False()
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                RefreshTab = New ComponentModel.BackgroundWorker With {
                    .WorkerReportsProgress = True,
                    .WorkerSupportsCancellation = True
                }
                RefreshTab.RunWorkerAsync()
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            BS.DataSource = dsSTOCK.Tables("STOCKSITEMS")
            Me.Cursor = Cursors.Default
            PictureBox2.Visible = False
            If BS.Count < RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf BS.Count > RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & BS.Count - RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
            Dim Sound As IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error6", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            PictureBox2.Visible = False
            PictureBox5.Visible = False
        End If
    End Sub
    Private Sub CLEARDATA()
        On Error Resume Next
        Dim txt As Control
        For Each txt In Me.Controls
            If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Then
                txt.Text = ""
            End If
        Next
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim Consum As New SqlConnection(constring)
        Dim strsql1 As New SqlCommand("SELECT DISTINCT STK1 FROM STOCKS WHERE STK25 = '" & Me.TEXTITEMCODE.Text & "'", Consum)
        Dim ds1 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql1)
        On Error Resume Next
        ds1.Clear()
        Adp1.Fill(ds1, "STOCKS")
        If ds1.Tables(0).Rows.Count > 0 Then
            MsgBox("لايمكن حذف  السجل الحالى لأنه مرتبط بحركات المستودع ... ", 16, "تنبيه")
            Exit Sub
        Else
            MYDELETERECORD("STOCKSITEMS", "SKITM1", TEXT1, BS, True)
            FrmStocks1_Load(sender, e)
            Insert_Actions(Me.TEXT1.Text.Trim, "حذف", Me.Text)
        End If
    End Sub
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles InternalAuditorERBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        'If Me.CheckBox2.Checked = False Then
        '    MsgBox("عفوا .. لايمكن مراجعة السجلات قبل الترحيل الى الحسابات", 16, "تنبيه")
        '    Exit Sub
        'End If
        Static P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = True
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        MsgBox("تمت عمليةالمراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Insert_Actions(Me.TEXT1.Text.Trim, "المراجع", Me.Text)
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckLogReview.Checked = False Then
            MsgBox("عفوا .. هذا السجل غير مراجع ", 16, "تنبيه")
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = False
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        MsgBox("تمت عملية إلغاء المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Insert_Actions(Me.TEXT1.Text.Trim, "إلغاء المراجعة", Me.Text)
    End Sub
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FIRSTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PREVIOUSBUTTON.Click
        On Error Resume Next
        Me.BS.Position = BS.Position - 1
        Me.RecordCount()
    End Sub
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NEXTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = BS.Position + 1
        Me.RecordCount()
    End Sub
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
        On Error Resume Next
        BS.Position = BS.Count - 1
        RecordCount()
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
    Private Sub UPDATEBALANCEITEMS()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim sql As New SqlCommand("UPDATE STOCKS SET STK25 = @STK25 WHERE STK7='" & Me.TEXTITEMNAME.Text.Trim & "'" & " AND CUser='" & CUser & "'", Consum)
        Dim CMD As New SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@STK25", System.Data.SqlDbType.Int).Value = Val(Me.TEXTITEMCODE.Text)
            '.Parameters.Add("@Price", System.Data.SqlDbType.Float).Value = Val(Me.TEXT11.Text), SKITM8 = @Price
            .CommandText = sql.CommandText
        End With
        CMD.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Position
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.UPDATEBALANCEITEMS()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.SHOWBUTTON()
        Insert_Actions(Me.TEXT1.Text.Trim, "تعديل", Me.Text)
    End Sub
    Private Sub LISTBOX_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LISTBOX.Click
        On Error Resume Next
        Me.BS.Position = Me.LISTBOX.SelectedIndex
    End Sub
    Private Sub TEXT7_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTUnitPrice.EditValueChanged, TextThirdSalePrice.EditValueChanged, TextSecondSellingPrice.EditValueChanged, TextHashUnitNumber2.EditValueChanged, TextHashUnitNumber1.EditValueChanged, TEXTDiscount.EditValueChanged
        On Error Resume Next
        TEXTPurchasingPrice.EditValue = Format(Val(TextQUANTITY.Text) * Val(TEXTUnitPrice.EditValue) * (100 - Val(TEXTDiscount.EditValue)) / 100, "0.000")
        TextTotalSecondSellingPrice.EditValue = Format(Val(TextSecondSellingPrice.EditValue) * Val(TextHashUnitNumber1.EditValue) * (100 - Val(TextDiscountPercentageWhenSelling.EditValue)) / 100, "0.000")
        TextTotalThirdSalePrice.EditValue = Format(Val(TextThirdSalePrice.EditValue) * Val(TextHashUnitNumber2.EditValue) * (100 - Val(TextDiscountPercentageWhenSelling.EditValue)) / 100, "0.000")
    End Sub
    Private Sub TEXT13_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            If Not IsDate(ProductionDate.Text) Then
                MsgBox("تاريخ غير صالخ")
                ProductionDate.Focus()
            Else
                Dim years As Double
                Dim SecondDate As Date
                SecondDate = CDate(ProductionDate.Text)
                years = 5
                ExpiryDate.Text = DateAdd(DateInterval.Year, years, SecondDate)
                ExpiryDate.Focus()
            End If
        End If
    End Sub
    Private Sub ButAA_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonItemCode.Click
        strlnputstring = "946564126535615326241565642353261235326412356642653613562315665235466524363221356223415662435656235466523546213565235456282043653898373898373653535898378983736535353627282993930393837664535343434957544389837365353536272829939303938376645353434348983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293458983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453689837365353589837898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498983736535353627282993930393837664535343434850982495722372839030495625366736873986453623728390304985098249572408572435728457234752439875234875082347529345562536673687398645362372839030493294628204989837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049575443329958372920495556377383949958575659484746353526474849404098385757773464626627987635242526373898373653535362728299393039383766453534343485098249589837389837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030497240898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498572435728457234752439875289837365353589837898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875236538983738983736535358983789837365353536272829939303938376645353434343487508234752934556253667368739864536237898373653535898378983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304936535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304989837365353536289837365353589837898378983736535358983789837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049898373653535362728299393039383766453534343485098249572898373653535898378983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304936535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304989837365353536272829939303938376645353434348509824957289837365353589837898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498983736535353627282993930393837664535343434850982495728983736535358983789837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049898373653535362728299393039383766453534343485098249572898373653535898378983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304936535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304989837365353536272829939303938376645353434348509824957289837365353589837898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498983736535353627282993930393837664535343434850982495728983736535358983789837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049898373653535362728299393039383766453534343485098249572898373653535898378983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304936535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304989837365353536272829939303938376645353434348509824957289837365353589837898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498983736535353627282993930393837664535343434850982495723653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498983736535353627282993930393837664535343434850982495727282993930393837664535343434850982495722839030498983736535353627282993930393837664535343434850982495723487508 " &
           "23475293455625366736873986453623728390304948474635353637383904034049529562356356356898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493673596825923098374646222345094584574995837294628204957544332995837292049555637738394995857565948474635352647484940409838575777346462662798763898373653535362728299393039383766453534343485098249572408572435728457234752439889837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368898373653535362728299393039383766453534343485098249578983736535358983789837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049898373653535362728299393039383766453534343485098249898373653535898378983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304936535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304989837365353536272829939303938376645353434348509824957257224085724357284572347524398752348750823475293455625366736873986453623728390304973986453623789837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049283903049752348750823475293455625366736873986453623728390304952898373653535898378983736535353627282993930393837663653898373898373653535898378983736535353627282993930393837664535343434453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030489837365353589837898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372889837365353589837898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498983736535353627282993930393837664535343434850982495723903049898373653535362728299393039383766453534343485098249572989837365353536272829939303938376645353434348509824957242526373" &
"898365389837389833653898373898373653535898378983736535353627282993930393837664535343434736535358983789837365353536272829939303938376645353434343736535358983898373653535898378983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304936535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304989837365353536289837365353589837898373653535362728299393039383766453534343485098249572408572465465465485646465466666666666666444444444444444444444444444444888888888885456446546546546545646546546546548421324654654564654654654654875132165487865432132165464414654655466543245746749744514214346545942145142124454515415433649754541242424154544464245421241542421512424542121215454412452543543654654325434656543299999999999999999999999999999999999999999999999999999999999999999999999999999777777777777777777777777777777777145852572675572572572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498983736535353627282993930393837664535343434850982495789837365353589837898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498983736535353627282993930393837664535343434850982495722728299393039383766453534343485098249572898373653535898378983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304936535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304989837365353538983736535358983789837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049898373653535362728299393039383766453534343485098249572627282993930393837664535343434853653898373898373653535898378983736535353627282993930393837664535343434098249572789837365353536272829939303938376645353434348509824957240857248983736535358983789837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049898373653535362728299393039383766453534343485098249572898373653535898378983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304936535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304989837365353536272829939303938376645353434348509824957289837365353589837898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498983736535353627282993930393837664535343434850982495728983736535358983789837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049898373653535362728299393039383766453534343485098249572898373653535898378983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304936535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304989837365353536272829939303938376645353434348509824957235728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304936272829898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030499393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839089837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049304948474635353637383904034049529562356356356367359682592309837464622234509458457492049555637738389837365353589837898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498983736535353627282993930393837664535343434850982495729499585756594847463535264748494040983857577734646266279876352428983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304952898983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390389837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049049837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049637389837" &
"365389837389837365353589837898373653535362725464543216543216546546555555555555555555555555566546534452653465642653546265356426535642653564265346285356423556465235467283567235765235462535164523546728536782935642653546235166523546235748635768299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498983736535353627282993930393837664535343434850982495728983736535358983789837365353536272829939303938376645353434348509365389837389837365353589837898373653535362728299393039383766453534343482495724085724357284572347524398752348750823475293455625366736873986453623728390304936535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304989837365353536272829939303938376645353434348509824957265353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049589889837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752938983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304945562536673687398645362372839030493736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304935362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030494847494628204957544332995837292049555637738394995857565948474635352647484940409838575777346462662798763524252637389837365389837365353536272829939303938376645353434348509824953653898373898373653535898378983736535353627282993930393837664535343434723653898373898373653535898378983736535353627282993930393837664535343434408572435728457234752439875234875082347529345562536673687398645898373653535898378983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304936535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304989837365353536272829939303938376645353434348509824957236237283903049535362728299393039383766453589837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049343434850982495724085724357284572347524398752348983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986458983736535353627282898373653535362728299393039383766453534343485098249572408572435728457234752439875234898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498750823475293455625366736873986453623728390304999393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493623728390304987508234752934" &
"556253667368733653898373898373653535898378983736535353627282993930393837664535343434365389837389837365353589837898373653535362728299393039383766453534343436538983738983736535358983789837365353536272829939303938376645353434343653898373898373653535898378983736535353627282993930393837664535343434365389837389837365353589837898373653535362728299393039383766453534343436538983738983736535358983789837365353536272829939303938376645353365389837389837365353589837898373653535362728299393039383766453534343436538983738983736535358983789837365353536272829939303938376645353434343653898373898373653535898378983736535353627282993930393837664535343434365389837389837365353589837898373653535362728299393039383766453534343436538983738983736535358983789837365353536272829939303938376645353434343653898373898373653535898378983736535353627282993930393837664535343434365389837389837365353589837898373653535362728299393039383766453534343436538983738983736535358983789837365353536272829939303938376645353434343653898373898373653535898378983736535353627282993930393837664535343434365389837389837365353589837898373653535362728299393039383766453534343436538983738983736535358983789837365353536272829939303938376645353434343653898373898373653535898378983736535353627282993930393837664535343434365389837389837365353589837898373653535362728299393039383766453534343436538983738983736535358983789837365353536272829939303938376645353434343653898373898373653535898378983653898373898373653535898378983736535353627282993930393653898373898373653535898378983736535353627282993930393837664535343434383766453534343437365353536272829939303938376645353434344343498898373653535898378983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304936535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304989837365353536272829939303938376645353434348509824957264536237283903049484746353536373839040340495295623563563563673598983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304968259230983746462223450945845746353536373839040340495295689837365353589837898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498983736535353627282993930393837664535343434850982495722356356356898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493673596825923098374623563563563673596826235635635623563898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030898373658983736535358983789837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049898373653535362728299393039383766453534343485098249572353589837898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030493653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030498983736535353627282993930393837664535343434850982495724956356367359898373653535362728299393039383766453534343485098249572408572435728457234752439875234875082347529345562536673687398645362372839030496826235635635636735968263673596826235623563563563673596826356356367359682646222345096235635623563563563673596826356367359682462356356356367359682584578983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455628983736535353627282993930393837664535343434850982495724085724357284589837365353536272829939303938376645353434348509824957240857243572845723475243987523487508234752934556253667368739864536237283903049723475243987523487508234752934556253667368739864536237283903049536673687398645362372839030498983736535353627282993930393837664535343434850982495724085724357284572347524398752348750823475293455625366736873986453623728390304943"
        intlength = Len(strlnputstring)
        intnamelength = 6
        Randomize()
        strname = "000"
        For intstep = 1 To intnamelength
            intrand = Int(intlength * Rnd()) + 1
            strname &= Mid(strlnputstring, intrand, 1)
        Next
        TEXTITEMCODE.Text = strname
    End Sub
    Private Sub Buted_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Buted.Click
        On Error Resume Next
        Dim f As New Form_EDIT
        f.Show()
    End Sub

    Private Sub ComboGROUPNAME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboGROUPNAME.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT SKITM2  FROM STOCKSITEMS WHERE SKITM3 ='" & Me.ComboGROUPNAME.Text & "'", Consum)

        'SKITM4  FROM STOCKSITEMS

        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXTGROUPCODE.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TEXTGROUPCODE.Text = ""
        End If
        Me.TEXTGROUPCODE.Enabled = False
        Adp.Dispose()
        Consum.Close()
    End Sub

    Private Sub ChkPD_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPD.CheckedChanged
        If ChkPD.Checked = True Then
            ProductionDate.Enabled = True
            ExpiryDate.Enabled = True
        Else
            ProductionDate.Enabled = False
            ExpiryDate.Enabled = False
        End If
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button1.Click
        On Error Resume Next
        Dim f As New Form_barcode
        'f.TxtItemsBarcode.Text = Me.TEXTITEMCODE.Text.Trim
        'f.TxtItemsName.Text = Me.TEXTITEMNAME.Text.Trim
        'f.TxtItemsPrixVente.Text = Me.TexTSellingPrice.EditValue
        f.Show()
    End Sub


End Class