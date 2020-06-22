﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunRise.HOSP.MONITOR.Util;
using SunRise.HOSP.MONITOR.Util.Extension;
using SunRise.HOSP.MONITOR.Util.Model;
using SunRise.HOSP.MONITOR.Entity.SystemManage;
using SunRise.HOSP.MONITOR.Model.Param.SystemManage;
using SunRise.HOSP.MONITOR.Service.SystemManage;

namespace SunRise.HOSP.MONITOR.Business.SystemManage
{
    public class AutoJobLogBLL
    {
        private AutoJobLogService autoJobLogService = new AutoJobLogService();

        #region 获取数据
        public async Task<TData<List<AutoJobLogEntity>>> GetList(AutoJobLogListParam param)
        {
            TData<List<AutoJobLogEntity>> obj = new TData<List<AutoJobLogEntity>>();
            obj.Data = await autoJobLogService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<AutoJobLogEntity>>> GetPageList(AutoJobLogListParam param, Pagination pagination)
        {
            TData<List<AutoJobLogEntity>> obj = new TData<List<AutoJobLogEntity>>();
            obj.Data = await autoJobLogService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<AutoJobLogEntity>> GetEntity(long id)
        {
            TData<AutoJobLogEntity> obj = new TData<AutoJobLogEntity>();
            obj.Data = await autoJobLogService.GetEntity(id);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(AutoJobLogEntity entity)
        {
            TData<string> obj = new TData<string>();
            await autoJobLogService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData<long> obj = new TData<long>();
            await autoJobLogService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
