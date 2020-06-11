using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunRise_HOSP_MONITOR.Enum.SystemManage
{
    public enum AuthorizeTypeEnum
    {
        [Description("角色")]
        Role = 1,

        [Description("用户")]
        User = 2,
    }
}
