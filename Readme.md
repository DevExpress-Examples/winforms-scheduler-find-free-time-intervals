<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128634929/13.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E508)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# How to find free time intervals for a meeting arrangement


<p>This example illustrates the use of <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraSchedulerToolsFreeTimeCalculatortopic"><u>FreeTimeCalculator</u></a> class to find all available free intervals within the specified period of time. Also, it can be used to find the nearest free slot with the specified duration.<br />
When the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerToolsFreeTimeCalculator_FindFreeTimeIntervaltopic1125"><u>FindFreeTimeInterval</u></a> method finds an interval that does not intersect with existing appointments, the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerToolsFreeTimeCalculator_IntervalFoundtopic"><u>IntervalFound</u></a> event occurs. We handle this event to exclude intervals which fall into restricted areas, such as non-working hours or holidays.</p><p>This application finds a free slot with specified duration within the work time before the end of the current work week. The non-working time is defined in code as an interval from 6 PM current day to 8 AM next day.The project uses SQL Server so the corresponding detached database files - XtraScheduling.mdf and XtraScheduling_log.ldf are included. You should attach the databases to the MS SQL server and change a connection string in the app.config file before running the project.</p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-find-free-time-intervals&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-find-free-time-intervals&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
