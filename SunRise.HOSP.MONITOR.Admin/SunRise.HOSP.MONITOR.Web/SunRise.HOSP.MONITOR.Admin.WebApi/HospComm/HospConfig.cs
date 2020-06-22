using SunRise.HOSP.MONITOR.Business.HospMonitorManage;
using SunRise.HOSP.MONITOR.Util.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunRise.HOSP.MONITOR.Admin.WebApi.HospComm
{
    public static class HospConfig
    {
        
        public async static void GetMaxAVCount()
        {
            TData<List<Entity.HospMonitorManage.ConfigEntity>> data = await new ConfigBLL().GetList(new Model.Param.HospMonitorManage.ConfigListParam
            {

            });
            if (data.Tag != 1 || data.Data == null) return;
            foreach (var item in data?.Data)
            {
                if (item.ConfigName.Equals("nMaxAccompanyCount"))
                {
                    HospMonConfigure.nMaxAccompanyCount = int.Parse(item.ConfigValue);

                }
                if (item.ConfigName.Equals("nMaxVisitorCount"))
                {
                    HospMonConfigure.nMaxVisitorCount = int.Parse(item.ConfigValue);
                }
            }
        }
    }
}
