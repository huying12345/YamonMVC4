
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 订单明细视图实体类
    /// </summary>
    [Serializable]
    [Table("View_Product_OrderDetail")]
    public partial class VOrderDetail
    {
        public VOrderDetail()
        { }

        #region Model

        
        /// <summary>
        /// 订单明细ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("订单明细ID")]
       public string OrderDetailID
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

        /// <summary>
        /// 支付状态
        /// </summary>
       [DisplayName("支付状态")]
       public int? PayStatus
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("支付状态")]
       public string PayStatus_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 支付类型
        /// </summary>
       [DisplayName("支付类型")]
       public string PayType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("支付类型")]
       public string PayType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 是否退单
        /// </summary>
       [DisplayName("是否退单")]
       public string DetailStatus
        {
            set;
            get;
        }

        /// <summary>
        /// 订单信息ID
        /// </summary>
       [DisplayName("订单信息ID")]
       public string OrderID
        {
            set;
            get;
        }

        /// <summary>
        /// 商品ID
        /// </summary>
       [DisplayName("商品ID")]
       public int? ProductID
        {
            set;
            get;
        }

        /// <summary>
        /// 商品编号
        /// </summary>
       [DisplayName("商品编号")]
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
        /// 出售价格
        /// </summary>
       [DisplayName("出售价格")]
       public double? SalePrice
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
        /// 商品名称
        /// </summary>
       [DisplayName("商品名称")]
       public string ProductName
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
        /// 总金额
        /// </summary>
       [DisplayName("总金额")]
       public double? TotalMoney
        {
            set;
            get;
        }

        /// <summary>
        /// 销售时间
        /// </summary>
       [DisplayName("销售时间")]
       public DateTime? CreateTime
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
        /// 客户名称
        /// </summary>
       [DisplayName("客户名称")]
       public int? MemberID
        {
            set;
            get;
        }

        /// <summary>
        /// 销售员
        /// </summary>
       [DisplayName("销售员")]
       public int? CreateUserID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("销售员")]
       public string CreateUserID_ShowValue
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
