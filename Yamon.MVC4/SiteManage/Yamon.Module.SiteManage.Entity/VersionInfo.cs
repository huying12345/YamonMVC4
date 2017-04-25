
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.SiteManage.Entity
{
    /// <summary>
    /// 版本记录表实体类
    /// </summary>
    [Serializable]
    [Table("SiteManage_Version")]
    public partial class VersionInfo
    {
        public VersionInfo()
        { }

        #region Model

        
        /// <summary>
        /// 版本ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("版本ID")]
       public int? VersionID
        {
            set;
            get;
        }

        /// <summary>
        /// 主版本号
        /// </summary>
       [DisplayName("主版本号")]
       public int? Major
        {
            set;
            get;
        }

        /// <summary>
        /// 次版本号
        /// </summary>
       [DisplayName("次版本号")]
       public int? Minor
        {
            set;
            get;
        }

        /// <summary>
        /// 内部版本号
        /// </summary>
       [DisplayName("内部版本号")]
       public int? Build
        {
            set;
            get;
        }

        /// <summary>
        /// 修订版本号
        /// </summary>
       [DisplayName("修订版本号")]
       public int? Revision
        {
            set;
            get;
        }

        /// <summary>
        /// 创建日期
        /// </summary>
       [DisplayName("创建日期")]
       public DateTime? CreatedDate
        {
            set;
            get;
        }

        /// <summary>
        /// 更新日志
        /// </summary>
       [DisplayName("更新日志")]
       public string ChangeLog
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
