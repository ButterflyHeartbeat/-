using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using SunRise_HOSP_MONITOR.Util;
using SunRise_HOSP_MONITOR.Util.Model;
using SunRise_HOSP_MONITOR.Entity;
using SunRise_HOSP_MONITOR.Model;
using SunRise_HOSP_MONITOR.Admin.Web.Controllers;
using SunRise_HOSP_MONITOR.Entity.HospMonitorManage;
using SunRise_HOSP_MONITOR.Business.HospMonitorManage;
using SunRise_HOSP_MONITOR.Model.Param.HospMonitorManage;

namespace SunRise_HOSP_MONITOR.Admin.Web.Areas.HospMonitorManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-11 23:24
    /// 描 述：控制器类
    /// </summary>
    [Area("HospMonitorManage")]
    public class Test1Controller :  BaseController
    {
        private Test1BLL test1BLL = new Test1BLL();

        #region 视图功能
        [AuthorizeFilter("hospmonitor:test1:view")]
        public ActionResult Test1Index()
        {
            return View();
        }

        public ActionResult Test1Form()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("hospmonitor:test1:search")]
        public async Task<ActionResult> GetListJson(Test1ListParam param)
        {
            TData<List<Test1Entity>> obj = await test1BLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("hospmonitor:test1:search")]
        public async Task<ActionResult> GetPageListJson(Test1ListParam param, Pagination pagination)
        {
            TData<List<Test1Entity>> obj = await test1BLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<Test1Entity> obj = await test1BLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("hospmonitor:test1:add,hospmonitor:test1:edit")]
        public async Task<ActionResult> SaveFormJson(Test1Entity entity)
        {
            TData<string> obj = await test1BLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("hospmonitor:test1:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await test1BLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
