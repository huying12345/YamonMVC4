
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

namespace Yamon.Module.Product.DAL
{
    /// <summary>
    ///  体验卡实体类
    ///</summary>
    public partial class ProductCardDAL : _ProductCardDAL
    {


        public override int InsertByModel(object obj)
        {

            ProductCard model = (ProductCard)obj;
            IsExistsByCardID(model);
            List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();
            SqlParametersKeyValue sql1 = base.GetInsertByModelSql(obj);
            sqllist.Add(sql1);
            ProductCardRecordDAL productCardRecordDal = new ProductCardRecordDAL();
            ProductCardRecord record = new ProductCardRecord();
            record.CardID = GetMaxID();
            record.CardNo = model.CardNo;
            record.CardSN = model.CardSN;
            record.TradeType = "1";
            record.TradeTime = DateTime.Now;
            record.MemberID = model.MemberID;
            record.Money = model.Balance;
            record.Remarks = "发卡";
            record.Times = model.Times;
            record.UserID = model.CreateUserID;
            record.IsCharge = 1;
            SqlParametersKeyValue sql2 = productCardRecordDal.GetInsertByModelSql(record);
            sqllist.Add(sql2);
            return Db.ExecuteNonQueryTran(sqllist);
        }

        /// <summary>
        /// 判断卡是否存在
        /// </summary>
        /// <param name="cardSN"></param>
        public void IsExistsByCardID(ProductCard card)
        {
            bool isExists = Db.ExistsSqlEx("select count(1) from Product_Card where CardSN=? AND Status='Normal'", card.CardSN);
            if (isExists)
            {
                throw new Exception("该卡已存在，请换张卡");
            }

            isExists = Db.ExistsSqlEx("select count(1) from Product_Card where CardNo=? AND Status='Normal'", card.CardNo);
            if (isExists)
            {
                throw new Exception("该卡号已存在");
            }
            if (card.CardType == "4")
            {
                if (card.MemberID == null && string.IsNullOrEmpty(card.MemberID.ToString()))
                {
                    throw new Exception("会员编号不能为空！");
                }
                isExists = Db.ExistsSqlEx("select count(1) from Product_Card where MemberID=? AND Status='Normal'",
                    card.MemberID);
                if (isExists)
                {
                    throw new Exception("该会员已经发卡！");
                }
            }
        }
    }
}
