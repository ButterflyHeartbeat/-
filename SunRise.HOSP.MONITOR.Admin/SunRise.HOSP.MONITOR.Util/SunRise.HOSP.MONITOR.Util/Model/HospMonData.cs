using System;
using System.Collections.Generic;
using System.Text;

namespace SunRise.HOSP.MONITOR.Util.Model
{
   public class HospMonData
    {
        /// <summary>
        /// 0代表失败 1成功
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 提示信息或异常信息
        /// </summary>
        public string Message { get; set; }

      
    }

    public class HospMonData<T>: HospMonData
    {
        public T Data { get; set; }
    }


    public class ParameterIn
    {
        public string sId { get; set; }
        public string sName { get; set; }
    }
}
