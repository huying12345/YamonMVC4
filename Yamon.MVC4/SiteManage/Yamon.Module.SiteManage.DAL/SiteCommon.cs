using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using Yamon.Module.SiteManage.DAL;

namespace Yamon.Module.SiteManage.DAL
{
    public static class SiteCommon
    {
        public static Dictionary<string, List<string>> PurviewDictionary = new Dictionary<string, List<string>>();
        public static Dictionary<string, string> CustomPageDictionary;
        public static Dictionary<string, string> AppDictionary;
        public static Dictionary<string, ValidateCode> ValidateDictionary;

        public static List<string> NoCheckPurviewList;

        static SiteCommon()
        {
            AppDictionary = new Dictionary<string, string>();
            CustomPageDictionary = new Dictionary<string, string>();
            ValidateDictionary = new Dictionary<string, ValidateCode>();
            ApplicationDAL applicationDal = new ApplicationDAL();
            DataTable appTable = applicationDal.GetAllEntityTable("AppKey,AppSecretKey");
            foreach (DataRow row in appTable.Rows)
            {
                AppDictionary.Add(row["AppKey"].ToString(), row["AppSecretKey"].ToString());
            }
            NoCheckPurviewList = new List<string>();

            //删除过期的验证码
            Thread thread = new Thread(ClearValidateDictionary);
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 删除过期的验证码
        /// </summary>
        public static void ClearValidateDictionary()
        {
            while (true)
            {
                if (ValidateDictionary.Count > 0)
                {
                    ArrayList delList = new ArrayList();
                    foreach (var key in ValidateDictionary.Keys.ToArray())
                    {
                        if (ValidateDictionary.ContainsKey(key))
                        {
                            ValidateCode value = ValidateDictionary[key];
                            if (value == null || (DateTime.Now.Ticks - value.Time > 180*10000000))
                            {
                                delList.Add(key);
                            }
                        }
                    }
                    foreach (string key in delList)
                    {
                        ValidateDictionary.Remove(key);
                    }
                }
                else
                {
                    Thread.Sleep(60000);
                }
            }
        }

        /// <summary>
        /// 添加权限关联
        /// </summary>
        /// <param name="key"></param>
        /// <param name="code"></param>
        public static void AddPurview(string key, string code)
        {

            string[] arrCode = code.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            AddPurview(key, arrCode);
        }
        public static void AddPurview(string key, string[] code)
        {
            if (!PurviewDictionary.ContainsKey(key))
            {
                List<string> list = new List<string>();
                list.Add(key);
                PurviewDictionary.Add(key, list);
            }

            List<string> list1 = PurviewDictionary[key];
            foreach (var myCode in code)
            {
                if (!list1.Contains(myCode) && !string.IsNullOrEmpty(myCode))
                {
                    list1.Add(myCode);
                }
            }
            PurviewDictionary[key] = list1;
        }

        /// <summary>
        /// 添加自定义页面
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="newPageName"></param>
        public static void AddCustomPage(string pageName, string newPageName)
        {
            if (!CustomPageDictionary.ContainsKey(pageName))
            {
                CustomPageDictionary.Add(pageName, newPageName);
            }
        }

        /// <summary>
        /// 获取自定义页面
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public static string GetCustomPage(string pageName)
        {
            if (CustomPageDictionary.ContainsKey(pageName))
            {
                return CustomPageDictionary[pageName];
            }
            return pageName;
        }

        public static void AddNoCheckPurview(string pageCode)
        {
            if (!NoCheckPurviewList.Contains(pageCode))
            {
                NoCheckPurviewList.Add(pageCode);
            }
        }

        public static string GetAppSecretKey(string appKey)
        {
            if (AppDictionary.ContainsKey(appKey))
            {
                return AppDictionary[appKey];
            }
            return "";
        }
    }

    public class ValidateCode
    {
        public string Code { get; set; }

        public long Time { get; set; }

        public ValidateCode(string code)
        {
            Code = code;
            Time = DateTime.Now.Ticks;
        }
    }
}
