
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Product.Entity
{
    /// <summary>
    /// 验票记录表实体类
    /// </summary>
    [Serializable]
    [Table("Product_TicketVisitLog")]
    public partial class TicketVisitLog
    {
        public TicketVisitLog()
        { }

        #region Model

        
        /// <summary>
        /// 日志编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("日志编号")]
       public int? LogID
        {
            set;
            get;
        }

        /// <summary>
        /// 票号
        /// </summary>
       [DisplayName("票号")]
       public string TicketID
        {
            set;
            get;
        }

        /// <summary>
        /// 日志类型
        /// </summary>
       [DisplayName("日志类型")]
       public string LogType
        {
            set;
            get;
        }

        /// <summary>
        /// 扫描设备
        /// </summary>
       [DisplayName("扫描设备")]
       public string DeviceID
        {
            set;
            get;
        }

        /// <summary>
        /// 是否成功
        /// </summary>
       [DisplayName("是否成功")]
       public int? IsSuccess
        {
            set;
            get;
        }

        /// <summary>
        /// 进入时间
        /// </summary>
       [DisplayName("进入时间")]
       public DateTime? VisitTime
        {
            set;
            get;
        }

        /// <summary>
        /// CheckStationID
        /// </summary>
       [DisplayName("CheckStationID")]
       public int? CheckStationID
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
