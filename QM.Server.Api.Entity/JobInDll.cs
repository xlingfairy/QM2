using Microsoft.CSharp;
using QM.Server.Common;
using QM.Server.Common.Attributes;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QM.Server.Api.Entity
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract, Serializable]
    public class JobInDll
    {

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string DllPath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string JobName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string JobType { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<JobParameterInfo> Parameters { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public JobInDll(Type type)
        {
            this.DllPath = type.Assembly.Location;
            this.JobName = type.GetCustomAttribute<DescriptionAttribute>()?.Description ?? type.Name;
            this.JobType = type.FullName;

            var attr = type.GetCustomAttribute<ParameterTypeAttribute>(false);
            if (attr != null)
            {
                var dic = JobDataMapParser.GetSupportProperties(attr.ParameterType);
                this.Parameters = dic?.Select(d =>
                {
                    var pa = d.Key.GetCustomAttribute<ParameterAttribute>();
                    return new JobParameterInfo()
                    {
                        Name = d.Key.Name,
                        Value = pa?.DefaultValue ?? d.Value?.ToString(),
                        Desc = pa?.Desc,
                        Type = GetTypeName(d.Key.PropertyType)
                    };
                }).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetTypeName(Type type)
        {
            using (var p = new CSharpCodeProvider())
            {
                var typeRef = new CodeTypeReference(type);
                return p.GetTypeOutput(typeRef);
            }

            //var nt = Nullable.GetUnderlyingType(type);
            //if (nt != null)
            //{
            //    return $"{nt.Name}?";
            //}
            //else
            //    return type.Name;
        }
    }
}
