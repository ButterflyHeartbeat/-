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
    /// 日 期：2020-06-12 12:41
    /// 描 述：在线人员控制器类
    /// </summary>
    [Area("HospMonitorManage")]
    public class InlinePeopleController :  BaseController
    {
        private InlinePeopleBLL inlinePeopleBLL = new InlinePeopleBLL();
        private BaseInfoBLL baseInfoBLL = new BaseInfoBLL();

        #region 视图功能
        [AuthorizeFilter("hospmonitor:inlinepeople:view")]
        public ActionResult InlinePeopleIndex()
        {
            return View();
        }

        public ActionResult InlinePeopleForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("hospmonitor:inlinepeople:search")]
        public async Task<ActionResult> GetListJson(InlinePeopleListParam param)
        {
            TData<List<InlinePeopleEntity>> obj = await inlinePeopleBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("hospmonitor:inlinepeople:search")]
        public async Task<ActionResult> GetPageListJson(InlinePeopleListParam param, Pagination pagination)
        { 
           TData<List<InlinePeopleEntity>> obj = await inlinePeopleBLL.GetPageList(param, pagination);
            return Json(obj);
        }


        [HttpGet]
        [AuthorizeFilter("hospmonitor:inlinepeople:search")]
        public async Task<ActionResult> GetInLineDetailJson(InlinePeopleListParam param, Pagination pagination)
        {
            TData<List<HospMonitorInLinePeopleViewModel>> obj = await inlinePeopleBLL.GetInLineDetailsList(param, pagination);
            return Json(obj);
        }






        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<InlinePeopleEntity> obj = await inlinePeopleBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("hospmonitor:inlinepeople:add,hospmonitor:inlinepeople:edit")]
        public async Task<ActionResult> SaveFormJson(InlinePeopleEntity entity)
        {
            TData<string> obj = await inlinePeopleBLL.SaveForm(entity);
            return Json(obj);
        }

        /// <summary>
        /// 登记
        /// </summary>
        /// <param name="baseInfoViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthorizeFilter("hospmonitor:inlinepeople:add,hospmonitor:inlinepeople:edit")]
        public async Task<ActionResult> RegisterBaseInfo(BaseInfoViewModel baseInfoViewModel)
        {
            TData<string> obj = await baseInfoBLL.RegisterBase(baseInfoViewModel);
            return Json(obj);
        }


        [HttpPost]
        [AuthorizeFilter("hospmonitor:inlinepeople:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await inlinePeopleBLL.DeleteForm(ids);
            return Json(obj);
        }
        
        #endregion
    }
}
