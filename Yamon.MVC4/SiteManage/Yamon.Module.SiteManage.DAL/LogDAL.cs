
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
    /// 日志模型实体类
    ///</summary>
    public partial class LogDAL : _LogDAL
    {
        /// <summary>
        /// 新增日志
        /// </summary>
        /// <param name="logKey">日志关键字</param>
        /// <param name="logType">日志类型</param>
        /// <param name="logContent">日志内容</param>
        /// <param name="appId">应用编号</param>
        /// <param name="logTime">日志时间</param>
        /// <param name="userId">用户编号</param>
        /// <param name="userIP">用户IP</param>
        /// <returns></returns>
        public static int AddLog(string modelId, string logKey, string logType, string logContent, int isSuccess, int userId, string userIP, string userName = "", string param = "")
        {
            try
            {
                Log model = new Log
                {
                    LogKey = logKey,
                    LogType = logType,
                    LogContent = logContent,
                    UserID = userId,
                    UserIP = userIP,
                    LogTime = DateTime.Now,
                    ModelID = modelId,
                    IsSuccess = isSuccess,
                    UserName = userName,
                    Params = param
                };
                LogQueue.AddLog(model);
            }
            catch
            {

            }
            return 0;
        }

        public static int AddLog(string modelId, string logKey, string logType, string logContent, int isSuccess = 1, string param = "")
        {
            return AddLog(modelId, logKey, logType, logContent, isSuccess, CookieHelper.GetCookieInt("UserID"), RequestHelper.GetIP(), CookieHelper.GetCookie("TrueName"), param);
        }

        /// <summary>
        /// 根据时间删除日志
        /// </summary>
        /// <param name="appId">应用编号</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public int DeleteLogByTime(DateTime startTime, DateTime endTime)
        {
            string sql = "Delete From SiteManage_Log Where LogTime>=? AND LogTime<=?";
            return Db.ExecuteNonQuerySqlEx(sql, startTime, endTime);
        }

    }
}
