
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 商品折扣实体类
    /// </summary>
    [Serializable]
    [Table("Product_Discount")]
    public partial class ProductDiscount
    {
        public ProductDiscount()
        { }

        #region Model

        
        /// <summary>
        /// 折扣编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("折扣编号")]
       public int? DiscountID
        {
            set;
            get;
        }

        /// <summary>
        /// 折扣名称
        /// </summary>
       [DisplayName("折扣名称")]
       public string DiscountName
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
       [Column(notMap:true)]
       [DisplayName("是否默认")]
       public string IsDefault_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 折扣率
        /// </summary>
       [DisplayName("折扣率")]
       public decimal? DiscountPercent
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
        /// 模型
        /// </summary>
       [DisplayName("模型")]
       public string Models
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
