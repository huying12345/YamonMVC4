
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
using Yamon.Module.Product.Entity;

namespace Yamon.Module.Product.DAL
{
    /// <summary>
    /// 商品信息实体类
    ///</summary>
    public partial class ProductInfoDAL : _ProductInfoDAL
    {

        public DataTable ProductInfoDataTable(double db, string id = "")
        {

            string sql = "select*from [View_Product_ProductInfo] where ProductInfoNo=?";
            DataTable dt = DbHelper.GetConn("UCenter").ExecuteDataTableSqlEx(sql,id);
            dt.Columns.Add("AfterPrice");
             dt.Columns.Add("AfterTotal");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //if (db< DataConverter.ToDouble(dt.Rows[i]["MinDiscountPercent"]))
                //{
                //    db = DataConverter.ToDouble(dt.Rows[i]["MinDiscountPercent"]);
                //}
                dt.Rows[i]["SalePrice"] = DataConverter.ToDouble(dt.Rows[i]["SalePrice"]).ToString("F2");
             
                //if (DataConverter.ToDouble(dt.Rows[i]["StockNum"]) > 0)
                //{
                //    dt.Rows[i]["AfterTotal"] = DataConverter.ToDouble(dt.Rows[i]["AfterPrice"]) * (DataConverter.ToDouble(dt.Rows[i]["StockNum"]));
                //}
                //else
                //{
                //    dt.Rows[i]["AfterTotal"] = DataConverter.ToDouble(dt.Rows[i]["AfterPrice"]) * 1;
                //}
              
            }
            return dt;
        }

    }
}
