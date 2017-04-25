using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Timers;
using Yamon.Framework.Common;
using Yamon.Module.SiteManage.DAL;
using Yamon.Module.SiteManage.Entity;

namespace Yamon.Module.SiteManage.DAL
{
    /// <summary>
    /// 日志消息队列
    /// </summary>
    public static class AppAPILogQueue
    {
        public static Queue APILogQueue;

        private static APILogDAL logDAL;

        static AppAPILogQueue()
        {
            APILogQueue = new Queue();
            logDAL = new APILogDAL();
            Thread thread = new Thread(Dequeue);
            thread.IsBackground = true;
            thread.Start();
        }

        public static void AddLog(APILog model)
        {
            APILogQueue.Enqueue(model);
        }

        public static void Dequeue()
        {
            while (true)
            {
                if (APILogQueue.Count > 0)
                {
                    while (APILogQueue.Count > 0)
                    {
                        object log = APILogQueue.Dequeue();
                        if (log is APILog)
                        {
                            logDAL.InsertByModel(log);
                        }
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }

    }
}
