using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CakeArtWebAPI.Models
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Price{ get; set; }

        public Product(int id,string name,string price)
        {
            this.id = id;
            this.Name = name;
            this.Price = price;
        }

    }
}