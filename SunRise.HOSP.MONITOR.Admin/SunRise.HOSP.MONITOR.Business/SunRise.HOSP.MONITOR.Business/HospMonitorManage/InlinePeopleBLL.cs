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
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using SunRise.HOSP.MONITOR.Enum;

namespace SunRise.HOSP.MONITOR.Business.HospMonitorManage
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
        private HistoricalPerRecordsService historicalPerRecordsService = new HistoricalPerRecordsService();
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
        public async Task<TData<List<HospMonitorInLinePeopleViewModel>>> GetInLineDetailsList(InlinePeopleListParam param, Pagination pagination = null)
        {
            TData<List<HospMonitorInLinePeopleViewModel>> obj = new TData<List<HospMonitorInLinePeopleViewModel>>();
            List<InlinePeopleEntity> inlinePeopleEntities = null;
            if (pagination != null)
            {
                inlinePeopleEntities = await inlinePeopleService.GetPageList(param, pagination);
            }
            else
            {
                inlinePeopleEntities = await inlinePeopleService.GetList(param);
            }
            if (inlinePeopleEntities == null)
            {
                obj.Tag = 0;
                obj.Message = "查询失败";
                return obj;
            }
            BaseInfoListParam baseInfoListParam = new BaseInfoListParam
            {
                sId = param.sId,
                sName = param.sName
            };
            List<BaseInfoEntity> baseInfoEntities = await baseInfoService.GetList(baseInfoListParam);
            #region 左外连
            //obj.Data = (from inline in inlinePeopleEntities
            //            join baseInfo in baseInfoEntities on inline.sId equals baseInfo.sId into InLineDetails
            //            from details in InLineDetails.DefaultIfEmpty()
            //            select new HospMonitorInLinePeopleViewModel
            //            {
            //                Id = inline.Id.ToString(),
            //                sId = details?.sId,
            //                nType = inline.nType,
            //                dtCheckIn = inline.dtCheckIn,
            //                sPatientId = inline.sPatientId,
            //                sName = details?.sName,
            //                sPhone = details?.sPhone,
            //                sAddress = details?.sAddress,
            //                sBedNo = details?.sBedNo,
            //                sArea = details?.sArea,
            //                sDoc = details?.sDoc,
            //                sSex = details?.sSex,
            //                sAge = details?.sAge,
            //                sRemarks = details?.sRemarks,
            //                sExtend = details?.sExtend
            //            }).ToList();
            #endregion
            #region 内联
            obj.Data=
            (from inline in inlinePeopleEntities
            join baseInfo in baseInfoEntities on inline.sId equals baseInfo.sId 
            select new HospMonitorInLinePeopleViewModel
            {
                Id = inline.Id.ToString(),
                sId = inline?.sId,
                nType = inline.nType,
                dtCheckIn = inline.dtCheckIn,
                sPatientId = inline.sPatientId,
                sName = baseInfo?.sName,
                sPhone = baseInfo?.sPhone,
                sAddress = baseInfo?.sAddress,
                sBedNo = baseInfo?.sBedNo,
                sArea = baseInfo?.sArea,
                sDoc = baseInfo?.sDoc,
                sSex = baseInfo?.sSex,
                sAge = baseInfo?.sAge,
                sRemarks = baseInfo?.sRemarks,
                sExtend = baseInfo?.sExtend
            }).ToList();
            #endregion      
            obj.Total = pagination?.TotalCount ?? 0;
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
            //await LoopInsert(ids);
            //if (!await this.InsertCheckData(ids))
            //{
            //    obj.Tag = 0;
            //    obj.Message = "網絡異常,請稍後重試";
            //    return obj;
            //}

            await inlinePeopleService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }


        /// <summary>
        /// 注销操作
        /// </summary>
        /// <returns></returns>
        public async Task<TData> CancelOper(string ids)
        {
            TData obj = new TData();
            obj.Tag = 0;
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            TData<List<InlinePeopleEntity>> InLineData = await this.GetList(new InlinePeopleListParam
            {
                Ids = idArr
            });
            if (InLineData.Tag == 1 && InLineData.Data != null && idArr.Length == InLineData.Data.Count)
            {
          
                await InsertCheckData(InLineData.Data);
                await inlinePeopleService.DeleteForm(ids);
                #region 递归
                List<string> sPatId = new List<string>();

                foreach (var item in InLineData.Data)
                {
                    if (item.nType == (int)nTypeEnum.Patient)
                    {
                        sPatId.Add(item.sId);

                    }
                }
                if (sPatId.Count > 0)
                {
                    string allIds = "";
                    TData<List<InlinePeopleEntity>> InLinePatData = await this.GetList(new InlinePeopleListParam
                    {
                        sPatIdArr = sPatId.ToArray()
                    });
                    if (InLinePatData.Tag == 1 && InLinePatData.Data != null)
                    {
                        foreach (var item in InLinePatData.Data)
                        {
                            allIds += (item.Id + ",");
                        }
                       return await CancelOper(allIds.Trim(','));
                    }
                }
                #endregion
            }
            else
            {
                obj.Message = "注销失败，请重试";

                return obj;
            }
            obj.Tag = 1;
            return obj;

        }

        /// <summary>
        /// 向checkin_log中写入people中删除的数据
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        private async Task InsertCheckData(List<InlinePeopleEntity> Data)
        {
            #region 执行添加
            List<HistoricalPerRecordsEntity> HPE = new List<HistoricalPerRecordsEntity>();
            foreach (var item in Data)
            {
                HPE.Add(new HistoricalPerRecordsEntity
                {
                    sId = item.sId,
                    nType = item.nType,
                    dtCheckIn = item.dtCheckIn,
                    dtCheckOut = DateTime.Now,
                    sPatientId = item.sPatientId
                });
            }
            await historicalPerRecordsService.SaveBatchForm(HPE);
    
            #endregion
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
                perids += (EntityData.Id + ",");
            }
            await baseInfoService.DeleteForm(perids.Trim(','));

            return true;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
