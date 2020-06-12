using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunRise_HOSP_MONITOR.Util;
using SunRise_HOSP_MONITOR.Util.Extension;
using SunRise_HOSP_MONITOR.Util.Model;
using SunRise_HOSP_MONITOR.Entity.HospMonitorManage;
using SunRise_HOSP_MONITOR.Model.Param.HospMonitorManage;
using SunRise_HOSP_MONITOR.Service.HospMonitorManage;

namespace SunRise_HOSP_MONITOR.Business.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-12 16:44
    /// 描 述：人员出入记录业务类
    /// </summary>
    public class PassRecordBLL
    {
        private PassRecordService passRecordService = new PassRecordService();

        #region 获取数据
        public async Task<TData<List<PassRecordEntity>>> GetList(PassRecordListParam param)
        {
            TData<List<PassRecordEntity>> obj = new TData<List<PassRecordEntity>>();
            obj.Data = await passRecordService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<PassRecordEntity>>> GetPageList(PassRecordListParam param, Pagination pagination)
        {
            TData<List<PassRecordEntity>> obj = new TData<List<PassRecordEntity>>();
            obj.Data = await passRecordService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<PassRecordEntity>> GetEntity(long id)
        {
            TData<PassRecordEntity> obj = new TData<PassRecordEntity>();
            obj.Data = await passRecordService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(PassRecordEntity entity)
        {
            TData<string> obj = new TData<string>();
            await passRecordService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await passRecordService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
