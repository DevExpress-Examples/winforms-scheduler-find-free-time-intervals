Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Tools
Imports System
Imports System.Windows.Forms

Namespace FreeTimeIntervals

    Public Partial Class Form1
        Inherits Form

        Private timeZoneHelperField As TimeZoneHelper

        ' Specify non-working time interval.
        Private nonWorkingTimeField As TimeOfDayInterval = New TimeOfDayInterval(TimeSpan.FromHours(18), TimeSpan.FromDays(1) + TimeSpan.FromHours(9))

        Friend ReadOnly Property TimeZoneHelper As TimeZoneHelper
            Get
                Return timeZoneHelperField
            End Get
        End Property

        Friend Property NonWorkingTime As TimeOfDayInterval
            Get
                Return nonWorkingTimeField
            End Get

            Set(ByVal value As TimeOfDayInterval)
                nonWorkingTimeField = value
            End Set
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' TODO: This line of code loads data into the 'xtraSchedulingDataSet1.Resources' table. You can move, or remove it, as needed.
            resourcesTableAdapter.Fill(xtraSchedulingDataSet1.Resources)
            ' TODO: This line of code loads data into the 'xtraSchedulingDataSet.Appointments' table. You can move, or remove it, as needed.
            appointmentsTableAdapter.Fill(xtraSchedulingDataSet.Appointments)
            timeZoneHelperField = New TimeZoneHelper(schedulerControl1.OptionsBehavior.ClientTimeZoneId)
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim duration As TimeSpan =(CDate(slotDuration.EditValue)).TimeOfDay
            Dim start As Date = schedulerControl1.ActiveView.SelectedInterval.End
            Dim startOfWeek As Date = Native.DateTimeHelper.GetStartOfWeek(start)
            Dim interval As TimeInterval = New TimeInterval(start, startOfWeek.AddDays(7))
            Dim freeTime As TimeInterval = FindInterval(interval, duration)
            Dim text As String
            If Equals(freeTime, TimeInterval.Empty) Then
                text = "Not found"
            Else
                Dim clientFreeInterval As TimeInterval = TimeZoneHelper.ToClientTime(freeTime)
                text = "Free time interval with duration " & clientFreeInterval.Duration.ToString() & " is found! " & Microsoft.VisualBasic.Constants.vbLf & Microsoft.VisualBasic.Constants.vbCr & " It starts on " & clientFreeInterval.Start.Date.ToShortDateString() & " at " & clientFreeInterval.Start.TimeOfDay.ToString() & "."
                schedulerControl1.ActiveView.SetSelection(clientFreeInterval, Resource.Empty)
            End If

            MessageBox.Show(text, "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Function FindInterval(ByVal clientInterval As TimeInterval, ByVal duration As TimeSpan) As TimeInterval
            Dim calculator As FreeTimeCalculator = New FreeTimeCalculator(schedulerControl1.Storage)
            ' Set a handler for the IntervalFound event.
            AddHandler calculator.IntervalFound, New IntervalFoundEventHandler(AddressOf OnIntervalFound)
            Dim interval As TimeInterval = TimeZoneHelper.FromClientTime(clientInterval)
            ' Call the method which raises the event.
            Return calculator.FindFreeTimeInterval(interval, duration, True)
        End Function

        Private Sub OnIntervalFound(ByVal sender As Object, ByVal args As IntervalFoundEventArgs)
            Dim freeIntervals As TimeIntervalCollectionEx = args.FreeIntervals
            Dim start As Date = freeIntervals.Start.Date.AddDays(-1)
            Dim [end] As Date = freeIntervals.End
            While start < [end]
                RemoveNonWorkingTime(freeIntervals, start)
                RemoveNonWorkingDay(freeIntervals, start)
                start += TimeSpan.FromDays(1)
            End While
        End Sub

        Private Sub RemoveNonWorkingTime(ByVal freeIntervals As TimeIntervalCollectionEx, ByVal [date] As Date)
            Dim clientDate As Date = TimeZoneHelper.ToClientTime([date]).Date
            Dim clientNonWorkingTime As TimeInterval = New TimeInterval(clientDate + NonWorkingTime.Start, clientDate + NonWorkingTime.End)
            freeIntervals.Remove(TimeZoneHelper.FromClientTime(clientNonWorkingTime))
        End Sub

        Private Sub RemoveNonWorkingDay(ByVal freeIntervals As TimeIntervalCollectionEx, ByVal [date] As Date)
            Dim clientDate As Date = TimeZoneHelper.ToClientTime([date]).Date
            Dim isWorkDay As Boolean = schedulerControl1.WorkDays.IsWorkDay(clientDate)
            If Not isWorkDay Then
                Dim clientInterval As TimeInterval = New TimeInterval(clientDate, TimeSpan.FromDays(1))
                freeIntervals.Remove(TimeZoneHelper.FromClientTime(clientInterval))
            End If
        End Sub

        Private Sub OnApptChangedInsertedDeleted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            appointmentsTableAdapter.Update(xtraSchedulingDataSet)
            xtraSchedulingDataSet.AcceptChanges()
        End Sub
    End Class
End Namespace
