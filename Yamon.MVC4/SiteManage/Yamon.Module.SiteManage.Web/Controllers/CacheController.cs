using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using Yamon.Framework.MVC;

namespace Yamon.Module.SiteManage.Web.Controllers
{
    public class CacheController : BaseController
    {
        // GET: SmartForm/Cache
        public ActionResult Index()
        {
            return View();
        }
    }
}