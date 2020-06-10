using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inte_InpatientCare.Models
{
    public interface IInPatManger
    {
        /// <summary>
        /// 获取患者信息
        /// </summary>
        /// <returns></returns>
        InPatient GetInPatInfo(int id);
        /// <summary>
        /// 獲取患者列表信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<InPatient> GetInPatList();
        /// <summary>
        /// 添加患者
        /// </summary>
        InPatient AddInPat(InPatient inPatient);
    }
}
