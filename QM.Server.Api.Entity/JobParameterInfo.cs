using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QM.Server.Api.Entity
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract, Serializable]
    public class JobParameterInfo
    {
        /// <summary>
        /// 
        /// </summary>
        
        public string Name { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string Value { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string Desc { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string Type { get; internal set; }
    }
}
