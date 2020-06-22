using SunRise.HOSP.MONITOR.Util;
using SunRise.HOSP.MONITOR.Cache.Interface;
using SunRise.HOSP.MONITOR.MemoryCache;
using SunRise.HOSP.MONITOR.RedisCache;

namespace SunRise.HOSP.MONITOR.Cache.Factory
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
