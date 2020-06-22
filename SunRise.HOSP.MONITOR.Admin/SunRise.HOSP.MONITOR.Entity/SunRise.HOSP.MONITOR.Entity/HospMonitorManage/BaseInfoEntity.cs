using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using SunRise.HOSP.MONITOR.Util;

namespace SunRise.HOSP.MONITOR.Entity.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-12 12:43
    /// 描 述：人员基础信息实体类
    /// </summary>
    [Table("people_base_info")]
    public class BaseInfoEntity : BaseEntity
    {
        /// <summary>
        /// 身份证
        /// </summary>
        /// <returns></returns>
        public string sId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
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
