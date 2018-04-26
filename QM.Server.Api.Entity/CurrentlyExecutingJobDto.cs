using Quartz;
using System;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class CurrentlyExecutingJobDto
    {
        public CurrentlyExecutingJobDto(IJobExecutionContext context)
        {
            FireInstanceId = context.FireInstanceId;
            FireTime = context.FireTimeUtc;
            Trigger = new KeyDto(context.Trigger.Key);
            Job = new KeyDto(context.JobDetail.Key);
            JobRunTime = context.JobRunTime;
            RefireCount = context.RefireCount;

            Recovering = context.Recovering;
            if (context.Recovering)
            {
                RecoveringTrigger = new KeyDto(context.RecoveringTriggerKey);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FireInstanceId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTimeOffset? FireTime { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public KeyDto Trigger { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public KeyDto Job { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public TimeSpan JobRunTime { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int RefireCount { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public KeyDto RecoveringTrigger { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool Recovering { get; private set; }
    }
}