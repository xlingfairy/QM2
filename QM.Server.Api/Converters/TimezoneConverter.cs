using QM.Server.Api.Entity;
using System;

namespace QM.Server.Api.Converters
{
    public static class TimezoneConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static TimeZoneDto ToDto(this TimeZoneInfo timeZone)
        {
            return new TimeZoneDto()
            {
                Id = timeZone.Id,
                StandardName = timeZone.StandardName,
                DisplayName = timeZone.DisplayName
            };
        }


    }
}
