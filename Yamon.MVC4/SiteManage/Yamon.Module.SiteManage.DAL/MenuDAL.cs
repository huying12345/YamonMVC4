
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
    /// 菜单模型实体类
    ///</summary>
    public partial class MenuDAL : _MenuDAL
    {
        ToolBarDAL toolBarDal;
        public MenuDAL()
        {
            toolBarDal = new ToolBarDAL();
        }

        public override void AfterInsertByModelSuccess(object obj)
        {
            base.AfterInsertByModelSuccess(obj);
            Menu menu = (Menu)obj;
            toolBarDal.InsertToolBar(menu.Toolbar, menu.MenuID, menu.LinkUrl);
        }

        /// <summary>
        /// 获取所有站点的菜单
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public virtual DataTable GetAllListByStatus()
        {
            object[] searchParams = new object[] { };
            string where = "Enabled=1";
            return GetEntityTable(where, searchParams, "", 0);
        }

        public string GetPurivewGridTreeJson(ArrayList purview, bool showAll = false)
        {
            List<ToolBar> toolBarList = toolBarDal.GetAllCacheModelList();
            DataTable menuList = GetAllListByStatus();
            TreeHelper treeHelper = new TreeHelper("MenuID", "MenuName", "OrderID", "ParentID");
            menuList = treeHelper.GetTreeDataTable(menuList, "");
            StringBuilder sb = new StringBuilder();
            GetPurivewGridTreeJson(menuList, toolBarList, sb, "", 0, purview);
            return sb.ToString();
        }

        private void GetPurivewGridTreeJson(DataTable menuList, List<ToolBar> toolBarList, StringBuilder sb, string parentId, int level, ArrayList purview)
        {
            System.Data.DataRow[] dt = menuList.Select("ParentID='" + parentId + "'", "OrderID");
            string check = "";
            for (int i = 0; i < dt.Length; i++)
            {
                check = "";
                if (purview.Contains(dt[i]["MenuID"].ToString()))
                {
                    check = " checked='checked'";
                }
                if (i == 0 && level > 0)
                {
                    sb.AppendLine();
                    sb.AppendLine(",\"children\":[");
                }
                sb.Append("{");
                sb.AppendFormat("\"MenuID\":\"{0}\",", dt[i]["MenuID"].ToString());
                sb.AppendFormat("\"MenuName\":\"{0}\",", dt[i]["MenuName"].ToString());
                sb.AppendFormat("\"PageCode\":\"<input type='checkbox' id='Purview{0}' name='Purview' value='{0}' {1} onclick='setPurview(this)' AllChildID='{2}' ParentPath='{3}'/>\",", dt[i]["MenuID"].ToString(), check, dt[i]["AllChildID"].ToString(), dt[i]["ParentPath"].ToString());
                sb.AppendFormat("\"ToolBar\":\"{0}\"", toolBarDal.GetToolBarPurviewJsonByMenuID(toolBarList, dt[i]["MenuID"].ToString(), purview));
                GetPurivewGridTreeJson(menuList, toolBarList, sb, dt[i]["MenuID"].ToString(), level + 1, purview);
                if (i == dt.Length - 1)
                {
                    sb.AppendLine("}\r\n]");
                }
                else
                {
                    sb.AppendLine("},");
                }
            }
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <param name="purview"></param>
        /// <returns></returns>
        public List<Menu> GetMenuByPurview(string purview)
        {
            string where = string.Format("(MenuType=-1 OR MenuID in('{0}')) AND Enabled=1", purview.Replace(",", "','"));
            return GetEntityList(where, null, "OrderID");
        }
        public List<Menu> GetMyTreeMenuList(string roleId, ArrayList purviewList)
        {
            string cacheKey = this.CacheKeyPrefix + "_GetMyTreeMenuList_" + roleId;
            object objType = CacheHelper.Get(cacheKey);//从缓存读取
            if (objType == null)
            {
                List<Menu> menuList = GetMyMenuList(roleId, purviewList);
                menuList = menuList.Where(o => o.MenuType == 0 || o.MenuType == -1).ToList();
                menuList = ModelListToTree(menuList);
                objType = menuList;
                CacheHelper.Insert(cacheKey, menuList);// 写入缓存
            }
            return (List<Menu>)objType;
        }

        public List<Menu> GetMyMenuList(string roleId, ArrayList purviewList)
        {
            string cacheKey = this.CacheKeyPrefix + "_GetMyMenuList_" + roleId;
            object objType = CacheHelper.Get(cacheKey);//从缓存读取
            if (objType == null)
            {
                List<Menu> menuList = GetMenuByPurview(string.Join(",", purviewList.ToArray()));

                for (int i = 0; i < menuList.Count; i++)
                {
                    if (menuList[i].LinkUrl != null)
                    {
                        if (string.IsNullOrEmpty(menuList[i].PageCode))
                        {
                            string pageCode = menuList[i].LinkUrl.Replace("/", "_").TrimStart('_');
                            if (pageCode.Contains("?"))
                            {
                                pageCode = StringHelper.GetInterceptionString(pageCode, "", "?", false, false, false).Replace("?", "");
                            }
                            menuList[i].PageCode = pageCode;
                        }

                        string linkUrl = menuList[i].LinkUrl.Replace("/SF/", "/");
                        if (string.IsNullOrEmpty(linkUrl))
                        {
                            linkUrl = "/Home/Blank";
                        }

                        if (!linkUrl.StartsWith("http://"))
                        {
                            if (linkUrl.Contains("?"))
                            {
                                linkUrl = linkUrl + "&Frame=1&Menu=" + menuList[i].MenuID;
                            }
                            else
                            {
                                linkUrl = linkUrl + "?Frame=1&Menu=" + menuList[i].MenuID;
                            }
                        }
                        menuList[i].LinkUrl = linkUrl;
                    }
                }

                objType = menuList;
                CacheHelper.Insert(cacheKey, menuList);// 写入缓存
            }
            return (List<Menu>)objType;
        }



        public List<Menu> GetParentPathList(List<Menu> list, string menuId, bool includeSelf = true)
        {
            List<Menu> parentList = new List<Menu>();
            Menu menu1 = list.FindLast(o => o.MenuID == menuId);
            if (includeSelf)
            {
                parentList.Add(menu1);
            }
            Action<Menu> findParent = null;
            findParent = (info =>
            {
                var parentMenu = list.FindLast(o => o.MenuID == info.ParentID);
                if (parentMenu != null)
                {
                    parentList.Add(parentMenu);
                    findParent(parentMenu);
                }
            });
            //递归调用
            findParent(menu1);
            parentList.Reverse();
            return parentList;
        }

        public override void AfterBatchDelete(params object[] param)
        {
            List<SqlParametersKeyValue> sqlList = new List<SqlParametersKeyValue>();
            sqlList.Add(new SqlParametersKeyValue("Delete from SiteManage_Menu where ParentID not in(select a.MenuID from(select MenuID from SiteManage_Menu) as a) and ParentID<>''", param));
            sqlList.Add(new SqlParametersKeyValue("Delete from SiteManage_MenuToolBar where MenuID not in(select MenuID from SiteManage_Menu)"));
            Db.ExecuteNonQueryTran(sqlList);
            base.AfterBatchDelete(param);
        }

        public string GetChildIds(string menuId)
        {
            DataTable menuTable = GetAllEntityTable();
            TreeHelper treeHelper = new TreeHelper("MenuID", "MenuName", "OrderID", "ParentID");
            DataTable menuTreeTable = treeHelper.GetTreeDataTable(menuTable, "");
            DataRow[] parentMenu = menuTreeTable.Select("MenuID='" + menuId + "'");
            string childMenuds = "";
            if (parentMenu.Length > 0)
            {
                childMenuds = parentMenu[0]["AllChildID"].ToString();
            }
            childMenuds = string.IsNullOrEmpty(childMenuds) ? menuId : menuId + "," + childMenuds;
            return childMenuds;
        }

        public DataSet GetMenuDataSet(string menuId)
        {
            string childMenuds = GetChildIds(menuId);
            DataTable menuTable = GetEntityTable("MenuID in ('" + childMenuds.Replace(",", "','") + "')");
            for (int i = 0; i < menuTable.Rows.Count; i++)
            {
                if (menuTable.Rows[i]["MenuID"].ToString() == menuId)
                {
                    menuTable.Rows[i]["ParentID"] = "";
                    break;
                }
            }
            menuTable.TableName = "Menu";

            DataTable toolbarTable = toolBarDal.GetEntityTable("MenuID in ('" + childMenuds.Replace(",", "','") + "')");
            toolbarTable.TableName = "Toolbar";
            DataSet ds = new DataSet();
            ds.Tables.Add(menuTable);
            ds.Tables.Add(toolbarTable);
            return ds;
        }

        public override int ImportDataFromDataSet(DataSet ds)
        {
            if (ds.Tables.Count == 2)
            {
                DataTable menuTable = ds.Tables[0];
                ArrayList menuIdList = new ArrayList();
                foreach (DataRow row in menuTable.Rows)
                {
                    if (!menuIdList.Contains(row["MenuID"].ToString()))
                    {
                        menuIdList.Add(row["MenuID"].ToString());
                    }
                }
                DataTable toolbarTable = ds.Tables[1];


                ArrayList toobarIdList = new ArrayList();
                foreach (DataRow row in toolbarTable.Rows)
                {
                    if (!toobarIdList.Contains(row["ToolBarID"].ToString()))
                    {
                        toobarIdList.Add(row["ToolBarID"].ToString());
                    }
                }
                Db.ExecuteNonQuerySql(string.Format("Delete from SiteManage_Menu where MenuID in('{0}')",
                    string.Join("','", menuIdList.ToArray())));
                Db.ExecuteNonQuerySql(string.Format("Delete from SiteManage_MenuToolBar where ToolBarID in('{0}')",
                    string.Join("','", toobarIdList.ToArray())));
                ImportDataFromDataTable(menuTable);
                toolBarDal.ImportDataFromDataTable(toolbarTable);
                return 1;
            }
            return 0;
        }
    }
}
