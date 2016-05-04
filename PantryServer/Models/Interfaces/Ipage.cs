using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PantryServer.Models.Interfaces
{
    public interface IPage
    {
        int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string HeroImage { get; set; }
        List<string> ImagePaths { get; set; }
    }
}