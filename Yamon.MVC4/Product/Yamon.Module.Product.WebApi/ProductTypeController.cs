
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
       [CheckPurview(0)]
    /// <summary>
    /// 商品类型
    /// </summary>
    public partial class ProductTypeController : _ProductTypeController
    {

      
        public ActionResult GetProductTypeByModels(int parentid=0, string models="Ticket")
        {
             ProductTypeDAL vp = new  ProductTypeDAL();
             List<ProductType> dt = vp.GetEntityList("Models=? AND ParentID=?", new object[] { models, parentid });
            return Content(JsonConvert.SerializeObject(dt));
        }
         public ActionResult GetProductTypeByModelsParentID()
         {
             ProductTypeDAL vp = new ProductTypeDAL();
             List<ProductType> dt = vp.GetEntityList("ParentID=0");
             return Content(JsonConvert.SerializeObject(dt));
         }
         [CheckPurview(param: "Models")]
         public override ActionResult TreeGrid_Models()
         {
             return base.TreeGrid_Models();
         }
     
    }
}
