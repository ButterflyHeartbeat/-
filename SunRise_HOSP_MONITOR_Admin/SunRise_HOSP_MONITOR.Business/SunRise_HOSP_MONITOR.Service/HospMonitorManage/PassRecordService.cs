﻿using System;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunRise_HOSP_MONITOR.Util;
using SunRise_HOSP_MONITOR.Util.Extension;
using SunRise_HOSP_MONITOR.Util.Model;
using SunRise_HOSP_MONITOR.Data;
using SunRise_HOSP_MONITOR.Data.Repository;
using SunRise_HOSP_MONITOR.Entity.HospMonitorManage;
using SunRise_HOSP_MONITOR.Model.Param.HospMonitorManage;

namespace SunRise_HOSP_MONITOR.Service.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-12 16:44
    /// 描 述：人员出入记录服务类
    /// </summary>
    public class PassRecordService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<PassRecordEntity>> GetList(PassRecordListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<PassRecordEntity>> GetPageList(PassRecordListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<PassRecordEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<PassRecordEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(PassRecordEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                
                await this.BaseRepository().Update(entity);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<PassRecordEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<PassRecordEntity, bool>> ListFilter(PassRecordListParam param)
        {
            var expression = LinqExtensions.True<PassRecordEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
