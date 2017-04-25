
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.SiteManage.Entity
{
    /// <summary>
    /// 应用实体类
    /// </summary>
    [Serializable]
    [Table("SiteManage_Applications")]
    public partial class Application
    {
        public Application()
        { }

        #region Model

        
        /// <summary>
        /// 应用编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("应用编号")]
       public int? AppID
        {
            set;
            get;
        }

        /// <summary>
        /// 应用名称
        /// </summary>
       [DisplayName("应用名称")]
       public string AppName
        {
            set;
            get;
        }

        /// <summary>
        /// 应用Key
        /// </summary>
       [DisplayName("应用Key")]
       public string AppKey
        {
            set;
            get;
        }

        /// <summary>
        /// 应用密钥
        /// </summary>
       [DisplayName("应用密钥")]
       public string AppSecretKey
        {
            set;
            get;
        }

        /// <summary>
        /// 备注
        /// </summary>
       [DisplayName("备注")]
       public string AppMemo
        {
            set;
            get;
        }

        /// <summary>
        /// 关联用户
        /// </summary>
       [DisplayName("关联用户")]
       public int? UserID
        {
            set;
            get;
        }

        /// <summary>
        /// 授权方式
        /// </summary>
       [DisplayName("授权方式")]
       public string AuthType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("授权方式")]
       public string AuthType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 可信域名
        /// </summary>
       [DisplayName("可信域名")]
       public string AllowDomain
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
