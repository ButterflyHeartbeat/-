using System;
using System.Collections.Generic;
using System.Text;

namespace SunRise_HOSP_MONITOR.Entity.HospMonitorManage
{
   public class BaseInfoViewModel
    {
        /// <summary>
        /// 人员类型
        /// </summary>
        public int nType { get; set; }
        /// <summary>
        /// 是否上线
        /// </summary>
        public int IsOnLine { get; set; }
        /// <summary>
        /// 如果是陪护/访客则需绑定病人 身份证
        /// 如果是病人 即nType=0 ，则此项为sId
        /// </summary>
        public string sPatient { get; set; }

        #region BaseInfoEntity
        /// <summary>
        /// 身份证
        /// </summary>
        /// <returns></returns>
        public string sId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public string sName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        public string sPhone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        /// <returns></returns>
        public string sAddress { get; set; }
        /// <summary>
        /// 病床号
        /// </summary>
        /// <returns></returns>
        public string sBedNo { get; set; }
        /// <summary>
        /// 病区
        /// </summary>
        /// <returns></returns>
        public string sArea { get; set; }
        /// <summary>
        /// 主治医生
        /// </summary>
        /// <returns></returns>
        public string sDoc { get; set; }
        /// <summary>
        /// 性别  0女  1男
        /// </summary>
        /// <returns></returns>
        public int? sSex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        /// <returns></returns>
        public string sAge { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string sRemarks { get; set; }
        /// <summary>
        /// 扩展字段
        /// </summary>
        /// <returns></returns>
        public string sExtend { get; set; }
        #endregion
    }
}
