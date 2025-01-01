

Imports DevExpress.XtraCharts

Public Class FormChart1
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    ReadOnly dt As New DataTable

    Private Sub FormChart1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboAccountLevel.SelectedIndex = 0

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

    Private Sub ComboAccountLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboAccountLevel.SelectedIndexChanged

        ChartControl1.Series(0).DataSource = GetData()
        ChartControl1.Series(0).ArgumentDataMember = String.Format("account_name", GetType(String))
        ChartControl1.Series(0).ValueDataMembers(0) = "CurrentBalance1"



        'CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
        'CType(ChartControl1.Diagram, XYDiagram).AxisY.Visibility = DevExpress.Utils.DefaultBoolean.False
        'ChartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False

        'ChartControl1.Series(0).ChangeView(ViewType.Line)
        'ChartControl1.Series(0).DataSourceSorted = True

        'Dim seriesView = CType(ChartControl1.Series(0).View, LineSeriesView)
        'seriesView.LastPoint.LabelDisplayMode = SidePointDisplayMode.DiagramEdge
        'seriesView.LastPoint.Label.TextPattern = "{V:f2}"
        'Dim diagram = CType(Me.ChartControl1.Diagram, XYDiagram)
        'diagram.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Continuous
        'diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = False
        'diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = False
        'diagram.AxisX.WholeRange.SideMarginsValue = 0
        'diagram.DependentAxesYRange = DefaultBoolean.True
        'diagram.AxisY.WholeRange.AlwaysShowZeroLevel = False
        'Dim timer As New Timer With {
        '    .Interval = 100
        '}
        'timer.Start()
        'AddHandler timer.Tick, AddressOf Timer_Tick


    End Sub

    Private Sub ChartControl1_BoundDataChanged(sender As Object, e As EventArgs) Handles ChartControl1.BoundDataChanged
        'NewMethod()
        Try
            Dim colorEachView As SeriesViewColorEachSupportBase = TryCast(ChartControl1.Series(0).View, SeriesViewColorEachSupportBase)
            If colorEachView IsNot Nothing AndAlso colorEachView.ColorEach Then
                CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
            ElseIf colorEachView.ColorEach Then
                'CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
            ElseIf colorEachView IsNot Nothing Then
                CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
            Else
                Return
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    'Private Sub NewMethod()
    'Dim myView As StockSeriesView = CType(ChartControl1.Series(0).View, StockSeriesView)

    'Select Case ChartControl1.Series(0).View.ToString()
    'If ChartControl1.Series(0).View.ToString(ViewType.Bar) = ChartControl1.Series(0).View.ToString(ViewType.Bar) Then
    '    CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    'ElseIf ChartControl1.Series(0).View.ToString(ViewType.SideBySideStackedBar) = ChartControl1.Series(0).View.ToString(ViewType.SideBySideStackedBar) Then
    '    CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    'ElseIf ChartControl1.Series(0).View.ToString(ViewType.SideBySideFullStackedBar) = ChartControl1.Series(0).View.ToString(ViewType.SideBySideFullStackedBar) Then
    '    CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    'ElseIf ChartControl1.Series(0).View.ToString(ViewType.Waterfall) = ChartControl1.Series(0).View.ToString(ViewType.Waterfall) Then
    '    CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    'ElseIf ChartControl1.Series(0).View.ToString(ViewType.Bar3D) = ChartControl1.Series(0).View.ToString(ViewType.Bar3D) Then
    '    CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    'ElseIf ChartControl1.Series(0).View.ToString(ViewType.StackedBar3D) = ChartControl1.Series(0).View.ToString(ViewType.StackedBar3D) Then
    '    CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    'ElseIf ChartControl1.Series(0).View.ToString(ViewType.FullStackedBar3D) = ChartControl1.Series(0).View.ToString(ViewType.FullStackedBar3D) Then
    '    CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    'ElseIf ChartControl1.Series(0).View.ToString(ViewType.ManhattanBar) = ChartControl1.Series(0).View.ToString(ViewType.ManhattanBar) Then
    '    CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    'ElseIf ChartControl1.Series(0).View.ToString(ViewType.SideBySideStackedBar3D) = ChartControl1.Series(0).View.ToString(ViewType.SideBySideStackedBar3D) Then
    '    CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    'ElseIf ChartControl1.Series(0).View.ToString(ViewType.SideBySideFullStackedBar3D) = ChartControl1.Series(0).View.ToString(ViewType.SideBySideFullStackedBar3D) Then
    '    CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    'End If








    'Case ChartControl1.Series(0).View.ToString(ViewType.Point)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.Bubble)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.Line)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.StackedLine)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.FullStackedLine)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.StepLine)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.Spline)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.ScatterLine)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.Area)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.StepArea)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.SplineArea)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.RangeBar)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.SideBySideRangeBar)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.RangeArea)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.RadarPoint)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.RadarLine)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.ScatterRadarLine)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.RadarArea)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.RadarRangeArea)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.PolarPoint)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.PolarLine)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.ScatterPolarLine)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.PolarArea)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.PolarRangeArea)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.Gantt)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.SideBySideGantt)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True
    '    Case ChartControl1.Series(0).View.ToString(ViewType.BoxPlot)
    '        CType(ChartControl1.Series(0).View, SideBySideBarSeriesView).ColorEach = True

    'End Select
    'End Sub
End Class
