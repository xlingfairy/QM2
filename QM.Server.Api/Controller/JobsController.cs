using QM.Server.Api.Converters;
using QM.Server.Api.Entity;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace QM.Server.Api.Controller
{

    /// <summary>
    /// 任务
    /// </summary>
    [RoutePrefix("api/schedulers/{schedulerName}/jobs")]
    public class JobsController : BaseController
    {
        /// <summary>
        /// 任务查找
        /// </summary>
        /// <param name="schedulerName"></param>
        /// <param name="groupMatcher"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<IReadOnlyList<KeyDto>> Jobs(string schedulerName, GroupMatcherDto groupMatcher)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            var matcher = (groupMatcher ?? new GroupMatcherDto()).GetJobGroupMatcher();
            var jobKeys = await scheduler.GetJobKeys(matcher).ConfigureAwait(false);
            return jobKeys.Select(x => x.ToDto()).ToList();
        }

        /// <summary>
        /// 获取任务详情
        /// </summary>
        /// <param name="schedulerName">调度器名称</param>
        /// <param name="jobGroup">任务分组</param>
        /// <param name="jobName">任务名称</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{jobGroup}/{jobName}/details")]
        public async Task<JobDetailDto> JobDetails(string schedulerName, string jobGroup, string jobName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            var jobDetail = await scheduler.GetJobDetail(new JobKey(jobName, jobGroup)).ConfigureAwait(false);
            return new JobDetailDto(jobDetail);
        }

        /// <summary>
        /// 当前正在执行的任务列表
        /// </summary>
        /// <param name="schedulerName">调度器名称</param>
        /// <returns></returns>
        [HttpGet]
        [Route("currently-executing")]
        public async Task<IReadOnlyList<CurrentlyExecutingJobDto>> CurrentlyExecutingJobs(string schedulerName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            var currentlyExecutingJobs = await scheduler.GetCurrentlyExecutingJobs().ConfigureAwait(false);
            return currentlyExecutingJobs.Select(x => x.ToDto()).ToList();
        }


        /// <summary>
        /// 暂停任务
        /// </summary>
        /// <param name="schedulerName">调度器名称</param>
        /// <param name="jobGroup">任务分组</param>
        /// <param name="jobName">任务名称</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{jobGroup}/{jobName}/pause")]
        public async Task PauseJobs(string schedulerName, string jobGroup, string jobName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            await scheduler.PauseJob(new JobKey(jobName, jobGroup)).ConfigureAwait(false);
        }

        /// <summary>
        /// 暂停任务
        /// </summary>
        /// <param name="schedulerName">调度器名称</param>
        /// <param name="groupMatcher">任务查询条件</param>
        /// <returns></returns>
        [HttpPost]
        [Route("pause")]
        public async Task PauseJobs(string schedulerName, GroupMatcherDto groupMatcher)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            var matcher = (groupMatcher ?? new GroupMatcherDto()).GetJobGroupMatcher();
            await scheduler.PauseJobs(matcher).ConfigureAwait(false);
        }

        /// <summary>
        /// 恢复任务
        /// </summary>
        /// <param name="schedulerName">调度器名称</param>
        /// <param name="jobGroup">任务分组</param>
        /// <param name="jobName">任务名称</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{jobGroup}/{jobName}/resume")]
        public async Task ResumeJob(string schedulerName, string jobGroup, string jobName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            await scheduler.ResumeJob(new JobKey(jobName, jobGroup)).ConfigureAwait(false);
        }

        /// <summary>
        /// 恢复任务
        /// </summary>
        /// <param name="schedulerName">高度器名称</param>
        /// <param name="groupMatcher">任务查询条件</param>
        /// <returns></returns>
        [HttpPost]
        [Route("resume")]
        public async Task ResumeJobs(string schedulerName, GroupMatcherDto groupMatcher)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            var matcher = (groupMatcher ?? new GroupMatcherDto()).GetJobGroupMatcher();
            await scheduler.ResumeJobs(matcher).ConfigureAwait(false);
        }

        /// <summary>
        /// 触发任务
        /// </summary>
        /// <param name="schedulerName">调度器名称</param>
        /// <param name="jobGroup">任务分组</param>
        /// <param name="jobName">任务名称</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{jobGroup}/{jobName}/trigger")]
        public async Task TriggerJob(string schedulerName, string jobGroup, string jobName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            await scheduler.TriggerJob(new JobKey(jobName, jobGroup)).ConfigureAwait(false);
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="schedulerName">调度器名称</param>
        /// <param name="jobGroup">任务分组</param>
        /// <param name="jobName">任务名称</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{jobGroup}/{jobName}")]
        public async Task DeleteJob(string schedulerName, string jobGroup, string jobName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            await scheduler.DeleteJob(new JobKey(jobName, jobGroup)).ConfigureAwait(false);
        }

        /// <summary>
        /// 取消任务执行
        /// </summary>
        /// <param name="schedulerName"></param>
        /// <param name="jobGroup"></param>
        /// <param name="jobName"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{jobGroup}/{jobName}/interrupt")]
        public async Task InterruptJob(string schedulerName, string jobGroup, string jobName)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            await scheduler.Interrupt(new JobKey(jobName, jobGroup)).ConfigureAwait(false);
        }


        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="schedulerName">调度器名称</param>
        /// <param name="jobGroup">任务分组</param>
        /// <param name="jobName">任务名称</param>
        /// <param name="jobType">任务类型</param>
        /// <param name="durable"></param>
        /// <param name="requestsRecovery"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{jobGroup}/{jobName}")]
        public async Task AddJob(string schedulerName, string jobGroup, string jobName, string jobType, bool durable, bool requestsRecovery, bool replace = false)
        {
            var scheduler = await GetScheduler(schedulerName).ConfigureAwait(false);
            var jobDetail = new JobDetailImpl(jobName, jobGroup, Type.GetType(jobType), durable, requestsRecovery);
            await scheduler.AddJob(jobDetail, replace).ConfigureAwait(false);
        }

    }
}