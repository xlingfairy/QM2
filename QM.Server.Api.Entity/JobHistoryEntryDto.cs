using System;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class JobHistoryEntryDto
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string JobName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string JobGroup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string TriggerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string TriggerGroup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTimeOffset FiredTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTimeOffset ScheduledTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public TimeSpan RunTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool Error { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}