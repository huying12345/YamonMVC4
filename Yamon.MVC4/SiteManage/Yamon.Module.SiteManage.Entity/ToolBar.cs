
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.SiteManage.Entity
{
    /// <summary>
    /// 工具栏模型实体类
    /// </summary>
    [Serializable]
    [Table("SiteManage_MenuToolBar")]
    public partial class ToolBar
    {
        public ToolBar()
        { }

        #region Model

        
        /// <summary>
        /// 编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("编号")]
       public string ToolBarID
        {
            set;
            get;
        }

        /// <summary>
        /// 工具栏名称
        /// </summary>
       [DisplayName("工具栏名称")]
       public string ToolBarName
        {
            set;
            get;
        }

        /// <summary>
        /// 所属菜单
        /// </summary>
       [DisplayName("所属菜单")]
       public string MenuID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("所属菜单")]
       public string MenuID_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 排序号
        /// </summary>
       [DisplayName("排序号")]
       public short? OrderID
        {
            set;
            get;
        }

        /// <summary>
        /// 工具栏类型
        /// </summary>
       [DisplayName("工具栏类型")]
       public string ToolbarType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("工具栏类型")]
       public string ToolbarType_ShowValue
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
        /// 样式名称
        /// </summary>
       [DisplayName("样式名称")]
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
        /// 事件代码
        /// </summary>
       [DisplayName("事件代码")]
       public string OnClick
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


        #endregion Model

        //(Table)
    }
}
