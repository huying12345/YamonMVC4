
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.SiteManage.Entity
{
    /// <summary>
    /// 数据字典实体类
    /// </summary>
    [Serializable]
    [Table("SiteManage_DictData")]
    public partial class DictData
    {
        public DictData()
        { }

        #region Model

        
        /// <summary>
        /// ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("ID")]
       public int? ID
        {
            set;
            get;
        }

        /// <summary>
        /// 所属类型
        /// </summary>
       [DisplayName("所属类型")]
       public string DictTypeID
        {
            set;
            get;
        }

        /// <summary>
        /// 名称
        /// </summary>
       [DisplayName("名称")]
       public string Name
        {
            set;
            get;
        }

        /// <summary>
        /// 值
        /// </summary>
       [DisplayName("值")]
       public string Value
        {
            set;
            get;
        }

        /// <summary>
        /// 排序号
        /// </summary>
       [DisplayName("排序号")]
       public int? OrderID
        {
            set;
            get;
        }

        /// <summary>
        /// 备注
        /// </summary>
       [DisplayName("备注")]
       public string Remark
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
