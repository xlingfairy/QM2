using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace QM.Server.Api.Controller
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseController : ApiController
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulerName"></param>
        /// <returns></returns>
        protected async Task<IScheduler> GetScheduler(string schedulerName)
        {
            var scheduler = await SchedulerRepository.Instance.Lookup(schedulerName).ConfigureAwait(false);
            if (scheduler == null)
            {
                throw new KeyNotFoundException($"Scheduler {schedulerName} not found!");
            }
            return scheduler;
        }

    }
}
