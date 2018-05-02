using Microsoft.Owin.Hosting;
using QM.Server.Api;
using Quartz;
using Quartz.Impl;
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
                //var f = DirectSchedulerFactory.Instance;
                this.Factory = new StdSchedulerFactory();
                this.Scheduler = await this.Factory.GetScheduler();
                this.Scheduler.JobFactory = new IsolatedJobFactory();
                this.CanStart = true;
            }
            catch (Exception)
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
