
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
using Yamon.Module.App.Entity;

namespace Yamon.Module.App.DAL
{
    /// <summary>
    /// 设备模型实体类
    ///</summary>
    public partial class AppDeviceDAL : _AppDeviceDAL
    {

        public override int Insert(MyNameValueCollection nv)
        {
            string deviceId = nv.GetString("DeviceID");
            if (Exists(deviceId))
            {
                AppDevice device = GetModelByID(deviceId);
                device.DeviceID = deviceId;
                device.UserName = nv.GetString("UserName");
                device.LastStartTime = DateTime.Now;
                device.StartNums = device.StartNums + 1;
                return base.UpdateByModel(device);
                return 0;
            }
            else
            {
                nv.Set("InstallTime",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                nv.Set("LastStartTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                return base.Insert(nv);
            }
        }
    }
}
