
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
using Yamon.Framework.Common.DataBase;
using Yamon.Module.SiteManage.DAL;
using Yamon.Framework.MVC;



namespace Yamon.Module.Product.WebApi
{
    /// <summary>
    ///  体验卡
    /// </summary>
    public partial class ProductCardController : _ProductCardController
    {
        [CheckPurview(0)]
        public ActionResult GetProductCardByID()
        {
            string cardId = RequestHelper.GetString("CardSN");
            ProductCard model = dal.GetEntityModel("CardSN = ? and Status = 'Normal'", new object[] { cardId });
            if (model != null)
            {
                ProductCard newModel = dal.GetModelShowValue(model);
                hash["data"] = newModel;
                hash["success"] = true;
            }
            return Content(JsonConvert.SerializeObject(hash)); 
        }

        [CheckPurview(0)]
        public ActionResult RefundCard()
        {
            string cardId = RequestHelper.GetString("CardSN");
            if (!string.IsNullOrEmpty(cardId))
            {
                ProductCard model = dal.GetEntityModel("CardSN = ? and Status = 'Normal'", new object[] { cardId });
                if (model != null)
                {
                    ProductCardRecord cardRecord=new ProductCardRecord();
                    cardRecord.IsCharge = 1;
                    cardRecord.Money = model.Balance*-1;
                    cardRecord.Times = model.Times*-1;
                    cardRecord.CardID = model.CardID;
                    cardRecord.CardNo = model.CardNo;
                    cardRecord.CardSN = model.CardSN;
                    cardRecord.MemberID = model.MemberID;
                    cardRecord.TradeType = "3";
                    cardRecord.UserID = CookieHelper.GetCookieInt("UserID");
                    cardRecord.Remarks = "退卡";
                    cardRecord.TradeTime = DateTime.Now;
                    List<SqlParametersKeyValue> kv = new List<SqlParametersKeyValue>();
                    kv.Add(new ProductCardRecordDAL().GetInsertByModelSql(cardRecord));
                    model.Status = "CardBacked";
                    model.UpdateTime = DateTime.Now;
                    model.Balance = 0;
                    model.Times = 0;
                    kv.Add(dal.GetUpdateByModelSql(model));
                    dal.Db.ExecuteNonQueryTran(kv);
                    hash["message"] = "已成功退卡！";
                    hash["success"] = true;
                }
                else
                {
                    hash["message"] = "退卡失败！该卡不存在！";
                    hash["success"] = false;
                }
            }
            else
            {
                hash["message"] = "卡号不能为空！";
                hash["success"] = false;
            }
            
            return Content(JsonConvert.SerializeObject(hash));
        }




    }
}
