
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
    ///  体验卡
    /// </summary>
    public partial class ProductCardController : _ProductCardController
    {

        public ActionResult Card(string Type)
        {
            switch(Type){
                case "Charge":
                    {
                        ViewBag.Title = "充值";
                        break;
                    }
                case "Consume":
                    {
                        ViewBag.Title = "消费";
                        break;
                    }
                case "":
                    {
                        ViewBag.Title = "读卡";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            ViewBag.Type = Type;
            string formPath = SiteCommon.GetCustomPage("~/Areas/Product/Views/ProductCard/Card.cshtml");
            return View(formPath);
        }

    }
}
