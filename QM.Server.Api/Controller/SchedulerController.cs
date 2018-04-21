using QM.Server.Api.Entity;
using QM.Server.Api.Entity.Enums;
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
    /// Web API endpoint for scheduler information.
    /// </summary>
    [Route("api/schedulers")]
    public class SchedulerController : ApiController
    {
        [HttpGet]
        [Route("")]
        public async Task<List<SchedulerHeader>> AllSchedulers()
        {
            var schedulers = await SchedulerRepository.Instance.LookupAll().ConfigureAwait(false);
            return schedulers.Select(x => new SchedulerHeader
            {
                Name = x.SchedulerName,
                Status = x.IsStarted ? ScheduleStatus.Running : (x.IsShutdown ? ScheduleStatus.Shutdown : (x.InStandbyMode ? ScheduleStatus.Standby : ScheduleStatus.Unknown)),
                ID = x.SchedulerInstanceId
            }).ToList();
        }

        //[HttpGet]
        //[Route("{schedulerName}")]
        //public async Task<SchedulerDto> SchedulerDetails(string schedulerName)
        //{
        //    var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
        //    var metaData = await scheduler.GetMetaData().ConfigureAwait(false);
        //    return new SchedulerDto(scheduler, metaData);
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulerName"></param>
        /// <param name="delayMilliseconds"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{schedulerName}/start")]
        public async Task Start(string schedulerName, int? delayMilliseconds = null)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            if (delayMilliseconds == null)
            {
                await scheduler.Start().ConfigureAwait(false);
            }
            else
            {
                await scheduler.StartDelayed(TimeSpan.FromMilliseconds(delayMilliseconds.Value)).ConfigureAwait(false);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulerName"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{schedulerName}/standby")]
        public async Task Standby(string schedulerName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            await scheduler.Standby().ConfigureAwait(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulerName"></param>
        /// <param name="waitForJobsToComplete"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{schedulerName}/shutdown")]
        public async Task Shutdown(string schedulerName, bool waitForJobsToComplete = false)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            await scheduler.Shutdown(waitForJobsToComplete).ConfigureAwait(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulerName"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{schedulerName}/clear")]
        public async Task Clear(string schedulerName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            await scheduler.Clear().ConfigureAwait(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulerName"></param>
        /// <returns></returns>
        private static async Task<IScheduler> GetScheduler(string schedulerName)
        {
            var scheduler = await SchedulerRepository.Instance.Lookup(schedulerName).ConfigureAwait(false);
            if (scheduler == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                throw new KeyNotFoundException($"Scheduler {schedulerName} not found!");
            }
            return scheduler;
        }
    }
}
