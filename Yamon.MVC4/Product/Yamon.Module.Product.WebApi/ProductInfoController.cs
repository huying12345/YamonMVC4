
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
    /// 商品信息
    /// </summary>
    public partial class ProductInfoController : _ProductInfoController
    {
         [CheckPurview(0)]
        public ActionResult GetProductInfoList(string id)
        {

            Double db = RequestHelper.GetFloat("discountpercent");
            ProductInfoDAL info = new ProductInfoDAL();
            DataTable dr = info.ProductInfoDataTable(db,id);
            return Content(dr.ToJson());
        }
       
    }
}
