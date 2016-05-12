using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PantryServer.Models.Pages
{
    public class AboutPage
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public List<string> ImagePaths { get; set; }
        public List<string> Testimonials { get; set; }
    }
}