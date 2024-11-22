﻿using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class ProjectController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();

        private void CategoryDropdown()
        {
            var categoryList = db.TblCategories.ToList();
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            ViewBag.categories = categories;
        }
        public ActionResult Index()
        {
            var projects = db.TblProjects.ToList();
            return View(projects);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            CategoryDropdown();
            
                     
             return View();

        }

        [HttpPost]
        public ActionResult CreateProject(TblProject model )
        {
            CategoryDropdown();
                            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
          
            db.TblProjects.Add(model); 
            db.SaveChangesAsync();
            return RedirectToAction("index");
        }

        public ActionResult DeleteProject( int id )
        {
            var value = db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");  
        }

        [HttpGet]
         public ActionResult UpdateProject( int id )
        {
            CategoryDropdown();
            var value = db.TblProjects.Find(id);
            return View(value);
        }
        [HttpPost]

        public ActionResult UpdateProject(TblProject model)
        {
            CategoryDropdown();
            var value = db.TblProjects.Find(model.ProjectId);
            value.Name = model.Name;
            value.ImageUrl = model.ImageUrl;
            value.Description = model.Description;
            value.CategoryId= model.CategoryId;
            value.GithubUrl= model.GithubUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            db.SaveChanges();
            return RedirectToAction("index");   
        }
    }
}