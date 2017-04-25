﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由亚萌智能表单代码生成工具生成。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。除非此项目不再使用代码生成器生成。
//     如果想修改此文件的方法，请在此文件的上级目录中的ProductDiscountDAL重写(override)该方法。
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
    /// 商品折扣实体类
    ///</summary>
    public partial class _ProductDiscountDAL : BaseModelDAL<ProductDiscount>
    {
        public _ProductDiscountDAL():base("UCenter")
        {
        }

		/// <summary>
        /// 是否默认（IsDefault）字段的数据集合（键值对）
        /// </summary>
		public MyNameValueCollection NameValue_IsDefault
		{
			get
			{
			    MyNameValueCollection nv=new MyNameValueCollection();
                nv.Add("0", "否");
                nv.Add("1", "是");
                return nv;

			}
		}



		/// <summary>
		/// 获取数据实体列表(模型过滤)
		///</summary>
		/// <param name="nv">页面传递参数集合</param>
		/// <param name="topN">数据条数</param>
		/// <param name="fields">查询的字段</param>
		/// <returns>实体列表</returns>
        public virtual List<ProductDiscount> GetEntityList_Models(int topN = 0,string fields="")
        {
            object[] arrParams = new object[] { RequestHelper.GetString("Models") };
            return GetEntityList("1=1 AND Models=? ",arrParams, "", topN,fields);
        }
		
		/// <summary>
		/// 获取数据实体列表(模型过滤)
		///</summary>
		/// <param name="fields">查询的字段</param>
		/// <returns>实体列表</returns>
        public virtual List<ProductDiscount> GetAllEntityList_Models(string fields="")
        {
            return GetEntityList_Models(0,fields);
        }
		
		/// <summary>
		/// 获取分页的数据实体列表(模型过滤)
		///</summary>
		/// <param name="totalRows">记录总条数（out）</param>
		/// <param name="nv">页面传递参数集合</param>
		/// <param name="topN">数据条数</param>
		/// <param name="page">页码</param>
		/// <param name="rows">每页记录数</param>
		/// <param name="orderBy">排序</param>
		/// <returns>实体列表</returns>
        public virtual List<ProductDiscount> GetEntityListByPage_Models(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
        {
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
			   order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			object[] arrParams = new object[] { RequestHelper.GetString("Models") };
            arrParams=arrParams.Concat(searchParams).ToArray();
            string fields="DiscountID,DiscountName,IsDefault,DiscountPercent,OrderID";
            return GetEntityListByPage("1=1 AND Models=? "+ where, arrParams,order,fields ,rows,page,topN,out totalRows);
        }
		
		/// <summary>
		/// 获取数据列表DataTable(模型过滤)
		///</summary>
		/// <param name="nv">页面传递参数集合</param>
		/// <param name="topN">数据条数</param>
		/// <param name="fields">查询的字段</param>
		/// <returns>数据列表</returns>
        public virtual DataTable GetEntityTable_Models(int topN = 0,string fields="")
        {
            object[] arrParams = new object[] { RequestHelper.GetString("Models") };
            return GetEntityTable("1=1 AND Models=? ",arrParams, "", topN,fields);
        }
		
		/// <summary>
		/// 获取数据列表DataTable(模型过滤)
		///</summary>
		/// <param name="fields">查询的字段</param>
		/// <returns>数据列表</returns>
        public virtual DataTable GetAllEntityTable_Models(string fields="")
        {
        	return GetEntityTable_Models(0,fields);
        }
		/// <summary>
		/// 获取分页的数据列表DataTable(模型过滤)
		///</summary>
		/// <param name="totalRows">记录总条数（out）</param>
		/// <param name="nv">页面传递参数集合</param>
		/// <param name="topN">数据条数</param>
		/// <param name="page">页码</param>
		/// <param name="rows">每页记录数</param>
		/// <param name="orderBy">排序</param>
		/// <returns>DataTable</returns>
        public virtual DataTable GetEntityTableByPage_Models(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
        {
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
			    order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			object[] arrParams = new object[] { RequestHelper.GetString("Models") };
            arrParams=arrParams.Concat(searchParams).ToArray();
            string fields="DiscountID,DiscountName,IsDefault,DiscountPercent,OrderID";
            return GetEntityTableByPage("1=1 AND Models=? "+ where, arrParams,order,fields, rows,page,topN,out totalRows);
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
		public virtual List<ProductDiscount> GetEntityListByPage(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
		{
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
				order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			string fields="DiscountID,DiscountName,IsDefault,DiscountPercent,OrderID";
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
			string fields="DiscountID,DiscountName,IsDefault,DiscountPercent,OrderID";
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

		
	    public virtual ProductDiscount GetModelValue(ProductDiscount model)
        {
            return model;
        }
		/// <summary>
        /// 设置商品折扣实体(ProductDiscount)的显示值
        /// </summary>
        /// <param name="model">商品折扣实体(ProductDiscount)</param>
        /// <returns>商品折扣实体(ProductDiscount)</returns>
		public virtual ProductDiscount GetModelShowValue(ProductDiscount model,bool clearValue=false)
        {
            model=GetModelValue(model);
			if (model.IsDefault!=null)
			{
				model.IsDefault_ShowValue=NameValue_IsDefault.Get(model.IsDefault.ToString());
			}
			if(clearValue)
			{
				model.IsDefault = null;
			}
			return model;
		}
		
		/// <summary>
        /// 设置商品折扣实体(ProductDiscount)的列表显示值
        /// </summary>
        /// <param name="model">商品折扣实体(ProductDiscount)</param>
        /// <returns>商品折扣实体(ProductDiscount)</returns>
		public virtual ProductDiscount GetModelGridShowValue(ProductDiscount model){
			model=GetModelShowValue(model);
			return model;
        }

        public virtual ProductDiscount GetInfoByID(object id){
            ProductDiscount model = GetModelByID(id);
            model = GetModelShowValue(model);
            return model;
        } 


      #region 新建相关方法
		/// <summary>
        /// 设置新增入库时商品折扣实体(ProductDiscount)默认值
        /// </summary>
        /// <param name="model">商品折扣实体(ProductDiscount)</param>
        /// <returns>商品折扣实体(ProductDiscount)</returns>
		public virtual ProductDiscount GetInsertModelValue(ProductDiscount model)
		{
			model.DiscountID =null;
			model.Models =(RequestHelper.GetString("Models"));
			return model;
		}		/// <summary>
        /// 设置新建页面的商品折扣实体(ProductDiscount)默认值
        /// </summary>
        /// <param name="model">商品折扣实体(ProductDiscount)</param>
        /// <returns>商品折扣实体(ProductDiscount)</returns>
		public virtual ProductDiscount GetCreateFormDefaultValue()
		{
            ProductDiscount model = new ProductDiscount();
			model.IsDefault=0;
			model.DiscountPercent=1;
			model.OrderID=0;
			model.Models=(RequestHelper.GetString("Models"));
            return model;
		}

		/// <summary>
        /// 新建数据格式验证
        /// </summary>
        /// <param name="model">商品折扣实体(ProductDiscount)</param>
        public virtual void CreateFormValidator(ProductDiscount model)
        {
			string value="";
			
			//DiscountName验证
			value = model.DiscountName!=null ? model.DiscountName.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("折扣名称不能为空！");
		            }
			
			//IsDefault验证
			value = model.IsDefault!=null ? model.IsDefault.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("是否默认不能为空！");
		            }
			
			//DiscountPercent验证
			value = model.DiscountPercent!=null ? model.DiscountPercent.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("折扣率不能为空！");
		            }
			
			//OrderID验证
			value = model.OrderID!=null ? model.OrderID.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("排序号不能为空！");
		            }
}
      #endregion

      #region 修改相关方法
		/// <summary>
        /// 设置更新入库时商品折扣实体(ProductDiscount)默认值
        /// </summary>
        /// <param name="model">商品折扣实体(ProductDiscount)</param>
        /// <returns>商品折扣实体(ProductDiscount)</returns>
		public virtual ProductDiscount GetUpdateModelValue(ProductDiscount model)
		{
			return model;
		}		/// <summary>
        /// 设置编辑页面的商品折扣实体(ProductDiscount)默认值
        /// </summary>
        /// <param name="model">商品折扣实体(ProductDiscount)</param>
        /// <returns>商品折扣实体(ProductDiscount)</returns>
		public virtual ProductDiscount GetEditFormDefaultValue(ProductDiscount model)
		{
			return model;
		}

		/// <summary>
        /// 编辑数据格式验证
        /// </summary>
        /// <param name="model">商品折扣实体(ProductDiscount)</param>
        public virtual void EditFormValidator(ProductDiscount model)
        {
			string value="";
			
			//DiscountName验证
			value = model.DiscountName!=null ? model.DiscountName.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("折扣名称不能为空！");
		            }
			
			//IsDefault验证
			value = model.IsDefault!=null ? model.IsDefault.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("是否默认不能为空！");
		            }
			
			//DiscountPercent验证
			value = model.DiscountPercent!=null ? model.DiscountPercent.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("折扣率不能为空！");
		            }
			
			//OrderID验证
			value = model.OrderID!=null ? model.OrderID.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("排序号不能为空！");
		            }
}
      #endregion

    }
}