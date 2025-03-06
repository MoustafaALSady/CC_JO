
Imports System.Data.SqlClient
Imports System.IO
Imports System.Math
Imports System.Net
Imports System.Net.Mail
Imports System.Text
Imports DevExpress.XtraReports.UI

Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraEditors
Public Class Form_beea
    'متغيرات ارسال التقارير
    Public SEN1 As String
    Public SEN2 As String
    Public SEN3 As String
    Public SEN4 As String
    Public SEN5 As String
    Public SEN6 As String
    Public SEN7 As String
    Public SEN8 As String
    Public SEN9 As String
    ' متغيرات التشييك على الارسال
    Public CHEE1 As Boolean
    Public CHEE2 As Boolean
    Public CHEE3 As Boolean
    ' تحميل معلومات مجموع السلع
    Public sum1 As String
    Public sum2 As String
    Public sum3 As String
    Public sum4 As String
    Public sum5 As String
    Public sum6 As String
    Public sum7 As String
    Public GOM As String ' يحمل الرسالة الى الجوال
    ReadOnly V1 As String
    'متغيرات اضافة صور
    ReadOnly ImageFile As Image
    ReadOnly ImageFilePath As String
    ReadOnly sFilePath As String
    ReadOnly imgHeight As Integer
    ReadOnly imgWidth As Integer
    ReadOnly imgType As String
    ReadOnly img As Byte()

    ReadOnly pagingAdapter As SqlDataAdapter
    ReadOnly pagingDS As DataSet
    ReadOnly scrollVal As Integer
<<<<<<< HEAD
    Dim adp As New SqlDataAdapter
=======
    Dim adp As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Dim Tax As Boolean
    Dim Tax1 As Boolean
    Dim Tax2 As String
    ' متغيرات رقم المنتج
    Public intrand As Object
    Public intstep As Object
    Public strname As Object
    Public intnamelength As Object
    Public intlength As Object
    Public strlnputstring As Object
    Dim cod1 As String = ""
    Dim num As String = ""
    ReadOnly dt1 As DateTime = ServerDateTime()

    Dim test2 As Integer
    Private ik As Integer
    Private ReadOnly sadf As Integer
    Dim test As Integer
    Dim Discount As Double = 0
    Dim ChkPD As Boolean = False

<<<<<<< HEAD

    Dim ItemBalance As Double = 0.0
    Dim PreviousBalance As Double = 0.0
    Dim CurrentBalance As Double = 0.0
    Dim UnitPriceA As Double = 0.0
    Dim SellingPrice As Double = 0.0

    Private Sub Form_beea_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
=======
    Private Sub Form_beea_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.Butcan_Click(sender, e)
                Case Keys.F2
                    Me.ButtonSaveAndPrint_Click(sender, e)
                Case Keys.F3
                    Me.Buttaleek_Click(sender, e)
                Case Keys.F4
                    Me.Butsala_Click(sender, e)
                Case Keys.F5
                    Me.Bufind_Click(sender, e)
                Case Keys.F6
                    Me.Bude_Click(sender, e)
                Case Keys.A And (e.Alt And Not e.Control And Not e.Shift)
                    Me.Butcash_Click(sender, e)
                Case Keys.Up
                    Me.Bupl_Click(sender, e)
                    Me.Textadd.SelectAll()
                    Me.Textadd.Focus()
                Case Keys.Down
                    Bum_Click(sender, e)
                    Me.Textadd.SelectAll()
                    Me.Textadd.Focus()
                Case Keys.F11
                    Me.Buadd_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD

    Private Sub Form_beea_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = ModuleGeneral.img
        'For a As Byte = 0 To 10
        '    System.Threading.Thread.Sleep(10)
        '    Application.DoEvents()
        '    Me.Opacity = a / 10
        'Next
=======
    Private Sub Form_beea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = ModuleGeneral.img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Call MangUsers()
        If LockAddRow = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Me.Temi.Text = dt1.ToString("hh:mm:ss tt")
        Me.Tedate.Text = MaxDate.ToString("yyyy-MM-dd")
        Me.TextUSERNAME.Text = USERNAME
        Me.TextBarCode.Focus()
        FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.Bufind.Enabled = LockPrint
        Me.Butcash.Enabled = LockUpdate
        Me.ButtonSettings.Enabled = LockPrint
        Me.Buttondelete.Enabled = LockDelete
        Me.ButtonInvoiceComment.Enabled = LockUpdate
        Me.ButtonSaveAndPrint.Enabled = LockSave
        Me.ButtonNew.Enabled = LockAddRow
    End Sub

<<<<<<< HEAD
    Private Sub ButtonSaveAndPrint_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonSaveAndPrint.Click
