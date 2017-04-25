
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.App.Entity
{
    /// <summary>
    /// 版本模型实体类
    /// </summary>
    [Serializable]
    [Table("App_Versions")]
    public partial class AppVersion
    {
        public AppVersion()
        { }

        #region Model

        
        /// <summary>
        /// 版本
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("版本")]
       public int? VersionID
        {
            set;
            get;
        }

        /// <summary>
        /// 版本类型
        /// </summary>
       [DisplayName("版本类型")]
       public int? VersionType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("版本类型")]
       public string VersionType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 设备类型
        /// </summary>
       [DisplayName("设备类型")]
       public string DeviceType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("设备类型")]
       public string DeviceType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 版本号
        /// </summary>
       [DisplayName("版本号")]
       public int? VersionCode
        {
            set;
            get;
        }

        /// <summary>
        /// 版本号(XYZ)
        /// </summary>
       [DisplayName("版本号(XYZ)")]
       public string VersionName
        {
            set;
            get;
        }

        /// <summary>
        /// 更新文件大小
        /// </summary>
       [DisplayName("更新文件大小")]
       public string FileSize
        {
            set;
            get;
        }

        /// <summary>
        /// 更新路径
        /// </summary>
       [DisplayName("更新路径")]
       public string UpdatePath
        {
            set;
            get;
        }

        /// <summary>
        /// 更新时间
        /// </summary>
       [DisplayName("更新时间")]
       public DateTime? ReleaseTime
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
