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
        
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string Address { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        
        public IReadOnlyList<string> Schedulers { get; set; } 
    }
}