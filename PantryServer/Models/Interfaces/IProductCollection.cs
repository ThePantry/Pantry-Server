using System.Collections.Generic;

namespace PantryServer.Models.Interfaces
{
    public interface IProductCollection
    {
        int Id { get; set; }
        string Name { get; set; }
        List<Product> Products { get; set; }
    }
}