using QM.Server.Common.Attributes;
using Quartz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.Server.TestJob
{

    /// <summary>
    /// 
    /// </summary>
    [Description("Test Job A"), ParameterType(typeof(TestJobAParameter))]
    public class TestJobA : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public class TestJobAParameter
        {

            public long? HotelID { get; set; }

            [Parameter(Desc = "是否是全量同步")]
            public bool IsFullSync { get; set; }

            [Parameter(DefaultValue = "2018-01-01 12:30:00", Desc = "起始时间")]
            public DateTime? SyncBeginDate { get; set; }
        }
    }
}
