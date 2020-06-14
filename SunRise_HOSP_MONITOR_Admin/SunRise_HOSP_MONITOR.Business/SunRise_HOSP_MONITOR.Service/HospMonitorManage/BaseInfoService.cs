using System;
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
    /// 日 期：2020-06-12 12:43
    /// 描 述：人员基础信息服务类
    /// </summary>
    public class BaseInfoService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<BaseInfoEntity>> GetList(BaseInfoListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<BaseInfoEntity>> GetPageList(BaseInfoListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<BaseInfoEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<BaseInfoEntity>(id);
        }

        #endregion

        #region 提交数据
        public async Task SaveForm(BaseInfoEntity entity)
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
            await this.BaseRepository().Delete<BaseInfoEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<BaseInfoEntity, bool>> ListFilter(BaseInfoListParam param)
        {
            var expression = LinqExtensions.True<BaseInfoEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.sId))
                {
                    expression.And(t => t.sId.Contains(param.sId));
                }
                if (!string.IsNullOrEmpty(param.sName))
                {
                    expression.And(t => t.sName.Contains(param.sName));
                }
            }
            return expression;
        }
        #endregion
    }
}
