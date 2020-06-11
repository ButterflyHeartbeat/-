using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using SunRise_HOSP_MONITOR.Util;

namespace SunRise_HOSP_MONITOR.Entity.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-11 23:24
    /// 描 述：实体类
    /// </summary>
    [Table("hosp_test1")]
    public class Test1Entity : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? dtCheckIn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? dtCheckOut { get; set; }
        /// <summary>
        /// 0:病人 1:陪护 2:访客
        /// </summary>
        /// <returns></returns>
        public byte? nType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string sPatientId { get; set; }
    }
}
