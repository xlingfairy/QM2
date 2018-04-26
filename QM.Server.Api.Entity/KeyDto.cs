using Quartz;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class KeyDto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobKey"></param>
        public KeyDto(JobKey jobKey)
        {
            Name = jobKey.Name;
            Group = jobKey.Group;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="triggerKey"></param>
        public KeyDto(TriggerKey triggerKey)
        {
            Name = triggerKey.Name;
            Group = triggerKey.Group;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Group { get; private set; }
    }
}