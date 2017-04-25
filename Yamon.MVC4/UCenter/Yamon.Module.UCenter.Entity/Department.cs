
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.UCenter.Entity
{
    /// <summary>
    /// 部门模型实体类
    /// </summary>
    [Serializable]
    [Table("UC_Department")]
    public partial class Department
    {
        public Department()
        { }

        #region Model

        
        /// <summary>
        /// 部门ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("部门ID")]
       public int? DepartmentID
        {
            set;
            get;
        }

        /// <summary>
        /// 部门名称
        /// </summary>
       [DisplayName("部门名称")]
       public string DepartmentName
        {
            set;
            get;
        }

        /// <summary>
        /// 上级部门
        /// </summary>
       [DisplayName("上级部门")]
       public int? ParentID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("上级部门")]
       public string ParentID_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 排序ID
        /// </summary>
       [DisplayName("排序ID")]
       public int? OrderID
        {
            set;
            get;
        }

        /// <summary>
        /// 联系人
        /// </summary>
       [DisplayName("联系人")]
       public string ContactName
        {
            set;
            get;
        }

        /// <summary>
        /// 成员数量
        /// </summary>
       [DisplayName("成员数量")]
       public int? EmployeeNum
        {
            set;
            get;
        }

        /// <summary>
        /// 联系方式
        /// </summary>
       [DisplayName("联系方式")]
       public string Phone
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

        //(TableTree)
            [Column(notMap:true)]
            [JsonProperty("children")]
            public List<Department> Children
            {
             get;
             set;
            }
            [Column(notMap: true)]
            public int ChildCount
            {
                get;
                set;
            }
            
            
            [Column(notMap: true)]
            [JsonProperty("state")]
            public string State
            {
                get
                {
                    return ChildCount > 0 ? "closed" : "open";
                }
            }
    }
}
