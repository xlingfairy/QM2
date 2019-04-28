using Quartz;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{
    /// <summary>
    /// 
    /// </summary>
    
    public class SchedulerDto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduler"></param>
        /// <param name="metaData"></param>
        public SchedulerDto(IScheduler scheduler, SchedulerMetaData metaData)
        {
            Name = scheduler.SchedulerName;
            SchedulerInstanceId = scheduler.SchedulerInstanceId;
            Status = SchedulerHeaderDto.TranslateStatus(scheduler);

            ThreadPool = new SchedulerThreadPoolDto(metaData);
            JobStore = new SchedulerJobStoreDto(metaData);
            Statistics = new SchedulerStatisticsDto(metaData);
        }


        /// <summary>
        /// 
        /// </summary>
        
        public string SchedulerInstanceId { get; }

        /// <summary>
        /// 
        /// </summary>
        
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        
        public SchedulerStatus Status { get; }

        /// <summary>
        /// 
        /// </summary>
        
        public SchedulerThreadPoolDto ThreadPool { get; }

        /// <summary>
        /// 
        /// </summary>
        
        public SchedulerJobStoreDto JobStore { get; }

        /// <summary>
        /// 
        /// </summary>
        
        public SchedulerStatisticsDto Statistics { get; }
    }
}