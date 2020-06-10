using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inte_InpatientCare.Models
{
    public static class ModelBiudleSql
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InPatient>().HasData(new InPatient
            {
                ID=11,
                Name="闫高伟",
                //Sex=SexEnum.男,
                InPatCard="16122315",
                Chaperone="毛"
            },
            new InPatient
            {
                ID = 12,
                Name = "毛子轩",
                //Sex = SexEnum.男,
                InPatCard = "16122315",
                Chaperone = "烟"
            }
            );
        }
    }
}
