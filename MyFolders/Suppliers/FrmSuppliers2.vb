Option Explicit Off
Imports System.Data.SqlClient
Public Class FrmSuppliers2
<<<<<<< HEAD
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter
=======
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Private ReadOnly account_noF As String
    Private ReadOnly ACCF As String
    Private ReadOnly account_nameF As String
    ReadOnly p As Integer
    Dim dt1 As Date
    ReadOnly nem, nem1, nem2, nem3 As String
<<<<<<< HEAD
    Private Sub FrmSuppliers1_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmSuppliers2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub FrmSuppliers1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmSuppliers2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.F1
                Case Keys.F1
                    Me.ADDBUTTON_Click(sender, e)
                Case Keys.F2
                    Me.SAVEBUTTON_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub FrmSuppliers2_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmSuppliers2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboSupplierName)
        Me.SHOWBUTTON()
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboSupplierName, e, )
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboPaymentMethod, e, )
    End Sub
    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboCheckDrawerName, e, )
    End Sub
    Private Sub TEXTBOX9_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboSupplierName, e, )
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboPaymentMethod, e, )
    End Sub
    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboCheckDrawerName, e, )
    End Sub
    Private Sub TEXTBOX9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        AutoComplete(Me.TEXTStatement, e, )
    End Sub
    Private Sub SAVERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As String = "INSERT INTO Suppliers1(IDCAB, CAB2, CAB3, CAB4, CAB5, CAB6, CAB7, CAB8, CAB9, CAB10, CAB11, CAB12, CAB13, CAB14, CAB15, CAB16, CAB17, CAB18, CAB19, CAB20, CAB21, CAB22, CAB23, CB1, BN2, USERNAME, Cuser, COUser, da, ne) VALUES  (@IDCAB,  @CAB2, @CAB3, @CAB4, @CAB5, @CAB6, @CAB7, @CAB8, @CAB9, @CAB10, @CAB11, @CAB12, @CAB13, @CAB14, @CAB15, @CAB16, @CAB17, @CAB18, @CAB19, @CAB20, @CAB21, @CAB22, @CAB23, @CB1, @BN2, @USERNAME, @Cuser, @COUser, @da, @ne)"
            Dim cmd As New SqlCommand(SQL, Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO Suppliers1(IDCAB, CAB2, CAB3, CAB4, CAB5, CAB6, CAB7, CAB8, CAB9, CAB10, CAB11, CAB12, CAB13, CAB14, CAB15, CAB16, CAB17, CAB18, CAB19, CAB20, CAB21, CAB22, CAB23, CB1, BN2, USERNAME, Cuser, COUser, da, ne) VALUES  (@IDCAB,  @CAB2, @CAB3, @CAB4, @CAB5, @CAB6, @CAB7, @CAB8, @CAB9, @CAB10, @CAB11, @CAB12, @CAB13, @CAB14, @CAB15, @CAB16, @CAB17, @CAB18, @CAB19, @CAB20, @CAB21, @CAB22, @CAB23, @CB1, @BN2, @USERNAME, @Cuser, @COUser, @da, @ne)"
            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDCAB", SqlDbType.BigInt).Value = TEXTID.EditValue
                .Parameters.Add("@CAB2", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text
                .Parameters.Add("@CAB3", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CAB4", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@CAB5", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@CAB6", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@CAB7", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text
                .Parameters.Add("@CAB8", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@CAB9", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@CAB10", SqlDbType.NVarChar).Value = Me.ComboSupplierName.Text
                .Parameters.Add("@CAB11", SqlDbType.NVarChar).Value = Me.TextSupplierNumber.Text
                .Parameters.Add("@CAB12", SqlDbType.NVarChar).Value = Me.ComboCondition.Text
                .Parameters.Add("@CAB13", SqlDbType.Bit).Value = False
                .Parameters.Add("@CAB14", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@CAB15", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@CAB16", SqlDbType.NVarChar).Value = Me.ComboSource.Text
                .Parameters.Add("@CAB17", SqlDbType.Bit).Value = False
                .Parameters.Add("@CAB18", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.Text
                .Parameters.Add("@CAB19", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckBox1.Checked)
                .Parameters.Add("@CAB20", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@CAB21", SqlDbType.Int).Value = Val(Me.TextCheckDrawerCode.Text)
                .Parameters.Add("@CAB22", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@CAB23", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text

                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
<<<<<<< HEAD
            MessageBox.Show(ex.Message, "Error SAVERECORD", MessageBoxButtons.OK, MessageBoxIcon.Error)
=======
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        End Try
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try

1:          Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "Suppliers1")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                Me.PictureBox2False()
                TestNet = False
                e.Cancel = True
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                Me.PictureBox2False()
                e.Cancel = True
                MessageBox.Show(ex.Message, "Error3", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.myds.Tables("Suppliers1")
            Me.PictureBox2.Visible = False
            Me.TEXTCredit.Enabled = True
            Me.Cursor = Cursors.Default
            If DelRow = False Then
                If Me.BS.Count < Me.RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 48 + 524288, "تحديث السجلات")
                ElseIf Me.BS.Count > Me.RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 48 + 524288, "تحديث السجلات")
                End If
            Else
                DelRow = False
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error4", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try

1:
            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()

            'SqlDataAdapter1.Update(myds, "Suppliers1")
            'myds = New DataSet
            'SqlDataAdapter1.Fill(myds, "Suppliers1")
            'myds.RejectChanges()
        Catch ex As Exception
            If ex.Message.GetHashCode = -1115812848 Or ex.Message.GetHashCode = 379362862 Then
                e.Cancel = True
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                e.Cancel = True
                TestNet = False
                PictureBox2False()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            ElseIf ex.Message.GetHashCode = -652120241 Or ex.Message.GetHashCode = 2067669773 Then
                DelRow = True
                Me.PictureBox2False()
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
            Else
                e.Cancel = True
                PictureBox2False()
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
<<<<<<< HEAD
                Me.RefreshTab = New ComponentModel.BackgroundWorker With {
=======
                Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    .WorkerReportsProgress = True,
                    .WorkerSupportsCancellation = True
                }
                Me.RefreshTab.RunWorkerAsync()
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = Me.myds.Tables("Suppliers1")
            Me.TEXTCredit.Enabled = True
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False

            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            If Click1 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "حفظ", Me.Text)
=======
            Dim Sound As System.IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            If Click1 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue.Trim, "حفظ", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click2 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue.Trim, "تعديل", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click3 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue.Trim, "الارصدة", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            End If
            Click1 = False
            Click2 = False
            Click3 = False
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error6", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.PictureBox4.Visible = False
            Me.PictureBox5.Visible = False
            Me.ComboSupplierName.Focus()
            Me.ComboSupplierName.SelectAll()
        End If
    End Sub

<<<<<<< HEAD
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
=======
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Call MangUsers()
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            CLEARDATA1(Me)
            Application.DoEvents()
            Me.BS.CancelEdit()

            Me.BS.Position = Me.BS.Count - 1

            Me.BS.EndEdit()
            Me.BS.AddNew()
            CLEARDATA1(Me)

            GetAutoNumber("IDCAB", "Suppliers1", "CAB3")
            Me.TEXTID.EditValue = AutoNumber
            Me.TEXTDebit.EditValue = 0
            Me.TEXTCredit.EditValue = 0
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            If ComboBN2.Items.Count > 0 Then
                Me.ComboBN2.SelectedIndex = 0
            End If
            FundBalance()
            Me.dt1 = MaxDate.ToString("yyyy-MM-dd")
            Me.DateMovementHistory.Value = MaxDate.ToString("yyyy-MM-dd")
            Me.TextDateMovementHistory.Text = Me.DateMovementHistory.Value
            Me.ComboSource.Text = "الموردين"
            Me.ComboCondition.Text = "نقدا"
            Me.TEXTDocumentNumber.Text = Me.TEXTID.EditValue
            Me.TEXTStatement.Text = "حركات الموردين"
            Me.ComboPaymentMethod.Text = "نقدا"
            Me.TextMovementSymbol.Text = "SU" & Me.TEXTID.EditValue
            Me.TextDateMovementHistory.Focus()
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.addv
=======
            Dim Sound As System.IO.Stream = My.Resources.addv
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
=======
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockSave = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.ComboPaymentMethod.Text = "شيك" Then
            If Me.ComboCheckDrawerName.Text = "" Then
                MsgBox("يجب إدخال اسم ساحب الشيك", 16, "تنبيه")
                Me.ComboCheckDrawerName.Focus()
                Exit Sub
            End If
            If Me.TextCheckNumber.Text = "" Then
                MsgBox("يجب إدخال رقم الشيك", 16, "تنبيه")
                Me.TextCheckNumber.Focus()
                Exit Sub
            End If
            If Me.CheckDate.Value = Nothing Then
                MsgBox("يجب إدخال تاريخ الشيك", 16, "تنبيه")
                Me.CheckDate.Focus()
                Exit Sub
            End If
        ElseIf Me.ComboPaymentMethod.Text = "نقدا_شيك" Then
            If Me.ComboCheckDrawerName.Text = "" Then
                MsgBox("يجب إدخال اسم ساحب الشيك", 16, "تنبيه")
                Me.ComboCheckDrawerName.Focus()
                Exit Sub
            End If
            If Me.TextCheckNumber.Text = "" Then
                MsgBox("يجب إدخال رقم الشيك", 16, "تنبيه")
                Me.TextCheckNumber.Focus()
                Exit Sub
            End If
            If Me.CheckDate.Value = Nothing Then
                MsgBox("يجب إدخال تاريخ الشيك", 16, "تنبيه")
                Me.CheckDate.Focus()
                Exit Sub
            End If
        End If
        Static P As Integer
        P = Me.BS.Count
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.SAVERECORD()
        Me.BS.EndEdit()
        Me.RowCount = BS.Count
<<<<<<< HEAD
        Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Me.SAVEBUTTON.Enabled = False
        Click1 = True
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX3_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
=======
    Private Sub TEXTBOX3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX11_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
=======
    Private Sub TEXTBOX11_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX12_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
=======
    Private Sub TEXTBOX12_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter

        End Select
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX14_KeyUp1(ByVal sender As Object, ByVal e As KeyEventArgs)
=======
    Private Sub TEXTBOX14_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter

        End Select
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX4_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTDebit.DoubleClick
        On Error Resume Next
        Me.TEXTDebit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX5_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTCredit.DoubleClick
        On Error Resume Next
        Me.TEXTCredit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTPreviousBalance.TextChanged, TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged, TEXTCurrentBalance.TextChanged
=======
    Private Sub TEXTBOX4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTDebit.DoubleClick
        On Error Resume Next
        Me.TEXTDebit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX5_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTCredit.DoubleClick
        On Error Resume Next
        Me.TEXTCredit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTPreviousBalance.TextChanged, TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged, TEXTCurrentBalance.TextChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTCredit.EditValue) - Val(Me.TEXTDebit.EditValue), "0.000")
        On Error Resume Next
        If Val(Me.TEXTCurrentBalance.Text) = "0" Then
            Me.CheckBox1.Checked = True
        Else
            Me.CheckBox1.Checked = False
        End If
        If Val(Me.TEXTDebit.EditValue) = "0" Then
            Me.ComboPaymentMethod.Text = "نقدا"
            'Me.ComboPaymentMethod.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.GroupCHKS1.Enabled = False
        Else
            Me.ComboPaymentMethod.Enabled = True
            Me.GroupCHKS.Enabled = True
            Me.GroupCHKS1.Enabled = True
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX4_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTDebit.KeyPress
=======
    Private Sub TEXTBOX4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTDebit.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If (e.KeyChar < "0" Or e.KeyChar > "9") And Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboSupplierName.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT sup1,sup2,cuser,couser  FROM SUPPLIER WHERE sup2 ='" & Me.ComboSupplierName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboSupplierName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT sup1,sup2,cuser,couser  FROM SUPPLIER WHERE sup2 ='" & Me.ComboSupplierName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextSupplierNumber.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextSupplierNumber.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
<<<<<<< HEAD
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioResetText.CheckedChanged
=======
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioResetText.CheckedChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Call Me.AddType1()
    End Sub
    Private Sub AddType1()
        On Error Resume Next
        If RadioAllCustomers.Checked = True Then
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioSUPPLIER.Checked = True Then
            FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioEMPLOYEES.Checked = True Then
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboCheckDrawerName)
        Else
            Me.ComboCheckDrawerName.ResetText()
        End If
        Me.ComboCheckDrawerName.Focus()
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
            If RadioAllCustomers.Checked = True Then
                Dim Adp As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If RadioAllCustomers.Checked = True Then
                Dim Adp As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds.Clear()
                Adp.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                End If
                Adp.Dispose()
                Consum.Close()
            ElseIf RadioSUPPLIER.Checked = True Then
