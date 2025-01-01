<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportTodaySales
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SelectQuery1 As DevExpress.DataAccess.Sql.SelectQuery = New DevExpress.DataAccess.Sql.SelectQuery()
        Dim Column1 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression1 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Table1 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim Column2 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression2 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column3 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression3 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column4 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression4 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column5 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression5 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column6 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression6 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim IDNumber As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression7 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column8 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression8 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column9 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression9 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column10 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression10 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column11 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression11 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column12 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression12 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column13 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression13 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column14 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression14 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column15 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression15 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column16 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression16 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column17 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression17 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportTodaySales))
        Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrGroupSortingSummary1 As DevExpress.XtraReports.UI.XRGroupSortingSummary = New DevExpress.XtraReports.UI.XRGroupSortingSummary()
        Dim DynamicListLookUpSettings1 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Me.SqlDataSource1 = New DevExpress.DataAccess.Sql.SqlDataSource(Me.components)
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.LblAsUser = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.Lbldaet = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LblInvoiceNumber = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LblUser = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CelltemCount = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CellDiscount = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CellTotal = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CelltpaidUp = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CellRest = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CellTotalPrice = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.DetailReport = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.Detail1 = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable4 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow11 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell25 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CellTS1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CellTS2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CellTS3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CellTS4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CellTS5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow10 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell20 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell21 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell22 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell23 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell24 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.DataSet1 = New System.Data.DataSet()
        Me.ParameterTS9 = New DevExpress.XtraReports.Parameters.Parameter()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionName = "CC_JO.My.MySettings.CC_JOConnectionString"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        ColumnExpression1.ColumnName = "ID"
        Table1.MetaSerializable = "<Meta X=""30"" Y=""30"" Width=""125"" Height=""724"" />"
        Table1.Name = "TodaySales"
        ColumnExpression1.Table = Table1
        Column1.Expression = ColumnExpression1
        ColumnExpression2.ColumnName = "DataTS"
        ColumnExpression2.Table = Table1
        Column2.Expression = ColumnExpression2
        ColumnExpression3.ColumnName = "TS1"
        ColumnExpression3.Table = Table1
        Column3.Expression = ColumnExpression3
        ColumnExpression4.ColumnName = "TS2"
        ColumnExpression4.Table = Table1
        Column4.Expression = ColumnExpression4
        ColumnExpression5.ColumnName = "TS4"
        ColumnExpression5.Table = Table1
        Column5.Expression = ColumnExpression5
        ColumnExpression6.ColumnName = "TS5"
        ColumnExpression6.Table = Table1
        Column6.Expression = ColumnExpression6
        ColumnExpression7.ColumnName = "TS6"
        ColumnExpression7.Table = Table1
        IDNumber.Expression = ColumnExpression7
        ColumnExpression8.ColumnName = "TS7"
        ColumnExpression8.Table = Table1
        Column8.Expression = ColumnExpression8
        ColumnExpression9.ColumnName = "TS8"
        ColumnExpression9.Table = Table1
        Column9.Expression = ColumnExpression9
        ColumnExpression10.ColumnName = "TS9"
        ColumnExpression10.Table = Table1
        Column10.Expression = ColumnExpression10
        ColumnExpression11.ColumnName = "TS11"
        ColumnExpression11.Table = Table1
        Column11.Expression = ColumnExpression11
        ColumnExpression12.ColumnName = "TS12"
        ColumnExpression12.Table = Table1
        Column12.Expression = ColumnExpression12
        ColumnExpression13.ColumnName = "USERNAME"
        ColumnExpression13.Table = Table1
        Column13.Expression = ColumnExpression13
        ColumnExpression14.ColumnName = "ne"
        ColumnExpression14.Table = Table1
        Column14.Expression = ColumnExpression14
        ColumnExpression15.ColumnName = "da"
        ColumnExpression15.Table = Table1
        Column15.Expression = ColumnExpression15
        ColumnExpression16.ColumnName = "TS3"
        ColumnExpression16.Table = Table1
        Column16.Expression = ColumnExpression16
        ColumnExpression17.ColumnName = "TS13"
        ColumnExpression17.Table = Table1
        Column17.Expression = ColumnExpression17
        SelectQuery1.Columns.Add(Column1)
        SelectQuery1.Columns.Add(Column2)
        SelectQuery1.Columns.Add(Column3)
        SelectQuery1.Columns.Add(Column4)
        SelectQuery1.Columns.Add(Column5)
        SelectQuery1.Columns.Add(Column6)
        SelectQuery1.Columns.Add(IDNumber)
        SelectQuery1.Columns.Add(Column8)
        SelectQuery1.Columns.Add(Column9)
        SelectQuery1.Columns.Add(Column10)
        SelectQuery1.Columns.Add(Column11)
        SelectQuery1.Columns.Add(Column12)
        SelectQuery1.Columns.Add(Column13)
        SelectQuery1.Columns.Add(Column14)
        SelectQuery1.Columns.Add(Column15)
        SelectQuery1.Columns.Add(Column16)
        SelectQuery1.Columns.Add(Column17)
        SelectQuery1.Name = "TodaySales"
        SelectQuery1.Tables.Add(Table1)
        Me.SqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {SelectQuery1})
        Me.SqlDataSource1.ResultSchemaSerializable = resources.GetString("SqlDataSource1.ResultSchemaSerializable")
        '
        'TopMargin
        '
        Me.TopMargin.Dpi = 254.0!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.Dpi = 254.0!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.BackColor = System.Drawing.Color.White
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LblAsUser})
        Me.Detail.Dpi = 254.0!
        Me.Detail.FillEmptySpace = True
        Me.Detail.HierarchyPrintOptions.Indent = 50.8!
        Me.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown
        Me.Detail.Name = "Detail"
        Me.Detail.StylePriority.UseBackColor = False
        '
        'LblAsUser
        '
        Me.LblAsUser.Dpi = 254.0!
        Me.LblAsUser.ForeColor = System.Drawing.Color.Black
        Me.LblAsUser.Multiline = True
        Me.LblAsUser.Name = "LblAsUser"
        Me.LblAsUser.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.LblAsUser.StylePriority.UseFont = False
        Me.LblAsUser.StylePriority.UseForeColor = False
        Me.LblAsUser.StylePriority.UseTextAlignment = False
        Me.LblAsUser.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLine1
        '
        Me.XrLine1.Dpi = 254.0!
        Me.XrLine1.Name = "XrLine1"
        '
        'XrTable1
        '
        Me.XrTable1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.Dpi = 254.0!
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1, Me.XrTableRow2, Me.XrTableRow3})
        Me.XrTable1.StylePriority.UseBorders = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.Lbldaet})
        Me.XrTableRow1.Dpi = 254.0!
        Me.XrTableRow1.Name = "XrTableRow1"
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Dpi = 254.0!
        Me.XrTableCell1.Multiline = True
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.StylePriority.UseTextAlignment = False
        Me.XrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'Lbldaet
        '
        Me.Lbldaet.Dpi = 254.0!
        Me.Lbldaet.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DataTS]")})
        Me.Lbldaet.Multiline = True
        Me.Lbldaet.Name = "Lbldaet"
        Me.Lbldaet.StylePriority.UseFont = False
        Me.Lbldaet.StylePriority.UseTextAlignment = False
        Me.Lbldaet.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell3, Me.LblInvoiceNumber})
        Me.XrTableRow2.Dpi = 254.0!
        Me.XrTableRow2.Name = "XrTableRow2"
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Dpi = 254.0!
        Me.XrTableCell3.Multiline = True
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StylePriority.UseFont = False
        Me.XrTableCell3.StylePriority.UseTextAlignment = False
        Me.XrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LblInvoiceNumber
        '
        Me.LblInvoiceNumber.Dpi = 254.0!
        Me.LblInvoiceNumber.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TS9]")})
        Me.LblInvoiceNumber.Multiline = True
        Me.LblInvoiceNumber.Name = "LblInvoiceNumber"
        Me.LblInvoiceNumber.StylePriority.UseFont = False
        Me.LblInvoiceNumber.StylePriority.UseTextAlignment = False
        Me.LblInvoiceNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell5, Me.LblUser})
        Me.XrTableRow3.Dpi = 254.0!
        Me.XrTableRow3.Name = "XrTableRow3"
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Dpi = 254.0!
        Me.XrTableCell5.Multiline = True
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.StylePriority.UseFont = False
        Me.XrTableCell5.StylePriority.UseTextAlignment = False
        Me.XrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LblUser
        '
        Me.LblUser.Dpi = 254.0!
        Me.LblUser.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[USERNAME]")})
        Me.LblUser.Multiline = True
        Me.LblUser.Name = "LblUser"
        Me.LblUser.StylePriority.UseFont = False
        Me.LblUser.StylePriority.UseTextAlignment = False
        Me.LblUser.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTable2
        '
        Me.XrTable2.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable2.Dpi = 254.0!
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow4, Me.XrTableRow5, Me.XrTableRow6})
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell7, Me.CelltemCount, Me.XrTableCell2, Me.CellDiscount})
        Me.XrTableRow4.Dpi = 254.0!
        Me.XrTableRow4.Name = "XrTableRow4"
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Dpi = 254.0!
        Me.XrTableCell7.Multiline = True
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.StylePriority.UseFont = False
        Me.XrTableCell7.StylePriority.UseTextAlignment = False
        Me.XrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'CelltemCount
        '
        Me.CelltemCount.Dpi = 254.0!
        Me.CelltemCount.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TS7]")})
        Me.CelltemCount.Multiline = True
        Me.CelltemCount.Name = "CelltemCount"
        Me.CelltemCount.StylePriority.UseFont = False
        Me.CelltemCount.StylePriority.UseTextAlignment = False
        Me.CelltemCount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Dpi = 254.0!
        Me.XrTableCell2.Multiline = True
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.StylePriority.UseFont = False
        Me.XrTableCell2.StylePriority.UseTextAlignment = False
        Me.XrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'CellDiscount
        '
        Me.CellDiscount.Dpi = 254.0!
        Me.CellDiscount.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([TS6])")})
        Me.CellDiscount.Multiline = True
        Me.CellDiscount.Name = "CellDiscount"
        Me.CellDiscount.StylePriority.UseFont = False
        Me.CellDiscount.StylePriority.UseTextAlignment = False
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.CellDiscount.Summary = XrSummary1
        Me.CellDiscount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow5
        '
        Me.XrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell9, Me.CellTotal, Me.XrTableCell4, Me.CelltpaidUp})
        Me.XrTableRow5.Dpi = 254.0!
        Me.XrTableRow5.Name = "XrTableRow5"
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Dpi = 254.0!
        Me.XrTableCell9.Multiline = True
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.StylePriority.UseFont = False
        Me.XrTableCell9.StylePriority.UseTextAlignment = False
        Me.XrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'CellTotal
        '
        Me.CellTotal.Dpi = 254.0!
        Me.CellTotal.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TS12]")})
        Me.CellTotal.Multiline = True
        Me.CellTotal.Name = "CellTotal"
        Me.CellTotal.StylePriority.UseFont = False
        Me.CellTotal.StylePriority.UseTextAlignment = False
        Me.CellTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Dpi = 254.0!
        Me.XrTableCell4.Multiline = True
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.StylePriority.UseFont = False
        Me.XrTableCell4.StylePriority.UseTextAlignment = False
        Me.XrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'CelltpaidUp
        '
        Me.CelltpaidUp.Dpi = 254.0!
        Me.CelltpaidUp.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TS11]")})
        Me.CelltpaidUp.Multiline = True
        Me.CelltpaidUp.Name = "CelltpaidUp"
        Me.CelltpaidUp.StylePriority.UseFont = False
        Me.CelltpaidUp.StylePriority.UseTextAlignment = False
        Me.CelltpaidUp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow6
        '
        Me.XrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell11, Me.CellRest, Me.XrTableCell6, Me.CellTotalPrice})
        Me.XrTableRow6.Dpi = 254.0!
        Me.XrTableRow6.Name = "XrTableRow6"
        Me.XrTableRow6.StylePriority.UseFont = False
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Dpi = 254.0!
        Me.XrTableCell11.Multiline = True
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.StylePriority.UseFont = False
        Me.XrTableCell11.StylePriority.UseTextAlignment = False
        Me.XrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'CellRest
        '
        Me.CellRest.Dpi = 254.0!
        Me.CellRest.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TS13]")})
        Me.CellRest.Multiline = True
        Me.CellRest.Name = "CellRest"
        Me.CellRest.StylePriority.UseFont = False
        Me.CellRest.StylePriority.UseTextAlignment = False
        Me.CellRest.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Dpi = 254.0!
        Me.XrTableCell6.Multiline = True
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.StylePriority.UseFont = False
        Me.XrTableCell6.StylePriority.UseTextAlignment = False
        Me.XrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'CellTotalPrice
        '
        Me.CellTotalPrice.Dpi = 254.0!
        Me.CellTotalPrice.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TS12]")})
        Me.CellTotalPrice.Multiline = True
        Me.CellTotalPrice.Name = "CellTotalPrice"
        Me.CellTotalPrice.StylePriority.UseFont = False
        Me.CellTotalPrice.StylePriority.UseTextAlignment = False
        Me.CellTotalPrice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLine2
        '
        Me.XrLine2.Dpi = 254.0!
        Me.XrLine2.Name = "XrLine2"
        '
        'PageFooter
        '
        Me.PageFooter.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PageFooter.Dpi = 254.0!
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.StylePriority.UseBackColor = False
        '
        'DetailReport
        '
        Me.DetailReport.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail1, Me.GroupHeader1, Me.GroupFooter1})
        Me.DetailReport.DataMember = "TodaySales"
        Me.DetailReport.DataSource = Me.SqlDataSource1
        Me.DetailReport.Dpi = 254.0!
        Me.DetailReport.FilterString = "[TS9] = ?ParameterTS9"
        Me.DetailReport.Level = 0
        Me.DetailReport.Name = "DetailReport"
        '
        'Detail1
        '
        Me.Detail1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable4})
        Me.Detail1.Dpi = 254.0!
        Me.Detail1.HierarchyPrintOptions.Indent = 50.8!
        Me.Detail1.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown
        Me.Detail1.Name = "Detail1"
        Me.Detail1.StylePriority.UseFont = False
        '
        'XrTable4
        '
        Me.XrTable4.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable4.Dpi = 254.0!
        Me.XrTable4.Name = "XrTable4"
        Me.XrTable4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.XrTable4.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow11})
        Me.XrTable4.StylePriority.UseBorders = False
        '
        'XrTableRow11
        '
        Me.XrTableRow11.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell25, Me.CellTS1, Me.CellTS2, Me.CellTS3, Me.CellTS4, Me.CellTS5})
        Me.XrTableRow11.Dpi = 254.0!
        Me.XrTableRow11.Name = "XrTableRow11"
        '
        'XrTableCell25
        '
        Me.XrTableCell25.Dpi = 254.0!
        Me.XrTableCell25.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DataSource.CurrentRowIndex]")})
        Me.XrTableCell25.Multiline = True
        Me.XrTableCell25.Name = "XrTableCell25"
        Me.XrTableCell25.StylePriority.UseFont = False
        '
        'CellTS1
        '
        Me.CellTS1.Dpi = 254.0!
        Me.CellTS1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TS1]")})
        Me.CellTS1.Multiline = True
        Me.CellTS1.Name = "CellTS1"
        Me.CellTS1.StylePriority.UseFont = False
        '
        'CellTS2
        '
        Me.CellTS2.Dpi = 254.0!
        Me.CellTS2.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TS2]")})
        Me.CellTS2.Multiline = True
        Me.CellTS2.Name = "CellTS2"
        Me.CellTS2.StylePriority.UseFont = False
        Me.CellTS2.StylePriority.UseTextAlignment = False
        Me.CellTS2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'CellTS3
        '
        Me.CellTS3.Dpi = 254.0!
        Me.CellTS3.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TS3]")})
        Me.CellTS3.Multiline = True
        Me.CellTS3.Name = "CellTS3"
        Me.CellTS3.StylePriority.UseFont = False
        Me.CellTS3.StylePriority.UseTextAlignment = False
        Me.CellTS3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'CellTS4
        '
        Me.CellTS4.Dpi = 254.0!
        Me.CellTS4.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TS6]")})
        Me.CellTS4.Multiline = True
        Me.CellTS4.Name = "CellTS4"
        Me.CellTS4.StylePriority.UseFont = False
        Me.CellTS4.StylePriority.UseTextAlignment = False
        Me.CellTS4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'CellTS5
        '
        Me.CellTS5.CanShrink = True
        Me.CellTS5.Dpi = 254.0!
        Me.CellTS5.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TS5]")})
        Me.CellTS5.Multiline = True
        Me.CellTS5.Name = "CellTS5"
        Me.CellTS5.StylePriority.UseFont = False
        Me.CellTS5.StylePriority.UseTextAlignment = False
        Me.CellTS5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine3, Me.XrLine1, Me.XrTable3, Me.XrTable1})
        Me.GroupHeader1.Dpi = 254.0!
        Me.GroupHeader1.Level = 1
        Me.GroupHeader1.Name = "GroupHeader1"
        XrGroupSortingSummary1.Enabled = True
        XrGroupSortingSummary1.FieldName = "TS6"
        XrGroupSortingSummary1.IgnoreNullValues = True
        Me.GroupHeader1.SortingSummary = XrGroupSortingSummary1
        '
        'XrLine3
        '
        Me.XrLine3.BackColor = System.Drawing.Color.SteelBlue
        Me.XrLine3.BorderColor = System.Drawing.Color.Black
        Me.XrLine3.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLine3.Dpi = 254.0!
        Me.XrLine3.ForeColor = System.Drawing.Color.White
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.StylePriority.UseBackColor = False
        Me.XrLine3.StylePriority.UseBorderColor = False
        Me.XrLine3.StylePriority.UseBorders = False
        Me.XrLine3.StylePriority.UseForeColor = False
        '
        'XrTable3
        '
        Me.XrTable3.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable3.Dpi = 254.0!
        Me.XrTable3.Name = "XrTable3"
        Me.XrTable3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.XrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow10})
        Me.XrTable3.StylePriority.UseBorders = False
        '
        'XrTableRow10
        '
        Me.XrTableRow10.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell19, Me.XrTableCell20, Me.XrTableCell21, Me.XrTableCell22, Me.XrTableCell23, Me.XrTableCell24})
        Me.XrTableRow10.Dpi = 254.0!
        Me.XrTableRow10.Name = "XrTableRow10"
        '
        'XrTableCell19
        '
        Me.XrTableCell19.Dpi = 254.0!
        Me.XrTableCell19.Multiline = True
        Me.XrTableCell19.Name = "XrTableCell19"
        Me.XrTableCell19.StylePriority.UseFont = False
        '
        'XrTableCell20
        '
        Me.XrTableCell20.Dpi = 254.0!
        Me.XrTableCell20.Multiline = True
        Me.XrTableCell20.Name = "XrTableCell20"
        Me.XrTableCell20.StylePriority.UseFont = False
        '
        'XrTableCell21
        '
        Me.XrTableCell21.Dpi = 254.0!
        Me.XrTableCell21.Multiline = True
        Me.XrTableCell21.Name = "XrTableCell21"
        Me.XrTableCell21.StylePriority.UseFont = False
        Me.XrTableCell21.StylePriority.UseTextAlignment = False
        Me.XrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableCell22
        '
        Me.XrTableCell22.Dpi = 254.0!
        Me.XrTableCell22.Multiline = True
        Me.XrTableCell22.Name = "XrTableCell22"
        Me.XrTableCell22.StylePriority.UseFont = False
        Me.XrTableCell22.StylePriority.UseTextAlignment = False
        Me.XrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrTableCell23
        '
        Me.XrTableCell23.Dpi = 254.0!
        Me.XrTableCell23.Multiline = True
        Me.XrTableCell23.Name = "XrTableCell23"
        Me.XrTableCell23.StylePriority.UseFont = False
        Me.XrTableCell23.StylePriority.UseTextAlignment = False
        Me.XrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrTableCell24
        '
        Me.XrTableCell24.Dpi = 254.0!
        Me.XrTableCell24.Multiline = True
        Me.XrTableCell24.Name = "XrTableCell24"
        Me.XrTableCell24.StylePriority.UseFont = False
        Me.XrTableCell24.StylePriority.UseTextAlignment = False
        Me.XrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine2, Me.XrTable2})
        Me.GroupFooter1.Dpi = 254.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1DataSet"
        '
        'ParameterTS9
        '
        Me.ParameterTS9.Name = "ParameterTS9"
        Me.ParameterTS9.Type = GetType(Long)
        Me.ParameterTS9.ValueInfo = "0"
        DynamicListLookUpSettings1.DataMember = "TodaySales"
        DynamicListLookUpSettings1.DataSource = Me.SqlDataSource1
        DynamicListLookUpSettings1.DisplayMember = Nothing
        DynamicListLookUpSettings1.SortMember = Nothing
        DynamicListLookUpSettings1.ValueMember = "TS9"
        Me.ParameterTS9.ValueSourceSettings = DynamicListLookUpSettings1
        '
        'ReportTodaySales
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.PageFooter, Me.DetailReport})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.SqlDataSource1, Me.DataSet1})
        Me.Dpi = 254.0!
        Me.LocalizationItems.AddRange(New DevExpress.XtraReports.Localization.LocalizationItem() {New DevExpress.XtraReports.Localization.LocalizationItem(Me.BottomMargin, "Default", "HeightF", 50.0!), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellDiscount, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellDiscount, "Default", "Text", "0.000"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellDiscount, "Default", "TextFormatString", "{0:N3}"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellDiscount, "Default", "Weight", 1.6851829912974097R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellRest, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellRest, "Default", "Text", "0.000"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellRest, "Default", "TextFormatString", "{0:N3}"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellRest, "Default", "Weight", 1.2808807736529184R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CelltemCount, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CelltemCount, "Default", "Text", "0.0"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CelltemCount, "Default", "TextFormatString", "{0:N}"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CelltemCount, "Default", "Weight", 1.2808807736529189R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTotal, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTotal, "Default", "Text", "0.000"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTotal, "Default", "TextFormatString", "{0:N3}"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTotal, "Default", "Weight", 1.2808807736529182R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTotalPrice, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTotalPrice, "Default", "Text", "0.000"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTotalPrice, "Default", "TextFormatString", "{0:N3}"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTotalPrice, "Default", "Weight", 1.6858862125344658R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CelltpaidUp, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CelltpaidUp, "Default", "Text", "0.000"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CelltpaidUp, "Default", "TextFormatString", "{0:N3}"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CelltpaidUp, "Default", "Weight", 1.6858862125344658R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS1, "Default", "Font", New System.Drawing.Font("Times New Roman", 8.0!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS1, "Default", "Text", "الصنف"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS1, "Default", "Weight", 1.5190138616007913R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS2, "Default", "Font", New System.Drawing.Font("Arial", 8.0!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS2, "Default", "Text", "0.0"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS2, "Default", "TextFormatString", "{0:N1}"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS2, "Default", "Weight", 0.23059494429274266R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS3, "Default", "Font", New System.Drawing.Font("Times New Roman", 8.0!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS3, "Default", "Text", "0.000"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS3, "Default", "TextFormatString", "{0:N2}"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS3, "Default", "Weight", 0.39948670590921631R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS4, "Default", "Font", New System.Drawing.Font("Times New Roman", 8.0!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS4, "Default", "Text", "0.00"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS4, "Default", "TextFormatString", "{0:N2}"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS4, "Default", "Weight", 0.34284561356005627R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS5, "Default", "Font", New System.Drawing.Font("Times New Roman", 8.0!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS5, "Default", "Text", "0.000"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS5, "Default", "TextFormatString", "{0:N2}"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.CellTS5, "Default", "Weight", 0.47706190122964454R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.Detail, "Default", "HeightF", 53.17198!), New DevExpress.XtraReports.Localization.LocalizationItem(Me.Detail1, "Default", "Font", New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))), New DevExpress.XtraReports.Localization.LocalizationItem(Me.Detail1, "Default", "HeightF", 39.6875!), New DevExpress.XtraReports.Localization.LocalizationItem(Me.GroupFooter1, "Default", "HeightF", 161.9218!), New DevExpress.XtraReports.Localization.LocalizationItem(Me.GroupHeader1, "Default", "HeightF", 231.3906!), New DevExpress.XtraReports.Localization.LocalizationItem(Me.LblAsUser, "Default", "Font", New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.LblAsUser, "Default", "LocationFloat", New DevExpress.Utils.PointFloat(0.0001856089!, 0!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.LblAsUser, "Default", "SizeF", New System.Drawing.SizeF(760.5836!, 53.17198!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.LblAsUser, "Default", "Text", "الجمعية"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.Lbldaet, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.Lbldaet, "Default", "TextFormatString", "{0:yyyy-MM-dd}"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.Lbldaet, "Default", "Weight", 1.8838081186045874R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.LblInvoiceNumber, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.LblInvoiceNumber, "Default", "Text", "0"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.LblInvoiceNumber, "Default", "Weight", 1.8838081186045874R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.LblUser, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.LblUser, "Default", "Text", "........................................"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.LblUser, "Default", "Weight", 1.8838081186045874R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.PageFooter, "Default", "HeightF", 6.942729!), New DevExpress.XtraReports.Localization.LocalizationItem(Me.ParameterTS9, "Default", "Description", "رقم الفاتورة"), New DevExpress.XtraReports.Localization.LocalizationItem(Me, "Default", "Font", New System.Drawing.Font("Times New Roman", 10.0!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me, "ar-JO", "Font", New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))), New DevExpress.XtraReports.Localization.LocalizationItem(Me, "Default", "Margins", New System.Drawing.Printing.Margins(20, 20, 10, 50)), New DevExpress.XtraReports.Localization.LocalizationItem(Me, "Default", "PaperKind", System.Drawing.Printing.PaperKind.Custom), New DevExpress.XtraReports.Localization.LocalizationItem(Me, "Default", "Watermark.Font", New System.Drawing.Font("Verdana", 36.0!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me, "Default", "Watermark.Text", ""), New DevExpress.XtraReports.Localization.LocalizationItem(Me.TopMargin, "Default", "HeightF", 10.0!), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrLine1, "Default", "LocationFloat", New DevExpress.Utils.PointFloat(0.000007629395!, 187.3281!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrLine1, "Default", "SizeF", New System.Drawing.SizeF(761.5417!, 5.291672!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrLine2, "Default", "LocationFloat", New DevExpress.Utils.PointFloat(0!, 9.124928!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrLine2, "Default", "SizeF", New System.Drawing.SizeF(755.3541!, 5.291667!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrLine3, "Default", "LocationFloat", New DevExpress.Utils.PointFloat(0.0002002716!, 156.5157!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrLine3, "Default", "SizeF", New System.Drawing.SizeF(760.6876!, 23.81241!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTable1, "Default", "LocationFloat", New DevExpress.Utils.PointFloat(0!, 0!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTable1, "Default", "SizeF", New System.Drawing.SizeF(760.7919!, 144.9949!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTable2, "Default", "Font", New System.Drawing.Font("Times New Roman", 8.0!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTable2, "Default", "LocationFloat", New DevExpress.Utils.PointFloat(0.00001013279!, 14.41659!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTable2, "Default", "SizeF", New System.Drawing.SizeF(760.1254!, 142.7969!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTable3, "Default", "LocationFloat", New DevExpress.Utils.PointFloat(0!, 192.6198!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTable3, "Default", "SizeF", New System.Drawing.SizeF(760.8959!, 38.77081!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTable4, "Default", "LocationFloat", New DevExpress.Utils.PointFloat(0.00006198883!, 0!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTable4, "Default", "SizeF", New System.Drawing.SizeF(760.8958!, 39.6875!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell1, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell1, "Default", "Text", "التاريخ"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell1, "Default", "Weight", 1.0R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell11, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell11, "Default", "Text", "الباقي"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell11, "Default", "Weight", 1.0R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell19, "Default", "Font", New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell19, "Default", "Text", "م"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell19, "Default", "Weight", 0.20612791575547085R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell2, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell2, "Default", "Text", "الخصم"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell2, "Default", "Weight", 0.899708045772413R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell20, "Default", "Font", New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell20, "Default", "Text", "الصنف"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell20, "Default", "Weight", 1.4987872854320907R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell21, "Default", "Font", New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell21, "Default", "Text", "كمية"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell21, "Default", "Weight", 0.22752462787497527R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell22, "Default", "Font", New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell22, "Default", "Text", "سعر"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell22, "Default", "Weight", 0.39416702598722758R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell23, "Default", "Font", New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell23, "Default", "Text", "خصم"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell23, "Default", "Weight", 0.33334309184916433R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell24, "Default", "Font", New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell24, "Default", "Text", "مجموع"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell24, "Default", "Weight", 0.4760764033931133R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell25, "Default", "Font", New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell25, "Default", "Text", "1"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell25, "Default", "Weight", 0.2093446472893428R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell3, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell3, "Default", "Text", "رقم الفاتورة"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell3, "Default", "Weight", 1.0R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell4, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell4, "Default", "Text", "المدفوع"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell4, "Default", "Weight", 0.89900482453535668R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell5, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell5, "Default", "Text", "المستخدم"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell5, "Default", "Weight", 1.0R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell6, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell6, "Default", "Text", "الاجمالي"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell6, "Default", "Weight", 0.89900482453535668R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell7, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell7, "Default", "Text", "العدد"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell7, "Default", "Weight", 1.0R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell9, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell9, "Default", "Text", "المجموع"), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableCell9, "Default", "Weight", 1.0R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableRow1, "Default", "Weight", 1.0R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableRow10, "Default", "Weight", 1.0R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableRow11, "Default", "Weight", 1.0R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableRow2, "Default", "Weight", 1.0R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableRow3, "Default", "Weight", 1.0R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableRow4, "Default", "Weight", 1.0R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableRow5, "Default", "Weight", 1.0R), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableRow6, "Default", "Font", New System.Drawing.Font("Times New Roman", 9.0!)), New DevExpress.XtraReports.Localization.LocalizationItem(Me.XrTableRow6, "Default", "Weight", 1.0R)})
        Me.PageHeight = 988
        Me.PageWidth = 803
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.ParameterTS9})
        Me.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter
        Me.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes
        Me.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes
        Me.RollPaper = True
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.SnapGridSize = 25.0!
        Me.Version = "20.2"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents LblAsUser As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CelltemCount As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CellTotal As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CellRest As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents DetailReport As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents XrTable4 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow11 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell25 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CellTS1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CellTS2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CellTS3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CellTS4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CellTS5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrTable3 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow10 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell20 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell21 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell22 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell23 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell24 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CellDiscount As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CelltpaidUp As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CellTotalPrice As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents DataSet1 As DataSet
    Private WithEvents Detail1 As DevExpress.XtraReports.UI.DetailBand
    Private WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents ParameterTS9 As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents Lbldaet As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents LblInvoiceNumber As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents LblUser As DevExpress.XtraReports.UI.XRTableCell
End Class
