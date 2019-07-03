using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }

        [ForeignKey("identityUser")]
        public string apliacationUser_ID { get; set; }

        public virtual ApplicationUser identityUser { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }

}