<<<<<<< HEAD
                Dim Adp1 As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds1 As New DataSet
                Adp1 = New SqlDataAdapter(strsql)
=======
                Dim Adp1 As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds1 As New DataSet
                Adp1 = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds1.Clear()
                Adp1.Fill(ds1)
                If ds1.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds1.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                End If
                Adp1.Dispose()
                Consum.Close()
            ElseIf RadioEMPLOYEES.Checked = True Then
<<<<<<< HEAD
                Dim Adp2 As SqlDataAdapter
                Dim strsq2 As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds2 As New DataSet
                Adp2 = New SqlDataAdapter(strsq2)
=======
                Dim Adp2 As SqlClient.SqlDataAdapter
                Dim strsq2 As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds2 As New DataSet
                Adp2 = New SqlClient.SqlDataAdapter(strsq2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds2.Clear()
                Adp2.Fill(ds2)
                If ds2.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds2.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                End If
                Adp2.Dispose()
                Consum.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboCheckDrawerName", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



<<<<<<< HEAD
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
=======
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = False
                Me.TextFundValue.EditValue = "0.000"
                Me.TextValueOfCheck.EditValue = "0.000"
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
            Case "شيك"
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.Enabled = False
                Me.TextFundValue.EditValue = "0.000"
                Me.TextValueOfCheck.EditValue = "0.000"
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
            Case "نقدا_شيك"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.EditValue = "0.000"
                Me.TextValueOfCheck.EditValue = "0.000"
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
        End Select
    End Sub


    Private Sub FundBalance()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub
<<<<<<< HEAD
    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCB1.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCB1.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            CB2 = ds.Tables(0).Rows(0).Item(0)
        Else
            CB2 = ""
        End If
        Adp.Dispose()
        Consum.Close()
        FundBalance()
    End Sub
<<<<<<< HEAD
    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBN2.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT BN3,BN4    FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBN2.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT BN3,BN4    FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextBN3.Text = ds.Tables(0).Rows(0).Item(0)
            BN4 = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TextBN3.Text = ""
            BN4 = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
End Class