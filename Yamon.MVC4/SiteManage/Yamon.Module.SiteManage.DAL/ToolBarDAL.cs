
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
using Yamon.Module.SiteManage.Entity;

namespace Yamon.Module.SiteManage.DAL
{
    /// <summary>
    /// 工具栏模型实体类
    ///</summary>
    public partial class ToolBarDAL : _ToolBarDAL
    {

        /// <summary>
        /// 获取工具栏Json
        /// </summary>
        /// <param name="toolBar">工具栏</param>
        /// <param name="purview">权限</param>
        /// <returns></returns>
        public string GetToolBarPurviewJson(ToolBar toolBar, ArrayList purview)
        {
            StringBuilder sb = new StringBuilder();
            string check = "";
            if (purview.Contains(toolBar.ToolBarID))
            {
                check = " checked='checked'";
            }
            sb.AppendFormat("<input type='checkbox' id='Purview{0}' name='Purview' value='{1}' onclick='setToolPurview(this)' {3}/>{2}", toolBar.MenuID, toolBar.ToolBarID, toolBar.ToolBarName, check);
            return sb.ToString();
        }

        /// <summary>
        /// 根据菜单查找对应的工具栏选择框
        /// </summary>
        /// <param name="toolBarList"></param>
        /// <param name="menuId"></param>
        /// <param name="purview"></param>
        /// <returns></returns>
        public string GetToolBarPurviewJsonByMenuID(List<ToolBar> toolBarList, string menuId, ArrayList purview)
        {
            List<ToolBar> myList = toolBarList.Where(o => o.MenuID == menuId).OrderBy(o => o.OrderID).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (ToolBar model in myList)
            {
                sb.Append(GetToolBarPurviewJson(model, purview));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取所有站点的工具栏
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public virtual List<ToolBar> GetAllCacheModelList()
        {
            string cacheKey = this.CacheKeyPrefix + "GetAllCacheModelList";
            object toolbarList = CacheHelper.Get(cacheKey);
            if (toolbarList == null)
            {
                toolbarList = GetAllEntityList();
                CacheHelper.Insert(cacheKey, toolbarList);
            }
            return (List<ToolBar>)toolbarList;
        }


        public string GetToolBarJsonByMenuID(string menuId)
        {
            DataTable dt = Db.ExecuteDataTableSqlEx("Select ToolBarID as id,ToolBarName as text from SiteManage_MenuToolBar Where MenuID=? Order By OrderID", menuId);
            return dt.ToJson();
        }


        /// <summary>
        /// 插入默认工具栏
        /// </summary>
        /// <param name="toolBar"></param>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public int InsertToolBar(string toolBar, string menuId, string linkUrl)
        {
            if (string.IsNullOrEmpty(linkUrl) || string.IsNullOrEmpty(toolBar))
            {
                return 1;
            }
            string[] arrLink = linkUrl.TrimStart('/').Split('/');
            if (arrLink.Length < 2)
            {
                return 1;
            }
            string toolId = arrLink[0] + "_" + arrLink[1];
            string[] arrToolBar = toolBar.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<ToolBar> toolList = new List<ToolBar>();
            for (int i = 0; i < arrToolBar.Length; i++)
            {
                if (arrToolBar[i] == "New")
                {
                    ToolBar tool = new ToolBar
                    {
                        ToolBarID = Guid.NewGuid().ToString(),
                        ToolBarName = "新建",
                        ToolbarType = "Toolbar",
                        MenuID = menuId,
                        ClassName = "icon-add",
                        OnClick = "OpenDialog_InsertForm();",
                        PageCode = string.Format("{0}_Create", toolId),
                        OrderID = 1
                    };
                    toolList.Add(tool);

                }
                else if (arrToolBar[i] == "Update")
                {
                    ToolBar tool = new ToolBar
                    {
                        ToolBarID = Guid.NewGuid().ToString(),
                        ToolBarName = "修改",
                        ToolbarType = "Toolbar",
                        MenuID = menuId,
                        ClassName = "icon-edit",
                        OnClick = "OpenDialog_UpdateForm();",
                        PageCode = string.Format("{0}_Edit", toolId),
                        OrderID = 2
                    };
                    toolList.Add(tool);

                }
                else if (arrToolBar[i] == "BatchDelete")
                {
                    ToolBar tool = new ToolBar
                    {
                        ToolBarID = Guid.NewGuid().ToString(),
                        ToolBarName = "批量删除",
                        ToolbarType = "Toolbar",
                        MenuID = menuId,
                        ClassName = "icon-remove",
                        PageCode = string.Format("{0}_BatchDelete", toolId),
                        OnClick = "BatchDelete();",
                        OrderID = 3
                    };
                    toolList.Add(tool);
                }
                else if (arrToolBar[i] == "Show")
                {
                    ToolBar tool = new ToolBar
                    {
                        ToolBarID = Guid.NewGuid().ToString(),
                        ToolBarName = "查看",
                        ToolbarType = "Toolbar",
                        MenuID = menuId,
                        ClassName = "icon-remove",
                        PageCode = string.Format("{0}_Show", toolId),
                        OnClick = "OpenDialog_ViewForm();",
                        OrderID = 3
                    };
                    toolList.Add(tool);
                }
                else if (arrToolBar[i] == "Delete")
                {
                    ToolBar tool = new ToolBar
                    {
                        ToolBarID = Guid.NewGuid().ToString(),
                        ToolBarName = "删除",
                        ToolbarType = "Toolbar",
                        MenuID = menuId,
                        ClassName = "icon-remove",
                        PageCode = string.Format("{0}_Delete", toolId),
                        OnClick = "Delete();",
                        OrderID = 3
                    };
                    toolList.Add(tool);
                }
                else if (arrToolBar[i] == "Search")
                {
                    ToolBar tool = new ToolBar
                    {
                        ToolBarID = Guid.NewGuid().ToString(),
                        ToolBarName = "查询",
                        ToolbarType = "Toolbar",
                        MenuID = menuId,
                        ClassName = "icon-search",
                        OnClick = "ShowSearchFrm(true);",
                        OrderID = 4
                    };
                    toolList.Add(tool);
                }
            }
            return BatchInsertByModel(toolList);
        }


        public List<ToolBar> GetMyToolBarList(string cityId, string menuId, ArrayList purview)
        {
            List<ToolBar> toolBarList = GetAllCacheModelList();
            List<ToolBar> myList = toolBarList.Where(o => o.MenuID == menuId && ((o.ToolbarType == "CommonToolbar") || (purview.Contains(o.ToolBarID)))).OrderBy(o => o.OrderID).ToList();
            return myList;
        }

        public List<ToolBar> GetMyToolBarList(ArrayList purview)
        {
            string cityId = CookieHelper.GetCookie("CityID");
            List<ToolBar> toolBarList = GetAllCacheModelList();
            List<ToolBar> myList = toolBarList.Where(o => ((o.ToolbarType == "CommonToolbar") || (purview.Contains(o.ToolBarID)))).OrderBy(o => o.OrderID).ToList();
            return myList;
        }
    }
}
