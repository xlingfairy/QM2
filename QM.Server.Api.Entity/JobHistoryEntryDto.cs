using System;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    
    public class JobHistoryEntryDto
    {
        /// <summary>
        /// 
        /// </summary>
        
        public string JobName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string JobGroup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string TriggerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string TriggerGroup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public DateTimeOffset FiredTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public DateTimeOffset ScheduledTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public TimeSpan RunTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public bool Error { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string ErrorMessage { get; set; }
    }
}