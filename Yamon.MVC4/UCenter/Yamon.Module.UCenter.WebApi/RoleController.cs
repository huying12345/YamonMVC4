
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


namespace Yamon.Module.UCenter.WebApi
{
    /// <summary>
    /// 角色模型
    /// </summary>
    public partial class RoleController : _RoleController
    {

        /// <summary>
        /// 保存角色信息
        /// </summary>
        /// <returns></returns>
        [CheckPurview("UCenter_Role_SetUserRole")]
        public ActionResult SetUserRole(string roleId)
        {
            string userId = RequestHelper.GetRequestString("UserID");
            UserRoleDAL userRoleDal = new UserRoleDAL();
            int result = userRoleDal.UpdateUserRoleByUserID(userId.TrimEnd(','), roleId);
            Hashtable hash = new Hashtable();
            hash["success"] = result > 0 ? true : false;
            return Json(hash);
        }

        [CheckPurview("UCenter_Role_SetRolePurview")]
        public ActionResult GetRolePurivewTreeGridJson(string roleId)
        {
            StringBuilder jsonsb = new StringBuilder();

            RolePurviewDAL rpDal = new RolePurviewDAL();
            ArrayList purview = rpDal.GetPurviewArrayListByRoleID(roleId);

            MenuDAL menuDal = new MenuDAL();
            jsonsb.AppendLine("[");
            jsonsb.AppendLine(menuDal.GetPurivewGridTreeJson(purview, false));
            return Content(jsonsb.ToString());
        }

        /// <summary>
        /// 保存角色权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ActionResult SetRolePurview(string roleId)
        {
            string purview = RequestHelper.GetString("Purview");
            RolePurviewDAL rolePurviewDal = new RolePurviewDAL();
            int result = rolePurviewDal.SaveRolePurview(roleId, purview);
            Hashtable hash = new Hashtable();
            hash["success"] = result > 0 ? true : false;
            return Json(hash);
        }

        [CheckPurview("UCenter_Role_MenuRolePurview")]
        public ActionResult GetRoleListByPurview()
        {
            string purview = RequestHelper.GetString("Purview");
            RolePurviewDAL roleDal = new RolePurviewDAL();
            string result = roleDal.GetRoleListByPurview(purview);
            return Content(result);
        }


        /// <summary>
        /// 根据权限保存角色与权限关系
        /// </summary>
        /// <returns></returns>
       [CheckPurview("UCenter_Role_MenuRolePurview")]
        public ActionResult SaveRolePurviewByPurview()
        {
            string roleId = RequestHelper.GetRequestString("RoleID");
            string purview = RequestHelper.GetString("Purview");
            RolePurviewDAL roleDal = new RolePurviewDAL();
            int result = roleDal.SaveRolePurviewByPurview(roleId, purview);
            Hashtable hash = new Hashtable();
            hash["success"] = result > 0 ? true : false;
            return Json(hash);
        }
    }
}
