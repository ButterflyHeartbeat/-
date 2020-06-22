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
using NPOI.SS.Formula.Functions;

namespace SunRise.HOSP.MONITOR.Service.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-15 10:51
    /// 描 述：配置表服务类
    /// </summary>
    public class ConfigService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<ConfigEntity>> GetList(ConfigListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<ConfigEntity>> GetPageList(ConfigListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<ConfigEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<ConfigEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(ConfigEntity entity)
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
            await this.BaseRepository().Delete<ConfigEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<ConfigEntity, bool>> ListFilter(ConfigListParam param)
        {
            var expression = LinqExtensions.True<ConfigEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.ConfigCnName))
                {
                    expression = expression.And(t=>t.ConfigCnName.Contains(param.ConfigCnName));
                }

                if (!string.IsNullOrEmpty(param.ConfigName))
                {
                    expression = expression.And(t => t.ConfigName.Contains(param.ConfigName));
                }
            }
            return expression;
        }
        #endregion
    }
}
