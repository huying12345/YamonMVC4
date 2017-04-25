﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由亚萌智能表单代码生成工具生成。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。除非此项目不再使用代码生成器生成。
//     如果想修改此文件的方法，请在此文件的上级目录中的AppVersionDAL重写(override)该方法。
//     如有问题联系zongeasy@qq.com
//
//</auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Yamon.Framework.DBUtility;
using System.Collections;
using Yamon.Framework.Common.DataBase;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using System.IO;
using System.Linq.Expressions;
using Yamon.Framework.DAL;
using Yamon.Module.App.Entity;

namespace Yamon.Module.App.DAL
{
    /// <summary>
    /// 版本模型实体类
    ///</summary>
    public partial class _AppVersionDAL : BaseModelDAL<AppVersion>
    {
        public _AppVersionDAL():base("UCenter")
        {
        }

		/// <summary>
        /// 版本类型（VersionType）字段的数据集合（键值对）
        /// </summary>
		public MyNameValueCollection NameValue_VersionType
		{
			get
			{
			    MyNameValueCollection nv=new MyNameValueCollection();
                nv.Add("1", "稳定版");
                nv.Add("0", "测试版");
                nv.Add("2", "强制更新版本");
                return nv;

			}
		}
		/// <summary>
        /// 设备类型（DeviceType）字段的数据集合（键值对）
        /// </summary>
		public MyNameValueCollection NameValue_DeviceType
		{
			get
			{
			    MyNameValueCollection nv=new MyNameValueCollection();
                nv.Add("Android", "Android");
                nv.Add("iOS", "iOS");
                return nv;

			}
		}




		/// <summary>
		/// 获取分页的数据实体列表
		///</summary>
		/// <param name="totalRows">记录总条数（out）</param>
		/// <param name="nv">页面传递参数集合</param>
		/// <param name="topN">数据条数</param>
		/// <param name="page">页码</param>
		/// <param name="rows">每页记录数</param>
		/// <param name="orderBy">排序</param>
		/// <returns>实体列表</returns>
		public virtual List<AppVersion> GetEntityListByPage(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
		{
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
				order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			string fields="VersionID,VersionType,DeviceType,VersionCode,VersionName,FileSize,UpdatePath,ReleaseTime,ChangeLog";
			return GetEntityListByPage("1=1 "+ where, searchParams,order,fields, rows,page,topN,out totalRows);
		}

		/// <summary>
		/// 获取分页的数据列表DataTable
		///</summary>
		/// <param name="totalRows">记录总条数（out）</param>
		/// <param name="nv">页面传递参数集合</param>
		/// <param name="topN">数据条数</param>
		/// <param name="page">页码</param>
		/// <param name="rows">每页记录数</param>
		/// <param name="orderBy">排序</param>
		/// <returns>DataTable</returns>
		public virtual DataTable GetEntityTableByPage(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
		{
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
				order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			string fields="VersionID,VersionType,DeviceType,VersionCode,VersionName,FileSize,UpdatePath,ReleaseTime,ChangeLog";
			return GetEntityTableByPage("1=1 "+ where, searchParams,order,fields,rows,page,topN,out totalRows);
		}

		/// <summary>
        /// 拼接查询Sql语句及参数
        /// </summary>
        /// <param name="nv">页面传递的参数集合</param>
        /// <param name="notIn">排除字段</param>
        /// <param name="arrParam">out查询参数</param>
        /// <returns>查询Sql语句</returns>
		public virtual string GetSearchSql(string notIn,out object[] arrParam)
		{
			StringBuilder sb=new StringBuilder();
			string value="";
			string value1 = "";
			string value2 = "";
			ArrayList param=new ArrayList();
			arrParam=param.ToArray();
			return sb.ToString();

		}

		
	    public virtual AppVersion GetModelValue(AppVersion model)
        {
            return model;
        }
		/// <summary>
        /// 设置版本模型实体(AppVersion)的显示值
        /// </summary>
        /// <param name="model">版本模型实体(AppVersion)</param>
        /// <returns>版本模型实体(AppVersion)</returns>
		public virtual AppVersion GetModelShowValue(AppVersion model,bool clearValue=false)
        {
            model=GetModelValue(model);
			if (model.VersionType!=null)
			{
				model.VersionType_ShowValue=NameValue_VersionType.Get(model.VersionType.ToString());
			}
			if (model.DeviceType!=null)
			{
				model.DeviceType_ShowValue=NameValue_DeviceType.Get(model.DeviceType.ToString());
			}
			if(clearValue)
			{
				model.VersionType = null;
				model.DeviceType = null;
			}
			return model;
		}
		
		/// <summary>
        /// 设置版本模型实体(AppVersion)的列表显示值
        /// </summary>
        /// <param name="model">版本模型实体(AppVersion)</param>
        /// <returns>版本模型实体(AppVersion)</returns>
		public virtual AppVersion GetModelGridShowValue(AppVersion model){
			model=GetModelShowValue(model);
			return model;
        }

        public virtual AppVersion GetInfoByID(object id){
            AppVersion model = GetModelByID(id);
            model = GetModelShowValue(model);
            return model;
        } 


      #region 新建相关方法
		/// <summary>
        /// 设置新增入库时版本模型实体(AppVersion)默认值
        /// </summary>
        /// <param name="model">版本模型实体(AppVersion)</param>
        /// <returns>版本模型实体(AppVersion)</returns>
		public virtual AppVersion GetInsertModelValue(AppVersion model)
		{
			model.VersionID =null;
			return model;
		}		/// <summary>
        /// 设置新建页面的版本模型实体(AppVersion)默认值
        /// </summary>
        /// <param name="model">版本模型实体(AppVersion)</param>
        /// <returns>版本模型实体(AppVersion)</returns>
		public virtual AppVersion GetCreateFormDefaultValue()
		{
            AppVersion model = new AppVersion();
			model.VersionType=1;
			model.DeviceType="Android";
			model.VersionCode=1;
			model.ReleaseTime=DateTime.Now;
            return model;
		}

		/// <summary>
        /// 新建数据格式验证
        /// </summary>
        /// <param name="model">版本模型实体(AppVersion)</param>
        public virtual void CreateFormValidator(AppVersion model)
        {
			string value="";
}
      #endregion

      #region 修改相关方法
		/// <summary>
        /// 设置更新入库时版本模型实体(AppVersion)默认值
        /// </summary>
        /// <param name="model">版本模型实体(AppVersion)</param>
        /// <returns>版本模型实体(AppVersion)</returns>
		public virtual AppVersion GetUpdateModelValue(AppVersion model)
		{
			return model;
		}		/// <summary>
        /// 设置编辑页面的版本模型实体(AppVersion)默认值
        /// </summary>
        /// <param name="model">版本模型实体(AppVersion)</param>
        /// <returns>版本模型实体(AppVersion)</returns>
		public virtual AppVersion GetEditFormDefaultValue(AppVersion model)
		{
			return model;
		}

		/// <summary>
        /// 编辑数据格式验证
        /// </summary>
        /// <param name="model">版本模型实体(AppVersion)</param>
        public virtual void EditFormValidator(AppVersion model)
        {
			string value="";
}
      #endregion

    }
}