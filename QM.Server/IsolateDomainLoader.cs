using System;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;

namespace QM.Server
{

    /// <summary>
    /// 
    /// </summary>
    public class IsolateDomainLoader : IDisposable
    {
        private AppDomain Domain;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="configFileName"></param>
        public IsolateDomainLoader(string path, string configFileName = "")
        {
            AppDomainSetup setup = new AppDomainSetup
            {
                ApplicationName = "IsolateDomainLoader",
                ApplicationBase = path,
                DynamicBase = path,
                PrivateBinPath = path
            };

            //setup.CachePath = setup.ApplicationBase;
            //setup.ShadowCopyFiles = "true";
            //setup.ShadowCopyDirectories = setup.ApplicationBase;
            if (!string.IsNullOrWhiteSpace(configFileName))
            {
                setup.ConfigurationFile = Path.Combine(path, configFileName);
            }
            this.Domain = AppDomain.CreateDomain("ApplicationLoaderDomain", null, setup);
        }


        public RemoteObject GetObject(string assemblyFile, string typeFullName)
        {
            var name = Assembly.GetExecutingAssembly().FullName;
            //如果用 CreateInstanceAndUnwrap 只能把 ApplicationBas 设为主程充的 BaseDirectory, 这样子域就不能有自己的 ApplicationBase 了.
            //var obj = (RemoteObject)this.Domain.CreateInstanceAndUnwrap(name, typeof(RemoteObject).FullName);
            var obj = (RemoteObject)this.Domain.CreateInstanceFromAndUnwrap(Assembly.GetExecutingAssembly().Location, typeof(RemoteObject).FullName);
            obj.Init(assemblyFile, typeFullName);

            var lease = (ILease)obj.GetLifetimeService();
            lease.Register(obj);

            return obj;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Unload()
        {
            if (Domain == null)
                return;

            try
            {
                AppDomain.Unload(this.Domain);
                this.Domain = null;
            }
            catch
            {
            }
        }

        #region dispose
        ~IsolateDomainLoader()
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
            if (disposing)
            {
                this.Unload();
#if DEBUG
                Console.WriteLine("Domain Unloaded");
#endif
            }
        }
        #endregion
    }
}
