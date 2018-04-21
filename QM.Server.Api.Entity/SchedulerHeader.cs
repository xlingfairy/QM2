using QM.Server.Api.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.Server.Api.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class SchedulerHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ScheduleStatus Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ID { get; set; }
    }
}
