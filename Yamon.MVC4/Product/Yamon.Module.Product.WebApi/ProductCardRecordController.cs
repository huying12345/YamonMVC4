
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
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
    /// 体验卡交易记录
    /// </summary>
    public partial class ProductCardRecordController : _ProductCardRecordController
    {
        ProductCardDAL _cardDal = new ProductCardDAL();

        /// <summary>
        /// 消费和充值
        /// </summary>
        /// <returns></returns>
        [CheckPurview(0)]
        public ActionResult ChargeCard()
        {
            string cardSn = RequestHelper.GetString("CardSN");
            float money = RequestHelper.GetRequestFloat("money",0);
            int times = RequestHelper.GetRequestInt("Times");
            string remarks = "";
            string type=RequestHelper.GetRequestString("type");
            try
            {
                ProductCardRecord cardRecord = new ProductCardRecord();
                ProductCard card = _cardDal.GetEntityModel("CardSN = ? and Status = 'Normal'", new object[] { cardSn });
                if (card != null)
                {
                    string chargeConsume = "";
                    bool isOk = true;
                    switch (type.ToLower())
                    {
                        case "charge":
                            {
                                card.Balance = money + card.Balance;
                                card.Times = times + card.Times;

                                cardRecord.TradeType = "1";
                                cardRecord.Money = money;
                                cardRecord.Times = times;
                                remarks = "充值";
                                chargeConsume = "充值成功！";
                                break;
                            }
                        case "consume":
                            {
                                if (card.Balance >= money)
                                {
                                    card.Balance = card.Balance - money;
                                }
                                else
                                {
                                    hash["message"] = "余额不足!";
                                    hash["success"] = false;
                                    isOk = false;
                                }
                                if (card.Times >= times)
                                {
                                    card.Times = card.Times - times;
                                }
                                else
                                {
                                    hash["message"] = "次数不足!";
                                    hash["success"] = false;
                                    isOk = false;
                                }
                                if (isOk)
                                {
                                    cardRecord.TradeType = "2";
                                    cardRecord.Money = -money;
                                    cardRecord.Times = -times;
                                    remarks = "消费";
                                    chargeConsume = "成功消费！";
                                }
                                break;
                            }
                    }
                    if (isOk)
                    {
                        List<SqlParametersKeyValue> kv = new List<SqlParametersKeyValue>();
                        card.UpdateTime = DateTime.Now;
                        
                        kv.Add(_cardDal.GetUpdateByModelSql(card));
                        cardRecord.IsCharge = 0;
                        cardRecord.CardID = card.CardID;
                        cardRecord.CardNo = card.CardNo;
                        cardRecord.CardSN = card.CardSN;
                        cardRecord.MemberID = card.MemberID;
                        cardRecord.TradeTime = DateTime.Now;
                        cardRecord.UserID = card.CreateUserID;
                        cardRecord.Remarks = remarks;
                        cardRecord.IsCharge = 1;
                        kv.Add(dal.GetInsertByModelSql(cardRecord));
                        dal.Db.ExecuteNonQueryTran(kv);
                        hash["message"] = chargeConsume;
                        hash["success"] = true;
                    }
                }
                else
                {
                    hash["message"] = "该卡不存在,无法充值或消费！";
                    hash["success"] = false;
                }
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
                hash["success"] = false;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }

        /// <summary>
        /// 获取交易记录明细
        /// </summary>
        /// <returns></returns>
        [CheckPurview(0)]
        public ActionResult GetProductCardRecordListByID()
        {
            string cardSN = RequestHelper.GetString("CardSN");
            ProductCard modelCard = _cardDal.GetEntityModel("CardSN = ? and Status = 'Normal'", new object[] { cardSN });
            try
            {
                if (modelCard != null)
                {
                    List<ProductCardRecord> modelList = dal.GetEntityList("CardSN = ? and IsCharge = 1", new object[] { cardSN }, "RecordID DESC");
                    List<ProductCardRecord> newModelList = modelList.Select(model => dal.GetModelGridShowValue(model)).ToList();
                    hash["data"] = newModelList;
                    hash["success"] = true;
                }
            }
            catch (Exception ex)
            {
                hash["data"] = ex.Message;
                hash["success"] = false;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }

    }
}
