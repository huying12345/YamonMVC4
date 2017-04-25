
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
using Newtonsoft.Json;
using System;

namespace Yamon.Module.Product.DAL
{
    /// <summary>
    /// 订单退票实体类
    ///</summary>
    public partial class OrderRefundDAL : _OrderRefundDAL
    {
        public override OrderRefund GetInsertModelValue(OrderRefund model)
        {

            model.RefundID = DateTime.Now.ToString("yyyyMMddHHmmss");
            model.RefundTime = DateTime.Now;
            model.RefundUserID = CookieHelper.GetCookieInt("UserID");
            // model.RefundMoney =DataConverter.ToDouble(RequestHelper.GetFormString("RefundMoney"));
            return base.GetInsertModelValue(model);
        }


        public int RefundOrder(OrderRefund model)
        {
          
            List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();

            string orderId = model.OrderID;
            string orderDetailId = model.OrderDetailID;

            OrderDetailDAL orderDetailDal = new OrderDetailDAL();
            OrderDetail od = orderDetailDal.GetModelByID(orderDetailId);

            od.Status = 1;
            sqllist.Add(orderDetailDal.GetUpdateByModelSql(od));

            OrderInfoDAL orderInfoDal = new OrderInfoDAL();
            OrderInfo oi = orderInfoDal.GetModelByID(orderId);

            List<OrderDetail> orderModel = orderDetailDal.GetEntityList(" OrderID = ? and Status = 0", new object[] { orderId });
            if (orderModel.Count >= 2)
            {
                oi.Status = 2;
            }
            else
            {
                oi.Status = 1;
            }
            sqllist.Add(orderInfoDal.GetUpdateByModelSql(oi));
            return Db.ExecuteNonQueryTran(sqllist);
        }

    }
}
