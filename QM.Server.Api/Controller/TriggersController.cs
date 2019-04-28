using QM.Server.Api.Converters;
using QM.Server.Api.Entity;
using Quartz;
using Quartz.Impl;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace QM.Server.Api.Controller
{

    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/schedulers/{schedulerName}/triggers")]
    public class TriggersController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulerName"></param>
        /// <param name="groupMatcher"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IReadOnlyList<KeyDto>> Triggers(string schedulerName, GroupMatcherDto groupMatcher)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            var matcher = (groupMatcher ?? new GroupMatcherDto()).GetTriggerGroupMatcher();
            var jobKeys = await scheduler.GetTriggerKeys(matcher).ConfigureAwait(false);

            return jobKeys.Select(x => x.ToDto()).ToList();
        }

        [HttpGet]
        [Route("{triggerGroup}/{triggerName}/details")]
        public async Task<TriggerDetailDto> TriggerDetails(string schedulerName, string triggerGroup, string triggerName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            var trigger = await scheduler.GetTrigger(new TriggerKey(triggerName, triggerGroup)).ConfigureAwait(false);
            var calendar = trigger.CalendarName != null
                ? await scheduler.GetCalendar(trigger.CalendarName).ConfigureAwait(false)
                : null;
            return  trigger.ToDto(calendar);
        }

        [HttpPost]
        [Route("{triggerGroup}/{triggerName}/pause")]
        public async Task PauseTrigger(string schedulerName, string triggerGroup, string triggerName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            await scheduler.PauseTrigger(new TriggerKey(triggerName, triggerGroup)).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("pause")]
        public async Task PauseTriggers(string schedulerName, GroupMatcherDto groupMatcher)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            var matcher = (groupMatcher ?? new GroupMatcherDto()).GetTriggerGroupMatcher();
            await scheduler.PauseTriggers(matcher).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("{triggerGroup}/{triggerName}/resume")]
        public async Task ResumeTrigger(string schedulerName, string triggerGroup, string triggerName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            await scheduler.ResumeTrigger(new TriggerKey(triggerName, triggerGroup)).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("resume")]
        public async Task ResumeTriggers(string schedulerName, GroupMatcherDto groupMatcher)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            var matcher = (groupMatcher ?? new GroupMatcherDto()).GetTriggerGroupMatcher();
            await scheduler.ResumeTriggers(matcher).ConfigureAwait(false);
        }

    }
}