=======
    Private Sub ButtonSaveAndPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveAndPrint.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If LockSave = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Me.Timsum.Stop()
        Dim Z As Integer = Me.TextpaidUp.Text.Trim
        If Me.TextpaidUp.Text.Trim = "0" Or Me.TextpaidUp.Text.Trim = "" Then
            MsgBox("لا يمكن الحفظ المدفوع لا شيء = 0" & Environment.NewLine, MsgBoxStyle.Critical, "تنبيه")
            Exit Sub
        End If
        If M1.Text.Trim = "استرجاع F7" Then
            MsgBox("تنبيه أن العملية هي استرجاع يجب تحديد نوع العملية بيع ", MsgBoxStyle.Critical, "تنبيه")
            Exit Sub
        End If
        Dim a As Integer = Me.TextTotalPrice.Text.Trim
        Dim b As Integer = Me.TextpaidUp.Text.Trim
        If a > b Then
            MsgBox(" المدفوع اقل من الاجمالي لا يمكن الحفظ الرجاء الدفع اكبر من الاجمالي " & Environment.NewLine & Me.TextTotalPrice.Text.Trim & " > " & Me.TextpaidUp.Text.Trim, MsgBoxStyle.Critical, "تنبيه")
            Exit Sub
        End If
        GetAutoNumber("TS9", "TodaySales", "DataTS")
        Me.TEXTInvoiceNumber.Text = AutoNumber
        Me.TextMovementSymbol.Text = "QR" & TEXTInvoiceNumber.Text
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        Me.Temi.Text = dt1.ToString("hh:mm:ss tt")
        Me.Tedate.Text = MaxDate.ToString("yyyy-MM-dd")
        Try
            Dim Row = Datab.CurrentRow
            If Row Is Nothing Then
                MsgBox(" لا يوجد بيانات للحفظ  ", MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
            If Consum.State = 1 Then Consum.Close()
            Consum.Open()
            Dim cmd1 As New SqlCommand(" Select TS9 From TodaySales Where TS9 = '" & Me.TEXTInvoiceNumber.Text.Trim & "'", Consum)
            Dim dr As SqlDataReader = cmd1.ExecuteReader()
            If dr.Read Then
                MsgBox(" رقم الفاتورة موجود مسبقاً", MsgBoxStyle.Critical)
                Exit Sub
            End If
            '-------------------------------------------------
            If Consum.State = ConnectionState.Open Then Consum.Close()
        Catch ex As Exception
            Consum.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه الاستعلام")
            'Finally
            '    If Consum.State = ConnectionState.Open Then Consum.Close()
            Exit Sub
        End Try

        Dim n As Integer
        Try
                For n = 0 To Datab.RowCount - 1
                    Dim cmd99 As New SqlCommand("insert into TodaySales (DataTS,Barcod,TS1,TS2,TS3,TS4,TS5,TS6,TS7,TS8,TS9,TS10,TS11,TS12,TS13,TS14,TS15,Chk,Chk1,Chk2,Chk3, WarehouseNumber,WarehouseName,CB1, USERNAME, CUser, COUser, da, ne ) values (@DataTS,@Barcod,@TS1,@TS2,@TS3,@TS4,@TS5,@TS6,@TS7,@TS8,@TS9,@TS10,@TS11,@TS12,@TS13,@TS14,@TS15,@Chk,@Chk1,@Chk2,@Chk3, @WarehouseNumber,@WarehouseName, @CB1, @USERNAME, @CUser, @COUser, @da, @ne)", Consum)
                    cmd99.Parameters.AddWithValue("@DataTS", MaxDate.ToString("yyyy-MM-dd")) '
                    cmd99.Parameters.AddWithValue("@Barcod", Me.Datab.Item(0, n).Value)
                    cmd99.Parameters.AddWithValue("@TS1", Me.Datab.Item(1, n).Value)
                    cmd99.Parameters.AddWithValue("@TS2", Me.Datab.Item(2, n).Value) '
                    cmd99.Parameters.AddWithValue("@TS3", Me.Datab.Item(3, n).Value) '
                    cmd99.Parameters.AddWithValue("@TS4", Me.Datab.Item(4, n).Value) '
                    cmd99.Parameters.AddWithValue("@TS5", Me.Datab.Item(5, n).Value) '
                    cmd99.Parameters.AddWithValue("@TS6", Me.Datab.Item(6, n).Value) '
                    cmd99.Parameters.AddWithValue("@TS7", Me.TextItemCount.Text) '
                    cmd99.Parameters.AddWithValue("@TS8", Me.Datab.Item(8, n).Value) '
                    cmd99.Parameters.AddWithValue("@TS9", Me.TEXTInvoiceNumber.Text) '
                    cmd99.Parameters.AddWithValue("@TS10", Me.M1.Text) '
                    cmd99.Parameters.AddWithValue("@TS11", Me.TextpaidUp.Text) '
                    cmd99.Parameters.AddWithValue("@TS12", Me.TextTotalPrice.Text) '
                    cmd99.Parameters.AddWithValue("@TS13", Me.TextRest.Text)
                    cmd99.Parameters.AddWithValue("@TS14", Me.Datab.Item(7, n).Value)
                    cmd99.Parameters.AddWithValue("@TS15", Me.TextMovementSymbol.Text)
                    cmd99.Parameters.AddWithValue("@Chk", False) '
                    cmd99.Parameters.AddWithValue("@Chk1", False) '
                    cmd99.Parameters.AddWithValue("@Chk2", False) '
                    cmd99.Parameters.AddWithValue("@Chk3", False) '
                    cmd99.Parameters.AddWithValue("@WarehouseNumber", ComboStore.Text) '
                    cmd99.Parameters.AddWithValue("@WarehouseName", TextWarehouseName.Text) '
                    cmd99.Parameters.AddWithValue("@CB1", ComboCB1.Text)
                    cmd99.Parameters.AddWithValue("@USERNAME", USERNAME) '
                    cmd99.Parameters.AddWithValue("@CUser", CUser) '
                    cmd99.Parameters.AddWithValue("@COUser", COUser) '
                    cmd99.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd")) '
                    cmd99.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt")) '
                    If Consum.State = ConnectionState.Closed Then Consum.Open()
                    cmd99.ExecuteNonQuery()
                    cmd99.Dispose()
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                Next
            ''If Cheprint.Checked = True Then
            ''    Dim f As New FrmPRINT1
            ''    Dim rpt As New Cr_fatora
            ''    Dim ReportToday As New ReportTodaySales
            ''    If Consum.State = ConnectionState.Closed Then Consum.Open()
            ''    GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            ''    Dim sql As String = " SELECT * FROM TodaySales where  TS9=@TS9"
            ''    Dim comm As New SqlCommand(sql, Consum)
            ''    comm.Parameters.AddWithValue("@TS9", TEXTInvoiceNumber.Text)
            ''    Dim da As New SqlDataAdapter(comm)
            ''    Dim dt As New DataTable
            ''    da.Fill(dt)
            ''    ReportToday.DataSource = dt
            ''    ReportToday.DataAdapter = da
            ''    ReportToday.DataMember = "TodaySales"
            ''    ReportToday.ParameterTS9.Value = TEXTInvoiceNumber.Text
            ''    ReportToday.ParameterTS9.Visible = False
            ''    ReportToday.RequestParameters = False
            ''    ReportToday.LblAsUser.Text = AssociationName
            ''    Dim ToolReportToday As New ReportPrintTool(ReportToday)
            ''    ReportToday.CreateDocument()
            ''    ReportToday.ShowPreview
            ''End If
            'f.DocumentViewer1.DocumentSource = ReportToday

            'rpt.SetDataSource(dt)
            'f.CrystalReportViewer1.ReportSource = rpt
            'Dim objText As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.Section1.ReportObjects("Text22")
            'objText.Text = AssociationName
            'Dim objText1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(4).ReportObjects("Te1")
            'objText1.Text = Me.TextTotalPrice.Text
            'Dim objText2 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(4).ReportObjects("Te2")
            'objText2.Text = Me.TextB4.Text
            'Dim objText3 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(4).ReportObjects("Te3")
            'objText3.Text = Me.TextItemCount.Text
            'Dim objText4 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(4).ReportObjects("Te4")
            'objText4.Text = Me.TextpaidUp.Text
            'Dim objText5 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(4).ReportObjects("Te5")
            'objText5.Text = Me.TextTotalPrice.Text
            'Dim objText6 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(4).ReportObjects("Te6")
            'objText6.Text = Me.TextRest.Text.Trim
            'Dim objText7 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(4).ReportObjects("Text5")
            'objText7.Text = Me.TextUSERNAME.Text
            'rpt.PrintToPrinter(1, True, 0, 0)
            'f.CrystalReportViewer1.Zoom(65%)
            'f.CrystalReportViewer1.RefreshReport()
            'f.Show()
            'If Consum.State = ConnectionState.Open Then Consum.Close()

            Me.Timsum1.Start()
            Insert_Actions(Me.TEXTInvoiceNumber.Text, Me.TextMovementSymbol.Text & "-" & " حفظ فاتورة مبيعات", Me.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه حفظ")
            Consum.Close()
        Finally
            If Consum.State = ConnectionState.Open Then Consum.Close()
            'Exit Sub
        End Try
    End Sub
<<<<<<< HEAD

    Private Sub List0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles List0.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub List0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List0.SelectedIndexChanged
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            If FIFO = True Then
                Dim cmdDXa As New SqlCommand("select * from FIFOStocks where STK25 = '" & cod1.ToString.Trim & "'", Consum)
                Dim drDXa As SqlDataReader = cmdDXa.ExecuteReader
                If drDXa.Read = True Then
                    TextSTK8.Text = drDXa.Item("STK8")
                    Tax2 = drDXa.Item("STK25")
                    TextHashUnit.Text = drDXa.Item("SKITM6")
                    TextPurchasingPrice.Text = drDXa.Item("STK15")
                    TEXTMeasruingUnit.Text = drDXa.Item("SKITM9")
                    TexTSellingPrice.Text = drDXa.Item("STK19")
                    Discount = drDXa.Item("SKITM9")
                    TextDiscountPercentageWhenSelling.Text = drDXa.Item("SKITM15")
                    TextLowestDiscountRateWhenSelling.Text = drDXa.Item("SKITM16")
                    TextHighestDiscountRateWhenSelling.Text = drDXa.Item("SKITM17")
                    Tax = drDXa.Item("SKITM20")
                    Tax1 = drDXa.Item("SKITM21")
                    ChkPD = drDXa.Item("ChkPD")
                    TEXT15.Text = drDXa.Item("IT_DATEP")
                    TEXT16.Text = drDXa.Item("IT_DATEEX")
                    CheckBox6.Checked = Tax.ToString
                    CheckBox4.Checked = Tax1.ToString
                    cod1 = drDXa.Item("STK25")
                    num = drDXa.Item("STK7")
                    cmdDXa.Dispose()
                End If
            End If
            If LIFO = True Then
                Dim cmdDXa As New SqlCommand("select * from LIFOStock where STK7 = '" & List0.Text.ToString.Trim & "' ", Consum)
                Dim drDXa As SqlDataReader = cmdDXa.ExecuteReader
                If drDXa.Read = True Then
                    TextSTK8.Text = drDXa.Item("STK8")
                    Tax2 = drDXa.Item("STK25")
                    TextHashUnit.Text = drDXa.Item("SKITM6")
                    TextPurchasingPrice.Text = drDXa.Item("STK15")
                    TEXTMeasruingUnit.Text = drDXa.Item("SKITM9")
                    TexTSellingPrice.Text = drDXa.Item("STK19")
                    Discount = drDXa.Item("SKITM9")
                    TextDiscountPercentageWhenSelling.Text = drDXa.Item("SKITM15")
                    TextLowestDiscountRateWhenSelling.Text = drDXa.Item("SKITM16")
                    TextHighestDiscountRateWhenSelling.Text = drDXa.Item("SKITM17")
                    Tax = drDXa.Item("SKITM20")
                    Tax1 = drDXa.Item("SKITM21")
                    ChkPD = drDXa.Item("ChkPD")
                    TEXT15.Text = drDXa.Item("IT_DATEP")
                    TEXT16.Text = drDXa.Item("IT_DATEEX")
                    CheckBox6.Checked = Tax.ToString
                    CheckBox4.Checked = Tax1.ToString
                    cod1 = drDXa.Item("STK25")
                    num = drDXa.Item("STK7")
                    cmdDXa.Dispose()
                End If
            End If
            If AVG = True Then
                Dim cmdDXa As New SqlCommand("select * from AvgStocks where STK7 = '" & List0.Text.ToString.Trim & "' ", Consum)
                Dim drDXa As SqlDataReader = cmdDXa.ExecuteReader
                If drDXa.Read = True Then
                    TextSTK8.Text = drDXa.Item("STK8")
                    Tax2 = drDXa.Item("STK25")
                    TextHashUnit.Text = drDXa.Item("SKITM6")
                    TextPurchasingPrice.Text = drDXa.Item("STK15")
                    TEXTMeasruingUnit.Text = drDXa.Item("SKITM9")
                    TexTSellingPrice.Text = drDXa.Item("Avgstk")
                    Discount = drDXa.Item("SKITM9")
                    TextDiscountPercentageWhenSelling.Text = drDXa.Item("SKITM15")
                    TextLowestDiscountRateWhenSelling.Text = drDXa.Item("SKITM16")
                    TextHighestDiscountRateWhenSelling.Text = drDXa.Item("SKITM17")
                    Tax = drDXa.Item("SKITM20")
                    Tax1 = drDXa.Item("SKITM21")
                    ChkPD = drDXa.Item("ChkPD")
                    TEXT15.Text = drDXa.Item("IT_DATEP")
                    TEXT16.Text = drDXa.Item("IT_DATEEX")
                    CheckBox6.Checked = Tax.ToString
                    CheckBox4.Checked = Tax1.ToString
                    cod1 = drDXa.Item("STK25")
                    num = drDXa.Item("STK7")
                    cmdDXa.Dispose()
                End If
            End If
            Consum.Close()
            Textadd.Text = "1"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD

    Public Function SearchBalancEitems() As Int64
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim idSTK As Double
        Dim cmd1 As New SqlCommand("SELECT MAX(STK1) FROM STOCKS", Consum)
=======
    Public Function SearchBalancEitems()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim idSTK As Double
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(STK1) FROM STOCKS", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        idSTK = cmd1.ExecuteScalar
        Consum.Close()
<<<<<<< HEAD
        Dim strsq1 As New SqlCommand("SELECT Sum(STOCKS.STK11) AS SumIMPORTQUANTITY,Sum(STOCKS.STK12) AS SumEXPORTQUNATITY FROM STOCKS  WHERE  STK7 ='" & num.ToString.Trim & "'" & "or STK25 ='" & cod1.ToString.Trim & "'" & " and CUser='" & CUser & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsq1)
=======
        Dim strsq1 As New SqlClient.SqlCommand("SELECT Sum(STOCKS.STK11) AS SumIMPORTQUANTITY,Sum(STOCKS.STK12) AS SumEXPORTQUNATITY FROM STOCKS  WHERE  STK7 ='" & num.ToString.Trim & "'" & "or STK25 ='" & cod1.ToString.Trim & "'" & " and CUser='" & CUser & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp1.Fill(ds, "STOCKS")
        Dim tota4 As Double
        If ds.Tables(0).Rows.Count > 0 Then
            For Each r As DataGridViewRow In Datab.Rows
                If cod1.ToString.Trim = Me.Datab.CurrentRow.Cells(0).Value Then
                    tota4 += CDbl(r.Cells(2).Value)
                Else
                    tota4 = 0.00
                End If
            Next
            If Me.TextItemBalance.Text = "" Then Me.TextItemBalance.Text = "0"
            Me.TextItemBalance.Text = Val(ds.Tables(0).Rows(0).Item(0)) - Val(ds.Tables(0).Rows(0).Item(1))
        Else
            Me.TextItemBalance.Text = "0"
        End If
        Adp1.Dispose()
        Consum.Close()
    End Function

<<<<<<< HEAD
    Private Sub Buadd_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAddCategory.Click
=======
    Private Sub Buadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddCategory.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Me.Textadd.Text.Trim = "" Or Me.Textadd.Text.Trim = "0" Then
            MsgBox("كم عدد الصنف  ", MsgBoxStyle.Critical, "تنبيه")
            Exit Sub
        End If
        TextBarCode_TextChanged(sender, e)
        Dim firstDate As String, days As Integer
        Dim secondDate As Date
        firstDate = Me.TEXT16.Text
        secondDate = CDate(firstDate)

        If ItemsExpirationDate = True Then
            If ChkPD = True Then
                If ServerDateTime.ToString("yyyy-MM-dd") >= secondDate Then
                    MsgBox("إنتهاء صالحية الصنف  ", MsgBoxStyle.Critical, "تنبيه")
                    Exit Sub
                End If
            End If
        End If

        If CDbl(Val(Me.Textadd.Text)) > CDbl(Val(Me.TextItemBalance.Text)) Then
            MsgBox("لا يجب ان يكون العدد الفاتورة أكبر من رصيد المخزون ")
            Exit Sub
        End If

        Dim Tot As Double
        Dim item1 As Double
        For i As Integer = 0 To Me.Datab.Rows.Count - 1
            If Me.Datab.Rows(i).Cells(0).Value = cod1 Then
                Tot += Val(Datab.Rows(i).Cells(2).Value)
            End If
        Next
        If Val(Me.Textadd.Text) > Val(Me.TextItemBalance.Text) Then
            MsgBox("عفواً هذه الكميات أكبر من رصيد الصنف", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight)
            Me.TextBarCode.Clear()
            Me.TextBarCode.Focus()
            Exit Sub
        End If
        If Val(Me.Textadd.Text) > Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value() + Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index + 1).Value())) Then
            MsgBox("عفواً غير مسموح يوجد اكثر من سعرين في سجل واحد", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight)
            Me.Textadd.Text = Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value() + Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index + 1).Value()))
            Me.Textadd.Focus()
            Exit Sub
        End If

        If Val(Me.Textadd.Text) <= Val(Me.TextItemBalance.Text) Then
            'Me.SEARCHDATAITEMS()
            Me.SEARCHBALANCEITEMS()
            Dim w1 As Double
            Dim w2 As Double
            Dim w3 As Double
            Dim w4 As Double
            Dim wsum As Double
            Dim wsum1 As Double
            '''''''''''''''''''''''''''''''''''''''
            Dim r1 As Double
            Dim r2 As Double
            Dim rsum As Double
            Dim rsum1 As Double
            Dim sum2 As Double
            Dim sum3 As Double
            Dim tota4 As Double
            Dim naem As String
            Dim cx As Double
            Dim w11 As Double
            Dim w12 As Double
            Dim w13 As Double
            Dim w14 As Double
            If Me.Textadd.Text > Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value()) Then
                Me.TextNetItemsAvailableSale.Text = Val(Val(Textadd.Text) - Me.TextNetItems.Text)
                Me.TextItemBalanceAfterSale.Text = Val(Me.TextNetItemsAvailableSale.Text * Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index + 1).Value()))
                Me.TextItemBalanceAfterSaleA.Text = Val(Me.TextNetItemsAvailableSale.Text * Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index).Value()))
            End If
            If Me.Textadd.Text > Val(Me.TextNetItemsSale.Text) Then
                Me.TextNetItemsAfterSale.Text = Val(Val(Textadd.Text - Me.TextNetItemsSale.Text))
                Me.TextItemBalanceAfterSale.Text = Val(Me.TextNetItemsAfterSale.Text * Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index + 1).Value()))
                Me.TextItemBalanceAfterSaleA.Text = Val(Me.TextNetItemsAfterSale.Text * Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index).Value()))
            End If
            If Me.Textadd.Text < Val(Me.TextItemBalanceA.Text) Then
                Me.TextNetItemsAvailableSale.Text = 0
                Me.TextNetItemsAfterSale.Text = 0
                Me.TextItemBalanceAfterSale.Text = 0
                Me.TextItemBalanceAfterSaleA.Text = 0
            Else
                Me.TextNetItemsA.Text = Val(Me.Textadd.Text - Val(Me.TextItemBalanceA.Text))
                Me.TextItemBalanceAfterSale.Text = Val(Me.TextItemBalanceA.Text * Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index).Value()))
                Me.TextItemBalanceAfterSaleA.Text = Val(Me.TextItemBalanceA.Text * Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index).Value()))
            End If
            test = 1
            test2 = 1
            ik = 0

            For Each r As DataGridViewRow In Me.Datab.Rows
                If r.Cells(0).Value = cod1 Then
                    test = 0
                End If
            Next
            For Each itm As DataGridViewRow In Me.DataGridView2.Rows
                If itm.Cells("STK25").Value = cod1 Then
                    w11 = Val(Me.DataGridView2.Item(8, itm.Index).Value())
                    test2 = 0
                End If
            Next

            naem = Me.DataGridView2.Item("STK7", Me.DataGridView2.CurrentRow.Index).Value()
            w1 = Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index).Value())
            w2 = Textadd.Text
            w3 = TextDiscountPercentageWhenSelling.Text
            w4 = TEXTMeasruingUnit.Text
            Discount = Val(Me.DataGridView2.Item("SKITM9", Me.DataGridView2.CurrentRow.Index).Value())
            wsum = Format(Val(w1) * Val(w2) - Val(Me.TextItemBalanceAfterSaleA.Text) + Val(Me.TextItemBalanceAfterSale.Text) * (100 - Val(w3)) / 100, "0.000")
            wsum1 = Format(Val(Me.TextPurchasingPrice.Text.Trim) * Val(w2), "0.000")
            '''''''''''''''''''''''''''''''''''''''
            r1 = Textadd.Text
            r2 = TextDiscountPercentageWhenSelling.Text
            rsum = Format(Val(wsum) * Val(r2) / 100, "0.000")
            rsum1 = Format(Val(wsum1) * Val(w4) / 100, "0.000")
            sum2 = Format(Val(wsum) - Val(rsum), "0.000")
            sum3 = Format(Val(wsum1) - Val(rsum1), "0.000")
            Me.TextMovementSymbol.Text = "QR" & TEXTInvoiceNumber.Text
            If test2 = 0 Then
                If test = 0 Then
                    For Each row1 As DataGridViewRow In Me.Datab.Rows
                        If row1.Cells(0).Value = cod1 Then
                            w1 = Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index).Value())
                            w13 = Val(row1.Cells(4).Value)
                            w11 = Val(row1.Cells(5).Value)
                            w12 = Val(row1.Cells(6).Value)
                            w14 = Val(row1.Cells("Co4").Value)
                            '''''''''''''''''''''''''''''''''''''''
                            cx = Val(Me.Textadd.Text) + Val(row1.Cells("Co4").Value)
                            wsum = Format((Val(w1) * Val(cx)) - Val(Me.TextItemBalanceAfterSaleA.Text) + Val(Me.TextItemBalanceAfterSale.Text) * (100 - Val(w3)) / 100, "0.000")
                            wsum1 = Format((Val(Me.TextPurchasingPrice.Text) * Val(cx)) - Val(Me.TextItemBalanceAfterSaleA.Text) + Val(Me.TextItemBalanceAfterSale.Text) * (100 - Val(w4)) / 100, "0.000")
                            rsum = Format(Val(wsum) * Val(r2) / 100, "0.000")
                            rsum1 = Format(Val(wsum1) * Val(w4) / 100, "0.000")
                            '''''''''''''''''''''''''''''''''''''''
                            sum2 = Format(Val(wsum) - Val(rsum), "0.000")
                            sum3 = Format(Val(wsum1) - Val(rsum1), "0.000")
                            row1.Cells(2).Value = Val(cx)
                            row1.Cells(5).Value = Val(sum2)
                            row1.Cells(6).Value = Val(rsum)
                            row1.Cells(7).Value = Val(wsum1)
                            row1.Cells(8).Value = Val(Discount)
