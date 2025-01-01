Option Explicit On
Imports System.ComponentModel
Imports System.IO
Imports System.Security.AccessControl
Imports DevExpress.XtraSplashScreen

Public Class FrmServerusrs
    Dim chek As Boolean = False
    Private Sub FrmServerusrs_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        Dim fs As FileSystemSecurity = File.GetAccessControl(Application.StartupPath & "\" & "ConStr.XML")
        'fs.AddAccessRule(New FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny))
        File.SetAccessControl(Application.StartupPath & "\" & "ConStr.XML", fs)
        mykey.SetValue("tmpStr", Me.TextEncrypt.Text.Trim)
    End Sub

    Private Sub FrmServerusrs_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        Dim fs As FileSystemSecurity = File.GetAccessControl(Application.StartupPath & "\" & "ConStr.XML")
        'fs.AddAccessRule(New FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny))
        File.SetAccessControl(Application.StartupPath & "\" & "ConStr.XML", fs)
    End Sub

    Private Sub FrmServerusrs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        On Error Resume Next
        If Char.IsControl(e.KeyChar) = False Then

        End If
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.ButSave_Click(sender, e)
        End If
    End Sub

    Private Sub FrmServerusrs_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.ButSave_Click(sender, e)
        End Select
    End Sub

    Private Sub FrmServerusrs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                ButSave_Click(sender, e)
        End Select
    End Sub

    Private Sub RdoLocalConnection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoLocalConnection.CheckedChanged
        If Me.RdoLocalConnection.Checked = True Then
            If chek = True Then
                ComboServerName.Items.Clear()
                LoadInstalledServer(ComboServerName)
            End If
            ComboAuth.SelectedIndex = 0
            LocalConnection = True
            Me.ComboServerName.Enabled = True
            Me.TxtServerName.Enabled = False
            Me.Port1.Enabled = False
        ElseIf Me.RdoServerConnection.Checked = True Then
            Me.ComboServerName.Enabled = False
            ComboAuth.SelectedIndex = 1
            ServerConnection = True
            Me.TxtServerName.Enabled = True
            Me.Port1.Enabled = True
        End If
    End Sub

    Private Sub RdoServerConnection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoServerConnection.CheckedChanged
        If Me.RdoLocalConnection.Checked = True Then
            If chek = True Then
                ComboServerName.Items.Clear()
                LoadInstalledServer(ComboServerName)
            End If
            ComboAuth.SelectedIndex = 0
            LocalConnection = True
            Me.ComboServerName.Enabled = True
            Me.TxtServerName.Enabled = False
            Me.Port1.Enabled = False
        ElseIf Me.RdoServerConnection.Checked = True Then
            ComboAuth.SelectedIndex = 1
            Me.ComboServerName.Enabled = False
            ServerConnection = True
            Me.TxtServerName.Enabled = True
            Me.Port1.Enabled = True
        End If
    End Sub


    Private Sub ButSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSave.Click
        Dim SB As New System.Text.StringBuilder
        Select Case Me.RdoLocalConnection.Checked
            Case True
                LocalConnection = True
                Select Case Me.ComboAuth.SelectedIndex
                    Case 0
                        AuthenicationSQLServer = False
                        SB.AppendLine(True)
                        SB.AppendLine(False)
                        SB.AppendLine(False)
                        SB.AppendLine(Me.ComboServerName.SelectedItem)
                        SB.AppendLine("/CO.JO")
                        SB.AppendLine("Port")
                        SB.AppendLine("MASCO.JO")
                        SB.AppendLine("MASCO.JO")
                        SB.AppendLine(Me.ComboDBServer.SelectedItem & "JO")
                    Case 1
                        AuthenicationSQLServer = True
                        SB.AppendLine(True) ' 1
                        SB.AppendLine(False) ' 2
                        SB.AppendLine(True) ' 3
                        SB.AppendLine(Me.ComboServerName.SelectedItem) ' 4
                        SB.AppendLine("/CO.JO") ' 5
                        SB.AppendLine("Port") ' 6
                        SB.AppendLine(Me.UserID1.Text & "MASCO.JO") ' 7
                        SB.AppendLine(Me.BWS.Text & "MASCO.JO") ' 8
                        SB.AppendLine(Me.ComboDBServer.SelectedItem & "JO") ' 9
                End Select
            Case Else
                ServerConnection = True
                AuthenicationSQLServer = True
                SB.AppendLine(False)
                SB.AppendLine(True)
                SB.AppendLine(True)
                SB.AppendLine(Me.TxtServerName.Text.Trim)
                SB.AppendLine(Me.TxtServerName.Text.Trim & "/CO.JO")
                SB.AppendLine(Me.Port1.Text)
                SB.AppendLine(Me.UserID1.Text & "MASCO.JO")
                SB.AppendLine(Me.BWS.Text & "MASCO.JO")
                SB.AppendLine(Me.ComboDBServer.SelectedItem & "JO")
                'MessageBox.Show(SB.ToString())
        End Select
        If IO.File.Exists(Application.StartupPath & "\" & "ConStr.XML") = True Then
            IO.File.WriteAllText(Application.StartupPath & "\" & "ConStr.XML", EncryptConnectionString(SB.ToString), System.Text.Encoding.UTF8)
        End If
        Me.TextEncrypt.Text = EncryptConnectionString(SB.ToString)
        mykey.SetValue("tmpStr", Me.TextEncrypt.Text.Trim)
        mykey.SetValue("URL", Me.TxtServerName.Text.Trim)
        Me.Hide()
        Me.Close()
        Dim f As New FrmLOGIN
        f.ShowDialog()
    End Sub

    Private Sub FrmLoad()
        On Error Resume Next
        'Dim fs As FileSystemSecurity = File.GetAccessControl(Application.StartupPath & "\" & "ConStr.XML")
        'fs.RemoveAccessRule(New FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny))
        'File.SetAccessControl(Application.StartupPath & "\" & "ConStr.XML", fs)
    End Sub

    Private Sub FrmServerusrs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            Me.BackgroundWorker1.WorkerSupportsCancellation = True
            Me.BackgroundWorker1.WorkerReportsProgress = True
            Me.BackgroundWorker1.RunWorkerAsync()
            FrmLOGIN.Close()
            'FrmLoad()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboAuth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboAuth.SelectedIndexChanged
        If ComboAuth.SelectedIndex = 1 And RdoLocalConnection.Checked = True Then
            AuthenicationSQLServer = True
            Me.Port1.Enabled = False
            Me.UserID1.Enabled = True
            Me.BWS.Enabled = True
            Me.CheckShowBWS.Enabled = True
            Me.UserID1.Focus()
        ElseIf ComboAuth.SelectedIndex = 1 And RdoServerConnection.Checked = True Then
            AuthenicationSQLServer = True
            Me.Port1.Enabled = True
            Me.UserID1.Enabled = True
            Me.BWS.Enabled = True
            Me.CheckShowBWS.Enabled = True
            Me.UserID1.Focus()
        ElseIf ComboAuth.SelectedIndex = 0 Then
            AuthenicationSQLServer = False
            Me.Port1.Enabled = False
            Me.UserID1.Enabled = False
            Me.BWS.Enabled = False
            Me.CheckShowBWS.Enabled = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowBWS.CheckedChanged
        If Me.CheckShowBWS.Checked = True Then
            Me.BWS.PasswordChar = ""
            Me.CheckShowBWS.Image = My.Resources.Hide_16x16
        Else
            Me.BWS.PasswordChar = "*"
            Me.CheckShowBWS.Image = My.Resources.Show_16x16
        End If
    End Sub

    Private Sub ComboServerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboServerName.SelectedIndexChanged
        Try
            If RdoLocalConnection.Checked Then
                FollCombByDataBases(ComboServerName, ComboDBServer)
            ElseIf RdoServerConnection.Checked Then
                ComboServerName.Items.Add(TxtServerName.Text)
                ComboServerName.SelectedIndex = 0
                FollCombByDataBases(ComboServerName, ComboDBServer)
            End If
        Catch ex As Exception
            Return
        End Try
    End Sub

    Private Sub ButChek_Click(sender As Object, e As EventArgs) Handles ButChek.Click
        TestSQLServerConnection(Me)
    End Sub

    Private Sub ButClos_Click(sender As Object, e As EventArgs) Handles ButClos.Click
        Me.Hide()
        Me.Close()
        Dim f As New FrmLOGIN
        f.ShowDialog()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            ToolStrip1.Enabled = False
            GroupBox1.Enabled = False
            Panel3.Enabled = False
            SplashScreenManager.ShowForm(Me, GetType(WaitForm), True, True, False)
            Dim fs As IO.FileStream
            Dim sr As IO.StreamReader
            fs = New IO.FileStream(Application.StartupPath & "\ConStr.XML", IO.FileMode.Open)
            sr = New IO.StreamReader(fs)
            TextEncrypt.Text = sr.ReadToEnd
            sr.Close()
            fs.Close()
            GeneralConnection()
            ShowSaveSettings(Me)
            If RdoLocalConnection.Checked Then LoadInstalledServer(ComboServerName)
            If AuthenicationSQLServer = True Then
                ComboAuth.SelectedIndex = 1
            Else
                ComboAuth.SelectedIndex = 0
            End If
            If ComboServerName.Items.Count > 0 Then ComboServerName.SelectedIndex = 0
            If RdoLocalConnection.Checked Then
                FollCombByDataBases(ComboServerName, ComboDBServer)
            ElseIf RdoServerConnection.Checked Then
                ComboServerName.Items.Add(TxtServerName.Text)
                ComboServerName.SelectedIndex = 0
                FollCombByDataBases(ComboServerName, ComboDBServer)
            End If
            If ServerConnection = True Then
                RdoServerConnection.Checked = True
            Else
                RdoLocalConnection.Checked = True
            End If

        Catch ex As Exception
            Return
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        SplashScreenManager.CloseForm(False)
        ToolStrip1.Enabled = True
        GroupBox1.Enabled = True
        Panel3.Enabled = True
        chek = True
    End Sub

End Class