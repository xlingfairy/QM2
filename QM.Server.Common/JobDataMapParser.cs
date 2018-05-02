﻿using QM.Server.Common.Attributes;
using Quartz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QM.Server.Common
{

    /// <summary>
    /// 
    /// </summary>
    public static class JobDataMapParser
    {

        /// <summary>
        /// GetXXXFromString 是从 string 做类型转换
        /// GetXXXValue 是先判断值是不是 string, 如果是则调用 GetXXXFromString, 否则则直接改变类型
        /// GetXXX 则是直接用 Convert 转换
        /// </summary>
        private static readonly Dictionary<Type, Func<JobDataMap, string, object>> SupportTypes = new Dictionary<Type, Func<JobDataMap, string, object>>() {
            {typeof(bool), (datamap, key)=>{
                return datamap.GetBooleanValue(key);
            }},
            {typeof(char), (datamap, key)=>{
                return datamap.GetCharFromString(key);
            }},
            {typeof(DateTime), (datamap, key)=>{
                return datamap.GetDateTimeValue(key);
            }},
            {typeof(DateTimeOffset), (datamap, key)=>{
                return datamap.GetDateTimeOffsetValue(key);
            }},
            {typeof(double), (datamap, key)=>{
                return datamap.GetDoubleValue(key);
            }},
            {typeof(Single), (datamap, key)=>{
                return datamap.GetFloatValue(key);
            }},
            {typeof(int), (datamap, key)=>{
                return datamap.GetIntValue(key);
            }},
            {typeof(long), (datamap, key)=>{
                return datamap.GetLongValue(key);
            }},
            {typeof(TimeSpan), (datamap, key)=>{
                return datamap.GetTimeSpanValue(key);
            }},
            {typeof(decimal), (datamap, key)=>{
                return datamap.GetDecimalValue(key);
            }},
            {typeof(string), (datamap, key)=>{
                return datamap.GetString(key);
            }}
        };


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datamap"></param>
        /// <returns></returns>
        public static T Parse<T>(this JobDataMap datamap) where T : class, new()
        {
            var instance = (T)Activator.CreateInstance(typeof(T));
            var ps = GetSupportProperties<T>();
            foreach (var p in ps)
            {
                var pt = p.Key.PropertyType;
                if (pt.IsGenericType && pt.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    pt = new NullableConverter(pt).UnderlyingType;
                }
                var func = SupportTypes[pt];
                object value = null;
                try
                {
                    value = func(datamap, p.Key.Name);
                }
                catch
                {

                }

                if (value != null)
                    p.Key.SetValue(instance, value);
            }

            return instance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datamap"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal GetDecimalValue(this JobDataMap datamap, string key)
        {
            object obj = datamap.Get(key);

            if (obj is string)
            {
                return Decimal.Parse((string)obj, CultureInfo.InvariantCulture);
            }
            else
                return (decimal)obj;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Dictionary<PropertyInfo, string> GetSupportProperties(Type type)
        {
            var instance = Activator.CreateInstance(type);
            var ps = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            return ps.Where(p =>
                    SupportTypes.ContainsKey(p.PropertyType) || (
                        p.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>))
                        && SupportTypes.ContainsKey(new NullableConverter(p.PropertyType).UnderlyingType)
                    ))
                    .ToDictionary(p => p, p => p.GetValue(instance)?.ToString());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<PropertyInfo, string> GetSupportProperties<T>() where T : class, new()
        {
            var type = typeof(T);
            return GetSupportProperties(type);
        }
    }
}
