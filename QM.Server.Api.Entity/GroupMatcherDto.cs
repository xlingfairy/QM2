using Quartz;
using Quartz.Impl.Matchers;
using Quartz.Util;
using System.Runtime.Serialization;

namespace QM.Server.Api.Entity
{

    /// <summary>
    /// 
    /// </summary>
    
    public class GroupMatcherDto
    {

        /// <summary>
        /// 
        /// </summary>
        
        public string NameContains { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string NameEndsWith { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string NameStartsWith { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string NameEquals { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GroupMatcher<TriggerKey> GetTriggerGroupMatcher()
        {
            return GetGroupMatcher<TriggerKey>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GroupMatcher<JobKey> GetJobGroupMatcher()
        {
            return GetGroupMatcher<JobKey>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private GroupMatcher<T> GetGroupMatcher<T>() where T : Key<T>
        {
            if (!string.IsNullOrWhiteSpace(NameContains))
            {
                return GroupMatcher<T>.GroupContains(NameContains);
            }
            if (!string.IsNullOrWhiteSpace(NameStartsWith))
            {
                return GroupMatcher<T>.GroupStartsWith(NameStartsWith);
            }
            if (!string.IsNullOrWhiteSpace(NameEndsWith))
            {
                return GroupMatcher<T>.GroupEndsWith(NameEndsWith);
            }
            if (!string.IsNullOrWhiteSpace(NameEquals))
            {
                return GroupMatcher<T>.GroupEquals(NameEquals);
            }
            return GroupMatcher<T>.AnyGroup();
        }
    }
}