
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
using Yamon.Module.App.Entity;
using Yamon.Module.App.DAL;
using Newtonsoft.Json;
using Yamon.Framework.Common;
using Yamon.Framework.MVC;
using Yamon.Module.SiteManage.DAL;



namespace Yamon.Module.App.WebApi
{
    /// <summary>
    /// 版本模型
    /// </summary>
    public partial class AppVersionController : _AppVersionController
    {
        [CheckPurview(1)]
        public ActionResult GetLastVersionInfo(string deviceId, string deviceType, string version)
        {
            try
            {
                AppVersionDAL versionDal = new AppVersionDAL();
                bool needUpdate = false;
                AppVersion appVersion = versionDal.GetLastVersion(deviceType, version,out needUpdate);
                hash["needupdate"] = needUpdate;
                hash["AppVersion"] = appVersion;
                hash["success"] = true;
            }
            catch (Exception ex)
            {
                hash["success"] = false;
                hash["message"] = ex.Message;
            }
            return Content(JsonConvert.SerializeObject(hash), "application/json");
        }
    }
}
