
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    ///  体验卡实体类
    /// </summary>
    [Serializable]
    [Table("Product_Card")]
    public partial class ProductCard
    {
        public ProductCard()
        { }

        #region Model

        
        /// <summary>
        /// ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("ID")]
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
        /// 卡类型
        /// </summary>
       [DisplayName("卡类型")]
       public string CardType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("卡类型")]
       public string CardType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 有效期开始
        /// </summary>
       [DisplayName("有效期开始")]
       public DateTime? ValidityStart
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("有效期开始")]
       public string ValidityStart_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 有效期结束
        /// </summary>
       [DisplayName("有效期结束")]
       public DateTime? ValidityEnd
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("有效期结束")]
       public string ValidityEnd_ShowValue
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
        /// 状态
        /// </summary>
       [DisplayName("状态")]
       public string Status
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
        /// 余额
        /// </summary>
       [DisplayName("余额")]
       public float? Balance
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
        /// 创建时间
        /// </summary>
       [DisplayName("创建时间")]
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
        /// 经办人
        /// </summary>
       [DisplayName("经办人")]
       public int? CreateUserID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("经办人")]
       public string CreateUserID_ShowValue
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
