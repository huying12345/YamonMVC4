
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
using System.Reflection;
using Yamon.Framework.DAL;
using Yamon.Module.Product.Entity;
using Yamon.Module.SiteManage.DAL;
using Yamon.Module.SiteManage.Entity;

namespace Yamon.Module.Product.DAL
{
    /// <summary>
    /// 商品模块配置实体类
    ///</summary>
    public partial class ProductConfigDAL : _ProductConfigDAL
    {
        /// <summary>
        /// 重写根据ID获取模型的方法
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public override ProductConfig GetModelByID(params object[] param)
        {
            SystemConfigDAL configDal = new SystemConfigDAL();
            DataTable configDt = configDal.GetEntityTable("Module='Product'");
            DataTable dt = DataTableHelper.ConvertDataTable(configDt);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0].ToObject<ProductConfig>();
            }
            return null;
        }

        public override int UpdateByModel(object obj)
        {
            DataTable configDt = GetEntityTable("Module='Product'");
            DataTable dt = DataTableHelper.ConvertDataTable(configDt);
            DataRow row = dt.NewRow();
            if (dt.Rows.Count > 0)
            {
                row = dt.Rows[0];
            }
            ProductConfig config = (ProductConfig)obj;
            BeforeByModelUpdate(obj);
            var type = obj.GetType();
            Parameters ps;
            List<SqlParametersKeyValue> list = new List<SqlParametersKeyValue>();
            int i = 0;
            string sql = "";
            foreach (PropertyInfo p in type.GetProperties())
            {
                if (p.Name == "ConfigKey" || p.Name == "ConfigValue" || p.Name == "Module" || p.Name.EndsWith("_ShowValue"))
                {
                    continue;
                }
                ps = new Parameters();
                ps.AddInParameter("ConfigKey", DbType.AnsiString, p.Name);
                ps.AddInParameter("ConfigValue", DbType.AnsiString, p.GetValue(obj, null));
                ps.AddInParameter("Module", DbType.AnsiString, config.Module);

                if (row.Table.Columns.Contains(p.Name))
                {
                    sql = "UPDATE SiteManage_Config SET ConfigValue=@ConfigValue where ConfigKey=@ConfigKey";
                }
                else
                {
                    sql = "INSERT INTO SiteManage_Config (ConfigValue,ConfigKey,Module) VALUES(@ConfigValue,@ConfigKey,@Module)";
                }
                list.Add(new SqlParametersKeyValue(sql, ps));
            }
            SystemConfigDAL configDal=new SystemConfigDAL();
            configDal.RemoveCache();
            return configDal.Db.ExecuteNonQueryTran(list);
        }

    }
}
