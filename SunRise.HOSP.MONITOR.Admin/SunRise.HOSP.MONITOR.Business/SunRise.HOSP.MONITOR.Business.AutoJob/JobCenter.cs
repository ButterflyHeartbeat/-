﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using SunRise.HOSP.MONITOR.Entity.SystemManage;
using SunRise.HOSP.MONITOR.Service.SystemManage;
using SunRise.HOSP.MONITOR.Util;
using SunRise.HOSP.MONITOR.Util.Model;
using SunRise.HOSP.MONITOR.Util.Extension;
using SunRise.HOSP.MONITOR.Enum;
using SunRise.HOSP.MONITOR.Business.SystemManage;

namespace SunRise.HOSP.MONITOR.Business.AutoJob
{
    public class JobCenter
    {
        public void Start()
        {
            Task.Run(async () =>
            {
                if (!GlobalContext.SystemConfig.Debug)
                {
                    TData<List<AutoJobEntity>> obj = await new AutoJobBLL().GetList(null);
                    if (obj.Tag == 1)
                    {
                        AddScheduleJob(obj.Data);
                    }
                }
            });
        }

        #region 添加任务计划
        /// <summary>
        /// 添加任务计划
        /// </summary>
        /// <returns></returns>
        private void AddScheduleJob(List<AutoJobEntity> entityList)
        {
            try
            {
                foreach (AutoJobEntity entity in entityList)
                {
                    if (entity.StartTime == null)
                    {
                        entity.StartTime = DateTime.Now;
                    }
                    DateTimeOffset starRunTime = DateBuilder.NextGivenSecondDate(entity.StartTime, 1);
                    if (entity.EndTime == null)
                    {
                        entity.EndTime = DateTime.MaxValue.AddDays(-1);
                    }
                    DateTimeOffset endRunTime = DateBuilder.NextGivenSecondDate(entity.EndTime, 1);

                    var scheduler = JobScheduler.GetScheduler();
                    IJobDetail job = JobBuilder.Create<JobExecute>().WithIdentity(entity.JobName, entity.JobGroupName).Build();
                    job.JobDataMap.Add("Id", entity.Id);

                    ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                                                 .StartAt(starRunTime)
                                                 .EndAt(endRunTime)
                                                 .WithIdentity(entity.JobName, entity.JobGroupName)
                                                 .WithCronSchedule(entity.CronExpression)
                                                 .Build();

                    scheduler.ScheduleJob(job, trigger);
                    scheduler.Start();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Write(ex);
            }
        }
        #endregion

        #region 添加任务计划
        /// <summary>
        /// 添加任务计划
        /// </summary>
        /// <returns></returns>
        public void ClearScheduleJob()
        {
            try
            {
                JobScheduler.GetScheduler().Clear();
            }
            catch (Exception ex)
            {
                LogHelper.Write(ex);
            }
        }
        #endregion
    }
}
