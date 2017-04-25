
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.SiteManage.Entity
{
    /// <summary>
    /// 菜单模型实体类
    /// </summary>
    [Serializable]
    [Table("SiteManage_Menu")]
    public partial class Menu
    {
        public Menu()
        { }

        #region Model

        
        /// <summary>
        /// 菜单编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("菜单编号")]
       public string MenuID
        {
            set;
            get;
        }

        /// <summary>
        /// 菜单名称
        /// </summary>
       [DisplayName("菜单名称")]
       public string MenuName
        {
            set;
            get;
        }

        /// <summary>
        /// 上级菜单
        /// </summary>
       [DisplayName("上级菜单")]
       public string ParentID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("上级菜单")]
       public string ParentID_ShowValue
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
        /// 权限码
        /// </summary>
       [DisplayName("权限码")]
       public string PageCode
        {
            set;
            get;
        }

        /// <summary>
        /// 图标类型
        /// </summary>
       [DisplayName("图标类型")]
       public string IconType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("图标类型")]
       public string IconType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// CSS样式
        /// </summary>
       [DisplayName("CSS样式")]
       public string ClassName
        {
            set;
            get;
        }

        /// <summary>
        /// 图标地址
        /// </summary>
       [DisplayName("图标地址")]
       public string ImageUrl
        {
            set;
            get;
        }

        /// <summary>
        /// 是否启用
        /// </summary>
       [DisplayName("是否启用")]
       public int? Enabled
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("是否启用")]
       public string Enabled_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 打开方式
        /// </summary>
       [DisplayName("打开方式")]
       public int? OpenType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("打开方式")]
       public string OpenType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 菜单类型
        /// </summary>
       [DisplayName("菜单类型")]
       public int? MenuType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("菜单类型")]
       public string MenuType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 链接地址
        /// </summary>
       [DisplayName("链接地址")]
       public string LinkUrl
        {
            set;
            get;
        }

        /// <summary>
        /// 备注
        /// </summary>
       [DisplayName("备注")]
       public string Tips
        {
            set;
            get;
        }

        /// <summary>
        /// 创建工具栏
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("创建工具栏")]
       public string Toolbar
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("创建工具栏")]
       public string Toolbar_ShowValue
        {
            set;
            get;
        }


        #endregion Model

        //(TableTree)
            [Column(notMap:true)]
            [JsonProperty("children")]
            public List<Menu> Children
            {
             get;
             set;
            }
            [Column(notMap: true)]
            public int ChildCount
            {
                get;
                set;
            }
            
            
            [Column(notMap: true)]
            [JsonProperty("state")]
            public string State
            {
                get
                {
                    return ChildCount > 0 ? "closed" : "open";
                }
            }
    }
}
