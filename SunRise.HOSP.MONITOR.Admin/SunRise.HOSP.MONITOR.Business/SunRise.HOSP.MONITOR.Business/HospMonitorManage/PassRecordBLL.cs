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
using Microsoft.VisualBasic;
using SunRise.HOSP.MONITOR.Enum;

namespace SunRise.HOSP.MONITOR.Business.HospMonitorManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-06-12 16:44
    /// 描 述：人员出入记录业务类
    /// </summary>
    public class PassRecordBLL
    {
        private PassRecordService passRecordService = new PassRecordService();
        private InlinePeopleService inlinePeopleService = new InlinePeopleService();
        #region 获取数据
        public async Task<TData<List<PassRecordEntity>>> GetList(PassRecordListParam param)
        {
            TData<List<PassRecordEntity>> obj = new TData<List<PassRecordEntity>>();
            obj.Data = await passRecordService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<PassRecordEntity>>> GetPageList(PassRecordListParam param, Pagination pagination)
        {
            TData<List<PassRecordEntity>> obj = new TData<List<PassRecordEntity>>();
            obj.Data = await passRecordService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<PassRecordEntity>> GetEntity(long id)
        {
            TData<PassRecordEntity> obj = new TData<PassRecordEntity>();
            obj.Data = await passRecordService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(PassRecordEntity entity, string RequestMethod="")
        {
          
            TData<string> obj = new TData<string>();
            obj.Tag = 0;
            if (string.IsNullOrEmpty(entity.sId))
            {
                obj.Message = "身份证不能为空";
                return obj;
            }
            var InLineEntity = await this.GetInLineEntity(entity.sId, RequestMethod);
            if (InLineEntity == null)
            {
                obj.Tag = 00;
                obj.Message = "您尚未登记，请登记";
                return obj;
            }
            var nTypeStr = (nTypeEnum)InLineEntity.nType == nTypeEnum.Chaperon ? "陪护" :
      (nTypeEnum)InLineEntity.nType == nTypeEnum.Visitor ? "访客" : "患者";
            entity.nType = InLineEntity.nType;
            entity.dtPass = DateTime.Now;
            entity.sPatientId = InLineEntity.sPatientId;

            await passRecordService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            //obj.Message = $"您的身份是_{nTypeStr}_请通过";
            obj.Message = $"通过";
            return obj;
        }

        private async Task<InlinePeopleEntity> GetInLineEntity(string sId,string RequestMethod)
        {
            List<InlinePeopleEntity> data = await inlinePeopleService.GetList(new InlinePeopleListParam
            {
                sId = sId,
                RequestMethod= RequestMethod
            });
            if (data.Count > 0) return data.FirstOrDefault();
            return null;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await passRecordService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
