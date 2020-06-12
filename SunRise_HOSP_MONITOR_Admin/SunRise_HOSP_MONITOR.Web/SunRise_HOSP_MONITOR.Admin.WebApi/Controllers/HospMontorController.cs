using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SunRise_HOSP_MONITOR.Admin.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [AuthorizeFilter]
    public class HospMontorController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
