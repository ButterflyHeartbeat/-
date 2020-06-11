using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunRise_HOSP_MONITOR.Cache.Factory;
using SunRise_HOSP_MONITOR.Entity.SystemManage;
using SunRise_HOSP_MONITOR.Service.SystemManage;

namespace SunRise_HOSP_MONITOR.Business.Cache
{
    public class MenuCache : BaseBusinessCache<MenuEntity>
    {
        private MenuService menuService = new MenuService();

        public override string CacheKey => this.GetType().Name;

        public override async Task<List<MenuEntity>> GetList()
        {
            var cacheList = CacheFactory.Cache.GetCache<List<MenuEntity>>(CacheKey);
            if (cacheList == null)
            {
                var list = await menuService.GetList(null);
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
