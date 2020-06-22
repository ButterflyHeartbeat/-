using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using SunRise.HOSP.MONITOR.Util;

namespace SunRise.HOSP.MONITOR.Entity.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-15 10:51
    /// 描 述：配置表实体类
    /// </summary>
    [Table("config")]
    public class ConfigEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ConfigCnName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ConfigName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ConfigValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? CreatTime { get; set; }
    }
}
