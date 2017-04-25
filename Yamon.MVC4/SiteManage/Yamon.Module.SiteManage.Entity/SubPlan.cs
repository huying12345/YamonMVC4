
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.SiteManage.Entity
{
    /// <summary>
    /// 计划任务模型实体类
    /// </summary>
    [Serializable]
    [Table("SiteManage_SubPlan")]
    public partial class SubPlan
    {
        public SubPlan()
        { }

        #region Model

        
        /// <summary>
        /// ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("ID")]
       public int? SubPlanID
        {
            set;
            get;
        }

        /// <summary>
        /// 计划类型
        /// </summary>
       [DisplayName("计划类型")]
       public string PlanType
        {
            set;
            get;
        }

        /// <summary>
        /// 说明
        /// </summary>
       [DisplayName("说明")]
       public string Title
        {
            set;
            get;
        }

        /// <summary>
        /// 开始日期
        /// </summary>
       [DisplayName("开始日期")]
       public DateTime? BeginDate
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("开始日期")]
       public string BeginDate_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 结束日期
        /// </summary>
       [DisplayName("结束日期")]
       public DateTime? EndDate
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("结束日期")]
       public string EndDate_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 每天执行类型
        /// </summary>
       [DisplayName("每天执行类型")]
       public string DayExecuteTimeType
        {
            set;
            get;
        }

        /// <summary>
        /// 天间隔
        /// </summary>
       [DisplayName("天间隔")]
       public int? Day_Interval
        {
            set;
            get;
        }

        /// <summary>
        /// 每天循环数量
        /// </summary>
       [DisplayName("每天循环数量")]
       public string Day_LoopNum
        {
            set;
            get;
        }

        /// <summary>
        /// 每天循环类型
        /// </summary>
       [DisplayName("每天循环类型")]
       public string Day_LoopType
        {
            set;
            get;
        }

        /// <summary>
        /// 每天一次执行时间
        /// </summary>
       [DisplayName("每天一次执行时间")]
       public string Day_Time
        {
            set;
            get;
        }

        /// <summary>
        /// 每天多次执行时间
        /// </summary>
       [DisplayName("每天多次执行时间")]
       public string Day_TimeList
        {
            set;
            get;
        }

        /// <summary>
        /// 每天执行类型
        /// </summary>
       [DisplayName("每天执行类型")]
       public string ExecuteTimeType
        {
            set;
            get;
        }

        /// <summary>
        /// 月执行类型
        /// </summary>
       [DisplayName("月执行类型")]
       public string MonthLoopType
        {
            set;
            get;
        }

        /// <summary>
        /// 月执行间隔
        /// </summary>
       [DisplayName("月执行间隔")]
       public int? Month_Day_Interval
        {
            set;
            get;
        }

        /// <summary>
        /// 月执行天数
        /// </summary>
       [DisplayName("月执行天数")]
       public int? Month_Day_Num
        {
            set;
            get;
        }

        /// <summary>
        /// 月的第几周
        /// </summary>
       [DisplayName("月的第几周")]
       public int? Month_Week_Loop
        {
            set;
            get;
        }

        /// <summary>
        /// 月的循环周数
        /// </summary>
       [DisplayName("月的循环周数")]
       public int? Month_Week_Num
        {
            set;
            get;
        }

        /// <summary>
        /// 月的间隔数
        /// </summary>
       [DisplayName("月的间隔数")]
       public int? Month_Interval
        {
            set;
            get;
        }

        /// <summary>
        /// 无结束日期
        /// </summary>
       [DisplayName("无结束日期")]
       public int? NoEndDate
        {
            set;
            get;
        }

        /// <summary>
        /// 旬的第几天
        /// </summary>
       [DisplayName("旬的第几天")]
       public int? TenDay_Interval
        {
            set;
            get;
        }

        /// <summary>
        /// 指定星期的哪天
        /// </summary>
       [DisplayName("指定星期的哪天")]
       public string Week_Loop
        {
            set;
            get;
        }

        /// <summary>
        /// 周数
        /// </summary>
       [DisplayName("周数")]
       public string Week_LoopNum
        {
            set;
            get;
        }

        /// <summary>
        /// 天开始时间
        /// </summary>
       [DisplayName("天开始时间")]
       public string Day_BeginTime
        {
            set;
            get;
        }

        /// <summary>
        /// 天结束时间
        /// </summary>
       [DisplayName("天结束时间")]
       public string Day_EndTime
        {
            set;
            get;
        }

        /// <summary>
        /// 旬
        /// </summary>
       [DisplayName("旬")]
       public string TendayList
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
