
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
    /// 预约
    /// </summary>
    public partial class ProductBookController : _ProductBookController
    {

       [CheckPurview(0)]
        public override ActionResult Create(ProductBook model, bool returnData = false)
        {

            model.MemberID = DataConverter.ToInt(ViewBag.MemberID);
            if (model.MemberID == 0)
            {
                throw new Exception("请先登录！");
            }
            return base.Create(model, returnData);
        }


    }
}
