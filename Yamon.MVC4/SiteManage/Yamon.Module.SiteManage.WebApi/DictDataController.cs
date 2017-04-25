
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
using Yamon.Module.SiteManage.DAL;
using Yamon.Framework.MVC;



namespace Yamon.Module.SiteManage.WebApi
{
    /// <summary>
    /// 数据字典
    /// </summary>
    public partial class DictDataController : _DictDataController
    {

        [CheckPurview(0)]
        public ActionResult GetModelsList(int dictType)
        {
            try
            {
                string where ="";
                switch (dictType)
                {
                    case 1:
                        {
                            where ="DictTypeID='ad69e049-5617-4845-95c8-78512de97406'";
                            break;
                        }
                    case 2:
                        {
                            where = "DictTypeID='ce7932da-a2cb-4366-9c7a-6ae9aadc9e4f'";
                            break;
                        }
                    default:
                        break;
                }
                DataTable dt = dal.GetEntityTable(where);
                hash["data"] = dt;
                hash["success"] = true;
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
                hash["success"] = false;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }
    }
}
