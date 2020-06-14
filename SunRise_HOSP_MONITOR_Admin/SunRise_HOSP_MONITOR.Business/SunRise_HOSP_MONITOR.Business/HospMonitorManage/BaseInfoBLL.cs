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
using SunRise_HOSP_MONITOR.Enum;

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
        private InlinePeopleService inlinePeopleService = new InlinePeopleService();
        private ConfigService configService = new ConfigService();
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
        /// <summary>
        /// 登记
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TData<string>> RegisterBase(BaseInfoViewModel entity)
        {
            TData<string> obj = new TData<string>();
            obj.Tag = 0;
            if (!System.Enum.IsDefined(typeof(nTypeEnum), entity.nType))
            {
                obj.Message = $"人员类型有误";
                return obj;
            }
            if (!await QueryInLineCount(entity.sPatient, entity.nType))
            {
                var nTypeStr = (nTypeEnum)entity.nType == nTypeEnum.Chaperon ?"陪护":"访客";
                obj.Message = $"该患者的{nTypeStr}人数已达上线";
                return obj;
            }
            await baseInfoService.SaveForm(new BaseInfoEntity
            {
                sId = entity.sId,
                sName = entity.sName,
                sPhone = entity.sPhone,
                sAddress = entity.sAddress,
                sBedNo = entity.sBedNo,
                sArea = entity.sArea,
                sDoc = entity.sDoc,
                sSex = entity.sSex,
                sAge = entity.sAge,
                sRemarks = entity.sRemarks,
                sExtend = entity.sExtend
            });

            //if (entity.IsOnLine==1)
            if (true)
            {
                await inlinePeopleService.SaveForm(new InlinePeopleEntity
                {
                    sId = entity.sId,
                    nType = entity.nType,
                    dtCheckIn = DateTime.Now,
                    sPatientId = entity.nType == 0 ? entity.sId : entity.sPatient
                });
            }
           
            //obj.Data = entity.sId;
            obj.Tag = 1;
            return obj;
        }

        /// <summary>
        /// 判断当前患者陪护/访客人数是否达到上限
        /// </summary>
        /// <param name="sPatientId"></param>
        /// <param name="nType"></param>
        /// <returns></returns>
        private async Task<bool> QueryInLineCount(string sPatientId, int nType)
        {
            List<InlinePeopleEntity> inlinePeopleEntities = await inlinePeopleService.GetList(new InlinePeopleListParam
            {
                sPatientId = sPatientId,
                nType = nType
            });
            if (nType == (int)nTypeEnum.Chaperon && inlinePeopleEntities.Count >= HospMonConfigure.nMaxAccompanyCount) return false;
            if (nType == (int)nTypeEnum.Visitor && inlinePeopleEntities.Count >= HospMonConfigure.nMaxVisitorCount) return false;
            return true;
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
