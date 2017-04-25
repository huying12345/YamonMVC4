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
    public static class LogQueue
    {
        public static Queue queue;

        private static LogDAL logDAL;

        static LogQueue()
        {
            queue = new Queue();
            logDAL = new LogDAL();
            Thread thread = new Thread(Dequeue);
            thread.IsBackground = true;
            thread.Start();
        }

        public static void AddLog(Log model)
        {
            queue.Enqueue(model);
        }

        public static void Dequeue()
        {
            while (true)
            {
                if (queue.Count > 0)
                {
                    while (queue.Count > 0)
                    {
                        object log = queue.Dequeue();
                        if (log is Log)
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
