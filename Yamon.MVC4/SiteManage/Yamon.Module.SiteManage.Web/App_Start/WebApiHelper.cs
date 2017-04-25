using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yamon.Framework.Common;
using Yamon.Framework.Common.Encrypt;

namespace Yamon.Module.SiteManage.Web
{
    public class WebApiHelper
    {
        private readonly string baseUrl = ConfigHelper.GetConfigString("SiteUrl").TrimEnd('/');
        public string token = "";
        public string _apiKey = "";
        public string _secretKey = "";
        private HttpHelper _httpHelper;

        public WebApiHelper(string apiKey, string secretKey)
        {
            _httpHelper = new HttpHelper();
          // _httpHelper.SetShowErrorLog(true);
            _apiKey = apiKey;
            _secretKey = secretKey;
        }

        public string Get(string actionUrl, Dictionary<string, object> paramDictionary)
        {
            if (paramDictionary == null)
            {
                paramDictionary = new Dictionary<string, object>();
            }
            ParamOptions param = new ParamOptions();
            param.Timestamp = SignHelper.GetUnixTime();
            param.Apikey = _apiKey;
            param.Properties = paramDictionary;
            if (!string.IsNullOrEmpty(token))
            {
                param.Properties.Add("Token", token);
            }
            string url = baseUrl + actionUrl;
            param.Sign = SignHelper.CreateSign("GET", param, url, _secretKey);
            var postStr = SignHelper.CreateParamString(param, "&");
            string postParam = "sign=" + param.Sign + postStr;
            return _httpHelper.Get(url + postParam);
        }

        public string Post(string actionUrl, Dictionary<string, object> paramDictionary = null, string postString = "")
        {
            if (paramDictionary == null)
            {
                paramDictionary = new Dictionary<string, object>();
            }
            ParamOptions param = new ParamOptions();
            param.Timestamp = SignHelper.GetUnixTime();
            param.Apikey = _apiKey;
            param.Properties = paramDictionary;
            if (!string.IsNullOrEmpty(token))
            {
                param.Properties.Add("Token", token);
            }
            string url = baseUrl + actionUrl;
            param.Sign = SignHelper.CreateSign("POST", param, url, _secretKey);
            var postStr = SignHelper.CreateParamString(param, "&");
            string postParam = "sign=" + param.Sign + postStr + postString;
            return _httpHelper.Post(url, postParam);
        }
    }
}
