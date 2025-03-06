<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormScheduler
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TimeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim TimeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim TimeRuler3 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Me.DateNavigator1 = New DevExpress.XtraScheduler.DateNavigator()
        Me.SchedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
        Me.SchedulerDataStorage1 = New DevExpress.XtraScheduler.SchedulerDataStorage(Me.components)
        Me.AppointmentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
<<<<<<< HEAD
        Me.DataSetScheduler = New CC_JO.DataSetScheduler()
=======
        Me.DataSetScheduler = New DataSetScheduler()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ResourcesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.OpenScheduleItem1 = New DevExpress.XtraScheduler.UI.OpenScheduleItem()
        Me.SaveScheduleItem1 = New DevExpress.XtraScheduler.UI.SaveScheduleItem()
        Me.PrintPreviewItem1 = New DevExpress.XtraScheduler.UI.PrintPreviewItem()
        Me.PrintItem1 = New DevExpress.XtraScheduler.UI.PrintItem()
        Me.PrintPageSetupItem1 = New DevExpress.XtraScheduler.UI.PrintPageSetupItem()
        Me.NewAppointmentItem1 = New DevExpress.XtraScheduler.UI.NewAppointmentItem()
        Me.NewRecurringAppointmentItem1 = New DevExpress.XtraScheduler.UI.NewRecurringAppointmentItem()
        Me.NavigateViewBackwardItem1 = New DevExpress.XtraScheduler.UI.NavigateViewBackwardItem()
        Me.NavigateViewForwardItem1 = New DevExpress.XtraScheduler.UI.NavigateViewForwardItem()
        Me.GotoTodayItem1 = New DevExpress.XtraScheduler.UI.GotoTodayItem()
        Me.ViewZoomInItem1 = New DevExpress.XtraScheduler.UI.ViewZoomInItem()
        Me.ViewZoomOutItem1 = New DevExpress.XtraScheduler.UI.ViewZoomOutItem()
        Me.SwitchToDayViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToDayViewItem()
        Me.SwitchToWorkWeekViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToWorkWeekViewItem()
        Me.SwitchToWeekViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToWeekViewItem()
        Me.SwitchToFullWeekViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToFullWeekViewItem()
        Me.SwitchToMonthViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToMonthViewItem()
        Me.SwitchToTimelineViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToTimelineViewItem()
        Me.SwitchToGanttViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToGanttViewItem()
        Me.SwitchToAgendaViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToAgendaViewItem()
        Me.SwitchToYearViewItem1 = New DevExpress.XtraScheduler.UI.SwitchToYearViewItem()
        Me.GroupByNoneItem1 = New DevExpress.XtraScheduler.UI.GroupByNoneItem()
        Me.GroupByDateItem1 = New DevExpress.XtraScheduler.UI.GroupByDateItem()
        Me.GroupByResourceItem1 = New DevExpress.XtraScheduler.UI.GroupByResourceItem()
        Me.SwitchTimeScalesItem1 = New DevExpress.XtraScheduler.UI.SwitchTimeScalesItem()
        Me.ChangeScaleWidthItem1 = New DevExpress.XtraScheduler.UI.ChangeScaleWidthItem()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.SwitchTimeScalesCaptionItem1 = New DevExpress.XtraScheduler.UI.SwitchTimeScalesCaptionItem()
        Me.SwitchCompressWeekendItem1 = New DevExpress.XtraScheduler.UI.SwitchCompressWeekendItem()
        Me.SwitchShowWorkTimeOnlyItem1 = New DevExpress.XtraScheduler.UI.SwitchShowWorkTimeOnlyItem()
        Me.SwitchCellsAutoHeightItem1 = New DevExpress.XtraScheduler.UI.SwitchCellsAutoHeightItem()
        Me.ChangeSnapToCellsUIItem1 = New DevExpress.XtraScheduler.UI.ChangeSnapToCellsUIItem()
        Me.EditAppointmentQueryItem1 = New DevExpress.XtraScheduler.UI.EditAppointmentQueryItem()
        Me.EditOccurrenceUICommandItem1 = New DevExpress.XtraScheduler.UI.EditOccurrenceUICommandItem()
        Me.EditSeriesUICommandItem1 = New DevExpress.XtraScheduler.UI.EditSeriesUICommandItem()
        Me.DeleteAppointmentsItem1 = New DevExpress.XtraScheduler.UI.DeleteAppointmentsItem()
        Me.DeleteOccurrenceItem1 = New DevExpress.XtraScheduler.UI.DeleteOccurrenceItem()
        Me.DeleteSeriesItem1 = New DevExpress.XtraScheduler.UI.DeleteSeriesItem()
        Me.SplitAppointmentItem1 = New DevExpress.XtraScheduler.UI.SplitAppointmentItem()
        Me.ChangeAppointmentStatusItem1 = New DevExpress.XtraScheduler.UI.ChangeAppointmentStatusItem()
        Me.ChangeAppointmentLabelItem1 = New DevExpress.XtraScheduler.UI.ChangeAppointmentLabelItem()
        Me.ToggleRecurrenceItem1 = New DevExpress.XtraScheduler.UI.ToggleRecurrenceItem()
        Me.ChangeAppointmentReminderItem1 = New DevExpress.XtraScheduler.UI.ChangeAppointmentReminderItem()
        Me.RepositoryItemDuration1 = New DevExpress.XtraScheduler.UI.RepositoryItemDuration()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.CalendarToolsRibbonPageCategory2 = New DevExpress.XtraScheduler.UI.CalendarToolsRibbonPageCategory()
        Me.AppointmentRibbonPage2 = New DevExpress.XtraScheduler.UI.AppointmentRibbonPage()
        Me.ActionsRibbonPageGroup2 = New DevExpress.XtraScheduler.UI.ActionsRibbonPageGroup()
        Me.OptionsRibbonPageGroup2 = New DevExpress.XtraScheduler.UI.OptionsRibbonPageGroup()
        Me.FileRibbonPage1 = New DevExpress.XtraScheduler.UI.FileRibbonPage()
        Me.CommonRibbonPageGroup1 = New DevExpress.XtraScheduler.UI.CommonRibbonPageGroup()
        Me.PrintRibbonPageGroup1 = New DevExpress.XtraScheduler.UI.PrintRibbonPageGroup()
        Me.HomeRibbonPage1 = New DevExpress.XtraScheduler.UI.HomeRibbonPage()
        Me.AppointmentRibbonPageGroup1 = New DevExpress.XtraScheduler.UI.AppointmentRibbonPageGroup()
        Me.NavigatorRibbonPageGroup1 = New DevExpress.XtraScheduler.UI.NavigatorRibbonPageGroup()
        Me.ArrangeRibbonPageGroup1 = New DevExpress.XtraScheduler.UI.ArrangeRibbonPageGroup()
        Me.GroupByRibbonPageGroup1 = New DevExpress.XtraScheduler.UI.GroupByRibbonPageGroup()
        Me.ViewRibbonPage1 = New DevExpress.XtraScheduler.UI.ViewRibbonPage()
        Me.ActiveViewRibbonPageGroup1 = New DevExpress.XtraScheduler.UI.ActiveViewRibbonPageGroup()
        Me.TimeScaleRibbonPageGroup1 = New DevExpress.XtraScheduler.UI.TimeScaleRibbonPageGroup()
        Me.LayoutRibbonPageGroup1 = New DevExpress.XtraScheduler.UI.LayoutRibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.hideContainerRight = New DevExpress.XtraBars.Docking.AutoHideContainer()
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.SchedulerBarController1 = New DevExpress.XtraScheduler.UI.SchedulerBarController(Me.components)
<<<<<<< HEAD
        Me.AppointmentsTableAdapter = New CC_JO.DataSetSchedulerTableAdapters.AppointmentsTableAdapter()
        Me.ResourcesTableAdapter = New CC_JO.DataSetSchedulerTableAdapters.ResourcesTableAdapter()
