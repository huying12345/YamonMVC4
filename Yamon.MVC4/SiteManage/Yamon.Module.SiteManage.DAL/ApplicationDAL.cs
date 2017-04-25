
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
    /// SiteManage_Applications实体类
    ///</summary>
    public partial class ApplicationDAL : _ApplicationDAL
    {

        public Application GetEntityByAppKey(string appKey)
        {
            return GetEntityModel("AppKey=?", new object[] { appKey });
        }

        public List<Application> GetMyApp(int userId)
        {
            return GetEntityList("UserID=?", new object[] { userId });
        }

    }
}
