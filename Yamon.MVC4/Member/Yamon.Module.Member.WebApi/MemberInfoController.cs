
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Linq.Expressions;
using System.Web.Mvc;
using Yamon.Framework.DAL;
using Yamon.Module.Member.Entity;
using Yamon.Module.Member.DAL;
using Newtonsoft.Json;
using Yamon.Framework.Common;
using Yamon.Module.SiteManage.DAL;
using Yamon.Framework.MVC;



namespace Yamon.Module.Member.WebApi
{
    /// <summary>
    /// 会员信息
    /// </summary>
    public partial class MemberInfoController : _MemberInfoController
    {
        [CheckPurview(0)]
        public ActionResult GetMemberInfoSelect(string id = "0")
        {

            MemberInfoDAL info = new MemberInfoDAL();
            DataRow dr = info.MemberInfoSelect(id);

            return Content(dr.ToJson());
        }
        [CheckPurview(0)]
        public ActionResult MemberLogin(string phone, string password, string validate)
        {

            MemberInfoDAL info = new MemberInfoDAL();

            string msg = "";
            bool message = false;
            if (phone == "")
            {
                hash["message"] = "手机号码不能为空！";
            }
            if (password == "")
            {
                hash["message"] = "密码不能为空！";
            }
            if (validate == "")
            {
                hash["message"] = "验证码不能为空！";
            }
            string validateCode = "";
            string codeid = RequestHelper.GetString("codeid");
            if (SiteCommon.ValidateDictionary.ContainsKey(codeid))
            {
                validateCode = SiteCommon.ValidateDictionary[codeid].Code;
                SiteCommon.ValidateDictionary.Remove(codeid);
            }
            if (validateCode != validate)
            {
                hash["message"] = "验证码错误！";
                return Content(JsonConvert.SerializeObject(hash));
            }

            int uid = 0;
            string result = "";
            if (phone != "")
            {
                password = Yamon.Framework.Common.Encrypt.MD5Encrypt.Encrypt(password);
                MemberInfoDAL member = new MemberInfoDAL();
                result = member.MenberLogin(phone, password);
                uid = DataConverter.ToInt(result);

            }

            if (uid > 0)
            {
                string apiKey = RequestHelper.GetString("apikey");
                hash["token"] = TokenHelper.GetToken(apiKey, 1, uid);
                msg = "1";
                message = true;
            }
            else
            {
                message = false;
                msg = "手机号或密码错误！";
            }

            hash["success"] = message;
            hash["message"] = msg == "1" ? "true" : msg;
            return Content(JsonConvert.SerializeObject(hash));
        }



        [CheckPurview(0)]
        public ActionResult Register(MemberInfo model, string validate, bool returnData = false)
        {
            string validateCode = "";
            string codeid = RequestHelper.GetString("codeid");
            if (SiteCommon.ValidateDictionary.ContainsKey(codeid))
            {
                validateCode = SiteCommon.ValidateDictionary[codeid].Code;
                SiteCommon.ValidateDictionary.Remove(codeid);
            }
            if (validateCode != validate)
            {
                hash["message"] = "验证码错误！";
                return Content(JsonConvert.SerializeObject(hash));
            }
            model.MemberNo = dal.GetMaxID().ToString();
            model.MemberName = model.MobileNo;
            model.MemberGradeId = 3;
            return Create(model, returnData);
        }

        [CheckPurview(0)]
        public ActionResult MemberInfoReset()
        {
            try
            {
                string MemberInfoId = RequestHelper.GetString("MemberInfoId");
                MemberInfo info = dal.GetInfoByID(MemberInfoId);
                info.MemberPassword = Yamon.Framework.Common.Encrypt.MD5Encrypt.Encrypt("123456");
                dal.UpdateByModel(info);

                hash["success"] = true;
                hash["message"] = "密码重置成功";
            }
            catch (Exception ex)
            {
                hash["message"] = "密码重置失败" + ex.Message;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }

    }
}
