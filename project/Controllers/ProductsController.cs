using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;
namespace project.Models
{
    public class ProductsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index()
        {
            var ProductList = db.Products.ToList();
            
            return View("index",ProductList);
        }
        public ActionResult displayProduct(int id)
        {
           
              var prd = db.Products.FirstOrDefault(c => c.ID == id);
            ViewBag.Cateogry = db.Categorys.FirstOrDefault(c => c.ID==prd.category_ID);
            ViewBag.Cateogries = db.Categorys.ToList();

            return View(prd);
        }

        public ActionResult DisplayCart()
        {
            

            return View ((List<VMCART>)Session["products"]);

        }
        [Route("AddToCart/{id}")]
        public ActionResult AddToCart(int id,int Qunatity)
        {
            var prd = db.Products.FirstOrDefault(c => c.ID == id);

            if (Session["products"] == null)
            {
                List<VMCART> procart = new List<VMCART>();
                VMCART vc = new VMCART();
                vc.prod = prd;
                vc.Quantity = Qunatity;
                procart.Add(vc);
                Session["products"] = procart;
            }
            else
            {
              List<VMCART>procart= (List<VMCART>)Session["products"];
                foreach (var item in procart)
                {
                    if(item.prod.ID==id)
                    {
                        item.Quantity += Qunatity;
                        return View("_Navbar", (List<VMCART>)Session["products"]);

                    }
                }
                VMCART vc = new VMCART();
                vc.prod = prd;
                vc.Quantity = Qunatity;
                procart.Add(vc);
                Session["products"] = procart;

            }
                        return View("_Navbar", (List<VMCART>)Session["products"]);


        }
    }
}