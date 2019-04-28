using Quartz;
using Quartz.Util;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{
    /// <summary>
    /// 
    /// </summary>
    
    public class JobDetailDto
    {
        public JobDetailDto(IJobDetail jobDetail)
        {
            Durable = jobDetail.Durable;
            ConcurrentExecutionDisallowed = jobDetail.ConcurrentExecutionDisallowed;
            Description = jobDetail.Description;
            JobType = jobDetail.JobType.AssemblyQualifiedNameWithoutVersion();
            Name = jobDetail.Key.Name;
            Group = jobDetail.Key.Group;
            PersistJobDataAfterExecution = jobDetail.PersistJobDataAfterExecution;
            RequestsRecovery = jobDetail.RequestsRecovery;
        }

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
        
        public string JobType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public bool Durable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public bool RequestsRecovery { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public bool PersistJobDataAfterExecution { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public bool ConcurrentExecutionDisallowed { get; set; }
    }
}