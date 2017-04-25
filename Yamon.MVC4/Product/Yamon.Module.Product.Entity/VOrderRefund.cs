
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 退单视图实体类
    /// </summary>
    [Serializable]
    [Table("View_OrderRefund")]
    public partial class VOrderRefund
    {
        public VOrderRefund()
        { }

        #region Model

        
        /// <summary>
        /// 退单流水号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("退单流水号")]
       public string RefundID
        {
            set;
            get;
        }

        /// <summary>
        /// 子订单编号
        /// </summary>
       [DisplayName("子订单编号")]
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
        /// 价格
        /// </summary>
       [DisplayName("价格")]
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
        /// 备注
        /// </summary>
       [DisplayName("备注")]
       public string Comment
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
        /// 订单时间
        /// </summary>
       [DisplayName("订单时间")]
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
        /// 模型
        /// </summary>
       [DisplayName("模型")]
       public string Models
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
        /// 会员编号
        /// </summary>
       [DisplayName("会员编号")]
       public int? MemberID
        {
            set;
            get;
        }

        /// <summary>
        /// 创建人
        /// </summary>
       [DisplayName("创建人")]
       public int? CreateUserID
        {
            set;
            get;
        }

        /// <summary>
        /// 订单状态
        /// </summary>
       [DisplayName("订单状态")]
       public int? OrderStatus
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
       public int? PayType
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
        /// 子订单状态
        /// </summary>
       [DisplayName("子订单状态")]
       public int? DetailStatus
        {
            set;
            get;
        }

        /// <summary>
        /// 退款金额
        /// </summary>
       [DisplayName("退款金额")]
       public double? RefundMoney
        {
            set;
            get;
        }

        /// <summary>
        /// 退款时间
        /// </summary>
       [DisplayName("退款时间")]
       public DateTime? RefundTime
        {
            set;
            get;
        }

        /// <summary>
        ///  退款操作人
        /// </summary>
       [DisplayName(" 退款操作人")]
       public int? RefundUserID
        {
            set;
            get;
        }

        /// <summary>
        /// 退款状态
        /// </summary>
       [DisplayName("退款状态")]
       public int? Status
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("退款状态")]
       public string Status_ShowValue
        {
            set;
            get;
        }


        #endregion Model

        //(View)
    }
}
