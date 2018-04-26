using Quartz;
using Quartz.Util;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
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
        [DataMember]
        public string Type { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Size { get; private set; }
    }
}