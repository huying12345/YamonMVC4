using System.Web.Mvc;
using Yamon.Module.SiteManage.DAL;

namespace Yamon.Module.SiteManage.Web.Controllers
{
    public class SiteManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SiteManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SiteManage_default",
                "SiteManage/{controller}/{action}/{id}",
                new { action = "Index", Controller = "APILog", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.SiteManage.Web.Controllers" }
            );

            SiteCommon.AddCustomPage("~/Areas/SiteManage/Views/SubPlan/_/Create.cshtml", "~/Areas/SiteManage/Views/SubPlan/Create.cshtml");
            SiteCommon.AddCustomPage("~/Areas/SiteManage/Views/SubPlan/_/Edit.cshtml", "~/Areas/SiteManage/Views/SubPlan/Edit.cshtml");
        }
    }
}