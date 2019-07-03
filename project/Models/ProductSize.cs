using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class ProductSize
    {
        public int ID { get; set; }
        public string Size { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}