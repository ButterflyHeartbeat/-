﻿using System;
using System.Collections.Generic;
using SunRise_HOSP_MONITOR.Util.Model;

namespace SunRise_HOSP_MONITOR.Model.Param.SystemManage
{
    public class AreaListParam
    {
        public string AreaName { get; set; }
    }

    public class BaseAreaParam : BaseApiToken
    {
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? CountyId { get; set; }
        /// <summary>
        /// 逗号分隔的Id
        /// </summary>
        public string AreaId { get; set; }
    }
}
