using System.Web.Mvc;

namespace Yamon.Module.App.WebApi
{
    public class AppAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "App_WebApi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "App_WebApi_default",
                "api/App/{controller}/{action}/{id}",
                new { action = "Index", Controller = "AppDevice", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.App.WebApi" }
            );
        }
    }
}