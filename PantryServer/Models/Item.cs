using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Web;

namespace PantryServer.Models
{
    public class Item
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string SizeTyoe { get; set; }    
        public Shop Shop { get; set; }
    }
}