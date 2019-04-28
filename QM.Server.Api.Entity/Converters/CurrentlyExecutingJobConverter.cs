using QM.Server.Api.Entity;
using Quartz;
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
    public static class CurrentlyExecutingJobConverter
    {

        public static CurrentlyExecutingJobDto ToDto(this IJobExecutionContext context)
        {
            var dto = new CurrentlyExecutingJobDto()
            {
                FireInstanceId = context.FireInstanceId,
                FireTime = context.FireTimeUtc,
                Trigger = context.Trigger.Key.ToDto(),
                Job = context.JobDetail.Key.ToDto(),
                JobRunTime = context.JobRunTime,
                RefireCount = context.RefireCount,

                Recovering = context.Recovering
            };
            if (context.Recovering)
            {
                dto.RecoveringTrigger = context.RecoveringTriggerKey.ToDto();
            }

            return dto;
        }

    }
}
