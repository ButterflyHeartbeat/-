using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunRise.HOSP.MONITOR.Model.Result.SystemManage;
using SunRise.HOSP.MONITOR.Util.Model;

namespace SunRise.HOSP.MONITOR.Service.SystemManage
{
    public class DatabaseTableOracleService : IDatabaseTableService
    {
        public Task<bool> DatabaseBackup(string database, string backupPath)
        {
            throw new NotImplementedException();
        }

        public Task<List<TableFieldInfo>> GetTableFieldList(string tableName)
        {
            throw new NotImplementedException();
        }

        public Task<List<TableInfo>> GetTableList(string tableName)
        {
            throw new NotImplementedException();
        }

        public Task<List<TableInfo>> GetTablePageList(string tableName, Pagination pagination)
        {
            throw new NotImplementedException();
        }
    }
}
