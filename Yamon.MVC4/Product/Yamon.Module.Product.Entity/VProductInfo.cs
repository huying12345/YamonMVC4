
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 商品信息视图实体类
    /// </summary>
    [Serializable]
    [Table("View_Product_ProductInfo")]
    public partial class VProductInfo
    {
        public VProductInfo()
        { }

        #region Model

        
        /// <summary>
        /// 商品信息ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("商品信息ID")]
       public int? ProductInfoId
        {
            set;
            get;
        }

        /// <summary>
        /// 商品类型ID
        /// </summary>
       [DisplayName("商品类型ID")]
       public int? ProductTypeId
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
       public decimal? SaleDiscountPercent
        {
            set;
            get;
        }

        /// <summary>
        /// 最低折扣率
        /// </summary>
       [DisplayName("最低折扣率")]
       public decimal? MinDiscountPercent
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
        /// 修改时间
        /// </summary>
       [DisplayName("修改时间")]
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
        /// 类型名称
        /// </summary>
       [DisplayName("类型名称")]
       public string TypeName
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
        /// 上级ID
        /// </summary>
       [DisplayName("上级ID")]
       public int? ParentID
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
