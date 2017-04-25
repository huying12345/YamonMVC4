
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Yamon.Framework.DBUtility;
using System.Collections;
using Yamon.Framework.Common.DataBase;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using System.IO;
using System.Linq.Expressions;
using Yamon.Framework.DAL;
using Yamon.Module.Product.Entity;
using System;
using Newtonsoft.Json;
using Yamon.Module.SiteManage.DAL;
using Yamon.Module.SiteManage.Entity;

namespace Yamon.Module.Product.DAL
{
    /// <summary>
    /// 订单信息实体类
    ///</summary>
    public partial class OrderInfoDAL : _OrderInfoDAL
    {
        public override OrderInfo GetInsertModelValue(OrderInfo model)
        {

            model.CreateUserID = (CookieHelper.GetCookieInt("UserID"));
            model.CreateTime = DateTime.Now;
            return base.GetInsertModelValue(model);
        }
        public override int InsertByModel(object obj)
        {
            OrderInfo model = (OrderInfo)obj;
            
            List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();
            sqllist.Add(base.GetInsertByModelSql(obj));


            OrderDetailDAL orderDetailDal = new OrderDetailDAL();
            string result = RequestHelper.GetString("json");
            Parameters ps;

            List<OrderDetail> orderDetailList = JsonConvert.DeserializeObject<List<OrderDetail>>(result);
            int ii = 0;
            for (int i = 0; i < orderDetailList.Count; i++)
            {
                orderDetailList[i] = orderDetailDal.GetInsertModelValue(orderDetailList[i]);
                if (model.Models == "Ticket")
                {
                    double num = orderDetailList[i].Num.Value;
                    for (int j = 0; j < num; j++)
                    {
                        ii++;
                        OrderDetail ticket = orderDetailList[i];
                        ticket.OrderDetailID = (orderDetailDal.GetMaxTicketID() + ii).ToString().PadLeft(8, '0');
                        ticket.Num = 1;
                        ticket.TotalMoney = ticket.SalePrice;
                        sqllist.Add(orderDetailDal.GetInsertByModelSql(ticket));
                    }
                }
                else
                {
                    sqllist.Add(orderDetailDal.GetInsertByModelSql(orderDetailList[i]));
                }
                if (model.Models == "Good")
                {
                    ps = new Parameters();
                    ps.AddInParameter("ProductInfoNo", DbType.AnsiString, orderDetailList[i].ProductNo);
                    ps.AddInParameter("Models", DbType.AnsiString, "Good");
                    ps.AddInParameter("StockNum", DbType.Double, orderDetailList[i].Num);

                    sqllist.Add(new SqlParametersKeyValue("update View_Product_ProductInfo set StockNum=StockNum-@StockNum where ProductInfoNo=@ProductInfoNo and Models=@Models", ps));
                }
            }
            return Db.ExecuteNonQueryTran(sqllist);
        }


        /// <summary>
        /// 销售日统计-获取历史逐日统计数据
        /// </summary>
        /// <param name="starTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable GetProductEChars(string starTime, string endTime)
        {
            string dtime = DataConverter.ToDate(DbHelper.GetConn("UCenter").ExecuteStringSql("select top 1 CreateTime from View_Product_Statistics  order by CreateTime desc")).AddDays(-7).ToString("yyyy-MM-dd");

            string sql = "select*from View_Product_Statistics where CreateTime>=? and CreateTime<=? and PayStatus=1 order by createtime asc";
            DataTable dt = DbHelper.GetConn("UCenter").ExecuteDataTableSqlEx(sql, starTime, endTime);
            //if (dt.Rows.Count <= 0)
            //{
            //    sql = "select*from View_Product_Statistics where CreateTime>=? order by createtime asc";
            //    dt = DbHelper.GetConn("UCenter").ExecuteDataTableSqlEx(sql, dtime);
            //}
            return dt;
        }

