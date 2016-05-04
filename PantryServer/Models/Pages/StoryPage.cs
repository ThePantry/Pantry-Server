using PantryServer.Models.Interfaces;
using PantryServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PantryServer.Models.Pages
{
    public class StoryPage : IPage
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

        public string image
        {
            get
            {
                return blob.GetBlobPath(HeroImage);
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}