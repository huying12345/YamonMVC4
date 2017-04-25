
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



namespace Yamon.Module.SiteManage.WebApi
{
    /// <summary>
    /// 工具栏模型
    /// </summary>
    public partial class ToolBarController : _ToolBarController
    {
        [CheckPurview("UCenter_Role_MenuRolePurview")]
        public ActionResult GetToolBarJsonByMenu()
        {
            ToolBarDAL menuDal = new ToolBarDAL();
            string menu = RequestHelper.GetString("id");
            string returnValue = menuDal.GetToolBarJsonByMenuID(menu);
            return Content(returnValue);
        }
    }
}
