

Imports System.Diagnostics
Imports System.IO
Imports ALquhaliLibrary
Imports DevExpress.XtraEditors
Imports SautinSoft.Document
Imports SautinSoft.Document.Drawing
Imports Syncfusion.Pdf
Imports Syncfusion.Pdf.Graphics
Imports Syncfusion.Pdf.Parsing
Imports Syncfusion.Pdf.Security

Module ModuleSignature
    Public RB1 As Boolean = False
    Public RB2 As Boolean = False
    Public RB3 As Boolean = False
    Public RB4 As Boolean = False
    Public RB5 As Boolean = False
    Public RB6 As Boolean = False
    Public RB7 As Boolean = False
    Public RB8 As Boolean = False
    Public RB9 As Boolean = False
    Public RB10 As Boolean = False
    Public RB11 As Boolean = False
    Public RB12 As Boolean = False

    Public ABA1 As Integer = 0
    Public ABA2 As Integer = 0
    Public ABA3 As Integer = 0
    Public AB4 As Integer = 0
    Public AB5 As Integer = 0
    Public AB6 As Integer = 0
    Public AB7 As Integer = 0
    Public AB8 As Integer = 0
    Public AB9 As Integer = 0
    Public AB10 As Integer = 0
    Public AB11 As Integer = 0
    Public AB12 As Integer = 0

    Public ScanTo As Short = 0

    Public OfficialSeal As Boolean = False

    Public Sub PDFDocument(ByVal Document1 As String)
        Dim loadedDocument As PdfLoadedDocument = Nothing
        Dim certificate As PdfCertificate = Nothing
        If Not IO.File.Exists(Document1) Then
            MessageBox.Show("غير موجد (pdf) ملف")
        Else
            loadedDocument = New PdfLoadedDocument(Document1)
        End If
        Dim page As PdfPageBase = TryCast(loadedDocument.Pages(0), PdfLoadedPage)
        If Not IO.File.Exists(Application.StartupPath & "\Data" & "\" & "certificate.pfx") Then
            MessageBox.Show("غير موجد (pfx) ملف")
        Else
            certificate = New PdfCertificate(Application.StartupPath & "\Data" & "\" & "certificate.pfx", "123")
        End If

        Dim signatureField As New PdfSignature(loadedDocument, page, certificate, "Signature")
        'signatureField.Signature = New PdfSignature(loadedDocument, page, certificate, "التـوقبــع", signatureField)
        Dim signatureImage As New PdfBitmap(Application.StartupPath & "\Data" & "\" & "signature.png")
        Dim sOfficialSealImage As New PdfBitmap(Application.StartupPath & "\Data" & "\" & "OfficialSeal.png")
        If OfficialSeal = True Then
            signatureField.Bounds = New RectangleF(0, 0, 200, 100)
            signatureField.ContactInfo = "johndoe@owned.us"
            signatureField.LocationInfo = "Honolulu, Hawaii"
            signatureField.Reason = "I am author of this document."
            signatureField.Appearance.Normal.Graphics.DrawImage(signatureImage, signatureField.Bounds)
            loadedDocument.Save(Document1)
            signatureField.Bounds = New RectangleF(20, 40, 200, 100)
            signatureField.ContactInfo = "johndoe@owned.us"
            signatureField.LocationInfo = "Honolulu, Hawaii"
            signatureField.Reason = "I am author of this document."
            signatureField.Appearance.Normal.Graphics.DrawImage(sOfficialSealImage, signatureField.Bounds)
            loadedDocument.Save(Document1)
        Else
            signatureField.Bounds = New RectangleF(0, 0, 200, 100)
            signatureField.ContactInfo = "johndoe@owned.us"
            signatureField.LocationInfo = "Honolulu, Hawaii"
            signatureField.Reason = "I am author of this document."
            signatureField.Appearance.Normal.Graphics.DrawImage(signatureImage, signatureField.Bounds)
            'signatureField.Appearance.Normal.Graphics.DrawImage(signatureImage, New RectangleF(0, 0, signatureImage.Width, signatureImage.Height))
            loadedDocument.Save(Document1)
        End If
        loadedDocument.Close(True)
        Process.Start(Document1)
    End Sub
    Public Sub DigitalSignature(ByVal Document1 As String)
        Dim loadPath As String = Document1
        Dim dc As DocumentCore = Nothing
        If Not IO.File.Exists(Document1) Then
            MessageBox.Show("غير موجد (pdf) ملف")
        Else
            dc = DocumentCore.Load(loadPath)
        End If

<<<<<<< HEAD
        Dim signatureShape = New Shape(dc, Layout.Floating(New HorizontalPosition(0F, LengthUnit.Millimeter, HorizontalPositionAnchor.LeftMargin), New VerticalPosition(0F, LengthUnit.Millimeter, VerticalPositionAnchor.TopMargin), New Size(1, 1)))
=======
        Dim signatureShape = New Shape(dc, Layout.Floating(New HorizontalPosition(0F, LengthUnit.Millimeter, HorizontalPositionAnchor.LeftMargin), New VerticalPosition(0F, LengthUnit.Millimeter, VerticalPositionAnchor.TopMargin), New SautinSoft.Document.Drawing.Size(1, 1)))
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        CType(signatureShape.Layout, FloatingLayout).WrappingStyle = WrappingStyle.InFrontOfText
        signatureShape.Outline.Fill.SetEmpty()
        Dim firstPar As Paragraph = dc.GetChildElements(True).OfType(Of Paragraph)().FirstOrDefault()
        Dim signaturePict As New Picture(dc, Application.StartupPath & "\Data" & "\" & "signature2.jpg")
        Dim options As New PdfSaveOptions()
        Dim layouts As New List(Of Layout)() From {FloatingLayout.Floating(
            New HorizontalPosition(20, LengthUnit.Millimeter, HorizontalPositionAnchor.Page),
            New VerticalPosition(263, LengthUnit.Millimeter, VerticalPositionAnchor.TopMargin),
<<<<<<< HEAD
            New Size(LengthUnitConverter.Convert(5, LengthUnit.Centimeter, LengthUnit.Point),
=======
            New SautinSoft.Document.Drawing.Size(LengthUnitConverter.Convert(5, LengthUnit.Centimeter, LengthUnit.Point),
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            LengthUnitConverter.Convert(2, LengthUnit.Centimeter, LengthUnit.Point)))}
        firstPar.Inlines.Add(signatureShape)
        'signaturePict.Layout = Layout.Floating(New HorizontalPosition(1.5, LengthUnit.Centimeter, HorizontalPositionAnchor.Page), New VerticalPosition(27.5, LengthUnit.Centimeter, VerticalPositionAnchor.Page), New SautinSoft.Document.Drawing.Size(57, 15.5, LengthUnit.Millimeter))
        If Not IO.File.Exists(Application.StartupPath & "\Data" & "\" & "sautinsoft.pfx") Then
            MessageBox.Show("غير موجد (pfx) ملف")
        Else
            options.DigitalSignature.CertificatePath = Application.StartupPath & "\Data" & "\" & "sautinsoft.pfx"
            options.DigitalSignature.CertificatePassword = "123456789"
        End If
        options.DigitalSignature.Location = "الاردن _ عجلون _ عنجرة"
        options.DigitalSignature.Reason = "مصطفى ابراهيم السعدي"
        options.DigitalSignature.ContactInfo = "mams0076@yahoo.com"
        options.DigitalSignature.SignatureLine = signatureShape
        options.DigitalSignature.Signature = signaturePict
        For Each s As Section In dc.Sections
            For Each fl As FloatingLayout In layouts
                signaturePict.Layout = New FloatingLayout(fl.HorizontalPosition, fl.VerticalPosition, fl.Size)
                TryCast(signaturePict.Layout, FloatingLayout).WrappingStyle = WrappingStyle.BehindText
                s.Blocks(0).Content.Start.Insert(signaturePict.Content)
            Next
        Next
        dc.Save(loadPath, options)
<<<<<<< HEAD
        System.Diagnostics.Process.Start(New ProcessStartInfo(loadPath) With {.UseShellExecute = True})
=======
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(loadPath) With {.UseShellExecute = True})
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    End Sub
    Public Sub OfficialSealTOPDF(ByVal Document1 As String)
        Dim loadPath As String = Document1
        Dim pctFile As String = Application.StartupPath & "\Data" & "\" & "OfficialSeal.png"
        Dim dc As DocumentCore = Nothing
        If Not IO.File.Exists(Document1) Then
            MessageBox.Show("غير موجد (pdf) ملف")
        Else
            dc = DocumentCore.Load(loadPath)
        End If
        Dim pict As New Picture(dc, pctFile)
        Dim layouts As New List(Of Layout)() From {FloatingLayout.Floating(
            New HorizontalPosition(20, LengthUnit.Millimeter, HorizontalPositionAnchor.Page),
            New VerticalPosition(235, LengthUnit.Millimeter, VerticalPositionAnchor.TopMargin),
<<<<<<< HEAD
            New Size(LengthUnitConverter.Convert(5, LengthUnit.Centimeter, LengthUnit.Point),
=======
            New SautinSoft.Document.Drawing.Size(LengthUnitConverter.Convert(5, LengthUnit.Centimeter, LengthUnit.Point),
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            LengthUnitConverter.Convert(2.5, LengthUnit.Centimeter, LengthUnit.Point)))}
        For Each s As Section In dc.Sections
            For Each fl As FloatingLayout In layouts
                pict.Layout = New FloatingLayout(fl.HorizontalPosition, fl.VerticalPosition, fl.Size)
                TryCast(pict.Layout, FloatingLayout).WrappingStyle = WrappingStyle.BehindText
                s.Blocks(0).Content.Start.Insert(pict.Content)
            Next fl
        Next s
        dc.Save(loadPath, New PdfSaveOptions())
<<<<<<< HEAD
        System.Diagnostics.Process.Start(New ProcessStartInfo(loadPath) With {.UseShellExecute = True})
=======
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(loadPath) With {.UseShellExecute = True})
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    End Sub

    Public Sub AddSignatureToDocxInMemory(ByVal Document1 As String)
        Dim loadPath As String = Document1
        Dim pictPath As String = Application.StartupPath & "\Data" & "\" & "signature2.jpg"

        If Not IO.File.Exists(Document1) Then
            MessageBox.Show("غير موجد (Word) ملف")
        Else
            loadPath = Document1
        End If
        Dim inputDocxBytes() As Byte = File.ReadAllBytes(loadPath)
        Dim pictBytes() As Byte = File.ReadAllBytes(pictPath)
        Dim dc As DocumentCore = Nothing
        Using msDocx As New MemoryStream(inputDocxBytes)
            dc = DocumentCore.Load(msDocx, New DocxLoadOptions())
        End Using
        Dim pict As Picture = Nothing
        Dim width As Integer = 50.7
        Dim height As Integer = 20
<<<<<<< HEAD
        Dim size As New Size(LengthUnitConverter.Convert(width, LengthUnit.Millimeter, LengthUnit.Point), LengthUnitConverter.Convert(height, LengthUnit.Millimeter, LengthUnit.Point))
=======
        Dim size As New SautinSoft.Document.Drawing.Size(LengthUnitConverter.Convert(width, LengthUnit.Millimeter, LengthUnit.Point), LengthUnitConverter.Convert(height, LengthUnit.Millimeter, LengthUnit.Point))
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim fromLeftMm As Integer = 20
        Dim fromTopMm As Integer = 260
        Dim fl As New FloatingLayout(New HorizontalPosition(fromLeftMm, LengthUnit.Millimeter, HorizontalPositionAnchor.Page), New VerticalPosition(fromTopMm, LengthUnit.Millimeter, VerticalPositionAnchor.TopMargin), size)
        Using msPict As New MemoryStream(pictBytes)
            pict = New Picture(dc, fl, msPict, PictureFormat.Jpeg)
        End Using
        TryCast(pict.Layout, FloatingLayout).WrappingStyle = WrappingStyle.InFrontOfText
        Dim sect As Section = dc.Sections(0)
        sect.Content.End.Insert(pict.Content)
        Using msDocxResult As New MemoryStream()
            dc.Save(msDocxResult, New DocxSaveOptions())
            File.WriteAllBytes(Document1, msDocxResult.ToArray())
<<<<<<< HEAD
            System.Diagnostics.Process.Start(New ProcessStartInfo(Document1) With {.UseShellExecute = True})
=======
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Document1) With {.UseShellExecute = True})
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        End Using

    End Sub
    Public Sub AddOfficialSealToDocxInMemory(ByVal Document1 As String)
        Dim loadPath As String = Document1
        Dim pictPath As String = Application.StartupPath & "\Data" & "\" & "OfficialSeal.png"

        If Not IO.File.Exists(Document1) Then
            MessageBox.Show("غير موجد (Word) ملف")
        Else
            loadPath = Document1
        End If
        Dim inputDocxBytes() As Byte = File.ReadAllBytes(loadPath)
        Dim pictBytes() As Byte = File.ReadAllBytes(pictPath)
        Dim dc As DocumentCore = Nothing
        Using msDocx As New MemoryStream(inputDocxBytes)
            dc = DocumentCore.Load(msDocx, New DocxLoadOptions())
        End Using
        Dim pict As Picture = Nothing
        Dim width As Integer = 40.9
        Dim height As Integer = 20.3
<<<<<<< HEAD
        Dim size As New Size(LengthUnitConverter.Convert(width, LengthUnit.Millimeter, LengthUnit.Point), LengthUnitConverter.Convert(height, LengthUnit.Millimeter, LengthUnit.Point))
=======
        Dim size As New SautinSoft.Document.Drawing.Size(LengthUnitConverter.Convert(width, LengthUnit.Millimeter, LengthUnit.Point), LengthUnitConverter.Convert(height, LengthUnit.Millimeter, LengthUnit.Point))
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim fromLeftMm As Integer = 20
        Dim fromTopMm As Integer = 237
        Dim fl As New FloatingLayout(New HorizontalPosition(fromLeftMm, LengthUnit.Millimeter, HorizontalPositionAnchor.Page), New VerticalPosition(fromTopMm, LengthUnit.Millimeter, VerticalPositionAnchor.TopMargin), size)
        Using msPict As New MemoryStream(pictBytes)
            pict = New Picture(dc, fl, msPict, PictureFormat.Jpeg)
        End Using
        TryCast(pict.Layout, FloatingLayout).WrappingStyle = WrappingStyle.InFrontOfText
        Dim sect As Section = dc.Sections(0)
        sect.Content.End.Insert(pict.Content)
        Using msDocxResult As New MemoryStream()
            dc.Save(msDocxResult, New DocxSaveOptions())
            File.WriteAllBytes(Document1, msDocxResult.ToArray())
<<<<<<< HEAD
            System.Diagnostics.Process.Start(New ProcessStartInfo(Document1) With {.UseShellExecute = True})
=======
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Document1) With {.UseShellExecute = True})
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        End Using
    End Sub




    Public Sub ZoominoutPictureBox(ByVal pb As PictureBox, ByVal value As Double)
        If pb.Image Is Nothing Then Return
        pb.Width *= value
        pb.Height *= value
        pb.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub







    Public Sub Rotatraeit(ByVal pb As PictureBox)
        Try
            If pb.Image Is Nothing Then Return
            Dim pic As Bitmap = pb.Image.Clone
            pic.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pb.Image = pic
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Public Sub Rotatlaft(ByVal pb As PictureBox)
        Try
            If pb.Image Is Nothing Then Return
            Dim pic As Bitmap = pb.Image.Clone
            pic.RotateFlip(RotateFlipType.Rotate90FlipXY)
            pb.Image = pic
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Public Sub RotatlaftPictureEdit(ByVal pb As PictureEdit)
        Try
            If pb.Image Is Nothing Then Return
            Dim pic As Bitmap = pb.Image.Clone
            pic.RotateFlip(RotateFlipType.Rotate90FlipXY)
            pb.Image = pic
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Public Sub RotatraeitPictureEdit(ByVal pb As PictureEdit)
        Try
            If pb.Image Is Nothing Then Return
            Dim pic As Bitmap = pb.Image.Clone
            pic.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pb.Image = pic
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Public Function MYTexer(ByVal TXT As TextBox, ByVal ception As String)
        If TXT.Text.Trim = Nothing Then
            MsgBox("حقل" & " " & ception & " . " & "فارغ", MsgBoxStyle.Information, "تاكيد الادخال")
            TXT.Text = Nothing
            TXT.Focus()
            Return True
        Else
            TXT.Text = TXT.Text.Trim
            Return False
        End If
    End Function
    Public Sub CraeteToPDF(ByVal XX As FormScan)
        If XX.CheckedListBox1.Items.Count = 0 Then Return
        If MYTexer(XX.TextFailName, "اسم الملف الذي تريد انشائة") Then Return
        MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        If Not IO.Directory.Exists(MYFOLDER & "\FailImag") Then Directory.CreateDirectory(MYFOLDER & "\FolderImageName")
        Dim FolderImageName As String = MYFOLDER & "\FolderImageName"
        If MYFOLDER = String.Empty Then
            MessageBox.Show("اختار مسار حفظ الصوره", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim CreadedFolder As String = FolderImageName
        Dim CreadedFailName As String = CreadedFolder & "\" & XX.TextFailName.Text.Trim & ".pdf"
        XX.LabFileName.Visible = True
        XX.LabFileName.Text = CreadedFailName
        If My.Computer.FileSystem.FileExists(CreadedFolder) = False Then Directory.CreateDirectory(CreadedFolder)
        TPro.ConvertImagesToPDF(XX.CheckedListBox1, CreadedFailName)
        'If MessageBox.Show("هل تود ارشفة الملف" & "" & XX.TextFailName.Text.Trim, "رسالة تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '    XX.Close()
        '    If ScanTo = 1 Then

        '    ElseIf ScanTo = 2 Then

        '    End If
        'End If
    End Sub
    Public Sub CraeteTempFolder()
        MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        Dim StoredPath As String = MYFOLDER & "\Archived File\Temp"
        If My.Computer.FileSystem.FileExists(StoredPath) = False Then IO.Directory.CreateDirectory(StoredPath)

    End Sub

    Public Sub DeletDirectory(ByVal FPath As String)
        If Directory.Exists(FPath) Then
            For Each FilePath As String In Directory.GetFiles(FPath)
                File.Delete(FilePath)
            Next
            For Each dir As String In Directory.GetDirectories(FPath)
                DeletDirectory(dir)
            Next
        End If

    End Sub



    Public Function GetFileiceo(ByVal FileExtension As String) As Int16
        'OpenFileDialog1.Filter = "Bitmap file (*.bmp)|*.bmp|TIFF file (*.tif)|*.tif|JPEG file (*.jpg)|*.jpg|PNG file (*.png)|*.png|GIF file (*.gif)|*.gif|All files (*.*)|*.*"

        Select Case FileExtension
            Case ".pdf"
                Return 1
            Case ".doc", ".docx"
                Return 2
            Case ".xls", ".xlsx", ".XLS", ".XLSX"
                Return 3
            Case ".ppt", ".pptx", ".PPT", ".PPTX"
                Return 4
            Case ".mdw", ".mdb", ".accdb", ".mdE"
                Return 5
            Case ".zip", ".rar", ".7z"
                Return 6
            Case ".jpg", ".jpeg", ".png", ".gif", ".dng", ".rew", ".ico", ".bmp", ".JPG", ".PNG", ".JPEG"
                Return 7
            Case ".txt", ".log", ".ini"
                Return 8
            Case Else
                Return 0

        End Select
    End Function

    Sub Main()
        Dim filePath As String = "C:\myfile.exe"
        Dim TheIcon As Icon = IconFromFilePath(filePath)

        If TheIcon IsNot Nothing Then
            ''#Save it to disk, or do whatever you want with it.
<<<<<<< HEAD
            Using stream As New FileStream("c:\myfile.ico", IO.FileMode.CreateNew)
=======
            Using stream As New System.IO.FileStream("c:\myfile.ico", IO.FileMode.CreateNew)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                TheIcon.Save(stream)
            End Using
        End If
    End Sub
    Public Function IconFromFilePath(filePath As String) As Icon
        Dim result As Icon = Nothing
        Try
            result = Icon.ExtractAssociatedIcon(filePath)
        Catch ''# swallow and return nothing. You could supply a default Icon here as well
        End Try
        Return result
    End Function




End Module
