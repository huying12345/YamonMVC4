using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yamon.Framework.Common;
using Yamon.Framework.Common.DataBase;
using Yamon.Framework.DAL;
using Yamon.Framework.DBUtility;
using Yamon.Module.SiteManage;
using Yamon.Module.SiteManage.DAL;
using Yamon.Module.SiteManage.Entity;

namespace Yamon.Module.UCenter.DAL
{
    public class RolePurviewDAL : _RolePurviewDAL
    {
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="purview"></param>
        /// <returns></returns>
        public int DelPurview(string roleId, string purview)
        {
            string sql = string.Format("DELETE FROM {0} WHERE RoleID=@RoleID AND Purview=@Purview", TableName);
            Parameters db = new Parameters();
            db.AddInParameter("RoleID", DbType.String, roleId);
            db.AddInParameter("Purview", DbType.String, purview);
            return Db.ExecuteNonQuerySql(sql);
        }



        /// <summary>
        /// 获取菜单权限列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetRolePurviewList()
        {
            return GetAllEntityTable();
        }

        /// <summary>
        /// 保存权限项
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="purview">权限名</param>
        /// <returns></returns>
        public int SaveRolePurview(string roleId, string purview)
        {
            List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();
            string sql = "";
            Parameters db = new Parameters();
            sql = string.Format("DELETE FROM {0} WHERE RoleID=@RoleID", TableName);
            db.AddInParameter("RoleID", DbType.String, roleId);
            sqllist.Add(new SqlParametersKeyValue(sql, db));
            string[] arrPurview = purview.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrPurview.Length; i++)
            {
                sql = string.Format("INSERT INTO {0} (RoleID,Purview) VALUES(@RoleID,@Purview)", TableName);
                db = new Parameters();
                db.AddInParameter("RoleID", DbType.String, roleId);
                db.AddInParameter("Purview", DbType.String, arrPurview[i]);
                sqllist.Add(new SqlParametersKeyValue(sql, db));
            }
            this.RemoveCache();
            return Db.ExecuteNonQueryTran(sqllist);
        }

        /// <summary>
        /// 保存权限项
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="purview">权限名</param>
        /// <returns></returns>
        public int SaveRolePurviewByPurview(string roleId, string purview)
        {
            List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();
            string sql = "";
            Parameters db = new Parameters();
            sql = string.Format("DELETE FROM {0} WHERE Purview=@Purview", TableName);
            db.AddInParameter("Purview", DbType.String, purview);
            sqllist.Add(new SqlParametersKeyValue(sql, db));
            string[] arrRoleId = roleId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrRoleId.Length; i++)
            {
                sql = string.Format("INSERT INTO {0} (RoleID,Purview) VALUES(@RoleID,@Purview)", TableName);
                db = new Parameters();
                db.AddInParameter("RoleID", DbType.String, arrRoleId[i]);
                db.AddInParameter("Purview", DbType.String, purview);
                sqllist.Add(new SqlParametersKeyValue(sql, db));
            }
            this.RemoveCache();
            return Db.ExecuteNonQueryTran(sqllist);
        }

        #region 根据权限项配置岗位
        /// <summary>
        /// 根据权限项获取角色列表
        /// </summary>
        /// <param name="purview"></param>
        /// <returns></returns>
        public string GetRoleListByPurview(string purview)
        {
            return Db.ExecuteStringSqlEx("select RoleID from UC_RolePurview where Purview=?", purview);
        }


        public ArrayList GetPurviewArrayListByRoleID(string roleId)
        {
            string sql = "select Purview from UC_RolePurview where RoleID=?";
            return Db.ExecuteArrayListSqlEx(sql, roleId);
        }

        /// <summary>
        /// 根据角色取权限
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public ArrayList GetPurviewListByRoleIDNoCache(string roleId)
        {
            return Db.ExecuteArrayListSql(string.Format("select Purview from UC_RolePurview where RoleID in('{0}')", roleId.Replace(",", "','")));
        }

        /// <summary>
        /// 根据角色取权限
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public ArrayList GetPurviewListByRoleID(string roleId)
        {
            string cacheKey = this.CacheKeyPrefix + "GetPurviewListByRoleID_" + roleId;
            object objType = CacheHelper.Get(cacheKey);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = GetPurviewListByRoleIDNoCache(roleId);
                    CacheHelper.Insert(cacheKey, objType);// 写入缓存
                }
                catch
                { }
            }
            return objType as ArrayList;
        }

        /// <summary>
        /// 是否有权限 
        /// </summary>
        /// <param name="pageCode"></param>
        /// <returns></returns>
        public bool HasPurviewByRoleID(string roleId, string pageCode)
        {
            ArrayList purview = GetPurviewListByRoleID(roleId);
            MenuDAL menuDal = new MenuDAL();
            List<Menu> menuList = menuDal.GetMyMenuList(roleId, purview);
            List<string> arrPageCode = pageCode.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (SiteCommon.PurviewDictionary.ContainsKey(pageCode))
            {
               arrPageCode.AddRange(SiteCommon.PurviewDictionary[pageCode]);
            }
            foreach (var code in arrPageCode)
            {
                Menu menu = menuList.FindLast(o => o.PageCode == code);
                if (menu != null)
                {
                    return true;
                }
                ToolBarDAL toolBarDal = new ToolBarDAL();
                List<ToolBar> toolBarList = toolBarDal.GetMyToolBarList(purview);
                ToolBar toolbar = toolBarList.FindLast(o => o.PageCode == code);
                if (toolbar != null)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}