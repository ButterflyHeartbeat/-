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
    /// 日 期：2020-06-13 18:27
    /// 描 述：配置表控制器类
    /// </summary>
    [Area("HospMonitorManage")]
    public class ConfigController :  BaseController
    {
        private ConfigBLL configBLL = new ConfigBLL();

        #region 视图功能
        [AuthorizeFilter("hospmonitor:config:view")]
        public ActionResult ConfigIndex()
        {
            return View();
        }

        public ActionResult ConfigForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("hospmonitor:config:search")]
        public async Task<ActionResult> GetListJson(ConfigListParam param)
        {
            TData<List<ConfigEntity>> obj = await configBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("hospmonitor:config:search")]
        public async Task<ActionResult> GetPageListJson(ConfigListParam param, Pagination pagination)
        {
            TData<List<ConfigEntity>> obj = await configBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<ConfigEntity> obj = await configBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("hospmonitor:config:add,hospmonitor:config:edit")]
        public async Task<ActionResult> SaveFormJson(ConfigEntity entity)
        {
            TData<string> obj = await configBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("hospmonitor:config:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await configBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
