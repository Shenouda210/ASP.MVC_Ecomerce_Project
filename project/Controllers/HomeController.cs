using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;

namespace project.Controllers
{
   
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // /Home/Index
        public ActionResult Index()
        {
            var Categeories = db.Categorys.ToList();
            return View(Categeories);
        }
        public ActionResult CategoryPartialAction(int id)
        {
            var category = db.Categorys.FirstOrDefault(c=>c.ID==id);
            return View("_ProductSlicke", category);
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}