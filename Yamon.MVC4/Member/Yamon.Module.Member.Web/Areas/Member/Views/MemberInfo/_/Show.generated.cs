﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Member/Views/MemberInfo/_/Show.cshtml")]
    public partial class _Areas_Member_Views_MemberInfo___Show_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_Member_Views_MemberInfo___Show_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
  
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

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" region=\"center\"");

WriteLiteral(" border=\"true\"");

WriteLiteral(" style=\"padding: 10px; background: #F6F6F6; border: 1px solid #ccc;\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" id=\"myForm\"");

WriteLiteral(" name=\"myForm\"");

WriteLiteral(" action=\"/api/Member/MemberInfo/Show\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"mytable\"");

WriteLiteral("  cellpadding=\"1\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n<tr");

WriteLiteral(" id=\"Container_MemberInfoId\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">编号：</td><td>&nbsp;<span");

WriteLiteral(" id=\"MemberInfoId\"");

WriteLiteral(">");

            
            #line 19 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                          Write(Html.Raw(Model.MemberInfoId));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">会员编号：</td><td>&nbsp;<span");

WriteLiteral(" id=\"MemberNo\"");

WriteLiteral(">");

            
            #line 20 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                        Write(Html.Raw(Model.MemberNo));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_MemberGradeId\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">会员等级：</td><td>&nbsp;<span");

WriteLiteral(" id=\"MemberGradeId\"");

WriteLiteral(">");

            
            #line 23 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                             Write(Html.Raw(Model.MemberGradeId_ShowValue));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">姓名：</td><td>&nbsp;<span");

WriteLiteral(" id=\"MemberName\"");

WriteLiteral(">");

            
            #line 24 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                        Write(Html.Raw(Model.MemberName));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_Sex\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">性别：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Sex\"");

WriteLiteral(">");

            
            #line 27 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                 Write(Html.Raw(Model.Sex_ShowValue));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">密码：</td><td>&nbsp;<span");

WriteLiteral(" id=\"MemberPassword\"");

WriteLiteral(">");

            
            #line 28 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                            Write(Html.Raw(Model.MemberPassword));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_Balance\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">余额：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Balance\"");

WriteLiteral(">");

            
            #line 31 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                     Write(Html.Raw(Model.Balance));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">额外福利：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Bonus\"");

WriteLiteral(">");

            
            #line 32 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                     Write(Html.Raw(Model.Bonus));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_Tel\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">电话：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Tel\"");

WriteLiteral(">");

            
            #line 35 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                 Write(Html.Raw(Model.Tel));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">手机号：</td><td>&nbsp;<span");

WriteLiteral(" id=\"MobileNo\"");

WriteLiteral(">");

            
            #line 36 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                       Write(Html.Raw(Model.MobileNo));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_Email\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">邮箱：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Email\"");

WriteLiteral(">");

            
            #line 39 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                   Write(Html.Raw(Model.Email));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">证件类型：</td><td>&nbsp;<span");

WriteLiteral(" id=\"IdentityType\"");

WriteLiteral(">");

            
            #line 40 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                            Write(Html.Raw(Model.IdentityType_ShowValue));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_IdentityNo\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">证件号码：</td><td>&nbsp;<span");

WriteLiteral(" id=\"IdentityNo\"");

WriteLiteral(">");

            
            #line 43 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                          Write(Html.Raw(Model.IdentityNo));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">QQ：</td><td>&nbsp;<span");

WriteLiteral(" id=\"QQ\"");

WriteLiteral(">");

            
            #line 44 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                Write(Html.Raw(Model.QQ));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_BirthdayYear\"");

WriteLiteral(">\r\n<td");

WriteLiteral("  class=\"labeltd\"");

WriteLiteral(">生日年份：</td><td");

WriteLiteral("  colspan=\"3\"");

WriteLiteral(" >&nbsp;<span");

WriteLiteral(" id=\"BirthdayYear\"");

WriteLiteral(">");

            
            #line 47 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                                           Write(Html.Raw(Model.BirthdayYear));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_BirthdayMonthDay\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">生日月份：</td><td>&nbsp;<span");

WriteLiteral(" id=\"BirthdayMonthDay\"");

WriteLiteral(">");

            
            #line 50 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                                Write(Html.Raw(Model.BirthdayMonthDay));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">生日类型：</td><td>&nbsp;<span");

WriteLiteral(" id=\"BirthdayType\"");

WriteLiteral(">");

            
            #line 51 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                            Write(Html.Raw(Model.BirthdayType));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_Address\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">住址：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Address\"");

WriteLiteral(">");

            
            #line 54 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                     Write(Html.Raw(Model.Address));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">公司单位：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Company\"");

WriteLiteral(">");

            
            #line 55 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                       Write(Html.Raw(Model.Company));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_RegDate\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">注册日期：</td><td>&nbsp;<span");

WriteLiteral(" id=\"RegDate\"");

WriteLiteral(">");

            
            #line 58 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                       Write(Html.Raw(Model.RegDate));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">有效日期：</td><td>&nbsp;<span");

WriteLiteral(" id=\"ValidityDate\"");

WriteLiteral(">");

            
            #line 59 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                            Write(Html.Raw(Model.ValidityDate));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_MemberState\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">会员状态：</td><td>&nbsp;<span");

WriteLiteral(" id=\"MemberState\"");

WriteLiteral(">");

            
            #line 62 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                           Write(Html.Raw(Model.MemberState_ShowValue));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">修改时间：</td><td>&nbsp;<span");

WriteLiteral(" id=\"UpdateTime\"");

WriteLiteral(">");

            
            #line 63 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                          Write(Html.Raw(Model.UpdateTime));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_CreateTime\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">创建时间：</td><td>&nbsp;<span");

WriteLiteral(" id=\"CreateTime\"");

WriteLiteral(">");

            
            #line 66 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                          Write(Html.Raw(Model.CreateTime));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td>&nbsp;</td><td>&nbsp;</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_Comment\"");

WriteLiteral(">\r\n<td");

WriteLiteral("  class=\"labeltd\"");

WriteLiteral(">备注：</td><td");

WriteLiteral("  colspan=\"3\"");

WriteLiteral(" >&nbsp;<span");

WriteLiteral(" id=\"Comment\"");

WriteLiteral(">");

            
            #line 70 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                                    Write(Html.Raw(Model.Comment));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<span");

WriteLiteral(" id=\"LeavingDealTimes\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">");

            
            #line 72 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                             Write(Model.LeavingDealTimes);

            
            #line default
            #line hidden
WriteLiteral("</span><span");

WriteLiteral(" id=\"LeavingDealTimes_ShowValue\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">");

            
            #line 72 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                                                                                                        Write(Model.LeavingDealTimes);

            
            #line default
            #line hidden
WriteLiteral("</span><span");

WriteLiteral(" id=\"RecommendMemberNo\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">");

            
            #line 72 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                                                                                                                                                                                          Write(Model.RecommendMemberNo);

            
            #line default
            #line hidden
WriteLiteral("</span><span");

WriteLiteral(" id=\"RecommendMemberNo_ShowValue\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">");

            
            #line 72 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
                                                                                                                                                                                                                                                                                                                       Write(Model.RecommendMemberNo);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n</table>\r\n\r\n");

WriteLiteral("        ");

            
            #line 75 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
   Write(RenderPage("~/Areas/Member/Views/MemberInfo/Extend/Model_ViewHtml.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </form>\r\n</div>\r\n<div");

WriteLiteral(" region=\"south\"");

WriteLiteral(" border=\"false\"");

WriteLiteral(" style=\"text-align: right; background: #F6F6F6;height: 30px; line-height: 30px;\"");

WriteLiteral(">\r\n    <a");

WriteLiteral(" id=\"btnCancel\"");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(" icon=\"icon-cancel\"");

WriteLiteral(" href=\"javascript:CloseDialog();\"");

WriteLiteral(">\r\n        关闭\r\n    </a>\r\n</div>\r\n");

            
            #line 83 "..\..\Areas\Member\Views\MemberInfo\_\Show.cshtml"
Write(RenderPage("~/Areas/Member/Views/MemberInfo/Extend/Model_ViewJs.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

        }
    }
}
#pragma warning restore 1591