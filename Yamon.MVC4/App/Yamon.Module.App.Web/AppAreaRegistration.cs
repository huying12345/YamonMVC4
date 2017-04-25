using System.Web.Mvc;

namespace Yamon.Module.App.Web
{
    public class AppAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "App";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "App_default",
                "App/{controller}/{action}/{id}",
                new { action = "Index", Controller = "AppDevice", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.App.Web.Controllers" }
            );
        }
    }
}