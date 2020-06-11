using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SunRise_HOSP_MONITOR.Util;
using SunRise_HOSP_MONITOR.Util.Model;

namespace SunRise_HOSP_MONITOR.DataTest
{
    [SetUpFixture]
    public class SetupFixture
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            GlobalContext.SystemConfig = new SystemConfig
            {
                DBProvider = "MySql",
                DBConnectionString = "server=localhost;database=YiShaAdmin;user=root;password=123456;port=3306;",
                DBCommandTimeout = 180,
                DBBackup = "DataBase"
            };
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }
    }
}
