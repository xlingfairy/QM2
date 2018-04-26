using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ServerDetailsDto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulers"></param>
        public ServerDetailsDto(IEnumerable<IScheduler> schedulers)
        {
            Name = Environment.MachineName;
            Address = "localhost";
            Schedulers = schedulers.Select(x => x.SchedulerName).ToList();
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
        public string Address { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public IReadOnlyList<string> Schedulers { get; set; } 
    }
}