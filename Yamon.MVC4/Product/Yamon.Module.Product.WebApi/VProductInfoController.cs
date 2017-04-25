
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
    /// 商品信息视图
    /// </summary>
    /// 
    [CheckPurview(0)]
    public partial class VProductInfoController : _VProductInfoController
    {
        [CheckPurview(0)]
        public ActionResult GetProductListByModels(string models = "Ticket")
        {
            VProductInfoDAL vp = new VProductInfoDAL();
            List<VProductInfo> dt = vp.GetEntityList("Models=?", new object[] { models });
            hash["success"] = true;
            hash["rows"] = dt;
            return Content(JsonConvert.SerializeObject(hash));
        }
        [CheckPurview(param: "Models")]

        public override ActionResult Grid1_Models()
        {
            return base.Grid1_Models();
        }

        [CheckPurview(pageCode: "Product_VProductInfo_Show")]
        public ActionResult GetEntityByNo(string id, string models)
        {
            VProductInfo model = dal.GetEntityModel("ProductInfoNo=? and Models=?", new object[] { id, models });
            if (model != null)
            {
                model = dal.GetModelShowValue(model);
                hash["data"] = model;
                hash["success"] = true;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }
    }
}
