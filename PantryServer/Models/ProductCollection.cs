using System.Collections.Generic;
using PantryServer.Models.Interfaces;

namespace PantryServer.Models
{
    public class ProductCollection : IProductCollection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public List<Product> Products { get; set; }
    }
}