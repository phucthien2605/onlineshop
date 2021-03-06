﻿using Model.Dao;
using OnlineShopFinal.Areas.Admin.Models;
using OnlineShopFinal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopFinal.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encrytor.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var user = dao.GetbyId(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index","Home");
                }
                else if(result ==0 )
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if(result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
                else 
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }
                    
            }
            return View("Index"); 

        }
    }
}