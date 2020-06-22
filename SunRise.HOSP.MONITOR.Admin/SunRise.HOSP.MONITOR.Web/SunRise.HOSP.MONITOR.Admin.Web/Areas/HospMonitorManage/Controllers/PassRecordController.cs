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
    /// 日 期：2020-06-12 16:44
    /// 描 述：人员出入记录控制器类
    /// </summary>
    [Area("HospMonitorManage")]
    public class PassRecordController :  BaseController
    {
        private PassRecordBLL passRecordBLL = new PassRecordBLL();

        #region 视图功能
        [AuthorizeFilter("hospmonitor:passrecord:view")]
        public ActionResult PassRecordIndex()
        {
            return View();
        }

        public ActionResult PassRecordForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("hospmonitor:passrecord:search")]
        public async Task<ActionResult> GetListJson(PassRecordListParam param)
        {
            TData<List<PassRecordEntity>> obj = await passRecordBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("hospmonitor:passrecord:search")]
        public async Task<ActionResult> GetPageListJson(PassRecordListParam param, Pagination pagination)
        {
            TData<List<PassRecordEntity>> obj = await passRecordBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<PassRecordEntity> obj = await passRecordBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("hospmonitor:passrecord:add,hospmonitor:passrecord:edit")]
        public async Task<ActionResult> SaveFormJson(PassRecordEntity entity)
        {
            TData<string> obj = await passRecordBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("hospmonitor:passrecord:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await passRecordBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
