Imports System.Drawing.Text
Imports System.Drawing.Printing
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Module PrintSettingModule


#Region "Public Prting Variables"
    Public Property XLogBranchLogoPath As String = My.Application.Info.DirectoryPath & "\Branches Logo\" & AssociationName & ".jpg"
    Public Property XPrinterName As String = Nothing
    Public Property XNumOfPrtinedCoppies As Short = 1
    Public Property XPrtinedSample As Short = 1
    Public Property IsPreviewReprot As Boolean = False
    Public Property XPrtintCancelled As Boolean = False
    Public Property XPaperOrientation As Int32 = 0
    Public Property XPaperSize As Int32 = 0
    Public Property XAdjustPageMargin As Boolean = False
    Public Property XRightMargin As Int32 = 0
    Public Property XLeftMargin As Int32 = 0
    Public Property XTopMargin As Int32 = 0
    Public Property XBottonMargin As Int32 = 0
    Public Property XPrinterDuplex As Int32 = 1
    Public Property XPrinterAllRecord As Int32 = 1
    Public Property XNameOfExportedPDF As String = Nothing
    Public Property XExportReportAsPDF As Boolean = False


#End Region

#Region "General Modules Printing"
    Public Sub FillCombByInstalledPrinters(ByVal Comb As ComboBox)
        Comb.Items.Clear()
        For Each InstalledPrinters As String In PrinterSettings.InstalledPrinters
            Comb.Items.Add(InstalledPrinters)
        Next
        If Comb.Items.Count > 0 Then
            If String.IsNullOrEmpty(My.Settings.DefaultPrintrName) = False Then
                Comb.Text = My.Settings.DefaultPrintrName
            Else
                Comb.SelectedIndex = 0
            End If
        End If

    End Sub

    Public Sub FillCombByPagesSiz(ByVal Combo As ComboBox, ByVal SelectedPrinter As String)
        Try
            Combo.DataSource = Nothing
            If String.IsNullOrEmpty(SelectedPrinter) = False Then
                Dim XDoc As New PrintDocument()
                XDoc.PrinterSettings.PrinterName = SelectedPrinter
                Dim dt As New DataTable
                dt.Columns.Add("ID", Type.GetType("System.Int16"))
                dt.Columns.Add("Name", Type.GetType("System.String"))
                For Each xPaperSize As System.Drawing.Printing.PaperSize In xDoc.PrinterSettings.PaperSizes
                    Dim xrow = dt.NewRow
                    xrow("ID") = xPaperSize.RawKind
                    xrow("Name") = xPaperSize.PaperName
                    dt.Rows.Add(xrow)
                Next
                Combo.DataSource = dt
                Combo.DisplayMember = "Name"
                Combo.ValueMember = "ID"
                If Combo.Items.Count > 0 Then Combo.SelectedValue = 9
            Else
                FillCombByPagesSiz(Combo)
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            Return
        End Try
    End Sub
    Public Sub FillComboByPagesize(ByVal Combo As ComboBox, ByVal SelectedPrinter As String)
        Try
            Combo.DataSource = Nothing
            If String.IsNullOrEmpty(SelectedPrinter) = False Then
                Dim xDoc As New PrintDocument()
                xDoc.PrinterSettings.PrinterName = SelectedPrinter
                Dim dt As New DataTable
                dt.Columns.Add("ID", Type.GetType("System.Int16"))
                dt.Columns.Add("Name", Type.GetType("System.String"))
                'xDoc.PrinterSettings.DefaultPageSettings.PaperSize.PaperName = Printing.PaperKind.A5

                For Each xPaperSize As System.Drawing.Printing.PaperSize In xDoc.PrinterSettings.PaperSizes
                    Dim xrow = dt.NewRow
                    xrow("ID") = xPaperSize.RawKind
                    xrow("Name") = xPaperSize.PaperName
                    dt.Rows.Add(xrow)
                Next
                Combo.DataSource = dt
                Combo.DisplayMember = "Name"
                'Combo.ValueMember = "ID"
                'If Combo.Items.Count > 0 Then Combo.SelectedValue = 9
                'MsgBox(1)
            Else
                'MsgBox(2)
                FillCombByPagesSiz(Combo)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return
        End Try

    End Sub

    Public Sub FillCombByPagesSiz(ByVal Comb As ComboBox)

        Dim dt As New DataTable
        dt.Columns.Add("ID", Type.GetType("System.Int16"))
        dt.Columns.Add("Name", Type.GetType("System.String"))
        dt.Rows.Add(0, "DefaultSize")
        dt.Rows.Add(9, "A4")
        dt.Rows.Add(10, "A4Small")
        dt.Rows.Add(8, "A3")
        dt.Rows.Add(11, "A5")
        dt.Rows.Add(1, "Letter")
        dt.Rows.Add(2, "LetterSmall")
        dt.Rows.Add(3, "Tablold")
        dt.Rows.Add(4, "Ledger")
        dt.Rows.Add(5, "Legal")
        dt.Rows.Add(6, "Statement")
        dt.Rows.Add(15, "Quarto")

        Comb.DataSource = dt
        Comb.DisplayMember = "Name"
        Comb.ValueMember = "ID"
        Comb.SelectedIndex = 0

    End Sub

    Public Sub FillCombByFonts(ByVal Comb As ComboBox)
        Comb.Items.Clear()
        Dim InstalledFonts As New InstalledFontCollection
        For Each Font As FontFamily In InstalledFonts.Families
            Comb.Items.Add(Font.Name)
        Next
        If Comb.Items.Count > 0 Then Comb.SelectedIndex = 0
    End Sub

    Public Sub ApplayPrinteringOptions(ByVal Rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Rpt.PrintOptions.PrinterName = XPrinterName
        'Rpt.PrintOptions.PaperSize = XPaperSize
        'Rpt.PrintOptions.PaperOrientation = XPaperOrientation
        If XAdjustPageMargin = True Then
            Dim Margins As CrystalDecisions.Shared.PageMargins
            Margins.rightMargin = XRightMargin
            Margins.leftMargin = XLeftMargin
            Margins.bottomMargin = XBottonMargin
            Margins.topMargin = XTopMargin
            Rpt.PrintOptions.ApplyPageMargins(Margins)
        End If
        'Rpt.PrintOptions.PrinterDuplex = XPrinterDuplex

    End Sub

#End Region

End Module
