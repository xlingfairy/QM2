using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.Server.Common.Attributes
{

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ParameterAttribute : Attribute
    {

        /// <summary>
        /// 
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DefaultValue { get; set; }
    }
}
