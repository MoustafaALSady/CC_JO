Option Explicit Off

Imports System.Data.SqlClient
Public Class FormLASTAConvertingchecks
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Public SqlDataAdapter1 As SqlDataAdapter
    ReadOnly ds As New DataSet


    Private Sub FormLASTAConvertingchecks_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        On Error Resume Next
        Ward = False
        Issued = False
        Undercollection = False
        Returnedinbank = False
        Portfolio = False
        Expense = False
        Returned = False

    End Sub

    Private Sub FormLASTAConvertingchecks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.DataGridView1.AutoGenerateColumns = False
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strSQL As New SqlCommand("", Consum)
        With strSQL
            Dim F As Boolean
            Dim T As Boolean
            F = False
            T = True
            If Issued = True Then
                Me.Text = "الشيكات الصادره"
                If Expense = True Then
                    'مصروف
                    .CommandText = "SELECT  IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & True & "' and CH17 ='" & True & "' ORDER BY idch"
                ElseIf Returned = True Then
                    'مرجعة
                    .CommandText = "SELECT  IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & True & "' and CH22 ='" & True & "' ORDER BY idch"
                Else
                    'صادر
                    .CommandText = "SELECT  IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & True & "' and CH17 ='" & False & "'ORDER BY idch"
                End If

            ElseIf Ward = True Then
                Me.Text = "الشيكات الورده"
                If Expense = True Then
                    'مصروف
                    .CommandText = "SELECT  IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH17 ='" & True & "' ORDER BY idch"
                ElseIf Portfolio = True Then
                    'حافظة الشيكات
                    .CommandText = "SELECT  IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH20 ='" & True & "' ORDER BY idch"
                ElseIf Undercollection = True Then
                    ' تحت تحصيل
                    .CommandText = "SELECT  IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH21 ='" & True & "' ORDER BY idch"
                ElseIf Returned = True Then
                    'مرجعة
                    .CommandText = "SELECT  IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH22 ='" & True & "' ORDER BY idch"
                ElseIf Returnedinbank = True Then
                    'مرجعة في البنك
                    .CommandText = "SELECT  IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH23 ='" & True & "' ORDER BY idch"
                Else
                    ' وارد
                    .CommandText = "SELECT  IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH17 ='" & False & "'ORDER BY idch"
                End If
            End If
            '  End If

        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter1 = New SqlDataAdapter(strSQL)
        Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
        ds.Clear()
        SqlDataAdapter1.Fill(ds, "Checks")
        BS.DataSource = ds
        BS.DataMember = "Checks"
        Consum.Close()
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
            .DataBindings.Clear()
            .DataSource = BS
            .AutoGenerateColumns = False
        End With
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmChecks
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCH FROM Checks WHERE   CUser='" & CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCH", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Checks")
            f.BS.DataMember = "Checks"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCH", Me.DataGridView1.CurrentRow.Cells("IDCH").Value)
            f.TB1 = Me.DataGridView1.CurrentRow.Cells("IDCH").Value
            f.Show()
            f.DanLOd()
            f.BS.Position = index
            f.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub

End Class