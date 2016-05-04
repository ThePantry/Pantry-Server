using System.Collections.Generic;
using PantryServer.Infrastructure;

namespace PantryServer.Models.Interfaces
{
    public interface IShop
    {
        ApplicationUser User { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        List<Product> Products { get; set;}
        List<IPage> Pages { get; set; }
        string Location { get; set; }
        string Description { get; set; }
        string Email { get; set; }
    }
}