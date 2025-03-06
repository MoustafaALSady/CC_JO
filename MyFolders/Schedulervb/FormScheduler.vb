Imports System.ComponentModel
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing
Imports DevExpress.XtraSplashScreen

Public Class FormScheduler
    Private Sub FormScheduler_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.BackgroundWorker1.WorkerSupportsCancellation = True
        'Me.BackgroundWorker1.WorkerReportsProgress = True
        'Me.BackgroundWorker1.RunWorkerAsync()


        'TODO: This line of code loads data into the 'DataSetScheduler.Resources' table. You can move, or remove it, as needed.
        Me.ResourcesTableAdapter.Fill(Me.DataSetScheduler.Resources, CUser)

        'TODO: This line of code loads data into the 'DataSetScheduler.Appointments' table. You can move, or remove it, as needed.
        Me.AppointmentsTableAdapter.Fill(Me.DataSetScheduler.Appointments, CUser)

        SchedulerControl1.WorkDays.BeginUpdate()
        SchedulerControl1.WorkDays.Clear()
        SchedulerControl1.WorkDays.Add(WeekDays.Sunday Or WeekDays.Monday Or WeekDays.Tuesday Or WeekDays.Wednesday Or WeekDays.Thursday)
        SchedulerControl1.WorkDays.EndUpdate()

    End Sub

<<<<<<< HEAD
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
=======
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'SplashScreenManager.ShowForm(Me, GetType(WaitForm), True, True, False)

    End Sub


    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'SplashScreenManager.CloseForm(False)
    End Sub
    Private Sub SchedulerDataStorage1_AppointmentsChanged(sender As Object, e As PersistentObjectsEventArgs) Handles SchedulerDataStorage1.AppointmentsInserted, SchedulerDataStorage1.AppointmentsDeleted, SchedulerDataStorage1.AppointmentsChanged
        AppointmentsTableAdapter.Update(DataSetScheduler)
        DataSetScheduler.AcceptChanges()
    End Sub



    Private Sub SchedulerControl1_LayoutViewInfoCustomizing(sender As Object, e As LayoutViewInfoCustomizingEventArgs) Handles SchedulerControl1.LayoutViewInfoCustomizing
        If e.Kind = LayoutElementKind.ResourceHeader Then
            Dim header As SchedulerHeader = TryCast(e.ViewInfo, SchedulerHeader)
            If header IsNot Nothing Then
                header.Caption = header.Resource.Caption & System.Environment.NewLine & USERNAME
            End If
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim f As New ResourceInterface
        f.Show()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim f As New ResourceInterface
        f.Show()
    End Sub


    Private Sub SchedulerControl1_EditAppointmentFormShowing_1(sender As Object, e As AppointmentFormEventArgs) Handles SchedulerControl1.EditAppointmentFormShowing
<<<<<<< HEAD
        Dim scheduler As SchedulerControl = CType(sender, SchedulerControl)
=======
        Dim scheduler As DevExpress.XtraScheduler.SchedulerControl = CType(sender, DevExpress.XtraScheduler.SchedulerControl)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim form As New OutlookAppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm)
        Try
            e.DialogResult = form.ShowDialog
            e.Handled = True
        Finally
            form.Dispose()
        End Try

    End Sub

End Class