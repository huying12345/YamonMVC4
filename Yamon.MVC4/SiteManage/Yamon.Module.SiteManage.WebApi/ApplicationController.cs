
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
using Yamon.Framework.Common.JSPackerCrypto;
using Yamon.Framework.MVC;
using Yamon.Module.SiteManage.DAL;



namespace Yamon.Module.SiteManage.WebApi
{
    /// <summary>
    /// 应用
    /// </summary>
    public partial class ApplicationController : _ApplicationController
    {
        [NoCheckLogin]
        public ActionResult GetTokenScript(string apikey)
        {
            //if (!string.IsNullOrEmpty(CookieHelper.GetCookie(apikey + "__Token")))
            //{
            //    return Content("var __token='';");
            //}
            //int userId = CookieHelper.GetCookieInt(apikey + "__UserId");
            int userType = RequestHelper.GetInt("UserType");
            string token = TokenHelper.GetToken(apikey, userType, 0);
            ECMAScriptPacker jsPacker = new ECMAScriptPacker();
            token = jsPacker.Pack("var __token='" + token + "';");
            CookieHelper.WriteCookie(apikey + "__Token", "1", 59);
            return Content(token);
        }
    }
}
