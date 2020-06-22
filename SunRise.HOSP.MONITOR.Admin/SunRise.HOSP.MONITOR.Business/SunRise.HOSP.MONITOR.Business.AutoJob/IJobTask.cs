using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunRise.HOSP.MONITOR.Util.Model;

namespace SunRise.HOSP.MONITOR.Business.AutoJob
{
    public interface IJobTask
    {
        Task<TData> Start();
    }
}
