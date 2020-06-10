using Inte_InpatientCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inte_InpatientCare.ViewModels
{
    public class HomeInPatListViewModel
    {
        public IEnumerable<InPatient> InPatData { get; set; }
        public string PageTitle { get; set; }
    }
}
