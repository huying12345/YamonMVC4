﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Yamon.Framework.Common;
    using Yamon.Module.SiteManage;
    using Yamon.Module.SiteManage.Entity;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/SiteManage/Views/SystemConfig/_/Create.cshtml")]
    public partial class _Areas_SiteManage_Views_SystemConfig___Create_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_SiteManage_Views_SystemConfig___Create_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
  
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由亚萌智能表单代码生成工具生成。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。除非此项目不再使用代码生成器生成。
//     如果想修改此文件的内容，请复制一份到此文件的上级目录进行修改
//
//     如有问题联系zongeasy@qq.com
//</auto-generated>
//------------------------------------------------------------------------------
    ViewBag.Title="新建系统配置";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" region=\"center\"");

WriteLiteral(" border=\"true\"");

WriteLiteral(" style=\"padding: 10px; background: #F6F6F6; border: 1px solid #ccc;\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" id=\"myForm\"");

WriteLiteral(" name=\"myForm\"");

WriteLiteral(" action=\"/api/SiteManage/SystemConfig/Create\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"mytable\"");

WriteLiteral("  cellpadding=\"1\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n<tr");

WriteLiteral(" id=\"Container_Menber\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_Menber\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">是否支持会员：</td><td>&nbsp;");

            
            #line 20 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
                                                                                 Write(Html.Raw(MyHtmlHelper2.ShowCheckBox(ViewBag.DAL.NameValue_Menber, "Menber", Model.Menber, "&nbsp;&nbsp;")));

            
            #line default
            #line hidden
WriteLiteral("\r\n</td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_SiteName\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_SiteName\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">系统名称：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"SiteName\"");

WriteLiteral(" name=\"SiteName\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1066), Tuple.Create("\"", 1091)
            
            #line 23 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1074), Tuple.Create<System.Object, System.Int32>(Model.SiteName
            
            #line default
            #line hidden
, 1074), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral(" required=\"true\"");

WriteLiteral("  maxlength=\"30\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_SiteLogo\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_SiteLogo\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">登录背景图片：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"SiteLogo\"");

WriteLiteral(" name=\"SiteLogo\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1336), Tuple.Create("\"", 1361)
            
            #line 26 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1344), Tuple.Create<System.Object, System.Int32>(Model.SiteLogo
            
            #line default
            #line hidden
, 1344), false)
);

WriteLiteral("   class=\"easyui-validatebox\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral("/>\r\n<br/>\r\n<input");

WriteLiteral(" class=\"easyui-filebox\"");

WriteLiteral(" data-options=\"buttonText:\'浏览\',accept: \'image/*\',buttonAlign:\'left\'\"");

WriteLiteral(" id=\"Upload_SiteLogo\"");

WriteLiteral(" name=\"Upload_SiteLogo\"");

WriteLiteral(" style=\"width: 200px;\"");

WriteLiteral(" />\r\n<input");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"btnSiteLogo_Upload\"");

WriteLiteral(" name=\"btnSiteLogo_Upload\"");

WriteLiteral(" value=\"上传\"");

WriteLiteral(" onclick=\"btnSiteLogo_UploadClick()\"");

WriteLiteral("/>\r\n");

            
            #line 30 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
 if(!string.IsNullOrEmpty(Model.SiteLogo)){

            
            #line default
            #line hidden
WriteLiteral(" <br/>");

WriteLiteral("<img");

WriteLiteral(" id=\"Preview_SiteLogo\"");

WriteAttribute("src", Tuple.Create(" src=\"", 1814), Tuple.Create("\"", 1837)
            
            #line 31 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1820), Tuple.Create<System.Object, System.Int32>(Model.SiteLogo
            
            #line default
            #line hidden
, 1820), false)
);

WriteLiteral(" style=\"height: 60px; \"");

