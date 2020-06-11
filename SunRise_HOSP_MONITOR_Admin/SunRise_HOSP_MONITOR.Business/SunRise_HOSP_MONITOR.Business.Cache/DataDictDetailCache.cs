using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunRise_HOSP_MONITOR.Cache.Factory;
using SunRise_HOSP_MONITOR.Entity.SystemManage;
using SunRise_HOSP_MONITOR.Service.SystemManage;

namespace SunRise_HOSP_MONITOR.Business.Cache
{
    public class DataDictDetailCache : BaseBusinessCache<DataDictDetailEntity>
    {
        private DataDictDetailService dataDictDetailService = new DataDictDetailService();

        public override string CacheKey => this.GetType().Name;

        public override async Task<List<DataDictDetailEntity>> GetList()
        {
            var cacheList = CacheFactory.Cache.GetCache<List<DataDictDetailEntity>>(CacheKey);
            if (cacheList == null)
            {
                var list = await dataDictDetailService.GetList(null);
                CacheFactory.Cache.SetCache(CacheKey, list);
                return list;
            }
            else
            {
                return cacheList;
            }
        }
    }
}