=======
        Me.AppointmentsTableAdapter = New DataSetSchedulerTableAdapters.AppointmentsTableAdapter()
        Me.ResourcesTableAdapter = New DataSetSchedulerTableAdapters.ResourcesTableAdapter()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.AppointmentRibbonPage1 = New DevExpress.XtraScheduler.UI.AppointmentRibbonPage()
        Me.OptionsRibbonPageGroup1 = New DevExpress.XtraScheduler.UI.OptionsRibbonPageGroup()
        Me.ActionsRibbonPageGroup1 = New DevExpress.XtraScheduler.UI.ActionsRibbonPageGroup()
        Me.CalendarToolsRibbonPageCategory1 = New DevExpress.XtraScheduler.UI.CalendarToolsRibbonPageCategory()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.DateNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateNavigator1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchedulerDataStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppointmentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetScheduler, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResourcesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDuration1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.hideContainerRight.SuspendLayout()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.SchedulerBarController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateNavigator1
        '
        Me.DateNavigator1.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateNavigator1.Appearance.Options.UseFont = True
        Me.DateNavigator1.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.DateNavigator1.CalendarAppearance.DayCellSpecial.Options.UseFont = True
        Me.DateNavigator1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateNavigator1.CalendarTimeProperties.DisplayFormat.FormatString = "d"
        Me.DateNavigator1.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateNavigator1.CalendarTimeProperties.EditFormat.FormatString = "d"
        Me.DateNavigator1.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateNavigator1.CalendarTimeProperties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.DateNavigator1.CaseMonthNames = DevExpress.XtraEditors.Controls.TextCaseMode.System
        Me.DateNavigator1.CaseWeekDayAbbreviations = DevExpress.XtraEditors.Controls.TextCaseMode.System
        Me.DateNavigator1.DateTime = New Date(2023, 10, 26, 0, 0, 0, 0)
        Me.DateNavigator1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateNavigator1.EditValue = New Date(2023, 10, 26, 0, 0, 0, 0)
        Me.DateNavigator1.FirstDayOfWeek = System.DayOfWeek.Sunday
        Me.DateNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.DateNavigator1.Name = "DateNavigator1"
        Me.DateNavigator1.RightToLeftLayout = DevExpress.Utils.DefaultBoolean.[True]
        Me.DateNavigator1.SchedulerControl = Me.SchedulerControl1
<<<<<<< HEAD
        Me.DateNavigator1.Size = New System.Drawing.Size(383, 353)
