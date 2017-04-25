using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using Yamon.Framework.MVC;
using Yamon.Framework.NVelocity;


namespace Yamon.Module.SiteManage.WebApi
{
    public class UploadImageController : Controller
    {
        [CheckPurview(0)]
        public ActionResult Upload(string moduleId, string modelId, string fieldName)
        {
            string returnValue = "";
            int status = 0;
            string configFile = Server.MapPath(string.Format("~/App_Data/UploadConfig/{0}_{1}_{2}.config", moduleId, modelId, fieldName));
            string config = IOHelper.ReadFile(configFile);
            if (string.IsNullOrEmpty(config))
            {
                returnValue = "找不到该字段的上传配置！";
            }
            else
            {
                Serialize<MyNameValueCollection> serialize = new Serialize<MyNameValueCollection>();
                MyNameValueCollection configNameValue = serialize.DeserializeField(config);
                HttpPostedFileBase file = Request.Files["Upload_" + fieldName];

                NVelocityHelper nvh = new NVelocityHelper();
                nvh.Put("DateTime", new DateTime());
                nvh.Put("Year", DateTime.Now.ToString("yyyy"));
                nvh.Put("Month", DateTime.Now.ToString("MM"));
                nvh.Put("Day", DateTime.Now.ToString("dd"));
                nvh.Put("Hour", DateTime.Now.ToString("HH"));
                nvh.Put("Minute", DateTime.Now.ToString("mm"));
                nvh.Put("Second", DateTime.Now.ToString("ss"));
                nvh.Put("HtmlHelper", new MyHtmlHelper());
                nvh.Put("StringHelper", new StringHelper());
                nvh.Put("RequestHelper", new RequestHelper());
                nvh.Put("Random", Guid.NewGuid());
                string fileSavePath = "/" + configNameValue.GetString("txtImageSavePath").TrimStart('/');
                //文件类型
                string fileType = configNameValue.GetString("txtImageType"); //文件类型
                string fileSaveName = configNameValue.GetString("dropImageType"); //文件名称
                fileSaveName = nvh.GetStringFromSource(fileSaveName);
                fileSavePath = nvh.GetStringFromSource(fileSavePath);
                string fileLength = configNameValue.GetString("txtImageFileLength"); //文件大小
                int thumbnail = configNameValue.GetInt("radioImageSL");
                ; //缩略图
                int imageWather = RequestHelper.GetRequestInt("ImageWater_" + fieldName); //水印
                if (!fileSavePath.EndsWith("/"))
                {
                    fileSavePath = fileSavePath + "/";
                }
                string savePath = RequestHelper.GetMapPath("~" + fileSavePath); //保存路径

                if (!IOHelper.IsExist(savePath, FsoMethod.Folder))
                {
                    IOHelper.Create(savePath, FsoMethod.Folder);
                }
                string saveFileName = "";
                if (file == null)
                {
                    returnValue = "请选择要确定上传的图片！";
                    if (!string.IsNullOrEmpty(RequestHelper.GetString("sign")))
                    {
                        try
                        {
                            byte[] arr = Convert.FromBase64String(RequestHelper.GetString("Upload_" + fieldName));
                            string fileExt = RequestHelper.GetString("Ext_" + fieldName);
                            if (!("|" + fileType + "|").ToLower().Contains(fileExt.ToLower()))
                            {
                                returnValue = "请确定上传的文件扩展名为" + fileType.ToLower() + "！";
                            }
                            else
                            {
                                saveFileName = fileSaveName + "." + fileExt;
                                MemoryStream ms = new MemoryStream(arr);
                                Bitmap bmp = new Bitmap(ms);
                                bmp.Save(savePath + saveFileName, GetImageFormat(fileExt));
                                status = 1;
                            }
                        }
                        catch (Exception ex)
                        {
                            returnValue = ex.Message;
                            status = 0;
                        }
                    }
                }
                else
                {
                    if (file != null)
                    {
                        if (file.FileName.LastIndexOf(".") != -1)
                        {
                            string fileFix = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1);
                            saveFileName = fileSaveName + "." + fileFix;
                            if (!("|" + fileType + "|").ToLower().Contains(fileFix.ToLower()))
                            {
                                returnValue = "请确定上传的文件扩展名为" + fileType.ToLower() + "！";
                            }
                            else
                            {
                                file.SaveAs(savePath + saveFileName);

                                status = 1;
                            }
                        }
                    }
                }
                if (status == 1)
                {
                    if (imageWather == 1) //添加水印
                    {
                        returnValue = fileSavePath +
                                      ImageWater.DrawImage(saveFileName,
                                          RequestHelper.GetRootPath() + "Images/logo.png", 0.6f,
                                          ImagePosition.RigthBottom, savePath);
                    }
                    else
                    {
                        returnValue = fileSavePath + saveFileName;
                    }
                    if (thumbnail == 1) //生成缩略图
                    {
                        Thumbnail.MakeThumbnailImage(savePath + saveFileName, savePath + "s_" + saveFileName,
                            300, 500);
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(string.Format("\"Status\":\"{0}\",", status.ToString()));
            sb.Append(string.Format("\"returnValue\":\"{0}\"", returnValue));
            sb.Append("}");
            return Content(sb.ToString());
        }

        private ImageFormat GetImageFormat(string ext)
        {
            if (ext == "bmp")
            {
                return ImageFormat.Bmp;
            }
            else if (ext == "gif")
            {
                return ImageFormat.Gif;
            }
            else if (ext == "png")
            {
                return ImageFormat.Png;
            }
            return ImageFormat.Jpeg;
        }
    }
}
