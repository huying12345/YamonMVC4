
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
    /// 预约信息视图
    /// </summary>
    public partial class VProductBookDetailController : _VProductBookDetailController
    {
        [CheckPurview(0)]
        public ActionResult GetProductBookDetailList()
        {
            VProductBookDetailDAL vp = new VProductBookDetailDAL();
            List<VProductBookDetail> dt = vp.GetEntityList(" MemberID=? and MakeTime>=? order by ProductBookDetailID desc", new object[] { DataConverter.ToInt(ViewBag.MemberID), DataConverter.ToDate(DateTime.Now.ToString("yyyy-MM-dd")) });
            return Content(JsonConvert.SerializeObject(dt));
        }
         [CheckPurview(0)]
        public ActionResult GetProductBookDetailList1(string productBookID = "")
        {
            VProductBookDetailDAL vp = new VProductBookDetailDAL();
            string dtime = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            List<VProductBookDetail> dt = vp.GetEntityList(" ProductBookID=? and MakeTime=? order by ProductBookDetailID desc", new object[] { productBookID, dtime });
            return Content(JsonConvert.SerializeObject(dt));
        }
    }
}
