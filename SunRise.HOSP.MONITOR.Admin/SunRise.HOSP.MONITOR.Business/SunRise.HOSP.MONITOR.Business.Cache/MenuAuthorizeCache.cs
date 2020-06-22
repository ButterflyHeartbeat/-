using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunRise.HOSP.MONITOR.Cache.Factory;
using SunRise.HOSP.MONITOR.Entity.SystemManage;
using SunRise.HOSP.MONITOR.Service.SystemManage;

namespace SunRise.HOSP.MONITOR.Business.Cache
{
    public class MenuAuthorizeCache : BaseBusinessCache<MenuAuthorizeEntity>
    {
        private MenuAuthorizeService menuAuthorizeService = new MenuAuthorizeService();

        public override string CacheKey => this.GetType().Name;

        public override async Task<List<MenuAuthorizeEntity>> GetList()
        {
            var cacheList = CacheFactory.Cache.GetCache<List<MenuAuthorizeEntity>>(CacheKey);
            if (cacheList == null)
            {
                var list = await menuAuthorizeService.GetList(null);
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
