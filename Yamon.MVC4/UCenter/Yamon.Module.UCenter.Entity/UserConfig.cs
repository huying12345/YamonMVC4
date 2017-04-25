
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.UCenter.Entity
{
    /// <summary>
    /// 用户配置实体类
    /// </summary>
    [Serializable]
    [Table("UC_UserConfig")]
    public partial class UserConfig
    {
        public UserConfig()
        { }

        #region Model

        
        /// <summary>
        /// ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("ID")]
       public int? ID
        {
            set;
            get;
        }

        /// <summary>
        /// UserID
        /// </summary>
       [DisplayName("UserID")]
       public int? UserID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("UserID")]
       public string UserID_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// ConfigKey
        /// </summary>
       [DisplayName("ConfigKey")]
       public string ConfigKey
        {
            set;
            get;
        }

        /// <summary>
        /// ConfigValue
        /// </summary>
       [DisplayName("ConfigValue")]
       public string ConfigValue
        {
            set;
            get;
        }

        /// <summary>
        /// 预报评分用户名
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("预报评分用户名")]
       public string PF_UserName
        {
            set;
            get;
        }

        /// <summary>
        /// 用户编号
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("用户编号")]
       public string UserNumber
        {
            set;
            get;
        }

        /// <summary>
        /// 预报评分密码
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("预报评分密码")]
       public string PF_PassWord
        {
            set;
            get;
        }

        /// <summary>
        /// 是否限制IP
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("是否限制IP")]
       public int? IsLockIP
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("是否限制IP")]
       public string IsLockIP_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 限定IP
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("限定IP")]
       public string LockIP
        {
            set;
            get;
        }

        /// <summary>
        /// ASOM用户名
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("ASOM用户名")]
       public string ASOMID
        {
            set;
            get;
        }

        /// <summary>
        /// ASOM密码
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("ASOM密码")]
       public string ASOMPWD
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
