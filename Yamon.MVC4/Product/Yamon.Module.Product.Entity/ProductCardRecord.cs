
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 体验卡交易记录实体类
    /// </summary>
    [Serializable]
    [Table("Product_CardRecord")]
    public partial class ProductCardRecord
    {
        public ProductCardRecord()
        { }

        #region Model

        
        /// <summary>
        /// ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("ID")]
       public int? RecordID
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

        /// <summary>
        /// 交易类型
        /// </summary>
       [DisplayName("交易类型")]
       public string TradeType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("交易类型")]
       public string TradeType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 卡号
        /// </summary>
       [DisplayName("卡号")]
       public int? CardID
        {
            set;
            get;
        }

        /// <summary>
        /// 厂商代码
        /// </summary>
       [DisplayName("厂商代码")]
       public string CardSN
        {
            set;
            get;
        }

        /// <summary>
        /// 卡序号
        /// </summary>
       [DisplayName("卡序号")]
       public string CardNo
        {
            set;
            get;
        }

        /// <summary>
        /// 经办人
        /// </summary>
       [DisplayName("经办人")]
       public int? UserID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("经办人")]
       public string UserID_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 交易时间
        /// </summary>
       [DisplayName("交易时间")]
       public DateTime? TradeTime
        {
            set;
            get;
        }

        /// <summary>
        /// 金额
        /// </summary>
       [DisplayName("金额")]
       public float? Money
        {
            set;
            get;
        }

        /// <summary>
        /// 备注
        /// </summary>
       [DisplayName("备注")]
       public string Remarks
        {
            set;
            get;
        }

        /// <summary>
        /// 次数
        /// </summary>
       [DisplayName("次数")]
       public int? Times
        {
            set;
            get;
        }

        /// <summary>
        /// 写卡成功
        /// </summary>
       [DisplayName("写卡成功")]
       public int? IsCharge
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
