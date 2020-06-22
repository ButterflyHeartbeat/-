using System;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunRise.HOSP.MONITOR.Util;
using SunRise.HOSP.MONITOR.Util.Extension;
using SunRise.HOSP.MONITOR.Util.Model;
using SunRise.HOSP.MONITOR.Data;
using SunRise.HOSP.MONITOR.Data.Repository;
using SunRise.HOSP.MONITOR.Entity.HospMonitorManage;
using SunRise.HOSP.MONITOR.Model.Param.HospMonitorManage;

namespace SunRise.HOSP.MONITOR.Service.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-12 16:51
    /// 描 述：历史人员记录服务类
    /// </summary>
    public class HistoricalPerRecordsService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<HistoricalPerRecordsEntity>> GetList(HistoricalPerRecordsListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<HistoricalPerRecordsEntity>> GetPageList(HistoricalPerRecordsListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<HistoricalPerRecordsEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<HistoricalPerRecordsEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(HistoricalPerRecordsEntity entity)
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


        public async Task SaveBatchForm(List<HistoricalPerRecordsEntity> entity)
        {
            List<HistoricalPerRecordsEntity> data = new List<HistoricalPerRecordsEntity>();
            foreach (var item in entity)
            {
                if (item.Id.IsNullOrZero())
                {
                    item.Create();
                    data.Add(item);
                }
            }
            await this.BaseRepository().Insert(data);

        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<HistoricalPerRecordsEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<HistoricalPerRecordsEntity, bool>> ListFilter(HistoricalPerRecordsListParam param)
        {
            var expression = LinqExtensions.True<HistoricalPerRecordsEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
