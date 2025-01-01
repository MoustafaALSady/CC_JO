'Option Explicit Off
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPrinting.Drawing
Imports System.Threading

Public Class Form_barcode
    Inherits DevExpress.XtraEditors.XtraForm

    Sub New()
        InitializeComponent()
        'DevExpress.Skins.SkinManager.EnableFormSkins()
        'DevExpress.UserSkins.OfficeSkins.
        'DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Office 2013 Light Gray"
    End Sub

    Private Sub Form_barcode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'SetWindowPos(Handle, HWND_TOPMOST, Left / 15, Top / 15, Width / 15, Height / 15, SWP_NOACTIVATE Or SWP_SHOWWINDOW Or SWP_NOMOVE Or SWP_NOSIZE)

        ''Position form
        'Me.StartPosition = FormStartPosition.WindowsDefaultLocation
        'Me.TopMost = True
        'Me.Top = 164
        'Me.Left = 150
        'Me.Height = 800
        'Me.Width = 1200

        'Dim CultureInfo As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture("Ar")
        'Thread.CurrentThread.CurrentUICulture = CultureInfo

        Dim bmp As Bitmap = My.Resources.cart
        Me.Icon = Icon.FromHandle(bmp.GetHicon)

        'Call RETRIEVE_INFORMATION_SETTINGS()

        Call POPULATE_SEARCHLOOKUPEDIT_FROM_TABLE_ITEMS(SearchLookUpEdit1)

        Call GLOBAL_RECORD_COUNT(Me.LabelControl5, "STOCKSITEMS")

    End Sub

    Private Sub POPULATE_SEARCHLOOKUPEDIT_FROM_TABLE_ITEMS(ByVal Lookup_Repository As SearchLookUpEdit)
        BeginInvoke(Function()
                        Try
                            Dim Consum As New SqlClient.SqlConnection(constring)
                            Dim DT As New DataTable
                            Dim DA As New SqlDataAdapter
                            DT.Clear()
                            DA = New SqlDataAdapter("SELECT * FROM STOCKSITEMS WHERE  CUser='" & ModuleGeneral.CUser & "'", Consum)
                            DA.Fill(DT)
                            If DT.Rows.Count > 0 Then
                                Lookup_Repository.Properties.DataSource = DT
                                Lookup_Repository.Properties.DisplayMember = "SKITM4"
                                Lookup_Repository.Properties.ValueMember = "SKITM4"
                                Lookup_Repository.Properties.View.Columns.Clear()
                                Lookup_Repository.Properties.NullText = "[  ... الرجاء إختيار اسم المنتج من القائمة المنسدلة  ]"
                                Lookup_Repository.Properties.ShowFooter = False
                                Lookup_Repository.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit
                                Lookup_Repository.Properties.PopupFormSize = New Size(725, 600)
                                Lookup_Repository.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
                                Lookup_Repository.Properties.View.OptionsView.ShowColumnHeaders = True
                                Lookup_Repository.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
                                Lookup_Repository.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                                Lookup_Repository.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                                Lookup_Repository.Properties.View.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                                Lookup_Repository.Properties.View.Appearance.HeaderPanel.ForeColor = Color.Orange
                                Lookup_Repository.Properties.View.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                                Lookup_Repository.Properties.View.Appearance.FocusedRow.BackColor = Color.MediumPurple
                                Lookup_Repository.Properties.AllowMouseWheel = True
                                Lookup_Repository.Properties.View.OptionsView.ShowColumnHeaders = True
                                Lookup_Repository.Properties.Appearance.ForeColor = Color.Green
                                Lookup_Repository.Properties.View.Columns.AddVisible("SKITM14", "ثمن البيع")
                                Lookup_Repository.Properties.View.Columns.AddVisible("SKITM5", "اسم المنتج")
                                Lookup_Repository.Properties.View.Columns.AddVisible("SKITM4", "رمز الباركود")
                                Lookup_Repository.Properties.ShowClearButton = False
                                Lookup_Repository.Properties.PopupSizeable = False
                            Else
                                Lookup_Repository.Properties.DataSource = Nothing
                            End If
                        Catch ex As Exception
                            Consum.Close()
                            XtraMessageBox.Show("!! .. عذرا .. حصل خطأ غير متوقّع .. أثناء تنفيذ عمليّة الاستعلام" & vbNewLine & "" & vbNewLine & String.Format("{0}الخطأ: ", ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1))
                        Finally
                            Consum.Close()
                        End Try
                        Return True
                    End Function)
    End Sub

    Private Sub SearchLookUpEdit1_TextChanged(sender As Object, e As EventArgs) Handles SearchLookUpEdit1.TextChanged

        If Not String.IsNullOrEmpty(Me.SearchLookUpEdit1.EditValue) Then
            Me.TxtItemsBarcode.Text = Me.SearchLookUpEdit1.GetSelectedDataRow("SKITM4").ToString
            Me.TxtItemsName.Text = Me.SearchLookUpEdit1.GetSelectedDataRow("SKITM5").ToString
            Me.TxtItemsPrixVente.Text = Me.SearchLookUpEdit1.GetSelectedDataRow("SKITM14").ToString
        End If

        Call CUSTOMISE_MODELE_BARCODE()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'If Me.TxtSettingsEntreprise.Text = vbNullString Or Me.TxtItemsBarcode.Text = vbNullString Or Me.TxtItemsName.Text = vbNullString Or Me.TxtItemsPrixVente.Text = vbNullString Or Me.TxtNumberStickers.Text = vbNullString Then
        '    XtraMessageBox.Show("!! .. عذرا .. الرجاء إختيار اسم المنتج من القائمة المنسدلة لتنفيذ عمليّة الاستعلام", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Return
        '    Exit Sub
        'End If

        Dim Etiquette As New BarCodeReport
        Dim DT As New DataTable

        DT.Clear()

        DT.Columns.Add(New System.Data.DataColumn With {.ColumnName = "Template_Company", .DataType = GetType(String)})
        DT.Columns.Add(New System.Data.DataColumn With {.ColumnName = "Template_Barcode", .DataType = GetType(String)})
        DT.Columns.Add(New System.Data.DataColumn With {.ColumnName = "Template_Product", .DataType = GetType(String)})
        DT.Columns.Add(New System.Data.DataColumn With {.ColumnName = "Template_Prix_Vente", .DataType = GetType(Decimal)})

        For I As Integer = 1 To Convert.ToInt32(Me.TxtNumberStickers.Text.Trim)
            Dim New_Data As DataRow = DT.NewRow
            New_Data("Template_Company") = AssociationName
            New_Data("Template_Barcode") = Me.TxtItemsBarcode.Text
            New_Data("Template_Product") = Me.TxtItemsName.Text
            New_Data("Template_Prix_Vente") = Val(Me.TxtItemsPrixVente.Text)
            DT.Rows.Add(New_Data)
        Next

        With Etiquette
            Etiquette.DataSource = DT

            Etiquette.BarCode1.Text = Me.TxtItemsBarcode.Text
            'Etiquette.TxtSendoussaBarcode.Text = Me.TxtSettingsEntreprise.Text.Trim & Environment.NewLine & "BARCODE : " & Me.TxtItemsBarcode.Text.Trim & Environment.NewLine & "الصنف : " & Me.TxtItemsName.Text.Trim & Environment.NewLine & "السعر : " & Me.TxtItemsPrixVente.Text.Trim

            Etiquette.Watermark.Text = "CC _ JO"
            Etiquette.Watermark.TextDirection = DirectionMode.ForwardDiagonal
            Etiquette.Watermark.Font = New Font(Etiquette.Watermark.Font.FontFamily, 7, FontStyle.Bold)
            Etiquette.Watermark.ForeColor = Color.LightBlue
            Etiquette.Watermark.ImageTransparency = 210
            Etiquette.Watermark.Image = My.Resources.Resources.co102
            Etiquette.Watermark.ImageViewMode = ImageViewMode.Stretch
            Etiquette.BarCode1.ForeColor = Color.DarkCyan
            Etiquette.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ZoomToWholePage)
            Dim Tool_Printing As New ReportPrintTool(Etiquette)
            Etiquette.CreateDocument()
        End With

        Dim Frm As New FrmPRINT1
        Frm.DocumentViewer1.DocumentSource = Etiquette
        Frm.DocumentViewer1.Refresh()
        Frm.Show()

    End Sub

    Sub CUSTOMISE_MODELE_BARCODE()

        Dim Etiquette As New BarCodeReport
        Dim DT As New DataTable

        DT.Clear()

        DT.Columns.Add(New System.Data.DataColumn With {.ColumnName = "Template_Company", .DataType = GetType(String)})
        DT.Columns.Add(New System.Data.DataColumn With {.ColumnName = "Template_Barcode", .DataType = GetType(String)})
        DT.Columns.Add(New System.Data.DataColumn With {.ColumnName = "Template_Product", .DataType = GetType(String)})
        DT.Columns.Add(New System.Data.DataColumn With {.ColumnName = "Template_Prix_Vente", .DataType = GetType(Decimal)})


        Dim New_Data As DataRow = DT.NewRow
        New_Data("Template_Company") = Me.TxtSettingsEntreprise.Text
        New_Data("Template_Barcode") = Me.TxtItemsBarcode.Text
        New_Data("Template_Product") = Me.TxtItemsName.Text
        New_Data("Template_Prix_Vente") = Val(Me.TxtItemsPrixVente.Text)
        DT.Rows.Add(New_Data)


        With Etiquette
            Etiquette.DataSource = DT

            Etiquette.BarCode1.Text = Me.TxtItemsBarcode.Text
            ''Etiquette.TxtSendoussaBarcode.Text = Me.TxtSettingsEntreprise.Text.Trim & Environment.NewLine & "BARCODE : " & Me.TxtItemsBarcode.Text.Trim & Environment.NewLine & "الصنف : " & Me.TxtItemsName.Text.Trim & Environment.NewLine & "السعر : " & Me.TxtItemsPrixVente.Text.Trim

            Etiquette.Watermark.Text = "CC _ JO"
            Etiquette.Watermark.TextDirection = DirectionMode.ForwardDiagonal
            Etiquette.Watermark.Font = New Font(Etiquette.Watermark.Font.FontFamily, 7, FontStyle.Bold)
            Etiquette.Watermark.ForeColor = Color.LightBlue
            Etiquette.Watermark.ImageTransparency = 210
            Etiquette.Watermark.Image = My.Resources.Resources.co102
            Etiquette.Watermark.ImageViewMode = ImageViewMode.Stretch
            Etiquette.BarCode1.ForeColor = Color.DarkCyan
            Etiquette.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ZoomToWholePage)
            Dim Tool_Printing As New ReportPrintTool(Etiquette)
            Etiquette.CreateDocument()
        End With

        Me.DocumentViewer1.DocumentSource = Etiquette
        Me.DocumentViewer1.Refresh()

    End Sub

    Private Sub RETRIEVE_INFORMATION_SETTINGS()
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Consum.State = ConnectionState.Closed Then Consum.Open()
        Dim Sql As String = "SELECT * From STOCKSITEMS"
        Using Cmd As New SqlClient.SqlCommand
            With Cmd
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = Consum
                Cmd.CommandText = Sql
                Dim Dr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                If Dr.HasRows Then
                    Dr.Read()
                    Me.TxtSettingsEntreprise.Text = Dr("SETTINGS_Company").ToString
                End If
                Dr.Close()
            End With
            Cmd.Dispose()
        End Using
    End Sub

    Private Sub TxtNumberStickers_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumberStickers.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Public Sub GLOBAL_RECORD_COUNT(ByVal TxtEdit As LabelControl, ByVal TableName As String)
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Sql As String = "SELECT  COUNT(*)   From  " & TableName
        If Consum.State = ConnectionState.Closed Then Consum.Open()
        Using Cmd As New SqlClient.SqlCommand()
            With Cmd
                Cmd.Connection = Consum
                Cmd.CommandText = Sql
                Cmd.CommandType = CommandType.Text
            End With
            Try
                Dim Count_Record As Int16 = Convert.ToInt32(Cmd.ExecuteScalar())
                If IsDBNull(Count_Record) Then
                    TxtEdit.Text = 0
                Else
                    TxtEdit.Text = Count_Record.ToString()
                End If
            Catch ex As Exception
                Consum.Close()
                XtraMessageBox.Show("!! .. عذرا .. حصل خطأ غير متوقّع .. أثناء تنفيذ عمليّة الاستعلام" & vbNewLine & "" & vbNewLine & String.Format("{0}الخطأ: ", ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error))
            Finally
                Consum.Close()
            End Try
        End Using
    End Sub


















    'Private Sub Buprave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buprave.Click

    '    Dim f As New FrmPRINT
    '    'Dim txt As TextObject
    '    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    '    Dim Consum As New SqlClient.SqlConnection(constring)

    '    GETSERVERNAMEANDDATABASENAME(Repo, DBServer, "", "")
    '    Dim ds As New DataSet
    '    Dim str As New SqlCommand("SELECT * FROM STOCKSITEMS WHERE  CUser='" & ModuleGeneral.CUser & "'  and SKITM4 ='" & Trim(Me.TextBox2.Text) & "'", Consum)
    '    SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
    '    ds.Clear()
    '    SqlDataAdapter1.Fill(ds, "STOCKSITEMS")

    'End Sub





    Friend WithEvents Panel2 As Panel
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtItemsPrixVente As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtItemsName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtItemsBarcode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SearchLookUpEdit1 As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TxtNumberStickers As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Button1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Private components As System.ComponentModel.IContainer

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form_barcode))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSettingsEntreprise = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtItemsPrixVente = New DevExpress.XtraEditors.TextEdit()
        Me.TxtItemsName = New DevExpress.XtraEditors.TextEdit()
        Me.TxtItemsBarcode = New DevExpress.XtraEditors.TextEdit()
        Me.SearchLookUpEdit1 = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.TxtNumberStickers = New DevExpress.XtraEditors.TextEdit()
        Me.Button1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DocumentViewer1 = New DevExpress.XtraPrinting.Preview.DocumentViewer()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPage3 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPage4 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.DocumentViewerBarManager1 = New DevExpress.XtraPrinting.Preview.DocumentViewerBarManager(Me.components)
        Me.BarDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.PreviewBar1 = New DevExpress.XtraPrinting.Preview.PreviewBar()
        Me.PreviewBar2 = New DevExpress.XtraPrinting.Preview.PreviewBar()
        Me.PreviewBar3 = New DevExpress.XtraPrinting.Preview.PreviewBar()
        Me.PrintPreviewStaticItem1 = New DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem()
        Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.ProgressBarEditItem1 = New DevExpress.XtraPrinting.Preview.ProgressBarEditItem()
        Me.PrintPreviewBarItem1 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.PrintPreviewStaticItem2 = New DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem()
        Me.RepositoryItemZoomTrackBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar()
        Me.ZoomTrackBarEditItem1 = New DevExpress.XtraPrinting.Preview.ZoomTrackBarEditItem()
        Me.BbiDocumentMap = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiParameters = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiThumbnails = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiFind = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiHighlightEditingFields = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiCustomize = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiOpen = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiSave = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiPrint = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiPrintDirect = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiPageSetup = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiEditPageHF = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiScale = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiHandTool = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiMagnifier = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiZoomOut = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiZoom = New DevExpress.XtraPrinting.Preview.ZoomBarEditItem()
        Me.PrintPreviewRepositoryItemComboBox1 = New DevExpress.XtraPrinting.Preview.PrintPreviewRepositoryItemComboBox()
        Me.BbiZoomIn = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiShowFirstPage = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiShowPrevPage = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiShowNextPage = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiShowLastPage = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiMultiplePages = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiFillBackground = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiWatermark = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiExportFile = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiSendFile = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.BbiClosePreview = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.MiFile = New DevExpress.XtraPrinting.Preview.PrintPreviewSubItem()
        Me.MiView = New DevExpress.XtraPrinting.Preview.PrintPreviewSubItem()
        Me.MiBackground = New DevExpress.XtraPrinting.Preview.PrintPreviewSubItem()
        Me.MiPageLayout = New DevExpress.XtraPrinting.Preview.PrintPreviewSubItem()
        Me.MiPageLayoutFacing = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.MiPageLayoutContinuous = New DevExpress.XtraPrinting.Preview.PrintPreviewBarItem()
        Me.MiToolbars = New DevExpress.XtraBars.BarToolbarsListItem()
        Me.PrintPreviewBarCheckItem1 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem2 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem3 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem4 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem5 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem6 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem7 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem8 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem9 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem10 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem11 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem12 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem13 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem14 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem15 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem16 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem17 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem18 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.PrintPreviewBarCheckItem19 = New DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSettingsEntreprise.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.TxtItemsPrixVente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtItemsName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtItemsBarcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.TxtNumberStickers.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DocumentViewerBarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemZoomTrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintPreviewRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.Controls.Add(Me.LabelControl5)
        Me.Panel2.Controls.Add(Me.LabelControl3)
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.LabelControl10)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1105, 34)
        Me.Panel2.TabIndex = 1545
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Agency FB", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.Orange
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Appearance.Options.UseForeColor = True
        Me.LabelControl5.Appearance.Options.UseTextOptions = True
        Me.LabelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.LabelControl5.Location = New System.Drawing.Point(53, 2)
        Me.LabelControl5.LookAndFeel.SkinName = "Office 2019 White"
        Me.LabelControl5.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(81, 29)
        Me.LabelControl5.TabIndex = 1461
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.Appearance.Options.UseTextOptions = True
        Me.LabelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.LabelControl3.Location = New System.Drawing.Point(136, 2)
        Me.LabelControl3.LookAndFeel.SkinName = "Office 2019 White"
        Me.LabelControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(145, 29)
        Me.LabelControl3.TabIndex = 1460
        Me.LabelControl3.Text = "عدد المنتجات"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.CC_JO.My.Resources.Resources.Panier
        Me.PictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox3.Location = New System.Drawing.Point(4, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(43, 25)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 1459
        Me.PictureBox3.TabStop = False
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabelControl10.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LabelControl10.Appearance.Options.UseFont = True
        Me.LabelControl10.Appearance.Options.UseForeColor = True
        Me.LabelControl10.Appearance.Options.UseTextOptions = True
        Me.LabelControl10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl10.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.LabelControl10.Location = New System.Drawing.Point(832, 8)
        Me.LabelControl10.LookAndFeel.SkinName = "Office 2019 White"
        Me.LabelControl10.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(263, 24)
        Me.LabelControl10.TabIndex = 4
        Me.LabelControl10.Text = "شاشة طباعة ملصقات باركود المنتجات"
        '
        'TxtSettingsEntreprise
        '
        Me.TxtSettingsEntreprise.Location = New System.Drawing.Point(90, 59)
        Me.TxtSettingsEntreprise.Name = "TxtSettingsEntreprise"
        Me.TxtSettingsEntreprise.Size = New System.Drawing.Size(100, 20)
        Me.TxtSettingsEntreprise.TabIndex = 1462
        '
        'GroupControl4
        '
        Me.GroupControl4.Controls.Add(Me.LabelControl4)
        Me.GroupControl4.Controls.Add(Me.LabelControl2)
        Me.GroupControl4.Controls.Add(Me.LabelControl1)
        Me.GroupControl4.Controls.Add(Me.TxtItemsPrixVente)
        Me.GroupControl4.Controls.Add(Me.TxtItemsName)
        Me.GroupControl4.Controls.Add(Me.TxtItemsBarcode)
        Me.GroupControl4.Controls.Add(Me.SearchLookUpEdit1)
        Me.GroupControl4.Location = New System.Drawing.Point(477, 2)
        Me.GroupControl4.LookAndFeel.SkinName = "Office 2019 White"
        Me.GroupControl4.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(624, 129)
        Me.GroupControl4.TabIndex = 1546
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Appearance.Options.UseTextOptions = True
        Me.LabelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.LabelControl4.Location = New System.Drawing.Point(5, 62)
        Me.LabelControl4.LookAndFeel.SkinName = "Office 2019 White"
        Me.LabelControl4.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(152, 30)
        Me.LabelControl4.TabIndex = 1492
        Me.LabelControl4.Text = "سعر المنتج"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Appearance.Options.UseTextOptions = True
        Me.LabelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.LabelControl2.Location = New System.Drawing.Point(163, 62)
        Me.LabelControl2.LookAndFeel.SkinName = "Office 2019 White"
        Me.LabelControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(310, 30)
        Me.LabelControl2.TabIndex = 1490
        Me.LabelControl2.Text = "اسم المنتج"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseTextOptions = True
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.LabelControl1.Location = New System.Drawing.Point(479, 62)
        Me.LabelControl1.LookAndFeel.SkinName = "Office 2019 White"
        Me.LabelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(137, 30)
        Me.LabelControl1.TabIndex = 1489
        Me.LabelControl1.Text = "باركود المنتج"
        '
        'TxtItemsPrixVente
        '
        Me.TxtItemsPrixVente.EditValue = ""
        Me.TxtItemsPrixVente.Location = New System.Drawing.Point(5, 98)
        Me.TxtItemsPrixVente.Name = "TxtItemsPrixVente"
        Me.TxtItemsPrixVente.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtItemsPrixVente.Properties.Appearance.Options.UseFont = True
        Me.TxtItemsPrixVente.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtItemsPrixVente.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TxtItemsPrixVente.Size = New System.Drawing.Size(152, 24)
        Me.TxtItemsPrixVente.TabIndex = 1488
        '
        'TxtItemsName
        '
        Me.TxtItemsName.EditValue = ""
        Me.TxtItemsName.Location = New System.Drawing.Point(163, 98)
        Me.TxtItemsName.Name = "TxtItemsName"
        Me.TxtItemsName.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtItemsName.Properties.Appearance.Options.UseFont = True
        Me.TxtItemsName.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtItemsName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TxtItemsName.Size = New System.Drawing.Size(310, 24)
        Me.TxtItemsName.TabIndex = 1486
        '
        'TxtItemsBarcode
        '
        Me.TxtItemsBarcode.EditValue = ""
        Me.TxtItemsBarcode.Location = New System.Drawing.Point(479, 98)
        Me.TxtItemsBarcode.Name = "TxtItemsBarcode"
        Me.TxtItemsBarcode.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtItemsBarcode.Properties.Appearance.Options.UseFont = True
        Me.TxtItemsBarcode.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtItemsBarcode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TxtItemsBarcode.Size = New System.Drawing.Size(137, 24)
        Me.TxtItemsBarcode.TabIndex = 1485
        '
        'SearchLookUpEdit1
        '
        Me.SearchLookUpEdit1.EditValue = ""
        Me.SearchLookUpEdit1.Location = New System.Drawing.Point(5, 26)
        Me.SearchLookUpEdit1.Name = "SearchLookUpEdit1"
        Me.SearchLookUpEdit1.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SearchLookUpEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.SearchLookUpEdit1.Properties.Appearance.Options.UseFont = True
        Me.SearchLookUpEdit1.Properties.Appearance.Options.UseForeColor = True
        Me.SearchLookUpEdit1.Properties.Appearance.Options.UseTextOptions = True
        Me.SearchLookUpEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SearchLookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEdit1.Properties.NullText = "[  ... الرجاء إختيار اسم المنتج من القائمة المنسدلة  ]"
        Me.SearchLookUpEdit1.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchLookUpEdit1.Size = New System.Drawing.Size(611, 28)
        Me.SearchLookUpEdit1.TabIndex = 1484
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.SearchLookUpEdit1View.Appearance.FocusedRow.Options.UseBackColor = True
        Me.SearchLookUpEdit1View.Appearance.Row.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchLookUpEdit1View.Appearance.Row.Options.UseFont = True
        Me.SearchLookUpEdit1View.Appearance.Row.Options.UseTextOptions = True
        Me.SearchLookUpEdit1View.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.TxtNumberStickers)
        Me.GroupControl2.Controls.Add(Me.Button1)
        Me.GroupControl2.Location = New System.Drawing.Point(3, 5)
        Me.GroupControl2.LookAndFeel.SkinName = "Office 2019 White"
        Me.GroupControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(231, 129)
        Me.GroupControl2.TabIndex = 1550
        '
        'TxtNumberStickers
        '
        Me.TxtNumberStickers.EditValue = "10"
        Me.TxtNumberStickers.Location = New System.Drawing.Point(5, 84)
        Me.TxtNumberStickers.Name = "TxtNumberStickers"
        Me.TxtNumberStickers.Properties.Appearance.Font = New System.Drawing.Font("Consolas", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumberStickers.Properties.Appearance.Options.UseFont = True
        Me.TxtNumberStickers.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtNumberStickers.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TxtNumberStickers.Size = New System.Drawing.Size(220, 40)
        Me.TxtNumberStickers.TabIndex = 1494
        '
        'Button1
        '
        Me.Button1.Appearance.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Button1.Appearance.Options.UseFont = True
        Me.Button1.Appearance.Options.UseForeColor = True
        Me.Button1.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.printarea_32x32
        Me.Button1.Location = New System.Drawing.Point(6, 26)
        Me.Button1.LookAndFeel.SkinName = "Office 2019 White"
        Me.Button1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(220, 52)
        Me.Button1.TabIndex = 1493
        Me.Button1.Text = " طباعة ملصقات الباركود"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.PictureBox1)
        Me.GroupControl1.Controls.Add(Me.TxtSettingsEntreprise)
        Me.GroupControl1.Location = New System.Drawing.Point(240, 2)
        Me.GroupControl1.LookAndFeel.SkinName = "Office 2019 White"
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(231, 129)
        Me.GroupControl1.TabIndex = 1549
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.CC_JO.My.Resources.Resources.Barcode_Image
        Me.PictureBox1.Location = New System.Drawing.Point(5, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(221, 98)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1544
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DocumentViewer1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1105, 492)
        Me.Panel1.TabIndex = 1551
        '
        'DocumentViewer1
        '
        Me.DocumentViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentViewer1.IsMetric = True
        Me.DocumentViewer1.Location = New System.Drawing.Point(0, 175)
        Me.DocumentViewer1.Name = "DocumentViewer1"
        Me.DocumentViewer1.Size = New System.Drawing.Size(1105, 317)
        Me.DocumentViewer1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.GroupControl4)
        Me.Panel3.Controls.Add(Me.GroupControl1)
        Me.Panel3.Controls.Add(Me.GroupControl2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Panel3.Location = New System.Drawing.Point(0, 34)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1105, 141)
        Me.Panel3.TabIndex = 1552
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "RibbonPage2"
        '
        'RibbonPage3
        '
        Me.RibbonPage3.Name = "RibbonPage3"
        Me.RibbonPage3.Text = "RibbonPage3"
        '
        'RibbonPage4
        '
        Me.RibbonPage4.Name = "RibbonPage4"
        Me.RibbonPage4.Text = "RibbonPage4"
        '
        'DocumentViewerBarManager1
        '
        Me.DocumentViewerBarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.PreviewBar1, Me.PreviewBar2, Me.PreviewBar3})
        Me.DocumentViewerBarManager1.DockControls.Add(Me.BarDockControlTop)
        Me.DocumentViewerBarManager1.DockControls.Add(Me.BarDockControlBottom)
        Me.DocumentViewerBarManager1.DockControls.Add(Me.BarDockControlLeft)
        Me.DocumentViewerBarManager1.DockControls.Add(Me.BarDockControlRight)
        Me.DocumentViewerBarManager1.DocumentViewer = Me.DocumentViewer1
        Me.DocumentViewerBarManager1.Form = Me
        Me.DocumentViewerBarManager1.ImageStream = CType(resources.GetObject("DocumentViewerBarManager1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.DocumentViewerBarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.PrintPreviewStaticItem1, Me.ProgressBarEditItem1, Me.PrintPreviewBarItem1, Me.PrintPreviewStaticItem2, Me.ZoomTrackBarEditItem1, Me.BbiDocumentMap, Me.BbiParameters, Me.BbiThumbnails, Me.BbiFind, Me.BbiHighlightEditingFields, Me.BbiCustomize, Me.BbiOpen, Me.BbiSave, Me.BbiPrint, Me.BbiPrintDirect, Me.BbiPageSetup, Me.BbiEditPageHF, Me.BbiScale, Me.BbiHandTool, Me.BbiMagnifier, Me.BbiZoomOut, Me.BbiZoom, Me.BbiZoomIn, Me.BbiShowFirstPage, Me.BbiShowPrevPage, Me.BbiShowNextPage, Me.BbiShowLastPage, Me.BbiMultiplePages, Me.BbiFillBackground, Me.BbiWatermark, Me.BbiExportFile, Me.BbiSendFile, Me.BbiClosePreview, Me.MiFile, Me.MiView, Me.MiBackground, Me.MiPageLayout, Me.MiPageLayoutFacing, Me.MiPageLayoutContinuous, Me.MiToolbars, Me.PrintPreviewBarCheckItem1, Me.PrintPreviewBarCheckItem2, Me.PrintPreviewBarCheckItem3, Me.PrintPreviewBarCheckItem4, Me.PrintPreviewBarCheckItem5, Me.PrintPreviewBarCheckItem6, Me.PrintPreviewBarCheckItem7, Me.PrintPreviewBarCheckItem8, Me.PrintPreviewBarCheckItem9, Me.PrintPreviewBarCheckItem10, Me.PrintPreviewBarCheckItem11, Me.PrintPreviewBarCheckItem12, Me.PrintPreviewBarCheckItem13, Me.PrintPreviewBarCheckItem14, Me.PrintPreviewBarCheckItem15, Me.PrintPreviewBarCheckItem16, Me.PrintPreviewBarCheckItem17, Me.PrintPreviewBarCheckItem18, Me.PrintPreviewBarCheckItem19})
        Me.DocumentViewerBarManager1.MainMenu = Me.PreviewBar3
        Me.DocumentViewerBarManager1.MaxItemId = 59
        Me.DocumentViewerBarManager1.PreviewBar = Me.PreviewBar1
        Me.DocumentViewerBarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBar1, Me.RepositoryItemZoomTrackBar1, Me.PrintPreviewRepositoryItemComboBox1})
        Me.DocumentViewerBarManager1.StatusBar = Me.PreviewBar2
        Me.DocumentViewerBarManager1.TransparentEditorsMode = DevExpress.Utils.DefaultBoolean.[True]
        '
        'barDockControlTop
        '
        Me.BarDockControlTop.CausesValidation = False
        Me.BarDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControlTop.Manager = Me.DocumentViewerBarManager1
        Me.BarDockControlTop.Size = New System.Drawing.Size(1105, 45)
        '
        'barDockControlBottom
        '
        Me.BarDockControlBottom.CausesValidation = False
        Me.BarDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControlBottom.Location = New System.Drawing.Point(0, 537)
        Me.BarDockControlBottom.Manager = Me.DocumentViewerBarManager1
        Me.BarDockControlBottom.Size = New System.Drawing.Size(1105, 22)
        '
        'barDockControlLeft
        '
        Me.BarDockControlLeft.CausesValidation = False
        Me.BarDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControlLeft.Location = New System.Drawing.Point(0, 45)
        Me.BarDockControlLeft.Manager = Me.DocumentViewerBarManager1
        Me.BarDockControlLeft.Size = New System.Drawing.Size(0, 492)
        '
        'barDockControlRight
        '
        Me.BarDockControlRight.CausesValidation = False
        Me.BarDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControlRight.Location = New System.Drawing.Point(1105, 45)
        Me.BarDockControlRight.Manager = Me.DocumentViewerBarManager1
        Me.BarDockControlRight.Size = New System.Drawing.Size(0, 492)
        '
        'PreviewBar1
        '
        Me.PreviewBar1.BarName = "Toolbar"
        Me.PreviewBar1.DockCol = 0
        Me.PreviewBar1.DockRow = 1
        Me.PreviewBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.PreviewBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BbiDocumentMap), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiParameters), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiThumbnails), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiFind), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiHighlightEditingFields), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiCustomize, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiOpen, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiSave), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiPrint, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiPrintDirect), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiPageSetup), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiEditPageHF), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiScale), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiHandTool, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiMagnifier), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiZoomOut, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiZoom), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiZoomIn), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiShowFirstPage, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiShowPrevPage), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiShowNextPage), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiShowLastPage), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiMultiplePages, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiFillBackground), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiWatermark), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiExportFile, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiSendFile), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiClosePreview, True)})
        Me.PreviewBar1.Text = "Toolbar"
        '
        'PreviewBar2
        '
        Me.PreviewBar2.BarName = "Status Bar"
        Me.PreviewBar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.PreviewBar2.DockCol = 0
        Me.PreviewBar2.DockRow = 0
        Me.PreviewBar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.PreviewBar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewStaticItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ProgressBarEditItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPreviewStaticItem2, True), New DevExpress.XtraBars.LinkPersistInfo(Me.ZoomTrackBarEditItem1)})
        Me.PreviewBar2.OptionsBar.AllowQuickCustomization = False
        Me.PreviewBar2.OptionsBar.DrawDragBorder = False
        Me.PreviewBar2.OptionsBar.UseWholeRow = True
        Me.PreviewBar2.Text = "Status Bar"
        '
        'PreviewBar3
        '
        Me.PreviewBar3.BarName = "Main Menu"
        Me.PreviewBar3.DockCol = 0
        Me.PreviewBar3.DockRow = 0
        Me.PreviewBar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.PreviewBar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.MiFile), New DevExpress.XtraBars.LinkPersistInfo(Me.MiView), New DevExpress.XtraBars.LinkPersistInfo(Me.MiBackground)})
        Me.PreviewBar3.OptionsBar.MultiLine = True
        Me.PreviewBar3.OptionsBar.UseWholeRow = True
        Me.PreviewBar3.Text = "Main Menu"
        '
        'PrintPreviewStaticItem1
        '
        Me.PrintPreviewStaticItem1.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PrintPreviewStaticItem1.Caption = "Nothing"
        Me.PrintPreviewStaticItem1.Id = 0
        Me.PrintPreviewStaticItem1.LeftIndent = 1
        Me.PrintPreviewStaticItem1.Name = "PrintPreviewStaticItem1"
        Me.PrintPreviewStaticItem1.RightIndent = 1
        Me.PrintPreviewStaticItem1.Type = "PageOfPages"
        '
        'RepositoryItemProgressBar1
        '
        Me.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1"
        '
        'ProgressBarEditItem1
        '
        Me.ProgressBarEditItem1.Edit = Me.RepositoryItemProgressBar1
        Me.ProgressBarEditItem1.EditHeight = 12
        Me.ProgressBarEditItem1.EditWidth = 150
        Me.ProgressBarEditItem1.Id = 1
        Me.ProgressBarEditItem1.Name = "ProgressBarEditItem1"
        Me.ProgressBarEditItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'PrintPreviewBarItem1
        '
        Me.PrintPreviewBarItem1.Caption = "Stop"
        Me.PrintPreviewBarItem1.Command = DevExpress.XtraPrinting.PrintingSystemCommand.StopPageBuilding
        Me.PrintPreviewBarItem1.Enabled = False
        Me.PrintPreviewBarItem1.Hint = "Stop"
        Me.PrintPreviewBarItem1.Id = 2
        Me.PrintPreviewBarItem1.Name = "PrintPreviewBarItem1"
        Me.PrintPreviewBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'PrintPreviewStaticItem2
        '
        Me.PrintPreviewStaticItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.PrintPreviewStaticItem2.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PrintPreviewStaticItem2.Caption = "100%"
        Me.PrintPreviewStaticItem2.Id = 3
        Me.PrintPreviewStaticItem2.Name = "PrintPreviewStaticItem2"
        Me.PrintPreviewStaticItem2.TextAlignment = System.Drawing.StringAlignment.Far
        Me.PrintPreviewStaticItem2.Type = "ZoomFactor"
        '
        'RepositoryItemZoomTrackBar1
        '
        Me.RepositoryItemZoomTrackBar1.Alignment = DevExpress.Utils.VertAlignment.Center
        Me.RepositoryItemZoomTrackBar1.AllowFocused = False
        Me.RepositoryItemZoomTrackBar1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RepositoryItemZoomTrackBar1.Maximum = 180
        Me.RepositoryItemZoomTrackBar1.Name = "RepositoryItemZoomTrackBar1"
        '
        'ZoomTrackBarEditItem1
        '
        Me.ZoomTrackBarEditItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.ZoomTrackBarEditItem1.Edit = Me.RepositoryItemZoomTrackBar1
        Me.ZoomTrackBarEditItem1.EditValue = 90
        Me.ZoomTrackBarEditItem1.EditWidth = 140
        Me.ZoomTrackBarEditItem1.Enabled = False
        Me.ZoomTrackBarEditItem1.Id = 4
        Me.ZoomTrackBarEditItem1.Name = "ZoomTrackBarEditItem1"
        Me.ZoomTrackBarEditItem1.Range = New Integer() {10, 500}
        '
        'bbiDocumentMap
        '
        Me.BbiDocumentMap.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.BbiDocumentMap.Caption = "Document Map"
        Me.BbiDocumentMap.Command = DevExpress.XtraPrinting.PrintingSystemCommand.DocumentMap
        Me.BbiDocumentMap.Enabled = False
        Me.BbiDocumentMap.Hint = "Document Map"
        Me.BbiDocumentMap.Id = 5
        Me.BbiDocumentMap.Name = "bbiDocumentMap"
        '
        'bbiParameters
        '
        Me.BbiParameters.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.BbiParameters.Caption = "Parameters"
        Me.BbiParameters.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Parameters
        Me.BbiParameters.Enabled = False
        Me.BbiParameters.Hint = "Parameters"
        Me.BbiParameters.Id = 6
        Me.BbiParameters.Name = "bbiParameters"
        '
        'bbiThumbnails
        '
        Me.BbiThumbnails.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.BbiThumbnails.Caption = "Thumbnails"
        Me.BbiThumbnails.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Thumbnails
        Me.BbiThumbnails.Enabled = False
        Me.BbiThumbnails.Hint = "Thumbnails"
        Me.BbiThumbnails.Id = 7
        Me.BbiThumbnails.Name = "bbiThumbnails"
        '
        'bbiFind
        '
        Me.BbiFind.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.BbiFind.Caption = "Search"
        Me.BbiFind.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Find
        Me.BbiFind.Enabled = False
        Me.BbiFind.Hint = "Search"
        Me.BbiFind.Id = 8
        Me.BbiFind.Name = "bbiFind"
        '
        'bbiHighlightEditingFields
        '
        Me.BbiHighlightEditingFields.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.BbiHighlightEditingFields.Caption = "Editing Fields"
        Me.BbiHighlightEditingFields.Command = DevExpress.XtraPrinting.PrintingSystemCommand.HighlightEditingFields
        Me.BbiHighlightEditingFields.Enabled = False
        Me.BbiHighlightEditingFields.Hint = "Highlight Editing Fields"
        Me.BbiHighlightEditingFields.Id = 9
        Me.BbiHighlightEditingFields.Name = "bbiHighlightEditingFields"
        '
        'bbiCustomize
        '
        Me.BbiCustomize.Caption = "Customize"
        Me.BbiCustomize.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Customize
        Me.BbiCustomize.Enabled = False
        Me.BbiCustomize.Hint = "Customize"
        Me.BbiCustomize.Id = 10
        Me.BbiCustomize.Name = "bbiCustomize"
        '
        'bbiOpen
        '
        Me.BbiOpen.Caption = "Open"
        Me.BbiOpen.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Open
        Me.BbiOpen.Enabled = False
        Me.BbiOpen.Hint = "Open a document"
        Me.BbiOpen.Id = 11
        Me.BbiOpen.Name = "bbiOpen"
        '
        'bbiSave
        '
        Me.BbiSave.Caption = "Save"
        Me.BbiSave.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Save
        Me.BbiSave.Enabled = False
        Me.BbiSave.Hint = "Save the document"
        Me.BbiSave.Id = 12
        Me.BbiSave.Name = "bbiSave"
        '
        'bbiPrint
        '
        Me.BbiPrint.Caption = "&Print..."
        Me.BbiPrint.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Print
        Me.BbiPrint.Enabled = False
        Me.BbiPrint.Hint = "Print"
        Me.BbiPrint.Id = 13
        Me.BbiPrint.Name = "bbiPrint"
        '
        'bbiPrintDirect
        '
        Me.BbiPrintDirect.Caption = "P&rint"
        Me.BbiPrintDirect.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect
        Me.BbiPrintDirect.Enabled = False
        Me.BbiPrintDirect.Hint = "Quick Print"
        Me.BbiPrintDirect.Id = 14
        Me.BbiPrintDirect.Name = "bbiPrintDirect"
        '
        'bbiPageSetup
        '
        Me.BbiPageSetup.Caption = "Page Set&up..."
        Me.BbiPageSetup.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageSetup
        Me.BbiPageSetup.Enabled = False
        Me.BbiPageSetup.Hint = "Page Setup"
        Me.BbiPageSetup.Id = 15
        Me.BbiPageSetup.Name = "bbiPageSetup"
        '
        'bbiEditPageHF
        '
        Me.BbiEditPageHF.Caption = "Header And Footer"
        Me.BbiEditPageHF.Command = DevExpress.XtraPrinting.PrintingSystemCommand.EditPageHF
        Me.BbiEditPageHF.Enabled = False
        Me.BbiEditPageHF.Hint = "Header And Footer"
        Me.BbiEditPageHF.Id = 16
        Me.BbiEditPageHF.Name = "bbiEditPageHF"
        '
        'bbiScale
        '
        Me.BbiScale.ActAsDropDown = True
        Me.BbiScale.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.BbiScale.Caption = "Scale"
        Me.BbiScale.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Scale
        Me.BbiScale.Enabled = False
        Me.BbiScale.Hint = "Scale"
        Me.BbiScale.Id = 17
        Me.BbiScale.Name = "bbiScale"
        '
        'bbiHandTool
        '
        Me.BbiHandTool.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.BbiHandTool.Caption = "Hand Tool"
        Me.BbiHandTool.Command = DevExpress.XtraPrinting.PrintingSystemCommand.HandTool
        Me.BbiHandTool.Enabled = False
        Me.BbiHandTool.Hint = "Hand Tool"
        Me.BbiHandTool.Id = 18
        Me.BbiHandTool.Name = "bbiHandTool"
        '
        'bbiMagnifier
        '
        Me.BbiMagnifier.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.BbiMagnifier.Caption = "Magnifier"
        Me.BbiMagnifier.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Magnifier
        Me.BbiMagnifier.Enabled = False
        Me.BbiMagnifier.Hint = "Magnifier"
        Me.BbiMagnifier.Id = 19
        Me.BbiMagnifier.Name = "bbiMagnifier"
        '
        'bbiZoomOut
        '
        Me.BbiZoomOut.Caption = "Zoom Out"
        Me.BbiZoomOut.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ZoomOut
        Me.BbiZoomOut.Enabled = False
        Me.BbiZoomOut.Hint = "Zoom Out"
        Me.BbiZoomOut.Id = 20
        Me.BbiZoomOut.Name = "bbiZoomOut"
        '
        'bbiZoom
        '
        Me.BbiZoom.Caption = "Zoom"
        Me.BbiZoom.Edit = Me.PrintPreviewRepositoryItemComboBox1
        Me.BbiZoom.EditValue = "100%"
        Me.BbiZoom.EditWidth = 70
        Me.BbiZoom.Enabled = False
        Me.BbiZoom.Hint = "Zoom"
        Me.BbiZoom.Id = 21
        Me.BbiZoom.Name = "bbiZoom"
        '
        'PrintPreviewRepositoryItemComboBox1
        '
        Me.PrintPreviewRepositoryItemComboBox1.AutoComplete = False
        Me.PrintPreviewRepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PrintPreviewRepositoryItemComboBox1.DropDownRows = 11
        Me.PrintPreviewRepositoryItemComboBox1.Name = "PrintPreviewRepositoryItemComboBox1"
        '
        'bbiZoomIn
        '
        Me.BbiZoomIn.Caption = "Zoom In"
        Me.BbiZoomIn.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ZoomIn
        Me.BbiZoomIn.Enabled = False
        Me.BbiZoomIn.Hint = "Zoom In"
        Me.BbiZoomIn.Id = 22
        Me.BbiZoomIn.Name = "bbiZoomIn"
        '
        'bbiShowFirstPage
        '
        Me.BbiShowFirstPage.Caption = "Last Page"
        Me.BbiShowFirstPage.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowLastPage
        Me.BbiShowFirstPage.Enabled = False
        Me.BbiShowFirstPage.Hint = "Last Page"
        Me.BbiShowFirstPage.Id = 23
        Me.BbiShowFirstPage.Name = "bbiShowFirstPage"
        '
        'bbiShowPrevPage
        '
        Me.BbiShowPrevPage.Caption = "Next Page"
        Me.BbiShowPrevPage.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowNextPage
        Me.BbiShowPrevPage.Enabled = False
        Me.BbiShowPrevPage.Hint = "Next Page"
        Me.BbiShowPrevPage.Id = 24
        Me.BbiShowPrevPage.Name = "bbiShowPrevPage"
        '
        'bbiShowNextPage
        '
        Me.BbiShowNextPage.Caption = "Previous Page"
        Me.BbiShowNextPage.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowPrevPage
        Me.BbiShowNextPage.Enabled = False
        Me.BbiShowNextPage.Hint = "Previous Page"
        Me.BbiShowNextPage.Id = 25
        Me.BbiShowNextPage.Name = "bbiShowNextPage"
        '
        'bbiShowLastPage
        '
        Me.BbiShowLastPage.Caption = "First Page"
        Me.BbiShowLastPage.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowFirstPage
        Me.BbiShowLastPage.Enabled = False
        Me.BbiShowLastPage.Hint = "First Page"
        Me.BbiShowLastPage.Id = 26
        Me.BbiShowLastPage.Name = "bbiShowLastPage"
        '
        'bbiMultiplePages
        '
        Me.BbiMultiplePages.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.BbiMultiplePages.Caption = "Multiple Pages"
        Me.BbiMultiplePages.Command = DevExpress.XtraPrinting.PrintingSystemCommand.MultiplePages
        Me.BbiMultiplePages.Enabled = False
        Me.BbiMultiplePages.Hint = "Multiple Pages"
        Me.BbiMultiplePages.Id = 27
        Me.BbiMultiplePages.Name = "bbiMultiplePages"
        '
        'bbiFillBackground
        '
        Me.BbiFillBackground.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.BbiFillBackground.Caption = "&Color..."
        Me.BbiFillBackground.Command = DevExpress.XtraPrinting.PrintingSystemCommand.FillBackground
        Me.BbiFillBackground.Enabled = False
        Me.BbiFillBackground.Hint = "Background"
        Me.BbiFillBackground.Id = 28
        Me.BbiFillBackground.Name = "bbiFillBackground"
        '
        'bbiWatermark
        '
        Me.BbiWatermark.Caption = "&Watermark..."
        Me.BbiWatermark.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Watermark
        Me.BbiWatermark.Enabled = False
        Me.BbiWatermark.Hint = "Watermark"
        Me.BbiWatermark.Id = 29
        Me.BbiWatermark.Name = "bbiWatermark"
        '
        'bbiExportFile
        '
        Me.BbiExportFile.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.BbiExportFile.Caption = "Export Document..."
        Me.BbiExportFile.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportFile
        Me.BbiExportFile.Enabled = False
        Me.BbiExportFile.Hint = "Export Document..."
        Me.BbiExportFile.Id = 30
        Me.BbiExportFile.Name = "bbiExportFile"
        '
        'bbiSendFile
        '
        Me.BbiSendFile.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.BbiSendFile.Caption = "Send via E-Mail..."
        Me.BbiSendFile.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendFile
        Me.BbiSendFile.Enabled = False
        Me.BbiSendFile.Hint = "Send via E-Mail..."
        Me.BbiSendFile.Id = 31
        Me.BbiSendFile.Name = "bbiSendFile"
        '
        'bbiClosePreview
        '
        Me.BbiClosePreview.Caption = "E&xit"
        Me.BbiClosePreview.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ClosePreview
        Me.BbiClosePreview.Enabled = False
        Me.BbiClosePreview.Hint = "Close Preview"
        Me.BbiClosePreview.Id = 32
        Me.BbiClosePreview.Name = "bbiClosePreview"
        '
        'miFile
        '
        Me.MiFile.Caption = "&File"
        Me.MiFile.Command = DevExpress.XtraPrinting.PrintingSystemCommand.File
        Me.MiFile.Id = 33
        Me.MiFile.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BbiPageSetup), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiPrint), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiPrintDirect), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiExportFile, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiSendFile), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiClosePreview, True)})
        Me.MiFile.Name = "miFile"
        '
        'miView
        '
        Me.MiView.Caption = "&View"
        Me.MiView.Command = DevExpress.XtraPrinting.PrintingSystemCommand.View
        Me.MiView.Id = 34
        Me.MiView.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.MiPageLayout, True), New DevExpress.XtraBars.LinkPersistInfo(Me.MiToolbars, True)})
        Me.MiView.Name = "miView"
        '
        'miBackground
        '
        Me.MiBackground.Caption = "&Background"
        Me.MiBackground.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Background
        Me.MiBackground.Id = 35
        Me.MiBackground.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BbiFillBackground), New DevExpress.XtraBars.LinkPersistInfo(Me.BbiWatermark)})
        Me.MiBackground.Name = "miBackground"
        '
        'miPageLayout
        '
        Me.MiPageLayout.Caption = "&Page Layout"
        Me.MiPageLayout.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageLayout
        Me.MiPageLayout.Id = 36
        Me.MiPageLayout.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.MiPageLayoutFacing), New DevExpress.XtraBars.LinkPersistInfo(Me.MiPageLayoutContinuous)})
        Me.MiPageLayout.Name = "miPageLayout"
        '
        'miPageLayoutFacing
        '
        Me.MiPageLayoutFacing.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.MiPageLayoutFacing.Caption = "&Facing"
        Me.MiPageLayoutFacing.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageLayoutFacing
        Me.MiPageLayoutFacing.Enabled = False
        Me.MiPageLayoutFacing.GroupIndex = 100
        Me.MiPageLayoutFacing.Id = 37
        Me.MiPageLayoutFacing.Name = "miPageLayoutFacing"
        '
        'miPageLayoutContinuous
        '
        Me.MiPageLayoutContinuous.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.MiPageLayoutContinuous.Caption = "&Continuous"
        Me.MiPageLayoutContinuous.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageLayoutContinuous
        Me.MiPageLayoutContinuous.Enabled = False
        Me.MiPageLayoutContinuous.GroupIndex = 100
        Me.MiPageLayoutContinuous.Id = 38
        Me.MiPageLayoutContinuous.Name = "miPageLayoutContinuous"
        '
        'miToolbars
        '
        Me.MiToolbars.Caption = "Bars"
        Me.MiToolbars.Id = 39
        Me.MiToolbars.Name = "miToolbars"
        '
        'PrintPreviewBarCheckItem1
        '
        Me.PrintPreviewBarCheckItem1.BindableChecked = True
        Me.PrintPreviewBarCheckItem1.Caption = "PDF File"
        Me.PrintPreviewBarCheckItem1.Checked = True
        Me.PrintPreviewBarCheckItem1.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportPdf
        Me.PrintPreviewBarCheckItem1.Enabled = False
        Me.PrintPreviewBarCheckItem1.GroupIndex = 2
        Me.PrintPreviewBarCheckItem1.Hint = "PDF File"
        Me.PrintPreviewBarCheckItem1.Id = 40
        Me.PrintPreviewBarCheckItem1.Name = "PrintPreviewBarCheckItem1"
        '
        'PrintPreviewBarCheckItem2
        '
        Me.PrintPreviewBarCheckItem2.Caption = "HTML File"
        Me.PrintPreviewBarCheckItem2.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm
        Me.PrintPreviewBarCheckItem2.Enabled = False
        Me.PrintPreviewBarCheckItem2.GroupIndex = 2
        Me.PrintPreviewBarCheckItem2.Hint = "HTML File"
        Me.PrintPreviewBarCheckItem2.Id = 41
        Me.PrintPreviewBarCheckItem2.Name = "PrintPreviewBarCheckItem2"
        '
        'PrintPreviewBarCheckItem3
        '
        Me.PrintPreviewBarCheckItem3.Caption = "MHT File"
        Me.PrintPreviewBarCheckItem3.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportMht
        Me.PrintPreviewBarCheckItem3.Enabled = False
        Me.PrintPreviewBarCheckItem3.GroupIndex = 2
        Me.PrintPreviewBarCheckItem3.Hint = "MHT File"
        Me.PrintPreviewBarCheckItem3.Id = 42
        Me.PrintPreviewBarCheckItem3.Name = "PrintPreviewBarCheckItem3"
        '
        'PrintPreviewBarCheckItem4
        '
        Me.PrintPreviewBarCheckItem4.Caption = "RTF File"
        Me.PrintPreviewBarCheckItem4.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportRtf
        Me.PrintPreviewBarCheckItem4.Enabled = False
        Me.PrintPreviewBarCheckItem4.GroupIndex = 2
        Me.PrintPreviewBarCheckItem4.Hint = "RTF File"
        Me.PrintPreviewBarCheckItem4.Id = 43
        Me.PrintPreviewBarCheckItem4.Name = "PrintPreviewBarCheckItem4"
        '
        'PrintPreviewBarCheckItem5
        '
        Me.PrintPreviewBarCheckItem5.Caption = "DOCX File"
        Me.PrintPreviewBarCheckItem5.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportDocx
        Me.PrintPreviewBarCheckItem5.Enabled = False
        Me.PrintPreviewBarCheckItem5.GroupIndex = 2
        Me.PrintPreviewBarCheckItem5.Hint = "DOCX File"
        Me.PrintPreviewBarCheckItem5.Id = 44
        Me.PrintPreviewBarCheckItem5.Name = "PrintPreviewBarCheckItem5"
        '
        'PrintPreviewBarCheckItem6
        '
        Me.PrintPreviewBarCheckItem6.Caption = "XLS File"
        Me.PrintPreviewBarCheckItem6.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls
        Me.PrintPreviewBarCheckItem6.Enabled = False
        Me.PrintPreviewBarCheckItem6.GroupIndex = 2
        Me.PrintPreviewBarCheckItem6.Hint = "XLS File"
        Me.PrintPreviewBarCheckItem6.Id = 45
        Me.PrintPreviewBarCheckItem6.Name = "PrintPreviewBarCheckItem6"
        '
        'PrintPreviewBarCheckItem7
        '
        Me.PrintPreviewBarCheckItem7.Caption = "XLSX File"
        Me.PrintPreviewBarCheckItem7.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXlsx
        Me.PrintPreviewBarCheckItem7.Enabled = False
        Me.PrintPreviewBarCheckItem7.GroupIndex = 2
        Me.PrintPreviewBarCheckItem7.Hint = "XLSX File"
        Me.PrintPreviewBarCheckItem7.Id = 46
        Me.PrintPreviewBarCheckItem7.Name = "PrintPreviewBarCheckItem7"
        '
        'PrintPreviewBarCheckItem8
        '
        Me.PrintPreviewBarCheckItem8.Caption = "CSV File"
        Me.PrintPreviewBarCheckItem8.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportCsv
        Me.PrintPreviewBarCheckItem8.Enabled = False
        Me.PrintPreviewBarCheckItem8.GroupIndex = 2
        Me.PrintPreviewBarCheckItem8.Hint = "CSV File"
        Me.PrintPreviewBarCheckItem8.Id = 47
        Me.PrintPreviewBarCheckItem8.Name = "PrintPreviewBarCheckItem8"
        '
        'PrintPreviewBarCheckItem9
        '
        Me.PrintPreviewBarCheckItem9.Caption = "Text File"
        Me.PrintPreviewBarCheckItem9.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportTxt
        Me.PrintPreviewBarCheckItem9.Enabled = False
        Me.PrintPreviewBarCheckItem9.GroupIndex = 2
        Me.PrintPreviewBarCheckItem9.Hint = "Text File"
        Me.PrintPreviewBarCheckItem9.Id = 48
        Me.PrintPreviewBarCheckItem9.Name = "PrintPreviewBarCheckItem9"
        '
        'PrintPreviewBarCheckItem10
        '
        Me.PrintPreviewBarCheckItem10.Caption = "Image File"
        Me.PrintPreviewBarCheckItem10.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportGraphic
        Me.PrintPreviewBarCheckItem10.Enabled = False
        Me.PrintPreviewBarCheckItem10.GroupIndex = 2
        Me.PrintPreviewBarCheckItem10.Hint = "Image File"
        Me.PrintPreviewBarCheckItem10.Id = 49
        Me.PrintPreviewBarCheckItem10.Name = "PrintPreviewBarCheckItem10"
        '
        'PrintPreviewBarCheckItem11
        '
        Me.PrintPreviewBarCheckItem11.BindableChecked = True
        Me.PrintPreviewBarCheckItem11.Caption = "PDF File"
        Me.PrintPreviewBarCheckItem11.Checked = True
        Me.PrintPreviewBarCheckItem11.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendPdf
        Me.PrintPreviewBarCheckItem11.Enabled = False
        Me.PrintPreviewBarCheckItem11.GroupIndex = 1
        Me.PrintPreviewBarCheckItem11.Hint = "PDF File"
        Me.PrintPreviewBarCheckItem11.Id = 50
        Me.PrintPreviewBarCheckItem11.Name = "PrintPreviewBarCheckItem11"
        '
        'PrintPreviewBarCheckItem12
        '
        Me.PrintPreviewBarCheckItem12.Caption = "MHT File"
        Me.PrintPreviewBarCheckItem12.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendMht
        Me.PrintPreviewBarCheckItem12.Enabled = False
        Me.PrintPreviewBarCheckItem12.GroupIndex = 1
        Me.PrintPreviewBarCheckItem12.Hint = "MHT File"
        Me.PrintPreviewBarCheckItem12.Id = 51
        Me.PrintPreviewBarCheckItem12.Name = "PrintPreviewBarCheckItem12"
        '
        'PrintPreviewBarCheckItem13
        '
        Me.PrintPreviewBarCheckItem13.Caption = "RTF File"
        Me.PrintPreviewBarCheckItem13.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendRtf
        Me.PrintPreviewBarCheckItem13.Enabled = False
        Me.PrintPreviewBarCheckItem13.GroupIndex = 1
        Me.PrintPreviewBarCheckItem13.Hint = "RTF File"
        Me.PrintPreviewBarCheckItem13.Id = 52
        Me.PrintPreviewBarCheckItem13.Name = "PrintPreviewBarCheckItem13"
        '
        'PrintPreviewBarCheckItem14
        '
        Me.PrintPreviewBarCheckItem14.Caption = "DOCX File"
        Me.PrintPreviewBarCheckItem14.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendDocx
        Me.PrintPreviewBarCheckItem14.Enabled = False
        Me.PrintPreviewBarCheckItem14.GroupIndex = 1
        Me.PrintPreviewBarCheckItem14.Hint = "DOCX File"
        Me.PrintPreviewBarCheckItem14.Id = 53
        Me.PrintPreviewBarCheckItem14.Name = "PrintPreviewBarCheckItem14"
        '
        'PrintPreviewBarCheckItem15
        '
        Me.PrintPreviewBarCheckItem15.Caption = "XLS File"
        Me.PrintPreviewBarCheckItem15.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendXls
        Me.PrintPreviewBarCheckItem15.Enabled = False
        Me.PrintPreviewBarCheckItem15.GroupIndex = 1
        Me.PrintPreviewBarCheckItem15.Hint = "XLS File"
        Me.PrintPreviewBarCheckItem15.Id = 54
        Me.PrintPreviewBarCheckItem15.Name = "PrintPreviewBarCheckItem15"
        '
        'PrintPreviewBarCheckItem16
        '
        Me.PrintPreviewBarCheckItem16.Caption = "XLSX File"
        Me.PrintPreviewBarCheckItem16.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendXlsx
        Me.PrintPreviewBarCheckItem16.Enabled = False
        Me.PrintPreviewBarCheckItem16.GroupIndex = 1
        Me.PrintPreviewBarCheckItem16.Hint = "XLSX File"
        Me.PrintPreviewBarCheckItem16.Id = 55
        Me.PrintPreviewBarCheckItem16.Name = "PrintPreviewBarCheckItem16"
        '
        'PrintPreviewBarCheckItem17
        '
        Me.PrintPreviewBarCheckItem17.Caption = "CSV File"
        Me.PrintPreviewBarCheckItem17.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendCsv
        Me.PrintPreviewBarCheckItem17.Enabled = False
        Me.PrintPreviewBarCheckItem17.GroupIndex = 1
        Me.PrintPreviewBarCheckItem17.Hint = "CSV File"
        Me.PrintPreviewBarCheckItem17.Id = 56
        Me.PrintPreviewBarCheckItem17.Name = "PrintPreviewBarCheckItem17"
        '
        'PrintPreviewBarCheckItem18
        '
        Me.PrintPreviewBarCheckItem18.Caption = "Text File"
        Me.PrintPreviewBarCheckItem18.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendTxt
        Me.PrintPreviewBarCheckItem18.Enabled = False
        Me.PrintPreviewBarCheckItem18.GroupIndex = 1
        Me.PrintPreviewBarCheckItem18.Hint = "Text File"
        Me.PrintPreviewBarCheckItem18.Id = 57
        Me.PrintPreviewBarCheckItem18.Name = "PrintPreviewBarCheckItem18"
        '
        'PrintPreviewBarCheckItem19
        '
        Me.PrintPreviewBarCheckItem19.Caption = "Image File"
        Me.PrintPreviewBarCheckItem19.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendGraphic
        Me.PrintPreviewBarCheckItem19.Enabled = False
        Me.PrintPreviewBarCheckItem19.GroupIndex = 1
        Me.PrintPreviewBarCheckItem19.Hint = "Image File"
        Me.PrintPreviewBarCheckItem19.Id = 58
        Me.PrintPreviewBarCheckItem19.Name = "PrintPreviewBarCheckItem19"
        '
        'Form_barcode
        '
        Me.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1105, 559)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BarDockControlLeft)
        Me.Controls.Add(Me.BarDockControlRight)
        Me.Controls.Add(Me.BarDockControlBottom)
        Me.Controls.Add(Me.BarDockControlTop)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.IconOptions.Icon = CType(resources.GetObject("Form_barcode.IconOptions.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_barcode"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSettingsEntreprise.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        CType(Me.TxtItemsPrixVente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtItemsName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtItemsBarcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.TxtNumberStickers.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.DocumentViewerBarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemZoomTrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintPreviewRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtSettingsEntreprise As TextEdit
    Friend WithEvents Panel3 As Panel
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPage3 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPage4 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents DocumentViewer1 As DevExpress.XtraPrinting.Preview.DocumentViewer
    Friend WithEvents DocumentViewerBarManager1 As DevExpress.XtraPrinting.Preview.DocumentViewerBarManager
    Friend WithEvents PreviewBar1 As DevExpress.XtraPrinting.Preview.PreviewBar
    Friend WithEvents BbiDocumentMap As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiParameters As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiThumbnails As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiFind As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiHighlightEditingFields As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiCustomize As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiOpen As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiSave As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiPrint As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiPrintDirect As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiPageSetup As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiEditPageHF As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiScale As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiHandTool As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiMagnifier As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiZoomOut As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiZoom As DevExpress.XtraPrinting.Preview.ZoomBarEditItem
    Friend WithEvents PrintPreviewRepositoryItemComboBox1 As DevExpress.XtraPrinting.Preview.PrintPreviewRepositoryItemComboBox
    Friend WithEvents BbiZoomIn As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiShowFirstPage As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiShowPrevPage As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiShowNextPage As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiShowLastPage As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiMultiplePages As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiFillBackground As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiWatermark As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiExportFile As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiSendFile As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents BbiClosePreview As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PreviewBar2 As DevExpress.XtraPrinting.Preview.PreviewBar
    Friend WithEvents PrintPreviewStaticItem1 As DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem
    Friend WithEvents ProgressBarEditItem1 As DevExpress.XtraPrinting.Preview.ProgressBarEditItem
    Friend WithEvents RepositoryItemProgressBar1 As Repository.RepositoryItemProgressBar
    Friend WithEvents PrintPreviewBarItem1 As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents PrintPreviewStaticItem2 As DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem
    Friend WithEvents ZoomTrackBarEditItem1 As DevExpress.XtraPrinting.Preview.ZoomTrackBarEditItem
    Friend WithEvents RepositoryItemZoomTrackBar1 As Repository.RepositoryItemZoomTrackBar
    Friend WithEvents PreviewBar3 As DevExpress.XtraPrinting.Preview.PreviewBar
    Friend WithEvents MiFile As DevExpress.XtraPrinting.Preview.PrintPreviewSubItem
    Friend WithEvents MiView As DevExpress.XtraPrinting.Preview.PrintPreviewSubItem
    Friend WithEvents MiPageLayout As DevExpress.XtraPrinting.Preview.PrintPreviewSubItem
    Friend WithEvents MiPageLayoutFacing As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents MiPageLayoutContinuous As DevExpress.XtraPrinting.Preview.PrintPreviewBarItem
    Friend WithEvents MiToolbars As DevExpress.XtraBars.BarToolbarsListItem
    Friend WithEvents MiBackground As DevExpress.XtraPrinting.Preview.PrintPreviewSubItem
    Friend WithEvents BarDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents PrintPreviewBarCheckItem1 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem2 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem3 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem4 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem5 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem6 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem7 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem8 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem9 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem10 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem11 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem12 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem13 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem14 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem15 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem16 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem17 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem18 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
    Friend WithEvents PrintPreviewBarCheckItem19 As DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem
End Class