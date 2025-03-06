
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports Microsoft.Win32

Public Class Formsignature
    Private ReadOnly signatureObject As New Dictionary(Of Integer, List(Of Point))
    Private ReadOnly signaturePen As New Pen(Color.BlueViolet, 2)
    Private currentCurvePoints As List(Of Point)
    Private currentCurve As Integer = -1
    '======================================================================
    Public WithEvents BS As New BindingSource
<<<<<<< HEAD
    Public SqlDataAdapter1 As New SqlDataAdapter
=======
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public ds As New DataSet
    Dim RowCount As Integer = 0

    Private ReadOnly Memo As MemoryStream
    Public ID As Integer
    ReadOnly DrawU As Boolean = False

    Private SaveB As Boolean = False
    Private AddNaemB As Boolean = False


    ReadOnly Draw As Boolean
<<<<<<< HEAD
    ReadOnly DrawColor As Color = Color.Black
    ReadOnly DrawSize As Integer = 3
    ReadOnly pmb As Bitmap

=======
    ReadOnly DrawColor As Color = Color.BlueViolet
    ReadOnly DrawSize As Integer = 2
    ReadOnly pmb As Bitmap
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub SHOWPHOTO()
        On Error Resume Next
        Dim Consum As New SqlConnection(ModuleGeneral.constring)
        Dim sql As String = "SELECT CS3 FROM CapturingSignatures WHERE  USERNAME='" & USERNAME & "'"
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim reader As SqlDataReader
<<<<<<< HEAD
        Dim cmd As New SqlCommand(sql, Consum)
