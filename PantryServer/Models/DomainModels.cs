using System.Collections.Generic;
using PantryServer.Infrastructure;
using PantryServer.Models.Interfaces;

namespace PantryServer.Models
{
    public class Shop : IShop
    {
        public ApplicationUser User { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }

    public class Tag : ITag
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; } 
    }

    public class ProductCollection : IProductCollection
    {
        public List<Product> Products { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}