﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由亚萌智能表单代码生成工具生成。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。除非此项目不再使用代码生成器生成。
//     如果想修改此文件的方法，请在此文件的上级目录中的OrderDetailDAL重写(override)该方法。
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
using Yamon.Module.Product.Entity;

namespace Yamon.Module.Product.DAL
{
    /// <summary>
    /// 订单明细实体类
    ///</summary>
    public partial class _OrderDetailDAL : BaseModelDAL<OrderDetail>
    {
        public _OrderDetailDAL():base("UCenter")
        {
        }

		/// <summary>
        /// 状态（Status）字段的数据集合（键值对）
        /// </summary>
		public MyNameValueCollection NameValue_Status
		{
			get
			{
			    return Yamon.Module.SiteManage.DAL.DictTypeDAL.GetNameValueCollectionByID("a6007cb1-224d-4303-9733-1d891373cc6b");

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
		public virtual List<OrderDetail> GetEntityListByPage(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
		{
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
				order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			string fields="OrderDetailID,OrderID,ProductID,ProductNo,Price,Num,SalePrice,TotalMoney,Comment,BackField1,BackField2,Status";
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
			string fields="OrderDetailID,OrderID,ProductID,ProductNo,Price,Num,SalePrice,TotalMoney,Comment,BackField1,BackField2,Status";
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

		
	    public virtual OrderDetail GetModelValue(OrderDetail model)
        {
            return model;
        }
		/// <summary>
        /// 设置订单明细实体(OrderDetail)的显示值
        /// </summary>
        /// <param name="model">订单明细实体(OrderDetail)</param>
        /// <returns>订单明细实体(OrderDetail)</returns>
		public virtual OrderDetail GetModelShowValue(OrderDetail model,bool clearValue=false)
        {
            model=GetModelValue(model);
			if (model.Status!=null)
			{
				model.Status_ShowValue=NameValue_Status.Get(model.Status.ToString());
			}
			if(clearValue)
			{
				model.Status = null;
			}
			return model;
		}
		
		/// <summary>
        /// 设置订单明细实体(OrderDetail)的列表显示值
        /// </summary>
        /// <param name="model">订单明细实体(OrderDetail)</param>
        /// <returns>订单明细实体(OrderDetail)</returns>
		public virtual OrderDetail GetModelGridShowValue(OrderDetail model){
			model=GetModelShowValue(model);
			return model;
        }

        public virtual OrderDetail GetInfoByID(object id){
            OrderDetail model = GetModelByID(id);
            model = GetModelShowValue(model);
            return model;
        } 


      #region 新建相关方法
		/// <summary>
        /// 设置新增入库时订单明细实体(OrderDetail)默认值
        /// </summary>
        /// <param name="model">订单明细实体(OrderDetail)</param>
        /// <returns>订单明细实体(OrderDetail)</returns>
		public virtual OrderDetail GetInsertModelValue(OrderDetail model)
		{
			model.OrderDetailID =(Guid.NewGuid().ToString());
			return model;
		}		/// <summary>
        /// 设置新建页面的订单明细实体(OrderDetail)默认值
        /// </summary>
        /// <param name="model">订单明细实体(OrderDetail)</param>
        /// <returns>订单明细实体(OrderDetail)</returns>
		public virtual OrderDetail GetCreateFormDefaultValue()
		{
            OrderDetail model = new OrderDetail();
			model.Status=0;
            return model;
		}

		/// <summary>
        /// 新建数据格式验证
        /// </summary>
        /// <param name="model">订单明细实体(OrderDetail)</param>
        public virtual void CreateFormValidator(OrderDetail model)
        {
			string value="";
			
			//OrderDetailID验证
			value = model.OrderDetailID!=null ? model.OrderDetailID.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("ID不能为空！");
		            }
			
			//Status验证
			value = model.Status!=null ? model.Status.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("状态不能为空！");
		            }
}
      #endregion

      #region 修改相关方法
		/// <summary>
        /// 设置更新入库时订单明细实体(OrderDetail)默认值
        /// </summary>
        /// <param name="model">订单明细实体(OrderDetail)</param>
        /// <returns>订单明细实体(OrderDetail)</returns>
		public virtual OrderDetail GetUpdateModelValue(OrderDetail model)
		{
			return model;
		}		/// <summary>
        /// 设置编辑页面的订单明细实体(OrderDetail)默认值
        /// </summary>
        /// <param name="model">订单明细实体(OrderDetail)</param>
        /// <returns>订单明细实体(OrderDetail)</returns>
		public virtual OrderDetail GetEditFormDefaultValue(OrderDetail model)
		{
			return model;
		}

		/// <summary>
        /// 编辑数据格式验证
        /// </summary>
        /// <param name="model">订单明细实体(OrderDetail)</param>
        public virtual void EditFormValidator(OrderDetail model)
        {
			string value="";
			
			//Status验证
			value = model.Status!=null ? model.Status.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("状态不能为空！");
		            }
}
      #endregion
		/// <summary>
        /// 从DataSet中导入数据
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns>影响的行数</returns>
		public virtual int ImportDataFromDataSet(DataSet ds)
		{
			if (ds.Tables.Count > 0)
			{
                DataTable dt=ds.Tables[0];
                foreach (System.Reflection.PropertyInfo p in typeof(OrderDetail).GetProperties())
                {
                    var nameAttr = p.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                    if (nameAttr.Length > 0)
                    {
                        DisplayNameAttribute displayNameAttribute = nameAttr[0] as DisplayNameAttribute;
                        if (displayNameAttribute != null && !string.IsNullOrEmpty(displayNameAttribute.DisplayName) && dt.Columns.Contains(displayNameAttribute.DisplayName))
                        {
                            dt.Columns[displayNameAttribute.DisplayName].ColumnName = p.Name;
                        }
                    }
                }
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					if (dt.Columns.Contains("Status"))
					{
						if (dt.Rows[i]["Status"].ToString()!="")
						{
							dt.Rows[i]["Status"] = NameValue_Status.GetKeyByValue(dt.Rows[i]["Status"].ToString());
						}
					}
				}
				ImportDataFromDataTable(dt);

			}
			return 0;
		}
    }
}