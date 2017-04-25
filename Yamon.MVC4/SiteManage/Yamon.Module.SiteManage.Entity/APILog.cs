
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.SiteManage.Entity
{
    /// <summary>
    /// 接口日志实体类
    /// </summary>
    [Serializable]
    [Table("SiteManage_APILogs")]
    public partial class APILog
    {
        public APILog()
        { }

        #region Model

        
        /// <summary>
        /// ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("ID")]
       public long? LogID
        {
            set;
            get;
        }

        /// <summary>
        /// 日志时间
        /// </summary>
       [DisplayName("日志时间")]
       public DateTime? LogTime
        {
            set;
            get;
        }

        /// <summary>
        /// 应用
        /// </summary>
       [DisplayName("应用")]
       public string AppKey
        {
            set;
            get;
        }

        /// <summary>
        /// 请求地址
        /// </summary>
       [DisplayName("请求地址")]
       public string RequestUrl
        {
            set;
            get;
        }

        /// <summary>
        /// 接口名称
        /// </summary>
       [DisplayName("接口名称")]
       public string APIID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("接口名称")]
       public string APIID_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 请求参数
        /// </summary>
       [DisplayName("请求参数")]
       public string RequestParam
        {
            set;
            get;
        }

        /// <summary>
        /// 响应信息
        /// </summary>
       [DisplayName("响应信息")]
       public string ResponseData
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
       [Column(notMap:true)]
       [DisplayName("是否成功")]
       public string IsSuccess_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 错误代码
        /// </summary>
       [DisplayName("错误代码")]
       public int? ErrorCode
        {
            set;
            get;
        }

        /// <summary>
        /// IP
        /// </summary>
       [DisplayName("IP")]
       public string IP
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
