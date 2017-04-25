
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



namespace Yamon.Module.Product.Web.Controllers
{
    /// <summary>
    /// Product_ProductInfo
    /// </summary>
    public partial class ProductInfoController : _ProductInfoController
    {
        [CheckPurview(param: "Models")]
        public ActionResult CreateOrder()
        {
            ProductDiscountDAL discountDal = new ProductDiscountDAL();
            float defaultDiscount = 1;
            ViewBag.DiscountOptions = discountDal.GetDiscountOptions(RequestHelper.GetString("Models"), out defaultDiscount);
            ViewBag.DefaultDiscount = defaultDiscount;
            return View();
        }

        [CheckPurview(param: "Models")]
        public ActionResult CreateOrder1()
        {
            ProductDiscountDAL discountDal = new ProductDiscountDAL();
            float defaultDiscount = 1;
            ViewBag.DiscountOptions = discountDal.GetDiscountOptions(RequestHelper.GetString("Models"), out defaultDiscount);
            ViewBag.DefaultDiscount = defaultDiscount;
            return View();
        }

        [CheckPurview(0)]
        public ActionResult OrderInfoList()
        {
            return View();
        }

    }
}
