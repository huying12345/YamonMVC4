using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Yamon.Framework.Common;
using Yamon.Framework.MVC;
using Yamon.Framework.NPOI;


namespace Yamon.Module.SiteManage.WebApi
{
   public class TableExcelController : BaseController
    {
       public void Export()
       {
           HttpContext.Response.ContentType = "text/plain";
           string tableName = RequestHelper.GetString("TableName").Trim().Replace(" ", "");
           string tableContent = RequestHelper.GetString("TableContent");
           string tableTitleName = RequestHelper.GetString("TableTitleName");
           string None = RequestHelper.GetString("None");
           //int TableNameTrue = RequestHelper.GetRequestInt("TableNameTrue", 0);
           DataTable DT = new DataTable();
           string[] arrTableTitleName;
           if (None == "None")
           {
               arrTableTitleName = tableTitleName.Replace("<br>\n", "").Replace("<br>", "").Replace("<br/>", "").Replace("\\n", "").Replace("\n", "").Replace("[\"", "").Replace("\"]", "").Split(new string[] { "\",\"" }, StringSplitOptions.None);
           }
           else
           {
               arrTableTitleName = tableTitleName.Replace("<br>\n", "").Replace("<br>", "").Replace("<br/>", "").Replace("\\n", "").Replace("\n", "").Replace("[\"", "").Replace("\"]", "").Split(new string[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
           }
           for (int i = 0; i < arrTableTitleName.Length; i++)
           {
               DT.Columns.Add(new DataColumn(arrTableTitleName[i].ToString(), typeof(string)));
           }
           //if (TableNameTrue == 1)//添加表头
           //{
           //    DataRow drow = DT.NewRow();
           //    drow[0] = TableName;
           //    DT.Rows.InsertAt(drow, 0);
           //    DT.AcceptChanges();
           //}
           string[] arrTableContent_rows;
           if (None == "None")
           {
               arrTableContent_rows = tableContent.Replace("[[\"", "").Replace("\"]]", "").Split(new string[] { "\"],[\"" }, StringSplitOptions.None);
           }
           else
           {
               arrTableContent_rows = tableContent.Replace("[[\"", "").Replace("\"]]", "").Split(new string[] { "\"],[\"" }, StringSplitOptions.RemoveEmptyEntries);
           }
           for (int i = 0; i < arrTableContent_rows.Length; i++)
           {
               DataRow row = DT.NewRow();
               string[] arrTableContent_columns = arrTableContent_rows[i].Split(new string[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
               for (int j = 0; j < arrTableContent_columns.Length; j++)
               {
                   row[j] = arrTableContent_columns[j].ToString();
               }
               DT.Rows.Add(row);
           }
           //    ExcelName =context.Server.UrlPathEncode(ExcelName);
           System.Web.HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
           string userAgent = System.Web.HttpContext.Current.Request.UserAgent.ToLower();
           if (userAgent.IndexOf("msie") != -1 || userAgent.IndexOf("rv:11.0") != -1)
           {
               tableName = StringHelper.UrlEncode(tableName);
           }
           //ExcelHelper.ExportXlsToDownload(DT, TableName + ".xls");

           DataSet ds = new DataSet();
           ds.Tables.Add(DT);
           ExcelHelper.ExportXlsToDownload(ds, tableName + ".xls");
           HttpContext.Response.Write("");
           HttpContext.Response.End();
       }
    }
}
