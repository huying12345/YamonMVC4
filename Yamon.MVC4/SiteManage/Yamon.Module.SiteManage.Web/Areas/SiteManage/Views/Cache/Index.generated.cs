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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/SiteManage/Views/Cache/Index.cshtml")]
    public partial class _Areas_SiteManage_Views_Cache_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_SiteManage_Views_Cache_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<table");

WriteLiteral(" id=\"tt\"");

WriteLiteral("></table>\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 57), Tuple.Create("\"", 90)
, Tuple.Create(Tuple.Create("", 63), Tuple.Create<System.Object, System.Int32>(Href("~/Static/v1/js/GridUtils.js")
, 63), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        var _ListActionUrl = \'/api/SiteManage/Cache/CacheList\';\r\n        var _" +
"DelActionUrl = \'/api/SiteManage/Cache/Del\';\r\n        var _ClearActionUrl = \'/api" +
"/SiteManage/Cache/Clear\';\r\n\r\n        jQuery(function () {\r\n            window.on" +
"resize = setGridHeight;\r\n            jQuery(\'#tt\').datagrid({\r\n                u" +
"rl: _ListActionUrl,\r\n                fitColumns: false, //设置横向滚动条没有，宽度永远只有那么大\r\n " +
"               striped: true, //行是否隔行换样式\r\n                pagination: false, //显" +
"示分页\r\n                pageSize: 20,\r\n                loadMsg: \'数据加载中，请稍等...\', //显" +
"示加载信息\r\n                rownumbers: true, //显示序号\r\n                singleSelect: f" +
"alse, //单选一行\r\n\r\n                sortName: \'CacheName\',\r\n                sortOrde" +
"r: \'asc\',\r\n                remoteSort: false,\r\n\r\n                idField: \'Cache" +
"Name\',\r\n                frozenColumns: [\r\n                    [\r\n               " +
"         { field: \'ck\', checkbox: true }\r\n                    ]\r\n               " +
" ],\r\n                columns: [\r\n                    [\r\n                        " +
"{ field: \'CacheName\', title: \'缓存名称\', sortable: true, width: 200 },\r\n            " +
"            { field: \'CacheValue\', title: \'缓存内容\', sortable: true, width: 300 },\r" +
"\n                        {\r\n                            field: \'operator\',\r\n    " +
"                        title: \'操作\',\r\n                            width: 120,\r\n " +
"                           align: \'center\',\r\n                            formatt" +
"er: function (value, row, index) {\r\n                                return \"<a h" +
"ref=\\\"javascript:void(0)\\\" style=\\\"color:red;\\\" onclick=\\\"delData(\'\" + row.Cache" +
"Name + \"\')\\\">删除</a>\";\r\n                            }\r\n                        }\r" +
"\n                    ]\r\n                ],\r\n                toolbar: [\r\n        " +
"            {\r\n                        id: \'btncut\',\r\n                        te" +
"xt: \'删除\',\r\n                        iconCls: \'icon-remove\',\r\n                    " +
"    handler: function () {\r\n                            delData(getSelectIds());" +
"\r\n                        }\r\n                    }, {\r\n                        i" +
"d: \'btncut\',\r\n                        text: \'清空\',\r\n                        iconC" +
"ls: \'icon-cut\',\r\n                        handler: function () {\r\n               " +
"             clearData();\r\n                        }\r\n                    }\r\n   " +
"             ]\r\n            });\r\n            setGridHeight();\r\n        });\r\n\r\n\r\n" +
"        //删除数据\r\n        function delData(id) {\r\n            if (id == \"\" || id =" +
"= \"undefined\") return;\r\n            jQuery.messager.confirm(\'Confirm\', \'确定要删除[缓存" +
"名称为\' + id + \' ]的缓存吗?\', function (r) {\r\n                if (r) {\r\n               " +
"     jQuery.ajax({\r\n                        type: \'post\',\r\n                     " +
"   dataType: \'json\',\r\n                        url: _DelActionUrl + \'/\' + id,\r\n  " +
"                      success: function (msg) {\r\n                            if " +
"(msg.success) {\r\n                                jQuery.messager.alert(\'提示\', \'删除" +
"成功！\', \'info\');\r\n                                $(\'#tt\').datagrid(\'reload\');\r\n  " +
"                              $(\'#tt\').datagrid(\'unselectAll\');\r\n               " +
"             } else {\r\n                                jQuery.messager.alert(\'提示" +
"\', \'删除失败！\', \'error\');\r\n                                return;\r\n                " +
"            }\r\n                        }\r\n                    });\r\n             " +
"   }\r\n            });\r\n        }\r\n\r\n        //清空数据\r\n        function clearData()" +
" {\r\n            jQuery.messager.confirm(\'Confirm\', \'确定要清空缓存吗?\', function (r) {\r\n" +
"                if (r) {\r\n                    jQuery.ajax({\r\n                   " +
"     type: \'post\',\r\n                        dataType: \'json\',\r\n                 " +
"       url: _ClearActionUrl,\r\n                        success: function (msg) {\r" +
"\n                            if (msg.success) {\r\n                               " +
" //jQuery.messager.alert(\'提示\', \'清空成功！\', \'info\');\r\n                              " +
"  $(\'#tt\').datagrid(\'reload\');\r\n                                $(\'#tt\').datagri" +
"d(\'unselectAll\');\r\n                            } else {\r\n                       " +
"         jQuery.messager.alert(\'提示\', \'清空失败！\', \'error\');\r\n                       " +
"         return;\r\n                            }\r\n                        }\r\n    " +
"                });\r\n                }\r\n            });\r\n        }\r\n\r\n        fu" +
"nction reloadData() {\r\n            jQuery(\'#tt\').datagrid(\'reload\');\r\n        }\r" +
"\n    </script>\r\n");

});

        }
    }
}
#pragma warning restore 1591