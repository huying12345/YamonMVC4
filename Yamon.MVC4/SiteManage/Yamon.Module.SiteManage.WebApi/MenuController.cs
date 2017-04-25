
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
using Yamon.Module.Common;
using Yamon.Module.SiteManage.DAL;



namespace Yamon.Module.SiteManage.WebApi
{
    /// <summary>
    /// 菜单模型
    /// </summary>
    public partial class MenuController : _MenuController
    {
        public virtual ActionResult GetMenuTreeJson()
        {
            StringBuilder _jsonsb = new StringBuilder();
            try
            {
                MyNameValueCollection nv = RequestHelper.GetRequestNameValueCollection();
                MenuDAL dal = new MenuDAL();
                DataTable table;
                string filterId = nv.GetString("FilterID", "");
                string value = nv.GetString("Value");
                switch (filterId)
                {
                    default:
                        {
                            table = dal.GetAllListByStatus();
                            break;
                        }
                }
                TreeHelper treeHelper = new TreeHelper("MenuID", "MenuName", "OrderID", "ParentID");
                string[] attributes = RequestHelper.GetString("Attributes").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string append = "";
                append = "{\"id\":\"\",\"text\":\"根目录\"},";
                string json = treeHelper.GetTreeJson(table, "", value, append, attributes);
                json = json.Replace("\"id\":", "\"state\": \"closed\",\"id\":");
                _jsonsb.Append(json);
            }
            catch (Exception ex)
            {
                _jsonsb = new StringBuilder();
                _jsonsb.Append("{\"total\":\"-1\",\"msg\":" + StringHelper.ToJson(ex.Message) + ",\"rows\":[]}");
            }
            return Content(_jsonsb.ToString());
        }

        [CheckPurview(0)]
        public ActionResult GetMenuList()
        {
            List<Menu> menuList = dal.GetEntityList("Enabled=1");
            hash["success"] = true;
            hash["data"] = menuList;
            return Content(JsonConvert.SerializeObject(hash), "application/json");
        }



        public ActionResult ExportToExcel(string id)
        {
            hash["success"] = true;
            DataSet ds = dal.GetMenuDataSet(id);
            ExcelHelper.ExportXlsToDownload(ds, "Menu.xls");
            return Content(JsonConvert.SerializeObject(hash), "application/json");
        }
    }
}
