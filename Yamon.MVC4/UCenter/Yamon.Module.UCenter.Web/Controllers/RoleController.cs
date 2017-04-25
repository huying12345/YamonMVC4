
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
using Yamon.Framework.MVC;

using Yamon.Module.SiteManage.DAL;


namespace Yamon.Module.UCenter.Web.Controllers
{
    /// <summary>
    /// 角色模型
    /// </summary>
    public partial class RoleController : _RoleController
    {
        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ActionResult SetRolePurview(string roleId)
        {
            ViewBag.RoleID = roleId;
            RoleDAL roleDal = new RoleDAL();
            ViewData["RoleList"] = roleDal.GetAllEntityList();
            return View();
        }

        public ActionResult SetUserRole(string roleId)
        {
            return View();
        }

        /// <summary>
        /// 设置菜单权限
        /// </summary>
        /// <returns></returns>
        public ActionResult MenuRolePurview()
        {
            RoleDAL roleDal = new RoleDAL();
            ViewBag.RoleList = roleDal.GetAllEntityList();
            return View();
        }

    }
}
