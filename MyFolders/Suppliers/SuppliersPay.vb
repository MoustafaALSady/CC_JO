Option Explicit Off
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class SuppliersPay
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim ds As New DataSet
    Public SqlDataAdapter1 As SqlDataAdapter
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveDataBase As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()

    Dim T1 As Integer
    Dim T2 As Integer
    Dim T3 As String
    Dim T4 As String
    ReadOnly T5 As String
    ReadOnly T6 As String
    Dim T7 As String
    Dim T8 As String
    Dim T9 As String
    Dim T10 As Integer
    Dim Dec1, Dec2 As Decimal
    Dim nem As String
    Dim n As String
    Dim B As String
    Dim pp As String
    Dim A As Integer
    Dim C As Integer
    Dim s = "'"
    Private ReadOnly Typ As String
    Private Typ1 As String
    Private Typ2 As String
    Dim RowCount As Integer = 0
    ReadOnly phieght As Integer = 1

    Public Sub ClsTxt()
        Dim I As Integer
        For I = 0 To Me.Controls.Count - 1
            If TypeOf Me.Controls(I) Is TextBox _
            Or TypeOf Me.Controls(I) Is ComboBox _
               Or TypeOf Me.Controls(I) Is MaskedTextBox Then
                Me.Controls(I).Enabled = False
                Me.Controls(I).Text = ""
            End If
        Next

    End Sub
    Public Sub AppTxt()
        Dim I As Integer
        For I = 0 To Me.Controls.Count - 1
            If TypeOf Me.Controls(I) Is TextBox _
            Or TypeOf Me.Controls(I) Is ComboBox _
               Or TypeOf Me.Controls(I) Is MaskedTextBox Then
                Me.Controls(I).Enabled = True
            End If
        Next
    End Sub
    Private Sub CheckbeforeRec()
        If Not IsNumeric(TextBox1.Text) Then
            MsgBox("ÌÃ» √œŒ«· —ﬁ„ «·”Ã·")
            TextBox1.Focus()
            Exit Sub
        Else
        End If
        If Trim(TextBox2.Text) = "" Then
            MsgBox("ÌÃ» √œŒ«· √”„ «·⁄„Ì·")
            TextBox2.Focus()
            Exit Sub
        End If
        If IsNumeric(TextBox3.Text) = False Then
            MsgBox("ÌÃ» √œŒ«· „»·€ «· ”œÌœ „‰ ··⁄„Ì·")
            TextBox3.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub SuppliersPay_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT * FROM SupplierPay  WHERE  CUser='" & CUser & "'  ORDER BY lo1"
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                SqlDataAdapter1 = New SqlDataAdapter(strSQL)
                Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "SupplierPay")
                BS.DataSource = ds
                BS.DataMember = "SupplierPay"
            End With

            ConnectDataBase = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            ConnectDataBase.RunWorkerAsync()
            Me.TextBox13.Text = CUser
            FILLCOMBOBOX("ACCOUNTSTREE", "account_name", Me.ComboBox7)
            '==============================
            MangUsers()
            Consum.Close()
            MAXRECORD2()
            SEARCHDATAITEMS6()
            SEARCHDATAITEMS7()
            SEARCHDATAITEMS4()
            Me.TextBox37.Text = "DE" & "/" & " " & Me.TextBox5.Text & "/" & Me.TextBox6.Text
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SumAmounBALANCE()
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(Loa6)  FROM SupplierPay WHERE Lo1 ='" & Me.TextBox5.Text & "'", Consum)
        Consum = New SqlConnection(constring)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextBox7.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)) - Me.TextBox3.Text, "0.000")
        Else
            Me.TextBox7.Text = "0"
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try

1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            ds = New DataSet
            SqlDataAdapter1.Fill(ds, "SupplierPay")
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                LoadDataBase()
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
            '   Label20.ForeColor = Color.Yellow
        Else
            Me.Close()
        End If
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            BS.DataSource = ds.Tables("SupplierPay")
            RowCount = BS.Count
            TextBox6.DataBindings.Add("text", BS, "Loa", True, 1, "")
            TextBox5.DataBindings.Add("text", BS, "Lo1", True, 1, "")
            TextBox11.DataBindings.Add("text", BS, "Loa1", True, 1, "")
            TextBox17.DataBindings.Add("text", BS, "Loa3", True, 1, "")
            TextBox4.DataBindings.Add("text", BS, "Loa4", True, 1, "")
            MTextBox1.DataBindings.Add("text", BS, "Loa5", True, 1, "")

            TextBox3.DataBindings.Add("text", BS, "Loa6", True, 1, "")

            TextBox8.DataBindings.Add("text", BS, "Loa8", True, 1, "")
            TextBox12.DataBindings.Add("text", BS, "Loa9", True, 1, "")

            TextBox1.DataBindings.Add("text", BS, "Loa10", True, 1, "")
            TextBox2.DataBindings.Add("text", BS, "Loa11", True, 1, "")
            TextBox9.DataBindings.Add("text", BS, "Loa12", True, 1, "")
            TextBox10.DataBindings.Add("text", BS, "Loa13", True, 1, "")
            CheckBox2.DataBindings.Add("Checked", BS, "Loa14", True, 1, "")
            'TextBox37.DataBindings.Add("text", BS, "Lo25", True, 1, "")
            TextBox15.DataBindings.Add("text", BS, "Lo25", True, 1, "")
            TextBox13.DataBindings.Add("text", BS, "USERNAME", True, 1, "")
            TextBox23.DataBindings.Add("text", BS, "da", True, 1, "")
            TextBox24.DataBindings.Add("text", BS, "ne", True, 1, "")
            GETBANKNOWBALANCE()
            InternalAuditorBalance()
            SumAmount()
            MAXRECORD2()
            SEARCHDATAITEMS6()
            SEARCHDATAITEMS7()
            SEARCHDATAITEMS4()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveDataBase.DoWork
        Try
