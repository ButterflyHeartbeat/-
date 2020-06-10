using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Inte_InpatientCare.Models
{
    public class GetInPatInfoOpr : IInPatManger
    {
        private readonly List<InPatient> _inPatList;

        public GetInPatInfoOpr()
        {
            _inPatList = new List<InPatient>();
            //_inPatList.Add(new InPatient { ID = 1, Name = "張三", Sex = SexEnum.男, InPatCard = "20200060801", Chaperone = "張三陪護" });
            _inPatList.Add(new InPatient { ID = 2, Name = "里斯", Sex = SexEnum.男, InPatCard = "20200060802", Chaperone = "里斯陪護" });
            _inPatList.Add(new InPatient { ID = 3, Name = "王五", Sex = SexEnum.男, InPatCard = "20200060803", Chaperone = "王五陪護" });
            _inPatList.Add(new InPatient { ID = 4, Name = "趙六", Sex = SexEnum.男, InPatCard = "20200060804", Chaperone = "趙六陪護" });
            _inPatList.Add(new InPatient { ID = 5, Name = "岩崎", Sex = SexEnum.女, InPatCard = "20200060805", Chaperone = "岩崎陪護" });
        }

        public InPatient AddInPat(InPatient inPatient)
        {
            inPatient.ID = _inPatList.Max(m => m.ID) + 1;
            _inPatList.Add(inPatient);
            return inPatient;
        }

        public InPatient GetInPatInfo(int id)
        {
            return _inPatList.Where(w => w.ID == id).FirstOrDefault();
        }

        public IEnumerable<InPatient> GetInPatList()
        {
            return _inPatList;
        }
    }
}
