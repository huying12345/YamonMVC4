using System.Security.Policy;
using System.Web.Mvc;
using Yamon.Module.SiteManage;

namespace Yamon.Module.UCenter.WebApi
{
    public class UCenterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "UCenter_WebApi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "UCenter_WebApi_default",
                "api/UCenter/{controller}/{action}/{id}",
                new { controller = "User", action = "Index", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.UCenter.WebApi" }
            );
        }
    }
}