using System;
using System.Collections.Generic;
using SunRise.HOSP.MONITOR.Util.Model;

namespace SunRise.HOSP.MONITOR.Model.Param.SystemManage
{
    public class DataDictListParam : BaseApiToken
    {
        /// <summary>
        /// 字典类型
        /// </summary>
        public string DictType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
