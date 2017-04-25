
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Linq.Expressions;
using System.Web.Mvc;
using Yamon.Framework.DAL;
using Yamon.Module.Product.Entity;
using Yamon.Module.Product.DAL;
using Newtonsoft.Json;
using Yamon.Framework.Common;
using Yamon.Module.SiteManage.DAL;
using Yamon.Framework.MVC;
using Yamon.Module.SiteManage.Entity;
using Yamon.Framework.NPOI;



namespace Yamon.Module.Product.WebApi
{
    /// <summary>
    /// 订单信息
    /// </summary>
    public partial class OrderInfoController : _OrderInfoController
    {
        [CheckPurview(0)]
        public ActionResult GetOrderInfo(string orderId)
        {
            OrderInfo orderInfo = dal.GetInfoByID(orderId);
            if (orderInfo == null)
            {
                hash["message"] = "找不到该订单！";
            }
            else
            {
                hash["success"] = true;
                hash["Order"] = orderInfo;
                VOrderDetailDAL detailDal = new VOrderDetailDAL();
                hash["OrderDetails"] = detailDal.GetEntityList("OrderID=?", new object[] { orderId });
            }
            return Content(JsonConvert.SerializeObject(hash));
            //return Json(hash,JsonRequestBehavior.AllowGet);
        }


        [CheckPurview(param: "Models")]
        public override ActionResult Grid1_Models()
        {
            return base.Grid1_Models();
        }

        [CheckPurview(0)]
        public ActionResult GetOrderInfoCount(string starTime, string endTime)
        {
            OrderInfoDAL od = new OrderInfoDAL();
            if (string.IsNullOrEmpty(starTime))
            {
                starTime = DateTime.Now.ToString("yyyy-MM-dd");
            }
            if (string.IsNullOrEmpty(endTime))
            {
                endTime = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
            }
            DataTable dt = od.GetCountDataTable(starTime, endTime);
            return Content(JsonConvert.SerializeObject(dt));
        }
        [CheckPurview(0)]
        public ActionResult GetOrderInfoCountList(string starTime, string endTime,string type)
        {
            OrderInfoDAL od = new OrderInfoDAL();
            if (string.IsNullOrEmpty(starTime))
            {
                starTime = DateTime.Now.ToString("yyyy-MM-dd");
            }
            if (string.IsNullOrEmpty(endTime))
            {
                endTime = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
            }
           
            DataTable dt = od.GetCountList(starTime, endTime);
            return Content(JsonConvert.SerializeObject(dt));
        }

        [CheckPurview(0)]
        public ActionResult GetToDayCountlist()
        {
            OrderInfoDAL od = new OrderInfoDAL();

            DataTable dt = od.GetToDayCount();
            return Content(JsonConvert.SerializeObject(dt));
        }
        [CheckPurview(0)]
        public ActionResult GetSecond()
        {
            OrderInfoDAL od = new OrderInfoDAL();
            DataTable dt = od.GetSecondList();
            return Content(JsonConvert.SerializeObject(dt));
        }

        [CheckPurview(0)]
        public ActionResult GetSecondTime(string startime, string endtime, string models)
        {
            OrderInfoDAL od = new OrderInfoDAL();
            DataTable dt = od.GetSecondTimeList(startime, endtime, models);
            return Content(JsonConvert.SerializeObject(dt));
        }

        [CheckPurview(0)]
        public ActionResult GetSummaryList(string startTime,string endTime)
        {
            DataTable dt = dal.GetSummaryList(startTime, endTime);
            return Content(dt.ToJson());
        }


        [CheckPurview(0)]
        public ActionResult GetOrderInfoByPay(string startTime,string endTime,string modelsList="")
        {
            try
            {
                DataTable dt = dal.GetOrderInfoByPay(startTime, endTime, modelsList);
                if (dt.Rows.Count > 0)
                {
                    hash["data"] = dt;
                    hash["success"] = true;
                }
                else
                {
                    hash["message"] = "没有数据！";
                    hash["success"] = false;
                }
            }
            catch (Exception ex)
            {
                hash["success"] = false;
                hash["message"] = ex.Message;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }

        [CheckPurview(0)]
        public ActionResult ExportToExcel(string startTime, string endTime, string modelsList = "")
        {
            try
            {
                DictDataDAL dataDal = new DictDataDAL();
                List<DictData> list = dataDal.GetEntityList("DictTypeID='ad69e049-5617-4845-95c8-78512de97406'");
                DataTable dt = dal.GetOrderInfoByPay(startTime, endTime, modelsList);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        dt.Columns[i].ColumnName = "日期";
                    }
                    if (i == dt.Columns.Count - 1)
                    {
                        dt.Columns[i].ColumnName = "合计";
                    }
                    for (int j = 0; j < list.Count; j++)
                    {
                        string value = dt.Columns[i].ColumnName.Replace("Pay_", "");
                        if (value.Equals(list[j].Value))
                        {
                            dt.Columns[i].ColumnName = list[j].Name;
                            break;
                        }
                    }
                }
                dt.TableName = "支付方式统计";
                ExcelHelper.ExportXlsToDownload(dt, "支付方式统计.xls");
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
                hash["success"] = false;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }
    }
}
