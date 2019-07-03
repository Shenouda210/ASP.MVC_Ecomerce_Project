using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class DisplayCategoriesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: DisplayAllCategories
        public ActionResult AllCategories()
        {
            var Cateogries = db.Categorys.ToList();
            return View(Cateogries);
        }
        // GET: Cameras
        public ActionResult Cameras()
        {
            var Cateogry = db.Categorys.FirstOrDefault(c=>c.CategoryName.Contains("Cameras"));
            return View("Collection",Cateogry);
        }
        // GET: HEADPHONES
        public ActionResult HEADPHONES()
        {
            var Cateogry = db.Categorys.FirstOrDefault(c => c.CategoryName.Contains("HEADPHONES"));
            return View("Collection", Cateogry);
        }
        // GET: Smartphones
        public ActionResult Smartphones()
        {
            var Cateogry = db.Categorys.FirstOrDefault(c => c.CategoryName.Contains("Smartphones"));
            return View("Collection", Cateogry);
        }
        // GET: ACCESSORIES
        public ActionResult ACCESSORIES()
        {
            var Cateogry = db.Categorys.FirstOrDefault(c => c.CategoryName.Contains("ACCESSORIES"));
            return View("Collection", Cateogry);
        }
        // GET: Labtop
        public ActionResult Labtop()
        {
            var Cateogry = db.Categorys.FirstOrDefault(c => c.CategoryName.Contains("Labtop"));
            return View("Collection", Cateogry);
        }
        [HttpGet]
        public ActionResult categoryByID(int ID)
        {
            var Cateogry = db.Categorys.FirstOrDefault(c => c.ID== ID);
            return View("Collection", Cateogry);
        }
    }
}