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
using SunRise.HOSP.MONITOR.Enum;

namespace SunRise.HOSP.MONITOR.Service.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-12 12:41
    /// 描 述：在线人员服务类
    /// </summary>
    public class InlinePeopleService : RepositoryFactory
    {
        #region 获取数据
        public async Task<List<InlinePeopleEntity>> GetList(InlinePeopleListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<InlinePeopleEntity>> GetPageList(InlinePeopleListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<InlinePeopleEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<InlinePeopleEntity>(id);
        }


        #endregion

        #region 提交数据
        public async Task SaveForm(InlinePeopleEntity entity)
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
            await this.BaseRepository().Delete<InlinePeopleEntity>(idArr);
        }

        #endregion

        #region 私有方法
        private Expression<Func<InlinePeopleEntity, bool>> ListFilter(InlinePeopleListParam param)
        {
            var expression = LinqExtensions.True<InlinePeopleEntity>();
            if (param != null)
            {
                if (param.sPatIdArr != null && param.sPatIdArr.Length > 0)
                {
                    expression = expression.And(t => param.sPatIdArr.Contains(t.sPatientId) && t.nType != (int)nTypeEnum.Patient);
                }
                if (param.Ids != null && param.Ids.Length > 0)
                {
                    expression = expression.And(t => param.Ids.ToList().Contains((t.Id ?? 0)));
                }
                if (!string.IsNullOrEmpty(param.sId))
                {
                    if (!string.IsNullOrEmpty(param.RequestMethod) && param.RequestMethod.Equals("webapi"))
                    {
                        expression = expression.And(t => t.sId.Equals(param.sId));
                    }
                    else
                    {
                        expression = expression.And(t => t.sId.Contains(param.sId));
                    }

                }

                if (!string.IsNullOrEmpty(param.dtCheckIn))
                {
                    var DateArr = param.dtCheckIn.Split('-');
                    var sa = DateArr[0] + "-" + DateArr[1] + "-" + DateArr[2];
                    var saa = DateArr[3] + "-" + DateArr[4] + "-" + DateArr[5];
                    var startTime = DateTime.Parse(sa);
                    var endTime = DateTime.Parse(saa);
                    expression = expression.And(t => t.dtCheckIn <= endTime && t.dtCheckIn >= startTime);
                    //var endtime = (param.dtCheckIn.Value.ToString("yyyy-MM-dd") + " 23:59:59").ParseToDateTime();
                    //expression = expression.And(t => t.dtCheckIn <= endtime&&t.dtCheckIn>=param.dtCheckIn);
                }
                if (param.nType > -1)
                {
                    expression = expression.And(t => t.nType.Equals(param.nType));
                }
                if (!string.IsNullOrEmpty(param.sPatientId))
                {
                    expression = expression.And(t => t.sPatientId.Equals(param.sPatientId));
                }
            }
            return expression;
        }
        #endregion
    }
}
