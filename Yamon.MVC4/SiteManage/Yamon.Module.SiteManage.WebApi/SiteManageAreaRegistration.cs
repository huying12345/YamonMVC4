using System.Web.Mvc;
using Yamon.Module.SiteManage.DAL;

namespace Yamon.Module.SiteManage.WebApi
{
    public class SiteManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SiteManage_WebApi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SiteManage_WebApi_default",
                "api/SiteManage/{controller}/{action}/{id}",
                new { action = "Index", Controller = "APILog", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.SiteManage.WebApi" }
            );
            SiteCommon.AddPurview("SiteManage_DictType_EditTree", "SiteManage_DictType_TreeGrid");
            SiteCommon.AddPurview("SiteManage_Menu_SaveEditTree", "SiteManage_Menu_EditTree");
            SiteCommon.AddPurview("SiteManage_Menu_GetToolBarJsonByMenu", "SiteManage_Menu_GetMenuTreeJson");
            SiteCommon.AddNoCheckPurview("SiteManage_API_EditTree");
            
           
        }
    }
}