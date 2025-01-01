Imports System.Diagnostics
Imports Syncfusion.Pdf
Imports Syncfusion.Pdf.Graphics
Imports Syncfusion.Pdf.Parsing
Imports Syncfusion.Pdf.Security





Namespace PDFFormFillingSample
    Public Class DocumentPDF1
        Public Class Program
            Private Shared Sub Main(ByVal args As String())
                If args Is Nothing Then
                    Throw New ArgumentNullException(NameOf(args))
                End If

                Dim loadedDocument As New PdfLoadedDocument("../../Data/FormTemplate.pdf")
                Dim page As PdfLoadedPage = TryCast(loadedDocument.Pages(0), PdfLoadedPage)
                Dim form As PdfLoadedForm = loadedDocument.Form
                TryCast(form.Fields("Name"), PdfLoadedTextBoxField).Text = "Simons"
                TryCast(form.Fields("Email address"), PdfLoadedTextBoxField).Text = "simonsbistro@outlook.com"
                TryCast(form.Fields("Phone"), PdfLoadedTextBoxField).Text = "31 12 34 56"
                TryCast(form.Fields("Gender"), PdfLoadedRadioButtonListField).SelectedIndex = 0
                TryCast(form.Fields("JobTitle"), PdfLoadedComboBoxField).SelectedIndex = 1
                TryCast(form.Fields("Languages"), PdfLoadedListBoxField).SelectedIndex = New Integer(0) {2}
                TryCast(form.Fields("Associate degree"), PdfLoadedCheckBoxField).Items(0).Checked = True
                Dim signatureField As PdfLoadedSignatureField = TryCast(loadedDocument.Form.Fields(9), PdfLoadedSignatureField)
                Dim certificate As New PdfCertificate("../../Data/PDF.pfx", "syncfusion")
                signatureField.Signature = New PdfSignature(loadedDocument, page, certificate, "Signature", signatureField)
                Dim signatureImage As New PdfBitmap("../../Data/signature.jpg")
                signatureField.Signature.Appearance.Normal.Graphics.DrawImage(signatureImage, New PointF(5, 5), New SizeF(100, 20))
                loadedDocument.Save("Form.pdf")
                loadedDocument.Close(True)
                Process.Start("Form.pdf")
            End Sub
        End Class
    End Class
End Namespace


