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
        string Description { get; set; }
        List<Tag> Tags { get; set; }
    }

    public interface IProductCollection
    {
        int Id { get; set; }
        string Name { get; set; }
        List<Product> Products { get; set; }
    }

    public interface ITag
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}