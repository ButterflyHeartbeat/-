﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunRise_HOSP_MONITOR.Util;
using SunRise_HOSP_MONITOR.Util.Extension;
using SunRise_HOSP_MONITOR.Util.Model;
using SunRise_HOSP_MONITOR.Entity.SystemManage;
using SunRise_HOSP_MONITOR.Model.Param.SystemManage;
using SunRise_HOSP_MONITOR.Service.SystemManage;
using SunRise_HOSP_MONITOR.Entity.OrganizationManage;
using SunRise_HOSP_MONITOR.Service.OrganizationManage;

namespace SunRise_HOSP_MONITOR.Business.SystemManage
{
    public class LogApiBLL
    {
        private LogApiService logApiService = new LogApiService();

        #region 获取数据
        public async Task<TData<List<LogApiEntity>>> GetList(LogApiListParam param)
        {
            TData<List<LogApiEntity>> obj = new TData<List<LogApiEntity>>();
            obj.Data = await logApiService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<LogApiEntity>>> GetPageList(LogApiListParam param, Pagination pagination)
        {
            TData<List<LogApiEntity>> obj = new TData<List<LogApiEntity>>();
            obj.Data = await logApiService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<LogApiEntity>> GetEntity(long id)
        {
            TData<LogApiEntity> obj = new TData<LogApiEntity>();
            obj.Data = await logApiService.GetEntity(id);
            if (obj.Data != null)
            {
                UserEntity userEntity = await new UserService().GetEntity(obj.Data.BaseCreatorId.Value);
                if (userEntity != null)
                {
                    obj.Data.UserName = userEntity.UserName;
                    DepartmentEntity departmentEntitty = await new DepartmentService().GetEntity(userEntity.DepartmentId.Value);
                    if (departmentEntitty != null)
                    {
                        obj.Data.DepartmentName = departmentEntitty.DepartmentName;
                    }
                }
            }
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(LogApiEntity entity)
        {
            TData<string> obj = new TData<string>();
            await logApiService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await logApiService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> RemoveAllForm()
        {
            TData obj = new TData();
            await logApiService.RemoveAllForm();
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