=======
        Me.DateNavigator1.Size = New System.Drawing.Size(383, 340)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.DateNavigator1.TabIndex = 0
        Me.DateNavigator1.TodayDate = New Date(2023, 11, 2, 17, 14, 41, 0)
        Me.DateNavigator1.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.MonthView
        '
        'SchedulerControl1
        '
        Me.SchedulerControl1.Appearance.AdditionalHeaderCaption.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.SchedulerControl1.Appearance.AdditionalHeaderCaption.Options.UseFont = True
        Me.SchedulerControl1.Appearance.AlternateAdditionalHeaderCaption.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.SchedulerControl1.Appearance.AlternateAdditionalHeaderCaption.Options.UseFont = True
        Me.SchedulerControl1.Appearance.AlternateHeaderCaption.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.SchedulerControl1.Appearance.AlternateHeaderCaption.Options.UseFont = True
        Me.SchedulerControl1.Appearance.AlternateHeaderCaptionLine.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.SchedulerControl1.Appearance.AlternateHeaderCaptionLine.Options.UseFont = True
        Me.SchedulerControl1.Appearance.Appointment.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.SchedulerControl1.Appearance.Appointment.Options.UseFont = True
        Me.SchedulerControl1.Appearance.HeaderCaption.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.SchedulerControl1.Appearance.HeaderCaption.Options.UseFont = True
        Me.SchedulerControl1.Appearance.HeaderCaptionLine.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.SchedulerControl1.Appearance.HeaderCaptionLine.Options.UseFont = True
        Me.SchedulerControl1.Appearance.NavigationButton.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.SchedulerControl1.Appearance.NavigationButton.Options.UseFont = True
        Me.SchedulerControl1.Appearance.NavigationButtonDisabled.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.SchedulerControl1.Appearance.NavigationButtonDisabled.Options.UseFont = True
        Me.SchedulerControl1.Appearance.ResourceHeaderCaption.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.SchedulerControl1.Appearance.ResourceHeaderCaption.Options.UseFont = True
        Me.SchedulerControl1.Appearance.ResourceHeaderCaptionLine.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.SchedulerControl1.Appearance.ResourceHeaderCaptionLine.Options.UseFont = True
        Me.SchedulerControl1.Appearance.Selection.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.SchedulerControl1.Appearance.Selection.Options.UseFont = True
        Me.SchedulerControl1.Appearance.TabArea.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.SchedulerControl1.Appearance.TabArea.Options.UseFont = True
        Me.SchedulerControl1.Appearance.TabHeader.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.SchedulerControl1.Appearance.TabHeader.Options.UseFont = True
        Me.SchedulerControl1.DataStorage = Me.SchedulerDataStorage1
        Me.SchedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SchedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource
        Me.SchedulerControl1.Location = New System.Drawing.Point(0, 162)
        Me.SchedulerControl1.MenuManager = Me.RibbonControl1
        Me.SchedulerControl1.Name = "SchedulerControl1"
        Me.SchedulerControl1.OptionsBehavior.SelectOnRightClick = True
        Me.SchedulerControl1.OptionsRangeControl.DataDisplayType = DevExpress.XtraScheduler.RangeControlDataDisplayType.Thumbnail
        Me.SchedulerControl1.OptionsView.FirstDayOfWeek = DevExpress.XtraScheduler.FirstDayOfWeek.Sunday
        Me.SchedulerControl1.OptionsView.ResourceHeaders.Height = 125
        Me.SchedulerControl1.OptionsView.ResourceHeaders.ImageAlign = DevExpress.XtraScheduler.HeaderImageAlign.Top
        Me.SchedulerControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SchedulerControl1.Size = New System.Drawing.Size(1058, 382)
        Me.SchedulerControl1.Start = New Date(2023, 10, 26, 0, 0, 0, 0)
        Me.SchedulerControl1.TabIndex = 2
        Me.SchedulerControl1.Text = "جدول اعمال الإدارة"
        Me.SchedulerControl1.Views.DayView.AllDayAreaScrollBarVisible = True
        Me.SchedulerControl1.Views.DayView.TimeRulers.Add(TimeRuler1)
        Me.SchedulerControl1.Views.FullWeekView.AllDayAreaScrollBarVisible = True
        Me.SchedulerControl1.Views.FullWeekView.Enabled = True
        Me.SchedulerControl1.Views.FullWeekView.TimeRulers.Add(TimeRuler2)
        Me.SchedulerControl1.Views.WeekView.AppointmentDisplayOptions.AllowHtmlText = True
        Me.SchedulerControl1.Views.WeekView.Enabled = False
        Me.SchedulerControl1.Views.WorkWeekView.AppointmentDisplayOptions.AllowHtmlText = True
        Me.SchedulerControl1.Views.WorkWeekView.TimeRulers.Add(TimeRuler3)
        Me.SchedulerControl1.Views.YearView.UseOptimizedScrolling = False
        '
        'SchedulerDataStorage1
        '
        '
        '
        '
        Me.SchedulerDataStorage1.Appointments.CustomFieldMappings.Add(New DevExpress.XtraScheduler.AppointmentCustomFieldMapping("COUser", "COUser"))
        Me.SchedulerDataStorage1.Appointments.CustomFieldMappings.Add(New DevExpress.XtraScheduler.AppointmentCustomFieldMapping("CUser", "CUser"))
        Me.SchedulerDataStorage1.Appointments.CustomFieldMappings.Add(New DevExpress.XtraScheduler.AppointmentCustomFieldMapping("CustomField1", "CustomField1"))
        Me.SchedulerDataStorage1.Appointments.CustomFieldMappings.Add(New DevExpress.XtraScheduler.AppointmentCustomFieldMapping("Da", "da"))
        Me.SchedulerDataStorage1.Appointments.CustomFieldMappings.Add(New DevExpress.XtraScheduler.AppointmentCustomFieldMapping("Ne", "ne"))
        Me.SchedulerDataStorage1.Appointments.CustomFieldMappings.Add(New DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ResourceIDs", "ResourceIDs"))
        Me.SchedulerDataStorage1.Appointments.CustomFieldMappings.Add(New DevExpress.XtraScheduler.AppointmentCustomFieldMapping("UniqueID", "UniqueID"))
        Me.SchedulerDataStorage1.Appointments.CustomFieldMappings.Add(New DevExpress.XtraScheduler.AppointmentCustomFieldMapping("USERNAME", "USERNAME"))
        Me.SchedulerDataStorage1.Appointments.DataSource = Me.AppointmentsBindingSource
        Me.SchedulerDataStorage1.Appointments.Labels.CreateNewLabel(0, "None", "&None", System.Drawing.SystemColors.Window)
        Me.SchedulerDataStorage1.Appointments.Labels.CreateNewLabel(1, "Important", "&Important", System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(190, Byte), Integer)))
        Me.SchedulerDataStorage1.Appointments.Labels.CreateNewLabel(2, "Business", "&Business", System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer)))
        Me.SchedulerDataStorage1.Appointments.Labels.CreateNewLabel(3, "Personal", "&Personal", System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(156, Byte), Integer)))
        Me.SchedulerDataStorage1.Appointments.Labels.CreateNewLabel(4, "Vacation", "&Vacation", System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(199, Byte), Integer)))
        Me.SchedulerDataStorage1.Appointments.Labels.CreateNewLabel(5, "Must Attend", "Must &Attend", System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(147, Byte), Integer)))
        Me.SchedulerDataStorage1.Appointments.Labels.CreateNewLabel(6, "Travel Required", "&Travel Required", System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(255, Byte), Integer)))
        Me.SchedulerDataStorage1.Appointments.Labels.CreateNewLabel(7, "Needs Preparation", "&Needs Preparation", System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(152, Byte), Integer)))
        Me.SchedulerDataStorage1.Appointments.Labels.CreateNewLabel(8, "Birthday", "&Birthday", System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(233, Byte), Integer)))
        Me.SchedulerDataStorage1.Appointments.Labels.CreateNewLabel(9, "Anniversary", "&Anniversary", System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(223, Byte), Integer)))
        Me.SchedulerDataStorage1.Appointments.Labels.CreateNewLabel(10, "Phone Call", "Phone &Call", System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(165, Byte), Integer)))
        Me.SchedulerDataStorage1.Appointments.Mappings.AllDay = "AllDay"
        Me.SchedulerDataStorage1.Appointments.Mappings.Description = "Description"
        Me.SchedulerDataStorage1.Appointments.Mappings.End = "EndDate"
        Me.SchedulerDataStorage1.Appointments.Mappings.Label = "Label"
        Me.SchedulerDataStorage1.Appointments.Mappings.Location = "Location"
        Me.SchedulerDataStorage1.Appointments.Mappings.OriginalOccurrenceEnd = "QueryEndDate"
        Me.SchedulerDataStorage1.Appointments.Mappings.OriginalOccurrenceStart = "QueryStartDate"
        Me.SchedulerDataStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
        Me.SchedulerDataStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
        Me.SchedulerDataStorage1.Appointments.Mappings.ResourceId = "ResourceID"
        Me.SchedulerDataStorage1.Appointments.Mappings.Start = "StartDate"
        Me.SchedulerDataStorage1.Appointments.Mappings.Status = "Status"
        Me.SchedulerDataStorage1.Appointments.Mappings.Subject = "Subject"
        Me.SchedulerDataStorage1.Appointments.Mappings.TimeZoneId = "TimeZoneId"
        Me.SchedulerDataStorage1.Appointments.Mappings.Type = "Type"
        '
        '
        '
        Me.SchedulerDataStorage1.Resources.CustomFieldMappings.Add(New DevExpress.XtraScheduler.ResourceCustomFieldMapping("CustomField1", "CustomField1"))
        Me.SchedulerDataStorage1.Resources.CustomFieldMappings.Add(New DevExpress.XtraScheduler.ResourceCustomFieldMapping("COUser", "COUser"))
        Me.SchedulerDataStorage1.Resources.CustomFieldMappings.Add(New DevExpress.XtraScheduler.ResourceCustomFieldMapping("Da", "da"))
        Me.SchedulerDataStorage1.Resources.CustomFieldMappings.Add(New DevExpress.XtraScheduler.ResourceCustomFieldMapping("CUser", "CUser"))
        Me.SchedulerDataStorage1.Resources.CustomFieldMappings.Add(New DevExpress.XtraScheduler.ResourceCustomFieldMapping("UserName", "UserName"))
        Me.SchedulerDataStorage1.Resources.DataSource = Me.ResourcesBindingSource
        Me.SchedulerDataStorage1.Resources.Mappings.Caption = "ResourceName"
        Me.SchedulerDataStorage1.Resources.Mappings.Color = "Color"
        Me.SchedulerDataStorage1.Resources.Mappings.Id = "ResourceID"
        Me.SchedulerDataStorage1.Resources.Mappings.Image = "Image"
        Me.SchedulerDataStorage1.Resources.Mappings.ParentId = "UniqueID"
        '
        'AppointmentsBindingSource
        '
        Me.AppointmentsBindingSource.DataMember = "Appointments"
        Me.AppointmentsBindingSource.DataSource = Me.DataSetScheduler
        '
        'DataSetScheduler
        '
        Me.DataSetScheduler.DataSetName = "DataSetScheduler"
        Me.DataSetScheduler.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ResourcesBindingSource
        '
        Me.ResourcesBindingSource.DataMember = "Resources"
        Me.ResourcesBindingSource.DataSource = Me.DataSetScheduler
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.OpenScheduleItem1, Me.SaveScheduleItem1, Me.PrintPreviewItem1, Me.PrintItem1, Me.PrintPageSetupItem1, Me.NewAppointmentItem1, Me.NewRecurringAppointmentItem1, Me.NavigateViewBackwardItem1, Me.NavigateViewForwardItem1, Me.GotoTodayItem1, Me.ViewZoomInItem1, Me.ViewZoomOutItem1, Me.SwitchToDayViewItem1, Me.SwitchToWorkWeekViewItem1, Me.SwitchToWeekViewItem1, Me.SwitchToFullWeekViewItem1, Me.SwitchToMonthViewItem1, Me.SwitchToTimelineViewItem1, Me.SwitchToGanttViewItem1, Me.SwitchToAgendaViewItem1, Me.SwitchToYearViewItem1, Me.GroupByNoneItem1, Me.GroupByDateItem1, Me.GroupByResourceItem1, Me.SwitchTimeScalesItem1, Me.ChangeScaleWidthItem1, Me.SwitchTimeScalesCaptionItem1, Me.SwitchCompressWeekendItem1, Me.SwitchShowWorkTimeOnlyItem1, Me.SwitchCellsAutoHeightItem1, Me.ChangeSnapToCellsUIItem1, Me.EditAppointmentQueryItem1, Me.EditOccurrenceUICommandItem1, Me.EditSeriesUICommandItem1, Me.DeleteAppointmentsItem1, Me.DeleteOccurrenceItem1, Me.DeleteSeriesItem1, Me.SplitAppointmentItem1, Me.ChangeAppointmentStatusItem1, Me.ChangeAppointmentLabelItem1, Me.ToggleRecurrenceItem1, Me.ChangeAppointmentReminderItem1, Me.BarButtonItem1, Me.BarButtonItem2})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 47
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.PageCategories.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageCategory() {Me.CalendarToolsRibbonPageCategory2})
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.FileRibbonPage1, Me.HomeRibbonPage1, Me.ViewRibbonPage1})
        Me.RibbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1, Me.RepositoryItemDuration1})
        Me.RibbonControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.Size = New System.Drawing.Size(1081, 162)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'OpenScheduleItem1
        '
        Me.OpenScheduleItem1.Caption = "استورد"
        Me.OpenScheduleItem1.Id = 1
        Me.OpenScheduleItem1.Name = "OpenScheduleItem1"
        '
        'SaveScheduleItem1
        '
        Me.SaveScheduleItem1.Caption = "حفظ"
        Me.SaveScheduleItem1.Id = 2
        Me.SaveScheduleItem1.Name = "SaveScheduleItem1"
        '
        'PrintPreviewItem1
        '
        Me.PrintPreviewItem1.Caption = "معاينة قبل الطباعة"
        Me.PrintPreviewItem1.Id = 3
        Me.PrintPreviewItem1.Name = "PrintPreviewItem1"
        '
        'PrintItem1
        '
        Me.PrintItem1.Caption = "طباعة سريعة"
        Me.PrintItem1.Id = 4
        Me.PrintItem1.Name = "PrintItem1"
        '
        'PrintPageSetupItem1
        '
        Me.PrintPageSetupItem1.Caption = "اعداد الصفحة"
        Me.PrintPageSetupItem1.Id = 5
        Me.PrintPageSetupItem1.Name = "PrintPageSetupItem1"
        '
        'NewAppointmentItem1
        '
        Me.NewAppointmentItem1.Caption = "موعد جديد"
        Me.NewAppointmentItem1.Id = 6
        Me.NewAppointmentItem1.Name = "NewAppointmentItem1"
        '
        'NewRecurringAppointmentItem1
        '
        Me.NewRecurringAppointmentItem1.Caption = "تكرار وموعد جديد"
        Me.NewRecurringAppointmentItem1.Id = 7
        Me.NewRecurringAppointmentItem1.Name = "NewRecurringAppointmentItem1"
        '
        'NavigateViewBackwardItem1
        '
        Me.NavigateViewBackwardItem1.Caption = "الى الوراء"
        Me.NavigateViewBackwardItem1.Id = 8
        Me.NavigateViewBackwardItem1.Name = "NavigateViewBackwardItem1"
        '
        'NavigateViewForwardItem1
        '
        Me.NavigateViewForwardItem1.Caption = "إلى الأمام"
        Me.NavigateViewForwardItem1.Id = 9
        Me.NavigateViewForwardItem1.Name = "NavigateViewForwardItem1"
        '
        'GotoTodayItem1
        '
        Me.GotoTodayItem1.Caption = "انتقل إلى &اليوم"
        Me.GotoTodayItem1.Id = 10
        Me.GotoTodayItem1.Name = "GotoTodayItem1"
        '
        'ViewZoomInItem1
        '
        Me.ViewZoomInItem1.Id = 11
        Me.ViewZoomInItem1.Name = "ViewZoomInItem1"
        '
        'ViewZoomOutItem1
        '
        Me.ViewZoomOutItem1.Id = 12
        Me.ViewZoomOutItem1.Name = "ViewZoomOutItem1"
        '
        'SwitchToDayViewItem1
        '
        Me.SwitchToDayViewItem1.Caption = "&عرض اليوم"
        Me.SwitchToDayViewItem1.Id = 13
        Me.SwitchToDayViewItem1.Name = "SwitchToDayViewItem1"
        '
        'SwitchToWorkWeekViewItem1
        '
        Me.SwitchToWorkWeekViewItem1.Caption = "عرض أسبوع العمل"
        Me.SwitchToWorkWeekViewItem1.Id = 14
        Me.SwitchToWorkWeekViewItem1.Name = "SwitchToWorkWeekViewItem1"
        '
        'SwitchToWeekViewItem1
        '
        Me.SwitchToWeekViewItem1.Caption = "&عرض الأسبوع"
        Me.SwitchToWeekViewItem1.Id = 15
        Me.SwitchToWeekViewItem1.Name = "SwitchToWeekViewItem1"
        '
        'SwitchToFullWeekViewItem1
        '
        Me.SwitchToFullWeekViewItem1.Caption = "&عرض أسبوع كامل"
        Me.SwitchToFullWeekViewItem1.Id = 16
        Me.SwitchToFullWeekViewItem1.Name = "SwitchToFullWeekViewItem1"
        '
        'SwitchToMonthViewItem1
        '
        Me.SwitchToMonthViewItem1.Caption = "&عرض الشهر"
        Me.SwitchToMonthViewItem1.Id = 17
        Me.SwitchToMonthViewItem1.Name = "SwitchToMonthViewItem1"
        '
        'SwitchToTimelineViewItem1
        '
        Me.SwitchToTimelineViewItem1.Caption = "&عرض المخطط الزمني"
        Me.SwitchToTimelineViewItem1.Id = 18
        Me.SwitchToTimelineViewItem1.Name = "SwitchToTimelineViewItem1"
        '
        'SwitchToGanttViewItem1
        '
        Me.SwitchToGanttViewItem1.Caption = "&عرض الجدول"
        Me.SwitchToGanttViewItem1.Id = 19
        Me.SwitchToGanttViewItem1.Name = "SwitchToGanttViewItem1"
        '
        'SwitchToAgendaViewItem1
        '
        Me.SwitchToAgendaViewItem1.Caption = "&عرض الأجندة"
        Me.SwitchToAgendaViewItem1.Id = 20
        Me.SwitchToAgendaViewItem1.Name = "SwitchToAgendaViewItem1"
        '
        'SwitchToYearViewItem1
        '
        Me.SwitchToYearViewItem1.Caption = "عرض &السنة"
        Me.SwitchToYearViewItem1.Id = 21
        Me.SwitchToYearViewItem1.Name = "SwitchToYearViewItem1"
        '
        'GroupByNoneItem1
        '
        Me.GroupByNoneItem1.Caption = "&التجميع حسب لا شيء"
        Me.GroupByNoneItem1.Id = 22
        Me.GroupByNoneItem1.Name = "GroupByNoneItem1"
        '
        'GroupByDateItem1
        '
        Me.GroupByDateItem1.Caption = "&التجميع حسب التاريخ"
        Me.GroupByDateItem1.Id = 23
        Me.GroupByDateItem1.Name = "GroupByDateItem1"
        '
        'GroupByResourceItem1
        '
        Me.GroupByResourceItem1.Caption = "&التجميع حسب المورد"
        Me.GroupByResourceItem1.Id = 24
        Me.GroupByResourceItem1.Name = "GroupByResourceItem1"
        '
        'SwitchTimeScalesItem1
        '
        Me.SwitchTimeScalesItem1.Caption = "&مقاييس الوقت"
        Me.SwitchTimeScalesItem1.Id = 25
        Me.SwitchTimeScalesItem1.Name = "SwitchTimeScalesItem1"
        '
        'ChangeScaleWidthItem1
        '
        Me.ChangeScaleWidthItem1.Caption = "عرض المقياس"
        Me.ChangeScaleWidthItem1.Edit = Me.RepositoryItemSpinEdit1
        Me.ChangeScaleWidthItem1.Id = 26
        Me.ChangeScaleWidthItem1.Name = "ChangeScaleWidthItem1"
        Me.ChangeScaleWidthItem1.UseCommandCaption = True
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {200, 0, 0, 0})
        Me.RepositoryItemSpinEdit1.MinValue = New Decimal(New Integer() {10, 0, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'SwitchTimeScalesCaptionItem1
        '
        Me.SwitchTimeScalesCaptionItem1.Caption = "مقياس الوقت والتسميات التوضيحية"
        Me.SwitchTimeScalesCaptionItem1.Id = 27
        Me.SwitchTimeScalesCaptionItem1.Name = "SwitchTimeScalesCaptionItem1"
        '
        'SwitchCompressWeekendItem1
        '
        Me.SwitchCompressWeekendItem1.Caption = "ضغط عطلة نهاية الأسبوع"
        Me.SwitchCompressWeekendItem1.Id = 28
        Me.SwitchCompressWeekendItem1.Name = "SwitchCompressWeekendItem1"
        '
        'SwitchShowWorkTimeOnlyItem1
        '
        Me.SwitchShowWorkTimeOnlyItem1.Caption = "ساعات العمل"
        Me.SwitchShowWorkTimeOnlyItem1.Id = 29
        Me.SwitchShowWorkTimeOnlyItem1.Name = "SwitchShowWorkTimeOnlyItem1"
        '
        'SwitchCellsAutoHeightItem1
        '
        Me.SwitchCellsAutoHeightItem1.Caption = "الارتفاع التلقائي للخلية"
        Me.SwitchCellsAutoHeightItem1.Id = 30
        Me.SwitchCellsAutoHeightItem1.Name = "SwitchCellsAutoHeightItem1"
        '
        'ChangeSnapToCellsUIItem1
        '
        Me.ChangeSnapToCellsUIItem1.Caption = "انجذاب إلى الخلايا"
        Me.ChangeSnapToCellsUIItem1.Id = 31
        Me.ChangeSnapToCellsUIItem1.Name = "ChangeSnapToCellsUIItem1"
        '
        'EditAppointmentQueryItem1
        '
        Me.EditAppointmentQueryItem1.Caption = "&فتح"
        Me.EditAppointmentQueryItem1.Id = 32
        Me.EditAppointmentQueryItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.EditOccurrenceUICommandItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.EditSeriesUICommandItem1)})
        Me.EditAppointmentQueryItem1.Name = "EditAppointmentQueryItem1"
        Me.EditAppointmentQueryItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'EditOccurrenceUICommandItem1
        '
        Me.EditOccurrenceUICommandItem1.Id = 33
        Me.EditOccurrenceUICommandItem1.Name = "EditOccurrenceUICommandItem1"
        '
        'EditSeriesUICommandItem1
        '
        Me.EditSeriesUICommandItem1.Id = 34
        Me.EditSeriesUICommandItem1.Name = "EditSeriesUICommandItem1"
        '
        'DeleteAppointmentsItem1
        '
        Me.DeleteAppointmentsItem1.Caption = "&حذف"
        Me.DeleteAppointmentsItem1.Id = 35
        Me.DeleteAppointmentsItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.DeleteOccurrenceItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.DeleteSeriesItem1)})
        Me.DeleteAppointmentsItem1.Name = "DeleteAppointmentsItem1"
        Me.DeleteAppointmentsItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'DeleteOccurrenceItem1
        '
        Me.DeleteOccurrenceItem1.Id = 36
        Me.DeleteOccurrenceItem1.Name = "DeleteOccurrenceItem1"
        '
        'DeleteSeriesItem1
        '
        Me.DeleteSeriesItem1.Id = 37
        Me.DeleteSeriesItem1.Name = "DeleteSeriesItem1"
        '
        'SplitAppointmentItem1
        '
        Me.SplitAppointmentItem1.Caption = "يقسم"
        Me.SplitAppointmentItem1.Id = 38
        Me.SplitAppointmentItem1.Name = "SplitAppointmentItem1"
        '
        'ChangeAppointmentStatusItem1
        '
        Me.ChangeAppointmentStatusItem1.Caption = "&إظهار الوقت باسم"
        Me.ChangeAppointmentStatusItem1.Id = 39
        Me.ChangeAppointmentStatusItem1.Name = "ChangeAppointmentStatusItem1"
        '
        'ChangeAppointmentLabelItem1
        '
        Me.ChangeAppointmentLabelItem1.Caption = "&تسمية باسم"
        Me.ChangeAppointmentLabelItem1.Id = 40
        Me.ChangeAppointmentLabelItem1.Name = "ChangeAppointmentLabelItem1"
        '
        'ToggleRecurrenceItem1
        '
        Me.ToggleRecurrenceItem1.Caption = "تكرار"
        Me.ToggleRecurrenceItem1.Id = 41
        Me.ToggleRecurrenceItem1.Name = "ToggleRecurrenceItem1"
        '
        'ChangeAppointmentReminderItem1
        '
        Me.ChangeAppointmentReminderItem1.Caption = "تذكير"
        Me.ChangeAppointmentReminderItem1.Edit = Me.RepositoryItemDuration1
        Me.ChangeAppointmentReminderItem1.Id = 42
        Me.ChangeAppointmentReminderItem1.Name = "ChangeAppointmentReminderItem1"
        '
        'RepositoryItemDuration1
        '
        Me.RepositoryItemDuration1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemDuration1.AutoHeight = False
        Me.RepositoryItemDuration1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDuration1.DisabledStateText = Nothing
        Me.RepositoryItemDuration1.Name = "RepositoryItemDuration1"
        Me.RepositoryItemDuration1.ShowEmptyItem = True
        Me.RepositoryItemDuration1.ValidateOnEnterKey = True
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "اضافة وتعديل الاعضاء"
        Me.BarButtonItem1.Id = 45
        Me.BarButtonItem1.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.administrator
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "اضافة وتعديل الاعضاء"
        Me.BarButtonItem2.Id = 46
        Me.BarButtonItem2.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.administrator
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'CalendarToolsRibbonPageCategory2
        '
        Me.CalendarToolsRibbonPageCategory2.Control = Me.SchedulerControl1
        Me.CalendarToolsRibbonPageCategory2.Name = "CalendarToolsRibbonPageCategory2"
        Me.CalendarToolsRibbonPageCategory2.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.AppointmentRibbonPage2})
        Me.CalendarToolsRibbonPageCategory2.Text = "أدوات التقويم"
        Me.CalendarToolsRibbonPageCategory2.Visible = False
        '
        'AppointmentRibbonPage2
        '
        Me.AppointmentRibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.ActionsRibbonPageGroup2, Me.OptionsRibbonPageGroup2})
        Me.AppointmentRibbonPage2.Name = "AppointmentRibbonPage2"
        Me.AppointmentRibbonPage2.Text = "مواعيد"
        Me.AppointmentRibbonPage2.Visible = False
        '
        'ActionsRibbonPageGroup2
        '
        Me.ActionsRibbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.ActionsRibbonPageGroup2.ItemLinks.Add(Me.EditAppointmentQueryItem1)
        Me.ActionsRibbonPageGroup2.ItemLinks.Add(Me.DeleteAppointmentsItem1)
        Me.ActionsRibbonPageGroup2.ItemLinks.Add(Me.SplitAppointmentItem1)
        Me.ActionsRibbonPageGroup2.Name = "ActionsRibbonPageGroup2"
        '
        'OptionsRibbonPageGroup2
        '
        Me.OptionsRibbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.OptionsRibbonPageGroup2.ItemLinks.Add(Me.ChangeAppointmentStatusItem1)
        Me.OptionsRibbonPageGroup2.ItemLinks.Add(Me.ChangeAppointmentLabelItem1)
        Me.OptionsRibbonPageGroup2.ItemLinks.Add(Me.ToggleRecurrenceItem1)
        Me.OptionsRibbonPageGroup2.ItemLinks.Add(Me.ChangeAppointmentReminderItem1)
        Me.OptionsRibbonPageGroup2.ItemLinks.Add(Me.BarButtonItem2)
        Me.OptionsRibbonPageGroup2.Name = "OptionsRibbonPageGroup2"
        Me.OptionsRibbonPageGroup2.Text = "خيارات"
        '
        'FileRibbonPage1
        '
        Me.FileRibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.CommonRibbonPageGroup1, Me.PrintRibbonPageGroup1})
        Me.FileRibbonPage1.Name = "FileRibbonPage1"
        Me.FileRibbonPage1.Text = "ملف"
        '
        'CommonRibbonPageGroup1
        '
        Me.CommonRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.CommonRibbonPageGroup1.ItemLinks.Add(Me.OpenScheduleItem1)
        Me.CommonRibbonPageGroup1.ItemLinks.Add(Me.SaveScheduleItem1)
        Me.CommonRibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.CommonRibbonPageGroup1.Name = "CommonRibbonPageGroup1"
        Me.CommonRibbonPageGroup1.Text = "شائع"
        '
        'PrintRibbonPageGroup1
        '
        Me.PrintRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.PrintRibbonPageGroup1.ItemLinks.Add(Me.PrintPreviewItem1)
        Me.PrintRibbonPageGroup1.ItemLinks.Add(Me.PrintItem1)
        Me.PrintRibbonPageGroup1.ItemLinks.Add(Me.PrintPageSetupItem1)
        Me.PrintRibbonPageGroup1.Name = "PrintRibbonPageGroup1"
        Me.PrintRibbonPageGroup1.Text = "طبعة"
        '
        'HomeRibbonPage1
        '
        Me.HomeRibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.AppointmentRibbonPageGroup1, Me.NavigatorRibbonPageGroup1, Me.ArrangeRibbonPageGroup1, Me.GroupByRibbonPageGroup1})
        Me.HomeRibbonPage1.Name = "HomeRibbonPage1"
        Me.HomeRibbonPage1.Text = "الصفحة الرئيسية"
        '
        'AppointmentRibbonPageGroup1
        '
        Me.AppointmentRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.AppointmentRibbonPageGroup1.ItemLinks.Add(Me.NewAppointmentItem1)
        Me.AppointmentRibbonPageGroup1.ItemLinks.Add(Me.NewRecurringAppointmentItem1)
        Me.AppointmentRibbonPageGroup1.Name = "AppointmentRibbonPageGroup1"
        Me.AppointmentRibbonPageGroup1.Text = "مواعيد"
        '
        'NavigatorRibbonPageGroup1
        '
        Me.NavigatorRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.NavigatorRibbonPageGroup1.ItemLinks.Add(Me.NavigateViewBackwardItem1)
        Me.NavigatorRibbonPageGroup1.ItemLinks.Add(Me.NavigateViewForwardItem1)
        Me.NavigatorRibbonPageGroup1.ItemLinks.Add(Me.GotoTodayItem1)
        Me.NavigatorRibbonPageGroup1.ItemLinks.Add(Me.ViewZoomInItem1)
        Me.NavigatorRibbonPageGroup1.ItemLinks.Add(Me.ViewZoomOutItem1)
        Me.NavigatorRibbonPageGroup1.Name = "NavigatorRibbonPageGroup1"
        Me.NavigatorRibbonPageGroup1.Text = "التنقل"
        '
        'ArrangeRibbonPageGroup1
        '
        Me.ArrangeRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.ArrangeRibbonPageGroup1.ItemLinks.Add(Me.SwitchToDayViewItem1)
        Me.ArrangeRibbonPageGroup1.ItemLinks.Add(Me.SwitchToWorkWeekViewItem1)
        Me.ArrangeRibbonPageGroup1.ItemLinks.Add(Me.SwitchToWeekViewItem1)
        Me.ArrangeRibbonPageGroup1.ItemLinks.Add(Me.SwitchToFullWeekViewItem1)
        Me.ArrangeRibbonPageGroup1.ItemLinks.Add(Me.SwitchToMonthViewItem1)
        Me.ArrangeRibbonPageGroup1.ItemLinks.Add(Me.SwitchToTimelineViewItem1)
        Me.ArrangeRibbonPageGroup1.ItemLinks.Add(Me.SwitchToGanttViewItem1)
        Me.ArrangeRibbonPageGroup1.ItemLinks.Add(Me.SwitchToAgendaViewItem1)
        Me.ArrangeRibbonPageGroup1.ItemLinks.Add(Me.SwitchToYearViewItem1)
        Me.ArrangeRibbonPageGroup1.Name = "ArrangeRibbonPageGroup1"
        Me.ArrangeRibbonPageGroup1.Text = "عرض"
        '
        'GroupByRibbonPageGroup1
        '
        Me.GroupByRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.GroupByRibbonPageGroup1.ItemLinks.Add(Me.GroupByNoneItem1)
        Me.GroupByRibbonPageGroup1.ItemLinks.Add(Me.GroupByDateItem1)
        Me.GroupByRibbonPageGroup1.ItemLinks.Add(Me.GroupByResourceItem1)
        Me.GroupByRibbonPageGroup1.Name = "GroupByRibbonPageGroup1"
        Me.GroupByRibbonPageGroup1.Text = "تجميع"
        '
        'ViewRibbonPage1
        '
        Me.ViewRibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.ActiveViewRibbonPageGroup1, Me.TimeScaleRibbonPageGroup1, Me.LayoutRibbonPageGroup1})
        Me.ViewRibbonPage1.Name = "ViewRibbonPage1"
        Me.ViewRibbonPage1.Text = "عرض"
        '
        'ActiveViewRibbonPageGroup1
        '
        Me.ActiveViewRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.ActiveViewRibbonPageGroup1.ItemLinks.Add(Me.SwitchToDayViewItem1)
        Me.ActiveViewRibbonPageGroup1.ItemLinks.Add(Me.SwitchToWorkWeekViewItem1)
        Me.ActiveViewRibbonPageGroup1.ItemLinks.Add(Me.SwitchToWeekViewItem1)
        Me.ActiveViewRibbonPageGroup1.ItemLinks.Add(Me.SwitchToFullWeekViewItem1)
        Me.ActiveViewRibbonPageGroup1.ItemLinks.Add(Me.SwitchToMonthViewItem1)
        Me.ActiveViewRibbonPageGroup1.ItemLinks.Add(Me.SwitchToTimelineViewItem1)
        Me.ActiveViewRibbonPageGroup1.ItemLinks.Add(Me.SwitchToGanttViewItem1)
        Me.ActiveViewRibbonPageGroup1.ItemLinks.Add(Me.SwitchToAgendaViewItem1)
        Me.ActiveViewRibbonPageGroup1.ItemLinks.Add(Me.SwitchToYearViewItem1)
        Me.ActiveViewRibbonPageGroup1.Name = "ActiveViewRibbonPageGroup1"
        Me.ActiveViewRibbonPageGroup1.Text = "عرض نشط"
        '
        'TimeScaleRibbonPageGroup1
        '
        Me.TimeScaleRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.TimeScaleRibbonPageGroup1.ItemLinks.Add(Me.SwitchTimeScalesItem1)
        Me.TimeScaleRibbonPageGroup1.ItemLinks.Add(Me.ChangeScaleWidthItem1)
        Me.TimeScaleRibbonPageGroup1.ItemLinks.Add(Me.SwitchTimeScalesCaptionItem1)
        Me.TimeScaleRibbonPageGroup1.Name = "TimeScaleRibbonPageGroup1"
        Me.TimeScaleRibbonPageGroup1.Text = "مقياس الوقت"
        '
        'LayoutRibbonPageGroup1
        '
        Me.LayoutRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.LayoutRibbonPageGroup1.ItemLinks.Add(Me.SwitchCompressWeekendItem1)
        Me.LayoutRibbonPageGroup1.ItemLinks.Add(Me.SwitchShowWorkTimeOnlyItem1)
        Me.LayoutRibbonPageGroup1.ItemLinks.Add(Me.SwitchCellsAutoHeightItem1)
        Me.LayoutRibbonPageGroup1.ItemLinks.Add(Me.ChangeSnapToCellsUIItem1)
        Me.LayoutRibbonPageGroup1.Name = "LayoutRibbonPageGroup1"
        Me.LayoutRibbonPageGroup1.Text = "تَخطِيط"
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.BackColor = System.Drawing.Color.SteelBlue
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 544)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(1081, 24)
        '
        'DockManager1
        '
        Me.DockManager1.AutoHideContainers.AddRange(New DevExpress.XtraBars.Docking.AutoHideContainer() {Me.hideContainerRight})
        Me.DockManager1.Form = Me
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
        '
        'hideContainerRight
        '
        Me.hideContainerRight.BackColor = System.Drawing.Color.White
        Me.hideContainerRight.Controls.Add(Me.DockPanel1)
        Me.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.hideContainerRight.Location = New System.Drawing.Point(1058, 162)
        Me.hideContainerRight.Name = "hideContainerRight"
        Me.hideContainerRight.Size = New System.Drawing.Size(23, 382)
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right
        Me.DockPanel1.ID = New System.Guid("9bbc49cc-c09c-4123-991a-d0524b996db9")
