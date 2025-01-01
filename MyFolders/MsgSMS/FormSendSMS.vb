Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Management
Imports GsmComm.GsmCommunication
Imports GsmComm.PduConverter


Public Class FormSendSMS
    Private Shared comm_Port As Short = 0
    Private Shared comm_BaudRate As Short = 0
    Private Shared comm_TimeOut As Short = 0
    Private comm As GsmCommMain






    Private dataSet As DataSet

    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim RowCount As Short = 0
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Public WithEvents BS As New BindingSource
    Dim ds1 As New DataSet
    Dim ds2 As New DataSet
    Dim ds3 As New DataSet

    'Public Sub New(port As Integer, baudRate As Integer, timeout As Integer)
    '    comm = New GsmCommMain(port, baudRate, timeout)
    '    AddHandler comm.MessageReceived, AddressOf OnMessageReceived
    'End Sub


    'Public Sub Connect()
    '    comm.Open()
    '    If comm.IsConnected() Then
    '        Console.WriteLine("Connected to GSM modem.")
    '    Else
    '        Console.WriteLine("Failed to connect.")
    '    End If
    'End Sub

    'Public Sub SendMessage(phoneNumber As String, message As String)
    '    Dim pdu As SmsSubmitPdu = New SmsSubmitPdu(message, phoneNumber)
    '    comm.SendMessage(pdu)
    'End Sub


    'Private Sub OnMessageReceived(sender As Object, e As MessageReceivedEventArgs)
    '    Dim pdu As SmsDeliverPdu = CType(e.IndicationObject, SmsDeliverPdu)
    '    Console.WriteLine("Message received from: " & pdu.OriginatingAddress)
    '    Console.WriteLine("Message: " & pdu.UserDataText)
    'End Sub



    Private Sub ButSingle_SMS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButSingle_SMS.Click
        Dim CELL_Number, SMS_Message As String
        Dim pdu1 As SmsSubmitPdu
        Try
            If Comm.IsConnected() = True Then
                If Cell_Num.Text.ToString() = "" Then
                    MessageBox.Show("ارجو اضافة رقم الهاتف" & vbCrLf & vbLf & "علي سبيل المثال" & vbLf & vbLf & "+962777123456", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                ElseIf SMS_Text.Text.ToString() = "" Then
                    MessageBox.Show("ارجو إضافة نص رسالتك", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
                CELL_Number = Cell_Num.Text.ToString()
                SMS_Message = SMS_Text.Text.ToString()
                MessageBox.Show(" الخاصة بك" & "SMS" & "ارجو إعادة التحقق من الرسائل " & "CELL NUMBER " & vbCrLf & vbLf & "CELL # : " & CELL_Number & vbCrLf & vbLf & "MESSAGE TEXT : " & SMS_Message, "SMS INFO", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                Try
                    Cursor.Current = Cursors.WaitCursor
                    Dim dcs As Byte = CByte(DataCodingScheme.GeneralCoding.Alpha16Bit)
                    pdu1 = New SmsSubmitPdu(SMS_Message, CELL_Number, dcs)
                    Comm.SendMessage(pdu1)
                    Cursor.Current = Cursors.[Default]
                    MessageBox.Show("MESSAGE - SENT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch E5 As Exception
                    MessageBox.Show("Error Sending SMS To Destination Address" & vbCrLf & vbLf & " Connection Has Been Terminated !!!" & vbCrLf & vbLf, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    Comm.Close()
                    pictureBox3.Image = imageList1.Images(0)
                    ButGetPort.Enabled = True
                    ButPortDisconnect.Enabled = False
                    ButSingle_SMS.Enabled = False
                    ButSingle_SMSALL.Enabled = False
                    ButCheckTheValues.Enabled = False
                    dataGridView3.Rows.Clear()
                    Phone_Model.Text = "....."
                    Phone_Name.Text = "....."
                    Revision_Num.Text = "....."
                    Serial_Num.Text = "....."
                End Try
            Else
                MessageBox.Show("No GSM Phone / Modem Connected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        Catch E10 As Exception
            MessageBox.Show("CONNECTION ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:
            'On Error Resume Next
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                If Me.RB1.Checked = True Then
                    .CommandText = "SELECT  cust13 FROM AllCustomers  WHERE  CUser='" & CUser & "' and cust33 ='" & True & "'"
                    Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
                    Me.ds1.Clear()
                    Me.ds1 = New DataSet
                    Me.SqlDataAdapter1.Fill(Me.ds1, "AllCustomers")
                ElseIf Me.RB2.Checked = True Then
                    .CommandText = "SELECT  cust13 FROM AllCustomers  WHERE  CUser='" & CUser & "' and cust33 ='" & False & "'"
                    Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
                    Me.ds2.Clear()
                    Me.ds2 = New DataSet
                    Me.SqlDataAdapter1.Fill(Me.ds2, "AllCustomers")
                ElseIf Me.RB3.Checked = True Then
                    .CommandText = "SELECT  EMP4 FROM EMPLOYEES  WHERE  CUser='" & CUser & "'"
                    Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
                    Me.ds3.Clear()
                    Me.ds3 = New DataSet
                    Me.SqlDataAdapter1.Fill(Me.ds3, "EMPLOYEES")
                End If
            End With
            Consum.Open()
            'Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), New Object() {})
            Consum.Close()
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            Consum.Close()
        End Try
    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then
                Me.label2.ForeColor = Color.Yellow
                Me.label2.Text = "... تم الاتصال بالانترنت"
            Else
                Me.label2.ForeColor = Color.Red
                Me.label2.Text = "الاتصال بالانترنت غير متوفر"
                Me.Close()
            End If
        End If
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            If Me.RB1.Checked = True Then
                Me.BS.DataSource = Me.ds1.Tables("AllCustomers")
            ElseIf Me.RB2.Checked = True Then
                Me.BS.DataSource = Me.ds2.Tables("AllCustomers")
            ElseIf Me.RB3.Checked = True Then
                Me.BS.DataSource = Me.ds3.Tables("EMPLOYEES")
            End If
            Me.dataGridView1.DataSource = Me.BS
            Me.RowCount = Me.BS.Count
            'For i = 0 To dataGridView1.RowCount - 1 - 1
            'Me.Label6.Text = Mid(Me.dataGridView1.Rows(0).Cells(0).Value.ToString(), 2, 9)
            'Next
            If Me.dataGridView1.RowCount > 0 Then
                Me.ButCheckTheValues.Enabled = True
                Me.ButSingle_SMSALL.Enabled = True
            End If
            Me.dataGridView1.Columns(0).HeaderText = "رقم الخلوي"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Consum.Close()

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.tabPage1.BackgroundImage = img
        Me.tabPage2.BackgroundImage = img
        Me.tabPage4.BackgroundImage = img
        ButPortDisconnect.Enabled = False


        Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()

        Me.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        With Me.dataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
    End Sub
    Private Sub RB1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB1.CheckedChanged
        Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()
        Me.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        With Me.dataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
    End Sub
    Private Sub RB2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB2.CheckedChanged
        Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()
        Me.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        With Me.dataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
    End Sub
    Private Sub RB3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB3.CheckedChanged
        Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()
        Me.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        With Me.dataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
    End Sub
    Private Sub ButOpenFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButOpenFile.Click
        Dim rows_counting As Integer
        Me.OpenFileDialog1.Filter = "SMS Sending File|*.xlsx|SMS Sending File|.xls*"

        Me.OpenFileDialog1.Title = "Select Excel File For SMS"
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            MessageBox.Show("You Press Cancelled :-) !!!")
        Else
            Dim sms_filename As String = OpenFileDialog1.FileName
            If System.IO.File.Exists(sms_filename) Then
                Try
                    Cursor.Current = Cursors.WaitCursor
                    Dim connectionString As String = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", sms_filename)
                    Dim query As String = String.Format("select * from [{0}$]", "SMS")
                    Dim dataAdapter As New OleDbDataAdapter(query, connectionString)
                    dataSet = New DataSet()
                    dataAdapter.Fill(dataSet)
                    Me.dataGridView1.DataSource = Nothing
                    Me.dataGridView1.Columns.Clear()
                    Me.dataGridView1.DataSource = dataSet.Tables(0)
                    Me.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
                    rows_counting = Me.dataGridView1.RowCount - 1
                    Dim column_counting1 As Integer = Me.dataGridView1.ColumnCount
                    If column_counting1 < 2 OrElse column_counting1 > 2 Then
                        MessageBox.Show("Please Check Column Count in Excel Sheet !!!" & vbCrLf & vbLf & "There Should Be Only Two Columns in Sheet Like Below" & vbCrLf & vbLf & "CELL NUMBER ", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        Return
                    End If
                    If Me.dataGridView1.Columns(0).Name.ToString().ToUpper() = "CELL NUMBER" Then
                        Me.label25.Text = "Total SMS In Excel File " & rows_counting
                        MessageBox.Show("!!!...تم استيراد البيانات بنجاح" & vbCrLf & vbLf & "!!!..... SMS تحقق من القيم المستوردة & أرسل رسالة ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.ButCheckTheValues.Enabled = True
                        Me.ButSingle_SMSALL.Enabled = True
                        Cursor.Current = Cursors.[Default]
                    Else
                        MessageBox.Show("Column Names Are Not In Specified Format !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        Return
                    End If
                Catch E6 As Exception
                    'MessageBox.Show(E6.Message, "ErrorClosing", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MessageBox.Show("Error Loading Excel FIle" & vbCrLf & vbLf & "Please Check Worksheet Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    Return
                End Try
            End If
        End If
    End Sub


    Private Sub ButSingle_SMSALL_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButSingle_SMSALL.Click
        Dim MSMS_Number, MMessage As String
        Dim i As Integer
        Dim pdu3 As SmsSubmitPdu
        Try
            If Comm.IsConnected() = True Then
                Try
                    Cursor.Current = Cursors.WaitCursor
                    Dim dcs As Byte = CByte(DataCodingScheme.GeneralCoding.Alpha16Bit)
                    For i = 0 To dataGridView1.RowCount - 1 - 1
                        MSMS_Number = "+962" & Mid(Me.dataGridView1.Rows(0).Cells(0).Value.ToString(), 2, 9)
                        ''Me.dataGridView1.Rows(i).Cells(0).Value.ToString()
                        Me.Label6.Text = MSMS_Number
                        MMessage = SMS_Text.Text.ToString()
                        pdu3 = New SmsSubmitPdu(MMessage, MSMS_Number, dcs)
                        Comm.SendMessage(pdu3)
                        System.Threading.Thread.Sleep(1000)
                    Next
                    Cursor.Current = Cursors.[Default]
                    MessageBox.Show("T O T A L - M E S S A G E - S E N T = " & i, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch E23 As Exception
                    MessageBox.Show("Error Sending SMS To Destination Address" & vbCrLf & vbLf & " Connection Has Been Terminated !!!" & vbCrLf & vbLf, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    Comm.Close()
                    pictureBox3.Image = imageList1.Images(0)
                    ButGetPort.Enabled = True
                    ButPortDisconnect.Enabled = False
                    dataGridView3.Rows.Clear()
                    dataSet.Clear()
                    dataGridView1.Refresh()
                    ButSingle_SMSALL.Enabled = False
                    ButCheckTheValues.Enabled = False
                    ButSingle_SMS.Enabled = False
                    Phone_Model.Text = "....."
                    Phone_Name.Text = "....."
                    Revision_Num.Text = "....."
                    Serial_Num.Text = "....."
                End Try
            Else
                MessageBox.Show("No GSM Phone / Modem Connected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ButSingle_SMSALL.Enabled = False
                ButCheckTheValues.Enabled = False
                Return
            End If
        Catch E7 As Exception
            label25.Text = "M U L T I P L E  -  S M S  -  I N F O"
            dataSet.Clear()
            dataGridView1.Refresh()
            ButSingle_SMSALL.Enabled = False
            ButCheckTheValues.Enabled = False
            MessageBox.Show("Error Sending SMS Messages" & vbCrLf & vbLf & "Please Check Connection" & vbLf & vbLf & "Network Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub ButCheckTheValues_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButCheckTheValues.Click
        For i As Integer = 0 To dataGridView1.RowCount - 1 - 1
            For j As Integer = 0 To dataGridView1.ColumnCount - 1
                If dataGridView1.Rows(i).Cells(j).Value.ToString() = "" OrElse dataGridView1.Rows(i).Cells(j).Value.ToString().ToUpper() = "-" OrElse dataGridView1.Rows(i).Cells(j).Value.ToString().Length < 10 OrElse dataGridView1.Rows(i).Cells(j).Value.ToString().Length > 160 Then
                    dataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Red
                Else
                    dataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Green
                End If
                ButSingle_SMSALL.Enabled = True
            Next
        Next
    End Sub

    Private Sub ButGetPort_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButGetPort.Click
        dataGridView3.ColumnCount = 5
        dataGridView3.Columns(0).Name = "COM Port"
        dataGridView3.Columns(1).Name = "Connected Device"
        dataGridView3.Columns(2).Name = "Max Baud Rate"
        dataGridView3.Columns(3).Name = "Time Out"
        dataGridView3.Columns(4).Name = "Status"
        'dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_SerialPort")
            For Each queryObj As ManagementObject In searcher.[Get]()
                If queryObj IsNot Nothing Then
                    Dim captionObj As Object = queryObj("DESCRIPTION")
                    Dim capdeviceid As Object = queryObj("DEVICEID")
                    Dim MaxBaudRate As Object = queryObj("MAXBAUDRATE")
                    Dim connstatus As Object = queryObj("STATUS")
                    Dim timeoutsec As String = "100"
                    dataGridView3.Rows.Add(capdeviceid, captionObj, MaxBaudRate, timeoutsec, connstatus)
                End If
            Next
        Catch e15 As Exception
            MessageBox.Show("An error occurred while querying for WMI data: " & e15.Message)
        End Try
        Cursor.Current = Cursors.[Default]
        ButGetPort.Enabled = False
        ButPortDisconnect.Enabled = True
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.ButSingle_SMS.Enabled = True
        Me.PictureBox1.Visible = False
        Me.Label5.Visible = False
    End Sub
    Private Sub DataGridView3_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dataGridView3.CellClick
        Dim style As New DataGridViewCellStyle With {
            .Font = New Font(dataGridView3.Font, FontStyle.Bold),
            .BackColor = Color.Green,
            .ForeColor = Color.White
        }
        Me.PictureBox1.Visible = True
        Me.Label5.Visible = True
        ButSingle_SMS.Enabled = False
        Dim i As Integer = dataGridView3.CurrentRow.Index
        Try
            Comm_Port = Convert.ToInt16(dataGridView3.Rows(i).Cells(0).Value.ToString().Substring(3))
            'Comm_BaudRate = Convert.ToInt32(dataGridView3.Rows(i).Cells(2).Value.ToString())
            comm_TimeOut = Convert.ToInt32(dataGridView3.Rows(i).Cells(3).Value.ToString())
        Catch E1 As Exception
            Me.PictureBox1.Visible = False
            Me.Label5.Visible = False
            'MessageBox.Show("COM" & "خطأ في تحويل قيم إعدادات منفذ", "Check COM Port Values", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MessageBox.Show(E1.Message, "ErrorThreadTask", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End Try
        comm = New GsmCommMain(comm_Port, 115200, comm_TimeOut)
        Try
            Comm.Open()
            If Comm.IsConnected() Then
                pictureBox3.Image = imageList1.Images(1)
                MessageBox.Show("Connected Successfully To GSM Phone / Modem...!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dataGridView3.Rows(i).Cells(4).Value = "Connected"
                dataGridView3.Rows(i).DefaultCellStyle = style
                dataGridView3.ClearSelection()
                ButSingle_SMS.Enabled = True
            End If
            Try
                Phone_Name.Text = Comm.IdentifyDevice().Manufacturer.ToUpper().ToString()
                Phone_Model.Text = Comm.IdentifyDevice().Model.ToUpper().ToString()
                Revision_Num.Text = Comm.IdentifyDevice().Revision.ToUpper().ToString()
                Serial_Num.Text = Comm.IdentifyDevice().SerialNumber.ToUpper().ToString()
                pictureBox3.Image = imageList1.Images(2)
                Me.PictureBox1.Visible = False
                Me.Label5.Visible = False
            Catch e50 As Exception
                pictureBox3.Image = imageList1.Images(0)
                Me.PictureBox1.Visible = False
                Me.Label5.Visible = False
                MessageBox.Show("COM" & "خطأ في استرداد معلومات هاتف", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        Catch E2 As Exception
            pictureBox3.Image = imageList1.Images(0)
            Me.PictureBox1.Visible = False
            Me.Label5.Visible = False
            MessageBox.Show("Error While Connecting To GSM Phone / Modem", "Information", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            dataGridView3.ClearSelection()
        End Try
        'Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        'Me.BackgroundWorker1.WorkerReportsProgress = True
        'Me.BackgroundWorker1.WorkerSupportsCancellation = True
        'Me.BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub ButPortDisconnect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButPortDisconnect.Click
        Try
            If Not Comm.IsConnected() Then
                MessageBox.Show("No Phone Connected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            Else
                Comm.Close()
                pictureBox3.Image = imageList1.Images(0)
                ButGetPort.Enabled = True
                ButPortDisconnect.Enabled = False
                ButSingle_SMS.Enabled = False
                ButSingle_SMSALL.Enabled = False
                ButCheckTheValues.Enabled = False
                dataGridView3.Rows.Clear()
                Phone_Model.Text = "....."
                Phone_Name.Text = "....."
                Revision_Num.Text = "....."
                Serial_Num.Text = "....."
                MessageBox.Show("Disconnected Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch No_Conn As Exception
            MessageBox.Show("No Phone Connected!!" & " " & vbCrLf & vbLf, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub FormSendSMS_FormClosed1(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If Comm.IsOpen() = True Then
                Comm.Close()
            End If

        Catch E16 As Exception
            'Application.[Exit]()
        End Try

        'Application.[Exit]()
    End Sub
    Private Sub SMS_Text_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SMS_Text.TextChanged
        label4.Text = "Characters Left : " & (160 - SMS_Text.Text.Length).ToString()
    End Sub

End Class



