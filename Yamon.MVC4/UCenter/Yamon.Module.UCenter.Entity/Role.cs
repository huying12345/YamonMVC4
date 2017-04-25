
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.UCenter.Entity
{
    /// <summary>
    /// 角色模型实体类
    /// </summary>
    [Serializable]
    [Table("UC_Role")]
    public partial class Role
    {
        public Role()
        { }

        #region Model

        
        /// <summary>
        /// 角色编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("角色编号")]
       public int? RoleID
        {
            set;
            get;
        }

        /// <summary>
        /// 角色名称
        /// </summary>
       [DisplayName("角色名称")]
       public string RoleName
        {
            set;
            get;
        }

        /// <summary>
        /// 排序号
        /// </summary>
       [DisplayName("排序号")]
       public int? OrderID
        {
            set;
            get;
        }

        /// <summary>
        /// 角色描述
        /// </summary>
       [DisplayName("角色描述")]
       public string Description
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
