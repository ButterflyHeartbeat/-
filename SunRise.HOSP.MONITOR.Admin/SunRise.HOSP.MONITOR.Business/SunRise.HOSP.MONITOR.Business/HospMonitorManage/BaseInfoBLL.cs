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
using SunRise.HOSP.MONITOR.Enum;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SunRise.HOSP.MONITOR.Business.HospMonitorManage
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
        //private PassRecordBLL passRecordBLL = new PassRecordBLL();

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
            #region test
            //{
            //    var TdataPatInfo = await this.GetList(new BaseInfoListParam
            //    {
            //        sId = entity.sId
            //    });
            //    if (TdataPatInfo.Tag == 0) obj.Message = "网络异常，请重试";
            //    if (TdataPatInfo.Data == null || TdataPatInfo.Data.Count <= 0)
            //    {
            //        BiId = 0;
            //    }
            //    else
            //    {
            //        BiId = TdataPatInfo.Data.FirstOrDefault()?.Id ?? 0;
            //    }
            //}
            #endregion
            TData<string> obj = new TData<string>();
            obj.Tag = 0;
            long Oprlong;
            var OprStr = await ComprehensiveOper(entity);
            //if (OprStr == "00")
            //{
            //    obj.Tag = 1;
            //    obj.Message= "认证成功，请通过";
            //    return obj;
            //}
            if (long.TryParse(OprStr, out Oprlong))
            {

                await baseInfoService.SaveForm(new BaseInfoEntity
                {
                    Id = Oprlong,
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

            }
            else
            {
                obj.Message = OprStr;
                return obj;
            }




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
            obj.Message = "登记成功";
            return obj;
        }

        /// <summary>
        /// 处理逻辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private async Task<string> ComprehensiveOper(BaseInfoViewModel entity)
        {
            if (entity == null || entity.sId == null)
            {
                return "身份证不能为空";
            }
            if (!System.Enum.IsDefined(typeof(nTypeEnum), entity.nType))
            {
                return $"人员类型有误";
            }
            var nTypeStr = (nTypeEnum)entity.nType == nTypeEnum.Chaperon ? "陪护" :
                     (nTypeEnum)entity.nType == nTypeEnum.Visitor ? "访客" : "患者";
            if (entity.sId.Equals(entity.sPatient) && entity.nType != (int)nTypeEnum.Patient)
            {
                //return $"{nTypeStr}不可绑定自己";
                return $"绑定患者有误";
            }

            var Count = await QueryInLineCount(entity.sPatient, entity.nType, entity.sId);
            if (Count == 2)
            {

                return $"该患者的{nTypeStr}人数已达上线";
            }
            else if (Count == 1)
            {
                return $"要綁定的患者不存在或已注销";
            }
            else if (Count == 3)
            {

                 return $"該{nTypeStr}已在綫登記";
                //var BDPat = await passRecordBLL.SaveForm(new PassRecordEntity
                //{
                //    sId = entity.sId,
                //    nType = entity.nType,
                //    dtPass = DateTime.Now,
                //    sPatientId = entity.sPatient
                //});
                //if (BDPat.Tag==1) {
                //    return "00";
                //}
                //else
                //{
                //    return "认证失败";
                //}
            }

            {
                var TdataPatInfo = await this.GetList(new BaseInfoListParam
                {
                    sId = entity.sId
                });
                if (TdataPatInfo.Tag == 0) return "网络异常，请重试";
                if (TdataPatInfo.Data == null || TdataPatInfo.Data.Count <= 0)
                {
                    return "0";
                }
                else
                {
                    return TdataPatInfo.Data.FirstOrDefault()?.Id.ToString();
                }
            }

        }

        /// <summary>
        /// 判断当前患者陪护/访客人数是否达到上限
        /// 判断当前要绑定的患者是否在线
        /// 判断当前患者陪护/访客是否已登记
        /// </summary>
        /// <param name="sPatientId"></param>
        /// <param name="nType"></param>
        /// <returns></returns>
        private async Task<int> QueryInLineCount(string sPatientId, int nType, string sId)
        {
            List<InlinePeopleEntity> inlinePeopleEntities = await inlinePeopleService.GetList(new InlinePeopleListParam
            {

            });
            var GetAVData = inlinePeopleEntities;

            {
                GetAVData = inlinePeopleEntities.Where(
                   w => w.sId == sPatientId &&
                   w.nType == (int)nTypeEnum.Patient
                   ).ToList();
                if (nType != (int)nTypeEnum.Patient && GetAVData.Count <= 0) return 1;//要绑定的患者是否在线

                GetAVData = inlinePeopleEntities.Where(
                   w => w.sId == sId &&
                   w.nType == nType
                   ).ToList();
                if (GetAVData.Count > 0) return 3;//当前要登記的人员是否已经在綫

                //GetAVData = inlinePeopleEntities.Where(
                //  w => w.sId == sId &&
                //  w.nType == (int)nTypeEnum.Patient
                //  ).ToList();
                //if (GetAVData.Count > 0) return 4;//当前要的登記的人員已經作爲

            }


            {
                GetAVData = inlinePeopleEntities.Where(
           w => w.sId != sPatientId &&
           w.sPatientId == sPatientId &&
           w.nType == nType).ToList();
                if (nType == (int)nTypeEnum.Chaperon && GetAVData.Count >= HospMonConfigure.nMaxAccompanyCount) return 2;
                if (nType == (int)nTypeEnum.Visitor && GetAVData.Count >= HospMonConfigure.nMaxVisitorCount) return 2;
            }

            return 0;
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
