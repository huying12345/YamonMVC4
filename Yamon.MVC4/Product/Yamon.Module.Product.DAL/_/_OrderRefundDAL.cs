﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由亚萌智能表单代码生成工具生成。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。除非此项目不再使用代码生成器生成。
//     如果想修改此文件的方法，请在此文件的上级目录中的OrderRefundDAL重写(override)该方法。
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
    /// 订单退票实体类
    ///</summary>
    public partial class _OrderRefundDAL : BaseModelDAL<OrderRefund>
    {
        public _OrderRefundDAL():base("UCenter")
        {
        }

		/// <summary>
        /// 审核状态（Status）字段的数据集合（键值对）
        /// </summary>
		public MyNameValueCollection NameValue_Status
		{
			get
			{
			    MyNameValueCollection nv=new MyNameValueCollection();
                nv.Add("0", "待审核");
                nv.Add("1", "已审核");
                nv.Add("2", "审核不通过");
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
        public virtual List<OrderRefund> GetEntityList_Models(int topN = 0,string fields="")
        {
            object[] arrParams = new object[] { RequestHelper.GetString("Models") };
            return GetEntityList("1=1 AND Models=? ",arrParams, "", topN,fields);
        }
		
		/// <summary>
		/// 获取数据实体列表(模型过滤)
		///</summary>
		/// <param name="fields">查询的字段</param>
		/// <returns>实体列表</returns>
        public virtual List<OrderRefund> GetAllEntityList_Models(string fields="")
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
        public virtual List<OrderRefund> GetEntityListByPage_Models(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
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
            string fields="RefundID,OrderID,OrderDetailID,RefundMoney,RefundTime,RefundUserID,Status";
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
            string fields="RefundID,OrderID,OrderDetailID,RefundMoney,RefundTime,RefundUserID,Status";
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
		public virtual List<OrderRefund> GetEntityListByPage(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
		{
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
				order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			string fields="RefundID,OrderID,OrderDetailID,RefundMoney,RefundTime,RefundUserID,Status";
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
			string fields="RefundID,OrderID,OrderDetailID,RefundMoney,RefundTime,RefundUserID,Status";
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

		
	    public virtual OrderRefund GetModelValue(OrderRefund model)
        {
            return model;
        }
		/// <summary>
        /// 设置订单退票实体(OrderRefund)的显示值
        /// </summary>
        /// <param name="model">订单退票实体(OrderRefund)</param>
        /// <returns>订单退票实体(OrderRefund)</returns>
		public virtual OrderRefund GetModelShowValue(OrderRefund model,bool clearValue=false)
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
        /// 设置订单退票实体(OrderRefund)的列表显示值
        /// </summary>
        /// <param name="model">订单退票实体(OrderRefund)</param>
        /// <returns>订单退票实体(OrderRefund)</returns>
		public virtual OrderRefund GetModelGridShowValue(OrderRefund model){
			model=GetModelShowValue(model);
			return model;
        }

        public virtual OrderRefund GetInfoByID(object id){
            OrderRefund model = GetModelByID(id);
            model = GetModelShowValue(model);
            return model;
        } 


      #region 新建相关方法
		/// <summary>
        /// 设置新增入库时订单退票实体(OrderRefund)默认值
        /// </summary>
        /// <param name="model">订单退票实体(OrderRefund)</param>
        /// <returns>订单退票实体(OrderRefund)</returns>
		public virtual OrderRefund GetInsertModelValue(OrderRefund model)
		{
			model.Status =0;
			return model;
		}		/// <summary>
        /// 设置新建页面的订单退票实体(OrderRefund)默认值
        /// </summary>
        /// <param name="model">订单退票实体(OrderRefund)</param>
        /// <returns>订单退票实体(OrderRefund)</returns>
		public virtual OrderRefund GetCreateFormDefaultValue()
		{
            OrderRefund model = new OrderRefund();
            return model;
		}

		/// <summary>
        /// 新建数据格式验证
        /// </summary>
        /// <param name="model">订单退票实体(OrderRefund)</param>
        public virtual void CreateFormValidator(OrderRefund model)
        {
			string value="";
			
			//RefundID验证
			value = model.RefundID!=null ? model.RefundID.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("退单编号不能为空！");
		            }
}
      #endregion

      #region 修改相关方法
		/// <summary>
        /// 设置更新入库时订单退票实体(OrderRefund)默认值
        /// </summary>
        /// <param name="model">订单退票实体(OrderRefund)</param>
        /// <returns>订单退票实体(OrderRefund)</returns>
		public virtual OrderRefund GetUpdateModelValue(OrderRefund model)
		{
			model.Status =null;
			return model;
		}		/// <summary>
        /// 设置编辑页面的订单退票实体(OrderRefund)默认值
        /// </summary>
        /// <param name="model">订单退票实体(OrderRefund)</param>
        /// <returns>订单退票实体(OrderRefund)</returns>
		public virtual OrderRefund GetEditFormDefaultValue(OrderRefund model)
		{
			return model;
		}

		/// <summary>
        /// 编辑数据格式验证
        /// </summary>
        /// <param name="model">订单退票实体(OrderRefund)</param>
        public virtual void EditFormValidator(OrderRefund model)
        {
			string value="";
}
      #endregion

    }
}