1:
            Dim myBuilder As New SqlCommandBuilder(SqlDataAdapter1)
            myBuilder.GetUpdateCommand()
            SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()
            SqlDataAdapter1.Update(ds, "SupplierPay")
            ds = New DataSet
            SqlDataAdapter1.Fill(ds, "SupplierPay")
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then
                PictureBox2.Visible = False
                Exit Sub
            End If
            ' «»⁄ ﬂÊœ Õ›Ÿ «·«÷«›… Ê«· ⁄œÌ·
            Application.DoEvents()
            BS.DataSource = ds.Tables("SupplierPay")
            ''Me.TextBox9.Text = CurrencyJO(Me.TextBox3.Text, "jO")
            ''Me.TextBox10.Text = CurrencyJO(Me.TextBox12.Text, "jO")
            PictureBox2.Visible = False
            Dim Sound As IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
            PictureBox2.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub MTextBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MTextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If IsDate(MTextBox1.Text) = True Then
                CmdSave.Enabled = True
                CmdSave.Focus()
            Else
                MsgBox(" «—ÌŒ Œ«ÿ∆")
                MTextBox1.Focus()
            End If
        End If
    End Sub
    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextBox3.TextChanged, TextBox12.TextChanged
        On Error Resume Next
        '   TextBox7.Text = TextBox12.Text
        ' Me.TextBox10.Text = CurrencyJO(Me.TextBox7.Text, "jO")
        Dim p As String
        If ds.Tables("SupplierPay").Compute("Count(Loa1)", "Loa7 ='" & TextBox3.Text.Trim.ToLower & "'").ToString > 0 Then
            p = " „ «· ”œÌœ"
        ElseIf ds.Tables("SupplierPay").Compute("Count(Loa1)", "Loa7 >'" & TextBox3.Text.Trim.ToLower & "'").ToString > 0 Then
            p = "·„ Ì”œœ ﬂ«„· «·«ﬁ”ÿ"
        Else
            p = "·„ Ì „ «· ”œÌœ"
        End If
        Me.TextBox17.Text = p
        Me.TextBox13.Text = USERNAME
        Me.TextBox23.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextBox24.Text = ServerDateTime.ToString("hh:mm:ss tt")
        InternalAuditorBalance()
    End Sub
    Private Sub GETBANKNOWBALANCE()
        On Error Resume Next
        Dim n As Double
        Dim F As Double
        n = BS.Position
        BS.EndEdit()
        If BS.Position = 0 Then
            Me.TextBox8.Text = Val(TextBox12.Text) - Val(TextBox7.Text)
        ElseIf BS.Position > 0 Then
            F = 0
            BS.Position = BS.Position - 1
            F = Val(TextBox12.Text) - Val(TextBox7.Text)
            BS.Position = BS.Position + 1
            Me.TextBox8.Text = F
        End If
    End Sub
    Private Sub SumAmount()
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(Loa6) FROM SupplierPay WHERE Lo1 ='" & Me.TextBox5.Text & "'", Consum)
        Dim ds2 As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds2.Clear()
        Adp.Fill(ds2)
        If ds2.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds2.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Adp.Dispose()
        Consum.Close()
        Me.TextBox7.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub InternalAuditorBalance()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT sum(Loa6)  FROM SupplierPay  WHERE SupplierPay.Lo1='" & Me.TextBox5.Text & "'AND SupplierPay.Loa1 <'" & Me.TextBox11.Text & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsq1)
        ds.Clear()
        Adp1.Fill(ds, "SupplierPay")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextBox7.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            Me.TextBox7.Text = "0"
        End If
        Adp1.Dispose()
        Consum.Close()
        '  Catch ex As Exception
        'Me.TextBox7.Text = "0"
        '  End Try
        Consum.Close()
    End Sub
    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CmdSave.Click
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockSave = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If

        Dim p As String
        If ds.Tables("SupplierPay").Compute("Count(Loa1)", "Loa7 ='" & TextBox3.Text.Trim.ToLower & "'").ToString > 0 Then
            p = " „ «· ”œÌœ"
        ElseIf ds.Tables("SupplierPay").Compute("Count(Loa1)", "Loa7 >'" & TextBox3.Text.Trim.ToLower & "'").ToString > 0 Then
            p = "·„ Ì”œ«œ ﬂ«„· «·«ﬁ”ÿ"
        Else
            p = "·„ Ì „ «· ”œÌœ"
        End If
        GETBANKNOWBALANCE()
        Me.TextBox37.Text = "DE" & "/" & " " & Me.TextBox5.Text & "/" & Me.TextBox6.Text
        Me.TextBox17.Text = p.Trim.ToLower
        Me.TextBox13.Text = USERNAME
        Me.TextBox23.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextBox24.Text = ServerDateTime.ToString("hh:mm:ss tt")
        InternalAuditorBalance()
        Me.Cursor = Cursors.WaitCursor
        PictureBox2.Visible = True
        BS.EndEdit()
        SaveDataBase = New ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        SaveDataBase.RunWorkerAsync()
    End Sub
    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub
    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CmdCancel.Click
        On Error Resume Next
        BS.CancelEdit()
    End Sub
    Private Sub TextBox3_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox3.TextChanged
        On Error Resume Next
        TextBox8.Text = Format(Val(TextBox12.Text) - Val(TextBox7.Text), "0.000")
        ' TextBox12.Text = Format(Val(TextBox7.Text), "0.000")
        Me.TextBox9.Text = CurrencyJO(Me.TextBox3.Text, "jO")
        Me.TextBox10.Text = CurrencyJO(Me.TextBox8.Text, "jO")
        InternalAuditorBalance()
    End Sub
    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CmdSearch.Click
        Try
            Dim HeightInInch As Double
            HeightInInch = (phieght * 0.24096) + 0.90921
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Dim F As New FrmPRINT
            Dim txt As TextObject
            Dim rpt As New rptcash
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            ' rpt.SetDatabaseLogon("sa", "2710/m") '·ﬂÌ ·« Ìÿ·» »«”Ê—œ «À‰«¡ «· ‰›Ì–
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM SupplierPay  WHERE LO1 ='" & Me.TextBox5.Text & "' AND Loa=" & TextBox6.Text, Consum)
            '  Dim builder68 As New SqlCommandBuilder(DataAdapterTab65)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "SupplierPay")
            rpt.SetDataSource(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                txt = rpt.Section1.ReportObjects("TEXT2")
                ' txt.Text = "⁄ﬁœ »Ì‹‹‹‹‹‹‹‹‹‹‹‹‹‹‹‹‹‹‹‹⁄ »«·≈ﬁ”«ÿ"
                txt = rpt.Section1.ReportObjects("TEXT7")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT42")
                txt.Text = Character
                txt = rpt.Section1.ReportObjects("TEXT43")
                txt.Text = Ty1

                txt = rpt.Section1.ReportObjects("TEXT9")
                txt.Text = Directorate
                txt = rpt.Section1.ReportObjects("TEXT44")
                txt.Text = Recorded

                txt = rpt.Section1.ReportObjects("TEXT40")
                txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1

                txt = rpt.Section1.ReportObjects("TEXT18")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT6")
                txt.Text = Character
                txt = rpt.Section1.ReportObjects("Text31")
                txt.Text = Ty1
                txt = rpt.Section1.ReportObjects("TEXT19")
                txt.Text = Directorate
                txt = rpt.Section1.ReportObjects("Text49")
                txt.Text = Recorded
                txt = rpt.Section1.ReportObjects("Text45")
                txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1




                F.CrystalReportViewer1.ReportSource = rpt
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.Refresh()
                F.Show()
            Else
                MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub CustomerPay_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        On Error Resume Next
        Consum.Close()
    End Sub
    Private Sub INSERTRECORDempsolf()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim N As Double
            Dim cmd1 As New SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            N = cmd1.ExecuteScalar
            Consum.Close()
            Dim SQL As New SqlCommand("INSERT INTO CASHIER( CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH10, CSH11, CSH12, CSH14, CSH15, CSH16, CSH17, USERNAME, CUser, COUser, da, ne) VALUES     ( @CSH2, @CSH3, @CSH4, @CSH5, @CSH6, @CSH7, @CSH8, @CSH10, @CSH11, @CSH12, @CSH14, @CSH15, @CSH16, @CSH17, @USERNAME, @CUser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CSH2", SqlDbType.DateTime).Value = Me.MTextBox1.Text.Trim
                .Parameters.Add("@CSH3", SqlDbType.NVarChar).Value = "’—›"
                .Parameters.Add("@CSH4", SqlDbType.NVarChar).Value = Me.TextBox37.Text.Trim
                .Parameters.Add("@CSH5", SqlDbType.NVarChar).Value = "‰ﬁœ«"
                .Parameters.Add("@CSH6", SqlDbType.NVarChar).Value = Format(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N), "0.000")
                .Parameters.Add("@CSH7", SqlDbType.NVarChar).Value = "0"
                .Parameters.Add("@CSH8", SqlDbType.NVarChar).Value = Me.TextBox3.Text.Trim
                .Parameters.Add("@CSH10", SqlDbType.NVarChar).Value = "«·–„„ «·œ«∆‰…"
                .Parameters.Add("@CSH11", SqlDbType.NVarChar).Value = "”œ«œ «ﬁ”«ÿ"
                .Parameters.Add("@CSH12", SqlDbType.NVarChar).Value = " „‰ Õ”«» Õ—ﬂ… «·„Ê—œ «”„ Ê —ﬁ„ " & " _ " & Me.TextBox1.Text & "_" & Me.TextBox2.Text
                .Parameters.Add("@CSH14", SqlDbType.Bit).Value = False
                .Parameters.Add("@CSH15", SqlDbType.NVarChar).Value = Me.TextBox15.Text.Trim
                .Parameters.Add("@CSH16", SqlDbType.Bit).Value = False
                .Parameters.Add("@CSH17", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckBox2.Checked)
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub UPDATERECORDempsolf()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As String = " Update CASHIER SET  CSH2 = @CSH2, CSH3 = @CSH3, CSH4 = @CSH4, CSH5 = @CSH5, CSH7 = @CSH7, CSH8 = @CSH8, CSH10 = @CSH10, CSH11 = @CSH11, CSH12 = @CSH12, CSH15 = @CSH15, CSH17 = @CSH17, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser, da = @da WHERE CSH4 = '" & Me.TextBox1.Text.ToString & "'" & "AND CSH10='«·–„„ «·„œÌ‰…'"
        Dim CMD As New SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@CSH2", SqlDbType.DateTime).Value = Me.MTextBox1.Text.Trim
            .Parameters.Add("@CSH3", SqlDbType.NVarChar).Value = "’—›"
            .Parameters.Add("@CSH4", SqlDbType.NVarChar).Value = Me.TextBox37.Text.Trim
            .Parameters.Add("@CSH5", SqlDbType.NVarChar).Value = "‰ﬁœ«"
            .Parameters.Add("@CSH7", SqlDbType.NVarChar).Value = Me.TextBox3.Text.Trim
            .Parameters.Add("@CSH8", SqlDbType.NVarChar).Value = "0"
            .Parameters.Add("@CSH10", SqlDbType.NVarChar).Value = "«·–„„ «·„œÌ‰…"
            .Parameters.Add("@CSH11", SqlDbType.NVarChar).Value = "”œ«œ «ﬁ”«ÿ"
            .Parameters.Add("@CSH12", SqlDbType.NVarChar).Value = " „‰ Õ”«» Õ—ﬂ… «·„Ê—œ «”„ Ê —ﬁ„ " & " _ " & Me.TextBox1.Text & "_" & Me.TextBox2.Text
            .Parameters.Add("@CSH15", SqlDbType.NVarChar).Value = Me.TextBox15.Text.Trim
            .Parameters.Add("@CSH17", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckBox2.Checked)
            .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
            .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
            .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
            .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
            .Parameters.Add("@CSH16", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckBox2.Checked)
            .CommandText = SQL
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        CMD.ExecuteNonQuery()
        Consum.Close()
        '  Catch ex As Exception
        'MessageBox.Show(ex.Message & ex.Source)
        '    End Try
    End Sub

    Private Sub DELETEDATAempsolf()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim sql As String = "DELETE FROM CASHIER  WHERE CSH4 = '" & Me.TextBox5.Text.ToString & "'"
            Dim cmd As New SqlCommand(sql, Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub INSERTDATACO1()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim N As Double
            Dim cmd2 As New SqlCommand("SELECT MAX(IDCAB) FROM Suppliers1", Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            N = cmd2.ExecuteScalar
            Consum.Close()
            Dim SQL As New SqlCommand("INSERT INTO Suppliers1(CAB2, CAB3, CAB4, CAB5, CAB6, CAB8, CAB9, CAB10, CAB11, CAB12, CAB17, CAB21, USERNAME, Cuser, COUser, da, ne) VALUES  ( @CAB2, @CAB3, @CAB4, @CAB5, @CAB6, @CAB8, @CAB9, @CAB10, @CAB11, @CAB12, @CAB17, @CAB21, @USERNAME, @Cuser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                '.Parameters.Add("@IDCAB", SqlDbType.Int).Value = Val(N) + 1
                .Parameters.Add("@CAB2", SqlDbType.NVarChar).Value = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextBox1.Text, N)), "0.000")
                .Parameters.Add("@CAB3", SqlDbType.Date).Value = MTextBox1.Text.Trim
                .Parameters.Add("@CAB4", SqlDbType.NVarChar).Value = Me.TextBox3.Text
                .Parameters.Add("@CAB5", SqlDbType.NVarChar).Value = "0.00"
                .Parameters.Add("@CAB6", SqlDbType.NVarChar).Value = "‰ﬁœ«"
                .Parameters.Add("@CAB8", SqlDbType.NVarChar).Value = Me.TextBox4.Text
                .Parameters.Add("@CAB9", SqlDbType.NVarChar).Value = "„‰ Õ”«» Õ—ﬂ… «·„Ê—œ" & "_" & Me.TextBox2.Text
                .Parameters.Add("@CAB10", SqlDbType.NVarChar).Value = Me.TextBox2.Text
                .Parameters.Add("@CAB11", SqlDbType.NVarChar).Value = Me.TextBox1.Text
                .Parameters.Add("@CAB17", SqlDbType.NVarChar).Value = "«·„‘ —Ì« "
                .Parameters.Add("@CAB21", SqlDbType.NVarChar).Value = Me.TextBox37.Text
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = TextBox23.Text
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = TextBox24.Text
                If Cash = True Then
                    .Parameters.Add("@CAB12", SqlDbType.NVarChar).Value = "‰ﬁ‹‹‹‹‹‹œÏ"
                Else
                    .Parameters.Add("@CAB12", SqlDbType.NVarChar).Value = "√Ã‹‹‹‹‹‹‹·"
                    'Exit Sub
                End If
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub UPDATEDATACO1()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim sql As String = "UPDATE Suppliers1 SET CAB3 = @CAB3, CAB4 = @CAB4, CAB5 = @CAB5, CAB6 = @CAB6, CAB8 = @CAB8, CAB9 = @CAB9, CAB10 = @CAB10, CAB11 = @CAB11, CAB12 = @CAB12, CAB17 = @CAB17, USERNAME = @USERNAME, Cuser = @Cuser, COUser = @COUser, da = @da, ne = @ne WHERE CAB8 = '" & Me.TextBox4.Text & "'" & "AND CAB6 ='‰ﬁœ«'" & " AND CAB21='" & Me.TextBox37.Text & "'"
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CAB3", SqlDbType.Date).Value = MTextBox1.Text.Trim
                .Parameters.Add("@CAB4", SqlDbType.NVarChar).Value = Me.TextBox3.Text
                .Parameters.Add("@CAB5", SqlDbType.NVarChar).Value = "0.00"
                .Parameters.Add("@CAB6", SqlDbType.NVarChar).Value = "‰ﬁœ«"
                .Parameters.Add("@CAB8", SqlDbType.NVarChar).Value = Me.TextBox4.Text
                .Parameters.Add("@CAB9", SqlDbType.NVarChar).Value = "„‰ Õ”«» Õ—ﬂ… «·„Ê—œ" & "_" & Me.TextBox2.Text
                .Parameters.Add("@CAB10", SqlDbType.NVarChar).Value = Me.TextBox2.Text
                .Parameters.Add("@CAB11", SqlDbType.NVarChar).Value = Me.TextBox1.Text
                .Parameters.Add("@CAB17", SqlDbType.NVarChar).Value = "”œ«œ «ﬁ”«ÿ"
                .Parameters.Add("@CAB21", SqlDbType.NVarChar).Value = Me.TextBox37.Text
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = TextBox23.Text
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = TextBox24.Text
                If Cash = True Then
                    .Parameters.Add("@CAB12", SqlDbType.NVarChar).Value = "‰ﬁ‹‹‹‹‹‹œÏ"
                Else
                    .Parameters.Add("@CAB12", SqlDbType.NVarChar).Value = "√Ã‹‹‹‹‹‹‹·"
                    'Exit Sub
                End If
                .CommandText = sql
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATACUSTOMER1()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim sql As String = "DELETE FROM Suppliers1  WHERE CAB8 = '" & Me.TextBox5.Text.ToString & "'" & "AND  CAB21='" & Me.TextBox37.Text & "'"
        Dim cmd As New SqlCommand(sql, Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        cmd.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub SEARCHDATAITEMS4()
        Dim Consum As New SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboBox7.Text & " '", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql2)
        On Error Resume Next
        ds2.Clear()
        Adp1.Fill(ds2, "ACCOUNTSTREE")
        If ds2.Tables(0).Rows.Count > 0 Then
            n = ds2.Tables(0).Rows(0).Item(0)
            B = ds2.Tables(0).Rows(0).Item(2)
            T3 = ds2.Tables(0).Rows(0).Item(1)
        Else
            n = ""
            B = ""
            T3 = ""
        End If
        Me.TextBox4.Text = T3.Trim.ToLower
    End Sub
    Private Sub ComboBox7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBox7.SelectedIndexChanged
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboBox7.Text & " '", Consum)
        Consum = New SqlConnection(constring)
        Dim ds2 As New DataSet
        Adp1 = New SqlDataAdapter(strsql2)
        ds2.Clear()
        Adp1.Fill(ds2, "ACCOUNTSTREE")
        If ds.Tables(0).Rows.Count > 0 Then
            n = ds2.Tables(0).Rows(0).Item(0)
            B = ds2.Tables(0).Rows(0).Item(2)
            T10 = ds2.Tables(0).Rows(0).Item(1)
        Else
            n = ""
            B = ""
            T10 = ""
        End If
        Me.TextBox33.Text = T10.ToString.Trim
        Me.TextBox34.Text = n.ToString.Trim
        MAXRECORD2()
        SEARCHDATAITEMS6()
        SEARCHDATAITEMS7()
        SEARCHDATAITEMS4()
    End Sub
    Private Sub SEARCHDATAITEMS6()
        Dim Consum As New SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT MOV1 FROM MOVES WHERE MOV2='" & TextBox31.Text & "'", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql2)
        On Error Resume Next
        ds2.Clear()
        Adp1.Fill(ds2, "MOVES")
        If ds2.Tables(0).Rows.Count > 0 Then
            T9 = ds2.Tables(0).Rows(0).Item(0)
        Else
            T9 = ""
        End If
        Me.TextBox32.Text = T9.Trim.ToLower
    End Sub
    Private Sub SEARCHDATAITEMS7()
        Dim Consum As New SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT MOVD1,MOV2,MOVD7 FROM MOVESDATA WHERE MOVD9 = '" & TextBox37.Text & " '" & "AND MOVD10 = '" & TextBox15.Text & "'", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql2)
        On Error Resume Next
        ds2.Clear()
        Adp1.Fill(ds2, "MOVESDATA")
        If ds2.Tables(0).Rows.Count > 0 Then
            T8 = ds2.Tables(0).Rows(0).Item(0)
            T7 = ds2.Tables(0).Rows(0).Item(1)
            Me.TextBox36.Text = ds2.Tables(0).Rows(0).Item(2)
        Else
            T8 = ""
            T7 = ""
        End If
        Me.TextBox35.Text = T8.Trim.ToLower
        Me.TextBox32.Text = T7.Trim.ToLower
    End Sub
    Private Sub MAXRECORD2()
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim V As Integer
        Dim SQL As New SqlCommand("SELECT MAX(MOVES.MOV1) ,MAX(MOVES.MOV2),MAX(MOVES.MOV8)  FROM MOVES", Consum)
        Dim CMD As New SqlCommand
        Dim ds1 As New DataSet
        Adp = New SqlDataAdapter(SQL)
        ds1.Clear()
        Adp.Fill(ds1)
        If ds1.Tables(0).Rows.Count > 0 Then
            Me.TextBox30.Text = ds1.Tables(0).Rows(0).Item(0)
            Me.TextBox31.Text = ds1.Tables(0).Rows(0).Item(1)
            Me.TextBox29.Text = ds1.Tables(0).Rows(0).Item(2)
        Else
            Me.TextBox30.Text = "0"
            Me.TextBox31.Text = "0"
            Me.TextBox29.Text = "0"
        End If

        Adp.Dispose()
        Consum.Close()
        T1 = Me.TextBox30.Text + 1
        T2 = Me.TextBox31.Text + 1
        T4 = Me.TextBox29.Text
        Me.TextBox33.Text = T10.ToString.Trim
        Me.TextBox32.Text = T8.Trim.ToLower
        Consum.Close()
        SEARCHDATAITEMS6()
        SEARCHDATAITEMS7()
        AutoEx()
    End Sub
    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = "—ﬁ„" & Me.TextBox5.Text & "   » «—ÌŒ:" & MTextBox1.Text
        ExResult += "   Õ”«» " & nem.Trim & vbNewLine
        Label9.Text = ExResult
        T3 = Label9.Text
        Me.TextBox33.Text = T10.ToString.Trim

    End Sub
    Private Sub SaveMOVESDATARecord()
        Try
            Dim Box, Box1, Box2, Box3 As Integer
            nem = "«·–„„ «·œ«∆‰…"
            pp = "1"
            A = TextBox12.Text
            s = Label9.Text
            C = "0.00"
            Dim Consum As New SqlConnection(constring)
            Dim strsq1 As New SqlCommand("SELECT MOV2  FROM MOVESDATA  WHERE (MOVESDATA.MOV2)='" & TextBox31.Text & "'", Consum)
            Dim ds As New DataSet
            Dim Adp1 As New SqlDataAdapter(strsq1)
            ds.Clear()
            Adp1.Fill(ds, "MOVESDATA")
            If ds.Tables(0).Rows.Count > 0 Then
                MessageBox.Show(" „  ”ÃÌ· »Ì«‰«  «·⁄ﬁœ ”«»ﬁ«", " ﬂ—«— «·⁄ﬁÊœ", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                '  Me.TEXT1.Focus()
                ' Exit Sub
            Else
                ' ComboBox2.Text = Val(ComboBox2.Text) + 1 'Remainder will add a new installment
            End If
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ModuleGeneral.CB2, 1)
            Box = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
            Box1 = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboBox7.Text, 1)
            Box2 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ComboBox7.Text, 1)
            Box3 = ID_Nam

            Dim strSQL As New SqlCommand("", Consum)
            Dim CMD As New SqlCommand

            TextBox34.Text = Box.ToString.Trim
            TextBox33.Text = T10.ToString.Trim
            ComboBox7.Text = B.Trim
            With strSQL
                If TextBox12.Text <> 0 Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV2) values('" _
                 & pp.ToString & "','" & ModuleGeneral.CB2.ToString & "','" & Box.ToString.Trim & "','" & TextBox3.ToString.Trim & "','" & 0 & "','" & nem.Trim & "','" & Box1.ToString.Trim & "','" & TextBox37.Text.Trim & "','" & TextBox15.Text.Trim & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                End If
                .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV2) values('" _
              & pp.ToString + 1 & "','" & ComboBox7.Text.Trim & "','" & Box2.ToString.Trim & "','" & 0 & "','" & TextBox3.ToString.Trim & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & TextBox37.Text.Trim & "','" & TextBox15.Text.Trim & "','" & T2.ToString.Trim & "')"
                CMD.CommandType = CommandType.Text
                CMD.Connection = Consum
                CMD.CommandText = strSQL.CommandText
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Consum.Close()
            End With
        Catch er As Exception
            MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UPDATEMOVESDATARecord()
        Try
            Dim Box As Integer
            nem = "«·–„„ «·œ«∆‰…"
            pp = "1"
            A = TextBox12.Text
            s = Label9.Text
            C = "0.00"
            Dim AA, BB As String
            '›« Ê—… „»Ì⁄« 
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ModuleGeneral.CB2, 1)
            Box = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", "«·–„„ «·œ«∆‰…", 1)
            C = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboBox7.Text, 1)
            AA = ID_Nam
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            Dim CMD As New SqlCommand


            If T10 = 1 Or T10 = 4 Then
                If TextBox12.Text = "" Or TextBox12.Text = 0 Then
                    TextBox12.Text = 0
                    Box = ID_Nam
                    BB = B.Trim
                    AA = "«·–„„ «·„œÌ‰…"
                    Dec1 = TextBox14.Text
                Else
                    n = ID_Nam
                    AA = "«·–„„ «·„œÌ‰…"
                    B = ComboBox7.Text
                    Dec1 = TextBox3.Text

                End If
                Dec2 = TextBox3.Text
                If T10 = 1 Then
                    Typ2 = Typ1
                    Typ1 = AA.Trim
                Else
                    Typ1 = Typ1
                    Typ2 = AA.Trim
                End If
            End If

            TextBox34.Text = Box.ToString.Trim
            TextBox33.Text = T10.ToString.Trim
            ComboBox7.Text = B.Trim
            If T10 = 1 Or T10 = 4 Then
                With strSQL
                    If TextBox12.Text <> 0 Then
                        .CommandText = "UPDATE  MOVESDATA SET MOVD5=" & Dec1.ToString.Trim & " Where MOV2=" & TextBox32.Text & "AND MOVD1=" & TextBox35.Text
                        CMD.CommandType = CommandType.Text
                        CMD.Connection = Consum
                        CMD.CommandText = strSQL.CommandText
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        CMD.ExecuteNonQuery()
                        Consum.Close()
                    End If

                    .CommandText = "UPDATE  MOVESDATA SET MOVD6=" & Dec1.ToString.Trim & " Where MOV2=" & TextBox32.Text & "AND MOVD2>" & 1
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                End With

            End If
        Catch er As Exception
            MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveMOVES()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand("INSERT INTO MOVES ( MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV11, USERNAME, Realname, cuser, COUser) VALUES     ( @MOV1, @MOV2, @MOV3, @MOV4, @MOV5, @MOV6, @MOV7, @MOV8, @MOV9, @MOV11, @USERNAME, @Realname, @cuser, @COUser)", Consum)
            Dim CMD As New SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOV1", SqlDbType.Int).Value = T1.ToString.Trim
                .Parameters.Add("@MOV2", SqlDbType.Int).Value = T2.ToString
                .Parameters.Add("@MOV3", SqlDbType.DateTime).Value = Me.MTextBox1.Text.Trim
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = Me.Label9.Text.Trim
                .Parameters.Add("@MOV5", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TextBox3.Text.Trim
                .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TextBox3.Text.Trim
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = T4.Trim
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = "’—›"
                .Parameters.Add("@MOV11", SqlDbType.NVarChar).Value = Me.TextBox37.Text
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@cuser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@Realname", SqlDbType.NVarChar).Value = Realname
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = Me.TextBox23.Text
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = Me.TextBox24.Text
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub UPDATEMOVES()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" UPDATE  MOVES SET  MOV3 = @MOV3, MOV4 = @MOV4, MOV5 = @MOV5, MOV6 = @MOV6, MOV7 = @MOV7, MOV8 = @MOV8, MOV9 = @MOV9, MOV10 = @MOV10, da = @da, ne = @ne, USERNAME = @USERNAME, Realname = @Realname, cuser = @cuser, COUser = @COUser WHERE MOV1=" & T9.Trim.ToLower, Consum)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOV1", SqlDbType.Int).Value = T1.ToString.Trim
                '.Parameters.Add("@MOV2", SqlDbType.NVarChar).Value = Me.TextBox15.Text
                .Parameters.Add("@MOV3", SqlDbType.DateTime).Value = Me.MTextBox1.Text.Trim
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = "”œ«œ «ﬁ”«ÿ ⁄‰ "
                .Parameters.Add("@MOV5", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TextBox3.Text.Trim
                .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TextBox3.Text.Trim
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = T4.Trim
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = "’—›"
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@cuser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@Realname", SqlDbType.NVarChar).Value = Realname
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@MOV10", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")

                .CommandText = SQL.CommandText
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Consum.Close()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ButtonCUSTOMER1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCUSTOMER1.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If InternalAuditor = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „—«Ã⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Dim resault As Integer
            If Me.CheckBox2.Checked = False Then
                resault = MessageBox.Show("  ”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï Õ—ﬂ… «·’‰œÊﬁ " & "··„Ê—œ " & Me.TextBox2.Text, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.CheckBox2.Checked = True
                    INSERTRECORDempsolf()
                    INSERTDATACO1()
                    SaveMOVES()
                    SaveMOVESDATARecord()
                    CmdSave_Click(sender, e)
                Else
                    Exit Sub
                End If
            Else
                resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    UPDATERECORDempsolf()
                    UPDATEDATACO1()
                    UPDATEMOVESDATARecord()
                    CmdSave_Click(sender, e)
                Else
                    resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· Õ—ﬂ… «·’‰œÊﬁ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        DELETEDATAempsolf()
                        DELETEDATACUSTOMER1()
                        Me.CheckBox2.Checked = False
                        CmdSave_Click(sender, e)
                    Else
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
            Me.CheckBox2.Checked = False
            CmdSave_Click(sender, e)
        End Try

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button1.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „—«Ã⁄… «·«—’œ… „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Dim I As Integer
        On Error Resume Next
        Me.Cursor = Cursors.WaitCursor
        For I = 0 To BS.Count + 1
            BS.Position = I
            ProgressBar1.Visible = True
            ProgressBar1.Minimum = 1
            ProgressBar1.Maximum = BS.Count - 1
            ProgressBar1.Value = I
            If Consum.State = ConnectionState.Open Then Consum.Close()
            GETBANKNOWBALANCE()
            CmdSave_Click(sender, e)
        Next
        BS.Position = 0
        ProgressBar1.Visible = False
        Me.Cursor = Cursors.Default
        Insert_Actions(Me.TextBox5.Text.Trim, "«·«—’œ…", Me.Text)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button2.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If LockAddRow = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If

            Dim n As Double
            Dim s As Double
            n = BS.Count
            BS.Position = BS.Count - 1
            s = Val(Me.TextBox6.Text)
            Application.DoEvents()
            BS.EndEdit()
            BS.AddNew()
            CLEARDATA1(Me)
            Me.TextBox13.Text = USERNAME
            'Me.TextBox10.Text = CUser
            Me.TextBox23.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextBox24.Text = ServerDateTime.ToString("hh:mm:ss tt")
            If n = 0 Then
                Me.TextBox6.Text = 1
            Else
                If n >= s Then
                    Me.TextBox6.Text = Val(n) + 1
                Else
                    Me.TextBox6.Text = Val(s) + 1
                End If
            End If

            Me.TextBox5.Text = "DE" & Me.TextBox6.Text
            Me.MTextBox1.Text = ServerDateTime.ToString("yyyy-MM-dd")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Consum.Close()
        Dim Sound As IO.Stream = My.Resources.addv
        My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Label9.Click

    End Sub
End Class