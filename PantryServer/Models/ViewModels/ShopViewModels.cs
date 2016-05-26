using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PantryServer.Models.ViewModels
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
        //Content variables will contain an html string
        public string Content { get; set; }
        public List<string> VendorImagesPaths { get; set; }
    }
    
    public class ShopInformationViewModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public int ShopId { get; set; }
    }
}