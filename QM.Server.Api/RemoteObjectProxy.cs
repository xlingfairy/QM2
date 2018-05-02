using QM.Server.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QM.Server.Api
{

    /// <summary>
    /// 
    /// </summary>
    public class RemoteObjectProxy : MarshalByRefObject
    {


        public List<JobInDll> GetJobTypes(string assemblyFile)
        {
            var asn = AssemblyName.GetAssemblyName(assemblyFile);
            var asm = Assembly.Load(asn);
            return asm.GetTypes()
                .Where(t=>t.GetInterface("IJob", false) != null)
                .Select(t => new JobInDll(t)).ToList();
        }

    }
}
