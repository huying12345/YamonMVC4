
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Member.Entity
{
    /// <summary>
    /// 会员实体类
    /// </summary>
    [Serializable]
    [Table("Member_MemberInfo")]
    public partial class MemberInfo
    {
        public MemberInfo()
        { }

        #region Model

        
        /// <summary>
        /// 编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("编号")]
       public int? MemberInfoId
        {
            set;
            get;
        }

        /// <summary>
        /// 会员编号
        /// </summary>
       [DisplayName("会员编号")]
       public string MemberNo
        {
            set;
            get;
        }

        /// <summary>
        /// 会员等级
        /// </summary>
       [DisplayName("会员等级")]
       public int? MemberGradeId
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("会员等级")]
       public string MemberGradeId_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 姓名
        /// </summary>
       [DisplayName("姓名")]
       public string MemberName
        {
            set;
            get;
        }

        /// <summary>
        /// 性别
        /// </summary>
       [DisplayName("性别")]
       public string Sex
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("性别")]
       public string Sex_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 密码
        /// </summary>
       [JsonIgnore]
       [DisplayName("密码")]
       public string MemberPassword
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
        /// 离开时间
        /// </summary>
       [DisplayName("离开时间")]
       public int? LeavingDealTimes
        {
            set;
            get;
        }

        /// <summary>
        /// 额外福利
        /// </summary>
       [DisplayName("额外福利")]
       public int? Bonus
        {
            set;
            get;
        }

        /// <summary>
        /// 电话
        /// </summary>
       [DisplayName("电话")]
       public string Tel
        {
            set;
            get;
        }

        /// <summary>
        /// 手机号
        /// </summary>
       [DisplayName("手机号")]
       public string MobileNo
        {
            set;
            get;
        }

        /// <summary>
        /// 邮箱
        /// </summary>
       [DisplayName("邮箱")]
       public string Email
        {
            set;
            get;
        }

        /// <summary>
        /// 证件类型
        /// </summary>
       [DisplayName("证件类型")]
       public string IdentityType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("证件类型")]
       public string IdentityType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 证件号码
        /// </summary>
       [DisplayName("证件号码")]
       public string IdentityNo
        {
            set;
            get;
        }

        /// <summary>
        /// QQ
        /// </summary>
       [DisplayName("QQ")]
       public string QQ
        {
            set;
            get;
        }

        /// <summary>
        /// 生日年份
        /// </summary>
       [DisplayName("生日年份")]
       public string BirthdayYear
        {
            set;
            get;
        }

        /// <summary>
        /// 生日月份
        /// </summary>
       [DisplayName("生日月份")]
       public string BirthdayMonthDay
        {
            set;
            get;
        }

        /// <summary>
        /// 生日类型
        /// </summary>
       [DisplayName("生日类型")]
       public string BirthdayType
        {
            set;
            get;
        }

        /// <summary>
        /// 住址
        /// </summary>
       [DisplayName("住址")]
       public string Address
        {
            set;
            get;
        }

        /// <summary>
        /// 公司单位
        /// </summary>
       [DisplayName("公司单位")]
       public string Company
        {
            set;
            get;
        }

        /// <summary>
        /// 注册日期
        /// </summary>
       [DisplayName("注册日期")]
       public DateTime? RegDate
        {
            set;
            get;
        }

        /// <summary>
        /// 有效日期
        /// </summary>
       [DisplayName("有效日期")]
       public DateTime? ValidityDate
        {
            set;
            get;
        }

        /// <summary>
        /// 会员状态
        /// </summary>
       [DisplayName("会员状态")]
       public string MemberState
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("会员状态")]
       public string MemberState_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 介绍人
        /// </summary>
       [DisplayName("介绍人")]
       public string RecommendMemberNo
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

        /// <summary>
        /// 备注
        /// </summary>
       [DisplayName("备注")]
       public string Comment
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
