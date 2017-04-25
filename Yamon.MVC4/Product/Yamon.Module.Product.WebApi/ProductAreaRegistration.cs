using System.Web.Mvc;
using Yamon.Module.SiteManage.DAL;

namespace Yamon.Module.Product.WebApi
{
    public class ProductAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Product_WebApi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Product_WebApi_default",
                "api/Product/{controller}/{action}/{id}",
                new { action = "Index", Controller = "ProductInfo", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.Product.WebApi" }
            );


            SiteCommon.AddPurview("Product_ProductType_EditTree", new string[] { "Product_ProductType_Create", "Product_ProductType_Edit" });
            SiteCommon.AddPurview("Product_OrderInfo_Create", new string[] { "Product_ProductInfo_CreateOrder" });
            SiteCommon.AddPurview("Product_OrderInfo_Show", new string[] { "Product_OrderInfo_Grid1_Models" });
            SiteCommon.AddPurview("Product_ProductType_TreeJsonByFilterID", new string[] { "Product_ProductInfo_CreateOrder" });
               SiteCommon.AddPurview("Product_OrderDetail_Grid1", new string[] { "Product_ProductInfo_CreateOrder" });
               SiteCommon.AddPurview("Product_ProductInfo_Create", new string[] { "Product_VProductInfo_Grid1_Models" });
               SiteCommon.AddPurview("Product_ProductBook_Show", new string[] { "Product_ProductBook_Grid1" });
               SiteCommon.AddPurview("Product_VProductBookDetail_Grid1", new string[] { "Product_ProductInfo_CreateOrder" });

               SiteCommon.AddPurview("Product_VProductInfo_Grid1", new string[] { "Product_OrderInfo_Second" });
               SiteCommon.AddPurview("Product_VOrderDetail_ImportFromExcel", new string[] { "Product_VOrderDetail_Grid1_Models" });
        }
    }
}