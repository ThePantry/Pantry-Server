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

        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Title
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string HeroImage
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public List<string> ImagePaths
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string[] images
        {
            get
            {
                return blob.GetMultipleBlobPaths(new[] { "hello", "hello" });
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}