
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
using Yamon.Module.Common;
using Yamon.Module.SiteManage.Entity;

namespace Yamon.Module.SiteManage.DAL
{
    /// <summary>
    /// 接口实体类
    ///</summary>
    public partial class APIDAL : _APIDAL
    {
        /// <summary>
        /// 保存权限项
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="purview">权限名</param>
        /// <returns></returns>
        public int SaveRolePurview(int appId, string purview)
        {
            List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();
            string sql = "";
            Parameters db = new Parameters();
            sql = "DELETE FROM SiteManage_APIPurview WHERE AppID=@AppID";
            db.AddInParameter("AppID", DbType.Int32, appId);
            sqllist.Add(new SqlParametersKeyValue(sql, db));
            string[] arrPurview = purview.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string apiId in arrPurview)
            {
                sql = "INSERT INTO SiteManage_APIPurview (AppID,APIID) VALUES(@AppID,@APIID)";
                db = new Parameters();
                db.AddInParameter("AppID", DbType.Int32, appId);
                db.AddInParameter("APIID", DbType.String, apiId);
                sqllist.Add(new SqlParametersKeyValue(sql, db));
            }
            return Db.ExecuteNonQueryTran(sqllist);
        }


        public string GetPurviewStringByAppID(int id)
        {
            return Db.ExecuteStringSqlEx("select APIID from SiteManage_APIPurview where AppID=?", id);
        }

        public ArrayList GetPurviewListByAppID(int id)
        {
            return Db.ExecuteArrayListSqlEx("select APIID from SiteManage_APIPurview where AppID=?", id);
        }
        public ArrayList GetPurviewListByAppKey(string appKey)
        {
            return Db.ExecuteArrayListSqlEx("select APIID from SiteManage_APIPurview where AppID=(select AppID from SiteManage_Applications where AppKey=?)", appKey);
        }

        public string GetAPIIDByUrl(string url)
        {
            API api = GetEntityModel("Url=?", new object[] { url });
            return api == null ? "" : api.APIID;
        }

        public bool HasPurview(string appKey, string apiId)
        {
            ArrayList purview = GetPurviewListByAppKey(appKey);
            if (purview.Contains(apiId))
            {
                return true;
            }
            return false;
        }
        public string GetChildIds(string apiId)
        {
            DataTable menuTable = GetAllEntityTable();
            TreeHelper treeHelper = new TreeHelper("APIID", "APIName", "OrderID", "ParentID");
            DataTable menuTreeTable = treeHelper.GetTreeDataTable(menuTable, "");
            DataRow[] parentMenu = menuTreeTable.Select("APIID='" + apiId + "'");
            string childMenuds = "";
            if (parentMenu.Length > 0)
            {
                childMenuds = parentMenu[0]["AllChildID"].ToString();
            }
            childMenuds = string.IsNullOrEmpty(childMenuds) ? apiId : apiId + "," + childMenuds;
            return childMenuds;
        }

        public DataTable GetTreeDataTableByParentID(string parentId)
        {
            string childMenuds = GetChildIds(parentId);
            DataTable menuTable = GetEntityTable("APIID in ('" + childMenuds.Replace(",", "','") + "')");
            for (int i = 0; i < menuTable.Rows.Count; i++)
            {
                if (menuTable.Rows[i]["APIID"].ToString() == parentId)
                {
                    menuTable.Rows[i]["ParentID"] = "";
                    break;
                }
            }
            return menuTable;
        }


        public override int ImportDataFromDataSet(DataSet ds)
        {
            if (ds.Tables.Count == 1)
            {
                DataTable menuTable = ds.Tables[0];
                ArrayList menuIdList = new ArrayList();
                foreach (DataRow row in menuTable.Rows)
                {
                    if (!menuIdList.Contains(row["APIID"].ToString()))
                    {
                        menuIdList.Add(row["APIID"].ToString());
                    }
                }
                Db.ExecuteNonQuerySql(string.Format("Delete from SiteManage_API where APIID in('{0}')",
                    string.Join("','", menuIdList.ToArray())));
                ImportDataFromDataTable(menuTable);
                return 1;
            }
            return 0;
        }
    }
}
