
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.UCenter.Entity
{
    /// <summary>
    /// 用户模型实体类
    /// </summary>
    [Serializable]
    [Table("UC_User")]
    public partial class User
    {
        public User()
        { }

        #region Model

        
        /// <summary>
        /// 用户编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("用户编号")]
       public int? UserID
        {
            set;
            get;
        }

        /// <summary>
        /// 用户名
        /// </summary>
       [DisplayName("用户名")]
       public string UserName
        {
            set;
            get;
        }

        /// <summary>
        /// 密码
        /// </summary>
       [JsonIgnore]
       [DisplayName("密码")]
       public string PassWord
        {
            set;
            get;
        }

        /// <summary>
        /// 密码确认
        /// </summary>
       [Column(notMap:true)]
       [JsonIgnore]
       [DisplayName("密码确认")]
       public string ConfirmPassword
        {
            set;
            get;
        }

        /// <summary>
        /// 真实姓名
        /// </summary>
       [DisplayName("真实姓名")]
       public string TrueName
        {
            set;
            get;
        }

        /// <summary>
        /// Email
        /// </summary>
       [DisplayName("Email")]
       public string Email
        {
            set;
            get;
        }

        /// <summary>
        /// 所属部门
        /// </summary>
       [DisplayName("所属部门")]
       public int? DepartmentID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("所属部门")]
       public string DepartmentID_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 系统角色
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("系统角色")]
       public string RoleID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("系统角色")]
       public string RoleID_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 手机号
        /// </summary>
       [DisplayName("手机号")]
       public string Tel
        {
            set;
            get;
        }

        /// <summary>
        /// 用户照片
        /// </summary>
       [DisplayName("用户照片")]
       public string Photo
        {
            set;
            get;
        }

        /// <summary>
        /// 在线状态
        /// </summary>
       [DisplayName("在线状态")]
       public int? OnLineStatus
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("在线状态")]
       public string OnLineStatus_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 用户状态
        /// </summary>
       [DisplayName("用户状态")]
       public int? Status
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("用户状态")]
       public string Status_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 最后登陆的IP
        /// </summary>
       [DisplayName("最后登陆的IP")]
       public string LastLoginIP
        {
            set;
            get;
        }

        /// <summary>
        /// 最后登陆的时间
        /// </summary>
       [DisplayName("最后登陆的时间")]
       public DateTime? LastLoginTime
        {
            set;
            get;
        }

        /// <summary>
        /// 登录次数
        /// </summary>
       [DisplayName("登录次数")]
       public int? LoginTimes
        {
            set;
            get;
        }

        /// <summary>
        /// 注册时间
        /// </summary>
       [DisplayName("注册时间")]
       public DateTime? RegisterTime
        {
            set;
            get;
        }

        /// <summary>
        /// 注册应用
        /// </summary>
       [DisplayName("注册应用")]
       public string RegisterAppID
        {
            set;
            get;
        }

        /// <summary>
        /// 最后点击时间
        /// </summary>
       [DisplayName("最后点击时间")]
       public DateTime? LastHitTime
        {
            set;
            get;
        }

        /// <summary>
        /// 最后注销时间
        /// </summary>
       [DisplayName("最后注销时间")]
       public DateTime? LastLogoutTime
        {
            set;
            get;
        }

        /// <summary>
        /// 是否限制IP
        /// </summary>
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
       [DisplayName("限定IP")]
       public string LockIP
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
