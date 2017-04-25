
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
using Yamon.Module.UCenter.Entity;
using Yamon.Module.UCenter.DAL;
using Newtonsoft.Json;
using Yamon.Framework.Common;
using Yamon.Framework.MVC;
using Yamon.Module.SiteManage.DAL;



namespace Yamon.Module.UCenter.WebApi
{
    /// <summary>
    /// 角色权限
    /// </summary>
    public partial class RolePurviewController : _RolePurviewController
    {
        [CheckPurview(1)]
        public ActionResult GetMyPurview()
        {
            string purview = dal.Db.ExecuteStringSqlEx("select Purview from UC_RolePurview where RoleID=?", CookieHelper.GetCookie("RoleID"));
            hash["data"] = purview;
            hash["success"] = true;
            return Content(JsonConvert.SerializeObject(hash));
        }
    }
}