        /// <summary>
        /// 销售日统计-添加缺失时间（曲线图）
        /// </summary>
        /// <param name="starTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable GetCountDataTable(string starTime, string endTime)
        {
            DataTable dt = GetProductEChars(starTime, endTime);

            DataTable newdt = new DataTable();
            newdt.Columns.Add("CreateTime");
            newdt.Columns.Add("Models");
            newdt.Columns.Add("TotalMoney");
            DictDataDAL dic = new DictDataDAL();
            List<DictData> models = dic.GetEntityList("DictTypeID='ce7932da-a2cb-4366-9c7a-6ae9aadc9e4f'");
            if (dt.Rows.Count > 0)
            {

                int dateDiff = GetTime(DataConverter.ToDate(starTime), DataConverter.ToDate(endTime));

                for (int i = 0; i <= dateDiff; i++)
                {

                    string time3 = DataConverter.ToDate(starTime).AddDays(i).ToString("yyyy-MM-dd");
                    for (int k = 0; k < models.Count; k++)
                    {
                        DataRow dr = newdt.NewRow();
                        DataRow[] arrRow = dt.Select("CreateTime = '" + time3 + "' and Models='" + models[k].Value + "'");
                        if (arrRow.Length > 0)
                        {
                            dr["TotalMoney"] = arrRow[0]["TotalMoney"];
                        }
                        else
                        {
                            dr["TotalMoney"] = 0;
                        }
                        dr["CreateTime"] = time3;
                        dr["Models"] = models[k].Value;
                        newdt.Rows.Add(dr);

                    }


                }

            }


            return newdt;
        }

        /// <summary>
        /// 销售日统计-添加缺失时间、更改数据格式（列表）
        /// </summary>
        /// <param name="starTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable GetCountList(string starTime, string endTime)
        {
            DataTable dt = GetProductEChars(starTime, endTime);

            DataTable newdt = new DataTable();
            newdt.Columns.Add("CreateTime");

            newdt.Columns.Add("TotalMoney_Food");
            newdt.Columns.Add("TotalMoney_Good");
            newdt.Columns.Add("TotalMoney_Playground");
            newdt.Columns.Add("TotalMoney_Ticket");

            if (dt.Rows.Count > 0)
            {

                int dateDiff = GetTime(DataConverter.ToDate(starTime), DataConverter.ToDate(endTime));

                for (int i = 0; i <= dateDiff; i++)
                {

                    string time3 = DataConverter.ToDate(starTime).AddDays(i).ToString("yyyy-MM-dd");
                    DataRow dr = newdt.NewRow();

                    DataRow[] arrRow = dt.Select("CreateTime = '" + time3 + "'");
                    dr["CreateTime"] = time3;
                    dr["TotalMoney_Food"] = 0;
                    dr["TotalMoney_Ticket"] = 0;
                    dr["TotalMoney_Good"] = 0;
                    dr["TotalMoney_Playground"] = 0;
                    for (int l = 0; l < arrRow.Length; l++)
                    {

                        if (arrRow[l]["Models"].ToString() == "Food")
                        {
                            dr["TotalMoney_Food"] = arrRow[l]["TotalMoney"];
                        }

                        if (arrRow[l]["Models"].ToString() == "Ticket")
                        {
                            dr["TotalMoney_Ticket"] = arrRow[l]["TotalMoney"];
                        }
                        if (arrRow[l]["Models"].ToString() == "Good")
                        {
                            dr["TotalMoney_Good"] = arrRow[l]["TotalMoney"];
                        }
                        if (arrRow[l]["Models"].ToString() == "Playground")
                        {
                            dr["TotalMoney_Playground"] = arrRow[l]["TotalMoney"];
                        }



                    }
                    newdt.Rows.Add(dr);

                }




            }

            return newdt;
        }


