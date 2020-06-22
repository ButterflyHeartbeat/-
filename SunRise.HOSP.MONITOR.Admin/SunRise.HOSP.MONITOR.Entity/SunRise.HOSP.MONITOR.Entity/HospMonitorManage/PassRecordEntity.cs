using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using SunRise.HOSP.MONITOR.Util;

namespace SunRise.HOSP.MONITOR.Entity.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-12 16:44
    /// 描 述：人员出入记录实体类
    /// </summary>
    [Table("pass_log")]
    public class PassRecordEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string sId { get; set; }
        /// <summary>
        /// 0:病人 1:陪护 2:访客
        /// </summary>
        /// <returns></returns>
        public int? nType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? dtPass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string sPatientId { get; set; }
    }
}
