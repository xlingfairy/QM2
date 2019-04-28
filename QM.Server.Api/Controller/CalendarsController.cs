using QM.Server.Api.Converters;
using QM.Server.Api.Entity;
using Quartz;
using Quartz.Impl;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace QM.Server.Api.Controller
{

    /// <summary>
    /// 日历
    /// </summary>
    [RoutePrefix("api/schedulers/{schedulerName}/calendars")]
    public class CalendarsController : BaseController
    {
        /// <summary>
        /// 列出所有日历
        /// </summary>
        /// <param name="schedulerName">调度器名称</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IReadOnlyCollection<string>> Calendars(string schedulerName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            var calendarNames = await scheduler.GetCalendarNames().ConfigureAwait(false);

            return calendarNames;
        }

        /// <summary>
        /// 获取日历信息
        /// </summary>
        /// <param name="schedulerName">调度器名称</param>
        /// <param name="calendarName">日历名称</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{calendarName}")]
        public async Task<CalendarDetailDto> CalendarDetails(string schedulerName, string calendarName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            var calendar = await scheduler.GetCalendar(calendarName).ConfigureAwait(false);
            return calendar.ToDto();
        }

        /// <summary>
        /// 添加日历
        /// </summary>
        /// <param name="schedulerName">调度器名称</param>
        /// <param name="calendarName">日历名称</param>
        /// <param name="replace">如果存在同名的日历,是否替换</param>
        /// <param name="updateTriggers">是否更新触发器</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{calendarName}")]
        public async Task AddCalendar(string schedulerName, string calendarName, bool replace, bool updateTriggers)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            ICalendar calendar = null;
            await scheduler.AddCalendar(calendarName, calendar, replace, updateTriggers).ConfigureAwait(false);
        }

        /// <summary>
        /// 删除日历
        /// </summary>
        /// <param name="schedulerName">调度器名称</param>
        /// <param name="calendarName">日历名称</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{calendarName}")]
        public async Task DeleteCalendar(string schedulerName, string calendarName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            await scheduler.DeleteCalendar(calendarName).ConfigureAwait(false);
        }

    }
}