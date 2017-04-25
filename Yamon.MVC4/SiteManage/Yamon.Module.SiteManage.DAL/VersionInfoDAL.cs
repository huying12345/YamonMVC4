
using System;
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
using Yamon.Module.SiteManage.Entity;

namespace Yamon.Module.SiteManage.DAL
{
    /// <summary>
    /// 版本记录表实体类
    ///</summary>
    public partial class VersionInfoDAL : _VersionInfoDAL
    {

        public VersionInfo GetVersion()
        {
            string cacheKey = CacheKeyPrefix + "GetVersion";
            object objModel = CacheHelper.Get(cacheKey);
            if (objModel == null)
            {
                try
                {
                    VersionInfo model = GetEntityModel("", order: "VersionID desc");
                    CacheHelper.Insert(cacheKey, model);
                    return model;
                }
                catch { }
            }
            return (VersionInfo)objModel;
        }

        public string GetVersionString()
        {
            VersionInfo v = GetVersion();
            return v.Major + "." + v.Minor + "." + v.Build + "." + v.Revision;
        }
    }
}
