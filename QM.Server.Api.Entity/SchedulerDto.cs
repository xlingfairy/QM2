using Quartz;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
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
        [DataMember]
        public string SchedulerInstanceId { get; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public SchedulerStatus Status { get; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public SchedulerThreadPoolDto ThreadPool { get; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public SchedulerJobStoreDto JobStore { get; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public SchedulerStatisticsDto Statistics { get; }
    }
}