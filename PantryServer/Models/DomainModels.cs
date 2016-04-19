using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PantryServer.Controllers;
using PantryServer.Infrastructure;

namespace PantryServer.Models
{
    public class Shop
    {
        public ApplicationUser User { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Product> Product { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}