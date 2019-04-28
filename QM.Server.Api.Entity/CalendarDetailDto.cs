using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Quartz;
using Quartz.Impl.Calendar;
using Quartz.Util;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    
    public class CalendarDetailDto
    {
        /// <summary>
        /// 
        /// </summary>
        
        public string CalendarType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CalendarDetailDto CalendarBase { get; set; }

    }



    /// <summary>
    /// 
    /// </summary>
    public class AnnualCalendarDto : CalendarDetailDto
    {
        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyCollection<DateTime> DaysExcluded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeZoneDto TimeZone { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class CronCalendarDto : CalendarDetailDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string CronExpression { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeZoneDto TimeZone { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class DailyCalendarDto : CalendarDetailDto
    {

        /// <summary>
        /// 
        /// </summary>
        public bool InvertTimeRange { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeZoneDto TimeZone { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class HolidayCalendarDto : CalendarDetailDto
    {

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<DateTime> ExcludedDates { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeZoneDto TimeZone { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class MonthlyCalendarDto : CalendarDetailDto
    {

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<bool> DaysExcluded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeZoneDto TimeZone { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class WeeklyCalendarDto : CalendarDetailDto
    {
        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<bool> DaysExcluded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeZoneDto TimeZone { get; set; }
    }
}