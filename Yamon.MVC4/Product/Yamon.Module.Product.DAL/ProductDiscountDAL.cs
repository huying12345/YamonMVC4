
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
    /// 商品折扣实体类
    ///</summary>
    public partial class ProductDiscountDAL : _ProductDiscountDAL
    {
        public override void AfterInsertByModelSuccess(object obj)
        {
            ProductDiscount model = (ProductDiscount)obj;
            UpdateIsDefault(model);
            base.AfterInsertByModelSuccess(obj);
        }

        public override void AfterUpdateByModelSuccess(object obj)
        {
            ProductDiscount model = (ProductDiscount)obj;
            UpdateIsDefault(model);
            base.AfterUpdateByModelSuccess(obj);
        }

        //更新其它的为默认
        private void UpdateIsDefault(ProductDiscount model)
        {
            if (model.IsDefault == 1)
            {
                string sql = "update Product_Discount set IsDefault=0 where Models=? AND DiscountID<>?";
                Db.ExecuteNonQuerySqlEx(sql, model.Models, model.DiscountID);
            }
        }



        /// <summary>
        /// 获取折扣选项
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string GetDiscountOptions(string models,out float defaultDiscount)
        {
            defaultDiscount = 1;
            StringBuilder stringBuilder = new StringBuilder();

            List<ProductDiscount> list = GetEntityList("Models=?", new object[] { models }, "OrderID");

            foreach (ProductDiscount discount in list)
            {
                if (discount.IsDefault == 1)
                {
                    defaultDiscount = DataConverter.ToFloat(discount.DiscountPercent);
                }
                stringBuilder.AppendLine(string.Format("<option value=\"{0}\"{1}>{2}</option>", discount.DiscountPercent, discount.IsDefault == 1 ? " selected" : "", discount.DiscountName));
            }
            return stringBuilder.ToString();
        }
    }
}
