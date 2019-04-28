using QM.Server.Api.Entity;
using Quartz;
using Quartz.Spi;
using Quartz.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QM.Server.Api.Entity.TriggerDetailDto;

namespace QM.Server.Api.Converters
{
    /// <summary>
    /// 
    /// </summary>
    public static class TriggerDetailConverter
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="calendar"></param>
        public static TriggerDetailDto ToDto(this ITrigger trigger, ICalendar calendar)
        {

            TriggerDetailDto dto = null;

            if (trigger is ISimpleTrigger simpleTrigger)
            {
                dto = new SimpleTriggerDetailDto(simpleTrigger);
            }
            if (trigger is ICronTrigger cronTrigger)
            {
                dto = new CronTriggerDetailDto(cronTrigger);
            }
            if (trigger is ICalendarIntervalTrigger calendarIntervalTrigger)
            {
                dto = new CalendarIntervalTriggerDetailDto(calendarIntervalTrigger);
            }
            if (trigger is IDailyTimeIntervalTrigger dailyTimeIntervalTrigger)
            {
                dto = new DailyTimeIntervalTriggerDetailDto(dailyTimeIntervalTrigger);
            }
            else
            {
                dto = new TriggerDetailDto();
            }

            dto.Description = trigger.Description;
            dto.TriggerType = trigger.GetType().AssemblyQualifiedNameWithoutVersion();
            dto.Name = trigger.Key.Name;
            dto.Group = trigger.Key.Group;
            dto.CalendarName = trigger.CalendarName;
            dto.Priority = trigger.Priority;
            dto.StartTimeUtc = trigger.StartTimeUtc;
            dto.EndTimeUtc = trigger.EndTimeUtc;
            dto.NextFireTimes = TriggerUtils.ComputeFireTimes((IOperableTrigger)trigger, calendar, 10);

            return dto;
        }



    }
}
