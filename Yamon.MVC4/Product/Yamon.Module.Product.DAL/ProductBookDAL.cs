
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
using System;
using Newtonsoft.Json;

namespace Yamon.Module.Product.DAL
{
    /// <summary>
    /// 预约实体类
    ///</summary>
    public partial class ProductBookDAL : _ProductBookDAL
    {

        public override ProductBook GetInsertModelValue(ProductBook model)
        {


            model.CreateTime = DateTime.Now;
            model.ProductBookID = DateTime.Now.ToString("yyyyMMddHHmmss");
        
            return base.GetInsertModelValue(model);
        }
        public override int InsertByModel(object obj)
        {
            ProductBook model = (ProductBook)obj;

            List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();
            sqllist.Add(base.GetInsertByModelSql(obj));
          

            ProductBookDetailDAL productBookDetailDal = new ProductBookDetailDAL();
            string result = RequestHelper.GetString("json");

            List<ProductBookDetail> productBookDetailList = JsonConvert.DeserializeObject<List<ProductBookDetail>>(result);
            int ii = 0;
            for (int i = 0; i < productBookDetailList.Count; i++)
            {
                productBookDetailList[i] = productBookDetailDal.GetInsertModelValue(productBookDetailList[i]);
                if ( productBookDetailList[i].Num>0)
                {
                    double num = productBookDetailList[i].Num.Value;
                    for (int j = 0; j < num; j++)
                    {
                        ii++;
                        ProductBookDetail ticket = productBookDetailList[i];
                        ticket.ProductBookDetailID = DateTime.Now.ToString("yyyyMMddHHmmss")+ii;
                        ticket.Num = 1;
                        ticket.TotalMoney = ticket.SalePrice;
                        ticket.MakeTime = DataConverter.ToDate(ticket.MakeTime);
                        ticket.ProductBookID = model.ProductBookID;
                        sqllist.Add(productBookDetailDal.GetInsertByModelSql(ticket));
                    }
                }
              
             
            }
            return Db.ExecuteNonQueryTran(sqllist);
        }


    }
}
