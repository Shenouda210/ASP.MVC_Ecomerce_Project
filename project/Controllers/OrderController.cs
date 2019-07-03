using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace project.Controllers
{   [Authorize]
    public class OrderController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Order
        public ActionResult checkout()
        {
          
                return View((List<VMCART>)Session["products"]);
            
           
        }
      
        public ActionResult SaveOrder()
        {
            if (Session["products"] != null)
            {
                var user = User.Identity.Name;
           
                var CartsProducts = (List<VMCART>)Session["products"];
                Order order = new Order();
                order.OrderDate =  DateTime.Now;
                order.apliacationUser_ID = db.Users.FirstOrDefault(c => c.UserName == user).Id;
                Product p = new Product();
                int TotalPrice = 0;
                foreach (var productInCart in CartsProducts)
                {
                   
                        OrderDetails details = new OrderDetails();
                    details.orderID = order.ID;
                      details.productID=  productInCart.prod.ID;
                       details.Quantity=  productInCart.Quantity;
                        db.OrderDetails.Add(details);

                    TotalPrice = TotalPrice + productInCart.prod.PriceAfterDiscount;

                }
                order.TotalPrice = TotalPrice;

                db.Orders.Add(order);
                db.SaveChanges();

            }
            else
            {

            }

            return View("checkout");
        }
    }
}