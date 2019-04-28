using Quartz;
using System;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    
    public class CurrentlyExecutingJobDto
    {
        /// <summary>
        /// 
        /// </summary>
        
        public string FireInstanceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public DateTimeOffset? FireTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public KeyDto Trigger { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public KeyDto Job { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public TimeSpan JobRunTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public int RefireCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public KeyDto RecoveringTrigger { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public bool Recovering { get; set; }
    }
}