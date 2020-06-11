using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunRise_HOSP_MONITOR.Model.Result.SystemManage;
using SunRise_HOSP_MONITOR.Util.Model;

namespace SunRise_HOSP_MONITOR.Service.SystemManage
{
    public interface IDatabaseTableService
    {
        Task<bool> DatabaseBackup(string database, string backupPath);
        Task<List<TableInfo>> GetTableList(string tableName);
        Task<List<TableInfo>> GetTablePageList(string tableName, Pagination pagination);
        Task<List<TableFieldInfo>> GetTableFieldList(string tableName);
    }
}
