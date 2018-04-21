using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.Server
{

    /// <summary>
    /// 
    /// </summary>
    public class IsolatedJobFactory : IJobFactory
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bundle"></param>
        /// <param name="scheduler"></param>
        /// <returns></returns>
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return NewJob(bundle.JobDetail.JobType);
        }

        private IJob NewJob(Type jobType)
        {
            return new IsolatedJob(jobType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="job"></param>
        public void ReturnJob(IJob job)
        {
            if (job is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