<<<<<<< HEAD
                            Dim Sound As Stream = My.Resources.BarCode
=======
                            Dim Sound As System.IO.Stream = My.Resources.BarCode
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                            My.Computer.Audio.Play(Sound, AudioPlayMode.Background)
                        End If
                    Next
                Else
                    Me.Datab.Rows.Add(New String() {Me.Tax2.ToString, naem, Me.Textadd.Text, Val(w1), Me.TextDiscountPercentageWhenSelling.Text, sum2.ToString, rsum.ToString, wsum1.ToString, Val(Discount)})
<<<<<<< HEAD
                    Dim Sound As Stream = My.Resources.BarCode
=======
                    Dim Sound As System.IO.Stream = My.Resources.BarCode
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    My.Computer.Audio.Play(Sound, AudioPlayMode.Background)
                End If
            Else
                MsgBox("هذا الصنف غير موجود", MsgBoxStyle.Information, "تنبيه")
            End If
            Me.Timsum.Start()
            Me.Datab.FirstDisplayedScrollingRowIndex = Datab.Rows.Count - 1
            Me.List0.Items.Clear()
            Me.List0_SelectedIndexChanged(sender, e)
            Me.Textadd.Clear()
            Me.TextBarCode.Clear()
            Me.TexTSellingPrice.Clear()
            Me.TEXT16.Clear()
            Me.DataGridView2.Rows.Clear()
            Me.GetGrdQuantities()
            Me.TextBarCode.Focus()
            'Me.Timsum.Stop()
        Else
            MsgBox("عفواً هذه الكميات أكبر من رصيد الصنف", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight)
        End If
    End Sub

<<<<<<< HEAD
    Private Sub Bude_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Buttondelete.Click
=======
    Private Sub Bude_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttondelete.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If LockDelete = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If Datab.SelectedRows.Count > 0 Then
                For i As Integer = Datab.SelectedRows.Count - 1 To 0
                    Me.Datab.Rows.RemoveAt(Me.Datab.SelectedRows(i).Index)
                    Dim tota4 As Double
                    For Each r As DataGridViewRow In Datab.Rows
                        tota4 += CDbl(r.Cells(2).Value)
                    Next
                    Me.TextMovementSymbol.Text = "QR" & TEXTInvoiceNumber.Text
                    Me.TextItemBalance.Text = Format(Val(Me.TextItemBalance.Text) - Val(tota4), "0.000")
                Next
            Else
                MsgBox("حدد الصنف بشكل جيد", MsgBoxStyle.Critical, "تنبيه")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub Bupl_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Bupl.Click
        Me.Textadd.Text += 1
    End Sub
    Private Sub Bum_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Bum.Click
=======
    Private Sub Bupl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bupl.Click
        Me.Textadd.Text += 1
    End Sub
    Private Sub Bum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bum.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Me.Textadd.Text.Trim = 0 Then
            Exit Sub
        End If
        Me.Textadd.Text -= 1
    End Sub
<<<<<<< HEAD
    Private Sub Timsum_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timsum.Tick
=======
    Private Sub Timsum_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timsum.Tick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.ButtonAddCategory.TabStop = False
        Dim total As Double
        Dim tota2 As Double
        Dim tota3 As Double
        Dim tota4 As Double

        For Each r As DataGridViewRow In Me.Datab.Rows
            total += CDbl(r.Cells(4).Value)  ' الخصم
            tota2 += CDbl(r.Cells(5).Value) 'السعر
            tota3 += CDbl(r.Cells(2).Value) 'العدد
            tota4 += CDbl(r.Cells(6).Value) 'مجموع الخصم
        Next
        Me.TextB4.Text = total.ToString("0.000")
        Me.TextTotalPrice.Text = tota2.ToString("0.000")
        Me.TextItemCount.Text = tota3.ToString("0.000")
        Me.TextB4.Text = tota4.ToString("0.000")
        '--------------------------------------------
        If Me.TextpaidUp.Text.Trim > 0 Then
            Dim s1 As Double = Me.TextpaidUp.Text.Trim ' المدفوع
            Dim s2 As Double = Me.TextTotalPrice.Text.Trim ' الاجمالي
            Dim s3 As Double = Me.TextB4.Text.Trim  ' الخصم
            Dim suming As Double
            suming = Abs(s1 - s2) '+ s3
            Me.TextRest.Text = suming.ToString("0.000")
        End If
        If Me.TextRest.Text.Trim.Contains("-") Then
            Me.TextRest.Text = "0.000"
        End If
        If Me.TextTotalPrice.Text.Trim = "0.000" Then
            Me.TextRest.Text = "0.000"
        End If
        If Me.TextpaidUp.Text.Trim = "0.000" Or Me.TextpaidUp.Text.Trim = "0.000" Then
            Me.TextRest.Text = "0.000"
        End If
        Dim dgvRow As New DataGridViewRow
        For Each dgvRow In Me.Datab.Rows
            If dgvRow.Index Mod 2 = 0 Then
                Me.Datab.Rows(dgvRow.Index).DefaultCellStyle.BackColor = Color.LightYellow
            End If
        Next

    End Sub
<<<<<<< HEAD
    Private Sub Timsum1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timsum1.Tick
=======
    Private Sub Timsum1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timsum1.Tick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.Datab.Rows(0).Selected = True
        Me.List0.ClearSelected()
        If Datab.Rows.Count = 0 Then
        Else
            Dim counter As Integer = Me.Datab.CurrentRow.Index + 1
            Dim nextRow As DataGridViewRow
            If counter = Datab.RowCount Then
                nextRow = Me.Datab.Rows(0)
                Me.List0.ClearSelected()
                Me.SEARCHDATAITEMS()
                Me.SEARCHDATAITEMS1()
                Me.SaveStocks()
                Me.Timsum.Stop()
                Me.Timsum1.Stop()
                If Cheprint.Checked = True Then
                    Dim ReportToday As New ReportTodaySales
                    ReportToday.ParameterTS9.Value = TEXTInvoiceNumber.Text
                    ReportToday.ParameterTS9.Visible = False
                    ReportToday.RequestParameters = False
                    ReportToday.LblAsUser.Text = AssociationName
                    Dim ToolReportToday As New ReportPrintTool(ReportToday)
                    ReportToday.CreateDocument()
                    ReportToday.ShowPreview
                End If
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
                Me.ButtonNew.PerformClick()
            Else
                nextRow = Datab.Rows(counter)
                nextRow.Selected = True
                Me.List0.ClearSelected()
                Me.SEARCHDATAITEMS()
                Me.SEARCHDATAITEMS1()
                Me.SaveStocks()
            End If
            Me.Datab.CurrentCell = nextRow.Cells(0)
            nextRow.Selected = True
            Me.Datab.Rows(counter).Selected = True
            Me.List0.ClearSelected()
        End If
    End Sub
    Private Sub SEARCHDATAITEMS1()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim strsql1 As New SqlCommand("SELECT DISTINCT STK1 FROM STOCKS WHERE STK7 = '" & Me.Datab.CurrentRow.Cells(0).Value & "'" & "AND STK16 = '" & Me.TextMovementSymbol.Text & "'", Consum)
        Dim ds1 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql1)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql1 As New SqlClient.SqlCommand("SELECT DISTINCT STK1 FROM STOCKS WHERE STK7 = '" & Me.Datab.CurrentRow.Cells(0).Value & "'" & "AND STK16 = '" & Me.TextMovementSymbol.Text & "'", Consum)
        Dim ds1 As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds1.Clear()
        Adp1.Fill(ds1, "STOCKS")
        If ds1.Tables(0).Rows.Count > 0 Then
            Me.TextSTK1.Text = ds1.Tables(0).Rows(0).Item(0)
        Else
            Me.TextSTK1.Text = "0"
        End If

    End Sub
