
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 商品类型实体类
    /// </summary>
    [Serializable]
    [Table("Product_ProductType")]
    public partial class ProductType
    {
        public ProductType()
        { }

        #region Model

        
        /// <summary>
        /// ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("ID")]
       public int? ProductTypeId
        {
            set;
            get;
        }

        /// <summary>
        /// 名称
        /// </summary>
       [DisplayName("名称")]
       public string TypeName
        {
            set;
            get;
        }

        /// <summary>
        /// 排序
        /// </summary>
       [DisplayName("排序")]
       public int? OrderID
        {
            set;
            get;
        }

        /// <summary>
        /// 上级类别
        /// </summary>
       [DisplayName("上级类别")]
       public int? ParentID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("上级类别")]
       public string ParentID_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 模型
        /// </summary>
       [DisplayName("模型")]
       public string Models
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("模型")]
       public string Models_ShowValue
        {
            set;
            get;
        }


        #endregion Model

        //(TableTree)
            [Column(notMap:true)]
            [JsonProperty("children")]
            public List<ProductType> Children
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
