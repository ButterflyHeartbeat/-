using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inte_InpatientCare.Models
{
   public interface IInPatRepository
    {
        /// <summary>
        /// 获取患者信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        InPatient GetInPatient(int id);
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        IEnumerable<InPatient> GetAllInPatient();
        InPatient AddInPat(InPatient inPatient);
        InPatient UpDateInPat(InPatient inPatient);
        bool DeleteInPat(int id);
    }
}
