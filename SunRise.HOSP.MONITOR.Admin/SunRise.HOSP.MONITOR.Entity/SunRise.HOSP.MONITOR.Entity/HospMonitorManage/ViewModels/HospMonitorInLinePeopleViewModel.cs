using SunRise.HOSP.MONITOR.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SunRise.HOSP.MONITOR.Entity.HospMonitorManage
{
   public class HospMonitorInLinePeopleViewModel
    {
       
        public string Id { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        /// <returns></returns>
        public string sId { get; set; }
        /// <summary>
        /// 1:病人 2:陪护 3:访客
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
        /// <summary>
        /// 姓名
        /// </summary>
        public string sName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        public string sPhone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        /// <returns></returns>
        public string sAddress { get; set; }
        /// <summary>
        /// 病床号
        /// </summary>
        /// <returns></returns>
        public string sBedNo { get; set; }
        /// <summary>
        /// 病区
        /// </summary>
        /// <returns></returns>
        public string sArea { get; set; }
        /// <summary>
        /// 主治医生
        /// </summary>
        /// <returns></returns>
        public string sDoc { get; set; }
        /// <summary>
        /// 性别  0女  1男
        /// </summary>
        /// <returns></returns>
        public int? sSex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        /// <returns></returns>
        public string sAge { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string sRemarks { get; set; }
        /// <summary>
        /// 扩展字段
        /// </summary>
        /// <returns></returns>
        public string sExtend { get; set; }
    }
}