=======
        Dim cmd As New SqlClient.SqlCommand(sql, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        reader = cmd.ExecuteReader()
        reader.Read()
        Dim sw() As Byte = CType(reader("CS3"), Byte())
        Dim ms As New MemoryStream(sw)
        pBoxSavedSignature.Image = Image.FromStream(ms)
        reader.Close()
        Consum.Close()
    End Sub
    Private Sub SHOWPHOTO1()
        On Error Resume Next
        Dim Consum As New SqlConnection(ModuleGeneral.constring)
        Dim sql As String = "SELECT CS3 FROM CapturingSignatures  WHERE  USERNAME='" & USERNAME & "'"
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim reader As SqlDataReader
<<<<<<< HEAD
        Dim cmd As New SqlCommand(sql, Consum)
=======
        Dim cmd As New SqlClient.SqlCommand(sql, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        reader = cmd.ExecuteReader()
        reader.Read()
        Dim sw() As Byte = CType(reader("CS3"), Byte())
        Dim ms As New MemoryStream(sw)
        PictureBox1.Image = Image.FromStream(ms)
        reader.Close()
        Consum.Close()
    End Sub
    Private Sub SHOWPHOTOSELECT()
        On Error Resume Next
        'Me.pBoxSavedSignature.Image = Image.FromFile(SCANFILE)
    End Sub
    Private Sub BackWorker2_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackWorker2.DoWork
        Try

            ModuleGeneral.MYFOLDER = ModuleGeneral.mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            If Not Directory.Exists(ModuleGeneral.MYFOLDER & "\Photos") Then
                Directory.CreateDirectory(ModuleGeneral.MYFOLDER & "\Photos")
            End If
            Me.ds.EnforceConstraints = False
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT   IDCS, CS1, CS2, CS3, USERNAME, Auditor, CUser, COUser FROM     CapturingSignatures WHERE  USERNAME='" & USERNAME & "' "

            End With
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Me.ds = New DataSet
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.ds, "CapturingSignatures")


            Me.txtSignatureFileName.Text = USERNAME
            Consum.Close()
            Me.ds.RejectChanges()

        Catch exception1 As Exception
            MessageBox.Show(exception1.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub
    Private Sub BackWorker2_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackWorker2.ProgressChanged
        'Me.PictureBox1.Visible = True
    End Sub
    Private Sub BackWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackWorker2.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = ds.Tables("CapturingSignatures")
            Me.RowCount = Me.BS.Count
            If Me.ds.Tables.Item(0).Rows.Count > 0 Then
                Me.TextIDCS.Text = Me.ds.Tables.Item(0).Rows.Item(0).Item(0)
                Me.ADDBUTTON.Enabled = False
                Me.SAVEBUTTON.Enabled = False
            Else
                Me.ADDBUTTON.Enabled = True
                'Me.TextIDCS.Text = Nothing
                Me.SAVEBUTTON.Enabled = False
                Me.EDITBUTTON.Enabled = False
                Me.btnSaveSignature.Enabled = False
                Me.ButtonAddNaem.Enabled = False
            End If
            If AddNaemB = True Then
                Me.ADDBUTTON.Enabled = False
            End If
            If SaveB = True Then
                Me.SAVEBUTTON.Enabled = True
            End If
            Me.SHOWPHOTO()
            Me.CBFontSize.SelectedIndex = 3
<<<<<<< HEAD
            Me.CBFontSize1.SelectedIndex = 2
=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            'pmb = New Bitmap((Me.pBoxSignature.Width), (Me.pBoxSignature.Height))
            'Me.pBoxSignature.Image = pmb
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
    End Sub
<<<<<<< HEAD

=======
    Private Sub PintBrush(X As Integer, Y As Integer)
        'If DrawU = True Then
        '    DrawColor = Color.White
        'Else
        '    DrawColor = Color.BlueViolet
        'End If

        Using g As Graphics = Graphics.FromImage(Me.pBoxSignature.Image)
            g.FillRectangle(New SolidBrush(DrawColor), New Rectangle(X, Y, DrawSize, DrawSize))
        End Using
        Me.pBoxSignature.Refresh()
    End Sub
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

    Private Sub PBoxSignature_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pBoxSignature.MouseDown
        'Draw = True
        'pintBrush(e.X, e.Y)
        currentCurvePoints = New List(Of Point)
        currentCurve += 1
        signatureObject.Add(currentCurve, currentCurvePoints)
    End Sub
    Private Sub PBoxSignature_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pBoxSignature.MouseMove
        If e.Button <> MouseButtons.Left OrElse currentCurve < 0 Then Return
        signatureObject(currentCurve).Add(e.Location)
        pBoxSignature.Invalidate()
        'If Draw = True Then
        '    pintBrush(e.X, e.Y)
        'End If
        'If DrawU = True Then
        '    signaturePen = New Pen(Color.YellowGreen, 2)
        'Else
        '    signaturePen = New Pen(Color.BlueViolet, 2)
        'End If
    End Sub
    Private Sub PBoxSignature_MouseUp(sender As Object, e As MouseEventArgs) Handles pBoxSignature.MouseUp
        'Draw = False
    End Sub

    Private Sub BtnClearSignature_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSignature.Click
        currentCurve = -1
        signatureObject.Clear()
        Me.pBoxSignature.Invalidate()
        Me.PictureBox1.Image = Nothing
        Me.pBoxSignature.Image = Nothing
        Me.btnSaveSignature.Enabled = True
        Me.ButtonAddNaem.Enabled = False
    End Sub
    Private Sub ResizedImage()
        Dim fs As FileStream = File.Open(Path.Combine(Application.StartupPath, USERNAME & ".Png"), FileMode.Open)
        Dim bmp As New Bitmap(fs)
        fs.Close()
        Dim Resized As Image = ResizeImage(bmp, New Size(130, 32))
        Dim memStream As New MemoryStream()
        Resized.Save(memStream, ImageFormat.Png)
        memStream.Close()
        pBoxSavedSignature.Image = Resized
        Me.LabelWidth.Text = pBoxSavedSignature.Width
        Me.LabelHeight.Text = pBoxSavedSignature.Height
    End Sub
    Public Shared Function ResizeImageXT(InputImage As Image) As Image
        Return New Bitmap(InputImage, New Size(101, 32))
    End Function
    Private Sub BtnSaveSignature_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveSignature.Click
        Dim signatureFileName = txtSignatureFileName.Text.Trim()
        If String.IsNullOrEmpty(signatureFileName) Then Return
        If currentCurve < 0 OrElse signatureObject(currentCurve).Count = 0 Then Return
        Me.PictureBox1.Image = Nothing
        Using imgSignature As New Bitmap(Me.pBoxSignature.Width, Me.pBoxSignature.Height, PixelFormat.Format32bppArgb), g As Graphics = Graphics.FromImage(imgSignature)
            Using transparentbrush As New SolidBrush(Color.FromArgb(100, Color.White))
                g.FillRectangle(transparentbrush, 0, 0, Me.pBoxSignature.Width, Me.pBoxSignature.Height)
                g.Clear(Color.White)
                g.Save()
            End Using
            DrawSignature(g)
            Dim signaturePath As String = Path.Combine(Application.StartupPath, USERNAME & ".Png")
            If signaturePath <> Nothing Then
                imgSignature.Save(signaturePath, ImageFormat.Png)
            Else
                MessageBox.Show("الرجاء إعادة التوقيع ", "لم يتم", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If
            Me.pBoxSavedSignature.Image = New Bitmap(imgSignature)
            g.Dispose()
            imgSignature.Dispose()
        End Using
        Me.btnSaveSignature.Enabled = False
        Me.ButtonAddNaem.Enabled = True
    End Sub

    Public Shared Function ResizeImage(ByVal image As Image,
  ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
                percentHeight, percentWidth)
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
    End Function

<<<<<<< HEAD
    Private Sub ButtonAddNaem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAddNaem.Click
=======
    Private Sub ButtonAddNaem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddNaem.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim signatureFileName = txtSignatureFileName.Text.Trim()
        If String.IsNullOrEmpty(signatureFileName) Then Return
        If currentCurve < 0 OrElse signatureObject(currentCurve).Count = 0 Then Return
        Using imgSignature As New Bitmap(pBoxSignature.Width, pBoxSignature.Height, PixelFormat.Format32bppArgb), g As Graphics = Graphics.FromImage(imgSignature)
            Using transparentbrush As New SolidBrush(Color.FromArgb(100, Color.White))
                g.FillRectangle(transparentbrush, 0, 0, pBoxSignature.Width, pBoxSignature.Height)
                g.Clear(Color.White)
                Dim myFont As New Font("Times New Roman", Me.CBFontSize.SelectedItem, FontStyle.Bold, GraphicsUnit.Pixel, 100)
                g.DrawString(Me.TextRealname.Text, myFont, Brushes.Navy, Me.TextRight.Text, Me.TextUP.Text)
                g.Save()
            End Using
            DrawSignature(g)
            Dim signaturePath As String = Path.Combine(Application.StartupPath, USERNAME & ".Png")
            imgSignature.Save(signaturePath, ImageFormat.Png)
            Me.pBoxSavedSignature.Image = New Bitmap(imgSignature)
            g.Dispose()
            imgSignature.Dispose()
        End Using
        ResizedImage()
        'Dim fs As FileStream = File.Open(Path.Combine(Application.StartupPath, USERNAME & ".Png"), FileMode.Open)
        'Dim bmp As New Bitmap(fs)
        'fs.Close()
        'ResizeImageXT(bmp).Save(Path.Combine(Application.StartupPath, USERNAME & ".Png"))
        Me.pBoxSavedSignature.Image.Save(Application.StartupPath & "\" & USERNAME & ".Png")

        AddNaemB = True
        'Me.TextIDCS.Text = Nothing
        Me.btnSaveSignature.Enabled = False
        Me.ButtonAddNaem.Enabled = False
        Formsignature_Load(sender, e)
    End Sub
    Private Sub PBoxSignature_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pBoxSignature.Paint
        If currentCurve < 0 OrElse signatureObject(currentCurve).Count = 0 Then Return
        DrawSignature(e.Graphics)
    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub DrawSignature(ByVal g As Graphics)
        g.CompositingMode = CompositingMode.SourceOver
        g.CompositingQuality = CompositingQuality.HighQuality
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim curve As Object
<<<<<<< HEAD
        Dim signaturePen As New Pen(colorPickEdit1.Color, Me.CBFontSize1.SelectedItem)
=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        For Each curve In signatureObject
            If curve.Value.Count < 2 Then Continue For
            Using gPath As New GraphicsPath()
                gPath.AddCurve(curve.Value.ToArray(), 0.5F)
                g.DrawPath(signaturePen, gPath)
            End Using
        Next
    End Sub


    Public Sub PHOTOEDIT()
        On Error Resume Next
        Dim Consum As New SqlConnection(ModuleGeneral.constring)


        Dim MS As New MemoryStream
        Dim ArrImage() As Byte
        Dim NMImage As String
        If Not IsNothing(PictureBox1.Image) Then
            PictureBox1.Image.Save(MS, PictureBox1.Image.RawFormat)
            ArrImage = MS.GetBuffer
            NMImage = "Signature"
        Else
            ArrImage = Nothing
            NMImage = "NULL"
        End If
        If NMImage = "Signature" Then
            Dim SQL As String = " Update CapturingSignatures SET  CS3 = @CS3 WHERE IDCS = @IDCS"
<<<<<<< HEAD
            Dim CMD As New SqlCommand With {
=======
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDCS", SqlDbType.Int).Value = Me.TextIDCS.Text
                .Parameters.Add("@CS3", SqlDbType.Image).Value = ArrImage
                .CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
            MessageBox.Show("تم حفظ التوقيع بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            MessageBox.Show("لم يتم حفظ التوقيع ", "لم يتم", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

        Me.TextIDCS.Text = Nothing
    End Sub
    Private Sub MAXRECORD()
        On Error Resume Next
        Dim V As Integer
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(IDCS) FROM CapturingSignatures", Consum)
        Dim CMD As New SqlCommand
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(IDCS) FROM CapturingSignatures", Consum)
        Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        If IsDBNull(resualt) Then
            TextIDCS.Text = 1
        Else
            TextIDCS.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub

    Private Sub SAVERECORD()
        Try
            Dim Consum As New SqlConnection(ModuleGeneral.constring)
            Dim MS As New MemoryStream
            Dim ArrImage() As Byte
            Dim NMImage As String
            If Not IsNothing(PictureBox1.Image) Then
                PictureBox1.Image.Save(MS, PictureBox1.Image.RawFormat)
                ArrImage = MS.GetBuffer
                NMImage = "Signature"
            Else
                ArrImage = Nothing
                NMImage = "NULL"
            End If



            If NMImage = "Signature" Then
                Dim cmdText As String = "INSERT INTO CapturingSignatures(CS1, CS2, CS3, USERNAME, CUser, COUser) VALUES  (@CS1, @CS2, @CS3, @USERNAME, @CUser, @COUser)"
                Dim command As New SqlCommand(cmdText, Consum)
                Dim command2 As SqlCommand = command
                command2.CommandType = CommandType.Text
                command2.Connection = Consum
                command2.Parameters.Add("@IDCS", SqlDbType.Int).Value = Me.TextIDCS.Text
                command2.Parameters.Add("@CS1", SqlDbType.NVarChar).Value = ModuleGeneral.Realname
                command2.Parameters.Add("@CS2", SqlDbType.Date).Value = ServerDateTime.ToString("yyyy-MM-dd")
                command2.Parameters.Add("@CS3", SqlDbType.Image).Value = ArrImage
                command2.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                command2.Parameters.Add("@CUser", SqlDbType.NVarChar).Value = ModuleGeneral.CUser
                command2.Parameters.Add("@COUser", SqlDbType.NVarChar).Value = ModuleGeneral.COUser
                command2 = Nothing
                If Consum.State = ConnectionState.Open Then
                    Consum.Close()
                End If
                Consum.Open()
                command.ExecuteNonQuery()
                Consum.Close()
                MessageBox.Show("تم حفظ التوقيع بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.ADDBUTTON.Enabled = False
                Me.SAVEBUTTON.Enabled = False
                AddNaemB = False
            Else
                MessageBox.Show("لم يتم حفظ التوقيع ", "لم يتم", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.ADDBUTTON.Enabled = True
                Me.SAVEBUTTON.Enabled = False
                AddNaemB = True
            End If
            Me.TextIDCS.Text = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Consum.Close()
        End Try
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        'Me.EDITBUTTON.Enabled = LockUpdate
        'Me.DELETEBUTTON.Enabled = LockDelete
        'Me.PRINTBUTTON.Enabled = LockPrint
        'Me.ButtonSAVEFILE.Enabled = LockUpdate
        'Me.ButtonXP1.Enabled = LockUpdate
    End Sub
    Public Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        'Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.ds.Tables("MYDOCUMENTSHOME").Rows.Count - 1 Then
            Forward = True
        End If
        'Me.FIRSTBUTTON.Enabled = Back
        'Me.PREVIOUSBUTTON.Enabled = Back
        'Me.NEXTBUTTON.Enabled = Forward
        'Me.LASTBUTTON.Enabled = Forward
        'If Me.PHOTO = True Then
        '    Me.SHOWPHOTO1()
        'Else
        Me.SHOWPHOTO()
        'End If
    End Sub


<<<<<<< HEAD
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
=======
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        SAVERECORD()
        Formsignature_Load(sender, e)
    End Sub
<<<<<<< HEAD
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
=======
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        PHOTOEDIT()
        Formsignature_Load(sender, e)
    End Sub


<<<<<<< HEAD
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextRight.KeyPress
=======
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextRight.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Not Char.IsControl(e.KeyChar) Then
            If Not Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

<<<<<<< HEAD
    Private Sub TextUP_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextUP.KeyPress
=======
    Private Sub TextUP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextUP.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Not Char.IsControl(e.KeyChar) Then
            If Not Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

<<<<<<< HEAD
    Private Sub TextFont_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub TextFont_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Not Char.IsControl(e.KeyChar) Then
            If Not Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

<<<<<<< HEAD
    Private Sub Formsignature_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub Formsignature_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TextRealname.Text = Realname
        On Error Resume Next
<<<<<<< HEAD
        Me.BackWorker2 = New BackgroundWorker With {
=======
        Me.BackWorker2 = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.BackWorker2.RunWorkerAsync()

        'Me.pBoxSavedSignature.Image = Path.Combine(Application.StartupPath, USERNAME & ".png")
        Dim fs As FileStream = File.Open(Path.Combine(Application.StartupPath, USERNAME & ".Png"), FileMode.Open)
        Dim bmp As New Bitmap(fs)
        fs.Close()
        Me.PictureBox1.Image = bmp

    End Sub

    Private Sub CBFontSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBFontSize.SelectedIndexChanged
        'DrawSize = CBFontSize.SelectedItem
    End Sub

    Private Sub ADDBUTTON_Click(sender As Object, e As EventArgs) Handles ADDBUTTON.Click
        Me.SAVEBUTTON.Enabled = True
        currentCurve = -1
        signatureObject.Clear()
        Me.pBoxSignature.Invalidate()
        Me.PictureBox1.Image = Nothing
        Me.pBoxSignature.Image = Nothing
        Me.btnSaveSignature.Enabled = True
        Me.ButtonAddNaem.Enabled = False
        Me.ADDBUTTON.Enabled = False
        SaveB = True
        MAXRECORD()
    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
End Class