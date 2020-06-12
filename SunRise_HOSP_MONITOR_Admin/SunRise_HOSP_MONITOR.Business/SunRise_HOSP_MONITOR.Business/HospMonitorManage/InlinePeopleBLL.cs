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
    /// 日 期：2020-06-12 12:41
    /// 描 述：在线人员业务类
    /// </summary>
    public class InlinePeopleBLL
    {
        private InlinePeopleService inlinePeopleService = new InlinePeopleService();

        #region 获取数据
        public async Task<TData<List<InlinePeopleEntity>>> GetList(InlinePeopleListParam param)
        {
            TData<List<InlinePeopleEntity>> obj = new TData<List<InlinePeopleEntity>>();
            obj.Data = await inlinePeopleService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<InlinePeopleEntity>>> GetPageList(InlinePeopleListParam param, Pagination pagination)
        {
            TData<List<InlinePeopleEntity>> obj = new TData<List<InlinePeopleEntity>>();
            obj.Data = await inlinePeopleService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<InlinePeopleEntity>> GetEntity(long id)
        {
            TData<InlinePeopleEntity> obj = new TData<InlinePeopleEntity>();
            obj.Data = await inlinePeopleService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }

        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(InlinePeopleEntity entity)
        {
            TData<string> obj = new TData<string>();
            await inlinePeopleService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await inlinePeopleService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
