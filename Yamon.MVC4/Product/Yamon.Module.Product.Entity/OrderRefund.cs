
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 订单退票实体类
    /// </summary>
    [Serializable]
    [Table("Product_OrderRefund")]
    public partial class OrderRefund
    {
        public OrderRefund()
        { }

        #region Model

        
        /// <summary>
        /// 退单编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("退单编号")]
       public string RefundID
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
        /// 订单明细编号
        /// </summary>
       [DisplayName("订单明细编号")]
       public string OrderDetailID
        {
            set;
            get;
        }

        /// <summary>
        /// 退单金额
        /// </summary>
       [DisplayName("退单金额")]
       public double? RefundMoney
        {
            set;
            get;
        }

        /// <summary>
        /// 退单时间
        /// </summary>
       [DisplayName("退单时间")]
       public DateTime? RefundTime
        {
            set;
            get;
        }

        /// <summary>
        /// 经办人
        /// </summary>
       [DisplayName("经办人")]
       public int? RefundUserID
        {
            set;
            get;
        }

        /// <summary>
        /// 审核状态
        /// </summary>
       [DisplayName("审核状态")]
       public int? Status
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("审核状态")]
       public string Status_ShowValue
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
