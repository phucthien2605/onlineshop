using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopFinal.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(long id)
        {
            var product = new ProductDAO().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryID.Value);
            ViewBag.Information = new InformationProductDao().ViewDetail(product.Code);
            return View(product);
        }
    }
}