<<<<<<< HEAD
        Me.DockPanel1.Location = New System.Drawing.Point(668, 162)
=======
        Me.DockPanel1.Location = New System.Drawing.Point(664, 157)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(390, 200)
        Me.DockPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right
        Me.DockPanel1.SavedIndex = 0
<<<<<<< HEAD
        Me.DockPanel1.Size = New System.Drawing.Size(390, 382)
=======
        Me.DockPanel1.Size = New System.Drawing.Size(390, 389)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.DockPanel1.Text = "التقويــم"
        Me.DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.DateNavigator1)
<<<<<<< HEAD
        Me.DockPanel1_Container.Location = New System.Drawing.Point(3, 26)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(383, 353)
=======
        Me.DockPanel1_Container.Location = New System.Drawing.Point(3, 46)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(383, 340)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.DockPanel1_Container.TabIndex = 0
        '
        'SchedulerBarController1
        '
        Me.SchedulerBarController1.BarItems.Add(Me.OpenScheduleItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SaveScheduleItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.PrintPreviewItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.PrintItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.PrintPageSetupItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.NewAppointmentItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.NewRecurringAppointmentItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.NavigateViewBackwardItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.NavigateViewForwardItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.GotoTodayItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.ViewZoomInItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.ViewZoomOutItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SwitchToDayViewItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SwitchToWorkWeekViewItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SwitchToWeekViewItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SwitchToFullWeekViewItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SwitchToMonthViewItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SwitchToTimelineViewItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SwitchToGanttViewItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SwitchToAgendaViewItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SwitchToYearViewItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.GroupByNoneItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.GroupByDateItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.GroupByResourceItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SwitchTimeScalesItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.ChangeScaleWidthItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SwitchTimeScalesCaptionItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SwitchCompressWeekendItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SwitchShowWorkTimeOnlyItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SwitchCellsAutoHeightItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.ChangeSnapToCellsUIItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.EditOccurrenceUICommandItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.EditSeriesUICommandItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.EditAppointmentQueryItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.DeleteOccurrenceItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.DeleteSeriesItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.DeleteAppointmentsItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.SplitAppointmentItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.ChangeAppointmentStatusItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.ChangeAppointmentLabelItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.ToggleRecurrenceItem1)
        Me.SchedulerBarController1.BarItems.Add(Me.ChangeAppointmentReminderItem1)
        Me.SchedulerBarController1.Control = Me.SchedulerControl1
        '
        'AppointmentsTableAdapter
        '
        Me.AppointmentsTableAdapter.ClearBeforeFill = True
        '
        'ResourcesTableAdapter
        '
        Me.ResourcesTableAdapter.ClearBeforeFill = True
        '
        'AppointmentRibbonPage1
        '
        Me.AppointmentRibbonPage1.Name = "AppointmentRibbonPage1"
        Me.AppointmentRibbonPage1.Visible = False
        '
        'OptionsRibbonPageGroup1
        '
        Me.OptionsRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.OptionsRibbonPageGroup1.Name = "OptionsRibbonPageGroup1"
        Me.OptionsRibbonPageGroup1.Text = ""
        '
        'ActionsRibbonPageGroup1
        '
        Me.ActionsRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.ActionsRibbonPageGroup1.Name = "ActionsRibbonPageGroup1"
        Me.ActionsRibbonPageGroup1.Text = ""
        '
        'CalendarToolsRibbonPageCategory1
        '
        Me.CalendarToolsRibbonPageCategory1.Control = Me.SchedulerControl1
        Me.CalendarToolsRibbonPageCategory1.Name = "CalendarToolsRibbonPageCategory1"
        Me.CalendarToolsRibbonPageCategory1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.AppointmentRibbonPage1})
        Me.CalendarToolsRibbonPageCategory1.Visible = False
        '
        'BackgroundWorker1
        '
        '
        'FormScheduler
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1081, 568)
        Me.Controls.Add(Me.SchedulerControl1)
        Me.Controls.Add(Me.hideContainerRight)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.IconOptions.Image = Global.CC_JO.My.Resources.Resources.logCO12
        Me.Name = "FormScheduler"
        Me.Ribbon = Me.RibbonControl1
