using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Yamon.Framework.Common;
using Yamon.Framework.Common.VerifyImage;
using Yamon.Framework.MVC;
using Yamon.Module.SiteManage.DAL;

namespace Yamon.Module.SiteManage.WebApi
{
    [NoCheckLogin]
    public class ValidateCodeController : BaseController
    {
        public ActionResult GetValidateImage()
        {
            string validateCode = RandomHelper.GetRandomNum(4);
            CookieHelper.WriteCookie("ValidateCode", validateCode, 10);
            IVerifyImage verifyImage = VerifyImageProvider.GetDefaultVerifyImage();
            VerifyImageInfo image = verifyImage.GenerateImage(validateCode, 120, 60, Color.White, 30);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return File(ms.ToArray(), image.ContentType);
        }



        public ActionResult GetValidateCode()
        {
            string validateCode = RandomHelper.GetRandomNum(4);
            IVerifyImage verifyImage = VerifyImageProvider.GetDefaultVerifyImage();
            VerifyImageInfo image = verifyImage.GenerateImage(validateCode, 120, 60, Color.Azure, 30);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            string codeId = Guid.NewGuid().ToString();
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();
            hash["image"] = Convert.ToBase64String(arr);
            hash["success"] = true;
            hash["codeid"] = codeId;
            SiteCommon.ValidateDictionary.Add(codeId, new ValidateCode(validateCode));
            return Json(hash);
        }

    }
}
