using Model.Dao;
using OnlineShopFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopFinal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productDao = new ProductDAO();
            ViewBag.Iphone = productDao.ListIPhone(3);
            ViewBag.IPad = productDao.ListIPad(1);
            ViewBag.Macbook = productDao.ListMacbook(1);
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }

        public ActionResult About()
        {
            return View();
        }

       
    }
}