
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
using Newtonsoft.Json;
using Yamon.Framework.DAL;
using Yamon.Module.App.Entity;

namespace Yamon.Module.App.DAL
{
    /// <summary>
    /// 版本模型实体类
    ///</summary>
    public partial class AppVersionDAL : _AppVersionDAL
    {
        public AppVersion GetLastVersion(string deviceType, string version,out bool needUpdate)
        {
            needUpdate = false;
            AppVersion versionInfo = GetEntityModel("", null, "ReleaseTime desc");
            if (version != null)
            {
                if (DataConverter.ToInt(versionInfo.VersionCode) > DataConverter.ToInt(version))
                {
                    needUpdate = true;
                   
                }
                return versionInfo;
            }
            return null;
        }

    }
}
