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
    using Yamon.Module.SiteManage.Entity;
    using Yamon.Module.UCenter;
    using Yamon.Module.UCenter.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/UCenter/Views/Position/_/Edit.cshtml")]
    public partial class _Areas_UCenter_Views_Position___Edit_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_UCenter_Views_Position___Edit_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\UCenter\Views\Position\_\Edit.cshtml"
  
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
    ViewBag.Title="编辑岗位";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" region=\"center\"");

WriteLiteral(" border=\"true\"");

WriteLiteral(" style=\"padding: 10px; background: #FFFFFF; border: 1px solid #ccc;\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" id=\"myForm\"");

WriteLiteral(" name=\"myForm\"");

WriteLiteral(" action=\"/api/UCenter/Position/Edit\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"mytable\"");

WriteLiteral("  cellpadding=\"1\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n<tr");

WriteLiteral(" id=\"Container_DepartmentID\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_DepartmentID\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">所属部门：</td><td>&nbsp;\r\n\r\n<input");

WriteLiteral(" id=\"DepartmentID\"");

WriteLiteral(" name=\"DepartmentID\"");

WriteAttribute("url", Tuple.Create(" url=\"", 854), Tuple.Create("\"", 921)
, Tuple.Create(Tuple.Create("", 860), Tuple.Create("/api/UCenter/Department/EditTree?&Value=", 860), true)
            
            #line 22 "..\..\Areas\UCenter\Views\Position\_\Edit.cshtml"
            , Tuple.Create(Tuple.Create("", 900), Tuple.Create<System.Object, System.Int32>(Model.DepartmentID
            
            #line default
            #line hidden
, 900), false)
);

WriteAttribute("value", Tuple.Create(" value=\"", 922), Tuple.Create("\"", 951)
            
            #line 22 "..\..\Areas\UCenter\Views\Position\_\Edit.cshtml"
                                          , Tuple.Create(Tuple.Create("", 930), Tuple.Create<System.Object, System.Int32>(Model.DepartmentID
            
            #line default
            #line hidden
, 930), false)
);

WriteLiteral(" style=\"width: 200px\"");

WriteLiteral(" required=\"true\"");

WriteLiteral(" />\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    var DepartmentID_Value = \'");

            
            #line 24 "..\..\Areas\UCenter\Views\Position\_\Edit.cshtml"
                          Write(Model.DepartmentID);

            
            #line default
            #line hidden
WriteLiteral(@"';
    jQuery(function() {
        jQuery('#DepartmentID').combotree(
        {
            onLoadSuccess:function(node, data) {
                jQuery('#DepartmentID').combotree('setValue',DepartmentID_Value);
            }
        });
    });
</script>
</td></tr>
<tr");

WriteLiteral(" id=\"Container_PositionName\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_PositionName\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">岗位名称：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"PositionName\"");

WriteLiteral(" name=\"PositionName\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1509), Tuple.Create("\"", 1538)
            
            #line 36 "..\..\Areas\UCenter\Views\Position\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1517), Tuple.Create<System.Object, System.Int32>(Model.PositionName
            
            #line default
            #line hidden
, 1517), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral(" required=\"true\"");

WriteLiteral("  maxlength=\"20\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_IsManager\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_IsManager\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">是否为部门主管：</td><td>&nbsp;\r\n\r\n");

            
            #line 40 "..\..\Areas\UCenter\Views\Position\_\Edit.cshtml"
Write(Html.Raw(MyHtmlHelper2.ShowRadio(ViewBag.DAL.NameValue_IsManager, "IsManager", Model.IsManager, "&nbsp;&nbsp;")));

            
            #line default
            #line hidden
WriteLiteral("\r\n</td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_Responsibility\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_Responsibility\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">岗位职责：</td><td>&nbsp;\r\n<textarea");

WriteLiteral(" id=\"Responsibility\"");

WriteLiteral(" name=\"Responsibility\"");

WriteLiteral(" class=\"easyui-validatebox\"");

WriteLiteral("  style=\"width:300px;height:80px\"");

WriteLiteral(">");

            
            #line 43 "..\..\Areas\UCenter\Views\Position\_\Edit.cshtml"
                                                                                                            Write(Model.Responsibility);

            
            #line default
            #line hidden
WriteLiteral("</textarea>\r\n</td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_Tips\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_Tips\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">备注：</td><td>&nbsp;\r\n<textarea");

WriteLiteral(" id=\"Tips\"");

WriteLiteral(" name=\"Tips\"");

WriteLiteral(" class=\"easyui-validatebox\"");

WriteLiteral("  style=\"width:300px;height:80px\"");

WriteLiteral(">");

            
            #line 46 "..\..\Areas\UCenter\Views\Position\_\Edit.cshtml"
                                                                                        Write(Model.Tips);

            
            #line default
            #line hidden
WriteLiteral("</textarea>\r\n</td></tr>\r\n<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"PositionID\"");

WriteLiteral("  name=\"PositionID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2394), Tuple.Create("\"", 2421)
            
            #line 48 "..\..\Areas\UCenter\Views\Position\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 2402), Tuple.Create<System.Object, System.Int32>(Model.PositionID
            
            #line default
            #line hidden
, 2402), false)
);

WriteLiteral("/>\r\n</table>\r\n\r\n");

WriteLiteral("        ");

            
            #line 51 "..\..\Areas\UCenter\Views\Position\_\Edit.cshtml"
   Write(RenderPage("~/Areas/UCenter/Views/Position/Extend/Model_FormHtml.cshtml"));

            
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

            
            #line 79 "..\..\Areas\UCenter\Views\Position\_\Edit.cshtml"
Write(RenderPage("~/Areas/UCenter/Views/Position/Extend/Model_FormJs.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591