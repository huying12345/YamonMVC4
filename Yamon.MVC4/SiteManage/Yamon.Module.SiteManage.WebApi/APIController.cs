
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
using Yamon.Framework.NPOI;
using Yamon.Module.SiteManage.DAL;



namespace Yamon.Module.SiteManage.WebApi
{
    /// <summary>
    /// 接口
    /// </summary>
    public partial class APIController : _APIController
    {
        public ActionResult SetAPIPurview(int id)
        {
            int result = dal.SaveRolePurview(id, RequestHelper.GetString("APIID"));
            hash["success"] = result > 0;
            return Json(hash);
        }

        [CheckPurview(0)]

        public ActionResult EditTree_APIType()
        {
            return TreeJsonByFilterID("API_APIType");
        }

        public ActionResult ExportToExcel(string id)
        {
            hash["success"] = true;
            DataTable ds = dal.GetTreeDataTableByParentID(id);
            ExcelHelper.ExportXlsToDownload(ds, "API.xls");
            return Content(JsonConvert.SerializeObject(hash), "application/json");
        }
    }
}
