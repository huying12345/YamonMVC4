
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
using Yamon.Framework.MVC;
using Yamon.Module.SiteManage.DAL;
using Yamon.Module.SiteManage.Entity;



namespace Yamon.Module.Product.Web.Controllers
{
    /// <summary>
    /// 订单信息
    /// </summary>
    public partial class OrderInfoController : _OrderInfoController
    {
        public override ActionResult Show(string id = "")
        {
            ViewBag.ID = id;
            ViewBag.DAL = dal;
            VOrderDetailDAL od = new VOrderDetailDAL();
            List<VOrderDetail> list = od.GetEntityList("OrderID=?", new object[] { id });
            ViewBag.List = list;

            OrderInfo model = dal.GetModelByID(id);
            model = dal.GetEditFormDefaultValue(model);
            model = dal.GetModelShowValue(model);
           
            return View( model);
         
        }

        [CheckPurview(param: "Models")]
        public override ActionResult Grid1_Models()
        {
            return base.Grid1_Models();
        }


        public  ActionResult Statistics()
        {
            return View();
        }

        public ActionResult Second()
        {
            return View();
        }

        public ActionResult Summary()
        {
            return View();
        }


        public ActionResult Payment()
        {
            DictDataDAL dataDal = new DictDataDAL();
            List<DictData> modellist = dataDal.GetEntityList("DictTypeID='ad69e049-5617-4845-95c8-78512de97406'");
            ViewBag.list = modellist;
            return View();
        }
    }
}
