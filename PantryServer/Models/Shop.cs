using System.Collections.Generic;
using PantryServer.Infrastructure;
using PantryServer.Models.Interfaces;
using PantryServer.Models.Pages;

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
        public AboutPage AboutPage { get; set; }
        
    }
}