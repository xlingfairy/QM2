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
        
        public string DllPath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string Desc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string JobType { get; set; }


        /// <summary>
        /// 
        /// </summary>
        
        public List<JobParameterInfo> Parameters { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public JobInDll(Type type)
        {
            var attr = type.GetCustomAttribute<ParameterTypeAttribute>(false);

            this.DllPath = type.Assembly.Location;
            this.JobType = type.FullName;

            if (attr != null)
            {
                this.Desc = attr.Desc;

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
