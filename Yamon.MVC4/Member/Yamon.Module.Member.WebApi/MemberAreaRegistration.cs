using System.Web.Mvc;
using Yamon.Module.SiteManage.DAL;

namespace Yamon.Module.Member.WebApi
{
    public class MemberAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Member_WebApi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Member_WebApi_default",
                "api/Member/{controller}/{action}/{id}",
                new { action = "Index", Controller = "MemberGrade", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.Member.WebApi" }
            );
          
        }
      
    }
}