using Quartz;
using Quartz.Util;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    
    public class SchedulerThreadPoolDto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="metaData"></param>
        public SchedulerThreadPoolDto(SchedulerMetaData metaData)
        {
            Type = metaData.ThreadPoolType.AssemblyQualifiedNameWithoutVersion();
            Size = metaData.ThreadPoolSize;
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string Type { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        
        public int Size { get; private set; }
    }
}