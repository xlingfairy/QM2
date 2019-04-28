using Quartz;
using Quartz.Util;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    
    public class SchedulerJobStoreDto
    {
        public SchedulerJobStoreDto(SchedulerMetaData metaData)
        {
            Type = metaData.JobStoreType.AssemblyQualifiedNameWithoutVersion();
            Clustered = metaData.JobStoreClustered;
            Persistent = metaData.JobStoreSupportsPersistence;
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string Type { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        
        public bool Clustered { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        
        public bool Persistent { get; private set; }
    }
}