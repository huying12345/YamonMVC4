
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 预约实体类
    /// </summary>
    [Serializable]
    [Table("Product_ProductBook")]
    public partial class ProductBook
    {
        public ProductBook()
        { }

        #region Model

        
        /// <summary>
        /// 预约编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("预约编号")]
       public string ProductBookID
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
        /// 会员编号
        /// </summary>
       [DisplayName("会员编号")]
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
        /// 创建人
        /// </summary>
       [DisplayName("创建人")]
       public int? CreateUserID
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


        #endregion Model

        //(Table)
    }
}
