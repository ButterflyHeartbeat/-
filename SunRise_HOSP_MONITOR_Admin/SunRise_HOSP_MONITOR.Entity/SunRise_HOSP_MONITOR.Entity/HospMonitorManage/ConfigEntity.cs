using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using SunRise_HOSP_MONITOR.Util;

namespace SunRise_HOSP_MONITOR.Entity.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-13 18:27
    /// 描 述：配置表实体类
    /// </summary>
    [Table("config")]
    public class ConfigEntity : BaseEntity
    {
        /// <summary>
        /// 最大陪同人员
        /// </summary>
        /// <returns></returns>
        public int nMaxAccompanyCount { get; set; }
        /// <summary>
        /// 最大访客
        /// </summary>
        /// <returns></returns>
        public int nMaxVisitorCount { get; set; }
    }
}
