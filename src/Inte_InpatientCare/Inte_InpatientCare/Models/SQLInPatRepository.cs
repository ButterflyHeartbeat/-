using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Inte_InpatientCare.Models
{
    public class SQLInPatRepository : IInPatRepository
    {
        private readonly AppDbContext _appDbContext;

        public SQLInPatRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public InPatient AddInPat(InPatient inPatient)
        {
             _appDbContext.InPatients.Add(inPatient);
            _appDbContext.SaveChanges();
            return inPatient;
        }

        public bool DeleteInPat(int id)
        {
            var inP = _appDbContext.InPatients.Find(id);
            var ii = 0;
            if (inP != null)
            {
                _appDbContext.InPatients.Remove(inP);
               ii=_appDbContext.SaveChanges();
            }
            return ii > 0 ? true : false;
        }

        public IEnumerable<InPatient> GetAllInPatient()
        {
            return _appDbContext.InPatients;
        }

        public InPatient GetInPatient(int id)
        {
            return _appDbContext.InPatients.Find(id);
        }

        public InPatient UpDateInPat(InPatient inPatient)
        {
            var inP = _appDbContext.InPatients.Attach(inPatient);
            inP.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appDbContext.SaveChanges();
            return inPatient;

        }
    }
}
