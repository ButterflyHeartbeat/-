using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SunRise_HOSP_MONITOR.Util;

namespace SunRise_HOSP_MONITOR.Model.Param.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-12 12:41
    /// 描 述：在线人员实体查询类
    /// </summary>
    public class InlinePeopleListParam
    {
        public string sName { get; set; }
        public string sId { get; set; }

        public int? nType { get; set; }
        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime? dtCheckIn { get; set; }

        public string sPatientId { get; set; }

    }
}
