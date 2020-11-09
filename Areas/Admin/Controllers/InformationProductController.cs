using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopFinal.Areas.Admin.Controllers
{
    public class InformationProductController : BaseController
    {
        // GET: Admin/InformationProduct
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new InformationProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(InformationProduct information)
        {
            if (ModelState.IsValid)
            {
                var dao = new InformationProductDao();


                long id = dao.Insert(information);
                if (id > 0)
                {
                    return RedirectToAction("Index", "InformationProduct");
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
            var information = new InformationProductDao().ViewDetail(id);

            return View(information);
        }

        [HttpPost]
        public ActionResult Edit(InformationProduct information)
        {
            if (ModelState.IsValid)
            {
                var dao = new InformationProductDao();

                var result = dao.Update(information);
                if (result)
                {
                    return RedirectToAction("Index", "InformationProduct");
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
            new InformationProductDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}