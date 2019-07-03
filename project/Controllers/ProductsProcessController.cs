using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project.Models;
using Microsoft.AspNet.Identity;

namespace project.Controllers
{
    public class ProductsProcessController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductsProcess
        public ActionResult Index()
        {
           
                var products = db.Products.Include(p => p.category).Include(p => p.ProductColor).Include(p => p.ProductSize);

                return View(products.ToList());
           
          
               
            

        }

        // GET: ProductsProcess/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: ProductsProcess/Create
        public ActionResult Create()
        {
            ViewBag.category_ID = new SelectList(db.Categorys, "ID", "CategoryName");
            ViewBag.ProductColor_ID = new SelectList(db.ProductColors, "ID", "Color");
            ViewBag.ProductSize_ID = new SelectList(db.ProductSizes, "ID", "Size");
            return View();
        }

        // POST: ProductsProcess/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductName,PriceBeforeDiscount,PriceAfterDiscount,Discount,QuantityInStock,QuantitySoldProduct,Picture,category_ID,ProductSize_ID,ProductColor_ID,ProductDiscription")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_ID = new SelectList(db.Categorys, "ID", "CategoryName", product.category_ID);
            ViewBag.ProductColor_ID = new SelectList(db.ProductColors, "ID", "Color", product.ProductColor_ID);
            ViewBag.ProductSize_ID = new SelectList(db.ProductSizes, "ID", "Size", product.ProductSize_ID);
            return View(product);
        }

        // GET: ProductsProcess/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_ID = new SelectList(db.Categorys, "ID", "CategoryName", product.category_ID);
            ViewBag.ProductColor_ID = new SelectList(db.ProductColors, "ID", "Color", product.ProductColor_ID);
            ViewBag.ProductSize_ID = new SelectList(db.ProductSizes, "ID", "Size", product.ProductSize_ID);
            return View(product);
        }

        // POST: ProductsProcess/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductName,PriceBeforeDiscount,PriceAfterDiscount,Discount,QuantityInStock,QuantitySoldProduct,Picture,category_ID,ProductSize_ID,ProductColor_ID,ProductDiscription")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_ID = new SelectList(db.Categorys, "ID", "CategoryName", product.category_ID);
            ViewBag.ProductColor_ID = new SelectList(db.ProductColors, "ID", "Color", product.ProductColor_ID);
            ViewBag.ProductSize_ID = new SelectList(db.ProductSizes, "ID", "Size", product.ProductSize_ID);
            return View(product);
        }

        // GET: ProductsProcess/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: ProductsProcess/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
