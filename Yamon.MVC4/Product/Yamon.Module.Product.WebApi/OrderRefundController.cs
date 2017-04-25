
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



namespace Yamon.Module.Product.WebApi
{
    /// <summary>
    /// 订单退票
    /// </summary>
    public partial class OrderRefundController : _OrderRefundController
    {
        [CheckPurview(param: "Models")]
        public override ActionResult Create(OrderRefund model, bool returnData = false)
        {
            return base.Create(model, returnData);
        }

        [CheckPurview(0)]
        public ActionResult GetOrderInfoList(string id = "")
        {
            VOrderDetailDAL vp = new VOrderDetailDAL();
            //or ProductNo=? or OrderID=?
            List<VOrderDetail> dt = vp.GetEntityList(" DetailStatus = 0 and  OrderDetailID =? ", new object[] { id, id, id });
            return Content(JsonConvert.SerializeObject(dt));
        }


        [CheckPurview(0)]
        public ActionResult GetGoodOrderInfoList(string productno = "", string orderid = "")
        {
            VOrderDetailDAL vp = new VOrderDetailDAL();
            List<VOrderDetail> dt = vp.GetEntityList(" DetailStatus = 0 and ProductNo=? and OrderID=? ", new object[] { productno, orderid });
            return Content(JsonConvert.SerializeObject(dt));
        }
        [CheckPurview(0)]
        public ActionResult Audit(string ids, int status)
        {
            string[] arrId = ids.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrId.Length; i++)
            {
                OrderRefund refund = dal.GetModelByID(arrId[i]);
                if (refund != null && refund.Status == 0)
                {
                    refund.Status = status;
                    dal.UpdateByModel(refund);
                    dal.RefundOrder(refund);
                }
            }
            hash["success"] = true;
            return Content(JsonConvert.SerializeObject(hash), "application/json");
        }

        [CheckPurview(0)]
        public ActionResult CheckPwd(string password, string models)
        {
            dynamic config = SystemConfigDAL.Config;
            string pwd = "";
            if (models == "Good")
            {
                pwd = config.GoodPassword;
            }
            else if (models == "Food")
            {
                pwd = config.FoodPassword;
            }
            else if (models == "Ticket")
            {
                pwd = config.TicketPassword;
            }
            else if (models == "Playgroud")
            {
                pwd = config.PlaygroudPassword;
            }
            if (password == pwd)
            {
                hash["success"] = true;
            }
            return Content(JsonConvert.SerializeObject(hash), "application/json");
        }

    }
}
