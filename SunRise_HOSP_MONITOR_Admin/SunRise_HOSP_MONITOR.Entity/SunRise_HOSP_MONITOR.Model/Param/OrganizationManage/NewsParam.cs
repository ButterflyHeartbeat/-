using System;
using System.Collections.Generic;
using SunRise_HOSP_MONITOR.Model.Param.SystemManage;

namespace SunRise_HOSP_MONITOR.Model.Param.OrganizationManage
{
    public class NewsListParam : BaseAreaParam
    {
        public string NewsTitle { get; set; }
        public int? NewsType { get; set; }
        public string NewsTag { get; set; }
    }
}