<<<<<<< HEAD
=======
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar1
        Me.Text = "جدول اعمال الإدارة "
        CType(Me.DateNavigator1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchedulerDataStorage1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppointmentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetScheduler, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResourcesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDuration1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hideContainerRight.ResumeLayout(False)
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.SchedulerBarController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateNavigator1 As DevExpress.XtraScheduler.DateNavigator
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents SchedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents OpenScheduleItem1 As DevExpress.XtraScheduler.UI.OpenScheduleItem
    Friend WithEvents SaveScheduleItem1 As DevExpress.XtraScheduler.UI.SaveScheduleItem
    Friend WithEvents PrintPreviewItem1 As DevExpress.XtraScheduler.UI.PrintPreviewItem
    Friend WithEvents PrintItem1 As DevExpress.XtraScheduler.UI.PrintItem
    Friend WithEvents PrintPageSetupItem1 As DevExpress.XtraScheduler.UI.PrintPageSetupItem
    Friend WithEvents NewAppointmentItem1 As DevExpress.XtraScheduler.UI.NewAppointmentItem
    Friend WithEvents NewRecurringAppointmentItem1 As DevExpress.XtraScheduler.UI.NewRecurringAppointmentItem
    Friend WithEvents NavigateViewBackwardItem1 As DevExpress.XtraScheduler.UI.NavigateViewBackwardItem
    Friend WithEvents NavigateViewForwardItem1 As DevExpress.XtraScheduler.UI.NavigateViewForwardItem
    Friend WithEvents GotoTodayItem1 As DevExpress.XtraScheduler.UI.GotoTodayItem
    Friend WithEvents ViewZoomInItem1 As DevExpress.XtraScheduler.UI.ViewZoomInItem
    Friend WithEvents ViewZoomOutItem1 As DevExpress.XtraScheduler.UI.ViewZoomOutItem
    Friend WithEvents SwitchToDayViewItem1 As DevExpress.XtraScheduler.UI.SwitchToDayViewItem
    Friend WithEvents SwitchToWorkWeekViewItem1 As DevExpress.XtraScheduler.UI.SwitchToWorkWeekViewItem
    Friend WithEvents SwitchToWeekViewItem1 As DevExpress.XtraScheduler.UI.SwitchToWeekViewItem
    Friend WithEvents SwitchToFullWeekViewItem1 As DevExpress.XtraScheduler.UI.SwitchToFullWeekViewItem
    Friend WithEvents SwitchToMonthViewItem1 As DevExpress.XtraScheduler.UI.SwitchToMonthViewItem
    Friend WithEvents SwitchToTimelineViewItem1 As DevExpress.XtraScheduler.UI.SwitchToTimelineViewItem
    Friend WithEvents SwitchToGanttViewItem1 As DevExpress.XtraScheduler.UI.SwitchToGanttViewItem
    Friend WithEvents SwitchToAgendaViewItem1 As DevExpress.XtraScheduler.UI.SwitchToAgendaViewItem
    Friend WithEvents SwitchToYearViewItem1 As DevExpress.XtraScheduler.UI.SwitchToYearViewItem
    Friend WithEvents GroupByNoneItem1 As DevExpress.XtraScheduler.UI.GroupByNoneItem
    Friend WithEvents GroupByDateItem1 As DevExpress.XtraScheduler.UI.GroupByDateItem
    Friend WithEvents GroupByResourceItem1 As DevExpress.XtraScheduler.UI.GroupByResourceItem
    Friend WithEvents SwitchTimeScalesItem1 As DevExpress.XtraScheduler.UI.SwitchTimeScalesItem
    Friend WithEvents ChangeScaleWidthItem1 As DevExpress.XtraScheduler.UI.ChangeScaleWidthItem
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents SwitchTimeScalesCaptionItem1 As DevExpress.XtraScheduler.UI.SwitchTimeScalesCaptionItem
    Friend WithEvents SwitchCompressWeekendItem1 As DevExpress.XtraScheduler.UI.SwitchCompressWeekendItem
    Friend WithEvents SwitchShowWorkTimeOnlyItem1 As DevExpress.XtraScheduler.UI.SwitchShowWorkTimeOnlyItem
    Friend WithEvents SwitchCellsAutoHeightItem1 As DevExpress.XtraScheduler.UI.SwitchCellsAutoHeightItem
    Friend WithEvents ChangeSnapToCellsUIItem1 As DevExpress.XtraScheduler.UI.ChangeSnapToCellsUIItem
    Friend WithEvents EditAppointmentQueryItem1 As DevExpress.XtraScheduler.UI.EditAppointmentQueryItem
    Friend WithEvents EditOccurrenceUICommandItem1 As DevExpress.XtraScheduler.UI.EditOccurrenceUICommandItem
    Friend WithEvents EditSeriesUICommandItem1 As DevExpress.XtraScheduler.UI.EditSeriesUICommandItem
    Friend WithEvents DeleteAppointmentsItem1 As DevExpress.XtraScheduler.UI.DeleteAppointmentsItem
    Friend WithEvents DeleteOccurrenceItem1 As DevExpress.XtraScheduler.UI.DeleteOccurrenceItem
    Friend WithEvents DeleteSeriesItem1 As DevExpress.XtraScheduler.UI.DeleteSeriesItem
    Friend WithEvents SplitAppointmentItem1 As DevExpress.XtraScheduler.UI.SplitAppointmentItem
    Friend WithEvents ChangeAppointmentStatusItem1 As DevExpress.XtraScheduler.UI.ChangeAppointmentStatusItem
    Friend WithEvents ChangeAppointmentLabelItem1 As DevExpress.XtraScheduler.UI.ChangeAppointmentLabelItem
    Friend WithEvents ToggleRecurrenceItem1 As DevExpress.XtraScheduler.UI.ToggleRecurrenceItem
    Friend WithEvents ChangeAppointmentReminderItem1 As DevExpress.XtraScheduler.UI.ChangeAppointmentReminderItem
    Friend WithEvents RepositoryItemDuration1 As DevExpress.XtraScheduler.UI.RepositoryItemDuration
    Friend WithEvents SchedulerBarController1 As DevExpress.XtraScheduler.UI.SchedulerBarController
    Friend WithEvents DataSetScheduler As DataSetScheduler
    Friend WithEvents AppointmentsBindingSource As BindingSource
    Friend WithEvents AppointmentsTableAdapter As DataSetSchedulerTableAdapters.AppointmentsTableAdapter
    Friend WithEvents ResourcesBindingSource As BindingSource
    Friend WithEvents ResourcesTableAdapter As DataSetSchedulerTableAdapters.ResourcesTableAdapter
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents hideContainerRight As DevExpress.XtraBars.Docking.AutoHideContainer
    Friend WithEvents AppointmentRibbonPage1 As DevExpress.XtraScheduler.UI.AppointmentRibbonPage
    Friend WithEvents OptionsRibbonPageGroup1 As DevExpress.XtraScheduler.UI.OptionsRibbonPageGroup
    Friend WithEvents ActionsRibbonPageGroup1 As DevExpress.XtraScheduler.UI.ActionsRibbonPageGroup
    Friend WithEvents CalendarToolsRibbonPageCategory1 As DevExpress.XtraScheduler.UI.CalendarToolsRibbonPageCategory
    Private WithEvents SchedulerDataStorage1 As DevExpress.XtraScheduler.SchedulerDataStorage
    Friend WithEvents CalendarToolsRibbonPageCategory2 As DevExpress.XtraScheduler.UI.CalendarToolsRibbonPageCategory
    Friend WithEvents AppointmentRibbonPage2 As DevExpress.XtraScheduler.UI.AppointmentRibbonPage
    Friend WithEvents ActionsRibbonPageGroup2 As DevExpress.XtraScheduler.UI.ActionsRibbonPageGroup
    Friend WithEvents OptionsRibbonPageGroup2 As DevExpress.XtraScheduler.UI.OptionsRibbonPageGroup
    Friend WithEvents FileRibbonPage1 As DevExpress.XtraScheduler.UI.FileRibbonPage
    Friend WithEvents CommonRibbonPageGroup1 As DevExpress.XtraScheduler.UI.CommonRibbonPageGroup
    Friend WithEvents PrintRibbonPageGroup1 As DevExpress.XtraScheduler.UI.PrintRibbonPageGroup
    Friend WithEvents HomeRibbonPage1 As DevExpress.XtraScheduler.UI.HomeRibbonPage
    Friend WithEvents AppointmentRibbonPageGroup1 As DevExpress.XtraScheduler.UI.AppointmentRibbonPageGroup
    Friend WithEvents NavigatorRibbonPageGroup1 As DevExpress.XtraScheduler.UI.NavigatorRibbonPageGroup
    Friend WithEvents ArrangeRibbonPageGroup1 As DevExpress.XtraScheduler.UI.ArrangeRibbonPageGroup
    Friend WithEvents GroupByRibbonPageGroup1 As DevExpress.XtraScheduler.UI.GroupByRibbonPageGroup
    Friend WithEvents ViewRibbonPage1 As DevExpress.XtraScheduler.UI.ViewRibbonPage
    Friend WithEvents ActiveViewRibbonPageGroup1 As DevExpress.XtraScheduler.UI.ActiveViewRibbonPageGroup
    Friend WithEvents TimeScaleRibbonPageGroup1 As DevExpress.XtraScheduler.UI.TimeScaleRibbonPageGroup
    Friend WithEvents LayoutRibbonPageGroup1 As DevExpress.XtraScheduler.UI.LayoutRibbonPageGroup
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
