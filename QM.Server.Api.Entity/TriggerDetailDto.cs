using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Quartz;
using Quartz.Spi;
using Quartz.Util;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class TriggerDetailDto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="calendar"></param>
        protected TriggerDetailDto(ITrigger trigger, ICalendar calendar)
        {
            Description = trigger.Description;
            TriggerType = trigger.GetType().AssemblyQualifiedNameWithoutVersion();
            Name = trigger.Key.Name;
            Group = trigger.Key.Group;
            CalendarName = trigger.CalendarName;
            Priority = trigger.Priority;
            StartTimeUtc = trigger.StartTimeUtc;
            EndTimeUtc = trigger.EndTimeUtc;
            NextFireTimes = TriggerUtils.ComputeFireTimes((IOperableTrigger)trigger, calendar, 10);
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Group { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string TriggerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CalendarName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTimeOffset StartTimeUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTimeOffset? EndTimeUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public IReadOnlyList<DateTimeOffset> NextFireTimes { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static TriggerDetailDto Create(ITrigger trigger, ICalendar calendar)
        {
            if (trigger is ISimpleTrigger simpleTrigger)
            {
                return new SimpleTriggerDetailDto(simpleTrigger, calendar);
            }
            if (trigger is ICronTrigger cronTrigger)
            {
                return new CronTriggerDetailDto(cronTrigger, calendar);
            }
            if (trigger is ICalendarIntervalTrigger calendarIntervalTrigger)
            {
                return new CalendarIntervalTriggerDetailDto(calendarIntervalTrigger, calendar);
            }
            if (trigger is IDailyTimeIntervalTrigger dailyTimeIntervalTrigger)
            {
                return new DailyTimeIntervalTriggerDetailDto(dailyTimeIntervalTrigger, calendar);
            }

            return new TriggerDetailDto(trigger, calendar);
        }


        /// <summary>
        /// 
        /// </summary>
        [DataContract]
        public class CronTriggerDetailDto : TriggerDetailDto
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="trigger"></param>
            /// <param name="calendar"></param>
            public CronTriggerDetailDto(ICronTrigger trigger, ICalendar calendar) : base(trigger, calendar)
            {
                CronExpression = trigger.CronExpressionString;
                TimeZone = new TimeZoneDto(trigger.TimeZone);
            }

            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public string CronExpression { get; }

            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public TimeZoneDto TimeZone { get; }
        }


        /// <summary>
        /// 
        /// </summary>
        [DataContract]
        public class SimpleTriggerDetailDto : TriggerDetailDto
        {

            /// <summary>
            /// 
            /// </summary>
            /// <param name="trigger"></param>
            /// <param name="calendar"></param>
            public SimpleTriggerDetailDto(ISimpleTrigger trigger, ICalendar calendar) : base(trigger, calendar)
            {
                RepeatCount = trigger.RepeatCount;
                RepeatInterval = trigger.RepeatInterval;
                TimesTriggered = trigger.TimesTriggered;
            }


            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public TimeSpan RepeatInterval { get; }

            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public int RepeatCount { get; }

            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public int TimesTriggered { get; }
        }


        /// <summary>
        /// 
        /// </summary>
        [DataContract]
        public class CalendarIntervalTriggerDetailDto : TriggerDetailDto
        {
            public CalendarIntervalTriggerDetailDto(ICalendarIntervalTrigger trigger, ICalendar calendar) : base(trigger, calendar)
            {
                RepeatInterval = trigger.RepeatInterval;
                TimesTriggered = trigger.TimesTriggered;
                RepeatIntervalUnit = trigger.RepeatIntervalUnit;
                PreserveHourOfDayAcrossDaylightSavings = trigger.PreserveHourOfDayAcrossDaylightSavings;
                TimeZone = new TimeZoneDto(trigger.TimeZone);
                SkipDayIfHourDoesNotExist = trigger.SkipDayIfHourDoesNotExist;
            }

            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public TimeZoneDto TimeZone { get; }

            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public bool SkipDayIfHourDoesNotExist { get; }

            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public bool PreserveHourOfDayAcrossDaylightSavings { get; }

            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public IntervalUnit RepeatIntervalUnit { get; }

            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public int RepeatInterval { get; }

            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public int TimesTriggered { get; }
        }


        /// <summary>
        /// 
        /// </summary>
        [DataContract]
        public class DailyTimeIntervalTriggerDetailDto : TriggerDetailDto
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="trigger"></param>
            /// <param name="calendar"></param>
            public DailyTimeIntervalTriggerDetailDto(IDailyTimeIntervalTrigger trigger, ICalendar calendar) : base(trigger, calendar)
            {
                RepeatInterval = trigger.RepeatInterval;
                TimesTriggered = trigger.TimesTriggered;
                RepeatIntervalUnit = trigger.RepeatIntervalUnit;
                TimeZone = new TimeZoneDto(trigger.TimeZone);
            }

            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public TimeZoneDto TimeZone { get; }

            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public IntervalUnit RepeatIntervalUnit { get; }

            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public int TimesTriggered { get; }

            /// <summary>
            /// 
            /// </summary>
            [DataMember]
            public int RepeatInterval { get; }
        }
    }
}