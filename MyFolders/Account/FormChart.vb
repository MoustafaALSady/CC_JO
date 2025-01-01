Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Office.Interop

Public Class FormChart
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Private ReadOnly dataSourceNames As New List(Of String)()
    Private ReadOnly dataSourceImage As New List(Of Bitmap)()
    ReadOnly ToolTipProvider As New ToolTip
    ReadOnly dt As New DataTable
    Private Sub LoadComboChartType()
        ' Get ChartTypes and Images
        Dim resourceStream = GetType(Chart).Assembly.GetManifestResourceStream("System.Windows.Forms.DataVisualization.Charting.Design.resources")
        'Dim resourceStream = System.Enum.GetValues(GetType(DataVisualization.Charting.SeriesChartType))
        Using resReader As New Resources.ResourceReader(CType(resourceStream, IO.Stream))
            Dim dictEnumerator = resReader.GetEnumerator()
            While dictEnumerator.MoveNext()
                Dim ent = dictEnumerator.Entry
                dataSourceNames.Add(ent.Key.ToString())
                dataSourceImage.Add(TryCast(ent.Value, Bitmap))
            End While
        End Using
        ' Load ChartType into ComboBox
        ComboChartType.DataSource = dataSourceNames
        ComboChartType.MaxDropDownItems = 10
        ComboChartType.IntegralHeight = False
        ComboChartType.DrawMode = DrawMode.OwnerDrawFixed
        ComboChartType.DropDownStyle = ComboBoxStyle.DropDownList
        AddHandler ComboChartType.DrawItem, AddressOf ComboChartType_DrawItem
    End Sub

    Private Sub ComboChartType_DrawItem(sender As Object, e As DrawItemEventArgs)
        e.DrawBackground()
        If e.Index >= 0 Then
            ' Get text string
            Dim txt = ComboChartType.GetItemText(ComboChartType.Items(e.Index))
            ' Specify points for drawing
            Dim r1 = New Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1, 2 * (e.Bounds.Height - 2), e.Bounds.Height - 2)
            Dim r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top, e.Bounds.Right, e.Bounds.Bottom)
            ' Draw Image from list
            e.Graphics.DrawImage(dataSourceImage(e.Index), r1)
            e.Graphics.DrawRectangle(Pens.Black, r1)
            TextRenderer.DrawText(e.Graphics, txt, ComboChartType.Font, r2, ComboChartType.ForeColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
        End If
    End Sub

    Private Sub FormChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboAccountLevel.SelectedIndex = 0
        LoadComboChartType()
    End Sub

    Private Sub ComboAccountLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboAccountLevel.SelectedIndexChanged

        Me.Chart1.DataSource = GetData()

        'Chart1.ChartAreas(0).AxisX.Interval = 1
        Chart1.ChartAreas(0).AxisX.LabelStyle.Interval = 1

        Chart1.Series(0).XValueMember = String.Format("account_name", GetType(String))
        Chart1.Series(0).YValueMembers = "CurrentBalance1"
        Chart1.Series(0).IsValueShownAsLabel = True
        Chart1.ChartAreas(0).AxisX.IsMarksNextToAxis = False

    End Sub

    Public Function GetData() As DataTable
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim str2 As New SqlClient.SqlCommand("SELECT  [account_name] , [CurrentBalance1] FROM FINALBALANCE  WHERE CUser='" & ModuleGeneral.CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and [ACC]='" & ComboAccountLevel.Text & "'", Consum)
        SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str2)
        dt.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter1.Fill(dt)
        'If dt.Tables(0).Rows.Count > 0 Then
        Consum.Close()
        Return dt
    End Function


    Private Sub ComboChartType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboChartType.SelectedIndexChanged
        Dim selectedChartType As String = ComboChartType.SelectedItem.ToString()
        Select Case selectedChartType
            Case "AreaChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "SplineArea")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "RadarChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Radar")
                Chart1.Series(0).ChartType = SeriesChartType.Radar
                With Chart1
                    .Series(0)("pieLabelStyle") = "outside"
                    .Series(0).BorderWidth = 1
                    .Series(0).BorderColor = System.Drawing.Color.FromArgb(12, 12, 12)
                    .ChartAreas(0).Area3DStyle.Enable3D = True
                End With


            Case "ErrorBarChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "ErrorBar")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "KagiChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Kagi")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "RangeColumnChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "RangeColumn")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "RangeChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Range")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "StockChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Stock")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "CandlestickChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Candlestick")
            Case "StepLineChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "StepLine")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "ThreeLineBreakChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "ThreeLineBreak")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "PolarChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Polar")
                Chart1.Series(0).ChartType = SeriesChartType.Polar
                With Chart1
                    .Series(0)("pieLabelStyle") = "outside"
                    .Series(0).BorderWidth = 1
                    .Series(0).BorderColor = System.Drawing.Color.FromArgb(12, 12, 12)
                    .ChartAreas(0).Area3DStyle.Enable3D = True
                End With

            Case "PyramidChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Pyramid")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "BarChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Bar")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "LineChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Line")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "BubbleChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Bubble")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "PointAndFigureChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "PointAndFigure")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "SplineChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Spline")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "DoughnutChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Doughnut")
                Chart1.Series(0).ChartType = SeriesChartType.Doughnut
                With Chart1
                    .Series(0)("pieLabelStyle") = "outside"
                    .Series(0).BorderWidth = 1
                    .Series(0).BorderColor = System.Drawing.Color.FromArgb(12, 12, 12)
                    .ChartAreas(0).Area3DStyle.Enable3D = True
                End With
            Case "FastLineChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "FastLine")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "BoxPlotChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "BoxPlot")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "100%StackedColumnChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "StackedColumn100")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "SplineAreaChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "SplineArea")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "SplineRangeChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "SplineRange")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "StackedColumnChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "StackedColumn")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "100%StackedBarChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "StackedBar100")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "PieChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Pie")
                Chart1.Series(0).ChartType = SeriesChartType.Pie
                With Chart1
                    .Series(0)("pieLabelStyle") = "outside"
                    .Series(0).BorderWidth = 1
                    .Series(0).BorderColor = System.Drawing.Color.FromArgb(12, 12, 12)
                    .ChartAreas(0).Area3DStyle.Enable3D = True
                End With
            Case "StackedBarChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "StackedBar")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "StackedAreaChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "StackedArea")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "FastPointChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "FastPoint")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "100%StackedAreaChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "StackedArea100")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "RenkoChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Renko")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "ColumnChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Column")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "RangeBarChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "RangeBar")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "PointChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Point")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Case "FunnelChartType"
                Chart1.Series(0).ChartType = System.Enum.Parse(GetType(SeriesChartType), "Funnel")
                Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
        End Select

    End Sub


    Private Sub Chart1_MouseMove(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles Chart1.MouseMove
        'Dim ca As ChartArea = Chart1.ChartAreas(0)
        'Dim y As Double = ca.AxisY.PixelPositionToValue(e.Y)
        'Dim x As Double = ca.AxisX.PixelPositionToValue(e.X)

        'If y < ca.AxisY.Minimum OrElse y > ca.AxisY.Maximum OrElse x < ca.AxisX.Minimum OrElse x > ca.AxisX.Maximum Then
        '    Return
        'End If
        ''Chart1.Series(0).XValueMember = "account_name"
        ''Chart1.Series(0).YValueMembers = "CurrentBalance1"
        'Dim taX As New TextAnnotation With {
        '    .Name = "account_name",
        '    .Text = x.ToString("0.##"),
        '    .X = ca.AxisX.ValueToPosition(x),
        '    .Y = ca.AxisY.ValueToPosition(y)
        '}

        'Dim taY As New TextAnnotation With {
        '    .Name = "CurrentBalance1",
        '    .Text = y.ToString("0.##"),
        '    .X = ca.AxisX.ValueToPosition(x),
        '    .Y = ca.AxisY.ValueToPosition(y) + 5
        '}

        'Chart1.Annotations.Clear()
        'Chart1.Annotations.Add(taX)
        'Chart1.Annotations.Add(taY)
        'Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = Chart1.HitTest(e.X, e.Y)
        'Dim result As HitTestResult = Chart1.HitTest(e.X, e.Y)
        Dim p As New Point(e.X, e.Y)
        Chart1.ChartAreas(0).CursorX.Interval = 1
        Chart1.ChartAreas(0).CursorX.SetCursorPixelPosition(p, True)
        'Chart1.ChartAreas(0).CursorY.SetCursorPixelPosition(p, True)




    End Sub
    Private Sub Chart1_GetToolTipText(ByVal sender As System.Object, ByVal e As ToolTipEventArgs) Handles Chart1.GetToolTipText
        If e.HitTestResult.PointIndex >= 0 Then
            Select Case e.HitTestResult.ChartElementType
                Case ChartElementType.DataPoint
                    Dim dataPoint = e.HitTestResult.Series.Points(e.HitTestResult.PointIndex)
                    e.Text = String.Format("{0: F1}" & vbTab & ": اسم الحساب" & vbLf & "{1}" & vbTab & ": الرصيد", dataPoint.XValue.ToString, dataPoint.YValues(0))

                    'Label4.Text = Chart1.ChartAreas(0).AxisX.CustomLabels.ToString
            End Select

        End If

    End Sub







    Private Sub Chart1_MouseClick(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles Chart1.MouseClick
        'If e.Button = MouseButtons.Left Then
        '    Dim xValue As Double = Chart1.ChartAreas(0).AxisX.PixelPositionToValue(e.X)
        '    Dim yValue As Double = Chart1.ChartAreas(0).AxisY.PixelPositionToValue(e.Y)

        '    Dim annotation As New TextAnnotation With {
        '        .Text = "Clicked Point",
        '        .X = xValue,
        '        .Y = yValue
        '    }
        '    Chart1.Annotations.Add(annotation)
        'End If
    End Sub


    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    Dim objExcel As New Excel.Application
    '    Dim objWorkbook As Excel.Workbook = objExcel.Workbooks.Add
    '    Dim objWorksheet As Excel.Worksheet
    '    '= CType(objWorkbook.Worksheets.Item(1), Excel.Worksheet)
    '    Dim vialm As Object = System.Reflection.Missing.Value
    '    objWorkbook = objExcel.Workbooks.Add(vialm)
    '    objWorksheet = objWorkbook.Sheets("ورقة1")
    '    For i As Integer = 0 To Me.ComboChartType.Items.Count - 1
    '        For j As Integer = 0 To Me.ComboChartType.Items.Count - 1
    '            objWorksheet.Cells(i + 1, 1).Value = ComboChartType.Items(i).ToString
    '        Next

    '    Next
    '    '‪C:\Users\CC\Desktop\New Microsoft Excel Worksheet.xlsx
    '    objWorkbook.SaveAs("C:\Users\CC\Desktop\path_to_your_excel_file.xlsx")
    '    objWorkbook.Close()
    '    objExcel.Quit()

    'End Sub

    Private Sub Chart1_Customize(sender As Object, e As EventArgs) Handles Chart1.Customize
        'Label4.Text = Chart1.ChartAreas(0).AxisX.CustomLabels.ToString










    End Sub
End Class