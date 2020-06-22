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
    /// 日 期：2020-06-12 16:51
    /// 描 述：历史人员记录控制器类
    /// </summary>
    [Area("HospMonitorManage")]
    public class HistoricalPerRecordsController :  BaseController
    {
        private HistoricalPerRecordsBLL historicalPerRecordsBLL = new HistoricalPerRecordsBLL();

        #region 视图功能
        [AuthorizeFilter("hospmonitor:historicalperrecords:view")]
        public ActionResult HistoricalPerRecordsIndex()
        {
            return View();
        }

        public ActionResult HistoricalPerRecordsForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("hospmonitor:historicalperrecords:search")]
        public async Task<ActionResult> GetListJson(HistoricalPerRecordsListParam param)
        {
            TData<List<HistoricalPerRecordsEntity>> obj = await historicalPerRecordsBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("hospmonitor:historicalperrecords:search")]
        public async Task<ActionResult> GetPageListJson(HistoricalPerRecordsListParam param, Pagination pagination)
        {
            TData<List<HistoricalPerRecordsEntity>> obj = await historicalPerRecordsBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<HistoricalPerRecordsEntity> obj = await historicalPerRecordsBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("hospmonitor:historicalperrecords:add,hospmonitor:historicalperrecords:edit")]
        public async Task<ActionResult> SaveFormJson(HistoricalPerRecordsEntity entity)
        {
            TData<string> obj = await historicalPerRecordsBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("hospmonitor:historicalperrecords:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await historicalPerRecordsBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
