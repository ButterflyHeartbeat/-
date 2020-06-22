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
    /// 日 期：2020-06-15 10:51
    /// 描 述：配置表业务类
    /// </summary>
    public class ConfigBLL
    {
        private ConfigService configService = new ConfigService();

        #region 获取数据
        public async Task<TData<List<ConfigEntity>>> GetList(ConfigListParam param)
        {
            TData<List<ConfigEntity>> obj = new TData<List<ConfigEntity>>();
            obj.Data = await configService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ConfigEntity>>> GetPageList(ConfigListParam param, Pagination pagination)
        {
            TData<List<ConfigEntity>> obj = new TData<List<ConfigEntity>>();
            obj.Data = await configService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<ConfigEntity>> GetEntity(long id)
        {
            TData<ConfigEntity> obj = new TData<ConfigEntity>();
            obj.Data = await configService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(ConfigEntity entity)
        {
            TData<string> obj = new TData<string>();
            await configService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await configService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
