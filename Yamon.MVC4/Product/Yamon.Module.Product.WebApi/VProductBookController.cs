
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
    /// 预约视图
    /// </summary>
    public partial class VProductBookController : _VProductBookController
    {
        [CheckPurview(0)]
        public ActionResult GetProductBookList()
        {
            VProductBookDAL vp = new VProductBookDAL();
            int menber = DataConverter.ToInt(ViewBag.MemberID);
            List<VProductBook> dt = vp.GetEntityList("MemberNo=? and MakeTime>=? order by MakeTime asc", new object[] { menber, DateTime.Now.ToString("yyyy-MM-dd") });
            return Content(JsonConvert.SerializeObject(dt));
        }
    }
}
