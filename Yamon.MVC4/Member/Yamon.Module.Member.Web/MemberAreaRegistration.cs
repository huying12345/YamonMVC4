using System.Web.Mvc;

namespace Yamon.Module.Member
{
    public class MemberAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Member";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Member_default",
                "Member/{controller}/{action}/{id}",
                new { action = "Index", Controller = "MemberGrade", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.Member.Web.Controllers" }
            );
        }
    }
}