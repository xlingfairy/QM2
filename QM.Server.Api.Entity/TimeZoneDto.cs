using System;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class TimeZoneDto
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeZone"></param>
        public TimeZoneDto(TimeZoneInfo timeZone)
        {
            Id = timeZone.Id;
            StandardName = timeZone.StandardName;
            DisplayName = timeZone.DisplayName;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Id { get; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string StandardName { get; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string DisplayName { get; }
    }
}