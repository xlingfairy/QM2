using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;

namespace QM.Server
{

    /// <summary>
    /// 
    /// </summary>
    public class RemoteObject : MarshalByRefObject, IDisposable, ISponsor
    {


        /// <summary>
        /// 
        /// </summary>
        public Assembly CurrAssembly
        {
            get;
            private set;
        }

        private object Instance
        {
            get;
            set;
        }

        private Type Type
        {
            get;
            set;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyFile"></param>
        /// <param name="typeName"></param>
        public void Init(string assemblyFile, string typeName)
        {
            this.CurrAssembly = Assembly.LoadFrom(assemblyFile);
            this.Type = this.CurrAssembly.GetType(typeName);
            if (this.Type != null)
                this.Instance = Activator.CreateInstance(this.Type);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methodName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T ExecuteMethod<T>(string methodName, params object[] parameters)
        {
            return (T)this.Type.GetMethod(methodName).Invoke(this.Instance, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="parameters"></param>
        public void ExecuteMethod(string methodName, params object[] parameters)
        {
            this.Type.GetMethod(methodName).Invoke(this.Instance, parameters);
        }


        //public override object InitializeLifetimeService() {
        //    ILease lease = (ILease)base.InitializeLifetimeService();
        //    if (lease.CurrentState == LeaseState.Initial) {
        //        lease.InitialLeaseTime = TimeSpan.FromMinutes(1);
        //        lease.SponsorshipTimeout = TimeSpan.FromMinutes(2);
        //        lease.RenewOnCallTime = TimeSpan.FromSeconds(2);
        //    }
        //    return lease;
        //}

        /// <summary>
        /// 远程对象续约
        /// </summary>
        public TimeSpan Renewal(ILease lease)
        {
#if DEBUG
            Console.WriteLine("续约");
#endif
            return TimeSpan.FromMinutes(5);
        }


        #region dispose

        ~RemoteObject()
        {
            Dispose(false);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.Instance != null)
            {
                var method = this.Type.GetMethod("Dispose");
                if (method != null)
                    method.Invoke(this.Instance, null);
            }
        }

        #endregion

    }
}
