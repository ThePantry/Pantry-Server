using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PantryServer.Models.Pages
{
    public class ContactPage
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public List<string> VendorImagesPaths { get; set; }
    }
}