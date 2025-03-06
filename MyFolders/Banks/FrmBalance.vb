Option Strict Off
Option Explicit Off
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.VisualBasic.Compatibility


Public Class FrmBalance
<<<<<<< HEAD
    Inherits Form
    Private Sub FrmBALANCE_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles Me.DoubleClick
        On Error Resume Next
        Timer5.Enabled = Not Timer5.Enabled
    End Sub
    Private Sub FrmBALANCE_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
=======
    Inherits System.Windows.Forms.Form
    Private Sub FrmBALANCE_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        On Error Resume Next
        Timer5.Enabled = Not Timer5.Enabled
    End Sub
    Private Sub FrmBALANCE_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    BUTTON1_Click(sender, e)
                Case Keys.F2
                    Button2_Click(sender, e)
                Case Keys.F3
                    Button3_Click(sender, e)
                Case Keys.F4
                    Button4_Click(sender, e)
                Case Keys.F5
                    Button5_Click(sender, e)
                Case Keys.F6
                    Buttoncalcluter_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    <Obsolete>
<<<<<<< HEAD
    Private Sub FrmMY3_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmMY3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2
        Me.Top = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height

        Me.Label9.Text = Format(ServerDateTime, "dd-MM-yyyy  ****  hh:mm:ss tt")
        Me.Label8.Text = MytimeWord(Format(ServerDateTime, "hh:mm:ss tt"))
        Me.Label11.Text = MydateWord(Format(ServerDateTime, "dd-MM-yyyy"))
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        SumAmounFINALBALANCE1()
        SumAmounFINALBALANCE2()
        SumAmounFINALBALANCE3()
        SumAmounFINALBALANCE4()
        SumAmounFINALBALANCE5()
        SumAmounFINALBALANCE6()
        If Val(Me.TEXT6.Text) > 0 Then
            Me.TEXT6.ForeColor = Color.Black
        Else
            Me.TEXT6.ForeColor = Color.Red
        End If
        Me.Label10.Text = CurrencyJO(Me.TEXT6.Text, "jO")
        'Consum.Close()

        Me.BackgroundImage = img
    End Sub
    Private Sub SumAmounFINALBALANCE1()
