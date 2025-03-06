Imports System.Diagnostics
Imports System.Drawing.Drawing2D
Imports DevExpress.Pdf
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraTab

Module ModulePdfDocumentSigner

    Public Sub PDFDocumentExpress(ByVal Document1 As String)
        Dim loadedDocument As New PdfDocumentSigner(Document1)
        If Not IO.File.Exists(Document1) Then
            MessageBox.Show("ملف pdf غير موجود !")
        Else
            loadedDocument = New PdfDocumentSigner(Document1)
        End If

        Dim signatureFieldInfo = New PdfSignatureFieldInfo(1) With {
            .Name = "SignatureField",
            .SignatureBounds = New PdfRectangle(20, 20, 150, 150),
            .RotationAngle = PdfAcroFormFieldRotation.Rotate90
        }
        Dim pkcs7Signature As New Pkcs7Signer(Application.StartupPath & "\Data" & "\" & "certificate.pfx", "123", PdfHashAlgorithm.SHA256)
        Dim cooperSignature = New PdfSignatureBuilder(pkcs7Signature, signatureFieldInfo.ToString)
        cooperSignature.SetImageData(System.IO.File.ReadAllBytes(Application.StartupPath & "\Data\signature2.jpg"))
        cooperSignature.Location = "USA"
        cooperSignature.Name = "Jane Cooper"
        cooperSignature.Reason = "Acknowledgement"
        Dim santuzzaSignature = New PdfSignatureBuilder(pkcs7Signature, "Sign")
        santuzzaSignature.SetImageData(System.IO.File.ReadAllBytes(Application.StartupPath & "\Data" & "\" & "OfficialSeal.png"))
        santuzzaSignature.Location = "Australia"
        santuzzaSignature.Name = "Santuzza Valentina"
        santuzzaSignature.Reason = "I Agree"
        Dim signatures() As PdfSignatureBuilder = {cooperSignature, santuzzaSignature}
        'loadedDocument.Close(True)
        'loadedDocument.Close(Document1)
        loadedDocument.SaveDocument(Document1, signatures)
        'Process.Start(Document1)
    End Sub
<<<<<<< HEAD
    <Runtime.CompilerServices.Extension()>
=======
    <System.Runtime.CompilerServices.Extension()>
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public Sub WaitForWindowHandleToClose(ByVal p As Process, ByVal pollingInterval As Integer,
                                          ByVal waitForOpenTimeout As Integer, ByVal waitForCloseTimeout As Integer)

        ' Wait for Main Window Handle to Exist
        Dim totalSleep As Integer
        While Not p.HasExited AndAlso p.MainWindowHandle = IntPtr.Zero
            System.Threading.Thread.Sleep(pollingInterval)
            totalSleep += pollingInterval
            p.Refresh()
            If totalSleep >= waitForOpenTimeout And Not waitForOpenTimeout = 0 Then
                Throw New ApplicationException("Waiting too long for process to start")
            End If
        End While
        ' Wait for Main Window Handle to Close
        totalSleep = 0
        While Not p.HasExited AndAlso p.MainWindowHandle.ToInt64 > 0
            System.Threading.Thread.Sleep(pollingInterval)
            totalSleep += pollingInterval
            p.Refresh()
            If totalSleep >= waitForCloseTimeout And Not waitForCloseTimeout = 0 Then
                Throw New ApplicationException("Waiting too long for process to close")
            End If
        End While
    End Sub

    Public Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Try
            Dim newWidth As Integer
            Dim newHeight As Integer
            If preserveAspectRatio Then
                Dim originalWidth As Integer = image.Width
                Dim originalHeight As Integer = image.Height
                Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
                Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
                Dim percent As Single = IIf(percentHeight < percentWidth, percentHeight, percentWidth)
                newWidth = CInt(originalWidth * percent)
                newHeight = CInt(originalHeight * percent)
            Else
                newWidth = size.Width
                newHeight = size.Height
            End If
            Dim newImage As Image = New Bitmap(newWidth, newHeight)
            Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
            End Using
            Return newImage
        Catch ex As Exception
            Return image
        End Try
    End Function

    Public Function Re_SizeImage(ByVal InputImage As Image) As Image
        Return New Bitmap(InputImage, New Size(64, 64))
    End Function

End Module
