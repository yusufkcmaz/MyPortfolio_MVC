using Microsoft.Ajax.Utilities;
using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio_MVC.Controllers
{
    public class ProfileController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();
        public ActionResult Index()
        {
            string Email = Session ["Email"].ToString();
            if (string.IsNullOrEmpty(Email))
            {
                return RedirectToAction("Index","login");
            }
            var admin = db.TblAdmins.FirstOrDefault(x => x.Email == Email);
            return View(admin);
        }


        [HttpPost]
        public ActionResult Index(TblAdmin model)
        {
            string Email = Session["Email"].ToString();
            var admin = db.TblAdmins.FirstOrDefault(x=>x.Email==Email);

           

            if(admin.Password==model.Password)
            {
                if (model.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "images\\";
                    var FileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                    model.ImageFile.SaveAs(FileName);
                    admin.ImageUrl = "/images/" + model.ImageFile.FileName;
                }

                admin.Name = model.Name;
                admin.Surname = model.Surname;
                admin.Email = model.Email;
                db.SaveChanges();
                Session.Abandon();
                return RedirectToAction("Index", "Login");
            }

            ModelState.AddModelError("", "Girdiğiniz Şifre Hatalı");
            return View (model);


        }
    }
}