<<<<<<< HEAD
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq As New SqlCommand("SELECT Sum(CAB4-CAB5)  FROM CABLES WHERE CUser='" & CUser & "'and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  GROUP BY CAB6 HAVING CAB6='‰ﬁœ«'", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlDataAdapter(strsq)
=======
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsq As New SqlClient.SqlCommand("SELECT Sum(CAB4-CAB5)  FROM CABLES WHERE CUser='" & CUser & "'and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  GROUP BY CAB6 HAVING CAB6='‰ﬁœ«'", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp1.Fill(ds, "CABLES")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXT1.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            Me.TEXT1.Text = Format("0", "0.000")
        End If
        Adp1.Dispose()
        Consum.Close()
        Me.TEXT6.Text = Format(Val(Me.TEXT2.Text) + Val(Me.TEXT2.Text) + Val(Me.TEXT3.Text) + Val(Me.TEXT4.Text) + Val(Me.TEXT5.Text) + Val(Me.TEXT7.Text), "0.000")
    End Sub
    Private Sub SumAmounFINALBALANCE2()
<<<<<<< HEAD
        Dim Adp2 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq2 As New SqlCommand("SELECT Sum(CSH7-CSH8)  FROM EMPSOLF  WHERE CUser='" & CUser & "'and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim ds As New DataSet
        Adp2 = New SqlDataAdapter(strsq2)
=======
        Dim Adp2 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsq2 As New SqlClient.SqlCommand("SELECT Sum(CSH7-CSH8)  FROM EMPSOLF  WHERE CUser='" & CUser & "'and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim ds As New DataSet
        Adp2 = New SqlClient.SqlDataAdapter(strsq2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp2.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXT2.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            Me.TEXT2.Text = Format("0", "0.000")
        End If
        Adp2.Dispose()
        Consum.Close()
        Me.TEXT6.Text = Format(Val(Me.TEXT2.Text) + Val(Me.TEXT2.Text) + Val(Me.TEXT3.Text) + Val(Me.TEXT4.Text) + Val(Me.TEXT5.Text) + Val(Me.TEXT7.Text), "0.000")
    End Sub
    Private Sub SumAmounFINALBALANCE6()
<<<<<<< HEAD
        Dim Adp2 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq2 As New SqlCommand("SELECT Sum(CSH7-CSH8)  FROM CASHIER WHERE CUser='" & CUser & "'and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' ", Consum)
        Dim ds As New DataSet
        Adp2 = New SqlDataAdapter(strsq2)
=======
        Dim Adp2 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsq2 As New SqlClient.SqlCommand("SELECT Sum(CSH7-CSH8)  FROM CASHIER WHERE CUser='" & CUser & "'and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' ", Consum)
        Dim ds As New DataSet
        Adp2 = New SqlClient.SqlDataAdapter(strsq2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp2.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXT7.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            Me.TEXT7.Text = Format("0", "0.000")
        End If
        Adp2.Dispose()
        Consum.Close()
        Me.TEXT6.Text = Format(Val(Me.TEXT2.Text) + Val(Me.TEXT2.Text) + Val(Me.TEXT3.Text) + Val(Me.TEXT4.Text) + Val(Me.TEXT5.Text) + Val(Me.TEXT7.Text), "0.000")
    End Sub
    Private Sub SumAmounFINALBALANCE3()
<<<<<<< HEAD
        Dim Adp3 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq3 As New SqlCommand("SELECT Sum(EBNK4 - EBNK5) AS SUM1 FROM BANKJO  WHERE CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' ", Consum)
        Dim ds As New DataSet
        Adp3 = New SqlDataAdapter(strsq3)
=======
        Dim Adp3 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsq3 As New SqlClient.SqlCommand("SELECT Sum(EBNK4 - EBNK5) AS SUM1 FROM BANKJO  WHERE CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' ", Consum)
        Dim ds As New DataSet
        Adp3 = New SqlClient.SqlDataAdapter(strsq3)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp3.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXT3.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            Me.TEXT3.Text = Format("0", "0.000")
        End If
        Adp3.Dispose()
        Consum.Close()
        Me.TEXT6.Text = Format(Val(Me.TEXT2.Text) + Val(Me.TEXT2.Text) + Val(Me.TEXT3.Text) + Val(Me.TEXT4.Text) + Val(Me.TEXT5.Text) + Val(Me.TEXT7.Text), "0.000")
    End Sub
    Private Sub SumAmounFINALBALANCE4()
<<<<<<< HEAD
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CH5)FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH17 ='" & False & "'", Consum)
        Dim DS As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
=======
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlClient.SqlCommand("SELECT Sum(CH5)FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH17 ='" & False & "'", Consum)
        Dim DS As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        DS.Clear()
        Adp1.Fill(DS)
        Adp1.Dispose()
        If DS.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(DS.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM1 = Format("0", "0.000")
        End If
        Consum.Close()
        Me.TEXT4.Text = Format(Val(SUM1), "0.000")
        Me.TEXT6.Text = Format(Val(Me.TEXT2.Text) + Val(Me.TEXT2.Text) + Val(Me.TEXT3.Text) + Val(Me.TEXT4.Text) + Val(Me.TEXT5.Text) + Val(Me.TEXT7.Text), "0.000")
    End Sub
    Private Sub SumAmounFINALBALANCE5()
<<<<<<< HEAD
        Dim Adp5 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq5 As New SqlCommand("SELECT Sum(OpeningBalance1)  FROM CustomersCABLES2  WHERE CUser='" & CUser & "'and Year(LO2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'AND lo19 ='" & False & "'", Consum)
        Dim DataSetTab1 As New DataSet
        Adp1 = New SqlDataAdapter(strsq5)
=======
        Dim Adp5 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsq5 As New SqlClient.SqlCommand("SELECT Sum(OpeningBalance1)  FROM CustomersCABLES2  WHERE CUser='" & CUser & "'and Year(LO2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'AND lo19 ='" & False & "'", Consum)
        Dim DataSetTab1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq5)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        DataSetTab1.Clear()
        Adp1.Fill(DataSetTab1, "CustomersCABLES2")
        If DataSetTab1.Tables(0).Rows.Count > 0 Then
            Me.TEXT5.Text = Format(Val(DataSetTab1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            Me.TEXT5.Text = Format("0", "0.000")
        End If
        Adp1.Dispose()
        Consum.Close()
        Me.TEXT6.Text = Format(Val(Me.TEXT1.Text) + Val(Me.TEXT2.Text) + Val(Me.TEXT7.Text) + Val(Me.TEXT3.Text), "0.000")
    End Sub
<<<<<<< HEAD
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
=======
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.Label9.Text = Format(ServerDateTime, "dd-MM-yyyy  ****  hh:mm:ss tt")
        Me.Label8.Text = MytimeWord(Format(ServerDateTime, "hh:mm:ss tt"))
        Me.Label11.Text = MydateWord(Format(ServerDateTime, "dd-MM-yyyy"))
    End Sub
<<<<<<< HEAD
    Private Sub BUTTON1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTON1.Click
=======
    Private Sub BUTTON1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTON1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Dim txtFromDate As String
            Dim txtToDate As String
            Dim result1 As String
            Dim result2 As Date
            result1 = Val(Today.Year) - 1
            result2 = "31 / 12 / " & result1
            txtFromDate = Format(result2, "yyyy, MM, dd, 00, 00, 00")
            txtToDate = Format(Date.Today, "yyyy, MM, dd, 00, 00, 00")
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim rpt11 As New rptCustomer11
            GETSERVERNAMEANDDATABASENAME(rpt11, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM CABLES  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)

<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "CABLES")
            rpt11.SetDataSource(ds)
            Dim F As New FrmPRINT
            Dim txt As TextObject
            txt = rpt11.Section1.ReportObjects("Text5")
            txt.Text = " Œ·«· «·› —… „‰  " & result2 & "  «·Ï  " & Today.ToString("dd / MM / yyyy")
            'rpt11.RecordSelectionFormula = "{CABLES.CAB3} in DateTime (" & txtFromDate & ") to DateTime (" & txtToDate & ")" & "AND {CABLES.CAB6}='‰ﬁœ«'"
            txt = rpt11.Section1.ReportObjects("TEXT21")
            txt.Text = AssociationName
            txt = rpt11.Section1.ReportObjects("TEXT10")
            txt.Text = Directorate

            F.CrystalReportViewer1.ReportSource = rpt11
            F.CrystalReportViewer1.Zoom(92%)
            F.CrystalReportViewer1.Refresh()
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button2.Click
=======
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim rpt1 As New rptBanks21
        On Error Resume Next
        Dim F As New FrmPRINT
        Dim result As Double
        Dim result1 As Double
        result1 = Val(Today.Year) - 1
        txtFromDate = "31 / 12 / " & result1
        txtToDate = Today.ToString("dd / MM / yyyy")
        Dim txt As TextObject
        txt = rpt1.Section1.ReportObjects("Text8")
        txt.Text = " Œ·«· «·› —… „‰  " & txtFromDate & "  «·Ï  " & txtToDate
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
        Dim ds As New DataSet
        Dim str As New SqlCommand("SELECT * FROM EMPSOLF WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter1 = New SqlDataAdapter(str)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
        Dim ds As New DataSet
        Dim str As New SqlClient.SqlCommand("SELECT * FROM EMPSOLF WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        SqlDataAdapter1.Fill(ds, "EMPSOLF")
        rpt1.SetDataSource(ds)
        txt = rpt1.Section1.ReportObjects("TEXT12")
        txt.Text = AssociationName
        txt = rpt1.Section1.ReportObjects("Text14")
        txt.Text = Character
        txt = rpt1.Section1.ReportObjects("TEXT15")
        txt.Text = Directorate
        txt = rpt1.Section1.ReportObjects("Text44")
        txt.Text = Recorded
        txt = rpt1.Section1.ReportObjects("TEXT40")
        txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
        F.CrystalReportViewer1.ReportSource = rpt1
        F.CrystalReportViewer1.Zoom(92%)
        F.CrystalReportViewer1.Refresh()
        F.Show()
    End Sub
<<<<<<< HEAD
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button3.Click
=======
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim rpt1 As New rptjo
        On Error Resume Next
        Dim F As New FrmPRINT
        Dim result As Double
        Dim result1 As Double
        result1 = Val(Today.Year) - 1
        txtFromDate = "31 / 12 / " & result1
        txtToDate = Today.ToString("dd / MM / yyyy")
        Dim txt As TextObject
        txt = rpt1.Section1.ReportObjects("Text10")
        txt.Text = " Œ·«· «·› —… „‰  " & txtFromDate & "  «·Ï  " & txtToDate
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
        Dim ds As New DataSet
        Dim str As New SqlCommand("SELECT * FROM BANKJO  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter1 = New SqlDataAdapter(str)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
        Dim ds As New DataSet
        Dim str As New SqlCommand("SELECT * FROM BANKJO  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        SqlDataAdapter1.Fill(ds, "BANKJO")

        rpt1.SetDataSource(ds)
        txt = rpt1.Section1.ReportObjects("TEXT12")
        txt.Text = AssociationName
        txt = rpt1.Section1.ReportObjects("Text14")
        txt.Text = Character
        txt = rpt1.Section1.ReportObjects("TEXT15")
        txt.Text = Directorate
        txt = rpt1.Section1.ReportObjects("Text44")
        txt.Text = Recorded
        txt = rpt1.Section1.ReportObjects("TEXT40")
        txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
        F.CrystalReportViewer1.ReportSource = rpt1
        F.CrystalReportViewer1.Zoom(92%)
        F.CrystalReportViewer1.Refresh()
        F.Show()
    End Sub
<<<<<<< HEAD
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button4.Click
=======
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim rpt1 As New Checks
        On Error Resume Next
        Dim F As New FrmPRINT
        Dim result As Double
        Dim result1 As Double
        result1 = Val(Today.Year) - 1
        txtFromDate = "31 / 12 / " & result1
        txtToDate = Today.ToString("dd / MM / yyyy")
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Call GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
        Dim Adp1 As SqlDataAdapter
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT * FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH17 ='" & False & "'ORDER BY CH2", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Call GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
        Dim Adp1 As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsq1 As New SqlClient.SqlCommand("SELECT * FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH17 ='" & False & "'ORDER BY CH2", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp1.Fill(ds, "Checks")
        Consum.Close()

        rpt1.SetDataSource(ds)

        'Dim txt As TextObject
        'txt = rpt1.Section1.ReportObjects("Text4")
        'txt.Text = " Œ·«· «·› —… „‰  " & txtFromDate & "  «·Ï  " & txtToDate

        txt = rpt1.Section1.ReportObjects("TEXT12")
        txt.Text = AssociationName
        txt = rpt1.Section1.ReportObjects("TEXT13")
        txt.Text = Directorate

        F.CrystalReportViewer1.ReportSource = rpt1
        F.CrystalReportViewer1.Zoom(92%)
        F.CrystalReportViewer1.Refresh()
        F.Show()
    End Sub
<<<<<<< HEAD
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button5.Click
        On Error Resume Next
        Dim rpt1 As New rptReceivableDisclosure
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        On Error Resume Next
        Dim rpt1 As New rptReceivableDisclosure
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim F As New FrmPRINT
        Dim result As Double
        Dim result1 As Double
        result1 = Val(FiscalYear_currentDateMustBeInFiscalYear)
        txtFromDate = "31 / 12 / " & FiscalYear_currentDateMustBeInFiscalYear()
        txtToDate = ServerDateTime.ToString("yyyy-MM-dd")
        Dim txt As TextObject
        txt = rpt1.Section1.ReportObjects("Text5")
        txt.Text = " Œ·«· «·› —… „‰  " & txtFromDate & "  «·Ï  " & txtToDate
        GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
<<<<<<< HEAD
        Dim str8 As New SqlCommand("SELECT * FROM CustomersCABLES2   WHERE  CUser ='" & CUser & "'  AND Year(Lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' ", Consum)
        SqlDataAdapter1 = New SqlDataAdapter(str8)
=======
        Dim str8 As New SqlClient.SqlCommand("SELECT * FROM CustomersCABLES2   WHERE  CUser ='" & CUser & "'  AND Year(Lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' ", Consum)
        SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str8)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim ds8 As New DataSet
        ds8.Clear()
        SqlDataAdapter1.Fill(ds8, "CustomersCABLES2")
        rpt1.SetDataSource(ds8)
        txt = rpt1.Section1.ReportObjects("TEXT4")
        txt.Text = AssociationName
        txt = rpt1.Section1.ReportObjects("TEXT8")
        txt.Text = Directorate
        F.CrystalReportViewer1.ReportSource = rpt1
        F.CrystalReportViewer1.Zoom(92%)
        F.CrystalReportViewer1.Refresh()
        F.Show()
    End Sub
<<<<<<< HEAD
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As EventArgs)
=======
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Process.Start("calc.exe")
    End Sub

    <Obsolete>
<<<<<<< HEAD
    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer2.Tick
        On Error Resume Next
        Me.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Top) - 50)
    End Sub
    Private Sub Timer3_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer3.Tick
=======
    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        On Error Resume Next
        Me.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Top) - 50)
    End Sub
    Private Sub Timer3_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer3.Tick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Me.Top < Val(Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2 Then
            Timer2.Enabled = False
        End If
    End Sub

    <Obsolete>
<<<<<<< HEAD
    Private Sub Timer4_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer4.Tick
=======
    Private Sub Timer4_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer4.Tick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Timer2.Enabled = False
        Me.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Top) + 50)
        If VB6.PixelsToTwipsY(Me.Top) > VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) Then
            Me.Close()
        End If
    End Sub
<<<<<<< HEAD
    Private Sub Timer5_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer5.Tick
        On Error Resume Next
        Timer4.Enabled = False
    End Sub
    Private Sub BUTTON6_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTON6.Click
        On Error Resume Next
        Dim rpt1 As New rptBanks20
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub Timer5_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer5.Tick
        On Error Resume Next
        Timer4.Enabled = False
    End Sub
    Private Sub BUTTON6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTON6.Click
        On Error Resume Next
        Dim rpt1 As New rptBanks20
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim F As New FrmPRINT
        Dim result As Double
        Dim result1 As Double
        result1 = Val(Today.Year) - 1
        txtFromDate = "31 / 12 / " & result1
        txtToDate = Today.ToString("dd / MM / yyyy")
        GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
        Dim ds As New DataSet
        Dim strAs As New SqlCommand("SELECT * FROM CASHIER  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
<<<<<<< HEAD
        SqlDataAdapter1 = New SqlDataAdapter(strAs)
=======
        SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strAs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        SqlDataAdapter1.Fill(ds, "CASHIER")
        rpt1.SetDataSource(ds)
        F.CrystalReportViewer1.ReportSource = rpt1


        Dim txt As TextObject
        txt = rpt1.Section1.ReportObjects("Text8")
        txt.Text = " Œ·«· «·› —… „‰  " & txtFromDate & "  «·Ï  " & txtToDate
        txt = rpt1.Section1.ReportObjects("TEXT10")
        txt.Text = AssociationName
        txt = rpt1.Section1.ReportObjects("TEXT11")
        txt.Text = Directorate
        F.CrystalReportViewer1.ReportSource = rpt1
        F.CrystalReportViewer1.Zoom(92%)
        F.CrystalReportViewer1.Refresh()
        F.Show()
    End Sub

End Class