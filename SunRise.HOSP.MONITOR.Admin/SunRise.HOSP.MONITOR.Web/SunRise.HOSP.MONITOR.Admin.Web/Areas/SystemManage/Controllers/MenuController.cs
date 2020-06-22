﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SunRise.HOSP.MONITOR.Admin.Web.Controllers;
using SunRise.HOSP.MONITOR.Business.SystemManage;
using SunRise.HOSP.MONITOR.Entity.SystemManage;
using SunRise.HOSP.MONITOR.Model.Param.SystemManage;
using SunRise.HOSP.MONITOR.Model.Result;
using SunRise.HOSP.MONITOR.Util.Model;

namespace SunRise.HOSP.MONITOR.Admin.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class MenuController : BaseController
    {
        private MenuBLL menuBLL = new MenuBLL();

        #region 视图功能
        [AuthorizeFilter("system:menu:view")]
        public IActionResult MenuIndex()
        {
            return View();
        }

        public IActionResult MenuForm()
        {
            return View();
        }

        public IActionResult MenuChoose()
        {
            return View();
        }
        public IActionResult MenuIcon()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("system:menu:search,system:role:search")]
        public async Task<IActionResult> GetListJson(MenuListParam param)
        {
            TData<List<MenuEntity>> obj = await menuBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("system:menu:search,system:role:search")]
        public async Task<IActionResult> GetMenuTreeListJson(MenuListParam param)
        {
            TData<List<ZtreeInfo>> obj = await menuBLL.GetZtreeList(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetFormJson(long id)
        {
            TData<MenuEntity> obj = await menuBLL.GetEntity(id);
            return Json(obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetMaxSortJson(long parentId = 0)
        {
            TData<int> obj = await menuBLL.GetMaxSort(parentId);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("system:menu:add,system:menu:edit")]
        public async Task<IActionResult> SaveFormJson(MenuEntity entity)
        {
            TData<string> obj = await menuBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("system:menu:delete")]
        public async Task<IActionResult> DeleteFormJson(string ids)
        {
            TData obj = await menuBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}