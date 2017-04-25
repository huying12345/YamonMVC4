
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



namespace Yamon.Module.Product.Web.Controllers
{
    /// <summary>
    /// 预约
    /// </summary>
    public partial class ProductBookController : _ProductBookController
    {
        public override ActionResult Show(string id = "")
        {
            ViewBag.ID = id;
            ViewBag.DAL = dal;
            VProductBookDetailDAL od = new VProductBookDetailDAL();
            List<VProductBookDetail> list = od.GetEntityList("ProductBookID=?", new object[] { id });
            ViewBag.List = list;

            ProductBook model = dal.GetModelByID(id);
            model = dal.GetEditFormDefaultValue(model);
            model = dal.GetModelShowValue(model);

            return View(model);

        }
    }
}