WriteLiteral("/>\r\n");

            
            #line 32 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
}else{

            
            #line default
            #line hidden
WriteLiteral(" <br/>");

WriteLiteral("<img");

WriteLiteral(" id=\"Preview_SiteLogo\"");

WriteAttribute("src", Tuple.Create(" src=\"", 1905), Tuple.Create("\"", 1928)
            
            #line 33 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1911), Tuple.Create<System.Object, System.Int32>(Model.SiteLogo
            
            #line default
            #line hidden
, 1911), false)
);

WriteLiteral(" style=\"height: 60px; display: none; \"");

WriteLiteral("/>\r\n");

            
            #line 34 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
 }

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    ///上传按钮事件
    function btnSiteLogo_UploadClick(){
        jQuery(""#myForm"").ajaxSubmit( {
            type: 'post',
            dataType: 'text',
            url: ""/api/SiteManage/UploadImage/Upload?FieldName=SiteLogo&UploadFieldName=Upload_SiteLogo&ModelID=SystemConfig&ModuleID=SiteManage"",
            beforeSubmit: function(formData, jqForm, options) {
                var queryString = jQuery.param(formData);
                if( jQuery(""Upload_SiteLogo"").val()==""""){
                    alert(""请选择你要上传的图片！"");
                }
                return true;
            },
            success: function(msg) {
                eval(""var result=""+msg);
                if(result.Status==1){
                    jQuery(""#SiteLogo"").val(result.returnValue);
                    alert(""上传成功!"");
                    $('#Upload_SiteLogo').filebox('clear');
                    $('#Preview_SiteLogo').attr('src',result.returnValue);
                }else{
                    alert(result.returnValue);
                }
            },
            error: function(error) {
            }
        });
    }
</script>
</td></tr>
<tr");

WriteLiteral(" id=\"Container_WebLogo\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_WebLogo\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">后台管理Logo：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"WebLogo\"");

WriteLiteral(" name=\"WebLogo\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3302), Tuple.Create("\"", 3326)
            
            #line 67 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 3310), Tuple.Create<System.Object, System.Int32>(Model.WebLogo
            
            #line default
            #line hidden
, 3310), false)
);

WriteLiteral("   class=\"easyui-validatebox\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral("/>\r\n<br/>\r\n<input");

WriteLiteral(" class=\"easyui-filebox\"");

WriteLiteral(" data-options=\"buttonText:\'浏览\',accept: \'image/*\',buttonAlign:\'left\'\"");

WriteLiteral(" id=\"Upload_WebLogo\"");

WriteLiteral(" name=\"Upload_WebLogo\"");

WriteLiteral(" style=\"width: 200px;\"");

WriteLiteral(" />\r\n<input");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"btnWebLogo_Upload\"");

WriteLiteral(" name=\"btnWebLogo_Upload\"");

WriteLiteral(" value=\"上传\"");

WriteLiteral(" onclick=\"btnWebLogo_UploadClick()\"");

WriteLiteral("/>\r\n");

            
            #line 71 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
 if(!string.IsNullOrEmpty(Model.WebLogo)){

            
            #line default
            #line hidden
WriteLiteral(" <br/>");

WriteLiteral("<img");

WriteLiteral(" id=\"Preview_WebLogo\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3772), Tuple.Create("\"", 3794)
            
            #line 72 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 3778), Tuple.Create<System.Object, System.Int32>(Model.WebLogo
            
            #line default
            #line hidden
, 3778), false)
);

WriteLiteral(" style=\"height: 60px; \"");

WriteLiteral("/>\r\n");

            
            #line 73 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
}else{

            
            #line default
            #line hidden
WriteLiteral(" <br/>");

WriteLiteral("<img");

WriteLiteral(" id=\"Preview_WebLogo\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3861), Tuple.Create("\"", 3883)
            
            #line 74 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 3867), Tuple.Create<System.Object, System.Int32>(Model.WebLogo
            
            #line default
            #line hidden
, 3867), false)
);

WriteLiteral(" style=\"height: 60px; display: none; \"");

WriteLiteral("/>\r\n");

            
            #line 75 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
 }

            
            #line default
            #line hidden
WriteLiteral("<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    ///上传按钮事件
    function btnWebLogo_UploadClick(){
        jQuery(""#myForm"").ajaxSubmit( {
            type: 'post',
            dataType: 'text',
            url: ""/api/SiteManage/UploadImage/Upload?FieldName=WebLogo&UploadFieldName=Upload_WebLogo&ModelID=SystemConfig&ModuleID=SiteManage"",
            beforeSubmit: function(formData, jqForm, options) {
                var queryString = jQuery.param(formData);
                if( jQuery(""Upload_WebLogo"").val()==""""){
                    alert(""请选择你要上传的图片！"");
                }
                return true;
            },
            success: function(msg) {
                eval(""var result=""+msg);
                if(result.Status==1){
                    jQuery(""#WebLogo"").val(result.returnValue);
                    alert(""上传成功!"");
                    $('#Upload_WebLogo').filebox('clear');
                    $('#Preview_WebLogo').attr('src',result.returnValue);
                }else{
                    alert(result.returnValue);
                }
            },
            error: function(error) {
            }
        });
    }
