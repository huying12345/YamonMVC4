using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Yamon.Framework.Common;
using Yamon.Framework.MVC;

namespace Yamon.Module.SiteManage.WebApi
{
    public class PinyinController : BaseController
    {
        /// <summary>
        /// 获取全拼
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ActionResult GetPinyin(string key)
        {
            return Content(PinyinHelper.GetPinyin(key));
        }

        /// <summary>
        /// 获取简拼
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ActionResult GetShortPinyin(string key)
        {
            return Content(PinyinHelper.GetShortPinyin(key));
        }
    }
}
