<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128634929/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E508)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Scheduler - Find free time for a meeting

This example uses the [FreeTimeCalculator](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraScheduler.Tools.FreeTimeCalculator) class to find all available free time intervals within the specified period of time. You can also use this class to find the nearest free time slot with the specified duration.

The [FindFreeTimeInterval](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraScheduler.Tools.FreeTimeCalculator.FindFreeTimeInterval.overloads) method raises the [IntervalFound](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraScheduler.Tools.FreeTimeCalculator.IntervalFound) event if it finds an interval that does not overlap with existing appointments. The example handles this event to exclude intervals that fall within "restricted" areas, such as non-working hours and holidays.

This example looks for a free time slot with the specified duration within the work time before the end of the current work week.

> **Note**
>
> The example uses SQL Server (*XtraScheduling.mdf*, *XtraScheduling_log.ldf*). You should attach databases to the MS SQL server and change the connection string in the *app.config* file before you start the project.


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-find-free-time-intervals&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-find-free-time-intervals&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
