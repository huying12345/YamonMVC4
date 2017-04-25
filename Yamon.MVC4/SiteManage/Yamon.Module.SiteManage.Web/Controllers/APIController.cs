
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Yamon.Framework.DAL;
using Yamon.Module.SiteManage.Entity;
using Yamon.Module.SiteManage.DAL;
using Newtonsoft.Json;
using Yamon.Framework.Common;
using Yamon.Framework.Common.DataBase;
using Yamon.Framework.Common.IO;
using Yamon.Framework.MVC;
using Yamon.Module.SiteManage.DAL;



namespace Yamon.Module.SiteManage.Web.Controllers
{

    /// <summary>
    /// 接口
    /// </summary>
    public partial class APIController : _APIController
    {
        [CheckPurview(0)]
        public ActionResult DocIndex(int appId = 0, string id = "")
        {
            return APITool(appId, id);
        }

        [CheckPurview(0)]
        public ActionResult APITool(int appId = 0, string id = "")
        {
            int totalRows = 0;
            List<API> modelList = dal.GetAllEntityList("APIID,APIName,ParentID,OrderID,APIType,Status");
            List<API> newModelList = modelList.Select(model => dal.GetModelGridShowValue(model)).ToList();
            ViewBag.APIList = dal.ModelListToTree(newModelList);
            ViewBag.APIID = id;
            API api = dal.GetModelByID(id);
            if (api == null)
            {
                api = dal.GetEntityModel("APIType=1");
            }
            api = dal.GetModelShowValue(api);
            if (api != null)
            {
                ViewBag.APIID = api.APIID;
            }
            int userId = CookieHelper.GetCookieInt("UserID");
            ApplicationDAL appDal = new ApplicationDAL();
            List<Application> appList = appDal.GetMyApp(userId);
            ViewBag.AppList = appList;
            if (appList.Count == 0)
            {
                throw new Exception("您没有接口应用！");
            }

            if (appId == 0)
            {
                appId = appList[0].AppID.Value;
            }
            ViewBag.AppID = appId;
            ViewBag.AppInfo = appList.FindLast(o => o.AppID == appId);

            ViewBag.MyAPIList = dal.GetPurviewListByAppID(appId);
            return View(api);
        }

        [CheckPurview(0)]
        public ActionResult GetAPIContent(string appId)
        {
            ApplicationDAL appDal = new ApplicationDAL();
            Application app = appDal.GetCacheEntityModelByID(appId);
            if (app == null)
            {
                hash["message"] = "该应用不存在!";
                return Json(hash);
            }
            if (app.UserID != CookieHelper.GetCookieInt("UserID"))
            {
                hash["message"] = "该应用不属于您!";
                return Json(hash);
            }
            string requestType = RequestHelper.GetString("RequestType");
            string url = RequestHelper.GetString("Url");
            string signFields = RequestHelper.GetString("SignFields");
            string[] arrSignFields = signFields.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string notSignFields = RequestHelper.GetString("NotSignFields");
            string[] arrNotSignFields = notSignFields.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
            for (int i = 0; i < arrSignFields.Length; i++)
            {
                if (!paramDictionary.ContainsKey(arrSignFields[i]))
                {
                    paramDictionary.Add(arrSignFields[i], RequestHelper.GetString(arrSignFields[i]));
                }
            }
            StringBuilder postString = new StringBuilder();

            for (int i = 0; i < arrNotSignFields.Length; i++)
            {
                postString.Append("&" + arrNotSignFields[i] + "=" + StringHelper.UrlDecode(RequestHelper.GetString(arrNotSignFields[i])));
            }
            WebApiHelper apiHelper = new WebApiHelper(app.AppKey, app.AppSecretKey);
            string result = "";
            if (requestType == "POST")
            {
                result = apiHelper.Post(url, paramDictionary, postString.ToString());
            }
            else if (requestType == "GET")
            {
                if (!url.Contains("?"))
                {
                    url = url + "?";
                }
                result = apiHelper.Get(url + postString, paramDictionary);
            }
            return Content(PraseToJson(result));
        }

