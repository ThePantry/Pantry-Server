using PantryServer.Models.Interfaces;
using PantryServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PantryServer.Models.Pages
{
    public class LandingPage : IPage
    {
        private BlobService blob = new BlobService();

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string HeroImage { get; set; }

        public List<string> ImagePaths { get; set; }


    }
}