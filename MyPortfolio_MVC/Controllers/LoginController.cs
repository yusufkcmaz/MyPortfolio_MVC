﻿using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio_MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        MyPortfolioEntities db =new MyPortfolioEntities();

       [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin model)
        {
            var value = db.TblAdmins.FirstOrDefault(x=>x.Email == model.Email && x.Password==model.Password);
            if (value == null)
            {
                ModelState.AddModelError("", "Email veya Şifre Hatalıdır");
                return View(model);  

            }
            FormsAuthentication.SetAuthCookie(value.Email,false);

            
            Session["Email"] = value.Email;   
            return RedirectToAction("Index" , "Category");

        }
    }
}