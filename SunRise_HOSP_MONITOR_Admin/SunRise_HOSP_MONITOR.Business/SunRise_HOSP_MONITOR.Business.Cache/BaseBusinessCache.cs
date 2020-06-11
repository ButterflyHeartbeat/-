using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunRise_HOSP_MONITOR.Cache.Factory;

namespace SunRise_HOSP_MONITOR.Business.Cache
{
    public abstract class BaseBusinessCache<T>
    {
        public abstract string CacheKey { get; }

        public virtual bool Remove()
        {
            return CacheFactory.Cache.RemoveCache(CacheKey);
        }

        public virtual Task<List<T>> GetList()
        {
            throw new Exception("请在子类实现");
        }
    }
}
