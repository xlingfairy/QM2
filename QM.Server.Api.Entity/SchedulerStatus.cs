using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    
    public enum SchedulerStatus
    {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        Unknown = 0,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        Running = 1,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        Standby = 2,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        Shutdown = 3,
    }
}