using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PantryServer.Models.EmberViews
{
    public class AboutViewModel
    {
        public string Heading { get; set; }
        //Content variables will contain an html string
        public string Content { get; set; }
        public List<string> ImagePaths { get; set; }
        public List<string> Testimonials { get; set; }
    }

    public class ContactViewModel
    {
        public string Heading { get; set; }
        public string Content { get; set; }
        public List<string> VendorImagesPaths { get; set; }
    }
    
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

        public int Price { get; set; }
        public string Content { get; set; }
        public List<string> ImagePaths { get; set; }
    }
}