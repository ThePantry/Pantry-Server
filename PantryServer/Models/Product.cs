using System.Collections.Generic;
using PantryServer.Models.Interfaces;

namespace PantryServer.Models
{
    public class Product
    {
        public int Id { get; set; }
        //TODO move to inventry service
        public int? Quantity { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public List<Tag> Tags { get; set; }
        public List<string> ImagePaths { get; set; }
    }
}