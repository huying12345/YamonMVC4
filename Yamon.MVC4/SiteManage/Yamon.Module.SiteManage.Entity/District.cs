
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.SiteManage.Entity
{
    /// <summary>
    /// 区域实体类
    /// </summary>
    [Serializable]
    [Table("SiteManage_District")]
    public partial class District
    {
        public District()
        { }

        #region Model

        
        /// <summary>
        /// ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("ID")]
       public int? ID
        {
            set;
            get;
        }

        /// <summary>
        /// 名称
        /// </summary>
       [DisplayName("名称")]
       public string Name
        {
            set;
            get;
        }

        /// <summary>
        /// 级别
        /// </summary>
       [DisplayName("级别")]
       public int? Level
        {
            set;
            get;
        }

        /// <summary>
        /// 上级区域
        /// </summary>
       [DisplayName("上级区域")]
       public int? ParentID
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


        #endregion Model

        //(TableTree)
            [Column(notMap:true)]
            [JsonProperty("children")]
            public List<District> Children
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
