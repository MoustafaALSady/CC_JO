Imports System.Data.SqlClient
Imports DevExpress.LookAndFeel
Imports DevExpress.Skins

Public Class ResourceInterface
    Private Sub ResourceInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim element As SkinElement = SkinManager.GetSkinElement(SkinProductId.Ribbon, DevExpress.LookAndFeel.UserLookAndFeel.Default, "StatusBarFormBackground")
        element.Color.SolidImageCenterColor = Color.SteelBlue
        LookAndFeelHelper.ForceDefaultLookAndFeelChanged()

        'TODO: This line of code loads data into the 'DataSetScheduler.Resources' table. You can move, or remove it, as needed.

        Me.ResourcesTableAdapter.Fill(Me.DataSetScheduler.Resources, CUser)
        FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)
        UserNameTextEdit.EditValue = USERNAME
        CUserTextEdit.EditValue = CUser
        COUserTextEdit.EditValue = COUser
        daTextEdit.EditValue = ServerDateTime.ToString("yyyy-MM-dd")
    End Sub


    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.ResourcesTableAdapter.Update(Me.DataSetScheduler)
        DataSetScheduler.AcceptChanges()
        MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
    End Sub

    Private Sub ButtonEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ButtonEdit.ItemClick
        Me.ResourcesTableAdapter.Update(Me.DataSetScheduler)
        DataSetScheduler.AcceptChanges()
        MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
    End Sub

    Private Sub CombocustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim strsql As New SqlCommand("SELECT IDcust   FROM AllCustomers WHERE cust2 ='" & Me.ComboCustomerName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.ResourceIDTextEdit.Text = ds.Tables(0).Rows(0).Item(0)
            Me.ResourceNameTextEdit.Text = Me.ComboCustomerName.Text
        Else
            Me.ResourceIDTextEdit.Text = ""
            Me.ResourceNameTextEdit.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub


End Class