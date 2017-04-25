
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 预约视图实体类
    /// </summary>
    [Serializable]
    [Table("View_Product_ProductBook")]
    public partial class VProductBook
    {
        public VProductBook()
        { }

        #region Model

        
        /// <summary>
        /// MemberInfoId
        /// </summary>
       [DisplayName("MemberInfoId")]
       public int? MemberInfoId
        {
            set;
            get;
        }

        /// <summary>
        /// CreateTime
        /// </summary>
       [DisplayName("CreateTime")]
       public DateTime? CreateTime
        {
            set;
            get;
        }

        /// <summary>
        /// CreateUserID
        /// </summary>
       [DisplayName("CreateUserID")]
       public int? CreateUserID
        {
            set;
            get;
        }

        /// <summary>
        /// 预约时间
        /// </summary>
       [DisplayName("预约时间")]
       public string MakeTime
        {
            set;
            get;
        }

        /// <summary>
        /// MemberNo
        /// </summary>
       [DisplayName("MemberNo")]
       public string MemberNo
        {
            set;
            get;
        }

        /// <summary>
        /// MobileNo
        /// </summary>
       [DisplayName("MobileNo")]
       public string MobileNo
        {
            set;
            get;
        }

        /// <summary>
        /// MemberName
        /// </summary>
       [DisplayName("MemberName")]
       public string MemberName
        {
            set;
            get;
        }

        /// <summary>
        /// MemberGradeId
        /// </summary>
       [DisplayName("MemberGradeId")]
       public int? MemberGradeId
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
        /// Models
        /// </summary>
       [DisplayName("Models")]
       public string Models
        {
            set;
            get;
        }

        /// <summary>
        /// ProductBookID
        /// </summary>
       [DisplayName("ProductBookID")]
       public string ProductBookID
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
