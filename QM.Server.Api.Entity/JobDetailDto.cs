using Quartz;
using Quartz.Util;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
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
        public string JobType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool Durable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool RequestsRecovery { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool PersistJobDataAfterExecution { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool ConcurrentExecutionDisallowed { get; set; }
    }
}