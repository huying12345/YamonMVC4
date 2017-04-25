using System.Web.Mvc;
using Yamon.Module.SiteManage.DAL;

namespace Yamon.Module.Product
{
    public class ProductAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Product";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Product_default",
                "Product/{controller}/{action}/{id}",
                new { action = "Index", Controller = "ProductInfo", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.Product.Web.Controllers" }
            );
            SiteCommon.AddCustomPage("~/Areas/Product/Views/OrderInfo/_/Show.cshtml", "~/Areas/Product/Views/OrderInfo/Show.cshtml");
            SiteCommon.AddNoCheckPurview("Product_OrderInfo_Create");
            SiteCommon.AddNoCheckPurview("Product_OrderInfo_Show");
            SiteCommon.AddNoCheckPurview("Product_OrderInfo_Statistics");
        }
    }
}