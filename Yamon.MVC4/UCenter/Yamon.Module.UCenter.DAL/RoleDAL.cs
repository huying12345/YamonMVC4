
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
    /// 角色模型实体类
    ///</summary>
    public partial class RoleDAL : _RoleDAL
    {

        /// <summary>
        /// 根据用户编号得到角色列表
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public DataTable GetRoleListByUserID(int userId)
        {
            return Db.ExecuteDataTableSql(string.Format("select a.UserID,a.RoleID,b.RoleName,b.Description from UC_UserRole a, UC_Role b where a.RoleID=b.RoleID and a.UserID={0} order by b.OrderID", userId));
        }

        /// <summary>
        /// 取得用户的角色ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetRoleByUserID(int userId)
        {
            return Db.ExecuteStringSql(string.Format("select RoleID from  UC_UserRole where UserID={0}", userId));
        }

        /// <summary>
        /// 取得用户的角色ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetRoleNameByUserID(int userId)
        {
            return Db.ExecuteStringSql(string.Format("select RoleName from UC_Role where RoleID in (select RoleID from UC_UserRole where UserID={0})", userId));
        }

        public override void AfterBatchDelete(params object[] param)
        {
            DeleteRole(param[0].ToString());
            base.AfterBatchDelete(param);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <returns></returns>
        public int DeleteRole(string roleId)
        {
            if (string.IsNullOrEmpty(roleId))
            {
                return 1;
            }
            ArrayList sqllist = new ArrayList();
            sqllist.Add(string.Format("Delete from UC_Role where RoleID in({0})", roleId));
            sqllist.Add(string.Format("Delete from UC_UserRole where RoleID in({0})", roleId));
            sqllist.Add(string.Format("Delete from UC_RolePurview where RoleID in({0})", roleId));
            return Db.ExecuteNonQueryTran(sqllist);
        }


        #region 权限菜单Grid树
  

        /// <summary>
        /// 获取角色选项
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public string GetRoleOption(string roleId)
        {
            StringBuilder sb = new StringBuilder();
            DataTable roleDt = GetAllEntityTable();
            for (int i = 0; i < roleDt.Rows.Count; i++)
            {
                string selected = "";
                if (("," + roleId + ",").Contains("," + roleDt.Rows[i]["RoleID"].ToString() + ","))
                {
                    selected = "selected";
                }
                sb.AppendLine(string.Format("<option value=\"{0}\" {1}>{2}</option>", roleDt.Rows[i]["RoleID"].ToString(), selected, roleDt.Rows[i]["RoleName"].ToString()));
            }
            return sb.ToString();
        }
        #endregion
    }
}
