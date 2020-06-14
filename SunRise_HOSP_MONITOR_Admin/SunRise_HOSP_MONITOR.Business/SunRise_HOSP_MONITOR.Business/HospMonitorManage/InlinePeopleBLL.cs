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
using System.Security.Cryptography;

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
        private BaseInfoService baseInfoService = new BaseInfoService();
        private HistoricalPerRecordsBLL historicalPerRecordsBLL = new HistoricalPerRecordsBLL();
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
        public async Task<TData<List<HospMonitorInLinePeopleViewModel>>> GetInLineDetailsList(InlinePeopleListParam param, Pagination pagination)
        {
            TData<List<HospMonitorInLinePeopleViewModel>> obj = new TData<List<HospMonitorInLinePeopleViewModel>>();
            List<InlinePeopleEntity> inlinePeopleEntities = await inlinePeopleService.GetPageList(param, pagination);
            BaseInfoListParam baseInfoListParam = new BaseInfoListParam
            {
                sId=param.sId,
                sName=param.sName
            };
            List<BaseInfoEntity> baseInfoEntities = await baseInfoService.GetList(baseInfoListParam);
            obj.Data = (from inline in inlinePeopleEntities
                        join baseInfo in baseInfoEntities on inline.sId equals baseInfo.sId into InLineDetails
                        from details in InLineDetails.DefaultIfEmpty()
                        select new HospMonitorInLinePeopleViewModel
                        {
                            Id = inline.Id,
                            sId = details?.sId,
                            nType = inline.nType,
                            dtCheckIn = inline.dtCheckIn,
                            sPatientId = inline.sPatientId,
                            sName = details?.sName,
                            sPhone=details?.sPhone,
                            sAddress=details?.sAddress,
                            sBedNo=details?.sBedNo,
                            sArea=details?.sArea,
                            sDoc=details?.sDoc,
                            sSex=details?.sSex,
                            sAge=details?.sAge,
                            sRemarks=details?.sRemarks,
                            sExtend=details?.sExtend
                        }).ToList();
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
            await LoopInsert(ids);
            TData obj = new TData();
            await inlinePeopleService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }

        private async Task LoopInsert(string ids)
        {
                if (!await this.InsertCheckData(ids))
                {
                  await LoopInsert(ids);
                }
        }

        /// <summary>
        /// 向checkin_log中写入people中删除的数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        private async Task<bool> InsertCheckData(string ids)
        {
            
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            foreach (var id in idArr)
            {
              TData<InlinePeopleEntity> data= await this.GetEntity(id);
                if (data.Tag != 1 || data.Data==null) return false;
                //向checkin_log中写入数据
                HistoricalPerRecordsEntity historicalPerRecordsEntity = new HistoricalPerRecordsEntity
                {
                    sId=data.Data.sId,
                    nType=data.Data.nType,
                    dtCheckIn=data.Data.dtCheckIn,
                    dtCheckOut=DateTime.Now,
                    sPatientId=data.Data.sPatientId
                };
                TData<string> objCheck = await historicalPerRecordsBLL.SaveForm(historicalPerRecordsEntity);
                if (objCheck.Tag != 1 || data.Data == null) return false;
            }
            return true;
           
        }

        /// <summary>
        /// 清除people_base_info表中数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        private async Task<bool> DeleteBaseData(string ids)
        {
            List<string> per = new List<string>();
            string perids = "";
            foreach (var id in ids)
            {
                var EntityData = await baseInfoService.GetEntity(id);
                if (EntityData == null) continue;
                perids += (EntityData.Id+",");
            }
            await baseInfoService.DeleteForm(perids.Trim(','));

            return true;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
