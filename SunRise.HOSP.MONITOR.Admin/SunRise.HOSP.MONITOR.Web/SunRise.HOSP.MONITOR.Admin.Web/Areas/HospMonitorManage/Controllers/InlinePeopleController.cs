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
            if (baseInfoViewModel.nType==-1)
            {
                return Json(new TData
                {
                    Tag=0,
                    Message="请选择人员类型",
                });
            }
            TData<string> obj = await baseInfoBLL.RegisterBase(baseInfoViewModel);
            return Json(obj);
        }


        [HttpPost]
        [AuthorizeFilter("hospmonitor:inlinepeople:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            // TData obj = await inlinePeopleBLL.DeleteForm(ids);
            TData obj = await inlinePeopleBLL.CancelOper(ids);
            return Json(obj);
        }
        
        #endregion
    }
}
