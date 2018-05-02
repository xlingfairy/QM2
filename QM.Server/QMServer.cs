using Microsoft.Owin.Hosting;
using QM.Server.Api;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.AdoJobStore;
using Quartz.Impl.AdoJobStore.Common;
using Quartz.Util;
using System;
using Topshelf;

namespace QM.Server
{

    /// <summary>
    /// 
    /// </summary>
    public class QMServer : ServiceControl
    {

        private ISchedulerFactory Factory = null;
        private IScheduler Scheduler = null;
        private IDisposable _WebApp = null;

        private bool CanStart = false;


        /// <summary>
        /// 
        /// </summary>
        public QMServer()
        {
            this.Init();
        }

        private async void Init()
        {
            try
            {
                //var tp = new Quartz.Simpl.DefaultThreadPool()
                //{
                //    MaxConcurency = 10,
                //    ThreadCount = 10
                //};

                //DBConnectionManager.Instance.AddConnectionProvider("ds", new DbProvider("SqlServer", "connectionString"));
                //var js = new JobStoreTX()
                //{
                //    DataSource = "ds",
                //};

                //DirectSchedulerFactory.Instance.CreateScheduler("QM", "QM1", tp, js);

                this.Factory = new StdSchedulerFactory();
                this.Scheduler = await this.Factory.GetScheduler();

                this.Scheduler.JobFactory = new IsolatedJobFactory();
                this.CanStart = true;
            }
            catch (Exception e)
            {
                this.CanStart = false;
            }
        }

        public bool Start(HostControl hostControl)
        {
            if (this.Scheduler != null)
            {
                this.Scheduler.Start();
            }

            this._WebApp = WebApp.Start<Startup>("http://localhost:5556");

            return this.CanStart;
        }

        public bool Stop(HostControl hostControl)
        {
            if (this.Scheduler != null)
            {
                this.Scheduler.Shutdown();
            }

            if (this._WebApp != null)
                this._WebApp.Dispose();

            return true;
        }
    }
}
