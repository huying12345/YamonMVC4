
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
using Yamon.Module.SiteManage.Entity;
using Yamon.Module.SiteManage.DAL;
using Newtonsoft.Json;
using Yamon.Framework.Common;
using Yamon.Framework.MVC;
using Yamon.Module.SiteManage.DAL;



namespace Yamon.Module.SiteManage.Web.Controllers
{
    /// <summary>
    /// 版本记录表
    /// </summary>
    public partial class VersionInfoController : _VersionInfoController
    {
        [CheckPurview(0)]
        public ActionResult Version()
        {
            ViewBag.VersionList = dal.GetAllEntityList("","VersionID desc");
            return View();
        }
    }
}