        public int GetTime(DateTime times1, DateTime times2)
        {
            DateTime time = times1;
            DateTime time1 = times2;//设置要求的减的时间       
            int dateDiff = 0;
            TimeSpan ts1 = new TimeSpan(time.Ticks);
            TimeSpan ts2 = new TimeSpan(time1.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Days;
            return dateDiff;
        }

        /// <summary>
        /// 获取当天统计数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetToDayCount()
        {
            string dtime = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "select*from View_Product_Statistics  where CreateTime=? order by createtime asc";
            DataTable dt = DbHelper.GetConn("UCenter").ExecuteDataTableSqlEx(sql, dtime);
            DictDataDAL dic = new DictDataDAL();
            List<DictData> list = dic.GetEntityList("DictTypeID='ce7932da-a2cb-4366-9c7a-6ae9aadc9e4f'");
            DataTable newdt = new DataTable();
            newdt.Columns.Add("CreateTime");

            newdt.Columns.Add("TotalMoney_Food");
            newdt.Columns.Add("TotalMoney_Good");
            newdt.Columns.Add("TotalMoney_Playground");
            newdt.Columns.Add("TotalMoney_Ticket");
            newdt.Columns.Add("TotalMoney");

            DataRow dr = newdt.NewRow();
            for (int i = 0; i < list.Count; i++)
            {

                DataRow[] arrRow = dt.Select("Models = '" + list[i].Value + "'");
                if (arrRow.Length > 0)
                {
                    dr["TotalMoney_" + list[i].Value] = arrRow[0]["TotalMoney"];
                }
                else
                {
                    dr["TotalMoney_" + list[i].Value] = 0;
                }
                dr["CreateTime"] = dtime;


            }
            newdt.Rows.Add(dr);

            return newdt;
        }


        /// <summary>
        /// 销售排行
        /// </summary>
        /// <returns></returns>
        public DataTable GetSecondList()
        {
            string sql = "select sum(Num) as counts ,SUM(TotalMoney) as TotalMoney,ProductName,Models from [View_Product_OrderDetail] group by ProductName,Models order by counts desc";
            DataTable dt = DbHelper.GetConn("UCenter").ExecuteDataTableSqlEx(sql);
            sql = "select sum(Num) as counts ,SUM(TotalMoney) as TotalMoney,'合计' as ProductName,Models from [View_Product_OrderDetail] group by Models ";
            DataTable dtTotal = DbHelper.GetConn("UCenter").ExecuteDataTableSqlEx(sql);
            foreach (DataRow dr in dtTotal.Rows)
            {
                dt.ImportRow(dr);
            }
            return dt;
        }
        public DataTable GetSecondTimeList(string startime, string endtime, string models)
        {
            string sqlwehere = "";
            if (!string.IsNullOrEmpty(models))
            {
                sqlwehere = "and Models='" + models + "'";

            }
            //string sql = " select sum(Num) as counts ,SUM(TotalMoney) as TotalMoney,b.ProductName,b.Models,a.TypeName,a.ProductTypeId, CONVERT(varchar(100), b.CreateTime, 23) AS CreateTime from [View_Product_OrderDetail] as b left join (select ProductTypeId,ProductInfoId,TypeName from [View_Product_ProductInfo]) as a on b.ProductID=a.ProductInfoId where  CreateTime between ? and  ? " + sqlwehere + " group by ProductName,Models,  CONVERT(varchar(100), CreateTime, 23),a.TypeName,a.ProductTypeId order by counts desc";
            string sql = @"SELECT SUM(Num) as counts,SUM(TotalMoney) as TotalMoney,d.ProductName,d.Models,d.TypeName,t.ProductTypeId, CONVERT(varchar(100), d.CreateTime, 23) AS CreateTime
                            FROM View_Product_OrderDetail d
                            inner join Product_ProductInfo t on t.ProductInfoNo =d.ProductNo
                            where  Convert(varchar(100),d.CreateTime,23) between ? and ?
                            and Status = 0 and PayStatus=1" + sqlwehere + "group by d.ProductName,d.Models,d.TypeName,t.ProductTypeId,CONVERT(varchar(100), d.CreateTime, 23) order by counts desc";
            DataTable dt = DbHelper.GetConn("UCenter").ExecuteDataTableSqlEx(sql, startime, endtime);
            List<string> list = new List<string>() { "counts", "TotalMoney" };
            dt = CalcSum(list, dt, "ProductName");
            return dt;
        }



        private DataTable CalcSum(List<string> calcColumn, DataTable dt, string titleColumn)
        {
            dt.Columns.Add("CountsPercent");
            dt.Columns.Add("TotalMoneyPercent");
            DataRow newRow = dt.NewRow();
            foreach (string item in calcColumn)
            {
                string sum = dt.Compute("SUM(" + item + ")", "true").ToString();
                foreach (DataRow row in dt.Rows)
                {
                    double percent = 0;
                    if (DataConverter.ToDouble(sum) > 0)
                    {
                        percent = DataConverter.ToDouble(row[item]) / DataConverter.ToDouble(sum) * 100;
                    }
                    if ("CountsPercent".ToLower().Contains(item))
                    {
                        row["CountsPercent"] = Math.Round(percent, 2) + "%";
                    }
                    else if ("TotalMoneyPercent".Contains(item))
                    {
                        row["TotalMoneyPercent"] = Math.Round(percent, 2) + "%";
                    }
                }
                newRow[item] = sum==""?"0":sum;
            }
            newRow["TypeName"] = "";
            newRow[titleColumn] = "小计";
            dt.Rows.Add(newRow);
            return dt;
        }

        /// <summary>
        /// 财务汇总
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable GetSummaryList(string startTime, string endTime)
        {
            string sql = @" select Name,SUM(TotalMoney) as TotalMoney,SUM(RefundMoney)as RefundMoney,SUM(Total) as Total from View_Product_Statistics
                            where PayStatus=1 and CreateTime between ? and ?
                            group by Name";
            DataTable dt = DbHelper.GetConn("UCenter").ExecuteDataTableSqlEx(sql, startTime, endTime);
            return dt;
        }

        /// <summary>
        /// 支付方式统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="modelsList"></param>
        /// <returns></returns>
        public DataTable GetOrderInfoByPay(string startTime, string endTime, string modelsList)
        {
            try
            {
                if (!string.IsNullOrEmpty(modelsList))
                {
                    modelsList = "'" + modelsList.Replace(",", "','") + "'";
                    string sql = "select CONVERT(varchar(100),CreateTime,23) as CreateTime,SUM(d.TotalMoney) as TotalMoney,PayType from Product_OrderInfo o inner join Product_OrderDetail d on o.OrderID=d.OrderID where PayStatus=1 and CONVERT(varchar(100),CreateTime,23) between ? and ? and d.Status = 0 and Models in (" + modelsList + ") group by CONVERT(varchar(100),CreateTime,23),PayType";
                    DataTable dt = DbHelper.GetConn("UCenter").ExecuteDataTableSqlEx(sql, startTime, endTime);

                    if (dt.Rows.Count == 0) return new DataTable();

                    DataTable newTable = new DataTable();
                    newTable.Columns.Add("CreateTime");
                    DictDataDAL dictData = new DictDataDAL();
                    List<DictData> datalist = dictData.GetEntityList("DictTypeID='ad69e049-5617-4845-95c8-78512de97406'");
                    for (int i = 0; i < datalist.Count; i++)
                    {
                        newTable.Columns.Add("Pay_" + datalist[i].Value).SetOrdinal(i + 1);
                    }
                    newTable.Columns.Add("Total");

                    int dateDiff = GetTime(DataConverter.ToDate(startTime), DataConverter.ToDate(endTime));

                    for (int i = 0; i <= dateDiff; i++)
                    {
                        DataRow dr = newTable.NewRow();
                        double total = 0;
                        string dateTime = DataConverter.ToDate(startTime).AddDays(i).ToString("yyyy-MM-dd");
                        dr["CreateTime"] = dateTime;
                        for (int j = 0; j < datalist.Count; j++)
                        {
                            DataRow[] drs = dt.Select("CreateTime = '" + dateTime + "' and  PayType = " + datalist[j].Value);
                            if (drs.Length > 0)
                            {
                                dr[j + 1] = drs[0]["TotalMoney"];
                                total += DataConverter.ToDouble(drs[0]["TotalMoney"]);
                            }
                            else
                            {
                                dr[j + 1] = 0;
                            }
                        }
                        dr[newTable.Columns.Count - 1] = total;
                        newTable.Rows.Add(dr);
                    }
                    DataRow row = newTable.NewRow();
                    for (int i = 0; i < newTable.Columns.Count; i++)
                    {
                        if (i == 0)
                        {
                            row[i] = "小计";
                            continue;
                        }
                        double total = 0;
                        for (int j = 0; j < newTable.Rows.Count; j++)
                        {
                            total += DataConverter.ToDouble(newTable.Rows[j][i]);
                        }
                        row[i] = total;
                    }
                    newTable.Rows.Add(row);
                    return newTable;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return new DataTable();
        }



    }
}
