
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 商品模块配置实体类
    /// </summary>
    [Serializable]
    [Table("SiteManage_Config")]
    public partial class ProductConfig
    {
        public ProductConfig()
        { }

        #region Model

        
        /// <summary>
        /// 主键
        /// </summary>
       [DisplayName("主键")]
       public string ConfigKey
        {
            set;
            get;
        }

        /// <summary>
        /// 值
        /// </summary>
       [DisplayName("值")]
       public string ConfigValue
        {
            set;
            get;
        }

        /// <summary>
        /// 模块
        /// </summary>
       [DisplayName("模块")]
       public string Module
        {
            set;
            get;
        }

        /// <summary>
        /// 每天限制人数
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("每天限制人数")]
       public string VisitNum
        {
            set;
            get;
        }

        /// <summary>
        /// 是否开启打折功能
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("是否开启打折功能")]
       public string Menber
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("是否开启打折功能")]
       public string Menber_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 商品退单密码
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("商品退单密码")]
       public string GoodPassword
        {
            set;
            get;
        }

        /// <summary>
        /// 门票退单密码
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("门票退单密码")]
       public string TicketPassword
        {
            set;
            get;
        }

        /// <summary>
        /// 餐饮退单密码
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("餐饮退单密码")]
       public string FoodPassword
        {
            set;
            get;
        }

        /// <summary>
        /// 游乐场退单密码
        /// </summary>
       [Column(notMap:true)]
       [DisplayName("游乐场退单密码")]
       public string PlaygroudPassword
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
