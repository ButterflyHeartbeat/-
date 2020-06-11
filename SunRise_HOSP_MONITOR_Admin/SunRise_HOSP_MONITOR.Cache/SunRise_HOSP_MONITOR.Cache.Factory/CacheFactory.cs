using SunRise_HOSP_MONITOR.Util;
using SunRise_HOSP_MONITOR.Cache.Interface;
using SunRise_HOSP_MONITOR.MemoryCache;
using SunRise_HOSP_MONITOR.RedisCache;

namespace SunRise_HOSP_MONITOR.Cache.Factory
{
    public class CacheFactory
    {
        private static ICache cache = null;
        private static readonly object lockHelper = new object();

        public static ICache Cache
        {
            get
            {
                if (cache == null)
                {
                    lock (lockHelper)
                    {
                        if (cache == null)
                        {
                            switch (GlobalContext.SystemConfig.CacheProvider)
                            {
                                case "Redis": cache = new RedisCacheImp(); break;

                                default:
                                case "Memory": cache = new MemoryCacheImp(); break;
                            }
                        }
                    }
                }
                return cache;
            }
        }
    }
}
