
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
using Newtonsoft.Json.Linq;



namespace Yamon.Module.Product.WebApi
{
    /// <summary>
    /// 验票记录表
    /// </summary>
    [CheckPurview(0)]
    public partial class TicketVisitLogController : _TicketVisitLogController
    {
        public ActionResult CheckTicket(string deviceId, string ticketId)
        {
            int isSuccess = 0;
            try
            {
                TicketVisitLogDAL logDal = new TicketVisitLogDAL();
                OrderDetailDAL detailDal = new OrderDetailDAL();
                OrderDetail od = detailDal.GetModelByID(ticketId);
                if (od == null)
                {
                    return hashResult("该门票不存在！");
                }
                int checkStationID = RequestHelper.GetInt("CheckStationID");
                bool isTimeOut = logDal.CheckTicketTime(ticketId);
                if (!isTimeOut)
                {
                    return hashResult("该门票已过期！");
                }
                int result = logDal.GetCheckTicketCount(ticketId);
                if (result == 0)
                {
                    isSuccess = 1;
                }

                TicketVisitLog log = new TicketVisitLog
                {
                    TicketID = ticketId,
                    LogType = "验票",
                    DeviceID = deviceId,
                    IsSuccess = isSuccess,
                    VisitTime = DateTime.Now,
                    CheckStationID = checkStationID
                };
                logDal.InsertByModel(log);
                if (result == 0)
                {
                    hash["success"] = true;
                }
                else
                {
                    hash["success"] = false;
                    hash["message"] = "已验证" + result + "次！";
                }
                hash["data"] = result;
            }
            catch (Exception ex)
            {
                hash["success"] = false;
                hash["message"] = ex.Message;
            }
            return Json(hash,JsonRequestBehavior.AllowGet);
        }


        private ActionResult hashResult(string msg, bool success = false)
        {
            hash["message"] = msg;
            hash["success"] = success;
            return Json(hash, JsonRequestBehavior.AllowGet);
        }

    }
}