<<<<<<< HEAD
    Private Sub TextB1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub TextB1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Char.IsControl(e.KeyChar) = False Then
            If Char.IsDigit(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub T1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TexTSellingPrice.KeyPress
=======
    Private Sub T1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TexTSellingPrice.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Char.IsControl(e.KeyChar) = False Then
            If Char.IsDigit(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub Textadd_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Textadd.KeyDown
=======
    Private Sub Textadd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Textadd.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If e.KeyCode = Keys.Enter Then
            Me.Buadd_Click(sender, e)
        ElseIf e.KeyCode = Keys.End Then
            Me.ButtonSaveAndPrint_Click(sender, e)
        End If
    End Sub
<<<<<<< HEAD
    Private Sub Textadd_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Textadd.KeyPress
=======
    Private Sub Textadd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Textadd.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Char.IsControl(e.KeyChar) = False Then
            If Char.IsDigit(e.KeyChar) Then
            Else
                e.Handled = True
            End If

            If Asc(e.KeyChar) = Keys.Enter Then
                Me.Buadd_Click(sender, e)
            End If
        End If
    End Sub
<<<<<<< HEAD
    Private Sub Datab_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As DataGridViewCellMouseEventArgs) Handles Datab.CellMouseDoubleClick
=======
    Private Sub Datab_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Datab.CellMouseDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Datab.SelectedRows.Count > 0 Then
                For i As Integer = Datab.SelectedRows.Count - 1 To 0
                    Datab.Rows.RemoveAt(Datab.SelectedRows(i).Index)
                Next
            Else
                MsgBox("حدد السلعة بشكل جيد ", MsgBoxStyle.Critical, "تنبيه")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
<<<<<<< HEAD
    Private Sub Form_beea_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
=======
    Private Sub Form_beea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If e.KeyCode = Keys.F12 Then
            If TextpaidUp.Text.Trim = "0" Or TextpaidUp.Text.Trim = "" Then
                MsgBox("لا يمكن الحفظ المدفوع لا شيء = 0" & Environment.NewLine, MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
            Dim a As Integer = Me.TextTotalPrice.Text.Trim
            Dim b As Integer = Me.TextpaidUp.Text.Trim
            If a > b Then
                MsgBox(" المدفوع اقل من الاجمالي لا يمكن الحفظ الرجاء الدفع اكبر من الاجمالي " & Environment.NewLine & Me.TextTotalPrice.Text.Trim & " > " & Me.TextpaidUp.Text.Trim, MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
            ButtonSaveAndPrint.PerformClick()
        ElseIf e.KeyCode = Keys.C Then
            On Error Resume Next
            Dim f As New Form_MADFOA(Me)
            'f.Show()
            f.TextpaidUp.Text = Me.TextTotalPrice.Text
            f.ShowDialog()
            f.TextpaidUp.Text = Me.TextTotalPrice.Text
            'Me.TextpaidUp.Text = f.TextpaidUp.Text
        ElseIf e.KeyCode = Keys.F7 Then
            Form_ASTRJAA.Show()
        ElseIf e.KeyCode = Keys.N Then
            ButtonNew.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
<<<<<<< HEAD
    Private Sub Buadd_KeyUp(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles ButtonAddCategory.KeyUp
=======
    Private Sub Buadd_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ButtonAddCategory.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        TextItemCount.Focus()
        If e.KeyCode = Keys.Enter Then
            TextItemCount.Focus()
        End If
    End Sub
<<<<<<< HEAD
    Private Sub Buadd_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles ButtonAddCategory.KeyDown
        TextItemCount.Focus()
    End Sub
    Private Sub Buadd_Enter(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAddCategory.Enter
=======
    Private Sub Buadd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ButtonAddCategory.KeyDown
        TextItemCount.Focus()
    End Sub
    Private Sub Buadd_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddCategory.Enter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        TextItemCount.Focus()
    End Sub
    Private Sub TextB1_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        On Error Resume Next
        If Me.TextpaidUp.Text.Trim > 0 Then
            Dim a As Integer = Me.TextTotalPrice.Text.Trim
            Dim b As Integer = Me.TextpaidUp.Text.Trim
            If a > b Then
                MsgBox(" المدفوع اقل من الاجمالي لا يمكن الدفع الرجاء الدفع اكبر من الاجمالي " & Environment.NewLine & Me.TextTotalPrice.Text.Trim & " > " & Me.TextpaidUp.Text.Trim, MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
        End If
    End Sub
    Private Sub TextB2_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        On Error Resume Next
        Dim a As Integer = Me.TextTotalPrice.Text.Trim
        Dim b As Integer = Me.TextpaidUp.Text.Trim
        If a > b Then
            MsgBox(" المدفوع اقل من الاجمالي لا يمكن الدفع الرجاء الدفع اكبر من الاجمالي" & Environment.NewLine & Me.TextTotalPrice.Text.Trim & " > " & Me.TextpaidUp.Text.Trim, MsgBoxStyle.Critical, "تنبيه")
            Exit Sub
        End If
    End Sub
    Private Sub M1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles M1.SelectedIndexChanged
        If M1.Text.Trim = "استرجاع F7" Then
            Form_ASTRJAA.Show()
        ElseIf M1.Text.Trim = "متابعة الفاتورة" Then
            Form_FATORAMALK0.Show()
        End If
    End Sub
    Private Sub Butcan_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonNew.Click
        If LockAddRow = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Me.Timsum.Stop()
        'Me.Datab.DataSource = Nothing
        Me.TextTotalPrice.Text = "0.000"
        Me.Datab.Rows.Clear()


        Me.TextNetItemsAvailableSale.Text = ""
        Me.TextNetItemsAfterSale.Text = ""
        Me.TextNetItemsA.Text = ""
        Me.TextItemBalanceAfterSale.Text = ""
        Me.TextItemBalanceAfterSaleA.Text = ""


        Me.TextTot.Text = ""
        Me.TextNetItems.Text = ""
        Me.TextNetItemsSale.Text = ""
        Me.TextItemBalanceA.Text = ""
        'Me.Datab.Columns.Clear()
        'Dim cobr1 As New DataGridViewTextBoxColumn
        'cobr1.DataPropertyName = "day1"
        'cobr1.HeaderText = "الباركود"
        'cobr1.Name = "day1"
        'Datab.Columns.Add(cobr1)

        'Dim col As New DataGridViewTextBoxColumn
        'col.DataPropertyName = "day"
        'col.HeaderText = "اسم الصنف"
        'col.Name = "day"
        'Me.Datab.Columns.Add(col)

        'Dim col2 As New DataGridViewTextBoxColumn
        'col2.DataPropertyName = "month"
        'col2.HeaderText = "العدد "
        'col2.Name = "month"
        'Me.Datab.Columns.Add(col2)

        'Dim col3 As New DataGridViewTextBoxColumn
        'col3.DataPropertyName = "year"
        'col3.HeaderText = "السعر"
        'col3.Name = "year"
        'Datab.Columns.Add(col3)

        'Dim col4 As New DataGridViewTextBoxColumn
        'col4.DataPropertyName = "year"
        'col4.HeaderText = "الخصم "
        'col4.Name = "year"
        'Me.Datab.Columns.Add(col4)

        'Dim col5 As New DataGridViewTextBoxColumn
        'col5.DataPropertyName = "year"
        'col5.HeaderText = "مجموع السعر "
        'col5.Name = "year"
        'Me.Datab.Columns.Add(col5)

        'Dim col6 As New DataGridViewTextBoxColumn
        'col6.DataPropertyName = "year"
        'col6.HeaderText = "مجموع الخصم "
        'col6.Name = "year"
        'Me.Datab.Columns.Add(col6)
        'Me.Datab.Rows.Clear()
        Me.TexTSellingPrice.Text = "0"
        Me.TextDiscountPercentageWhenSelling.Text = "0"
        Me.Textadd.Text = "1"
        Me.TextpaidUp.Text = "0.000"
        Me.TextTotalPrice.Text = "0.000"
        Me.TextRest.Text = "0.000"
        Me.TextItemCount.Text = "0"
        Me.Temi.Text = dt1.ToString("hh:mm:ss tt")
        Me.Tedate.Text = MaxDate.ToString("yyyy-MM-dd")
        Me.TextB4.Text = "0"
        GetAutoNumber("TS9", "TodaySales", "DataTS")
        Me.TEXTInvoiceNumber.Text = AutoNumber
        Me.TextMovementSymbol.Text = "QR" & TEXTInvoiceNumber.Text

        Me.M1.Text = "بيع"
        Me.SEARCHBALANCEITEMS()

        'Me.TextBox10.Text = Format(Val(Me.TextBox10.Text) - Val(Me.TextBox45.Text), "0.000")
        Me.Timsum.Start()
    End Sub
    Private Sub Butcash_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Butcash.Click
        On Error Resume Next
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim f As New Form_MADFOA(Me)
        f.TextpaidUp.Text = Me.TextTotalPrice.Text
        f.ShowDialog()
        f.TextpaidUp.Text = Me.TextTotalPrice.Text

    End Sub

    Private Sub Form_beea_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Dim EDITOK As String = MsgBox(" قم بحفظ اي فاتورة نشطه هل انت متاكد من الخروج  ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "تأكيد عملية الخروج")
        'If EDITOK = vbYes Then
        '    e.Cancel = False
        'ElseIf EDITOK = vbNo Then
        '    e.Cancel = True
        'End If
    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub Ch1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.ButtonAddCategory.Enabled = True
        Me.Datab.Show()
        Me.TextpaidUp.Focus()
        Me.Timsum.Stop()
        Me.Datab.DataSource = Nothing
        Me.TextTotalPrice.Text = "0.000"
        Me.Datab.Rows.Clear()

        Me.TextNetItemsAvailableSale.Text = ""
        Me.TextNetItemsAfterSale.Text = ""
        Me.TextNetItemsA.Text = ""
        Me.TextItemBalanceAfterSale.Text = ""
        Me.TextItemBalanceAfterSaleA.Text = ""


        Me.TextTot.Text = ""
        Me.TextNetItems.Text = ""
        Me.TextNetItemsSale.Text = ""
        Me.TextItemBalanceA.Text = ""
    End Sub

<<<<<<< HEAD
=======


>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub Buttaleek_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonInvoiceComment.Click
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية تعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If

        Dim deleteok As String = MsgBox("هل ترغب بتعليق الفاتورة الحالية النشطه ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "تأكيد عملية التعليق")
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If deleteok = vbYes Then
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim cmdW As New SqlCommand(" Select NUMfatora From TaleekFatoBEEA Where NUMfatora = '" & TEXTInvoiceNumber.Text.Trim & "'", Consum)
            Dim drW As SqlDataReader = cmdW.ExecuteReader()
            If drW.Read Then
                MsgBox(" رقم الفاتورة المراد تعليقها موجود مسبقاً", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Temi.Text = dt1.ToString("hh:mm:ss tt")
            Tedate.Text = MaxDate.ToString("yyyy-MM-dd")
            Try
                Dim Row = Datab.CurrentRow
                If Row Is Nothing Then
                    MsgBox(" لا يوجد بيانات للتعليق There are no data ", MsgBoxStyle.Critical, "تنبيه")
                    Exit Sub
                End If
                GetAutoNumber("TS9", "TodaySales", "DataTS")
                Me.TEXTInvoiceNumber.Text = AutoNumber
                If Consum.State = ConnectionState.Open Then
                    Consum.Close()
                End If
                Consum.Open()
                Dim cmd1 As New SqlCommand(" Select NUMfatora From TaleekFatoBEEA Where NUMfatora = '" & TEXTInvoiceNumber.Text.Trim & "'", Consum)
                Dim dr As SqlDataReader = cmd1.ExecuteReader()
                If dr.Read Then
                    MsgBox(" رقم الفاتورة المراد تعليقها موجود مسبقاً", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                Consum.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End Try
            Dim n As Integer
            Try
                If Consum.State = ConnectionState.Open Then
                    Consum.Close()
                End If
                Consum.Open()
                For n = 0 To Datab.RowCount - 1
                    Dim cmd99 As New SqlCommand("insert into TaleekFatoBEEA (Asmmantg,Addm,Sar,Ksm,majmoa,majmoakasm,NUMfatora) values (@Asmmantg,@Addm,@Sar,@Ksm,@majmoa,@majmoakasm,@NUMfatora)", Consum)
                    cmd99.Parameters.AddWithValue("@Asmmantg", Datab.Item(0, n).Value)
                    cmd99.Parameters.AddWithValue("@Addm", Datab.Item(1, n).Value) '
                    cmd99.Parameters.AddWithValue("@Sar", Datab.Item(2, n).Value) '
                    cmd99.Parameters.AddWithValue("@Ksm", Datab.Item(3, n).Value) '
                    cmd99.Parameters.AddWithValue("@majmoa", Datab.Item(4, n).Value) '
                    cmd99.Parameters.AddWithValue("@majmoakasm", Datab.Item(5, n).Value) '
                    cmd99.Parameters.AddWithValue("@NUMfatora", TEXTInvoiceNumber.Text.Trim) '
                    cmd99.ExecuteNonQuery()
                    cmd99.Dispose()
                Next
                MsgBox("تم تعليق الفاتورة", MsgBoxStyle.Exclamation)
                If Cheprint.Checked = True Then
                    Dim rpt As New Cry_TALEEK
                    Dim objText6 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("Text3")
                    objText6.Text = TEXTInvoiceNumber.Text.Trim
                    rpt.PrintToPrinter(1, True, 0, 0)
                    rpt.PrintToPrinter(1, True, 0, 0)
                End If
                Try
                    If Consum.State = ConnectionState.Open Then
                        Consum.Close()
                    End If
                    Insert_Actions(TEXTInvoiceNumber.Text.Trim, " تعليق فاتورة مبيعات", Me.Text)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                ButtonNew.PerformClick()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub Timer_send_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_send.Tick
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Dim cmdD As New SqlCommand("select * from SendREPORT ", Consum)
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim drD As SqlDataReader = cmdD.ExecuteReader
            If drD.Read = True Then
                SEN1 = drD.Item("MRSL")
                SEN2 = drD.Item("AUSER")
                SEN3 = drD.Item("APASS")
                SEN4 = drD.Item("INVAL")
                SEN5 = drD.Item("PHONE")
                SEN6 = drD.Item("MAIL")
            End If
            drD.Close()
            Consum.Close()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim cmdDd As New SqlCommand("select * from SendREPORT ", Consum)
            Dim drDd As SqlDataReader = cmdDd.ExecuteReader
            If drDd.Read = True Then
                CHEE1 = drDd.Item("SENDPHNE")
                CHEE2 = drDd.Item("SENDMAIL")
                CHEE3 = drDd.Item("CHEEEK")
            End If
            Consum.Close()
        Catch ex As Exception
            'Me.Timer_sendmail.Stop()
            MsgBox(ex.Message)
            Exit Sub
        End Try
        If SEN4 = ServerDateTime.ToString("hh:mm:ss tt") Then
            Me.Timer_send.Stop()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim str1 As String = "Select CHEEEK,SENDPHNE From SendREPORT Where CHEEEK = '" & "1" & "' and SENDPHNE ='" & "1" & "'"
            Dim sda1 As New SqlDataAdapter(str1, Consum)
            Dim ds1 As New DataSet
            sda1.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Dim da2 As New SqlDataAdapter("select sum(CAST(TS5 as int)) from TodaySales where DataTS like  '%" & dt1.ToString("yyyy-MM-dd") & "%'", Consum)
                Dim ds2 As New DataSet
                da2.Fill(ds2)
                sum1 = ds2.Tables(0).Rows(0)(0).ToString
                Consum.Close()
                da2.Dispose()
                ds2.Dispose()
                'الباركود
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Dim da5 As New SqlDataAdapter("select sum(CAST(Sarmantg3 as int)) from ASTRGA_ASTRDA where DataD10 like  '%" & dt1.ToString("yyyy-MM-dd") & "%'", Consum)
                Dim ds5 As New DataSet
                da5.Fill(ds5)
                sum4 = ds5.Tables(0).Rows(0)(0).ToString
                Consum.Close()
                da5.Dispose()
                ds5.Dispose()
                Using cmd As New SqlCommand("select sum(TS5) from TodaySales where DataTS like  '%" & dt1.ToString("yyyy-MM-dd") & "%'", Consum)
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    sum5 = cmd.ExecuteScalar.ToString
                    Consum.Close()
                End Using
                GOM = "المبيعات" & "=" & sum1 & Environment.NewLine & "الباركود" & "=" & sum2 & Environment.NewLine & "سلع الوقت" & "=" & sum3 & Environment.NewLine & "الاسترجاع" & "=" & sum4 & Environment.NewLine & "خصم المبيعات" & "=" & sum5 & Environment.NewLine & "خصم الباركود" & "=" & sum6 & Environment.NewLine & "الحجوزات" & "=" & sum7
            ElseIf ds1.Tables(0).Rows.Count = 0 Then
                Me.Timer_send.Stop()
                Try
                    Insert_Actions(TEXTInvoiceNumber.Text.Trim, "  لم يتمكن النظام من ارسال تقارير للجوال لعدم تفعيل الصلاحية", Me.Text)
                Catch ex As Exception
                    Timer_send.Stop()
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
                MsgBox("لم يتمكن النظام من ارسال تقارير للجوال لعدم تفعيل الصلاحية", MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
            Try
                Dim user As String = SEN2
                Dim password As String = SEN3
                Dim sendername As String = SEN1
                Dim numers As String = SEN5
                Dim text As String = GOM
                Dim request As WebRequest = WebRequest.Create("http://www.4jawaly.net/api/sendsms.php?username=" & user & "&password=" & password &
                                                                "&message=" & text & "&numbers=" & numers & "&sender=" & sendername & "&unicode=e&return=full")
                request.Method = "POST"
                Dim postData As String = "This is a test that posts this string to a Web server."
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
                request.ContentType = "application/x-www-form-urlencoded"
                request.ContentLength = byteArray.Length
                Dim dataStream As Stream = request.GetRequestStream()
                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()
                Dim response As WebResponse = request.GetResponse()
                dataStream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()
                Try
                    Insert_Actions(TEXTInvoiceNumber.Text.Trim, "  عملية إرسال تقارير إلى الجوال والايميل", Me.Text)
                    Consum.Close()
                Catch ex As Exception
                    'Me.Timer_send.Stop()
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
                reader.Close()
                dataStream.Close()
                response.Close()
            Catch EX As Exception
                'Me.Timer_send.Stop()
                MsgBox(EX.Message, MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub Timer_sendmail_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_sendmail.Tick
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Dim cmdD As New SqlCommand("select * from SendREPORT ", Consum)
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim drD As SqlDataReader = cmdD.ExecuteReader
            If drD.Read = True Then
                SEN1 = drD.Item("MRSL")
                SEN2 = drD.Item("AUSER")
                SEN3 = drD.Item("APASS")
                SEN4 = drD.Item("INVAL")
                SEN5 = drD.Item("PHONE")
                SEN6 = drD.Item("MAIL")
                SEN7 = drD.Item("MAILPASS")
                SEN8 = drD.Item("MAILMASTKBL")
            End If
            drD.Close()
            Consum.Close()
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim cmdDd As New SqlCommand("select * from SendREPORT ", Consum)
            Dim drDd As SqlDataReader = cmdDd.ExecuteReader
            If drDd.Read = True Then
                CHEE1 = drDd.Item("SENDPHNE")
                CHEE2 = drDd.Item("SENDMAIL")
                CHEE3 = drDd.Item("CHEEEK")
            End If
            Consum.Close()
        Catch ex As Exception
            Timer_sendmail.Stop()
            MsgBox(ex.Message)
            Exit Sub
        End Try
        If SEN4 = ServerDateTime.ToString("hh:mm:ss tt") Then
            Timer_sendmail.Stop()
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim str1 As String = "Select CHEEEK,SENDMAIL From SendREPORT Where CHEEEK = '" & "1" & "' and SENDMAIL ='" & "1" & "'"
            Dim sda1 As New SqlDataAdapter(str1, Consum)
            Dim ds1 As New DataSet
            sda1.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                If Consum.State = ConnectionState.Open Then
                    Consum.Close()
                End If
                Consum.Open()
                Dim da2 As New SqlDataAdapter("select sum(CAST(TS5 as int)) from TodaySales where DataTS like  '%" & dt1.ToString("yyyy-MM-dd") & "%'", Consum)
                Dim ds2 As New DataSet
                da2.Fill(ds2)
                sum1 = ds2.Tables(0).Rows(0)(0).ToString
                Consum.Close()
                da2.Dispose()
                ds2.Dispose()
                If Consum.State = ConnectionState.Open Then
                    Consum.Close()
                End If
                Consum.Open()

                If Consum.State = ConnectionState.Open Then
                    Consum.Close()
                End If
                Consum.Open()
                Dim da5 As New SqlDataAdapter("select sum(CAST(Sarmantg3 as int)) from ASTRGA_ASTRDA where DataD10 like  '%" & dt1.ToString("yyyy-MM-dd") & "%'", Consum)
                Dim ds5 As New DataSet
                da5.Fill(ds5)
                sum4 = ds5.Tables(0).Rows(0)(0).ToString
                Consum.Close()
                da5.Dispose()
                ds5.Dispose()
                Using cmd As New SqlCommand("select sum(TS5) from TodaySales where DataTS like  '%" & dt1.ToString("yyyy-MM-dd") & "%'", Consum)
                    Consum.Open()
                    sum5 = cmd.ExecuteScalar.ToString
                    Consum.Close()
                End Using

                GOM = "المبيعات" & "=" & sum1 & Environment.NewLine & "الباركود" & "=" & sum2 & Environment.NewLine & "سلع الوقت" & "=" & sum3 & Environment.NewLine & "الاسترجاع" & "=" & sum4 & Environment.NewLine & "خصم المبيعات" & "=" & sum5 & Environment.NewLine & "خصم الباركود" & "=" & sum6 & Environment.NewLine & "الحجوزات" & "=" & sum7
                Try
                    '+========MAILING================
                    Me.PictureBox1.Visible = True
                    Dim MyMailMessage As New MailMessage With {
                        .From = New MailAddress(SEN8) 'username
                        }
                    MyMailMessage.To.Add(SEN8) 'username
                    MyMailMessage.Subject = "--تقرير مبيعات النظام-- "
                    MyMailMessage.SubjectEncoding = System.Text.Encoding.UTF8
                    MyMailMessage.Body = GOM
                    MyMailMessage.BodyEncoding = System.Text.Encoding.UTF8
                    MyMailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    Dim SMTPServer As New SmtpClient("smtp.gmail.com") With {
                        .Port = 587,
                        .Host = "smtp.gmail.com",
<<<<<<< HEAD
                        .Credentials = New NetworkCredential(SEN6, SEN7),
=======
                        .Credentials = New System.Net.NetworkCredential(SEN6, SEN7),
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        .EnableSsl = True
                    }
                    SMTPServer.Send(MyMailMessage)
                    SMTPServer.EnableSsl = True
                    SMTPServer.SendAsync(MyMailMessage, Nothing)
                Catch ex As Exception
                    Me.Timer_sendmail.Stop()
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
                    Me.PictureBox1.Visible = False
                    Exit Sub
                End Try
            ElseIf ds1.Tables(0).Rows.Count = 0 Then
                Me.Timer_sendmail.Stop()
                Try
                    If Consum.State = ConnectionState.Open Then
                        Consum.Close()
                    End If
                    Consum.Open()
                    Insert_Actions(Me.TEXTInvoiceNumber.Text.Trim, Me.TextMovementSymbol.Text.Trim & "-" & " لم يتمكن النظام من ارسال تقارير للبريد لعدم تفعيل الصلاحية", Me.Text)
                    Consum.Close()
                Catch ex As Exception
                    Timer_sendmail.Stop()
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
                Exit Sub
            End If
            Try
                Try
                    If Consum.State = ConnectionState.Open Then
                        Consum.Close()
                    End If
                    Consum.Open()
                    Insert_Actions(TEXTInvoiceNumber.Text.Trim, TextMovementSymbol.Text.Trim & "-" & "  عملية إرسال تقارير إلى الجوال والايميل", Me.Text)
                    Consum.Close()
                Catch ex As Exception
                    Timer_sendmail.Stop()
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
            Catch EX As Exception
                Timer_sendmail.Stop()
                MsgBox(EX.Message, MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub Bufind_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bufind.Click
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Form_finddd.Show()
    End Sub
    Private Sub Butsala_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonSettings.Click
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If

        Dim F As New FrmStocks1 With {
            .TB1 = "",
            .TB2 = ""
        }
        F.Show()
    End Sub

    Private Sub Timer_send2_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_send2.Tick
        Try

<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Dim cmdD As New SqlCommand("select * from SendREPORT ", Consum)
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim drD As SqlDataReader = cmdD.ExecuteReader
            If drD.Read = True Then
                SEN1 = drD.Item("MRSL")
                SEN2 = drD.Item("AUSER")
                SEN3 = drD.Item("APASS")
                SEN4 = drD.Item("INVAL")
                SEN5 = drD.Item("PHONE")
                SEN6 = drD.Item("MAIL")
                SEN9 = drD.Item("INVAL2")
            End If
            drD.Close()
            Consum.Close()
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim cmdDd As New SqlCommand("select * from SendREPORT ", Consum)
            Dim drDd As SqlDataReader = cmdDd.ExecuteReader
            If drDd.Read = True Then
                CHEE1 = drDd.Item("SENDPHNE")
                CHEE2 = drDd.Item("SENDMAIL")
                CHEE3 = drDd.Item("CHEEEK")
            End If
            Consum.Close()
        Catch ex As Exception
            Timer_sendmail.Stop()
            MsgBox(ex.Message)
            Exit Sub
        End Try
        If SEN9 = ServerDateTime.ToString("hh:mm:ss tt") Then
            Timer_send2.Stop()
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim str1 As String = "Select CHEEEK,SENDPHNE From SendREPORT Where CHEEEK = '" & "1" & "' and SENDPHNE ='" & "1" & "'"
            Dim sda1 As New SqlDataAdapter(str1, Consum)
            Dim ds1 As New DataSet
            sda1.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                If Consum.State = ConnectionState.Open Then
                    Consum.Close()
                End If
                Consum.Open()
                Dim da2 As New SqlDataAdapter("select sum(CAST(TS5 as int)) from TodaySales where DataTS like  '%" & dt1.ToString("yyyy-MM-dd") & "%'", Consum)
                Dim ds2 As New DataSet
                da2.Fill(ds2)
                sum1 = ds2.Tables(0).Rows(0)(0).ToString
                Consum.Close()
                da2.Dispose()
                ds2.Dispose()
                If Consum.State = ConnectionState.Open Then
                    Consum.Close()
                End If
                Consum.Open()
                Dim da5 As New SqlDataAdapter("select sum(CAST(Sarmantg3 as int)) from ASTRGA_ASTRDA where DataD10 like  '%" & dt1.ToString("yyyy-MM-dd") & "%'", Consum)
                Dim ds5 As New DataSet
                da5.Fill(ds5)
                sum4 = ds5.Tables(0).Rows(0)(0).ToString
                Consum.Close()
                da5.Dispose()
                ds5.Dispose()
                Using cmd As New SqlCommand("select sum(TS5) from TodaySales where DataTS like  '%" & dt1.ToString("yyyy-MM-dd") & "%'", Consum)
                    Consum.Open()
                    sum5 = cmd.ExecuteScalar.ToString
                    Consum.Close()
                End Using
                GOM = "المبيعات" & "=" & sum1 & Environment.NewLine & "الباركود" & "=" & sum2 & Environment.NewLine & "سلع الوقت" & "=" & sum3 & Environment.NewLine & "الاسترجاع" & "=" & sum4 & Environment.NewLine & "خصم المبيعات" & "=" & sum5 & Environment.NewLine & "خصم الباركود" & "=" & sum6 & Environment.NewLine & "الحجوزات" & "=" & sum7
            ElseIf ds1.Tables(0).Rows.Count = 0 Then
                Timer_send2.Stop()
                Try
                    If Consum.State = ConnectionState.Open Then
                        Consum.Close()
                    End If
                    Consum.Open()
                    Insert_Actions(TEXTInvoiceNumber.Text.Trim, TextMovementSymbol.Text.Trim & "-" & " لم يتمكن النظام من ارسال تقارير للبريد لعدم تفعيل الصلاحية", Me.Text)
                    Consum.Close()
                Catch ex As Exception
                    Timer_send2.Stop()
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
                Exit Sub
            End If
            Try
                Dim user As String = SEN2
                Dim password As String = SEN3
                Dim sendername As String = SEN1
                Dim numers As String = SEN5
                Dim text As String = GOM
                Dim request As WebRequest = WebRequest.Create("http://www.4jawaly.net/api/sendsms.php?username=" & user & "&password=" & password &
                                                              "&message=" & text & "&numbers=" & numers & "&sender=" & sendername & "&unicode=e&return=full")
                request.Method = "POST"
                Dim postData As String = "This is a test that posts this string to a Web server."
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
                request.ContentType = "application/x-www-form-urlencoded"
                request.ContentLength = byteArray.Length
                Dim dataStream As Stream = request.GetRequestStream()
                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()
                Dim response As WebResponse = request.GetResponse()
                dataStream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()
                Try
                    If Consum.State = ConnectionState.Open Then
                        Consum.Close()
                    End If
                    Consum.Open()
                    Insert_Actions(TEXTInvoiceNumber.Text.Trim, TextMovementSymbol.Text.Trim & "-" & "عملية إرسال تقارير إلى الجوال والايميل", Me.Text)
                    Consum.Close()
                Catch ex As Exception
                    Timer_send2.Stop()
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
                reader.Close()
                dataStream.Close()
                response.Close()
            Catch EX As Exception
                Timer_send2.Stop()
                MsgBox(EX.Message, MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub Timer_sendmail2_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer_sendmail2.Tick
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Dim cmdD As New SqlCommand("select * from SendREPORT ", Consum)
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim drD As SqlDataReader = cmdD.ExecuteReader
            If drD.Read = True Then
                SEN1 = drD.Item("MRSL")
                SEN2 = drD.Item("AUSER")
                SEN3 = drD.Item("APASS")
                SEN4 = drD.Item("INVAL")
                SEN5 = drD.Item("PHONE")
                SEN6 = drD.Item("MAIL")
                SEN7 = drD.Item("MAILPASS")
                SEN8 = drD.Item("MAILMASTKBL")
                SEN9 = drD.Item("INVAL2")
            End If
            drD.Close()
            Consum.Close()
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim cmdDd As New SqlCommand("select * from SendREPORT ", Consum)
            Dim drDd As SqlDataReader = cmdDd.ExecuteReader
            If drDd.Read = True Then
                CHEE1 = drDd.Item("SENDPHNE")
                CHEE2 = drDd.Item("SENDMAIL")
                CHEE3 = drDd.Item("CHEEEK")
            End If
            Consum.Close()
        Catch ex As Exception
            Timer_sendmail.Stop()
            MsgBox(ex.Message)
            Exit Sub
        End Try
        If SEN9 = ServerDateTime.ToString("hh:mm:ss tt") Then
            Timer_sendmail2.Stop()
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim str1 As String = "Select CHEEEK,SENDMAIL From SendREPORT Where CHEEEK = '" & "1" & "' and SENDMAIL ='" & "1" & "'"
            Dim sda1 As New SqlDataAdapter(str1, Consum)
            Dim ds1 As New DataSet
            sda1.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                If Consum.State = ConnectionState.Open Then
                    Consum.Close()
                End If
                Consum.Open()
                Dim da2 As New SqlDataAdapter("select sum(CAST(TS5 as int)) from TodaySales where DataTS like  '%" & dt1.ToString("yyyy-MM-dd") & "%'", Consum)
                Dim ds2 As New DataSet
                da2.Fill(ds2)
                sum1 = ds2.Tables(0).Rows(0)(0).ToString
                Consum.Close()
                da2.Dispose()
                ds2.Dispose()
                If Consum.State = ConnectionState.Open Then
                    Consum.Close()
                End If
                Consum.Open()
                Dim da5 As New SqlDataAdapter("select sum(CAST(Sarmantg3 as int)) from ASTRGA_ASTRDA where DataD10 like  '%" & dt1.ToString("yyyy-MM-dd") & "%'", Consum)
                Dim ds5 As New DataSet
                da5.Fill(ds5)
                sum4 = ds5.Tables(0).Rows(0)(0).ToString
                Consum.Close()
                da5.Dispose()
                ds5.Dispose()
                Using cmd As New SqlCommand("select sum(SumKASM) from TodaySales where DataD like  '%" & dt1.ToString("yyyy-MM-dd") & "%'", Consum)
                    Consum.Open()
                    sum5 = cmd.ExecuteScalar.ToString
                    Consum.Close()
                End Using
                GOM = "المبيعات" & "=" & sum1 & Environment.NewLine & "الباركود" & "=" & sum2 & Environment.NewLine & "سلع الوقت" & "=" & sum3 & Environment.NewLine & "الاسترجاع" & "=" & sum4 & Environment.NewLine & "خصم المبيعات" & "=" & sum5 & Environment.NewLine & "خصم الباركود" & "=" & sum6 & Environment.NewLine & "الحجوزات" & "=" & sum7
                Try
                    '+========MAILING================
                    Me.PictureBox1.Visible = True
                    Dim MyMailMessage As New MailMessage With {
                        .From = New MailAddress(SEN8) 'username
                        }
                    MyMailMessage.To.Add(SEN8) 'username
                    MyMailMessage.Subject = "--تقرير مبيعات النظام-- "
                    MyMailMessage.SubjectEncoding = System.Text.Encoding.UTF8
                    MyMailMessage.Body = GOM
                    MyMailMessage.BodyEncoding = System.Text.Encoding.UTF8
                    MyMailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    Dim SMTPServer As New SmtpClient("smtp.gmail.com") With {
                        .Port = 587,
                        .Host = "smtp.gmail.com",
<<<<<<< HEAD
                        .Credentials = New NetworkCredential(SEN6, SEN7),
=======
                        .Credentials = New System.Net.NetworkCredential(SEN6, SEN7),
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        .EnableSsl = True
                    }
                    SMTPServer.Send(MyMailMessage)
                    SMTPServer.EnableSsl = True
                    SMTPServer.SendAsync(MyMailMessage, Nothing)
                Catch ex As Exception
                    Timer_sendmail2.Stop()
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
                    Exit Sub
                End Try
            ElseIf ds1.Tables(0).Rows.Count = 0 Then
                Timer_sendmail2.Stop()
                Try
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    Insert_Actions(TEXTInvoiceNumber.Text.Trim, TextMovementSymbol.Text.Trim & "-" & " لم يتمكن النظام من ارسال تقارير للبريد لعدم تفعيل الصلاحية", Me.Text)
                    Consum.Close()
                Catch ex As Exception
                    Timer_sendmail2.Stop()
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
                MsgBox("لم يتمكن النظام من ارسال تقارير للبريد لعدم تفعيل الصلاحية", MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
            Try
                Try
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    Insert_Actions(TEXTInvoiceNumber.Text.Trim, TextMovementSymbol.Text.Trim & "-" & "  عملية إرسال تقارير إلى الجوال والايميل", Me.Text)
                    Consum.Close()
                Catch ex As Exception
                    Timer_sendmail2.Stop()
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
            Catch EX As Exception
                Timer_sendmail2.Stop()
                MsgBox(EX.Message, MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub SaveStocks()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            GetAutoIDSTK()
            ItemBalance = Convert.ToDouble(Me.Datab.Item("Co4", Me.Datab.CurrentRow.Index).Value)
            PreviousBalance = SumAmounTOTALSTOCKS(Tax2.ToString.Trim, IDSTK)
            CurrentBalance = SumAmounTOTALSTOCKS(Tax2.ToString.Trim, IDSTK) - Convert.ToDouble(ItemBalance)
            UnitPriceA = Convert.ToDouble(Me.TextPurchasingPrice.Text) * Convert.ToDouble(CurrentBalance)
            SellingPrice = Convert.ToDouble(Me.Datab.Item("Co4", Me.Datab.CurrentRow.Index).Value) * Convert.ToDouble(CurrentBalance)

            Dim SQL As String = "INSERT INTO STOCKS(  STK1, WarehouseNumber, WarehouseName,  STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, USERNAME, CUser, COUser, da, ne, IT_DATEP, IT_DATEEX) VALUES     (@STK1, @WarehouseNumber, @WarehouseName, @STK3, @STK4, @STK5, @STK6, @STK7, @STK8, @STK9, @STK10, @STK11, @STK12, @STK13, @STK14, @STK15, @STK16, @STK17, @STK18, @STK19, @STK20, @STK21, @STK22, @STK23, @STK25, @STK24, @STK26, @USERNAME, @CUser, @COUser, @da, @ne, @IT_DATEP, @IT_DATEEX)"
            Dim CMD As New SqlCommand(SQL, Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            GetAutoIDSTK()
            Dim SQL As String = "INSERT INTO STOCKS(  STK1, WarehouseNumber, WarehouseName,  STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, USERNAME, CUser, COUser, da, ne, IT_DATEP, IT_DATEEX) VALUES     (@STK1, @WarehouseNumber, @WarehouseName, @STK3, @STK4, @STK5, @STK6, @STK7, @STK8, @STK9, @STK10, @STK11, @STK12, @STK13, @STK14, @STK15, @STK16, @STK17, @STK18, @STK19, @STK20, @STK21, @STK22, @STK23, @STK25, @STK24, @STK26, @USERNAME, @CUser, @COUser, @da, @ne, @IT_DATEP, @IT_DATEEX)"
            Dim CMD As New SqlClient.SqlCommand(SQL, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            CMD.Parameters.AddWithValue("@STK1", IDSTK)
            CMD.Parameters.AddWithValue("@WarehouseNumber", ComboStore.Text)
            CMD.Parameters.AddWithValue("@WarehouseName", TextWarehouseName.Text)
            CMD.Parameters.AddWithValue("@STK3", TextPermissionNumber.Text)
            CMD.Parameters.AddWithValue("@STK4", MaxDate.ToString("yyyy-MM-dd"))
            CMD.Parameters.AddWithValue("@STK5", "صرف")
            CMD.Parameters.AddWithValue("@STK6", TEXTInvoiceNumber.Text)
            CMD.Parameters.AddWithValue("@STK7", Datab.Item("Co0", Datab.CurrentRow.Index).Value)
            CMD.Parameters.AddWithValue("@STK8", TextSTK8.Text)
            CMD.Parameters.AddWithValue("@STK9", TextHashUnit.Text)
<<<<<<< HEAD
            CMD.Parameters.AddWithValue("@STK10", PreviousBalance)
            CMD.Parameters.AddWithValue("@STK11", 0)
            CMD.Parameters.AddWithValue("@STK12", Datab.Item("Co4", Datab.CurrentRow.Index).Value)
            CMD.Parameters.AddWithValue("@STK13", CurrentBalance)
=======
            CMD.Parameters.AddWithValue("@STK10", Format(Val(SumAmounTOTALSTOCKS(Tax2.ToString.Trim, IDSTK)), "0.000"))
            CMD.Parameters.AddWithValue("@STK11", 0)
            CMD.Parameters.AddWithValue("@STK12", Datab.Item("Co4", Datab.CurrentRow.Index).Value)
            CMD.Parameters.AddWithValue("@STK13", Format(Val(SumAmounTOTALSTOCKS(Tax2.ToString.Trim, IDSTK)), "0.000") - Datab.Item("Co4", Datab.CurrentRow.Index).Value)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            CMD.Parameters.AddWithValue("@STK14", TEXTOrderLimit.Text)
            CMD.Parameters.AddWithValue("@STK15", TextPurchasingPrice.Text)
            CMD.Parameters.AddWithValue("@STK16", TextMovementSymbol.Text)
            CMD.Parameters.AddWithValue("@STK17", Discount)
            CMD.Parameters.AddWithValue("@STK18", Format(Val(Me.TextPurchasingPrice.Text) * Val(Datab.Item("Co4", Datab.CurrentRow.Index).Value) * (100 - Val(Datab.Item("Co6", Datab.CurrentRow.Index).Value)) / 100, "0.000"))
            CMD.Parameters.AddWithValue("@STK19", TexTSellingPrice.Text)
            CMD.Parameters.AddWithValue("@STK20", Format(Val(Me.TexTSellingPrice.Text) * Val(Datab.Item("Co4", Datab.CurrentRow.Index).Value) * (100 - Val(TextDiscountPercentageWhenSelling.Text)) / 100, "0.000"))
            CMD.Parameters.AddWithValue("@STK21", TextDiscountPercentageWhenSelling.Text)
            CMD.Parameters.AddWithValue("@STK22", TextLowestDiscountRateWhenSelling.Text)
            CMD.Parameters.AddWithValue("@STK23", TextHighestDiscountRateWhenSelling.Text)
            CMD.Parameters.AddWithValue("@STK25", Tax2.ToString.Trim)
            CMD.Parameters.AddWithValue("@STK24", Convert.ToInt32(CheckBox6.Checked).ToString)
            CMD.Parameters.AddWithValue("@STK26", Convert.ToInt32(CheckBox4.Checked).ToString)
            CMD.Parameters.AddWithValue("@USERNAME", USERNAME)
            CMD.Parameters.AddWithValue("@CUser", CUser)
            CMD.Parameters.AddWithValue("@COUser", COUser)
            CMD.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
            CMD.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
            CMD.Parameters.AddWithValue("@IT_DATEP", TEXT15.Text.Trim)
            CMD.Parameters.AddWithValue("@IT_DATEEX", TEXT16.Text.Trim)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSaveStocks", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

<<<<<<< HEAD

    Private Sub SEARCHDATAITEMS()
        Try
            Dim Consum As New SqlConnection(constring)
            If FIFO = True Then
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Dim cmdDX As New SqlCommand("SELECT * FROM FIFOStocks WHERE STK25='" & Datab.Item(0, Datab.CurrentRow.Index).Value & "'", Consum)
=======
    Private Sub SEARCHDATAITEMS()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If FIFO = True Then
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Dim cmdDX As New SqlClient.SqlCommand("SELECT * FROM FIFOStocks WHERE STK25='" & Datab.Item(0, Datab.CurrentRow.Index).Value & "'", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Dim drDX As SqlDataReader = cmdDX.ExecuteReader
                If drDX.Read = True Then
                    TextSTK8.Text = drDX.Item("STK8")
                    Tax2 = drDX.Item("STK25")
                    TextHashUnit.Text = drDX.Item("SKITM6")
                    TextPurchasingPrice.Text = drDX.Item("STK15")
                    TEXTMeasruingUnit.Text = drDX.Item("SKITM9")
                    TexTSellingPrice.Text = drDX.Item("STK19")
                    Discount = drDX.Item("SKITM9")

                    TextDiscountPercentageWhenSelling.Text = drDX.Item("SKITM15")
                    TextLowestDiscountRateWhenSelling.Text = drDX.Item("SKITM16")
                    TextHighestDiscountRateWhenSelling.Text = drDX.Item("SKITM17")
                    Tax = drDX.Item("SKITM20")
                    Tax1 = drDX.Item("SKITM21")
                    ChkPD = drDX.Item("ChkPD")
                    TEXT15.Text = drDX.Item("IT_DATEP")
                    TEXT16.Text = drDX.Item("IT_DATEEX")
                    CheckBox6.Checked = Tax.ToString
                    CheckBox4.Checked = Tax1.ToString
                    Consum.Close()
                    cmdDX.Dispose()
                End If

            End If
            If LIFO = True Then
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
<<<<<<< HEAD
                Dim cmdDX As New SqlCommand("SELECT * FROM LIFOStock WHERE STK25='" & Datab.Item(0, Datab.CurrentRow.Index).Value & "'", Consum)
=======
                Dim cmdDX As New SqlClient.SqlCommand("SELECT * FROM LIFOStock WHERE STK25='" & Datab.Item(0, Datab.CurrentRow.Index).Value & "'", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Dim drDX As SqlDataReader = cmdDX.ExecuteReader
                If drDX.Read = True Then
                    TextSTK8.Text = drDX.Item("STK8")
                    Tax2 = drDX.Item("STK25")
                    TextHashUnit.Text = drDX.Item("SKITM6")
                    TextPurchasingPrice.Text = drDX.Item("STK15")
                    TEXTMeasruingUnit.Text = drDX.Item("SKITM9")
                    TexTSellingPrice.Text = drDX.Item("STK19")
                    Discount = drDX.Item("SKITM9")
                    TextDiscountPercentageWhenSelling.Text = drDX.Item("SKITM15")
                    TextLowestDiscountRateWhenSelling.Text = drDX.Item("SKITM16")
                    TextHighestDiscountRateWhenSelling.Text = drDX.Item("SKITM17")
                    Tax = drDX.Item("SKITM20")
                    Tax1 = drDX.Item("SKITM21")
                    ChkPD = drDX.Item("ChkPD")
                    TEXT15.Text = drDX.Item("IT_DATEP")
                    TEXT16.Text = drDX.Item("IT_DATEEX")
                    CheckBox6.Checked = Tax.ToString
                    CheckBox4.Checked = Tax1.ToString
                    Consum.Close()
                    cmdDX.Dispose()
                End If
            End If
            If AVG = True Then
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
<<<<<<< HEAD
                Dim cmdDX As New SqlCommand("SELECT * FROM AvgStocks WHERE STK25='" & Datab.Item(0, Datab.CurrentRow.Index).Value & "'", Consum)
=======
                Dim cmdDX As New SqlClient.SqlCommand("SELECT * FROM AvgStocks WHERE STK25='" & Datab.Item(0, Datab.CurrentRow.Index).Value & "'", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Dim drDX As SqlDataReader = cmdDX.ExecuteReader
                If drDX.Read = True Then
                    TextSTK8.Text = drDX.Item("STK8")
                    Tax2 = drDX.Item("STK25")
                    TextHashUnit.Text = drDX.Item("SKITM6")
                    TextPurchasingPrice.Text = drDX.Item("STK15")
                    TEXTMeasruingUnit.Text = drDX.Item("SKITM9")
                    TexTSellingPrice.Text = drDX.Item("STK19")
                    Discount = drDX.Item("SKITM9")
                    TextDiscountPercentageWhenSelling.Text = drDX.Item("SKITM15")
                    TextLowestDiscountRateWhenSelling.Text = drDX.Item("SKITM16")
                    TextHighestDiscountRateWhenSelling.Text = drDX.Item("SKITM17")
                    Tax = drDX.Item("SKITM20")
                    Tax1 = drDX.Item("SKITM21")
                    ChkPD = drDX.Item("ChkPD")
                    TEXT15.Text = drDX.Item("IT_DATEP")
                    TEXT16.Text = drDX.Item("IT_DATEEX")
                    CheckBox6.Checked = Tax.ToString
                    CheckBox4.Checked = Tax1.ToString
                    Consum.Close()
                    cmdDX.Dispose()
                End If
            End If
            SEARCHBALANCEITEMS()
            Textadd.Text = "1"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub Dgv2()
        On Error Resume Next
        DataGridView2.Columns(0).Visible = False
        DataGridView2.Columns(1).Visible = True
        DataGridView2.Columns("STK4").Visible = False
        DataGridView2.Columns(3).Visible = False
        DataGridView2.Columns(4).Visible = False
        DataGridView2.Columns(5).Visible = False
        DataGridView2.Columns(6).Visible = False
        DataGridView2.Columns(7).Visible = False
        DataGridView2.Columns(8).Visible = True
        DataGridView2.Columns(9).Visible = False
        DataGridView2.Columns(10).Visible = False
        DataGridView2.Columns(11).Visible = False
        DataGridView2.Columns(12).Visible = False
        DataGridView2.Columns(13).Visible = False
        DataGridView2.Columns(14).Visible = False
        DataGridView2.Columns(15).Visible = False
        DataGridView2.Columns(16).Visible = False
        DataGridView2.Columns(19).Visible = False

        DataGridView2.Columns("SKITM14").Visible = False
        DataGridView2.Columns("SKITM15").Visible = False
        DataGridView2.Columns("SKITM16").Visible = False
        DataGridView2.Columns("SKITM17").Visible = False
        DataGridView2.Columns("SKITM18").Visible = False
        DataGridView2.Columns("SKITM19").Visible = False
        DataGridView2.Columns("SKITM20").Visible = False
        DataGridView2.Columns("SKITM21").Visible = False
        DataGridView2.Columns("SKITM22").Visible = False
        DataGridView2.Columns("SKITM23").Visible = False

        DataGridView2.Columns("WarehouseNumber").Visible = False
        DataGridView2.Columns("WarehouseName").Visible = False
        DataGridView2.Columns("ChkPD").Visible = False
        DataGridView2.Columns("IT_DATEP").Visible = False
        DataGridView2.Columns("IT_DATEEX").Visible = False
        DataGridView2.Columns("value").Visible = False
        DataGridView2.Columns("value1").Visible = False
        DataGridView2.Columns("value2").Visible = False
        DataGridView2.Columns("SoldUpToNow").Visible = False
        DataGridView2.Columns("TotalProduced").Visible = False
        DataGridView2.Columns("LeftQty").Visible = True
        DataGridView2.Columns("USERNAME").Visible = False
        DataGridView2.Columns("CUser").Visible = False
        DataGridView2.Columns("COUser").Visible = False

        DataGridView2.Columns(1).Width = 310
        DataGridView2.Columns(8).Width = 100
        DataGridView2.Columns("LeftQty").Width = 60
        ''''''''''''''''''''''''''''''''''''''''''''''''
        DataGridView2.Columns(1).HeaderText = "أسم الصنف"
        DataGridView2.Columns(8).HeaderText = "السعر"
        DataGridView2.Columns("LeftQty").HeaderText = "الرصيد"

        ''''
        DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.MultiSelect = False
        With Me.DataGridView2
            .RowsDefaultCellStyle.BackColor = Color.Beige
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
        End With
        ''''''''''''''''''''
    End Sub

<<<<<<< HEAD
    Private Sub TextBarCode_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBarCode.KeyPress
=======
    Private Sub TextBarCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBarCode.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Char.IsControl(e.KeyChar) = False Then
            If Char.IsDigit(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If

        If Asc(e.KeyChar) = Keys.Enter Then
            Me.Textadd.Focus()
            Me.Textadd.Text = 1
            Me.Textadd.SelectAll()
            If Me.CheckBoxquickSale.Checked = True Then
                Me.Buadd_Click(sender, e)
            End If
        End If

        'If Asc(e.KeyChar) = Keys.Enter Then

        'End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBarCode_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextBarCode.TextChanged
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub TextBarCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBarCode.TextChanged
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim Total As Double
        If Trim(Me.TextBarCode.Text) <> "" Then
            If FIFO = True Then
                List0.Items.Clear()
                Dim ds As DataSet
                ds = New DataSet
<<<<<<< HEAD
                Dim strSQL As New SqlCommand("", Consum)
=======
                Dim strSQL As New SqlClient.SqlCommand("", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                With strSQL
                    If Trim(Me.TextBarCode.Text) = "*" Then
                        .CommandText = "select * from FIFOStocks  WHERE   CUser='" & CUser & "' and WarehouseNumber ='" & Trim(Me.ComboStore.Text) & "'"
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                    Else
                        .CommandText = "SELECT * FROM FIFOStocks WHERE CUser ='" & CUser & "' and WarehouseNumber ='" & Trim(Me.ComboStore.Text) & "' and STK25 like'" & Trim(Me.TextBarCode.Text) & "%'" & "or STK7 like'" & Trim(Me.TextBarCode.Text) & "%'"
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                    End If

                End With
                Dim builder63 As New SqlCommandBuilder(adp)
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
<<<<<<< HEAD
                adp = New SqlDataAdapter(strSQL)
                Dim oCommandBuilder As New SqlCommandBuilder(adp)
=======
                adp = New SqlClient.SqlDataAdapter(strSQL)
                Dim oCommandBuilder As New SqlClient.SqlCommandBuilder(adp)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                adp.Fill(ds, "FIFOStocks")
                If Me.BindingContext(ds, "FIFOStocks").Count > 0 Then
                    Me.DataGridView2.DataSource = ds
                    Me.DataGridView2.DataMember = "FIFOStocks"
                    cod1 = ""
                    num = ""
                Else
                    MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
                    Exit Sub
                End If
                For I As Integer = 0 To ds.Tables("FIFOStocks").Rows.Count - 1
                    cod1 = ds.Tables("FIFOStocks").Rows(I).Item("STK25")
                    num = ds.Tables(0).Rows(0).Item(1)
                    Me.List0.Items.Add(ds.Tables("FIFOStocks").Rows(I).Item("STK7"))
                Next
                If ds.Tables(0).Rows.Count > 0 Then
                    cod1 = ds.Tables(0).Rows(0).Item("STK25")

                    For i As Integer = 0 To Datab.Rows.Count - 1
                        If Me.Datab.Rows(i).Cells(0).Value = cod1.ToString.Trim Then
                            Total += Val(Me.Datab.Rows(i).Cells(2).Value)
                        End If
                    Next
                Else
                    cod1 = ""
                    num = ""
                End If
                Me.TextBarCode.Focus()
                Call Dgv2()
            End If
            If LIFO = True Then
                Me.List0.Items.Clear()
                Dim ds As DataSet
                ds = New DataSet
<<<<<<< HEAD
                Dim strSQL As New SqlCommand("", Consum)
=======
                Dim strSQL As New SqlClient.SqlCommand("", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                With strSQL
                    If Trim(TextBarCode.Text) = "*" Then
                        .CommandText = "select * from LIFOStock1  WHERE   CUser='" & CUser & "' and WarehouseNumber ='" & Trim(Me.ComboStore.Text) & "'"
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                    Else
                        .CommandText = "SELECT * FROM LIFOStock1 WHERE CUser ='" & CUser & "' and WarehouseNumber ='" & Trim(Me.ComboStore.Text) & "' and STK25 like'" & Trim(Me.TextBarCode.Text) & "%'" & "or STK7 like'" & Trim(Me.TextBarCode.Text) & "%'"
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                    End If
                End With
                Dim builder63 As New SqlCommandBuilder(adp)
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
<<<<<<< HEAD
                adp = New SqlDataAdapter(strSQL)
                Dim oCommandBuilder As New SqlCommandBuilder(adp)
=======
                adp = New SqlClient.SqlDataAdapter(strSQL)
                Dim oCommandBuilder As New SqlClient.SqlCommandBuilder(adp)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                adp.Fill(ds, "LIFOStock1")
                If Me.BindingContext(ds, "LIFOStock1").Count > 0 Then
                    Me.DataGridView2.DataSource = ds
                    Me.DataGridView2.DataMember = "LIFOStock1"
                Else
                    MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
                    Exit Sub
                End If
                For I As Integer = 0 To ds.Tables("LIFOStock1").Rows.Count - 1
                    cod1 = ds.Tables("LIFOStock1").Rows(I).Item("STK25")
                    num = ds.Tables(0).Rows(0).Item(1)
                    Me.List0.Items.Add(ds.Tables("LIFOStock1").Rows(I).Item("STK7"))
                Next
                If ds.Tables(0).Rows.Count > 0 Then
                    cod1 = ds.Tables(0).Rows(0).Item("STK25")
                    For i As Integer = 0 To Me.Datab.Rows.Count - 1
                        If Me.Datab.Rows(i).Cells(0).Value = cod1.ToString.Trim Then
                            Total += Val(Me.Datab.Rows(i).Cells(2).Value)
                        End If
                    Next
                Else
                    cod1 = ""
                    num = ""
                End If
                Me.TextBarCode.Focus()
                Call Dgv2()
            End If
            If AVG = True Then
                Me.List0.Items.Clear()
                Dim ds As DataSet
                ds = New DataSet
<<<<<<< HEAD
                Dim strSQL As New SqlCommand("", Consum)
=======
                Dim strSQL As New SqlClient.SqlCommand("", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                With strSQL
                    If Trim(TextBarCode.Text) = "*" Then
                        .CommandText = "select * from AvgStocks  WHERE   CUser='" & CUser & "' and WarehouseNumber ='" & Trim(Me.ComboStore.Text) & "'"
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                    Else
                        .CommandText = "SELECT * FROM AvgStocks WHERE CUser ='" & CUser & "' and WarehouseNumber ='" & Trim(Me.ComboStore.Text) & "' and STK25 like'" & Trim(Me.TextBarCode.Text) & "%'" & "or STK7 like'" & Trim(Me.TextBarCode.Text) & "%'"
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                    End If
                End With
                Dim builder63 As New SqlCommandBuilder(adp)
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
<<<<<<< HEAD
                adp = New SqlDataAdapter(strSQL)
                Dim oCommandBuilder As New SqlCommandBuilder(adp)
=======
                adp = New SqlClient.SqlDataAdapter(strSQL)
                Dim oCommandBuilder As New SqlClient.SqlCommandBuilder(adp)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                adp.Fill(ds, "AvgStocks")
                If Me.BindingContext(ds, "AvgStocks").Count > 0 Then
                    Me.DataGridView2.DataSource = ds
                    Me.DataGridView2.DataMember = "AvgStocks"
                Else
                    MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
                    Exit Sub
                End If
                For I As Integer = 0 To ds.Tables("AvgStocks").Rows.Count - 1
                    cod1 = ds.Tables("AvgStocks").Rows(I).Item("STK25")
                    num = ds.Tables(0).Rows(0).Item(1)
                    Me.List0.Items.Add(ds.Tables("AvgStocks").Rows(I).Item("STK7"))
                Next
                If ds.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To Me.Datab.Rows.Count - 1
                        If Me.Datab.Rows(i).Cells(0).Value = cod1.ToString.Trim Then
                            Total += Val(Me.Datab.Rows(i).Cells(2).Value)
                        End If
                    Next
                Else
                    cod1 = ""
                    num = ""
                End If
                Me.TextBarCode.Focus()
                Call Dgv2()
            End If
            Consum.Close()
        End If
        Me.TextNetItemsAvailableSale.Text = ""
        Me.TextNetItemsAfterSale.Text = ""
        Me.TextNetItemsA.Text = ""
        Me.TextItemBalanceAfterSale.Text = ""
        Me.TextItemBalanceAfterSaleA.Text = ""
        Me.TextNetItemsSale.Text = ""
        Me.TextItemBalanceA.Text = ""

        Me.List0_SelectedIndexChanged(sender, e)
        Me.SEARCHBALANCEITEMS()
        Me.GetGrdQuantities()
        Me.Textadd.Text = "1"
        Me.TextItemBalance.Text = Format(Val(Me.TextItemBalance.Text) - Val(Me.TextTot.Text), "0.000")
        If Me.DataGridView2.Item(Me.DataGridView2.CurrentCell.ColumnIndex, Me.DataGridView2.CurrentRow.Index).EditedFormattedValue <> Nothing Then
            Dim v As Integer = Me.DataGridView2.Item(0, Me.DataGridView2.CurrentRow.Index).EditedFormattedValue
            For Each row As DataGridViewRow In DataGridView2.Rows
                If row.Cells(Me.DataGridView2.CurrentCell.ColumnIndex).RowIndex <> Me.DataGridView2.CurrentRow.Index Then
                    If row.Cells(0).Value <> v Then
                        Me.TextNetItems.Text = Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value()) - Val(Total)
                        Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value() = Val(Me.TextNetItems.Text) '
                    Else
                        If Me.TextNetItems.Text > 0 Then
                            Me.TextNetItems.Text = Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value()) - Val(Total)
                            Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value() = Val(Me.TextNetItems.Text) '
                        ElseIf Me.TextNetItems.Text <= 0 Then
                            Dim counter As Integer = Me.DataGridView2.CurrentRow.Index + 1
                            Dim nextRow As DataGridViewRow
                            If counter = Me.DataGridView2.RowCount Then
                                nextRow = Me.DataGridView2.Rows(0)
                            Else
                                nextRow = Me.DataGridView2.Rows(counter)
                                nextRow.Selected = True
                                Me.TextNetItemsSale.Text = Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value()) + Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index + 1).Value() - Val(Total)
                                Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index + 1).Value() = Val(Me.TextNetItemsSale.Text)
                                Me.TextNetItems.Text = 0
                                If Me.DataGridView2.SelectedRows.Count > 0 Then
                                    For i As Integer = Me.DataGridView2.SelectedRows.Count - 1 To 0
                                        Me.DataGridView2.Rows.RemoveAt(Me.DataGridView2.SelectedRows(i).Index - 1)
                                    Next
                                End If
                                If Me.TextNetItemsSale.Text <= 0 Then
                                    nextRow = Me.DataGridView2.Rows(counter)
                                    nextRow.Selected = True
                                    Me.TextNetItemsSale.Text = 0
                                    Me.TextItemBalanceA.Text = Val(Me.TextItemBalance.Text)
                                    Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index + 1).Value() = Val(Me.TextItemBalanceA.Text)
                                End If
                                Me.DataGridView2.CurrentCell = nextRow.Cells(1)
                                nextRow.Selected = True
                                Me.DataGridView2.Rows(counter).Selected = True
                            End If
                        End If
                    End If


                    Return
                End If
            Next
        End If
    End Sub
<<<<<<< HEAD
    Function GetGrdQuantities() As Double
=======
    Function GetGrdQuantities()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim Tot As Double

        For Each row As DataGridViewRow In Me.Datab.Rows
            If row.Cells(0).Value = cod1.ToString.Trim Then
                Tot += Val(row.Cells(2).Value)
            End If
            Me.TextTot.Text = Tot
        Next
        Return Tot

    End Function
<<<<<<< HEAD

    Private Sub ComboStore_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboStore.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)

        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT WarehouseName  FROM Warehouses WHERE WarehouseNumber ='" & Me.ComboStore.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        'Me.Timer_sendmail.Start()
    End Sub

    Private Sub ComboStore_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboStore.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)

        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT WarehouseName  FROM Warehouses WHERE WarehouseNumber ='" & Me.ComboStore.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextWarehouseName.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextWarehouseName.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

    Private Sub ComboCB1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboCB1.SelectedIndexChanged
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            CB2 = ds.Tables(0).Rows(0).Item(0)
        Else
            CB2 = ""
        End If
        Adp.Dispose()
        Consum.Close()
        LabelFundBalance.Text = "رصيد" & " " & CB2 & " " & ":"
        FundBalance()
    End Sub
    Private Sub FundBalance()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub


<<<<<<< HEAD
    Private Sub Cheprint_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles Cheprint.CheckedChanged
=======
    Private Sub Cheprint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cheprint.CheckedChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        'Me.Timer_send.Start()
        'Me.Timer_send2.Start()
        'Me.Timer_sendmail.Start()
        'Me.Timer_sendmail2.Start()
    End Sub

End Class