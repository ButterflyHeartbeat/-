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
    /// 日 期：2020-06-11 23:24
    /// 描 述：业务类
    /// </summary>
    public class Test1BLL
    {
        private Test1Service test1Service = new Test1Service();

        #region 获取数据
        public async Task<TData<List<Test1Entity>>> GetList(Test1ListParam param)
        {
            TData<List<Test1Entity>> obj = new TData<List<Test1Entity>>();
            obj.Data = await test1Service.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<Test1Entity>>> GetPageList(Test1ListParam param, Pagination pagination)
        {
            TData<List<Test1Entity>> obj = new TData<List<Test1Entity>>();
            obj.Data = await test1Service.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<Test1Entity>> GetEntity(long id)
        {
            TData<Test1Entity> obj = new TData<Test1Entity>();
            obj.Data = await test1Service.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(Test1Entity entity)
        {
            TData<string> obj = new TData<string>();
            await test1Service.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await test1Service.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
