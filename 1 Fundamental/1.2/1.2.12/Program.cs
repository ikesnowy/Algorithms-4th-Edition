using System;
using _1._2._12;

var today = new SmartDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year);
Console.WriteLine(today.DayOfTheWeek());