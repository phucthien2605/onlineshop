using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopFinal.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();

                product.CreatedDate = DateTime.Now;
                product.CreatedBy = "Neiht";

                long id = dao.Insert(product);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới thành công");
                }
            }
            return View("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = new ProductDAO().ViewDetail(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();

                var result = dao.Update(product);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thông tin thành công");
                }
            }
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}