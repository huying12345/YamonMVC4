
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.UCenter.Entity
{
    /// <summary>
    /// 用户角色实体类
    /// </summary>
    [Serializable]
    [Table("UC_UserRole")]
    public partial class UserRole
    {
        public UserRole()
        { }

        #region Model

        
        /// <summary>
        /// ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("ID")]
       public int? UserRoleID
        {
            set;
            get;
        }

        /// <summary>
        /// 用户编号
        /// </summary>
       [DisplayName("用户编号")]
       public int? UserID
        {
            set;
            get;
        }

        /// <summary>
        /// 角色编号
        /// </summary>
       [DisplayName("角色编号")]
       public int? RoleID
        {
            set;
            get;
        }

        /// <summary>
        /// 是否默认
        /// </summary>
       [DisplayName("是否默认")]
       public int? IsDefault
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
