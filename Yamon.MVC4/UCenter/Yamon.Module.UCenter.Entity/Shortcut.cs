
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.UCenter.Entity
{
    /// <summary>
    /// 快捷菜单模型实体类
    /// </summary>
    [Serializable]
    [Table("UC_Shortcut")]
    public partial class Shortcut
    {
        public Shortcut()
        { }

        #region Model

        
        /// <summary>
        /// 编号
        /// </summary>
[Column(isPrimaryKey: true, isIdentity: false)]
       public int? LinkID
        {
            set;
            get;
        }

        /// <summary>
        /// 所属用户
        /// </summary>
       public int? UserID
        {
            set;
            get;
        }

        /// <summary>
        /// 链接类型
        /// </summary>
       public int? LinkType
        {
            set;
            get;
        }
[Column(notMap:true)]
       public string LinkType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 链接名称
        /// </summary>
       public string LinkName
        {
            set;
            get;
        }

        /// <summary>
        /// 链接地址
        /// </summary>
       public string LinkUrl
        {
            set;
            get;
        }

        /// <summary>
        /// 链接菜单
        /// </summary>
       public string LinkMenuID
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