        private string PraseToJson(string str)
        {
            var tabIndex = 0;
            for (int i = 0; i < str.Length; i++)
            {
                var cr = str[i];

                if (cr == '{' || cr == '[')
                {
                    var prestr = str.Substring(0, i);
                    var strsuff = str.Substring(i + 1, str.Length - i - 1);
                    str = prestr + cr + "\n" + getSpace(tabIndex + 1) + strsuff;

                    i += (1 + 2 * (tabIndex + 1));
                    tabIndex++;
                }
                else if (cr == '}' || cr == ']')
                {
                    var prestr = str.Substring(0, i);
                    var strsuff = str.Substring(i + 1, str.Length - i - 1);
                    str = prestr + "\n" + getSpace(tabIndex - 1) + cr + strsuff;

                    i += (1 + 2 * (tabIndex - 1));
                    tabIndex--;

                }
                else if (cr == ',')
                {
                    var prestr = str.Substring(0, i + 1);
                    var strsuff = str.Substring(i + 1, str.Length - i - 1);
                    str = prestr + "\n" + getSpace(tabIndex) + strsuff;
                    i += (1 + 2 * tabIndex);
                }
            }

            return str.Trim();
        }

        private static string getSpace(int num)
        {
            string result = string.Empty;
            for (int i = 0; i < num; i++)
            {
                result += "  ";
            }

            return result;
        }

        public ActionResult SetAPIPurview(int id)
        {
            ViewBag.APIList = dal.GetPurviewStringByAppID(id);
            return View();
        }

        [CheckPurview("SiteManage_API_Edit")]
        public ActionResult UploadImage()
        {
            Hashtable hashtable = new Hashtable();
            hashtable["success"] = 0;
            HttpPostedFileBase file = Request.Files["editormd-image-file"];
            string url = "/UploadFiles/APIImages/" + DateTime.Now.ToString("yyyMMdd") + "/";
            string savePath = RequestHelper.GetMapPath("~/" + url); //保存路径
            if (!IOHelper.IsExist(savePath, FsoMethod.Folder))
            {
                IOHelper.Create(savePath, FsoMethod.Folder);
            }
            if (file == null)
            {
                hashtable["message"] = "请选择要确定上传的图片！";
            }
            else
            {
                if (file.FileName.LastIndexOf(".") != -1)
                {
                    string fileFix = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1);
                    string saveFileName = Guid.NewGuid() + "." + fileFix;
                    if (!("|gif|jpg|jpeg|png|bmp|").ToLower().Contains(fileFix.ToLower()))
                    {
                        hashtable["message"] = "请确定上传的文件扩展名为gif|jpg|jpeg|png|bmp！";
                    }
                    else
                    {
                        file.SaveAs(savePath + saveFileName);
                        hashtable["success"] = 1;
                        hashtable["url"] = url + saveFileName;
                    }
                }
            }
            return Json(hashtable);
        }

        [CheckPurview("SiteManage_API_Edit")]
        public ActionResult GetEntityFields(string entityName)
        {
            List<string> list = entityName.Split('.').ToList();
            list.RemoveAt(list.Count - 1);
            string assemblyPath = string.Join(".", list);
            object objType = Assembly.Load(assemblyPath).CreateInstance(entityName); //反射创建
            if (objType != null)
            {
                Type t = objType.GetType(); //获得该类的Type
                List<ColumnInfo> colList = new List<ColumnInfo>();
                foreach (PropertyInfo pi in t.GetProperties())
                {
                    string displayName = "";
                    var nameAttr = pi.GetCustomAttributes(typeof (DisplayNameAttribute), false);
                    if (nameAttr.Length > 0)
                    {
                        DisplayNameAttribute displayNameAttribute = nameAttr[0] as DisplayNameAttribute;
                        if (displayNameAttribute != null && !string.IsNullOrEmpty(displayNameAttribute.DisplayName))
                        {
                            displayName = displayNameAttribute.DisplayName;
                        }
                    }
                    string typeName = "string";
                    if (pi.PropertyType.ToString().Contains("System.Int"))
                    {
                        typeName = "int";
                    }
                    else if (pi.PropertyType.ToString().Contains("System.Double"))
                    {
                        typeName = "double";
                    }
                    else if (pi.PropertyType.ToString().Contains("System.DateTime"))
                    {
                        typeName = "datetime";
                    }
                    colList.Add(new ColumnInfo()
                    {
                        ColumnName = pi.Name,
                        Description = displayName,
                        TypeName = typeName
                    });
                }
                hash["success"] = true;
                hash["rows"] = colList;
            }
            else
            {
                hash["message"] = "找不到该实体类";
            }
            return Content(JsonConvert.SerializeObject(hash),"application/json");
        }
    }
}
