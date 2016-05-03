using System.Collections.Generic;
using PantryServer.Models.Interfaces;

namespace PantryServer.Models
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        //TODO move to inventry service
        public int? Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; } 
    }
}