
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
    /// 验票记录表实体类
    ///</summary>
    public partial class TicketVisitLogDAL : _TicketVisitLogDAL
    {

        public int GetCheckTicketCount(string ticketId)
        {
            string sql = "select count(1) from Product_TicketVisitLog where TicketID=?";
            return Db.GetSingleIntEx(sql, ticketId);
        }


        public bool CheckTicketTime(string ticketId)
        {
            VOrderDetailDAL infoDal = new VOrderDetailDAL();
            VOrderDetail infoModel = infoDal.GetModelByID(ticketId);
            DateTime createTime = DataConverter.ToDate(infoModel.CreateTime);            
            return createTime.Date==DateTime.Now.Date ? true : false;
        }

    }
}
