
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 订单实体类
    /// </summary>
    [Serializable]
    [Table("Product_OrderInfo")]
    public partial class OrderInfo
    {
        public OrderInfo()
        { }

        #region Model

        
        /// <summary>
        /// 订单编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("订单编号")]
       public string OrderID
        {
            set;
            get;
        }

        /// <summary>
        /// 会员
        /// </summary>
       [DisplayName("会员")]
       public int? MemberID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("会员")]
       public string MemberID_ShowValue
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
        /// 创建人
        /// </summary>
       [DisplayName("创建人")]
       public int? CreateUserID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("创建人")]
       public string CreateUserID_ShowValue
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
        /// 更新时间
        /// </summary>
       [DisplayName("更新时间")]
       public DateTime? UpdateTime
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
        /// 模型
        /// </summary>
       [DisplayName("模型")]
       public string Models
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


        #endregion Model

        //(Table)
    }
}
