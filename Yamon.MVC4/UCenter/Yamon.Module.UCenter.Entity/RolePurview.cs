
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.UCenter.Entity
{
    /// <summary>
    /// 角色权限实体类
    /// </summary>
    [Serializable]
    [Table("UC_RolePurview")]
    public partial class RolePurview
    {
        public RolePurview()
        { }

        #region Model

        
        /// <summary>
        /// ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("ID")]
       public int? RolePurviewID
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
        /// 权限项
        /// </summary>
       [DisplayName("权限项")]
       public string Purview
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
