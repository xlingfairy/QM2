using QM.Server.Api.Converters;
using Quartz;
using System;
using System.Collections.Generic;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>

    public class TriggerDetailDto
    {
        /// <summary>
        /// 
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string Group { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string TriggerType { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string CalendarName { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public int Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public DateTimeOffset StartTimeUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public DateTimeOffset? EndTimeUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>

        public IReadOnlyList<DateTimeOffset> NextFireTimes { get; set; }



        /// <summary>
        /// 
        /// </summary>

        public class CronTriggerDetailDto : TriggerDetailDto
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="trigger"></param>
            /// <param name="calendar"></param>
            public CronTriggerDetailDto(ICronTrigger trigger)
            {
                CronExpression = trigger.CronExpressionString;
                TimeZone = trigger.TimeZone.ToDto();
            }

            /// <summary>
            /// 
            /// </summary>

            public string CronExpression { get; }

            /// <summary>
            /// 
            /// </summary>

            public TimeZoneDto TimeZone { get; }
        }


        /// <summary>
        /// 
        /// </summary>

        public class SimpleTriggerDetailDto : TriggerDetailDto
        {

            /// <summary>
            /// 
            /// </summary>
            /// <param name="trigger"></param>
            /// <param name="calendar"></param>
            public SimpleTriggerDetailDto(ISimpleTrigger trigger)
            {
                RepeatCount = trigger.RepeatCount;
                RepeatInterval = trigger.RepeatInterval;
                TimesTriggered = trigger.TimesTriggered;
            }


            /// <summary>
            /// 
            /// </summary>

            public TimeSpan RepeatInterval { get; }

            /// <summary>
            /// 
            /// </summary>

            public int RepeatCount { get; }

            /// <summary>
            /// 
            /// </summary>

            public int TimesTriggered { get; }
        }


        /// <summary>
        /// 
        /// </summary>

        public class CalendarIntervalTriggerDetailDto : TriggerDetailDto
        {
            public CalendarIntervalTriggerDetailDto(ICalendarIntervalTrigger trigger)
            {
                RepeatInterval = trigger.RepeatInterval;
                TimesTriggered = trigger.TimesTriggered;
                RepeatIntervalUnit = trigger.RepeatIntervalUnit;
                PreserveHourOfDayAcrossDaylightSavings = trigger.PreserveHourOfDayAcrossDaylightSavings;
                TimeZone = trigger.TimeZone.ToDto(); //new TimeZoneDto(trigger.TimeZone);
                SkipDayIfHourDoesNotExist = trigger.SkipDayIfHourDoesNotExist;
            }

            /// <summary>
            /// 
            /// </summary>

            public TimeZoneDto TimeZone { get; }

            /// <summary>
            /// 
            /// </summary>

            public bool SkipDayIfHourDoesNotExist { get; }

            /// <summary>
            /// 
            /// </summary>

            public bool PreserveHourOfDayAcrossDaylightSavings { get; }

            /// <summary>
            /// 
            /// </summary>

            public IntervalUnit RepeatIntervalUnit { get; }

            /// <summary>
            /// 
            /// </summary>

            public int RepeatInterval { get; }

            /// <summary>
            /// 
            /// </summary>

            public int TimesTriggered { get; }
        }


        /// <summary>
        /// 
        /// </summary>

        public class DailyTimeIntervalTriggerDetailDto : TriggerDetailDto
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="trigger"></param>
            /// <param name="calendar"></param>
            public DailyTimeIntervalTriggerDetailDto(IDailyTimeIntervalTrigger trigger)
            {
                RepeatInterval = trigger.RepeatInterval;
                TimesTriggered = trigger.TimesTriggered;
                RepeatIntervalUnit = trigger.RepeatIntervalUnit;
                TimeZone = trigger.TimeZone.ToDto();
            }

            /// <summary>
            /// 
            /// </summary>

            public TimeZoneDto TimeZone { get; }

            /// <summary>
            /// 
            /// </summary>

            public IntervalUnit RepeatIntervalUnit { get; }

            /// <summary>
            /// 
            /// </summary>

            public int TimesTriggered { get; }

            /// <summary>
            /// 
            /// </summary>

            public int RepeatInterval { get; }
        }
    }
}