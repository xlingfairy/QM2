using QM.Server.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace QM.Server.Api.Controller
{

    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/discover")]
    public class DiscoverController : ApiController
    {
        private static readonly string PATH = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Jobs");

        [HttpGet]
        public IEnumerable<JobInDll> Get()
        {
            var dirs = System.IO.Directory.GetDirectories(PATH);
            return dirs.SelectMany(dir => this.Get(dir));
        }


        private List<JobInDll> Get(string dir)
        {
            var dlls = System.IO.Directory.GetFiles(dir, "*.dll");
            var domain = AppDomain.CreateDomain("tmp");

            try
            {
                var rst = new List<JobInDll>();

                foreach (var dll in dlls)
                {
                    var proxy = (RemoteObjectProxy)domain.CreateInstanceFromAndUnwrap(Assembly.GetExecutingAssembly().Location, typeof(RemoteObjectProxy).FullName);
                    var jds = proxy.GetJobTypes(dll);
                    rst.AddRange(jds);
                }

                return rst;
            }
            finally
            {
                AppDomain.Unload(domain);
            }
        }
    }
}
