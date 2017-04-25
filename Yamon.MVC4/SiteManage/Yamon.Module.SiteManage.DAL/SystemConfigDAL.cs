
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Yamon.Framework.DBUtility;
using System.Collections;
using System.Dynamic;
using Yamon.Framework.Common.DataBase;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Yamon.Framework.DAL;
using Yamon.Module.SiteManage.Entity;

namespace Yamon.Module.SiteManage.DAL
{
    /// <summary>
    /// 系统配置实体类
    ///</summary>
    public partial class SystemConfigDAL : _SystemConfigDAL
    {

        /// <summary>
        /// 获取系统配置
        /// </summary>
        public static ExpandoObject Config
        {
            get
            {
                SystemConfigDAL configDal = new SystemConfigDAL();
                string cacheKey = configDal.CacheKeyPrefix + "Config";
                object model = CacheHelper.Get(cacheKey);
                if (model == null)
                {
                    DataTable configDt = configDal.Db.ExecuteDataTableSql("select ConfigKey,ConfigValue from SiteManage_Config");
                    DataTable dt = DataTableHelper.ConvertDataTable(configDt);
                    if (dt.Rows.Count > 0)
                    {
                        model = dt.Rows[0].ToExpandoObject();
                        CacheHelper.Insert(cacheKey, model);
                    }
                }
                return (ExpandoObject)model;
            }
        }

        /// <summary>
        /// 重写根据ID获取模型的方法
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public override SystemConfig GetModelByID(params object[] param)
        {
            DataTable configDt = GetEntityTable("Module='SiteManage'");
            DataTable dt = DataTableHelper.ConvertDataTable(configDt);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0].ToObject<SystemConfig>();
            }
            return null;
        }

        public override int UpdateByModel(object obj)
        {
            DataTable configDt = GetEntityTable("Module='SiteManage'");
            DataTable dt = DataTableHelper.ConvertDataTable(configDt);
            DataRow row = dt.NewRow();
            if (dt.Rows.Count > 0)
            {
                row = dt.Rows[0];
            }
            SystemConfig config = (SystemConfig)obj;
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
            RemoveCache();
            return Db.ExecuteNonQueryTran(list);
        }


    }
}
