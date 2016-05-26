using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PantryServer.Models.ViewModels
{
    public class ProductCollectionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }

    public class ProductViewModel
    {
        public string Name { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public int Price { get; set; }
        public List<string> ImagePaths { get; set; }
        public int CurrentStock { get; set; }
    }
}
