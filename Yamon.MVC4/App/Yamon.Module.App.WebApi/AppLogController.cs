
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
    /// 日志模型
    /// </summary>
    public partial class AppLogController : _AppLogController
    {
        /// <summary>
        /// 插入App日志
        /// </summary>
        /// <returns></returns>
        [CheckPurview(1)]
        public ActionResult InsertDeviceLog(AppLog logInfo, string deviceId, int returnVersionInfo)
        {
            try
            {
                logInfo = dal.GetInsertModelValue(logInfo);
                int result = dal.InsertByModel(logInfo);
                bool isSuccess = result == 1;
                hash["success"] = isSuccess;
                AppDeviceDAL appDeviceDal = new AppDeviceDAL();
                appDeviceDal.Insert(RequestHelper.NameValue);
                if (isSuccess && returnVersionInfo == 1)
                {
                    AppVersionDAL versionDal = new AppVersionDAL();
                    bool needUpdate = false;
                    AppVersion version = versionDal.GetLastVersion(RequestHelper.NameValue.GetString("DeviceType"),
                        RequestHelper.NameValue.GetString("Version"),out needUpdate);
                    hash["needupdate"] = needUpdate;
                    if (needUpdate && version.VersionType == 2)
                    {
                        hash["forceUpdate"] = true;
                    }
                    else
                    {
                        hash["forceUpdate"] = false;
                    }
                    hash["AppVersion"] = version;
                }
            }
            catch (Exception ex)
            {
                hash["success"] = false;
                hash["message"] = ex.Message;
            }
            return Json(hash);
        }
    }
}
