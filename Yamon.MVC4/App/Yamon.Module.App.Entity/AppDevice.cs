
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.App.Entity
{
    /// <summary>
    /// 设备模型实体类
    /// </summary>
    [Serializable]
    [Table("App_Devices")]
    public partial class AppDevice
    {
        public AppDevice()
        { }

        #region Model

        
        /// <summary>
        /// 设备编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("设备编号")]
       public string DeviceID
        {
            set;
            get;
        }

        /// <summary>
        /// 备注名
        /// </summary>
       [DisplayName("备注名")]
       public string UserName
        {
            set;
            get;
        }

        /// <summary>
        /// App版本
        /// </summary>
       [DisplayName("App版本")]
       public string Version
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

        /// <summary>
        /// 系统版本
        /// </summary>
       [DisplayName("系统版本")]
       public string SystemVersion
        {
            set;
            get;
        }

        /// <summary>
        /// 设备名称
        /// </summary>
       [DisplayName("设备名称")]
       public string DeviceName
        {
            set;
            get;
        }

        /// <summary>
        /// 设备品牌
        /// </summary>
       [DisplayName("设备品牌")]
       public string DeviceModel
        {
            set;
            get;
        }

        /// <summary>
        /// 经度
        /// </summary>
       [DisplayName("经度")]
       public double? Longitude
        {
            set;
            get;
        }

        /// <summary>
        /// 纬度
        /// </summary>
       [DisplayName("纬度")]
       public double? Latitude
        {
            set;
            get;
        }

        /// <summary>
        /// 省份
        /// </summary>
       [DisplayName("省份")]
       public string Province
        {
            set;
            get;
        }

        /// <summary>
        /// 城市
        /// </summary>
       [DisplayName("城市")]
       public string City
        {
            set;
            get;
        }

        /// <summary>
        /// 地址
        /// </summary>
       [DisplayName("地址")]
       public string Address
        {
            set;
            get;
        }

        /// <summary>
        /// 屏幕宽度
        /// </summary>
       [DisplayName("屏幕宽度")]
       public int? ScreenWidth
        {
            set;
            get;
        }

        /// <summary>
        /// 屏幕高度
        /// </summary>
       [DisplayName("屏幕高度")]
       public int? ScreenHeight
        {
            set;
            get;
        }

        /// <summary>
        /// 网络状态
        /// </summary>
       [DisplayName("网络状态")]
       public string NetworkStatus
        {
            set;
            get;
        }

        /// <summary>
        /// 安装时间
        /// </summary>
       [DisplayName("安装时间")]
       public DateTime? InstallTime
        {
            set;
            get;
        }

        /// <summary>
        /// 最近启动时间
        /// </summary>
       [DisplayName("最近启动时间")]
       public DateTime? LastStartTime
        {
            set;
            get;
        }

        /// <summary>
        /// 启动次数
        /// </summary>
       [DisplayName("启动次数")]
       public int? StartNums
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
