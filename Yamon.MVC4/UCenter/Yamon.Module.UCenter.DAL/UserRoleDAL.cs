
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Yamon.Framework.DBUtility;
using System.Collections;
using Yamon.Framework.Common.DataBase;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using System.IO;
using System.Linq.Expressions;
using Yamon.Framework.DAL;
using Yamon.Module.UCenter.Entity;

namespace Yamon.Module.UCenter.DAL
{
    /// <summary>
    /// 用户角色实体类
    ///</summary>
    public partial class UserRoleDAL : _UserRoleDAL
    {
        /// <summary>
        /// 更新用户角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<SqlParametersKeyValue> GetUpdateUserRoleSqlList(int userId, string roleId)
        {
            List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();
            string sql = "";
            Parameters db = new Parameters();
            ArrayList purviews =
                Db.ExecuteArrayListSql(string.Format("SELECT RoleID FROM UC_UserRole WHERE UserID={0}", userId));
            string[] arrRoleIds = roleId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrRoleIds.Length; i++)
            {
                if (!purviews.Contains(arrRoleIds[i]))
                {
                    sql = "INSERT INTO UC_UserRole ([UserID],[RoleID]) VALUES(@UserID,@RoleID)";
                    db = new Parameters();
                    db.AddInParameter("UserID", DbType.Int32, userId);
                    db.AddInParameter("RoleID", DbType.Int32, arrRoleIds[i]);
                    sqllist.Add(new SqlParametersKeyValue(sql, db));
                }
                purviews.Remove(arrRoleIds[i]);

            }
            foreach (string s in purviews)
            {
                sql = "DELETE FROM UC_UserRole WHERE UserID=@UserID AND RoleID=@RoleID";
                db = new Parameters();
                db.AddInParameter("UserID", DbType.Int32, userId);
                db.AddInParameter("RoleID", DbType.Int32, s);
                sqllist.Add(new SqlParametersKeyValue(sql, db));
            }
            return sqllist;
        }

        public int UpdateUserRole(int userId, string roleId)
        {
            List<SqlParametersKeyValue> sqllist = GetUpdateUserRoleSqlList(userId, roleId);
            return Db.ExecuteNonQueryTran(sqllist);
        }

        /// <summary>
        /// 更新用户角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int UpdateUserRoleByUserID(string userId, string roleId)
        {
            List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();
            string sql = "";
            Parameters db = new Parameters();
            ArrayList purviews =
                Db.ExecuteArrayListSql(string.Format("SELECT UserID FROM UC_UserRole WHERE RoleID='{0}'", roleId));
            string[] arrPurview = userId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrPurview.Length; i++)
            {
                if (!purviews.Contains(DataConverter.ToInt(arrPurview[i])))
                {
                    sql = "INSERT INTO UC_UserRole (UserID,RoleID) VALUES(@UserID,@RoleID)";
                    db = new Parameters();
                    db.AddInParameter("UserID", DbType.Int32, DataConverter.ToInt(arrPurview[i]));
                    db.AddInParameter("RoleID", DbType.Int32, roleId);
                    sqllist.Add(new SqlParametersKeyValue(sql, db));
                }
                purviews.Remove(DataConverter.ToInt(arrPurview[i]));

            }
            foreach (string s in purviews)
            {
                sql = "DELETE FROM UC_UserRole WHERE UserID=@UserID AND RoleID=@RoleID";
                db = new Parameters();
                db.AddInParameter("UserID", DbType.Int32, s);
                db.AddInParameter("RoleID", DbType.Int32, roleId);
                sqllist.Add(new SqlParametersKeyValue(sql, db));
            }
            return Db.ExecuteNonQueryTran(sqllist);
        }


        public string GetUserListStringByRoleID(string roleId)
        {
            return
                Db.ExecuteStringSql(string.Format("select UserID from UC_UserRole where RoleID={0}", roleId.ToString()));
        }


        /// <summary>
        /// 设置用色的默认角色
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public int SetRoleDefault(int userId, int roleId)
        {
            ArrayList sqllist = new ArrayList();
            sqllist.Add(string.Format("update UC_UserRole set IsDefault=0 where UserID={0}", userId));
            sqllist.Add(string.Format("update UC_UserRole set IsDefault=1 where UserID={0} and RoleID={1}", userId,
                roleId));
            return Db.ExecuteNonQueryTran(sqllist);
        }


        /// <summary>
        /// 得到用户角色
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public string GetRoleIDByUser(int userID)
        {
            string sql = Db.GetSelectTopNSql("UC_UserRole", "RoleID",
                string.Format("UserID={0} and RoleID in (select RoleID  from UC_Role)", userID), " IsDefault desc", 1);
            return Db.GetSingleString(sql);
        }

    }
}
