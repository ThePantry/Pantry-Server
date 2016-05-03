using System.Collections.Generic;
using PantryServer.Models.Interfaces;

namespace PantryServer.Models
{
    public class ProductCollection : IProductCollection
    {
        public List<Product> Products { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}