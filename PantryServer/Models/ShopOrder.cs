using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PantryServer.Models
{
    public class ShopOrder
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
    }
}