﻿Imports System.Data.OleDb
Public Class FrmCustomers



<<<<<<< HEAD
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button1.Click
=======
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        OFD1.Filter = "Excel Files (*.xlsx)|*.xls"
        If OFD1.ShowDialog = Windows.Forms.DialogResult.OK Then
            DataGridView1.DataSource = Nothing
            DataGridView1.Columns.Clear()
            Dim pth As String = OFD1.FileName
            Dim con As New OleDbConnection("PROVIDER=MICROSOFT.ACE.OLEDB.12.0;DATA SOURCE=" & pth & ";EXTENDED PROPERTIS=EXCEL 12.0;")
            Dim ds As New DataSet
            Dim da As New OleDbDataAdapter("select * from [sheet1$]", con)
            da.Fill(ds, "[sheet1$]")
            DataGridView1.DataSource = ds.Tables("[sheet1$]")
        Else
            Exit Sub
        End If
    End Sub
End Class