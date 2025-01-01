Imports System.Drawing.Printing

Public Class FormPrintOptions
    Private Sub FormPrintOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillCombByInstalledPrinters(CombPrinters)
        FillCombByPagesSiz(CombPaperSize)
        'FillCombByFonts(ComboBox1)
        LabelSelectedPrinter.Text = CombPrinters.Text
        CombRecords.SelectedIndex = 0
        CombPageOrientation.SelectedIndex = 0
        CombSamples.SelectedIndex = 0
    End Sub

    Private Sub CombPrinters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CombPrinters.SelectedIndexChanged
        LabelSelectedPrinter.Text = CombPrinters.Text
        FillComboByPagesize(CombPaperSize, LabelSelectedPrinter.Text)
    End Sub

    Private Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
        Me.Close()
    End Sub

    Private Sub CombPaperSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CombPaperSize.SelectedIndexChanged
        'FillComboByPagesize(CombPaperSize, CombPrinters.SelectedIndex)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAdjustPageMargin.CheckedChanged
        If CheckAdjustPageMargin.Checked Then
            GroupBox1.Enabled = True
        Else
            GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub ButOK_Click(sender As Object, e As EventArgs) Handles ButOK.Click
        'XPrinterName = CombPrinters.SelectedIndex
        'XNumOfPrtinedCoppies = TextNumOfCopy.Value
        IsPreviewReprot = ChPreview.Checked
        XPrtintCancelled = True
        'XPaperOrientation
        XPaperSize = CombPaperSize.SelectedIndex
        XAdjustPageMargin = CheckAdjustPageMargin.Checked
        'XTopMargin = TextTopMargin.Value
        'XBottonMargin = TextBottonMargin.Value
        'XRightMargin = TextRightMargin.Value
        'XLeftMargin = TextLeftMargin.Value
        'XPrinterDuplex
        XPrinterAllRecord = CombRecords.SelectedIndex
        'XNameOfExportedPDF
        'XExportReportAsPDF
        Dim pd As New PrintDocument()
        pd.PrinterSettings.PrinterName = XPrinterName
        pd.PrinterSettings.Copies = XNumOfPrtinedCoppies
        'pd.PrinterSettings.IsDefaultPrinter = XNumOfPrtinedCoppies

        Me.Close()
    End Sub








End Class