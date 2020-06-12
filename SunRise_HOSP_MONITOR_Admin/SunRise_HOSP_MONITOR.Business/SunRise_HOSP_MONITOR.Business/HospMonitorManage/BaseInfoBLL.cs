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
    /// 日 期：2020-06-12 12:43
    /// 描 述：人员基础信息业务类
    /// </summary>
    public class BaseInfoBLL
    {
        private BaseInfoService baseInfoService = new BaseInfoService();

        #region 获取数据
        public async Task<TData<List<BaseInfoEntity>>> GetList(BaseInfoListParam param)
        {
            TData<List<BaseInfoEntity>> obj = new TData<List<BaseInfoEntity>>();
            obj.Data = await baseInfoService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<BaseInfoEntity>>> GetPageList(BaseInfoListParam param, Pagination pagination)
        {
            TData<List<BaseInfoEntity>> obj = new TData<List<BaseInfoEntity>>();
            obj.Data = await baseInfoService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<BaseInfoEntity>> GetEntity(long id)
        {
            TData<BaseInfoEntity> obj = new TData<BaseInfoEntity>();
            obj.Data = await baseInfoService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(BaseInfoEntity entity)
        {
            TData<string> obj = new TData<string>();
            await baseInfoService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await baseInfoService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
