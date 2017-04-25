
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.SiteManage.Entity
{
    /// <summary>
    /// 接口实体类
    /// </summary>
    [Serializable]
    [Table("SiteManage_API")]
    public partial class API
    {
        public API()
        { }

        #region Model

        
        /// <summary>
        /// 接口编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("接口编号")]
       public string APIID
        {
            set;
            get;
        }

        /// <summary>
        /// 接口名称
        /// </summary>
       [DisplayName("接口名称")]
       public string APIName
        {
            set;
            get;
        }

        /// <summary>
        /// 上级类型
        /// </summary>
       [DisplayName("上级类型")]
       public string ParentID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("上级类型")]
       public string ParentID_ShowValue
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
        /// 类型
        /// </summary>
       [DisplayName("类型")]
       public int? APIType
        {
            set;
            get;
        }

        /// <summary>
        /// 接口地址
        /// </summary>
       [DisplayName("接口地址")]
       public string Url
        {
            set;
            get;
        }

        /// <summary>
        /// 需要登录
        /// </summary>
       [DisplayName("需要登录")]
       public int? NeedUserLogin
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("需要登录")]
       public string NeedUserLogin_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 接口描述
        /// </summary>
       [DisplayName("接口描述")]
       public string Remark
        {
            set;
            get;
        }

        /// <summary>
        /// 请求方式
        /// </summary>
       [DisplayName("请求方式")]
       public string RequestType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("请求方式")]
       public string RequestType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 数据类型
        /// </summary>
       [DisplayName("数据类型")]
       public string DataType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("数据类型")]
       public string DataType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 请求参数
        /// </summary>
       [DisplayName("请求参数")]
       public string RequestParam
        {
            set;
            get;
        }

        /// <summary>
        /// 返回参数
        /// </summary>
       [DisplayName("返回参数")]
       public string ResponseParam
        {
            set;
            get;
        }

        /// <summary>
        /// 错误码
        /// </summary>
       [DisplayName("错误码")]
       public string ErrorCodeParam
        {
            set;
            get;
        }

        /// <summary>
        /// 返回示例
        /// </summary>
       [DisplayName("返回示例")]
       public string ResponseBody
        {
            set;
            get;
        }

        /// <summary>
        /// 创建人
        /// </summary>
       [DisplayName("创建人")]
       public int? CreateUserID
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
        /// 更新人
        /// </summary>
       [DisplayName("更新人")]
       public int? UpdateUserID
        {
            set;
            get;
        }

        /// <summary>
        /// 更新时间
        /// </summary>
       [DisplayName("更新时间")]
       public DateTime? UpdateTime
        {
            set;
            get;
        }

        /// <summary>
        /// 删除标识
        /// </summary>
       [DisplayName("删除标识")]
       public int? IsDelete
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("删除标识")]
       public string IsDelete_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 状态
        /// </summary>
       [DisplayName("状态")]
       public int? Status
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("状态")]
       public string Status_ShowValue
        {
            set;
            get;
        }


        #endregion Model

        //(TableTree)
            [Column(notMap:true)]
            [JsonProperty("children")]
            public List<API> Children
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
