
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.SiteManage.Entity
{
    /// <summary>
    /// 系统配置实体类
    /// </summary>
    [Serializable]
    [Table("SiteManage_Config")]
    public partial class SystemConfig
    {
        public SystemConfig()
        { }

        #region Model

        
        /// <summary>
        /// 主键
        /// </summary>
       [DisplayName("主键")]
       public string ConfigKey
        {
            set;
            get;
        }

        /// <summary>
        /// 值
        /// </summary>
       [DisplayName("值")]
       public string ConfigValue
        {
            set;
            get;
        }

        /// <summary>
        /// 模块
        /// </summary>
       [DisplayName("模块")]
       public string Module
        {
            set;
            get;
        }

        /// <summary>
        /// 系统名称
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("系统名称")]
       public string SiteName
        {
            set;
            get;
        }

        /// <summary>
        /// 登录背景图片
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("登录背景图片")]
       public string SiteLogo
        {
            set;
            get;
        }

        /// <summary>
        /// 后台管理Logo
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("后台管理Logo")]
       public string WebLogo
        {
            set;
            get;
        }

        /// <summary>
        /// 版权信息
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("版权信息")]
       public string Copyright
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
