using System.Security.Policy;
using System.Web.Mvc;
using Yamon.Module.SiteManage;
using Yamon.Module.SiteManage.DAL;

namespace Yamon.Module.UCenter.Web.Controllers
{
    public class UCenterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "UCenter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "UCenter_default",
                "UCenter/{controller}/{action}/{id}",
                new { controller = "User", action = "Index", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.UCenter.Web.Controllers" }
            );
            SiteCommon.AddPurview("SiteManage_Menu_GetMenuTreeJson", "UCenter_Role_MenuRolePurview");
            SiteCommon.AddPurview("UCenter_Role_GetRoleListByPurview", "UCenter_Role_MenuRolePurview");
            //SiteCommon.AddCustomPage("~/Areas/UCenter/Views/User/_/Create.cshtml", "~/Areas/UCenter/Views/User/Create.cshtml");
        }
    }
}