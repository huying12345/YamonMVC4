
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 预约信息视图实体类
    /// </summary>
    [Serializable]
    [Table("View_Product_ProductBookDetail")]
    public partial class VProductBookDetail
    {
        public VProductBookDetail()
        { }

        #region Model

        
        /// <summary>
        /// 预约编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("预约编号")]
       public string ProductBookDetailID
        {
            set;
            get;
        }

        /// <summary>
        /// 商品类型
        /// </summary>
       [DisplayName("商品类型")]
       public string TypeName
        {
            set;
            get;
        }

        /// <summary>
        /// 商品信息id
        /// </summary>
       [DisplayName("商品信息id")]
       public int? ProductInfoId
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
        /// 预约订单编号
        /// </summary>
       [DisplayName("预约订单编号")]
       public string ProductBookID
        {
            set;
            get;
        }

        /// <summary>
        /// ProductID
        /// </summary>
       [DisplayName("ProductID")]
       public int? ProductID
        {
            set;
            get;
        }

        /// <summary>
        /// ProductNo
        /// </summary>
       [DisplayName("ProductNo")]
       public string ProductNo
        {
            set;
            get;
        }

        /// <summary>
        /// 原价
        /// </summary>
       [DisplayName("原价")]
       public double? Price
        {
            set;
            get;
        }

        /// <summary>
        /// 数量
        /// </summary>
       [DisplayName("数量")]
       public double? Num
        {
            set;
            get;
        }

        /// <summary>
        /// 销售价格
        /// </summary>
       [DisplayName("销售价格")]
       public double? SalePrice
        {
            set;
            get;
        }

        /// <summary>
        /// 总金额
        /// </summary>
       [DisplayName("总金额")]
       public double? Money
        {
            set;
            get;
        }

        /// <summary>
        /// 预约时间
        /// </summary>
       [DisplayName("预约时间")]
       public DateTime? MakeTime
        {
            set;
            get;
        }

        /// <summary>
        /// BackField2
        /// </summary>
       [DisplayName("BackField2")]
       public string BackField2
        {
            set;
            get;
        }

        /// <summary>
        /// PurchasePrice
        /// </summary>
       [DisplayName("PurchasePrice")]
       public float? PurchasePrice
        {
            set;
            get;
        }

        /// <summary>
        /// StockNum
        /// </summary>
       [DisplayName("StockNum")]
       public int? StockNum
        {
            set;
            get;
        }

        /// <summary>
        /// ExchangeNeedBonus
        /// </summary>
       [DisplayName("ExchangeNeedBonus")]
       public int? ExchangeNeedBonus
        {
            set;
            get;
        }

        /// <summary>
        /// SaleDiscountPercent
        /// </summary>
       [DisplayName("SaleDiscountPercent")]
       public decimal? SaleDiscountPercent
        {
            set;
            get;
        }

        /// <summary>
        /// MinDiscountPercent
        /// </summary>
       [DisplayName("MinDiscountPercent")]
       public decimal? MinDiscountPercent
        {
            set;
            get;
        }

        /// <summary>
        /// BackField1
        /// </summary>
       [DisplayName("BackField1")]
       public string BackField1
        {
            set;
            get;
        }

        /// <summary>
        /// Comment
        /// </summary>
       [DisplayName("Comment")]
       public string Comment
        {
            set;
            get;
        }

        /// <summary>
        /// MemberID
        /// </summary>
       [DisplayName("MemberID")]
       public int? MemberID
        {
            set;
            get;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
       [DisplayName("创建时间")]
       public int? CreateUserID
        {
            set;
            get;
        }

        /// <summary>
        /// TotalMoney
        /// </summary>
       [DisplayName("TotalMoney")]
       public double? TotalMoney
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
