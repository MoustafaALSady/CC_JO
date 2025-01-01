Option Explicit Off
Public Class FrmBASICDATA
    Inherits System.Windows.Forms.Form

    ReadOnly ds1 As New DataSet
    Dim WithEvents BS As New BindingSource
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Private Sub FrmBASICDATA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    SAVEBUTTON_Click(sender, e)
                Case Keys.F2
                    EDITBUTTON_Click(sender, e)
                Case Keys.F3
                    BUTTONCANCEL_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmBASICDATA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Dim Consum As New SqlClient.SqlConnection(constring)
        ds1.EnforceConstraints = False
        Consum.Open()
        Dim str1 As String = "SELECT BDATA1, BDATA2, BDATA3, BDATA4, BDATA5, BDATA6, BDATA7, BDATA8, BDATA9, USERNAME, CUser, COUser FROM BASICDATA ORDER BY BDATA1 "
        SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1, Consum)
        ds1.Clear()
        SqlDataAdapter1.Fill(ds1, "BASICDATA")
        BS.DataSource = ds1
        BS.DataMember = "BASICDATA"
        ds1.EnforceConstraints = True
        Me.DataGridView1.DataSource = BS
        SqlDataAdapter1.Dispose()
        DataGridView1.Columns("USERNAME").Visible = False
        DataGridView1.Columns("CUser").Visible = False
        DataGridView1.Columns("COUser").Visible = False

        Consum.Close()
        SHOWBUTTON()
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.SAVEBUTTON.Enabled = LockSave
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
    End Sub
    Private Sub SaveBASICDATA()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO BASICDATA ( BDATA2, BDATA3, BDATA4, BDATA5, BDATA6, BDATA7, BDATA8, BDATA9, USERNAME, CUser, COUser) VALUES     ( @BDATA2, @BDATA3, @BDATA4, @BDATA5, @BDATA6, @BDATA7, @BDATA8, @BDATA9, @USERNAME, @CUser, @COUser)"
            Dim CMD As New SqlClient.SqlCommand(SQL, Consum)
            With CMD.Parameters
                .AddWithValue("@BDATA2", DataGridView1.Item("BDATA2", DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@BDATA3", DataGridView1.Item("BDATA3", DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@BDATA4", DataGridView1.Item("BDATA4", DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@BDATA5", DataGridView1.Item("BDATA5", DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@BDATA6", DataGridView1.Item("BDATA6", DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@BDATA7", DataGridView1.Item("BDATA7", DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@BDATA8", DataGridView1.Item("BDATA8", DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@BDATA9", DataGridView1.Item("BDATA9", DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@USERNAME", USERNAME)
                .AddWithValue("@CUser", CUser)
                .AddWithValue("@COUser", COUser)
            End With
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub UPDATEBASICDATA()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    Dim row As DataGridViewRow = DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For
                    Dim SQL As New SqlClient.SqlCommand("Update BASICDATA  SET BDATA2 = @BDATA2, BDATA3 = @BDATA3, BDATA4 = @BDATA4, BDATA5 = @BDATA5, BDATA6 = @BDATA6, BDATA7 = @BDATA7, BDATA8 = @BDATA8, BDATA9 = @BDATA9, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser WHERE  BDATA1 = '" & Me.DataGridView1.CurrentRow.Cells("BDATA1").Value & "'", Consum)
                    Dim CMD As New SqlClient.SqlCommand(SQL.CommandText) With {
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    With CMD
                        .CommandType = CommandType.Text
                        .Connection = Consum
                        .Parameters.Add("@BDATA1", SqlDbType.Int).Value = DataGridView1.Item("BDATA1", DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@BDATA2", SqlDbType.NVarChar).Value = DataGridView1.Item("BDATA2", DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@BDATA3", SqlDbType.NVarChar).Value = DataGridView1.Item("BDATA3", DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@BDATA4", SqlDbType.NVarChar).Value = DataGridView1.Item("BDATA4", DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@BDATA5", SqlDbType.Float).Value = DataGridView1.Item("BDATA5", DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@BDATA6", SqlDbType.NVarChar).Value = DataGridView1.Item("BDATA6", DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@BDATA7", SqlDbType.NVarChar).Value = DataGridView1.Item("BDATA7", DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@BDATA8", SqlDbType.Int).Value = DataGridView1.Item("BDATA8", DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@BDATA9", SqlDbType.NVarChar).Value = DataGridView1.Item("BDATA9", DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                        .Parameters.Add("@CUser", SqlDbType.Int).Value = CUser
                        .Parameters.Add("@COUser", SqlDbType.Int).Value = COUser
                    End With
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    CMD.Parameters.Clear()
                    Consum.Close()
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
        Try
            Static Dim P As Integer
            P = BS.Position
            SaveBASICDATA()
            FrmBASICDATA_Load(sender, e)
            BS.Position = P
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
        Try
            Static Dim P As Integer
            P = BS.Position
            UPDATEBASICDATA()
            FrmBASICDATA_Load(sender, e)
            BS.Position = P
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        BS.CancelEdit()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
        Dim resault As Integer
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        If BS.Count > 0 Then
            resault = MessageBox.Show("”»‰„ Õ–› «·”Ã·«  «·„Õœœ…", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                For Each row As DataGridViewRow In DataGridView1.SelectedRows
                    Dim n As Integer
                    n = Me.DataGridView1.Rows(row.Index).Cells(0).Value
                    Dim CMD As New SqlClient.SqlCommand With {
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    Dim SQL As String = "DELETE FROM BASICDATA WHERE BDATA1=" & n
                    CMD.CommandText = SQL
                    CMD.ExecuteNonQuery()
                Next
                Consum.Close()
                FrmBASICDATA_Load(sender, e)
            Else
                MessageBox.Show(" „ «Ìﬁ«› ⁄„·Ì… «·Õ–›", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Else
            MessageBox.Show(" ·«ÌÊÃœ ”Ã· Õ«·Ï ·« „«„ ⁄„·Ì… «·Õ–›", "Õ–› ”Ã·", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
    End Sub
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) 'Handles DataGridView1.CellEnter
        Try
            DataGridView1.Item(0, e.RowIndex).Value = Me.DataGridView1.CurrentRow.Index + 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class