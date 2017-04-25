using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using Yamon.Framework.MVC;
using Yamon.Framework.NPOI;
using Yamon.Framework.NVelocity;
using Yamon.Framework.Words;


namespace Yamon.Module.SiteManage.WebApi
{
    public class UploadFileController : Controller
    {
        [CheckPurview(0)]
        public ActionResult Upload(string moduleId, string modelId, string fieldName)
        {
            string returnValue = "";
            string saveFileName = "";
            string fileExt = "";
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
                HttpPostedFileBase file =
                    Request.Files[RequestHelper.GetString("UploadFieldName", "Upload_" + fieldName)];
                if (file == null)
                {
                    returnValue = "请选择要确定上传的文件！";
                }
                else
                {
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
                    nvh.Put("Origin", file.FileName.Substring(0, file.FileName.LastIndexOf(".")));

                    string fileSavePath = configNameValue.GetString("txtFileSavePath");
                    //文件类型
                    string fileType = configNameValue.GetString("txtFileType"); //文件类型
                    string fileSaveName = configNameValue.GetString("dropFileType"); //文件名称
                    fileSaveName = nvh.GetStringFromSource(fileSaveName);
                    fileSavePath = nvh.GetStringFromSource(fileSavePath);
                    string fileLength = configNameValue.GetString("txtFileLength"); //文件大小

                    if (!fileSavePath.EndsWith("/"))
                    {
                        fileSavePath = fileSavePath + "/";
                    }
                    string savePath = RequestHelper.GetMapPath("~/" + fileSavePath); //保存路径

                    if (!IOHelper.IsExist(savePath, FsoMethod.Folder))
                    {
                        IOHelper.Create(savePath, FsoMethod.Folder);
                    }

                    if (file != null)
                    {
                        if (file.FileName.LastIndexOf(".") != -1)
                        {
                            fileExt = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1);

                            saveFileName = fileSaveName + "." + fileExt;
                            if (!("|" + fileType + "|").ToLower().Contains(fileExt.ToLower()))
                            {
                                returnValue = "请确定上传的文件扩展名为" + fileType.ToLower() + "！";
                            }
                            else
                            {
                                file.SaveAs(savePath + saveFileName);
                                if (file.FileName.EndsWith(".docx") || file.FileName.EndsWith(".doc"))
                                {
                                    ConvertToPDF(savePath + saveFileName);
                                }
                                returnValue = fileSavePath + saveFileName;
                                status = 1;
                            }
                        }
                    }
                }
            }
            //StringBuilder sb = new StringBuilder();
            //sb.Append("{");
            //sb.Append(string.Format("\"Status\":\"{0}\",", status.ToString()));
            //sb.Append(string.Format("\"returnValue\":\"{0}\"", returnValue));
            //sb.Append("}");

            var resultObj = new
            {
                Status = status,
                returnValue = returnValue,
                FileName = saveFileName,
                FileExt = fileExt
            };
            return Json(resultObj);
        }


        private void ConvertToPDF(string filePath)
        {
            WordHelper.SaveAs(filePath, filePath.Replace(".docx", ".pdf").Replace(".doc", ".pdf"), MySaveFormat.Pdf);

        }
    }
}
