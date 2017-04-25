
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 商品实体类
    /// </summary>
    [Serializable]
    [Table("Product_ProductInfo")]
    public partial class ProductInfo
    {
        public ProductInfo()
        { }

        #region Model

        
        /// <summary>
        /// 商品ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("商品ID")]
       public int? ProductInfoId
        {
            set;
            get;
        }

        /// <summary>
        /// 商品类型
        /// </summary>
       [DisplayName("商品类型")]
       public int? ProductTypeId
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("商品类型")]
       public string ProductTypeId_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 商品编号
        /// </summary>
       [DisplayName("商品编号")]
       public string ProductInfoNo
        {
            set;
            get;
        }

        /// <summary>
        /// 商品名称
        /// </summary>
       [DisplayName("商品名称")]
       public string ProductName
        {
            set;
            get;
        }

        /// <summary>
        /// 销售价格
        /// </summary>
       [DisplayName("销售价格")]
       public float? SalePrice
        {
            set;
            get;
        }

        /// <summary>
        /// 进货价格
        /// </summary>
       [DisplayName("进货价格")]
       public float? PurchasePrice
        {
            set;
            get;
        }

        /// <summary>
        /// 商品库存
        /// </summary>
       [DisplayName("商品库存")]
       public int? StockNum
        {
            set;
            get;
        }

        /// <summary>
        /// 兑换该商品积分
        /// </summary>
       [DisplayName("兑换该商品积分")]
       public int? ExchangeNeedBonus
        {
            set;
            get;
        }

        /// <summary>
        /// 出售折扣率
        /// </summary>
       [DisplayName("出售折扣率")]
       public double? SaleDiscountPercent
        {
            set;
            get;
        }

        /// <summary>
        /// 最低折扣率
        /// </summary>
       [DisplayName("最低折扣率")]
       public double? MinDiscountPercent
        {
            set;
            get;
        }

        /// <summary>
        /// 备注
        /// </summary>
       [DisplayName("备注")]
       public string Comment
        {
            set;
            get;
        }

        /// <summary>
        /// 更新时间
        /// </summary>
       [DisplayName("更新时间")]
       public DateTime? UpdateTime
        {
            set;
            get;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
       [DisplayName("创建时间")]
       public DateTime? CreateTime
        {
            set;
            get;
        }

        /// <summary>
        /// 商品图片
        /// </summary>
       [DisplayName("商品图片")]
       public string ImageUrl
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
