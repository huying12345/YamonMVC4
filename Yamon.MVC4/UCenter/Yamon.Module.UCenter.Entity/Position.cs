
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.UCenter.Entity
{
    /// <summary>
    /// 岗位模型实体类
    /// </summary>
    [Serializable]
    [Table("UC_Position")]
    public partial class Position
    {
        public Position()
        { }

        #region Model

        
        /// <summary>
        /// 岗位编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("岗位编号")]
       public int? PositionID
        {
            set;
            get;
        }

        /// <summary>
        /// 所属部门
        /// </summary>
       [DisplayName("所属部门")]
       public int? DepartmentID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("所属部门")]
       public string DepartmentID_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 岗位名称
        /// </summary>
       [DisplayName("岗位名称")]
       public string PositionName
        {
            set;
            get;
        }

        /// <summary>
        /// 是否为部门主管
        /// </summary>
       [DisplayName("是否为部门主管")]
       public int? IsManager
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("是否为部门主管")]
       public string IsManager_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 岗位职责
        /// </summary>
       [DisplayName("岗位职责")]
       public string Responsibility
        {
            set;
            get;
        }

        /// <summary>
        /// 备注
        /// </summary>
       [DisplayName("备注")]
       public string Tips
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
