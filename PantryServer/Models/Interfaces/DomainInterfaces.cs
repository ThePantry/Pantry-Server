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
        string Location { get; set; }
        string Description { get; set; }
        string Email { get; set; }
    }

    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        Category Category { get; set; }
    }

    public interface ICategory
    {
        int Id { get; set; }
        string Name { get; set; }
        List<Product> Products { get; set; }
    }
}