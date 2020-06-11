using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SunRise_HOSP_MONITOR.Business.SystemManage;
using SunRise_HOSP_MONITOR.Model.Param.SystemManage;
using SunRise_HOSP_MONITOR.Model.Result.SystemManage;
using SunRise_HOSP_MONITOR.Util.Model;

namespace SunRise_HOSP_MONITOR.Admin.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [AuthorizeFilter]
    public class HOSPMONITORController : ControllerBase
    {
        [HttpGet]
        public object GetList([FromQuery] string id)
        {
            return new { 
            id=id
            };
        }
    }
}
