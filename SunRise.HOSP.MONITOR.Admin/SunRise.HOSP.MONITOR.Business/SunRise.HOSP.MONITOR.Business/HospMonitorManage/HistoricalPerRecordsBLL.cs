using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunRise.HOSP.MONITOR.Util;
using SunRise.HOSP.MONITOR.Util.Extension;
using SunRise.HOSP.MONITOR.Util.Model;
using SunRise.HOSP.MONITOR.Entity.HospMonitorManage;
using SunRise.HOSP.MONITOR.Model.Param.HospMonitorManage;
using SunRise.HOSP.MONITOR.Service.HospMonitorManage;

namespace SunRise.HOSP.MONITOR.Business.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-12 16:51
    /// 描 述：历史人员记录业务类
    /// </summary>
    public class HistoricalPerRecordsBLL
    {
        private HistoricalPerRecordsService historicalPerRecordsService = new HistoricalPerRecordsService();

        #region 获取数据
        public async Task<TData<List<HistoricalPerRecordsEntity>>> GetList(HistoricalPerRecordsListParam param)
        {
            TData<List<HistoricalPerRecordsEntity>> obj = new TData<List<HistoricalPerRecordsEntity>>();
            obj.Data = await historicalPerRecordsService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<HistoricalPerRecordsEntity>>> GetPageList(HistoricalPerRecordsListParam param, Pagination pagination)
        {
            TData<List<HistoricalPerRecordsEntity>> obj = new TData<List<HistoricalPerRecordsEntity>>();
            obj.Data = await historicalPerRecordsService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<HistoricalPerRecordsEntity>> GetEntity(long id)
        {
            TData<HistoricalPerRecordsEntity> obj = new TData<HistoricalPerRecordsEntity>();
            obj.Data = await historicalPerRecordsService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(HistoricalPerRecordsEntity entity)
        {
            TData<string> obj = new TData<string>();
            await historicalPerRecordsService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<string>> SavebatchForm(List<HistoricalPerRecordsEntity> entity)
        {
            TData<string> obj = new TData<string>();
            await historicalPerRecordsService.SaveBatchForm(entity);
            obj.Data ="批量插入";
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await historicalPerRecordsService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
