using System.Linq;
using System.Collections.Generic;
using SunRise.HOSP.MONITOR.Cache.Factory;
using SunRise.HOSP.MONITOR.Entity.SystemManage;
using SunRise.HOSP.MONITOR.Service.SystemManage;
using System.Threading.Tasks;

namespace SunRise.HOSP.MONITOR.Business.Cache
{
    public class AreaCache : BaseBusinessCache<AreaEntity>
    {
        private AreaService areaService = new AreaService();

        public override string CacheKey => this.GetType().Name;

        public override async Task<List<AreaEntity>> GetList()
        {
            var cacheList = CacheFactory.Cache.GetCache<List<AreaEntity>>(CacheKey);
            if (cacheList == null)
            {
                var result = await areaService.GetList(null);
                CacheFactory.Cache.SetCache(CacheKey, result);
                return result;
            }
            else
            {
                return cacheList;
            }
        }
    }
}
