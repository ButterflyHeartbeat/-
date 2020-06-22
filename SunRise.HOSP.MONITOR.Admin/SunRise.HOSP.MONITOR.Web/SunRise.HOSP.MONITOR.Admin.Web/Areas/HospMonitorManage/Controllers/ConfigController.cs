using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using SunRise.HOSP.MONITOR.Util;
using SunRise.HOSP.MONITOR.Util.Model;
using SunRise.HOSP.MONITOR.Entity;
using SunRise.HOSP.MONITOR.Model;
using SunRise.HOSP.MONITOR.Admin.Web.Controllers;
using SunRise.HOSP.MONITOR.Entity.HospMonitorManage;
using SunRise.HOSP.MONITOR.Business.HospMonitorManage;
using SunRise.HOSP.MONITOR.Model.Param.HospMonitorManage;
using System.Reflection;

namespace SunRise.HOSP.MONITOR.Admin.Web.Areas.HospMonitorManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-15 10:51
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
            var CValue = 0;
            if(!int.TryParse(entity.ConfigValue,out CValue))
            {
                return Json(new TData
                {
                    Tag=0,
                    Message="您设置的值有误"
                });
            }
            entity.CreatTime = DateTime.Now;
            TData<string> obj = await configBLL.SaveForm(entity);

            if (entity.ConfigName.Equals("nMaxAccompanyCount"))
            {
                HospMonConfigure.nMaxAccompanyCount = int.Parse(entity.ConfigValue);

            }
            if (entity.ConfigValue.Equals("nMaxVisitorCount"))
            {
                HospMonConfigure.nMaxVisitorCount = int.Parse(entity.ConfigValue);
            }
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
