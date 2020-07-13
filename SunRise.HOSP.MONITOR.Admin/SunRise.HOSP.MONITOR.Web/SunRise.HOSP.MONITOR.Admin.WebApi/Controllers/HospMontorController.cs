using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SunRise.HOSP.MONITOR.Business.HospMonitorManage;
using SunRise.HOSP.MONITOR.Entity.HospMonitorManage;
using SunRise.HOSP.MONITOR.Enum;
using SunRise.HOSP.MONITOR.Util.Extension;
using SunRise.HOSP.MONITOR.Util.Model;

namespace SunRise.HOSP.MONITOR.Admin.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [AuthorizeFilter]
    public class HospMontorController : ControllerBase
    {
        private ConfigBLL configBLL = new ConfigBLL();
        private InlinePeopleBLL inLineBLL = new InlinePeopleBLL();
        private BaseInfoBLL baseInfoBLL = new BaseInfoBLL();
        private HistoricalPerRecordsBLL HisPerReBLL = new HistoricalPerRecordsBLL();
        private PassRecordBLL passReBLL = new PassRecordBLL();
        #region MyRegion
        /// <summary>
        /// 获取住院患者数据
        /// </summary>
        /// <param name="parameterIn"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HospMonData<List<HospMonitorInLinePeopleViewModel>>> QueryInPatList([FromBody] ParameterIn parameterIn)
        {
            HospMonData<List<HospMonitorInLinePeopleViewModel>> hospMonData = new HospMonData<List<HospMonitorInLinePeopleViewModel>>();
            var data = await inLineBLL.GetInLineDetailsList(new Model.Param.HospMonitorManage.InlinePeopleListParam
            {
                sId = parameterIn.sId,
                sName = parameterIn.sName
            });
            hospMonData.Code = data.Tag;
            hospMonData.Message = data.Message;
            hospMonData.Data = data.Data;
            return hospMonData;
        }

        /// <summary>
        /// 登记
        /// </summary>
        /// <param name="baseInfoViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HospMonData> Register([FromBody]BaseInfoViewModel baseInfoViewModel)
        {
           var AutReturn=  await this.Authentication(new ParameterIn { sId= baseInfoViewModel?.sId });
            if (AutReturn.Code==00)
            {
                HospMonData hospMonData = new HospMonData();
                var data = await baseInfoBLL.RegisterBase(baseInfoViewModel);
                hospMonData.Code = data.Tag;
                hospMonData.Message = data.Message;
                return hospMonData;
            }
            return AutReturn;
        }

        /// <summary>
        /// 人员通过认证
        /// </summary>
        /// <param name="parameterIn"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HospMonData> Authentication([FromBody] ParameterIn parameterIn)
        {
            HospMonData hospMonData = new HospMonData();
            var data = await passReBLL.SaveForm(new PassRecordEntity
            {
                sId = parameterIn.sId
            },"webapi");
            hospMonData.Code = data.Tag;
            hospMonData.Message = data.Message;
            return hospMonData;
        }
        #endregion

        //private async Task GetMaxAVCount()
        //{
        //    TData<List<Entity.HospMonitorManage.ConfigEntity>> data = await configBLL.GetList(new Model.Param.HospMonitorManage.ConfigListParam
        //    {

        //    });
        //    if (data.Tag != 1 || data.Data == null) return;
        //    foreach (var item in data?.Data)
        //    {
        //        if (item.ConfigName.Equals("nMaxAccompanyCount"))
        //        {
        //            HospMonConfigure.nMaxAccompanyCount = int.Parse(item.ConfigValue);

        //        }
        //        if (item.ConfigName.Equals("nMaxVisitorCount"))
        //        {
        //            HospMonConfigure.nMaxVisitorCount = int.Parse(item.ConfigValue);
        //        }
        //    }


        //}
    }




}
