
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
using Yamon.Module.Product.Entity;
using Yamon.Module.Product.DAL;
using Newtonsoft.Json;
using Yamon.Framework.Common;
using Yamon.Module.SiteManage.DAL;
using Yamon.Framework.MVC;
using Yamon.Framework.Common.DataBase;
using Yamon.Module.SiteManage.Entity;
using Yamon.Framework.NPOI;



namespace Yamon.Module.Product.WebApi
{
    /// <summary>
    /// 订单明细视图
    /// </summary>
    public partial class VOrderDetailController : _VOrderDetailController
    {
        [CheckPurview(param: "Models")]
        public override ActionResult Grid1_Models()
        {
            return base.Grid1_Models();
        }

        [CheckPurview(0)]
        public ActionResult ExportToExcelR(string filterId = "", int showAllField = 1, int showValue = 1)
        {
            try
            {
                int totalRows = 0;
                List<VOrderDetail> list = GetGridList( filterId, showValue,out totalRows);
                DataTable modelTable = list.ToDataTable();
                modelTable = ControllerHelper.ToExcelDataTable(modelTable, showValue);
                string[] fieldList = { "OrderDetailID", "OrderID", "ProductNo", "ProductName", "TypeName", "Price", "Num", "SalePrice", "TotalMoney", "MemberID", "Status", "PayStatus", "CreateTime", "PayType", "CreateUserID" };
                for (int i = 0; i <fieldList.Length; i++)
			    {
                    modelTable.Columns[fieldList[i]].SetOrdinal(i);
			    }
                ArrayList arrayList = new ArrayList();
                foreach (DataColumn col in modelTable.Columns)
                {
                    if (!fieldList.Contains(col.ColumnName))
                    {
                        arrayList.Add(col.ColumnName);
                    }
                }
                DictDataDAL dictDatadal = new DictDataDAL();
                List<DictData> dictData = dictDatadal.GetEntityList("DictTypeID='ce7932da-a2cb-4366-9c7a-6ae9aadc9e4f'");
                DataTable newModelsList;
                DataSet ds = new DataSet();
                for (int i = 0; i < dictData.Count; i++)
                {
                    newModelsList = modelTable.Clone();
                    DataRow[] dr = modelTable.Select("Models like '" + dictData[i].Name+"'");
                    if (dr.Length > 0)
                    {
                        for (int j = 0; j < dr.Length; j++)
                        {
                            newModelsList.ImportRow(dr[j]);
                        }
                        
                        DataRow newRow = newModelsList.NewRow();
                        newRow["OrderDetailID"] = "合计";
                        newRow["Price"] = newModelsList.Compute("SUM(Price)", "true").ToString();
                        newRow["Num"] = newModelsList.Compute("SUM(Num)", "true").ToString();
                        newRow["SalePrice"] = newModelsList.Compute("SUM(SalePrice)", "true").ToString();
                        newRow["TotalMoney"] = newModelsList.Compute("SUM(TotalMoney)", "true").ToString();
                        newModelsList.Rows.Add(newRow);

                        foreach (DataColumn item in newModelsList.Columns)
                        {
                            if (fieldList.Contains(item.ColumnName))
                            {
                                item.ColumnName = dal.GetDisplayName(item.ColumnName);
                            }
                        }

                        foreach (string s in arrayList)
                        {
                            newModelsList.Columns.Remove(s);
                        }
                        newModelsList.TableName = dictData[i].Name;
                        ds.Tables.Add(newModelsList);
                    }
                }
                ExcelHelper.ExportXlsToDownload(ds, "VOrderDetail.xls");
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
                hash["success"] = false;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }
    }
}
