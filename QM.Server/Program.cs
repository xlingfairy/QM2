using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace QM.Server
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        private static ILog Log = LogManager.GetLogger("Server");

        static void Main(string[] args)
        {

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            HostFactory.Run(x =>
            {
                x.SetDescription("Quartz.net Scheduler Server");
                x.SetDisplayName("QM Server");
                x.SetInstanceName("QM.Server");
                x.SetServiceName("QM.Service");

                x.Service(s =>
                {
                    var server = new QMServer();
                    return server;
                });
            });
        }


        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Log.Error(e.Exception);
            e.SetObserved();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = ((Exception)e.ExceptionObject).GetBaseException();
            Log.Error(ex);
        }
    }
}
