
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.SiteManage.Entity
{
    /// <summary>
    /// 字典类型实体类
    /// </summary>
    [Serializable]
    [Table("SiteManage_DictType")]
    public partial class DictType
    {
        public DictType()
        { }

        #region Model

        
        /// <summary>
        /// 字典类型编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("字典类型编号")]
       public string DictTypeID
        {
            set;
            get;
        }

        /// <summary>
        /// 类型名称
        /// </summary>
       [DisplayName("类型名称")]
       public string DictTypeName
        {
            set;
            get;
        }

        /// <summary>
        /// 上级类型
        /// </summary>
       [DisplayName("上级类型")]
       public string ParentID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("上级类型")]
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
        /// 备注
        /// </summary>
       [DisplayName("备注")]
       public string Remark
        {
            set;
            get;
        }

        /// <summary>
        /// 删除标识
        /// </summary>
       [DisplayName("删除标识")]
       public int? IsDelete
        {
            set;
            get;
        }

        /// <summary>
        /// 名称与值相同
        /// </summary>
       [DisplayName("名称与值相同")]
       public int? IsSingleValue
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("名称与值相同")]
       public string IsSingleValue_ShowValue
        {
            set;
            get;
        }


        #endregion Model

        //(TableTree)
            [Column(notMap:true)]
            [JsonProperty("children")]
            public List<DictType> Children
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
