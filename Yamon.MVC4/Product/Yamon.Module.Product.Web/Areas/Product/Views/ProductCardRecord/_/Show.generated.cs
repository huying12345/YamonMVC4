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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Product/Views/ProductCardRecord/_/Show.cshtml")]
    public partial class _Areas_Product_Views_ProductCardRecord___Show_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_Product_Views_ProductCardRecord___Show_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\Product\Views\ProductCardRecord\_\Show.cshtml"
  
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

WriteLiteral(" action=\"/api/Product/ProductCardRecord/Show\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"mytable\"");

WriteLiteral("  cellpadding=\"1\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n<tr");

WriteLiteral(" id=\"Container_RecordID\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">ID：</td><td>&nbsp;<span");

WriteLiteral(" id=\"RecordID\"");

WriteLiteral(">");

            
            #line 19 "..\..\Areas\Product\Views\ProductCardRecord\_\Show.cshtml"
                                                      Write(Html.Raw(Model.RecordID));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">会员：</td><td>&nbsp;<span");

WriteLiteral(" id=\"MemberID\"");

WriteLiteral(">");

            
            #line 20 "..\..\Areas\Product\Views\ProductCardRecord\_\Show.cshtml"
                                                      Write(Html.Raw(Model.MemberID));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_TradeType\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">交易类型：</td><td>&nbsp;<span");

WriteLiteral(" id=\"TradeType\"");

WriteLiteral(">");

            
            #line 23 "..\..\Areas\Product\Views\ProductCardRecord\_\Show.cshtml"
                                                         Write(Html.Raw(Model.TradeType_ShowValue));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">卡号：</td><td>&nbsp;<span");

WriteLiteral(" id=\"CardID\"");

WriteLiteral(">");

            
            #line 24 "..\..\Areas\Product\Views\ProductCardRecord\_\Show.cshtml"
                                                    Write(Html.Raw(Model.CardID));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_CardSN\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">厂商代码：</td><td>&nbsp;<span");

WriteLiteral(" id=\"CardSN\"");

WriteLiteral(">");

            
            #line 27 "..\..\Areas\Product\Views\ProductCardRecord\_\Show.cshtml"
                                                      Write(Html.Raw(Model.CardSN));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">卡序号：</td><td>&nbsp;<span");

WriteLiteral(" id=\"CardNo\"");

WriteLiteral(">");

            
            #line 28 "..\..\Areas\Product\Views\ProductCardRecord\_\Show.cshtml"
                                                     Write(Html.Raw(Model.CardNo));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_UserID\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">经办人：</td><td>&nbsp;<span");

WriteLiteral(" id=\"UserID\"");

WriteLiteral(">");

            
            #line 31 "..\..\Areas\Product\Views\ProductCardRecord\_\Show.cshtml"
                                                     Write(Html.Raw(Model.UserID_ShowValue));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">交易时间：</td><td>&nbsp;<span");

WriteLiteral(" id=\"TradeTime\"");

WriteLiteral(">");

            
            #line 32 "..\..\Areas\Product\Views\ProductCardRecord\_\Show.cshtml"
                                                         Write(Html.Raw(Model.TradeTime));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_Money\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">金额：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Money\"");

WriteLiteral(">");

            
            #line 35 "..\..\Areas\Product\Views\ProductCardRecord\_\Show.cshtml"
                                                   Write(Html.Raw(Model.Money));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">备注：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Remarks\"");

WriteLiteral(">");

            
            #line 36 "..\..\Areas\Product\Views\ProductCardRecord\_\Show.cshtml"
                                                     Write(Html.Raw(Model.Remarks));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_Times\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">次数：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Times\"");

WriteLiteral(">");

            
            #line 39 "..\..\Areas\Product\Views\ProductCardRecord\_\Show.cshtml"
                                                   Write(Html.Raw(Model.Times));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">&nbsp;</td><td>&nbsp;</td>\r\n</tr>\r\n\r\n</table>\r\n\r\n");

WriteLiteral("        ");

            
            #line 45 "..\..\Areas\Product\Views\ProductCardRecord\_\Show.cshtml"
   Write(RenderPage("~/Areas/Product/Views/ProductCardRecord/Extend/Model_ViewHtml.cshtml"));

            
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

            
            #line 53 "..\..\Areas\Product\Views\ProductCardRecord\_\Show.cshtml"
Write(RenderPage("~/Areas/Product/Views/ProductCardRecord/Extend/Model_ViewJs.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

        }
    }
}
#pragma warning restore 1591