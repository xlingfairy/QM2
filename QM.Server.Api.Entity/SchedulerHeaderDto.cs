using Quartz;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    
    public class SchedulerHeaderDto
    {
        public SchedulerHeaderDto(IScheduler scheduler)
        {
            Name = scheduler.SchedulerName;
            SchedulerInstanceId = scheduler.SchedulerInstanceId;
            Status = TranslateStatus(scheduler);
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string SchedulerInstanceId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        
        public SchedulerStatus Status { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduler"></param>
        /// <returns></returns>
        internal static SchedulerStatus TranslateStatus(IScheduler scheduler)
        {
            if (scheduler.IsShutdown)
            {
                return SchedulerStatus.Shutdown;
            }
            if (scheduler.InStandbyMode)
            {
                return SchedulerStatus.Standby;
            }
            if (scheduler.IsStarted)
            {
                return SchedulerStatus.Running;
            }
            return SchedulerStatus.Unknown;
        }
    }
}