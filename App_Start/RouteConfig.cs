using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShopFinal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //routes.MapRoute(
            //    name: "Product Category",
            //    url: "san-pham/{metatitle}-{cateId}",
            //    defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
            //    namespaces: new[] { "OnlineShopFinal.Controllers" }
            //);

            routes.MapRoute(
                name: "Product Detail",
                url: "chi-tiet/{MetaTitle}-{ID}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShopFinal.Controllers" }
            );

            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShopFinal.Controllers" }
            );

            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShopFinal.Controllers" }
            );

            routes.MapRoute(
                name: "Payment Success",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "Sucsess", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShopFinal.Controllers" }
            );
            routes.MapRoute(
                name: "About",
                url: "About",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShopFinal.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShopFinal.Controllers" }
            );
        }
    }
}
