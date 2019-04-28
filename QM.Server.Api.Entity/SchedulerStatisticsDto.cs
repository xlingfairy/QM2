using Quartz;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{
    /// <summary>
    /// 
    /// </summary>
    
    public class SchedulerStatisticsDto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="metaData"></param>
        public SchedulerStatisticsDto(SchedulerMetaData metaData)
        {
            NumberOfJobsExecuted = metaData.NumberOfJobsExecuted;
        }

        /// <summary>
        /// 
        /// </summary>
        
        public int NumberOfJobsExecuted { get; private set; }
    }
}