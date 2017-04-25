
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
using Yamon.Framework.Common.Encrypt;
using Yamon.Framework.MVC;

using Yamon.Module.SiteManage.DAL;
using Yamon.Module.SiteManage.Entity;


namespace Yamon.Module.UCenter.Web.Controllers
{
    /// <summary>
    /// 用户模型
    /// </summary>
    public partial class UserController : _UserController
    {
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [CheckPurview(0)]
        public ActionResult ChangePwd()
        {
            return View();
        }

    }
}
