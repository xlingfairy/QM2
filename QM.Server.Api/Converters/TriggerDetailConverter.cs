using QM.Server.Api.Entity;
using Quartz;
using Quartz.Spi;
using Quartz.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return new TriggerDetailDto()
            {
                Description = trigger.Description,
                TriggerType = trigger.GetType().AssemblyQualifiedNameWithoutVersion(),
                Name = trigger.Key.Name,
                Group = trigger.Key.Group,
                CalendarName = trigger.CalendarName,
                Priority = trigger.Priority,
                StartTimeUtc = trigger.StartTimeUtc,
                EndTimeUtc = trigger.EndTimeUtc,
                NextFireTimes = TriggerUtils.ComputeFireTimes((IOperableTrigger)trigger, calendar, 10)
            };
        }

    }
}
