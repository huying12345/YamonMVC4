
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 订单明细实体类
    /// </summary>
    [Serializable]
    [Table("Product_OrderDetail")]
    public partial class OrderDetail
    {
        public OrderDetail()
        { }

        #region Model

        
        /// <summary>
        /// ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("ID")]
       public string OrderDetailID
        {
            set;
            get;
        }

        /// <summary>
        /// 订单编号
        /// </summary>
       [DisplayName("订单编号")]
       public string OrderID
        {
            set;
            get;
        }

        /// <summary>
        /// 商品编号
        /// </summary>
       [DisplayName("商品编号")]
       public int? ProductID
        {
            set;
            get;
        }

        /// <summary>
        /// 商品条码
        /// </summary>
       [DisplayName("商品条码")]
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
       public double? TotalMoney
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
        /// 备用字段1
        /// </summary>
       [DisplayName("备用字段1")]
       public string BackField1
        {
            set;
            get;
        }

        /// <summary>
        /// 备用字段2
        /// </summary>
       [DisplayName("备用字段2")]
       public string BackField2
        {
            set;
            get;
        }

        /// <summary>
        /// 状态
        /// </summary>
       [DisplayName("状态")]
       public int? Status
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("状态")]
       public string Status_ShowValue
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
