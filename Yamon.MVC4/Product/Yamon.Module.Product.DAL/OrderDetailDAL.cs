
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
using System.Text.RegularExpressions;

namespace Yamon.Module.Product.DAL
{
    /// <summary>
    /// 订单实体类
    ///</summary>
    public partial class OrderDetailDAL : _OrderDetailDAL
    {

        public int GetMaxTicketID()
        {
            string sql = Db.GetSelectTopNSql("View_Product_OrderDetail", "OrderDetailID", "Models=?", "OrderDetailID desc", 1);
            string id = Db.GetSingleStringEx(sql,"Ticket");
            id = Regex.Replace(id, @"[^0-9]", "");
            return DataConverter.ToInt(id);
        }
    }
}
