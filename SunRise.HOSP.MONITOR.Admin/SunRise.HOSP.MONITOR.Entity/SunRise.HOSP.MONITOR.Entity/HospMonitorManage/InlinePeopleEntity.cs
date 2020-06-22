using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using SunRise.HOSP.MONITOR.Util;

namespace SunRise.HOSP.MONITOR.Entity.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-12 12:41
    /// 描 述：在线人员实体类
    /// </summary>
    [Table("people")]
    public class InlinePeopleEntity : BaseEntity
    {
        /// <summary>
        /// 身份证
        /// </summary>
        /// <returns></returns>
        public string sId { get; set; }
        /// <summary>
        /// 0:病人 1:陪护 2:访客
        /// </summary>
        /// <returns></returns>
        public int? nType { get; set; }
        /// <summary>
        /// 登记时间
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? dtCheckIn { get; set; }
        /// <summary>
        /// 关联的病人，本身是病人(nType==0)时则为空
        /// </summary>
        /// <returns></returns>
        public string sPatientId { get; set; }
    }
}
