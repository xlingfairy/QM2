using QM.Server.Api.Entity;
using Quartz;
using Quartz.Impl.Calendar;
using Quartz.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QM.Server.Api.Entity.CalendarDetailDto;

namespace QM.Server.Api.Converters
{

    /// <summary>
    /// 
    /// </summary>
    public static class CalendarConverter
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static CalendarDetailDto ToDto(this ICalendar calendar)
        {
            CalendarDetailDto cd = null;

            if (calendar is AnnualCalendar annualCalendar)
            {
                cd = new AnnualCalendarDto()
                {
                    DaysExcluded = annualCalendar.DaysExcluded,
                    TimeZone = annualCalendar.TimeZone.ToDto()
                };
            }
            else if (calendar is CronCalendar cronCalendar)
            {
                cd = new CronCalendarDto()
                {
                    CronExpression = cronCalendar.CronExpression.CronExpressionString,
                    TimeZone = cronCalendar.TimeZone.ToDto()
                };
            }
            else if (calendar is DailyCalendar dailyCalendar)
            {
                cd = new DailyCalendarDto()
                {
                    InvertTimeRange = dailyCalendar.InvertTimeRange,
                    TimeZone = dailyCalendar.TimeZone.ToDto()
                };
            }
            else if (calendar is HolidayCalendar holidayCalendar)
            {
                cd = new HolidayCalendarDto()
                {
                    ExcludedDates = holidayCalendar.ExcludedDates.ToList(),
                    TimeZone = holidayCalendar.TimeZone.ToDto()
                };
            }
            else if (calendar is MonthlyCalendar monthlyCalendar)
            {
                cd = new MonthlyCalendarDto()
                {
                    DaysExcluded = monthlyCalendar.DaysExcluded.ToList(),
                    TimeZone = monthlyCalendar.TimeZone.ToDto()
                };
            }
            else if (calendar is WeeklyCalendar weeklyCalendar)
            {
                cd = new WeeklyCalendarDto()
                {
                    DaysExcluded = weeklyCalendar.DaysExcluded.ToList(),
                    TimeZone = weeklyCalendar.TimeZone.ToDto()
                };
            }
            else
            {
                cd = new CalendarDetailDto();
            }

            //
            cd.CalendarType = calendar.GetType().AssemblyQualifiedNameWithoutVersion();
            cd.Description = calendar.Description;

            if (calendar.CalendarBase != null)
            {
                cd.CalendarBase = calendar.CalendarBase.ToDto();
            }

            return cd;
        }

    }
}
