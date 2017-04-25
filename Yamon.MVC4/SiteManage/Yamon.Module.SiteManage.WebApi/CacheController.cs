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

namespace Yamon.Module.SiteManage.WebApi
{
    public class CacheController : BaseController
    {

        /// <summary>
        /// 获取缓存列表
        /// </summary>
        /// <returns></returns>
        [CheckPurview("SiteManage_Cache_Index")]
        public ActionResult CacheList()
        {
            StringBuilder jsonsb = new StringBuilder();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            jsonsb.Append("{\"total\":" + CacheHelper.CurrentCacheList.Count + ",\"rows\":");
            jsonsb.Append(jsSerializer.Serialize(CacheHelper.CurrentCacheList));
            jsonsb.Append("}");
            return Content(jsonsb.ToString());
        }


        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [CheckPurview("SiteManage_Cache_Index")]
        public ActionResult Del(string id)
        {
            string[] arrCacheName = id.Split(',');
            for (int i = 0; i < arrCacheName.Length; i++)
            {
                CacheHelper.Remove(arrCacheName[i]);
            }
            Hashtable hash = new Hashtable();
            hash["success"] = true;
            return Json(hash);
        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <returns></returns>
        [CheckPurview("SiteManage_Cache_Index")]
        public ActionResult Clear()
        {
            CacheHelper.Clear();
            Hashtable hash = new Hashtable();
            hash["success"] = true;
            return Json(hash);
        }
    }
}