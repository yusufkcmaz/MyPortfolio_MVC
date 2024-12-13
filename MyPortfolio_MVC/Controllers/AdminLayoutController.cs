using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{

    
    public class AdminLayoutController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities(); 
        public ActionResult Layout()   
        {
            return View();
        }

        public PartialViewResult AdminLayoutHead()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSpinner()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSidebar()
        {
            var Email = Session["email"].ToString();
            var admin = db.TblAdmins.FirstOrDefault(x =>x.Email == Email);

            ViewBag.nameSurname = admin.Name + " " + admin.Surname;
            ViewBag.image = admin.ImageUrl;
            return PartialView();
        }
        public PartialViewResult AdminLayoutNavbar()
        {
            var Email = Session["email"].ToString();
            var admin = db.TblAdmins.FirstOrDefault(x => x.Email == Email);

            ViewBag.nameSurname=admin.Name + " " + admin.Surname;
            ViewBag.image = admin.ImageUrl;
            return PartialView();
             
        }
        
        public PartialViewResult  AdminLayoutFooter()

        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutScripts()

        {
            return PartialView();
        }
    }

}