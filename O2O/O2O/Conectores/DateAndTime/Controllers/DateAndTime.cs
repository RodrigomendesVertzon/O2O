using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2O.Conectores.DateAndTime.Controllers
{
    public class DateAndTime
    {

        public double DateDiffDays(DateTime DateInit, DateTime DateEnd) 
        {
            double days;
            days = (DateEnd - DateInit).TotalDays;
            return days;
        
        }

        public double DateDiffHours(DateTime DateInit, DateTime DateEnd)
        {
            double days;
            days = (DateEnd - DateInit).TotalHours;
            return days;

        }

        public double DateDiffMinutes(DateTime DateInit, DateTime DateEnd)
        {
            double days;
            days = (DateEnd - DateInit).TotalMinutes;
            return days;

        }   


        public DateTime AddDaysToDate(DateTime Date, int days)
        {
            return Date.AddDays(days);
        }

        public DateTime AddMinutesToDate(DateTime Date, int minutes)
        {
            return Date.AddMinutes(minutes);
        }

        public DateTime AddHoursToDate(DateTime Date, int hours)
        {
            return Date.AddHours(hours);
        }

        public DateTime AddYearsToDate(DateTime Date, int years)
        {
            return Date.AddYears(years);
        }

    }
}