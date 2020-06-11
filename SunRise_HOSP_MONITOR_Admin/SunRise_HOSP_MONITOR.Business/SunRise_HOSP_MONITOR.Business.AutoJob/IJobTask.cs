using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunRise_HOSP_MONITOR.Util.Model;

namespace SunRise_HOSP_MONITOR.Business.AutoJob
{
    public interface IJobTask
    {
        Task<TData> Start();
    }
}
