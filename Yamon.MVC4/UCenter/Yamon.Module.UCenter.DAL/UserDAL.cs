
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
    /// 用户模型实体类
    ///</summary>
    public partial class UserDAL : _UserDAL
    {

        #region 重写方法

        public override int InsertByModel(object obj)
        {
            User user = (User)obj;
            if (user.RoleID == null)
            {
                return base.InsertByModel(obj);
            }
            List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();
            sqllist.Add(base.GetInsertByModelSql(obj));
            UserRoleDAL userRoleDal = new UserRoleDAL();
            List<SqlParametersKeyValue> userRoleSqlList = userRoleDal.GetUpdateUserRoleSqlList(user.UserID.Value,
                user.RoleID);
            sqllist.AddRange(userRoleSqlList);
            return Db.ExecuteNonQueryTran(sqllist);
        }

        public override int UpdateByModel(object obj)
        {
            User user = (User)obj;
            if (user.RoleID == null)
            {
                return base.UpdateByModel(obj);
            }
            List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();
            sqllist.Add(base.GetUpdateByModelSql(obj));
            UserRoleDAL userRoleDal = new UserRoleDAL();
            List<SqlParametersKeyValue> userRoleSqlList = userRoleDal.GetUpdateUserRoleSqlList(user.UserID.Value,
                user.RoleID);
            sqllist.AddRange(userRoleSqlList);
            return Db.ExecuteNonQueryTran(sqllist);
        }

        public override User GetModelValue(User model)
        {
            RoleDAL roleDal = new RoleDAL();
            if (model.UserID != null)
            {
                model.RoleID = roleDal.GetRoleByUserID(model.UserID.Value);
            }

            return base.GetModelValue(model);
        }

        #endregion
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginname">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="logintype">登录方式</param>
        /// <returns></returns>
        public int UserLogin(string loginname, string password, int logintype)
        {

            StringBuilder sql = new StringBuilder("Status=0");

            switch (logintype)
            {
                case 0:
                    {
                        sql.Append(" AND UserID=?");
                        break;
                    }
                case 1:
                    {
                        sql.Append(" AND UserName=?");
                        break;
                    }
                case 2:
                    {
                        sql.Append(" AND Email=?");
                        break;
                    }
                default:
                    return -1;
            }
            List<User> userList = GetEntityList(sql.ToString(), new[] { loginname }, "UserID");
            if (userList.Count > 0)
            {
                User user = userList[0];
                if (user.PassWord.ToLower() == password.ToLower())
                {

                    User updateUser = new User
                    {
                        LastLoginIP = RequestHelper.GetIP(),
                        LastLoginTime = DateTime.Now,
                        UserID = user.UserID,
                        OnLineStatus = 1,
                        LoginTimes = user.LoginTimes + 1
                    };
                    UpdateByModel(updateUser);
                    return user.UserID.Value;
                }
                else
                {
                    return -2;
                }
            }
            return -1;
        }


        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="userId"></param>
        public void LoginOut(int userId)
        {
            User updateUser = new User
            {
                LastLogoutTime = DateTime.Now,
                UserID = userId,
                OnLineStatus = 0,
            };
            UpdateByModel(updateUser);
            SessionHelper.Set("UserID", null);
            CookieHelper.WriteCookie("UserID", null, -1);
            CookieHelper.WriteCookie("UserName", null, -1);
            CookieHelper.WriteCookie("Email", null, -1);
            CookieHelper.WriteCookie("TrueName", null, -1);
            CookieHelper.WriteCookie("SkinName", null, -1);
            CookieHelper.WriteCookie("DepartmentID", null, -1);
            CookieHelper.WriteCookie("DepartmentName", null, -1);
            CookieHelper.WriteCookie("RoleIDList", null, -1);

        }



        /// <summary>
        /// 本接口函数用于更新用户资料。更新资料需验证用户的原密码是否正确，除非指定 ignoreoldpw 为 true。如果只修改 Email 不修改密码，可让 newpw 为空；同理如果只修改密码不修改 Email，可让 email 为空。 
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="username">用户名</param>
        /// <param name="oldpw">旧密码</param>
        /// <param name="newpw">新密码</param>
        /// <param name="email">Email</param>
        /// <param name="ignoreoldpw">是否忽略旧密码
        ///true:忽略，更改资料不需要验证密码
        ///false:(默认值) 不忽略，更改资料需要验证密码
        ///</param>
        /// <returns>
        ///1:更新成功
        ///0:没有做任何修改
        ///-1:旧密码不正确
        ///-4:Email 格式有误
        ///-5:Email 不允许注册
        ///-6:该 Email 已经被注册
        ///-7:没有做任何修改
        ///-8:该用户受保护无权限更改
        ///</returns>
        public int UserEdit(int uid, string username, string oldpw, string newpw, string email, bool ignoreoldpw)
        {

            int count = 0;
            //验证密码是否正确
            if (!ignoreoldpw)
            {
                int result = UserLogin(uid.ToString(), oldpw, 0);//先验证用户id和密码是否正确
                if (result < 0)
                {
                    return result;//密码不正确
                }
            }
            User updateUser = new User();
            updateUser.UserID = uid;
            if (!string.IsNullOrEmpty(email))
            {
                count++;
                int isEmail = UserCheckEmail(email);
                if (isEmail == 0 || isEmail == uid)
                {
                    updateUser.Email = email;
                }
                else
                {
                    return 0;
                }
            }
            if (!string.IsNullOrEmpty(newpw))
            {
                updateUser.PassWord = newpw;
                count++;
            }
            if (!string.IsNullOrEmpty(username))
            {
                int isUserName = UserCheckName(username);
                if (isUserName == 0 || isUserName == uid)
                {
                    updateUser.UserName = username;
                }
                else
                {
                    return 0;
                }
            }
            int output = UpdateByModel(updateUser);
            return output;
        }


        /// <summary>
        /// 检测邮件是否已存在
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>Count</returns>
        public int UserCheckEmail(string email)
        {
            if (DataValidator.IsEmail(email))
            {
                string sql = "select UserID from UC_User where Email=@Email";
                Parameters db = new Parameters();
                db.AddInParameter("Email", DbType.String, email);
                return Db.GetSingleInt(sql, db);
            }
            return -1;
        }
        /// <summary>
        /// 检测用户名是否已存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>Count</returns>
        public int UserCheckName(string username)
        {
            if (DataValidator.IsValidUserName(username))
            {
                string sql = "select UserID from UC_User where UserName=@UserName";
                Parameters db = new Parameters();
                db.AddInParameter("UserName", DbType.String, username);
                return Db.GetSingleInt(sql, db);
            }
            return -1;
        }

        /// <summary>
        /// 根据角色编号获取用户列表
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="isIn">是否返回该角色的用户</param>
        /// <param name="orderBy"><排序/param>
        /// <returns></returns>
        public DataTable GetListByRoleID(string roleId, int isIn, string orderBy)
        {
            string where = "Status=0";
            UserRoleDAL userRoleDal = new UserRoleDAL();
            string userIds = userRoleDal.GetUserListStringByRoleID(roleId);
            if (userIds == "")
            {
                userIds = "0";
            }
            if (isIn == 0)
            {
                where += "AND UserID Not in(" + userIds + ")";
            }
            else
            {
                where += "AND UserID in(" + userIds + ")";
            }
            DataTable modellist = GetEntityTable(where, new object[] { }, orderBy);
            return modellist;
        }

        public override bool ExistsByField(string fieldName, object value)
        {
            var sql = "SELECT COUNT(1) FROM UC_User WHERE Status=0 AND " + fieldName + "=?";
            return Db.ExistsSqlEx(sql, value, value);
        }

        public override bool ExistsByField(string fieldName, object value, object id)
        {
            var sql = "SELECT COUNT(1) FROM UC_User WHERE Status=0 AND UserID<>? AND " + fieldName + "=?";
            return Db.ExistsSqlEx(sql, id, value);
        }
    }
}
