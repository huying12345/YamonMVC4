
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



namespace Yamon.Module.Product.Web.Controllers
{
    /// <summary>
    /// 订单退票
    /// </summary>
    public partial class OrderRefundController : _OrderRefundController
    {
        [CheckPurview(param: "Models")]
        public override ActionResult Create(string id = "")
        {
            return View();
        }
    }
}
