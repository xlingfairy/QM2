using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.Server
{
    /// <summary>
    /// http://stackoverflow.com/questions/8392596/how-can-i-run-quartz-net-jobs-in-a-separate-appdomain
    /// </summary>
    public class IsolatedJob : IJob, IDisposable
    {
        private readonly Type JobType;

        private IsolateDomainLoader IDL = null;
        private RemoteObject Obj = null;

        public IsolatedJob(Type jobType)
        {
            this.JobType = jobType ?? throw new ArgumentNullException("jobType");

            var path = Path.GetDirectoryName(this.JobType.Assembly.Location);
            this.IDL = new IsolateDomainLoader(path, $"{this.JobType.Assembly.GetName().Name}.dll.config");
            this.Obj = this.IDL.GetObject(this.JobType.Assembly.Location, this.JobType.FullName);
        }


        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                this.Obj.ExecuteMethod("Execute", context);
            });
        }




        #region dispose
        ~IsolatedJob()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.Obj != null)
                this.Obj.Dispose();


            if (disposing)
            {
                if (this.IDL != null)
                    this.IDL.Dispose();
            }
        }
        #endregion
    }
}
