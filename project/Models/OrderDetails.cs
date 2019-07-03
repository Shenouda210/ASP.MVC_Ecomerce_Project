
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        [ForeignKey("order")]
        public int orderID { get; set; }
        [ForeignKey("product")]
        public int productID { get; set; }
        public int Quantity { get; set; }

        public virtual Order order { get; set; }
        public virtual Product product { get; set; }
    }
}