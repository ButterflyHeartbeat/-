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

namespace SunRise.HOSP.MONITOR.Admin.Web.Areas.HospMonitorManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-12 12:43
    /// 描 述：人员基础信息控制器类
    /// </summary>
    [Area("HospMonitorManage")]
    public class BaseInfoController :  BaseController
    {
        private BaseInfoBLL baseInfoBLL = new BaseInfoBLL();

        #region 视图功能
        [AuthorizeFilter("hospmonitor:baseinfo:view")]
        public ActionResult BaseInfoIndex()
        {
            return View();
        }

        public ActionResult BaseInfoForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("hospmonitor:baseinfo:search")]
        public async Task<ActionResult> GetListJson(BaseInfoListParam param)
        {
            TData<List<BaseInfoEntity>> obj = await baseInfoBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("hospmonitor:baseinfo:search")]
        public async Task<ActionResult> GetPageListJson(BaseInfoListParam param, Pagination pagination)
        {
            TData<List<BaseInfoEntity>> obj = await baseInfoBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<BaseInfoEntity> obj = await baseInfoBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("hospmonitor:baseinfo:add,hospmonitor:baseinfo:edit")]
        public async Task<ActionResult> SaveFormJson(BaseInfoEntity entity)
        {
            TData<string> obj = await baseInfoBLL.SaveForm(entity);
            return Json(obj);
        }

       
        [HttpPost]
        [AuthorizeFilter("hospmonitor:baseinfo:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await baseInfoBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
