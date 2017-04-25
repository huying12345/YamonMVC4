
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.SiteManage.Entity
{
    /// <summary>
    /// 日志模型实体类
    /// </summary>
    [Serializable]
    [Table("SiteManage_Log")]
    public partial class Log
    {
        public Log()
        { }

        #region Model

        
        /// <summary>
        /// 模型编号
        /// </summary>
       [DisplayName("模型编号")]
       public string ModelID
        {
            set;
            get;
        }

        /// <summary>
        /// 是否成功
        /// </summary>
       [DisplayName("是否成功")]
       public int? IsSuccess
        {
            set;
            get;
        }

        /// <summary>
        /// ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("ID")]
       public int? LogID
        {
            set;
            get;
        }

        /// <summary>
        /// 日志类型
        /// </summary>
       [DisplayName("日志类型")]
       public string LogType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("日志类型")]
       public string LogType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 日志内容
        /// </summary>
       [DisplayName("日志内容")]
       public string LogContent
        {
            set;
            get;
        }

        /// <summary>
        /// 操作人
        /// </summary>
       [DisplayName("操作人")]
       public int? UserID
        {
            set;
            get;
        }

        /// <summary>
        /// 操作时间
        /// </summary>
       [DisplayName("操作时间")]
       public DateTime? LogTime
        {
            set;
            get;
        }

        /// <summary>
        /// 操作IP
        /// </summary>
       [DisplayName("操作IP")]
       public string UserIP
        {
            set;
            get;
        }

        /// <summary>
        /// 关键字
        /// </summary>
       [DisplayName("关键字")]
       public string LogKey
        {
            set;
            get;
        }

        /// <summary>
        /// 操作人
        /// </summary>
       [DisplayName("操作人")]
       public string UserName
        {
            set;
            get;
        }

        /// <summary>
        /// 参数
        /// </summary>
       [DisplayName("参数")]
       public string Params
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
