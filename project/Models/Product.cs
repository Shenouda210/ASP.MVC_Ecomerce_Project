using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int PriceBeforeDiscount { get; set; }
        public int PriceAfterDiscount { get; set; }
        public float Discount { get; set; }
        public int QuantityInStock { get; set; }
   

        public string Picture { get; set; }
        [ForeignKey("category")]
        public int category_ID { get; set; }
        [ForeignKey("ProductSize")]
        public int ProductSize_ID { get; set; }
        [ForeignKey("ProductColor")]
        public int ProductColor_ID { get; set; }

        public virtual Category category { get; set; }
        public string ProductDiscription { get; set; }
       
        public virtual ProductSize ProductSize { get; set; }
        public virtual ProductColor ProductColor { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();




    }
}