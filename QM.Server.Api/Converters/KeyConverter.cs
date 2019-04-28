using QM.Server.Api.Entity;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.Server.Api.Converters
{
    public static class KeyConverter
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobKey"></param>
        public static KeyDto ToDto(this JobKey jobKey)
        {
            return new KeyDto()
            {
                Name = jobKey.Name,
                Group = jobKey.Group
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="triggerKey"></param>
        public static KeyDto ToDto(this TriggerKey triggerKey)
        {
            return new KeyDto()
            {
                Name = triggerKey.Name,
                Group = triggerKey.Group
            };
        }

    }
}