</script>
</td></tr>
<tr");

WriteLiteral(" id=\"Container_Copyright\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_Copyright\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">版权信息：</td><td>&nbsp;\r\n<textarea");

WriteLiteral(" id=\"Copyright\"");

WriteLiteral(" name=\"Copyright\"");

WriteLiteral(" class=\"easyui-validatebox\"");

WriteLiteral("  style=\"width:500px;height:80px\"");

WriteLiteral(">");

            
            #line 108 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
                                                                                                  Write(Model.Copyright);

            
            #line default
            #line hidden
WriteLiteral("</textarea>\r\n</td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_StationID\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_StationID\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">站点编号：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"StationID\"");

WriteLiteral(" name=\"StationID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 5491), Tuple.Create("\"", 5517)
            
            #line 111 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 5499), Tuple.Create<System.Object, System.Int32>(Model.StationID
            
            #line default
            #line hidden
, 5499), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"30\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_VisitNum\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_VisitNum\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">每天限制人数：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"VisitNum\"");

WriteLiteral(" name=\"VisitNum\"");

WriteAttribute("value", Tuple.Create(" value=\"", 5746), Tuple.Create("\"", 5771)
            
            #line 114 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 5754), Tuple.Create<System.Object, System.Int32>(Model.VisitNum
            
            #line default
            #line hidden
, 5754), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"30\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td></tr>\r\n\r\n</table>\r\n\r\n");

WriteLiteral("        ");

            
            #line 119 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
   Write(RenderPage("~/Areas/SiteManage/Views/SystemConfig/Extend/Model_FormHtml.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </form>\r\n</div>\r\n<div");

WriteLiteral(" region=\"south\"");

WriteLiteral(" border=\"false\"");

WriteLiteral(" style=\"text-align: right; background: #F6F6F6;height: 30px; line-height: 30px;\"");

WriteLiteral(">\r\n    <a");

WriteLiteral(" id=\"btnSubmit\"");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(" icon=\"icon-ok\"");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(">确定</a>\r\n    <a");

WriteLiteral(" id=\"btnCancel\"");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(" icon=\"icon-cancel\"");

WriteLiteral(" href=\"javascript:CloseDialog();\"");

WriteLiteral(">\r\n        取消\r\n    </a>\r\n</div>\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteLiteral(" src=\"/Resources/JsLib/jquery.form.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"/Resources/JsLib/My97DatePicker/WdatePicker.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"/Static/v1/js/Utils.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"/Static/v1/js/form.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
        jQuery(function() {
            CheckConditions();
function CheckConditions(){
jQuery('fieldset').show(); 
jQuery(""fieldset"").each(function(){ 
if(jQuery('tr',this).length>0){
if(jQuery('tr:visible',this).length>0){jQuery(this).show()} else{jQuery(this).hide()}
}
});
}
;
        });
    </script>
");

WriteLiteral("    ");

            
            #line 147 "..\..\Areas\SiteManage\Views\SystemConfig\_\Create.cshtml"
Write(RenderPage("~/Areas/SiteManage/Views/SystemConfig/Extend/Model_FormJs.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral(";\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
