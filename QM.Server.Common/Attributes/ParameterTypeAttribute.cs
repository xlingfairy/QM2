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
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ParameterTypeAttribute : Attribute
    {

        /// <summary>
        /// 
        /// </summary>
        public Type ParameterType
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public ParameterTypeAttribute(Type type)
        {
            this.ParameterType = type ?? throw new ArgumentNullException("type");
        }

    }
}
