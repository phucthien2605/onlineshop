using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace OnlineShopFinal.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        // GET: Admin/ProductCategory
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductCategoryDao();
            var model = dao.ListAllPaging( searchString, page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDao();

                productCategory.CreatedDate = DateTime.Now;
                productCategory.CreatedBy = "Neiht";

                long id = dao.Insert(productCategory);
                if (id > 0)
                {
                    return RedirectToAction("Index", "ProductCategory");
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
            var category = new ProductCategoryDao().ViewDetail(id);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory category)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDao();

                var result = dao.Update(category);
                if (result)
                {
                    return RedirectToAction("Index", "ProductCategory");
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
            new ProductCategoryDao().Delete(id);
            return RedirectToAction("Index");
        }

    }
}