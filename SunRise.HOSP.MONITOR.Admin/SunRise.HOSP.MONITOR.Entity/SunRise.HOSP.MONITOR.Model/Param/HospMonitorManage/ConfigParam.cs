using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SunRise.HOSP.MONITOR.Util;

namespace SunRise.HOSP.MONITOR.Model.Param.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-13 18:27
    /// 描 述：配置表实体查询类
    /// </summary>
    public class ConfigListParam
    {
        public string ConfigName { get; set; }
        public string ConfigCnName { get; set; }
    }
}
