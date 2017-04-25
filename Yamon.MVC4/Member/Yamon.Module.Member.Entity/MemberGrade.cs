
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Member.Entity
{
    /// <summary>
    /// 会员等级实体类
    /// </summary>
    [Serializable]
    [Table("Member_MemberGrade")]
    public partial class MemberGrade
    {
        public MemberGrade()
        { }

        #region Model

        
        /// <summary>
        /// 编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("编号")]
       public int? MemberGradeId
        {
            set;
            get;
        }

        /// <summary>
        /// 会员等级
        /// </summary>
       [DisplayName("会员等级")]
       public string GradeName
        {
            set;
            get;
        }

        /// <summary>
        /// 是否默认
        /// </summary>
       [DisplayName("是否默认")]
       public int? IsDefault
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("是否默认")]
       public string IsDefault_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 折扣率
        /// </summary>
       [DisplayName("折扣率")]
       public decimal? DiscountPercent
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
        /// 创建时间
        /// </summary>
       [DisplayName("创建时间")]
       public DateTime? CreateTime
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
