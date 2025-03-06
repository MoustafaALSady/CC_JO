
'Imports PCComm
Imports System.IO.Ports
Public Class FormSMS
    Private ReadOnly comm As New CommManager()
    Private ReadOnly transType As String = String.Empty
    ReadOnly SerialPort As New System.IO.Ports.SerialPort()
    ReadOnly CR As String
    Private Sub CboPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPort.SelectedIndexChanged
        comm.PortName = cboPort.Text()
    End Sub

    ''' <summary>
    ''' Method to initialize serial port
    ''' values to standard defaults
    ''' </summary>
    Private Sub SetDefaults()
        cboPort.SelectedIndex = 0
        cboBaud.SelectedText = "9600"
        cboParity.SelectedIndex = 0
        cboStop.SelectedIndex = 1
        cboData.SelectedIndex = 1

    End Sub
    ''' <summary>
    ''' methos to load our serial
    ''' port option values
    ''' </summary>
    Private Sub LoadValues()
        CommManager.SetPortNameValues(cboPort)
        CommManager.SetParityValues(cboParity)
        CommManager.SetStopBitValues(cboStop)
    End Sub

    ''' <summary>
    ''' method to set the state of controls
    ''' when the form first loads
    ''' </summary>
    Private Sub SetControlState()
        rdoText.Checked = True
        cmdSend.Enabled = False
        cmdClose.Enabled = False
    End Sub

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadValues()
        SetDefaults()
        SetControlState()
    End Sub

    Private Sub CmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        comm.ClosePort()
        SetControlState()
        SetDefaults()
    End Sub

    Private Sub CmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpen.Click
        comm.Parity = cboParity.Text
        comm.StopBits = cboStop.Text
        comm.DataBits = cboData.Text
        comm.BaudRate = cboBaud.Text
        comm.DisplayWindow = rtbDisplay
        comm.OpenPort()


        cmdOpen.Enabled = False
        cmdClose.Enabled = True
        cmdSend.Enabled = True
    End Sub

    Private Sub CmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click

        'comm.WriteData("AT")
        'comm.WriteData("AT + CMGF = 1" & vbCrLf) '"تعيين تنسيق رسالة الأمر إلى وضع النص (1) 
        'comm.WriteData("AT + CMGS =" & phoneNumBox.Text & vbCrLf)
        ''_ContSMS = False
        'comm.WriteData(txtSend.Text & vbCrLf & Chr(26)) ' إرسال' الرسائل القصيرة
        comm.Message = txtSend.Text
        comm.ClosePort()
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
        End If
        With SerialPort1
            .PortName = cboPort.Text
            .BaudRate = cboBaud.Text
            .Parity = Parity.None
            .DataBits = cboData.Text
            .StopBits = cboStop.Text
            .Handshake = Handshake.RequestToSend
            .DtrEnable = True
            .RtsEnable = True
            .NewLine = vbCrLf
        End With
        SerialPort1.Open()
        If SerialPort1.IsOpen = True Then
            'sending AT commands
            SerialPort1.WriteLine("AT")
            SerialPort1.WriteLine("AT+CMGF=1" & vbCrLf) 'set command message format to text mode(1)
            SerialPort1.WriteLine("AT+CSCA=""+96277000161""" & vbCrLf) 'set service center address (which varies for service providers (idea, airtel))
            SerialPort1.WriteLine("AT+CMGS=  + phoneNumBox.text + " & vbCrLf) ' enter the mobile number whom you want to send the SMS
            '_ContSMS = False
            SerialPort1.WriteLine("+ txtSend.text +" & vbCrLf & Chr(26)) 'SMS sending
            MessageBox.Show(":send")
            SerialPort1.Close()
        End If
        comm.OpenPort()
        comm.Message = txtSend.Text
        comm.Type = CommManager.MessageType.Normal
        comm.WriteData(txtSend.Text)
        txtSend.Text = String.Empty
        PictureBox2.Visible = False
        txtSend.Focus()
    End Sub

    Private Sub RdoHex_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHex.CheckedChanged
        If rdoHex.Checked() Then
            comm.CurrentTransmissionType = CommManager.TransmissionType.Hex
        Else
            comm.CurrentTransmissionType = CommManager.TransmissionType.Text
        End If
    End Sub

    Private Sub CboBaud_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBaud.SelectedIndexChanged
        comm.BaudRate = cboBaud.Text()
    End Sub

    Private Sub CboParity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboParity.SelectedIndexChanged
        comm.Parity = cboParity.Text()
    End Sub

    Private Sub CboStop_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStop.SelectedIndexChanged
        comm.StopBits = cboStop.Text()
    End Sub

    Private Sub CboData_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboData.SelectedIndexChanged
        comm.StopBits = cboStop.Text()
    End Sub


End Class