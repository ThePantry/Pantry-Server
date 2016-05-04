using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PantryServer.Services
{
    public class BlobService
    {
        public string GetBlobPath(string title)
        {
            //Todo: get path for item with title in name
            return "brussel";
        }

        public string[] GetMultipleBlobPaths(string[] title)
        {
            //Todo: get path for item with title in name
            return new[]{ "brussel", "sprout" };
        }
    }
}